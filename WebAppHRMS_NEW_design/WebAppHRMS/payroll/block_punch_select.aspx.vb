Imports System.Data
Partial Class new_newmail_block_punch_select_cdba7c323295
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If CDate(Me.Txt_dt.Text) >= CDate(Format(Date.Now, "dd/MMM/yyyy")) Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' Back date is only allowed ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        Else
            If Me.Chk_emp.Checked = True Then
                If Me.Cmb_emp.SelectedValue = -1 Then
                    Dim cl_script0 As New System.Text.StringBuilder
                    cl_script0.Append("         alert(' Select Employee Code ');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
                Else

                    Server.Transfer("block_punch_details.aspx?dtt='" & Me.Txt_dt.Text & "'&emp=" & Me.Cmb_emp.SelectedValue & "&status=1")
                

                End If
            Else
                Server.Transfer("block_punch_details.aspx?dtt='" & Me.Txt_dt.Text & "'&status=2")
            End If
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If Me.Chk_emp.Checked = True Then
                Me.Cmb_emp.Visible = True
                Me.Txt_dt.Text = Format(Date.Now, "dd/MMM/yyyy")
                Dim dt6 As DataTable = oh.ExecuteDataSet("select -1,' - Select Employee - ' as emp_name from dual union all select cm.emp_code,cm.emp_code||'-'||cm.emp_name as dtl from employee_master cm where cm.status_id=1  and cm.shift_id not in (4,5)  order by emp_name").Tables(0)
                Me.Cmb_emp.DataSource = dt6
                Me.Cmb_emp.DataTextField = dt6.Columns(1).ColumnName
                Me.Cmb_emp.DataValueField = dt6.Columns(0).ColumnName
                Me.Cmb_emp.DataBind()
            Else
                Me.Txt_dt.Text = Format(Date.Now, "dd/MMM/yyyy")
                Me.Cmb_emp.Visible = False
            End If
        End If
        
    End Sub

    Protected Sub Chk_emp_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_emp.CheckedChanged
        If Me.Chk_emp.Checked = True Then
            Me.Cmb_emp.Visible = True
            Dim dt6 As DataTable = oh.ExecuteDataSet("select -1,' - Select Employee - ' as emp_name from dual union all select cm.emp_code,cm.emp_code||'-'||cm.emp_name as dtl from employee_master cm where cm.status_id=1  and cm.shift_id not in (4,5)  order by emp_name").Tables(0)
            Me.Cmb_emp.DataSource = dt6
            Me.Cmb_emp.DataTextField = dt6.Columns(1).ColumnName
            Me.Cmb_emp.DataValueField = dt6.Columns(0).ColumnName
            Me.Cmb_emp.DataBind()
        Else
            Me.Cmb_emp.Visible = False
        End If
    End Sub
End Class
