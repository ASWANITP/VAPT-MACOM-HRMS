Imports System.Data
Imports System.Data.OracleClient

Partial Class leave_early_going_sanction_87bf77ed9385
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim str As String
    Dim dt As New DataTable
    ' Dim oh As New OracleHelper
    Dim oh As New helper.oracle.OracleHelper
    Dim usr() As String
    Dim st, firm As Integer
    Dim post As Integer
    Dim depid As Integer
    '    Dim maill As bilu_send_mail.bilu_send_mail
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' CType(Me.Master, WebAppHRMS.edp).Subtitle = "EARLY GOING CANCEL"
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.cmb_emp.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
        Me.cmb_emp.Attributes.Add("onchange", "early_goingOnchange()")

        usr = Me.Session("user_id").ToString.Split("!")
        firm = Me.Session("firm_id")
        'usr = "10001!".Split("!")
        Me.hid_user.Value = usr(0)
        If Me.Session("firm_id") = 24 Then
            Me.cmd_rec.Visible = False
        End If
        Dim cmb_emp As New DataTable
        If Not IsPostBack Then
            Dim dt44 As DataTable = oh.ExecuteDataSet("select emp_code from employee_master where post_id =85 and department_id=70 and emp_code=" & usr(0) & "").Tables(0)

            If dt44.Rows.Count > 0 Then
                Dim sql1y As String = "select t.department_id from department_major t where t.head_id like '%" & usr(0) & "%'"
                dt = oh.ExecuteDataSet(sql1y).Tables(0)

                Dim sql1 As String
                Me.Label1.Text = "COMPENSATORY SANCTION"
                Me.cmd_rec.Visible = False
                Me.emp_type.Value = 1
                If dt.Rows.Count > 0 Then
                    sql1 = "select '-1', 'Employee Code  - Leave Date- Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t,employ_firm ef   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and t.emp_code=ef.emp_code   and ef.firm_id=" & firm & " and ca.status_id in (0,4) and (t.emp_code in (select distinct dep_head   from department_mst  where dep_head is not null) or t.emp_code in (select emp_code from employee_master where post_id in (173))) union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t,employ_firm ef   where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and t.emp_code=ef.emp_code   and ef.firm_id=" & firm & " and ca.status_id in (4,0) and (ca.recom_person in (select m.emp_code from department_major t,employee_master m where t.head_id like '%'||m.emp_code||'%' and emp_code >9999) or ca.recom_person in (select emp_code from employee_master where post_id in (173))) union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp,employ_firm ef  where t.department_id=dp.dep_id and dp.major_dep_id=" & dt.Rows(0)(0) & " and t.emp_code=ca.emp_code and t.emp_code=ef.emp_code   and ef.firm_id=" & firm & " and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and ca.comp_id=cm.comp_id and ca.status_id in (4,0) and t.branch_id=0 union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp,employ_firm ef  where t.department_id=dp.dep_id  and t.emp_code = ef.emp_code   and ef.firm_id = " & firm & " and dp.major_dep_id=" & dt.Rows(0)(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and t.emp_code=ca.emp_code and t.emp_code<>" & usr(0) & " and t.branch_id<>0 and t.department_id in (23,37,4,5,38,183,188,179,180,23) and ca.comp_id=cm.comp_id and ca.status_id in (4,0) union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp,employ_firm ef  where t.emp_code=ca.emp_code and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and ca.comp_id=cm.comp_id and t.emp_code=ef.emp_code   and ef.firm_id=" & firm & " and ca.status_id in (0) and t.branch_id=0 and t.emp_code in (select r.dep_head from department_mst r where  r.major_dep_id=" & dt.Rows(0)(0) & " ) union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t,employ_firm ef   where t.emp_code = ca.emp_code and t.emp_code=ef.emp_code   and ef.firm_id=" & firm & " and t.emp_code <> 21820 and ca.comp_id = cm.comp_id and ca.status_id in (4,0) and (ca.emp_code in (select m.emp_code from department_major t,employee_master m where t.head_id like '%'||m.emp_code||'%' and emp_code >9999) or ca.emp_code in (select emp_code from employee_master where post_id in (173))) "
                Else
                    'sql1 = "select '-1', 'Employee Code  - Leave Date- Compensation Name' as emp_name  from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (0,4) and (t.emp_code in (select distinct dep_head   from department_mst  where dep_head is not null) or t.emp_code in (select emp_code from employee_master where post_id in (173))) union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t   where t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and ca.comp_id = cm.comp_id and ca.status_id in (4,0) and (ca.recom_person in (select m.emp_code from department_major t,employee_master m where t.head_id like '%'||m.emp_code||'%' and emp_code >9999) or ca.recom_person in (select emp_code from employee_master where post_id in (173))) "
                    sql1 = "select '-1', 'Employee Code  - Leave Date- Compensation Name' as emp_name  from dual  union  select ca.emp_code || '*' || ca.comp_id,  ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||  cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t, employ_firm ef  where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & "  and ca.comp_id = cm.comp_id  and ca.status_id in (0, 4)  and t.emp_code = ef.emp_code  and ef.firm_id = " & firm & "  and (t.emp_code in (select distinct dep_head  from department_mst  where dep_head is not null) or  t.emp_code in  (select emp_code from employee_master where post_id in (173)))  union  select ca.emp_code || '*' || ca.comp_id,  ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||  cm.comp_name  from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t, employ_firm ef  where t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & "  and ca.comp_id = cm.comp_id  and t.emp_code = ef.emp_code  and ef.firm_id = " & firm & "  and ca.status_id in (4, 0)  and (ca.recom_person in (select m.emp_code  from department_major t, employee_master m  where t.head_id like '%' || m.emp_code || '%'  and emp_code > 9999) or  ca.recom_person in  (select emp_code from employee_master where post_id in (173)))"
                End If


                dt = oh.ExecuteDataSet(sql1).Tables(0)
                If dt.Rows.Count > 1 Then
                    Me.cmb_emp.DataSource = dt
                    Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                    Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                    Me.cmb_emp.DataBind()
                Else
                    Me.cmd_rej.Visible = False
                    Dim cl_script As New StringBuilder
                    cl_script.Append("   alert('THERE IS NO COMPENSATORY OFF TO SANCTION/RECOMMEND') ;")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                End If

            Else

                Me.emp_type.Value = 1
                Dim Sql2 = "select t.emp_id from form_accessibility t where t.form_id=65 and t.emp_id=" & usr(0) & ""
                dt = oh.ExecuteDataSet(Sql2).Tables(0)
                If dt.Rows.Count > 0 Then
                    Me.hid_access.Value = 1
                    Me.Label1.Text = "COMPENSATORY SANCTION"
                    Sql2 = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select t.emp_code||'*'||t.comp_id,t.emp_code || '*' || t.emp_name ||'*'||t.leave_dt||'*'||cm.comp_name from hrm_comp_appl t,hrm_comp_mst cm where t.comp_id=cm.comp_id and t.status_id=4 union all  select t.emp_code ||'*'||t.comp_id,t.emp_code || '*' || t.emp_name ||'*'||t.leave_dt||'*'||cm.comp_name from hrm_comp_appl t,hrm_comp_mst cm,department_mst d,zonal_master z where t.comp_id=cm.comp_id and t.status_id=0 and z.head_id=t.emp_code and d.dep_head=t.emp_code"
                    dt = oh.ExecuteDataSet(Sql2).Tables(0)
                    If dt.Rows.Count > 1 Then
                        Me.cmb_emp.DataSource = dt
                        Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                        Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                        Me.cmb_emp.DataBind()
                    Else
                        Dim cl_script As New StringBuilder
                        cl_script.Append("   alert('THERE IS NO  COMPENSATORY OFF TO SANCTION') ;")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                    End If
                Else
                    Me.emp_type.Value = 2
                    Me.hid_access.Value = 2
                    Me.Label1.Text = "COMPENSATORY RECOMMENDATION/SANCTION"
                    If Session("branch_id") <> 0 Then
                        Dim Sql As String = "select count(*) from employee_master t  where t.emp_code=" & usr(0) & " and t.post_id in (10,11,12,13,14,15,16,17,18,101,198)"
                        cmb_emp = oh.ExecuteDataSet(Sql).Tables(0)
                        If cmb_emp.Rows(0)(0) > 0 Then
                            Dim sql1 As String = "select branch_id from employee_master where emp_code=" & usr(0) & ""
                            dt = oh.ExecuteDataSet(sql1).Tables(0)
                            If dt.Rows.Count > 0 Then
                                'sql1 = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t where t.emp_code=ca.emp_code and t.branch_id=" & dt.Rows(0)(0) & " and t.emp_code<>" & usr(0) & " and ca.comp_id=cm.comp_id and ca.status_id=0 and t.department_id not in (4,20,178,188,23,180,183)  and t.post_id not in(10,198,173,195,28,199,136,197,210,208,204,202)"
                                sql1 = "select 0 as srnumber,'Please Select ' from dual"
                                dt = oh.ExecuteDataSet(sql1).Tables(0)
                                If dt.Rows.Count > 1 Then
                                    Me.cmb_emp.DataSource = dt
                                    Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                                    Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                                    Me.cmb_emp.DataBind()
                                Else
                                    Dim cl_script As New StringBuilder
                                    cl_script.Append("   alert('THERE IS NO COMPENSATORY OFF TO SANCTION/RECOMMEND') ;")
                                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                                End If
                            End If
                        Else
                            Sql = "select count(*) from employee_master t  where t.emp_code=" & usr(0) & " and t.status_id=1 and t.post_id in(131,134,136,141,197)"
                            cmb_emp = oh.ExecuteDataSet(Sql).Tables(0)
                            If cmb_emp.Rows(0)(0) > 0 Then
                                'Dim sql1 As String = "select am.area_id from area_master am where am.area_head_id=" & usr(0) & ""
                                'dt = oh.ExecuteDataSet(sql1).Tables(0)
                                'If dt.Rows.Count > 0 Then
                                Dim sql1 As String
                                'sql1 = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,area_detail ad where t.emp_code=ca.emp_code and ad.area_id in (select am.area_id from branch_dtl_new am,employee_master e  where e.emp_code=" & usr(0) & " and e.branch_id=am.branch_id) and t.post_id in(10,11,12,13,14,15,16,17,18,101,198) and t.department_id not in (4,178,188,23,180,183) and t.branch_id=ad.branch_id and t.emp_code<>" & usr(0) & " and ca.comp_id=cm.comp_id and ca.status_id=0 union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,area_detail ad where t.emp_code=ca.emp_code and ad.area_id in (select am.area_id from branch_dtl_new am,employee_master e  where e.emp_code=" & usr(0) & " and e.branch_id=am.branch_id) and t.department_id not in (4,178,188,23,180,183) and ((t.post_id not in (10, 198, 173, 195, 28, 199, 136, 197, 210, 208, 204, 202)  and ca.status_id = 4) or(t.department_id =20 and ca.status_id = 0) ) and t.branch_id=ad.branch_id and t.emp_code<>" & usr(0) & " and ca.comp_id=cm.comp_id  and ca.recom_person<>" & usr(0) & ""
                                sql1 = "select 0 as srnumber,'Please Select ' from dual"
                                dt = oh.ExecuteDataSet(sql1).Tables(0)
                                If dt.Rows.Count > 1 Then
                                    Me.cmb_emp.DataSource = dt
                                    Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                                    Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                                    Me.cmb_emp.DataBind()
                                Else
                                    Dim cl_script As New StringBuilder
                                    cl_script.Append("   alert('THERE IS NO COMPENSATORY OFF TO SANCTION/RECOMMEND') ;")
                                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                                End If
                                'End If
                            Else
                                Sql = "select count(*) from employee_master t  where t.emp_code=" & usr(0) & " and t.post_id in(123,104,127,157,126,137,142,163,164,140)"
                                cmb_emp = oh.ExecuteDataSet(Sql).Tables(0)
                                If cmb_emp.Rows(0)(0) > 0 Then
                                    Dim sql1 As String = "select dm.division_id from division_master dm where dm.div_head_id=" & usr(0) & ""
                                    dt = oh.ExecuteDataSet(sql1).Tables(0)
                                    If dt.Rows.Count > 0 Then
                                        sql1 = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code||'*'||ca.comp_id,ca.emp_code|| '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,area_detail ad,division_detail dd where t.emp_code=ca.emp_code and t.branch_id=ad.branch_id and ad.area_id=dd.area_id and dd.div_id=" & dt.Rows(0)(0) & " and t.post_id in(131,134,136,141) and t.emp_code<>" & usr(0) & " and ca.comp_id=cm.comp_id and ca.status_id=0"
                                        dt = oh.ExecuteDataSet(sql1).Tables(0)
                                        If dt.Rows.Count > 1 Then
                                            Me.cmb_emp.DataSource = dt
                                            Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                                            Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                                            Me.cmb_emp.DataBind()
                                        Else
                                            Dim cl_script As New StringBuilder
                                            cl_script.Append("   alert('THERE IS NO COMPENSATORY OFF TO SANCTION/RECOMMEND') ;")
                                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                                        End If
                                    End If
                                Else
                                    Sql = "select count(*) from employee_master t  where t.emp_code=" & usr(0) & " and t.status_id=1 and t.post_id in(28,29,30,31,32,33,34,35,36,112,128,169,170,178,199,200)"
                                    cmb_emp = oh.ExecuteDataSet(Sql).Tables(0)
                                    If cmb_emp.Rows(0)(0) > 0 Then
                                        Dim sql12 As String = "select t.department_id from employee_master t where t.emp_code=" & usr(0) & ""
                                        dt = oh.ExecuteDataSet(sql12).Tables(0)
                                        If dt.Rows(0)(0) = 4 Or dt.Rows(0)(0) = 178 Or dt.Rows(0)(0) = 188 Then
                                            Dim sql1 As String = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code||'*'||ca.comp_id,ca.emp_code|| '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,area_detail ad,division_detail dd,region_detail rd where t.emp_code=ca.emp_code and t.branch_id=ad.branch_id and ad.area_id=dd.area_id and dd.div_id=rd.division_id and rd.region_id in (select am.reg_id from branch_dtl_new am,employee_master e  where e.emp_code=" & usr(0) & " and e.branch_id=am.branch_id) and t.emp_code<>" & usr(0) & " and ca.comp_id=cm.comp_id and ca.status_id=0 and ca.recom_person<>" & usr(0) & " and t.department_id in (4,178,188) union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,area_detail ad,division_detail dd,region_detail rd where t.emp_code=ca.emp_code and t.branch_id=ad.branch_id and ad.area_id=dd.area_id and dd.div_id=rd.division_id and rd.region_id in (select am.reg_id from branch_dtl_new am,employee_master e  where e.emp_code=" & usr(0) & " and e.branch_id=am.branch_id) and t.department_id not in (4,178,188) and t.post_id in (10,11,12,13,14,15,16,17,18,198,197,199,200,101,131,134,136,141,123,104,127,157,126,137,142,163,164,140,28,29,30,31,32,33,34,35,36,112,128,169,170,178,173,210,202) and t.emp_code<>" & usr(0) & " and ca.comp_id=cm.comp_id and ca.status_id=4 and ca.recom_person<>" & usr(0) & " "
                                            dt = oh.ExecuteDataSet(sql1).Tables(0)
                                        Else
                                            Dim sql1 As String = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code||'*'||ca.comp_id,ca.emp_code|| '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,area_detail ad,division_detail dd,region_detail rd where t.emp_code=ca.emp_code and t.branch_id=ad.branch_id and ad.area_id=dd.area_id and dd.div_id=rd.division_id and rd.region_id in (select am.reg_id from branch_dtl_new am,employee_master e  where e.emp_code=" & usr(0) & " and e.branch_id=am.branch_id) and ((t.post_id in(131,134,136,141,197,202,210) and t.department_id not in (4,178,188) and ca.status_id=0) or (t.department_id =20 and t.branch_id<>0 and ca.status_id=4)) and t.emp_code<>" & usr(0) & " and ca.comp_id=cm.comp_id  union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,area_detail ad,division_detail dd,region_detail rd where t.emp_code=ca.emp_code and t.branch_id=ad.branch_id and ad.area_id=dd.area_id and dd.div_id=rd.division_id and rd.region_id in (select am.reg_id from branch_dtl_new am,employee_master e  where e.emp_code=" & usr(0) & " and e.branch_id=am.branch_id) and t.department_id not in (4,178,188) and t.post_id in (10,11,12,13,14,15,16,17,18,101,198) and t.emp_code<>" & usr(0) & " and ca.comp_id=cm.comp_id and ca.status_id=4 and ca.recom_person<>" & usr(0) & " union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,area_detail ad,division_detail dd,region_detail rd where t.emp_code=ca.emp_code and t.branch_id=ad.branch_id and ad.area_id=dd.area_id and dd.div_id=rd.division_id and rd.region_id in (select am.reg_id from branch_dtl_new am,employee_master e  where e.emp_code=" & usr(0) & " and e.branch_id=am.branch_id) and t.department_id not in (4,178,188) and t.post_id in (10,11,12,13,14,15,16,17,18,198,197,199,200,101,131,134,136,141,123,127,157,126,137,142,163,164,140,28,29,30,31,32,33,34,35,36,112,128,169,170,178,173,210,202) and t.emp_code<>" & usr(0) & " and ca.comp_id=cm.comp_id and ca.status_id=4 and ca.recom_person<>" & usr(0) & " "
                                            dt = oh.ExecuteDataSet(sql1).Tables(0)
                                        End If


                                        If dt.Rows.Count > 1 Then
                                            Me.cmb_emp.DataSource = dt
                                            Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                                            Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                                            Me.cmb_emp.DataBind()
                                        Else
                                            Dim cl_script As New StringBuilder
                                            cl_script.Append("   alert('THERE IS NO COMPENSATORY OFF TO SANCTION/RECOMMEND') ;")
                                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                                        End If
                                        '  End If

                                    Else

                                        If Session("branch_id") <> 0 Then

                                            Sql = "select count(*) from employee_master t  where t.emp_code=" & usr(0) & " and t.post_id in(195)"
                                            cmb_emp = oh.ExecuteDataSet(Sql).Tables(0)
                                            If cmb_emp.Rows(0)(0) > 0 Then
                                                Dim sql1 As String = "select t.zonal_id from zonal_master t where t.hr_head=" & usr(0) & ""
                                                dt = oh.ExecuteDataSet(sql1).Tables(0)
                                                If dt.Rows.Count > 0 Then

                                                    Dim dtw As DataTable = oh.ExecuteDataSet("select count(*) from department_mst t where t.dep_head=" & usr(0) & "").Tables(0)
                                                    If dtw.Rows(0)(0) > 0 Then
                                                        Dim sql115 As String = "select t.dep_id from department_mst t where t.dep_head =" & usr(0) & ""
                                                        Dim dte As DataTable = oh.ExecuteDataSet(sql115).Tables(0)
                                                        Dim dr As DataRow
                                                        Dim dep As String = " "
                                                        For Each dr In dte.Rows
                                                            If dep = " " Then
                                                                dep = dr(0)
                                                            Else
                                                                dep = dep.ToString + "," + dr(0).ToString
                                                            End If

                                                        Next
                                                        sql1 = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,area_detail ad,division_detail dd,region_detail rd,zonal_detail zd where t.emp_code=ca.emp_code and t.branch_id=ad.branch_id and ad.area_id=dd.area_id and dd.div_id=rd.division_id and rd.region_id=zd.region_id and zd.zonal_id in (select t.zonal_id from zonal_master t where t.hr_head=" & usr(0) & ") and t.post_id in(28,29,30,31,32,33,34,35,36,112,128,169,170,178,131,134,136,210,202,141,197,199,200) and t.emp_code<>" & usr(0) & " and ca.comp_id=cm.comp_id and ca.status_id=0 and t.department_id not in (4,178,188,23,180,183) union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,area_detail ad,division_detail dd,region_detail rd,zonal_detail zd where t.emp_code=ca.emp_code and t.branch_id=ad.branch_id and ad.area_id=dd.area_id and dd.div_id=rd.division_id and rd.region_id=zd.region_id and zd.zonal_id in (select t.zonal_id from zonal_master t where t.hr_head=" & usr(0) & ") and t.post_id in(10,11,12,13,14,15,16,17,18,101,198) and t.emp_code<>" & usr(0) & " and ca.comp_id=cm.comp_id and ca.status_id=4 and ca.recom_person<>" & usr(0) & " and t.department_id not in (4,178,188,23,180,183) union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.department_id=dp.dep_id  and dp.dep_id in (" & dep & ") and t.emp_code=ca.emp_code  and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and ca.comp_id=cm.comp_id and ca.status_id in (0) and t.branch_id=0 and t.department_id not in (4,178,188,23,180,183)  union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.department_id=dp.dep_id and dp.dep_id in (" & dep & ") and t.emp_code=ca.emp_code and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and t.branch_id<>0 and t.department_id in (23,37,4,5,38,183,188,179,180,23) and t.department_id not in (4,178,188,23,180,183)  and ca.comp_id=cm.comp_id and ca.status_id in (0)"
                                                    Else

                                                        sql1 = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,area_detail ad,division_detail dd,region_detail rd,zonal_detail zd where t.emp_code=ca.emp_code and t.branch_id=ad.branch_id and ad.area_id=dd.area_id and dd.div_id=rd.division_id and rd.region_id=zd.region_id and zd.zonal_id in (select t.zonal_id from zonal_master t where t.hr_head=" & usr(0) & ") and t.post_id in(28,29,30,31,32,33,34,35,36,112,128,169,170,178,131,134,136,141,197,199,210,202,200) and t.department_id not in (4,178,188,23,180,183)  and t.emp_code<>" & usr(0) & " and ca.comp_id=cm.comp_id and ca.status_id=0  union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,area_detail ad,division_detail dd,region_detail rd,zonal_detail zd where t.emp_code=ca.emp_code and t.branch_id=ad.branch_id and ad.area_id=dd.area_id and dd.div_id=rd.division_id and rd.region_id=zd.region_id and zd.zonal_id in (select t.zonal_id from zonal_master t where t.hr_head=" & usr(0) & ") and t.post_id in(10,11,12,13,14,15,16,17,18,101,198) and t.department_id not in (4,178,188,23,180,183)  and t.emp_code<>" & usr(0) & " and ca.comp_id=cm.comp_id and ca.status_id=4 and ca.recom_person<>" & usr(0) & ""
                                                    End If

                                                    dt = oh.ExecuteDataSet(sql1).Tables(0)
                                                    If dt.Rows.Count > 1 Then
                                                        Me.cmb_emp.DataSource = dt
                                                        Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                                                        Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                                                        Me.cmb_emp.DataBind()
                                                    Else
                                                        Dim cl_script As New StringBuilder
                                                        cl_script.Append("   alert('THERE IS NO COMPENSATORY OFF TO SANCTION/RECOMMEND') ;")
                                                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                                                    End If
                                                End If
                                            Else
                                                Sql = "select count(*) from department_major t where t.head_id like '%" & usr(0) & "%'"
                                                cmb_emp = oh.ExecuteDataSet(Sql).Tables(0)
                                                If cmb_emp.Rows(0)(0) > 0 Then
                                                    Dim sql1 As String = "select t.department_id from department_major t where t.head_id like '%" & usr(0) & "%'"
                                                    dt = oh.ExecuteDataSet(sql1).Tables(0)
                                                    If dt.Rows.Count > 0 Then
                                                        Dim dtw As DataTable = oh.ExecuteDataSet("select count(*) from department_mst t where t.dep_head=" & usr(0) & "").Tables(0)
                                                        If dtw.Rows(0)(0) > 0 Then
                                                            Dim sql115 As String = "select t.dep_id from department_mst t where t.dep_head =" & usr(0) & ""
                                                            Dim dte As DataTable = oh.ExecuteDataSet(sql115).Tables(0)
                                                            Dim dr As DataRow
                                                            Dim dep As String = " "
                                                            For Each dr In dte.Rows
                                                                If dep = " " Then
                                                                    dep = dr(0)
                                                                Else
                                                                    dep = dep.ToString + "," + dr(0).ToString
                                                                End If

                                                            Next
                                                            sql1 = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.department_id=dp.dep_id and dp.major_dep_id=" & dt.Rows(0)(0) & " and t.emp_code=ca.emp_code and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and ca.comp_id=cm.comp_id and ca.status_id in (4) and t.branch_id=0 union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.department_id=dp.dep_id and dp.major_dep_id=" & dt.Rows(0)(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and t.emp_code=ca.emp_code and t.emp_code<>" & usr(0) & " and t.branch_id<>0 and t.department_id in (23,37,4,5,38,183,188,179,180,23) and ca.comp_id=cm.comp_id and ca.status_id in (4) union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.emp_code=ca.emp_code and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and ca.comp_id=cm.comp_id and ca.status_id in (0) and t.branch_id=0 and t.emp_code in (select r.dep_head from department_mst r where  r.major_dep_id=" & dt.Rows(0)(0) & " ) union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.department_id=dp.dep_id  and dp.dep_id in (" & dep & ") and t.emp_code=ca.emp_code  and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and ca.comp_id=cm.comp_id and ca.status_id in (0) and t.branch_id=0 and t.department_id not in (4,178,188,23,180,183)   union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.department_id=dp.dep_id and dp.dep_id in (" & dep & ") and t.emp_code=ca.emp_code and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and t.branch_id<>0 and t.department_id not in (4,178,188,23,180,183)  and ca.comp_id=cm.comp_id and ca.status_id in (0)"
                                                        Else
                                                            sql1 = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.department_id=dp.dep_id and dp.major_dep_id=" & dt.Rows(0)(0) & " and t.emp_code=ca.emp_code and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and ca.comp_id=cm.comp_id and ca.status_id in (4) and t.branch_id=0 union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.department_id=dp.dep_id and dp.major_dep_id=" & dt.Rows(0)(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and t.emp_code=ca.emp_code and t.emp_code<>" & usr(0) & " and t.branch_id<>0 and t.department_id in (23,37,4,5,38,183,188,179,180,23) and ca.comp_id=cm.comp_id and ca.status_id in (4) union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.emp_code=ca.emp_code and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and ca.comp_id=cm.comp_id and ca.status_id in (0) and t.branch_id=0 and t.emp_code in (select r.dep_head from department_mst r where  r.major_dep_id=" & dt.Rows(0)(0) & " )"
                                                        End If
                                                        dt = oh.ExecuteDataSet(sql1).Tables(0)
                                                        If dt.Rows.Count > 1 Then
                                                            Me.cmb_emp.DataSource = dt
                                                            Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                                                            Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                                                            Me.cmb_emp.DataBind()
                                                        Else
                                                            Dim cl_script As New StringBuilder
                                                            cl_script.Append("   alert('THERE IS NO COMPENSATORY OFF TO SANCTION/RECOMMEND') ;")
                                                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                                                        End If
                                                    Else
                                                        Sql = "select count(*) from department_mst t where t.dep_head=" & usr(0) & ""
                                                        cmb_emp = oh.ExecuteDataSet(Sql).Tables(0)
                                                        If cmb_emp.Rows(0)(0) > 0 Then
                                                            Dim sql11 As String = "select t.dep_id from department_mst t where t.dep_head =" & usr(0) & ""
                                                            dt = oh.ExecuteDataSet(sql11).Tables(0)
                                                            Dim dr As DataRow
                                                            Dim dep As String = " "
                                                            For Each dr In dt.Rows
                                                                If dep = " " Then
                                                                    dep = dr(0)
                                                                Else
                                                                    dep = dep.ToString + "," + dr(0).ToString
                                                                End If

                                                            Next
                                                            If dt.Rows.Count > 0 Then
                                                                sql11 = "select '-1','Employee Code  -Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.department_id=dp.dep_id  and dp.dep_id in (" & dep & ") and t.emp_code=ca.emp_code  and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and ca.comp_id=cm.comp_id and ca.status_id in (0) and t.branch_id=0 and t.department_id not in (4,178,188,23,180,183)   union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.department_id=dp.dep_id and dp.dep_id in (" & dep & ") and t.emp_code=ca.emp_code and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and t.branch_id<>0 and t.department_id in (23,37,4,5,38,183,188,179,180,23) and ca.comp_id=cm.comp_id and ca.status_id in (0) and t.department_id not in (4,178,188,23,180,183) "
                                                                dt = oh.ExecuteDataSet(sql11).Tables(0)
                                                                If dt.Rows.Count > 1 Then
                                                                    Me.cmb_emp.DataSource = dt
                                                                    Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                                                                    Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                                                                    Me.cmb_emp.DataBind()
                                                                Else
                                                                    Dim cl_script As New StringBuilder
                                                                    cl_script.Append("   alert('THERE IS NO COMPENSATORY OFF TO SANCTION/RECOMMEND') ;")
                                                                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                                                                End If
                                                            End If
                                                        Else
                                                            Server.Transfer("../../show_err.aspx")
                                                        End If

                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If

                    If Session("branch_id") = 0 Then
                        Dim Sql As String = "select count(*) from employee_master t  where t.emp_code=" & usr(0) & " and t.post_id in(195)"
                        cmb_emp = oh.ExecuteDataSet(Sql).Tables(0)
                        If cmb_emp.Rows(0)(0) > 0 Then
                            Dim sql1 As String = "select t.zonal_id from zonal_master t where t.hr_head=" & usr(0) & ""
                            dt = oh.ExecuteDataSet(sql1).Tables(0)
                            ' If dt.Rows.Count > 0 Then
                            Dim dtw As DataTable = oh.ExecuteDataSet("select count(*) from department_mst t where t.dep_head=" & usr(0) & "").Tables(0)
                            Dim dep As String = ""
                            If dtw.Rows(0)(0) > 0 Then
                                Dim sql115 As String = "select t.dep_id from department_mst t where t.dep_head =" & usr(0) & ""
                                Dim dte As DataTable = oh.ExecuteDataSet(sql115).Tables(0)
                                Dim dr As DataRow

                                For Each dr In dte.Rows
                                    If dep = "" Then
                                        dep = dr(0)
                                    Else
                                        dep = dep.ToString + "," + dr(0).ToString
                                    End If

                                Next
                            End If
                            If dep = "" Then
                                dep = 0
                            End If
                            sql1 = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,area_detail ad,division_detail dd,region_detail rd,zonal_detail zd where t.emp_code=ca.emp_code and t.branch_id=ad.branch_id and ad.area_id=dd.area_id and dd.div_id=rd.division_id and rd.region_id=zd.region_id and zd.zonal_id in (select t.zonal_id from zonal_master t where t.hr_head=" & usr(0) & ") and t.post_id in(28,29,30,31,32,33,34,35,36,112,128,169,170,178,131,134,136,141,197,199,200) and t.emp_code<>" & usr(0) & " and ca.comp_id=cm.comp_id and ca.status_id=0  union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,area_detail ad,division_detail dd,region_detail rd,zonal_detail zd where t.emp_code=ca.emp_code and t.branch_id=ad.branch_id and ad.area_id=dd.area_id and dd.div_id=rd.division_id and rd.region_id=zd.region_id and zd.zonal_id in (select t.zonal_id from zonal_master t where t.hr_head=" & usr(0) & ") and t.post_id in(10,11,12,13,14,15,16,17,18,101,198) and t.emp_code<>" & usr(0) & " and ca.comp_id=cm.comp_id and ca.status_id=4 and ca.recom_person<>" & usr(0) & " union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.department_id=dp.dep_id  and dp.dep_id in (" & dep & ") and t.emp_code=ca.emp_code  and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and ca.comp_id=cm.comp_id and ca.status_id in (0) and t.branch_id=0  union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.department_id=dp.dep_id and dp.dep_id in (" & dep & ") and t.emp_code=ca.emp_code and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and t.branch_id<>0 and t.department_id in (23,37,4,5,38,183,188,179,180,23) and ca.comp_id=cm.comp_id and ca.status_id in (0) union select ca.emp_code || '*' || ca.comp_id,ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name from hrm_comp_appl   ca,hrm_comp_mst cm,employee_master t,leave_autosanction m, employ_firm  ef where  t.emp_code = ca.emp_code and t.emp_code = ef.emp_code and ef.firm_id =" & Session("firm_id") & " and ca.emp_code=m.emp_code and ca.comp_id = cm.comp_id and ca.status_id in (4,0)"
                            'Else
                            '    sql1 = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,area_detail ad,division_detail dd,region_detail rd,zonal_detail zd where t.emp_code=ca.emp_code and t.branch_id=ad.branch_id and ad.area_id=dd.area_id and dd.div_id=rd.division_id and rd.region_id=zd.region_id and zd.zonal_id in (select t.zonal_id from zonal_master t where t.hr_head=" & usr(0) & ") and t.post_id in(28,29,30,31,32,33,34,35,36,112,128,169,170,178,131,134,136,141,197,199,200) and t.emp_code<>" & usr(0) & " and ca.comp_id=cm.comp_id and ca.status_id=0  union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,area_detail ad,division_detail dd,region_detail rd,zonal_detail zd where t.emp_code=ca.emp_code and t.branch_id=ad.branch_id and ad.area_id=dd.area_id and dd.div_id=rd.division_id and rd.region_id=zd.region_id and zd.zonal_id in (select t.zonal_id from zonal_master t where t.hr_head=" & usr(0) & ") and t.post_id in(10,11,12,13,14,15,16,17,18,101,198) and t.emp_code<>" & usr(0) & " and ca.comp_id=cm.comp_id and ca.status_id=4 and ca.recom_person<>" & usr(0) & ""

                            'End If


                            dt = oh.ExecuteDataSet(sql1).Tables(0)
                            If dt.Rows.Count > 1 Then
                                Me.cmb_emp.DataSource = dt
                                Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                                Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                                Me.cmb_emp.DataBind()
                            Else
                                Dim cl_script As New StringBuilder
                                cl_script.Append("   alert('THERE IS NO COMPENSATORY OFF TO SANCTION/RECOMMEND') ;")
                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                            End If





                            'End If
                        Else



                            Sql = "select count(*) from department_mst t where t.adt_tour_sac=" & usr(0) & ""
                            cmb_emp = oh.ExecuteDataSet(Sql).Tables(0)
                            If cmb_emp.Rows(0)(0) > 0 Then
                                Dim sql15 As String = "select t.dep_id from department_mst t where t.adt_tour_sac =" & usr(0) & ""
                                dt = oh.ExecuteDataSet(sql15).Tables(0)
                                Dim dr1 As DataRow
                                Dim dep1 As String = " "
                                For Each dr1 In dt.Rows
                                    If dep1 = " " Then
                                        dep1 = dr1(0)
                                    Else
                                        dep1 = dep1.ToString + "," + dr1(0).ToString
                                    End If
                                Next
                                If dt.Rows.Count > 0 Then
                                    Dim sql16 As String = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.department_id=dp.dep_id  and dp.dep_id in (" & dep1 & ") and t.emp_code=ca.emp_code  and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and ca.comp_id=cm.comp_id and ca.status_id=0  and t.department_id in (4,188,179,178,189,179,183,180,38)   union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.department_id=dp.dep_id and dp.dep_id in (" & dep1 & ") and t.emp_code=ca.emp_code and t.emp_code<>" & usr(0) & "   and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and t.department_id in (4,188,178,189,179,183,180,38) and ca.comp_id=cm.comp_id and ca.status_id=0"
                                    dt = oh.ExecuteDataSet(sql16).Tables(0)
                                    If dt.Rows.Count > 1 Then
                                        Me.cmb_emp.DataSource = dt
                                        Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                                        Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                                        Me.cmb_emp.DataBind()
                                        'Else
                                        '    Dim cl_script As New StringBuilder
                                        '    cl_script.Append("   alert('THERE IS NO COMPENSATORY OFF TO SANCTION/RECOMMEND') ;")
                                        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                                    End If
                                End If

                            Else


                                Sql = "select count(*) from department_mst t where t.vg_tour_sac=" & usr(0) & ""
                                cmb_emp = oh.ExecuteDataSet(Sql).Tables(0)
                                If cmb_emp.Rows(0)(0) > 0 Then
                                    Dim sql15 As String = "select t.dep_id from department_mst t where t.vg_tour_sac =" & usr(0) & ""
                                    dt = oh.ExecuteDataSet(sql15).Tables(0)
                                    Dim dr1 As DataRow
                                    Dim dep1 As String = " "
                                    For Each dr1 In dt.Rows
                                        If dep1 = " " Then
                                            dep1 = dr1(0)
                                        Else
                                            dep1 = dep1.ToString + "," + dr1(0).ToString
                                        End If
                                    Next
                                    If dt.Rows.Count > 0 Then
                                        Dim sql16 As String = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.department_id=dp.dep_id  and dp.dep_id in (" & dep1 & ") and t.emp_code=ca.emp_code  and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and ca.comp_id=cm.comp_id and ca.status_id=0  and t.department_id in (23,180,183)   union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.department_id=dp.dep_id and dp.dep_id in (" & dep1 & ") and t.emp_code=ca.emp_code and t.emp_code<>" & usr(0) & "   and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and t.department_id in (23,180,183) and ca.comp_id=cm.comp_id and ca.status_id=0"
                                        dt = oh.ExecuteDataSet(sql16).Tables(0)
                                        If dt.Rows.Count > 1 Then
                                            Me.cmb_emp.DataSource = dt
                                            Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                                            Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                                            Me.cmb_emp.DataBind()
                                            'Else
                                            '    Dim cl_script As New StringBuilder
                                            '    cl_script.Append("   alert('THERE IS NO COMPENSATORY OFF TO SANCTION/RECOMMEND') ;")
                                            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                                        End If
                                    End If


                                Else

                                    ''''''''''''headoffice




                                    Sql = "select count(*) from department_major t where t.head_id like '%" & usr(0) & "%'"
                                    cmb_emp = oh.ExecuteDataSet(Sql).Tables(0)
                                    If cmb_emp.Rows(0)(0) > 0 Then

                                        Dim sql1 As String = "select t.department_id from department_major t where t.head_id like '%" & usr(0) & "%'"
                                        dt = oh.ExecuteDataSet(sql1).Tables(0)


                                        If dt.Rows.Count > 0 Then
                                            Dim dep As String = " "
                                            Dim dtw As DataTable = oh.ExecuteDataSet("select count(*) from department_mst t where t.dep_head=" & usr(0) & "").Tables(0)

                                            If dtw.Rows(0)(0) > 0 Then
                                                Dim sql115 As String = "select t.dep_id from department_mst t where t.dep_head =" & usr(0) & ""
                                                Dim dte As DataTable = oh.ExecuteDataSet(sql115).Tables(0)
                                                Dim dr As DataRow

                                                For Each dr In dte.Rows
                                                    If dep = " " Then
                                                        dep = dr(0)
                                                    Else
                                                        dep = dep.ToString + "," + dr(0).ToString
                                                    End If

                                                Next
                                                sql1 = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp,employ_firm ef  where t.department_id=dp.dep_id and dp.major_dep_id=" & dt.Rows(0)(0) & " and t.emp_code=ca.emp_code  and t.emp_code=ef.emp_code   and ef.firm_id=" & firm & " and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and ca.comp_id=cm.comp_id and ca.status_id in (4) and t.branch_id=0 union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp,employ_firm ef  where t.department_id=dp.dep_id and dp.major_dep_id=" & dt.Rows(0)(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and t.emp_code=ca.emp_code  and t.emp_code=ef.emp_code   and ef.firm_id=" & firm & " and t.emp_code<>" & usr(0) & " and t.branch_id<>0 and t.department_id in (23,37,5,38,179,180,23) and ca.comp_id=cm.comp_id and ca.status_id in (4) union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp,employ_firm ef  where t.emp_code=ca.emp_code and t.emp_code<>" & usr(0) & "  and t.emp_code=ef.emp_code   and ef.firm_id=" & firm & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and ca.comp_id=cm.comp_id and ca.status_id in (0) and t.branch_id=0 and t.emp_code in (select r.dep_head from department_mst r where  r.major_dep_id=" & dt.Rows(0)(0) & " union select r.vg_tour_sac from department_mst r where  r.major_dep_id=" & dt.Rows(0)(0) & " union select r.adt_tour_sac from department_mst r where  r.major_dep_id=" & dt.Rows(0)(0) & "   ) union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp,employ_firm ef  where t.department_id=dp.dep_id  and dp.dep_id in (" & dep & ") and t.emp_code=ca.emp_code  and t.emp_code=ef.emp_code   and ef.firm_id=" & firm & "  and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and ca.comp_id=cm.comp_id and ca.status_id in (0) and t.branch_id=0  union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp,employ_firm ef  where t.department_id=dp.dep_id and dp.dep_id in (" & dep & ") and t.emp_code=ca.emp_code  and t.emp_code=ef.emp_code   and ef.firm_id=" & firm & " and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and t.branch_id<>0 and t.department_id in (23,37,5,38,179,180,23) and ca.comp_id=cm.comp_id and ca.status_id in (0) union select ca.emp_code || '*' || ca.comp_id,ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name from hrm_comp_appl   ca,hrm_comp_mst cm,employee_master t,leave_autosanction m, employ_firm  ef where  t.emp_code = ca.emp_code and t.emp_code = ef.emp_code and ef.firm_id =" & Session("firm_id") & " and ca.emp_code=m.emp_code and ca.comp_id = cm.comp_id and ca.status_id in (4,0)"
                                            Else
                                                sql1 = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp,employ_firm ef  where t.department_id=dp.dep_id and dp.major_dep_id=" & dt.Rows(0)(0) & " and t.emp_code=ca.emp_code  and t.emp_code=ef.emp_code   and ef.firm_id=" & firm & " and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and ca.comp_id=cm.comp_id and ca.status_id in (4) and t.branch_id=0 union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp,employ_firm ef  where t.department_id=dp.dep_id and dp.major_dep_id=" & dt.Rows(0)(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and t.emp_code=ca.emp_code  and t.emp_code=ef.emp_code   and ef.firm_id=" & firm & " and t.emp_code<>" & usr(0) & " and t.branch_id<>0 and t.department_id in (37,5,38,179,180,23) and ca.comp_id=cm.comp_id and ca.status_id in (4) union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp, employ_firm ef  where t.emp_code=ca.emp_code and t.emp_code<>" & usr(0) & "   and t.emp_code=ef.emp_code     and ef.firm_id=" & firm & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and ca.comp_id=cm.comp_id and ca.status_id in (0) and t.branch_id=0 and t.emp_code in (select r.dep_head from department_mst r where  r.major_dep_id=" & dt.Rows(0)(0) & " union select r.vg_tour_sac from department_mst r where  r.major_dep_id=" & dt.Rows(0)(0) & " union select r.adt_tour_sac from department_mst r where  r.major_dep_id=" & dt.Rows(0)(0) & "  )"
                                            End If
                                            If Session("firm_id") = 24 Then
                                                Dim dtpdst = oh.ExecuteDataSet("select post_id,department_id from emp_master where emp_code=" & usr(0) & "").Tables(0)
                                                post = dtpdst.rows(0)(0)
                                                If post = 378 Then
                                                    sql1 = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name from hrm_comp_appl   ca, hrm_comp_mst    cm,employee_master t,employ_firm     ef where ca.comp_id=cm.comp_id and ca.emp_code = t.emp_code and t.post_id<>318 and  t.emp_code <> " & usr(0) & " and t.emp_code = ef.emp_code and ef.firm_id = " & Session("firm_id") & "  and ca.status_id in(0,4) and t.branch_id = 0 and t.emp_code in (select  d.dep_head from department_mst d, emp_master e, employ_firm f where d.dep_id = e.DEPARTMENT_ID and e.EMP_CODE = f.emp_code and f.firm_id = 24  and e.STATUS_ID = 1 group by d.dep_head) union select ca.emp_code || '*' || ca.comp_id, ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name from hrm_comp_appl   ca, hrm_comp_mst    cm,employee_master t, employ_firm     ef where t.emp_code = ca.emp_code and t.emp_code = ef.emp_code and ef.firm_id = " & Session("firm_id") & "  and t.emp_code <> " & usr(0) & " and t.branch_id <> 0 and t.post_id in(199) and ca.comp_id = cm.comp_id and ca.status_id in (0,4) union    select ca.emp_code || '*' || ca.comp_id,ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' || cm.comp_name from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t, employ_firm ef where ca.comp_id = cm.comp_id and ca.emp_code = t.emp_code and t.post_id <> 318 and t.emp_code <> " & usr(0) & " and t.emp_code = ef.emp_code and ef.firm_id = 24 and ca.status_id in (0, 4) and t.branch_id = 0 and t.department_id in (select d.dep_id from department_mst d where d.dep_head=" & usr(0) & ")"
                                                Else
                                                    sql1 = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code || '*' || ca.comp_id,ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||cm.comp_name from hrm_comp_appl   ca,hrm_comp_mst    cm,employee_master t,department_mst  dp,employ_firm     ef where t.department_id = dp.dep_id and dp.dep_id in (" & dep & ") and t.emp_code = ca.emp_code and t.emp_code <> " & usr(0) & " and t.emp_code = ef.emp_code and ef.firm_id = " & Session("firm_id") & " and t.branch_id <> 0 and (ca.recom_person <> " & usr(0) & " or ca.recom_person is null) and ca.comp_id = cm.comp_id and ca.status_id = 0 and t.emp_code not in(select dep_head from department_mst )"
                                                End If
                                            End If
                                            dt = oh.ExecuteDataSet(sql1).Tables(0)

                                            'Sql = "select count(*) from department_mst t where t.dep_head=" & usr(0) & ""
                                            'cmb_emp = oh.ExecuteDataSet(Sql).Tables(0)
                                            'If cmb_emp.Rows(0)(0) > 0 Then
                                            '    Dim sql1 As String = "select t.dep_id from department_mst t where t.dep_head=" & usr(0) & ""
                                            '    dt = oh.ExecuteDataSet(sql1).Tables(0)
                                            '    If dt.Rows.Count > 0 Then
                                            '        sql1 = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code||'*'||ca.comp_id,ca.emp_code||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t where t.department_id=" & dt.Rows(0)(0) & " and t.emp_code=ca.emp_code and t.emp_code<>" & usr(0) & " and ca.comp_id=cm.comp_id and ca.status_id=0"
                                            '        dt = oh.ExecuteDataSet(sql1).Tables(0)


                                            If dt.Rows.Count > 1 Then
                                                Me.cmb_emp.DataSource = dt
                                                Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                                                Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                                                Me.cmb_emp.DataBind()
                                            Else
                                                Dim cl_script As New StringBuilder
                                                cl_script.Append("   alert('THERE IS NO COMPENSATORY OFF TO SANCTION/RECOMMEND') ;")
                                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                                            End If


                                        End If



                                    Else



                                        Sql = "select count(*) from department_mst t where t.dep_head=" & usr(0) & ""
                                        cmb_emp = oh.ExecuteDataSet(Sql).Tables(0)
                                        If cmb_emp.Rows(0)(0) > 0 Then
                                            Dim sql11 As String = "select t.dep_id from department_mst t where t.dep_head =" & usr(0) & ""
                                            dt = oh.ExecuteDataSet(sql11).Tables(0)
                                            Dim dr As DataRow
                                            Dim dep As String = " "
                                            For Each dr In dt.Rows
                                                If dep = " " Then
                                                    dep = dr(0)
                                                Else
                                                    dep = dep.ToString + "," + dr(0).ToString
                                                End If
                                            Next
                                            If dt.Rows.Count > 0 Then
                                                'sql11 = "select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.department_id=dp.dep_id  and dp.dep_id in (" & dep & ") and t.emp_code=ca.emp_code  and t.emp_code<>" & usr(0) & " and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and ca.comp_id=cm.comp_id and ca.status_id=0 and t.branch_id=0 and t.department_id not in (4,178,188,23,180,183)   union select ca.emp_code||'*'||ca.comp_id,ca.emp_code || '*' || t.emp_name ||'*'||ca.leave_dt||'*'||cm.comp_name from hrm_comp_appl ca,hrm_comp_mst cm,employee_master t,department_mst dp  where t.department_id=dp.dep_id and dp.dep_id in (" & dep & ") and t.emp_code=ca.emp_code and t.emp_code<>" & usr(0) & " and t.branch_id<>0  and (ca.recom_person<>" & usr(0) & " or ca.recom_person is null) and t.department_id in (23,37,5,38,179,180,23) and t.department_id not in (4,178,188,23,180,183)  and ca.comp_id=cm.comp_id and ca.status_id=0"
                                                sql11 = "select '-1', 'Employee Code  - Leave Date- Compensation Name' as emp_name  from dual  union  select ca.emp_code || '*' || ca.comp_id,  ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||  cm.comp_name  from hrm_comp_appl   ca,  hrm_comp_mst    cm,  employee_master t,  department_mst  dp,  employ_firm     ef  where t.department_id = dp.dep_id  and dp.dep_id in (" & dep & ")  and t.emp_code = ca.emp_code  and t.emp_code = ef.emp_code  and ef.firm_id = " & firm & "  and t.emp_code <> " & usr(0) & "  and (ca.recom_person <> " & usr(0) & " or ca.recom_person is null)  and ca.comp_id = cm.comp_id  and ca.status_id = 0  and t.branch_id = 0  and t.department_id not in (4, 178, 188, 23, 180, 183)  union  select ca.emp_code || '*' || ca.comp_id,  ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||  cm.comp_name  from hrm_comp_appl   ca,  hrm_comp_mst    cm,  employee_master t,  department_mst  dp,  employ_firm     ef  where t.department_id = dp.dep_id  and dp.dep_id in (" & dep & ")  and t.emp_code = ca.emp_code  and t.emp_code <> " & usr(0) & "  and t.emp_code = ef.emp_code  and ef.firm_id = " & firm & "  and t.branch_id <> 0  and (ca.recom_person <> " & usr(0) & " or ca.recom_person is null)  and t.department_id in (23, 37, 5, 38, 179, 180, 23)  and t.department_id not in (4, 178, 188, 23, 180, 183)  and ca.comp_id = cm.comp_id  and ca.status_id = 0"
                                                dt = oh.ExecuteDataSet(sql11).Tables(0)
                                                If dt.Rows.Count > 1 Then
                                                    Me.cmb_emp.DataSource = dt
                                                    Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                                                    Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                                                    Me.cmb_emp.DataBind()
                                                Else
                                                    Dim cl_script As New StringBuilder
                                                    cl_script.Append("   alert('THERE IS NO COMPENSATORY OFF TO SANCTION/RECOMMEND') ;")
                                                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                                                End If
                                            End If
                                        Else
                                            If usr(0) = 20007 Then

                                                dt = oh.ExecuteDataSet("select '-1','Employee Code  - Leave Date- Compensation Name' as emp_name from dual union select ca.emp_code || '*' || ca.comp_id,ca.emp_code || '*' || t.emp_name || '*' || ca.leave_dt || '*' ||cm.comp_name from hrm_comp_appl ca, hrm_comp_mst cm, employee_master t, employ_firm ef where t.emp_code = ca.emp_code and t.emp_code = ef.emp_code and ef.firm_id = 24 and t.branch_id =0 and t.post_id in (318,378) and ca.comp_id = cm.comp_id and ca.status_id in (0, 4)").Tables(0)
                                                If dt.Rows.Count > 1 Then
                                                    Me.cmb_emp.DataSource = dt
                                                    Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                                                    Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                                                    Me.cmb_emp.DataBind()
                                                Else
                                                    Dim cl_script As New StringBuilder
                                                    cl_script.Append("   alert('THERE IS NO COMPENSATORY OFF TO SANCTION/RECOMMEND') ;")
                                                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                                                End If

                                            Else

                                                Server.Transfer("../../show_err.aspx")
                                            End If
                                        End If
                                    End If
                                    ''''''''''headoffice


                                End If
                            End If

                        End If
                    End If

                End If
            End If
        End If


    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return str
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        str = ""
        Dim data() As String = eventArgument.Split("*")

        Select Case CInt(data(0))
            Case 1
                Dim dt2 As New DataTable
                dt = oh.ExecuteDataSet("select distinct em.emp_code||'*'||em.emp_name||'*'||br.branch_name||'*'||pm.post_name||'*'||ca.leave_dt||'*'||ca.apply_dt||'*'||cm.comp_name||'*'||cd.comp_date||'*'||cd.exp_date||'*'||ca.reason from employee_master em,post_mst pm,branch br,hrm_comp_appl ca,hrm_comp_mst cm,hrm_comp_dtl cd where  em.post_id=pm.post_id and cm.comp_id=cd.comp_id and em.branch_id=br.branch_id and ca.emp_code=em.emp_code and ca.comp_id=cm.comp_id and ca.status_id in (0,4) and ca.comp_id=" & data(2) & " and em.emp_code=" & data(1) & "").Tables(0)
                If dt.Rows.Count > 0 Then
                    str += dt.Rows(0)(0).ToString
                Else
                    str = 4
                End If
            Case 2


                Dim leave(7) As OracleParameter
                leave(0) = New OracleParameter("emp_type", OracleType.Number)
                leave(0).Direction = ParameterDirection.Input
                leave(0).Value = data(3)
                leave(1) = New OracleParameter("btn_type", OracleType.Number)
                leave(1).Direction = ParameterDirection.Input
                leave(1).Value = 3
                leave(2) = New OracleParameter("emp_id", OracleType.Number)
                leave(2).Direction = ParameterDirection.Input
                leave(2).Value = data(1)
                leave(3) = New OracleParameter("com_id", OracleType.Number)
                leave(3).Direction = ParameterDirection.Input
                leave(3).Value = data(2)
                leave(4) = New OracleParameter("rec_san_emp_code", OracleType.Number)
                leave(4).Direction = ParameterDirection.Input
                leave(4).Value = data(4)

                leave(5) = New OracleParameter("rej_reason", OracleType.VarChar, 100)
                leave(5).Direction = ParameterDirection.Input
                leave(5).Value = data(5)

                leave(6) = New OracleParameter("err_stat", OracleType.Number)
                leave(6).Direction = ParameterDirection.InputOutput
                leave(7) = New OracleParameter("err_msg", OracleType.VarChar, 100)
                leave(7).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("hrm_compensatory_san", leave)
                str += leave(6).Value.ToString()
                str += "*"
                str += leave(7).Value.ToString()
                If leave(6).Value = 1 Then

                    Dim dt88 As DataTable = oh.ExecuteDataSet("select e.emp_name,a.leave_dt,e1.emp_name,decode(a.status_id,1,'Sanctioned',2,'Rejected',3,'cancelled',5,'cancelled',4,'Recommended') as status,a.email from employee_master e,hrm_comp_appl a,employee_master e1 where a.comp_id=" & data(2) & " and a.emp_code=" & data(1) & " and e.emp_code=a.emp_code and e1.emp_code=" & data(4) & "").Tables(0)
                    'If dt88.Rows.Count <> 0 And dt88.Rows.Count = 1 Then
                    '    If Not IsDBNull(dt88.Rows(0)(4)) Then

                    '        Try
                    '            Dim mMailServer As String
                    '            Dim mPort As Integer
                    '            mMailServer = ConfigurationManager.AppSettings.Get("MyMailServer")
                    '            mPort = ConfigurationManager.AppSettings.Get("MyMailServerPort")
                    '            Dim ldt As String = Format(CDate(dt88.Rows(0)(1)), "dd/MMM/yyyy")
                    '            Dim str As String = "<h1 style='background-color:gold; color:red; text-align:center; font-size:18px'>MANAPPURAM GROUP OF COMPANIES</h1><h2 style='color:red; font-size:14px'><u>COMPENSATORY STATUS</u></h2><p style='font-size:12px'>Mr/Ms " & dt88.Rows(0)(0) & " </p> <p style='font-size:12px'>Your Compensatory Leave on " & ldt & " is " & dt88.Rows(0)(3) & " by Mr/Ms " & dt88.Rows(0)(2) & ",Due to " & data(5) & "</p><p style='color:blue; font-size:12px'> For further Queries and information if needed contact HRM</p><p style='text-align:right; font-size:12px'>Thank you ,</p><p style='text-align:right; font-size:12px'></p><p style='font-family:courier new; text-align:right; color:navy; font-size:12px'>MANAPPURAM-IT(SOFTWARE)</p><p style='font-family:courier new; text-align:right; color:navy; font-size:12px'>Payroll-section</p>"
                    '            bilu_send_mail.bilu_send_mail.SendMail(dt88.Rows(0)(3), mMailServer, mPort, "manappuram", ldt, dt88.Rows(0)(0), dt88.Rows(0)(4), "Compensatory Applied Status on " & Format(Date.Now, "dd/MMM/yyyy") & "", str)

                    '        Catch ex As Exception
                    '            Dim cl_script As New StringBuilder
                    '            cl_script.Append("   alert('Mail Service is not Available in this system') ;")
                    '            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)


                    '        End Try
                    '         End If
                    'End If
                End If

        End Select

    End Sub

    Protected Sub cmd_rec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_rec.Click
        Dim emp_dtl() As String
        emp_dtl = Me.cmb_emp.SelectedValue.Split("*")

        Dim leave(7) As OracleParameter
        leave(0) = New OracleParameter("emp_type", OracleType.Number)
        leave(0).Direction = ParameterDirection.Input
        leave(0).Value = Me.emp_type.Value
        leave(1) = New OracleParameter("btn_type", OracleType.Number)
        leave(1).Direction = ParameterDirection.Input
        leave(1).Value = 1
        leave(2) = New OracleParameter("emp_id", OracleType.Number)
        leave(2).Direction = ParameterDirection.Input
        leave(2).Value = emp_dtl(0)
        leave(3) = New OracleParameter("com_id", OracleType.Number)
        leave(3).Direction = ParameterDirection.Input
        leave(3).Value = emp_dtl(1)
        leave(4) = New OracleParameter("rec_san_emp_code", OracleType.Number)
        leave(4).Direction = ParameterDirection.Input
        leave(4).Value = usr(0)

        leave(5) = New OracleParameter("rej_reason", OracleType.VarChar, 100)
        leave(5).Direction = ParameterDirection.Input
        leave(5).Value = Me.hid_rej.Value

        leave(6) = New OracleParameter("err_stat", OracleType.Number)
        leave(6).Direction = ParameterDirection.InputOutput
        leave(7) = New OracleParameter("err_msg", OracleType.VarChar, 100)
        leave(7).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("hrm_compensatory_san", leave)
        If leave(6).Value = 1 Then
            Dim dt88 As DataTable = oh.ExecuteDataSet("select e.emp_name,a.leave_dt,e1.emp_name,decode(a.status_id,1,'Sanctioned',2,'Rejected',3,'cancelled',5,'cancelled',4,'Recommended') as status,a.email from employee_master e,hrm_comp_appl a,employee_master e1 where a.comp_id=" & emp_dtl(1) & " and a.emp_code=" & emp_dtl(0) & " and e.emp_code=a.emp_code and e1.emp_code=" & usr(0) & "").Tables(0)
            'If dt88.Rows.Count <> 0 And dt88.Rows.Count = 1 Then
            '    If Not IsDBNull(dt88.Rows(0)(4)) Then
            '        Try
            '            Dim mMailServer As String
            '            Dim mPort As Integer
            '            mMailServer = ConfigurationManager.AppSettings.Get("MyMailServer")
            '            mPort = ConfigurationManager.AppSettings.Get("MyMailServerPort")
            '            Dim ldt As String = Format(CDate(dt88.Rows(0)(1)), "dd/MMM/yyyy")
            '            Dim str As String = "<h1 style='background-color:gold; color:red; text-align:center; font-size:18px'>MANAPPURAM GROUP OF COMPANIES</h1><h2 style='color:red; font-size:14px'><u>COMPENSATORY STATUS</u></h2><p style='font-size:12px'>Mr/Ms " & dt88.Rows(0)(0) & " </p> <p style='font-size:12px'>Your Compensatory Leave on " & ldt & " is " & dt88.Rows(0)(3) & " by Mr/Ms " & dt88.Rows(0)(2) & " and waiting for Sanction.</p><p style='color:blue; font-size:12px'> For further Queries and information if needed contact HRM</p><p style='text-align:right; font-size:12px'>Thank you ,</p><p style='text-align:right; font-size:12px'></p><p style='font-family:courier new; text-align:right; color:navy; font-size:12px'>MANAPPURAM-IT(SOFTWARE)</p><p style='font-family:courier new; text-align:right; color:navy; font-size:12px'>Payroll-section</p>"
            '            bilu_send_mail.bilu_send_mail.SendMail(dt88.Rows(0)(3), mMailServer, mPort, "manappuram", ldt, dt88.Rows(0)(0), dt88.Rows(0)(4), "Compensatory Applied Status on " & Format(Date.Now, "dd/MMM/yyyy") & "", str)
            '        Catch ex As Exception
            '            Dim cl_script As New StringBuilder
            '            cl_script.Append("   alert('Mail Service is not Available in this system') ;")
            '            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)


            '        End Try
            ' End If
            '    End If
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' " & leave(7).Value & " ');")
            cl_script0.Append("       window.open('compensatory_sanction.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' " & leave(7).Value & " ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)

        End If
    End Sub


    Protected Sub cmd_san_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_san.Click
        Dim emp_dtl() As String

        emp_dtl = Me.cmb_emp.SelectedValue.Split("*")

        Dim leave(7) As OracleParameter
        leave(0) = New OracleParameter("emp_type", OracleType.Number)
        leave(0).Direction = ParameterDirection.Input
        leave(0).Value = Me.emp_type.Value
        leave(1) = New OracleParameter("btn_type", OracleType.Number)
        leave(1).Direction = ParameterDirection.Input
        leave(1).Value = 2
        leave(2) = New OracleParameter("emp_id", OracleType.Number)
        leave(2).Direction = ParameterDirection.Input
        leave(2).Value = emp_dtl(0)
        leave(3) = New OracleParameter("com_id", OracleType.Number)
        leave(3).Direction = ParameterDirection.Input
        leave(3).Value = emp_dtl(1)
        leave(4) = New OracleParameter("rec_san_emp_code", OracleType.Number)
        leave(4).Direction = ParameterDirection.Input
        leave(4).Value = usr(0)

        leave(5) = New OracleParameter("rej_reason", OracleType.VarChar, 100)
        leave(5).Direction = ParameterDirection.Input
        leave(5).Value = Me.hid_rej.Value

        leave(6) = New OracleParameter("err_stat", OracleType.Number)
        leave(6).Direction = ParameterDirection.InputOutput
        leave(7) = New OracleParameter("err_msg", OracleType.VarChar, 100)
        leave(7).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("hrm_compensatory_san", leave)
        If leave(6).Value = 1 Then
            Dim dt88 As DataTable = oh.ExecuteDataSet("select e.emp_name,a.leave_dt,e1.emp_name,decode(a.status_id,1,'Sanctioned',2,'Rejected',3,'cancelled',5,'cancelled',4,'Recommended') as status,a.email from employee_master e,hrm_comp_appl a,employee_master e1 where a.comp_id=" & emp_dtl(1) & " and a.emp_code=" & emp_dtl(0) & " and e.emp_code=a.emp_code and e1.emp_code=" & usr(0) & "").Tables(0)
            'If dt88.Rows.Count <> 0 And dt88.Rows.Count = 1 Then

            '    If Not IsDBNull(dt88.Rows(0)(4)) Then
            '        Try
            '            Dim mMailServer As String
            '            Dim mPort As Integer
            '            mMailServer = ConfigurationManager.AppSettings.Get("MyMailServer")
            '            mPort = ConfigurationManager.AppSettings.Get("MyMailServerPort")
            '            Dim ldt As String = Format(CDate(dt88.Rows(0)(1)), "dd/MMM/yyyy")
            '            Dim str As String = "<h1 style='background-color:gold; color:red; text-align:center; font-size:18px'>MANAPPURAM GROUP OF COMPANIES</h1><h2 style='color:red; font-size:14px'><u>COMPENSATORY STATUS</u></h2><p style='font-size:12px'>Mr/Ms " & dt88.Rows(0)(0) & " </p> <p style='font-size:12px'>Your Compensatory Leave on " & ldt & " is " & dt88.Rows(0)(3) & " by Mr/Ms " & dt88.Rows(0)(2) & ".</p><p style='color:blue; font-size:12px'> For further Queries and information if needed contact HRM</p><p style='text-align:right; font-size:12px'>Thank you ,</p><p style='text-align:right; font-size:12px'></p><p style='font-family:courier new; text-align:right; color:navy; font-size:12px'>MANAPPURAM-IT(SOFTWARE)</p><p style='font-family:courier new; text-align:right; color:navy; font-size:12px'>Payroll-section</p>"
            '            bilu_send_mail.bilu_send_mail.SendMail(dt88.Rows(0)(3), mMailServer, mPort, "manappuram", ldt, dt88.Rows(0)(0), dt88.Rows(0)(4), "Compensatory Applied Status on " & Format(Date.Now, "dd/MMM/yyyy") & "", str)
            '        Catch ex As Exception
            '            Dim cl_script As New StringBuilder
            '            cl_script.Append("   alert('Mail Service is not Available in this system') ;")
            '            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)


            '        End Try

            '    End If
            'End If
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' " & leave(7).Value & " ');")
            cl_script0.Append("       window.open('compensatory_sanction.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' " & leave(7).Value & " ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        End If
    End Sub

    Protected Sub cmd_rej_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_rej.Click
        Dim emp_dtl() As String
        emp_dtl = Me.cmb_emp.SelectedValue.Split("*")

        Dim leave(7) As OracleParameter
        leave(0) = New OracleParameter("emp_type", OracleType.Number)
        leave(0).Direction = ParameterDirection.Input
        leave(0).Value = Me.emp_type.Value
        leave(1) = New OracleParameter("btn_type", OracleType.Number)
        leave(1).Direction = ParameterDirection.Input
        leave(1).Value = 3
        leave(2) = New OracleParameter("emp_id", OracleType.Number)
        leave(2).Direction = ParameterDirection.Input
        leave(2).Value = emp_dtl(0)
        leave(3) = New OracleParameter("com_id", OracleType.Number)
        leave(3).Direction = ParameterDirection.Input
        leave(3).Value = emp_dtl(1)
        leave(4) = New OracleParameter("rec_san_emp_code", OracleType.Number)
        leave(4).Direction = ParameterDirection.Input
        leave(4).Value = usr(0)

        leave(5) = New OracleParameter("rej_reason", OracleType.VarChar, 100)
        leave(5).Direction = ParameterDirection.Input
        leave(5).Value = Me.hid_rej.Value

        leave(6) = New OracleParameter("err_stat", OracleType.Number)
        leave(6).Direction = ParameterDirection.InputOutput
        leave(7) = New OracleParameter("err_msg", OracleType.VarChar, 100)
        leave(7).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("hrm_compensatory_san", leave)
        If leave(6).Value = 1 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' " & leave(7).Value & " ');")
            cl_script0.Append("       window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' " & leave(7).Value & " ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        End If
    End Sub
End Class


