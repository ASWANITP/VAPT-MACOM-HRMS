Imports System.Data
Imports System.Data.OracleClient
Partial Class Appointment_Order_appointmentorder_e89e90669335
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("firm_id") = 24 Then
            Server.Transfer("appointmentorder_jwel.aspx")
        End If

        If Session("firm_id") = 8 Then
            Server.Transfer("appointmentorder_mac.aspx")
        End If
        If Session("firm_id") = 27 Then
            Server.Transfer("Appointmnt_Mafarm.aspx")
        End If
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txt_dt.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)


        If Session("access_id") = 33 Or Session("access_id") = 60 Then
            If Not IsPostBack Then
                Dim dt As New DataTable
                dt = oh.ExecuteDataSet("select e.emp_code||'-'||e.emp_name, e.emp_code from employee_master e,employ_firm f where e.emp_code=f.emp_code and f.firm_id= " & Session("firm_id") & " and e.status_id=1 and e.emp_code>9999 order by emp_code").Tables(0)
                Me.cmb_code.DataSource = dt
                Me.cmb_code.DataTextField = dt.Columns(0).ColumnName
                Me.cmb_code.DataValueField = dt.Columns(1).ColumnName
                Me.cmb_code.DataBind()
                Me.txt_dt.Text = Format(Now.Date, "dd/MMM/yyyy")

            End If
        Else
            Response.Redirect("../../show_err.aspx")
        End If
    End Sub

    Protected Sub cmd_appletter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_appletter.Click
        Dim dt2 As DataTable = oh.ExecuteDataSet("select designation from designation_master d,employ_promotion_dtl ep where d.designation_id=ep.designation_id and  ep.from_dt in (select min(pe.from_dt) from employ_promotion_dtl pe where pe.emp_code = " & Me.cmb_code.SelectedValue & ") and ep.emp_code=" & Me.cmb_code.SelectedValue & " and ep.status_id=1").Tables(0)

        Dim dt As DataTable
        dt = oh.ExecuteDataSet("select e.emp_type,d.grade_id from employee_master e,designation_master d,employ_promotion_dtl ep where e.emp_code=" & Me.cmb_code.SelectedValue & " and ep.designation_id=d.designation_id and e.emp_code=ep.emp_code and ep.from_dt in(select min(pe.from_dt) from employ_promotion_dtl pe where pe.emp_code=" & Me.cmb_code.SelectedValue & ")").Tables(0)
        Dim dt1 As DataTable
        dt1 = oh.ExecuteDataSet("select e.emp_name, h.post  from hrm_assign_delegate h, employee_master e  where h.emp_code = e.emp_code  and h.module_id = 1  and " & dt.Rows(0)(1) & " between h.assign_grade_from and  h.assign_grade_to  and h.firm_id=" & Session("firm_id") & "").Tables(0)
        If (Session("firm_id") = 8) Then
            dt1 = oh.ExecuteDataSet("select e.emp_name, h.post  from hrm_assign_delegate h, employee_master e  where h.emp_code = e.emp_code  and h.module_id = 1  and " & dt.Rows(0)(1) & " between h.assign_grade_from and  h.assign_grade_to  and h.firm_id=8").Tables(0)
            Server.Transfer("appointment_order8.aspx?empid=" & Me.cmb_code.SelectedValue & "&confirm_dt=" & Me.txt_dt.Text & "&confirm_by=" & dt1.Rows(0)(0) & "&confirm_post=" & dt1.Rows(0)(1) & "&subject=" & "Offer Of Appointment as " + dt2.Rows(0)(0))
        Else
            Server.Transfer("appointment_order.aspx?empid=" & Me.cmb_code.SelectedValue & "&confirm_dt=" & Me.txt_dt.Text & "&confirm_by=" & dt1.Rows(0)(0) & "&confirm_post=" & dt1.Rows(0)(1) & "&subject=" & "Offer Of Appointment as " + dt2.Rows(0)(0))
        End If
    End Sub

  

    'Protected Sub cmd_ok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_ok.Click
    '    Dim dt As DataTable = oh.ExecuteDataSet("select emp_type,designation_id from employee_master where emp_code=" & Me.cmb_code.SelectedValue).Tables(0)
    '    If dt.Rows(0)(1) = 74 Then
    '        Me.txt_subject.Text = "Offer of Appointment"
    '    ElseIf dt.Rows(0)(0) = 2 Then
    '        Me.txt_subject.Text = "Offer of Appointment(Outsource)"
    '    Else
    '        Me.txt_subject.Text = "Offer of Appointment"
    '    End If
    '    '  Me.Panel1.Visible = True
    '    Me.Panel4.Visible = True
    '    Me.Panel2.Visible = True
    'End Sub
End Class
