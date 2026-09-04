Imports System.Data
Imports System.Data.OracleClient
Partial Class november_Block_employee_a351de278076
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Cmd_block_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_block.Click

        Dim script1 As New System.Text.StringBuilder
        Dim parameter(1) As OracleParameter
        parameter(0) = New OracleParameter("code", OracleType.Number, 150)
        parameter(0).Direction = ParameterDirection.Input
        parameter(0).Value = Me.Cmb_block.SelectedValue
        
        parameter(1) = New OracleParameter("msg", OracleType.VarChar, 150)
        parameter(1).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("hrm_salary_block", parameter)

        Dim message As String
        message = parameter(1).Value

        script1.Append("        alert('" & message & "');")

        script1.Append("window.open('Block_employee.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

    End Sub

    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ff As Integer = Session("firm_id")
        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        Dim dt1 As DataTable = oh.ExecuteDataSet("select emp_id from form_accessibility where form_id=181 and emp_id=" & sf(0) & "").Tables(0)
        'Dim dt1 As DataTable = oh.ExecuteDataSet("select emp_code from punch_access where emp_code=" & sf(0) & " and status_id=1").Tables(0)
        If dt1.Rows.Count > 0 Then


            If Not IsPostBack Then
                'dt = oh.ExecuteDataSet("select e.emp_code||'---'||e.emp_name,e.emp_code from employee_master e,salari s where s.emp_id=e.emp_code and e.emp_code>9999 and e.emp_code not in (select distinct emp_code from hrm_employ_verification ) union select e.emp_code||'---'||e.emp_name,e.emp_code from employee_master e,salari s where s.emp_id=e.emp_code and e.emp_code>9999 and e.emp_code in (select distinct emp_code from hrm_employ_verification  where status_id=0) union select e.emp_code||'---'||e.emp_name,e.emp_code from employee_master e,incentives_allowances_dtl i where i.emp_code=e.emp_code and e.emp_code>9999 and e.emp_code not in (select distinct emp_code from hrm_employ_verification) union select e.emp_code||'---'||e.emp_name,e.emp_code from employee_master e,incentives_allowances_dtl i,hrm_employ_verification hv where i.emp_code=e.emp_code and e.emp_code>9999 and e.emp_code in (select distinct emp_code from hrm_employ_verification  where status_id=0)").Tables(0)
                'dt = oh.ExecuteDataSet("select e.emp_code || '---' || name as emp_name, e.emp_code  from m_wage e, employee_master_dtl em where not exists (select emp_code from hrm_employ_verification h where status_id = 1  and h.emp_code = e.EMP_CODE) and e.emp_code = em.emp_code and em.new_empcode is null union select e.emp_code || '---' || name as emp_name, e.emp_code from m_wage e, employee_master_dtl em where not exists (select emp_code from hrm_employ_verification h where status_id = 1 and h.emp_code = e.EMP_CODE) and e.emp_code = em.emp_code and em.new_empcode is not null and em.new_empcode not in (select emp_code from m_wage) order by emp_name").Tables(0)
                dt = oh.ExecuteDataSet("select e.emp_code || '---' || name as emp_name, e.emp_code from m_wage e, employee_master_dtl em,employ_firm f where not exists (select h.emp_code  from hrm_employ_verification h,employ_firm f  where h.status_id = " & ff & "  and h.emp_code = e.EMP_CODE and f.emp_code=h.emp_code and f.firm_id=" & ff & ") and e.emp_code = em.emp_code and e.emp_code=f.emp_code and f.firm_id=" & ff & "   and em.new_empcode is null union select e.emp_code || '---' || name as emp_name, e.emp_code  from m_wage e,employee_master_dtl em,employ_firm f where not exists (select h.emp_code from hrm_employ_verification h,employ_firm f where h.status_id = " & ff & " and h.emp_code = e.EMP_CODE and h.emp_code=f.emp_code and f.firm_id=" & ff & ") and e.emp_code = em.emp_code  and em.new_empcode is not null and em.new_empcode not in (select w.emp_code from m_wage w,employ_firm f where w.emp_code=f.emp_code and f.firm_id=" & ff & ") order by emp_name").Tables(0)
                Me.Cmb_block.DataSource = dt
                Me.Cmb_block.DataTextField = dt.Columns(0).ColumnName
                Me.Cmb_block.DataValueField = dt.Columns(1).ColumnName
                Me.Cmb_block.DataBind()
            End If

        Else
            Server.Transfer("../show_err.aspx")

        End If
    End Sub

    
End Class
