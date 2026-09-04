Imports System.Data
Imports System.Data.OracleClient
Partial Class salary_report_sal_wage_report_individual_047da15c1418
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim s As String
    Dim firmid As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        firmid = Session("firm_id")
        Dim dtsal As New DataTable
        dtsal = oh.ExecuteDataSet("Select count(*) from hrm_salary_release t where t.firm_id=" & firmid & " ").Tables(0)
        If dtsal.Rows(0)(0) = 0 Then
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('Salary Not Released.') ;")
            cl_script.Append(" window.open('../Home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script.ToString, True)
            Exit Sub
        End If


        Dim dt As DataTable
        Dim user() As String
        '     Session("branch_id") = 5
        ' Session("user_id") = "70721!we"
        user = Session("user_id").ToString.Split("!")
        dt = oh.ExecuteDataSet("select s.name as Name,nvl(s.wages_pble,0) as wages_payable,nvl(s.tot_dedu,0)+nvl(s.lop,0) as Total_deduction,nvl(s.wages_pble,0)-nvl(s.tot_dedu,0)-nvl(s.lop,0) as Salary_Payable,nvl(s.cutting,0) as Other_Deduction ,nvl(s.wages_pble,0)-nvl(s.tot_dedu,0)-nvl(s.lop,0)-nvl(s.cutting,0)+nvl(s.bonus,0) as Salary_Paid,s.emp_id,s.hpta,nvl(s.bonus,0) from salari s,firm_master fm,branch_master bm where s.firm_id=fm.firm_id and bm.branch_id=s.branch_id and emp_id=" & user(0) & " union select s.name as Name,nvl(s.wages_pble,0) as wages_payable,nvl(s.tot_dedu,0)+nvl(s.lop,0) as Total_deduction,nvl(s.wages_pble,0)-nvl(s.tot_dedu,0)-nvl(s.lop,0) as Salary_Payable,nvl(s.cutting,0) as Other_Deduction ,nvl(s.wages_pble,0)-nvl(s.tot_dedu,0)-nvl(s.lop,0)-nvl(s.cutting,0)+nvl(s.bonus,0) as Salary_Paid,s.emp_id,s.hpta,nvl(s.bonus,0) from salari s,firm_master fm,before_completion bc where s.firm_id=fm.firm_id and bc.old_id=s.branch_id and emp_id=" & user(0)).Tables(0)
        If dt.Rows.Count = 0 Then
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('No Salary Details Found For This Employee');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''
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
        tabr2.ForeColor = Drawing.Color.Maroon
        Dim tabc2 As New TableCell
        tabc2.ColumnSpan = 20
        tabc2.HorizontalAlign = HorizontalAlign.Center
        tabc2.ForeColor = Drawing.Color.Brown
        s = oh.ExecuteDataSet("select to_char(sal_dt,'MONTH - yyyy') from m_wage where emp_code = " & user(0) & "").Tables(0).Rows(0)(0)
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
        tabc4.Font.Bold = True
        tabc4.Text = "<div id='txt'></div>"
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

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
            tabr10c2.Text = "<FONT SIZE=3>- <a href=other_deduction_rpt.aspx?empid=" & user(0) & ">" & dbnull(dt.Rows(0)(4)) & "</a></FONT>"
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
        Panel1.Controls.Add(tab)
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
