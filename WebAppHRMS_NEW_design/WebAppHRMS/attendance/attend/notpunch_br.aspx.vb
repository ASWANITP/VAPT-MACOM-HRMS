Imports System.Data

Partial Class attend_attend_br_f1ce36f08881
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim arun As String = "select bm.branch_name,count(distinct t.emp_code),bm.branch_id from attend t,branch_master bm,state_master st,district_master dm where  bm.district_id=dm.district_id and dm.district_id=" & Request.QueryString.Get("did") & " and st.state_id=bm.state_id and st.state_id=" & Request.QueryString.Get("stid") & " and t.branch_id=bm.branch_id and emp_code<9999 and shift_id in(" & Request.QueryString("shift") & ") and to_date(curr_date)>='" & Request.QueryString("fdt") & "' and to_date(curr_date)<='" & Request.QueryString("tdt") & "' and (t.m_time is null or t.e_time is null)and shift_id in (" & Request.QueryString("shift") & ")  group by bm.branch_name,bm.branch_id union all select bm.branch_name,count(distinct t.emp_code),bm.branch_id  from district_master dm,daily_attend t,branch_master bm,state_master st where bm.district_id=dm.district_id and dm.district_id=" & Request.QueryString("did") & " and st.state_id=" & Request.QueryString("stid") & " and st.state_id=bm.state_id and t.branch_id=bm.branch_id and emp_code<9999 and shift_id in(" & Request.QueryString("shift") & ") and to_date(curr_date)>='" & Request.QueryString("fdt") & "' and to_date(curr_date)<='" & Request.QueryString("tdt") & "' and (t.m_time is null or t.e_time is null)and shift_id in (" & Request.QueryString("shift") & ") group by bm.branch_name,bm.branch_id"
        'Dim arun As String = "select bm.branch_name,count(distinct t.emp_code),bm.branch_id from attend t,branch_master bm,state_master st,division_detail dt,division_master dm where bm.branch_id=dt.branch_id and dt.division_id=dm.division_id and dt.division_id=" & Request.QueryString.Get("did") & " and st.state_id=bm.state_id and st.state_id=" & Request.QueryString.Get("stid") & " and t.branch_id=bm.branch_id and dt.branch_id=bm.branch_id and emp_code<9999 and shift_id in(" & Request.QueryString("shift") & ") and to_date(curr_date)>='" & Request.QueryString("fdt") & "' and to_date(curr_date)<='" & Request.QueryString("tdt") & "' and shift_id in (" & Request.QueryString("shift") & ")  group by bm.branch_name,bm.branch_id union all select bm.branch_name,count(distinct t.emp_code),bm.branch_id  from division_master dm,division_detail dt,daily_attend t,branch_master bm,state_master st where dm.division_id=dt.division_id and dt.division_id=" & Request.QueryString("did") & " and st.state_id=" & Request.QueryString("stid") & " and dt.branch_id=bm.branch_id and dt.branch_id=bm.branch_id and st.state_id=bm.state_id and t.branch_id=bm.branch_id and emp_code<9999 and shift_id in(" & Request.QueryString("shift") & ") and to_date(curr_date)>='" & Request.QueryString("fdt") & "' and to_date(curr_date)<='" & Request.QueryString("tdt") & "' and shift_id in (" & Request.QueryString("shift") & ") group by bm.branch_name,bm.branch_id"
        Dim oh As New Helper.Oracle.OracleHelper
        dt = oh.ExecuteDataSet(arun).Tables(0)
        Dim ar As DataRow
        Dim attend As New Table
        Dim trt1 As New TableRow
        Dim tct1 As New TableCell
        tct1.ColumnSpan = 5

        tct1.HorizontalAlign = HorizontalAlign.Center
        tct1.Text = "<b><font size=2 >" & Session("firm_name") & "</font></b>"
        trt1.Controls.Add(tct1)
        attend.Controls.Add(trt1)

        Dim tr_br As New TableRow
        Dim tc_br As New TableCell
        tc_br.ColumnSpan = 5
        tc_br.HorizontalAlign = HorizontalAlign.Center
        tc_br.Text = "<b><font size=2 >Branch ID-" & Session("branch_id") & "," + "  Branch  " & Session("branch_name") & " </font></b>"
        tr_br.Controls.Add(tc_br)
        attend.Controls.Add(tr_br)

        Dim trt2 As New TableRow
        Dim tct2 As New TableCell
        tct2.ColumnSpan = 1
        tct2.Text = "<b><font size=2 >" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        tct2.HorizontalAlign = HorizontalAlign.Left
        trt2.Controls.Add(tct2)

        Dim tct3 As New TableCell
        tct3.ColumnSpan = 2
        tct3.Text = "<b><font size=2 > Attendence Report Not Punched Branches </font></b>"
        tct3.HorizontalAlign = HorizontalAlign.Center
        trt2.Controls.Add(tct3)
        Dim tct4 As New TableCell
        tct4.ColumnSpan = 1
        tct4.Text = "<b><font size=2 >" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        tct4.HorizontalAlign = HorizontalAlign.Right
        trt2.Controls.Add(tct4)
        attend.Controls.Add(trt2)

        Dim tc1 As New TableCell
        Dim tc2 As New TableCell
        Dim tc3 As New TableCell
        Dim tc4 As New TableCell
        Dim tc5 As New TableCell
        Dim tc6 As New TableCell
        Dim tr As New TableRow
        Dim tr1 As New TableRow
        Dim a As Integer
        Dim line1 As New TableRow
        Dim line11 As New TableCell
        line11.ColumnSpan = 4
        line11.Text = "<hr align=center width=100% >"
        line1.Controls.Add(line11)
        attend.Controls.Add(line1)

        attend.Attributes.Add("align", "center")
        attend.Attributes.Add("width", "75%")
        Dim q As New TableRow
        Dim q1 As New TableCell
        Dim q2 As New TableCell
        q1.Text = "Branch Name"
        q.Cells.Add(q1)
        q2.Text = "Count"
        q2.HorizontalAlign = HorizontalAlign.Right
        q.Cells.Add(q2)
        attend.Rows.Add(q)
        Dim line10 As New TableRow
        Dim line101 As New TableCell
        line101.ColumnSpan = 4
        line101.Text = "<hr align=center width=100% >"
        line10.Controls.Add(line101)
        attend.Controls.Add(line10)
        Dim c As Integer
        For Each ar In dt.Rows
            Dim t As New TableRow
            'Dim z As New TableRow
            Dim t1 As New TableCell
            Dim t2 As New TableCell
            Dim t3 As New TableCell
            Dim t4 As New TableCell
            Dim t5 As New TableCell
            Dim t6 As New TableCell
            'Dim p As Integer = -1
            t1.Text = "<a href=notpunch_emp.aspx?id=" & ar(2) & "&shift=" & Request.QueryString("shift") & "&fdate=" & Request.QueryString("fdt") & "&tdate=" & Request.QueryString("tdt") & ">" & ar(0) & "</a>"
            t.Cells.Add(t1)
            t2.Text = ar(1)
            c = c + ar(1)
            t2.HorizontalAlign = HorizontalAlign.Right
            t.Cells.Add(t2)
            attend.Rows.Add(t)
        Next
        Dim line110 As New TableRow
        Dim line1101 As New TableCell
        line1101.ColumnSpan = 4
        line1101.Text = "<hr align=center width=100% >"
        line110.Controls.Add(line1101)
        attend.Controls.Add(line110)

        Dim l As New TableRow
        Dim l0 As New TableCell
        Dim l1 As New TableCell
        Dim l2 As New TableCell
        Dim l3 As New TableCell
        l0.Text = "&nbsp"
        l.Cells.Add(l0)
        l1.Text = "Total"
        l.Cells.Add(l1)
        l2.Text = c
        l2.HorizontalAlign = HorizontalAlign.Center
        l.Cells.Add(l2)
        'l3.Text = FormatNumber(price, 2)
        'l3.HorizontalAlign = HorizontalAlign.Right
        'l.Cells.Add(l3)
        attend.Rows.Add(l)

        Dim line210 As New TableRow
        Dim line2101 As New TableCell
        line2101.ColumnSpan = 4
        line2101.Text = "<hr align=center width=100% >"
        line210.Controls.Add(line2101)
        attend.Controls.Add(line210)
        Me.pnl_attendbr.Controls.Add(attend)
    End Sub
End Class
