Imports System.Data
Imports System.Data.OracleClient
Partial Class fixed_TA_New_branchwise_705efa6b4758
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.Oraclehelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim i As Integer = 0
    Dim zi As Integer = 0
    Dim zfixlim As Double = 0
    Dim fixlimtot As Double = 0
    Dim zfixelg As Double = 0
    Dim fixelgtot As Double = 0

    Dim fixedtatable As New Table
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '                   0           1            2          3              4               5                                    6
        str = "select bd.zonal_name,  bd.REG_NAME,  bd.AREA_NAME,  a.branch_id,  bd.BRANCH_NAME,  sum(nvl(a.ta_limit, 0)) as TA_LIMIT,  sum(nvl(a.ta_amt, 0)) as TA_AMOUNT  from hr_fixed_ta a, branch_detail bd,branch b  where a.branch_id = bd.BRANCH_ID  and bd.BRANCH_ID=b.BRANCH_ID  and b.firm_id=" & Session("firm_id") & "  and a.post_id = 10  and a.emp_code not in (select emp_code from hrm_ta_constant_employees)  group by bd.zonal_name,  bd.REG_NAME,  bd.AREA_NAME,  a.branch_id,  bd.BRANCH_NAME  having sum(nvl(a.ta_limit, 0)) <> 0  union  select zm.zonal_name,  rm.reg_name,  am.area_name,  a.branch_id,  bc.branch_name,  sum(nvl(a.ta_limit, 0)) as TA_LIMIT,  sum(nvl(a.ta_amt, 0)) as TA_AMOUNT  from hr_fixed_ta       a,  before_completion bc,  area_master       am,  region_master     rm,  zonal_master      zm  where a.branch_id = bc.old_id  and bc.branch_id is null  and a.post_id = 10  and bc.area_id = am.area_id  and bc.region_id = rm.reg_id  and bc.zonal_id = zm.zonal_id  and a.emp_code not in (select emp_code from hrm_ta_constant_employees)  group by zm.zonal_name,  rm.reg_name,  am.area_name,  a.branch_id,  bc.branch_name  having sum(nvl(a.ta_limit, 0)) <> 0  order by branch_id"
        dt = oh.ExecuteDataSet(str).Tables(0)
        If dt.Rows.Count > 0 Then

            'Me.fixedtatable.Attributes.Add("width", "80%")
            Dim header As New TableRow
            header.Width = 7
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            Dim headercell As New TableCell
            headercell.ColumnSpan = 7
            headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
            headercell.HorizontalAlign = HorizontalAlign.Center
            header.Controls.Add(headercell)
            fixedtatable.Controls.Add(header)

            Dim sheader As New TableRow
            sheader.BackColor = Drawing.Color.LightGray
            Dim sheadercell1 As New TableCell
            Dim sheadercell2 As New TableCell
            sheadercell1.ColumnSpan = 7
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<font size=2 ><b>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "&nbsp;</b></font>"
            sheader.Controls.Add(sheadercell1)
            fixedtatable.Controls.Add(sheader)

            Dim subh As New TableRow
            Dim subcell1 As New TableCell
            Dim subcell2 As New TableCell
            Dim subcell3 As New TableCell
            subh.Width = 7

            subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd-MMM-yyyy") & "</font></b>"
            subcell1.ColumnSpan = 2
            subcell1.HorizontalAlign = HorizontalAlign.Left
            subh.Controls.Add(subcell1)


            subcell2.ColumnSpan = 3
            subcell2.HorizontalAlign = HorizontalAlign.Center
            subcell2.Text = " "
            subh.Controls.Add(subcell2)

            subcell3.ColumnSpan = 2
            subcell3.HorizontalAlign = HorizontalAlign.Left
            subcell3.Text = "<b><font size=2>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
            subcell3.HorizontalAlign = HorizontalAlign.Right
            subh.Controls.Add(subcell3)
            fixedtatable.Controls.Add(subh)
            '

            Dim dtdet As String = oh.ExecuteDataSet("select distinct to_char(min(a.from_dt),'dd-Mon-yyyy')||' To '||to_char(max(a.to_dt),'dd-Mon-yyyy') from hr_fixed_ta a").Tables(0).Rows(0)(0)
            Dim newhead As New TableRow
            newhead.Width = 7
            Dim newcell As New TableCell
            newcell.ColumnSpan = 7
            newcell.HorizontalAlign = HorizontalAlign.Center
            newcell.Text = "<b><font size=2>Fixed TA for Branch Heads (Gold) Report of " & dtdet & "</font></b>"
            newhead.Controls.Add(newcell)
            fixedtatable.Controls.Add(newhead)


            Dim line As New TableRow
            Dim linecell As New TableCell
            linecell.ColumnSpan = 7
            linecell.Text = "<hr>"
            line.Controls.Add(linecell)
            fixedtatable.Controls.Add(line)

            Dim row2 As New TableRow
            row2.Width = 7
            Dim r1, r2, r3, r4, r5, r6, r7 As New TableCell

            r7.ColumnSpan = 1
            r7.HorizontalAlign = HorizontalAlign.Left
            r7.Text = "<b><font size=2>Zonal&nbsp;Name&nbsp;</font></b>"
            row2.Controls.Add(r7)

            r1.ColumnSpan = 1
            r1.HorizontalAlign = HorizontalAlign.Left
            r1.Text = "<b><font size=2>Region&nbsp;Name&nbsp;</font></b>"
            row2.Controls.Add(r1)

            r2.ColumnSpan = 1
            r2.HorizontalAlign = HorizontalAlign.Left
            r2.Text = "<b><font size=2>Area&nbsp;Name&nbsp;</font></b>"
            row2.Controls.Add(r2)

            r3.ColumnSpan = 1
            r3.HorizontalAlign = HorizontalAlign.Center
            r3.Text = "<b><font size=2>BrID&nbsp;</font></b>"
            row2.Controls.Add(r3)

            r4.ColumnSpan = 1
            r4.HorizontalAlign = HorizontalAlign.Left
            r4.Text = "<b><font size=2>Branch&nbsp;Name&nbsp;</font></b>"
            row2.Controls.Add(r4)

            r5.ColumnSpan = 1
            r5.HorizontalAlign = HorizontalAlign.Left
            r5.Text = "<b><font size=2>Fix.TA&nbsp;Limit&nbsp;</font></b>"
            row2.Controls.Add(r5)

            r6.ColumnSpan = 1
            r6.HorizontalAlign = HorizontalAlign.Left
            r6.Text = "<b><font size=2>Fix.TA&nbsp;Eligible&nbsp;</font></b>"
            row2.Controls.Add(r6)

            fixedtatable.Controls.Add(row2)

            Dim lineu As New TableRow
            Dim linecellu As New TableCell
            linecellu.ColumnSpan = 7
            linecellu.Text = "<hr>"
            lineu.Controls.Add(linecellu)
            fixedtatable.Controls.Add(lineu)


            For Each dr In dt.Rows

                i += 1

                Dim value As New TableRow
                value.Width = 7
                Dim v1, v2, v3, v4, v5, v6, v7 As New TableCell

                v7.ColumnSpan = 1        'Zonal Name
                v7.HorizontalAlign = HorizontalAlign.Left
                v7.Text = "<font size=2><b>" & dr(0) & "&nbsp;</b></font>"
                value.Controls.Add(v7)


                v1.ColumnSpan = 1        'Reg Name
                v1.HorizontalAlign = HorizontalAlign.Left
                v1.Text = "<font size=2><b>" & dr(1) & "&nbsp;</b></font>"
                value.Controls.Add(v1)

                v5.ColumnSpan = 1        'Area Name
                v5.HorizontalAlign = HorizontalAlign.Left
                v5.Text = "<font size=2><b>" & dr(2) & "&nbsp;</b></font>"
                value.Controls.Add(v5)

                v6.ColumnSpan = 1        'brid
                v6.HorizontalAlign = HorizontalAlign.Center
                v6.Text = "<font size=2><b>" & dr(3) & "&nbsp;</b></font>"
                value.Controls.Add(v6)

                v2.ColumnSpan = 1        'Branch Name
                v2.HorizontalAlign = HorizontalAlign.Left
                v2.Text = "<a href=branch_drill_rpt.aspx?branchid=" & dr(3) & "><font size=2>" & dr(4) & "&nbsp;</font>"
                value.Controls.Add(v2)

                v3.ColumnSpan = 1    'ta Limit
                v3.HorizontalAlign = HorizontalAlign.Right
                v3.Text = "<font size=2>" & FormatNumber(dr(5), 2) & "&nbsp;</font>"
                value.Controls.Add(v3)
                'Me.zfixlim += dr(3)
                Me.fixlimtot += dr(5)


                v4.ColumnSpan = 1  'ta elig
                v4.HorizontalAlign = HorizontalAlign.Right
                v4.Text = "<font size=2>" & FormatNumber(dr(6), 2) & "&nbsp;</font>"
                value.Controls.Add(v4)
                'Me.zfixelg += dr(6)
                Me.fixelgtot += dr(6)

                fixedtatable.Controls.Add(value)

            Next

            Dim line4 As New TableRow
            line4.Width = 7
            Dim linecell4 As New TableCell
            linecell4.ColumnSpan = 7
            linecell4.Text = "<hr>"
            line4.Controls.Add(linecell4)
            fixedtatable.Controls.Add(line4)

            ''-------------------------------------------------------------
            'Dim introw As New TableRow
            'introw.Width = 4

            'Dim int1, int2, int3, int4 As New TableCell
            'int1.ColumnSpan = 2       'Reg Name
            'int1.HorizontalAlign = HorizontalAlign.Left
            'int1.Text = "<font size=2><b>Zonal&nbsp;Total:&nbsp;" & Me.zi & "&nbsp;Areas</b></font>"
            'introw.Controls.Add(int1)

            'int2.ColumnSpan = 1       'Reg Name
            'int2.HorizontalAlign = HorizontalAlign.Right
            'int2.Text = "<font size=2>" & FormatNumber(Me.zfixlim, 2) & "&nbsp;</font>"
            'introw.Controls.Add(int2)

            'int3.ColumnSpan = 1       'Reg Name
            'int3.HorizontalAlign = HorizontalAlign.Right
            'int3.Text = "<font size=2>" & FormatNumber(Me.zfixelg, 2) & "&nbsp;</font>"
            'introw.Controls.Add(int3)


            'fixedtatable.Controls.Add(introw)

            'Dim line6 As New TableRow
            'Dim linecell6 As New TableCell
            'linecell6.ColumnSpan = 4
            'linecell6.Text = "<hr>"
            'line6.Controls.Add(linecell6)
            'fixedtatable.Controls.Add(line6)

            '--------------------------------------------------------------------------

            Dim totvalue As New TableRow
            totvalue.Width = 7
            Dim tv1, tv2, tv3, tv4 As New TableCell

            tv1.ColumnSpan = 5        '
            tv1.HorizontalAlign = HorizontalAlign.Left
            tv1.Text = "<font size=2><b>Overall&nbsp;Total:&nbsp;" & Me.i & "&nbsp;Branches</b></font>"
            totvalue.Controls.Add(tv1)


            tv2.ColumnSpan = 1  'sum(talimit)
            tv2.HorizontalAlign = HorizontalAlign.Right
            tv2.Text = "<font size=2>" & FormatNumber(Me.fixlimtot, 2) & "&nbsp;</font>"
            totvalue.Controls.Add(tv2)

            tv3.ColumnSpan = 1   'sum(taeligible)
            tv3.HorizontalAlign = HorizontalAlign.Right
            tv3.Text = "<font size=2>" & FormatNumber(Me.fixelgtot, 2) & "&nbsp;</font>"
            totvalue.Controls.Add(tv3)


            fixedtatable.Controls.Add(totvalue)

            Dim line5 As New TableRow
            Dim linecell5 As New TableCell
            linecell5.ColumnSpan = 7
            linecell5.Text = "<hr>"
            line5.Controls.Add(linecell5)
            fixedtatable.Controls.Add(line5)


        Else

            Dim warn As New TableRow
            warn.Width = 4
            Dim w1 As New TableCell
            w1.ColumnSpan = 4
            w1.HorizontalAlign = HorizontalAlign.Center
            w1.Text = "<b><font size=3> No Data !!</font></b>"
            warn.Controls.Add(w1)
            fixedtatable.Controls.Add(warn)
        End If
        Panel_BHTA.Controls.Add(fixedtatable)
    End Sub
End Class
