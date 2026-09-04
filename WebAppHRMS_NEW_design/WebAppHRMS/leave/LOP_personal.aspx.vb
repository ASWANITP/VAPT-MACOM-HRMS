Imports System.Data
Imports System.Data.OracleClient
Partial Class LOP_to_Personal_Account_LOP_personal_3e0442e66734
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.Session("access_id") = 33 Then
            CType(Me.Master, WebAppHRMS.edp).Subtitle = "LOP TO PERSONAL ACCOUNT LEAVE ENTRY "
            If Not IsPostBack Then
                Dim dt As DataTable = oh.ExecuteDataSet("select distinct e.emp_code,e.emp_code || ' - ' || e.emp_name from employee_master e,employ_leave_dtl em where e.emp_code>9999 and e.emp_code=em.emp_code and em.leave_process_id=1 and em.leave_id=4 order by e.emp_code").Tables(0)
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
        Dim dt As DataTable = oh.ExecuteDataSet("select distinct e.leave_seq,to_char(to_date(e.leave_frdate),'DD/MON/yyyy') || '   -   ' || to_char(to_date(e.leave_todate),'DD/MON/yyyy') as frdate from employ_leave_dtl e where e.leave_id=4 and e.leave_process_id=1 and e.emp_code=" & Me.cmb_emp.SelectedValue & " order by frdate").Tables(0)
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
        Dim param(5) As OracleParameter
        param(0) = New OracleParameter("userid", OracleType.Number)
        param(0).Direction = ParameterDirection.Input
        param(0).Value = i

        param(1) = New OracleParameter("leaveseq", OracleType.Number)
        param(1).Direction = ParameterDirection.Input
        param(1).Value = Me.cmb_leave.SelectedValue

        param(2) = New OracleParameter("empcode", OracleType.Number)
        param(2).Direction = ParameterDirection.Input
        param(2).Value = Me.cmb_emp.SelectedValue

        param(3) = New OracleParameter("frdt", OracleType.DateTime)
        param(3).Direction = ParameterDirection.Input
        param(3).Value = Me.cmb_leave.SelectedItem.ToString.Split("-")(0)

        param(4) = New OracleParameter("todt", OracleType.DateTime)
        param(4).Direction = ParameterDirection.Input
        param(4).Value = Me.cmb_leave.SelectedItem.ToString.Split("-")(1)


        param(5) = New OracleParameter("flag", OracleType.Number)
        param(5).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("loppersonalac", param)
        Dim script1 As New System.Text.StringBuilder
        If param(5).Value = 1 Then
            script1.Append("        alert('Successfully Updated');")
            script1.Append("window.open('../home.aspx','_self');")
            ' leavefill()
        Else
            script1.Append("        alert('Sorry,Error in Editing');")
        End If
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
    End Sub
End Class
