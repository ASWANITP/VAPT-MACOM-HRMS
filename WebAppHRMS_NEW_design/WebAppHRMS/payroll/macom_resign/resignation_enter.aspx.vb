Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Partial Class new_resignation_enter_76bbc5f21103
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim reason, reason1 As String
    Dim sql, fnm, alls() As String
    Dim sf() As String
    Dim dt, dt1, dt2, dt3, dt4, dt5 As New DataTable




    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.Panel1.Visible = True Then

            If Me.cmb_reason.SelectedValue = 1 Then

                If Me.Txt_coll.Text = "" Or Me.Txt_cou.Text = "" Or Me.Txt_du.Text = "" Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Please fill all Reason details!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Exit Sub
                Else
                    reason = Me.cmb_reason.SelectedValue.ToString + "*" + Me.Txt_coll.Text.ToString + "*" + Me.Txt_cou.Text.ToString + "*" + Me.Txt_du.Text.ToString + "*" + Me.DropDownList2.SelectedValue
                End If

            End If

            If Me.cmb_reason.SelectedValue = 2 Then
                reason = Me.cmb_reason.SelectedValue.ToString + "*" + Me.cmb_pr.SelectedItem.ToString + "*" + Me.cmb_pr.SelectedValue.ToString + "*" + Me.DropDownList2.SelectedValue
            End If
            If Me.cmb_reason.SelectedValue = 3 Then
                If Me.Txt_fir.Text = "" Or Me.Txt_nw.Text = "" Or Me.Txt_rea.Text = "" Or Me.Txt_sal.Text = "" Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Please fill all Reason details!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Exit Sub
                Else
                    reason = Me.cmb_reason.SelectedValue.ToString + "*" + Me.Txt_fir.Text.ToString + "*" + Me.Txt_rea.Text.ToString + "*" + Me.Txt_nw.Text.ToString + "*" + Me.Txt_sal.Text.ToString + "*" + Me.DropDownList2.SelectedValue
                End If

            End If
            If Me.cmb_reason.SelectedValue = 4 Then

                If Me.Txt_jp.Text = "" Or Me.Txt_np.Text = "" Or Me.Txt_pm.Text = "" Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Please fill all Reason details!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Exit Sub
                Else

                    reason = Me.cmb_reason.SelectedValue.ToString + "*" + Me.Txt_pm.Text.ToString + "*" + Me.Txt_np.Text.ToString + "*" + Me.Txt_jp.Text.ToString + "*" + Me.DropDownList2.SelectedValue
                End If
            End If
            If Me.cmb_reason.SelectedValue = 5 Then
                If Me.Txt_or.Text = "" Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("        alert('Please fill all Reason details!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Exit Sub
                Else
                    reason = Me.cmb_reason.SelectedValue.ToString + "*" + Me.Txt_or.Text.ToString + "*" + Me.DropDownList2.SelectedValue
                End If
            End If

            'If Me.DropDownList2.SelectedValue = -1 Then
            '    Dim cl_script1 As New System.Text.StringBuilder
            '    cl_script1.Append("        alert('Please select tech lead!!');")
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            '    DropDownList2.Focus()
            '    Exit Sub
            'End If


            If Me.FileUpload1.HasFile = False Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('please attach the file!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                FileUpload1.Focus()
                Exit Sub
            End If



            'If Me.Txt_rsdt.Text = "" Then
            '    Dim cl_script1 As New System.Text.StringBuilder
            '    cl_script1.Append("        alert('Please enter Resignation date!!');")
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            '    Txt_rsdt.Focus()
            '    Exit Sub
            'End If

        End If
        If CDate(Me.Txt_rsdt.Value) >= Format(Date.Today, "dd/MMM/yyyy") Then


            If Me.FileUpload1.HasFile Then
                Dim fileExtension As String
                fileExtension = System.IO.Path.
                    GetExtension(Me.FileUpload1.FileName).ToLower()
                Dim allowedExtensions As String() =
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
                    cl_script.Append("   alert('File Extension Not Supported!!') ;")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                    Exit Sub
                End If

            End If

            Dim DirPath As String
            DirPath = Me.Server.MapPath("../image")
            'DirPath = Me.Server.MapPath("image")

            Dim usr() As String
            usr = Me.Session("user_id").ToString.Split("!")
            Dim dt1 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & usr(0) & " and status_id=1 ").Tables(0)
            Dim parameter(5) As OracleParameter
            parameter(0) = New OracleParameter("code", OracleType.Number, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = usr(0)
            parameter(1) = New OracleParameter("edate", OracleType.DateTime, 150)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = CDate(TextBox1.Text)
            parameter(2) = New OracleParameter("rdt", OracleType.DateTime, 150)
            parameter(2).Direction = ParameterDirection.Input
            parameter(2).Value = CDate(Me.Txt_rsdt.Value)
            parameter(3) = New OracleParameter("rea", OracleType.VarChar, 150)
            parameter(3).Direction = ParameterDirection.Input
            parameter(3).Value = reason
            parameter(4) = New OracleParameter("ebr", OracleType.Number, 150)
            parameter(4).Direction = ParameterDirection.Input
            parameter(4).Value = dt1.Rows(0)(0)
            parameter(5) = New OracleParameter("msg", OracleType.Number, 150)
            parameter(5).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("m_resigning_appl_com", parameter)

            'Dim script1 As New System.Text.StringBuilder
            'script1.Append("         window.open('resignation_enter.aspx','_self');")

            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

            If parameter(5).Value = 1 Then
                Dim mycode() As String
                mycode = usr

                Dim server As SmtpClient = New SmtpClient("smtp.office365.com")
                server.Port = 587
                server.EnableSsl = True
                server.UseDefaultCredentials = False
                server.DeliveryMethod = SmtpDeliveryMethod.Network
                server.Credentials = New Net.NetworkCredential("no-reply@macomsolutions.com", "vltyzwqhzzkzrcgc")
                server.Timeout = 60000
                Dim mail As MailMessage = New MailMessage()
                mail.From = New MailAddress("no-reply@macomsolutions.com", "MACOM-HR")
                Dim qur As Integer = 450
                If qur = 450 Then
                    mail.Subject = "Resignation Submitted by [Employee Name] – Action Required"
                Else
                    mail.Subject = "Default Subject"
                End If
                mail.IsBodyHtml = True
                Dim BDY As String = oh.ExecuteDataSet("select t.query from HRM_REPORT_MASTER t where t.query_id=450").Tables(0).Rows(0)(0)
                'Dim replace As DataTable = oh.ExecuteDataSet("select e.emp_code, e.emp_name, em.office_mailid from mactech.employee_master e join mactech.hrm_emp_additional_dtl em on e.emp_code = em.emp_code and e.firm_id = em.firm_id join m_resign_appl_temp w on e.emp_code = w.emp_code where e.emp_code = '" & emp(0) & "'").Tables(0)
                Dim replace As DataTable = oh.ExecuteDataSet("select distinct decode(ap.sex, 1, 'Mr. ', 0, 'Ms. ') || upper(e.emp_name) name, d1.designation, (select d.dep_name from mactech.employ_transfer_dtl a, mactech.employee_master b, mactech.DEPARTMENT_MST d where a.to_dt is null and a.from_dt in (select max(from_dt) from mactech.employ_transfer_dtl where status_id in (8) and emp_code = " & usr(0) & ") and a.emp_code = b.emp_code and a.department_id = d.dep_id and a.status_id in (8) and a.emp_code = " & usr(0) & ") as proposed_dep, (select max(rt.enter_dt) from m_resign_appl_temp rt where rt.emp_code = " & usr(0) & ") as enter_dt, e.emp_code as emp_code, (select max(rt.resign_dt) from m_resign_appl_temp rt where rt.emp_code = " & usr(0) & ") as resig_dt, (select decode(t.reason, 1, 'Higher Studies', 2, 'Personal Reason', 3, 'Other Employment', 4, 'Marriage', 5, 'Other Reason') from m_resign_appl_temp t where t.emp_code = " & usr(0) & ") as resig_reas from mactech.employee_master e, mactech.employee_master ae, mactech.employ_personal_dtl ap, mactech.designation_master d1, mactech.designation_master ds, mactech.department_mst d, mactech.employ_transfer_dtl tr, mactech.department_mst td where e.emp_code = " & usr(0) & " and e.emp_code = ap.emp_code and ds.designation_id = d1.designation_id and e.designation_id = ds.designation_id and e.department_id = d.dep_id and tr.emp_code = e.emp_code and tr.status_id = 8 and tr.department_id = td.dep_id and ae.firm_id = 8").Tables(0)
                ' Dim replace As DataTable = oh.ExecuteDataSet("select distinct decode(ap.sex, 1, 'Mr. ', 0, 'Ms. ') || upper(e.emp_name) name, d1.designation, (select d.dep_name from mactech.employ_transfer_dtl a, mactech.employee_master b, mactech.DEPARTMENT_MST d where a.to_dt is null and a.from_dt in (select max(from_dt) from mactech.employ_transfer_dtl where status_id in (8) and emp_code = mycode) and a.emp_code = b.emp_code and a.department_id = d.dep_id and a.status_id in (8) and a.emp_code = mycode) as proposed_dep, (select max(rt.enter_dt) from m_resign_appl_temp rt where rt.emp_code=mycode) as enter_dt, e.emp_code, (select max(rt.resign_dt) from m_resign_appl_temp rt where rt.emp_code=mycode) as resig_dt , ( select decode(t.reason, 1, 'Higher Studies', 2, 'Personal Reason', 3, 'Other Employment', 4, 'Marriage', 5, 'Other Reason') from m_resign_appl_temp t where t.emp_code=mycode )as resig_reas from mactech.employee_master e, mactech.employee_master ae, mactech.employ_personal_dtl ap, mactech.designation_master d1, mactech.designation_master ds, mactech.department_mst d, mactech.employ_transfer_dtl tr, mactech.department_mst td where e.emp_code = mycode and e.emp_code = ap.emp_code and ds.designation_id = d1.designation_id and e.designation_id = ds.designation_id and e.department_id = d.dep_id and tr.emp_code = e.emp_code and tr.status_id = 8 and tr.department_id = td.dep_id and ae.firm_id = 8").Tables(0)

                ' Dim replace As DataTable = ds.Tables(0)
                If (replace.Rows.Count) > 0 Then
                    Dim row As DataRow = replace.Rows(0)

                    ' Extract values from the DataTable
                    Dim empName As String = row("name").ToString()
                    Dim designation As String = row("designation").ToString()
                    Dim department As String = row("proposed_dep").ToString()
                    Dim resignationDate As String = Convert.ToDateTime(row("enter_dt")).ToString("dd-MMM-yyyy")
                    Dim empCode As String = row("emp_code").ToString()
                    Dim lastWorkingDay As String = Convert.ToDateTime(row("resig_dt")).ToString("dd-MMM-yyyy")
                    Dim reason As String = row("resig_reas").ToString()
                    BDY = BDY.Replace("[EmployeeName]", empName)
                    BDY = BDY.Replace("[Designation]", designation)
                    BDY = BDY.Replace("[Department]", department)
                    BDY = BDY.Replace("[Resignation Date]", resignationDate)
                    BDY = BDY.Replace("[EmployeeCode]", empCode)
                    BDY = BDY.Replace("[Proposed Last Working Day]", lastWorkingDay)
                    BDY = BDY.Replace("[If provided by employee]", reason)
                    mail.Subject = mail.Subject.Replace("[Employee Name]", empName)
                    'BDY = BDY.Replace("myname", replace.Rows(0)(1))
                    'BDY = BDY.Replace("mydate", replace.Rows(0)(3))
                    mail.Body = BDY


                    'Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls Or Net.SecurityProtocolType.Tls11 Or Net.SecurityProtocolType.Tls12
                    Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or CType(3072, SecurityProtocolType) Or CType(768, SecurityProtocolType)
                    'mail.[To].Add("elanchezian.s@mactech.net.in")
                    ' mail.To.Add(replace.Rows(0)("office_mailid").ToString())
                    mail.To.Add("girisha@macomsolutions.com")
                    mail.To.Add("nandan@macomsolutions.com")
                    mail.To.Add("hr@macomsolutions.com")

                    server.Send(mail)

                    ' MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim cl_scrip1 As New StringBuilder
                    cl_scrip1.Append("   alert('Mail has been sent Successfully') ;")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
                End If


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
                    sql = "update macdms.m_resign_appl_image_temp set attach=:ph where emp_code=:empid and status=10"
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
                cl_script1.Append("       window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If
            If Parameter(5).Value = 2 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Already an application is waiting for Approval!!');")
            cl_script1.Append("            window.open('../../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
        If Parameter(5).Value = 3 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Error ...Contact IT Department...!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
        If Parameter(5).Value = 4 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('You can only enter Today's date As Notice submitted Date!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                'End If

            Else
        Dim cl_script1 As New System.Text.StringBuilder
        cl_script1.Append("        alert('Resign date must be greater than Today...!!');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If

        Else
        Dim cl_script1 As New System.Text.StringBuilder
        cl_script1.Append("        alert('Resign date must be greater than Today...!!');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If

        'Else
        'Dim script1 As New System.Text.StringBuilder
        'script1.Append("         window.open('home.aspx','_self');")

        'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        'End If
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
        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_rea.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        'Dim ap As String = "29-FEB-2024"
        'ap = ap.Substring(3, 8)

        'shi------
        ' If Not IsPostBack Then
        Dim usr() As String
        usr = Me.Session("user_id").ToString.Split("!")
        'sf = Session("user_id").ToString.Split("!")
        '  Me.txt_emp.Text = sf(0)
        'End If
        Dim dat As DataTable = oh.ExecuteDataSet("select count(*) from TBL_HIGHER_EDN_DTLS_MACOM t where t.status=1 and t.agree_penality is null and  t.emp_code=" & usr(0) & "").Tables(0)
        If dat.Rows(0)(0) > 0 Then

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Please confirm your COURSE PENALITY!!');")
            cl_script1.Append("        window.open('Course_Penalty_Macom.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
        'shi-----
        hid.Value = 1
        If Not IsPostBack Then
            Button1.Enabled = False
            Me.cmb_reason.Enabled = False
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        window.open('rej_res_ho.aspx', 'WinC', 'width=500px,height=380px,toolbar=no,location=no,directories=no,status=no,menubar=no, scrollbars=no,resizable=no,copyhistory=no');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

            'Dim usr() As String
            'usr = Me.Session("user_id").ToString.Split("!")
            'Me.TextBox1.Text = Format(Now.Date, "dd/MMM/yyyy")
            dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=121 and t.firm_id=99").Tables(0)
            alls = dt.Rows(0)(0).ToString.Split("$")

            dt1 = oh.ExecuteDataSet(alls(0)).Tables(0)
            If usr(0) = dt1.Rows(0)(1) Or usr(0) = dt1.Rows(1)(1) Or usr(0) = dt1.Rows(2)(1) Then
                Panel2.Visible = False
            Else
                Label1.Text = dt1.Rows(0)(0)
                Label2.Text = dt1.Rows(2)(0)
                Label3.Text = dt1.Rows(1)(0)
            End If

            dt2 = oh.ExecuteDataSet(alls(1)).Tables(0)
            Me.cmb_reason.DataSource = dt2
            Me.cmb_reason.DataTextField = dt2.Columns(0).ColumnName
            Me.cmb_reason.DataValueField = dt2.Columns(1).ColumnName
            Me.cmb_reason.DataBind()
            Me.Panel1.Visible = True
            Me.hs1.Visible = True
            Me.pr1.Visible = False
            Me.oe1.Visible = False
            Me.mr1.Visible = False
            Me.orr.Visible = False
            dt3 = oh.ExecuteDataSet(alls(2).Replace("mycode", usr(0))).Tables(0)
            If dt3.Rows.Count > 0 Then
                Me.lbl_code.Text = dt3.Rows(0)(0)
                Me.lbl_name.Text = dt3.Rows(0)(1)
            Else
                Server.Transfer("../Show_err.aspx")
            End If
            dt4 = oh.ExecuteDataSet(alls(3)).Tables(0)
            Me.DropDownList2.DataSource = dt4
            Me.DropDownList2.DataTextField = dt4.Columns(0).ColumnName
            Me.DropDownList2.DataValueField = dt4.Columns(1).ColumnName
            Me.DropDownList2.DataBind()

        End If
    End Sub
    Protected Sub cmb_reason_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_reason.SelectedIndexChanged
        Button1.Enabled = True
        Me.cmb_reason.Enabled = True
        dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=121 and t.firm_id=99").Tables(0)
        alls = dt.Rows(0)(0).ToString.Split("$")
        If Me.cmb_reason.SelectedValue = 1 Then
            Me.hs1.Visible = True
            Me.pr1.Visible = False
            Me.oe1.Visible = False
            Me.mr1.Visible = False
            Me.orr.Visible = False
        End If
        If Me.cmb_reason.SelectedValue = 2 Then
            Me.hs1.Visible = False
            Me.pr1.Visible = True
            Me.oe1.Visible = False
            Me.mr1.Visible = False
            Me.orr.Visible = False
            dt1 = oh.ExecuteDataSet(alls(4)).Tables(0)
            Me.cmb_pr.DataSource = dt1
            Me.cmb_pr.DataTextField = dt1.Columns(0).ColumnName
            Me.cmb_pr.DataValueField = dt1.Columns(1).ColumnName
            Me.cmb_pr.DataBind()

        End If
        If Me.cmb_reason.SelectedValue = 3 Then
            Me.hs1.Visible = False
            Me.pr1.Visible = False
            Me.oe1.Visible = True
            Me.mr1.Visible = False
            Me.orr.Visible = False
        End If
        If Me.cmb_reason.SelectedValue = 4 Then
            Me.hs1.Visible = False
            Me.pr1.Visible = False
            Me.oe1.Visible = False
            Me.mr1.Visible = True
            Me.orr.Visible = False
        End If
        If Me.cmb_reason.SelectedValue = 5 Then
            Me.hs1.Visible = False
            Me.pr1.Visible = False
            Me.oe1.Visible = False
            Me.mr1.Visible = False
            Me.orr.Visible = True
        End If
    End Sub


End Class
