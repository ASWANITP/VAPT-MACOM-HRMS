Imports system.data

Imports system.data.oracleclient
Partial Class Attendence_Report_PresentReportE_9703487c4569
    Inherits System.Web.UI.Page
    Dim dt, dt1, dtb As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql, sql1 As String
    Dim dr As DataRow
    Dim per, totalper As Double
    Dim totalp = 0, totals = 0
    Dim color = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fdate As String
        Dim brid As Integer
        fdate = Request.QueryString.Get("fdate")
        'fdate = Request.QueryString.Get("fdate")
        brid = Request.QueryString.Get("brid")
        sql = "select to_date(curr_date) as day,em.emp_code as emp_code,upper(substr(em.emp_name,0,19)) as Name,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,case when m_time is not null then substr(bm1.branch_name,0,12) else '' end as Morning_Branch,decode(e_time,NULL,'----------',e_time) as evening_time,case when e_time is not null then substr(bm2.branch_name,0,12) else '' end  as Evening_Branch,case when (m_time='OFF' and e_time='OFF') then '' else case when ((da.m_time is null and da.e_time is null) and (to_char(to_date(da.curr_date),'d')=1)) then 'Sunday' else case when da.m_time is null and da.e_time is null then 'Absent' else case when da.m_time>tt.in_time and da.e_time is null then 'Late & Non Marking' else case when da.m_time<=tt.in_time and da.e_time is null and to_date(da.CURR_DATE)<to_date(sysdate) then 'Non Marking' else case when da.m_time is null and da.e_time <tt.out_time then 'Non Marking & Early Going' else case when da.m_time is null and da.e_time >=tt.out_time then 'Non Marking' else case when da.m_time<=tt.in_time and da.e_time<tt.out_time then 'Early Going' else case when da.m_time>tt.in_time and da.e_time<tt.out_time then 'Late & Early Going' else case when da.m_time>tt.in_time and da.e_time>tt.out_time then 'Late' else '' end end end end end end end end end end as remarks from ATTENDANCE da,employee_master em,branch_master bm,branch_master bm1,branch_master bm2,time_tab tt where  em.emp_code=da.emp_code and bm.branch_id=em.branch_id and to_date(da.curr_date)>='" & Request.QueryString.Get("fdate") & "' and to_date(da.curr_date)<='" & Request.QueryString.Get("fdate") & "' and em.department_id=14 and em.branch_id=da.branch_id  and da.shift_id not in (4,5) and da.shift_id=tt.shift_id and bm1.branch_id=da.m_branch and bm2.branch_id=da.e_branch and da.branch_id=" & Request.QueryString.Get("brid") & " order by da.emp_code,bm.branch_id,day"

        dt = oh.ExecuteDataSet(sql).Tables(0)
        Dim tb As New Table
        ' tb.Attributes.Add("Border", "1")
        tb.Attributes.Add("width", "100%")

        Dim tr1 As New TableRow
        Dim td11 As New TableCell
        td11.Attributes.Add("width", "100%")
        td11.ColumnSpan = 80
        td11.HorizontalAlign = HorizontalAlign.Center
        td11.Text = "<font size=4><b>" & Me.Session("firm_name") & "</b></font>"
        tr1.Controls.Add(td11)
        tb.Controls.Add(tr1)

        Dim tr2 As New TableRow
        Dim td21 As New TableCell
        td21.Attributes.Add("width", "50%")
        td21.ColumnSpan = 40
        td21.HorizontalAlign = HorizontalAlign.Right
        td21.Text = "<font size=2><b>Branch-id :" & Me.Session("branch_id") & "</b></font>"
        tr2.Controls.Add(td21)
        Dim td22 As New TableCell
        td22.Attributes.Add("width", "50%")
        td22.ColumnSpan = 40
        td22.HorizontalAlign = HorizontalAlign.Left
        td22.Text = "<font size=2><b>Branch :" & Me.Session("branch_name") & "</b></font>"
        tr2.Controls.Add(td22)
        tb.Controls.Add(tr2)


        Dim tr3 As New TableRow
        Dim td31 As New TableCell
        td31.Attributes.Add("width", "50%")
        td31.ColumnSpan = 40
        td31.HorizontalAlign = HorizontalAlign.Left
        td31.Text = "<font size=2><b>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</b></font>"
        tr3.Controls.Add(td31)
        Dim td32 As New TableCell
        td32.Attributes.Add("width", "50%")
        td32.ColumnSpan = 40
        td32.HorizontalAlign = HorizontalAlign.Right
        td32.Text = "<font size=2><b>Time :" & Format(Date.Now, "hh:mm:ss") & "</b></font>"
        tr3.Controls.Add(td32)
        tb.Controls.Add(tr3)


        Dim tr4 As New TableRow
        tr4.BackColor = Drawing.Color.WhiteSmoke
        Dim td41 As New TableCell
        td41.Attributes.Add("width", "100%")
        td41.ColumnSpan = 80
        td41.HorizontalAlign = HorizontalAlign.Center
        sql = "select initcap(branch_name) from branch_master where branch_id=" & brid
        dtb = oh.ExecuteDataSet(sql).Tables(0)
        td41.Text = "<font size=3><b>Attendance  Report of &nbsp" & dtb.Rows(0)(0) & " &nbspBranch From :&nbsp" & fdate & " &nbsp To :" & fdate & " </b></font>"
        tr4.Controls.Add(td41)
        tb.Controls.Add(tr4)

        Dim l1 As New TableRow
        Dim ld1 As New TableCell
        ld1.Attributes.Add("width", "100%")
        ld1.ColumnSpan = 80
        ld1.HorizontalAlign = HorizontalAlign.Center
        ld1.Text = "<font size=3><hr size='2' NOSHADE></font>"
        l1.Controls.Add(ld1)
        tb.Controls.Add(l1)

        Dim tr5 As New TableRow
        Dim td51 As New TableCell
        td51.Attributes.Add("width", "8%")
        td51.ColumnSpan = 8
        td51.HorizontalAlign = HorizontalAlign.Left
        td51.Text = "<font size=2.5><b>DATE</b></font>"
        tr5.Controls.Add(td51)

        Dim td52 As New TableCell
        td52.Attributes.Add("width", "7%")
        td52.ColumnSpan = 7
        td52.HorizontalAlign = HorizontalAlign.Left
        td52.Text = "<font size=2.5><b>EMPLOYEE CODE</b></font>"
        tr5.Controls.Add(td52)

        Dim td53 As New TableCell
        td53.Attributes.Add("width", "15%")
        td53.ColumnSpan = 17
        td53.HorizontalAlign = HorizontalAlign.Left
        td53.Text = "<font size=2.5><b>EMPLOYEE NAME</b></font>"
        tr5.Controls.Add(td53)


        Dim td54 As New TableCell
        td54.Attributes.Add("width", "10%")
        td54.ColumnSpan = 5
        td54.HorizontalAlign = HorizontalAlign.Left
        td54.Text = "<font size=2.5><b>MORNING TIME</b></font>"
        tr5.Controls.Add(td54)

        Dim td55 As New TableCell
        td55.Attributes.Add("width", "15%")
        td55.ColumnSpan = 15
        td55.HorizontalAlign = HorizontalAlign.Left
        td55.Text = "<font size=2.5><b>MORNING BRANCH</b></font>"
        tr5.Controls.Add(td55)

        Dim td56 As New TableCell
        td56.Attributes.Add("width", "10%")
        td56.ColumnSpan = 5
        td56.HorizontalAlign = HorizontalAlign.Left
        td56.Text = "<font size=2.5><b>EVENING TIME</b></font>"
        tr5.Controls.Add(td56)

        Dim td57 As New TableCell
        td57.Attributes.Add("width", "15%")
        td57.ColumnSpan = 15
        td57.HorizontalAlign = HorizontalAlign.Left
        td57.Text = "<font size=2.5><b>EVENING BRANCH</b></font>"
        tr5.Controls.Add(td57)

        Dim td58 As New TableCell
        td58.Attributes.Add("width", "20%")
        td58.ColumnSpan = 8
        td58.HorizontalAlign = HorizontalAlign.Center
        td58.Text = "<font size=2.5><b>REMARKS</b></font>"
        tr5.Controls.Add(td58)
        tb.Controls.Add(tr5)
        tb.Controls.Add(tr5)

        Dim l2 As New TableRow
        Dim ld2 As New TableCell
        ld2.Attributes.Add("width", "100%")
        ld2.ColumnSpan = 80
        ld2.HorizontalAlign = HorizontalAlign.Center
        ld2.Text = "<font size=3><hr size='2' NOSHADE></font>"
        l2.Controls.Add(ld2)
        tb.Controls.Add(l2)

        For Each dr In dt.Rows
            Dim tr6 As New TableRow
            If (color = 0) Then
                tr6.BackColor = Drawing.Color.GhostWhite
                color = 1
            Else
                tr6.BackColor = Drawing.Color.WhiteSmoke
                color = 0
            End If
            Dim td61 As New TableCell
            td61.Attributes.Add("width", "8%")
            td61.ColumnSpan = 8
            td61.HorizontalAlign = HorizontalAlign.Left
            td61.Text = "<font size=2>" & Format(dr(0), "dd/MMM/yyyy") & "</font>"
            tr6.Controls.Add(td61)

            Dim td62 As New TableCell
            td62.Attributes.Add("width", "7%")
            td62.ColumnSpan = 7
            td62.HorizontalAlign = HorizontalAlign.Center
            td62.Text = "<font size=2><a href=javascript:next(" & dr(1) & ")>" & dr(1) & "</font>"
            tr6.Controls.Add(td62)

            Dim td63 As New TableCell
            td63.Attributes.Add("width", "15%")
            td63.ColumnSpan = 17
            td63.HorizontalAlign = HorizontalAlign.Left
            td63.Text = "<font size=2>" & dr(2) & "</font>"
            tr6.Controls.Add(td63)


            Dim td64 As New TableCell
            td64.Attributes.Add("width", "10%")
            td64.ColumnSpan = 5
            td64.HorizontalAlign = HorizontalAlign.Left
            td64.Text = "<font size=2>" & dr(3) & "</font>"
            tr6.Controls.Add(td64)

            Dim td65 As New TableCell
            td65.Attributes.Add("width", "15%")
            td65.ColumnSpan = 15
            td65.HorizontalAlign = HorizontalAlign.Left
            td65.Text = "<font size=2>" & dr(4) & "</font>"
            tr6.Controls.Add(td65)

            Dim td66 As New TableCell
            td66.Attributes.Add("width", "10%")
            td66.ColumnSpan = 5
            td66.HorizontalAlign = HorizontalAlign.Left
            td66.Text = "<font size=2>" & dr(5) & "</font>"
            tr6.Controls.Add(td66)

            Dim td67 As New TableCell
            td67.Attributes.Add("width", "15%")
            td67.ColumnSpan = 15
            td67.HorizontalAlign = HorizontalAlign.Left
            td67.Text = "<font size=2>" & dr(6) & "</font>"
            tr6.Controls.Add(td67)

            Dim td68 As New TableCell
            td68.Attributes.Add("width", "20%")
            td68.ColumnSpan = 8
            td68.HorizontalAlign = HorizontalAlign.Center
            td68.Text = "<font size=2>" & dr(7) & "</font>"
            tr6.Controls.Add(td68)
            tb.Controls.Add(tr6)
        Next

        Dim l3 As New TableRow
        Dim ld3 As New TableCell
        ld3.Attributes.Add("width", "100%")
        ld3.ColumnSpan = 80
        ld3.HorizontalAlign = HorizontalAlign.Center
        ld3.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
        l3.Controls.Add(ld3)
        tb.Controls.Add(l3)
        Me.Panel_report.Controls.Add(tb)
    End Sub
End Class
