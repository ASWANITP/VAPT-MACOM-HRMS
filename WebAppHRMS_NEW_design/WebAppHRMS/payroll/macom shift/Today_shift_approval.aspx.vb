Imports System.Data.OracleClient

Public Class Today_shift_approval
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2, dt3, dt4, dt5 As New DataTable
    Dim sf() As String
    Private Const REJECT_FLAG As Integer = 1
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.Subtitle = "TODAY SHIFT APPROVAL"

        If Not IsPostBack Then
            sf = Session("user_id").ToString.Split("!")
            dt3 = oh.ExecuteDataSet("select count(*) from DEPARTMENT_MST where dep_head=" & sf(0) & " ").Tables(0)
            If dt3.Rows(0)(0) = 0 Then

                Me.Response.Redirect("../../show_err.aspx")
            Else
                dt4 = oh.ExecuteDataSet("select -1 as request_id, '-----Select-----' as sname, to_date(null) as request_date from dual union all select t.requ_id, e.emp_name || ' --> ' || e.emp_code || '-->' || t.enter_dt || '-->' || 'Req_ID:' || t.requ_id, t.enter_dt from macom_today_shift t inner join employee_master e on t.emp_code = e.emp_code and t.status = 0 inner join department_mst d on d.dep_id = e.department_id and d.dep_head = " & sf(0) & " order by request_id").Tables(0)
                Me.ddlEmployee.DataSource = dt4
                Me.ddlEmployee.DataValueField = dt4.Columns(0).ColumnName
                Me.ddlEmployee.DataTextField = dt4.Columns(1).ColumnName
                Me.ddlEmployee.DataBind()
            End If
        End If

    End Sub

    Protected Sub ddlEmployee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlEmployee.SelectedIndexChanged
        If ddlEmployee.SelectedValue <> "-1" Then

            '1) SQL with placeholder
            ' Dim sql As String = "select e.emp_name, e.emp_code, d.dep_name, ds.designation, b.branch_name, tl.tl_empcode,m.eff_dt, (select t.shift || ' --> ' || t.in_time || ' -- ' || t.out_time from time_tab t, MACOM_SHIFT_CHANGE m where m.new_shift_id=t.shift_id and m.emp_code= (select k.emp_code from MACOM_SHIFT_CHANGE k where k.request_id= :tlEmpCode)) as old_shift , (select t.shift || ' --> ' || t.in_time || ' -- ' || t.out_time from time_tab t, MACOM_SHIFT_CHANGE m where m.old_shift_id=t.shift_id and m.emp_code= (select k.emp_code from MACOM_SHIFT_CHANGE k where k.request_id= :tlEmpCode)) as new_shift from employee_master e, department_mst d, designation_master ds, post_mst p, branch_master b, tl_trsfr_level tl, employee_master e1, time_tab t, MACOM_SHIFT_CHANGE m where m.request_id = :tlEmpCode and e.department_id = d.dep_id and e.designation_id = ds.designation_id and e.post_id = p.post_id and tl.emp_code = e.emp_code and tl.tl_empcode = e1.emp_code and e.branch_id = b.branch_id and e.shift_id = t.shift_id"
            Dim sql As String = "select e.emp_name, e.emp_code, d.dep_name, ds.designation, b.branch_name, (select s.emp_code||'-->'||s.emp_name from employee_master s where s.emp_code=tl.tl_empcode) as tl_empcode , (select s.emp_code||'-->'||s.emp_name from employee_master s where s.emp_code=d.dep_head)as dep_head , m.eff_dt, td.shift || ' --> ' || td.in_time || ' -- ' || td.out_time, tn.shift || ' --> ' || tn.in_time || ' -- ' || tn.out_time from employee_master e inner join department_mst d on e.department_id = d.dep_id inner join designation_master ds on e.designation_id = ds.designation_id inner join post_mst p on e.post_id = p.post_id inner join branch_master b on e.branch_id = b.branch_id inner join tl_trsfr_level tl on e.emp_code = tl.emp_code inner join macom_today_shift m on m.emp_code = e.emp_code and m.requ_id = :Requestid inner join time_tab td on m.old_shift_id = td.shift_id inner join time_tab tn on m.new_shift_id = tn.shift_id"


            'Dim p As New OracleParameter("tlEmpCode", OracleType.Number) With {.Value = CInt(ddlEmployee.SelectedValue)}
            Dim tlId As Integer = CInt(ddlEmployee.SelectedValue)
            Dim p As New OracleParameter("Requestid", OracleType.Number) With {.Value = tlId}
            ' 3) Execute and pull back the first DataTable
            'Dim ds As DataSet = oh.ExecuteDataSet(sql, p)
            Dim ds As DataSet = oh.ExecuteDataSet(sql, New OracleParameter() {p})
            Dim dt5 As DataTable = ds.Tables(0)

            'dt5 = oh.ExecuteDataSet("select e.emp_name, e.emp_code, d.dep_name, ds.designation, b.branch_name, tl.tl_empcode,m.eff_dt, (select t.shift || ' --> ' || t.in_time || ' -- ' || t.out_time from time_tab t, MACOM_SHIFT_CHANGE m where m.new_shift_id=t.shift_id and m.emp_code=" & Me.ddlEmployee.SelectedValue & ") as old_shift , (select t.shift || ' --> ' || t.in_time || ' -- ' || t.out_time from time_tab t, MACOM_SHIFT_CHANGE m where m.old_shift_id=t.shift_id and m.emp_code=" & Me.ddlEmployee.SelectedValue & ") as new_shift from employee_master e, department_mst d, designation_master ds, post_mst p, branch_master b, tl_trsfr_level tl, employee_master e1, time_tab t, MACOM_SHIFT_CHANGE m where e.emp_code = " & Me.ddlEmployee.SelectedValue & " and e.department_id = d.dep_id and e.designation_id = ds.designation_id and e.post_id = p.post_id and tl.emp_code = e.emp_code and tl.tl_empcode = e1.emp_code and e.branch_id = b.branch_id and e.shift_id = t.shift_id ").Tables(0)

            Me.txtName.Text = dt5.Rows(0)(0)
            Me.txtEmpCode.Text = dt5.Rows(0)(1)
            Me.txtOldShift.Text = dt5.Rows(0)(8)
            Me.ddlRequestedShift.Text = dt5.Rows(0)(9)
            Me.txtEffectiveDate.Text = dt5.Rows(0)(7)
            Me.txtManagerName.Text = dt5.Rows(0)(5)


        End If
    End Sub

    Protected Sub btnRecommend_Click(sender As Object, e As EventArgs) Handles btnRecommend.Click
        Dim script2 As New System.Text.StringBuilder



        If String.IsNullOrWhiteSpace(Me.txtRemarks.Text) Then
            script2.Append("alert('enter your remarks');")
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertScript", script2.ToString(), True)
            Exit Sub
        End If

        sf = Session("user_id").ToString.Split("!")
        Dim script1 As New System.Text.StringBuilder
        Dim parameter(5) As OracleParameter
        parameter(0) = New OracleParameter("empid", OracleType.Number, 150)
        parameter(0).Direction = ParameterDirection.Input
        parameter(0).Value = Me.txtEmpCode.Text


        parameter(1) = New OracleParameter("uid", OracleType.Number, 150)
        parameter(1).Direction = ParameterDirection.Input
        parameter(1).Value = sf(0)

        parameter(2) = New OracleParameter("remarks", OracleType.VarChar, 250)
        parameter(2).Direction = ParameterDirection.Input
        parameter(2).Value = Me.txtRemarks.Text

        parameter(3) = New OracleParameter("flag", OracleType.Number, 150)
        parameter(3).Direction = ParameterDirection.Input
        parameter(3).Value = 2

        parameter(4) = New OracleParameter("req_id", OracleType.Number, 150)
        parameter(4).Direction = ParameterDirection.Input
        parameter(4).Value = Me.ddlEmployee.SelectedValue

        parameter(5) = New OracleParameter("errmsg", OracleType.VarChar, 500)
        parameter(5).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("hrm_today_shift_change", parameter)

        Dim message As String
        message = parameter(5).Value.ToString()

        Try
            'If message.StartsWith("SHIFT") = True Then
            script1.Append("alert('" & message & "');")
            script1.Append("window.open('Today_shift_approval.aspx','_self');")
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertScript", script1.ToString(), True)

            'End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        Dim script2 As New System.Text.StringBuilder

        If String.IsNullOrWhiteSpace(Me.txtRemarks.Text) Then
            script2.Append("alert('enter your remarks');")
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertScript", script2.ToString(), True)
            Exit Sub
        End If

        sf = Session("user_id").ToString.Split("!")
        Dim script1 As New System.Text.StringBuilder
        Dim parameter(6) As OracleParameter
        parameter(0) = New OracleParameter("empid", OracleType.Number, 150)
        parameter(0).Direction = ParameterDirection.Input
        parameter(0).Value = Me.txtEmpCode.Text


        parameter(1) = New OracleParameter("uid", OracleType.Number, 150)
        parameter(1).Direction = ParameterDirection.Input
        parameter(1).Value = sf(0)

        parameter(2) = New OracleParameter("remarks", OracleType.VarChar, 250)
        parameter(2).Direction = ParameterDirection.Input
        parameter(2).Value = Me.txtRemarks.Text

        parameter(3) = New OracleParameter("flag", OracleType.Number, 150)
        parameter(3).Direction = ParameterDirection.Input
        parameter(3).Value = 2

        parameter(4) = New OracleParameter("req_id", OracleType.Number, 150)
        parameter(4).Direction = ParameterDirection.Input
        parameter(4).Value = Me.ddlEmployee.SelectedValue

        parameter(5) = New OracleParameter("reject_flag", OracleType.Number, 150)
        parameter(5).Direction = ParameterDirection.Input
        parameter(5).Value = REJECT_FLAG

        parameter(6) = New OracleParameter("errmsg", OracleType.VarChar, 500)
        parameter(6).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("hrm_today_shift_change", parameter)

        Dim message As String
        message = parameter(6).Value.ToString()

        Try
            'If message.StartsWith("SHIFT") = True Then
            script1.Append("alert('" & message & "');")
            script1.Append("window.open('Today_shift_approval.aspx','_self');")
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertScript", script1.ToString(), True)

            'End If
        Catch ex As Exception
        End Try

    End Sub
End Class