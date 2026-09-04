Imports System.Data
Imports system.data.oracleclient



Partial Class dailyLeaveStatus_89f8a2bb3369
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim firmid As Integer
    Dim firm As String
    Dim sql As String
    Dim fmid As Integer
    Dim dt As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            firmid = Session("firm_id")
            Dim dtSelected As String
            dtSelected = Request.QueryString("argv")
            lblDate.Text = dtSelected.Trim()
            sql = "Select emp_code,emp_name,branch_name,post_name,dep_name,leavetype from (with empdata as(select m.emp_code,m.emp_name,b.branch_name,p.post_name,d.dep_name from employee_master m,employ_firm f, post_mst p, branch_master b ,department_mst d where m.emp_code=f.emp_code and m.post_id=p.post_id and m.branch_id=b.branch_id and m.department_id=d.dep_id and m.status_id=1 and f.firm_id in(" & firmid & ")),leavedata as (select t.emp_code,  case t.leave_id   when 1 then   'Casual'   when 2 then   'Sick'  when 3 then  'Earned'  when 4 then   'LOP'  end as leavetype from employ_leave_dtl t,  employ_firm      b,  employee_master  e where t.emp_code = b.emp_code and e.status_id=1 and t.emp_code = e.emp_code  and b.firm_id in (" & firmid & ") and  to_date('" & dtSelected & "') between t.leave_frdate and t.leave_todate and t.leave_process_id in (1, 2) union select c.emp_code,'Comp Off' as leavetype  from hrm_comp_appl c, employ_firm f, employee_master m where c.emp_code=f.emp_code and c.emp_code=m.emp_code and m.status_id=1 and f.firm_id in (" & firmid & ") and c.leave_dt =  to_date('" & dtSelected & "') and c.status_id=1  ), attdata as  ( select a.*  from attendance a,employee_master m,  employ_firm f where a.emp_code = f.emp_code and m.emp_code=a.emp_code  and f.firm_id in(" & firmid & ") and to_date(a.curr_date) =  to_date('" & dtSelected & "')  and a.pay_id not in (50,51,52,7) and a.M_TIME is null and m.status_id=1 ) select a.emp_code,emp.emp_name,emp.branch_name,emp.post_name,emp.dep_name , 'Absent' as leavetype from attdata a,empdata emp where a.EMP_CODE=emp.emp_code and a.emp_code not in (select ld.emp_code from leavedata ld) union select ld.emp_code,emp.emp_name, emp.branch_name,emp.post_name,emp.dep_name ,ld.leavetype from leavedata ld, empdata emp where ld.emp_code = emp.emp_code order by branch_name, dep_name,post_name )"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            GridView1.DataSource = dt
            GridView1.DataBind()
            Dim cnt As Integer
            cnt = dt.Rows.Count
            lblTotal.Text = "Total Employees : " & cnt.ToString()

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Failed to load details.');window.location ='leaveRptDateSelect.aspx';", True)
        End Try

    End Sub


End Class
