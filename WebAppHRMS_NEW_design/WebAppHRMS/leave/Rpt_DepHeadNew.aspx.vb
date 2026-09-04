Imports System.Data
Imports System.Data.OracleClient
Partial Class pl3_Rpt_DepHeadNew_1fa769ec4994
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2, dt3, dt4, dt5, dt6, dtr As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim RH As New WholeHelper.ClsRepCtrl
    Dim tb As New Table
    Dim dr, dr1, dr2, dr4 As DataRow
    Dim BrID As Integer
    Dim str As New StringBuilder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim RowBG As Integer = 0
        Dim MAJOR As String = ""
        Dim DEP As Integer = 0
        Dim HEAD As String = ""
        Dim id As Integer
        id = Request.QueryString.Get("key")
        If Session("user_id") = "" Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Session Closed .Please login again !!!!');")
            cl_script0.Append("window.open('../../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Exit Sub
        End If
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        BrID = Session("branch_id")
        dt = oh.ExecuteDataSet("select branch_name from branch_master where branch_id=" & BrID & "").Tables(0)
        RH.Heading(Session("branch_id"), Session("branch_name"), Session("firm_name"), tb, "MAJOR AND SUB DEPARTMENT DETAILS", 37)


        'dt6 = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=6013 and emp_id= " & User(0) & "").Tables(0)
        'If dt6.Rows(0)(0) = 0 Then
        '    Dim cl_script0 As New System.Text.StringBuilder
        '    cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
        '    cl_script0.Append("window.open('../../home.aspx','_self');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        'End If
        'dt1 = oh.ExecuteDataSet("select a.department_id,  a.department_name || ' - ' || b.emp_code || ' - ' || b.emp_name ||  ' - ' || c.designation as depname  from department_major a, employee_master b, designation_mst c,employ_firm f  where a.head_id like '%' || b.emp_code || '%'  and b.emp_code > 9999  and b.designation_id = c.designation_id  and b.emp_code=f.emp_code  and f.firm_id=" & Session("firm_id") & "  order by depname").Tables(0)
        'For Each dr In dt1.Rows
        dt2 = oh.ExecuteDataSet("select distinct a.dep_id, a.dep_name || ' - ' || b.emp_code || ' - ' || b.emp_name || ' - ' || c.designation as depname, t.head from TBL_DEPT_STRUCTURE t, employee_master b, designation_master c, employ_firm f, department_mst a where b.emp_code > 9999 and t.head = b.emp_code and a.dep_id = b.department_id and b.designation_id = c.designation_id and b.emp_code = f.emp_code and f.firm_id = 8 and b.status_id=1 union select distinct a.dep_id, a.dep_name || ' - ' || b.emp_code || ' - ' || b.emp_name || ' - ' || c.designation as depname, (select p.dep_head from department_mst p where p.dep_id = b.department_id) head from TBL_DEPT_STRUCTURE t, employee_master b, designation_master c, employ_firm f, department_mst a where b.emp_code > 9999 and a.dep_head = b.emp_code and a.dep_id = b.department_id and b.designation_id = c.designation_id and b.emp_code = f.emp_code and f.firm_id = 8 and b.status_id=1 and (select count(p.dep_head) from department_mst p where p.dep_head = b.emp_code) > 1 and a.dep_id not in (select distinct a.dep_id from TBL_DEPT_STRUCTURE t, employee_master b, designation_master c, employ_firm f, department_mst a where b.emp_code > 9999 and t.head = b.emp_code and a.dep_id = b.department_id and b.designation_id = c.designation_id and b.emp_code = f.emp_code and f.firm_id = 8 and b.status_id=1) order by head").Tables(0)
        'dt4 = oh.ExecuteDataSet("select count(a.dep_id)from department_mst a, employee_master b, designation_mst c where a.dep_head = b.emp_code and a.status = 1 and b.emp_code > 9999 and b.designation_id = c.designation_id and a.major_dep_id =" & dr(0) & " union all (select count(a.dep_id) from department_mst a where a.dep_head is null and a.status = 1 and a.major_dep_id = " & dr(0) & ")").Tables(0)
        'If MAJOR <> dr(1) Then
        'MAJOR = dr(1)
        dtr = oh.ExecuteDataSet("select count(*) from(select distinct a.dep_id, a.dep_name || ' - ' || b.emp_code || ' - ' || b.emp_name || ' - ' || c.designation as depname,t.head from TBL_DEPT_STRUCTURE t, employee_master b, designation_master c, employ_firm f, department_mst a where b.emp_code > 9999 and t.head = b.emp_code and a.dep_id=b.department_id and b.designation_id = c.designation_id and b.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & "  order by head)").Tables(0)
        Dim tr01 As New TableRow
        Dim tr01_01 As New TableCell
        tr01.BackColor = Drawing.Color.NavajoWhite
        tr01.ForeColor = Drawing.Color.Red
        RH.AddColumn(tr01, tr01_01, 37, 10, "c", "<b>&nbsp;&nbsp;TOTAL DEPARTMENTS&nbsp;&nbsp;:&nbsp;" & dtr.Rows(0)(0) & "")
        tb.Controls.Add(tr01)
        Dim count As Integer = 0
        For Each dr1 In dt2.Rows
            If HEAD <> dr1(1) Then
                HEAD = dr1(1)
                Dim tr011 As New TableRow
                Dim tr011_01 As New TableCell
                tr011.BackColor = Drawing.Color.PapayaWhip
                tr011.ForeColor = Drawing.Color.Blue
                'RH.AddColumn(tr011, tr011_01, 37, 10, "c", "<b>" & HEAD)
                RH.AddColumn(tr011, tr011_01, 37, 10, "c", "<b>" & HEAD)
                tb.Controls.Add(tr011)
                count = count + 1
                dt3 = oh.ExecuteDataSet("select distinct t.emp_code, (select b.emp_name from employee_master b where b.emp_code = t.emp_code) as emp_name, c.designation as depname, t.head from TBL_DEPT_STRUCTURE t, employee_master b, designation_master c, employ_firm f, department_mst a where b.emp_code > 9999 and t.emp_code = b.emp_code and a.dep_id = b.department_id and b.designation_id = c.designation_id and b.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and t.head = " & dr1(2) & " and b.status_id=1 order by emp_code").Tables(0)
                Dim slno As Integer = 0
                For Each dr2 In dt3.Rows
                    slno = slno + 1
                    Dim tr09 As New TableRow
                    Dim tr09_01, tr09_02, tr09_03, tr09_04, tr09_05, tr09_06 As New TableCell
                    tr09.ForeColor = Drawing.Color.Maroon
                    If RowBG = 0 Then
                        tr09.BackColor = Drawing.Color.AliceBlue
                        RowBG = 1
                    Else
                        tr09.BackColor = Drawing.Color.Snow
                        RowBG = 0
                    End If
                    RH.AddColumn(tr09, tr09_01, 7, 10, "c", slno)
                    RH.AddColumn(tr09, tr09_02, 10, 10, "l", dr2(0))
                    RH.AddColumn(tr09, tr09_03, 10, 10, "l", dr2(1))
                    RH.AddColumn(tr09, tr09_04, 10, 10, "l", dr2(2))
                    tb.Controls.Add(tr09)
                Next
            End If
        Next
        'End If
        'Next
        Panel1.Controls.Add(tb)
    End Sub
End Class
