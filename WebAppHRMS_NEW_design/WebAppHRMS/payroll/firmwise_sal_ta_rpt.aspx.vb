Imports System.Data
Imports System.Data.OracleClient
Partial Class Firmwise_Salary_TA_firmwise_sal_ta_rpt_2afd6a4c3028
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim i As Integer = 0
    Dim toti As Integer = 0
    Dim saltot As Double = 0
    Dim tatot As Double = 0
    Dim alltot As Double = 0
    Dim firsaltatable As New Table

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.Request.QueryString("firm") = 0 Then
            '              -----0----  -----1---   ------2-----  ---3------- -----4------------------  ------5--------------------------------------------------         -------------5--------------------------------------------------    -----------6 -----------  -------7----------------    --------8-------    --------9-------------- ------
            str = "select hm.emp_code,em.emp_name,dm.designation,dp.dep_name,fm.firm_abbr as Emp_Firm,bm.branch_name||'  '||'('||fm1.firm_abbr||')' as Emp_Branch,bm1.branch_name||'   '||'('||fm2.firm_abbr||')' as Emp_salta_rec_Branch,fm3.firm_abbr as receive_firm,case when hm.emp_code=m.emp_code then decode(m.status_id,1,'LIVE',3,'RESIGNED',4,'SUSPENDED',5,'TERMI/REGULARISED',6,'LONG LEAVE',10,'MATERNITY') when hm.emp_code=m.emp_code and hm.emp_code=ad.emp_code then decode(m.status_id,1,'LIVE',3,'RESIGNED',4,'SUSPENDED',5,'TERMI/REGULARISED',6,'LONG LEAVE',10,'MATERNITY') when hm.emp_code=ad.emp_code then decode(ad.status_id,1,'LIVE',3,'RESIGNED',4,'SUSPENDED',5,'TERMI/REGULARISED',6,'LONG LEAVE',10,'MATERNITY') end as Emp_Status,nvl(hm.salary,0) as Salary,nvl(hm.ta,0) as TA,nvl(hm.total_amt,0) as Total_Amount from employee_master em,hrm_employ_verification hm left outer join m_wage m on(hm.emp_code=m.emp_code) left outer join incentives_allowances_dtl ad on(hm.emp_code=ad.emp_code),designation_master dm,department_mst dp,branch_master bm,branch_master bm1,firm_master fm,firm_master fm1,firm_master fm2,firm_master fm3 where hm.emp_code=em.emp_code and em.designation_id=dm.designation_id and hm.dep_id=dp.dep_id and hm.emp_branch=bm.branch_id and hm.verify_br=bm1.branch_id and em.firm_id=fm.firm_id and bm.firm_id=fm1.firm_id and bm1.firm_id=fm2.firm_id and hm.rec_firm=fm3.firm_id and hm.status_id=1 and hm.rec_by<>'SD PROCESS' and hm.rec_by<>'BLOCK' union select hm.emp_code,em.emp_name,dm.designation,dp.dep_name,fm.firm_abbr as Emp_Firm,bc.branch_name||' (N.O.B)' as Emp_Branch,bm1.branch_name||'   '||'('||fm2.firm_abbr||')' as Emp_salta_rec_Branch,fm3.firm_abbr as receive_firm,case when hm.emp_code=m.emp_code then decode(m.status_id,1,'LIVE',3,'RESIGNED',4,'SUSPENDED',5,'TERMI/REGULARISED',6,'LONG LEAVE',10,'MATERNITY') when hm.emp_code=m.emp_code and hm.emp_code=ad.emp_code then decode(m.status_id,1,'LIVE',3,'RESIGNED',4,'SUSPENDED',5,'TERMI/REGULARISED',6,'LONG LEAVE',10,'MATERNITY') when hm.emp_code=ad.emp_code then decode(ad.status_id,1,'LIVE',3,'RESIGNED',4,'SUSPENDED',5,'TERMI/REGULARISED',6,'LONG LEAVE',10,'MATERNITY') end as Emp_Status,nvl(hm.salary,0) as Salary,nvl(hm.ta,0) as TA,nvl(hm.total_amt,0) as Total_Amount from employee_master em,hrm_employ_verification hm left outer join m_wage m on(hm.emp_code=m.emp_code) left outer join incentives_allowances_dtl ad on(hm.emp_code=ad.emp_code),designation_master dm,department_mst dp,before_completion bc,branch_master bm1,firm_master fm,firm_master fm2,firm_master fm3 where hm.emp_code=em.emp_code and em.designation_id=dm.designation_id and hm.dep_id=dp.dep_id and hm.emp_branch=bc.old_id and bc.branch_id is null and hm.verify_br=bm1.branch_id and em.firm_id=fm.firm_id and bm1.firm_id=fm2.firm_id and hm.rec_firm=fm3.firm_id and hm.status_id=1 and hm.rec_by<>'SD PROCESS' and hm.rec_by<>'BLOCK' order by receive_firm,emp_code"

        Else
            '              -----0----  -----1---   ------2-----  ---3------- ---------4-------------   -------------5---------------    -----------6 -----------------------   -------7-----------------------------   -------------8-------------   --------9----------------   ---10----------    --------11----------------------
            'str = "select hm.emp_code,em.emp_name,dm.designation,dp.dep_name,fm.firm_abbr as Emp_Firm,bm.branch_name||'  '||'('||fm1.firm_abbr||')' as Emp_Branch,bm1.branch_name||'   '||'('||fm2.firm_abbr||')' as Emp_salta_rec_Branch,fm3.firm_abbr as receive_firm,case when hm.emp_code=m.emp_code then decode(m.status_id,1,'LIVE',3,'RESIGNED',4,'SUSPENDED',5,'TERMI/REGULARISED',6,'LONG LEAVE',10,'MATERNITY') when hm.emp_code=m.emp_code and hm.emp_code=ad.emp_code then decode(m.status_id,1,'LIVE',3,'RESIGNED',4,'SUSPENDED',5,'TERMI/REGULARISED',6,'LONG LEAVE',10,'MATERNITY') when hm.emp_code=ad.emp_code then decode(ad.status_id,1,'LIVE',3,'RESIGNED',4,'SUSPENDED',5,'TERMI/REGULARISED',6,'LONG LEAVE',10,'MATERNITY') end as Emp_Status,nvl(hm.salary,0) as Salary,nvl(hm.ta,0) as TA,nvl(hm.total_amt,0) as Total_Amount from employee_master em,hrm_employ_verification hm left outer join m_wage m on(hm.emp_code=m.emp_code) left outer join incentives_allowances_dtl ad on(hm.emp_code=ad.emp_code),designation_master dm,department_mst dp,branch_master bm,branch_master bm1,firm_master fm,firm_master fm1,firm_master fm2,firm_master fm3 where hm.emp_code=em.emp_code and em.designation_id=dm.designation_id and hm.dep_id=dp.dep_id and hm.emp_branch=bm.branch_id and hm.verify_br=bm1.branch_id and em.firm_id=fm.firm_id and bm.firm_id=fm1.firm_id and bm1.firm_id=fm2.firm_id and hm.rec_firm=fm3.firm_id and hm.rec_firm=" & Me.Request.QueryString("firm") & " and hm.status_id=1 and hm.rec_by<>'SD PROCESS' and hm.rec_by<>'BLOCK' union select hm.emp_code,em.emp_name,dm.designation,dp.dep_name,fm.firm_abbr as Emp_Firm,bc.branch_name||' (N.O.B)' as Emp_Branch,bm1.branch_name||'   '||'('||fm2.firm_abbr||')' as Emp_salta_rec_Branch,fm3.firm_abbr as receive_firm,case when hm.emp_code=m.emp_code then decode(m.status_id,1,'LIVE',3,'RESIGNED',4,'SUSPENDED',5,'TERMI/REGULARISED',6,'LONG LEAVE',10,'MATERNITY') when hm.emp_code=m.emp_code and hm.emp_code=ad.emp_code then decode(m.status_id,1,'LIVE',3,'RESIGNED',4,'SUSPENDED',5,'TERMI/REGULARISED',6,'LONG LEAVE',10,'MATERNITY') when hm.emp_code=ad.emp_code then decode(ad.status_id,1,'LIVE',3,'RESIGNED',4,'SUSPENDED',5,'TERMI/REGULARISED',6,'LONG LEAVE',10,'MATERNITY') end as Emp_Status,nvl(hm.salary,0) as Salary,nvl(hm.ta,0) as TA,nvl(hm.total_amt,0) as Total_Amount from employee_master em,hrm_employ_verification hm left outer join m_wage m on(hm.emp_code=m.emp_code) left outer join incentives_allowances_dtl ad on(hm.emp_code=ad.emp_code),designation_master dm,department_mst dp,before_completion bc,branch_master bm1,firm_master fm,firm_master fm2,firm_master fm3 where hm.emp_code=em.emp_code and em.designation_id=dm.designation_id and hm.dep_id=dp.dep_id and hm.emp_branch=bc.old_id and bc.branch_id is null and hm.verify_br=bm1.branch_id and em.firm_id=fm.firm_id and bm1.firm_id=fm2.firm_id and hm.rec_firm=fm3.firm_id and hm.rec_firm=" & Me.Request.QueryString("firm") & " and hm.status_id=1 and hm.rec_by<>'SD PROCESS' and hm.rec_by<>'BLOCK' order by receive_firm,emp_code"
            str = "select hm.emp_code,  em.emp_name,  dm.designation,  dp.dep_name,  fm.firm_abbr as Emp_Firm,  bm.branch_name || '  ' || '(' || fm1.firm_abbr || ')' as Emp_Branch,  bm1.branch_name || '   ' || '(' || fm2.firm_abbr || ')' as Emp_salta_rec_Branch,  fm3.firm_abbr as receive_firm,  case  when hm.emp_code = m.emp_code then  decode(m.status_id,  1,  'LIVE',  3,  'RESIGNED',  4,  'SUSPENDED',  5,  'TERMI/REGULARISED',  6,  'LONG LEAVE',  10,  'MATERNITY')  when hm.emp_code = m.emp_code and hm.emp_code = ad.emp_code then  decode(m.status_id,  1,  'LIVE',  3,  'RESIGNED',  4,  'SUSPENDED',  5,  'TERMI/REGULARISED',  6,  'LONG LEAVE',  10,  'MATERNITY')  when hm.emp_code = ad.emp_code then  decode(ad.status_id,  1,  'LIVE',  3,  'RESIGNED',  4,  'SUSPENDED',  5,  'TERMI/REGULARISED',  6,  'LONG LEAVE',  10,  'MATERNITY')  end as Emp_Status,  nvl(hm.salary, 0) as Salary,  nvl(hm.ta, 0) as TA,  nvl(hm.total_amt, 0) as Total_Amount  from employee_master em, employ_firm ef, hrm_employ_verification hm  left outer join m_wage m on (hm.emp_code = m.emp_code)  left outer join incentives_allowances_dtl ad on (hm.emp_code =  ad.emp_code),  designation_master dm,  department_mst dp,  branch_master bm,  branch_master bm1,  firm_master fm,  firm_master fm1,  firm_master fm2,  firm_master fm3  where hm.emp_code = em.emp_code  and em.designation_id = dm.designation_id  and hm.dep_id = dp.dep_id  and hm.emp_branch = bm.branch_id  and hm.verify_br = bm1.branch_id  and ef.firm_id = fm.firm_id  and ef.firm_id = hm.rec_firm  and ef.emp_code = hm.emp_code  and ef.emp_code = em.emp_code  and bm.firm_id = fm1.firm_id  and bm1.firm_id = fm2.firm_id  and hm.rec_firm = fm3.firm_id  and hm.rec_firm = " & Me.Request.QueryString("firm") & "  and hm.status_id = 1  and hm.rec_by <> 'SD PROCESS'  and hm.rec_by <> 'BLOCK' union select hm.emp_code,  em.emp_name,  dm.designation,  dp.dep_name,  fm.firm_abbr as Emp_Firm,  bc.branch_name || ' (N.O.B)' as Emp_Branch,  bm1.branch_name || '   ' || '(' || fm2.firm_abbr || ')' as Emp_salta_rec_Branch,  fm3.firm_abbr as receive_firm,  case  when hm.emp_code = m.emp_code then  decode(m.status_id,  1,  'LIVE',  3,  'RESIGNED',  4,  'SUSPENDED',  5,  'TERMI/REGULARISED',  6,  'LONG LEAVE',  10,  'MATERNITY')  when hm.emp_code = m.emp_code and hm.emp_code = ad.emp_code then  decode(m.status_id,  1,  'LIVE',  3,  'RESIGNED',  4,  'SUSPENDED',  5,  'TERMI/REGULARISED',  6,  'LONG LEAVE',  10,  'MATERNITY')  when hm.emp_code = ad.emp_code then  decode(ad.status_id,  1,  'LIVE',  3,  'RESIGNED',  4,  'SUSPENDED',  5,  'TERMI/REGULARISED',  6,  'LONG LEAVE',  10,  'MATERNITY')  end as Emp_Status,  nvl(hm.salary, 0) as Salary,  nvl(hm.ta, 0) as TA,  nvl(hm.total_amt, 0) as Total_Amount  from employee_master em, employ_firm ef, hrm_employ_verification hm  left outer join m_wage m on (hm.emp_code = m.emp_code)  left outer join incentives_allowances_dtl ad on (hm.emp_code =  ad.emp_code),  designation_master dm,  department_mst dp,  before_completion bc,  branch_master bm1,  firm_master fm,  firm_master fm2,  firm_master fm3  where hm.emp_code = em.emp_code  and em.designation_id = dm.designation_id  and hm.dep_id = dp.dep_id  and hm.emp_branch = bc.old_id  and bc.branch_id is null  and hm.verify_br = bm1.branch_id  and ef.firm_id = hm.rec_firm  and ef.firm_id = fm.firm_id  and ef.emp_code = hm.emp_code  and ef.emp_code = em.emp_code  and bm1.firm_id = fm2.firm_id  and hm.rec_firm = fm3.firm_id  and hm.rec_firm = " & Me.Request.QueryString("firm") & "  and hm.status_id = 1  and hm.rec_by <> 'SD PROCESS'  and hm.rec_by <> 'BLOCK'  order by receive_firm, emp_code"
        End If
        dt = oh.ExecuteDataSet(str).Tables(0)

        If dt.Rows.Count > 0 Then

            firsaltatable.Attributes.Add("width", "100%")
            Dim header As New TableRow
            header.Width = 11
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            Dim headcell As New TableCell
            headcell.ColumnSpan = 11
            headcell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
            headcell.HorizontalAlign = HorizontalAlign.Center
            header.Controls.Add(headcell)
            firsaltatable.Controls.Add(header)

            Dim sheader As New TableRow
            sheader.Width = 11
            Dim sheadercell1 As New TableCell
            sheadercell1.ColumnSpan = 11
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
            sheader.Controls.Add(sheadercell1)
            firsaltatable.Controls.Add(sheader)


            Dim subh As New TableRow
            Dim subcell1 As New TableCell
            Dim subcell2 As New TableCell
            Dim subcell3 As New TableCell
            subh.Width = 11
            subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
            subcell1.ColumnSpan = 3
            subcell1.HorizontalAlign = HorizontalAlign.Left
            subh.Controls.Add(subcell1)

            subcell2.ColumnSpan = 5
            subcell2.HorizontalAlign = HorizontalAlign.Center
            subcell2.Text = " "
            subh.Controls.Add(subcell2)

            subcell3.ColumnSpan = 3
            subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
            subcell3.HorizontalAlign = HorizontalAlign.Right
            subh.Controls.Add(subcell3)

            firsaltatable.Controls.Add(subh)

            Dim s As String = oh.ExecuteDataSet("select distinct to_char(to_date(s.sal_dt),'MONTH') from salari s").Tables(0).Rows(0)(0)

            Dim y As Integer = oh.ExecuteDataSet("select distinct to_char(to_date(s.sal_dt),'YYYY') from salari s").Tables(0).Rows(0)(0)

            Dim pheader As New TableRow
            Dim pheadercell As New TableCell
            pheader.Width = 11
            pheadercell.ColumnSpan = 11
            pheadercell.HorizontalAlign = HorizontalAlign.Center

            pheadercell.Text = "<body align=center ><b><font size=3>Cash Received Firmwise Employees Salary and others of " & s & "&nbsp;&nbsp;" & y & "</font></b>"
            pheader.Controls.Add(pheadercell)
            firsaltatable.Controls.Add(pheader)

            Dim line1 As New TableRow
            Dim linecell1 As New TableCell
            line1.Width = 11
            linecell1.ColumnSpan = 11
            linecell1.Text = "<hr>"
            line1.Controls.Add(linecell1)
            firsaltatable.Controls.Add(line1)

            Dim field As New TableRow
            field.Width = 11
            Dim f1, f2, f3, fa, f4, f5, f6, f7, f8, f9, f10, f11 As New TableCell
            'colors = "#8BB381"
            field.Attributes.Add("bgcolor", "#CCFFCC")

            f1.ColumnSpan = 1
            f1.HorizontalAlign = HorizontalAlign.Left
            f1.Text = "<b><font size=2>Emp&nbsp;Code&nbsp;</font></b>"
            field.Controls.Add(f1)

            f2.ColumnSpan = 1
            f2.HorizontalAlign = HorizontalAlign.Left
            f2.Text = "<b><font size=2>Employee&nbsp;Name&nbsp;</font></b>"
            field.Controls.Add(f2)

            f3.ColumnSpan = 1
            f3.HorizontalAlign = HorizontalAlign.Left
            f3.Text = "<b><font size=2>Designation&nbsp;</font></b>"
            field.Controls.Add(f3)

            fa.ColumnSpan = 1
            fa.HorizontalAlign = HorizontalAlign.Left
            fa.Text = "<b><font size=2>Department&nbsp;</font></b>"
            field.Controls.Add(fa)

            f4.ColumnSpan = 1
            f4.HorizontalAlign = HorizontalAlign.Left
            f4.Text = "<b><font size=2>Working&nbsp;Firm&nbsp;</font></b>"
            field.Controls.Add(f4)

            f5.ColumnSpan = 1
            f5.HorizontalAlign = HorizontalAlign.Center
            f5.Text = "<b><font size=2>Working&nbsp;Branch&nbsp;</font></b>"
            field.Controls.Add(f5)

            f6.ColumnSpan = 1
            f6.HorizontalAlign = HorizontalAlign.Center
            f6.Text = "<b><font size=2>Cash Received Branch</font></b>"
            field.Controls.Add(f6)

            f7.ColumnSpan = 1
            f7.HorizontalAlign = HorizontalAlign.Left
            f7.Text = "<b><font size=2>Emp Status</font></b>"
            field.Controls.Add(f7)

            'f8.ColumnSpan = 1
            'f8.HorizontalAlign = HorizontalAlign.Left
            'f8.Text = 
            'field.Controls.Add(f8)

            If Me.Request.QueryString("item") = 1 Then   'salary ionly
                f9.ColumnSpan = 2
                f9.HorizontalAlign = HorizontalAlign.Left
                f9.Text = "<b><font size=2>Salary Amount</font></b>"
                field.Controls.Add(f9)

                f11.ColumnSpan = 1
                f11.HorizontalAlign = HorizontalAlign.Left
                f11.Text = "<b><font size=2>Total Amount</font></b>"
                field.Controls.Add(f11)

            ElseIf Me.Request.QueryString("item") = 2 Then   ' ta only
                f10.ColumnSpan = 2
                f10.HorizontalAlign = HorizontalAlign.Left
                f10.Text = "<b><font size=2>Allowances Amount</font></b>"
                field.Controls.Add(f10)

                f11.ColumnSpan = 1
                f11.HorizontalAlign = HorizontalAlign.Left
                f11.Text = "<b><font size=2>Total Amount</font></b>"
                field.Controls.Add(f11)

            ElseIf Me.Request.QueryString("item") = 3 Then  ' both salary and ta

                f9.ColumnSpan = 1
                f9.HorizontalAlign = HorizontalAlign.Left
                f9.Text = "<b><font size=2>Salary Amount</font></b>"
                field.Controls.Add(f9)

                f10.ColumnSpan = 1
                f10.HorizontalAlign = HorizontalAlign.Left
                f10.Text = "<b><font size=2>Allowances Amount</font></b>"
                field.Controls.Add(f10)

                f11.ColumnSpan = 1
                f11.HorizontalAlign = HorizontalAlign.Left
                f11.Text = "<b><font size=2>Total Amount</font></b>"
                field.Controls.Add(f11)

            End If

            firsaltatable.Controls.Add(field)

            Dim recfirm As String = ""

            For Each dr In dt.Rows
                toti += 1
                If recfirm <> dr(7) Then
                    Dim refirm As New TableRow
                    refirm.Width = 11
                    Dim rf As New TableCell
                    rf.ColumnSpan = 11
                    rf.HorizontalAlign = HorizontalAlign.Left
                    rf.Text = "<b><font size=3>Received Firm:&nbsp;" & dr(7).ToString & "</font></b>"
                    refirm.Controls.Add(rf)
                    firsaltatable.Controls.Add(refirm)
                    i = 0
                End If
                recfirm = dr(7).ToString
                i += 1
                Dim value As New TableRow
                value.Width = 11
                Dim v1, v2, v3, va, v4, v5, v6, v7, v8, v9, v10, v11 As New TableCell
                'colors = "#8BB381"
                value.Attributes.Add("bgcolor", "#FFFFCC")

                v1.ColumnSpan = 1    'Code
                v1.HorizontalAlign = HorizontalAlign.Left
                v1.Text = "<b><font size=2>" & dr(0) & "&nbsp;</font></b>"
                value.Controls.Add(v1)

                v2.ColumnSpan = 1   'EmployeeName
                v2.HorizontalAlign = HorizontalAlign.Left
                v2.Text = "<font size=2>" & dr(1) & "&nbsp;</font>"
                value.Controls.Add(v2)

                v3.ColumnSpan = 1    'Designation
                v3.HorizontalAlign = HorizontalAlign.Left
                v3.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
                value.Controls.Add(v3)

                va.ColumnSpan = 1    'Department
                va.HorizontalAlign = HorizontalAlign.Left
                va.Text = "<font size=2>" & dr(3) & "&nbsp;</font>"
                value.Controls.Add(va)

                v4.ColumnSpan = 1  'Working Firm
                v4.HorizontalAlign = HorizontalAlign.Left
                v4.Text = "<font size=2>" & dr(4) & "&nbsp;</font>"
                value.Controls.Add(v4)

                v5.ColumnSpan = 1  'Working&nbsp;Branch&nbsp;
                v5.HorizontalAlign = HorizontalAlign.Left
                v5.Text = "<font size=2>" & dr(5) & "&nbsp;</font>"
                value.Controls.Add(v5)

                v6.ColumnSpan = 1   'Cash Received Branch
                v6.HorizontalAlign = HorizontalAlign.Left
                v6.Text = "<font size=2>" & dr(6) & "&nbsp;</font>"
                value.Controls.Add(v6)

                v7.ColumnSpan = 1       'Emp Status
                v7.HorizontalAlign = HorizontalAlign.Left
                v7.Text = "<font size=2>" & dr(8) & "&nbsp;</font>"
                value.Controls.Add(v7)

               

                If Me.Request.QueryString("item") = 1 Then   'salary ionly
                    v9.ColumnSpan = 2  'salary
                    v9.HorizontalAlign = HorizontalAlign.Right
                    v9.Text = "<font size=2>" & FormatNumber(dr(9), 2) & "&nbsp;</font>"
                    value.Controls.Add(v9)
                    Me.saltot += dr(9)

                    v11.ColumnSpan = 1   'total
                    v11.HorizontalAlign = HorizontalAlign.Right
                    v11.Text = "<font size=2>" & FormatNumber(dr(11), 2) & "</font>"
                    value.Controls.Add(v11)
                    Me.alltot += dr(11)

                ElseIf Me.Request.QueryString("item") = 2 Then   ' ta only
                    v10.ColumnSpan = 2  'ta
                    v10.HorizontalAlign = HorizontalAlign.Right
                    v10.Text = "<font size=2>" & FormatNumber(dr(10), 2) & "&nbsp;</font>"
                    value.Controls.Add(v10)
                    Me.tatot += dr(10)

                    v11.ColumnSpan = 1    'total
                    v11.HorizontalAlign = HorizontalAlign.Right
                    v11.Text = "<font size=2>" & FormatNumber(dr(11), 2) & "</font>"
                    value.Controls.Add(v11)
                    Me.alltot += dr(11)

                ElseIf Me.Request.QueryString("item") = 3 Then  ' both salary and ta

                    v9.ColumnSpan = 1
                    v9.HorizontalAlign = HorizontalAlign.Right
                    v9.Text = "<font size=2>" & FormatNumber(dr(9), 2) & "&nbsp;</font>"
                    value.Controls.Add(v9)
                    Me.saltot += dr(9)

                    v10.ColumnSpan = 1
                    v10.HorizontalAlign = HorizontalAlign.Right
                    v10.Text = "<font size=2>" & FormatNumber(dr(10), 2) & "&nbsp;</font>"
                    value.Controls.Add(v10)
                    Me.tatot += dr(10)

                    v11.ColumnSpan = 1
                    v11.HorizontalAlign = HorizontalAlign.Right
                    v11.Text = "<font size=2>" & FormatNumber(dr(11), 2) & "</font>"
                    value.Controls.Add(v11)
                    Me.alltot += dr(11)

                End If

                firsaltatable.Controls.Add(value)


            Next

            Dim lineq As New TableRow
            lineq.Width = 11
            Dim l1 As New TableCell
            l1.ColumnSpan = 11
            l1.Text = "<hr>"
            lineq.Controls.Add(l1)
            firsaltatable.Controls.Add(lineq)


            If Me.Request.QueryString("item") = 1 Then   'salary ionly
                Dim tot As New TableRow
                tot.Width = 11
                Dim tt As New TableCell
                tt.ColumnSpan = 11
                tt.HorizontalAlign = HorizontalAlign.Left
                tt.Text = "<b><font size=3>Total:&nbsp;" & Me.toti & "&nbsp;Employee(s) and Sum of Total Salary=" & FormatNumber(Me.saltot, 2) & "&nbsp;And Sum Of Total Amount=" & FormatNumber(Me.alltot, 2) & "&nbsp;Rupees</font></b>"
                tot.Controls.Add(tt)
                firsaltatable.Controls.Add(tot)
            ElseIf Me.Request.QueryString("item") = 2 Then   ' ta only
                Dim tot As New TableRow
                tot.Width = 11
                Dim tt As New TableCell
                tt.ColumnSpan = 11
                tt.HorizontalAlign = HorizontalAlign.Left
                tt.Text = "<b><font size=3>Total:&nbsp;" & Me.toti & "&nbsp;Employee(s) and Sum of Total Incentives=" & FormatNumber(Me.tatot, 2) & "&nbsp;And Sum Of Total Amount=" & FormatNumber(Me.alltot, 2) & "&nbsp;Rupees</font></b>"
                tot.Controls.Add(tt)
                firsaltatable.Controls.Add(tot)
            ElseIf Me.Request.QueryString("item") = 3 Then  ' both salary and ta
                Dim tot As New TableRow
                tot.Width = 11
                Dim tt As New TableCell
                tt.ColumnSpan = 11
                tt.HorizontalAlign = HorizontalAlign.Left
                tt.Text = "<b><font size=3>Total:&nbsp;" & Me.toti & "&nbsp;Employee(s) and Sum of Total Salary=" & FormatNumber(Me.saltot, 2) & "&nbsp;And Sum of Total Incentives=" & FormatNumber(Me.tatot, 2) & "&nbsp;And Sum Of Total Amount=" & FormatNumber(Me.alltot, 2) & "&nbsp;Rupees </font></b>"
                tot.Controls.Add(tt)
                firsaltatable.Controls.Add(tot)
                
            End If

            Dim totq As New TableRow
            totq.Width = 11
            Dim ttq As New TableCell
            ttq.ColumnSpan = 11
            ttq.HorizontalAlign = HorizontalAlign.Left
            ttq.Text = "<font size=2>**Total Amount=Salary Amount+Allowances Amount of Particular Employee!!</font>"
            totq.Controls.Add(ttq)
            firsaltatable.Controls.Add(totq)



        Else         'No data 
            Dim warn As New TableRow
            warn.Width = 11
            Dim w1 As New TableCell
            w1.ColumnSpan = 11
            w1.HorizontalAlign = HorizontalAlign.Center
            w1.Text = "No Data Found!!"
            warn.Controls.Add(w1)
            firsaltatable.Controls.Add(warn)
        End If


            Panel_Firm_Sal_Ta.Controls.Add(firsaltatable)
    End Sub
End Class
