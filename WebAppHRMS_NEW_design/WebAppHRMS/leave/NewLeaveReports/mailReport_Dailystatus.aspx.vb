Imports System.Data
Imports system.data.oracleclient
Partial Class mailReport_Dailystatus_55cdfc835892
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim firmid As String
    Dim firm As String
    Dim sql As String
    Dim fmid As Integer
    Dim dt As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            lblMsg.Text = ""
            lblTotal.Visible = True
            Dim firmid As Integer
            firmid = Request.QueryString("argv")
            sql = "select f.firm_name from firm_master f where f.firm_id=" & firmid & ""
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows.Count > 0 Then
                lblSubHead.Text = dt.Rows(0)(0).ToString()
            End If
            sql = "select t.emp_code emp_code,  t.emp_name emp_name,  t.branch_name ,  t.post_name post_name, t.dep_name dep_name,  t.reason REMARK  from hrm_daily_leave_data_new t where t.firm_id= " & firmid & "  and to_date(t.current_date) = to_date(sysdate) order by branch_name"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows.Count > 0 Then
                GridView1.DataSource = dt
                GridView1.DataBind()
                Dim cnt As Integer
                cnt = dt.Rows.Count
                lblTotal.Text = "Total Employees : " & cnt.ToString()
            Else
                lblTotal.Visible = False
                lblMsg.Text = "No Data found !"
            End If
        Catch ex As Exception
            lblMsg.Text = "Failed to load details" & ex.Message
            lblTotal.Visible = False
        End Try
    End Sub


    Protected Sub cmdClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Dim CloseDialog As String
        CloseDialog = "<script>window.close();</script>"
        ClientScript.RegisterStartupScript([GetType], "Close", CloseDialog)
    End Sub
End Class
