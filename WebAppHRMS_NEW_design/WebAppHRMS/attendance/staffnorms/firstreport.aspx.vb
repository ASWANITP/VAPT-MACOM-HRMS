Imports System.Data
Imports System.Data.OracleClient
Partial Class hploanandchits_firstreport_a0aeef543059
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim hptable As New Table
        Dim header As New TableRow
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        header.Width = 11
        Dim headercell As New TableCell
        headercell.ColumnSpan = 11
        headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headercell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headercell)
        hptable.Controls.Add(header)
        hptable.Attributes.Add("align", "center")
        Dim sheader As New TableRow
        sheader.Width = 11
        sheader.BackColor = Drawing.Color.LightGray
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 11
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        hptable.Controls.Add(sheader)

        Dim tt As New TableRow
        'tt.BackColor = Drawing.Color.LightSkyBlue
        tt.Width = 11
        Dim tt1 As New TableCell
        tt1.ColumnSpan = 11
        tt1.HorizontalAlign = HorizontalAlign.Center
        tt1.Text = "<b><font size=2>&nbsp;HP&nbsp;/&nbsp;BUSINESS&nbsp;&nbsp;LOAN&nbsp;/&nbsp;PERSONAL&nbsp;&nbsp;LOAN&nbsp;/&nbsp;CHITS&nbsp;&nbsp;Norms&nbsp;&nbsp;and&nbsp;&nbsp;shortages&nbsp;&nbsp;Report&nbsp;</font></b>"
        tt.Controls.Add(tt1)
        hptable.Controls.Add(tt)

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
        hptable.Controls.Add(subh)

        Dim line As New TableRow
        Dim linecell As New TableCell
        linecell.ColumnSpan = 11
        linecell.Text = "<hr>"
        line.Controls.Add(linecell)
        hptable.Controls.Add(line)
        '''''''''''''''''

        Dim colors As String
        colors = "#fff7ff"

        'If colors.Equals("#fff7ff") = True Then
        '    colors = "#eef9ff"
        'Else
        '    colors = "#fff7ff"
        'End If


        Dim field As New TableRow
        field.Width = 11
        field.Attributes.Add("bgcolor", colors)
        Dim f1, f2, f3, f4, f5, f6, f7, f8, f9, f10 As New TableCell

        f1.ColumnSpan = 2
        f1.HorizontalAlign = HorizontalAlign.Center
        f1.Text = "<b><font size=2>&nbsp;&nbsp;Zone&nbsp;&nbsp;</font></b>"
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

        hptable.Controls.Add(field)

        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        linecell1.ColumnSpan = 11
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        hptable.Controls.Add(line1)

        '                   0           1                     2                   3                        4     ----------------------------------------5-----------------------------------------------------------------------   --------------------------------------6----------------------------------------------------------------------------     7
        str = "select zd.zonal_id,zm.zonal_name,count(ad.branch_id),sum(st.fldstaff_loan),sum(st.fldstaff_loan_avbl),sum(case when st.fldstaff_loan-st.fldstaff_loan_avbl>0 then st.fldstaff_loan-st.fldstaff_loan_avbl else 0 end) as hpshort,sum(case when st.fldstaff_loan_avbl -st.fldstaff_loan >0 then st.fldstaff_loan_avbl -st.fldstaff_loan else 0 end) as hpsurplus,sum(st.bpc)from staff_required st,area_detail ad,division_detail dd,region_detail rd,zonal_master zm,zonal_detail zd where zd.zonal_id=zm.zonal_id and  zd.region_id=rd.region_id and rd.division_id=dd.div_id and dd.area_id=ad.area_id and ad.branch_id=st.branch_id and st.branch_id<>0 group by zd.zonal_id,zm.zonal_name"
        dt = oh.ExecuteDataSet(str).Tables(0)
        Dim c1 As Integer = 0
        Dim c2 As Integer = 0
        Dim c3 As Integer = 0
        Dim c4 As Integer = 0
        Dim c5 As Integer = 0
        Dim c6 As Integer = 0
        Dim c7 As Integer = 0
       

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
            v1.Text = "<a href=regreport.aspx?zonal_id=" & dr(0) & "><font size=2>" & dr(1) & "&nbsp;</font></a>"
            value.Controls.Add(v1)
            hptable.Controls.Add(value)

            v2.ColumnSpan = 1
            v2.HorizontalAlign = HorizontalAlign.Center
            v2.Text = "<font size=2>" & dr(2) & "</font>"
            value.Controls.Add(v2)
            hptable.Controls.Add(value)
            c1 += dr(2)

            v3.ColumnSpan = 1
            v3.HorizontalAlign = HorizontalAlign.Right
            v3.Text = "<font size=2>&nbsp;" & dr(3) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v3)
            hptable.Controls.Add(value)
            c2 += dr(3)

            v4.ColumnSpan = 1
            v4.HorizontalAlign = HorizontalAlign.Right
            v4.Text = "<font size=2>&nbsp;" & dr(4) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v4)
            hptable.Controls.Add(value)
            c3 += dr(4)

            v5.ColumnSpan = 1
            v5.HorizontalAlign = HorizontalAlign.Right
            v5.Text = "<font size=2>&nbsp;" & dr(5) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v5)
            hptable.Controls.Add(value)
            c4 += dr(5)

            v6.ColumnSpan = 1
            v6.HorizontalAlign = HorizontalAlign.Right
            v6.Text = "<font size=2>&nbsp;" & dr(6) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v6)
            hptable.Controls.Add(value)
            c5 += dr(6)

            v7.ColumnSpan = 1
            v7.HorizontalAlign = HorizontalAlign.Right
            v7.Text = "<font size=2>&nbsp;" & dr(7) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v7)
            hptable.Controls.Add(value)
            c6 += dr(7)

            v8.ColumnSpan = 1
            v8.HorizontalAlign = HorizontalAlign.Right
            v8.Text = "<font size=2>&nbsp;" & dr(7) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v8)
            hptable.Controls.Add(value)
            c7 += dr(7)

            v9.ColumnSpan = 1
            v9.HorizontalAlign = HorizontalAlign.Center
            v9.Text = "<font size=2>" & 0 & "</font>"
            value.Controls.Add(v9)
            hptable.Controls.Add(value)



            v10.ColumnSpan = 1
            v10.HorizontalAlign = HorizontalAlign.Center
            v10.Text = "<font size=2>" & 0 & "</font>"
            value.Controls.Add(v10)
            hptable.Controls.Add(value)

        Next


        Dim line2 As New TableRow
        Dim linecell2 As New TableCell
        linecell2.ColumnSpan = 11
        linecell2.Text = "<hr>"
        line2.Controls.Add(linecell2)
        hptable.Controls.Add(line2)

        ''''''''''''''total
        Dim total As New TableRow
        total.Width = 11
        total.Attributes.Add("bgcolor", colors)
        Dim t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 As New TableCell

        t1.ColumnSpan = 2
        t1.HorizontalAlign = HorizontalAlign.Center
        t1.Text = "<b><font size=2>&nbsp;Total&nbsp;:&nbsp;</font></b>"
        total.Controls.Add(t1)

        t2.ColumnSpan = 1
        t2.HorizontalAlign = HorizontalAlign.Center
        t2.Text = "<b><font size=2>" & c1 & "</font></b>"
        total.Controls.Add(t2)

        t3.ColumnSpan = 1
        t3.HorizontalAlign = HorizontalAlign.Right
        t3.Text = "<b><font size=2>&nbsp;" & c2 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        total.Controls.Add(t3)

        t4.ColumnSpan = 1
        t4.HorizontalAlign = HorizontalAlign.Right
        t4.Text = "<b><font size=2>&nbsp;" & c3 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        total.Controls.Add(t4)

        t5.ColumnSpan = 1
        t5.HorizontalAlign = HorizontalAlign.Right
        t5.Text = "<b><font size=2>&nbsp;" & c4 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        total.Controls.Add(t5)

        t6.ColumnSpan = 1
        t6.HorizontalAlign = HorizontalAlign.Right
        t6.Text = "<b><font size=2>&nbsp;" & c5 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        total.Controls.Add(t6)

        t7.ColumnSpan = 1
        t7.HorizontalAlign = HorizontalAlign.Right
        t7.Text = "<b><font size=2>&nbsp;" & c6 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        total.Controls.Add(t7)

        t8.ColumnSpan = 1
        t8.HorizontalAlign = HorizontalAlign.Right
        t8.Text = "<b><font size=2>&nbsp;" & c7 & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        total.Controls.Add(t8)

        t9.ColumnSpan = 1
        t9.HorizontalAlign = HorizontalAlign.Center
        t9.Text = "<b><font size=2>" & 0 & "</font></b>"
        total.Controls.Add(t9)

        t10.ColumnSpan = 1
        t10.HorizontalAlign = HorizontalAlign.Center
        t10.Text = "<b><font size=2>" & 0 & "</font></b>"
        total.Controls.Add(t10)



        '////////////////////////total ends
        hptable.Controls.Add(total)

        Dim line3 As New TableRow
        Dim linecell3 As New TableCell
        linecell3.ColumnSpan = 11
        linecell3.Text = "<hr>"
        line3.Controls.Add(linecell3)
        hptable.Controls.Add(line3)

        Dim back As New TableRow
        Dim back1 As New TableCell
        back1.ColumnSpan = 11
        back1.HorizontalAlign = HorizontalAlign.Center
        back1.Text = "<a href=../../home.aspx><font size=2>Back</font></a>"
        back.Controls.Add(back1)
        hptable.Controls.Add(back)

        PanelHP.Controls.Add(hptable)
    End Sub
End Class
