Imports System.Data
Imports System.Data.OracleClient
Partial Class staffnorms_hoemps_267231457639
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim i As Integer = 0
    Dim tot As Integer = 0
    Dim hotable As New Table

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '                  0           1             2              3           4          
        str = "select em.emp_code,em.emp_name,dm.designation,dp.dep_name,pm.post_name from employee_master em left outer join designation_master dm on(em.designation_id=dm.designation_id) left outer join department_mst dp on (em.department_id=dp.dep_id) left outer join post_mst pm on(em.post_id=pm.post_id) where em.emp_code in(select emp_code from employee_involve) and em.department_id<>154 and em.status_id=1 and em.branch_id=0 and em.emp_code>9999 and em.shift_id not in(4,5)order by dep_name,emp_code"
        dt = oh.ExecuteDataSet(str).Tables(0)
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
            hotable.Controls.Add(header)

            Dim sheader As New TableRow
            sheader.BackColor = Drawing.Color.LightGray
            Dim sheadercell1 As New TableCell
            Dim sheadercell2 As New TableCell
            sheadercell1.ColumnSpan = 7
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
            sheader.Controls.Add(sheadercell1)
            hotable.Controls.Add(sheader)

            Dim tt As New TableRow
            tt.BackColor = Drawing.Color.LightSkyBlue
            tt.Width = 7
            Dim tt1 As New TableCell
            tt1.ColumnSpan = 7
            tt1.HorizontalAlign = HorizontalAlign.Center
            tt1.Text = "<b><font size=2>List Of Head Office Employees</font></b>"
            tt.Controls.Add(tt1)
            hotable.Controls.Add(tt)

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
            subh.Controls.Add(subcell2)
            subcell3.ColumnSpan = 2
            subcell3.HorizontalAlign = HorizontalAlign.Left
            subcell3.Text = "<b><font size=2.5>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
            subcell3.HorizontalAlign = HorizontalAlign.Right
            subh.Controls.Add(subcell3)
            hotable.Controls.Add(subh)

            Dim line As New TableRow
            Dim linecell As New TableCell
            linecell.ColumnSpan = 7
            linecell.Text = "<hr>"
            line.Controls.Add(linecell)
            hotable.Controls.Add(line)

            Dim row2 As New TableRow
            row2.Width = 7
            Dim r1, r2, ra, r3, re, r4, r5 As New TableCell

            r1.ColumnSpan = 1
            r1.HorizontalAlign = HorizontalAlign.Left
            r1.Text = "<b><font size=2>Employee&nbsp;Code&nbsp;</font></b>"
            row2.Controls.Add(r1)

            r2.ColumnSpan = 2
            r2.HorizontalAlign = HorizontalAlign.Left
            r2.Text = "<b><font size=2>Employee&nbsp;Name&nbsp;</font></b>"
            row2.Controls.Add(r2)

            're.ColumnSpan = 1
            're.HorizontalAlign = HorizontalAlign.Left
            're.Text = "<b><font size=2>Branch&nbsp;ID&nbsp;</font></b>"
            'row2.Controls.Add(re)


            'r3.ColumnSpan = 1
            'r3.HorizontalAlign = HorizontalAlign.Left
            'r3.Text = "<b><font size=2>Branch&nbsp;</font></b>"
            'row2.Controls.Add(r3)

            ra.ColumnSpan = 2
            ra.HorizontalAlign = HorizontalAlign.Left
            ra.Text = "<b><font size=2>Designation&nbsp;</font></b>"
            row2.Controls.Add(ra)

            'r4.ColumnSpan = 1
            'r4.HorizontalAlign = HorizontalAlign.Left
            'r4.Text = "<b><font size=2>Department&nbsp;</font></b>"
            'row2.Controls.Add(r4)

            r5.ColumnSpan = 2
            r5.HorizontalAlign = HorizontalAlign.Left
            r5.Text = "<b><font size=2>Post&nbsp;</font></b>"
            row2.Controls.Add(r5)


            hotable.Controls.Add(row2)

            Dim lineu As New TableRow
            Dim linecellu As New TableCell
            linecellu.ColumnSpan = 7
            linecellu.Text = "<hr>"
            lineu.Controls.Add(linecellu)
            hotable.Controls.Add(lineu)

            Dim depname As String = ""

            For Each dr In dt.Rows

                i += 1

                If depname <> dr(3).ToString Then

                    If depname <> "" Then
                        Dim deptot As New TableRow
                        deptot.Width = 7
                        Dim deptotcell As New TableCell
                        deptotcell.ColumnSpan = 7
                        deptotcell.HorizontalAlign = HorizontalAlign.Left
                        deptotcell.BackColor = Drawing.Color.FloralWhite
                        deptotcell.Text = "<font size=2><b>Department&nbsp;Total&nbsp;:&nbsp;</b>" & tot & "</font>"
                        deptot.Controls.Add(deptotcell)
                        hotable.Controls.Add(deptot)

                        tot = 0
                    End If

                    Dim deprow As New TableRow
                    deprow.Width = 7
                    Dim deprowcell As New TableCell
                    deprowcell.ColumnSpan = 7
                    deprowcell.HorizontalAlign = HorizontalAlign.Left
                    deprowcell.BackColor = Drawing.Color.Cornsilk
                    deprowcell.Text = "<font size=3><b>" & dr(3).ToString & "</b>&nbsp;&nbsp;Department</font>"
                    deprow.Controls.Add(deprowcell)
                    hotable.Controls.Add(deprow)


                End If

                depname = dr(3).ToString

                tot += 1


                Dim value As New TableRow
                value.Width = 7
                Dim v1, v2, v3, va, v4, v5, v6 As New TableCell

                v1.ColumnSpan = 1        'Empcode
                v1.HorizontalAlign = HorizontalAlign.Left
                v1.Text = "<font size=2><b>" & dr(0) & "&nbsp;</b></font>"
                value.Controls.Add(v1)

                v2.ColumnSpan = 2        'EmpName
                v2.HorizontalAlign = HorizontalAlign.Left
                v2.Text = "<font size=2>" & dr(1) & "&nbsp;</font>"
                value.Controls.Add(v2)

                'v3.ColumnSpan = 1    'Bid
                'v3.HorizontalAlign = HorizontalAlign.Left
                'If IsDBNull(dr(2)) Then
                '    v3.Text = "<font size=2>----&nbsp;</font>"
                'Else
                '    v3.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
                'End If
                'value.Controls.Add(v3)

                'va.ColumnSpan = 1    'Banem
                'va.HorizontalAlign = HorizontalAlign.Left
                'If IsDBNull(dr(3)) Then
                '    va.Text = "<font size=2>----&nbsp;</font>"
                'Else
                '    va.Text = "<font size=2>" & dr(3) & "&nbsp;</font>"
                'End If
                'value.Controls.Add(va)

                v4.ColumnSpan = 2  'Designation
                v4.HorizontalAlign = HorizontalAlign.Left
                If IsDBNull(dr(2)) Then
                    v4.Text = "<font size=2>----&nbsp;</font>"
                Else
                    v4.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
                End If
                value.Controls.Add(v4)

                'v5.ColumnSpan = 1   'Department
                'v5.HorizontalAlign = HorizontalAlign.Left
                'If IsDBNull(dr(5)) Then
                '    v5.Text = "<font size=2>----&nbsp;</font>"
                'Else
                '    v5.Text = "<font size=2>" & dr(5) & "&nbsp;</font>"
                'End If
                'value.Controls.Add(v5)

                v6.ColumnSpan = 2  'post
                v6.HorizontalAlign = HorizontalAlign.Left
                If IsDBNull(dr(4)) Then
                    v6.Text = "<font size=2>----&nbsp;</font>"
                Else
                    v6.Text = "<font size=2>" & dr(4) & "&nbsp;</font>"
                End If
                value.Controls.Add(v6)


                hotable.Controls.Add(value)

            Next

            Dim deptot1 As New TableRow
            deptot1.Width = 7
            Dim deptotcell1 As New TableCell
            deptotcell1.ColumnSpan = 7
            deptotcell1.HorizontalAlign = HorizontalAlign.Left
            deptotcell1.BackColor = Drawing.Color.FloralWhite
            deptotcell1.Text = "<font size=2><b>Department&nbsp;Total&nbsp;:&nbsp;</b>" & tot & "</font>"
            deptot1.Controls.Add(deptotcell1)
            hotable.Controls.Add(deptot1)


            Dim line4 As New TableRow
            Dim linecell4 As New TableCell
            linecell4.ColumnSpan = 7
            linecell4.Text = "<hr>"
            line4.Controls.Add(linecell4)
            hotable.Controls.Add(line4)


            Dim qlast As New TableRow
            qlast.Width = 7
            Dim q As New TableCell
            q.ColumnSpan = 7
            q.HorizontalAlign = HorizontalAlign.Left
            q.Text = "<font size=3>Total:&nbsp;<b>" & Me.i & "</b>&nbsp;Employee(s)<font>"
            qlast.Controls.Add(q)
            hotable.Controls.Add(qlast)


        Else

            Dim warn As New TableRow
            warn.Width = 7
            Dim w1 As New TableCell
            w1.ColumnSpan = 7
            w1.HorizontalAlign = HorizontalAlign.Center
            w1.Text = "<b><font size=3> No Data !!</font></b>"
            warn.Controls.Add(w1)
            hotable.Controls.Add(warn)

        End If

        Panel_HO.Controls.Add(hotable)
    End Sub
End Class
