Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class Acc_file_Recevied
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh, oh1 As New Helper.Oracle.OracleHelper
    Dim res As String
    Dim frm As Integer
    Dim sf() As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "EMPLOYEE ENROLLMENT"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.Subtitle = "ACCOUNTS FILE MOVEMENT RECEIVER PAGE"
        frm = Session("firm_id")
        Dim script_val As String
        Dim dt1 As New DataTable
        'script_val = "var loanno;" & "loanno='" & "" & Me.file_no.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server(arg,context) { " & cbref & "; } "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
        btnDownload.Attributes("onchange") = "UploadFile(this)"
        sf = Session("user_id").ToString.Split("!")

        dt1 = oh1.ExecuteDataSet("select count(t.emp_id) ecod  from form_accessibility t  where form_id = 9992  and emp_id = " & Session("user_id").ToString.Split("!")(0)).Tables(0)
        If dt1.Rows(0)(0) = 0 Then
            Server.Transfer("~/show_err.aspx")
        End If
        'If Session("access_id") = 33 Then
        If Not IsPostBack Then


            Dim dt As New DataTable

            'dt = oh.ExecuteDataSet("SELECT NULL AS file_no, NULL AS ref_no, '------------------Select------------------' AS display_text  FROM dual  UNION ALL  SELECT h.file_no, h.ref_no, h.ref_no || ' --- ' || h.entered_by || ' --- ' || h.remark AS display_text  FROM tbl_accfile_mov h  WHERE h.status = 0 AND h.receiver_name = " & sf(0)).Tables(0)
            dt = oh.ExecuteDataSet("SELECT 0 AS file_no, '------------------Select------------------' AS display_text FROM dual UNION ALL SELECT h.file_no, h.file_name || ' --- ' || h.entered_by || ' --- ' || h.remark AS display_text FROM tbl_accfile_mov h WHERE h.status = 0 AND h.receiver_name = " & sf(0)).Tables(0)

            cmb_file.DataSource = dt
            cmb_file.DataTextField = "display_text"
            cmb_file.DataValueField = "file_no"   ' <-- use file_no here
            cmb_file.DataBind()


        End If



        Try


            Catch ex As Exception
            Finally
                dt1.Dispose()
            End Try



            ' Response.Redirect("../../show_err.aspx")
        ' End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

    End Sub

    Protected Sub cmd_confirm_Click(sender As Object, e As EventArgs) Handles cmd_confirm.Click
        If String.IsNullOrWhiteSpace(rcremark.Value) Then
            lbl_err.Text = "Please enter receiver remark."
            Exit Sub
        End If

        Dim op(13) As OracleParameter
        Try
            ' File_No (unique key)
            op(0) = New OracleParameter("File_Num", OracleType.Number)
            op(0).Value = Convert.ToInt32(Me.hid2.Value)   ' hidden field stores file_no
            op(0).Direction = ParameterDirection.Input

            ' Ref_No
            op(1) = New OracleParameter("Ref_Num", OracleType.VarChar, 30)
            op(1).Value = Me.cmb_file.SelectedValue
            op(1).Direction = ParameterDirection.Input

            ' Req_Name (not really needed here, but procedure requires it)
            op(2) = New OracleParameter("Req_Names", OracleType.VarChar, 20)
            op(2).Value = DBNull.Value
            op(2).Direction = ParameterDirection.Input

            ' Dep_Name
            op(3) = New OracleParameter("Dep_Names", OracleType.VarChar, 30)
            op(3).Value = DBNull.Value
            op(3).Direction = ParameterDirection.Input

            ' Purpose
            op(4) = New OracleParameter("Purposes", OracleType.VarChar, 50)
            op(4).Value = DBNull.Value
            op(4).Direction = ParameterDirection.Input

            ' Receiver_Name
            op(5) = New OracleParameter("Receiver_Names", OracleType.VarChar, 20)
            op(5).Value = DBNull.Value
            op(5).Direction = ParameterDirection.Input

            ' Upload_file
            op(6) = New OracleParameter("Upload_files", OracleType.Blob)
            op(6).Value = DBNull.Value
            op(6).Direction = ParameterDirection.Input

            ' Upload_filename
            op(7) = New OracleParameter("Upload_filenames", OracleType.VarChar, 200)
            op(7).Value = DBNull.Value
            op(7).Direction = ParameterDirection.Input

            ' Upload_contenttype
            op(8) = New OracleParameter("Upload_contenttypes", OracleType.VarChar, 100)
            op(8).Value = DBNull.Value
            op(8).Direction = ParameterDirection.Input

            ' Remark (requester remark, not needed here)
            op(9) = New OracleParameter("Remarks", OracleType.VarChar, 200)
            op(9).Value = DBNull.Value
            op(9).Direction = ParameterDirection.Input

            ' Receiver_Remark
            op(10) = New OracleParameter("Receiver_Remarks", OracleType.VarChar, 200)
            op(10).Value = Me.rcremark.Value.Trim()
            op(10).Direction = ParameterDirection.Input

            ' ActionType
            op(11) = New OracleParameter("ActionTypes", OracleType.VarChar, 20)
            op(11).Value = "Receive"
            op(11).Direction = ParameterDirection.Input

            ' Message (output)
            op(12) = New OracleParameter("messages", OracleType.VarChar, 2000)
            op(12).Direction = ParameterDirection.Output

            op(13) = New OracleParameter("file", OracleType.Number)
            op(13).Direction = ParameterDirection.Output

            ' Execute
            oh.ExecuteNonQuery("Acc_File_Movement", op)

            Dim message As String = If(op(12).Value IsNot Nothing, op(12).Value.ToString(), "")
            Dim cl_script1 As New System.Text.StringBuilder(1, 500)
            cl_script1.Append("alert('" & message.Replace("'", "\'") & "');")
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "client script", cl_script1.ToString(), True)


            cmb_file.ClearSelection()
            req_name.Value = String.Empty
            dep_name.Value = String.Empty
            purpose.Value = String.Empty
            rdate.Value = String.Empty
            btnDownload.Enabled = False
            rqremark.Value = String.Empty
            rcremark.Value = String.Empty

            ' --- REFRESH DROPDOWN HERE ---
            Dim dt As New DataTable
            dt = oh.ExecuteDataSet("SELECT 0 AS file_no, '------------------Select------------------' AS display_text FROM dual UNION ALL SELECT h.file_no, h.file_name || ' --- ' || h.entered_by || ' --- ' || h.remark AS display_text FROM tbl_accfile_mov h WHERE h.status = 0 AND h.receiver_name = " & sf(0)).Tables(0)

            cmb_file.DataSource = dt
            cmb_file.DataTextField = "display_text"
            cmb_file.DataValueField = "file_no"
            cmb_file.DataBind()
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub cmb_file_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_file.SelectedIndexChanged
        Dim dt As New DataTable
        Dim User() As String = Session("user_id").ToString.Split("!")

        ' Get ref_no directly from SelectedValue
        Dim fileNo As String = cmb_file.SelectedValue

        dt = oh.ExecuteDataSet("SELECT h.file_name, t.emp_name || '*' || h.dep_name || '*' || h.purpose || '*' || h.req_date || '*' || h.remark AS details FROM tbl_accfile_mov h JOIN employee_master t ON h.req_name = t.emp_code WHERE h.receiver_name = '" & User(0) & "' AND h.status = 0 AND h.file_no = '" & fileNo & "' ORDER BY h.entered_by").Tables(0)

        If dt.Rows.Count > 0 Then
            Dim StrArr() As String = dt.Rows(0)("details").ToString().Split("*"c)

            Me.req_name.Value = StrArr(0).ToString()
            Me.dep_name.Value = StrArr(1).ToString()
            Me.purpose.Value = StrArr(2).ToString()
            Me.rdate.Value = StrArr(3).ToString()
            Me.rqremark.Value = StrArr(4).ToString()

            Me.hid_appln_no.Value = dt.Rows(0)("file_name").ToString()
            Me.hid2.Value = cmb_file.SelectedValue   ' keep ref_no here
        End If

        dt.Dispose()
    End Sub


    Protected Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        Try

            Dim refNo As String = Me.hid_appln_no.Value

            Dim dt As DataTable = oh.ExecuteDataSet("SELECT upload_file, upload_filename, upload_contenttype FROM tbl_accfile_mov WHERE file_name = '" & refNo & "'").Tables(0)

            If dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)("upload_file")) Then
                Dim fileData As Byte() = DirectCast(dt.Rows(0)("upload_file"), Byte())
                Dim fileName As String = dt.Rows(0)("upload_filename").ToString()
                Dim contentType As String = dt.Rows(0)("upload_contenttype").ToString()

                Response.Clear()
                Response.ContentType = contentType
                Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
                Response.BinaryWrite(fileData)
                Response.End()
            Else
                lbl_err.Text = "No file found for this record."
            End If

        Catch ex As Exception
            lbl_err.Text = "Error while downloading: " & ex.Message
        End Try
    End Sub

End Class