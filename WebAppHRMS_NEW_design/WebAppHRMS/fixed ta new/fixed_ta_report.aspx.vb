Imports System.Data
Imports System.Data.OracleClient
Partial Class Fixed_TA_New_fixed_ta_report_a037239f8934
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim FxTATable As New Table
    Dim i As Integer = 0
    Dim userid, struser() As String
    Dim userCode As Integer
    Dim talim As Double = 0
    Dim taelg As Double = 0
    Dim tainsded As Double = 0
    Dim tanet As Double = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.userid = Me.Session("user_id")
            Me.struser = Me.userid.Split("!")
            Me.userCode = Me.struser(0)

            Dim empName As String = oh.ExecuteDataSet("select emp_code||' : '||emp_name from employee_master where emp_code = " & Me.userCode & "").Tables(0).Rows(0)(0)
            '                                                0                                   1                                  2                               3                                 4   //
            str = "select decode(a.all_id,1,'FIXED T.A',6,'B.H/B.M TA') as TA_Type,nvl(a.all_limit,0) as TA_Limit,nvl(a.all_amt,0) as TA_Amount,nvl(a.ins_ded_amt,0) as Ded_Amount,nvl(a.net_fixed_ta,0) as Fixed_TA from hr_fixed_ta_amt a where emp_code = " & Me.userCode & ""
            dt = oh.ExecuteDataSet(str).Tables(0)
            If dt.Rows.Count > 0 Then
                FxTATable.Width = 5
                FxTATable.Attributes.Add("width", "100%")

                Dim header As New TableRow
                header.BackColor = Drawing.Color.Gold
                header.ForeColor = Drawing.Color.Red
                header.Width = 5
                Dim headercell As New TableCell
                headercell.ColumnSpan = 5
                headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
                headercell.HorizontalAlign = HorizontalAlign.Center
                header.Controls.Add(headercell)
                FxTATable.Controls.Add(header)

                Dim sheader As New TableRow
                sheader.Width = 5
                sheader.BackColor = Drawing.Color.LightGray
                Dim sheadercell1 As New TableCell
                sheadercell1.ColumnSpan = 5
                sheadercell1.HorizontalAlign = HorizontalAlign.Center
                sheadercell1.Text = "<b><font size=2>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
                sheader.Controls.Add(sheadercell1)
                FxTATable.Controls.Add(sheader)

                Dim tt As New TableRow
                'tt.BackColor = Drawing.Color.LightSkyBlue
                tt.Width = 5
                Dim tt1 As New TableCell
                tt1.ColumnSpan = 5
                tt1.HorizontalAlign = HorizontalAlign.Center
                tt1.Text = "<b><font size=3>Fixed TA Report of " & empName & "</font></b>"
                tt.Controls.Add(tt1)
                FxTATable.Controls.Add(tt)

                Dim subh As New TableRow
                Dim subcell1 As New TableCell
                Dim subcell2 As New TableCell
                Dim subcell3 As New TableCell
                subh.Width = 5

                subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
                subcell1.ColumnSpan = 1
                subcell1.HorizontalAlign = HorizontalAlign.Left
                subh.Controls.Add(subcell1)

                subcell2.ColumnSpan = 2
                subcell2.HorizontalAlign = HorizontalAlign.Center
                subcell2.Text = " "
                subh.Controls.Add(subcell2)

                subcell3.ColumnSpan = 2
                subcell3.HorizontalAlign = HorizontalAlign.Right
                subcell3.Text = "<b><font size=2>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
                'subcell3.Text = "<font size=2><b><div id= txt align= right></div></b></font></div>"
                subh.Controls.Add(subcell3)
                FxTATable.Controls.Add(subh)

                Dim line As New TableRow
                Dim linecell As New TableCell
                linecell.ColumnSpan = 5
                linecell.Text = "<hr>"
                line.Controls.Add(linecell)
                FxTATable.Controls.Add(line)
                '----------------
                Dim colors As String
                colors = "#fff7ef"
                '-----------------

                Dim field As New TableRow
                field.Width = 5
                field.Attributes.Add("bgcolor", colors)
                Dim f1, f2, f3, f4, f5 As New TableCell

                f1.ColumnSpan = 1
                f1.HorizontalAlign = HorizontalAlign.Left
                f1.Text = "<b><font size=2>T.A&nbsp;Type&nbsp;</font></b>"
                field.Controls.Add(f1)

                f2.ColumnSpan = 1
                f2.HorizontalAlign = HorizontalAlign.Center
                f2.Text = "<b><font size=2>T.A&nbsp;Limit&nbsp;</font></b>"
                field.Controls.Add(f2)

                f3.ColumnSpan = 1
                f3.HorizontalAlign = HorizontalAlign.Center
                f3.Text = "<b><font size=2>T.A&nbsp;Amount&nbsp;</font></b>"
                field.Controls.Add(f3)

                f4.ColumnSpan = 1
                f4.HorizontalAlign = HorizontalAlign.Center
                f4.Text = "<b><font size=2>Ins.&nbsp;Ded.&nbsp;Amount&nbsp;</font></b>"
                field.Controls.Add(f4)

                f5.ColumnSpan = 1
                f5.HorizontalAlign = HorizontalAlign.Left
                f5.Text = "<b><font size=2>Net&nbsp;Amount&nbsp;</font></b>"
                field.Controls.Add(f5)

                FxTATable.Controls.Add(field)

                Dim line1 As New TableRow
                Dim linecell1 As New TableCell
                linecell1.ColumnSpan = 5
                linecell1.Text = "<hr>"
                line1.Controls.Add(linecell1)
                FxTATable.Controls.Add(line1)


                For Each dr In dt.Rows

                    '///////////////////////////values
                    Dim value As New TableRow
                    value.Width = 5
                    value.Attributes.Add("bgcolor", colors)
                    Dim v1, v2, v3, v4, v5 As New TableCell

                    v1.ColumnSpan = 1    'ta type
                    v1.HorizontalAlign = HorizontalAlign.Left
                    v1.Text = "<font size=2>" & dr(0) & "&nbsp;</font>"
                    value.Controls.Add(v1)

                    v2.ColumnSpan = 1    'ta limit
                    v2.HorizontalAlign = HorizontalAlign.Right
                    v2.Text = "<font size=2>" & dr(1) & "&nbsp;</font>"
                    value.Controls.Add(v2)
                    talim += dr(1)

                    v3.ColumnSpan = 1   'ta eligible
                    v3.HorizontalAlign = HorizontalAlign.Right
                    v3.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
                    value.Controls.Add(v3)
                    taelg += dr(2)

                    v4.ColumnSpan = 1   'ta Ins deduction
                    v4.HorizontalAlign = HorizontalAlign.Right
                    v4.Text = "<font size=2>" & dr(3) & "&nbsp;</font>"
                    value.Controls.Add(v4)
                    tainsded += dr(3)

                    v5.ColumnSpan = 1   'Net TA
                    v5.HorizontalAlign = HorizontalAlign.Right
                    v5.Text = "<font size=2>" & dr(4) & "&nbsp;</font>"
                    value.Controls.Add(v5)
                    tanet += dr(4)

                    FxTATable.Controls.Add(value)
                Next
                Dim linew As New TableRow
                Dim linecellw1 As New TableCell
                linecellw1.ColumnSpan = 5
                linecellw1.Text = "<hr>"
                linew.Controls.Add(linecellw1)
                FxTATable.Controls.Add(linew)

                Dim Rowtow As New TableRow
                Rowtow.Width = 5
                Dim cel1, cel2, cel3, cel4, cel5 As New TableCell

                cel1.ColumnSpan = 1    'ta type
                cel1.HorizontalAlign = HorizontalAlign.Center
                cel1.Text = "<font size=2>&nbsp;&nbsp;</font>"
                Rowtow.Controls.Add(cel1)

                cel2.ColumnSpan = 1    'ta limit
                cel2.HorizontalAlign = HorizontalAlign.Right
                cel2.Text = "<font size=2>" & FormatNumber(talim, 2) & "&nbsp;</font>"
                Rowtow.Controls.Add(cel2)


                cel3.ColumnSpan = 1   'ta eligible
                cel3.HorizontalAlign = HorizontalAlign.Right
                cel3.Text = "<a href=fixed_ta_eligible.aspx?empcode=" & Me.userCode & "><font size=2>" & FormatNumber(taelg, 2) & "&nbsp;</font></a>"
                Rowtow.Controls.Add(cel3)


                cel4.ColumnSpan = 1   'ta Ins deduction
                cel4.HorizontalAlign = HorizontalAlign.Right
                If Me.tainsded > 0 Then
                    cel4.Text = "<a href=fixed_ta_insded.aspx?empcode=" & Me.userCode & "><font size=2>" & FormatNumber(tainsded, 2) & "&nbsp;</font></a>"
                Else
                    cel4.Text = "<font size=2>" & FormatNumber(tainsded, 2) & "&nbsp;</font>"
                End If
                Rowtow.Controls.Add(cel4)


                cel5.ColumnSpan = 1   'Net TA
                cel5.HorizontalAlign = HorizontalAlign.Right
                cel5.Text = "<font size=2>" & FormatNumber(tanet, 2) & "&nbsp;</font>"
                Rowtow.Controls.Add(cel5)

                FxTATable.Controls.Add(Rowtow)


                Dim linex As New TableRow
                Dim linecellx1 As New TableCell
                linecellx1.ColumnSpan = 5
                linecellx1.Text = "<hr>"
                linex.Controls.Add(linecellx1)
                FxTATable.Controls.Add(linex)

            Else

                Dim warn As New TableRow
                warn.Width = 5
                Dim w1 As New TableCell
                w1.ColumnSpan = 5
                w1.HorizontalAlign = HorizontalAlign.Center
                w1.Text = "<b><font size=2>No Data Found..!!</font></b>"
                warn.Controls.Add(w1)
                FxTATable.Controls.Add(warn)

            End If

        Catch ex As Exception
            Dim warn1 As New TableRow
            warn1.Width = 5
            Dim w11 As New TableCell
            w11.ColumnSpan = 5
            w11.HorizontalAlign = HorizontalAlign.Center
            w11.Text = "<b><font size=2>" & ex.Message & "..!!</font></b>"
            warn1.Controls.Add(w11)
            FxTATable.Controls.Add(warn1)
        End Try
        Me.panel_FixedTA.Controls.Add(FxTATable)
    End Sub
End Class
