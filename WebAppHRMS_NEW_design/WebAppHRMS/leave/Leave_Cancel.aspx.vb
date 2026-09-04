Imports System.Data
Imports System.Data.OracleClient
Partial Class Deepak_Leave_Cancel_70db02a15227
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lbl_message.Text = "<marquee><font>This module For canceling the leave.Give empcode And Cancel it</font></marquee>"
        If Not IsPostBack Then
            adddata()
        End If
    End Sub

    Protected Sub txt_ecode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'dt = oh.ExecuteDataSet("select b.emp_name,c.leave_type,a.leave_frdate,a.leave_todate,a.leave_days,a.leave_apply_date,a.leave_reason from employ_leave_dtl a,employee_master b,leave_master c where a.leave_id=c.leave_id and a.emp_code=b.emp_code and a.emp_code='" & Me.txt_ecode.Text & "' and a.status in(0,1)").Tables(0)
        'Me.lbl_message.Text = ""
        'If (dt.Rows.Count = 0) Then
        '    Me.lbl_message.Text = "No Leave To Be Cancelled"
        '    clear()
        'Else
        '    Me.txt_name.Text = dt.Rows(0)(0)
        '    Me.txt_leavetype.Text = dt.Rows(0)(1)
        '    Me.txt_leavefrom.Text = Format(dt.Rows(0)(2), "dd/MMM/yyyy")
        '    Me.txt_leaveto.Text = Format(dt.Rows(0)(3), "dd/MMM/yyyy")
        '    Me.txt_nofdays.Text = dt.Rows(0)(4)
        '    Me.txt_applydate.Text = Format(dt.Rows(0)(5), "dd/MMM/yyyy")
        '    Me.txt_reason.Text = dt.Rows(0)(6)
        '    Me.lbl_message.Text = ""
        '    Me.txt_hid.Text = CInt(Me.txt_hid.Text) + 1
        'End If


    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.txt_leavefrom.Text = "" Then
            Me.lbl_message.Text = "NO LEAVE TO BE CANCELLED"
        Else
            Dim i As Date
            i = Format(Date.Now, "dd/MMM/yyyy")
            If (txt_leaveto.Text < i) Then

                Me.lbl_message.Text = "LEAVE CANNOT BE CANCELLED"
            Else
                Dim leave_cancel(3) As OracleParameter
                leave_cancel(0) = New OracleParameter("emp_id", OracleType.Int32)
                leave_cancel(0).Direction = ParameterDirection.Input
                leave_cancel(0).Value = Me.txt_ecode.Text
                leave_cancel(1) = New OracleParameter("from_date", OracleType.DateTime)
                leave_cancel(1).Direction = ParameterDirection.Input
                leave_cancel(1).Value = CDate(Me.txt_leavefrom.Text)
                leave_cancel(2) = New OracleParameter("to_date", OracleType.DateTime)
                leave_cancel(2).Direction = ParameterDirection.Input
                leave_cancel(2).Value = CDate(Me.txt_leaveto.Text)
                leave_cancel(3) = New OracleParameter("days", OracleType.Int32)
                leave_cancel(3).Direction = ParameterDirection.Input
                leave_cancel(3).Value = Me.txt_nofdays.Text
                oh.ExecuteNonQuery("leave_cancel", leave_cancel)
                Dim dtf, dtt As New Date
                Dim emp As New Integer
                dtf = Me.txt_leavefrom.Text
                dtt = Me.txt_leaveto.Text
                emp = Me.txt_ecode.Text
                adddata()
                Me.lbl_message.Text = "EMPCODE:" & emp & " FROM:" & dtf & " TO:" & dtt & "  LEAVE CANCELLED"
            End If
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("../home.aspx")
    End Sub

    Protected Sub cmd_next_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.lbl_message.Text = ""
        dt = oh.ExecuteDataSet("select b.emp_name,c.leave_type,a.leave_frdate,a.leave_todate,a.leave_days,a.leave_apply_date,a.leave_reason from employ_leave_dtl a,employee_master b,leave_master c where a.leave_id=c.leave_id and a.emp_code=b.emp_code and a.emp_code='" & Me.txt_ecode.Text & "' and a.status in(0,1,3) and a.leave_frdate>sysdate").Tables(0)
        If dt.Rows.Count <> 0 Then
            If Me.txt_hid.Text <> dt.Rows.Count Then
                If dt.Rows.Count > 1 Then
                    Dim i As New Integer
                    i = Me.txt_hid.Text
                    Me.txt_name.Text = dt.Rows(i)(0)
                    Me.txt_leavetype.Text = dt.Rows(i)(1)
                    Me.txt_leavefrom.Text = Format(dt.Rows(i)(2), "dd/MMM/yyyy")
                    Me.txt_leaveto.Text = Format(dt.Rows(i)(3), "dd/MMM/yyyy")
                    Me.txt_nofdays.Text = dt.Rows(i)(4)
                    Me.txt_applydate.Text = Format(dt.Rows(i)(5), "dd/MMM/yyyy")
                    Me.txt_reason.Text = dt.Rows(i)(6)
                    Me.lbl_message.Text = ""
                    Me.txt_hid.Text = CInt(Me.txt_hid.Text) + 1
                Else
                    Me.lbl_message.Text = "THERE IS ONLY ONE LEAVE IS AVAILABLE FOR CANCELLATION"
                End If
            Else
                Me.lbl_message.Text = "THIS IS THE LAST LEAVE APPLIED BY " & Me.txt_ecode.Text & ""
            End If
        Else
            Me.lbl_message.Text = "NO LEAVE TO BE CANCELLED"
        End If

    End Sub

    Protected Sub cmd_back_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.lbl_message.Text = ""
        dt = oh.ExecuteDataSet("select b.emp_name,c.leave_type,a.leave_frdate,a.leave_todate,a.leave_days,a.leave_apply_date,a.leave_reason from employ_leave_dtl a,employee_master b,leave_master c where a.leave_id=c.leave_id and a.emp_code=b.emp_code and a.emp_code='" & Me.txt_ecode.Text & "' and a.status in(0,1,3) and a.leave_frdate>sysdate").Tables(0)
        If dt.Rows.Count <> 0 Then
            If Me.txt_hid.Text <> 0 Then
                Me.txt_hid.Text = CInt(Me.txt_hid.Text) - 1
                If Me.txt_hid.Text < dt.Rows.Count Then
                    Dim i As New Integer
                    i = Me.txt_hid.Text
                    Me.txt_name.Text = dt.Rows(i)(0)
                    Me.txt_leavetype.Text = dt.Rows(i)(1)
                    Me.txt_leavefrom.Text = Format(dt.Rows(i)(2), "dd/MMM/yyyy")
                    Me.txt_leaveto.Text = Format(dt.Rows(i)(3), "dd/MMM/yyyy")
                    Me.txt_nofdays.Text = dt.Rows(i)(4)
                    Me.txt_applydate.Text = Format(dt.Rows(i)(5), "dd/MMM/yyyy")
                    Me.txt_reason.Text = dt.Rows(i)(6)
                    Me.lbl_message.Text = ""

                Else
                    Me.lbl_message.Text = "THERE IS ONLY ONE LEAVE IS AVAULABLE FOR CANCELLATION"
                End If
            Else
                Me.lbl_message.Text = "<font size=3><b>THIS IS THE FIRST LEAVE APPLIED BY " & Me.txt_ecode.Text & "</b></font>"
            End If
        Else
            Me.lbl_message.Text = "NO LEAVE TO BE CANCELLED"
        End If
    End Sub
    'Function clear()
    '    Me.txt_name.Text = ""
    '    Me.txt_leavetype.Text = ""
    '    Me.txt_leavefrom.Text = ""
    '    Me.txt_leaveto.Text = ""
    '    Me.txt_nofdays.Text = ""
    '    Me.txt_applydate.Text = ""
    '    Me.txt_reason.Text = ""

    'End Function
    Sub clear()
        Me.txt_leavetype.Text = ""
        Me.txt_leavefrom.Text = ""
        Me.txt_leaveto.Text = ""
        Me.txt_nofdays.Text = ""
        Me.txt_applydate.Text = ""
        Me.txt_reason.Text = ""
    End Sub
    Sub adddata()
        Dim st As String = Me.Session("user_id")
        Dim st1(), st2, st3 As String
        st1 = st.Split("!")
        st2 = st1(0)
        st3 = st1(1)
        Me.txt_ecode.Text = st2
        Dim Sql2 As String = "select emp_name from employee_master where emp_code=" & st2 & ""
        Dim dt3 As New DataTable
        dt3 = oh.ExecuteDataSet(Sql2).Tables(0)
        Me.txt_name.Text = dt3.Rows(0)(0)
        dt = oh.ExecuteDataSet("select b.emp_name,c.leave_type,a.leave_frdate,a.leave_todate,a.leave_days,a.leave_apply_date,a.leave_reason from employ_leave_dtl a,employee_master b,leave_master c where a.leave_id=c.leave_id and a.emp_code=b.emp_code and a.emp_code='" & st2 & "' and a.status in(0,1,3) AND a.leave_frdate>sysdate").Tables(0)
        '  Me.lbl_message.Text = ""
        If (dt.Rows.Count = 0) Then
            Me.lbl_message.Text = "NO LEAVE TO BE CANCELLED"
            clear()
        Else
            Me.txt_name.Text = dt.Rows(0)(0)
            Me.txt_leavetype.Text = dt.Rows(0)(1)
            Me.txt_leavefrom.Text = Format(dt.Rows(0)(2), "dd/MMM/yyyy")
            Me.txt_leaveto.Text = Format(dt.Rows(0)(3), "dd/MMM/yyyy")
            Me.txt_nofdays.Text = dt.Rows(0)(4)
            Me.txt_applydate.Text = Format(dt.Rows(0)(5), "dd/MMM/yyyy")
            Me.txt_reason.Text = dt.Rows(0)(6)
            ' Me.lbl_message.Text = ""
            Me.txt_hid.Text = CInt(Me.txt_hid.Text) + 1
        End If
    End Sub
End Class
