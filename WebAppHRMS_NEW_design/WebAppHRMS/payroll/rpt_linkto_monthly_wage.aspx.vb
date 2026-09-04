Imports System.Data
Imports System.Data.OracleClient
Partial Class salary_report_annual_report_rpt_linkto_monthly_wage_58847ada2656
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper
    Dim script1 As New StringBuilder
    Dim dt As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dat As Date = Me.Request.QueryString("saldate")
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        Dim dtt As DataTable = oh.ExecuteDataSet("select count(*) from m_wage m where m.sal_dt='" & Format(CDate(Me.Request.QueryString("saldate")), "dd/MMM/yyyy") & "'").Tables(0)
        If dtt.Rows(0)(0) = 0 Then
            Dim dtt1 As DataTable = oh.ExecuteDataSet("select count(*) from m_wage_his m where m.sal_dt='" & Format(CDate(Me.Request.QueryString("saldate")), "dd/MMM/yyyy") & "'").Tables(0)
            If dtt1.Rows(0)(0) = 0 Then
                script1.Append("        alert('No Details Found');")
                script1.Append("window.open('rpt_individual_salary_report.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
                Exit Sub
            Else
                dt = oh.ExecuteDataSet("select emp_code,name,w_days-l_days as Total_working_days,lop,p_fund as PF,esi,s_w_fund as staff_welfare_fund,l_w_fund as labour_welfare_fund,p_tax as professional_tax,lic,tds,rdded_amt as RD,oth_ded,chitty_ded from m_wage_his s where emp_code=" & user(0) & " and s.sal_dt=to_date('" & Format(dat, "dd/MMM/yyyy") & "')").Tables(0)
            End If

        Else
            dt = oh.ExecuteDataSet("select emp_code,name,w_days-l_days as Total_working_days,lop,p_fund as PF,esi,s_w_fund as staff_welfare_fund,l_w_fund as labour_welfare_fund,p_tax as professional_tax,lic,tds,rdded_amt as RD,oth_ded,chitty_ded from m_wage s where emp_code=" & user(0) & " and s.sal_dt=to_date('" & Format(dat, "dd/MMM/yyyy") & "')").Tables(0)
        End If

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
        tabc2.Text = "<body align=center color=red><b><font size=3.5> DETAILED SALARY STATEMENT -" & Format(dat, "MMM/yyyy") & "</font></b></body>"
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
        tabr5c1.Attributes.Add("align", "center")
        tabr5c2.Attributes.Add("align", "center")
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
        tabr6c1.Attributes.Add("align", "center")
        tabr6c2.Attributes.Add("align", "center")
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
        tabr7c1.Attributes.Add("align", "center")
        tabr7c2.Attributes.Add("align", "center")
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
        tabr8c1.Attributes.Add("align", "center")
        tabr8c2.Attributes.Add("align", "center")
        tabr8c1.ColumnSpan = 10
        tabr8c1.ColumnSpan = 10

        tabr8c1.Text = "<FONT SIZE=3>LOP  </FONT>"
        If dt.Rows(0)(3) = 0 Then
            tabr8c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(3)) & "</FONT>"
        Else
            tabr8c2.Text = "<FONT SIZE=3>- " & dbnull(dt.Rows(0)(3)) & "</FONT>"
        End If

        tabr8.Controls.Add(tabr8c1)
        tabr8.Controls.Add(tabr8c2)
        tab.Controls.Add(tabr8)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabr9 As New TableRow
        tabr9.Attributes.Add("bgcolor", "#fffcff")
        Dim tabr9c1, tabr9c2 As New TableCell
        tabr9c1.Attributes.Add("align", "center")
        tabr9c2.Attributes.Add("align", "center")
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
        tabr10c1.Attributes.Add("align", "center")
        tabr10c2.Attributes.Add("align", "center")
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
        tabr11c1.Attributes.Add("align", "center")
        tabr11c2.Attributes.Add("align", "center")
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
        tabr12c1.Attributes.Add("align", "center")
        tabr12c2.Attributes.Add("align", "center")
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
        tabr13c1.Attributes.Add("align", "center")
        tabr13c2.Attributes.Add("align", "center")
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
        tabr14c1.Attributes.Add("align", "center")
        tabr14c2.Attributes.Add("align", "center")
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
        tabr15c1.Attributes.Add("align", "center")
        tabr15c2.Attributes.Add("align", "center")
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
        tabr16c1.Attributes.Add("align", "center")
        tabr16c2.Attributes.Add("align", "center")
        tabr16c1.ColumnSpan = 10
        tabr16c1.ColumnSpan = 10

        tabr16c1.Text = "<FONT SIZE=3>RD  </FONT>"
        tabr16c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(11)) & "</FONT>"
        tabr16.Controls.Add(tabr16c1)
        tabr16.Controls.Add(tabr16c2)
        tab.Controls.Add(tabr16)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabr171 As New TableRow
        tabr171.Attributes.Add("bgcolor", "#fffcff")
        Dim tabr171c1, tabr171c2 As New TableCell
        tabr171c1.Attributes.Add("align", "center")
        tabr171c2.Attributes.Add("align", "center")
        tabr171c1.ColumnSpan = 10
        tabr171c1.ColumnSpan = 10

        tabr171c1.Text = "<FONT SIZE=3>CHITTY DEDUCTION  </FONT>"
        tabr171c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(13)) & "</FONT>"
        tabr171.Controls.Add(tabr171c1)
        tabr171.Controls.Add(tabr171c2)
        tab.Controls.Add(tabr171)
        ''''''''''''''''''
        Dim tabr17 As New TableRow
        tabr17.Attributes.Add("bgcolor", "#f8f8f8")
        Dim tabr17c1, tabr17c2 As New TableCell
        tabr17c1.Attributes.Add("align", "center")
        tabr17c2.Attributes.Add("align", "center")
        tabr17c1.ColumnSpan = 10
        tabr17c1.ColumnSpan = 10

        tabr17c1.Text = "<FONT SIZE=3>OTHER DEDUCTION  </FONT>"
        tabr17c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(12)) & "</FONT>"
        tabr17.Controls.Add(tabr17c1)
        tabr17.Controls.Add(tabr17c2)
        tab.Controls.Add(tabr17)
        ''''''''''''''''''

        Dim tabr161 As New TableRow
        tabr161.Attributes.Add("bgcolor", "#fffcff")
        Dim tabr16c11 As New TableCell
        tabr16c11.Attributes.Add("align", "center")
        tabr16c11.ColumnSpan = 20
        tabr16c11.Text = "<a href=rpt_individual_salary_report.aspx><font color=blue>BACK</font ></a>"
        tabr161.Controls.Add(tabr16c11)
        tab.Controls.Add(tabr161)
        Me.Panel1.Controls.Add(tab)
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
