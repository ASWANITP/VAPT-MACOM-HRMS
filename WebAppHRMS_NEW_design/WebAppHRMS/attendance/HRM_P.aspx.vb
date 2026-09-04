Imports System.Data
Imports System.Data.OracleClient

Partial Class ATTENDANCE_HRM_P_eb004fcf2252
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String

    Protected Sub txt_ecode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        sql = "select count(*) from employee_master where status_id in (1,5) and emp_code=" & Me.txt_ecode.Text
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If (dt.Rows(0)(0) <= 0) Then
            Me.lbl_mesage.Text = "Employee Does Not Exist"
            clear()
        Else
            sql = "select e.emp_name,t.shift||'('||t.in_time||' To '||t.out_time||')' from employee_master e,time_tab t where e.shift_id=t.shift_id and e.emp_code=" & Me.txt_ecode.Text
            dt = oh.ExecuteDataSet(sql).Tables(0)
            Me.txt_name.Text = dt.Rows(0)(0)
            Me.txt_shift.Text = dt.Rows(0)(1)
        End If

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If (Me.txt_date.Text = "") Then
            Me.lbl_mesage.Text = "PUNCHING IS NOT POSSIBLE"

        else
        If (Me.txt_ecode.Text = "" Or Me.txt_name.Text = "" Or Me.txt_reason.Text = "" Or Me.txt_shift.Text = "" Or Me.txt_hh.Text = "" Or Me.txt_mm.Text = "" Or Me.txt_ss.Text = "") Then
            Me.lbl_mesage.Text = "Complete All Entries"
        Else
            Dim time As String
            If (Me.rd_am.Checked = True) Then
                time = Me.txt_hh.Text + ":" + Me.txt_mm.Text + ":" + Me.txt_ss.Text + " " + "AM"
            Else
                time = Me.txt_hh.Text + ":" + Me.txt_mm.Text + ":" + Me.txt_ss.Text + " " + "PM"
            End If
            Dim punch(5) As OracleParameter
            punch(0) = New OracleParameter("ecode", OracleType.Int32)
            punch(0).Direction = ParameterDirection.Input
            punch(0).Value = CInt(Me.txt_ecode.Text)
            punch(1) = New OracleParameter("ttime", OracleType.DateTime)
            punch(1).Direction = ParameterDirection.Input
            punch(1).Value = CDate(time)
            punch(2) = New OracleParameter("reason", OracleType.VarChar, 100)
            punch(2).Direction = ParameterDirection.Input
            punch(2).Value = Me.txt_reason.Text
            punch(3) = New OracleParameter("entr_person", OracleType.VarChar, 30)
            punch(3).Direction = ParameterDirection.Input
            punch(3).Value = Me.Session("user_id")
            punch(4) = New OracleParameter("p_date", OracleType.DateTime)
            punch(4).Direction = ParameterDirection.Input
            punch(4).Value = CDate(Me.txt_date.Text)
            punch(5) = New OracleParameter("msg", OracleType.Int32)
            punch(5).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("hrm_punch", punch)
            clear()
            Select Case punch(5).Value
                Case 0
                    Me.lbl_mesage.Text = "Punch Not Successful"
                    clear()
                Case 1
                    Me.lbl_mesage.Text = "Morning Punch Done Successfully"
                    clear()
                Case 2
                    Me.lbl_mesage.Text = "Evening Punch Done Successfully"
                    clear()
                Case 3
                    Me.lbl_mesage.Text = "Employee Already Punched"
                    clear()
            End Select
        End If
        End If
    End Sub
    Sub clear()
        Me.txt_ecode.Text = ""
        Me.txt_name.Text = ""
        Me.txt_reason.Text = ""
        Me.txt_shift.Text = ""
        Me.txt_hh.Text = ""
        Me.txt_mm.Text = ""
        Me.txt_ss.Text = ""
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.lbl_mesage.Text = ""
        clear()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim dt1 As New DataTable


            Dim sf() As String
            sf = Session("user_id").ToString.Split("!")
            dt1 = oh.ExecuteDataSet("select count(emp_code) from employee_master where emp_code=" & sf(0) & " and status_id=1 and (post_id in (195) or emp_code in (select emp_Code from form_accessibility f where f.form_id=174 and f.emp_id=" & sf(0) & " ))").Tables(0)
            'dt2 = oh.ExecuteDataSet("select to_date(sysdate),to_char(sysdate,'HH24:MI:SS') from dual").Tables(0)

            If (dt1.Rows(0)(0) = 0) Then
                Server.Transfer("../show_err.aspx")
                'Else
                '    If (sf(0) = dt1.Rows(0)(0) And dt1.Rows(0)(1) = dt2.Rows(0)(0) And dt2.Rows(0)(1) <= dt1.Rows(0)(2)) Then
                '    Else
                '        Server.Transfer("../show_err.aspx")
                '    End If
            End If
        End If





        Me.txt_date.Attributes.Add("onkeyup", "correct('txt_date',event)")
        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.txt_hh.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)
    End Sub

    Protected Sub txt_date_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim fdt, tdt As New Date
        Dim cnt As New Integer
        fdt = Format(Date.Today, "dd/MMM/yyyy")
        tdt = Me.txt_date.Text
        cnt = DateDiff(DateInterval.Day, tdt, fdt)
        If (cnt > 5) Then
            Me.txt_date.Text = ""
        End If
    End Sub
End Class
