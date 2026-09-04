Imports System.Data
Imports System.Data.OracleClient
Partial Class EXTRAFORMS_Hrm_Earlygoing_status_rpt1_a2e43fec8207
    Inherits System.Web.UI.Page
    Dim RH As New WholeHelper.ClsRepCtrl
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim tb As New Table
    Dim BrID As Integer
    Dim BranchName As String
    Dim dr As DataRow
    Dim tot_count As Double
    Dim from_dt, to_dt As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        from_dt = Request.QueryString.Get("from_dt")
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim ff As Integer = Session("firm_id")
        Dim UserId As Integer = User(0)
        dt = oh.ExecuteDataSet("select branch_name from branch_master where branch_id=" & BrID & "").Tables(0)
        BranchName = dt.Rows(0)(0)
        'dt = oh.ExecuteDataSet("select e.emp_code,em.old_code,e.emp_name,d.designation,dm.dep_name,p.post_name,f.firm_abbr from employee_master    e,post_mst   p,designation_master d,department_mst     dm,emp_new_old_code   em,firm_master   f where e.emp_code = em.new_code and e.post_id = p.post_id  and e.designation_id = d.designation_id  and e.department_id = dm.dep_id  and e.firm_id = f.firm_id  and e.status_id = 1 order by e.emp_code,f.firm_abbr").Tables(0)
       
        RH.Heading(Session("branch_id"), Session("branch_name"), Session("firm_name"), tb, "EMPLOYEES DETAILS", 73)

        Dim tr07 As New TableRow
        tr07.ForeColor = Drawing.Color.Maroon
        Dim tr07_01, tr07_02, tr07_03, tr07_04, tr07_05, tr07_06, tr07_07, tr07_08, tr07_09, tr07_10 As New TableCell
        RH.AddColumn(tr07, tr07_01, 1, 1, "l", "<b><font name=Californian FB>EMP&nbsp;CODE&nbsp;</font>")
        RH.AddColumn(tr07, tr07_02, 1, 1, "l", "<b>OLD&nbsp;CODE&nbsp;")
        RH.AddColumn(tr07, tr07_03, 8, 12, "2", "<b>EMP&nbsp;NAME&nbsp;")
        RH.AddColumn(tr07, tr07_04, 8, 50, "2", "<b>DESIGNATION&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_05, 8, 100, "5", "<b>DEPARTMENT&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_06, 8, 150, "9", "<b>POST&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_07, 5, 200, "14", "<b>BRANCH&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_08, 5, 25, "1", "<b>JOIN&nbsp;DATE&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_09, 5, 10, "l", "<b>BASIC&nbsp;")
        RH.AddColumn(tr07, tr07_10, 5, 55, "3", "<b>FIRM&nbsp;&nbsp;&nbsp;")
        tb.Controls.Add(tr07)
        RH.DrawLine(tb, 73)
        'OLD QUERRY
        'dt = oh.ExecuteDataSet("select  e.emp_code, nvl(em.old_code,e.emp_code) as old_code,e.emp_name,d.designation,dm.dep_name,p.post_name,b.branch_name as BRANCH,nvl(em.old_joindt,e.join_dt) as JOIN_DT,e.basic_pay as CTC,f.firm_abbr as FIRM from employee_master     e join employ_transfer_dtl td on td.emp_code=e.emp_code and (to_date('" & from_dt & "') between td.from_dt and nvl(td.to_dt,to_date(sysdate)))   join branch_master b on b.branch_id=td.branch_id  left join post_mst p on p.post_id=e.post_id  left join designation_master  d on d.designation_id=e.designation_id  left join department_mst   dm on dm.dep_id=e.department_id  left join emp_new_old_live em on em.new_code=e.emp_code join employ_firm   ef on ef.emp_code=e.emp_code join  firm_master  f on f.firm_id=ef.firm_id  join employee_master_dtl emd on emd.emp_code=e.emp_code  where  f.firm_id = 24  and (nvl(to_date(emd.discont_dt), to_date(sysdate))>=to_date('" & from_dt & "')) and e.join_dt <=  to_date('" & from_dt & "') union select  e.emp_code, nvl(em.old_code,e.emp_code) as old_code,e.emp_name,d.designation,dm.dep_name,p.post_name,bn.branch_name as BRANCH,nvl(em.old_joindt,e.join_dt) as JOIN_DT,e.basic_pay as CTC,f.firm_abbr as FIRM from employee_master     e join employ_transfer_dtl td on td.emp_code=e.emp_code and (to_date('" & from_dt & "') between td.from_dt and nvl(td.to_dt,to_date(sysdate)))  join before_completion bn on bn.old_id =td.branch_id  left join post_mst p on p.post_id=e.post_id  left join designation_master  d on d.designation_id=e.designation_id  left join department_mst   dm on dm.dep_id=e.department_id  left join emp_new_old_live em on em.new_code=e.emp_code join employ_firm   ef on ef.emp_code=e.emp_code join  firm_master  f on f.firm_id=ef.firm_id  join employee_master_dtl emd on emd.emp_code=e.emp_code  where  f.firm_id = 24  and (nvl(to_date(emd.discont_dt), to_date(sysdate))>=to_date('" & from_dt & "')) and e.join_dt <=  to_date('" & from_dt & "')").Tables(0)
        ''''KRISHNDAS QUERRY CHANGED

        dt = oh.ExecuteDataSet("select t.emp_code,       nvl(em.old_code, t.emp_code) as old_code,       t.emp_name,       m.designation,       d.dep_name,       p.post_name,       b.branch_name,       nvl(em.old_joindt, t.join_dt) as JOIN_DT,       t.basic_pay,   fm.firm_abbr  from employee_master t  join employ_firm f on f.emp_code = t.emp_code   and f.firm_id in (" & ff & ")  join firm_master fm on fm.firm_id = f.firm_id  join post_mst p on p.post_id = t.post_id  join designation_mst m on m.designation_id = t.designation_id  join department_mst d on d.dep_id = t.department_id  join branch_master b on b.branch_id = t.branch_id  left join emp_new_old_live em on em.new_code = t.emp_code where to_date(t.join_dt) <= to_date('" & from_dt & "')   and t.status_id = 1 and t.post_id not in (324) union  select t.emp_code,       nvl(em.old_code, t.emp_code) as old_code,       t.emp_name,       m.designation,       d.dep_name,       p.post_name,       b.branch_name,       nvl(em.old_joindt, t.join_dt) as JOIN_DT,       t.basic_pay,       fm.firm_abbr  from employee_master t   join employ_firm f on f.emp_code = t.emp_code      and f.firm_id in (" & ff & ")  join firm_master fm on fm.firm_id = f.firm_id  join post_mst p on p.post_id = t.post_id  join designation_mst m on m.designation_id = t.designation_id  join department_mst d on d.dep_id = t.department_id  join branch_master b on b.branch_id = t.branch_id  left join emp_new_old_live em on em.new_code = t.emp_code  join employee_master_dtl d2 on d2.emp_code=t.emp_code and d2.discont_dt > to_date('" & from_dt & "')  where t.status_id<>1  and to_date(t.join_dt)<= to_date('" & from_dt & "') and t.post_id not in (324) order by 1").Tables(0)
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
        Dim s As String = "0"

        For Each dr In dt.Rows
            Dim tr09 As New TableRow
            Dim tr09_01, tr09_02, tr09_03, tr09_04, tr09_05, tr09_06, tr09_07, tr09_08, tr09_09, tr09_10 As New TableCell
            If RowBG = 0 Then
                tr09.BackColor = Drawing.Color.Snow
                tr09.Font.Size = 10
                tr09.BorderColor = Drawing.Color.DarkBlue
                RowBG = 1
                tr09.Font.Name = "Courier New"
                ''tr09.Font.Bold = True
            Else
                tr09.BackColor = Drawing.Color.Honeydew
                tr09.Font.Size = 10
                tr09.BorderColor = Drawing.Color.DarkBlue
                RowBG = 0
                tr09.Font.Name = "Courier New"
                ''tr09.Font.Bold = True



            End If
            RH.AddColumn(tr09, tr09_01, 1, 1, "l", dr(0))
            RH.AddColumn(tr09, tr09_02, 1, 1, "l", dr(1))
            RH.AddColumn(tr09, tr09_03, 8, 12, "2", dr(2))
            RH.AddColumn(tr09, tr09_04, 8, 50, "2", dr(3))
            RH.AddColumn(tr09, tr09_05, 8, 100, "5", dr(4))
            RH.AddColumn(tr09, tr09_06, 8, 150, "9", dr(5))
            RH.AddColumn(tr09, tr09_07, 5, 200, "14", dr(6))
            RH.AddColumn(tr09, tr09_08, 5, 25, "2", dr(7))
            If IsDBNull(dr(8)) Then
                dr(8) = 0

            End If

            RH.AddColumn(tr09, tr09_09, 5, 10, "l", dr(8))
            RH.AddColumn(tr09, tr09_10, 5, 55, "3", dr(9))
            tb.Controls.Add(tr09)
            tot_count += 1
        Next
        RH.DrawLine(tb, 73)
        Dim tr10 As New TableRow
        Dim tr10_01, tr10_02, tr10_03 As New TableCell
        tr10.BackColor = Drawing.Color.AliceBlue
        RH.AddColumn(tr10, tr10_01, 10, 5, "l", "TOTAL :&nbsp;&nbsp;&nbsp;&nbsp;" & "<b>" & tot_count)
        RH.AddColumn(tr10, tr10_03, 43, 5, "r", "")
        tb.Controls.Add(tr10)
        RH.DrawLine(tb, 73)
        Panel1.Controls.Add(tb)
    End Sub


End Class
