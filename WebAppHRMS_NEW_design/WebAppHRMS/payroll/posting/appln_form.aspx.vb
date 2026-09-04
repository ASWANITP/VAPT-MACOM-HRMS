Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class payroll_Posting_appln_form_f58b824f4464
    Inherits System.Web.UI.Page
    Dim report As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oh As New Helper.Oracle.OracleHelper
        Dim dt, dt1, dt2 As New DataTable
        Dim sql, sql1 As String
        'sql = "select a.appln_no,a.appln_name,a.perm_add1,p.post_office,d.district_name,s.state_name,a.pres_add1,p1.post_office,d1.district_name,s1.state_name,a.father_name,a.res_phone,a.cont_phone,a.birth_date,case when a.gender=1 then 'MALE' when a.gender=0 then 'FEMALE' end gender,a.appln_email,case when a.marital_status=1 then 'SINGLE' when a.marital_status=2 then 'MARRIED' end marital,a.spouse_name,a.child_number,b.blood_type from appln_pers_dtl a,bloodgroup_master b,post_master p,post_master p1,district_master d,district_master d1,state_master s,state_master s1 where a.perm_pin=p.sr_number and p.district_id=d.district_id and d.state_id=s.state_id and a.pres_pin=p1.sr_number and p1.district_id=d1.district_id and d1.state_id=s1.state_id and a.blood_id=b.blood_id and a.appln_no=1"
        sql = "select a.appln_no,a.appln_name,a.perm_add1,p.post_office,d.district_name,s.state_name,p.pin_code,a.pres_add1,p1.post_office prepost_office,d1.district_name predistrict_name,s1.state_name prestate_name,p1.pin_code prepin_code,a.father_name,a.res_phone,a.cont_phone,a.birth_date,case when a.gender=1 then 'MALE' when a.gender=0 then 'FEMALE' end gender,a.appln_email,case when a.marital_status=1 then 'SINGLE' when a.marital_status=2 then 'MARRIED' end marital,a.spouse_name,a.child_number,b.blood_type,i.identity_name,a.idproof_number,r.religion,a.caste,a.landmark,a.pp from appln_pers_dtl a,bloodgroup_master b,identity i,religion_master r,post_master p,post_master p1,district_master d,district_master d1,state_master s,state_master s1 where a.perm_pin=p.sr_number and p.district_id=d.district_id and d.state_id=s.state_id and a.pres_pin=p1.sr_number and p1.district_id=d1.district_id and d1.state_id=s1.state_id and a.blood_id=b.blood_id and a.id_proof=i.identity_id and a.religion_id=r.religion_id and a.appln_no=1"
        sql1 = "select a.appln_no,b.qualification,a.institution,a.university,a.percentage,a.year_pass from appln_qualif_dtl a,qualification_master b where a.qualification=b.qualification_id and a.appln_no=1"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        'report.Load(Server.MapPath("appln.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Load(Server.MapPath("appln.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("personal").SetDataSource(dt)
        report.Database.Tables("qualification").SetDataSource(dt1)
        Me.CrystalReportViewer1.ReportSource = report
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Close()
        report.Dispose()
        GC.Collect()
    End Sub
End Class
