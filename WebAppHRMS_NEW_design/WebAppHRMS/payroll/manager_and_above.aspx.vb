Imports System.Data
Imports System.Data.OracleClient
Partial Class manager_and_above_12a1d39a9859
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim i As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '                   0            1           2           3                             4                                                                                         5           6                       7
        str = "select bm.branch_name,  em.emp_code,  em.emp_name,  dm.designation,  case  when em.department_id = 0 or em.department_id is null then  '-----'  else  dp.dep_name  end as Department,  em.join_dt,  fm.firm_abbr,  decode(em.status_id, 1, 'Live', 6, 'L\L', 10, 'Mat.Leave') as Current_Status  from employee_master em  left outer join department_mst dp on (em.department_id = dp.dep_id),  branch_master bm, designation_master dm,employ_firm f,  firm_master fm  where em.designation_id = dm.designation_id  and em.emp_code=f.emp_code  and f.firm_id=fm.firm_id  and f.firm_id=" & Session("firm_id") & "  and em.branch_id = bm.branch_id  and em.emp_code > 9999  and em.shift_id not in (4, 5)  and em.status_id in (1, 6, 10)  and em.grade_id <= 11  union  select bc.branch_name,  em.emp_code,  em.emp_name,  dm.designation,  case  when em.department_id = 0 or em.department_id is null then  '-----'  else  dp.dep_name  end as Department,  em.join_dt,  fm.firm_abbr,  decode(em.status_id, 1, 'Live', 6, 'L\L', 10, 'Mat.Leave') as Current_Status  from employee_master em  left outer join department_mst dp on (em.department_id = dp.dep_id),  before_completion bc,  designation_master dm, firm_master fm,employ_firm f  where em.designation_id = dm.designation_id  and em.emp_code=f.emp_code  and f.firm_id=fm.firm_id  and f.firm_id=" & Session("firm_id") & "  and em.branch_id = bc.old_id  and bc.branch_id is null  and em.emp_code > 9999  and em.shift_id not in (4, 5)  and em.status_id in (1, 6, 10)  and em.grade_id <= 11  order by branch_name, emp_code"
        dt = oh.ExecuteDataSet(str).Tables(0)

        Dim mgr_abv_table As New Table

        mgr_abv_table.Attributes.Add("width", "100%")
        Dim header As New TableRow
        header.Width = 9
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        Dim headcell As New TableCell
        headcell.ColumnSpan = 9
        headcell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headcell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headcell)
        mgr_abv_table.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.Width = 9
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 9
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        mgr_abv_table.Controls.Add(sheader)


        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 9
        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 2
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 4
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subcell2.Text = " "
        subh.Controls.Add(subcell2)

        subcell3.ColumnSpan = 3
        subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)

        mgr_abv_table.Controls.Add(subh)

        Dim pheader As New TableRow
        Dim pheadercell As New TableCell
        pheader.Width = 9
        pheadercell.ColumnSpan = 9
        pheadercell.HorizontalAlign = HorizontalAlign.Center

        pheadercell.Text = "<body align=center ><b><font size=3>List of Managers and Above Positioned Employees</font></b>"
        pheader.Controls.Add(pheadercell)
        mgr_abv_table.Controls.Add(pheader)


        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        line1.Width = 9
        linecell1.ColumnSpan = 9
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        mgr_abv_table.Controls.Add(line1)

        Dim colors As String
        colors = "#fff7ff"

        Dim field As New TableRow
        field.Width = 9
        field.Attributes.Add("bgcolor", colors)
        Dim f1, f2, f3, f4, f5, f6, f7, f8, f9 As New TableCell

        f1.ColumnSpan = 1
        f1.HorizontalAlign = HorizontalAlign.Left
        f1.Text = "<b><font size=2>Si No</font></b>"
        field.Controls.Add(f1)

        f2.ColumnSpan = 1
        f2.HorizontalAlign = HorizontalAlign.Left
        f2.Text = "<b><font size=2>Branch</font></b>"
        field.Controls.Add(f2)

        f3.ColumnSpan = 1
        f3.HorizontalAlign = HorizontalAlign.Left
        f3.Text = "<b><font size=2>Emp Code</font></b>"
        field.Controls.Add(f3)

        f4.ColumnSpan = 1
        f4.HorizontalAlign = HorizontalAlign.Left
        f4.Text = "<b><font size=2>Emp Name</font></b>"
        field.Controls.Add(f4)

        f5.ColumnSpan = 1
        f5.HorizontalAlign = HorizontalAlign.Left
        f5.Text = "<b><font size=2>Desig.n</font></b>"
        field.Controls.Add(f5)

        f6.ColumnSpan = 1
        f6.HorizontalAlign = HorizontalAlign.Left
        f6.Text = "<b><font size=2>Deptmt</font></b>"
        field.Controls.Add(f6)

        f7.ColumnSpan = 1
        f7.HorizontalAlign = HorizontalAlign.Left
        f7.Text = "<b><font size=2>D.O.J</font></b>"
        field.Controls.Add(f7)

        f8.ColumnSpan = 1
        f8.HorizontalAlign = HorizontalAlign.Left
        f8.Text = "<b><font size=2>Firm</font></b>"
        field.Controls.Add(f8)

        f9.ColumnSpan = 1
        f9.HorizontalAlign = HorizontalAlign.Left
        f9.Text = "<b><font size=2>Curr. Status</font></b>"
        field.Controls.Add(f9)

        mgr_abv_table.Controls.Add(field)

        Dim b1 As New TableRow
        b1.Width = 9
        Dim bb1 As New TableCell
        bb1.ColumnSpan = 9
        bb1.Text = "<hr>"
        b1.Controls.Add(bb1)

        mgr_abv_table.Controls.Add(b1)

        For Each dr In dt.Rows

            i += 1

            If colors.Equals("#fff7ff") = True Then
                colors = "#eef9ff"
            Else
                colors = "#fff7ff"
            End If


            Dim value As New TableRow
            value.Width = 9
            value.Attributes.Add("bgcolor", colors)
            Dim v1, v2, v3, v4, v5, v6, v7, v8, v9 As New TableCell

            v1.ColumnSpan = 1
            v1.HorizontalAlign = HorizontalAlign.Left
            v1.Text = "<font size=2>" & i & "</font>"
            value.Controls.Add(v1)

            v2.ColumnSpan = 1
            v2.HorizontalAlign = HorizontalAlign.Left
            v2.Text = "<font size=2>" & dr(0) & "</font>"
            value.Controls.Add(v2)

            v3.ColumnSpan = 1
            v3.HorizontalAlign = HorizontalAlign.Left
            v3.Text = "<font size=2>" & dr(1) & "</font>"
            value.Controls.Add(v3)

            v4.ColumnSpan = 1
            v4.HorizontalAlign = HorizontalAlign.Left
            v4.Text = "<font size=2>" & dr(2) & "</font>"
            value.Controls.Add(v4)

            v5.ColumnSpan = 1
            v5.HorizontalAlign = HorizontalAlign.Left
            v5.Text = "<font size=2>" & dr(3) & "</font>"
            value.Controls.Add(v5)

            v6.ColumnSpan = 1
            v6.HorizontalAlign = HorizontalAlign.Left
            v6.Text = "<font size=2>" & dr(4) & "</font>"
            value.Controls.Add(v6)

            v7.ColumnSpan = 1
            v7.HorizontalAlign = HorizontalAlign.Left
            v7.Text = "<font size=2>" & Format(dr(5), "dd/MMM/yyyy") & "</font>"
            value.Controls.Add(v7)

            v8.ColumnSpan = 1
            v8.HorizontalAlign = HorizontalAlign.Left
            v8.Text = "<font size=2>" & dr(6) & "</font>"
            value.Controls.Add(v8)

            v9.ColumnSpan = 1
            v9.HorizontalAlign = HorizontalAlign.Left
            v9.Text = "<font size=2>" & dr(7) & "</font>"
            value.Controls.Add(v9)

            mgr_abv_table.Controls.Add(value)

        Next

        Dim b2 As New TableRow
        b2.Width = 9
        Dim bb2 As New TableCell
        bb2.ColumnSpan = 9
        bb2.Text = "<hr>"
        b2.Controls.Add(bb2)

        mgr_abv_table.Controls.Add(b2)

        Panel_mgr_abv.Controls.Add(mgr_abv_table)

    End Sub
End Class
