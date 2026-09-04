Imports System.Data
Imports System.Data.OracleClient
Partial Class Salary_Calculation_salary_block_release_bb7ba7c84202
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2 As New DataTable
    Dim oh As New helper.oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        Dim dt1 As DataTable = oh.ExecuteDataSet("select emp_id from form_accessibility where form_id=181 and emp_id=" & sf(0) & "").Tables(0)
        'Dim dt1 As DataTable = oh.ExecuteDataSet("select emp_code from punch_access where emp_code=" & sf(0) & " and status_id=1").Tables(0)
        If dt1.Rows.Count > 0 Then


            If Not IsPostBack Then
                dt = oh.ExecuteDataSet("select e.emp_code || ' --- ' || e.emp_name as empcode,e.emp_code from hrm_employ_verification h, employee_master_dtl em,employee_master e  where h.status_id = 1 and h.emp_code=e.emp_code and h.rec_by = 'BLOCK'  and h.emp_code = em.emp_code  and em.new_empcode is null union select  e.emp_code || ' --- ' || e.emp_name as empcode,e.emp_code  from hrm_employ_verification h, employee_master_dtl em,employee_master e  where h.status_id = 1 and h.emp_code=e.emp_code  and h.rec_by = 'BLOCK' and h.emp_code = em.emp_code and em.new_empcode is not null and em.new_empcode not in (select emp_Code from hrm_employ_verification) order by empcode").Tables(0)
                Me.Cmb_block.DataSource = dt
                Me.Cmb_block.DataTextField = dt.Columns(0).ColumnName
                Me.Cmb_block.DataValueField = dt.Columns(1).ColumnName
                Me.Cmb_block.DataBind()
            End If

        Else
            Server.Transfer("../show_err.aspx")

        End If
    End Sub


    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim script1 As New System.Text.StringBuilder
        Dim parameter(1) As OracleParameter
        parameter(0) = New OracleParameter("code", OracleType.Number, 150)
        parameter(0).Direction = ParameterDirection.Input
        parameter(0).Value = Me.cmb_block.SelectedValue

        parameter(1) = New OracleParameter("msg", OracleType.VarChar, 150)
        parameter(1).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("hrm_salary_block_release", parameter)

        Dim message As String
        message = parameter(1).Value

        script1.Append("        alert('" & message & "');")

        script1.Append("window.open('salary_block_release.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

    End Sub
End Class
