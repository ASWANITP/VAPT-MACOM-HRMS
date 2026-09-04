Imports System.Data
Imports System.Data.OracleClient
Partial Class incentive_allowance_rpt_incentive_allowance_e75f70da1651
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim s As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim user() As String
        ' Session("branch_id") = 5
        '  Session("user_id") = "51007!we"
        user = Session("user_id").ToString.Split("!")

        Dim dt1 As DataTable = oh.ExecuteDataSet("select emp_code,emp_name from employee_master em where em.emp_code=" & user(0)).Tables(0)

        Dim dt As DataTable = oh.ExecuteDataSet("select im.all_name,i.all_amount from incentives_allowances_dtl i,INCENTIVES_ALLOWANCES_MASTER im where i.all_id=im.all_id and i.emp_code=" & user(0)).Tables(0)


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
        tabc2.ForeColor = Drawing.Color.Brown
        'Dim s As String = oh.ExecuteDataSet("select distinct to_char(to_date(sal_dt),'MONTH') from salari").Tables(0).Rows(0)(0)
        Dim dt2 As New DataTable
        dt2 = oh.ExecuteDataSet("select to_char(sal_dt,'MONTH - yyyy') from m_wage where emp_code=" & user(0)).Tables(0)
        If dt2.Rows.Count > 0 Then
            s = dt2.Rows(0)(0)
        Else
            s = "Last Month"
        End If
        tabc2.Text = " INCENTIVE ALLOWANCE DETAILS -" & s & " "

        '  tabc2.Text = "<body align=center color=red><b><font size=3.5> INCENTIVE ALLOWANCE DETAILS -" & s & " " & Now.Year & " </font></b></body>"

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
        Dim tabr5 As New TableRow
        tabr5.Attributes.Add("bgcolor", "#fffcff")
        Dim tabr5c1, tabr5c2 As New TableCell
        tabr5c1.Attributes.Add("align", "left")
        tabr5c2.Attributes.Add("align", "left")
        tabr5c1.ColumnSpan = 10
        tabr5c2.ColumnSpan = 10
        tabr5c1.Text = "<FONT SIZE=3>EMP.CODE  </FONT>"
        tabr5c2.Text = "<FONT SIZE=3>- " & dt1.Rows(0)(0) & "</FONT>"
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
        tabr6c2.Text = "<FONT SIZE=3>- " & dt1.Rows(0)(1) & "</FONT>"
        tabr6.Controls.Add(tabr6c1)
        tabr6.Controls.Add(tabr6c2)
        tab.Controls.Add(tabr6)
        Dim tot As Integer = 0

        If dt.Rows.Count > 0 Then
            Dim dr As DataRow
            For Each dr In dt.Rows
                Dim t1 As New TableRow
                t1.Width = 20
                Dim t11, t12 As New TableCell
                t11.HorizontalAlign = HorizontalAlign.Left
                t12.HorizontalAlign = HorizontalAlign.Left
                t11.ColumnSpan = 10
                t12.ColumnSpan = 10
                t11.Text = dr(0)
                If IsDBNull(dr(1)) Then
                    t12.Text = ""
                Else
                    t12.Text = " - " & dr(1)
                    tot += dr(1)
                End If
                t1.Controls.Add(t11)
                t1.Controls.Add(t12)
                tab.Controls.Add(t1)
            Next
            Dim tablinef As New TableRow
            tablinef.Width = 20
            Dim tabcelllinef As New TableCell
            tabcelllinef.ColumnSpan = 20
            tabcelllinef.Text = "<hr>"
            tablinef.Controls.Add(tabcelllinef)
            tab.Controls.Add(tablinef)

            Dim tabr51 As New TableRow
            tabr51.Attributes.Add("bgcolor", "#fffcff")
            Dim tabr5c11, tabr5c21 As New TableCell
            tabr5c11.Attributes.Add("align", "left")
            tabr5c21.Attributes.Add("align", "left")
            tabr5c11.ColumnSpan = 10
            tabr5c21.ColumnSpan = 10
            tabr5c11.Text = "<FONT SIZE=3>TOTAL  </FONT>"
            tabr5c21.Text = "<FONT SIZE=3>- " & tot & "</FONT>"
            tabr51.Controls.Add(tabr5c11)
            tabr51.Controls.Add(tabr5c21)
            tab.Controls.Add(tabr51)
        Else
            Dim t1 As New TableRow
            t1.Width = 20
            Dim t11 As New TableCell
            t11.ColumnSpan = 20
            t11.Text = "No Details Found "
            t1.Controls.Add(t11)
            tab.Controls.Add(t1)
        End If


        Me.Panel1.Controls.Add(tab)
    End Sub
End Class
