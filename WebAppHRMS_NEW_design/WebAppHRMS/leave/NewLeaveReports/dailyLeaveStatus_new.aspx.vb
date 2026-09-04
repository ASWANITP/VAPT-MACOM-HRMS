Imports System.Data
Imports system.data.oracleclient



Partial Class dailyLeaveStatus_new_3e95c9886762
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim firmid As Integer
    Dim firm As String
    Dim sql As String
    Dim fmid As Integer
    Dim dt As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            lblMsg.Visible = False
            lblmsghead.Visible = False
            firmid = Session("firm_id")
            lblDate.Text = Convert.ToDateTime(DateTime.Today).ToString("dd-MMM-yyyy")

            'Modified by Sajiny as per req id 13871
            sql = "select t.emp_code,t.emp_name,t.branch_name,t.post_name,t.status,t.reason,t.leave_status,t.sanctioned_by,t.monthly,t.yearly,decode(t.status,'LEAVE','1','COMP OFF','2','TOUR','3','ABSENT','4','TOO LATE','5') AS STATUS1,decode(t.LEAVE_status,'APPLIED','1','RECOMMEDED','2','SANCTIONED','3','REJECTED','4') AS LEAVESTATUS1 from hrm_daily_leave_status_new t where  t.firm_id= " & firmid & " and to_date(t.processed_date) = to_date(sysdate) ORDER BY STATUS1,LEAVESTATUS1"
            '....................

            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows.Count > 0 Then
                GridView1.DataSource = dt
                GridView1.DataBind()
                Dim cnt As Integer
                cnt = dt.Rows.Count
                lblmsghead.Visible = True
                lblTotal.Text = "Total Employees : " & cnt.ToString()
            Else
                lblMsg.Visible = True
                lblmsghead.Visible = False
                lblMsg.Text = "No details available!"
                lblTotal.Visible = False
            End If

        Catch ex As Exception
            Server.Transfer("../../home.aspx")
        End Try
    End Sub

End Class
