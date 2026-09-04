Imports System.Data
Imports System.Data.OracleClient
Partial Class PF_REPORT_PF_statement_d67dd5c97951
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sql As String = ""
        Dim dtstd As String = Me.Request.QueryString("dt")
        Dim m As Integer = CDate(dtstd).Month
        Dim y As Integer = CDate(dtstd).Year
        If m = 1 Then
            m = 12
            y = y - 1
        Else
            m = m - 1
        End If
        Dim dtst As Date
        dtst = CDate(MonthName(m, True).ToUpper & "/" & y)

        Dim dtstr As String = "select count(*) from m_wage m where to_char(m.sal_dt,'MON/yyyy')='" & Format(dtst, "MMM/yyyy").ToUpper & "'"
        Dim dtsttable As DataTable = oh.ExecuteDataSet(dtstr).Tables(0)

        If dtsttable.Rows(0)(0) <> 0 Then
            If Request.QueryString("firm") = 1 Then
                sql = "select m.emp_code,m.name,round((m.gross_sal)),round(m.p_fund) as pf_contribution , case when m.emp_code =10002 then round(m.gross_sal) else least(m.gross_sal,6500) end as pf_sal,round(least(m.gross_sal,6500)*3.67/100) as ac_no1,round(round(least(m.gross_sal,6500)*12/100)-round(least(m.gross_sal,6500)*3.67/100)) as ac_no2,round(least(m.gross_sal,6500)*12/100) as total, (m.p_fund-round(least(m.gross_sal,6500)*12/100)) as difference from m_wage m ,employee_master e where e.emp_code=m.emp_code and e.emp_type=1 and e.firm_id in(1) order by m.emp_code"
            ElseIf Request.QueryString("firm") = 2 Then
                sql = "select m.emp_code,m.name,round((m.gross_sal)),round(m.p_fund) as pf_contribution ,least(m.gross_sal,6500) as pf_sal,round(least(m.gross_sal,6500)*3.67/100) as ac_no1,round(round(least(m.gross_sal,6500)*12/100)-round(least(m.gross_sal,6500)*3.67/100)) as ac_no2,round(least(m.gross_sal,6500)*12/100) as total, (m.p_fund-round(least(m.gross_sal,6500)*12/100)) as difference from m_wage m ,employee_master e where e.emp_code=m.emp_code and e.emp_type=1 and e.firm_id in(2,3) order by m.emp_code"
            Else
                sql = "select m.emp_code,m.name,round((m.gross_sal)),round(m.p_fund) as pf_contribution ,least(m.gross_sal,6500) as pf_sal,round(least(m.gross_sal,6500)*3.67/100) as ac_no1,round(round(least(m.gross_sal,6500)*12/100)-round(least(m.gross_sal,6500)*3.67/100)) as ac_no2,round(least(m.gross_sal,6500)*12/100) as total, (m.p_fund-round(least(m.gross_sal,6500)*12/100)) as difference from m_wage m ,employee_master e where e.emp_code=m.emp_code and e.emp_type=1 and e.firm_id in(24) order by m.emp_code"
            End If
        Else
            If Request.QueryString("firm") = 1 Then
                sql = "select m.emp_code,m.name,round((m.gross_sal)),round(m.p_fund) as pf_contribution ,case when m.emp_code =10002 then round(m.gross_sal) else least(m.gross_sal,6500) end as pf_sal,round(least(m.gross_sal,6500)*3.67/100) as ac_no1,round(round(least(m.gross_sal,6500)*12/100)-round(least(m.gross_sal,6500)*3.67/100)) as ac_no2,round(least(m.gross_sal,6500)*12/100) as total, (m.p_fund-round(least(m.gross_sal,6500)*12/100)) as difference from m_wage_his m ,employee_master e where e.emp_code=m.emp_code and e.emp_type=1  and e.firm_id in(1) and to_char(m.sal_dt,'MON/yyyy')='" & Format(dtst, "MMM/yyyy").ToUpper & "' order by m.emp_code"
            ElseIf Request.QueryString("firm") = 2 Then
                sql = "select m.emp_code,m.name,round((m.gross_sal)),round(m.p_fund) as pf_contribution ,least(m.gross_sal,6500) as pf_sal,round(least(m.gross_sal,6500)*3.67/100) as ac_no1,round(round(least(m.gross_sal,6500)*12/100)-round(least(m.gross_sal,6500)*3.67/100)) as ac_no2,round(least(m.gross_sal,6500)*12/100) as total, (m.p_fund-round(least(m.gross_sal,6500)*12/100)) as difference from m_wage_his m ,employee_master e where e.emp_code=m.emp_code and e.emp_type=1 and e.firm_id in(2,3)  and to_char(m.sal_dt,'MON/yyyy')='" & Format(dtst, "MMM/yyyy").ToUpper & "' order by m.emp_code"
            Else
                sql = "select m.emp_code,m.name,round((m.gross_sal)),round(m.p_fund) as pf_contribution ,least(m.gross_sal,6500) as pf_sal,round(least(m.gross_sal,6500)*3.67/100) as ac_no1,round(round(least(m.gross_sal,6500)*12/100)-round(least(m.gross_sal,6500)*3.67/100)) as ac_no2,round(least(m.gross_sal,6500)*12/100) as total, (m.p_fund-round(least(m.gross_sal,6500)*12/100)) as difference from m_wage_his m ,employee_master e where e.emp_code=m.emp_code and e.emp_type=1 and e.firm_id in(24)  and to_char(m.sal_dt,'MON/yyyy')='" & Format(dtst, "MMM/yyyy").ToUpper & "' order by m.emp_code"
            End If

        End If

        Dim dt As DataTable = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count = 0 Then
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('Sorry, This Report Is Not Avilable');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        Dim tab1 As New Table
        tab1.Attributes.Add("width", "100%")


        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Width = 11
        'cell declaration
        Dim tabcc3 As New TableCell
        tabcc3.Attributes.Add("align", "center")
        Dim t As DataTable = oh.ExecuteDataSet("select firm_name from firm_master where firm_id= " & Me.Request.QueryString("firm")).Tables(0)
        tabcc3.Text = "<b><font size=2.5>" & t.Rows(0)(0) & " </font></b>"
        tabcc3.ColumnSpan = 11
        tabrr3.Controls.Add(tabcc3)
        tab1.Controls.Add(tabrr3)



        '3RD ROW
        Dim tabrr3Y As New TableRow
        tabrr3Y.Width = 11

        Dim tabcc3Y As New TableCell
        tabcc3Y.Attributes.Add("align", "center")
        ' Dim dd As DataTable = oh.ExecuteDataSet("select to_char(sal_dt,'MON,YYYY') from m_wage").Tables(0)
        tabcc3Y.Text = "<b><font size=2.5>PF STATEMENT FOR THE MONTH OF " & Format(CDate(dtst), "MMM/yyyy") & " </font></b>"
        tabcc3Y.ColumnSpan = 11
        tabrr3Y.Controls.Add(tabcc3Y)
        tab1.Controls.Add(tabrr3Y)


        Dim tabrr3Y1 As New TableRow
        tabrr3Y1.Width = 11

        'cell declaration
        Dim tabcc3Y1 As New TableCell
        tabcc3Y1.Attributes.Add("align", "center")
        tabcc3Y1.Text = " "
        tabcc3Y1.ColumnSpan = 11
        tabrr3Y1.Controls.Add(tabcc3Y1)
        tab1.Controls.Add(tabrr3Y1)


        '5th row

        Dim tabr5 As New TableRow
        tabr5.Width = 11
        tabr5.ForeColor = Drawing.Color.DarkSlateGray
        Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7, tabr5c8, tabr5c9, tabr5c10 As New TableCell
        tabr5c1.ColumnSpan = 1
        tabr5c2.ColumnSpan = 1
        tabr5c3.ColumnSpan = 2
        tabr5c4.ColumnSpan = 1
        tabr5c5.ColumnSpan = 1
        tabr5c6.ColumnSpan = 1
        tabr5c7.ColumnSpan = 1
        tabr5c8.ColumnSpan = 1
        tabr5c7.ColumnSpan = 1

        tabr5c1.HorizontalAlign = HorizontalAlign.Center
        tabr5c2.HorizontalAlign = HorizontalAlign.Left
        tabr5c3.HorizontalAlign = HorizontalAlign.Left
        tabr5c4.HorizontalAlign = HorizontalAlign.Center
        tabr5c5.HorizontalAlign = HorizontalAlign.Center
        tabr5c6.HorizontalAlign = HorizontalAlign.Center
        tabr5c7.HorizontalAlign = HorizontalAlign.Center
        tabr5c8.HorizontalAlign = HorizontalAlign.Center
        tabr5c9.HorizontalAlign = HorizontalAlign.Center
        tabr5c10.HorizontalAlign = HorizontalAlign.Center


        tabr5c1.Text = "<font size=2.5><b>SI NO.</b></font>"
        tabr5c2.Text = "<font size=2.5><b>EMP CODE</b></font>"
        tabr5c3.Text = "<font size=2.5><b>EMP NAME</b></font>"
        tabr5c4.Text = "<font size=2.5><b>GROSS SALARY</b></font>"
        tabr5c5.Text = "<font size=2.5><b>EMP. PF CONTRI.</b></font>"
        tabr5c6.Text = "<font size=2.5><b>PF SALARY</b></font>"
        tabr5c7.Text = "<font size=2.5><b>A/C NO.1</b></font>"
        tabr5c8.Text = "<font size=2.5><b>A/C NO.10</b></font>"
        tabr5c9.Text = "<font size=2.5><b>TOTAL</b></font>"
        tabr5c10.Text = "<font size=2.5><b>DIFF.</b></font>"

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

        tab1.Controls.Add(tabr5)

        '''''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 11
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 11
        tabcellline1.Text = "<hr>"
        tabline1.Controls.Add(tabcellline1)
        tab1.Controls.Add(tabline1)

        Dim count As Integer = 0
        Dim tot1 As Integer = 0
        Dim tot2 As Integer = 0
        Dim tot3 As Integer = 0
        Dim tot4 As Integer = 0
        Dim tot5 As Integer = 0
        Dim tot6 As Integer = 0
        Dim tot7 As Integer = 0

        Dim dr As DataRow
        For Each dr In dt.Rows
            count += 1

            Dim tabr6 As New TableRow
            tabr6.Width = 11
            Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7, tabr6c8, tabr6c9, tabr6c10 As New TableCell
            tabr6c1.ColumnSpan = 1
            tabr6c2.ColumnSpan = 1
            tabr6c3.ColumnSpan = 2
            tabr6c4.ColumnSpan = 1
            tabr6c5.ColumnSpan = 1
            tabr6c6.ColumnSpan = 1
            tabr6c7.ColumnSpan = 1
            tabr6c5.ColumnSpan = 1
            tabr6c6.ColumnSpan = 1
            tabr6c7.ColumnSpan = 1

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

            tabr6c1.Text = "<font size=2>" & count & "&nbsp;&nbsp;</font>"
            tabr6c2.Text = "<font size=2>" & dr(0) & "&nbsp;&nbsp;</font>"
            tabr6c3.Text = "<font size=2>" & dr(1) & "&nbsp;&nbsp;</font>"
            tabr6c4.Text = "<font size=2>" & dr(2) & "&nbsp;&nbsp;</font>"
            tabr6c5.Text = "<font size=2>" & dr(3) & "&nbsp;&nbsp;</font>"
            tabr6c6.Text = "<font size=2>" & dr(4) & "&nbsp;&nbsp;</font>"
            tabr6c7.Text = "<font size=2>" & dr(5) & "&nbsp;&nbsp;</font>"
            tabr6c8.Text = "<font size=2>" & dr(6) & "&nbsp;&nbsp;</font>"
            tabr6c9.Text = "<font size=2>" & dr(7) & "&nbsp;&nbsp;</font>"
            tabr6c10.Text = "<font size=2>" & dr(8) & "&nbsp;&nbsp;</font>"
            tot1 += dr(2)
            tot2 += dr(3)
            tot3 += dr(4)
            tot4 += dr(5)
            tot5 += dr(6)
            tot6 += dr(7)
            tot7 += dr(8)

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

            tab1.Controls.Add(tabr6)
        Next

        Dim tabline11 As New TableRow
        tabline11.Width = 11
        Dim tabcellline11 As New TableCell
        tabcellline11.ColumnSpan = 11
        tabcellline11.Text = "<hr>"
        tabline11.Controls.Add(tabcellline11)
        tab1.Controls.Add(tabline11)

        'total row
        Dim totrow As New TableRow
        totrow.Width = 11
        Dim t1, t2, t3, t4, t5, t6, t7, t8 As New TableCell

        t1.ColumnSpan = 4
        t1.HorizontalAlign = HorizontalAlign.Center
        t1.Text = "<font size=2>TOTAL</font>"
        totrow.Controls.Add(t1)

        t2.ColumnSpan = 1
        t2.HorizontalAlign = HorizontalAlign.Right
        t2.Text = "<font size=2>" & tot1 & "</font>"
        totrow.Controls.Add(t2)

        t3.ColumnSpan = 1
        t3.HorizontalAlign = HorizontalAlign.Right
        t3.Text = "<font size=2>" & tot2 & "</font>"
        totrow.Controls.Add(t3)

        t4.ColumnSpan = 1
        t4.HorizontalAlign = HorizontalAlign.Right
        t4.Text = "<font size=2>" & tot3 & "</font>"
        totrow.Controls.Add(t4)

        t5.ColumnSpan = 1
        t5.HorizontalAlign = HorizontalAlign.Right
        t5.Text = "<font size=2>" & tot4 & "</font>"
        totrow.Controls.Add(t5)

        t6.ColumnSpan = 1
        t6.HorizontalAlign = HorizontalAlign.Right
        t6.Text = "<font size=2>" & tot5 & "</font>"
        totrow.Controls.Add(t6)

        t7.ColumnSpan = 1
        t7.HorizontalAlign = HorizontalAlign.Right
        t7.Text = "<font size=2>" & tot6 & "</font>"
        totrow.Controls.Add(t7)

        t8.ColumnSpan = 1
        t8.HorizontalAlign = HorizontalAlign.Right
        t8.Text = "<font size=2>" & tot7 & "</font>"
        totrow.Controls.Add(t8)

        tab1.Controls.Add(totrow)


        Dim tabline1a As New TableRow
        tabline1a.Width = 11
        Dim tabcellline1a As New TableCell
        tabcellline1a.ColumnSpan = 11
        tabcellline1a.Text = "<hr>"
        tabline1a.Controls.Add(tabcellline1a)
        tab1.Controls.Add(tabline1a)

        'summary1
        Dim summary1 As New TableRow
        summary1.Width = 11
        Dim s11, s12, s13, s14, s15, s16, s17 As New TableCell
        s11.ColumnSpan = 1
        s11.Text = ""
        summary1.Controls.Add(s11)
        s12.ColumnSpan = 3
        s12.HorizontalAlign = HorizontalAlign.Left
        s12.Text = "<font size=2>A/C NO.1 EPF </font>"
        summary1.Controls.Add(s12)
        s13.ColumnSpan = 1
        s13.HorizontalAlign = HorizontalAlign.Right
        s13.Text = "<font size=2>3.67 % </font>"
        summary1.Controls.Add(s13)
        s14.ColumnSpan = 1
        s14.HorizontalAlign = HorizontalAlign.Right
        s14.Text = "<font size=2>" & tot4 & " </font>"
        summary1.Controls.Add(s14)
        s15.ColumnSpan = 1
        s15.Text = ""
        summary1.Controls.Add(s15)
        s16.ColumnSpan = 3
        s16.Text = ""
        summary1.Controls.Add(s16)
        s17.ColumnSpan = 1
        s17.Text = ""
        summary1.Controls.Add(s17)
        tab1.Controls.Add(summary1)

        'summary2
        Dim summary2 As New TableRow
        summary2.Width = 11
        Dim s21, s22, s23, s24, s25, s26, s27 As New TableCell
        s21.ColumnSpan = 1
        s21.Text = ""
        summary2.Controls.Add(s21)
        s22.ColumnSpan = 3
        s22.HorizontalAlign = HorizontalAlign.Left
        s22.Text = "<font size=2>A/C NO.10 EPF </font>"
        summary2.Controls.Add(s22)
        s23.ColumnSpan = 1
        s23.Text = "<font size=2>8.33 % </font>"
        s23.HorizontalAlign = HorizontalAlign.Right
        summary2.Controls.Add(s23)
        s24.ColumnSpan = 1
        s24.HorizontalAlign = HorizontalAlign.Right
        s24.Text = "<font size=2>" & tot5 & " </font>"
        summary2.Controls.Add(s24)
        s25.ColumnSpan = 1
        s25.Text = ""
        summary2.Controls.Add(s25)
        s26.ColumnSpan = 3
        s26.Text = "<font size=2>EMPLOYEE </font>"
        summary2.Controls.Add(s26)
        s27.ColumnSpan = 1
        s27.Text = "<font size=2>" & tot2 & " </font>"
        summary2.Controls.Add(s27)
        tab1.Controls.Add(summary2)

        'summary3
        Dim summary3 As New TableRow
        summary3.Width = 11
        Dim s31, s32, s33, s34, s35, s36, s37 As New TableCell
        s31.ColumnSpan = 1
        s31.Text = ""
        summary3.Controls.Add(s31)
        s32.ColumnSpan = 3
        s32.HorizontalAlign = HorizontalAlign.Left
        s32.Text = "<font size=2>A/C NO.2 ADMIN CHARGE </font>"
        summary3.Controls.Add(s32)
        s33.ColumnSpan = 1
        s33.Text = "<font size=2>1.10 % </font>"
        s33.HorizontalAlign = HorizontalAlign.Right
        summary3.Controls.Add(s33)
        s34.ColumnSpan = 1
        s34.HorizontalAlign = HorizontalAlign.Right
        s34.Text = "<font size=2>" & Math.Round(tot3 * 1.1 / 100) & " </font>"
        summary3.Controls.Add(s34)
        s35.ColumnSpan = 1
        s35.Text = ""
        summary3.Controls.Add(s35)
        s36.ColumnSpan = 3
        s36.Text = "<font size=2>EMPLOYER </font>"
        summary3.Controls.Add(s36)
        s37.ColumnSpan = 1
        s37.Text = "<font size=2>" & tot6 + Math.Round(tot3 * 1.1 / 100) + Math.Round(tot3 * 0.005 / 100) & " </font>"
        summary3.Controls.Add(s37)
        tab1.Controls.Add(summary3)

        'summary4
        Dim summary4 As New TableRow
        summary4.Width = 11
        Dim s41, s42, s43, s44, s45, s46, s47 As New TableCell
        s41.ColumnSpan = 1
        s41.Text = ""
        summary4.Controls.Add(s41)
        s42.ColumnSpan = 3
        s42.HorizontalAlign = HorizontalAlign.Left
        s42.Text = "<font size=2>INSPECTION CHARGE </font>"
        summary4.Controls.Add(s42)
        s43.ColumnSpan = 1
        s43.Text = "<font size=2>0.005 % </font>"
        s43.HorizontalAlign = HorizontalAlign.Right
        summary4.Controls.Add(s43)
        s44.ColumnSpan = 1
        s44.HorizontalAlign = HorizontalAlign.Right
        s44.Text = "<font size=2>" & Math.Round(tot3 * 0.005 / 100) & " </font>"
        summary4.Controls.Add(s44)
        s45.ColumnSpan = 1
        s45.Text = ""
        summary4.Controls.Add(s45)
        s46.ColumnSpan = 3
        s46.Text = ""
        summary4.Controls.Add(s46)
        s47.ColumnSpan = 1
        s47.Text = ""
        summary4.Controls.Add(s47)
        tab1.Controls.Add(summary4)


        Dim tabline111 As New TableRow
        tabline111.Width = 11
        Dim tabcellline111 As New TableCell
        tabcellline111.ColumnSpan = 11
        tabcellline111.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
        tabline111.Controls.Add(tabcellline111)
        tab1.Controls.Add(tabline111)

        'summary5
        Dim summary5 As New TableRow
        summary5.Width = 11
        Dim s51, s52, s53, s54, s55, s56, s57 As New TableCell
        s51.ColumnSpan = 1
        s51.Text = ""
        summary5.Controls.Add(s51)
        s52.ColumnSpan = 3
        s52.HorizontalAlign = HorizontalAlign.Left
        s52.Text = "<font size=2><b>TOTAL </b></font>"
        summary5.Controls.Add(s52)
        s53.ColumnSpan = 1
        s53.Text = " "
        s53.HorizontalAlign = HorizontalAlign.Right
        summary5.Controls.Add(s53)
        s54.ColumnSpan = 1
        s54.HorizontalAlign = HorizontalAlign.Right
        ''''''''''''''''''''
        Dim tt As Integer = 0

        tt = tot4 + tot5 + Math.Round(tot3 * 1.1 / 100) + Math.Round(tot3 * 0.005 / 100)

        s54.Text = "<font size=2><b>" & tt & " </b></font>"
        summary5.Controls.Add(s54)
        s55.ColumnSpan = 1
        s55.Text = ""
        summary5.Controls.Add(s55)
        s56.ColumnSpan = 3
        s56.Text = "<font size=2><b>GRAND TOTAL </b></font>"
        summary5.Controls.Add(s56)
        s57.ColumnSpan = 1
        s57.Text = "<font size=2><b>" & tot2 + tot6 + Math.Round(tot3 * 1.1 / 100) + Math.Round(tot3 * 0.005 / 100) & " </b></font>"
        summary5.Controls.Add(s57)
        tab1.Controls.Add(summary5)

        Dim tabln As New TableRow
        tabln.Width = 11
        Dim tabcn1 As New TableCell
        tabcn1.ColumnSpan = 11
        tabcn1.Text = "<hr>"
        tabln.Controls.Add(tabcn1)
        tab1.Controls.Add(tabln)

        Dim lastrow As New TableRow
        lastrow.Width = 11
        Dim last1 As New TableCell
        last1.ColumnSpan = 11
        last1.HorizontalAlign = HorizontalAlign.Left
        Dim tts As String = getWords(tot2 + tot6 + Math.Round(tot3 * 1.1 / 100) + Math.Round(tot3 * 0.005 / 100))
        Dim tts1 As String = (tot2 + tot6 + Math.Round(tot3 * 1.1 / 100) + Math.Round(tot3 * 0.005 / 100)) & "/- (" & tts & " Only)"
        last1.Text = "<font size=3> Rs. " & tts1 & " </font 2>"
        lastrow.Controls.Add(last1)
        tab1.Controls.Add(lastrow)

        Me.Panel1.Controls.Add(tab1)
    End Sub

    Public Function getWords(ByVal myNumber As String) As String
        getWords = SpellNumber(myNumber)
    End Function

    Private Function SpellNumber(ByVal MyNumber As String)
        Dim Rupees, Paise, Temp, ornum
        Dim DecimalPlace, Count
        Dim Place(9) As String
        Place(2) = " Thousand "
        Place(3) = " Lakh "
        Place(4) = " Crore "
        MyNumber = Convert.ToString(MyNumber)
        DecimalPlace = InStr(MyNumber, ".")
        If DecimalPlace > 0 Then
            ornum = Trim(Left(MyNumber, DecimalPlace - 1))
        Else
            ornum = MyNumber
        End If
        If DecimalPlace > 0 Then
            Paise = GetTens(Left(Mid(MyNumber, DecimalPlace + 1) & _
                                 "00", 2))
            MyNumber = Trim(Left(MyNumber, DecimalPlace - 1))
            ornum = MyNumber
        End If
        Count = 1
        Do While MyNumber <> ""
            If ornum = MyNumber Then
                Temp = GetHundreds(Right(MyNumber, 3))
                If Temp <> "" Then Rupees = Temp & Place(Count) & Rupees
                If Len(MyNumber) > 3 Then
                    If MyNumber = ornum Then
                        MyNumber = Left(MyNumber, Len(MyNumber) - 3)
                    Else
                        MyNumber = Left(MyNumber, Len(MyNumber) - 2)
                    End If
                Else
                    MyNumber = ""
                End If
                Count = Count + 1
            Else
                Temp = GetTens(Right(MyNumber, 2))
                If Temp <> "" Then Rupees = Temp & Place(Count) & Rupees
                If Len(MyNumber) > 2 Then
                    If MyNumber = ornum Then
                        MyNumber = Left(MyNumber, Len(MyNumber) - 3)
                    Else
                        MyNumber = Left(MyNumber, Len(MyNumber) - 2)
                    End If
                Else
                    MyNumber = ""
                End If
                Count = Count + 1
            End If
        Loop
        Select Case Rupees
            Case ""
                Rupees = "zero Rupees"
            Case "One"
                Rupees = "One Rupees"
            Case Else
                Rupees = Rupees & " Rupees"
        End Select
        Select Case Paise
            Case ""
                Paise = " and zero Paise"
            Case "One"
                Paise = " and One Paise"
            Case Else
                Paise = " and " & Paise & " Paise"
        End Select
        SpellNumber = Rupees & Paise
    End Function

    Private Function GetHundreds(ByVal MyNumber As String)
        Dim Result As String
        If Val(MyNumber) = 0 Then Exit Function
        MyNumber = Right("000" & MyNumber, 3)
        If Mid(MyNumber, 1, 1) <> "0" Then
            Result = GetDigit(Mid(MyNumber, 1, 1)) & " Hundred "
        End If
        If Mid(MyNumber, 2, 1) <> "0" Then
            Result = Result & GetTens(Mid(MyNumber, 2))
        Else
            Result = Result & GetDigit(Mid(MyNumber, 3))
        End If
        GetHundreds = Result
    End Function

    Private Function GetTens(ByVal TensText As String)
        Dim Result As String
        Result = ""
        If Val(Left(TensText, 1)) = 1 Then
            If Len(TensText) = 1 Then
                Result = Result & GetDigit(Right(TensText, 1))
            Else
                Select Case Val(TensText)
                    Case 10 : Result = "Ten"
                    Case 11 : Result = "Eleven"
                    Case 12 : Result = "Twelve"
                    Case 13 : Result = "Thirteen"
                    Case 14 : Result = "Fourteen"
                    Case 15 : Result = "Fifteen"
                    Case 16 : Result = "Sixteen"
                    Case 17 : Result = "Seventeen"
                    Case 18 : Result = "Eighteen"
                    Case 19 : Result = "Nineteen"
                    Case Else
                End Select
            End If
        Else
            If Len(TensText) = 1 Then
            Else
                Dim kl
                kl = CInt(Val(Left(TensText, 1)))
                Select Case CInt(Val(Left(TensText, 1)))
                    Case 2 : Result = "Twenty "
                    Case 3 : Result = "Thirty "
                    Case 4 : Result = "Forty "
                    Case 5 : Result = "Fifty "
                    Case 6 : Result = "Sixty "
                    Case 7 : Result = "Seventy "
                    Case 8 : Result = "Eighty "
                    Case 9 : Result = "Ninety "
                    Case Else
                End Select
            End If
            Result = Result & GetDigit(Right(TensText, 1))
        End If
        GetTens = Result
    End Function

    Private Function GetDigit(ByVal Digit As String)
        Select Case Val(Digit)
            Case 1 : GetDigit = "One"
            Case 2 : GetDigit = "Two"
            Case 3 : GetDigit = "Three"
            Case 4 : GetDigit = "Four"
            Case 5 : GetDigit = "Five"
            Case 6 : GetDigit = "Six"
            Case 7 : GetDigit = "Seven"
            Case 8 : GetDigit = "Eight"
            Case 9 : GetDigit = "Nine"
            Case Else : GetDigit = ""
        End Select
    End Function

End Class
