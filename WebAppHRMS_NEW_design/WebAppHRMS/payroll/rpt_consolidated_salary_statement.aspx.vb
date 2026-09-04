Imports System.Data
Imports System.Data.OracleClient

Partial Class salary_report_rpt_consolidated_salary_statement_f5a8d3141275
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

        'Dim dt As DataTable = oh.ExecuteDataSet("select m.emp_code,m.name,m.gross_sal,m.p_fund,m.lic,m.tds,m.p_tax,m.esi+m.s_w_fund+m.l_w_fund+m.rdded_amt  as other_ded,m.tot_dedu,m.net_pay,0 as bonus from m_wage m where m.emp_code not in(select emp_code from hrm_bonus_dtl) union select m.emp_code,m.name,m.gross_sal,m.p_fund,m.lic,m.tds,m.p_tax,m.esi+m.s_w_fund+m.l_w_fund+m.rdded_amt  as other_ded,m.tot_dedu,m.net_pay,case when h.bonus>0 then h.bonus else h.exgratia end as bonus from m_wage m,hrm_bonus_dtl h where m.emp_code=h.emp_code order by emp_code").Tables(0)
        Dim dt As DataTable = oh.ExecuteDataSet("select m.emp_code,m.name,m.gross_sal,m.p_fund,m.lic,m.tds,m.p_tax,m.esi+m.s_w_fund+m.l_w_fund+m.rdded_amt  as other_ded,m.tot_dedu,m.net_pay,0 as bonus from m_wage m,employ_firm ef where m.emp_code not in(select emp_code from hrm_bonus_dtl)  and m.emp_code = ef.emp_code  and ef.firm_id = '" & Session("firm_id") & "' union select m.emp_code,m.name,m.gross_sal,m.p_fund,m.lic,m.tds,m.p_tax,m.esi+m.s_w_fund+m.l_w_fund+m.rdded_amt  as other_ded,m.tot_dedu,m.net_pay,case when h.bonus>0 then h.bonus else h.exgratia end as bonus from m_wage m,hrm_bonus_dtl h,employ_firm ef where m.emp_code=h.emp_code  and ef.emp_code = m.emp_code and  ef.firm_id = '" & Session("firm_id") & "' order by emp_code").Tables(0)
        'table declaration
        Dim tab1 As New Table
        tab1.Attributes.Add("width", "100%")
        'tab1.BorderStyle = BorderStyle.Solid
        '1st row declaration
        Dim tabr1 As New TableRow
        tabr1.Width = 13
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.Attributes.Add("bordercolor", "red")
        'cell declaration
        Dim tabc1 As New TableCell
        tabc1.Attributes.Add("forecolor", "blue")
        tabc1.Attributes.Add("align", "center")
        tabc1.ColumnSpan = 13
        '   tabc1.Text = "<body align=center ><b><font size=4>MANAPPURAM GROUP OF COMPANIES</font></b></body>"
        tabc1.Text = "<body align=center ><b><font size=4>'" & Session("firm_name") & "'</font></b></body>"

        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab1.Controls.Add(tabr1)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Width = 13
        'cell declaration
        Dim tabc2 As New TableCell
        tabc2.ColumnSpan = 13
        tabc2.Attributes.Add("align", "center")
        Dim MinCode As Integer = oh.ExecuteDataSet("select min(emp_code) FROM M_WAGE").Tables(0).Rows(0)(0)
        Dim salDt As String = oh.ExecuteDataSet("select to_char(sal_dt,'MONTH - yyyy') from m_wage where emp_code = " & MinCode).Tables(0).Rows(0)(0)
        'Dim dtq As DataTable = oh.ExecuteDataSet("select distinct to_char(to_date(sal_dt),'MONTH') from salari").Tables(0)
        tabc2.Text = "<body align=center color=red><b><font size=3.5> CONSOLIDATED SALARY STATEMENT FOR THE MONTH -  " & salDt & "</font></b></body>"
   
        tabc2.ForeColor = Drawing.Color.Maroon
        tabr2.Controls.Add(tabc2)
        tab1.Controls.Add(tabr2)
        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Attributes.Add("bgcolor", "#ffcca3")

        'cell declaration
        Dim tabcc3 As New TableCell
        tabcc3.ColumnSpan = 7
        tabcc3.Attributes.Add("align", "left")
        tabcc3.Text = "<b><font size=3.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
        tabcc3.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc3)
        tab1.Controls.Add(tabrr3)
        'cell declaration
        Dim tabcc4 As New TableCell
        tabcc4.ColumnSpan = 6
        tabcc4.Attributes.Add("align", "right")
        tabcc4.Font.Bold = True
        tabcc4.Text = "<div id='txt'></div>"
        tabcc4.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc4)
        tab1.Controls.Add(tabrr3)

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabline As New TableRow
        tabline.Width = 13
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 13
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab1.Controls.Add(tabline)
        ''''''''''''''''''''''''''''''''''''''''
        Dim tabr5 As New TableRow
        tabr5.Width = 13
        tabr5.ForeColor = Drawing.Color.DarkRed
        Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7, tabr5c8, tabr5c9, tabr5c10, tabr5c11, tabr5c12 As New TableCell

        tabr5c1.ColumnSpan = "1"
        tabr5c2.ColumnSpan = "1"
        tabr5c3.ColumnSpan = "2"
        tabr5c4.ColumnSpan = "1"
        tabr5c5.ColumnSpan = "1"
        tabr5c6.ColumnSpan = "1"
        tabr5c7.ColumnSpan = "1"
        tabr5c8.ColumnSpan = "1"
        tabr5c9.ColumnSpan = "1"
        tabr5c10.ColumnSpan = "1"
        tabr5c11.ColumnSpan = "1"
        tabr5c12.ColumnSpan = "1"

        tabr5c1.HorizontalAlign = HorizontalAlign.Center
        tabr5c2.HorizontalAlign = HorizontalAlign.Left
        tabr5c5.HorizontalAlign = HorizontalAlign.Left
        tabr5c6.HorizontalAlign = HorizontalAlign.Left
        tabr5c3.HorizontalAlign = HorizontalAlign.Left
        tabr5c4.HorizontalAlign = HorizontalAlign.Left
        tabr5c7.HorizontalAlign = HorizontalAlign.Left
        tabr5c8.HorizontalAlign = HorizontalAlign.Left
        tabr5c9.HorizontalAlign = HorizontalAlign.Left
        tabr5c10.HorizontalAlign = HorizontalAlign.Left
        tabr5c11.HorizontalAlign = HorizontalAlign.Left
        tabr5c12.HorizontalAlign = HorizontalAlign.Left

        tabr5c1.Text = "<b><font size=2.5>SI.NO</font></b>"
        tabr5c2.Text = "<b><font size=2.5>EMP.CODE</font></b>"
        tabr5c3.Text = "<b><font size=2.5>NAME</font></b>"
        tabr5c4.Text = "<b><font size=2.5>SALARY</font></b>"
        tabr5c5.Text = "<b><font size=2.5>&nbsp;&nbsp;&nbsp;PF</font></b>"
        tabr5c6.Text = "<b><font size=2.5>LIC</font></b>"
        tabr5c7.Text = "<b><font size=2.5>&nbsp;TDS</font></b>"
        tabr5c8.Text = "<b><font size=2.5>P_TAX&nbsp;&nbsp;&nbsp;</font></b>"
        tabr5c9.Text = "<b><font size=2.5>ESI+SWF +LWF+RD&nbsp;&nbsp;</font></b>"
        tabr5c10.Text = "<b><font size=2.5>TOTAL DED</font></b>"
        tabr5c11.Text = "<b><font size=2.5>NET PAY</font></b>"
        tabr5c12.Text = "<b><font size=2.5>BONUS /&nbsp; EXGRATIA</font></b>"


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
        tabr5.Controls.Add(tabr5c12)

        tab1.Controls.Add(tabr5)
        '''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 13
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 13
        tabcellline1.Text = "<hr>"
        tabline1.Controls.Add(tabcellline1)
        tab1.Controls.Add(tabline1)
        '''''''''''''''''''''''''''''''''
        If dt.Rows.Count > 0 Then

            Dim colors As String
            colors = "#fff7ff"
            Dim dr As DataRow
            Dim m As Integer = 0
            For Each dr In dt.Rows
                m = m + 1
                If colors.Equals("#fff7ff") = True Then
                    colors = "#eef9ff"
                Else
                    colors = "#fff7ff"
                End If
                Dim tabr6 As New TableRow
                tabr6.Width = 13
                tabr6.Attributes.Add("bgcolor", colors)
                Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7, tabr6c8, tabr6c9, tabr6c10, tabr6c11, tabr6c12 As New TableCell

                tabr6c1.ColumnSpan = "1"
                tabr6c2.ColumnSpan = "1"
                tabr6c3.ColumnSpan = "2"
                tabr6c4.ColumnSpan = "1"
                tabr6c5.ColumnSpan = "1"
                tabr6c6.ColumnSpan = "1"
                tabr6c7.ColumnSpan = "1"
                tabr6c8.ColumnSpan = "1"
                tabr6c9.ColumnSpan = "1"
                tabr6c10.ColumnSpan = "1"
                tabr6c11.ColumnSpan = "1"
                tabr6c12.ColumnSpan = "1"

                tabr6c1.Attributes.Add("align", "center")
                tabr6c2.Attributes.Add("align", "left")
                tabr6c3.Attributes.Add("align", "left")
                tabr6c4.Attributes.Add("align", "Right")
                tabr6c5.Attributes.Add("align", "Right")
                tabr6c6.Attributes.Add("align", "Right")
                tabr6c7.Attributes.Add("align", "Right")
                tabr6c8.Attributes.Add("align", "Right")
                tabr6c9.Attributes.Add("align", "Right")
                tabr6c10.Attributes.Add("align", "Right")
                tabr6c11.Attributes.Add("align", "Right")
                tabr6c12.Attributes.Add("align", "Right")

                tabr6c1.Text = "<font size=2>" & m & "</font>"
                tabr6c2.Text = "<font size=2>" & dr(0) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c3.Text = "<font size=2>" & dr(1) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c4.Text = "<font size=2>" & dr(2) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c5.Text = "<font size=2>" & dr(3) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c6.Text = "<font size=2>" & dr(4) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c7.Text = "<font size=2>" & dr(5) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c8.Text = "<font size=2>" & dr(6) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c9.Text = "<font size=2>" & dr(7) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c10.Text = "<font size=2>" & dr(8) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c11.Text = "<font size=2>" & dr(9) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c12.Text = "<font size=2>" & dr(10) & "&nbsp;&nbsp;&nbsp;</font>"

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
                tabr6.Controls.Add(tabr6c12)

                tab1.Controls.Add(tabr6)


            Next
        End If
        Me.Panel1.Controls.Add(tab1)
    End Sub
End Class
