Imports System.Data
Imports System.Data.OracleClient
Partial Class LOP_to_Personal_Account_LOP_personal_eab8b0892563
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.Session("access_id") = 33 Then
            If Not IsPostBack Then
                Dim frm As Integer = session("firm_id")
                Dim dt As DataTable = oh.ExecuteDataSet("select distinct e.emp_code,e.emp_code || ' - ' || e.emp_name from employee_master e,employ_leave_dtl em,employ_firm ef where e.emp_code=ef.emp_code and e.emp_code>9999 and e.emp_code=em.emp_code and em.leave_process_id=1 and em.leave_id=4 and ef.firm_id=" & frm & " order by e.emp_code").Tables(0)
                Me.cmb_emp.DataSource = dt
                Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_emp.DataBind()
                leavefill()
            End If
        Else
            Me.Server.Transfer("show_err.aspx")
        End If
    End Sub

    Protected Sub cmb_emp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_emp.SelectedIndexChanged
        leavefill()
    End Sub
    Private Sub leavefill()
        Dim dt As DataTable = oh.ExecuteDataSet("select distinct e.leave_seq,e.leave_frdate || '   -   ' || e.leave_todate as frdate from employ_leave_dtl e where e.leave_id=4 and e.leave_process_id=1 and e.emp_code=" & Me.cmb_emp.SelectedValue & " order by frdate").Tables(0)
        If dt.Rows.Count > 0 Then
            Me.cmb_leave.DataSource = dt
            Me.cmb_leave.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_leave.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_leave.DataBind()
        Else

        End If

    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        Dim i As Integer = user(0)
        Dim param(2) As OracleParameter
        param(0) = New OracleParameter("userid", OracleType.Number)
        param(0).Direction = ParameterDirection.Input
        param(0).Value = i

        param(1) = New OracleParameter("leaveseq", OracleType.Number)
        param(1).Direction = ParameterDirection.Input
        param(1).Value = Me.cmb_leave.SelectedValue

        param(2) = New OracleParameter("flag", OracleType.Number)
        param(2).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("loppersonalac", param)
        Dim script1 As New System.Text.StringBuilder
        If param(2).Value = 1 Then
            script1.Append("        alert('Successfully Updated');")
            script1.Append("window.open('../home.aspx','_self');")
            ' leavefill()
        Else
            script1.Append("        alert('Sorry,Error in Editing');")
        End If
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
    End Sub
End Class
