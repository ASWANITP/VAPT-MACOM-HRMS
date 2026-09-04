Imports System.Data
Imports system.Data.oracleclient
Partial Class New_Staff_Norms_branch_employee_290510e07955
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim dr1 As DataRow
    Dim str As String
    Dim i As Integer = 0
    Dim tot As Integer = 0
    Dim emplivetable As New Table

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  Dim bid As Integer = Me.Request.QueryString("brid")
        Dim bid As Integer = Me.Session("branch_id")
       
        'str = "select em.emp_code,em.emp_name,upper(dm.designation),upper(dp.dep_name),pm.post_name from employee_master em left outer join designation_master dm on(em.designation_id=dm.designation_id) left outer join department_mst dp on (em.department_id=dp.dep_id) left outer join post_mst pm on(em.post_id=pm.post_id) where em.emp_code in(select emp_code from employee_involve) and em.department_id<>154 and em.status_id=1 and em.branch_id=" & Me.Request.QueryString("brid") & " and em.emp_code>9999 and em.shift_id not in(4,5)order by dep_name,post_name,emp_code"
        '             ---0-----   ---1-----   --------2---------    ------3--------    -----4----   ----5---------------------     -----6-----------------     -------7----------------     -----8---------------------
        'str = "select em.emp_code,em.emp_name,upper(dm.designation),upper(dp.dep_name),pm.post_name,et.from_dt as Branch_join_date,em1.EMP_CODE as Old_Emp_Code,em1.JOIN_DT as Old_Join_Date,em.JOIN_DT as Regularise_date from employ_transfer_dtl et,employee_master em left outer join designation_master dm on(em.designation_id=dm.designation_id) left outer join department_mst dp on (em.department_id=dp.dep_id) left outer join post_mst pm on(em.post_id=pm.post_id) left outer join employee_master_dtl ed on (em.EMP_CODE = nvl(ed.new_empcode,0)) left outer join employee_master em1 on (nvl(ed.emp_code,0) = em1.EMP_CODE) where em.EMP_CODE = et.emp_code and em.status_id = 1 and em.branch_id = 29 and et.branch_id = em.BRANCH_ID and et.status_id = 8 and (et.to_dt is null or to_date(et.to_dt) > to_date(sysdate)) order by dep_name,post_name,emp_code"
        ' adding firm in staffnorms
        '================================
        'str = "select em.emp_code,em.emp_name,upper(dm.designation),upper(dp.dep_name),upper(fp.firm_name),pm.post_name,et.from_dt as Branch_join_date,em1.EMP_CODE as Old_Emp_Code,em1.JOIN_DT as Old_Join_Date,em.JOIN_DT as Regularise_date from employ_transfer_dtl et,employee_master em left outer join designation_master dm on(em.designation_id=dm.designation_id) left outer join department_mst dp on (em.department_id=dp.dep_id) left outer join firm_master fp on (em.firm_id=fp.firm_id) left outer join post_mst pm on(em.post_id=pm.post_id) left outer join employee_master_dtl ed on (em.EMP_CODE = nvl(ed.new_empcode,0)) left outer join employee_master em1 on (nvl(ed.emp_code,0) = em1.EMP_CODE) where em.EMP_CODE = et.emp_code and em.status_id = 1 and em.branch_id = " & Session("branch_id") & " and et.branch_id = em.BRANCH_ID and et.status_id = 8 and (et.to_dt is null or to_date(et.to_dt) > to_date(sysdate)) order by firm_name,dep_name,post_name,emp_code"
        str = "select em.emp_code,em.emp_name,upper(dm.designation),upper(dp.dep_name),upper(fp.firm_name),pm.post_name,et.from_dt as Branch_join_date,em1.EMP_CODE as Old_Emp_Code,em1.JOIN_DT as Old_Join_Date,em.JOIN_DT as Regularise_date from employ_transfer_dtl et,employee_master em left outer join designation_master dm on(em.designation_id=dm.designation_id) left outer join department_mst dp on (em.department_id=dp.dep_id) left outer join post_mst pm on (em.post_id = pm.post_id) left outer join employee_master_dtl ed on (em.EMP_CODE = nvl(ed.new_empcode, 0)) left outer join employee_master em1 on (nvl(ed.emp_code, 0) = em1.EMP_CODE),employ_firm ef left outer join firm_master fp on (ef.firm_id = fp.firm_id) where ef.emp_code = em.emp_code and em.EMP_CODE = et.emp_code and em.status_id = 1 and em.branch_id =" & Session("branch_id") & " and et.branch_id = em.BRANCH_ID and et.status_id = 8 and (et.to_dt is null or to_date(et.to_dt) > to_date(sysdate)) order by firm_name,dep_name,post_name,emp_code"
        '================================
        dt = oh.ExecuteDataSet(str).Tables(0)
        If dt.Rows.Count > 0 Then

            Dim header As New TableRow
            header.Width = 8
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            Dim headercell As New TableCell
            headercell.ColumnSpan = 8
            headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
            headercell.HorizontalAlign = HorizontalAlign.Center
            header.Controls.Add(headercell)
            emplivetable.Controls.Add(header)

            Dim sheader As New TableRow
            sheader.BackColor = Drawing.Color.LightGray
            Dim sheadercell1 As New TableCell
            Dim sheadercell2 As New TableCell
            sheadercell1.ColumnSpan = 8
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<font size=2 ><b>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "&nbsp;</b>(Login Branch)</font>"
            sheader.Controls.Add(sheadercell1)
            emplivetable.Controls.Add(sheader)

            '  Dim bname As String = oh.ExecuteDataSet("select branch_name||'*'||to_char(inauguration_dt,'dd-Mon-yyyy')||'*'||nvl(c.total_amt,0)/100000 from branch_master b,staff_norms_month_balance c where b.branch_id = c.branch_id and b.branch_id=" & Me.Request.QueryString("brid")).Tables(0).Rows(0)(0)
            Dim bname As String = oh.ExecuteDataSet("select branch_name||'*'||to_char(inauguration_dt,'dd-Mon-yyyy')||'*'||nvl(c.total_amt,0)/100000 from branch_master b,staff_norms_month_balance c where b.branch_id = c.branch_id and b.branch_id=" & Me.Session("branch_id")).Tables(0).Rows(0)(0)
            Dim ball() As String = bname.Split("*")
            Dim outamt As Double = ball(2)
            Dim tt As New TableRow
            tt.BackColor = Drawing.Color.LightSkyBlue
            tt.Width = 8
            Dim tt1 As New TableCell
            tt1.ColumnSpan = 8
            tt1.HorizontalAlign = HorizontalAlign.Center
            tt1.Text = "<b><font size=2>List Of Employees Now Working in&nbsp;&nbsp;" & ball(0) & "&nbsp;Branch</font></b>"
            tt.Controls.Add(tt1)
            emplivetable.Controls.Add(tt)


            Dim subh As New TableRow
            Dim subcell1 As New TableCell
            Dim subcell2 As New TableCell
            Dim subcell3 As New TableCell
            subh.Width = 8

            subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd-MMM-yyyy") & "</font></b>"
            subcell1.ColumnSpan = 2
            subcell1.HorizontalAlign = HorizontalAlign.Left
            subh.Controls.Add(subcell1)


            subcell2.ColumnSpan = 4
            subcell2.HorizontalAlign = HorizontalAlign.Center
            subcell2.Text = "<font size=2>Branch ID=<b>" & Me.Session("branch_id") & "</b>&nbsp;,&nbsp;Inag.Date&nbsp;:&nbsp;<b>" & ball(1) & "</b><font>"
            subh.Controls.Add(subcell2)

            subcell3.ColumnSpan = 2
            subcell3.HorizontalAlign = HorizontalAlign.Left
            subcell3.Text = "<b><font size=2>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
            subcell3.HorizontalAlign = HorizontalAlign.Right
            subh.Controls.Add(subcell3)
            emplivetable.Controls.Add(subh)

            Dim line As New TableRow
            Dim linecell As New TableCell
            linecell.ColumnSpan = 8
            linecell.Text = "<hr>"
            line.Controls.Add(linecell)
            emplivetable.Controls.Add(line)

            Dim row2 As New TableRow
            row2.Width = 8
            Dim r1, r2, ra, r3, re, r4, r5, r8 As New TableCell

            r1.ColumnSpan = 1
            r1.HorizontalAlign = HorizontalAlign.Left
            r1.Text = "<b><font size=2>Employee&nbsp;Code&nbsp;</font></b>"
            row2.Controls.Add(r1)

            r2.ColumnSpan = 1
            r2.HorizontalAlign = HorizontalAlign.Left
            r2.Text = "<b><font size=2>Employee&nbsp;Name&nbsp;</font></b>"
            row2.Controls.Add(r2)

            ra.ColumnSpan = 1
            ra.HorizontalAlign = HorizontalAlign.Left
            ra.Text = "<b><font size=2>Designation&nbsp;</font></b>"
            row2.Controls.Add(ra)

            r5.ColumnSpan = 1
            r5.HorizontalAlign = HorizontalAlign.Left
            r5.Text = "<b><font size=2>Post&nbsp;</font></b>"
            row2.Controls.Add(r5)

            re.ColumnSpan = 1
            re.HorizontalAlign = HorizontalAlign.Center
            re.Text = "<b><font size=2>Posted to&nbsp;this&nbsp;Branch&nbsp;</font></b>"
            row2.Controls.Add(re)

            r3.ColumnSpan = 1
            r3.HorizontalAlign = HorizontalAlign.Left
            r3.Text = "<b><font size=2>Old&nbsp;EmpCode&nbsp;</font></b>"
            row2.Controls.Add(r3)

            r4.ColumnSpan = 1
            r4.HorizontalAlign = HorizontalAlign.Left
            r4.Text = "<b><font size=2>Old&nbsp;JoinDate&nbsp;</font></b>"
            row2.Controls.Add(r4)

            r8.ColumnSpan = 1
            r8.HorizontalAlign = HorizontalAlign.Left
            r8.Text = "<b><font size=2>Reg./Join&nbsp;Date</font></b>"
            row2.Controls.Add(r8)

            emplivetable.Controls.Add(row2)

            Dim lineu As New TableRow
            Dim linecellu As New TableCell
            linecellu.ColumnSpan = 8
            linecellu.Text = "<hr>"
            lineu.Controls.Add(linecellu)
            emplivetable.Controls.Add(lineu)

            Dim depname As String = ""
            Dim firmname As String = ""

             
            For Each dr In dt.Rows
                i += 1

                'adding firm in staffnorms
                '============================

                If firmname <> dr(4).ToString Then

                    Dim deprow1 As New TableRow
                    deprow1.Width = 8
                    Dim deprowcel2 As New TableCell
                    deprowcel2.ColumnSpan = 8
                    deprowcel2.HorizontalAlign = HorizontalAlign.Left
                    deprowcel2.BackColor = Drawing.Color.SkyBlue
                    deprowcel2.Text = "<font size=3><b>Firm:" & dr(4) & "</b></font>"
                    deprow1.Controls.Add(deprowcel2)
                    emplivetable.Controls.Add(deprow1)

                    firmname = dr(4).ToString
                End If
                '=============================

                If depname <> dr(3).ToString Then

                    Dim deprow As New TableRow
                    deprow.Width = 8
                    Dim deprowcell As New TableCell
                    deprowcell.ColumnSpan = 8
                    deprowcell.HorizontalAlign = HorizontalAlign.Left
                    deprowcell.BackColor = Drawing.Color.Cornsilk
                    deprowcell.Text = "<font size=3><b>Department:&nbsp;" & dr(3).ToString & "</b></font>"
                    '  deprowcell.Text = "<font size=3><b>Firm:&nbsp;" & dr(4).ToString & "</b></font>"
                    deprow.Controls.Add(deprowcell)
                    emplivetable.Controls.Add(deprow)

                End If
                depname = dr(3).ToString


                Dim value As New TableRow
                value.Width = 8
                Dim v1, v2, v3, va, v4, v5, v6, v8 As New TableCell



                v1.ColumnSpan = 1        'Empcode
                v1.HorizontalAlign = HorizontalAlign.Left
                v1.Text = "<font size=2><b>" & dr(0) & "&nbsp;</b></font>"
                value.Controls.Add(v1)

                v2.ColumnSpan = 1       'EmpName
                v2.HorizontalAlign = HorizontalAlign.Left
                v2.Text = "<font size=2>" & dr(1) & "&nbsp;</font>"
                value.Controls.Add(v2)


                v4.ColumnSpan = 1  'Designation
                v4.HorizontalAlign = HorizontalAlign.Left
                If IsDBNull(dr(2)) Then
                    v4.Text = "<font size=2>----&nbsp;</font>"
                Else
                    v4.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
                End If
                value.Controls.Add(v4)

                v6.ColumnSpan = 1  'post
                v6.HorizontalAlign = HorizontalAlign.Left
                If IsDBNull(dr(5)) Then
                    v6.Text = "<font size=2>----&nbsp;</font>"
                Else
                    v6.Text = "<font size=2>" & dr(5) & "&nbsp;</font>"
                End If
                value.Controls.Add(v6)

                v3.ColumnSpan = 1    'Branch Join Date
                v3.HorizontalAlign = HorizontalAlign.Center
                If IsDBNull(dr(6)) Then
                    v3.Text = "<font size=2>&nbsp;---&nbsp;</font>"
                Else
                    v3.Text = "<font size=2>" & Format(dr(6), "dd-MMM-yyyy") & "&nbsp;</font>"
                End If
                value.Controls.Add(v3)

                va.ColumnSpan = 1    'Old EmpCode
                va.HorizontalAlign = HorizontalAlign.Center
                If IsDBNull(dr(7)) Or dr(7) = 0 Then
                    va.Text = "<font size=2>&nbsp;---&nbsp;</font>"
                Else
                    va.Text = "<font size=2>" & dr(7) & "&nbsp;</font>"
                End If
                value.Controls.Add(va)

                v5.ColumnSpan = 1   'Old Join Date
                v5.HorizontalAlign = HorizontalAlign.Left
                If IsDBNull(dr(8)) Then
                    v5.Text = "<font size=2>&nbsp;---&nbsp;</font>"
                Else
                    v5.Text = "<font size=2>" & Format(dr(8), "dd-MMM-yyyy") & "&nbsp;</font>"
                End If
                value.Controls.Add(v5)

                v8.ColumnSpan = 1       'Regu/Join Date
                v8.HorizontalAlign = HorizontalAlign.Left
                If IsDBNull(dr(9)) Then
                    v8.Text = "<font size=2>&nbsp;---&nbsp;</font>"
                Else
                    v8.Text = "<font size=2>" & Format(dr(9), "dd-MMM-yyyy") & "&nbsp;</font>"
                End If
                value.Controls.Add(v8)
                emplivetable.Controls.Add(value)
            Next

            Dim line4 As New TableRow
            Dim linecell4 As New TableCell
            linecell4.ColumnSpan = 8
            linecell4.Text = "<hr>"
            line4.Controls.Add(linecell4)
            emplivetable.Controls.Add(line4)


            Dim qlast As New TableRow
            qlast.Width = 8
            Dim q As New TableCell
            q.ColumnSpan = 8
            q.HorizontalAlign = HorizontalAlign.Left
            q.Text = "<font size=3>Total:&nbsp;<b>" & Me.i & "</b>&nbsp;Employee(s)<font>"
            qlast.Controls.Add(q)
            emplivetable.Controls.Add(qlast)

            'Dim outamt As Double = oh.ExecuteDataSet("select nvl(total_amt,0)/100000 from staff_norms_month_balance where branch_id=" & Me.Request.QueryString("brid") & "").Tables(0).Rows(0)(0)

            Dim qqlast As New TableRow
            qqlast.Width = 8
            Dim qq As New TableCell
            qq.ColumnSpan = 8
            qq.HorizontalAlign = HorizontalAlign.Left
            qq.Text = "<font size=3>Total&nbsp;Outstanding&nbsp;of&nbsp;this&nbsp;Branch:&nbsp;<b>" & FormatNumber(outamt, 2) & "</b>&nbsp;&nbsp;Lakhs..<font>"
            qqlast.Controls.Add(qq)
            emplivetable.Controls.Add(qqlast)

        Else

            Dim warn As New TableRow
            warn.Width = 8
            Dim w1 As New TableCell
            w1.ColumnSpan = 8
            w1.HorizontalAlign = HorizontalAlign.Center
            w1.Text = "<b><font size=3> No Data..!!</font></b>"
            warn.Controls.Add(w1)
            emplivetable.Controls.Add(warn)

        End If

        Panel_EmpLive.Controls.Add(emplivetable)
    End Sub

End Class
