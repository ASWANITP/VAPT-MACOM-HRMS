Imports System.Data
Imports System.Data.OracleClient
Partial Class PayRoll_pay_sus_rvk_Repo_a9ae87294506
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim typtest As Integer = 2
        Dim type As String
        Dim tc5 As New TableCell
        If Request.QueryString.Get("typ") = 1 Then
            dt = oh.ExecuteDataSet("select em.emp_name,em.emp_code,dm.dep_name,pm.post_name,bm.branch_name,to_char(epd.from_dt),epd.susp_rmrk from employee_master em,branch_master bm,department_mst dm,post_mst pm,employ_promotion_dtl epd where em.branch_id=bm.branch_id and em.department_id=dm.dep_id and em.post_id=pm.post_id and epd.emp_code=em.emp_code and to_dt is null and epd.status_id=4 and em.emp_code=" & Request.QueryString.Get("ecode") & "").Tables(0)
            type = " Suspension From The Service"
            tc5.Text = "<font size=3><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mr/Ms." & dt.Rows(0)(0) & " (Emp.Code:" & dt.Rows(0)(1) & ")," & dt.Rows(0)(2) & "," & dt.Rows(0)(3) & "," & dt.Rows(0)(4) & ": branch has been placed into Suspension With effect from :" & dt.Rows(0)(5) & " for " & dt.Rows(0)(6) & "  noticed at our " & dt.Rows(0)(4) & "  Branch,pending detailed enquiry into the matter. </b></font>"
        Else
            'dt = oh.ExecuteDataSet("select em.emp_name,em.emp_code,dm.dep_name,pm.post_name,bm.branch_name,epd.revoke_rmrk,to_char(max(epd.from_dt)),to_char(max(epd.to_dt)) from employee_master em,branch_master bm,department_mst dm,post_mst pm,employ_promotion_dtl epd where em.branch_id=bm.branch_id and em.department_id=dm.dep_id and em.post_id=pm.post_id and epd.emp_code=em.emp_code and epd.status_id=4 and em.emp_code=" & Request.QueryString.Get("ecode") & " and epd.to_dt in(select max(epd.to_dt) from employ_promotion_dtl) group by em.emp_name,em.emp_code,dm.dep_name,pm.post_name,bm.branch_name,to_char(epd.from_dt),epd.revoke_rmrk").Tables(0)
            dt = oh.ExecuteDataSet("select em.emp_name,em.emp_code,dm.dep_name,pm.post_name,bm.branch_name,epd.revoke_rmrk,to_char(epd.from_dt),to_char(epd.to_dt),to_date(epd.enter_dt) from employee_master em,branch_master bm,department_mst dm,post_mst pm,employ_promotion_dtl epd where em.branch_id=bm.branch_id and em.department_id=dm.dep_id and em.post_id=pm.post_id and epd.emp_code=em.emp_code and epd.status_id=4 and em.emp_code=" & Request.QueryString.Get("ecode") & " and epd.enter_dt in (select max(enter_dt) from employ_promotion_dtl )").Tables(0)
            type = "Revocation of Suspension Order"
            tc5.Text = "<font size=3><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The suspension of Mr/Ms." & dt.Rows(0)(0) & "(Emp.Code:" & dt.Rows(0)(1) & ")," & dt.Rows(0)(2) & "," & dt.Rows(0)(3) & "," & dt.Rows(0)(4) & ":Branch is revoked with effect from " & dt.Rows(0)(7) & " accepting his explanations-(" & dt.Rows(0)(5) & ")." & Environment.NewLine() & "The suspension period from :" & dt.Rows(0)(6) & " to : " & dt.Rows(0)(7) & " will be treated as leave and adjusted towards his leave account. </b></font>"
        End If
        Dim tb As New Table
        Dim tr1 As New TableRow
        tb.Attributes.Add("width", "100%")
        'tb.Attributes.Add("border", "2")
        Dim tc1 As New TableCell
        tc1.Attributes.Add("width", "100%")
        tc1.ColumnSpan = 10
        tc1.HorizontalAlign = HorizontalAlign.Right
        tc1.Text = "<font size=2><b> Date : " & Format(Date.Now, "dd/MMM/yyyy") & " </b></font>"
        tr1.Controls.Add(tc1)
        tb.Controls.Add(tr1)

        Dim tr2 As New TableRow
        Dim tc2 As New TableCell
        tc2.Attributes.Add("width", "100%")
        tc2.ColumnSpan = 10
        tc2.HorizontalAlign = HorizontalAlign.Right
        tc2.Text = "<font size=2><b> Time : " & Format(Date.Now, "hh:mm:ss") & " </b></font>"
        tr2.Controls.Add(tc2)

        tb.Controls.Add(tr2)

        'If typtest = 1 Then
        '    'If Request.QueryString.Get("typ") = 1 Then
        '    type = " Suspension From The Service"
        'Else
        '    type = "Revocation of Suspension Order"
        'End If

        Dim tr3 As New TableRow
        Dim tc3 As New TableCell
        tc3.Attributes.Add("width", "100%")
        tc3.ColumnSpan = 10
        tc3.HorizontalAlign = HorizontalAlign.Left
        tc3.Text = "<font size=3><b> " & type & " </b></font>"
        tr3.Controls.Add(tc3)

        tb.Controls.Add(tr3)

        Dim tr4 As New TableRow
        Dim tc4 As New TableCell
        tc4.Attributes.Add("width", "100%")
        tc4.ColumnSpan = 10
        tc4.HorizontalAlign = HorizontalAlign.Left
        tc4.Text = "<font size=2><b>----------------------------------------------------- </b></font>"
        tr4.Controls.Add(tc4)

        tb.Controls.Add(tr4)


        Dim tr5 As New TableRow

        tc5.Attributes.Add("width", "100%")
        tc5.ColumnSpan = 10
        tc5.HorizontalAlign = HorizontalAlign.Left
        'If typtest = 1 Then
        '    tc5.Text = "<font size=3><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mr/Ms." & dt.Rows(0)(0) & " (Emp.Code:" & dt.Rows(0)(1) & ")," & dt.Rows(0)(2) & "," & dt.Rows(0)(3) & "," & dt.Rows(0)(4) & ": branch has been placed into Suspension With effect from :" & dt.Rows(0)(5) & " for " & dt.Rows(0)(6) & "  noticed at our " & dt.Rows(0)(4) & "  Branch,pending detailed enquiry into the matter. </b></font>"
        'Else
        '    tc5.Text = "<font size=3><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The suspension of Mr/Ms." & dt.Rows(0)(0) & "(Emp.Code:" & dt.Rows(0)(1) & ")," & dt.Rows(0)(2) & "," & dt.Rows(0)(3) & "," & dt.Rows(0)(4) & ":Branch is revoked with effect from " & dt.Rows(0)(7) & " accepting his explanations-(" & dt.Rows(0)(5) & ")." & Environment.NewLine() & "The suspension period from :" & dt.Rows(0)(6) & " to : " & dt.Rows(0)(7) & " will be treated as leave and adjusted towards his leave account. </b></font>"
        'End If

        tr5.Controls.Add(tc5)

        tb.Controls.Add(tr5)

        Dim tr6 As New TableRow
        Dim tc6 As New TableCell
        tc6.Attributes.Add("width", "100%")
        tc6.ColumnSpan = 10
        tc6.HorizontalAlign = HorizontalAlign.Left
        tc6.Text = "<font size=2><b></b></font>"
        tr6.Controls.Add(tc6)

        tb.Controls.Add(tr6)

        Dim tr61 As New TableRow
        Dim tc61 As New TableCell
        tc61.Attributes.Add("width", "100%")
        tc61.ColumnSpan = 10
        tc61.HorizontalAlign = HorizontalAlign.Left
        tc61.Text = "<font size=2><b></b></font>"
        tr6.Controls.Add(tc61)

        tb.Controls.Add(tr61)

        Dim tr7 As New TableRow
        Dim tc7 As New TableCell
        tc7.Attributes.Add("width", "100%")
        tc7.ColumnSpan = 10
        tc7.HorizontalAlign = HorizontalAlign.Left

        '--------Changed to print MD name from DB..changed on 20-Oct-2016
        'tc7.Text = "<font size=2><b> V.P.NANDAKUMAR </b></font>"
        Dim sqlstr, name As String
        Dim TempDt As DataTable
        name = " "
        sqlstr = "select count(m.emp_name) from employee_master m,employ_firm f where m.emp_code=f.emp_code and m.status_id=1 and m.post_id=192 and f.firm_id=" & Session("firm_id") & ""
        TempDt = oh.ExecuteDataSet(sqlstr).Tables(0)
        If TempDt.Rows(0)(0) > 0 Then
            TempDt.Clear()
            sqlstr = "select m.emp_name from employee_master m,employ_firm f where m.emp_code=f.emp_code and m.status_id=1 and m.post_id=192 and f.firm_id=" & Session("firm_id") & ""
            TempDt = oh.ExecuteDataSet(sqlstr).Tables(0)
            name = TempDt.Rows(0)(0)
        End If

        tc7.Text = "<font size=2><b>" & name.ToUpper() & "</b></font>"
        '-------------------------------------------------------------
        tr7.Controls.Add(tc7)

        tb.Controls.Add(tr7)

        Dim tr8 As New TableRow
        Dim tc8 As New TableCell
        tc8.Attributes.Add("width", "100%")
        tc8.ColumnSpan = 10
        tc8.HorizontalAlign = HorizontalAlign.Left
        tc8.Text = "<font size=2><b> Managing Director </b></font>"
        tr8.Controls.Add(tc8)

        tb.Controls.Add(tr8)

        Dim tr9 As New TableRow
        Dim tc9 As New TableCell
        tc9.Attributes.Add("width", "100%")
        tc9.ColumnSpan = 10
        tc9.HorizontalAlign = HorizontalAlign.Left
        tc9.Text = "<font size=2><b> </b></font>"
        tr9.Controls.Add(tc9)

        tb.Controls.Add(tr9)


        Dim tr10 As New TableRow
        Dim tc10 As New TableCell
        tc10.Attributes.Add("width", "100%")
        tc10.ColumnSpan = 10
        tc10.HorizontalAlign = HorizontalAlign.Left
        tc10.Text = "<font size=2><b> </b></font>"
        tr10.Controls.Add(tc10)

        tb.Controls.Add(tr10)

        Dim tr11 As New TableRow
        Dim tc11 As New TableCell
        tc11.Attributes.Add("width", "100%")
        tc11.ColumnSpan = 10
        tc11.HorizontalAlign = HorizontalAlign.Left
        tc11.Text = "<font size=2><b> TO, </b></font>"
        tr11.Controls.Add(tc11)

        tb.Controls.Add(tr11)

        Dim tr12 As New TableRow
        Dim tc12 As New TableCell
        tc12.Attributes.Add("width", "100%")
        tc12.ColumnSpan = 10
        tc12.HorizontalAlign = HorizontalAlign.Left
        tc12.Text = "<font size=2><b>Mr/Ms. " & dt.Rows(0)(0) & " </b></font>"
        tr12.Controls.Add(tc12)

        tb.Controls.Add(tr12)

        Dim tr13 As New TableRow
        Dim tc13 As New TableCell
        tc13.Attributes.Add("width", "100%")
        tc13.ColumnSpan = 10
        tc13.HorizontalAlign = HorizontalAlign.Left
        tc13.Text = "<font size=2><b>Emp.Code: " & dt.Rows(0)(1) & " </b></font>"
        tr13.Controls.Add(tc13)

        tb.Controls.Add(tr13)

        Dim tr14 As New TableRow
        Dim tc14 As New TableCell
        tc14.Attributes.Add("width", "100%")
        tc14.ColumnSpan = 10
        tc14.HorizontalAlign = HorizontalAlign.Left
        tc14.Text = "<font size=2><b>" & dt.Rows(0)(2) & " </b></font>"
        tr14.Controls.Add(tc14)

        tb.Controls.Add(tr14)

        Dim tr15 As New TableRow
        Dim tc15 As New TableCell
        tc15.Attributes.Add("width", "100%")
        tc15.ColumnSpan = 10
        tc15.HorizontalAlign = HorizontalAlign.Left
        tc15.Text = "<font size=2><b>" & dt.Rows(0)(3) & " </b></font>"
        tr15.Controls.Add(tc15)

        tb.Controls.Add(tr15)

        Dim tr16 As New TableRow
        Dim tc16 As New TableCell
        tc16.Attributes.Add("width", "100%")
        tc16.ColumnSpan = 10
        tc16.HorizontalAlign = HorizontalAlign.Left
        tc16.Text = "<font size=2><b>" & dt.Rows(0)(4) & ": Branch </b></font>"
        tr16.Controls.Add(tc16)

        tb.Controls.Add(tr16)

        Me.Panel1.Controls.Add(tb)

    End Sub
End Class
