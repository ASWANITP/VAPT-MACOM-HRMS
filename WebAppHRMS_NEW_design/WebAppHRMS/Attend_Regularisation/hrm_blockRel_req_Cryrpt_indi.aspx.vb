Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Block_Release_Request_hrm_blockRel_req_Cryrpt_indi_e9c3e21c2046
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim crSections As Sections
    Dim report As New ReportDocument
    Dim UserAll(), BranchAll() As String
    Dim UserCode, BranchId As Integer
    Dim dt2 As DataTable
    Dim export As New IO.MemoryStream

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Frdt As String = Request.QueryString.Get("Fdt")
        Dim Todt As String = Request.QueryString.Get("Tdt")
        Dim ecod As String = Request.QueryString.Get("eid")

        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)

        BranchAll = Me.Session("branch_id").ToString.Split("!")
        BranchId = BranchAll(0)

        'If BranchId = 0 Then
        '    dt2 = oh.ExecuteDataSet("select p.req_by as ecode,e.emp_name as ename,b.branch_name as branch,to_char(p.req_dt) as reqdt,bl.block_reason as reqblock,p.req_reson as reqres,decode(p.status,0,'Applied',1,'Sanctioned',2,'Rejected',3,'Cancel',4,'AM Recommended',5,'RM Recommended',6,'RH Recommended') as status ,case when p.am_rec is not null then(select em.emp_code || '_' || em.emp_name from employee_master em where em.emp_code = p.am_rec) else '' end as amreccby,p.am_rec_res as amrecres,to_char(p.am_rec_dt) as amrecdt, case when p.rm_rec is not null then (select em.emp_code || '_' || em.emp_name from employee_master em where em.emp_code = p.rm_rec) else '' end as rmreccby,p.rm_rec_res as rmrecres,to_char(p.rm_rec_dt) as rmrecdt,case when p.rh_rec is not null then (select em.emp_code || '_' || em.emp_name from employee_master em where em.emp_code = p.rh_rec) else '' end as rhreccby,p.rh_rec_res as rhrecres,to_char(p.rh_rec_dt) as rhrecdt,case when p.sant is not null then(select em.emp_code || '_' || em.emp_name from employee_master em where em.emp_code = p.sant) else '' end as sanctby,p.sanct_res as sanres,to_char(p.sanct_dt) as sandt from hrm_punchblock_release_req p, employee_master e,branch_dtl_new b,block_master_1 bl where p.req_by = e.emp_code and e.branch_id = b.branch_id and bl.block_id = p.block_id and p.req_dt between to_date('" & Frdt & "') and to_date('" & Todt & "') order by reqdt").Tables(0)
        'Else
        dt2 = oh.ExecuteDataSet("select p.req_by as ecode,e.emp_name as ename,b.branch_name as branch,to_char(p.req_dt) as reqdt,bl.block_reason as reqblock,p.req_reson as reqres,decode(p.status,0,'Applied',1,'Sanctioned',2,'Rejected',3,'Cancel',4,'AM Recommended',5,'RM Recommended',6,'RH Recommended') as status ,case when p.am_rec is not null then(select em.emp_code || '_' || em.emp_name from employee_master em where em.emp_code = p.am_rec) else '' end as amreccby,p.am_rec_res as amrecres,to_char(p.am_rec_dt) as amrecdt, case when p.rm_rec is not null then (select em.emp_code || '_' || em.emp_name from employee_master em where em.emp_code = p.rm_rec) else '' end as rmreccby,p.rm_rec_res as rmrecres,to_char(p.rm_rec_dt) as rmrecdt,case when p.rh_rec is not null then (select em.emp_code || '_' || em.emp_name from employee_master em where em.emp_code = p.rh_rec) else '' end as rhreccby,p.rh_rec_res as rhrecres,to_char(p.rh_rec_dt) as rhrecdt,case when p.sant is not null then(select em.emp_code || '_' || em.emp_name from employee_master em where em.emp_code = p.sant) else '' end as sanctby,p.sanct_res as sanres,to_char(p.sanct_dt) as sandt from hrm_punchblock_release_req p, employee_master e,branch_dtl_new b,block_master_1 bl where p.req_by = e.emp_code and e.branch_id = b.branch_id and bl.block_id = p.block_id and p.req_dt between to_date('" & Frdt & "') and to_date('" & Todt & "') and p.req_by= " & ecod & " order by reqdt").Tables(0)
        ' End If

        report.Load(Server.MapPath("hrm_blockRel_req_rpt.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("C1").SetDataSource(dt2)
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.ReportSource = report
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        report.Close()
    End Sub
End Class
