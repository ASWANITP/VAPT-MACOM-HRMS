Imports System.Data
Imports System.Data.OracleClient
Partial Class honormsandshort_honorshsur_a02a88b87045
    Inherits System.Web.UI.Page
    Dim dt, dts As New DataTable
    Dim dr As DataRow
    Dim str, strs As String
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dts1 As DataTable = oh.ExecuteDataSet("select query from hrm_report_master where firm_id=99 and query_id=134").Tables(0)
        Dim strd() As String = dts1.Rows(0)(0).ToString.Split("#")
        Dim hotable As New Table
        hotable.Attributes.Add("width", "100%")
        Dim header As New TableRow
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        header.Width = 15
        Dim headercell As New TableCell
        headercell.ColumnSpan = 15
        headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headercell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headercell)
        hotable.Controls.Add(header)

        strs = strd(3).Replace("mybranch", 0)
        dts = oh.ExecuteDataSet(strs).Tables(0)

        Dim sheader As New TableRow
        sheader.Width = 15
        sheader.BackColor = Drawing.Color.LightGray
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 15
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        'sheadercell1.Text = "<b><font size=2>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        hotable.Controls.Add(sheader)
        Dim tt As New TableRow
        ' tt.BackColor = Drawing.Color.LightSkyBlue
        tt.Width = 15
        Dim tt1 As New TableCell
        tt1.ColumnSpan = 15
        tt1.HorizontalAlign = HorizontalAlign.Center
        tt1.Text = "<b><font size=2>&nbsp;&nbsp;&nbsp;Staff&nbsp;Shortages&nbsp;and&nbsp;Surplus&nbsp;Report&nbsp;Of&nbsp;" & dts.Rows(0)(0) & "</font></b>"
        tt.Controls.Add(tt1)
        hotable.Controls.Add(tt)

        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 15

        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 4
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 2
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
        linecella.ColumnSpan = 15
        linecella.Text = "<hr>"
        linea.Controls.Add(linecella)
        hotable.Controls.Add(linea)

        Dim colors As String
        colors = "#fff7ff"


        Dim field As New TableRow
        field.Width = 3
        field.Attributes.Add("bgcolor", colors)
        Dim f1, f2, f3, f4, f5, f6, f7, f8, f9, f10 As New TableCell

        f1.ColumnSpan = 1
        f1.HorizontalAlign = HorizontalAlign.Center
        f1.Text = "<b><font size=2>&nbsp;&nbsp;SI No&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f1)

        f2.ColumnSpan = 3
        f2.HorizontalAlign = HorizontalAlign.Center
        f2.Text = "<b><font size=2>&nbsp;&nbsp;&nbsp;Department&nbsp;&nbsp;Name&nbsp;</font></b>"
        field.Controls.Add(f2)

        f3.ColumnSpan = 1
        f3.HorizontalAlign = HorizontalAlign.Center
        f3.Text = "<b><font size=2>&nbsp;&nbsp;Norms&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f3)

        f4.ColumnSpan = 1
        f4.HorizontalAlign = HorizontalAlign.Center
        f4.Text = "<b><font size=2>&nbsp;&nbsp;Live&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f4)

        f5.ColumnSpan = 1
        f5.HorizontalAlign = HorizontalAlign.Center
        f5.Text = "<b><font size=2>&nbsp;&nbsp;Short&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f5)

        f6.ColumnSpan = 1
        f6.HorizontalAlign = HorizontalAlign.Center
        f6.Text = "<b><font size=2>&nbsp;&nbsp;Surplus&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f6)

        f7.ColumnSpan = 1
        f7.HorizontalAlign = HorizontalAlign.Center
        f7.Text = "<b><font size=2>&nbsp;&nbsp;Notice Period&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f7)

        hotable.Controls.Add(field)

        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        linecell1.ColumnSpan = 15
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        hotable.Controls.Add(line1)
        '                   0            1            2          3       ---------------------------4---------------------------------------------    -----------------------------------------5----------------------------------------    eliminated Boerd of Directors...norm id=32 on 06-12-08           
        'str = "select distinct sn.norm_id,  sn.dept_name,  sn.requirement,  sn.actual,  case  when sn.requirement - sn.actual > 0 then  sn.requirement - sn.actual  else  0  end as short,  case  when sn.actual - sn.requirement > 0 then  sn.actual - sn.requirement  else  0  end as surplus  from staff_norm_ho sn,employee_master e,employ_firm f  where sn.norm_id <> 32  and e.department_id=sn.dep_id  and e.status_id=1  and e.emp_code=f.emp_code  and f.firm_id=" & Session("firm_id") & "  order by sn.dept_name"
        str = strd(3).Replace("mybranch", 0)
        dt = oh.ExecuteDataSet(str).Tables(0)

        Dim i As Integer = 0

        Dim c1 As Integer = 0
        Dim c2 As Integer = 0
        Dim c3 As Integer = 0
        Dim c4 As Integer = 0
        Dim c5 As Integer = 0
        Dim c6 As Integer = 0
        Dim c7 As Integer = 0
        Dim c8 As Integer = 0
        Dim c9 As Integer = 0
        Dim c10 As Integer = 0


        For Each dr In dt.Rows
            If colors.Equals("#fff7ff") = True Then
                colors = "#eef9ff"
            Else
                colors = "#fff7ff"
            End If

            Dim value As New TableRow
            value.Width = 8
            value.Attributes.Add("bgcolor", colors)

            Dim v1, v2, v3, v4, v5, v6, v7 As New TableCell
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
            v3.Text = "<font size=2>&nbsp;" & dr(2) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v3)
            hotable.Controls.Add(value)
            c1 += dr(2)

            v4.ColumnSpan = 1
            v4.HorizontalAlign = HorizontalAlign.Right
            v4.Text = "<font size=2>&nbsp;<a href='split_mac.aspx?depid=" & dr(1) & "&depname=" & dr(0) & "'>" & dr(3) & "</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v4)
            hotable.Controls.Add(value)
            c2 += dr(3)

            v5.ColumnSpan = 1
            v5.HorizontalAlign = HorizontalAlign.Right
            v5.Text = "<font size=2>&nbsp;" & dr(4) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v5)
            hotable.Controls.Add(value)
            c3 += dr(4)

            v6.ColumnSpan = 1
            v6.HorizontalAlign = HorizontalAlign.Right
            v6.Text = "<font size=2>&nbsp;" & dr(5) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v6)
            hotable.Controls.Add(value)
            c4 += dr(5)


            v7.ColumnSpan = 1
            v7.HorizontalAlign = HorizontalAlign.Right
            v7.Text = "<font size=2>&nbsp;" & dr(6) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v7)
            hotable.Controls.Add(value)
            c5 += dr(6)

        Next

        Dim line2 As New TableRow
        Dim linecell2 As New TableCell
        linecell2.ColumnSpan = 15
        linecell2.Text = "<hr>"
        line2.Controls.Add(linecell2)
        hotable.Controls.Add(line2)

        Dim total As New TableRow
        total.Width = 8
        total.Attributes.Add("bgcolor", colors)
        Dim to1, d1, d2, d3, d4, d5, d6, d7, d8 As New TableCell
        to1.ColumnSpan = 4
        to1.HorizontalAlign = HorizontalAlign.Center
        to1.Text = "<b><font size=2>Total:</font></b>"
        total.Controls.Add(to1)

        d1.ColumnSpan = 1
        d1.HorizontalAlign = HorizontalAlign.Right
        d1.Text = "<b><font size=2>&nbsp;" & c1 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        total.Controls.Add(d1)

        d2.ColumnSpan = 1
        d2.HorizontalAlign = HorizontalAlign.Right
        d2.Text = "<b><font size=2>&nbsp;" & c2 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        total.Controls.Add(d2)

        d3.ColumnSpan = 1
        d3.HorizontalAlign = HorizontalAlign.Right
        d3.Text = "<b><font size=2>&nbsp;" & c3 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        total.Controls.Add(d3)

        d4.ColumnSpan = 1
        d4.HorizontalAlign = HorizontalAlign.Right
        d4.Text = "<b><font size=2>&nbsp;" & c4 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        total.Controls.Add(d4)

        d5.ColumnSpan = 1
        d5.HorizontalAlign = HorizontalAlign.Center
        d5.Text = "<b><font size=2>&nbsp;" & c5 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        total.Controls.Add(d5)



        hotable.Controls.Add(total)

        Dim line3 As New TableRow
        Dim linecell3 As New TableCell
        linecell3.ColumnSpan = 15
        linecell3.Text = "<hr>"
        line3.Controls.Add(linecell3)
        hotable.Controls.Add(line3)

        Dim summary As New TableRow
        Dim s1 As New TableCell
        summary.Width = 15
        s1.ColumnSpan = 15
        s1.Text = "<b><font size=2>Summary&nbsp;:</font></b>"
        s1.HorizontalAlign = HorizontalAlign.Left
        summary.Controls.Add(s1)
        hotable.Controls.Add(summary)

        Dim sum1 As New TableRow
        Dim s2 As New TableCell
        sum1.Width = 15
        s2.ColumnSpan = 15
        s2.Text = "<font size=2>As per norms,Total staff required in Head Office&nbsp;:&nbsp;" & c1 & "&nbsp;</font>"
        s2.HorizontalAlign = HorizontalAlign.Left
        sum1.Controls.Add(s2)
        hotable.Controls.Add(sum1)

        Dim sum2 As New TableRow
        Dim s3 As New TableCell
        sum2.Width = 15
        s3.ColumnSpan = 15
        s3.Text = "<font size=2>At this time, Number of staffs in Head Office&nbsp;:&nbsp;" & c2 & "&nbsp;</font>"
        s3.HorizontalAlign = HorizontalAlign.Left
        sum2.Controls.Add(s3)
        hotable.Controls.Add(sum2)

        Dim sum3 As New TableRow
        Dim s4 As New TableCell
        sum3.Width = 15
        s4.ColumnSpan = 15
        s4.Text = "<font size=2>Shortage of Staffs&nbsp;:&nbsp;" & c3 & "&nbsp;</font>"
        s4.HorizontalAlign = HorizontalAlign.Left
        sum3.Controls.Add(s4)
        hotable.Controls.Add(sum3)

        Dim sum4 As New TableRow
        Dim s5 As New TableCell
        sum4.Width = 15
        s5.ColumnSpan = 15
        s5.Text = "<font size=2>Surplus of Staffs&nbsp;&nbsp;(if any)&nbsp;:&nbsp;" & c4 & "&nbsp;</font>"
        s5.HorizontalAlign = HorizontalAlign.Left
        sum4.Controls.Add(s5)
        hotable.Controls.Add(sum4)

        Dim sum6 As New TableRow
        Dim s7 As New TableCell
        sum3.Width = 15
        s4.ColumnSpan = 15
        s4.Text = "<font size=2>Notice Period of staffs &nbsp;:&nbsp;" & c5 & "&nbsp;</font>"
        s4.HorizontalAlign = HorizontalAlign.Left
        sum3.Controls.Add(s7)
        hotable.Controls.Add(sum6)

        Dim line4 As New TableRow
        Dim linecell4 As New TableCell
        linecell4.ColumnSpan = 15
        linecell4.Text = "<hr>"
        line4.Controls.Add(linecell4)
        hotable.Controls.Add(line4)

        PanelHoNSS.Controls.Add(hotable)
    End Sub

End Class
