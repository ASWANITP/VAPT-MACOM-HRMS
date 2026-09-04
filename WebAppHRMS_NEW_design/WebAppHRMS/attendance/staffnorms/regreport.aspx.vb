Imports System.Data
Imports System.Data.OracleClient
Partial Class hploanandchits_regreport_e0a56e416169
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim regtable As New Table
        Dim header As New TableRow
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        header.Width = 11
        Dim headercell As New TableCell
        headercell.ColumnSpan = 11
        headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headercell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headercell)
        regtable.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.Width = 11
        sheader.BackColor = Drawing.Color.LightGray
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 11
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        regtable.Controls.Add(sheader)

        Dim tt As New TableRow
        'tt.BackColor = Drawing.Color.LightSkyBlue
        tt.Width = 11
        Dim tt1 As New TableCell
        tt1.ColumnSpan = 11
        tt1.HorizontalAlign = HorizontalAlign.Center
        tt1.Text = "<b><font size=2>&nbsp;HP&nbsp;/&nbsp;BUSINESS&nbsp;&nbsp;LOAN&nbsp;/&nbsp;PERSONAL&nbsp;&nbsp;LOAN&nbsp;/&nbsp;CHITS&nbsp;&nbsp;Norms&nbsp;&nbsp;and&nbsp;&nbsp;shortages&nbsp;&nbsp;Report&nbsp;</font></b>"
        tt.Controls.Add(tt1)
        regtable.Controls.Add(tt)

        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 11

        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 2
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 7
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subh.Controls.Add(subcell2)
        subcell3.ColumnSpan = 2
        subcell3.HorizontalAlign = HorizontalAlign.Left
        subcell3.Text = "<b><font size=2.5>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)
        regtable.Controls.Add(subh)

        'Dim line As New TableRow
        'Dim linecell As New TableCell
        'linecell.ColumnSpan = 11
        'linecell.Text = "<hr>"
        'line.Controls.Add(linecell)
        'regtable.Controls.Add(line)

        Dim ss As String = oh.ExecuteDataSet("select zonal_name from zonal_master where zonal_id=" & Request.QueryString("zonal_id")).Tables(0).Rows(0)(0)
        Dim zone As New TableRow
        zone.Width = 11
        Dim zone1 As New TableCell
        zone1.ColumnSpan = 11
        zone.BackColor = Drawing.Color.Wheat
        zone1.Text = "<b><font size=2>" & ss & "</font></b>"
        zone1.HorizontalAlign = HorizontalAlign.Center
        zone.Controls.Add(zone1)
        regtable.Controls.Add(zone)

        Dim linea As New TableRow
        Dim linecella As New TableCell
        linecella.ColumnSpan = 11
        linecella.Text = "<hr>"
        linea.Controls.Add(linecella)
        regtable.Controls.Add(linea)

        Dim colors As String
        colors = "#fff7ff"

        'If colors.Equals("#fff7ff") = True Then
        '    colors = "#eef9ff"
        'Else
        '    colors = "#fff7ff"
        'End If

        '/////////////////////
        Dim field As New TableRow
        field.Width = 11
        field.Attributes.Add("bgcolor", colors)
        Dim f1, f2, f3, f4, f5, f6, f7, f8, f9, f10 As New TableCell

        f1.ColumnSpan = 2
        f1.HorizontalAlign = HorizontalAlign.Center
        f1.Text = "<b><font size=2>&nbsp;&nbsp;Region&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f1)

        f2.ColumnSpan = 1
        f2.HorizontalAlign = HorizontalAlign.Center
        f2.Text = "<b><font size=2>&nbsp;No&nbsp;of&nbsp;Branches&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f2)

        f3.ColumnSpan = 1
        f3.HorizontalAlign = HorizontalAlign.Center
        f3.Text = "<b><font size=2>&nbsp;LOAN&nbsp;Norms&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f3)

        f4.ColumnSpan = 1
        f4.HorizontalAlign = HorizontalAlign.Center
        f4.Text = "<b><font size=2>&nbsp;LOAN&nbsp;Actual&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f4)

        f5.ColumnSpan = 1
        f5.HorizontalAlign = HorizontalAlign.Center
        f5.Text = "<b><font size=2>&nbsp;LOAN&nbsp;Short&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f5)

        f6.ColumnSpan = 1
        f6.HorizontalAlign = HorizontalAlign.Center
        f6.Text = "<b><font size=2>&nbsp;LOAN&nbsp;Surplus&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f6)

        f7.ColumnSpan = 1
        f7.HorizontalAlign = HorizontalAlign.Center
        f7.Text = "<b><font size=2>&nbsp;&nbsp;B.L/P.L/Chits &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Norms&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f7)

        f8.ColumnSpan = 1
        f8.HorizontalAlign = HorizontalAlign.Center
        f8.Text = "<b><font size=2>&nbsp;&nbsp;B.L/P.L/Chits &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ACTUAL&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f8)

        f9.ColumnSpan = 1
        f9.HorizontalAlign = HorizontalAlign.Center
        f9.Text = "<b><font size=2>&nbsp;&nbsp;B.L/P.l/Chits &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Short&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f9)

        f10.ColumnSpan = 1
        f10.HorizontalAlign = HorizontalAlign.Center
        f10.Text = "<b><font size=2>&nbsp;&nbsp;B.L/P.L/Chits &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Surplus&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f10)

        regtable.Controls.Add(field)

        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        linecell1.ColumnSpan = 11
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        regtable.Controls.Add(line1)
        '                  1            2              3                  4                    5                                                    6                                                                                                                7                                                                                     8
        str = "select rd.region_id,rm.reg_name,count(st.branch_id),sum(st.fldstaff_loan),sum(st.fldstaff_loan_avbl),sum(case when st.fldstaff_loan-st.fldstaff_loan_avbl>0 then st.fldstaff_loan-st.fldstaff_loan_avbl else 0 end)as hp_short,sum(case when st.fldstaff_loan_avbl-st.fldstaff_loan>0 then st.fldstaff_loan_avbl-st.fldstaff_loan else 0 end)as hp_surplus,sum(st.bpc) from zonal_detail zd,region_detail rd,region_master rm,division_detail dd,area_detail ad,staff_required st where zd.region_id=rd.region_id and rd.region_id=rm.reg_id and  rd.division_id = dd.div_id And dd.area_id = ad.area_id And ad.branch_id = st.branch_id and st.branch_id<>0 and zd.zonal_id=" & Request.QueryString("zonal_id") & " group by rd.region_id,rm.reg_name"
        dt = oh.ExecuteDataSet(str).Tables(0)

        Dim hpnorm As Integer = 0
        Dim hpact As Integer = 0
        Dim br As Integer = 0
        Dim c1 As Integer = 0
        Dim c2 As Integer = 0
        Dim c3 As Integer = 0
        Dim c4 As Integer = 0
       

        For Each dr In dt.Rows

            If colors.Equals("#fff7ff") = True Then
                colors = "#eef9ff"
            Else
                colors = "#fff7ff"
            End If

            Dim value As New TableRow
            value.Width = 11
            value.Attributes.Add("bgcolor", colors)

            Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10 As New TableCell

            v1.ColumnSpan = 2
            v1.HorizontalAlign = HorizontalAlign.Left  '"<a href=DrilldownShort.aspx?area_id=" & dr(4) & "&hw=" & dr(12) & ">
            v1.Text = "<a href=divreport.aspx?reg_id=" & dr(0) & "><font size=2>&nbsp;" & dr(1) & "&nbsp;</font></a>"
            value.Controls.Add(v1)
            regtable.Controls.Add(value)

            v2.ColumnSpan = 1
            v2.HorizontalAlign = HorizontalAlign.Right
            v2.Text = "<font size=2>&nbsp;" & dr(2) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v2)
            regtable.Controls.Add(value)
            br += dr(2)

            v3.ColumnSpan = 1
            v3.HorizontalAlign = HorizontalAlign.Right
            v3.Text = "<font size=2>&nbsp;" & dr(3) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v3)
            regtable.Controls.Add(value)

            v4.ColumnSpan = 1
            v4.HorizontalAlign = HorizontalAlign.Right
            v4.Text = "<font size=2>&nbsp;" & dr(4) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v4)
            regtable.Controls.Add(value)

            v5.ColumnSpan = 1
            v5.HorizontalAlign = HorizontalAlign.Right
            v5.Text = "<font size=2>&nbsp;" & dr(5) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v5)
            regtable.Controls.Add(value)

            v6.ColumnSpan = 1
            v6.HorizontalAlign = HorizontalAlign.Right
            v6.Text = "<font size=2>&nbsp;" & dr(6) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v6)
            regtable.Controls.Add(value)
            c2 += dr(6)

            v7.ColumnSpan = 1
            v7.HorizontalAlign = HorizontalAlign.Right
            v7.Text = "<font size=2>&nbsp;" & dr(7) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v7)
            regtable.Controls.Add(value)
            c3 += dr(7)

            v8.ColumnSpan = 1
            v8.HorizontalAlign = HorizontalAlign.Right
            v8.Text = "<font size=2>&nbsp;" & dr(7) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v8)
            regtable.Controls.Add(value)
            c4 += dr(7)

            v9.ColumnSpan = 1
            v9.HorizontalAlign = HorizontalAlign.Center
            v9.Text = "<font size=2>" & 0 & "</font>"
            value.Controls.Add(v9)
            regtable.Controls.Add(value)


            v10.ColumnSpan = 1
            v10.HorizontalAlign = HorizontalAlign.Center
            v10.Text = "<font size=2>" & 0 & "</font>"
            value.Controls.Add(v10)
            regtable.Controls.Add(value)

            hpnorm += dr(3)
            hpact += dr(4)
            c1 += dr(5)
        Next


        Dim line2 As New TableRow
        Dim linecell2 As New TableCell
        linecell2.ColumnSpan = 11
        linecell2.Text = "<hr>"
        line2.Controls.Add(linecell2)
        regtable.Controls.Add(line2)

        Dim total As New TableRow
        total.Width = 11
        total.Attributes.Add("bgcolor", colors)
        Dim to1, hp1, hp2, bb, d1, d2, d3, d4, d5, d6 As New TableCell
        to1.ColumnSpan = 2
        to1.Text = "<b><font size=2>Total:</font></b>"
        total.Controls.Add(to1)

        bb.ColumnSpan = 1
        bb.HorizontalAlign = HorizontalAlign.Right
        bb.Text = "<font size=2>&nbsp;" & br & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
        total.Controls.Add(bb)


        hp1.ColumnSpan = 1
        hp1.HorizontalAlign = HorizontalAlign.Right
        hp1.Text = "<font size=2>&nbsp;" & hpnorm & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
        total.Controls.Add(hp1)

        hp2.ColumnSpan = 1
        hp2.HorizontalAlign = HorizontalAlign.Right
        hp2.Text = "<font size=2>&nbsp;" & hpact & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
        total.Controls.Add(hp2)

        d1.ColumnSpan = 1
        d1.HorizontalAlign = HorizontalAlign.Right
        d1.Text = "<font size=2>&nbsp;" & c1 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
        total.Controls.Add(d1)

        d2.ColumnSpan = 1
        d2.HorizontalAlign = HorizontalAlign.Right
        d2.Text = "<font size=2>&nbsp;" & c2 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
        total.Controls.Add(d2)

        d3.ColumnSpan = 1
        d3.HorizontalAlign = HorizontalAlign.Right
        d3.Text = "<font size=2>&nbsp;" & c3 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
        total.Controls.Add(d3)

        d4.ColumnSpan = 1
        d4.HorizontalAlign = HorizontalAlign.Right
        d4.Text = "<font size=2>&nbsp;" & c4 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
        total.Controls.Add(d4)

        '////
        d5.ColumnSpan = 1
        d5.Text = "<font size=2>" & 0 & "</font>"
        d5.HorizontalAlign = HorizontalAlign.Center
        total.Controls.Add(d5)

        d6.ColumnSpan = 1
        d6.Text = "<font size=2>" & 0 & "</font>"
        d6.HorizontalAlign = HorizontalAlign.Center
        total.Controls.Add(d6)

        regtable.Controls.Add(total)

        Dim line3 As New TableRow
        Dim linecell3 As New TableCell
        linecell3.ColumnSpan = 11
        linecell3.Text = "<hr>"
        line3.Controls.Add(linecell3)
        regtable.Controls.Add(line3)



        PanelRegion.Controls.Add(regtable)
    End Sub
End Class
