Imports system.data

Imports system.data.oracleclient
Partial Class Attendence_Report_PresentReportE_3e55437b1912
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql, sql1 As String
    Dim dr As DataRow
    Dim per, totalper As Double
    Dim totalp = 0, totals = 0
    Dim category, type, id As Integer
    Dim cat As String
    Dim color As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fdate, tdate As String
        Dim brid As Integer
        fdate = Request.QueryString.Get("fdate")
        tdate = Request.QueryString.Get("tdate")
        brid = Request.QueryString.Get("brid")
        category = Request.QueryString.Get("category")
        type = Request.QueryString.Get("type")
        id = Request.QueryString.Get("id")

        Dim dts As DataTable = oh.ExecuteDataSet("select t.query from MACTECH.hrm_report_master t where t.query_id=163 and t.firm_id=99").Tables(0)
        sql = dts.Rows(0)(0).ToString.Replace("myfrom", Request.QueryString.Get("fdt"))
        sql = sql.Replace("myto", Request.QueryString.Get("tdt"))
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
        Dim td41 As New TableCell
        td41.Attributes.Add("width", "100%")
        td41.ColumnSpan = 80
        td41.HorizontalAlign = HorizontalAlign.Center
        td41.BackColor = Drawing.Color.Bisque
        td41.Text = "<font size=3><b>" & cat & " &nbspReport From :&nbsp" & Request.QueryString.Get("fdt") & " &nbsp To :" & Request.QueryString.Get("tdt") & " </b></font>"
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
        td52.Text = "<font size=2.5><b>BR-ID</b></font>"
        tr5.Controls.Add(td52)

        Dim td53 As New TableCell
        td53.Attributes.Add("width", "15%")
        td53.ColumnSpan = 17
        td53.HorizontalAlign = HorizontalAlign.Left
        td53.Text = "<font size=2.5><b>BRANCH NAME</b></font>"
        tr5.Controls.Add(td53)


        Dim td54 As New TableCell
        td54.Attributes.Add("width", "10%")
        td54.ColumnSpan = 5
        td54.HorizontalAlign = HorizontalAlign.Left
        td54.Text = "<font size=2.5><b>REMARKS</b></font>"
        tr5.Controls.Add(td54)

        Dim td55 As New TableCell
        td55.Attributes.Add("width", "15%")
        td55.ColumnSpan = 15
        td55.HorizontalAlign = HorizontalAlign.Left
        td55.Text = "<font size=2.5><b>EMP CODE</b></font>"
        tr5.Controls.Add(td55)

        Dim td56 As New TableCell
        td56.Attributes.Add("width", "10%")
        td56.ColumnSpan = 5
        td56.HorizontalAlign = HorizontalAlign.Left
        td56.Text = "<font size=2.5><b>EMP NAME</b></font>"
        tr5.Controls.Add(td56)

        Dim td57 As New TableCell
        td57.Attributes.Add("width", "15%")
        td57.ColumnSpan = 15
        td57.HorizontalAlign = HorizontalAlign.Left
        td57.Text = "<font size=2.5><b>POST</b></font>"
        tr5.Controls.Add(td57)

        Dim td58 As New TableCell
        td58.Attributes.Add("width", "20%")
        td58.ColumnSpan = 8
        td58.HorizontalAlign = HorizontalAlign.Center
        td58.Text = "<font size=2.5><b>DESIGNATION</b></font>"
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
                tr6.BackColor = Drawing.Color.Snow
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
            td62.Text = "<font size=2>" & dr(1) & "</font>"
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

        'Dim tr7 As New TableRow

        'Dim td71 As New TableCell
        'td71.Attributes.Add("width", "30%")
        'td71.ColumnSpan = 20
        'td71.HorizontalAlign = HorizontalAlign.Center
        'td71.Text = "<font size=2.5>TOTAL</font>"
        'tr7.Controls.Add(td71)
        'tb.Controls.Add(tr7)
        'Me.Panel_report.Controls.Add(tb)

        'Dim td72 As New TableCell
        'td72.Attributes.Add("width", "25%")
        'td72.ColumnSpan = 20
        'td72.HorizontalAlign = HorizontalAlign.Center
        'td72.Text = "<font size=2.5>" & totalp & "</font>"
        'tr7.Controls.Add(td72)
        'tb.Controls.Add(tr7)

        'Dim td73 As New TableCell
        'td73.Attributes.Add("width", "25%")
        'td73.ColumnSpan = 20
        'td73.HorizontalAlign = HorizontalAlign.Center
        'td73.Text = "<font size=2.5>" & totals & "</font>"
        'tr7.Controls.Add(td73)
        'tb.Controls.Add(tr7)

        'totalper = (totalp / totals) * 100

        'Dim td74 As New TableCell
        'td74.Attributes.Add("width", "25%")
        'td74.ColumnSpan = 20
        'td74.HorizontalAlign = HorizontalAlign.Center
        'td74.Text = "<font size=2.5>" & FormatNumber(totalper, 2) & "</font>"
        'tr7.Controls.Add(td74)
        'tb.Controls.Add(tr7)

        'Dim l4 As New TableRow
        'Dim ld4 As New TableCell
        'ld4.Attributes.Add("width", "100%")
        'ld4.ColumnSpan = 90
        'ld4.HorizontalAlign = HorizontalAlign.Center
        'ld4.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
        'l4.Controls.Add(ld4)
        'tb.Controls.Add(l4)

        Me.Panel_report.Controls.Add(tb)
    End Sub
End Class
