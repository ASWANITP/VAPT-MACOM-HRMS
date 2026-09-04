Imports System.Data
Imports System.Data.OracleClient
Partial Class nov2009_mmm_br_select_traansfer_433d55fc1090
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frID = Session("firm_ID").ToString

        dt = oh.ExecuteDataSet("select e.emp_code from employee_master e,employ_firm f where e.emp_code=f.emp_code and e.emp_code=" & Me.Txt_emp.Text & " and status_id=1 and f.firm_id=" & frID & "").Tables(0)

        If dt.Rows.Count > 0 Then
            If Session("firm_id") = 2 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("window.open('br_Payroll_Transfer_rpt_mab.aspx?&emp=" & Me.Txt_emp.Text & "','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("window.open('br_Payroll_Transfer_rpt.aspx?&emp=" & Me.Txt_emp.Text & "','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Employee does not exist');")
             Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        End If
    End Sub

   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_emp.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)

        '--changed
        If Session("access_id") <> 33 Then

            Server.Transfer("../../show_err.aspx")
        End If
    End Sub
End Class
