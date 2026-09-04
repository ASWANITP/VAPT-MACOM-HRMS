Imports System.Data
Imports System.Data.OracleClient
Partial Class staff_noms_normleave_cd94dc497466
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tab As New Table
        tab.Attributes.Add("width", "100%")
        ' tab.Attributes.Add("border", "1")

        Dim tr1 As New TableRow
        Dim td11 As New TableCell
        tr1.Width = 8
        td11.ColumnSpan = 8
        td11.HorizontalAlign = HorizontalAlign.Center
        td11.Text = "<font size=4><b>" & Me.Session("firm_name") & "</b></font>"
        tr1.Controls.Add(td11)
        tab.Controls.Add(tr1)

        Dim tr2 As New TableRow
        tr2.Width = 8
        Dim td21 As New TableCell
        td21.ColumnSpan = 8
        td21.HorizontalAlign = HorizontalAlign.Center
        td21.Text = "<font size=2><b> " & Me.Session("branch_name") & " </b></font>"
        tr2.Controls.Add(td21)
        tab.Controls.Add(tr2)

        Dim trr As New TableRow
        trr.Width = 8
        Dim tdr1 As New TableCell
        tdr1.ColumnSpan = 8
        tdr1.HorizontalAlign = HorizontalAlign.Center
        tdr1.Text = "<font size=2><b> LONG LEAVE REPORT </b></font>"
        trr.Controls.Add(tdr1)
        tab.Controls.Add(trr)

        Dim tr3 As New TableRow
        tr3.Width = 8
        Dim td31 As New TableCell
        td31.ColumnSpan = 4
        td31.HorizontalAlign = HorizontalAlign.Left
        td31.Text = "<font size=2><b>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</b></font>"
        tr3.Controls.Add(td31)
        Dim td32 As New TableCell
        td32.ColumnSpan = 4
        td32.HorizontalAlign = HorizontalAlign.Right
        td32.Text = "<font size=2><b>Time :" & Format(Date.Now, "hh:mm:ss") & "</b></font>"
        tr3.Controls.Add(td32)
        tab.Controls.Add(tr3)

        Dim lin2101 As New TableRow
        Dim lin21011 As New TableCell
        lin21011.ColumnSpan = 8
        lin21011.Text = "<hr align=center width=100% >"
        lin2101.Controls.Add(lin21011)
        tab.Controls.Add(lin2101)



        Dim ta5 As New TableRow
        ta5.Width = 8
        Dim ta51, ta52, ta53, ta54, ta55, ta56 As New TableCell
        ta51.ColumnSpan = 1
        ta52.ColumnSpan = 1
        ta53.ColumnSpan = 2
        ta54.ColumnSpan = 2
        ta55.ColumnSpan = 1
        ta56.ColumnSpan = 1

        ta51.Text = "<font size=2><b>SI.NO</b></font>"
        ta52.Text = "<font size=2><b>EMP.CODE</b></font>"
        ta53.Text = "<font size=2><b>EMP&nbsp;NAME&nbsp;&nbsp;</b></font>"
        ta54.Text = "<font size=2><b>POST&nbsp;&nbsp;</b></font>"
        ta55.Text = "<font size=2><b>LAST PUNCH</b></font>"
        ta56.Text = "<font size=2><b>ABSENT DAYS</b></font>"

        ta51.HorizontalAlign = HorizontalAlign.Center
        ta52.HorizontalAlign = HorizontalAlign.Left
        ta53.HorizontalAlign = HorizontalAlign.Left
        ta54.HorizontalAlign = HorizontalAlign.Left
        ta55.HorizontalAlign = HorizontalAlign.Left
        ta56.HorizontalAlign = HorizontalAlign.Left


        ta5.Controls.Add(ta51)
        ta5.Controls.Add(ta52)
        ta5.Controls.Add(ta53)
        ta5.Controls.Add(ta54)
        ta5.Controls.Add(ta55)
        ta5.Controls.Add(ta56)
        tab.Controls.Add(ta5)

        Dim lin21012 As New TableRow
        Dim lin210112 As New TableCell
        lin210112.ColumnSpan = 8
        lin210112.Text = "<hr align=center width=100% >"
        lin21012.Controls.Add(lin210112)
        tab.Controls.Add(lin21012)

        Dim dt As New DataTable
        Dim sql As String = Nothing
        Dim dr As DataRow
        Dim cn1 As Integer = 0
        Dim oh As New Helper.Oracle.OracleHelper
        '   dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,p.post_name from attend a,employee_master e,post_mst p where m_time is null and e_time is null and curr_date between to_date(sysdate-7) and to_date(sysdate) and a.emp_code>9999 and a.branch_id=" & Request.QueryString("br_id") & " and a.emp_code=e.emp_code and e.post_id=p.post_id having count(*)>=7 group by e.emp_code,e.emp_name,p.post_name ").Tables(0)
        dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,p.post_name,s.last_punch,s.absent_days from employee_master e,staff_long_leave s,post_mst p where e.emp_code=s.emp_code and e.post_id=p.post_id and s.branch_id=" & Request.QueryString("br_id")).Tables(0)
        For Each dr In dt.Rows
            cn1 += 1
            Dim lm5 As New TableRow
            Dim lm51, lm52, lm53, lm54, lm55, lm56 As New TableCell
            lm51.ColumnSpan = 1
            lm51.HorizontalAlign = HorizontalAlign.Center
            lm51.Text = "<font size=2>" & cn1 & "</font>"
            lm5.Controls.Add(lm51)


            lm52.ColumnSpan = 1
            lm52.HorizontalAlign = HorizontalAlign.Left
            lm52.Text = "<font size=2> " & dr(0) & "</font>"
            lm5.Controls.Add(lm52)


            lm53.ColumnSpan = 2
            lm53.HorizontalAlign = HorizontalAlign.Left
            lm53.Text = "<font size=2> " & dr(1) & "</font>"
            lm5.Controls.Add(lm53)

            lm54.ColumnSpan = 2
            lm54.HorizontalAlign = HorizontalAlign.Left
            lm54.Text = "<font size=2> " & dr(2) & "</font>"
            lm5.Controls.Add(lm54)

            lm55.ColumnSpan = 1
            lm55.HorizontalAlign = HorizontalAlign.Left
            lm55.Text = "<font size=2> " & Format(dr(3), "dd/MMM/yyyy") & "</font>"
            lm5.Controls.Add(lm55)

            lm56.ColumnSpan = 1
            lm56.HorizontalAlign = HorizontalAlign.Left
            lm56.Text = "<font size=2> " & dr(4) & "</font>"
            lm5.Controls.Add(lm56)

            tab.Controls.Add(lm5)
        Next
        Dim lin210b As New TableRow
        Dim lin2101b As New TableCell
        lin2101b.ColumnSpan = 8
        lin2101b.Text = "<hr align=center width=100% >"
        lin210b.Controls.Add(lin2101b)
        tab.Controls.Add(lin210b)
        Me.Panel1.Controls.Add(tab)
    End Sub
End Class
