Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_above_10_detailed_leave_above9_report_640ad24f9537
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim dr, dr1 As DataRow
    Dim str, str1 As String
    Dim detailtable As New Table
    Dim total As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ecode As Integer = Me.Request.QueryString("emp_code")
        str = "select em.emp_code,el.leave_frdate,el.leave_todate,el.leave_days,el.leave_reason from employee_master em left outer join employ_leave_dtl el on(em.emp_code=el.emp_code) where to_date(el.leave_frdate)>=to_date('1-jan-'||to_char(sysdate,'yyyy')) and el.leave_process_id in (1,2) and em.status_id<>3 and em.emp_code=" & Me.Request.QueryString("emp_code") & ""
        dt = oh.ExecuteDataSet(str).Tables(0)

        'str1 = "select et.from_dt,et.to_dt,decode(et.status_id,6,'Long Leave',10,'Maternity'),et.remarks from employ_transfer_dtl et where et.emp_code=" & Me.Request.QueryString("emp_code") & " and et.status_id in(6,10)and to_date(et.from_dt)>=to_date('1-jan-'||to_char(sysdate,'yyyy'))"
        'dt1 = oh.ExecuteDataSet(str1).Tables(0)

        detailtable.Attributes.Add("width", "100%")
        Dim header As New TableRow
        header.Width = 10
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        Dim headcell As New TableCell
        headcell.ColumnSpan = 10
        headcell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headcell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headcell)
        detailtable.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.Width = 10
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 10
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        detailtable.Controls.Add(sheader)


        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 10
        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 3
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 4
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subcell2.Text = " "
        subh.Controls.Add(subcell2)

        subcell3.ColumnSpan = 3
        subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)

        detailtable.Controls.Add(subh)

        Dim pheader As New TableRow
        Dim pheadercell As New TableCell
        pheader.Width = 10
        pheadercell.ColumnSpan = 10
        pheadercell.HorizontalAlign = HorizontalAlign.Center

        pheadercell.Text = "<body align=center ><b><font size=3> Employees Having Leave Greater than or Equal to " & Me.Request.QueryString("leaveno") & " days </font></b>"
        pheader.Controls.Add(pheadercell)
        detailtable.Controls.Add(pheader)

        Dim pheaderq As New TableRow
        Dim pheadercellq As New TableCell
        pheaderq.Width = 10
        pheadercellq.ColumnSpan = 10
        pheadercellq.HorizontalAlign = HorizontalAlign.Center

        pheadercellq.Text = "<body align=center ><b><font size=3>  Employee Code:&nbsp;<a href=otherdet_emp.aspx?empcode=" & Me.Request.QueryString("emp_code") & ">" & Me.Request.QueryString("emp_code") & "</a></font></b>"
        pheaderq.Controls.Add(pheadercellq)
        detailtable.Controls.Add(pheaderq)

        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        line1.Width = 10
        linecell1.ColumnSpan = 10
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        detailtable.Controls.Add(line1)

        Dim field As New TableRow
        field.Width = 10
        Dim f1, f2, f3, fll, f4, f5, f6, f7, f8, f9, f10 As New TableCell

        'f1.ColumnSpan = 1
        'f1.HorizontalAlign = HorizontalAlign.Center
        'f1.Text = "<b><font size=2>Si No</font></b>"
        'field.Controls.Add(f1)

        f2.ColumnSpan = 2
        f2.HorizontalAlign = HorizontalAlign.Center
        f2.Text = "<b><font size=2>&nbsp;Leave&nbsp;From&nbsp;</font></b>"
        field.Controls.Add(f2)

        f3.ColumnSpan = 2
        f3.HorizontalAlign = HorizontalAlign.Center
        f3.Text = "<b><font size=2>&nbsp;Leave&nbsp;To&nbsp;</font></b>"
        field.Controls.Add(f3)

        fll.ColumnSpan = 2
        fll.HorizontalAlign = HorizontalAlign.Center
        fll.Text = "<b><font size=2>&nbsp;Leave&nbsp;Days&nbsp;</font></b>"
        field.Controls.Add(fll)

        f4.ColumnSpan = 4
        f4.HorizontalAlign = HorizontalAlign.Left
        f4.Text = "<b><font size=2>&nbsp;&nbsp;&nbsp;Leave&nbsp;&nbsp;Reason&nbsp;</font></b>"
        field.Controls.Add(f4)

        'f5.ColumnSpan = 1
        'f5.HorizontalAlign = HorizontalAlign.Center
        'f5.Text = "<b><font size=2>S/L</font></b>"
        'field.Controls.Add(f5)

        'f6.ColumnSpan = 1
        'f6.HorizontalAlign = HorizontalAlign.Center
        'f6.Text = "<b><font size=2>E/L</font></b>"
        'field.Controls.Add(f6)

        'f7.ColumnSpan = 1
        'f7.HorizontalAlign = HorizontalAlign.Center
        'f7.Text = "<b><font size=2>L.O.P</font></b>"
        'field.Controls.Add(f7)

        'f8.ColumnSpan = 1
        'f8.HorizontalAlign = HorizontalAlign.Center
        'f8.Text = "<b><font size=2>Leave&nbsp;From</font></b>"
        'field.Controls.Add(f8)

        'f9.ColumnSpan = 1
        'f9.HorizontalAlign = HorizontalAlign.Center
        'f9.Text = "<b><font size=2>Leave&nbsp;To</font></b>"
        'field.Controls.Add(f9)

        'f10.ColumnSpan = 1
        'f10.HorizontalAlign = HorizontalAlign.Center
        'f10.Text = "<b><font size=2>Reason</font></b>"
        'field.Controls.Add(f10)

        detailtable.Controls.Add(field)

        Dim linek As New TableRow
        Dim linecellk As New TableCell
        linek.Width = 10
        linecellk.ColumnSpan = 10
        linecellk.Text = "<hr>"
        linek.Controls.Add(linecellk)
        detailtable.Controls.Add(linek)

        For Each dr In dt.Rows

            Dim values As New TableRow
            values.Width = 10
            Dim v1, v2, v3, v4 As New TableCell

            v1.ColumnSpan = 2
            v1.HorizontalAlign = HorizontalAlign.Center
            v1.Text = "<font size=2>" & Format(dr(1), "dd/MMM/yyyy") & "&nbsp;</font>"
            values.Controls.Add(v1)

            v2.ColumnSpan = 2
            v2.HorizontalAlign = HorizontalAlign.Center
            v2.Text = "<font size=2>" & Format(dr(2), "dd/MMM/yyyy") & "&nbsp;</font>"
            values.Controls.Add(v2)

            v3.ColumnSpan = 2
            v3.HorizontalAlign = HorizontalAlign.Right
            v3.Text = "<font size=2>" & dr(3) & "&nbsp;&nbsp;</font></b>"
            values.Controls.Add(v3)
            total += dr(3)

            v4.ColumnSpan = 4
            v4.HorizontalAlign = HorizontalAlign.Left
            v4.Text = "<font size=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & dr(4) & "</font>"
            values.Controls.Add(v4)

            detailtable.Controls.Add(values)



        Next

        Dim linel As New TableRow
        Dim linecelll As New TableCell
        linel.Width = 10
        linecelll.ColumnSpan = 10
        linecelll.Text = "<hr>"
        linel.Controls.Add(linecelll)
        detailtable.Controls.Add(linel)

        Dim totrow As New TableRow
        totrow.Width = 10
        Dim t1 As New TableCell
        t1.ColumnSpan = 10
        t1.HorizontalAlign = HorizontalAlign.Center
        t1.Text = "<b><font size=2> Total Leave:&nbsp;" & Me.total & "</font></b>"
        totrow.Controls.Add(t1)
        detailtable.Controls.Add(totrow)

        Dim linem As New TableRow
        Dim linecellm As New TableCell
        linem.Width = 10
        linecellm.ColumnSpan = 10
        linecellm.Text = "<hr>"
        linem.Controls.Add(linecellm)
        detailtable.Controls.Add(linem)

        Dim detail As New TableRow
        Dim detail1 As New TableCell
        detail.Width = 10
        detail1.ColumnSpan = 10
        detail1.Text = "<a href=otherdet_emp.aspx?empcode=" & Me.Request.QueryString("emp_code") & "><font size=2>Clck here for other Details</font></a>"
        detail.Controls.Add(detail1)
        detailtable.Controls.Add(detail)

        'If dt1.Rows.Count > 0 Then

        '    Dim lineo As New TableRow
        '    Dim linecello As New TableCell
        '    lineo.Width = 10
        '    linecello.ColumnSpan = 10
        '    linecello.Text = "<b><font size=2>Other Leave Details(may be specified above)</font></b>"
        '    lineo.Controls.Add(linecello)
        '    detailtable.Controls.Add(lineo)

        '    Dim gg As New TableRow
        '    Dim ggp As New TableCell
        '    gg.Width = 10
        '    ggp.ColumnSpan = 10
        '    ggp.Text = "<hr>"
        '    gg.Controls.Add(ggp)
        '    detailtable.Controls.Add(gg)


        '    Dim valueq As New TableRow
        '    valueq.Width = 10
        '    Dim vq1, vq2, vq3, vq4 As New TableCell

        '    vq1.ColumnSpan = 2
        '    vq1.HorizontalAlign = HorizontalAlign.Center
        '    vq1.Text = "<b><font size=2>Leave From </font></b>"
        '    valueq.Controls.Add(vq1)

        '    vq2.ColumnSpan = 2
        '    vq2.HorizontalAlign = HorizontalAlign.Center
        '    vq2.Text = "<b><font size=2>  Leave To </font></b>"
        '    valueq.Controls.Add(vq2)

        '    vq3.ColumnSpan = 2
        '    vq3.HorizontalAlign = HorizontalAlign.Right
        '    vq3.Text = "<b><font size=2>Leave Type</font></b>"
        '    valueq.Controls.Add(vq3)
        '    total += dr(3)

        '    vq4.ColumnSpan = 4
        '    vq4.HorizontalAlign = HorizontalAlign.Center
        '    vq4.Text = "<b><font size=2>Reason</font></b>"
        '    valueq.Controls.Add(vq4)

        '    detailtable.Controls.Add(valueq)

        '    For Each dr1 In dt1.Rows
        '        Dim valuew As New TableRow
        '        valuew.Width = 10
        '        Dim vw1, vw2, vw3, vw4 As New TableCell

        '        vw1.ColumnSpan = 2
        '        vw1.HorizontalAlign = HorizontalAlign.Center
        '        vw1.Text = "<font size=2>" & Format(dr1(0), "dd/MMM/yyyy") & "</font>"
        '        valuew.Controls.Add(vw1)

        '        vw2.ColumnSpan = 2
        '        vw2.HorizontalAlign = HorizontalAlign.Center

        '        If IsDBNull(dr1(1)) Then
        '            vw2.Text = "<font size=2>Still in L/L</font>"
        '        Else
        '            vw2.Text = "<font size=2>" & Format(dr1(1), "dd/MMM/yyyy") & "</font>"
        '        End If

        '        valuew.Controls.Add(vw2)

        '        vw3.ColumnSpan = 2
        '        vw3.HorizontalAlign = HorizontalAlign.Right
        '        vw3.Text = "<font size=2>" & dr1(2) & "</font>"
        '        valuew.Controls.Add(vw3)

        '        vw4.ColumnSpan = 4
        '        vw4.HorizontalAlign = HorizontalAlign.Center
        '        If IsDBNull(dr1(3)) Then
        '            vw4.Text = "<font size=2>Not specified</font>"
        '        Else
        '            vw4.Text = "<font size=2>" & dr1(3) & "</font>"
        '        End If
        '        valuew.Controls.Add(vw4)

        '        detailtable.Controls.Add(valuew)

        '    Next
        '    Dim linep As New TableRow
        '    Dim linecellp As New TableCell
        '    linep.Width = 10
        '    linecellp.ColumnSpan = 10
        '    linecellp.Text = "<hr>"
        '    linep.Controls.Add(linecellp)
        '    detailtable.Controls.Add(linep)




        'End If

        Panel_detailed.Controls.Add(detailtable)
       

    End Sub
End Class
