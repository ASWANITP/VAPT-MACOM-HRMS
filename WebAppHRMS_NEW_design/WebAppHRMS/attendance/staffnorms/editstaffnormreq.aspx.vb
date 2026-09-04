Imports System.Data
Imports System.Data.OracleClient
Partial Class edit_staff_norms_req_editstaffnormreq_611a2cea2172
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txt_req.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Me.txt_req.Attributes.Add("onkeyup", "checknum(event)")
        Dim usr() As String
        usr = Session("user_id").ToString().Split("!")
        If Not IsPostBack Then
            dt = oh.ExecuteDataSet("select t.emp_id from form_accessibility t where t.emp_id=" & usr(0) & " and t.form_id=65").Tables(0)
            If dt.Rows.Count = 0 Then
                Server.Transfer("../../show_err.aspx")
            Else
                dt = oh.ExecuteDataSet("select norm_id,dept_name,requirement from staff_norm_ho order by dept_name").Tables(0)
                Me.cmb_dep.DataSource = dt
                Me.cmb_dep.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_dep.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_dep.DataBind()
                Me.txt_req.Text = dt.Rows(0)(2)
            End If
        End If

    End Sub

    Protected Sub cmb_dep_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_dep.SelectedIndexChanged
        Dim dt As DataTable = oh.ExecuteDataSet("select requirement from staff_norm_ho where norm_id=" & Me.cmb_dep.SelectedValue).Tables(0)
        Me.txt_req.Text = dt.Rows(0)(0)
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim sql As String
        sql = "update staff_norm_ho set requirement=" & Me.txt_req.Text & " where norm_id=" & Me.cmb_dep.SelectedValue
        oh.ExecuteNonQuery(sql)
        Dim scrp_val As New System.Text.StringBuilder
        scrp_val.Append("   alert('successfully saved');")
        scrp_val.Append("window.open('editstaffnormreq.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", scrp_val.ToString, True)

    End Sub
End Class
