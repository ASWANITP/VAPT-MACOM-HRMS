Imports System.Data
Imports System.Data.OracleClient
Partial Class salary_report_rpt_individual_salary_report_c2017cea1504
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper
    Dim firmid As Integer



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        firmid = Session("firm_id")
        Dim dtsal As New DataTable
        dtsal = oh.ExecuteDataSet("select count(*) from hrm_salary_release t where t.firm_id=" & firmid & " ").Tables(0)
        If dtsal.Rows(0)(0) = 0 Then
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('Salary Not Released.') ;")
            cl_script.Append(" window.open('../Home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script.ToString, True)
            Exit Sub
        End If


        Dim user() As String
        user = Session("user_id").ToString.Split("!")

        Dim datestring1 As String = ""
        Dim datestring2 As String = ""
        Dim yestring As String = ""
        Dim sysdt As DataTable = oh.ExecuteDataSet("select to_char(sysdate,'MM'),to_char(sysdate,'YYYY') from dual").Tables(0)
        Dim ye As Integer = sysdt.Rows(0)(1)

        If sysdt.Rows(0)(0) > 3 Then
            yestring = ye & " - " & ye + 1
            datestring1 = "1/apr/" & ye
            datestring2 = "31 / mar / " & (ye + 1)

        Else
            yestring = ye - 1 & " - " & ye
            datestring1 = "1/apr/" & (ye - 1)
            datestring2 = " 31/mar/" & ye
        End If
        Dim dt As DataTable
        Dim querry As String = "select m.sal_dt as dt,nvl(m.wages_pble,0) as wages_payable,nvl(m.tot_dedu,0)+nvl(m.lop,0)as Total_deduction,nvl(m.wages_pble,0)-nvl(m.tot_dedu,0)-nvl(m.lop,0) as Salary_Payable,nvl(m.bonus,0) ,nvl(m.net_pay,0)+nvl(m.bonus,0) as salary_paid from m_wage m where m.emp_code=" & user(0) & " and m.sal_dt between '" & Format(CDate(datestring1), "dd/MMM/yyyy") & "' and '" & Format(CDate(datestring2), "dd/MMM/yyyy") & "' union select m.sal_dt as dt,nvl(m.wages_pble,0) as wages_payable,nvl(m.tot_dedu,0)+nvl(m.lop,0)as Total_deduction,nvl(m.wages_pble,0)-nvl(m.tot_dedu,0)-nvl(m.lop,0) as Salary_Payable,nvl(m.bonus,0) ,nvl(m.net_pay,0)+nvl(m.bonus,0) as salary_paid from m_wage_his m where m.emp_code=" & user(0) & " and m.sal_dt between '" & Format(CDate(datestring1), "dd/MMM/yyyy") & "' and '" & Format(CDate(datestring2), "dd/MMM/yyyy") & "' order by dt desc"

        dt = oh.ExecuteDataSet(querry).Tables(0)
        If dt.Rows.Count = 0 Then
            Dim script1 As New StringBuilder
            script1.Append("        alert('No Details Found');")
            script1.Append("window.open('rpt_individual_salary_report.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        Dim bonuscount As Integer = 0
        For k As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(k)(4) > 0 Then
                bonuscount = 1
                Exit For
            End If
        Next
        Dim tab1 As New Table
        tab1.Attributes.Add("width", "100%")
        Dim tabr1 As New TableRow
        tabr1.Width = 7
        tabr1.BackColor = Drawing.Color.Gold
        tabr1.BorderColor = Drawing.Color.Red
        Dim tabc1 As New TableCell
        tabc1.ColumnSpan = 7
        tabc1.Text = "<body align=center color=red><b><font size=4>" & Session("firm_name") & " </font></b></body>"
        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab1.Controls.Add(tabr1)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Width = 7
        tabr2.ForeColor = Drawing.Color.Maroon
        Dim tabc2 As New TableCell
        ' Dim s As String = oh.ExecuteDataSet("select month_name from month where month_id=" & Now.Month - 1).Tables(0).Rows(0)(0)

        tabc2.Text = "<body align=center><b> INDIVIDUAL SALARY STATEMENT " & yestring & "</b></body>"
        tabc2.ColumnSpan = 7
        tabr2.Controls.Add(tabc2)
        tab1.Controls.Add(tabr2)

        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Width = 7
        tabrr3.Attributes.Add("bgcolor", "#ffcca3")

        'cell declaration
        Dim tabcc3 As New TableCell
        tabcc3.Width = 7
        tabcc3.ForeColor = Drawing.Color.Maroon
        tabcc3.Attributes.Add("align", "left")
        tabcc3.Text = "<b><font size=2.5>DATE:" & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
        tabcc3.ColumnSpan = 4
        tabrr3.Controls.Add(tabcc3)
        tab1.Controls.Add(tabrr3)
        'cell declaration
        Dim tabcc4 As New TableCell
        tabcc4.ForeColor = Drawing.Color.Maroon
        tabcc4.Attributes.Add("align", "right")

        tabcc4.Font.Bold = True
        tabcc4.Font.Size = 10
        tabcc4.Text = "<div id='txt'></div>"
        tabcc4.ColumnSpan = 3
        tabrr3.Controls.Add(tabcc4)
        tab1.Controls.Add(tabrr3)

        Dim tabline As New TableRow
        tabline.Width = 7
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 7
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab1.Controls.Add(tabline)

        Dim dt1 As DataTable = oh.ExecuteDataSet("select e.emp_code,  e.emp_name,  br.branch_name,  f.firm_abbr,  d.designation,  e.join_dt,  decode(e.emp_type, 1, 'PERMANENT', 'OUTSOURCE') as emp_type,  s.remark  from employee_master    e,  branch_master      br,  firm_master        f,  designation_master d,  status_mst         s,  employ_firm ef  where e.branch_id = br.branch_id  and e.emp_code = ef.emp_code  and ef.firm_id=f.firm_id  and e.designation_id = d.designation_id  and e.status_id = s.status_id  and e.emp_code =" & user(0) & "  union  select e.emp_code,  e.emp_name,  bc.branch_name,  f.firm_abbr,  d.designation,  e.join_dt,  decode(e.emp_type, 1, 'PERMANENT', 'OUTSOURCE') as emp_type,  s.remark  from employee_master    e,  before_completion  bc,  firm_master        f,  designation_master d,  status_mst         s,  employ_firm ef  where e.branch_id = bc.old_id  and bc.branch_id is null  and e.emp_code = ef.emp_code  and ef.firm_id=f.firm_id  and e.designation_id = d.designation_id  and e.status_id = s.status_id  and e.emp_code = " & user(0)).Tables(0)
        If dt1.Rows.Count > 0 Then

            Dim r1 As New TableRow
            r1.Width = 7
            Dim k1, k2, k3, k4 As New TableCell
            k1.ColumnSpan = 1
            k2.ColumnSpan = 2
            k3.ColumnSpan = 1
            k4.ColumnSpan = 3
            k2.HorizontalAlign = HorizontalAlign.Left
            k4.HorizontalAlign = HorizontalAlign.Left
            k1.HorizontalAlign = HorizontalAlign.Left
            k3.HorizontalAlign = HorizontalAlign.Left
            k1.ForeColor = Drawing.Color.DarkBlue
            k2.ForeColor = Drawing.Color.DarkBlue
            k3.ForeColor = Drawing.Color.DarkBlue
            k4.ForeColor = Drawing.Color.DarkBlue

            k1.Text = "Emp Code "
            k2.Text = "<font size=2>&nbsp;&nbsp;&nbsp;- &nbsp;" & dt1.Rows(0)(0) & "</font>"
            k3.Text = "Emp Name "
            k4.Text = "<font size=2>- &nbsp; " & dt1.Rows(0)(1) & "</font>"
            r1.Controls.Add(k1)
            r1.Controls.Add(k2)
            r1.Controls.Add(k3)
            r1.Controls.Add(k4)
            tab1.Controls.Add(r1)

            Dim r2 As New TableRow
            r2.Width = 7
            Dim j1, j2, j3, j4 As New TableCell
            j1.ColumnSpan = 1
            j2.ColumnSpan = 2
            j3.ColumnSpan = 1
            j4.ColumnSpan = 3
            j2.HorizontalAlign = HorizontalAlign.Left
            j4.HorizontalAlign = HorizontalAlign.Left
            j1.HorizontalAlign = HorizontalAlign.Left
            j3.HorizontalAlign = HorizontalAlign.Left
            j1.ForeColor = Drawing.Color.DarkBlue
            j2.ForeColor = Drawing.Color.DarkBlue
            j3.ForeColor = Drawing.Color.DarkBlue
            j4.ForeColor = Drawing.Color.DarkBlue
            j1.Text = "Branch"
            j2.Text = "<font size=2>&nbsp;&nbsp;&nbsp;- &nbsp; " & dt1.Rows(0)(2) & "</font>"
            j3.Text = "Firm"
            j4.Text = "<font size=2>- &nbsp; " & dt1.Rows(0)(3) & "</font>"
            r2.Controls.Add(j1)
            r2.Controls.Add(j2)
            r2.Controls.Add(j3)
            r2.Controls.Add(j4)
            tab1.Controls.Add(r2)

            Dim r3 As New TableRow
            r3.Width = 7
            Dim n1, n2, n3, n4 As New TableCell
            n1.ColumnSpan = 1
            n2.ColumnSpan = 2
            n3.ColumnSpan = 1
            n4.ColumnSpan = 3
            n2.HorizontalAlign = HorizontalAlign.Left
            n4.HorizontalAlign = HorizontalAlign.Left
            n1.HorizontalAlign = HorizontalAlign.Left
            n3.HorizontalAlign = HorizontalAlign.Left
            n1.ForeColor = Drawing.Color.DarkBlue
            n2.ForeColor = Drawing.Color.DarkBlue
            n3.ForeColor = Drawing.Color.DarkBlue
            n4.ForeColor = Drawing.Color.DarkBlue
            n1.Text = "Designation"
            n2.Text = "<font size=2>&nbsp;&nbsp;&nbsp;- &nbsp; " & dt1.Rows(0)(4) & "</font>"
            n3.Text = "Join Date"
            n4.Text = "<font size=2>- &nbsp; " & Format(dt1.Rows(0)(5), "dd/MMM/yyyy") & "</font>"
            r3.Controls.Add(n1)
            r3.Controls.Add(n2)
            r3.Controls.Add(n3)
            r3.Controls.Add(n4)
            tab1.Controls.Add(r3)


            Dim r4 As New TableRow
            r4.Width = 7
            Dim b1, b2, b3, b4 As New TableCell
            b1.ColumnSpan = 1
            b2.ColumnSpan = 2
            b3.ColumnSpan = 1
            b4.ColumnSpan = 3
            b2.HorizontalAlign = HorizontalAlign.Left
            b4.HorizontalAlign = HorizontalAlign.Left
            b1.HorizontalAlign = HorizontalAlign.Left
            b3.HorizontalAlign = HorizontalAlign.Left
            b1.ForeColor = Drawing.Color.DarkBlue
            b2.ForeColor = Drawing.Color.DarkBlue
            b3.ForeColor = Drawing.Color.DarkBlue
            b4.ForeColor = Drawing.Color.DarkBlue
            b1.Text = "Emp Type"
            b2.Text = "<font size=2>&nbsp;&nbsp;&nbsp;- &nbsp; " & dt1.Rows(0)(6) & "</font>"
            b3.Text = "Status "
            b4.Text = "<font size=2>- &nbsp; " & dt1.Rows(0)(7) & "</font>"
            r4.Controls.Add(b1)
            r4.Controls.Add(b2)
            r4.Controls.Add(b3)
            r4.Controls.Add(b4)
            tab1.Controls.Add(r4)
            '5th row
        End If
        Dim tabline1w As New TableRow
        tabline1w.Width = 7
        Dim tabcellline1w As New TableCell
        tabcellline1w.ColumnSpan = 7
        tabcellline1w.Text = "&nbsp;&nbsp;&nbsp;&nbsp;"
        tabline1w.Controls.Add(tabcellline1w)
        tab1.Controls.Add(tabline1w)

        Dim tabr5 As New TableRow
        tabr5.Width = 8
        tabr5.ForeColor = Drawing.Color.DarkSlateGray
        Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7, tabr5c8 As New TableCell
        If bonuscount = 0 Then
            tabr5c1.Attributes.Add("width", "10%")
            tabr5c2.Attributes.Add("width", "20%")
            tabr5c3.Attributes.Add("width", "18%")
            tabr5c4.Attributes.Add("width", "16%")
            tabr5c5.Attributes.Add("width", "18%")
            tabr5c8.Attributes.Add("width", "18%")
        Else
            tabr5c1.Attributes.Add("width", "10%")
            tabr5c2.Attributes.Add("width", "16%")
            tabr5c3.Attributes.Add("width", "16%")
            tabr5c4.Attributes.Add("width", "15%")
            tabr5c5.Attributes.Add("width", "15%")
            tabr5c6.Attributes.Add("width", "14%")
            tabr5c8.Attributes.Add("width", "14%")
        End If
        tabr5c2.HorizontalAlign = HorizontalAlign.Left
        tabr5c1.Text = "<font size=2.5><b>SI.NO</b></font>"
        tabr5c2.Text = "<font size=2.5><b>SALARY DATE</b></font>"
        tabr5c3.Text = "<font size=2.5><b>WAGES PAYABLE</b></font>"
        tabr5c4.Text = "<font size=2.5><b>TOTAL DEDUCTION</b></font>"
        tabr5c5.Text = "<font size=2.5><b>SALARY PAYABLE</b></font>"
        tabr5c6.Text = "<font size=2.5><b>BONUS</b></font>"
        tabr5c8.Text = "<font size=2.5><b>SALARY PAID</b></font>"

        tabr5.Controls.Add(tabr5c1)
        tabr5.Controls.Add(tabr5c2)
        tabr5.Controls.Add(tabr5c3)
        tabr5.Controls.Add(tabr5c4)
        tabr5.Controls.Add(tabr5c5)
        If bonuscount > 0 Then
            tabr5.Controls.Add(tabr5c6)
        End If
        tabr5.Controls.Add(tabr5c8)

        tab1.Controls.Add(tabr5)

        '''''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 7
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 7
        tabcellline1.Text = "<hr>"
        tabline1.Controls.Add(tabcellline1)
        tab1.Controls.Add(tabline1)

        '''''''''''''''''''''''''''''''''''''''''''

        Dim tot_wagespayable, tot_deduction, tot_salarypayable, tot_otherdeduction, tot_salarypaid, tot_bonus As Double
        'data
        Dim colors As String = ""
        colors = "#fffcff"
        Dim dr As DataRow
        Dim count As Integer = 0
        For Each dr In dt.Rows
            count += 1
            If IsDBNull(dr(1)) = False Then
                tot_wagespayable = tot_wagespayable + dr(1)
            End If
            If IsDBNull(dr(2)) = False Then
                tot_deduction = tot_deduction + dr(2)
            End If
            If IsDBNull(dr(3)) = False Then
                tot_salarypayable = tot_salarypayable + dr(3)
            End If
            If IsDBNull(dr(5)) = False Then
                tot_salarypaid = tot_salarypaid + dr(5)
            End If
            If IsDBNull(dr(4)) = False Then
                tot_bonus = tot_bonus + dr(4)
            End If


            If colors.Equals("#fffcff") = True Then
                colors = "#f8f8f8"
            Else
                colors = "#fffcff"
            End If
            Dim tabr6 As New TableRow
            tabr6.Attributes.Add("bgcolor", colors)
            Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7, tabr6c8 As New TableCell

            tabr6c1.Attributes.Add("align", "center")
            tabr6c2.Attributes.Add("align", "left")
            tabr6c3.Attributes.Add("align", "right")
            tabr6c4.Attributes.Add("align", "right")
            tabr6c5.Attributes.Add("align", "right")
            tabr6c6.Attributes.Add("align", "right")
            tabr6c8.Attributes.Add("align", "right")

            tabr6c1.Text = count
            '  tabr6c2.Text = Format(CDate(dr(0)), "dd/MMM/yyyy")
            tabr6c2.Text = "<a href=rpt_linkto_monthly_wage.aspx?saldate=" & Format(CDate(dr(0)), "dd/MMM/yyyy") & ">" & Format(CDate(dr(0)), "dd/MMM/yyyy") & "</a>"

            If IsDBNull(dr(1)) = True Then
                tabr6c3.Text = dbnull(dr(1))
            ElseIf dr(1) = 0 Then
                tabr6c3.Text = dbnull(dr(1))
            Else
                tabr6c3.Text = dbnull(dr(1))
            End If

            tabr6c4.Text = dbnull(dr(2))


            If IsDBNull(dr(3)) = True Then
                tabr6c5.Text = dbnull(dr(3))
            ElseIf dr(3) = 0 Then
                tabr6c5.Text = dbnull(dr(3))
            Else
                tabr6c5.Text = dbnull(dr(3))
            End If

            If bonuscount = 1 Then
                tabr6c6.Text = dbnull(dr(4))
            End If
            tabr6c8.Text = dbnull(dr(5))

            tabr6.Controls.Add(tabr6c1)
            tabr6.Controls.Add(tabr6c2)
            tabr6.Controls.Add(tabr6c3)
            tabr6.Controls.Add(tabr6c4)
            tabr6.Controls.Add(tabr6c5)
            If bonuscount = 1 Then
                tabr6.Controls.Add(tabr6c6)
            End If
            tabr6.Controls.Add(tabr6c8)


            tabr6.Controls.Add(tabr6c8)
            tab1.Controls.Add(tabr6)
        Next

        Dim tabline2 As New TableRow
        tabline2.Width = 7
        Dim tabcellline2 As New TableCell
        tabcellline2.ColumnSpan = 7
        tabcellline2.Text = "<hr>"
        tabline2.Controls.Add(tabcellline2)
        tab1.Controls.Add(tabline2)


        Dim totrow As New TableRow
        Dim totc1, totc2, totc3, totc4, totc5, totc6, totc7, totc8 As New TableCell
        totc1.HorizontalAlign = HorizontalAlign.Center
        totc2.HorizontalAlign = HorizontalAlign.Right
        totc3.HorizontalAlign = HorizontalAlign.Right
        totc4.HorizontalAlign = HorizontalAlign.Right
        totc5.HorizontalAlign = HorizontalAlign.Right
        totc6.HorizontalAlign = HorizontalAlign.Right
        totc7.HorizontalAlign = HorizontalAlign.Right
        totc8.HorizontalAlign = HorizontalAlign.Right

        totc1.ForeColor = Drawing.Color.Red
        totc2.ForeColor = Drawing.Color.Red
        totc3.ForeColor = Drawing.Color.Red
        totc4.ForeColor = Drawing.Color.Red
        totc5.ForeColor = Drawing.Color.Red
        totc6.ForeColor = Drawing.Color.Red
        totc7.ForeColor = Drawing.Color.Red
        totc8.ForeColor = Drawing.Color.Red
        If bonuscount = 0 Then
            totrow.Width = 7
            totc1.ColumnSpan = 2
            totc2.ColumnSpan = 1
            totc3.ColumnSpan = 1
            totc4.ColumnSpan = 1
            ' totc5.ColumnSpan = 1
            totc6.ColumnSpan = 1
        Else
            totrow.Width = 8
            totc1.ColumnSpan = 2
            totc2.ColumnSpan = 1
            totc3.ColumnSpan = 1
            totc4.ColumnSpan = 1
            'totc5.ColumnSpan = 1
            totc6.ColumnSpan = 1
            totc7.ColumnSpan = 1
        End If

        totc1.Text = "TOTAL  :"
        totc2.Text = "<b><u>" & FormatNumber(tot_wagespayable, 2) & "</b></u>"
        totc3.Text = "<b><u>" & FormatNumber(tot_deduction, 2) & "</b></u>"
        totc4.Text = "<b><u>" & FormatNumber(tot_salarypayable, 2) & "</b></u>"
        ' totc5.Text = "<b><u>" & FormatNumber(tot_otherdeduction, 2) & "</b></u>"
        totc6.Text = "<b><u>" & FormatNumber(tot_salarypaid, 2) & "</b></u>"
        totc7.Text = "<b><u>" & FormatNumber(tot_bonus, 2) & "</b></u>"

        totrow.Controls.Add(totc1)
        totrow.Controls.Add(totc2)
        totrow.Controls.Add(totc3)
        totrow.Controls.Add(totc4)
        'totrow.Controls.Add(totc5)
        If bonuscount = 1 Then
            totrow.Controls.Add(totc7)
        End If
        totrow.Controls.Add(totc6)
        ' totrow.Controls.Add(totc7)
        tab1.Controls.Add(totrow)

        Me.Panel1.Controls.Add(tab1)

    End Sub
    Private Function dbnull(ByVal a) As String
        Dim a1 As Double

        If IsDBNull(a) Then
            Return 0
        Else
            a1 = FormatNumber(a, 2)
            Return FormatNumber(a, 2)
        End If
    End Function
End Class
