
Partial Class salary_individual_salary_empcode_select_1fd2a2151281
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Salary Statement-Individual"

        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Txt_EmpCode.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)


    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        'Me.Server.Transfer("salstatement_individ_report.aspx?empcode=" & Me.Txt_EmpCode.Text)
        If Session("firm_id") = 24 Then    ' Request id: 18166
            Dim access As Integer
            Dim User() As String = Session("user_id").ToString.Split("!")
            Dim UserId As Integer = User(0)
            access = Session("access_id")
            If Session("access_id") = 33 Then
                Me.Server.Transfer("salstatement_individ_report.aspx?empcode=" & Me.Txt_EmpCode.Text)
            Else
                If UserId = Val(Me.Txt_EmpCode.Text) Then
                    Dim empcode As Integer = Txt_EmpCode.Text
                    Txt_EmpCode.Text = ""
                    Me.Server.Transfer("salstatement_individ_report.aspx?empcode=" & empcode)
                Else
                    Txt_EmpCode.Text = ""
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('Not Allowed!. Please Enter your own code');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Txt_EmpCode.Focus()
                    Exit Sub
                End If
            End If
        ElseIf Session("firm_id") = 2 Then
            Dim access As Integer
            Dim User() As String = Session("user_id").ToString.Split("!")
            Dim UserId As Integer = User(0)
            access = Session("access_id")
            If UserId = Val(Me.Txt_EmpCode.Text) Then
                Dim empcode As Integer = Txt_EmpCode.Text
                Txt_EmpCode.Text = ""
                Me.Server.Transfer("salstatement_individ_report_mab.aspx?empcode=" & empcode)
            Else
                Txt_EmpCode.Text = ""
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('Not Allowed!. Please Enter your own code');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Txt_EmpCode.Focus()
                Exit Sub
            End If
        ElseIf Session("firm_id") = 28 Then
            Me.Server.Transfer("~/payroll/wage slip new mafound/wage_slip.aspx")
        Else
            Me.Server.Transfer("salstatement_individ_report.aspx?empcode=" & Me.Txt_EmpCode.Text)
        End If

    End Sub
End Class
