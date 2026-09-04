Imports System.Data
Imports System.Data.OracleClient
Partial Class ESI_hrm_esi_add_4adc98564126
    Inherits System.Web.UI.Page
    Dim cbResult As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode, stat As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CType(Me.Master, WebAppHRMS.edp).Subtitle = "ESI Number Add"

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtDesp.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim emno As Integer = oh.ExecuteDataSet("select count(*) from hrm_esi_add t where t.emp_code=" & UserCode & "").Tables(0).Rows(0)(0)

        If emno > 0 Then

            str_tkn.Append("         alert('Already Entered...!');")
            str_tkn.Append(" window.open('../Home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)

        Else

            Dim name As String = oh.ExecuteDataSet("select e.emp_name from employee_master e where e.emp_code=" & UserCode).Tables(0).Rows(0)(0)
            Me.txtEcode.Text = name.ToString()

        End If

    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Try

            Dim p(5) As OracleParameter

            p(0) = New OracleParameter("EmpID", OracleType.Number, 6)
            p(0).Value = UserCode

            p(1) = New OracleParameter("Eno", OracleType.VarChar, 15)
            p(1).Value = Me.txtEsiNo.Text

            p(2) = New OracleParameter("Ebr", OracleType.VarChar, 25)
            p(2).Value = Me.txtEsiBranch.Text

            p(3) = New OracleParameter("Dis", OracleType.VarChar, 25)
            p(3).Value = Me.txtDesp.Text

            p(4) = New OracleParameter("EntryDt", OracleType.VarChar, 15)
            p(4).Value = Me.txtDate.Text

            p(5) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
            p(5).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_esi_add_proc", p)

            Dim fnm, sql As String
            Dim cp As String = Me.Server.MapPath(Me.Request.ApplicationPath)


            If FileUpload1.FileName <> "" Then

                Dim fileExtension As String
                fileExtension = System.IO.Path. _
                    GetExtension(Me.FileUpload1.FileName).ToLower()
                Dim allowedExtensions As String() = _
                    {".jpg", ".jpeg", ".png", ".bmp"}
                Dim fileok As Boolean
                fileok = False
                For j As Integer = 0 To allowedExtensions.Length - 1
                    If fileExtension = allowedExtensions(j) Then
                        fileok = True
                    End If
                Next
                If Not (fileok) Then
                    Dim cl_script1 As New StringBuilder
                    cl_script1.Append("   alert('Attachement Type Not Supported (JPG,JPEG,PNG,BMP only supported)!!') ;")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)
                    Exit Sub
                End If

                fnm = GetUniqueFilename(cp + "..\image\" + "IDPhoto.jpg")
                If Me.FileUpload1.HasFile Then
                    Me.FileUpload1.SaveAs(fnm)
                End If
                Dim fs As New IO.FileStream(fnm, IO.FileMode.Open, IO.FileAccess.Read)
                Dim bl(fs.Length) As Byte
                fs.Read(bl, 0, fs.Length)
                fs.Close()
                Dim fp As New IO.FileInfo(fnm)
                If fp.Exists Then
                    fp.Delete()
                End If

                Dim oh As New helper.oracle.OracleHelper
                sql = "update dms.hrm_id_esi_photo a set a.esi_photo = :ph where a.emp_code = :EmpCode"
                Dim parm_coll(1) As OracleParameter
                parm_coll(0) = New OracleParameter
                parm_coll(0).ParameterName = "ph"
                parm_coll(0).OracleType = OracleType.Blob
                parm_coll(0).Direction = ParameterDirection.Input
                parm_coll(0).Value = bl

                parm_coll(1) = New OracleParameter
                parm_coll(1).ParameterName = "EmpCode"
                parm_coll(1).OracleType = OracleType.Number
                parm_coll(1).Direction = ParameterDirection.Input
                parm_coll(1).Value = UserCode

                oh.ExecuteNonQuery(sql, parm_coll)
            End If

            str_tkn.Append("         alert('" & p(5).Value & "');")
            str_tkn.Append(" window.open('../Home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        Catch ex As Exception

        End Try

    End Sub
    Public Shared Function GetUniqueFilename(ByVal FileName As String) As String
        Dim count As Integer = 0
        Dim Name As String = ""
        If System.IO.File.Exists(FileName) Then
            Dim f As New System.IO.FileInfo(FileName)
            If Not String.IsNullOrEmpty(f.Extension) Then
                Name = f.FullName.Substring(0, f.FullName.LastIndexOf("."))
            Else
                Name = f.FullName
            End If
            While System.IO.File.Exists(FileName)
                count += 1
                FileName = Name + count.ToString() + f.Extension
            End While
        End If
        Return FileName
    End Function
End Class

