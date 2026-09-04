Imports System.Data
Imports System.Data.OracleClient

Partial Class special_allowance_rpt_special_emp_report_72a6bfdd2645
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rdb As Integer = Request.QueryString("rdb")
        Dim str As String = ""
        If rdb = 0 Then
            str = "select am.area_id,am.area_name,s.emp_code,h.emp_name,p.post_name,h.org_tfr_from,h.org_tfr_to,d.designation,s.ta_from_dt,s.ta_to_dt,s.allowance,s.working_days,s.susp_days,s.leave_days,s.actual_amount from hrm_spa_pro_dtl h,hrm_spa_pro_dtl_sub s,area_master am,branch b,post_mst p,designation_master d ,employ_firm f where h.si_no=s.srno and h.area_id=am.area_id and h.post_id=p.post_id and h.branch_id=b.BRANCH_ID and h.designation=d.designation_id and s.post_id in(134,136,141) and s.emp_code=f.emp_code   and f.firm_id=" & Session("firm_id") & "  order by s.area_id,s.branch_id,s.emp_code,s.ta_from_dt"
        ElseIf rdb = 1 Then
            str = "select b.BRANCH_ID,b.BRANCH_NAME,s.emp_code,h.emp_name,p.post_name,h.org_tfr_from,h.org_tfr_to,d.designation,s.ta_from_dt,s.ta_to_dt,s.allowance,s.working_days,s.susp_days,s.leave_days,s.actual_amount from hrm_spa_pro_dtl h,hrm_spa_pro_dtl_sub s,area_master am,branch b,post_mst p,designation_master d,employ_firm f  where h.si_no=s.srno and h.area_id=am.area_id and h.post_id=p.post_id and h.branch_id=b.BRANCH_ID and h.designation=d.designation_id and s.post_id=10 and s.emp_code=f.emp_code   and f.firm_id=" & Session("firm_id") & " order by s.branch_id,s.emp_code,s.ta_from_dt"
        ElseIf rdb = 2 Then
            str = "select b.BRANCH_ID,b.BRANCH_NAME,s.emp_code,h.emp_name,p.post_name,h.org_tfr_from,h.org_tfr_to,d.designation,s.ta_from_dt,s.ta_to_dt,s.allowance,s.working_days,s.susp_days,s.leave_days,s.actual_amount from hrm_spa_pro_dtl h,hrm_spa_pro_dtl_sub s,area_master am,branch b,post_mst p,designation_master d,employ_firm f  where h.si_no=s.srno and h.area_id=am.area_id and h.post_id=p.post_id and h.branch_id=b.BRANCH_ID and h.designation=d.designation_id and s.post_id=1 and s.emp_code=f.emp_code   and f.firm_id=" & Session("firm_id") & " order by s.branch_id,s.emp_code,s.ta_from_dt"
        Else
            str = "select b.BRANCH_ID,b.BRANCH_NAME,s.emp_code,h.emp_name,p.post_name,h.org_tfr_from,h.org_tfr_to,d.designation,s.ta_from_dt,s.ta_to_dt,s.allowance,s.working_days,s.susp_days,s.leave_days,s.actual_amount from hrm_spa_pro_dtl h,hrm_spa_pro_dtl_sub s,area_master am,branch b,post_mst p,designation_master d,employ_firm f  where h.si_no=s.srno and h.area_id=am.area_id and h.post_id=p.post_id and h.branch_id=b.BRANCH_ID and h.designation=d.designation_id and s.branch_id=0 and s.emp_code=f.emp_code   and f.firm_id=" & Session("firm_id") & " order by s.branch_id,s.emp_code,s.ta_from_dt "
        End If
        Dim dt As DataTable = oh.ExecuteDataSet(str).Tables(0)
        Dim tab1 As New Table
        tab1.Attributes.Add("width", "100%")
        '1st row declaration
        Dim tabr1 As New TableRow
        tabr1.Width = 20
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.Attributes.Add("bordercolor", "red")
        'cell declaration
        Dim tabc1 As New TableCell
        tabc1.Attributes.Add("forecolor", "blue")
        tabc1.Attributes.Add("align", "center")
        tabc1.ColumnSpan = 20
        tabc1.Text = "<body align=center ><b><font size=4>" & Session("firm_name") & "</font></b></body>"

        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab1.Controls.Add(tabr1)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Width = 20
        'cell declaration
        Dim tabc2 As New TableCell
        tabc2.ColumnSpan = 20
        Dim d1 As DataTable = oh.ExecuteDataSet("select to_char(min(s.tfr_from_dt),'DD/MON/yyyy')  || ' - ' ||to_char(max(s.tfr_to_dt),'DD/MON/yyyy') from hrm_spa_pro_dtl s ").Tables(0)

        tabc2.Attributes.Add("align", "center")
        If rdb = 0 Then
            tabc2.Text = "<body align=center color=red><b><font size=3.5> AM SPECIAL ALLOWANCE REPORT " & d1.Rows(0)(0) & " </font></b></body>"
        ElseIf rdb = 1 Then
            tabc2.Text = "<body align=center color=red><b><font size=3.5> BH SPECIAL ALLOWANCE REPORT " & d1.Rows(0)(0) & " </font></b></body>"
        Else
            tabc2.Text = "<body align=center color=red><b><font size=3.5> ABH SPECIAL ALLOWANCE REPORT " & d1.Rows(0)(0) & " </font></b></body>"
        End If

        tabc2.ForeColor = Drawing.Color.Maroon
        tabr2.Controls.Add(tabc2)
        tab1.Controls.Add(tabr2)
        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Attributes.Add("bgcolor", "#ffcca3")

        'cell declaration
        Dim tabcc3 As New TableCell
        tabcc3.ColumnSpan = 10
        tabcc3.Attributes.Add("align", "left")
        tabcc3.Text = "<b><font size=3.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
        tabcc3.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc3)
        tab1.Controls.Add(tabrr3)
        'cell declaration
        Dim tabcc4 As New TableCell
        tabcc4.ColumnSpan = 10
        tabcc4.HorizontalAlign = HorizontalAlign.Right
        tabcc4.Text = "<b><font size=3.5>TIME: " & Format(Now, "HH:mm:ss tt") & "</font></b>"
        tabcc4.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc4)
        tab1.Controls.Add(tabrr3)

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabline As New TableRow
        tabline.Width = 20
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 20
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab1.Controls.Add(tabline)
        ''''''''''''''''''''''''''''''''''''''''
        Dim tabr5 As New TableRow
        tabr5.Width = 20
        tabr5.ForeColor = Drawing.Color.DarkRed
        Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7, tabr5c8, tabr5c9, tabr5c10, tabr5c11, tabr5c12, tabr5c13, tabr5c14, tabr5c15, tabr5c16 As New TableCell

        tabr5c1.ColumnSpan = "1"
        tabr5c2.ColumnSpan = "1"
        tabr5c3.ColumnSpan = "3"
        tabr5c4.ColumnSpan = "1"
        tabr5c5.ColumnSpan = "2"
        tabr5c6.ColumnSpan = "1"
        tabr5c7.ColumnSpan = "1"
        tabr5c8.ColumnSpan = "1"
        tabr5c9.ColumnSpan = "2"
        tabr5c10.ColumnSpan = "1"
        tabr5c11.ColumnSpan = "1"
        tabr5c12.ColumnSpan = "1"
        tabr5c13.ColumnSpan = "1"
        tabr5c14.ColumnSpan = "1"
        tabr5c15.ColumnSpan = "1"
        tabr5c16.ColumnSpan = "1"

        tabr5c1.HorizontalAlign = HorizontalAlign.Left
        tabr5c2.HorizontalAlign = HorizontalAlign.Left
        tabr5c3.HorizontalAlign = HorizontalAlign.Left
        tabr5c4.HorizontalAlign = HorizontalAlign.Left
        tabr5c5.HorizontalAlign = HorizontalAlign.Left
        tabr5c6.HorizontalAlign = HorizontalAlign.Left
        tabr5c7.HorizontalAlign = HorizontalAlign.Left
        tabr5c8.HorizontalAlign = HorizontalAlign.Left
        tabr5c9.HorizontalAlign = HorizontalAlign.Left
        tabr5c10.HorizontalAlign = HorizontalAlign.Left
        tabr5c11.HorizontalAlign = HorizontalAlign.Left
        tabr5c12.HorizontalAlign = HorizontalAlign.Right
        tabr5c13.HorizontalAlign = HorizontalAlign.Center
        tabr5c14.HorizontalAlign = HorizontalAlign.Center
        tabr5c15.HorizontalAlign = HorizontalAlign.Center
        tabr5c16.HorizontalAlign = HorizontalAlign.Right

        tabr5c1.Text = "<b><font size=2.5>Si.No&nbsp;&nbsp;</font></b>"
        If rdb = 0 Then
            tabr5c2.Text = "<b><font size=2.5>AREA ID&nbsp;&nbsp;</font></b>"
            tabr5c3.Text = "<b><font size=2.5>AREA NAME&nbsp;&nbsp;</font></b>"
        Else
            tabr5c2.Text = "<b><font size=2.5>BRANCH ID&nbsp;&nbsp;</font></b>"
            tabr5c3.Text = "<b><font size=2.5>BRANCH NAME&nbsp;&nbsp;</font></b>"
        End If
        tabr5c4.Text = "<b><font size=2.5>EMP CODE</font></b>"
        tabr5c5.Text = "<b><font size=2.5>EMP NAME</font></b>"
        tabr5c6.Text = "<b><font size=2.5>POST</font></b>"
        tabr5c7.Text = "<b><font size=2.5>TRANSFER FROM</font></b>"
        tabr5c8.Text = "<b><font size=2.5>TRANSFER TO</font></b>"
        tabr5c9.Text = "<b><font size=2.5>DESIGNATION</font></b>"
        tabr5c10.Text = "<b><font size=2.5>TA FROM DT</font></b>"
        tabr5c11.Text = "<b><font size=2.5>TA TO DT</font></b>"
        tabr5c12.Text = "<b><font size=2.5>ALLOWANCE AS PER CIRCULAR</font></b>"
        tabr5c13.Text = "<b><font size=2.5>WORKING DAYS</font></b>"
        tabr5c14.Text = "<b><font size=2.5>SUSPENSION DAYS</font></b>"
        tabr5c15.Text = "<b><font size=2.5>LEAVE DAYS</font></b>"
        tabr5c16.Text = "<b><font size=2.5>ALLOWANCE PAYABLE</font></b>"

        tabr5.Controls.Add(tabr5c1)
        tabr5.Controls.Add(tabr5c2)
        tabr5.Controls.Add(tabr5c3)
        tabr5.Controls.Add(tabr5c4)
        tabr5.Controls.Add(tabr5c5)
        tabr5.Controls.Add(tabr5c6)
        tabr5.Controls.Add(tabr5c7)
        tabr5.Controls.Add(tabr5c8)
        tabr5.Controls.Add(tabr5c9)
        tabr5.Controls.Add(tabr5c10)
        tabr5.Controls.Add(tabr5c11)
        tabr5.Controls.Add(tabr5c12)
        tabr5.Controls.Add(tabr5c13)
        tabr5.Controls.Add(tabr5c14)
        tabr5.Controls.Add(tabr5c15)
        tabr5.Controls.Add(tabr5c16)
        tab1.Controls.Add(tabr5)

        '''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 20
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 20
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
                tabr6.Width = 20
                tabr6.Attributes.Add("bgcolor", colors)
                Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7, tabr6c8, tabr6c9, tabr6c10, tabr6c11, tabr6c12, tabr6c13, tabr6c14, tabr6c15, tabr6c16 As New TableCell

                tabr6c1.ColumnSpan = "1"
                tabr6c2.ColumnSpan = "1"
                tabr6c3.ColumnSpan = "3"
                tabr6c4.ColumnSpan = "1"
                tabr6c5.ColumnSpan = "2"
                tabr6c6.ColumnSpan = "1"
                tabr6c7.ColumnSpan = "1"
                tabr6c8.ColumnSpan = "1"
                tabr6c9.ColumnSpan = "2"
                tabr6c10.ColumnSpan = "1"
                tabr6c11.ColumnSpan = "1"
                tabr6c12.ColumnSpan = "1"
                tabr6c13.ColumnSpan = "1"
                tabr6c14.ColumnSpan = "1"
                tabr6c15.ColumnSpan = "1"
                tabr6c16.ColumnSpan = "1"


                tabr6c1.Attributes.Add("align", "left")
                tabr6c2.Attributes.Add("align", "left")
                tabr6c3.Attributes.Add("align", "left")
                tabr6c4.Attributes.Add("align", "left")
                tabr6c5.Attributes.Add("align", "left")
                tabr6c6.Attributes.Add("align", "left")
                tabr6c7.Attributes.Add("align", "left")
                tabr6c8.Attributes.Add("align", "left")
                tabr6c9.Attributes.Add("align", "left")
                tabr6c10.Attributes.Add("align", "left")
                tabr6c11.Attributes.Add("align", "left")
                tabr6c12.Attributes.Add("align", "right")
                tabr6c13.Attributes.Add("align", "center")
                tabr6c14.Attributes.Add("align", "center")
                tabr6c15.Attributes.Add("align", "center")
                tabr6c16.Attributes.Add("align", "right")

                tabr6c1.Text = "<font size=2>" & i & "&nbsp;&nbsp;</a></font>"
                tabr6c2.Text = "<font size=2>" & dr(0) & "&nbsp;&nbsp;</a></font>"
                tabr6c3.Text = "<font size=2>" & dr(1) & "</a></font>"
                tabr6c4.Text = "<font size=2>" & dr(2) & "</a></font>"
                tabr6c5.Text = "<font size=2>" & dr(3) & "</a></font>"
                tabr6c6.Text = "<font size=2>&nbsp;&nbsp;&nbsp;" & dr(4) & "</a></font>"
                tabr6c7.Text = "<font size=2>&nbsp;&nbsp;&nbsp;" & Format(dr(5), "dd/MMM/yyyy") & "</a></font>"
                If IsDBNull(dr(6)) Then
                    tabr6c8.Text = "<font size=2>&nbsp;&nbsp;&nbsp;" & dr(6) & "</a></font>"
                Else
                    tabr6c8.Text = "<font size=2>&nbsp;&nbsp;&nbsp;" & Format(dr(6), "dd/MMM/yyyy") & "</a></font>"

                End If
                tabr6c9.Text = "<font size=2>&nbsp;&nbsp;&nbsp;" & dr(7) & "</a></font>"
                tabr6c10.Text = "<font size=2>&nbsp;&nbsp;&nbsp;" & Format(dr(8), "dd/MMM/yyyy") & "</a></font>"
                tabr6c11.Text = "<font size=2>&nbsp;&nbsp;&nbsp;" & Format(dr(9), "dd/MMM/yyyy") & "</a></font>"
                tabr6c12.Text = "<font size=2>&nbsp;&nbsp;&nbsp;" & dr(10) & "</a></font>"
                tabr6c13.Text = "<font size=2>&nbsp;&nbsp;&nbsp;" & dr(11) & "</a></font>"
                tabr6c14.Text = "<font size=2>&nbsp;&nbsp;&nbsp;" & dr(12) & "</a></font>"
                tabr6c15.Text = "<font size=2>&nbsp;&nbsp;&nbsp;" & dr(13) & "</a></font>"
                If dr(14) > 0 Then
                    tabr6c16.Text = "<font size=2>&nbsp;&nbsp;&nbsp;" & FormatNumber(dr(14), 2) & "</a></font>"
                    tot = tot + dr(14)
                Else
                    tabr6c16.Text = "<font size=2>&nbsp;&nbsp;&nbsp;0.00&nbsp;&nbsp;&nbsp;</font>"
                End If

                tabr6.Controls.Add(tabr6c1)
                tabr6.Controls.Add(tabr6c2)
                tabr6.Controls.Add(tabr6c3)
                tabr6.Controls.Add(tabr6c4)
                tabr6.Controls.Add(tabr6c5)
                tabr6.Controls.Add(tabr6c6)
                tabr6.Controls.Add(tabr6c7)
                tabr6.Controls.Add(tabr6c8)
                tabr6.Controls.Add(tabr6c9)
                tabr6.Controls.Add(tabr6c10)
                tabr6.Controls.Add(tabr6c11)
                tabr6.Controls.Add(tabr6c12)
                tabr6.Controls.Add(tabr6c13)
                tabr6.Controls.Add(tabr6c14)
                tabr6.Controls.Add(tabr6c15)
                tabr6.Controls.Add(tabr6c16)

                tab1.Controls.Add(tabr6)
            Next

            Dim tabline5 As New TableRow
            tabline5.Width = 20
            Dim tabcellline5 As New TableCell
            tabcellline5.ColumnSpan = 20
            tabcellline5.Text = "<hr>"
            tab1.Controls.Add(tabline5)

            Dim tabtot As New TableRow
            tabtot.BackColor = Drawing.Color.Cornsilk
            tabtot.ForeColor = Drawing.Color.Red

            tabtot.Width = 20
            Dim tabtot1, tabtot2 As New TableCell
            tabtot1.ColumnSpan = 18
            tabtot2.ColumnSpan = 2
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
