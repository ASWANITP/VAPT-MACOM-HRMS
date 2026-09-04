Imports System.Data
Imports System.Data.OracleClient
Partial Class SD_CONFIRM_REPORT_sd_confirm_report_70764a411516
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim i As Integer = 0
    Dim total As Double = 0
    Dim colors As String
    Dim sdtable As New Table

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim allid As Integer = Me.Request.QueryString("allid")
        Dim depid As Integer = Me.Request.QueryString("depid")

        If depid = 0 And allid = -99 Then
            '                0             1           2               3            4
            str = "select dp.dep_name,em.emp_code,em.emp_name,dm.designation,sum(nvl(hd.amount,0))as Total from hrm_sd_confirmation hd,employee_master em,department_mst dp,designation_master dm where hd.emp_code=em.emp_code and hd.dep_id=dp.dep_id and em.designation_id=dm.designation_id and hd.given_status=1 and hd.process_status=0 group by dp.dep_name,em.emp_code,em.emp_name,dm.designation order by dep_name,emp_code"
        ElseIf depid <> 0 And allid = -99 Then
            str = "select dp.dep_name,em.emp_code,em.emp_name,dm.designation,sum(nvl(hd.amount,0))as Total from hrm_sd_confirmation hd,employee_master em,department_mst dp,designation_master dm where hd.emp_code=em.emp_code and hd.dep_id=dp.dep_id and em.designation_id=dm.designation_id and hd.given_status=1 and hd.process_status=0 and hd.dep_id=" & Me.Request.QueryString("depid") & " group by dp.dep_name,em.emp_code,em.emp_name,dm.designation order by dep_name,emp_code "
        ElseIf depid = 0 And allid <> -99 Then
            str = "select dp.dep_name,em.emp_code,em.emp_name,dm.designation,sum(nvl(hd.amount,0))as Total from hrm_sd_confirmation hd,employee_master em,department_mst dp,designation_master dm where hd.emp_code=em.emp_code and hd.dep_id=dp.dep_id and em.designation_id=dm.designation_id and hd.given_status=1 and hd.process_status=0 and hd.all_id=" & Me.Request.QueryString("allid") & " group by dp.dep_name,em.emp_code,em.emp_name,dm.designation order by dep_name,emp_code "
        ElseIf depid <> 0 And allid <> -99 Then
            str = "select dp.dep_name,em.emp_code,em.emp_name,dm.designation,sum(nvl(hd.amount,0))as Total from hrm_sd_confirmation hd,employee_master em,department_mst dp,designation_master dm where hd.emp_code=em.emp_code and hd.dep_id=dp.dep_id and em.designation_id=dm.designation_id and hd.given_status=1 and hd.process_status=0 and hd.dep_id=" & Me.Request.QueryString("depid") & " and hd.all_id=" & Me.Request.QueryString("allid") & " group by dp.dep_name,em.emp_code,em.emp_name,dm.designation order by dep_name,emp_code "
        End If

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
            sdtable.Controls.Add(header)

            Dim sheader As New TableRow
            sheader.BackColor = Drawing.Color.LightGray
            Dim sheadercell1 As New TableCell
            Dim sheadercell2 As New TableCell
            sheadercell1.ColumnSpan = 6
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
            sheader.Controls.Add(sheadercell1)
            sdtable.Controls.Add(sheader)

            Dim s As String = oh.ExecuteDataSet("select month_name from month where month_id=" & Now.Month - 1).Tables(0).Rows(0)(0)

            Dim tt As New TableRow
            tt.BackColor = Drawing.Color.LightSkyBlue
            tt.Width = 6
            Dim tt1 As New TableCell
            tt1.ColumnSpan = 6
            tt1.HorizontalAlign = HorizontalAlign.Center
            tt1.Text = "<b><font size=2>Departmentwise SD Confirmed list of Incentives of " & s & " " & Now.Year & " </font></b>"
            tt.Controls.Add(tt1)
            sdtable.Controls.Add(tt)

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
            sdtable.Controls.Add(subh)

            Dim line As New TableRow
            Dim linecell As New TableCell
            linecell.ColumnSpan = 6
            linecell.Text = "<hr>"
            line.Controls.Add(linecell)
            sdtable.Controls.Add(line)


            colors = "#fff7ff"

        


            Dim dep_name As String = ""

            For Each dr In dt.Rows

                i += 1

                If dep_name <> dr(0).ToString Then

                    Dim deprow As New TableRow
                    deprow.Width = 6
                    Dim deprowcell As New TableCell
                    deprowcell.ColumnSpan = 6
                    deprowcell.HorizontalAlign = HorizontalAlign.Left
                    deprowcell.Text = "<font size=2><b>" & dr(0).ToString & "</b>&nbsp;&nbsp;Department</font>"
                    deprow.Controls.Add(deprowcell)
                    sdtable.Controls.Add(deprow)

                    fill()

                End If

                dep_name = dr(0).ToString

                If colors.Equals("#fff7ff") = True Then
                    colors = "#eef9ff"
                Else
                    colors = "#fff7ff"
                End If

                Dim value As New TableRow
                value.Width = 6
                value.Attributes.Add("bgcolor", colors)
                Dim v1, v2, v3, v4 As New TableCell

                v1.ColumnSpan = 1        'Empcode
                v1.HorizontalAlign = HorizontalAlign.Left
                v1.Text = "<a href=sd_confirm_empwise_report.aspx?empcode=" & dr(1) & "><font size=2><b>" & dr(1) & "&nbsp;</b></font></a>"
                value.Controls.Add(v1)
                '"<a href=all_inc_empwise_report.aspx?emp_code=" & dr(1) & "&prdate=" & dr(4) & "><font size=2>" & dr(0) & "</font></a>"

                v2.ColumnSpan = 2         'EmpName
                v2.HorizontalAlign = HorizontalAlign.Left
                v2.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
                value.Controls.Add(v2)

                v3.ColumnSpan = 2    'Designation
                v3.HorizontalAlign = HorizontalAlign.Left
                v3.Text = "<font size=2>" & dr(3) & "&nbsp;</font>"
                value.Controls.Add(v3)

                v4.ColumnSpan = 1   'Amount
                v4.HorizontalAlign = HorizontalAlign.Right
                v4.Text = "<font size=2>" & FormatNumber(dr(4), 2) & "&nbsp;</font>"
                value.Controls.Add(v4)

                total += dr(4)

                sdtable.Controls.Add(value)

            Next

            Dim line4 As New TableRow
            Dim linecell4 As New TableCell
            linecell4.ColumnSpan = 6
            linecell4.Text = "<hr>"
            line4.Controls.Add(linecell4)
            sdtable.Controls.Add(line4)


            Dim qlast As New TableRow
            qlast.Width = 6
            Dim q As New TableCell
            q.ColumnSpan = 6
            q.HorizontalAlign = HorizontalAlign.Left
            q.Text = "<font size=2>Total:&nbsp;<b>" & Me.i & "</b>&nbsp;Employee Record(s) and Sum of Total&nbsp;=&nbsp;<b>" & FormatNumber(Me.total, 2) & "</b>&nbsp;Rupees.<font>"
            qlast.Controls.Add(q)
            sdtable.Controls.Add(qlast)


        Else

            Dim warn As New TableRow
            warn.Width = 6
            Dim w1 As New TableCell
            w1.ColumnSpan = 6
            w1.HorizontalAlign = HorizontalAlign.Center
            w1.Text = "<b><font size=2> No Data Found!!</font></b>"
            warn.Controls.Add(w1)
            sdtable.Controls.Add(warn)

        End If

        Panel_SDconfirm.Controls.Add(sdtable)

    End Sub

    Sub fill()
        Dim row2 As New TableRow
        row2.Width = 6
        row2.Attributes.Add("bgcolor", colors)
        Dim r1, r2, r3, r4 As New TableCell

        r1.ColumnSpan = 1
        r1.HorizontalAlign = HorizontalAlign.Left
        r1.Text = "<b><font size=2>Employee&nbsp;Code&nbsp;</font></b>"
        row2.Controls.Add(r1)

        r2.ColumnSpan = 2
        r2.HorizontalAlign = HorizontalAlign.Left
        r2.Text = "<b><font size=2>Employee&nbsp;Name&nbsp;</font></b>"
        row2.Controls.Add(r2)

        r3.ColumnSpan = 2
        r3.HorizontalAlign = HorizontalAlign.Left
        r3.Text = "<b><font size=2>Designation&nbsp;</font></b>"
        row2.Controls.Add(r3)

        r4.ColumnSpan = 1
        r4.HorizontalAlign = HorizontalAlign.Center
        r4.Text = "<b><font size=2>Amount&nbsp;</font></b>"
        row2.Controls.Add(r4)

        sdtable.Controls.Add(row2)
    End Sub
End Class
