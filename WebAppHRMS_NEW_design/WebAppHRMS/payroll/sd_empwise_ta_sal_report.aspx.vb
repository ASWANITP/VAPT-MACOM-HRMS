Imports System.Data
Imports System.Data.OracleClient
Partial Class sd_sal_ta_report_sd_empwise_ta_sal_report_1b5c3feb5272
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim total As Double = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim empcode As Integer = Me.Request.QueryString("empcode")
        Dim type As Integer = Me.Request.QueryString("type")

        'str = "select em.emp_code,em.emp_name,im.all_name as name,nvl(hd.amount,0) from incentives_allowances_master im,hrm_sd_confirmation hd,employee_master em where hd.emp_code=em.emp_code and hd.all_id=im.all_id and hd.emp_code=" & Request.QueryString("empcode") & "and hd.given_status=1 and hd.process_status=1"
        If type = 1 Then
            '                   0           1           2              3              4              5               6                  7                    8                  9                10                 11              12              13             14                15            16              17               18              19            20           21              22             23                  24                25                26            27           28          29
            'str = "select em.emp_code,em.emp_name,fm.firm_abbr,dm.designation,dp.dep_name,nvl(s.basic_pay,0),nvl(s.vda,0),nvl(s.ovt_wages,0),nvl(s.arrear_sal,0),nvl(s.arrear_da,0),nvl(s.oth_add,0),nvl(s.wages_pble,0),nvl(s.w_days,0),nvl(s.l_days,0),nvl(s.lop,0),nvl(s.gross_sal,0),nvl(s.p_fund,0),nvl(s.esi,0),nvl(s.s_w_fund,0),nvl(s.l_w_fund,0),nvl(s.p_tax,0),nvl(s.lic,0),nvl(s.tds,0),nvl(s.oth_ded,0),nvl(s.rdded_amt,0),nvl(s.tot_dedu,0),nvl(s.net_pay,0),nvl(s.cutting,0),nvl(s.bonus,0),m.sal_dt from employee_master em,hrm_sd_confirmation hd,salari s,m_wage m,department_mst dp,designation_master dm,firm_master fm where em.emp_code=hd.emp_code and em.emp_code=s.emp_id and em.emp_code=m.emp_code and em.emp_code=" & Me.Request.QueryString("empcode") & " and m.department_id=dp.dep_id and m.designation_id=dm.designation_id and hd.all_id=0 and hd.given_status=1 and hd.process_status=1 and m.firm_id=fm.firm_id"
            'hd.process_status=1 is eliminated
            str = "select em.emp_code,em.emp_name,fm.firm_abbr,dm.designation,dp.dep_name,nvl(s.basic_pay,0),nvl(s.vda,0),nvl(s.ovt_wages,0),nvl(s.arrear_sal,0),nvl(s.arrear_da,0),nvl(s.oth_add,0),nvl(s.wages_pble,0),nvl(s.w_days,0),nvl(s.l_days,0),nvl(s.lop,0),nvl(s.gross_sal,0),nvl(s.p_fund,0),nvl(s.esi,0),nvl(s.s_w_fund,0),nvl(s.l_w_fund,0),nvl(s.p_tax,0),nvl(s.lic,0),nvl(s.tds,0),nvl(s.oth_ded,0),nvl(s.rdded_amt,0),nvl(s.tot_dedu,0),nvl(s.net_pay,0),nvl(s.cutting,0),nvl(s.bonus,0),m.sal_dt from employee_master em,hrm_sd_confirmation hd,salari s,m_wage m,department_mst dp,designation_master dm,firm_master fm where em.emp_code=hd.emp_code and em.emp_code=s.emp_id and em.emp_code=m.emp_code and em.emp_code=" & Me.Request.QueryString("empcode") & " and m.department_id=dp.dep_id and m.designation_id=dm.designation_id and hd.all_id=0 and hd.given_status=1 and m.firm_id=fm.firm_id"
        ElseIf type = 2 Then

            'str = "select em.emp_code,em.emp_name,im.all_name as name,nvl(id.all_amount,0) from incentives_allowances_master im,incentives_allowances_dtl id,employee_master em,hrm_sd_confirmation hd where im.all_id=id.all_id and id.emp_code=em.emp_code and id.emp_code=hd.emp_code and hd.all_id=1 and hd.given_status=1 and hd.process_status=1 and id.emp_code=" & Request.QueryString("empcode") & ""
            'hd.process_status=1 is eliminated
            str = "select em.emp_code,em.emp_name,im.all_name as name,nvl(id.all_amount,0) from incentives_allowances_master im,incentives_allowances_dtl id,employee_master em,hrm_sd_confirmation hd where im.all_id=id.all_id and id.emp_code=em.emp_code and id.emp_code=hd.emp_code and hd.all_id=1 and hd.given_status=1 and id.emp_code=" & Request.QueryString("empcode") & ""
        End If
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
            If type = 1 Then
                hh1.Text = "<body align=center><b><font size=2.5> SD Confirmed Salary Details of " & Me.Request.QueryString("empcode") & " </font></b></body>"
            ElseIf type = 2 Then
                hh1.Text = "<body align=center><b><font size=2.5> SD Confirmed List of Allowances and Incentives of " & Me.Request.QueryString("empcode") & " </font></b></body>"
            End If
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
            If type = 1 Then   '.............Salary...!!!!..........

                Dim empf As New TableRow
                Dim empf1, empf2, empf3 As New TableCell
                empn.Width = 4
                empf1.ColumnSpan = 2
                empf2.ColumnSpan = 1
                empf3.ColumnSpan = 1
                empf1.HorizontalAlign = HorizontalAlign.Left
                empf2.HorizontalAlign = HorizontalAlign.Center
                empf3.HorizontalAlign = HorizontalAlign.Left
                empf1.Text = "<b><font size=2>Employee&nbsp;Firm&nbsp;</font></b>"
                empf2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                empf3.Text = "<font size=2>" & dt.Rows(0)(2) & "<font>"
                empf.Controls.Add(empf1)
                empf.Controls.Add(empf2)
                empf.Controls.Add(empf3)
                sdemptable.Controls.Add(empf)

                Dim empdes As New TableRow
                Dim empdes1, empdes2, empdes3 As New TableCell
                empdes.Width = 4
                empdes1.ColumnSpan = 2
                empdes2.ColumnSpan = 1
                empdes3.ColumnSpan = 1
                empdes1.HorizontalAlign = HorizontalAlign.Left
                empdes2.HorizontalAlign = HorizontalAlign.Center
                empdes3.HorizontalAlign = HorizontalAlign.Left
                empdes1.Text = "<b><font size=2>Employee&nbsp;Designation&nbsp;</font></b>"
                empdes2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                empdes3.Text = "<font size=2>" & dt.Rows(0)(3) & "<font>"
                empdes.Controls.Add(empdes1)
                empdes.Controls.Add(empdes2)
                empdes.Controls.Add(empdes3)
                sdemptable.Controls.Add(empdes)

                Dim empdep As New TableRow
                Dim empdep1, empdep2, empdep3 As New TableCell
                empdep.Width = 4
                empdep1.ColumnSpan = 2
                empdep2.ColumnSpan = 1
                empdep3.ColumnSpan = 1
                empdep1.HorizontalAlign = HorizontalAlign.Left
                empdep2.HorizontalAlign = HorizontalAlign.Center
                empdep3.HorizontalAlign = HorizontalAlign.Left
                empdep1.Text = "<b><font size=2>Employee&nbsp;Department&nbsp;</font></b>"
                empdep2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                empdep3.Text = "<font size=2>" & dt.Rows(0)(4) & "<font>"
                empdep.Controls.Add(empdep1)
                empdep.Controls.Add(empdep2)
                empdep.Controls.Add(empdep3)
                sdemptable.Controls.Add(empdep)

                Dim empbas As New TableRow  'basic pay
                Dim empbas1, empbas2, empbas3 As New TableCell
                empbas.Width = 4
                empbas1.ColumnSpan = 2
                empbas2.ColumnSpan = 1
                empbas3.ColumnSpan = 1
                empbas1.HorizontalAlign = HorizontalAlign.Left
                empbas2.HorizontalAlign = HorizontalAlign.Center
                empbas3.HorizontalAlign = HorizontalAlign.Right
                empbas1.Text = "<b><font size=2>Basic&nbsp;Pay&nbsp;</font></b>"
                empbas2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                empbas3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(5), 2) & "<font>"
                empbas.Controls.Add(empbas1)
                empbas.Controls.Add(empbas2)
                empbas.Controls.Add(empbas3)
                sdemptable.Controls.Add(empbas)

                Dim empbvda As New TableRow    'vda 
                Dim empbvda1, empbvda2, empbvda3 As New TableCell
                empbvda.Width = 4
                empbvda1.ColumnSpan = 2
                empbvda2.ColumnSpan = 1
                empbvda3.ColumnSpan = 1
                empbvda1.HorizontalAlign = HorizontalAlign.Left
                empbvda2.HorizontalAlign = HorizontalAlign.Center
                empbvda3.HorizontalAlign = HorizontalAlign.Right
                empbvda1.Text = "<b><font size=2>V.D.A&nbsp;</font></b>"
                empbvda2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                empbvda3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(6), 2) & "<font>"
                empbvda.Controls.Add(empbvda1)
                empbvda.Controls.Add(empbvda2)
                empbvda.Controls.Add(empbvda3)
                sdemptable.Controls.Add(empbvda)

                Dim ovtwage As New TableRow           'ovt wages
                Dim ovtwage1, ovtwage2, ovtwage3 As New TableCell
                ovtwage.Width = 4
                ovtwage1.ColumnSpan = 2
                ovtwage2.ColumnSpan = 1
                ovtwage3.ColumnSpan = 1
                ovtwage1.HorizontalAlign = HorizontalAlign.Left
                ovtwage2.HorizontalAlign = HorizontalAlign.Center
                ovtwage3.HorizontalAlign = HorizontalAlign.Right
                ovtwage1.Text = "<b><font size=2>Overtime&nbsp;Wages&nbsp;</font></b>"
                ovtwage2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                ovtwage3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(7), 2) & "<font>"
                ovtwage.Controls.Add(ovtwage1)
                ovtwage.Controls.Add(ovtwage2)
                ovtwage.Controls.Add(ovtwage3)
                sdemptable.Controls.Add(ovtwage)

                Dim arrsal As New TableRow         'arrear sal
                Dim arrsal1, arrsal2, arrsal3 As New TableCell
                arrsal.Width = 4
                arrsal1.ColumnSpan = 2
                arrsal2.ColumnSpan = 1
                arrsal3.ColumnSpan = 1
                arrsal1.HorizontalAlign = HorizontalAlign.Left
                arrsal2.HorizontalAlign = HorizontalAlign.Center
                arrsal3.HorizontalAlign = HorizontalAlign.Right
                arrsal1.Text = "<b><font size=2>Arrear&nbsp;Salary&nbsp;</font></b>"
                arrsal2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                arrsal3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(8), 2) & "<font>"
                arrsal.Controls.Add(arrsal1)
                arrsal.Controls.Add(arrsal2)
                arrsal.Controls.Add(arrsal3)
                sdemptable.Controls.Add(arrsal)

                Dim arrda As New TableRow   'arrear da
                Dim arrda1, arrda2, arrda3 As New TableCell
                arrda.Width = 4
                arrda1.ColumnSpan = 2
                arrda2.ColumnSpan = 1
                arrda3.ColumnSpan = 1
                arrda1.HorizontalAlign = HorizontalAlign.Left
                arrda2.HorizontalAlign = HorizontalAlign.Center
                arrda3.HorizontalAlign = HorizontalAlign.Right
                arrda1.Text = "<b><font size=2>Arrear&nbsp;D.A&nbsp;</font></b>"
                arrda2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                arrda3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(9), 2) & "<font>"
                arrda.Controls.Add(arrda1)
                arrda.Controls.Add(arrda2)
                arrda.Controls.Add(arrda3)
                sdemptable.Controls.Add(arrda)


                Dim othadd As New TableRow      'oth_additions
                Dim othadd1, othadd2, othadd3 As New TableCell
                othadd.Width = 4
                othadd1.ColumnSpan = 2
                othadd2.ColumnSpan = 1
                othadd3.ColumnSpan = 1
                othadd1.HorizontalAlign = HorizontalAlign.Left
                othadd2.HorizontalAlign = HorizontalAlign.Center
                othadd3.HorizontalAlign = HorizontalAlign.Right
                othadd1.Text = "<b><font size=2>Other&nbsp;Additions&nbsp;</font></b>"
                othadd2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                othadd3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(10), 2) & "<font>"
                othadd.Controls.Add(othadd1)
                othadd.Controls.Add(othadd2)
                othadd.Controls.Add(othadd3)
                sdemptable.Controls.Add(othadd)


                Dim wpayb As New TableRow        'Wages_payable
                Dim wpayb1, wpayb2, wpayb3 As New TableCell
                wpayb.Width = 4
                wpayb1.ColumnSpan = 2
                wpayb2.ColumnSpan = 1
                wpayb3.ColumnSpan = 1
                wpayb1.HorizontalAlign = HorizontalAlign.Left
                wpayb2.HorizontalAlign = HorizontalAlign.Center
                wpayb3.HorizontalAlign = HorizontalAlign.Right
                wpayb1.Text = "<b><font size=2>Wages&nbsp;Payable&nbsp;</font></b>"
                wpayb2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                wpayb3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(11), 2) & "<font>"
                wpayb.Controls.Add(wpayb1)
                wpayb.Controls.Add(wpayb2)
                wpayb.Controls.Add(wpayb3)
                sdemptable.Controls.Add(wpayb)


                Dim wdays As New TableRow   'Work Days
                Dim wdays1, wdays2, wdays3 As New TableCell
                wdays.Width = 4
                wdays1.ColumnSpan = 2
                wdays2.ColumnSpan = 1
                wdays3.ColumnSpan = 1
                wdays1.HorizontalAlign = HorizontalAlign.Left
                wdays2.HorizontalAlign = HorizontalAlign.Center
                wdays3.HorizontalAlign = HorizontalAlign.Right
                wdays1.Text = "<b><font size=2>Work&nbsp;Days&nbsp;</font></b>"
                wdays2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                wdays3.Text = "<font size=2>" & dt.Rows(0)(12) & "<font>"
                wdays.Controls.Add(wdays1)
                wdays.Controls.Add(wdays2)
                wdays.Controls.Add(wdays3)
                sdemptable.Controls.Add(wdays)


                Dim ldays As New TableRow     'Leave Days
                Dim ldays1, ldays2, ldays3 As New TableCell
                ldays.Width = 4
                ldays1.ColumnSpan = 2
                ldays2.ColumnSpan = 1
                ldays3.ColumnSpan = 1
                ldays1.HorizontalAlign = HorizontalAlign.Left
                ldays2.HorizontalAlign = HorizontalAlign.Center
                ldays3.HorizontalAlign = HorizontalAlign.Right
                ldays1.Text = "<b><font size=2>Leave&nbsp;Days&nbsp;</font></b>"
                ldays2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                ldays3.Text = "<font size=2>" & dt.Rows(0)(13) & "<font>"
                ldays.Controls.Add(ldays1)
                ldays.Controls.Add(ldays2)
                ldays.Controls.Add(ldays3)
                sdemptable.Controls.Add(ldays)


                Dim lop As New TableRow    'LOP
                Dim lop1, lop2, lop3 As New TableCell
                lop.Width = 4
                lop1.ColumnSpan = 2
                lop2.ColumnSpan = 1
                lop3.ColumnSpan = 1
                lop1.HorizontalAlign = HorizontalAlign.Left
                lop2.HorizontalAlign = HorizontalAlign.Center
                lop3.HorizontalAlign = HorizontalAlign.Right
                lop1.Text = "<b><font size=2>L.O.P&nbsp;</font></b>"
                lop2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                lop3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(14), 2) & "<font>"
                lop.Controls.Add(lop1)
                lop.Controls.Add(lop2)
                lop.Controls.Add(lop3)
                sdemptable.Controls.Add(lop)


                Dim gsal As New TableRow       'Gross sal
                Dim gsal1, gsal2, gsal3 As New TableCell
                gsal.Width = 4
                gsal1.ColumnSpan = 2
                gsal2.ColumnSpan = 1
                gsal3.ColumnSpan = 1
                gsal1.HorizontalAlign = HorizontalAlign.Left
                gsal2.HorizontalAlign = HorizontalAlign.Center
                gsal3.HorizontalAlign = HorizontalAlign.Right
                gsal1.Text = "<b><font size=2>Gross&nbsp;Salary&nbsp;</font></b>"
                gsal2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                gsal3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(15), 2) & "<font>"
                gsal.Controls.Add(gsal1)
                gsal.Controls.Add(gsal2)
                gsal.Controls.Add(gsal3)
                sdemptable.Controls.Add(gsal)


                Dim pf As New TableRow       'P Fund
                Dim pf1, pf2, pf3 As New TableCell
                pf.Width = 4
                pf1.ColumnSpan = 2
                pf2.ColumnSpan = 1
                pf3.ColumnSpan = 1
                pf1.HorizontalAlign = HorizontalAlign.Left
                pf2.HorizontalAlign = HorizontalAlign.Center
                pf3.HorizontalAlign = HorizontalAlign.Right
                pf1.Text = "<b><font size=2>Provident&nbsp;Fund&nbsp(P.F)&nbsp;</font></b>"
                pf2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                pf3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(16), 2) & "<font>"
                pf.Controls.Add(pf1)
                pf.Controls.Add(pf2)
                pf.Controls.Add(pf3)
                sdemptable.Controls.Add(pf)


                Dim esi As New TableRow       'Esi
                Dim esi1, esi2, esi3 As New TableCell
                esi.Width = 4
                esi1.ColumnSpan = 2
                esi2.ColumnSpan = 1
                esi3.ColumnSpan = 1
                esi1.HorizontalAlign = HorizontalAlign.Left
                esi2.HorizontalAlign = HorizontalAlign.Center
                esi3.HorizontalAlign = HorizontalAlign.Right
                esi1.Text = "<b><font size=2>E.S.I&nbsp;</font></b>"
                esi2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                esi3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(17), 2) & "<font>"
                esi.Controls.Add(esi1)
                esi.Controls.Add(esi2)
                esi.Controls.Add(esi3)
                sdemptable.Controls.Add(esi)


                Dim swfnd As New TableRow    'sw fund
                Dim swfnd1, swfnd2, swfnd3 As New TableCell
                swfnd.Width = 4
                swfnd1.ColumnSpan = 2
                swfnd2.ColumnSpan = 1
                swfnd3.ColumnSpan = 1
                swfnd1.HorizontalAlign = HorizontalAlign.Left
                swfnd2.HorizontalAlign = HorizontalAlign.Center
                swfnd3.HorizontalAlign = HorizontalAlign.Right
                swfnd1.Text = "<b><font size=2>Staff&nbsp;Welfare&nbsp;Fund&nbsp;</font></b>"
                swfnd2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                swfnd3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(18), 2) & "<font>"
                swfnd.Controls.Add(swfnd1)
                swfnd.Controls.Add(swfnd2)
                swfnd.Controls.Add(swfnd3)
                sdemptable.Controls.Add(swfnd)


                Dim lwfnd As New TableRow     'LW fund
                Dim lwfnd1, lwfnd2, lwfnd3 As New TableCell
                lwfnd.Width = 4
                lwfnd1.ColumnSpan = 2
                lwfnd2.ColumnSpan = 1
                lwfnd3.ColumnSpan = 1
                lwfnd1.HorizontalAlign = HorizontalAlign.Left
                lwfnd2.HorizontalAlign = HorizontalAlign.Center
                lwfnd3.HorizontalAlign = HorizontalAlign.Right
                lwfnd1.Text = "<b><font size=2>Labour&nbsp;Welfare&nbsp;Fund&nbsp;</font></b>"
                lwfnd2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                lwfnd3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(19), 2) & "<font>"
                lwfnd.Controls.Add(lwfnd1)
                lwfnd.Controls.Add(lwfnd2)
                lwfnd.Controls.Add(lwfnd3)
                sdemptable.Controls.Add(lwfnd)


                Dim ptax As New TableRow      'Ptax
                Dim ptax1, ptax2, ptax3 As New TableCell
                ptax.Width = 4
                ptax1.ColumnSpan = 2
                ptax2.ColumnSpan = 1
                ptax3.ColumnSpan = 1
                ptax1.HorizontalAlign = HorizontalAlign.Left
                ptax2.HorizontalAlign = HorizontalAlign.Center
                ptax3.HorizontalAlign = HorizontalAlign.Right
                ptax1.Text = "<b><font size=2>Professional&nbsp;Tax&nbsp;</font></b>"
                ptax2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                ptax3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(20), 2) & "<font>"
                ptax.Controls.Add(ptax1)
                ptax.Controls.Add(ptax2)
                ptax.Controls.Add(ptax3)
                sdemptable.Controls.Add(ptax)


                Dim lic As New TableRow   'LIC
                Dim lic1, lic2, lic3 As New TableCell
                lic.Width = 4
                lic1.ColumnSpan = 2
                lic2.ColumnSpan = 1
                lic3.ColumnSpan = 1
                lic1.HorizontalAlign = HorizontalAlign.Left
                lic2.HorizontalAlign = HorizontalAlign.Center
                lic3.HorizontalAlign = HorizontalAlign.Right
                lic1.Text = "<b><font size=2>L.I.C&nbsp;</font></b>"
                lic2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                lic3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(21), 2) & "<font>"
                lic.Controls.Add(lic1)
                lic.Controls.Add(lic2)
                lic.Controls.Add(lic3)
                sdemptable.Controls.Add(lic)


                Dim tds As New TableRow        'TDS
                Dim tds1, tds2, tds3 As New TableCell
                tds.Width = 4
                tds1.ColumnSpan = 2
                tds2.ColumnSpan = 1
                tds3.ColumnSpan = 1
                tds1.HorizontalAlign = HorizontalAlign.Left
                tds2.HorizontalAlign = HorizontalAlign.Center
                tds3.HorizontalAlign = HorizontalAlign.Right
                tds1.Text = "<b><font size=2>T.D.S&nbsp;</font></b>"
                tds2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                tds3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(22), 2) & "<font>"
                tds.Controls.Add(tds1)
                tds.Controls.Add(tds2)
                tds.Controls.Add(tds3)
                sdemptable.Controls.Add(tds)


                Dim othded As New TableRow    'Other Deducton
                Dim othded1, othded2, othded3 As New TableCell
                othded.Width = 4
                othded1.ColumnSpan = 2
                othded2.ColumnSpan = 1
                othded3.ColumnSpan = 1
                othded1.HorizontalAlign = HorizontalAlign.Left
                othded2.HorizontalAlign = HorizontalAlign.Center
                othded3.HorizontalAlign = HorizontalAlign.Right
                othded1.Text = "<b><font size=2>Other&nbsp;Deduction&nbsp;</font></b>"
                othded2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                othded3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(23), 2) & "<font>"
                othded.Controls.Add(othded1)
                othded.Controls.Add(othded2)
                othded.Controls.Add(othded3)
                sdemptable.Controls.Add(othded)


                Dim rdded As New TableRow        'RD Deduction
                Dim rdded1, rdded2, rdded3 As New TableCell
                rdded.Width = 4
                rdded1.ColumnSpan = 2
                rdded2.ColumnSpan = 1
                rdded3.ColumnSpan = 1
                rdded1.HorizontalAlign = HorizontalAlign.Left
                rdded2.HorizontalAlign = HorizontalAlign.Center
                rdded3.HorizontalAlign = HorizontalAlign.Right
                rdded1.Text = "<b><font size=2>R.D&nbsp;Deduction&nbsp;</font></b>"
                rdded2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                rdded3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(24), 2) & "<font>"
                rdded.Controls.Add(rdded1)
                rdded.Controls.Add(rdded2)
                rdded.Controls.Add(rdded3)
                sdemptable.Controls.Add(rdded)


                Dim totded As New TableRow  'Total Deductin
                Dim totded1, totded2, totded3 As New TableCell
                totded.Width = 4
                totded1.ColumnSpan = 2
                totded2.ColumnSpan = 1
                totded3.ColumnSpan = 1
                totded1.HorizontalAlign = HorizontalAlign.Left
                totded2.HorizontalAlign = HorizontalAlign.Center
                totded3.HorizontalAlign = HorizontalAlign.Right
                totded1.Text = "<b><font size=2>Total&nbsp;Deduction&nbsp;</font></b>"
                totded2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                totded3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(25), 2) & "<font>"
                totded.Controls.Add(totded1)
                totded.Controls.Add(totded2)
                totded.Controls.Add(totded3)
                sdemptable.Controls.Add(totded)


                Dim ntpy As New TableRow        'Netpay
                Dim ntpy1, ntpy2, ntpy3 As New TableCell
                ntpy.Width = 4
                ntpy1.ColumnSpan = 2
                ntpy2.ColumnSpan = 1
                ntpy3.ColumnSpan = 1
                ntpy1.HorizontalAlign = HorizontalAlign.Left
                ntpy2.HorizontalAlign = HorizontalAlign.Center
                ntpy3.HorizontalAlign = HorizontalAlign.Right
                ntpy1.Text = "<b><font size=2>Net&nbsp;Pay&nbsp;</font></b>"
                ntpy2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                ntpy3.Text = "<b><font size=2>" & FormatNumber(dt.Rows(0)(26), 2) & "<font></b>"
                ntpy.Controls.Add(ntpy1)
                ntpy.Controls.Add(ntpy2)
                ntpy.Controls.Add(ntpy3)
                sdemptable.Controls.Add(ntpy)


                Dim cttig As New TableRow                      'Cutting
                Dim cttig1, cttig2, cttig3 As New TableCell
                cttig.Width = 4
                cttig1.ColumnSpan = 2
                cttig2.ColumnSpan = 1
                cttig3.ColumnSpan = 1
                cttig1.HorizontalAlign = HorizontalAlign.Left
                cttig2.HorizontalAlign = HorizontalAlign.Center
                cttig3.HorizontalAlign = HorizontalAlign.Right
                cttig1.Text = "<b><font size=2>Salary&nbsp;Cutting&nbsp;</font></b>"
                cttig2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                cttig3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(27), 2) & "<font>"
                cttig.Controls.Add(cttig1)
                cttig.Controls.Add(cttig2)
                cttig.Controls.Add(cttig3)
                sdemptable.Controls.Add(cttig)


                Dim bnus As New TableRow          'Bonus
                Dim bnus1, bnus2, bnus3 As New TableCell
                bnus.Width = 4
                bnus1.ColumnSpan = 2
                bnus2.ColumnSpan = 1
                bnus3.ColumnSpan = 1
                bnus1.HorizontalAlign = HorizontalAlign.Left
                bnus2.HorizontalAlign = HorizontalAlign.Center
                bnus3.HorizontalAlign = HorizontalAlign.Right
                bnus1.Text = "<b><font size=2>Bonus&nbsp</font></b>"
                bnus2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                bnus3.Text = "<font size=2>" & FormatNumber(dt.Rows(0)(28), 2) & "<font>"
                bnus.Controls.Add(bnus1)
                bnus.Controls.Add(bnus2)
                bnus.Controls.Add(bnus3)
                sdemptable.Controls.Add(bnus)

                Dim saldt As New TableRow          'sal_date
                Dim saldt1, saldt2, saldt3 As New TableCell
                saldt.Width = 4
                saldt1.ColumnSpan = 2
                saldt2.ColumnSpan = 1
                saldt3.ColumnSpan = 1
                saldt1.HorizontalAlign = HorizontalAlign.Left
                saldt2.HorizontalAlign = HorizontalAlign.Center
                saldt3.HorizontalAlign = HorizontalAlign.Left
                saldt1.Text = "<b><font size=2>Salary&nbsp;Date&nbsp;</font></b>"
                saldt2.Text = "<b><font size=2>&nbsp;:&nbsp;</font></b>"
                If Not IsDBNull(dt.Rows(0)(29)) Then
                    saldt3.Text = "<font size=2>" & Format(dt.Rows(0)(29), "dd-MMM-yyyy") & "<font>"
                Else
                    saldt3.Text = "<font size=2>Not Specified!!<font>"
                End If
                saldt.Controls.Add(saldt1)
                saldt.Controls.Add(saldt2)
                saldt.Controls.Add(saldt3)
                sdemptable.Controls.Add(saldt)


            ElseIf type = 2 Then  '//////////Incentives.!!........../////////////////

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

            End If

            If type = 2 Then

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
                t3.Text = "<b><font size=2>" & FormatNumber(Me.total, 2) & "&nbsp;&nbsp;&nbsp;</font></b>"
                totr.Controls.Add(t1)
                totr.Controls.Add(t2)
                totr.Controls.Add(t3)
                sdemptable.Controls.Add(totr)


            End If



            '////////////////////////////////////////////////////////////////////////

            Panel_Empwise_sal_ta.Controls.Add(sdemptable)



        End If
    End Sub
End Class
