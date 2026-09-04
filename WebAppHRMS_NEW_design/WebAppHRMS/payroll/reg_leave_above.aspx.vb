Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_above_10_reg_leave_above_faa274a19717
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim edes As Integer = 0
    Dim epost As Integer = 0
    Dim total As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Region_table As New Table
        Region_table.Attributes.Add("width", "100%")

        Me.edes = Me.Request.QueryString("designation")
        Me.epost = Me.Request.QueryString("post")

        Dim header As New TableRow
        header.Width = 10
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        Dim headcell As New TableCell
        headcell.ColumnSpan = 10
        headcell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headcell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headcell)
        Region_table.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.Width = 10
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 10
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        Region_table.Controls.Add(sheader)


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
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)

        Region_table.Controls.Add(subh)

        Dim pheader As New TableRow
        Dim pheadercell As New TableCell
        pheader.Width = 10
        pheadercell.ColumnSpan = 10
        pheadercell.HorizontalAlign = HorizontalAlign.Center

        pheadercell.Text = "<body align=center ><b><font size=3> Regionwise list of employees having  " & Me.Request.QueryString("leaveno") & " or more leaves </font></b>"
        pheader.Controls.Add(pheadercell)
        Region_table.Controls.Add(pheader)

        Dim pheaderq As New TableRow
        Dim pheadercellq As New TableCell
        pheaderq.Width = 10
        pheadercellq.ColumnSpan = 10

        If Me.Request.QueryString("designation") <> 0 Then
            Dim s As String = oh.ExecuteDataSet("select designation from designation_master where designation_id=" & Me.Request.QueryString("designation")).Tables(0).Rows(0)(0)
            pheadercellq.Text = "<b><font size=3>Employees with Designation:" & s & "</font></b>"
        ElseIf Me.Request.QueryString("post") <> 0 Then
            Dim s As String = oh.ExecuteDataSet("select post_name from post_mst where post_id=" & Me.Request.QueryString("post")).Tables(0).Rows(0)(0)
            pheadercellq.Text = "<b><font size=3>Employees with Post:" & s & "</font></b>"
        End If


        pheadercellq.HorizontalAlign = HorizontalAlign.Center
        pheaderq.Controls.Add(pheadercellq)
        Region_table.Controls.Add(pheaderq)

        If Me.Request.QueryString("status") = 0 Then


            If Me.Request.QueryString("designation") <> 0 Then

                str = "select c.reg_id,c.REG_NAME,count(a.emp_code) from employee_master a,branch_detail c,employ_firm f where a.status_id not in (3,5) and a.designation_id=" & Me.Request.QueryString("designation") & " and a.emp_code in (select emp_code from employ_leave_dtl where to_date(leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and leave_process_id in (1,2)having sum(leave_days)>=" & Me.Request.QueryString("leaveno") & " group by emp_code)and a.branch_id=c.BRANCH_ID and c.zonal_id=" & Me.Request.QueryString("zonalid") & " and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " group by c.reg_id,c.REG_NAME"

            ElseIf Me.Request.QueryString("post") <> 0 Then

                str = "select c.reg_id,c.REG_NAME,count(a.emp_code) from employee_master a,branch_detail c,employ_firm f where a.status_id not in (3,5) and a.post_id=" & Me.Request.QueryString("post") & " and a.emp_code in (select emp_code from employ_leave_dtl where to_date(leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and leave_process_id in (1,2)having sum(leave_days)>=" & Me.Request.QueryString("leaveno") & " group by emp_code)and a.branch_id=c.BRANCH_ID and c.zonal_id=" & Me.Request.QueryString("zonalid") & " and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " group by c.reg_id,c.REG_NAME"

            Else
                str = "select c.reg_id,c.REG_NAME,count(a.emp_code) from employee_master a,branch_detail c,employ_firm f where a.status_id not in (3,5) and a.emp_code in (select emp_code from employ_leave_dtl where to_date(leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and leave_process_id in (1,2)having sum(leave_days)>=" & Me.Request.QueryString("leaveno") & " group by emp_code)and a.branch_id=c.BRANCH_ID and c.zonal_id=" & Me.Request.QueryString("zonalid") & " and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " group by c.reg_id,c.REG_NAME"

            End If

        ElseIf Me.Request.QueryString("status") = 1 Then


            If Me.Request.QueryString("designation") <> 0 Then

                str = "select c.reg_id,c.REG_NAME,count(a.emp_code) from employee_master a,branch_detail c,employ_firm f where a.status_id not in (3,5) and a.emp_type=1 and a.designation_id=" & Me.Request.QueryString("designation") & " and a.emp_code in (select emp_code from employ_leave_dtl where to_date(leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and leave_process_id in (1,2)having sum(leave_days)>=" & Me.Request.QueryString("leaveno") & " group by emp_code)and a.branch_id=c.BRANCH_ID and c.zonal_id=" & Me.Request.QueryString("zonalid") & " and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " group by c.reg_id,c.REG_NAME"

            ElseIf Me.Request.QueryString("post") <> 0 Then

                str = "select c.reg_id,c.REG_NAME,count(a.emp_code) from employee_master a,branch_detail c,employ_firm f where a.status_id not in (3,5) and a.emp_type=1 and a.post_id=" & Me.Request.QueryString("post") & " and a.emp_code in (select emp_code from employ_leave_dtl where to_date(leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and leave_process_id in (1,2)having sum(leave_days)>=" & Me.Request.QueryString("leaveno") & " group by emp_code)and a.branch_id=c.BRANCH_ID and c.zonal_id=" & Me.Request.QueryString("zonalid") & " and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " group by c.reg_id,c.REG_NAME"

            Else
                str = "select c.reg_id,c.REG_NAME,count(a.emp_code) from employee_master a,branch_detail c,employ_firm f where a.status_id not in (3,5) and a.emp_type=1 a.emp_code in (select emp_code from employ_leave_dtl where to_date(leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and leave_process_id in (1,2)having sum(leave_days)>=" & Me.Request.QueryString("leaveno") & " group by emp_code)and a.branch_id=c.BRANCH_ID and c.zonal_id=" & Me.Request.QueryString("zonalid") & " and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " group by c.reg_id,c.REG_NAME"

            End If


        ElseIf Me.Request.QueryString("status") = 2 Then


            If Me.Request.QueryString("designation") <> 0 Then

                str = "select c.reg_id,c.REG_NAME,count(a.emp_code) from employee_master a,branch_detail c,employ_firm f where a.status_id not in (3,5) and a.emp_type=2 and a.designation_id=" & Me.Request.QueryString("designation") & " and a.emp_code in (select emp_code from employ_leave_dtl where to_date(leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and leave_process_id in (1,2)having sum(leave_days)>=" & Me.Request.QueryString("leaveno") & " group by emp_code)and a.branch_id=c.BRANCH_ID and c.zonal_id=" & Me.Request.QueryString("zonalid") & " and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " group by c.reg_id,c.REG_NAME"

            ElseIf Me.Request.QueryString("post") <> 0 Then

                str = "select c.reg_id,c.REG_NAME,count(a.emp_code) from employee_master a,branch_detail c,employ_firm f where a.status_id not in (3,5) and a.emp_type=2 and a.post_id=" & Me.Request.QueryString("post") & " and a.emp_code in (select emp_code from employ_leave_dtl where to_date(leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and leave_process_id in (1,2)having sum(leave_days)>=" & Me.Request.QueryString("leaveno") & " group by emp_code)and a.branch_id=c.BRANCH_ID and c.zonal_id=" & Me.Request.QueryString("zonalid") & " and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " group by c.reg_id,c.REG_NAME"

            Else
                str = "select c.reg_id,c.REG_NAME,count(a.emp_code) from employee_master a,branch_detail c,employ_firm f where a.status_id not in (3,5) and a.emp_type=2 and a.emp_code in (select emp_code from employ_leave_dtl where to_date(leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and leave_process_id in (1,2)having sum(leave_days)>=" & Me.Request.QueryString("leaveno") & " group by emp_code)and a.branch_id=c.BRANCH_ID and c.zonal_id=" & Me.Request.QueryString("zonalid") & " and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " group by c.reg_id,c.REG_NAME"

            End If


        End If

        dt = oh.ExecuteDataSet(str).Tables(0)


        pheaderq.Controls.Add(pheadercellq)
        Region_table.Controls.Add(pheaderq)

        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        line1.Width = 10
        linecell1.ColumnSpan = 10
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        Region_table.Controls.Add(line1)





        Dim field As New TableRow
        field.Width = 10
        Dim f1, f2, f3, fll, f4, f5, f6, f7, f8, f9, f10 As New TableCell

        'f1.ColumnSpan = 1
        'f1.HorizontalAlign = HorizontalAlign.Center
        'f1.Text = "<b><font size=2>Si No</font></b>"
        'field.Controls.Add(f1)

        f2.ColumnSpan = 5
        f2.HorizontalAlign = HorizontalAlign.Center
        f2.Text = "<b><font size=2>Region Name</font></b>"
        field.Controls.Add(f2)

        f3.ColumnSpan = 5
        f3.HorizontalAlign = HorizontalAlign.Center
        f3.Text = "<b><font size=2>No of Employees</font></b>"
        field.Controls.Add(f3)

        'fll.ColumnSpan = 6
        'fll.HorizontalAlign = HorizontalAlign.Center
        'fll.Text = "<b><font size=2>Dept/Branch Name</font></b>"
        'field.Controls.Add(fll)

        'f4.ColumnSpan = 2
        'f4.HorizontalAlign = HorizontalAlign.Center
        'f4.Text = "<b><font size=2>Total Leave</font></b>"
        'field.Controls.Add(f4)

        'f5.ColumnSpan = 1
        'f5.HorizontalAlign = HorizontalAlign.Center
        'f5.Text = "<b><font size=2>S/L</font></b>"
        'field.Controls.Add(f5)

        'f6.ColumnSpan = 1
        'f6.HorizontalAlign = HorizontalAlign.Center
        'f6.Text = "<b><font size=2>E/L</font></b>"
        'field.Controls.Add(f6)

        'f7.ColumnSpan = 1
        'f7.HorizontalAlign = HorizontalAlign.Center
        'f7.Text = "<b><font size=2>L.O.P</font></b>"
        'field.Controls.Add(f7)

        'f8.ColumnSpan = 1
        'f8.HorizontalAlign = HorizontalAlign.Center
        'f8.Text = "<b><font size=2>Leave&nbsp;From</font></b>"
        'field.Controls.Add(f8)

        'f9.ColumnSpan = 1
        'f9.HorizontalAlign = HorizontalAlign.Center
        'f9.Text = "<b><font size=2>Leave&nbsp;To</font></b>"
        'field.Controls.Add(f9)

        'f10.ColumnSpan = 1
        'f10.HorizontalAlign = HorizontalAlign.Center
        'f10.Text = "<b><font size=2>Reason</font></b>"
        'field.Controls.Add(f10)

        Region_table.Controls.Add(field)

        Dim linek As New TableRow
        Dim linecellk As New TableCell
        linek.Width = 10
        linecellk.ColumnSpan = 10
        linecellk.Text = "<hr>"
        linek.Controls.Add(linecellk)
        Region_table.Controls.Add(linek)

        For Each dr In dt.Rows

            Dim val As New TableRow
            val.Width = 10
            Dim v1, v2 As New TableCell

            v1.ColumnSpan = 5
            v1.HorizontalAlign = HorizontalAlign.Left
            '<a href=divisionwise_leave.aspx?regionid=" & dr(0) & "&designation=" & Me.edes & "&post=" & Me.epost & "&leaveno=" & Me.Request.QueryString("leaveno") & "><font size=2>" & dr(1) & "</font></a>"
            v1.Text = "<a href=divisionwise_leave.aspx?status=" & Me.Request.QueryString("status") & "&regionid=" & dr(0) & "&designation=" & Me.edes & "&post=" & Me.epost & "&leaveno=" & Me.Request.QueryString("leaveno") & "><font size=2>" & dr(1) & "</font></a>"
            val.Controls.Add(v1)

            v2.ColumnSpan = 5
            v2.HorizontalAlign = HorizontalAlign.Right
            v2.Text = "<font size=2>" & dr(2) & "</font>"
            val.Controls.Add(v2)
            total += dr(2)

            Region_table.Controls.Add(val)

        Next

        Dim linee As New TableRow
        Dim linecelle As New TableCell
        linee.Width = 10
        linecelle.ColumnSpan = 10
        linecelle.Text = "<hr>"
        linee.Controls.Add(linecelle)
        Region_table.Controls.Add(linee)

        Dim totrow As New TableRow
        totrow.Width = 10
        Dim t1 As New TableCell
        t1.ColumnSpan = 10
        t1.HorizontalAlign = HorizontalAlign.Right
        t1.Text = "<b><font size=2> Total Employees:&nbsp;" & Me.total & "</font></b>"
        totrow.Controls.Add(t1)
        Region_table.Controls.Add(totrow)



        Panel_Region.Controls.Add(Region_table)



    End Sub
End Class
