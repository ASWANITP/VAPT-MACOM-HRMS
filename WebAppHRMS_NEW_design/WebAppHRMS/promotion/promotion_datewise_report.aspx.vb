Imports System.Data
Imports System.Data.OracleClient
Partial Class PROMOTION_promotion_datewise_report_630684374181
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fdt As String
        fdt = Request.QueryString("from_date")

        Dim arr As Array
        arr = fdt.Split("|")

        Dim tb As New Table
        tb.Attributes.Add("width", "80%")
        tb.Attributes.Add("align", "left")

        Dim tr As New TableRow
        Dim td As New TableCell
        td.ColumnSpan = 10
        td.HorizontalAlign = HorizontalAlign.Center
        td.Text = "<font size=4><b> MANAPPURAM &nbsp;GROUP&nbsp;OF&nbsp;COMPANIES</font></b>"
        tr.Cells.Add(td)
        tb.Controls.Add(tr)


        Dim tr1d As New TableRow
        Dim td1d As New TableCell
        td1d.ColumnSpan = 10
        td1d.HorizontalAlign = HorizontalAlign.Center
        td1d.Text = "<font size=3><b>Regd.Office&nbsp;&nbsp;&nbsp;Manappuram&nbsp;House,&nbsp;&nbsp;&nbsp;V/104,&nbsp;&nbsp;&nbsp;Valappad-680576</font></b>"
        tr1d.Controls.Add(td1d)
        tb.Controls.Add(tr1d)

        Dim tr1e As New TableRow
        Dim td1e As New TableCell
        td1e.ColumnSpan = 10
        td1e.HorizontalAlign = HorizontalAlign.Center
        td1e.Text = "<font size=2><b>DEPARTMENT OF HUMAN RESOURCE MANAGEMENT</font></b>"
        tr1e.Controls.Add(td1e)
        tb.Controls.Add(tr1e)


        Dim tr1 As New TableRow
        Dim td1 As New TableCell
        td1.ColumnSpan = 10
        td1.HorizontalAlign = HorizontalAlign.Center
        td1.Text = "<font size=2><b>Branch id=" & Session("branch_id") & ",&nbsp;Branch&nbsp;Name-&nbsp;" & Session("branch_name") & "</font></b>"
        tr1.Controls.Add(td1)
        tb.Controls.Add(tr1)

        'Heading of the report

        Dim tr2 As New TableRow
        Dim td2 As New TableCell
        td2.ColumnSpan = 10
        td2.HorizontalAlign = HorizontalAlign.Center
        td2.Text = "<font size=2><b>EMPLOYEES&nbsp;PROMOTION&nbsp;OR&nbsp;REVERTING&nbsp;REPORT&nbsp;FROM&nbsp;" & arr(0) & " &nbspTO&nbsp;" & arr(1) & "</font></b>"
        tr2.Controls.Add(td2)
        tb.Controls.Add(tr2)
        'Print the system date and time

        Dim tr3 As New TableRow
        Dim td30 As New TableCell
        Dim td3 As New TableCell

        td3.ColumnSpan = 4
        td30.ColumnSpan = 7
        td3.HorizontalAlign = HorizontalAlign.Left
        td3.Text = "<font size=2><b>Date:&nbsp;" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        td30.HorizontalAlign = HorizontalAlign.Right
        td30.Text = "<font size=2><b>Time:&nbsp;" & Format(Date.Now, "hh:mm:ss") & " </font></b>"
        tr3.Controls.Add(td3)
        tr3.Controls.Add(td30)
        tb.Controls.Add(tr3)


        '************RULER FOR LINE AFTER THE HEADING********************************

        Dim tr5 As New TableRow
        Dim td5 As New TableCell
        td5.ColumnSpan = 11
        td5.HorizontalAlign = HorizontalAlign.Center
        td5.Text = "<hr>"
        tr5.Controls.Add(td5)
        tb.Controls.Add(tr5)

        'for subheadings

        Dim tr6 As New TableRow
        Dim td6, td7, td8, td9, td10, td101, td11, td9d, td16a, td101f, td9f As New TableCell
        td6.Text = "<font size=1><b>NAME</b></font>"
        td6.HorizontalAlign = HorizontalAlign.Left
        td6.ColumnSpan = 1
        tr6.Controls.Add(td6)

        td7.Text = "<font size=1><b>ECODE</b></font>"
        td7.HorizontalAlign = HorizontalAlign.Left
        td7.ColumnSpan = 1
        tr6.Controls.Add(td7)

        td11.Text = "<font size=1><b>EFF&nbsp;DT</b></font>"
        td11.HorizontalAlign = HorizontalAlign.Center
        td11.ColumnSpan = 1
        tr6.Controls.Add(td11)


        td8.Text = "<font size=1><b>DES&nbsp;BFR</b></font>"
        td8.HorizontalAlign = HorizontalAlign.Right
        td8.ColumnSpan = 1
        tr6.Controls.Add(td8)

        td9.Text = "<font size=1><b>DES&nbsp;AFTR</b></font>"
        td9.HorizontalAlign = HorizontalAlign.Right
        td9.ColumnSpan = 1
        tr6.Controls.Add(td9)

        td10.Text = "<font size=1><b>BASC&nbsp;BFR</b></font>"
        td10.HorizontalAlign = HorizontalAlign.Center
        td10.ColumnSpan = 1
        tr6.Controls.Add(td10)


        td101.Text = "<font size=1><b>BASIC&nbsp;AFTR</b></font>"
        td101.HorizontalAlign = HorizontalAlign.Center
        td101.ColumnSpan = 1
        tr6.Controls.Add(td101)

        td101f.Text = "<font size=1><b>DIFFER</b></font>"
        td101f.HorizontalAlign = HorizontalAlign.Center
        td101f.ColumnSpan = 1
        tr6.Controls.Add(td101f)

        td9f.Text = "<font size=1><b>TOT&nbsp;SAL(BF)</b></font>"
        td9f.HorizontalAlign = HorizontalAlign.Right
        td9f.ColumnSpan = 1
        tr6.Controls.Add(td9f)

        td9d.Text = "<font size=1><b>TOT&nbsp;SAL(AF)</b></font>"
        td9d.HorizontalAlign = HorizontalAlign.Right
        td9d.ColumnSpan = 1
        tr6.Controls.Add(td9d)

        tb.Controls.Add(tr6)
        

        'for ruler

        Dim tr7 As New TableRow
        Dim td11a As New TableCell
        td11a.ColumnSpan = 11
        td11a.HorizontalAlign = HorizontalAlign.Center
        td11a.Text = "<hr>"
        tr7.Controls.Add(td11a)
        tb.Controls.Add(tr7)

        sql = "select a.emp_code,c.emp_name,a.FROM_DT,nvl(a.BASIC_PAY,0),nvl(b.designation,'NA'),nvl(a.da_flag,'NA'),a.TO_DT,a.designation_id  from employ_promotion_dtl a,designation_master b,employee_master c  where to_dt is null and a.designation_id=b.designation_id and to_date(a.ENTER_DT)>='" & arr(0) & "' and to_date(a.ENTER_DT)<='" & arr(1) & "' and to_date(a.FROM_DT) <> c.JOIN_DT and  a.emp_code=c.emp_code order by a.emp_code,to_date(a.ENTER_DT)"
        Dim dt, dt6, dt7 As New DataTable
        dt = oh.ExecuteDataSet(sql).Tables(0)

        Dim tr5165, tr11 As New TableRow
        
        Dim dr As DataRow
        Dim tot_no, tot_amt, bfrbasic, aftrbasic, gnttot, gnttot1 As New Double
        tot_no = 0
        tot_amt = 0

        Dim totsal As Integer
        Dim totsal1 As Integer
        For Each dr In dt.Rows
            Dim tr8 As New TableRow
            Dim td12, td13, td14, td15, td16, TD161, TD161a, td16b, td16c, td16d, td16e, td16f As New TableCell

            sql = "select nvl(a.basic_pay,0) ,nvl(b.designation,'NA'),a.to_dt,nvl(a.da_flag,'NA'),a.from_dt from employ_promotion_dtl a,designation_master b where a.to_dt in (select max(to_dt) from employ_promotion_dtl where emp_code=" & dr(0) & ") and a.designation_id=b.designation_id and a.status_id in (1,7) and a.designation_id<> " & dr(7) & "and a.emp_code=" & dr(0)
            Dim dt1, dt5 As New DataTable
            dt1 = oh.ExecuteDataSet(sql).Tables(0)

            td13.ColumnSpan = 1
            td13.HorizontalAlign = HorizontalAlign.Left
            td13.Text = "<font size=1>" & removespace(dr(1)) & " </font>"  'ename
            tr8.Controls.Add(td13)

            td14.ColumnSpan = 1
            td14.HorizontalAlign = HorizontalAlign.Right
            td14.Text = "<font size=1>" & dr(0) & " </font>"   'ecode
            tr8.Controls.Add(td14)

            td15.ColumnSpan = 1
            td15.HorizontalAlign = HorizontalAlign.Right
            td15.Text = "<font size=1>" & dr(2) & " </font>"   'effdt
            tr8.Controls.Add(td15)

            TD161.ColumnSpan = 1
            TD161.HorizontalAlign = HorizontalAlign.Right
            If dt1.Rows.Count > 0 Then
                TD161.Text = "<font size=1>" & dt1.Rows(0)(1) & " </font>"  'bfrdesig
            Else
                TD161.Text = "<font size=1>NOT&nbsp;AVAILABLE </font>"
            End If
            tr8.Controls.Add(TD161)
            tb.Controls.Add(tr8)


            td16.ColumnSpan = 1
            td16.HorizontalAlign = HorizontalAlign.Right
            td16.Text = "<font size=1>" & dr(4) & " </font>"    'aftr desig
            tr8.Controls.Add(td16)


            td16b.ColumnSpan = 1
            td16b.HorizontalAlign = HorizontalAlign.Right
            If dt1.Rows.Count > 0 Then
                td16b.Text = "<font size=1>" & dt1.Rows(0)(0) & " </font>"    'bfr basic
            Else
                td16b.Text = "<font size=1>0</font>"
            End If
            tr8.Controls.Add(td16b)
            tb.Controls.Add(tr8)
            If dt1.Rows.Count > 0 Then
                bfrbasic += dt1.Rows(0)(0)
            End If


            td16c.ColumnSpan = 1
            td16c.HorizontalAlign = HorizontalAlign.Right
            td16c.Text = "<font size=1>" & dr(3) & " </font>"       'aftr basic
            tr8.Controls.Add(td16c)
            aftrbasic += dr(3)


            Dim saldiff As Integer
            If dt1.Rows.Count = 0 Then
                saldiff = dr(3)
            Else
                saldiff = dr(3) - dt1.Rows(0)(0)
            End If


            td16d.ColumnSpan = 1
            td16d.HorizontalAlign = HorizontalAlign.Right
            If saldiff < 0 Then
                saldiff = Math.Abs(saldiff)
                td16d.Text = "<font size=1>" & saldiff & "&nbsp;(DEC) </font>"
            Else
                saldiff = saldiff
                td16d.Text = "<font size=1>" & saldiff & "&nbsp;(INC) </font>"
            End If
            tr8.Controls.Add(td16d)

            If dt1.Rows.Count > 0 Then
                sql = "select max(from_dt) from da_index  where to_date(from_dt)<='" & Format(dt1.Rows(0)(4), "dd/MMM/yyyy") & "'"
                dt6 = oh.ExecuteDataSet(sql).Tables(0)
            End If
           
            If dt6.Rows.Count > 0 Then
                sql = "select value,from_dt,to_dt from da_index where to_date(from_dt)='" & Format(dt6.Rows(0)(0), "dd/MMM/yyyy") & "'"
                dt7 = oh.ExecuteDataSet(sql).Tables(0)

            End If


            If dt1.Rows.Count > 0 Then
                If (dt1.Rows(0)(3) = "TRUE" Or dt1.Rows(0)(3) = "true") Then
                    totsal1 = dt1.Rows(0)(0) + dt7.Rows(0)(0)
                End If

            End If

            If dt1.Rows.Count = 0 Then
                totsal1 = 0
            End If


            td16f.ColumnSpan = 1
            td16f.HorizontalAlign = HorizontalAlign.Right
            td16f.Text = "<font size=1>" & totsal1 & " </font>"
            tr8.Controls.Add(td16f)
            gnttot += totsal1


            sql = "select value,from_dt,to_dt from da_index where to_dt is null"
            dt5 = oh.ExecuteDataSet(sql).Tables(0)

            If dr(5) = "TRUE" Then
                totsal = dr(3) + dt5.Rows(0)(0)
            Else
                totsal = dr(3)
            End If

            td16e.ColumnSpan = 1
            td16e.HorizontalAlign = HorizontalAlign.Right
            td16e.Text = "<font size=1>" & totsal & " </font>"
            tr8.Controls.Add(td16e)
            gnttot1 += totsal


            tb.Controls.Add(tr8)
            tot_no = tot_no + 1
        Next
        Dim tr7a As New TableRow
        Dim td133 As New TableCell
        td133.ColumnSpan = 11
        td133.HorizontalAlign = HorizontalAlign.Center
        td133.Text = "<hr>"
        tr7a.Controls.Add(td133)
        tb.Controls.Add(tr7a)


        Dim tr512 As New TableRow

        Dim td512 As New TableCell
        td512.ColumnSpan = 1
        td512.HorizontalAlign = HorizontalAlign.Center
        td512.Text = "<font size=2><b>TOTAL</font>"
        tr512.Controls.Add(td512)


        Dim td5121 As New TableCell
        td5121.ColumnSpan = 2
        td5121.HorizontalAlign = HorizontalAlign.Center
        td5121.Text = "<font size=1><b>" & tot_no & "</font>"
        tr512.Controls.Add(td5121)


        Dim td51211 As New TableCell
        td51211.ColumnSpan = 3
        td51211.HorizontalAlign = HorizontalAlign.Right
        td51211.Text = "<font size=1><b>" & bfrbasic & "</font>"
        tr512.Controls.Add(td51211)


        Dim td51211d As New TableCell
        td51211d.ColumnSpan = 1
        td51211d.HorizontalAlign = HorizontalAlign.Right
        td51211d.Text = "<font size=1><b>" & aftrbasic & "</font>"
        tr512.Controls.Add(td51211d)


        Dim td51211f As New TableCell
        td51211f.ColumnSpan = 2
        td51211f.HorizontalAlign = HorizontalAlign.Right
        td51211f.Text = "<font size=1><b>" & gnttot & "</font>"
        tr512.Controls.Add(td51211f)

        Dim td51211g As New TableCell
        td51211g.ColumnSpan = 2
        td51211g.HorizontalAlign = HorizontalAlign.Right
        td51211g.Text = "<font size=1><b>" & gnttot1 & "</font>"
        tr512.Controls.Add(td51211g)


        tb.Controls.Add(tr512)

        Dim tr511 As New TableRow
        Dim td511 As New TableCell
        td511.ColumnSpan = 11
        td511.HorizontalAlign = HorizontalAlign.Center
        td511.Text = "<hr>"
        tr511.Controls.Add(td511)
        tb.Controls.Add(tr511)


        Me.Panel1.Controls.Add(tb)
    End Sub
    Public Function removespace(ByVal str As String) As String
        Dim str1 As New StringBuilder
        Dim i As Int16
        Dim str0 = str
        Dim split_str As Array
        split_str = str0.ToString.Split(" ")
        Dim st = 0
        Dim j = split_str.Length - 1
        For i = 0 To split_str.Length - 1
            st = 1
            str1.Append(split_str(i))
            If i <> j Then
                str1.Append("&nbsp;")
            End If
        Next
        If st = 0 Then
            Str = str0.ToString
        Else
            Str = str1.ToString
        End If
        Return str
    End Function

End Class
