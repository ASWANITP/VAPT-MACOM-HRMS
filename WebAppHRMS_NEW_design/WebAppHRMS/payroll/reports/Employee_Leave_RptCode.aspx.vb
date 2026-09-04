Imports System.Data
Imports System.Data.OracleClient
Partial Class Store_drill_storeinventorylist_72e46ba67609
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dtb, dt6, dt7, dt8, dt9, dt10, dt11, dt12 As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
     
        Dim brid = Me.Session("branch_id")
        Dim frdt As String = Request.QueryString.Get("frdt")
        Dim todt As String = Request.QueryString.Get("todt")
        Dim Deptid As String = Request.QueryString.Get("dept")
        Dim Dept_Name As String = Request.QueryString.Get("dept_name")

        Dim sql As String
        Dim dt, dt1, dtb As New DataTable
        Dim dr As DataRow
        Dim SlNo As Integer = 0
        Dim flg As Integer = 0
        Dim color As Integer = 0
       
        If Deptid <> -2 Then ' --- department wise ---
            sql = "select cc.emp_code,cc.emp_name,cc.status,cc.designation,cc.post_name,cc.department,cc.gender,cc.joindt,cc.casual,cc.sick,cc.Earned,cc.lop,cc.total,nvl(lms.leave_days,0) ,nvl(lms1.leave_days,0),nvl(lms2.leave_days,0) from( select k.emp_code,k.emp_name,k.status, k.designation, k.post_name, k.department, k.gender, k.joindt, k.casual, k.sick, k.Earned, k.LOP, k.casual + k.sick + k.Earned + k.LOP as total from (select z.emp_code, z.emp_name, z.status, z.designation, z.post_name, z.department, z.gender, z.joindt, z.casual, z.sick, z.Earned, nvl(sum(llop.leave_days), 0) as LOP from (select y.emp_code, y.emp_name, y.status, y.designation, y.post_name, y.department, y.gender, y.joindt, y.casual, y.sick, nvl(sum(le.leave_days), 0) as Earned from (select x.emp_code,x.emp_name, x.status, x.designation, x.post_name, x.department, x.gender, x.joindt,  x.casual, nvl(sum(lsick.leave_days), 0) as Sick from (select t.emp_code, t.emp_name, decode(t.status_id, 1, 'LIVE', 'NOT LIVE') as status, c.designation, d.post_name, e.dep_name department, decode(f.sex, 1, 'M', 'F') as gender, to_char(t.join_dt, 'dd-Mon-yyyy') as joindt, nvl(sum(lc.leave_days), 0) as casual from employee_master t join employ_firm b on b.emp_code =       t.emp_code   and b.firm_id =       " & Me.Session("Firm_id") & " join designation_mst c on c.designation_id =           t.designation_id join post_mst d on d.post_id =    t.post_id join department_mst e on e.dep_id =          t.department_id join employ_personal_dtl f on f.emp_code = t.emp_code left join employ_leave_dtl lc on lc.emp_code =   t.emp_code              and lc.leave_process_id = 1              and lc.leave_id in (1)              and lc.leave_frdate between                 to_date('" & frdt & "') and                 to_date('" & todt & "') where t.department_id = " & Deptid & " and t.status_id = 1 and t.join_dt <= to_date('" & todt & "') group by t.emp_code, t.emp_name, c.designation, d.post_name, e.dep_name, f.sex, t.join_dt, t.status_id) x left join employ_leave_dtl lsick on lsick.emp_code =             x.emp_code         and lsick.leave_process_id = 1         and lsick.leave_id in (2)         and lsick.leave_frdate between to_date('" & frdt & "') and to_date('" & todt & "') group by x.emp_code, x.emp_name, x.designation, x.post_name, x.department, x.gender, x.joindt, x.casual, x.status) y left join employ_leave_dtl le on le.emp_code =  y.emp_code and le.leave_process_id = 1 and le.leave_id in (3) and le.leave_frdate between  to_date('" & frdt & "') and  to_date('" & todt & "') group by y.emp_code, y.emp_name, y.designation, y.post_name, y.department, y.gender, y.joindt, y.casual, y.sick, y.status) z left join employ_leave_dtl llop on llop.emp_code = z.emp_code and llop.leave_process_id in (1, 2) and llop.leave_id in (4) and llop.leave_frdate between to_date('" & frdt & "') and to_date('" & todt & "') group by z.emp_code, z.emp_name, z.designation, z.post_name, z.department, z.gender, z.joindt, z.casual, z.sick, z.earned, z.status union select z.emp_code, z.emp_name, z.status, z.designation, z.post_name, z.department, z.gender, z.joindt, z.casual,  z.sick, z.Earned, nvl(sum(llop.leave_days), 0) as LOP from (select y.emp_code, y.emp_name, y.status, y.designation, y.post_name, y.department, y.gender, y.joindt, y.casual, y.sick, nvl(sum(le.leave_days), 0) as Earned from (select x.emp_code, x.emp_name, x.status, x.designation, x.post_name, x.department, x.gender, x.joindt, x.casual, nvl(sum(lsick.leave_days), 0) as Sick from (select t.emp_code, t.emp_name, decode(t.status_id, 1, 'LIVE', 'NOT LIVE') as status, c.designation, d.post_name, e.dep_name department, decode(f.sex, 1, 'M', 'F') as gender, to_char(t.join_dt, 'dd-Mon-yyyy') as joindt, nvl(sum(lc.leave_days), 0) as casual from employee_master t join employ_firm b on b.emp_code =       t.emp_code   and b.firm_id =       " & Me.Session("Firm_id") & " join designation_mst c on c.designation_id =           t.designation_id join post_mst d on d.post_id =    t.post_id join department_mst e on e.dep_id =          t.department_id join employ_personal_dtl f on f.emp_code = t.emp_code join employee_master_dtl md on t.emp_code = md.emp_code and to_date(md.discont_dt) between to_date('" & frdt & "') and to_date('" & todt & "') left join employ_leave_dtl lc on lc.emp_code = t.emp_code and lc.leave_process_id = 1 and lc.leave_id in (1) and lc.leave_frdate between to_date('" & frdt & "') and to_date('" & todt & "') where t.department_id = " & Deptid & " and t.status_id not in (1) group by t.emp_code, t.emp_name, c.designation, d.post_name, e.dep_name, f.sex, t.join_dt, t.status_id) x left join employ_leave_dtl lsick on lsick.emp_code = x.emp_code and lsick.leave_process_id = 1 and lsick.leave_id in (2) and lsick.leave_frdate between to_date('" & frdt & "') and to_date('" & todt & "') group by x.emp_code, x.emp_name, x.designation, x.post_name, x.department, x.gender, x.joindt, x.casual, x.status) y left join employ_leave_dtl le on le.emp_code =  y.emp_code and le.leave_process_id = 1 and le.leave_id in (3) and le.leave_frdate between  to_date('" & frdt & "') and  to_date('" & todt & "') group by y.emp_code, y.emp_name,y.designation, y.post_name, y.department,y.gender, y.joindt, y.casual, y.sick, y.status) z left join employ_leave_dtl llop on llop.emp_code = z.emp_code and llop.leave_process_id in (1, 2) and llop.leave_id in (4) and llop.leave_frdate between to_date('" & frdt & "') and to_date('" & todt & "') group by z.emp_code, z.emp_name,z.designation, z.post_name,z.department,z.gender, z.joindt, z.casual, z.sick, z.earned, z.status union select z.emp_code, z.emp_name, z.status, z.designation, z.post_name, z.department, z.gender, z.joindt, z.casual, z.sick, z.Earned, nvl(sum(llop.leave_days), 0) as LOP from (select y.emp_code, y.emp_name, y.status, y.designation, y.post_name, y.department, y.gender, y.joindt, y.casual, y.sick, nvl(sum(le.leave_days), 0) as Earned from (select x.emp_code, x.emp_name, x.status, x.designation,  x.post_name,x.department, x.gender, x.joindt, x.casual, nvl(sum(lsick.leave_days), 0) as Sick from (select t.emp_code, t.emp_name, decode(t.status_id, 1,'LIVE', 'NOT LIVE') as status, c.designation, d.post_name, e.dep_name department,  decode(f.sex, 1, 'M', 'F') as gender,to_char(t.join_dt, 'dd-Mon-yyyy') as joindt, nvl(sum(lc.leave_days), 0) as casual from employee_master t join employ_firm b on b.emp_code = t.emp_code and b.firm_id = " & Me.Session("Firm_id") & " join designation_mst c on c.designation_id = t.designation_id join post_mst d on d.post_id = t.post_id join department_mst e on e.dep_id = t.department_id join employ_personal_dtl f on f.emp_code = t.emp_code join employee_master_dtl md on t.emp_code = md.emp_code left join employ_leave_dtl lc on lc.emp_code =t.emp_code and lc.leave_process_id = 1 and lc.leave_id in (1) and lc.leave_frdate between to_date('" & frdt & "') and to_date('" & todt & "') where t.department_id = " & Deptid & " and t.status_id not in (1) and t.join_dt <= to_date('" & todt & "') and md.discont_dt between to_date('" & frdt & "') and to_date(sysdate) group by t.emp_code,t.emp_name, c.designation, d.post_name, e.dep_name, f.sex, t.join_dt, t.status_id) x  left join employ_leave_dtl lsick on lsick.emp_code = x.emp_code and lsick.leave_process_id = 1 and lsick.leave_id in (2) and lsick.leave_frdate between to_date('" & frdt & "') and to_date('" & todt & "') group by x.emp_code, x.emp_name, x.designation, x.post_name, x.department,  x.gender,x.joindt, x.casual, x.status) y left join employ_leave_dtl le on le.emp_code = y.emp_code and le.leave_process_id = 1 and le.leave_id in (3) and le.leave_frdate between to_date('" & frdt & "') and to_date('" & todt & "') group by y.emp_code, y.emp_name, y.designation, y.post_name, y.department, y.gender, y.joindt, y.casual, y.sick, y.status) z left join employ_leave_dtl llop on llop.emp_code = z.emp_code and llop.leave_process_id in (1, 2) and llop.leave_id in (4) and llop.leave_frdate between to_date('" & frdt & "') and to_date('" & todt & "') group by z.emp_code, z.emp_name, z.designation, z.post_name, z.department, z.gender, z.joindt, z.casual, z.sick, z.earned, z.status) k  )cc left join employ_leave_master lms on cc.emp_code=lms.emp_code and lms.leave_id=1  left join employ_leave_master lms1 on cc.emp_code=lms1.emp_code and lms1.leave_id=2   left join employ_leave_master lms2 on cc.emp_code=lms2.emp_code and lms2.leave_id=3 order by emp_code"
        Else '--- ALL depatrtments ---
            sql = "select cc.emp_code,cc.emp_name,cc.status,cc.designation,cc.post_name,cc.department,cc.gender,cc.joindt,cc.casual,cc.sick,cc.Earned,cc.lop,cc.total,nvl(lms.leave_days,0) ,nvl(lms1.leave_days,0),nvl(lms2.leave_days,0) from( select k.emp_code,k.emp_name,k.status, k.designation, k.post_name, k.department, k.gender, k.joindt, k.casual, k.sick, k.Earned, k.LOP, k.casual + k.sick + k.Earned + k.LOP as total from (select z.emp_code, z.emp_name, z.status, z.designation, z.post_name, z.department, z.gender, z.joindt, z.casual, z.sick, z.Earned, nvl(sum(llop.leave_days), 0) as LOP from (select y.emp_code, y.emp_name, y.status, y.designation, y.post_name, y.department, y.gender, y.joindt, y.casual, y.sick, nvl(sum(le.leave_days), 0) as Earned from (select x.emp_code,x.emp_name, x.status, x.designation, x.post_name, x.department, x.gender, x.joindt,  x.casual, nvl(sum(lsick.leave_days), 0) as Sick from (select t.emp_code, t.emp_name, decode(t.status_id, 1, 'LIVE', 'NOT LIVE') as status, c.designation, d.post_name, e.dep_name department, decode(f.sex, 1, 'M', 'F') as gender, to_char(t.join_dt, 'dd-Mon-yyyy') as joindt, nvl(sum(lc.leave_days), 0) as casual from employee_master t join employ_firm b on b.emp_code =       t.emp_code   and b.firm_id =       " & Me.Session("Firm_id") & " join designation_mst c on c.designation_id =           t.designation_id join post_mst d on d.post_id =    t.post_id join department_mst e on e.dep_id =          t.department_id join employ_personal_dtl f on f.emp_code = t.emp_code left join employ_leave_dtl lc on lc.emp_code =   t.emp_code              and lc.leave_process_id = 1              and lc.leave_id in (1)              and lc.leave_frdate between                 to_date('" & frdt & "') and                 to_date('" & todt & "') where  t.status_id = 1 and t.join_dt <= to_date('" & todt & "') group by t.emp_code, t.emp_name, c.designation, d.post_name, e.dep_name, f.sex, t.join_dt, t.status_id) x left join employ_leave_dtl lsick on lsick.emp_code =             x.emp_code         and lsick.leave_process_id = 1         and lsick.leave_id in (2)         and lsick.leave_frdate between to_date('" & frdt & "') and to_date('" & todt & "') group by x.emp_code, x.emp_name, x.designation, x.post_name, x.department, x.gender, x.joindt, x.casual, x.status) y left join employ_leave_dtl le on le.emp_code =  y.emp_code and le.leave_process_id = 1 and le.leave_id in (3) and le.leave_frdate between  to_date('" & frdt & "') and  to_date('" & todt & "') group by y.emp_code, y.emp_name, y.designation, y.post_name, y.department, y.gender, y.joindt, y.casual, y.sick, y.status) z left join employ_leave_dtl llop on llop.emp_code = z.emp_code and llop.leave_process_id in (1, 2) and llop.leave_id in (4) and llop.leave_frdate between to_date('" & frdt & "') and to_date('" & todt & "') group by z.emp_code, z.emp_name, z.designation, z.post_name, z.department, z.gender, z.joindt, z.casual, z.sick, z.earned, z.status union select z.emp_code, z.emp_name, z.status, z.designation, z.post_name, z.department, z.gender, z.joindt, z.casual,  z.sick, z.Earned, nvl(sum(llop.leave_days), 0) as LOP from (select y.emp_code, y.emp_name, y.status, y.designation, y.post_name, y.department, y.gender, y.joindt, y.casual, y.sick, nvl(sum(le.leave_days), 0) as Earned from (select x.emp_code, x.emp_name, x.status, x.designation, x.post_name, x.department, x.gender, x.joindt, x.casual, nvl(sum(lsick.leave_days), 0) as Sick from (select t.emp_code, t.emp_name, decode(t.status_id, 1, 'LIVE', 'NOT LIVE') as status, c.designation, d.post_name, e.dep_name department, decode(f.sex, 1, 'M', 'F') as gender, to_char(t.join_dt, 'dd-Mon-yyyy') as joindt, nvl(sum(lc.leave_days), 0) as casual from employee_master t join employ_firm b on b.emp_code =       t.emp_code   and b.firm_id =       " & Me.Session("Firm_id") & " join designation_mst c on c.designation_id =           t.designation_id join post_mst d on d.post_id =    t.post_id join department_mst e on e.dep_id =          t.department_id join employ_personal_dtl f on f.emp_code = t.emp_code join employee_master_dtl md on t.emp_code = md.emp_code and to_date(md.discont_dt) between to_date('" & frdt & "') and to_date('" & todt & "') left join employ_leave_dtl lc on lc.emp_code = t.emp_code and lc.leave_process_id = 1 and lc.leave_id in (1) and lc.leave_frdate between to_date('" & frdt & "') and to_date('" & todt & "') where  t.status_id not in (1) group by t.emp_code, t.emp_name, c.designation, d.post_name, e.dep_name, f.sex, t.join_dt, t.status_id) x left join employ_leave_dtl lsick on lsick.emp_code = x.emp_code and lsick.leave_process_id = 1 and lsick.leave_id in (2) and lsick.leave_frdate between to_date('" & frdt & "') and to_date('" & todt & "') group by x.emp_code, x.emp_name, x.designation, x.post_name, x.department, x.gender, x.joindt, x.casual, x.status) y left join employ_leave_dtl le on le.emp_code =  y.emp_code and le.leave_process_id = 1 and le.leave_id in (3) and le.leave_frdate between  to_date('" & frdt & "') and  to_date('" & todt & "') group by y.emp_code, y.emp_name,y.designation, y.post_name, y.department,y.gender, y.joindt, y.casual, y.sick, y.status) z left join employ_leave_dtl llop on llop.emp_code = z.emp_code and llop.leave_process_id in (1, 2) and llop.leave_id in (4) and llop.leave_frdate between to_date('" & frdt & "') and to_date('" & todt & "') group by z.emp_code, z.emp_name,z.designation, z.post_name,z.department,z.gender, z.joindt, z.casual, z.sick, z.earned, z.status union select z.emp_code, z.emp_name, z.status, z.designation, z.post_name, z.department, z.gender, z.joindt, z.casual, z.sick, z.Earned, nvl(sum(llop.leave_days), 0) as LOP from (select y.emp_code, y.emp_name, y.status, y.designation, y.post_name, y.department, y.gender, y.joindt, y.casual, y.sick, nvl(sum(le.leave_days), 0) as Earned from (select x.emp_code, x.emp_name, x.status, x.designation,  x.post_name,x.department, x.gender, x.joindt, x.casual, nvl(sum(lsick.leave_days), 0) as Sick from (select t.emp_code, t.emp_name, decode(t.status_id, 1,'LIVE', 'NOT LIVE') as status, c.designation, d.post_name, e.dep_name department,  decode(f.sex, 1, 'M', 'F') as gender,to_char(t.join_dt, 'dd-Mon-yyyy') as joindt, nvl(sum(lc.leave_days), 0) as casual from employee_master t join employ_firm b on b.emp_code = t.emp_code and b.firm_id = " & Me.Session("Firm_id") & " join designation_mst c on c.designation_id = t.designation_id join post_mst d on d.post_id = t.post_id join department_mst e on e.dep_id = t.department_id join employ_personal_dtl f on f.emp_code = t.emp_code join employee_master_dtl md on t.emp_code = md.emp_code left join employ_leave_dtl lc on lc.emp_code =t.emp_code and lc.leave_process_id = 1 and lc.leave_id in (1) and lc.leave_frdate between to_date('" & frdt & "') and to_date('" & todt & "') where t.status_id not in (1) and t.join_dt <= to_date('" & todt & "') and md.discont_dt between to_date('" & frdt & "') and to_date(sysdate) group by t.emp_code,t.emp_name, c.designation, d.post_name, e.dep_name, f.sex, t.join_dt, t.status_id) x  left join employ_leave_dtl lsick on lsick.emp_code = x.emp_code and lsick.leave_process_id = 1 and lsick.leave_id in (2) and lsick.leave_frdate between to_date('" & frdt & "') and to_date('" & todt & "') group by x.emp_code, x.emp_name, x.designation, x.post_name, x.department,  x.gender,x.joindt, x.casual, x.status) y left join employ_leave_dtl le on le.emp_code = y.emp_code and le.leave_process_id = 1 and le.leave_id in (3) and le.leave_frdate between to_date('" & frdt & "') and to_date('" & todt & "') group by y.emp_code, y.emp_name, y.designation, y.post_name, y.department, y.gender, y.joindt, y.casual, y.sick, y.status) z left join employ_leave_dtl llop on llop.emp_code = z.emp_code and llop.leave_process_id in (1, 2) and llop.leave_id in (4) and llop.leave_frdate between to_date('" & frdt & "') and to_date('" & todt & "') group by z.emp_code, z.emp_name, z.designation, z.post_name, z.department, z.gender, z.joindt, z.casual, z.sick, z.earned, z.status) k  )cc left join employ_leave_master lms on cc.emp_code=lms.emp_code and lms.leave_id=1  left join employ_leave_master lms1 on cc.emp_code=lms1.emp_code and lms1.leave_id=2   left join employ_leave_master lms2 on cc.emp_code=lms2.emp_code and lms2.leave_id=3 order by emp_code"
        End If
        dt = oh.ExecuteDataSet(sql).Tables(0)


        Dim tb As New Table


        Dim tr1 As New TableRow
        tr1.BackColor = Drawing.Color.WhiteSmoke
        Dim td11 As New TableCell
        td11.ColumnSpan = 250
        td11.HorizontalAlign = HorizontalAlign.Center
        td11.Text = "<font size=4><b>" & Me.Session("firm_name") & "</b></font>"
        tr1.Controls.Add(td11)
        tb.Controls.Add(tr1)


       



        Dim tr2 As New TableRow
        tr2.BackColor = Drawing.Color.GhostWhite
        Dim td21 As New TableCell
        td21.ColumnSpan = 90
        td21.HorizontalAlign = HorizontalAlign.Right
        td21.Text = "<font size=3><b>Branch-id :" & Me.Session("branch_id") & "</b></font>"
        tr2.Controls.Add(td21)
        Dim td22 As New TableCell
        td22.ColumnSpan = 160
        td22.HorizontalAlign = HorizontalAlign.Left
        td22.Text = "<font size=3><b>Branch :" & Me.Session("branch_name") & "</b></font>"
        tr2.Controls.Add(td22)
        tb.Controls.Add(tr2)


        Dim tr3 As New TableRow
        tr3.BackColor = Drawing.Color.WhiteSmoke
        Dim td31 As New TableCell
        td31.ColumnSpan = 90
        td31.HorizontalAlign = HorizontalAlign.Left
        td31.Text = "<font size=2><b>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</b></font>"
        tr3.Controls.Add(td31)
        Dim td32 As New TableCell
        'td32.Attributes.Add("width", "50%")
        td32.ColumnSpan = 160
        td32.HorizontalAlign = HorizontalAlign.Right
        td32.Text = "<font size=2><b>Time :" & Format(Date.Now, "hh:mm:ss") & "</b></font>"
        tr3.Controls.Add(td32)
        tb.Controls.Add(tr3)



        Dim tr100 As New TableRow
        tr100.BackColor = Drawing.Color.WhiteSmoke
        Dim tr101 As New TableCell
        tr101.ColumnSpan = 250
        tr101.HorizontalAlign = HorizontalAlign.Center
        tr101.Text = "<font size=2><b>" & Dept_Name & "</b></font>"
        tr100.Controls.Add(tr101)
        tb.Controls.Add(tr100)
        Dim tr490 As New TableRow
        tr490.BackColor = Drawing.Color.WhiteSmoke
        Dim td410 As New TableCell
        'td410.Attributes.Add("width", "100%")
        td410.ColumnSpan = 250
        td410.HorizontalAlign = HorizontalAlign.Center
        sql = "select initcap(branch_name) from branch_master where branch_id=" & brid
        dtb = oh.ExecuteDataSet(sql).Tables(0)
        td410.Text = "<font size=3><b>Leave  Report From :&nbsp" & frdt & " &nbsp To :" & todt & " </b></font>"
        tr490.Controls.Add(td410)
        tb.Controls.Add(tr490)

        'Dim tr44 As New TableRow
        'tr44.BackColor = Drawing.Color.GhostWhite
        'Dim td414 As New TableCell
        'td414.Attributes.Add("width", "80%")
        'td414.ColumnSpan = 50
        'td414.HorizontalAlign = HorizontalAlign.Center
        'td414.Text = "<font size=2.5 color=Maroon><BR><b> EMPLOYEE NAME&nbsp:&nbsp" & dt1.Rows(0)(0) & "</b></font>"
        'tr44.Controls.Add(td414)


        Dim l1 As New TableRow
        Dim ld1 As New TableCell
        'ld1.Attributes.Add("width", "100%")
        ld1.ColumnSpan = 250
        ld1.HorizontalAlign = HorizontalAlign.Center
        ld1.Text = "<font size=3><hr size='2' NOSHADE></font>"
        l1.Controls.Add(ld1)
        tb.Controls.Add(l1)

        Dim tr5 As New TableRow
        tr5.BackColor = Drawing.Color.WhiteSmoke
        Dim td51 As New TableCell
        'td51.Attributes.Add("width", "2%")
        td51.ColumnSpan = 8
        td51.HorizontalAlign = HorizontalAlign.Left
        td51.Text = "<font size=2.5><b>EMP CODE</b></font>"
        tr5.Controls.Add(td51)


        Dim td55 As New TableCell
        'td55.Attributes.Add("width", "15%")
        td55.ColumnSpan = 22
        td55.HorizontalAlign = HorizontalAlign.Left
        td55.Text = "<font size=2.5><b>EMP NAME</b></font>"
        tr5.Controls.Add(td55)

        Dim td56 As New TableCell
        'td56.Attributes.Add("width", "10%")
        td56.ColumnSpan = 18
        td56.HorizontalAlign = HorizontalAlign.Center
        td56.Text = "<font size=2.5><b>STATUS</b></font>"
        tr5.Controls.Add(td56)


        Dim td58 As New TableCell
        'td58.Attributes.Add("width", "20%")
        td58.ColumnSpan = 25
        td58.HorizontalAlign = HorizontalAlign.Center
        td58.Text = "<font size=2.5><b>DESIGNATION</b></font>"
        tr5.Controls.Add(td58)


        Dim td158 As New TableCell
        ' td158.Attributes.Add("width", "20%")
        td158.ColumnSpan = 20
        td158.HorizontalAlign = HorizontalAlign.Left
        td158.Text = "<font size=2.5><b>POST</b></font>"
        tr5.Controls.Add(td158)
        If Deptid = -2 Then
            Dim td159 As New TableCell
            'td159.Attributes.Add("width", "30%")
            td159.ColumnSpan = 25
            td159.HorizontalAlign = HorizontalAlign.Center
            td159.Text = "<font size=2.5><b>DEPARTMENT</b></font>"
            tr5.Controls.Add(td159)
            tb.Controls.Add(tr5)
        End If

        Dim td160 As New TableCell
        'td160.Attributes.Add("width", "20%")
        td160.ColumnSpan = 10
        td160.HorizontalAlign = HorizontalAlign.Center
        td160.Text = "<font size=2.5><b>GENDER</b></font>"
        tr5.Controls.Add(td160)
        tb.Controls.Add(tr5)

        Dim td161 As New TableCell
        'td161.Attributes.Add("width", "20%")
        td161.ColumnSpan = 25
        td161.HorizontalAlign = HorizontalAlign.Center
        td161.Text = "<font size=2.5><b>JOIN DATE</b></font>"
        tr5.Controls.Add(td161)
        tb.Controls.Add(tr5)

        Dim td162 As New TableCell
        ' td162.Attributes.Add("width", "20%")
        td162.ColumnSpan = 12
        td162.HorizontalAlign = HorizontalAlign.Center
        td162.Text = "<font size=2.5><b>C/L</b></font>"
        tr5.Controls.Add(td162)
        tb.Controls.Add(tr5)


        Dim td163 As New TableCell
        ' td163.Attributes.Add("width", "20%")
        td163.ColumnSpan = 12
        td163.HorizontalAlign = HorizontalAlign.Center
        td163.Text = "<font size=2.5><b>S/L</b></font>"
        tr5.Controls.Add(td163)
        tb.Controls.Add(tr5)



        Dim td164 As New TableCell
        'td164.Attributes.Add("width", "20%")
        td164.ColumnSpan = 12
        td164.HorizontalAlign = HorizontalAlign.Center
        td164.Text = "<font size=2.5><b>E/L</b></font>"
        tr5.Controls.Add(td164)
        tb.Controls.Add(tr5)

        Dim td165 As New TableCell
        'td165.Attributes.Add("width", "20%")
        td165.ColumnSpan = 11
        td165.HorizontalAlign = HorizontalAlign.Center
        td165.Text = "<font size=2.5><b>LOP</b></font>"
        tr5.Controls.Add(td165)
        tb.Controls.Add(tr5)


        Dim td166 As New TableCell
        'td166.Attributes.Add("width", "20%")
        td166.ColumnSpan = 10
        td166.HorizontalAlign = HorizontalAlign.Center
        td166.Text = "<font size=2.5><b>TOTAL</b></font>"
        tr5.Controls.Add(td166)
        tb.Controls.Add(tr5)

        Dim td167 As New TableCell
        'td167.Attributes.Add("width", "20%")
        td167.ColumnSpan = 10
        td167.HorizontalAlign = HorizontalAlign.Center
        td167.Text = "<font size=2.5><b>C/L BALANCE</b></font>"
        tr5.Controls.Add(td167)
        tb.Controls.Add(tr5)


        Dim td168 As New TableCell
        'td168.Attributes.Add("width", "20%")
        td168.ColumnSpan = 15
        td168.HorizontalAlign = HorizontalAlign.Center
        td168.Text = "<font size=2.5><b>S/L BALANCE</b></font>"
        tr5.Controls.Add(td168)
        tb.Controls.Add(tr5)


        Dim td169 As New TableCell
        'td169.Attributes.Add("width", "20%")
        td169.ColumnSpan = 15
        td169.HorizontalAlign = HorizontalAlign.Center
        td169.Text = "<font size=2.5><b>E/L BALANCE</b></font>"
        tr5.Controls.Add(td169)
        tb.Controls.Add(tr5)


        For Each dr In dt.Rows
            Dim tr6 As New TableRow
            If (color = 0) Then
                tr6.BackColor = Drawing.Color.GhostWhite
                color = 1
            Else
                tr6.BackColor = Drawing.Color.WhiteSmoke
                color = 0
            End If

            'emp_code,cc.emp_name,cc.status,cc.designation,
            Dim td61 As New TableCell
            ' td61.Attributes.Add("width", "8%")
            td61.ColumnSpan = 8
            td61.HorizontalAlign = HorizontalAlign.Left
            td61.Text = "<font size=2>" & dr(0) & "</font>"
            tr6.Controls.Add(td61)

            Dim td62 As New TableCell
            ' td62.Attributes.Add("width", "7%")
            td62.ColumnSpan = 22
            td62.HorizontalAlign = HorizontalAlign.Left

            td62.Text = "<font size=2>" & dr(1) & "</font>" '----empname
            tr6.Controls.Add(td62)

            Dim td63 As New TableCell
            'td63.Attributes.Add("width", "15%")
            td63.ColumnSpan = 18
            td63.HorizontalAlign = HorizontalAlign.Center
            td63.Text = "<font size=2>" & dr(2) & "</font>" '---
            tr6.Controls.Add(td63)


            Dim td65 As New TableCell
            'td65.Attributes.Add("width", "15%")
            td65.ColumnSpan = 25
            td65.HorizontalAlign = HorizontalAlign.Left
            td65.Text = "<font size=2>" & dr(3) & "</font>" '
            tr6.Controls.Add(td65)







            'cc.post_name,cc.department,cc.gender,cc.joindt,


            Dim td68 As New TableCell
            'td68.Attributes.Add("width", "25%")
            td68.ColumnSpan = 20
            td68.HorizontalAlign = HorizontalAlign.Left

            td68.Text = "<font size=2>" & dr(4) & "</font>"
            tr6.Controls.Add(td68)
            'tb.Controls.Add(tr6)

            If Deptid = -2 Then
                Dim td69 As New TableCell
                'td69.Attributes.Add("width", "15%")
                td69.ColumnSpan = 25
                td69.HorizontalAlign = HorizontalAlign.Left
                td69.Text = "<font size=2>" & dr(5) & "</font>"
                tr6.Controls.Add(td69)
            End If

            Dim td70 As New TableCell
            'td70.Attributes.Add("width", "25%")
            td70.ColumnSpan = 10
            td70.HorizontalAlign = HorizontalAlign.Center
            td70.Text = "<font size=2>" & dr(6) & "</font>"
            tr6.Controls.Add(td70)
            tb.Controls.Add(tr6)

            Dim td701 As New TableCell
            'td701.Attributes.Add("width", "25%")
            td701.ColumnSpan = 25
            td701.HorizontalAlign = HorizontalAlign.Center
            td701.Text = "<font size=2>" & dr(7) & "</font>"
            tr6.Controls.Add(td701)
            tb.Controls.Add(tr6)


            'cc.casual,cc.sick,cc.Earned,cc.lop,cc.total,nvl(lms.leave_days,0) ,nvl(lms1.leave_days,0),nvl(lms2.leave_days,0) 

            Dim td702 As New TableCell
            'td702.Attributes.Add("width", "25%")
            td702.ColumnSpan = 12
            td702.HorizontalAlign = HorizontalAlign.Center
            td702.Text = "<font size=2>" & dr(8) & "</font>"
            tr6.Controls.Add(td702)
            tb.Controls.Add(tr6)

            Dim td703 As New TableCell
            'td703.Attributes.Add("width", "25%")
            td703.ColumnSpan = 12
            td703.HorizontalAlign = HorizontalAlign.Center
            td703.Text = "<font size=2>" & dr(9) & "</font>"
            tr6.Controls.Add(td703)
            tb.Controls.Add(tr6)

            Dim td704 As New TableCell
            'td704.Attributes.Add("width", "25%")
            td704.ColumnSpan = 12
            td704.HorizontalAlign = HorizontalAlign.Center
            td704.Text = "<font size=2>" & dr(10) & "</font>"
            tr6.Controls.Add(td704)
            tb.Controls.Add(tr6)

            Dim td705 As New TableCell
            'td705.Attributes.Add("width", "25%")
            td705.ColumnSpan = 11
            td705.HorizontalAlign = HorizontalAlign.Center
            td705.Text = "<font size=2>" & dr(11) & "</font>"
            tr6.Controls.Add(td705)
            tb.Controls.Add(tr6)

            Dim td706 As New TableCell
            'td706.Attributes.Add("width", "25%")
            td706.ColumnSpan = 10
            td706.HorizontalAlign = HorizontalAlign.Center
            td706.Text = "<font size=2>" & dr(12) & "</font>"
            tr6.Controls.Add(td706)
            tb.Controls.Add(tr6)

            Dim td707 As New TableCell
            'td707.Attributes.Add("width", "25%")
            td707.ColumnSpan = 10
            td707.HorizontalAlign = HorizontalAlign.Center
            td707.Text = "<font size=2>" & dr(13) & "</font>"
            tr6.Controls.Add(td707)
            tb.Controls.Add(tr6)

            Dim td708 As New TableCell
            'td708.Attributes.Add("width", "25%")
            td708.ColumnSpan = 15
            td708.HorizontalAlign = HorizontalAlign.Center
            td708.Text = "<font size=2>" & dr(14) & "</font>"
            tr6.Controls.Add(td708)
            tb.Controls.Add(tr6)


            Dim td709 As New TableCell
            'td709.Attributes.Add("width", "25%")
            td709.ColumnSpan = 15
            td709.HorizontalAlign = HorizontalAlign.Center
            td709.Text = "<font size=2>" & dr(15) & "</font>"
            tr6.Controls.Add(td709)
            tb.Controls.Add(tr6)

        Next



        Dim l3 As New TableRow
        Dim ld3 As New TableCell
        'ld3.Attributes.Add("width", "100%")
        ld3.ColumnSpan = 250
        ld3.HorizontalAlign = HorizontalAlign.Center
        ld3.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
        l3.Controls.Add(ld3)
        tb.Controls.Add(l3)
        Me.Panel1.Controls.Add(tb)
        Me.Panel1.HorizontalAlign = HorizontalAlign.Center


    End Sub

    Protected Sub btn_Exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Exit.Click
        Response.Redirect("Employee_Leave_Rpt.aspx")
    End Sub
End Class
