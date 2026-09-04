Imports System.Data
Imports System.Data.OracleClient
Partial Class accounts_Period_wide_rpt_details
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql, sql1, sql2, sql3 As String
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim dr As DataRow
    Dim tab As New Table
    Dim t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, total, Rowtotal As Integer
    Dim com_id, fdate, tdate As String
    Dim precrtot, precrval, predbtot, predbval, durcrtot, durcrval, durdbtot, durdbval, thirtytot, thirtyval, sixtot, sixval, ninetot, nineval, fintot, finval As Double
    Dim tdt, cmbid As String
    Dim fdt As String
    Dim kid, pid, sid, prid, firmid, brid As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '--------VAPT - Prevent Caching of Sensitive Content--------
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")
        
        '--------VAPT - Input Validation for Query Parameters--------
        ValidateQueryParameters()
        ValidateSessionData()
        
        Try
            '--------VAPT - Validate and Sanitize Query Parameters--------
            Dim date1 As String = ValidateAndSanitizeInput(Request.QueryString.Get("frDt"))
            Dim accno As String = ValidateAndSanitizeInput(Request.QueryString.Get("stid"))
            Dim date2 As String = ValidateAndSanitizeInput(Request.QueryString.Get("toDt"))
            
            If String.IsNullOrEmpty(date1) OrElse String.IsNullOrEmpty(accno) OrElse String.IsNullOrEmpty(date2) Then
                RedirectToLogin()
                Return
            End If

            total = 0

            precrtot = 0
            precrval = 0
            predbtot = 0
            predbval = 0

            durcrtot = 0
            durcrval = 0
            durdbtot = 0
            durdbval = 0

            thirtytot = 0
            thirtyval = 0
            sixtot = 0
            sixval = 0
            ninetot = 0
            nineval = 0
            fintot = 0
            finval = 0

            FillBasic()
            FillColumn()
            FillData1()
            filltotal()
            pn3.Controls.Add(tab)
        Catch ex As Exception
            RedirectToLogin()
        End Try
    End Sub
    Sub FillBasic()
        '--------VAPT - Validate and Sanitize Query Parameters--------
        Dim date1 As String = ValidateAndSanitizeInput(Request.QueryString.Get("frDt"))
        Dim accno As String = ValidateAndSanitizeInput(Request.QueryString.Get("stid"))
        Dim date2 As String = ValidateAndSanitizeInput(Request.QueryString.Get("toDt"))
        
        If String.IsNullOrEmpty(date1) OrElse String.IsNullOrEmpty(accno) OrElse String.IsNullOrEmpty(date2) Then
            Return
        End If

        'sql = "select state_name from state_master  where state_id= " & sateid & ""
        'dt = oh.ExecuteDataSet(sql).Tables(0)

        tab.Attributes.Add("width", "80%")
        tab.Attributes.Add("align", "left")
        tab.Attributes.Add("border", "1")
        Dim row1 As New TableRow
        Dim c11 As New TableCell
        c11.ColumnSpan = 24
        '--------VAPT - Sanitize Session Data--------
        Dim firmName As String = If(Session("firm_name") IsNot Nothing, HttpUtility.HtmlEncode(Session("firm_name").ToString()), "")
        c11.Text = "<font size=4><b> " & firmName & " </font></b>"
        c11.HorizontalAlign = HorizontalAlign.Center
        c11.VerticalAlign = VerticalAlign.Middle
        c11.BackColor = Drawing.Color.Gold
        c11.ForeColor = Drawing.Color.Red
        c11.BorderColor = Drawing.Color.Red
        row1.Controls.Add(c11)
        tab.Controls.Add(row1)
        Dim row2 As New TableRow
        Dim c21 As New TableCell
        Dim c22 As New TableCell
        c21.ColumnSpan = 12
        c22.ColumnSpan = 12
        c21.Attributes.Add("width", "50%")
        c22.Attributes.Add("width", "50%")
        '--------VAPT - Sanitize Session Data--------
        Dim branchName As String = If(Session("branch_name") IsNot Nothing, HttpUtility.HtmlEncode(Session("branch_name").ToString()), "")
        Dim branchId As String = If(Session("branch_id") IsNot Nothing, HttpUtility.HtmlEncode(Session("branch_id").ToString()), "")
        c21.Text = "<font size=2><b> Branch_name:" & branchName & ", </font></b>"
        c21.HorizontalAlign = HorizontalAlign.Right
        c22.Text = "<font size=2><b> Branch_id:" & branchId & " </font></b>"
        c22.HorizontalAlign = HorizontalAlign.Left
        row2.Controls.Add(c21)
        row2.Controls.Add(c22)
        Dim row4 As New TableRow
        'Dim c41 As New TableCell
        Dim c42 As New TableCell
        'Dim c43 As New TableCell
        c42.ColumnSpan = 24

        'c42.Text = "<FONT SIZE =2>" & dr(13) & "</font>"

        'If sateid = -1 Then
        '    c42.Text = "Consolidated Trail Balance as on " + date2 + "- ALL STATES"
        'Else
        '    c42.Text = "Consolidated Trail Balance as on " + date2 + "-" + dt.Rows(0)(0)
        'End If


        c42.BackColor = Drawing.Color.LightPink
        c42.HorizontalAlign = HorizontalAlign.Center
        row4.Controls.Add(c42)
        tab.Controls.Add(row4)

    End Sub
    Sub FillColumn()
        '--------VAPT - Validate and Sanitize Query Parameters--------
        Dim date1 As String = ValidateAndSanitizeInput(Request.QueryString.Get("frDt"))
        Dim date2 As String = ValidateAndSanitizeInput(Request.QueryString.Get("toDt"))
        
        If String.IsNullOrEmpty(date1) OrElse String.IsNullOrEmpty(date2) Then
            Return
        End If

        sql = "select to_date('" & date1 & "')-1  from dual"
        'sql = "select to_date(Format('" & date1 & "','dd-MMM-yyyy'))-1  from dual"
        dt = oh.ExecuteDataSet(sql).Tables(0)

        Dim date3 As String = Format(dt.Rows(0)(0), "dd-MMM-yyyy")

        sql1 = "select to_date('" & date1 & "')  from dual"
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)

        sql2 = "select to_date('" & date2 & "')  from dual"
        dt2 = oh.ExecuteDataSet(sql2).Tables(0)

        'Dim row8 As New TableRow
        'Dim c81 As New TableCell
        ' c81.ColumnSpan = 15
        Dim dtet As New DateTime
        Dim tabt1 As New Table
        tabt1.Attributes.Add("width", "90%")
        tabt1.Attributes.Add("align", "left")
        'tabt1.Attributes.Add("border", "1")

        Dim trt2 As New TableRow
        Dim tct2 As New TableCell
        tct2.ColumnSpan = 2
        tct2.Attributes.Add("width", "25%")
        tct2.Text = "<b><font size=2 >" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        tct2.HorizontalAlign = HorizontalAlign.Left
        trt2.Controls.Add(tct2)

        Dim tct4 As New TableCell
        tct4.ColumnSpan = 2
        tct4.Attributes.Add("width", "25%")
        tct4.Text = "<b><font size=2 >" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        tct4.HorizontalAlign = HorizontalAlign.Right
        trt2.Controls.Add(tct4)
        tabt1.Controls.Add(trt2)

        Dim row6 As New TableRow
        row6.BackColor = Drawing.Color.LightBlue
        row6.Attributes.Add("width", "100%")
        Dim c61, c62, c63, c64, c65, C66, C67, C68, C69, c70, c71, c72, c73, c74, c75, c76, c77, c78 As New TableCell
        c61.ColumnSpan = 1
        c62.ColumnSpan = 1
        c63.ColumnSpan = 1
        c64.ColumnSpan = 1
        c65.ColumnSpan = 1
        C66.ColumnSpan = 1
        C67.ColumnSpan = 1
        C68.ColumnSpan = 1

        'C69.ColumnSpan = 1
        'c70.ColumnSpan = 1
        'c71.ColumnSpan = 1
        'c72.ColumnSpan = 1
        'c73.ColumnSpan = 1
        'c74.ColumnSpan = 1
        'c75.ColumnSpan = 1

        'c42.Text = "Consolidated Trail Balance as on " + date1 + "-" + dt.Rows(0)(0)

        c61.Text = "<font size=2><b>Acc.No</font>"
        c62.Text = "<font size=2><b>Account&nbspName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
        c63.Text = "<font size=2><b>Opening&nbsp;Amout--&nbsp;&nbsp;(</font>" + date3 + ")"
        'c64.Text = "<font size=2><b>Opening&nbsp;Credit--&nbsp;&nbsp;(</font>" + date3 + ")"
        c64.Text = "<font size=2><b>During&nbsp;Debit--&nbsp;&nbsp;(</font>" + date1 + "-" + date2 + ")"
        c65.Text = "<font size=2><b>During&nbsp;Credit--&nbsp;&nbsp;(</font>" + date1 + "-" + date2 + ")"
        C66.Text = "<font size=2><b>Closing&nbsp;Amout--&nbsp;&nbsp;(</font>" + date2 + ")"
        'C68.Text = "<font size=2><b>Closing&nbsp;Credit--&nbsp;&nbsp;(</font>" + date2 + ")"
        C67.Text = "<font size=2><b><30&nbsp;&nbsp;days&nbsp;&nbsp;</font>"
        C68.Text = "<font size=2><b>30-60&nbsp;&nbsp;days&nbsp;&nbsp;</font>"
        C69.Text = "<font size=2><b>60-90&nbsp;&nbsp;days&nbsp;&nbsp;</font>"
        c70.Text = "<font size=2><b>>90&nbsp;&nbsp;days&nbsp;&nbsp;</font>"

        c71.Text = "<font size=2><b><30&nbsp;&nbsp;Invoice&nbsp;No&nbsp;</font>"
        c72.Text = "<font size=2><b><30&nbsp;&nbsp;Invoice&nbsp;DT&nbsp;&nbsp;</font>"
        c73.Text = "<font size=2><b>30-60&nbsp;&nbsp;Invoice&nbsp;No&nbsp;</font>"
        c74.Text = "<font size=2><b>30-60&nbsp;&nbsp;Invoice&nbsp;DT&nbsp;</font>"
        c75.Text = "<font size=2><b>60-90&nbsp;&nbsp;Invoice&nbsp;No&nbsp;</font>"
        c76.Text = "<font size=2><b>60-90&nbsp;&nbsp;Invoice&nbsp;DT&nbsp;</font>"
        c77.Text = "<font size=2><b>>90&nbsp;&nbsp;Invoice&nbsp;No&nbsp;</font>"
        c78.Text = "<font size=2><b>>90&nbsp;&nbsp;Invoice&nbsp;DT&nbsp;</font>"

        'c74.Text = "<font size=2><b>Approve&nbsp;Date</font>"
        'c75.Text = "<font size=2><b>Status&nbsp</font>"
        'c84.Text = "<font size=2><b>Total&nbsp;Days</font>"
        'C74.BackColor = Drawing.Color.Yellow
        c61.HorizontalAlign = HorizontalAlign.Center
        c62.HorizontalAlign = HorizontalAlign.Center
        c63.HorizontalAlign = HorizontalAlign.Center
        c64.HorizontalAlign = HorizontalAlign.Center
        c65.HorizontalAlign = HorizontalAlign.Center
        C66.HorizontalAlign = HorizontalAlign.Center

        C67.HorizontalAlign = HorizontalAlign.Center

        C68.HorizontalAlign = HorizontalAlign.Center
        C69.HorizontalAlign = HorizontalAlign.Center
        c70.HorizontalAlign = HorizontalAlign.Center
        c71.HorizontalAlign = HorizontalAlign.Center
        c72.HorizontalAlign = HorizontalAlign.Center
        c73.HorizontalAlign = HorizontalAlign.Center
        c74.HorizontalAlign = HorizontalAlign.Center
        c75.HorizontalAlign = HorizontalAlign.Center
        c76.HorizontalAlign = HorizontalAlign.Center
        c77.HorizontalAlign = HorizontalAlign.Center
        c78.HorizontalAlign = HorizontalAlign.Center

        row6.Controls.Add(c61)
        row6.Controls.Add(c62)
        row6.Controls.Add(c63)
        row6.Controls.Add(c64)
        row6.Controls.Add(c65)
        row6.Controls.Add(C66)
        row6.Controls.Add(C67)
        row6.Controls.Add(C68)
        row6.Controls.Add(C69)
        row6.Controls.Add(c70)
        row6.Controls.Add(c71)
        row6.Controls.Add(c72)
        row6.Controls.Add(c73)
        row6.Controls.Add(c74)
        row6.Controls.Add(c75)
        row6.Controls.Add(c76)
        row6.Controls.Add(c77)
        row6.Controls.Add(c78)

        '  row6.Controls.Add(c84)

        tab.Controls.Add(row6)
    End Sub
    Sub FillData1()
        '--------VAPT - Validate and Sanitize Query Parameters--------
        Dim date1 As String = ValidateAndSanitizeInput(Request.QueryString.Get("frDt"))
        Dim accno As String = ValidateAndSanitizeInput(Request.QueryString.Get("stid"))
        Dim date2 As String = ValidateAndSanitizeInput(Request.QueryString.Get("toDt"))
        
        If String.IsNullOrEmpty(date1) OrElse String.IsNullOrEmpty(accno) OrElse String.IsNullOrEmpty(date2) Then
            Return
        End If
        'sql = "select a.account_no,  case when  sum(case when  a.tra_dt <=add_months(to_date(last_day('" & date1 & "')),-1)  then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) >0  then  sum(case when  a.tra_dt <=add_months(to_date(last_day('" & date1 & "')),-1)  then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) end opening_amt_debit,case when  sum(case when  a.tra_dt <=add_months(to_date(last_day('" & date1 & "')),-1)  then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <0  then  sum(case when  a.tra_dt <=add_months(to_date(last_day('" & date1 & "')),-1)  then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) end opening_amt_credit,case when     sum(case when  a.tra_dt >add_months(to_date(last_day('" & date1 & "')),-1) and a.tra_dt <=to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)>0 then  sum(case when  a.tra_dt >add_months(to_date(last_day('" & date1 & "')),-1) and a.tra_dt <=to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) end  during_amt_debit,case when     sum(case when  a.tra_dt >add_months(to_date(last_day('" & date1 & "')),-1) and a.tra_dt <=to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)<0 then  sum(case when  a.tra_dt >add_months(to_date(last_day('" & date1 & "')),-1) and a.tra_dt <=to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) end  during_amt_credit,  case when   sum(case when  a.tra_dt <=to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0 then sum(case when  a.tra_dt <=to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  end closing_amt_debit,  case when   sum(case when  a.tra_dt <=to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) <0 then sum(case when  a.tra_dt <=to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) end  closing_amt_credit,  b.account_name  from masset.full_transaction_all a,  masset.account_profile b,  masset.branch_master   c,  masset.state_master    d  where a.tra_dt <= to_date('" & date1 & "')  and a.firm_id = " & Session("firm_id") & "  and c.branch_id = a.branch_id  and d.state_id = c.state_id  and c.state_id = '" & sateid & "'  and a.account_no = b.account_no  and b.ho_status <> 1  group by a.account_no, b.account_name  having  (sum(case when  a.tra_dt <=add_months(to_date(last_day('" & date1 & "')),-1)  then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <>0 or  sum(case when  a.tra_dt >add_months(to_date(last_day('" & date1 & "')),-1) and a.tra_dt <=to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  <>0 or  sum(case when  a.tra_dt <=to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  <>0)  order by a.account_no"
        'sql = "select a.account_no,case when  sum(case when  a.tra_dt < to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) >0  then  sum(case when  a.tra_dt < to_date('" & date1 & "') then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) end opening_amt_debit,case when  sum(case when  a.tra_dt < to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <0  then  sum(case when  a.tra_dt < to_date('" & date1 & "')  then decode(a.type, 'C', a.amount, a.amount * -1)else 0 end ) end opening_amt_credit,case when     sum(case when   a.tra_dt =to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)>0 then  sum(case when   a.tra_dt =to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) end  during_amt_debit,case when     sum(case when  a.tra_dt =to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)<0 then  sum(case when   a.tra_dt =to_date('" & date1 & "')   then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  during_amt_credit,  case when   sum(case when  a.tra_dt <=to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0 then sum(case when  a.tra_dt <=to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  end closing_amt_debit,  case when   sum(case when  a.tra_dt <=to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) <0 then sum(case when  a.tra_dt <=to_date('" & date1 & "')  then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  closing_amt_credit,  b.account_name  from full_transaction_all a,  account_profile b,  branch_master   c,  state_master    d where a.tra_dt <= '" & date1 & "'  and a.firm_id = " & Session("firm_id") & "  and c.branch_id = a.branch_id  and d.state_id = c.state_id  and c.state_id = '" & sateid & "'  and a.account_no = b.account_no  and b.ho_status <> 1  group by a.account_no, b.account_name  having  (sum(case when a.tra_dt < to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <>0 or  sum(case when  a.tra_dt =to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  <>0 or  sum(case when  a.tra_dt <=to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  <>0)  order by a.account_no"
        'If sateid = -1 Then
        '    sql = "select a.account_no,case when  sum(case when  a.tra_dt < to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) >0  then  sum(case when  a.tra_dt < to_date('" & date1 & "') then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) end opening_amt_debit,case when  sum(case when  a.tra_dt < to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <0  then  sum(case when  a.tra_dt < to_date('" & date1 & "')   then decode(a.type, 'C', a.amount, a.amount * -1)else 0 end ) end opening_amt_credit,  case when     sum(case when  a.tra_dt >= to_date('" & date1 & "') and  a.tra_dt <= to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)>0 then  sum(case when   a.tra_dt >= to_date('" & date1 & "') and  a.tra_dt <= to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) end  during_amt_debit,case when     sum(case when  a.tra_dt >= to_date('" & date1 & "') and  a.tra_dt <= to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)<0 then  sum(case when   a.tra_dt >= to_date('" & date1 & "') and  a.tra_dt <= to_date('" & date2 & "')   then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  during_amt_credit,  case when   sum(case when  a.tra_dt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0 then sum(case when  a.tra_dt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  end closing_amt_debit,case when   sum(case when  a.tra_dt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) <0 then sum(case when  a.tra_dt <=to_date('" & date2 & "')  then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  closing_amt_credit,  b.account_name  from full_transaction_all a,  account_profile b,  branch_master   c,  state_master    d  where a.tra_dt <= '" & date2 & "'  and a.firm_id = " & Session("firm_id") & "  and c.branch_id = a.branch_id  and d.state_id = c.state_id  and  c.state_id in(18,19,20,27,31,32,42) and a.account_no = b.account_no  and b.ho_status <> 1  group by a.account_no, b.account_name  having  (sum(case when a.tra_dt < to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <>0 or  sum(case when  a.tra_dt >= to_date('" & date1 & "') and  a.tra_dt < to_date('" & date2 & "') then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  <>0 or  sum(case when  a.tra_dt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  <>0)  order by a.account_no"
        'Else
        '    sql = "select a.account_no,case when  sum(case when  a.tra_dt < to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) >0  then  sum(case when  a.tra_dt < to_date('" & date1 & "') then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) end opening_amt_debit,case when  sum(case when  a.tra_dt < to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <0  then  sum(case when  a.tra_dt < to_date('" & date1 & "')   then decode(a.type, 'C', a.amount, a.amount * -1)else 0 end ) end opening_amt_credit,  case when     sum(case when  a.tra_dt >= to_date('" & date1 & "') and  a.tra_dt <= to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)>0 then  sum(case when   a.tra_dt >= to_date('" & date1 & "') and  a.tra_dt <= to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) end  during_amt_debit,case when     sum(case when  a.tra_dt >= to_date('" & date1 & "') and  a.tra_dt <= to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)<0 then  sum(case when   a.tra_dt >= to_date('" & date1 & "') and  a.tra_dt <= to_date('" & date2 & "')   then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  during_amt_credit,  case when   sum(case when  a.tra_dt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0 then sum(case when  a.tra_dt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  end closing_amt_debit,case when   sum(case when  a.tra_dt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) <0 then sum(case when  a.tra_dt <=to_date('" & date2 & "')  then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  closing_amt_credit,  b.account_name  from full_transaction_all a,  account_profile b,  branch_master   c,  state_master    d  where a.tra_dt <= '" & date2 & "'  and a.firm_id = " & Session("firm_id") & "  and c.branch_id = a.branch_id  and d.state_id = c.state_id  and c.state_id = '" & sateid & "' and a.account_no = b.account_no  and b.ho_status <> 1  group by a.account_no, b.account_name  having  (sum(case when a.tra_dt < to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <>0 or  sum(case when  a.tra_dt >= to_date('" & date1 & "') and  a.tra_dt < to_date('" & date2 & "') then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  <>0 or  sum(case when  a.tra_dt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  <>0)  order by a.account_no"
        'End If
        'sql = "select a.parent_acc,a.account_no,case when  sum(case when  a.tradt < to_date('1-jan-2022')  then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) >0  then  sum(case when  a.tradt < to_date('1-jan-2022') then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) end opening_amt_debit,case when  sum(case when  a.tradt < to_date('1-jan-2022')   then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <0  then  sum(case when  a.tradt < to_date('1-jan-2022')   then decode(a.type, 'C', a.amount, a.amount * -1)else 0 end ) end opening_amt_credit,  case when     sum(case when  a.tradt >= to_date('1-jan-2022') and  a.tradt <= to_date('27-feb-2022')      then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)>0 then  sum(case when   a.tradt >= to_date('1-jan-2022') and  a.tradt <= to_date('27-feb-2022')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) end  during_amt_debit,case when     sum(case when  a.tradt >= to_date('1-jan-2022') and  a.tradt <= to_date('27-feb-2022')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)<0 then  sum(case when   a.tradt >= to_date('1-jan-2022') and  a.tradt <= to_date('27-feb-2022')   then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  during_amt_credit,  case when   sum(case when  a.tradt <=to_date('27-feb-2022')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0   then sum(case when  a.tradt <=to_date('27-feb-2022')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  end closing_amt_debit,case when   sum(case when  a.tradt <=to_date('27-feb-2022')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) <0 then sum(case when  a.tradt <=to_date('27-feb-2022')  then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  closing_amt_credit,  b.account_name, sum(case when floor(floor (sysdate - a.tradt) / 15) < 1 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) less_30days,  sum(case when floor(floor (sysdate - a.tradt) / 15) between 2 and 3 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) btw30_60,  sum(case when floor(floor (sysdate - a.tradt) / 15) between 4 and 5 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) btw60_90,  sum(case when floor(floor (sysdate - a.tradt) / 15) > 6 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) grt_90  from sub_all a,  account_profile b,  branch_master   c  where a.tradt <= '27-feb-2022'  and a.firm_id = 9  and c.branch_id = a.branch_id  and a.parent_acc = 41109  and a.account_no = b.account_no  and b.ho_status <> 1  group by a.parent_acc,a.account_no, b.account_name  having    (sum(case when a.tradt < to_date('1-jan-2022')   then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <>0 or    sum(case when  a.tradt >= to_date('1-jan-2022') and  a.tradt < to_date('27-feb-2022') then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)  <>0 or  sum(case when  a.tradt <=to_date('27-feb-2022')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  <>0) order by a.parent_acc,a.account_no"
        'sql = "select a.parent_acc,a.account_no,case when  sum(case when  a.tradt < to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) >0  then  sum(case when  a.tradt < to_date('" & date1 & "') then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) end opening_amt_debit,case when  sum(case when  a.tradt < to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <0  then  sum(case when  a.tradt < to_date('" & date1 & "')   then decode(a.type, 'C', a.amount, a.amount * -1)else 0 end ) end opening_amt_credit,  case when     sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')      then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)>0 then  sum(case when   a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) end  during_amt_debit,case when     sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)<0 then  sum(case when   a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')   then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  during_amt_credit,  case when   sum(case when  a.tradt <=to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0   then sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  end closing_amt_debit,case when   sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) <0 then sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  closing_amt_credit,  b.account_name, sum(case when floor(floor (sysdate - a.tradt) / 15) < 1 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) less_30days,  sum(case when floor(floor (sysdate - a.tradt) / 15) between 2 and 3 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) btw30_60,  sum(case when floor(floor (sysdate - a.tradt) / 15) between 4 and 5 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) btw60_90,  sum(case when floor(floor (sysdate - a.tradt) / 15) > 6 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) grt_90,s.account_name  from sub_all a,  account_profile b, account_profile s, branch_master   c  where a.tradt <= '" & date2 & "'  and a.firm_id = 9  and c.branch_id = a.branch_id  and a.parent_acc = ('" & accno & "') and a.account_no = b.account_no  and s.account_no=a.parent_acc  and b.ho_status <> 1  group by a.parent_acc,a.account_no, b.account_name,s.account_name  having    (sum(case when a.tradt < to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <>0 or    sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt < to_date('" & date2 & "') then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)  <>0 or  sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  <>0) order by a.parent_acc,a.account_no"
        'sql = "select a.parent_acc,a.account_no,case when  sum(case when  a.tradt < to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) >0  then  sum(case when  a.tradt < to_date('" & date1 & "') then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) end opening_amt_debit,case when  sum(case when  a.tradt < to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <0  then  sum(case when  a.tradt < to_date('" & date1 & "')   then decode(a.type, 'C', a.amount, a.amount * -1)else 0 end ) end opening_amt_credit,  case when     sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')      then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)>0 then  sum(case when   a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) end  during_amt_debit,case when     sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)<0 then  sum(case when   a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')   then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  during_amt_credit,  case when   sum(case when  a.tradt <=to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0   then sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  end closing_amt_debit,case when   sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) <0 then sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  closing_amt_credit,  a.account_name, sum(case when floor(floor (sysdate - a.tradt) / 15) < 1 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) less_30days,  sum(case when floor(floor (sysdate - a.tradt) / 15) between 2 and 3 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) btw30_60,  sum(case when floor(floor (sysdate - a.tradt) / 15) between 4 and 5 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) btw60_90,  sum(case when floor(floor (sysdate - a.tradt) / 15) > 6 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) grt_90,s.account_name  from sub_all a,  account_profile b, account_profile s, branch_master   c  where a.tradt <= '" & date2 & "'  and a.firm_id = 9  and c.branch_id = a.branch_id  and a.parent_acc = ('" & accno & "') and a.account_no = b.account_no  and s.account_no=a.parent_acc  and b.ho_status <> 1  group by a.parent_acc,a.account_no, a.account_name,s.account_name  having    (sum(case when a.tradt < to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <>0 or    sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt < to_date('" & date2 & "') then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)  <>0 or  sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  <>0) order by a.parent_acc,a.account_no"
        'sql = "select a.parent_acc,a.account_no,case when  sum(case when  a.tradt < to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) >0  then  sum(case when  a.tradt < to_date('" & date1 & "') then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) end opening_amt_debit,case when  sum(case when  a.tradt < to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <0  then  sum(case when  a.tradt < to_date('" & date1 & "')   then decode(a.type, 'C', a.amount, a.amount * -1)else 0 end ) end opening_amt_credit,  case when     sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')      then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)>0 then  sum(case when   a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) end  during_amt_debit,case when     sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)<0 then  sum(case when   a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')   then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  during_amt_credit,  case when   sum(case when  a.tradt <=to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0   then sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  end closing_amt_debit,case when   sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) <0 then sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  closing_amt_credit,  a.account_name, sum(case when floor(floor (sysdate - a.tradt) / 15) < 1 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) less_30days,  sum(case when floor(floor (sysdate - a.tradt) / 15) between 2 and 3 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) btw30_60,  sum(case when floor(floor (sysdate - a.tradt) / 15) between 4 and 5 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) btw60_90,  sum(case when floor(floor (sysdate - a.tradt) / 15) > 6 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) grt_90,s.account_name  from sub_all a,  account_profile b, account_profile s, branch_master   c  where a.tradt <= '" & date2 & "'  and a.firm_id = 9  and c.branch_id = a.branch_id  and a.parent_acc = ('" & accno & "') and a.account_no = b.account_no  and s.account_no=a.parent_acc  and b.ho_status <> 1  group by a.parent_acc,a.account_no, a.account_name,s.account_name  having    (sum(case when a.tradt < to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <>0 or    sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt < to_date('" & date2 & "') then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)  <>0 or  sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  <>0) order by a.parent_acc,a.account_no"
        'sql = "select a.parent_acc,a.account_no,case when  sum(case when  a.tradt < to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) >0  then  sum(case when  a.tradt < to_date('" & date1 & "') then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) end opening_amt_debit,case when  sum(case when  a.tradt < to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <0  then  sum(case when  a.tradt < to_date('" & date1 & "')   then decode(a.type, 'C', a.amount, a.amount * -1)else 0 end ) end opening_amt_credit,  case when     sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')      then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)>0 then  sum(case when   a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) end  during_amt_debit,case when     sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)<0 then  sum(case when   a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')   then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  during_amt_credit,  case when   sum(case when  a.tradt <=to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0   then sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  end closing_amt_debit,case when   sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) <0 then sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  closing_amt_credit,  a.account_name, sum(case when floor(floor (sysdate - a.tradt) / 15) < 1 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) less_30days,  sum(case when floor(floor (sysdate - a.tradt) / 15) between 2 and 3 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) btw30_60,  sum(case when floor(floor (sysdate - a.tradt) / 15) between 4 and 5 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) btw60_90,  sum(case when floor(floor (sysdate - a.tradt) / 15) > 6 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end) grt_90,s.account_name  from sub_all a,  account_profile s, branch_master   c  where a.tradt <= '" & date2 & "'  and a.firm_id = 9  and c.branch_id = a.branch_id  and a.parent_acc = ('" & accno & "')   and s.account_no=a.parent_acc  and s.ho_status <> 1  group by a.parent_acc,a.account_no, a.account_name,s.account_name  having    (sum(case when a.tradt < to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <>0 or    sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt < to_date('" & date2 & "') then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)  <>0 or  sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  <>0) order by a.parent_acc,a.account_no"
        'sql = "select a.parent_acc,a.account_no,case when  sum(case when  a.tradt < to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) >0  then  sum(case when  a.tradt < to_date('" & date1 & "') then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) end opening_amt_debit,case when  sum(case when  a.tradt < to_date('" & date1 & "')     then decode(a.type, 'D',a.amount, a.amount * -1)else 0 end ) <0  then  sum(case when  a.tradt < to_date('" & date1 & "')   then decode(a.type, 'C',   a.amount, a.amount * -1)else 0 end ) end opening_amt_credit,  case when     sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')        then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)>0 then  sum(case when   a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')      then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) end  during_amt_debit,case when     sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')    then decode(a.type, 'D',   a.amount, a.amount * -1) else 0 end)<0 then  sum(case when   a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')   then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  during_amt_credit,case when   sum(case when  a.tradt <=to_date('" & date2 & "')    then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0   then sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)  end closing_amt_debit,case when   sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) <0 then sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'C',   a.amount, a.amount * -1) else 0 end) end  closing_amt_credit,  a.account_name, abs(sum(case when floor(floor (sysdate - a.tradt) ) < 30 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end)) less_30days,  abs(sum(case when floor(floor (sysdate - a.tradt) ) >= 30 and floor(floor (sysdate - a.tradt) ) < 60 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end)) btw30_60,  abs(sum(case when floor(floor (sysdate - a.tradt) )>= 60 and  floor(floor (sysdate - a.tradt) )< 90 then decode(a.type, 'C',a.amount ,-1 * a.amount ) else null end)) btw60_90,  abs(sum(case when floor(floor (sysdate - a.tradt) ) >= 90   then abs(decode(a.type, 'C',a.amount ,-1 * a.amount )) else null end)) grt_90,s.account_name  from sub_all a, account_profile s, branch_master   c  where a.tradt <= '" & date2 & "'  and a.firm_id = 9  and c.branch_id = a.branch_id  and a.parent_acc = ('" & accno & "')   and s.account_no=a.parent_acc  and s.ho_status <> 1    group by a.parent_acc,a.account_no, a.account_name,s.account_name  having    (sum(case when a.tradt < to_date('" & date1 & "')   then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <>0 or      sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt < to_date('" & date2 & "') then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)  <>0 or    sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  <>0) order by a.parent_acc,a.account_no"
        'sql = "select a.parent_acc,a.account_no,  abs(sum(case when  a.tradt < to_date('" & date1 & "') then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ))|| case when  sum(case when  a.tradt < to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) >0  then'Dr' else 'Cr' end opening_amt_debit,  case when     sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date(" & date2 & ")          then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)>0 then  sum(case when   a.tradt >= to_date('" & date1 & "')   and  a.tradt <= to_date(" & date2 & ")      then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) end  during_amt_debit,  case when     sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date(" & date2 & ")    then decode(a.type, 'D',     a.amount, a.amount * -1) else 0 end)<0 then  sum(case when   a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date(" & date2 & ")  then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  during_amt_credit,abs(sum(case when  a.tradt <=to_date(" & date2 & ")  then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)) ||case when   sum(case when  a.tradt <=to_date(" & date2 & ")      then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0   then 'Dr' else 'Cr' end   closing_amt_debit,  a.account_name,   (case when floor(floor (sysdate - max(a.tradt)) ) < 30 then abs(sum(case when  a.tradt <=to_date(" & date2 & ")  then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)) ||case when   sum(case when  a.tradt <=to_date(" & date2 & ")      then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0   then 'Dr' else 'Cr' end  else null end )less_30days ,  (case when floor(floor (sysdate - max(a.tradt)) ) >= 30 and floor(floor (sysdate - max(a.tradt)) ) < 60  then abs(sum(case when  a.tradt <=to_date(" & date2 & ")  then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)) ||case when   sum(case when  a.tradt <=to_date(" & date2 & ")      then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0   then 'Dr' else 'Cr' end  else null end )btw30_60 ,  (case when floor(floor (sysdate - max(a.tradt)) ) >= 60 and floor(floor (sysdate - max(a.tradt)) ) < 90  then abs(sum(case when  a.tradt <=to_date(" & date2 & ")  then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)) ||case when   sum(case when  a.tradt <=to_date(" & date2 & ") then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0   then 'Dr' else 'Cr' end  else null end )btw60_90 ,  (case when floor(floor (sysdate - max(a.tradt)) ) >= 90   then abs(sum(case when  a.tradt <=to_date(" & date2 & ")  then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)) ||case when   sum(case when  a.tradt <=to_date(" & date2 & ")      then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0   then 'Dr' else 'Cr' end  else null end )GRT_90 ,  s.account_name  from sub_all a, account_profile s, branch_master   c    where a.tradt <= " & date2 & "  and a.firm_id = 9  and c.branch_id = a.branch_id  and a.parent_acc = ('" & accno & "')   and s.account_no=a.parent_acc  and s.ho_status <> 1    group by a.parent_acc,a.account_no, a.account_name,s.account_name  having    (sum(case when a.tradt < to_date('" & date1 & "')     then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <>0 or      sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt < to_date(" & date2 & ") then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)  <>0 or    sum(case when  a.tradt <=to_date(" & date2 & ")  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  <>0)   order by a.parent_acc,a.account_no"

        'sql = "select a.parent_acc,a.account_no,  abs(sum(case when  a.tradt < to_date('" & date1 & "') then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ))|| case when  sum(case when  a.tradt < to_date('" & date1 & "')  then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) >0  then'Dr' else 'Cr' end opening_amt_debit,  case when     sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')          then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)>0 then  sum(case when   a.tradt >= to_date('" & date1 & "')   and  a.tradt <= to_date('" & date2 & "')      then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) end  during_amt_debit,  case when     sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')    then decode(a.type, 'D',     a.amount, a.amount * -1) else 0 end)<0 then  sum(case when   a.tradt >= to_date('" & date1 & "') and  a.tradt <= to_date('" & date2 & "')     then decode(a.type, 'C', a.amount, a.amount * -1) else 0 end) end  during_amt_credit,  abs(sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)) ||case when   sum(case when  a.tradt <=to_date('" & date2 & "')      then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0   then 'Dr' else 'Cr' end   closing_amt_debit,  a.account_name,   (case when floor(floor (sysdate - max(a.tradt)) ) < 30 then abs(sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)) ||case when   sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0   then 'Dr' else 'Cr' end  else null end )less_30days ,(case when floor(floor (sysdate - max(a.tradt)) ) >= 30 and floor(floor (sysdate - max(a.tradt)) ) < 60  then abs(sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)) ||case when   sum(case when  a.tradt <=to_date('" & date2 & "')      then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0   then 'Dr' else 'Cr' end  else null end )btw30_60 ,  (case when floor(floor (sysdate - max(a.tradt)) ) >= 60 and floor(floor (sysdate - max(a.tradt)) ) < 90  then abs(sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)) ||case when   sum(case when  a.tradt <=to_date('" & date2 & "')      then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0   then 'Dr' else 'Cr' end  else null end )btw60_90 ,  (case when floor(floor (sysdate - max(a.tradt)) ) >= 90   then abs(sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)) ||case when   sum(case when  a.tradt <=to_date('" & date2 & "')      then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end) >0   then 'Dr' else 'Cr' end  else null end )GRT_90 ,  s.account_name  from  sub_all a, account_profile s, branch_master   c    where a.tradt <= '" & date2 & "'  and a.firm_id = 9  and c.branch_id = a.branch_id  and a.parent_acc = ('" & accno & "')   and s.account_no=a.parent_acc  and s.ho_status <> 1    group by a.parent_acc,a.account_no, a.account_name,s.account_name  having    (sum(case when a.tradt < to_date('" & date1 & "')     then decode(a.type, 'D', a.amount, a.amount * -1)else 0 end ) <>0 or      sum(case when  a.tradt >= to_date('" & date1 & "') and  a.tradt < to_date('" & date2 & "') then decode(a.type, 'D', a.amount, a.amount * -1)   else 0 end)  <>0 or    sum(case when  a.tradt <=to_date('" & date2 & "')  then decode(a.type, 'D', a.amount, a.amount * -1) else 0 end)  <>0)   order by a.parent_acc,a.account_no"
        'sql = "select PARENT_ACC,       ACCOUNT_NO,       OPENING_AMT_DEBIT,       DURING_AMT_DEBIT,       DURING_AMT_CREDIT,       CLOSING_AMT_DEBIT,       ACCOUNT_NAME,       LESS_30DAYS,       BTW30_60,       BTW60_90,       GRT_90,       main_ACCOUNT_NAME  from table(sub_during_balance(" & Session("firm_id") & ", '" & accno & "', '" & date1 & "', '" & date2 & "'))"
        '--------VAPT - Validate Session Data Before Use--------
        If Session("firm_id") Is Nothing Then
            Return
        End If
        
        Dim firmId As Integer = 0
        If Not Integer.TryParse(Session("firm_id").ToString(), firmId) OrElse firmId <= 0 Then
            Return
        End If
        
        sql = "select PARENT_ACC,  ACCOUNT_NO,  OPENING_AMT_DEBIT,  DURING_AMT_DEBIT,  DURING_AMT_CREDIT,  CLOSING_AMT_DEBIT,  ACCOUNT_NAME,  LESS_30DAYS,  BTW30_60,  BTW60_90,  GRT_90,  main_ACCOUNT_NAME, LESS_30INV_NO, LESS_30INV_DT, BTW30_60_INVNO, BTW30_60_INVDT, BTW60_90_INVNO, BTW60_90INVDT, GRT_90_INVNO, GRT_90INVDT  from table(sub_during_balance_inv(" & firmId & ",  '" & accno & "',  '" & date1 & "',  '" & date2 & "'))"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        For Each dr In dt.Rows
            Rowtotal = 0
            Dim row9 As New TableRow
            row9.BackColor = Drawing.Color.WhiteSmoke
            Dim c91, c92, c93, c94, c95, c96, c97, c98, c99, c100, c101, c102, C103, c104, c105, c106, c107, c108 As New TableCell
            c91.ColumnSpan = 1
            c92.ColumnSpan = 1
            c93.ColumnSpan = 1
            c94.ColumnSpan = 1
            c95.ColumnSpan = 1
            c96.ColumnSpan = 1
            c97.ColumnSpan = 1
            c98.ColumnSpan = 1
            c99.ColumnSpan = 1
            c100.ColumnSpan = 1
            c101.ColumnSpan = 1
            c102.ColumnSpan = 1
            C103.ColumnSpan = 1
            c104.ColumnSpan = 1
            c105.ColumnSpan = 1
            c106.ColumnSpan = 1
            c107.ColumnSpan = 1
            c108.ColumnSpan = 1


            c91.BorderColor = Drawing.Color.Black
            c91.Text = "<FONT SIZE =2>" & dr(1) & "</font>"

            c92.BorderColor = Drawing.Color.Black
            c92.Text = "<FONT SIZE =2>" & dr(6) & "</font>"

            If IsDBNull(dr(2)) Then
                c93.BorderColor = Drawing.Color.Black
                c93.Text = 0
            Else
                c93.BorderColor = Drawing.Color.Black
                c93.Text = "<FONT SIZE =2>" & dr(2) & "</font>"
            End If

            If IsDBNull(dr(3)) Then
                c94.BorderColor = Drawing.Color.Black
                c94.Text = 0
            Else
                c94.BorderColor = Drawing.Color.Black
                c94.Text = "<FONT SIZE =2>" & dr(3) & "</font>"
            End If

            If IsDBNull(dr(4)) Then
                c95.BorderColor = Drawing.Color.Black
                c95.Text = 0
            Else
                c95.BorderColor = Drawing.Color.Black
                c95.Text = "<FONT SIZE =2>" & dr(4) & "</font>"
            End If

            If IsDBNull(dr(5)) Then
                c96.BorderColor = Drawing.Color.Black
                c96.Text = 0
            Else
                c96.BorderColor = Drawing.Color.Black
                c96.Text = "<FONT SIZE =2>" & dr(5) & "</font>"
            End If

            If IsDBNull(dr(7)) Then
                c97.BorderColor = Drawing.Color.Black
                c97.Text = 0
            Else
                c97.BorderColor = Drawing.Color.Black
                c97.Text = "<FONT SIZE =2>" & dr(7) & "</font>"
            End If

            If IsDBNull(dr(8)) Then
                c98.BorderColor = Drawing.Color.Black
                c98.Text = 0
            Else
                c98.BorderColor = Drawing.Color.Black
                c98.Text = "<FONT SIZE =2>" & dr(8) & "</font>"
            End If

            If IsDBNull(dr(9)) Then
                c99.BorderColor = Drawing.Color.Black
                c99.Text = 0
            Else
                c99.BorderColor = Drawing.Color.Black
                c99.Text = "<FONT SIZE =2>" & dr(9) & "</font>"
            End If

            If IsDBNull(dr(10)) Then
                c100.BorderColor = Drawing.Color.Black
                c100.Text = 0
            Else
                c100.BorderColor = Drawing.Color.Black
                c100.Text = "<FONT SIZE =2>" & dr(10) & "</font>"
            End If

            If IsDBNull(dr(12)) Then
                c101.BorderColor = Drawing.Color.Black
                c101.Text = 0
            Else
                c101.BorderColor = Drawing.Color.Black
                c101.Text = "<FONT SIZE =2>" & dr(12) & "</font>"
            End If

            If IsDBNull(dr(13)) Then
                c102.BorderColor = Drawing.Color.Black
                c102.Text = 0
            Else
                c102.BorderColor = Drawing.Color.Black
                c102.Text = "<FONT SIZE =2>" & dr(13) & "</font>"
            End If

            If IsDBNull(dr(14)) Then
                C103.BorderColor = Drawing.Color.Black
                C103.Text = 0
            Else
                C103.BorderColor = Drawing.Color.Black
                C103.Text = "<FONT SIZE =2>" & dr(14) & "</font>"
            End If

            If IsDBNull(dr(15)) Then
                c104.BorderColor = Drawing.Color.Black
                c104.Text = 0
            Else
                c104.BorderColor = Drawing.Color.Black
                c104.Text = "<FONT SIZE =2>" & dr(15) & "</font>"
            End If

            If IsDBNull(dr(16)) Then
                c105.BorderColor = Drawing.Color.Black
                c105.Text = 0
            Else
                c105.BorderColor = Drawing.Color.Black
                c105.Text = "<FONT SIZE =2>" & dr(16) & "</font>"
            End If

            If IsDBNull(dr(17)) Then
                c106.BorderColor = Drawing.Color.Black
                c106.Text = 0
            Else
                c106.BorderColor = Drawing.Color.Black
                c106.Text = "<FONT SIZE =2>" & dr(17) & "</font>"
            End If

            If IsDBNull(dr(18)) Then
                c107.BorderColor = Drawing.Color.Black
                c107.Text = 0
            Else
                c107.BorderColor = Drawing.Color.Black
                c107.Text = "<FONT SIZE =2>" & dr(18) & "</font>"
            End If

            If IsDBNull(dr(19)) Then
                c108.BorderColor = Drawing.Color.Black
                c108.Text = 0
            Else
                c108.BorderColor = Drawing.Color.Black
                c108.Text = "<FONT SIZE =2>" & dr(19) & "</font>"
            End If


            'If IsDBNull(dr(11)) Then
            '    c101.BorderColor = Drawing.Color.Black
            '    c101.Text = 0
            'Else
            '    c101.BorderColor = Drawing.Color.Black
            '    c101.Text = "<FONT SIZE =2>" & dr(11) & "</font>"
            'End If

            'If IsDBNull(dr(12)) Then
            '    c102.BorderColor = Drawing.Color.Black
            '    c102.Text = 0
            'Else
            '    c102.BorderColor = Drawing.Color.Black
            '    c102.Text = "<FONT SIZE =2>" & dr(12) & "</font>"
            'End If





            ''If IsDBNull(dr(11)) Then
            'C103.Text = "<FONT SIZE =2>" & dr(12) & "</font>"
            'c104.Text = "<FONT SIZE =2>" & dr(13) & "</font>"
            'c105.Text = "<FONT SIZE =2>" & dr(14) & "</font>"



            'total = total + 1



            'If IsDBNull(dr(2)) Then
            '    precrval = 0
            'Else
            '    'precrval = dr(2)
            '    precrval = dr(2).Trim().Substring(0, dr(2).Length - 2)               
            'End If


            'If IsDBNull(dr(3)) Then
            '    predbval = 0
            'Else
            '    predbval = dr(3)
            'End If
            ''----------------------------------

            'If IsDBNull(dr(4)) Then
            '    durcrval = 0
            'Else
            '    durcrval = dr(4)
            'End If


            'If IsDBNull(dr(5)) Then
            '    durdbval = 0
            'Else
            '    'durdbval = dr(5)
            '    durdbval = dr(5).Trim().Substring(0, dr(5).Length - 2)
            'End If

            ''----------------------------------

            'If IsDBNull(dr(7)) Then
            '    thirtyval = 0
            'Else
            '    thirtyval = dr(7)
            'End If

            'If IsDBNull(dr(8)) Then
            '    sixval = 0
            'Else
            '    sixval = dr(8)
            'End If

            'If IsDBNull(dr(9)) Then
            '    nineval = 0
            'Else
            '    nineval = dr(9)
            'End If

            'If IsDBNull(dr(10)) Then
            '    finval = 0
            'Else
            '    finval = dr(10)
            'End If


            predbtot = predbtot + predbval
            precrtot = precrtot + precrval
            durdbtot = durdbtot + durdbval
            durcrtot = durcrtot + durcrval


            thirtytot = thirtytot + thirtyval
            sixtot = sixtot + sixval
            ninetot = ninetot + nineval
            fintot = fintot + finval



            c91.HorizontalAlign = HorizontalAlign.Center
            c92.HorizontalAlign = HorizontalAlign.Center
            c93.HorizontalAlign = HorizontalAlign.Center
            c94.HorizontalAlign = HorizontalAlign.Center
            c95.HorizontalAlign = HorizontalAlign.Center
            c96.HorizontalAlign = HorizontalAlign.Center
            c97.HorizontalAlign = HorizontalAlign.Center
            c98.HorizontalAlign = HorizontalAlign.Center
            c99.HorizontalAlign = HorizontalAlign.Center
            c100.HorizontalAlign = HorizontalAlign.Center
            c101.HorizontalAlign = HorizontalAlign.Center
            c102.HorizontalAlign = HorizontalAlign.Center
            C103.HorizontalAlign = HorizontalAlign.Center
            c104.HorizontalAlign = HorizontalAlign.Center
            c105.HorizontalAlign = HorizontalAlign.Center
            c106.HorizontalAlign = HorizontalAlign.Center
            c107.HorizontalAlign = HorizontalAlign.Center
            c108.HorizontalAlign = HorizontalAlign.Center



            row9.Controls.Add(c91)
            row9.Controls.Add(c92)
            row9.Controls.Add(c93)
            row9.Controls.Add(c94)
            row9.Controls.Add(c95)
            row9.Controls.Add(c96)
            row9.Controls.Add(c97)
            row9.Controls.Add(c98)
            row9.Controls.Add(c99)
            row9.Controls.Add(c100)
            row9.Controls.Add(c101)
            row9.Controls.Add(c102)
            row9.Controls.Add(C103)
            row9.Controls.Add(c104)
            row9.Controls.Add(c105)
            row9.Controls.Add(c106)
            row9.Controls.Add(c107)
            row9.Controls.Add(c108)

            'row9.Controls.Add(c114)
            tab.Controls.Add(row9)
        Next
    End Sub
    Sub filltotal()
        Dim row6 As New TableRow
        row6.ForeColor = Drawing.Color.Red
        Dim c61, c62, c63, c64, c65, C66, C67, C68, C69, c70, c71, c72, c73, C74, c75, c76 As New TableCell
        c61.ColumnSpan = 1


        row6.HorizontalAlign = HorizontalAlign.Center
        row6.Font.Size = 10


        'c61.Text = "<font size=2><b>TOTAL:&nbsp;</font>" & total
        ''c62.Text = "<font size=2><b>&nbsp;</font>"
        'c63.Text = "<font size=2><b>&nbsp;</font>" & precrtot
        'c64.Text = "<font size=2><b>&nbsp;</font>" & predbtot
        'c65.Text = "<font size=2><b>&nbsp;</font>" & durcrtot
        'C66.Text = "<font size=2><b>&nbsp;</font>" & durdbtot
        'C67.Text = "<font size=2><b>&nbsp;</font>" & thirtytot
        'C68.Text = "<font size=2><b>&nbsp;</font>" & sixtot
        'C69.Text = "<font size=2><b>&nbsp;</font>" & ninetot
        'c70.Text = "<font size=2><b>&nbsp;</font>" & fintot



        row6.Controls.Add(c61)
        row6.Controls.Add(c62)
        row6.Controls.Add(c63)
        row6.Controls.Add(c64)
        row6.Controls.Add(c65)
        row6.Controls.Add(C66)
        row6.Controls.Add(C67)
        row6.Controls.Add(C68)
        row6.Controls.Add(C69)
        row6.Controls.Add(c70)
        tab.Controls.Add(row6)


    End Sub

    '--------VAPT - Enhanced Parameter Validation Methods--------
    Private Sub ValidateQueryParameters()
        For Each key As String In Request.QueryString.AllKeys
            If key IsNot Nothing Then
                Dim value As String = Request.QueryString(key)
                
                If Not ValidateParameter(key, value) Then
                    RedirectToLogin()
                    Return
                End If
            End If
        Next
    End Sub
    
    Private Function ValidateParameter(paramName As String, paramValue As String) As Boolean
        If String.IsNullOrEmpty(paramValue) Then Return False
        
        ' Length validation
        If paramValue.Length > 100 Then Return False
        
        ' Parameter-specific validation
        Select Case paramName.ToLower()
            Case "frdt", "todt"
                Return ValidateDateParameter(paramValue)
            Case "stid"
                Return ValidateNumericParameter(paramValue)
            Case Else
                Return Not ContainsMaliciousContent(paramValue)
        End Select
    End Function
    
    Private Function ValidateDateParameter(dateValue As String) As Boolean
        Try
            Dim parsedDate As DateTime
            If DateTime.TryParse(dateValue, parsedDate) Then
                ' Date should be within reasonable range
                Return parsedDate >= DateTime.Now.AddYears(-10) AndAlso parsedDate <= DateTime.Now.AddYears(1)
            End If
            Return False
        Catch
            Return False
        End Try
    End Function
    
    Private Function ValidateNumericParameter(numValue As String) As Boolean
        Try
            Dim parsedNum As Integer
            If Integer.TryParse(numValue, parsedNum) Then
                Return parsedNum > 0 AndAlso parsedNum <= 999999999
            End If
            Return False
        Catch
            Return False
        End Try
    End Function
    
    Private Sub ValidateSessionData()
        If Session("firm_id") Is Nothing Then
            RedirectToLogin()
            Return
        End If
    End Sub
    
    Private Function ValidateAndSanitizeInput(input As String) As String
        If String.IsNullOrEmpty(input) Then Return String.Empty
        
        '--------VAPT - Enhanced Input Validation--------
        If input.Length > 100 OrElse ContainsMaliciousContent(input) Then
            RedirectToLogin()
            Return String.Empty
        End If
        
        ' Remove potentially dangerous characters
        Dim sanitized As String = input.Trim()
        sanitized = System.Text.RegularExpressions.Regex.Replace(sanitized, "[<>""'%;()&+]", "")
        
        Return HttpUtility.HtmlEncode(sanitized)
    End Function
    
    Private Function ContainsMaliciousContent(input As String) As Boolean
        If String.IsNullOrEmpty(input) Then Return False
        
        Dim maliciousPatterns() As String = {
            "<script", "javascript:", "vbscript:", "onload=", "onerror=",
            "''", "--", "/*", "*/", "xp_", "sp_", "exec", "union",
            "select", "insert", "update", "delete", "drop", "create"
        }
        
        Dim lowerInput As String = input.ToLower()
        For Each pattern As String In maliciousPatterns
            If lowerInput.Contains(pattern) Then Return True
        Next
        
        Return False
    End Function
    
    Private Sub RedirectToLogin()
        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("alert('Please Login Again');")
        cl_script0.Append("window.open('main.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
    End Sub

    Protected Sub lnkbutExportXL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbutExportXL.Click
        '--------VAPT - Sanitize Filename--------
        Dim filename As String
        filename = "Trxn" & CDate(Now.Date).ToString("dd-MMM-yyyy") & ".xls"
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment; filename=" & filename)
        Response.Charset = ""

        ' If you want the option to open the Excel file without saving than
        ' comment out the line below
        ' Response.Cache.SetCacheability(HttpCacheability.NoCache);

        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As New System.IO.StringWriter()
        Dim htmlWrite As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(stringWrite)
        pn3.RenderControl(htmlWrite)
        Response.Write(stringWrite.ToString())
        Response.End()
    End Sub
End Class
