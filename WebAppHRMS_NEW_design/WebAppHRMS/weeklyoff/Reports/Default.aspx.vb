Imports system.data
Imports System.Data.OracleClient

Partial Class HRM_Default_e84cd19b5889
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2 As DataTable
    Dim s As String
    Dim UserCode, l As Integer
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub btnConfrm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfrm.Click

        Dim eid As Integer
        eid = txtecode.Text

        Try
            dt = oh.ExecuteDataSet("select count(emp_code) from employee_master where emp_code='" & eid & "'").Tables(0)
            l = dt.Rows(0)(0)
            If l = 0 Then
                MsgBox("Employee Code Not Found")
                txtecode.Text = ""
                txtecode.Focus()
            Else
                Me.Server.Transfer("Week_Off_Status.aspx?emp_id=" & eid & "")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "EMPLOYEES WEEK OFF  STATUS"
        Dim masterPage As edp = CType(Me.Master, edp)
        masterPage.subtitle = "EMPLOYEES WEEK OFF  STATUS"
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtecode.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
    End Sub
End Class
