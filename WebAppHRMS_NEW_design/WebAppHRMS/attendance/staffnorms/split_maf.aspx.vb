Imports System.Data
Imports System.Data.OracleClient
Partial Class honormsandshort_honorshsur_a02a88b87787
    Inherits System.Web.UI.Page
    Dim dt, dts As New DataTable
    Dim dr As DataRow
    Dim str, strs As String
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dts1 As DataTable = oh.ExecuteDataSet("select query from hrm_report_master where firm_id=99 and query_id=130").Tables(0)
        Dim strd() As String = dts1.Rows(0)(0).ToString.Split("#")
        Dim hotable As New Table
        Dim header As New TableRow
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        header.Width = 8
        Dim headercell As New TableCell
        headercell.ColumnSpan = 8
        headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headercell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headercell)
        hotable.Controls.Add(header)

        strs = strd(4).Replace("mybranch", Request.QueryString("brid"))
        dts = oh.ExecuteDataSet(strs).Tables(0)

        Dim sheader As New TableRow
        sheader.Width = 8
        sheader.BackColor = Drawing.Color.LightGray
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 8
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        'sheadercell1.Text = "<b><font size=2>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        hotable.Controls.Add(sheader)
        Dim tt As New TableRow
        ' tt.BackColor = Drawing.Color.LightSkyBlue
        tt.Width = 8
        Dim tt1 As New TableCell
        tt1.ColumnSpan = 8
        tt1.HorizontalAlign = HorizontalAlign.Center
        tt1.Text = "<b><font size=2>&nbsp;&nbsp;&nbsp;Staff&nbsp;Report&nbsp;Of&nbsp;" & dts.Rows(0)(0) & "</font></b>"
        tt.Controls.Add(tt1)
        hotable.Controls.Add(tt)

        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 8

        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 2
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 4
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subh.Controls.Add(subcell2)
        subcell3.ColumnSpan = 2
        subcell3.HorizontalAlign = HorizontalAlign.Left
        'subcell3.Text = "<b><font size=2.5>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.Text = "<font size=2><b><div id= txt align= right></div></b></font></div>"
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)
        hotable.Controls.Add(subh)


        Dim linea As New TableRow
        Dim linecella As New TableCell
        linecella.ColumnSpan = 8
        linecella.Text = "<hr>"
        linea.Controls.Add(linecella)
        hotable.Controls.Add(linea)

        Dim colors As String
        colors = "#fff7ff"

      
        Dim field As New TableRow
        field.Width = 8
        field.Attributes.Add("bgcolor", colors)
        Dim f1, f2, f3, f4, f5, f6, f7, f8, f9, f10 As New TableCell

        f1.ColumnSpan = 1
        f1.HorizontalAlign = HorizontalAlign.Center
        f1.Text = "<b><font size=2>&nbsp;&nbsp;SI No&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f1)

        f2.ColumnSpan = 3
        f2.HorizontalAlign = HorizontalAlign.Center
        f2.Text = "<b><font size=2>&nbsp;&nbsp;&nbsp;EMPLOYEE CODE&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f2)

        f3.ColumnSpan = 1
        f3.HorizontalAlign = HorizontalAlign.Center
        f3.Text = "<b><font size=2>&nbsp;&nbsp;EMPLOYEE NAME&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f3)

        f4.ColumnSpan = 1
        f4.HorizontalAlign = HorizontalAlign.Center
        f4.Text = "<b><font size=2>&nbsp;&nbsp;DEPARTMENT&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f4)

        f5.ColumnSpan = 1
        f5.HorizontalAlign = HorizontalAlign.Center
        f5.Text = "<b><font size=2>&nbsp;&nbsp;BRANCH&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f5)

        f6.ColumnSpan = 1
        f6.HorizontalAlign = HorizontalAlign.Center
        f6.Text = "<b><font size=2>&nbsp;&nbsp;FIRM&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f6)


        hotable.Controls.Add(field)

        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        linecell1.ColumnSpan = 8
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        hotable.Controls.Add(line1)
        str = strd(5).Replace("mybranch", Request.QueryString("brid"))
        str = str.Replace("mydep", Request.QueryString("depid"))
        dt = oh.ExecuteDataSet(str).Tables(0)

        Dim i As Integer = 0

        Dim c1 As Integer = 0
        Dim c2 As Integer = 0
        Dim c3 As Integer = 0
        Dim c4 As Integer = 0
        Dim c5 As Integer = 0

        For Each dr In dt.Rows
            If colors.Equals("#fff7ff") = True Then
                colors = "#eef9ff"
            Else
                colors = "#fff7ff"
            End If

            Dim value As New TableRow
            value.Width = 8
            value.Attributes.Add("bgcolor", colors)

            Dim v1, v2, v3, v4, v5, v6 As New TableCell
            i = i + 1

            v1.ColumnSpan = 1
            v1.HorizontalAlign = HorizontalAlign.Center  '"<a href=DrilldownShort.aspx?area_id=" & dr(4) & "&hw=" & dr(12) & ">
            v1.Text = "<font size=2>" & i & "</font>"
            value.Controls.Add(v1)
            hotable.Controls.Add(value)

            v2.ColumnSpan = 3
            v2.HorizontalAlign = HorizontalAlign.Left 'drill down eliminated due to report not needed..norms same as actual..!!
            'v2.Text = "<a href=honormshortdrilldown.aspx?norm_id=" & dr(0) & "><font size=2>&nbsp;" & dr(1) & "&nbsp;&nbsp;</font></a>"
            v2.Text = "<font size=2>&nbsp;" & dr(0) & "&nbsp;&nbsp;</font>"
            value.Controls.Add(v2)
            hotable.Controls.Add(value)


            v3.ColumnSpan = 1
            v3.HorizontalAlign = HorizontalAlign.Right
            v3.Text = "<font size=2>&nbsp;" & dr(1) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v3)
            hotable.Controls.Add(value)
            'c1 += dr(3)

            v4.ColumnSpan = 1
            v4.HorizontalAlign = HorizontalAlign.Right
            v4.Text = "<font size=2>&nbsp;" & dr(2) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v4)
            hotable.Controls.Add(value)
            'c2 += dr(4)

            v5.ColumnSpan = 1
            v5.HorizontalAlign = HorizontalAlign.Right
            v5.Text = "<font size=2>&nbsp;" & dr(3) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v5)
            hotable.Controls.Add(value)
            'c3 += dr(5)

            v6.ColumnSpan = 1
            v6.HorizontalAlign = HorizontalAlign.Right
            v6.Text = "<font size=2>&nbsp;" & dr(4) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v6)
            hotable.Controls.Add(value)
            'c4 += dr(6)

        Next

        Dim line2 As New TableRow
        Dim linecell2 As New TableCell
        linecell2.ColumnSpan = 8
        linecell2.Text = "<hr>"
        line2.Controls.Add(linecell2)
        hotable.Controls.Add(line2)

        Dim total As New TableRow
        total.Width = 8
        total.Attributes.Add("bgcolor", colors)
        Dim to1, d1, d2, d3, d4 As New TableCell
        to1.ColumnSpan = 4
        to1.HorizontalAlign = HorizontalAlign.Center
        'to1.Text = "<b><font size=2>Total:</font></b>"
        total.Controls.Add(to1)

        d1.ColumnSpan = 1
        d1.HorizontalAlign = HorizontalAlign.Right
        'd1.Text = "<b><font size=2>&nbsp;" & c1 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        total.Controls.Add(d1)

        d2.ColumnSpan = 1
        d2.HorizontalAlign = HorizontalAlign.Right
        'd2.Text = "<b><font size=2>&nbsp;" & c2 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        total.Controls.Add(d2)

        d3.ColumnSpan = 1
        d3.HorizontalAlign = HorizontalAlign.Right
        'd3.Text = "<b><font size=2>&nbsp;" & c3 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        total.Controls.Add(d3)

        d4.ColumnSpan = 1
        d4.HorizontalAlign = HorizontalAlign.Right
        'd4.Text = "<b><font size=2>&nbsp;" & c4 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        total.Controls.Add(d4)


        hotable.Controls.Add(total)

        Dim line3 As New TableRow
        Dim linecell3 As New TableCell
        linecell3.ColumnSpan = 8
        'linecell3.Text = "<hr>"
        line3.Controls.Add(linecell3)
        hotable.Controls.Add(line3)

        '//////////////////////////////////////////////////////////////////////
        Dim summary As New TableRow
        Dim s1 As New TableCell
        summary.Width = 8
        s1.ColumnSpan = 8
        's1.Text = "<b><font size=2>Summary&nbsp;:</font></b>"
        s1.HorizontalAlign = HorizontalAlign.Left
        summary.Controls.Add(s1)
        hotable.Controls.Add(summary)

        Dim sum1 As New TableRow
        Dim s2 As New TableCell
        sum1.Width = 8
        s2.ColumnSpan = 8
        's2.Text = "<font size=2>As per norms,Total staff required in Head Office&nbsp;:&nbsp;" & c1 & "&nbsp;</font>"
        s2.HorizontalAlign = HorizontalAlign.Left
        sum1.Controls.Add(s2)
        hotable.Controls.Add(sum1)

        Dim sum2 As New TableRow
        Dim s3 As New TableCell
        sum2.Width = 8
        s3.ColumnSpan = 8
        's3.Text = "<font size=2>At this time, Number of staffs in Head Office&nbsp;:&nbsp;" & c2 & "&nbsp;</font>"
        s3.HorizontalAlign = HorizontalAlign.Left
        sum2.Controls.Add(s3)
        hotable.Controls.Add(sum2)

        Dim sum3 As New TableRow
        Dim s4 As New TableCell
        sum3.Width = 8
        s4.ColumnSpan = 8
        's4.Text = "<font size=2>Shortage of Staffs&nbsp;:&nbsp;" & c3 & "&nbsp;</font>"
        s4.HorizontalAlign = HorizontalAlign.Left
        sum3.Controls.Add(s4)
        hotable.Controls.Add(sum3)

        Dim sum4 As New TableRow
        Dim s5 As New TableCell
        sum4.Width = 8
        s5.ColumnSpan = 8
        's5.Text = "<font size=2>Surplus of Staffs&nbsp;&nbsp;(if any)&nbsp;:&nbsp;" & c4 & "&nbsp;</font>"
        s5.HorizontalAlign = HorizontalAlign.Left
        sum4.Controls.Add(s5)
        hotable.Controls.Add(sum4)

        Dim line4 As New TableRow
        Dim linecell4 As New TableCell
        linecell4.ColumnSpan = 8
        linecell4.Text = "<hr>"
        line4.Controls.Add(linecell4)
        hotable.Controls.Add(line4)
        '////////////////////////////////////////////////////////



        'Dim back As New TableRow
        'back.Width = 8
        'Dim back1 As New TableCell
        'back1.ColumnSpan = 8
        'back1.HorizontalAlign = HorizontalAlign.Center
        'back1.Text = "<a href=../../home.aspx><=&nbsp;&nbsp;Back</a>"
        'back.Controls.Add(back1)
        'hotable.Controls.Add(back)

        'PanelHoNSS.BorderStyle = BorderStyle.Groove
        PanelHoNSS.Controls.Add(hotable)
    End Sub

End Class
