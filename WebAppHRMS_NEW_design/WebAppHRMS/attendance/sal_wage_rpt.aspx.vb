Imports System.Data
Imports System.Data.OracleClient
Partial Class salary_report_sal_wage_rpt_34b2f95f1868
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim colors As String
    Dim dt As New DataTable
    Dim s As String
    Dim tab, tab1 As New Table
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SalCnt As Integer = oh.ExecuteDataSet("select count(*) from salari").Tables(0).Rows(0)(0)
        If SalCnt > 0 Then
            If (Session("branch_id") = 0) Then
                Panel1.Visible = False
                Panel2.Visible = True
                Dim user() As String
                user = Session("user_id").ToString.Split("!")
                dt = oh.ExecuteDataSet("select s.name as Name,nvl(s.wages_pble,0) as wages_payable,nvl(s.tot_dedu,0)+nvl(s.lop,0) as Total_deduction,nvl(s.wages_pble,0)-nvl(s.tot_dedu,0)-nvl(s.lop,0) as Salary_Payable,nvl(s.cutting,0) as Other_Deduction ,nvl(s.wages_pble,0)-nvl(s.tot_dedu,0)-nvl(s.lop,0)-nvl(s.cutting,0)+nvl(s.bonus,0) as Salary_Paid,s.emp_id,s.hpta,nvl(s.bonus,0) from salari s,firm_master fm,branch_master bm where s.firm_id=fm.firm_id and bm.branch_id=s.branch_id and emp_id=" & user(0)).Tables(0)
                If dt.Rows.Count <= 0 Then
                    Panel1.Visible = False
                    Panel2.Visible = True
                    Dim warnRow As New TableRow
                    Dim w1 As New TableCell
                    warnRow.Width = 9
                    w1.ColumnSpan = 9
                    w1.Text = "<font size=2><b>Your Salary Not Updated..!! Please Check After Sometime..!!</b></font>"
                    warnRow.Controls.Add(w1)
                    tab1.Controls.Add(warnRow)
                    Me.Panel2.Controls.Add(tab1)
                    Exit Sub
                End If
                tab.Attributes.Add("width", "100%")
                Dim tabr1 As New TableRow
                tabr1.Width = 20
                tabr1.Attributes.Add("bgcolor", "gold")
                tabr1.BorderStyle = BorderStyle.Solid
                tabr1.BorderColor = Drawing.Color.Red
                Dim tabc1 As New TableCell
                tabc1.ColumnSpan = 20
                tabc1.Text = "<body align=center color=red><b><font size=4> " & Session("firm_name") & "</font></b></body>"
                tabc1.ForeColor = Drawing.Color.Red
                tabc1.Attributes.Add("align", "center")
                tabr1.Controls.Add(tabc1)
                tab.Controls.Add(tabr1)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim tabr2 As New TableRow
                'tabr2.Attributes.Add("bgcolor", "bisque")
                tabr2.ForeColor = Drawing.Color.Maroon
                Dim tabc2 As New TableCell
                tabc2.ColumnSpan = 20
                tabc2.HorizontalAlign = HorizontalAlign.Center
                tabc2.ForeColor = Drawing.Color.Brown
                s = oh.ExecuteDataSet("select to_char(sal_dt,'MONTH - yyyy') from m_wage where emp_code=" & user(0)).Tables(0).Rows(0)(0)

                tabc2.Text = "<body align=center color=red><b><font size=3.5> SALARY STATEMENT -" & s & " </font></b></body>"
                tabr2.Controls.Add(tabc2)
                tab.Controls.Add(tabr2)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim tabr3 As New TableRow
                tabr3.Width = 20
                tabr3.Attributes.Add("bgcolor", "#ffcca3")
                Dim tabc3 As New TableCell
                tabc3.ColumnSpan = 10
                tabc3.HorizontalAlign = HorizontalAlign.Left
                tabc3.ForeColor = Drawing.Color.Maroon
                tabc3.Text = "<b><font size=3.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
                tabr3.Controls.Add(tabc3)
                tab.Controls.Add(tabr3)

                Dim tabc4 As New TableCell
                tabc4.Attributes.Add("width", "50%")
                tabc4.HorizontalAlign = HorizontalAlign.Right
                tabc4.ColumnSpan = 10
                tabc4.ForeColor = Drawing.Color.Maroon
                Dim dat As String
                Dim hr As Integer = Date.Now.Hour
                If hr > 12 Then
                    dat = "PM"
                Else
                    dat = "AM"
                End If
                If (hr = 0) Then
                    hr = 12
                End If

                If (hr > 12) Then
                    hr = hr - 12
                End If

                tabc4.Text = "<b><font size=3.5>TIME: " & hr.ToString & ":" & Date.Now.Minute & ":" & Date.Now.Second & " " & dat & "</font></b>"
                tabr3.Controls.Add(tabc4)
                tab.Controls.Add(tabr3)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim tabline As New TableRow
                tabline.Width = 20
                Dim tabcellline As New TableCell
                tabcellline.ColumnSpan = 20
                tabcellline.Text = "<hr>"
                tabline.Controls.Add(tabcellline)
                tab.Controls.Add(tabline)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim tabr5 As New TableRow
                tabr5.Attributes.Add("bgcolor", "#fffcff")
                Dim tabr5c1, tabr5c2 As New TableCell
                tabr5c1.Attributes.Add("align", "left")
                tabr5c2.Attributes.Add("align", "left")
                tabr5c1.ColumnSpan = 10
                tabr5c2.ColumnSpan = 10
                tabr5c1.Text = "<FONT SIZE=3>EMP.CODE  </FONT>"
                tabr5c2.Text = "<FONT SIZE=3>- " & dt.Rows(0)(6) & "</FONT>"
                tabr5.Controls.Add(tabr5c1)
                tabr5.Controls.Add(tabr5c2)
                tab.Controls.Add(tabr5)

                Dim tabr6 As New TableRow
                tabr6.Attributes.Add("bgcolor", "#f8f8f8")
                Dim tabr6c1, tabr6c2 As New TableCell
                tabr6c1.Attributes.Add("align", "left")
                tabr6c2.Attributes.Add("align", "left")
                tabr6c1.ColumnSpan = 10
                tabr6c1.ColumnSpan = 10

                tabr6c1.Text = "<FONT SIZE=3>NAME  </FONT>"
                tabr6c2.Text = "<FONT SIZE=3>- " & dt.Rows(0)(0) & "</FONT>"
                tabr6.Controls.Add(tabr6c1)
                tabr6.Controls.Add(tabr6c2)
                tab.Controls.Add(tabr6)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim tabr7 As New TableRow
                tabr7.Attributes.Add("bgcolor", "#fffcff")
                Dim tabr7c1, tabr7c2 As New TableCell
                tabr7c1.Attributes.Add("align", "left")
                tabr7c2.Attributes.Add("align", "left")
                tabr7c1.ColumnSpan = 10
                tabr7c1.ColumnSpan = 10

                tabr7c1.Text = "<FONT SIZE=3>WAGES PAYABLE  </FONT>"
                tabr7c2.Text = "<FONT SIZE=3>- " & dbnull(dt.Rows(0)(1)) & "</FONT>"
                tabr7.Controls.Add(tabr7c1)
                tabr7.Controls.Add(tabr7c2)
                tab.Controls.Add(tabr7)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim tabr8 As New TableRow
                tabr8.Attributes.Add("bgcolor", "#f8f8f8")
                Dim tabr8c1, tabr8c2 As New TableCell
                tabr8c1.Attributes.Add("align", "left")
                tabr8c2.Attributes.Add("align", "left")
                tabr8c1.ColumnSpan = 10
                tabr8c1.ColumnSpan = 10

                tabr8c1.Text = "<FONT SIZE=3>TOTEL DEDUCTION  </FONT>"
                If IsDBNull(dt.Rows(0)(2)) = True Then
                    tabr8c2.Text = "- " & dbnull(dt.Rows(0)(2))
                ElseIf dt.Rows(0)(2) = 0 Then
                    tabr8c2.Text = "- " & dbnull(dt.Rows(0)(2))
                Else
                    tabr8c2.Text = "<FONT SIZE=3>- <a href=deduction_rpt.aspx?empid=" & user(0) & ">" & dbnull(dt.Rows(0)(2)) & "</a></FONT>"
                End If
                tabr8.Controls.Add(tabr8c1)
                tabr8.Controls.Add(tabr8c2)
                tab.Controls.Add(tabr8)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim tabr9 As New TableRow
                tabr9.Attributes.Add("bgcolor", "#fffcff")
                Dim tabr9c1, tabr9c2 As New TableCell
                tabr9c1.Attributes.Add("align", "left")
                tabr9c2.Attributes.Add("align", "left")
                tabr9c1.ColumnSpan = 10
                tabr9c1.ColumnSpan = 10

                tabr9c1.Text = "<FONT SIZE=3>SALARY PAYABLE  </FONT>"
                tabr9c2.Text = "<FONT SIZE=3>- " & dbnull(dt.Rows(0)(3)) & "</FONT>"
                tabr9.Controls.Add(tabr9c1)
                tabr9.Controls.Add(tabr9c2)
                tab.Controls.Add(tabr9)
                '''''''''''''''''
                Dim tabr10 As New TableRow
                tabr10.Attributes.Add("bgcolor", "#f8f8f8")
                Dim tabr10c1, tabr10c2 As New TableCell
                tabr10c1.Attributes.Add("align", "left")
                tabr10c2.Attributes.Add("align", "left")
                tabr10c1.ColumnSpan = 10
                tabr10c1.ColumnSpan = 10

                tabr10c1.Text = "<FONT SIZE=3>OTHER DEDUCTION  </FONT>"
                If IsDBNull(dt.Rows(0)(4)) = True Then
                    tabr10c2.Text = "- " & dbnull(dt.Rows(0)(4))
                ElseIf dt.Rows(0)(4) = 0 Then
                    tabr10c2.Text = "- " & dbnull(dt.Rows(0)(4))
                Else
                    tabr10c2.Text = "<FONT SIZE=3>-" & dbnull(dt.Rows(0)(4)) & "</FONT>"
                End If
                tabr10.Controls.Add(tabr10c1)
                tabr10.Controls.Add(tabr10c2)
                tab.Controls.Add(tabr10)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If dt.Rows(0)(8) > 0 Then
                    Dim tabr111 As New TableRow
                    tabr111.Attributes.Add("bgcolor", "#fffcff")
                    Dim tabr111c1, tabr111c2 As New TableCell
                    tabr111c1.Attributes.Add("align", "left")
                    tabr111c2.Attributes.Add("align", "left")
                    tabr111c1.ColumnSpan = 10
                    tabr111c1.ColumnSpan = 10

                    tabr111c1.Text = "<FONT SIZE=3>BONUS </FONT>"
                    tabr111c2.Text = "<FONT SIZE=3>- " & dbnull(dt.Rows(0)(8)) & "</FONT>"
                    tabr111.Controls.Add(tabr111c1)
                    tabr111.Controls.Add(tabr111c2)
                    tab.Controls.Add(tabr111)

                End If

                Dim tabr11 As New TableRow
                If dt.Rows(0)(8) > 0 Then
                    tabr11.Attributes.Add("bgcolor", "#f8f8f8")
                Else
                    tabr11.Attributes.Add("bgcolor", "#fffcff")

                End If

                Dim tabr11c1, tabr11c2 As New TableCell
                tabr11c1.Attributes.Add("align", "left")
                tabr11c2.Attributes.Add("align", "left")
                tabr11c1.ColumnSpan = 10
                tabr11c1.ColumnSpan = 10

                tabr11c1.Text = "<FONT SIZE=3>SALARY PAID  </FONT>"
                tabr11c2.Text = "<FONT SIZE=3>- " & dbnull(dt.Rows(0)(5)) & "</FONT>"
                tabr11.Controls.Add(tabr11c1)
                tabr11.Controls.Add(tabr11c2)
                tab.Controls.Add(tabr11)



                Dim tabr12 As New TableRow
                If dt.Rows(0)(8) > 0 Then
                    tabr12.Attributes.Add("bgcolor", "#fffcff")
                Else
                    tabr12.Attributes.Add("bgcolor", "#f8f8f8")

                End If

                'Dim tabr12c1, tabr12c2 As New TableCell
                'tabr12c1.Attributes.Add("align", "left")
                'tabr12c2.Attributes.Add("align", "left")
                'tabr12c1.ColumnSpan = 10
                'tabr12c1.ColumnSpan = 10

                'tabr12c1.Text = "<FONT SIZE=3>HPTA  </FONT>"
                'tabr12c2.Text = "<FONT SIZE=3>- " & dbnull(dt.Rows(0)(7)) & "</FONT>"
                'tabr12.Controls.Add(tabr12c1)
                'tabr12.Controls.Add(tabr12c2)
                'tab.Controls.Add(tabr12)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Panel2.Controls.Add(tab)

            Else
                Panel2.Visible = False
                Panel1.Visible = True
                dt = oh.ExecuteDataSet("select s.emp_id||'-'||s.name as Name,nvl(s.wages_pble,0) as wages_payable,nvl(s.tot_dedu,0)+nvl(s.lop,0) as Total_deduction,nvl(s.wages_pble,0)-nvl(s.tot_dedu,0)-nvl(s.lop,0) as Salary_Payable,nvl(s.cutting,0) as Other_Deduction ,nvl(s.wages_pble,0)-nvl(s.tot_dedu,0)-nvl(s.lop,0)-nvl(s.cutting,0)+nvl(s.bonus,0) as Salary_Paid,s.emp_id,s.hpta,nvl(s.bonus,0) from salari s,firm_master fm,branch_master bm where s.firm_id=fm.firm_id and bm.branch_id=s.branch_id and bm.branch_id=" & Session("branch_id") & "  order by emp_id").Tables(0)
                Dim bonuscount As Integer = 0
                For k As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(k)(8) > 0 Then
                        bonuscount = 1
                        Exit For
                    End If
                Next
                tab1.Attributes.Add("width", "100%")
                Dim tabr1 As New TableRow
                tabr1.Attributes.Add("width", "100%")
                tabr1.Attributes.Add("bgcolor", "gold")
                tabr1.Attributes.Add("bordercolor", "red")
                Dim tabc1 As New TableCell
                tabc1.Attributes.Add("width", "100%")

                tabc1.Text = "<body align=center color=red><b><font size=4>" & Session("firm_name") & " </font></b></body>"
                tabc1.ColumnSpan = "8"
                tabc1.ForeColor = Drawing.Color.Red
                tabr1.Controls.Add(tabc1)
                tab1.Controls.Add(tabr1)

                '2nd row
                Dim tabr2 As New TableRow
                tabr2.Attributes.Add("width", "100%")
                tabr2.ForeColor = Drawing.Color.Maroon
                'cell declaration
                Dim tabc2 As New TableCell
                tabc2.Attributes.Add("width", "100%")
                '-=-=-=-=-=-=-=-=-=
                'Dim s As String = oh.ExecuteDataSet("select distinct to_char(to_date(sal_dt),'MONTH') from salari").Tables(0).Rows(0)(0)

                tabc2.Text = "<body align=center><b> SALARY STATEMENT -" & s & " </b></body>"
                tabc2.ColumnSpan = "8"
                tabr2.Controls.Add(tabc2)
                tab1.Controls.Add(tabr2)

                '3RD ROW
                Dim tabr3 As New TableRow
                tabr3.Attributes.Add("width", "100%")

                'cell declaration
                Dim tabc3 As New TableCell
                tabc3.Attributes.Add("width", "100%")
                tabc3.ForeColor = Drawing.Color.Maroon
                tabc3.Text = "<body align=center><b><font size=2.5>BRANCH ID : " & Session("branch_id") & ",    BRANCH NAME : " & Session("branch_name") & " </font></b></body>"
                tabc3.ColumnSpan = "8"
                tabr3.Controls.Add(tabc3)
                tab1.Controls.Add(tabr3)

                '3RD ROW
                Dim tabrr3 As New TableRow
                tabrr3.Attributes.Add("width", "100%")
                tabrr3.Attributes.Add("bgcolor", "#ffcca3")

                'cell declaration
                Dim tabcc3 As New TableCell
                tabcc3.Attributes.Add("width", "100%")
                tabcc3.ForeColor = Drawing.Color.Maroon
                tabcc3.Attributes.Add("align", "left")
                tabcc3.Text = "<b><font size=2.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
                tabcc3.ColumnSpan = "4"
                tabrr3.Controls.Add(tabcc3)
                tab1.Controls.Add(tabrr3)
                'cell declaration
                Dim tabcc4 As New TableCell
                tabcc4.Attributes.Add("width", "100%")
                tabcc4.ForeColor = Drawing.Color.Maroon

                tabcc4.Attributes.Add("align", "right")

                Dim dat As String
                Dim hr As Integer = Date.Now.Hour
                If hr > 12 Then
                    dat = "PM"
                Else
                    dat = "AM"
                End If
                If (hr = 0) Then
                    hr = 12
                End If

                If (hr > 12) Then
                    hr = hr - 12
                End If

                tabcc4.Text = "<b><font size=2.5>TIME: " & hr.ToString & ":" & Date.Now.Minute & ":" & Date.Now.Second & " " & dat & "</font></b>"
                tabcc4.ColumnSpan = "4"
                tabrr3.Controls.Add(tabcc4)
                tab1.Controls.Add(tabrr3)

                Dim tabline As New TableRow
                tabline.Width = 20
                Dim tabcellline As New TableCell
                tabcellline.ColumnSpan = 20
                tabcellline.Text = "<hr>"
                tabline.Controls.Add(tabcellline)
                tab1.Controls.Add(tabline)

                '5th row

                Dim tabr5 As New TableRow
                tabr5.Attributes.Add("width", "100%")
                tabr5.ForeColor = Drawing.Color.DarkSlateGray
                Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7, tabr5c8 As New TableCell
                If bonuscount = 0 Then
                    tabr5c1.Attributes.Add("width", "20%")
                    tabr5c2.Attributes.Add("width", "14%")
                    tabr5c3.Attributes.Add("width", "13%")
                    tabr5c4.Attributes.Add("width", "14%")
                    tabr5c5.Attributes.Add("width", "13%")
                    tabr5c6.Attributes.Add("width", "15%")
                    ' tabr5c7.Attributes.Add("width", "11%")
                Else
                    tabr5c1.Attributes.Add("width", "20%")
                    tabr5c2.Attributes.Add("width", "13%")
                    tabr5c3.Attributes.Add("width", "12%")
                    tabr5c4.Attributes.Add("width", "13%")
                    tabr5c5.Attributes.Add("width", "10%")
                    tabr5c6.Attributes.Add("width", "12%")
                    ' tabr5c7.Attributes.Add("width", "11%")
                    tabr5c8.Attributes.Add("width", "9%")
                End If


                tabr5c1.Text = "<font size=2.5><b>NAME</b></font>"
                tabr5c2.Text = "<font size=2.5><b>WAGES PAYABLE</b></font>"
                tabr5c3.Text = "<font size=2.5><b>TOTAL DEDUCTION</b></font>"
                tabr5c4.Text = "<font size=2.5><b>SALARY PAYABLE</b></font>"
                tabr5c5.Text = "<font size=2.5><b>OTHER DEDUCTION</b></font>"
                tabr5c8.Text = "<font size=2.5><b>BONUS</b></font>"
                tabr5c6.Text = "<font size=2.5><b>SALARY PAID</b></font>"
                ' tabr5c7.Text = "<font size=2.5><b>HPTA</b></font>"

                tabr5.Controls.Add(tabr5c1)
                tabr5.Controls.Add(tabr5c2)
                tabr5.Controls.Add(tabr5c3)
                tabr5.Controls.Add(tabr5c4)
                tabr5.Controls.Add(tabr5c5)
                If bonuscount > 0 Then
                    tabr5.Controls.Add(tabr5c8)
                End If
                tabr5.Controls.Add(tabr5c6)
                ' tabr5.Controls.Add(tabr5c7)
                tab1.Controls.Add(tabr5)

                '''''''''''''''''''''''''''''''''''''''
                Dim tabline1 As New TableRow
                tabline1.Width = 20
                Dim tabcellline1 As New TableCell
                tabcellline1.ColumnSpan = 20
                tabcellline1.Text = "<hr>"
                tabline1.Controls.Add(tabcellline1)
                tab1.Controls.Add(tabline1)

                '''''''''''''''''''''''''''''''''''''''''''
                Dim tot_wagespayable, tot_deduction, tot_salarypayable, tot_otherdeduction, tot_salarypaid, tot_bonus As Double
                'data
                colors = "#fffcff"
                Dim dr As DataRow
                For Each dr In dt.Rows
                    If IsDBNull(dr(1)) = False Then
                        tot_wagespayable = tot_wagespayable + dr(1)
                    End If
                    If IsDBNull(dr(2)) = False Then
                        tot_deduction = tot_deduction + dr(2)
                    End If
                    If IsDBNull(dr(3)) = False Then
                        tot_salarypayable = tot_salarypayable + dr(3)
                    End If
                    If IsDBNull(dr(4)) = False Then
                        tot_otherdeduction = tot_otherdeduction + dr(4)
                    End If
                    If IsDBNull(dr(5)) = False Then
                        tot_salarypaid = tot_salarypaid + dr(5)
                    End If
                    'If IsDBNull(dr(7)) = False Then
                    '    tot_hpta = tot_hpta + dr(7)
                    'End If
                    If IsDBNull(dr(8)) = False Then
                        tot_bonus = tot_bonus + dr(8)
                    End If
                    If colors.Equals("#fffcff") = True Then
                        colors = "#f8f8f8"
                    Else
                        colors = "#fffcff"
                    End If
                    Dim tabr6 As New TableRow
                    tabr6.Attributes.Add("bgcolor", colors)
                    Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7, tabr6c8 As New TableCell

                    tabr6c1.Attributes.Add("align", "left")
                    tabr6c2.Attributes.Add("align", "right")
                    tabr6c3.Attributes.Add("align", "right")
                    tabr6c4.Attributes.Add("align", "right")
                    tabr6c5.Attributes.Add("align", "right")
                    tabr6c6.Attributes.Add("align", "right")
                    'tabr6c7.Attributes.Add("align", "right")
                    tabr6c8.Attributes.Add("align", "right")

                    tabr6c1.Text = dr(0)
                    tabr6c2.Text = dbnull(dr(1))
                    If IsDBNull(dr(2)) = True Then
                        tabr6c3.Text = dbnull(dr(2))
                    ElseIf dr(2) = 0 Then
                        tabr6c3.Text = dbnull(dr(2))
                    Else
                        tabr6c3.Text = "<a href=deduction_rpt.aspx?empid=" & dr(6) & " >" & dbnull(dr(2)) & "</a>"
                    End If
                    tabr6c4.Text = dbnull(dr(3))


                    If IsDBNull(dr(4)) = True Then
                        tabr6c5.Text = dbnull(dr(4))
                    ElseIf dr(4) = 0 Then
                        tabr6c5.Text = dbnull(dr(4))
                    Else
                        tabr6c5.Text = dbnull(dr(4))
                    End If

                    tabr6c6.Text = dbnull(dr(5))
                    tabr6c7.Text = dbnull(dr(7))
                    If bonuscount = 1 Then
                        tabr6c8.Text = dbnull(dr(8))
                    End If

                    tabr6.Controls.Add(tabr6c1)
                    tabr6.Controls.Add(tabr6c2)
                    tabr6.Controls.Add(tabr6c3)
                    tabr6.Controls.Add(tabr6c4)
                    tabr6.Controls.Add(tabr6c5)
                    If bonuscount = 1 Then
                        tabr6.Controls.Add(tabr6c8)
                    End If

                    tabr6.Controls.Add(tabr6c6)
                    'tabr6.Controls.Add(tabr6c7)

                    tab1.Controls.Add(tabr6)

                Next

                Dim tabline2 As New TableRow
                tabline2.Width = 20
                Dim tabcellline2 As New TableCell
                tabcellline2.ColumnSpan = 20
                tabcellline2.Text = "<hr>"
                tabline2.Controls.Add(tabcellline2)
                tab1.Controls.Add(tabline2)


                Dim totrow As New TableRow
                Dim totc1, totc2, totc3, totc4, totc5, totc6, totc7, totc8 As New TableCell
                totc1.HorizontalAlign = HorizontalAlign.Left
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
                'totc7.ForeColor = Drawing.Color.Red
                totc8.ForeColor = Drawing.Color.Red

                totc1.Text = "TOTAL  :"
                totc2.Text = "<b><u>" & FormatNumber(tot_wagespayable, 2) & "</b></u>"
                totc3.Text = "<b><u>" & FormatNumber(tot_deduction, 2) & "</b></u>"
                totc4.Text = "<b><u>" & FormatNumber(tot_salarypayable, 2) & "</b></u>"
                totc5.Text = "<b><u>" & FormatNumber(tot_otherdeduction, 2) & "</b></u>"
                totc6.Text = "<b><u>" & FormatNumber(tot_salarypaid, 2) & "</b></u>"
                ' totc7.Text = "<b><u>" & FormatNumber(tot_hpta, 2) & "</b></u>"
                totc8.Text = "<b><u>" & FormatNumber(tot_bonus, 2) & "</b></u>"

                totrow.Controls.Add(totc1)
                totrow.Controls.Add(totc2)
                totrow.Controls.Add(totc3)
                totrow.Controls.Add(totc4)
                totrow.Controls.Add(totc5)
                If bonuscount = 1 Then
                    totrow.Controls.Add(totc8)
                End If
                totrow.Controls.Add(totc6)
                ' totrow.Controls.Add(totc7)
                tab1.Controls.Add(totrow)
                Me.Panel1.Controls.Add(tab1)
            End If
        Else
            Panel1.Visible = False
            Panel2.Visible = True
            Dim warnRow As New TableRow
            Dim w1 As New TableCell
            warnRow.Width = 9
            w1.ColumnSpan = 9
            w1.Text = "<font size=2><b>Salary Not Processed/Last Month Data Removed..Please Check After Sometime..!!</b></font>"
            warnRow.Controls.Add(w1)
            tab1.Controls.Add(warnRow)
            Me.Panel2.Controls.Add(tab1)
        End If
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
