Imports System.Data
Imports System.Data.OracleClient
Partial Class EXTRAFORMS_Hrm_Earlygoing_status_rpt1_a2e43fec5400
    Inherits System.Web.UI.Page
    Dim RH As New WholeHelper.ClsRepCtrl
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim tb As New Table
    Dim BrID As Integer
    Dim BranchName As String
    Dim dr As DataRow
    Dim tot_count As Double
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim ff As Integer = Session("firm_id")
        Dim UserId As Integer = User(0)
        dt = oh.ExecuteDataSet("select branch_name from branch_master where branch_id=" & BrID & "").Tables(0)
        BranchName = dt.Rows(0)(0)

        'dt = oh.ExecuteDataSet("select e.emp_code,em.old_code,e.emp_name,d.designation,dm.dep_name,p.post_name,f.firm_abbr from employee_master    e,post_mst   p,designation_master d,department_mst     dm,emp_new_old_code   em,firm_master   f where e.emp_code = em.new_code and e.post_id = p.post_id  and e.designation_id = d.designation_id  and e.department_id = dm.dep_id  and e.firm_id = f.firm_id  and e.status_id = 1 order by e.emp_code,f.firm_abbr").Tables(0)
        If ff <> 24 Then
            RH.Heading(Session("branch_id"), Session("branch_name"), Session("firm_name"), tb, "EMPLOYEES DETAILS", 39)
            Dim tr07 As New TableRow
            tr07.ForeColor = Drawing.Color.Maroon
            Dim tr07_01, tr07_02, tr07_03, tr07_04, tr07_05, tr07_06, tr07_07 As New TableCell
            RH.AddColumn(tr07, tr07_01, 1, 1, "l", "<b>EMP&nbsp;CODE&nbsp;")
            RH.AddColumn(tr07, tr07_02, 1, 1, "l", "<b>OLD&nbsp;CODE&nbsp;")
            RH.AddColumn(tr07, tr07_03, 8, 8, "l", "<b>EMP&nbsp;NAME&nbsp;")
            RH.AddColumn(tr07, tr07_04, 8, 8, "l", "<b>DESIGNATION&nbsp;&nbsp;")
            RH.AddColumn(tr07, tr07_05, 8, 8, "l", "<b>DEPARTMENT&nbsp;&nbsp;&nbsp;&nbsp;")
            RH.AddColumn(tr07, tr07_06, 8, 8, "l", "<b>POST&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
            RH.AddColumn(tr07, tr07_07, 5, 5, "l", "<b>FIRM&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
            tb.Controls.Add(tr07)
            RH.DrawLine(tb, 39)
            If ff = 24 Then
                dt = oh.ExecuteDataSet("select e.emp_code, em.old_code, e.emp_name, d.designation, dm.dep_name, p.post_name, f.firm_abbr, decode(e.status_id,1,'LIVE',10,'MATERNITY',6,'LONG LEAVE') from employee_master e, post_mst_jwell  p, designation_master d, department_mst dm, emp_new_old_code_jewel em, firm_master f, employ_firm ef where e.emp_code = em.new_code and e.post_id = p.post_id and e.designation_id = d.designation_id and e.department_id = dm.dep_id and e.emp_code = ef.emp_code and ef.firm_id = f.firm_id and f.firm_id = 24 and e.status_id in (1, 10, 6) order by e.emp_code, f.firm_abbr").Tables(0)
            End If
            If ff <> 24 Then
                dt = oh.ExecuteDataSet("select e.emp_code,  em.old_code,  e.emp_name,  d.designation,  dm.dep_name,  p.post_name,  f.firm_abbr  from employee_master    e,  post_mst           p,  designation_master d,  department_mst     dm,  emp_new_old_code   em,  firm_master        f,  employ_firm ef  where e.emp_code = em.new_code  and e.post_id = p.post_id  and e.designation_id = d.designation_id  and e.department_id = dm.dep_id  and e.emp_code=ef.emp_code  and ef.firm_id=f.firm_id  and f.firm_id=" & Session("firm_id") & "  and e.status_id = 1  order by e.emp_code, f.firm_abbr").Tables(0)
            End If
            If dt.Rows.Count <= 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('No Details !!!!');")
                cl_script0.Append("window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            End If
            Dim RowBG As Integer = 0
            Dim ItemTotal As Integer = 0
            tot_count = 0
            Dim Total As Double = 0
            For Each dr In dt.Rows
                Dim tr09 As New TableRow
                Dim tr09_01, tr09_02, tr09_03, tr09_04, tr09_05, tr09_06, tr09_07 As New TableCell
                If RowBG = 0 Then
                    tr09.BackColor = Drawing.Color.AliceBlue
                    RowBG = 1
                Else
                    tr09.BackColor = Drawing.Color.MintCream
                    RowBG = 0
                End If
                RH.AddColumn(tr09, tr09_01, 1, 1, "l", dr(0))
                RH.AddColumn(tr09, tr09_02, 1, 1, "l", dr(1))
                RH.AddColumn(tr09, tr09_03, 8, 8, "l", dr(2))
                RH.AddColumn(tr09, tr09_04, 8, 8, "l", dr(3))
                RH.AddColumn(tr09, tr09_05, 8, 8, "l", dr(4))
                RH.AddColumn(tr09, tr09_06, 8, 8, "l", dr(5))
                RH.AddColumn(tr09, tr09_07, 5, 5, "l", dr(6))
                tb.Controls.Add(tr09)
                tot_count += 1
            Next
            RH.DrawLine(tb, 39)
            Dim tr10 As New TableRow
            Dim tr10_01, tr10_02, tr10_03 As New TableCell
            tr10.BackColor = Drawing.Color.AliceBlue
            RH.AddColumn(tr10, tr10_01, 10, 5, "l", "TOTAL :&nbsp;&nbsp;&nbsp;&nbsp;" & "<b>" & tot_count)
            RH.AddColumn(tr10, tr10_03, 29, 5, "r", "")
            tb.Controls.Add(tr10)
            RH.DrawLine(tb, 39)
            Panel1.Controls.Add(tb)
        Else
            RH.Heading(Session("branch_id"), Session("branch_name"), Session("firm_name"), tb, "EMPLOYEES DETAILS", 70)
            Dim tr07 As New TableRow
            tr07.ForeColor = Drawing.Color.Maroon
            Dim tr07_01, tr07_02, tr07_03, tr07_04, tr07_05, tr07_06, tr07_07, tr07_08, tr07_09, tr07_10, tr07_11 As New TableCell
            RH.AddColumn(tr07, tr07_01, 1, 1, "l", "<b>EMP&nbsp;CODE&nbsp;")
            RH.AddColumn(tr07, tr07_02, 1, 1, "l", "<b>OLD&nbsp;CODE&nbsp;")
            RH.AddColumn(tr07, tr07_03, 8, 8, "l", "<b>EMP&nbsp;NAME&nbsp;")
            RH.AddColumn(tr07, tr07_04, 8, 8, "l", "<b>DESIGNATION&nbsp;&nbsp;")
            RH.AddColumn(tr07, tr07_05, 8, 8, "l", "<b>DEPARTMENT&nbsp;&nbsp;&nbsp;&nbsp;")
            RH.AddColumn(tr07, tr07_06, 8, 8, "l", "<b>POST&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
            RH.AddColumn(tr07, tr07_07, 5, 5, "l", "<b>BRANCH&nbsp;&nbsp;&nbsp;")
            RH.AddColumn(tr07, tr07_08, 5, 5, "l", "<b>JOIN&nbsp;DATE")
            RH.AddColumn(tr07, tr07_09, 5, 5, "l", "<b>CTC&nbsp;")
            RH.AddColumn(tr07, tr07_10, 5, 5, "l", "<b>FIRM&nbsp;&nbsp;&nbsp;")
            RH.AddColumn(tr07, tr07_11, 8, 8, "l", "<b>STATUS&nbsp;&nbsp;&nbsp;")
            tb.Controls.Add(tr07)
            RH.DrawLine(tb, 70)
            'dt = oh.ExecuteDataSet("select e.emp_code,  em.old_code,  e.emp_name,  d.designation,  dm.dep_name,  p.post_name,  f.firm_abbr  from employee_master    e,  post_mst           p,  designation_master d,  department_mst     dm,  emp_new_old_code   em,  firm_master        f,  employ_firm ef  where e.emp_code = em.new_code  and e.post_id = p.post_id  and e.designation_id = d.designation_id  and e.department_id = dm.dep_id  and e.emp_code=ef.emp_code  and ef.firm_id=f.firm_id  and f.firm_id=" & Session("firm_id") & "  and e.status_id = 1  order by e.emp_code, f.firm_abbr").Tables(0)
            ' dt = oh.ExecuteDataSet("select e.emp_code as EMP_CODE, em.old_code as OLD_CODE, e.emp_name as EMPLOYNAME,d.designation as DESIGNATION, dm.dep_name as DEPARTMENT, p.post_name,b.branch_name as BRANCH,es.join_dt as JOIN_DT,w.actual_basic+w.actual_da+w.ta_total+w.bonus+w.e_esi+w.e_pf as CTC, f.firm_abbr as FIRM from employee_master  e,post_mst   p,employee_master es,designation_master d,department_mst     dm, emp_new_old_live   em,firm_master   f,employ_firm  ef,branch_master b,m_wage w where e.emp_code = em.new_code and b.branch_id=e.branch_id and e.emp_code=w.emp_code  and e.post_id = p.post_id and em.old_code=es.emp_code  and e.designation_id = d.designation_id and e.department_id = dm.dep_id  and e.emp_code = ef.emp_code  and ef.firm_id = f.firm_id and f.firm_id = " & Session("firm_id") & " and e.status_id = 1 order by e.emp_code, f.firm_abbr").Tables(0)
            'dt = oh.ExecuteDataSet("select e.emp_code ,em.old_code ,e.emp_name ,d.designation ,dm.dep_name ,p.post_name,b.branch_name as BRANCH,es.join_dt as JOIN_DT,w.actual_basic + w.actual_da + nvl(all_amount,0) + w.bonus + w.e_esi +w.e_pf as CTC,f.firm_abbr as FIRM  from employee_master    e, post_mst           p,employee_master    es,designation_master d,department_mst     dm,emp_new_old_live   em,firm_master        f,employ_firm        ef,branch_master      b,m_wage             w left outer join (select emp_code ,nvl(sum(all_amount),0) all_amount from incentives_allowances_dtl dd where dd.all_id in(9,1,75,57,52,55,66,69,3,78,41,7,8) group by emp_code) x on(w.emp_code=x.emp_code) where e.emp_code = em.new_code and b.branch_id = e.branch_id and e.emp_code = w.emp_code and e.post_id = p.post_id and em.old_code = es.emp_code and e.designation_id = d.designation_id  and e.department_id = dm.dep_id and e.emp_code = ef.emp_code and ef.firm_id = f.firm_id and f.firm_id =24 and e.status_id = 1 order by e.emp_code, f.firm_abbr").Tables(0)
            If ff = 24 Then
                dt1 = oh.ExecuteDataSet("select query from hrm_report_master where firm_id=24 and query_id=132").Tables(0)
                dt = oh.ExecuteDataSet(dt1.Rows(0)(0)).Tables(0)
            End If
            If ff <> 24 Then
                dt = oh.ExecuteDataSet("select e.emp_code,em.old_code,e.emp_name,d.designation,dm.dep_name,p.post_name,b.branch_name as BRANCH,es.join_dt as JOIN_DT,e.basic_pay+nvl(all_amount, 0) +nvl(bonus,0) +(case when e.da_flag='T' then (select value from da_index where to_dt is null and firm_id=24) else 0 end )+nvl(e_esi,0) + nvl(e_pf,0) as CTC,f.firm_abbr as FIRM  from employee_master    e left outer join ( select w.emp_code,w.actual_basic,w.actual_da,w.bonus,w.e_esi,w.e_pf from m_wage  w ) ee on(e.emp_code=ee.emp_code),post_mst  p,designation_master d,department_mst     dm,emp_new_old_live   em,firm_master        f,employ_firm        ef, branch_master      b,employee_master    es left outer join (select emp_code, nvl(sum(all_amount), 0) all_amount  from incentives_allowances_dtl dd where dd.all_id in (9, 1, 75, 57, 52, 55, 66, 69, 3, 78, 41, 7, 8) group by emp_code) x on (es.emp_code = x.emp_code) where e.emp_code = em.new_code and b.branch_id = e.branch_id  and e.post_id = p.post_id  and em.old_code = es.emp_code  and e.designation_id = d.designation_id  and e.department_id = dm.dep_id  and e.emp_code = ef.emp_code and ef.firm_id = f.firm_id and f.firm_id = 24 and e.status_id = 1  union  select e.emp_code,em.old_code,e.emp_name,d.designation,dm.dep_name,p.post_name,b.branch_name as BRANCH,es.join_dt as JOIN_DT,e.basic_pay+nvl(all_amount, 0) +nvl(bonus,0) +(case when e.da_flag='T' then (select value from da_index where to_dt is null and firm_id=24) else 0 end )+nvl(e_esi,0) + nvl(e_pf,0) as CTC,f.firm_abbr as FIRM  from employee_master    e left outer join ( select w.emp_code,w.actual_basic,w.actual_da,w.bonus,w.e_esi,w.e_pf from m_wage  w ) ee on(e.emp_code=ee.emp_code),post_mst  p,designation_master d,department_mst     dm,emp_new_old_live   em,firm_master        f,employ_firm        ef, before_completion      b,employee_master    es left outer join (select emp_code, nvl(sum(all_amount), 0) all_amount  from incentives_allowances_dtl dd where dd.all_id in (9, 1, 75, 57, 52, 55, 66, 69, 3, 78, 41, 7, 8) group by emp_code) x on (es.emp_code = x.emp_code) where e.emp_code = em.new_code and b.old_id = e.branch_id  and e.post_id = p.post_id  and em.old_code = es.emp_code  and e.designation_id = d.designation_id  and e.department_id = dm.dep_id  and e.emp_code = ef.emp_code and ef.firm_id = f.firm_id and f.firm_id = 24 and e.status_id = 1 order by emp_code,FIRM").Tables(0)
            End If
            If dt.Rows.Count <= 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('No Details !!!!');")
                cl_script0.Append("window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            End If
            Dim RowBG As Integer = 0
            Dim ItemTotal As Integer = 0
            tot_count = 0
            Dim Total As Double = 0
            For Each dr In dt.Rows
                Dim tr09 As New TableRow
                Dim tr09_01, tr09_02, tr09_03, tr09_04, tr09_05, tr09_06, tr09_07, tr09_08, tr09_09, tr09_10, tr09_11 As New TableCell
                If RowBG = 0 Then
                    tr09.BackColor = Drawing.Color.AliceBlue
                    RowBG = 1
                Else
                    tr09.BackColor = Drawing.Color.MintCream
                    RowBG = 0
                End If
                RH.AddColumn(tr09, tr09_01, 1, 1, "l", dr(0))
                RH.AddColumn(tr09, tr09_02, 1, 1, "l", dr(1))
                RH.AddColumn(tr09, tr09_03, 8, 8, "l", dr(2))
                RH.AddColumn(tr09, tr09_04, 8, 8, "l", dr(3))
                RH.AddColumn(tr09, tr09_05, 8, 8, "l", dr(4))
                RH.AddColumn(tr09, tr09_06, 8, 8, "l", dr(5))
                RH.AddColumn(tr09, tr09_07, 5, 5, "l", dr(6))
                RH.AddColumn(tr09, tr09_08, 5, 5, "l", dr(7))
                RH.AddColumn(tr09, tr09_09, 5, 5, "l", dr(8))
                RH.AddColumn(tr09, tr09_10, 5, 5, "l", dr(9))
                RH.AddColumn(tr09, tr09_11, 5, 5, "l", dr(10))
                tb.Controls.Add(tr09)
                tot_count += 1
            Next
            RH.DrawLine(tb, 70)
            Dim tr10 As New TableRow
            Dim tr10_01, tr10_02, tr10_03 As New TableCell
            tr10.BackColor = Drawing.Color.AliceBlue
            RH.AddColumn(tr10, tr10_01, 10, 5, "l", "TOTAL :&nbsp;&nbsp;&nbsp;&nbsp;" & "<b>" & tot_count)
            RH.AddColumn(tr10, tr10_03, 43, 5, "r", "")
            tb.Controls.Add(tr10)
            RH.DrawLine(tb, 70)
            Panel1.Controls.Add(tb)
        End If


    End Sub
End Class
