Imports System.Data
Imports System.Data.OracleClient
Partial Class New_TA_Report_outstation_branch_b3ed3af28676
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    ' Dim oh As New helper.oracle.Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim str, str1 As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Branchwise Incentives and other Allowances Report"

        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Cmb_Branch.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)

        If Not IsPostBack Then
            If Me.Session("access_id") <> 33 Then

                Me.Server.Transfer("../show_err.aspx")

            Else

                str = "select branch_id as branchid,branch_id||'     '||branch_name from branch_master order by branchid"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Me.Cmb_Branch.DataSource = dt
                Me.Cmb_Branch.DataValueField = dt.Columns(0).ColumnName
                Me.Cmb_Branch.DataTextField = dt.Columns(1).ColumnName
                Me.Cmb_Branch.DataBind()

                str1 = "select branch_id as branchid,branch_id||'     '||branch_name from branch_master order by branchid"
                dt1 = oh.ExecuteDataSet(str1).Tables(0)
                Me.Cmb_BranchTo.DataSource = dt1
                Me.Cmb_BranchTo.DataValueField = dt1.Columns(0).ColumnName
                Me.Cmb_BranchTo.DataTextField = dt1.Columns(1).ColumnName
                Me.Cmb_BranchTo.DataBind()


            End If

        End If
    End Sub

    Protected Sub Cmd_Report_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Report.Click
        Me.Server.Transfer("outstation_report.aspx?branchid_from=" & Me.Cmb_Branch.SelectedValue & "&branchid_to=" & Me.Cmb_BranchTo.SelectedValue )
    End Sub
End Class
