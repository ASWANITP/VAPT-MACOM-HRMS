Imports System.Data
Imports System.Data.OracleClient
Partial Class Emp_Current_select_bd1dc25f6154
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim str, str1 As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "To View Current Status of Employees"

        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Cmb_Department.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)

        If Not IsPostBack Then
            
            str1 = "select 0 as depid,' SELECT ALL DEPARTMENTS' as depname from dual union select distinct d.dep_id as depid,d.dep_name as depname from department_mst d,employee_master e,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.status_id=1 and e.department_id=d.dep_id order by depname"
            dt1 = oh.ExecuteDataSet(str1).Tables(0)
            Me.Cmb_Department.DataSource = dt1
            Me.Cmb_Department.DataTextField = dt1.Columns(1).ColumnName
            Me.Cmb_Department.DataValueField = dt1.Columns(0).ColumnName
            Me.Cmb_Department.DataBind()

        End If
    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        
        Me.Server.Transfer("emp_current_first.aspx?depid=" & Me.Cmb_Department.SelectedValue)

    End Sub
End Class
