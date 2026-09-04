Imports System.Data
Imports System.Data.OracleClient
Partial Class emp_current_first_ce9e295e1743
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow

    Dim empdettable As New Table
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim header As New TableRow
        header.Width = 10
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        Dim headcell As New TableCell
        headcell.ColumnSpan = 10
        headcell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headcell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headcell)
        empdettable.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.Width = 10
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 10
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        empdettable.Controls.Add(sheader)


        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 10
        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 3
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 4
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subcell2.Text = " "
        subh.Controls.Add(subcell2)

        subcell3.ColumnSpan = 3
        subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.HorizontalAlign = HorizontalAlign.Center
        subh.Controls.Add(subcell3)

        empdettable.Controls.Add(subh)

        Dim pheader As New TableRow
        Dim pheadercell As New TableCell
        pheader.Width = 10
        pheadercell.ColumnSpan = 10
        pheadercell.HorizontalAlign = HorizontalAlign.Center


        
        pheadercell.Text = "<body align=center ><b><font size=3>Employee Current Status Report</font></b>"


        pheader.Controls.Add(pheadercell)
        empdettable.Controls.Add(pheader)



        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        line1.Width = 10
        linecell1.ColumnSpan = 10
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        empdettable.Controls.Add(line1)

        Dim deptid As Integer = Me.Request.QueryString("depid")

        If Me.Request.QueryString("depid") <> 0 Then
            Dim dename As String = oh.ExecuteDataSet("select upper(dep_name) from department_mst where dep_id=" & Me.Request.QueryString("depid") & "").Tables(0).Rows(0)(0)

            Dim field1 As New TableRow
            field1.Width = 10

            Dim f11, f12, f13 As New TableCell

            f11.ColumnSpan = 4
            f11.HorizontalAlign = HorizontalAlign.Left
            f11.Text = "<b><font size=2>Department Name&nbsp;</font></b>"
            field1.Controls.Add(f11)

            f12.ColumnSpan = 2
            f12.HorizontalAlign = HorizontalAlign.Center
            f12.Text = "<b><font size=2>:&nbsp;</font></b>"
            field1.Controls.Add(f12)

            f13.ColumnSpan = 4
            f13.HorizontalAlign = HorizontalAlign.Left
            f13.Text = "<b><font size=2>" & dename & "&nbsp;</font></b>"
            field1.Controls.Add(f13)

            empdettable.Controls.Add(field1)

            Dim field2 As New TableRow
            field2.Width = 10

            Dim f21, f22, f23, f24 As New TableCell

            f21.ColumnSpan = 4
            f21.HorizontalAlign = HorizontalAlign.Left
            f21.Text = "<a href=emp_current_report_ver3.aspx?deparid=" & deptid & "&status=" & 0 & " ><b><font size=2>Employees except Terminated and Resigned&nbsp;</font></b></a>"
            field2.Controls.Add(f21)

            f22.ColumnSpan = 2
            f22.HorizontalAlign = HorizontalAlign.Center
            f22.Text = "<b><font size=2>:&nbsp;</font></b>"
            field2.Controls.Add(f22)

            Dim cnt As Integer = oh.ExecuteDataSet("select count(ec.emp_code) from employee_current ec where ec.department_id=" & Me.Request.QueryString("depid") & " and ec.status_id not in (3,5) and ec.emp_code>9999").Tables(0).Rows(0)(0)


            f23.ColumnSpan = 2
            f23.HorizontalAlign = HorizontalAlign.Right
            f23.Text = "<b><font size=2>" & cnt & "&nbsp;</font></b>"
            field2.Controls.Add(f23)

            f24.ColumnSpan = 2
            f24.Text = " "
            field2.Controls.Add(f24)


            empdettable.Controls.Add(field2)

            Dim field3 As New TableRow
            field3.Width = 10

            Dim f31, f32, f33, f34 As New TableCell

            f31.ColumnSpan = 4
            f31.HorizontalAlign = HorizontalAlign.Left
            f31.Text = "<a href=emp_current_report_ver3.aspx?deparid=" & deptid & "&status=" & 1 & " ><b><font size=2>Employees Now Live&nbsp;</font></b></a>"
            field3.Controls.Add(f31)

            f32.ColumnSpan = 2
            f32.HorizontalAlign = HorizontalAlign.Center
            f32.Text = "<b><font size=2>:&nbsp;</font></b>"
            field3.Controls.Add(f32)

            Dim ncnt As Integer = oh.ExecuteDataSet("select count(ec.emp_code) from employee_current ec where ec.department_id=" & Me.Request.QueryString("depid") & " and ec.status_id=1 and ec.emp_code>9999").Tables(0).Rows(0)(0)


            f33.ColumnSpan = 2
            f33.HorizontalAlign = HorizontalAlign.Right
            f33.Text = "<b><font size=2>" & ncnt & "&nbsp;</font></b>"
            field3.Controls.Add(f33)

            f34.ColumnSpan = 2
            f34.Text = " "
            field3.Controls.Add(f34)


            empdettable.Controls.Add(field3)

            Dim field4 As New TableRow
            field4.Width = 10

            Dim f41, f42, f43, f44 As New TableCell

            f41.ColumnSpan = 4
            f41.HorizontalAlign = HorizontalAlign.Left
            f41.Text = "<a href=emp_current_report_ver3.aspx?deparid=" & deptid & "&status=" & 3 & " ><b><font size=2>Resigned Employees&nbsp;</font></b></a>"
            field4.Controls.Add(f41)

            f42.ColumnSpan = 2
            f42.HorizontalAlign = HorizontalAlign.Center
            f42.Text = "<b><font size=2>:&nbsp;</font></b>"
            field4.Controls.Add(f42)

            Dim rcnt As Integer = oh.ExecuteDataSet("select count(ec.emp_code) from employee_current ec where ec.department_id=" & Me.Request.QueryString("depid") & " and ec.status_id=3 and ec.emp_code>9999").Tables(0).Rows(0)(0)


            f43.ColumnSpan = 2
            f43.HorizontalAlign = HorizontalAlign.Right
            f43.Text = "<b><font size=2>" & rcnt & "&nbsp;</font></b>"
            field4.Controls.Add(f43)

            f44.ColumnSpan = 2
            f44.Text = " "
            field4.Controls.Add(f44)

            empdettable.Controls.Add(field4)

            Dim field5 As New TableRow
            field5.Width = 10

            Dim f51, f52, f53, f54 As New TableCell

            f51.ColumnSpan = 4
            f51.HorizontalAlign = HorizontalAlign.Left
            f51.Text = "<a href=emp_current_report_ver3.aspx?deparid=" & deptid & "&status=" & 4 & " ><b><font size=2>Suspended Employees&nbsp;</font></b></a>"
            field5.Controls.Add(f51)

            f52.ColumnSpan = 2
            f52.HorizontalAlign = HorizontalAlign.Center
            f52.Text = "<b><font size=2>:&nbsp;</font></b>"
            field5.Controls.Add(f52)

            Dim scnt As Integer = oh.ExecuteDataSet("select count(ec.emp_code) from employee_current ec where ec.department_id=" & Me.Request.QueryString("depid") & " and ec.status_id=4 and ec.emp_code>9999").Tables(0).Rows(0)(0)


            f53.ColumnSpan = 2
            f53.HorizontalAlign = HorizontalAlign.Right
            f53.Text = "<b><font size=2>" & scnt & "&nbsp;</font></b>"
            field5.Controls.Add(f53)

            f54.ColumnSpan = 2
            f54.Text = " "
            field5.Controls.Add(f54)

            empdettable.Controls.Add(field5)

            Dim field6 As New TableRow
            field6.Width = 10

            Dim f61, f62, f63, f64 As New TableCell

            f61.ColumnSpan = 4
            f61.HorizontalAlign = HorizontalAlign.Left
            f61.Text = "<a href=emp_current_report_ver3.aspx?deparid=" & deptid & "&status=" & 6 & " ><b><font size=2>Employees in Long Leave&nbsp;</font></b></a>"
            field6.Controls.Add(f61)

            f62.ColumnSpan = 2
            f62.HorizontalAlign = HorizontalAlign.Center
            f62.Text = "<b><font size=2>:&nbsp;</font></b>"
            field6.Controls.Add(f62)

            Dim lcnt As Integer = oh.ExecuteDataSet("select count(ec.emp_code) from employee_current ec where ec.department_id=" & Me.Request.QueryString("depid") & " and ec.status_id=6 and ec.emp_code>9999").Tables(0).Rows(0)(0)


            f63.ColumnSpan = 2
            f63.HorizontalAlign = HorizontalAlign.Right
            f63.Text = "<b><font size=2>" & lcnt & "&nbsp;</font></b>"
            field6.Controls.Add(f63)

            f64.ColumnSpan = 2
            f64.Text = " "
            field6.Controls.Add(f64)

            empdettable.Controls.Add(field6)

            Dim field7 As New TableRow
            field7.Width = 10

            Dim f71, f72, f73, f74 As New TableCell

            f71.ColumnSpan = 4
            f71.HorizontalAlign = HorizontalAlign.Left
            f71.Text = "<a href=emp_current_report_ver3.aspx?deparid=" & deptid & "&status=" & 10 & " ><b><font size=2>Employees in Maternity Leave&nbsp;</font></b></a>"
            field7.Controls.Add(f71)

            f72.ColumnSpan = 2
            f72.HorizontalAlign = HorizontalAlign.Center
            f72.Text = "<b><font size=2>:&nbsp;</font></b>"
            field7.Controls.Add(f72)

            Dim mcnt As Integer = oh.ExecuteDataSet("select count(ec.emp_code) from employee_current ec where ec.department_id=" & Me.Request.QueryString("depid") & " and ec.status_id=10 and ec.emp_code>9999").Tables(0).Rows(0)(0)


            f73.ColumnSpan = 2
            f73.HorizontalAlign = HorizontalAlign.Right
            f73.Text = "<b><font size=2>" & mcnt & "&nbsp;</font></b>"
            field7.Controls.Add(f73)

            f74.ColumnSpan = 2
            f74.Text = " "
            field7.Controls.Add(f74)

            empdettable.Controls.Add(field7)

            Dim field8 As New TableRow
            field8.Width = 10

            Dim f81, f82, f83, f84 As New TableCell

            f81.ColumnSpan = 4
            f81.HorizontalAlign = HorizontalAlign.Left
            f81.Text = "<a href=emp_current_report_ver3.aspx?deparid=" & deptid & "&status=" & 5 & " ><b><font size=2>Terminated Employees&nbsp;</font></b></a>"
            field8.Controls.Add(f81)

            f82.ColumnSpan = 2
            f82.HorizontalAlign = HorizontalAlign.Center
            f82.Text = "<b><font size=2>:&nbsp;</font></b>"
            field8.Controls.Add(f82)

            Dim tcnt As Integer = oh.ExecuteDataSet("select count(ec.emp_code) from employee_current ec,employee_master_dtl ed where ec.emp_code=ed.emp_code and ec.status_id=5 and ed.new_empcode is null and ec.department_id=" & Me.Request.QueryString("depid") & " and ec.emp_code>9999").Tables(0).Rows(0)(0)


            f83.ColumnSpan = 2
            f83.HorizontalAlign = HorizontalAlign.Right
            f83.Text = "<b><font size=2>" & tcnt & "&nbsp;</font></b>"
            field8.Controls.Add(f83)

            f84.ColumnSpan = 2
            f84.Text = " "
            field8.Controls.Add(f84)

            empdettable.Controls.Add(field8)

            Dim line2 As New TableRow
            Dim linecell2 As New TableCell
            line2.Width = 10
            linecell2.ColumnSpan = 10
            linecell2.Text = "<hr>"
            line2.Controls.Add(linecell2)
            empdettable.Controls.Add(line2)

        ElseIf Me.Request.QueryString("depid") = 0 Then
           
            Dim field1 As New TableRow
            field1.Width = 10

            Dim f11, f12, f13 As New TableCell

            f11.ColumnSpan = 4
            f11.HorizontalAlign = HorizontalAlign.Left
            f11.Text = "<b><font size=2>Department Name&nbsp;</font></b>"
            field1.Controls.Add(f11)

            f12.ColumnSpan = 2
            f12.HorizontalAlign = HorizontalAlign.Center
            f12.Text = "<b><font size=2>:&nbsp;</font></b>"
            field1.Controls.Add(f12)

            f13.ColumnSpan = 4
            f13.HorizontalAlign = HorizontalAlign.Left
            f13.Text = "<b><font size=2>All Departments&nbsp;</font></b>"
            field1.Controls.Add(f13)

            empdettable.Controls.Add(field1)

            Dim field2 As New TableRow
            field2.Width = 10

            Dim f21, f22, f23, f24 As New TableCell

            f21.ColumnSpan = 4
            f21.HorizontalAlign = HorizontalAlign.Left
            f21.Text = "<a href=emp_current_report_ver3.aspx?deparid=" & deptid & "&status=" & 0 & " ><b><font size=2>Employees except Terminated and Resigned&nbsp;</font></b></a>"
            field2.Controls.Add(f21)

            f22.ColumnSpan = 2
            f22.HorizontalAlign = HorizontalAlign.Center
            f22.Text = "<b><font size=2>:&nbsp;</font></b>"
            field2.Controls.Add(f22)

            Dim cnt As Integer = oh.ExecuteDataSet("select count(ec.emp_code) from employee_current ec,employ_firm f where ec.status_id not in (3,5)and ec.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and ec.emp_code>9999").Tables(0).Rows(0)(0)


            f23.ColumnSpan = 2
            f23.HorizontalAlign = HorizontalAlign.Right
            f23.Text = "<b><font size=2>" & cnt & "&nbsp;</font></b>"
            field2.Controls.Add(f23)

            f24.ColumnSpan = 2
            f24.Text = " "
            field2.Controls.Add(f24)


            empdettable.Controls.Add(field2)

            Dim field3 As New TableRow
            field3.Width = 10

            Dim f31, f32, f33, f34 As New TableCell

            f31.ColumnSpan = 4
            f31.HorizontalAlign = HorizontalAlign.Left
            f31.Text = "<a href=emp_current_report_ver3.aspx?deparid=" & deptid & "&status=" & 1 & " ><b><font size=2>Employees Now Live&nbsp;</font></b></a>"
            field3.Controls.Add(f31)

            f32.ColumnSpan = 2
            f32.HorizontalAlign = HorizontalAlign.Center
            f32.Text = "<b><font size=2>:&nbsp;</font></b>"
            field3.Controls.Add(f32)

            Dim ncnt As Integer = oh.ExecuteDataSet("select count(ec.emp_code) from employee_current ec,employ_firm f where ec.status_id=1 and ec.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and ec.emp_code>9999").Tables(0).Rows(0)(0)


            f33.ColumnSpan = 2
            f33.HorizontalAlign = HorizontalAlign.Right
            f33.Text = "<b><font size=2>" & ncnt & "&nbsp;</font></b>"
            field3.Controls.Add(f33)

            f34.ColumnSpan = 2
            f34.Text = " "
            field3.Controls.Add(f34)


            empdettable.Controls.Add(field3)

            Dim field4 As New TableRow
            field4.Width = 10

            Dim f41, f42, f43, f44 As New TableCell

            f41.ColumnSpan = 4
            f41.HorizontalAlign = HorizontalAlign.Left
            f41.Text = "<a href=emp_current_report_ver3.aspx?deparid=" & deptid & "&status=" & 3 & " ><b><font size=2>Resigned Employees&nbsp;</font></b></a>"
            field4.Controls.Add(f41)

            f42.ColumnSpan = 2
            f42.HorizontalAlign = HorizontalAlign.Center
            f42.Text = "<b><font size=2>:&nbsp;</font></b>"
            field4.Controls.Add(f42)

            Dim rcnt As Integer = oh.ExecuteDataSet("select count(ec.emp_code) from employee_current ec where ec.status_id=3 and ec.emp_code>9999").Tables(0).Rows(0)(0)


            f43.ColumnSpan = 2
            f43.HorizontalAlign = HorizontalAlign.Right
            f43.Text = "<b><font size=2>" & rcnt & "&nbsp;</font></b>"
            field4.Controls.Add(f43)

            f44.ColumnSpan = 2
            f44.Text = " "
            field4.Controls.Add(f44)

            empdettable.Controls.Add(field4)

            Dim field5 As New TableRow
            field5.Width = 10

            Dim f51, f52, f53, f54 As New TableCell

            f51.ColumnSpan = 4
            f51.HorizontalAlign = HorizontalAlign.Left
            f51.Text = "<a href=emp_current_report_ver3.aspx?deparid=" & deptid & "&status=" & 4 & " ><b><font size=2>Suspended Employees&nbsp;</font></b></a>"
            field5.Controls.Add(f51)

            f52.ColumnSpan = 2
            f52.HorizontalAlign = HorizontalAlign.Center
            f52.Text = "<b><font size=2>:&nbsp;</font></b>"
            field5.Controls.Add(f52)

            Dim scnt As Integer = oh.ExecuteDataSet("select count(ec.emp_code) from employee_current ec where ec.status_id=4 and ec.emp_code>9999").Tables(0).Rows(0)(0)


            f53.ColumnSpan = 2
            f53.HorizontalAlign = HorizontalAlign.Right
            f53.Text = "<b><font size=2>" & scnt & "&nbsp;</font></b>"
            field5.Controls.Add(f53)

            f54.ColumnSpan = 2
            f54.Text = " "
            field5.Controls.Add(f54)

            empdettable.Controls.Add(field5)

            Dim field6 As New TableRow
            field6.Width = 10

            Dim f61, f62, f63, f64 As New TableCell

            f61.ColumnSpan = 4
            f61.HorizontalAlign = HorizontalAlign.Left
            f61.Text = "<a href=emp_current_report_ver3.aspx?deparid=" & deptid & "&status=" & 6 & " ><b><font size=2>Employees in Long Leave&nbsp;</font></b></a>"
            field6.Controls.Add(f61)

            f62.ColumnSpan = 2
            f62.HorizontalAlign = HorizontalAlign.Center
            f62.Text = "<b><font size=2>:&nbsp;</font></b>"
            field6.Controls.Add(f62)

            Dim lcnt As Integer = oh.ExecuteDataSet("select count(ec.emp_code) from employee_current ec where ec.status_id=6 and ec.emp_code>9999").Tables(0).Rows(0)(0)


            f63.ColumnSpan = 2
            f63.HorizontalAlign = HorizontalAlign.Right
            f63.Text = "<b><font size=2>" & lcnt & "&nbsp;</font></b>"
            field6.Controls.Add(f63)

            f64.ColumnSpan = 2
            f64.Text = " "
            field6.Controls.Add(f64)

            empdettable.Controls.Add(field6)

            Dim field7 As New TableRow
            field7.Width = 10

            Dim f71, f72, f73, f74 As New TableCell

            f71.ColumnSpan = 4
            f71.HorizontalAlign = HorizontalAlign.Left
            f71.Text = "<a href=emp_current_report_ver3.aspx?deparid=" & deptid & "&status=" & 10 & " ><b><font size=2>Employees in Maternity Leave&nbsp;</font></b></a>"
            field7.Controls.Add(f71)

            f72.ColumnSpan = 2
            f72.HorizontalAlign = HorizontalAlign.Center
            f72.Text = "<b><font size=2>:&nbsp;</font></b>"
            field7.Controls.Add(f72)

            Dim mcnt As Integer = oh.ExecuteDataSet("select count(ec.emp_code) from employee_current ec where ec.status_id=10 and ec.emp_code>9999").Tables(0).Rows(0)(0)


            f73.ColumnSpan = 2
            f73.HorizontalAlign = HorizontalAlign.Right
            f73.Text = "<b><font size=2>" & mcnt & "&nbsp;</font></b>"
            field7.Controls.Add(f73)

            f74.ColumnSpan = 2
            f74.Text = " "
            field7.Controls.Add(f74)

            empdettable.Controls.Add(field7)

            Dim field8 As New TableRow
            field8.Width = 10

            Dim f81, f82, f83, f84 As New TableCell

            f81.ColumnSpan = 4
            f81.HorizontalAlign = HorizontalAlign.Left
            f81.Text = "<a href=emp_current_report_ver3.aspx?deparid=" & deptid & "&status=" & 5 & " ><b><font size=2>Terminated Employees&nbsp;</font></b></a>"
            field8.Controls.Add(f81)

            f82.ColumnSpan = 2
            f82.HorizontalAlign = HorizontalAlign.Center
            f82.Text = "<b><font size=2>:&nbsp;</font></b>"
            field8.Controls.Add(f82)

            Dim tcnt As Integer = oh.ExecuteDataSet("select count(ec.emp_code) from employee_current ec,employee_master_dtl ed where ec.emp_code=ed.emp_code  and ec.status_id=5 and ed.new_empcode is null and ec.emp_code>9999").Tables(0).Rows(0)(0)


            f83.ColumnSpan = 2
            f83.HorizontalAlign = HorizontalAlign.Right
            f83.Text = "<b><font size=2>" & tcnt & "&nbsp;</font></b>"
            field8.Controls.Add(f83)

            f84.ColumnSpan = 2
            f84.Text = " "
            field8.Controls.Add(f84)

            empdettable.Controls.Add(field8)

            Dim line2 As New TableRow
            Dim linecell2 As New TableCell
            line2.Width = 10
            linecell2.ColumnSpan = 10
            linecell2.Text = "<hr>"
            line2.Controls.Add(linecell2)
            empdettable.Controls.Add(line2)




        End If



        Panel_Curr_detls.Controls.Add(empdettable)
    End Sub
End Class
