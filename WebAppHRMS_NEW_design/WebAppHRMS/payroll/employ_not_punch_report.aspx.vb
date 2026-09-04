Imports System.Data
Imports System.Data.OracleClient
Partial Class november_employ_not_punch_report_4906ae7e8127
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tb As New Table
        tb.Attributes.Add("width", "100%")
        tb.Attributes.Add("border", "")
        tb.Attributes.Add("align", "center")

        Dim tr4 As New TableRow
        tr4.BackColor = Drawing.Color.Gold
        Dim tc14 As New TableCell
        tc14.ColumnSpan = 50
        tc14.HorizontalAlign = HorizontalAlign.Center
        'tc14.Text = "<font size=5 color=red><b>MANAPPURAM GROUP OF COMPANIES</b></font>"
        tc14.Text = "<font size=5 color=red><b>" & Me.session("firm_name") & "</b></font>"
        tr4.Cells.Add(tc14)
        tb.Controls.Add(tr4)
        'dt1 = oh.ExecuteDataSet("select emp_name,emp_code from employee_master where emp_code=" & Request.QueryString("emp") & " ").Tables(0)

        Dim tr5 As New TableRow
        tr5.BackColor = Drawing.Color.FloralWhite
        Dim tc15 As New TableCell
        tc15.ColumnSpan = 50
        tc15.HorizontalAlign = HorizontalAlign.Center
        Dim rep As String


        tc15.Text = "<FONT color=navy><b>EMPLOYEE NOT PUNCHED REPORT</b></FONT>"
        tr5.Cells.Add(tc15)
        tb.Controls.Add(tr5)


        Dim tr6 As New TableRow
        tr6.BackColor = Drawing.Color.FloralWhite
        Dim tc16 As New TableCell
        tc16.Attributes.Add("width", "50%")
        tc16.ColumnSpan = 25
        tc16.HorizontalAlign = HorizontalAlign.Left
        tc16.BorderWidth = 0
        tc16.Text = "<font size=2 color=darkblue>Date&nbsp:" & Format(Date.Now, "dd/MMM/yyyy") & "</font>"
        tr6.Cells.Add(tc16)


        Dim tc17 As New TableCell
        tc17.Attributes.Add("width", "50%")
        tc17.ColumnSpan = 25
        tc17.BorderWidth = 0
        tc17.HorizontalAlign = HorizontalAlign.Right
        tc17.Text = "<font size=2 color=darkblue>Time&nbsp:" & Format(Date.Now, "hh:mm:ss") & "</font>"
        tr6.Cells.Add(tc17)
        tb.Controls.Add(tr6)


        Dim tr1 As New TableRow
        tr1.BackColor = Drawing.Color.PeachPuff
        Dim tc1 As New TableCell
        tc1.ColumnSpan = 1
        tc1.HorizontalAlign = HorizontalAlign.Left
        tc1.Text = "<font size=2><b>CODE</b></font>"
        tr1.Cells.Add(tc1)

        Dim tc2 As New TableCell
        tc2.ColumnSpan = 3
        tc2.HorizontalAlign = HorizontalAlign.Left
        tc2.Text = "<font size=2><b>EMPLOYEE NAME</b></font>"
        tr1.Cells.Add(tc2)

        Dim tc3 As New TableCell
        tc3.ColumnSpan = 3
        tc3.HorizontalAlign = HorizontalAlign.Left
        tc3.Text = "<font size=2><b>BRANCH ID&NAME</b></font>"
        tr1.Cells.Add(tc3)

        Dim tc4 As New TableCell
        tc4.ColumnSpan = 2
        tc4.HorizontalAlign = HorizontalAlign.Left
        tc4.Text = "<font size=2><b>DEPARTMENT</b></font>"
        tr1.Cells.Add(tc4)

        Dim tc5 As New TableCell
        tc5.ColumnSpan = 2
        tc5.HorizontalAlign = HorizontalAlign.Left
        tc5.Text = "<font size=2><b>DESIGNATION</b></font>"
        tr1.Cells.Add(tc5)

        Dim tc6 As New TableCell
        tc6.ColumnSpan = 2
        tc6.HorizontalAlign = HorizontalAlign.Left
        tc6.Text = "<font size=2><b>POST</b></font>"
        tr1.Cells.Add(tc6)

        Dim tc7 As New TableCell
        tc7.ColumnSpan = 2
        tc7.HorizontalAlign = HorizontalAlign.Left
        tc7.Text = "<font size=2><b>LAST&nbsp;PUNCH&nbsp;DATE</b></font>"
        tr1.Cells.Add(tc7)
        tb.Controls.Add(tr1)
        Dim tc8 As New TableCell
        tc8.ColumnSpan = 2
        tc8.HorizontalAlign = HorizontalAlign.Left
        tc8.Text = "<font size=2><b>LAST&nbsp;PUNCH MORNING&nbsp;TIME</b></font>"
        tr1.Cells.Add(tc8)
        tb.Controls.Add(tr1)

        Dim tc9 As New TableCell
        tc9.ColumnSpan = 3
        tc9.HorizontalAlign = HorizontalAlign.Left
        tc9.Text = "<font size=2><b>MORNING BRANCH</b></font>"
        tr1.Cells.Add(tc9)
        tb.Controls.Add(tr1)
        Dim tc10 As New TableCell
        tc10.ColumnSpan = 2
        tc10.HorizontalAlign = HorizontalAlign.Left
        tc10.Text = "<font size=2><b>LAST&nbsp;PUNCH EVENING&nbsp;TIME</b></font>"
        tr1.Cells.Add(tc10)
        tb.Controls.Add(tr1)

        Dim tc11 As New TableCell
        tc11.ColumnSpan = 3
        tc11.HorizontalAlign = HorizontalAlign.Left
        tc11.Text = "<font size=2><b>EVENING BRANCH</b></font>"
        tr1.Cells.Add(tc11)
        tb.Controls.Add(tr1)
        Dim tc131 As New TableCell
        tc131.ColumnSpan = 3
        tc131.HorizontalAlign = HorizontalAlign.Left
        tc131.Text = "<font size=2><b>DATE&nbsp;OF&nbsp;JOINING</b></font>"
        tr1.Cells.Add(tc131)
        tb.Controls.Add(tr1)
        Dim tc121 As New TableCell
        tc121.ColumnSpan = 3
        tc121.HorizontalAlign = HorizontalAlign.Left
        tc121.Text = "<font size=2><b>No.Of DAYS</b></font>"
        tr1.Cells.Add(tc121)
        tb.Controls.Add(tr1)
        Dim dr As DataRow
        Dim color As Integer = 0
        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        If (Request.QueryString("post") = 1) Then
            '  dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,b.branch_id||' - '||b.branch_name as brname ,d.dep_name,ds.designation,p.post_name,to_char(e.curr_date) as last_punch,e.m_time,b1.branch_name,e.e_time,b2.branch_name,b.branch_name as br,to_date(sysdate)-to_date(e.curr_date) as days from employ_not_punch e,branch_master b,department_mst d,designation_master ds,post_mst p,branch_master b1,branch_master b2,employee_master em where e.branch_id=b.branch_id and e.emp_code=em.emp_code and e.department_id=d.dep_id and e.designation_id=ds.designation_id and em.post_id=p.post_id and e.m_branch=b1.branch_id and e.e_branch=b2.branch_id and em.post_id in (17,18,10,11,12,13,14,15,16,101,149,146,148,90) and e.user_id=" & sf(0) & " union select e.emp_code,e.emp_name,b.old_id||' - '||b.branch_name as brname,d.dep_name,ds.designation,p.post_name,to_char(e.curr_date) as last_punch,e.m_time,b1.branch_name,e.e_time,b2.branch_name,b.branch_name as br,to_date(sysdate)-to_date(e.curr_date) as days from employ_not_punch e,before_completion b,department_mst d,designation_master ds,post_mst p,branch_master b1,branch_master b2,employee_master em where e.branch_id=b.old_id and e.emp_code=em.emp_code and b.branch_id is null and e.department_id=d.dep_id and e.designation_id=ds.designation_id and em.post_id=p.post_id and e.m_branch=b1.branch_id and e.e_branch=b2.branch_id and em.post_id in (17,18,10,11,12,13,14,15,16,101,149,146,148,90) and e.user_id=" & sf(0) & " order by br,emp_code").Tables(0)
            dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,b.branch_id||' - '||b.branch_name as brname ,d.dep_name,ds.designation,p.post_name,to_char(e.curr_date) as last_punch,e.m_time,b1.branch_name,e.e_time,b2.branch_name,b.branch_name as br,to_date(sysdate)-to_date(e.curr_date) as days from employ_not_punch e,employ_firm ef,branch_master b,department_mst d,designation_master ds,post_mst p,branch_master b1,branch_master b2,employee_master em where e.branch_id=b.branch_id and em.emp_code = ef.emp_code and ef.firm_id = " & Session("firm_id") & " and e.emp_code=em.emp_code and e.department_id=d.dep_id and e.designation_id=ds.designation_id and em.post_id=p.post_id and e.m_branch=b1.branch_id and e.e_branch=b2.branch_id and em.post_id in (17,18,10,11,12,13,14,15,16,101,149,146,148,90) and e.user_id=" & sf(0) & " union select e.emp_code,e.emp_name,b.old_id||' - '||b.branch_name as brname,d.dep_name,ds.designation,p.post_name,to_char(e.curr_date) as last_punch,e.m_time,b1.branch_name,e.e_time,b2.branch_name,b.branch_name as br,to_date(sysdate)-to_date(e.curr_date) as days from employ_not_punch e,before_completion b,department_mst d,designation_master ds,post_mst p,branch_master b1,branch_master b2,employee_master em,employ_firm ef where e.branch_id=b.old_id and em.emp_code = ef.emp_code and ef.firm_id = " & Session("firm_id") & " and e.emp_code=em.emp_code and b.branch_id is null and e.department_id=d.dep_id and e.designation_id=ds.designation_id and em.post_id=p.post_id and e.m_branch=b1.branch_id and e.e_branch=b2.branch_id and em.post_id in (17,18,10,11,12,13,14,15,16,101,149,146,148,90) and e.user_id=" & sf(0) & " order by br,emp_code").Tables(0)
        End If
        If (Request.QueryString("post") = 2) Then
            ' dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,b.branch_id||' - '||b.branch_name as brname ,d.dep_name,ds.designation,p.post_name,to_char(e.curr_date) as last_punch,e.m_time,b1.branch_name,e.e_time,b2.branch_name,b.branch_name as br,to_date(sysdate)-to_date(e.curr_date) as days from employ_not_punch e,branch_master b,department_mst d,designation_master ds,post_mst p,branch_master b1,branch_master b2,employee_master em where e.branch_id=b.branch_id and e.emp_code=em.emp_code and e.department_id=d.dep_id and e.designation_id=ds.designation_id and em.post_id=p.post_id and e.m_branch=b1.branch_id and e.e_branch=b2.branch_id and em.post_id in (1,2,3,4,5,6,7,8,9) and e.user_id=" & sf(0) & " union select e.emp_code,e.emp_name,b.old_id||' - '||b.branch_name as brname,d.dep_name,ds.designation,p.post_name,to_char(e.curr_date) as last_punch,e.m_time,b1.branch_name,e.e_time,b2.branch_name,b.branch_name as br,to_date(sysdate)-to_date(e.curr_date) as days from employ_not_punch e,before_completion b,department_mst d,designation_master ds,post_mst p,branch_master b1,branch_master b2,employee_master em where e.branch_id=b.old_id and e.emp_code=em.emp_code and b.branch_id is null and e.department_id=d.dep_id and e.designation_id=ds.designation_id and em.post_id=p.post_id and e.m_branch=b1.branch_id and e.e_branch=b2.branch_id and em.post_id in (1,2,3,4,5,6,7,8,9) and e.user_id=" & sf(0) & " order by br,emp_code").Tables(0)
            dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,b.branch_id||' - '||b.branch_name as brname ,d.dep_name,ds.designation,p.post_name,to_char(e.curr_date) as last_punch,e.m_time,b1.branch_name,e.e_time,b2.branch_name,b.branch_name as br,to_date(sysdate)-to_date(e.curr_date) as days from employ_not_punch e,branch_master b,department_mst d,designation_master ds,post_mst p,branch_master b1,branch_master b2,employee_master em,employ_firm ef where e.branch_id=b.branch_id and e.emp_code=em.emp_code and em.emp_code = ef.emp_code and ef.firm_id = " & Session("firm_id") & " and e.department_id=d.dep_id and e.designation_id=ds.designation_id and em.post_id=p.post_id and e.m_branch=b1.branch_id and e.e_branch=b2.branch_id and em.post_id in (1,2,3,4,5,6,7,8,9) and e.user_id=" & sf(0) & " union select e.emp_code,e.emp_name,b.old_id||' - '||b.branch_name as brname,d.dep_name,ds.designation,p.post_name,to_char(e.curr_date) as last_punch,e.m_time,b1.branch_name,e.e_time,b2.branch_name,b.branch_name as br,to_date(sysdate)-to_date(e.curr_date) as days from employ_not_punch e,before_completion b,department_mst d,designation_master ds,post_mst p,branch_master b1,branch_master b2,employee_master em,employ_firm ef  where e.branch_id=b.old_id and e.emp_code=em.emp_code and em.emp_code = ef.emp_code and ef.firm_id = " & Session("firm_id") & " and b.branch_id is null and e.department_id=d.dep_id and e.designation_id=ds.designation_id and em.post_id=p.post_id and e.m_branch=b1.branch_id and e.e_branch=b2.branch_id and em.post_id in (1,2,3,4,5,6,7,8,9) and e.user_id=" & sf(0) & " order by br,emp_code").Tables(0)

        End If
        If (Request.QueryString("post") = 0) Then
            ' dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,b.branch_id||' - '||b.branch_name as brname ,d.dep_name,ds.designation,p.post_name,to_char(e.curr_date) as last_punch,e.m_time,b1.branch_name,e.e_time,b2.branch_name,b.branch_name as br,to_date(sysdate)-to_date(e.curr_date) as days from employ_not_punch e,branch_master b,department_mst d,designation_master ds,post_mst p,branch_master b1,branch_master b2,employee_master em where e.branch_id=b.branch_id and e.emp_code=em.emp_code and e.department_id=d.dep_id and e.designation_id=ds.designation_id and em.post_id=p.post_id and e.m_branch=b1.branch_id and e.e_branch=b2.branch_id and e.user_id=" & sf(0) & " union select e.emp_code,e.emp_name,b.old_id||' - '||b.branch_name as brname,d.dep_name,ds.designation,p.post_name,to_char(e.curr_date) as last_punch,e.m_time,b1.branch_name,e.e_time,b2.branch_name,b.branch_name as br,to_date(sysdate)-to_date(e.curr_date) as days from employ_not_punch e,before_completion b,department_mst d,designation_master ds,post_mst p,branch_master b1,branch_master b2,employee_master em where e.branch_id=b.old_id and e.emp_code=em.emp_code and b.branch_id is null and e.department_id=d.dep_id and e.designation_id=ds.designation_id and em.post_id=p.post_id and e.m_branch=b1.branch_id and e.e_branch=b2.branch_id and e.user_id=" & sf(0) & " order by br,emp_code").Tables(0)
            dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,b.branch_id||' - '||b.branch_name as brname ,d.dep_name,ds.designation,p.post_name,to_char(e.curr_date) as last_punch,e.m_time,b1.branch_name,e.e_time,b2.branch_name,b.branch_name as br,to_date(sysdate)-to_date(e.curr_date) as days from employ_not_punch e,branch_master b,department_mst d,designation_master ds,post_mst p,branch_master b1,branch_master b2,employee_master em,employ_firm ef where e.branch_id=b.branch_id and e.emp_code=em.emp_code and em.emp_code = ef.emp_code and ef.firm_id = " & Session("firm_id") & " and e.department_id=d.dep_id and e.designation_id=ds.designation_id and em.post_id=p.post_id and e.m_branch=b1.branch_id and e.e_branch=b2.branch_id and e.user_id=" & sf(0) & " union select e.emp_code,e.emp_name,b.old_id||' - '||b.branch_name as brname,d.dep_name,ds.designation,p.post_name,to_char(e.curr_date) as last_punch,e.m_time,b1.branch_name,e.e_time,b2.branch_name,b.branch_name as br,to_date(sysdate)-to_date(e.curr_date) as days from employ_not_punch e,before_completion b,department_mst d,designation_master ds,post_mst p,branch_master b1,branch_master b2,employee_master em,employ_firm ef where e.branch_id=b.old_id and e.emp_code=em.emp_code and em.emp_code = ef.emp_code and ef.firm_id = " & Session("firm_id") & " and b.branch_id is null and e.department_id=d.dep_id and e.designation_id=ds.designation_id and em.post_id=p.post_id and e.m_branch=b1.branch_id and e.e_branch=b2.branch_id and e.user_id=" & sf(0) & " order by br,emp_code").Tables(0)
        End If
        Dim emp As Integer
        emp = 0
        Dim branch As String = ""

        For Each dr In dt.Rows
            If branch <> dr(11) Then
                Dim br As New TableRow
                Dim brr As New TableCell
                brr.ColumnSpan = 31
                brr.HorizontalAlign = HorizontalAlign.Center
                brr.Text = "<font size=3 color=blue align=center><b>" & dr(11).ToString & "  </b></font>"
                br.Controls.Add(brr)
                tb.Controls.Add(br)

            End If
            branch = dr(11).ToString
            Dim tr2 As New TableRow

            If (color = 0) Then
                tr2.BackColor = Drawing.Color.Beige
                color = 1
            Else
                tr2.BackColor = Drawing.Color.Snow
                color = 0
            End If
            tr2.Attributes.Add("height", "25px")

            Dim tc18 As New TableCell
            tc18.ColumnSpan = 1
            tc18.HorizontalAlign = HorizontalAlign.Left
            tc18.Text = "<font size=2>" & dr(0) & "</font>"
            tc18.ForeColor = Drawing.Color.Black
            tr2.Cells.Add(tc18)
            emp = emp + 1

            Dim sd3 As String
            Dim tc19 As New TableCell
            tc19.ColumnSpan = 3
            tc19.HorizontalAlign = HorizontalAlign.Left
            tc19.Text = "<font size=2 >" & dr(1) & "</font>"
            ' tc19.ForeColor = Drawing.Color.Black
            tr2.Cells.Add(tc19)

            Dim tc20 As New TableCell
            tc20.ColumnSpan = 3
            tc20.HorizontalAlign = HorizontalAlign.Left
            tc20.Text = "<font size=2 color=blue>" & dr(2) & "</font>"
            ' tc10.Text = dt.Rows(0)(0)
            tr2.Cells.Add(tc20)



            Dim tc21 As New TableCell
            tc21.ColumnSpan = 2
            tc21.HorizontalAlign = HorizontalAlign.Left
            tc21.Text = "<font size=2 >" & dr(3) & "</font>"
            tr2.Cells.Add(tc21)
            tb.Controls.Add(tr2)



            Dim tc22 As New TableCell
            tc22.ColumnSpan = 2
            tc22.HorizontalAlign = HorizontalAlign.Left
            tc22.Text = "<font size=2>" & dr(4) & "</font>"
            tr2.Cells.Add(tc22)
            tb.Controls.Add(tr2)

            Dim tc23 As New TableCell
            tc23.ColumnSpan = 2
            tc23.HorizontalAlign = HorizontalAlign.Left
            tc23.Text = "<font size=2 >" & dr(5) & "</font>"
            tr2.Cells.Add(tc23)
            tb.Controls.Add(tr2)

            Dim tc24 As New TableCell
            tc24.ColumnSpan = 2
            tc24.HorizontalAlign = HorizontalAlign.Left
            tc24.Text = "<font size=2>" & dr(6) & "</font>"
            tr2.Cells.Add(tc24)
            tb.Controls.Add(tr2)

            Dim tc25 As New TableCell
            tc25.ColumnSpan = 2
            tc25.HorizontalAlign = HorizontalAlign.Left
            tc25.Text = "<font size=2 >" & dr(7) & "</font>"
            tr2.Cells.Add(tc25)
            tb.Controls.Add(tr2)

            Dim tc26 As New TableCell
            tc26.ColumnSpan = 3
            tc26.HorizontalAlign = HorizontalAlign.Left
            tc26.Text = "<font size=2>" & dr(8) & "</font>"
            tr2.Cells.Add(tc26)
            tb.Controls.Add(tr2)

            Dim tc27 As New TableCell
            tc27.ColumnSpan = 2
            tc27.HorizontalAlign = HorizontalAlign.Left
            tc27.Text = "<font size=2 >" & dr(9) & "</font>"
            tr2.Cells.Add(tc27)
            tb.Controls.Add(tr2)

            Dim tc28 As New TableCell
            tc28.ColumnSpan = 3
            tc28.HorizontalAlign = HorizontalAlign.Left
            tc28.Text = "<font size=2 >" & dr(10) & "</font>"
            tr2.Cells.Add(tc28)
            tb.Controls.Add(tr2)
            Dim dt7 As DataTable = oh.ExecuteDataSet("select  a.emp_name, min(to_char(a.join_dt)) from employee_master a where a.emp_code in (select e.emp_code from employee_master e,employee_master_dtl em where e.emp_code=em.emp_code and em.new_empcode=" & dr(0) & " union select e.emp_code from employee_master e,employee_master_dtl em,employee_master_dtl em1 where e.emp_code=em.emp_code and em.emp_code=" & dr(0) & " and em.new_empcode is null and em1.new_empcode<>em.emp_code) group by a.emp_name ").Tables(0)
            Dim tc30 As New TableCell
            tc30.ColumnSpan = 3
            tc30.HorizontalAlign = HorizontalAlign.Left
            tc30.Text = "<font size=2 >" & dt7.Rows(0)(1) & "</font>"
            tr2.Cells.Add(tc30)
            tb.Controls.Add(tr2)
            Dim tc29 As New TableCell
            tc29.ColumnSpan = 3
            tc29.HorizontalAlign = HorizontalAlign.Left
            tc29.Text = "<font size=2 >" & dr(12) & "</font>"
            tr2.Cells.Add(tc29)
            tb.Controls.Add(tr2)

        Next
        Dim br1 As New TableRow
        Dim brr1 As New TableCell
        brr1.ColumnSpan = 31
        brr1.Text = "<font size=3 color=black align=center><b>Total Employees-" & emp & " </b></font>"
        brr1.HorizontalAlign = HorizontalAlign.Center
        br1.Controls.Add(brr1)
        tb.Controls.Add(br1)
        Dim tr42 As New TableRow
        Dim tc142 As New TableCell
        tc142.ColumnSpan = 50
        tc142.HorizontalAlign = HorizontalAlign.Center
        tc142.Text = "<a href =employ_not_punch.aspx ><font size=4 color=red><b>BACK </b></font></a>"
        tr42.Cells.Add(tc142)
        tb.Controls.Add(tr42)
        Me.Panel1.Controls.Add(tb)


    End Sub


End Class
