Imports System.Data
Imports System.Data.OracleClient
Partial Class staff_noms_aoothers_9b1882705245
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim i As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim Sql As String = "select e.emp_code,e.emp_name,e.designation,e.department,e.post,e.join_dt,e.qualification,e.gender,e.exp_day,e.emp_type,e.status from employee_current e where e.status_id=1 and e.branch_id=0 and e.department_id not in(118,122,61,24,136,147,120,151,139,127,133,150,27,6,9,5,10,31,124,126,108,123,28,101,18,134,70,3,51,49,50,54,12,4,23,13,92,111,112,90,91,93,103,149,110,105,21,143,66,2,20,26,7,152,155,156,154,153,100) and e.post_id<>173 order by e.emp_code"
        dt = oh.ExecuteDataSet(Sql).Tables(0)
        Dim tab As New Table
        tab.Attributes.Add("width", "100%")
        ' tab.Attributes.Add("border", 1)

        Dim trr As New TableRow
        trr.Width = 16
        Dim tdr1 As New TableCell
        tdr1.ColumnSpan = 16
        tdr1.HorizontalAlign = HorizontalAlign.Center
        tdr1.ForeColor = Drawing.Color.Blue
        tdr1.Text = "<font size=4><b><u>A.O STAFF OTHERS</u></b></font>"
        trr.Controls.Add(tdr1)
        tab.Controls.Add(trr)


        Dim lin2101 As New TableRow
        lin2101.Width = 16
        Dim lin21011 As New TableCell
        lin21011.ColumnSpan = 16
        lin21011.Text = "<hr>"
        lin2101.Controls.Add(lin21011)
        tab.Controls.Add(lin2101)



        Dim tabh As New TableRow
        tabh.Width = 16
        Dim tabh1, tabh2, tabh3, tabh4, tabh5, tabh6, tabh7, tabh8, tabh9, tabh10, tabh11 As New TableCell
        tabh1.HorizontalAlign = HorizontalAlign.Left
        tabh2.HorizontalAlign = HorizontalAlign.Left
        tabh3.HorizontalAlign = HorizontalAlign.Left
        tabh4.HorizontalAlign = HorizontalAlign.Left
        tabh5.HorizontalAlign = HorizontalAlign.Left
        tabh6.HorizontalAlign = HorizontalAlign.Left
        tabh7.HorizontalAlign = HorizontalAlign.Left
        tabh8.HorizontalAlign = HorizontalAlign.Left
        tabh9.HorizontalAlign = HorizontalAlign.Left
        tabh10.HorizontalAlign = HorizontalAlign.Left
        tabh11.HorizontalAlign = HorizontalAlign.Left

        tabh1.ColumnSpan = 1
        tabh2.ColumnSpan = 2
        tabh3.ColumnSpan = 2
        tabh4.ColumnSpan = 2
        tabh5.ColumnSpan = 2
        tabh6.ColumnSpan = 1
        tabh7.ColumnSpan = 2
        tabh8.ColumnSpan = 1
        tabh9.ColumnSpan = 1
        tabh10.ColumnSpan = 1
        tabh11.ColumnSpan = 1

        tabh1.Text = "<font size=2><B>EMP CODE&nbsp;&nbsp;</B></font>"
        tabh2.Text = "<font size=2><B>EMP NAME&nbsp;&nbsp;</B></font>"
        tabh3.Text = "<font size=2><B>DESIGNATION&nbsp;&nbsp;</B></font>"
        tabh4.Text = "<font size=2><B>DEPARTMENT&nbsp;&nbsp;</B></font>"
        tabh5.Text = "<font size=2><B>POST&nbsp;&nbsp;</B></font>"
        tabh6.Text = "<font size=2><B>JOIN DATE&nbsp;&nbsp;</B></font>"
        tabh7.Text = "<font size=2><B>QUALIFICATION&nbsp;&nbsp;</B></font>"
        tabh8.Text = "<font size=2><B>GENDER&nbsp;&nbsp;</B></font>"
        tabh9.Text = "<font size=2><B>EXP DAY</B>&nbsp;&nbsp;</font>"
        tabh10.Text = "<font size=2><B>EMP TYPE</B></font>"
        tabh10.Text = "<font size=2><B>STATUS</B></font>"

        tabh.Controls.Add(tabh1)
        tabh.Controls.Add(tabh2)
        tabh.Controls.Add(tabh3)
        tabh.Controls.Add(tabh4)
        tabh.Controls.Add(tabh5)
        tabh.Controls.Add(tabh6)
        tabh.Controls.Add(tabh7)
        tabh.Controls.Add(tabh8)
        tabh.Controls.Add(tabh9)
        tabh.Controls.Add(tabh10)
        tabh.Controls.Add(tabh11)

        tab.Controls.Add(tabh)



        Dim tabrb1q As New TableRow
        Dim tabrb11 As New TableCell
        tabrb1q.Width = 16
        tabrb11.ColumnSpan = 16
        tabrb11.Text = "<hr>"
        tabrb1q.Controls.Add(tabrb11)
        tab.Controls.Add(tabrb1q)

        Dim dr As DataRow
        For Each dr In dt.Rows
            i += 1
            Dim tabr As New TableRow
            Dim tabrc1, tabrc2, tabrc3, tabrc4, tabrc5, tabrc6, tabrc7, tabrc8, tabrc9, tabrc10, tabrc11 As New TableCell
            tabr.Width = 16
            tabrc1.HorizontalAlign = HorizontalAlign.Left
            tabrc2.HorizontalAlign = HorizontalAlign.Left
            tabrc3.HorizontalAlign = HorizontalAlign.Left
            tabrc4.HorizontalAlign = HorizontalAlign.Left
            tabrc5.HorizontalAlign = HorizontalAlign.Left
            tabrc6.HorizontalAlign = HorizontalAlign.Left
            tabrc7.HorizontalAlign = HorizontalAlign.Left
            tabrc8.HorizontalAlign = HorizontalAlign.Left
            tabrc9.HorizontalAlign = HorizontalAlign.Left
            tabrc10.HorizontalAlign = HorizontalAlign.Left
            tabrc11.HorizontalAlign = HorizontalAlign.Left


            tabrc1.ColumnSpan = 1
            tabrc2.ColumnSpan = 2
            tabrc3.ColumnSpan = 2
            tabrc4.ColumnSpan = 2
            tabrc5.ColumnSpan = 2
            tabrc6.ColumnSpan = 1
            tabrc7.ColumnSpan = 2
            tabrc8.ColumnSpan = 1
            tabrc9.ColumnSpan = 1
            tabrc10.ColumnSpan = 1
            tabrc11.ColumnSpan = 1

            tabrc1.Text = "<font size=2>" & dr(0) & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            tabrc2.Text = "<font size=2>" & dr(1) & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            tabrc3.Text = "<font size=2>" & dr(2) & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            tabrc4.Text = "<font size=2>" & dr(3) & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            tabrc5.Text = "<font size=2>" & dr(4) & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            tabrc6.Text = "<font size=2>" & Format(dr(5), "dd/MMM/yyyy") & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            tabrc7.Text = "<font size=2>" & dr(6) & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            tabrc8.Text = "<font size=2>" & dr(7) & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            tabrc9.Text = "<font size=2>" & dr(8) & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            tabrc10.Text = "<font size=2>" & dr(9) & "</font>"
            tabrc10.Text = "<font size=2>" & dr(10) & "</font>"


            tabr.Controls.Add(tabrc1)
            tabr.Controls.Add(tabrc2)
            tabr.Controls.Add(tabrc3)
            tabr.Controls.Add(tabrc4)
            tabr.Controls.Add(tabrc5)
            tabr.Controls.Add(tabrc6)
            tabr.Controls.Add(tabrc7)
            tabr.Controls.Add(tabrc8)
            tabr.Controls.Add(tabrc9)
            tabr.Controls.Add(tabrc10)
            tabr.Controls.Add(tabrc11)

            tab.Controls.Add(tabr)

        Next

        Dim lin22 As New TableRow
        Dim lin221 As New TableCell
        lin221.ColumnSpan = 16
        lin221.Text = "<hr >"
        lin22.Controls.Add(lin221)
        tab.Controls.Add(lin22)

        Dim trrl As New TableRow
        trrl.Width = 16
        Dim ltdr1 As New TableCell
        ltdr1.ColumnSpan = 16
        ltdr1.HorizontalAlign = HorizontalAlign.Left
        ltdr1.ForeColor = Drawing.Color.Blue
        ltdr1.Text = "<font size=2><b>Total&nbsp;Employees&nbsp;:&nbsp;</b>" & Me.i & "</font>"
        trrl.Controls.Add(ltdr1)
        tab.Controls.Add(trrl)


        Me.Panel1.Controls.Add(tab)
    End Sub
End Class
