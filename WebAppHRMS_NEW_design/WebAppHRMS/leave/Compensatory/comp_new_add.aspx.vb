Imports System.Data
Imports System.Data.OracleClient

Partial Class staffaccount_compensatory_add_new_06608cc45600
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim str As String
    Dim dt, dt1, dt2, dt3, dt4, dt5, dt6, dt7 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim CbResult As String = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '------VAPT - improper parameter validation---------------------------------------
        Dim paramCount As Integer = Request.QueryString.Count
        If Request.QueryString.Count > 0 Then
            Response.StatusCode = 400
            Response.StatusDescription = "Bad Request"
            Response.End()
        End If

        CType(Me.Master, WebAppHRMS.edp).Subtitle = "COMPENSATORY ADD & ASSIGN"
        Dim UserAll(), UserCode As String
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_compen.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        If Not IsPostBack Then
            Dim emno As Integer = oh.ExecuteDataSet("select count(d.emp_id)  from form_accessibility d  where d.emp_id=" & UserCode & " and d.form_id=1685").Tables(0).Rows(0)(0)
            Me.hid_access.Value = emno
            'If Me.Session("access_id") = 33 Then
            Me.txt_dt.Text = Format(Date.Now, "dd/MMM/yyyy")
            dt = oh.ExecuteDataSet("SELECT add_months(to_date(TO_CHAR(TRUNC(current_date, 'YYYY'), 'DD-MON-YYYY')),12)-1 FROM dual").Tables(0)
            Me.txt_exdt.Text = Format(dt.Rows(0)(0), "dd/MMM/yyyy")
            str = "select -1,'-Select State-' as state_name from dual union all select cm.state_id,cm.state_name as dtl from state_master cm order by state_name"
            dt = oh.ExecuteDataSet(str).Tables(0)
            Me.cmb_state.DataSource = dt
            Me.cmb_state.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_state.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_state.DataBind()
            dt1 = oh.ExecuteDataSet("select -1, '-Select district-' as district_name   from dual union all select cm.district_id, s.state_name||'--'||cm.district_name dtl   from district_master cm   join state_master s on s.state_id=cm.state_id  order by 2 ").Tables(0)
            Me.cmb_dist.DataSource = dt1
            Me.cmb_dist.DataTextField = dt1.Columns(1).ColumnName
            Me.cmb_dist.DataValueField = dt1.Columns(0).ColumnName
            Me.cmb_dist.DataBind()
            dt5 = oh.ExecuteDataSet("select -1, '-Select Branch-' as branch_name  from dual union all select cm.branch_id, cm.branch_name as dtl   from branch_master cm where cm.firm_id=" & Session("firm_id") & " and cm.branch_id not in (0) union all select 0,'ADMINISTRATIVE OFFICE'  from dual order by 2 ").Tables(0)
            Me.cmb_branch.DataSource = dt5
            Me.cmb_branch.DataTextField = dt5.Columns(1).ColumnName
            Me.cmb_branch.DataValueField = dt5.Columns(0).ColumnName
            Me.cmb_branch.DataBind()
            dt6 = oh.ExecuteDataSet("select -1 emp_code, ' -Select Employee- ' as emp_name   from dual union all select cm.emp_code, cm.emp_code || '-' || cm.emp_name as dtl   from employee_master cm   join employ_firm f on f.emp_code=cm.emp_code and f.firm_id=" & Session("firm_id") & " where  cm.status_id = 1 and cm.shift_id not in (4, 5)  order by emp_code ").Tables(0)
            Me.cmb_emp.DataSource = dt6
            Me.cmb_emp.DataTextField = dt6.Columns(1).ColumnName
            Me.cmb_emp.DataValueField = dt6.Columns(0).ColumnName
            Me.cmb_emp.DataBind()

            loadCompensatory()

            Me.chk_state.Attributes.Add("onclick", "chkstatus()")
            Me.chk_emp.Attributes.Add("onclick", "chkstatus1()")
            Me.chk_dist.Attributes.Add("onclick", "chkstatus2()")
            Me.chk_branch.Attributes.Add("onclick", "chkstatus3()")
            Me.chk_assigncomp.Attributes.Add("onclick", "chk_add()")
            Me.chk_addcomp.Attributes.Add("onclick", "chk_add1()")
        End If
        'Else
        'Me.Server.Transfer("../../show_err.aspx")
        'End If

    End Sub
    Private Sub loadCompensatory()
        Dim str As String = "select t.comp_id,t.comp_name from hrm_comp_mst t where t.status=1 and t.firm_id=" & Session("firm_id") & "order by t.comp_id"
        dt = oh.ExecuteDataSet(str).Tables(0)
        Me.cmb_comp.DataSource = dt
        Me.cmb_comp.DataTextField = dt.Columns(1).ColumnName
        Me.cmb_comp.DataValueField = dt.Columns(0).ColumnName
        Me.cmb_comp.DataBind()
    End Sub
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim dept As Integer
        Dim Firm As Integer
        Dim firmid As Integer

        firmid = Session("firm_id")
        Dim usr = Me.Session("user_id").ToString.Split("!")
        dept = oh.ExecuteDataSet("select t.department_id from EMPLOYEE_MASTER t where t.emp_code=" & usr(0) & "").Tables(0).Rows(0)(0)

        Dim stat As Integer
        If Me.chk_state.Checked = True Then
            stat = 1
        End If
        If Me.chk_dist.Checked = True Then
            stat = 2
        End If
        If Me.chk_branch.Checked = True Then
            stat = 3
        End If
        If Me.chk_emp.Checked = True Then
            stat = 4
        End If
        Dim dt As DataTable = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)

        If (CStr(Me.Hidden2.Value) = "" Or CStr(Me.Hidden2.Value) = Nothing) And stat = 0 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Data not Selected.. Please select Items');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            ''me.

        End If
        Me.hid_load.Value = Me.Hidden2.Value & "*" & stat
        If CDate(Me.txt_dt.Text) < CDate(dt.Rows(0)(0)) Then

            If CStr(Me.Hidden2.Value) <> "" And CStr(Me.Hidden2.Value) <> Nothing Then
                Dim param(10) As OracleParameter

                param(0) = New OracleParameter("firm", OracleType.Number)
                param(0).Direction = ParameterDirection.Input
                param(0).Value = firmid

                param(1) = New OracleParameter("comdt", OracleType.DateTime)
                param(1).Direction = ParameterDirection.Input
                param(1).Value = CDate(Me.txt_dt.Text)

                param(2) = New OracleParameter("exdt", OracleType.DateTime)
                param(2).Direction = ParameterDirection.Input
                param(2).Value = CDate(Me.txt_exdt.Text)

                param(3) = New OracleParameter("comnm", OracleType.VarChar, 5000)
                param(3).Direction = ParameterDirection.Input
                param(3).Value = Me.cmb_comp.SelectedItem.Text

                param(4) = New OracleParameter("userid", OracleType.VarChar, 200)
                param(4).Direction = ParameterDirection.Input
                param(4).Value = usr(0)

                param(5) = New OracleParameter("data", OracleType.VarChar, 5000)
                param(5).Direction = ParameterDirection.Input
                param(5).Value = Me.Hidden2.Value

                param(6) = New OracleParameter("com_id", OracleType.Number)
                param(6).Direction = ParameterDirection.Input
                param(6).Value = CInt(Me.cmb_comp.SelectedValue)

                param(7) = New OracleParameter("status", OracleType.Number)
                param(7).Direction = ParameterDirection.Input
                param(7).Value = stat

                'Request 
                param(8) = New OracleParameter("maker_flag", OracleType.Number)
                param(8).Direction = ParameterDirection.Input
                param(8).Value = 1

                param(9) = New OracleParameter("err_stat", OracleType.Number)
                param(9).Direction = ParameterDirection.Output

                param(10) = New OracleParameter("err_msg", OracleType.VarChar, 100)
                param(10).Direction = ParameterDirection.Output
                If (dept = 748 Or Firm = 28) Then
                    oh.ExecuteNonQuery("hrm_comp_credit_new_school", param)
                Else
                    oh.ExecuteNonQuery("hrm_comp_credit_new_macom", param)
                End If




                If param(8).Value = 1 Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('Successfully Inserted');")
                    cl_script1.Append("         window.open('comp_new_add.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Else
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('Some Problems Occured.. Try again');")
                    'cl_script1.Append("         window.open('comp_new_add.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                End If
            End If
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Future Date Entry Is Not permitted');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub


        End If
        loadCompensatory()
    End Sub


    Protected Sub cmd_addc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_addc.Click
        If Me.Txt_compen.Text = "" Then

            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' Please Enter COMPENSATORY Name !');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
            Exit Sub
        Else
            Dim leave(3) As OracleParameter
            leave(0) = New OracleParameter("comnm", OracleType.VarChar, 5000)
            leave(0).Direction = ParameterDirection.Input
            leave(0).Value = Me.Txt_compen.Text

            leave(1) = New OracleParameter("flag", OracleType.Number)
            leave(1).Direction = ParameterDirection.Output

            leave(2) = New OracleParameter("msg", OracleType.VarChar, 100)
            leave(2).Direction = ParameterDirection.InputOutput

            leave(3) = New OracleParameter("firm", OracleType.Number)
            leave(3).Direction = ParameterDirection.Input
            leave(3).Value = CInt(Session("firm_id"))

            oh.ExecuteNonQuery("hrm_comp_add", leave)
            If leave(1).Value = 1 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert(' " & leave(2).Value & " ');")
                loadCompensatory()
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
            Else
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert(' " & leave(2).Value & " ');")
                cl_script0.Append("       window.open('comp_new_add.aspx','_self');")
                loadCompensatory()
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
            End If
        End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        If eventArgument = 1 Then
            loadCompensatory()
        End If
        CbResult = "OK"
    End Sub
    Sub Pages_Load()
        Server.Transfer("comp_new_add.aspx")
    End Sub

End Class
