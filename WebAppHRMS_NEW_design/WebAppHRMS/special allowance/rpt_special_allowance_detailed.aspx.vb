Imports System.Data
Imports System.Data.OracleClient
Partial Class special_allowance_rpt_special_allowance_detailed_25519ffd7585
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim pq As String = Request.QueryString("ar_id")
        Dim ab = pq.Split("`")
        Dim str As String = ""
        If ab(0) = "a" Then
            str = "select b.BRANCH_NAME,p.post_name,s.emp_code,e.EMP_NAME,s.actual_amount from hrm_spa_pro_dtl_sub s,branch b,post_mst p,emp_master e,employ_firm f where s.area_id=" & ab(1) & " and s.post_id in(136,134,141) and s.branch_id=b.BRANCH_ID and s.post_id=p.post_id and s.emp_code=e.EMP_CODE and s.emp_code=f.emp_code   and f.firm_id=" & Session("firm_id") & " order by b.BRANCH_NAME,s.emp_code"
        ElseIf ab(0) = "b" Then
            str = "select b.BRANCH_NAME,p.post_name,s.emp_code,e.EMP_NAME,s.actual_amount from hrm_spa_pro_dtl_sub s,branch b,post_mst p,emp_master e,employ_firm f where s.branch_id=" & ab(1) & " and s.post_id in(10) and s.branch_id=b.BRANCH_ID and s.post_id=p.post_id and s.emp_code=e.EMP_CODE and s.emp_code=f.emp_code   and f.firm_id=" & Session("firm_id") & " order by b.BRANCH_NAME,s.emp_code"
        Else
            str = "select b.BRANCH_NAME,p.post_name,s.emp_code,e.EMP_NAME,s.actual_amount from hrm_spa_pro_dtl_sub s,branch b,post_mst p,emp_master e,employ_firm f where s.branch_id=" & ab(1) & " and s.post_id in(1) and s.branch_id=b.BRANCH_ID and s.post_id=p.post_id and s.emp_code=e.EMP_CODE and s.emp_code=f.emp_code   and f.firm_id=" & Session("firm_id") & " order by b.BRANCH_NAME,s.emp_code"
        End If

        Dim dt As New DataTable
        dt = oh.ExecuteDataSet(str).Tables(0)
        Dim tab As New Table

        tab.Attributes.Add("width", "100%")
        '1st row declaration
        Dim tabr1 As New TableRow
        tabr1.Width = 9
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.Attributes.Add("bordercolor", "red")
        'cell declaration
        Dim tabc1 As New TableCell
        tabc1.Attributes.Add("forecolor", "blue")
        tabc1.Attributes.Add("align", "center")
        tabc1.ColumnSpan = 9
        tabc1.Text = "<body align=center ><b><font size=4>" & Session("firm_name") & "</font></b></body>"

        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab.Controls.Add(tabr1)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Width = 9
        'cell declaration
        Dim tabc2 As New TableCell
        tabc2.ColumnSpan = 9
        tabc2.Attributes.Add("align", "center")
        tabc2.Text = "<body align=center color=red><b><font size=3.5>  SPECIAL ALLOWANCE DETAILED REPORT </font></b></body>"

        tabc2.ForeColor = Drawing.Color.Maroon
        tabr2.Controls.Add(tabc2)
        tab.Controls.Add(tabr2)
        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Attributes.Add("bgcolor", "#ffcca3")

        'cell declaration
        Dim tabcc3 As New TableCell
        tabcc3.ColumnSpan = 5
        tabcc3.Attributes.Add("align", "left")
        tabcc3.Text = "<b><font size=3.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
        tabcc3.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc3)
        tab.Controls.Add(tabrr3)
        'cell declaration
        Dim tabcc4 As New TableCell
        tabcc4.ColumnSpan = 4
        tabcc4.HorizontalAlign = HorizontalAlign.Right
        tabcc4.Text = "<b><font size=3.5>TIME: " & Format(Now, "HH:mm:ss tt") & "</font></b>"
        tabcc4.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc4)
        tab.Controls.Add(tabrr3)

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabline As New TableRow
        tabline.Width = 9
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 9
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab.Controls.Add(tabline)


        Dim tabh As New TableRow
        tabh.Width = 9
        tabh.ForeColor = Drawing.Color.DarkRed
        Dim tabh1, tabh2, tabh3, tabh4, tabh5, tabh6 As New TableCell
        tabh1.HorizontalAlign = HorizontalAlign.Left
        tabh2.HorizontalAlign = HorizontalAlign.Left
        tabh3.HorizontalAlign = HorizontalAlign.Left
        tabh4.HorizontalAlign = HorizontalAlign.Left
        tabh5.HorizontalAlign = HorizontalAlign.Left
        tabh6.HorizontalAlign = HorizontalAlign.Right

        tabh1.ColumnSpan = 1
        tabh2.ColumnSpan = 2
        tabh3.ColumnSpan = 2
        tabh4.ColumnSpan = 1
        tabh5.ColumnSpan = 2
        tabh6.ColumnSpan = 1
     

        tabh1.Text = "<font size=2><B>Si.No</B></font>"
        tabh2.Text = "<font size=2><B>BRANCH&nbsp;&nbsp;&nbsp;</B></font>"
        tabh3.Text = "<font size=2><B>POST&nbsp;&nbsp;&nbsp;</B></font>"
        tabh4.Text = "<font size=2><B>EMP_CODE&nbsp;&nbsp;&nbsp;</B></font>"
        tabh5.Text = "<font size=2><B>EMP_NAME&nbsp;&nbsp;&nbsp;</B></font>"
        tabh6.Text = "<font size=2><B>AMOUNT</B></font>"
      
        tabh.Controls.Add(tabh1)
        tabh.Controls.Add(tabh2)
        tabh.Controls.Add(tabh3)
        tabh.Controls.Add(tabh4)
        tabh.Controls.Add(tabh5)
        tabh.Controls.Add(tabh6)

        tab.Controls.Add(tabh)



        Dim tabrb1q As New TableRow
        tabrb1q.Width = 9
        Dim tabrb11 As New TableCell
        tabrb1q.Width = 9
        tabrb11.ColumnSpan = 9
        tabrb11.Text = "<hr>"
        tabrb1q.Controls.Add(tabrb11)
        tab.Controls.Add(tabrb1q)
        Dim tot As Double = 0.0
        Dim i As Integer = 0

        Dim dr As DataRow
        For Each dr In dt.Rows
            i = i + 1
            Dim tabr As New TableRow

            Dim tabrc1, tabrc2, tabrc3, tabrc4, tabrc5, tabrc6 As New TableCell
            tabr.Width = 9
            tabrc1.HorizontalAlign = HorizontalAlign.Left
            tabrc2.HorizontalAlign = HorizontalAlign.Left
            tabrc3.HorizontalAlign = HorizontalAlign.Left
            tabrc4.HorizontalAlign = HorizontalAlign.Left
            tabrc5.HorizontalAlign = HorizontalAlign.Left
            tabrc6.HorizontalAlign = HorizontalAlign.Right

            tabrc1.ColumnSpan = 1
            tabrc2.ColumnSpan = 2
            tabrc3.ColumnSpan = 2
            tabrc4.ColumnSpan = 1
            tabrc5.ColumnSpan = 2
            tabrc6.ColumnSpan = 1

            tabrc1.Text = "<font size=2>" & i & "</font>"
            tabrc2.Text = "<font size=2>" & dr(0) & "&nbsp;&nbsp;&nbsp;</font>"
            tabrc3.Text = "<font size=2>" & dr(1) & "&nbsp;&nbsp;&nbsp;</font>"
            tabrc4.Text = "<font size=2>" & dr(2) & "&nbsp;&nbsp;&nbsp;</font>"
            tabrc5.Text = "<font size=2>" & dr(3) & "</font>"
            tabrc6.Text = "<font size=2>" & FormatNumber(dr(4), 2) & "</font>"
            tot = tot + dr(4)
            tabr.Controls.Add(tabrc1)
            tabr.Controls.Add(tabrc2)
            tabr.Controls.Add(tabrc3)
            tabr.Controls.Add(tabrc4)
            tabr.Controls.Add(tabrc5)
            tabr.Controls.Add(tabrc6)

            tab.Controls.Add(tabr)

        Next

        Dim lin22 As New TableRow
        lin22.Width = 9
        Dim lin221 As New TableCell
        lin221.ColumnSpan = 9
        lin221.Text = "<hr align=center width=100% >"
        lin22.Controls.Add(lin221)
        tab.Controls.Add(lin22)

        Dim tabtot As New TableRow
        tabtot.Width = 9
        tabtot.BackColor = Drawing.Color.Cornsilk
        tabtot.ForeColor = Drawing.Color.Red

        Dim tabt1, tabt2 As New TableCell
        tabt1.ColumnSpan = 7
        tabt2.ColumnSpan = 2
       
        tabt1.HorizontalAlign = HorizontalAlign.Left
        tabt2.HorizontalAlign = HorizontalAlign.Right
        
        tabt1.Text = "Total"
        tabt2.Text = FormatNumber(tot, 2)

        tabtot.Controls.Add(tabt1)
        tabtot.Controls.Add(tabt2)

        tab.Controls.Add(tabtot)
        Me.Panel1.Controls.Add(tab)

    End Sub
End Class
