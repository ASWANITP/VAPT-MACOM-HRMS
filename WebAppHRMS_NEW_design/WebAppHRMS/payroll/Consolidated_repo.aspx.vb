Imports system.data
Imports system.data.oracleclient
Partial Class Attendence_Report_cosolidated_new_6ba650131068
    Inherits System.Web.UI.Page
    Dim dt, dt1, dtb, dt6, dt7, dt8, dt9, dt10, dt11, dt12 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql, sql1 As String
    Dim dr As DataRow
    Dim per, totalper As Double
    Dim totalp = 0, totals = 0
    Dim color = 0S

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fdate, tdate As String
        '''''KRISHNADAS MAFARM NEW REQUEST
        Dim brid As Integer
        Dim frid = Session("firm_id")
        fdate = Request.QueryString.Get("fdt")
        tdate = Request.QueryString.Get("tdt")
        sql = "select curr_date as day,bm.BRANCH_NAME,       em.emp_code as emp_code,       upper(em.emp_name)as Name,       decode(da.m_time, NULL, '----------', da.m_time) as morning_time,       decode(e_time, NULL, '----------', e_time) as evening_time,       case             when (da.m_time is null and da.pay_id not in (50, 52)) and (da.pay_id not in (51, 52) and da.e_time is null) then             'Absent'       else             case                     when da.pay_id in (50) and da.e_time is not null then                     'Morning-REG'             else                     case                             when da.pay_id in (51) and da.m_time is not null then                             'Evening-REG'                     else                             case                                       when da.pay_id in (52) then                                       'BOTH-REG'                             else                                       case                                                 when (da.m_time > bt1.in_time and da.m_time <> 'TOUR' and da.m_time <> 'COMPEN' and da.pay_id not in (50, 7, 52)) and   (da.e_time is null and da.pay_id not in (51, 7, 52)) then                                                 'Late & Non-Marking'                                       else          case         when da.m_time <= bt1.in_time and              (da.e_time is null and da.pay_id not in (51, 52)) then          'Non-Marking Evening'         else          case         when (da.m_time is null and da.pay_id not in (50, 52, 7)) and              da.e_time < bt2.out_time then          'Non-Marking Morning & Early-Going'         else          case         when (da.m_time is null and da.pay_id not in (50, 52)) and              da.e_time >= bt2.out_time then          'Non-Marking Morning'         else          case         when da.m_time <= bt1.in_time and              (da.e_time < bt2.out_time and da.e_time <> 'TOUR' and              da.e_time <> 'COMPEN' and da.pay_id not in (51, 52, 7)) then          'Early-Going'         else          case         when (da.m_time > bt1.in_time and da.pay_id not in (50, 52)) and              (da.e_time < bt2.out_time and da.pay_id not in (51, 52, 7)) then  'Late & Early Going'         else          case         when (da.m_time > bt1.in_time and da.m_time <> 'TOUR' and              da.m_time <> 'COMPEN' and da.pay_id not in (50, 52, 7)) and              da.e_time >= bt2.out_time then        'Late'         else          case         when da.pay_id in (50) and da.E_TIME is null then        'REG-Morning & Non-Marking Evening'         else          case         when da.pay_id in (51) and da.M_TIME is null then        'REG-Morning & Non-Marking Morning'         else          case         when da.pay_id in (50) and da.e_time <> 'TOUR' and              da.e_time <> 'COMPEN' and da.E_TIME < bt2.out_time then        'REG-Morning & Early-Going'         else          case         when da.pay_id in (51) and da.m_time <> 'TOUR' and              da.m_time <> 'COMPEN' and da.M_TIME > bt1.in_time then        'REG-Evening & Late'         else          case         when da.pay_id in (52) then        'REG-Morning & Evening'         else        ''       end end end end end end end end end end end end end end end end as remarks  from ATTENDANCE      da,       employee_master em,       branch          bm,       branch_master   bm1,       branch_master   bm2,       time_tab        bt1,       time_tab        bt2,        employ_firm ef        where em.emp_code = da.emp_code   and bm.branch_id = em.branch_id   and da.curr_date >= to_date('" & fdate & "')   and da.curr_date <= to_date('" & tdate & "')   and em.branch_id = da.branch_id   and da.m_shift = bt1.shift_id   and da.e_shift = bt2.shift_id   and bm1.branch_id = da.m_branch   and bm2.branch_id = da.e_branch   and em.emp_code=ef.emp_code and ef.firm_id='" & frid & "'                                union all   select to_date('" & tdate & "') day,b.branch_name BRANCH_NAME ,e.emp_code emp_code,e.emp_name,'----------','----------','Excluded from Daily Punching' from employee_master e join branch_master b on b.branch_id=e.branch_id join employ_firm f on f.emp_code=e.emp_code and f.firm_id='" & frid & "'    join (select x.emp_code, x.excep from (select t.emp_code, count(p.emp_code) over(partition by t.emp_code) excep  from employee_master t  left join hrm_exep_employs p on p.emp_code = t.emp_code  and p.status = 1 where t.status_id = 1) x  where (x.excep = 1))y on y.emp_code=e.emp_code order by day, BRANCH_NAME,emp_code"
        '''''old_sql = "select curr_date as day,em.emp_code as emp_code,upper(substr(em.emp_name,0,19)) as Name,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,case when m_time is not null then substr(bm1.branch_name,0,12) else '' end as Morning_Branch,decode(e_time,NULL,'----------',e_time) as evening_time,case when e_time is not null then substr(bm2.branch_name,0,12) else '' end  as Evening_Branch,case when (da.m_time is null and da.pay_id not in (50,52)) and (da.pay_id not in (51,52) and da.e_time is null) then 'Absent' else case when da.pay_id in (50) and da.e_time is not null then 'Morning-REG' else case when da.pay_id in (51) and da.m_time is not null then 'Evening-REG' else case when da.pay_id in (52) then 'BOTH-REG' else case when (da.m_time>bt1.in_time and da.m_time<>'TOUR' and da.m_time<>'COMPEN' and da.pay_id not in (50,7,52)) and (da.e_time is null and da.pay_id not in (51,7,52)) then 'Late & Non-Marking' else case when da.m_time<=bt1.in_time and (da.e_time is null and da.pay_id not in (51,52)) then 'Non-Marking Evening' else case when (da.m_time is null and da.pay_id not in (50,52,7)) and da.e_time <bt2.out_time then 'Non-Marking Morning & Early-Going' else case when (da.m_time is null and da.pay_id not in (50,52)) and da.e_time >=bt2.out_time then 'Non-Marking Morning' else case when da.m_time<=bt1.in_time and (da.e_time<bt2.out_time and da.e_time<>'TOUR' and da.e_time<>'COMPEN' and da.pay_id not in (51,52,7)) then 'Early-Going' else case when (da.m_time>bt1.in_time and da.pay_id not in (50,52) ) and (da.e_time<bt2.out_time and da.pay_id not in (51,52,7)) then 'Late & Early Going' else case when (da.m_time>bt1.in_time and da.m_time<>'TOUR' and da.m_time<>'COMPEN' and da.pay_id not in (50,52,7)) and da.e_time>=bt2.out_time then 'Late' else case when da.pay_id in (50) and da.E_TIME is null then  'REG-Morning & Non-Marking Evening'   else case when da.pay_id in (51) and da.M_TIME is null then 'REG-Morning & Non-Marking Morning'  else  case  when da.pay_id in (50) and da.e_time<>'TOUR' and da.e_time<>'COMPEN'  and da.E_TIME <bt2.out_time  then 'REG-Morning & Early-Going'  else  case  when da.pay_id in (51) and da.m_time<>'TOUR' and da.m_time<>'COMPEN'  and da.M_TIME>bt1.in_time then  'REG-Evening & Late' else case when da.pay_id in (52) then 'REG-Morning & Evening'  else '' end end end end end end end end end end end end end end end end as remarks from ATTENDANCE da,employee_master em,branch bm,branch_master bm1,branch_master bm2,time_tab bt1,time_tab bt2 where  em.emp_code=da.emp_code and bm.branch_id=em.branch_id and da.curr_date>='" & Request.QueryString.Get("fdate") & "' and da.curr_date<='" & Request.QueryString.Get("fdate") & "' and em.branch_id=da.branch_id  and da.m_shift=bt1.shift_id and da.e_shift=bt2.shift_id and bm1.branch_id=da.m_branch and da.branch_id = " & Request.QueryString.Get("brid") & "  and bm.firm_id=" & Session("firm_id") & " and bm2.branch_id=da.e_branch and da.branch_id=" & Request.QueryString.Get("brid") & " order by da.emp_code,bm.branch_id,day"
        ''no_punch="union   select '---' as day,b.branch_name,q.emp_code as emp_code, upper(q.emp_name) as Name, ' -- ',' -- ','NON PUNCHING EMPLOYEE'   from employee_master q   join (select e.emp_code from hrm_exep_employs e   join employee_master em on em.emp_code=e.emp_code and em.status_id=1 where e.status=1union select p.emp_code from hrm_notpunching p   join employee_master w on w.emp_code=p.emp_code and w.status_id=1 )x   on x.emp_code=q.emp_code   join branch_master b on q.branch_id=b.branch_id   join employ_firm fd on fd.emp_code=q.emp_code and fd.firm_id='" & frid & "'"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Dim tb As New Table


        tb.Attributes.Add("width", "100%")

        Dim tr1 As New TableRow
        Dim td11 As New TableCell
        td11.Attributes.Add("width", "100%")
        td11.ColumnSpan = 80
        td11.HorizontalAlign = HorizontalAlign.Center
        td11.Text = "<font size=4><b>" & Me.Session("firm_name") & "</b></font>"
        tr1.Controls.Add(td11)
        tb.Controls.Add(tr1)

        Dim tr2 As New TableRow
        Dim td21 As New TableCell
        td21.Attributes.Add("width", "50%")
        td21.ColumnSpan = 40
        td21.HorizontalAlign = HorizontalAlign.Right
        td21.Text = "<font size=2><b>Branch-id :" & Me.Session("branch_id") & "</b></font>"
        tr2.Controls.Add(td21)
        Dim td22 As New TableCell
        td22.Attributes.Add("width", "50%")
        td22.ColumnSpan = 40
        td22.HorizontalAlign = HorizontalAlign.Left
        td22.Text = "<font size=2><b>Branch :" & Me.Session("branch_name") & "</b></font>"
        tr2.Controls.Add(td22)
        tb.Controls.Add(tr2)


        Dim tr3 As New TableRow
        Dim td31 As New TableCell
        td31.Attributes.Add("width", "50%")
        td31.ColumnSpan = 40
        td31.HorizontalAlign = HorizontalAlign.Left
        td31.Text = "<font size=2><b>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</b></font>"
        tr3.Controls.Add(td31)
        Dim td32 As New TableCell
        td32.Attributes.Add("width", "50%")
        td32.ColumnSpan = 40
        td32.HorizontalAlign = HorizontalAlign.Right
        td32.Text = "<font size=2><b>Time :" & Format(Date.Now, "hh:mm:ss") & "</b></font>"
        tr3.Controls.Add(td32)
        tb.Controls.Add(tr3)


        Dim tr4 As New TableRow
        tr4.BackColor = Drawing.Color.WhiteSmoke
        Dim td41 As New TableCell
        td41.Attributes.Add("width", "100%")
        td41.ColumnSpan = 80
        td41.HorizontalAlign = HorizontalAlign.Center
        sql = "select initcap(branch_name) from branch_master where branch_id=" & brid
        dtb = oh.ExecuteDataSet(sql).Tables(0)
        td41.Text = "<font size=3><b>Consolidated Attendance  Report From :&nbsp" & fdate & " &nbsp To :" & tdate & " </b></font>"
        tr4.Controls.Add(td41)
        tb.Controls.Add(tr4)

        Dim l1 As New TableRow
        Dim ld1 As New TableCell
        ld1.Attributes.Add("width", "100%")
        ld1.ColumnSpan = 80
        ld1.HorizontalAlign = HorizontalAlign.Center
        ld1.Text = "<font size=3><hr size='2' NOSHADE></font>"
        l1.Controls.Add(ld1)
        tb.Controls.Add(l1)

        Dim tr5 As New TableRow
        Dim td51 As New TableCell
        td51.Attributes.Add("width", "2%")
        td51.ColumnSpan = 8
        td51.HorizontalAlign = HorizontalAlign.Left
        td51.Text = "<font size=2.5><b>DATE</b></font>"
        tr5.Controls.Add(td51)

        Dim td52 As New TableCell
        td52.Attributes.Add("width", "7%")
        td52.ColumnSpan = 16
        td52.HorizontalAlign = HorizontalAlign.Left
        td52.Text = "<font size=2.5><b>BRANCH NAME</b></font>"
        tr5.Controls.Add(td52)

        Dim td53 As New TableCell
        td53.Attributes.Add("width", "15%")
        td53.ColumnSpan = 10
        td53.HorizontalAlign = HorizontalAlign.Left
        td53.Text = "<font size=2.5><b>EMPLOYEE CODE</b></font>"
        tr5.Controls.Add(td53)


        Dim td54 As New TableCell
        td54.Attributes.Add("width", "10%")
        td54.ColumnSpan = 15
        td54.HorizontalAlign = HorizontalAlign.Left
        td54.Text = "<font size=2.5><b>EMPLOYEE NAME</b></font>"
        tr5.Controls.Add(td54)

        Dim td55 As New TableCell
        td55.Attributes.Add("width", "15%")
        td55.ColumnSpan = 6
        td55.HorizontalAlign = HorizontalAlign.Left
        td55.Text = "<font size=2.5><b>MORNING TIME</b></font>"
        tr5.Controls.Add(td55)

        Dim td56 As New TableCell
        td56.Attributes.Add("width", "10%")
        td56.ColumnSpan = 6
        td56.HorizontalAlign = HorizontalAlign.Left
        td56.Text = "<font size=2.5><b>EVENING TIME</b></font>"
        tr5.Controls.Add(td56)

        'Dim td57 As New TableCell
        'td57.Attributes.Add("width", "15%")
        'td57.ColumnSpan = 15
        'td57.HorizontalAlign = HorizontalAlign.Left
        'td57.Text = "<font size=2.5><b>EVENING BRANCH</b></font>"
        'tr5.Controls.Add(td57)

        Dim td58 As New TableCell
        td58.Attributes.Add("width", "20%")
        td58.ColumnSpan = 12
        td58.HorizontalAlign = HorizontalAlign.Center
        td58.Text = "<font size=2.5><b>REMARKS</b></font>"
        tr5.Controls.Add(td58)
        tb.Controls.Add(tr5)
        tb.Controls.Add(tr5)

        Dim l2 As New TableRow
        Dim ld2 As New TableCell
        ld2.Attributes.Add("width", "100%")
        ld2.ColumnSpan = 80
        ld2.HorizontalAlign = HorizontalAlign.Center
        ld2.Text = "<font size=3><hr size='2' NOSHADE></font>"
        l2.Controls.Add(ld2)
        tb.Controls.Add(l2)

        For Each dr In dt.Rows
            Dim tr6 As New TableRow
            If (color = 0) Then
                tr6.BackColor = Drawing.Color.GhostWhite
                color = 1
            Else
                tr6.BackColor = Drawing.Color.WhiteSmoke
                color = 0
            End If
            Dim td61 As New TableCell
            td61.Attributes.Add("width", "8%")
            td61.ColumnSpan = 8
            td61.HorizontalAlign = HorizontalAlign.Left
            td61.Text = "<font size=2>" & Format(dr(0), "dd/MMM/yyyy") & "</font>"
            tr6.Controls.Add(td61)

            Dim td62 As New TableCell
            td62.Attributes.Add("width", "7%")
            td62.ColumnSpan = 17
            td62.HorizontalAlign = HorizontalAlign.Center
            'td62.Text = "<font size=2><a href=javascript:next(" & dr(1) & ")>" & dr(1) & "</font>"
            td62.Text = "<font size=2>" & dr(1) & "</font>"
            tr6.Controls.Add(td62)

            Dim td63 As New TableCell
            td63.Attributes.Add("width", "15%")
            td63.ColumnSpan = 10
            td63.HorizontalAlign = HorizontalAlign.Left ''''''''''''EMPLOYEE CODE
            td63.Text = "<font size=2>" & dr(2) & "</font>"
            tr6.Controls.Add(td63)


            Dim td64 As New TableCell
            td64.Attributes.Add("width", "15%")
            td64.ColumnSpan = 15
            td64.HorizontalAlign = HorizontalAlign.Left
            td64.Text = "<font size=2>" & dr(3) & "</font>"
            tr6.Controls.Add(td64)

            Dim td65 As New TableCell
            td65.Attributes.Add("width", "15%")
            td65.ColumnSpan = 6
            td65.HorizontalAlign = HorizontalAlign.Left
            td65.Text = "<font size=2>" & dr(4) & "</font>"
            tr6.Controls.Add(td65)

            Dim td66 As New TableCell
            td66.Attributes.Add("width", "10%")
            td66.ColumnSpan = 6
            td66.HorizontalAlign = HorizontalAlign.Left
            td66.Text = "<font size=2>" & dr(5) & "</font>"
            tr6.Controls.Add(td66)

            'Dim td67 As New TableCell
            'td67.Attributes.Add("width", "15%")
            'td67.ColumnSpan = 15
            'td67.HorizontalAlign = HorizontalAlign.Left
            'td67.Text = "<font size=2>" & dr(6) & "</font>"
            'tr6.Controls.Add(td67)

            '-------------------------------------
            If Not IsDBNull(dr(6)) Then
                If dr(6) = "Absent" Or dr(6) = "-" Then
                    'dt6 = oh.ExecuteDataSet("select count(*)from hrm_leave_apply_sanction a where a.emp_code =" & emp & " and ((to_date(a.leave_frdate)='" & Format(dr(0), "dd/MMM/yyyy") & "') or(to_date(a.leave_todate)='" & Format(dr(0), "dd/MMM/yyyy") & "')and a.status_id in (0,4,5,1))").Tables(0)
                    dt6 = oh.ExecuteDataSet("select count(*) from hrm_leave_apply_sanction a where a.emp_code = " & dr(2) & " and ((to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between to_date(a.leave_frdate) and to_date(a.leave_todate)) or (to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between  to_date(a.leave_frdate) and to_date(a.leave_todate))) and a.status_id in (0, 4, 5, 1) ").Tables(0)
                    If dt6.Rows(0)(0) > 0 Then
                        'dt7 = oh.ExecuteDataSet("select a.emp_code,decode(a.status_id,0,'Leave Applied',4,'Leave Recommended',5,'Leave Recommended',1,'Leave Sanctioned',2,'Leave Rejected')from hrm_leave_apply_sanction a where a.emp_code =" & emp & " and ((to_date(a.leave_frdate)='" & Format(dr(0), "dd/MMM/yyyy") & "') or(to_date(a.leave_todate)='" & Format(dr(0), "dd/MMM/yyyy") & "')and a.status_id in (0,4,5,1))").Tables(0)
                        dt7 = oh.ExecuteDataSet("select distinct a.emp_code,decode(a.status_id,0,'Leave Applied',4,'Leave Recommended',5,'Leave Recommended',1,'Leave Sanctioned',2,'Leave Rejected')from hrm_leave_apply_sanction a where a.emp_code =" & dr(2) & " and ((to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between to_date(a.leave_frdate) and to_date(a.leave_todate)) or (to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between  to_date(a.leave_frdate) and to_date(a.leave_todate))) and a.status_id in (0,4,5,1)").Tables(0)
                        Dim td68 As New TableCell
                        td68.Attributes.Add("width", "25%")
                        td68.ColumnSpan = 15
                        td68.HorizontalAlign = HorizontalAlign.Center
                        td68.Text = "<font size=2>" & dt7.Rows(0)(1) & "</font>"
                        tr6.Controls.Add(td68)
                        tb.Controls.Add(tr6)
                    Else


                        dt8 = oh.ExecuteDataSet("select count(*) from hrm_comp_appl a where a.emp_code = " & dr(2) & " and  to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') =to_date(a.leave_dt) and a.status_id in (0, 4, 1)  ").Tables(0)
                        If dt8.Rows(0)(0) > 0 Then
                            dt9 = oh.ExecuteDataSet("select distinct a.emp_code,decode(a.status_id,0,'COMPENOFF Applied',4,'COMPENOFF Recommended',1,'COMPENOFF Sanctioned',2,'COMPENOFF Rejected') from hrm_comp_appl a where a.emp_code =" & dr(2) & " and  to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') =to_date(a.leave_dt) and a.status_id in (0,4,1)").Tables(0)
                            Dim td68 As New TableCell
                            td68.Attributes.Add("width", "25%")
                            td68.ColumnSpan = 15
                            td68.HorizontalAlign = HorizontalAlign.Center
                            td68.Text = "<font size=2>" & dt9.Rows(0)(1) & "</font>"
                            tr6.Controls.Add(td68)
                            tb.Controls.Add(tr6)


                        Else


                            dt10 = oh.ExecuteDataSet("select count(*) from hrm_TOUR_dtl a where a.emp_code = " & dr(2) & " and  to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between to_date(a.from_dt) and to_date(a.to_dt) and a.tour_id in (0, 4, 1)  ").Tables(0)
                            If dt10.Rows(0)(0) > 0 Then
                                dt11 = oh.ExecuteDataSet("select distinct a.emp_code,decode(a.tour_id,0,'TOUR Applied',4,'TOUR Recommended',1,'TOUR Sanctioned',2,'TOUR Rejected') from hrm_tour_dtl a where a.emp_code =" & dr(2) & " and  to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between to_date(a.from_dt) and to_date(a.to_dt) and a.tour_id in (0,4,1)").Tables(0)
                                Dim td68 As New TableCell
                                td68.Attributes.Add("width", "25%")
                                td68.ColumnSpan = 15
                                td68.HorizontalAlign = HorizontalAlign.Center
                                td68.Text = "<font size=2>" & dt11.Rows(0)(1) & "</font>"
                                tr6.Controls.Add(td68)
                                tb.Controls.Add(tr6)

                            Else
                                Dim td68 As New TableCell
                                td68.Attributes.Add("width", "25%")
                                td68.ColumnSpan = 15
                                td68.HorizontalAlign = HorizontalAlign.Center
                                td68.Text = "<font size=2>" & dr(6) & "</font>"
                                tr6.Controls.Add(td68)
                                tb.Controls.Add(tr6)
                            End If

                        End If



                    End If
                Else
                    Dim td68 As New TableCell
                    td68.Attributes.Add("width", "25%")
                    td68.ColumnSpan = 15
                    td68.HorizontalAlign = HorizontalAlign.Center
                    td68.Text = "<font size=2>" & dr(6) & "</font>"
                    tr6.Controls.Add(td68)
                    tb.Controls.Add(tr6)
                End If
            Else
                

                '--------------------------------------

                Dim td68 As New TableCell
                td68.Attributes.Add("width", "20%")
                td68.ColumnSpan = 12S
                td68.HorizontalAlign = HorizontalAlign.Center
                td68.Text = "<font size=2>" & dr(6) & "</font>"
                tr6.Controls.Add(td68)
                tb.Controls.Add(tr6)
            End If
        Next

        Dim l3 As New TableRow
        Dim ld3 As New TableCell
        ld3.Attributes.Add("width", "100%")
        ld3.ColumnSpan = 80
        ld3.HorizontalAlign = HorizontalAlign.Center
        ld3.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
        l3.Controls.Add(ld3)
        tb.Controls.Add(l3)
        Me.Panel_report.Controls.Add(tb)
        Me.Panel_report.HorizontalAlign = HorizontalAlign.Center

    End Sub
End Class
