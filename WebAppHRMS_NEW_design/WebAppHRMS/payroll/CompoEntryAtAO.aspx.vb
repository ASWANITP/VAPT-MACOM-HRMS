Imports System.Data
Imports System.Data.OracleClient
Partial Class CompoEntryAtAO_a8608d4f3984
    Inherits System.Web.UI.Page


    Dim CH As New WholeHelper.ClsComCtrl
    Dim str_tkn As New System.Text.StringBuilder
    Dim OH As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim cbResult As String

    Protected Sub Page_Load(ByVal sener As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                Dim fmid As Integer
                fmid = Session("firm_id")
                Dim User() As String = Session("user_id").ToString.Split("!")
                Dim UserId As Integer = User(0)

                If fmid <> 24 Then 'Jewellery request id: 	18134
                    Server.Transfer("../show_err.aspx")
                    Exit Sub
                End If
                dt = OH.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=1826 and s.emp_id=" & UserId & "").Tables(0)  ' change form id
                If (dt.Rows(0)(0) = 0) Then
                    Server.Transfer("../show_err.aspx")
                    Exit Sub
                End If


                Me.txtAppliedDt.Text = Format(Date.Today, "dd/MM/yyyy")
                txtCode.Focus()
            End If
        Catch ex As System.Exception
        End Try
    End Sub

    Protected Sub btnCheckName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheckName.Click

        Dim cl_script1 As New System.Text.StringBuilder
        Dim code As Integer
        Try

            code = CInt(txtCode.Text)

            If txtCode.Text.Length = 0 Then
                cl_script1.Append("         alert('Enter Employee code');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                txtCode.Focus()
                Exit Sub
            End If

            Dim firmid As Integer
            firmid = Session("firm_id")
            'dt = OH.ExecuteDataSet("select emp_name from EMPLOYEE_MASTER where emp_code = " & txtCode.Text & " and status_id in (1,4) and  ").Tables(0)
            dt = OH.ExecuteDataSet("select emp_name from EMPLOYEE_MASTER t, employ_firm f where t.emp_code=f.emp_code and t.emp_code = " & code & " and t.status_id in (1,4) and f.firm_id=" & firmid & " ").Tables(0)

            If dt.Rows.Count > 0 Then
                Dim EmpName As String = dt.Rows(0)(0).ToString
                txtName.Text = EmpName
                listCompo()
                showCount()
                If Val(txtCount.Text) = 0 Then
                    cl_script1.Append("         alert('There are no pending Compensatory Leaves');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    resetPage()
                    Exit Sub
                End If
            Else
                cl_script1.Append("         alert('Invalid Employee code');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                resetPage()
            End If
        Catch ex As System.Exception
            cl_script1.Append("         alert('Please check the Code you entered');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End Try
    End Sub

    Sub listCompo()
        dt = OH.ExecuteDataSet("select -1 as comp_id,'Compansatory_date-Name-State_Name-Expiry_Date' COMPONAME from dual union all select distinct cm.comp_id,TO_CHAR(cd.comp_date, 'DD/MON/YYYY')||'*'||cm.comp_name||'*'||sm.state_name||'*'||TO_CHAR(cd.exp_date, 'DD/MON/YYYY') COMPONAME  from hrm_comp_eligible ce,hrm_comp_dtl cd,hrm_comp_mst cm,state_master sm where cd.comp_id=ce.comp_id and cd.comp_date<=to_date(sysdate) and cd.exp_date>= to_date(sysdate) and sm.state_id=ce.state_id and cm.comp_id=ce.comp_id and ce.status=0 and cd.emp_code=ce.emp_code and ce.emp_code=" & txtCode.Text & " order by comp_id ").Tables(0)
        cmd_comp_det.Items.Clear()
        If dt.Rows.Count > 0 Then
            cmd_comp_det.DataSource = dt
            cmd_comp_det.DataTextField = "COMPONAME"
            cmd_comp_det.DataValueField = "comp_id"
            cmd_comp_det.DataBind()
        End If
    End Sub
    Sub showCount()
        Try
            dt = OH.ExecuteDataSet("select count( distinct cm.comp_id)  from hrm_comp_eligible ce,hrm_comp_dtl cd,hrm_comp_mst cm,state_master sm where cd.comp_id=ce.comp_id and cd.comp_date<=to_date(sysdate) and cd.exp_date>= to_date(sysdate) and sm.state_id=ce.state_id and cm.comp_id=ce.comp_id and ce.status=0 and cd.emp_code=ce.emp_code and ce.emp_code=" & txtCode.Text & " ").Tables(0)
            If dt.Rows.Count > 0 Then
                txtCount.Text = dt.Rows(0)(0).ToString()
            End If
        Catch ex As System.Exception
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Error..Failed to retrieve Compensatory count.');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            txtCode.Text = 0
        End Try
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Try
            Dim User() As String = Session("user_id").ToString.Split("!")
            Dim UserId As Integer = User(0)
            Dim msg As String

            If txtName.Text = "" Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('Please enter Employee code');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Exit Sub
            End If

            If txtFromDt.Text = "" Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('Please enter Compensatory taken date');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Exit Sub
            End If

            If Val(txtCount.Text) = 0 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('There are No pending Compensatory Leave to apply!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Exit Sub
            End If

            If Val(cmd_comp_det.SelectedItem.Value.ToString()) = -1 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('Select the Compensatory Leave to apply!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Exit Sub
            End If

            If txtReason.Text.Length = 0 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('Enter Leave Reason');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                txtReason.Focus()
                Exit Sub
            End If



            If Val(txtCount.Text) > 0 Then
                Dim code, compo_id As Integer
                Dim compo_date, reason, email, message As String

                dt = OH.ExecuteDataSet("select count(*) from hrm_comp_appl t where t.emp_code=" & txtCode.Text & " and to_date(t.leave_dt)=to_date('" & txtFromDt.Text & "') and t.status_id  in (0,1,4)").Tables(0)
                If dt.Rows(0)(0) = 0 Then
                    code = Val(txtCode.Text)
                    compo_id = Val(cmd_comp_det.SelectedItem.Value.ToString())
                    compo_date = txtFromDt.Text.Trim()
                    reason = txtReason.Text
                    email = ""
                    message = ""
                    'code to insert compo off....

                    '--PROCEDURE....HRM_COMPO_ENTRY_AT_AO

                    Dim leave(7) As OracleParameter
                    leave(0) = New OracleParameter("em_code", OracleType.Number)
                    leave(0).Direction = ParameterDirection.Input
                    leave(0).Value = code
                    leave(1) = New OracleParameter("go_dt", OracleType.VarChar, 100)
                    leave(1).Direction = ParameterDirection.Input
                    leave(1).Value = compo_date
                    leave(2) = New OracleParameter("co_id", OracleType.Number, 5)
                    leave(2).Direction = ParameterDirection.Input
                    leave(2).Value = compo_id
                    leave(3) = New OracleParameter("go_reason", OracleType.VarChar, 100)
                    leave(3).Direction = ParameterDirection.Input
                    leave(3).Value = reason
                    leave(4) = New OracleParameter("email", OracleType.VarChar, 300)
                    leave(4).Direction = ParameterDirection.Input
                    leave(4).Value = email
                    leave(5) = New OracleParameter("user_id", OracleType.Number)
                    leave(5).Direction = ParameterDirection.Input
                    leave(5).Value = UserId
                    leave(6) = New OracleParameter("msg", OracleType.VarChar, 100)
                    leave(6).Direction = ParameterDirection.InputOutput
                    leave(7) = New OracleParameter("flag", OracleType.Number)
                    leave(7).Direction = ParameterDirection.Output

                    OH.ExecuteNonQuery("HRM_COMPO_ENTRY_AT_AO", leave)

                    msg = leave(6).Value
                    txtCode.Text = ""
                    resetPage()
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('" & msg & "');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Else
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('Please make sure No compensatory leave applied on this date!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                End If
            End If
        Catch ex As System.Exception
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & ex.Message & "');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End Try
    End Sub

    Sub resetPage()
        Try
            dt.Clear()
            txtName.Text = ""
            txtFromDt.Text = ""
            txtReason.Text = ""
            txtCount.Text = ""
            cmd_comp_det.DataSource = dt
            cmd_comp_det.DataTextField = "COMPONAME"
            cmd_comp_det.DataValueField = "comp_id"
            cmd_comp_det.DataBind()
        Catch ex As System.Exception
        End Try
    End Sub
End Class
