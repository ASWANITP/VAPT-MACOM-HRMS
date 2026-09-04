Imports System.Data
Imports System.Data.OracleClient

Partial Class salary_report_sal_wage_rpt_9fa947724508
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper
    Dim colors, firm As String
    Dim s As String
    Dim sy As Integer = 0
    Dim sdt As String
    Dim dr As DataRow
    Dim fir, fmid As Integer
    Dim dt, dt1 As New DataTable
    Dim str_tkn As New System.Text.StringBuilder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fir = Session("firm_id")
        firm = Session("firm_name")
        Dim user() As String
        Dim dtacc As New DataTable
        Dim brdt As New DataTable
        s = Request.QueryString("code")

        dt = oh.ExecuteDataSet("select to_char(h.from_dt),nvl(to_char(h.to_date),'-'),upper(am.all_name),h.amount from employee_master e, employ_firm ef inner join hrm_ta_employees h on h.emp_code=ef.emp_code inner join incentives_allowances_master am on am.all_id=h.all_id where ef.emp_code = e.emp_code and e.emp_code =" & s & "  order by h.from_dt").Tables(0)
        If dt.Rows.Count < 0 Then
            If dt.Rows(0)(0) = 0 Then
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('No AlLowance Found.') ;")
                cl_script.Append(" window.open('../../Home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script.ToString, True)
                Exit Sub
            End If
        End If

        'user = Session("user_id").ToString.Split("!")
        'dt1 = oh.ExecuteDataSet("select ef.firm_id from employee_master e,employ_firm ef where ef.emp_code=e.emp_code and e.emp_code=" & user(0) & "").Tables(0)
        'fmid = dt1.Rows(0)(0)
        'If fir <> fmid Then
        '    str_tkn.Append("         alert('Invalid Employee Code...!');")
        '    str_tkn.Append(" window.open('../../Home.aspx','_self');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        '    Exit Sub
        'End If

        If Me.Session("user_id") = "" Then
            Dim cl_script1 As New StringBuilder
            cl_script1.Append(" alert('Please Login again and Retry....!! ');")
            cl_script1.Append("    window.open('../../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)
            Exit Sub
        End If
        Panel1.Visible = False
        Panel2.Visible = True
        Dim tab As New Table
        tab.Attributes.Add("width", "100%")
        tab.Attributes.Add("border", 1)

        Dim tabr1 As New TableRow
        'tabr1.Width = 20
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.BorderStyle = BorderStyle.Solid
        tabr1.BorderColor = Drawing.Color.Red
        Dim tabc1 As New TableCell
        tabc1.ColumnSpan = 240
        tabc1.Text = "<body align=center color=red><b><font size=4>MANAPPURAM COMPTECH AND CONSULTANTS LIMITED</font></b></body>"
        tabc1.ForeColor = Drawing.Color.Red
        tabc1.Attributes.Add("align", "center")
        tabr1.Controls.Add(tabc1)
        tab.Controls.Add(tabr1)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabr2 As New TableRow
        'tabr2.Attributes.Add("bgcolor", "bisque")
        tabr2.ForeColor = Drawing.Color.Maroon
        Dim tabc2 As New TableCell
        tabc2.ColumnSpan = 240
        tabc2.HorizontalAlign = HorizontalAlign.Center
        tabc2.ForeColor = Drawing.Color.Brown
        'sdt = oh.ExecuteDataSet("select to_char(sal_dt,'MONTH - yyyy') from m_wage where emp_code=" & user(0)).Tables(0).Rows(0)(0)
        'If sdt <> "" Then
        's = sdt
        'Else

        'End If
        Dim dt1s As DataTable = oh.ExecuteDataSet("select e.emp_name from employee_master e,employ_firm ef where ef.emp_code=e.emp_code and e.emp_code=" & s & "").Tables(0)
        tabc2.Text = "<body align=center color=red><b><font size=3.5> ALLOWANCE SPLIT-UP OF EMPLOYEE " & s & "(" & dt1s.Rows(0)(0) & ") </font></b></body>"
        tabr2.Controls.Add(tabc2)
        tab.Controls.Add(tabr2)


        Dim tabr3 As New TableRow
        'tabr3.Width = 20
        'tabr3.Attributes.Add("bgcolor", "#ffcca3")
        Dim tabc3 As New TableCell
        tabc3.Attributes.Add("border-right", "none")
        tabc3.BorderStyle = BorderStyle.None
        tabc3.ColumnSpan = 120
        tabc3.HorizontalAlign = HorizontalAlign.Left
        tabc3.ForeColor = Drawing.Color.Maroon
        tabc3.Text = "<b><font size=3.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
        tabr3.Controls.Add(tabc3)
        tab.Controls.Add(tabr3)



        Dim tabc4 As New TableCell
        tabc4.Attributes.Add("width", "50%")
        tabc4.HorizontalAlign = HorizontalAlign.Right
        tabc4.Attributes.Add("border-left", "none")
        tabc4.BorderStyle = BorderStyle.None
        tabc4.ColumnSpan = 120
        tabc4.ForeColor = Drawing.Color.Maroon
        tabc4.Font.Bold = True
        tabc4.Text = "<div id='txt'></div>"

        tabr3.Controls.Add(tabc4)
        tab.Controls.Add(tabr3)

        Dim tabr3v As New TableRow
        'tabr3v.Width = 40
        tabr3v.Attributes.Add("bgcolor", "#ffcca3")
        Dim tabc3v As New TableCell
        tabc3v.ColumnSpan = 60
        tabc3v.HorizontalAlign = HorizontalAlign.Center
        tabc3v.ForeColor = Drawing.Color.Maroon
        tabc3v.Text = "<b><font size=3.5>FROM</font></b>"
        tabr3v.Controls.Add(tabc3v)
        tab.Controls.Add(tabr3v)

        Dim tabc3v1 As New TableCell
        tabc3v1.ColumnSpan = 60
        tabc3v1.HorizontalAlign = HorizontalAlign.Center
        tabc3v1.ForeColor = Drawing.Color.Maroon
        tabc3v1.Text = "<b><font size=3.5>TO</font></b>"
        tabr3v.Controls.Add(tabc3v1)
        tab.Controls.Add(tabr3v)

        Dim tabc3v2 As New TableCell
        tabc3v2.ColumnSpan = 60
        tabc3v2.HorizontalAlign = HorizontalAlign.Center
        tabc3v2.ForeColor = Drawing.Color.Maroon
        tabc3v2.Text = "<b><font size=3.5>ALLOWANCE/TA NAME</font></b>"
        tabr3v.Controls.Add(tabc3v2)
        tab.Controls.Add(tabr3v)


        Dim tabc4p As New TableCell
        tabc4p.Attributes.Add("width", "50%")
        tabc4p.HorizontalAlign = HorizontalAlign.Center
        tabc4p.ColumnSpan = 60
        tabc4p.ForeColor = Drawing.Color.Maroon
        tabc4p.Font.Bold = True
        tabc4p.Text = "<b><font size=3.5>AMOUNT</font></b>"
        tabr3v.Controls.Add(tabc4p)
        tab.Controls.Add(tabr3v)
        ''''''''''''''''VY

        For Each dr In dt.Rows

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tabr5 As New TableRow
            tabr5.Attributes.Add("bgcolor", "#ffff99")
            Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4 As New TableCell

            tabr5c1.Attributes.Add("align", "center")
            tabr5c2.Attributes.Add("align", "center")
            tabr5c3.Attributes.Add("align", "center")
            tabr5c4.Attributes.Add("align", "center")
            tabr5c1.ColumnSpan = 60
            tabr5c2.ColumnSpan = 60
            tabr5c3.ColumnSpan = 60
            tabr5c4.ColumnSpan = 60
            tabr5c1.Text = "<FONT SIZE=3>" & dr(0) & "</FONT>"
            tabr5c2.Text = "<FONT SIZE=3> " & dr(1) & "</FONT>"
            tabr5c3.Text = "<FONT SIZE=3>" & dr(2) & "</FONT>"
            tabr5c4.Text = "<FONT SIZE=3> " & dr(3) & "</FONT>"
            tabr5.Controls.Add(tabr5c1)
            tabr5.Controls.Add(tabr5c2)
            tabr5.Controls.Add(tabr5c3)
            tabr5.Controls.Add(tabr5c4)
            tab.Controls.Add(tabr5)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Next
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Dim tabline As New TableRow
        'tabline.Width = 20
        'Dim tabcellline As New TableCell
        'tabcellline.ColumnSpan = 20
        'tabcellline.Text = "<hr>"
        'tabline.Controls.Add(tabcellline)
        'tab.Controls.Add(tabline)
        'Dim dts2 As DataTable = oh.ExecuteDataSet("select nvl(SUM(alls.rd_amt),0),COUNT(alls.month) from (select m.emp_code, m.name, m.rdded_amt rd_amt, m.sal_dt sal, to_char(m.sal_dt,'MON/yyyy') month from mactech.m_wage m where m.emp_code = " & s & " union all select m.emp_code, m.name, m.rdded_amt rd_amt, m.sal_dt sal, to_char(m.sal_dt,'MON/yyyy') month from mactech.m_wage_his m where m.emp_code = " & s & " Order by sal) alls where alls.rd_amt > 0").Tables(0)
        '''''''''''VY

        'Dim tabr3v1 As New TableRow
        'tabr3v1.Width = 20
        'Dim tabc3v1 As New TableCell
        'tabc3v1.ColumnSpan = 10
        'tabc3v1.HorizontalAlign = HorizontalAlign.Left
        'tabc3v1.ForeColor = Drawing.Color.Maroon
        'tabc3v1.Text = "<b><font size=2>TOTAL MONTHS : " & dts2.Rows(0)(1) & " </font></b>"
        'tabr3v1.Controls.Add(tabc3v1)
        'tab.Controls.Add(tabr3v1)


        'Dim tabc4p1 As New TableCell
        'tabc4p1.Attributes.Add("width", "50%")
        'tabc4p1.HorizontalAlign = HorizontalAlign.Right
        'tabc4p1.ColumnSpan = 10
        'tabc4p1.ForeColor = Drawing.Color.Maroon
        'tabc4p1.Font.Bold = True
        'tabc4p1.Text = "<b><font size=2>TOTAL AMOUNT : " & dts2.Rows(0)(0) & "/-</font></b>"
        'tabr3v1.Controls.Add(tabc4p1)
        'tab.Controls.Add(tabr3v1)
        ''''''''''''''''VY

        Panel2.Controls.Add(tab)


        'End If

    End Sub

End Class
