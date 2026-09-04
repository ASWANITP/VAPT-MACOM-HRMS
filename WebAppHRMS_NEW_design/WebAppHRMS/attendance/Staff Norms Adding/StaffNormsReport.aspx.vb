Imports System.Data
Imports System.Data.OracleClient
Imports System.Text

Partial Class Staff_Norms_StaffNormsReport_7766fd932226
    Inherits System.Web.UI.Page

    Dim oh As New Helper.Oracle.OracleHelper
    Dim strHTML As New StringBuilder
    Dim UserId As Integer
    Dim form_id As Integer = 8838
    Dim dt, dt1 As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim User() As String = Session("user_id").ToString.Split("!")
        UserId = User(0)
        If Not IsPostBack = True Then

            dt = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=" & form_id & " and emp_id=" & User(0) & "").Tables(0)
            If dt.Rows(0)(0) = 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('You are not authorised!!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Else
                Dim sql As String = "select query from hrm_report_master where firm_id=99 and query_id=173"
                dt1 = oh.ExecuteDataSet(sql).Tables(0)
                Dim _filename As String = ("Staff Norms Report-" + ".doc")
                Dim sr() As String = dt1.Rows(0)(0).ToString.Split("#")
                Dim dr As DataRow

                strHTML.Append("<html><head><style>")
                strHTML.Append("table { border-collapse: collapse; width: 100%; }")
                strHTML.Append("th, td { border: 1px solid #ddd; padding: 8px; text-align: center; }")
                strHTML.Append("th { background-color: #333; color: white; }")
                strHTML.Append("tr:nth-child(even) { background-color: #f9f9f9; }")
                strHTML.Append("</style></head><body>")
                strHTML.Append("<table>")
                strHTML.Append("<tr><th rowspan='2'>Departments</th><th rowspan='2'>Total employee count as per Norms</th><th rowspan='2'>Actual</th><th rowspan='2'>Short</th><th rowspan='2'>Excess</th><th rowspan='2'>Lag Days</th></tr>")
                strHTML.Append("<tr></tr>")

                Dim dts As DataTable
                dts = oh.ExecuteDataSet(sr(1)).Tables(0)
                Dim apar, num As Integer
                apar = dts.Rows.Count - 1
                For Each dr In dts.Rows
                    If num <> apar Then
                        strHTML.Append("<tr><td>" & dr(1) & "</td><td>" & dr(2) & "</td><td>" & dr(3) & "</td><td>" & dr(4) & "</td><td>" & dr(5) & "</td><td>" & dr(6) & "</td></tr>")
                    Else
                        strHTML.Append("<tr><td><b>" & dr(1) & "</td><td><b>" & dr(2) & "</td><td><b>" & dr(3) & "</td><td><b>" & dr(4) & "</td><td><b>" & dr(5) & "</td><td><b>" & dr(6) & "</td></tr>")
                    End If
                    num += 1
                Next
                Response.Write(strHTML.ToString)

            End If
        End If
    End Sub

    Protected Sub btnDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDownload.Click

        '        Dim _filename As String = "Staff_Norms_Report.html"
        '        Response.ClearContent()
        '        Response.ClearHeaders()
        '        Response.ContentType = "text/html"
        '        Response.AddHeader("Content-Disposition", "attachment;filename=" & _filename)
        '        Response.Write(strHTML.ToString)
        '        Response.End()
        Me.Server.Transfer("../../home.aspx")

    End Sub

End Class
