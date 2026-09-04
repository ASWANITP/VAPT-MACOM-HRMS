Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Partial Class new_resignation_enter_a858a39d2739
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim reason, reason1 As String
    Dim sql, fnm As String
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Me.Panel1.Visible = True Then

            If Me.cmb_reason.SelectedValue = 1 Then

                If Me.Txt_coll.Text = "" Or Me.Txt_cou.Text = "" Or Me.Txt_du.Text = "" Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Please fill all Reason details!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Exit Sub
                Else
                    reason = Me.cmb_reason.SelectedValue.ToString + "*" + Me.Txt_coll.Text.ToString + "*" + Me.Txt_cou.Text.ToString + "*" + Me.Txt_du.Text.ToString
                End If

            End If

            If Me.cmb_reason.SelectedValue = 2 Then
                reason = Me.cmb_reason.SelectedValue.ToString + "*" + Me.cmb_pr.SelectedItem.ToString + "*" + Me.cmb_pr.SelectedValue.ToString
            End If
            If Me.cmb_reason.SelectedValue = 3 Then
                If Me.Txt_fir.Text = "" Or Me.Txt_nw.Text = "" Or Me.Txt_rea.Text = "" Or Me.Txt_sal.Text = "" Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Please fill all Reason details!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Exit Sub
                Else
                    reason = Me.cmb_reason.SelectedValue.ToString + "*" + Me.Txt_fir.Text.ToString + "*" + Me.Txt_rea.Text.ToString + "*" + Me.Txt_nw.Text.ToString + "*" + Me.Txt_sal.Text.ToString
                End If

            End If
            If Me.cmb_reason.SelectedValue = 4 Then

                If Me.Txt_jp.Text = "" Or Me.Txt_np.Text = "" Or Me.Txt_pm.Text = "" Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Please fill all Reason details!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Exit Sub
                Else
                    reason = Me.cmb_reason.SelectedValue.ToString + "*" + Me.Txt_pm.Text.ToString + "*" + Me.Txt_np.Text.ToString + "*" + Me.Txt_jp.Text.ToString
                End If
            End If
            If Me.cmb_reason.SelectedValue = 5 Then
                If Me.Txt_or.Text = "" Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Please fill all Reason details!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Exit Sub
                Else
                    reason = Me.cmb_reason.SelectedValue.ToString + "*" + Me.Txt_or.Text.ToString
                End If
            End If

            If Me.Txt_rsdt.Text = "" Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('Please enter Resignation date!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Txt_rsdt.Focus()
                Exit Sub
            End If


            If CDate(Me.Txt_rsdt.Text) >= Format(Date.Today, "dd/MMM/yyyy") Then


                If Me.FileUpload1.HasFile Then
                    Dim fileExtension As String
                    fileExtension = System.IO.Path. _
                        GetExtension(Me.FileUpload1.FileName).ToLower()
                    Dim allowedExtensions As String() = _
                        {".jpg", ".jpeg", ".png", ".bmp"}
                    Dim fileok As Boolean
                    fileok = False
                    For i As Integer = 0 To allowedExtensions.Length - 1
                        If fileExtension = allowedExtensions(i) Then
                            fileok = True
                        End If
                    Next
                    If Not (fileok) Then
                        Dim cl_script As New StringBuilder
                        cl_script.Append("   alert('First Attachement Type Not Supported!!') ;")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                        Exit Sub
                    End If

                End If

                Dim DirPath As String
                DirPath = Me.Server.MapPath("../../image")
                'DirPath = Me.Server.MapPath("image")

                Dim usr() As String
                usr = Me.Session("user_id").ToString.Split("!")
                Dim dt1 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & usr(0) & " and status_id=1 ").Tables(0)
                Dim parameter(4) As OracleParameter
                parameter(0) = New OracleParameter("code", OracleType.Number, 150)
                parameter(0).Direction = ParameterDirection.Input
                parameter(0).Value = usr(0)
                parameter(1) = New OracleParameter("rdt", OracleType.DateTime, 150)
                parameter(1).Direction = ParameterDirection.Input
                parameter(1).Value = Me.Txt_rsdt.Text
                parameter(2) = New OracleParameter("rea", OracleType.VarChar, 150)
                parameter(2).Direction = ParameterDirection.Input
                parameter(2).Value = reason
                parameter(3) = New OracleParameter("ebr", OracleType.Number, 150)
                parameter(3).Direction = ParameterDirection.Input
                parameter(3).Value = dt1.Rows(0)(0)
                parameter(4) = New OracleParameter("msg", OracleType.Number, 150)
                parameter(4).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("m_resigning_appl", parameter)


                If parameter(4).Value = 1 Then
                    If Me.FileUpload1.FileName <> "" Then


                        fnm = GetUniqueFilename(DirPath + "support1.jpg")
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
                        sql = "update macdms.m_resign_appl_image set attach=:ph where emp_code=:empid and status=0"
                        Dim parm_coll(1) As OracleParameter
                        parm_coll(0) = New OracleParameter
                        parm_coll(0).ParameterName = "ph"
                        parm_coll(0).OracleType = OracleType.Blob
                        parm_coll(0).Direction = ParameterDirection.Input
                        parm_coll(0).Value = bl
                        parm_coll(1) = New OracleParameter
                        parm_coll(1).ParameterName = "empid"
                        parm_coll(1).OracleType = OracleType.Number
                        parm_coll(1).Direction = ParameterDirection.Input
                        parm_coll(1).Value = usr(0)

                        oh.ExecuteNonQuery(sql, parm_coll)
                    End If

                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Applied successfully!!');")
                    cl_script1.Append("       window.open('resignation_enter.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                End If
                If parameter(4).Value = 2 Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Already an application is waiting for Approval!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                End If
                If parameter(4).Value = 3 Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Error ...Contact IT Department...!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                End If
                If parameter(4).Value = 4 Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('please enter resigning date!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                End If
            Else

                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('Resign date must be greater than Today...!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

            End If
        End If

        If Me.Panel2.Visible = True Then

            If Me.cmb_reason2.SelectedValue = 1 Then

                If Me.Txt_coll1.Text = "" Or Me.Txt_cou1.Text = "" Or Me.Txt_dur1.Text = "" Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Please fill all Reason details!!');")

                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Exit Sub
                Else
                    reason1 = Me.cmb_reason2.SelectedValue.ToString + "*" + Me.Txt_coll1.Text.ToString + "*" + Me.Txt_cou1.Text.ToString + "*" + Me.Txt_dur1.Text.ToString
                End If

            End If

            If Me.cmb_reason2.SelectedValue = 2 Then
                reason1 = Me.cmb_reason2.SelectedValue.ToString + "*" + Me.cmb_pr1.SelectedItem.ToString + "*" + Me.cmb_pr1.SelectedValue.ToString
            End If
            If Me.cmb_reason2.SelectedValue = 3 Then
                If Me.Txt_firm1.Text = "" Or Me.Txt_naw1.Text = "" Or Me.Txt_rea1.Text = "" Or Me.Txt_sal1.Text = "" Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Please fill all Reason details!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Exit Sub
                Else
                    reason1 = Me.cmb_reason2.SelectedValue.ToString + "*" + Me.Txt_firm1.Text.ToString + "*" + Me.Txt_rea1.Text.ToString + "*" + Me.Txt_naw1.Text.ToString + "*" + Me.Txt_sal1.Text.ToString
                End If

            End If
            If Me.cmb_reason2.SelectedValue = 4 Then

                If Me.Txt_jp1.Text = "" Or Me.Txt_np1.Text = "" Or Me.Txt_pm1.Text = "" Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Please fill all Reason details!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Exit Sub
                Else
                    reason1 = Me.cmb_reason2.SelectedValue.ToString + "*" + Me.Txt_pm1.Text.ToString + "*" + Me.Txt_np1.Text.ToString + "*" + Me.Txt_jp1.Text.ToString
                End If
            End If
            If Me.cmb_reason2.SelectedValue = 5 Then
                If Me.Txt_or1.Text = "" Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Please fill all Reason details!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Exit Sub
                Else
                    reason1 = Me.cmb_reason2.SelectedValue.ToString + "*" + Me.Txt_or1.Text.ToString
                End If
            End If

            If Me.Txt_rsdt1.Text = "" Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('Please enter Resignation date!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Txt_rsdt.Focus()
                Exit Sub
            End If


            If CDate(Me.Txt_rsdt1.Text) >= Format(Date.Today, "dd/MMM/yyyy") And CDate(Me.Txt_reldt.Text) >= Format(Date.Today, "dd/MMM/yyyy") Then

                If Me.FileUpload1.HasFile Then
                    Dim fileExtension As String
                    fileExtension = System.IO.Path. _
                        GetExtension(Me.FileUpload1.FileName).ToLower()
                    Dim allowedExtensions As String() = _
                        {".jpg", ".jpeg", ".png", ".bmp"}
                    Dim fileok As Boolean
                    fileok = False
                    For i As Integer = 0 To allowedExtensions.Length - 1
                        If fileExtension = allowedExtensions(i) Then
                            fileok = True
                        End If
                    Next
                    If Not (fileok) Then
                        Dim cl_script As New StringBuilder
                        cl_script.Append("   alert('First Attachement Type Not Supported!!') ;")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                        Exit Sub
                    End If

                End If

                Dim DirPath As String
                DirPath = Me.Server.MapPath("../../image")



                Dim usr() As String
                usr = Me.Session("user_id").ToString.Split("!")
                Dim dt1 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & usr(0) & " and status_id=1 ").Tables(0)
                Dim parameter(6) As OracleParameter
                parameter(0) = New OracleParameter("code", OracleType.Number, 150)
                parameter(0).Direction = ParameterDirection.Input
                parameter(0).Value = Me.cmb_employee.SelectedValue
                parameter(1) = New OracleParameter("rdt", OracleType.DateTime, 150)
                parameter(1).Direction = ParameterDirection.Input
                parameter(1).Value = Me.Txt_rsdt1.Text
                parameter(2) = New OracleParameter("rea", OracleType.VarChar, 150)
                parameter(2).Direction = ParameterDirection.Input
                parameter(2).Value = reason1
                parameter(3) = New OracleParameter("ebr", OracleType.Number, 150)
                parameter(3).Direction = ParameterDirection.Input
                parameter(3).Value = dt1.Rows(0)(0)
                parameter(4) = New OracleParameter("reldt", OracleType.DateTime, 150)
                parameter(4).Direction = ParameterDirection.Input
                parameter(4).Value = Me.Txt_reldt.Text
                parameter(5) = New OracleParameter("usr", OracleType.Number, 150)
                parameter(5).Direction = ParameterDirection.Input
                parameter(5).Value = usr(0)
                parameter(6) = New OracleParameter("msg", OracleType.Number, 150)
                parameter(6).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("m_resigning_appl_bh", parameter)
                If parameter(6).Value = 1 Then
                    If Me.FileUpload1.FileName <> "" Then


                        fnm = GetUniqueFilename(DirPath + "support1.jpg")
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

                        'sql = "update m_resign_appl set attach=:ph where emp_code=:empid and status=1"
                        sql = "update macdms.m_resign_appl_image set attach=:ph where emp_code=:empid and status=1"
                        Dim parm_coll(1) As OracleParameter
                        parm_coll(0) = New OracleParameter
                        parm_coll(0).ParameterName = "ph"
                        parm_coll(0).OracleType = OracleType.Blob
                        parm_coll(0).Direction = ParameterDirection.Input
                        parm_coll(0).Value = bl
                        parm_coll(1) = New OracleParameter
                        parm_coll(1).ParameterName = "empid"
                        parm_coll(1).OracleType = OracleType.Number
                        parm_coll(1).Direction = ParameterDirection.Input
                        parm_coll(1).Value = Me.cmb_employee.SelectedValue
                        oh.ExecuteNonQuery(sql, parm_coll)
                    End If

                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Applied successfully!!');")
                    cl_script1.Append("       window.open('resignation_enter.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                End If
                If parameter(6).Value = 2 Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Already an application is waiting for Approval!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                End If
                If parameter(6).Value = 4 Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('please enter resigning date!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                End If
                If parameter(6).Value = 3 Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Error ...Contact IT Department...!!');")
                    cl_script1.Append("window.open('resignation_enter.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                End If
            Else

                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('Resign & Relieve date must be greater than Today  !!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

            End If

        End If

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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim frm As Integer = Session("firm_id")
        If frm = 8 Then
            Response.Redirect("~/payroll/macom_resign/resignation_enter.aspx")
            Exit Sub
        End If
        If frm = 16 Or frm = 33 Then
            Response.Redirect("~/payroll/macare_resign/resignation_enter_new.aspx")
            Exit Sub
        End If
        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_rea.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)


        If Not IsPostBack Then

            Dim usr() As String
            usr = Me.Session("user_id").ToString.Split("!")
            Me.TextBox1.Text = Format(Now.Date, "dd/MMM/yyyy")
            Me.TextBox2.Text = Format(Now.Date, "dd/MMM/yyyy")

            'Commented. Request ID - 17120 
            'Me.Txt_rsdt.Text = Format(Now.Date, "dd/MMM/yyyy")
            Me.Txt_reldt.Text = Format(Now.Date, "dd/MMM/yyyy")
            Dim dt1 As DataTable = oh.ExecuteDataSet("select emp_code,branch_id from employee_master where emp_code=" & usr(0) & " and status_id=1 and post_id in (10,198,14,1,4) ").Tables(0)

            If dt1.Rows.Count > 0 Then
                Me.hs1.Visible = False
                Me.hs2.Visible = True
                Me.pr1.Visible = False
                Me.pr2.Visible = False
                Me.oe1.Visible = False
                Me.mr1.Visible = False
                Me.oe2.Visible = False
                Me.orr.Visible = False
                Me.or1.Visible = False
                Me.mr2.Visible = False
                Me.Panel1.Visible = False
                Me.Panel2.Visible = True
                Dim Sql33 As String = "select categ,categ_id from resign_reason_mst order by categ"
                Dim dt33 As DataTable = oh.ExecuteDataSet(Sql33).Tables(0)
                Me.cmb_reason2.DataSource = dt33
                Me.cmb_reason2.DataTextField = dt33.Columns(0).ColumnName
                Me.cmb_reason2.DataValueField = dt33.Columns(1).ColumnName
                Me.cmb_reason2.DataBind()

                Dim Sql As String = "select e.emp_code||' --- '||e.emp_name||'  ---  Branch: '||b.branch_name,e.emp_code from employee_master e,branch b where  e.branch_id=b.branch_id and e.branch_id=" & dt1.Rows(0)(1) & " and  e.status_id=1 and emp_code>9999 order by emp_code"
                Dim dt3 As DataTable = oh.ExecuteDataSet(Sql).Tables(0)
                Me.cmb_employee.DataSource = dt3
                Me.cmb_employee.DataTextField = dt3.Columns(0).ColumnName
                Me.cmb_employee.DataValueField = dt3.Columns(1).ColumnName
                Me.cmb_employee.DataBind()
                Dim dt As DataTable = oh.ExecuteDataSet("select emp_code,emp_name from employee_master where emp_code=" & Me.cmb_employee.SelectedValue & " and status_id=1 and emp_code>9999 ").Tables(0)
                Me.lbl_code1.Text = dt.Rows(0)(0)
                Me.lbl_name1.Text = dt.Rows(0)(1)

            Else
                Dim dt3 As DataTable = oh.ExecuteDataSet("select t.department_id from department_major t where t.head_id like '%" & usr(0) & "%'").Tables(0)

                If dt3.Rows.Count > 0 Then

                    Me.hs1.Visible = False
                    Me.hs2.Visible = True
                    Me.pr1.Visible = False
                    Me.pr2.Visible = False
                    Me.oe1.Visible = False
                    Me.mr1.Visible = False
                    Me.oe2.Visible = False
                    Me.mr2.Visible = False
                    Me.Panel1.Visible = False
                    Me.Panel2.Visible = True
                    Me.orr.Visible = False
                    Me.or1.Visible = False
                    Dim Sql33 As String = "select categ,categ_id from resign_reason_mst order by categ"
                    Dim dt33 As DataTable = oh.ExecuteDataSet(Sql33).Tables(0)
                    Me.cmb_reason2.DataSource = dt33
                    Me.cmb_reason2.DataTextField = dt33.Columns(0).ColumnName
                    Me.cmb_reason2.DataValueField = dt33.Columns(1).ColumnName
                    Me.cmb_reason2.DataBind()
                    Dim Sql As String = "select e.emp_code||' --- '||e.emp_name||'  ---  Branch: '||b.branch_name,e.emp_code from employee_master e,branch b where  e.branch_id=b.branch_id and  e.status_id=1 and emp_code>9999 and e.department_id in ( select dep_id from department_mst where major_dep_id in (select t.department_id from department_major t where t.head_id like '%" & usr(0) & "%')) order by emp_code"
                    Dim dt4 As DataTable = oh.ExecuteDataSet(Sql).Tables(0)
                    Me.cmb_employee.DataSource = dt4
                    Me.cmb_employee.DataTextField = dt4.Columns(0).ColumnName
                    Me.cmb_employee.DataValueField = dt4.Columns(1).ColumnName
                    Me.cmb_employee.DataBind()
                    Dim dt5 As DataTable = oh.ExecuteDataSet("select emp_code,emp_name from employee_master where emp_code=" & Me.cmb_employee.SelectedValue & " and status_id=1 and emp_code>9999 ").Tables(0)
                    Me.lbl_code1.Text = dt5.Rows(0)(0)
                    Me.lbl_name1.Text = dt5.Rows(0)(1)


                    '''''''''''''''''''''''''''''''''''
                Else

                    Dim Sql33 As String = "select categ,categ_id from resign_reason_mst order by categ"
                    Dim dt33 As DataTable = oh.ExecuteDataSet(Sql33).Tables(0)
                    Me.cmb_reason.DataSource = dt33
                    Me.cmb_reason.DataTextField = dt33.Columns(0).ColumnName
                    Me.cmb_reason.DataValueField = dt33.Columns(1).ColumnName
                    Me.cmb_reason.DataBind()
                    Me.Panel1.Visible = True
                    Me.Panel2.Visible = False
                    Me.hs1.Visible = True
                    Me.hs2.Visible = False
                    Me.pr1.Visible = False
                    Me.pr2.Visible = False
                    Me.oe1.Visible = False
                    Me.mr1.Visible = False
                    Me.oe2.Visible = False
                    Me.mr2.Visible = False
                    Me.orr.Visible = False
                    Me.or1.Visible = False
                    Dim dt2 As DataTable = oh.ExecuteDataSet("select emp_code,emp_name from employee_master where emp_code=" & usr(0) & " and status_id=1").Tables(0)


                    If dt2.Rows.Count > 0 Then
                        Me.lbl_code.Text = dt2.Rows(0)(0)
                        Me.lbl_name.Text = dt2.Rows(0)(1)
                    Else
                        Server.Transfer("../../show_err.aspx")
                    End If
                End If

            End If

            Dim usrs() As String
            usrs = Me.Session("user_id").ToString.Split("!")
            If Session("firm_id") = 2 Then
                Dim dats As DataTable = oh.ExecuteDataSet("select count(t.emp_code) from hrm_notice_period_accept t where t.emp_code=" & usrs(0) & "").Tables(0)
                If dats.Rows(0)(0) > 0 Then
                    Dim dat1 As DataTable = oh.ExecuteDataSet("select to_char(to_date(sysdate+t.notice_days),'DD-MON-YYYY') from hrm_notice_period_accept t where t.emp_code=" & usrs(0) & "").Tables(0)
                    Me.Txt_rsdt.Text = dat1.Rows(0)(0)
                    Me.Txt_rsdt.Enabled = False
                Else
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Please confirm your notice period acceptance!!');")
                    cl_script1.Append("        window.open('./maben/Notice_Period_Acceptance_indi.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Exit Sub
                End If
            End If

            '----sh
            'If Session("firm_id") = 2 Then
            '    Dim dah As DataTable = oh.ExecuteDataSet("select count(t.emp_code) from TBL_HIGHER_EDN_DTLS t where   t.emp_code=" & usrs(0) & "").Tables(0)
            '    If dah.Rows(0)(0) = 0 Then

            '        '    Dim cl_script1 As New System.Text.StringBuilder
            '        '    cl_script1.Append("        alert('Please confirm your COURSE PENALITY!!');")
            '        '    cl_script1.Append("        window.open('./maben/Course_Penality_Alert.aspx','_self');")
            '        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            '        'Else
            '        Dim cl_script1 As New System.Text.StringBuilder
            '        'cl_script1.Append("        alert('Please confirm your COURSE PENALITY!!');")
            '        cl_script1.Append("        window.open('resignation_enter.aspx','_self');")
            '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

            '    End If





            Dim dat As DataTable = oh.ExecuteDataSet("select count(t.emp_code) from TBL_HIGHER_EDN_DTLS t where t.status=1 and t.agree_penality is null and  t.emp_code=" & usrs(0) & "").Tables(0)
            If dat.Rows(0)(0) > 0 Then

                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('Please confirm your COURSE PENALTY!!');")
                cl_script1.Append("        window.open('./maben/Course_Penality_Alert.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                'Else
                '    Dim cl_script1 As New System.Text.StringBuilder
                '    'cl_script1.Append("        alert('Please confirm your COURSE PENALITY!!');")
                '    cl_script1.Append("        window.open('../resignation_enter.aspx','_self');")
                '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

            End If
            Exit Sub

        End If
        '----sh

        ' End If
    End Sub

    Protected Sub cmb_employee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_employee.SelectedIndexChanged

        Dim dt As DataTable = oh.ExecuteDataSet("select emp_code,emp_name from employee_master where emp_code=" & Me.cmb_employee.SelectedValue & " and status_id=1 and emp_code>9999 ").Tables(0)
        Me.lbl_code1.Text = dt.Rows(0)(0)
        Me.lbl_name1.Text = dt.Rows(0)(1)

    End Sub

    Protected Sub cmb_reason_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_reason.SelectedIndexChanged
        If Me.cmb_reason.SelectedValue = 1 Then
            Me.hs1.Visible = True
            Me.hs2.Visible = False
            Me.pr1.Visible = False
            Me.pr2.Visible = False
            Me.oe1.Visible = False
            Me.mr1.Visible = False
            Me.oe2.Visible = False
            Me.mr2.Visible = False
            Me.orr.Visible = False
            Me.or1.Visible = False
        End If
        If Me.cmb_reason.SelectedValue = 2 Then
            Me.hs1.Visible = False
            Me.hs2.Visible = False
            Me.pr1.Visible = True
            Me.pr2.Visible = False
            Me.oe1.Visible = False
            Me.mr1.Visible = False
            Me.oe2.Visible = False
            Me.mr2.Visible = False
            Me.orr.Visible = False
            Me.or1.Visible = False
            Dim dt44 As DataTable = oh.ExecuteDataSet("select t.reason, t.reason_id from resign_personal_res t order by t.reason_id").Tables(0)
            Me.cmb_pr.DataSource = dt44
            Me.cmb_pr.DataTextField = dt44.Columns(0).ColumnName
            Me.cmb_pr.DataValueField = dt44.Columns(1).ColumnName
            Me.cmb_pr.DataBind()

        End If
        If Me.cmb_reason.SelectedValue = 3 Then
            Me.hs1.Visible = False
            Me.hs2.Visible = False
            Me.pr1.Visible = False
            Me.pr2.Visible = False
            Me.oe1.Visible = True
            Me.mr1.Visible = False
            Me.oe2.Visible = False
            Me.mr2.Visible = False
            Me.orr.Visible = False
            Me.or1.Visible = False
        End If
        If Me.cmb_reason.SelectedValue = 4 Then
            Me.hs1.Visible = False
            Me.hs2.Visible = False
            Me.pr1.Visible = False
            Me.pr2.Visible = False
            Me.oe1.Visible = False
            Me.mr1.Visible = True
            Me.oe2.Visible = False
            Me.mr2.Visible = False
            Me.orr.Visible = False
            Me.or1.Visible = False
        End If
        If Me.cmb_reason.SelectedValue = 5 Then
            Me.hs1.Visible = False
            Me.hs2.Visible = False
            Me.pr1.Visible = False
            Me.pr2.Visible = False
            Me.oe1.Visible = False
            Me.mr1.Visible = False
            Me.oe2.Visible = False
            Me.mr2.Visible = False
            Me.orr.Visible = True
            Me.or1.Visible = False
        End If
    End Sub

    Protected Sub cmb_reason2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_reason2.SelectedIndexChanged
        If Me.cmb_reason2.SelectedValue = 1 Then
            Me.hs1.Visible = False
            Me.hs2.Visible = True
            Me.pr1.Visible = False
            Me.pr2.Visible = False
            Me.oe1.Visible = False
            Me.mr1.Visible = False
            Me.oe2.Visible = False
            Me.mr2.Visible = False
            Me.orr.Visible = False
            Me.or1.Visible = False
        End If
        If Me.cmb_reason2.SelectedValue = 2 Then
            Me.hs1.Visible = False
            Me.hs2.Visible = False
            Me.pr1.Visible = False
            Me.pr2.Visible = True
            Me.oe1.Visible = False
            Me.mr1.Visible = False
            Me.oe2.Visible = False
            Me.mr2.Visible = False
            Me.orr.Visible = False
            Me.or1.Visible = False
            Dim dt44 As DataTable = oh.ExecuteDataSet("select t.reason, t.reason_id from resign_personal_res t order by t.reason_id").Tables(0)
            Me.cmb_pr1.DataSource = dt44
            Me.cmb_pr1.DataTextField = dt44.Columns(0).ColumnName
            Me.cmb_pr1.DataValueField = dt44.Columns(1).ColumnName
            Me.cmb_pr1.DataBind()
        End If
        If Me.cmb_reason2.SelectedValue = 3 Then
            Me.hs1.Visible = False
            Me.hs2.Visible = False
            Me.pr1.Visible = False
            Me.pr2.Visible = False
            Me.oe1.Visible = False
            Me.mr1.Visible = False
            Me.oe2.Visible = True
            Me.mr2.Visible = False
            Me.orr.Visible = False
            Me.or1.Visible = False
        End If
        If Me.cmb_reason2.SelectedValue = 4 Then

            Me.hs1.Visible = False
            Me.hs2.Visible = False
            Me.pr1.Visible = False
            Me.pr2.Visible = False
            Me.oe1.Visible = False
            Me.mr1.Visible = False
            Me.oe2.Visible = False
            Me.mr2.Visible = True
            Me.orr.Visible = False
            Me.or1.Visible = False
        End If
        If Me.cmb_reason2.SelectedValue = 5 Then

            Me.hs1.Visible = False
            Me.hs2.Visible = False
            Me.pr1.Visible = False
            Me.pr2.Visible = False
            Me.oe1.Visible = False
            Me.mr1.Visible = False
            Me.oe2.Visible = False
            Me.mr2.Visible = False
            Me.orr.Visible = False
            Me.or1.Visible = True
        End If
    End Sub
End Class
