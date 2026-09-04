Imports System.Data
Imports System.Data.OracleClient
Partial Class payroll_oth_deduction_f75f3d2f8852
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        Dim dt1 As DataTable

       dt1 = oh.ExecuteDataSet("select oth_ded as deduction,remark_ded as remark from employ_sal_add  where emp_id=" & user(0) & " and oth_ded<>0").Tables(0)

        If dt1.Rows.Count > 0 Then
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tab As New Table
            tab.Attributes.Add("width", "100%")
            Dim tabr1 As New TableRow
            tabr1.Width = 20
            tabr1.Attributes.Add("bgcolor", "gold")
            tabr1.BorderStyle = BorderStyle.Solid '
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
            tabr5c1.Attributes.Add("align", "center")
            tabr5c2.Attributes.Add("align", "center")
            tabr5c1.ColumnSpan = 10
            tabr5c2.ColumnSpan = 10


            tabr5c1.Text = "<FONT SIZE=3 COLOR=""#ff0000"">&nbsp;&nbsp;AMOUNT</FONT>"
            tabr5c2.Text = "<FONT SIZE=3 COLOR=""#ff0000"">&nbsp;&nbsp;REMARK</FONT>"
            tabr5.Controls.Add(tabr5c1)
            tabr5.Controls.Add(tabr5c2)
            tab.Controls.Add(tabr5)


            
            For Each row As DataRow In dt1.Rows
                Dim tabr7 As New TableRow
                tabr5.Attributes.Add("bgcolor", "#f8f8f8")

                Dim tabr7c1, tabr7c2 As New TableCell
                tabr7c1.Attributes.Add("align", "center")
                tabr7c2.Attributes.Add("align", "center")
                tabr7c1.ColumnSpan = 10
                tabr7c2.ColumnSpan = 10

                tabr7c1.Text = "<FONT SIZE=3>&nbsp;&nbsp;" & row("deduction") & "</FONT>"
                tabr7c2.Text = "<FONT SIZE=3>&nbsp;&nbsp;" & row("remark") & "</FONT>"
                tabr7.Controls.Add(tabr7c1)
                tabr7.Controls.Add(tabr7c2)
                tab.Controls.Add(tabr7)
            Next


            'Dim tabr18 As New TableRow
            'tabr18.Attributes.Add("bgcolor", "#f8f8f8")
            'Dim tabr18c1, tabr18c2 As New TableCell
            'tabr18c1.Attributes.Add("align", "left")
            'tabr18c2.Attributes.Add("align", "left")
            'tabr18c1.ColumnSpan = 10
            'tabr18c1.ColumnSpan = 10

            'tabr18c1.Text = "<FONT SIZE=3>TOTAL</FONT>"
            'tabr18c2.Text = "<FONT SIZE=3>-&nbsp;&nbsp;" & dbnull(dt.Rows(0)(14) + dt.Rows(0)(15) + dt.Rows(0)(16)) & "</FONT>"
            'tabr18.Controls.Add(tabr18c1)
            'tabr18.Controls.Add(tabr18c2)
            'tab.Controls.Add(tabr18)

            Dim tabr8 As New TableRow
            tabr8.Attributes.Add("bgcolor", "#fffcff")
            Dim tabr8c1 As New TableCell
            tabr8c1.Attributes.Add("align", "center")
            tabr8c1.ColumnSpan = 20
            'Added on 09-03-2017 for RqstId = 12730
            ' tabr16c11.Text = "<a href=sal_wage_rpt.aspx?empid=" & user(0) & "><font color=blue>BACK</font ></a>"
            tabr8c1.Text = "<a href=deduction_rpt.aspx><font color=blue>BACK</font ></a>"
            tabr8.Controls.Add(tabr8c1)
            tab.Controls.Add(tabr8)
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

