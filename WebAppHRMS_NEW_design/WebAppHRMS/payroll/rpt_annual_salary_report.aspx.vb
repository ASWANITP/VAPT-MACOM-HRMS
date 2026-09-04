Imports System.Data
Imports System.Data.OracleClient

Partial Class salary_report_rpt_annual_salary_report_f0da9e172977
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim user() As String
        user = Session("user_id").ToString.Split("!")

        Dim pa As DataTable = oh.ExecuteDataSet("select parmtr_value from general_parameter where firm_id=1 and parmtr_id=28 and module_id=33").Tables(0)
        Dim sttt() As String = pa.Rows(0)(0).ToString.Split(",")

        Dim cn, i, j As New Integer
        cn = sttt.Length
        j = 0
        i = 0
        For j = 0 To cn - 1
            If sttt(j) = user(0) Then
                i = 1
                Exit For
            End If
        Next
        If i <> 1 Then
            Server.Transfer("../show_err.aspx")
        End If
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
        'Dim querry As String = "select emp_code,emp_name,sum(gross_sal),sum(p_fund),sum(lic),sum(tds),sum(p_tax),sum(other_ded) ,sum(tot_dedu),sum(net_pay) from (select m.emp_code as emp_code,e.emp_name as emp_name,m.sal_dt as dt,m.gross_sal,m.p_fund,m.lic,m.tds,m.p_tax,m.esi+m.s_w_fund+m.l_w_fund+m.rdded_amt  as other_ded,m.tot_dedu,m.net_pay from m_wage m,employee_master e where m.emp_code=e.emp_code and  m.sal_dt between '" & Format(CDate(datestring1), "dd/MMM/yyyy") & "' and '" & Format(CDate(datestring2), "dd/MMM/yyyy") & "' union select m.emp_code as emp_code, e.emp_name as emp_name,m.sal_dt as dt,m.gross_sal,m.p_fund,m.lic,m.tds,m.p_tax,m.esi+m.s_w_fund+m.l_w_fund+m.rdded_amt  as other_ded,m.tot_dedu,m.net_pay from m_wage_his m,employee_master e where m.emp_code=e.emp_code and  m.sal_dt between '" & Format(CDate(datestring1), "dd/MMM/yyyy") & "' and '" & Format(CDate(datestring2), "dd/MMM/yyyy") & "') group by emp_code,emp_name order by emp_code"
        Dim querry As String = "select emp_code,emp_name,sum(gross_sal),sum(p_fund),sum(lic),sum(tds),sum(p_tax),sum(other_ded) ,sum(tot_dedu),sum(net_pay) from (select m.emp_code as emp_code,e.emp_name as emp_name,m.sal_dt as dt,m.gross_sal,m.p_fund,m.lic,m.tds,m.p_tax,m.esi+m.s_w_fund+m.l_w_fund+m.rdded_amt  as other_ded,m.tot_dedu,m.net_pay from m_wage m,employee_master e,employ_firm ef where m.emp_code=e.emp_code and m.emp_code = ef.emp_code         and ef.firm_id = '" & Session("firm_id") & "' and  m.sal_dt between '" & Format(CDate(datestring1), "dd/MMM/yyyy") & "' and '" & Format(CDate(datestring2), "dd/MMM/yyyy") & "' union select m.emp_code as emp_code, e.emp_name as emp_name,m.sal_dt as dt,m.gross_sal,m.p_fund,m.lic,m.tds,m.p_tax,m.esi+m.s_w_fund+m.l_w_fund+m.rdded_amt  as other_ded,m.tot_dedu,m.net_pay from m_wage_his m,employee_master e,employ_firm ef where m.emp_code=e.emp_code and m.emp_code = ef.emp_code         and ef.firm_id = '" & Session("firm_id") & "' and  m.sal_dt between '" & Format(CDate(datestring1), "dd/MMM/yyyy") & "' and '" & Format(CDate(datestring2), "dd/MMM/yyyy") & "') group by emp_code,emp_name order by emp_code"

        dt = oh.ExecuteDataSet(querry).Tables(0)

        Dim tab1 As New Table
        tab1.Attributes.Add("width", "100%")
        'tab1.Attributes.Add("frame", "vsides")
        'tab1.Attributes.Add("border", "1")
        Dim tabr1 As New TableRow
        tabr1.Width = 12
        tabr1.BackColor = Drawing.Color.Gold
        tabr1.BorderColor = Drawing.Color.Red
        Dim tabc1 As New TableCell
        tabc1.ColumnSpan = 12
        ' tabc1.Text = "<body align=center color=red><b><font size=4>MANAPPURAM GROUP OF COMPANIES</font></b></body>"
        tabc1.Text = "<body align=center color=red><b><font size=4>'" & Session("firm_name") & "'</font></b></body>"
        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab1.Controls.Add(tabr1)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Width = 12
        tabr2.ForeColor = Drawing.Color.Maroon
        Dim tabc2 As New TableCell
        ' Dim s As String = oh.ExecuteDataSet("select month_name from month where month_id=" & Now.Month - 1).Tables(0).Rows(0)(0)

        tabc2.Text = "<body align=center><b> CONSOLIDATED SALARY STATEMENT FOR THE FINANCIAL YEAR " & yestring & "</b></body>"
        tabc2.ColumnSpan = 12
        tabr2.Controls.Add(tabc2)
        tab1.Controls.Add(tabr2)

        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Width = 12
        tabrr3.Attributes.Add("bgcolor", "#ffcca3")

        'cell declaration
        Dim tabcc3 As New TableCell
        tabcc3.Width = 12
        tabcc3.ForeColor = Drawing.Color.Maroon
        tabcc3.Attributes.Add("align", "left")
        tabcc3.Text = "<b><font size=2.5>DATE:" & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
        tabcc3.ColumnSpan = 6
        tabrr3.Controls.Add(tabcc3)
        tab1.Controls.Add(tabrr3)
        'cell declaration
        Dim tabcc4 As New TableCell
        tabcc4.ForeColor = Drawing.Color.Maroon
        tabcc4.Attributes.Add("align", "right")
        tabcc4.Font.Bold = True
        tabcc4.Font.Size = 10

        tabcc4.Text = "<div id='txt'></div>"
        tabcc4.ColumnSpan = 6
        tabrr3.Controls.Add(tabcc4)
        tab1.Controls.Add(tabrr3)

        Dim tabline As New TableRow
        tabline.Width = 12
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 12
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab1.Controls.Add(tabline)


        Dim tabr5 As New TableRow
        tabr5.Width = 12
        tabr5.ForeColor = Drawing.Color.DarkSlateGray
        Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7, tabr5c8, tabr5c9, tabr5c10, tabr5c11 As New TableCell

        tabr5c1.ColumnSpan = 1
        tabr5c2.ColumnSpan = 1
        tabr5c3.ColumnSpan = 2
        tabr5c4.ColumnSpan = 1
        tabr5c5.ColumnSpan = 1
        tabr5c6.ColumnSpan = 1
        tabr5c7.ColumnSpan = 1
        tabr5c8.ColumnSpan = 1
        tabr5c9.ColumnSpan = 1
        tabr5c10.ColumnSpan = 1
        tabr5c11.ColumnSpan = 1

        tabr5c1.Text = "<font size=2.5><b>SI.NO</b></font>"
        tabr5c2.Text = "<font size=2.5><b>EMP.CODE</b></font>"
        tabr5c3.Text = "<font size=2.5><b>EMP.NAME</b></font>"
        tabr5c4.Text = "<font size=2.5><b>SALARY</b></font>"
        tabr5c5.Text = "<font size=2.5><b>&nbsp;&nbsp;&nbsp;PF</b></font>"
        tabr5c6.Text = "<font size=2.5><b>LIC</b></font>"
        tabr5c7.Text = "<font size=2.5><b>&nbsp;TDS</b></font>"
        tabr5c8.Text = "<font size=2.5><b>P_TAX&nbsp;&nbsp;&nbsp;</b></font>"
        tabr5c9.Text = "<b><font size=2.5>ESI+SWF +LWF+RD&nbsp;&nbsp;</font></b>"
        tabr5c10.Text = "<b><font size=2.5>TOTAL DED</font></b>"
        tabr5c11.Text = "<b><font size=2.5>NET PAY</font></b>"

        tabr5.Controls.Add(tabr5c1)
        tabr5.Controls.Add(tabr5c2)
        tabr5.Controls.Add(tabr5c3)
        tabr5.Controls.Add(tabr5c4)
        tabr5.Controls.Add(tabr5c5)
        tabr5.Controls.Add(tabr5c6)
        tabr5.Controls.Add(tabr5c7)
        tabr5.Controls.Add(tabr5c8)
        tabr5.Controls.Add(tabr5c9)
        tabr5.Controls.Add(tabr5c10)
        tabr5.Controls.Add(tabr5c11)
        tab1.Controls.Add(tabr5)

        '''''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 12
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 12
        tabcellline1.Text = "<hr>"
        tabline1.Controls.Add(tabcellline1)
        tab1.Controls.Add(tabline1)

        '''''''''''''''''''''''''''''''''''''''''''

        Dim tot_sal, tot_pf, tot_lic, tot_tds, tot_otherded, tot_ded, tot_netpay As Double
        'data
        Dim colors As String = ""
        colors = "#fffcff"
        Dim dr As DataRow
        Dim count As Integer = 0
        For Each dr In dt.Rows
            count += 1
            If IsDBNull(dr(2)) = False Then
                tot_sal = tot_sal + dr(2)
            End If
            If IsDBNull(dr(3)) = False Then
                tot_pf = tot_pf + dr(3)
            End If
            If IsDBNull(dr(4)) = False Then
                tot_lic = tot_lic + dr(4)
            End If
            If IsDBNull(dr(5)) = False Then
                tot_tds = tot_tds + dr(5)
            End If
            If IsDBNull(dr(6)) = False Then
                tot_otherded = tot_otherded + dr(6)
            End If
            If IsDBNull(dr(7)) = False Then
                tot_ded = tot_ded + dr(7)
            End If
            If IsDBNull(dr(8)) = False Then
                tot_netpay = tot_netpay + dr(8)
            End If

            If colors.Equals("#fffcff") = True Then
                colors = "#f8f8f8"
            Else
                colors = "#fffcff"
            End If
            Dim tabr6 As New TableRow
            tabr6.Width = 12
            tabr6.Attributes.Add("bgcolor", colors)
            Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7, tabr6c8, tabr6c9, tabr6c10, tabr6c11 As New TableCell

            tabr6c1.ColumnSpan = 1
            tabr6c2.ColumnSpan = 1
            tabr6c3.ColumnSpan = 2
            tabr6c4.ColumnSpan = 1
            tabr6c5.ColumnSpan = 1
            tabr6c6.ColumnSpan = 1
            tabr6c7.ColumnSpan = 1
            tabr6c8.ColumnSpan = 1
            tabr6c9.ColumnSpan = 1
            tabr6c10.ColumnSpan = 1
            tabr6c11.ColumnSpan = 1

            tabr6c1.Attributes.Add("align", "center")
            tabr6c2.Attributes.Add("align", "left")
            tabr6c3.Attributes.Add("align", "left")
            tabr6c4.Attributes.Add("align", "right")
            tabr6c5.Attributes.Add("align", "right")
            tabr6c6.Attributes.Add("align", "right")
            tabr6c7.Attributes.Add("align", "right")
            tabr6c8.Attributes.Add("align", "right")
            tabr6c9.Attributes.Add("align", "right")
            tabr6c10.Attributes.Add("align", "right")
            tabr6c11.Attributes.Add("align", "right")

            'tabr5c1.Text = "<font size=2.5><b>SI.NO</b></font>"
            'tabr5c2.Text = "<font size=2.5><b>EMP.CODE</b></font>"
            'tabr5c3.Text = "<font size=2.5><b>EMP.NAME</b></font>"
            'tabr5c4.Text = "<font size=2.5><b>SALARY</b></font>"
            'tabr5c5.Text = "<font size=2.5><b&nbsp;&nbsp;&nbsp;PF</b></font>"
            'tabr5c6.Text = "<font size=2.5><b>LIC</b></font>"
            'tabr5c7.Text = "<font size=2.5><b>&nbsp;TDS</b></font>"
            'tabr5c8.Text = "<font size=2.5><b>P_TAX&nbsp;&nbsp;&nbsp;</b></font>"
            'tabr5c9.Text = "<b><font size=2.5>ESI+SWF +LWF+RD&nbsp;&nbsp;</font></b>"
            'tabr5c10.Text = "<b><font size=2.5>TOTAL DED</font></b>"
            'tabr5c11.Text = "<b><font size=2.5>NET PAY</font></b>"

            tabr6c1.Text = "<font size=2.5>" & count & "</font>"
            tabr6c2.Text = "<font size=2.5>" & dr(0) & "</font>"
            tabr6c3.Text = "<font size=2.5>" & dr(1) & "</font>"

            If IsDBNull(dr(2)) = True Then
                tabr6c4.Text = "<font size=2.5>" & dbnull(dr(2)) & "</font>"
            ElseIf dr(2) = 0 Then
                tabr6c4.Text = "<font size=2.5>" & dbnull(dr(2)) & "</font>"
            Else
                tabr6c4.Text = "<font size=2.5>" & dbnull(dr(2)) & "</font>"
            End If

            tabr6c5.Text = dbnull(dr(3))


            If IsDBNull(dr(4)) = True Then
                tabr6c6.Text = "<font size=2.5>" & dbnull(dr(4)) & "</font>"
            ElseIf dr(4) = 0 Then
                tabr6c6.Text = "<font size=2.5>" & dbnull(dr(4)) & "</font>"
            Else
                tabr6c6.Text = "<font size=2.5>" & dbnull(dr(4)) & "</font>"
            End If

            tabr6c7.Text = "<font size=2.5>" & dbnull(dr(5)) & "</font>"
            tabr6c8.Text = "<font size=2.5>" & dbnull(dr(6)) & "</font>"
            tabr6c9.Text = "<font size=2.5>" & dbnull(dr(7)) & "</font>"
            tabr6c10.Text = "<font size=2.5>" & dbnull(dr(8)) & "</font>"
            tabr6c11.Text = "<font size=2.5>" & dbnull(dr(9)) & "</font>"

            tabr6.Controls.Add(tabr6c1)
            tabr6.Controls.Add(tabr6c2)
            tabr6.Controls.Add(tabr6c3)
            tabr6.Controls.Add(tabr6c4)
            tabr6.Controls.Add(tabr6c5)
            tabr6.Controls.Add(tabr6c6)
            tabr6.Controls.Add(tabr6c7)
            tabr6.Controls.Add(tabr6c8)
            tabr6.Controls.Add(tabr6c9)
            tabr6.Controls.Add(tabr6c10)
            tabr6.Controls.Add(tabr6c11)

            tab1.Controls.Add(tabr6)
        Next

        Dim tabline2 As New TableRow
        tabline2.Width = 12
        Dim tabcellline2 As New TableCell
        tabcellline2.ColumnSpan = 12
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

        totrow.Width = 12
        totc1.ColumnSpan = 5
        totc2.ColumnSpan = 1
        totc3.ColumnSpan = 1
        totc4.ColumnSpan = 1
        totc5.ColumnSpan = 1
        totc6.ColumnSpan = 1
        totc7.ColumnSpan = 1
        totc8.ColumnSpan = 1

        totc1.Text = "<font size=2.5>TOTAL : </font>"
        totc2.Text = "<font size=2.5>" & tot_sal & "</font>"
        totc3.Text = "<font size=2.5>" & tot_pf & "</font>"
        totc4.Text = "<font size=2.5>" & tot_lic & "</font>"
        totc5.Text = "<b><u>" & tot_tds & "</b></u>"
        totc6.Text = "<font size=2.5>" & tot_otherded & "</font>"
        totc7.Text = "<font size=2.5>" & tot_ded & "</font>"
        totc8.Text = "<font size=2.5>" & tot_netpay & "</font>"

        totrow.Controls.Add(totc1)
        totrow.Controls.Add(totc2)
        totrow.Controls.Add(totc3)
        totrow.Controls.Add(totc4)
        totrow.Controls.Add(totc5)
        totrow.Controls.Add(totc7)
        totrow.Controls.Add(totc6)
        totrow.Controls.Add(totc8)

        tab1.Controls.Add(totrow)

        Me.Panel1.Controls.Add(tab1)

    End Sub

    Private Function dbnull(ByVal a) As String
        Dim a1 As Double

        If IsDBNull(a) Then
            Return 0
        Else
            a1 = a
            Return a
        End If
    End Function
End Class
