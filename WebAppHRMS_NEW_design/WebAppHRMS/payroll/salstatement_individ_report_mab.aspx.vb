Imports System.Data
Imports System.Data.OracleClient
Partial Class salstatement_individ_report_5b1ae9dc8436
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2 As New DataTable
    Dim str, str1 As String
    Dim dr, dr1 As DataRow
    Dim oh As New Helper.Oracle.OracleHelper

    Dim empcode As Integer

    Dim saldate As Date
    Dim salarytable As New Table

    Dim basic As Double = 0
    Dim vda As Double = 0
    Dim arrsal As Double = 0
    Dim wagespayable As Double = 0
    Dim esi As Double = 0
    Dim pf As Double = 0
    Dim swf As Double = 0
    Dim lwf As Double = 0
    Dim lic As Double = 0
    Dim tds As Double = 0
    Dim othded As Double = 0
    Dim rdded As Double = 0
    Dim proftax As Double = 0
    Dim totalded As Double = 0
    Dim bonus As Double = 0
    Dim allowance As Double = 0
    Dim wagespaid As Double = 0
    Dim reccount As Double = 0
    Dim pagenonext As Double = 1
    Dim sino As Integer = 0
    Dim firm As String
    Dim fir As Integer
    Dim fmid As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.salarytable.Attributes.Add("width", "100%")
        'Me.salarytable.Attributes.Add("border", "1")
        Me.empcode = Me.Request.QueryString("empcode")
        firm = Session("firm_name")
        fir = Session("firm_id")
        dt2 = oh.ExecuteDataSet("select ef.firm_id from employee_master e,employ_firm ef where ef.emp_code=e.emp_code and e.emp_code=" & empcode & "").Tables(0)
        If dt2.Rows.Count = 0 Then
            Dim cl_script31 As New System.Text.StringBuilder(1, 500)
            cl_script31.Append("  alert('No Such Employee Exist');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script31.ToString, True)
            Exit Sub
        End If
        fmid = dt2.Rows(0)(0)
        If fmid <> fir Then
            Response.Redirect("../show_err.aspx")
        End If


        '                 0              1                2               3           ------- 4 --------------------------------------------------------------------------------                5              -----------6-----------------------------------           ----------------7--------------------------         8              9                10               11                  12         13          14               15             -----------------16--------------------------          17           -----------------18----------------                19           20            21       

        str = "select mw.emp_code, upper(mw.name), nvl(mw.basic_pay, 0), nvl(mw.vda, 0), (nvl(mw.ovt_wages, 0) + nvl(mw.arrear_sal, 0) + nvl(mw.arrear_da, 0) + nvl(mw.oth_add, 0)) as Arrear_salary,nvl(mw.min_wage_adj, 0)minwage, (nvl(mw.basic_pay, 0) + nvl(mw.vda, 0) +nvl(mw.ovt_wages, 0) + nvl(mw.arrear_sal, 0) + nvl(mw.arrear_da, 0) + nvl(mw.oth_add, 0)+nvl(mw.min_wage_adj, 0)+nvl(mw.lock_down_amount, 0))as wages_pble, (nvl(mw.w_days, 0) - nvl(mw.l_days, 0)) as Total_attendance, (nvl(mw.lop, 0) + nvl(mw.oth_ded, 0)++nvl(mw.shift_change, 0)) as oth_deduction, nvl(mw.p_fund, 0), nvl(mw.esi, 0), nvl(mw.s_w_fund, 0), nvl(mw.l_w_fund, 0), nvl(mw.p_tax, 0), nvl(mw.lic, 0), nvl(mw.tds, 0), nvl(mw.rdded_amt, 0), (nvl(mw.tot_dedu, 0) + nvl(mw.lop, 0)) as total_deduction, nvl(mw.bonus, 0), nvl(mw.ta_total, 0) allow, (nvl(mw.net_pay, 0) + nvl(mw.bonus, 0) + nvl(mw.ta_total, 0)) as WAGES_PAID, mw.sal_dt, dm.designation, fm.firm_abbr from employee_master em, m_wage mw left outer join employee_master_dtl ed on (mw.emp_code = ed.emp_code), designation_master dm, firm_master fm, salari s where mw.firm_id = fm.firm_id and fm.firm_id =2 and mw.designation_id = dm.designation_id and em.emp_code = mw.emp_code and mw.emp_code = s.emp_id and mw.emp_code =" & empcode & ""
        'str = "select mw.emp_code, upper(mw.name), nvl(mw.basic_pay, 0), nvl(mw.vda, 0), (nvl(mw.ovt_wages, 0) + nvl(mw.arrear_sal, 0) + nvl(mw.arrear_da, 0) + nvl(mw.oth_add, 0)) as Arrear_salary, nvl(mw.wages_pble, 0), (nvl(mw.w_days, 0) - nvl(mw.l_days, 0)) as Total_attendance, (nvl(mw.lop, 0) + nvl(mw.oth_ded, 0)) as oth_deduction, nvl(mw.p_fund, 0), nvl(mw.esi, 0), nvl(mw.s_w_fund, 0), nvl(mw.l_w_fund, 0), nvl(mw.p_tax, 0), nvl(mw.lic, 0), nvl(mw.tds, 0), nvl(mw.rdded_amt, 0), (nvl(mw.tot_dedu, 0) + nvl(mw.lop, 0)) as total_deduction, nvl(mw.bonus, 0), nvl(mw.ta_total,0)allow, (nvl(mw.net_pay, 0) + nvl(mw.bonus, 0)) as WAGES_PAID, mw.sal_dt, dm.designation, fm.firm_abbr from employee_master em, m_wage mw left outer join employee_master_dtl ed on (mw.emp_code = ed.emp_code), designation_master dm, firm_master fm where mw.firm_id = fm.firm_id and fm.firm_id = 2 and mw.designation_id = dm.designation_id and em.emp_code = mw.emp_code and mw.emp_code =28310"
        dt = oh.ExecuteDataSet(str).Tables(0)

        If dt.Rows.Count > 0 Then



            Dim header As New TableRow
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            header.Width = 30
            Dim headercell As New TableCell
            headercell.ColumnSpan = 30
            headercell.Text = "<b><font size=3>" & firm & "</font></b>"
            headercell.HorizontalAlign = HorizontalAlign.Center
            header.Controls.Add(headercell)
            salarytable.Controls.Add(header)

            Dim sheader As New TableRow
            sheader.Width = 30
            sheader.BackColor = Drawing.Color.LightGray
            Dim sheadercell1 As New TableCell
            sheadercell1.ColumnSpan = 30
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<b><font size=2>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
            sheader.Controls.Add(sheadercell1)
            salarytable.Controls.Add(sheader)




            For Each dr In dt.Rows



                titlefunc()

                Dim rrb As New TableRow
                rrb.Width = 30
                rrb.ForeColor = Drawing.Color.Black
                ' rrb.BackColor = Drawing.Color.Lavender
                Dim rrb1 As New TableCell
                rrb1.ColumnSpan = 30
                rrb1.HorizontalAlign = HorizontalAlign.Center
                rrb1.Text = "<b><u><font size=3>Salary Branch &nbsp;:&nbsp;&nbsp;" & Session("branch_name") & "</font></u></b>"
                rrb.Controls.Add(rrb1)
                salarytable.Controls.Add(rrb)
                'reccount += 1

                fieldname()
                'reccount += 1





                Dim rr As New TableRow
                rr.Width = 30
                rr.ForeColor = Drawing.Color.Black
                rr.BackColor = Drawing.Color.GhostWhite
                Dim rr1 As New TableCell
                rr1.ColumnSpan = 30
                rr1.HorizontalAlign = HorizontalAlign.Left
                rr1.Text = "<b><u><font size=3>&nbsp;&nbsp;Firm&nbsp;:&nbsp;&nbsp;" & dr(23) & "</font></u></b>"
                rr.Controls.Add(rr1)
                salarytable.Controls.Add(rr)
                reccount += 1


                Dim values As New TableRow
                values.Width = 30
                Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v30, v23, v24, v25 As New TableCell

                v1.ColumnSpan = 1
                v1.HorizontalAlign = HorizontalAlign.Center
                v1.Text = "<font size=2><b>" & dr(0) & "&nbsp;</b></font>"
                values.Controls.Add(v1)

                v2.ColumnSpan = 1
                v2.HorizontalAlign = HorizontalAlign.Left
                v2.Text = "<font size=2>" & dr(1) & "&nbsp;</font>"
                values.Controls.Add(v2)

                ' ///////father name
                'v3.ColumnSpan = 1
                'v3.HorizontalAlign = HorizontalAlign.Left
                'v3.Text = "<font size=2>&nbsp;" & dr(2) & "</font>"
                'values.Controls.Add(v3)

                ' /////////////Designation
                v4.ColumnSpan = 1
                v4.HorizontalAlign = HorizontalAlign.Left
                v4.Text = "<font size=2>" & dr(22) & "&nbsp;</font>"
                values.Controls.Add(v4)

                ' ///////////////Basic
                v5.ColumnSpan = 1
                v5.HorizontalAlign = HorizontalAlign.Right
                v5.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
                values.Controls.Add(v5)
                basic += dr(3)


                '///////DA
                v6.ColumnSpan = 1
                v6.HorizontalAlign = HorizontalAlign.Right
                v6.Text = "<font size=2>" & dr(3) & "&nbsp;</font>"
                values.Controls.Add(v6)
                vda += dr(3)


                ' ///////////////Total Attendance

                v7.ColumnSpan = 1
                v7.HorizontalAlign = HorizontalAlign.Right
                v7.Text = "<font size=2>" & dr(7) & "&nbsp;</font>"
                values.Controls.Add(v7)

                ' /////////////Arrear Salary

                v8.ColumnSpan = 1
                v8.HorizontalAlign = HorizontalAlign.Right
                v8.Text = "<font size=2>" & dr(4) & "&nbsp;</font>"
                values.Controls.Add(v8)
                arrsal += dr(4)
                ' /////////////min wage
                v25.ColumnSpan = 1
                v25.HorizontalAlign = HorizontalAlign.Right
                v25.Text = "<font size=2>" & dr(5) & "&nbsp;</font>"
                values.Controls.Add(v25)
                wagespayable += dr(5)

                '  /////////////wages payable
                v9.ColumnSpan = 1
                v9.HorizontalAlign = HorizontalAlign.Right
                v9.Text = "<font size=2>" & dr(6) & "&nbsp;</font>"
                values.Controls.Add(v9)
                wagespayable += dr(5)

                ' //////////////////Pf

                v10.ColumnSpan = 1
                v10.HorizontalAlign = HorizontalAlign.Right
                v10.Text = "<font size=2>" & dr(9) & "&nbsp;</font>"
                values.Controls.Add(v10)
                pf += dr(8)



                '////////ESI
                v11.ColumnSpan = 1
                v11.HorizontalAlign = HorizontalAlign.Right
                v11.Text = "<font size=2>" & dr(10) & "&nbsp;</font>"
                values.Controls.Add(v11)
                esi += dr(9)

                '/////////Staff(Welfare)

                v12.ColumnSpan = 1
                v12.HorizontalAlign = HorizontalAlign.Right
                v12.Text = "<font size=2>" & dr(11) & "&nbsp;</font>"
                values.Controls.Add(v12)
                swf += dr(10)



                ' //////////////Insurance Premium
                v13.ColumnSpan = 1
                v13.HorizontalAlign = HorizontalAlign.Right
                v13.Text = "<font size=2>" & dr(14) & "&nbsp;</font>"
                values.Controls.Add(v13)
                lic += dr(13)


                ' /////////////Professiona; Tax
                v14.ColumnSpan = 1
                v14.HorizontalAlign = HorizontalAlign.Right
                v14.Text = "<font size=2>" & dr(13) & "&nbsp;</font>"
                values.Controls.Add(v14)
                proftax += dr(12)


                ' ///////////////TDS
                v15.ColumnSpan = 1
                v15.HorizontalAlign = HorizontalAlign.Right
                v15.Text = "<font size=2>" & dr(15) & "&nbsp;</font>"
                values.Controls.Add(v15)
                tds += dr(14)



                '////////////////LWF


                v16.ColumnSpan = 1
                v16.HorizontalAlign = HorizontalAlign.Right
                v16.Text = "<font size=2>" & dr(12) & "&nbsp;</font>"
                values.Controls.Add(v16)
                lwf += dr(11)


                ' /////////////RD Deduction
                v17.ColumnSpan = 1
                v17.HorizontalAlign = HorizontalAlign.Right
                v17.Text = "<font size=2>" & dr(16) & "&nbsp;</font>"
                values.Controls.Add(v17)
                rdded += dr(15)

                ' //////////////Oth Deduction
                v18.ColumnSpan = 1
                v18.HorizontalAlign = HorizontalAlign.Right
                v18.Text = "<font size=2>" & dr(8) & "&nbsp;</font>"
                values.Controls.Add(v18)
                othded += dr(7)

                '  ///////////Total Deduction
                v19.ColumnSpan = 1
                v19.HorizontalAlign = HorizontalAlign.Right
                v19.Text = "<font size=2>" & dr(17) & "&nbsp;</font>"
                values.Controls.Add(v19)
                totalded += dr(16)

                '/////////////Bonus Amount
                v20.ColumnSpan = 1
                v20.HorizontalAlign = HorizontalAlign.Right
                v20.Text = "<font size=2>" & dr(18) & "&nbsp;</font>"
                values.Controls.Add(v20)
                bonus += dr(17)

                '/////////////Allowance Amount
                v24.ColumnSpan = 1
                v24.HorizontalAlign = HorizontalAlign.Right
                v24.Text = "<font size=2>" & dr(19) & "&nbsp;</font>"
                values.Controls.Add(v24)
                allowance += dr(18)

                '  //////////////Wages Paid
                v21.ColumnSpan = 1
                v21.HorizontalAlign = HorizontalAlign.Right
                v21.Text = "<b><font size=2>" & dr(20) & "&nbsp;</font></b>"
                values.Controls.Add(v21)
                wagespaid += dr(19)

                ' ////////Date of Payment
                v30.ColumnSpan = 1
                v30.HorizontalAlign = HorizontalAlign.Center
                If IsDBNull(dr(20)) Then
                    v30.Text = "<font size=2>--</font>"
                Else

                    v30.Text = "<font size=2>" & Format(dr(21), "dd/MMM/yyyy") & "</font>"
                End If
                values.Controls.Add(v30)

                v23.ColumnSpan = 1
                v23.HorizontalAlign = HorizontalAlign.Right
                v23.Text = " "
                values.Controls.Add(v23)

                salarytable.Controls.Add(values)

                Dim liness As New TableRow
                liness.Width = 30
                Dim linewss1 As New TableCell
                linewss1.ColumnSpan = 30
                linewss1.HorizontalAlign = HorizontalAlign.Center
                linewss1.Text = " "
                liness.Controls.Add(linewss1)
                salarytable.Controls.Add(liness)
                reccount += 1

                Dim linesr As New TableRow
                linesr.Width = 30
                Dim linewssr As New TableCell
                linewssr.ColumnSpan = 30
                linewssr.HorizontalAlign = HorizontalAlign.Center
                linewssr.Text = " "
                linesr.Controls.Add(linewssr)
                salarytable.Controls.Add(linesr)
                reccount += 1

                Dim linest As New TableRow
                linest.Width = 30
                Dim linewsst As New TableCell
                linewsst.ColumnSpan = 30
                linewsst.HorizontalAlign = HorizontalAlign.Center
                linewsst.Text = " "
                linest.Controls.Add(linewsst)
                salarytable.Controls.Add(linest)
                reccount += 1

            Next

            brtotal()

        Else
            Dim warn As New TableRow
            warn.Width = 30
            Dim w1 As New TableCell
            w1.ColumnSpan = 30
            w1.HorizontalAlign = HorizontalAlign.Center
            w1.Text = "<b><font size=2>This is Not the Correct Time To View Salary Statement!!</font></b>"
            warn.Controls.Add(w1)
            salarytable.Controls.Add(warn)
        End If

        Pan_salary.Controls.Add(salarytable)
    End Sub

    Sub titlefunc()

        Dim ttf As New TableRow
        ttf.Width = 30
        Dim ttf1 As New TableCell
        ttf1.ColumnSpan = 30
        ttf1.HorizontalAlign = HorizontalAlign.Center
        ttf1.Text = "<b><font size=3>&nbsp;&nbsp;FORM XI&nbsp;&nbsp;</font></b>"
        ttf.Controls.Add(ttf1)
        salarytable.Controls.Add(ttf)

        Dim ttss As New TableRow
        ttss.Width = 30
        Dim ttss1 As New TableCell
        ttss1.ColumnSpan = 30
        ttss1.HorizontalAlign = HorizontalAlign.Center
        ttss1.Text = "<b><font size=3>&nbsp;&nbsp;See Rule 29(1)&nbsp;&nbsp;</font></b>"
        ttss.Controls.Add(ttss1)
        salarytable.Controls.Add(ttss)


        Dim s As String = oh.ExecuteDataSet("select distinct to_char(to_date(s.sal_dt),'MONTH') from salari s").Tables(0).Rows(0)(0)

        Dim y As Integer = oh.ExecuteDataSet("select distinct to_char(to_date(s.sal_dt),'YYYY') from salari s").Tables(0).Rows(0)(0)


        Dim tt As New TableRow
        tt.Width = 30
        Dim tt1 As New TableCell
        tt1.ColumnSpan = 30
        tt1.HorizontalAlign = HorizontalAlign.Center
        tt1.Text = "<b><font size=3>REGISTER OF WAGES of " & s & " " & y & "</font></b>"
        tt.Controls.Add(tt1)
        salarytable.Controls.Add(tt)

        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 30

        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 2
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 16
        subcell2.HorizontalAlign = HorizontalAlign.Center

        subh.Controls.Add(subcell2)
        subcell3.ColumnSpan = 4
        subcell3.HorizontalAlign = HorizontalAlign.Left
        subcell3.Text = "<b><font size=3.5>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)
        salarytable.Controls.Add(subh)


        Dim linea As New TableRow
        Dim linecella As New TableCell
        linecella.ColumnSpan = 30
        linecella.Text = "<hr>"
        linea.Controls.Add(linecella)
        salarytable.Controls.Add(linea)





        'If colors.Equals("#fff7ff") = True Then
        '    colors = "#eef9ff"
        'Else
        '    colors = "#fff7ff"
        'End If

    End Sub
    Sub fieldname()
        reccount += 1
        Dim field As New TableRow
        field.Width = 30
        ' field.Attributes.Add("bgcolor", colors)
        Dim f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, f17, f18, f19, f20, f21, f30, f23, f24, f25 As New TableCell

        f1.ColumnSpan = 1
        f1.HorizontalAlign = HorizontalAlign.Center
        f1.Text = "<b><font size=2>EmpCode&nbsp;</font></b>"
        field.Controls.Add(f1)

        f2.ColumnSpan = 1
        f2.HorizontalAlign = HorizontalAlign.Left
        f2.Text = "<b><font size=2>EmpName&nbsp;</font></b>"
        field.Controls.Add(f2)

        f4.ColumnSpan = 1
        f4.HorizontalAlign = HorizontalAlign.Left
        f4.Text = "<b><font size=2>Designation&nbsp;</font></b>"
        field.Controls.Add(f4)

        f5.ColumnSpan = 1
        f5.HorizontalAlign = HorizontalAlign.Left
        f5.Text = "<b><font size=2>Basic&nbsp;</font></b>"
        field.Controls.Add(f5)

        f6.ColumnSpan = 1
        f6.HorizontalAlign = HorizontalAlign.Left
        f6.Text = "<b><font size=2>D.A&nbsp;</font></b>"
        field.Controls.Add(f6)

        f7.ColumnSpan = 1
        f7.HorizontalAlign = HorizontalAlign.Left
        f7.Text = "<b><font size=2>Tot. Att&nbsp;</font></b>"
        field.Controls.Add(f7)

        f8.ColumnSpan = 1
        f8.HorizontalAlign = HorizontalAlign.Left
        f8.Text = "<b><font size=2>Arr Sal&nbsp;</font></b>"
        field.Controls.Add(f8)

        f25.ColumnSpan = 1
        f25.HorizontalAlign = HorizontalAlign.Left
        f25.Text = "<b><font size=2>Minimum Wage Adjustment&nbsp;</font></b>"
        field.Controls.Add(f25)

        f9.ColumnSpan = 1
        f9.HorizontalAlign = HorizontalAlign.Left
        f9.Text = "<b><font size=2>Wages Pble&nbsp;</font></b>"
        field.Controls.Add(f9)

        f10.ColumnSpan = 1
        f10.HorizontalAlign = HorizontalAlign.Left
        f10.Text = "<b><font size=2>P.F&nbsp;</font></b>"
        field.Controls.Add(f10)

        f11.ColumnSpan = 1
        f11.HorizontalAlign = HorizontalAlign.Left
        f11.Text = "<b><font size=2>E.S.I&nbsp;</font></b>"
        field.Controls.Add(f11)

        f12.ColumnSpan = 1
        f12.HorizontalAlign = HorizontalAlign.Left
        f12.Text = "<b><font size=2>S.W.F</font></b>"
        field.Controls.Add(f12)

        f13.ColumnSpan = 1
        f13.HorizontalAlign = HorizontalAlign.Left
        f13.Text = "<b><font size=2>Ins&nbsp;</font></b>"
        field.Controls.Add(f13)

        f14.ColumnSpan = 1
        f14.HorizontalAlign = HorizontalAlign.Left
        f14.Text = "<b><font size=2>Prof. Tax&nbsp;</font></b>"
        field.Controls.Add(f14)

        f15.ColumnSpan = 1
        f15.HorizontalAlign = HorizontalAlign.Left
        f15.Text = "<b><font size=2>T.D.S&nbsp;</font></b>"
        field.Controls.Add(f15)

        f16.ColumnSpan = 1
        f16.HorizontalAlign = HorizontalAlign.Left
        f16.Text = "<b><font size=2>L.W.F&nbsp;</font></b>"
        field.Controls.Add(f16)

        f17.ColumnSpan = 1
        f17.HorizontalAlign = HorizontalAlign.Left
        f17.Text = "<b><font size=2>R.D&nbsp;</font></b>"
        field.Controls.Add(f17)

        f18.ColumnSpan = 1
        f18.HorizontalAlign = HorizontalAlign.Left
        f18.Text = "<b><font size=2>Oth Ded&nbsp;</font></b>"
        field.Controls.Add(f18)

        f19.ColumnSpan = 1
        f19.HorizontalAlign = HorizontalAlign.Left
        f19.Text = "<b><font size=2>Tot Ded&nbsp;</font></b>"
        field.Controls.Add(f19)

        f20.ColumnSpan = 1
        f20.HorizontalAlign = HorizontalAlign.Left
        f20.Text = "<b><font size=2>Bonus&nbsp;</font></b>"
        field.Controls.Add(f20)

        f24.ColumnSpan = 1
        f24.HorizontalAlign = HorizontalAlign.Left
        f24.Text = "<b><font size=2>Allowance</font></b>"
        field.Controls.Add(f24)

        f21.ColumnSpan = 1
        f21.HorizontalAlign = HorizontalAlign.Left
        f21.Text = "<b><font size=2>Wages Paid&nbsp;</font></b>"
        field.Controls.Add(f21)

        f30.ColumnSpan = 1
        f30.HorizontalAlign = HorizontalAlign.Left
        f30.Text = "<b><font size=2>Dt of Pay&nbsp;</font></b>"
        field.Controls.Add(f30)

        f23.ColumnSpan = 1
        f23.HorizontalAlign = HorizontalAlign.Left
        f23.Text = "<b><font size=2>Sig.&nbsp;of Emp</font></b>"
        field.Controls.Add(f23)

        salarytable.Controls.Add(field)

        Dim linew As New TableRow
        linew.Width = 30
        Dim linew1 As New TableCell
        linew1.ColumnSpan = 30
        linew1.HorizontalAlign = HorizontalAlign.Center
        linew1.Text = "<hr>"
        linew.Controls.Add(linew1)
        salarytable.Controls.Add(linew)
    End Sub

    Sub brtotal()

        Dim last As New TableRow
        Dim last1 As New TableCell
        last1.ColumnSpan = 30
        last1.Text = "<hr>"
        last.Controls.Add(last1)
        salarytable.Controls.Add(last)

        Dim aaw As New TableRow
        aaw.Width = 30
        Dim prepare, prepare1, verify, verify1, approve, approve1 As New TableCell

        prepare.ColumnSpan = 3
        prepare.HorizontalAlign = HorizontalAlign.Center
        prepare.Text = "<font size=2>Prepared By </font>"
        aaw.Controls.Add(prepare)

        prepare1.ColumnSpan = 2
        prepare1.HorizontalAlign = HorizontalAlign.Center
        prepare1.Text = " "
        aaw.Controls.Add(prepare1)

        verify.ColumnSpan = 3
        verify.HorizontalAlign = HorizontalAlign.Center
        verify.Text = "<font size=2>Verified By </font>"
        aaw.Controls.Add(verify)

        verify1.ColumnSpan = 3
        verify1.HorizontalAlign = HorizontalAlign.Center
        verify1.Text = " "
        aaw.Controls.Add(verify1)

        approve.ColumnSpan = 3
        approve.HorizontalAlign = HorizontalAlign.Center
        approve.Text = "<font size=2>Approved By </font>"
        aaw.Controls.Add(approve)

        approve1.ColumnSpan = 8
        approve1.HorizontalAlign = HorizontalAlign.Center
        approve1.Text = ""
        aaw.Controls.Add(approve1)

        salarytable.Controls.Add(aaw)

        Dim foot1 As New TableRow
        Dim foot1a As New TableCell
        foot1a.ColumnSpan = 30
        foot1a.Text = "<hr>"
        foot1.Controls.Add(foot1a)
        salarytable.Controls.Add(foot1)

        Dim space2 As New TableRow
        Dim space2a As New TableCell
        space2a.ColumnSpan = 30
        space2a.Text = " "
        space2.Controls.Add(space2a)
        salarytable.Controls.Add(space2)


    End Sub

    Sub pagenext()


        Dim pgebrk As New TableRow
        pgebrk.Width = 30
        Dim pgebrk1 As New TableCell
        pgebrk1.ColumnSpan = 30
        pgebrk1.HorizontalAlign = HorizontalAlign.Center
        pgebrk1.Text = "<DIV style=page-break-after:always></DIV>"
        pgebrk.Controls.Add(pgebrk1)
        salarytable.Controls.Add(pgebrk)
    End Sub
    Private Function numbering(ByVal a) As Integer

        Dim ar As New TableRow
        ar.Width = 30
        Dim ar1 As New TableCell
        ar1.ColumnSpan = 30
        ar1.HorizontalAlign = HorizontalAlign.Right
        ar1.Text = "<font size=2>Page Number :" & a & "</font>"
        ar.Controls.Add(ar1)
        salarytable.Controls.Add(ar)
    End Function


End Class
