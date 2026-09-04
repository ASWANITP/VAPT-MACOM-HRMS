Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data

Partial Class employeeListReport_emp_area_branch_17e1a42e8433
    Inherits System.Web.UI.Page
    Dim report As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim oh As New Helper.Oracle.OracleHelper
        ' dt = oh.ExecuteDataSet("select b.branch_name,a.emp_code,a.emp_name,to_char(to_date(a.join_dt)) as join_date,decode(a.emp_type,1,'REGULAR',2,'OUTSOURCE','TRAINEE') as type,f.firm_abbr,ds.designation,d.dep_name,p.post_name,case when ep.sex=1 then 'MALE' else 'FEMALE' end as sex,dm.district_name from employee_master a,firm_master f,department_mst d,designation_master ds,branch_master b,post_mst p,employ_personal_dtl ep,post_master pm,district_master dm,area_master am,area_detail ad where a.firm_id=f.firm_id and a.designation_id=ds.designation_id and a.department_id=d.dep_id and a.post_id=p.post_id and a.branch_id=b.branch_id and a.status_id=1 and a.emp_code=ep.emp_code and ep.pres_pin=pm.sr_number and b.district_id=dm.district_id and ad.branch_id=a.branch_id and ad.area_id=" & Request.QueryString("ar") & " group by b.branch_name,a.emp_code,a.emp_name,a.join_dt,a.emp_type,f.firm_abbr,ds.designation,d.dep_name,p.post_name,ep.sex,dm.district_name ").Tables(0)
        dt = oh.ExecuteDataSet("select b.branch_name,  a.emp_code,  a.emp_name,  to_char(to_date(a.join_dt)) as join_date,  decode(a.emp_type, 1, 'REGULAR', 2, 'OUTSOURCE', 'TRAINEE') as type,  f.firm_abbr,  ds.designation,  d.dep_name,  p.post_name,  case  when ep.sex = 1 then  'MALE'  else  'FEMALE'  end as sex,  dm.district_name  from employee_master     a,  employ_firm         ef,  firm_master         f,  department_mst      d,  designation_master  ds,  branch_master       b,  post_mst            p,  employ_personal_dtl ep,  post_master         pm,  district_master     dm,  area_master         am,  area_detail         ad  where a.emp_code = ef.emp_code  and ef.firm_id = f.firm_id  and ef.firm_id = " & Session("firm_id") & "  and a.designation_id = ds.designation_id  and a.department_id = d.dep_id  and a.post_id = p.post_id  and a.branch_id = b.branch_id  and a.status_id = 1  and a.emp_code = ep.emp_code  and ep.pres_pin = pm.sr_number  and b.district_id = dm.district_id  and ad.branch_id = a.branch_id  and ad.area_id = " & Request.QueryString("ar") & "  group by b.branch_name,  a.emp_code,  a.emp_name,  a.join_dt,  a.emp_type,  f.firm_abbr,  ds.designation,  d.dep_name,  p.post_name,  ep.sex,  dm.district_name union  select b.branch_name,  a.emp_code,  a.emp_name,  to_char(to_date(a.join_dt)) as join_date,  decode(a.emp_type, 1, 'REGULAR', 2, 'OUTSOURCE', 'TRAINEE') as type,  f.firm_abbr,  ds.designation,  d.dep_name,  p.post_name,  case  when ep.sex = 1 then  'MALE'  else  'FEMALE'  end as sex,  dm.district_name  from employee_master     a,  employ_firm         ef,  firm_master         f,  department_mst      d,  designation_master  ds,  before_completion   b,  post_mst            p,  employ_personal_dtl ep,  post_master         pm,  district_master     dm,  area_master         am,  area_detail         ad  where a.emp_code = ef.emp_code  and ef.firm_id = f.firm_id  and ef.firm_id = " & Session("firm_id") & "  and a.designation_id = ds.designation_id  and a.department_id = d.dep_id  and a.post_id = p.post_id  and a.branch_id = b.old_id  and b.branch_id is null  and a.status_id = 1  and a.emp_code = ep.emp_code  and ep.pres_pin = pm.sr_number  and b.district_id = dm.district_id  and b.area_id = " & Request.QueryString("ar") & "  group by b.branch_name,  a.emp_code,  a.emp_name,  a.join_dt,  a.emp_type,  f.firm_abbr,  ds.designation,  d.dep_name,  p.post_name,  ep.sex,  dm.district_name").Tables(0)
        report.Load(Server.MapPath("employ_area_branch.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.SetDataSource(dt)
        'report.SetParameterValue("from", Format(CDate(Request.QueryString.Get("fdate")), "dd/MMM/yyyy"))
        ' report.SetParameterValue("to", Format(CDate(Request.QueryString.Get("tdate")), "dd/MMM/yyyy"))
        report.SetParameterValue("rpthd", Request.QueryString("area"))
        ' report.SetParameterValue("brid", Session("branch_id"))
        report.SetParameterValue("brname", Session("branch_name"))
        report.SetParameterValue("Firm", Session("firm_name"))

        CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.ReportSource = report
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        report.Close()
        GC.Collect()
    End Sub
End Class
