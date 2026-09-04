Imports system
Imports System.Data
Imports System.Data.OracleClient
Partial Class Sunday_Lop_Cancel_0346d3b82049
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dts1, dts2, dtpri, dtrs As New DataTable
    Dim UserAll(), UserCode, sql, dtt As String
    Dim str_tkn As New StringBuilder
    Dim cat As Integer
    Dim dts, dt1, dt2, dt3, dth As New DataTable
    Dim str, strs, sf(), frm As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cs As String = "var cont_name;cont_name='" & Me.txtlopFrom.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        'Dim usr() As String = Session("user_id").ToString.Split("!")
        sf = Session("user_id").ToString.Split("!")

        dtt = "select count(*) from mactech.employee_master t where t.department_id in (881, 946, 875, 879, 880,996,542) and t.emp_code = '" & sf(0) & "'"
        dt3 = oh.ExecuteDataSet(dtt).Tables(0)
        'If dt3.Rows.Count = 0 Then
        Dim count As Integer = Convert.ToInt32(dt3.Rows(0)(0))
        If count = 0 Then
            'Server.Transfer("../../show_err.aspx")
            Server.Transfer("~/show_err.aspx")
        End If

        Me.txtlopFrom.DataBind()
        'Me.hidLeaveFrom.Value = "1-jan-2024"
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click

        Dim script1 As New System.Text.StringBuilder

        Dim sql1 As String
        'sql1 = "select count(*) from mactech.attend t where t.emp_code = '" & sf(0) & "' and (curr_date = to_date('" & Me.txtlopFrom.Text & "', 'dd-mm-yyyy')) and t.m_time is null and t.pay_id not in (50, 52, 51) and t.e_time is null"
        'sql1 = "select count(*) from mactech.attend t where t.emp_code = '" & sf(0) & "' and (curr_date = to_date('" & Me.txtlopFrom.Text & "', 'dd-mm-yyyy')) and ( (t.m_time is not null and t.e_time is not null) or ((t.m_time is null and t.pay_id in(50)) and t.e_time is not null) or ((t.e_time is null and t.pay_id in(51)) and t.m_time is not null)or ((t.m_time is null and t.e_time is null)and t.pay_id in(52))or t.pay_id in(52) )"
        sql1 = "select nvl(sum(cnts),0)from (select count(*) cnts from mactech.attend t where t.emp_code = '" & sf(0) & "' and (curr_date = to_date('" & Me.txtlopFrom.Text & "', 'dd-mm-yyyy')) and ((t.m_time is not null and t.e_time is not null) or ((t.m_time is null and t.pay_id in (50)) and t.e_time is not null) or ((t.e_time is null and t.pay_id in (51)) and t.m_time is not null) or ((t.m_time is null and t.e_time is null) and t.pay_id in (52)) or t.pay_id in (52)) union select count(*) from mactech.hrm_comp_appl t where t.emp_code = '" & sf(0) & "' and (t.leave_dt = to_date('" & Me.txtlopFrom.Text & "', 'dd-mm-yyyy')) and t.status_id in (0,1,4) union select count(*) from hrm_leave_apply_sanction t where t.emp_code = '" & sf(0) & "' and (t.leave_frdate = to_date('" & Me.txtlopFrom.Text & "', 'dd-mm-yyyy')) and t.leave_id in (1, 2, 3) and t.status_id in (0,1,4))"
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        If dt1.Rows(0)(0) = 0 Then
            If (Not (Me.txtlopFrom.Text) = "") Then
                script1.Append("alert('You are not punched on selected sunday..!!');")
                script1.Append("window.open('Sunday_Lop_Cancel.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Else
                script1.Append("        alert('Please Select worked date..!!');")
                'script1.Append("window.open('Sunday_Lop_Cancel.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            End If
        End If
        Dim sql2 As String
        sql2 = "select count(*) from mactech.attend t where t.emp_code = '" & sf(0) & "' and (curr_date = to_date('" & Me.txtlopToDate.Text & "', 'dd-mm-yyyy')) and ( (t.m_time is not null and t.e_time is not null) or ((t.m_time is null and t.pay_id in(50)) and t.e_time is not null) or ((t.e_time is null and t.pay_id in(51)) and t.m_time is not null)or ((t.m_time is null and t.e_time is null)and t.pay_id in(52))or t.pay_id in(52) )"
        dt2 = oh.ExecuteDataSet(sql2).Tables(0)

        If dt2.Rows(0)(0) = 1 Then
            'If (Not (Me.txtlopToDate.Text) = "") Then
            script1.Append("alert('Please select lop date..!!');")
            'script1.Append("window.open('Sunday_Lop_Cancel.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            'Else
        End If

        Dim sql3 As String
        sql3 = "select count (*) from mactech.tbl_lop_cancelled t where t.empcode= '" & sf(0) & "' and (t.workeddate = to_date('" & Me.txtlopFrom.Text & "', 'dd-mm-yyyy'))and t.status in (0,4,1)"
        dt3 = oh.ExecuteDataSet(sql3).Tables(0)

        If dt3.Rows(0)(0) = 1 Then
            script1.Append("alert('You are Already Applied on this day..!!');")
            script1.Append("window.open('Sunday_Lop_Cancel.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf (txtlopFrom.Text = "") Then
            script1.Append("        alert('Please Select worked date..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf (txtlopToDate.Text = "") Then
            script1.Append("        alert('Please select cancellation date..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf (txtremarks.Text = "") Then
            script1.Append("        alert('Please enter remarks..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        ElseIf dt1.Rows(0)(0) = 0 Then
            'If (Not (Me.txtlopFrom.Text) = "") Then
            script1.Append("alert('You are not punched on selected sunday..!!');")
            script1.Append("window.open('Sunday_Lop_Cancel.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        Else

            Dim parameter(4) As OracleParameter
            Parameter(0) = New OracleParameter("ecode", OracleType.Number, 150)
            Parameter(0).Direction = ParameterDirection.Input
            Parameter(0).Value = sf(0)


            Parameter(1) = New OracleParameter("wrkdt", OracleType.DateTime, 150)
            Parameter(1).Direction = ParameterDirection.Input
            Parameter(1).Value = Format(CDate(Me.txtlopFrom.Text), "dd/MMM/yyyy")


            Parameter(2) = New OracleParameter("remarks", OracleType.VarChar, 100)
            Parameter(2).Direction = ParameterDirection.Input
            Parameter(2).Value = Me.txtremarks.Text


            Parameter(3) = New OracleParameter("lopcancelltndate", OracleType.DateTime, 150)
            Parameter(3).Direction = ParameterDirection.Input
            Parameter(3).Value = Format(CDate(Me.txtlopToDate.Text), "dd/MMM/yyyy")


            Parameter(4) = New OracleParameter("msg", OracleType.VarChar, 500)
            Parameter(4).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("hrm_lopsndy_cancellation", Parameter)

            Dim message As String
            message = Parameter(4).Value
            script1.Append("alert('" & message & "');")
            script1.Append("window.open('Sunday_lop_Cancel.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If

    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Response.Redirect("../home.aspx")
    End Sub

    'Protected Sub txtremarks_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtremarks.TextChanged
    '    'Dim cleanString As String = Regex.Replace(txtremarks, "[^A-Za-z0-9\-/]", "")
    '    Dim txt As String
    '    txt = Regex.Replace(Me.txtremarks.Text, "[^a-zA-Z 0-9-/-]", "")
    'End Sub
End Class




