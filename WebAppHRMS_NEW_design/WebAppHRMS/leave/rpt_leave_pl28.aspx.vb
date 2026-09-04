Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine


Partial Class leave_mod_rpt_leave_pl28_096f07a31042
    Inherits System.Web.UI.Page
    Dim report As New ReportDocument
    Dim export As New IO.MemoryStream
    Dim oh As New helper.oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim frdt As Date
        Dim empcode As Integer
        Dim dtq As DataTable = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
        frdt = CDate(dtq.Rows(0)(0))
        empcode = Request.QueryString("empcode")

        Try
            report.Load(Server.MapPath("crpt_leave_pl28.rpt"), OpenReportMethod.OpenReportByTempCopy)

            Dim dt As DataTable = oh.ExecuteDataSet("select emp_name,e.emp_code,l.old_joindt as doj,d.designation,dep.dep_name as department from employee_master e,designation_master d,department_mst dep,emp_new_old_live l where e.emp_code=l.new_code and e.designation_id=d.designation_id and e.department_id=dep.dep_id and e.emp_code=" & empcode).Tables(0)
            report.Database.Tables("DataTable1").SetDataSource(dt)
            Dim dt1 As DataTable = oh.ExecuteDataSet("select leavedays || ' - ' || lower(lreason) || ' - ' || leavetype as reason from(select case when to_char(to_date(el.leave_frdate),'MM/YYYY')=to_char(to_date('" & Format(frdt, "dd/MMM/yyyy") & "'),'MM/YYYY') and to_char(to_date(el.leave_todate),'MM/YYYY')=to_char(to_date('" & Format(frdt, "dd/MMM/yyyy") & "'),'MM/YYYY') then el.leave_days else case when to_date(el.leave_frdate)<to_date('" & Format(frdt, "dd/MMM/yyyy") & "') and to_char(to_date(el.leave_todate),'MM/YYYY')=to_char(to_date('" & Format(frdt, "dd/MMM/yyyy") & "'),'MM/YYYY') then to_date(el.leave_todate)-to_date('" & Format(frdt, "dd/MMM/yyyy") & "')+1 else case when to_date(el.leave_todate)>last_day(to_date('" & Format(frdt, "dd/MMM/yyyy") & "')) and to_char(to_date(el.leave_frdate),'MM/YYYY')=to_char(to_date('" & Format(frdt, "dd/MMM/yyyy") & "'),'MM/YYYY') then last_day(to_date('" & Format(frdt, "dd/MMM/yyyy") & "'))-to_date(el.leave_frdate)+1 end end end as leavedays,el.leave_reason as lreason,decode(el.leave_id,1,'Casual',2,'Sick',3,'Earned',4,'Lop') as leavetype from employ_leave_dtl el where el.emp_code=" & empcode & " and el.leave_process_id not in(0,3)) p where p.leavedays is not null").Tables(0)
            report.Database.Tables("DataTable2").SetDataSource(dt1)
            Dim dt2 As DataTable = oh.ExecuteDataSet("select el.leave_days || ' - ' || lower(el.leave_reason)  || ' - ' ||decode(el.leave_id,1,'Casual',2,'Sick',3,'Earned',4,'Lop')as reasony from employ_leave_dtl el where to_char(to_date(el.leave_frdate),'YYYY') =to_char(to_date('" & Format(frdt, "dd/MMM/yyyy") & "'),'YYYY') and el.emp_code=" & empcode & "  and el.leave_process_id not in(0,3)").Tables(0)
            report.Database.Tables("DataTable3").SetDataSource(dt2)
            Dim dt3 As DataTable = oh.ExecuteDataSet("select sum(leave_days) as leavecount from employ_leave_dtl el where to_char(to_date(el.leave_frdate),'YYYY') =to_char(to_date('" & Format(frdt, "dd/MMM/yyyy") & "'),'YYYY')-1 and el.emp_code=" & empcode & " and el.leave_process_id not in(0,3)").Tables(0)
            report.Database.Tables("DataTable4").SetDataSource(dt3)


            export = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "application/pdf"
            Response.BinaryWrite(export.ToArray())

            Response.End()

            Me.CrystalReportViewer1.ReportSource = export


            ' Me.CrystalReportViewer1.ReportSource = report
        Catch ex As Exception
        End Try


    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        oh.dispose()
        report.Dispose()
        GC.Collect()
    End Sub
End Class
