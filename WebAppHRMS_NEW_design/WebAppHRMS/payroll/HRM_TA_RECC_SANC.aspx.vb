Imports System.Data
Imports System.Data.OracleClient
Partial Class HRM_TA_RECC_SANC_6ceb55d63629
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim CbResult As String = Nothing
    Dim str, pass_data As String
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str_tkn As New System.Text.StringBuilder
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("firm_id") = 8 Then
            Server.Transfer("~/TA/ta_recom.aspx")
        End If
        '--JEWEL REQUEST--------10621-Krishnadas-Dec-2015
        'changed
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "EMPLOYEE TA AND ALLOWANCE UPDATION"
        Dim User(), Sql, deps, branc As String
        Dim dhead, bhead As Integer
        User = Session("user_id").ToString.Split("!")
        Dim script_val As String
        Dim branchid = Session("branch_id")
        Dim frm As Integer = Session("firm_id")
        If Not IsPostBack Then
            '-------------------STORY---------------------
            'Based on Sajeesh MAIL confirmation ON February-3-2016
            'if special employee then list all emp under his dept and all recc person in branch
            'else
            'If head office
            'if dept head then list all emps in his dept else if he has formid=1687 then he is CFO and list all
            'emps who has no dept heads and list all dept heads.
            'else check if HR dept[acccessid=33] then list all emps whose post is (empid[postid] in formid-1688)
            'else not authorised

            'if branch then if formid-1688 in form_accessibility is the post of branch recc authority
            'to him[post of all emp who is in this post[formid-1688]]--list all emps in his branch
            '' Else  not authorised
            '-------------------STORY---------------------

            If branchid = 0 Then
                Dim ssql As String
                ssql = "select count(*) from form_accessibility t where t.form_id=1691 and t.emp_id=" & User(0) & ""
                Dim spec_emp = oh.ExecuteDataSet(ssql).Tables(0).Rows(0)(0)
                If spec_emp = 1 Then
                    deps = oh.ExecuteDataSet("select nvl(substr(trim(listagg(t.dep_id || ',') within group( order by t.dep_id)),0,length(listagg(t.dep_id || ',') within group(order by t.dep_id))-1),'-1') from department_mst t where t.dep_head =" & User(0) & "").Tables(0).Rows(0)(0)
                    loaddata(deps, 4)
                Else
                    Sql = "select count(*) from form_accessibility t where t.form_id=1687 and t.emp_id=" & User(0) & ""
                    Dim cfo = oh.ExecuteDataSet(Sql).Tables(0).Rows(0)(0)
                    If cfo = 1 Then
                        loaddata(frm, 1)
                    Else
                        dhead = oh.ExecuteDataSet("select count(t.dep_id) from department_mst t where t.dep_head=" & User(0) & "").Tables(0).Rows(0)(0)
                        If dhead > 0 Then
                            deps = oh.ExecuteDataSet("select nvl(substr(trim(listagg(t.dep_id || ',') within group( order by t.dep_id)),0,length(listagg(t.dep_id || ',') within group(order by t.dep_id))-1),'-1') from department_mst t where t.dep_head =" & User(0) & "").Tables(0).Rows(0)(0)
                            loaddata(deps, 0)
                        Else
                            If Session("access_id") = 33 Then
                                loaddata(frm, 2)
                            Else
                                Dim cl_script0 As New System.Text.StringBuilder
                                cl_script0.Append("         alert('You Are Not Authorised to View This Page !');")
                                cl_script0.Append("window.open('../home.aspx','_self');")
                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)

                            End If
                        End If
                    End If
                End If
            Else
                    bhead = oh.ExecuteDataSet("select count(*)  from form_accessibility t   join employee_master m on m.post_id=t.emp_id and m.emp_code=" & User(0) & "  where m.status_id = 1    and m.branch_id <> 0  and t.form_id=1688 ").Tables(0).Rows(0)(0)
                    If bhead > 0 Then
                        branc = oh.ExecuteDataSet("select t.branch_id from employee_master t where t.status_id=1 and t.emp_code=" & User(0) & "").Tables(0).Rows(0)(0)
                        loaddata(branc, 3)
                    Else
                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert('You Are Not Authorised to View This Page !');")
                        cl_script0.Append("window.open('../home.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)

                    End If
            End If
        End If
        Me.hid_details.Value = ""
        script_val = "var loanno;" & "loanno='" & "" & Me.cmb_details.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        Me.cmb_details.Attributes.Add("onchange", "all_select()")
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim frm As Integer = Session("firm_id")
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Dim Datastr() As String
        Dim allid() As String
        Datastr = eventArgument.Split("#")
        allid = Datastr(0).Split("%")
        Select Case (Datastr(1))
            Case 1
                Dim Instr() As String = Datastr(0).Split("%")
                Dim CODE As String = Instr(0)
                Dim dt1 As DataTable = oh.ExecuteDataSet("select  t.emp_code||'!'||to_char(t.from_dt)||'!'||to_char(t.to_dt)||'!'||t.source||'!'||t.destination||'!'||s.description||'!'||t.distance||'!'||t.req_amount||'!'||k.description||'!'||x.description||'!'||t.request_id   from hrm_ta_request t  join employ_firm f on f.emp_code = t.emp_code and f.firm_id =" & frm & "  join employee_master e on e.emp_code = t.emp_code   join (select t.module_id,t.option_id,t.status_id,t.description from status_master t where t.module_id=118 and t.option_id=2)s   on t.mode_id=s.status_id   join (select t.module_id,t.option_id,t.status_id,t.description from status_master t where t.module_id=118 and t.option_id=3)k   on k.status_id=t.type_id   join (select t.module_id,t.option_id,t.status_id,t.description from status_master t where t.module_id=118 and t.option_id=1)x   on x.status_id=t.purpose_id  where t.status_id = 0  and t.emp_code=" & allid(0) & " ").Tables(0)
                Dim dr As DataRow
                For Each dr In dt1.Rows
                    str_tkn.Append(dr(0))
                    str_tkn.Append("@")
                Next
                CbResult = str_tkn.ToString
            Case 2
                oh.ExecuteNonQuery("update hrm_ta_request t set t.status_id=3,t.cancel_by=" & User(0) & ",t.cancel_dt=sysdate where t.request_id=" & allid(0) & "")
                Dim dt5 As DataTable = oh.ExecuteDataSet("select  emp_code from  hrm_ta_request where request_id =" & allid(0) & "").Tables(0)
                Dim CODE As String = dt5.Rows(0)(0)
                Dim dt1 As DataTable = oh.ExecuteDataSet("select  t.emp_code||'!'||to_char(t.from_dt)||'!'||to_char(t.to_dt)||'!'||t.source||'!'||t.destination||'!'||s.description||'!'||t.distance||'!'||t.req_amount||'!'||k.description||'!'||x.description||'!'||t.request_id|| '!' ||case when t.sanc_amount is null then t.req_amount else t.sanc_amount end   from hrm_ta_request t  join employ_firm f on f.emp_code = t.emp_code and f.firm_id =" & frm & "  join employee_master e on e.emp_code = t.emp_code   join (select t.module_id,t.option_id,t.status_id,t.description from status_master t where t.module_id=118 and t.option_id=2)s   on t.mode_id=s.status_id   join (select t.module_id,t.option_id,t.status_id,t.description from status_master t where t.module_id=118 and t.option_id=3)k   on k.status_id=t.type_id   join (select t.module_id,t.option_id,t.status_id,t.description from status_master t where t.module_id=118 and t.option_id=1)x   on x.status_id=t.type_id  where t.status_id =0  and t.emp_code=" & CODE & " ").Tables(0)
                Dim dr As DataRow
                For Each dr In dt1.Rows
                    str_tkn.Append(dr(0))
                    str_tkn.Append("@")
                Next
                CbResult = str_tkn.ToString
        End Select
    End Sub
    Private Sub loaddata(ByVal depart, ByVal choice)
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Dim frm As Integer = Session("firm_id")

        If choice = 1 Then '--Dept heads and those who has no dept heads
            dt1 = oh.ExecuteDataSet("select 0 ,'-------Select----------' from dual union all select t.emp_code,t.emp_code||'--'||e.emp_name  from hrm_ta_request t join employ_firm f on f.emp_code=t.emp_code and f.firm_id=" & frm & " join employee_master e on e.emp_code=t.emp_code  join department_mst m on m.dep_head=t.emp_code where t.status_id=0 group by t.emp_code,e.emp_name  union all select t.emp_code, t.emp_code || '--' || e.emp_name  from hrm_ta_request t  join employ_firm f on f.emp_code = t.emp_code  and f.firm_id = " & frm & "  join employee_master e on e.emp_code = t.emp_code and e.department_id in (select d.dep_id from department_mst d where d.dep_head is null)  group by t.emp_code, e.emp_name order by 1 ").Tables(0)

        ElseIf choice = 3 Then 'list employees who are reccmending branch employees                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     who has the authority to recc from branch
            dt1 = oh.ExecuteDataSet("select 0 ,'-------Select----------' from dual union all select t.emp_code,t.emp_code||'--'||e.emp_name  from hrm_ta_request t join employ_firm f on f.emp_code=t.emp_code and f.firm_id=" & frm & " join employee_master e on e.emp_code=t.emp_code where t.status_id=0 and e.branch_id=" & depart & " and t.emp_code not in (" & User(0) & ") group by t.emp_code,e.emp_name order by 1 ").Tables(0)

        ElseIf choice = 0 Then '--list all employees in purticular depts where user is that deptartments head
            dt1 = oh.ExecuteDataSet("select 0 ,'-------Select----------' from dual union all select t.emp_code,t.emp_code||'--'||e.emp_name  from hrm_ta_request t join employ_firm f on f.emp_code=t.emp_code and f.firm_id=" & frm & " join employee_master e on e.emp_code=t.emp_code where t.status_id=0 and e.department_id in (" & depart & ")and e.branch_id=0 group by t.emp_code,e.emp_name order by 1 ").Tables(0)

        ElseIf choice = 2 Then '-- list all emps whose post is [form_accsblty-1688] and he is authorised to recomend all branch staafs TA request
            dt1 = oh.ExecuteDataSet("select 0 ,'-------Select----------' from dual union all select t.emp_code,t.emp_code||'--'||e.emp_name  from hrm_ta_request t join employ_firm f on f.emp_code=t.emp_code and f.firm_id=" & frm & " join employee_master e on e.emp_code=t.emp_code where t.status_id=0 and e.post_id in (select fo.emp_id from form_accessibility fo where fo.form_id=1688) group by t.emp_code,e.emp_name order by 1 ").Tables(0)

        ElseIf choice = 4 Then '--special employees like 22345[shihabudhin] who wants to see all emp in his dept and all emps who are reccmending persons from branch 
            dt1 = oh.ExecuteDataSet("select 0, '-------Select----------'  from dual union all select t.emp_code, t.emp_code || '--' || e.emp_name   from hrm_ta_request t   join employ_firm f on f.emp_code = t.emp_code and f.firm_id =" & frm & " join employee_master e on e.emp_code = t.emp_code  where t.status_id = 0    and e.post_id in (select fo.emp_id   from form_accessibility fo   where fo.form_id = 1688) group by t.emp_code,  e.emp_name    union all  select t.emp_code, t.emp_code || '--' || e.emp_name from hrm_ta_request t join employ_firm f on f.emp_code = t.emp_code and f.firm_id =" & frm & " join employee_master e on e.emp_code = t.emp_code where t.status_id = 0   and e.department_id in (" & depart & ") and e.branch_id = 0  group by t.emp_code, e.emp_name  order by 1 ").Tables(0)
        End If
        Me.cmb_details.DataSource = dt1
        Me.cmb_details.DataValueField = dt1.Columns(0).ColumnName
        Me.cmb_details.DataTextField = dt1.Columns(1).ColumnName
        Me.cmb_details.DataBind()
    End Sub

    Protected Sub Button2_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.ServerClick
        Response.Redirect("../home.aspx")
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim str, data() As String
        str = Me.hdnDisplay.Value
        If str = String.Empty Or str = "" Or str = Nothing Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('No Items to Confirm..');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        Else
            data = Me.hdnDisplay.Value.Split("@")
            Dim frm As Integer = Session("firm_id")
            Dim branchid = Session("branch_id")
            Try
                Dim op(4) As OracleParameter
                op(0) = New OracleParameter("details", OracleType.VarChar, 10000)
                op(0).Value = str
                op(1) = New OracleParameter("status", OracleType.Number)
                op(1).Value = 4
                op(2) = New OracleParameter("user_by", OracleType.VarChar, 50)
                op(2).Value = Session("user_id")
                op(3) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                op(3).Direction = ParameterDirection.Output
                op(4) = New OracleParameter("Errflag", OracleType.Number, 1)
                op(4).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("hrm_ta_request_apply", op)
                If op(4).Value = 1 Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('" + op(3).Value + "');")
                    cl_script1.Append("window.open('../home.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Else
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('" + op(3).Value + "');")
                    cl_script1.Append("window.open('../home.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                End If


            Catch ex As Exception
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('Error Occured..');")
                cl_script1.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End Try
        End If
    End Sub
End Class
