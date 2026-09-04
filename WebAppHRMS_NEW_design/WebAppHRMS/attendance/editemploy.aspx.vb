Imports System.Data.OracleClient
Imports System.Data

Partial Class employ_editemploy_778ffe944910
    Inherits System.Web.UI.Page

    Protected Sub cmb_id_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oh1 As New Helper.Oracle.OracleHelper
        Dim dtt1 As New DataTable
        dtt1 = oh1.ExecuteDataSet("select emp_name,branch_id,designation_id,department_id,shift_id from employee_master where emp_code=" & Me.cmb_id.SelectedValue & "").Tables(0)
        Me.txt_name.Text = dtt1.Rows(0)(0)
        Me.cmb_branch.SelectedValue = dtt1.Rows(0)(1)
        Me.cmb_desg.SelectedValue = dtt1.Rows(0)(2)
        Me.cmb_dept.SelectedValue = dtt1.Rows(0)(3)
        Me.cmb_shift.SelectedValue = dtt1.Rows(0)(4)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("branch_id") <> 0 Then
            Server.Transfer("../show_err.aspx")
        End If
        If Not IsPostBack Then

            Dim oh As New Helper.Oracle.OracleHelper
            Dim dt As New DataTable
            dt = oh.ExecuteDataSet("select shift_id,shift from time_tab").Tables(0)
            Me.cmb_shift.DataSource = dt
            Me.cmb_shift.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_shift.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_shift.DataBind()

            Dim dt1 As New DataTable
            dt1 = oh.ExecuteDataSet("select branch_id,branch_name from branch_master order by branch_name").Tables(0)
            Me.cmb_branch.DataSource = dt1
            Me.cmb_branch.DataTextField = dt1.Columns(1).ColumnName
            Me.cmb_branch.DataValueField = dt1.Columns(0).ColumnName
            Me.cmb_branch.DataBind()

            Dim dt2 As New DataTable
            dt2 = oh.ExecuteDataSet("select designation,designation_id from designation_mst order by designation").Tables(0)
            Me.cmb_desg.DataSource = dt2
            Me.cmb_desg.DataTextField = dt2.Columns(0).ColumnName
            Me.cmb_desg.DataValueField = dt2.Columns(1).ColumnName
            Me.cmb_desg.DataBind()

            Dim dt3 As New DataTable
            dt3 = oh.ExecuteDataSet("select dep_id,dep_name from department_mst order by dep_name").Tables(0)
            Me.cmb_dept.DataSource = dt3
            Me.cmb_dept.DataTextField = dt3.Columns(1).ColumnName
            Me.cmb_dept.DataValueField = dt3.Columns(0).ColumnName
            Me.cmb_dept.DataBind()
            Dim dt4 As New DataTable
            dt4 = oh.ExecuteDataSet("select emp_code from employee_master where shift_id not in (4,5) and emp_code >9999 order by emp_code").Tables(0)
            Me.cmb_id.DataSource = dt4
            Me.cmb_id.DataValueField = dt4.Columns(0).ColumnName
            Me.cmb_id.DataBind()

        End If
    End Sub

    Protected Sub btn_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        Dim ob As New Helper.Oracle.OracleHelper
        ob.ExecuteNonQuery("update employee_master set designation_id=" & Me.cmb_desg.SelectedValue & ",branch_id=" & Me.cmb_branch.SelectedValue & ",department_id=" & Me.cmb_dept.SelectedValue & ",shift_id=" & Me.cmb_shift.SelectedValue & " where emp_code=" & Me.cmb_id.SelectedValue)
        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("         alert('Updated');")
        cl_script0.Append("window.open('../home.aspx','_self')")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)

    End Sub
End Class
