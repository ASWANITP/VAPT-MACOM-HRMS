Imports System.Data
Imports System.Data.OracleClient
Partial Class allo_inc_firstreport_3e57fe0e3541
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str, str1 As String
    Dim i As Integer = 0
    Dim total As Double = 0.0
    Dim tatable As New Table
    Private Function checknull(ByVal a) As String
        If IsDBNull(a) Then
            Return ("0.00")
        Else
            Return (FormatNumber(a, 2))
        End If
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim User() As String = Session("user_id").ToString.Split("!")
        'Dim UserId As Integer = User(0)
        Dim access As Integer
        access = Session("access_id")
        'If access <> 33 Then
        '    Server.Transfer("../show_err.aspx")
        '    Exit Sub
        'End If



        tatable.Attributes.Add("width", "100%")
        Dim stuser As String = Me.Session("user_id")
        Dim st() As String = stuser.Split("!")
        '-------for head office employeewise ------so key=1
        If Me.Request.QueryString("key") = 1 Then
            Dim cn As Integer = oh.ExecuteDataSet("select count(emp_code) from incentives_allowances_dtl where emp_code=" & st(0)).Tables(0).Rows(0)(0)
            If cn <> 0 Then
                Dim bid As Integer = oh.ExecuteDataSet("select count(branch_id) from incentives_allowances_dtl where emp_code=" & st(0)).Tables(0).Rows(0)(0)
                If bid > 0 Then
                    '        '          0        --1----   --------2---    ---------3------                     
                    str = "select id.emp_code,em.emp_name,dm.designation,nvl(sum(id.all_amount),0)as Total,to_char(id.pr_date) from incentives_allowances_dtl id,employee_master em,designation_master dm where em.emp_code=id.emp_code  and em.designation_id=dm.designation_id and id.status_id=1 and id.emp_code=" & st(0) & " group by id.emp_code,em.emp_name,dm.designation,id.pr_date order by id.pr_date,id.emp_code"
                End If
            End If
            '----------for branches------so key=2----all employees in a branch excluding res,sus,L/L,Termi and maternity 
        ElseIf Me.Request.QueryString("key") = 2 Then
            If access <> 33 Then
                Dim cn As Integer = oh.ExecuteDataSet("select count(emp_code) from incentives_allowances_dtl where emp_code=" & st(0)).Tables(0).Rows(0)(0)
                If cn <> 0 Then
                    Dim bid As Integer = oh.ExecuteDataSet("select count(branch_id) from incentives_allowances_dtl where emp_code=" & st(0)).Tables(0).Rows(0)(0)
                    If bid > 0 Then
                        '        '          0        --1----   --------2---    ---------3------                     
                        str = "select id.emp_code,em.emp_name,dm.designation,nvl(sum(id.all_amount),0)as Total,to_char(id.pr_date) from incentives_allowances_dtl id,employee_master em,designation_master dm where em.emp_code=id.emp_code  and em.designation_id=dm.designation_id and id.status_id=1 and id.emp_code=" & st(0) & " group by id.emp_code,em.emp_name,dm.designation,id.pr_date order by id.pr_date,id.emp_code"
                    End If
                End If
            Else
                str = "select id.emp_code,em.emp_name,dm.designation,nvl(sum(id.all_amount),0)as Total,to_char(id.pr_date) as PrDate from incentives_allowances_dtl id,employee_master em,designation_master dm where em.emp_code=id.emp_code  and em.designation_id=dm.designation_id and id.status_id not in (3,4,5,6,10) and id.status_id is not null and id.branch_id=" & Me.Session("branch_id") & " group by id.emp_code,em.emp_name,dm.designation,id.pr_date union select id.emp_code,em.emp_name,dm.designation,nvl(sum(id.all_amount),0)as Total,to_char(id.pr_date) as PrDate from incentives_allowances_dtl id,employee_master em,designation_master dm,employee_master_dtl ed where em.emp_code=id.emp_code and ed.emp_code=id.emp_code and em.designation_id=dm.designation_id and id.status_id =5 and ed.new_empcode is not null  and id.branch_id=" & Me.Session("branch_id") & " group by id.emp_code,em.emp_name,dm.designation,id.pr_date order by  PrDate,emp_code"
                'str1 = "select nvl(cg.cash,0) as cash,nvl(cg.gold,0) as gold from cash_gold cg where cg.branch_id=" & Session("branch_id") & ""
                'dt1 = oh.ExecuteDataSet(str1).Tables(0)
            End If

        End If
        If str = "" Then
            Dim blank As New TableRow
            blank.Width = 6
            Dim b1 As New TableCell
            b1.ColumnSpan = 6
            b1.HorizontalAlign = HorizontalAlign.Center
            b1.Text = "<b><font size=2>Not Processed..Please Check After Sometime !!</font></b>"
            blank.Controls.Add(b1)
            tatable.Controls.Add(blank)
        Else
            dt = oh.ExecuteDataSet(str).Tables(0)
            If dt.Rows.Count > 0 Then
                Dim header As New TableRow
                header.BackColor = Drawing.Color.Gold
                header.ForeColor = Drawing.Color.Red
                header.Width = 6
                Dim headercell As New TableCell
                headercell.ColumnSpan = 6
                headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
                headercell.HorizontalAlign = HorizontalAlign.Center
                header.Controls.Add(headercell)
                tatable.Controls.Add(header)

                Dim sheader As New TableRow
                sheader.BackColor = Drawing.Color.LightGray
                Dim sheadercell1 As New TableCell
                Dim sheadercell2 As New TableCell
                sheadercell1.ColumnSpan = 6
                sheadercell1.HorizontalAlign = HorizontalAlign.Center
                sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
                sheader.Controls.Add(sheadercell1)
                tatable.Controls.Add(sheader)

                'Dim s As String = oh.ExecuteDataSet("select month_name from month where month_id=" & Now.Month - 1).Tables(0).Rows(0)(0)
                'dim Cnt as Integer=oh.ExecuteDataSet("select count(*) from salari").Tables(0).
                Dim dtt As DataTable = oh.ExecuteDataSet("select distinct to_char(to_date(s.sal_dt),'MONTH'),to_char(to_date(s.sal_dt),'YYYY') from salari s").Tables(0)
                Dim s As String
                Dim y As Integer = 0
                If dtt.Rows.Count > 0 Then
                    s = dtt.Rows(0)(0)
                    y = dtt.Rows(0)(1)
                Else
                    s = "Last month"
                End If


                Dim tt As New TableRow
                tt.BackColor = Drawing.Color.LightSkyBlue
                tt.Width = 6
                Dim tt1 As New TableCell
                tt1.ColumnSpan = 6
                tt1.HorizontalAlign = HorizontalAlign.Center
                tt1.Text = "<b><font size=2>Incentives and Allowances Report of " & s & " " & y & " </font></b>"
                tt.Controls.Add(tt1)
                tatable.Controls.Add(tt)

                Dim subh As New TableRow
                Dim subcell1 As New TableCell
                Dim subcell2 As New TableCell
                Dim subcell3 As New TableCell
                subh.Width = 6

                subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
                subcell1.ColumnSpan = 2
                subcell1.HorizontalAlign = HorizontalAlign.Left
                subh.Controls.Add(subcell1)

                subcell2.ColumnSpan = 2
                subcell2.HorizontalAlign = HorizontalAlign.Center
                subh.Controls.Add(subcell2)
                subcell3.ColumnSpan = 2
                subcell3.HorizontalAlign = HorizontalAlign.Left
                subcell3.Text = "<b><font size=2.5>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
                subcell3.HorizontalAlign = HorizontalAlign.Right
                subh.Controls.Add(subcell3)
                tatable.Controls.Add(subh)

                Dim line As New TableRow
                Dim linecell As New TableCell
                linecell.ColumnSpan = 6
                linecell.Text = "<hr>"
                line.Controls.Add(linecell)
                tatable.Controls.Add(line)


                Dim colors As String
                colors = "#fff7ff"

                Dim row2 As New TableRow
                row2.Width = 6
                row2.Attributes.Add("bgcolor", colors)
                Dim h1 As New TableCell
                Dim hq As New TableCell
                Dim h2 As New TableCell
                Dim h3 As New TableCell
                Dim h4 As New TableCell
                Dim h5 As New TableCell
                Dim h6 As New TableCell
                Dim h7 As New TableCell

                h1.ColumnSpan = 1
                h1.HorizontalAlign = HorizontalAlign.Left
                h1.Text = "<b><font size=2>Emp&nbsp;Code&nbsp;</font></b>"
                row2.Controls.Add(h1)

                hq.ColumnSpan = 2
                hq.HorizontalAlign = HorizontalAlign.Left
                hq.Text = "<b><font size=2>Employee&nbsp;Name&nbsp;</font></b>"
                row2.Controls.Add(hq)

                h2.ColumnSpan = 2
                h2.HorizontalAlign = HorizontalAlign.Left
                h2.Text = "<b><font size=2>Designation&nbsp;</font></b>"
                row2.Controls.Add(h2)

                h3.ColumnSpan = 1
                h3.HorizontalAlign = HorizontalAlign.Center
                h3.Text = "<b><font size=2>Total</font></b>"
                row2.Controls.Add(h3)

                tatable.Controls.Add(row2)

                Dim line3 As New TableRow
                Dim linecell3 As New TableCell
                linecell3.ColumnSpan = 6
                linecell3.Text = "<hr>"
                line3.Controls.Add(linecell3)
                tatable.Controls.Add(line3)

                Dim prodate As String = ""

                For Each dr In dt.Rows

                    i += 1

                    If Not IsDBNull(dr(4)) Then
                        If prodate <> dr(4) Then
                            Dim pdater As New TableRow
                            pdater.Width = 6
                            Dim pdatecell As New TableCell
                            pdatecell.ColumnSpan = 6
                            pdatecell.HorizontalAlign = HorizontalAlign.Left
                            pdatecell.Text = "<font size=2><b>Processed Date:</b>" & dr(4) & "</font>"
                            pdater.Controls.Add(pdatecell)
                            tatable.Controls.Add(pdater)

                        End If

                        prodate = dr(4)

                    End If

                    If colors.Equals("#fff7ff") = True Then
                        colors = "#eef9ff"
                    Else
                        colors = "#fff7ff"
                    End If

                    Dim drow As New TableRow
                    drow.Width = 6
                    drow.Attributes.Add("bgcolor", colors)
                    Dim d1, dq, d2, d3, d4 As New TableCell

                    d1.HorizontalAlign = HorizontalAlign.Left
                    d1.ColumnSpan = 1
                    If Not IsDBNull(dr(4)) Then
                        d1.Text = "<a href=all_inc_empwise_report.aspx?emp_code=" & dr(0) & "&prdate=" & dr(4) & "><font size=2>" & dr(0) & "</font></a>"
                    Else
                        d1.Text = "<a href=all_inc_empwise_report.aspx?emp_code=" & dr(0) & "&prdate=" & "15/aug/1947" & "><font size=2>" & dr(0) & "</font></a>"
                    End If
                    d1.HorizontalAlign = HorizontalAlign.Left
                    drow.Controls.Add(d1)

                    dq.HorizontalAlign = HorizontalAlign.Left
                    dq.ColumnSpan = 2
                    dq.Text = "<font size=2>" & dr(1) & "&nbsp;</font>"
                    dq.HorizontalAlign = HorizontalAlign.Left
                    drow.Controls.Add(dq)

                    d2.ColumnSpan = 2
                    d2.Text = "<a><font size=2>" & dr(2) & "&nbsp;</font></a>"
                    d2.HorizontalAlign = HorizontalAlign.Left
                    drow.Controls.Add(d2)

                    d3.ColumnSpan = 1
                    d3.Text = "<a><font size=2>" & checknull(dr(3)) & "&nbsp;</font></a>"
                    d3.HorizontalAlign = HorizontalAlign.Right
                    drow.Controls.Add(d3)

                    total += checknull(dr(3))

                    tatable.Controls.Add(drow)
                Next

                Dim line4 As New TableRow
                Dim linecell4 As New TableCell
                linecell4.ColumnSpan = 6
                linecell4.Text = "<hr>"
                line4.Controls.Add(linecell4)
                tatable.Controls.Add(line4)

                ''==--=-==-=-=-=-=-=-=-=-=-=-==-=- Commented on 02Oct2010 because cash_gold table droped from main -=-==-=-===

                'If dt1.Rows.Count > 0 Then

                '    Dim cago As New TableRow
                '    cago.Width = 6
                '    Dim c1, cg1, cg2 As New TableCell



                '    cg1.ColumnSpan = 3
                '    cg1.HorizontalAlign = HorizontalAlign.Center
                '    If IsDBNull(dt1.Rows(0)(0)) Then
                '        cg1.Text = "<b><font size=2>Cash:&nbsp;&nbsp;0</font></b>"
                '    Else
                '        cg1.Text = "<b><font size=2>Cash:&nbsp;&nbsp;" & dt1.Rows(0)(0) & "</font></b>"
                '    End If
                '    cago.Controls.Add(cg1)

                '    cg2.ColumnSpan = 3
                '    cg2.HorizontalAlign = HorizontalAlign.Center
                '    If IsDBNull(dt1.Rows(0)(1)) Then
                '        cg2.Text = "<b><font size=2>Gold:&nbsp;&nbsp;0</font></b>"
                '    Else
                '        cg2.Text = "<b><font size=2>Gold:&nbsp;&nbsp;" & dt1.Rows(0)(1) & "</font></b>"
                '    End If
                '    cago.Controls.Add(cg2)

                '    tatable.Controls.Add(cago)

                'Else

                '    Dim cago As New TableRow
                '    cago.Width = 6
                '    Dim cg1, cg2 As New TableCell

                '    cg1.ColumnSpan = 3
                '    cg1.HorizontalAlign = HorizontalAlign.Center
                '    cg1.Text = "<b><font size=2>Cash:&nbsp;&nbsp;0</font></b>"
                '    cago.Controls.Add(cg1)

                '    cg2.ColumnSpan = 3
                '    cg2.HorizontalAlign = HorizontalAlign.Center
                '    cg2.Text = "<b><font size=2>Gold:&nbsp;&nbsp;0</font></b>"
                '    cago.Controls.Add(cg2)

                '    tatable.Controls.Add(cago)

                'End If

                'Dim last As New TableRow
                'Dim last1 As New TableCell
                'last1.ColumnSpan = 6
                'last1.Text = "<hr>"
                'last.Controls.Add(last1)
                'tatable.Controls.Add(last)
                '==--=-==-=-=-=-=-=-=-=-=-=-==-=- End of Commented on 02Oct2010 because cash_gold table droped from main -=-==-=-===

                Dim qlast As New TableRow
                qlast.Width = 6
                Dim q As New TableCell
                q.ColumnSpan = 6
                q.HorizontalAlign = HorizontalAlign.Left
                q.Text = "<font size=2>Total:&nbsp;<b>" & Me.i & "</b>&nbsp;Employee(s) and Sum of Total&nbsp;=&nbsp;<b>" & FormatNumber(Me.total, 2) & "</b>&nbsp;Rupees.<font>"
                qlast.Controls.Add(q)
                tatable.Controls.Add(qlast)

                If Me.Request.QueryString("key") = 2 Then
                    Dim warn As New TableRow
                    warn.Width = 6
                    Dim w1 As New TableCell
                    w1.ColumnSpan = 6
                    w1.HorizontalAlign = HorizontalAlign.Left
                    w1.Text = "<font size=1>* Excluding Resigned,Suspended,Terminated,Long Leave and Maternity Leave Employees.</font>"
                    warn.Controls.Add(w1)
                    tatable.Controls.Add(warn)
                End If
            Else
                Dim blank1 As New TableRow
                blank1.Width = 6
                Dim b11 As New TableCell
                b11.ColumnSpan = 6
                b11.HorizontalAlign = HorizontalAlign.Center
                b11.Text = "<b><font size=2>Not Processed..Please Check After Sometime !!</font></b>"
                blank1.Controls.Add(b11)
                tatable.Controls.Add(blank1)
            End If
        End If    '    end if of str="" checking!!

        Panel_First.Controls.Add(tatable)
    End Sub
End Class
