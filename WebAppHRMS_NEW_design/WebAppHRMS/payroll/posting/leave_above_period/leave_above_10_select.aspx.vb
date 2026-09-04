Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_above_10_select_821ce8f49183
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt1, dt2 As New DataTable
    Dim str1, str2 As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "To Find Employees Having Leave above a specified number of days from 1st January of Current Year"
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "Leave Report Based on Leave Days"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.subtitle = "Leave Report Based on Leave Days"

        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Txt_LeaveNo.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)

        If Not IsPostBack Then

            str1 = "select dm.designation_id,dm.designation from designation_master dm order by dm.designation"
            dt1 = oh.ExecuteDataSet(str1).Tables(0)
            Me.Cmb_Designation.DataSource = dt1
            Me.Cmb_Designation.DataTextField = dt1.Columns(1).ColumnName
            Me.Cmb_Designation.DataValueField = dt1.Columns(0).ColumnName
            Me.Cmb_Designation.DataBind()

            str2 = "select p.post_id,p.post_name from post_mst p order by p.post_name"
            dt2 = oh.ExecuteDataSet(str2).Tables(0)
            Me.Cmb_Post.DataSource = dt2
            Me.Cmb_Post.DataTextField = dt2.Columns(1).ColumnName
            Me.Cmb_Post.DataValueField = dt2.Columns(0).ColumnName
            Me.Cmb_Post.DataBind()

        End If

    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click

        Me.Server.Transfer("zonal_leave_above_10.aspx?&status=" & Me.Hid_Status.Value & "&leaveno=" & Me.Txt_LeaveNo.Text & "&designation=" & Me.Hid_Designation.Value & "&post=" & Me.Hid_Post.Value)

    End Sub
End Class
