Imports System.Data
Imports System.Data.OracleClient
Partial Class Employee_status_emp_app_report_ffd85f976419
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim firm_desig As Integer = Me.Request.QueryString("firm_desig")
        Dim firmid As Integer = Me.Request.QueryString("designation")
        Dim jtype As Integer = Me.Request.QueryString("jointype")
        Dim emptype As Integer = Me.Request.QueryString("emptype")
        Dim datetype As Integer = Me.Request.QueryString("date_type")
        Dim firm As Integer
        Dim desig As Integer
        firm = 0
        desig = 0


        If firm_desig = 1 Then
            firm = firmid
        ElseIf firm_desig = 2 Then
            desig = firmid
        End If
        Dim str As String
        If jtype = 1 Then   ' appointed all..both regularised and new join
            If emptype = 3 Then     ' both permanant and Outsource
                If firm <> 0 And desig = 0 Then
                    '                  0          1           2                3                             4                               5                            6             7                8         9
                    str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep,employ_firm f where em.emp_code=f.emp_code and f.firm_id=fm.firm_id and fm.firm_id=" & Session("firm_id") & " and et.branch_id = bm.BRANCH_ID  and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
                ElseIf firm = 0 And desig <> 0 Then
                    str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep,employ_firm f where em.emp_code=f.emp_code and f.firm_id=fm.firm_id and fm.firm_id=" & Session("firm_id") & " and et.branch_id = bm.BRANCH_ID and ep.designation_id=" & desig & "  and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
                ElseIf firm <> 0 And desig <> 0 Then
                    str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep,employ_firm f where em.emp_code=f.emp_code and f.firm_id=fm.firm_id and fm.firm_id=" & Session("firm_id") & " and et.branch_id = bm.BRANCH_ID  and ep.designation_id=" & desig & "  and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
                Else
                    str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep,employ_firm f where em.emp_code=f.emp_code and f.firm_id=fm.firm_id and fm.firm_id=" & Session("firm_id") & " and et.branch_id = bm.BRANCH_ID and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
                End If

            ElseIf emptype = 1 Or emptype = 2 Then    ' permanant only
                If firm <> 0 And desig = 0 Then
                    str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep,employ_firm f where em.emp_code=f.emp_code and f.firm_id=fm.firm_id and fm.firm_id=" & Session("firm_id") & " and et.branch_id = bm.BRANCH_ID and em.emp_type=" & emptype & "  and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
                ElseIf firm = 0 And desig <> 0 Then
                    str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep,employ_firm f where em.emp_code=f.emp_code and f.firm_id=fm.firm_id and fm.firm_id=" & Session("firm_id") & " and et.branch_id = bm.BRANCH_ID and em.emp_type=" & emptype & " and ep.designation_id=" & desig & "  and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
                ElseIf firm <> 0 And desig <> 0 Then
                    str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep,employ_firm f where em.emp_code=f.emp_code and f.firm_id=fm.firm_id and fm.firm_id=" & Session("firm_id") & " and et.branch_id = bm.BRANCH_ID and em.emp_type=" & emptype & "  and ep.designation_id=" & desig & "  and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
                Else
                    str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep,employ_firm f where em.emp_code=f.emp_code and f.firm_id=fm.firm_id and fm.firm_id=" & Session("firm_id") & " and et.branch_id = bm.BRANCH_ID and em.emp_type=" & emptype & " and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
                End If

            End If

        ElseIf jtype = 2 Then   '//////only New Joining.....

            If emptype = 3 Then     ' both permanant and Outsource

                If firm <> 0 And desig = 0 Then
                    '                  0          1           2                3           4         5               6          7                      8
                    str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep where em.firm_id = fm.firm_id and et.branch_id = bm.BRANCH_ID and em.emp_code in(select new_empcode from employee_master_dtl )  and em.firm_id = " & firm & " and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
                ElseIf firm = 0 And desig <> 0 Then
                    str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep where em.firm_id = fm.firm_id and et.branch_id = bm.BRANCH_ID and em.emp_code in(select new_empcode from employee_master_dtl )  and ep.designation_id=" & desig & "  and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
                ElseIf firm <> 0 And desig <> 0 Then
                    str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep where em.firm_id = fm.firm_id and et.branch_id = bm.BRANCH_ID and em.emp_code in(select new_empcode from employee_master_dtl )  and em.firm_id = " & firm & " and ep.designation_id=" & desig & "  and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
                Else
                    str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep where em.firm_id = fm.firm_id and et.branch_id = bm.BRANCH_ID and em.emp_code in(select new_empcode from employee_master_dtl )  and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
                End If

            ElseIf emptype = 1 Or emptype = 2 Then    ' permanant only
                If firm <> 0 And desig = 0 Then
                    str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep where em.firm_id = fm.firm_id and et.branch_id = bm.BRANCH_ID and em.emp_code in(select new_empcode from employee_master_dtl and em.emp_type=" & emptype & " and em.firm_id = " & firm & " and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
                ElseIf firm = 0 And desig <> 0 Then
                    str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep where em.firm_id = fm.firm_id and et.branch_id = bm.BRANCH_ID and em.emp_code in(select new_empcode from employee_master_dtl and em.emp_type=" & emptype & " and ep.designation_id=" & desig & "  and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
                ElseIf firm <> 0 And desig <> 0 Then
                    str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep where em.firm_id = fm.firm_id and et.branch_id = bm.BRANCH_ID and em.emp_code in(select new_empcode from employee_master_dtl and em.emp_type=" & emptype & " and em.firm_id = " & firm & " and ep.designation_id=" & desig & "  and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
                Else
                    str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep where em.firm_id = fm.firm_id and et.branch_id = bm.BRANCH_ID and em.emp_code in(select new_empcode from employee_master_dtl and em.emp_type=" & emptype & " and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
                End If

            End If

            'one extra column old employee code
        ElseIf jtype = 3 Then    '/////////////only Regularised   so not checking whether perm or outsource..
            If firm <> 0 And desig = 0 Then
                '                  0          1           2                3           4         5               6          7                      8
                str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep,employee_master_dtl ed where em.emp_code=ed.new_empcode and em.firm_id = fm.firm_id and et.branch_id = bm.BRANCH_ID and em.emp_code in(select new_empcode from employee_master_dtl )  and em.firm_id = " & firm & " and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
            ElseIf firm = 0 And desig <> 0 Then
                str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep,employee_master_dtl ed where em.emp_code=ed.new_empcode and em.firm_id = fm.firm_id and et.branch_id = bm.BRANCH_ID and em.emp_code in(select new_empcode from employee_master_dtl )  and ep.designation_id=" & desig & "  and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
            ElseIf firm <> 0 And desig <> 0 Then
                str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep,employee_master_dtl ed where em.emp_code=ed.new_empcode and em.firm_id = fm.firm_id and et.branch_id = bm.BRANCH_ID and em.emp_code in(select new_empcode from employee_master_dtl )  and em.firm_id = " & firm & " and ep.designation_id=" & desig & "  and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
            Else
                str = "select em.emp_code,em.emp_name,fm.firm_abbr,bm.branch_name as joining_branch, bm.state_name as joining_state,bm.ZONAL_NAME as joining_zonal,dp.dep_name,dm.designation,pm.post_name,em.join_dt,s.remark as current_status,qm.qualification,ep.basic_pay from employee_master em,status_mst s,department_mst dp,firm_master fm, branch_dtl_new bm,employ_qualification_dtl eq, qualification_master qm,designation_master dm,post_mst pm,employ_transfer_dtl et,employ_promotion_dtl ep,employee_master_dtl ed where em.emp_code=ed.new_empcode and em.firm_id = fm.firm_id and et.branch_id = bm.BRANCH_ID and em.emp_code in(select new_empcode from employee_master_dtl )  and to_date(em.join_dt) >= to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(em.join_dt) <= to_date('" & Me.Request.QueryString("todate") & "') and et.department_id = dp.dep_id and em.status_id = s.status_id and ep.designation_id = dm.designation_id and em.post_id = pm.post_id and em.emp_code = eq.emp_code and eq.qualification = qm.qualification_id and em.emp_code=ep.emp_code and ep.status_id=1 and eq.year_pass in (select max(year_pass) from employ_qualification_dtl q where q.emp_code = em.emp_code) and em.emp_code = et.emp_code and et.status_id = 8 and et.from_dt in (select min(from_dt) from employ_transfer_dtl where emp_code = em.emp_code) order by em.join_dt,em.emp_code"
            End If

        End If




        Dim dt As New DataTable
        dt = oh.ExecuteDataSet(str).Tables(0)
        Dim tab1 As New Table
        tab1.BorderWidth = 1
        tab1.Attributes.Add("width", "100%")
        '1st row declaration
        Dim tabr1 As New TableRow
        tabr1.Width = 21
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.Attributes.Add("bordercolor", "red")
        'cell declaration
        Dim tabc1 As New TableCell
        tabc1.Attributes.Add("forecolor", "blue")
        tabc1.Attributes.Add("align", "center")
        tabc1.ColumnSpan = 21
        ' tabc1.Text = "<body align=center ><b><font size=4>MANAPPURAM GROUP OF COMPANIES</font></b></body>"
        tabc1.Text = "<body align=center ><b><font size=4>" & Me.Session("firm_name") & "</font></b></body>"


        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab1.Controls.Add(tabr1)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Width = 21
        'cell declaration
        Dim tabc2 As New TableCell
        tabc2.ColumnSpan = 21
        tabc2.Attributes.Add("align", "center")
        '  Dim kt As DataTable = oh.ExecuteDataSet("select emp_code || ' - ' || emp_name from employee_master e where e.emp_code =" & Me.Request.QueryString("empcode")).Tables(0)
        If jtype = 1 Then
            tabc2.Text = "<b><font size=2>Employees(both New and Regularised) Appointed Between " & Me.Request.QueryString("fromdate") & "and " & Me.Request.QueryString("todate") & "</font></b>"
        ElseIf jtype = 2 Then
            tabc2.Text = "<b><font size=2>Employees(New) Appointed Between " & Me.Request.QueryString("fromdate") & "and " & Me.Request.QueryString("todate") & "</font></b>"
        ElseIf jtype = 3 Then
            tabc2.Text = "<b><font size=2>Regularised Employees Appointed Between " & Me.Request.QueryString("fromdate") & "and " & Me.Request.QueryString("todate") & "</font></b>"
        End If

        tabc2.ForeColor = Drawing.Color.Maroon
        tabr2.Controls.Add(tabc2)
        tab1.Controls.Add(tabr2)
        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Attributes.Add("bgcolor", "#ffcca3")

        'cell declaration
        Dim tabcc3 As New TableCell
        tabcc3.ColumnSpan = 7
        tabcc3.Attributes.Add("align", "left")
        tabcc3.Text = "<b><font size=3>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
        tabcc3.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc3)
        tab1.Controls.Add(tabrr3)

        Dim tabcct As New TableCell
        tabcct.ColumnSpan = 7
        tabcct.Attributes.Add("align", "center")
        'Dim kt As DataTable = oh.ExecuteDataSet("select emp_code || ' - ' || emp_name from employee_master e where e.emp_code =" & Me.Request.QueryString("empcode")).Tables(0)

        tabcct.Text = " "
        tabcct.ForeColor = Drawing.Color.Blue
        tabrr3.Controls.Add(tabcct)
        tab1.Controls.Add(tabrr3)


        'cell declaration
        Dim tabcc4 As New TableCell
        tabcc4.ColumnSpan = 7
        tabcc4.Attributes.Add("align", "right")
        Dim dat As String
        Dim hr As Integer = Date.Now.Hour
        If hr > 12 Then
            dat = "PM"
        Else
            dat = "AM"
        End If
        If (hr = 0) Then
            hr = 12
        End If

        If (hr > 12) Then
            hr = hr - 12
        End If

        tabcc4.Text = "<b><font size=3>TIME: " & hr.ToString & ":" & Date.Now.Minute & ":" & Date.Now.Second & " " & dat & "</font></b>"
        tabcc4.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc4)
        tab1.Controls.Add(tabrr3)

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabline As New TableRow
        tabline.Width = 21
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 21
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab1.Controls.Add(tabline)



        ''''''''''''''''''''''''''''''''''''''''
        Dim tabr5 As New TableRow
        tabr5.Width = 21
        tabr5.ForeColor = Drawing.Color.DarkRed
        Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7, tabr5c8, tabr5c9, tabr5c10, tabr5c11, tabr5c12, tabr5c13 As New TableCell

        tabr5c1.ColumnSpan = "1"
        tabr5c2.ColumnSpan = "2"
        tabr5c3.ColumnSpan = "1"
        tabr5c4.ColumnSpan = "2"
        tabr5c5.ColumnSpan = "2"
        tabr5c6.ColumnSpan = "2"
        tabr5c7.ColumnSpan = "2"
        tabr5c8.ColumnSpan = "2"
        tabr5c9.ColumnSpan = "2"
        tabr5c10.ColumnSpan = "1"
        tabr5c11.ColumnSpan = "1"
        tabr5c12.ColumnSpan = "2"
        tabr5c13.ColumnSpan = "1"

        tabr5c1.HorizontalAlign = HorizontalAlign.Left
        tabr5c2.HorizontalAlign = HorizontalAlign.Left
        tabr5c3.HorizontalAlign = HorizontalAlign.Left
        tabr5c4.HorizontalAlign = HorizontalAlign.Left
        tabr5c5.HorizontalAlign = HorizontalAlign.Left
        tabr5c6.HorizontalAlign = HorizontalAlign.Left
        tabr5c7.HorizontalAlign = HorizontalAlign.Left
        tabr5c8.HorizontalAlign = HorizontalAlign.Left
        tabr5c9.HorizontalAlign = HorizontalAlign.Left
        tabr5c10.HorizontalAlign = HorizontalAlign.Left
        tabr5c10.HorizontalAlign = HorizontalAlign.Left
        tabr5c12.HorizontalAlign = HorizontalAlign.Right
        tabr5c13.HorizontalAlign = HorizontalAlign.Center

        tabr5c1.Text = "<b><font size=2.5>Emp Code.</font></b>"
        tabr5c2.Text = "<b><font size=2.5>Emp Name</font></b>"
        tabr5c3.Text = "<b><font size=2.5>Firm</font></b>"
        tabr5c4.Text = "<b><font size=2.5>Joining Branch</font></b>"
        tabr5c5.Text = "<b><font size=2.5>Joining State</font></b>"
        tabr5c6.Text = "<b><font size=2.5>Joining Zonal</font></b>"
        tabr5c7.Text = "<b><font size=2.5>Department</font></b>"
        tabr5c8.Text = "<b><font size=2.5>Designation</font></b>"
        tabr5c9.Text = "<b><font size=2.5>Post</font></b>"
        tabr5c10.Text = "<b><font size=2.5>Joining date</font></b>"
        tabr5c11.Text = "<b><font size=2.5>Qualification</font></b>"
        tabr5c12.Text = "<b><font size=2.5>Basic</font></b>"
        tabr5c13.Text = "<b><font size=2.5>Current Status</font></b>"

        tabr5.Controls.Add(tabr5c1)
        tabr5.Controls.Add(tabr5c2)
        tabr5.Controls.Add(tabr5c3)
        tabr5.Controls.Add(tabr5c4)
        tabr5.Controls.Add(tabr5c5)
        tabr5.Controls.Add(tabr5c6)
        tabr5.Controls.Add(tabr5c7)
        tabr5.Controls.Add(tabr5c8)
        tabr5.Controls.Add(tabr5c9)
        tabr5.Controls.Add(tabr5c10)
        tabr5.Controls.Add(tabr5c11)
        tabr5.Controls.Add(tabr5c12)
        tabr5.Controls.Add(tabr5c13)
        tab1.Controls.Add(tabr5)

        '''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 21
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 21
        tabcellline1.Text = "<hr>"
        tabline1.Controls.Add(tabcellline1)
        tab1.Controls.Add(tabline1)
        '''''''''''''''''''''''''''''''''
        Dim cn As Integer = 0
        Dim colors As String
        colors = "#fff7ff"
        Dim dr As DataRow
        Dim jddate As String = ""

        For Each dr In dt.Rows
            cn = cn + 1
            If colors.Equals("#fff7ff") = True Then
                colors = "#eef9ff"
            Else
                colors = "#fff7ff"
            End If
            If jddate <> dr(9).ToString Then
                Dim rdate As New TableRow
                rdate.Width = 9
                Dim rd As New TableCell
                rd.ColumnSpan = 9
                rd.HorizontalAlign = HorizontalAlign.Center
                rd.Text = "<b><font size=2>Appointed Date:&nbsp;" & Format(dr(9), "dd/MMM/yyyy") & "</font></b>"
                rdate.Controls.Add(rd)
                tab1.Controls.Add(rdate)
            End If
            jddate = dr(9).ToString

            Dim tabr6 As New TableRow
            tabr6.Width = 21
            tabr6.Attributes.Add("bgcolor", colors)
            Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7, tabr6c8, tabr6c9, tabr6c10, tabr6c11, tabr6c12, tabr6c13 As New TableCell
            tabr6c1.ColumnSpan = "1"
            tabr6c2.ColumnSpan = "2"
            tabr6c3.ColumnSpan = "1"
            tabr6c4.ColumnSpan = "2"
            tabr6c5.ColumnSpan = "2"
            tabr6c6.ColumnSpan = "2"
            tabr6c7.ColumnSpan = "2"
            tabr6c8.ColumnSpan = "2"
            tabr6c9.ColumnSpan = "2"
            tabr6c10.ColumnSpan = "1"
            tabr6c11.ColumnSpan = "1"
            tabr6c12.ColumnSpan = "2"
            tabr6c13.ColumnSpan = "1"

            tabr6c1.HorizontalAlign = HorizontalAlign.Left
            tabr6c2.HorizontalAlign = HorizontalAlign.Left
            tabr6c3.HorizontalAlign = HorizontalAlign.Left
            tabr6c4.HorizontalAlign = HorizontalAlign.Left
            tabr6c5.HorizontalAlign = HorizontalAlign.Left
            tabr6c6.HorizontalAlign = HorizontalAlign.Left
            tabr6c7.HorizontalAlign = HorizontalAlign.Left
            tabr6c8.HorizontalAlign = HorizontalAlign.Left
            tabr6c9.HorizontalAlign = HorizontalAlign.Left
            tabr6c10.HorizontalAlign = HorizontalAlign.Left
            tabr6c11.HorizontalAlign = HorizontalAlign.Left
            tabr6c12.HorizontalAlign = HorizontalAlign.Left
            tabr6c13.HorizontalAlign = HorizontalAlign.Right

            tabr6c1.Text = "<font size=2>" & dr(0) & "&nbsp;</font>"
            tabr6c2.Text = "<font size=2>" & dr(1) & "&nbsp;</font>"
            tabr6c3.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
            tabr6c4.Text = "<font size=2>" & dr(3) & "&nbsp;</font>"
            tabr6c5.Text = "<font size=2>" & dr(4) & "&nbsp;</font>"
            tabr6c6.Text = "<font size=2>" & dr(5) & "&nbsp;</font>"
            tabr6c7.Text = "<font size=2>" & dr(6) & "&nbsp;</font>"
            tabr6c8.Text = "<font size=2>" & dr(7) & "</font>"
            tabr6c9.Text = "<font size=2>" & dr(8) & "&nbsp;</font>"
            tabr6c10.Text = "<font size=2>" & Format(dr(9), "dd/MMM/yyyy") & "&nbsp;</font>"
            tabr6c11.Text = "<font size=2>" & dr(11) & "&nbsp;</font>"
            tabr6c12.Text = "<font size=2>" & dr(12) & "&nbsp;</font>"
            tabr6c13.Text = "<font size=2>" & dr(10) & "&nbsp;</font>"

            tabr6.Controls.Add(tabr6c1)
            tabr6.Controls.Add(tabr6c2)
            tabr6.Controls.Add(tabr6c3)
            tabr6.Controls.Add(tabr6c4)
            tabr6.Controls.Add(tabr6c5)
            tabr6.Controls.Add(tabr6c6)
            tabr6.Controls.Add(tabr6c7)
            tabr6.Controls.Add(tabr6c8)
            tabr6.Controls.Add(tabr6c9)
            tabr6.Controls.Add(tabr6c10)
            tabr6.Controls.Add(tabr6c11)
            tabr6.Controls.Add(tabr6c12)
            tabr6.Controls.Add(tabr6c13)
            tab1.Controls.Add(tabr6)
        Next
        Dim tablinew As New TableRow
        tablinew.Width = 21
        Dim tabcelllinew As New TableCell
        tabcelllinew.ColumnSpan = 21
        tabcelllinew.Text = "<hr>"
        tablinew.Controls.Add(tabcelllinew)
        tab1.Controls.Add(tablinew)

        Dim tbrow As New TableRow
        tbrow.Width = 21
        tbrow.ForeColor = Drawing.Color.Red
        tbrow.BackColor = Drawing.Color.Wheat
        Dim tabcv As New TableCell
    
        tabcv.ColumnSpan = 21
        tabcv.Text = "<body align=center ><b><font size=4>Total " & cn & "  Employees</font></b></body>"

        tbrow.Controls.Add(tabcv)
        tab1.Controls.Add(tbrow)

        Dim tablinew1 As New TableRow
        tablinew1.Width = 21
        Dim tabcelllinew1 As New TableCell
        tabcelllinew1.ColumnSpan = 21
        tabcelllinew1.Text = "<hr>"
        tablinew1.Controls.Add(tabcelllinew1)
        tab1.Controls.Add(tablinew1)

        Me.Panel1.Controls.Add(tab1)


    End Sub
End Class
