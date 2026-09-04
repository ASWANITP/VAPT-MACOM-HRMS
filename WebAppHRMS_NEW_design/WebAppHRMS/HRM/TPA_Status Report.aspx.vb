Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class TPA_Status_Report_983361aa3817
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As DataTable
    Dim aj_report As New ReportDocument
    Dim export As New IO.MemoryStream


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '   dt = oh.ExecuteDataSet("select tp.emp_code,       em.emp_name,  bm.branch_name as Branch,  decode(tp.status,  1,  'Transfer/Promotion Order',  2,  'Appointment Order') as Order_Type,  decode(tp.recv_status,  0,  'Employee Send',  1,  'HO Receive',  2,  'Employee Receive',  3,  'HO Reject') as Receive_Status    from employee_master em, branch_master bm, trans_prom tp,employ_firm ef    where    em.emp_code = tp.emp_code and em.emp_code = ef.emp_code and ef.firm_id = '" & Session("firm_id") & "'  and tp.branch = bm.branch_id").Tables(0)
        dt = oh.ExecuteDataSet("select tp.emp_code,       em.emp_name,  bm.branch_name as Branch,  decode(tp.status,  1,  'Transfer/Promotion Order',  2,  'Appointment Order') as Order_Type,  decode(tp.recv_status,  0,  'Employee Send',  1,  'HO Receive',  2,  'Employee Receive',  3,  'HO Reject') as Receive_Status,   tp.send_date,            decode(tp.recv_status, 1, to_date(sysdate)) as Receive_date    from employee_master em, branch_master bm, trans_prom tp,employ_firm ef    where    em.emp_code = tp.emp_code and em.emp_code = ef.emp_code and ef.firm_id = '" & Session("firm_id") & "'  and tp.branch = bm.branch_id").Tables(0)
        aj_report.Load(Server.MapPath("TPA_Crystal.rpt"), OpenReportMethod.OpenReportByTempCopy)
        aj_report.Database.Tables("TPA").SetDataSource(dt)
        aj_report.SetParameterValue("..BRANCH..", Session("branch_name"))
        aj_report.SetParameterValue("..FIRM..", Session("firm_name"))
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.ReportSource = aj_report


        export = aj_report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/pdf"
        Response.BinaryWrite(export.ToArray())
        Response.End()
        Me.CrystalReportViewer1.DisplayGroupTree = True

        Me.CrystalReportViewer1.ReportSource = aj_report



    End Sub
End Class
