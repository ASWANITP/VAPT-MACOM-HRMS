Imports System.Data
Imports System.Data.OracleClient
Partial Class compensatory_extension_Add_compensatory_78d2ea263586
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim oh As New helper.oracle.OracleHelper
    Dim UserAll(), res, sql, str As String
    Dim UserCode, stat As Integer
    Dim dr As DataRow
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "ASSIGN COMPENSATORY"
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim emno As Integer = oh.ExecuteDataSet("select count(d.emp_id)  from form_accessibility d  where d.emp_id=" & UserCode & " and d.form_id=750").Tables(0).Rows(0)(0)
        If emno = 0 Then
            str_tkn.Append("         alert('You are not authorized...!');")
            str_tkn.Append(" window.open('../Home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        Else
            'Dim script_val As String
            'script_val = "var header;" & "header='" & Me.drp_emp.ClientID & "';"
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
            Dim cs As String = "var cont_name;cont_name='" & Me.ListBox1.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
            Me.drp_emp.Attributes.Add("onclick", "chkstatus()")

            If Not IsPostBack = True Then
                dt1 = oh.ExecuteDataSet("select -1 emp_code, '------Employee Code--------' employ_name  from dual  union all  select t.emp_code, t.emp_code || '---' || t.emp_name  from employee_master t, employ_firm ef  where t.status_id = 1  and t.emp_code = ef.emp_code  and ef.firm_id = " & Session("firm_id") & " order by emp_code").Tables(0)
                Me.drp_emp.DataSource = dt1
                Me.drp_emp.DataTextField = dt1.Columns(1).ColumnName
                Me.drp_emp.DataValueField = dt1.Columns(0).ColumnName
                Me.drp_emp.DataBind()
            End If


        End If

    End Sub
    Protected Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button.Click
        'Dim z As Integer = Me.drp_emp.SelectedValue
        If Me.txt_calender.Text = "" Then

            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('Please Enter Expiry date') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub

        End If
        Dim p(5) As OracleParameter

        p(0) = New OracleParameter("comnm", OracleType.VarChar, 25)
        p(0).Value = Me.Cmp_name.Text
        p(1) = New OracleParameter("dte", OracleType.DateTime)
        p(1).Value = CDate(Me.txt_calender.Text)
        p(2) = New OracleParameter("emp", OracleType.Number, 7)
        p(2).Value = UserCode
        p(3) = New OracleParameter("expdte", OracleType.DateTime)
        p(3).Value = CDate(Me.txt_exp.Text)
        p(4) = New OracleParameter("states", OracleType.VarChar, 5000)
        p(4).Direction = ParameterDirection.Input
        p(4).Value = Me.Hidden2.Value
        p(5) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
        p(5).Direction = ParameterDirection.Output

        oh.ExecuteNonQuery("hrm_comp_assign", p)
        Dim script1 As New System.Text.StringBuilder
        script1.Append("   alert(' " & p(5).Value & "');")

        script1.Append("       window.open('Add_comp_id.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return cbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim Userd() As String = Session("user_id").ToString.Split("!")
        Dim UserIdd As Integer = Userd(0)
        Dim DataStr() As String
        DataStr = eventArgument.Split("#")
        Dim Instr() As String = DataStr(0).Split("%")
        Dim CODE As String = Instr(0)
        'dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time || '*' || r.remarks|| '*' || r.recommended_by|| ' - ' || ee.emp_name|| '*' || r.recommended_reason|| '*' ||p.post_name|| '*' ||r.am_recomm_reason|| '*' ||r.rm_recomm_reason from daily_attend d,time_tab b,employee_master e,employee_master ee,hrm_anytimepunching_reg r,post_mst p where d.emp_code = e.emp_code and r.not_punch is null and e.department_id not in (4, 178, 188,211) and e.post_id=p.post_id and r.branch_id=d.m_branch and d.m_shift = b.shift_id and d.m_branch = " & CODE & " and d.m_time > b.in_time and e.emp_code > 10000 and d.m_branch <> 0 and d.emp_code = r.requested_by and r.status_id = 2 and r.recommended_by=ee.emp_code and to_date(r.requested_dt)=to_date('" & ReqDt & "') and (to_date(d.curr_date) =to_date('" & ReqDt & "') ) order by d.emp_code").Tables(0)
        dt2 = oh.ExecuteDataSet("select -1 emp_code, '------Employee Code--------' employ_name  from dual  union all  select t.emp_code, t.emp_code || '---' || t.emp_name  from employee_master t, employ_firm ef  where t.status_id = 1  and t.emp_code = ef.emp_code  and ef.firm_id = " & Session("firm_id") & "").Tables(0)
        Dim dr As DataRow
        For Each dr In dt2.Rows
            str_tkn.Append(dr(0))
            str_tkn.Append("!")
        Next
        str_tkn.Append("@")
        str_tkn.Append("2")
        cbResult = str_tkn.ToString
    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Dim script1 As New System.Text.StringBuilder
        script1.Append("       window.open('../../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

    End Sub
End Class
