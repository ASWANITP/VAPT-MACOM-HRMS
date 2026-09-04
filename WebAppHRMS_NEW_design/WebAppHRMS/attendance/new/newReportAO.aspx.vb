Imports System.Data
Imports System.Data.OracleClient
Partial Class test_newReportAO_7c32dcbd9719
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim ToDate, sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Branchwise Attendance Report in a given Period"
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtFromDate.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        If Not IsPostBack Then
            Me.ToDate = oh.ExecuteDataSet("select to_char(sysdate,'dd/Mon/yyyy') from dual").Tables(0).Rows(0)(0)
            Me.hidToday.Value = Me.ToDate
            Me.txtFromDate.Text = Me.ToDate
            Me.txtToDate.Text = Me.ToDate
            'select bc.old_id as BranchID,bc.old_id||' : '||bc.branch_name||' : Not Opened',bc.branch_name as Branch_name from before_completion bc where bc.branch_id is null union all 
            sql = "select bm.branch_id as BranchID,  bm.branch_name || ' : ' || bm.branch_id,  bm.branch_name as Branch_name  from branch_master bm  where bm.branch_id < 9999  and bm.firm_id=" & Session("firm_id") & "  order by Branch_name"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            Me.cmbBranch.DataSource = dt
            Me.cmbBranch.DataValueField = dt.Columns(0).ColumnName
            Me.cmbBranch.DataTextField = dt.Columns(1).ColumnName
            Me.cmbBranch.DataBind()
        End If
    End Sub

    Protected Sub cmdConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdConfirm.Click
        If Me.Session("branch_id") = 0 Then
            If Me.hidBranch.Value = 100000 Then
                Server.Transfer("newatt_rep.aspx?fdate=" & Me.txtFromDate.Text & "&tdate=" & Me.txtToDate.Text & "&stat=0")
            Else
                Server.Transfer("newatt_rep.aspx?fdate=" & Me.txtFromDate.Text & "&tdate=" & Me.txtToDate.Text & "&bid=" & Me.hidBranch.Value & "&stat=1")
            End If
        Else
            'Server.Transfer("newatt_rep.aspx?fdate=" & Me.txtFromDate.Text & "&tdate=" & Me.txtToDate.Text)
            'Branch ID added as an argument..req.12043
            Server.Transfer("newatt_rep.aspx?fdate=" & Me.txtFromDate.Text & "&tdate=" & Me.txtToDate.Text & "&bid=" & Me.hidBranch.Value)
        End If
    End Sub
End Class
