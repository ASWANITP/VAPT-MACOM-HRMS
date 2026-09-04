Imports System.Data
Imports System.Data.OracleClient
Partial Class sd_sal_ta_report_sd_sal_inc_report_e82fc5f97280
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

        Dim type As Integer = Me.Request.QueryString("type")  'salary or incentive!!
        Dim depid As Integer = Me.Request.QueryString("depid")

             
        '   Modified by not taking Process status=1 on 02 dec 2008
        'Modified on 03 12 2008 with 2 options one Confirmed List and other Not Confirmed List..

        If Me.Request.QueryString("sdtype") = 1 Then   'Confirmed
            If type = 1 And depid = 0 Then   'salary with no department
                str = "select dp.dep_name,em.emp_code,em.emp_name,dm.designation,nvl(ed.sdno,0),nvl(hd.amount,0)as Salary from hrm_sd_confirmation hd,employee_master em,department_mst dp,designation_master dm,employee_master_dtl ed where hd.emp_code=em.emp_code and hd.dep_id=dp.dep_id and em.designation_id=dm.designation_id and hd.emp_code=ed.emp_code and hd.given_status=1 and hd.all_id=0 order by dep_name,emp_code"
            ElseIf type = 1 And depid <> 0 Then   'Salary with Department
                str = "select dp.dep_name,em.emp_code,em.emp_name,dm.designation,nvl(ed.sdno,0),nvl(hd.amount,0)as Salary from hrm_sd_confirmation hd,employee_master em,department_mst dp,designation_master dm,employee_master_dtl ed where hd.emp_code=em.emp_code and hd.dep_id=dp.dep_id and em.designation_id=dm.designation_id and hd.emp_code=ed.emp_code and hd.given_status=1 and hd.all_id=0 and hd.dep_id=" & Me.Request.QueryString("depid") & " order by dep_name,emp_code"
            ElseIf type = 2 And depid = 0 Then   'Incentive without dept
                str = "select dp.dep_name,em.emp_code,em.emp_name,dm.designation,nvl(ed.sdno,0),nvl(hd.amount,0)as Salary from hrm_sd_confirmation hd,employee_master em,department_mst dp,designation_master dm,employee_master_dtl ed where hd.emp_code=em.emp_code and hd.dep_id=dp.dep_id and em.designation_id=dm.designation_id and hd.emp_code=ed.emp_code and hd.given_status=1 and hd.all_id=1 order by dep_name,emp_code"
            ElseIf type = 2 And depid <> 0 Then   'Incentive with dept
                str = "select dp.dep_name,em.emp_code,em.emp_name,dm.designation,nvl(ed.sdno,0),nvl(hd.amount,0)as Salary from hrm_sd_confirmation hd,employee_master em,department_mst dp,designation_master dm,employee_master_dtl ed where hd.emp_code=em.emp_code and hd.dep_id=dp.dep_id and em.designation_id=dm.designation_id and hd.emp_code=ed.emp_code and hd.given_status=1 and hd.all_id=1 and hd.dep_id=" & Me.Request.QueryString("depid") & " order by dep_name,emp_code"
            End If
        ElseIf Me.Request.QueryString("sdtype") = 2 Then   'Not Confirmed
            If type = 1 And depid = 0 Then   'salary with no department
                str = "select dp.dep_name,em.emp_code,em.emp_name,dm.designation,nvl(ed.sdno,0),nvl(hd.amount,0)as Salary from hrm_sd_confirmation hd,employee_master em,department_mst dp,designation_master dm,employee_master_dtl ed where hd.emp_code=em.emp_code and hd.dep_id=dp.dep_id and em.designation_id=dm.designation_id and hd.emp_code=ed.emp_code and (hd.given_status=0 or hd.given_status is null) and hd.given_status<>1 and hd.all_id=0 order by dep_name,emp_code"
            ElseIf type = 1 And depid <> 0 Then   'Salary with Department
                str = "select dp.dep_name,em.emp_code,em.emp_name,dm.designation,nvl(ed.sdno,0),nvl(hd.amount,0)as Salary from hrm_sd_confirmation hd,employee_master em,department_mst dp,designation_master dm,employee_master_dtl ed where hd.emp_code=em.emp_code and hd.dep_id=dp.dep_id and em.designation_id=dm.designation_id and hd.emp_code=ed.emp_code and (hd.given_status=0 or hd.given_status is null) and hd.given_status<>1 and hd.all_id=0 and hd.dep_id=" & Me.Request.QueryString("depid") & " order by dep_name,emp_code"
            ElseIf type = 2 And depid = 0 Then   'Incentive without dept
                str = "select dp.dep_name,em.emp_code,em.emp_name,dm.designation,nvl(ed.sdno,0),nvl(hd.amount,0)as Salary from hrm_sd_confirmation hd,employee_master em,department_mst dp,designation_master dm,employee_master_dtl ed where hd.emp_code=em.emp_code and hd.dep_id=dp.dep_id and em.designation_id=dm.designation_id and hd.emp_code=ed.emp_code and (hd.given_status=0 or hd.given_status is null) and hd.given_status<>1 and hd.all_id=1 order by dep_name,emp_code"
            ElseIf type = 2 And depid <> 0 Then   'Incentive with dept
                str = "select dp.dep_name,em.emp_code,em.emp_name,dm.designation,nvl(ed.sdno,0),nvl(hd.amount,0)as Salary from hrm_sd_confirmation hd,employee_master em,department_mst dp,designation_master dm,employee_master_dtl ed where hd.emp_code=em.emp_code and hd.dep_id=dp.dep_id and em.designation_id=dm.designation_id and hd.emp_code=ed.emp_code and (hd.given_status=0 or hd.given_status is null) and hd.given_status<>1 and hd.all_id=1 and hd.dep_id=" & Me.Request.QueryString("depid") & " order by dep_name,emp_code"
            End If
        End If

        dt = oh.ExecuteDataSet(str).Tables(0)




        If dt.Rows.Count > 0 Then


            Dim header As New TableRow
            header.Width = 7
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            Dim headercell As New TableCell
            headercell.ColumnSpan = 7
            headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
            headercell.HorizontalAlign = HorizontalAlign.Center
            header.Controls.Add(headercell)
            sdtable.Controls.Add(header)

            Dim sheader As New TableRow
            sheader.BackColor = Drawing.Color.LightGray
            Dim sheadercell1 As New TableCell
            Dim sheadercell2 As New TableCell
            sheadercell1.ColumnSpan = 7
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
            sheader.Controls.Add(sheadercell1)
            sdtable.Controls.Add(sheader)

            Dim s As String = oh.ExecuteDataSet("select distinct to_char(to_date(s.sal_dt),'MONTH') from salari s").Tables(0).Rows(0)(0)

            Dim y As Integer = oh.ExecuteDataSet("select distinct to_char(to_date(s.sal_dt),'YYYY') from salari s").Tables(0).Rows(0)(0)

            Dim tt As New TableRow
            tt.BackColor = Drawing.Color.LightSkyBlue
            tt.Width = 7
            Dim tt1 As New TableCell
            tt1.ColumnSpan = 7
            tt1.HorizontalAlign = HorizontalAlign.Center
            tt1.Text = "<b><font size=2>Departmentwise SD Confirmed And/Or Not Confirmed list of Salary or Incentives of " & s & " " & y & " </font></b>"
            tt.Controls.Add(tt1)
            sdtable.Controls.Add(tt)

            Dim subh As New TableRow
            Dim subcell1 As New TableCell
            Dim subcell2 As New TableCell
            Dim subcell3 As New TableCell
            subh.Width = 7

            subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
            subcell1.ColumnSpan = 2
            subcell1.HorizontalAlign = HorizontalAlign.Left
            subh.Controls.Add(subcell1)

            subcell2.ColumnSpan = 3
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
            linecell.ColumnSpan = 7
            linecell.Text = "<hr>"
            line.Controls.Add(linecell)
            sdtable.Controls.Add(line)


            colors = "#fff7ff"




            Dim dep_name As String = ""

            For Each dr In dt.Rows

                i += 1

                If dep_name <> dr(0).ToString Then

                    Dim deprow As New TableRow
                    deprow.Width = 7
                    Dim deprowcell As New TableCell
                    deprowcell.ColumnSpan = 7
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
                value.Width = 7
                value.Attributes.Add("bgcolor", colors)
                Dim v1, v2, v3, va, v4 As New TableCell

                v1.ColumnSpan = 1        'Empcode
                v1.HorizontalAlign = HorizontalAlign.Left
                v1.Text = "<a href=sd_empwise_ta_sal_report.aspx?empcode=" & dr(1) & "&type=" & Me.Request.QueryString("type") & "><font size=2><b>" & dr(1) & "&nbsp;</b></font></a>"
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

                va.ColumnSpan = 1    'SD Number
                va.HorizontalAlign = HorizontalAlign.Left
                If dr(4) <> 0 Then
                    va.Text = "<font size=2>" & dr(4) & "&nbsp;</font>"
                ElseIf dr(4) = 0 Then
                    va.Text = "<font size=2>Not Entered!&nbsp;</font>"
                End If
                value.Controls.Add(va)

                v4.ColumnSpan = 1   'Amount
                v4.HorizontalAlign = HorizontalAlign.Right
                v4.Text = "<font size=2>" & FormatNumber(dr(5), 2) & "&nbsp;</font>"
                value.Controls.Add(v4)

                total += dr(5)

                sdtable.Controls.Add(value)

            Next

            Dim line4 As New TableRow
            Dim linecell4 As New TableCell
            linecell4.ColumnSpan = 7
            linecell4.Text = "<hr>"
            line4.Controls.Add(linecell4)
            sdtable.Controls.Add(line4)


            Dim qlast As New TableRow
            qlast.Width = 7
            Dim q As New TableCell
            q.ColumnSpan = 7
            q.HorizontalAlign = HorizontalAlign.Left
            q.Text = "<font size=2>Total:&nbsp;<b>" & Me.i & "</b>&nbsp;Employee Record(s) and Sum of Total&nbsp;=&nbsp;<b>" & FormatNumber(Me.total, 2) & "</b>&nbsp;Rupees.<font>"
            qlast.Controls.Add(q)
            sdtable.Controls.Add(qlast)


        Else

            Dim warn As New TableRow
            warn.Width = 7
            Dim w1 As New TableCell
            w1.ColumnSpan = 7
            w1.HorizontalAlign = HorizontalAlign.Center
            w1.Text = "<b><font size=3> No Data !!</font></b>"
            warn.Controls.Add(w1)
            sdtable.Controls.Add(warn)

        End If

        Panel_Sd_Sal_inc.Controls.Add(sdtable)

    End Sub

    Sub fill()
        Dim row2 As New TableRow
        row2.Width = 7
        row2.Attributes.Add("bgcolor", colors)
        Dim r1, r2, r3, ra, r4 As New TableCell

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

        ra.ColumnSpan = 1
        ra.HorizontalAlign = HorizontalAlign.Left
        ra.Text = "<b><font size=2>S.D&nbsp;Number&nbsp;</font></b>"
        row2.Controls.Add(ra)

        r4.ColumnSpan = 1
        r4.HorizontalAlign = HorizontalAlign.Center
        If Me.Request.QueryString("type") = 1 Then
            r4.Text = "<b><font size=2>Salary&nbsp;</font></b>"
        ElseIf Me.Request.QueryString("type") = 2 Then
            r4.Text = "<b><font size=2>Incentives&nbsp;</font></b>"
        End If
        row2.Controls.Add(r4)

        sdtable.Controls.Add(row2)
    End Sub


End Class
