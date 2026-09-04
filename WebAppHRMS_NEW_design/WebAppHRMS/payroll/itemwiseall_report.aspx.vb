Imports System.Data
Imports System.Data.OracleClient
Partial Class itemwiseall_report_3c812c636668
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim total As Double = 0.0
    Dim i As Integer = 0


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim itemtable As New Table
        itemtable.Attributes.Add("width", "100%")

        Dim s As String = oh.ExecuteDataSet("select all_name from incentives_allowances_master where all_id=" & Me.Request.QueryString("item_id")).Tables(0).Rows(0)(0)

        str = "select ad.emp_code,em.emp_name,nvl(ad.all_amount,0) from incentives_allowances_dtl ad,employee_master em where ad.emp_code=em.emp_code and ad.all_id=" & Me.Request.QueryString("item_id") & " and ad.rec_firm=" & Session("firm_id") & " having ad.all_amount<>0 group by ad.emp_code,em.emp_name,ad.all_amount order by ad.emp_code"

        dt = oh.ExecuteDataSet(str).Tables(0)

        Dim header As New TableRow
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        header.Width = 8
        Dim headercell As New TableCell
        headercell.ColumnSpan = 8
        headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headercell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headercell)
        itemtable.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.Width = 8
        sheader.BackColor = Drawing.Color.LightGray
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 8
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        itemtable.Controls.Add(sheader)

        Dim tt As New TableRow
        'tt.BackColor = Drawing.Color.LightSkyBlue
        tt.Width = 8
        Dim tt1 As New TableCell
        tt1.ColumnSpan = 8
        tt1.HorizontalAlign = HorizontalAlign.Center
        tt1.Text = "<b><font size=3>ITEMWISE TOTAL REPORT</font></b>"
        tt.Controls.Add(tt1)
        itemtable.Controls.Add(tt)

        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 8

        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 2
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 3
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subcell2.Text = " "
        subh.Controls.Add(subcell2)

        subcell3.ColumnSpan = 3
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subcell3.Text = "<b><font size=2>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        'subcell3.Text = "<font size=2><b><div id= txt align= right></div></b></font></div>"
        subh.Controls.Add(subcell3)
        itemtable.Controls.Add(subh)

        Dim line As New TableRow
        Dim linecell As New TableCell
        linecell.ColumnSpan = 8
        linecell.Text = "<hr>"
        line.Controls.Add(linecell)
        itemtable.Controls.Add(line)
        '''''''''''''''''

        Dim colors As String
        colors = "#fff7ef"



        Dim field As New TableRow
        field.Width = 8
        field.Attributes.Add("bgcolor", colors)
        Dim f1, f2, f3, f4 As New TableCell

        f1.ColumnSpan = 1
        f1.HorizontalAlign = HorizontalAlign.Center
        f1.Text = "<b><font size=2>Si&nbsp;NO</font></b>"
        field.Controls.Add(f1)

        f2.ColumnSpan = 2
        f2.HorizontalAlign = HorizontalAlign.Left
        f2.Text = "<b><font size=2>&nbsp;EMP&nbsp;CODE&nbsp;</font></b>"
        field.Controls.Add(f2)

        f3.ColumnSpan = 3
        f3.HorizontalAlign = HorizontalAlign.Left
        f3.Text = "<b><font size=2>&nbsp;EMPLOYEE&nbsp;NAME&nbsp;</font></b>"
        field.Controls.Add(f3)

        f4.ColumnSpan = 2
        f4.HorizontalAlign = HorizontalAlign.Center
        f4.Text = "<b><font size=2>&nbsp;" & s & "&nbsp;</font></b>"
        field.Controls.Add(f4)


        itemtable.Controls.Add(field)

        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        linecell1.ColumnSpan = 8
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        itemtable.Controls.Add(line1)

      
        dt = oh.ExecuteDataSet(str).Tables(0)

        For Each dr In dt.Rows
            i += 1

            If colors.Equals("#fff7ef") = True Then
                colors = "#eef3ef"
            Else
                colors = "#fff7ef"
            End If



            Dim value As New TableRow
            value.Width = 8
            Dim v1, v2, v3, v4 As New TableCell
            value.Attributes.Add("bgcolor", colors)

            v1.ColumnSpan = 1
            v1.HorizontalAlign = HorizontalAlign.Center
            v1.Text = "<font size=2>" & i & "</font>"
            value.Controls.Add(v1)

            v2.ColumnSpan = 2
            v2.HorizontalAlign = HorizontalAlign.Left
            v2.Text = "<font size=2>" & dr(0) & "</font>"
            value.Controls.Add(v2)

            v3.ColumnSpan = 3
            v3.HorizontalAlign = HorizontalAlign.Left
            v3.Text = "<font size=2>" & dr(1) & "</font>"
            value.Controls.Add(v3)

            v4.ColumnSpan = 2
            v4.HorizontalAlign = HorizontalAlign.Right
            v4.Text = "<font size=2>" & FormatNumber(dr(2), 2) & "</font>"
            value.Controls.Add(v4)

            total += dr(2)

            itemtable.Controls.Add(value)

        Next

        Dim line2 As New TableRow
        Dim linecell2 As New TableCell
        linecell2.ColumnSpan = 8
        linecell2.Text = "<hr>"
        line2.Controls.Add(linecell2)
        itemtable.Controls.Add(line2)

        Dim totval As New TableRow
        totval.Width = 8
        totval.Attributes.Add("bgcolor", colors)

        Dim tot1, tot2 As New TableCell

        tot1.ColumnSpan = 6
        tot1.HorizontalAlign = HorizontalAlign.Center
        tot1.Text = "<b><font size=3>TOTAL:</font></b>"
        totval.Controls.Add(tot1)

        tot2.ColumnSpan = 2
        tot2.HorizontalAlign = HorizontalAlign.Right
        tot2.Text = "<b><font size=3>" & FormatNumber(total, 2) & "</font></b>"
        totval.Controls.Add(tot2)

        itemtable.Controls.Add(totval)


        Dim line3 As New TableRow
        Dim linecell3 As New TableCell
        linecell3.ColumnSpan = 8
        linecell3.Text = "<hr>"
        line3.Controls.Add(linecell3)
        itemtable.Controls.Add(line3)

        Dim back As New TableRow
        Dim back3 As New TableCell
        back3.ColumnSpan = 8
        back3.HorizontalAlign = HorizontalAlign.Center
        back3.Text = "<a href=incentive_allowance_select.aspx><= Back</a>"
        back.Controls.Add(back3)
        itemtable.Controls.Add(back)

        Panel_ItemwiseReport.Controls.Add(itemtable)
    End Sub
End Class
