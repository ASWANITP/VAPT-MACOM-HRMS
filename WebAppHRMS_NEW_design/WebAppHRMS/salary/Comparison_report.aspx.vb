Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Web
Imports Helper.Oracle
Imports OracleInternal
'Imports Oracle.ManagedDataAccess.Client

Public Class Comparison_report
    Inherits System.Web.UI.Page
    Dim oh, oh1 As New Helper.Oracle.OracleHelper
    Dim sql As String
    Dim dt, dt1, dtn, dtn1, dt2, dt3, st As New DataTable
    Dim fromDt, toDt As DateTime
    Dim combined As DataTable


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then

            fromDt = DateTime.ParseExact(Request.QueryString("fdt"), "yyyy-MM", Nothing).Date
            toDt = DateTime.ParseExact(Request.QueryString("tdt"), "yyyy-MM", Nothing).Date

            Dim pFromDate As New OracleParameter("FromDate", OracleType.DateTime) With {.Value = fromDt}
            Dim pToDate As New OracleParameter("ToDate", OracleType.DateTime) With {.Value = toDt}


            Dim ds As DataSet = CallProcedure(fromDt, toDt)

            combined = ds.Tables(0).Clone() ' clone schema of first table
            combined.Merge(ds.Tables(0))
            combined.Merge(ds.Tables(1))
            combined.Merge(ds.Tables(2))


            ' Earnings section
            Dim dtEarnings As New DataTable()
            dtEarnings.Columns.Add("element", GetType(String))
            dtEarnings.Columns.Add("month1_total", GetType(Decimal))
            dtEarnings.Columns.Add("month2_total", GetType(Decimal))
            dtEarnings.Columns.Add("difference", GetType(Decimal))
            dtEarnings.Columns.Add("diff_percent", GetType(Decimal))

            dtEarnings.Rows.Add("Gross Salary",
                    combined.Rows(0)("month1_total"),
                    combined.Rows(0)("month2_total"),
                    combined.Rows(0)("difference"),
                    combined.Rows(0)("diff_percent"))
            dtEarnings.Rows.Add("Allowance & Incentives",
                    combined.Rows(1)("month1_total"),
                    combined.Rows(1)("month2_total"),
                    combined.Rows(1)("difference"),
                    combined.Rows(1)("diff_percent"))
            dtEarnings.Rows.Add("Monthly Bonus",
                    combined.Rows(2)("month1_total"),
                    combined.Rows(2)("month2_total"),
                    combined.Rows(2)("difference"),
                    combined.Rows(2)("diff_percent"))

            dtEarnings.Rows.Add("Total (A)",
                    combined.Rows(3)("month1_total"),
                    combined.Rows(3)("month2_total"),
                    combined.Rows(3)("difference"),
                    combined.Rows(3)("diff_percent"))
            Dim headerRow As DataRow = dtEarnings.NewRow()
            headerRow("element") = "EMPLOYER STATUTORY CONTRIBUTION"
            dtEarnings.Rows.Add(headerRow)

            dtEarnings.Rows.Add("ESI Employer contribution",
        combined.Rows(5)("month1_total"),
        combined.Rows(5)("month2_total"),
        combined.Rows(5)("difference"),
        combined.Rows(5)("diff_percent"))
            '    dtEarnings.Rows.Add("EESI Employer contribution",
            'combined.Rows(5)("month1_total"),
            'combined.Rows(5)("month2_total"),
            'combined.Rows(5)("difference"),
            'combined.Rows(5)("diff_percent"))
            dtEarnings.Rows.Add("PF Employer contribution",
        combined.Rows(7)("month1_total"),
        combined.Rows(7)("month2_total"),
        combined.Rows(7)("difference"),
        combined.Rows(7)("diff_percent"))
            '    dtEarnings.Rows.Add("EPF Employer contribution",
            'combined.Rows(7)("month1_total"),
            'combined.Rows(7)("month2_total"),
            'combined.Rows(7)("difference"),
            'combined.Rows(7)("diff_percent"))
            dtEarnings.Rows.Add("Total (B)",
                    combined.Rows(8)("month1_total"),
                    combined.Rows(8)("month2_total"),
                    combined.Rows(8)("difference"),
                    combined.Rows(8)("diff_percent"))
            dtEarnings.Rows.Add("TOTAL CTC (A+B)",
                    combined.Rows(9)("month1_total"),
                    combined.Rows(9)("month2_total"),
                    combined.Rows(9)("difference"),
                    combined.Rows(9)("diff_percent"))


            ' Deduction section
            Dim dtContrib As New DataTable()
            dtContrib.Columns.Add("element", GetType(String))
            dtContrib.Columns.Add("month1_total", GetType(Decimal))
            dtContrib.Columns.Add("month2_total", GetType(Decimal))
            dtContrib.Columns.Add("difference", GetType(Decimal))
            dtContrib.Columns.Add("diff_percent", GetType(Decimal))
            dtContrib.Rows.Add("RD Deduction",
                    combined.Rows(10)("month1_total"),
                    combined.Rows(10)("month2_total"),
                    combined.Rows(10)("difference"),
                    combined.Rows(10)("diff_percent"))
            dtContrib.Rows.Add("Staff Welfare Fund",
                    combined.Rows(11)("month1_total"),
                    combined.Rows(11)("month2_total"),
                    combined.Rows(11)("difference"),
                    combined.Rows(11)("diff_percent"))
            dtContrib.Rows.Add("Professional Tax",
                    combined.Rows(12)("month1_total"),
                    combined.Rows(12)("month2_total"),
                    combined.Rows(12)("difference"),
                    combined.Rows(12)("diff_percent"))
            dtContrib.Rows.Add("LW Fund",
                    combined.Rows(13)("month1_total"),
                    combined.Rows(13)("month2_total"),
                    combined.Rows(13)("difference"),
                    combined.Rows(13)("diff_percent"))
            dtContrib.Rows.Add("LIC Deductions",
                    combined.Rows(14)("month1_total"),
                    combined.Rows(14)("month2_total"),
                    combined.Rows(14)("difference"),
                    combined.Rows(14)("diff_percent"))
            dtContrib.Rows.Add("Other Deductions",
                    combined.Rows(15)("month1_total"),
                    combined.Rows(15)("month2_total"),
                    combined.Rows(15)("difference"),
                    combined.Rows(15)("diff_percent"))
            dtContrib.Rows.Add("PF Employee Contribution",
                    combined.Rows(6)("month1_total"),
                    combined.Rows(6)("month2_total"),
                    combined.Rows(6)("difference"),
                    combined.Rows(6)("diff_percent"))
            'dtContrib.Rows.Add("EPF Contribution",
            '        combined.Rows(7)("month1_total"),
            '        combined.Rows(7)("month2_total"),
            '        combined.Rows(7)("difference"),
            '        combined.Rows(7)("diff_percent"))
            dtContrib.Rows.Add("ESI Employee Contribution",
                    combined.Rows(4)("month1_total"),
                    combined.Rows(4)("month2_total"),
                    combined.Rows(4)("difference"),
                    combined.Rows(4)("diff_percent"))
            'dtContrib.Rows.Add("EESI Contribution",
            '        combined.Rows(5)("month1_total"),
            '        combined.Rows(5)("month2_total"),
            '        combined.Rows(5)("difference"),
            '        combined.Rows(5)("diff_percent"))
            dtContrib.Rows.Add("GRAND TOTAL",
                    combined.Rows(16)("month1_total"),
                    combined.Rows(16)("month2_total"),
                    combined.Rows(16)("difference"),
                    combined.Rows(16)("diff_percent"))

            ' Gross salary section
            Dim dtGrossal As New DataTable()
            dtGrossal.Columns.Add("element", GetType(String))
            dtGrossal.Columns.Add("month1_total", GetType(Decimal))
            dtGrossal.Columns.Add("month2_total", GetType(Decimal))
            dtGrossal.Columns.Add("difference", GetType(Decimal))
            dtGrossal.Columns.Add("diff_percent", GetType(Decimal))
            dtGrossal.Rows.Add("Basic Pay",
                    combined.Rows(17)("month1_total"),
                    combined.Rows(17)("month2_total"),
                    combined.Rows(17)("difference"),
                    combined.Rows(17)("diff_percent"))
            dtGrossal.Rows.Add("VDA",
                    combined.Rows(18)("month1_total"),
                    combined.Rows(18)("month2_total"),
                    combined.Rows(18)("difference"),
                    combined.Rows(18)("diff_percent"))
            dtGrossal.Rows.Add("OVT Wages",
                    combined.Rows(19)("month1_total"),
                    combined.Rows(19)("month2_total"),
                    combined.Rows(19)("difference"),
                    combined.Rows(19)("diff_percent"))
            dtGrossal.Rows.Add("ARREAR_SAL",
                    combined.Rows(20)("month1_total"),
                    combined.Rows(20)("month2_total"),
                    combined.Rows(20)("difference"),
                    combined.Rows(20)("diff_percent"))
            dtGrossal.Rows.Add("ARREAR_DA",
                    combined.Rows(21)("month1_total"),
                    combined.Rows(21)("month2_total"),
                    combined.Rows(21)("difference"),
                    combined.Rows(21)("diff_percent"))
            dtGrossal.Rows.Add("OTH_ADD",
                    combined.Rows(22)("month1_total"),
                    combined.Rows(22)("month2_total"),
                    combined.Rows(22)("difference"),
                    combined.Rows(22)("diff_percent"))
            dtGrossal.Rows.Add("SPECIAL_BENEFIT",
                    combined.Rows(23)("month1_total"),
                    combined.Rows(23)("month2_total"),
                    combined.Rows(23)("difference"),
                    combined.Rows(23)("diff_percent"))
            dtGrossal.Rows.Add("HIGHER_EDU_AMOUNT",
                    combined.Rows(24)("month1_total"),
                    combined.Rows(24)("month2_total"),
                    combined.Rows(24)("difference"),
                    combined.Rows(24)("diff_percent"))
            dtGrossal.Rows.Add("TOTAL",
                    combined.Rows(25)("month1_total"),
                    combined.Rows(25)("month2_total"),
                    combined.Rows(25)("difference"),
                    combined.Rows(25)("diff_percent"))
            dtGrossal.Rows.Add("LOP AMOUNT",
                    combined.Rows(26)("month1_total"),
                    combined.Rows(26)("month2_total"),
                    combined.Rows(26)("difference"),
                    combined.Rows(26)("diff_percent"))
            dtGrossal.Rows.Add("GRAND TOTAL",
                    combined.Rows(27)("month1_total"),
                    combined.Rows(27)("month2_total"),
                    combined.Rows(27)("difference"),
                    combined.Rows(27)("diff_percent"))

            ' Allowance and incentive breakdown section
            Dim dtAllin As New DataTable()
            dtAllin.Columns.Add("element", GetType(String))
            dtAllin.Columns.Add("month1_total", GetType(Decimal))
            dtAllin.Columns.Add("month2_total", GetType(Decimal))
            dtAllin.Columns.Add("difference", GetType(Decimal))
            dtAllin.Columns.Add("diff_percent", GetType(Decimal))
            dtAllin.Rows.Add("Fixed TA",
                    combined.Rows(28)("month1_total"),
                    combined.Rows(28)("month2_total"),
                    combined.Rows(28)("difference"),
                    combined.Rows(28)("diff_percent"))
            dtAllin.Rows.Add("Actual TA",
                    combined.Rows(29)("month1_total"),
                    combined.Rows(29)("month2_total"),
                    combined.Rows(29)("difference"),
                    combined.Rows(29)("diff_percent"))
            dtAllin.Rows.Add("Outstation",
                    combined.Rows(30)("month1_total"),
                    combined.Rows(30)("month2_total"),
                    combined.Rows(30)("difference"),
                    combined.Rows(30)("diff_percent"))
            dtAllin.Rows.Add("Telephone Allowance",
                    combined.Rows(31)("month1_total"),
                    combined.Rows(31)("month2_total"),
                    combined.Rows(31)("difference"),
                    combined.Rows(31)("diff_percent"))
            dtAllin.Rows.Add("HRA",
                    combined.Rows(32)("month1_total"),
                    combined.Rows(32)("month2_total"),
                    combined.Rows(32)("difference"),
                    combined.Rows(32)("diff_percent"))
            dtAllin.Rows.Add("Hardware TA",
                    combined.Rows(33)("month1_total"),
                    combined.Rows(33)("month2_total"),
                    combined.Rows(33)("difference"),
                    combined.Rows(33)("diff_percent"))
            dtAllin.Rows.Add("Special Allowance AO",
                    combined.Rows(34)("month1_total"),
                    combined.Rows(34)("month2_total"),
                    combined.Rows(34)("difference"),
                    combined.Rows(34)("diff_percent"))
            dtAllin.Rows.Add("Allowance Arrear",
                    combined.Rows(35)("month1_total"),
                    combined.Rows(35)("month2_total"),
                    combined.Rows(35)("difference"),
                    combined.Rows(35)("diff_percent"))
            dtAllin.Rows.Add("Vehicle Fuel Maintenance",
                    combined.Rows(36)("month1_total"),
                    combined.Rows(36)("month2_total"),
                    combined.Rows(36)("difference"),
                    combined.Rows(36)("diff_percent"))
            dtAllin.Rows.Add("Driver Salary Reimbursement",
                    combined.Rows(37)("month1_total"),
                    combined.Rows(37)("month2_total"),
                    combined.Rows(37)("difference"),
                    combined.Rows(37)("diff_percent"))
            dtAllin.Rows.Add("Medical Reimbursement",
                    combined.Rows(38)("month1_total"),
                    combined.Rows(38)("month2_total"),
                    combined.Rows(38)("difference"),
                    combined.Rows(38)("diff_percent"))
            dtAllin.Rows.Add("SODEXO/Food Coupon",
                    combined.Rows(39)("month1_total"),
                    combined.Rows(39)("month2_total"),
                    combined.Rows(39)("difference"),
                    combined.Rows(39)("diff_percent"))
            dtAllin.Rows.Add("Children Education Allowance",
                    combined.Rows(40)("month1_total"),
                    combined.Rows(40)("month2_total"),
                    combined.Rows(40)("difference"),
                    combined.Rows(40)("diff_percent"))
            dtAllin.Rows.Add("Audit Allowance",
                    combined.Rows(41)("month1_total"),
                    combined.Rows(41)("month2_total"),
                    combined.Rows(41)("difference"),
                    combined.Rows(41)("diff_percent"))
            dtAllin.Rows.Add("IT Allowance",
                    combined.Rows(42)("month1_total"),
                    combined.Rows(42)("month2_total"),
                    combined.Rows(42)("difference"),
                    combined.Rows(42)("diff_percent"))
            dtAllin.Rows.Add("City Allowance",
                    combined.Rows(43)("month1_total"),
                    combined.Rows(43)("month2_total"),
                    combined.Rows(43)("difference"),
                    combined.Rows(43)("diff_percent"))
            dtAllin.Rows.Add("Positional Allowance",
                    combined.Rows(44)("month1_total"),
                    combined.Rows(44)("month2_total"),
                    combined.Rows(44)("difference"),
                    combined.Rows(44)("diff_percent"))
            dtAllin.Rows.Add("Referal Incentive",
                    combined.Rows(45)("month1_total"),
                    combined.Rows(45)("month2_total"),
                    combined.Rows(45)("difference"),
                    combined.Rows(45)("diff_percent"))
            dtAllin.Rows.Add("IT Incentive Macom",
                    combined.Rows(46)("month1_total"),
                    combined.Rows(46)("month2_total"),
                    combined.Rows(46)("difference"),
                    combined.Rows(46)("diff_percent"))
            dtAllin.Rows.Add("TOTAL",
                    combined.Rows(47)("month1_total"),
                    combined.Rows(47)("month2_total"),
                    combined.Rows(47)("difference"),
                    combined.Rows(47)("diff_percent"))


            ' employee count section
            Dim dtEmpCount As New DataTable()
            dtEmpCount.Columns.Add("element", GetType(String))
            dtEmpCount.Columns.Add("month1_total", GetType(Decimal))
            dtEmpCount.Columns.Add("month2_total", GetType(Decimal))
            dtEmpCount.Columns.Add("difference", GetType(Decimal))
            dtEmpCount.Columns.Add("diff_percent", GetType(Decimal))
            dtEmpCount.Rows.Add("LIVE",
                    combined.Rows(48)("month1_total"),
                    combined.Rows(48)("month2_total"),
                    combined.Rows(48)("difference"),
                    combined.Rows(48)("diff_percent"))
            dtEmpCount.Rows.Add("RESIGNED",
                    combined.Rows(49)("month1_total"),
                    combined.Rows(49)("month2_total"),
                    combined.Rows(49)("difference"),
                    combined.Rows(49)("diff_percent"))
            dtEmpCount.Rows.Add("SUSPENDED",
                    combined.Rows(50)("month1_total"),
                    combined.Rows(50)("month2_total"),
                    combined.Rows(50)("difference"),
                    combined.Rows(50)("diff_percent"))
            dtEmpCount.Rows.Add("LONG LEAVE",
                    combined.Rows(51)("month1_total"),
                    combined.Rows(51)("month2_total"),
                    combined.Rows(51)("difference"),
                    combined.Rows(51)("diff_percent"))
            dtEmpCount.Rows.Add("MATERNITY",
                    combined.Rows(52)("month1_total"),
                    combined.Rows(52)("month2_total"),
                    combined.Rows(52)("difference"),
                    combined.Rows(52)("diff_percent"))
            dtEmpCount.Rows.Add("TERMINATED",
                    combined.Rows(53)("month1_total"),
                    combined.Rows(53)("month2_total"),
                    combined.Rows(53)("difference"),
                    combined.Rows(53)("diff_percent"))
            dtEmpCount.Rows.Add("TOTAL",
                    combined.Rows(54)("month1_total"),
                    combined.Rows(54)("month2_total"),
                    combined.Rows(54)("difference"),
                    combined.Rows(54)("diff_percent"))

            ' After you have fromDt and toDt
            gvEarnings.Columns(1).HeaderText = fromDt.ToString("MMMM yyyy").ToUpper()   ' e.g. AUGUST 2024
            gvEarnings.Columns(2).HeaderText = toDt.ToString("MMMM yyyy").ToUpper()     ' e.g. SEPTEMBER 2025

            gvContrib.Columns(1).HeaderText = fromDt.ToString("MMMM yyyy").ToUpper()
            gvContrib.Columns(2).HeaderText = toDt.ToString("MMMM yyyy").ToUpper()

            gvGrossal.Columns(1).HeaderText = fromDt.ToString("MMMM yyyy").ToUpper()
            gvGrossal.Columns(2).HeaderText = toDt.ToString("MMMM yyyy").ToUpper()

            gvAllin.Columns(1).HeaderText = fromDt.ToString("MMMM yyyy").ToUpper()
            gvAllin.Columns(2).HeaderText = toDt.ToString("MMMM yyyy").ToUpper()

            gvEmpcount.Columns(1).HeaderText = fromDt.ToString("MMMM yyyy").ToUpper()
            gvEmpcount.Columns(2).HeaderText = toDt.ToString("MMMM yyyy").ToUpper()


            gvEarnings.DataSource = dtEarnings
            gvEarnings.DataBind()

            gvContrib.DataSource = dtContrib
            gvContrib.DataBind()

            gvGrossal.DataSource = dtGrossal
            gvGrossal.DataBind()

            gvAllin.DataSource = dtAllin
            gvAllin.DataBind()

            gvEmpcount.DataSource = dtEmpCount
            gvEmpcount.DataBind()

        End If

    End Sub

    Protected Sub gvEarnings_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Check if this is your special row
            If e.Row.Cells(0).Text = "EMPLOYER STATUTORY CONTRIBUTION" Then
                ' Merge across all 5 columns
                e.Row.Cells(0).ColumnSpan = 5
                e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center
                e.Row.Cells(0).Font.Bold = True
                e.Row.Cells(0).ForeColor = System.Drawing.Color.MidnightBlue
                e.Row.Cells(0).Font.Size = FontUnit.Point(15)
                ' Remove the extra cells so only one big merged cell remains
                For i As Integer = e.Row.Cells.Count - 1 To 1 Step -1
                    e.Row.Cells.RemoveAt(i)
                Next
            End If
        End If
    End Sub



    Private Function CallProcedure(ByVal frmdt As Date, ByVal toddt As Date) As DataSet
        Dim dS As DataSet = New DataSet()

        Try
            oh = New Helper.Oracle.OracleHelper()
            ' Now we need 4 parameters instead of 3
            Dim param() As OracleParameter = New OracleParameter(6) {}

            ' Input parameter 1
            'Dim parameterDate As DateTime = Convert.ToDateTime(txtEffectiveDate.Value)
            param(0) = New OracleParameter("from_Date", OracleType.DateTime)
            param(0).Direction = ParameterDirection.Input
            param(0).Value = frmdt

            'Dim paraDate As DateTime = Convert.ToDateTime(txtEffectiveDate.Value)
            param(1) = New OracleParameter("To_Dates", OracleType.DateTime)
            param(1).Direction = ParameterDirection.Input
            param(1).Value = toddt

            param(2) = New OracleParameter("p_Error_sts", OracleType.Number, 150)
            param(2).Direction = ParameterDirection.Output

            param(3) = New OracleParameter("P_Error_msg", OracleType.VarChar, 500)
            param(3).Direction = ParameterDirection.Output
            ' Output cursor 1
            param(4) = New OracleParameter("wage", OracleType.Cursor)
            param(4).Direction = ParameterDirection.Output

            ' Output cursor 2 (new one)
            param(5) = New OracleParameter("incentive", OracleType.Cursor)
            param(5).Direction = ParameterDirection.Output

            ' Output cursor 3 (new one)
            param(6) = New OracleParameter("employeecount", OracleType.Cursor)
            param(6).Direction = ParameterDirection.Output

            ' Execute procedure
            dS = oh.ExecuteDataSet("SALARY_COMPARISON_MACOM", param)

        Catch ex As Exception
            dS = Nothing
        End Try

        Return dS
    End Function


    Protected Sub BtnLoadReport_Click(sender As Object, e As EventArgs) Handles BtnLoadReport.Click


    End Sub

    Protected Sub gvReport_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvEarnings.PageIndex = e.NewPageIndex
        gvContrib.PageIndex = e.NewPageIndex
        gvGrossal.PageIndex = e.NewPageIndex
        gvAllin.PageIndex = e.NewPageIndex
        gvEmpcount.PageIndex = e.NewPageIndex

        ' Re-bind using the same logic
        BtnLoadReport_Click(Nothing, Nothing)
    End Sub

End Class