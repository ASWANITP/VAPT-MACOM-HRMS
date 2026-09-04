Imports System.Data
Imports system.data.oracleclient
Partial Class salaryreport_wage_slip_report_560a62de6805
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    ' Dim b As Integer
    Dim tb As New Table

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' dt1 = oh.ExecuteDataSet("select to_char(to_date(trunc(to_date(" & Request.QueryString("dt") & " ,'dd/mm/yyyy'),'mm'),'dd/mm/yyyy')) from dual").Tables(0)
        'If (Request.QueryString("a") = 1) Then
        '    dt = oh.ExecuteDataSet("select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name,e.emp_code from employee_master e,employ_firm ef,designation_master ds,firm_master f,branch_master b,m_wage w where w.branch_id=b.branch_id  and e.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and b.branch_id=" & Request.QueryString("br") & " and f.firm_id=w.firm_id and e.emp_type=1 union select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name,e.emp_code from employee_master e,employ_firm ef,designation_master ds,firm_master f,before_completion b,m_wage w where w.branch_id=b.old_id    and e.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and b.old_id=" & Request.QueryString("br") & " and f.firm_id=w.firm_id and b.branch_id is null and e.emp_type=1 order by emp_code").Tables(0)
        'End If

        'If (Request.QueryString("a") = 2) Then
        '    dt = oh.ExecuteDataSet("select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name,e.emp_code from employee_master e,employ_firm ef,designation_master ds,firm_master f,m_wage w,branch_master b where w.branch_id=b.branch_id  and e.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and w.firm_id=" & Request.QueryString("fr") & " and f.firm_id=w.firm_id and e.emp_type=1 union select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name,e.emp_code from employee_master e,employ_firm ef,designation_master ds,firm_master f,m_wage w,before_completion b where w.branch_id=b.old_id    and e.emp_code = ef.emp_code  and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and w.firm_id=" & Request.QueryString("fr") & " and f.firm_id=w.firm_id and b.branch_id is null and e.emp_type=1 order by emp_code").Tables(0)
        'End If
        'If (Request.QueryString("a") = 3) Then
        '    dt = oh.ExecuteDataSet("select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name from employee_master e,designation_master ds,employ_firm ef,firm_master f,m_wage w,branch_master b where w.branch_id=b.branch_id  and e.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and e.emp_code=" & Request.QueryString("em") & " and f.firm_id=w.firm_id and e.emp_type=1 union select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name from employee_master e,designation_master ds,firm_master f,employ_firm ef,m_wage w,before_completion b where w.branch_id=b.old_id    and e.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and e.emp_code=" & Request.QueryString("em") & " and f.firm_id=w.firm_id and b.branch_id is null and e.emp_type=1 ").Tables(0)
        'End If
        'If (Request.QueryString("a") = 4) Then
        '    dt = oh.ExecuteDataSet("select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name from employee_master e,designation_master ds,employ_firm ef,firm_master f,branch_master b,m_wage w where w.branch_id=b.branch_id  and e.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and f.firm_id=w.firm_id and f.firm_id=" & Session("firm_id") & " and b.firm_id=f.firm_id and e.emp_type=1 union select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name from employee_master e,designation_master ds,employ_firm ef,firm_master f,before_completion b,m_wage w where w.branch_id=b.old_id    and e.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and f.firm_id=w.firm_id and f.firm_id=" & Session("firm_id") & " and b.firm_id=f.firm_id and b.branch_id is null and e.emp_type=1 order by branch_name").Tables(0)
        'End If
        'If (Request.QueryString("a") = 5) Then
        '    dt = oh.ExecuteDataSet("select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name from employee_master e,designation_master ds,employ_firm ef,firm_master f,m_wage w,branch_master b where w.branch_id=b.branch_id  and e.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and f.firm_id=w.firm_id and f.firm_id=" & Session("firm_id") & " and e.emp_type=1 union select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name from employee_master e,designation_master ds,firm_master f,m_wage w,employ_firm ef,before_completion b where w.branch_id=b.old_id    and e.emp_code = ef.emp_code and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and f.firm_id=w.firm_id and f.firm_id=" & Session("firm_id") & " and b.branch_id is null and e.emp_type=1 order by firm_name").Tables(0)
        'End If

        ' dt1 = oh.ExecuteDataSet("select to_char(to_date(trunc(to_date(" & Request.QueryString("dt") & " ,'dd/mm/yyyy'),'mm'),'dd/mm/yyyy')) from dual").Tables(0)
        'If (Request.QueryString("a") = 1) Then
        '    dt = oh.ExecuteDataSet("select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name,e.emp_code from employee_master e,employ_firm ef,designation_master ds,firm_master f,branch_master b,m_wage w where w.branch_id=b.branch_id  and e.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and b.branch_id=" & Request.QueryString("br") & " and f.firm_id=w.firm_id and e.emp_type=1 union select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name,e.emp_code from employee_master e,employ_firm ef,designation_master ds,firm_master f,before_completion b,m_wage w where w.branch_id=b.old_id    and e.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and b.old_id=" & Request.QueryString("br") & " and f.firm_id=w.firm_id and b.branch_id is null and e.emp_type=1 order by emp_code").Tables(0)
        'End If

        'If (Request.QueryString("a") = 2) Then
        '    dt = oh.ExecuteDataSet("select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name,e.emp_code from employee_master e,employ_firm ef,designation_master ds,firm_master f,m_wage w,branch_master b where w.branch_id=b.branch_id  and e.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and w.firm_id=" & Request.QueryString("fr") & " and f.firm_id=w.firm_id and e.emp_type=1 union select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name,e.emp_code from employee_master e,employ_firm ef,designation_master ds,firm_master f,m_wage w,before_completion b where w.branch_id=b.old_id    and e.emp_code = ef.emp_code  and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and w.firm_id=" & Request.QueryString("fr") & " and f.firm_id=w.firm_id and b.branch_id is null and e.emp_type=1 order by emp_code").Tables(0)
        'End If
        'If (Request.QueryString("a") = 3) Then
        '    dt = oh.ExecuteDataSet("select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name from employee_master e,designation_master ds,employ_firm ef,firm_master f,m_wage w,branch_master b where w.branch_id=b.branch_id  and e.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and e.emp_code=" & Request.QueryString("em") & " and f.firm_id=w.firm_id and e.emp_type=1 union select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name from employee_master e,designation_master ds,firm_master f,employ_firm ef,m_wage w,before_completion b where w.branch_id=b.old_id    and e.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and e.emp_code=" & Request.QueryString("em") & " and f.firm_id=w.firm_id and b.branch_id is null and e.emp_type=1 ").Tables(0)
        'End If
        'If (Request.QueryString("a") = 4) Then
        '    dt = oh.ExecuteDataSet("select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name from employee_master e,designation_master ds,employ_firm ef,firm_master f,branch_master b,m_wage w where w.branch_id=b.branch_id  and e.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and f.firm_id=w.firm_id and f.firm_id=" & Session("firm_id") & " and b.firm_id=f.firm_id and e.emp_type=1 union select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name from employee_master e,designation_master ds,employ_firm ef,firm_master f,before_completion b,m_wage w where w.branch_id=b.old_id    and e.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and f.firm_id=w.firm_id and f.firm_id=" & Session("firm_id") & " and b.firm_id=f.firm_id and b.branch_id is null and e.emp_type=1 order by branch_name").Tables(0)
        'End If
        'If (Request.QueryString("a") = 5) Then
        '    dt = oh.ExecuteDataSet("select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name from employee_master e,designation_master ds,employ_firm ef,firm_master f,m_wage w,branch_master b where w.branch_id=b.branch_id  and e.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and f.firm_id=w.firm_id and f.firm_id=" & Session("firm_id") & " and e.emp_type=1 union select f.firm_name,e.emp_name,w.fat_hus,ds.designation,to_char(trunc(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'),'mm')),to_char(last_day(to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy'))),nvl((w.w_days-w.l_days),0)||'/'||nvl(w.w_days,0),nvl(w.basic_pay,0),nvl(w.vda,0),nvl(w.ovt_wages,0),nvl(w.gross_sal,0),nvl(w.tot_dedu,0),nvl(w.net_pay,0),b.branch_name from employee_master e,designation_master ds,firm_master f,m_wage w,employ_firm ef,before_completion b where w.branch_id=b.old_id    and e.emp_code = ef.emp_code and ef.firm_id = '" & Session("firm_id") & "' and e.emp_code=w.emp_code and w.designation_id=ds.designation_id and w.sal_dt=to_date(" & Request.QueryString("dt") & ") and f.firm_id=w.firm_id and f.firm_id=" & Session("firm_id") & " and b.branch_id is null and e.emp_type=1 order by firm_name").Tables(0)
        'End If
        '==========================
        If Session("firm_id") = 9 Or Session("firm_id") = 35 Then
            If (Request.QueryString("a") = 1) Then
                dt = oh.ExecuteDataSet("select w.fname,w.ename,w.gunme,w.dsgn,w.mnthstart,w.mnthend,w.workdys,w.basal,w.vda,w.ovtwge,w.grssal,w.totded,w.ntpay,w.brnme,w.fxdta,w.alamt,w.arrsal,w.tds,w.esi,w.pf,w.lop,w.othded,w.ecode,w.lic from wage_dtls w where w.brnid=" & Request.QueryString("br") & " and w.fmid='" & Session("firm_id") & "' and w.salcdt=to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy')").Tables(0)
            End If

            If (Request.QueryString("a") = 2) Then
                dt = oh.ExecuteDataSet("select w.fname,w.ename,w.gunme,w.dsgn,w.mnthstart,w.mnthend,w.workdys,w.basal,w.vda,w.ovtwge,w.grssal,w.totded,w.ntpay,w.brnme,w.fxdta,w.alamt,w.arrsal,w.tds,w.esi,w.pf,w.lop,w.othded,w.ecode,w.lic from wage_dtls w where  w.fmid='" & Session("firm_id") & "' and w.salcdt=to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy')").Tables(0)
            End If
            If (Request.QueryString("a") = 3) Then
                dt = oh.ExecuteDataSet("select w.fname,w.ename,w.gunme,w.dsgn,w.mnthstart,w.mnthend,w.workdys,w.basal,w.vda,w.ovtwge,w.grssal,w.totded,w.ntpay,w.brnme,w.fxdta,w.alamt,w.arrsal,w.tds,w.esi,w.pf,w.lop,w.othded,w.ecode,w.lic from wage_dtls w where w.ecode=" & Request.QueryString("em") & "  and w.fmid='" & Session("firm_id") & "' and w.salcdt=to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy')").Tables(0)
            End If
            If (Request.QueryString("a") = 4) Then
                dt = oh.ExecuteDataSet("select w.fname,w.ename,w.gunme,w.dsgn,w.mnthstart,w.mnthend,w.workdys,w.basal,w.vda,w.ovtwge,w.grssal,w.totded,w.ntpay,w.brnme,w.fxdta,w.alamt,w.arrsal,w.tds,w.esi,w.pf,w.lop,w.othded,w.ecode,w.lic from wage_dtls w where  w.fmid='" & Session("firm_id") & "' and w.salcdt=to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy')  order by w.brnme").Tables(0)
            End If
            If (Request.QueryString("a") = 5) Then
                dt = oh.ExecuteDataSet("select w.fname,w.ename,w.gunme,w.dsgn,w.mnthstart,w.mnthend,w.workdys,w.basal,w.vda,w.ovtwge,w.grssal,w.totded,w.ntpay,w.brnme,w.fxdta,w.alamt,w.arrsal,w.tds,w.esi,w.pf,w.lop,w.othded,w.ecode,w.lic from wage_dtls w where  w.fmid='" & Session("firm_id") & "' and w.salcdt=to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy')  order by w.brnme").Tables(0)
            End If




            Dim dr As DataRow

            For Each dr In dt.Rows


                tb.Attributes.Add("width", "90%")
                tb.Attributes.Add("align", "center")

                Dim tr As New TableRow
                Dim tc As New TableCell
                tr.Font.Size = 10
                tc.Attributes.Add("width", "100%")
                tc.ColumnSpan = 10
                tc.HorizontalAlign = HorizontalAlign.Center

                tc.Text = "<font size=3 color=darkblue><b>FORM XIII</b></font>"   'firm_name
                tr.Controls.Add(tc)
                tb.Controls.Add(tr)


                Dim tra As New TableRow
                tra.Font.Size = 10
                Dim tca As New TableCell
                tca.Attributes.Add("width", "100%")
                tca.ColumnSpan = 10
                tca.HorizontalAlign = HorizontalAlign.Center
                tca.Text = "<font size=2 color=darkblue><b></b></font>"   'firm_name
                tra.Controls.Add(tca)
                tb.Controls.Add(tra)

                Dim tr1 As New TableRow
                tr1.Font.Size = 10
                Dim tc1 As New TableCell
                tc1.Attributes.Add("width", "100%")
                tc1.ColumnSpan = 10
                tc1.HorizontalAlign = HorizontalAlign.Center
                tc1.Text = "<font size=2 color=darkblue>WAGE SLIP [SEE RULE 29(2)]</font>"
                tr1.Controls.Add(tc1)
                tb.Controls.Add(tr1)

                Dim tr2 As New TableRow
                Dim tc2 As New TableCell
                tr2.Font.Size = 10
                tc2.Attributes.Add("width", "100%")
                tc2.ColumnSpan = 10
                tc2.HorizontalAlign = HorizontalAlign.Right
                tc2.Text = "<font size=2 color=darkblue>PLACE&nbsp;:" & dr(13) & "</font>"
                tr2.Controls.Add(tc2)
                tb.Controls.Add(tr2)


                Dim tr3 As New TableRow
                Dim tc31 As New TableCell
                tr3.Font.Size = 10
                tc31.Attributes.Add("width", "50%")
                tc31.ColumnSpan = 3
                tc31.HorizontalAlign = HorizontalAlign.Left
                tc31.Text = "<font size=2 color=darkblue>Time&nbsp:" & Format(Date.Now, "hh:mm:ss") & "</font>"
                tr3.Controls.Add(tc31)
                Dim tc4 As New TableCell
                tc4.Attributes.Add("width", "25%")
                tc4.ColumnSpan = 4
                tc4.HorizontalAlign = HorizontalAlign.Center
                tc4.Text = "<font size=2 color=darkblue><b>WAGE&nbsp;SLIP&nbsp;</b></font>"
                tr3.Controls.Add(tc4)
                Dim tc32 As New TableCell
                tc32.Attributes.Add("width", "50%")
                tc32.ColumnSpan = 3
                tc32.HorizontalAlign = HorizontalAlign.Right
                tc32.Text = "<font size=2 color=darkblue>Date&nbsp:" & Format(Date.Now, "dd/MMM/yyyy") & "</font>"
                tr3.Controls.Add(tc32)
                tb.Controls.Add(tr3)

                ' Dim tr4 As New TableRow
                'tr4.Font.Size = 10

                ' tb.Controls.Add(tr4)



                Dim tr5a As New TableRow
                tr5a.Font.Size = 10
                Dim td5a As New TableCell
                td5a.ColumnSpan = 12
                td5a.HorizontalAlign = HorizontalAlign.Center
                td5a.Text = "<hr>"
                tr5a.Controls.Add(td5a)
                tb.Controls.Add(tr5a)

                Dim tr5 As New TableRow
                Dim tc51 As New TableCell
                tr5.Font.Size = 11
                tc51.Attributes.Add("width", "50%")
                tc51.ColumnSpan = 3
                tc51.HorizontalAlign = HorizontalAlign.Left
                tc51.Text = "<font size=2 color=darkblue>NAME OF THE ESTABLISHMENT&nbsp</font>"
                tr5.Controls.Add(tc51)


                Dim tc52a As New TableCell
                tc52a.Attributes.Add("width", "5%")
                tc52a.ColumnSpan = 1
                tc52a.HorizontalAlign = HorizontalAlign.Left
                tc52a.Text = "<font size=2 color=darkblue>-</font>"
                tr5.Controls.Add(tc52a)

                Dim tc52 As New TableCell
                tc52.Attributes.Add("width", "70%")
                tc52.ColumnSpan = 10
                tc52.HorizontalAlign = HorizontalAlign.Left

                tc52.Text = "<font size=2 color=darkblue>" & dr(0) & "</font>"
                tr5.Controls.Add(tc52)
                tb.Controls.Add(tr5)


                Dim tr6 As New TableRow
                Dim tc61 As New TableCell
                tr6.Font.Size = 10
                tc61.Attributes.Add("width", "50%")
                tc61.ColumnSpan = 3
                tc61.HorizontalAlign = HorizontalAlign.Left
                tc61.Text = "<font size=2 color=darkblue>NAME OF EMPLOYEE&nbsp;</font>"
                tr6.Controls.Add(tc61)


                Dim tc62a As New TableCell
                tc62a.Attributes.Add("width", "5%")
                tc62a.HorizontalAlign = HorizontalAlign.Left
                tc62a.Text = "<font size=2 color=darkblue>-</font>"
                tr6.Controls.Add(tc62a)


                Dim tc62 As New TableCell
                tc62.Attributes.Add("width", "70%")
                tc62.ColumnSpan = 7
                tc62.HorizontalAlign = HorizontalAlign.Left
                tc62.Text = "<font size=2 color=darkblue>" & dr(1) & "</font>"
                tr6.Controls.Add(tc62)
                tb.Controls.Add(tr6)

                Dim tre6 As New TableRow
                Dim tc6e1 As New TableCell
                tre6.Font.Size = 10
                tc6e1.Attributes.Add("width", "50%")
                tc6e1.ColumnSpan = 3
                tc6e1.HorizontalAlign = HorizontalAlign.Left
                tc6e1.Text = "<font size=2 color=darkblue>EMPLOYEE CODE&nbsp;</font>"
                tre6.Controls.Add(tc6e1)


                Dim tc62e As New TableCell
                tc62e.Attributes.Add("width", "5%")
                tc62e.HorizontalAlign = HorizontalAlign.Left
                tc62e.Text = "<font size=2 color=darkblue>-</font>"
                tre6.Controls.Add(tc62e)


                Dim tce62e As New TableCell
                tce62e.Attributes.Add("width", "70%")
                tce62e.ColumnSpan = 7
                tce62e.HorizontalAlign = HorizontalAlign.Left
                tce62e.Text = "<font size=2 color=darkblue>" & dr(22) & "</font>"
                tre6.Controls.Add(tce62e)
                tb.Controls.Add(tre6)


                Dim tr5d As New TableRow
                Dim tc51d As New TableCell
                tr5d.Font.Size = 10
                tc51d.Attributes.Add("width", "50%")
                tc51d.ColumnSpan = 3
                tc51d.HorizontalAlign = HorizontalAlign.Left
                tc51d.Text = "<font size=2 color=darkblue>FATHER'S NAME&nbsp;</font>"
                tr5d.Controls.Add(tc51d)

                Dim tc52g As New TableCell
                tc52g.Attributes.Add("width", "5%")

                tc52g.HorizontalAlign = HorizontalAlign.Left
                tc52g.Text = "<font size=2 color=darkblue>-</font>"
                tr5d.Controls.Add(tc52g)


                Dim tc52h As New TableCell
                tc52h.Attributes.Add("width", "70%")
                tc52h.ColumnSpan = 7
                tc52h.HorizontalAlign = HorizontalAlign.Left
                tc52h.Text = "<font size=2 color=darkblue>" & dr(2) & "</font>"
                tr5d.Controls.Add(tc52h)
                tb.Controls.Add(tr5d)



                Dim tr6d As New TableRow
                tr6d.Font.Size = 10
                Dim tc6d As New TableCell
                tc6d.Attributes.Add("width", "50%")
                tc6d.ColumnSpan = 3
                tc6d.HorizontalAlign = HorizontalAlign.Left
                tc6d.Text = "<font size=2 color=darkblue>DESIGNATION&nbsp;</font>"
                tr6d.Controls.Add(tc6d)

                Dim tc6e As New TableCell
                tc6e.Attributes.Add("width", "5%")
                tc6e.HorizontalAlign = HorizontalAlign.Left
                tc6e.Text = "<font size=2 color=darkblue>-</font>"
                tr6d.Controls.Add(tc6e)

                Dim tc6f As New TableCell
                tc6f.Attributes.Add("width", "70%")
                tc6f.ColumnSpan = 7
                tc6f.HorizontalAlign = HorizontalAlign.Left
                tc6f.Text = "<font size=2 color=darkblue>" & dr(3) & "</font>"
                tr6d.Controls.Add(tc6f)
                tb.Controls.Add(tr6d)

                Dim tr7d As New TableRow
                Dim tc7d As New TableCell
                tr7d.Font.Size = 10
                tc7d.Attributes.Add("width", "50%")
                tc7d.ColumnSpan = 3
                tc7d.HorizontalAlign = HorizontalAlign.Left
                tc7d.Text = "<font size=2 color=darkblue>WAGE PERIOD&nbsp;</font>"
                tr7d.Controls.Add(tc7d)

                Dim tc7e As New TableCell
                tc7e.Attributes.Add("width", "5%")
                tc7e.HorizontalAlign = HorizontalAlign.Left
                tc7e.Text = "<font size=2 color=darkblue>-</font>"
                tr7d.Controls.Add(tc7e)

                Dim tc7f As New TableCell
                tc7f.Attributes.Add("width", "70%")
                tc7f.ColumnSpan = 7
                tc7f.HorizontalAlign = HorizontalAlign.Left
                tc7f.Text = "<font size=2 color=darkblue>" & dr(4) & " to " & dr(5) & "</font>"
                tr7d.Controls.Add(tc7f)
                tb.Controls.Add(tr7d)



                Dim tr8d1 As New TableRow
                Dim tc8d1 As New TableCell
                tr8d1.Font.Size = 10
                tc8d1.Attributes.Add("width", "100%")
                tc8d1.ColumnSpan = 11
                tc8d1.HorizontalAlign = HorizontalAlign.Left
                tc8d1.Text = "<font size=2 color=darkblue><u>TOTAL ATTENDANCE</u>&nbsp;</font>"
                tr8d1.Controls.Add(tc8d1)
                tb.Controls.Add(tr8d1)

                Dim tr8d As New TableRow
                Dim tc8d As New TableCell
                tr8d.Font.Size = 10
                tc8d.Attributes.Add("width", "50%")
                tc8d.ColumnSpan = 3
                tc8d.HorizontalAlign = HorizontalAlign.Left
                tc8d.Text = "<font size=2 color=darkblue>UNITS OF WORK DONE&nbsp;</font>"
                tr8d.Controls.Add(tc8d)



                Dim tc8e As New TableCell
                tc8e.Attributes.Add("width", "5%")
                tc8e.HorizontalAlign = HorizontalAlign.Left
                tc8e.Text = "<font size=2 color=darkblue>-</font>"
                tr8d.Controls.Add(tc8e)

                Dim tc8f As New TableCell
                tc8f.Attributes.Add("width", "70%")
                tc8f.ColumnSpan = 7
                tc8f.HorizontalAlign = HorizontalAlign.Left
                tc8f.Text = "<font size=2 color=darkblue>" & dr(6) & "</font>"
                tr8d.Controls.Add(tc8f)
                tb.Controls.Add(tr8d)


                Dim tr8d2 As New TableRow
                Dim tc8d2 As New TableCell
                tr8d2.Font.Size = 10
                tc8d2.Attributes.Add("width", "100%")
                tc8d2.ColumnSpan = 11
                tc8d2.HorizontalAlign = HorizontalAlign.Left
                tc8d2.Text = "<font size=2 color=darkblue><u>RATE OF WAGE PAYABLE:</u>&nbsp;</font>"
                tr8d2.Controls.Add(tc8d2)
                tb.Controls.Add(tr8d2)



                Dim tr9d As New TableRow
                tr9d.Font.Size = 10
                Dim tc9d As New TableCell
                tc9d.Attributes.Add("width", "50%")
                tc9d.ColumnSpan = 3
                tc9d.HorizontalAlign = HorizontalAlign.Left
                tc9d.Text = "<font size=2 color=darkblue>a)&nbsp;BASIC WAGE&nbsp;</font>"
                tr9d.Controls.Add(tc9d)

                Dim tc9e As New TableCell
                tc9e.Attributes.Add("width", "5%")
                tc9e.HorizontalAlign = HorizontalAlign.Left
                tc9e.Text = "<font size=2 color=darkblue>-</font>"
                tr9d.Controls.Add(tc9e)

                Dim tc9f As New TableCell
                tc9f.Attributes.Add("width", "70%")
                tc9f.ColumnSpan = 7
                tc9f.HorizontalAlign = HorizontalAlign.Left
                tc9f.Text = "<font size=2 color=darkblue>" & dr(7) & " </font>"
                tr9d.Controls.Add(tc9f)
                tb.Controls.Add(tr9d)

                Dim tr10d As New TableRow
                Dim tc10d As New TableCell
                tr10d.Font.Size = 10
                tc10d.Attributes.Add("width", "50%")
                tc10d.ColumnSpan = 3
                tc10d.HorizontalAlign = HorizontalAlign.Left
                tc10d.Text = "<font size=2 color=darkblue>b)&nbsp;D.A&nbsp;</font>"
                tr10d.Controls.Add(tc10d)

                Dim tc10e As New TableCell
                tc10e.Attributes.Add("width", "5%")
                tc10e.HorizontalAlign = HorizontalAlign.Left
                tc10e.Text = "<font size=2 color=darkblue>-</font>"
                tr10d.Controls.Add(tc10e)

                Dim tc10f As New TableCell
                tc10f.Attributes.Add("width", "70%")
                tc10f.ColumnSpan = 7
                tc10f.HorizontalAlign = HorizontalAlign.Left
                tc10f.Text = "<font size=2 color=darkblue>" & dr(8) & " </font>"
                tr10d.Controls.Add(tc10f)
                tb.Controls.Add(tr10d)



                Dim tr10fd As New TableRow
                Dim tc10fd As New TableCell
                tr10fd.Font.Size = 10
                tc10fd.Attributes.Add("width", "50%")
                tc10fd.ColumnSpan = 3
                tc10fd.HorizontalAlign = HorizontalAlign.Left
                tc10fd.Text = "<font size=2 color=darkblue>c)&nbsp;FIXED TA&nbsp;</font>"
                tr10fd.Controls.Add(tc10fd)

                Dim tc10fe As New TableCell
                tc10fe.Attributes.Add("width", "5%")
                tc10fe.HorizontalAlign = HorizontalAlign.Left
                tc10fe.Text = "<font size=2 color=darkblue>-</font>"
                tr10fd.Controls.Add(tc10fe)

                Dim tc10ff As New TableCell
                tc10ff.Attributes.Add("width", "70%")
                tc10ff.ColumnSpan = 7
                tc10ff.HorizontalAlign = HorizontalAlign.Left
                tc10ff.Text = "<font size=2 color=darkblue>" & dr(14) & " </font>"
                tr10fd.Controls.Add(tc10ff)
                tb.Controls.Add(tr10fd)

                Dim tr10Ad As New TableRow
                Dim tc10Ad As New TableCell
                tr10Ad.Font.Size = 10
                tc10Ad.Attributes.Add("width", "50%")
                tc10Ad.ColumnSpan = 3
                tc10Ad.HorizontalAlign = HorizontalAlign.Left
                tc10Ad.Text = "<font size=2 color=darkblue>d)&nbsp;ALLOWANCES&nbsp;</font>"
                tr10Ad.Controls.Add(tc10Ad)

                Dim tc10Ae As New TableCell
                tc10Ae.Attributes.Add("width", "5%")
                tc10Ae.HorizontalAlign = HorizontalAlign.Left
                tc10Ae.Text = "<font size=2 color=darkblue>-</font>"
                tr10Ad.Controls.Add(tc10Ae)

                Dim tc10Af As New TableCell
                tc10Af.Attributes.Add("width", "70%")
                tc10Af.ColumnSpan = 7
                tc10Af.HorizontalAlign = HorizontalAlign.Left
                tc10Af.Text = "<font size=2 color=darkblue>" & dr(15) & " </font>"
                tr10Ad.Controls.Add(tc10Af)
                tb.Controls.Add(tr10Ad)

                Dim tr10ARd As New TableRow
                Dim tc10ARd As New TableCell
                tr10ARd.Font.Size = 10
                tc10ARd.Attributes.Add("width", "50%")
                tc10ARd.ColumnSpan = 3
                tc10ARd.HorizontalAlign = HorizontalAlign.Left
                tc10ARd.Text = "<font size=2 color=darkblue>e)&nbsp;ARREAR&nbsp;</font>"
                tr10ARd.Controls.Add(tc10ARd)

                Dim tc10ARe As New TableCell
                tc10ARe.Attributes.Add("width", "5%")
                tc10ARe.HorizontalAlign = HorizontalAlign.Left
                tc10ARe.Text = "<font size=2 color=darkblue>-</font>"
                tr10ARd.Controls.Add(tc10ARe)

                Dim tc10ARf As New TableCell
                tc10ARf.Attributes.Add("width", "70%")
                tc10ARf.ColumnSpan = 7
                tc10ARf.HorizontalAlign = HorizontalAlign.Left
                tc10ARf.Text = "<font size=2 color=darkblue>" & dr(16) & " </font>"
                tr10ARd.Controls.Add(tc10ARf)
                tb.Controls.Add(tr10ARd)


                Dim tr15d As New TableRow
                Dim tc15d As New TableCell
                tr15d.Font.Size = 10
                tc15d.Attributes.Add("width", "50%")
                tc15d.ColumnSpan = 3
                tc15d.HorizontalAlign = HorizontalAlign.Left
                tc15d.Text = "<font size=2 color=darkblue>f)&nbsp;OVERTIME WAGE&nbsp;</font>"
                tr15d.Controls.Add(tc15d)

                Dim tc15e As New TableCell
                tc15e.Attributes.Add("width", "5%")
                tc15e.HorizontalAlign = HorizontalAlign.Left
                tc15e.Text = "<font size=2 color=darkblue>-</font>"
                tr15d.Controls.Add(tc15e)

                Dim tc15ff As New TableCell
                tc15ff.Attributes.Add("width", "70%")
                tc15ff.ColumnSpan = 7
                tc15ff.HorizontalAlign = HorizontalAlign.Left
                tc15ff.Text = "<font size=2 color=darkblue>" & dr(9) & " </font>"
                tr15d.Controls.Add(tc15ff)
                tb.Controls.Add(tr15d)



                Dim tr16d As New TableRow
                Dim tc16d As New TableCell
                tr16d.Font.Size = 10
                tc16d.Attributes.Add("width", "50%")
                tc16d.ColumnSpan = 3
                tc16d.HorizontalAlign = HorizontalAlign.Left
                tc16d.Text = "<font size=2 color=darkblue>GROSS WAGES PAYABLE&nbsp;</font>"
                tr16d.Controls.Add(tc16d)

                Dim tc16e As New TableCell
                tc16e.Attributes.Add("width", "5%")
                tc16e.HorizontalAlign = HorizontalAlign.Left
                tc16e.Text = "<font size=2 color=darkblue>-</font>"
                tr16d.Controls.Add(tc16e)


                Dim tc16f As New TableCell
                tc16f.Attributes.Add("width", "70%")
                tc16f.ColumnSpan = 7
                tc16f.HorizontalAlign = HorizontalAlign.Left
                tc16f.Text = "<font size=2 color=darkblue>" & dr(10) & "  </font>"
                tr16d.Controls.Add(tc16f)
                tb.Controls.Add(tr16d)


                Dim tr8d21 As New TableRow
                Dim tc8d21 As New TableCell
                tr8d21.Font.Size = 10
                tc8d21.Attributes.Add("width", "100%")
                tc8d21.ColumnSpan = 11
                tc8d21.HorizontalAlign = HorizontalAlign.Left
                tc8d21.Text = "<font size=2 color=darkblue><u>DEDUCTIONS:</u>&nbsp;</font>"
                tr8d21.Controls.Add(tc8d21)
                tb.Controls.Add(tr8d21)


                Dim trdt As New TableRow
                Dim tcdt As New TableCell
                trdt.Font.Size = 10
                tcdt.Attributes.Add("width", "50%")
                tcdt.ColumnSpan = 3
                tcdt.HorizontalAlign = HorizontalAlign.Left
                tcdt.Text = "<font size=2 color=darkblue>a)&nbsp;TDS&nbsp;</font>"
                trdt.Controls.Add(tcdt)

                Dim tcte As New TableCell
                tcte.Attributes.Add("width", "5%")
                tcte.HorizontalAlign = HorizontalAlign.Left
                tcte.Text = "<font size=2 color=darkblue>-</font>"
                trdt.Controls.Add(tcte)

                Dim tctf As New TableCell
                tctf.Attributes.Add("width", "70%")
                tctf.ColumnSpan = 7
                tctf.HorizontalAlign = HorizontalAlign.Left
                tctf.Text = "<font size=2 color=darkblue>" & dr(17) & " </font>"
                trdt.Controls.Add(tctf)
                tb.Controls.Add(trdt)


                Dim trdte As New TableRow
                Dim tcdte As New TableCell
                trdte.Font.Size = 10
                tcdte.Attributes.Add("width", "50%")
                tcdte.ColumnSpan = 3
                tcdte.HorizontalAlign = HorizontalAlign.Left
                tcdte.Text = "<font size=2 color=darkblue>b)&nbsp;ESI&nbsp;</font>"
                trdte.Controls.Add(tcdte)

                Dim tcteee As New TableCell
                tcteee.Attributes.Add("width", "5%")
                tcteee.HorizontalAlign = HorizontalAlign.Left
                tcteee.Text = "<font size=2 color=darkblue>-</font>"
                trdte.Controls.Add(tcteee)

                Dim tctfe As New TableCell
                tctfe.Attributes.Add("width", "70%")
                tctfe.ColumnSpan = 7
                tctfe.HorizontalAlign = HorizontalAlign.Left
                tctfe.Text = "<font size=2 color=darkblue>" & dr(18) & " </font>"
                trdte.Controls.Add(tctfe)
                tb.Controls.Add(trdte)

                Dim trdpe As New TableRow
                Dim tcdpe As New TableCell
                trdpe.Font.Size = 10
                tcdpe.Attributes.Add("width", "50%")
                tcdpe.ColumnSpan = 3
                tcdpe.HorizontalAlign = HorizontalAlign.Left
                tcdpe.Text = "<font size=2 color=darkblue>c)&nbsp;PF&nbsp;</font>"
                trdpe.Controls.Add(tcdpe)

                Dim tctpe As New TableCell
                tctpe.Attributes.Add("width", "5%")
                tctpe.HorizontalAlign = HorizontalAlign.Left
                tctpe.Text = "<font size=2 color=darkblue>-</font>"
                trdpe.Controls.Add(tctpe)

                Dim tcpf As New TableCell
                tcpf.Attributes.Add("width", "70%")
                tcpf.ColumnSpan = 7
                tcpf.HorizontalAlign = HorizontalAlign.Left
                tcpf.Text = "<font size=2 color=darkblue>" & dr(19) & " </font>"
                trdpe.Controls.Add(tcpf)
                tb.Controls.Add(trdpe)

                Dim trdle As New TableRow
                Dim tcdle As New TableCell
                trdle.Font.Size = 10
                tcdle.Attributes.Add("width", "50%")
                tcdle.ColumnSpan = 3
                tcdle.HorizontalAlign = HorizontalAlign.Left
                tcdle.Text = "<font size=2 color=darkblue>d)&nbsp;LOP&nbsp;</font>"
                trdle.Controls.Add(tcdle)

                Dim tctle As New TableCell
                tctle.Attributes.Add("width", "5%")
                tctle.HorizontalAlign = HorizontalAlign.Left
                tctle.Text = "<font size=2 color=darkblue>-</font>"
                trdle.Controls.Add(tctle)

                Dim tclf As New TableCell
                tclf.Attributes.Add("width", "70%")
                tclf.ColumnSpan = 7
                tclf.HorizontalAlign = HorizontalAlign.Left
                tclf.Text = "<font size=2 color=darkblue>" & dr(20) & " </font>"
                trdle.Controls.Add(tclf)
                tb.Controls.Add(trdle)
                '-------------
                Dim trdl1 As New TableRow
                Dim tcdl1 As New TableCell
                trdl1.Font.Size = 10
                tcdl1.Attributes.Add("width", "50%")
                tcdl1.ColumnSpan = 3
                tcdl1.HorizontalAlign = HorizontalAlign.Left
                tcdl1.Text = "<font size=2 color=darkblue>e)&nbsp;LIC&nbsp;</font>"
                trdl1.Controls.Add(tcdl1)

                Dim tctl1 As New TableCell
                tctl1.Attributes.Add("width", "5%")
                tctl1.HorizontalAlign = HorizontalAlign.Left
                tctl1.Text = "<font size=2 color=darkblue>-</font>"
                trdl1.Controls.Add(tctl1)

                Dim tcl1 As New TableCell
                tcl1.Attributes.Add("width", "70%")
                tcl1.ColumnSpan = 7
                tcl1.HorizontalAlign = HorizontalAlign.Left
                tcl1.Text = "<font size=2 color=darkblue>" & dr(23) & " </font>"
                trdl1.Controls.Add(tcl1)
                tb.Controls.Add(trdl1)
                '-------------

                Dim trdoe As New TableRow
                Dim tcdoe As New TableCell
                trdoe.Font.Size = 10
                tcdoe.Attributes.Add("width", "50%")
                tcdoe.ColumnSpan = 3
                tcdoe.HorizontalAlign = HorizontalAlign.Left
                tcdoe.Text = "<font size=2 color=darkblue>f)&nbsp;OTHER&nbsp;</font>"
                trdoe.Controls.Add(tcdoe)

                Dim tctoe As New TableCell
                tctoe.Attributes.Add("width", "5%")
                tctoe.HorizontalAlign = HorizontalAlign.Left
                tctoe.Text = "<font size=2 color=darkblue>-</font>"
                trdoe.Controls.Add(tctoe)

                Dim tcof As New TableCell
                tcof.Attributes.Add("width", "70%")
                tcof.ColumnSpan = 7
                tcof.HorizontalAlign = HorizontalAlign.Left
                tcof.Text = "<font size=2 color=darkblue>" & dr(21) & " </font>"
                trdoe.Controls.Add(tcof)
                tb.Controls.Add(trdoe)

                Dim tr16d1 As New TableRow
                Dim tc16d1 As New TableCell
                tr16d1.Font.Size = 10
                tc16d1.Attributes.Add("width", "50%")
                tc16d1.ColumnSpan = 3
                tc16d1.HorizontalAlign = HorizontalAlign.Left
                tc16d1.Text = "<font size=2 color=darkblue>TOTAL DEDUCTIONS&nbsp;</font>"
                tr16d1.Controls.Add(tc16d1)

                Dim tc16e1 As New TableCell
                tc16e1.Attributes.Add("width", "5%")
                tc16e1.HorizontalAlign = HorizontalAlign.Left
                tc16e1.Text = "<font size=2 color=darkblue>-</font>"
                tr16d1.Controls.Add(tc16e1)


                Dim tc16f1 As New TableCell
                tc16f1.Attributes.Add("width", "70%")
                tc16f1.ColumnSpan = 7
                tc16f1.HorizontalAlign = HorizontalAlign.Left
                tc16f1.Text = "<font size=2 color=darkblue>" & dr(11) & "  </font>"
                tr16d1.Controls.Add(tc16f1)
                tb.Controls.Add(tr16d1)



                Dim tr16d2 As New TableRow
                Dim tc16d2 As New TableCell
                tr16d2.Font.Size = 10
                tc16d2.Attributes.Add("width", "50%")
                tc16d2.ColumnSpan = 3
                tc16d2.HorizontalAlign = HorizontalAlign.Left
                tc16d2.Text = "<font size=2 color=darkblue>NET WAGES PAID&nbsp;</font>"
                tr16d2.Controls.Add(tc16d2)

                Dim tc16e2 As New TableCell
                tc16e2.Attributes.Add("width", "5%")
                tc16e2.HorizontalAlign = HorizontalAlign.Left
                tc16e2.Text = "<font size=2 color=darkblue>-</font>"
                tr16d2.Controls.Add(tc16e2)


                Dim tc16f2 As New TableCell
                tc16f2.Attributes.Add("width", "70%")
                tc16f2.ColumnSpan = 7
                tc16f2.HorizontalAlign = HorizontalAlign.Left
                tc16f2.Text = "<font size=2 color=darkblue>" & dr(12) & "  </font>"
                tr16d2.Controls.Add(tc16f2)
                tb.Controls.Add(tr16d2)




                Dim tr16d3 As New TableRow
                tr16d3.Width = 10
                Dim tc16d3 As New TableCell
                tr16d3.Font.Size = 10
                tc16d3.Attributes.Add("width", "50%")
                tc16d3.ColumnSpan = 3
                tc16d3.HorizontalAlign = HorizontalAlign.Left
                tc16d3.Text = "<font size=2 color=darkblue><BR><BR><I>PAY-IN-CHARGE&nbsp;(SIGNATURE)</I></</font>"
                tr16d3.Controls.Add(tc16d3)

                Dim tc16e3 As New TableCell
                tc16e3.Attributes.Add("width", "5%")
                tc16e3.HorizontalAlign = HorizontalAlign.Center
                tc16e3.Text = ""
                tr16d3.Controls.Add(tc16e3)

                Dim tc16f3 As New TableCell
                tc16f3.Attributes.Add("width", "70%")
                tc16f3.ColumnSpan = 7
                tc16f3.HorizontalAlign = HorizontalAlign.Right
                tc16f3.Text = "<font size=2 color=darkblue><BR><BR><I>EMPLOYEE'S&nbsp;SIGNATURE   / THUMB-IMPRESSION </I></font>"
                tr16d3.Controls.Add(tc16f3)
                tb.Controls.Add(tr16d3)

                Dim t17d As New TableRow
                Dim qq17d As New TableCell
                t17d.Font.Size = 10
                qq17d.Attributes.Add("width", "125%")
                qq17d.ColumnSpan = 10
                qq17d.HorizontalAlign = HorizontalAlign.Left
                qq17d.Text = "************************************************************************************************<BR> "
                t17d.Controls.Add(qq17d)
                tb.Controls.Add(t17d)
                pagenext()
            Next
            Me.Panel1.Controls.Add(tb)
        Else
            '==========================
            If (Request.QueryString("a") = 1) Then
                dt = oh.ExecuteDataSet("select w.fname,w.ename,w.gunme,w.dsgn,w.mnthstart,w.mnthend,w.workdys,w.basal,w.vda,w.ovtwge,w.grssal,w.totded,w.ntpay,w.brnme,w.fxdta,w.alamt,w.arrsal,w.tds,w.esi,w.pf,w.lop,w.othded,w.ecode from wage_dtls w where w.brnid=" & Request.QueryString("br") & " and w.fmid='" & Session("firm_id") & "' and w.salcdt=to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy')").Tables(0)
            End If

            If (Request.QueryString("a") = 2) Then
                dt = oh.ExecuteDataSet("select w.fname,w.ename,w.gunme,w.dsgn,w.mnthstart,w.mnthend,w.workdys,w.basal,w.vda,w.ovtwge,w.grssal,w.totded,w.ntpay,w.brnme,w.fxdta,w.alamt,w.arrsal,w.tds,w.esi,w.pf,w.lop,w.othded,w.ecode from wage_dtls w where  w.fmid='" & Session("firm_id") & "' and w.salcdt=to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy')").Tables(0)
            End If
            If (Request.QueryString("a") = 3) Then
                dt = oh.ExecuteDataSet("select w.fname,w.ename,w.gunme,w.dsgn,w.mnthstart,w.mnthend,w.workdys,w.basal,w.vda,w.ovtwge,w.grssal,w.totded,w.ntpay,w.brnme,w.fxdta,w.alamt,w.arrsal,w.tds,w.esi,w.pf,w.lop,w.othded,w.ecode from wage_dtls w where w.ecode=" & Request.QueryString("em") & "  and w.fmid='" & Session("firm_id") & "' and w.salcdt=to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy')").Tables(0)
            End If
            If (Request.QueryString("a") = 4) Then
                dt = oh.ExecuteDataSet("select w.fname,w.ename,w.gunme,w.dsgn,w.mnthstart,w.mnthend,w.workdys,w.basal,w.vda,w.ovtwge,w.grssal,w.totded,w.ntpay,w.brnme,w.fxdta,w.alamt,w.arrsal,w.tds,w.esi,w.pf,w.lop,w.othded,w.ecode from wage_dtls w where  w.fmid='" & Session("firm_id") & "' and w.salcdt=to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy')  order by w.brnme").Tables(0)
            End If
            If (Request.QueryString("a") = 5) Then
                dt = oh.ExecuteDataSet("select w.fname,w.ename,w.gunme,w.dsgn,w.mnthstart,w.mnthend,w.workdys,w.basal,w.vda,w.ovtwge,w.grssal,w.totded,w.ntpay,w.brnme,w.fxdta,w.alamt,w.arrsal,w.tds,w.esi,w.pf,w.lop,w.othded,w.ecode from wage_dtls w where  w.fmid='" & Session("firm_id") & "' and w.salcdt=to_date(" & Request.QueryString("dt") & ",'dd/mm/yyyy')  order by w.brnme").Tables(0)
            End If




            Dim dr As DataRow

            For Each dr In dt.Rows


                tb.Attributes.Add("width", "90%")
                tb.Attributes.Add("align", "center")

                Dim tr As New TableRow
                Dim tc As New TableCell
                tr.Font.Size = 10
                tc.Attributes.Add("width", "100%")
                tc.ColumnSpan = 10
                tc.HorizontalAlign = HorizontalAlign.Center

                tc.Text = "<font size=3 color=darkblue><b>FORM XIII</b></font>"   'firm_name
                tr.Controls.Add(tc)
                tb.Controls.Add(tr)


                Dim tra As New TableRow
                tra.Font.Size = 10
                Dim tca As New TableCell
                tca.Attributes.Add("width", "100%")
                tca.ColumnSpan = 10
                tca.HorizontalAlign = HorizontalAlign.Center
                tca.Text = "<font size=2 color=darkblue><b></b></font>"   'firm_name
                tra.Controls.Add(tca)
                tb.Controls.Add(tra)

                Dim tr1 As New TableRow
                tr1.Font.Size = 10
                Dim tc1 As New TableCell
                tc1.Attributes.Add("width", "100%")
                tc1.ColumnSpan = 10
                tc1.HorizontalAlign = HorizontalAlign.Center
                tc1.Text = "<font size=2 color=darkblue>WAGE SLIP [SEE RULE 29(2)]</font>"
                tr1.Controls.Add(tc1)
                tb.Controls.Add(tr1)

                Dim tr2 As New TableRow
                Dim tc2 As New TableCell
                tr2.Font.Size = 10
                tc2.Attributes.Add("width", "100%")
                tc2.ColumnSpan = 10
                tc2.HorizontalAlign = HorizontalAlign.Right
                tc2.Text = "<font size=2 color=darkblue>PLACE&nbsp;:" & dr(13) & "</font>"
                tr2.Controls.Add(tc2)
                tb.Controls.Add(tr2)


                Dim tr3 As New TableRow
                Dim tc31 As New TableCell
                tr3.Font.Size = 10
                tc31.Attributes.Add("width", "50%")
                tc31.ColumnSpan = 3
                tc31.HorizontalAlign = HorizontalAlign.Left
                tc31.Text = "<font size=2 color=darkblue>Time&nbsp:" & Format(Date.Now, "hh:mm:ss") & "</font>"
                tr3.Controls.Add(tc31)
                Dim tc4 As New TableCell
                tc4.Attributes.Add("width", "25%")
                tc4.ColumnSpan = 4
                tc4.HorizontalAlign = HorizontalAlign.Center
                tc4.Text = "<font size=2 color=darkblue><b>WAGE&nbsp;SLIP&nbsp;</b></font>"
                tr3.Controls.Add(tc4)
                Dim tc32 As New TableCell
                tc32.Attributes.Add("width", "50%")
                tc32.ColumnSpan = 3
                tc32.HorizontalAlign = HorizontalAlign.Right
                tc32.Text = "<font size=2 color=darkblue>Date&nbsp:" & Format(Date.Now, "dd/MMM/yyyy") & "</font>"
                tr3.Controls.Add(tc32)
                tb.Controls.Add(tr3)

                ' Dim tr4 As New TableRow
                'tr4.Font.Size = 10

                ' tb.Controls.Add(tr4)



                Dim tr5a As New TableRow
                tr5a.Font.Size = 10
                Dim td5a As New TableCell
                td5a.ColumnSpan = 12
                td5a.HorizontalAlign = HorizontalAlign.Center
                td5a.Text = "<hr>"
                tr5a.Controls.Add(td5a)
                tb.Controls.Add(tr5a)

                Dim tr5 As New TableRow
                Dim tc51 As New TableCell
                tr5.Font.Size = 11
                tc51.Attributes.Add("width", "50%")
                tc51.ColumnSpan = 3
                tc51.HorizontalAlign = HorizontalAlign.Left
                tc51.Text = "<font size=2 color=darkblue>NAME OF THE ESTABLISHMENT&nbsp</font>"
                tr5.Controls.Add(tc51)


                Dim tc52a As New TableCell
                tc52a.Attributes.Add("width", "5%")
                tc52a.ColumnSpan = 1
                tc52a.HorizontalAlign = HorizontalAlign.Left
                tc52a.Text = "<font size=2 color=darkblue>-</font>"
                tr5.Controls.Add(tc52a)

                Dim tc52 As New TableCell
                tc52.Attributes.Add("width", "70%")
                tc52.ColumnSpan = 10
                tc52.HorizontalAlign = HorizontalAlign.Left

                tc52.Text = "<font size=2 color=darkblue>" & dr(0) & "</font>"
                tr5.Controls.Add(tc52)
                tb.Controls.Add(tr5)


                Dim tr6 As New TableRow
                Dim tc61 As New TableCell
                tr6.Font.Size = 10
                tc61.Attributes.Add("width", "50%")
                tc61.ColumnSpan = 3
                tc61.HorizontalAlign = HorizontalAlign.Left
                tc61.Text = "<font size=2 color=darkblue>NAME OF EMPLOYEE&nbsp;</font>"
                tr6.Controls.Add(tc61)


                Dim tc62a As New TableCell
                tc62a.Attributes.Add("width", "5%")
                tc62a.HorizontalAlign = HorizontalAlign.Left
                tc62a.Text = "<font size=2 color=darkblue>-</font>"
                tr6.Controls.Add(tc62a)


                Dim tc62 As New TableCell
                tc62.Attributes.Add("width", "70%")
                tc62.ColumnSpan = 7
                tc62.HorizontalAlign = HorizontalAlign.Left
                tc62.Text = "<font size=2 color=darkblue>" & dr(1) & "</font>"
                tr6.Controls.Add(tc62)
                tb.Controls.Add(tr6)

                Dim tre6 As New TableRow
                Dim tc6e1 As New TableCell
                tre6.Font.Size = 10
                tc6e1.Attributes.Add("width", "50%")
                tc6e1.ColumnSpan = 3
                tc6e1.HorizontalAlign = HorizontalAlign.Left
                tc6e1.Text = "<font size=2 color=darkblue>EMPLOYEE CODE&nbsp;</font>"
                tre6.Controls.Add(tc6e1)


                Dim tc62e As New TableCell
                tc62e.Attributes.Add("width", "5%")
                tc62e.HorizontalAlign = HorizontalAlign.Left
                tc62e.Text = "<font size=2 color=darkblue>-</font>"
                tre6.Controls.Add(tc62e)


                Dim tce62e As New TableCell
                tce62e.Attributes.Add("width", "70%")
                tce62e.ColumnSpan = 7
                tce62e.HorizontalAlign = HorizontalAlign.Left
                tce62e.Text = "<font size=2 color=darkblue>" & dr(22) & "</font>"
                tre6.Controls.Add(tce62e)
                tb.Controls.Add(tre6)


                Dim tr5d As New TableRow
                Dim tc51d As New TableCell
                tr5d.Font.Size = 10
                tc51d.Attributes.Add("width", "50%")
                tc51d.ColumnSpan = 3
                tc51d.HorizontalAlign = HorizontalAlign.Left
                tc51d.Text = "<font size=2 color=darkblue>FATHER'S NAME&nbsp;</font>"
                tr5d.Controls.Add(tc51d)

                Dim tc52g As New TableCell
                tc52g.Attributes.Add("width", "5%")

                tc52g.HorizontalAlign = HorizontalAlign.Left
                tc52g.Text = "<font size=2 color=darkblue>-</font>"
                tr5d.Controls.Add(tc52g)


                Dim tc52h As New TableCell
                tc52h.Attributes.Add("width", "70%")
                tc52h.ColumnSpan = 7
                tc52h.HorizontalAlign = HorizontalAlign.Left
                tc52h.Text = "<font size=2 color=darkblue>" & dr(2) & "</font>"
                tr5d.Controls.Add(tc52h)
                tb.Controls.Add(tr5d)



                Dim tr6d As New TableRow
                tr6d.Font.Size = 10
                Dim tc6d As New TableCell
                tc6d.Attributes.Add("width", "50%")
                tc6d.ColumnSpan = 3
                tc6d.HorizontalAlign = HorizontalAlign.Left
                tc6d.Text = "<font size=2 color=darkblue>DESIGNATION&nbsp;</font>"
                tr6d.Controls.Add(tc6d)

                Dim tc6e As New TableCell
                tc6e.Attributes.Add("width", "5%")
                tc6e.HorizontalAlign = HorizontalAlign.Left
                tc6e.Text = "<font size=2 color=darkblue>-</font>"
                tr6d.Controls.Add(tc6e)

                Dim tc6f As New TableCell
                tc6f.Attributes.Add("width", "70%")
                tc6f.ColumnSpan = 7
                tc6f.HorizontalAlign = HorizontalAlign.Left
                tc6f.Text = "<font size=2 color=darkblue>" & dr(3) & "</font>"
                tr6d.Controls.Add(tc6f)
                tb.Controls.Add(tr6d)

                Dim tr7d As New TableRow
                Dim tc7d As New TableCell
                tr7d.Font.Size = 10
                tc7d.Attributes.Add("width", "50%")
                tc7d.ColumnSpan = 3
                tc7d.HorizontalAlign = HorizontalAlign.Left
                tc7d.Text = "<font size=2 color=darkblue>WAGE PERIOD&nbsp;</font>"
                tr7d.Controls.Add(tc7d)

                Dim tc7e As New TableCell
                tc7e.Attributes.Add("width", "5%")
                tc7e.HorizontalAlign = HorizontalAlign.Left
                tc7e.Text = "<font size=2 color=darkblue>-</font>"
                tr7d.Controls.Add(tc7e)

                Dim tc7f As New TableCell
                tc7f.Attributes.Add("width", "70%")
                tc7f.ColumnSpan = 7
                tc7f.HorizontalAlign = HorizontalAlign.Left
                tc7f.Text = "<font size=2 color=darkblue>" & dr(4) & " to " & dr(5) & "</font>"
                tr7d.Controls.Add(tc7f)
                tb.Controls.Add(tr7d)



                Dim tr8d1 As New TableRow
                Dim tc8d1 As New TableCell
                tr8d1.Font.Size = 10
                tc8d1.Attributes.Add("width", "100%")
                tc8d1.ColumnSpan = 11
                tc8d1.HorizontalAlign = HorizontalAlign.Left
                tc8d1.Text = "<font size=2 color=darkblue><u>TOTAL ATTENDANCE</u>&nbsp;</font>"
                tr8d1.Controls.Add(tc8d1)
                tb.Controls.Add(tr8d1)

                Dim tr8d As New TableRow
                Dim tc8d As New TableCell
                tr8d.Font.Size = 10
                tc8d.Attributes.Add("width", "50%")
                tc8d.ColumnSpan = 3
                tc8d.HorizontalAlign = HorizontalAlign.Left
                tc8d.Text = "<font size=2 color=darkblue>UNITS OF WORK DONE&nbsp;</font>"
                tr8d.Controls.Add(tc8d)



                Dim tc8e As New TableCell
                tc8e.Attributes.Add("width", "5%")
                tc8e.HorizontalAlign = HorizontalAlign.Left
                tc8e.Text = "<font size=2 color=darkblue>-</font>"
                tr8d.Controls.Add(tc8e)

                Dim tc8f As New TableCell
                tc8f.Attributes.Add("width", "70%")
                tc8f.ColumnSpan = 7
                tc8f.HorizontalAlign = HorizontalAlign.Left
                tc8f.Text = "<font size=2 color=darkblue>" & dr(6) & "</font>"
                tr8d.Controls.Add(tc8f)
                tb.Controls.Add(tr8d)


                Dim tr8d2 As New TableRow
                Dim tc8d2 As New TableCell
                tr8d2.Font.Size = 10
                tc8d2.Attributes.Add("width", "100%")
                tc8d2.ColumnSpan = 11
                tc8d2.HorizontalAlign = HorizontalAlign.Left
                tc8d2.Text = "<font size=2 color=darkblue><u>RATE OF WAGE PAYABLE:</u>&nbsp;</font>"
                tr8d2.Controls.Add(tc8d2)
                tb.Controls.Add(tr8d2)



                Dim tr9d As New TableRow
                tr9d.Font.Size = 10
                Dim tc9d As New TableCell
                tc9d.Attributes.Add("width", "50%")
                tc9d.ColumnSpan = 3
                tc9d.HorizontalAlign = HorizontalAlign.Left
                tc9d.Text = "<font size=2 color=darkblue>a)&nbsp;BASIC WAGE&nbsp;</font>"
                tr9d.Controls.Add(tc9d)

                Dim tc9e As New TableCell
                tc9e.Attributes.Add("width", "5%")
                tc9e.HorizontalAlign = HorizontalAlign.Left
                tc9e.Text = "<font size=2 color=darkblue>-</font>"
                tr9d.Controls.Add(tc9e)

                Dim tc9f As New TableCell
                tc9f.Attributes.Add("width", "70%")
                tc9f.ColumnSpan = 7
                tc9f.HorizontalAlign = HorizontalAlign.Left
                tc9f.Text = "<font size=2 color=darkblue>" & dr(7) & " </font>"
                tr9d.Controls.Add(tc9f)
                tb.Controls.Add(tr9d)

                Dim tr10d As New TableRow
                Dim tc10d As New TableCell
                tr10d.Font.Size = 10
                tc10d.Attributes.Add("width", "50%")
                tc10d.ColumnSpan = 3
                tc10d.HorizontalAlign = HorizontalAlign.Left
                tc10d.Text = "<font size=2 color=darkblue>b)&nbsp;D.A&nbsp;</font>"
                tr10d.Controls.Add(tc10d)

                Dim tc10e As New TableCell
                tc10e.Attributes.Add("width", "5%")
                tc10e.HorizontalAlign = HorizontalAlign.Left
                tc10e.Text = "<font size=2 color=darkblue>-</font>"
                tr10d.Controls.Add(tc10e)

                Dim tc10f As New TableCell
                tc10f.Attributes.Add("width", "70%")
                tc10f.ColumnSpan = 7
                tc10f.HorizontalAlign = HorizontalAlign.Left
                tc10f.Text = "<font size=2 color=darkblue>" & dr(8) & " </font>"
                tr10d.Controls.Add(tc10f)
                tb.Controls.Add(tr10d)



                Dim tr10fd As New TableRow
                Dim tc10fd As New TableCell
                tr10fd.Font.Size = 10
                tc10fd.Attributes.Add("width", "50%")
                tc10fd.ColumnSpan = 3
                tc10fd.HorizontalAlign = HorizontalAlign.Left
                tc10fd.Text = "<font size=2 color=darkblue>c)&nbsp;FIXED TA&nbsp;</font>"
                tr10fd.Controls.Add(tc10fd)

                Dim tc10fe As New TableCell
                tc10fe.Attributes.Add("width", "5%")
                tc10fe.HorizontalAlign = HorizontalAlign.Left
                tc10fe.Text = "<font size=2 color=darkblue>-</font>"
                tr10fd.Controls.Add(tc10fe)

                Dim tc10ff As New TableCell
                tc10ff.Attributes.Add("width", "70%")
                tc10ff.ColumnSpan = 7
                tc10ff.HorizontalAlign = HorizontalAlign.Left
                tc10ff.Text = "<font size=2 color=darkblue>" & dr(14) & " </font>"
                tr10fd.Controls.Add(tc10ff)
                tb.Controls.Add(tr10fd)

                Dim tr10Ad As New TableRow
                Dim tc10Ad As New TableCell
                tr10Ad.Font.Size = 10
                tc10Ad.Attributes.Add("width", "50%")
                tc10Ad.ColumnSpan = 3
                tc10Ad.HorizontalAlign = HorizontalAlign.Left
                tc10Ad.Text = "<font size=2 color=darkblue>d)&nbsp;ALLOWANCES&nbsp;</font>"
                tr10Ad.Controls.Add(tc10Ad)

                Dim tc10Ae As New TableCell
                tc10Ae.Attributes.Add("width", "5%")
                tc10Ae.HorizontalAlign = HorizontalAlign.Left
                tc10Ae.Text = "<font size=2 color=darkblue>-</font>"
                tr10Ad.Controls.Add(tc10Ae)

                Dim tc10Af As New TableCell
                tc10Af.Attributes.Add("width", "70%")
                tc10Af.ColumnSpan = 7
                tc10Af.HorizontalAlign = HorizontalAlign.Left
                tc10Af.Text = "<font size=2 color=darkblue>" & dr(15) & " </font>"
                tr10Ad.Controls.Add(tc10Af)
                tb.Controls.Add(tr10Ad)

                Dim tr10ARd As New TableRow
                Dim tc10ARd As New TableCell
                tr10ARd.Font.Size = 10
                tc10ARd.Attributes.Add("width", "50%")
                tc10ARd.ColumnSpan = 3
                tc10ARd.HorizontalAlign = HorizontalAlign.Left
                tc10ARd.Text = "<font size=2 color=darkblue>e)&nbsp;ARREAR&nbsp;</font>"
                tr10ARd.Controls.Add(tc10ARd)

                Dim tc10ARe As New TableCell
                tc10ARe.Attributes.Add("width", "5%")
                tc10ARe.HorizontalAlign = HorizontalAlign.Left
                tc10ARe.Text = "<font size=2 color=darkblue>-</font>"
                tr10ARd.Controls.Add(tc10ARe)

                Dim tc10ARf As New TableCell
                tc10ARf.Attributes.Add("width", "70%")
                tc10ARf.ColumnSpan = 7
                tc10ARf.HorizontalAlign = HorizontalAlign.Left
                tc10ARf.Text = "<font size=2 color=darkblue>" & dr(16) & " </font>"
                tr10ARd.Controls.Add(tc10ARf)
                tb.Controls.Add(tr10ARd)


                Dim tr15d As New TableRow
                Dim tc15d As New TableCell
                tr15d.Font.Size = 10
                tc15d.Attributes.Add("width", "50%")
                tc15d.ColumnSpan = 3
                tc15d.HorizontalAlign = HorizontalAlign.Left
                tc15d.Text = "<font size=2 color=darkblue>f)&nbsp;OVERTIME WAGE&nbsp;</font>"
                tr15d.Controls.Add(tc15d)

                Dim tc15e As New TableCell
                tc15e.Attributes.Add("width", "5%")
                tc15e.HorizontalAlign = HorizontalAlign.Left
                tc15e.Text = "<font size=2 color=darkblue>-</font>"
                tr15d.Controls.Add(tc15e)

                Dim tc15ff As New TableCell
                tc15ff.Attributes.Add("width", "70%")
                tc15ff.ColumnSpan = 7
                tc15ff.HorizontalAlign = HorizontalAlign.Left
                tc15ff.Text = "<font size=2 color=darkblue>" & dr(9) & " </font>"
                tr15d.Controls.Add(tc15ff)
                tb.Controls.Add(tr15d)



                Dim tr16d As New TableRow
                Dim tc16d As New TableCell
                tr16d.Font.Size = 10
                tc16d.Attributes.Add("width", "50%")
                tc16d.ColumnSpan = 3
                tc16d.HorizontalAlign = HorizontalAlign.Left
                tc16d.Text = "<font size=2 color=darkblue>GROSS WAGES PAYABLE&nbsp;</font>"
                tr16d.Controls.Add(tc16d)

                Dim tc16e As New TableCell
                tc16e.Attributes.Add("width", "5%")
                tc16e.HorizontalAlign = HorizontalAlign.Left
                tc16e.Text = "<font size=2 color=darkblue>-</font>"
                tr16d.Controls.Add(tc16e)


                Dim tc16f As New TableCell
                tc16f.Attributes.Add("width", "70%")
                tc16f.ColumnSpan = 7
                tc16f.HorizontalAlign = HorizontalAlign.Left
                tc16f.Text = "<font size=2 color=darkblue>" & dr(10) & "  </font>"
                tr16d.Controls.Add(tc16f)
                tb.Controls.Add(tr16d)


                Dim tr8d21 As New TableRow
                Dim tc8d21 As New TableCell
                tr8d21.Font.Size = 10
                tc8d21.Attributes.Add("width", "100%")
                tc8d21.ColumnSpan = 11
                tc8d21.HorizontalAlign = HorizontalAlign.Left
                tc8d21.Text = "<font size=2 color=darkblue><u>DEDUCTIONS:</u>&nbsp;</font>"
                tr8d21.Controls.Add(tc8d21)
                tb.Controls.Add(tr8d21)


                Dim trdt As New TableRow
                Dim tcdt As New TableCell
                trdt.Font.Size = 10
                tcdt.Attributes.Add("width", "50%")
                tcdt.ColumnSpan = 3
                tcdt.HorizontalAlign = HorizontalAlign.Left
                tcdt.Text = "<font size=2 color=darkblue>a)&nbsp;TDS&nbsp;</font>"
                trdt.Controls.Add(tcdt)

                Dim tcte As New TableCell
                tcte.Attributes.Add("width", "5%")
                tcte.HorizontalAlign = HorizontalAlign.Left
                tcte.Text = "<font size=2 color=darkblue>-</font>"
                trdt.Controls.Add(tcte)

                Dim tctf As New TableCell
                tctf.Attributes.Add("width", "70%")
                tctf.ColumnSpan = 7
                tctf.HorizontalAlign = HorizontalAlign.Left
                tctf.Text = "<font size=2 color=darkblue>" & dr(17) & " </font>"
                trdt.Controls.Add(tctf)
                tb.Controls.Add(trdt)


                Dim trdte As New TableRow
                Dim tcdte As New TableCell
                trdte.Font.Size = 10
                tcdte.Attributes.Add("width", "50%")
                tcdte.ColumnSpan = 3
                tcdte.HorizontalAlign = HorizontalAlign.Left
                tcdte.Text = "<font size=2 color=darkblue>b)&nbsp;ESI&nbsp;</font>"
                trdte.Controls.Add(tcdte)

                Dim tcteee As New TableCell
                tcteee.Attributes.Add("width", "5%")
                tcteee.HorizontalAlign = HorizontalAlign.Left
                tcteee.Text = "<font size=2 color=darkblue>-</font>"
                trdte.Controls.Add(tcteee)

                Dim tctfe As New TableCell
                tctfe.Attributes.Add("width", "70%")
                tctfe.ColumnSpan = 7
                tctfe.HorizontalAlign = HorizontalAlign.Left
                tctfe.Text = "<font size=2 color=darkblue>" & dr(18) & " </font>"
                trdte.Controls.Add(tctfe)
                tb.Controls.Add(trdte)

                Dim trdpe As New TableRow
                Dim tcdpe As New TableCell
                trdpe.Font.Size = 10
                tcdpe.Attributes.Add("width", "50%")
                tcdpe.ColumnSpan = 3
                tcdpe.HorizontalAlign = HorizontalAlign.Left
                tcdpe.Text = "<font size=2 color=darkblue>c)&nbsp;PF&nbsp;</font>"
                trdpe.Controls.Add(tcdpe)

                Dim tctpe As New TableCell
                tctpe.Attributes.Add("width", "5%")
                tctpe.HorizontalAlign = HorizontalAlign.Left
                tctpe.Text = "<font size=2 color=darkblue>-</font>"
                trdpe.Controls.Add(tctpe)

                Dim tcpf As New TableCell
                tcpf.Attributes.Add("width", "70%")
                tcpf.ColumnSpan = 7
                tcpf.HorizontalAlign = HorizontalAlign.Left
                tcpf.Text = "<font size=2 color=darkblue>" & dr(19) & " </font>"
                trdpe.Controls.Add(tcpf)
                tb.Controls.Add(trdpe)

                Dim trdle As New TableRow
                Dim tcdle As New TableCell
                trdle.Font.Size = 10
                tcdle.Attributes.Add("width", "50%")
                tcdle.ColumnSpan = 3
                tcdle.HorizontalAlign = HorizontalAlign.Left
                tcdle.Text = "<font size=2 color=darkblue>d)&nbsp;LOP&nbsp;</font>"
                trdle.Controls.Add(tcdle)

                Dim tctle As New TableCell
                tctle.Attributes.Add("width", "5%")
                tctle.HorizontalAlign = HorizontalAlign.Left
                tctle.Text = "<font size=2 color=darkblue>-</font>"
                trdle.Controls.Add(tctle)

                Dim tclf As New TableCell
                tclf.Attributes.Add("width", "70%")
                tclf.ColumnSpan = 7
                tclf.HorizontalAlign = HorizontalAlign.Left
                tclf.Text = "<font size=2 color=darkblue>" & dr(20) & " </font>"
                trdle.Controls.Add(tclf)
                tb.Controls.Add(trdle)

                Dim trdoe As New TableRow
                Dim tcdoe As New TableCell
                trdoe.Font.Size = 10
                tcdoe.Attributes.Add("width", "50%")
                tcdoe.ColumnSpan = 3
                tcdoe.HorizontalAlign = HorizontalAlign.Left
                tcdoe.Text = "<font size=2 color=darkblue>e)&nbsp;OTHER&nbsp;</font>"
                trdoe.Controls.Add(tcdoe)

                Dim tctoe As New TableCell
                tctoe.Attributes.Add("width", "5%")
                tctoe.HorizontalAlign = HorizontalAlign.Left
                tctoe.Text = "<font size=2 color=darkblue>-</font>"
                trdoe.Controls.Add(tctoe)

                Dim tcof As New TableCell
                tcof.Attributes.Add("width", "70%")
                tcof.ColumnSpan = 7
                tcof.HorizontalAlign = HorizontalAlign.Left
                tcof.Text = "<font size=2 color=darkblue>" & dr(21) & " </font>"
                trdoe.Controls.Add(tcof)
                tb.Controls.Add(trdoe)

                Dim tr16d1 As New TableRow
                Dim tc16d1 As New TableCell
                tr16d1.Font.Size = 10
                tc16d1.Attributes.Add("width", "50%")
                tc16d1.ColumnSpan = 3
                tc16d1.HorizontalAlign = HorizontalAlign.Left
                tc16d1.Text = "<font size=2 color=darkblue>TOTAL DEDUCTIONS&nbsp;</font>"
                tr16d1.Controls.Add(tc16d1)

                Dim tc16e1 As New TableCell
                tc16e1.Attributes.Add("width", "5%")
                tc16e1.HorizontalAlign = HorizontalAlign.Left
                tc16e1.Text = "<font size=2 color=darkblue>-</font>"
                tr16d1.Controls.Add(tc16e1)


                Dim tc16f1 As New TableCell
                tc16f1.Attributes.Add("width", "70%")
                tc16f1.ColumnSpan = 7
                tc16f1.HorizontalAlign = HorizontalAlign.Left
                tc16f1.Text = "<font size=2 color=darkblue>" & dr(11) & "  </font>"
                tr16d1.Controls.Add(tc16f1)
                tb.Controls.Add(tr16d1)



                Dim tr16d2 As New TableRow
                Dim tc16d2 As New TableCell
                tr16d2.Font.Size = 10
                tc16d2.Attributes.Add("width", "50%")
                tc16d2.ColumnSpan = 3
                tc16d2.HorizontalAlign = HorizontalAlign.Left
                tc16d2.Text = "<font size=2 color=darkblue>NET WAGES PAID&nbsp;</font>"
                tr16d2.Controls.Add(tc16d2)

                Dim tc16e2 As New TableCell
                tc16e2.Attributes.Add("width", "5%")
                tc16e2.HorizontalAlign = HorizontalAlign.Left
                tc16e2.Text = "<font size=2 color=darkblue>-</font>"
                tr16d2.Controls.Add(tc16e2)


                Dim tc16f2 As New TableCell
                tc16f2.Attributes.Add("width", "70%")
                tc16f2.ColumnSpan = 7
                tc16f2.HorizontalAlign = HorizontalAlign.Left
                tc16f2.Text = "<font size=2 color=darkblue>" & dr(12) & "  </font>"
                tr16d2.Controls.Add(tc16f2)
                tb.Controls.Add(tr16d2)




                Dim tr16d3 As New TableRow
                tr16d3.Width = 10
                Dim tc16d3 As New TableCell
                tr16d3.Font.Size = 10
                tc16d3.Attributes.Add("width", "50%")
                tc16d3.ColumnSpan = 3
                tc16d3.HorizontalAlign = HorizontalAlign.Left
                tc16d3.Text = "<font size=2 color=darkblue><BR><BR><I>PAY-IN-CHARGE&nbsp;(SIGNATURE)</I></</font>"
                tr16d3.Controls.Add(tc16d3)

                Dim tc16e3 As New TableCell
                tc16e3.Attributes.Add("width", "5%")
                tc16e3.HorizontalAlign = HorizontalAlign.Center
                tc16e3.Text = ""
                tr16d3.Controls.Add(tc16e3)

                Dim tc16f3 As New TableCell
                tc16f3.Attributes.Add("width", "70%")
                tc16f3.ColumnSpan = 7
                tc16f3.HorizontalAlign = HorizontalAlign.Right
                tc16f3.Text = "<font size=2 color=darkblue><BR><BR><I>EMPLOYEE'S&nbsp;SIGNATURE   / THUMB-IMPRESSION </I></font>"
                tr16d3.Controls.Add(tc16f3)
                tb.Controls.Add(tr16d3)

                Dim t17d As New TableRow
                Dim qq17d As New TableCell
                t17d.Font.Size = 10
                qq17d.Attributes.Add("width", "125%")
                qq17d.ColumnSpan = 10
                qq17d.HorizontalAlign = HorizontalAlign.Left
                qq17d.Text = "************************************************************************************************<BR> "
                t17d.Controls.Add(qq17d)
                tb.Controls.Add(t17d)
                pagenext()
            Next
            Me.Panel1.Controls.Add(tb)
            '''''''''''''''''''''''''''''''''''''''''''''
        End If




    End Sub
    Sub pagenext()


        Dim pgebrk As New TableRow
        pgebrk.Width = 23
        Dim pgebrk1 As New TableCell
        pgebrk1.ColumnSpan = 23
        pgebrk1.HorizontalAlign = HorizontalAlign.Center
        pgebrk1.Text = "<DIV style=page-break-after:always></DIV>"
        pgebrk.Controls.Add(pgebrk1)
        tb.Controls.Add(pgebrk)
    End Sub

End Class
