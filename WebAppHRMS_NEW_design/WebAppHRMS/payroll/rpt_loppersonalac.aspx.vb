Imports System.Data
Imports System.Data.OracleClient
Partial Class lop_to_personal_account_report_rpt_loppersonalac_650299a31659
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '  Dim str As String = "select distinct e.emp_code,em.emp_name,e.leave_frdate || '   -   ' || e.leave_todate as leavedate,e.leave_days,e.leave_apply_date,e.leave_enter_date,upper(e.leave_reason),e.recomm_person ,t.leave_seq from employ_leave_dtl e,employee_master em, hrm_personal_acc_data t where to_char(to_date(t.tra_dt),'MM')=to_char(to_date('1/" & Me.Request.QueryString("dat") & "'),'MM') and e.emp_code=em.emp_code and t.leave_seq=e.leave_seq order by e.emp_code"

        Dim dtt As String = Format(CDate(Me.Request.QueryString("dat")), "dd/MMM/yyyy")

        ' Dim str As String = "select distinct e.emp_code,em.emp_name,to_char(e.leave_frdate,'dd/MON/yyyy') , to_char(e.leave_todate,'dd/MON/yyyy') as leavedate,e.leave_days,to_char(e.leave_apply_date,'dd/MON/yyyy'),to_char(e.leave_enter_date,'dd/MON/yyyy'),upper(e.leave_reason),e.recomm_person ,t.leave_seq,t.amount from employ_leave_dtl e,employee_master em, hrm_personal_acc_data t where to_char(to_date(t.tra_dt),'MM')=to_char(to_date('" & dtt & "'),'MM') and to_number(to_char(to_date(t.tra_dt),'yyyy'))=to_number(to_char(to_date('" & dtt & "'),'yyyy')) and e.emp_code=em.emp_code and t.leave_seq=e.leave_seq order by e.emp_code"
        'Dim str As String = "select distinct e.emp_code,em.emp_name, to_char(e.leave_frdate, 'dd/MON/yyyy'), to_char(e.leave_todate, 'dd/MON/yyyy') as leavedate, e.leave_days, to_char(e.leave_apply_date, 'dd/MON/yyyy'), to_char(e.leave_enter_date, 'dd/MON/yyyy'),upper(e.leave_reason), e.recomm_person,t.leave_seq,t.amount, t.tra_dt from employ_leave_dtl e, employee_master em, hrm_personal_acc_data t where to_date(t.tra_dt)  between to_date('" & dtt & "')  and  last_day( to_date(' " & dtt & "')) and e.emp_code = em.emp_code and t.leave_seq = e.leave_seq order by e.emp_code"

        Dim str As String = "select distinct e.emp_code,em.emp_name, to_char(e.leave_frdate, 'dd/MON/yyyy'), to_char(e.leave_todate, 'dd/MON/yyyy') as leavedate, e.leave_days, to_char(e.leave_apply_date, 'dd/MON/yyyy'), to_char(e.leave_enter_date, 'dd/MON/yyyy'),upper(e.leave_reason), e.recomm_person,t.leave_seq,t.amount, t.tra_dt,EM.JOIN_DT,m.discont_dt from employ_leave_dtl e,employee_master_dtl m, employee_master em, hrm_personal_acc_data t,employ_firm ef where to_date(t.tra_dt)  between to_date('" & dtt & "')  and  last_day( to_date(' " & dtt & "')) and e.emp_code = em.emp_code and em.emp_code=m.emp_code and em.emp_code = ef.emp_code and ef.firm_id = " & Session("firm_id") & " and t.leave_seq = e.leave_seq order by e.emp_code"
        '     MsgBox(str)
        Dim dt As DataTable = oh.ExecuteDataSet(str).Tables(0)
        If dt.Rows.Count = 0 Then
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('Data Not Available');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If
        'table declaration
        Dim tab1 As New Table
        ' tab1.BorderWidth = 1
        tab1.Attributes.Add("width", "100%")
        '1st row declaration
        Dim tabr1 As New TableRow
        tabr1.Width = 18
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.Attributes.Add("bordercolor", "red")
        'cell declaration
        Dim tabc1 As New TableCell
        tabc1.Attributes.Add("forecolor", "blue")
        tabc1.Attributes.Add("align", "center")
        tabc1.ColumnSpan = 18
        ' tabc1.Text = "<body align=center ><b><font size=4>MANAPPURAM GROUP OF COMPANIES</font></b></body>"
        tabc1.Text = "<body align=center ><b><font size=4>" & Me.Session("firm_name") & " </font></b></body>"



        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab1.Controls.Add(tabr1)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Width = 18
        'cell declaration
        Dim tabc2 As New TableCell
        tabc2.ColumnSpan = 18
        tabc2.Attributes.Add("align", "center")
        tabc2.Text = "<body align=center color=red><b><font size=3.5> LOP-PERSONAL ACCOUNT REPORT FOR " & Me.Request.QueryString("dat") & "</font></b></body>"

        tabc2.ForeColor = Drawing.Color.Maroon
        tabr2.Controls.Add(tabc2)
        tab1.Controls.Add(tabr2)
        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Attributes.Add("bgcolor", "#ffcca3")

        'cell declaration
        Dim tabcc3 As New TableCell
        tabcc3.ColumnSpan = 7
        tabcc3.Attributes.Add("align", "left")
        tabcc3.Text = "<b><font size=3.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
        tabcc3.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc3)
        tab1.Controls.Add(tabrr3)

        Dim tabcct As New TableCell
        tabcct.ColumnSpan = 4
        tabcct.Attributes.Add("align", "left")
        tabcct.Text = ""
        tabcct.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcct)
        tab1.Controls.Add(tabrr3)


        'cell declaration
        Dim tabcc4 As New TableCell
        tabcc4.ColumnSpan = 7
        tabcc4.Attributes.Add("align", "right")
        tabcc4.Font.Bold = True
        tabcc4.Text = "<div id='txt'></div>"
        tabcc4.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc4)
        tab1.Controls.Add(tabrr3)

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabline As New TableRow
        tabline.Width = 18
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 18
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab1.Controls.Add(tabline)
        ''''''''''''''''''''''''''''''''''''''''
        Dim tabr5 As New TableRow
        tabr5.Width = 18
        tabr5.ForeColor = Drawing.Color.DarkRed
        Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7, tabr5c8, tabr5c9, tabr5c10, tabr5c11, tabr5c12 As New TableCell
        tabr5c9.ColumnSpan = "1"
        tabr5c1.ColumnSpan = "1"
        tabr5c2.ColumnSpan = "2"
        tabr5c3.ColumnSpan = "1"
        tabr5c4.ColumnSpan = "1"
        tabr5c5.ColumnSpan = "1"
        tabr5c6.ColumnSpan = "1"
        tabr5c7.ColumnSpan = "1"
        tabr5c8.ColumnSpan = "2"
        tabr5c10.ColumnSpan = "1"
        tabr5c11.ColumnSpan = "3"
        tabr5c12.ColumnSpan = "3"

        tabr5c1.HorizontalAlign = HorizontalAlign.Center
        tabr5c2.HorizontalAlign = HorizontalAlign.Center
        tabr5c5.HorizontalAlign = HorizontalAlign.Center
        tabr5c6.HorizontalAlign = HorizontalAlign.Center
        tabr5c3.HorizontalAlign = HorizontalAlign.Center
        tabr5c4.HorizontalAlign = HorizontalAlign.Center
        tabr5c7.HorizontalAlign = HorizontalAlign.Center
        tabr5c8.HorizontalAlign = HorizontalAlign.Center
        tabr5c9.HorizontalAlign = HorizontalAlign.Center
        tabr5c10.HorizontalAlign = HorizontalAlign.Right
        tabr5c11.HorizontalAlign = HorizontalAlign.Center
        tabr5c12.HorizontalAlign = HorizontalAlign.Center


        tabr5c9.Text = "<b><font size=2.5>SI.No</font></b>"
        tabr5c1.Text = "<b><font size=2.5>EMP CODE</font></b>"
        tabr5c2.Text = "<b><font size=2.5>EMP NAME&nbsp;&nbsp;</font></b>"
        tabr5c3.Text = "<b><font size=2.5>LEAVE FROM</font></b>"
        tabr5c4.Text = "<b><font size=2.5>LEAVE TO</font></b>"
        tabr5c5.Text = "<b><font size=2.5>LEAVE DAYS</font></b>"
        tabr5c6.Text = "<b><font size=2.5>APPLY DATE</font></b>"
        tabr5c7.Text = "<b><font size=2.5>PERSONAL A/C DATE</font></b>"
        tabr5c8.Text = "<b><font size=2.5>LEAVE REASON</font></b>"
        tabr5c10.Text = "<b><font size=2.5>AMOUNT</font></b>"
        tabr5c11.Text = "<b><font size=2.5>JOIN DATE</font></b>"
        tabr5c12.Text = "<b><font size=2.5>RESGN DATE</font></b>"

        tabr5.Controls.Add(tabr5c9)
        tabr5.Controls.Add(tabr5c1)
        tabr5.Controls.Add(tabr5c2)
        tabr5.Controls.Add(tabr5c3)
        tabr5.Controls.Add(tabr5c4)
        tabr5.Controls.Add(tabr5c5)
        tabr5.Controls.Add(tabr5c6)
        tabr5.Controls.Add(tabr5c7)
        tabr5.Controls.Add(tabr5c8)
        tabr5.Controls.Add(tabr5c10)
        tabr5.Controls.Add(tabr5c11)
        tabr5.Controls.Add(tabr5c12)

        tab1.Controls.Add(tabr5)

        '''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 18
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 18
        tabcellline1.Text = "<hr>"
        tabline1.Controls.Add(tabcellline1)
        tab1.Controls.Add(tabline1)
        '''''''''''''''''''''''''''''''''
        Dim colors As String
        colors = "#fff7ff"
        Dim dr As DataRow
        Dim zone As String = ""
        Dim i As Integer = 0
        For Each dr In dt.Rows
            i += 1
            If colors.Equals("#fff7ff") = True Then
                colors = "#eef9ff"
            Else
                colors = "#fff7ff"
            End If
            Dim tabr6 As New TableRow
            tabr6.Width = 12
            tabr6.Attributes.Add("bgcolor", colors)
            Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7, tabr6c8, tabr6c9, tabr6c10, tabr6c11, tabr6c12 As New TableCell

            tabr6c9.ColumnSpan = "1"
            tabr6c1.ColumnSpan = "1"
            tabr6c2.ColumnSpan = "2"
            tabr6c3.ColumnSpan = "1"
            tabr6c4.ColumnSpan = "1"
            tabr6c5.ColumnSpan = "1"
            tabr6c6.ColumnSpan = "1"
            tabr6c7.ColumnSpan = "1"
            tabr6c8.ColumnSpan = "2"
            tabr6c10.ColumnSpan = "1"
            tabr6c11.ColumnSpan = "3"
            tabr6c12.ColumnSpan = "3"

            tabr6c9.Attributes.Add("align", "center")
            tabr6c1.Attributes.Add("align", "left")
            tabr6c2.Attributes.Add("align", "left")
            tabr6c3.Attributes.Add("align", "left")
            tabr6c4.Attributes.Add("align", "left")
            tabr6c5.Attributes.Add("align", "center")
            tabr6c6.Attributes.Add("align", "left")
            tabr6c7.Attributes.Add("align", "left")
            tabr6c8.Attributes.Add("align", "left")
            tabr6c10.Attributes.Add("align", "right")
            tabr6c11.Attributes.Add("align", "center")
            tabr6c12.Attributes.Add("align", "center")

            tabr6c9.Text = "<font size=2>" & i & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c1.Text = "<font size=2>" & dr(0) & "</font>"
            tabr6c2.Text = "<font size=2>" & dr(1) & "</font>"
            tabr6c3.Text = "<font size=2>" & dr(2) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c4.Text = "<font size=2>" & dr(3) & "</font>"
            tabr6c5.Text = "<font size=2>" & dr(4) & "</font>"
            tabr6c6.Text = "<font size=2>" & dr(5) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c7.Text = "<font size=2>" & Format(dr(11), "dd/MMM/yyyy") & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c8.Text = "<font size=2>" & dr(7) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c10.Text = "<font size=2>" & dr(10) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c11.Text = "<font size=2>" & dr(12) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c12.Text = "<font size=2>" & dr(13) & "&nbsp;&nbsp;&nbsp;</font>"

            tabr6.Controls.Add(tabr6c9)
            tabr6.Controls.Add(tabr6c1)
            tabr6.Controls.Add(tabr6c2)
            tabr6.Controls.Add(tabr6c3)
            tabr6.Controls.Add(tabr6c4)
            tabr6.Controls.Add(tabr6c5)
            tabr6.Controls.Add(tabr6c6)
            tabr6.Controls.Add(tabr6c7)
            tabr6.Controls.Add(tabr6c8)
            tabr6.Controls.Add(tabr6c10)
            tabr6.Controls.Add(tabr6c11)
            tabr6.Controls.Add(tabr6c12)

            tab1.Controls.Add(tabr6)
        Next

        Me.Panel1.Controls.Add(tab1)


    End Sub
End Class
