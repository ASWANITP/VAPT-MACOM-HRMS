Imports System.Data
Imports System.Data.OracleClient
Partial Class HRM_Punching_Report_Induvidual_Photo_0e0b060f2544
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt21 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        dt1 = oh.ExecuteDataSet("select f.firm_id from employ_firm f where f.emp_code=" & txtcode.Text & "").Tables(0)
        If (dt1.Rows(0)(0) = Session("firm_id")) Then
            Server.Transfer("Display_punch_report_Branch.aspx?Fdt=" & txtfdt.Text & "&Tdt=" & txttdt.Text & "&Ecode=" & txtcode.Text)
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('You are not authorized');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        ' dt = oh.ExecuteDataSet("select count(emp_code)  from employee_master t where emp_code = " & sf(0) & " and status_id = 1 and t.branch_id = 0  and (((department_id in (189)) or (department_id in (183)) or(department_id in (23)) or (department_id in (304)) or(department_id in (180)) or (department_id in (411)) or (department_id in (179)) or (department_id in (491,472))or department_id in(523)) or emp_code in (11046, 45745, 42887, 13296, 21820, 14291))").Tables(0)

        dt = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=811 and s.emp_id=" & sf(0) & "").Tables(0)
        dt21 = oh.ExecuteDataSet("select count(*) from employee_master t where t.emp_code=" & sf(0) & " and t.department_id in(517,490)").Tables(0)
        If (dt.Rows(0)(0) = 0 And dt21.Rows(0)(0) = 0) Then
            Server.Transfer("../../show_err.aspx")

        End If
        'dt = "select count(*) from employee_master e where e.department_id = 23 and e.emp_code=" & Session("User") & ""
        'If dt.Rows(0)(0) > 0 Then
        '    Dim script_val As String
        '    script_val = "var header;" & "header='" & Me.txtcode.ClientID & "';"
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        'Else
        '    Me.Server.Transfer("../../show_err.aspx")
        'End If
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtcode.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
    End Sub
End Class
