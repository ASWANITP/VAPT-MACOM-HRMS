Imports System.Data.OracleClient
Imports Org.BouncyCastle.Asn1.Cmp

Public Class Shift_Change_HR_repo
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dtn, dtn1, dt2, dt3, st As New DataTable
    Dim sf(), sf1(), sf2(), app, rec, frm, dm, mode As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            sf = Session("user_id").ToString.Split("!")
            dt3 = oh.ExecuteDataSet("select count(*) from employee_master t where t.emp_code=" & sf(0) & " and t.department_id=546 and t.firm_id=8 and t.status_id=1").Tables(0)
            If dt3.Rows(0)(0) = 0 Then

                Me.Response.Redirect("../../show_err.aspx")
            End If
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'sf = Session("user_id").ToString.Split("!")
        'Response.Redirect("Shift_TL_Report.aspx?&fdt=" & Me.txtFromDate.Value & "&tdt=" & Me.txtToDate.Value & "&emp=" & sf(0))

        ' 2. Collect raw control values
        Dim fromDate As String = txtFromDate.Value
        Dim toDate As String = txtToDate.Value
        Dim empCode As String = txtEmpCode.Value

        If Me.rbAll.Checked Then
            mode = "all"

        ElseIf Me.rbCode.Checked Then
            mode = "code"

        End If

        ' 3. Normalize: convert empty or “All” to Nothing
        If String.IsNullOrWhiteSpace(fromDate) Then fromDate = Nothing
        If String.IsNullOrWhiteSpace(toDate) Then toDate = Nothing
        If empCode = "" Then empCode = Nothing
        If mode = "" Then mode = Nothing

        ' 4. Build a safe, URL-encoded query string
        Dim parms As New List(Of String)
        If fromDate IsNot Nothing Then parms.Add("fdt=" & HttpUtility.UrlEncode(fromDate))
        If toDate IsNot Nothing Then parms.Add("tdt=" & HttpUtility.UrlEncode(toDate))
        If empCode IsNot Nothing Then parms.Add("emp=" & HttpUtility.UrlEncode(empCode))
        If mode IsNot Nothing Then parms.Add("mode=" & HttpUtility.UrlEncode(mode))

        Dim url As String = "Shift_Change_HR_ALLreport.aspx?" & String.Join("&", parms)

        ' 5. Redirect with everything in place
        Response.Redirect(url)
    End Sub
End Class