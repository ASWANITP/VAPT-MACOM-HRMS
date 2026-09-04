Imports System.Data
Imports System.Data.OracleClient
Partial Class report_AgencyWiseTrxn_0357ac437527
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim objHelper As New Helper.Oracle.OracleHelper
    Dim dsOut As New DataSet
    Dim backResult As String
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = Session("title")
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "Leave Report"
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.Cmb_Emp.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)

        If Not IsPostBack Then
            Dim dt1 As New DataTable
            sql = "select -1,'--------------Select-----------' as emp from dual union all select t.emp_id,a.EMP_NAME from form_accessibility t , emp_master a  where t.emp_id=a.EMP_CODE and t.form_id=613 order by emp"

            dt1 = objHelper.ExecuteDataSet(sql).Tables(0)
            Me.Cmb_Emp.DataSource = dt1
            Me.Cmb_Emp.DataTextField = dt1.Columns(1).ColumnName
            Me.Cmb_Emp.DataValueField = dt1.Columns(0).ColumnName
            Me.Cmb_Emp.DataBind()
            Me.Cmb_Emp.Attributes.Add("onchange", "EmpOnchange()")
            Me.Cmb_Branch.Attributes.Add("onchange", "BranchOnchange()")
            Me.Butn_Generate.Attributes.Add("onclick", "return ClickOnchange()")
        End If
    End Sub

    Protected Sub Butn_Generate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Butn_Generate.Click
        Dim par(1) As OracleParameter
        Dim dt As New DataSet
      
        Dim user() As String = Session("User_id").ToString.Split("!")

        'If Me.HiddenBranch.Value = 614 Then
        '    '**********Head Office***********
        '    par(0) = New OracleParameter("usr_id", OracleType.VarChar, 10)
        '    par(0).Value = Session("User_id").ToString
        '    par(0).Direction = ParameterDirection.Input

        '    par(1) = New OracleParameter("flag", OracleType.Number, 3)
        '    par(1).Direction = ParameterDirection.Output

        '    objHelper.ExecuteNonQuery("hrm_leave_access_modify", par)
        'ElseIf Me.HiddenBranch.Value = 613 Then
        '    '*********Branches****************
        '    par(0) = New OracleParameter("usr", OracleType.Number, 10)
        '    par(0).Value = CInt(Me.HiddenEmp.Value)
        '    par(0).Direction = ParameterDirection.Input

        '    par(1) = New OracleParameter("flag", OracleType.Number, 3)
        '    par(1).Direction = ParameterDirection.Output
        '    objHelper.ExecuteNonQuery("hrmleaveaccessmodify_new", par)
        'End If




        Dim strBuild As New StringBuilder
        If Me.HiddenBranch.Value = 614 Then   '**********Head Office***********

            'strBuild.Append("select t.emp_code, e.EMP_NAME,       b.BRANCH_NAME,       d.designation,       p.post_name,dp.dep_name,       e.JOIN_DT,       t.leave_frdate,       t.leave_todate,       l.leave_abbr,       t.leave_apply_date,t.leave_reason,       t.leave_days,       sum(em.eligible_leave),                 (select sum(leave_days)                 from  employ_leave_dtl el, emp_new_old_live p                 where el.leave_process_id not in (0, 3) and el.leave_reason<>'N/M E' and el.leave_reason<>'N/M M' and (el.emp_code=p.new_code or                 el.emp_code=p.old_code) and to_date(el.leave_frdate)>=to_date('1/jan/2012') and                 (p.new_code=t.emp_code or p.old_code=t.emp_code))         as leave_taken,sum(em.leave_days) as balance_leave,       t.leave_seq  from  hrm_leave_application t,        leave_master          l,        emp_master            e,        designation_master    d,        post_mst              p, department_mst dp ,        branch                b,        employ_leave_master   em where t.sanc_code = '" & user(0) & "'  and e.STATUS_ID = 1 and e.DEPARTMENT_ID=dp.dep_id   and t.emp_code = e.EMP_CODE   and e.DESIGNATION_ID = d.designation_id   and e.BRANCH_ID = b.BRANCH_ID   and e.POST_ID = p.post_id   and t.leave_id = l.leave_id   and e.EMP_CODE = em.emp_code group by em.emp_code,          t.emp_code,          e.EMP_NAME,          b.BRANCH_NAME,          d.designation,          p.post_name,          e.JOIN_DT,          t.leave_frdate,          t.leave_todate,          l.leave_abbr,          t.leave_apply_date,          t.leave_days,t.leave_seq,t.leave_reason ,dp.dep_name")
            strBuild.Append("select s.emp_code, m.emp_name, b.branch_name, d.designation,p.post_name, m.join_dt,dep.dep_name, s.leave_frdate, s.leave_todate,l.leave_abbr,s.leave_days,sum(lm.leave_days),(select sum(leave_days) from employ_leave_dtl el  where el.leave_process_id not in (0, 3) and el.leave_reason <> 'N/M E' and el.leave_reason <> 'N/M M' and el.emp_code=s.emp_code  and to_date(el.leave_frdate) >= to_date('1/jan/2012')) as leave_taken, sum(lm.leave_days) as balance_leave,s.leave_seq from hrm_leave_apply_sanction s,leave_sanction_authority a,employee_master  m,branch_master   b,designation_mst d,post_mst  p,department_mst  dep,leave_master  l,employ_leave_master lm where a.emp_code = s.emp_code and m.branch_id=b.branch_id   and a.emp_code = m.emp_code and s.emp_code=lm.emp_code and s.leave_id=lm.leave_id   and m.designation_id = d.designation_id   and m.post_id = p.post_id   and m.department_id = dep.dep_id and s.leave_id = l.leave_id and s.status_id in (4, 5) and m.branch_id = 0   and a.l_sanc_by = '" & user(0) & "' group by s.emp_code, m.emp_name,b.branch_name,d.designation,p.post_name,m.join_dt,dep.dep_name, s.leave_frdate, s.leave_todate,l.leave_abbr,s.leave_days,s.leave_seq union all  select s.emp_code,m.emp_name, b.branch_name,d.designation, p.post_name, m.join_dt,dep.dep_name,s.leave_frdate,s.leave_todate,l.leave_abbr,s.leave_days,sum(lm.leave_days),(select sum(leave_days) from employ_leave_dtl el where el.leave_process_id not in (0, 3) and el.leave_reason <> 'N/M E' and el.leave_reason <> 'N/M M' and el.emp_code=s.emp_code and to_date(el.leave_frdate) >= to_date('1/jan/2012')) as leave_taken, sum(lm.leave_days) as balance_leave, s.leave_seq from hrm_leave_apply_sanction s, leave_sanction_authority a, employee_master m, branch_master  b, designation_mst d,post_mst  p, department_mst  dep,  leave_master   l,employ_leave_master lm where a.emp_code = s.emp_code and m.branch_id=b.branch_id and a.emp_code = m.emp_code and s.emp_code=lm.emp_code and s.leave_id=lm.leave_id and m.designation_id = d.designation_id and m.post_id = p.post_id and m.department_id = dep.dep_id and s.leave_id = l.leave_id and s.status_id in (0) and a.l_rec_by = '" & user(0) & "' and m.branch_id = 0 group by s.emp_code,m.emp_name,b.branch_name, d.designation, p.post_name,m.join_dt,dep.dep_name, s.leave_frdate, s.leave_todate,l.leave_abbr,s.leave_days,s.leave_seq")

        ElseIf Me.HiddenBranch.Value = 613 Then  '*********Branches****************
            'strBuild.Append("select t.emp_code, e.EMP_NAME,       b.BRANCH_NAME,       d.designation,       p.post_name,dp.dep_name,       e.JOIN_DT,       t.leave_frdate,       t.leave_todate,       l.leave_abbr,       t.leave_apply_date,t.leave_reason,       t.leave_days,       sum(em.eligible_leave),                 (select sum(leave_days)                 from  employ_leave_dtl el, emp_new_old_live p                 where el.leave_process_id not in (0, 3) and el.leave_reason<>'N/M E' and el.leave_reason<>'N/M M' and (el.emp_code=p.new_code or                 el.emp_code=p.old_code) and to_date(el.leave_frdate)>=to_date('1/jan/2012') and                 (p.new_code=t.emp_code or p.old_code=t.emp_code))         as leave_taken,sum(em.leave_days) as balance_leave,       t.leave_seq  from  hrm_leave_application t,        leave_master          l,        emp_master            e,        designation_master    d,        post_mst              p, department_mst dp ,        branch                b,        employ_leave_master   em where t.sanc_code = '" & Me.HiddenEmp.Value & "'  and e.STATUS_ID = 1 and e.DEPARTMENT_ID=dp.dep_id   and t.emp_code = e.EMP_CODE   and e.DESIGNATION_ID = d.designation_id   and e.BRANCH_ID = b.BRANCH_ID   and e.POST_ID = p.post_id   and t.leave_id = l.leave_id   and e.EMP_CODE = em.emp_code group by em.emp_code,          t.emp_code,          e.EMP_NAME,          b.BRANCH_NAME,          d.designation,          p.post_name,          e.JOIN_DT,          t.leave_frdate,          t.leave_todate,          l.leave_abbr,          t.leave_apply_date,          t.leave_days,t.leave_seq,t.leave_reason ,dp.dep_name")
            strBuild.Append("select s.emp_code, m.emp_name, b.branch_name, d.designation,p.post_name, m.join_dt,dep.dep_name, s.leave_frdate, s.leave_todate,l.leave_abbr,s.leave_days,sum(lm.leave_days),(select sum(leave_days) from employ_leave_dtl el  where el.leave_process_id not in (0, 3) and el.leave_reason <> 'N/M E' and el.leave_reason <> 'N/M M' and el.emp_code=s.emp_code  and to_date(el.leave_frdate) >= to_date('1/jan/2012')) as leave_taken, sum(lm.leave_days) as balance_leave,s.leave_seq from hrm_leave_apply_sanction s,leave_sanction_authority a,employee_master  m,branch_master   b,designation_mst d,post_mst  p,department_mst  dep,leave_master  l,employ_leave_master lm where a.emp_code = s.emp_code and m.branch_id=b.branch_id   and a.emp_code = m.emp_code and s.emp_code=lm.emp_code and s.leave_id=lm.leave_id   and m.designation_id = d.designation_id   and m.post_id = p.post_id   and m.department_id = dep.dep_id and s.leave_id = l.leave_id and s.status_id in (4, 5) and m.branch_id <> 0   and a.l_sanc_by = '" & user(0) & "' group by s.emp_code, m.emp_name,b.branch_name,d.designation,p.post_name,m.join_dt,dep.dep_name, s.leave_frdate, s.leave_todate,l.leave_abbr,s.leave_days,s.leave_seq union all  select s.emp_code,m.emp_name, b.branch_name,d.designation, p.post_name, m.join_dt,dep.dep_name,s.leave_frdate,s.leave_todate,l.leave_abbr,s.leave_days,sum(lm.leave_days),(select sum(leave_days) from employ_leave_dtl el where el.leave_process_id not in (0, 3) and el.leave_reason <> 'N/M E' and el.leave_reason <> 'N/M M' and el.emp_code=s.emp_code and to_date(el.leave_frdate) >= to_date('1/jan/2012')) as leave_taken, sum(lm.leave_days) as balance_leave, s.leave_seq from hrm_leave_apply_sanction s, leave_sanction_authority a, employee_master m, branch_master  b, designation_mst d,post_mst  p, department_mst  dep,  leave_master   l,employ_leave_master lm where a.emp_code = s.emp_code and m.branch_id=b.branch_id and a.emp_code = m.emp_code and s.emp_code=lm.emp_code and s.leave_id=lm.leave_id and m.designation_id = d.designation_id and m.post_id = p.post_id and m.department_id = dep.dep_id and s.leave_id = l.leave_id and s.status_id in (0) and a.l_rec_by = '" & user(0) & "' and m.branch_id <> 0 group by s.emp_code,m.emp_name,b.branch_name, d.designation, p.post_name,m.join_dt,dep.dep_name, s.leave_frdate, s.leave_todate,l.leave_abbr,s.leave_days,s.leave_seq")


        End If
        dsOut = objHelper.ExecuteDataSet(strBuild.ToString)
        If dsOut.Tables.Count > 0 AndAlso dsOut.Tables(0).Rows.Count > 0 Then
            Dim dgGrid As New GridView
            dgGrid.AutoGenerateColumns = False
            dgGrid.EnableViewState = False
            dgGrid.Font.Name = "Times New Roman"
            dgGrid.HeaderStyle.BackColor = Drawing.Color.LightGray
            dgGrid.HeaderStyle.Font.Size = New FontUnit(FontSize.Smaller)
            dgGrid.HeaderStyle.HorizontalAlign = HorizontalAlign.Left
            dgGrid.RowStyle.VerticalAlign = VerticalAlign.Top
            dgGrid.RowStyle.Font.Size = New FontUnit(FontSize.Smaller)

            For i As Integer = 0 To dsOut.Tables(0).Columns.Count - 1
                Dim dbField As New BoundField
                dbField.HeaderText = dsOut.Tables(0).Columns(i).ColumnName
                dbField.DataField = dsOut.Tables(0).Columns(i).ColumnName
                dgGrid.Columns.Add(dbField)
            Next
            dgGrid.DataSource = dsOut
            dgGrid.DataBind()
            Dim fname As String = "Leave Report.xls"
            GridViewExportUtil.Export(fname, dgGrid)
        End If
    End Sub


    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return backResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        backResult = ""
        Dim data() As String = eventArgument.Split("*")
        Select Case CInt(data(0))
            Case 1
                Dim brid As Integer = data(1)
                Dim dt1, dt As New DataTable
                sql = "select -1,'--------------Select-----------' as emp from dual union all select t.emp_id,a.EMP_NAME from form_accessibility t , emp_master a  where t.emp_id=a.EMP_CODE and t.form_id=" & brid & " order by emp"
                dt1 = objHelper.ExecuteDataSet(sql).Tables(0)

                For i As Integer = 0 To dt1.Rows.Count - 1
                    backResult += dt1.Rows(i)(0).ToString
                    backResult += "@"
                    backResult += dt1.Rows(i)(1).ToString
                    If i < dt1.Rows.Count - 1 Then
                        backResult += "%"
                    End If
                Next
           
        End Select
    End Sub
End Class


