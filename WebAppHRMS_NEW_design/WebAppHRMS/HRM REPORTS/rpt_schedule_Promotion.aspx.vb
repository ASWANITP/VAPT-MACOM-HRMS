Imports System.Data.OracleClient
Imports System.Data
Partial Class HRM_Reports_rpt_schedule_Promotion_bd1d42fd5997
    Inherits System.Web.UI.Page
    Dim OHELPER As New helper.oracle.OracleHelper
    Dim DTABLE As DataTable
    Dim COUNT As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim FromStr() As String = (Request.QueryString("from_dt")).ToString.Split("/")
        Dim FromDt As String = Format(CDate(FromStr(1) + "/" + FromStr(0) + "/" + FromStr(2)), "dd-MMM-yyyy")
        Dim ToStr() As String = (Request.QueryString("to_dt")).ToString.Split("/")
        Dim ToDt As String = Format(CDate(ToStr(1) + "/" + ToStr(0) + "/" + ToStr(2)), "dd-MMM-yyyy")
        Dim sql As String = "select td.venue,count(td.training_id) Participants,td.from_time||'--'||td.to_time as time,td.topic,td.training_from as TrainingDate from training_dtl td,training_participant_dtl tpd where td.training_id = tpd.training_id and ((to_date(td.training_from) between to_date('" & FromDt & "') and to_date('" & ToDt & "')) and (to_date(td.training_to) between to_date('" & FromDt & "') and to_date('" & ToDt & "'))) group by td.venue,td.training_id,td.from_time||'--'||td.to_time,td.topic,td.training_from"
        DTABLE = OHELPER.ExecuteDataSet(sql).Tables(0)
        Dim colors As String = "fff7ff"
        Dim tab As New Table
        tab.Attributes.Add("align", "center")
        tab.Attributes.Add("width", "100%")

        Dim row1 As New TableRow
        Dim c11 As New TableCell
        c11.ColumnSpan = 30
        c11.Text = "<font size = 4><b>" & Session("firm_name") & "</b></font>"
        c11.HorizontalAlign = HorizontalAlign.Center
        row1.Controls.Add(c11)
        tab.Controls.Add(row1)

        Dim row2 As New TableRow
        Dim c21, c22 As New TableCell
        c21.ColumnSpan = 15
        c22.ColumnSpan = 15
        c21.Text = "<font size = 2><b>Branch&nbsp;ID : " & Session("branch_id") & "</b></font>"
        c22.Text = "<font size = 2><b>Branch&nbsp;Name : " & Session("branch_name") & "</b></font>"
        c21.HorizontalAlign = HorizontalAlign.Right
        c22.HorizontalAlign = HorizontalAlign.Left
        row2.Controls.Add(c21)
        row2.Controls.Add(c22)
        tab.Controls.Add(row2)

        Dim row3 As New TableRow
        Dim c31 As New TableCell
        c31.ColumnSpan = 18
        c31.Text = "&nbsp;"
        c31.HorizontalAlign = HorizontalAlign.Center
        row3.Controls.Add(c31)
        tab.Controls.Add(row3)

        Dim row4 As New TableRow
        Dim c41, c43 As New TableCell
        c41.ColumnSpan = 15
        c43.ColumnSpan = 15
        c41.Text = "<font size = 2><b>Date : " & Format(Date.Now(), "dd/MMM/yyyy") & "</b></font>"
        c41.HorizontalAlign = HorizontalAlign.Left
        c43.Text = "<font size = 2><b>Time : " & Format(Date.Now(), "hh:mm:ss t") & "</b></font>"
        c43.HorizontalAlign = HorizontalAlign.Right
        row4.Controls.Add(c41)
        row4.Controls.Add(c43)
        tab.Controls.Add(row4)

        Dim row41 As New TableRow
        row41.Attributes.Add("bgcolor", colors)
        Dim c411 As New TableCell
        c411.ColumnSpan = 30
        c411.Text = "<font size = 3><b>SCHEDULE PROMOTION</b></font>"
        c411.HorizontalAlign = HorizontalAlign.Center
        row41.Controls.Add(c411)
        tab.Controls.Add(row41)

        Dim row5 As New TableRow
        Dim c51 As New TableCell
        c51.ColumnSpan = 30
        c51.Text = "<hr align = center width=100%>"
        c51.HorizontalAlign = HorizontalAlign.Center
        row5.Controls.Add(c51)
        tab.Controls.Add(row5)

        Dim row6 As New TableRow
        Dim c61, c62, c63, c64, c65, c66 As New TableCell

        c61.ColumnSpan = 5
        c61.Text = "<b>Sl No."
        c61.HorizontalAlign = HorizontalAlign.Left

        c62.ColumnSpan = 5
        c62.Text = "<b>Venue"
        c62.HorizontalAlign = HorizontalAlign.Left

        c63.ColumnSpan = 5
        c63.Text = "<b>No of Participants"
        c63.HorizontalAlign = HorizontalAlign.Left

        c64.ColumnSpan = 5
        c64.Text = "<b>Time"
        c64.HorizontalAlign = HorizontalAlign.Left

        c65.ColumnSpan = 5
        c65.Text = "<b>Topics"
        c65.HorizontalAlign = HorizontalAlign.Right

        c66.ColumnSpan = 5
        c66.Text = "<b>Date"
        c66.HorizontalAlign = HorizontalAlign.Right

        row6.Controls.Add(c61)
        row6.Controls.Add(c62)
        row6.Controls.Add(c63)
        row6.Controls.Add(c64)
        row6.Controls.Add(c65)
        row6.Controls.Add(c66)
        tab.Controls.Add(row6)

        Dim row7 As New TableRow
        Dim c71 As New TableCell
        c71.ColumnSpan = 30
        c71.Text = "<hr align = center width=100%>"
        c71.HorizontalAlign = HorizontalAlign.Center
        row7.Controls.Add(c71)
        tab.Controls.Add(row7)
        Dim dr As DataRow
        For Each dr In DTABLE.Rows
            COUNT += 1
            If (colors.Equals("fff7ff")) Then
                colors = "#eef9ff"
            Else
                colors = "fff7ff"
            End If
            Dim row8 As New TableRow
            row8.Attributes.Add("bgcolor", colors)
            Dim c81, c82, c83, c84, c85, c86 As New TableCell

            c81.ColumnSpan = 5
            c81.Text = "<font size = 2>" & COUNT & "</font>"
            c81.HorizontalAlign = HorizontalAlign.Left
            row8.Controls.Add(c81)
            tab.Controls.Add(row8)

            c82.ColumnSpan = 5
            c82.Text = "<font size = 2>" & dr(0) & "</font>"
            c82.HorizontalAlign = HorizontalAlign.Left
            row8.Controls.Add(c82)
            tab.Controls.Add(row8)

            c83.ColumnSpan = 5
            c83.Text = "<font size = 2>" & dr(1) & "</font>"
            c83.HorizontalAlign = HorizontalAlign.Left
            row8.Controls.Add(c83)
            tab.Controls.Add(row8)

            c84.ColumnSpan = 5
            c84.Text = "<font size = 2>" & dr(2) & "</font>"
            c84.HorizontalAlign = HorizontalAlign.Left
            row8.Controls.Add(c84)
            tab.Controls.Add(row8)

            c85.ColumnSpan = 5
            c85.Text = "<font size = 2>" & dr(3) & "</font>"
            c85.HorizontalAlign = HorizontalAlign.Right
            row8.Controls.Add(c85)
            tab.Controls.Add(row8)

            c86.ColumnSpan = 5
            c86.Text = "<font size = 2>" & Format(dr(4), "dd-MMM-yyyy") & "</font>"
            c86.HorizontalAlign = HorizontalAlign.Right
            row8.Controls.Add(c86)
            tab.Controls.Add(row8)
        Next
        Panel1.Controls.Add(tab)
    End Sub
End Class


