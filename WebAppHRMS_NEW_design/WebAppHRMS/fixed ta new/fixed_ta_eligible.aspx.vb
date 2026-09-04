Imports System.Data
Imports System.Data.OracleClient
Partial Class Fixed_TA_New_fixed_ta_eligible_20815dec5437
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim FxTATable As New Table
    Dim i As Integer = 0
    Dim talim As Double = 0
    Dim taelg As Double = 0
    Dim wdays As Integer = 0
    Dim ldays As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
           
            Dim empName As String = oh.ExecuteDataSet("select emp_code||' : '||emp_name from employee_master where emp_code = " & Me.Request.QueryString("empcode") & "").Tables(0).Rows(0)(0)
            '               0         1             2             3       4          5           6          7        8 //
            str = "select a.from_dt,a.to_dt,dm.designation,pm.post_name,a.days,a.leave_days,a.ta_limit,a.ta_amt,bm.branch_name from hr_fixed_ta a,designation_master dm,post_mst pm,branch_master bm where a.desig_id = dm.designation_id and a.post_id = pm.post_id and a.branch_id = bm.branch_id and a.emp_code = " & Me.Request.QueryString("empcode") & " union select a.from_dt,a.to_dt,dm.designation,pm.post_name,a.days,a.leave_days,a.ta_limit,a.ta_amt,bc.branch_name from hr_fixed_ta a,designation_master dm,post_mst pm,before_completion bc where a.desig_id = dm.designation_id and a.post_id = pm.post_id and a.branch_id = bc.old_id and a.emp_code = " & Me.Request.QueryString("empcode") & " order by from_dt"
            dt = oh.ExecuteDataSet(str).Tables(0)
            If dt.Rows.Count > 0 Then
                FxTATable.Width = 9
                FxTATable.Attributes.Add("width", "100%")

                Dim header As New TableRow
                header.BackColor = Drawing.Color.Gold
                header.ForeColor = Drawing.Color.Red
                header.Width = 9
                Dim headercell As New TableCell
                headercell.ColumnSpan = 9
                headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
                headercell.HorizontalAlign = HorizontalAlign.Center
                header.Controls.Add(headercell)
                FxTATable.Controls.Add(header)

                Dim sheader As New TableRow
                sheader.Width = 9
                sheader.BackColor = Drawing.Color.LightGray
                Dim sheadercell1 As New TableCell
                sheadercell1.ColumnSpan = 9
                sheadercell1.HorizontalAlign = HorizontalAlign.Center
                sheadercell1.Text = "<b><font size=2>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
                sheader.Controls.Add(sheadercell1)
                FxTATable.Controls.Add(sheader)

                Dim tt As New TableRow
                'tt.BackColor = Drawing.Color.LightSkyBlue
                tt.Width = 9
                Dim tt1 As New TableCell
                tt1.ColumnSpan = 9
                tt1.HorizontalAlign = HorizontalAlign.Center
                tt1.Text = "<b><font size=3>Fixed TA Detailed report of " & empName & "</font></b>"
                tt.Controls.Add(tt1)
                FxTATable.Controls.Add(tt)

                Dim subh As New TableRow
                Dim subcell1 As New TableCell
                Dim subcell2 As New TableCell
                Dim subcell3 As New TableCell
                subh.Width = 9

                subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
                subcell1.ColumnSpan = 2
                subcell1.HorizontalAlign = HorizontalAlign.Left
                subh.Controls.Add(subcell1)

                subcell2.ColumnSpan = 5
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
                linecell.ColumnSpan = 9
                linecell.Text = "<hr>"
                line.Controls.Add(linecell)
                FxTATable.Controls.Add(line)
                '----------------
                Dim colors As String
                colors = "#fff7ef"
                '-----------------

                Dim field As New TableRow
                field.Width = 9
                field.Attributes.Add("bgcolor", colors)
                Dim f1, f2, f3, f4, f5, f6, f7, f8, f9 As New TableCell

                f1.ColumnSpan = 1  'Fromdate
                f1.HorizontalAlign = HorizontalAlign.Left
                f1.Text = "<b><font size=2>From&nbsp;Date&nbsp;</font></b>"
                field.Controls.Add(f1)

                f2.ColumnSpan = 1  'Todate
                f2.HorizontalAlign = HorizontalAlign.Left
                f2.Text = "<b><font size=2>To&nbsp;Date&nbsp;</font></b>"
                field.Controls.Add(f2)

                f9.ColumnSpan = 1  'Todate
                f9.HorizontalAlign = HorizontalAlign.Left
                f9.Text = "<b><font size=2>Branch&nbsp;Name&nbsp;</font></b>"
                field.Controls.Add(f9)

                f3.ColumnSpan = 1 'designation
                f3.HorizontalAlign = HorizontalAlign.Left
                f3.Text = "<b><font size=2>Designation&nbsp;</font></b>"
                field.Controls.Add(f3)

                f4.ColumnSpan = 1 'Post
                f4.HorizontalAlign = HorizontalAlign.Left
                f4.Text = "<b><font size=2>Post&nbsp;</font></b>"
                field.Controls.Add(f4)

                f5.ColumnSpan = 1
                f5.HorizontalAlign = HorizontalAlign.Center
                f5.Text = "<b><font size=2>Work&nbsp;Days&nbsp;</font></b>"
                field.Controls.Add(f5)

                f6.ColumnSpan = 1
                f6.HorizontalAlign = HorizontalAlign.Center
                f6.Text = "<b><font size=2>Leave&nbsp;Days&nbsp;</font></b>"
                field.Controls.Add(f6)

                f7.ColumnSpan = 1
                f7.HorizontalAlign = HorizontalAlign.Center
                f7.Text = "<b><font size=2>T.A&nbsp;Limit&nbsp;</font></b>"
                field.Controls.Add(f7)

                f8.ColumnSpan = 1
                f8.HorizontalAlign = HorizontalAlign.Center
                f8.Text = "<b><font size=2>T.A&nbsp;Amount&nbsp;</font></b>"
                field.Controls.Add(f8)

                FxTATable.Controls.Add(field)

                Dim line1 As New TableRow
                Dim linecell1 As New TableCell
                linecell1.ColumnSpan = 9
                linecell1.Text = "<hr>"
                line1.Controls.Add(linecell1)
                FxTATable.Controls.Add(line1)


                For Each dr In dt.Rows

                    '///////////////////////////values
                    Dim value As New TableRow
                    value.Width = 9
                    value.Attributes.Add("bgcolor", colors)
                    Dim v1, v2, v3, v4, v5, v6, v7, v8, v9 As New TableCell

                    v1.ColumnSpan = 1    'fromdate
                    v1.HorizontalAlign = HorizontalAlign.Center
                    If IsDBNull(dr(0)) Then
                        v1.Text = "<font size=2>&nbsp;----&nbsp;</font>"
                    Else
                        v1.Text = "<font size=2>" & Format(dr(0), "dd-MMM-yyyy") & "&nbsp;</font>"
                    End If
                    value.Controls.Add(v1)

                    v2.ColumnSpan = 1    'todate
                    v2.HorizontalAlign = HorizontalAlign.Center
                    If IsDBNull(dr(1)) Then
                        v2.Text = "<font size=2>&nbsp;----&nbsp;</font>"
                    Else
                        v2.Text = "<font size=2>" & Format(dr(1), "dd-MMM-yyyy") & "&nbsp;</font>"
                    End If
                    value.Controls.Add(v2)

                    v9.ColumnSpan = 1   'Branch Name
                    v9.HorizontalAlign = HorizontalAlign.Left
                    v9.Text = "<font size=2>" & dr(8) & "&nbsp;</font>"
                    value.Controls.Add(v9)


                    v3.ColumnSpan = 1   'designation
                    v3.HorizontalAlign = HorizontalAlign.Left
                    v3.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
                    value.Controls.Add(v3)

                    v4.ColumnSpan = 1   'post
                    v4.HorizontalAlign = HorizontalAlign.Left
                    v4.Text = "<font size=2>" & dr(3) & "&nbsp;</font>"
                    value.Controls.Add(v4)

                    v5.ColumnSpan = 1   'days
                    v5.HorizontalAlign = HorizontalAlign.Right
                    v5.Text = "<font size=2>" & dr(4) & "&nbsp;</font>"
                    value.Controls.Add(v5)
                    wdays += dr(4)

                    v6.ColumnSpan = 1   'Leave days
                    v6.HorizontalAlign = HorizontalAlign.Right
                    v6.Text = "<font size=2>" & dr(5) & "&nbsp;</font>"
                    value.Controls.Add(v6)
                    ldays += dr(5)

                    v7.ColumnSpan = 1   'TA LIMIT
                    v7.HorizontalAlign = HorizontalAlign.Right
                    v7.Text = "<font size=2>" & FormatNumber(dr(6), 2) & "&nbsp;</font>"
                    value.Controls.Add(v7)
                    talim += dr(6)

                    v8.ColumnSpan = 1   'TA Amount
                    v8.HorizontalAlign = HorizontalAlign.Right
                    v8.Text = "<font size=2>" & FormatNumber(dr(7), 2) & "&nbsp;</font>"
                    value.Controls.Add(v8)
                    taelg += dr(7)

                    FxTATable.Controls.Add(value)
                Next
                Dim linew As New TableRow
                Dim linecellw1 As New TableCell
                linecellw1.ColumnSpan = 9
                linecellw1.Text = "<hr>"
                linew.Controls.Add(linecellw1)
                FxTATable.Controls.Add(linew)

                Dim Rowtow As New TableRow
                Rowtow.Width = 9
                Dim cel1, cel2, cel3, cel4, cel5 As New TableCell

                cel1.ColumnSpan = 5    '
                cel1.HorizontalAlign = HorizontalAlign.Center
                cel1.Text = "<font size=2>&nbsp;&nbsp;</font>"
                Rowtow.Controls.Add(cel1)

                cel2.ColumnSpan = 1    'wdays
                cel2.HorizontalAlign = HorizontalAlign.Right
                cel2.Text = "<font size=2>" & Me.wdays & "&nbsp;</font>"
                Rowtow.Controls.Add(cel2)


                cel3.ColumnSpan = 1   'ldays
                cel3.HorizontalAlign = HorizontalAlign.Right
                cel3.Text = "<font size=2>" & Me.ldays & "&nbsp;</font>"
                Rowtow.Controls.Add(cel3)


                cel4.ColumnSpan = 1   'ta Ins deduction
                cel4.HorizontalAlign = HorizontalAlign.Right
                cel4.Text = "<font size=2>" & FormatNumber(Me.talim, 2) & "&nbsp;</font>"
                Rowtow.Controls.Add(cel4)


                cel5.ColumnSpan = 1   'Net TA
                cel5.HorizontalAlign = HorizontalAlign.Right
                cel5.Text = "<font size=2>" & FormatNumber(Me.taelg, 2) & "&nbsp;</font>"
                Rowtow.Controls.Add(cel5)

                FxTATable.Controls.Add(Rowtow)


                Dim linex As New TableRow
                Dim linecellx1 As New TableCell
                linecellx1.ColumnSpan = 9
                linecellx1.Text = "<hr>"
                linex.Controls.Add(linecellx1)
                FxTATable.Controls.Add(linex)

            Else

                Dim warn As New TableRow
                warn.Width = 9
                Dim w1 As New TableCell
                w1.ColumnSpan = 9
                w1.HorizontalAlign = HorizontalAlign.Center
                w1.Text = "<b><font size=2>No Data Found..!!</font></b>"
                warn.Controls.Add(w1)
                FxTATable.Controls.Add(warn)

            End If

        Catch ex As Exception
            Dim warn1 As New TableRow
            warn1.Width = 9
            Dim w11 As New TableCell
            w11.ColumnSpan = 9
            w11.HorizontalAlign = HorizontalAlign.Center
            w11.Text = "<b><font size=2>" & ex.Message & "..!!</font></b>"
            warn1.Controls.Add(w11)
            FxTATable.Controls.Add(warn1)
        End Try
        Me.pan_FixTaElg.Controls.Add(FxTATable)
    End Sub
End Class
