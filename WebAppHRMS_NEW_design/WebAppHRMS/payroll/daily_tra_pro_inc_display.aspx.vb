Imports System.Data
Imports System.Data.OracleClient
Partial Class report_daily_tra_pro_inc_display_9f8bf7d19145
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2, dts As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dts = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=5215 and s.emp_id=" & Session("user_id").ToString.Split("!")(0) & "").Tables(0)
        If (dts.Rows(0)(0) = 0) Then
            Server.Transfer("../show_err.aspx")
            Exit Sub
        End If
        If (Request.QueryString("cat") = 1) Then
            dt = oh.ExecuteDataSet("select e.emp_code,  e.emp_name,  to_char(t.from_dt) as present_date,  to_char(r.from_dt) as past_date,  b.branch_name as present_branch,  b1.branch_name as past_branch,  d.dep_name as present_dep,  dm.dep_name as past_dep,  pm.post_name as past_post,  p.post_name as present_post,  to_char(t.enter_dt) as enter_date,  case when t.deputation_id=0 then fm.firm_abbr else fm1.firm_abbr end as curr_firm,  case when r.deputation_id=0 then fm.firm_abbr else fm2.firm_abbr end as past_firm    from employee_master     e left outer join  firm_master fm on (e.firm_id=fm.firm_id),  employ_transfer_dtl t left outer join  firm_master fm1 on (t.deputation_id=fm1.firm_id),  department_mst      d,  department_mst      dm,  post_mst            p,  post_mst            pm,  branch              b,  branch              b1,  employ_transfer_dtl r left outer join  firm_master fm2 on (r.deputation_id=fm2.firm_id),employ_firm f    where e.emp_code = t.emp_code  and t.department_id = d.dep_id  and r.department_id = dm.dep_id  and r.post_id = pm.post_id  and r.status_id in (1, 8)  and t.post_id = p.post_id  and t.emp_code = r.emp_code  and to_date(r.to_dt) = (to_date(t.from_dt) - 1)  and r.branch_id = b1.branch_id  and t.branch_id = b.branch_id  and to_date(t.enter_dt) between '" & Request.QueryString("fdt") & "' and  '" & Request.QueryString("tdt") & "'  and t.status_id = 8 and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & "  union  select e.emp_code,  e.emp_name,  to_char(t.from_dt) as present_date,  to_char(r.from_dt) as past_date,  b.branch_name as present_branch,  b1.branch_name as past_branch,  d.dep_name as present_dep,  dm.dep_name as past_dep,  pm.post_name as past_post,  p.post_name as present_post,  to_char(t.enter_dt) as enter_date,  case when t.deputation_id=0 then fm.firm_abbr else fm1.firm_abbr end as curr_firm,  case when r.deputation_id=0 then fm.firm_abbr else fm2.firm_abbr end as past_firm  from employee_master     e left outer join  firm_master fm on (e.firm_id=fm.firm_id),  employ_transfer_dtl t left outer join  firm_master fm1 on (t.deputation_id=fm1.firm_id),  department_mst      d,  department_mst      dm,  post_mst           p,  post_mst            pm,  branch              b,  branch              b1, employ_transfer_dtl r left outer join  firm_master fm2 on (r.deputation_id=fm2.firm_id),employ_firm f  where e.emp_code = t.emp_code  and t.department_id = d.dep_id  and r.department_id = dm.dep_id and r.post_id = pm.post_id  and r.status_id = 1  and r.status_id not in (6, 10)  and t.post_id =p.post_id  and t.emp_code = r.emp_code  and to_date(r.to_dt) = to_date(t.from_dt)  and r.branch_id = b1.branch_id  and t.branch_id = b.branch_id  and to_date(t.enter_dt) between '" & Request.QueryString("fdt") & "' and  '" & Request.QueryString("tdt") & "'  and t.status_id =8 and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & "  order by emp_code, present_date").Tables(0)
            'dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,to_char(t.from_dt) as present_date,to_char(r.from_dt) as past_date,b.branch_name as present_branch,b1.branch_name as past_branch,d.dep_name as present_dep,dm.dep_name as past_dep,pm.post_name as past_post,p.post_name as present_post,to_char(t.enter_dt) as enter_date from employee_master  e, employ_firm ef,employ_transfer_dtl t,department_mst  d,department_mst  dm,post_mst  p,post_mst pm,branch b,branch b1,employ_transfer_dtl r where e.emp_code = t.emp_code and t.department_id = d.dep_id and r.department_id = dm.dep_id  and r.post_id = pm.post_id  and r.status_id in (1,8) and t.post_id = p.post_id and t.emp_code = r.emp_code and to_date(r.to_dt) = (to_date(t.from_dt)- 1) and r.branch_id = b1.branch_id and t.branch_id = b.branch_id and to_date(t.enter_dt) between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "' and t.status_id = 8 union select e.emp_code,e.emp_name,to_char(t.from_dt) as present_date,to_char(r.from_dt) as past_date,b.branch_name as present_branch,b1.branch_name as past_branch,d.dep_name as present_dep,dm.dep_name as past_dep,pm.post_name as past_post,p.post_name as present_post,to_char(t.enter_dt) as enter_date from employee_master  e, employ_firm ef,employ_transfer_dtl t,department_mst  d,department_mst  dm,post_mst  p,post_mst pm,branch b,branch b1,employ_transfer_dtl r where e.emp_code = t.emp_code and t.department_id = d.dep_id and r.department_id = dm.dep_id  and r.post_id = pm.post_id  and r.status_id=1 and r.status_id not in (6,10) and t.post_id = p.post_id and t.emp_code = r.emp_code and to_date(r.to_dt) = to_date(t.from_dt) and r.branch_id = b1.branch_id and t.branch_id = b.branch_id and to_date(t.enter_dt) between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "' and t.status_id = 8 order by emp_code,present_date").Tables(0)
        End If

        If (Request.QueryString("cat") = 2) Then
            dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,to_char(t.from_dt) as present_dt,to_char(r.from_dt) as past_dt,d.designation as present_des,dm.designation as past_des,t.basic_pay as persent_pay,r.basic_pay as past_pay,to_char(t.enter_dt) from employee_master e,employ_promotion_dtl t,designation_master d,designation_master dm,employ_promotion_dtl r,employ_firm f where e.emp_code = t.emp_code and t.designation_id = d.designation_id and r.designation_id = dm.designation_id  and t.emp_code = r.emp_code  and to_date(r.to_dt) =(to_date(t.from_dt)-1) and r.status_id in(1,11,7) and to_date(t.enter_dt) between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "' and t.status_id =7  and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " order by emp_code,present_dt").Tables(0)
            ' dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,to_char(t.from_dt) as present_dt,to_char(r.from_dt) as past_dt,d.designation as present_des,dm.designation as past_des,t.basic_pay as persent_pay,r.basic_pay as past_pay,to_char(t.enter_dt) from employee_master e,employ_promotion_dtl t,designation_master d,designation_master dm,employ_promotion_dtl r where e.emp_code = t.emp_code and t.designation_id = d.designation_id and r.designation_id = dm.designation_id  and t.emp_code = r.emp_code  and to_date(r.to_dt) =(to_date(t.from_dt)-1) and r.status_id in(1,11,7) and to_date(t.enter_dt) between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "' and t.status_id =7 order by emp_code,present_dt").Tables(0)
        End If
        If (Request.QueryString("cat") = 3) Then
            dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,to_char(t.from_dt) as present_dt,to_char(r.from_dt) as past_dt,d.designation as present_des,dm.designation as past_des,t.basic_pay as present_pay,r.basic_pay as past_pay,to_char(t.enter_dt) from employee_master e,employ_promotion_dtl t,designation_master d,designation_master dm,employ_promotion_dtl r,employ_firm f where e.emp_code=t.emp_code and t.designation_id=d.designation_id and r.designation_id=dm.designation_id and t.emp_code=r.emp_code and to_date(r.to_dt)=(to_date(t.from_dt)-1) and r.status_id in (1,7,11) and  to_date(t.enter_dt) between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "' and t.status_id=11  and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & "  order by emp_code,present_dt").Tables(0)
        End If


        If (Request.QueryString("cat") = 1) Then
            Dim tb As New Table
            tb.Attributes.Add("width", "100%")
            tb.Attributes.Add("border", "")

            tb.Attributes.Add("align", "center")

            Dim tr4 As New TableRow
            tr4.BackColor = Drawing.Color.Gold
            Dim tc14 As New TableCell
            tc14.ColumnSpan = 50
            tc14.HorizontalAlign = HorizontalAlign.Center
            'tc14.Text = "<font size=5 color=red><b>MANAPPURAM GROUP OF COMPANIES</b></font>" @
            tc14.Text = "<font size=5 color=red><b> " & Me.Session("firm_name") & " </b></font>"

            tr4.Cells.Add(tc14)
            tb.Controls.Add(tr4)
            'dt1 = oh.ExecuteDataSet("select emp_name,emp_code from employee_master where emp_code=" & Request.QueryString("emp") & " ").Tables(0)

            Dim tr5 As New TableRow
            tr5.BackColor = Drawing.Color.FloralWhite
            Dim tc15 As New TableCell
            tc15.ColumnSpan = 50
            tc15.HorizontalAlign = HorizontalAlign.Center
            Dim rep As String

            If (Request.QueryString("cat") = 1) Then
                rep = "TRANSFER"
            End If
            If (Request.QueryString("cat") = 2) Then
                rep = "PROMOTION"
            End If
            If (Request.QueryString("cat") = 3) Then
                rep = "INCREMENT"
            End If
            tc15.Text = "<MARQUEE  bgColor=snow><STRONG><FONT color=navy><b>DAILY " & rep & " REPORT - " & rep & "  ENTERED BETWEEN  " & Request.QueryString("fdt") & " and  " & Request.QueryString("tdt") & " </b></FONT></STRONG></MARQUEE>"
            tr5.Cells.Add(tc15)
            tb.Controls.Add(tr5)


            Dim tr6 As New TableRow
            tr6.BackColor = Drawing.Color.FloralWhite
            Dim tc16 As New TableCell
            tc16.Attributes.Add("width", "50%")
            tc16.ColumnSpan = 25
            tc16.HorizontalAlign = HorizontalAlign.Left
            tc16.BorderWidth = 0
            tc16.Text = "<font size=2 color=darkblue>Date&nbsp:" & Format(Date.Now, "dd/MMM/yyyy") & "</font>"
            tr6.Cells.Add(tc16)


            Dim tc17 As New TableCell
            tc17.Attributes.Add("width", "50%")
            tc17.ColumnSpan = 25
            tc17.BorderWidth = 0
            tc17.HorizontalAlign = HorizontalAlign.Right
            tc17.Text = "<font size=2 color=darkblue>Time&nbsp:" & Format(Date.Now, "hh:mm:ss") & "</font>"
            tr6.Cells.Add(tc17)
            tb.Controls.Add(tr6)


            Dim tr1 As New TableRow
            tr1.BackColor = Drawing.Color.Salmon
            Dim tc1 As New TableCell
            tc1.ColumnSpan = 1
            tc1.HorizontalAlign = HorizontalAlign.Left
            tc1.Text = "<font size=2><b>CODE</b></font>"
            tr1.Cells.Add(tc1)

            Dim tc2 As New TableCell
            tc2.ColumnSpan = 2
            tc2.HorizontalAlign = HorizontalAlign.Left
            tc2.Text = "<font size=2><b>EMPLOYEE NAME</b></font>"
            tr1.Cells.Add(tc2)

            Dim tc3 As New TableCell
            tc3.ColumnSpan = 8
            tc3.HorizontalAlign = HorizontalAlign.Left
            tc3.Text = "<font size=2><b>D.O.J&nbsp;(PRESENT)</b></font>"
            tr1.Cells.Add(tc3)

            Dim tc4 As New TableCell
            tc4.ColumnSpan = 8
            tc4.HorizontalAlign = HorizontalAlign.Left
            tc4.Text = "<font size=2><b>D.O.J&nbsp;(PAST)</b></font>"
            tr1.Cells.Add(tc4)

            Dim tc5 As New TableCell
            tc5.ColumnSpan = 8
            tc5.HorizontalAlign = HorizontalAlign.Left
            tc5.Text = "<font size=2><b>BRANCH(PRESENT)</b></font>"
            tr1.Cells.Add(tc5)

            Dim tc6 As New TableCell
            tc6.ColumnSpan = 15
            tc6.HorizontalAlign = HorizontalAlign.Left
            tc6.Text = "<font size=2><b>BRANCH(PAST)</b></font>"
            tr1.Cells.Add(tc6)

            Dim tc7 As New TableCell
            tc7.ColumnSpan = 1
            tc7.HorizontalAlign = HorizontalAlign.Left
            tc7.Text = "<font size=2><b>DEPARTMENT(PRESENT)</b></font>"
            tr1.Cells.Add(tc7)
            tb.Controls.Add(tr1)
            Dim tc8 As New TableCell
            tc8.ColumnSpan = 1
            tc8.HorizontalAlign = HorizontalAlign.Left
            tc8.Text = "<font size=2><b>DEPARTMENT(PAST)</b></font>"
            tr1.Cells.Add(tc8)
            tb.Controls.Add(tr1)

            Dim tc9 As New TableCell
            tc9.ColumnSpan = 1
            tc9.HorizontalAlign = HorizontalAlign.Left
            tc9.Text = "<font size=2><b>POST(PRESENT)</b></font>"
            tr1.Cells.Add(tc9)
            tb.Controls.Add(tr1)
            Dim tc10 As New TableCell
            tc10.ColumnSpan = 1
            tc10.HorizontalAlign = HorizontalAlign.Left
            tc10.Text = "<font size=2><b>POST(PAST)</b></font>"
            tr1.Cells.Add(tc10)
            tb.Controls.Add(tr1)

            Dim tc11 As New TableCell
            tc11.ColumnSpan = 1
            tc11.HorizontalAlign = HorizontalAlign.Left
            tc11.Text = "<font size=2><b>ENTER&nbsp;DATE</b></font>"
            tr1.Cells.Add(tc11)
            tb.Controls.Add(tr1)

            Dim tc12 As New TableCell
            tc12.ColumnSpan = 1
            tc12.HorizontalAlign = HorizontalAlign.Left
            tc12.Text = "<font size=2><b>FIRM(PRESENT)</b></font>"
            tr1.Cells.Add(tc12)
            tb.Controls.Add(tr1)

            Dim tc13 As New TableCell
            tc13.ColumnSpan = 1
            tc13.HorizontalAlign = HorizontalAlign.Left
            tc13.Text = "<font size=2><b>FIRM(PAST)</b></font>"
            tr1.Cells.Add(tc13)
            tb.Controls.Add(tr1)

            Dim dr As DataRow
            Dim color As Integer = 0

            For Each dr In dt.Rows
                Dim tr2 As New TableRow

                If (color = 0) Then
                    tr2.BackColor = Drawing.Color.WhiteSmoke
                    color = 1
                Else
                    tr2.BackColor = Drawing.Color.Snow
                    color = 0
                End If
                tr2.Attributes.Add("height", "25px")

                Dim tc18 As New TableCell
                tc18.ColumnSpan = 1
                tc18.HorizontalAlign = HorizontalAlign.Left
                tc18.Text = "<font size=2>" & dr(0) & "</font>"
                tc18.ForeColor = Drawing.Color.Black
                tr2.Cells.Add(tc18)


                Dim sd3 As String


                Dim tc19 As New TableCell
                tc19.ColumnSpan = 2
                tc19.HorizontalAlign = HorizontalAlign.Left
                tc19.Text = "<font size=2 color=blue>" & dr(1) & "</font>"
                ' tc19.ForeColor = Drawing.Color.Black
                tr2.Cells.Add(tc19)

                Dim tc20 As New TableCell
                tc20.ColumnSpan = 8
                tc20.HorizontalAlign = HorizontalAlign.Left

                tc20.Text = "<font size=2>" & dr(2) & "</font>"
                ' tc10.Text = dt.Rows(0)(0)
                tr2.Cells.Add(tc20)

                If IsDBNull(dr(3)) Then

                    sd3 = "---"
                    Dim tc21 As New TableCell
                    tc21.ColumnSpan = 8
                    tc21.HorizontalAlign = HorizontalAlign.Center
                    tc21.Text = "<font size=2 color=blue>" & sd3 & "</font>"
                    tr2.Cells.Add(tc21)
                    tb.Controls.Add(tr2)
                Else

                    sd3 = dr(3)
                    Dim tc21 As New TableCell
                    tc21.ColumnSpan = 8
                    tc21.HorizontalAlign = HorizontalAlign.Left
                    tc21.Text = "<font size=2 color=blue>" & sd3 & "</font>"
                    tr2.Cells.Add(tc21)
                    tb.Controls.Add(tr2)
                End If


                Dim tc22 As New TableCell
                tc22.ColumnSpan = 8
                tc22.HorizontalAlign = HorizontalAlign.Left
                tc22.Text = "<font size=2>" & dr(4) & "</font>"
                tr2.Cells.Add(tc22)
                tb.Controls.Add(tr2)

                Dim tc23 As New TableCell
                tc23.ColumnSpan = 15
                tc23.HorizontalAlign = HorizontalAlign.Left
                tc23.Text = "<font size=2 color=blue>" & dr(5) & "</font>"
                tr2.Cells.Add(tc23)
                tb.Controls.Add(tr2)

                Dim tc24 As New TableCell
                tc24.ColumnSpan = 1
                tc24.HorizontalAlign = HorizontalAlign.Left
                tc24.Text = "<font size=2>" & dr(6) & "</font>"
                tr2.Cells.Add(tc24)
                tb.Controls.Add(tr2)
                Dim tc25 As New TableCell
                tc25.ColumnSpan = 1
                tc25.HorizontalAlign = HorizontalAlign.Left
                tc25.Text = "<font size=2 color=blue>" & dr(7) & "</font>"
                tr2.Cells.Add(tc25)
                tb.Controls.Add(tr2)
                Dim tc26 As New TableCell
                tc26.ColumnSpan = 1
                tc26.HorizontalAlign = HorizontalAlign.Left
                tc26.Text = "<font size=2>" & dr(9) & "</font>"
                tr2.Cells.Add(tc26)
                tb.Controls.Add(tr2)
                Dim tc27 As New TableCell
                tc27.ColumnSpan = 1
                tc27.HorizontalAlign = HorizontalAlign.Left
                tc27.Text = "<font size=2 color=blue>" & dr(8) & "</font>"
                tr2.Cells.Add(tc27)
                tb.Controls.Add(tr2)
                Dim tc28 As New TableCell
                tc28.ColumnSpan = 1
                tc28.HorizontalAlign = HorizontalAlign.Left
                tc28.Text = "<font size=2 color=red>" & dr(10) & "</font>"
                tr2.Cells.Add(tc28)
                tb.Controls.Add(tr2)

                Dim tc29 As New TableCell
                tc29.ColumnSpan = 1
                tc29.HorizontalAlign = HorizontalAlign.Left
                tc29.Text = "<font size=2 color=blue>" & dr(11) & "</font>"
                tr2.Cells.Add(tc29)
                tb.Controls.Add(tr2)

                Dim tc30 As New TableCell
                tc30.ColumnSpan = 1
                tc30.HorizontalAlign = HorizontalAlign.Left
                tc30.Text = "<font size=2 color=red>" & dr(12) & "</font>"
                tr2.Cells.Add(tc30)
                tb.Controls.Add(tr2)
            Next


            Me.Panel1.Controls.Add(tb)

        End If
        If (Request.QueryString("cat") = 2 Or Request.QueryString("cat") = 3) Then
            Dim tb As New Table
            tb.Attributes.Add("width", "100%")
            tb.Attributes.Add("border", "")

            tb.Attributes.Add("align", "center")

            Dim tr4 As New TableRow
            tr4.BackColor = Drawing.Color.Gold
            Dim tc14 As New TableCell
            tc14.ColumnSpan = 50
            tc14.HorizontalAlign = HorizontalAlign.Center
            '   tc14.Text = "<font size=5 color=red><b>MANAPPURAM GROUP OF COMPANIES</b></font>"
            tc14.Text = "<font size=5 color=red><b> " & Me.Session("firm_name") & " </b></font>"
            tr4.Cells.Add(tc14)
            tb.Controls.Add(tr4)
            'dt1 = oh.ExecuteDataSet("select emp_name,emp_code from employee_master where emp_code=" & Request.QueryString("emp") & " ").Tables(0)

            Dim tr5 As New TableRow
            tr5.BackColor = Drawing.Color.FloralWhite
            Dim tc15 As New TableCell
            tc15.ColumnSpan = 50
            tc15.HorizontalAlign = HorizontalAlign.Center
            Dim rep As String

            If (Request.QueryString("cat") = 1) Then
                rep = "TRANSFER"
            End If
            If (Request.QueryString("cat") = 2) Then
                rep = "PROMOTION"
            End If
            If (Request.QueryString("cat") = 3) Then
                rep = "INCREMENT"
            End If
            tc15.Text = "<MARQUEE  bgColor=snow><STRONG><FONT color=navy><b>DAILY " & rep & " REPORT - " & rep & "  ENTERED BETWEEN  " & Request.QueryString("fdt") & " and  " & Request.QueryString("tdt") & " </b></FONT></STRONG></MARQUEE>"
            tr5.Cells.Add(tc15)
            tb.Controls.Add(tr5)


            Dim tr6 As New TableRow
            tr6.BackColor = Drawing.Color.FloralWhite
            Dim tc16 As New TableCell
            tc16.Attributes.Add("width", "50%")
            tc16.ColumnSpan = 25
            tc16.HorizontalAlign = HorizontalAlign.Left
            tc16.BorderWidth = 0
            tc16.Text = "<font size=2 color=darkblue>Date&nbsp:" & Format(Date.Now, "dd/MMM/yyyy") & "</font>"
            tr6.Cells.Add(tc16)


            Dim tc17 As New TableCell
            tc17.Attributes.Add("width", "50%")
            tc17.ColumnSpan = 25
            tc17.BorderWidth = 0
            tc17.HorizontalAlign = HorizontalAlign.Right
            tc17.Text = "<font size=2 color=darkblue>Time&nbsp:" & Format(Date.Now, "hh:mm:ss") & "</font>"
            tr6.Cells.Add(tc17)
            tb.Controls.Add(tr6)


            Dim tr1 As New TableRow
            tr1.BackColor = Drawing.Color.BlanchedAlmond
            Dim tc1 As New TableCell
            tc1.ColumnSpan = 1
            tc1.HorizontalAlign = HorizontalAlign.Left
            tc1.Text = "<font size=2><b>CODE</b></font>"
            tr1.Cells.Add(tc1)

            Dim tc2 As New TableCell
            tc2.ColumnSpan = 2
            tc2.HorizontalAlign = HorizontalAlign.Left
            tc2.Text = "<font size=2><b>EMPLOYEE NAME</b></font>"
            tr1.Cells.Add(tc2)

            Dim tc3 As New TableCell
            tc3.ColumnSpan = 8
            tc3.HorizontalAlign = HorizontalAlign.Left
            tc3.Text = "<font size=2><b>D.O.J&nbsp;(PRESENT)</b></font>"
            tr1.Cells.Add(tc3)

            Dim tc4 As New TableCell
            tc4.ColumnSpan = 8
            tc4.HorizontalAlign = HorizontalAlign.Left
            tc4.Text = "<font size=2><b>D.O.J&nbsp;(PAST)</b></font>"
            tr1.Cells.Add(tc4)

            Dim tc5 As New TableCell
            tc5.ColumnSpan = 8
            tc5.HorizontalAlign = HorizontalAlign.Left
            tc5.Text = "<font size=2><b>DESIGNATION(PRESENT)</b></font>"
            tr1.Cells.Add(tc5)

            Dim tc6 As New TableCell
            tc6.ColumnSpan = 15
            tc6.HorizontalAlign = HorizontalAlign.Left
            tc6.Text = "<font size=2><b>DESIGNATION(PAST)</b></font>"
            tr1.Cells.Add(tc6)

            Dim tc7 As New TableCell
            tc7.ColumnSpan = 1
            tc7.HorizontalAlign = HorizontalAlign.Left
            tc7.Text = "<font size=2><b>BASICPAY(PRESENT)</b></font>"
            tr1.Cells.Add(tc7)
            tb.Controls.Add(tr1)
            Dim tc8 As New TableCell
            tc8.ColumnSpan = 1
            tc8.HorizontalAlign = HorizontalAlign.Left
            tc8.Text = "<font size=2><b>BASICPAY(PAST)</b></font>"
            tr1.Cells.Add(tc8)
            tb.Controls.Add(tr1)

            Dim tc9 As New TableCell
            tc9.ColumnSpan = 1
            tc9.HorizontalAlign = HorizontalAlign.Left
            tc9.Text = "<font size=2><b>ENTER&nbsp;DATE</b></font>"
            tr1.Cells.Add(tc9)
            tb.Controls.Add(tr1)

            Dim dr As DataRow
            Dim color As Integer = 0

            For Each dr In dt.Rows
                Dim tr2 As New TableRow

                If (color = 0) Then
                    tr2.BackColor = Drawing.Color.Snow
                    color = 1
                Else
                    tr2.BackColor = Drawing.Color.Azure
                    color = 0
                End If
                tr2.Attributes.Add("height", "25px")

                Dim tc18 As New TableCell
                tc18.ColumnSpan = 1
                tc18.HorizontalAlign = HorizontalAlign.Left
                tc18.Text = "<font size=2>" & dr(0) & "</font>"
                tc18.ForeColor = Drawing.Color.Black
                tr2.Cells.Add(tc18)


                Dim sd3 As String


                Dim tc19 As New TableCell
                tc19.ColumnSpan = 2
                tc19.HorizontalAlign = HorizontalAlign.Left
                tc19.Text = "<font size=2 color=blue>" & dr(1) & "</font>"
                ' tc19.ForeColor = Drawing.Color.Black
                tr2.Cells.Add(tc19)

                Dim tc20 As New TableCell
                tc20.ColumnSpan = 8
                tc20.HorizontalAlign = HorizontalAlign.Left

                tc20.Text = "<font size=2>" & dr(2) & "</font>"
                ' tc10.Text = dt.Rows(0)(0)
                tr2.Cells.Add(tc20)

                If IsDBNull(dr(3)) Then

                    sd3 = "---"
                    Dim tc21 As New TableCell
                    tc21.ColumnSpan = 8
                    tc21.HorizontalAlign = HorizontalAlign.Center
                    tc21.Text = "<font size=2 color=blue>" & sd3 & "</font>"
                    tr2.Cells.Add(tc21)
                    tb.Controls.Add(tr2)
                Else

                    sd3 = dr(3)
                    Dim tc21 As New TableCell
                    tc21.ColumnSpan = 8
                    tc21.HorizontalAlign = HorizontalAlign.Left
                    tc21.Text = "<font size=2 color=blue>" & sd3 & "</font>"
                    tr2.Cells.Add(tc21)
                    tb.Controls.Add(tr2)
                End If


                Dim tc22 As New TableCell
                tc22.ColumnSpan = 8
                tc22.HorizontalAlign = HorizontalAlign.Left
                tc22.Text = "<font size=2>" & dr(4) & "</font>"
                tr2.Cells.Add(tc22)
                tb.Controls.Add(tr2)

                Dim tc23 As New TableCell
                tc23.ColumnSpan = 15
                tc23.HorizontalAlign = HorizontalAlign.Left
                tc23.Text = "<font size=2 color=blue>" & dr(5) & "</font>"
                tr2.Cells.Add(tc23)
                tb.Controls.Add(tr2)

                Dim tc24 As New TableCell
                tc24.ColumnSpan = 1
                tc24.HorizontalAlign = HorizontalAlign.Left
                tc24.Text = "<font size=2>" & dr(6) & "</font>"
                tr2.Cells.Add(tc24)
                tb.Controls.Add(tr2)
                Dim tc25 As New TableCell
                tc25.ColumnSpan = 1
                tc25.HorizontalAlign = HorizontalAlign.Left
                tc25.Text = "<font size=2 color=blue>" & dr(7) & "</font>"
                tr2.Cells.Add(tc25)
                tb.Controls.Add(tr2)

                Dim tc28 As New TableCell
                tc28.ColumnSpan = 1
                tc28.HorizontalAlign = HorizontalAlign.Left
                tc28.Text = "<font size=2 color=red>" & dr(8) & "</font>"
                tr2.Cells.Add(tc28)
                tb.Controls.Add(tr2)

            Next


            Me.Panel1.Controls.Add(tb)

        End If
    End Sub
End Class
