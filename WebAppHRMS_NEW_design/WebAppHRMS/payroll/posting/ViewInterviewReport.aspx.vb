Imports System.Data
Imports System.Data.OracleClient
Partial Class InterviewScheduling_ViewInterviewReport_0a7181d58749
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'TextBox1.Text = Request.QueryString("Date_From")
        'TextBox2.Text = Request.QueryString("Date_To")
        Dim intschtable As New Table
        'intschtable.BorderStyle = BorderStyle.Solid
        Dim header As New TableRow
        header.Width = 16
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        Dim headcell As New TableCell
        headcell.ColumnSpan = 16
        headcell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headcell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headcell)
        intschtable.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.Width = 16
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 16
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        intschtable.Controls.Add(sheader)


        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 16
        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 3
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 9
        subcell2.HorizontalAlign = HorizontalAlign.Center
        'subcell2.Text = "<b><font size=2> Interview Schedule Report Between " & Request.QueryString("Date_From") & " and " & Request.QueryString("Date_To") & " </font></b>"
        subh.Controls.Add(subcell2)
        subcell3.ColumnSpan = 4
        subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss") & "</font></b>"
        subcell3.HorizontalAlign = HorizontalAlign.Center
        subh.Controls.Add(subcell3)
        intschtable.Controls.Add(subh)

        Dim pheader As New TableRow
        Dim pheadercell As New TableCell
        pheader.Width = 16
        pheadercell.ColumnSpan = 16
        pheadercell.HorizontalAlign = HorizontalAlign.Center

        pheadercell.Text = "<body align=center ><b><font size=3> Interview Schedule Report Between " & Request.QueryString("Date_From") & " and " & Request.QueryString("Date_To") & " </font></b>"
        pheader.Controls.Add(pheadercell)
        intschtable.Controls.Add(pheader)

        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        line1.Width = 16
        linecell1.ColumnSpan = 16
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        intschtable.Controls.Add(line1)

        Dim fieldh As New TableRow
        fieldh.Width = 16
        fieldh.BorderWidth = 1
        fieldh.BorderStyle = BorderStyle.Solid
        fieldh.BorderColor = Drawing.Color.AliceBlue
        Dim t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13 As New TableCell
        t8.ColumnSpan = 1
        t1.ColumnSpan = 1
        t2.ColumnSpan = 1
        t3.ColumnSpan = 2
        t4.ColumnSpan = 2
        t5.ColumnSpan = 2
        t6.ColumnSpan = 2
        t7.ColumnSpan = 5
        't8.ColumnSpan = 2
        't9.ColumnSpan = 1
        't10.ColumnSpan = 1
        't11.ColumnSpan = 1
        't12.ColumnSpan = 3
        't13.ColumnSpan = 3
        t1.HorizontalAlign = HorizontalAlign.Left
        t2.HorizontalAlign = HorizontalAlign.Center
        t3.HorizontalAlign = HorizontalAlign.Center
        t4.HorizontalAlign = HorizontalAlign.Center
        t5.HorizontalAlign = HorizontalAlign.Center
        t6.HorizontalAlign = HorizontalAlign.Center
        t7.HorizontalAlign = HorizontalAlign.Center
        t8.HorizontalAlign = HorizontalAlign.Center
        't9.HorizontalAlign = HorizontalAlign.Center
        't10.HorizontalAlign = HorizontalAlign.Center
        't11.HorizontalAlign = HorizontalAlign.Center
        't12.HorizontalAlign = HorizontalAlign.Center
        't13.HorizontalAlign = HorizontalAlign.Right
        t8.Text = "<b><font size=2>SI No</font></b>"
        t1.Text = "<b><font size=2> SCHEDULE NO&nbsp;&nbsp</font></b>"
        t2.Text = "<b><font size=2> &nbsp;&nbspDATE</font></b>"
        t3.Text = "<b><font size=2> &nbsp;&nbspPLACE</font></b>"
        t4.Text = "<b><font size=2>&nbsp;&nbspDISTRICT</font></b>"
        t5.Text = "<b><font size=2>&nbsp;&nbspSTATE</font></b>"
        t6.Text = "<b><font size=2>&nbsp;&nbspPOST OFFERED</font></b>"
        t7.Text = "<b><font size=2>&nbsp;&nbspINTERVIEWER & DESIGNATION</font></b>"
        't8.Text = "<b><font size=2>&nbsp;&nbspDESIGNATION</font></b>"
        fieldh.Controls.Add(t8)
        fieldh.Controls.Add(t1)
        fieldh.Controls.Add(t2)
        fieldh.Controls.Add(t3)
        fieldh.Controls.Add(t4)
        fieldh.Controls.Add(t5)
        fieldh.Controls.Add(t6)
        fieldh.Controls.Add(t7)
        'fieldh.Controls.Add(t8)
        'fieldh.Controls.Add(t9)
        'fieldh.Controls.Add(t10)
        'fieldh.Controls.Add(t11)
        'fieldh.Controls.Add(t12)
        'fieldh.Controls.Add(t13)
        intschtable.Controls.Add(fieldh)
        Dim line4 As New TableRow
        Dim linecell4 As New TableCell
        line4.Width = 16
        linecell4.ColumnSpan = 16
        linecell4.Text = "<hr>"
        line4.Controls.Add(linecell4)
        intschtable.Controls.Add(line4)

        dt = oh.ExecuteDataSet(Request.QueryString("str2")).Tables(0)
        Dim colors As String
        colors = "#fff7ff"
        Dim i As Integer = 0
        For Each dr In dt.Rows
            i = i + 1
            If colors.Equals("#fff7ff") = True Then
                colors = "#eef9ff"
            Else
                colors = "#fff7ff"
            End If
            Dim tabr7 As New TableRow
            tabr7.Width = 16
            tabr7.Attributes.Add("bgcolor", colors)
            Dim tabr7c1, tabr7c2, tabr7c3, tabr7c4, tabr7c5, tabr7c6, tabr7c7, tabr7c8 As New TableCell
            tabr7c8.ColumnSpan = "1"
            tabr7c1.ColumnSpan = "1"
            tabr7c2.ColumnSpan = "1"
            tabr7c3.ColumnSpan = "2"
            tabr7c4.ColumnSpan = "2"
            tabr7c5.ColumnSpan = "2"
            tabr7c6.ColumnSpan = "2"
            tabr7c7.ColumnSpan = "5"
            'tabr7c8.ColumnSpan = "2"

            tabr7c8.Attributes.Add("align", "center")
            tabr7c1.Attributes.Add("align", "center")
            tabr7c2.Attributes.Add("align", "left")
            tabr7c3.Attributes.Add("align", "left")
            tabr7c4.Attributes.Add("align", "left")
            tabr7c5.Attributes.Add("align", "left")
            tabr7c6.Attributes.Add("align", "left")
            tabr7c7.Attributes.Add("align", "left")
            'tabr7c8.Attributes.Add("align", "left")

            'ks.interview_dt,s.state_name,d.district_name,p.postoffer_name,
            'case ks.place_st when 1 then upper(ks.other_place) when 2 then 
            '(select upper(br.branch_name) from branch_master br where ks.branch_id=br.branch_id) end place,
            'e.emp_code, e.emp_name, des.designation
            tabr7c8.Text = "<font size=2>&nbsp;" & i & "</font>"
            tabr7c1.Text = "<font size=2>&nbsp;&nbsp" & dr(0) & "</font>"
            tabr7c2.Text = "<font size=2>&nbsp;&nbsp&nbsp;" & Format(dr(1), "dd/MMM/yyyy") & "&nbsp;&nbsp;</font>"
            tabr7c3.Text = "<font size=2>&nbsp;&nbsp&nbsp;" & dr(5) & "&nbsp;&nbsp;</font>"
            tabr7c4.Text = "<font size=2>&nbsp;&nbsp&nbsp;" & dr(3) & "&nbsp;&nbsp;</font>"
            tabr7c5.Text = "<font size=2>&nbsp;&nbsp&nbsp;" & dr(2) & "&nbsp;&nbsp;</font>"
            tabr7c6.Text = "<font size=2>&nbsp;&nbsp&nbsp;" & dr(4) & " &nbsp;&nbsp;</font>"
            tabr7c7.Text = "<font size=2>&nbsp&nbsp;" & dr(6) & "&nbsp;&nbsp;--&nbsp;" & dr(7) & "&nbsp;&nbsp;(&nbsp;" & dr(8) & "&nbsp;)</font>"
            'tabr7c8.Text = "<font size=2>&nbsp;" & dr(8) & "</font>"
            tabr7.Controls.Add(tabr7c8)
            tabr7.Controls.Add(tabr7c1)
            tabr7.Controls.Add(tabr7c2)
            tabr7.Controls.Add(tabr7c3)
            tabr7.Controls.Add(tabr7c4)
            tabr7.Controls.Add(tabr7c5)
            tabr7.Controls.Add(tabr7c6)
            tabr7.Controls.Add(tabr7c7)
            'tabr7.Controls.Add(tabr7c8)

            intschtable.Controls.Add(tabr7)
        Next
        Dim line5 As New TableRow
        Dim linecell5 As New TableCell
        line5.Width = 16
        linecell5.ColumnSpan = 16
        linecell5.Text = "<hr>"
        line5.Controls.Add(linecell5)
        intschtable.Controls.Add(line5)
        Pnl_InterviewReport.Controls.Add(intschtable)
    End Sub
End Class
