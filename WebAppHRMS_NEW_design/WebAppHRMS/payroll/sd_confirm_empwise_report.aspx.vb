Imports System.Data
Imports System.Data.OracleClient
Partial Class SD_CONFIRM_REPORT_sd_confirm_empwise_report_373969907572
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim total As Double = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim empcode As Integer = Me.Request.QueryString("empcode")

        str = "select em.emp_code,em.emp_name,im.all_name as name,nvl(hd.amount,0) from incentives_allowances_master im,hrm_sd_confirmation hd,employee_master em where hd.emp_code=em.emp_code and hd.all_id=im.all_id and hd.emp_code=" & Request.QueryString("empcode") & "and hd.given_status=1 and hd.process_status=1"
        dt = oh.ExecuteDataSet(str).Tables(0)

        Dim sdemptable As New Table

        If dt.Rows.Count > 0 Then

            sdemptable.Attributes.Add("width", "100%")
            Dim header As New TableRow
            Dim headercell As New TableCell
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            headercell.ColumnSpan = 4
            headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
            headercell.HorizontalAlign = HorizontalAlign.Center
            header.Controls.Add(headercell)
            sdemptable.Controls.Add(header)

            Dim sheader As New TableRow
            Dim sheadercell1 As New TableCell
            Dim sheadercell2 As New TableCell
            sheadercell1.ColumnSpan = 4
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
            sheader.Controls.Add(sheadercell1)
            sdemptable.Controls.Add(sheader)


            'Dim s As String = oh.ExecuteDataSet("select month_name from month where month_id=" & Now.Month - 1).Tables(0).Rows(0)(0)
            Dim head As New TableRow
            head.Width = 4
            Dim hh1 As New TableCell
            hh1.ColumnSpan = 4
            hh1.Text = "<body align=center><b><font size=2.5> SD Confirmed List of Allowances and Incentives of " & Me.Request.QueryString("empcode") & " </font></b></body>"
            head.Controls.Add(hh1)
            sdemptable.Controls.Add(head)

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
            sdemptable.Controls.Add(subh)
            Dim linerowa As New TableRow
            Dim linecella As New TableCell
            linecella.ColumnSpan = 4
            linecella.HorizontalAlign = HorizontalAlign.Center
            linecella.Text = "<hr>"
            linerowa.Controls.Add(linecella)
            sdemptable.Controls.Add(linerowa)

            Dim empc As New TableRow
            Dim empc1, empc2, empc3 As New TableCell
            empc.Width = 4
            empc1.ColumnSpan = 2
            empc2.ColumnSpan = 1
            empc3.ColumnSpan = 1
            empc1.HorizontalAlign = HorizontalAlign.Left
            empc2.HorizontalAlign = HorizontalAlign.Center
            empc3.HorizontalAlign = HorizontalAlign.Left
            empc1.Text = "<b><font size=2>Employee&nbsp;Code&nbsp;</font></b>"
            empc2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
            empc3.Text = "<font size=2>" & Request.QueryString("empcode") & "<font>"
            empc.Controls.Add(empc1)
            empc.Controls.Add(empc2)
            empc.Controls.Add(empc3)

            sdemptable.Controls.Add(empc)

            Dim empn As New TableRow
            Dim empn1, empn2, empn3 As New TableCell
            empn.Width = 4
            empn1.ColumnSpan = 2
            empn2.ColumnSpan = 1
            empn3.ColumnSpan = 1
            empn1.HorizontalAlign = HorizontalAlign.Left
            empn2.HorizontalAlign = HorizontalAlign.Center
            empn3.HorizontalAlign = HorizontalAlign.Left
            empn1.Text = "<b><font size=2>Employee&nbsp;Name&nbsp;</font></b>"
            empn2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
            empn3.Text = "<font size=2>" & dt.Rows(0)(1) & "<font>"
            empn.Controls.Add(empn1)
            empn.Controls.Add(empn2)
            empn.Controls.Add(empn3)
            sdemptable.Controls.Add(empn)

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
                v1.Text = "<b><font size=2>" & dr(2) & "&nbsp;</font></b>"
                v2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                v3.Text = "<font size=2>" & FormatNumber(dr(3), 2) & "&nbsp;&nbsp;&nbsp;</font>"

                Me.total += dr(3)

                value.Controls.Add(v1)
                value.Controls.Add(v2)
                value.Controls.Add(v3)
                sdemptable.Controls.Add(value)

            Next

            Dim hline As New TableRow
            hline.Width = 4
            Dim h1 As New TableCell
            h1.ColumnSpan = 4
            h1.Text = "<hr>"
            hline.Controls.Add(h1)
            sdemptable.Controls.Add(hline)

            Dim totr As New TableRow
            totr.Width = 4
            Dim t1, t2, t3 As New TableCell
            t1.ColumnSpan = 2
            t2.ColumnSpan = 1
            t3.ColumnSpan = 1
            t1.HorizontalAlign = HorizontalAlign.Center
            t2.HorizontalAlign = HorizontalAlign.Center
            t3.HorizontalAlign = HorizontalAlign.Right
            t1.Text = "<b><font size=2>Total</font></b>"
            t2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
            t3.Text = "<font size=2>" & FormatNumber(Me.total, 2) & "&nbsp;&nbsp;&nbsp;</font>"
            totr.Controls.Add(t1)
            totr.Controls.Add(t2)
            totr.Controls.Add(t3)
            sdemptable.Controls.Add(totr)

            'Dim ahline As New TableRow
            'ahline.Width = 4
            'Dim ah1 As New TableCell
            'ah1.ColumnSpan = 4
            'ah1.Text = "<hr>"
            'ahline.Controls.Add(ah1)
            'sdemptable.Controls.Add(ahline)



            '////////////////////////////////////////////////////////////////////////

            Panel_Sd_Empwise.Controls.Add(sdemptable)



        End If
    End Sub
End Class
