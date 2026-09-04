Imports system.data
Imports system.data.oracleclient
Partial Class specificempattend_individualreport_a698374d7466
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt6, dt7, dt8, dt9, dt10, dt11, dtb As New DataTable
    Dim oh As New helper.oracle.OracleHelper
    Dim fdt, tdt, emp, sql, sql1, brid As String
    Dim dr As DataRow
    Dim per, totalper As Double
    Dim totalp = 0, totals = 0
    Dim color = 0
    Dim firm As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fdt = Request.QueryString.Get("fdt")
        tdt = Request.QueryString.Get("tdt")
        emp = Request.QueryString.Get("emp")
        firm = Session("firm_id")
        brid = Session("branch_id")
        'KRISHNADAS SPECIAL TOUR REPORT MACPRO
        Dim empcode As Integer
        empcode = Request.QueryString.Get("empcode")
        sql = "select curr_date as day,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,decode(e_time,NULL,'----------',e_time) as evening_time, case when (da.m_time is null and da.pay_id not in (50,52)) and (da.pay_id not in (51,52) and da.e_time is null) then 'Absent' else case when da.pay_id in (50) and da.e_time is not null then 'Morning-REG' else case when da.pay_id in (51) and da.m_time is not null then 'Evening-REG' else case when da.pay_id in (52) then 'BOTH-REG' else case when (da.m_time>bt1.in_time and da.m_time<>'TOUR' and da.m_time<>'COMPEN' and da.pay_id not in (50,7,52)) and (da.e_time is null and da.pay_id not in (51,7,52)) then 'Late & Non-Marking' else case when da.m_time<=bt1.in_time and (da.e_time is null and da.pay_id not in (51,52)) then 'Non-Marking Evening' else case when (da.m_time is null and da.pay_id not in (50,52,7)) and da.e_time <bt2.out_time then 'Non-Marking Morning & Early-Going' else case when (da.m_time is null and da.pay_id not in (50,52)) and da.e_time >=bt2.out_time then 'Non-Marking Morning' else case when da.m_time<=bt1.in_time and (da.e_time<bt2.out_time and da.e_time<>'TOUR' and da.e_time<>'COMPEN' and da.pay_id not in (51,52,7)) then 'Early-Going' else case when (da.m_time>bt1.in_time and da.pay_id not in (50,52) ) and (da.e_time<bt2.out_time and da.pay_id not in (51,52,7)) then 'Late & Early Going' else case when (da.m_time>bt1.in_time and da.m_time<>'TOUR' and da.m_time<>'COMPEN' and da.pay_id not in (50,52,7)) and da.e_time>=bt2.out_time then 'Late' else case when da.pay_id in (50) and da.E_TIME is null then  'REG-Morning & Non-Marking Evening'   else case when da.pay_id in (51) and da.M_TIME is null then 'REG-EVENING & Non-Marking Morning'  else  case  when da.pay_id in (50) and da.e_time<>'TOUR' and da.e_time<>'COMPEN'  and da.E_TIME <bt2.out_time  then 'REG-Morning & Early-Going'  else  case  when da.pay_id in (51) and da.m_time<>'TOUR' and da.m_time<>'COMPEN'  and da.M_TIME>bt1.in_time then  'REG-Evening & Late' else case when da.pay_id in (52) then 'REG-Morning & Evening'  else '-' end end end end end end end end end end end end end end end end as remarks,case when da.gun_status<>0 then 'PUNCHING-BLOCK' else '--' end as block,bm.branch_name as bname,bm1.branch_name as ebname from tour_attendance da,employee_master em, time_tab bt1, time_tab bt2,employ_firm ef,branch_master bm,branch_master   bm1 where  em.emp_code=da.emp_code and  ef.firm_id='" & firm & "'   and ef.emp_code=em.emp_code and da.curr_date between '" & fdt & "' and '" & tdt & "' and bt1.shift_id=da.m_shift and bt2.shift_id=da.e_shift and da.M_BRANCH=bm.branch_id and da.E_BRANCH=bm1.branch_id and da.emp_code=" & emp & " order by day,morning_time"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Dim tb As New Table
        
        tb.Attributes.Add("width", "100%")
        Dim tr1 As New TableRow
        tr1.BackColor = Drawing.Color.WhiteSmoke
        Dim td11 As New TableCell
        td11.Attributes.Add("width", "100%")
        td11.ColumnSpan = 100
        td11.HorizontalAlign = HorizontalAlign.Center
        td11.Text = "<font size=4><b>" & Me.Session("firm_name") & "</b></font>"
        tr1.Controls.Add(td11)
        tb.Controls.Add(tr1)

        Dim tr2 As New TableRow
        tr2.BackColor = Drawing.Color.GhostWhite
        Dim td21 As New TableCell
        td21.Attributes.Add("width", "50%")
        td21.ColumnSpan = 50
        td21.HorizontalAlign = HorizontalAlign.Right
        td21.Text = "<font size=2><b>Branch-id :" & Me.Session("branch_id") & "</b></font>"
        tr2.Controls.Add(td21)
        Dim td22 As New TableCell
        td22.Attributes.Add("width", "50%")
        td22.ColumnSpan = 50
        td22.HorizontalAlign = HorizontalAlign.Left
        td22.Text = "<font size=2><b>Branch :" & Me.Session("branch_name") & "</b></font>"
        tr2.Controls.Add(td22)
        tb.Controls.Add(tr2)


        Dim tr3 As New TableRow
        tr3.BackColor = Drawing.Color.WhiteSmoke
        Dim td31 As New TableCell
        td31.Attributes.Add("width", "50%")
        td31.ColumnSpan = 50
        td31.HorizontalAlign = HorizontalAlign.Center
        td31.Text = "<font size=2><b>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</b></font>"
        tr3.Controls.Add(td31)
        Dim td32 As New TableCell
        td32.Attributes.Add("width", "50%")
        td32.ColumnSpan = 50
        td32.HorizontalAlign = HorizontalAlign.Center
        td32.Text = "<font size=2><b>Time :" & Format(Date.Now, "hh:mm:ss") & "</b></font>"
        tr3.Controls.Add(td32)
        tb.Controls.Add(tr3)


        Dim tr490 As New TableRow
        tr490.BackColor = Drawing.Color.WhiteSmoke
        Dim td410 As New TableCell
        td410.Attributes.Add("width", "100%")
        td410.ColumnSpan = 100
        td410.HorizontalAlign = HorizontalAlign.Center
        sql = "select initcap(branch_name) from branch_master where branch_id=" & brid
        dtb = oh.ExecuteDataSet(sql).Tables(0)
        td410.Text = "<font size=3><b>Attendance  Report From :&nbsp" & fdt & " &nbsp To :" & tdt & " </b></font>"
        tr490.Controls.Add(td410)
        tb.Controls.Add(tr490)

        dt1 = oh.ExecuteDataSet("select e.emp_name from employee_master e where e.emp_code=" & emp & "").Tables(0)

        Dim tr44 As New TableRow
        tr44.BackColor = Drawing.Color.GhostWhite
        Dim td414 As New TableCell
        td414.Attributes.Add("width", "80%")
        td414.ColumnSpan = 50
        td414.HorizontalAlign = HorizontalAlign.Center
        td414.Text = "<font size=2.5 color=Maroon><BR><b> EMPLOYEE NAME&nbsp:&nbsp" & dt1.Rows(0)(0) & "</b></font>"
        tr44.Controls.Add(td414)


        Dim td411 As New TableCell
        td411.Attributes.Add("width", "80%")
        td411.ColumnSpan = 50
        td411.HorizontalAlign = HorizontalAlign.Center
        td411.Text = "<font size=2.5 color=Maroon><BR><b> EMPLOYEE CODE&nbsp:&nbsp" & emp & "</b></font>"
        tr44.Controls.Add(td411)
        tb.Controls.Add(tr44)

        Dim l1 As New TableRow
        Dim ld1 As New TableCell
        ld1.Attributes.Add("width", "100%")
        ld1.ColumnSpan = 100
        ld1.HorizontalAlign = HorizontalAlign.Center
        ld1.Text = "<font size=3><hr size='2' NOSHADE></font>"
        l1.Controls.Add(ld1)
        tb.Controls.Add(l1)

        Dim tr5 As New TableRow
        tr5.BackColor = Drawing.Color.WhiteSmoke
        Dim td51 As New TableCell
        td51.Attributes.Add("width", "2%")
        td51.ColumnSpan = 8
        td51.HorizontalAlign = HorizontalAlign.Left
        td51.Text = "<font size=2.5><b>DATE</b></font>"
        tr5.Controls.Add(td51)


        Dim td55 As New TableCell
        td55.Attributes.Add("width", "15%")
        td55.ColumnSpan = 12
        td55.HorizontalAlign = HorizontalAlign.Left
        td55.Text = "<font size=2.5><b>MORNING TIME</b></font>"
        tr5.Controls.Add(td55)

        Dim td56 As New TableCell
        td56.Attributes.Add("width", "10%")
        td56.ColumnSpan = 12
        td56.HorizontalAlign = HorizontalAlign.Left
        td56.Text = "<font size=2.5><b>EVENING TIME</b></font>"
        tr5.Controls.Add(td56)


        Dim td58 As New TableCell
        td58.Attributes.Add("width", "20%")
        td58.ColumnSpan = 12
        td58.HorizontalAlign = HorizontalAlign.Center
        td58.Text = "<font size=2.5><b>REMARKS</b></font>"
        tr5.Controls.Add(td58)


        Dim td158 As New TableCell
        td158.Attributes.Add("width", "20%")
        td158.ColumnSpan = 27
        td158.HorizontalAlign = HorizontalAlign.Center
        td158.Text = "<font size=2.5><b>MORNING BRANCH</b></font>"
        tr5.Controls.Add(td158)

        Dim td159 As New TableCell
        td159.Attributes.Add("width", "20%")
        td159.ColumnSpan = 2
        td159.HorizontalAlign = HorizontalAlign.Center
        td159.Text = "<font size=2.5><b>EVENING BRANCH</b></font>"
        tr5.Controls.Add(td159)
        tb.Controls.Add(tr5)







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
            td61.ColumnSpan = 4
            td61.HorizontalAlign = HorizontalAlign.Left
            td61.Text = "<font size=2>" & Format(dr(0), "dd/MMM/yyyy") & "</font>"
            tr6.Controls.Add(td61)

            Dim td62 As New TableCell
            td62.Attributes.Add("width", "7%")
            td62.ColumnSpan = 17
            td62.HorizontalAlign = HorizontalAlign.Center
            td62.Text = "<font size=2>" & dr(1) & "</font>" '-----m TIME
            tr6.Controls.Add(td62)

            Dim td63 As New TableCell
            td63.Attributes.Add("width", "15%")
            td63.ColumnSpan = 10
            td63.HorizontalAlign = HorizontalAlign.Left
            td63.Text = "<font size=2>" & dr(2) & "</font>" '---etime
            tr6.Controls.Add(td63)


            'Dim td65 As New TableCell
            'td65.Attributes.Add("width", "15%")
            'td65.ColumnSpan = 6
            'td65.HorizontalAlign = HorizontalAlign.Left
            'td65.Text = "<font size=2>" & dr(3) & "</font>" '
            'tr6.Controls.Add(td65)










            If Not IsDBNull(dr(3)) Then
                If dr(3) = "Absent" Or dr(3) = "-" Then
                    'dt6 = oh.ExecuteDataSet("select count(*)from hrm_leave_apply_sanction a where a.emp_code =" & emp & " and ((to_date(a.leave_frdate)='" & Format(dr(0), "dd/MMM/yyyy") & "') or(to_date(a.leave_todate)='" & Format(dr(0), "dd/MMM/yyyy") & "')and a.status_id in (0,4,5,1))").Tables(0)
                    dt6 = oh.ExecuteDataSet("select count(*) from hrm_leave_apply_sanction a where a.emp_code = " & emp & " and ((to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between to_date(a.leave_frdate) and to_date(a.leave_todate)) or (to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between  to_date(a.leave_frdate) and to_date(a.leave_todate))) and a.status_id in (0, 4, 5, 1) ").Tables(0)
                    If dt6.Rows(0)(0) > 0 Then
                        'dt7 = oh.ExecuteDataSet("select a.emp_code,decode(a.status_id,0,'Leave Applied',4,'Leave Recommended',5,'Leave Recommended',1,'Leave Sanctioned',2,'Leave Rejected')from hrm_leave_apply_sanction a where a.emp_code =" & emp & " and ((to_date(a.leave_frdate)='" & Format(dr(0), "dd/MMM/yyyy") & "') or(to_date(a.leave_todate)='" & Format(dr(0), "dd/MMM/yyyy") & "')and a.status_id in (0,4,5,1))").Tables(0)
                        dt7 = oh.ExecuteDataSet("select distinct a.emp_code,decode(a.status_id,0,'Leave Applied',4,'Leave Recommended',5,'Leave Recommended',1,'Leave Sanctioned',2,'Leave Rejected')from hrm_leave_apply_sanction a where a.emp_code =" & emp & " and ((to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between to_date(a.leave_frdate) and to_date(a.leave_todate)) or (to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between  to_date(a.leave_frdate) and to_date(a.leave_todate))) and a.status_id in (0,4,5,1)").Tables(0)
                        Dim td68 As New TableCell
                        td68.Attributes.Add("width", "25%")
                        td68.ColumnSpan = 15
                        td68.HorizontalAlign = HorizontalAlign.Center
                        td68.Text = "<font size=2>" & dt7.Rows(0)(1) & "</font>"
                        tr6.Controls.Add(td68)
                        'tb.Controls.Add(tr6)
                    Else


                        dt8 = oh.ExecuteDataSet("select count(*) from hrm_comp_appl a where a.emp_code = " & emp & " and  to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') =to_date(a.leave_dt) and a.status_id in (0, 4, 1)  ").Tables(0)
                        If dt8.Rows(0)(0) > 0 Then
                            dt9 = oh.ExecuteDataSet("select distinct a.emp_code,decode(a.status_id,0,'COMPENOFF Applied',4,'COMPENOFF Recommended',1,'COMPENOFF Sanctioned',2,'COMPENOFF Rejected') from hrm_comp_appl a where a.emp_code =" & emp & " and  to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') =to_date(a.leave_dt) and a.status_id in (0,4,1)").Tables(0)
                            Dim td68 As New TableCell
                            td68.Attributes.Add("width", "25%")
                            td68.ColumnSpan = 15
                            td68.HorizontalAlign = HorizontalAlign.Center
                            td68.Text = "<font size=2>" & dt9.Rows(0)(1) & "</font>"
                            tr6.Controls.Add(td68)
                            'tb.Controls.Add(tr6)


                        Else


                            dt10 = oh.ExecuteDataSet("select count(*) from hrm_TOUR_dtl a where a.emp_code = " & emp & " and  to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between to_date(a.from_dt) and to_date(a.to_dt) and a.tour_id in (0, 4, 1)  ").Tables(0)
                            If dt10.Rows(0)(0) > 0 Then
                                dt11 = oh.ExecuteDataSet("select distinct a.emp_code,decode(a.tour_id,0,'TOUR Applied',4,'TOUR Recommended',1,'TOUR Sanctioned',2,'TOUR Rejected') from hrm_tour_dtl a where a.emp_code =" & emp & " and  to_date('" & Format(dr(0), "dd/MMM/yyyy") & "') between to_date(a.from_dt) and to_date(a.to_dt) and a.tour_id in (0,4,1)").Tables(0)
                                Dim td68 As New TableCell
                                td68.Attributes.Add("width", "25%")
                                td68.ColumnSpan = 15
                                td68.HorizontalAlign = HorizontalAlign.Center
                                td68.Text = "<font size=2>" & dt11.Rows(0)(1) & "</font>"
                                tr6.Controls.Add(td68)
                                'tb.Controls.Add(tr6)

                            Else
                                Dim td68 As New TableCell
                                td68.Attributes.Add("width", "25%")
                                td68.ColumnSpan = 15
                                td68.HorizontalAlign = HorizontalAlign.Center
                                td68.Text = "<font size=2>" & dr(3) & "</font>"
                                tr6.Controls.Add(td68)
                                'tb.Controls.Add(tr6)
                            End If

                        End If



                    End If
                Else
                    Dim td68 As New TableCell
                    td68.Attributes.Add("width", "25%")
                    td68.ColumnSpan = 15
                    td68.HorizontalAlign = HorizontalAlign.Center
                    td68.Text = "<font size=2>" & dr(3) & "</font>"
                    tr6.Controls.Add(td68)
                    'tb.Controls.Add(tr6)
                End If
            Else
                Dim td68 As New TableCell
                td68.Attributes.Add("width", "25%")
                td68.ColumnSpan = 15
                td68.HorizontalAlign = HorizontalAlign.Center
                td68.Text = "<font size=2>" & dr(3) & "</font>"
                tr6.Controls.Add(td68)
                'tb.Controls.Add(tr6)
            End If

            Dim td69 As New TableCell
            td69.Attributes.Add("width", "15%")
            td69.ColumnSpan = 5
            td69.HorizontalAlign = HorizontalAlign.Left
            td69.Text = "<font size=2></font>"
            tr6.Controls.Add(td69)

            Dim td70 As New TableCell
            td70.Attributes.Add("width", "25%")
            td70.ColumnSpan = 17
            td70.HorizontalAlign = HorizontalAlign.Left
            td70.Text = "<font size=2>" & dr(5) & "</font>"
            tr6.Controls.Add(td70)
            tb.Controls.Add(tr6)

            Dim td701 As New TableCell
            td701.Attributes.Add("width", "25%")
            td701.ColumnSpan = 9
            td701.HorizontalAlign = HorizontalAlign.Left
            td701.Text = "<font size=2>" & dr(6) & "</font>"
            tr6.Controls.Add(td701)
            tb.Controls.Add(tr6)

        Next



        Dim l3 As New TableRow
        Dim ld3 As New TableCell
        ld3.Attributes.Add("width", "100%")
        ld3.ColumnSpan = 80
        ld3.HorizontalAlign = HorizontalAlign.Center
        ld3.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
        l3.Controls.Add(ld3)
        tb.Controls.Add(l3)
        Me.Panel1.Controls.Add(tb)
        Me.Panel1.HorizontalAlign = HorizontalAlign.Center


    End Sub
End Class
