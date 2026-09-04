Imports System.Data
Imports System.Data.OracleClient

Partial Class staff_noms_short_ae822efc7052
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oh As New Helper.Oracle.OracleHelper
        Dim dt As New DataTable
        'dt = oh.ExecuteDataSet("select nvl(st.sr_bh-st.sr_bh_avbl,0),nvl(st.bh-st.bh_avbl,0),nvl(st.abh-st.abh_avbl,0),nvl(st.jr_asst-st.jr_asst_avbl,0),nvl(st.sweeper-st.sweeper_avbl,0) from staff_required st where st.branch_id=" & Request.QueryString("br_id")).Tables(0)

        '                                         
        dt = oh.ExecuteDataSet("select nvl(st.bh-st.bh_avbl,0),nvl(st.abh-st.abh_avbl,0),nvl(st.jr_asst-st.jr_asst_avbl,0),nvl(st.sweeper-st.sweeper_avbl,0),nvl(st.jo-st.jo_avbl,0) from staff_required st where st.branch_id=" & Request.QueryString("br_id")).Tables(0)
        Dim tab As New Table
        tab.Attributes.Add("width", "100%")
        tab.Attributes.Add("align", "left")
        tab.Attributes.Add("border", "0")

        Dim tr1 As New TableRow
        Dim td11 As New TableCell
        td11.Attributes.Add("width", "100%")
        td11.ColumnSpan = 14
        td11.HorizontalAlign = HorizontalAlign.Center
        td11.Text = "<font size=4><b>" & Me.Session("firm_name") & "</b></font>"
        tr1.Controls.Add(td11)
        tab.Controls.Add(tr1)

        Dim tr2 As New TableRow
        Dim td21 As New TableCell
        td21.Attributes.Add("width", "100%")
        td21.ColumnSpan = 14
        td21.HorizontalAlign = HorizontalAlign.Center
        td21.Text = "<font size=2><b> " & Me.Session("branch_name") & " </b></font>"
        tr2.Controls.Add(td21)
        tab.Controls.Add(tr2)

        Dim trr As New TableRow
        Dim tdr1 As New TableCell
        tdr1.Attributes.Add("width", "100%")
        tdr1.ColumnSpan = 14
        tdr1.HorizontalAlign = HorizontalAlign.Center
        tdr1.Text = "<font size=2><b> SHORT(TOT) REPORT </b></font>"
        trr.Controls.Add(tdr1)
        tab.Controls.Add(trr)

        Dim tr3 As New TableRow
        Dim td31 As New TableCell
        td31.Attributes.Add("width", "50%")
        td31.ColumnSpan = 7
        td31.HorizontalAlign = HorizontalAlign.Left
        td31.Text = "<font size=2><b>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</b></font>"
        tr3.Controls.Add(td31)
        Dim td32 As New TableCell
        td32.Attributes.Add("width", "50%")
        td32.ColumnSpan = 7
        td32.HorizontalAlign = HorizontalAlign.Right
        td32.Text = "<font size=2><b>Time :" & Format(Date.Now, "hh:mm:ss") & "</b></font>"
        tr3.Controls.Add(td32)
        tab.Controls.Add(tr3)

        Dim lin2101 As New TableRow
        Dim lin21011 As New TableCell
        lin21011.ColumnSpan = 14
        lin21011.Text = "<hr align=center width=100% >"
        lin2101.Controls.Add(lin21011)
        tab.Controls.Add(lin2101)

        Dim tabr2 As New TableRow
        Dim tabr2c1, tabr2c2 As New TableCell
        tabr2c1.ColumnSpan = 7
        tabr2c2.ColumnSpan = 7
        tabr2c1.HorizontalAlign = HorizontalAlign.Left
        tabr2c2.HorizontalAlign = HorizontalAlign.Left

        tabr2c1.Text = "<font size=2>" & "BH" & "</font>"
        If dt.Rows(0)(0) > 0 Then
            tabr2c2.Text = "<font size=2> -- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp" & dt.Rows(0)(0) & "</font>"
        End If
        tabr2.Controls.Add(tabr2c1)
        tabr2.Controls.Add(tabr2c2)
        tab.Controls.Add(tabr2)

        Dim tabr3 As New TableRow
        Dim tabr3c1, tabr3c2 As New TableCell
        tabr3c1.ColumnSpan = 7
        tabr3c2.ColumnSpan = 7
        tabr3c1.HorizontalAlign = HorizontalAlign.Left
        tabr3c2.HorizontalAlign = HorizontalAlign.Left

        tabr3c1.Text = "<font size=2>" & "ABH" & "</font>"
        If dt.Rows(0)(1) > 0 Then
            tabr3c2.Text = "<font size=2> -- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp" & dt.Rows(0)(1) & "</font>"
        End If
        tabr3.Controls.Add(tabr3c1)
        tabr3.Controls.Add(tabr3c2)
        tab.Controls.Add(tabr3)

        Dim tabr4 As New TableRow
        Dim tabr4c1, tabr4c2 As New TableCell
        tabr4c1.ColumnSpan = 7
        tabr4c2.ColumnSpan = 7
        tabr4c1.HorizontalAlign = HorizontalAlign.Left
        tabr4c2.HorizontalAlign = HorizontalAlign.Left

        tabr4c1.Text = "<font size=2>" & "JR.ASST" & "</font>"
        If dt.Rows(0)(2) > 0 Then
            tabr4c2.Text = "<font size=2> -- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp" & dt.Rows(0)(2) & "</font>"
        End If
        tabr4.Controls.Add(tabr4c1)
        tabr4.Controls.Add(tabr4c2)
        tab.Controls.Add(tabr4)

        Dim tabr5 As New TableRow
        Dim tabr5c1, tabr5c2 As New TableCell
        tabr5c1.ColumnSpan = 7
        tabr5c2.ColumnSpan = 7
        tabr5c1.HorizontalAlign = HorizontalAlign.Left
        tabr5c2.HorizontalAlign = HorizontalAlign.Left

        tabr5c1.Text = "<font size=2>" & "SWEEPER" & "</font>"
        If dt.Rows(0)(3) > 0 Then
            tabr5c2.Text = "<font size=2> -- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp" & dt.Rows(0)(3) & "</font>"
        End If
        tabr5.Controls.Add(tabr5c1)
        tabr5.Controls.Add(tabr5c2)
        tab.Controls.Add(tabr5)

        Dim tabr6 As New TableRow
        Dim tabr6c1, tabr6c2 As New TableCell
        tabr6c1.ColumnSpan = 7
        tabr6c2.ColumnSpan = 7
        tabr6c1.HorizontalAlign = HorizontalAlign.Left
        tabr6c2.HorizontalAlign = HorizontalAlign.Left

        tabr6c1.Text = "<font size=2>" & "J.O" & "</font>"
        If dt.Rows(0)(4) > 0 Then
            tabr6c2.Text = "<font size=2> -- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & dt.Rows(0)(4) & "</font>"
        End If
        tabr6.Controls.Add(tabr6c1)
        tabr6.Controls.Add(tabr6c2)
        tab.Controls.Add(tabr6)

        Me.Panel1.Controls.Add(tab)
    End Sub
End Class
