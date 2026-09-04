Imports System.Data
Imports System.Data.OracleClient
Partial Class Shift_Change_hrm_shiftChange_3ddee0529768
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler

    Dim cbResult As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode As Integer
    Dim sf() As String
    Dim fnm, alls() As String
    Dim PostID, BranchID, AreaID, RegID As Integer
    Dim strResult As New System.Text.StringBuilder

    Dim str_tkn As New System.Text.StringBuilder
    Dim DesID As Integer
    Dim DepID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            'Dim ass As DataTable = oh.ExecuteDataSet("select count(*) from form_accessibility where emp_id=" & Session("user_id").ToString.Split("!")(0) & " and form_id=2023").Tables(0)
            'If ass.Rows(0)(0) = 1 Then
            '    Server.Transfer("~/payroll/macom shift/hrm_shiftChange2.aspx")
            'End If

            Dim user_id() As String = Session("user_id").ToString.Split("!")
            sql = "select count(t.emp_id) from form_accessibility t where t.form_id=855  and t.emp_id='" & user_id(0) & "' "
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows(0)(0) = 0 Then
                Dim script_val1 As New StringBuilder
                script_val1.Append("         alert('You Not Authorized To View This Page !!');")
                script_val1.Append("         window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script_val1.ToString, True)

            End If
            Dim script_val As String
            script_val = "var header;" & "header='" & Me.ddlEmpname.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
            Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)

            UserAll = Me.Session("user_id").ToString.Split("!")
            UserCode = UserAll(0)

            'CType(Me.Master, WebAppHRMS.edp).Subtitle = "SHIFT CHANGE"

            'If Not IsPostBack Then
            '    dt3 = oh.ExecuteDataSet("select count(*) from department_mst t where t.dep_head=" & UserCode & "").Tables(0)
            '    If dt3.Rows(0)(0) = 0 Then

            '        Server.Transfer("../../show_err.aspx")

            '    Else

            'dt = oh.ExecuteDataSet("select to_char(to_date(sysdate)) from dual").Tables(0)
            'Me.Txtdate.Text = dt.Rows(0)(0)

            'dt2 = oh.ExecuteDataSet("select -1 as in_time ,'-----Select-----' as sname  from dual union all select t.shift_id, t.shift|| ' --> ' || t.in_time || ' -- ' || t.out_time from time_tab t where t.shift_id in (152,153,154,155,156,157,158,159,160,161,162,163,164,165,16) order by in_time").Tables(0)
            'Me.ddlShiftChange.DataSource = dt2
            'Me.ddlShiftChange.DataValueField = dt2.Columns(0).ColumnName
            'Me.ddlShiftChange.DataTextField = dt2.Columns(1).ColumnName
            'Me.ddlShiftChange.DataBind()
            'Me.ddlShiftChange.Focus()

            dt1 = oh.ExecuteDataSet("select to_char(-1) as eid, ' --------SELECT----------' as ename from dual union all select distinct e.emp_code || '|' || d.enter_dt, e.emp_code || '--' || e.emp_name from m_resign_appl d, employee_master e, employ_firm f where e.emp_code = d.emp_code and f.emp_code = d.emp_code and f.firm_id = 8 and e.status_id=1 and d.status in (0, 1, 5, 7, 8)").Tables(0)
            Me.ddlEmpname.DataSource = dt1
            Me.ddlEmpname.DataValueField = dt1.Columns(0).ColumnName
            Me.ddlEmpname.DataTextField = dt1.Columns(1).ColumnName
            Me.ddlEmpname.DataBind()
            Me.ddlEmpname.Focus()
        End If
        'End If

        'End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return cbResult
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

        'Dim cal_data = eventArgument
        'Dim str() As String
        'str = cal_data.ToString.Split("$")
        'Dim st As New StringBuilder
        'Dim x = str(0)

        'Select Case (x)

        '    Case "1"

        '        dt2 = oh.ExecuteDataSet("select a.emp_name || ' * ' || c.dep_name || ' * ' || b.post_name || ' * ' || d.designation || ' * ' || e.shift  from employee_master a,post_mst b , department_mst c, designation_mst d,time_tab e where a.post_id = b.post_id and a.department_id = c.dep_id and a.designation_id = d.designation_id and a.shift_id=e.shift_id and a.emp_code = " & str(1) & "").Tables(0)
        '        str_tkn.Append(dt2.Rows(0)(0))
        '        cbResult = str_tkn.ToString

        '    Case "2"

        '        Dim empid As Integer
        '        empid = str(1)
        '        Dim sid As Integer
        '        sid = str(2)
        '        Try

        '            Dim p(3) As OracleParameter

        '            p(0) = New OracleParameter("EmpID", OracleType.Number, 6)
        '            p(0).Value = empid

        '            p(1) = New OracleParameter("ShID", OracleType.Number, 6)
        '            p(1).Value = sid

        '            p(2) = New OracleParameter("Uid", OracleType.Number, 8)
        '            p(2).Value = UserCode

        '            p(3) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
        '            p(3).Direction = ParameterDirection.Output

        '            oh.ExecuteNonQuery("hrm_Shift_Change_head", p)
        '            cbResult = p(3).Value
        '        Catch ex As Exception
        '            cbResult = ex.Message

        '        End Try

        'End Select

    End Sub

    Protected Sub Btn_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_confirm.Click
        Dim script1 As New System.Text.StringBuilder
        Dim ap As Integer = 0


        If Me.ddlEmpname.SelectedValue = "-1" Then
            script1.Append("   alert(' Please Select an Employee');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            ap = 1
            Exit Sub
        End If
        If Me.Txtdate.Text = "" Then
            script1.Append("   alert(' Please Select the Proposed Exit Date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        If Me.txtcurr.Text = "" Then
            script1.Append("   alert(' Please Select the Current Exit Date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If

        Dim parameter(4) As OracleParameter
        sf = Session("user_id").ToString.Split("!")
        parameter(0) = New OracleParameter("empid", OracleType.Number, 6)
        parameter(0).Direction = ParameterDirection.Input
        parameter(0).Value = Me.ddlEmpname.SelectedValue.Split("|")(0)

        parameter(1) = New OracleParameter("enter_date", OracleType.DateTime, 150)
        parameter(1).Direction = ParameterDirection.Input
        parameter(1).Value = CDate(Me.ddlEmpname.SelectedValue.Split("|")(1))

        parameter(2) = New OracleParameter("new_date", OracleType.DateTime, 150)
        parameter(2).Direction = ParameterDirection.Input
        parameter(2).Value = CDate(Me.Txtdate.Text)


        parameter(3) = New OracleParameter("msg", OracleType.VarChar, 150)
        parameter(3).Direction = ParameterDirection.Output

        parameter(4) = New OracleParameter("change_user", OracleType.Number, 150)
        parameter(4).Direction = ParameterDirection.Input
        parameter(4).Value = CInt(Me.Session("user_id").ToString.Split("!")(0))
        oh.ExecuteNonQuery("hrm_extend_resign", parameter)
        script1.Append("   alert(' " & parameter(3).Value & "');")
        script1.Append("         window.open('notice_period_updation.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)




    End Sub


    Protected Sub ddlEmpname_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpname.SelectedIndexChanged

        Dim usr() As String
        usr = Me.Session("user_id").ToString.Split("!")
        'Me.txtcurr.Text = Format(Now.Date, "dd/MMM/yyyy")
        dt1 = oh.ExecuteDataSet("select to_char (d.resign_dt) from m_resign_appl d, employee_master e,employ_firm f where e.emp_code = d.emp_code and f.emp_code = d.emp_code and f.firm_id = 8 and e.emp_code=" & Me.ddlEmpname.SelectedValue.Split("|")(0)).Tables(0)
        Me.txtcurr.Text = dt1.Rows(0)(0)

    End Sub
End Class
