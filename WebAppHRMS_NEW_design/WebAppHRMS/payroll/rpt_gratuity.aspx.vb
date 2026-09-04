Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class grtuity_rpt_gratuity_625852833458
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper
    Dim report As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("access_id") <> 33 Then
            Server.Transfer("../show_err.aspx")
        End If

        Dim sql As String = ""
        Dim dt As DataTable
        Dim n1, n2, n3 As Date
        Dim r1, r2 As Date
        Dim e1, e2, e3 As Date
        Dim currentdt As DataTable = oh.ExecuteDataSet("select to_char(sysdate,'MM'),to_char(sysdate,'YYYY') from dual").Tables(0)

        If Me.Request.QueryString("report") = 1 Then   'new join'

            If Me.Request.QueryString("firm") = 1 Then
                n1 = Format(CDate("1/aug/" & currentdt.Rows(0)(1) - 1), "dd/MMM/yyyy")
                n2 = Format(CDate("31/jul/" & currentdt.Rows(0)(1)), "dd/MMM/yyyy")
                n3 = Format(CDate("1/aug/" & currentdt.Rows(0)(1)), "dd/MMM/yyyy")
            ElseIf Me.Request.QueryString("firm") = 2 Then
                n1 = Format(CDate("1/apr/" & currentdt.Rows(0)(1) - 1), "dd/MMM/yyyy")
                n2 = Format(CDate("31/mar/" & currentdt.Rows(0)(1)), "dd/MMM/yyyy")
                n3 = Format(CDate("1/apr/" & currentdt.Rows(0)(1)), "dd/MMM/yyyy")
            Else
                n1 = Format(CDate("1/jan/" & currentdt.Rows(0)(1) - 1), "dd/MMM/yyyy")
                n2 = Format(CDate("31/dec/" & currentdt.Rows(0)(1) - 1), "dd/MMM/yyyy")
                n3 = Format(CDate("1/jan/" & currentdt.Rows(0)(1)), "dd/MMM/yyyy")
            End If

            sql = "select e.emp_code,e.emp_name,ep.birth_date as dob,e.join_dt as doj,(e.basic_pay+case when e.da_flag='T' then (select value from da_index where to_dt is null) else 0 end) as salary from employee_master e ,employee_master_dtl em,employ_personal_dtl ep where e.emp_type=1 and e.emp_code=ep.emp_code and e.emp_code>9999 and e.emp_code=em.emp_code and e.firm_id=" & Me.Request.QueryString("firm") & " and e.join_dt>='" & Format(n1, "dd/MMM/yyyy") & "' and e.join_dt<='" & Format(n2, "dd/MMM/yyyy") & "' and (e.status_id in(1,4,6,10) or em.discont_dt >='" & Format(n3, "dd/MMM/yyyy") & "' ) order by e.emp_name"

            dt = oh.ExecuteDataSet(sql).Tables(0)
            report.Load(Server.MapPath("crpt_gratuity_newjoin.rpt"), OpenReportMethod.OpenReportByTempCopy)
            report.SetDataSource(dt)

        ElseIf Me.Request.QueryString("report") = 2 Then  'resigned

            If Me.Request.QueryString("firm") = 1 Then   'magfil
                r1 = Format(CDate("1/aug/" & currentdt.Rows(0)(1) - 1), "dd/MMM/yyyy")
                r2 = Format(CDate("31/jul/" & currentdt.Rows(0)(1)), "dd/MMM/yyyy")
                sql = "select em.insurance_no,e.emp_code,e.emp_name,ep.birth_date as dob,e.join_dt as doj,(e.basic_pay+case when e.da_flag='T' then (select value from da_index where to_dt is null) else 0 end) as salary ,decode(ep.sex,1,'M',0,'F') as sex,case when ((to_char(to_date(e.join_dt),'dd') >=to_char(to_date('1/aug/2008'),'dd')) and (to_char(to_date(e.join_dt),'MM') >=to_char(to_date('1/aug/2008'),'MM'))) then to_date('1/aug/' || (to_char(to_date(e.join_dt),'yyyy')+1)) else  to_date('1/aug/' || (to_char(to_date(e.join_dt),'yyyy'))) end as scheme,em.discont_dt from employee_master e ,employee_master_dtl em ,employ_personal_dtl ep where e.emp_type=1 and e.emp_code=ep.emp_code and e.status_id not in(1,4,6,10,13) and e.emp_code=em.emp_code and e.firm_id=" & Me.Request.QueryString("firm") & " and e.join_dt< '" & Format(r1, "dd/MMM/yyyy") & "' and em.discont_dt >='" & Format(r1, "dd/MMM/yyyy") & "'  and em.discont_dt<='" & Format(r2, "dd/MMM/yyyy") & "'  order by e.emp_name"
            ElseIf Me.Request.QueryString("firm") = 2 Then 'maben
                r1 = Format(CDate("1/apr/" & currentdt.Rows(0)(1) - 1), "dd/MMM/yyyy")
                r2 = Format(CDate("31/mar/" & currentdt.Rows(0)(1)), "dd/MMM/yyyy")
                sql = "select em.insurance_no,e.emp_code,e.emp_name,ep.birth_date as dob,e.join_dt as doj,(e.basic_pay+case when e.da_flag='T' then (select value from da_index where to_dt is null) else 0 end) as salary ,decode(ep.sex,1,'M',0,'F') as sex,case when ((to_char(to_date(e.join_dt),'dd') >=to_char(to_date('1/apr/2008'),'dd')) and (to_char(to_date(e.join_dt),'MM') >=to_char(to_date('1/apr/2008'),'MM'))) then to_date('1/apr/' || (to_char(to_date(e.join_dt),'yyyy')+1)) else  to_date('1/apr/' || (to_char(to_date(e.join_dt),'yyyy'))) end as scheme,em.discont_dt from employee_master e ,employee_master_dtl em ,employ_personal_dtl ep where e.emp_type=1 and e.emp_code=ep.emp_code and e.status_id not in(1,4,6,10,13) and e.emp_code=em.emp_code and e.firm_id=" & Me.Request.QueryString("firm") & " and e.join_dt< '" & Format(r1, "dd/MMM/yyyy") & "' and em.discont_dt >='" & Format(r1, "dd/MMM/yyyy") & "'  and em.discont_dt<='" & Format(r2, "dd/MMM/yyyy") & "'  order by e.emp_name"
            Else 'magro
                r1 = Format(CDate("1/jan/" & currentdt.Rows(0)(1) - 1), "dd/MMM/yyyy")
                r2 = Format(CDate("31/dec/" & currentdt.Rows(0)(1) - 1), "dd/MMM/yyyy")
                sql = "select em.insurance_no,e.emp_code,e.emp_name,ep.birth_date as dob,e.join_dt as doj,(e.basic_pay+case when e.da_flag='T' then (select value from da_index where to_dt is null) else 0 end) as salary ,decode(ep.sex,1,'M',0,'F') as sex,case when ((to_char(to_date(e.join_dt),'dd') >=to_char(to_date('1/jan/2008'),'dd')) and (to_char(to_date(e.join_dt),'MM') >=to_char(to_date('1/jan/2008'),'MM'))) then to_date('1/jan/' || (to_char(to_date(e.join_dt),'yyyy')+1)) else  to_date('1/jan/' || (to_char(to_date(e.join_dt),'yyyy'))) end as scheme,em.discont_dt from employee_master e ,employee_master_dtl em ,employ_personal_dtl ep where e.emp_type=1 and e.emp_code=ep.emp_code and e.status_id not in(1,4,6,10,13) and e.emp_code=em.emp_code and e.firm_id=" & Me.Request.QueryString("firm") & " and e.join_dt< '" & Format(r1, "dd/MMM/yyyy") & "' and em.discont_dt >='" & Format(r1, "dd/MMM/yyyy") & "'  and em.discont_dt<='" & Format(r2, "dd/MMM/yyyy") & "'  order by e.emp_name"
            End If

            dt = oh.ExecuteDataSet(sql).Tables(0)
            report.Load(Server.MapPath("crpt_gratuity_resigned.rpt"), OpenReportMethod.OpenReportByTempCopy)
            report.SetDataSource(dt)

        Else     'live'
            If Me.Request.QueryString("firm") = 1 Then
                r1 = Format(CDate("1/aug/" & currentdt.Rows(0)(1) - 1), "dd/MMM/yyyy")
                r2 = Format(CDate("1/aug/" & currentdt.Rows(0)(1)), "dd/MMM/yyyy")
                sql = "select em.insurance_no,e.emp_code,e.emp_name,ep.birth_date as dob,e.join_dt as doj,(e.basic_pay+case when e.da_flag='T' then (select value from da_index where to_dt is null) else 0 end) as salary ,decode(ep.sex,1,'M',0,'F') as sex,case when ((to_char(to_date(e.join_dt),'dd') >=to_char(to_date('1/aug/2008'),'dd')) and (to_char(to_date(e.join_dt),'MM') >=to_char(to_date('1/aug/2008'),'MM'))) then to_date('1/aug/' || (to_char(to_date(e.join_dt),'yyyy')+1)) else  to_date('1/aug/' || (to_char(to_date(e.join_dt),'yyyy'))) end as scheme from employee_master e ,employee_master_dtl em ,employ_personal_dtl ep where e.emp_type=1 and e.emp_code=ep.emp_code and e.status_id  in(1,4,6,10) and e.emp_code=em.emp_code and e.firm_id=" & Me.Request.QueryString("firm") & " and e.join_dt< '" & Format(r1, "dd/MMM/yyyy") & "' and (e.status_id in(1,6,10) or em.discont_dt>='" & Format(r2, "dd/MMM/yyyy") & "') order by e.emp_name"
            ElseIf Me.Request.QueryString("firm") = 2 Then
                r1 = Format(CDate("1/apr/" & currentdt.Rows(0)(1) - 1), "dd/MMM/yyyy")
                r2 = Format(CDate("1/apr/" & currentdt.Rows(0)(1)), "dd/MMM/yyyy")
                sql = "select em.insurance_no,e.emp_code,e.emp_name,ep.birth_date as dob,e.join_dt as doj,(e.basic_pay+case when e.da_flag='T' then (select value from da_index where to_dt is null) else 0 end) as salary ,decode(ep.sex,1,'M',0,'F') as sex,case when ((to_char(to_date(e.join_dt),'dd') >=to_char(to_date('1/apr/2008'),'dd')) and (to_char(to_date(e.join_dt),'MM') >=to_char(to_date('1/apr/2008'),'MM'))) then to_date('1/apr/' || (to_char(to_date(e.join_dt),'yyyy')+1)) else  to_date('1/apr/' || (to_char(to_date(e.join_dt),'yyyy'))) end as scheme from employee_master e ,employee_master_dtl em ,employ_personal_dtl ep where e.emp_type=1 and e.emp_code=ep.emp_code and e.status_id in(1,4,6,10) and e.emp_code=em.emp_code and e.firm_id=" & Me.Request.QueryString("firm") & " and e.join_dt< '" & Format(r1, "dd/MMM/yyyy") & "' and (e.status_id in(1,6,10) or em.discont_dt>='" & Format(r2, "dd/MMM/yyyy") & "') order by e.emp_name"
            Else
                r1 = Format(CDate("1/jan/" & currentdt.Rows(0)(1) - 1), "dd/MMM/yyyy")
                r2 = Format(CDate("1/jan/" & currentdt.Rows(0)(1)), "dd/MMM/yyyy")
                sql = "select em.insurance_no,e.emp_code,e.emp_name,ep.birth_date as dob,e.join_dt as doj,(e.basic_pay+case when e.da_flag='T' then (select value from da_index where to_dt is null) else 0 end) as salary ,decode(ep.sex,1,'M',0,'F') as sex,case when ((to_char(to_date(e.join_dt),'dd') >=to_char(to_date('1/jan/2008'),'dd')) and (to_char(to_date(e.join_dt),'MM') >=to_char(to_date('1/jan/2008'),'MM'))) then to_date('1/jan/' || (to_char(to_date(e.join_dt),'yyyy')+1)) else  to_date('1/jan/' || (to_char(to_date(e.join_dt),'yyyy'))) end as scheme from employee_master e ,employee_master_dtl em ,employ_personal_dtl ep where e.emp_type=1 and e.emp_code=ep.emp_code and e.status_id in(1,4,6,10) and e.emp_code=em.emp_code and e.firm_id=" & Me.Request.QueryString("firm") & " and e.join_dt< '" & Format(r1, "dd/MMM/yyyy") & "' and (e.status_id in(1,6,10) or em.discont_dt>='" & Format(r2, "dd/MMM/yyyy") & "') order by e.emp_name"
            End If
            dt = oh.ExecuteDataSet(sql).Tables(0)
            report.Load(Server.MapPath("crpt_gratuity_live.rpt"), OpenReportMethod.OpenReportByTempCopy)
            report.SetDataSource(dt)

        End If

        Me.CrystalReportViewer1.ReportSource = report
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        oh.dispose()
        GC.Collect()
    End Sub
End Class
