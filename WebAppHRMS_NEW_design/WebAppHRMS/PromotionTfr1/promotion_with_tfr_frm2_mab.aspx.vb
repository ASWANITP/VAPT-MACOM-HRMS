Imports System.Data
Imports system.data.oracleclient
Imports System.Net.Mail
Imports System.net
Partial Class Maben_Poromotion_promotion_with_tfr_frm2_mab_cd399f072001
    Inherits System.Web.UI.Page
    Dim dt, dt5, dt22, dt23, dt24, dtv As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql, sql3, sql4, post2, tran, fm, idmail() As String
    Dim da As String
    Dim oldtdate As Date
    Dim sb As New StringBuilder
    Dim brid, empida As Integer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_dist.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        Dim emp_code As String = Request.QueryString.Get("empcode")
        If Not IsPostBack Then

            If (Me.rdbtn_no.Checked = True) Then
                Me.cmb_firm.Visible = False
            End If

            ''dt = oh.ExecuteDataSet("select a.emp_code||' -------> '||a.emp_name||'',a.emp_code||'*'||a.emp_name||'*'||a.status_id||'*'||b.branch_name||'*'||a.designation_id||'*'||c.designation||'*'||e.post_name||'*'||d.dep_name||'*'||a.join_dt||'*'||a.branch_id||'*'||a.firm_id from employee_master a,branch_master b,designation_master c,department_mst d,post_mst e  where a.branch_id=b.branch_id and a.status_id=1 and a.designation_id=c.designation_id and a.department_id=d.dep_id and a.post_id=e.post_id and a.emp_code not in (select emp_code from employee_exception where  status_id=7) and emp_code >9999  union select a.emp_code||' -------> '||a.emp_name||'',a.emp_code||'*'||a.emp_name||'*'||a.status_id||'*'||b.branch_name||'*'||a.designation_id||'*'||c.designation||'*'||e.post_name||'*'||d.dep_name||'*'||a.join_dt||'*'||a.branch_id||'*'||a.firm_id from employee_master a,branch_master b,designation_master c,department_mst d,post_mst e  where a.branch_id=b.branch_id and a.status_id=1 and a.designation_id=c.designation_id and a.department_id=d.dep_id and a.post_id=e.post_id and a.emp_code not in (select emp_code from employee_exception where  status_id=7) and a.emp_code >9999 union select a.emp_code||' -------> '||a.emp_name||'',a.emp_code||'*'||a.emp_name||'*'||a.status_id||'*'||b.branch_name||'*'||a.designation_id||'*'||c.designation||'*'||e.post_name||'*'||d.dep_name||'*'||a.join_dt||'*'||a.branch_id||'*'||a.firm_id from employee_master a,before_completion b,designation_master c,department_mst d,post_mst e  where a.branch_id=b.old_id and a.status_id=1 and a.designation_id=c.designation_id and a.department_id=d.dep_id and a.post_id=e.post_id and a.emp_code not in (select emp_code from employee_exception where  status_id=7) and a.emp_code>9999 and b.branch_id is null ").Tables(0)
            ' dt = oh.ExecuteDataSet("select '-1','---------Select Employee--------------' from dual union all select a.emp_code||' -------> '||a.emp_name||'',a.emp_code||'*'||a.emp_name||'*'||a.status_id||'*'||b.branch_name||'*'||a.designation_id||'*'||c.designation||'*'||e.post_name||'*'||d.dep_name||'*'||a.join_dt||'*'||a.branch_id||'*'||a.firm_id from employee_master a,branch_master b,designation_master c,department_mst d,post_mst e  where a.branch_id=b.branch_id and a.status_id=1 and a.designation_id=c.designation_id and a.department_id=d.dep_id and a.post_id=e.post_id and a.emp_code not in (select emp_code from employee_exception where  status_id=7) and emp_code ='" & emp_code & "'  union select a.emp_code||' -------> '||a.emp_name||'',a.emp_code||'*'||a.emp_name||'*'||a.status_id||'*'||b.branch_name||'*'||a.designation_id||'*'||c.designation||'*'||e.post_name||'*'||d.dep_name||'*'||a.join_dt||'*'||a.branch_id||'*'||a.firm_id from employee_master a,branch_master b,designation_master c,department_mst d,post_mst e  where a.branch_id=b.branch_id and a.status_id=1 and a.designation_id=c.designation_id and a.department_id=d.dep_id and a.post_id=e.post_id and a.emp_code not in (select emp_code from employee_exception where  status_id=7) and a.emp_code ='" & emp_code & "' union select a.emp_code||' -------> '||a.emp_name||'',a.emp_code||'*'||a.emp_name||'*'||a.status_id||'*'||b.branch_name||'*'||a.designation_id||'*'||c.designation||'*'||e.post_name||'*'||d.dep_name||'*'||a.join_dt||'*'||a.branch_id||'*'||a.firm_id from employee_master a,before_completion b,designation_master c,department_mst d,post_mst e  where a.branch_id=b.old_id and a.status_id=1 and a.designation_id=c.designation_id and a.department_id=d.dep_id and a.post_id=e.post_id and a.emp_code not in (select emp_code from employee_exception where  status_id=7) and a.emp_code='" & emp_code & "' and b.branch_id is null ").Tables(0)
            dt = oh.ExecuteDataSet("select a.emp_code||' -------> '||a.emp_name||'',a.emp_code||'*'||a.emp_name||'*'||a.status_id||'*'||b.branch_name||'*'||a.designation_id||'*'||c.designation||'*'||e.post_name||'*'||d.dep_name||'*'||a.join_dt||'*'||a.branch_id||'*'||a.firm_id from employee_master a,branch_master b,designation_master c,department_mst d,post_mst e  where a.branch_id=b.branch_id and a.status_id=1 and a.designation_id=c.designation_id and a.department_id=d.dep_id and a.post_id=e.post_id and a.emp_code not in (select emp_code from employee_exception where  status_id=7) and emp_code ='" & emp_code & "'  union select a.emp_code||' -------> '||a.emp_name||'',a.emp_code||'*'||a.emp_name||'*'||a.status_id||'*'||b.branch_name||'*'||a.designation_id||'*'||c.designation||'*'||e.post_name||'*'||d.dep_name||'*'||a.join_dt||'*'||a.branch_id||'*'||a.firm_id from employee_master a,branch_master b,designation_master c,department_mst d,post_mst e  where a.branch_id=b.branch_id and a.status_id=1 and a.designation_id=c.designation_id and a.department_id=d.dep_id and a.post_id=e.post_id and a.emp_code not in (select emp_code from employee_exception where  status_id=7) and a.emp_code ='" & emp_code & "' union select a.emp_code||' -------> '||a.emp_name||'',a.emp_code||'*'||a.emp_name||'*'||a.status_id||'*'||b.branch_name||'*'||a.designation_id||'*'||c.designation||'*'||e.post_name||'*'||d.dep_name||'*'||a.join_dt||'*'||a.branch_id||'*'||a.firm_id from employee_master a,before_completion b,designation_master c,department_mst d,post_mst e  where a.branch_id=b.old_id and a.status_id=1 and a.designation_id=c.designation_id and a.department_id=d.dep_id and a.post_id=e.post_id and a.emp_code not in (select emp_code from employee_exception where  status_id=7) and a.emp_code='" & emp_code & "' and b.branch_id is null ").Tables(0)
            If dt.Rows.Count > 0 Then
                Me.cmb_employee.DataSource = dt
                Me.cmb_employee.DataTextField = dt.Columns(0).ColumnName
                Me.cmb_employee.DataValueField = dt.Columns(1).ColumnName
                Me.cmb_employee.DataBind()
            End If

            Me.lbl_message.Visible = False
            fill_select()
            designation_fill()
            branch_fill()
            post_fill()
            payment_fill()
            totsal()
            department_fill()
            Me.rdbtn_no.Checked = True
            Dim arr As Array
            arr = Me.cmb_employee.SelectedValue.Split("*")
            brid = arr(9)
            empida = arr(0)
            sql3 = "select branch_id from employee_master where emp_code=" & empida & " and branch_id=" & brid & " and branch_id in (4,29,41,75,92) "
            dt = oh.ExecuteDataSet(sql3).Tables(0)
            If dt.Rows.Count > 0 Then
                If (dt.Rows(0)(0) = 4 Or dt.Rows(0)(0) = 29 Or dt.Rows(0)(0) = 41 Or dt.Rows(0)(0) = 75 Or dt.Rows(0)(0) = 92) Then
                    Me.lbl_message.Visible = True
                    Me.lbl_message.Text = "PLEASE INFORM INTO FULLERTON COMPANY!!!"
                End If
            End If
            Dim dt1 As New DataTable
            dt1 = oh.ExecuteDataSet("select a.designation||'('||a.designation_id||')',a.designation_id||'*'||a.grade_id||'*'||a.designation||'*'||a.payment_id from designation_master a order by a.designation").Tables(0)
            Me.cmb_desig.DataSource = dt1
            Me.cmb_desig.DataTextField = dt1.Columns(0).ColumnName
            Me.cmb_desig.DataValueField = dt1.Columns(1).ColumnName
            Me.cmb_desig.DataBind()
        End If
        Me.Timer1.Enabled = False
        Me.lbl_message.Text = ""
        Me.cmd_Exit.Attributes.Add("onclick", "exit()")
    End Sub
    Sub fill_select()
        Dim arr As Array
        Dim dt4, dt3 As New DataTable
        Dim sql2, firm As String
        arr = Me.cmb_employee.SelectedValue.Split("*")
        Me.txt_name.Text = arr(1)
        Me.txt_designation.Text = arr(5)
        Me.txt_postoffered.Text = arr(6)
        Me.txt_branch.Text = arr(3)
        Me.txt_department.Text = arr(7)
        sql3 = "select  nvl(deputation_id,0) from employ_transfer_dtl where from_dt in (select max(from_dt) from employ_transfer_dtl where (deputation_id not in (0) or deputation_id in (0)) and emp_code='" & arr(0) & "' and (to_date(to_dt) is not null or to_date(to_dt) is null)) and emp_code='" & arr(0) & "'  order by from_dt"
        dt4 = oh.ExecuteDataSet(sql3).Tables(0)
        sql2 = "select firm_id from employee_master where emp_code='" & arr(0) & "'"
        dt3 = oh.ExecuteDataSet(sql2).Tables(0)
        If (dt4.Rows.Count = 1 And dt4.Rows(0)(0) <> 0) Then
            Dim dt15 As DataTable
            firm = "select nvl(firm_abbr,'----') from firm_master where firm_id='" & dt4.Rows(0)(0) & "'"
            dt15 = oh.ExecuteDataSet(firm).Tables(0)
            Me.Txt_currfirm.Text = dt15.Rows(0)(0)
        Else
            If (dt4.Rows(0)(0) = 0 And IsDBNull(dt3.Rows(0)(0))) Then
                Me.Txt_currfirm.Text = "No Firm"
            Else
                Dim dt15 As DataTable
                firm = "select nvl(firm_abbr,'----') from firm_master where firm_id='" & dt3.Rows(0)(0) & "'"
                dt15 = oh.ExecuteDataSet(firm).Tables(0)
                Me.Txt_currfirm.Text = dt15.Rows(0)(0)
            End If
        End If

    End Sub
    Sub designation_fill()
        Dim sql As String
        sql = "select a.designation||'('||a.designation_id||')',a.designation_id||'*'||a.grade_id||'*'||a.designation||'*'||a.payment_id from designation_master a order by a.designation"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Me.cmb_designation.DataSource = dt
            Me.cmb_designation.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_designation.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_designation.DataBind()
        End If
    End Sub
    Sub post_fill()
        Dim pos As String
        pos = ""
        Dim dt33 As DataTable = oh.ExecuteDataSet("select count(emp_code) from employee_master where branch_id=" & Me.cmb_branch.SelectedValue & " and post_id in (17,18,12,15,101,10,11,14,13,16,149,146,148,90) and status_id=1").Tables(0)
        If (dt33.Rows.Count >= 1 And dt33.Rows(0)(0) > 3) Then
            Dim dt34 As DataTable = oh.ExecuteDataSet("select post_id from employee_master where branch_id=" & Me.cmb_branch.SelectedValue & " and post_id in (17,18,12,15,101,10,11,14,13,16,149,146,148,90) and status_id=1 ").Tables(0)
            Dim dr As DataRow
            If (dt33.Rows(0)(0) = 0 And dt34.Rows.Count = 0) Then
                sql = "select post_name,post_id||'*'||post_name from post_mst  order by post_name"
            Else

                If (dt34.Rows.Count = 1 And Not IsDBNull(dt34.Rows(0)(0))) Then
                    sql = "select post_name,post_id||'*'||post_name from post_mst where post_id not in (" & dt34.Rows(0)(0) & ") order by post_name"
                Else

                    For Each dr In dt34.Rows
                        '  pos = dr(0)
                        If pos = "" Then
                            pos = dr(0)
                        Else
                            pos = pos & "," & dr(0)
                        End If

                    Next


                    sql = "select post_name,post_id||'*'||post_name from post_mst where post_id not in (" & pos & ") order by post_name"


                End If
            End If

        Else
            sql = "select post_name,post_id||'*'||post_name from post_mst  order by post_name"
        End If
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Me.cmb_postoffered.DataSource = dt
            Me.cmb_postoffered.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_postoffered.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_postoffered.DataBind()
        End If
    End Sub
    Protected Sub cmb_cat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sql22, sql23, sql24, sql25 As String
        Dim arr As Array
        arr = Me.cmb_employee.SelectedValue.Split("*")
        sql22 = "select s.state_name,s.state_id from state_master s,branch b where b.branch_id=" & Me.cmb_branch.SelectedValue & " and b.state_id=s.state_id order by s.state_name "
        dt22 = oh.ExecuteDataSet(sql22).Tables(0)
        Me.cmb_state.DataSource = dt22
        Me.cmb_state.DataTextField = dt22.Columns(0).ColumnName
        Me.cmb_state.DataValueField = dt22.Columns(1).ColumnName
        Me.cmb_state.DataBind()
        Dim dthh As DataTable = oh.ExecuteDataSet("select nvl(h.hostel,0) from hrm_proposal_order h where h.emp_code= " & arr(0) & " and h.status=1 ").Tables(0)
        Dim hoste As String
        If dthh.Rows.Count = 0 Then
            Me.cathos.Visible = True
            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select 'Hostel Not Required',0 as flat_no,'AAB' as area_name from dual union select t.flat_name||'('||b.area_name||')',t.flat_no,b.area_name from tbl_rent_building_mst t,branch b where b.BRANCH_ID=t.branch_id and t.rent_category_id=" & Me.cmb_cat.SelectedValue & " and b.STATE_ID=" & Me.cmb_state.SelectedValue & " and t.status_id=1 order by area_name "
        Else
            Me.cathos.Visible = False
            hoste = dthh.Rows(0)(0)
            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select ' No Hostel',0 as flat_no,'AAB' as area_name from dual union select t.flat_name|| '(' || b.area_name || ')',t.flat_no,b.area_name from tbl_rent_building_mst t ,hrm_proposal_order d,branch b where  d.emp_code=" & arr(0) & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1 and t.branch_id=b.branch_id order by area_name"
        End If


        'sql23 = "select ' Select Hostel',-1 as flat_no from dual union select ' No Hostel',0 as flat_no from dual union select t.flat_name,t.flat_no from tbl_rent_building_mst t ,hrm_proposal_order d where  d.emp_code=" & Me.cmb_select.SelectedValue & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1  order by flat_no"
        dt23 = oh.ExecuteDataSet(sql23).Tables(0)
        Me.cmb_hostel.DataSource = dt23
        Me.cmb_hostel.DataTextField = dt23.Columns(0).ColumnName
        Me.cmb_hostel.DataValueField = dt23.Columns(1).ColumnName
        Me.cmb_hostel.DataBind()
        sql24 = "select count(t.flat_no),nvl(v.capacity,0) from tbl_rent_building_mst t left outer join tbl_rent_building_mst v  on (v.flat_no=t.flat_no) where t.flat_no=" & Me.cmb_hostel.SelectedValue & " group by  t.flat_no,v.capacity"
        dt24 = oh.ExecuteDataSet(sql24).Tables(0)
        If dt24.Rows.Count = 0 Then
            Me.pcap.Text = 0
            Me.totcap.Text = 0
        Else
            Me.pcap.Text = dt24.Rows(0)(0)
            Me.totcap.Text = dt24.Rows(0)(1)
        End If
    End Sub
    Sub branch_fill()
        Dim arr As Array
        arr = Me.cmb_employee.SelectedValue.Split("*")
        Dim sql As String


        '----sh
        If Session("firm_id") = 2 Then
            sql = "select branch_name, branch_id from branch_master where firm_id = " & Session("firm_id") & " union all select branch_name, branch_id from branch_master where branch_id = 0 order by branch_name"
        Else
            sql = "select branch_name, branch_id from branch_master union select branch_name,old_id from before_completion where branch_id is null order by branch_name"
        End If

        '----sh

        'sql = "select branch_name, branch_id from branch_master union select branch_name,old_id from before_completion where branch_id is null order by branch_name"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Me.cmb_branch.DataSource = dt
            Me.cmb_branch.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_branch.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_branch.DataBind()
        End If

        Dim sql22, sql23, sql24, sql25 As String
        sql25 = "select t.rent_category_id,t.rent_category_name from tbl_rent_category t where t.rent_category_id<>1"
        Dim dt25 As DataTable = oh.ExecuteDataSet(sql25).Tables(0)
        Me.cmb_cat.DataSource = dt25
        Me.cmb_cat.DataTextField = dt25.Columns(1).ColumnName
        Me.cmb_cat.DataValueField = dt25.Columns(0).ColumnName
        Me.cmb_cat.DataBind()
        sql22 = "select s.state_name,s.state_id from state_master s,branch b where b.branch_id=" & Me.cmb_branch.SelectedValue & " and b.state_id=s.state_id order by s.state_name "
        dt22 = oh.ExecuteDataSet(sql22).Tables(0)
        Me.cmb_state.DataSource = dt22
        Me.cmb_state.DataTextField = dt22.Columns(0).ColumnName
        Me.cmb_state.DataValueField = dt22.Columns(1).ColumnName
        Me.cmb_state.DataBind()
        'Dim dthh As DataTable = oh.ExecuteDataSet("select nvl(h.hostel,0) from hrm_proposal_order h where h.emp_code= " & arr(0) & " and h.status=1 ").Tables(0)
        Dim hoste As String
        Dim dthh As DataTable = oh.ExecuteDataSet("select nvl(h.hostel,0) from hrm_proposal_order h where h.emp_code= " & arr(0) & " and h.status=1 ").Tables(0)

        If dthh.Rows.Count = 0 Then
            Me.cathos.Visible = True
            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select 'Hostel Not Required',0 as flat_no,'AAB' as area_name from dual union select t.flat_name||'('||b.area_name||')',t.flat_no,b.area_name from tbl_rent_building_mst t,branch b where b.BRANCH_ID=t.branch_id and t.rent_category_id=" & Me.cmb_cat.SelectedValue & " and b.STATE_ID=" & Me.cmb_state.SelectedValue & " and t.status_id=1 order by area_name "
        Else
            Me.cathos.Visible = False
            hoste = dthh.Rows(0)(0)
            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select ' No Hostel',0 as flat_no,'AAB' as area_name from dual union select t.flat_name|| '(' || b.area_name || ')',t.flat_no,b.area_name from tbl_rent_building_mst t ,hrm_proposal_order d,branch b where  d.emp_code=" & arr(0) & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1 and t.branch_id=b.branch_id order by  area_name"
        End If
        dt23 = oh.ExecuteDataSet(sql23).Tables(0)
        Me.cmb_hostel.DataSource = dt23
        Me.cmb_hostel.DataTextField = dt23.Columns(0).ColumnName
        Me.cmb_hostel.DataValueField = dt23.Columns(1).ColumnName
        Me.cmb_hostel.DataBind()
        sql24 = "select count(t.flat_no),nvl(v.capacity,0) from tbl_rent_building_mst t left outer join tbl_rent_building_mst v  on (v.flat_no=t.flat_no) where t.flat_no=" & Me.cmb_hostel.SelectedValue & " group by  t.flat_no,v.capacity"
        dt24 = oh.ExecuteDataSet(sql24).Tables(0)
        If dt24.Rows.Count = 0 Then
            Me.pcap.Text = 0
            Me.totcap.Text = 0
        Else
            Me.pcap.Text = dt24.Rows(0)(0)
            Me.totcap.Text = dt24.Rows(0)(1)
        End If
    End Sub
    Sub department_fill()
        Dim sql As String
        sql = "select dep_name,dep_id||'*'||dep_name from department_mst order by dep_name"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Me.cmb_department.DataSource = dt
            Me.cmb_department.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_department.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_department.DataBind()
        End If
    End Sub
    Sub clear()
        Me.txt_name.Text = ""
        Me.txt_designation.Text = ""
        Me.txt_postoffered.Text = ""
        Me.txt_branch.Text = ""
        Me.txt_department.Text = ""
        Me.txt_relievedate.Text = ""
        Me.txt_joindate.Text = ""
        Me.txt_effectivedate.Text = ""
        Me.txt_totalsalary.Text = ""
        Me.Txt_currfirm.Text = ""
        Me.text_remark.Text = ""
        Me.Txt_dist.Text = ""
    End Sub
    Sub payment_fill()
        Dim arr As Array
        arr = Me.cmb_designation.SelectedValue.Split("*")
        Dim dt1, dt2, dt3 As New DataTable
        Dim sql, sql1 As String
        Dim k, j, n, a, basic, incerement, period As Integer

        sql = "select 'NOT IN THE LIST AND WANT TO ENTER..?', -1, -1 from dual union all select to_char(BASIC_PAY), INCREMENT_AMT, PERIOD from pay_scale where PAYMENT_ID = 14 order by 1 desc"

        sql1 = ("select count(*) from pay_scale where PAYMENT_ID=" & arr(3) & " order by basic_pay")
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        n = dt1.Rows(0)(0)

        dt = oh.ExecuteDataSet(sql).Tables(0)

        a = 0
        Dim tdt, tdt2 As New DataTable
        Dim tdr, tdr2 As DataRow
        Dim tdc1, tdc3, tdc4 As New DataColumn()
        Dim tdc2 As New DataColumn()
        tdt.Columns.Add(tdc1)
        tdt.Columns.Add(tdc2)

        tdt.Columns.Add(tdc3)
        tdt.Columns.Add(tdc4)
        tdr2 = tdt.NewRow
        Dim a2, b2 As String

        a2 = dt.Rows(0)(0)
        b2 = dt.Rows(0)(1)
        tdr2(0) = dt.Rows(0)(0)
        tdr2(1) = dt.Rows(0)(1)
        tdt.Rows.Add(tdr2)


        For k = 1 To n - 1
            basic = dt.Rows(k)(0)
            incerement = dt.Rows(k)(1)
            period = dt.Rows(k)(2)
            tdr = tdt.NewRow
            tdr(0) = basic
            tdr(1) = a
            tdt.Rows.Add(tdr)
            For j = 1 To period
                basic = basic + incerement
                tdr = tdt.NewRow
                a = a + 1
                tdr(0) = basic
                tdr(1) = a
                tdt.Rows.Add(tdr)
            Next
            a = a + 1
        Next


        Me.cmb_pay_amnt.DataSource = tdt
        Me.cmb_pay_amnt.DataTextField = tdt.Columns(0).ColumnName
        Me.cmb_pay_amnt.DataValueField = tdt.Columns(1).ColumnName
        Me.cmb_pay_amnt.DataBind()

    End Sub
    Sub totsal()
        Dim f As Integer = Session("firm_id")
        Dim arr As Array
        arr = Me.cmb_designation.SelectedValue.Split("*")
        Dim dt1, dt2, dt3 As New DataTable
        Dim sql2 As String
        Dim basic As Integer

        If IsNumeric(Me.cmb_pay_amnt.SelectedItem.Text) Then

            basic = Me.cmb_pay_amnt.SelectedItem.Text
            Me.txt_enter.Enabled = False
            'Me.Td1.Visible = False
            'Me.Td2.Visible = False
            Me.txt_enter.Text = 0


        Else
            Me.txt_enter.Enabled = True
            'Me.Td1.Visible = True
            'Me.Td2.Visible = True
            Me.txt_enter.Text = 0
            basic = Me.txt_enter.Text
        End If
        Me.txt_totalsalary.Text = 0
        If arr(3) <> 14 Then
            sql2 = ("select value,from_dt,to_dt,enter_dt from da_index where to_dt is null and firm_id=" & f & "")
            dt3 = oh.ExecuteDataSet(sql2).Tables(0)
            If dt3.Rows.Count > 0 Then
                da = dt3.Rows(0)(0)
                Me.txt_totalsalary.Text = basic + da
            End If
        Else
            Me.txt_totalsalary.Text = basic
        End If
    End Sub
    Protected Sub cmb_employee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_employee.SelectedIndexChanged
        fill_select()
        Dim arr As Array
        'Dim postoffer As String
        arr = Me.cmb_employee.SelectedValue.Split("*")
        brid = arr(9)
        empida = arr(0)
        Dim dthh As DataTable = oh.ExecuteDataSet("select nvl(h.hostel,0) from hrm_proposal_order h where h.emp_code= " & empida & " and h.status=1 ").Tables(0)
        Dim hoste, sql23, sql24 As String
        If dthh.Rows.Count = 0 Then
            Me.cathos.Visible = True
            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select 'Hostel Not Required',0 as flat_no,'AAB' as area_name from dual union select t.flat_name||'('||b.area_name||')',t.flat_no,b.area_name from tbl_rent_building_mst t,branch b where b.BRANCH_ID=t.branch_id and t.rent_category_id=" & Me.cmb_cat.SelectedValue & " and b.STATE_ID=" & Me.cmb_state.SelectedValue & " and t.status_id=1 order by area_name "
        Else
            Me.cathos.Visible = False
            hoste = dthh.Rows(0)(0)
            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select ' No Hostel',0 as flat_no,'AAB' as area_name from dual union select t.flat_name|| '(' || b.area_name || ')',t.flat_no,b.area_name from tbl_rent_building_mst t ,hrm_proposal_order d,branch b where  d.emp_code=" & empida & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1 and t.branch_id=b.branch_id order by area_name"
        End If
        'sql23 = "select ' Select Hostel',-1 as flat_no from dual union select ' No Hostel',0 as flat_no from dual union select t.flat_name,t.flat_no from tbl_rent_building_mst t ,hrm_proposal_order d where  d.emp_code=" & Me.cmb_select.SelectedValue & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1  order by flat_no"
        dt23 = oh.ExecuteDataSet(sql23).Tables(0)
        Me.cmb_hostel.DataSource = dt23
        Me.cmb_hostel.DataTextField = dt23.Columns(0).ColumnName
        Me.cmb_hostel.DataValueField = dt23.Columns(1).ColumnName
        Me.cmb_hostel.DataBind()
        sql24 = "select count(t.flat_no),nvl(v.capacity,0) from tbl_rent_building_mst t left outer join tbl_rent_building_mst v  on (v.flat_no=t.flat_no) where t.flat_no=" & Me.cmb_hostel.SelectedValue & " group by  t.flat_no,v.capacity"
        dt24 = oh.ExecuteDataSet(sql24).Tables(0)
        If dt24.Rows.Count = 0 Then
            Me.pcap.Text = 0
            Me.totcap.Text = 0
        Else
            Me.pcap.Text = dt24.Rows(0)(0)
            Me.totcap.Text = dt24.Rows(0)(1)
        End If
        sql3 = "select branch_id from employee_master where emp_code=" & empida & " and branch_id=" & brid & " and branch_id in (4,29,41,75,92) "
        dt = oh.ExecuteDataSet(sql3).Tables(0)
        If dt.Rows.Count > 0 Then
            If (dt.Rows(0)(0) = 4 Or dt.Rows(0)(0) = 29 Or dt.Rows(0)(0) = 41 Or dt.Rows(0)(0) = 75 Or dt.Rows(0)(0) = 92) Then
                Me.lbl_message.Visible = True
                Me.lbl_message.Text = "PLEASE INFORM INTO FULLERTON COMPANY!!!"
            End If
        End If

    End Sub

    Protected Sub cmd_Exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Exit.Click
        'Server.Transfer("../home.aspx")
        Server.Transfer("promotion_with_tfr_frm1.aspx")
    End Sub

    Protected Sub cmb_designation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_designation.SelectedIndexChanged
        Me.txt_totalsalary.Text = " "
        payment_fill()
    End Sub

    Protected Sub txt_effectivedate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Me.lbl_message.Text = ""
        Dim sql4 As String
        Dim dt4 As New DataTable()
        Dim dat As Date
        Dim arr As Array
        Dim empid As New Integer
        Dim newjfdate As Date
        arr = Me.cmb_employee.SelectedValue.Split("*")
        empid = arr(0)
        sql4 = ("select to_date(from_dt) from employ_promotion_dtl where to_date(TO_DT) is null and emp_code=" & empid)
        dt4 = oh.ExecuteDataSet(sql4).Tables(0)
        If dt4.Rows.Count > 0 Then
            dat = dt4.Rows(0)(0)
            If (Me.txt_effectivedate.Text < dat) Then
                Me.lbl_message.Visible = True
                Me.lbl_message.Text = "EFFECTIVE DATE SHOULD BE GREATER THAN-" & dat
                Me.txt_effectivedate.Text = ""
            End If
        End If
        newjfdate = CDate(Me.txt_joindate.Text)
        If (Me.txt_effectivedate.Text <> Format(newjfdate, "dd/MMM/yyyy")) Then
            Me.lbl_message.Visible = True
            Me.lbl_message.Text = "EFFECTIVE DATE SHOULD BE EQUAL TO REPORTING(JOIN)DATE"
            Me.txt_effectivedate.Text = ""
        End If
    End Sub
    Protected Sub cmb_pay_amnt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        totsal()
    End Sub

    Protected Sub txt_joindate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim arr As Array
        arr = Me.cmb_employee.SelectedValue.Split("*")
        Dim joindt, reliv, reportdt As Date
        Dim a, b, c As Integer
        joindt = CDate(arr(8))
        reliv = CDate(Me.txt_relievedate.Text)
        reportdt = CDate(Me.txt_joindate.Text)
        a = DateDiff(DateInterval.DayOfYear, joindt, reliv)
        b = DateDiff(DateInterval.DayOfYear, joindt, reportdt)
        c = DateDiff(DateInterval.DayOfYear, reliv, reportdt)

        If (a < 0) Then
            Me.lbl_message.Visible = True
            Me.lbl_message.Text = "RELIEVING DATE SHOULD BE GREATER THAN EMPLOYEE JOINED DATE"
            Me.txt_relievedate.Text = ""
        ElseIf (b < 0) Then
            Me.lbl_message.Visible = True
            Me.lbl_message.Text = "REPORTING DATE SHOULD BE GREATER THAN EMPLOYEE JOINED DATE"
            Me.txt_joindate.Text = ""
        ElseIf (c < 0) Then
            Me.lbl_message.Visible = True
            Me.lbl_message.Text = "RELIEVING DATE SHOULD BE LESS THAN OR EQUAL TO REPORTING(JOIN) DATE"
            Me.txt_joindate.Text = ""
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


    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If String.IsNullOrEmpty(Me.text_remark.Text.Trim()) Then
            'Me.Timer1.Enabled = True
            Me.lbl_message.Visible = True
            Me.lbl_message.Text = "*************PLEASE ENTER THE REMARK!!!!******"
            Exit Sub
        End If
        Dim sql1emp, sql2emp As String, basic As New Integer
        Dim dt1emp, dt2emp As New DataTable
        Dim Chkarray As Array
        Chkarray = Me.cmb_employee.SelectedValue.Split("*")

        If Me.cmb_pay_amnt.SelectedItem.Text <> "NOT IN THE LIST AND WANT TO ENTER..?" Then
            basic = Me.cmb_pay_amnt.SelectedItem.Text
        Else
            If Me.txt_totalsalary.Text <> "" Then
                basic = Me.txt_totalsalary.Text


            End If
        End If
        If Me.cmb_hostel.SelectedValue <> -1 And Me.cmb_hostel.SelectedValue <> 0 Then

            sql1emp = "select t.sex ,e.post_id,e.emp_code,e.branch_id from employ_personal_dtl t,emp_master e where t.emp_code=e.emp_code and  t.emp_code=" & Chkarray(0) & ""
            dt1emp = oh.ExecuteDataSet(sql1emp).Tables(0)
            sql2emp = "select t.rent_category_id,t.branch_id,t.flat_no from tbl_rent_building_mst t where t.flat_no=" & Me.cmb_hostel.SelectedValue & ""
            dt2emp = oh.ExecuteDataSet(sql2emp).Tables(0)

            If dt1emp.Rows(0)(0) = 0 And dt2emp.Rows(0)(0) <> 6 Then

                Me.lbl_message.Visible = True
                Me.lbl_message.Text = "You Cannot Select Other Hostels For Ladies .. SELECT LADIES FLAT ONLY !"
                Exit Sub

            ElseIf dt1emp.Rows(0)(0) = 1 And dt2emp.Rows(0)(0) = 6 Then

                Me.lbl_message.Visible = True
                Me.lbl_message.Text = "You Cannot Select LADIES Hostels For GENTS .. SELECT OTHER FLAT !"
                Exit Sub
            End If

            If BH_BM_ABH_CHECK(dt1emp.Rows(0)(2), dt1emp.Rows(0)(1), dt2emp.Rows(0)(2), dt2emp.Rows(0)(1), dt1emp.Rows(0)(3)) = 1 Then

                Me.lbl_message.Visible = True
                Me.lbl_message.Text = "You Cannot Select same Hostel for JOINT Custodians,Choose Another One!!"
                Exit Sub

            End If
        End If

        ' end cHECKING fOR hOSTEL '
        '===========================

        If (Me.rbd_pro.Checked = False And Me.rbd_depro.Checked = False) Then

            Me.lbl_message.Text = "SELECT PROMOTION / DEPROMOTION"
            Exit Sub

        Else
            If (Me.Txt_dist.Text = "") Then
                Me.lbl_message.Text = "Enter distance between home & working branch"
            Else
                'If (Me.txt_branch.Text = Me.cmb_branch.SelectedItem.Text) Then
                '    Me.lbl_message.Text = "Check the branch"
                'Else

                If (Me.txt_relievedate.Text = "" Or Me.txt_joindate.Text = "" Or Me.txt_effectivedate.Text = "") Then
                    Me.lbl_message.Visible = True
                    Me.lbl_message.Text = "PLEASE ENTER ALL THE ENTRIES"
                    Exit Sub
                Else
                    Dim sf() As String
                    sf = Session("user_id").ToString.Split("!")
                    Dim arr5 As Array
                    arr5 = Me.cmb_employee.SelectedValue.Split("*")
                    Dim sql2 As String = "update employ_transfer_dtl set enter_by=" & sf(0) & " where emp_code='" & arr5(0) & "' and to_dt is null"
                    oh.ExecuteNonQuery(sql2)
                    Dim empid, newpscale, newbasic, grad, newdesig, tfr_type As New Integer
                    Dim arr, arr1, arr2 As Array
                    Dim newfdate, oldrldate, newjtdate, newjfdate, basicdate As Date
                    Dim newdept, newpost, deputid, newbranch, oldbranch As String
                    Dim ddf() As String
                    If (Me.rbd_pro.Checked = True) Then
                        tran = 1
                        Me.rbd_depro.Checked = False
                    Else
                        tran = 0
                    End If

                    If (Me.rbd_depro.Checked = True) Then
                        Me.rbd_pro.Checked = False
                        tran = 0
                    Else
                        tran = 1
                    End If

                    Dim trandt As String
                    trandt = Me.txt_relievedate.Text + "|" + Me.txt_effectivedate.Text + "|" + tran

                    arr = Me.cmb_employee.SelectedValue.Split("*")
                    empid = arr(0)

                    If Me.cmb_pay_amnt.SelectedItem.Text <> "NOT IN THE LIST AND WANT TO ENTER..?" Then
                        basic = Me.cmb_pay_amnt.SelectedItem.Text
                    Else
                        basic = Me.txt_totalsalary.Text
                    End If

                    '******PROMOTION*********************************
                    oldtdate = Me.txt_effectivedate.Text
                    oldtdate = DateAdd(DateInterval.Day, -1, oldtdate)
                    newfdate = Me.txt_effectivedate.Text
                    '********TRANSFER*********************************
                    oldrldate = Me.txt_relievedate.Text
                    newjtdate = Me.txt_joindate.Text
                    newjtdate = DateAdd(DateInterval.Day, -1, newjtdate)
                    newjfdate = Me.txt_joindate.Text
                    '******END****************************************

                    arr1 = Me.cmb_department.SelectedValue.Split("*")
                    newdept = arr1(0)
                    arr2 = Me.cmb_postoffered.SelectedValue.Split("*")
                    newpost = arr2(0)
                    oldbranch = arr(3)
                    If (newpost = 1 Or newpost = 2 Or newpost = 3 Or newpost = 4 Or newpost = 5 Or newpost = 6 Or newpost = 7 Or newpost = 8 Or newpost = 9) Then
                        tfr_type = 1     'B.H
                    ElseIf (newpost = 10 Or newpost = 11 Or newpost = 12 Or newpost = 13 Or newpost = 14 Or newpost = 15 Or newpost = 16 Or newpost = 17 Or newpost = 18 Or newpost = 101) Then
                        tfr_type = 2     'ABH
                    Else
                        tfr_type = 3     'NORMAL EMPLOYEE
                    End If

                    newbranch = Me.cmb_branch.SelectedValue

                    arr1 = Me.cmb_designation.SelectedValue.Split("*")
                    newpscale = arr1(3)
                    newbasic = basic
                    ddf = Me.cmb_desig.SelectedValue.Split("*")
                    newdesig = ddf(0)
                    grad = ddf(1)
                    If newpscale = 14 Then
                        da = "F"
                    Else
                        da = "T"
                    End If
                    If Me.rdbtn_yes.Checked = True Then
                        arr1 = Me.cmb_firm.SelectedValue.Split("*")
                        deputid = arr1(0)  'FIRMID
                    Else

                        deputid = 0
                    End If

                    basicdate = Me.txt_effectivedate.Text
                    If Me.txt_effectivedate.Text < Format(Date.Now, "dd/MMM/yyyy") Then
                        basicdate = Format(Date.Now, "dd/MMM/yyyy")
                    End If

                    Dim dist As String = Me.Txt_dist.Text + "|" + Me.cmb_hostel.SelectedValue

                    Dim prm(19) As OracleParameter

                    prm(0) = New OracleParameter("empid", OracleType.Int32, 25)
                    prm(0).Direction = ParameterDirection.Input
                    prm(0).Value = empid

                    prm(1) = New OracleParameter("oldtdate", OracleType.DateTime)
                    prm(1).Direction = ParameterDirection.Input
                    prm(1).Value = Format(oldtdate, "dd/MMM/yyyy")

                    prm(2) = New OracleParameter("newfdate", OracleType.DateTime)
                    prm(2).Direction = ParameterDirection.Input
                    prm(2).Value = Format(newfdate, "dd/MMM/yyyy")

                    prm(3) = New OracleParameter("newpscale", OracleType.Int32, 15)
                    prm(3).Direction = ParameterDirection.Input
                    prm(3).Value = newpscale

                    prm(4) = New OracleParameter("newbasic", OracleType.Int32, 60)
                    prm(4).Direction = ParameterDirection.Input
                    prm(4).Value = newbasic

                    prm(5) = New OracleParameter("newdesig", OracleType.Int32, 35)
                    prm(5).Direction = ParameterDirection.Input
                    prm(5).Value = newdesig

                    prm(6) = New OracleParameter("grad", OracleType.Int32, 25)
                    prm(6).Direction = ParameterDirection.Input
                    prm(6).Value = grad

                    prm(7) = New OracleParameter("da", OracleType.VarChar, 25)
                    prm(7).Direction = ParameterDirection.Input
                    prm(7).Value = da

                    prm(8) = New OracleParameter("basicdate", OracleType.DateTime)
                    prm(8).Direction = ParameterDirection.Input
                    prm(8).Value = Format(basicdate, "dd/MMM/yyyy")


                    prm(9) = New OracleParameter("deputid", OracleType.Int32, 25)
                    prm(9).Direction = ParameterDirection.Input
                    prm(9).Value = deputid

                    prm(10) = New OracleParameter("newbranch", OracleType.Int32, 25)
                    prm(10).Direction = ParameterDirection.Input
                    prm(10).Value = newbranch

                    prm(11) = New OracleParameter("newpost", OracleType.Int32, 25)
                    prm(11).Direction = ParameterDirection.Input
                    prm(11).Value = newpost


                    prm(12) = New OracleParameter("newdept", OracleType.Int32, 25)
                    prm(12).Direction = ParameterDirection.Input
                    prm(12).Value = newdept

                    prm(13) = New OracleParameter("tfr_type", OracleType.Int32, 25)
                    prm(13).Direction = ParameterDirection.Input
                    prm(13).Value = tfr_type

                    prm(14) = New OracleParameter("oldrldate", OracleType.DateTime)
                    prm(14).Direction = ParameterDirection.Input
                    prm(14).Value = Format(oldrldate, "dd/MMM/yyyy")

                    prm(15) = New OracleParameter("newjtdate", OracleType.DateTime)
                    prm(15).Direction = ParameterDirection.Input
                    prm(15).Value = Format(newjtdate, "dd/MMM/yyyy")

                    prm(16) = New OracleParameter("newjfdate", OracleType.DateTime)
                    prm(16).Direction = ParameterDirection.Input
                    prm(16).Value = Format(newjfdate, "dd/MMM/yyyy")

                    prm(17) = New OracleParameter("dist", OracleType.VarChar, 500)
                    prm(17).Direction = ParameterDirection.Input
                    prm(17).Value = dist

                    prm(18) = New OracleParameter("remark", OracleType.VarChar, 25)
                    prm(18).Direction = ParameterDirection.Input
                    prm(18).Value = Me.text_remark.Text



                    prm(19) = New OracleParameter("ap", OracleType.Int32, 15)
                    prm(19).Direction = ParameterDirection.Output


                    Dim ap As Integer

                    oh.ExecuteNonQuery("PROMOTION_MODEL_mab", prm)
                    ap = prm(19).Value
                    If ap = 1 Then

                        Me.Timer1.Enabled = True
                        Me.lbl_message.Visible = True
                        Me.lbl_message.Text = "PROMOTION WITH TRANSFER CONFIRMED SUCCESSFULLY!!!!"
                        ' clear()


                        Dim arr3 As Array

                        arr3 = Me.cmb_employee.SelectedValue.Split("*")
                        arr1 = Me.cmb_postoffered.SelectedValue.Split("*")

                        Dim str, newdat As String
                        str = ""
                        str = arr3(0) & "|" & arr1(0) & "|" & arr3(10) & "|" & arr3(3) & "|" & arr3(5) & "|" & arr3(6) & "|" & arr3(7) & "|" & arr3(8)

                        newdat = Me.cmb_postoffered.SelectedValue + "|" + Me.cmb_desig.SelectedValue + "|" + Me.cmb_department.SelectedValue + "|" + Me.cmb_branch.SelectedValue
                        'Krishnadas changed for maben (SREEJESH BUG IN MODULE)
                        Dim cl_script1 As New System.Text.StringBuilder
                        Dim f As Integer = Session("firm_id")
                        f = Session("firm_id")
                        If f = 2 Then
                            If tran = 1 Then


                                Try
                                    Dim c1 As String
                                    ' If tran = 1 Then
                                    c1 = "select y.emailid, y.subject1, y.bodymess1, y.host,y.credent,y.too,y.bodymess2 from mailing_serves y where y.subject1='PROMOTION LETTER,REGARDING PROMOTION'and y.firm_id=2"


                                    ' c1 = "select y.emailid, y.subject1, y.bodymess1, y.host,y.credent,y.too,y.bodymess2 from mailing_serves y where y.subject1='PROMOTION LETTER,REGARDING PROMOTION'and y.firm_id=2"
                                    dtv = oh.ExecuteDataSet(c1).Tables(0)
                                    Dim b1 As String = dtv.Rows(0)(2).ToString.Split("#")(0)
                                    Dim sub1 As String = dtv.Rows(0)(1).ToString.Split(",")(0)
                                    Dim shima1 As String = dtv.Rows(0)(2).ToString.Split("#")(1)
                                    shima1 = shima1.Replace("mycode", Me.cmb_employee.SelectedValue.Split("*")(0))
                                    Dim dtv1 As DataTable = oh.ExecuteDataSet(shima1).Tables(0)
                                    b1 = b1.Replace("myname", dtv1.Rows(0)(0))
                                    b1 = b1.Replace("mydes", dtv1.Rows(0)(1))
                                    b1 = b1.Replace("mypost", dtv1.Rows(0)(2))
                                    b1 = b1.Replace("mynewdes", dtv1.Rows(0)(3))
                                    b1 = b1.Replace("mypost", dtv1.Rows(0)(4))
                                    b1 = b1.Replace("mycode", dtv1.Rows(0)(5))
                                    b1 = b1.Replace("myname", dtv1.Rows(0)(6))
                                    b1 = b1.Replace("mydes", dtv1.Rows(0)(7))
                                    b1 = b1.Replace("mypost", dtv1.Rows(0)(8))
                                    b1 = b1.Replace("mydep", dtv1.Rows(0)(9))
                                    b1 = b1.Replace("mycode", dtv1.Rows(0)(10))
                                    b1 = b1.Replace("myname", dtv1.Rows(0)(11))
                                    b1 = b1.Replace("mynewdes", dtv1.Rows(0)(12))
                                    b1 = b1.Replace("mypost", dtv1.Rows(0)(13))
                                    b1 = b1.Replace("mydep", dtv1.Rows(0)(14))
                                    b1 = b1.Replace("mynewbranch", dtv1.Rows(0)(18))
                                    b1 = b1.Replace("mybranch", dtv1.Rows(0)(19))
                                    b1 = b1.Replace("mynewpost", dtv1.Rows(0)(20))
                                    b1 = b1.Replace("mynewdep", dtv1.Rows(0)(21))


                                    'for employee start
                                    Dim from As String = dtv.Rows(0)(0).ToString
                                    Dim tooffic As String = dtv.Rows(0)(5).ToString
                                    Dim pass As String = dtv.Rows(0)(4).ToString
                                    Dim host As String = dtv.Rows(0)(3).ToString
                                    Dim mail As MailMessage = New MailMessage()
                                    Dim SmtpServer As SmtpClient = New SmtpClient(host, 587)
                                    mail.From = New MailAddress(from, "RECRUITMENT")
                                    'mail.To.Add(New MailAddress(tooffic))
                                    If dtv1.Rows(0)(17).ToString <> "0" Then
                                        Dim togmail As String = dtv1.Rows(0)(17).ToString
                                        mail.To.Add(New MailAddress(togmail))
                                    Else
                                        mail.To.Add(New MailAddress(dtv.Rows(0)(0).ToString))
                                    End If
                                    mail.Subject = sub1
                                    mail.Body = String.Format(b1)
                                    mail.IsBodyHtml = True
                                    mail.BodyEncoding = System.Text.Encoding.UTF8
                                    SmtpServer.Port = 587
                                    SmtpServer.UseDefaultCredentials = False
                                    SmtpServer.Credentials = New System.Net.NetworkCredential(from, pass)
                                    'SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network
                                    'SmtpServer.EnableSsl = True
                                    'ServicePointManager.Expect100Continue = True
                                    'System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or CType(3072, SecurityProtocolType) Or CType(768, SecurityProtocolType)
                                    SmtpServer.Send(mail)
                                    'for employee end


                                    Dim b2 As String = dtv.Rows(0)(2).ToString.Split("#")(3)
                                    Dim sub2 As String = dtv.Rows(0)(1).ToString.Split(",")(1)
                                    Dim shima2 As String = dtv.Rows(0)(2).ToString.Split("#")(1)
                                    shima2 = shima2.Replace("mycode", Me.cmb_employee.SelectedValue.Split("*")(0))
                                    Dim dtv2 As DataTable = oh.ExecuteDataSet(shima2).Tables(0)
                                    b2 = b2.Replace("myname", dtv2.Rows(0)(0))
                                    b2 = b2.Replace("mydes", dtv2.Rows(0)(1))
                                    b2 = b2.Replace("mypost", dtv2.Rows(0)(2))
                                    b2 = b2.Replace("mynewdes", dtv2.Rows(0)(3))
                                    b2 = b2.Replace("mypost", dtv2.Rows(0)(4))
                                    b2 = b2.Replace("mycode", dtv2.Rows(0)(5))
                                    b2 = b2.Replace("myname", dtv2.Rows(0)(6))
                                    b2 = b2.Replace("mydes", dtv2.Rows(0)(7))
                                    b2 = b2.Replace("mypost", dtv2.Rows(0)(8))
                                    b2 = b2.Replace("mydep", dtv2.Rows(0)(9))
                                    b2 = b2.Replace("mycode", dtv2.Rows(0)(10))
                                    b2 = b2.Replace("myname", dtv2.Rows(0)(11))
                                    b2 = b2.Replace("mynewdes", dtv2.Rows(0)(12))
                                    b2 = b2.Replace("mypost", dtv2.Rows(0)(13))
                                    b2 = b2.Replace("mydep", dtv2.Rows(0)(14))
                                    b2 = b2.Replace("mynewbranch", dtv2.Rows(0)(18))
                                    b2 = b2.Replace("mybranch", dtv2.Rows(0)(19))
                                    b2 = b2.Replace("mynewpost", dtv2.Rows(0)(20))
                                    b2 = b2.Replace("mynewdep", dtv2.Rows(0)(21))


                                    'for others start
                                    Dim fromo As String = dtv.Rows(0)(0).ToString
                                    Dim passo As String = dtv.Rows(0)(4).ToString
                                    Dim hosto As String = dtv.Rows(0)(3).ToString
                                    Dim mailo As MailMessage = New MailMessage()
                                    Dim SmtpServero As SmtpClient = New SmtpClient(hosto, 587)
                                    mailo.From = New MailAddress(fromo, "RECRUITMENT")
                                    Dim latest As DataTable = oh.ExecuteDataSet("select em.branch_id, t.area_id ,em.department_id from BRANCH_DETAIL   t,branch_master   b,employee_master em where em.branch_id = t.BRANCH_ID and b.branch_id = t.BRANCH_ID and em.emp_code=" & Me.cmb_employee.SelectedValue.Split("*")(0) & "").Tables(0)

                                    ''for from and to branches
                                    'Dim bradres As String = dtv.Rows(0)(6).ToString.Split("|")(0)
                                    'Dim brmailids() As String = bradres.Split(",")
                                    'For Each brst As String In brmailids
                                    '    If brst.ToString.Split("~")(1) = latest.Rows(0)(0) Then
                                    '        mailo.To.Add(New MailAddress(brst.ToString.Split("~")(0)))
                                    '    End If
                                    'Next

                                    ''for from and to areaheads
                                    'Dim ahadres As String = dtv.Rows(0)(6).ToString.Split("|")(1)
                                    'Dim ahmailids() As String = ahadres.Split(",")
                                    'For Each ahst As String In ahmailids
                                    '    If ahst.ToString.Split("~")(1) = latest.Rows(0)(1) Then
                                    '        mailo.To.Add(New MailAddress(ahst.ToString.Split("~")(0)))
                                    '    End If
                                    'Next

                                    ''for ALL HO & other officials
                                    'Dim hofadres As String = dtv.Rows(0)(6).ToString.Split("|")(2)
                                    'Dim hofmailids() As String = hofadres.Split(",")
                                    'For Each hofst As String In hofmailids
                                    '    mailo.To.Add(New MailAddress(hofst))
                                    'Next

                                    ''for ALL LAP
                                    'If latest.Rows(0)(2) = 607 Then
                                    '    Dim lapadres As String = dtv.Rows(0)(6).ToString.Split("|")(3)
                                    '    Dim lapmailids() As String = lapadres.Split(",")
                                    '    For Each lapst As String In lapmailids
                                    '        mailo.To.Add(New MailAddress(lapst))
                                    '    Next
                                    'End If

                                    ''for DEP HEADS
                                    'Dim depadres As String = dtv.Rows(0)(6).ToString.Split("|")(4)
                                    'Dim depmailids() As String = depadres.Split(",")
                                    'For Each depst As String In depmailids
                                    '    If depst.ToString.Split("~")(1) = latest.Rows(0)(2) Then
                                    '        mailo.To.Add(New MailAddress(depst))
                                    '    End If
                                    'Next

                                    ''for ALL HO & other officials
                                    'Dim hofadres As String = dtv.Rows(0)(6).ToString.Split("|")(2)
                                    'Dim hofmailids() As String = hofadres.Split(",")
                                    'For Each hofst As String In hofmailids
                                    '    'mailo.To.Add(New MailAddress(hofst))
                                    '    sb.Append(hofst)
                                    '    sb.Append("&")
                                    'Next

                                    ''for from and to branches
                                    'Dim bradres As String = dtv.Rows(0)(6).ToString.Split("|")(0)
                                    'Dim brmailids() As String = bradres.Split(",")
                                    'For Each brst As String In brmailids
                                    '    If brst.ToString.Split("~")(1) = latest.Rows(0)(0) Then
                                    '        'mailo.To.Add(New MailAddress(brst.ToString.Split("~")(0)))
                                    '        sb.Append(brst.ToString.Split("~")(0))
                                    '        sb.Append("&")
                                    '    End If
                                    'Next

                                    ''for from and to areaheads
                                    'Dim ahadres As String = dtv.Rows(0)(6).ToString.Split("|")(1)
                                    'Dim ahmailids() As String = ahadres.Split(",")
                                    'For Each ahst As String In ahmailids
                                    '    If ahst.ToString.Split("~")(1) = latest.Rows(0)(1) Then
                                    '        'mailo.To.Add(New MailAddress(ahst.ToString.Split("~")(0)))
                                    '        sb.Append(ahst.ToString.Split("~")(0))
                                    '        sb.Append("&")
                                    '    End If
                                    'Next

                                    ''for ALL LAP
                                    'If latest.Rows(0)(2) = 607 Then
                                    '    Dim lapadres As String = dtv.Rows(0)(6).ToString.Split("|")(3)
                                    '    Dim lapmailids() As String = lapadres.Split(",")
                                    '    For Each lapst As String In lapmailids
                                    '        'mailo.To.Add(New MailAddress(lapst))
                                    '        sb.Append(lapst)
                                    '        sb.Append("&")
                                    '    Next
                                    'End If

                                    ''for DEP HEADS
                                    'Dim depadres As String = dtv.Rows(0)(6).ToString.Split("|")(4)
                                    'Dim depmailids() As String = depadres.Split(",")
                                    'For Each depst As String In depmailids
                                    '    If depst.ToString.Split("~")(1) = latest.Rows(0)(2) Then
                                    '        'mailo.To.Add(New MailAddress(depst.ToString.Split("~")(0)))
                                    '        sb.Append(depst.ToString.Split("~")(0))
                                    '        sb.Append("&")
                                    '    End If
                                    'Next

                                    ''For Each tomail As String In sb.ToString().Split("&")
                                    ''    mailo.To.Add(New MailAddress(tomail))
                                    ''Next
                                    'idmail = sb.ToString().Split("&")
                                    'For i As Integer = 0 To idmail.Length - 1
                                    '    If ((idmail(i) <> "") And (Not IsDBNull(idmail(i)))) Then
                                    '        mailo.To.Add(New MailAddress(idmail(i)))
                                    '    End If
                                    'Next

                                    'for all except md,cs,ceo,cfo (To)
                                    Dim bradres As String = dtv.Rows(0)(6).ToString.Split("|")(0)
                                    Dim brmailids() As String = bradres.Split(",")
                                    For Each brst As String In brmailids
                                        mailo.To.Add(New MailAddress(brst))
                                    Next

                                    'for  md,cs,ceo,cfo (CC)
                                    Dim ahadres As String = dtv.Rows(0)(6).ToString.Split("|")(1)
                                    Dim ahmailids() As String = ahadres.Split(",")
                                    For Each ahst As String In ahmailids
                                        mailo.CC.Add(New MailAddress(ahst))
                                    Next

                                    mailo.Subject = sub2
                                    mailo.Body = String.Format(b2)
                                    mailo.IsBodyHtml = True
                                    mailo.BodyEncoding = System.Text.Encoding.UTF8
                                    SmtpServero.Port = 587
                                    SmtpServero.UseDefaultCredentials = False
                                    SmtpServero.Credentials = New System.Net.NetworkCredential(fromo, passo)
                                    'SmtpServero.DeliveryMethod = SmtpDeliveryMethod.Network
                                    'SmtpServero.EnableSsl = True
                                    'ServicePointManager.Expect100Continue = True
                                    'System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or CType(3072, SecurityProtocolType) Or CType(768, SecurityProtocolType)
                                    SmtpServero.Send(mailo)
                                    'for others end
                                Catch ex As Exception
                                End Try
                            End If
                            'Me.Timer1.Enabled = True
                            Me.lbl_message.Visible = True
                            Me.lbl_message.Text = "PROMOTION WITH TRANSFER CONFIRMED SUCCESSFULLY!!!!"
                            clear()

                        End If
                        'MIAL CONFIGURATION END
                        cl_script1.Append("window.open('promotion_with_tfr_report_mab.aspx?from_date=" & str & "&trandt=" & trandt & "&newdat=" & newdat & "&dis=" & dist & "');")
                        'Server.Transfer("promotion_with_tfr_frm1.aspx")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    ElseIf ap = 10 Then
                        Me.lbl_message.Visible = True
                        Me.lbl_message.Text = "Not Successfull.already a confirmation done on same Join Date!!"
                    ElseIf ap = 20 Then
                        Me.lbl_message.Visible = True
                        Me.lbl_message.Text = "Not Successfull.employ firm not correct!!"
                    ElseIf ap = 30 Then
                        Me.lbl_message.Visible = True
                        Me.lbl_message.Text = "Not Successfull.Already Promoted/demoted on same date!!"
                    Else
                        Me.lbl_message.Visible = True
                        Me.lbl_message.Text = "Not Successfull. Some Problems occured!!!!"
                    End If
                End If
            End If
        End If
        'End If
    End Sub

    Protected Sub cmd_clear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_clear.Click
        clear()
    End Sub

    Protected Sub rdbtn_yes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.rdbtn_no.Checked = False
        If Me.rdbtn_yes.Checked = True Then


            Dim sql As String
            sql = "select firm_name,firm_id||'*'||firm_name from firm_master order by firm_name"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows.Count > 0 Then
                Me.cmb_firm.Visible = True
                Me.cmb_firm.DataSource = dt
                Me.cmb_firm.DataTextField = dt.Columns(0).ColumnName
                Me.cmb_firm.DataValueField = dt.Columns(1).ColumnName
                Me.cmb_firm.DataBind()
            End If
        End If
    End Sub

    Protected Sub rdbtn_no_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.rdbtn_yes.Checked = False
        If Me.rdbtn_no.Checked = True Then
            Me.cmb_firm.Visible = False
        End If
    End Sub


    Protected Sub cmb_postoffered_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim arr As Array
        Dim empid, brid, postoffid, empidd, cnt, k As Integer

        arr = Me.cmb_employee.SelectedValue.Split("*")
        empid = arr(0)

        arr = Me.cmb_branch.SelectedValue.Split("*")
        brid = arr(0)

        arr = Me.cmb_postoffered.SelectedValue.Split("*")
        postoffid = arr(0)

        sql4 = "select count(emp_code) from employee_exception where status_id=6"
        dt = oh.ExecuteDataSet(sql4).Tables(0)
        If dt.Rows.Count > 0 Then
            cnt = dt.Rows(0)(0)
        End If


        sql4 = "select emp_code,status_id from employee_exception where status_id=6"
        dt = oh.ExecuteDataSet(sql4).Tables(0)
        If dt.Rows.Count > 0 Then
            'EMPLOYEE WHO IS HAVING STATUS_ID 6(IN EMPLOYEE_EXCEPTION TABLE) THEN THAT WILL NOT ELIGIBLE FOR THE POST OF A.B.H AND B.H
            For k = 0 To cnt - 1
                empidd = dt.Rows(k)(0)
                If ((empid = empidd) And (postoffid <= 18)) Then
                    Me.lbl_message.Visible = True
                    Me.lbl_message.Text = "THIS EMPLOYEE IS NOT ELIGIBLE FOR THE POST OF A.B.H AND B.H"
                End If
            Next
        End If


        sql3 = "select a.emp_code from employ_transfer_dtl a,post_mst b  where a.branch_id=" & brid & " and to_char(to_dt) is null and a.post_id=b.post_id and a.status_id in (1,8) and b.post_id in (10,11,12,13,14,15,16,17,18,101,149,146,148,90)"
        dt = oh.ExecuteDataSet(sql3).Tables(0)
        If dt.Rows.Count > 0 Then

            Me.lbl_message.Visible = True
            Me.lbl_message.Text = "B.H (G) ALREADY EXISTS IN THIS BRANCH "
        End If
    End Sub



    Protected Sub rbd_pro_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Me.rbd_pro.Checked = True) Then
            tran = 1
            Me.rbd_depro.Checked = False
        Else
            tran = 0
        End If
    End Sub

    Protected Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Me.rbd_depro.Checked = True) Then
            Me.rbd_pro.Checked = False
            tran = 0
        Else
            tran = 1
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (Me.rbd_pro.Checked = False And Me.rbd_depro.Checked = False) Then

            Me.lbl_message.Text = "SELECT PROMOTION / DEMOTION"
        Else

            'If (Me.txt_branch.Text = Me.cmb_branch.SelectedItem.Text) Then
            '    'Me.lbl_message.Text = ""
            '    Dim msgbx As New System.Text.StringBuilder
            '    msgbx.Append("         alert(' Check the branch');")
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
            'Else

            If (Me.txt_relievedate.Text = "" Or Me.txt_joindate.Text = "" Or Me.txt_effectivedate.Text = "") Then
                Me.lbl_message.Visible = True
                Me.lbl_message.Text = "PLEASE ENTER ALL THE ENTRIES"
            Else
                'Dim sf() As String
                'sf = Session("user_id").ToString.Split("!")
                'Dim sql2 As String = "update employ_transfer_dtl set enter_by=" & sf(0) & " where emp_code='" & Me.cmb_select.SelectedValue & "' and to_dt is null"
                'oh.ExecuteNonQuery(sql2)
                Dim empid, newpscale, newbasic, grad, newdesig, basic, tfr_type As New Integer
                Dim arr, arr1, arr2 As Array
                Dim newfdate, oldrldate, newjtdate, newjfdate, basicdate As Date
                Dim newdept, newpost, deputid, newbranch, oldbranch As String
                If (Me.rbd_pro.Checked = True) Then
                    tran = 1
                    Me.rbd_depro.Checked = False
                Else
                    tran = 0
                End If

                If (Me.rbd_depro.Checked = True) Then
                    Me.rbd_pro.Checked = False
                    tran = 0
                Else
                    tran = 1
                End If

                Dim trandt As String
                trandt = Me.txt_relievedate.Text + "|" + Me.txt_effectivedate.Text + "|" + tran

                arr = Me.cmb_employee.SelectedValue.Split("*")
                empid = arr(0)
                If Me.cmb_pay_amnt.SelectedItem.Text <> "NOT IN THE LIST AND WANT TO ENTER..?" Then
                    basic = Me.cmb_pay_amnt.SelectedItem.Text
                Else
                    basic = Me.txt_totalsalary.Text
                End If

                '******PROMOTION*********************************
                oldtdate = Me.txt_effectivedate.Text
                oldtdate = DateAdd(DateInterval.Day, -1, oldtdate)
                newfdate = Me.txt_effectivedate.Text
                '********TRANSFER*********************************
                oldrldate = Me.txt_relievedate.Text
                newjtdate = Me.txt_joindate.Text
                newjtdate = DateAdd(DateInterval.Day, -1, newjtdate)
                newjfdate = Me.txt_joindate.Text
                '******END****************************************

                arr1 = Me.cmb_department.SelectedValue.Split("*")
                newdept = arr1(0)
                arr2 = Me.cmb_postoffered.SelectedValue.Split("*")
                newpost = arr2(0)
                oldbranch = arr(3)
                If (newpost = 1 Or newpost = 2 Or newpost = 3 Or newpost = 4 Or newpost = 5 Or newpost = 6 Or newpost = 7 Or newpost = 8 Or newpost = 9) Then
                    tfr_type = 2     'B.H
                ElseIf (newpost = 10 Or newpost = 11 Or newpost = 12 Or newpost = 13 Or newpost = 14 Or newpost = 15 Or newpost = 16 Or newpost = 17 Or newpost = 18) Then
                    tfr_type = 1     'ABH
                Else
                    tfr_type = 3     'NORMAL EMPLOYEE
                End If

                newbranch = Me.cmb_branch.SelectedValue

                arr1 = Me.cmb_designation.SelectedValue.Split("*")
                Dim ddf() As String = Me.cmb_desig.SelectedValue.Split("*")
                newpscale = arr1(0)
                newbasic = basic
                newdesig = ddf(0)
                grad = ddf(1)
                If newpscale = 14 Then
                    da = "F"
                Else
                    da = "T"
                End If
                If Me.rdbtn_yes.Checked = True Then
                    arr1 = Me.cmb_firm.SelectedValue.Split("*")
                    deputid = arr1(0)  'FIRMID
                Else

                    deputid = 0
                End If

                basicdate = Me.txt_effectivedate.Text
                If Me.txt_effectivedate.Text < Format(Date.Now, "dd/MMM/yyyy") Then
                    basicdate = Format(Date.Now, "dd/MMM/yyyy")
                End If


                Dim arr3 As Array

                arr3 = Me.cmb_employee.SelectedValue.Split("*")
                arr1 = Me.cmb_postoffered.SelectedValue.Split("*")

                Dim str, newdat As String
                str = ""
                str = arr3(0) & "|" & arr1(0) & "|" & arr3(10) & "|" & arr3(3) & "|" & arr3(5) & "|" & arr3(6) & "|" & arr3(7) & "|" & arr3(8)


                If (Me.cmb_firm.Visible = False) Then
                    fm = 0
                Else
                    fm = Me.cmb_firm.SelectedItem.Text
                End If


                If Me.cmb_pay_amnt.SelectedItem.Text <> "NOT IN THE LIST AND WANT TO ENTER..?" Then
                    newdat = Me.cmb_postoffered.SelectedValue + "|" + Me.cmb_desig.SelectedValue + "|" + Me.cmb_department.SelectedValue + "|" + Me.cmb_branch.SelectedItem.Text + "|" + fm + "|" + Me.cmb_pay_amnt.SelectedItem.Text + "|" + Me.txt_totalsalary.Text
                Else
                    newdat = Me.cmb_postoffered.SelectedValue + "|" + Me.cmb_desig.SelectedValue + "|" + Me.cmb_department.SelectedValue + "|" + Me.cmb_branch.SelectedItem.Text + "|" + fm + "|" + Me.txt_totalsalary.Text + "|" + Me.txt_totalsalary.Text
                End If

                Dim cl_script1 As New System.Text.StringBuilder

                cl_script1.Append("window.open('viewpromotionrepo.aspx?from_date=" & str & "&trandt=" & trandt & "&newdat=" & newdat & "');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If
        End If
        'End If
    End Sub

    Protected Sub cmb_branch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim pos As String
        pos = ""
        Dim dt33 As DataTable = oh.ExecuteDataSet("select count(emp_code) from employee_master where branch_id=" & Me.cmb_branch.SelectedValue & " and post_id in (17,18,12,15,101,10,11,14,13,16,149,146,148,90) and status_id=1").Tables(0)
        If (dt33.Rows.Count >= 1 And dt33.Rows(0)(0) > 3) Then
            Dim dt34 As DataTable = oh.ExecuteDataSet("select post_id from employee_master where branch_id=" & Me.cmb_branch.SelectedValue & " and post_id in (17,18,12,15,101,10,11,14,13,16,149,146,148,90) and status_id=1 ").Tables(0)
            Dim dr As DataRow
            If (dt33.Rows(0)(0) = 0 And dt34.Rows.Count = 0) Then
                sql = "select post_name,post_id||'*'||post_name from post_mst  order by post_id"
            Else

                If (dt34.Rows.Count = 1 And Not IsDBNull(dt34.Rows(0)(0))) Then
                    sql = "select post_name,post_id||'*'||post_name from post_mst where post_id not in (" & dt34.Rows(0)(0) & ") order by post_id"
                Else

                    For Each dr In dt34.Rows
                        '  pos = dr(0)
                        If pos = "" Then
                            pos = dr(0)
                        Else
                            pos = pos & "," & dr(0)
                        End If

                    Next


                    sql = "select post_name,post_id||'*'||post_name from post_mst where post_id not in (" & pos & ") order by post_id"


                End If
            End If

        Else
            sql = "select post_name,post_id||'*'||post_name from post_mst  order by post_id"
        End If
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Me.cmb_postoffered.DataSource = dt
            Me.cmb_postoffered.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_postoffered.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_postoffered.DataBind()
        End If

        Dim sql22, sql23, sql24 As String
        sql22 = "select s.state_name,s.state_id from state_master s,branch b where b.branch_id=" & Me.cmb_branch.SelectedValue & " and b.state_id=s.state_id order by s.state_name "
        dt22 = oh.ExecuteDataSet(sql22).Tables(0)
        Me.cmb_state.DataSource = dt22
        Me.cmb_state.DataTextField = dt22.Columns(0).ColumnName
        Me.cmb_state.DataValueField = dt22.Columns(1).ColumnName
        Me.cmb_state.DataBind()
        Dim arr As Array
        arr = Me.cmb_employee.SelectedValue.Split("*")
        Dim dthh As DataTable = oh.ExecuteDataSet("select nvl(h.hostel,0) from hrm_proposal_order h where h.emp_code= " & arr(0) & " and h.status=1 ").Tables(0)
        Dim hoste As String
        'If dthh.Rows.Count = 0 Then
        '    hoste = 0
        'Else
        '    hoste = dthh.Rows(0)(0)
        'End If
        If dthh.Rows.Count = 0 Then
            Me.cathos.Visible = True
            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select 'Hostel Not Required',0 as flat_no,'AAB' as area_name from dual union select t.flat_name||'('||b.area_name||')',t.flat_no,b.area_name from tbl_rent_building_mst t,branch b where b.BRANCH_ID=t.branch_id and t.rent_category_id=" & Me.cmb_cat.SelectedValue & " and b.STATE_ID=" & Me.cmb_state.SelectedValue & " and t.status_id=1 order by area_name "
        Else
            Me.cathos.Visible = False
            hoste = dthh.Rows(0)(0)
            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select ' No Hostel',0 as flat_no,'AAB' as area_name from dual union select t.flat_name|| '(' || b.area_name || ')',t.flat_no,b.area_name from tbl_rent_building_mst t ,hrm_proposal_order d,branch b where  d.emp_code=" & arr(0) & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1 and t.branch_id=b.branch_id order by area_name"
        End If
        dt23 = oh.ExecuteDataSet(sql23).Tables(0)
        Me.cmb_hostel.DataSource = dt23
        Me.cmb_hostel.DataTextField = dt23.Columns(0).ColumnName
        Me.cmb_hostel.DataValueField = dt23.Columns(1).ColumnName
        Me.cmb_hostel.DataBind()
        sql24 = "select count(t.flat_no),nvl(v.capacity,0) from tbl_rent_building_mst t left outer join tbl_rent_building_mst v  on (v.flat_no=t.flat_no) where t.flat_no=" & Me.cmb_hostel.SelectedValue & " group by  t.flat_no,v.capacity"
        dt24 = oh.ExecuteDataSet(sql24).Tables(0)
        If dt24.Rows.Count = 0 Then
            Me.pcap.Text = 0
            Me.totcap.Text = 0
        Else
            Me.pcap.Text = dt24.Rows(0)(0)
            Me.totcap.Text = dt24.Rows(0)(1)
        End If
    End Sub

    Protected Sub txt_relievedate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim revdt, jdt As Date
        revdt = Me.txt_relievedate.Text

        If Me.txt_joindate.Text = "" Then
        Else
            jdt = Me.txt_joindate.Text
            If CDate(revdt) > CDate(jdt) Then
                Me.lbl_message.Text = " Joining date should be greater than Releving date"
                Me.txt_joindate.Text = ""
            End If
        End If

    End Sub

    Protected Sub cmb_hostel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sql24 As String = "select count(t.flat_no),nvl(v.capacity,0) from tbl_rent_building_mst t left outer join tbl_rent_building_mst v  on (v.flat_no=t.flat_no) where t.flat_no=" & Me.cmb_hostel.SelectedValue & " group by  t.flat_no,v.capacity"
        dt24 = oh.ExecuteDataSet(sql24).Tables(0)
        If dt24.Rows.Count = 0 Then
            Me.pcap.Text = 0
            Me.totcap.Text = 0
        Else
            Me.pcap.Text = dt24.Rows(0)(0)
            Me.totcap.Text = dt24.Rows(0)(1)
        End If
    End Sub

    Protected Sub cmb_state_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim arr As Array
        arr = Me.cmb_employee.SelectedValue.Split("*")

        Dim sql23, sql24 As String
        Dim dthh As DataTable = oh.ExecuteDataSet("select nvl(h.hostel,0) from hrm_proposal_order h where h.emp_code= " & arr(0) & " and h.status=1 ").Tables(0)
        Dim hoste As String
        If dthh.Rows.Count = 0 Then
            Me.cathos.Visible = True
            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select 'Hostel Not Required',0 as flat_no,'AAB' as area_name from dual union select t.flat_name||'('||b.area_name||')',t.flat_no,b.area_name from tbl_rent_building_mst t,branch b where b.BRANCH_ID=t.branch_id and t.rent_category_id=" & Me.cmb_cat.SelectedValue & " and b.STATE_ID=" & Me.cmb_state.SelectedValue & " and t.status_id=1 order by area_name "
        Else
            Me.cathos.Visible = False
            hoste = dthh.Rows(0)(0)
            sql23 = "select ' Select Hostel',-1 as flat_no,'AAA' as area_name from dual union select ' No Hostel',0 as flat_no,'AAB' as area_name from dual union select t.flat_name|| '(' || b.area_name || ')',t.flat_no,b.area_name from tbl_rent_building_mst t ,hrm_proposal_order d,branch b where  d.emp_code=" & arr(0) & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1 and t.branch_id=b.branch_id order by area_name"
        End If
        'If dthh.Rows.Count = 0 Then
        '    hoste = 0
        'Else
        '    hoste = dthh.Rows(0)(0)
        'End If
        'sql23 = "select ' Select Hostel',-1 as flat_no from dual union select ' No Hostel',0 as flat_no from dual union select t.flat_name,t.flat_no from tbl_rent_building_mst t ,hrm_proposal_order d where  d.emp_code=" & arr(0) & " and d.hostel=t.flat_no  and t.flat_no=" & hoste & " and t.status_id=1  order by flat_no"
        'dt23 = oh.ExecuteDataSet(sql23).Tables(0)
        Me.cmb_hostel.DataSource = dt23
        Me.cmb_hostel.DataTextField = dt23.Columns(0).ColumnName
        Me.cmb_hostel.DataValueField = dt23.Columns(1).ColumnName
        Me.cmb_hostel.DataBind()
        sql24 = "select count(t.flat_no),nvl(v.capacity,0) from tbl_rent_building_mst t left outer join tbl_rent_building_mst v  on (v.flat_no=t.flat_no) where t.flat_no=" & Me.cmb_hostel.SelectedValue & " group by  t.flat_no,v.capacity"
        dt24 = oh.ExecuteDataSet(sql24).Tables(0)
        If dt24.Rows.Count = 0 Then
            Me.pcap.Text = 0
            Me.totcap.Text = 0
        Else
            Me.pcap.Text = dt24.Rows(0)(0)
            Me.totcap.Text = dt24.Rows(0)(1)
        End If
    End Sub




    Protected Sub txt_enter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_enter.TextChanged

        If Me.txt_totalsalary.Text = "" Or Val(Me.txt_totalsalary.Text) = 0 Then
            Me.txt_totalsalary.Text = Me.txt_enter.Text
        Else
            Me.txt_totalsalary.Text = Me.txt_enter.Text
        End If

    End Sub
End Class


