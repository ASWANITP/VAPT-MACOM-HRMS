Imports System.Data
Imports System.Data.OracleClient
Partial Class Salary_Statement_Release_749f8a378927
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim res As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim sf() As String
            sf = Session("user_id").ToString.Split("!")
            dt1 = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=1816 and s.emp_id=" & sf(0) & "").Tables(0)
            If (dt1.Rows(0)(0) = 0) Then
                Server.Transfer("../show_err.aspx")
            End If
            If Not IsPostBack Then
                showStatus()
            End If
        Catch ex As System.Exception
        End Try
    End Sub

    Sub showStatus()
        Dim firm As Integer
        Dim stat As Integer
        firm = Convert.ToInt32(Me.Session("firm_id"))
        dt = oh.ExecuteDataSet("Select t.block_status from hrm_salary_release t where t.firm_id=" & firm & " ").Tables(0)
        If dt.Rows.Count > 0 Then
            stat = dt.Rows(0)(0)
        End If
        If stat = 1 Then
            lblMsg.Text = "RELEASED"
            lblMsg.ForeColor = Drawing.Color.DarkGreen
        End If
        If stat = 0 Then
            lblMsg.Text = "BLOCKED"
            lblMsg.ForeColor = Drawing.Color.Maroon
        End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        'Record to be added for any firm those who wants to block/Release salary statement...Table: hrm_salary_release.
        Dim firm As Integer
        Dim frmCheck As Integer = 0
        Dim cl_script As New StringBuilder
        firm = Convert.ToInt32(Me.Session("firm_id"))
        Try
            If Cmb_action.SelectedItem.Value = -1 Then
                cl_script.Append("   alert('Please select the action you want to perform.') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "Salary Release", cl_script.ToString, True)
                Exit Sub
            End If

            dt.Clear()
            dt = oh.ExecuteDataSet("Select count(*) from hrm_salary_release t where t.firm_id=" & firm & " ").Tables(0)
            If dt.Rows(0)(0) = 0 Then
                frmCheck = 0
            Else
                frmCheck = 1
            End If

            If frmCheck = 0 Then
                cl_script.Append("   alert('This Feature is Not enabled for you...Contact IT') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "Salary Release", cl_script.ToString, True)
                Exit Sub
            End If


            Dim opt As Integer = 0
            opt = Cmb_action.SelectedItem.Value
            oh.ExecuteNonQuery("update hrm_salary_release set block_status = " & opt & " where firm_id=" & firm & "")
            cl_script.Append("   alert('Successfully updated.') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "Salary Release", cl_script.ToString, True)
            showStatus()
            Cmb_action.SelectedIndex = 0
        Catch ex As System.Exception
            cl_script.Append("   alert('Failed to update.') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "Salary Release", cl_script.ToString, True)
        End Try
    End Sub

End Class
