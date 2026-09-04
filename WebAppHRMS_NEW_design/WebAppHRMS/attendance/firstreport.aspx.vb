Imports System.Data
Partial Class DetailReport_firstreport_31da607f7926
    Inherits System.Web.UI.Page
    Dim dt, dt2 As New DataTable
    Dim dr As DataRow
    Dim str, str2 As String
    Dim oh As New Helper.Oracle.OracleHelper
    Private Function checknull(ByVal a) As String
        If IsDBNull(a) Then
            Return ("0.00")
        Else
            Return (FormatNumber(a, 2))
        End If
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '        Dim empcode As Integer = Request.QueryString("emp_code")
      
        If Session("branch_id") = 0 Then
            '                0                        1                           ---------------2------------------------------    -----------------------3---------------------------------     --------------------4-------------------------------------------------------------------------------------------------------------              ------------------------5--------------      -----------------------------6--------------------------------------------------------------------------------------        
            str = "select t.emp_id as emp_id,substr(e.emp_name,0,28) as emp_name,(nvl(t.fix_ta,0)+nvl(t.act_ta,0)+nvl(t.abh_ta,0)+nvl(t.bh_ta,0)+nvl(hp_ta,0)) as ta,(nvl(t.outstation,0)+nvl(t.bh_all,0)+nvl(t.tele_all,0)+nvl(t.dist_all,0)+nvl(t.summer_inc,0)) as allowance,(nvl(t.incentive,0)+nvl(hp_incent,0)+nvl(INS_INCENT,0)+nvl(FOREX_INC,0)+nvl(GLR_INCENT,0)+nvl(BOND_INC,0)+nvl(MANAG_INC,0)+nvl(MONTH_INC,0)+nvl(LEGAL_INC,0)+nvl(CIVIL_INC,0)+nvl(CHITS_INC,0)+nvl(OTHER_INC,0)) as incentive,(nvl(DEP_MOB,0)+nvl(BUS_LOAN,0)+nvl(PERS_LOAN,0)+nvl(GOLD_GA,0)+nvl(DEP_MKT,0))as others,(nvl(t.fix_ta,0)+nvl(t.act_ta,0)+nvl(t.abh_ta,0)+nvl(t.bh_ta,0)+nvl(hp_ta,0))+(nvl(t.outstation,0)+nvl(t.bh_all,0)+nvl(t.tele_all,0)+nvl(t.dist_all,0)+nvl(t.summer_inc,0))+(nvl(t.incentive,0)+nvl(hp_incent,0)+nvl(INS_INCENT,0)+nvl(FOREX_INC,0)+nvl(GLR_INCENT,0)+nvl(BOND_INC,0)+nvl(MANAG_INC,0)+nvl(MONTH_INC,0)+nvl(LEGAL_INC,0)+nvl(CIVIL_INC,0)+nvl(CHITS_INC,0)+nvl(OTHER_INC,0))+(nvl(DEP_MOB,0)+nvl(BUS_LOAN,0)+nvl(PERS_LOAN,0)+nvl(GOLD_GA,0)+nvl(DEP_MKT,0))as net_all from ta_br t,employee_master e where t.emp_id=e.emp_code  order by e.emp_code"
        Else
            str = "select t.emp_id as emp_id,substr(e.emp_name,0,28) as emp_name,(nvl(t.fix_ta,0)+nvl(t.act_ta,0)+nvl(t.abh_ta,0)+nvl(t.bh_ta,0)+nvl(hp_ta,0)) as ta,(nvl(t.outstation,0)+nvl(t.bh_all,0)+nvl(t.tele_all,0)+nvl(t.dist_all,0)+nvl(t.summer_inc,0)) as allowance,(nvl(t.incentive,0)+nvl(hp_incent,0)+nvl(INS_INCENT,0)+nvl(FOREX_INC,0)+nvl(GLR_INCENT,0)+nvl(BOND_INC,0)+nvl(MANAG_INC,0)+nvl(MONTH_INC,0)+nvl(LEGAL_INC,0)+nvl(CIVIL_INC,0)+nvl(CHITS_INC,0)+nvl(OTHER_INC,0)) as incentive,(nvl(DEP_MOB,0)+nvl(BUS_LOAN,0)+nvl(PERS_LOAN,0)+nvl(GOLD_GA,0)+nvl(DEP_MKT,0))as others,(nvl(t.fix_ta,0)+nvl(t.act_ta,0)+nvl(t.abh_ta,0)+nvl(t.bh_ta,0)+nvl(hp_ta,0))+(nvl(t.outstation,0)+nvl(t.bh_all,0)+nvl(t.tele_all,0)+nvl(t.dist_all,0)+nvl(t.summer_inc,0))+(nvl(t.incentive,0)+nvl(hp_incent,0)+nvl(INS_INCENT,0)+nvl(FOREX_INC,0)+nvl(GLR_INCENT,0)+nvl(BOND_INC,0)+nvl(MANAG_INC,0)+nvl(MONTH_INC,0)+nvl(LEGAL_INC,0)+nvl(CIVIL_INC,0)+nvl(CHITS_INC,0)+nvl(OTHER_INC,0))+(nvl(DEP_MOB,0)+nvl(BUS_LOAN,0)+nvl(PERS_LOAN,0)+nvl(GOLD_GA,0)+nvl(DEP_MKT,0))as net_all from ta_br t,employee_master e where t.emp_id=e.emp_code and t.branch_id=" & Session("branch_id") & "order by e.emp_code"
        End If
        dt = oh.ExecuteDataSet(str).Tables(0)

        str2 = "select nvl(cg.cash,0) as cash,nvl(cg.gold,0) as gold from cash_gold cg where cg.branch_id=" & Session("branch_id") & ""
        dt2 = oh.ExecuteDataSet(str2).Tables(0)

        Dim tatble As New Table
        Dim header As New TableRow
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        header.Width = 8
        Dim headercell As New TableCell
        headercell.ColumnSpan = 8
        headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headercell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headercell)
        tatble.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.BackColor = Drawing.Color.LightGray
        Dim sheadercell1 As New TableCell
        Dim sheadercell2 As New TableCell
        'sheaderdate.ColumnSpan = 2
        'sheaderdate.Text = "<b><font size=2>Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        'sheader.Controls.Add(sheaderdate)
        sheadercell1.ColumnSpan = 8
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        tatble.Controls.Add(sheader)

        Dim s As String = oh.ExecuteDataSet("select month_name from month where month_id=" & Now.Month - 1).Tables(0).Rows(0)(0)

        Dim tt As New TableRow
        tt.BackColor = Drawing.Color.LightSkyBlue
        tt.Width = 8
        Dim tt1 As New TableCell
        tt1.ColumnSpan = 8
        tt1.HorizontalAlign = HorizontalAlign.Center
        tt1.Text = "<b><font size=2>Travelling Allowance Report of " & s & " " & Now.Year & " </font></b>"
        tt.Controls.Add(tt1)
        tatble.Controls.Add(tt)

        Dim subh As New TableRow
        ' subh.BackColor = Drawing.Color.LightCoral
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 8

        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 2
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 3
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subh.Controls.Add(subcell2)
        subcell3.ColumnSpan = 3
        subcell3.HorizontalAlign = HorizontalAlign.Left
        subcell3.Text = "<b><font size=2.5>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"



        'subcell3.Text = "<b><font size=2> Time:" & Format(Date.Now, "hh:mm:ss") & "</font></b>"
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)
        tatble.Controls.Add(subh)

        Dim line As New TableRow
        Dim linecell As New TableCell
        linecell.ColumnSpan = 8
        linecell.Text = "<hr>"
        line.Controls.Add(linecell)
        tatble.Controls.Add(line)

        'Dim colors As String
        'colors = "#fff7ff"
        'Dim i As Integer = 0
        'For Each dr In dt.Rows
        '    i = i + 1
        '    If colors.Equals("#fff7ff") = True Then
        '        colors = "#eef9ff"
        '    Else
        '        colors = "#fff7ff"
        '    End If



        Dim colors As String
        colors = "#fff7ff"

        Dim row2 As New TableRow
        row2.Attributes.Add("bgcolor", colors)
        Dim h1 As New TableCell
        Dim hq As New TableCell
        Dim h2 As New TableCell
        Dim h3 As New TableCell
        Dim h4 As New TableCell
        Dim h5 As New TableCell
        Dim h6 As New TableCell

        h1.ColumnSpan = 1
        h1.Text = "<b><font size=2>&nbsp;Em.Code&nbsp;</font></b>"
        h1.HorizontalAlign = HorizontalAlign.Left
        row2.Controls.Add(h1)

        hq.ColumnSpan = 1
        hq.Text = "<b><font size=2>&nbsp;Name&nbsp;</font></b>"
        hq.HorizontalAlign = HorizontalAlign.Left
        row2.Controls.Add(hq)

        h2.ColumnSpan = 2
        h2.Text = "<b><font size=2>&nbsp;Travelling&nbsp;Allowance&nbsp</font></b>"
        h2.HorizontalAlign = HorizontalAlign.Right
        row2.Controls.Add(h2)
        h3.ColumnSpan = 1
        h3.Text = "<b><font size=2>&nbsp;Allowance&nbsp;</font></b>"
        h3.HorizontalAlign = HorizontalAlign.Right
        row2.Controls.Add(h3)
        h4.ColumnSpan = 1
        h4.Text = "<b><font size=2>&nbsp;Incentive&nbsp;</font></b>"
        h4.HorizontalAlign = HorizontalAlign.Right
        row2.Controls.Add(h4)
        h5.ColumnSpan = 1
        h5.Text = "<b><font size=2>&nbsp;Others&nbsp;</font></b>"
        h5.HorizontalAlign = HorizontalAlign.Right
        row2.Controls.Add(h5)
        h6.ColumnSpan = 1
        h6.Text = "<b><font size=2>&nbsp;Total&nbsp;</font></b>"
        h6.HorizontalAlign = HorizontalAlign.Right
        row2.Controls.Add(h6)

        tatble.Controls.Add(row2)
        Dim line3 As New TableRow
        Dim linecell3 As New TableCell
        linecell3.ColumnSpan = 8
        linecell3.Text = "<hr>"
        line3.Controls.Add(linecell3)
        tatble.Controls.Add(line3)


        For Each dr In dt.Rows

            If colors.Equals("#fff7ff") = True Then
                colors = "#eef9ff"
            Else
                colors = "#fff7ff"
            End If

            Dim drow As New TableRow
            drow.Attributes.Add("bgcolor", colors)
            Dim d1, dq, d2, d3, d4, d5, d6 As New TableCell
            d1.HorizontalAlign = HorizontalAlign.Left
            d1.ColumnSpan = 1
            d1.Text = "<a href=subreport.aspx?emp_code=" & dr(0) & "><font size=2>" & dr(0) & "</font></a>"
            d1.HorizontalAlign = HorizontalAlign.Left
            drow.Controls.Add(d1)

            dq.HorizontalAlign = HorizontalAlign.Left
            dq.ColumnSpan = 1
            dq.Text = "<font size=2>" & dr(1) & "</font>"
            dq.HorizontalAlign = HorizontalAlign.Left
            drow.Controls.Add(dq)

            d2.ColumnSpan = 2
            d2.Text = "<a><font size=2>" & checknull(dr(2)) & "</font></a>"
            d2.HorizontalAlign = HorizontalAlign.Right
            drow.Controls.Add(d2)
            d3.ColumnSpan = 1
            d3.Text = "<a><font size=2>" & checknull(dr(3)) & "</font></a>"
            d3.HorizontalAlign = HorizontalAlign.Right
            drow.Controls.Add(d3)
            d4.ColumnSpan = 1
            d4.Text = "<a><font size=2>" & checknull(dr(4)) & "</font></a>"
            d4.HorizontalAlign = HorizontalAlign.Right
            drow.Controls.Add(d4)
            d5.ColumnSpan = 1
            d5.Text = "<a><font size=2>" & checknull(dr(5)) & "</font></a>"
            d5.HorizontalAlign = HorizontalAlign.Right
            drow.Controls.Add(d5)
            d6.Text = "<a><font size=2>" & checknull(dr(6)) & "</font></a>"
            d6.HorizontalAlign = HorizontalAlign.Right
            drow.Controls.Add(d6)

            tatble.Controls.Add(drow)
        Next

        Dim line4 As New TableRow
        Dim linecell4 As New TableCell
        linecell4.ColumnSpan = 8
        linecell4.Text = "<hr>"
        line4.Controls.Add(linecell4)
        tatble.Controls.Add(line4)

        If dt2.Rows.Count > 0 Then

            Dim cago As New TableRow
            cago.Width = 8
            Dim cg1, cg2 As New TableCell

            cg1.ColumnSpan = 3
            cg1.HorizontalAlign = HorizontalAlign.Center
            If IsDBNull(dt2.Rows(0)(0)) Then
                cg1.Text = "<b><font size=2>Cash:&nbsp;&nbsp;0</font></b>"
            Else
                cg1.Text = "<b><font size=2>Cash:&nbsp;&nbsp;" & dt2.Rows(0)(0) & "</font></b>"
            End If
            cago.Controls.Add(cg1)

            cg2.ColumnSpan = 5
            cg2.HorizontalAlign = HorizontalAlign.Center
            If IsDBNull(dt2.Rows(0)(1)) Then
                cg2.Text = "<b><font size=2>Gold:&nbsp;&nbsp;0</font></b>"
            Else
                cg2.Text = "<b><font size=2>Gold:&nbsp;&nbsp;" & dt2.Rows(0)(1) & "</font></b>"
            End If
            cago.Controls.Add(cg2)

            tatble.Controls.Add(cago)

        Else

            Dim cago As New TableRow
            cago.Width = 8
            Dim cg1, cg2 As New TableCell

            cg1.ColumnSpan = 3
            cg1.HorizontalAlign = HorizontalAlign.Center
            cg1.Text = "<b><font size=2>Cash:&nbsp;&nbsp;0</font></b>"
            cago.Controls.Add(cg1)

            cg2.ColumnSpan = 5
            cg2.HorizontalAlign = HorizontalAlign.Center
            cg2.Text = "<b><font size=2>Gold:&nbsp;&nbsp;0</font></b>"
            cago.Controls.Add(cg2)

            tatble.Controls.Add(cago)

        End If

        Dim last As New TableRow
        Dim last1 As New TableCell
        last1.ColumnSpan = 8
        last1.Text = "<hr>"
        last.Controls.Add(last1)
        tatble.Controls.Add(last)

        Panel1.Controls.Add(tatble)
    End Sub
End Class
