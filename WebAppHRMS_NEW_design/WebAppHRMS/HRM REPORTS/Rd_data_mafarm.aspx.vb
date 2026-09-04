Imports System.Data
Imports System.Data.OracleClient
Partial Class Auction_Listed_pledges_ad40ce217263
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Dim dt, dt1 As New DataTable
    Dim dr As DataRow
    Dim tbl As New Table
    Dim count, type As New Integer
    Dim fdate, tdate, brid, fd, branch_name As String
    Dim total1, total2, total3, total4, total5, total6, total7, total8, total9, total10, total11, total12, total13, total14, total15, total16, total17 As String
    Dim date1 As Date 

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        brid = Session("branch_id")
        type = Request.QueryString.Get("adt")
        FillReportHeader()
        FillColumnHeader()
        FillColumnField()
        FillTotalField()
        Panel1.Controls.Add(tbl)
    End Sub


    Sub FillReportHeader()
        tbl.Attributes.Add("width", "100%")
        tbl.Attributes.Add("align", "center")
        tbl.Attributes.Add("border", "0")
        Dim tr1 As New TableRow
        Dim tc1 As New TableCell

        tc1.ColumnSpan = 9

        tc1.Text = "<font size=4><b>" & Session("firm_name") & "</font></b>"
        tc1.HorizontalAlign = HorizontalAlign.Center
        tc1.BackColor = Drawing.Color.Gold
        tc1.ForeColor = Drawing.Color.Red
        tc1.BorderColor = Drawing.Color.Red
        tr1.Controls.Add(tc1)
        tbl.Controls.Add(tr1)
        Dim tr2 As New TableRow
        Dim tc2 As New TableCell
        tc2.ColumnSpan = 9
        tc2.Text = "<font size=2><b>" & Session("branch_name") & " </font></b>"
        tc2.HorizontalAlign = HorizontalAlign.Center
        tc2.BackColor = Drawing.Color.LightCyan
        tr2.Controls.Add(tc2)
        tbl.Controls.Add(tr2)
        Dim tr3 As New TableRow
        Dim tc31 As New TableCell
        Dim tc32 As New TableCell
        Dim tc33 As New TableCell
        tc31.ColumnSpan = 1
        tc32.ColumnSpan = 7
        tc33.ColumnSpan = 1

        tc31.Text = "<font size=2><b>DATE : " & Format(Date.Now, "dd-MMM-yyyy") & "</font></b>"
        tc31.HorizontalAlign = HorizontalAlign.Left
        tc32.Text = "<font size=2><b>RD PAYABLE REPORT</font></b>"
        tc32.HorizontalAlign = HorizontalAlign.Center
        tc33.Text = "<b><font size=2 >TIME : " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        tc33.HorizontalAlign = HorizontalAlign.Right
        tr3.ForeColor = Drawing.Color.Red
        tr3.BackColor = Drawing.Color.Gold
        tr3.Controls.Add(tc31)
        tr3.Controls.Add(tc32)
        tr3.Controls.Add(tc33)
        tbl.Controls.Add(tr3)


        'Dim tr5 As New TableRow
        'tr5.BackColor = Drawing.Color.LightGray
        'Dim tcx11, tcx12, tcx13, tcx14, tcx15, tcx16, tcx17, tcx18, tcx19, tcx10, tcx21, tcx22, tcx23, tcx24, tcx25, tcx26 As New TableCell
        'tr5.BackColor = Drawing.Color.LightGray
        'tr5.ForeColor = Drawing.Color.Black
        'tr5.Font.Bold = True
        'tcx11.ColumnSpan = 2
        'tcx12.ColumnSpan = 2
        'tcx13.ColumnSpan = 3
        'tcx14.ColumnSpan = 3
        'tcx15.ColumnSpan = 3
        'tcx16.ColumnSpan = 3
        'tcx17.ColumnSpan = 3

        'tcx11.Text = "<font size=2><b></font>"
        'tcx12.Text = "<font size=2><b>Listed Pledges</font>"
        'tcx13.Text = "<font size=2><b>Interest Remitted Accounts</font>"
        'tcx14.Text = "<font size=2><b>Normal Settlment</font>"
        'tcx15.Text = "<font size=2><b>Auction Settled</font>"
        'tcx16.Text = "<font size=2><b>Stock In Auction Center(Not Auctioned)</font>"
        'tcx17.Text = "<font size=2><b>Balance in branch</font>"

        'tcx11.HorizontalAlign = HorizontalAlign.Center
        'tcx12.HorizontalAlign = HorizontalAlign.Center
        'tcx13.HorizontalAlign = HorizontalAlign.Center
        'tcx14.HorizontalAlign = HorizontalAlign.Center
        'tcx15.HorizontalAlign = HorizontalAlign.Center
        'tcx16.HorizontalAlign = HorizontalAlign.Center
        'tcx17.HorizontalAlign = HorizontalAlign.Center

        'tr5.Controls.Add(tcx11)
        'tr5.Controls.Add(tcx12)
        'tr5.Controls.Add(tcx13)
        'tr5.Controls.Add(tcx14)
        'tr5.Controls.Add(tcx15)
        'tr5.Controls.Add(tcx16)
        'tr5.Controls.Add(tcx17)

        'tbl.Controls.Add(tr5) 

    End Sub
    Sub FillColumnHeader()
        Dim tr4 As New TableRow
        tr4.BackColor = Drawing.Color.LightGray
        Dim tc41, tc42, tc43, tc44, tc45, tc46, tc47, tc48, tc49, tc50, tc51, tc52, tc53, tc54, tc55, tc56, tc57, tc58, tc59, tc60, tc61, tc62, tc63, tc64 As New TableCell
        tr4.BackColor = Drawing.Color.LightGray
        tr4.ForeColor = Drawing.Color.Black
        tr4.Font.Bold = True

        tc41.Text = "<font size=2><b>SL NO.</font>"
        tc42.Text = "<font size=2><b>EMPLOYEE CODE</font>"
        tc43.Text = "<font size=2><b>EMPLOYEE NAME</font>"
        tc44.Text = "<font size=2><b>JOIN DATE</font>"
        tc45.Text = "<font size=2><b>TOTAL RD AMOUNT</font>"
        tc46.Text = "<font size=2><b>PAID RD AMOUNT</font>"
        tc47.Text = "<font size=2><b>BALANCE TO BE PAID</font>"
        tc48.Text = "<font size=2><b>STATUS</font>"
        tc49.Text = "<font size=2><b>NUMBER OF INSTALLMENTS</font>"

        tc41.HorizontalAlign = HorizontalAlign.Left
        tc42.HorizontalAlign = HorizontalAlign.Left
        tc43.HorizontalAlign = HorizontalAlign.Left
        tc44.HorizontalAlign = HorizontalAlign.Left
        tc45.HorizontalAlign = HorizontalAlign.Right
        tc46.HorizontalAlign = HorizontalAlign.Right
        tc47.HorizontalAlign = HorizontalAlign.Right
        tc48.HorizontalAlign = HorizontalAlign.Center
        tc49.HorizontalAlign = HorizontalAlign.Right
       
        tr4.Controls.Add(tc41)
        tr4.Controls.Add(tc42)
        tr4.Controls.Add(tc43)
        tr4.Controls.Add(tc44)
        tr4.Controls.Add(tc45)
        tr4.Controls.Add(tc46)
        tr4.Controls.Add(tc47)
        tr4.Controls.Add(tc48)
        tr4.Controls.Add(tc49)
        tbl.Controls.Add(tr4)

    End Sub
    Sub FillColumnField()

        If type = 3 Then
            sql = "select rownum, xx.emp_code,xx.emp_name,xx.joindate,xx.SECURITY_DEPOSIT,xx.PAID_AMOUNT, xx.SECURITY_DEPOSIT-xx.PAID_AMOUNT BALANCE_TO_BE_PAID,xx.Status,xx.NUMBER_OF_INSTALLMENTS  from (select t.emp_code, t.emp_name,  to_char(t.join_dt)joindate, nvl(t.security_dep, 0) SECURITY_DEPOSIT, case when  ((select count(s.status_id) from status_master s where s.module_id=121 and s.status_id=t.emp_code)>0) then  (select nvl(w.order_by,0) from status_master w where w.module_id=121 and w.status_id=t.emp_code)   else nvl(sum(w.RDDED_AMT), 0) end  PAID_AMOUNT,  nvl(t.security_dep - nvl(sum(w.RDDED_AMT), 0), 0) BALANCE_TO_BE_PAID, decode(t.status_id, 1, 'LIVE', 'RESIGNED') Status,  case when s.amount > 0 then  t.security_dep / s.amount else  0   end NUMBER_OF_INSTALLMENTS  from employee_master t  join employ_firm f on f.emp_code = t.emp_code  and f.firm_id in ('" & Session("firm_id") & "')                    left join m_wage_all w on w.EMP_CODE = t.emp_code   and w.REC_FIRM = f.firm_id left join hrm_rd_security s on s.emp_code = t.emp_code group by t.emp_code, t.emp_name, t.join_dt, t.security_dep, t.status_id, s.amount order by t.emp_code) xx"
        ElseIf type = 2 Then
            sql = "select rownum, xx.emp_code,xx.emp_name,xx.joindate,xx.SECURITY_DEPOSIT,xx.PAID_AMOUNT, xx.SECURITY_DEPOSIT-xx.PAID_AMOUNT BALANCE_TO_BE_PAID,xx.Status,xx.NUMBER_OF_INSTALLMENTS  from (select t.emp_code, t.emp_name,  to_char(t.join_dt)joindate, nvl(t.security_dep, 0) SECURITY_DEPOSIT, case when  ((select count(s.status_id) from status_master s where s.module_id=121 and s.status_id=t.emp_code)>0) then  (select nvl(w.order_by,0) from status_master w where w.module_id=121 and w.status_id=t.emp_code)   else nvl(sum(w.RDDED_AMT), 0) end  PAID_AMOUNT,  nvl(t.security_dep - nvl(sum(w.RDDED_AMT), 0), 0) BALANCE_TO_BE_PAID, decode(t.status_id, 1, 'LIVE', 'RESIGNED') Status,  case when s.amount > 0 then  t.security_dep / s.amount else  0   end NUMBER_OF_INSTALLMENTS  from employee_master t  join employ_firm f on f.emp_code = t.emp_code  and f.firm_id in ('" & Session("firm_id") & "') and t.status_id<>1 left join m_wage_all w on w.EMP_CODE = t.emp_code   and w.REC_FIRM = f.firm_id left join hrm_rd_security s on s.emp_code = t.emp_code group by t.emp_code, t.emp_name, t.join_dt, t.security_dep, t.status_id, s.amount order by t.emp_code) xx"
        Else
            sql = "select rownum, xx.emp_code,xx.emp_name,xx.joindate,xx.SECURITY_DEPOSIT,xx.PAID_AMOUNT, xx.SECURITY_DEPOSIT-xx.PAID_AMOUNT BALANCE_TO_BE_PAID,xx.Status,xx.NUMBER_OF_INSTALLMENTS  from (select t.emp_code, t.emp_name,  to_char(t.join_dt)joindate, nvl(t.security_dep, 0) SECURITY_DEPOSIT, case when  ((select count(s.status_id) from status_master s where s.module_id=121 and s.status_id=t.emp_code)>0) then  (select nvl(w.order_by,0) from status_master w where w.module_id=121 and w.status_id=t.emp_code)   else nvl(sum(w.RDDED_AMT), 0) end  PAID_AMOUNT,  nvl(t.security_dep - nvl(sum(w.RDDED_AMT), 0), 0) BALANCE_TO_BE_PAID, decode(t.status_id, 1, 'LIVE', 'RESIGNED') Status,  case when s.amount > 0 then  t.security_dep / s.amount else  0   end NUMBER_OF_INSTALLMENTS  from employee_master t  join employ_firm f on f.emp_code = t.emp_code  and f.firm_id in ('" & Session("firm_id") & "') and t.status_id=1 left join m_wage_all w on w.EMP_CODE = t.emp_code   and w.REC_FIRM = f.firm_id left join hrm_rd_security s on s.emp_code = t.emp_code group by t.emp_code, t.emp_name, t.join_dt, t.security_dep, t.status_id, s.amount order by t.emp_code) xx"
        End If


        dt = oh.ExecuteDataSet(sql).Tables(0)
        For Each dr In dt.Rows
            Dim tr5 As New TableRow
            tr5.BackColor = Drawing.Color.WhiteSmoke
            Dim tc51, tc52, tc53, tc54, tc55, tc56, tc57, tc58, tc59, tc60, tc61, tc62, tc63, tc64, tc65, tc66, tc67, tc68, tc69, tc70 As New TableCell

            tc51.Text = "<FONT SIZE =2><font color='blue'>" & dr(0) & "</font>"
            tc52.Text = "<FONT SIZE =2><font color='blue'>" & dr(1) & "</font>"
            tc53.Text = "<FONT SIZE =2><font color='blue'>" & dr(2) & "</font>"
            tc54.Text = "<FONT SIZE =2><font color='blue'>" & dr(3) & "</font>"
            tc55.Text = "<FONT SIZE =2><font color='blue'>" & FormatNumber(dr(4)) & "</font>"
            tc56.Text = "<FONT SIZE =2><font color='blue'><a href='rdsplit.aspx?code=" & dr(1) & "'>" & FormatNumber(dr(5)) & "</a></font>"
            tc57.Text = "<FONT SIZE =2><font color='blue'>" & FormatNumber(dr(6)) & "</font>"
            tc58.Text = "<FONT SIZE =2><font color='blue'>" & dr(7) & "</font>"
            tc59.Text = "<FONT SIZE =2><font color='blue'>" & dr(8) & "</font>"

            tc51.HorizontalAlign = HorizontalAlign.Left
            tc52.HorizontalAlign = HorizontalAlign.Left
            tc53.HorizontalAlign = HorizontalAlign.Left
            tc54.HorizontalAlign = HorizontalAlign.Left
            tc55.HorizontalAlign = HorizontalAlign.Right
            tc56.HorizontalAlign = HorizontalAlign.Right
            tc57.HorizontalAlign = HorizontalAlign.Right
            tc58.HorizontalAlign = HorizontalAlign.Center
            tc59.HorizontalAlign = HorizontalAlign.Right

            tr5.Controls.Add(tc51)
            tr5.Controls.Add(tc52)
            tr5.Controls.Add(tc53)
            tr5.Controls.Add(tc54)
            tr5.Controls.Add(tc55)
            tr5.Controls.Add(tc56)
            tr5.Controls.Add(tc57)
            tr5.Controls.Add(tc58)
            tr5.Controls.Add(tc59)

            tbl.Controls.Add(tr5)
            count = count + 1
            total1 = total1 + dr(2)
            total2 = total2 + dr(3)
            total3 = total3 + dr(4)
            total4 = total4 + dr(5)
            total5 = total5 + dr(6)
        Next
    End Sub
    Sub FillTotalField()

        Dim tr6 As New TableRow
        tr6.BackColor = Drawing.Color.LightGray
        Dim tc61, tc62, tc63, tc64, tc65, tc66, tc67, tc68, tc69, tc70, tc71, tc72, tc73, tc74, tc75, tc76, tc77, tc78, tc79, tc80 As New TableCell
        tr6.BackColor = Drawing.Color.LightGray
        tr6.ForeColor = Drawing.Color.Black
        tr6.Font.Bold = True
        tc61.ColumnSpan = 1
        tc62.ColumnSpan = 1
        tc63.ColumnSpan = 2
        tc64.ColumnSpan = 1
        tc65.ColumnSpan = 1
        tc66.ColumnSpan = 1
        tc67.ColumnSpan = 1
        tc68.ColumnSpan = 2

        tc61.Text = "<font size=2><b>Total</font>"
        tc62.Text = "<font size=2><b>" & count & "</font>"
        ' tc63.Text = "<font size=2><b>" & FormatNumber(total1) & "</font>"
        ' tc64.Text = "<font size=2><b>" & FormatNumber(total2) & "</font>"
        tc65.Text = "<font size=2><b>" & FormatNumber(total3) & "</font>"
        tc66.Text = "<font size=2><b>" & FormatNumber(total4) & "</font>"
        tc67.Text = "<font size=2><b>" & FormatNumber(total5) & "</font>"

        tc61.HorizontalAlign = HorizontalAlign.Left
        tc62.HorizontalAlign = HorizontalAlign.Left
        tc63.HorizontalAlign = HorizontalAlign.Right
        tc64.HorizontalAlign = HorizontalAlign.Right
        tc65.HorizontalAlign = HorizontalAlign.Right
        tc66.HorizontalAlign = HorizontalAlign.Right
        tc67.HorizontalAlign = HorizontalAlign.Right

        tr6.Controls.Add(tc61)
        tr6.Controls.Add(tc62)
        tr6.Controls.Add(tc63)

        tr6.Controls.Add(tc65)
        tr6.Controls.Add(tc66)
        tr6.Controls.Add(tc67)
        tr6.Controls.Add(tc68)
        tbl.Controls.Add(tr6)
    End Sub
End Class
