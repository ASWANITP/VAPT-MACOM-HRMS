
Imports System.Data
Imports System.Data.OracleClient
Partial Class promotiondetails_promotion_display_report_26bc35d17651
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("firm_id") = 2 Then
            Server.Transfer("promotion_display_report_mab.aspx")
            Exit Sub
        End If
        Dim frm = Session("firm_name").ToString
        ' dt = oh.ExecuteDataSet("select t.from_dt,t.to_dt ,d.designation,t.basic_pay,case when to_date(t.to_dt) is null then to_date(sysdate)-to_date(t.from_dt)+1 else (to_date(t.to_dt)-to_date(t.from_dt)+1) end  as days,decode(t.status_id,1,'JOINING',7,'PROMOTION',11,'INCREMENT',4,'SUSPENSION') as status from employ_promotion_dtl t,designation_master d where t.emp_code=" & Request.QueryString("emp") & " and t.designation_id=d.designation_id and  to_date(t.from_dt) between '" & Request.QueryString("f_dt") & "' and '" & Request.QueryString("t_dt") & "'  order by from_dt,status").Tables(0)
        If Session("firm_id") <> 28 Then
            dt = oh.ExecuteDataSet("select t.from_dt,t.to_dt ,case when t.designation_id is null then '-----' else d.designation end as des,nvl(t.basic_pay,0),case when to_date(t.to_dt) is null then to_date(sysdate)-to_date(t.from_dt)+1 else (to_date(t.to_dt)-to_date(t.from_dt)+1) end  as days,decode(t.status_id,1,'JOINING',7,'PROMOTION',11,'INCREMENT',4,'SUSPENSION') as status from employ_promotion_dtl t left outer join designation_master d on t.designation_id=d.designation_id where t.emp_code=" & Request.QueryString("emp") & " and  to_date(t.from_dt) between '" & Request.QueryString("f_dt") & "' and '" & Request.QueryString("t_dt") & "'  order by from_dt,status").Tables(0)
        Else
            dt = oh.ExecuteDataSet("select t.from_dt,t.to_dt ,case when t.designation_id is null then '-----' else case when d.designation_id <> 7 then d.designation || '/' || d.CTGRY || '/' || d.CTGRY_code when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = T.EMP_CODE and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (4, 3) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'JR. MANAGEMENT' || '/' || 'JM 4' when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = T.EMP_CODE and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (7) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'STAFF' || '/' || 'JM 2' when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = T.EMP_CODE and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (5, 6, 8) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'STAFF' || '/' || 'JM 3' when d.designation_id = 7 and exists (select t.emp_code, max(t.year_pass), t.qualification, qc.category_id from employ_qualification_dtl t, qualification_master qm, qualification_category qc where t.emp_code = T.EMP_CODE and qm.qualification_id = t.qualification and qc.category_id = qm.category_id and qc.category_id IN (2) group by t.emp_code, t.qualification, qc.category_id) then d.designation || '/' || 'JR. MANAGEMENT' || '/' || 'JM 5' end end as des,nvl(t.basic_pay,0),case when to_date(t.to_dt) is null then to_date(sysdate)-to_date(t.from_dt)+1 else (to_date(t.to_dt)-to_date(t.from_dt)+1) end  as days,decode(t.status_id,1,'JOINING',7,'PROMOTION',11,'INCREMENT',4,'SUSPENSION') as status from employ_promotion_dtl t left outer join designation_master d on t.designation_id=d.designation_id where t.emp_code=" & Request.QueryString("emp") & " and  to_date(t.from_dt) between '" & Request.QueryString("f_dt") & "' and '" & Request.QueryString("t_dt") & "'  order by from_dt,status").Tables(0)
        End If
        Dim tb As New Table
        tb.Attributes.Add("width", "100%")
        tb.Attributes.Add("border", "1")

        tb.Attributes.Add("align", "center")

        Dim tr4 As New TableRow
        tr4.BackColor = Drawing.Color.Gold
        Dim tc14 As New TableCell
        tc14.ColumnSpan = 28
        tc14.HorizontalAlign = HorizontalAlign.Center
        'tc14.Text = "<font size=5 color=red><b>MANAPPURAM GROUP OF COMPANIES</b></font>"
        tc14.Text = "<font size=5 color=red><b>" & frm & "</b></font>"
        tr4.Cells.Add(tc14)
        tb.Controls.Add(tr4)
        dt1 = oh.ExecuteDataSet("select emp_name,emp_code from employee_master where emp_code=" & Request.QueryString("emp") & " ").Tables(0)

        Dim tr5 As New TableRow
        tr5.BackColor = Drawing.Color.FloralWhite
        Dim tc15 As New TableCell
        tc15.ColumnSpan = 28
        tc15.HorizontalAlign = HorizontalAlign.Center
        tc15.Text = "<font size=4><b>EMPLOYEE :" & dt1.Rows(0)(0) & "---(" & dt1.Rows(0)(1) & " )</b></font>"
        tr5.Cells.Add(tc15)
        tb.Controls.Add(tr5)


        Dim tr6 As New TableRow
        tr6.BackColor = Drawing.Color.FloralWhite
        Dim tc16 As New TableCell
        tc16.Attributes.Add("width", "50%")
        tc16.ColumnSpan = 17
        tc16.HorizontalAlign = HorizontalAlign.Left
        tc16.BorderWidth = 0
        tc16.Text = "<font size=2 color=darkblue>Date&nbsp:" & Format(Date.Now, "dd/MMM/yyyy") & "</font>"
        tr6.Cells.Add(tc16)


        Dim tc17 As New TableCell
        tc17.Attributes.Add("width", "50%")
        tc17.ColumnSpan = 8
        tc17.BorderWidth = 0
        tc17.HorizontalAlign = HorizontalAlign.Right
        tc17.Text = "<font size=2 color=darkblue>Time&nbsp:" & Format(Date.Now, "hh:mm:ss") & "</font>"
        tr6.Cells.Add(tc17)
        tb.Controls.Add(tr6)


        Dim tr1 As New TableRow
        tr1.BackColor = Drawing.Color.Salmon
        Dim tc1 As New TableCell
        tc1.ColumnSpan = 1
        tc1.HorizontalAlign = HorizontalAlign.Center
        tc1.Text = "<font size=3><b>FROM</b></font>"
        tr1.Cells.Add(tc1)

        Dim tc2 As New TableCell
        tc2.ColumnSpan = 2
        tc2.HorizontalAlign = HorizontalAlign.Center
        tc2.Text = "<font size=3><b>TO</b></font>"
        tr1.Cells.Add(tc2)

        Dim tc3 As New TableCell
        tc3.ColumnSpan = 8
        tc3.HorizontalAlign = HorizontalAlign.Center
        tc3.Text = "<font size=3><b>DESIGNATION</b></font>"
        tr1.Cells.Add(tc3)


        If Session("firm_id") = 28 Then
            Dim tc3a As New TableCell
            tc3a.ColumnSpan = 8
            tc3a.HorizontalAlign = HorizontalAlign.Center
            tc3a.Text = "<font size=3><b>DES. CAT</b></font>"
            tr1.Cells.Add(tc3a)

            Dim tc3b As New TableCell
            tc3b.ColumnSpan = 8
            tc3b.HorizontalAlign = HorizontalAlign.Center
            tc3b.Text = "<font size=3><b>CAT CODE</b></font>"
            tr1.Cells.Add(tc3b)
        End If
        Dim tc4 As New TableCell
        tc4.ColumnSpan = 8
        tc4.HorizontalAlign = HorizontalAlign.Center
        tc4.Text = "<font size=3><b>BASIC PAY</b></font>"
        tr1.Cells.Add(tc4)

        Dim tc5 As New TableCell
        tc5.ColumnSpan = 2
        tc5.HorizontalAlign = HorizontalAlign.Center
        tc5.Text = "<font size=3><b>DAYS</b></font>"
        tr1.Cells.Add(tc5)
        tb.Controls.Add(tr1)
        Dim tc22 As New TableCell
        tc22.ColumnSpan = 1
        tc22.HorizontalAlign = HorizontalAlign.Center
        tc22.Text = "<font size=3><b>STATUS</b></font>"
        tr1.Cells.Add(tc22)
        tb.Controls.Add(tr1)

        Dim dr As DataRow
        Dim color As Integer = 0

        For Each dr In dt.Rows
            Dim tr2 As New TableRow

            If (color = 0) Then
                tr2.BackColor = Drawing.Color.WhiteSmoke
                color = 1
            Else
                tr2.BackColor = Drawing.Color.Snow
                color = 0
            End If
            tr2.Attributes.Add("height", "25px")
            Dim sd1 As Date = CDate(dr(0))
            Dim sd As String = Format(sd1, "dd/MMM/yyyy")
            Dim tc8 As New TableCell
            tc8.ColumnSpan = 1
            tc8.HorizontalAlign = HorizontalAlign.Center
            tc8.Text = "<font size=3><b>" & sd & "</b></font>"
            tc8.ForeColor = Drawing.Color.Black
            tr2.Cells.Add(tc8)
            Dim sd3 As String
            If IsDBNull(dr(1)) Then
                sd3 = "---"
            Else
                Dim sd2 As Date = CDate(dr(1))
                sd3 = Format(sd2, "dd/MMM/yyyy")
            End If


            Dim tc9 As New TableCell
            tc9.ColumnSpan = 2
            tc9.HorizontalAlign = HorizontalAlign.Center
            tc9.Text = "<font size=3><b>" & sd3 & "</b></font>"
            tc9.ForeColor = Drawing.Color.Black
            tr2.Cells.Add(tc9)

            Dim tc10 As New TableCell
            tc10.ColumnSpan = 8
            tc10.HorizontalAlign = HorizontalAlign.Center

            tc10.Text = "<font size=3><b>" & dr(2).ToString().Split("/")(0) & "</b></font>"
            ' tc10.Text = dt.Rows(0)(0)
            tr2.Cells.Add(tc10)

            If Session("firm_id") = 28 Then
                Dim tc10a As New TableCell
                tc10a.ColumnSpan = 8
                tc10a.HorizontalAlign = HorizontalAlign.Center
                tc10a.Text = "<font size=3><b>" & dr(2).ToString().Split("/")(1) & "</b></font>"
                tr2.Cells.Add(tc10a)


                Dim tc10b As New TableCell
                tc10b.ColumnSpan = 8
                tc10b.HorizontalAlign = HorizontalAlign.Center
                tc10b.Text = "<font size=3><b>" & dr(2).ToString().Split("/")(2) & "</b></font>"
                tr2.Cells.Add(tc10b)
            End If

            Dim tc11 As New TableCell
            tc11.ColumnSpan = 8
            tc11.HorizontalAlign = HorizontalAlign.Center
            tc11.Text = "<font size=3><b>" & dr(3) & "</b></font>"
            tr2.Cells.Add(tc11)
            tb.Controls.Add(tr2)
            Dim tc12 As New TableCell
            tc12.ColumnSpan = 2
            tc12.HorizontalAlign = HorizontalAlign.Center
            tc12.Text = "<font size=3><b>" & dr(4) & "</b></font>"
            tr2.Cells.Add(tc12)
            tb.Controls.Add(tr2)
            Dim tc23 As New TableCell
            tc23.ColumnSpan = 1
            tc23.HorizontalAlign = HorizontalAlign.Center
            tc23.Text = "<font size=3><b>" & dr(5) & "</b></font>"
            tr2.Cells.Add(tc23)
            tb.Controls.Add(tr2)
        Next


        Me.Panel1.Controls.Add(tb)
    End Sub
End Class
