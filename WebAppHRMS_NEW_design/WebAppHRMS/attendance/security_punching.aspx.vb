Imports System.Data
Imports System.Data.OracleClient

Partial Class attendance_security_punching_da7ab6442965
    Inherits System.Web.UI.Page
    Protected Sub txt_password_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oh As New Helper.Oracle.OracleHelper
        Dim dt As New DataTable
        dt = oh.ExecuteDataSet("select a.emp_code,a.status_id,a.shift_id,a.emp_name,b.shift,b.in_time,b.ncry_time,b.mcry_time,b.early_time,b.out_time,b.ovr_time,a.category,d.m_time,d.e_time,b.start_time from employee_master a,time_tab b,daily_attend d where a.shift_id=b.shift_id and a.shift_id in (4,5) and a.emp_code=d.emp_code and a.emp_code=" & Me.txt_empcode.Text & " and a.password='" & Me.txt_password.Text & "'").Tables(0)
        If dt.Rows.Count = 1 Then
            ' If Me.txt_password.Text = dt.Rows(0)(14) Then
            Me.txt_password.ReadOnly = True
            Me.txt_empcode.ReadOnly = True
            Me.txt_empname.Text = dt.Rows(0)(3)
            Me.txt_shift.Text = dt.Rows(0)(4)
            Me.lbl_message.Text = ""
            'Else
            '    Me.lbl_message.Text = "INVALID PASSWORD"
            '    Me.txt_empname.Text = ""
            '    Me.txt_shift.Text = ""
            'End If
        Else
            Me.lbl_message.Text = "INVALID PASSWORD/EMPLOYEE DOES NOT EXIST"
        Me.txt_empname.Text = ""
        Me.txt_shift.Text = ""
        Me.txt_empcode.Text = ""
        End If
    End Sub

    Protected Sub cmd_ok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_ok.Click
        Dim oh As New Helper.Oracle.OracleHelper
        Dim parm_coll(4) As OracleParameter
        parm_coll(0) = New OracleParameter("empcd", OracleType.Number, 5)
        parm_coll(0).Value = CInt(Me.txt_empcode.Text)
        parm_coll(1) = New OracleParameter("brno", OracleType.Number, 4)
        parm_coll(1).Value = CInt(Session("branch_id"))
        parm_coll(2) = New OracleParameter("pun_time", OracleType.VarChar, 10)
        parm_coll(2).Value = " "
        parm_coll(3) = New OracleParameter("gun_st", OracleType.Number, 10)
        If Me.chk_gun.Checked = True Then
            parm_coll(3).Value = 1
        Else
            parm_coll(3).Value = 0
        End If
        parm_coll(4) = New OracleParameter("error_st", OracleType.Number)
        parm_coll(4).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("Sec_UpdateDailyAttend", parm_coll)
        If parm_coll(4).Value = 0 Then
            Me.lbl_message.Text = "Successfully Confirmed"
            Me.txt_empname.Text = ""
            Me.txt_shift.Text = ""
            Me.txt_empcode.Text = ""
        End If
    End Sub
    Protected Sub chk_gun_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.chk_gun.Checked = True Then
            Me.chk_gun.Text = "WITH GUN"
        Else
            Me.chk_gun.Text = "WITHOUT GUN"
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Me.chk_gun.Checked = True Then
                Me.chk_gun.Text = "WITH GUN"
            Else
                Me.chk_gun.Text = "WITHOUT GUN"
            End If
        End If
    End Sub
End Class
