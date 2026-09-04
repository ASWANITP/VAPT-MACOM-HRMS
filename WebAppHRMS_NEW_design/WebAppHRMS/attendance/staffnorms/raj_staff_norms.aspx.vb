Imports System.Data
Imports System.Data.OracleClient
Partial Class staffnorms_raj_staff_norms_1a8f77095070
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3, dt4 As New DataTable
    Dim dr As DataRow
    Dim str, str1, str2, str3, str4 As String
    Dim staffnormstable As New Table
    Dim i As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '                  0            1                                                             2                                                                                            3                                                                                         4                                5                              6                                                                                                         7                                                                                             8                                                                                                              9                                                                                                                                                                                                                                                                                                                                                                                                 10                                                                                                                                                                                                                                                                                                                                                                                           11                12                            13                            14                                  15                           16                17                        18                    19                       20                     21                            22                      23                 24               25                    26
        'str = "select a.zonal_id,zm.zonal_name,nvl(sum(st.bh+st.abh+st.jr_asst+st.sweeper+st.jo),0) as actual_norms,nvl(sum(st.sweeper_avbl+st.bh_avbl+st.abh_avbl+st.jr_asst_avbl+st.jo_avbl),0)as actual_position,nvl(sum(st.bh_avbl+st.abh_avbl+st.jr_asst_avbl+st.jo_avbl),0)as actual_others,nvl(sum(st.sweeper_avbl),0) as actual_sweeper,nvl(sum(st.long_leave),0),nvl(sum(CASE when ST.JR_ASST-st.jr_asst_avbl<0 then 0 else st.jr_asst-st.jr_asst_avbl end),0) as short_JRASST,nvl(sum(CASE when st.jo-st.jo_avbl<0 then 0 else st.jo-st.jo_avbl end),0) as short_JROFFCER,nvl(sum(case when st.sweeper-st.sweeper_avbl<0 then 0 else st.sweeper-st.sweeper_avbl end),0) as short_sweeper,nvl(sum(case when(st.bh-st.bh_avbl)>0 then st.bh-st.bh_avbl else 0 end+case when(st.abh-st.abh_avbl)>0 then st.abh-st.abh_avbl else 0 end+case when(st.jr_asst-st.jr_asst_avbl)>0 then st.jr_asst-st.jr_asst_avbl else 0 end+case when(st.sweeper-st.sweeper_avbl)>0 then st.sweeper-st.sweeper_avbl else 0 end+case when(st.jo-st.jo_avbl)>0 then st.jo-st.jo_avbl else 0 end),0) as tot_short,sum(case when(st.bh_avbl-st.bh)>0 then st.bh_avbl-st.bh else 0 end+case when(st.abh_avbl-st.abh)>0 then st.abh_avbl-st.abh else 0 end+case when(st.jr_asst_avbl-st.jr_asst)>0 then st.jr_asst_avbl-st.jr_asst else 0 end+case when(st.sweeper_avbl-st.sweeper)>0 then st.sweeper_avbl-st.sweeper else 0 end+case when(st.jo_avbl-st.jo)>0 then st.jo_avbl-st.jo else 0 end) as surplus,nvl(sum(st.fldstaff_gold),0),nvl(sum(st.fldstaff_gold_avbl),0),nvl(sum(st.fldstaff_loan),0),nvl(sum(st.fldstaff_loan_avbl),0),nvl(sum(st.hp_other),0),nvl(sum(st.bpc),0),nvl(sum(st.auditors),0),nvl(sum(st.hardware),0),nvl(sum(st.life_ins),0),nvl(sum(general_ins),0),nvl(sum(gl_marketing),0),nvl(sum(rel_officer),0),nvl(sum(hon_dir),0),nvl(sum(corp_tnr),0),nvl(sum(reg_dir),0) from staff_required st,branch_master br,zonal_detail a,region_detail b,division_detail c,area_detail d,zonal_master zm where st.branch_id=br.branch_id and br.branch_id <>0 and a.region_id=b.region_id and b.division_id=c.div_id and c.area_id=d.area_id and d.branch_id=br.branch_id and zm.zonal_id=a.zonal_id group by a.zonal_id,zm.zonal_name order by a.zonal_id"

        str = "select count(*) from employee_master where status_id=1 and emp_code>9999"  'Total employees
        str1 = "select nvl(actual,0) from staff_norm_ho where norm_id=32" 'Board of Directors
        str2 = "select nvl(sum(actual),0) from staff_norm_ho where norm_id<>32" ' HO Employees
        str3 = "select count(*) from employee_master where status_id=1 and branch_id>0 and emp_code>9999"  'in Open Branches
        str4 = "select count(*) from employee_master where status_id=1 and branch_id<0 and emp_code>9999"  'in NOBranches


        dt = oh.ExecuteDataSet(str).Tables(0)
        dt1 = oh.ExecuteDataSet(str1).Tables(0)
        dt2 = oh.ExecuteDataSet(str2).Tables(0)
        dt3 = oh.ExecuteDataSet(str3).Tables(0)
        dt4 = oh.ExecuteDataSet(str4).Tables(0)

        If dt.Rows.Count > 0 Then

            Dim header As New TableRow
            header.Width = 7
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            Dim headercell As New TableCell
            headercell.ColumnSpan = 7
            headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
            headercell.HorizontalAlign = HorizontalAlign.Center
            header.Controls.Add(headercell)
            staffnormstable.Controls.Add(header)

            Dim sheader As New TableRow
            sheader.BackColor = Drawing.Color.LightGray
            Dim sheadercell1 As New TableCell
            Dim sheadercell2 As New TableCell
            sheadercell1.ColumnSpan = 7
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
            sheader.Controls.Add(sheadercell1)
            staffnormstable.Controls.Add(sheader)

            Dim tt As New TableRow
            tt.BackColor = Drawing.Color.LightSkyBlue
            tt.Width = 7
            Dim tt1 As New TableCell
            tt1.ColumnSpan = 7
            tt1.HorizontalAlign = HorizontalAlign.Center
            tt1.Text = "<b><font size=2>Staff Norms Total Report</font></b>"
            tt.Controls.Add(tt1)
            staffnormstable.Controls.Add(tt)

            Dim subh As New TableRow
            Dim subcell1 As New TableCell
            Dim subcell2 As New TableCell
            Dim subcell3 As New TableCell
            subh.Width = 7

            subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
            subcell1.ColumnSpan = 2
            subcell1.HorizontalAlign = HorizontalAlign.Left
            subh.Controls.Add(subcell1)

            subcell2.ColumnSpan = 3
            subcell2.HorizontalAlign = HorizontalAlign.Center
            subh.Controls.Add(subcell2)
            subcell3.ColumnSpan = 2
            subcell3.HorizontalAlign = HorizontalAlign.Left
            subcell3.Text = "<b><font size=2.5>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
            subcell3.HorizontalAlign = HorizontalAlign.Right
            subh.Controls.Add(subcell3)
            staffnormstable.Controls.Add(subh)

            Dim line As New TableRow
            Dim linecell As New TableCell
            linecell.ColumnSpan = 7
            linecell.Text = "<hr>"
            line.Controls.Add(linecell)
            staffnormstable.Controls.Add(line)

            'Toatal Live
            Dim totemp As New TableRow
            totemp.Width = 7
            Dim q, q1, q2 As New TableCell
            q.ColumnSpan = 3
            q1.ColumnSpan = 1
            q2.ColumnSpan = 3
            q.HorizontalAlign = HorizontalAlign.Left
            q1.HorizontalAlign = HorizontalAlign.Center
            q2.HorizontalAlign = HorizontalAlign.Right
            q.Text = "<b><font size=2>Total Employees Now Live<font></b>"
            totemp.Controls.Add(q)
            q1.Text = "<b><font size=2>---<font></b>"
            totemp.Controls.Add(q1)
            q2.Text = "<font size=2>" & dt.Rows(0)(0) & "<font>"  'total
            totemp.Controls.Add(q2)
            staffnormstable.Controls.Add(totemp)


            'Board of Directors

            Dim bodemp As New TableRow
            bodemp.Width = 7
            Dim bq, bq1, bq2 As New TableCell
            bq.ColumnSpan = 3
            bq1.ColumnSpan = 1
            bq2.ColumnSpan = 3
            bq.HorizontalAlign = HorizontalAlign.Left
            bq1.HorizontalAlign = HorizontalAlign.Center
            bq2.HorizontalAlign = HorizontalAlign.Right
            bq.Text = "<b><font size=2>Board Of Directors<font></b>"
            bodemp.Controls.Add(bq)
            bq1.Text = "<b><font size=2>---<font></b>"
            bodemp.Controls.Add(bq1)
            bq2.Text = "<font size=2>" & dt1.Rows(0)(0) & "<font>"  'Bod
            bodemp.Controls.Add(bq2)
            staffnormstable.Controls.Add(bodemp)
            i += dt1.Rows(0)(0)

            'Other HO Employees Including ZM

            Dim hooth As New TableRow
            hooth.Width = 7
            Dim hq, hq1, hq2 As New TableCell
            hq.ColumnSpan = 3
            hq1.ColumnSpan = 1
            hq2.ColumnSpan = 3
            hq.HorizontalAlign = HorizontalAlign.Left
            hq1.HorizontalAlign = HorizontalAlign.Center
            hq2.HorizontalAlign = HorizontalAlign.Right
            hq.Text = "<b><font size=2>HO Employees(ZMs Included)<font></b>"
            hooth.Controls.Add(hq)
            hq1.Text = "<b><font size=2>---<font></b>"
            hooth.Controls.Add(hq1)
            hq2.Text = "<font size=2>" & dt2.Rows(0)(0) & "<font>"  'HO Employees
            hooth.Controls.Add(hq2)
            staffnormstable.Controls.Add(hooth)
            i += dt2.Rows(0)(0)

            'oppen branches
            Dim opbr As New TableRow
            opbr.Width = 7
            Dim oq, oq1, oq2 As New TableCell
            oq.ColumnSpan = 3
            oq1.ColumnSpan = 1
            oq2.ColumnSpan = 3
            oq.HorizontalAlign = HorizontalAlign.Left
            oq1.HorizontalAlign = HorizontalAlign.Center
            oq2.HorizontalAlign = HorizontalAlign.Right
            oq.Text = "<b><font size=2>Open Branches Employees<font></b>"
            opbr.Controls.Add(oq)
            oq1.Text = "<b><font size=2>---<font></b>"
            opbr.Controls.Add(oq1)
            oq2.Text = "<font size=2>" & dt3.Rows(0)(0) & "<font>"  'Open Branch Employes
            opbr.Controls.Add(oq2)
            staffnormstable.Controls.Add(opbr)
            i += dt3.Rows(0)(0)

            'Not oppen branches
            Dim nopbr As New TableRow
            nopbr.Width = 7
            Dim noq, noq1, noq2 As New TableCell
            noq.ColumnSpan = 3
            noq1.ColumnSpan = 1
            noq2.ColumnSpan = 3
            noq.HorizontalAlign = HorizontalAlign.Left
            noq1.HorizontalAlign = HorizontalAlign.Center
            noq2.HorizontalAlign = HorizontalAlign.Right
            noq.Text = "<b><font size=2>Not Opened Branches Employees<font></b>"
            nopbr.Controls.Add(noq)
            noq1.Text = "<b><font size=2>---<font></b>"
            nopbr.Controls.Add(noq1)
            noq2.Text = "<font size=2>" & dt4.Rows(0)(0) & "<font>"  'Not Open Branch Employes
            nopbr.Controls.Add(noq2)
            staffnormstable.Controls.Add(nopbr)
            i += dt4.Rows(0)(0)




            'For Each dr In dt.Rows

            '    i += 1



            '    Dim value As New TableRow
            '    value.Width = 7

            '    Dim v1, v2, v3, va, v4 As New TableCell

            '    v1.ColumnSpan = 1        'Empcode
            '    v1.HorizontalAlign = HorizontalAlign.Left
            '    v1.Text = "<a href=sd_empwise_ta_sal_report.aspx?empcode=" & dr(1) & "&type=" & Me.Request.QueryString("type") & "><font size=2><b>" & dr(1) & "&nbsp;</b></font></a>"
            '    value.Controls.Add(v1)
            '    '"<a href=all_inc_empwise_report.aspx?emp_code=" & dr(1) & "&prdate=" & dr(4) & "><font size=2>" & dr(0) & "</font></a>"

            '    v2.ColumnSpan = 2         'EmpName
            '    v2.HorizontalAlign = HorizontalAlign.Left
            '    v2.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
            '    value.Controls.Add(v2)

            '    v3.ColumnSpan = 2    'Designation
            '    v3.HorizontalAlign = HorizontalAlign.Left
            '    v3.Text = "<font size=2>" & dr(3) & "&nbsp;</font>"
            '    value.Controls.Add(v3)

            '    va.ColumnSpan = 1    'SD Number
            '    va.HorizontalAlign = HorizontalAlign.Left
            '    If dr(4) <> 0 Then
            '        va.Text = "<font size=2>" & dr(4) & "&nbsp;</font>"
            '    ElseIf dr(4) = 0 Then
            '        va.Text = "<font size=2>Not Entered!&nbsp;</font>"
            '    End If
            '    value.Controls.Add(va)

            '    v4.ColumnSpan = 1   'Amount
            '    v4.HorizontalAlign = HorizontalAlign.Right
            '    v4.Text = "<font size=2>" & FormatNumber(dr(5), 2) & "&nbsp;</font>"
            '    value.Controls.Add(v4)



            '    staffnormstable.Controls.Add(value)

            'Next

            Dim line4 As New TableRow
            Dim linecell4 As New TableCell
            linecell4.ColumnSpan = 7
            linecell4.Text = "<hr>"
            line4.Controls.Add(linecell4)
            staffnormstable.Controls.Add(line4)


            Dim lastemp As New TableRow
            lastemp.Width = 7
            Dim lq, lq1, lq2 As New TableCell
            lq.ColumnSpan = 3
            lq1.ColumnSpan = 1
            lq2.ColumnSpan = 3
            lq.HorizontalAlign = HorizontalAlign.Left
            lq1.HorizontalAlign = HorizontalAlign.Center
            lq2.HorizontalAlign = HorizontalAlign.Right
            lq.Text = "<b><font size=2>Total Employees<font></b>"
            lastemp.Controls.Add(lq)
            lq1.Text = "<b><font size=2>---<font></b>"
            lastemp.Controls.Add(lq1)
            lq2.Text = "<font size=2>" & Me.i & "<font>"  'Toatal
            lastemp.Controls.Add(lq2)
            staffnormstable.Controls.Add(lastemp)

            Dim line5 As New TableRow
            Dim linecell5 As New TableCell
            linecell5.ColumnSpan = 7
            linecell5.Text = "<hr>"
            line5.Controls.Add(linecell5)
            staffnormstable.Controls.Add(line5)

            Dim ztt As New TableRow
            ztt.BackColor = Drawing.Color.LightSkyBlue
            ztt.Width = 7
            Dim ztt1 As New TableCell
            ztt1.ColumnSpan = 7
            ztt1.HorizontalAlign = HorizontalAlign.Center
            ztt1.Text = "<b><font size=2>Zonal wise Total Report</font></b>"
            ztt.Controls.Add(ztt1)
            staffnormstable.Controls.Add(ztt)


        Else

            Dim warn As New TableRow
            warn.Width = 7
            Dim w1 As New TableCell
            w1.ColumnSpan = 7
            w1.HorizontalAlign = HorizontalAlign.Center
            w1.Text = "<b><font size=3> No Data !!</font></b>"
            warn.Controls.Add(w1)
            staffnormstable.Controls.Add(warn)

        End If

        Panel_Staff_Norms.Controls.Add(staffnormstable)
    End Sub
End Class
