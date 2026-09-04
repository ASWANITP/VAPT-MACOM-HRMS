Imports System.Data
Imports System.Data.OracleClient
Partial Class emp_transfer_37c2c69b1602
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1, dt2, dt22, dt23, dt24, dt3, dt4, dt7, dt8, dt9 As New DataTable
    Dim sql, sql1, sql2, sql3, sql7, sql8 As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim f As Integer = Session("firm_id")
        If f = 24 Then
            Response.Redirect("emp_transfer_Jwell.aspx")
            Exit Sub
        End If
        If f = 2 Then
            Response.Redirect("emp_transfer2.aspx")
            Exit Sub
        End If
        If f = 8 Then
            Response.Redirect("emp_transfer_mac_req.aspx")
            Exit Sub
        End If
        Dim cs As String = "var cont_name;cont_name='" & Me.txt_releivingdate.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)

        Dim script_val As String = "var disb ; disb='" & Me.cmd_confirm.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "Slll", script_val, True)
        'If (Session("access_id") = 33 Or Session("access_id") = 25) Then
        If Not IsPostBack Then
            sql = "select emp_code ||'--------'||emp_name,emp_code from employee_master where status_id=1 and emp_type in (1,2,4) and department_id is not null and post_id is not null and post_id not in (89) and designation_id is not null order by emp_code"
            sql1 = "select count(*) from employee_master where status_id=1 and emp_type in (1,2,4)"
            loa()

        End If
        'Else
        'Response.Redirect("../../show_err.aspx")
        'End If
    End Sub
    Sub loa()
        'dt = oh.ExecuteDataSet(sql1).Tables(0)
        'If (dt.Rows(0)(0) < 1) Then
        '    Me.cmb_select.Items.Add("No Employee Waiting To Be Transfer")
        'Else
        '    Me.cmb_select.Items.Add("Select the Employee")
        '    dt = oh.ExecuteDataSet(sql).Tables(0)
        '    Me.cmb_select.DataSource = dt
        '    Me.cmb_select.DataTextField = dt.Columns(0).ColumnName
        '    Me.cmb_select.DataValueField = dt.Columns(1).ColumnName
        '    Me.cmb_select.DataBind()
        '    emp_select()
        'End If

        Me.cmb_select.Text = 0
        If Me.cmb_select.Text = "" Then
            Dim msgbx1 As New System.Text.StringBuilder
            msgbx1.Append("         alert('Please Enter Employee Code!!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx1.ToString, True)
        Else
            emp_select()
        End If

        init_fill()
    End Sub
    Sub clear()
        Me.txt_name.Text = ""
        Me.txt_desig.Text = ""
        Me.txt_currentbranch.Text = ""
        Me.txt_currentdept.Text = ""
        Me.txt_currentPost.Text = ""
        Me.txt_joiningdate.Text = ""
        Me.Txt_firm.Text = ""
    End Sub
    'Protected Sub cmb_select_textChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_select.TextChanged
    '    clr()
    '    Me.lbl_date.Text = ""
    '    Me.lbl_msg.Text = ""
    '    dt1 = oh.ExecuteDataSet("select status_id from employee_exception  where emp_code='" & Me.cmb_select.Text & "'").Tables(0)
    '    If (dt1.Rows.Count <= 0) Then
    '        emp_select()
    '        clr()
    '        Dim sql22, sql23, sql24 As String
    '        sql22 = "select s.state_name,s.state_id from state_master s,branch b where b.branch_id=" & Me.cmb_newbranch.SelectedValue & " and b.state_id=s.state_id order by s.state_name "
    '        dt22 = oh.ExecuteDataSet(sql22).Tables(0)
    '        Me.cmb_state.DataSource = dt22
    '        Me.cmb_state.DataTextField = dt22.Columns(0).ColumnName
    '        Me.cmb_state.DataValueField = dt22.Columns(1).ColumnName
    '        Me.cmb_state.DataBind()
    '        Dim dthh As DataTable = oh.ExecuteDataSet("select nvl(h.hostel,0) from hrm_proposal_order h where h.emp_code= " & Me.cmb_select.Text & " and h.status=1 ").Tables(0)
    '        Dim hoste As String
    '        If dthh.Rows.Count = 0 Then
    '            Me.cathos.Visible = True
    '            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select 'Hostel Not Required',0 as flat_no,'AAB' as area_name from dual union select t.flat_name||'('||b.area_name||')',t.flat_no,b.area_name from tbl_rent_building_mst t,branch b where b.BRANCH_ID=t.branch_id and t.rent_category_id=" & Me.cmb_cat.SelectedValue & " and b.STATE_ID=" & Me.cmb_state.SelectedValue & " and t.status_id=1 order by area_name "
    '        Else
    '            Me.cathos.Visible = False
    '            hoste = dthh.Rows(0)(0)
    '            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select ' No Hostel',0 as flat_no,'AAB' as area_name from dual union select t.flat_name|| '(' || b.area_name || ')',t.flat_no,b.area_name from tbl_rent_building_mst t ,hrm_proposal_order d,branch b where  d.emp_code=" & Me.cmb_select.Text & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1 and t.branch_id=b.branch_id order by area_name"
    '        End If
    '        'sql23 = "select ' Select Hostel',-1 as flat_no from dual union select ' No Hostel',0 as flat_no from dual union select t.flat_name,t.flat_no from tbl_rent_building_mst t ,hrm_proposal_order d where  d.emp_code=" & Me.cmb_select.Text & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1  order by flat_no"
    '        dt23 = oh.ExecuteDataSet(sql23).Tables(0)
    '        Me.cmb_hostel.DataSource = dt23
    '        Me.cmb_hostel.DataTextField = dt23.Columns(0).ColumnName
    '        Me.cmb_hostel.DataValueField = dt23.Columns(1).ColumnName
    '        Me.cmb_hostel.DataBind()
    '        sql24 = "select count(t.flat_no),nvl(v.capacity,0) from tbl_rent_building_mst t left outer join tbl_rent_building_mst v  on (v.flat_no=t.flat_no and v.status_id=1) where t.flat_no=" & Me.cmb_hostel.SelectedValue & "  and t.status_id=1 group by  t.flat_no,v.capacity"
    '        dt24 = oh.ExecuteDataSet(sql24).Tables(0)
    '        If dt24.Rows.Count = 0 Then
    '            Me.pcap.Text = 0
    '            Me.totcap.Text = 0
    '        Else
    '            Me.pcap.Text = dt24.Rows(0)(0)
    '            Me.totcap.Text = dt24.Rows(0)(1)
    '        End If
    '    Else
    '        If (dt1.Rows(0)(0) = 1) Then
    '            clr()
    '            clear()
    '            Me.lbl_msg.Text = "SELECTED EMPLOYEE IS NOT ELIGIBLE FOR TRANSFER !"
    '        Else
    '            emp_select()
    '        End If
    '    End If
    'End Sub
    Sub emp_select()
        ' Sub emp_select()
        Dim f As Integer = Session("firm_id")
        clr()
        Dim sql, sql3, sql2, firm As String
        sql = "select count(*) from employ_transfer_dtl where to_dt is null and emp_code =" & Me.cmb_select.Text & ""
        sql2 = "select status_id from employ_transfer_dtl where to_dt is null and emp_code =" & Me.cmb_select.Text & ""
        dt1 = oh.ExecuteDataSet("select count(f.EMP_CODE)  from employ_firm f where f.EMP_CODE = " & Me.cmb_select.Text & "  and  f.firm_id=" & f & "").Tables(0)
        dt = oh.ExecuteDataSet(sql).Tables(0)

        If (dt.Rows(0)(0) >= 1) Then
            If dt1.Rows(0)(0) = 0 Then
                Me.lbl_msg.Text = "You Not Authorized To Transfer This CODE.PLz Login to correct FIRM !!!"
                clr()
                clear()
            Else
                dt = oh.ExecuteDataSet(sql2).Tables(0)
                If (dt.Rows(0)(0) = 1 Or dt.Rows(0)(0) = 8) Then
                    sql3 = "select a.emp_name,b.designation,c.branch_name,d.post_name,e.dep_name,a.join_dt from employee_master a,designation_master b,branch_master c,post_mst d,department_mst e where a.emp_code='" & Me.cmb_select.Text & "' and b.designation_id=a.designation_id and c.branch_id=a.branch_id and d.post_id=a.post_id and e.dep_id=a.department_id "
                    dt = oh.ExecuteDataSet(sql3).Tables(0)

                    If (dt.Rows.Count = 0) Then
                        dt = oh.ExecuteDataSet("select a.emp_name,b.designation,c.branch_name,d.post_name,e.dep_name,a.join_dt from employee_master a,designation_master b,before_completion c,post_mst d,department_mst e where a.emp_code='" & Me.cmb_select.Text & "' and b.designation_id=a.designation_id and c.old_id=a.branch_id and c.branch_id is null and d.post_id=a.post_id and e.dep_id=a.department_id ").Tables(0)
                    End If
                    If (dt.Rows.Count = 0) Then
                        Me.lbl_msg.Text = "SELECTED EMPLOYEE IS NOT AVAILABLE FOR TRANSFER !"
                        clr()
                        clear()
                    Else
                        Me.txt_name.Text = dt.Rows(0)(0)
                        Me.txt_desig.Text = dt.Rows(0)(1)
                        Me.txt_currentbranch.Text = dt.Rows(0)(2)
                        Me.txt_currentPost.Text = dt.Rows(0)(3)
                        Me.txt_currentdept.Text = dt.Rows(0)(4)

                        dt8 = oh.ExecuteDataSet("select emp_code from employee_master_dtl where new_empcode =" & Me.cmb_select.Text & "").Tables(0)
                        If (dt8.Rows.Count = 0) Then

                            Me.txt_joiningdate.Text = Format(dt.Rows(0)(5), "dd/MMM/yyyy")

                        Else

                            sql3 = "select a.join_dt from employee_master a where a.emp_code='" & dt8.Rows(0)(0) & "' "
                            dt = oh.ExecuteDataSet(sql3).Tables(0)
                            Me.txt_joiningdate.Text = Format(dt.Rows(0)(0), "dd/MMM/yyyy")


                        End If



                        sql3 = "select  nvl(deputation_id,0) from employ_transfer_dtl where from_dt in (select max(from_dt) from employ_transfer_dtl where (deputation_id not in (0) or deputation_id in (0)) and emp_code='" & Me.cmb_select.Text & "' and (to_date(to_dt) is not null or to_date(to_dt) is null)) and emp_code='" & Me.cmb_select.Text & "'  order by from_dt"
                        dt4 = oh.ExecuteDataSet(sql3).Tables(0)
                        sql2 = "select firm_id from employee_master where emp_code='" & Me.cmb_select.Text & "'"
                        dt3 = oh.ExecuteDataSet(sql2).Tables(0)
                        If (dt4.Rows.Count = 1 And dt4.Rows(0)(0) <> 0) Then
                            Dim dt15 As DataTable
                            firm = "select firm_name from firm_master where firm_id='" & dt4.Rows(0)(0) & "'"
                            dt15 = oh.ExecuteDataSet(firm).Tables(0)
                            Me.Txt_firm.Text = dt15.Rows(0)(0)
                        Else
                            If (dt4.Rows(0)(0) = 0 And IsDBNull(dt3.Rows(0)(0))) Then
                                Me.Txt_firm.Text = "No Firm"
                            Else
                                Dim dt15 As DataTable
                                firm = "select firm_name from firm_master where firm_id='" & dt3.Rows(0)(0) & "'"
                                dt15 = oh.ExecuteDataSet(firm).Tables(0)

                                Me.Txt_firm.Text = dt15.Rows(0)(0)
                                clr()


                            End If
                        End If
                        clr()
                    End If
                End If

            End If
            'Else

            'End If
        Else

            clear()
        End If
    End Sub
    Sub init_fill()
        Dim sql As String
        Dim f As Integer = Session("firm_id")
        sql8 = "select b.firm_id from branch_master b where b.branch_id=0"
        dt9 = oh.ExecuteDataSet(sql8).Tables(0)
        If dt9.Rows(0)(0) = f Then
            sql = "select branch_name,branch_id from branch_master where firm_id = " & f & " union select branch_name,old_id from before_completion where branch_id is null and firm_id=" & f & " order by branch_name "
        Else
            sql = "select branch_name,branch_id from branch_master where firm_id = " & f & " union select branch_name,old_id from before_completion where branch_id is null and firm_id=" & f & " union all select branch_name, branch_id  from branch_master where branch_id=0 order by branch_name "
        End If
        'sql = "select branch_name,branch_id from branch_master where firm_id = " & f & " union select branch_name,old_id from before_completion where branch_id is null and firm_id=" & f & " order by branch_name "
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Me.cmb_newbranch.DataSource = dt
        Me.cmb_newbranch.DataTextField = dt.Columns(0).ColumnName
        Me.cmb_newbranch.DataValueField = dt.Columns(1).ColumnName
        Me.cmb_newbranch.DataBind()

        Dim sql22, sql23, sql24, sql25 As String

        sql25 = "select t.rent_category_id,t.rent_category_name from tbl_rent_category t where t.rent_category_id<>1"
        Dim dt25 As DataTable = oh.ExecuteDataSet(sql25).Tables(0)
        Me.cmb_cat.DataSource = dt25
        Me.cmb_cat.DataTextField = dt25.Columns(1).ColumnName
        Me.cmb_cat.DataValueField = dt25.Columns(0).ColumnName
        Me.cmb_cat.DataBind()

        sql22 = "select s.state_name,s.state_id from state_master s,branch b where b.branch_id=" & Me.cmb_newbranch.SelectedValue & " and b.state_id=s.state_id order by s.state_name "
        dt22 = oh.ExecuteDataSet(sql22).Tables(0)
        Me.cmb_state.DataSource = dt22
        Me.cmb_state.DataTextField = dt22.Columns(0).ColumnName
        Me.cmb_state.DataValueField = dt22.Columns(1).ColumnName
        Me.cmb_state.DataBind()
        Dim dthh As DataTable = oh.ExecuteDataSet("select nvl(h.hostel,0) from hrm_proposal_order h where h.emp_code= " & Me.cmb_select.Text & " and h.status=1 ").Tables(0)
        Dim hoste As String
        If dthh.Rows.Count = 0 Then
            Me.cathos.Visible = True
            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select 'Hostel Not Required',0 as flat_no,'AAB' as area_name from dual union select t.flat_name||'('||b.area_name||')',t.flat_no,b.area_name from tbl_rent_building_mst t,branch b where b.BRANCH_ID=t.branch_id and t.rent_category_id=" & Me.cmb_cat.SelectedValue & " and b.STATE_ID=" & Me.cmb_state.SelectedValue & " and t.status_id=1 order by area_name "
        Else
            Me.cathos.Visible = False
            hoste = dthh.Rows(0)(0)
            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select ' No Hostel',0 as flat_no,'AAB' as area_name from dual union select t.flat_name|| '(' || b.area_name || ')',t.flat_no,b.area_name from tbl_rent_building_mst t ,hrm_proposal_order d,branch b where  d.emp_code=" & Me.cmb_select.Text & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1 and t.branch_id=b.branch_id order by area_name"
        End If
        'sql23 = "select ' Select Hostel',-1 as flat_no from dual union select ' No Hostel',0 as flat_no from dual union select t.flat_name,t.flat_no from tbl_rent_building_mst t ,hrm_proposal_order d where  d.emp_code=" & Me.cmb_select.Text & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1  order by flat_no"
        dt23 = oh.ExecuteDataSet(sql23).Tables(0)
        Me.cmb_hostel.DataSource = dt23
        Me.cmb_hostel.DataTextField = dt23.Columns(0).ColumnName
        Me.cmb_hostel.DataValueField = dt23.Columns(1).ColumnName
        Me.cmb_hostel.DataBind()
        sql24 = "select count(t.flat_no),nvl(v.capacity,0) from tbl_rent_building_mst t left outer join tbl_rent_building_mst v  on (v.flat_no=t.flat_no and v.status_id=1) where t.flat_no=" & Me.cmb_hostel.SelectedValue & "  and t.status_id=1 group by  t.flat_no,v.capacity"
        dt24 = oh.ExecuteDataSet(sql24).Tables(0)
        If dt24.Rows.Count = 0 Then
            Me.pcap.Text = 0
            Me.totcap.Text = 0
        Else
            Me.pcap.Text = dt24.Rows(0)(0)
            Me.totcap.Text = dt24.Rows(0)(1)
        End If
        Dim firms As Integer = Session("firm_id")
        If firms = 4 Then
            sql = "select dep_id, dep_name from department_mst d where d.firm_id=" & f & "  union all select dep_id, dep_name from department_mst d where d.firm_id=0  union all  select s.dep_id, s.dep_name from department_mst s where s.dep_id=14 order by dep_name"
        Else
            sql = "select dep_id, dep_name from department_mst d where d.firm_id=" & f & "  union all select dep_id, dep_name from department_mst d where d.firm_id=0 order by dep_name"
        End If
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Me.cmb_newdept.DataSource = dt
        Me.cmb_newdept.DataTextField = dt.Columns(1).ColumnName
        Me.cmb_newdept.DataValueField = dt.Columns(0).ColumnName
        Me.cmb_newdept.DataBind()

        Dim pos As String
        pos = ""
        Dim dt33 As DataTable = oh.ExecuteDataSet("select count(emp_code) from employee_master where branch_id=" & Me.cmb_newbranch.SelectedValue & " and post_id in (17,18,12,15,101,10,11,14,13,16,149,146,148,90) and status_id=1").Tables(0)
        If (dt33.Rows.Count >= 1 And dt33.Rows(0)(0) > 3) Then
            Dim dt34 As DataTable = oh.ExecuteDataSet("select post_id from employee_master where branch_id=" & Me.cmb_newbranch.SelectedValue & " and post_id in (17,18,12,15,101,10,11,14,13,16,149,146,148,90) and status_id=1 ").Tables(0)
            Dim dr As DataRow
            If (dt33.Rows(0)(0) = 0 And dt34.Rows.Count = 0) Then
                sql = "select post_name,post_id||'*'||post_name from post_mst  order by post_name"
            Else

                If (dt34.Rows.Count = 1 And Not IsDBNull(dt34.Rows(0)(0))) Then
                    sql = "select post_name,post_id from post_mst where post_id not in (" & dt34.Rows(0)(0) & ") order by post_name"
                Else

                    For Each dr In dt34.Rows
                        '  pos = dr(0)
                        If pos = "" Then
                            pos = dr(0)
                        Else
                            pos = pos & "," & dr(0)
                        End If

                    Next


                    sql = "select post_name,post_id from post_mst where post_id not in (" & pos & ") order by post_name"


                End If
            End If

        Else
            sql = "select post_name,post_id from post_mst  order by post_name"
        End If
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Me.cmb_newpost.DataSource = dt
            Me.cmb_newpost.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_newpost.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_newpost.DataBind()
        End If

        sql7 = "select post_name,post_id from post_mst where post_id not in (100,183,191,37,38,39,40,41,42,44,43,45,46,47,48,49,50,51,53,95,119,186,189,193,190,174,168,55,130,56,118,54,109,110,96,116,122,151,143) order by post_name"
        dt7 = oh.ExecuteDataSet(sql7).Tables(0)
        Me.cmb_report_person.DataSource = dt7
        Me.cmb_report_person.DataTextField = dt7.Columns(0).ColumnName
        Me.cmb_report_person.DataValueField = dt7.Columns(1).ColumnName
        Me.cmb_report_person.DataBind()



    End Sub
    Protected Sub cmb_state_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sql23, sql24 As String
        Dim dthh As DataTable = oh.ExecuteDataSet("select nvl(h.hostel,0) from hrm_proposal_order h where h.emp_code= " & Me.cmb_select.Text & " and h.status=1 ").Tables(0)
        Dim hoste As String
        If dthh.Rows.Count = 0 Then
            Me.cathos.Visible = True
            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select 'Hostel Not Required',0 as flat_no,'AAB' as area_name from dual union select t.flat_name||'('||b.area_name||')',t.flat_no,b.area_name from tbl_rent_building_mst t,branch b where b.BRANCH_ID=t.branch_id and t.rent_category_id=" & Me.cmb_cat.SelectedValue & " and b.STATE_ID=" & Me.cmb_state.SelectedValue & " and t.status_id=1 order by area_name "
        Else
            Me.cathos.Visible = False
            hoste = dthh.Rows(0)(0)
            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select ' No Hostel',0 as flat_no,'AAB' as area_name from dual union select t.flat_name|| '(' || b.area_name || ')',t.flat_no,b.area_name from tbl_rent_building_mst t ,hrm_proposal_order d,branch b where  d.emp_code=" & Me.cmb_select.Text & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1 and t.branch_id=b.branch_id order by area_name"
        End If
        dt23 = oh.ExecuteDataSet(sql23).Tables(0)
        Me.cmb_hostel.DataSource = dt23
        Me.cmb_hostel.DataTextField = dt23.Columns(0).ColumnName
        Me.cmb_hostel.DataValueField = dt23.Columns(1).ColumnName
        Me.cmb_hostel.DataBind()
        sql24 = "select count(t.flat_no),nvl(v.capacity,0) from tbl_rent_building_mst t left outer join tbl_rent_building_mst v  on (v.flat_no=t.flat_no and v.status_id=1) where t.flat_no=" & Me.cmb_hostel.SelectedValue & " and t.status_id=1 group by  t.flat_no,v.capacity"
        dt24 = oh.ExecuteDataSet(sql24).Tables(0)
        If dt24.Rows.Count = 0 Then
            Me.pcap.Text = 0
            Me.totcap.Text = 0
        Else
            Me.pcap.Text = dt24.Rows(0)(0)
            Me.totcap.Text = dt24.Rows(0)(1)
        End If
    End Sub

    Function BH_BM_ABH_CHECK(ByVal empcode As Double, ByVal postid As Double, ByVal flatno As Double, ByVal branchid As Double, ByVal emp_branch As Double) As Integer

        Dim sql As String
        Dim result As Double
        Dim dt As New DataTable
        sql = "select t.flat_no, t.emp_code, e.branch_id, e.post_id, p.post_name,e.branch_id  from tbl_rent_hostel t, employee_master e, post_mst p where t.flat_no = " & flatno & "  and t.status = 1  and e.emp_code = t.emp_code  and p.post_id = e.post_id"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Select Case postid
                Case 1
                    If dt.Rows(0)(0) = flatno Then
                        If dt.Rows(0)(5) = emp_branch Then
                            result = 1
                        Else
                            result = 0
                        End If

                    End If
                Case 10
                    If dt.Rows(0)(0) = flatno Then
                        If dt.Rows(0)(5) = emp_branch Then
                            result = 1
                        Else
                            result = 0
                        End If
                    End If
                Case 198
                    If dt.Rows(0)(0) = flatno Then
                        If dt.Rows(0)(5) = emp_branch Then
                            result = 1
                        Else
                            result = 0
                        End If
                    End If
                Case Else
                    result = 0

            End Select
        End If
        Return result
    End Function


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click

        ' By Harikrishnan M.
        ' START Checking for Hostel
        '-------------------------
        Dim sql1emp, sql2emp As String
        Dim dt1emp, dt2emp As New DataTable

        dt1 = oh.ExecuteDataSet("select count(emp_code) from employee_exception  where emp_code='" & Me.cmb_select.Text & "' and status_id=1").Tables(0)

        If Me.cmb_hostel.SelectedValue <> -1 And Me.cmb_hostel.SelectedValue <> 0 Then

            sql1emp = "select t.sex ,e.post_id,e.emp_code,e.branch_id from employ_personal_dtl t,emp_master e where t.emp_code=e.emp_code and  t.emp_code=" & Me.cmb_select.Text & ""
            dt1emp = oh.ExecuteDataSet(sql1emp).Tables(0)
            sql2emp = "select t.rent_category_id,t.branch_id,t.flat_no from tbl_rent_building_mst t where t.flat_no=" & Me.cmb_hostel.SelectedValue & ""
            dt2emp = oh.ExecuteDataSet(sql2emp).Tables(0)

            If dt1emp.Rows(0)(0) = 0 And dt2emp.Rows(0)(0) <> 6 Then
                Me.lbl_msg.Text = "You Cannot Select Other Hostels For Ladies .. SELECT LADIES FLAT ONLY !"
                clear()
                clr()
                Exit Sub
            ElseIf dt1emp.Rows(0)(0) = 1 And dt2emp.Rows(0)(0) = 6 Then
                Me.lbl_msg.Text = "You Cannot Select LADIES Hostels For GENTS .. SELECT OTHER FLAT !"
                clear()
                clr()
                Exit Sub
            End If
            'NEW CODE' BH_BM_ABH_CHECK(dt1.Rows(0)(2), dt1.Rows(0)(1), dt2.Rows(0)(2), dt2.Rows(0)(1), dt1.Rows(0)(3))
            If BH_BM_ABH_CHECK(dt1emp.Rows(0)(2), dt1emp.Rows(0)(1), dt2emp.Rows(0)(2), dt2emp.Rows(0)(1), dt1emp.Rows(0)(3)) = 1 Then
                ' FOR JOIN CUSTODIANS
                Me.lbl_msg.Text = "You Cannot Select same Hostel for JOINT Custodians,Choose Another One!"
                clear()
                clr()
                Exit Sub
            End If
        End If

        ' END Checking for Hostel
        '-------------------------


        If (dt1.Rows(0)(0) >= 1) Then
            Me.lbl_msg.Text = "SELECTED EMPLOYEE IS NOT ELIGIBLE FOR TRANSFER !"
            clear()
            clr()
        Else

            If (Me.txt_tfrjoiningdate.Text = "" Or Me.txt_releivingdate.Text = "" Or Me.txt_reportingdate.Text = "") Then
                Dim msgbx1 As New System.Text.StringBuilder
                msgbx1.Append("         alert(' Complete All Entries ');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx1.ToString, True)
            Else
                Dim sql As String = "select count(*) from employ_transfer_dtl where emp_code='" & Me.cmb_select.Text & "' and to_dt is null and status_id<>1 and enter_dt=to_date(sysdate) and branch_id='" & Me.cmb_newbranch.SelectedValue & "'"
                dt2 = oh.ExecuteDataSet(sql).Tables(0)
                If (dt2.Rows(0)(0) >= 2) Then
                    Me.lbl_msg.Text = " This Employee is already Transfered today!"
                    clr()
                    clear()
                Else
                    'If (Me.txt_currentbranch.Text = Me.cmb_newbranch.SelectedItem.Text) Then
                    '    Dim msgbx As New System.Text.StringBuilder
                    '    msgbx.Append("         alert(' Check the branch for transfer ');")
                    '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                    'Else

                    If (Me.Txt_dis.Text = "" Or Me.Txt_dis.Text = "0" Or Me.Txt_dis.Text = "00" Or Me.Txt_dis.Text = "000" Or Me.Txt_dis.Text = "0000" Or Me.Txt_dis.Text = "00000") Then
                        Dim msgbx As New System.Text.StringBuilder
                        msgbx.Append("         alert(' Enter the distance between home and branch in kilometer');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                        Exit Sub
                    Else


                        sql3 = "select nvl(deputation_id,0) from employ_transfer_dtl where to_dt is null and emp_code='" & Me.cmb_select.Text & "'"
                        dt4 = oh.ExecuteDataSet(sql3).Tables(0)
                        Dim def As String
                        If (dt4.Rows.Count <= 0) Then
                            def = 0
                        Else
                            def = dt4.Rows(0)(0)
                        End If
                        Dim sf() As String

                        sf = Session("user_id").ToString.Split("!")
                        Dim sql2 As String = "update employ_transfer_dtl set enter_by=" & sf(0) & " where emp_code='" & Me.cmb_select.Text & "' and to_dt is null"
                        oh.ExecuteNonQuery(sql2)
                        Dim detail, curr_det, firm As String
                        sql2 = "select firm_id from employee_master where emp_code='" & Me.cmb_select.Text & "'"
                        dt3 = oh.ExecuteDataSet(sql2).Tables(0)
                        Dim crf As String = dt3.Rows(0)(0)
                        firm = crf + "|" + def
                        Dim fir As String
                      
                        fir = Session("firm_id")

                        detail = Me.cmb_newbranch.SelectedValue + "|" + Me.cmb_select.Text + "|" + Me.txt_tfrjoiningdate.Text + "|" + Me.txt_releivingdate.Text + "|" + Me.txt_reportingdate.Text + "|" + Me.cmb_newdept.SelectedValue + "|" + Me.cmb_newpost.SelectedValue + "|" + fir + "|" + Me.cmb_report_person.SelectedValue
                        curr_det = Me.txt_name.Text + "|" + Me.txt_desig.Text + "|" + Me.txt_currentPost.Text + "|" + Me.txt_currentdept.Text + "|" + Me.txt_currentbranch.Text + "|" + Me.txt_joiningdate.Text + "|" + Me.Txt_firm.Text

                        Dim dist As String = Me.Txt_dis.Text + "|" + Me.cmb_hostel.SelectedValue
                        Dim parameter(2) As OracleParameter
                        parameter(0) = New OracleParameter("details", OracleType.VarChar, 150)
                        parameter(0).Direction = ParameterDirection.Input
                        parameter(0).Value = detail
                        parameter(1) = New OracleParameter("dist", OracleType.VarChar, 150)
                        parameter(1).Direction = ParameterDirection.Input
                        parameter(1).Value = dist
                        parameter(2) = New OracleParameter("tfr_number", OracleType.VarChar, 150)
                        parameter(2).Direction = ParameterDirection.Output

                        oh.ExecuteNonQuery("EMPlOY_TRANSFER", parameter)

                        If (parameter(2).Value = "Proposed Branch Has Same State Employee" Or parameter(2).Value = "Transfer Is Not Possible,User not Authorised" Or parameter(2).Value = "Same State Transfer Is Not Allowed In The Case Of Jr.Asst (T-NG)" Or parameter(2).Value = "This Branch Is Not Having 4 Crore Bussiness For transfering Jr-Officer & Above") Then
                            If (parameter(2).Value = "Proposed Branch Has Same State Employee") Then
                                Me.lbl_msg.Text = parameter(2).Value

                                Exit Sub
                            End If
                            If (parameter(2).Value = "Transfer Is Not Possible,User not Authorised") Then

                                Me.lbl_msg.Text = parameter(2).Value
                                Exit Sub
                            End If

                            If (parameter(2).Value = "This Branch Is Not Having 4 Crore Bussiness For transfering Jr-Officer & Above") Then

                                Me.lbl_msg.Text = parameter(2).Value
                                Exit Sub
                            End If
                            If (parameter(2).Value = "Same State Transfer Is Not Allowed In The Case Of Jr.Asst (T-NG)") Then

                                Me.lbl_msg.Text = parameter(2).Value
                                Exit Sub
                            End If
                        Else
                            Me.txt_tfrjoiningdate.Text = ""
                            Me.txt_releivingdate.Text = ""
                            Me.txt_reportingdate.Text = ""
                            clear()
                            init_fill()
                            Me.lbl_date.Text = ""
                            Dim cl_script1 As New System.Text.StringBuilder
                            cl_script1.Append("  alert('TRANSFER CONFIRMED SUCCESSFULLY!!!!');")
                            cl_script1.Append("window.open('Payroll_Transfer.aspx?dtl=" & detail & "&no=" & parameter(2).Value & "&cr_dt=" & curr_det & "&frm=" & firm & "&dis=" & dist & "');")
                            cl_script1.Append("window.open('emp_transfer.aspx','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                        End If
                    End If
                End If
            End If
        End If

    End Sub
    Sub clr()
        Me.txt_tfrjoiningdate.Text = ""
        Me.txt_releivingdate.Text = ""
        Me.txt_reportingdate.Text = ""
    End Sub
    Protected Sub txt_releivingdate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_releivingdate.TextChanged
        Me.lbl_date.Text = ""
        If (Me.txt_releivingdate.Text = "") Then

        Else

            Dim dt22 As DataTable
            dt22 = oh.ExecuteDataSet("select to_date(from_dt) from employ_transfer_dtl where to_dt is null and emp_code=" & Me.cmb_select.Text & " and status_id<>1").Tables(0)
            If (dt22.Rows.Count = 0) Then
            Else

                If (dt22.Rows(0)(0) <= Me.txt_releivingdate.Text) Then

                Else
                    Me.txt_releivingdate.Text = ""
                    Me.lbl_date.Text = "Releiving Date Is Greater than Last Joining Date "
                    Exit Sub
                End If
            End If
        End If
        Dim dt45 As DataTable = oh.ExecuteDataSet("select to_date(sysdate+get_parameter(33,29,1)) from dual").Tables(0)
        If (CDate(Me.txt_releivingdate.Text) >= CDate(dt45.Rows(0)(0))) Then
            Me.txt_releivingdate.Text = ""
            Me.lbl_date.Text = "Releiving Date Is Limted Upto 15 Days From Here"
            Exit Sub
        End If

        Dim dt46 As DataTable = oh.ExecuteDataSet("select to_date(sysdate-get_parameter(33,29,1)) from dual").Tables(0)
        If (CDate(Me.txt_releivingdate.Text) <= CDate(dt46.Rows(0)(0))) Then
            Me.txt_releivingdate.Text = ""
            Me.lbl_date.Text = "Releiving Date Is Limted Upto 15 Days Back Date"
            Exit Sub
        End If
    End Sub

    Protected Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_tfrjoiningdate.TextChanged
        Me.lbl_date.Text = ""
        Dim dt45 As DataTable = oh.ExecuteDataSet("select to_date(sysdate+get_parameter(33,29,1)+1) from dual").Tables(0)
        If (CDate(Me.txt_tfrjoiningdate.Text) >= CDate(dt45.Rows(0)(0))) Then
            Me.txt_tfrjoiningdate.Text = ""
            Me.lbl_date.Text = "Joining Date Is Limted Upto 16 Days From Here"
            Exit Sub
        End If
        Dim dt46 As DataTable = oh.ExecuteDataSet("select to_date(sysdate-get_parameter(33,29,1)+1) from dual").Tables(0)
        If (CDate(Me.txt_tfrjoiningdate.Text) <= CDate(dt46.Rows(0)(0))) Then
            Me.txt_tfrjoiningdate.Text = ""
            Me.lbl_date.Text = "Joining Date Is Limted Upto 14 Days Back Date"
            Exit Sub
        End If
        If (Me.txt_releivingdate.Text = "") Then
            Dim msgbx2 As New System.Text.StringBuilder
            msgbx2.Append("         alert('First Enter Releiving Date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx2.ToString, True)
            Me.txt_tfrjoiningdate.Text = ""
            Me.lbl_date.Text = "First Enter Releiving Date"
            Exit Sub
        Else
            Dim sql As String
            Dim dt1 As New DataTable
            sql = "select from_dt from employ_transfer_dtl where to_dt is null and  emp_code=" & Me.cmb_select.Text
            dt1 = oh.ExecuteDataSet(sql).Tables(0)
            Dim a As Integer
            Dim dat, dt, dts, rdt, rpdt As Date
            dat = Me.txt_tfrjoiningdate.Text
            rdt = Me.txt_releivingdate.Text
            a = DateDiff(DateInterval.DayOfYear, dt1.Rows(0)(0), dat)
            If CDate(dt1.Rows(0)(0)) > CDate(dat) Then

                Dim msgbx3 As New System.Text.StringBuilder
                msgbx3.Append("         alert('Check the Joining Date **** Last Joining date is " & dt1.Rows(0)(0) & "');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx3.ToString, True)
                Me.txt_tfrjoiningdate.Text = ""
                Me.lbl_date.Text = "Check the Joining Date **** Last Joining date is " & dt1.Rows(0)(0) & ""
                Exit Sub
            End If
            If CDate(rdt) > CDate(dat) Then
                Me.txt_tfrjoiningdate.Text = ""

                Dim msgbx4 As New System.Text.StringBuilder
                msgbx4.Append("         alert('Check the Joining Date');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx4.ToString, True)
                Me.lbl_date.Text = "Check the Joining Date"
                Exit Sub
            End If
            If Me.txt_reportingdate.Text = "" Then
            Else
                rpdt = Me.txt_reportingdate.Text
                If CDate(dat) < CDate(rpdt) Then
                    Me.lbl_date.Text = "joining date sholud be greater or equal to reporting date"
                    Exit Sub
                End If

            End If

        End If
    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Dim script1 As New System.Text.StringBuilder
        script1.Append("window.open('../../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
    End Sub

    Protected Sub txt_reportingdate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.lbl_date.Text = ""
        Dim rpdt, rdt, jdt As Date
        rpdt = Me.txt_reportingdate.Text
        jdt = Me.txt_releivingdate.Text
        Dim dt45 As DataTable = oh.ExecuteDataSet("select to_date(sysdate+get_parameter(33,29,1)+1) from dual").Tables(0)
        If (CDate(Me.txt_reportingdate.Text) >= CDate(dt45.Rows(0)(0))) Then
            Me.txt_reportingdate.Text = ""
            Me.lbl_date.Text = "Reporting Date Is Limted Upto 16 Days From Here"
            Exit Sub
        End If
        Dim dt46 As DataTable = oh.ExecuteDataSet("select to_date(sysdate-get_parameter(33,29,1)+1) from dual").Tables(0)
        If (CDate(Me.txt_reportingdate.Text) <= CDate(dt46.Rows(0)(0))) Then
            Me.txt_reportingdate.Text = ""
            Me.lbl_date.Text = "Reporting Date Is Limted Upto 14 Days Back Date"
            Exit Sub
        End If
        If CDate(jdt) > CDate(rpdt) Then
            Me.lbl_date.Text = "Report date sholud be greater than releiving date"
            Exit Sub
        End If
        If Me.txt_tfrjoiningdate.Text = "" Then
            Me.lbl_date.Text = "select the join date "
        Else
            rdt = Me.txt_tfrjoiningdate.Text
            If CDate(rpdt) > CDate(rdt) Then
                Me.lbl_date.Text = "joining date sholud be greater or equal reporting date"
                Exit Sub
            End If
        End If
        If (Me.txt_reportingdate.Text = "") Then
            Me.txt_reportingdate.Text = ""
            Exit Sub

        End If
    End Sub

    Protected Sub cmd_clear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_clear.Click
        Server.Transfer("emp_transfer.aspx")
    End Sub


    Protected Sub cmd_vewrepo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_vewrepo.Click

        dt1 = oh.ExecuteDataSet("select count(emp_code) from employee_exception  where emp_code='" & Me.cmb_select.Text & "' and status_id=1").Tables(0)

        If (dt1.Rows(0)(0) >= 1) Then
            Me.lbl_msg.Text = "SELECTED EMPLOYEE IS NOT ELIGIBLE FOR TRANSFER !"
            clear()
            clr()
        Else

            If (Me.txt_tfrjoiningdate.Text = "" Or Me.txt_releivingdate.Text = "" Or Me.txt_reportingdate.Text = "") Then
                Dim msgbx5 As New System.Text.StringBuilder
                msgbx5.Append("         alert(' Complete All Entries ');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx5.ToString, True)
            Else
                Dim sql As String = "select count(*) from employ_transfer_dtl where emp_code='" & Me.cmb_select.Text & "' and status_id<>1 and to_dt is null and enter_dt=to_date(sysdate) and branch_id='" & Me.cmb_newbranch.SelectedValue & "'"
                dt2 = oh.ExecuteDataSet(sql).Tables(0)
                If (dt2.Rows(0)(0) = 1) Then
                    Me.lbl_msg.Text = " This Employee is already Transfered today!"
                    clr()
                    clear()
                Else
                    If (Me.Txt_dis.Text = "" Or Me.Txt_dis.Text = "0" Or Me.Txt_dis.Text = "00" Or Me.Txt_dis.Text = "000" Or Me.Txt_dis.Text = "0000" Or Me.Txt_dis.Text = "00000") Then
                        Dim msgbx As New System.Text.StringBuilder
                        msgbx.Append("         alert(' Enter the distance between home and branch in kilometer');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                        Exit Sub
                    Else
                        sql3 = "select nvl(deputation_id,0) from employ_transfer_dtl where to_dt is null and emp_code='" & Me.cmb_select.Text & "'"
                        dt4 = oh.ExecuteDataSet(sql3).Tables(0)
                        Dim def As String
                        If (dt4.Rows.Count <= 0) Then
                            def = 0
                        Else
                            def = dt4.Rows(0)(0)
                        End If



                        Dim detail, curr_det, firm As String
                        sql2 = "select firm_id from employee_master where emp_code='" & Me.cmb_select.Text & "'"
                        dt3 = oh.ExecuteDataSet(sql2).Tables(0)
                        Dim crf As String = dt3.Rows(0)(0)
                        firm = crf + "|" + def
                        Dim fir As String
                        fir = Session("firm_id")

                        detail = Me.cmb_newbranch.SelectedValue + "|" + Me.cmb_select.Text + "|" + Me.txt_tfrjoiningdate.Text + "|" + Me.txt_releivingdate.Text + "|" + Me.txt_reportingdate.Text + "|" + Me.cmb_newdept.SelectedValue + "|" + Me.cmb_newpost.SelectedValue + "|" + fir + "|" + Me.cmb_report_person.SelectedValue
                        curr_det = Me.txt_name.Text + "|" + Me.txt_desig.Text + "|" + Me.txt_currentPost.Text + "|" + Me.txt_currentdept.Text + "|" + Me.txt_currentbranch.Text + "|" + Me.txt_joiningdate.Text + "|" + Me.Txt_firm.Text


                        Dim parameter(1) As OracleParameter
                        parameter(0) = New OracleParameter("details", OracleType.VarChar, 150)
                        parameter(0).Direction = ParameterDirection.Input
                        parameter(0).Value = detail
                        parameter(1) = New OracleParameter("tfr_number", OracleType.VarChar, 150)
                        parameter(1).Direction = ParameterDirection.Output
                        oh.ExecuteNonQuery("EMPlO_TRANSFER", parameter)


                        Dim cl_script1 As New System.Text.StringBuilder
                        cl_script1.Append("        alert('Verify Your Report');")
                        cl_script1.Append("window.open('tran_repo.aspx?dtl=" & detail & "&no=" & parameter(1).Value & "&cr_dt=" & curr_det & "&frm=" & firm & "');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    End If
                End If
            End If
        End If

        'End If

    End Sub

    Protected Sub cmb_newbranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_newbranch.SelectedIndexChanged
        Dim pos As String
        pos = ""
        Dim dt33 As DataTable = oh.ExecuteDataSet("select count(emp_code) from employee_master where branch_id=" & Me.cmb_newbranch.SelectedValue & " and post_id in (17,18,12,15,101,10,11,14,13,16,149,146,148,90) and status_id=1").Tables(0)
        If (dt33.Rows.Count >= 1 And dt33.Rows(0)(0) > 3) Then
            Dim dt34 As DataTable = oh.ExecuteDataSet("select post_id from employee_master where branch_id=" & Me.cmb_newbranch.SelectedValue & " and post_id in (17,18,12,15,101,10,11,14,13,16,149,146,148,90) and status_id=1 ").Tables(0)
            Dim dr As DataRow
            If (dt33.Rows(0)(0) = 0 And dt34.Rows.Count = 0) Then
                sql = "select post_name,post_id||'*'||post_name from post_mst  order by POST_NAME"
            Else

                If (dt34.Rows.Count = 1 And Not IsDBNull(dt34.Rows(0)(0))) Then
                    sql = "select post_name,post_id||'*'||post_name from post_mst where post_id not in (" & dt34.Rows(0)(0) & ") order by POST_NAME"
                Else

                    For Each dr In dt34.Rows
                        '  pos = dr(0)
                        If pos = "" Then
                            pos = dr(0)
                        Else
                            pos = pos & "," & dr(0)
                        End If

                    Next


                    sql = "select post_name,post_id||'*'||post_name from post_mst where post_id not in (" & pos & ") order by POST_NAME"


                End If
            End If
        Else
            sql = "select post_name,post_id||'*'||post_name from post_mst p order by p.post_name"
        End If
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Me.cmb_newpost.DataSource = dt
            Me.cmb_newpost.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_newpost.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_newpost.DataBind()
        End If

        Dim sql22, sql23, sql24 As String
        sql22 = "select s.state_name,s.state_id from state_master s,branch b where b.branch_id=" & Me.cmb_newbranch.SelectedValue & " and b.state_id=s.state_id order by s.state_name "
        dt22 = oh.ExecuteDataSet(sql22).Tables(0)
        Me.cmb_state.DataSource = dt22
        Me.cmb_state.DataTextField = dt22.Columns(0).ColumnName
        Me.cmb_state.DataValueField = dt22.Columns(1).ColumnName
        Me.cmb_state.DataBind()
        Dim dthh As DataTable = oh.ExecuteDataSet("select nvl(h.hostel,0) from hrm_proposal_order h where h.emp_code= " & Me.cmb_select.Text & " and h.status=1 ").Tables(0)
        Dim hoste As String
        If dthh.Rows.Count = 0 Then
            Me.cathos.Visible = True
            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select 'Hostel Not Required',0 as flat_no,'AAB' as area_name from dual union select t.flat_name||'('||b.area_name||')',t.flat_no,b.area_name from tbl_rent_building_mst t,branch b where b.BRANCH_ID=t.branch_id and t.rent_category_id=" & Me.cmb_cat.SelectedValue & " and b.STATE_ID=" & Me.cmb_state.SelectedValue & " and t.status_id=1 order by area_name "
        Else
            Me.cathos.Visible = False
            hoste = dthh.Rows(0)(0)
            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select ' No Hostel',0 as flat_no,'AAB' as area_name from dual union select t.flat_name|| '(' || b.area_name || ')',t.flat_no,b.area_name from tbl_rent_building_mst t ,hrm_proposal_order d,branch b where  d.emp_code=" & Me.cmb_select.Text & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1 and t.branch_id=b.branch_id order by area_name"
        End If
        '  sql23 = "select ' Select Hostel',-1 as flat_no from dual union select ' No Hostel',0 as flat_no from dual union select t.flat_name,t.flat_no from tbl_rent_building_mst t ,hrm_proposal_order d where  d.emp_code=" & Me.cmb_select.Text & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1  order by flat_no"
        dt23 = oh.ExecuteDataSet(sql23).Tables(0)
        Me.cmb_hostel.DataSource = dt23
        Me.cmb_hostel.DataTextField = dt23.Columns(0).ColumnName
        Me.cmb_hostel.DataValueField = dt23.Columns(1).ColumnName
        Me.cmb_hostel.DataBind()
        sql24 = "select count(t.flat_no),nvl(v.capacity,0) from tbl_rent_building_mst t left outer join tbl_rent_building_mst v  on (v.flat_no=t.flat_no and v.status_id=1) where t.flat_no=" & Me.cmb_hostel.SelectedValue & " and t.status_id=1 group by  t.flat_no,v.capacity"
        dt24 = oh.ExecuteDataSet(sql24).Tables(0)
        If dt24.Rows.Count = 0 Then
            Me.pcap.Text = 0
            Me.totcap.Text = 0
        Else
            Me.pcap.Text = dt24.Rows(0)(0)
            Me.totcap.Text = dt24.Rows(0)(1)
        End If
    End Sub


    Protected Sub cmb_hostel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sql24 As String = "select count(t.flat_no),nvl(v.capacity,0) from tbl_rent_building_mst t left outer join tbl_rent_building_mst v  on (v.flat_no=t.flat_no and v.status_id=1) where t.flat_no=" & Me.cmb_hostel.SelectedValue & " and t.status_id=1 group by  t.flat_no,v.capacity"
        dt24 = oh.ExecuteDataSet(sql24).Tables(0)
        If dt24.Rows.Count = 0 Then
            Me.pcap.Text = 0
            Me.totcap.Text = 0
        Else
            Me.pcap.Text = dt24.Rows(0)(0)
            Me.totcap.Text = dt24.Rows(0)(1)
        End If
    End Sub

    Protected Sub cmb_cat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sql22, sql23, sql24, sql25 As String

        sql22 = "select s.state_name,s.state_id from state_master s,branch b where b.branch_id=" & Me.cmb_newbranch.SelectedValue & " and b.state_id=s.state_id order by s.state_name "
        dt22 = oh.ExecuteDataSet(sql22).Tables(0)
        Me.cmb_state.DataSource = dt22
        Me.cmb_state.DataTextField = dt22.Columns(0).ColumnName
        Me.cmb_state.DataValueField = dt22.Columns(1).ColumnName
        Me.cmb_state.DataBind()
        Dim dthh As DataTable = oh.ExecuteDataSet("select nvl(h.hostel,0) from hrm_proposal_order h where h.emp_code= " & Me.cmb_select.Text & " and h.status=1 ").Tables(0)
        Dim hoste As String
        If dthh.Rows.Count = 0 Then
            Me.cathos.Visible = True
            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select 'Hostel Not Required',0 as flat_no,'AAB' as area_name  from dual union select t.flat_name||'('||b.area_name||')',t.flat_no,b.area_name from tbl_rent_building_mst t,branch b where b.BRANCH_ID=t.branch_id and t.rent_category_id=" & Me.cmb_cat.SelectedValue & " and b.STATE_ID=" & Me.cmb_state.SelectedValue & " and t.status_id=1 order by area_name "
        Else
            Me.cathos.Visible = False
            hoste = dthh.Rows(0)(0)
            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select ' No Hostel',0 as flat_no,'AAB' as area_name from dual union select t.flat_name|| '(' || b.area_name || ')',t.flat_no,b.area_name from tbl_rent_building_mst t ,hrm_proposal_order d,branch b where  d.emp_code=" & Me.cmb_select.Text & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1 and t.branch_id=b.branch_id order by area_name"
        End If


        'sql23 = "select ' Select Hostel',-1 as flat_no from dual union select ' No Hostel',0 as flat_no from dual union select t.flat_name,t.flat_no from tbl_rent_building_mst t ,hrm_proposal_order d where  d.emp_code=" & Me.cmb_select.Text & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1  order by flat_no"
        dt23 = oh.ExecuteDataSet(sql23).Tables(0)
        Me.cmb_hostel.DataSource = dt23
        Me.cmb_hostel.DataTextField = dt23.Columns(0).ColumnName
        Me.cmb_hostel.DataValueField = dt23.Columns(1).ColumnName
        Me.cmb_hostel.DataBind()
        sql24 = "select count(t.flat_no),nvl(v.capacity,0) from tbl_rent_building_mst t left outer join tbl_rent_building_mst v  on (v.flat_no=t.flat_no and v.status_id=1) where t.flat_no=" & Me.cmb_hostel.SelectedValue & " and t.status_id=1 group by  t.flat_no,v.capacity"
        dt24 = oh.ExecuteDataSet(sql24).Tables(0)
        If dt24.Rows.Count = 0 Then
            Me.pcap.Text = 0
            Me.totcap.Text = 0
        Else
            Me.pcap.Text = dt24.Rows(0)(0)
            Me.totcap.Text = dt24.Rows(0)(1)
        End If
    End Sub
    Protected Sub cmb_select_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_select.TextChanged
        clr()
        Me.lbl_date.Text = ""
        Me.lbl_msg.Text = ""
        dt1 = oh.ExecuteDataSet("select status_id from employee_exception  where emp_code='" & Me.cmb_select.Text & "'").Tables(0)
        If (dt1.Rows.Count <= 0) Then
            emp_select()
            clr()
            Dim sql22, sql23, sql24 As String
            sql22 = "select s.state_name,s.state_id from state_master s,branch b where b.branch_id=" & Me.cmb_newbranch.SelectedValue & " and b.state_id=s.state_id order by s.state_name "
            dt22 = oh.ExecuteDataSet(sql22).Tables(0)
            Me.cmb_state.DataSource = dt22
            Me.cmb_state.DataTextField = dt22.Columns(0).ColumnName
            Me.cmb_state.DataValueField = dt22.Columns(1).ColumnName
            Me.cmb_state.DataBind()
            Dim dthh As DataTable = oh.ExecuteDataSet("select nvl(h.hostel,0) from hrm_proposal_order h where h.emp_code= " & Me.cmb_select.Text & " and h.status=1 ").Tables(0)
            Dim hoste As String
            If dthh.Rows.Count = 0 Then
                Me.cathos.Visible = True
                sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select 'Hostel Not Required',0 as flat_no,'AAB' as area_name from dual union select t.flat_name||'('||b.area_name||')',t.flat_no,b.area_name from tbl_rent_building_mst t,branch b where b.BRANCH_ID=t.branch_id and t.rent_category_id=" & Me.cmb_cat.SelectedValue & " and b.STATE_ID=" & Me.cmb_state.SelectedValue & " and t.status_id=1 order by area_name "
            Else
                Me.cathos.Visible = False
                hoste = dthh.Rows(0)(0)
                sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select ' No Hostel',0 as flat_no,'AAB' as area_name from dual union select t.flat_name|| '(' || b.area_name || ')',t.flat_no,b.area_name from tbl_rent_building_mst t ,hrm_proposal_order d,branch b where  d.emp_code=" & Me.cmb_select.Text & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1 and t.branch_id=b.branch_id order by area_name"
            End If
            'sql23 = "select ' Select Hostel',-1 as flat_no from dual union select ' No Hostel',0 as flat_no from dual union select t.flat_name,t.flat_no from tbl_rent_building_mst t ,hrm_proposal_order d where  d.emp_code=" & Me.cmb_select.Text & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1  order by flat_no"
            dt23 = oh.ExecuteDataSet(sql23).Tables(0)
            Me.cmb_hostel.DataSource = dt23
            Me.cmb_hostel.DataTextField = dt23.Columns(0).ColumnName
            Me.cmb_hostel.DataValueField = dt23.Columns(1).ColumnName
            Me.cmb_hostel.DataBind()
            sql24 = "select count(t.flat_no),nvl(v.capacity,0) from tbl_rent_building_mst t left outer join tbl_rent_building_mst v  on (v.flat_no=t.flat_no and v.status_id=1) where t.flat_no=" & Me.cmb_hostel.SelectedValue & "  and t.status_id=1 group by  t.flat_no,v.capacity"
            dt24 = oh.ExecuteDataSet(sql24).Tables(0)
            If dt24.Rows.Count = 0 Then
                Me.pcap.Text = 0
                Me.totcap.Text = 0
            Else
                Me.pcap.Text = dt24.Rows(0)(0)
                Me.totcap.Text = dt24.Rows(0)(1)
            End If
        Else
            If (dt1.Rows(0)(0) = 1) Then
                clr()
                clear()
                Me.lbl_msg.Text = "SELECTED EMPLOYEE IS NOT ELIGIBLE FOR TRANSFER !"
            Else
                emp_select()
            End If
        End If
    End Sub
End Class

