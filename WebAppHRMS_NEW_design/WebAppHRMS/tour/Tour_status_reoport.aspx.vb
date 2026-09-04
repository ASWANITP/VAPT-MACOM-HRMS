Imports System.Data
Imports System.Data.OracleClient
Partial Class TOUR_Tour_status_reoport_1aaf31ad3508
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fdt As String
        fdt = Request.QueryString("from_date")

        Dim arr As Array
        arr = fdt.Split("|")

        'create table

        Dim tb As New Table
        tb.Attributes.Add("width", "80%")
        tb.Attributes.Add("align", "left")
        'tb.Attributes.Add("border", "1")
        'create one row and one column for heading "manappuram groups of companies"

        Dim tr As New TableRow
        Dim td As New TableCell
        td.ColumnSpan = 7
        td.HorizontalAlign = HorizontalAlign.Center
        td.Text = "<font size=4><b> MANAPPURAM &nbsp;GROUP&nbsp;OF&nbsp;COMPANIES</font></b>"
        tr.Cells.Add(td)
        tb.Controls.Add(tr)

        Dim tr1 As New TableRow
        Dim td1 As New TableCell
        td1.ColumnSpan = 7
        td1.HorizontalAlign = HorizontalAlign.Center
        td1.Text = "<font size=2><b>Branch id=" & Session("branch_id") & ",&nbsp;Branch&nbsp;Name-&nbsp;" & Session("branch_name") & "</font></b>"
        tr1.Controls.Add(td1)
        tb.Controls.Add(tr1)

        'Heading of the report

        Dim tr2 As New TableRow
        Dim td2 As New TableCell
        td2.ColumnSpan = 7
        td2.HorizontalAlign = HorizontalAlign.Center
        td2.Text = "<font size=2><b>TOUR&nbsp;APPLIED,&nbsp;RECOMMENDED&nbsp;AND&nbsp;CONFIRMED&nbsp;STATUS&nbsp;REPORT&nbsp;FROM&nbsp;" & arr(0) & " &nbspTO&nbsp;" & arr(1) & "</font></b>"
        tr2.Controls.Add(td2)
        tb.Controls.Add(tr2)
        'Print the system date and time

        Dim tr3 As New TableRow
        Dim td30 As New TableCell
        Dim td3 As New TableCell

        td3.ColumnSpan = 4
        td30.ColumnSpan = 3
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
        td5.ColumnSpan = 7
        td5.HorizontalAlign = HorizontalAlign.Center
        td5.Text = "<hr>"
        tr5.Controls.Add(td5)
        tb.Controls.Add(tr5)

        'for subheadings

        Dim tr6 As New TableRow
        Dim td6, td7, td8, td9, td10, td101 As New TableCell
        td6.Text = "<font size=2><b>NAME</b></font>"
        td6.HorizontalAlign = HorizontalAlign.Left
        td6.ColumnSpan = 1
        tr6.Controls.Add(td6)

        td7.Text = "<font size=2><b>TOUR PLACE</b></font>"
        td7.HorizontalAlign = HorizontalAlign.Left
        td7.ColumnSpan = 2
        tr6.Controls.Add(td7)


        td8.Text = "<font size=2><b>DURATION</b></font>"
        td8.HorizontalAlign = HorizontalAlign.Right
        td8.ColumnSpan = 1
        tr6.Controls.Add(td8)

        td9.Text = "<font size=2><b>APPLY_DATE</b></font>"
        td9.HorizontalAlign = HorizontalAlign.Right
        td9.ColumnSpan = 1
        tr6.Controls.Add(td9)

        td10.Text = "<font size=2><b>ADV_AMT</b></font>"
        td10.HorizontalAlign = HorizontalAlign.Center
        td10.ColumnSpan = 1
        tr6.Controls.Add(td10)
        tb.Controls.Add(tr6)

        'td101

        td101.Text = "<font size=2><b>TOUR_STATUS</b></font>"
        td101.HorizontalAlign = HorizontalAlign.Center
        td101.ColumnSpan = 1
        tr6.Controls.Add(td101)
        tb.Controls.Add(tr6)


        'for ruler

        Dim tr7 As New TableRow
        Dim td11 As New TableCell
        td11.ColumnSpan = 7
        td11.HorizontalAlign = HorizontalAlign.Center
        td11.Text = "<hr>"
        tr7.Controls.Add(td11)
        tb.Controls.Add(tr7)


        sql = "select b.emp_name,a.tour_place,nvl((a.to_date-a.from_date),0),a.apply_date,a.advance_rs,c.description from tour_master a,employee_master b,tourstatus_mst c where a.emp_code=b.emp_code and to_date(a.apply_date)>='" & arr(0) & "' and to_date(a.apply_date)<='" & arr(1) & "' and  a.tour_status=c.tour_status order by b.emp_name"
        Dim dt As New DataTable
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow
            Dim tot_no, tot_amt As New Double

            tot_no = 0
            tot_amt = 0

            Dim j As Int16 = 0
            For Each dr In dt.Rows
                Dim tr8 As New TableRow
                Dim td12, td13, td14, td15, td16, TD161, TD161a As New TableCell
                Dim tr5165 As New TableRow

                Dim tr535 As New TableRow
                Dim td535 As New TableCell
                td535.ColumnSpan = 7
                td535.HorizontalAlign = HorizontalAlign.Center
                td535.Text = "<hr>"
                tr535.Controls.Add(td535)



                tb.Controls.Add(tr5165)
                td13.ColumnSpan = 1
                td13.HorizontalAlign = HorizontalAlign.Left
                td13.Text = "<font size=2>" & removespace(dr(0)) & " </font>"
                tr8.Controls.Add(td13)

                td14.ColumnSpan = 2
                td14.HorizontalAlign = HorizontalAlign.Right
                td14.Text = "<font size=2>" & removespace(dr(1)) & " </font>"
                tr8.Controls.Add(td14)

                td15.ColumnSpan = 1
                td15.HorizontalAlign = HorizontalAlign.Right
                td15.Text = "<font size=2>" & FormatNumber(dr(2), 0) & " </font>"
                tr8.Controls.Add(td15)


                td16.ColumnSpan = 1
                td16.HorizontalAlign = HorizontalAlign.Right
                td16.Text = "<font size=2>" & dr(3) & " </font>"
                tr8.Controls.Add(td16)
                tb.Controls.Add(tr8)



                TD161.ColumnSpan = 1
                TD161.HorizontalAlign = HorizontalAlign.Right
                TD161.Text = "<font size=2>" & FormatNumber(dr(4), 2) & " </font>"
                tr8.Controls.Add(TD161)
                tot_amt += dr(4)

                TD161a.ColumnSpan = 1
                TD161a.HorizontalAlign = HorizontalAlign.Right
                TD161a.Text = "<font size=2>" & removespace(dr(5)) & " </font>"
                tr8.Controls.Add(TD161a)
                tb.Controls.Add(tr8)

                tot_no = tot_no + 1

            Next

            Dim tr51c As New TableRow
            Dim td51c As New TableCell
            td51c.ColumnSpan = 7
            td51c.HorizontalAlign = HorizontalAlign.Center
            td51c.Text = "<hr>"
            tr51c.Controls.Add(td51c)
            tb.Controls.Add(tr51c)


            Dim tr512 As New TableRow

            Dim td512 As New TableCell
            td512.ColumnSpan = 1
            td512.HorizontalAlign = HorizontalAlign.Center
            td512.Text = "<font size=2><b>TOTAL</font>"
            tr512.Controls.Add(td512)


            Dim td5121 As New TableCell
            td5121.ColumnSpan = 2
            td5121.HorizontalAlign = HorizontalAlign.Right
            td5121.Text = "<font size=2><b>" & FormatNumber(tot_no, 0) & "</font>"
            tr512.Controls.Add(td5121)


            Dim td51211 As New TableCell
            td51211.ColumnSpan = 3
            td51211.HorizontalAlign = HorizontalAlign.Right
            td51211.Text = "<font size=2><b>" & FormatNumber(tot_amt, 2) & "</font>"
            tr512.Controls.Add(td51211)
            tb.Controls.Add(tr512)


            Dim tr511 As New TableRow
            Dim td511 As New TableCell
            td511.ColumnSpan = 7
            td511.HorizontalAlign = HorizontalAlign.Center
            td511.Text = "<hr>"
            tr511.Controls.Add(td511)
            tb.Controls.Add(tr511)

        End If
        

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
