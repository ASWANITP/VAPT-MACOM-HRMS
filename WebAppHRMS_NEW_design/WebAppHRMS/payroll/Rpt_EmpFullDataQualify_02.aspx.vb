Imports System.Data
Imports System.Data.OracleClient
Partial Class PayRoll_Rpt_EmpFullDataQualify_02_876426be9299
    Inherits System.Web.UI.Page
    Dim RH As New WholeHelper.ClsRepCtrl
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt_2 As New DataTable
    Dim tb As New Table
    Dim dr As DataRow
    Dim StateID, QualifyID, Experience, Gender As Integer
    Dim ClassID() As String
    Dim PostDt As String
    Dim tot_count As Double
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  Rpt_EmpFullDataQualify_02.aspx?QualifyID='+QualifyID+'&Experience='+Experience+'&StateID='+StateID+'&Gender='+Gender+'&Class='+Class+
        QualifyID = Request.QueryString.Get("QualifyID")
        Experience = Request.QueryString.Get("Experience")
        StateID = Request.QueryString.Get("StateID")
        Gender = Request.QueryString.Get("Gender")
        ClassID = Request.QueryString.Get("Class").Split("-")
        If (QualifyID = -1) Then
            RH.Heading(Session("branch_id"), Session("branch_name"), Session("firm_name"), tb, "ALL - Wise Employee Details Report ", 32)
        Else
            dt = oh.ExecuteDataSet("select a.CATEGORY from qualification_category a where a.CATEGORY_ID=" & QualifyID & "").Tables(0)
            RH.Heading(Session("branch_id"), Session("branch_name"), Session("firm_name"), tb, " " & dt.Rows(0)(0) & " - Wise Employee Details Report ", 32)
        End If




        ' tb.Attributes.Add("border", "1")
        Dim tr07, tr08 As New TableRow
        Dim tr07_01, tr07_02, tr07_03, tr07_04, tr07_05, tr07_06, tr07_07, tr07_08, tr07_09, tr07_010, tr07_011 As New TableCell
        Dim tr07_012, tr07_013, tr07_014, tr07_015, tr07_016, tr07_017, tr07_018, tr07_019, tr07_020, tr07_021, tr07_022, tr07_023, tr07_024, tr07_25 As New TableCell
        RH.AddColumn(tr07, tr07_01, 1, 5, "c", "<b>CODE")
        RH.AddColumn(tr07, tr07_02, 1, 10, "l", "<b>NAME")
        RH.AddColumn(tr07, tr07_03, 2, 15, "l", "<b>BRANCH")

        RH.AddColumn(tr07, tr07_04, 2, 10, "l", "<b>AREA")
        RH.AddColumn(tr07, tr07_05, 1, 10, "l", "<b>REGION")
        RH.AddColumn(tr07, tr07_06, 1, 9, "l", "<b>ZONAL")

        RH.AddColumn(tr07, tr07_07, 1, 10, "l", "<b>NATIVE")
        RH.AddColumn(tr07, tr07_08, 5, 25, "l", "<b>POST")
        RH.AddColumn(tr07, tr07_09, 1, 5, "c", "<b>EXPERIENCE(Days)")

        RH.AddColumn(tr07, tr07_010, 4, 20, "l", "<b>DESIGNATION")
        'RH.AddColumn(tr07, tr07_011, 2, 10, "c", "GRADE")
        RH.AddColumn(tr07, tr07_012, 1, 5, "c", "<b>% MARKS")

        RH.AddColumn(tr07, tr07_013, 1, 8, "c", "<b>JOIN DATE")
        RH.AddColumn(tr07, tr07_014, 1, 4, "l", "<b>BUSINESS (in Kg)")
        RH.AddColumn(tr07, tr07_015, 1, 2.5, "l", "<b>&nbsp;NORMS")

        RH.AddColumn(tr07, tr07_016, 1, 2.5, "l", "<b>&nbsp;ACTUAL")
        RH.AddColumn(tr07, tr07_024, 3, 15, "c", "<u><b>Branch Experience")

        RH.AddColumn(tr08, tr07_017, 25, 120, "r", "<b>&nbsp;BH")
        RH.AddColumn(tr08, tr07_018, 1, 5, "c", "<b>&nbsp;ABH")
        RH.AddColumn(tr08, tr07_019, 1, 5, "c", "<b>&nbsp;PRESENT")

        RH.AddColumn(tr08, tr07_020, 1, 5, "c", "<b>&nbsp;OLD&nbsp;CODE")
        RH.AddColumn(tr08, tr07_021, 1, 5, "c", "<b>&nbsp;OLD&nbsp;JOIN.DATE")
        RH.AddColumn(tr08, tr07_022, 1, 5, "c", "<b>&nbsp;OLD.&nbsp;DESIGN")
        RH.AddColumn(tr08, tr07_023, 1, 5, "l", "<b>&nbsp;BR.&nbsp;STATE")

        RH.AddColumn(tr07, tr07_25, 0.5, 5, "l", "<b>ID")

        tb.Controls.Add(tr07)
        tb.Controls.Add(tr08)
        RH.DrawLine(tb, 32)

        If (Gender = -1) And QualifyID = -1 And StateID = -1 And ClassID(1) = 100 Then
            dt = oh.ExecuteDataSet("select a.emp_code,substr(a.emp_name,0,15),substr(b.branch_name,0,15),substr(c.area_name,0,15),substr(c.reg_name,0,15),substr(c.ZONAL_NAME,0,15),sm.state_name,substr(a.qualification,0,45),a.exp_day,a.designation,a.post,a.join_dt,nvl(SND.GOLD_OS,0),nvl(SND.Emp_Norms,0),nvl(SND.Emp_Actual,0),EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,nvl(a.old_empcode,0),a.old_joindt,sm_1.state_name,a.old_designation,a.branch_id from EMPLOYEE_CURRENT a,BRANCH_MASTER b left outer join STAFF_NORM_DTL SND on(SND.BRANCH_ID=b.branch_id),BRANCH_DTL_NEW c,EMPLOY_PERSONAL_DTL ep,POST_MASTER pm,DISTRICT_MASTER dm,STATE_MASTER sm,BH_EXP_DATA EXPDATA,STATE_MASTER sm_1,DESIGNATION_MASTER DM where a.status_id=1 and a.branch_id=b.branch_id and b.branch_id=c.BRANCH_ID and a.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=dm.district_id and dm.state_id= sm.state_id and a.percentage>=" & ClassID(0) & " and EXPDATA.emp_code=a.emp_code and b.state_id=sm_1.state_id having round((a.exp_day/30),2)>" & Experience & " group by a.emp_code,a.emp_name,b.branch_name,c.area_name,c.reg_name,c.ZONAL_NAME,sm.state_name,a.qualification,a.exp_day,a.designation,a.post,a.join_dt,SND.GOLD_OS,SND.Emp_Norms,SND.Emp_Actual,EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage ,a.old_empcode,a.old_joindt,sm_1.state_name,a.old_designation, a.branch_id order by a.emp_code").Tables(0)
        ElseIf (Gender = -1) And (QualifyID = -1) And (StateID = -1) Then
            dt = oh.ExecuteDataSet("select a.emp_code,substr(a.emp_name,0,15),substr(b.branch_name,0,15),substr(c.area_name,0,15),substr(c.reg_name,0,15),substr(c.ZONAL_NAME,0,15),sm.state_name,substr(a.qualification,0,45),a.exp_day,a.designation,a.post,a.join_dt,nvl(SND.GOLD_OS,0),nvl(SND.Emp_Norms,0),nvl(SND.Emp_Actual,0),EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,nvl(a.old_empcode,0),a.old_joindt,sm_1.state_name,a.old_designation,a.branch_id from EMPLOYEE_CURRENT a,BRANCH_MASTER b left outer join STAFF_NORM_DTL SND on(SND.BRANCH_ID=b.branch_id),BRANCH_DTL_NEW c,EMPLOY_PERSONAL_DTL ep,POST_MASTER pm,DISTRICT_MASTER dm,STATE_MASTER sm,BH_EXP_DATA EXPDATA,STATE_MASTER sm_1,DESIGNATION_MASTER DM where a.status_id=1 and a.branch_id=b.branch_id and b.branch_id=c.BRANCH_ID and a.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=dm.district_id and dm.state_id= sm.state_id and a.percentage>=" & ClassID(0) & " and a.percentage<" & ClassID(1) & "   and EXPDATA.emp_code=a.emp_code and b.state_id=sm_1.state_id having round((a.exp_day/30),2)>" & Experience & " group by a.emp_code,a.emp_name,b.branch_name,c.area_name,c.reg_name,c.ZONAL_NAME,sm.state_name,a.qualification,a.exp_day,a.designation,a.post,a.join_dt,SND.GOLD_OS,SND.Emp_Norms,SND.Emp_Actual,EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,a.old_empcode,a.old_joindt,sm_1.state_name,a.old_designation, a.branch_id order by a.emp_code").Tables(0)
        ElseIf (QualifyID = -1 And StateID = -1 And ClassID(1) = 100) Then
            dt = oh.ExecuteDataSet("select a.emp_code,substr(a.emp_name,0,15),substr(b.branch_name,0,15),substr(c.area_name,0,15),substr(c.reg_name,0,15),substr(c.ZONAL_NAME,0,15),sm.state_name,substr(a.qualification,0,45),a.exp_day,a.designation,a.post,a.join_dt,nvl(SND.GOLD_OS,0),nvl(SND.Emp_Norms,0),nvl(SND.Emp_Actual,0),EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,nvl(a.old_empcode,0),a.old_joindt,sm_1.state_name,a.old_designation,a.branch_id from EMPLOYEE_CURRENT a,BRANCH_MASTER b left outer join STAFF_NORM_DTL SND on(SND.BRANCH_ID=b.branch_id),BRANCH_DTL_NEW c,EMPLOY_PERSONAL_DTL ep,POST_MASTER pm,DISTRICT_MASTER dm,STATE_MASTER sm,qualification_category QC,qualification_master qm,BH_EXP_DATA EXPDATA,STATE_MASTER sm_1,DESIGNATION_MASTER DM   where a.status_id=1 and  qc.category_id=qm.category_id and a.qualification_id=qm.qualification_id  and  a.gen_id=" & Gender & " and a.branch_id=b.branch_id and b.branch_id=c.BRANCH_ID and a.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=dm.district_id and dm.state_id= sm.state_id and a.percentage>=" & ClassID(0) & "    and EXPDATA.emp_code=a.emp_code and b.state_id=sm_1.state_id having round((a.exp_day/30),2)>" & Experience & " group by a.emp_code,a.emp_name,b.branch_name,c.area_name,c.reg_name,c.ZONAL_NAME,sm.state_name,a.qualification,a.exp_day,a.designation,a.post,a.join_dt,SND.GOLD_OS,SND.Emp_Norms,SND.Emp_Actual,EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,a.old_empcode,a.old_joindt,sm_1.state_name,a.old_designation, a.branch_id order by a.emp_code").Tables(0)
        ElseIf (Gender = -1 And QualifyID = -1 And ClassID(1) = 100) Then
            dt = oh.ExecuteDataSet("select a.emp_code,substr(a.emp_name,0,15),substr(b.branch_name,0,15),substr(c.area_name,0,15),substr(c.reg_name,0,15),substr(c.ZONAL_NAME,0,15),sm.state_name,substr(a.qualification,0,45),a.exp_day,a.designation,a.post,a.join_dt,nvl(SND.GOLD_OS,0),nvl(SND.Emp_Norms,0),nvl(SND.Emp_Actual,0),EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,nvl(a.old_empcode,0)a.old_joindt,sm_1.state_name,a.old_designation,a.branch_id from EMPLOYEE_CURRENT a,BRANCH_MASTER b left outer join STAFF_NORM_DTL SND on(SND.BRANCH_ID=b.branch_id),BRANCH_DTL_NEW c,EMPLOY_PERSONAL_DTL ep,POST_MASTER pm,DISTRICT_MASTER dm,STATE_MASTER sm,qualification_category QC,qualification_master qm,BH_EXP_DATA EXPDATA,STATE_MASTER sm_1,DESIGNATION_MASTER DM,employ_firm f   where a.status_id=1 and  qc.category_id=qm.category_id and a.qualification_id=qm.qualification_id  and sm_1.state_id=" & StateID & " and a.branch_id=b.branch_id and b.branch_id=c.BRANCH_ID and a.emp_code=ep.emp_code and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and ep.perm_pin=pm.sr_number and pm.district_id=dm.district_id and dm.state_id= sm.state_id and a.percentage>=" & ClassID(0) & "   and EXPDATA.emp_code=a.emp_code and b.state_id=sm_1.state_id having round((a.exp_day/30),2)>" & Experience & " group by a.emp_code,a.emp_name,b.branch_name,c.area_name,c.reg_name,c.ZONAL_NAME,sm.state_name,a.qualification,a.exp_day,a.designation,a.post,a.join_dt,SND.GOLD_OS,SND.Emp_Norms,SND.Emp_Actual,EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,a.old_empcode,a.old_joindt,sm_1.state_name,a.old_designation, a.branch_id order by a.emp_code").Tables(0)
        ElseIf (Gender = -1 And StateID = -1 And ClassID(1) = 100) Then
            dt = oh.ExecuteDataSet("select a.emp_code,substr(a.emp_name,0,15),substr(b.branch_name,0,15),substr(c.area_name,0,15),substr(c.reg_name,0,15),substr(c.ZONAL_NAME,0,15),sm.state_name,substr(a.qualification,0,45),a.exp_day,a.designation,a.post,a.join_dt,nvl(SND.GOLD_OS,0),nvl(SND.Emp_Norms,0),nvl(SND.Emp_Actual,0),EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,nvl(a.old_empcode,0),a.old_joindt,sm_1.state_name,a.old_designation,a.branch_id from EMPLOYEE_CURRENT a,BRANCH_MASTER b left outer join STAFF_NORM_DTL SND on(SND.BRANCH_ID=b.branch_id),BRANCH_DTL_NEW c,EMPLOY_PERSONAL_DTL ep,POST_MASTER pm,DISTRICT_MASTER dm,STATE_MASTER sm,qualification_category QC,qualification_master qm,BH_EXP_DATA EXPDATA,STATE_MASTER sm_1,DESIGNATION_MASTER DM,employ_firm f   where a.status_id=1 and qc.category_id=" & QualifyID & "   and  qc.category_id=qm.category_id and a.qualification_id=qm.qualification_id   and a.branch_id=b.branch_id and b.branch_id=c.BRANCH_ID and a.emp_code=ep.emp_code and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and ep.perm_pin=pm.sr_number and pm.district_id=dm.district_id and dm.state_id= sm.state_id and a.percentage>=" & ClassID(0) & "   and EXPDATA.emp_code=a.emp_code  and b.state_id=sm_1.state_id having round((a.exp_day/30),2)>" & Experience & " group by a.emp_code,a.emp_name,b.branch_name,c.area_name,c.reg_name,c.ZONAL_NAME,sm.state_name,a.qualification,a.exp_day,a.designation,a.post ,a.join_dt,SND.GOLD_OS,SND.Emp_Norms,SND.Emp_Actual,EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,a.old_empcode,a.old_joindt,sm_1.state_name,a.old_designation, a.branch_id order by a.emp_code").Tables(0)
        ElseIf (Gender = -1) And QualifyID = -1 Then
            dt = oh.ExecuteDataSet("select a.emp_code,substr(a.emp_name,0,15),substr(b.branch_name,0,15),substr(c.area_name,0,15),substr(c.reg_name,0,15),substr(c.ZONAL_NAME,0,15),sm.state_name,substr(a.qualification,0,45),a.exp_day,a.designation,a.post,a.join_dt,nvl(SND.GOLD_OS,0),nvl(SND.Emp_Norms,0),nvl(SND.Emp_Actual,0),EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,nvl(a.old_empcode,0),a.old_joindt,sm_1.state_name,a.old_designation,a.branch_id from EMPLOYEE_CURRENT a,BRANCH_MASTER b left outer join STAFF_NORM_DTL SND on(SND.BRANCH_ID=b.branch_id),BRANCH_DTL_NEW c,EMPLOY_PERSONAL_DTL ep,POST_MASTER pm,DISTRICT_MASTER dm,STATE_MASTER sm,BH_EXP_DATA EXPDATA,STATE_MASTER sm_1,DESIGNATION_MASTER DM,employ_firm f where a.status_id=1 and sm_1.state_id=" & StateID & " and a.branch_id=b.branch_id and b.branch_id=c.BRANCH_ID and a.emp_code=ep.emp_code and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and ep.perm_pin=pm.sr_number and pm.district_id=dm.district_id and dm.state_id= sm.state_id and a.percentage>=" & ClassID(0) & " and a.percentage<" & ClassID(1) & "   and EXPDATA.emp_code=a.emp_code and b.state_id=sm_1.state_id having round((a.exp_day/30),2)>" & Experience & " group by a.emp_code,a.emp_name,b.branch_name,c.area_name,c.reg_name,c.ZONAL_NAME,sm.state_name,a.qualification,a.exp_day,a.designation,a.post,a.join_dt,SND.GOLD_OS,SND.Emp_Norms,SND.Emp_Actual,EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,a.old_empcode,a.old_joindt,sm_1.state_name,a.old_designation, a.branch_id  order by a.emp_code").Tables(0)
        ElseIf (Gender = -1) And StateID = -1 Then
            dt = oh.ExecuteDataSet("select a.emp_code,substr(a.emp_name,0,15),substr(b.branch_name,0,15),substr(c.area_name,0,15),substr(c.reg_name,0,15),substr(c.ZONAL_NAME,0,15),sm.state_name,substr(a.qualification,0,45),a.exp_day,a.designation,a.post,a.join_dt,nvl(SND.GOLD_OS,0),nvl(SND.Emp_Norms,0),nvl(SND.Emp_Actual,0),EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,nvl(a.old_empcode,0),a.old_joindt,sm_1.state_name,a.old_designation,a.branch_id from EMPLOYEE_CURRENT a,BRANCH_MASTER b left outer join STAFF_NORM_DTL SND on(SND.BRANCH_ID=b.branch_id),BRANCH_DTL_NEW c,EMPLOY_PERSONAL_DTL ep,POST_MASTER pm,DISTRICT_MASTER dm,STATE_MASTER sm,qualification_category QC,qualification_master qm,BH_EXP_DATA EXPDATA,STATE_MASTER sm_1,DESIGNATION_MASTER DM,employ_firm f   where a.status_id=1 and qc.category_id=" & QualifyID & " and  qc.category_id=qm.category_id and a.qualification_id=qm.qualification_id and a.branch_id=b.branch_id and b.branch_id=c.BRANCH_ID and a.emp_code=ep.emp_code and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and ep.perm_pin=pm.sr_number and pm.district_id=dm.district_id and dm.state_id= sm.state_id and a.percentage>=" & ClassID(0) & " and a.percentage<" & ClassID(1) & "   and EXPDATA.emp_code=a.emp_code and b.state_id=sm_1.state_id having round((a.exp_day/30),2)>" & Experience & " group by a.emp_code,a.emp_name,b.branch_name,c.area_name,c.reg_name,c.ZONAL_NAME,sm.state_name,a.qualification,a.exp_day,a.designation,a.post,a.join_dt,SND.GOLD_OS,SND.Emp_Norms,SND.Emp_Actual,EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,a.old_empcode,a.old_joindt,sm_1.state_name,a.old_designation, a.branch_id order by a.emp_code").Tables(0)
        ElseIf (QualifyID = -1) And StateID = -1 Then
            dt = oh.ExecuteDataSet("select a.emp_code,substr(a.emp_name,0,15),substr(b.branch_name,0,15),substr(c.area_name,0,15),substr(c.reg_name,0,15),substr(c.ZONAL_NAME,0,15),sm.state_name,substr(a.qualification,0,45),a.exp_day,a.designation,a.post,a.join_dt,nvl(SND.GOLD_OS,0),nvl(SND.Emp_Norms,0),nvl(SND.Emp_Actual,0),EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,nvl(a.old_empcode,0),a.old_joindt,sm_1.state_name,a.old_designation,a.branch_id from EMPLOYEE_CURRENT a,BRANCH_MASTER b left outer join STAFF_NORM_DTL SND on(SND.BRANCH_ID=b.branch_id),BRANCH_DTL_NEW c,EMPLOY_PERSONAL_DTL ep,POST_MASTER pm,DISTRICT_MASTER dm,STATE_MASTER sm,qualification_category QC,qualification_master qm,BH_EXP_DATA EXPDATA,STATE_MASTER sm_1,DESIGNATION_MASTER DM,employ_firm f where a.status_id=1 and  qc.category_id=qm.category_id and a.qualification_id=qm.qualification_id and a.gen_id=" & Gender & " and a.branch_id=b.branch_id and b.branch_id=c.BRANCH_ID and a.emp_code=ep.emp_code and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and ep.perm_pin=pm.sr_number and pm.district_id=dm.district_id and dm.state_id= sm.state_id and a.percentage>=" & ClassID(0) & " and a.percentage<" & ClassID(1) & "    and EXPDATA.emp_code=a.emp_code  and b.state_id=sm_1.state_id having round((a.exp_day/30),2)>" & Experience & " group by a.emp_code,a.emp_name,b.branch_name,c.area_name,c.reg_name,c.ZONAL_NAME,sm.state_name,a.qualification,a.exp_day,a.designation,a.post,a.join_dt,SND.GOLD_OS,SND.Emp_Norms,SND.Emp_Actual,EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,a.old_empcode,a.old_joindt,sm_1.state_name,a.old_designation, a.branch_id  order by a.emp_code").Tables(0)
        ElseIf (ClassID(1) = 100) And StateID = -1 Then
            dt = oh.ExecuteDataSet("select a.emp_code,substr(a.emp_name,0,15),substr(b.branch_name,0,15),substr(c.area_name,0,15),substr(c.reg_name,0,15),substr(c.ZONAL_NAME,0,15),sm.state_name,substr(a.qualification,0,45),a.exp_day,a.designation,a.post,a.join_dt,nvl(SND.GOLD_OS,0),nvl(SND.Emp_Norms,0),nvl(SND.Emp_Actual,0),EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,nvl(a.old_empcode,0),a.old_joindt,sm_1.state_name,a.old_designation,a.branch_id from EMPLOYEE_CURRENT a,BRANCH_MASTER b left outer join STAFF_NORM_DTL SND on(SND.BRANCH_ID=b.branch_id),BRANCH_DTL_NEW c,EMPLOY_PERSONAL_DTL ep,POST_MASTER pm,DISTRICT_MASTER dm,STATE_MASTER sm,qualification_category QC,qualification_master qm,BH_EXP_DATA EXPDATA,STATE_MASTER sm_1,DESIGNATION_MASTER DM,employ_firm f   where a.status_id=1 and  qc.category_id=" & QualifyID & " and  qc.category_id=qm.category_id and a.qualification_id=qm.qualification_id and a.gen_id=" & Gender & " and a.branch_id=b.branch_id and b.branch_id=c.BRANCH_ID and a.emp_code=ep.emp_code and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and ep.perm_pin=pm.sr_number and pm.district_id=dm.district_id and dm.state_id= sm.state_id and a.percentage>=" & ClassID(0) & "    and EXPDATA.emp_code=a.emp_code  and b.state_id=sm_1.state_id having round((a.exp_day/30),2)>" & Experience & " group by a.emp_code,a.emp_name,b.branch_name,c.area_name,c.reg_name,c.ZONAL_NAME,sm.state_name,a.qualification,a.exp_day,a.designation,a.post,a.join_dt,SND.GOLD_OS,SND.Emp_Norms,SND.Emp_Actual,EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,a.old_empcode,a.old_joindt,sm_1.state_name,a.old_designation, a.branch_id  order by a.emp_code").Tables(0)
        ElseIf (ClassID(1) = 100) And QualifyID = -1 Then
            dt = oh.ExecuteDataSet("select a.emp_code,substr(a.emp_name,0,15),substr(b.branch_name,0,15),substr(c.area_name,0,15),substr(c.reg_name,0,15),substr(c.ZONAL_NAME,0,15),sm.state_name,substr(a.qualification,0,45),a.exp_day,a.designation,a.post,a.join_dt,nvl(SND.GOLD_OS,0),nvl(SND.Emp_Norms,0),nvl(SND.Emp_Actual,0),EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,nvl(a.old_empcode,0),a.old_joindt,sm_1.state_name,a.old_designation,a.branch_id from EMPLOYEE_CURRENT a,BRANCH_MASTER b left outer join  STAFF_NORM_DTL SND on(SND.BRANCH_ID=b.branch_id),BRANCH_DTL_NEW c,EMPLOY_PERSONAL_DTL ep,POST_MASTER pm,DISTRICT_MASTER dm,STATE_MASTER sm,qualification_category QC,qualification_master qm,BH_EXP_DATA EXPDATA,STATE_MASTER sm_1,DESIGNATION_MASTER DM,employ_firm f   where a.status_id=1 and  qc.category_id=qm.category_id and a.qualification_id=qm.qualification_id and sm_1.state_id=" & StateID & " and a.gen_id=" & Gender & " and a.branch_id=b.branch_id and b.branch_id=c.BRANCH_ID and a.emp_code=ep.emp_code and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and ep.perm_pin=pm.sr_number and pm.district_id=dm.district_id and dm.state_id= sm.state_id and a.percentage>=" & ClassID(0) & "   and EXPDATA.emp_code=a.emp_code   and b.state_id=sm_1.state_id having round((a.exp_day/30),2)>" & Experience & " group by a.emp_code,a.emp_name,b.branch_name,c.area_name,c.reg_name,c.ZONAL_NAME,sm.state_name,a.qualification,a.exp_day,a.designation,a.post,a.join_dt,SND.GOLD_OS,SND.Emp_Norms,SND.Emp_Actual,EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,a.old_empcode,a.old_joindt,sm_1.state_name,a.old_designation, a.branch_id  order by a.emp_code").Tables(0)
        ElseIf (ClassID(1) = 100) And Gender = -1 Then
            dt = oh.ExecuteDataSet("select a.emp_code,substr(a.emp_name, 0, 15),substr(b.branch_name, 0, 15),substr(c.area_name, 0, 15),substr(c.reg_name, 0, 15),substr(c.ZONAL_NAME, 0, 15),sm.state_name,substr(a.qualification, 0, 45),a.exp_day,        a.designation,a.post,a.join_dt,nvl(SND.GOLD_OS, 0),nvl(SND.Emp_Norms, 0),nvl(SND.Emp_Actual, 0),EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,nvl(a.old_empcode, 0),a.old_joindt,sm_1.state_name,a.old_designation,a.branch_id   from EMPLOYEE_CURRENT a, BRANCH_MASTER b   left outer join STAFF_NORM_DTL SND on (SND.BRANCH_ID = b.branch_id),  BRANCH_DTL_NEW c,  EMPLOY_PERSONAL_DTL ep, POST_MASTER pm,  DISTRICT_MASTER dm, STATE_MASTER sm,  qualification_category QC,  qualification_master qm,  BH_EXP_DATA EXPDATA, STATE_MASTER sm_1,  DESIGNATION_MASTER DM, employ_firm f  where a.status_id = 1    and qc.category_id = " & QualifyID & "  and qc.category_id = qm.category_id    and a.qualification_id = qm.qualification_id    and sm_1.state_id = " & StateID & "    and a.branch_id = b.branch_id    and b.branch_id = c.BRANCH_ID    and a.emp_code = ep.emp_code    and a.emp_code = f.emp_code    and f.firm_id = " & Session("firm_id") & "    and ep.perm_pin = pm.sr_number    and pm.district_id = dm.district_id    and dm.state_id = sm.state_id    and a.percentage >= " & ClassID(0) & "    and EXPDATA.emp_code = a.emp_code    and b.state_id = sm_1.state_id having  round((a.exp_day / 30), 2) > " & Experience & "  group by a.emp_code,           a.emp_name,           b.branch_name,           c.area_name,           c.reg_name,           c.ZONAL_NAME,           sm.state_name,           a.qualification,           a.exp_day,           a.designation,           a.post,           a.join_dt,           SND.GOLD_OS,           SND.Emp_Norms,           SND.Emp_Actual,           EXPDATA.BH_Exp,           EXPDATA.ABH_Exp,           EXPDATA.PrsntEXP,           a.percentage,           a.old_empcode,a.old_joindt,sm_1.state_name,a.old_designation,a.branch_id  order by a.emp_code").Tables(0)
        ElseIf (Gender = -1) Then
            dt = oh.ExecuteDataSet("select a.emp_code,substr(a.emp_name,0,15),substr(b.branch_name,0,15),substr(c.area_name,0,15),substr(c.reg_name,0,15),substr(c.ZONAL_NAME,0,15),sm.state_name,substr(a.qualification,0,45),a.exp_day,a.designation,a.post,a.join_dt,nvl(SND.GOLD_OS,0),nvl(SND.Emp_Norms,0),nvl(SND.Emp_Actual,0),EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,nvl(a.old_empcode,0),a.old_joindt,sm_1.state_name,a.old_designation,a.branch_id from EMPLOYEE_CURRENT a,BRANCH_MASTER b left outer join  STAFF_NORM_DTL SND on(SND.BRANCH_ID=b.branch_id),BRANCH_DTL_NEW c,EMPLOY_PERSONAL_DTL ep,POST_MASTER pm,DISTRICT_MASTER dm,STATE_MASTER sm,qualification_category QC,qualification_master qm,BH_EXP_DATA EXPDATA,STATE_MASTER sm_1,DESIGNATION_MASTER DM,employ_firm f   where a.status_id=1 and  qc.category_id=" & QualifyID & " and  qc.category_id=qm.category_id and a.qualification_id=qm.qualification_id and sm_1.state_id=" & StateID & " and a.branch_id=b.branch_id and b.branch_id=c.BRANCH_ID and a.emp_code=ep.emp_code and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and ep.perm_pin=pm.sr_number and pm.district_id=dm.district_id and dm.state_id= sm.state_id and a.percentage>=" & ClassID(0) & " and a.percentage<" & ClassID(1) & "   and EXPDATA.emp_code=a.emp_code  and b.state_id=sm_1.state_id having round((a.exp_day/30),2)>" & Experience & " group by a.emp_code,a.emp_name,b.branch_name,c.area_name,c.reg_name,c.ZONAL_NAME,sm.state_name,a.qualification,a.exp_day,a.designation,a.post,a.join_dt,SND.GOLD_OS,SND.Emp_Norms,SND.Emp_Actual,EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,a.old_empcode,a.old_joindt,sm_1.state_name,a.old_designation, a.branch_id  order by a.emp_code").Tables(0)
        ElseIf (QualifyID = -1) Then
            dt = oh.ExecuteDataSet("select a.emp_code,substr(a.emp_name,0,15),substr(b.branch_name,0,15),substr(c.area_name,0,15),substr(c.reg_name,0,15),substr(c.ZONAL_NAME,0,15),sm.state_name,substr(a.qualification,0,45),a.exp_day,a.designation,a.post,a.join_dt,nvl(SND.GOLD_OS,0),nvl(SND.Emp_Norms,0),nvl(SND.Emp_Actual,0),EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,nvl(a.old_empcode,0),a.old_joindt,sm_1.state_name,a.old_designation,a.branch_id from EMPLOYEE_CURRENT a,BRANCH_MASTER b left outer join  STAFF_NORM_DTL SND on(SND.BRANCH_ID=b.branch_id),BRANCH_DTL_NEW c,EMPLOY_PERSONAL_DTL ep,POST_MASTER pm,DISTRICT_MASTER dm,STATE_MASTER sm,BH_EXP_DATA EXPDATA,STATE_MASTER sm_1,DESIGNATION_MASTER DM,employ_firm f   where a.status_id=1 and sm_1.state_id=" & StateID & " and a.gen_id=" & Gender & " and a.branch_id=b.branch_id and b.branch_id=c.BRANCH_ID and a.emp_code=ep.emp_code and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and ep.perm_pin=pm.sr_number and pm.district_id=dm.district_id and dm.state_id= sm.state_id and a.percentage>=" & ClassID(0) & " and a.percentage<" & ClassID(1) & "   and EXPDATA.emp_code=a.emp_code  and b.state_id=sm_1.state_id having round((a.exp_day/30),2)>" & Experience & " group by a.emp_code,a.emp_name,b.branch_name,c.area_name,c.reg_name,c.ZONAL_NAME,sm.state_name,a.qualification,a.exp_day,a.designation,a.post,a.join_dt,SND.GOLD_OS,SND.Emp_Norms,SND.Emp_Actual,EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,a.old_empcode,a.old_joindt,sm_1.state_name,a.old_designation, a.branch_id  order by a.emp_code").Tables(0)
        ElseIf (StateID = -1) Then
            dt = oh.ExecuteDataSet("select a.emp_code,substr(a.emp_name,0,15),substr(b.branch_name,0,15),substr(c.area_name,0,15),substr(c.reg_name,0,15),substr(c.ZONAL_NAME,0,15),sm.state_name,substr(a.qualification,0,45),a.exp_day,a.designation,a.post,a.join_dt,nvl(SND.GOLD_OS,0),nvl(SND.Emp_Norms,0),nvl(SND.Emp_Actual,0),EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,nvl(a.old_empcode,0),a.old_joindt,sm_1.state_name,a.old_designation,a.branch_id from EMPLOYEE_CURRENT a,BRANCH_MASTER b left outer join STAFF_NORM_DTL SND on(SND.BRANCH_ID=b.branch_id),BRANCH_DTL_NEW c,EMPLOY_PERSONAL_DTL ep,POST_MASTER pm,DISTRICT_MASTER dm,STATE_MASTER sm,qualification_category QC,qualification_master qm,BH_EXP_DATA EXPDATA,STATE_MASTER sm_1,DESIGNATION_MASTER DM,employ_firm f   where a.status_id=1 and qc.category_id=" & QualifyID & " and  qc.category_id=qm.category_id and a.qualification_id=qm.qualification_id  and a.gen_id=" & Gender & " and a.branch_id=b.branch_id and b.branch_id=c.BRANCH_ID and a.emp_code=ep.emp_code and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and ep.perm_pin=pm.sr_number and pm.district_id=dm.district_id and dm.state_id= sm.state_id and a.percentage>=" & ClassID(0) & " and a.percentage<" & ClassID(1) & "   and EXPDATA.emp_code=a.emp_code  and b.state_id=sm_1.state_id having round((a.exp_day/30),2)>" & Experience & " group by a.emp_code,a.emp_name,b.branch_name,c.area_name,c.reg_name,c.ZONAL_NAME,sm.state_name,a.qualification,a.exp_day,a.designation,a.post,a.join_dt,SND.GOLD_OS,SND.Emp_Norms,SND.Emp_Actual,EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,a.old_empcode,a.old_joindt,sm_1.state_name,a.old_designation, a.branch_id  order by a.emp_code").Tables(0)
        ElseIf (ClassID(1) = 100) Then
            dt = oh.ExecuteDataSet("select a.emp_code,substr(a.emp_name,0,15),substr(b.branch_name,0,15),substr(c.area_name,0,15),substr(c.reg_name,0,15),substr(c.ZONAL_NAME,0,15),sm.state_name,substr(a.qualification,0,45),a.exp_day,a.designation,a.post,a.join_dt,nvl(SND.GOLD_OS,0),nvl(SND.Emp_Norms,0),nvl(SND.Emp_Actual,0),EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,nvl(a.old_empcode,0),a.old_joindt,sm_1.state_name,a.old_designation,a.branch_id from EMPLOYEE_CURRENT a,BRANCH_MASTER b left outer join STAFF_NORM_DTL SND on(SND.BRANCH_ID=b.branch_id),BRANCH_DTL_NEW c,EMPLOY_PERSONAL_DTL ep,POST_MASTER pm,DISTRICT_MASTER dm,STATE_MASTER sm,qualification_category QC,qualification_master qm,BH_EXP_DATA EXPDATA,STATE_MASTER sm_1,DESIGNATION_MASTER DM,employ_firm f   where a.status_id=1 and qc.category_id=" & QualifyID & " and  qc.category_id=qm.category_id and a.qualification_id=qm.qualification_id  and sm_1.state_id=" & StateID & " and a.gen_id=" & Gender & "and a.branch_id=b.branch_id and b.branch_id=c.BRANCH_ID and a.emp_code=ep.emp_code and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and ep.perm_pin=pm.sr_number and pm.district_id=dm.district_id and dm.state_id= sm.state_id and a.percentage>=" & ClassID(0) & "   and EXPDATA.emp_code=a.emp_code  and b.state_id=sm_1.state_id having round((a.exp_day/30),2)>" & Experience & " group by a.emp_code,a.emp_name,b.branch_name,c.area_name,c.reg_name,c.ZONAL_NAME,sm.state_name,a.qualification,a.exp_day,a.designation,a.post,a.join_dt,SND.GOLD_OS,SND.Emp_Norms,SND.Emp_Actual,EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,a.old_empcode,a.old_joindt,sm_1.state_name,a.old_designation, a.branch_id  order by a.emp_code").Tables(0)
        Else
            dt = oh.ExecuteDataSet("select a.emp_code,substr(a.emp_name,0,15),substr(b.branch_name,0,15),substr(c.area_name,0,15),substr(c.reg_name,0,15),substr(c.ZONAL_NAME,0,15),sm.state_name,substr(a.qualification,0,45),a.exp_day,a.designation,a.post,a.join_dt,nvl(SND.GOLD_OS,0),nvl(SND.Emp_Norms,0),nvl(SND.Emp_Actual,0),EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,nvl(a.old_empcode,0),a.old_joindt,sm_1.state_name,a.old_designation,a.branch_id from EMPLOYEE_CURRENT a,BRANCH_MASTER b left outer join STAFF_NORM_DTL SND on(SND.BRANCH_ID=b.branch_id),BRANCH_DTL_NEW c,EMPLOY_PERSONAL_DTL ep,POST_MASTER pm,DISTRICT_MASTER dm,STATE_MASTER sm,qualification_category QC,qualification_master qm,BH_EXP_DATA EXPDATA,STATE_MASTER sm_1,DESIGNATION_MASTER DM,employ_firm f   where a.status_id=1 and qc.category_id=" & QualifyID & " and  qc.category_id=qm.category_id and a.qualification_id=qm.qualification_id  and sm_1.state_id=" & StateID & " and a.gen_id=" & Gender & " and a.branch_id=b.branch_id and b.branch_id=c.BRANCH_ID and a.emp_code=ep.emp_code and a.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and ep.perm_pin=pm.sr_number and pm.district_id=dm.district_id and dm.state_id= sm.state_id and a.percentage>=" & ClassID(0) & " and a.percentage<" & ClassID(1) & "   and EXPDATA.emp_code=a.emp_code  and b.state_id=sm_1.state_id having round((a.exp_day/30),2)>" & Experience & " group by a.emp_code,a.emp_name,b.branch_name,c.area_name,c.reg_name,c.ZONAL_NAME,sm.state_name,a.qualification,a.exp_day,a.designation,a.post,a.join_dt,SND.GOLD_OS,SND.Emp_Norms,SND.Emp_Actual,EXPDATA.BH_Exp,EXPDATA.ABH_Exp,EXPDATA.PrsntEXP,a.percentage,a.old_empcode,a.old_joindt,sm_1.state_name,a.old_designation, a.branch_id  order by a.emp_code").Tables(0)
        End If

        Dim RowBG As Integer = 0
        tot_count = 0
        For Each dr In dt.Rows
            Dim tr09 As New TableRow
            Dim tr09_01, tr09_02, tr09_03, tr09_04, tr09_05, tr09_06, tr09_07, tr09_08, tr09_09, tr09_010, tr09_011 As New TableCell
            Dim tr09_012, tr09_013, tr09_014, tr09_015, tr09_016, tr09_017, tr09_018, tr09_019, tr09_020, tr09_021, tr09_022, tr09_023, tr09_25 As New TableCell

            If RowBG = 0 Then
                tr09.BackColor = Drawing.Color.WhiteSmoke
                RowBG = 1
            Else
                RowBG = 0
            End If
            RH.AddColumn(tr09, tr09_01, 1, 5, "c", dr(0))
            RH.AddColumn(tr09, tr09_02, 1, 10, "l", "&nbsp;" & dr(1))
            RH.AddColumn(tr09, tr09_03, 2, 15, "l", "&nbsp;" & dr(2))

            RH.AddColumn(tr09, tr09_04, 2, 10, "l", "&nbsp;" & dr(3))
            RH.AddColumn(tr09, tr09_05, 1, 10, "l", "&nbsp;" & dr(4))
            RH.AddColumn(tr09, tr09_06, 1, 9, "l", "&nbsp;" & dr(5))

            RH.AddColumn(tr09, tr09_07, 1, 10, "l", "&nbsp;" & dr(6))
            RH.AddColumn(tr09, tr09_08, 5, 25, "l", "&nbsp;" & dr(10))
            RH.AddColumn(tr09, tr09_09, 1, 5, "c", "&nbsp;" & dr(8))

            RH.AddColumn(tr09, tr09_010, 4, 20, "l", "&nbsp;" & dr(9))
            'RH.AddColumn(tr09, tr09_011, 3, 10, "l", "&nbsp;" & dr(10))
            RH.AddColumn(tr09, tr09_012, 1, 5, "r", "&nbsp;" & FormatNumber(dr(18)))

            RH.AddColumn(tr09, tr09_013, 1, 8, "c", "&nbsp;" & Format(dr(11), "dd-MMM-yyyy"))
            RH.AddColumn(tr09, tr09_014, 1, 4, "r", "&nbsp;" & FormatNumber(dr(12)))
            RH.AddColumn(tr09, tr09_015, 1, 2.5, "c", "&nbsp;" & dr(13))

            RH.AddColumn(tr09, tr09_016, 1, 2.5, "c", "&nbsp;" & dr(14))
            RH.AddColumn(tr09, tr09_018, 1, 5, "c", "&nbsp;" & dr(16))
            RH.AddColumn(tr09, tr09_017, 1, 5, "r", "&nbsp;" & dr(15))
            RH.AddColumn(tr09, tr09_019, 1, 5, "c", "&nbsp;" & dr(17))

            RH.AddColumn(tr09, tr09_020, 1, 5, "c", "&nbsp;" & dr(19))

            If (IsDBNull(dr(20))) Then
                RH.AddColumn(tr09, tr09_021, 1, 5, "c", "&nbsp;Nil")
            Else
                RH.AddColumn(tr09, tr09_021, 1, 5, "c", "&nbsp;" & Format(dr(20), "dd-MMM-yyyy"))
            End If

            If (IsDBNull(dr(22))) Then
                RH.AddColumn(tr09, tr09_022, 1, 5, "l", "&nbsp;Nil")
            Else
                dt_2 = oh.ExecuteDataSet("select a.designation from DESIGNATION_MASTER a where a.designation_id=" & dr(22) & "").Tables(0)
                RH.AddColumn(tr09, tr09_022, 1, 5, "l", "&nbsp;" & dt_2.rows(0)(0))
            End If

            RH.AddColumn(tr09, tr09_023, 1, 5, "l", "&nbsp;" & dr(21))
            RH.AddColumn(tr09, tr09_25, 0.5, 5, "l", "&nbsp;" & dr(23))

            tb.Controls.Add(tr09)
            tot_count += 1
        Next
        RH.DrawLine(tb, 32)
        Dim tr10 As New TableRow
        Dim tr10_01, tr10_02, tr10_03 As New TableCell
        tr10.BackColor = Drawing.Color.WhiteSmoke
        RH.AddColumn(tr10, tr10_01, 1, 5, "c", "<b>TOTAL :")
        RH.AddColumn(tr10, tr10_02, 1, 10, "c", "<b>" & tot_count)
        tb.Controls.Add(tr10)
        RH.DrawLine(tb, 32)
        Panel1.Controls.Add(tb)
    End Sub
End Class

