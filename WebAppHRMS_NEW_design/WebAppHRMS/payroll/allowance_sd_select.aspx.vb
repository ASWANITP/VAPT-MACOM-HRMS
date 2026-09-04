Imports System.Data
Imports System.Data.OracleClient
Partial Class SD_CONFIRM_REPORT_allowance_sd_select_b49557c14996
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim str, str1 As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Report of Employees Allowances in SD"

        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Cmb_Department.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)

        If Not IsPostBack Then

            str = "select -99 as All_id,'ALL INCENTIVES'as allname from dual union select a.all_id as All_id,a.all_name as allname from incentives_allowances_master a order by allname"
            dt = oh.ExecuteDataSet(str).Tables(0)
            Me.Cmb_Incentive.DataSource = dt
            Me.Cmb_Incentive.DataTextField = dt.Columns(1).ColumnName
            Me.Cmb_Incentive.DataValueField = dt.Columns(0).ColumnName
            Me.Cmb_Incentive.DataBind()
            Me.Cmb_Incentive.SelectedValue = -99

            str1 = "select 0 as depid,'ALL DEPARTMENTS' as depname from dual union select dep_id as depid,dep_name as depname from department_mst order by depname"
            dt1 = oh.ExecuteDataSet(str1).Tables(0)
            Me.Cmb_Department.DataSource = dt1
            Me.Cmb_Department.DataTextField = dt1.Columns(1).ColumnName
            Me.Cmb_Department.DataValueField = dt1.Columns(0).ColumnName
            Me.Cmb_Department.DataBind()
            Me.Cmb_Department.SelectedValue = 0

        End If

    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        Me.Server.Transfer("sd_confirm_report.aspx?allid=" & Me.Cmb_Incentive.SelectedValue & "&depid=" & Me.Hid_Department.Value)
    End Sub
End Class
