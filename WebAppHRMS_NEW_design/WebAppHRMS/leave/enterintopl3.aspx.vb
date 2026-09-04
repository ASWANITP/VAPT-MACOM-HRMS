Imports system.data
Imports System.Data.OracleClient
Partial Class enterinpl3_enterintopl3_1d52d4778429
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Me.Txt_fdate.Text = Format(Date.Today, "dd/MMM/yyyy")

            dt = oh.ExecuteDataSet("select a.emp_code||'--------'||upper(substr(d.emp_name,0,19)) as emp_name,a.emp_code from attendance a,branch_master c,employee_master d,department_mst e where exists (select emp_code from leave_pl3 l where a.emp_code=l.emp_code and to_date(l.leave_date)='" & Me.Txt_fdate.Text & "') and exists (select emp_code from employ_leave_dtl el where a.emp_code=el.emp_code and '" & Me.Txt_fdate.Text & "' between to_date(el.leave_frdate) and to_date(el.leave_todate)) and m_time is NULL and e_time is NULL and a.shift_id not in (4,5) and d.status_id=1 and a.branch_id=c.branch_id and a.emp_code=d.emp_code and d.department_id=e.dep_id and to_date(a.curr_date)='" & Me.Txt_fdate.Text & "' order by a.emp_code,a.branch_id,d.department_id").Tables(0)
            Me.cmb_employ.DataSource = dt
            Me.cmb_employ.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_employ.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_employ.DataBind()


        End If
    End Sub

    Protected Sub cmb_employ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_employ.SelectedIndexChanged
        Me.Txt_date.Text = ""
        Me.Txt_branch.Text = ""
        Me.Txt_reas.Text = ""
        dt1 = oh.ExecuteDataSet("select a.branch_id,b.branch_name from employee_master a,branch_master b where a.branch_id=b.branch_id and a.emp_code=" & Me.cmb_employ.SelectedValue & "").Tables(0)
        Me.Txt_branch.Text = dt1.Rows(0)(1)
        Me.Txt_date.Text = Me.Txt_fdate.Text


    End Sub
    Sub loa()
        dt = oh.ExecuteDataSet("select a.emp_code||'--------'||upper(substr(d.emp_name,0,19)) as emp_name,a.emp_code from attendance a,branch_master c,employee_master d,department_mst e where not exists (select emp_code from leave_pl3 l where a.emp_code=l.emp_code and to_date(l.leave_date)='" & Me.Txt_fdate.Text & "') and not exists (select emp_code from employ_leave_dtl el where a.emp_code=el.emp_code and '" & Me.Txt_fdate.Text & "' between to_date(el.leave_frdate) and to_date(el.leave_todate)) and m_time is NULL and e_time is NULL and a.shift_id not in (4,5) and d.status_id=1 and a.branch_id=c.branch_id and a.emp_code=d.emp_code and d.department_id=e.dep_id and to_date(a.curr_date)='" & Me.Txt_fdate.Text & "' order by a.emp_code").Tables(0)
        Me.cmb_employ.DataSource = dt
        Me.cmb_employ.DataTextField = dt.Columns(0).ColumnName
        Me.cmb_employ.DataValueField = dt.Columns(1).ColumnName
        Me.cmb_employ.DataBind()

    End Sub

    Protected Sub Txt_fdate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Txt_date.Text = ""
        Me.Txt_branch.Text = ""
        Me.Txt_reas.Text = ""
        dt = oh.ExecuteDataSet("select a.emp_code||'--------'||upper(substr(d.emp_name,0,19)) as emp_name,a.emp_code from attendance a,branch_master c,employee_master d,department_mst e where not exists (select emp_code from leave_pl3 l where a.emp_code=l.emp_code and to_date(l.leave_date)='" & Me.Txt_fdate.Text & "') and not exists (select emp_code from employ_leave_dtl el where a.emp_code=el.emp_code and '" & Me.Txt_fdate.Text & "' between to_date(el.leave_frdate) and to_date(el.leave_todate)) and m_time is NULL and e_time is NULL and a.shift_id not in (4,5) and d.status_id=1 and a.branch_id=c.branch_id and a.emp_code=d.emp_code and d.department_id=e.dep_id and to_date(a.curr_date)='" & Me.Txt_fdate.Text & "' order by a.emp_code,a.branch_id,d.department_id").Tables(0)
        Me.cmb_employ.DataSource = dt
        Me.cmb_employ.DataTextField = dt.Columns(0).ColumnName
        Me.cmb_employ.DataValueField = dt.Columns(1).ColumnName
        Me.cmb_employ.DataBind()

    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click

        dt2 = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & Me.cmb_employ.SelectedValue & " ").Tables(0)

        oh.ExecuteNonQuery("insert into leave_pl3 values(" & Me.cmb_employ.SelectedValue & "," & dt2.Rows(0)(0) & "," & Me.cmb_levtype.SelectedValue & ",'" & Me.Txt_date.Text & "','" & Me.Txt_reas.Text & "')")
        Me.Txt_date.Text = ""
        Me.Txt_branch.Text = ""
        Me.Txt_reas.Text = ""
        loa()

    End Sub
End Class
