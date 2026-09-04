Imports System.Data
Imports System.Data.OracleClient
Partial Class fixed_TA_New_taspecial_4cf35cbe6475
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.Oraclehelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim i As Integer = 0
    Dim day As Integer = 0
    Dim ldays As Integer = 0
    Dim talimtotal As Double = 0
    Dim taelgtotal As Double = 0
    Dim fixedtatable As New Table
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '                  0            1             2            3             4         5            6          7          8                    9                             10                             11
        str = "select br.BRANCH_ID,  br.BRANCH_NAME,  a.emp_code,  em.emp_name,  dm.designation,  pm.post_name,  a.from_dt,  a.to_dt,  nvl(a.days, 0) days,  nvl(a.leave_days, 0) as Leave_days,  nvl(a.ta_limit, 0) as Ta_Limit,  nvl(a.ta_amt, 0) as Ta_Amount  from hr_fixed_ta        a,  employee_master    em,  post_mst           pm,  designation_master dm,  branch             br,  employ_firm f  where a.emp_code = em.emp_code  and em.emp_code=f.emp_code  and f.firm_id=" & Session("firm_id") & "  and a.post_id = pm.post_id  and a.desig_id = dm.designation_id  and a.branch_id = br.BRANCH_ID  and a.emp_code in (select emp_code from hrm_ta_constant_employees)  order by br.BRANCH_ID, a.from_dt, a.emp_code"
        dt = oh.ExecuteDataSet(str).Tables(0)
        If dt.Rows.Count > 0 Then

            'Me.fixedtatable.Attributes.Add("width", "80%")

            Dim header As New TableRow
            header.Width = 12
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            Dim headercell As New TableCell
            headercell.ColumnSpan = 12
            headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
            headercell.HorizontalAlign = HorizontalAlign.Center
            header.Controls.Add(headercell)
            fixedtatable.Controls.Add(header)

            Dim sheader As New TableRow
            sheader.BackColor = Drawing.Color.LightGray
            Dim sheadercell1 As New TableCell
            Dim sheadercell2 As New TableCell
            sheadercell1.ColumnSpan = 12
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<font size=2 ><b>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "&nbsp;</b></font>"
            sheader.Controls.Add(sheadercell1)
            fixedtatable.Controls.Add(sheader)

            Dim dtdet As String = oh.ExecuteDataSet("select distinct to_char(min(a.from_dt),'dd-Mon-yyyy')||' To '||to_char(max(a.to_dt),'dd-Mon-yyyy') from hr_fixed_ta a").Tables(0).Rows(0)(0)
            Dim newhead As New TableRow
            newhead.Width = 12
            Dim newcell As New TableCell
            newcell.ColumnSpan = 12
            newcell.HorizontalAlign = HorizontalAlign.Center
            newcell.Text = "<b><font size=2>Fixed TA for Special Employees Detailed Report of " & dtdet & "</font></b>"
            newhead.Controls.Add(newcell)
            fixedtatable.Controls.Add(newhead)

            Dim subh As New TableRow
            Dim subcell1 As New TableCell
            Dim subcell2 As New TableCell
            Dim subcell3 As New TableCell
            subh.Width = 12

            subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd-MMM-yyyy") & "</font></b>"
            subcell1.ColumnSpan = 2
            subcell1.HorizontalAlign = HorizontalAlign.Left
            subh.Controls.Add(subcell1)


            subcell2.ColumnSpan = 8
            subcell2.HorizontalAlign = HorizontalAlign.Center
            subcell2.Text = "<font size=2> <font>"
            subh.Controls.Add(subcell2)

            subcell3.ColumnSpan = 2
            subcell3.HorizontalAlign = HorizontalAlign.Left
            subcell3.Text = "<b><font size=2>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
            subcell3.HorizontalAlign = HorizontalAlign.Right
            subh.Controls.Add(subcell3)
            fixedtatable.Controls.Add(subh)

            Dim line As New TableRow
            Dim linecell As New TableCell
            linecell.ColumnSpan = 12
            linecell.Text = "<hr>"
            line.Controls.Add(linecell)
            fixedtatable.Controls.Add(line)

            Dim row2 As New TableRow
            row2.Width = 12
            Dim r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12 As New TableCell

            r11.ColumnSpan = 1
            r11.HorizontalAlign = HorizontalAlign.Center
            r11.Text = "<b><font size=2>BrID&nbsp;</font></b>"
            row2.Controls.Add(r11)

            r12.ColumnSpan = 1
            r12.HorizontalAlign = HorizontalAlign.Left
            r12.Text = "<b><font size=2>Branch&nbsp;Name&nbsp;</font></b>"
            row2.Controls.Add(r12)


            r1.ColumnSpan = 1
            r1.HorizontalAlign = HorizontalAlign.Left
            r1.Text = "<b><font size=2>Emp&nbsp;Code&nbsp;</font></b>"
            row2.Controls.Add(r1)

            r2.ColumnSpan = 1
            r2.HorizontalAlign = HorizontalAlign.Left
            r2.Text = "<b><font size=2>Employee&nbsp;Name&nbsp;</font></b>"
            row2.Controls.Add(r2)

            r3.ColumnSpan = 1
            r3.HorizontalAlign = HorizontalAlign.Left
            r3.Text = "<b><font size=2>Designation&nbsp;</font></b>"
            row2.Controls.Add(r3)

            r4.ColumnSpan = 1
            r4.HorizontalAlign = HorizontalAlign.Left
            r4.Text = "<b><font size=2>Post&nbsp;</font></b>"
            row2.Controls.Add(r4)

            r5.ColumnSpan = 1
            r5.HorizontalAlign = HorizontalAlign.Left
            r5.Text = "<b><font size=2>Date&nbsp;From&nbsp;</font></b>"
            row2.Controls.Add(r5)

            r6.ColumnSpan = 1
            r6.HorizontalAlign = HorizontalAlign.Left
            r6.Text = "<b><font size=2>Date&nbsp;To&nbsp;</font></b>"
            row2.Controls.Add(r6)

            r7.ColumnSpan = 1
            r7.HorizontalAlign = HorizontalAlign.Left
            r7.Text = "<b><font size=2>Days&nbsp;</font></b>"
            row2.Controls.Add(r7)

            r8.ColumnSpan = 1
            r8.HorizontalAlign = HorizontalAlign.Left
            r8.Text = "<b><font size=2>Leave&nbsp;Days&nbsp;</font></b>"
            row2.Controls.Add(r8)

            r9.ColumnSpan = 1
            r9.HorizontalAlign = HorizontalAlign.Left
            r9.Text = "<b><font size=2>TA&nbsp;Maximum&nbsp;</font></b>"
            row2.Controls.Add(r9)

            r10.ColumnSpan = 1
            r10.HorizontalAlign = HorizontalAlign.Left
            r10.Text = "<b><font size=2>TA&nbsp;Payable&nbsp;</font></b>"
            row2.Controls.Add(r10)


            fixedtatable.Controls.Add(row2)

            Dim lineu As New TableRow
            Dim linecellu As New TableCell
            linecellu.ColumnSpan = 12
            linecellu.Text = "<hr>"
            lineu.Controls.Add(linecellu)
            fixedtatable.Controls.Add(lineu)

            For Each dr In dt.Rows

                i += 1

                Dim value As New TableRow
                value.Width = 12
                Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12 As New TableCell

                v11.ColumnSpan = 1        'station Branch
                v11.HorizontalAlign = HorizontalAlign.Center
                v11.Text = "<font size=2>" & dr(0) & "&nbsp;</font>"
                value.Controls.Add(v11)

                v12.ColumnSpan = 1        'station Branch Name
                v12.HorizontalAlign = HorizontalAlign.Left
                v12.Text = "<font size=2>" & dr(1) & "&nbsp;</font>"
                value.Controls.Add(v12)

                v1.ColumnSpan = 1        'empcode
                v1.HorizontalAlign = HorizontalAlign.Center
                v1.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
                value.Controls.Add(v1)

                v2.ColumnSpan = 1        'emp Name
                v2.HorizontalAlign = HorizontalAlign.Left
                v2.Text = "<font size=2>" & dr(3) & "&nbsp;</font>"
                value.Controls.Add(v2)

                v3.ColumnSpan = 1        'Deswignation
                v3.HorizontalAlign = HorizontalAlign.Left
                v3.Text = "<font size=2>" & dr(4) & "&nbsp;</font>"
                value.Controls.Add(v3)

                v4.ColumnSpan = 1        'Post
                v4.HorizontalAlign = HorizontalAlign.Left
                v4.Text = "<font size=2>" & dr(5) & "&nbsp;</font>"
                value.Controls.Add(v4)

                v5.ColumnSpan = 1        'fromdate
                v5.HorizontalAlign = HorizontalAlign.Left
                v5.Text = "<font size=2>&nbsp;" & Format(dr(6), "dd-MMM-yyyy") & "&nbsp;</font>"
                value.Controls.Add(v5)

                v6.ColumnSpan = 1        'Todate
                v6.HorizontalAlign = HorizontalAlign.Left
                v6.Text = "<font size=2>" & Format(dr(7), "dd-MMM-yyyy") & "&nbsp;</font>"
                value.Controls.Add(v6)

                v7.ColumnSpan = 1        'Days
                v7.HorizontalAlign = HorizontalAlign.Center
                v7.Text = "<font size=2>" & dr(8) & "&nbsp;</font>"
                value.Controls.Add(v7)
                'Me.day += dr(8)


                v8.ColumnSpan = 1        'leavedays
                v8.HorizontalAlign = HorizontalAlign.Center
                v8.Text = "<font size=2>" & dr(9) & "&nbsp;</font>"
                value.Controls.Add(v8)
                'Me.ldays += dr(9)

                v9.ColumnSpan = 1        'talimtotal
                v9.HorizontalAlign = HorizontalAlign.Right
                v9.Text = "<font size=2>" & FormatNumber(dr(10), 2) & "&nbsp;</font>"
                value.Controls.Add(v9)
                Me.talimtotal += dr(10)

                v10.ColumnSpan = 1        'taelgtotal
                v10.HorizontalAlign = HorizontalAlign.Right
                v10.Text = "<font size=2>" & FormatNumber(dr(11), 2) & "&nbsp;</font>"
                value.Controls.Add(v10)
                Me.taelgtotal += dr(11)

                fixedtatable.Controls.Add(value)

            Next


            Dim line4 As New TableRow
            Dim linecell4 As New TableCell
            linecell4.ColumnSpan = 12
            linecell4.Text = "<hr>"
            line4.Controls.Add(linecell4)
            fixedtatable.Controls.Add(line4)


            Dim qlast As New TableRow
            qlast.Width = 12
            Dim q1, q2, q3, q4, q5, q6 As New TableCell

            q1.ColumnSpan = 6
            q1.HorizontalAlign = HorizontalAlign.Left
            q1.Text = "<font size=2>Total:&nbsp;<b>" & Me.i & "</b>&nbsp;Employee Record(s)<font>"
            qlast.Controls.Add(q1)

            q2.ColumnSpan = 1
            q2.HorizontalAlign = HorizontalAlign.Center
            q2.Text = "<font size=2><b> </b>&nbsp;<font>"
            qlast.Controls.Add(q2)

            q3.ColumnSpan = 1
            q3.HorizontalAlign = HorizontalAlign.Center
            q3.Text = "<font size=2><b> </b>&nbsp;<font>"
            qlast.Controls.Add(q3)

            q6.ColumnSpan = 2
            q6.HorizontalAlign = HorizontalAlign.Right
            q6.Text = "<font size=2><b> </b>&nbsp;<font>"
            qlast.Controls.Add(q6)

            q4.ColumnSpan = 1
            q4.HorizontalAlign = HorizontalAlign.Right
            q4.Text = "<font size=2><b>" & FormatNumber(Me.talimtotal, 2) & "</b>&nbsp;<font>"
            qlast.Controls.Add(q4)

            q5.ColumnSpan = 1
            q5.HorizontalAlign = HorizontalAlign.Right
            q5.Text = "<font size=2><b>" & FormatNumber(Me.taelgtotal, 2) & "</b>&nbsp;<font>"
            qlast.Controls.Add(q5)

            fixedtatable.Controls.Add(qlast)

            Dim linet As New TableRow
            Dim linecellt As New TableCell
            linecellt.ColumnSpan = 12
            linecellt.Text = "<hr>"
            linet.Controls.Add(linecellt)
            fixedtatable.Controls.Add(linet)

        Else

            Dim warn As New TableRow
            warn.Width = 8
            Dim w1 As New TableCell
            w1.ColumnSpan = 8
            w1.HorizontalAlign = HorizontalAlign.Center
            w1.Text = "<b><font size=3> No Data !!</font></b>"
            warn.Controls.Add(w1)
            fixedtatable.Controls.Add(warn)

        End If
        Panel_FxTASpec.Controls.Add(fixedtatable)
    End Sub
End Class
