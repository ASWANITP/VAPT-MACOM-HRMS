Imports System.Data.OracleClient
Public Class Shift_Change_Request
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dtn, dtn1, dt2, dt3, st As New DataTable
    Dim sf(), sf1(), sf2(), app, rec, frm, dm As String
    Dim shift As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sf = Session("user_id").ToString.Split("!")
        frm = Session("firm_id")

        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.Subtitle = "EMPLOYEE SHIFT REQUEST"
        If Not IsPostBack Then

            txtRequestedDate.Text = DateTime.Now.ToString("dd-MM-yyyy")
            dt = oh.ExecuteDataSet("select e.emp_name, e.emp_code, d.dep_name, ds.designation, b.branch_name, tl.tl_empcode, t.shift || ' --> ' || t.in_time || ' -- ' || t.out_time, d.dep_name,t.shift_id from employee_master e, department_mst d, designation_master ds, post_mst p, branch_master b, tl_trsfr_level tl, employee_master e1, time_tab t where e.emp_code = " & sf(0) & " and e.department_id = d.dep_id and e.designation_id = ds.designation_id and e.post_id = p.post_id and tl.emp_code = e.emp_code and tl.tl_empcode = e1.emp_code and e.branch_id = b.branch_id and e.shift_id=t.shift_id").Tables(0)

            Me.txtName.Text = dt.Rows(0)(0)
            Me.txtEmpCode.Text = dt.Rows(0)(1)
            Me.txtCurrentShift.Text = dt.Rows(0)(6)
            Me.txtDepartment.Text = dt.Rows(0)(2)
            Session("shif") = dt.Rows(0)(8)



            ' dt3 = oh.ExecuteDataSet("select -1 as in_time, '-----Select-----' as sname from dual union all select distinct t.shift_id, t.shift || ' --> ' || t.in_time || ' -- ' || t.out_time from mactech.time_tab t, mactech.employee_master e where e.shift_id=t.shift_id and e.firm_id=8 order by in_time").Tables(0)
            dt3 = oh.ExecuteDataSet("select -1 as in_time, '-----Select-----' as name from dual union all select t.shift_id, t.shift || ' --> ' || t.in_time || ' -- ' || t.out_time from time_tab t, TIME_TAB_MACOM m where t.shift_id = m.shiftid and t.shift_id in (1,2,3,6,7,9,10,19,64,86,100,187,186,40) order by in_time").Tables(0)

            Me.ddlNewShift.DataSource = dt3
            Me.ddlNewShift.DataValueField = dt3.Columns(0).ColumnName
            Me.ddlNewShift.DataTextField = dt3.Columns(1).ColumnName
            Me.ddlNewShift.DataBind()


        End If
    End Sub


    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim script2 As New System.Text.StringBuilder

        If String.IsNullOrWhiteSpace(Me.txtRemarks.Text) Then
            script2.Append("alert('enter your remarks');")
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertScript", script2.ToString(), True)

        End If

        If Me.Session("shif") = Me.ddlNewShift.SelectedValue Then

            script2.Append("alert('please select another shift');")
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertScript", script2.ToString(), True)
            Exit Sub

        End If
        sf = Session("user_id").ToString.Split("!")
        Dim script1 As New System.Text.StringBuilder
        Dim parameter(5) As OracleParameter
        parameter(0) = New OracleParameter("empid", OracleType.Number, 150)
        parameter(0).Direction = ParameterDirection.Input
        parameter(0).Value = sf(0)

        Dim parameterDate As DateTime = Convert.ToDateTime(txtEffectiveDate.Value)
        parameter(1) = New OracleParameter("effdt", OracleType.DateTime)
        parameter(1).Direction = ParameterDirection.Input
        parameter(1).Value = parameterDate

        parameter(2) = New OracleParameter("newshift", OracleType.Number, 150)
        parameter(2).Direction = ParameterDirection.Input
        parameter(2).Value = Me.ddlNewShift.SelectedValue

        parameter(3) = New OracleParameter("remark", OracleType.VarChar, 250)
        parameter(3).Direction = ParameterDirection.Input
        parameter(3).Value = Me.txtRemarks.Text

        parameter(4) = New OracleParameter("flag", OracleType.Number, 150)
        parameter(4).Direction = ParameterDirection.Input
        parameter(4).Value = 1

        parameter(5) = New OracleParameter("msg", OracleType.VarChar, 500)
        parameter(5).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("hrm_change_shift_Macom", parameter)

        Dim message As String
        message = parameter(5).Value.ToString()

        Try
            'If message.StartsWith("SHIFT") = True Then
            script1.Append("alert('" & message & "');")
            script1.Append("window.open('Shift_Change_Request.aspx','_self');")
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertScript", script1.ToString(), True)

            'End If
        Catch ex As Exception
        End Try

    End Sub


End Class