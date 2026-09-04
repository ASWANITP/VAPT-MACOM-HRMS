Imports System.Data
Imports System.Data.OracleClient
Partial Class Resigned_Employees_rpt_resigned_emp_8094a4b23815
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim sql As String = "select * from resignedemp where discont_dt>=to_date('" & Me.Request.QueryString("fromdt") & "') and discont_dt<=to_date('" & Me.Request.QueryString("todt") & "')"
        Dim sql As String = "select t.*  from resignedemp t,employ_firm ef  where t.discont_dt >= to_date('" & Me.Request.QueryString("fromdt") & "')  and t.discont_dt <= to_date('" & Me.Request.QueryString("todt") & "')  and t.ecode=ef.emp_code  and ef.firm_id=" & Session("firm_id") & " "
        Dim dt As DataTable = oh.ExecuteDataSet(sql).Tables(0)
        'table declaration
        Dim tab1 As New Table
        tab1.Attributes.Add("width", "100%")
        '1st row declaration
        Dim tabr1 As New TableRow
        tabr1.Width = 33
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.Attributes.Add("bordercolor", "red")
        'cell declaration
        Dim tabc1 As New TableCell
        tabc1.Attributes.Add("forecolor", "blue")
        tabc1.Attributes.Add("align", "center")
        tabc1.ColumnSpan = "33"
        ' tabc1.Text = "<body align=center ><b><font size=4>MANAPPURAM GROUP OF COMPANIES</font></b></body>"
        tabc1.Text = "<body align=center ><b><font size=4>" & Me.Session("firm_name") & "  </font></b></body>"

        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab1.Controls.Add(tabr1)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Width = 33
        'cell declaration
        Dim tabc2 As New TableCell
        tabc2.ColumnSpan = 33
        tabc2.Attributes.Add("align", "center")
        tabc2.Text = "<body align=center color=red><b><font size=3.5> RESIGNED EMPLOYEE REPORT </font></b></body>"

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
        tabcct.ColumnSpan = 19
        tabcct.Attributes.Add("align", "left")
        tabcct.Text = ""
        tabcct.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcct)
        tab1.Controls.Add(tabrr3)


        'cell declaration
        Dim tabcc4 As New TableCell
        tabcc4.ColumnSpan = 7
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

        tabcc4.Text = "<b><font size=3.5>TIME: " & hr.ToString & ":" & Date.Now.Minute & ":" & Date.Now.Second & " " & dat & "</font></b>"
        tabcc4.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc4)
        tab1.Controls.Add(tabrr3)

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabline As New TableRow
        tabline.Width = 33
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 33
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab1.Controls.Add(tabline)
        ''''''''''''''''''''''''''''''''''''''''
        Dim tabr5 As New TableRow
        tabr5.Width = 33
        tabr5.ForeColor = Drawing.Color.DarkRed
        Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7, tabr5c8, tabr5c9, tabr5c10, tabr5c11, tabr5c12, tabr5c13, tabr5c14, tabr5c15, tabr5c16, tabr5c17, tabr5c18, tabr5c19, tabr5c20 As New TableCell

        tabr5c1.ColumnSpan = "1"
        tabr5c2.ColumnSpan = "1"
        tabr5c3.ColumnSpan = "2"
        tabr5c4.ColumnSpan = "2"
        tabr5c5.ColumnSpan = "2"
        tabr5c6.ColumnSpan = "2"
        tabr5c7.ColumnSpan = "2"
        tabr5c8.ColumnSpan = "2"
        tabr5c9.ColumnSpan = "2"
        tabr5c10.ColumnSpan = "2"
        tabr5c11.ColumnSpan = "1"
        tabr5c12.ColumnSpan = "2"
        tabr5c13.ColumnSpan = "1"
        tabr5c14.ColumnSpan = "1"
        tabr5c15.ColumnSpan = "1"
        tabr5c16.ColumnSpan = "1"
        tabr5c17.ColumnSpan = "2"
        tabr5c18.ColumnSpan = "2"
        tabr5c19.ColumnSpan = "2"
        tabr5c20.ColumnSpan = "2"

        tabr5c1.HorizontalAlign = HorizontalAlign.Left
        tabr5c2.HorizontalAlign = HorizontalAlign.Left
        tabr5c5.HorizontalAlign = HorizontalAlign.Left
        tabr5c6.HorizontalAlign = HorizontalAlign.Left
        tabr5c3.HorizontalAlign = HorizontalAlign.Left
        tabr5c4.HorizontalAlign = HorizontalAlign.Left
        tabr5c7.HorizontalAlign = HorizontalAlign.Left
        tabr5c8.HorizontalAlign = HorizontalAlign.Left
        tabr5c9.HorizontalAlign = HorizontalAlign.Left
        tabr5c10.HorizontalAlign = HorizontalAlign.Left
        tabr5c11.HorizontalAlign = HorizontalAlign.Left
        tabr5c12.HorizontalAlign = HorizontalAlign.Left
        tabr5c13.HorizontalAlign = HorizontalAlign.Left
        tabr5c14.HorizontalAlign = HorizontalAlign.Left
        tabr5c15.HorizontalAlign = HorizontalAlign.Left
        tabr5c16.HorizontalAlign = HorizontalAlign.Left
        tabr5c17.HorizontalAlign = HorizontalAlign.Left
        tabr5c18.HorizontalAlign = HorizontalAlign.Left
        tabr5c19.HorizontalAlign = HorizontalAlign.Left
        tabr5c20.HorizontalAlign = HorizontalAlign.Left
        tabr5c1.Text = "<b><font size=2.5>SI.NO</font></b>"
        tabr5c2.Text = "<b><font size=2.5>EMP CODE</font></b>"
        tabr5c3.Text = "<b><font size=2.5>EMP NAME&nbsp;&nbsp;</font></b>"
        tabr5c4.Text = "<b><font size=2.5>BRANCH&nbsp;&nbsp;</font></b>"
        tabr5c5.Text = "<b><font size=2.5>AREA&nbsp;&nbsp;</font></b>"
        tabr5c6.Text = "<b><font size=2.5>DIVISION&nbsp;&nbsp;</font></b>"
        tabr5c17.Text = "<b><font size=2.5>REGION&nbsp;&nbsp;</font></b>"
        tabr5c18.Text = "<b><font size=2.5>ZONE&nbsp;</font></b>"
        tabr5c19.Text = "<b><font size=2.5>STATE&nbsp;</font></b>"
        tabr5c7.Text = "<b><font size=2.5>CONTACT NO.&nbsp;&nbsp;</font></b>"
        tabr5c8.Text = "<b><font size=2.5>DESIGNATION&nbsp;</font></b>"
        tabr5c9.Text = "<b><font size=2.5>DEPARTMENT&nbsp;&nbsp;</font></b>"
        tabr5c10.Text = "<b><font size=2.5>POST&nbsp;&nbsp;</font></b>"
        tabr5c11.Text = "<b><font size=2.5>&nbsp;JOIN DT</font></b>"
        tabr5c12.Text = "<b><font size=2.5>QUALIFICATION&nbsp;&nbsp;</font></b>"
        tabr5c13.Text = "<b><font size=2.5>AGE&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        tabr5c14.Text = "<b><font size=2.5>EXP (DAYS)&nbsp;&nbsp;</font></b>"
        tabr5c15.Text = "<b><font size=2.5>GENDER&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        tabr5c16.Text = "<b><font size=2.5>MARITAL STATUS&nbsp;&nbsp;</font></b>"
        tabr5c20.Text = "<b><font size=2.5>DISCONT.DATE&nbsp;&nbsp;</font></b>"
        tabr5.Controls.Add(tabr5c1)
        tabr5.Controls.Add(tabr5c2)
        tabr5.Controls.Add(tabr5c3)
        tabr5.Controls.Add(tabr5c4)
        tabr5.Controls.Add(tabr5c5)
        tabr5.Controls.Add(tabr5c6)
        tabr5.Controls.Add(tabr5c17)
        tabr5.Controls.Add(tabr5c18)
        tabr5.Controls.Add(tabr5c19)
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
        tabr5.Controls.Add(tabr5c20)

        tab1.Controls.Add(tabr5)

        '''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 33
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 33
        tabcellline1.Text = "<hr>"
        tabline1.Controls.Add(tabcellline1)
        tab1.Controls.Add(tabline1)
        '''''''''''''''''''''''''''''''''
        Dim colors As String
        colors = "#fff7ff"
        Dim dr As DataRow
        '    Dim tot As Integer = 0
        ' Dim totmale As Integer = 0
        ' Dim totfemale As Integer = 0
        Dim state As String = ""
        Dim i As Integer = 0
        Dim totexp As Integer = 0
        For Each dr In dt.Rows
            If state <> dr(15) Then
                state = dr(15)
                Dim staterow As New TableRow
                staterow.Width = 33
                staterow.BackColor = Drawing.Color.Wheat
                staterow.ForeColor = Drawing.Color.Red
                Dim statecell As New TableCell
                statecell.ColumnSpan = 33
                statecell.Text = state
                staterow.Controls.Add(statecell)
                tab1.Controls.Add(staterow)
            End If
            i = i + 1
            If colors.Equals("#fff7ff") = True Then
                colors = "#eef9ff"
            Else
                colors = "#fff7ff"
            End If
            Dim tabr6 As New TableRow
            tabr6.Width = 33
            tabr6.Attributes.Add("bgcolor", colors)
            Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7, tabr6c8, tabr6c9, tabr6c10, tabr6c11, tabr6c12, tabr6c13, tabr6c14, tabr6c15, tabr6c16, tabr6c17, tabr6c18, tabr6c19, tabr6c20 As New TableCell

            tabr6c1.ColumnSpan = "1"
            tabr6c2.ColumnSpan = "1"
            tabr6c3.ColumnSpan = "2"
            tabr6c4.ColumnSpan = "2"
            tabr6c5.ColumnSpan = "2"
            tabr6c6.ColumnSpan = "2"
            tabr6c7.ColumnSpan = "2"
            tabr6c8.ColumnSpan = "2"
            tabr6c9.ColumnSpan = "2"
            tabr6c10.ColumnSpan = "2"
            tabr6c11.ColumnSpan = "1"
            tabr6c12.ColumnSpan = "2"
            tabr6c13.ColumnSpan = "1"
            tabr6c14.ColumnSpan = "1"
            tabr6c15.ColumnSpan = "1"
            tabr6c16.ColumnSpan = "1"
            tabr6c17.ColumnSpan = "2"
            tabr6c18.ColumnSpan = "2"
            tabr6c19.ColumnSpan = "2"
            tabr6c19.ColumnSpan = "2"
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
            tabr6c12.Attributes.Add("align", "left")
            tabr6c13.Attributes.Add("align", "left")
            tabr6c14.Attributes.Add("align", "left")
            tabr6c15.Attributes.Add("align", "left")
            tabr6c16.Attributes.Add("align", "left")
            tabr6c17.Attributes.Add("align", "left")
            tabr6c18.Attributes.Add("align", "left")
            tabr6c19.Attributes.Add("align", "left")
            tabr6c20.Attributes.Add("align", "left")
            tabr6c1.Text = "<font size=2>" & i & "&nbsp;&nbsp;</font>"
            tabr6c2.Text = "<font size=2>" & dr(0) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c3.Text = "<font size=2>" & dr(1) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c4.Text = "<font size=2>" & dr(2) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c5.Text = "<font size=2>" & dr(3) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c6.Text = "<font size=2>" & dr(4) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c17.Text = "<font size=2>" & dr(17) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c18.Text = "<font size=2>" & dr(18) & "&nbsp;&nbsp;</font>"
            tabr6c19.Text = "<font size=2>" & dr(15) & "&nbsp;&nbsp;</font>"
            tabr6c7.Text = "<font size=2>" & dr(5) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c8.Text = "<font size=2>" & dr(6) & "&nbsp;&nbsp;</font>"
            tabr6c9.Text = "<font size=2>" & dr(7) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c10.Text = "<font size=2>" & dr(8) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c11.Text = "<font size=2>" & Format(dr(9), "dd/MMM/yyyy") & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c12.Text = "<font size=2>" & dr(10) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c13.Text = "<font size=2>" & dr(11) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c14.Text = "<font size=2>" & dr(12) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c15.Text = "<font size=2>" & dr(13) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c16.Text = "<font size=2>" & dr(14) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c20.Text = "<font size=2>" & dr(19) & "&nbsp;&nbsp;&nbsp;</font>"

            totexp += dr(12)

            tabr6.Controls.Add(tabr6c1)
            tabr6.Controls.Add(tabr6c2)
            tabr6.Controls.Add(tabr6c3)
            tabr6.Controls.Add(tabr6c4)
            tabr6.Controls.Add(tabr6c5)
            tabr6.Controls.Add(tabr6c6)
            tabr6.Controls.Add(tabr6c17)
            tabr6.Controls.Add(tabr6c18)
            tabr6.Controls.Add(tabr6c19)
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
            tabr6.Controls.Add(tabr6c20)
            tab1.Controls.Add(tabr6)
        Next
        Dim totrow As New TableRow
        totrow.Width = 33
        Dim totcell As New TableCell
        totcell.ColumnSpan = 33
        totcell.HorizontalAlign = HorizontalAlign.Center
        totcell.ForeColor = Drawing.Color.Red
        totcell.BackColor = Drawing.Color.SkyBlue
        totcell.Text = "<font size =4.5><b> TOTAL EXPERIENCE = " & totexp & " days</b></font>"
        totrow.Controls.Add(totcell)
        tab1.Controls.Add(totrow)
        Me.Panel1.Controls.Add(tab1)
    End Sub
End Class
