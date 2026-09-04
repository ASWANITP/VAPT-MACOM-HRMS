Imports system.data

Imports system.data.oracleclient
Partial Class Attendence_Report_PresentReportB_0e8de44c4422
    Inherits System.Web.UI.Page
    Dim dt, dt1, dta As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql, sql1 As String
    Dim dr As DataRow
    Dim per, totalper, lper, totalpres, totalabsent, totallate, totalearly, totalnon, totalstr, tlper As Double
    Dim totalp = 0, totals = 0
    Dim color = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim frdate As String
        Dim areaid As Integer
        frdate = Request.QueryString.Get("fdate")
        '  frdate = Request.QueryString.Get("tdate")
        areaid = Request.QueryString.Get("areaid")
        'sql = "select count(da.emp_code),bm.branch_name,bm.branch_id,sum(case when (da.m_time is NOT NULL or da.e_time is NOT NULL) then 1 else 0 end) as present,sum(case when (da.m_time is NULL and da.e_time is NULL) then 1 else 0 end) as Absent,sum(case when (da.shift_id=tt.shift_id and da.m_time>tt.in_time) then 1 else 0 end) as Late,sum(case when (da.shift_id=tt.shift_id and da.e_time<tt.out_time) then 1 else 0 end) as EarlyGoing,sum(case when ((da.m_time is  null or da.e_time is  null) AND NOT(DA.M_TIME IS NULL AND DA.E_TIME IS NULL)) then 1 else 0 end) as NonMarking from time_tab tt, ATTENDANCE da,branch_master bm,AREA_DETAIL AD where tt.shift_id=da.SHIFT_ID and bm.branch_id=da.branch_id  and da.branch_id=AD.BRANCH_ID AND AD.AREA_ID=" & areaid & " and da.curr_date>=to_date('" & frdate & "') and da.curr_date<=to_date('" & frdate & "') group by bm.branch_name,bm.branch_id"
        sql = "select branch_id,  branch_name,  count(emp_code) as Total,  sum(case  when (m_time is NOT NULL or e_time is NOT NULL) then  1  else  0  end) as present,  sum(case  when (m_time is NULL and e_time is NULL) then  1  else  0  end) as Absent,  sum(case  when (m_time > in_time) then  1  else  0  end) as Late,  sum(case  when (e_time < out_time) then  1  else  0  end) as EarlyGoing,  sum(case  when ((m_time is null and e_time is not null) or  (M_TIME IS not NULL AND E_TIME IS NULL and  CURR_DATE < to_date(sysdate))) then  1  else  0  end) as NonMarking  from (select da.*  from attendance_detail da,branch_master b  where da.CURR_DATE >= to_date('" & frdate & "')  and da.curr_date <= to_date('" & frdate & "')  and da.area_id = " & areaid & "  and da.BRANCH_ID=b.branch_id  and b.firm_id=" & Session("firm_id") & "  and da.shift_id not in (4, 5))  left outer join (select a.branch_id,  a.branch_name,  count(a.emp_code) as Total,  sum(case  when (a.m_time is NOT NULL or a.e_time is NOT NULL) then  1  else  0  end) as present,  sum(case  when (a.m_time is NULL and a.e_time is NULL) then  1  else  0  end) as Absent,  sum(case  when (a.m_time > a.in_time) then  1  else  0  end) as Late,  sum(case  when (a.e_time < a.out_time) then  1  else  0  end) as EarlyGoing,  sum(case  when ((a.m_time is null and a.e_time is not null) OR  (a.M_TIME IS not NULL AND a.E_TIME IS NULL and  a.CURR_DATE < to_date(sysdate))) then  1  else  0  end) as NonMarking  from attendance_detail a,branch_master b  where a.CURR_DATE >= to_date('" & frdate & "')  and a.curr_date <= to_date('" & frdate & "')  and a.area_id = " & areaid & "  and a.BRANCH_ID=b.branch_id  and b.firm_id=" & Session("firm_id") & "  and a.shift_id not in (4, 5)  group by a.branch_id, a.branch_name)  using (branch_id, branch_name)  group by branch_id, branch_name  order by branch_name"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Dim tb As New Table
        'tb.Attributes.Add("Border", "1")
        tb.Attributes.Add("width", "100%")

        Dim tr1 As New TableRow
        Dim td11 As New TableCell
        td11.Attributes.Add("width", "100%")
        td11.ColumnSpan = 90
        td11.HorizontalAlign = HorizontalAlign.Center
        td11.Text = "<font size=4><b>" & Me.Session("firm_name") & "</b></font>"
        tr1.Controls.Add(td11)
        tb.Controls.Add(tr1)

        Dim tr2 As New TableRow
        Dim td21 As New TableCell
        td21.Attributes.Add("width", "50%")
        td21.ColumnSpan = 45
        td21.HorizontalAlign = HorizontalAlign.Right
        td21.Text = "<font size=2><b>Branch-id :" & Me.Session("branch_id") & "</b></font>"
        tr2.Controls.Add(td21)
        Dim td22 As New TableCell
        td22.Attributes.Add("width", "50%")
        td22.ColumnSpan = 45
        td22.HorizontalAlign = HorizontalAlign.Left
        td22.Text = "<font size=2><b>Branch :" & Me.Session("branch_name") & "</b></font>"
        tr2.Controls.Add(td22)
        tb.Controls.Add(tr2)


        Dim tr3 As New TableRow
        Dim td31 As New TableCell
        td31.Attributes.Add("width", "50%")
        td31.ColumnSpan = 45
        td31.HorizontalAlign = HorizontalAlign.Left
        td31.Text = "<font size=2><b>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</b></font>"
        tr3.Controls.Add(td31)
        Dim td32 As New TableCell
        td32.Attributes.Add("width", "50%")
        td32.ColumnSpan = 45
        td32.HorizontalAlign = HorizontalAlign.Right
        td32.Text = "<font size=2><b>Time :" & Format(Date.Now, "hh:mm:ss") & "</b></font>"
        tr3.Controls.Add(td32)
        tb.Controls.Add(tr3)


        Dim tr4 As New TableRow
        tr4.BackColor = Drawing.Color.WhiteSmoke
        Dim td41 As New TableCell
        td41.Attributes.Add("width", "100%")
        td41.ColumnSpan = 90
        td41.HorizontalAlign = HorizontalAlign.Center

        sql = "select initcap(r.area_name) from area_master r where r.area_id=" & areaid
        dta = oh.ExecuteDataSet(sql).Tables(0)

        td41.Text = "<font size=3><b> Attendance Report of " & dta.Rows(0)(0) & " &nbsp Area From :&nbsp" & frdate & " &nbsp To :" & frdate & " </b></font>"
        tr4.Controls.Add(td41)
        tb.Controls.Add(tr4)

        Dim l1 As New TableRow
        Dim ld1 As New TableCell
        ld1.Attributes.Add("width", "100%")
        ld1.ColumnSpan = 90
        ld1.HorizontalAlign = HorizontalAlign.Center
        ld1.Text = "<font size=3><hr size='2' NOSHADE></font>"
        l1.Controls.Add(ld1)
        tb.Controls.Add(l1)

        Dim tr5 As New TableRow
        Dim td51 As New TableCell
        td51.Attributes.Add("width", "23%")
        td51.ColumnSpan = 20
        td51.HorizontalAlign = HorizontalAlign.Left
        td51.Text = "<font size=2.5><b>BRANCH NAME</b></font>"
        tr5.Controls.Add(td51)

        Dim td52 As New TableCell
        td52.Attributes.Add("width", "11%")
        td52.ColumnSpan = 10
        td52.HorizontalAlign = HorizontalAlign.Center
        td52.Text = "<font size=2.5><b>PRESENT</b></font>"
        tr5.Controls.Add(td52)

        Dim td53 As New TableCell
        td53.Attributes.Add("width", "11%")
        td53.ColumnSpan = 10
        td53.HorizontalAlign = HorizontalAlign.Center
        td53.Text = "<font size=2.5><b>ABSENT</b></font>"
        tr5.Controls.Add(td53)
        tb.Controls.Add(tr5)

        Dim td54 As New TableCell
        td54.Attributes.Add("width", "11%")
        td54.ColumnSpan = 10
        td54.HorizontalAlign = HorizontalAlign.Center
        td54.Text = "<font size=2.5><b>LATE</b></font>"
        tr5.Controls.Add(td54)

        Dim td55 As New TableCell
        td55.Attributes.Add("width", "11%")
        td55.ColumnSpan = 10
        td55.HorizontalAlign = HorizontalAlign.Center
        td55.Text = "<font size=2.5><b>EARLY GOING</b></font>"
        tr5.Controls.Add(td55)

        Dim td56 As New TableCell
        td56.Attributes.Add("width", "11%")
        td56.ColumnSpan = 10
        td56.HorizontalAlign = HorizontalAlign.Center
        td56.Text = "<font size=2.5><b>NON MARKING</b></font>"
        tr5.Controls.Add(td56)

        Dim td57 As New TableCell
        td57.Attributes.Add("width", "11%")
        td57.ColumnSpan = 10
        td57.HorizontalAlign = HorizontalAlign.Center
        td57.Text = "<font size=2.5><b>TOTAL STRENGTH</b></font>"
        tr5.Controls.Add(td57)

        Dim td58 As New TableCell
        td58.Attributes.Add("width", "11%")
        td58.ColumnSpan = 10
        td58.HorizontalAlign = HorizontalAlign.Center
        td58.Text = "<font size=2.5><b>LEAVE % </b></font>"
        tr5.Controls.Add(td58)
        tb.Controls.Add(tr5)

        Dim l2 As New TableRow
        Dim ld2 As New TableCell
        ld2.Attributes.Add("width", "100%")
        ld2.ColumnSpan = 90
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
                color = 0
                tr6.BackColor = Drawing.Color.WhiteSmoke
            End If

            Dim td61 As New TableCell
            td61.Attributes.Add("width", "23%")
            td61.ColumnSpan = 20
            td61.HorizontalAlign = HorizontalAlign.Left
            td61.Text = "<font size=2.5><a href = javascript:next(" & dr(0) & ",'" & frdate & "')>" & dr(1) & "</a></font>"
            tr6.Controls.Add(td61)

            Dim td62 As New TableCell
            td62.Attributes.Add("width", "11%")
            td62.ColumnSpan = 10
            td62.HorizontalAlign = HorizontalAlign.Center
            td62.Text = "<font size=2.5>" & dr(3) & "</font>"
            tr6.Controls.Add(td62)


            Dim td63 As New TableCell
            td63.Attributes.Add("width", "11%")
            td63.ColumnSpan = 10
            td63.HorizontalAlign = HorizontalAlign.Center
            td63.Text = "<font size=2.5>" & dr(4) & "</font>"
            tr6.Controls.Add(td63)

            Dim td64 As New TableCell
            td64.Attributes.Add("width", "11%")
            td64.ColumnSpan = 10
            td64.HorizontalAlign = HorizontalAlign.Center
            td64.Text = "<font size=2.5>" & dr(5) & "</font>"
            tr6.Controls.Add(td64)

            Dim td65 As New TableCell
            td65.Attributes.Add("width", "11%")
            td65.ColumnSpan = 10
            td65.HorizontalAlign = HorizontalAlign.Center
            td65.Text = "<font size=2.5>" & dr(6) & "</font>"
            tr6.Controls.Add(td65)

            Dim td66 As New TableCell
            td66.Attributes.Add("width", "11%")
            td66.ColumnSpan = 10
            td66.HorizontalAlign = HorizontalAlign.Center
            td66.Text = "<font size=2.5>" & dr(7) & "</font>"
            tr6.Controls.Add(td66)

            Dim td67 As New TableCell
            td67.Attributes.Add("width", "11%")
            td67.ColumnSpan = 10
            td67.HorizontalAlign = HorizontalAlign.Center
            td67.Text = "<font size=2.5>" & dr(2) & "</font>"
            tr6.Controls.Add(td67)

            If (dr(4) <> 0) Then
                lper = FormatNumber((dr(4) / dr(2)) * 100, 2)
            Else
                lper = 0.0
            End If

            Dim td68 As New TableCell
            td68.Attributes.Add("width", "16%")
            td68.ColumnSpan = 10
            td68.HorizontalAlign = HorizontalAlign.Center
            td68.Text = "<font size=2.5>" & lper & "</font>"
            tr6.Controls.Add(td68)

            tb.Controls.Add(tr6)


            totalpres = totalpres + dr(3)
            totalabsent = totalabsent + dr(4)
            totallate = totallate + dr(5)
            totalearly = totalearly + dr(6)
            totalnon = totalnon + dr(7)
            totalstr = totalstr + dr(2)

        Next

        Dim l3 As New TableRow
        Dim ld3 As New TableCell
        ld3.Attributes.Add("width", "100%")
        ld3.ColumnSpan = 90
        ld3.HorizontalAlign = HorizontalAlign.Center
        ld3.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
        l3.Controls.Add(ld3)
        tb.Controls.Add(l3)

        Dim tr7 As New TableRow

        Dim td71 As New TableCell
        td71.Attributes.Add("width", "23%")
        td71.ColumnSpan = 20
        td71.HorizontalAlign = HorizontalAlign.Center
        td71.Text = "<font size=2.5>TOTAL</font>"
        tr7.Controls.Add(td71)

        Dim td72 As New TableCell
        td72.Attributes.Add("width", "11%")
        td72.ColumnSpan = 10
        td72.HorizontalAlign = HorizontalAlign.Center
        td72.Text = "<font size=2.5>" & totalpres & "</font>"
        tr7.Controls.Add(td72)

        Dim td73 As New TableCell
        td73.Attributes.Add("width", "11%")
        td73.ColumnSpan = 10
        td73.HorizontalAlign = HorizontalAlign.Center
        td73.Text = "<font size=2.5>" & totalabsent & "</font>"
        tr7.Controls.Add(td73)

        Dim td74 As New TableCell
        td74.Attributes.Add("width", "11%")
        td74.ColumnSpan = 10
        td74.HorizontalAlign = HorizontalAlign.Center
        td74.Text = "<font size=2.5>" & totallate & "</font>"
        tr7.Controls.Add(td74)

        Dim td75 As New TableCell
        td75.Attributes.Add("width", "11%")
        td75.ColumnSpan = 10
        td75.HorizontalAlign = HorizontalAlign.Center
        td75.Text = "<font size=2.5>" & totalearly & "</font>"
        tr7.Controls.Add(td75)

        Dim td76 As New TableCell
        td76.Attributes.Add("width", "11%")
        td76.ColumnSpan = 10
        td76.HorizontalAlign = HorizontalAlign.Center
        td76.Text = "<font size=2.5>" & totalnon & "</font>"
        tr7.Controls.Add(td76)

        Dim td77 As New TableCell
        td77.Attributes.Add("width", "11%")
        td77.ColumnSpan = 10
        td77.HorizontalAlign = HorizontalAlign.Center
        td77.Text = "<font size=2.5> " & totalstr & "</font>"
        tr7.Controls.Add(td77)

        If (totalabsent <> 0) Then
            tlper = FormatNumber((totalabsent / totalstr) * 100, 2)
        Else
            tlper = 0.0
        End If

        Dim td78 As New TableCell
        td78.Attributes.Add("width", "11%")
        td78.ColumnSpan = 10
        td78.HorizontalAlign = HorizontalAlign.Center
        td78.Text = "<font size=2.5>" & tlper & "  </font>"
        tr7.Controls.Add(td78)




        tb.Controls.Add(tr7)


        Dim l4 As New TableRow
        Dim ld4 As New TableCell
        ld4.Attributes.Add("width", "100%")
        ld4.ColumnSpan = 90
        ld4.HorizontalAlign = HorizontalAlign.Center
        ld4.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
        l4.Controls.Add(ld4)
        tb.Controls.Add(l4)
        Me.Panel_report.Controls.Add(tb)
    End Sub
End Class

