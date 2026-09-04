Imports System.Data
Imports System.Data.OracleClient
Partial Class special_allowance_rpt_summer_all_consolidated_a176f4db3574
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rdb As Integer = Request.QueryString("rdb")
        Dim str As String = ""
        If rdb = 0 Then
            str = "select h.emp_code,e.emp_name,h.amount from hrm_spa_amount h,emp_master e ,hrm_spa_pro_dtl_sub s,employ_firm f where h.emp_code=e.emp_code and h.post_id in(136,134,141) and h.emp_code=s.emp_code and s.post_id in(136,134,141)  and h.amount>0 and e.emp_code=f.emp_code   and f.firm_id=" & Session("firm_id") & " group by h.emp_code,e.EMP_name,h.amount order by h.emp_code"
        ElseIf rdb = 1 Then
            str = "select h.emp_code,e.emp_name,h.amount from hrm_spa_amount h,emp_master e ,hrm_spa_pro_dtl_sub s,employ_firm f where h.emp_code=e.emp_code and h.post_id=10 and h.emp_code=s.emp_code and s.post_id=10  and h.amount>0 and e.emp_code=f.emp_code   and f.firm_id=" & Session("firm_id") & " group by h.emp_code,e.EMP_name,h.amount order by h.emp_code"
        ElseIf rdb = 2 Then
            str = "select h.emp_code,e.emp_name,h.amount from hrm_spa_amount h,emp_master e ,hrm_spa_pro_dtl_sub s,employ_firm f where h.emp_code=e.emp_code and h.post_id=1 and h.emp_code=s.emp_code and s.post_id=1  and h.amount>0 and e.emp_code=f.emp_code   and f.firm_id=" & Session("firm_id") & " group by h.emp_code,e.EMP_name,h.amount order by h.emp_code"
        Else
            str = "select h.emp_code,e.emp_name,h.amount from hrm_spa_amount h,emp_master e ,hrm_spa_pro_dtl_sub s,employ_firm f where h.emp_code=e.emp_code and s.branch_id=0 and h.post_id not in(1,10,136,134,141) and h.emp_code=s.emp_code  and s.post_id not in(1,10,136,134,141) and h.amount>0 and e.emp_code=f.emp_code   and f.firm_id=" & Session("firm_id") & " group by h.emp_code,e.EMP_name,h.amount order by h.emp_code"
        End If
        Dim dt As DataTable = oh.ExecuteDataSet(str).Tables(0)
        Dim tab1 As New Table
        tab1.Attributes.Add("width", "100%")
        '1st row declaration
        Dim tabr1 As New TableRow
        tabr1.Width = 5
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.Attributes.Add("bordercolor", "red")
        'cell declaration
        Dim tabc1 As New TableCell
        tabc1.Attributes.Add("forecolor", "blue")
        tabc1.Attributes.Add("align", "center")
        tabc1.ColumnSpan = 5
        tabc1.Text = "<body align=center ><b><font size=4> " & Session("firm_name") & " </font></b></body>"

        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab1.Controls.Add(tabr1)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Width = 5
        'cell declaration
        Dim tabc2 As New TableCell
        tabc2.ColumnSpan = 5
        Dim d1 As DataTable = oh.ExecuteDataSet("select to_char(min(s.tfr_from_dt),'DD/MON/yyyy')  || ' - ' ||to_char(max(s.tfr_to_dt),'DD/MON/yyyy') from hrm_spa_pro_dtl s ").Tables(0)

        tabc2.Attributes.Add("align", "center")
        If rdb = 0 Then
            tabc2.Text = "<body align=center color=red><b><font size=3.5> AM ALLOWANCE REPORT " & d1.Rows(0)(0) & " </font></b></body>"
        ElseIf rdb = 1 Then
            tabc2.Text = "<body align=center color=red><b><font size=3.5> BH ALLOWANCE REPORT " & d1.Rows(0)(0) & " </font></b></body>"
        ElseIf rdb = 2 Then
            tabc2.Text = "<body align=center color=red><b><font size=3.5> ABH ALLOWANCE REPORT " & d1.Rows(0)(0) & " </font></b></body>"
        Else
            tabc2.Text = "<body align=center color=red><b><font size=3.5> SPECIAL ALLOWANCE A.O REPORT " & d1.Rows(0)(0) & " </font></b></body>"
        End If

        tabc2.ForeColor = Drawing.Color.Maroon
        tabr2.Controls.Add(tabc2)
        tab1.Controls.Add(tabr2)
        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Attributes.Add("bgcolor", "#ffcca3")

        'cell declaration
        Dim tabcc3 As New TableCell
        tabcc3.ColumnSpan = 3
        tabcc3.Attributes.Add("align", "left")
        tabcc3.Text = "<b><font size=3.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
        tabcc3.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc3)
        tab1.Controls.Add(tabrr3)
        'cell declaration
        Dim tabcc4 As New TableCell
        tabcc4.ColumnSpan = 2
        tabcc4.HorizontalAlign = HorizontalAlign.Right
        tabcc4.Text = "<b><font size=3.5>TIME: " & Format(Now, "HH:mm:ss tt") & "</font></b>"
        tabcc4.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc4)
        tab1.Controls.Add(tabrr3)

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabline As New TableRow
        tabline.Width = 5
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 5
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab1.Controls.Add(tabline)
        ''''''''''''''''''''''''''''''''''''''''
        Dim tabr5 As New TableRow
        tabr5.Width = 5
        tabr5.ForeColor = Drawing.Color.DarkRed
        Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4 As New TableCell

        tabr5c1.ColumnSpan = "1"
        tabr5c2.ColumnSpan = "1"
        tabr5c3.ColumnSpan = "2"
        tabr5c4.ColumnSpan = "1"
       
        tabr5c1.HorizontalAlign = HorizontalAlign.Left
        tabr5c2.HorizontalAlign = HorizontalAlign.Left
        tabr5c3.HorizontalAlign = HorizontalAlign.Left
        tabr5c4.HorizontalAlign = HorizontalAlign.Right
       

        tabr5c1.Text = "<b><font size=2.5>Si.No&nbsp;&nbsp;</font></b>"
        tabr5c2.Text = "<b><font size=2.5>EMP CODE</font></b>"
        tabr5c3.Text = "<b><font size=2.5>EMP NAME</font></b>"
        tabr5c4.Text = "<b><font size=2.5>ALLOWANCE</font></b>"
       
        tabr5.Controls.Add(tabr5c1)
        tabr5.Controls.Add(tabr5c2)
        tabr5.Controls.Add(tabr5c3)
        tabr5.Controls.Add(tabr5c4)

        tab1.Controls.Add(tabr5)

        '''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 5
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 5
        tabcellline1.Text = "<hr>"
        tabline1.Controls.Add(tabcellline1)
        tab1.Controls.Add(tabline1)
        '''''''''''''''''''''''''''''''''

        Dim tot As Double = 0.0
        If dt.Rows.Count > 0 Then
            Dim colors As String
            colors = "#fff7ff"
            Dim dr As DataRow
            Dim i As Integer = 0
            For Each dr In dt.Rows
                i = i + 1
                If colors.Equals("#fff7ff") = True Then
                    colors = "#eef9ff"
                Else
                    colors = "#fff7ff"
                End If
                Dim tabr6 As New TableRow
                tabr6.Width = 5
                tabr6.Attributes.Add("bgcolor", colors)
                Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4 As New TableCell

                tabr6c1.ColumnSpan = "1"
                tabr6c2.ColumnSpan = "1"
                tabr6c3.ColumnSpan = "2"
                tabr6c4.ColumnSpan = "1"

                tabr6c1.Attributes.Add("align", "left")
                tabr6c2.Attributes.Add("align", "left")
                tabr6c3.Attributes.Add("align", "left")
                tabr6c4.Attributes.Add("align", "right")

                tabr6c1.Text = "<font size=2>" & i & "&nbsp;&nbsp;</a></font>"
                tabr6c2.Text = "<font size=2>" & dr(0) & "&nbsp;&nbsp;</a></font>"
                tabr6c3.Text = "<font size=2>" & dr(1) & "</a></font>"
                tabr6c4.Text = "<font size=2>" & FormatNumber(dr(2), 2) & "</a></font>"
                tot = tot + dr(2)

                tabr6.Controls.Add(tabr6c1)
                tabr6.Controls.Add(tabr6c2)
                tabr6.Controls.Add(tabr6c3)
                tabr6.Controls.Add(tabr6c4)

                tab1.Controls.Add(tabr6)
            Next

            Dim tabline5 As New TableRow
            tabline5.Width = 5
            Dim tabcellline5 As New TableCell
            tabcellline5.ColumnSpan = 5
            tabcellline5.Text = "<hr>"
            tab1.Controls.Add(tabline5)

            Dim tabtot As New TableRow
            tabtot.BackColor = Drawing.Color.Cornsilk
            tabtot.ForeColor = Drawing.Color.Red

            tabtot.Width = 5
            Dim tabtot1, tabtot2 As New TableCell
            tabtot1.ColumnSpan = 4
            tabtot2.ColumnSpan = 1
            tabtot1.HorizontalAlign = HorizontalAlign.Right
            tabtot2.HorizontalAlign = HorizontalAlign.Right
            tabtot1.Text = "<font size=2>TOTAL</font>"
            tabtot2.Text = "<font size=2><b>" & FormatNumber(tot, 2) & "</b></font>"
            tabtot.Controls.Add(tabtot1)
            tabtot.Controls.Add(tabtot2)
            tab1.Controls.Add(tabtot)
        End If
        Me.Panel1.Controls.Add(tab1)


    End Sub
End Class
