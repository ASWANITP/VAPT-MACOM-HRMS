Imports system.data
Imports system.data.oracleclient
Partial Class attendance_DRILL_DOWN_individualreport_mafarm_2714e40e3446
    Inherits System.Web.UI.Page

    Dim dt, dt1, dt6, dt7, dt8, dt9, dt10, dt11, dt12 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim fdt, tdt, emp, sql, sql1 As String
    Dim str, strs, sf(), frm As String
    Dim dr As DataRow
    Dim per, totalper As Double
    Dim totalp = 0, totals = 0
    Dim color = 0
    Dim firm As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fdt = Request.QueryString.Get("fdt")
        tdt = Request.QueryString.Get("tdt")
        emp = Request.QueryString.Get("emp")
        firm = Session("firm_id")
        Dim empcode As Integer
        empcode = Request.QueryString.Get("empcode")
        'If firm = 8 Then
        '    sql = "select curr_date as day,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,decode(e_time,NULL,'----------',e_time) as evening_time, case when (da.m_time is null and da.pay_id not in (50,52)) and (da.pay_id not in (51,52) and da.e_time is null) then 'Absent' else case when da.pay_id in (50) and da.e_time is not null then 'Morning-REG' else case when da.pay_id in (51) and da.m_time is not null then 'Evening-REG' else case when da.pay_id in (52) then 'BOTH-REG' else case when (da.m_time>bt1.in_time and da.m_time<>'TOUR' and da.m_time<>'COMPEN' and da.pay_id not in (50,7,52)) and (da.e_time is null and da.pay_id not in (51,7,52)) then 'Late & Non-Marking' else case when da.m_time<=bt1.in_time and (da.e_time is null and da.pay_id not in (51,52)) then case when da.PAY_ID in(7) then 'Absent' else 'Non-Marking Evening' end else case when (da.m_time is null and da.pay_id not in (50,52,7)) and da.e_time <bt2.out_time then 'Non-Marking Morning & Early-Going' else case when (da.m_time is null and da.pay_id not in (50,52)) and da.e_time >=bt2.out_time then case when da.PAY_ID in(7) then 'Absent' else  'Non-Marking Morning' end else case when da.m_time<=bt1.in_time and (da.e_time<bt2.out_time and da.e_time<>'TOUR' and da.e_time<>'COMPEN' and da.pay_id not in (51,52,7)) then 'Early-Going' else case when (da.m_time>bt1.in_time and da.pay_id not in (50,52) ) and (da.e_time<bt2.out_time and da.pay_id not in (51,52,7)) then 'Late & Early Going' else case when (da.m_time>bt1.in_time and da.m_time<>'TOUR' and da.m_time<>'COMPEN' and da.pay_id not in (50,52,7)) and da.e_time>=bt2.out_time then 'Late' else case when da.pay_id in (50) and da.E_TIME is null then  'REG-Morning & Non-Marking Evening'   else case when da.pay_id in (51) and da.M_TIME is null then 'REG-EVENING & Non-Marking Morning'  else  case  when da.pay_id in (50) and da.e_time<>'TOUR' and da.e_time<>'COMPEN'  and da.E_TIME <bt2.out_time  then 'REG-Morning & Early-Going'  else  case  when da.pay_id in (51) and da.m_time<>'TOUR' and da.m_time<>'COMPEN'  and da.M_TIME>bt1.in_time then  'REG-Evening & Late' else case when da.pay_id in (52) then 'REG-Morning & Evening'  else '-' end end end end end end end end end end end end end end end end as remarks,case when da.gun_status<>0 then 'PUNCHING-BLOCK' else '--' end as block from ATTENDANCE da,employee_master em, time_tab bt1, time_tab bt2,employ_firm ef where  em.emp_code=da.emp_code and  ef.firm_id='" & firm & "'   and ef.emp_code=em.emp_code and da.curr_date between '" & fdt & "' and '" & tdt & "' and bt1.shift_id=da.m_shift and bt2.shift_id=da.e_shift and da.emp_code=" & emp & " order by day"
        'Else
        '    'sql = "select to_date(curr_date) as day,em.emp_code as emp_code,upper(substr(em.emp_name,0,19)) as Name,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,substr(bm1.branch_name,0,12) as Morning_Branch,decode(e_time,NULL,'----------',e_time) as evening_time,substr(bm2.branch_name,0,12) as Evening_Branch,case when (m_time='ONDUTY' and e_time is NULL) then 'Non-Marking' else case when (m_time='ONDUTY' and e_time='ONDUTY') then '' else case when (m_time='OFF' and e_time='OFF') then '' else case when ((da.m_time is null and da.e_time is null) and (to_char(to_date(da.curr_date),'d')=1)) then 'Sunday' else case when da.m_time is null and da.e_time is null then 'Absent' else case when da.m_time>tt.in_time and da.e_time is null then 'Late & Non Marking' else case when da.m_time<=tt.in_time and da.e_time is null then 'Non Marking' else case when da.m_time is null and da.e_time <tt.out_time then 'Non Marking & Early Going' else case when da.m_time is null and da.e_time >=tt.out_time then 'Non Marking' else case when da.m_time<=tt.in_time and da.e_time<tt.out_time then 'Early Going' else case when da.m_time>tt.in_time and da.e_time<tt.out_time then 'Late & Early Going' else case when da.m_time>tt.in_time and da.e_time>tt.out_time then 'Late' else '' end end end end end end end end end end end end as remarks from ATTENDANCE da,employee_master em,branch_master bm,branch_master bm1,branch_master bm2,time_tab tt where  em.emp_code=da.emp_code and bm.branch_id=em.branch_id and   da.shift_id not in (4,5) and da.shift_id=tt.shift_id and bm1.branch_id=da.m_branch and bm2.branch_id=da.e_branch and da.EMP_CODE=" & empcode & " order by bm.branch_id,day"
        '    ' sql = "select to_date(curr_date) as day,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,decode(e_time,NULL,'----------',e_time) as evening_time,case when (m_time='ONDUTY' and e_time is NULL) then 'Non-Marking' else case when (m_time='ONDUTY' and e_time='ONDUTY') then '' else case when (m_time='OFF' and e_time='OFF') then '' else case when ((da.m_time is null and da.e_time is null) and (to_char(to_date(da.curr_date),'d')=1)) then 'Sunday' else case when da.m_time is null and da.e_time is null then 'Absent' else case when da.m_time>bt1.in_time and da.e_time is null then 'Late & Non Marking' else case when da.m_time<=bt1.in_time and da.e_time is null then 'Non Marking' else case when da.m_time is null and da.e_time <bt2.out_time then 'Non Marking & Early Going' else case when da.m_time is null and da.e_time >=bt2.out_time then 'Non Marking' else case when da.m_time<=bt1.in_time and da.e_time<bt2.out_time then 'Early Going' else case when da.m_time>bt1.in_time and da.e_time<bt2.out_time then 'Late & Early Going' else case when da.m_time>bt1.in_time and da.e_time>=bt2.out_time then 'Late' else '' end end end end end end end end end  end end end as remarks from ATTENDANCE da,employee_master em,branch_time bt1,branch_time bt2 where  em.emp_code=da.emp_code and to_date(da.curr_date)>='" & fdt & "' and to_date(da.curr_date)<='" & tdt & "' and   da.shift_id not in (4,5) and bt1.branch_id=da.m_branch and bt2.branch_id=da.e_branch and da.emp_code=" & emp & " and da.branch_id<>0 union select to_date(curr_date) as day,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,decode(e_time,NULL,'----------',e_time) as evening_time,case when (m_time='ONDUTY' and e_time is NULL) then 'Non-Marking' else case when (m_time='ONDUTY' and e_time='ONDUTY') then '' else case when (m_time='OFF' and e_time='OFF') then '' else case when ((da.m_time is null and da.e_time is null) and (to_char(to_date(da.curr_date),'d')=1)) then 'Sunday' else case when da.m_time is null and da.e_time is null then 'Absent' else case when da.m_time>tt.in_time and da.e_time is null then 'Late & Non Marking' else case when da.m_time<=tt.in_time and da.e_time is null then 'Non Marking' else case when da.m_time is null and da.e_time <tt.out_time then 'Non Marking & Early Going' else case when da.m_time is null and da.e_time >=tt.out_time then 'Non Marking' else case when da.m_time<=tt.in_time and da.e_time<tt.out_time then 'Early Going' else case when da.m_time>tt.in_time and da.e_time<tt.out_time then 'Late & Early Going' else case when da.m_time>tt.in_time and da.e_time>=tt.out_time then 'Late' else '' end end end end end end end end end  end end end as remarks from ATTENDANCE da,employee_master em,branch_master bm1,branch_master bm2,time_tab tt where  em.emp_code=da.emp_code and to_date(da.curr_date)>='" & fdt & "' and to_date(da.curr_date)<='" & tdt & "' and   da.shift_id not in (4,5) and da.shift_id=tt.shift_id and bm1.branch_id=da.m_branch and bm2.branch_id=da.e_branch and da.emp_code=" & emp & " and da.branch_id=0 and da.e_branch=0 and da.m_branch=0 union select to_date(curr_date) as day,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,decode(e_time,NULL,'----------',e_time) as evening_time,case when (m_time='ONDUTY' and e_time is NULL) then 'Non-Marking' else case when (m_time='ONDUTY' and e_time='ONDUTY') then '' else case when (m_time='OFF' and e_time='OFF') then '' else case when ((da.m_time is null and da.e_time is null) and (to_char(to_date(da.curr_date),'d')=1)) then 'Sunday' else case when da.m_time is null and da.e_time is null then 'Absent' else case when da.m_time>bt1.in_time and da.e_time is null then 'Late & Non Marking' else case when da.m_time<=bt1.in_time and da.e_time is null then 'Non Marking' else case when da.m_time is null and da.e_time <bt2.out_time then 'Non Marking & Early Going' else case when da.m_time is null and da.e_time >=bt2.out_time then 'Non Marking' else case when da.m_time<=bt1.in_time and da.e_time<bt2.out_time then 'Early Going' else case when da.m_time>bt1.in_time and da.e_time<bt2.out_time then 'Late & Early Going' else case when da.m_time>bt1.in_time and da.e_time>=bt2.out_time then 'Late' else '' end end end end end end end end end  end end end as remarks from ATTENDANCE da,employee_master em,branch_time bt1,branch_time bt2 where  em.emp_code=da.emp_code and to_date(da.curr_date)>='" & fdt & "' and to_date(da.curr_date)<='" & tdt & "' and   da.shift_id not in (4,5) and bt1.branch_id=da.m_branch and bt2.branch_id=da.e_branch and da.emp_code=" & emp & " and da.branch_id=0 and (da.m_branch<>0 or da.e_branch<>0) order by day"
        '    sql = "select distinct curr_date as day,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,decode(e_time,NULL,'----------',e_time) as evening_time, case when (da.m_time is null and da.pay_id not in (50,52)) and (da.pay_id not in (51,52) and da.e_time is null) then 'Absent' else case when da.pay_id in (50) and da.e_time is not null then 'Morning-REG' else case when da.pay_id in (51) and da.m_time is not null then 'Evening-REG' else case when da.pay_id in (52) then 'BOTH-REG' else case when (da.m_time>bt1.in_time and da.m_time<>'TOUR' and da.m_time<>'COMPEN' and da.pay_id not in (50,7,52)) and (da.e_time is null and da.pay_id not in (51,7,52)) then 'Late & Non-Marking' else case when da.m_time<=bt1.in_time and (da.e_time is null and da.pay_id not in (51,52)) then 'Non-Marking Evening' else case when (da.m_time is null and da.pay_id not in (50,52,7)) and da.e_time <bt2.out_time then 'Non-Marking Morning & Early-Going' else case when (da.m_time is null and da.pay_id not in (50,52)) and da.e_time >=bt2.out_time then 'Non-Marking Morning' else case when da.m_time<=bt1.in_time and (da.e_time<bt2.out_time and da.e_time<>'TOUR' and da.e_time<>'COMPEN' and da.pay_id not in (51,52,7)) then 'Early-Going' else case when (da.m_time>bt1.in_time and da.pay_id not in (50,52) ) and (da.e_time<bt2.out_time and da.pay_id not in (51,52,7)) then 'Late & Early Going' else case when (da.m_time>bt1.in_time and da.m_time<>'TOUR' and da.m_time<>'COMPEN' and da.pay_id not in (50,52,7)) and da.e_time>=bt2.out_time then 'Late' else case when da.pay_id in (50) and da.E_TIME is null then  'REG-Morning & Non-Marking Evening'   else case when da.pay_id in (51) and da.M_TIME is null then 'REG-EVENING & Non-Marking Morning'  else  case  when da.pay_id in (50) and da.e_time<>'TOUR' and da.e_time<>'COMPEN'  and da.E_TIME <bt2.out_time  then 'REG-Morning & Early-Going'  else  case  when da.pay_id in (51) and da.m_time<>'TOUR' and da.m_time<>'COMPEN'  and da.M_TIME>bt1.in_time then  'REG-Evening & Late' else case when da.pay_id in (52) then 'REG-Morning & Evening'  else '-' end end end end end end end end end end end end end end end end as remarks,case when da.gun_status<>0 then 'PUNCHING-BLOCK' else '--' end as block from ATTENDANCE da,employee_master em, time_tab bt1, time_tab bt2,employ_firm ef where  em.emp_code=da.emp_code and  ef.firm_id='" & firm & "'   and ef.emp_code=em.emp_code and da.curr_date between '" & fdt & "' and '" & tdt & "' and bt1.shift_id=da.m_shift and bt2.shift_id=da.e_shift and da.emp_code=" & emp & " order by day"
        'End If

        Dim dts1 As DataTable = oh.ExecuteDataSet("select query from hrm_report_master where firm_id=99 and query_id=204").Tables(0)
        Dim strd() As String = dts1.Rows(0)(0).ToString.Split("#")

        strs = strd(1).Replace("empcd", emp)


        strs = strs.Replace("fdt", fdt)

        strs = strs.Replace("tdt", tdt)
        strs = strs.Replace("firmid", firm)


        dt = oh.ExecuteDataSet(strs).Tables(0)
        'dt = oh.ExecuteDataSet(strd(1)).Tables(0)
        Dim tb As New Table
        ' tb.Attributes.Add("Border", "1")
        tb.Attributes.Add("width", "100%")
        If Session("firm_id") = 28 Then
            'sql1 = "select a.emp_name,b.branch_name,a.branch_id,c.dep_name,case when d.designation_id <> 7 then d.designation || '/' || d.CTGRY || '/' || d.CTGRY_CODE when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (4, 3) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'JR. MANAGEMENT' || '/' || 'JM 4' when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (7) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'STAFF' || '/' || 'JM 2' when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (5, 6, 8) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'STAFF' || '/' || 'JM 3' when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (2) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'JR. MANAGEMENT' || '/' || 'JM 5' end from employee_master a,branch_master b,department_mst c,designation_master d where a.emp_code=" & emp & " and b.branch_id=a.branch_id and a.department_id=c.dep_id and a.designation_id=d.designation_id union select a.emp_name,b.branch_name,a.branch_id,c.dep_name,case when d.designation_id <> 7 then d.designation || '/' || d.CTGRY || '/' || d.CTGRY_CODE when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (4, 3) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'JR. MANAGEMENT' || '/' || 'JM 4' when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (7) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'STAFF' || '/' || 'JM 2' when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (5, 6, 8) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'STAFF' || '/' || 'JM 3' when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (2) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'JR. MANAGEMENT' || '/' || 'JM 5' end from employee_master a,before_completion b,department_mst c,designation_master d where a.emp_code=" & emp & " and b.old_id=a.branch_id and a.department_id=c.dep_id and a.designation_id=d.designation_id and b.branch_id is null"

            sql1 = "select a.emp_name, b.branch_name, a.branch_id, c.dep_name, case when d.designation_id <> 7 then d.designation || '/' || d.CTGRY || '/' || d.CTGRY_CODE when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (4, 3) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'JR. MANAGEMENT' || '/' || 'JM 4' when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (7) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'STAFF' || '/' || 'JM 2' when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (5, 6, 8) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'STAFF' || '/' || 'JM 3' when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (2) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'JR. MANAGEMENT' || '/' || 'JM 5' else d.designation || '/' || '-----' || '/' || '---' end from employee_master a, branch_master b, department_mst c, designation_master d where a.emp_code =" & emp & " and b.branch_id = a.branch_id and a.department_id = c.dep_id and a.designation_id = d.designation_id union select a.emp_name, b.branch_name, a.branch_id, c.dep_name, case when d.designation_id <> 7 then d.designation || '/' || d.CTGRY || '/' || d.CTGRY_CODE when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (4, 3) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'JR. MANAGEMENT' || '/' || 'JM 4' when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (7) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'STAFF' || '/' || 'JM 2' when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (5, 6, 8) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'STAFF' || '/' || 'JM 3' when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = a.emp_code and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (2) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'JR. MANAGEMENT' || '/' || 'JM 5' else d.designation || '/' || '-----' || '/' || '---' end from employee_master a, before_completion b, department_mst c, designation_master d where a.emp_code = " & emp & " and b.old_id = a.branch_id and a.department_id = c.dep_id and a.designation_id = d.designation_id and b.branch_id is null"


        Else
            sql1 = "select a.emp_name,b.branch_name,a.branch_id,c.dep_name,d.designation from employee_master a,branch_master b,department_mst c,designation_master d where a.emp_code=" & emp & " and b.branch_id=a.branch_id and a.department_id=c.dep_id and a.designation_id=d.designation_id union select a.emp_name,b.branch_name,a.branch_id,c.dep_name,d.designation from employee_master a,before_completion b,department_mst c,designation_master d where a.emp_code=" & emp & " and b.old_id=a.branch_id and a.department_id=c.dep_id and a.designation_id=d.designation_id and b.branch_id is null"
        End If
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        If dt1.Rows.Count > 0 Then
            Dim tr1 As New TableRow
            Dim td11 As New TableCell
            tr1.BackColor = Drawing.Color.Gold
            td11.Attributes.Add("width", "80%")
            td11.ColumnSpan = 80
            td11.HorizontalAlign = HorizontalAlign.Center
            td11.Text = "<font size=4 color=red><b>" & Session("firm_name") & "</b></font>"
            tr1.Controls.Add(td11)
            tb.Controls.Add(tr1)

            Dim tr2 As New TableRow
            Dim td21 As New TableCell
            tr2.BackColor = Drawing.Color.MistyRose
            td21.Attributes.Add("width", "40%")
            td21.ColumnSpan = 35
            td21.HorizontalAlign = HorizontalAlign.Right
            td21.Text = "<font size=2 color=darkblue><b>Branch-id :" & dt1.Rows(0)(2) & "</b></font>"
            tr2.Controls.Add(td21)
            Dim td22 As New TableCell
            td22.Attributes.Add("width", "40%")
            td22.ColumnSpan = 40
            td22.HorizontalAlign = HorizontalAlign.Left
            td22.Text = "<font size=2 color=darkblue><b>Branch :" & dt1.Rows(0)(1) & "</b></font>"
            tr2.Controls.Add(td22)
            tb.Controls.Add(tr2)


            Dim tr3 As New TableRow
            'tr3.BackColor = Drawing.Color.MistyRose
            Dim td31 As New TableCell


            Dim td32 As New TableCell
            td32.Attributes.Add("width", "40%")
            td32.ColumnSpan = 15
            td32.HorizontalAlign = HorizontalAlign.Center
            td32.Text = "<font size=2 color=darkblue><BR><BR><b>Time :" & Format(Date.Now, "hh:mm:ss") & "</b></font>"
            tr3.Controls.Add(td32)

            Dim td321 As New TableCell
            td321.Attributes.Add("width", "40%")
            td321.ColumnSpan = 42
            td321.HorizontalAlign = HorizontalAlign.Center
            td321.Text = "<font size=2.8 color=darkbrown><BR><b>Attendance Report from &nbsp" & fdt & "&nbsp to &nbsp" & tdt & "</b></font>"
            tr3.Controls.Add(td321)


            td31.Attributes.Add("width", "40%")
            td31.ColumnSpan = 18
            td31.HorizontalAlign = HorizontalAlign.Center
            td31.Text = "<font size=2 color=darkblue><BR><BR><b>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</b></font>"
            tr3.Controls.Add(td31)

            tb.Controls.Add(tr3)

            Dim l11 As New TableRow
            Dim ld11 As New TableCell
            ld11.Attributes.Add("width", "80%")
            ld11.ColumnSpan = 80
            ld11.HorizontalAlign = HorizontalAlign.Center
            ld11.Text = "<font size=3><hr size='1' NOSHADE></font>"
            l11.Controls.Add(ld11)
            tb.Controls.Add(l11)


            Dim tr4 As New TableRow
            tr4.BackColor = Drawing.Color.Cornsilk
            Dim td41 As New TableCell
            td41.Attributes.Add("width", "80%")
            td41.ColumnSpan = 35
            td41.HorizontalAlign = HorizontalAlign.Center
            td41.Text = "<font size=2.5 color=Maroon><BR><b> EMPLOYEE NAME&nbsp:&nbsp" & dt1.Rows(0)(0) & "</b></font>"
            tr4.Controls.Add(td41)


            Dim td411 As New TableCell
            td411.Attributes.Add("width", "80%")
            td411.ColumnSpan = 55
            td411.HorizontalAlign = HorizontalAlign.Center
            td411.Text = "<font size=2.5 color=Maroon><BR><b> EMPLOYEE CODE&nbsp:&nbsp" & emp & "</b></font>"
            tr4.Controls.Add(td411)
            tb.Controls.Add(tr4)

            Dim tr8 As New TableRow
            tr8.BackColor = Drawing.Color.Cornsilk
            Dim td441 As New TableCell
            td441.Attributes.Add("width", "80%")
            td441.ColumnSpan = 35
            td441.HorizontalAlign = HorizontalAlign.Center
            td441.Text = "<font size=2.5 color=Maroon><BR><b> DEPARTMENT&nbsp:&nbsp" & dt1.Rows(0)(3) & "</b></font>"
            tr8.Controls.Add(td441)


            Dim td414 As New TableCell
            td414.Attributes.Add("width", "80%")
            td414.ColumnSpan = 55
            td414.HorizontalAlign = HorizontalAlign.Center
            td414.Text = "<font size=2.5 color=Maroon><BR><b> DESIGNATION&nbsp:&nbsp" & dt1.Rows(0)(4).ToString().Split("/")(0) & "</b></font>"
            tr8.Controls.Add(td414)
            tb.Controls.Add(tr8)


            If Session("firm_id") = 28 Then
                Dim tr81 As New TableRow
                tr81.BackColor = Drawing.Color.Cornsilk
                Dim td441a As New TableCell
                td441a.Attributes.Add("width", "80%")
                td441a.ColumnSpan = 35
                td441a.HorizontalAlign = HorizontalAlign.Center
                td441a.Text = "<font size=2.5 color=Maroon><BR><b> DES. CAT&nbsp:&nbsp" & dt1.Rows(0)(4).ToString().Split("/")(1) & "</b></font>"
                tr81.Controls.Add(td441a)


                Dim td414a As New TableCell
                td414a.Attributes.Add("width", "80%")
                td414a.ColumnSpan = 55
                td414a.HorizontalAlign = HorizontalAlign.Center
                td414a.Text = "<font size=2.5 color=Maroon><BR><b> CAT CODE&nbsp:&nbsp" & dt1.Rows(0)(4).ToString().Split("/")(2) & "</b></font>"
                tr81.Controls.Add(td414a)
                tb.Controls.Add(tr81)
            End If

            Dim l1 As New TableRow
            Dim ld1 As New TableCell
            ld1.Attributes.Add("width", "80%")
            ld1.ColumnSpan = 80
            ld1.HorizontalAlign = HorizontalAlign.Center
            ld1.Text = "<font size=3><hr size='2' NOSHADE></font>"
            l1.Controls.Add(ld1)
            tb.Controls.Add(l1)

            Dim tr5 As New TableRow
            Dim td51 As New TableCell
            td51.Attributes.Add("width", "10%")
            td51.ColumnSpan = 8
            td51.HorizontalAlign = HorizontalAlign.Left
            td51.Text = "<font size=2.5><b>DATE</b></font>"
            tr5.Controls.Add(td51)

            Dim td541 As New TableCell
            td541.Attributes.Add("width", "10%")
            td541.ColumnSpan = 7
            td541.HorizontalAlign = HorizontalAlign.Left
            td541.Text = "<font size=2.5><b></b></font>"
            tr5.Controls.Add(td541)

            Dim td54 As New TableCell
            td54.Attributes.Add("width", "20%")
            td54.ColumnSpan = 15
            td54.HorizontalAlign = HorizontalAlign.Left
            td54.Text = "<font size=2.5><b>MORNING TIME</b></font>"
            tr5.Controls.Add(td54)

            Dim td55 As New TableCell
            td55.Attributes.Add("width", "15%")
            td55.ColumnSpan = 7
            td55.HorizontalAlign = HorizontalAlign.Left
            td55.Text = "<font size=2.5><b></b></font>"
            tr5.Controls.Add(td55)

            Dim td56 As New TableCell
            td56.Attributes.Add("width", "20%")
            td56.ColumnSpan = 15
            td56.HorizontalAlign = HorizontalAlign.Left
            td56.Text = "<font size=2.5><b>EVENING TIME</b></font>"
            tr5.Controls.Add(td56)

            Dim td57 As New TableCell
            td57.Attributes.Add("width", "15%")
            td57.ColumnSpan = 7
            td57.HorizontalAlign = HorizontalAlign.Left
            td57.Text = "<font size=2.5><b>BLOCK</b></font>"
            tr5.Controls.Add(td57)

            Dim td58 As New TableCell
            td58.Attributes.Add("width", "25%")
            td58.ColumnSpan = 15
            td58.HorizontalAlign = HorizontalAlign.Center
            td58.Text = "<font size=2.5><b>REMARKS</b></font>"
            tr5.Controls.Add(td58)
            tb.Controls.Add(tr5)
            tb.Controls.Add(tr5)

            Dim l2 As New TableRow
            Dim ld2 As New TableCell
            ld2.Attributes.Add("width", "100%")
            ld2.ColumnSpan = 80
            ld2.HorizontalAlign = HorizontalAlign.Center
            ld2.Text = "<font size=3><hr size='2' NOSHADE></font>"
            l2.Controls.Add(ld2)
            tb.Controls.Add(l2)






            For Each dr In dt.Rows




                Dim tr6 As New TableRow
                If (color = 0) Then
                    tr6.BackColor = Drawing.Color.GhostWhite
                    color = 1
                Else
                    tr6.BackColor = Drawing.Color.WhiteSmoke
                    color = 0
                End If

                Dim td61 As New TableCell
                td61.Attributes.Add("width", "10%")
                td61.ColumnSpan = 8
                td61.HorizontalAlign = HorizontalAlign.Left
                td61.Text = "<font size=2>" & Format(dr(0), "dd/MMM/yyyy") & "</font>"
                tr6.Controls.Add(td61)

                Dim td641 As New TableCell
                td641.Attributes.Add("width", "10%")
                td641.ColumnSpan = 7
                td641.HorizontalAlign = HorizontalAlign.Left
                td641.Text = "<font size=2></font>"
                tr6.Controls.Add(td641)


                Dim td64 As New TableCell
                td64.Attributes.Add("width", "20%")
                td64.ColumnSpan = 15
                td64.HorizontalAlign = HorizontalAlign.Left
                td64.Text = "<font size=2>" & dr(1) & "</font>"
                tr6.Controls.Add(td64)


                Dim td65 As New TableCell
                td65.Attributes.Add("width", "15%")
                td65.ColumnSpan = 7
                td65.HorizontalAlign = HorizontalAlign.Left
                td65.Text = "<font size=2></font>"
                tr6.Controls.Add(td65)


                Dim td66 As New TableCell
                td66.Attributes.Add("width", "20%")
                td66.ColumnSpan = 15
                td66.HorizontalAlign = HorizontalAlign.Left
                td66.Text = "<font size=2>" & dr(2) & "</font>"
                tr6.Controls.Add(td66)


                Dim td67 As New TableCell
                td67.Attributes.Add("width", "15%")
                td67.ColumnSpan = 7
                td67.HorizontalAlign = HorizontalAlign.Left
                td67.Text = "<font size=2><a href=Block_Details.aspx?dt=" & Format(dr(0), "dd/MMM/yyyy") & ">" & dr(4) & "</font>"
                ' td67.Text = "<font size=2><a href=Block_Details.aspx?Request.QueryString=" & fdt & " &Request.QueryString=" & dr(4) & "</font>"

                tr6.Controls.Add(td67)
                If Not IsDBNull(dr(3)) Then
                    'If dr(3) = "Absent" Or dr(3) = "-" Then------------Commented to include 'Non marking mng/evng' ...if punched, Compo off not shown in punch report.[mismatched report-bug reported from Auditing side]
                    If dr(3) = "Absent" Or dr(3) = "-" Or dr(3) = "Non-Marking Morning" Or dr(3) = "Non-Marking Evening" Then


                        ' ...............req id 14776...............................
                        'dt6 = oh.ExecuteDataSet("select count(*)from hrm_leave_apply_sanction a where a.emp_code =" & emp & " and ((to_date(a.leave_frdate)='" & Format(dr(0), "dd/MMM/yyyy") & "') or(to_date(a.leave_todate)='" & Format(dr(0), "dd/MMM/yyyy") & "')and a.status_id in (0,4,5,1))").Tables(0)
                        dt6 = oh.ExecuteDataSet("select count(*) from hrm_leave_apply_sanction a where a.emp_code =" & emp & " and ((to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between to_date(a.leave_frdate) and to_date(a.leave_todate)) or (to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between to_date(a.leave_frdate) and to_date(a.leave_todate))) and a.status_id in (0, 4, 5, 1)").Tables(0)
                        dt12 = oh.ExecuteDataSet("select count(*) from employ_leave_dtl e where ((to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between to_date(e.leave_frdate) and to_date(e.leave_todate)) or (to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between to_date(e.leave_frdate) and to_date(e.leave_todate))) and e.leave_id not in (4) and e.leave_process_id in (1,2) and e.emp_code = " & emp & " ").Tables(0)

                        If dt6.Rows(0)(0) > 0 Or dt12.Rows(0)(0) > 0 Then
                            'dt7 = oh.ExecuteDataSet("select a.emp_code,decode(a.status_id,0,'Leave Applied',4,'Leave Recommended',5,'Leave Recommended',1,'Leave Sanctioned',2,'Leave Rejected')from hrm_leave_apply_sanction a where a.emp_code =" & emp & " and ((to_date(a.leave_frdate)='" & Format(dr(0), "dd/MMM/yyyy") & "') or(to_date(a.leave_todate)='" & Format(dr(0), "dd/MMM/yyyy") & "')and a.status_id in (0,4,5,1))").Tables(0)
                            dt7 = oh.ExecuteDataSet("select distinct a.emp_code,case when a.status_id = 0 then 'Leave applied' when a.status_id = 4 then 'Leave Recommended' when a.status_id = 5 then 'Leave Recommended' when a.status_id = 1 then 'Leave Sanctioned' when a.status_id = 2 then 'Leave Rejected' end as status from hrm_leave_apply_sanction a where a.emp_code =" & emp & " and ((to_date('" & Format(dr(0), "dd/MMM/yyyy") & "')  between to_date(a.leave_frdate) and to_date(a.leave_todate)) or (to_date('" & Format(dr(0), "dd/MMM/yyyy") & "')  between to_date(a.leave_frdate) and to_date(a.leave_todate))) union select distinct e.emp_code,case when (e.leave_id not in (4)and e.leave_process_id in (1,2)) then 'Leave Sanctioned' end as status from employ_leave_dtl e where e.emp_code = " & emp & " and ((to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between to_date(e.leave_frdate) and to_date(e.leave_todate)) or (to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between to_date(e.leave_frdate) and to_date(e.leave_todate)) ) and e.leave_id not in (4) and e.leave_process_id  in (1,2)").Tables(0)

                            Dim td68 As New TableCell
                            td68.Attributes.Add("width", "25%")
                            td68.ColumnSpan = 15
                            td68.HorizontalAlign = HorizontalAlign.Center
                            td68.Text = "<font size=2>" & dt7.Rows(0)(1) & "</font>"
                            tr6.Controls.Add(td68)
                            tb.Controls.Add(tr6)
                        Else


                            dt8 = oh.ExecuteDataSet("select count(*) from hrm_comp_appl a where a.emp_code = " & emp & " and  to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') =to_date(a.leave_dt) and a.status_id in (0, 4, 1)  ").Tables(0)
                            If dt8.Rows(0)(0) > 0 Then
                                dt9 = oh.ExecuteDataSet("select distinct a.emp_code,decode(a.status_id,0,'COMPENOFF Applied',4,'COMPENOFF Recommended',1,'COMPENOFF Sanctioned',2,'COMPENOFF Rejected') from hrm_comp_appl a where a.emp_code =" & emp & " and  to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') =to_date(a.leave_dt) and a.status_id in (0,4,1)").Tables(0)
                                Dim td68 As New TableCell
                                td68.Attributes.Add("width", "25%")
                                td68.ColumnSpan = 15
                                td68.HorizontalAlign = HorizontalAlign.Center
                                td68.Text = "<font size=2>" & dt9.Rows(0)(1) & "</font>"
                                tr6.Controls.Add(td68)
                                tb.Controls.Add(tr6)


                            Else


                                dt10 = oh.ExecuteDataSet("select count(*) from hrm_TOUR_dtl a where a.emp_code = " & emp & " and  to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between to_date(a.from_dt) and to_date(a.to_dt) and a.tour_id in (0, 4, 1)  ").Tables(0)
                                If dt10.Rows(0)(0) > 0 Then
                                    dt11 = oh.ExecuteDataSet("select distinct a.emp_code,decode(a.tour_id,0,'TOUR Applied',4,'TOUR Recommended',1,'TOUR Sanctioned',2,'TOUR Rejected') from hrm_tour_dtl a where a.emp_code =" & emp & " and  to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between to_date(a.from_dt) and to_date(a.to_dt) and a.tour_id in (0,4,1)").Tables(0)
                                    Dim td68 As New TableCell
                                    td68.Attributes.Add("width", "25%")
                                    td68.ColumnSpan = 15
                                    td68.HorizontalAlign = HorizontalAlign.Center
                                    td68.Text = "<font size=2>" & dt11.Rows(0)(1) & "</font>"
                                    tr6.Controls.Add(td68)
                                    tb.Controls.Add(tr6)

                                Else
                                    Dim td68 As New TableCell
                                    td68.Attributes.Add("width", "25%")
                                    td68.ColumnSpan = 15
                                    td68.HorizontalAlign = HorizontalAlign.Center
                                    td68.Text = "<font size=2>" & dr(3) & "</font>"
                                    tr6.Controls.Add(td68)
                                    tb.Controls.Add(tr6)
                                End If

                            End If


                        End If
                    Else
                        Dim td68 As New TableCell
                        td68.Attributes.Add("width", "25%")
                        td68.ColumnSpan = 15
                        td68.HorizontalAlign = HorizontalAlign.Center
                        td68.Text = "<font size=2>" & dr(3) & "</font>"
                        tr6.Controls.Add(td68)
                        tb.Controls.Add(tr6)
                    End If
                Else
                    Dim td68 As New TableCell
                    td68.Attributes.Add("width", "25%")
                    td68.ColumnSpan = 15
                    td68.HorizontalAlign = HorizontalAlign.Center
                    td68.Text = "<font size=2>" & dr(3) & "</font>"
                    tr6.Controls.Add(td68)
                    tb.Controls.Add(tr6)
                End If

            Next
            Dim l3 As New TableRow
            Dim ld3 As New TableCell
            ld3.Attributes.Add("width", "100%")
            ld3.ColumnSpan = 80
            ld3.HorizontalAlign = HorizontalAlign.Center
            ld3.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
            l3.Controls.Add(ld3)
            tb.Controls.Add(l3)
            Me.Panel1.Controls.Add(tb)
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Employee Does not Exists');")
            cl_script1.Append("       window.open('atterepo.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
    End Sub

End Class
