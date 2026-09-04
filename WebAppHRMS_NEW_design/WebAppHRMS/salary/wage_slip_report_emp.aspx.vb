Imports System.Data
Imports system.data.oracleclient
Partial Class salaryreport_wage_slip_report_emp_ae077ab83088
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    ' Dim b As Integer
    Dim tb As New Table

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

       

        dt = Session("resulttable")

        Dim dr As DataRow

        For Each dr In dt.Rows


            tb.Attributes.Add("width", "90%")
            tb.Attributes.Add("align", "center")

            Dim tr As New TableRow
            Dim tc As New TableCell
            tr.Font.Size = 10
            tc.Attributes.Add("width", "100%")
            tc.ColumnSpan = 10
            tc.HorizontalAlign = HorizontalAlign.Center

            tc.Text = "<font size=3 color=darkblue><b>FORM XIII</b></font>"   'firm_name
            tr.Controls.Add(tc)
            tb.Controls.Add(tr)


            Dim tra As New TableRow
            tra.Font.Size = 10
            Dim tca As New TableCell
            tca.Attributes.Add("width", "100%")
            tca.ColumnSpan = 10
            tca.HorizontalAlign = HorizontalAlign.Center
            tca.Text = "<font size=2 color=darkblue><b></b></font>"   'firm_name
            tra.Controls.Add(tca)
            tb.Controls.Add(tra)

            Dim tr1 As New TableRow
            tr1.Font.Size = 10
            Dim tc1 As New TableCell
            tc1.Attributes.Add("width", "100%")
            tc1.ColumnSpan = 10
            tc1.HorizontalAlign = HorizontalAlign.Center
            tc1.Text = "<font size=2 color=darkblue>WAGE SLIP [SEE RULE 29(2)]</font>"
            tr1.Controls.Add(tc1)
            tb.Controls.Add(tr1)

            Dim tr2 As New TableRow
            Dim tc2 As New TableCell
            tr2.Font.Size = 10
            tc2.Attributes.Add("width", "100%")
            tc2.ColumnSpan = 10
            tc2.HorizontalAlign = HorizontalAlign.Right
            tc2.Text = "<font size=2 color=darkblue>PLACE&nbsp;:" & dr(13) & "</font>"
            tr2.Controls.Add(tc2)
            tb.Controls.Add(tr2)


            Dim tr3 As New TableRow
            Dim tc31 As New TableCell
            tr3.Font.Size = 10
            tc31.Attributes.Add("width", "50%")
            tc31.ColumnSpan = 3
            tc31.HorizontalAlign = HorizontalAlign.Left
            tc31.Text = "<font size=2 color=darkblue>Time&nbsp:" & Format(Date.Now, "hh:mm:ss") & "</font>"
            tr3.Controls.Add(tc31)
            Dim tc4 As New TableCell
            tc4.Attributes.Add("width", "25%")
            tc4.ColumnSpan = 4
            tc4.HorizontalAlign = HorizontalAlign.Center
            tc4.Text = "<font size=2 color=darkblue><b>WAGE&nbsp;SLIP&nbsp;</b></font>"
            tr3.Controls.Add(tc4)
            Dim tc32 As New TableCell
            tc32.Attributes.Add("width", "50%")
            tc32.ColumnSpan = 3
            tc32.HorizontalAlign = HorizontalAlign.Right
            tc32.Text = "<font size=2 color=darkblue>Date&nbsp:" & Format(Date.Now, "dd/MMM/yyyy") & "</font>"
            tr3.Controls.Add(tc32)
            tb.Controls.Add(tr3)

            ' Dim tr4 As New TableRow
            'tr4.Font.Size = 10

            ' tb.Controls.Add(tr4)



            Dim tr5a As New TableRow
            tr5a.Font.Size = 10
            Dim td5a As New TableCell
            td5a.ColumnSpan = 12
            td5a.HorizontalAlign = HorizontalAlign.Center
            td5a.Text = "<hr>"
            tr5a.Controls.Add(td5a)
            tb.Controls.Add(tr5a)

            Dim tr5 As New TableRow
            Dim tc51 As New TableCell
            tr5.Font.Size = 11
            tc51.Attributes.Add("width", "50%")
            tc51.ColumnSpan = 3
            tc51.HorizontalAlign = HorizontalAlign.Left
            tc51.Text = "<font size=2 color=darkblue>NAME OF THE ESTABLISHMENT&nbsp</font>"
            tr5.Controls.Add(tc51)


            Dim tc52a As New TableCell
            tc52a.Attributes.Add("width", "5%")
            tc52a.ColumnSpan = 1
            tc52a.HorizontalAlign = HorizontalAlign.Left
            tc52a.Text = "<font size=2 color=darkblue>-</font>"
            tr5.Controls.Add(tc52a)

            Dim tc52 As New TableCell
            tc52.Attributes.Add("width", "70%")
            tc52.ColumnSpan = 10
            tc52.HorizontalAlign = HorizontalAlign.Left

            tc52.Text = "<font size=2 color=darkblue>" & dr(0) & "</font>"
            tr5.Controls.Add(tc52)
            tb.Controls.Add(tr5)


            Dim tr6 As New TableRow
            Dim tc61 As New TableCell
            tr6.Font.Size = 10
            tc61.Attributes.Add("width", "50%")
            tc61.ColumnSpan = 3
            tc61.HorizontalAlign = HorizontalAlign.Left
            tc61.Text = "<font size=2 color=darkblue>NAME OF EMPLOYEE&nbsp;</font>"
            tr6.Controls.Add(tc61)


            Dim tc62a As New TableCell
            tc62a.Attributes.Add("width", "5%")
            tc62a.HorizontalAlign = HorizontalAlign.Left
            tc62a.Text = "<font size=2 color=darkblue>-</font>"
            tr6.Controls.Add(tc62a)


            Dim tc62 As New TableCell
            tc62.Attributes.Add("width", "70%")
            tc62.ColumnSpan = 7
            tc62.HorizontalAlign = HorizontalAlign.Left
            tc62.Text = "<font size=2 color=darkblue>" & dr(1) & "</font>"
            tr6.Controls.Add(tc62)
            tb.Controls.Add(tr6)


            Dim tr5d As New TableRow
            Dim tc51d As New TableCell
            tr5d.Font.Size = 10
            tc51d.Attributes.Add("width", "50%")
            tc51d.ColumnSpan = 3
            tc51d.HorizontalAlign = HorizontalAlign.Left
            tc51d.Text = "<font size=2 color=darkblue>FATHER'S NAME&nbsp;</font>"
            tr5d.Controls.Add(tc51d)

            Dim tc52g As New TableCell
            tc52g.Attributes.Add("width", "5%")

            tc52g.HorizontalAlign = HorizontalAlign.Left
            tc52g.Text = "<font size=2 color=darkblue>-</font>"
            tr5d.Controls.Add(tc52g)


            Dim tc52h As New TableCell
            tc52h.Attributes.Add("width", "70%")
            tc52h.ColumnSpan = 7
            tc52h.HorizontalAlign = HorizontalAlign.Left
            tc52h.Text = "<font size=2 color=darkblue>" & dr(2) & "</font>"
            tr5d.Controls.Add(tc52h)
            tb.Controls.Add(tr5d)



            Dim tr6d As New TableRow
            tr6d.Font.Size = 10
            Dim tc6d As New TableCell
            tc6d.Attributes.Add("width", "50%")
            tc6d.ColumnSpan = 3
            tc6d.HorizontalAlign = HorizontalAlign.Left
            tc6d.Text = "<font size=2 color=darkblue>DESIGNATION&nbsp;</font>"
            tr6d.Controls.Add(tc6d)

            Dim tc6e As New TableCell
            tc6e.Attributes.Add("width", "5%")
            tc6e.HorizontalAlign = HorizontalAlign.Left
            tc6e.Text = "<font size=2 color=darkblue>-</font>"
            tr6d.Controls.Add(tc6e)

            Dim tc6f As New TableCell
            tc6f.Attributes.Add("width", "70%")
            tc6f.ColumnSpan = 7
            tc6f.HorizontalAlign = HorizontalAlign.Left
            tc6f.Text = "<font size=2 color=darkblue>" & dr(3) & "</font>"
            tr6d.Controls.Add(tc6f)
            tb.Controls.Add(tr6d)

            Dim tr7d As New TableRow
            Dim tc7d As New TableCell
            tr7d.Font.Size = 10
            tc7d.Attributes.Add("width", "50%")
            tc7d.ColumnSpan = 3
            tc7d.HorizontalAlign = HorizontalAlign.Left
            tc7d.Text = "<font size=2 color=darkblue>WAGE PERIOD&nbsp;</font>"
            tr7d.Controls.Add(tc7d)

            Dim tc7e As New TableCell
            tc7e.Attributes.Add("width", "5%")
            tc7e.HorizontalAlign = HorizontalAlign.Left
            tc7e.Text = "<font size=2 color=darkblue>-</font>"
            tr7d.Controls.Add(tc7e)

            Dim tc7f As New TableCell
            tc7f.Attributes.Add("width", "70%")
            tc7f.ColumnSpan = 7
            tc7f.HorizontalAlign = HorizontalAlign.Left
            tc7f.Text = "<font size=2 color=darkblue>" & dr(4) & " to " & dr(5) & "</font>"
            tr7d.Controls.Add(tc7f)
            tb.Controls.Add(tr7d)

            Dim cn As String = dr(4).ToString()


            Dim tr8d1 As New TableRow
            Dim tc8d1 As New TableCell
            tr8d1.Font.Size = 10
            tc8d1.Attributes.Add("width", "100%")
            tc8d1.ColumnSpan = 11
            tc8d1.HorizontalAlign = HorizontalAlign.Left
            tc8d1.Text = "<font size=2 color=darkblue><u>TOTAL ATTENDANCE</u>&nbsp;</font>"
            tr8d1.Controls.Add(tc8d1)
            tb.Controls.Add(tr8d1)

            Dim tr8d As New TableRow
            Dim tc8d As New TableCell
            tr8d.Font.Size = 10
            tc8d.Attributes.Add("width", "50%")
            tc8d.ColumnSpan = 3
            tc8d.HorizontalAlign = HorizontalAlign.Left
            tc8d.Text = "<font size=2 color=darkblue>UNITS OF WORK DONE&nbsp;</font>"
            tr8d.Controls.Add(tc8d)



            Dim tc8e As New TableCell
            tc8e.Attributes.Add("width", "5%")
            tc8e.HorizontalAlign = HorizontalAlign.Left
            tc8e.Text = "<font size=2 color=darkblue>-</font>"
            tr8d.Controls.Add(tc8e)

            Dim tc8f As New TableCell
            tc8f.Attributes.Add("width", "70%")
            tc8f.ColumnSpan = 7
            tc8f.HorizontalAlign = HorizontalAlign.Left
            tc8f.Text = "<font size=2 color=darkblue>" & dr(6) & "</font>"
            tr8d.Controls.Add(tc8f)
            tb.Controls.Add(tr8d)


            Dim tr8d2 As New TableRow
            Dim tc8d2 As New TableCell
            tr8d2.Font.Size = 10
            tc8d2.Attributes.Add("width", "100%")
            tc8d2.ColumnSpan = 11
            tc8d2.HorizontalAlign = HorizontalAlign.Left
            tc8d2.Text = "<font size=2 color=darkblue><u>RATE OF WAGE PAYABLE:</u>&nbsp;</font>"
            tr8d2.Controls.Add(tc8d2)
            tb.Controls.Add(tr8d2)



            Dim tr9d As New TableRow
            tr9d.Font.Size = 10
            Dim tc9d As New TableCell
            tc9d.Attributes.Add("width", "50%")
            tc9d.ColumnSpan = 3
            tc9d.HorizontalAlign = HorizontalAlign.Left
            tc9d.Text = "<font size=2 color=darkblue>a)&nbsp;BASIC WAGE&nbsp;</font>"
            tr9d.Controls.Add(tc9d)

            Dim tc9e As New TableCell
            tc9e.Attributes.Add("width", "5%")
            tc9e.HorizontalAlign = HorizontalAlign.Left
            tc9e.Text = "<font size=2 color=darkblue>-</font>"
            tr9d.Controls.Add(tc9e)

            Dim tc9f As New TableCell
            tc9f.Attributes.Add("width", "70%")
            tc9f.ColumnSpan = 7
            tc9f.HorizontalAlign = HorizontalAlign.Left
            tc9f.Text = "<font size=2 color=darkblue>" & dr(7) & " </font>"
            tr9d.Controls.Add(tc9f)
            tb.Controls.Add(tr9d)

            Dim tr10d As New TableRow
            Dim tc10d As New TableCell
            tr10d.Font.Size = 10
            tc10d.Attributes.Add("width", "50%")
            tc10d.ColumnSpan = 3
            tc10d.HorizontalAlign = HorizontalAlign.Left
            tc10d.Text = "<font size=2 color=darkblue>b)&nbsp;D.A&nbsp;</font>"
            tr10d.Controls.Add(tc10d)

            Dim tc10e As New TableCell
            tc10e.Attributes.Add("width", "5%")
            tc10e.HorizontalAlign = HorizontalAlign.Left
            tc10e.Text = "<font size=2 color=darkblue>-</font>"
            tr10d.Controls.Add(tc10e)

            Dim tc10f As New TableCell
            tc10f.Attributes.Add("width", "70%")
            tc10f.ColumnSpan = 7
            tc10f.HorizontalAlign = HorizontalAlign.Left
            tc10f.Text = "<font size=2 color=darkblue>" & dr(8) & " </font>"
            tr10d.Controls.Add(tc10f)
            tb.Controls.Add(tr10d)


            Dim tr15d As New TableRow
            Dim tc15d As New TableCell
            tr15d.Font.Size = 10
            tc15d.Attributes.Add("width", "50%")
            tc15d.ColumnSpan = 3
            tc15d.HorizontalAlign = HorizontalAlign.Left
            tc15d.Text = "<font size=2 color=darkblue>OVERTIME WAGE&nbsp;</font>"
            tr15d.Controls.Add(tc15d)

            Dim tc15e As New TableCell
            tc15e.Attributes.Add("width", "5%")
            tc15e.HorizontalAlign = HorizontalAlign.Left
            tc15e.Text = "<font size=2 color=darkblue>-</font>"
            tr15d.Controls.Add(tc15e)

            Dim tc15f As New TableCell
            tc15f.Attributes.Add("width", "70%")
            tc15f.ColumnSpan = 7
            tc15f.HorizontalAlign = HorizontalAlign.Left
            tc15f.Text = "<font size=2 color=darkblue>" & dr(9) & " </font>"
            tr15d.Controls.Add(tc15f)
            tb.Controls.Add(tr15d)


            Dim tr16d As New TableRow
            Dim tc16d As New TableCell
            tr16d.Font.Size = 10
            tc16d.Attributes.Add("width", "50%")
            tc16d.ColumnSpan = 3
            tc16d.HorizontalAlign = HorizontalAlign.Left
            tc16d.Text = "<font size=2 color=darkblue>GROSS WAGES PAYABLE&nbsp;</font>"
            tr16d.Controls.Add(tc16d)

            Dim tc16e As New TableCell
            tc16e.Attributes.Add("width", "5%")
            tc16e.HorizontalAlign = HorizontalAlign.Left
            tc16e.Text = "<font size=2 color=darkblue>-</font>"
            tr16d.Controls.Add(tc16e)


            Dim tc16f As New TableCell
            tc16f.Attributes.Add("width", "70%")
            tc16f.ColumnSpan = 7
            tc16f.HorizontalAlign = HorizontalAlign.Left
            tc16f.Text = "<font size=2 color=darkblue>" & dr(10) & "  </font>"
            tr16d.Controls.Add(tc16f)
            tb.Controls.Add(tr16d)


            Dim tr16d1 As New TableRow
            Dim tc16d1 As New TableCell
            tr16d1.Font.Size = 10
            tc16d1.Attributes.Add("width", "50%")
            tc16d1.ColumnSpan = 3
            tc16d1.HorizontalAlign = HorizontalAlign.Left
            tc16d1.Text = "<font size=2 color=darkblue>TOTAL DEDUCTIONS&nbsp;</font>"
            tr16d1.Controls.Add(tc16d1)

            Dim tc16e1 As New TableCell
            tc16e1.Attributes.Add("width", "5%")
            tc16e1.HorizontalAlign = HorizontalAlign.Left
            tc16e1.Text = "<font size=2 color=darkblue>-</font>"
            tr16d1.Controls.Add(tc16e1)


            Dim tc16f1 As New TableCell
            tc16f1.Attributes.Add("width", "70%")
            tc16f1.ColumnSpan = 7
            tc16f1.HorizontalAlign = HorizontalAlign.Left
            tc16f1.Text = "<font size=2 color=darkblue>" & dr(11) & "  </font>"
            tr16d1.Controls.Add(tc16f1)
            tb.Controls.Add(tr16d1)



            Dim tr16d2 As New TableRow
            Dim tc16d2 As New TableCell
            tr16d2.Font.Size = 10
            tc16d2.Attributes.Add("width", "50%")
            tc16d2.ColumnSpan = 3
            tc16d2.HorizontalAlign = HorizontalAlign.Left
            tc16d2.Text = "<font size=2 color=darkblue>NET WAGES PAID&nbsp;</font>"
            tr16d2.Controls.Add(tc16d2)

            Dim tc16e2 As New TableCell
            tc16e2.Attributes.Add("width", "5%")
            tc16e2.HorizontalAlign = HorizontalAlign.Left
            tc16e2.Text = "<font size=2 color=darkblue>-</font>"
            tr16d2.Controls.Add(tc16e2)


            Dim tc16f2 As New TableCell
            tc16f2.Attributes.Add("width", "70%")
            tc16f2.ColumnSpan = 7
            tc16f2.HorizontalAlign = HorizontalAlign.Left
            tc16f2.Text = "<font size=2 color=darkblue>" & dr(12) & "  </font>"
            tr16d2.Controls.Add(tc16f2)
            tb.Controls.Add(tr16d2)




            Dim tr16d3 As New TableRow
            tr16d3.Width = 10
            Dim tc16d3 As New TableCell
            tr16d3.Font.Size = 10
            tc16d3.Attributes.Add("width", "50%")
            tc16d3.ColumnSpan = 3
            tc16d3.HorizontalAlign = HorizontalAlign.Left
            tc16d3.Text = "<font size=2 color=darkblue><BR><BR><I>PAY-IN-CHARGE&nbsp;(SIGNATURE)</I></</font>"
            tr16d3.Controls.Add(tc16d3)

            Dim tc16e3 As New TableCell
            tc16e3.Attributes.Add("width", "5%")
            tc16e3.HorizontalAlign = HorizontalAlign.Center
            tc16e3.Text = ""
            tr16d3.Controls.Add(tc16e3)

            Dim tc16f3 As New TableCell
            tc16f3.Attributes.Add("width", "70%")
            tc16f3.ColumnSpan = 7
            tc16f3.HorizontalAlign = HorizontalAlign.Right
            tc16f3.Text = "<font size=2 color=darkblue><BR><BR><I>EMPLOYEE'S&nbsp;SIGNATURE   / THUMB-IMPRESSION </I></font>"
            tr16d3.Controls.Add(tc16f3)
            tb.Controls.Add(tr16d3)

            Dim t17d As New TableRow
            Dim qq17d As New TableCell
            t17d.Font.Size = 10
            qq17d.Attributes.Add("width", "125%")
            qq17d.ColumnSpan = 10
            qq17d.HorizontalAlign = HorizontalAlign.Left
            qq17d.Text = "************************************************************************************************<BR> "
            t17d.Controls.Add(qq17d)
            tb.Controls.Add(t17d)
            pagenext()
        Next
        Me.Panel1.Controls.Add(tb)
        '''''''''''''''''''''''''''''''''''''''''''''



    End Sub
    Sub pagenext()


        Dim pgebrk As New TableRow
        pgebrk.Width = 23
        Dim pgebrk1 As New TableCell
        pgebrk1.ColumnSpan = 23
        pgebrk1.HorizontalAlign = HorizontalAlign.Center
        pgebrk1.Text = "<DIV style=page-break-after:always></DIV>"
        pgebrk.Controls.Add(pgebrk1)
        tb.Controls.Add(pgebrk)
    End Sub
   

End Class
