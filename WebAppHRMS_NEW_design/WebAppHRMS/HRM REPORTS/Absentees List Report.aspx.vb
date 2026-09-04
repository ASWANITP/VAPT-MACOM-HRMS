Imports System.Data
Imports System.Data.OracleClient
Partial Class hrm_final_Absentees_List_Report_49a624712100
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sql = "select distinct td.training_id,em.emp_name,tpd.participant_id,td.training_dt,td.venue,td.trainer from employee_master em,training_dtl td,training_participant_dtl tpd where em.emp_code=tpd.participant_id and tpd.training_id=td.training_id and tpd.status='A' order by td.training_id"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Dim colors As String
        colors = "#fff7ff"
        Dim tab As New Table
        tab.Attributes.Add("width", "95%")
        tab.Attributes.Add("align", "left")
        Dim row1 As New TableRow
        Dim c11 As New TableCell
        c11.ColumnSpan = 26
        c11.Text = "<font size=4><b> " & Session("firm_name") & " </font></b>"
        c11.HorizontalAlign = HorizontalAlign.Center
        row1.Controls.Add(c11)
        tab.Controls.Add(row1)
        Dim row2 As New TableRow
        Dim c21 As New TableCell
        Dim c22 As New TableCell
        c21.ColumnSpan = 15
        c22.ColumnSpan = 15
        c21.Text = "<font size=2><b> Branch_name:" & Session("branch_name") & ", </font></b>"
        c21.HorizontalAlign = HorizontalAlign.Right
        c22.Text = "<font size=2><b> Branch ID:" & Session("branch_id") & " </font></b>"
        c22.HorizontalAlign = HorizontalAlign.Left
        row2.Controls.Add(c21)
        row2.Controls.Add(c22)
        tab.Controls.Add(row2)
        Dim row3 As New TableRow
        Dim c31 As New TableCell
        c31.ColumnSpan = 18
        c31.Text = "&nbsp;"
        row3.Controls.Add(c31)
        tab.Controls.Add(row3)
        Dim row4 As New TableRow
        row4.Attributes.Add("bgcolor", colors)
        Dim c41 As New TableCell
        Dim c42 As New TableCell
        Dim c43 As New TableCell
        c43.ColumnSpan = 10
        c42.ColumnSpan = 10
        c41.ColumnSpan = 10
        'c43.Attributes.Add("width", "")
        c41.Text = "<font size=2><b> Date :" & Format(Date.Now, "dd/MM/yyyy") & "</font></b>"
        c41.HorizontalAlign = HorizontalAlign.Left
        c43.Text = "<font size=2><b>ABSENTEES REPORT</font></b>"
        c43.HorizontalAlign = HorizontalAlign.Center
        c42.Text = "<font size=2><b><div id=txt align=right></div></font></b>"
        c42.HorizontalAlign = HorizontalAlign.Right
        row4.Controls.Add(c41)
        row4.Controls.Add(c43)
        row4.Controls.Add(c42)
        tab.Controls.Add(row4)
        Dim row5 As New TableRow
        Dim c51 As New TableCell
        c51.ColumnSpan = 30
        c51.Attributes.Add("width", "100%")
        c51.Text = "<hr align=center width='100%'>"
        row5.Controls.Add(c51)
        tab.Controls.Add(row5)
        Dim row6 As New TableRow
        Dim c61, c62, c63, c64, c65, c66, c67, c68, c69, c661, c662, c663, c664, c665, c666, c667 As New TableCell
        c61.ColumnSpan = 5
        c61.Text = "<b>Employee&nbsp;Name"
        c61.HorizontalAlign = HorizontalAlign.Left
        c69.ColumnSpan = 5
        c69.Text = "<b>Employee&nbsp;Code"
        c69.HorizontalAlign = HorizontalAlign.Left
        'c62.ColumnSpan = 5
        'c62.Text = "<b>Examination&nbsp;Name"
        'c62.HorizontalAlign = HorizontalAlign.Left
        c667.ColumnSpan = 5
        c667.Text = "<b>Training&nbsp;Detail"
        c667.HorizontalAlign = HorizontalAlign.Left
        c664.ColumnSpan = 5
        c664.Text = "<b>Venue&nbsp;"
        c664.HorizontalAlign = HorizontalAlign.Left
        c665.ColumnSpan = 5
        c665.Text = "<b>Trainer"
        c665.HorizontalAlign = HorizontalAlign.Left
        'c661.ColumnSpan = 2
        'c661.Text = "<b>Branch&nbspDis."
        'c661.HorizontalAlign = HorizontalAlign.Left
        'c662.ColumnSpan = 2
        'c662.Text = "<b>Native&nbspDis."
        'c662.HorizontalAlign = HorizontalAlign.Left
        'c63.ColumnSpan = 2
        'c63.Text = "<b>L.&nbspDays"
        'c63.HorizontalAlign = HorizontalAlign.Left
        'c64.ColumnSpan = 1
        'c64.Text = "<b>L.&nbspAmount"
        'c64.HorizontalAlign = HorizontalAlign.Left
        'c65.ColumnSpan = 2
        'c65.Text = "<b>B.&nbspDays"
        'c65.HorizontalAlign = HorizontalAlign.Left
        'c663.ColumnSpan = 1
        'c663.Text = "<b>B.&nbspAmount"
        'c663.HorizontalAlign = HorizontalAlign.Left
        'c66.ColumnSpan = 2
        'c66.Text = "<b>Out&nbspAmount"
        'c66.HorizontalAlign = HorizontalAlign.Left
        'c67.ColumnSpan = 2
        'c67.Text = "<b>Cla.&nbspAmount"
        'c67.HorizontalAlign = HorizontalAlign.Left
        'c666.ColumnSpan = 2
        'c666.Text = "<b>Given&nbspAmount"
        'c666.HorizontalAlign = HorizontalAlign.Left
        'c68.ColumnSpan = 2
        'c68.Text = "<b>Variance"
        'c68.HorizontalAlign = HorizontalAlign.Right
        row6.Controls.Add(c61)
        row6.Controls.Add(c69)
        'row6.Controls.Add(c62)
        row6.Controls.Add(c667)
        row6.Controls.Add(c664)
        row6.Controls.Add(c665)
        'row6.Controls.Add(c661)
        'row6.Controls.Add(c662)
        'row6.Controls.Add(c63)
        'row6.Controls.Add(c64)
        'row6.Controls.Add(c65)
        'row6.Controls.Add(c663)
        'row6.Controls.Add(c66)
        'row6.Controls.Add(c67)
        'row6.Controls.Add(c666)
        'row6.Controls.Add(c68)

        tab.Controls.Add(row6)
        Dim row8 As New TableRow
        Dim c81 As New TableCell
        c81.ColumnSpan = 30
        ' c81.Attributes.Add("width", "100%")
        c81.Text = "<hr align=center>"
        row8.Controls.Add(c81)
        tab.Controls.Add(row8)
        'Dim cnt, sum As Integer
        'cnt = 0
        'sum = 0
        Dim dr As DataRow
        For Each dr In dt.Rows
            If colors.Equals("#fff7ff") = True Then
                colors = "#eef9ff"
            Else
                colors = "#fff7ff"
            End If
            Dim row7 As New TableRow
            row7.Attributes.Add("bgcolor", colors)
            Dim c71, c72, c73, c74, c75, c76, c77, c78, c79, c771, c772, c773, c774, c775, c776, c777 As New TableCell
            c71.ColumnSpan = 5
            c71.Text = "<font size=2><B>" & dr(1) & "</B></font>"
            c71.HorizontalAlign = HorizontalAlign.Left
            row7.Controls.Add(c71)
            tab.Controls.Add(row7)
            c79.ColumnSpan = 5
            c79.Text = "<font size=2>" & dr(2) & "</font>"
            c79.HorizontalAlign = HorizontalAlign.Left
            row7.Controls.Add(c79)
            tab.Controls.Add(row7)
            c72.ColumnSpan = 5
            c72.Text = "<font size=2>" & Format(dr(3), "dd/MMM/yyyy") & "</font>"
            c72.HorizontalAlign = HorizontalAlign.Left
            row7.Controls.Add(c72)
            tab.Controls.Add(row7)
            c777.ColumnSpan = 5
            c777.Text = "<font size=2>" & dr(4) & "</font>"
            c777.HorizontalAlign = HorizontalAlign.Left
            row7.Controls.Add(c777)
            tab.Controls.Add(row7)
            c771.ColumnSpan = 5
            c771.Text = "<font size=2>" & dr(5) & "</font>"
            c771.HorizontalAlign = HorizontalAlign.Left
            row7.Controls.Add(c771)
            tab.Controls.Add(row7)
            'c772.ColumnSpan = 5
            'c772.Text = "<font size=2>" & dr(5) & "</font>"
            'c772.HorizontalAlign = HorizontalAlign.Left
            'row7.Controls.Add(c772)
            'tab.Controls.Add(row7)
            'c73.ColumnSpan = 2
            'c73.Text = "<font size=2>" & dr(5) & "</font>"
            'c73.HorizontalAlign = HorizontalAlign.Left
            'row7.Controls.Add(c73)
            'tab.Controls.Add(row7)
            'c74.ColumnSpan = 2
            'c74.Text = "<font size=2>" & dr(6) & "</font>"
            'c74.HorizontalAlign = HorizontalAlign.Left
            'row7.Controls.Add(c74)
            'tab.Controls.Add(row7)
            'c75.ColumnSpan = 1
            'c75.Text = "<font size=2>" & dr(7) & "</font>"
            'c75.HorizontalAlign = HorizontalAlign.Center
            'row7.Controls.Add(c75)
            'tab.Controls.Add(row7)
            'c76.ColumnSpan = 2
            'c76.Text = "<font size=2>" & FormatNumber(dr(8), 2) & "</font>"
            'c76.HorizontalAlign = HorizontalAlign.Right
            'row7.Controls.Add(c76)
            'c77.ColumnSpan = 1
            'c77.Text = "<font size=2>" & dr(9) & "</font>"
            'c77.HorizontalAlign = HorizontalAlign.Center
            'row7.Controls.Add(c77)
            'c78.ColumnSpan = 2
            'c78.Text = "<font size=2>" & FormatNumber(dr(10), 2) & "</font>"
            'c78.HorizontalAlign = HorizontalAlign.Right
            'row7.Controls.Add(c78)
            'tab.Controls.Add(row7)

            'c773.ColumnSpan = 2
            'c773.Text = "<font size=2>" & FormatNumber(dr(11), 2) & "</font>"
            'c773.HorizontalAlign = HorizontalAlign.Right
            'row7.Controls.Add(c773)
            'tab.Controls.Add(row7)

            'c774.ColumnSpan = 2
            'c774.Text = "<font size=2>" & FormatNumber(dr(12), 2) & "</font>"
            'c774.HorizontalAlign = HorizontalAlign.Right
            'row7.Controls.Add(c774)
            'tab.Controls.Add(row7)
            'c776.ColumnSpan = 2
            'c776.Text = "<font size=2>" & FormatNumber(dr(13), 2) & "</font>"
            'c776.HorizontalAlign = HorizontalAlign.Right
            'row7.Controls.Add(c776)
            'tab.Controls.Add(row7)
            'c775.ColumnSpan = 2
            'c775.Text = "<font size=2>" & FormatNumber(dr(14), 2) & "</font>"
            'c775.HorizontalAlign = HorizontalAlign.Right
            'row7.Controls.Add(c775)
            'tab.Controls.Add(row7)
            'cnt = cnt + 1
            'sum = sum + dr(13)
        Next
        'Dim row811 As New TableRow
        'Dim c8111 As New TableCell
        'c8111.ColumnSpan = 28
        'c8111.Text = "<hr align=center>"
        'row811.Controls.Add(c8111)
        'tab.Controls.Add(row811)
        'Dim row9 As New TableRow
        'Dim c91, c92 As New TableCell
        'c91.ColumnSpan = 15
        'c91.Text = "<font size=2><b>Count:=" & cnt & "</b></font>"
        'c91.HorizontalAlign = HorizontalAlign.Left
        'row9.Controls.Add(c91)
        'c92.ColumnSpan = 15
        'c92.Text = "<font size=2><b>Outstation Amount:=" & FormatNumber(sum, 2) & "</b></font>"
        'c92.HorizontalAlign = HorizontalAlign.Right
        'row9.Controls.Add(c92)
        'tab.Controls.Add(row9)
        Panel1.Controls.Add(tab)
    End Sub
End Class
