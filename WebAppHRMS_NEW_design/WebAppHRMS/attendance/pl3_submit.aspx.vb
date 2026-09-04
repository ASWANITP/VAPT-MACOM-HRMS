Imports System.Data
Imports System.Data.OracleClient

Partial Class payroll_pl3_submit_464bf23d1190
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    ' Dim oh As New OracleHelper
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("branch_id") = 0 Then
            Me.pnl_ho.Visible = True
        Else
            Me.rd_ho.SelectedValue = 0
        End If
        If Not IsPostBack Then
            fillemploy()
            fillbr()
        End If

    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Response.Redirect("../home.aspx")

    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If Me.cmb_employ.Items.Count = 0 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert(' No Employee to confirm ');")
            'cl_script0.Append("       window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
        'oh.ExecuteNonQuery("insert into leave_pl3 values(" & Me.cmb_employ.SelectedValue & "," & Session("branch_id") & "," & Me.cmb_particulars.SelectedValue & ",sysdate,'" & Me.txt_reason.Text & "')")
        If Me.txt_reason.Text = "" And Me.cmb_particulars.SelectedValue <> 0 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert(' You must Specify reason ');")
            'cl_script0.Append("       window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            Dim op(3) As OracleParameter
            op(0) = New OracleParameter("emp_code", OracleType.Number, 5)
            op(0).Value = CInt(Me.cmb_employ.SelectedValue)
            op(0).Direction = ParameterDirection.Input
            op(1) = New OracleParameter("brid", OracleType.Number, 5)
            If Me.rd_ho.SelectedValue = 1 And Session("branch_id") = 0 Then
                op(1).Value = Me.cmb_branch.SelectedValue
            Else
                op(1).Value = CInt(Session("branch_id"))
            End If
            op(1).Direction = ParameterDirection.Input
            op(2) = New OracleParameter("leave", OracleType.Number, 3)
            op(2).Value = CInt(Me.cmb_particulars.SelectedValue)
            op(2).Direction = ParameterDirection.Input
            op(3) = New OracleParameter("leave_reason", OracleType.VarChar, 250)
            If Me.cmb_particulars.SelectedValue = 0 And Me.txt_reason.Text = "" Then
                op(3).Value = "NOT INFORMED "
            Else
                op(3).Value = Me.txt_reason.Text
            End If
            op(3).Direction = ParameterDirection.Input
            oh.ExecuteNonQuery("pl3_confirm", op)
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' Confirmed ');")
            'cl_script0.Append("       window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
            fillemploy()
            Me.txt_reason.Text = ""
        End If
    End Sub
    Sub fillemploy()
        Dim df() As String
        df = Session("user_id").ToString.Split("!")
        If Session("branch_id") = 0 Then
            'dt = oh.ExecuteDataSet("select a.emp_code,upper(a.emp_name)||'~'||a.emp_code from employee_master a,daily_attend b,department_mst c where a.emp_code=b.emp_code and a.status_id=1 and b.m_time is null and c.dep_head=" & df(0) & " and not exists (select emp_code from leave_pl3 c where to_date(leave_date)=to_date(sysdate) and a.emp_code=c.emp_code) and not exists (select emp_code from employ_leave_dtl d where to_date(sysdate) between to_date(d.leave_frdate) and to_date(d.leave_todate) and a.emp_code=d.emp_code)  and a.shift_id not in (4,5) order by  upper(a.emp_name)").Tables(0)
            dt = oh.ExecuteDataSet("select a.emp_code,upper(a.emp_name)||'~'||a.emp_code from employee_master a,daily_attend b  where a.emp_code=b.emp_code and a.status_id=1 and b.m_time is null and a.branch_id=0 and exists (select dep_id from department_mst c where a.department_id=c.dep_id and c.dep_head=" & df(0) & ")  and a.shift_id not in (4,5) and not exists (select t.emp_code from training_attend t where t.emp_code=a.emp_code and to_date(t.training_date)=to_date(sysdate) and t.in_time is not null) and not exists (select emp_code from leave_pl3 c where to_date(leave_date)=to_date(sysdate) and a.emp_code=c.emp_code) and not exists (select emp_code from employ_leave_dtl d where to_date(sysdate) between to_date(d.leave_frdate) and to_date(d.leave_todate) and a.emp_code=d.emp_code) order by  upper(a.emp_name)").Tables(0)
        Else
            dt = oh.ExecuteDataSet("select a.emp_code,upper(a.emp_name)||'~'||a.emp_code from employee_master a,daily_attend b where a.emp_code=b.emp_code and a.status_id=1 and b.m_time is null and a.branch_id=" & Session("branch_id") & " and not exists (select t.emp_code from training_attend t where t.emp_code=a.emp_code and to_date(t.training_date)=to_date(sysdate) and t.in_time is not null) and not exists (select emp_code from leave_pl3 c where to_date(leave_date)=to_date(sysdate) and a.emp_code=c.emp_code) and not exists (select emp_code from employ_leave_dtl d where to_date(sysdate) between to_date(d.leave_frdate) and to_date(d.leave_todate) and a.emp_code=d.emp_code)  and a.shift_id not in (4,5) order by  upper(a.emp_name)").Tables(0)
        End If
        Me.cmb_employ.DataSource = dt
        Me.cmb_employ.DataTextField = dt.Columns(1).ColumnName
        Me.cmb_employ.DataValueField = dt.Columns(0).ColumnName
        Me.cmb_employ.DataBind()
    End Sub
    Sub fillbr()
        Dim sd As DataTable
        sd = oh.ExecuteDataSet("select branch_id,branch_name from branch where branch_id not in (0,9999)").Tables(0)
        Me.cmb_branch.DataSource = sd
        Me.cmb_branch.DataTextField = sd.Columns(1).ColumnName
        Me.cmb_branch.DataValueField = sd.Columns(0).ColumnName
        Me.cmb_branch.DataBind()
    End Sub

    Protected Sub rd_ho_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rd_ho.SelectedIndexChanged
        If Me.rd_ho.SelectedValue = 1 Then
            Me.pnl_br.Visible = True
        ElseIf Me.rd_ho.SelectedValue = 0 Then
            Me.pnl_br.Visible = False
            fillemploy()
        End If
    End Sub

    Protected Sub cmb_branch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_branch.SelectedIndexChanged
        dt = oh.ExecuteDataSet("select a.emp_code,upper(a.emp_name)||'~'||a.emp_code from employee_master a,daily_attend b where a.emp_code=b.emp_code and a.status_id=1 and b.m_time is null and a.branch_id=" & Me.cmb_branch.SelectedValue & " and not exists (select t.emp_code from training_attend t where t.emp_code=a.emp_code and to_date(t.training_date)=to_date(sysdate) and t.in_time is not null) and not exists (select emp_code from leave_pl3 c where to_date(leave_date)=to_date(sysdate) and a.emp_code=c.emp_code) and not exists (select emp_code from employ_leave_dtl d where to_date(sysdate) between to_date(d.leave_frdate) and to_date(d.leave_todate) and a.emp_code=d.emp_code)  and a.shift_id not in (4,5) order by  upper(a.emp_name)").Tables(0)
        Me.cmb_employ.DataSource = dt
        Me.cmb_employ.DataTextField = dt.Columns(1).ColumnName
        Me.cmb_employ.DataValueField = dt.Columns(0).ColumnName
        Me.cmb_employ.DataBind()
    End Sub
End Class
