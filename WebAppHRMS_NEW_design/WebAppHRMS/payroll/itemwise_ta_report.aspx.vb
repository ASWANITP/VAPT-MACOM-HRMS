Imports System.Data
Imports System.Data.OracleClient
Partial Class TA_updation_Part2_itemwise_ta_report_fe319b802194
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim i As Integer = 0
    Dim total As Double = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim itemtable As New Table
        itemtable.Attributes.Add("width", "100%")

        Dim header As New TableRow
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        header.Width = 8
        Dim headercell As New TableCell
        headercell.ColumnSpan = 8
        headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headercell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headercell)
        itemtable.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.Width = 8
        sheader.BackColor = Drawing.Color.LightGray
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 8
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        itemtable.Controls.Add(sheader)

        Dim tt As New TableRow
        'tt.BackColor = Drawing.Color.LightSkyBlue
        tt.Width = 8
        Dim tt1 As New TableCell
        tt1.ColumnSpan = 8
        tt1.HorizontalAlign = HorizontalAlign.Center
        tt1.Text = "<b><font size=3>ITEMWISE TOTAL REPORT</font></b>"
        tt.Controls.Add(tt1)
        itemtable.Controls.Add(tt)

        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 8

        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 2
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 3
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subcell2.Text = " "
        subh.Controls.Add(subcell2)

        subcell3.ColumnSpan = 3
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subcell3.Text = "<b><font size=2>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        'subcell3.Text = "<font size=2><b><div id= txt align= right></div></b></font></div>"
        subh.Controls.Add(subcell3)
        itemtable.Controls.Add(subh)

        Dim line As New TableRow
        Dim linecell As New TableCell
        linecell.ColumnSpan = 8
        linecell.Text = "<hr>"
        line.Controls.Add(linecell)
        itemtable.Controls.Add(line)
        '''''''''''''''''

        Dim colors As String
        colors = "#fff7ff"

        'If colors.Equals("#fff7ff") = True Then
        '    colors = "#eef9ff"
        'Else
        '    colors = "#fff7ff"
        'End If

        Dim field As New TableRow
        field.Width = 8
        field.Attributes.Add("bgcolor", colors)
        Dim f1, f2, f3, f4 As New TableCell

        f1.ColumnSpan = 1
        f1.HorizontalAlign = HorizontalAlign.Center
        f1.Text = "<b><font size=2>Si&nbsp;NO</font></b>"
        field.Controls.Add(f1)

        f2.ColumnSpan = 2
        f2.HorizontalAlign = HorizontalAlign.Left
        f2.Text = "<b><font size=2>&nbsp;EMP&nbsp;CODE&nbsp;</font></b>"
        field.Controls.Add(f2)

        f3.ColumnSpan = 3
        f3.HorizontalAlign = HorizontalAlign.Left
        f3.Text = "<b><font size=2>&nbsp;EMPLOYEE&nbsp;NAME&nbsp;</font></b>"
        field.Controls.Add(f3)

        f4.ColumnSpan = 2
        f4.HorizontalAlign = HorizontalAlign.Center
        f4.Text = "<b><font size=2>&nbsp;" & Me.Request.QueryString("item_name") & "&nbsp;</font></b>"
        field.Controls.Add(f4)


        itemtable.Controls.Add(field)

        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        linecell1.ColumnSpan = 8
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        itemtable.Controls.Add(line1)

        Dim item As Integer = Me.Request.QueryString("item_code")

        If item = 0 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.fix_ta,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.fix_ta,tb.emp_id,em.emp_name having tb.fix_ta>0 order by tb.emp_id"
        ElseIf item = 1 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.act_ta,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.act_ta,tb.emp_id,em.emp_name having tb.act_ta>0 order by tb.emp_id"
        ElseIf item = 2 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.outstation,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.outstation,tb.emp_id,em.emp_name having tb.outstation>0 order by tb.emp_id"
        ElseIf item = 3 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.abh_ta,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.abh_ta,tb.emp_id,em.emp_name having tb.abh_ta>0 order by tb.emp_id"
        ElseIf item = 4 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.bh_all,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.bh_all,tb.emp_id,em.emp_name having tb.bh_all>0 order by tb.emp_id"
        ElseIf item = 5 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.bh_ta,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.bh_ta,tb.emp_id,em.emp_name having tb.bh_ta>0 order by tb.emp_id"
        ElseIf item = 6 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.incentive,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.incentive,tb.emp_id,em.emp_name having tb.incentive>0 order by tb.emp_id"
        ElseIf item = 7 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.tele_all,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.tele_all,tb.emp_id,em.emp_name having tb.tele_all>0 order by tb.emp_id"
        ElseIf item = 8 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.dist_all,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.dist_all,tb.emp_id,em.emp_name having tb.dist_all>0 order by tb.emp_id"
        ElseIf item = 9 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.hp_ta,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.hp_ta,tb.emp_id,em.emp_name having tb.hp_ta>0 order by tb.emp_id"
        ElseIf item = 10 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.hp_incent,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.hp_incent,tb.emp_id,em.emp_name having tb.hp_incent>0 order by tb.emp_id"
        ElseIf item = 11 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.ins_incent,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.ins_incent,tb.emp_id,em.emp_name having tb.ins_incent>0 order by tb.emp_id"
        ElseIf item = 12 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.forex_inc,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.forex_inc,tb.emp_id,em.emp_name having tb.forex_inc>0 order by tb.emp_id"
        ElseIf item = 13 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.glr_incent,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.glr_incent,tb.emp_id,em.emp_name having tb.glr_incent>0 order by tb.emp_id"
        ElseIf item = 14 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.dep_mob,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.dep_mob,tb.emp_id,em.emp_name having tb.dep_mob>0 order by tb.emp_id"
        ElseIf item = 15 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.bond_inc,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.bond_inc,tb.emp_id,em.emp_name having tb.bond_inc>0 order by tb.emp_id"
        ElseIf item = 16 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.bus_loan,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.bus_loan,tb.emp_id,em.emp_name having tb.bus_loan>0 order by tb.emp_id"
        ElseIf item = 17 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.pers_loan,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.pers_loan,tb.emp_id,em.emp_name having tb.pers_loan>0 order by tb.emp_id"
        ElseIf item = 18 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.gold_ga,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.gold_ga,tb.emp_id,em.emp_name having tb.gold_ga>0 order by tb.emp_id"
        ElseIf item = 19 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.manag_inc,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.manag_inc,tb.emp_id,em.emp_name having tb.manag_inc>0 order by tb.emp_id"
        ElseIf item = 20 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.month_inc,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.month_inc,tb.emp_id,em.emp_name having tb.month_inc>0 order by tb.emp_id"
        ElseIf item = 21 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.dep_mkt,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.dep_mkt,tb.emp_id,em.emp_name having tb.dep_mkt>0 order by tb.emp_id"
        ElseIf item = 22 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.legal_inc,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.legal_inc,tb.emp_id,em.emp_name having tb.legal_inc>0 order by tb.emp_id"
        ElseIf item = 23 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.civil_inc,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.civil_inc,tb.emp_id,em.emp_name having tb.civil_inc>0 order by tb.emp_id"
        ElseIf item = 24 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.chits_inc,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.chits_inc,tb.emp_id,em.emp_name having tb.chits_inc>0 order by tb.emp_id"
        ElseIf item = 25 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.other_inc,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.other_inc,tb.emp_id,em.emp_name having tb.other_inc>0 order by tb.emp_id"
        ElseIf item = 26 Then
            str = "select tb.emp_id,em.emp_name,nvl(tb.summer_inc,0) from employee_master em,ta_br tb where tb.emp_id=em.emp_code group by tb.summer_inc,tb.emp_id,em.emp_name having tb.summer_inc>0 order by tb.emp_id"
        End If

        dt = oh.ExecuteDataSet(str).Tables(0)

        For Each dr In dt.Rows
            i += 1

            If colors.Equals("#fff7ff") = True Then
                colors = "#eef9ff"
            Else
                colors = "#fff7ff"
            End If


            Dim value As New TableRow
            value.Width = 8
            Dim v1, v2, v3, v4 As New TableCell
            value.Attributes.Add("bgcolor", colors)

            v1.ColumnSpan = 1
            v1.HorizontalAlign = HorizontalAlign.Center
            v1.Text = "<font size=2>" & i & "</font>"
            value.Controls.Add(v1)

            v2.ColumnSpan = 2
            v2.HorizontalAlign = HorizontalAlign.Left
            v2.Text = "<font size=2>" & dr(0) & "</font>"
            value.Controls.Add(v2)

            v3.ColumnSpan = 3
            v3.HorizontalAlign = HorizontalAlign.Left
            v3.Text = "<font size=2>" & dr(1) & "</font>"
            value.Controls.Add(v3)

            v4.ColumnSpan = 2
            v4.HorizontalAlign = HorizontalAlign.Right
            v4.Text = "<font size=2>" & dr(2) & "</font>"
            value.Controls.Add(v4)

            total += dr(2)

            itemtable.Controls.Add(value)

        Next

        Dim line2 As New TableRow
        Dim linecell2 As New TableCell
        linecell2.ColumnSpan = 8
        linecell2.Text = "<hr>"
        line2.Controls.Add(linecell2)
        itemtable.Controls.Add(line2)

        Dim totval As New TableRow
        totval.Width = 8
        totval.Attributes.Add("bgcolor", colors)

        Dim tot1, tot2 As New TableCell

        tot1.ColumnSpan = 6
        tot1.HorizontalAlign = HorizontalAlign.Center
        tot1.Text = "<b><font size=3>TOTAL:</font></b>"
        totval.Controls.Add(tot1)

        tot2.ColumnSpan = 2
        tot2.HorizontalAlign = HorizontalAlign.Right
        tot2.Text = "<b><font size=3>" & FormatNumber(total, 2) & "</font></b>"
        totval.Controls.Add(tot2)

        itemtable.Controls.Add(totval)


        Dim line3 As New TableRow
        Dim linecell3 As New TableCell
        linecell3.ColumnSpan = 8
        linecell3.Text = "<hr>"
        line3.Controls.Add(linecell3)
        itemtable.Controls.Add(line3)

        Dim back As New TableRow
        Dim back3 As New TableCell
        back3.ColumnSpan = 8
        back3.HorizontalAlign = HorizontalAlign.Center
        back3.Text = "<a href=deptwise_ta_updation.aspx><= Back</a>"
        back.Controls.Add(back3)
        itemtable.Controls.Add(back)

        Panel_Itemwise_TA.Controls.Add(itemtable)
    End Sub
End Class
