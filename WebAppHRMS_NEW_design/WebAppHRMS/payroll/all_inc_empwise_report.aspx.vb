Imports System.Data
Imports System.Data.OracleClient
Partial Class all_inc_empwise_report_65556dd39245
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim prdt As String
    Dim total As Double = 0.0

    Private Function checknull(ByVal a) As String
        If IsDBNull(a) Then
            Return ("0.00")

        Else
            Return (FormatNumber(a, 2))
        End If
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.Request.QueryString("prdate") = "15/aug/1947" Then
            '             
            str = "select bm.branch_name,em.emp_code,em.emp_name,im.all_name as name,nvl(id.all_amount,0) from incentives_allowances_master im,incentives_allowances_dtl id,employee_master em,branch_master bm where id.emp_code=em.emp_code and id.branch_id=bm.branch_id and id.all_id=im.all_id and id.emp_code=" & Request.QueryString("emp_code") & " union select bc.branch_name,em.emp_code,em.emp_name,im.all_name as name,nvl(id.all_amount,0) from incentives_allowances_master im,incentives_allowances_dtl id,employee_master em,before_completion bc where id.emp_code=em.emp_code and id.branch_id=bc.old_id and bc.branch_id is null and id.all_id=im.all_id and id.emp_code=" & Request.QueryString("emp_code") & " order by name"
        Else
            str = "select bm.branch_name,em.emp_code,em.emp_name,im.all_name as name,nvl(id.all_amount,0) from incentives_allowances_master im,incentives_allowances_dtl id,employee_master em,branch_master bm where id.emp_code=em.emp_code and id.branch_id=bm.branch_id and id.all_id=im.all_id and id.emp_code=" & Request.QueryString("emp_code") & " and to_date(id.pr_date)=to_date('" & Me.Request.QueryString("prdate") & "') union select bc.branch_name,em.emp_code,em.emp_name,im.all_name as name,nvl(id.all_amount,0) from incentives_allowances_master im,incentives_allowances_dtl id,employee_master em,before_completion bc where id.emp_code=em.emp_code and id.branch_id=bc.old_id and bc.branch_id is null and id.all_id=im.all_id and id.emp_code=" & Request.QueryString("emp_code") & " and to_date(id.pr_date)=to_date('" & Me.Request.QueryString("prdate") & "') order by name"
        End If

        dt = oh.ExecuteDataSet(str).Tables(0)

        'Dim subtot As Double = dt.Rows(0)(1) + dt.Rows(0)(2) + dt.Rows(0)(3) + dt.Rows(0)(4) + dt.Rows(0)(5) + dt.Rows(0)(6) + dt.Rows(0)(7) + dt.Rows(0)(8) + dt.Rows(0)(9) + dt.Rows(0)(10) + dt.Rows(0)(11) + dt.Rows(0)(12) + dt.Rows(0)(13) + dt.Rows(0)(14) + dt.Rows(0)(15) + dt.Rows(0)(16) + dt.Rows(0)(17) + dt.Rows(0)(18) + dt.Rows(0)(19) + dt.Rows(0)(20) + dt.Rows(0)(21) + dt.Rows(0)(22) + dt.Rows(0)(23) + dt.Rows(0)(24) + dt.Rows(0)(25) + dt.Rows(0)(26) + dt.Rows(0)(27)

        Dim subtable As New Table
        subtable.Attributes.Add("width", "100%")
        Dim header As New TableRow
        Dim headercell As New TableCell
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        headercell.ColumnSpan = 4
        headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headercell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headercell)
        subtable.Controls.Add(header)

        Dim sheader As New TableRow
        Dim sheadercell1 As New TableCell
        Dim sheadercell2 As New TableCell
        sheadercell1.ColumnSpan = 4
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        subtable.Controls.Add(sheader)


        ''''''' Dim s As String = oh.ExecuteDataSet("select month_name from month where month_id=" & Now.Month - 1).Tables(0).Rows(0)(0)

        'Dim s As String = oh.ExecuteDataSet("select distinct to_char(to_date(s.sal_dt),'MONTH') from salari s").Tables(0).Rows(0)(0)

        'Dim y As Integer = oh.ExecuteDataSet("select distinct to_char(to_date(s.sal_dt),'YYYY') from salari s").Tables(0).Rows(0)(0)
        Dim dtt As DataTable = oh.ExecuteDataSet("select distinct to_char(to_date(s.sal_dt),'MONTH'),to_char(to_date(s.sal_dt),'YYYY') from salari s").Tables(0)
        Dim s As String
        Dim y As Integer = 0
        If dtt.Rows.Count > 0 Then
            s = dtt.Rows(0)(0)
            y = dtt.Rows(0)(1)
        Else
            s = "Last month"
        End If

        Dim head As New TableRow
        head.Width = 4
        Dim hh1 As New TableCell
        hh1.ColumnSpan = 4
        hh1.Text = "<body align=center><b><font size=2.5> Detailed Allowances and Incentives Report of " & s & " " & y & " </font></b></body>"
        head.Controls.Add(hh1)
        subtable.Controls.Add(head)

        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell

        subcell1.ColumnSpan = 1
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subh.Controls.Add(subcell1)
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subcell2.ColumnSpan = 2


        subh.Controls.Add(subcell2)

        subcell3.HorizontalAlign = HorizontalAlign.Right
        ' subcell3.Text = "<b><font size=2> Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.Text = "<font size=2><b><div id= txt align= right></div></b></font></div>"
        subh.Controls.Add(subcell3)
        subtable.Controls.Add(subh)
        Dim linerowa As New TableRow
        Dim linecella As New TableCell
        linecella.ColumnSpan = 4
        linecella.HorizontalAlign = HorizontalAlign.Center
        linecella.Text = "<hr>"
        linerowa.Controls.Add(linecella)
        subtable.Controls.Add(linerowa)


        '///////////////////////
        Dim prd As New TableRow
        Dim prd1, prd2, prd3 As New TableCell
        prd.Width = 4
        prd1.ColumnSpan = 2
        prd2.ColumnSpan = 1
        prd3.ColumnSpan = 1
        prd1.HorizontalAlign = HorizontalAlign.Left
        prd2.HorizontalAlign = HorizontalAlign.Center
        prd3.HorizontalAlign = HorizontalAlign.Left
        prd1.Text = "<b><font size=2>&nbsp;Process&nbsp;Date&nbsp;</font></b>"
        prd2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
        If Me.Request.QueryString("prdate") = "15/aug/1947" Then
            prd3.Text = "<font size=2>-----<font>"
        Else
            prd3.Text = "<font size=2>" & Request.QueryString("prdate") & "<font>"
        End If
        prd.Controls.Add(prd1)
        prd.Controls.Add(prd2)
        prd.Controls.Add(prd3)

        subtable.Controls.Add(prd)
        '////////////////////////////////

        Dim empc As New TableRow
        Dim empc1, empc2, empc3 As New TableCell
        empc.Width = 4
        empc1.ColumnSpan = 2
        empc2.ColumnSpan = 1
        empc3.ColumnSpan = 1
        empc1.HorizontalAlign = HorizontalAlign.Left
        empc2.HorizontalAlign = HorizontalAlign.Center
        empc3.HorizontalAlign = HorizontalAlign.Left
        empc1.Text = "<b><font size=2>&nbsp;Employee&nbsp;Code&nbsp;</font></b>"
        empc2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
        empc3.Text = "<font size=2>" & Request.QueryString("emp_code") & "<font>"
        empc.Controls.Add(empc1)
        empc.Controls.Add(empc2)
        empc.Controls.Add(empc3)

        subtable.Controls.Add(empc)

        Dim empn As New TableRow
        Dim empn1, empn2, empn3 As New TableCell
        empn.Width = 4
        empn1.ColumnSpan = 2
        empn2.ColumnSpan = 1
        empn3.ColumnSpan = 1
        empn1.HorizontalAlign = HorizontalAlign.Left
        empn2.HorizontalAlign = HorizontalAlign.Center
        empn3.HorizontalAlign = HorizontalAlign.Left
        empn1.Text = "<b><font size=2>&nbsp;Employee&nbsp;Name&nbsp;</font></b>"
        empn2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
        empn3.Text = "<font size=2>" & dt.Rows(0)(2) & "<font>"
        empn.Controls.Add(empn1)
        empn.Controls.Add(empn2)
        empn.Controls.Add(empn3)
        subtable.Controls.Add(empn)





        Dim bname As New TableRow
        Dim bname1, bname2, bname3 As New TableCell
        bname.Width = 4
        bname1.ColumnSpan = 2
        bname2.ColumnSpan = 1
        bname3.ColumnSpan = 1
        bname1.HorizontalAlign = HorizontalAlign.Left
        bname2.HorizontalAlign = HorizontalAlign.Center
        bname3.HorizontalAlign = HorizontalAlign.Left
        bname1.Text = "<b><font size=2>&nbsp;Branch&nbsp;Name&nbsp;</font></b>"
        bname2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
        bname3.Text = "<font size=2>" & dt.Rows(0)(0) & "<font>"
        bname.Controls.Add(bname1)
        bname.Controls.Add(bname2)
        bname.Controls.Add(bname3)
        subtable.Controls.Add(bname)

        For Each dr In dt.Rows

            Dim value As New TableRow
            value.Width = 4
            Dim v1, v2, v3 As New TableCell
            v1.ColumnSpan = 2
            v2.ColumnSpan = 1
            v2.ColumnSpan = 1
            v1.HorizontalAlign = HorizontalAlign.Left
            v2.HorizontalAlign = HorizontalAlign.Center
            v3.HorizontalAlign = HorizontalAlign.Right
            v1.Text = "<b><font size=2>" & dr(3) & "&nbsp;</font></b>"
            v2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
            v3.Text = "<font size=2>" & FormatNumber(dr(4), 2) & "&nbsp;&nbsp;&nbsp;</font>"

            Me.total += dr(4)

            value.Controls.Add(v1)
            value.Controls.Add(v2)
            value.Controls.Add(v3)
            subtable.Controls.Add(value)

        Next

        Dim hline As New TableRow
        hline.Width = 4
        Dim h1 As New TableCell
        h1.ColumnSpan = 4
        h1.Text = "<hr>"
        hline.Controls.Add(h1)
        subtable.Controls.Add(hline)

        Dim totr As New TableRow
        totr.Width = 4
        Dim t1, t2, t3 As New TableCell
        t1.ColumnSpan = 2
        t2.ColumnSpan = 1
        t3.ColumnSpan = 1
        t1.HorizontalAlign = HorizontalAlign.Left
        t2.HorizontalAlign = HorizontalAlign.Center
        t3.HorizontalAlign = HorizontalAlign.Right
        t1.Text = "<b><font size=2>Total</font></b>"
        t2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
        t3.Text = "<font size=2>" & FormatNumber(Me.total, 2) & "&nbsp;&nbsp;&nbsp;</font>"
        totr.Controls.Add(t1)
        totr.Controls.Add(t2)
        totr.Controls.Add(t3)
        subtable.Controls.Add(totr)



        '////////////////////////////////////////////////////////////////////////

        Panel_SecondReport.Controls.Add(subtable)

    End Sub
End Class
