Imports System.Data
Imports System.Data.OracleClient
Partial Class Salary_Individ_Ho_statement_sal_indivi_HO_all_report_5cdbde592029
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim str, str1 As String
    Dim dr, dr1 As DataRow
    Dim oh As New Helper.Oracle.OracleHelper
    '----------------KRISHNADAS FOR MAFARM JUNE-22
    Dim type As Integer = 0
    Dim firm As Integer = 0
    Dim branch_from As Integer = 0
    Dim branch_to As Integer = 0
    Dim saldate As Date
    Dim salarytable As New Table

    Dim basic As Double = 0
    Dim vda As Double = 0
    Dim arrsal As Double = 0
    Dim wagespayable As Double = 0
    Dim esi As Double = 0
    Dim pf As Double = 0
    Dim swf As Double = 0
    Dim lwf As Double = 0
    Dim lic As Double = 0
    Dim tds As Double = 0
    Dim othded As Double = 0
    Dim rdded As Double = 0
    Dim proftax As Double = 0
    Dim totalded As Double = 0
    Dim bonus As Double = 0
    Dim wagespaid As Double = 0
    Dim reccount As Double = 0
    Dim pagenonext As Double = 1
    Dim sino As Integer = 0
    Dim emptype As Integer = 0
    Dim date_str, first_dat, first_datt As String
    Dim color As Integer = 0
    Dim ta_total As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        emptype = Me.Request.QueryString("emptype")
        date_str = Me.Request.QueryString("date_in")
        Dim mon As String
        Dim dt As New DataTable


        first_datt = oh.ExecuteDataSet("select to_date('01-'||to_char( to_date('" & date_str & "','mm-dd-yyyy'),'MM-YYYY') ,'mm-dd-yyyy')from dual").Tables(0).Rows(0)(0)
        first_dat = oh.ExecuteDataSet("select to_date(to_char(to_date('" & date_str & "', 'mm-dd-yyyy'), 'mm') || '-01-' || to_char(to_date('" & date_str & "', 'mm-dd-yyyy'), 'YYYY'),'mm-dd-yyyy') from dual").Tables(0).Rows(0)(0)

        dt = oh.ExecuteDataSet("select distinct to_date(t.sal_dt) from m_wage t").Tables(0)
        If dt.Rows.Count > 0 Then
            mon = CStr(dt.Rows(0)(0))
        Else
            mon = ""
        End If

        If emptype = 1 And date_str = mon Then     '                   0         1        2              3                4                                           5                                                                     6                              7                                                                    8                       9              10               11                12                13               14           15              16                             17                                       18                               19                           20            21           22           23                           24                    25       26                     
            str = "select mw.emp_code,       mw.name,       mw.fat_hus,       nvl(mw.basic_pay, 0),       nvl(mw.vda, 0),       (nvl(mw.ovt_wages, 0) + nvl(mw.arrear_sal, 0) + nvl(mw.arrear_da, 0) +       nvl(mw.oth_add, 0)) as Arrear_salary,       nvl(mw.wages_pble, 0),       (nvl(mw.w_days, 0) - nvl(mw.l_days, 0)) as Total_attendance,       (nvl(mw.lop, 0) + nvl(mw.oth_ded, 0)) as oth_deduction,       nvl(mw.p_fund, 0),       nvl(mw.esi, 0),       nvl(mw.s_w_fund, 0),       nvl(mw.l_w_fund, 0),       nvl(mw.p_tax, 0),       nvl(mw.lic, 0),       nvl(mw.tds, 0),       nvl(mw.rdded_amt, 0),       (nvl(mw.tot_dedu, 0) + nvl(mw.lop, 0)) as total_deduction,       nvl(mw.bonus, 0),       (nvl(mw.net_pay, 0) + nvl(mw.bonus, 0)) as WAGES_PAID,       mw.sal_dt,       dm.designation,       fm.firm_abbr,       bm.branch_name as branchname,       bm.branch_id as brid,       em.emp_type,       mw.status_id,       mw.ta_total,       (nvl(mw.net_pay, 0) + nvl(mw.bonus, 0) + nvl(mw.ta_total, 0)) -       nvl(mw.cutting, 0) as PAID_AMNT  from m_wage mw  join employee_master em on mw.emp_code = em.emp_code  and em.emp_type in(1)  join employ_firm ef on ef.emp_code = mw.emp_code   and ef.firm_id in ('" & Session("firm_id") & "')   join branch_master bm on em.branch_id = bm.branch_id   join designation_master dm on dm.designation_id = em.designation_id   join firm_master fm on ef.firm_id = fm.firm_id  order by branchname, firm_abbr, emp_code"
        ElseIf emptype = 2 And date_str = mon Then
            str = "select mw.emp_code,       mw.name,       mw.fat_hus,       nvl(mw.basic_pay, 0),       nvl(mw.vda, 0),       (nvl(mw.ovt_wages, 0) + nvl(mw.arrear_sal, 0) + nvl(mw.arrear_da, 0) +       nvl(mw.oth_add, 0)) as Arrear_salary,       nvl(mw.wages_pble, 0),       (nvl(mw.w_days, 0) - nvl(mw.l_days, 0)) as Total_attendance,       (nvl(mw.lop, 0) + nvl(mw.oth_ded, 0)) as oth_deduction,       nvl(mw.p_fund, 0),       nvl(mw.esi, 0),       nvl(mw.s_w_fund, 0),       nvl(mw.l_w_fund, 0),       nvl(mw.p_tax, 0),       nvl(mw.lic, 0),       nvl(mw.tds, 0),       nvl(mw.rdded_amt, 0),       (nvl(mw.tot_dedu, 0) + nvl(mw.lop, 0)) as total_deduction,       nvl(mw.bonus, 0),       (nvl(mw.net_pay, 0) + nvl(mw.bonus, 0)) as WAGES_PAID,       mw.sal_dt,       dm.designation,       fm.firm_abbr,       bm.branch_name as branchname,       bm.branch_id as brid,       em.emp_type,       mw.status_id,       mw.ta_total,       (nvl(mw.net_pay, 0) + nvl(mw.bonus, 0) + nvl(mw.ta_total, 0)) -       nvl(mw.cutting, 0) as PAID_AMNT  from m_wage mw  join employee_master em on mw.emp_code = em.emp_code  and em.emp_type in(2,3,4)  join employ_firm ef on ef.emp_code = mw.emp_code   and ef.firm_id in ('" & Session("firm_id") & "')   join branch_master bm on em.branch_id = bm.branch_id   join designation_master dm on dm.designation_id = em.designation_id   join firm_master fm on ef.firm_id = fm.firm_id  order by branchname, firm_abbr, emp_code"
        ElseIf emptype = 3 And date_str = mon Then
            str = "select mw.emp_code,       mw.name,       mw.fat_hus,       nvl(mw.basic_pay, 0),       nvl(mw.vda, 0),       (nvl(mw.ovt_wages, 0) + nvl(mw.arrear_sal, 0) + nvl(mw.arrear_da, 0) +       nvl(mw.oth_add, 0)) as Arrear_salary,       nvl(mw.wages_pble, 0),       (nvl(mw.w_days, 0) - nvl(mw.l_days, 0)) as Total_attendance,       (nvl(mw.lop, 0) + nvl(mw.oth_ded, 0)) as oth_deduction,       nvl(mw.p_fund, 0),       nvl(mw.esi, 0),       nvl(mw.s_w_fund, 0),       nvl(mw.l_w_fund, 0),       nvl(mw.p_tax, 0),       nvl(mw.lic, 0),       nvl(mw.tds, 0),       nvl(mw.rdded_amt, 0),       (nvl(mw.tot_dedu, 0) + nvl(mw.lop, 0)) as total_deduction,       nvl(mw.bonus, 0),       (nvl(mw.net_pay, 0) + nvl(mw.bonus, 0)) as WAGES_PAID,       mw.sal_dt,       dm.designation,       fm.firm_abbr,       bm.branch_name as branchname,       bm.branch_id as brid,       em.emp_type,       mw.status_id,       mw.ta_total,       (nvl(mw.net_pay, 0) + nvl(mw.bonus, 0) + nvl(mw.ta_total, 0)) -       nvl(mw.cutting, 0) as PAID_AMNT  from m_wage mw  join employee_master em on mw.emp_code = em.emp_code  and em.emp_type in(1)  join employ_firm ef on ef.emp_code = mw.emp_code   and ef.firm_id in ('" & Session("firm_id") & "')   join branch_master bm on em.branch_id = bm.branch_id   join designation_master dm on dm.designation_id = em.designation_id   join firm_master fm on ef.firm_id = fm.firm_id  union select mw.emp_code,       mw.name,       mw.fat_hus,       nvl(mw.basic_pay, 0),       nvl(mw.vda, 0),       (nvl(mw.ovt_wages, 0) + nvl(mw.arrear_sal, 0) + nvl(mw.arrear_da, 0) +       nvl(mw.oth_add, 0)) as Arrear_salary,       nvl(mw.wages_pble, 0),       (nvl(mw.w_days, 0) - nvl(mw.l_days, 0)) as Total_attendance,       (nvl(mw.lop, 0) + nvl(mw.oth_ded, 0)) as oth_deduction,       nvl(mw.p_fund, 0),       nvl(mw.esi, 0),       nvl(mw.s_w_fund, 0),       nvl(mw.l_w_fund, 0),       nvl(mw.p_tax, 0),       nvl(mw.lic, 0),       nvl(mw.tds, 0),       nvl(mw.rdded_amt, 0),       (nvl(mw.tot_dedu, 0) + nvl(mw.lop, 0)) as total_deduction,       nvl(mw.bonus, 0),       (nvl(mw.net_pay, 0) + nvl(mw.bonus, 0)) as WAGES_PAID,       mw.sal_dt,       dm.designation,       fm.firm_abbr,       bm.branch_name as branchname,       bm.branch_id as brid,       em.emp_type,       mw.status_id,       mw.ta_total,       (nvl(mw.net_pay, 0) + nvl(mw.bonus, 0) + nvl(mw.ta_total, 0)) -       nvl(mw.cutting, 0)  as PAID_AMNT  from m_wage mw  join employee_master em on mw.emp_code = em.emp_code  and em.emp_type in(2,3,4)  join employ_firm ef on ef.emp_code = mw.emp_code   and ef.firm_id in ('" & Session("firm_id") & "')   join branch_master bm on em.branch_id = bm.branch_id   join designation_master dm on dm.designation_id = em.designation_id   join firm_master fm on ef.firm_id = fm.firm_id order by branchname, firm_abbr, emp_code  "


        ElseIf emptype = 1 And date_str <> mon Then
            str = "select mw.emp_code,        mw.name,        mw.fat_hus,        nvl(mw.basic_pay, 0),        nvl(mw.vda, 0),        (nvl(mw.ovt_wages, 0) + nvl(mw.arrear_sal, 0) + nvl(mw.arrear_da, 0) +        nvl(mw.oth_add, 0)) as Arrear_salary,        nvl(mw.wages_pble, 0),        (nvl(mw.w_days, 0) - nvl(mw.l_days, 0)) as Total_attendance,        (nvl(mw.lop, 0) + nvl(mw.oth_ded, 0)) as oth_deduction,        nvl(mw.p_fund, 0),        nvl(mw.esi, 0),        nvl(mw.s_w_fund, 0),        nvl(mw.l_w_fund, 0),        nvl(mw.p_tax, 0),        nvl(mw.lic, 0),        nvl(mw.tds, 0),        nvl(mw.rdded_amt, 0),        (nvl(mw.tot_dedu, 0) + nvl(mw.lop, 0)) as total_deduction,        nvl(mw.bonus, 0),        (nvl(mw.net_pay, 0) + nvl(mw.bonus, 0)) as WAGES_PAID,        mw.sal_dt,        dm.designation,        fm.firm_abbr,        bm.branch_name as branchname,        bm.branch_id as brid,        em.emp_type,        mw.status_id,        mw.ta_total,        (nvl(mw.net_pay, 0) + nvl(mw.bonus, 0) + nvl(mw.ta_total, 0)) -    nvl(mw.cutting, 0)  as PAID_AMNT  from m_wage_his mw   join employee_master em on mw.emp_code = em.emp_code    and em.emp_type in (1)   join employ_firm ef on ef.emp_code = mw.emp_code and ef.firm_id in ('" & Session("firm_id") & "')   join branch_master bm on em.branch_id = bm.branch_id   join designation_master dm on dm.designation_id = em.designation_id   join firm_master fm on ef.firm_id = fm.firm_id   where  to_date(mw.sal_dt) between   to_date('" & first_dat & "','mm-dd-yyyy') and    to_date('" & date_str & "','mm-dd-yyyy')  order by branchname, firm_abbr, emp_code "
        ElseIf emptype = 2 And date_str <> mon Then
            str = "select mw.emp_code,        mw.name,        mw.fat_hus,        nvl(mw.basic_pay, 0),        nvl(mw.vda, 0),        (nvl(mw.ovt_wages, 0) + nvl(mw.arrear_sal, 0) + nvl(mw.arrear_da, 0) +        nvl(mw.oth_add, 0)) as Arrear_salary,        nvl(mw.wages_pble, 0),        (nvl(mw.w_days, 0) - nvl(mw.l_days, 0)) as Total_attendance,        (nvl(mw.lop, 0) + nvl(mw.oth_ded, 0)) as oth_deduction,        nvl(mw.p_fund, 0),        nvl(mw.esi, 0),        nvl(mw.s_w_fund, 0),        nvl(mw.l_w_fund, 0),        nvl(mw.p_tax, 0),        nvl(mw.lic, 0),        nvl(mw.tds, 0),        nvl(mw.rdded_amt, 0),        (nvl(mw.tot_dedu, 0) + nvl(mw.lop, 0)) as total_deduction,        nvl(mw.bonus, 0),        (nvl(mw.net_pay, 0) + nvl(mw.bonus, 0)) as WAGES_PAID,        mw.sal_dt,        dm.designation,        fm.firm_abbr,        bm.branch_name as branchname,        bm.branch_id as brid,        em.emp_type,        mw.status_id,        mw.ta_total,        (nvl(mw.net_pay, 0) + nvl(mw.bonus, 0) + nvl(mw.ta_total, 0)) -    nvl(mw.cutting, 0)  as PAID_AMNT  from m_wage_his mw   join employee_master em on mw.emp_code = em.emp_code    and em.emp_type in (2,3,4)   join employ_firm ef on ef.emp_code = mw.emp_code and ef.firm_id in ('" & Session("firm_id") & "')   join branch_master bm on em.branch_id = bm.branch_id   join designation_master dm on dm.designation_id = em.designation_id   join firm_master fm on ef.firm_id = fm.firm_id   where  to_date(mw.sal_dt) between   to_date('" & first_dat & "','mm-dd-yyyy') and    to_date('" & date_str & "','mm-dd-yyyy')  order by branchname, firm_abbr, emp_code"
        ElseIf emptype = 3 And date_str <> mon Then
            str = "select mw.emp_code,        mw.name,        mw.fat_hus,        nvl(mw.basic_pay, 0),        nvl(mw.vda, 0),        (nvl(mw.ovt_wages, 0) + nvl(mw.arrear_sal, 0) + nvl(mw.arrear_da, 0) +        nvl(mw.oth_add, 0)) as Arrear_salary,        nvl(mw.wages_pble, 0),        (nvl(mw.w_days, 0) - nvl(mw.l_days, 0)) as Total_attendance,        (nvl(mw.lop, 0) + nvl(mw.oth_ded, 0)) as oth_deduction,        nvl(mw.p_fund, 0),        nvl(mw.esi, 0),        nvl(mw.s_w_fund, 0),        nvl(mw.l_w_fund, 0),        nvl(mw.p_tax, 0),        nvl(mw.lic, 0),        nvl(mw.tds, 0),        nvl(mw.rdded_amt, 0),        (nvl(mw.tot_dedu, 0) + nvl(mw.lop, 0)) as total_deduction,        nvl(mw.bonus, 0),        (nvl(mw.net_pay, 0) + nvl(mw.bonus, 0)) as WAGES_PAID,        mw.sal_dt,        dm.designation,        fm.firm_abbr,        bm.branch_name as branchname,        bm.branch_id as brid,        em.emp_type,        mw.status_id,        mw.ta_total,        (nvl(mw.net_pay, 0) + nvl(mw.bonus, 0) + nvl(mw.ta_total, 0)) -    nvl(mw.cutting, 0)  as PAID_AMNT  from m_wage_his mw   join employee_master em on mw.emp_code = em.emp_code    and em.emp_type in (1)   join employ_firm ef on ef.emp_code = mw.emp_code and ef.firm_id in ('" & Session("firm_id") & "')   join branch_master bm on em.branch_id = bm.branch_id   join designation_master dm on dm.designation_id = em.designation_id   join firm_master fm on ef.firm_id = fm.firm_id   where  to_date(mw.sal_dt) between   to_date('" & first_dat & "','mm-dd-yyyy') and    to_date('" & date_str & "','mm-dd-yyyy') union  select mw.emp_code,        mw.name,        mw.fat_hus,        nvl(mw.basic_pay, 0),        nvl(mw.vda, 0),        (nvl(mw.ovt_wages, 0) + nvl(mw.arrear_sal, 0) + nvl(mw.arrear_da, 0) +        nvl(mw.oth_add, 0)) as Arrear_salary,        nvl(mw.wages_pble, 0),        (nvl(mw.w_days, 0) - nvl(mw.l_days, 0)) as Total_attendance,        (nvl(mw.lop, 0) + nvl(mw.oth_ded, 0)) as oth_deduction,        nvl(mw.p_fund, 0),        nvl(mw.esi, 0),        nvl(mw.s_w_fund, 0),        nvl(mw.l_w_fund, 0),        nvl(mw.p_tax, 0),        nvl(mw.lic, 0),        nvl(mw.tds, 0),        nvl(mw.rdded_amt, 0),        (nvl(mw.tot_dedu, 0) + nvl(mw.lop, 0)) as total_deduction,        nvl(mw.bonus, 0),        (nvl(mw.net_pay, 0) + nvl(mw.bonus, 0)) as WAGES_PAID,        mw.sal_dt,        dm.designation,        fm.firm_abbr,        bm.branch_name as branchname,        bm.branch_id as brid,        em.emp_type,        mw.status_id,        mw.ta_total,        (nvl(mw.net_pay, 0) + nvl(mw.bonus, 0) + nvl(mw.ta_total, 0)) -    nvl(mw.cutting, 0)  as PAID_AMNT  from m_wage_his mw   join employee_master em on mw.emp_code = em.emp_code    and em.emp_type in (2,3,4)   join employ_firm ef on ef.emp_code = mw.emp_code and ef.firm_id in ('" & Session("firm_id") & "')   join branch_master bm on em.branch_id = bm.branch_id   join designation_master dm on dm.designation_id = em.designation_id   join firm_master fm on ef.firm_id = fm.firm_id   where  to_date(mw.sal_dt) between   to_date('" & first_dat & "','mm-dd-yyyy') and    to_date('" & date_str & "','mm-dd-yyyy') order by branchname, firm_abbr, emp_code    "

        End If

        dt = oh.ExecuteDataSet(str).Tables(0)

        Dim header As New TableRow
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        header.Width = 450
        Dim headercell As New TableCell
        headercell.ColumnSpan = 450
        headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headercell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headercell)
        salarytable.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.Width = 450
        sheader.BackColor = Drawing.Color.LightGray
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 450
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        salarytable.Controls.Add(sheader)

        Dim shfirm As String = ""
        Dim shbrch As String = ""
        Dim sbranchid As Double = -9999
        Dim color As Integer = 0
        For Each dr In dt.Rows
            Dim rrb As New TableRow
            Dim rr As New TableRow
            'If (color = 0) Then
            '    rrb.BackColor = Drawing.Color.GhostWhite
            '    color = 1
            'Else
            '    rrb.BackColor = Drawing.Color.WhiteSmoke
            '    color = 0
            'End If
            reccount += 1
            sino = sino + 1
            If reccount > 72 Then
                pagenext()
                pagenonext += 1
                numbering(pagenonext)
                reccount = 0
                'fieldname()
            End If
            If shbrch <> dr(23) Then
                If sbranchid <> -9999 Then
                    'sino = sino - 1
                    brtotal()
                    pagenext()
                    reccount = 0
                    pagenonext += 1
                    numbering(pagenonext)
                    'End If
                    sino = 0
                End If

                titlefunc()
                reccount += 5
                shfirm = ""

                rrb.Width = 22
                rrb.ForeColor = Drawing.Color.Black
                ' rrb.BackColor = Drawing.Color.Lavender



                If shfirm <> dr(22).ToString Then
                    'Dim rr As New TableRow
                    rr.Width = 50
                    rr.ForeColor = Drawing.Color.Black
                    rr.BackColor = Drawing.Color.WhiteSmoke

                    Dim rr1 As New TableCell
                    rr1.ColumnSpan = 450
                    rr1.HorizontalAlign = HorizontalAlign.Center
                    rr1.Text = "<b><u><font size=3>&nbsp;&nbsp;Firm&nbsp;:&nbsp;&nbsp;" & dr(22) & "</font></u></b>"
                    rr.Controls.Add(rr1)
                    salarytable.Controls.Add(rr)
                    reccount += 1
                End If





                Dim rrb1 As New TableCell
                rrb1.ColumnSpan = 450
                rrb1.HorizontalAlign = HorizontalAlign.Center
                rrb1.Text = "<b><u><font size=3>Salary for &nbsp;:&nbsp;&nbsp;" & dr(23) & "</font></u></b>"
                rrb.Controls.Add(rrb1)
                salarytable.Controls.Add(rrb)
                reccount += 1
                Dim rrb_d As New TableRow
                Dim rrb_dummy As New TableCell
                rrb_dummy.ColumnSpan = 450
                rrb_dummy.HorizontalAlign = HorizontalAlign.Center
                'rrb1.Text = "<b><u><font size=3>Salary for &nbsp;:&nbsp;&nbsp;" & dr(23) & "</font></u></b>"
                rrb_d.Controls.Add(rrb_dummy)
                salarytable.Controls.Add(rrb_d)
                fieldname()
                reccount += 1
                basic = 0
                vda = 0
                arrsal = 0
                wagespayable = 0
                esi = 0
                pf = 0
                swf = 0
                lwf = 0
                lic = 0
                tds = 0
                othded = 0
                rdded = 0
                proftax = 0
                totalded = 0
                bonus = 0
                ta_total = 0
                wagespaid = 0
            End If

            shfirm = dr(22)
            shbrch = dr(23)
            sbranchid = dr(24)

            Dim values As New TableRow
            values.Width = 90
            If color = 0 Then

                values.BackColor = Drawing.Color.GhostWhite
                color = 1
            Else

                values.BackColor = Drawing.Color.WhiteSmoke




                color = 0
            End If

            ' values.Attributes.Add("bgcolor", colors)
            Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v27, v24 As New TableCell

            v1.ColumnSpan = 2
            v1.HorizontalAlign = HorizontalAlign.Center
            v1.Text = "<font size=2><b>" & dr(0) & "</b></font>"
            values.Controls.Add(v1)

            v2.ColumnSpan = 2
            v2.HorizontalAlign = HorizontalAlign.Left
            v2.Text = "<font size=2>&nbsp;" & dr(1) & "</font>"
            values.Controls.Add(v2)

            ' ///////father name
            'v3.ColumnSpan = 1
            'v3.HorizontalAlign = HorizontalAlign.Left
            'v3.Text = "<font size=2>&nbsp;" & dr(2) & "</font>"
            'values.Controls.Add(v3)

            ' /////////////Designation
            v4.ColumnSpan = 2
            v4.HorizontalAlign = HorizontalAlign.Left
            v4.Text = "<font size=2>" & dr(21) & "</font>"
            values.Controls.Add(v4)

            ' ///////////////Basic
            v5.ColumnSpan = 2
            v5.HorizontalAlign = HorizontalAlign.Right
            v5.Text = "<font size=2>" & dr(3) & "</font>"
            values.Controls.Add(v5)
            basic += dr(3)


            '///////DA
            v6.ColumnSpan = 2
            v6.HorizontalAlign = HorizontalAlign.Right
            v6.Text = "<font size=2>" & dr(4) & "</font>"
            values.Controls.Add(v6)
            vda += dr(4)


            ' ///////////////Total Attendance

            v7.ColumnSpan = 3
            v7.HorizontalAlign = HorizontalAlign.Right
            v7.Text = "<font size=2>" & dr(7) & "</font>"
            values.Controls.Add(v7)

            ' /////////////Arrear Salary

            v8.ColumnSpan = 4
            v8.HorizontalAlign = HorizontalAlign.Right
            v8.Text = "<font size=2>" & dr(5) & "</font>"
            values.Controls.Add(v8)
            arrsal += dr(5)


            '  /////////////wages payable
            v9.ColumnSpan = 4
            v9.HorizontalAlign = HorizontalAlign.Right
            v9.Text = "<font size=2>" & dr(6) & "</font>"
            values.Controls.Add(v9)
            wagespayable += dr(6)

            ' //////////////////Pf

            v10.ColumnSpan = 19
            v10.HorizontalAlign = HorizontalAlign.Right
            v10.Text = "<font size=2>" & dr(9) & "</font>"
            values.Controls.Add(v10)
            pf += dr(9)



            '////////ESI
            v11.ColumnSpan = 22
            v11.HorizontalAlign = HorizontalAlign.Right
            v11.Text = "<font size=2>" & dr(10) & "</font>"
            values.Controls.Add(v11)
            esi += dr(10)

            '/////////Staff(Welfare)

            v12.ColumnSpan = 18
            v12.HorizontalAlign = HorizontalAlign.Right
            v12.Text = "<font size=2>" & dr(11) & "</font>"
            values.Controls.Add(v12)
            swf += dr(11)



            ' //////////////Insurance Premium
            v13.ColumnSpan = 26
            v13.HorizontalAlign = HorizontalAlign.Right
            v13.Text = "<font size=2>" & dr(14) & "</font>"
            values.Controls.Add(v13)
            lic += dr(14)


            ' /////////////Professiona; Tax
            v14.ColumnSpan = 30
            v14.HorizontalAlign = HorizontalAlign.Right
            v14.Text = "<font size=2>" & dr(13) & "</font>"
            values.Controls.Add(v14)
            proftax += dr(13)


            ' ///////////////TDS
            v15.ColumnSpan = 10
            v15.HorizontalAlign = HorizontalAlign.Right
            v15.Text = "<font size=2>" & dr(15) & "</font>"
            values.Controls.Add(v15)
            tds += dr(15)



            '////////////////LWF


            v16.ColumnSpan = 30
            v16.HorizontalAlign = HorizontalAlign.Right
            v16.Text = "<font size=2>" & dr(12) & "</font>"
            values.Controls.Add(v16)
            lwf += dr(12)


            ' /////////////RD Deduction
            v17.ColumnSpan = 25
            v17.HorizontalAlign = HorizontalAlign.Right
            v17.Text = "<font size=2>" & dr(16) & "</font>"
            values.Controls.Add(v17)
            rdded += dr(16)

            ' //////////////Oth Deduction
            v18.ColumnSpan = 28
            v18.HorizontalAlign = HorizontalAlign.Right
            v18.Text = "<font size=2>" & dr(8) & "</font>"
            values.Controls.Add(v18)
            othded += dr(8)

            '  ///////////Total Deduction
            v19.ColumnSpan = 20
            v19.HorizontalAlign = HorizontalAlign.Center
            v19.Text = "<font size=2>" & dr(17) & "</font>"
            values.Controls.Add(v19)
            totalded += dr(17)

            '/////////////Bonus Amount
            v20.ColumnSpan = 15
            v20.HorizontalAlign = HorizontalAlign.Right
            v20.Text = "<font size=2>" & dr(18) & "</font>"
            values.Controls.Add(v20)
            bonus += dr(18)




            '/////////////Allowances
            v27.ColumnSpan = 17
            v27.HorizontalAlign = HorizontalAlign.Right
            v27.Text = "<font size=2>" & dr(27) & "</font>"
            values.Controls.Add(v27)
            ta_total += dr(27)



            '  //////////////Wages Paid
            v21.ColumnSpan = 28
            v21.HorizontalAlign = HorizontalAlign.Right
            v21.Text = "<font size=2>" & dr(28) & "</font>"
            values.Controls.Add(v21)
            wagespaid += dr(28)

            ' ////////Date of Payment
            v22.ColumnSpan = 36
            v22.HorizontalAlign = HorizontalAlign.Center
            If IsDBNull(dr(20)) Then
                v22.Text = "<font size=2>--</font>"
            Else

                v22.Text = "<font size=2>" & Format(dr(20), "dd/MMM/yyyy") & "</font>"
            End If
            values.Controls.Add(v22)

            v23.ColumnSpan = 2
            v23.HorizontalAlign = HorizontalAlign.Right
            v23.Text = " "
            values.Controls.Add(v23)




            '  //////////////Account
            v24.ColumnSpan = 3
            v24.HorizontalAlign = HorizontalAlign.Left
            Dim acc As String
            Dim cntacc As Integer
            cntacc = oh.ExecuteDataSet("select count(t.bank_accno) from employee_master_dtl t where t.emp_code=" & dr(0) & "").Tables(0).Rows(0)(0)
            If cntacc = 1 Then
                acc = oh.ExecuteDataSet("select t.bank_accno from employee_master_dtl t where t.emp_code=" & dr(0) & "").Tables(0).Rows(0)(0)
            Else
                acc = "--"
            End If
            v24.Text = "<font size=2>" & acc & "</font>"
            values.Controls.Add(v24)



            salarytable.Controls.Add(values)

            Dim liness As New TableRow
            liness.Width = 450
            Dim linewss1 As New TableCell
            linewss1.ColumnSpan = 450
            linewss1.HorizontalAlign = HorizontalAlign.Center
            linewss1.Text = " "
            liness.Controls.Add(linewss1)
            salarytable.Controls.Add(liness)
            reccount += 1

            Dim linesr As New TableRow
            linesr.Width = 450
            Dim linewssr As New TableCell
            linewssr.ColumnSpan = 450
            linewssr.HorizontalAlign = HorizontalAlign.Center
            linewssr.Text = " "
            linesr.Controls.Add(linewssr)
            salarytable.Controls.Add(linesr)
            reccount += 1

            Dim linest As New TableRow
            linest.Width = 450
            Dim linewsst As New TableCell
            linewsst.ColumnSpan = 450
            linewsst.HorizontalAlign = HorizontalAlign.Center
            linewsst.Text = " "
            linest.Controls.Add(linewsst)
            salarytable.Controls.Add(linest)
            reccount += 1
        Next
        brtotal()
        Panel_Sal_HO.Controls.Add(salarytable)
    End Sub
    Sub titlefunc()
        Dim ttf As New TableRow
        ttf.Width = 50
        Dim ttf1 As New TableCell
        ttf1.ColumnSpan = 450
        ttf1.HorizontalAlign = HorizontalAlign.Center
        ttf1.BackColor = Drawing.Color.LightGray
        If session("firm_id") = 28 Then
            ttf1.Text = "<b><font size=3>&nbsp;&nbsp;FORM B&nbsp;&nbsp;</font></b>"
        Else
            ttf1.Text = "<b><font size=3>&nbsp;&nbsp;FORM XI&nbsp;&nbsp;</font></b>"
        End If
        ttf.Controls.Add(ttf1)
        salarytable.Controls.Add(ttf)

        Dim ttss As New TableRow
        ttss.Width = 450
        Dim ttss1 As New TableCell
        ttss1.ColumnSpan = 450
        ttss1.HorizontalAlign = HorizontalAlign.Center
        If session("firm_id") = 28 Then
            ttss1.Text = "<b><font size=3></font></b>"
        Else
            ttss1.Text = "<b><font size=3>&nbsp;&nbsp;See Rule 29(1)&nbsp;&nbsp;</font></b>"
        End If

        ttss.Controls.Add(ttss1)
        salarytable.Controls.Add(ttss)


        Dim s As String = oh.ExecuteDataSet("select  to_char(to_date(' " & date_str & " ','mm-dd-yyyy'),'DD-MON-YYYY') from dual").Tables(0).Rows(0)(0)
        'Dim y As Integer = oh.ExecuteDataSet("select distinct to_char(to_date(s.sal_dt),'YYYY') from salari s").Tables(0).Rows(0)(0)

        Dim tt As New TableRow
        tt.Width = 450
        Dim tt1 As New TableCell
        tt1.ColumnSpan = 450
        tt1.HorizontalAlign = HorizontalAlign.Center
        tt1.Text = "<b><font size=3>REGISTER OF WAGES of " & s & " </font></b>"
        tt.Controls.Add(tt1)
        salarytable.Controls.Add(tt)

        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 50

        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 1
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 240
        subcell2.HorizontalAlign = HorizontalAlign.Center
        'If Me.Request.QueryString("emp_status") = 1 Then
        If emptype = 1 Then
            subcell2.Text = "<b><font size=3>Includes&nbsp;Permanant&nbsp;Employees&nbsp;only &nbsp;</font></b>"
        ElseIf Me.emptype = 2 Then
            subcell2.Text = "<b><font size=3>Includes&nbsp;Outsource&nbsp;Employees&nbsp;only&nbsp;&nbsp;</font></b>"
        End If

        subh.Controls.Add(subcell2)
        subcell3.ColumnSpan = 1
        subcell3.HorizontalAlign = HorizontalAlign.Left
        subcell3.Text = "<b><font size=3.5>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)
        salarytable.Controls.Add(subh)


        Dim linea As New TableRow
        Dim linecella As New TableCell
        linecella.ColumnSpan = 450
        linecella.Text = "<hr>"
        linea.Controls.Add(linecella)
        salarytable.Controls.Add(linea)
        'If colors.Equals("#fff7ff") = True Then
        '    colors = "#eef9ff"
        'Else
        '    colors = "#fff7ff"
        'End If

    End Sub
    Sub fieldname()
        reccount += 1
        Dim field As New TableRow
        field.Width = 100
        field.BackColor = Drawing.Color.DarkGray
        ' field.Attributes.Add("bgcolor", colors)
        Dim f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f27, f12, f13, f14, f15, f16, f17, f18, f19, f20, f21, f22, f23 As New TableCell
        f1.ColumnSpan = 2
        'f1.BackColor = Drawing.Color.DarkSalmon
        f1.HorizontalAlign = HorizontalAlign.Center
        f1.ForeColor = Drawing.Color.Black
        f1.Text = "<b><font size=2>EMP CODE </font></b>"
        field.Controls.Add(f1)

        f2.ColumnSpan = 2
        'f2.BackColor = Drawing.Color.DarkGray
        f2.HorizontalAlign = HorizontalAlign.Left
        f2.ForeColor = Drawing.Color.White
        f2.Text = "<b><font size=2>EMP NAME </font></b>"
        field.Controls.Add(f2)

        'f3.ColumnSpan = 1
        'f3.HorizontalAlign = HorizontalAlign.Left
        'f3.Text = "<b><font size=2>Fat/Hus Name</font></b>"
        'field.Controls.Add(f3)

        f4.ColumnSpan = 2
        f4.HorizontalAlign = HorizontalAlign.Left
        f4.ForeColor = Drawing.Color.Black
        'f4.BackColor = Drawing.Color.DarkSalmon
        f4.Text = "<b><font size=2>DESIG </font></b>"
        field.Controls.Add(f4)

        f5.ColumnSpan = 3
        f5.HorizontalAlign = HorizontalAlign.Right
        f5.ForeColor = Drawing.Color.White
        'f5.BackColor = Drawing.Color.DarkGray
        f5.Text = "<b><font size=2>BASIC </font></b>"
        field.Controls.Add(f5)

        f6.ColumnSpan = 2
        f6.HorizontalAlign = HorizontalAlign.Right
        f6.ForeColor = Drawing.Color.Black
        'f6.BackColor = Drawing.Color.DarkSalmon
        f6.Text = "<b><font size=2>VDA </font></b>"
        field.Controls.Add(f6)

        f7.ColumnSpan = 3
        f7.HorizontalAlign = HorizontalAlign.Right
        f7.ForeColor = Drawing.Color.White
        'f7.BackColor = Drawing.Color.DarkGray
        f7.Text = "<b><font size=2>&nbsp; &nbsp; ATTENDANCE</font></b>"
        field.Controls.Add(f7)

        f8.ColumnSpan = 4
        f8.HorizontalAlign = HorizontalAlign.Right
        f8.ForeColor = Drawing.Color.Black
        'f8.BackColor = Drawing.Color.DarkSalmon
        f8.Text = "<b><font size=2>ARR SAL </font></b>"
        field.Controls.Add(f8)

        f9.ColumnSpan = 3
        f9.HorizontalAlign = HorizontalAlign.Right
        f9.ForeColor = Drawing.Color.White
        'f9.BackColor = Drawing.Color.DarkGray
        f9.Text = "<b><font size=2>WAGE PAYABLE </font></b>"
        field.Controls.Add(f9)

        f10.ColumnSpan = 19
        f10.HorizontalAlign = HorizontalAlign.Right
        f10.ForeColor = Drawing.Color.Black
        'f10.BackColor = Drawing.Color.DarkSalmon
        f10.Text = "<b><font size=2>PF </font></b>"
        field.Controls.Add(f10)

        f11.ColumnSpan = 22
        f11.HorizontalAlign = HorizontalAlign.Right
        f11.ForeColor = Drawing.Color.White
        'f11.BackColor = Drawing.Color.DarkGray
        f11.Text = "<b><font size=2>ESI </font></b>"
        field.Controls.Add(f11)

        f12.ColumnSpan = 18
        f12.HorizontalAlign = HorizontalAlign.Right
        f12.ForeColor = Drawing.Color.Black
        'f12.BackColor = Drawing.Color.DarkSalmon
        f12.Text = "<b><font size=2>SWF </font></b>"
        field.Controls.Add(f12)

        f13.ColumnSpan = 26
        f13.HorizontalAlign = HorizontalAlign.Right
        f13.ForeColor = Drawing.Color.White
        'f13.BackColor = Drawing.Color.DarkGray
        f13.Text = "<b><font size=2>INS </font></b>"
        field.Controls.Add(f13)

        f14.ColumnSpan = 30
        f14.HorizontalAlign = HorizontalAlign.Right
        f14.ForeColor = Drawing.Color.Black
        'f14.BackColor = Drawing.Color.DarkSalmon
        f14.Text = "<b><font size=2>P.TAX </font></b>"
        field.Controls.Add(f14)

        f15.ColumnSpan = 13
        f15.HorizontalAlign = HorizontalAlign.Right
        f15.ForeColor = Drawing.Color.White
        'f15.BackColor = Drawing.Color.DarkGray
        f15.Text = "<b><font size=2>TDS </font></b>"
        field.Controls.Add(f15)

        f16.ColumnSpan = 30
        f16.HorizontalAlign = HorizontalAlign.Right
        f16.ForeColor = Drawing.Color.Black
        'f16.BackColor = Drawing.Color.DarkSalmon
        f16.Text = "<b><font size=2>&nbsp;LWF </font></b>"
        field.Controls.Add(f16)

        f17.ColumnSpan = 20
        f17.HorizontalAlign = HorizontalAlign.Right
        f17.ForeColor = Drawing.Color.White
        'f17.BackColor = Drawing.Color.DarkGray
        f17.Text = "<b><font size=2>RD </font></b>"
        field.Controls.Add(f17)

        f18.ColumnSpan = 35
        f18.HorizontalAlign = HorizontalAlign.Right
        f18.ForeColor = Drawing.Color.Black
        'f18.BackColor = Drawing.Color.DarkSalmon
        f18.Text = "<b><font size=2>OTH DED </font></b>"
        field.Controls.Add(f18)

        f19.ColumnSpan = 13
        f19.HorizontalAlign = HorizontalAlign.Center
        f19.ForeColor = Drawing.Color.White
        'f19.BackColor = Drawing.Color.DarkGray
        f19.Text = "<b><font size=2>TOT DED </font></b>"
        field.Controls.Add(f19)

        f20.ColumnSpan = 17
        f20.HorizontalAlign = HorizontalAlign.Right
        f20.ForeColor = Drawing.Color.Black
        'f20.BackColor = Drawing.Color.DarkSalmon
        f20.Text = "<b><font size=2>&nbsp;BONUS </font></b>"
        field.Controls.Add(f20)


        f27.ColumnSpan = 19
        f27.HorizontalAlign = HorizontalAlign.Right
        f27.ForeColor = Drawing.Color.White
        'f20.BackColor = Drawing.Color.DarkSalmon
        f27.Text = "<b><font size=2>TA </font></b>"
        field.Controls.Add(f27)


        f21.ColumnSpan = 36
        f21.HorizontalAlign = HorizontalAlign.Right
        f21.ForeColor = Drawing.Color.Black
        'f21.BackColor = Drawing.Color.DarkGray
        f21.Text = "<b><font size=2>&nbsp;&nbsp;WAGE PAID&nbsp;  </font></b>"
        field.Controls.Add(f21)

        f22.ColumnSpan = 28
        f22.HorizontalAlign = HorizontalAlign.Center
        f22.ForeColor = Drawing.Color.White
        'f22.BackColor = Drawing.Color.DarkSalmon
        f22.Text = "<b><font size=2>DATE OF PAY </font></b>"
        field.Controls.Add(f22)

        f23.ColumnSpan = 3
        f23.HorizontalAlign = HorizontalAlign.Left
        f23.ForeColor = Drawing.Color.Black
        'f23.BackColor = Drawing.Color.DarkGray
        f23.Text = "<b><font size=2>ACCOUNT NO </font></b>"
        field.Controls.Add(f23)

        salarytable.Controls.Add(field)

        Dim linew As New TableRow
        linew.Width = 450
        Dim linew1 As New TableCell
        linew1.ColumnSpan = 450

        linew1.HorizontalAlign = HorizontalAlign.Center
        linew1.Text = "<hr>"
        linew.Controls.Add(linew1)
        salarytable.Controls.Add(linew)
    End Sub
    Sub brtotal()
        Dim liaa As New TableRow
        Dim liaa1 As New TableCell
        liaa1.ColumnSpan = 450

        liaa1.Text = "<hr>"
        liaa.Controls.Add(liaa1)
        salarytable.Controls.Add(liaa)

        Dim brtotal As New TableRow
        brtotal.Width = 450
        Dim b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14, b15, b16, b17, b27 As New TableCell

        b1.ColumnSpan = 1
        b1.HorizontalAlign = HorizontalAlign.Left
        b1.Text = "<b><font size=2>Total</font></b>"
        brtotal.Controls.Add(b1)

        '///basic
        b2.ColumnSpan = 8
        b2.HorizontalAlign = HorizontalAlign.Right
        b2.Text = "<b><font size=2>" & basic & "</font></b>"
        brtotal.Controls.Add(b2)

        ' //vda
        b3.ColumnSpan = 1
        b3.HorizontalAlign = HorizontalAlign.Right
        b3.Text = "<b><font size=2>" & vda & "</font></b>"
        brtotal.Controls.Add(b3)

        '///arrearsal
        b4.ColumnSpan = 7
        b4.HorizontalAlign = HorizontalAlign.Right
        b4.Text = "<b><font size=2>" & arrsal & "</font></b>"
        brtotal.Controls.Add(b4)

        ' ///wagespayable
        b5.ColumnSpan = 4
        b5.HorizontalAlign = HorizontalAlign.Right
        b5.Text = "<b><font size=2>" & wagespayable & "</font></b>"
        brtotal.Controls.Add(b5)

        ' ////pf
        b6.ColumnSpan = 19

        b6.HorizontalAlign = HorizontalAlign.Right
        b6.Text = "<b><font size=2>" & pf & "</font></b>"
        brtotal.Controls.Add(b6)

        '////Esi
        b7.ColumnSpan = 22
        b7.HorizontalAlign = HorizontalAlign.Right
        b7.Text = "<b><font size=2>" & esi & "</font></b>"
        brtotal.Controls.Add(b7)

        '////swf
        b8.ColumnSpan = 18
        b8.HorizontalAlign = HorizontalAlign.Right
        b8.Text = "<b><font size=2>" & swf & "</font></b>"
        brtotal.Controls.Add(b8)

        ' ////insPremium
        b9.ColumnSpan = 25
        b9.HorizontalAlign = HorizontalAlign.Right
        b9.Text = "<b><font size=2>" & lic & "</font></b>"
        brtotal.Controls.Add(b9)

        ' ////proffTax

        b10.ColumnSpan = 28
        b10.HorizontalAlign = HorizontalAlign.Right
        b10.Text = "<b><font size=2>" & proftax & "</font></b>"
        brtotal.Controls.Add(b10)

        '//Tds
        b11.ColumnSpan = 18
        b11.HorizontalAlign = HorizontalAlign.Right
        b11.Text = "<b><font size=2>" & tds & "</font></b>"
        brtotal.Controls.Add(b11)

        '///lwf
        b12.ColumnSpan = 22
        b12.HorizontalAlign = HorizontalAlign.Right
        b12.Text = "<b><font size=2>" & lwf & "</font></b>"
        brtotal.Controls.Add(b12)

        ' ///rdded

        b13.ColumnSpan = 24
        b13.HorizontalAlign = HorizontalAlign.Right
        b13.Text = "<b><font size=2>" & rdded & "</font></b>"
        brtotal.Controls.Add(b13)

        ' ///othDed
        b14.ColumnSpan = 30
        b14.HorizontalAlign = HorizontalAlign.Right
        b14.Text = "<b><font size=2>" & othded & "</font></b>"
        brtotal.Controls.Add(b14)

        ' ////tot_Ded

        b15.ColumnSpan = 22
        b15.HorizontalAlign = HorizontalAlign.Center
        b15.Text = "<b><font size=2>" & totalded & "</font></b>"
        brtotal.Controls.Add(b15)

        ' ////bonus///
        b16.ColumnSpan = 15
        b16.HorizontalAlign = HorizontalAlign.Right
        b16.Text = "<b><font size=2>" & bonus & "</font></b>"
        brtotal.Controls.Add(b16)

        ' ////TA TOTAL///
        b27.ColumnSpan = 17
        b27.HorizontalAlign = HorizontalAlign.Right
        b27.Text = "<b><font size=2>" & ta_total & "</font></b>"
        brtotal.Controls.Add(b27)



        '///wages_Paid
        b17.ColumnSpan = 28
        b17.HorizontalAlign = HorizontalAlign.Right
        b17.Text = "<b><font size=2>" & wagespaid & "</font></b>"
        brtotal.Controls.Add(b17)
        salarytable.Controls.Add(brtotal)
        Dim last As New TableRow
        Dim last1 As New TableCell
        last1.ColumnSpan = 450

        last1.Text = "<hr>"
        last.Controls.Add(last1)
        salarytable.Controls.Add(last)

        Dim aaw As New TableRow
        aaw.Width = 450
        Dim prepare, prepare1, verify, verify1, approve, approve1 As New TableCell

        prepare.ColumnSpan = 2
        prepare.HorizontalAlign = HorizontalAlign.Center
        prepare.Text = "<font size=2>Prepared By </font>"
        aaw.Controls.Add(prepare)

        prepare1.ColumnSpan = 2
        prepare1.HorizontalAlign = HorizontalAlign.Center
        prepare1.Text = " "
        aaw.Controls.Add(prepare1)

        verify.ColumnSpan = 2
        verify.HorizontalAlign = HorizontalAlign.Center
        verify.Text = "<font size=2>Verified By </font>"
        aaw.Controls.Add(verify)

        verify1.ColumnSpan = 3
        verify1.HorizontalAlign = HorizontalAlign.Center
        verify1.Text = " "
        aaw.Controls.Add(verify1)

        approve.ColumnSpan = 2
        approve.HorizontalAlign = HorizontalAlign.Center
        approve.Text = "<font size=2>Approved By </font>"
        aaw.Controls.Add(approve)

        approve1.ColumnSpan = 450
        approve1.HorizontalAlign = HorizontalAlign.Center
        approve1.Text = ""
        aaw.Controls.Add(approve1)

        salarytable.Controls.Add(aaw)

        Dim foot1 As New TableRow
        Dim foot1a As New TableCell
        foot1a.ColumnSpan = 450
        foot1a.Text = "<hr>"
        foot1.Controls.Add(foot1a)
        salarytable.Controls.Add(foot1)

        Dim space1 As New TableRow
        Dim space1a As New TableCell
        space1a.ColumnSpan = 450
        space1a.Text = " "
        space1.Controls.Add(space1a)
        salarytable.Controls.Add(space1)

        Dim space2 As New TableRow
        Dim space2a As New TableCell
        space2a.ColumnSpan = 450
        space2a.Text = " "
        space2.Controls.Add(space2a)
        salarytable.Controls.Add(space2)
    End Sub
    Sub pagenext()
        'Dim pgebrk As New TableRow
        'pgebrk.Width = 22
        'Dim pgebrk1 As New TableCell
        'pgebrk1.ColumnSpan = 22
        'pgebrk1.HorizontalAlign = HorizontalAlign.Center
        'pgebrk1.Text = "<DIV style=page-break-after:always></DIV>"
        'pgebrk.Controls.Add(pgebrk1)
        'salarytable.Controls.Add(pgebrk)
    End Sub
    Private Function numbering(ByVal a) As Integer

        '    Dim ar As New TableRow
        '    ar.Width = 22
        '    Dim ar1 As New TableCell
        '    ar1.ColumnSpan = 22
        '    ar1.HorizontalAlign = HorizontalAlign.Right
        '    ar1.Text = "<font size=2>Page Number :" & a & "</font>"
        '    ar.Controls.Add(ar1)
        '    salarytable.Controls.Add(ar)
    End Function
End Class


