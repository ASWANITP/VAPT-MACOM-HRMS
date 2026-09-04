
Imports System.Data
Imports System.Data.OracleClient
Partial Class transferreport_transfer_display_report_a651d2358109
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim frm = Session("firm_name").ToString
        dt = oh.ExecuteDataSet("select t.from_dt,t.to_dt,b.branch_name,d.dep_name,nvl(t.deputation_id,0),p.post_name,case when to_date(t.to_dt) is null then (to_date(sysdate)-to_date(t.from_dt))+1 else ((to_date(t.to_dt)-to_date(t.from_dt))+1) end  as days from employ_transfer_dtl t,department_mst d,post_mst p,branch_master b where t.emp_code=" & Request.QueryString("emp") & " and t.department_id=d.dep_id and t.post_id=p.post_id and t.branch_id=b.branch_id and  to_date(t.from_dt) between '" & Request.QueryString("f_dt") & "' and '" & Request.QueryString("t_dt") & "' union select t.from_dt,t.to_dt,b.branch_name,d.dep_name,nvl(t.deputation_id,0),p.post_name,case when to_date(t.to_dt) is null then (to_date(sysdate)-to_date(t.from_dt))+1 else ((to_date(t.to_dt)-to_date(t.from_dt))+1) end  as days from employ_transfer_dtl t,department_mst d,post_mst p,before_completion b where t.emp_code=" & Request.QueryString("emp") & " and t.department_id=d.dep_id and t.post_id=p.post_id and t.branch_id=b.old_id and b.branch_id is null and  to_date(t.from_dt) between '" & Request.QueryString("f_dt") & "' and '" & Request.QueryString("t_dt") & "' ").Tables(0)

        Dim tb As New Table
        tb.Attributes.Add("width", "100%")
        tb.Attributes.Add("border", "1")

        tb.Attributes.Add("align", "center")

        Dim tr4 As New TableRow
        tr4.BackColor = Drawing.Color.Gold
        Dim tc14 As New TableCell
        tc14.ColumnSpan = 50
        tc14.HorizontalAlign = HorizontalAlign.Center
        tc14.Text = "<font size=5 color=red><b>" & frm & "</b></font>"
        tr4.Cells.Add(tc14)
        tb.Controls.Add(tr4)
        dt1 = oh.ExecuteDataSet("select emp_name,emp_code from employee_master where emp_code=" & Request.QueryString("emp") & " ").Tables(0)

        Dim tr5 As New TableRow
        tr5.BackColor = Drawing.Color.FloralWhite
        Dim tc15 As New TableCell
        tc15.ColumnSpan = 50
        tc15.HorizontalAlign = HorizontalAlign.Center
        tc15.Text = "<font size=4><b>EMPLOYEE :" & dt1.Rows(0)(0) & "---(" & dt1.Rows(0)(1) & " )</b></font>"
        tr5.Cells.Add(tc15)
        tb.Controls.Add(tr5)


        Dim tr6 As New TableRow
        tr6.BackColor = Drawing.Color.FloralWhite
        Dim tc16 As New TableCell
        tc16.Attributes.Add("width", "50%")
        tc16.ColumnSpan = 25
        tc16.HorizontalAlign = HorizontalAlign.Left
        tc16.BorderWidth = 0
        tc16.Text = "<font size=2 color=darkblue>Date&nbsp:" & Format(Date.Now, "dd/MMM/yyyy") & "</font>"
        tr6.Cells.Add(tc16)


        Dim tc17 As New TableCell
        tc17.Attributes.Add("width", "50%")
        tc17.ColumnSpan = 25
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
        tc3.Text = "<font size=3><b>BRANCH</b></font>"
        tr1.Cells.Add(tc3)

        Dim tc4 As New TableCell
        tc4.ColumnSpan = 8
        tc4.HorizontalAlign = HorizontalAlign.Center
        tc4.Text = "<font size=3><b>DEPARTMENT</b></font>"
        tr1.Cells.Add(tc4)

        Dim tc5 As New TableCell
        tc5.ColumnSpan = 8
        tc5.HorizontalAlign = HorizontalAlign.Center
        tc5.Text = "<font size=3><b>FIRM</b></font>"
        tr1.Cells.Add(tc5)

        Dim tc6 As New TableCell
        tc6.ColumnSpan = 15
        tc6.HorizontalAlign = HorizontalAlign.Center
        tc6.Text = "<font size=3><b>POST</b></font>"
        tr1.Cells.Add(tc6)

        Dim tc7 As New TableCell
        tc7.ColumnSpan = 1
        tc7.HorizontalAlign = HorizontalAlign.Center
        tc7.Text = "<font size=3><b>DAYS</b></font>"
        tr1.Cells.Add(tc7)
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

            tc10.Text = "<font size=3><b>" & dr(2) & "</b></font>"
            ' tc10.Text = dt.Rows(0)(0)
            tr2.Cells.Add(tc10)

            Dim tc11 As New TableCell
            tc11.ColumnSpan = 8
            tc11.HorizontalAlign = HorizontalAlign.Center
            tc11.Text = "<font size=3><b>" & dr(3) & "</b></font>"
            tr2.Cells.Add(tc11)
            tb.Controls.Add(tr2)

            If dr(4) = 0 Then
                dt2 = oh.ExecuteDataSet("select a.firm_abbr from firm_master a,employee_master b where a.firm_id=b.firm_id and b.emp_code=" & Request.QueryString("emp") & "").Tables(0)
            Else
                dt2 = oh.ExecuteDataSet("select firm_abbr from firm_master where firm_id=" & dr(4) & "").Tables(0)
            End If
            
            Dim tc12 As New TableCell
            tc12.ColumnSpan = 8
            tc12.HorizontalAlign = HorizontalAlign.Center
            tc12.Text = "<font size=3><b>" & dt2.Rows(0)(0) & "</b></font>"
            tr2.Cells.Add(tc12)
            tb.Controls.Add(tr2)

            Dim tc13 As New TableCell
            tc13.ColumnSpan = 15
            tc13.HorizontalAlign = HorizontalAlign.Center
            tc13.Text = "<font size=3><b>" & dr(5) & "</b></font>"
            tr2.Cells.Add(tc13)
            tb.Controls.Add(tr2)

            Dim tc21 As New TableCell
            tc21.ColumnSpan = 1
            tc21.HorizontalAlign = HorizontalAlign.Center
            tc21.Text = "<font size=3><b>" & dr(6) & "</b></font>"
            tr2.Cells.Add(tc21)
            tb.Controls.Add(tr2)

           
        Next
        'Dim tr3 As New TableRow
        'tr3.BackColor = Drawing.Color.Cornsilk
        'Dim tc31 As New TableCell
        'tc31.ColumnSpan = 1
        'tc31.HorizontalAlign = HorizontalAlign.Center
        'tc31.Text = "<font size=3><b>TOTAL DAYS=" & coun & " </b></font>"
        'tr3.Cells.Add(tc31)

        'Dim tc32 As New TableCell
        'tc32.ColumnSpan = 2
        'tc32.HorizontalAlign = HorizontalAlign.Center
        'tc32.Text = "<font size=3 color=blue><b>STRENGTH=" & total & "</b></font>"
        'tr3.Cells.Add(tc32)

        'Dim tc33 As New TableCell
        'tc33.ColumnSpan = 1
        'tc33.HorizontalAlign = HorizontalAlign.Center
        'tc33.Text = "<font size=3 color=blue><b>ABSENT=" & absent & "</b></font>"
        'tr3.Cells.Add(tc33)

        'Dim perc As Double
        'perc = absent / total * 100
        'Dim per As String = FormatNumber(perc, 2)
        'Dim tc34 As New TableCell
        'tc34.ColumnSpan = 1
        'tc34.HorizontalAlign = HorizontalAlign.Center
        'tc34.Text = "<font size=3 color=blue><b>PERCENTAGE=" & per & "%</b></font>"
        'tr3.Cells.Add(tc34)

        'tb.Controls.Add(tr3)

        Me.Panel1.Controls.Add(tb)
    End Sub
End Class
