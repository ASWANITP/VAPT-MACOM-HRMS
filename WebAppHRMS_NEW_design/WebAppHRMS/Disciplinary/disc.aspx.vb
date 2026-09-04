Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Partial Class HRM_SECURITY_hrm_Add_Post_528746868019
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim dt1, dt2, dt3, dt4, dtt, dt5 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim BranchID, AreaID, RegionID As Integer
    Dim str_tkn As New System.Text.StringBuilder
    Dim val, ld, flag, appln_no As Integer
    Dim sql7 As String
    Dim sql8 As String
    Dim CbResult As String = Nothing
    Dim d1, d2, d3, d4 As String
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.Txt_FromTime1.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)


        Dim usr() As String = Session("user_id").Split("!")
        dt1 = oh.ExecuteDataSet("select count(*) from form_accessibility  where form_id=5195 and emp_id=" & usr(0) & "").Tables(0)
        Dim access As Integer = dt1.Rows(0)(0)
        If Session("access_id") = 33 Or access > 0 Then
            If Not IsPostBack Then
                dt2 = oh.ExecuteDataSet("select '---SELECT---', 0 b from dual union all select e.emp_name || '<->' || e.emp_code, e.emp_code from employee_master e, employ_firm f, branch_master b, department_mst d, designation_master m, post_mst p where e.status_id = 1 and f.firm_id = 8 and e.emp_code = f.emp_code and e.branch_id = b.branch_id and e.designation_id = m.designation_id and e.department_id = d.dep_id and e.post_id = p.post_id order by b").Tables(0)
                Me.textb1.DataSource = dt2
                Me.textb1.DataValueField = dt2.Columns(1).ColumnName
                Me.textb1.DataTextField = dt2.Columns(0).ColumnName
                Me.textb1.DataBind()
                dt3 = oh.ExecuteDataSet("select '---SELECT---', 0 from dual union all select upper(ms.discipline_name),ms.discipline_id from HRM_DISCIPLINARY_MASTER ms").Tables(0)
                Me.DropDownList1.DataSource = dt3
                Me.DropDownList1.DataValueField = dt3.Columns(1).ColumnName
                Me.DropDownList1.DataTextField = dt3.Columns(0).ColumnName
                Me.DropDownList1.DataBind()
                Me.Txt_FromTime1.Text = "00:00 am "
                Me.Txt_ToTime.Text = "00:00 am "

            End If
        Else
            Response.Redirect("../show_err.aspx")
        End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

    End Sub
    Protected Sub textb1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles textb1.SelectedIndexChanged
        dt4 = oh.ExecuteDataSet("select d.dep_name,p.post_name,e.designation from employee_MASTER ms,department_mst d,post_mst p,designation_master e where d.dep_id=ms.department_id and p.post_id=ms.post_id and e.designation_id=ms.designation_id and ms.emp_code=" & Me.textb1.SelectedValue & "").Tables(0)
        Me.Label1.Text = dt4.Rows(0)(0).ToString
        Me.Label2.Text = dt4.Rows(0)(1).ToString
        Me.Label3.Text = dt4.Rows(0)(2).ToString
    End Sub


    Protected Sub Button1confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1confirm.Click


        'Dim usr() = Session("user_id").ToString.Split("!")

        Label1.Visible = True
        Dim filePath As String = Me.FileUpload1.PostedFile.FileName
        Dim filePath1 As String = Me.FileUpload2.PostedFile.FileName
        Dim filename1 As String = Path.GetFileName(filePath)
        Dim filename2 As String = Path.GetFileName(filePath1)
        Dim ext As String = Path.GetExtension(filename1)
        Dim ext1 As String = Path.GetExtension(filename2)
        Dim type As String = String.Empty
        Dim type1 As String = String.Empty
        Dim file1 As Byte() = Me.FileUpload1.FileBytes
        Dim file2 As Byte() = Me.FileUpload2.FileBytes

        If Me.textb1.Text = 0 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Enter Employee Code');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)


        ElseIf Me.DropDownList1.SelectedValue = 0 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please SELECT DISCIPLINARY');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)



        ElseIf Me.tb_fd.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Enter fromdate');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)


        ElseIf Me.tb_td.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Enter TOdate');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)



        ElseIf Me.TextBox8.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Enter comments');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)


        ElseIf textb1.SelectedValue = "" Or DropDownList1.SelectedValue = "" Or TextBox6.Text = "" Or Txt_ToTime.Text = "" Then

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append(" alert('PLEASE ENTER ALL DETAILS');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

            Dim cl_script9 As New System.Text.StringBuilder
            cl_script9.Append("         alert('Please select to date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script9.ToString, True)

        ElseIf (CDate(Me.tb_fd.Text) > CDate(Format(Me.tb_td.Text))) Then
            Dim cl_script9 As New System.Text.StringBuilder
            cl_script9.Append(" alert('Future date is not allowed in From Date!! ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)

            'ElseIf (CDate(Me.tb_td.Text) > CDate(Format(Date.Today, "dd/MMM/yyyy"))) Then
            '    Dim cl_script9 As New System.Text.StringBuilder
            '    cl_script9.Append(" alert('Future date is not allowed in TO Date!! ');")
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)


        ElseIf (Me.FileUpload1.HasFile = False) Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Upload File ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        ElseIf (Me.FileUpload2.HasFile = False) Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Upload File ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        ElseIf (ext <> ".pdf") Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('File Format Is Not Supported');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        ElseIf (ext1 <> ".pdf") Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('File Format Is Not Supported');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)




        ElseIf (Me.FileUpload1.HasFile) Then
            'If (Me.file_support1.PostedFile.ContentLength > 20728650) Then
            If (Me.FileUpload1.PostedFile.ContentLength > 1048576) Then

                'If (Me.file_support1.PostedFile.ContentLength >= 50000) Then
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('File size exceeds maximum limit 50 KB.') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)


                'ElseIf Me.FileUpload1.HasFile Then
            Else


                Try

                    Select Case ext
                        Case ".pdf"
                            type = "application/pdf"
                    End Select




                    If type <> String.Empty Then


                        Dim fs As Stream = Me.FileUpload1.PostedFile.InputStream
                        Dim br As BinaryReader = New BinaryReader(fs)
                        Dim bytes As Byte() = br.ReadBytes(CType(fs.Length, Int32))
                        Dim fs1 As Stream = Me.FileUpload2.PostedFile.InputStream
                        Dim br1 As BinaryReader = New BinaryReader(fs)
                        Dim bytes1 As Byte() = br.ReadBytes(CType(fs.Length, Int32))
                        Dim b1 As Byte() = Me.FileUpload1.FileBytes
                        Dim b2 As Byte() = Me.FileUpload2.FileBytes


                        Dim dt5 As DataTable = oh.ExecuteDataSet("select l.emp_code from DISCIPLINARY_DTL l where l.emp_code=" & Me.textb1.Text & " and l.DISCIPLINARYID= " & Me.DropDownList1.SelectedValue & "  and l.OCCUREDFRMDT= ' " & Me.tb_fd.Text & " ' ").Tables(0)


                        If dt5.Rows.Count = 0 Then

                            sql7 = "INSERT into DISCIPLINARY_DTL(emp_code,DISCIPLINARYID,USERCOMMENTS,OCCUREDFRMDT,OCCUREDTODT,SHOWCAUSEGVNDT,CAUSERPLYDT,OCCUREDFRMTM,OCCUREDTOTM,SHOWCAUSEATTACHNAME,SHOWCAUSERPLYATTACHNAME)values(" & Me.textb1.SelectedValue & "," & Me.DropDownList1.SelectedValue & ",' " & Me.TextBox8.Text & " ',' " & Me.tb_fd.Text & " ',' " & Me.tb_td.Text & " ',' " & Me.TextBox6.Text & " ',' " & Me.TextBox3.Text & " ', ' " & Me.Txt_FromTime1.Text & " ',' " & Me.Txt_ToTime.Text & " ', ' " & Me.FileUpload1.FileName & " ', ' " & Me.FileUpload2.FileName & " ')"




                            oh.ExecuteNonQuery(sql7)
                            Dim sq As String


                            sq = "UPDATE DISCIPLINARY_DTL h set h.ATTACHMENT= :attah,h.SHOWATTACHMENT= :shwattach where h.emp_code= :code"


                            Dim prr(2) As OracleParameter




                            prr(0) = New OracleParameter
                            prr(0).ParameterName = "attah"
                            prr(0).OracleType = OracleType.Blob
                            prr(0).Direction = ParameterDirection.Input
                            prr(0).Value = Me.FileUpload1.FileBytes



                            prr(1) = New OracleParameter
                            prr(1).ParameterName = "shwattach"
                            prr(1).OracleType = OracleType.Blob
                            prr(1).Direction = ParameterDirection.Input
                            prr(1).Value = Me.FileUpload2.FileBytes


                            prr(2) = New OracleParameter
                            prr(2).ParameterName = "code"
                            prr(2).OracleType = OracleType.Number
                            prr(2).Direction = ParameterDirection.Input
                            prr(2).Value = Me.textb1.SelectedValue


                            oh.ExecuteNonQuery(sq, prr)



                            Dim cl_script5 As New System.Text.StringBuilder
                            cl_script5.Append(" alert('successfully inserted');")
                            cl_script5.Append("window.open('disc.aspx','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script5.ToString, True)


                        Else
                            Dim cl_script2 As New System.Text.StringBuilder
                            cl_script2.Append("alert('already inserted');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script2.ToString, True)

                        End If
                    End If


                Catch ex As Exception
                    Response.Write(ex.Message.ToString)

                End Try
            End If

        End If


    End Sub


    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("../home.aspx")
    End Sub



End Class





