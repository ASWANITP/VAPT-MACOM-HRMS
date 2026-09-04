Imports System.Data
Imports System.Data.OracleClient
Partial Class punching_earlypunching_00846e464627
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbl_message.Visible = False
        If Not Me.IsPostBack Then
            txt_leave_date.Text = Format(Now, "dd/MMM/yyyy")
        End If
        ' txt_leave_date.Text =Format(Now, "dd/MMM/yyyy")
        Dim dt1 As New DataTable
        Dim st, st1(), st2 As String
        st = Session("user_id")
        st1 = st.Split("!")
        st2 = st1(0)
        'If (Me.txt_emp_code.Text = st2) Then
        ' dt1 = oh.ExecuteDataSet("SELECT TT.IN_TIME||'--'||TT.OUT_TIME,em.emp_name,TT.SHIFT_ID FROM EMPLOYEE_MASTER EM,TIME_TAB TT WHERE EM.SHIFT_ID=TT.SHIFT_ID AND EM.EMP_CODE='" & Me.txt_emp_code.Text & "' ").Tables(0)
        dt1 = oh.ExecuteDataSet("SELECT TT.IN_TIME||'--'||TT.OUT_TIME,em.emp_name,TT.SHIFT_ID FROM EMPLOYEE_MASTER EM,TIME_TAB TT WHERE EM.SHIFT_ID=TT.SHIFT_ID AND EM.EMP_CODE=" & st2 & " ").Tables(0)
        If dt1.Rows.Count > 0 Then
            ' Me.txt_reason.Text = ""
            Me.txt_emp_code.Text = st2
            Me.txt_shift_time.Text = dt1.Rows(0)(0)
            Me.txt_name.Text = dt1.Rows(0)(1)
            Me.hdn1.Value = dt1.Rows(0)(2)
            ' txt_leave_date.Text = Format(Now, "dd/MMM/yyyy")
        Else
            'Dim cl_script As New StringBuilder
            'cl_script.Append("   alert('NO SUCH EMPLOYEE') ;")
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            'Me.lbl_message.Text = "<FONT SIZE=4 ><B> NO SUCH EMPLOYEE </B></FONT>"
            Me.lbl_message.Text = "NO SUCH EMPLOYEE"
            Me.lbl_message.Visible = True
            Me.txt_emp_code.Text = ""
            'Me.txt_going_time.Text = ""
            'Me.txt_leave_date.Text = ""
            txt_leave_date.Text = Format(Now, "dd/MMM/yyyy")
            ' Me.RadioButtonList1.SelectedItem.Text = "NO"
            Me.txt_name.Text = ""
            Me.txt_reason.Text = ""
            Me.txt_shift_time.Text = ""
            Me.RadioButtonList1.SelectedValue = "NO"
        End If
        'Else
        'Me.lbl_message.Visible = True
        'Me.lbl_message.Text = "LOGIN WITH YOUR EMP_CODE"
        'Me.txt_name.Text = ""
        'Me.txt_reason.Text = ""
        'Me.txt_shift_time.Text = ""
        'Me.RadioButtonList1.SelectedValue = "NO"
        'End If
    End Sub

    Protected Sub btn_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        'If Page.IsValid() Then
        ' MsgBox(TextBox1.Text)
        Dim a As Integer = 0
        If Me.txt_emp_code.Text = "" Or Me.txt_reason.Text = "" Or Me.txt_name.Text = "" Or Me.txt_shift_time.Text = "" Or Me.txt_leave_date.Text = "" Then
            lbl_message.Visible = True
            lbl_message.Text = "ENTER REASON"
            'Me.txt_emp_code.Text = ""
            'Me.txt_name.Text = ""
            'Me.txt_shift_time.Text = ""
            'Me.txt_reason.Text = ""
        Else

            'If IsDate(txt_leave_date.Text) Then
            '    MsgBox("WRONG DATE")
            'Else

            Dim dt2 As New DataTable
            ' Try
            dt2 = oh.ExecuteDataSet("select emp_code from early_going_mst where leave_frdate= ' " & Me.txt_leave_date.Text & "  ' and emp_code='" & Me.txt_emp_code.Text & " ' ").Tables(0)

            'Catch ex As Exception
            '    a = 1
            '    Dim cl_script As New StringBuilder
            '    cl_script.Append("   alert('wrong date') ;")
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            'End Try

            'If (a <> 1) Then


            If dt2.Rows.Count > 0 Then
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('YOU ARE ALREADY APPLIED') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Else

                If Me.RadioButtonList1.SelectedItem.Text = "YES" Then
                    Me.hdn.Value = "T"
                ElseIf Me.RadioButtonList1.SelectedItem.Text = "NO" Then
                    Me.hdn.Value = "F"
                End If
                lbl_message.Visible = True
                'Dim str As String
                'str = ""
                'dt = oh.ExecuteDataSet(str).Tables(0)
                Dim p(6) As OracleParameter

                p(0) = New OracleParameter("ecode", OracleType.Number, 5)
                p(0).Direction = ParameterDirection.Input
                p(0).Value = Me.txt_emp_code.Text

                p(1) = New OracleParameter("shift_time", OracleType.Char, 15)
                p(1).Direction = ParameterDirection.Input
                p(1).Value = Me.hdn1.Value


                'p(2) = New OracleParameter("going_time", OracleType.Char, 15)
                'p(2).Direction = ParameterDirection.Input
                'p(2).Value = Me.txt_going_time.Text


                p(2) = New OracleParameter("leave_date", OracleType.DateTime)
                p(2).Direction = ParameterDirection.Input
                p(2).Value = Me.txt_leave_date.Text


                p(3) = New OracleParameter("reason", OracleType.VarChar, 150)
                p(3).Direction = ParameterDirection.Input
                p(3).Value = Me.txt_reason.Text


                p(4) = New OracleParameter("branch_id1", OracleType.VarChar, 3)
                p(4).Direction = ParameterDirection.Input
                p(4).Value = Me.Session("branch_id")


                p(5) = New OracleParameter("radio", OracleType.VarChar, 3)
                p(5).Direction = ParameterDirection.Input
                p(5).Value = Me.hdn.Value


                p(6) = New OracleParameter("flag", OracleType.Number, 6)
                p(6).Direction = ParameterDirection.Output

                Try
                    Dim chk As Integer = oh.ExecuteNonQuery("early_going", p)
                    If p(6).Value = 1 Then
                        Me.lbl_message.Text = "DATA UPDATED."
                        ' fill_combo1()
                        'clear_all()
                        'add_date()
                    Else
                        Me.lbl_message.Text = "DATA NOT UPDATED."
                    End If
                Catch ex As Exception
                    Me.lbl_message.Text = ex.Message
                End Try
            End If

            'Me.txt_going_time.Text = ""
            'Me.txt_leave_date.Text = ""
            ' Me.RadioButtonList1.SelectedItem.Text = "NO"
            Me.RadioButtonList1.SelectedValue = "NO"
            Me.txt_reason.Text = ""
            ' txt_leave_date.Text = Format(Now, "dd/MMM/yyyy") 
            'Me.txt_emp_code.Text = ""
            'Me.txt_name.Text = ""

            'Me.txt_shift_time.Text = ""            
        End If
        'End If
        'Else
        '    MsgBox("Weong Date")
        'End If
        ' End If
    End Sub


    'Protected Sub txt_emp_code_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_emp_code.TextChanged
    '    Dim dt1 As New DataTable
    '    Dim st, st1(), st2 As String
    '    st = Session("user_id")
    '    st1 = st.Split("!")
    '    st2 = st1(0)
    '    If (Me.txt_emp_code.Text = st2) Then
    '        ' dt1 = oh.ExecuteDataSet("SELECT TT.IN_TIME||'--'||TT.OUT_TIME,em.emp_name,TT.SHIFT_ID FROM EMPLOYEE_MASTER EM,TIME_TAB TT WHERE EM.SHIFT_ID=TT.SHIFT_ID AND EM.EMP_CODE='" & Me.txt_emp_code.Text & "' ").Tables(0)
    '        dt1 = oh.ExecuteDataSet("SELECT TT.IN_TIME||'--'||TT.OUT_TIME,em.emp_name,TT.SHIFT_ID FROM EMPLOYEE_MASTER EM,TIME_TAB TT WHERE EM.SHIFT_ID=TT.SHIFT_ID AND EM.EMP_CODE=" & st2 & " ").Tables(0)
    '        If dt1.Rows.Count > 0 Then
    '            Me.txt_reason.Text = ""
    '            Me.txt_emp_code.Text = st2
    '            Me.txt_shift_time.Text = dt1.Rows(0)(0)
    '            Me.txt_name.Text = dt1.Rows(0)(1)
    '            Me.hdn1.Value = dt1.Rows(0)(2)
    '            txt_leave_date.Text = Format(Now, "dd/MMM/yyyy")
    '        Else
    '            'Dim cl_script As New StringBuilder
    '            'cl_script.Append("   alert('NO SUCH EMPLOYEE') ;")
    '            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
    '            'Me.lbl_message.Text = "<FONT SIZE=4 ><B> NO SUCH EMPLOYEE </B></FONT>"
    '            Me.lbl_message.Text = "NO SUCH EMPLOYEE"
    '            Me.lbl_message.Visible = True
    '            Me.txt_emp_code.Text = ""
    '            'Me.txt_going_time.Text = ""
    '            'Me.txt_leave_date.Text = ""
    '            txt_leave_date.Text = Format(Now, "dd/MMM/yyyy")
    '            ' Me.RadioButtonList1.SelectedItem.Text = "NO"
    '            Me.txt_name.Text = ""
    '            Me.txt_reason.Text = ""
    '            Me.txt_shift_time.Text = ""
    '            Me.RadioButtonList1.SelectedValue = "NO"
    '        End If
    '    Else
    '        Me.lbl_message.Visible = True
    '        Me.lbl_message.Text = "LOGIN WITH YOUR EMP_CODE"
    '        Me.txt_name.Text = ""
    '        Me.txt_reason.Text = ""
    '        Me.txt_shift_time.Text = ""
    '        Me.RadioButtonList1.SelectedValue = "NO"
    '    End If
    'End Sub
    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Server.Transfer("../home.aspx")
        'txt_leave_date.Text = Format(Now, "dd/MMM/yyyy")
        'Me.txt_emp_code.Text = ""
        'Me.txt_name.Text = ""
        'Me.txt_reason.Text = ""
        'Me.txt_shift_time.Text = ""
    End Sub

  
   
End Class
