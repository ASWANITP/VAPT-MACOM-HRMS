Imports System.Data
Imports System.Data.OracleClient
Partial Class salary_report_Deduction_rpt_3699043d5551
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable

        dt = oh.ExecuteDataSet("select emp_id,name,w_days-l_days as Total_working_days,lop,p_fund as PF,esi,s_w_fund as staff_welfare_fund,l_w_fund as labour_welfare_fund,p_tax as professional_tax,lic,tds,rdded_amt as RD,oth_ded from salari where emp_id=" & Request.QueryString("empid")).Tables(0)
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
        Dim s As String = oh.ExecuteDataSet("select  to_char(sal_dt,'MONTH - yyyy') from m_wage where emp_code=" & Request.QueryString("empid")).Tables(0).Rows(0)(0)
        tabc2.Text = "<body align=center color=red><b><font size=3.5> DETAILED SALARY STATEMENT -" & s & " </font></b></body>"
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
        tabr8c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(3)) & "</FONT>"
        '   tabr8c2.Text = "<FONT SIZE=3>-&nbsp; " & dbnull(dt.Rows(0)(3)) & "</a></FONT>"

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
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim tabr17 As New TableRow
        tabr17.Attributes.Add("bgcolor", "#fffcff")
        Dim tabr17c1, tabr17c2 As New TableCell
        tabr17c1.Attributes.Add("align", "left")
        tabr17c2.Attributes.Add("align", "left")
        tabr17c1.ColumnSpan = 10
        tabr17c1.ColumnSpan = 10

        tabr17c1.Text = "<FONT SIZE=3>OTHER DEDUCTION  </FONT>"
        tabr17c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(12)) & "</FONT>"
        tabr17.Controls.Add(tabr17c1)
        tabr17.Controls.Add(tabr17c2)
        tab.Controls.Add(tabr17)
        ''''''''''''''''''

        Me.Panel1.Controls.Add(tab)

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
