Imports System.Data
Imports System.Data.OracleClient
Imports System.Net.Mail
Imports System.Net
Partial Class PROMOTION_promotion_frm_fc97d4d36758
    Inherits System.Web.UI.Page
    Dim dt, dt5, dtv As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql, sql3 As String
    Dim fr_time, to_time, da, F, T, idmail() As String
    Dim sb As New StringBuilder
    Dim oldtdate, newfdate, basicdate As Date
    Dim frm As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        frm = Session("Firm_id").ToString
        If frm = 2 Then
            Response.Redirect("Promotion_frm_maben.aspx")
            Exit Sub
        End If

        If Not IsPostBack Then
            ' dt = oh.ExecuteDataSet("select a.emp_name||'('||a.emp_code||')' ,a.emp_code||'*'||a.emp_name||'*'||a.status_id||'*'||b.branch_name||'*'||a.designation_id||'*'||c.designation||'*'||e.post_name||'*'||d.dep_name from employee_master a,branch_master b,designation_master c,department_mst d,post_mst e where a.branch_id=b.branch_id and a.status_id=1 and a.designation_id=c.designation_id and a.department_id=d.dep_id and a.post_id=e.post_id and  a.emp_code not in (22523,22283) order by a.emp_name").Tables(0)
            If frm = 24 Then
                dt = oh.ExecuteDataSet("select a.emp_code||'-'||a.emp_name ,a.emp_code||'*'||a.emp_name||'*'||a.status_id||'*'||b.branch_name||'*'||a.designation_id||'*'||c.designation||'*'||e.post_name||'*'||d.dep_name from employee_master a,branch_master b,designation_master c,department_mst d,post_mst_jwell e,employ_firm ef where a.emp_code=ef.emp_code and ef.firm_id=" & frm & " and a.branch_id=b.branch_id and a.status_id=1 and a.designation_id=c.designation_id and a.department_id=d.dep_id and a.post_id=e.post_id and  a.emp_code not in (select emp_code from employee_exception where  status_id=7) union select a.emp_code||'-'||a.emp_name ,a.emp_code||'*'||a.emp_name||'*'||a.status_id||'*'||b.branch_name||'*'||a.designation_id||'*'||c.designation||'*'||e.post_name||'*'||d.dep_name from employee_master a,before_completion b,designation_master c,department_mst d,post_mst_jwell e,employ_firm ef where a.emp_code=ef.emp_code and ef.firm_id=" & frm & " and a.branch_id=b.old_id and b.branch_id is null and a.status_id=1 and a.designation_id=c.designation_id and a.department_id=d.dep_id and a.post_id=e.post_id and  a.emp_code not in (select emp_code from employee_exception where  status_id=7) ").Tables(0)
            Else
                dt = oh.ExecuteDataSet("select a.emp_code||'-'||a.emp_name ,a.emp_code||'*'||a.emp_name||'*'||a.status_id||'*'||b.branch_name||'*'||a.designation_id||'*'||c.designation||'*'||e.post_name||'*'||d.dep_name from employee_master a,branch_master b,designation_master c,department_mst d,post_mst e,employ_firm ef where a.emp_code=ef.emp_code and ef.firm_id=" & frm & " and a.branch_id=b.branch_id and a.status_id=1 and a.designation_id=c.designation_id and a.department_id=d.dep_id and a.post_id=e.post_id and  a.emp_code not in (select emp_code from employee_exception where  status_id=7) union select a.emp_code||'-'||a.emp_name ,a.emp_code||'*'||a.emp_name||'*'||a.status_id||'*'||b.branch_name||'*'||a.designation_id||'*'||c.designation||'*'||e.post_name||'*'||d.dep_name from employee_master a,before_completion b,designation_master c,department_mst d,post_mst e,employ_firm ef where a.emp_code=ef.emp_code and ef.firm_id=" & frm & " and a.branch_id=b.old_id and b.branch_id is null and a.status_id=1 and a.designation_id=c.designation_id and a.department_id=d.dep_id and a.post_id=e.post_id and  a.emp_code not in (select emp_code from employee_exception where  status_id=7) ").Tables(0)
            End If

            Me.cmb_employee.DataSource = dt
            Me.cmb_employee.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_employee.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_employee.DataBind()

            fill_select()
            designation_fill()
            pdesignation_fill()
            payment_fill()
            totsal()
            Me.Lbl_MESSAGE.Visible = False
        End If
        If Session("firm_id") = 8 Then
            Dim cl_script As New StringBuilder
            cl_script.Append("window.open('promotion_all/promotion_frm_all.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            'Me.Timer1.Enabled = False

        End If



        Me.Lbl_MESSAGE.Text = ""
        Me.Cmd_Exit.Attributes.Add("onclick", "exit()")
    End Sub
    Sub fill_select()
        Dim arr As Array
        arr = Me.cmb_employee.SelectedValue.Split("*")
        Me.txt_name.Text = arr(1)
        Me.txt_desination.Text = arr(5)
        Me.txt_branch.Text = arr(3)
        Me.txt_postoffer.Text = arr(6)
        Me.txt_department.Text = arr(7)
        Me.txt_totalsalary.Text = 0
        Me.txt_enter.Text = 0
    End Sub

    Protected Sub cmb_employee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_employee.SelectedIndexChanged
        fill_select()
    End Sub
    Sub designation_fill()
        Dim sql As String
        sql = "select a.designation||'('||a.designation_id||')',a.designation_id||'*'||a.grade_id||'*'||a.designation||'*'||a.payment_id from designation_master a,grade_master b where a.grade_id=b.grade_id order by a.designation"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Me.cmb_designation.DataSource = dt
            Me.cmb_designation.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_designation.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_designation.DataBind()
        End If
    End Sub
    Sub pdesignation_fill()
        Dim sql As String
        sql = "select designation,designation_id from designation_master  order by designation"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Me.cmb_pdesig.DataSource = dt
            Me.cmb_pdesig.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_pdesig.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_pdesig.DataBind()
        End If
    End Sub
    Sub payment_fill()
        Dim arr As Array
        arr = Me.cmb_designation.SelectedValue.Split("*")
        Dim dt1, dt2, dt3 As New DataTable
        Dim sql, sql1 As String
        Dim k, j, n, a, basic, incerement, period As Integer

        sql = "select 'NOT IN THE LIST AND WANT TO ENTER..?', -1, -1  from dual union all select to_char(BASIC_PAY),INCREMENT_AMT,PERIOD from pay_scale where PAYMENT_ID=" & arr(3) & " order by 1 desc"

        sql1 = ("select count(*) from pay_scale where PAYMENT_ID=" & arr(3) & "")
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        n = dt1.Rows(0)(0)

        dt = oh.ExecuteDataSet(sql).Tables(0)

        a = 0
        Dim tdt, tdt2 As New DataTable
        Dim tdr, tdr2 As DataRow
        Dim tdc1, tdc3, tdc4 As New DataColumn()
        Dim tdc2 As New DataColumn()
        tdt.Columns.Add(tdc1)
        tdt.Columns.Add(tdc2)

        tdt.Columns.Add(tdc3)
        tdt.Columns.Add(tdc4)
        tdr2 = tdt.NewRow
        Dim a2, b2 As String

        a2 = dt.Rows(0)(0)
        b2 = dt.Rows(0)(1)
        tdr2(0) = dt.Rows(0)(0)
        tdr2(1) = dt.Rows(0)(1)
        tdt.Rows.Add(tdr2)

        For k = 1 To n - 1
            basic = dt.Rows(k)(0)
            incerement = dt.Rows(k)(1)
            period = dt.Rows(k)(2)
            tdr = tdt.NewRow
            tdr(0) = basic
            tdr(1) = a
            tdt.Rows.Add(tdr)
            For j = 1 To period
                basic = basic + incerement
                tdr = tdt.NewRow
                a = a + 1
                tdr(0) = basic
                tdr(1) = a
                tdt.Rows.Add(tdr)
            Next
            a = a + 1
        Next

        Me.cmb_pay_amnt.DataSource = tdt
        Me.cmb_pay_amnt.DataTextField = tdt.Columns(0).ColumnName
        Me.cmb_pay_amnt.DataValueField = tdt.Columns(1).ColumnName
        Me.cmb_pay_amnt.DataBind()
    End Sub
    Protected Sub cmb_designation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_designation.SelectedIndexChanged
        Me.txt_totalsalary.Text = ""
        Me.Td1.Visible = True
        Me.Td2.Visible = True
        Me.txt_enter.Text = 0
        payment_fill()
    End Sub
    Protected Sub txt_effective_date_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sql4 As String
        Dim dt4 As New DataTable
        Dim dat As Date
        Dim arr As Array
        Dim empid As New Integer
        arr = Me.cmb_employee.SelectedValue.Split("*")
        empid = arr(0)
        sql4 = ("select to_date(from_dt) from employ_promotion_dtl where to_date(TO_DT) is null and status_id in (1,7,11) and emp_code=" & empid)
        dt4 = oh.ExecuteDataSet(sql4).Tables(0)
        dat = dt4.Rows(0)(0)

        If (Me.txt_effective_date.Text <= dat) Then
            Me.Lbl_MESSAGE.Visible = True
            Me.Lbl_MESSAGE.Text = "*************EFFECTIVE DATE SHOULD BE GREATER THAN" & dat
            Me.txt_effective_date.Text = ""
        End If

    End Sub
    Protected Sub cmb_pay_amnt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_pay_amnt.SelectedIndexChanged
        totsal()
    End Sub
    Sub totsal()
        Dim arr As Array
        arr = Me.cmb_designation.SelectedValue.Split("*")
        Dim dt1, dt2, dt3 As New DataTable
        Dim sql2 As String
        Dim basic As Integer
        If IsNumeric(Me.cmb_pay_amnt.SelectedItem.Text) Then

            basic = Me.cmb_pay_amnt.SelectedItem.Text

            Me.Td1.Visible = False
            Me.Td2.Visible = False
            Me.txt_enter.Text = 0


        Else
            Me.Td1.Visible = True
            Me.Td2.Visible = True
            Me.txt_enter.Text = 0
            basic = Me.txt_enter.Text
        End If

        Me.txt_totalsalary.Text = 0
        If arr(3) <> 14 Then
            sql2 = ("select t.value,t.from_dt,t.to_dt,t.enter_dt from da_index t where t.to_dt is null and t.firm_id=" & frm & "")
            dt3 = oh.ExecuteDataSet(sql2).Tables(0)
            If dt3.Rows.Count > 0 Then
                da = dt3.Rows(0)(0)
                Me.txt_totalsalary.Text = basic + da
            End If

        Else
            Me.txt_totalsalary.Text = basic
        End If
    End Sub
    Protected Sub Cmd_Exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Server.Transfer("../home.aspx")
    End Sub

    Protected Sub Cmd_Clear_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        clear()
        'Server.Transfer("promotion_frm.aspx")
    End Sub
    Sub clear()
        Me.txt_name.Text = ""
        Me.txt_postoffer.Text = ""
        Me.txt_department.Text = ""
        Me.txt_desination.Text = ""
        Me.txt_branch.Text = ""
        Me.txt_effective_date.Text = ""
        Me.txt_totalsalary.Text = ""
        Me.txt_enter.Text = ""



    End Sub
    Protected Sub cmd_confirm_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Try






            If Me.txt_effective_date.Text = "" Then
                'Me.Timer1.Enabled = True
                Me.Lbl_MESSAGE.Visible = True
                Me.Lbl_MESSAGE.Text = "*************PLEASE ENTER THE EFFECTIVE DATE!!!!******"
            Else
                Dim empid, newpscale, newbasic, grad, newdesig, basic As New Integer
                Dim arr, arr1 As Array
                arr = Me.cmb_employee.SelectedValue.Split("*")
                empid = arr(0)
                If Me.cmb_pay_amnt.SelectedItem.Text <> "NOT IN THE LIST AND WANT TO ENTER..?" Then
                    basic = Me.cmb_pay_amnt.SelectedItem.Text
                Else
                    If Me.txt_totalsalary.Text <> "" Then
                        basic = Me.txt_totalsalary.Text
                    End If
                End If
                oldtdate = Me.txt_effective_date.Text
                oldtdate = DateAdd(DateInterval.Day, -1, oldtdate)
                newfdate = Me.txt_effective_date.Text

                arr1 = Me.cmb_designation.SelectedValue.Split("*")
                newpscale = arr1(3)    'pay_id
                'newbasic = Me.txt_totalsalary.Text
                newbasic = basic
                newdesig = Me.cmb_pdesig.SelectedValue
                grad = arr1(1)
                'PAY_ID 14 ,IT REPRESENTS CONSOLIDATED PAY
                If newpscale = 14 Then
                    da = "F"
                Else
                    da = "T"
                End If

                basicdate = Me.txt_effective_date.Text
                If Me.txt_effective_date.Text < Format(Date.Now, "dd/MMM/yyyy") Then
                    basicdate = Format(Date.Now, "dd/MMM/yyyy")
                End If

                Dim prm(10) As OracleParameter

                prm(0) = New OracleParameter("empid", OracleType.Int32, 25)
                prm(0).Direction = ParameterDirection.Input
                prm(0).Value = empid

                prm(1) = New OracleParameter("oldtdate", OracleType.DateTime)
                prm(1).Direction = ParameterDirection.Input
                prm(1).Value = oldtdate

                prm(2) = New OracleParameter("newfdate", OracleType.DateTime)
                prm(2).Direction = ParameterDirection.Input
                prm(2).Value = newfdate

                prm(3) = New OracleParameter("newpscale", OracleType.Int32, 15)
                prm(3).Direction = ParameterDirection.Input
                prm(3).Value = newpscale

                prm(4) = New OracleParameter("newbasic", OracleType.Int32, 60)
                prm(4).Direction = ParameterDirection.Input
                prm(4).Value = newbasic

                prm(5) = New OracleParameter("newdesig", OracleType.Int32, 35)
                prm(5).Direction = ParameterDirection.Input
                prm(5).Value = newdesig

                prm(6) = New OracleParameter("grad", OracleType.Int32, 25)
                prm(6).Direction = ParameterDirection.Input
                prm(6).Value = grad

                prm(7) = New OracleParameter("da", OracleType.VarChar, 25)
                prm(7).Direction = ParameterDirection.Input
                prm(7).Value = da

                prm(8) = New OracleParameter("basicdate", OracleType.DateTime)
                prm(8).Direction = ParameterDirection.Input
                prm(8).Value = basicdate

                prm(9) = New OracleParameter("a", OracleType.Int32, 15)
                prm(9).Direction = ParameterDirection.Output
                prm(10) = New OracleParameter("usrid", OracleType.VarChar, 25)
                prm(10).Value = Session("user_id")
                prm(10).Direction = ParameterDirection.Input







                Dim a As Integer

                oh.ExecuteNonQuery("PROMOTION_UPDATE2", prm)
                prm(9).Value = a

                If a = 1 Then
                    'Me.Timer1.Enabled = True
                    Dim f As Integer = Session("firm_id")
                    f = Session("firm_id")
                    If f = 2 Then
                        Try
                            Dim c1 As String
                            c1 = "select y.emailid, y.subject1, y.bodymess1, y.host,y.credent,y.too,y.bodymess2 from mailing_serves y where y.subject1='PROMOTION LETTER,REGARDING PROMOTION'and y.firm_id=2"
                            dtv = oh.ExecuteDataSet(c1).Tables(0)
                            Dim b1 As String = dtv.Rows(0)(2).ToString.Split("#")(0)
                            Dim sub1 As String = dtv.Rows(0)(1).ToString.Split(",")(0)
                            Dim shima1 As String = dtv.Rows(0)(2).ToString.Split("#")(1)
                            shima1 = shima1.Replace("mycode", Me.cmb_employee.SelectedValue.Split("*")(0))
                            Dim dtv1 As DataTable = oh.ExecuteDataSet(shima1).Tables(0)
                            b1 = b1.Replace("myname", dtv1.Rows(0)(0))
                            b1 = b1.Replace("mydes", dtv1.Rows(0)(1))
                            b1 = b1.Replace("mypost", dtv1.Rows(0)(2))
                            b1 = b1.Replace("mynewdes", dtv1.Rows(0)(3))
                            b1 = b1.Replace("mypost", dtv1.Rows(0)(4))
                            b1 = b1.Replace("mycode", dtv1.Rows(0)(5))
                            b1 = b1.Replace("myname", dtv1.Rows(0)(6))
                            b1 = b1.Replace("mydes", dtv1.Rows(0)(7))
                            b1 = b1.Replace("mypost", dtv1.Rows(0)(8))
                            b1 = b1.Replace("mydep", dtv1.Rows(0)(9))
                            b1 = b1.Replace("mycode", dtv1.Rows(0)(10))
                            b1 = b1.Replace("myname", dtv1.Rows(0)(11))
                            b1 = b1.Replace("mynewdes", dtv1.Rows(0)(12))
                            b1 = b1.Replace("mypost", dtv1.Rows(0)(13))
                            b1 = b1.Replace("mydep", dtv1.Rows(0)(14))
                            b1 = b1.Replace("mynewbranch", dtv1.Rows(0)(18))


                            'for employee start
                            Dim from As String = dtv.Rows(0)(0).ToString
                            Dim tooffic As String = dtv.Rows(0)(5).ToString
                            Dim pass As String = dtv.Rows(0)(4).ToString
                            Dim host As String = dtv.Rows(0)(3).ToString
                            Dim mail As MailMessage = New MailMessage()
                            Dim SmtpServer As SmtpClient = New SmtpClient(host, 587)
                            mail.From = New MailAddress(from, "RECRUITMENT")
                            'mail.To.Add(New MailAddress(tooffic))
                            If dtv1.Rows(0)(17).ToString <> "0" Then
                                Dim togmail As String = dtv1.Rows(0)(17).ToString
                                mail.To.Add(New MailAddress(togmail))
                            Else
                                mail.To.Add(New MailAddress(dtv.Rows(0)(0).ToString))
                            End If
                            mail.Subject = sub1
                            mail.Body = String.Format(b1)
                            mail.IsBodyHtml = True
                            mail.BodyEncoding = System.Text.Encoding.UTF8
                            SmtpServer.Port = 587
                            SmtpServer.UseDefaultCredentials = False
                            SmtpServer.Credentials = New System.Net.NetworkCredential(from, pass)
                            'SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network
                            'SmtpServer.EnableSsl = True
                            'ServicePointManager.Expect100Continue = True
                            'System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or CType(3072, SecurityProtocolType) Or CType(768, SecurityProtocolType)
                            SmtpServer.Send(mail)
                            'for employee end


                            Dim b2 As String = dtv.Rows(0)(2).ToString.Split("#")(3)
                            Dim sub2 As String = dtv.Rows(0)(1).ToString.Split(",")(1)
                            Dim shima2 As String = dtv.Rows(0)(2).ToString.Split("#")(1)
                            shima2 = shima2.Replace("mycode", Me.cmb_employee.SelectedValue.Split("*")(0))
                            Dim dtv2 As DataTable = oh.ExecuteDataSet(shima2).Tables(0)
                            b2 = b2.Replace("myname", dtv2.Rows(0)(0))
                            b2 = b2.Replace("mydes", dtv2.Rows(0)(1))
                            b2 = b2.Replace("mypost", dtv2.Rows(0)(2))
                            b2 = b2.Replace("mynewdes", dtv2.Rows(0)(3))
                            b2 = b2.Replace("mypost", dtv2.Rows(0)(4))
                            b2 = b2.Replace("mycode", dtv2.Rows(0)(5))
                            b2 = b2.Replace("myname", dtv2.Rows(0)(6))
                            b2 = b2.Replace("mydes", dtv2.Rows(0)(7))
                            b2 = b2.Replace("mypost", dtv2.Rows(0)(8))
                            b2 = b2.Replace("mydep", dtv2.Rows(0)(9))
                            b2 = b2.Replace("mycode", dtv2.Rows(0)(10))
                            b2 = b2.Replace("myname", dtv2.Rows(0)(11))
                            b2 = b2.Replace("mynewdes", dtv2.Rows(0)(12))
                            b2 = b2.Replace("mypost", dtv2.Rows(0)(13))
                            b2 = b2.Replace("mydep", dtv2.Rows(0)(14))
                            b2 = b2.Replace("mynewbranch", dtv2.Rows(0)(18))


                            'for others start
                            Dim fromo As String = dtv.Rows(0)(0).ToString
                            Dim passo As String = dtv.Rows(0)(4).ToString
                            Dim hosto As String = dtv.Rows(0)(3).ToString
                            Dim mailo As MailMessage = New MailMessage()
                            Dim SmtpServero As SmtpClient = New SmtpClient(hosto, 587)
                            mailo.From = New MailAddress(fromo, "RECRUITMENT")
                            Dim latest As DataTable = oh.ExecuteDataSet("select em.branch_id, t.area_id ,em.department_id from BRANCH_DETAIL   t,branch_master   b,employee_master em where em.branch_id = t.BRANCH_ID and b.branch_id = t.BRANCH_ID and em.emp_code=" & Me.cmb_employee.SelectedValue.Split("*")(0) & "").Tables(0)

                            ''for from and to branches
                            'Dim bradres As String = dtv.Rows(0)(6).ToString.Split("|")(0)
                            'Dim brmailids() As String = bradres.Split(",")
                            'For Each brst As String In brmailids
                            '    If brst.ToString.Split("~")(1) = latest.Rows(0)(0) Then
                            '        mailo.To.Add(New MailAddress(brst.ToString.Split("~")(0)))
                            '    End If
                            'Next

                            ''for from and to areaheads
                            'Dim ahadres As String = dtv.Rows(0)(6).ToString.Split("|")(1)
                            'Dim ahmailids() As String = ahadres.Split(",")
                            'For Each ahst As String In ahmailids
                            '    If ahst.ToString.Split("~")(1) = latest.Rows(0)(1) Then
                            '        mailo.To.Add(New MailAddress(ahst.ToString.Split("~")(0)))
                            '    End If
                            'Next

                            ''for ALL HO & other officials
                            'Dim hofadres As String = dtv.Rows(0)(6).ToString.Split("|")(2)
                            'Dim hofmailids() As String = hofadres.Split(",")
                            'For Each hofst As String In hofmailids
                            '    mailo.To.Add(New MailAddress(hofst))
                            'Next

                            ''for ALL LAP
                            'If latest.Rows(0)(2) = 607 Then
                            '    Dim lapadres As String = dtv.Rows(0)(6).ToString.Split("|")(3)
                            '    Dim lapmailids() As String = lapadres.Split(",")
                            '    For Each lapst As String In lapmailids
                            '        mailo.To.Add(New MailAddress(lapst))
                            '    Next
                            'End If

                            ''for DEP HEADS
                            'Dim depadres As String = dtv.Rows(0)(6).ToString.Split("|")(4)
                            'Dim depmailids() As String = depadres.Split(",")
                            'For Each depst As String In depmailids
                            '    If depst.ToString.Split("~")(1) = latest.Rows(0)(2) Then
                            '        mailo.To.Add(New MailAddress(depst))
                            '    End If
                            'Next

                            ''for ALL HO & other officials
                            'Dim hofadres As String = dtv.Rows(0)(6).ToString.Split("|")(2)
                            'Dim hofmailids() As String = hofadres.Split(",")
                            'For Each hofst As String In hofmailids
                            '    'mailo.To.Add(New MailAddress(hofst))
                            '    sb.Append(hofst)
                            '    sb.Append("&")
                            'Next

                            ''for from and to branches
                            'Dim bradres As String = dtv.Rows(0)(6).ToString.Split("|")(0)
                            'Dim brmailids() As String = bradres.Split(",")
                            'For Each brst As String In brmailids
                            '    If brst.ToString.Split("~")(1) = latest.Rows(0)(0) Then
                            '        'mailo.To.Add(New MailAddress(brst.ToString.Split("~")(0)))
                            '        sb.Append(brst.ToString.Split("~")(0))
                            '        sb.Append("&")
                            '    End If
                            'Next

                            ''for from and to areaheads
                            'Dim ahadres As String = dtv.Rows(0)(6).ToString.Split("|")(1)
                            'Dim ahmailids() As String = ahadres.Split(",")
                            'For Each ahst As String In ahmailids
                            '    If ahst.ToString.Split("~")(1) = latest.Rows(0)(1) Then
                            '        'mailo.To.Add(New MailAddress(ahst.ToString.Split("~")(0)))
                            '        sb.Append(ahst.ToString.Split("~")(0))
                            '        sb.Append("&")
                            '    End If
                            'Next

                            ''for ALL LAP
                            'If latest.Rows(0)(2) = 607 Then
                            '    Dim lapadres As String = dtv.Rows(0)(6).ToString.Split("|")(3)
                            '    Dim lapmailids() As String = lapadres.Split(",")
                            '    For Each lapst As String In lapmailids
                            '        'mailo.To.Add(New MailAddress(lapst))
                            '        sb.Append(lapst)
                            '        sb.Append("&")
                            '    Next
                            'End If

                            ''for DEP HEADS
                            'Dim depadres As String = dtv.Rows(0)(6).ToString.Split("|")(4)
                            'Dim depmailids() As String = depadres.Split(",")
                            'For Each depst As String In depmailids
                            '    If depst.ToString.Split("~")(1) = latest.Rows(0)(2) Then
                            '        'mailo.To.Add(New MailAddress(depst.ToString.Split("~")(0)))
                            '        sb.Append(depst.ToString.Split("~")(0))
                            '        sb.Append("&")
                            '    End If
                            'Next

                            ''For Each tomail As String In sb.ToString().Split("&")
                            ''    mailo.To.Add(New MailAddress(tomail))
                            ''Next
                            'idmail = sb.ToString().Split("&")
                            'For i As Integer = 0 To idmail.Length - 1
                            '    If ((idmail(i) <> "") And (Not IsDBNull(idmail(i)))) Then
                            '        mailo.To.Add(New MailAddress(idmail(i)))
                            '    End If
                            'Next

                            'for all except md,cs,ceo,cfo (To)
                            Dim bradres As String = dtv.Rows(0)(6).ToString.Split("|")(0)
                            Dim brmailids() As String = bradres.Split(",")
                            For Each brst As String In brmailids
                                mailo.To.Add(New MailAddress(brst))
                            Next

                            'for  md,cs,ceo,cfo (CC)
                            Dim ahadres As String = dtv.Rows(0)(6).ToString.Split("|")(1)
                            Dim ahmailids() As String = ahadres.Split(",")
                            For Each ahst As String In ahmailids
                                mailo.CC.Add(New MailAddress(ahst))
                            Next

                            mailo.Subject = sub2
                            mailo.Body = String.Format(b2)
                            mailo.IsBodyHtml = True
                            mailo.BodyEncoding = System.Text.Encoding.UTF8
                            SmtpServero.Port = 587
                            SmtpServero.UseDefaultCredentials = False
                            SmtpServero.Credentials = New System.Net.NetworkCredential(fromo, passo)
                            'SmtpServero.DeliveryMethod = SmtpDeliveryMethod.Network
                            'SmtpServero.EnableSsl = True
                            'ServicePointManager.Expect100Continue = True
                            'System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or CType(3072, SecurityProtocolType) Or CType(768, SecurityProtocolType)
                            SmtpServero.Send(mailo)
                            'for others end
                        Catch ex As Exception
                        End Try
                    End If
                    'MIAL CONFIGURATION END
                    Me.Lbl_MESSAGE.Visible = True
                    Me.Lbl_MESSAGE.Text = "************PROMOTION/REVERTING CONFIRMED SUCCESSFULLY!!!!********"
                    clear()
                Else
                    'Me.Timer1.Enabled = True
                    Me.Lbl_MESSAGE.Visible = True
                    Me.Lbl_MESSAGE.Text = "************THIS EMPLOYEE PROMOTION WAS ALREADY CONFIRMED********"
                    clear()
                End If
                clear()
                Dim arr3 As Array
                arr3 = Me.cmb_employee.SelectedValue.Split("*")
                Dim str As String
                str = ""
                str = arr3(0)
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("window.open('prom_rev_report.aspx?from_date=" & str & "');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

                'Response.Redirect("prom_rev_report.aspx?from_date=" & str)
            End If


        Catch ex As Exception
            Dim trace = New Diagnostics.StackTrace(ex, True)
            Dim line As String = Strings.Right(trace.ToString, 5)
            Dim nombreMetodo As String = ""

            For Each sf As Diagnostics.StackFrame In trace.GetFrames
                nombreMetodo = sf.GetFileLineNumber()
            Next
            Me.Label3.Text = line & vbCrLf & ex.Message & nombreMetodo
        End Try
    End Sub

    Protected Sub txt_enter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_enter.TextChanged
        If Me.txt_totalsalary.Text = "" Or val(Me.txt_totalsalary.Text) = 0 Then
            Me.txt_totalsalary.Text = Me.txt_enter.Text
        Else
            Me.txt_totalsalary.Text = Me.txt_enter.Text
        End If
    End Sub




End Class