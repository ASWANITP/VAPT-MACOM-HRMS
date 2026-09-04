Imports System.Data
Imports System.Data.OracleClient
Partial Class PF_REPORT_pf_form5_b3fbf9126278
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper
    Dim mflag As Integer = 0
    Dim mgtable As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sql As String = ""
        Dim dtstd As String = Me.Request.QueryString("dt")
        Dim m As Integer = CDate(dtstd).Month
        Dim y As Integer = CDate(dtstd).Year
        If m = 1 Then
            m = 12
            y = y - 1
        Else
            m = m - 1
        End If
        Dim dtst As Date
        dtst = CDate(MonthName(m, True).ToUpper & "/" & y)

        Dim dtstr As String = "select count(*) from m_wage m where to_char(m.sal_dt,'MON/yyyy')='" & Format(dtst, "MMM/yyyy").ToUpper & "'"
        Dim dtsttable As DataTable = oh.ExecuteDataSet(dtstr).Tables(0)
        If dtsttable.Rows(0)(0) <> 0 Then
            If Request.QueryString("firm") = 1 Then
                sql = "select em.pf_accno,e.emp_code,e.emp_name,m.fat_hus,ep.birth_date,e.join_dt,' ' as remarks,decode(ep.sex,1,'Male',0,'Female') from employee_master e,m_wage m ,employ_personal_dtl ep,employee_master_dtl em,employ_transfer_dtl et where e.emp_code=ep.emp_code and e.emp_code=em.emp_code and e.emp_code=m.emp_code and e.emp_type =1 and e.firm_id in(1) and e.emp_code=et.emp_code and et.status_id=1 and (e.join_dt >(select max(sal_dt) from m_wage_his) or et.enter_dt>= (select max(sal_dt) from m_wage_his)) order by e.emp_code"
            ElseIf Request.QueryString("firm") = 2 Then
                sql = "select em.pf_accno,e.emp_code,e.emp_name,m.fat_hus,ep.birth_date,e.join_dt,' ' as remarks,decode(ep.sex,1,'Male',0,'Female') from employee_master e,m_wage m ,employ_personal_dtl ep,employee_master_dtl em,employ_transfer_dtl et where e.emp_code=ep.emp_code and e.emp_code=em.emp_code and e.emp_code=m.emp_code and e.emp_type =1 and e.firm_id in(2,3) and e.emp_code=et.emp_code and et.status_id=1 and (e.join_dt >(select max(sal_dt) from m_wage_his) or et.enter_dt>= (select max(sal_dt) from m_wage_his)) order by e.emp_code"
            Else
                sql = "select em.pf_accno,e.emp_code,e.emp_name,m.fat_hus,ep.birth_date,e.join_dt,' ' as remarks,decode(ep.sex,1,'Male',0,'Female') from employee_master e,m_wage m ,employ_personal_dtl ep,employee_master_dtl em,employ_transfer_dtl et where e.emp_code=ep.emp_code and e.emp_code=em.emp_code and e.emp_code=m.emp_code and e.emp_type =1 and e.firm_id in(24) and e.emp_code=et.emp_code and et.status_id=1 and (e.join_dt >(select max(sal_dt) from m_wage_his) or et.enter_dt>= (select max(sal_dt) from m_wage_his)) order by e.emp_code"
            End If
        Else
            mflag = 1
            Dim k, y1 As Integer
            Dim mgst1 As String = ""
            Dim mgst2 As String = ""
            k = m
            y1 = y
            If m = 1 Then
                k = 12
                y1 = y1 - 1
            Else
                k = k - 1
            End If
            mgst1 = (MonthName(k, True) & "/" & y1).ToUpper
            mgst2 = (MonthName(m, True) & "/" & y).ToUpper
            Dim mg As String = "select distinct m.sal_dt from m_wage_his m where (to_char(m.sal_dt,'MON/yyyy')='" & mgst1 & "' or to_char(m.sal_dt,'MON/yyyy')='" & mgst2 & "' ) order by m.sal_dt"
            mgtable = oh.ExecuteDataSet(mg).Tables(0)
            If mgtable.Rows.Count <> 2 Then
                Dim script1 As New System.Text.StringBuilder
                script1.Append("        alert('Sorry, Details Not Available');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
                Exit Sub
            Else
                If Request.QueryString("firm") = 1 Then
                    sql = "select distinct em.pf_accno,e.emp_code,e.emp_name,m.fat_hus,ep.birth_date,e.join_dt,' ' as remarks,decode(ep.sex,1,'Male',0,'Female') from employee_master e,m_wage_his m ,employ_personal_dtl ep,employee_master_dtl em,employ_transfer_dtl et where e.emp_code=ep.emp_code and e.emp_code=em.emp_code and e.emp_code=m.emp_code and e.emp_type =1 and e.firm_id in(1) and e.emp_code=et.emp_code and et.status_id=1 and ((e.join_dt>to_date('" & Format(mgtable.Rows(0)(0), "dd/MMM/yyyy") & "') and e.join_dt<to_date('" & Format(mgtable.Rows(1)(0), "dd/MMM/yyyy") & "')) or (et.enter_dt>=to_date('" & Format(mgtable.Rows(0)(0), "dd/MMM/yyyy") & "') and et.enter_dt<to_date('" & Format(mgtable.Rows(1)(0), "dd/MMM/yyyy") & "'))) and e.emp_code in(select e1.emp_code from m_wage_his h,employee_master e1 where to_char(h.sal_dt)=to_date('" & Format(mgtable.Rows(1)(0), "dd/MMM/yyyy") & "') and h.firm_id=1 and h.emp_code=e1.emp_code and e1.emp_type=1) order by e.emp_code"
                ElseIf Request.QueryString("firm") = 2 Then
                    sql = "select distinct em.pf_accno,e.emp_code,e.emp_name,m.fat_hus,ep.birth_date,e.join_dt,' ' as remarks,decode(ep.sex,1,'Male',0,'Female') from employee_master e,m_wage_his m ,employ_personal_dtl ep,employee_master_dtl em,employ_transfer_dtl et where e.emp_code=ep.emp_code and e.emp_code=em.emp_code and e.emp_code=m.emp_code and e.emp_type =1 and e.firm_id in(2,3) and e.emp_code=et.emp_code and et.status_id=1 and ((e.join_dt>to_date('" & Format(mgtable.Rows(0)(0), "dd/MMM/yyyy") & "') and e.join_dt<to_date('" & Format(mgtable.Rows(1)(0), "dd/MMM/yyyy") & "')) or (et.enter_dt>=to_date('" & Format(mgtable.Rows(0)(0), "dd/MMM/yyyy") & "') and et.enter_dt<to_date('" & Format(mgtable.Rows(1)(0), "dd/MMM/yyyy") & "'))) and e.emp_code in(select e1.emp_code from m_wage_his h,employee_master e1 where to_char(h.sal_dt)=to_date('" & Format(mgtable.Rows(1)(0), "dd/MMM/yyyy") & "') and h.firm_id in(2,5) and h.emp_code=e1.emp_code and e1.emp_type=1) order by e.emp_code"
                Else
                    sql = "select distinct em.pf_accno,e.emp_code,e.emp_name,m.fat_hus,ep.birth_date,e.join_dt,' ' as remarks,decode(ep.sex,1,'Male',0,'Female') from employee_master e,m_wage_his m ,employ_personal_dtl ep,employee_master_dtl em,employ_transfer_dtl et where e.emp_code=ep.emp_code and e.emp_code=em.emp_code and e.emp_code=m.emp_code and e.emp_type =1 and e.firm_id in(24) and e.emp_code=et.emp_code and et.status_id=1 and ((e.join_dt>to_date('" & Format(mgtable.Rows(0)(0), "dd/MMM/yyyy") & "') and e.join_dt<to_date('" & Format(mgtable.Rows(1)(0), "dd/MMM/yyyy") & "')) or (et.enter_dt>=to_date('" & Format(mgtable.Rows(0)(0), "dd/MMM/yyyy") & "') and et.enter_dt<to_date('" & Format(mgtable.Rows(1)(0), "dd/MMM/yyyy") & "'))) and e.emp_code in(select e1.emp_code from m_wage_his h,employee_master e1 where to_char(h.sal_dt)=to_date('" & Format(mgtable.Rows(1)(0), "dd/MMM/yyyy") & "') and e1.firm_id in(24) and h.emp_code=e1.emp_code and e1.emp_type=1) order by e.emp_code"
                End If
            End If
        End If
        Dim dt As DataTable = oh.ExecuteDataSet(sql).Tables(0)
        Dim tab1 As New Table
        tab1.Attributes.Add("width", "100%")
        Dim tabr1 As New TableRow
        tabr1.Width = 10
        Dim tabc1 As New TableCell

        tabc1.Text = "<body align=center color=red><b><font size=2.5> FORM NO.5 </font></b></body>"
        tabc1.ColumnSpan = 10
        tabr1.Controls.Add(tabc1)
        tab1.Controls.Add(tabr1)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Width = 10
        Dim tabc2 As New TableCell

        tabc2.Text = "<b><font size=2.5>ANNEXURE - 1</font></b>"
        tabc2.ColumnSpan = 10
        tabr2.Controls.Add(tabc2)
        tab1.Controls.Add(tabr2)


        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Width = 10
        'cell declaration
        Dim tabcc3 As New TableCell
        tabcc3.Attributes.Add("align", "center")
        Dim t As DataTable = oh.ExecuteDataSet("select firm_name from firm_master where firm_id= " & Me.Request.QueryString("firm")).Tables(0)
        tabcc3.Text = "<b><font size=2.5>" & t.Rows(0)(0) & " </font></b>"
        tabcc3.ColumnSpan = 10
        tabrr3.Controls.Add(tabcc3)
        tab1.Controls.Add(tabrr3)



        '3RD ROW
        Dim tabrr3Y As New TableRow
        tabrr3Y.Width = 10

        Dim tabcc3Y As New TableCell
        tabcc3Y.Attributes.Add("align", "center")
        If mflag = 0 Then
            Dim dd As DataTable = oh.ExecuteDataSet("select to_char(max(sal_dt),'MON,YYYY') from m_wage_his").Tables(0)
            tabcc3Y.Text = "<b><font size=2.5>LIST OF NEW EMPLOYEES " & dd.Rows(0)(0) & " </font></b>"
        Else
            tabcc3Y.Text = "<b><font size=2.5>LIST OF NEW EMPLOYEES " & Format(CDate(mgtable.Rows(0)(0)), "MMM/yyyy").ToUpper & " </font></b>"

        End If
        tabcc3Y.ColumnSpan = 10
        tabrr3Y.Controls.Add(tabcc3Y)
        tab1.Controls.Add(tabrr3Y)


        Dim tabrr3Y1 As New TableRow
        tabrr3Y1.Width = 10

        'cell declaration
        Dim tabcc3Y1 As New TableCell
        tabcc3Y1.Attributes.Add("align", "center")
        tabcc3Y1.Text = " "
        tabcc3Y1.ColumnSpan = 10
        tabrr3Y1.Controls.Add(tabcc3Y1)
        tab1.Controls.Add(tabrr3Y1)


        '5th row

        Dim tabr5 As New TableRow
        tabr5.Width = 10
        tabr5.ForeColor = Drawing.Color.DarkSlateGray
        Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7, tabr5c8 As New TableCell
        tabr5c1.ColumnSpan = 1
        tabr5c2.ColumnSpan = 1
        tabr5c3.ColumnSpan = 1
        tabr5c4.ColumnSpan = 2
        tabr5c5.ColumnSpan = 2
        tabr5c6.ColumnSpan = 1
        tabr5c7.ColumnSpan = 1
        tabr5c8.ColumnSpan = 1
        tabr5c1.HorizontalAlign = HorizontalAlign.Center
        Dim acno As String = ""
        If Me.Request.QueryString("firm") = 1 Then
            acno = "KR/KC/15076"
        ElseIf Me.Request.QueryString("firm") = 2 Then
            acno = "KR/KC/15001"
        Else
            acno = "KR/KC/27247"
        End If
        tabr5c1.Text = "<font size=2.5><b>PF A/C No. " & acno & "</b></font>"
        tabr5c2.Text = "<font size=2.5><b>EMP_CODE</b></font>"
        tabr5c3.Text = "<font size=2.5><b>EMP_NAME</b></font>"
        tabr5c4.Text = "<font size=2.5><b>FATHER'S / HUSBAND'S NAME</b></font>"
        tabr5c5.Text = "<font size=2.5><b>DATE OF JOINING</b></font>"
        tabr5c6.Text = "<font size=2.5><b>DATE OF BIRTH</b></font>"
        tabr5c8.Text = "<font size=2.5><b>SEX</b></font>"
        tabr5c7.Text = "<font size=2.5><b>SI.NO</b></font>"

        tabr5.Controls.Add(tabr5c7)
        tabr5.Controls.Add(tabr5c1)
        tabr5.Controls.Add(tabr5c2)
        tabr5.Controls.Add(tabr5c3)
        tabr5.Controls.Add(tabr5c4)
        tabr5.Controls.Add(tabr5c5)
        tabr5.Controls.Add(tabr5c6)
        tabr5.Controls.Add(tabr5c8)


        tab1.Controls.Add(tabr5)
        '''''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 10
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 10
        tabcellline1.Text = "<hr>"
        tabline1.Controls.Add(tabcellline1)
        tab1.Controls.Add(tabline1)

        Dim count As Integer = 0

        Dim dr As DataRow
        For Each dr In dt.Rows
            count += 1

            Dim tabr6 As New TableRow
            tabr6.Width = 12
            Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7, tabr6c8 As New TableCell
            tabr6c1.ColumnSpan = 1
            tabr6c2.ColumnSpan = 1
            tabr6c3.ColumnSpan = 1
            tabr6c4.ColumnSpan = 2
            tabr6c5.ColumnSpan = 2
            tabr6c6.ColumnSpan = 1
            tabr6c7.ColumnSpan = 1
            tabr6c8.ColumnSpan = 1

            tabr6c1.Attributes.Add("align", "center")
            tabr6c2.Attributes.Add("align", "left")
            tabr6c3.Attributes.Add("align", "left")
            tabr6c4.Attributes.Add("align", "left")
            tabr6c5.Attributes.Add("align", "left")
            tabr6c6.Attributes.Add("align", "left")
            tabr6c7.Attributes.Add("align", "left")
            tabr6c8.Attributes.Add("align", "left")

            tabr6c7.Text = "<font size=2>" & count & "&nbsp;&nbsp;</font>"
            tabr6c1.Text = "<font size=2>" & dr(0) & "&nbsp;&nbsp;</font>"
            tabr6c2.Text = "<font size=2>" & dr(1) & "&nbsp;&nbsp;</font>"
            tabr6c3.Text = "<font size=2>" & dr(2) & "&nbsp;&nbsp;</font>"
            tabr6c4.Text = "<font size=2>" & dr(3) & "&nbsp;&nbsp;</font>"
            tabr6c5.Text = "<font size=2>" & Format(dr(5), "dd/MMM/yyyy") & "&nbsp;&nbsp;</font>"
            tabr6c6.Text = "<font size=2>" & Format(dr(4), "dd/MMM/yyyy") & "&nbsp;&nbsp;</font>"
            tabr6c8.Text = "<font size=2>" & dr(7) & "&nbsp;&nbsp;</font>"

            tabr6.Controls.Add(tabr6c7)
            tabr6.Controls.Add(tabr6c1)
            tabr6.Controls.Add(tabr6c2)
            tabr6.Controls.Add(tabr6c3)
            tabr6.Controls.Add(tabr6c4)
            tabr6.Controls.Add(tabr6c5)
            tabr6.Controls.Add(tabr6c6)
            tabr6.Controls.Add(tabr6c8)
            tab1.Controls.Add(tabr6)
        Next
        Me.Panel1.Controls.Add(tab1)
    End Sub
End Class
