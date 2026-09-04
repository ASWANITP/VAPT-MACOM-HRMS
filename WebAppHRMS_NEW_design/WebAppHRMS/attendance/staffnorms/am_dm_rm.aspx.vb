Imports System.Data
Imports System.Data.OracleClient
Partial Class staffnorms_am_dm_rm_c96291c31630
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim i As Integer = 0
    Dim tot As Integer = 0
    Dim amdmrmtable As New Table

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '                   0           1             2              3           4           5          6             7           8             9               10         11
        str = "select bm.zonal_name,bm.REG_NAME,bm.DIV_NAME,bm.AREA_NAME,bm.BRANCH_ID,bm.BRANCH_NAME,em.emp_code,em.emp_name,dm.designation,dp.dep_name,pm.post_name,'AREA MANAGERS' as typea from area_master am,employee_master em,employee_involve ev,branch_detail bm,designation_master dm,department_mst dp,post_mst pm where am.area_head_id=em.emp_code and am.area_head_id=ev.emp_code and em.branch_id=bm.branch_id and em.designation_id=dm.designation_id and em.department_id=dp.dep_id and em.post_id=pm.post_id and em.status_id=1 and em.emp_code>9999 union select bm.zonal_name,bm.REG_NAME,bm.DIV_NAME,bm.AREA_NAME,bm.BRANCH_ID,bm.BRANCH_NAME,em.emp_code,em.emp_name,dm.designation,dp.dep_name,pm.post_name,'DIVISIONAL MANAGERS' as typea from division_master dim,employee_master em,employee_involve ev,branch_detail bm,designation_master dm,department_mst dp,post_mst pm where dim.div_head_id=em.emp_code and dim.div_head_id=ev.emp_code and em.branch_id=bm.branch_id and em.designation_id=dm.designation_id and em.department_id=dp.dep_id and em.post_id=pm.post_id and em.status_id=1 and em.emp_code>9999 union select bm.zonal_name,bm.REG_NAME,bm.DIV_NAME,bm.AREA_NAME,bm.BRANCH_ID,bm.BRANCH_NAME,em.emp_code,em.emp_name,dm.designation,dp.dep_name,pm.post_name,'REGIONAL MANAGERS' as typea from region_master rm,employee_master em,employee_involve ev,branch_detail bm,designation_master dm,department_mst dp,post_mst pm where rm.head_id=em.emp_code and rm.head_id=ev.emp_code and em.branch_id=bm.branch_id and em.designation_id=dm.designation_id and em.department_id=dp.dep_id and em.post_id=pm.post_id and em.status_id=1 and em.emp_code>9999 order by typea"
        dt = oh.ExecuteDataSet(str).Tables(0)
        If dt.Rows.Count > 0 Then

            Dim header As New TableRow
            header.Width = 11
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            Dim headercell As New TableCell
            headercell.ColumnSpan = 11
            headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
            headercell.HorizontalAlign = HorizontalAlign.Center
            header.Controls.Add(headercell)
            amdmrmtable.Controls.Add(header)

            Dim sheader As New TableRow
            sheader.BackColor = Drawing.Color.LightGray
            Dim sheadercell1 As New TableCell
            Dim sheadercell2 As New TableCell
            sheadercell1.ColumnSpan = 11
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
            sheader.Controls.Add(sheadercell1)
            amdmrmtable.Controls.Add(sheader)

            Dim tt As New TableRow
            tt.BackColor = Drawing.Color.LightSkyBlue
            tt.Width = 11
            Dim tt1 As New TableCell
            tt1.ColumnSpan = 11
            tt1.HorizontalAlign = HorizontalAlign.Center
            tt1.Text = "<b><font size=2>List of Employees Not Included as Per Norms</font></b>"
            tt.Controls.Add(tt1)
            amdmrmtable.Controls.Add(tt)

            Dim subh As New TableRow
            Dim subcell1 As New TableCell
            Dim subcell2 As New TableCell
            Dim subcell3 As New TableCell
            subh.Width = 11

            subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd-MMM-yyyy") & "</font></b>"
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
            amdmrmtable.Controls.Add(subh)

            Dim line As New TableRow
            Dim linecell As New TableCell
            linecell.ColumnSpan = 11
            linecell.Text = "<hr>"
            line.Controls.Add(linecell)
            amdmrmtable.Controls.Add(line)

            Dim row2 As New TableRow
            row2.Width = 11
            Dim r1, r2, ra, r3, re, r4, r5, r6, r7, r8, r9 As New TableCell

            r1.ColumnSpan = 1
            r1.HorizontalAlign = HorizontalAlign.Left
            r1.Text = "<b><font size=2>Zonal&nbsp;Name&nbsp;</font></b>"
            row2.Controls.Add(r1)

            r2.ColumnSpan = 1
            r2.HorizontalAlign = HorizontalAlign.Left
            r2.Text = "<b><font size=2>Region&nbsp;Name&nbsp;</font></b>"
            row2.Controls.Add(r2)

            re.ColumnSpan = 1
            re.HorizontalAlign = HorizontalAlign.Left
            re.Text = "<b><font size=2>Division&nbsp;Name&nbsp;</font></b>"
            row2.Controls.Add(re)


            r3.ColumnSpan = 1
            r3.HorizontalAlign = HorizontalAlign.Left
            r3.Text = "<b><font size=2>Area&nbsp;Name&nbsp;</font></b>"
            row2.Controls.Add(r3)

            ra.ColumnSpan = 1
            ra.HorizontalAlign = HorizontalAlign.Left
            ra.Text = "<b><font size=2>Branch&nbsp;ID&nbsp;</font></b>"
            row2.Controls.Add(ra)

            r4.ColumnSpan = 1
            r4.HorizontalAlign = HorizontalAlign.Left
            r4.Text = "<b><font size=2>Branch&nbsp;</font></b>"
            row2.Controls.Add(r4)

            r5.ColumnSpan = 1
            r5.HorizontalAlign = HorizontalAlign.Left
            r5.Text = "<b><font size=2>Emp&nbsp;Code&nbsp;</font></b>"
            row2.Controls.Add(r5)

            r6.ColumnSpan = 1
            r6.HorizontalAlign = HorizontalAlign.Left
            r6.Text = "<b><font size=2>Emp&nbsp;Name&nbsp;</font></b>"
            row2.Controls.Add(r6)

            r7.ColumnSpan = 1
            r7.HorizontalAlign = HorizontalAlign.Left
            r7.Text = "<b><font size=2>Designation&nbsp;</font></b>"
            row2.Controls.Add(r7)

            r8.ColumnSpan = 1
            r8.HorizontalAlign = HorizontalAlign.Left
            r8.Text = "<b><font size=2>Department&nbsp;</font></b>"
            row2.Controls.Add(r8)

            r9.ColumnSpan = 1
            r9.HorizontalAlign = HorizontalAlign.Left
            r9.Text = "<b><font size=2>Post&nbsp;</font></b>"
            row2.Controls.Add(r9)



            amdmrmtable.Controls.Add(row2)

            Dim lineu As New TableRow
            Dim linecellu As New TableCell
            linecellu.ColumnSpan = 11
            linecellu.Text = "<hr>"
            lineu.Controls.Add(linecellu)
            amdmrmtable.Controls.Add(lineu)

            Dim ttype As String = ""

            For Each dr In dt.Rows

                i += 1

                If ttype <> dr(11).ToString Then

                    If ttype <> "" Then
                        Dim deptot As New TableRow
                        deptot.Width = 11
                        Dim deptotcell As New TableCell
                        deptotcell.ColumnSpan = 11
                        deptotcell.HorizontalAlign = HorizontalAlign.Left
                        deptotcell.BackColor = Drawing.Color.FloralWhite
                        deptotcell.Text = "<font size=2><b>Post&nbsp;Total&nbsp;:&nbsp;</b>" & tot & "</font>"
                        deptot.Controls.Add(deptotcell)
                        amdmrmtable.Controls.Add(deptot)

                        tot = 0
                    End If

                    Dim deprow As New TableRow
                    deprow.Width = 11
                    Dim deprowcell As New TableCell
                    deprowcell.ColumnSpan = 11
                    deprowcell.HorizontalAlign = HorizontalAlign.Left
                    deprowcell.BackColor = Drawing.Color.Cornsilk
                    deprowcell.Text = "<font size=3><b>" & dr(11).ToString & "</b>&nbsp;</font>"
                    deprow.Controls.Add(deprowcell)
                    amdmrmtable.Controls.Add(deprow)


                End If

                ttype = dr(11).ToString

                tot += 1

                Dim value As New TableRow
                value.Width = 11
                Dim v1, v2, v3, va, v4, v5, v6, v7, v8, v9, v10, v11 As New TableCell

                v1.ColumnSpan = 1   'Zonal&nbsp;Name
                v1.HorizontalAlign = HorizontalAlign.Left
                v1.Text = "<font size=2>" & dr(0) & "&nbsp;</font>"
                value.Controls.Add(v1)

                v2.ColumnSpan = 1  'Region&nbsp;Name
                v2.HorizontalAlign = HorizontalAlign.Left
                v2.Text = "<font size=2>" & dr(1) & "&nbsp;</font>"
                value.Controls.Add(v2)

                v3.ColumnSpan = 1  'Division&nbsp;Name
                v3.HorizontalAlign = HorizontalAlign.Left
                v3.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
                value.Controls.Add(v3)


                va.ColumnSpan = 1  'Area&nbsp;Name
                va.HorizontalAlign = HorizontalAlign.Left
                va.Text = "<font size=2>" & dr(3) & "&nbsp;</font>"
                value.Controls.Add(va)

                v4.ColumnSpan = 1  'Branch&nbsp;ID
                v4.HorizontalAlign = HorizontalAlign.Left
                v4.Text = "<font size=2>" & dr(4) & "&nbsp;</font>"
                value.Controls.Add(v4)

                v5.ColumnSpan = 1  'Branch
                v5.HorizontalAlign = HorizontalAlign.Left
                v5.Text = "<font size=2>" & dr(5) & "&nbsp;</font>"
                value.Controls.Add(v5)

                v6.ColumnSpan = 1 'Emp&nbsp;Code
                v6.HorizontalAlign = HorizontalAlign.Left
                v6.Text = "<b><font size=2>" & dr(6) & "&nbsp;</font></b>"
                value.Controls.Add(v6)

                v7.ColumnSpan = 1 'Emp&nbsp;Name
                v7.HorizontalAlign = HorizontalAlign.Left
                v7.Text = "<font size=2>" & dr(7) & "&nbsp;</font>"
                value.Controls.Add(v7)

                v8.ColumnSpan = 1  'Designation
                v8.HorizontalAlign = HorizontalAlign.Left
                v8.Text = "<font size=2>" & dr(8) & "&nbsp;</font>"
                value.Controls.Add(v8)

                v9.ColumnSpan = 1 'Department&
                v9.HorizontalAlign = HorizontalAlign.Left
                v9.Text = "<font size=2>" & dr(9) & "&nbsp;</font>"
                value.Controls.Add(v9)

                v10.ColumnSpan = 1 'Post
                v10.HorizontalAlign = HorizontalAlign.Left
                v10.Text = "<font size=2>" & dr(10) & "&nbsp;</font>"
                value.Controls.Add(v10)


                amdmrmtable.Controls.Add(value)

            Next

            Dim deptot1 As New TableRow
            deptot1.Width = 11
            Dim deptotcell1 As New TableCell
            deptotcell1.ColumnSpan = 11
            deptotcell1.BackColor = Drawing.Color.FloralWhite
            deptotcell1.HorizontalAlign = HorizontalAlign.Left
            deptotcell1.Text = "<font size=2><b>Post&nbsp;Total&nbsp;:&nbsp;</b>" & tot & "</font>"
            deptot1.Controls.Add(deptotcell1)
            amdmrmtable.Controls.Add(deptot1)

            Dim line4 As New TableRow
            line4.Width = 11
            Dim linecell4 As New TableCell
            linecell4.ColumnSpan = 11
            linecell4.Text = "<hr>"
            line4.Controls.Add(linecell4)
            amdmrmtable.Controls.Add(line4)


            Dim qlast As New TableRow
            qlast.Width = 11
            Dim q As New TableCell
            q.ColumnSpan = 11
            q.HorizontalAlign = HorizontalAlign.Left
            q.Text = "<font size=2>Overall&nbsp;Total:&nbsp;<b>" & Me.i & "</b>&nbsp;Employee(s)<font>"
            qlast.Controls.Add(q)
            amdmrmtable.Controls.Add(qlast)


        Else

            Dim warn As New TableRow
            warn.Width = 11
            Dim w1 As New TableCell
            w1.ColumnSpan = 11
            w1.HorizontalAlign = HorizontalAlign.Center
            w1.Text = "<b><font size=3> No Data !!</font></b>"
            warn.Controls.Add(w1)
            amdmrmtable.Controls.Add(warn)

        End If

        Panel_AMDMRM.Controls.Add(amdmrmtable)
    End Sub
End Class
