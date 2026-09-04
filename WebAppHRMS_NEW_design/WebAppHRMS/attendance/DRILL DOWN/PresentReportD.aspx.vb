Imports system.data
Imports system.data.oracleclient

Partial Class Attendence_Report_PresentReportD_31d5029f8076
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql, sql1 As String
    Dim dr As DataRow
    Dim per, totalper As Double
    Dim totalp = 0, totals = 0
    Dim category As Integer
    Dim cat As String
    Dim color As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fdate, tdate As String
        Dim regid As Integer
        fdate = Request.QueryString.Get("fdate")
        tdate = Request.QueryString.Get("tdate")
        regid = Request.QueryString.Get("regid")
        category = Request.QueryString.Get("category")
        Select Case category
            Case 1
                sql = "select count(da.emp_code),DM.DIV_NAME,DM.DIVISION_ID from ATTENDANCE da,branch_master bm,AREA_DETAIL AD,DIVISION_DETAIL DD,DIVISION_MASTER DM,REGION_DETAIL RD where bm.branch_id=da.branch_id  and da.branch_id=AD.BRANCH_ID AND AD.AREA_ID=DD.AREA_ID AND DD.DIV_ID=DM.DIVISION_ID AND DM.DIVISION_ID=RD.DIVISION_ID AND RD.REGION_ID=" & regid & " and da.curr_date>=to_date('" & fdate & "') and da.curr_date<=to_date('" & tdate & "') and (da.m_time is NOT NULL or da.e_time is NOT NULL or da.pay_id in (50,51,52,7)) and da.shift_id not in(4,5) and bm.firm_id = " & Session("firm_id") & " group by DM.DIV_NAME,DM.DIVISION_ID"
                cat = "PRESENT"
            Case 2
                sql = "select count(da.emp_code),DM.DIV_NAME,DM.DIVISION_ID from ATTENDANCE da,branch_master bm,AREA_DETAIL AD,DIVISION_DETAIL DD,DIVISION_MASTER DM,REGION_DETAIL RD where bm.branch_id=da.branch_id  and da.branch_id=AD.BRANCH_ID AND AD.AREA_ID=DD.AREA_ID AND DD.DIV_ID=DM.DIVISION_ID AND DM.DIVISION_ID=RD.DIVISION_ID AND RD.REGION_ID=" & regid & " and da.curr_date>=to_date('" & fdate & "') and da.curr_date<=to_date('" & tdate & "') and da.m_time is  NULL and da.e_time is  NULL and da.pay_id not in (50,51,52,7) and da.shift_id not in(4,5) and bm.firm_id = " & Session("firm_id") & " group by DM.DIV_NAME,DM.DIVISION_ID"
                cat = "ABSENT"
            Case 3
                sql = "select count(da.emp_code),DM.DIV_NAME,DM.DIVISION_ID from ATTENDANCE da,time_tab tt,branch_master bm,AREA_DETAIL AD,DIVISION_DETAIL DD,DIVISION_MASTER DM,REGION_DETAIL RD where bm.branch_id=da.branch_id  and da.branch_id=AD.BRANCH_ID AND AD.AREA_ID=DD.AREA_ID AND DD.DIV_ID=DM.DIVISION_ID AND DM.DIVISION_ID=RD.DIVISION_ID AND RD.REGION_ID=" & regid & " and da.curr_date>=to_date('" & fdate & "') and da.curr_date<=to_date('" & tdate & "') and da.m_shift = tt.shift_id And da.m_time > tt.in_time   and da.pay_id not in (50,52,7) and bm.firm_id = " & Session("firm_id") & " group by DM.DIV_NAME,DM.DIVISION_ID"
                cat = "LATE"
            Case 4
                sql = "select count(da.emp_code),DM.DIV_NAME,DM.DIVISION_ID from ATTENDANCE da,time_tab tt,branch_master bm,AREA_DETAIL AD,DIVISION_DETAIL DD,DIVISION_MASTER DM,REGION_DETAIL RD where bm.branch_id=da.branch_id  and da.branch_id=AD.BRANCH_ID AND AD.AREA_ID=DD.AREA_ID AND DD.DIV_ID=DM.DIVISION_ID AND DM.DIVISION_ID=RD.DIVISION_ID AND RD.REGION_ID=" & regid & " and da.curr_date>=to_date('" & fdate & "') and da.curr_date<=to_date('" & tdate & "') and da.e_shift = tt.shift_id And da.e_time < tt.out_time and da.pay_id not in (51,52,7) and bm.firm_id = " & Session("firm_id") & "  group by DM.DIV_NAME,DM.DIVISION_ID"
                cat = "EARLY GOING"
            Case 5
                sql = "select count(da.emp_code),DM.DIV_NAME,DM.DIVISION_ID from ATTENDANCE da,branch_master bm,AREA_DETAIL AD,DIVISION_DETAIL DD,DIVISION_MASTER DM,REGION_DETAIL RD where bm.branch_id=da.branch_id  and da.branch_id=AD.BRANCH_ID AND AD.AREA_ID=DD.AREA_ID AND DD.DIV_ID=DM.DIVISION_ID AND DM.DIVISION_ID=RD.DIVISION_ID AND RD.REGION_ID=" & regid & " and da.curr_date>=to_date('" & fdate & "') and da.curr_date<=to_date('" & tdate & "') and (((da.m_time is  null and da.pay_id<>50 ) or (da.e_time is  null and da.pay_id<>51)) AND NOT(DA.M_TIME IS NULL AND DA.E_TIME IS NULL) and da.pay_id not in (52)) and da.shift_id not in(4,5) and bm.firm_id = " & Session("firm_id") & " group by DM.DIV_NAME,DM.DIVISION_ID"
                cat = "NON MARKING"
        End Select
        dt = oh.ExecuteDataSet(sql).Tables(0)

        Dim tb As New Table
        'tb.Attributes.Add("Border", "1")
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

        Dim ss As String = oh.ExecuteDataSet("select reg_name from region_master where reg_id=" & Request.QueryString("regid")).Tables(0).Rows(0)(0)



        Dim tr4 As New TableRow
        Dim td41 As New TableCell
        td41.Attributes.Add("width", "100%")
        td41.ColumnSpan = 80
        td41.HorizontalAlign = HorizontalAlign.Center
        td41.BackColor = Drawing.Color.Bisque
        td41.Text = "<font size=3><b>" & cat & " &nbsp  Report From :&nbsp" & fdate & " &nbsp To :" & tdate & " Of Region " & ss & "</b></font>"
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
        td51.Attributes.Add("width", "30%")
        td51.ColumnSpan = 20
        td51.HorizontalAlign = HorizontalAlign.Left
        td51.Text = "<font size=2.5><b>DIVISION NAME</b></font>"
        tr5.Controls.Add(td51)

        Dim td52 As New TableCell
        td52.Attributes.Add("width", "25%")
        td52.ColumnSpan = 20
        td52.HorizontalAlign = HorizontalAlign.Center
        td52.Text = "<font size=2.5><b>NUMBER OF " & cat & "</b></font>"
        tr5.Controls.Add(td52)

        Dim td53 As New TableCell
        td53.Attributes.Add("width", "25%")
        td53.ColumnSpan = 20
        td53.HorizontalAlign = HorizontalAlign.Center
        td53.Text = "<font size=2.5><b>TOTAL STRENGTH</b></font>"
        tr5.Controls.Add(td53)
        tb.Controls.Add(tr5)

        Dim td54 As New TableCell
        td54.Attributes.Add("width", "25%")
        td54.ColumnSpan = 20
        td54.HorizontalAlign = HorizontalAlign.Center
        td54.Text = "<font size=2.5><b>" & cat & " %</b></font>"
        tr5.Controls.Add(td54)
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
                tr6.BackColor = Drawing.Color.WhiteSmoke
                color = 1
            Else
                tr6.BackColor = Drawing.Color.Snow
                color = 0
            End If
            Dim td61 As New TableCell
            td61.Attributes.Add("width", "30%")
            td61.ColumnSpan = 20
            td61.HorizontalAlign = HorizontalAlign.Left
            td61.Text = "<font size=2.5><a href = javascript:next(" & dr(2) & ",'" & fdate & "','" & tdate & "'," & category & ")>" & dr(1) & "</a></font>"
            tr6.Controls.Add(td61)

            Dim td62 As New TableCell
            td62.Attributes.Add("width", "25%")
            td62.ColumnSpan = 20
            td62.HorizontalAlign = HorizontalAlign.Center
            td62.Text = "<font size=2.5>" & dr(0) & "</font>"
            tr6.Controls.Add(td62)

            sql1 = "select count(da.emp_code),dd.div_id from ATTENDANCE da,branch_master bm,AREA_DETAIL AD,DIVISION_DETAIL DD where bm.branch_id=da.branch_id  and da.branch_id=AD.BRANCH_ID AND AD.AREA_ID=DD.AREA_ID AND DD.DIV_ID=" & dr(2) & " and da.curr_date>=to_date('" & fdate & "') and da.curr_date<=to_date('" & tdate & "')  group by dd.div_id"
            dt1 = oh.ExecuteDataSet(sql1).Tables(0)
            If (dr(0) <> 0) Then
                per = (dr(0) / dt1.Rows(0)(0)) * 100
            Else
                per = 0.0
            End If

            Dim td63 As New TableCell
            td63.Attributes.Add("width", "25%")
            td63.ColumnSpan = 20
            td63.HorizontalAlign = HorizontalAlign.Center
            td63.Text = "<font size=2.5>" & dt1.Rows(0)(0) & "</font>"
            tr6.Controls.Add(td63)
            tb.Controls.Add(tr6)


            Dim td64 As New TableCell
            td64.Attributes.Add("width", "25%")
            td64.ColumnSpan = 20
            td64.HorizontalAlign = HorizontalAlign.Center
            td64.Text = "<font size=2.5>" & FormatNumber(per, 2) & "</font>"
            tr6.Controls.Add(td64)
            tb.Controls.Add(tr6)
            totalp = totalp + dr(0)
            totals = totals + dt1.Rows(0)(0)
        Next

        Dim l3 As New TableRow
        Dim ld3 As New TableCell
        ld3.Attributes.Add("width", "100%")
        ld3.ColumnSpan = 80
        ld3.HorizontalAlign = HorizontalAlign.Center
        ld3.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
        l3.Controls.Add(ld3)
        tb.Controls.Add(l3)

        Dim tr7 As New TableRow

        Dim td71 As New TableCell
        td71.Attributes.Add("width", "30%")
        td71.ColumnSpan = 20
        td71.HorizontalAlign = HorizontalAlign.Center
        td71.Text = "<font size=2.5>TOTAL</font>"
        tr7.Controls.Add(td71)
        tb.Controls.Add(tr7)
        Me.Panel_report.Controls.Add(tb)

        Dim td72 As New TableCell
        td72.Attributes.Add("width", "25%")
        td72.ColumnSpan = 20
        td72.HorizontalAlign = HorizontalAlign.Center
        td72.Text = "<font size=2.5>" & totalp & "</font>"
        tr7.Controls.Add(td72)
        tb.Controls.Add(tr7)

        Dim td73 As New TableCell
        td73.Attributes.Add("width", "25%")
        td73.ColumnSpan = 20
        td73.HorizontalAlign = HorizontalAlign.Center
        td73.Text = "<font size=2.5>" & totals & "</font>"
        tr7.Controls.Add(td73)
        tb.Controls.Add(tr7)

        totalper = (totalp / totals) * 100

        Dim td74 As New TableCell
        td74.Attributes.Add("width", "25%")
        td74.ColumnSpan = 20
        td74.HorizontalAlign = HorizontalAlign.Center
        td74.Text = "<font size=2.5>" & FormatNumber(totalper, 2) & "</font>"
        tr7.Controls.Add(td74)
        tb.Controls.Add(tr7)

        Dim l4 As New TableRow
        Dim ld4 As New TableCell
        ld4.Attributes.Add("width", "100%")
        ld4.ColumnSpan = 80
        ld4.HorizontalAlign = HorizontalAlign.Center
        ld4.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
        l4.Controls.Add(ld4)
        tb.Controls.Add(l4)

        Me.Panel_report.Controls.Add(tb)
    End Sub

End Class
