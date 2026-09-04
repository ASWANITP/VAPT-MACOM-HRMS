Imports system.data
Imports system.data.oracleclient

Partial Class Attendence_Report_PresentReportE_9703487c8110
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql, sql1 As String
    Dim dr As DataRow
    Dim per, totalper As Double
    Dim totalp = 0, totals = 0
    Dim category As Integer
    Dim cat As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fdate, tdate As String
        Dim brid As Integer
        fdate = Request.QueryString.Get("fdate")
        tdate = Request.QueryString.Get("tdate")
        brid = Request.QueryString.Get("brid")
        category = Request.QueryString.Get("category")
        Select Case category
            Case 1
                sql = "select to_date(curr_date) as day,em.emp_code as emp_code,upper(substr(em.emp_name,0,19)) as Name,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,decode(bm1.branch_name,'A.O.VALAPAD','',substr(bm1.branch_name,0,12)) as Morning_Branch,decode(e_time,NULL,'----------',e_time) as evening_time,decode(bm2.branch_name,'A.O.VALAPAD','',substr(bm2.branch_name,0,12)) as Evening_Branch,case when (da.m_time is null and da.pay_id not in (50,52)) and (da.pay_id not in (51,52) and da.e_time is null) then 'Absent' else case when da.pay_id in (50) and da.e_time is not null then 'Morning-REG' else case when da.pay_id in (51) and da.m_time is not null then 'Evening-REG' else case when da.pay_id in (52) then 'BOTH-REG'  else case when (da.m_time>tt.in_time and da.m_time<>'TOUR' and da.m_time<>'COMPEN' and da.pay_id not in (50,52,7)) and (da.e_time is null and da.pay_id not in (51,52,7)) then 'Late & Non-Marking' else case when da.m_time<=tt.in_time and (da.e_time is null and da.pay_id not in (51,52)) then 'Non-Marking Evening' else case when (da.m_time is null and da.pay_id not in (50,52,7)) and da.e_time <tt1.out_time then 'Non-Marking Morning & Early-Going' else case when (da.m_time is null and da.pay_id not in (50,52)) and da.e_time >=tt1.out_time then 'Non-Marking Morning' else case when da.m_time<=tt.in_time and (da.e_time<tt1.out_time and da.pay_id not in (51,52,7)) then 'Early-Going' else case when (da.m_time>tt.in_time and da.pay_id not in (50,52,7) ) and (da.e_time<tt1.out_time and da.pay_id not in (51,52,7)) then 'Late & Early Going' else case when (da.m_time>tt.in_time and da.m_time<>'TOUR' and da.m_time<>'COMPEN' and da.pay_id not in (50,52,7)) and da.e_time>=tt1.out_time then 'Late' else case when da.pay_id in (50) and da.E_TIME is null then  'REG-Morning & Non-Marking Evening'   else case when da.pay_id in (51) and da.M_TIME is null then 'REG-Morning & Non-Marking Morning'  else  case  when da.pay_id in (50) and da.e_time<>'TOUR' and da.e_time<>'COMPEN'  and da.E_TIME <tt1.out_time then 'REG-Morning & Early-Going'  else  case  when da.pay_id in (51) and da.m_time<>'TOUR' and da.m_time<>'COMPEN'  and da.M_TIME>tt.in_time then  'REG-Evening & Late' else case when da.pay_id in (52) then 'REG-Morning & Evening'   else '' end end end end end end end end end end end end end end end end as remarks from ATTENDANCE da,employee_master em,branch_master bm,branch_master bm1,branch_master bm2,time_tab tt,time_tab tt1 where  em.emp_code=da.emp_code and bm.branch_id=em.branch_id and to_date(da.curr_date)>='" & Request.QueryString.Get("fdate") & "' and to_date(da.curr_date)<='" & Request.QueryString.Get("tdate") & "' and em.branch_id=da.branch_id  and da.m_shift=tt.shift_id and da.e_shift=tt1.shift_id and bm1.branch_id=da.m_branch and bm2.branch_id=da.e_branch and da.branch_id=" & Request.QueryString.Get("brid") & " and (da.m_time is not null or  da.e_time is not null or da.pay_id in (50,51,52,7)) and bm.firm_id = " & Session("firm_id") & " order by bm.branch_id,day"
                cat = "PRESENT"

            Case 2
                sql = "select to_date(curr_date) as day,em.emp_code as emp_code,upper(substr(em.emp_name,0,19)) as Name,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,decode(bm1.branch_name,'A.O.VALAPAD','',substr(bm1.branch_name,0,12)) as Morning_Branch,decode(e_time,NULL,'----------',e_time) as evening_time,decode(bm2.branch_name,'A.O.VALAPAD','',substr(bm2.branch_name,0,12)) as Evening_Branch,case when (da.m_time is null and da.pay_id not in (50,52)) and (da.pay_id not in (51,52) and da.e_time is null) then 'Absent' else case when da.pay_id in (50) and da.e_time is not null then 'Morning-REG' else case when da.pay_id in (51) and da.m_time is not null then 'Evening-REG' else case when da.pay_id in (52) then 'BOTH-REG'  else case when (da.m_time>tt.in_time and da.m_time<>'TOUR' and da.m_time<>'COMPEN' and da.pay_id not in (50,52,7)) and (da.e_time is null and da.pay_id not in (51,52,7)) then 'Late & Non-Marking' else case when da.m_time<=tt.in_time and (da.e_time is null and da.pay_id not in (51,52)) then 'Non-Marking Evening' else case when (da.m_time is null and da.pay_id not in (50,52,7)) and da.e_time <tt.out_time then 'Non-Marking Morning & Early-Going' else case when (da.m_time is null and da.pay_id not in (50,52)) and da.e_time >=tt.out_time then 'Non-Marking Morning' else case when da.m_time<=tt.in_time and (da.e_time<tt.out_time and da.pay_id not in (51,52,7)) then 'Early-Going' else case when (da.m_time>tt.in_time and da.pay_id not in (50,52,7) ) and (da.e_time<tt.out_time and da.pay_id not in (51,52,7)) then 'Late & Early Going' else case when (da.m_time>tt.in_time and da.m_time<>'TOUR' and da.m_time<>'COMPEN' and da.pay_id not in (50,52,7)) and da.e_time>=tt.out_time then 'Late' else case when da.pay_id in (50) and da.E_TIME is null then  'REG-Morning & Non-Marking Evening'   else case when da.pay_id in (51) and da.M_TIME is null then 'REG-Morning & Non-Marking Morning'  else  case  when da.pay_id in (50) and da.e_time<>'TOUR' and da.e_time<>'COMPEN'  and da.E_TIME <tt.out_time then 'REG-Morning & Early-Going'  else  case  when da.pay_id in (51) and da.m_time<>'TOUR' and da.m_time<>'COMPEN'  and da.M_TIME>tt.in_time then  'REG-Evening & Late' else case when da.pay_id in (52) then 'REG-Morning & Evening'   else '' end end end end end end end end end end end end end end end end as remarks from ATTENDANCE da,employee_master em,branch_master bm,branch_master bm1,branch_master bm2,time_tab tt where  em.emp_code=da.emp_code and bm.branch_id=em.branch_id and to_date(da.curr_date)>='" & Request.QueryString.Get("fdate") & "' and to_date(da.curr_date)<='" & Request.QueryString.Get("tdate") & "' and em.branch_id=da.branch_id  and da.shift_id not in (4,5) and da.shift_id=tt.shift_id and bm1.branch_id=da.m_branch and bm2.branch_id=da.e_branch and da.branch_id=" & Request.QueryString.Get("brid") & " and da.m_time is  null and da.e_time is  null and da.pay_id not in (50,51,52,7) and bm.firm_id = " & Session("firm_id") & " order by bm.branch_id,day"
                cat = "ABSENT"

            Case 3
                sql = "select to_date(curr_date) as day,em.emp_code as emp_code,upper(substr(em.emp_name,0,19)) as Name,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,decode(bm1.branch_name,'A.O.VALAPAD','',substr(bm1.branch_name,0,12)) as Morning_Branch,decode(e_time,NULL,'----------',e_time) as evening_time,decode(bm2.branch_name,'A.O.VALAPAD','',substr(bm2.branch_name,0,12)) as Evening_Branch,case when (da.m_time is null and da.pay_id not in (50,52)) and (da.pay_id not in (51,52) and da.e_time is null) then 'Absent' else case when da.pay_id in (50) and da.e_time is not null then 'Morning-REG' else case when da.pay_id in (51) and da.m_time is not null then 'Evening-REG' else case when da.pay_id in (52) then 'BOTH-REG'  else case when (da.m_time>tt.in_time and da.m_time<>'TOUR' and da.m_time<>'COMPEN' and da.pay_id not in (50,52,7)) and (da.e_time is null and da.pay_id not in (51,52,7)) then 'Late & Non-Marking' else case when da.m_time<=tt.in_time and (da.e_time is null and da.pay_id not in (51,52)) then 'Non-Marking Evening' else case when (da.m_time is null and da.pay_id not in (50,52,7)) and da.e_time <tt1.out_time then 'Non-Marking Morning & Early-Going' else case when (da.m_time is null and da.pay_id not in (50,52)) and da.e_time >=tt1.out_time then 'Non-Marking Morning' else case when da.m_time<=tt.in_time and (da.e_time<tt1.out_time and da.pay_id not in (51,52,7)) then 'Early-Going' else case when (da.m_time>tt.in_time and da.pay_id not in (50,52,7) ) and (da.e_time<tt1.out_time and da.pay_id not in (51,52,7)) then 'Late & Early Going' else case when (da.m_time>tt.in_time and da.m_time<>'TOUR' and da.m_time<>'COMPEN' and da.pay_id not in (50,52,7)) and da.e_time>=tt1.out_time then 'Late' else case when da.pay_id in (50) and da.E_TIME is null then  'REG-Morning & Non-Marking Evening'   else case when da.pay_id in (51) and da.M_TIME is null then 'REG-Morning & Non-Marking Morning'  else  case  when da.pay_id in (50) and da.e_time<>'TOUR' and da.e_time<>'COMPEN'  and da.E_TIME <tt1.out_time then 'REG-Morning & Early-Going'  else  case  when da.pay_id in (51) and da.m_time<>'TOUR' and da.m_time<>'COMPEN'  and da.M_TIME>tt.in_time then  'REG-Evening & Late' else case when da.pay_id in (52) then 'REG-Morning & Evening'   else '' end end end end end end end end end end end end end end end end as remarks from ATTENDANCE da,time_tab tt,time_tab tt1,employee_master em,branch_master bm,branch_master bm1,branch_master bm2 where  em.emp_code=da.emp_code and bm.branch_id=em.branch_id and to_date(da.curr_date)>='" & Request.QueryString.Get("fdate") & "' and to_date(da.curr_date)<='" & Request.QueryString.Get("tdate") & "' and em.branch_id=da.branch_id  and da.m_shift=tt.shift_id and  da.e_shift=tt1.shift_id and bm1.branch_id=da.m_branch and bm2.branch_id=da.e_branch and da.branch_id=" & Request.QueryString.Get("brid") & " And da.m_time > tt.in_time and da.m_time<>'ONDUTY' and da.pay_id not in (50,52,7) and bm.firm_id = " & Session("firm_id") & " order by bm.branch_id,day"
                cat = "LATE"

            Case 4
                sql = "select to_date(curr_date) as day,em.emp_code as emp_code,upper(substr(em.emp_name,0,19)) as Name,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,decode(bm1.branch_name,'A.O.VALAPAD','',substr(bm1.branch_name,0,12)) as Morning_Branch,decode(e_time,NULL,'----------',e_time) as evening_time,decode(bm2.branch_name,'A.O.VALAPAD','',substr(bm2.branch_name,0,12)) as Evening_Branch,case when (da.m_time is null and da.pay_id not in (50,52)) and (da.pay_id not in (51,52) and da.e_time is null) then 'Absent' else case when da.pay_id in (50) and da.e_time is not null then 'Morning-REG' else case when da.pay_id in (51) and da.m_time is not null then 'Evening-REG' else case when da.pay_id in (52) then 'BOTH-REG'  else case when (da.m_time>tt.in_time and da.m_time<>'TOUR' and da.m_time<>'COMPEN' and da.pay_id not in (50,52,7)) and (da.e_time is null and da.pay_id not in (51,52,7)) then 'Late & Non-Marking' else case when da.m_time<=tt.in_time and (da.e_time is null and da.pay_id not in (51,52)) then 'Non-Marking Evening' else case when (da.m_time is null and da.pay_id not in (50,52,7)) and da.e_time <tt1.out_time then 'Non-Marking Morning & Early-Going' else case when (da.m_time is null and da.pay_id not in (50,52)) and da.e_time >=tt1.out_time then 'Non-Marking Morning' else case when da.m_time<=tt.in_time and (da.e_time<tt1.out_time and da.pay_id not in (51,52,7)) then 'Early-Going' else case when (da.m_time>tt.in_time and da.pay_id not in (50,52,7) ) and (da.e_time<tt1.out_time and da.pay_id not in (51,52,7)) then 'Late & Early Going' else case when (da.m_time>tt.in_time and da.m_time<>'TOUR' and da.m_time<>'COMPEN' and da.pay_id not in (50,52,7)) and da.e_time>=tt1.out_time then 'Late' else case when da.pay_id in (50) and da.E_TIME is null then  'REG-Morning & Non-Marking Evening'   else case when da.pay_id in (51) and da.M_TIME is null then 'REG-Morning & Non-Marking Morning'  else  case  when da.pay_id in (50) and da.e_time<>'TOUR' and da.e_time<>'COMPEN'  and da.E_TIME <tt1.out_time then 'REG-Morning & Early-Going'  else  case  when da.pay_id in (51) and da.m_time<>'TOUR' and da.m_time<>'COMPEN'  and da.M_TIME>tt.in_time then  'REG-Evening & Late' else case when da.pay_id in (52) then 'REG-Morning & Evening'   else '' end end end end end end end end end end end end end end end end as remarks from ATTENDANCE da,time_tab tt,time_tab tt1,employee_master em,branch_master bm,branch_master bm1,branch_master bm2 where  em.emp_code=da.emp_code and bm.branch_id=em.branch_id and to_date(da.curr_date)>='" & Request.QueryString.Get("fdate") & "' and to_date(da.curr_date)<='" & Request.QueryString.Get("tdate") & "' and em.branch_id=da.branch_id and da.m_shift=tt.shift_id  and da.e_shift=tt1.shift_id and bm1.branch_id=da.m_branch and bm2.branch_id=da.e_branch and da.branch_id=" & Request.QueryString.Get("brid") & " And da.e_time < tt1.out_time and da.e_time<>'ONDUTY'  and da.pay_id not in (51,52,7) and bm.firm_id = " & Session("firm_id") & "  order by bm.branch_id,day"
                cat = "EARLY GOING"

            Case 5
                sql = "select to_date(curr_date) as day,em.emp_code as emp_code,upper(substr(em.emp_name,0,19)) as Name,decode(da.m_time,NULL,'----------',da.m_time) as morning_time,decode(bm1.branch_name,'A.O.VALAPAD','',substr(bm1.branch_name,0,12)) as Morning_Branch,decode(e_time,NULL,'----------',e_time) as evening_time,decode(bm2.branch_name,'A.O.VALAPAD','',substr(bm2.branch_name,0,12)) as Evening_Branch,case when (da.m_time is null and da.pay_id not in (50,52)) and (da.pay_id not in (51,52) and da.e_time is null) then 'Absent' else case when da.pay_id in (50) and da.e_time is not null then 'Morning-REG' else case when da.pay_id in (51) and da.m_time is not null then 'Evening-REG' else case when da.pay_id in (52) then 'BOTH-REG'  else case when (da.m_time>tt.in_time and da.m_time<>'TOUR' and da.m_time<>'COMPEN' and da.pay_id not in (50,52,7)) and (da.e_time is null and da.pay_id not in (51,52,7)) then 'Late & Non-Marking' else case when da.m_time<=tt.in_time and (da.e_time is null and da.pay_id not in (51,52)) then 'Non-Marking Evening' else case when (da.m_time is null and da.pay_id not in (50,52,7)) and da.e_time <tt1.out_time then 'Non-Marking Morning & Early-Going' else case when (da.m_time is null and da.pay_id not in (50,52)) and da.e_time >=tt1.out_time then 'Non-Marking Morning' else case when da.m_time<=tt.in_time and (da.e_time<tt1.out_time and da.pay_id not in (51,52,7)) then 'Early-Going' else case when (da.m_time>tt.in_time and da.pay_id not in (50,52,7) ) and (da.e_time<tt1.out_time and da.pay_id not in (51,52,7)) then 'Late & Early Going' else case when (da.m_time>tt.in_time and da.m_time<>'TOUR' and da.m_time<>'COMPEN' and da.pay_id not in (50,52,7)) and da.e_time>=tt1.out_time then 'Late' else case when da.pay_id in (50) and da.E_TIME is null then  'REG-Morning & Non-Marking Evening'   else case when da.pay_id in (51) and da.M_TIME is null then 'REG-Morning & Non-Marking Morning'  else  case  when da.pay_id in (50) and da.e_time<>'TOUR' and da.e_time<>'COMPEN'  and da.E_TIME <tt1.out_time then 'REG-Morning & Early-Going'  else  case  when da.pay_id in (51) and da.m_time<>'TOUR' and da.m_time<>'COMPEN'  and da.M_TIME>tt.in_time then  'REG-Evening & Late' else case when da.pay_id in (52) then 'REG-Morning & Evening'   else '' end end end end end end end end end end end end end end end end as remarks from ATTENDANCE da,employee_master em,branch_master bm,branch_master bm1,branch_master bm2,time_tab tt,time_tab tt1  where  em.emp_code=da.emp_code and bm.branch_id=em.branch_id and to_date(da.curr_date)>='" & Request.QueryString.Get("fdate") & "' and to_date(da.curr_date)<='" & Request.QueryString.Get("tdate") & "' and em.branch_id=da.branch_id  and da.m_shift=tt.shift_id and da.e_shift=tt1.shift_id and bm1.branch_id=da.m_branch and bm2.branch_id=da.e_branch and da.branch_id=" & Request.QueryString.Get("brid") & " and (((da.m_time is  null and da.pay_id<>50 ) or (da.e_time is  null and da.pay_id<>51)) AND NOT(DA.M_TIME IS NULL AND DA.E_TIME IS NULL) and da.pay_id not in (52)) and bm.firm_id = " & Session("firm_id") & "  order by bm.branch_id,day"
                cat = "NON-MARKING"

        End Select

        dt = oh.ExecuteDataSet(sql).Tables(0)
        Dim tb As New Table
        ' tb.Attributes.Add("Border", "1")
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
        Dim td41 As New TableCell
        td41.Attributes.Add("width", "100%")
        td41.ColumnSpan = 80
        td41.HorizontalAlign = HorizontalAlign.Center
        td41.BackColor = Drawing.Color.Bisque
        td41.Text = "<font size=3><b>" & cat & " &nbsp Report From :&nbsp" & fdate & " &nbsp To :" & tdate & " </b></font>"
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
        td51.Attributes.Add("width", "8%")
        td51.ColumnSpan = 8
        td51.HorizontalAlign = HorizontalAlign.Left
        td51.Text = "<font size=2.5><b>DATE</b></font>"
        tr5.Controls.Add(td51)

        Dim td52 As New TableCell
        td52.Attributes.Add("width", "7%")
        td52.ColumnSpan = 7
        td52.HorizontalAlign = HorizontalAlign.Left
        td52.Text = "<font size=2.5><b>EMPLOYEE CODE</b></font>"
        tr5.Controls.Add(td52)

        Dim td53 As New TableCell
        td53.Attributes.Add("width", "15%")
        td53.ColumnSpan = 17
        td53.HorizontalAlign = HorizontalAlign.Left
        td53.Text = "<font size=2.5><b>EMPLOYEE NAME</b></font>"
        tr5.Controls.Add(td53)


        Dim td54 As New TableCell
        td54.Attributes.Add("width", "10%")
        td54.ColumnSpan = 5
        td54.HorizontalAlign = HorizontalAlign.Left
        td54.Text = "<font size=2.5><b>MORNING TIME</b></font>"
        tr5.Controls.Add(td54)

        Dim td55 As New TableCell
        td55.Attributes.Add("width", "15%")
        td55.ColumnSpan = 15
        td55.HorizontalAlign = HorizontalAlign.Left
        td55.Text = "<font size=2.5><b>MORNING BRANCH</b></font>"
        tr5.Controls.Add(td55)

        Dim td56 As New TableCell
        td56.Attributes.Add("width", "10%")
        td56.ColumnSpan = 5
        td56.HorizontalAlign = HorizontalAlign.Left
        td56.Text = "<font size=2.5><b>EVENING TIME</b></font>"
        tr5.Controls.Add(td56)

        Dim td57 As New TableCell
        td57.Attributes.Add("width", "15%")
        td57.ColumnSpan = 15
        td57.HorizontalAlign = HorizontalAlign.Left
        td57.Text = "<font size=2.5><b>EVENING BRANCH</b></font>"
        tr5.Controls.Add(td57)

        Dim td58 As New TableCell
        td58.Attributes.Add("width", "20%")
        td58.ColumnSpan = 8
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

        Dim color As Integer = 0
        For Each dr In dt.Rows
            Dim tr6 As New TableRow
            If (color = 0) Then
                tr6.BackColor = Drawing.Color.WhiteSmoke
                color = 1
            Else
                tr6.BackColor = Drawing.Color.Snow
                color = 0
            End If
            Dim td61 As New TableCell
            td61.Attributes.Add("width", "8%")
            td61.ColumnSpan = 8
            td61.HorizontalAlign = HorizontalAlign.Left
            td61.Text = "<font size=2>" & dr(0) & "</font>"
            tr6.Controls.Add(td61)

            Dim td62 As New TableCell
            td62.Attributes.Add("width", "7%")
            td62.ColumnSpan = 7
            td62.HorizontalAlign = HorizontalAlign.Left
            td62.Text = "<font size=2>" & dr(1) & "</font>"
            tr6.Controls.Add(td62)

            Dim td63 As New TableCell
            td63.Attributes.Add("width", "15%")
            td63.ColumnSpan = 17
            td63.HorizontalAlign = HorizontalAlign.Left
            td63.Text = "<font size=2>" & dr(2) & "</font>"
            tr6.Controls.Add(td63)


            Dim td64 As New TableCell
            td64.Attributes.Add("width", "10%")
            td64.ColumnSpan = 5
            td64.HorizontalAlign = HorizontalAlign.Left
            td64.Text = "<font size=2>" & dr(3) & "</font>"
            tr6.Controls.Add(td64)

            Dim td65 As New TableCell
            td65.Attributes.Add("width", "15%")
            td65.ColumnSpan = 15
            td65.HorizontalAlign = HorizontalAlign.Left
            td65.Text = "<font size=2>" & dr(4) & "</font>"
            tr6.Controls.Add(td65)

            Dim td66 As New TableCell
            td66.Attributes.Add("width", "10%")
            td66.ColumnSpan = 5
            td66.HorizontalAlign = HorizontalAlign.Left
            td66.Text = "<font size=2>" & dr(5) & "</font>"
            tr6.Controls.Add(td66)

            Dim td67 As New TableCell
            td67.Attributes.Add("width", "15%")
            td67.ColumnSpan = 15
            td67.HorizontalAlign = HorizontalAlign.Left
            td67.Text = "<font size=2>" & dr(6) & "</font>"
            tr6.Controls.Add(td67)

            Dim td68 As New TableCell
            td68.Attributes.Add("width", "20%")
            td68.ColumnSpan = 8
            td68.HorizontalAlign = HorizontalAlign.Center
            td68.Text = "<font size=2>" & dr(7) & "</font>"
            tr6.Controls.Add(td68)
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

        'Dim tr7 As New TableRow

        'Dim td71 As New TableCell
        'td71.Attributes.Add("width", "30%")
        'td71.ColumnSpan = 20
        'td71.HorizontalAlign = HorizontalAlign.Center
        'td71.Text = "<font size=2.5>TOTAL</font>"
        'tr7.Controls.Add(td71)
        'tb.Controls.Add(tr7)
        'Me.Panel_report.Controls.Add(tb)

        'Dim td72 As New TableCell
        'td72.Attributes.Add("width", "25%")
        'td72.ColumnSpan = 20
        'td72.HorizontalAlign = HorizontalAlign.Center
        'td72.Text = "<font size=2.5>" & totalp & "</font>"
        'tr7.Controls.Add(td72)
        'tb.Controls.Add(tr7)

        'Dim td73 As New TableCell
        'td73.Attributes.Add("width", "25%")
        'td73.ColumnSpan = 20
        'td73.HorizontalAlign = HorizontalAlign.Center
        'td73.Text = "<font size=2.5>" & totals & "</font>"
        'tr7.Controls.Add(td73)
        'tb.Controls.Add(tr7)

        'totalper = (totalp / totals) * 100

        'Dim td74 As New TableCell
        'td74.Attributes.Add("width", "25%")
        'td74.ColumnSpan = 20
        'td74.HorizontalAlign = HorizontalAlign.Center
        'td74.Text = "<font size=2.5>" & FormatNumber(totalper, 2) & "</font>"
        'tr7.Controls.Add(td74)
        'tb.Controls.Add(tr7)

        'Dim l4 As New TableRow
        'Dim ld4 As New TableCell
        'ld4.Attributes.Add("width", "100%")
        'ld4.ColumnSpan = 90
        'ld4.HorizontalAlign = HorizontalAlign.Center
        'ld4.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
        'l4.Controls.Add(ld4)
        'tb.Controls.Add(l4)

        Me.Panel_report.Controls.Add(tb)
    End Sub
End Class
