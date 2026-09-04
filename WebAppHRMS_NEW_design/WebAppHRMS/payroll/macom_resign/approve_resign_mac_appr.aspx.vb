Imports System.Data
Imports System.Data.OracleClient
Imports System.Net
Imports System.Net.Mail
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports Org.BouncyCastle.Asn1.X509
Public Class approve_resign_mac_appr
    Inherits System.Web.UI.Page

    Dim oh As New Helper.Oracle.OracleHelper
    Dim dtr, tdtt, lastdt1, lastdt, dt, dt1 As DataTable
    Dim alls() As String

    'Public Shared Function GetUniqueFilename(ByVal FileName As String) As String
    '    Dim count As Integer = 0
    '    Dim Name As String = ""
    '    If System.IO.File.Exists(FileName) Then
    '        Dim f As New System.IO.FileInfo(FileName)
    '        If Not String.IsNullOrEmpty(f.Extension) Then
    '            Name = f.FullName.Substring(0, f.FullName.LastIndexOf("."))
    '        Else
    '            Name = f.FullName
    '        End If
    '        While System.IO.File.Exists(FileName)
    '            count += 1
    '            FileName = Name + count.ToString() + f.Extension
    '        End While
    '    End If
    '    Return FileName
    'End Function

    Protected Sub cmd_modify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_modify.ServerClick
        Dim cl_script1 As New System.Text.StringBuilder
        cl_script1.Append("window.open('approve_resign_mac_appr_modify.aspx','_self');")

        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script1.ToString, True)
        Exit Sub
    End Sub




    Protected Sub new_reject_Click(sender As Object, e As EventArgs) Handles new_reject.Click
        Me.Txt_rej.Visible = True
        Me.Label1.Visible = True
        Me.new_reject.Visible = False
        Me.cmd_reject.Visible = True
        Me.pnlRelievingDate.Visible = False
    End Sub

    Protected Sub cmd_reject_Click(sender As Object, e As EventArgs) Handles cmd_reject.Click

        Dim usr() As String
        usr = Me.Session("user_id").ToString.Split("!")


        If Me.Txt_rej.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Please Enter Reject Reason ..!!');")
            cl_script1.Append("window.open('approve_resign_mac_appr.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            Dim parameter(4) As OracleParameter
            parameter(0) = New OracleParameter("code", OracleType.Number, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = Me.lbl_code.Text
            parameter(1) = New OracleParameter("rejrem", OracleType.VarChar, 150)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = Me.Txt_rej.Text
            parameter(2) = New OracleParameter("usr", OracleType.Number, 150)
            parameter(2).Direction = ParameterDirection.Input
            parameter(2).Value = usr(0)
            parameter(3) = New OracleParameter("ubr", OracleType.Number, 150)
            parameter(3).Direction = ParameterDirection.Input
            parameter(3).Value = Session("branch_id")
            parameter(4) = New OracleParameter("msg", OracleType.Number, 150)
            parameter(4).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("M_RESIGNING_REj_MAC", parameter)
            If parameter(4).Value = 1 Then
                Dim mycode() As String
                mycode = usr
                Dim empcode As String = Me.lbl_code.Text
                Dim server As SmtpClient = New SmtpClient("smtp.office365.com")
                server.Port = 587
                server.EnableSsl = True
                server.UseDefaultCredentials = False
                server.DeliveryMethod = SmtpDeliveryMethod.Network
                server.Credentials = New Net.NetworkCredential("no-reply@macomsolutions.com", "vltyzwqhzzkzrcgc")
                server.Timeout = 60000
                Dim mail As MailMessage = New MailMessage()
                mail.From = New MailAddress("no-reply@macomsolutions.com", "MACOM-HR")
                Dim qur As Integer = 452
                If qur = 452 Then
                    mail.Subject = "Resignation Request – Status Update"
                Else
                    mail.Subject = "Default Subject"
                End If
                mail.IsBodyHtml = True
                Dim BDY As String = oh.ExecuteDataSet("select t.query from HRM_REPORT_MASTER t where t.query_id=452").Tables(0).Rows(0)(0)
                'Dim replace As DataTable = oh.ExecuteDataSet("select e.emp_code, e.emp_name, em.office_mailid from mactech.employee_master e join mactech.hrm_emp_additional_dtl em on e.emp_code = em.emp_code and e.firm_id = em.firm_id join m_resign_appl_temp w on e.emp_code = w.emp_code where e.emp_code = '" & emp(0) & "'").Tables(0)
                Dim replace As DataTable = oh.ExecuteDataSet("select distinct decode(ap.sex, 1, 'Mr. ', 0, 'Ms. ') || upper(e.emp_name) name, (select max(rt.enter_dt) from m_resign_appl_temp rt where rt.emp_code = '" & empcode & "') as enter_dt, e.emp_code, (select max(rt.rej_rem) from m_resign_appl_temp rt where rt.emp_code = '" & empcode & "') as rej_reason, (select s.office_mailid from mactech.hrm_emp_additional_dtl s where s.emp_code = '" & empcode & "') as mailid from mactech.employee_master e, mactech.employee_master ae, mactech.employ_personal_dtl ap where e.emp_code = '" & empcode & "' and e.emp_code = ap.emp_code and ae.firm_id = 8").Tables(0)
                ' Dim replace As DataTable = oh.ExecuteDataSet("select distinct decode(ap.sex, 1, 'Mr. ', 0, 'Ms. ') || upper(e.emp_name) name, d1.designation, (select d.dep_name from mactech.employ_transfer_dtl a, mactech.employee_master b, mactech.DEPARTMENT_MST d where a.to_dt is null and a.from_dt in (select max(from_dt) from mactech.employ_transfer_dtl where status_id in (8) and emp_code = mycode) and a.emp_code = b.emp_code and a.department_id = d.dep_id and a.status_id in (8) and a.emp_code = mycode) as proposed_dep, (select max(rt.enter_dt) from m_resign_appl_temp rt where rt.emp_code=mycode) as enter_dt, e.emp_code, (select max(rt.resign_dt) from m_resign_appl_temp rt where rt.emp_code=mycode) as resig_dt , ( select decode(t.reason, 1, 'Higher Studies', 2, 'Personal Reason', 3, 'Other Employment', 4, 'Marriage', 5, 'Other Reason') from m_resign_appl_temp t where t.emp_code=mycode )as resig_reas from mactech.employee_master e, mactech.employee_master ae, mactech.employ_personal_dtl ap, mactech.designation_master d1, mactech.designation_master ds, mactech.department_mst d, mactech.employ_transfer_dtl tr, mactech.department_mst td where e.emp_code = mycode and e.emp_code = ap.emp_code and ds.designation_id = d1.designation_id and e.designation_id = ds.designation_id and e.department_id = d.dep_id and tr.emp_code = e.emp_code and tr.status_id = 8 and tr.department_id = td.dep_id and ae.firm_id = 8").Tables(0)

                ' Dim replace As DataTable = ds.Tables(0)
                If (replace.Rows.Count) > 0 Then
                    Dim row As DataRow = replace.Rows(0)

                    ' Extract values from the DataTable
                    Dim empName As String = row("name").ToString()
                    Dim resignationDate As String = Convert.ToDateTime(row("enter_dt")).ToString("dd-MMM-yyyy")
                    Dim rejectreason As String = row("rej_reason").ToString()
                    Dim recipientMail As String = row("mailid").ToString()
                    ' Dim empCode As String = row("emp_code").ToString()

                    BDY = BDY.Replace("[Employee Name]", empName)
                    BDY = BDY.Replace("[apply date]", resignationDate)
                    BDY = BDY.Replace("[reject reason]", rejectreason)
                    'BDY = BDY.Replace("[EmployeeCode]", empCode)
                    mail.Body = BDY


                    'Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls Or Net.SecurityProtocolType.Tls11 Or Net.SecurityProtocolType.Tls12
                    Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or CType(3072, SecurityProtocolType) Or CType(768, SecurityProtocolType)
                    'mail.[To].Add("elanchezian.s@mactech.net.in")
                    ' mail.To.Add(replace.Rows(0)("office_mailid").ToString())
                    'mail.To.Add("girthigaa.r@mactech.net.in")
                    If Not String.IsNullOrEmpty(recipientMail) Then
                        mail.To.Add(recipientMail)
                    Else
                        ' Optional: Add a fallback email if the employee's mail is missing
                        ' mail.To.Add("girthigaa.r@mactech.net.in") 
                    End If


                    server.Send(mail)

                    ' MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim cl_scrip1 As New StringBuilder
                    cl_scrip1.Append("   alert('Mail has been sent Successfully') ;")

                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
                End If
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('Rejected successfully!!');")
                cl_script1.Append("window.open('approve_resign_mac_appr.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If
            If parameter(4).Value = 2 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('No Such application Exist for Approval!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If
            If parameter(4).Value = 3 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('Error ...Contact IT Department...!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If
            dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=122 and t.firm_id=99").Tables(0)
            alls = dt.Rows(0)(0).ToString.Split("$")
            dtr = oh.ExecuteDataSet(alls(32)).Tables(0)
            Me.cmb_emp.DataSource = dtr
            Me.cmb_emp.DataTextField = dtr.Columns(0).ColumnName
            Me.cmb_emp.DataValueField = dtr.Columns(1).ColumnName
            Me.cmb_emp.DataBind()
            Me.Txt_rdt.Text = ""
            Me.Txt_rea.Text = ""
            Me.Txt_rsdt.Text = ""
            Me.lbl_name.Text = ""
            Me.lbl_code.Text = ""

        End If
    End Sub



    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim usr() As String
        usr = Me.Session("user_id").ToString.Split("!")
        If Me.Txt_rdt.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Please enter Relieving date ..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            Dim parameter(3) As OracleParameter
            parameter(0) = New OracleParameter("code", OracleType.Number, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = Me.lbl_code.Text
            'parameter(1) = New OracleParameter("reldt", OracleType.DateTime, 150)
            'parameter(1).Direction = ParameterDirection.Input
            'parameter(1).Value = Me.Txt_rdt.Text
            parameter(1) = New OracleParameter("usr", OracleType.Number, 150)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = usr(0)
            parameter(2) = New OracleParameter("ubr", OracleType.Number, 150)
            parameter(2).Direction = ParameterDirection.Input
            parameter(2).Value = Session("branch_id")
            parameter(3) = New OracleParameter("msg", OracleType.Number, 150)
            parameter(3).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("M_RESIGNING_SAN_MAC", parameter)
            If parameter(3).Value = 1 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('Sanctioned successfully!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)


                '------'hr approved mail to employee

                Dim mycode() As String
                mycode = usr
                Dim empcode As String = Me.lbl_code.Text

                Dim server As SmtpClient = New SmtpClient("smtp.office365.com")
                server.Port = 587
                server.EnableSsl = True
                server.UseDefaultCredentials = False
                server.DeliveryMethod = SmtpDeliveryMethod.Network
                server.Credentials = New Net.NetworkCredential("no-reply@macomsolutions.com", "vltyzwqhzzkzrcgc")
                server.Timeout = 60000
                Dim mail As MailMessage = New MailMessage()
                mail.From = New MailAddress("no-reply@macomsolutions.com", "MACOM-HR")
                Dim qur As Integer = 451
                If qur = 451 Then
                    mail.Subject = "Resignation Approval Confirmation"
                Else
                    mail.Subject = "Default Subject"
                End If
                mail.IsBodyHtml = True
                Dim BDY As String = oh.ExecuteDataSet("select t.query from HRM_REPORT_MASTER t where t.query_id=451").Tables(0).Rows(0)(0)
                'Dim replace As DataTable = oh.ExecuteDataSet("select e.emp_code, e.emp_name, em.office_mailid from mactech.employee_master e join mactech.hrm_emp_additional_dtl em on e.emp_code = em.emp_code and e.firm_id = em.firm_id join m_resign_appl_temp w on e.emp_code = w.emp_code where e.emp_code = '" & emp(0) & "'").Tables(0)
                Dim replace As DataTable = oh.ExecuteDataSet("select distinct decode(ap.sex, 1, 'Mr. ', 0, 'Ms. ') || upper(e.emp_name) name, (select max(rt.enter_dt) from m_resign_appl_temp rt where rt.emp_code = '" & empcode & "') as enter_dt, e.emp_code, (select max(rt.resign_dt) from m_resign_appl_temp rt where rt.emp_code = '" & empcode & "') as resig_dt, (select s.office_mailid from mactech.hrm_emp_additional_dtl s where s.emp_code = '" & empcode & "') as mailid from mactech.employee_master e, mactech.employee_master ae, mactech.employ_personal_dtl ap where e.emp_code = '" & empcode & "' and e.emp_code = ap.emp_code and ae.firm_id = 8").Tables(0)
                ' Dim replace As DataTable = oh.ExecuteDataSet("select distinct decode(ap.sex, 1, 'Mr. ', 0, 'Ms. ') || upper(e.emp_name) name, d1.designation, (select d.dep_name from mactech.employ_transfer_dtl a, mactech.employee_master b, mactech.DEPARTMENT_MST d where a.to_dt is null and a.from_dt in (select max(from_dt) from mactech.employ_transfer_dtl where status_id in (8) and emp_code = mycode) and a.emp_code = b.emp_code and a.department_id = d.dep_id and a.status_id in (8) and a.emp_code = mycode) as proposed_dep, (select max(rt.enter_dt) from m_resign_appl_temp rt where rt.emp_code=mycode) as enter_dt, e.emp_code, (select max(rt.resign_dt) from m_resign_appl_temp rt where rt.emp_code=mycode) as resig_dt , ( select decode(t.reason, 1, 'Higher Studies', 2, 'Personal Reason', 3, 'Other Employment', 4, 'Marriage', 5, 'Other Reason') from m_resign_appl_temp t where t.emp_code=mycode )as resig_reas from mactech.employee_master e, mactech.employee_master ae, mactech.employ_personal_dtl ap, mactech.designation_master d1, mactech.designation_master ds, mactech.department_mst d, mactech.employ_transfer_dtl tr, mactech.department_mst td where e.emp_code = mycode and e.emp_code = ap.emp_code and ds.designation_id = d1.designation_id and e.designation_id = ds.designation_id and e.department_id = d.dep_id and tr.emp_code = e.emp_code and tr.status_id = 8 and tr.department_id = td.dep_id and ae.firm_id = 8").Tables(0)

                ' Dim replace As DataTable = ds.Tables(0)
                If (replace.Rows.Count) > 0 Then
                    Dim row As DataRow = replace.Rows(0)

                    ' Extract values from the DataTable
                    Dim empName As String = row("name").ToString()
                    Dim resignationDate As String = Convert.ToDateTime(row("enter_dt")).ToString("dd-MMM-yyyy")
                    Dim lastWorkingDay As String = Convert.ToDateTime(row("resig_dt")).ToString("dd-MMM-yyyy")
                    ' Dim empCode As String = row("emp_code").ToString()

                    BDY = BDY.Replace("[Employee Name]", empName)
                    BDY = BDY.Replace("[apply date]", resignationDate)
                    BDY = BDY.Replace("[resign dt]", lastWorkingDay)
                    Dim recipientMail As String = row("mailid").ToString()
                    'BDY = BDY.Replace("[EmployeeCode]", empCode)
                    mail.Body = BDY


                    'Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls Or Net.SecurityProtocolType.Tls11 Or Net.SecurityProtocolType.Tls12
                    Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or CType(3072, SecurityProtocolType) Or CType(768, SecurityProtocolType)
                    'mail.[To].Add("elanchezian.s@mactech.net.in")
                    ' mail.To.Add(replace.Rows(0)("office_mailid").ToString())
                    ' mail.To.Add("girthigaa.r@mactech.net.in")
                    If Not String.IsNullOrEmpty(recipientMail) Then
                        mail.To.Add(recipientMail)
                    Else
                        ' Optional: Add a fallback email if the employee's mail is missing
                        ' mail.To.Add("girthigaa.r@mactech.net.in") 
                    End If


                    server.Send(mail)

                    ' MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim cl_scrip1 As New StringBuilder
                    cl_scrip1.Append("   alert('Mail has been sent Successfully') ;")
                    cl_script1.Append("window.open('approve_resign_mac_appr.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
                End If
                '------'hr approved mail to employee



            End If
            If parameter(3).Value = 2 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('No Such application Exist for Approval!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If
            If parameter(3).Value = 3 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('Error ...Contact IT Department...!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If
            dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=122 and t.firm_id=99").Tables(0)
            alls = dt.Rows(0)(0).ToString.Split("$")
            dtr = oh.ExecuteDataSet(alls(32)).Tables(0)
            Me.cmb_emp.DataSource = dtr
            Me.cmb_emp.DataTextField = dtr.Columns(0).ColumnName
            Me.cmb_emp.DataValueField = dtr.Columns(1).ColumnName
            Me.cmb_emp.DataBind()
            Me.Txt_rdt.Text = ""
            Me.Txt_rea.Text = ""
            Me.Txt_rsdt.Text = ""
            Me.lbl_name.Text = ""
            Me.lbl_code.Text = ""
        End If
    End Sub











    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim usr() As String
            Dim sql As String
            Me.Txt_rej.Visible = False
            Me.cmd_reject.Visible = False
            Me.Label1.Visible = False
            Me.TextBox2.Visible = False
            Me.TextBox1.Visible = False
            Me.Label3.Visible = False
            Me.Label2.Visible = False

            dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=122 and t.firm_id=99").Tables(0)
            alls = dt.Rows(0)(0).ToString.Split("$")
            usr = Me.Session("user_id").ToString.Split("!")
            dt1 = oh.ExecuteDataSet(alls(33).Replace("mycode", usr(0))).Tables(0)
            If Session("branch_id") = 0 Then
                If (dt1.Rows(0)(0) = 1251 Or dt1.Rows(0)(0) = 107) Then
                    dtr = oh.ExecuteDataSet(alls(34)).Tables(0)
                    Me.cmb_emp.DataSource = dtr
                    Me.cmb_emp.DataTextField = dtr.Columns(0).ColumnName
                    Me.cmb_emp.DataValueField = dtr.Columns(1).ColumnName
                    Me.cmb_emp.DataBind()
                    If dtr.Rows.Count > 0 Then
                        lastdt = oh.ExecuteDataSet(alls(35).Replace("mycode", Me.cmb_emp.SelectedValue)).Tables(0)
                        lastdt1 = oh.ExecuteDataSet(alls(36)).Tables(0)
                        If lastdt.Rows(0)(0) > lastdt1.Rows(0)(0) Then
                            tdtt = oh.ExecuteDataSet(alls(37).Replace("mycode", Me.cmb_emp.SelectedValue)).Tables(0)
                            'Txt_rdt.Text = tdtt.Rows(0)(0)
                        Else
                            tdtt = oh.ExecuteDataSet(alls(38)).Tables(0)
                            'Txt_rdt.Text = tdtt.Rows(0)(0)
                        End If
                        Dim dt11 As DataTable = oh.ExecuteDataSet(alls(39).Replace("mycode", Me.cmb_emp.SelectedValue)).Tables(0)
                        Dim dt21 As DataTable = oh.ExecuteDataSet(alls(40).Replace("mycode", Me.cmb_emp.SelectedValue)).Tables(0)
                        Me.lbl_code.Text = dt11.Rows(0)(0)
                        Me.lbl_name.Text = dt11.Rows(0)(1)
                        Me.Txt_rdt.Text = Format(CDate(dt21.Rows(0)(0)), "dd/MMM/yyyy")
                        Me.Txt_rsdt.Text = Format(CDate(dt21.Rows(0)(1)), "dd/MMM/yyyy")
                        If IsDBNull(dt21.Rows(0)(2)) Then
                            Me.Txt_rea.Text = ""
                        Else
                            Me.Txt_rea.Text = dt21.Rows(0)(2)
                        End If
                    Else
                        Dim cl_script11 As New System.Text.StringBuilder
                        cl_script11.Append("        alert('No Employees Found...!!');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
                    End If
                Else
                    ' Server.Transfer("../../show_err.aspx")
                    'Response.Redirect("../../show_err.aspx")
                    Dim cl_script0 As New System.Text.StringBuilder
                    cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
                    cl_script0.Append("window.open('../../home.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

                End If
            End If
        End If


    End Sub

    Protected Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.TextChanged
        If Not String.IsNullOrEmpty(TextBox1.Text) Then
            Dim resignDate As Date
            If Date.TryParse(TextBox1.Text, resignDate) Then
                ' Add 90 days
                Dim lastDay As Date = resignDate.AddDays(90)
                ' Show it in TextBox2
                TextBox2.Text = lastDay.ToString("dd-MMM-yyyy")
            Else
                ' Invalid date entered
                TextBox2.Text = ""
            End If
        End If
    End Sub


    Protected Sub cmb_emp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_emp.SelectedIndexChanged
        dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=122 and t.firm_id=99").Tables(0)
        alls = dt.Rows(0)(0).ToString.Split("$")
        If Me.cmb_emp.SelectedValue <> "" Then
            Dim dt1 As DataTable = oh.ExecuteDataSet(alls(41).Replace("mycode", Me.cmb_emp.SelectedValue)).Tables(0)
            Dim dt2 As DataTable = oh.ExecuteDataSet(alls(42).Replace("mycode", Me.cmb_emp.SelectedValue)).Tables(0)
            Me.lbl_code.Text = dt1.Rows(0)(0)
            Me.lbl_name.Text = dt1.Rows(0)(1)
            Me.Txt_rsdt.Text = Format(CDate(dt2.Rows(0)(1)), "dd/MMM/yyyy")
            If IsDBNull(dt2.Rows(0)(2)) Then
                Me.Txt_rea.Text = ""
            Else
                Me.Txt_rea.Text = dt2.Rows(0)(2)
            End If
        Else
            Dim cl_script11 As New System.Text.StringBuilder
            cl_script11.Append("        alert('No Employees Found...!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
        End If
    End Sub

    Protected Sub Txt_rdt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_rdt.TextChanged
        'dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=121 and t.firm_id=99").Tables(0)
        'alls = dt.Rows(0)(0).ToString.Split("$")
        'Dim dt2 As DataTable = oh.ExecuteDataSet(alls(42).Replace("mycode", Me.cmb_emp.SelectedValue)).Tables(0)
        'If Format(CDate(Me.Txt_rdt.Text), "dd/MMM/yyyy") > Format(CDate(dt2.Rows(0)(0)), "dd/MMM/yyyy") Then
        '    Me.Txt_rdt.Text = ""
        '    Me.lbl1.Text = "Relieving date must be less or Equal to Resign Date"
        '    Dim cl_script11 As New System.Text.StringBuilder
        '    cl_script11.Append("        alert('Relieving date must be less or Equal to Resign Date...!!');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
        'Else
        '    Me.lbl1.Text = " "
        'End If
    End Sub

    Protected Sub cmd_att_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_att.ServerClick
        dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=122 and t.firm_id=99").Tables(0)
        alls = dt.Rows(0)(0).ToString.Split("$")
        Dim dt6 As DataTable = oh.ExecuteDataSet(alls(43).Replace("mycode", Me.cmb_emp.SelectedValue)).Tables(0)
        If dt6.Rows(0)(0) = 0 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('No Resignation Letter Attached');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Verify Resignation Letter');")
            'cl_script1.Append("window.open('resign_attach.aspx?empid=" & Me.cmb_emp.SelectedValue & "');")
            ' Server.Transfer("Resign_report_macom.aspx?Ecode=" & lbl_code.Text)
            Response.Redirect("Resign_report_macom.aspx?Ecode=" & lbl_code.Text)

            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
    End Sub
End Class