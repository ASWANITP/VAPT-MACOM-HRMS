Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class rpt_proposalformtransfer_3cbd02bf6247
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim report As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable
        Dim str As String

        Dim sf() As String

        sf = Session("user_id").ToString.Split("!")
        str = "select e.emp_code,e.emp_name,des.designation,post.post_name,substr(br.branch_name,0,15) as branch_abbr,e.join_dt,e.exp,substr(prbr.branch_name,0,15) as pr_branch,e.reason,e.prjoin_dt,e.remark,prpost.post_name as pr_post,q.qualification,e.tfr_no from employ_proposal_order e,designation_master des,post_mst post,post_mst prpost,branch_master br,branch_master prbr,employ_qualification_dtl empq,qualification_master q where e.designation_id=des.designation_id and e.post_id=post.post_id and e.prpost_id=prpost.post_id and e.qualif=empq.emp_code and e.branch_id=br.branch_id and e.pr_branch=prbr.branch_id and empq.year_pass in (select max(year_pass) from employ_qualification_dtl where emp_code=empq.emp_code) and empq.qualification=q.qualification_id and e.user_id=" & sf(0) & " union select e.emp_code,e.emp_name,des.designation,post.post_name,substr(br.branch_name,0,15) as branch_abbr,e.join_dt,e.exp,substr(prbr.branch_name,0,15) as pr_branch,e.reason,e.prjoin_dt,e.remark,prpost.post_name as pr_post,q.qualification,e.tfr_no from employ_proposal_order e,designation_master des,post_mst post,post_mst prpost,before_completion br,branch_master prbr,employ_qualification_dtl empq,qualification_master q where e.designation_id=des.designation_id and e.post_id=post.post_id and e.prpost_id=prpost.post_id and e.qualif=empq.emp_code and e.branch_id=br.old_id and br.branch_id is null and e.pr_branch=prbr.branch_id and empq.year_pass in (select max(year_pass) from employ_qualification_dtl where emp_code=empq.emp_code) and empq.qualification=q.qualification_id and e.user_id=" & sf(0) & " union select e.emp_code,e.emp_name,des.designation,post.post_name,substr(br.branch_name,0,15) as branch_abbr,e.join_dt,e.exp,substr(prbr.branch_name,0,15) as pr_branch,e.reason,e.prjoin_dt,e.remark,prpost.post_name as pr_post,q.qualification,e.tfr_no from employ_proposal_order e,designation_master des,post_mst post,post_mst prpost,branch_master br,before_completion prbr,employ_qualification_dtl empq,qualification_master q where e.designation_id=des.designation_id and e.post_id=post.post_id and e.prpost_id=prpost.post_id and e.qualif=empq.emp_code and e.branch_id=br.branch_id and e.pr_branch=prbr.old_id and prbr.branch_id is null and empq.year_pass in (select max(year_pass) from employ_qualification_dtl where emp_code=empq.emp_code) and empq.qualification=q.qualification_id and e.user_id=" & sf(0) & " union select e.emp_code,e.emp_name,des.designation,post.post_name,substr(br.branch_name,0,15) as branch_abbr,e.join_dt,e.exp,substr(prbr.branch_name,0,15) as pr_branch,e.reason,e.prjoin_dt,e.remark,prpost.post_name as pr_post,q.qualification,e.tfr_no from employ_proposal_order e,designation_master des,post_mst post,post_mst prpost, before_completion br,before_completion prbr,employ_qualification_dtl empq,qualification_master q where e.designation_id=des.designation_id and e.post_id=post.post_id and e.prpost_id=prpost.post_id and e.qualif=empq.emp_code and e.branch_id=br.old_id and br.branch_id is null and e.pr_branch=prbr.old_id and prbr.branch_id is null and empq.year_pass in (select max(year_pass) from employ_qualification_dtl where emp_code=empq.emp_code) and empq.qualification=q.qualification_id and e.user_id=" & sf(0) & ""
        dt = oh.ExecuteDataSet(str).Tables(0)
        report.Load(Server.MapPath("Crptproposaltran.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.SetDataSource(dt)
        Me.CrystalReportViewer1.ReportSource = report
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        GC.Collect()
        Dim sf() As String

        sf = Session("user_id").ToString.Split("!")
        oh.ExecuteNonQuery("delete employ_proposal_order where user_id=" & sf(0) & "")
    End Sub
End Class
