Imports System.Data
Imports System.Data.OracleClient
Imports System.Net.Mail
Imports System.Net
Imports System.IO
Partial Class Regularisation_Regularisation_Request_2fe6d9d75747
    Inherits System.Web.UI.Page
    Dim cbResult As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dta, dts As New DataTable
    Dim us, res, sql, str As String
    Dim sql7, sql1, sql20, fnm As String
    Dim frm, u1 As Integer

    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim usr() = Session("user_id").ToString.Split("!")

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtBranch.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)



        If Not IsPostBack Then

            dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,b.BRANCH_NAME,p.post_name,d.designation,em.emp_name dephead from employee_master e,post_mst p,designation_master d,branch_dtl_new b,employ_firm ef,employee_master em,department_mst t where e.branch_id=b.BRANCH_ID and e.post_id=p.post_id and e.designation_id=d.designation_id and t.dep_head = em.emp_code and t.dep_id = e.department_id and e.status_id =1 and e.emp_code=" & usr(0) & " and ef.firm_id=" & Session("firm_id") & " and ef.emp_code=" & usr(0) & "").Tables(0)
            Me.txtEcode.Text = dt.Rows(0)(0)
            Me.txtEname.Text = dt.Rows(0)(1)
            Me.txtBranch.Text = dt.Rows(0)(2)
            Me.txtPost.Text = dt.Rows(0)(3)
            Me.txtDes.Text = dt.Rows(0)(4)
            Me.TxtDep.Text = dt.Rows(0)(5)
            Me.txtDate.Text = Format(Now.Date, "dd/MM/yyyy")



            Dim dt1 As DataTable = oh.ExecuteDataSet("select 0 ecode,'-----------SELECT-----------' as emp from dual union select e.emp_code ecode, e.emp_code || '-' || e.emp_name from employee_master e where e.firm_id=8 and e.status_id=1 order by ecode").Tables(0)
            Me.Ddltech.DataSource = dt1
            Me.Ddltech.DataTextField = dt1.Columns(1).ColumnName
            Me.Ddltech.DataValueField = dt1.Columns(0).ColumnName
            Me.Ddltech.DataBind()

        End If

    End Sub


    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click


        Dim usr() = Session("user_id").ToString.Split("!")

        Label1.Visible = True
        Dim filePath As String = Me.file_support1.PostedFile.FileName
        Dim filename1 As String = Path.GetFileName(filePath)
        Dim ext As String = Path.GetExtension(filename1)

        Dim type As String = String.Empty
        Dim file1 As Byte() = Me.file_support1.FileBytes



        If Me.txtEcode.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Enter Employee Code');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)


        ElseIf Me.txtDate.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Enter Date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        ElseIf Me.txtDate.Text = Format(Now.Date, "dd/MM/yyyy") Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Current Date Not Allowed');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        ElseIf Me.cmb_type.SelectedIndex = -1 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select Any One');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        ElseIf Me.Ddltech.SelectedIndex = -1 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select Any One');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        ElseIf Me.txt_remarks.Value = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Enter Remarks');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        ElseIf Me.chk_mor.Checked = False And Me.chk_eve.Checked = False Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Check Any One');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        ElseIf (Me.file_support1.HasFile = False) Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Upload File ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        ElseIf (ext <> ".pdf") Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('File Format Is Not Supported');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        ElseIf (Me.file_support1.HasFile) Then
            If (Me.file_support1.PostedFile.ContentLength > 20728650) Then
                'If (Me.file_support1.PostedFile.ContentLength > 1048576) Then

                'If (Me.file_support1.PostedFile.ContentLength >= 50000) Then
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('File size exceeds maximum limit 2 MB.') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)

            Else

                dts = oh.ExecuteDataSet("select a.emp_code from ATTEND a where a.emp_code=" & Me.txtEcode.Text & " and to_date(a.curr_date)='" & Me.txtDate.Text & "'").Tables(0)
                If dts.Rows.Count = 1 Then

                    If Not Me.file_support1.HasFile Then
                        Label1.Text = "Please Select File"
                    ElseIf Me.file_support1.HasFile Then

                        Try

                            Select Case ext
                                Case ".pdf"
                                    type = "application/pdf"
                            End Select

                            If type <> String.Empty Then


                                Dim fs As Stream = Me.file_support1.PostedFile.InputStream
                                Dim br As BinaryReader = New BinaryReader(fs)
                                Dim bytes As Byte() = br.ReadBytes(CType(fs.Length, Int32))

                                Dim sql841 As String = "select count(*) from tbl_regularisation l where l.emp_code=" & Me.txtEcode.Text & " and to_char(l.apply_dt,'MM')=" & Format(CDate(Me.txtDate.Text), "MM") & ""
                                Dim sql84 As DataTable = oh.ExecuteDataSet(sql841).Tables(0)
                                If sql84.Rows(0)(0) <= 2 Then

                                    sql = "INSERT into tbl_regularisation(emp_code,apply_dt,emp_remarks,select_person,mreg,evngreg,enter_dt,reg_type,status) values(:code,:app_dt,:rem,:sel_code,:m1,:e1,:ent_dt,:regtype,:status)"
                                    Dim pr(8) As OracleParameter

                                    pr(0) = New OracleParameter
                                    pr(0).ParameterName = "code"
                                    pr(0).OracleType = OracleType.Number
                                    pr(0).Direction = ParameterDirection.Input
                                    pr(0).Value = Me.txtEcode.Text

                                    pr(1) = New OracleParameter
                                    pr(1).ParameterName = "app_dt"
                                    pr(1).OracleType = OracleType.DateTime
                                    pr(1).Direction = ParameterDirection.Input
                                    pr(1).Value = Me.txtDate.Text

                                    pr(2) = New OracleParameter
                                    pr(2).ParameterName = "rem"
                                    pr(2).OracleType = OracleType.VarChar
                                    pr(2).Direction = ParameterDirection.Input
                                    pr(2).Value = Me.txt_remarks.Value

                                    pr(3) = New OracleParameter
                                    pr(3).ParameterName = "sel_code"
                                    pr(3).OracleType = OracleType.Number
                                    pr(3).Direction = ParameterDirection.Input
                                    pr(3).Value = Me.Ddltech.SelectedValue



                                    pr(4) = New OracleParameter
                                    pr(4).ParameterName = "m1"
                                    pr(4).OracleType = OracleType.Number
                                    pr(4).Direction = ParameterDirection.Input
                                    If (Me.chk_mor.Checked = True) Then
                                        pr(4).Value = 1
                                    Else
                                        pr(4).Value = 0
                                    End If



                                    pr(5) = New OracleParameter
                                    pr(5).ParameterName = "e1"
                                    pr(5).OracleType = OracleType.Number
                                    pr(5).Direction = ParameterDirection.Input
                                    If (Me.chk_eve.Checked = True) Then
                                        pr(5).Value = 1
                                    Else
                                        pr(5).Value = 0
                                    End If


                                    pr(6) = New OracleParameter
                                    pr(6).ParameterName = "ent_dt"
                                    pr(6).OracleType = OracleType.DateTime
                                    pr(6).Direction = ParameterDirection.Input
                                    pr(6).Value = Format(Now.Date, "dd/MMM/yyyy")

                                    pr(7) = New OracleParameter
                                    pr(7).ParameterName = "regtype"
                                    pr(7).OracleType = OracleType.VarChar
                                    pr(7).Direction = ParameterDirection.Input
                                    pr(7).Value = Me.cmb_type.SelectedIndex

                                    pr(8) = New OracleParameter
                                    pr(8).ParameterName = "status"
                                    pr(8).OracleType = OracleType.Number
                                    pr(8).Direction = ParameterDirection.Input
                                    pr(8).Value = 0
                                    oh.ExecuteNonQuery(sql, pr)

                                    sql7 = "UPDATE tbl_regularisation h set h.data= :ph,h.name1=:name1 where h.apply_dt=:appdate1 and h.emp_code=:code"
                                    Dim prr(3) As OracleParameter

                                    prr(0) = New OracleParameter
                                    prr(0).ParameterName = "code"
                                    prr(0).OracleType = OracleType.Number
                                    prr(0).Direction = ParameterDirection.Input
                                    prr(0).Value = Me.txtEcode.Text

                                    prr(1) = New OracleParameter
                                    prr(1).ParameterName = "ph"
                                    prr(1).OracleType = OracleType.Blob
                                    prr(1).Direction = ParameterDirection.Input
                                    prr(1).Value = Me.file_support1.FileBytes

                                    prr(2) = New OracleParameter
                                    prr(2).ParameterName = "name1"
                                    prr(2).OracleType = OracleType.VarChar
                                    prr(2).Direction = ParameterDirection.Input
                                    prr(2).Value = Me.file_support1.FileName

                                    prr(3) = New OracleParameter
                                    prr(3).ParameterName = "appdate1"
                                    prr(3).OracleType = OracleType.DateTime
                                    prr(3).Direction = ParameterDirection.Input
                                    prr(3).Value = Me.txtDate.Text





                                    If oh.ExecuteNonQuery(sql7, prr) Then


                                        Dim cl_scrip1 As New StringBuilder
                                        cl_scrip1.Append("   alert('Request Successfully Submitted') ;")
                                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
                                        'Response.Redirect("../home.aspx")
                                        'clr()
                                        'Exit Sub
                                    End If
                                    Me.txt_remarks.Value = ""
                                    Me.txtBranch.Text = ""
                                    Me.txtDate.Text = ""
                                    Me.TxtDep.Text = ""
                                    Me.txtDes.Text = ""
                                    Me.txtEcode.Text = ""
                                    Me.txtEname.Text = ""
                                    Me.txtPost.Text = ""
                                    Me.Ddltech.SelectedIndex = -1
                                    Me.cmb_type.SelectedIndex = -1
                                    Me.chk_eve.Checked = False
                                    Me.chk_mor.Checked = False
                                    Me.lbl_error.Text = ""
                                Else
                                    Dim cl_scrip1 As New StringBuilder
                                    cl_scrip1.Append("   alert('Only 2 Request is allowed') ;")
                                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
                                    'clr()

                                End If

                            Else

                                'Response.Write(ex.Message.ToString)
                                Dim cl_scrip1 As New StringBuilder
                                cl_scrip1.Append("   alert('Please upload correct Document!!!') ;")
                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
                            End If

                        Catch ex As Exception
                            'Response.Write(ex.Message.ToString)
                            Dim cl_scrip1 As New StringBuilder
                            cl_scrip1.Append("   alert('Please Try Later!!!') ;")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
                        End Try

                    Else
                        Dim cl_scrip1 As New StringBuilder
                        'cl_scrip1.Append("   alert('" & txtename.Text & ", YOUR PHOTO ALREADY  Attached !!!') ;")
                        cl_scrip1.Append("   alert('Please Try Later!!') ;")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
                        'clr()


                    End If

                End If

            End If


        End If


    End Sub



    Protected Sub txtDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        Dim usr() = Session("user_id").ToString.Split("!")
        Dim sty As String = "select a.m_time,a.e_time from attend a where a.emp_code=" & usr(0) & " and to_date(a.curr_date)='" & txtDate.Text & "'"
        dta = oh.ExecuteDataSet(sty).Tables(0)
        If dta.Rows.Count > 0 Then
            Me.lbl_error.Text = "         Moring Punch Time is :" & dta.Rows(0)(0) & " and Evening time is :" & dta.Rows(0)(1) & ""
        Else
            Me.lbl_error.Text = "           You are not punched at " & txtDate.Text & ""
        End If
    End Sub
End Class

