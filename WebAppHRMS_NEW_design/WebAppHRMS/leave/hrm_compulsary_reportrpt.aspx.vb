Imports System.Data
Imports System.Data.OracleClient
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Web.UI.WebControls

Public Class hrm_compulsary_reportrpt
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected tb As Table


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            GenerateReport()
        End If
    End Sub

    Private Sub GenerateReport()
        'Dim empId As Integer = Request.QueryString.Get("Ecode")
        Dim fdate As String = Request.QueryString.Get("fdt")
        Dim tdate As String = Request.QueryString.Get("tdt")



        'Dim sql As String = "select t.emp_code, em.emp_name, to_char(t.ldate) as regularise_date, to_char(trunc(t.approved_dt))  as approve_date, case when t.status = 1 then 'COMPULSARY LEAVE' when t.status = 2 then 'LATE' when t.status = 3 then 'EARLY GOING' when t.status = 4 then 'REGULARISE' END as compulsary_type, case when t.t_status=0 then 'Requested' when t.t_status=1 then 'Verified' when t.t_status=2 then 'Rejected' end as status, t.remark from mactech.hrm_attendance_regtemp t, mactech.employee_master em where t.emp_code = em.emp_code and t.ldate between TO_DATE('" & fdate & "') and TO_DATE('" & tdate & "') order by t.ldate desc"
        Dim sql As String = "select t.emp_code, em.emp_name, to_char(t.ldate) as regularise_date, to_char(trunc(t.approved_dt)) as approve_date, case when t.status = 1 then 'COMPULSARY LEAVE' when t.status = 2 then 'LATE' when t.status = 3 then 'EARLY GOING' when t.status = 4 then case when t.m_regn=1 and t.e_regn=1 then 'BOTH-REGULARISE' when t.m_regn=1 then 'MORNING-REGULARISE' when t.e_regn=1 then 'EVENING-REGULARISE' end END as compulsary_type, case when t.t_status = 0 then 'Requested' when t.t_status = 1 then 'Verified' when t.t_status = 2 then 'Rejected' end as status, t.remark from mactech.hrm_attendance_regtemp t, mactech.employee_master em where t.emp_code = em.emp_code and t.ldate between TO_DATE('" & fdate & "') and TO_DATE('" & tdate & "') order by t.ldate desc"
        Dim dt As DataTable = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count = 0 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('No data available');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        End If
        litTitle.Text = "<h2 style='color:#17508A; margin-bottom:10px;'>Employee Regularisation Report</h2>"



        Dim tb As New Table With {.CssClass = "report-table", .Width = Unit.Percentage(100)}

        Dim frm As String = Session("firm_name")
        Dim currentDate As String = Format(Date.Now, "dd/MMM/yyyy")
        Dim currentTime As String = Format(Date.Now, "hh:mm:ss tt")
        Dim head As String = "COMPULSARY LEAVE DETAILS FROM " & Request.QueryString.Get("fdt") & " TO " & Request.QueryString.Get("tdt")
        Dim branchId As String = Session("branch_id")
        Dim branchName As String = Session("branch_name")

        litHeader.Text = "<div style='width:100%; display:flex; justify-content:space-between; align-items:center; font-size:14px; margin-bottom:10px;'>" &
                 "<div><b>" & currentDate & "</b></div>" &
                 "<div style='color:#17508A; text-align:center;'>" &
                 "  <h3 style='margin:0;'><b>" & frm & "</b></h3>" &
                 "  <div><b>Branch ID: " & branchId & " &nbsp;&nbsp; Branch Name: " & branchName & "</b></div>" &
                 "  <div><b>" & head & "</b></div>" &
                 "</div>" &
                 "<div><b>" & currentTime & "</b></div>" &
                 "</div><hr style='border:1px solid #ccc;'>"


        ' Header row
        Dim headerRow As New TableRow()
        Dim headers As String() = {"Emp Code", "Name", "Regularise Date", "Verified Date", "Type", "Status", "Remark"}
        For Each header As String In headers
            Dim th As New TableHeaderCell()
            th.Text = header
            th.Font.Bold = True
            th.BackColor = System.Drawing.ColorTranslator.FromHtml("#17508A")
            th.ForeColor = System.Drawing.Color.White
            th.HorizontalAlign = HorizontalAlign.Left
            headerRow.Cells.Add(th)
        Next
        tb.Rows.Add(headerRow)

        ' Data rows
        For Each row As DataRow In dt.Rows
            Dim tr As New TableRow()

            tr.Cells.Add(New TableCell With {.Text = row("emp_code").ToString(), .HorizontalAlign = HorizontalAlign.Left})
            tr.Cells.Add(New TableCell With {.Text = row("emp_name").ToString(), .HorizontalAlign = HorizontalAlign.Left})
            tr.Cells.Add(New TableCell With {.Text = row("regularise_date").ToString(), .HorizontalAlign = HorizontalAlign.Left})
            tr.Cells.Add(New TableCell With {.Text = row("approve_date").ToString(), .HorizontalAlign = HorizontalAlign.Left})
            tr.Cells.Add(New TableCell With {.Text = row("compulsary_type").ToString(), .HorizontalAlign = HorizontalAlign.Left})
            tr.Cells.Add(New TableCell With {.Text = row("status").ToString(), .HorizontalAlign = HorizontalAlign.Left})
            tr.Cells.Add(New TableCell With {.Text = row("remark").ToString(), .HorizontalAlign = HorizontalAlign.Left})

            tb.Rows.Add(tr)
        Next
        Dim style As New LiteralControl("<style>table, th, td { border: 1px solid black; border-collapse: collapse; }</style>")
        Panel_report.Controls.AddAt(0, style)
        Panel_report.Controls.Add(tb)
    End Sub



    Protected Sub btnExportExcel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=Report.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"


        Dim sw As New System.IO.StringWriter()
        Dim hw As New HtmlTextWriter(sw)


        GenerateReport()

        hw.Write("<style>table, th, td { border: 1px solid black; border-collapse: collapse; }</style>")
        For Each ctrl As Control In Panel_report.Controls
            If TypeOf ctrl Is Table Then
                CType(ctrl, Table).RenderControl(hw)
                Exit For
            End If
        Next


        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.[End]()
    End Sub

End Class