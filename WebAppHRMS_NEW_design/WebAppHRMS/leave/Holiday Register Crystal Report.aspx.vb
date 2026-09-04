Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Partial Class Holiday_Register_Crystal_Report_e42756b61575
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt1 As DataTable
    Dim aj_report As New ReportDocument
    Dim export As New IO.MemoryStream

    Protected Sub Page_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        aj_report.Close()
        aj_report.Dispose()
        GC.Collect()
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim aju As String = Me.Request.QueryString("aji")

        '    dt1 = oh.ExecuteDataSet("select em.emp_name    as Name_of_the_Employee,mw.fat_hus     as Fathers_Husbands_Name, dm.designation as Designation,  mw.basic_pay   as Min_Basic,  mw.vda         as Min_DA,  mw.basic_pay   as Act_Basic,  mw.vda         as Act_DA,  mw.w_days as Tot_attendance,  mw.gross_sal as Gross_wages_payable,  mw.remark_ded as Ded_Emp_Contribution,  mw.oth_ded as Other_Deduction,  mw.tot_dedu as Total_Deduction,  mw.wages_pble as Wages_Paid,  mw.sal_dt as Date_Of_Payment    from employee_master em, m_wage mw, designation_master dm,employ_firm ef,branch_master bm     where    em.emp_code = mw.emp_code and  em.designation_id = dm.designation_id and  em.emp_code = ef.emp_code  and bm.branch_id = em.branch_id and  ef.firm_id = '" & Session("firm_id") & "' and bm.branch_id = '" & Session("branch_id") & "'   order by em.emp_code ").Tables(0)
        dt1 = oh.ExecuteDataSet("select em.emp_name as Emp_Name,  ep.father_name as Father_Name,  la.leave_apply_date as Applied_Date,  la.leave_days as Num_of_Days,  hd.reason_name as Reason_for_Leave,  decode(la.status_id,  1,  'SANCTIONED',  2,  'REJECTED',  3,  'CANCELLED',  4,  'RECOMMEND',  5,  'RECOMMENDED') as Approved_Status,  decode(la.leave_id, 1, 'CASUAL', 2, 'SICK', 3, 'EARNED', 4, 'LOP') as Leave_Type,  la.recom_reason as Remarks  from employee_master          em,  employ_personal_dtl      ep,  hrm_leave_apply_sanction la,  hrm_category_dtl         hd,  hrm_category_master      hc,  employ_firm              ef,branch_master bm    where em.emp_code = la.emp_code  and em.emp_code = ep.emp_code  and em.emp_code = ef.emp_code  and ef.firm_id = '" & Session("firm_id") & "'  and hd.reason_id = la.reason_id  and la.category_id = hd.category_id and bm.branch_id = em.branch_id and bm.branch_id = '" & Session("branch_id") & "'  and hd.category_id = hc.category_id and em.status_id = 1  and em.emp_code = '" & aju & "'").Tables(0)

        aj_report.Load(Server.MapPath("HolidayRegisterCrystal.rpt"), OpenReportMethod.OpenReportByTempCopy)

        Me.CrystalReportViewer1.DisplayGroupTree = False

        aj_report.Database.Tables("Holiday").SetDataSource(dt1)
        Me.CrystalReportViewer1.ReportSource = aj_report


        'export = aj_report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
        'Response.Clear()
        'Response.Buffer = True
        'Response.ContentType = "application/pdf"
        'Response.BinaryWrite(export.ToArray())
        'Response.End()
        Dim exportStream As Stream = aj_report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)

        ' Copy to MemoryStream to make it usable
        Dim export As New MemoryStream()
        exportStream.CopyTo(export)
        export.Position = 0

        ' Send it to the browser
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "inline; filename=report.pdf")
        Response.BinaryWrite(export.ToArray())
        Response.Flush()
        HttpContext.Current.ApplicationInstance.CompleteRequest()

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        aj_report.Close()
        aj_report.Dispose()
        GC.Collect()
    End Sub
End Class
