Imports System.Data
Imports System.Data.OracleClient
Imports System.Text.StringBuilder

Partial Class Sal_InsAdditioDeduction_hrm_salIns_AddtionDeduction_f4cfa1865262
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler

    ' --- Variable Declarations ---
    Dim cbResult As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode As Integer
    Dim strResult As New StringBuilder
    Dim str_tkn As New StringBuilder
    Dim cl_script1, cl_script2 As New StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' --- Page Initialization ---
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Salary Addition / Deduction"
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=184 and emp_id=" & UserCode).Tables(0).Rows(0)(0)

        If acce > 0 Then
            ' --- Register Client-Side Scripts ---
            Dim script_val As String = "var header; header='" & Me.txtEcode.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
            Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
        Else
            Me.Server.Transfer("~/show_err.aspx")
        End If

    End Sub


    ' --- Callback Event Handling ---
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return cbResult
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str() As String = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)
        Dim ff As Integer = Session("firm_id")

        Select Case x
            Case "1" ' --- Employee Name Fetch ---
                dt = oh.ExecuteDataSet("select a.emp_name || ' * ' ||a.emp_code from employee_master a,employ_firm f where a.emp_code=f.emp_code and f.firm_id=" & ff & " and a.emp_code = " & str(1) & "").Tables(0)

                If dt.Rows.Count = 0 Then
                    str_tkn.Append("NULL")
                Else
                    str_tkn.Append(dt.Rows(0)(0))
                End If
                cbResult = str_tkn.ToString
            Case "2" ' --- Dynamic Dropdown Population (based on selected value) ---
                Dim ddlVal As String = str(1)

                If ddlVal = "1" Then ' --- Arrear Salary ---
                    dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name from employee_master e,employ_sal_add s where e.emp_code=s.emp_id and s.arrear_sal>0 order by e.emp_code").Tables(0)
                ElseIf ddlVal = "2" Then ' --- Arrear DA ---
                    dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name from employee_master e,employ_sal_add s where e.emp_code=s.emp_id and s.arrear_da > 0 order by e.emp_code").Tables(0)
                ElseIf ddlVal = "3" Then ' --- Other Addition ---
                    dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name from employee_master e,employ_sal_add s where e.emp_code=s.emp_id and s.oth_add > 0 order by e.emp_code").Tables(0)
                ElseIf ddlVal = "4" Then ' --- Remark Addition ---
                    dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name from employee_master e,employ_sal_add s where e.emp_code=s.emp_id and s.remark_add > 0 order by e.emp_code").Tables(0)
                ElseIf ddlVal = "5" Then ' --- LIC ---
                    dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name from employee_master e,employ_sal_add s where e.emp_code=s.emp_id and s.lic> 0 order by e.emp_code").Tables(0)
                ElseIf ddlVal = "6" Then ' --- Professional Tax ---
                    dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name from employee_master e,employ_sal_add s where e.emp_code=s.emp_id and s.p_tax> 0 order by e.emp_code").Tables(0)
                ElseIf ddlVal = "7" Then ' --- TDS ---
                    dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name from employee_master e,employ_sal_add s where e.emp_code=s.emp_id and s.tds> 0 order by e.emp_code").Tables(0)
                ElseIf ddlVal = "8" Then ' --- Other Deduction ---
                    dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name from employee_master e,employ_sal_add s where e.emp_code=s.emp_id and s.oth_ded> 0 order by e.emp_code").Tables(0)
                ElseIf ddlVal = "9" Then ' --- Remark Deduction ---
                    dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name from employee_master e,employ_sal_add s where e.emp_code=s.emp_id and s.remark_ded> 0 order by e.emp_code").Tables(0)
                End If

                If dt2 IsNot Nothing AndAlso dt2.Rows.Count > 0 Then
                    For Each dr As DataRow In dt2.Rows
                        str_tkn.Append(dr(0))
                        str_tkn.Append("!")
                    Next
                End If
                str_tkn.Append("@")
                cbResult = str_tkn.ToString
        End Select

    End Sub

    ' Custom function to check for null or whitespace
    Private Function IsNullOrWhiteSpace(ByVal value As String) As Boolean
        Return String.IsNullOrEmpty(value) OrElse String.IsNullOrEmpty(value.Trim())
    End Function



    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        'btnConfirm.Enabled = False ' Disable the button to prevent multiple submissions
        If Me.rdAdd.Checked OrElse Me.rdDeduction.Checked Then
            If Me.hdnAdd.Value = "" Then
                Dim script1a As New System.Text.StringBuilder
                script1a.Append("        alert('Please click the Add button before proceeding.');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1a.ToString, True)
                Exit Sub
            End If
        End If
        ' Check if remarks are provided based on selected operation (Addition or Deduction)
        If Me.rdAdd.Checked OrElse Me.rdDeduction.Checked Then
            If IsNullOrWhiteSpace(Me.txtRemarks.Text) Then
                Dim script As String = "alert('Remark Validation: Please enter remarks before confirming.');"
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "RemarkAlert", script, True)
                btnConfirm.Enabled = True ' Re-enable the button for another attempt
                Return
            End If
        End If

        'If Not Me.btnAdd.Enabled Then
        '    Dim cl_script31 As New System.Text.StringBuilder(1, 500)
        '    cl_script31.Append("alert('');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client script1", cl_script31.ToString(), True)
        '    Exit Sub
        'End If


        If Me.rdDelete.Checked = True Then
            ' --- Delete Operation ---
            Try
                Dim p(2) As OracleParameter
                p(0) = New OracleParameter("Dataa", OracleType.VarChar, 5000)
                p(0).Direction = ParameterDirection.Input
                p(0).Value = Me.hdnToSendDel.Value

                p(1) = New OracleParameter("Ins", OracleType.Number, 2)
                p(1).Direction = ParameterDirection.Input
                p(1).Value = Me.hdnDelChange.Value

                p(2) = New OracleParameter("Errmsg", OracleType.VarChar, 400)
                p(2).Direction = ParameterDirection.Output

                oh.ExecuteNonQuery("hrm_SalIns_Del", p)

                ' Display success or error message based on database response
                If p(2).Value.ToString.Trim() <> "" Then ' Check if there is a message
                    cl_script1.Append("alert('" & p(2).Value.ToString.Trim() & "');") 'Display the message from the database
                Else
                    cl_script1.Append("alert('Deletion was processed successfully.');")
                End If
            Catch ex As Exception
                cl_script1.Append("alert('An error occurred during the deletion process.');") 'Generic error handling
            Finally
                cl_script1.Append(" window.open('hrm_salIns_AddtionDeduction.aspx','_self');") 'Refresh the Page
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End Try
        Else
            ' --- Add/Update Operation ---
            Try

                Dim remadd As String = ""
                Dim remded As String = ""
                If Me.rdAdd.Checked = True Then
                    remadd = Me.txtRemarks.Text
                ElseIf Me.rdDeduction.Checked = True Then
                    remded = Me.txtRemarks.Text
                End If
                Dim p(3) As OracleParameter
                p(0) = New OracleParameter("Dataa", OracleType.VarChar, 10000000)
                p(0).Value = Me.hdnAdd.Value
                p(0).Direction = ParameterDirection.Input 'Dataa needs input for update

                ' Use the Remarks textbox - assuming you only have one for the whole page
                p(1) = New OracleParameter("remark_add", OracleType.VarChar, 4000)
                p(1).Value = remadd  ' Use the remarks entered in the textbox - corrected to .Text
                p(1).Direction = ParameterDirection.Input 'remark_add is input

                p(2) = New OracleParameter("remark_ded", OracleType.VarChar, 4000)
                p(2).Value = remded ' Use the remarks entered in the textbox. - corrected to .Text
                p(2).Direction = ParameterDirection.Input ' remark_ded is input
                p(2).IsNullable = True ' remark_ded can be null when no deduction made

                p(3) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                p(3).Direction = ParameterDirection.Output

                oh.ExecuteNonQuery("hrm_SalIns_AddDed", p)

                ' Display success or error message based on database response
                'If Not Me.txtRemarks.Text Then

                '    Dim cl_script31 As New System.Text.StringBuilder(1, 500)
                '    cl_script31.Append("alert('Please provide a reason in the remark');")
                '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client script1", cl_script31.ToString(), True)

                If p(3).Value.ToString.Trim() <> "" Then ' Check if there is a message
                    cl_script1.Append("alert('" & p(3).Value.ToString.Trim() & "');") 'Display the message from the database
                    cl_script1.Append(" window.open('hrm_salIns_AddtionDeduction.aspx','_self');") 'Refresh the Page
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Else
                    cl_script1.Append("alert('Addition/Update was processed successfully.');")
                End If
            Catch ex As Exception
                cl_script1.Append("alert('An error occurred during the addition/update process.');") 'Generic error handling
            Finally
                cl_script1.Append(" window.open('hrm_salIns_AddtionDeduction.aspx','_self');") 'Refresh the Page
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End Try
        End If

    End Sub


    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Server.Transfer("~/home.aspx")
    'End Sub
End Class