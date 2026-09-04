Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class january2009_Division_leave_perc_report_7ac82ed61884
    Inherits System.Web.UI.Page
    Dim report As New ReportDocument
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dt = oh.ExecuteDataSet("select zonal_name,  reg_name,  div_id,  div_name,  area_name,  branch_name,  count(emp_code) as Total,  sum(case  when (m_time is NOT NULL or e_time is NOT NULL) then  1  else  0  end) as present,  sum(case  when (m_time is NULL and e_time is NULL) then  1  else  0  end) as Absent,  sum(case  when (m_time > in_time) then  1  else  0  end) as Late,  sum(case  when (e_time < out_time) then  1  else  0  end) as EarlyGoing,  sum(case  when ((m_time is null or e_time is null) AND  NOT (M_TIME IS NULL AND E_TIME IS NULL)) then  1  else  0  end) as NonMarking  from (select zm.zonal_name, da.*  from attendance_detail da,  zonal_master      zm,  zonal_detail      zd,  employee_master   e,  employ_firm       f,branch_master br  where da.CURR_DATE >= to_date('" & Request.QueryString("fdt") & "')  and da.curr_date <= to_date('" & Request.QueryString("tdt") & "')  and da.shift_id not in (4, 5)  AND da.region_id = zd.region_id  and zd.zonal_id = zm.zonal_id and da.branch_id=br.branch_id and br.firm_id=" & Session("firm_id") & "  and da.EMP_CODE = e.emp_code  and e.emp_code = f.emp_code  and f.firm_id = " & Session("firm_id") & ")  left outer join (select zm.zonal_name,  z.reg_name,  z.div_id,  z.div_name,  z.area_name,  z.branch_name,  count(z.emp_code) as Total,  sum(case  when (z.m_time is NOT NULL or  z.e_time is NOT NULL) then  1  else  0  end) as present,  sum(case  when (z.m_time is NULL and z.e_time is NULL) then  1  else  0  end) as Absent,  sum(case  when (z.m_time > z.in_time) then  1  else  0  end) as Late,  sum(case  when (z.e_time < z.out_time) then  1  else  0  end) as EarlyGoing,  sum(case  when ((z.m_time is null or z.e_time is null) AND  NOT (z.M_TIME IS NULL AND z.E_TIME IS NULL)) then  1  else  0  end) as NonMarking  from attendance_detail z,  zonal_detail      zd,  zonal_master      zm,  employee_master   em,  employ_firm       fm,branch_master bm  where z.CURR_DATE >=  to_date('" & Request.QueryString("fdt") & "')  and z.curr_date <=  to_date('" & Request.QueryString("tdt") & "')  and z.shift_id not in (4, 5)  and z.region_id = zd.region_id  and zd.zonal_id = zm.zonal_id  and z.EMP_CODE = em.emp_code  and em.emp_code = fm.emp_code  and fm.firm_id = " & Session("firm_id") & " and z.branch_id=bm.branch_id and bm.firm_id=" & Session("firm_id") & "  group by zm.zonal_name,  z.reg_name,  z.div_id,  z.div_name,  z.area_name,  z.branch_name)  using (zonal_name, reg_name, div_id, div_name, area_name, branch_name)  group by zonal_name, reg_name, div_id, div_name, area_name, branch_name  order by div_name").Tables(0)

        
        report.Load(Server.MapPath("Division_leave_percentage_report.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.SetDataSource(dt)

        report.setparametervalue("FIRM", session("firm_name"))
        Me.CrystalReportViewer1.ReportSource = report

    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        report.Close()
        GC.Collect()
    End Sub
End Class
