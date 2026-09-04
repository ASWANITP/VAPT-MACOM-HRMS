Imports System.Data
Imports System.Data.OracleClient
Partial Class salary_report_Deduction_rpt_897a6bce9100
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        Dim dt, dt1, dt2 As DataTable
        'Added on 09-03-2017 for RqstId = 12730
        'dt = oh.ExecuteDataSet("select emp_code,name,w_days-l_days as Total_working_days,lop,p_fund as PF,esi,s_w_fund as staff_welfare_fund,l_w_fund as labour_welfare_fund,p_tax as professional_tax,lic,tds,rdded_amt as RD,oth_ded,chitty_ded,kanakadepam,swarnanidhi,pharmacy from m_wage where emp_code=" & Request.QueryString("empid")).Tables(0)
        dt = oh.ExecuteDataSet("select emp_code,name,w_days-l_days as Total_working_days,lop,p_fund as PF,esi,s_w_fund as staff_welfare_fund,l_w_fund as labour_welfare_fund,p_tax as professional_tax,lic,tds,rdded_amt as RD,oth_ded,chitty_ded,kanakadepam,swarnanidhi,pharmacy from m_wage where emp_code=" & user(0) & "").Tables(0)
        'dt1 = oh.ExecuteDataSet("select oth_ded as deduction,remark_ded as remark from employ_sal_add where emp_id=" & user(0) & "").Tables(0)
        dt1 = oh.ExecuteDataSet("select oth_ded as deduction,remark_ded as remark from employ_sal_add  where emp_id=" & user(0) & " and oth_ded<>0").Tables(0)
        dt2 = oh.ExecuteDataSet("select sum(oth_ded) as deduction_sum from employ_sal_add where emp_id =" & user(0) & "").Tables(0)


        If dt.Rows.Count > 0 Then
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tab As New Table
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
            'Added on 09-03-2017 for RqstId = 12730
            ' Dim sdt As DataTable = oh.ExecuteDataSet("select to_char(sal_dt,'MON - yyyy') from m_wage where emp_code=" & Request.QueryString("empid")).Tables(0)
            Dim sdt As DataTable = oh.ExecuteDataSet("select to_char(sal_dt,'MON - yyyy') from m_wage where emp_code=" & user(0) & " ").Tables(0)
            Dim s As String
            If sdt.Rows.Count > 0 Then
                s = sdt.Rows(0)(0)
            Else
                s = "Last Month"
            End If
            tabc2.Text = "<body align=center color=red><b><font size=3.5> DETAILED SALARY STATEMENT -" & s & "</font></b></body>"
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
            tabc4.Font.Bold = True
            tabc4.Text = "<div id='txt'></div>"
            tabr3.Controls.Add(tabc4)
            tab.Controls.Add(tabr3)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim tabr5 As New TableRow
            tabr5.Attributes.Add("bgcolor", "#fffcff")
            Dim tabr5c1, tabr5c2 As New TableCell
            tabr5c1.Attributes.Add("align", "left")
            tabr5c2.Attributes.Add("align", "left")
            tabr5c1.ColumnSpan = 10
            tabr5c2.ColumnSpan = 10


            tabr5c1.Text = "<FONT SIZE=3>EMP.CODE  </FONT>"
            tabr5c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dt.Rows(0)(0) & "</FONT>"
            tabr5.Controls.Add(tabr5c1)
            tabr5.Controls.Add(tabr5c2)
            tab.Controls.Add(tabr5)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tabr6 As New TableRow
            tabr6.Attributes.Add("bgcolor", "#f8f8f8")
            Dim tabr6c1, tabr6c2 As New TableCell
            tabr6c1.Attributes.Add("align", "left")
            tabr6c2.Attributes.Add("align", "left")
            tabr6c1.ColumnSpan = 10
            tabr6c1.ColumnSpan = 10

            tabr6c1.Text = "<FONT SIZE=3>NAME  </FONT>"
            tabr6c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dt.Rows(0)(1) & "</FONT>"
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

            tabr7c1.Text = "<FONT SIZE=3>NO.OF DAYS WORKED  </FONT>"
            tabr7c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dt.Rows(0)(2) & "</FONT>"
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

            tabr8c1.Text = "<FONT SIZE=3>LOP  </FONT>"
            If dt.Rows(0)(3) = 0 Then
                tabr8c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(3)) & "</FONT>"
            Else
                'Added on 09-03-2017 for RqstId = 12730
                ' tabr8c2.Text = "<FONT SIZE=3>- <a href=lossofpay_rpt.aspx?empid=" & user(0) & ">" & dbnull(dt.Rows(0)(3)) & "</a></FONT>"
                tabr8c2.Text = "<FONT SIZE=3>- <a href=lossofpay_rpt.aspx>" & dbnull(dt.Rows(0)(3)) & "</a></FONT>"
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

            tabr9c1.Text = "<FONT SIZE=3>PF  </FONT>"
            tabr9c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(4)) & "</FONT>"
            tabr9.Controls.Add(tabr9c1)
            tabr9.Controls.Add(tabr9c2)
            tab.Controls.Add(tabr9)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim tabr10 As New TableRow
            tabr10.Attributes.Add("bgcolor", "#f8f8f8")
            Dim tabr10c1, tabr10c2 As New TableCell
            tabr10c1.Attributes.Add("align", "left")
            tabr10c2.Attributes.Add("align", "left")
            tabr10c1.ColumnSpan = 10
            tabr10c1.ColumnSpan = 10

            tabr10c1.Text = "<FONT SIZE=3>ESI  </FONT>"
            tabr10c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(5)) & "</FONT>"
            tabr10.Controls.Add(tabr10c1)
            tabr10.Controls.Add(tabr10c2)
            tab.Controls.Add(tabr10)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tabr11 As New TableRow
            tabr11.Attributes.Add("bgcolor", "#fffcff")
            Dim tabr11c1, tabr11c2 As New TableCell
            tabr11c1.Attributes.Add("align", "left")
            tabr11c2.Attributes.Add("align", "left")
            tabr11c1.ColumnSpan = 10
            tabr11c1.ColumnSpan = 10

            tabr11c1.Text = "<FONT SIZE=3>STAFF WELFARE FUND  </FONT>"
            tabr11c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(6)) & "</FONT>"
            tabr11.Controls.Add(tabr11c1)
            tabr11.Controls.Add(tabr11c2)
            tab.Controls.Add(tabr11)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tabr12 As New TableRow
            tabr12.Attributes.Add("bgcolor", "#f8f8f8")
            Dim tabr12c1, tabr12c2 As New TableCell
            tabr12c1.Attributes.Add("align", "left")
            tabr12c2.Attributes.Add("align", "left")
            tabr12c1.ColumnSpan = 10
            tabr12c1.ColumnSpan = 10

            tabr12c1.Text = "<FONT SIZE=3>LABOUR WELFARE FUND  </FONT>"
            tabr12c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(7)) & "</FONT>"
            tabr12.Controls.Add(tabr12c1)
            tabr12.Controls.Add(tabr12c2)
            tab.Controls.Add(tabr12)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tabr13 As New TableRow
            tabr13.Attributes.Add("bgcolor", "#fffcff")
            Dim tabr13c1, tabr13c2 As New TableCell
            tabr13c1.Attributes.Add("align", "left")
            tabr13c2.Attributes.Add("align", "left")
            tabr13c1.ColumnSpan = 10
            tabr13c1.ColumnSpan = 10

            tabr13c1.Text = "<FONT SIZE=3>PROFESSIONAL TAX  </FONT>"
            tabr13c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(8)) & "</FONT>"
            tabr13.Controls.Add(tabr13c1)
            tabr13.Controls.Add(tabr13c2)
            tab.Controls.Add(tabr13)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim tabr14 As New TableRow
            tabr14.Attributes.Add("bgcolor", "#f8f8f8")
            Dim tabr14c1, tabr14c2 As New TableCell
            tabr14c1.Attributes.Add("align", "left")
            tabr14c2.Attributes.Add("align", "left")
            tabr14c1.ColumnSpan = 10
            tabr14c1.ColumnSpan = 10

            tabr14c1.Text = "<FONT SIZE=3>LIC  </FONT>"
            tabr14c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(9)) & "</FONT>"
            tabr14.Controls.Add(tabr14c1)
            tabr14.Controls.Add(tabr14c2)
            tab.Controls.Add(tabr14)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tabr15 As New TableRow
            tabr15.Attributes.Add("bgcolor", "#fffcff")
            Dim tabr15c1, tabr15c2 As New TableCell
            tabr15c1.Attributes.Add("align", "left")
            tabr15c2.Attributes.Add("align", "left")
            tabr15c1.ColumnSpan = 10
            tabr15c1.ColumnSpan = 10

            tabr15c1.Text = "<FONT SIZE=3>TDS  </FONT>"
            tabr15c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(10)) & "</FONT>"
            tabr15.Controls.Add(tabr15c1)
            tabr15.Controls.Add(tabr15c2)
            tab.Controls.Add(tabr15)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim tabr16 As New TableRow
            tabr16.Attributes.Add("bgcolor", "#f8f8f8")
            Dim tabr16c1, tabr16c2 As New TableCell
            tabr16c1.Attributes.Add("align", "left")
            tabr16c2.Attributes.Add("align", "left")
            tabr16c1.ColumnSpan = 10
            tabr16c1.ColumnSpan = 10

            tabr16c1.Text = "<FONT SIZE=3>RD  </FONT>"
            tabr16c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(11)) & "</FONT>"
            tabr16.Controls.Add(tabr16c1)
            tabr16.Controls.Add(tabr16c2)
            tab.Controls.Add(tabr16)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim tabr17 As New TableRow
            tabr17.Attributes.Add("bgcolor", "#f8f8f8")
            Dim tabr17c1, tabr17c2, tabr19c2, tabr17c3 As New TableCell
            tabr17c1.Attributes.Add("align", "left")
            tabr17c2.Attributes.Add("align", "left")
            tabr17c3.Attributes.Add("align", "left")
            tabr17c1.ColumnSpan = 10
            tabr17c1.ColumnSpan = 10
            tabr17c1.ColumnSpan = 10



            tabr17c1.Text = "<FONT SIZE=3>OTHER DEDUCTIONS</FONT>"

            'If dt1.Rows.Count > 0 AndAlso Not IsDBNull(dt1.Rows(0)(1)) Then
            '    If dt1.Rows(0)(1).ToString() <> "0" Then
            '        tabr17c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt1.Rows(0)(0)) & "&nbsp;(&nbsp;" & dt1.Rows(0)(1) & "&nbsp;)</FONT>"
            '    Else
            '        tabr17c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt1.Rows(0)(0)) & "</FONT>"
            '    End If
            '    'Else
            '    '    tabr17c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt1.Rows(0)(0)) & "</FONT>"
            'End If

            'If dt1.Rows.Count > 0 Then
            '    If dt1.Rows(0)(1).ToString() <> "0" Then
            '        tabr17c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt1.Rows(0)(0)) & "&nbsp;(&nbsp;" & dt1.Rows(0)(1) & "&nbsp;)</FONT>"
            '        tabr19c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt1.Rows(1)(0)) & "&nbsp;(&nbsp;" & dt1.Rows(1)(1) & "&nbsp;)</FONT>"
            '    Else
            '        tabr17c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp; 0.00</FONT>"
            '    End If
            '    'Else
            '    '    tabr17c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt1.Rows(0)(0)) & "</FONT>"
            'End If

            If dt1.Rows.Count > 0 Then
                tabr17c2.Text = "<FONT SIZE=3>- <a href=oth_deduction.aspx?id=" & 16 & ">" & dbnull(dt2.Rows(0)(0)) & "</a></FONT>"

            Else
                tabr17c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp; 0.00</FONT>"

            End If

            tabr17.Controls.Add(tabr17c1)
            tabr17.Controls.Add(tabr17c2)
            tabr17.Controls.Add(tabr19c2)
            tab.Controls.Add(tabr17)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Dim tabr19 As New TableRow
            'tabr19.Attributes.Add("bgcolor", "#f8f8f8")
            'Dim tabr19c1, tabr19c2 As New TableCell
            'tabr19c1.Attributes.Add("align", "left")
            'tabr19c2.Attributes.Add("align", "left")
            'tabr19c1.ColumnSpan = 10
            'tabr19c1.ColumnSpan = 10

            'tabr19c1.Text = "<FONT SIZE=3>REMARK</FONT>"
            'If dt1.Rows.Count > 0 Then
            '    tabr19c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & (dt1.Rows(0)(1)) & "</FONT>"

            'End If
            'tabr19.Controls.Add(tabr19c1)
            'tabr19.Controls.Add(tabr19c2)
            'tab.Controls.Add(tabr19)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Dim tabr171 As New TableRow
            'tabr171.Attributes.Add("bgcolor", "#fffcff")
            'Dim tabr171c1, tabr171c2 As New TableCell
            'tabr171c1.Attributes.Add("align", "left")
            'tabr171c2.Attributes.Add("align", "left")
            'tabr171c1.ColumnSpan = 10
            'tabr171c1.ColumnSpan = 10

            'tabr171c1.Text = "<FONT SIZE=3>CHITTY DEDUCTION  </FONT>"
            'tabr171c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(13)) & "</FONT>"
            'tabr171.Controls.Add(tabr171c1)
            'tabr171.Controls.Add(tabr171c2)
            'tab.Controls.Add(tabr171)
            '''''''''''''''''''
            'Dim tabr172 As New TableRow
            'tabr172.Attributes.Add("bgcolor", "#fffcff")
            'Dim tabr172c1, tabr172c2 As New TableCell
            'tabr172c1.Attributes.Add("align", "left")
            'tabr172c2.Attributes.Add("align", "left")
            'tabr172c1.ColumnSpan = 10
            'tabr172c1.ColumnSpan = 10

            'tabr172c1.Text = "<FONT SIZE=3>KANAKADEEPAM </FONT>"
            'tabr172c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(14)) & "</FONT>"
            'tabr172.Controls.Add(tabr172c1)
            'tabr172.Controls.Add(tabr172c2)
            'tab.Controls.Add(tabr172)
            '''''''''''''''''''
            'Dim tabr173 As New TableRow
            'tabr173.Attributes.Add("bgcolor", "#fffcff")
            'Dim tabr173c1, tabr173c2 As New TableCell
            'tabr173c1.Attributes.Add("align", "left")
            'tabr173c2.Attributes.Add("align", "left")
            'tabr173c1.ColumnSpan = 10
            'tabr173c1.ColumnSpan = 10

            'tabr173c1.Text = "<FONT SIZE=3>SWARNANIDHI</FONT>"
            'tabr173c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(15)) & "</FONT>"
            'tabr173.Controls.Add(tabr173c1)
            'tabr173.Controls.Add(tabr173c2)
            'tab.Controls.Add(tabr173)
            '''''''''''''''''''

            'Dim tabr17 As New TableRow
            'tabr17.Attributes.Add("bgcolor", "#f8f8f8")
            'Dim tabr17c1, tabr17c2 As New TableCell
            'tabr17c1.Attributes.Add("align", "left")
            'tabr17c2.Attributes.Add("align", "left")
            'tabr17c1.ColumnSpan = 10
            'tabr17c1.ColumnSpan = 10

            'tabr17c1.Text = "<FONT SIZE=3>OTHER DEDUCTION  </FONT>"
            'tabr17c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(12)) & "</FONT>"
            'tabr17.Controls.Add(tabr17c1)
            'tabr17.Controls.Add(tabr17c2)
            'tab.Controls.Add(tabr17)
            '''''''''''''''''''
            Dim tabr18 As New TableRow
            tabr18.Attributes.Add("bgcolor", "#f8f8f8")
            Dim tabr18c1, tabr18c2 As New TableCell
            tabr18c1.Attributes.Add("align", "left")
            tabr18c2.Attributes.Add("align", "left")
            tabr18c1.ColumnSpan = 10
            tabr18c1.ColumnSpan = 10

            tabr18c1.Text = "<FONT SIZE=3>CASH PAYMENT</FONT>"
            tabr18c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(14) + dt.Rows(0)(15) + dt.Rows(0)(16)) & "</FONT>"
            tabr18.Controls.Add(tabr18c1)
            tabr18.Controls.Add(tabr18c2)
            tab.Controls.Add(tabr18)
            ''''''''''''''''''



            Dim tabr161 As New TableRow
            tabr161.Attributes.Add("bgcolor", "#fffcff")
            Dim tabr16c11 As New TableCell
            tabr16c11.Attributes.Add("align", "center")
            tabr16c11.ColumnSpan = 20
            'Added on 09-03-2017 for RqstId = 12730
            ' tabr16c11.Text = "<a href=sal_wage_rpt.aspx?empid=" & user(0) & "><font color=blue>BACK</font ></a>"
            tabr16c11.Text = "<a href=sal_wage_rpt.aspx><font color=blue>BACK</font ></a>"
            tabr161.Controls.Add(tabr16c11)
            tab.Controls.Add(tabr161)
            Me.Panel1.Controls.Add(tab)
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
