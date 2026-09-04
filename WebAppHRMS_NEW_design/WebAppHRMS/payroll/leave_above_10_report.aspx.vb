Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_above_10_report_125bf9e56149
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow

    Dim sql, str1 As String

    Dim lo_leavetable As New Table

    Dim i As Integer = 0



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


  

        lo_leavetable.Attributes.Add("width", "100%")
        Dim header As New TableRow
        header.Width = 10
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        Dim headcell As New TableCell
        headcell.ColumnSpan = 10
        headcell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headcell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headcell)
        lo_leavetable.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.Width = 10
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 10
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        lo_leavetable.Controls.Add(sheader)


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

        lo_leavetable.Controls.Add(subh)

        Dim pheader As New TableRow
        Dim pheadercell As New TableCell
        pheader.Width = 10
        pheadercell.ColumnSpan = 10
        pheadercell.HorizontalAlign = HorizontalAlign.Center

        pheadercell.Text = "<body align=center ><b><font size=3> Employees Having Leave Greater than or Equal to " & Me.Request.QueryString("leaveno") & " days </font></b>"
        pheader.Controls.Add(pheadercell)
        lo_leavetable.Controls.Add(pheader)

        Dim pheaderq As New TableRow
        Dim pheadercellq As New TableCell
        pheaderq.Width = 10
        pheadercellq.ColumnSpan = 10
        pheadercellq.HorizontalAlign = HorizontalAlign.Center
        Dim s As String = oh.ExecuteDataSet("select branch_name from branch_detail where branch_id=" & Me.Request.QueryString("branchid")).Tables(0).Rows(0)(0)
        pheadercellq.Text = "<body align=center ><b><font size=3>Branch Name:" & s & "</font></b>"
        pheaderq.Controls.Add(pheadercellq)
        lo_leavetable.Controls.Add(pheaderq)

        Dim pheader2 As New TableRow
        Dim pheadercell2 As New TableCell
        pheader2.Width = 10
        pheadercell2.ColumnSpan = 10

        If Me.Request.QueryString("designation") <> 0 Then
            Dim ss As String = oh.ExecuteDataSet("select designation from designation_master where designation_id=" & Me.Request.QueryString("designation")).Tables(0).Rows(0)(0)
            pheadercellq.Text = "<b><font size=3>Employees with Designation:" & ss & "</font></b>"
        ElseIf Me.Request.QueryString("post") <> 0 Then
            Dim ss As String = oh.ExecuteDataSet("select post_name from post_mst where post_id=" & Me.Request.QueryString("post")).Tables(0).Rows(0)(0)
            pheadercell2.Text = "<b><font size=3>Employees with Post:" & ss & "</font></b>"
        End If


        pheadercell2.HorizontalAlign = HorizontalAlign.Center
        pheader2.Controls.Add(pheadercell2)
        lo_leavetable.Controls.Add(pheader2)



        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        line1.Width = 10
        linecell1.ColumnSpan = 10
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        lo_leavetable.Controls.Add(line1)

        Dim colors As String
        colors = "#fff7ff"


        Dim field As New TableRow
        field.Width = 10
        field.Attributes.Add("bgcolor", colors)
        Dim f1, f2, f3, fll, f4, f5, f6, f7, f8, f9, f10 As New TableCell

        'f1.ColumnSpan = 1
        'f1.HorizontalAlign = HorizontalAlign.Center
        'f1.Text = "<b><font size=2>Si No</font></b>"
        'field.Controls.Add(f1)

        f2.ColumnSpan = 1
        f2.HorizontalAlign = HorizontalAlign.Center
        f2.Text = "<b><font size=2>Emp&nbsp;Code</font></b>"
        field.Controls.Add(f2)

        f3.ColumnSpan = 1
        f3.HorizontalAlign = HorizontalAlign.Center
        f3.Text = "<b><font size=2>Emp&nbsp;Name</font></b>"
        field.Controls.Add(f3)

        fll.ColumnSpan = 6
        fll.HorizontalAlign = HorizontalAlign.Center
        fll.Text = "<b><font size=2>Dept/Branch Name</font></b>"
        field.Controls.Add(fll)

        f4.ColumnSpan = 2
        f4.HorizontalAlign = HorizontalAlign.Center
        f4.Text = "<b><font size=2>Total Leave</font></b>"
        field.Controls.Add(f4)

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

        lo_leavetable.Controls.Add(field)

        Dim linek As New TableRow
        Dim linecellk As New TableCell
        linek.Width = 10
        linecellk.ColumnSpan = 10
        linecellk.Text = "<hr>"
        linek.Controls.Add(linecellk)
        lo_leavetable.Controls.Add(linek)

        If Me.Request.QueryString("status") = 0 Then
            '                  0           1           2                   3                                     4                                  5                                              6                     

            ' str1 = "select em.emp_code,em.emp_name,bd.BRANCH_NAME,dm.dep_name,sum(el.leave_days) as Total_Leave from employee_master em,employ_leave_dtl el ,branch_detail bd,department_mst dm where em.branch_id=bd.branch_id and em.emp_code=el.emp_code and em.department_id=dm.dep_id and  to_date(el.leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and el.leave_process_id in (1,2) and em.status_id not in (3,5) group by em.branch_id,em.emp_code,em.emp_name,dm.dep_name,bd.branch_name having   sum(el.leave_days)>=10 order by em.emp_code"
            If Me.Request.QueryString("designation") <> 0 Then

                str1 = "select em.emp_code,em.emp_name,bd.BRANCH_NAME,dm.dep_name,sum(el.leave_days) as Total_Leave from employee_master em,employ_leave_dtl el ,branch_detail bd,department_mst dm,employ_firm f where em.branch_id=bd.branch_id and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=el.emp_code and em.department_id=dm.dep_id and em.designation_id=" & Me.Request.QueryString("designation") & " and  to_date(el.leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and el.leave_process_id in (1,2) and em.status_id not in (3,5) and bd.branch_id=" & Me.Request.QueryString("branchid") & " group by em.branch_id,em.emp_code,em.emp_name,dm.dep_name,bd.branch_name having sum(el.leave_days)>=" & Me.Request.QueryString("leaveno") & " order by em.emp_code"

            ElseIf Me.Request.QueryString("post") <> 0 Then

                str1 = "select em.emp_code,em.emp_name,bd.BRANCH_NAME,dm.dep_name,sum(el.leave_days) as Total_Leave from employee_master em,employ_leave_dtl el ,branch_detail bd,department_mst dm,employ_firm f where em.branch_id=bd.branch_id and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=el.emp_code and em.department_id=dm.dep_id and em.post_id=" & Me.Request.QueryString("post") & " and  to_date(el.leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and el.leave_process_id in (1,2) and em.status_id not in (3,5) and bd.branch_id=" & Me.Request.QueryString("branchid") & " group by em.branch_id,em.emp_code,em.emp_name,dm.dep_name,bd.branch_name having sum(el.leave_days)>=" & Me.Request.QueryString("leaveno") & " order by em.emp_code"

            Else
                str1 = "select em.emp_code,em.emp_name,bd.BRANCH_NAME,dm.dep_name,sum(el.leave_days) as Total_Leave from employee_master em,employ_leave_dtl el ,branch_detail bd,department_mst dm,employ_firm f where em.branch_id=bd.branch_id and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=el.emp_code and em.department_id=dm.dep_id and  to_date(el.leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and el.leave_process_id in (1,2) and em.status_id not in (3,5) and bd.branch_id=" & Me.Request.QueryString("branchid") & " group by em.branch_id,em.emp_code,em.emp_name,dm.dep_name,bd.branch_name having sum(el.leave_days)>=" & Me.Request.QueryString("leaveno") & " order by em.emp_code"

            End If

        ElseIf Me.Request.QueryString("status") = 1 Then

            'str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then el.leave_days else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then el.leave_days else 0 end )as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then el.leave_days else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then el.leave_days else 0 end) as Lop from employee_master_dtl ed,employ_promotion_dtl ep, employee_master em left outer join employ_leave_dtl el on(em.emp_code=el.emp_code) where em.emp_code=ed.emp_code and em.emp_code=ep.emp_code  and ed.discont_dt>=to_date('" & Request.QueryString("Date_From") & "') and ed.discont_dt<=to_date('" & Request.QueryString("Date_To") & "') and ep.from_dt=ed.discont_dt and ep.to_dt is null and ep.status_id=4 and em.emp_type=1 and ep.status_id =em.status_id and em.emp_code>=" & Me.Request.QueryString("Emp_from") & " and em.emp_code<=" & Me.Request.QueryString("Emp_to") & " group by em.emp_code,em.emp_name,ed.discont_dt"
            'str1 = "select em.emp_code,em.emp_name,decode(em.branch_id,0,dm.dep_name,bm.branch_name),sum(el.leave_days) as Total_Leave from employee_master em left outer join employ_leave_dtl el on(em.emp_code=el.emp_code),branch_master bm,department_mst dm where em.branch_id=bm.branch_id and em.department_id=dm.dep_id and  to_date(el.leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and el.leave_process_id in (1,2) and em.status_id not in (3,5) and em.emp_type=1 group by em.branch_id,em.emp_code,em.emp_name,dm.dep_name,bm.branch_name having   sum(el.leave_days)>=" & Me.Request.QueryString("leaveno") & " order by em.emp_code"
            If Me.Request.QueryString("designation") <> 0 Then

                str1 = "select em.emp_code,em.emp_name,bd.BRANCH_NAME,dm.dep_name,sum(el.leave_days) as Total_Leave from employee_master em,employ_leave_dtl el ,branch_detail bd,department_mst dm,employ_firm f where em.branch_id=bd.branch_id and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=el.emp_code and em.department_id=dm.dep_id and em.designation_id=" & Me.Request.QueryString("designation") & " and  to_date(el.leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and el.leave_process_id in (1,2) and em.status_id not in (3,5) and em.emp_type=1 and bd.branch_id=" & Me.Request.QueryString("branchid") & " group by em.branch_id,em.emp_code,em.emp_name,dm.dep_name,bd.branch_name having sum(el.leave_days)>=" & Me.Request.QueryString("leaveno") & " order by em.emp_code"

            ElseIf Me.Request.QueryString("post") <> 0 Then

                str1 = "select em.emp_code,em.emp_name,bd.BRANCH_NAME,dm.dep_name,sum(el.leave_days) as Total_Leave from employee_master em,employ_leave_dtl el ,branch_detail bd,department_mst dm,employ_firm f where em.branch_id=bd.branch_id and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=el.emp_code and em.department_id=dm.dep_id and em.post_id=" & Me.Request.QueryString("post") & " and  to_date(el.leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and el.leave_process_id in (1,2) and em.status_id not in (3,5) and em.emp_type=1 and bd.branch_id=" & Me.Request.QueryString("branchid") & " group by em.branch_id,em.emp_code,em.emp_name,dm.dep_name,bd.branch_name having sum(el.leave_days)>=" & Me.Request.QueryString("leaveno") & " order by em.emp_code"

            Else
                str1 = "select em.emp_code,em.emp_name,bd.BRANCH_NAME,dm.dep_name,sum(el.leave_days) as Total_Leave from employee_master em,employ_leave_dtl el ,branch_detail bd,department_mst dm,employ_firm f where em.branch_id=bd.branch_id and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=el.emp_code and em.department_id=dm.dep_id and  to_date(el.leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and el.leave_process_id in (1,2) and em.status_id not in (3,5) and em.emp_type=1 and bd.branch_id=" & Me.Request.QueryString("branchid") & " group by em.branch_id,em.emp_code,em.emp_name,dm.dep_name,bd.branch_name having sum(el.leave_days)>=" & Me.Request.QueryString("leaveno") & " order by em.emp_code"

            End If

        ElseIf Me.Request.QueryString("status") = 2 Then

            'str1 = "select em.emp_code,em.emp_name,decode(em.branch_id,0,dm.dep_name,bm.branch_name),sum(el.leave_days) as Total_Leave from employee_master em left outer join employ_leave_dtl el on(em.emp_code=el.emp_code),branch_master bm,department_mst dm where em.branch_id=bm.branch_id and em.department_id=dm.dep_id and  to_date(el.leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and el.leave_process_id in (1,2) and em.status_id not in (3,5) and em.emp_type=2 group by em.branch_id,em.emp_code,em.emp_name,dm.dep_name,bm.branch_name having   sum(el.leave_days)>=" & Me.Request.QueryString("leaveno") & " order by em.emp_code"
            'str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then el.leave_days else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then el.leave_days else 0 end )as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then el.leave_days else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then el.leave_days else 0 end) as Lop from employee_master_dtl ed,employ_promotion_dtl ep, employee_master em left outer join employ_leave_dtl el on(em.emp_code=el.emp_code) where em.emp_code=ed.emp_code and em.emp_code=ep.emp_code  and ed.discont_dt>=to_date('" & Request.QueryString("Date_From") & "') and ed.discont_dt<=to_date('" & Request.QueryString("Date_To") & "') and ep.from_dt=ed.discont_dt and ep.to_dt is null and ep.status_id=4 and em.emp_type=2 and ep.status_id =em.status_id and em.emp_code>=" & Me.Request.QueryString("Emp_from") & " and em.emp_code<=" & Me.Request.QueryString("Emp_to") & " group by em.emp_code,em.emp_name,ed.discont_dt"
            If Me.Request.QueryString("designation") <> 0 Then

                str1 = "select em.emp_code,em.emp_name,bd.BRANCH_NAME,dm.dep_name,sum(el.leave_days) as Total_Leave from employee_master em,employ_leave_dtl el ,branch_detail bd,department_mst dm,employ_firm f where em.branch_id=bd.branch_id and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=el.emp_code and em.department_id=dm.dep_id and em.designation_id=" & Me.Request.QueryString("designation") & " and  to_date(el.leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and el.leave_process_id in (1,2) and em.status_id not in (3,5) and em.emp_type=2 and bd.branch_id=" & Me.Request.QueryString("branchid") & " group by em.branch_id,em.emp_code,em.emp_name,dm.dep_name,bd.branch_name having sum(el.leave_days)>=" & Me.Request.QueryString("leaveno") & " order by em.emp_code"

            ElseIf Me.Request.QueryString("post") <> 0 Then

                str1 = "select em.emp_code,em.emp_name,bd.BRANCH_NAME,dm.dep_name,sum(el.leave_days) as Total_Leave from employee_master em,employ_leave_dtl el ,branch_detail bd,department_mst dm,employ_firm f where em.branch_id=bd.branch_id and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=el.emp_code and em.department_id=dm.dep_id and em.post_id=" & Me.Request.QueryString("post") & " and  to_date(el.leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and el.leave_process_id in (1,2) and em.status_id not in (3,5) and em.emp_type=2 and bd.branch_id=" & Me.Request.QueryString("branchid") & " group by em.branch_id,em.emp_code,em.emp_name,dm.dep_name,bd.branch_name having sum(el.leave_days)>=" & Me.Request.QueryString("leaveno") & " order by em.emp_code"

            Else
                str1 = "select em.emp_code,em.emp_name,bd.BRANCH_NAME,dm.dep_name,sum(el.leave_days) as Total_Leave from employee_master em,employ_leave_dtl el ,branch_detail bd,department_mst dm,employ_firm f where em.branch_id=bd.branch_id and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=el.emp_code and em.department_id=dm.dep_id and  to_date(el.leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and el.leave_process_id in (1,2) and em.status_id not in (3,5) and em.emp_type=2 and bd.branch_id=" & Me.Request.QueryString("branchid") & " group by em.branch_id,em.emp_code,em.emp_name,dm.dep_name,bd.branch_name having sum(el.leave_days)>=" & Me.Request.QueryString("leaveno") & " order by em.emp_code"

            End If
        End If


        dt = oh.ExecuteDataSet(str1).Tables(0)



        If dt.Rows.Count = 0 Then
            Dim line1d As New TableRow
            Dim linecell1d As New TableCell
            line1d.Width = 10
            linecell1d.ColumnSpan = 10
            linecell1d.Text = "<b> No Employees Found !! Or Check whether You entered Correct information!!"
            line1d.Controls.Add(linecell1d)
            lo_leavetable.Controls.Add(line1d)
        Else

            For Each dr In dt.Rows

                i += 1

                If colors.Equals("#fff7ff") = True Then
                    colors = "#eef9ff"
                Else
                    colors = "#fff7ff"
                End If

                Dim value As New TableRow
                value.Width = 10
                Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11 As New TableCell
                value.Attributes.Add("bgcolor", colors)

                '//SI no
                'v1.ColumnSpan = 1
                'v1.HorizontalAlign = HorizontalAlign.Center
                'v1.Text = "<font size=2>" & i & "</font>"
                'value.Controls.Add(v1)

                '//E_Code
                v2.ColumnSpan = 1
                v2.HorizontalAlign = HorizontalAlign.Left
                v2.Text = "<a href=detailed_leave_above9_report.aspx?emp_code=" & dr(0) & "&leaveno=" & Me.Request.QueryString("leaveno") & "><font size=2>" & dr(0) & "</font></a>"
                value.Controls.Add(v2)

                '///E_Name
                v3.ColumnSpan = 1
                v3.HorizontalAlign = HorizontalAlign.Left
                v3.Text = "<font size=2>" & dr(1) & "</font>"
                value.Controls.Add(v3)

                '///Dept/Branch_name
                v4.ColumnSpan = 6
                v4.HorizontalAlign = HorizontalAlign.Left
                v4.Text = "<font size=2>" & dr(3) & "</font>"
                value.Controls.Add(v4)

                '///Total_Leave
                v5.ColumnSpan = 2
                v5.HorizontalAlign = HorizontalAlign.Center
                v5.Text = "<font size=2>" & dr(4) & "</font>"
                value.Controls.Add(v5)
                ' d1.Text = "<a href=subreport.aspx?emp_code=" & dr(0) & "><font size=2>" & dr(0) & "***" & dr(1) & "</font></a>"
                '//S/L
                'v6.ColumnSpan = 1
                'v6.HorizontalAlign = HorizontalAlign.Left
                'v6.Text = "<font size=2>" & dr(4) & "</font>"
                'value.Controls.Add(v6)

                '///Earned Leave
                'v7.ColumnSpan = 1
                'v7.HorizontalAlign = HorizontalAlign.Left
                'v7.Text = "<font size=2>" & dr(5) & "</font>"
                'value.Controls.Add(v7)

                '///////LOP
                'v8.ColumnSpan = 1
                'v8.HorizontalAlign = HorizontalAlign.Left
                'v8.Text = "<font size=2>" & dr(6) & "</font>"
                'value.Controls.Add(v8)

                '///////Leave_Fro_date
                'v9.ColumnSpan = 1
                'v9.HorizontalAlign = HorizontalAlign.Left
                'v9.Text = " "
                'value.Controls.Add(v9)

                '///////Leave_TO_date
                'v10.ColumnSpan = 1
                'v10.HorizontalAlign = HorizontalAlign.Left
                'v10.Text = " "
                'value.Controls.Add(v10)

                '///////Reason'////////
                'v11.ColumnSpan = 1
                'v11.HorizontalAlign = HorizontalAlign.Left
                'v11.Text = " "
                'value.Controls.Add(v11)

                lo_leavetable.Controls.Add(value)

                'str2 = "select el.leave_frdate,el.leave_todate,el.leave_reason from employ_leave_dtl el where el.leave_id = 4 and el.leave_process_id = 1 And el.emp_code =" & dr(0) & ""




            Next
            Dim bline As New TableRow
            bline.Width = 10
            Dim bline1 As New TableCell
            bline1.ColumnSpan = 10
            bline1.Text = "<hr>"
            bline.Controls.Add(bline1)

            lo_leavetable.Controls.Add(bline)

            Dim tline23 As New TableRow
            tline23.Width = 10
            Dim tcellline233 As New TableCell
            tcellline233.ColumnSpan = 10
            tcellline233.HorizontalAlign = HorizontalAlign.Left
            tcellline233.Text = "<b><font size=2>Total:" & i & "&nbsp;Employees</font></b>"
            tline23.Controls.Add(tcellline233)

            lo_leavetable.Controls.Add(tline23)


        End If

        Pan_Sal_Long_Leave.Controls.Add(lo_leavetable)
    End Sub

End Class
