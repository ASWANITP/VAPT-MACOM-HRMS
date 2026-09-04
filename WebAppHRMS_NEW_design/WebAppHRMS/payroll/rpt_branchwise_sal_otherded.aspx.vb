Imports System.Data
Imports System.Data.OracleClient

Partial Class salary_consolidated_report_rpt_branchwise_sal_otherded_8a9b4e382487
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim tab1 As New Table
    Dim pageno As Integer = 0
    Dim recno As Integer = 10

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable = oh.ExecuteDataSet("select s.emp_code,e.emp_name,s.amount,s.reason,br.branch_name,br.branch_id from sal_ded S,employee_master e,salari sa,branch_master br,m_wage m where e.emp_type=" & Me.Request.QueryString("type") & " and e.emp_code=s.emp_code and s.emp_code=sa.emp_id and sa.branch_id=br.branch_id  and m.emp_code=s.emp_code and m.status_id=1 union select s.emp_code,e.emp_name,s.amount,s.reason,bc.branch_name,bc.old_id from sal_ded S,employee_master e,salari sa,before_completion bc,m_wage m where e.emp_code=s.emp_code and s.emp_code=sa.emp_id and sa.branch_id=bc.old_id and bc.branch_id is null and e.emp_type=" & Me.Request.QueryString("type") & " and m.emp_code=s.emp_code and m.status_id=1 order by branch_name,emp_code").Tables(0)

        tab1.Attributes.Add("width", "100%")
        ' tab1.Attributes.Add("border", 1)

        '''''''''''''''''''''''''''''''''''''''''''
        'data
        Dim dr As DataRow
        Dim count As Integer = 0
        Dim dedamt As Double = 0.0
        Dim femalest As Integer = 0
        Dim branch As String = ""
        If dt.Rows.Count > 0 Then

            For Each dr In dt.Rows
           
                If Not branch.Equals(dr(4)) Then

                    If branch <> "" Then
                        Dim tabl As New TableRow
                        tabl.Width = 8
                        Dim tabc As New TableCell
                        tabc.ColumnSpan = 8
                        tabc.Text = "<hr>"
                        tabl.Controls.Add(tabc)
                        tab1.Controls.Add(tabl)


                        Dim totrowa As New TableRow
                        totrowa.Width = 8
                        Dim totcell1a, totcell2a, totcell3a As New TableCell
                        totcell1a.ColumnSpan = 4
                        totcell2a.ColumnSpan = 2
                        totcell3a.ColumnSpan = 2
                        totcell1a.HorizontalAlign = HorizontalAlign.Right
                        totcell2a.HorizontalAlign = HorizontalAlign.Right
                        totcell3a.HorizontalAlign = HorizontalAlign.Right
                        totcell1a.Text = "<font size=2><b>Total : </b></font>"
                        totcell2a.Text = "<font size=2><b>" & FormatNumber(dedamt, 2) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></font>"
                        totcell3a.Text = " "
                        totrowa.Controls.Add(totcell1a)
                        totrowa.Controls.Add(totcell2a)
                        totrowa.Controls.Add(totcell3a)
                        tab1.Controls.Add(totrowa)

                        Dim tabr As New TableRow
                        tabr.Width = 8
                        Dim tabc11 As New TableCell
                        tabc11.ColumnSpan = 8
                        tabc11.Text = "<hr>"
                        tabr.Controls.Add(tabc11)
                        tab1.Controls.Add(tabr)

                        pagenext()
                    End If

                    dedamt = 0
                 
                    branch = dr(4)
                    count = 0

                    Dim tabr1 As New TableRow
                    tabr1.Width = 8
                    Dim tabc1 As New TableCell

                    tabc1.Text = "<body align=center color=red><b><font size=4>MANAPPURAM GROUP OF COMPANIES </font></b></body>"
                    tabc1.ColumnSpan = 8
                    ' tabc1.ForeColor = Drawing.Color.Red
                    tabr1.Controls.Add(tabc1)
                    tab1.Controls.Add(tabr1)


                    Dim tabrP As New TableRow
                    tabrP.Width = 8
                    Dim tabcP As New TableCell

                    tabcP.Text = "<body align=center color=red><b><font size=3>DEPARTMENT OF HUMAN RESOURCE AND MANAGEMENT </font></b></body>"
                    tabcP.ColumnSpan = 8
                    tabrP.Controls.Add(tabcP)
                    tab1.Controls.Add(tabrP)

                    '3RD ROW
                    Dim tabrr3 As New TableRow
                    tabrr3.Width = 8

                    'cell declaration
                    Dim tabcc3 As New TableCell
                    tabcc3.Attributes.Add("align", "left")
                    tabcc3.Text = "<b><font size=2.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
                    tabcc3.ColumnSpan = 2
                    tabrr3.Controls.Add(tabcc3)
                    tab1.Controls.Add(tabrr3)

                    Dim tabccc As New TableCell
                    tabccc.Attributes.Add("align", "center")
                    tabccc.Text = "<font size=2.5><b> EMPLOYEE WISE DEDUCTION REPORT </b></font>"
                    tabccc.ColumnSpan = 4
                    tabrr3.Controls.Add(tabccc)
                    tab1.Controls.Add(tabrr3)

                    'cell declaration
                    Dim tabcc4 As New TableCell
                    tabcc4.Attributes.Add("align", "right")

                    Dim dat As String
                    Dim hr As Integer = Date.Now.Hour
                    If hr > 12 Then
                        dat = "PM"
                    Else
                        dat = "AM"
                    End If
                    If (hr = 0) Then
                        hr = 12
                    End If

                    If (hr > 12) Then
                        hr = hr - 12
                    End If

                    tabcc4.Text = "<b><font size=2.5>TIME: " & hr.ToString & ":" & Date.Now.Minute & ":" & Date.Now.Second & " " & dat & "</font></b>"
                    tabcc4.ColumnSpan = 2
                    tabrr3.Controls.Add(tabcc4)
                    tab1.Controls.Add(tabrr3)

                    Dim tabline As New TableRow
                    tabline.Width = 8
                    Dim tabcellline As New TableCell
                    tabcellline.ColumnSpan = 8
                    tabcellline.Text = "<hr>"
                    tabline.Controls.Add(tabcellline)
                    tab1.Controls.Add(tabline)

                    '5th row

                    Dim tabr5 As New TableRow
                    tabr5.Width = 8
                    Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5 As New TableCell
                    tabr5c1.ColumnSpan = 1
                    tabr5c2.ColumnSpan = 1
                    tabr5c3.ColumnSpan = 2
                    tabr5c4.ColumnSpan = 1
                    tabr5c5.ColumnSpan = 3
                    tabr5c1.HorizontalAlign = HorizontalAlign.Center
                    tabr5c4.HorizontalAlign = HorizontalAlign.Center

                    tabr5c1.Text = "<font size=2.5><b>SI.NO</b></font>"
                    tabr5c2.Text = "<font size=2.5><b>EMP CODE</b></font>"
                    tabr5c3.Text = "<font size=2.5><b>EMP NAME</b></font>"
                    tabr5c4.Text = "<font size=2.5><b>DEDUCTION AMT</b></font>"
                    tabr5c5.Text = "<font size=2.5><b>REASON</b></font>"

                    tabr5.Controls.Add(tabr5c1)
                    tabr5.Controls.Add(tabr5c2)
                    tabr5.Controls.Add(tabr5c3)
                    tabr5.Controls.Add(tabr5c4)
                    tabr5.Controls.Add(tabr5c5)

                    tab1.Controls.Add(tabr5)

                    '''''''''''''''''''''''''''''''''''''''
                    Dim tabline1 As New TableRow
                    tabline1.Width = 8
                    Dim tabcellline1 As New TableCell
                    tabcellline1.ColumnSpan = 8
                    tabcellline1.Text = "<hr>"
                    tabline1.Controls.Add(tabcellline1)
                    tab1.Controls.Add(tabline1)


                    Dim tabli As New TableRow
                    tabli.Width = 8
                    Dim tabce As New TableCell
                    tabce.ColumnSpan = 8
                    tabce.HorizontalAlign = HorizontalAlign.Left
                    tabce.Text = "<font size=2.5><u>" & branch & "</u></font>"
                    tabli.Controls.Add(tabce)
                    tab1.Controls.Add(tabli)
                End If
                Dim tabr6 As New TableRow
                tabr6.Width = 8
                Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5 As New TableCell
                tabr6c1.ColumnSpan = 1
                tabr6c2.ColumnSpan = 1
                tabr6c3.ColumnSpan = 2
                tabr6c4.ColumnSpan = 1
                tabr6c5.ColumnSpan = 3

                count += 1
                tabr6c1.Attributes.Add("align", "center")
                tabr6c2.Attributes.Add("align", "left")
                tabr6c3.Attributes.Add("align", "left")
                tabr6c4.Attributes.Add("align", "right")
                tabr6c5.Attributes.Add("align", "left")


                tabr6c1.Text = "<font size=2>" & count & "&nbsp;&nbsp;</font>"
                tabr6c2.Text = "<font size=2>" & dr(0) & "&nbsp;</font>"
                tabr6c3.Text = "<font size=2>" & dr(1) & "</font>"
                tabr6c4.Text = "<font size=2>" & FormatNumber(dr(2), 2) & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
                dedamt += dr(2)
                tabr6c5.Text = "<font size=2>" & dr(3) & "&nbsp;</font>"

                tabr6.Controls.Add(tabr6c1)
                tabr6.Controls.Add(tabr6c2)
                tabr6.Controls.Add(tabr6c3)
                tabr6.Controls.Add(tabr6c4)
                tabr6.Controls.Add(tabr6c5)

                tab1.Controls.Add(tabr6)



            Next
            Dim tabline23 As New TableRow
            tabline23.Width = 8
            Dim tabcellline233 As New TableCell
            tabcellline233.ColumnSpan = 8
            tabcellline233.Text = "<hr>"
            tabline23.Controls.Add(tabcellline233)
            tab1.Controls.Add(tabline23)


            Dim totrow As New TableRow
            totrow.Width = 8
            Dim totcell1, totcell2, totcell3 As New TableCell
            totcell1.ColumnSpan = 4
            totcell2.ColumnSpan = 2
            totcell3.ColumnSpan = 2
            totcell1.HorizontalAlign = HorizontalAlign.Right
            totcell2.HorizontalAlign = HorizontalAlign.Right
            totcell3.HorizontalAlign = HorizontalAlign.Right
            totcell1.Text = "<font size=2><b>Total : </b></font>"
            totcell2.Text = "<font size=2><b>" & FormatNumber(dedamt, 2) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></font>"
            totcell3.Text = " "
            totrow.Controls.Add(totcell1)
            totrow.Controls.Add(totcell2)
            totrow.Controls.Add(totcell3)
            tab1.Controls.Add(totrow)

            Dim tabline231 As New TableRow
            tabline231.Width = 8
            Dim tabcellline231 As New TableCell
            tabcellline231.ColumnSpan = 8
            tabcellline231.Text = "<hr>"
            tabline231.Controls.Add(tabcellline231)
            tab1.Controls.Add(tabline231)

        End If





        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''resigned
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim dt1 As DataTable = oh.ExecuteDataSet("select s.emp_code,e.emp_name,s.amount,s.reason,br.branch_name,br.branch_id from sal_ded S,employee_master e,salari sa,branch_master br,m_wage m where e.emp_code=s.emp_code and s.emp_code=sa.emp_id and sa.branch_id=br.branch_id  and m.emp_code=s.emp_code and m.status_id<>1 union select s.emp_code,e.emp_name,s.amount,s.reason,bc.branch_name,bc.old_id from sal_ded S,employee_master e,salari sa,before_completion bc,m_wage m where e.emp_code=s.emp_code and s.emp_code=sa.emp_id and sa.branch_id=bc.old_id and bc.branch_id is null and m.emp_code=s.emp_code and m.status_id<>1 union select s2.emp_code,e1.emp_name,s2.amount,s2.reason,'A.O.VALAPAD',0 from sal_ded s2,employee_master e1 where s2.emp_code=e1.emp_code and s2.emp_code not in(select ss.emp_id from salari ss)").Tables(0)
        If dt1.Rows.Count = 0 Then
            Me.Panel1.Controls.Add(tab1)
            Exit Sub
        Else
            pagenext()
            Dim tabr1 As New TableRow
            tabr1.Width = 8
            'tabr1.Attributes.Add("bgcolor", "gold")
            ' tabr1.Attributes.Add("bordercolor", "red")
            Dim tabc1 As New TableCell

            tabc1.Text = "<body align=center color=red><b><font size=4>MANAPPURAM GROUP OF COMPANIES </font></b></body>"
            tabc1.ColumnSpan = 8
            ' tabc1.ForeColor = Drawing.Color.Red
            tabr1.Controls.Add(tabc1)
            tab1.Controls.Add(tabr1)


            Dim tabrP As New TableRow
            tabrP.Width = 8
            ' tabrP.Attributes.Add("bgcolor", "gold")
            ' tabrP.Attributes.Add("bordercolor", "red")
            Dim tabcP As New TableCell

            tabcP.Text = "<body align=center color=red><b><font size=3>DEPARTMENT OF HUMAN RESOURCE AND MANAGEMENT </font></b></body>"
            tabcP.ColumnSpan = 8
            '   tabcP.ForeColor = Drawing.Color.Red
            tabrP.Controls.Add(tabcP)
            tab1.Controls.Add(tabrP)

            '3RD ROW
            Dim tabrr3 As New TableRow
            tabrr3.Width = 8
            '  tabrr3.Attributes.Add("bgcolor", "#ffcca3")

            'cell declaration
            Dim tabcc3 As New TableCell
            '  tabcc3.ForeColor = Drawing.Color.Maroon
            tabcc3.Attributes.Add("align", "left")
            tabcc3.Text = "<b><font size=2.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
            tabcc3.ColumnSpan = 2
            tabrr3.Controls.Add(tabcc3)
            tab1.Controls.Add(tabrr3)

            Dim tabccc As New TableCell
            ' tabccc.ForeColor = Drawing.Color.Maroon
            tabccc.Attributes.Add("align", "left")
            tabccc.Text = "<body align=center><b> EMPLOYEE WISE DEDUCTION REPORT </b></body>"
            tabccc.ColumnSpan = 4
            tabrr3.Controls.Add(tabccc)
            tab1.Controls.Add(tabrr3)

            'cell declaration
            Dim tabcc4 As New TableCell
            '   tabcc4.ForeColor = Drawing.Color.Maroon

            tabcc4.Attributes.Add("align", "right")

            Dim dat As String
            Dim hr As Integer = Date.Now.Hour
            If hr > 12 Then
                dat = "PM"
            Else
                dat = "AM"
            End If
            If (hr = 0) Then
                hr = 12
            End If

            If (hr > 12) Then
                hr = hr - 12
            End If

            tabcc4.Text = "<b><font size=2.5>TIME: " & hr.ToString & ":" & Date.Now.Minute & ":" & Date.Now.Second & " " & dat & "</font></b>"
            tabcc4.ColumnSpan = 2
            tabrr3.Controls.Add(tabcc4)
            tab1.Controls.Add(tabrr3)

            Dim tabline As New TableRow
            tabline.Width = 8
            Dim tabcellline As New TableCell
            tabcellline.ColumnSpan = 8
            tabcellline.Text = "<hr>"
            tabline.Controls.Add(tabcellline)
            tab1.Controls.Add(tabline)

            '5th row

            Dim tabr5 As New TableRow
            tabr5.Width = 8
            ' tabr5.ForeColor = Drawing.Color.DarkSlateGray
            Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5 As New TableCell
            tabr5c1.ColumnSpan = 1
            tabr5c2.ColumnSpan = 1
            tabr5c3.ColumnSpan = 2
            tabr5c4.ColumnSpan = 1
            tabr5c5.ColumnSpan = 3
            tabr5c1.HorizontalAlign = HorizontalAlign.Center
            tabr5c4.HorizontalAlign = HorizontalAlign.Center

            tabr5c1.Text = "<font size=2.5><b>SI.NO</b></font>"
            tabr5c2.Text = "<font size=2.5><b>EMP CODE</b></font>"
            tabr5c3.Text = "<font size=2.5><b>EMP NAME</b></font>"
            tabr5c4.Text = "<font size=2.5><b>DEDUCTION AMT</b></font>"
            tabr5c5.Text = "<font size=2.5><b>REASON</b></font>"

            tabr5.Controls.Add(tabr5c1)
            tabr5.Controls.Add(tabr5c2)
            tabr5.Controls.Add(tabr5c3)
            tabr5.Controls.Add(tabr5c4)
            tabr5.Controls.Add(tabr5c5)

            tab1.Controls.Add(tabr5)

            '''''''''''''''''''''''''''''''''''''''
            Dim tabline1 As New TableRow
            tabline1.Width = 8
            Dim tabcellline1 As New TableCell
            tabcellline1.ColumnSpan = 8
            tabcellline1.Text = "<hr>"
            tabline1.Controls.Add(tabcellline1)
            tab1.Controls.Add(tabline1)


            Dim tabli As New TableRow
            tabli.Width = 8
            Dim tabce As New TableCell
            tabce.ColumnSpan = 8
            tabce.HorizontalAlign = HorizontalAlign.Left
            tabce.Text = "<font size=2.5><u>A.O.VALAPPAD - Resigned</u></font>"
            tabli.Controls.Add(tabce)
            tab1.Controls.Add(tabli)

        End If

        Dim dr1 As DataRow
        Dim count1 As Integer = 0
        Dim dedamt1 As Double = 0.0

        For Each dr1 In dt1.Rows
            count1 += 1
            Dim tabr6 As New TableRow
            tabr6.Width = 8
            Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5 As New TableCell
            tabr6c1.ColumnSpan = 1
            tabr6c2.ColumnSpan = 1
            tabr6c3.ColumnSpan = 2
            tabr6c4.ColumnSpan = 1
            tabr6c5.ColumnSpan = 3


            tabr6c1.Attributes.Add("align", "center")
            tabr6c2.Attributes.Add("align", "left")
            tabr6c3.Attributes.Add("align", "left")
            tabr6c4.Attributes.Add("align", "right")
            tabr6c5.Attributes.Add("align", "left")


            tabr6c1.Text = "<font size=2>" & count1 & "&nbsp;&nbsp;</font>"
            tabr6c2.Text = "<font size=2>" & dr1(0) & "&nbsp;</font>"
            tabr6c3.Text = "<font size=2>" & dr1(1) & "</font>"
            tabr6c4.Text = "<font size=2>" & FormatNumber(dr1(2), 2) & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            dedamt1 += dr1(2)
            tabr6c5.Text = "<font size=2>" & dr1(3) & "&nbsp;</font>"

            tabr6.Controls.Add(tabr6c1)
            tabr6.Controls.Add(tabr6c2)
            tabr6.Controls.Add(tabr6c3)
            tabr6.Controls.Add(tabr6c4)
            tabr6.Controls.Add(tabr6c5)

            tab1.Controls.Add(tabr6)



        Next
        Dim tabline23r As New TableRow
        tabline23r.Width = 8
        Dim tabcellline233r As New TableCell
        tabcellline233r.ColumnSpan = 8
        tabcellline233r.Text = "<hr>"
        tabline23r.Controls.Add(tabcellline233r)
        tab1.Controls.Add(tabline23r)


        Dim totrowr As New TableRow
        totrowr.Width = 8
        Dim totcell1r, totcell2r, totcell3r As New TableCell
        totcell1r.ColumnSpan = 4
        totcell2r.ColumnSpan = 2
        totcell3r.ColumnSpan = 2
        totcell1r.HorizontalAlign = HorizontalAlign.Right
        totcell2r.HorizontalAlign = HorizontalAlign.Right
        totcell3r.HorizontalAlign = HorizontalAlign.Right
        totcell1r.Text = "<font size=2><b>Total : </b></font>"
        totcell2r.Text = "<font size=2><b>" & FormatNumber(dedamt1, 2) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></font>"
        totcell3r.Text = " "
        totrowr.Controls.Add(totcell1r)
        totrowr.Controls.Add(totcell2r)
        totrowr.Controls.Add(totcell3r)
        tab1.Controls.Add(totrowr)

        Dim tabline231r As New TableRow
        tabline231r.Width = 8
        Dim tabcellline231r As New TableCell
        tabcellline231r.ColumnSpan = 8
        tabcellline231r.Text = "<hr>"
        tabline231r.Controls.Add(tabcellline231r)
        tab1.Controls.Add(tabline231r)

        Me.Panel1.Controls.Add(tab1)

    End Sub

    Sub pagenext()


        Dim pgebrk As New TableRow
        pgebrk.Width = 8
        Dim pgebrk1 As New TableCell
        pgebrk1.ColumnSpan = 8
        pgebrk1.HorizontalAlign = HorizontalAlign.Center
        pgebrk1.Text = "<p style=page-break-after:always></DIV>"
        pgebrk.Controls.Add(pgebrk1)
        tab1.Controls.Add(pgebrk)

        'Dim pgeno As New TableRow
        'pgeno.Width = 8
        'Dim pgeno1 As New TableCell
        'pgeno1.ColumnSpan = 8
        'pgeno1.HorizontalAlign = HorizontalAlign.Right
        'pageno += 1
        'pgeno1.Text = "<font size=2><b> Page :" & pageno & " </b></font>"
        'pgeno.Controls.Add(pgeno1)
        'tab1.Controls.Add(pgeno)

    End Sub
End Class
