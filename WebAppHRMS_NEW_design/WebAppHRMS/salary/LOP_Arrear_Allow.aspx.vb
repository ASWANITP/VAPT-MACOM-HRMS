Imports system.data

Imports system.data.oracleclient
Partial Class LOP_Arrear_Allow_d62cc7793871
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql, sql1 As String
    Dim dr, dr1 As DataRow
    Dim per, totalper As Double
    Dim totalp = 0, totals = 0
    Dim category As Integer
    Dim cat As String
    Dim color As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")

        dt = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=1811 and s.emp_id=" & sf(0) & "").Tables(0)
        If (dt.Rows(0)(0) = 0) Then
            Server.Transfer("../show_err.aspx")
        End If

        sql = "select t.emp_code, m.emp_name , t.lop_date, am.all_name, sum(t.arrear_amount) from hrm_arrear_lop_mafdn t, incentives_allowances_master am, employee_master m  where t.emp_code=m.emp_code and t.all_id = am.all_id  and t.arrear_status = 1 and t.processed_status = 1  group by t.emp_code,m.emp_name, t.lop_date, am.all_name  order by t.emp_code,t.lop_date"

        dt = oh.ExecuteDataSet(sql).Tables(0)
        Dim tb As New Table
        tb.Attributes.Add("width", "100%")

        If dt.Rows.Count > 0 Then

            Dim trr3 As New TableRow
            Dim tdd31 As New TableCell
            tdd31.Attributes.Add("width", "100%")
            tdd31.ColumnSpan = 100
            tdd31.HorizontalAlign = HorizontalAlign.Center
            tdd31.BackColor = Drawing.Color.BlanchedAlmond
            tdd31.ForeColor = Drawing.Color.Maroon
            tdd31.Text = "<font size=4><b>LOP Arrear on TA Allowance Detail</b></font>"
            trr3.Controls.Add(tdd31)
            tb.Controls.Add(trr3)


            Dim l1 As New TableRow
            Dim ld1 As New TableCell
            ld1.Attributes.Add("width", "100%")
            ld1.ColumnSpan = 80
            ld1.HorizontalAlign = HorizontalAlign.Center
            ld1.Text = "<font size=3><hr size='2' NOSHADE></font>"
            l1.Controls.Add(ld1)
            tb.Controls.Add(l1)

            Dim tr5 As New TableRow

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
            td54.Attributes.Add("width", "7%")
            td54.ColumnSpan = 5
            td54.HorizontalAlign = HorizontalAlign.Left
            td54.Text = "<font size=2.5><b>LOP DATE</b></font>"
            tr5.Controls.Add(td54)

            Dim td55 As New TableCell
            td55.Attributes.Add("width", "25%")
            td55.ColumnSpan = 15
            td55.HorizontalAlign = HorizontalAlign.Left
            td55.Text = "<font size=2.5><b>ALLOWANCE</b></font>"
            tr5.Controls.Add(td55)

            Dim td56 As New TableCell
            td56.Attributes.Add("width", "6%")
            td56.ColumnSpan = 5
            td56.HorizontalAlign = HorizontalAlign.Right
            td56.Text = "<font size=2.5><b>ARREAR AMOUNT</b></font>"
            tr5.Controls.Add(td56)

            tb.Controls.Add(tr5)

            Dim l2 As New TableRow
            Dim ld2 As New TableCell
            ld2.Attributes.Add("width", "100%")
            ld2.ColumnSpan = 80
            ld2.HorizontalAlign = HorizontalAlign.Center
            ld2.Text = "<font size=3><hr size='2' NOSHADE></font>"
            l2.Controls.Add(ld2)
            tb.Controls.Add(l2)

            Dim dept As String = ""
            Dim gtot As Double = 0.0
            Me.Panel_report.Controls.Add(tb)

            For Each dr In dt.Rows
                Dim tr6 As New TableRow
                If (color = 0) Then
                    tr6.BackColor = Drawing.Color.Snow
                    color = 1
                Else
                    tr6.BackColor = Drawing.Color.WhiteSmoke
                    color = 0
                End If


                Dim td62 As New TableCell
                td62.Attributes.Add("width", "7%")
                td62.ColumnSpan = 7
                td62.HorizontalAlign = HorizontalAlign.Center
                td62.Text = "<font size=2>" & dr(0) & "</font>"
                tr6.Controls.Add(td62)

                Dim td63 As New TableCell
                td63.Attributes.Add("width", "15%")
                td63.ColumnSpan = 17
                td63.HorizontalAlign = HorizontalAlign.Left
                td63.Text = "<font size=2>" & dr(1) & "</font>"
                tr6.Controls.Add(td63)

                Dim td61 As New TableCell
                td61.Attributes.Add("width", "7%")
                td61.ColumnSpan = 5
                td61.HorizontalAlign = HorizontalAlign.Left
                td61.Text = "<font size=2>" & Format(dr(2), "dd/MMM/yyyy") & "</font>"
                tr6.Controls.Add(td61)

                Dim td64 As New TableCell
                td64.Attributes.Add("width", "25%")
                td64.ColumnSpan = 15
                td64.HorizontalAlign = HorizontalAlign.Left
                td64.Text = "<font size=2>" & dr(3) & "</font>"
                tr6.Controls.Add(td64)

                Dim td65 As New TableCell
                td65.Attributes.Add("width", "6%")
                td65.ColumnSpan = 5
                td65.HorizontalAlign = HorizontalAlign.Right
                td65.Text = "<font size=2>" & dr(4) & "</font>"
                tr6.Controls.Add(td65)

                gtot = gtot + Convert.ToDouble(dr(4))

                tb.Controls.Add(tr6)

            Next

            Dim l31 As New TableRow
            Dim ld31 As New TableCell
            ld31.Attributes.Add("width", "100%")
            ld31.ColumnSpan = 80
            ld31.HorizontalAlign = HorizontalAlign.Center
            ld31.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
            l31.Controls.Add(ld31)
            tb.Controls.Add(l31)

            Dim l312 As New TableRow
            Dim ld312 As New TableCell
            ld312.Attributes.Add("width", "100%")
            ld312.ColumnSpan = 80
            ld312.HorizontalAlign = HorizontalAlign.Center
            ld312.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
            l312.Controls.Add(ld31)
            tb.Controls.Add(l312)

            'Dim trtot1 As New TableRow
            'Dim tdtot1 As New TableCell
            'tdtot1.Attributes.Add("width", "100%")
            'tdtot1.ColumnSpan = 49
            'tdtot1.HorizontalAlign = HorizontalAlign.Right
            'tdtot1.Text = "<font size=2>" & "Total : " & gtot & "</font>"
            'trtot1.Controls.Add(tdtot1)
            'tb.Controls.Add(trtot1)
        End If

        '-------------------------------------------------------------
        sql = "select t.emp_code, m.emp_name , round(sum(t.arrear_amount),0) ARREAR_AMOUNT from hrm_arrear_lop_mafdn t, incentives_allowances_master am, employee_master m  where t.emp_code=m.emp_code and t.all_id = am.all_id  and t.arrear_status = 1 and t.processed_status = 1  group by t.emp_code,m.emp_name  order by t.emp_code"
        dt.Clear()
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Dim tb2 As New Table

        If dt.Rows.Count > 0 Then

            tb2.Attributes.Add("width", "80%")

            Dim trr31 As New TableRow
            Dim tdd311 As New TableCell

            trr31.BackColor = Drawing.Color.BlanchedAlmond
            tdd311.ForeColor = Drawing.Color.Maroon
            tdd311.Attributes.Add("width", "80%")
            tdd311.ColumnSpan = 80
            tdd311.HorizontalAlign = HorizontalAlign.Center
            tdd311.Text = "<font size=4><b>LOP Arrear on TA Allowance Total</b></font>"
            trr31.Controls.Add(tdd311)
            tb2.Controls.Add(trr31)

            Dim tr52 As New TableRow

            Dim td522 As New TableCell
            td522.Attributes.Add("width", "7%")
            td522.ColumnSpan = 7
            td522.HorizontalAlign = HorizontalAlign.Center
            td522.Text = "<font size=2.5><b>EMPLOYEE CODE</b></font>"
            tr52.Controls.Add(td522)

            Dim td532 As New TableCell
            td532.Attributes.Add("width", "15%")
            td532.ColumnSpan = 17
            td532.HorizontalAlign = HorizontalAlign.Left
            td532.Text = "<font size=2.5><b>EMPLOYEE NAME</b></font>"
            tr52.Controls.Add(td532)


            Dim td542 As New TableCell
            td542.Attributes.Add("width", "7%")
            td542.ColumnSpan = 5
            td542.HorizontalAlign = HorizontalAlign.Left
            td542.Text = "<font size=2.5><b>TOTAL AMOUNT</b></font>"
            tr52.Controls.Add(td542)

            tb2.Controls.Add(tr52)


            Dim tot As Double = 0.0

            For Each dr1 In dt.Rows

                Dim tr61 As New TableRow
                If (color = 0) Then
                    tr61.BackColor = Drawing.Color.Snow
                    color = 1
                Else
                    tr61.BackColor = Drawing.Color.WhiteSmoke
                    color = 0
                End If


                Dim td621 As New TableCell
                td621.Attributes.Add("width", "7%")
                td621.ColumnSpan = 7
                td621.HorizontalAlign = HorizontalAlign.Center
                td621.Text = "<font size=2>" & dr1(0) & "</font>"
                tr61.Controls.Add(td621)

                Dim td631 As New TableCell
                td631.Attributes.Add("width", "15%")
                td631.ColumnSpan = 17
                td631.HorizontalAlign = HorizontalAlign.Left
                td631.Text = "<font size=2>" & dr1(1) & "</font>"
                tr61.Controls.Add(td631)

                Dim td611 As New TableCell
                td611.Attributes.Add("width", "7%")
                td611.ColumnSpan = 5
                td611.HorizontalAlign = HorizontalAlign.Right
                td611.Text = "<font size=2>" & Format(dr1(2), "#####.00") & "</font>"
                tr61.Controls.Add(td611)

                tot = tot + Convert.ToDouble(dr1(2))
                tb2.Controls.Add(tr61)

            Next


            Dim l3 As New TableRow
            Dim ld3 As New TableCell
            ld3.Attributes.Add("width", "100%")
            ld3.ColumnSpan = 80
            ld3.HorizontalAlign = HorizontalAlign.Center
            ld3.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
            l3.Controls.Add(ld3)
            tb2.Controls.Add(l3)

            Dim trtot As New TableRow
            Dim tdtot As New TableCell
            tdtot.Attributes.Add("width", "80%")
            tdtot.ColumnSpan = 29
            tdtot.HorizontalAlign = HorizontalAlign.Right
            tdtot.Text = "<font size=2>" & "Total : " & tot & "</font>"
            trtot.Controls.Add(tdtot)
            tb2.Controls.Add(trtot)

        Else
            Dim trr31 As New TableRow
            Dim tdd311 As New TableCell
            tdd311.Attributes.Add("width", "100%")
            tdd311.ColumnSpan = 100
            tdd311.HorizontalAlign = HorizontalAlign.Center
            'tdd311.BackColor = Drawing.Color.Gold

            tdd311.Text = "<font size=3><b>No Records Found !.</b></font>"
            trr31.Controls.Add(tdd311)
            tb.Controls.Add(trr31)
        End If

        Me.Panel_report.Controls.Add(tb2)
        Me.Panel_report.Controls.Add(tb)

    End Sub
End Class
