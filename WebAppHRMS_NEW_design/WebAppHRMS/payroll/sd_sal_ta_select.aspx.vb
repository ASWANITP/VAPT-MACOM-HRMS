Imports System.Data
Imports System.Data.OracleClient
Partial Class sd_sal_ta_report_sd_sal_ta_select_9ce61f503296
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim str As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "SD Confirmed List Of Salary And Incentives"

        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Cmb_Department.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)

        If Not IsPostBack Then

            str = "select 0 as depid,' SELECT ALL DEPARTMENTS' as depname from dual union select dep_id as depid,upper(dep_name) as depname from department_mst order by depname"
            dt = oh.ExecuteDataSet(str).Tables(0)
            Cmb_Department.DataSource = dt
            Cmb_Department.DataValueField = dt.Columns(0).ColumnName
            Cmb_Department.DataTextField = dt.Columns(1).ColumnName
            Cmb_Department.DataBind()
            'Cmb_Department.SelectedValue = 0
        End If


    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        
        Me.Server.Transfer("sd_sal_inc_report.aspx?type=" & Me.Hid_Type.Value & "&depid=" & Me.Cmb_Department.SelectedValue & "&sdtype=" & Me.Hid_SDType.Value)

    End Sub
End Class
