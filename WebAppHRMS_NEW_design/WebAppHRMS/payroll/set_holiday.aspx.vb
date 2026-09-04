Imports System.Data
Imports System.Data.OracleClient

Partial Class PF_set_holiday_983b32f82317
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.Session("access_id") = 33 Then
            If Not IsPostBack Then
                Dim dt As New DataTable
                dt = oh.ExecuteDataSet("select br.BRANCH_ID,br.BRANCH_NAME from branch br where br.BRANCH_ID not in (select branch_id from branch_holiday) order by br.BRANCH_NAME").Tables(0)
                Me.cmb_branch.DataSource = dt
                Me.cmb_branch.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_branch.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_branch.DataBind()
            End If
        Else
            Server.Transfer("../show_err.aspx")
        End If
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.cmb_branch.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim param(2) As OracleParameter
        param(0) = New OracleParameter("brid", OracleType.Number)
        param(0).Direction = ParameterDirection.Input
        param(0).Value = Me.cmb_branch.SelectedValue


        param(1) = New OracleParameter("hoid", OracleType.Number)
        param(1).Direction = ParameterDirection.Input
        param(1).Value = Me.cmb_hol.SelectedValue

        param(2) = New OracleParameter("flag", OracleType.Number)
        param(2).Direction = ParameterDirection.Output

        oh.ExecuteNonQuery("hrm_set_branch_holiday", param)
        Dim status As Integer
        status = param(2).Value
        If status = 1 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Confirmed Successfully');")
            cl_script1.Append("         window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please try again');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If

    End Sub
End Class
