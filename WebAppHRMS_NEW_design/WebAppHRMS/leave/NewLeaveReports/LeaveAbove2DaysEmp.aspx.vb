Imports System.Data
Imports system.data.oracleclient
Partial Class LeaveAbove2DaysEmp_8c39c2921599
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
            firm = Session("firm_name")
            Dim user() As String
            user = Session("user_id").ToString.Split("!")
            Dim param, frmdate, todate, ecode As String
            ecode = Request.QueryString("eid")
            param = Session("rpt_Leavedate_sel")
            Dim a() As String
            a = param.Split(",")
            frmdate = a(0)
            todate = a(1)
            lblDate.Text = a(0) & "   --   " & a(1)
            sql = "select t.emp_code,e.emp_name, sum(t.leave_days) leave_count,br.branch_name, p.post_name,d.dep_name from employ_leave_dtl t,employ_firm b,department_mst d, post_mst p, employee_master e, branch_master br where t.emp_code=b.emp_code and t.emp_code=e.emp_code and e.department_id=d.dep_id and e.post_id=p.post_id  and e.branch_id = br.branch_id and b.firm_id in (" & firmid & ")  and t.leave_frdate between to_date('" & frmdate & "') and to_date('" & todate & "') and t.leave_process_id in (1,2) group by t.emp_code,d.dep_name,p.post_name,br.branch_name, e.emp_name having sum(t.leave_days)>2 and t.emp_code = " & ecode & " order by br.branch_name"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            GridView1.DataSource = dt
            GridView1.DataBind()

            sql = "select rownum as slno, to_char(t.leave_frdate,'DD-Mon-YYYY') leave_frdate, to_char(t.leave_todate,'DD-Mon-YYYY') leave_todate,t.leave_days as days,case t.leave_id when 1 then 'Casual' when 2 then 'Sick' when 3 then 'Earned' when 4 then 'LOP' end as leavetype from employ_leave_dtl t,employ_firm b, employee_master e  where t.emp_code=b.emp_code and t.emp_code=e.emp_code and  b.firm_id in (" & firmid & ")  and t.leave_frdate between to_date('" & frmdate & "') and to_date('" & todate & "') and t.leave_process_id in (1,2)  and t.emp_code=" & ecode & ""
            dt = oh.ExecuteDataSet(sql).Tables(0)
            GridView2.DataSource = dt
            GridView2.DataBind()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Failed to load details.');window.location ='showLeaveAbove2Days.aspx';", True)
        End Try
    End Sub


End Class
