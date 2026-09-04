Imports System.Data
Imports System.Data.OracleClient
Partial Class Leave_Details_emp_leave_select_7d01b3034805
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim str As String
    Dim fir As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "View different leave details of selected Employee"
        fir = Session("firm_id")
        Dim userid As String = Session("user_id").Split("!")(0)
        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Txt_From.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)

        If Not IsPostBack Then
            dt1 = oh.ExecuteDataSet("select m.emp_code from employee_master m where m.firm_id=" & fir & " and m.firm_id in (6,31) and m.emp_code= " & userid & "").Tables(0)
            If Session("access_id") = 33 And dt1.Rows.Count > 0 Then
                CType(Me.Master, WebAppHRMS.edp).Subtitle = "View different leave details of selected Employee"
            Else
                Response.Redirect("../show_err.aspx")
            End If
        End If
    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        Dim p As Integer
        Dim d As Integer
        If (Me.Ckpost.Checked = False And Me.Ckdist.Checked = False) Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select Any CheckBox');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        ElseIf (Me.Ckpost.Checked = True And Me.DDLpost.SelectedIndex = -1) Then
            'If () Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select Any Post ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            'Else
            '    p = 1

            'End If
        ElseIf (Me.Ckdist.Checked = True And Me.DDLbranch.SelectedIndex = -1) Then
            'If () Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select Any Branch ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            'Else
            '    d = 1

            'End If
        ElseIf CDate(Me.Txt_From.Text) > CDate(Me.Txt_to.Text) Or CDate(Me.Txt_to.Text) > Date.Now Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('To Date Invalid');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            If (Me.Ckdist.Checked = True) Then
                Me.Server.Transfer("view_leave_rpt_branch.aspx?branchid=" & Me.DDLbranch.SelectedValue & "&leavetype=" & Me.Cmb_Leave.SelectedValue & "&leavefrom=" & Me.Txt_From.Text & "&leaveto=" & Me.Txt_to.Text)
            ElseIf (Me.Ckpost.Checked = True) Then
                Me.Server.Transfer("view_leave_rpt_post.aspx?postid=" & Me.DDLpost.SelectedValue & "&leavetype=" & Me.Cmb_Leave.SelectedValue & "&leavefrom=" & Me.Txt_From.Text & "&leaveto=" & Me.Txt_to.Text)
            Else
                Response.Redirect("../show_err.aspx")
            End If


        End If
    End Sub


    Protected Sub Ckpost_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ckpost.CheckedChanged
        If (Me.Ckpost.Checked = True) Then
            Ckdist.Enabled = False
            DDLbranch.Enabled = False
            str = "select 0,'----SELECT----' as postname from dual union select distinct(e.post_id), t.post_name from employee_master e,post_mst t where e.post_id = t.post_id and e.firm_id = 6"
            dt = oh.ExecuteDataSet(str).Tables(0)
            Me.DDLpost.DataSource = dt
            Me.DDLpost.DataTextField = dt.Columns(1).ColumnName
            Me.DDLpost.DataValueField = dt.Columns(0).ColumnName
            Me.DDLpost.DataBind()
        Else
            Ckdist.Enabled = True
            DDLbranch.Enabled = True
            Me.DDLpost.SelectedIndex = -1
            Me.Cmb_Leave.SelectedIndex = -1
            Me.Txt_From.Text = ""
            Me.Txt_to.Text = ""
            'Me.Cmb_Employee.SelectedIndex = -1
            Me.DDLbranch.SelectedIndex = -1

        End If
    End Sub

    'Protected Sub DDLpost_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLpost.SelectedIndexChanged
    '    str = "select 0 id,'---- SELECT----' emp from dual union select  e.emp_code id,e.emp_code || ' ' || e.emp_name emp from employee_master e,employ_firm ef where e.emp_code>9999 and shift_id not in(4,5)and status_id<>3 and e.emp_code=ef.emp_code and e.post_id=" & DDLpost.SelectedValue & " and ef.firm_id=" & fir & " order by emp"
    '    dt = oh.ExecuteDataSet(str).Tables(0)
    '    Me.Cmb_Employee.DataSource = dt
    '    Me.Cmb_Employee.DataTextField = dt.Columns(1).ColumnName
    '    Me.Cmb_Employee.DataValueField = dt.Columns(0).ColumnName
    '    Me.Cmb_Employee.DataBind()
    'End Sub

    Protected Sub Ckdist_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ckdist.CheckedChanged

        If (Me.Ckdist.Checked = True) Then
            Ckpost.Enabled = False
            DDLpost.Enabled = False
            Dim dt1 As New DataTable
            str = "select '---- SELECT----' as BranchName, -1 id from dual union select upper(BR.BRANCH_NAME)BranchName, BR.branch_id id FROM BRANCH_MASTER BR where br.branch_id in (select em.branch_id from employee_master em where em.status_id in (1) and em.emp_code in (select ef.emp_code from employ_firm ef where ef.firm_id=" & fir & "))order by id"
            dt1 = oh.ExecuteDataSet(str).Tables(0)
            Me.DDLbranch.DataSource = dt1
            Me.DDLbranch.DataTextField = dt1.Columns(0).ColumnName
            Me.DDLbranch.DataValueField = dt1.Columns(1).ColumnName
            Me.DDLbranch.DataBind()
        Else
            Ckpost.Enabled = True
            DDLpost.Enabled = True
            Me.DDLpost.SelectedIndex = -1
            Me.Cmb_Leave.SelectedIndex = -1
            Me.Txt_From.Text = ""
            Me.Txt_to.Text = ""
            'Me.Cmb_Employee.SelectedIndex = -1
            Me.DDLbranch.SelectedIndex = -1
        End If
    End Sub

    'Protected Sub DDLbranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLbranch.SelectedIndexChanged
    '    Dim dt1 As New DataTable
    '    str = "select '---- SELECT----' , 0 from dual union select e.emp_code || ' ' || e.emp_name, e.emp_code from employee_master e, employ_firm ef, branch_master b where e.emp_code > 9999 and shift_id not in (4, 5) and e.status_id <> 3 and e.emp_code = ef.emp_code and e.branch_id = b.branch_id and e.branch_id=" & DDLbranch.SelectedValue & " and e.firm_id = ef.firm_id and ef.firm_id=" & fir & ""
    '    dt1 = oh.ExecuteDataSet(str).Tables(0)
    '    Me.Cmb_Employee.DataSource = dt1
    '    Me.Cmb_Employee.DataTextField = dt1.Columns(0).ColumnName
    '    Me.Cmb_Employee.DataValueField = dt1.Columns(1).ColumnName
    '    Me.Cmb_Employee.DataBind()

    'End Sub

 
    Protected Sub Btedit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btedit.Click
        'Me.Cmb_Employee.SelectedIndex = -1
        Me.DDLbranch.SelectedIndex = -1
        Me.DDLpost.SelectedIndex = -1
        Me.Ckdist.Enabled = True
        Me.Ckdist.Checked = False
        Me.Ckpost.Checked = False
        Me.Ckpost.Enabled = True
        Me.Cmb_Leave.SelectedIndex = -1
        Me.Txt_From.Text = ""
        Me.Txt_to.Text = ""
        Me.DDLbranch.Enabled = True
        Me.DDLpost.Enabled = True
    End Sub
End Class

