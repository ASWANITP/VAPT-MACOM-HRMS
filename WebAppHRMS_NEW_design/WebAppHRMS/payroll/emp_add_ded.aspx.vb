Imports System.Data
Imports System.Data.OracleClient
Partial Class emp_add_ded_5592fbd29480
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper
    Dim script1 As New System.Text.StringBuilder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "<B><U>SALARY ADDITIONS AND DEDUCTIONS</U></B>"
        Dim cs As String = "var cont_name;cont_name='" & Me.txt_date.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        Me.txt_arrearbasic.Attributes.Add("onkeypress", "return isNumberKey(event)")
        Me.txt_arrearda.Attributes.Add("onkeypress", "return isNumberKey(event)")
        Me.txt_Addothers.Attributes.Add("onkeypress", "return isNumberKey(event)")
        Me.txt_insurance.Attributes.Add("onkeypress", "return isNumberKey(event)")
        Me.txt_proftax.Attributes.Add("onkeypress", "return isNumberKey(event)")
        Me.txt_tax.Attributes.Add("onkeypress", "return isNumberKey(event)")
        Me.txt_dedothers.Attributes.Add("onkeypress", "return isNumberKey(event)")

        If Not IsPostBack Then
            If Session("access_id") <> 33 Then
                Response.Redirect("../show_err.aspx")
                Exit Sub
            End If
            Dim formaccess As DataTable = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=183 and emp_id=" & Session("user_id").ToString.Split("!")(0)).Tables(0)
            If formaccess.Rows(0)(0) = 0 Then
                Dim script1 As New System.Text.StringBuilder
                script1.Append("        alert('You are not Authorized');")
                script1.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

            End If
            Dim dt As DataTable
            dt = oh.ExecuteDataSet("select emp_code,emp_code|| ' - ' ||emp_name from employee_master where emp_code>9999 order by emp_code").Tables(0)
            Me.cmb_emp.DataSource = dt
            Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_emp.DataBind()
            Me.txt_date.Text = Format(Now.Date, "dd/MMM/yyyy")
            '   Me.Panel2.Visible = False

        End If
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        oh.ExecuteNonQuery("insert into employ_sal_add values(" & Me.cmb_emp.SelectedValue & "," & Val(Me.txt_arrearbasic.Text) & "," & Val(Me.txt_arrearda.Text) & "," & Val(Me.txt_Addothers.Text) & ",'" & Me.txt_addremarks.Text & "'," & Val(Me.txt_insurance.Text) & "," & Val(Me.txt_proftax.Text) & "," & Val(Me.txt_tax.Text) & "," & Val(Me.txt_dedothers.Text) & ",'" & Me.txt_dedremarks.Text & "','" & Me.txt_date.Text & "')")
        script1.Append("        alert('Successfully Saved');")
        script1.Append("window.open('emp_add_ded.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
    End Sub

    'Protected Sub chk_add_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_add.CheckedChanged
    '    If Me.chk_ded.Checked = True Or Me.chk_add.Checked = True Then
    '        Panel2.Visible = True
    '        Me.lb_dt.Visible = True
    '        Me.txt_date.Visible = True

    '    Else
    '        Me.lb_dt.Visible = False
    '        Me.txt_date.Visible = False
    '        Panel2.Visible = False
    '    End If

    '    If Me.chk_add.Checked = True Then
    '        Me.lb_add.Visible = True
    '        Me.lb_addothers.Visible = True
    '        Me.lb_addremarks.Visible = True
    '        Me.lb_arrearda.Visible = True
    '        Me.lb_arrearbasic.Visible = True

    '        Me.txt_Addothers.Visible = True
    '        Me.txt_addremarks.Visible = True
    '        Me.txt_arrearbasic.Visible = True
    '        Me.txt_arrearda.Visible = True
    '        Me.cmd_confirm.Visible = True
    '        Panel4.Visible = False

    '        Me.txt_arrearbasic.Focus()
    '    Else
    '        Me.lb_add.Visible = False
    '        Me.lb_addothers.Visible = False
    '        Me.lb_addremarks.Visible = False
    '        Me.lb_arrearda.Visible = False
    '        Me.lb_arrearbasic.Visible = False

    '        Me.txt_Addothers.Visible = False
    '        Me.txt_addremarks.Visible = False
    '        Me.txt_arrearbasic.Visible = False
    '        Me.txt_arrearda.Visible = False
    '        Panel4.Visible = True

    '    End If
    'End Sub

    'Protected Sub chk_ded_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_ded.CheckedChanged
    '    If Me.chk_ded.Checked = True Or Me.chk_add.Checked = True Then
    '        Panel2.Visible = True
    '        Me.lb_dt.Visible = True
    '        Me.txt_date.Visible = True
    '        Me.cmd_confirm.Visible = True
    '    Else
    '        Me.lb_dt.Visible = False
    '        Me.txt_date.Visible = False
    '        Panel2.Visible = False
    '    End If
    '    If Me.chk_ded.Checked = True Then
    '        Me.lb_ded.Visible = True
    '        Me.lb_dedremarks.Visible = True
    '        Me.lb_dedothers.Visible = True
    '        Me.lb_insurance.Visible = True
    '        Me.lb_ptax.Visible = True
    '        Me.lb_tax.Visible = True
    '        Me.txt_dedothers.Visible = True
    '        Me.txt_dedremarks.Visible = True
    '        Me.txt_tax.Visible = True
    '        Me.txt_insurance.Visible = True
    '        Me.txt_proftax.Visible = True

    '        Me.txt_insurance.Focus()
    '    Else
    '        Me.lb_ded.Visible = False
    '        Me.lb_dedremarks.Visible = False
    '        Me.lb_dedothers.Visible = False
    '        Me.lb_insurance.Visible = False
    '        Me.lb_ptax.Visible = False
    '        Me.lb_tax.Visible = False
    '        Me.txt_dedothers.Visible = False
    '        Me.txt_dedremarks.Visible = False
    '        Me.txt_tax.Visible = False
    '        Me.txt_insurance.Visible = False
    '        Me.txt_proftax.Visible = False
    '    End If
    'End Sub
End Class
