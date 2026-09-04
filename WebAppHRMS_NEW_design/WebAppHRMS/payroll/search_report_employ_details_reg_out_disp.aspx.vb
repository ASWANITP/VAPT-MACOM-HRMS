Imports System.Data
Imports System.Data.OracleClient
Partial Class search_report_employ_details_reg_out_disp_a764d6208532
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tab As New Table
        tab.Attributes.Add("width", "100%")
        tab.Attributes.Add("align", "left")
        tab.Attributes.Add("border", "0")

       

        Dim tr1 As New TableRow
        tr1.Width = 29
        Dim td11 As New TableCell
        td11.Attributes.Add("width", "100%")
        td11.ColumnSpan = 29
        td11.HorizontalAlign = HorizontalAlign.Center
        td11.Text = "<font size=4><b>" & Me.Session("firm_name") & "</b></font>"
        tr1.Controls.Add(td11)
        tab.Controls.Add(tr1)

        Dim tr2 As New TableRow
        tr2.Width = 29
        Dim td21 As New TableCell
        td21.Attributes.Add("width", "100%")
        td21.ColumnSpan = 29
        td21.HorizontalAlign = HorizontalAlign.Center
        td21.Text = "<font size=2><b> " & Me.Session("branch_name") & " </b></font>"
        tr2.Controls.Add(td21)
        tab.Controls.Add(tr2)


        Dim trr As New TableRow
        trr.Width = 29
        Dim tdr1 As New TableCell
        tdr1.Attributes.Add("width", "100%")
        tdr1.Attributes.Add("bgcolor", "lightblue")
        tdr1.ColumnSpan = 29
        tdr1.HorizontalAlign = HorizontalAlign.Center
        tdr1.Text = "<font size=3><b> REGULAR/OUTSORCE EMPLOYEE DETAILS </b></font>"
        trr.Controls.Add(tdr1)
        tab.Controls.Add(trr)

        Dim tr3 As New TableRow
        tr3.Width = 29
        Dim td31, td3m As New TableCell
        td31.Attributes.Add("width", "50%")
        td31.ColumnSpan = 2
        td3m.ColumnSpan = 16
        td31.HorizontalAlign = HorizontalAlign.Left
        td31.Text = "<font size=2><b>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</b></font>"
        tr3.Controls.Add(td31)
        tr3.Controls.Add(td3m)
        Dim td32 As New TableCell
        td32.Attributes.Add("width", "50%")
        td32.ColumnSpan = 11
        td32.HorizontalAlign = HorizontalAlign.Right
        td32.Text = "<font size=2><b>Time :" & Format(Date.Now, "hh:mm:ss tt") & "</b></font>"
        tr3.Controls.Add(td32)
        tab.Controls.Add(tr3)

        Dim lin2 As New TableRow
        lin2.Width = 29
        Dim lin22 As New TableCell
        lin22.ColumnSpan = 29
        lin22.Text = "<hr align=center width=100% >"
        lin2.Controls.Add(lin22)
        tab.Controls.Add(lin2)
        Dim dt23 As DataTable



        If (Request.QueryString("sta") = 0) Then
            If (Request.QueryString("opt") = 1) Then
                dt23 = oh.ExecuteDataSet("select bd.BRANCH_NAME,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(e.join_dt))/30,0) as exp,to_char(e.join_dt) as join_dt,bd.AREA_NAME,bd.DIV_NAME,bd.REG_NAME,bd.zonal_name from employee_master e,employee_master m,employee_master_dtl em,branch_detail bd,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where e.emp_code=em.emp_code and em.new_empcode=m.emp_code and  m.status_id=1 and m.emp_type=1 and e.emp_type=2 and m.branch_id=bd.BRANCH_ID and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and m.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id and round((to_date(sysdate)-to_date(e.join_dt))/30,0)>" & Request.QueryString("exp") & " union select bd.BRANCH_NAME,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(m.join_dt))/30,0) as exp,to_char(m.join_dt) as join_dt,bd.AREA_NAME,bd.DIV_NAME,bd.REG_NAME,bd.zonal_name from employee_master m,branch_detail bd,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where  m.emp_code not in ( select em.new_empcode from employee_master_dtl em where em.discont_dt is not null and em.new_empcode is not null) and  m.status_id=1 and m.emp_type=1 and m.branch_id=bd.BRANCH_ID and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and m.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id and round((to_date(sysdate)-to_date(m.join_dt))/30,0)> " & Request.QueryString("exp") & " union select b.branch_name,m.emp_code,m.emp_name,e.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(e.join_dt))/30,0) as exp,to_char(e.join_dt) as join_dt,am.area_name,dm.div_name,rm.reg_name,zm.zonal_name from employee_master e,employee_master m,employee_master_dtl em,before_completion b,zonal_master zm,region_master rm,division_master dm,area_master am,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q ,employ_firm f where e.emp_code=em.emp_code and em.new_empcode=m.emp_code and  m.status_id=1 and m.emp_type=1 and e.emp_type=2 and m.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and m.branch_id=b.old_id and b.branch_id is null and b.zonal_id=zm.zonal_id and b.region_id=rm.reg_id and b.division_id=dm.division_id and b.area_id=am.area_id and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id and round((to_date(sysdate)-to_date(e.join_dt))/30,0)> " & Request.QueryString("exp") & " union select b.branch_name,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(m.join_dt))/30,0) as exp,to_char(m.join_dt) as join_dt,am.area_name,dm.div_name,rm.reg_name,zm.zonal_name from employee_master m,before_completion b,zonal_master zm,region_master rm,division_master dm,area_master am,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where m.emp_code not in ( select em.new_empcode from employee_master_dtl em where em.discont_dt is not null and em.new_empcode is not null) and  m.status_id=1 and m.emp_type=1 and m.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and m.branch_id=b.old_id and b.branch_id is null and b.zonal_id=zm.zonal_id and b.region_id=rm.reg_id and b.division_id=dm.division_id and b.area_id=am.area_id and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id and round((to_date(sysdate)-to_date(m.join_dt))/30,0)>" & Request.QueryString("exp") & " order by emp_code").Tables(0)
            End If
            If (Request.QueryString("opt") = 2) Then
                dt23 = oh.ExecuteDataSet("select bd.BRANCH_NAME,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(m.join_dt))/30,0) as exp,to_char(m.join_dt) as join_dt,bd.AREA_NAME,bd.DIV_NAME,bd.REG_NAME,bd.zonal_name from employee_master m,branch_detail bd,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where  m.status_id=1 and m.emp_type=2 and m.branch_id=bd.BRANCH_ID and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id and round((to_date(sysdate)-to_date(m.join_dt))/30,0)>" & Request.QueryString("exp") & " union select bm.BRANCH_NAME,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(m.join_dt))/30,0) as exp,to_char(m.join_dt) as join_dt,am.AREA_NAME,dm.DIV_NAME,rm.REG_NAME,zm.zonal_name from employee_master m,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,before_completion bm,zonal_master zm,division_master dm,area_master am,region_master rm,employ_firm f where  m.status_id=1 and m.emp_type=2 and m.branch_id=bm.old_id and bm.branch_id is null and bm.zonal_id=zm.zonal_id and bm.region_id=rm.reg_id and bm.division_id=dm.division_id and bm.area_id=am.area_id and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id and round((to_date(sysdate)-to_date(m.join_dt))/30,0)>" & Request.QueryString("exp") & " order by emp_code").Tables(0)
            End If
            If (Request.QueryString("opt") = 3) Then
                dt23 = oh.ExecuteDataSet("select bd.BRANCH_NAME,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(e.join_dt))/30,0) as exp,to_char(e.join_dt) as join_dt,bd.AREA_NAME,bd.DIV_NAME,bd.REG_NAME,bd.zonal_name from employee_master e,employee_master m,employee_master_dtl em,branch_detail bd,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where e.emp_code=em.emp_code and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and em.new_empcode=m.emp_code and  m.status_id=1 and m.emp_type=1 and e.emp_type=2 and m.branch_id=bd.BRANCH_ID and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id and round((to_date(sysdate)-to_date(e.join_dt))/30,0)>" & Request.QueryString("exp") & " union select bd.BRANCH_NAME,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(m.join_dt))/30,0) as exp,to_char(m.join_dt) as join_dt,bd.AREA_NAME,bd.DIV_NAME,bd.REG_NAME,bd.zonal_name from employee_master m,branch_detail bd,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where  m.emp_code not in ( select em.new_empcode from employee_master_dtl em where em.discont_dt is not null and em.new_empcode is not null) and  m.status_id=1 and m.emp_type=1 and m.branch_id=bd.BRANCH_ID and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id and round((to_date(sysdate)-to_date(m.join_dt))/30,0)> " & Request.QueryString("exp") & " union select b.branch_name,m.emp_code,m.emp_name,e.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(e.join_dt))/30,0) as exp,to_char(e.join_dt) as join_dt,am.area_name,dm.div_name,rm.reg_name,zm.zonal_name from employee_master e,employee_master m,employee_master_dtl em,before_completion b,zonal_master zm,region_master rm,division_master dm,area_master am,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where e.emp_code=em.emp_code and em.new_empcode=m.emp_code and  m.status_id=1 and m.emp_type=1 and e.emp_type=2 and m.branch_id=b.old_id and b.branch_id is null and b.zonal_id=zm.zonal_id and b.region_id=rm.reg_id and b.division_id=dm.division_id and b.area_id=am.area_id and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id and round((to_date(sysdate)-to_date(e.join_dt))/30,0)> " & Request.QueryString("exp") & " union select b.branch_name,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(m.join_dt))/30,0) as exp,to_char(m.join_dt) as join_dt,am.area_name,dm.div_name,rm.reg_name,zm.zonal_name from employee_master m,before_completion b,zonal_master zm,region_master rm,division_master dm,area_master am,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where m.emp_code not in ( select em.new_empcode from employee_master_dtl em where em.discont_dt is not null and em.new_empcode is not null) and  m.status_id=1 and m.emp_type=1 and m.branch_id=b.old_id and b.branch_id is null and b.zonal_id=zm.zonal_id and b.region_id=rm.reg_id and b.division_id=dm.division_id and b.area_id=am.area_id and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id and round((to_date(sysdate)-to_date(m.join_dt))/30,0)>" & Request.QueryString("exp") & " union select bd.BRANCH_NAME,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(m.join_dt))/30,0) as exp,to_char(m.join_dt) as join_dt,bd.AREA_NAME,bd.DIV_NAME,bd.REG_NAME,bd.zonal_name from employee_master m,branch_detail bd,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where  m.status_id=1 and m.emp_type=2 and m.branch_id=bd.BRANCH_ID and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id and round((to_date(sysdate)-to_date(m.join_dt))/30,0)>" & Request.QueryString("exp") & " union select bm.BRANCH_NAME,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(m.join_dt))/30,0) as exp,to_char(m.join_dt) as join_dt,am.AREA_NAME,dm.DIV_NAME,rm.REG_NAME,zm.zonal_name from employee_master m,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,before_completion bm,zonal_master zm,division_master dm,area_master am,region_master rm,employ_firm f where  m.status_id=1 and m.emp_type=2 and m.branch_id=bm.old_id and bm.branch_id is null and bm.zonal_id=zm.zonal_id and bm.region_id=rm.reg_id and bm.division_id=dm.division_id and bm.area_id=am.area_id and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id and round((to_date(sysdate)-to_date(m.join_dt))/30,0)>" & Request.QueryString("exp") & " order by emp_code").Tables(0)
            End If

        End If
        If (Request.QueryString("sta") = 1) Then
            If (Request.QueryString("opt") = 1) Then
                dt23 = oh.ExecuteDataSet("select bd.BRANCH_NAME,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(e.join_dt))/30,0) as exp,to_char(e.join_dt) as join_dt,bd.AREA_NAME,bd.DIV_NAME,bd.REG_NAME,bd.zonal_name from employee_master e,employee_master m,employee_master_dtl em,branch_detail bd,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where e.emp_code=em.emp_code and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and em.new_empcode=m.emp_code and  m.status_id=1 and m.emp_type=1 and e.emp_type=2 and m.branch_id=bd.BRANCH_ID and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id union select bd.BRANCH_NAME,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(m.join_dt))/30,0) as exp,to_char(m.join_dt) as join_dt,bd.AREA_NAME,bd.DIV_NAME,bd.REG_NAME,bd.zonal_name from employee_master m,branch_detail bd,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where  m.emp_code not in ( select em.new_empcode from employee_master_dtl em where em.discont_dt is not null and em.new_empcode is not null) and  m.status_id=1 and m.emp_type=1 and m.branch_id=bd.BRANCH_ID and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id union select b.branch_name,m.emp_code,m.emp_name,e.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(e.join_dt))/30,0) as exp,to_char(e.join_dt) as join_dt,am.area_name,dm.div_name,rm.reg_name,zm.zonal_name from employee_master e,employee_master m,employee_master_dtl em,before_completion b,zonal_master zm,region_master rm,division_master dm,area_master am,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where e.emp_code=em.emp_code and em.new_empcode=m.emp_code and  m.status_id=1 and m.emp_type=1 and e.emp_type=2 and m.branch_id=b.old_id and b.branch_id is null and b.zonal_id=zm.zonal_id and b.region_id=rm.reg_id and b.division_id=dm.division_id and b.area_id=am.area_id and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id union select b.branch_name,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(m.join_dt))/30,0) as exp,to_char(m.join_dt) as join_dt,am.area_name,dm.div_name,rm.reg_name,zm.zonal_name from employee_master m,before_completion b,zonal_master zm,region_master rm,division_master dm,area_master am,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where m.emp_code not in ( select em.new_empcode from employee_master_dtl em where em.discont_dt is not null and em.new_empcode is not null) and  m.status_id=1 and m.emp_type=1 and m.branch_id=b.old_id and b.branch_id is null and b.zonal_id=zm.zonal_id and b.region_id=rm.reg_id and b.division_id=dm.division_id and b.area_id=am.area_id and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id order by emp_code").Tables(0)
            End If
            If (Request.QueryString("opt") = 2) Then
                dt23 = oh.ExecuteDataSet("select bd.BRANCH_NAME,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(m.join_dt))/30,0) as exp,to_char(m.join_dt) as join_dt,bd.AREA_NAME,bd.DIV_NAME,bd.REG_NAME,bd.zonal_name from employee_master m,branch_detail bd,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where  m.status_id=1 and m.emp_type=2 and m.branch_id=bd.BRANCH_ID and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id union select bm.BRANCH_NAME,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(m.join_dt))/30,0) as exp,to_char(m.join_dt) as join_dt,am.AREA_NAME,dm.DIV_NAME,rm.REG_NAME,zm.zonal_name from employee_master m,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,before_completion bm,zonal_master zm,division_master dm,area_master am,region_master rm,employ_firm f where  m.status_id=1 and m.emp_type=2 and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and m.branch_id=bm.old_id and bm.branch_id is null and bm.zonal_id=zm.zonal_id and bm.region_id=rm.reg_id and bm.division_id=dm.division_id and bm.area_id=am.area_id and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id order by emp_code ").Tables(0)
            End If
            If (Request.QueryString("opt") = 3) Then
                dt23 = oh.ExecuteDataSet("select bd.BRANCH_NAME,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(e.join_dt))/30,0) as exp,to_char(e.join_dt) as join_dt,bd.AREA_NAME,bd.DIV_NAME,bd.REG_NAME,bd.zonal_name from employee_master e,employee_master m,employee_master_dtl em,branch_detail bd,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where e.emp_code=em.emp_code and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and em.new_empcode=m.emp_code and  m.status_id=1 and m.emp_type=1 and e.emp_type=2 and m.branch_id=bd.BRANCH_ID and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id union select bd.BRANCH_NAME,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(m.join_dt))/30,0) as exp,to_char(m.join_dt) as join_dt,bd.AREA_NAME,bd.DIV_NAME,bd.REG_NAME,bd.zonal_name from employee_master m,branch_detail bd,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where  m.emp_code not in ( select em.new_empcode from employee_master_dtl em where em.discont_dt is not null and em.new_empcode is not null) and  m.status_id=1 and m.emp_type=1 and m.branch_id=bd.BRANCH_ID and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id union select b.branch_name,m.emp_code,m.emp_name,e.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(e.join_dt))/30,0) as exp,to_char(e.join_dt) as join_dt,am.area_name,dm.div_name,rm.reg_name,zm.zonal_name from employee_master e,employee_master m,employee_master_dtl em,before_completion b,zonal_master zm,region_master rm,division_master dm,area_master am,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where e.emp_code=em.emp_code and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and em.new_empcode=m.emp_code and  m.status_id=1 and m.emp_type=1 and e.emp_type=2 and m.branch_id=b.old_id and b.branch_id is null and b.zonal_id=zm.zonal_id and b.region_id=rm.reg_id and b.division_id=dm.division_id and b.area_id=am.area_id and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id union select b.branch_name,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(m.join_dt))/30,0) as exp,to_char(m.join_dt) as join_dt,am.area_name,dm.div_name,rm.reg_name,zm.zonal_name from employee_master m,before_completion b,zonal_master zm,region_master rm,division_master dm,area_master am,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where m.emp_code not in ( select em.new_empcode from employee_master_dtl em where em.discont_dt is not null and em.new_empcode is not null) and  m.status_id=1 and m.emp_type=1 and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and m.branch_id=b.old_id and b.branch_id is null and b.zonal_id=zm.zonal_id and b.region_id=rm.reg_id and b.division_id=dm.division_id and b.area_id=am.area_id and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id union select bd.BRANCH_NAME,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(m.join_dt))/30,0) as exp,to_char(m.join_dt) as join_dt,bd.AREA_NAME,bd.DIV_NAME,bd.REG_NAME,bd.zonal_name from employee_master m,branch_detail bd,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,employ_firm f where  m.status_id=1 and m.emp_type=2 and m.branch_id=bd.BRANCH_ID and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id union select bm.BRANCH_NAME,m.emp_code,m.emp_name,m.basic_pay,dp.dep_name,ds.designation,p.post_name,q.qualification,to_char(qm.year_pass),round((to_date(sysdate)-to_date(m.join_dt))/30,0) as exp,to_char(m.join_dt) as join_dt,am.AREA_NAME,dm.DIV_NAME,rm.REG_NAME,zm.zonal_name from employee_master m,department_mst dp,designation_master ds,post_mst p,employ_qualification_dtl qm,qualification_master q,before_completion bm,zonal_master zm,division_master dm,area_master am,region_master rm,employ_firm f where  m.status_id=1 and m.emp_type=2 and m.emp_code = f.emp_code and f.firm_id = " & Session("firm_id") & " and m.branch_id=bm.old_id and bm.branch_id is null and bm.zonal_id=zm.zonal_id and bm.region_id=rm.reg_id and bm.division_id=dm.division_id and bm.area_id=am.area_id and m.designation_id=ds.designation_id and m.department_id=dp.dep_id and m.post_id=p.post_id and m.emp_code=qm.emp_code and qm.year_pass in (select max(j.year_pass) from employ_qualification_dtl j where m.emp_code=j.emp_code) and qm.qualification=q.qualification_id order by emp_code").Tables(0)
            End If

        End If
        Dim trr2 As New TableRow
        trr2.Width = 29
        Dim tdr2 As New TableCell
        tdr2.Attributes.Add("width", "100%")
        tdr2.Attributes.Add("bgcolor", "snow")
        tdr2.ColumnSpan = 29
        tdr2.HorizontalAlign = HorizontalAlign.Center
        tdr2.Text = "<font size=3 color=red><b> DETAILS  </b></font>"
        trr2.Controls.Add(tdr2)
        tab.Controls.Add(trr2)

        Dim lin2101 As New TableRow
        lin2101.Width = 29
        Dim lin21011 As New TableCell
        lin21011.ColumnSpan = 29
        lin21011.Text = "<hr align=center width=100% >"
        lin2101.Controls.Add(lin21011)
        tab.Controls.Add(lin2101)

        Dim ta5 As New TableRow
        Dim ta51, ta52, ta53, ta70, ta71, ta72, ta73, ta74, ta75, ta54, ta60, ta61, ta62, ta64, ta551, ta55, ta56, ta63 As New TableCell
        ta62.Attributes.Add("width", "5%")
        ta52.Attributes.Add("width", "5%")

        ta52.ColumnSpan = 2
        ta53.ColumnSpan = 2
        ta54.ColumnSpan = 2
        ta55.ColumnSpan = 1
        ta56.ColumnSpan = 2
        ta70.ColumnSpan = 2
        ta60.ColumnSpan = 1
        ta61.ColumnSpan = 2
        ta62.ColumnSpan = 2
        ta63.ColumnSpan = 2
        ta71.ColumnSpan = 1
        ta72.ColumnSpan = 2
        ta73.ColumnSpan = 2
        ta74.ColumnSpan = 2
        ta75.ColumnSpan = 2
        ta60.Text = "<font size=2><b>BRANCH&nbsp;</b></font>"
        ta52.Text = "<font size=2><b>CODE</b></font>"
        ta53.Text = "<font size=2><b>EMPLOY&nbsp;NAME</b></font>"
        ta54.Text = "<font size=2><b>BASIC&nbsp;PAY</b></font>"
        ta70.Text = "<font size=2><b>DEPARTMENT</b></font>"
        ta61.Text = "<font size=2><b>DESIGNATION</b></font>"
        ta62.Text = "<font size=2><b>POST</b></font>"
        ta63.Text = "<font size=2><b>QUALIFICATION</b></font>"
        ta55.Text = "<font size=2><b>YEAR&nbsp;OF&nbsp;PASS</b></font>"
        ta71.Text = "<font size=2><b>EXPERIENCE</b></font>"
        ta56.Text = "<font size=2><b>&nbsp;JOIN&nbsp;DATE</b></font>"
        ta72.Text = "<font size=2><b>AREA&nbsp;NAME</b></font>"
        ta73.Text = "<font size=2><b>DIVISION&nbsp;NAME</b></font>"
        ta74.Text = "<font size=2><b>REGION&nbsp;NAME</b></font>"
        ta75.Text = "<font size=2><b>ZONAL&nbsp;NAME</b></font>"
        ta52.HorizontalAlign = HorizontalAlign.Center
        ta53.HorizontalAlign = HorizontalAlign.Center
        ta54.HorizontalAlign = HorizontalAlign.Center
        ta55.HorizontalAlign = HorizontalAlign.Center
        ta551.HorizontalAlign = HorizontalAlign.Center
        ta56.HorizontalAlign = HorizontalAlign.Center
        ta70.HorizontalAlign = HorizontalAlign.Center
        ta71.HorizontalAlign = HorizontalAlign.Center
        ta60.HorizontalAlign = HorizontalAlign.Center
        ta61.HorizontalAlign = HorizontalAlign.Center
        ta62.HorizontalAlign = HorizontalAlign.Center
        ta63.HorizontalAlign = HorizontalAlign.Center
        ta72.HorizontalAlign = HorizontalAlign.Center
        ta73.HorizontalAlign = HorizontalAlign.Center
        ta74.HorizontalAlign = HorizontalAlign.Center
        ta75.HorizontalAlign = HorizontalAlign.Center


        ''
        ta5.Controls.Add(ta60)
        ta5.Controls.Add(ta52)
        ta5.Controls.Add(ta53)
        ta5.Controls.Add(ta54)
        ta5.Controls.Add(ta70)
        ta5.Controls.Add(ta61)
        ta5.Controls.Add(ta62)
        ta5.Controls.Add(ta63)
        ta5.Controls.Add(ta55)
        ta5.Controls.Add(ta71)
        ta5.Controls.Add(ta56)
        ta5.Controls.Add(ta72)
        ta5.Controls.Add(ta73)
        ta5.Controls.Add(ta74)
        ta5.Controls.Add(ta75)


        Dim colors As String
        colors = "#ffdjff"
        ta5.Attributes.Add("bgcolor", colors)
        tab.Controls.Add(ta5)
        '   Dim dt As DataTable = oh.ExecuteDataSet("select b.branch_name,e.emp_code as bh_code,e.emp_name as bh_name,p.post_name,to_char(e.join_dt) as bh_join_dt,sm.state_name as bh_native,e1.emp_code as abh_code,e1.emp_name as abh_name,p1.post_name,to_char(e1.join_dt) as abh_join_dt,sm1.state_name as ABH_native from employee_master e,post_mst p,branch_master b,employ_personal_dtl ep,post_master pm,district_master dm,state_master sm,employee_master e1,employ_personal_dtl ep1,post_mst p1,post_master pm1,district_master dm1,state_master sm1 where e.emp_code=ep.emp_code and e.branch_id=b.branch_id and b.state_id=" & Request.QueryString("state") & " and e.post_id=p.post_id and e.post_id in (17,18,10,11,12,13,14,15,16,101,149,146,148,90) and ep.perm_pin=pm.sr_number and pm.district_id=dm.district_id and dm.state_id=sm.state_id and e.status_id=1 and e1.emp_code=ep1.emp_code and e1.status_id=1 and e1.post_id=p1.post_id and e1.post_id in (1,2,3,4,5,6,7,8,9) and ep1.perm_pin=pm1.sr_number and pm1.district_id=dm1.district_id and dm1.state_id=sm1.state_id and e1.branch_id=b.branch_id    order by sm.state_name,sm1.state_name").Tables(0)

        Dim dr As DataRow

        Dim emp As Integer
        emp = 0



        For Each dr In dt23.Rows

            If colors.Equals("#ffffef") = True Then
                colors = "#egf9ff"
            Else
                colors = "#ffffef"
            End If

            Dim lm5 As New TableRow
            lm5.Attributes.Add("bgcolor", colors)
            Dim lm49, lm61, lm62, lm51, lm52, lm53, lm54, lm72, lm73, lm74, lm75, lm60, sbh, bh, lm56, lm55, abh As New TableCell

            ''''''''''''''''''''''''''''''''''''''''''''''''
            lm51.ColumnSpan = 1
            lm51.HorizontalAlign = HorizontalAlign.Left


            ''''''''''''''''''''''''''''
            '
            lm51.ColumnSpan = 1
            lm51.HorizontalAlign = HorizontalAlign.Left
            lm51.Text = "<font size=2>" & dr(0) & "</font>"
            lm5.Controls.Add(lm51)



            lm52.ColumnSpan = 2
            lm52.HorizontalAlign = HorizontalAlign.Left
            lm52.Text = "<font size=2> " & dr(1) & " </font>"
            lm5.Controls.Add(lm52)
            emp = emp + 1

            lm53.ColumnSpan = 2
            lm53.HorizontalAlign = HorizontalAlign.Left
            lm53.Text = "<font size=2> " & dr(2) & "</font>"
            lm5.Controls.Add(lm53)

            lm61.ColumnSpan = 2
            lm61.HorizontalAlign = HorizontalAlign.Center
            lm61.Text = "<font size=2>" & dr(3) & "</font>"
            lm5.Controls.Add(lm61)


            lm54.ColumnSpan = 2
            lm54.HorizontalAlign = HorizontalAlign.Left

            lm54.Text = "<font size=2>" & dr(4) & "</font></a>"
            lm5.Controls.Add(lm54)

            ''''''''''''''''''''
            sbh.ColumnSpan = 2
            sbh.HorizontalAlign = HorizontalAlign.Left
            sbh.Text = "<font size=2>" & dr(5) & "</font>"
            lm5.Controls.Add(sbh)

            bh.ColumnSpan = 2
            bh.HorizontalAlign = HorizontalAlign.Left
            bh.Text = "<font size=2>" & dr(6) & "</font>"
            lm5.Controls.Add(bh)
            abh.ColumnSpan = 2
            abh.HorizontalAlign = HorizontalAlign.Left
            abh.Text = "<font size=2>" & dr(7) & "</font>"
            lm5.Controls.Add(abh)

            ''''''''''''''''''

            lm55.ColumnSpan = 1
            lm55.HorizontalAlign = HorizontalAlign.Center

            lm55.Text = "<font size=2> " & dr(8) & "</font>"
            lm5.Controls.Add(lm55)

            lm62.ColumnSpan = 1
            lm62.HorizontalAlign = HorizontalAlign.Center
            lm62.Text = "<font size=2> " & dr(9) & " </font>"
            lm5.Controls.Add(lm62)

            lm56.ColumnSpan = 2
            lm56.HorizontalAlign = HorizontalAlign.Left
            lm56.Text = "<font size=2> " & dr(10) & "</font>"
            lm5.Controls.Add(lm56)
            tab.Controls.Add(lm5)

            lm72.ColumnSpan = 2
            lm72.HorizontalAlign = HorizontalAlign.Left
            lm72.Text = "<font size=2> " & dr(11) & "</font>"
            lm5.Controls.Add(lm72)
            tab.Controls.Add(lm5)
            lm73.ColumnSpan = 2
            lm73.HorizontalAlign = HorizontalAlign.Left
            lm73.Text = "<font size=2> " & dr(12) & "</font>"
            lm5.Controls.Add(lm73)
            tab.Controls.Add(lm5)
            lm74.ColumnSpan = 2
            lm74.HorizontalAlign = HorizontalAlign.Left
            lm74.Text = "<font size=2> " & dr(13) & "</font>"
            lm5.Controls.Add(lm74)
            tab.Controls.Add(lm5)
            lm75.ColumnSpan = 2
            lm75.HorizontalAlign = HorizontalAlign.Left
            lm75.Text = "<font size=2> " & dr(14) & "</font>"
            lm5.Controls.Add(lm75)
            tab.Controls.Add(lm5)
        Next


        Dim li12 As New TableRow
        Dim li112 As New TableCell
        li112.ColumnSpan = 29
        li112.Text = "<hr align=center width=100% >"
        li12.Controls.Add(li112)
        tab.Controls.Add(li12)

        '''''''''''''''''''''''''''''''''''''''
        Dim llm5 As New TableRow
        llm5.Attributes.Add("bgcolor", "seashell")
        Dim llm49, llm51, llm52, llm53, llm54, llm60, lsbh, lbh, labh, llm55, llm56 As New TableCell


        ''''''''''''''''''''''''''''''''''''''''''''''''
        llm51.ColumnSpan = 2
        llm51.HorizontalAlign = HorizontalAlign.Left


        ''''''''''''''''''''''''''''
        '
        llm51.ColumnSpan = 2
        llm51.HorizontalAlign = HorizontalAlign.Left
        llm51.Text = "<font size=2></font>"
        llm5.Controls.Add(llm51)


        llm52.ColumnSpan = 2
        llm52.HorizontalAlign = HorizontalAlign.Left
        llm52.Text = "<font size=2>TOTAL RECORD-" & emp & "</font>"
        llm5.Controls.Add(llm52)

        llm53.ColumnSpan = 2
        llm53.HorizontalAlign = HorizontalAlign.Left
        llm53.Text = "<font size=2> </font>"
        llm5.Controls.Add(llm53)


        llm54.ColumnSpan = 2
        llm54.HorizontalAlign = HorizontalAlign.Left

        llm54.Text = "<font size=2></font></a>"
        llm5.Controls.Add(llm54)
        ''''''''''''''''''''
        lsbh.ColumnSpan = 1
        lsbh.HorizontalAlign = HorizontalAlign.Center
        lsbh.Text = "<font size=2></font>"
        llm5.Controls.Add(lsbh)

        lbh.ColumnSpan = 2
        lbh.HorizontalAlign = HorizontalAlign.Center
        lbh.Text = "<font size=2></font>"
        llm5.Controls.Add(lbh)

        labh.ColumnSpan = 2
        labh.HorizontalAlign = HorizontalAlign.Center
        labh.Text = "<font size=2></font>"
        llm5.Controls.Add(labh)

        llm55.ColumnSpan = 1
        llm55.HorizontalAlign = HorizontalAlign.Center

        llm55.Text = "<font size=2> </font>"
        llm5.Controls.Add(llm55)

        llm56.ColumnSpan = 2
        llm56.HorizontalAlign = HorizontalAlign.Center
        llm56.Text = "<font size=2> </font>"
        llm5.Controls.Add(llm56)
        tab.Controls.Add(llm5)

        '''''''''''''''''''''''''''''''''''''''''''''
        Dim lin21012 As New TableRow
        Dim lin210112 As New TableCell
        lin210112.ColumnSpan = 29
        lin210112.Text = "<hr align=center width=100% >"
        lin21012.Controls.Add(lin210112)
        tab.Controls.Add(lin21012)
        Dim lin21 As New TableRow
        Dim lin212 As New TableCell
        lin212.ColumnSpan = 29
        lin212.Text = "<a href=search_employ_details_reg_out.aspx><font color=blue>BACK</font ></a>"
        lin21.Controls.Add(lin212)
        tab.Controls.Add(lin21)
        Panel1.Controls.Add(tab)
    End Sub
End Class
