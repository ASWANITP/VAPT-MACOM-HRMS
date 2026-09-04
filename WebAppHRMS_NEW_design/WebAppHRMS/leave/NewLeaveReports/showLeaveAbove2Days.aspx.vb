Imports System.Data
Imports system.data.oracleclient
Partial Class showLeaveAbove2Days_596a53452970
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
            Dim param, frmdate, todate As String
            param = Request.QueryString("argv")
            Dim a() As String
            a = param.Split(",")
            frmdate = a(0)
            todate = a(1)
            txtfrm.Text = frmdate
            txtTo.Text = todate
            lblDate.Text = frmdate & "    --    " & todate
            sql = "select t.emp_code,e.emp_name, sum(t.leave_days) leave_count,br.branch_name, p.post_name,d.dep_name from employ_leave_dtl t,employ_firm b,department_mst d, post_mst p, employee_master e, branch_master br where t.emp_code=b.emp_code and t.emp_code=e.emp_code and e.department_id=d.dep_id and e.post_id=p.post_id  and e.branch_id = br.branch_id and b.firm_id in (" & firmid & ")  and t.leave_frdate between to_date('" & frmdate & "') and to_date('" & todate & "') and t.leave_process_id in (1,2) group by t.emp_code,d.dep_name,p.post_name,br.branch_name, e.emp_name having sum(t.leave_days)>2 order by br.branch_name,d.dep_name,p.post_name"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            GridView1.DataSource = dt
            GridView1.DataBind()
            Dim cnt As Integer
            cnt = dt.Rows.Count
            lblTotal.Text = "Total Employees : " & cnt.ToString()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Failed to load details.');window.location ='LeaveAbove2Days.aspx';", True)
        End Try

    End Sub


End Class
