Imports System.Data
Imports System.Data.OracleClient
Partial Class attendance_mark_attendance_f50b06c31519
    Inherits System.Web.UI.Page
    Protected Sub TextBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.txt_employee_code.Text.Length < 5 Then
            Me.lbl_message.Text = " Please Mark your attendance through security puching option !"
            Exit Sub
        End If
        Dim oh1 As New Helper.Oracle.OracleHelper
        Dim SQL As String
        'SQL = "select emp_name,shift,password,to_char(sysdate,'hh24:mi:ss') from employee_master a,time_tab b where a.emp_code=" & Me.txt_employee_code.Text & " and a.shift_id=b.shift_id"
        Dim dt As New DataTable
        dt = oh1.ExecuteDataSet(SQL).Tables(0)
        If dt.Rows.Count = 0 Then
            Me.lbl_message.Text = " You are not a registered employee !"
        Else
            If txt_password.Text <> dt.Rows(0)(2) Then
                lbl_message.Text = "Invalid Password"
            Else
                Me.txt_employee_name.Text = dt.Rows(0)(0)
                Me.txt_shift.Text = dt.Rows(0)(1)
                Me.hdn_time.Value = dt.Rows(0)(3)
                lbl_message.Text = "Click Save To Confirm"
                Me.cmd_save.Focus()
            End If
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lbl_message.Text = "Enter Employee Code"
        Me.txt_employee_code.Focus()
    End Sub
    Protected Sub cmd_save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_save.Click
        Dim oh1 As New Helper.Oracle.OracleHelper
        Dim parm_coll(2) As OracleParameter
        parm_coll(0) = New OracleParameter("empcd", OracleType.Number, 5)
        parm_coll(0).Value = CInt(Me.txt_employee_code.Text)
        parm_coll(1) = New OracleParameter("brno", OracleType.Number, 4)
        parm_coll(1).Value = CInt(Session("branch_id"))
        parm_coll(2) = New OracleParameter("pun_time", OracleType.VarChar, 10)
        parm_coll(2).Value = Me.hdn_time.Value
        Dim res As Integer
        res = oh1.ExecuteNonQuery("UpdateDailyAttend1", parm_coll)
        If res = 1 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Successfully Confirmed');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
            Me.txt_employee_code.Text = ""
            Me.txt_employee_name.Text = ""
            Me.txt_shift.Text = ""
            Me.txt_employee_code.Focus()
        End If
    End Sub
End Class
