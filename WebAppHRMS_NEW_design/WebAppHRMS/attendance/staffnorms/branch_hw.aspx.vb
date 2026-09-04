Imports System.Data.OracleClient
Imports System.Data
Partial Class staff_norms_hw_lg_ins_branch_hw_62390f5a4432
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tab As New Table
        tab.Attributes.Add("width", "100%")
        tab.Attributes.Add("align", "left")


        Dim tr1 As New TableRow
        Dim td11 As New TableCell
        td11.Attributes.Add("width", "100%")
        td11.ColumnSpan = 15
        td11.HorizontalAlign = HorizontalAlign.Center
        td11.Text = "<font size=4><b>" & Me.Session("firm_name") & "</b></font>"
        tr1.Controls.Add(td11)
        tab.Controls.Add(tr1)

        Dim tr2 As New TableRow
        Dim td21 As New TableCell
        td21.Attributes.Add("width", "100%")
        td21.ColumnSpan = 15
        td21.HorizontalAlign = HorizontalAlign.Center
        td21.Text = "<font size=2><b> " & Me.Session("branch_name") & " </b></font>"
        tr2.Controls.Add(td21)
        tab.Controls.Add(tr2)

        Dim trr As New TableRow
        Dim tdr1 As New TableCell
        tdr1.Attributes.Add("width", "100%")
        tdr1.ColumnSpan = 15
        tdr1.HorizontalAlign = HorizontalAlign.Center
        tdr1.Text = "<font size=2><b> BRANCH WISE LIST </b></font>"
        trr.Controls.Add(tdr1)
        tab.Controls.Add(trr)

        Dim tr3 As New TableRow
        Dim td31 As New TableCell
        td31.Attributes.Add("width", "50%")
        td31.ColumnSpan = 7.5
        td31.HorizontalAlign = HorizontalAlign.Left
        td31.Text = "<font size=2><b>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</b></font>"
        tr3.Controls.Add(td31)
        Dim td32 As New TableCell
        td32.Attributes.Add("width", "50%")
        td32.ColumnSpan = 7.5
        td32.HorizontalAlign = HorizontalAlign.Right
        td32.Text = "<font size=2><b>Time :" & Format(Date.Now, "hh:mm:ss tt") & "</b></font>"
        tr3.Controls.Add(td32)
        tab.Controls.Add(tr3)

        Dim lin2101 As New TableRow
        Dim lin21011 As New TableCell
        lin21011.ColumnSpan = 15
        lin21011.Text = "<hr align=center width=100% >"
        lin2101.Controls.Add(lin21011)
        tab.Controls.Add(lin2101)

        Dim ta5 As New TableRow
        ta5.Width = 15
        Dim ta51, ta52, ta54, ta57, ta58 As New TableCell
        ta51.ColumnSpan = 3
        ta52.ColumnSpan = 4
        ta54.ColumnSpan = 3
        ta57.ColumnSpan = 2
        ta58.ColumnSpan = 3

        ta51.Text = "<font size=2><b>SI.NO&nbsp;</b></font>"
        ta52.Text = "<font size=2><b>BRANCH</b></font>"
        ta54.Text = "<font size=2><b>H/W&nbsp;ACTUAL&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></font>"
        ta57.Text = "<font size=2><b>L.INS&nbsp;ACTUAL&nbsp;&nbsp;&nbsp;</b></font>"
        ta58.Text = "<font size=2><b>G.INS&nbsp;ACTUAL&nbsp;</b></font>"

        ta51.HorizontalAlign = HorizontalAlign.Center
        ta52.HorizontalAlign = HorizontalAlign.Left
        ta54.HorizontalAlign = HorizontalAlign.Center
        ta57.HorizontalAlign = HorizontalAlign.Center
        ta58.HorizontalAlign = HorizontalAlign.Center

        ta5.Controls.Add(ta51)
        ta5.Controls.Add(ta52)
        ta5.Controls.Add(ta54)
        ta5.Controls.Add(ta57)
        ta5.Controls.Add(ta58)
        tab.Controls.Add(ta5)

        Dim lin21012 As New TableRow
        Dim lin210112 As New TableCell
        lin210112.ColumnSpan = 15
        lin210112.Text = "<hr align=center width=100% >"
        lin21012.Controls.Add(lin210112)
        tab.Controls.Add(lin21012)

        Dim dt As New DataTable
        Dim sql As String = Nothing
        Dim dr As DataRow
        Dim cn1 As Integer = 0
        Dim cn2 As Integer = 0
        Dim cn3 As Integer = 0
        Dim sino As Integer = 0
        sql = "select sr.branch_id,bm.branch_name,sr.hardware as hw_Act,sr.life_ins as lins_act,sr.general_ins as gins_act from area_detail ad,branch_master bm,staff_required sr where ad.branch_id=bm.branch_id and bm.branch_id=sr.branch_id and ad.branch_id=sr.branch_id and sr.branch_id<>0 and ad.area_id=" & Request.QueryString("areaid") & " order by bm.branch_name"
        Dim oh As New Helper.Oracle.OracleHelper
        dt = oh.ExecuteDataSet(sql).Tables(0)

        For Each dr In dt.Rows

            Dim lm5 As New TableRow
            lm5.Width = 15
            Dim lm50, lm51, lm52, lm53, lm54 As New TableCell

            sino += 1

            lm54.ColumnSpan = 3
            lm54.HorizontalAlign = HorizontalAlign.Center
            lm54.Text = "<font size=2> " & sino & "</font>"
            lm5.Controls.Add(lm54)

            lm50.ColumnSpan = 4
            lm50.HorizontalAlign = HorizontalAlign.Left
            lm50.Text = "<font size=2> " & dr(1) & "</font>"
            lm5.Controls.Add(lm50)

            lm51.ColumnSpan = 3
            lm51.HorizontalAlign = HorizontalAlign.Center
            lm51.Text = "<font size=2>" & dr(2) & "</a></font>"
            lm5.Controls.Add(lm51)
            cn1 += dr(2)


            lm52.ColumnSpan = 2
            lm52.HorizontalAlign = HorizontalAlign.Center
            lm52.Text = "<font size=2> " & dr(3) & "</font>"
            lm5.Controls.Add(lm52)
            cn2 += dr(3)

            lm53.ColumnSpan = 3
            lm53.HorizontalAlign = HorizontalAlign.Center
            lm53.Text = "<font size=2> " & dr(4) & "</font>"
            lm5.Controls.Add(lm53)
            cn3 += dr(4)
            tab.Controls.Add(lm5)
        Next

        Dim lin22 As New TableRow
        Dim lin221 As New TableCell
        lin221.ColumnSpan = 15
        lin221.Text = "<hr align=center width=100% >"
        lin22.Controls.Add(lin221)
        tab.Controls.Add(lin22)


        Dim t5 As New TableRow
        t5.Width = 15
        Dim tt1, tt2, tt3, tt4, tt5 As New TableCell

        tt5.ColumnSpan = 3
        tt5.HorizontalAlign = HorizontalAlign.Center
        tt5.Text = "<font size=2>" & sino & "</font>"
        t5.Controls.Add(tt5)

        tt1.ColumnSpan = 4
        tt1.HorizontalAlign = HorizontalAlign.Left
        tt1.Text = "<font size=2>Total</font>"
        t5.Controls.Add(tt1)


        tt2.ColumnSpan = 3
        tt2.HorizontalAlign = HorizontalAlign.Center
        tt2.Text = "<font size=2> " & cn1 & "</font>"
        t5.Controls.Add(tt2)

        tt3.ColumnSpan = 2
        tt3.HorizontalAlign = HorizontalAlign.Center
        tt3.Text = "<font size=2> " & cn2 & "</font>"
        t5.Controls.Add(tt3)

        tt4.ColumnSpan = 3
        tt4.HorizontalAlign = HorizontalAlign.Center
        tt4.Text = "<font size=2> " & cn3 & "</font>"
        t5.Controls.Add(tt4)

        tab.Controls.Add(t5)
        Me.Panel1.Controls.Add(tab)
    End Sub
End Class
