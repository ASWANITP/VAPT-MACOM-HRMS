Imports System.Data
Imports System.Data.OracleClient
Partial Class OutstationReport_outstation_report_885f40145794
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    ' Dim oh As New helper.oracle.Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim dr As DataRow
    Dim str, str1, str2 As String
    Dim bridfrom, bridto As Integer
   
    Dim fixedta As Double = 0
    Dim actualta As Double = 0
    Dim outstation As Double = 0
    Dim abhallowance As Double = 0
    Dim incentive As Double = 0
    Dim teleallowance As Double = 0
    Dim bhallowance As Double = 0
    Dim bhta As Double = 0
    Dim distallowance As Double = 0
    Dim hpta As Double = 0
    Dim total As Double = 0
    Dim reccount As Double = 0
    Dim pagenonext As Double = 1

    Dim tatble As New Table

    Dim i As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
        Me.bridfrom = Request.QueryString("branchid_from")
        Me.bridto = Request.QueryString("branchid_to")


        If Me.bridfrom = 0 And Me.bridto = 0 Then
            '                           0                           1                               2                           3                                4                              5                             6_incentive                                                                                                                                                                                                                                                                                                                                                 7                                 8                                  9                        10                        11                                          12                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          13               14
            str = "select ad.emp_code,em.emp_name,sum(decode(ad.all_id,1,ad.all_amount,0))as Fix_ta,sum(decode(ad.all_id,2,ad.all_amount,0))as Act_ta,sum(decode(ad.all_id,3,ad.all_amount,0))as Outstation,sum(decode(ad.all_id,4,ad.all_amount,0))as Abh_All,sum((decode(ad.all_id,7,ad.all_amount,0)+decode(ad.all_id,11,ad.all_amount,0)+decode(ad.all_id,12,ad.all_amount,0)+decode(ad.all_id,13,ad.all_amount,0)+decode(ad.all_id,14,ad.all_amount,0)+decode(ad.all_id,15,ad.all_amount,0)+decode(ad.all_id,16,ad.all_amount,0)+decode(ad.all_id,17,ad.all_amount,0)+decode(ad.all_id,18,ad.all_amount,0)+decode(ad.all_id,19,ad.all_amount,0)+decode(ad.all_id,20,ad.all_amount,0)+decode(ad.all_id,21,ad.all_amount,0)+decode(ad.all_id,22,ad.all_amount,0)+decode(ad.all_id,23,ad.all_amount,0)+decode(ad.all_id,24,ad.all_amount,0)+decode(ad.all_id,25,ad.all_amount,0)+decode(ad.all_id,26,ad.all_amount,0)+decode(ad.all_id,28,ad.all_amount,0)+decode(ad.all_id,29,ad.all_amount,0)+decode(ad.all_id,30,ad.all_amount,0)+decode(ad.all_id,31,ad.all_amount,0)+decode(ad.all_id,32,ad.all_amount,0)+decode(ad.all_id,33,ad.all_amount,0)+decode(ad.all_id,34,ad.all_amount,0)+decode(ad.all_id,35,ad.all_amount,0)))as incentive,sum(decode(ad.all_id,8,ad.all_amount,0))as tele_all,sum(decode(ad.all_id,5,ad.all_amount,0))as Bh_all,sum(decode(ad.all_id,6,ad.all_amount,0))as Bh_ta,sum(decode(ad.all_id,9,ad.all_amount,0)+decode(ad.all_id,27,ad.all_amount,0))as Dist_summer,sum(decode(ad.all_id,10,ad.all_amount,0))as Hp_ta,sum((decode(ad.all_id,1,ad.all_amount,0)+decode(ad.all_id,2,ad.all_amount,0)+decode(ad.all_id,3,ad.all_amount,0)+decode(ad.all_id,4,ad.all_amount,0)+decode(ad.all_id,5,ad.all_amount,0)+decode(ad.all_id,6,ad.all_amount,0)+decode(ad.all_id,7,ad.all_amount,0)+decode(ad.all_id,8,ad.all_amount,0)+decode(ad.all_id,9,ad.all_amount,0)+decode(ad.all_id,10,ad.all_amount,0)+decode(ad.all_id,11,ad.all_amount,0)+decode(ad.all_id,12,ad.all_amount,0)+decode(ad.all_id,13,ad.all_amount,0)+decode(ad.all_id,14,ad.all_amount,0)+decode(ad.all_id,15,ad.all_amount,0)+decode(ad.all_id,16,ad.all_amount,0)+decode(ad.all_id,17,ad.all_amount,0)+decode(ad.all_id,18,ad.all_amount,0)+decode(ad.all_id,19,ad.all_amount,0)+decode(ad.all_id,20,ad.all_amount,0)+decode(ad.all_id,21,ad.all_amount,0)+decode(ad.all_id,22,ad.all_amount,0)+decode(ad.all_id,23,ad.all_amount,0)+decode(ad.all_id,24,ad.all_amount,0)+decode(ad.all_id,25,ad.all_amount,0)+decode(ad.all_id,26,ad.all_amount,0)+decode(ad.all_id,28,ad.all_amount,0)+decode(ad.all_id,29,ad.all_amount,0)+decode(ad.all_id,30,ad.all_amount,0)+decode(ad.all_id,27,ad.all_amount,0)+decode(ad.all_id,31,ad.all_amount,0)+decode(ad.all_id,32,ad.all_amount,0)+decode(ad.all_id,33,ad.all_amount,0)+decode(ad.all_id,34,ad.all_amount,0)+decode(ad.all_id,35,ad.all_amount,0))) as Total,'A.O.VALAPAD(Others)' as branchname,0 as branchid from employee_master em,incentives_allowances_dtl ad,employee_master_dtl ed where  ad.emp_code=em.emp_code and ad.emp_code=ed.emp_code and ed.discont_dt is not null and (ad.status_id in(3,4,6,10) or ad.status_id=5 and ed.new_empcode is null)group by  ad.emp_code,em.emp_name union select ad.emp_code,em.emp_name,sum(decode(ad.all_id,1,ad.all_amount,0))as Fix_ta,sum(decode(ad.all_id,2,ad.all_amount,0))as Act_ta,sum(decode(ad.all_id,3,ad.all_amount,0))as Outstation,sum(decode(ad.all_id,4,ad.all_amount,0))as Abh_All,sum((decode(ad.all_id,7,ad.all_amount,0)+decode(ad.all_id,11,ad.all_amount,0)+decode(ad.all_id,12,ad.all_amount,0)+decode(ad.all_id,13,ad.all_amount,0)+decode(ad.all_id,14,ad.all_amount,0)+decode(ad.all_id,15,ad.all_amount,0)+decode(ad.all_id,16,ad.all_amount,0)+decode(ad.all_id,17,ad.all_amount,0)+decode(ad.all_id,18,ad.all_amount,0)+decode(ad.all_id,19,ad.all_amount,0)+decode(ad.all_id,20,ad.all_amount,0)+decode(ad.all_id,21,ad.all_amount,0)+decode(ad.all_id,22,ad.all_amount,0)+decode(ad.all_id,23,ad.all_amount,0)+decode(ad.all_id,24,ad.all_amount,0)+decode(ad.all_id,25,ad.all_amount,0)+decode(ad.all_id,26,ad.all_amount,0)+decode(ad.all_id,28,ad.all_amount,0)+decode(ad.all_id,29,ad.all_amount,0)+decode(ad.all_id,30,ad.all_amount,0)+decode(ad.all_id,31,ad.all_amount,0)+decode(ad.all_id,32,ad.all_amount,0)+decode(ad.all_id,33,ad.all_amount,0)+decode(ad.all_id,34,ad.all_amount,0)+decode(ad.all_id,35,ad.all_amount,0)))as incentive,sum(decode(ad.all_id,8,ad.all_amount,0))as tele_all,sum(decode(ad.all_id,5,ad.all_amount,0))as Bh_all,sum(decode(ad.all_id,6,ad.all_amount,0))as Bh_ta,sum(decode(ad.all_id,9,ad.all_amount,0)+decode(ad.all_id,27,ad.all_amount,0))as Dist_summer,sum(decode(ad.all_id,10,ad.all_amount,0))as Hp_ta,sum((decode(ad.all_id,1,ad.all_amount,0)+decode(ad.all_id,2,ad.all_amount,0)+decode(ad.all_id,3,ad.all_amount,0)+decode(ad.all_id,4,ad.all_amount,0)+decode(ad.all_id,5,ad.all_amount,0)+decode(ad.all_id,6,ad.all_amount,0)+decode(ad.all_id,7,ad.all_amount,0)+decode(ad.all_id,8,ad.all_amount,0)+decode(ad.all_id,9,ad.all_amount,0)+decode(ad.all_id,10,ad.all_amount,0)+decode(ad.all_id,11,ad.all_amount,0)+decode(ad.all_id,12,ad.all_amount,0)+decode(ad.all_id,13,ad.all_amount,0)+decode(ad.all_id,14,ad.all_amount,0)+decode(ad.all_id,15,ad.all_amount,0)+decode(ad.all_id,16,ad.all_amount,0)+decode(ad.all_id,17,ad.all_amount,0)+decode(ad.all_id,18,ad.all_amount,0)+decode(ad.all_id,19,ad.all_amount,0)+decode(ad.all_id,20,ad.all_amount,0)+decode(ad.all_id,21,ad.all_amount,0)+decode(ad.all_id,22,ad.all_amount,0)+decode(ad.all_id,23,ad.all_amount,0)+decode(ad.all_id,24,ad.all_amount,0)+decode(ad.all_id,25,ad.all_amount,0)+decode(ad.all_id,26,ad.all_amount,0)+decode(ad.all_id,28,ad.all_amount,0)+decode(ad.all_id,29,ad.all_amount,0)+decode(ad.all_id,30,ad.all_amount,0)+decode(ad.all_id,27,ad.all_amount,0)+decode(ad.all_id,31,ad.all_amount,0)+decode(ad.all_id,32,ad.all_amount,0)+decode(ad.all_id,33,ad.all_amount,0)+decode(ad.all_id,34,ad.all_amount,0)+decode(ad.all_id,35,ad.all_amount,0))) as Total,'A.O.VALAPAD' as branchname,0 as branchid from employee_master em,incentives_allowances_dtl ad,hrm_sd_confirmation hsd where ad.emp_code=em.emp_code and ad.emp_code=hsd.emp_code and hsd.all_id=1 and hsd.given_status=1 and ad.status_id=1 and ad.branch_id=0 group by ad.emp_code,em.emp_name order by branchid,branchname,emp_code"
        ElseIf Me.bridfrom = 0 And Me.bridto >= 0 Then
            str = "select ad.emp_code,em.emp_name,sum(decode(ad.all_id,1,ad.all_amount,0))as Fix_ta,sum(decode(ad.all_id,2,ad.all_amount,0))as Act_ta,sum(decode(ad.all_id,3,ad.all_amount,0))as Outstation,sum(decode(ad.all_id,4,ad.all_amount,0))as Abh_All,sum((decode(ad.all_id,7,ad.all_amount,0)+decode(ad.all_id,11,ad.all_amount,0)+decode(ad.all_id,12,ad.all_amount,0)+decode(ad.all_id,13,ad.all_amount,0)+decode(ad.all_id,14,ad.all_amount,0)+decode(ad.all_id,15,ad.all_amount,0)+decode(ad.all_id,16,ad.all_amount,0)+decode(ad.all_id,17,ad.all_amount,0)+decode(ad.all_id,18,ad.all_amount,0)+decode(ad.all_id,19,ad.all_amount,0)+decode(ad.all_id,20,ad.all_amount,0)+decode(ad.all_id,21,ad.all_amount,0)+decode(ad.all_id,22,ad.all_amount,0)+decode(ad.all_id,23,ad.all_amount,0)+decode(ad.all_id,24,ad.all_amount,0)+decode(ad.all_id,25,ad.all_amount,0)+decode(ad.all_id,26,ad.all_amount,0)+decode(ad.all_id,28,ad.all_amount,0)+decode(ad.all_id,29,ad.all_amount,0)+decode(ad.all_id,30,ad.all_amount,0)+decode(ad.all_id,31,ad.all_amount,0)+decode(ad.all_id,32,ad.all_amount,0)+decode(ad.all_id,33,ad.all_amount,0)+decode(ad.all_id,34,ad.all_amount,0)+decode(ad.all_id,35,ad.all_amount,0)))as incentive,sum(decode(ad.all_id,8,ad.all_amount,0))as tele_all,sum(decode(ad.all_id,5,ad.all_amount,0))as Bh_all,sum(decode(ad.all_id,6,ad.all_amount,0))as Bh_ta,sum(decode(ad.all_id,9,ad.all_amount,0)+decode(ad.all_id,27,ad.all_amount,0))as Dist_summer,sum(decode(ad.all_id,10,ad.all_amount,0))as Hp_ta,sum((decode(ad.all_id,1,ad.all_amount,0)+decode(ad.all_id,2,ad.all_amount,0)+decode(ad.all_id,3,ad.all_amount,0)+decode(ad.all_id,4,ad.all_amount,0)+decode(ad.all_id,5,ad.all_amount,0)+decode(ad.all_id,6,ad.all_amount,0)+decode(ad.all_id,7,ad.all_amount,0)+decode(ad.all_id,8,ad.all_amount,0)+decode(ad.all_id,9,ad.all_amount,0)+decode(ad.all_id,10,ad.all_amount,0)+decode(ad.all_id,11,ad.all_amount,0)+decode(ad.all_id,12,ad.all_amount,0)+decode(ad.all_id,13,ad.all_amount,0)+decode(ad.all_id,14,ad.all_amount,0)+decode(ad.all_id,15,ad.all_amount,0)+decode(ad.all_id,16,ad.all_amount,0)+decode(ad.all_id,17,ad.all_amount,0)+decode(ad.all_id,18,ad.all_amount,0)+decode(ad.all_id,19,ad.all_amount,0)+decode(ad.all_id,20,ad.all_amount,0)+decode(ad.all_id,21,ad.all_amount,0)+decode(ad.all_id,22,ad.all_amount,0)+decode(ad.all_id,23,ad.all_amount,0)+decode(ad.all_id,24,ad.all_amount,0)+decode(ad.all_id,25,ad.all_amount,0)+decode(ad.all_id,26,ad.all_amount,0)+decode(ad.all_id,28,ad.all_amount,0)+decode(ad.all_id,29,ad.all_amount,0)+decode(ad.all_id,30,ad.all_amount,0)+decode(ad.all_id,27,ad.all_amount,0)+decode(ad.all_id,31,ad.all_amount,0)+decode(ad.all_id,32,ad.all_amount,0)+decode(ad.all_id,33,ad.all_amount,0)+decode(ad.all_id,34,ad.all_amount,0)+decode(ad.all_id,35,ad.all_amount,0))) as Total,'A.O.VALAPAD(Others)' as branchname,0 as branchid from employee_master em,incentives_allowances_dtl ad,employee_master_dtl ed where  ad.emp_code=em.emp_code and ad.emp_code=ed.emp_code and ed.discont_dt is not null and (ad.status_id in(3,4,6,10) or ad.status_id=5 and ed.new_empcode is null)group by  ad.emp_code,em.emp_name union select ad.emp_code,em.emp_name,sum(decode(ad.all_id,1,ad.all_amount,0))as Fix_ta,sum(decode(ad.all_id,2,ad.all_amount,0))as Act_ta,sum(decode(ad.all_id,3,ad.all_amount,0))as Outstation,sum(decode(ad.all_id,4,ad.all_amount,0))as Abh_All,sum((decode(ad.all_id,7,ad.all_amount,0)+decode(ad.all_id,11,ad.all_amount,0)+decode(ad.all_id,12,ad.all_amount,0)+decode(ad.all_id,13,ad.all_amount,0)+decode(ad.all_id,14,ad.all_amount,0)+decode(ad.all_id,15,ad.all_amount,0)+decode(ad.all_id,16,ad.all_amount,0)+decode(ad.all_id,17,ad.all_amount,0)+decode(ad.all_id,18,ad.all_amount,0)+decode(ad.all_id,19,ad.all_amount,0)+decode(ad.all_id,20,ad.all_amount,0)+decode(ad.all_id,21,ad.all_amount,0)+decode(ad.all_id,22,ad.all_amount,0)+decode(ad.all_id,23,ad.all_amount,0)+decode(ad.all_id,24,ad.all_amount,0)+decode(ad.all_id,25,ad.all_amount,0)+decode(ad.all_id,26,ad.all_amount,0)+decode(ad.all_id,28,ad.all_amount,0)+decode(ad.all_id,29,ad.all_amount,0)+decode(ad.all_id,30,ad.all_amount,0)+decode(ad.all_id,31,ad.all_amount,0)+decode(ad.all_id,32,ad.all_amount,0)+decode(ad.all_id,33,ad.all_amount,0)+decode(ad.all_id,34,ad.all_amount,0)+decode(ad.all_id,35,ad.all_amount,0)))as incentive,sum(decode(ad.all_id,8,ad.all_amount,0))as tele_all,sum(decode(ad.all_id,5,ad.all_amount,0))as Bh_all,sum(decode(ad.all_id,6,ad.all_amount,0))as Bh_ta,sum(decode(ad.all_id,9,ad.all_amount,0)+decode(ad.all_id,27,ad.all_amount,0))as Dist_summer,sum(decode(ad.all_id,10,ad.all_amount,0))as Hp_ta,sum((decode(ad.all_id,1,ad.all_amount,0)+decode(ad.all_id,2,ad.all_amount,0)+decode(ad.all_id,3,ad.all_amount,0)+decode(ad.all_id,4,ad.all_amount,0)+decode(ad.all_id,5,ad.all_amount,0)+decode(ad.all_id,6,ad.all_amount,0)+decode(ad.all_id,7,ad.all_amount,0)+decode(ad.all_id,8,ad.all_amount,0)+decode(ad.all_id,9,ad.all_amount,0)+decode(ad.all_id,10,ad.all_amount,0)+decode(ad.all_id,11,ad.all_amount,0)+decode(ad.all_id,12,ad.all_amount,0)+decode(ad.all_id,13,ad.all_amount,0)+decode(ad.all_id,14,ad.all_amount,0)+decode(ad.all_id,15,ad.all_amount,0)+decode(ad.all_id,16,ad.all_amount,0)+decode(ad.all_id,17,ad.all_amount,0)+decode(ad.all_id,18,ad.all_amount,0)+decode(ad.all_id,19,ad.all_amount,0)+decode(ad.all_id,20,ad.all_amount,0)+decode(ad.all_id,21,ad.all_amount,0)+decode(ad.all_id,22,ad.all_amount,0)+decode(ad.all_id,23,ad.all_amount,0)+decode(ad.all_id,24,ad.all_amount,0)+decode(ad.all_id,25,ad.all_amount,0)+decode(ad.all_id,26,ad.all_amount,0)+decode(ad.all_id,28,ad.all_amount,0)+decode(ad.all_id,29,ad.all_amount,0)+decode(ad.all_id,30,ad.all_amount,0)+decode(ad.all_id,27,ad.all_amount,0)+decode(ad.all_id,31,ad.all_amount,0)+decode(ad.all_id,32,ad.all_amount,0)+decode(ad.all_id,33,ad.all_amount,0)+decode(ad.all_id,34,ad.all_amount,0)+decode(ad.all_id,35,ad.all_amount,0))) as Total,'A.O.VALAPAD' as branchname,0 as branchid from employee_master em,incentives_allowances_dtl ad,hrm_sd_confirmation hsd where ad.emp_code=em.emp_code and ad.emp_code=hsd.emp_code and hsd.all_id=1 and hsd.given_status=1 and ad.status_id=1 and ad.branch_id=0 group by ad.emp_code,em.emp_name union select ad.emp_code,em.emp_name,sum(decode(ad.all_id,1,ad.all_amount,0))as Fix_ta,sum(decode(ad.all_id,2,ad.all_amount,0))as Act_ta,sum(decode(ad.all_id,3,ad.all_amount,0))as Outstation,sum(decode(ad.all_id,4,ad.all_amount,0))as Abh_All,sum((decode(ad.all_id,7,ad.all_amount,0)+decode(ad.all_id,11,ad.all_amount,0)+decode(ad.all_id,12,ad.all_amount,0)+decode(ad.all_id,13,ad.all_amount,0)+decode(ad.all_id,14,ad.all_amount,0)+decode(ad.all_id,15,ad.all_amount,0)+decode(ad.all_id,16,ad.all_amount,0)+decode(ad.all_id,17,ad.all_amount,0)+decode(ad.all_id,18,ad.all_amount,0)+decode(ad.all_id,19,ad.all_amount,0)+decode(ad.all_id,20,ad.all_amount,0)+decode(ad.all_id,21,ad.all_amount,0)+decode(ad.all_id,22,ad.all_amount,0)+decode(ad.all_id,23,ad.all_amount,0)+decode(ad.all_id,24,ad.all_amount,0)+decode(ad.all_id,25,ad.all_amount,0)+decode(ad.all_id,26,ad.all_amount,0)+decode(ad.all_id,28,ad.all_amount,0)+decode(ad.all_id,29,ad.all_amount,0)+decode(ad.all_id,30,ad.all_amount,0)+decode(ad.all_id,31,ad.all_amount,0)+decode(ad.all_id,32,ad.all_amount,0)+decode(ad.all_id,33,ad.all_amount,0)+decode(ad.all_id,34,ad.all_amount,0)+decode(ad.all_id,35,ad.all_amount,0)))as incentive,sum(decode(ad.all_id,8,ad.all_amount,0))as tele_all,sum(decode(ad.all_id,5,ad.all_amount,0))as Bh_all,sum(decode(ad.all_id,6,ad.all_amount,0))as Bh_ta,sum(decode(ad.all_id,9,ad.all_amount,0)+decode(ad.all_id,27,ad.all_amount,0))as Dist_summer,sum(decode(ad.all_id,10,ad.all_amount,0))as Hp_ta,sum((decode(ad.all_id,1,ad.all_amount,0)+decode(ad.all_id,2,ad.all_amount,0)+decode(ad.all_id,3,ad.all_amount,0)+decode(ad.all_id,4,ad.all_amount,0)+decode(ad.all_id,5,ad.all_amount,0)+decode(ad.all_id,6,ad.all_amount,0)+decode(ad.all_id,7,ad.all_amount,0)+decode(ad.all_id,8,ad.all_amount,0)+decode(ad.all_id,9,ad.all_amount,0)+decode(ad.all_id,10,ad.all_amount,0)+decode(ad.all_id,11,ad.all_amount,0)+decode(ad.all_id,12,ad.all_amount,0)+decode(ad.all_id,13,ad.all_amount,0)+decode(ad.all_id,14,ad.all_amount,0)+decode(ad.all_id,15,ad.all_amount,0)+decode(ad.all_id,16,ad.all_amount,0)+decode(ad.all_id,17,ad.all_amount,0)+decode(ad.all_id,18,ad.all_amount,0)+decode(ad.all_id,19,ad.all_amount,0)+decode(ad.all_id,20,ad.all_amount,0)+decode(ad.all_id,21,ad.all_amount,0)+decode(ad.all_id,22,ad.all_amount,0)+decode(ad.all_id,23,ad.all_amount,0)+decode(ad.all_id,24,ad.all_amount,0)+decode(ad.all_id,25,ad.all_amount,0)+decode(ad.all_id,26,ad.all_amount,0)+decode(ad.all_id,28,ad.all_amount,0)+decode(ad.all_id,29,ad.all_amount,0)+decode(ad.all_id,30,ad.all_amount,0)+decode(ad.all_id,27,ad.all_amount,0)+decode(ad.all_id,31,ad.all_amount,0)+decode(ad.all_id,32,ad.all_amount,0)+decode(ad.all_id,33,ad.all_amount,0)+decode(ad.all_id,34,ad.all_amount,0)+decode(ad.all_id,35,ad.all_amount,0))) as Total,bm.branch_name as branchname,hm.verify_br as branchid from employee_master em,incentives_allowances_dtl ad,hrm_employ_verification hm,branch_master bm where ad.emp_code=em.emp_code and ad.emp_code=hm.emp_code and hm.status_id=1 and hm.verify_br=bm.branch_id and hm.verify_br>=" & Me.bridfrom & " and hm.verify_br<=" & Me.bridto & " group by hm.verify_br,bm.branch_name,ad.emp_code,em.emp_name order by branchid,branchname,emp_code"
        ElseIf Me.bridfrom > 0 And Me.bridto > 0 Then
            '                           0                           1                               2                           3                                4                              5                             6_incentive                                                                                                                                                                                                                                                                                                                                                 7                                 8                                  9                        10                        11                                          12                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          13               14
            str = "select ad.emp_code,em.emp_name,sum(decode(ad.all_id,1,ad.all_amount,0))as Fix_ta,sum(decode(ad.all_id,2,ad.all_amount,0))as Act_ta,sum(decode(ad.all_id,3,ad.all_amount,0))as Outstation,sum(decode(ad.all_id,4,ad.all_amount,0))as Abh_All,sum((decode(ad.all_id,7,ad.all_amount,0)+decode(ad.all_id,11,ad.all_amount,0)+decode(ad.all_id,12,ad.all_amount,0)+decode(ad.all_id,13,ad.all_amount,0)+decode(ad.all_id,14,ad.all_amount,0)+decode(ad.all_id,15,ad.all_amount,0)+decode(ad.all_id,16,ad.all_amount,0)+decode(ad.all_id,17,ad.all_amount,0)+decode(ad.all_id,18,ad.all_amount,0)+decode(ad.all_id,19,ad.all_amount,0)+decode(ad.all_id,20,ad.all_amount,0)+decode(ad.all_id,21,ad.all_amount,0)+decode(ad.all_id,22,ad.all_amount,0)+decode(ad.all_id,23,ad.all_amount,0)+decode(ad.all_id,24,ad.all_amount,0)+decode(ad.all_id,25,ad.all_amount,0)+decode(ad.all_id,26,ad.all_amount,0)+decode(ad.all_id,28,ad.all_amount,0)+decode(ad.all_id,29,ad.all_amount,0)+decode(ad.all_id,30,ad.all_amount,0)+decode(ad.all_id,31,ad.all_amount,0)+decode(ad.all_id,32,ad.all_amount,0)+decode(ad.all_id,33,ad.all_amount,0)+decode(ad.all_id,34,ad.all_amount,0)+decode(ad.all_id,35,ad.all_amount,0)))as incentive,sum(decode(ad.all_id,8,ad.all_amount,0))as tele_all,sum(decode(ad.all_id,5,ad.all_amount,0))as Bh_all,sum(decode(ad.all_id,6,ad.all_amount,0))as Bh_ta,sum(decode(ad.all_id,9,ad.all_amount,0)+decode(ad.all_id,27,ad.all_amount,0))as Dist_summer,sum(decode(ad.all_id,10,ad.all_amount,0))as Hp_ta,sum((decode(ad.all_id,1,ad.all_amount,0)+decode(ad.all_id,2,ad.all_amount,0)+decode(ad.all_id,3,ad.all_amount,0)+decode(ad.all_id,4,ad.all_amount,0)+decode(ad.all_id,5,ad.all_amount,0)+decode(ad.all_id,6,ad.all_amount,0)+decode(ad.all_id,7,ad.all_amount,0)+decode(ad.all_id,8,ad.all_amount,0)+decode(ad.all_id,9,ad.all_amount,0)+decode(ad.all_id,10,ad.all_amount,0)+decode(ad.all_id,11,ad.all_amount,0)+decode(ad.all_id,12,ad.all_amount,0)+decode(ad.all_id,13,ad.all_amount,0)+decode(ad.all_id,14,ad.all_amount,0)+decode(ad.all_id,15,ad.all_amount,0)+decode(ad.all_id,16,ad.all_amount,0)+decode(ad.all_id,17,ad.all_amount,0)+decode(ad.all_id,18,ad.all_amount,0)+decode(ad.all_id,19,ad.all_amount,0)+decode(ad.all_id,20,ad.all_amount,0)+decode(ad.all_id,21,ad.all_amount,0)+decode(ad.all_id,22,ad.all_amount,0)+decode(ad.all_id,23,ad.all_amount,0)+decode(ad.all_id,24,ad.all_amount,0)+decode(ad.all_id,25,ad.all_amount,0)+decode(ad.all_id,26,ad.all_amount,0)+decode(ad.all_id,28,ad.all_amount,0)+decode(ad.all_id,29,ad.all_amount,0)+decode(ad.all_id,30,ad.all_amount,0)+decode(ad.all_id,27,ad.all_amount,0)+decode(ad.all_id,31,ad.all_amount,0)+decode(ad.all_id,32,ad.all_amount,0)+decode(ad.all_id,33,ad.all_amount,0)+decode(ad.all_id,34,ad.all_amount,0)+decode(ad.all_id,35,ad.all_amount,0))) as Total,bm.branch_name as branchname,hm.verify_br as branchid from employee_master em,incentives_allowances_dtl ad,hrm_employ_verification hm,branch_master bm where ad.emp_code=em.emp_code and ad.emp_code=hm.emp_code and hm.status_id=1 and hm.verify_br=bm.branch_id and hm.verify_br>=" & Me.bridfrom & " and hm.verify_br<=" & Me.bridto & " group by hm.verify_br,bm.branch_name,ad.emp_code,em.emp_name order by branchid,branchname,emp_code"

        End If

        dt = oh.ExecuteDataSet(str).Tables(0)


        Dim header As New TableRow
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        header.Width = 13
        Dim headercell As New TableCell
        headercell.ColumnSpan = 13
        headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headercell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headercell)
        tatble.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.BackColor = Drawing.Color.LightGray
        Dim sheadercell1 As New TableCell
        Dim sheadercell2 As New TableCell

        sheadercell1.ColumnSpan = 13
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        tatble.Controls.Add(sheader)

        ' fieldtitle(br)


        Dim branchname As String = ""
        Dim bid As Double = -9999


        For Each dr In dt.Rows

            reccount += 1

            If reccount > 66 Then
                pagenext()

                pagenonext += 1
                numbering(pagenonext)

                reccount = 0


            End If



            If bid = -9999 Or branchname <> dr(13) Then

                '//////////////////////////////////////////////////////////////

                If bid <> -9999 Then

                    branchtotal()
                    i = 0
                    pagenext()
                    reccount = 0
                    pagenonext += 1
                    numbering(pagenonext)
                    'fieldtitle()
                End If

                ' br = dr(13).ToString

                headertext()
                reccount += 2


                Dim rrb As New TableRow
                rrb.Width = 13
                rrb.ForeColor = Drawing.Color.Black
                ' rrb.BackColor = Drawing.Color.Lavender
                Dim rrb1 As New TableCell
                rrb1.ColumnSpan = 13
                rrb1.HorizontalAlign = HorizontalAlign.Center

                rrb1.Text = "<b><u><font size=3>Allowances,incentives and others of &nbsp;:&nbsp;&nbsp;" & dr(13) & "</font></u></b>"

                rrb.Controls.Add(rrb1)
                tatble.Controls.Add(rrb)
                reccount += 1

                fieldtitle()
                reccount += 3

                fixedta = 0
                actualta = 0
                outstation = 0
                abhallowance = 0
                incentive = 0
                teleallowance = 0
                bhallowance = 0
                bhta = 0
                distallowance = 0
                hpta = 0
                total = 0



                str2 = "select nvl(cg.cash,0) as cash,nvl(cg.gold,0) as gold from cash_gold cg where cg.branch_id=" & dr(14) & ""
                dt2 = oh.ExecuteDataSet(str2).Tables(0)


            End If

            branchname = dr(13)
            bid = dr(14)





            '  //////////////////////////////////////////
            'End If

            Dim drow As New TableRow
            drow.Width = 13
            'drow.Attributes.Add("bgcolor", colors)
            Dim d1, da, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, d13 As New TableCell

            i = i + 1


            'd1.Text = "<emp_code=" & dr(0) & "><font size=2>" & dr(0) & "***" & dr(1) & "</font></a>"
            d2.ColumnSpan = 1
            d2.Text = "<font size=2><b>" & dr(0) & "&nbsp;</font>"
            d2.HorizontalAlign = HorizontalAlign.Left
            drow.Controls.Add(d2)

            da.ColumnSpan = 1
            da.Text = "<a><font size=2>" & dr(1) & "&nbsp;</font></a>"
            da.HorizontalAlign = HorizontalAlign.Left
            drow.Controls.Add(da)

            '/////fixed ta
            d3.ColumnSpan = 1
            d3.Text = "<a><font size=2>" & dr(2) & "&nbsp;</font></a>"
            d3.HorizontalAlign = HorizontalAlign.Right
            drow.Controls.Add(d3)
            fixedta += dr(2)


            '////actual ta
            d4.ColumnSpan = 1
            d4.Text = "<a><font size=2>" & dr(3) & "&nbsp;</font></a>"
            d4.HorizontalAlign = HorizontalAlign.Right
            drow.Controls.Add(d4)
            actualta += dr(3)


            '///outstation
            d5.ColumnSpan = 1
            d5.Text = "<a><font size=2>" & dr(4) & "&nbsp;</font></a>"
            d5.HorizontalAlign = HorizontalAlign.Right
            drow.Controls.Add(d5)
            outstation += dr(4)

            '/////////abh all
            d6.ColumnSpan = 1
            d6.Text = "<a><font size=2>" & dr(5) & "&nbsp;</font></a>"
            d6.HorizontalAlign = HorizontalAlign.Right
            drow.Controls.Add(d6)
            abhallowance += dr(5)



            '////////incentive
            d7.ColumnSpan = 1
            d7.Text = "<a><font size=2>" & dr(6) & "&nbsp;</font></a>"
            d7.HorizontalAlign = HorizontalAlign.Right
            drow.Controls.Add(d7)
            incentive += dr(6)

            '/////Tele_all
            d8.ColumnSpan = 1
            d8.Text = "<a><font size=2>" & dr(7) & "&nbsp;</font></a>"
            d8.HorizontalAlign = HorizontalAlign.Right
            drow.Controls.Add(d8)
            teleallowance += dr(7)

            '/bh_allo
            d9.ColumnSpan = 1
            d9.Text = "<a><font size=2>" & dr(8) & "&nbsp;</font></a>"
            d9.HorizontalAlign = HorizontalAlign.Right
            drow.Controls.Add(d9)
            bhallowance += dr(8)

            '/bh_Ta
            d10.ColumnSpan = 1
            d10.Text = "<a><font size=2>" & dr(9) & "&nbsp;</font></a>"
            d10.HorizontalAlign = HorizontalAlign.Right
            drow.Controls.Add(d10)
            bhta += dr(9)

            '//dist/summ_alll
            d11.ColumnSpan = 1
            d11.Text = "<a><font size=2>" & dr(10) & "&nbsp;</font></a>"
            d11.HorizontalAlign = HorizontalAlign.Right
            drow.Controls.Add(d11)
            distallowance += dr(10)

            '//////////hp_ta
            d12.ColumnSpan = 1
            d12.Text = "<a><font size=2>" & dr(11) & "&nbsp;</font></a>"
            d12.HorizontalAlign = HorizontalAlign.Right
            drow.Controls.Add(d12)
            hpta += dr(11)

            '///////////total
            d13.ColumnSpan = 1
            d13.Text = "<a><font size=2>" & dr(12) & "&nbsp;</font></a>"
            d13.HorizontalAlign = HorizontalAlign.Right
            drow.Controls.Add(d13)
            total += dr(12)



            tatble.Controls.Add(drow)

            Dim space As New TableRow
            space.Width = 13
            Dim ss As New TableCell
            ss.ColumnSpan = 13
            ss.Text = " "
            space.Controls.Add(ss)
            tatble.Controls.Add(space)
            reccount += 1

        Next

        branchtotal()
        i = 0

        '////////////for next page

        '  pagenext()

        Pan_ta.Controls.Add(tatble)
    End Sub
    Sub headertext()
        Dim s As String = oh.ExecuteDataSet("select distinct to_char(to_date(s.sal_dt),'MONTH') from salari s").Tables(0).Rows(0)(0)

        Dim y As Integer = oh.ExecuteDataSet("select distinct to_char(to_date(s.sal_dt),'YYYY') from salari s").Tables(0).Rows(0)(0)

        Dim tt As New TableRow
        tt.BackColor = Drawing.Color.LightSkyBlue
        tt.Width = 13
        Dim tt1 As New TableCell
        tt1.ColumnSpan = 13
        tt1.HorizontalAlign = HorizontalAlign.Center
        tt1.Text = "<b><font size=3>Allowances,Incentives and others Report of " & s & " " & y & "</font></b>"
        tt.Controls.Add(tt1)
        tatble.Controls.Add(tt)

        Dim subh As New TableRow
        ' subh.BackColor = Drawing.Color.LightCoral
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 13

        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 2
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 8
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subh.Controls.Add(subcell2)
        subcell3.ColumnSpan = 3
        subcell3.HorizontalAlign = HorizontalAlign.Left
        'subcell3.Text = "<font size=2><b><div id= txt align= right></div></b></font></div>"
        subcell3.Text = "<b><font size=2> Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)
        tatble.Controls.Add(subh)

        Dim line As New TableRow
        Dim linecell As New TableCell
        linecell.ColumnSpan = 13
        linecell.Text = "<hr>"
        line.Controls.Add(linecell)
        tatble.Controls.Add(line)

    End Sub

    Sub fieldtitle()



        Dim row2 As New TableRow
        row2.Width = 13
        'row2.Attributes.Add("bgcolor", colors)
        Dim si As New TableCell
        Dim h1 As New TableCell
        Dim ha As New TableCell
        Dim h2 As New TableCell
        Dim h3 As New TableCell
        Dim h4 As New TableCell
        Dim h5 As New TableCell
        Dim h6 As New TableCell
        Dim h7 As New TableCell
        Dim h8 As New TableCell
        Dim h9 As New TableCell
        Dim h10 As New TableCell
        Dim h11 As New TableCell
        Dim h12 As New TableCell
        Dim h13 As New TableCell

        

        h1.ColumnSpan = 1
        h1.Text = "<b><font size=2>EmpCode</font></b>"
        h1.HorizontalAlign = HorizontalAlign.Left
        row2.Controls.Add(h1)

        ha.ColumnSpan = 1
        ha.Text = "<b><font size=2>EmpName</font></b>"
        ha.HorizontalAlign = HorizontalAlign.Left
        row2.Controls.Add(ha)

        h2.ColumnSpan = 1
        h2.Text = "<b><font size=2>Fix TA&nbsp</font></b>"
        h2.HorizontalAlign = HorizontalAlign.Center
        row2.Controls.Add(h2)
        h3.ColumnSpan = 1
        h3.Text = "<b><font size=2>Act TA&nbsp;</font></b>"
        h3.HorizontalAlign = HorizontalAlign.Center
        row2.Controls.Add(h3)
        h4.ColumnSpan = 1
        h4.Text = "<b><font size=2>Outstation </font></b>"
        h4.HorizontalAlign = HorizontalAlign.Center
        row2.Controls.Add(h4)
        h5.ColumnSpan = 1
        h5.Text = "<b><font size=2>A.B.H(G) All&nbsp;</font></b>"
        h5.HorizontalAlign = HorizontalAlign.Center
        row2.Controls.Add(h5)
        h6.ColumnSpan = 1
        h6.Text = "<b><font size=2>Incentive&nbsp;</font></b>"
        h6.HorizontalAlign = HorizontalAlign.Center
        row2.Controls.Add(h6)

        h7.ColumnSpan = 1
        h7.Text = "<b><font size=2>Tele All&nbsp;</font></b>"
        h7.HorizontalAlign = HorizontalAlign.Center
        row2.Controls.Add(h7)

        h8.ColumnSpan = 1
        h8.Text = "<b><font size=2>BH(G) All</font></b>"
        h8.HorizontalAlign = HorizontalAlign.Center
        row2.Controls.Add(h8)

        h9.ColumnSpan = 1
        h9.Text = "<b><font size=2>B.H(G)&nbsp; TA</font></b>"
        h9.HorizontalAlign = HorizontalAlign.Center
        row2.Controls.Add(h9)

        h10.ColumnSpan = 1
        h10.Text = "<b><font size=2>Dist/Sum&nbsp; All</font></b>"
        h10.HorizontalAlign = HorizontalAlign.Center
        row2.Controls.Add(h10)

        h11.ColumnSpan = 1
        h11.Text = "<b><font size=2>HP TA&nbsp;</font></b>"
        h11.HorizontalAlign = HorizontalAlign.Center
        row2.Controls.Add(h11)

        h12.ColumnSpan = 1
        h12.Text = "<b><font size=2>Total&nbsp;</font></b>"
        h12.HorizontalAlign = HorizontalAlign.Center
        row2.Controls.Add(h12)

        tatble.Controls.Add(row2)

        Dim line3 As New TableRow
        Dim linecell3 As New TableCell
        linecell3.ColumnSpan = 13
        linecell3.Text = "<hr>"
        line3.Controls.Add(linecell3)
        tatble.Controls.Add(line3)

    End Sub
    Sub branchtotal()

        Dim line4 As New TableRow
        Dim linecell4 As New TableCell
        linecell4.ColumnSpan = 13
        linecell4.Text = "<hr>"
        line4.Controls.Add(linecell4)
        tatble.Controls.Add(line4)

        Dim totalta As New TableRow
        totalta.Width = 13
        Dim totalcell, cfixta, cactta, coutst, cabhall, cincent, cteleall, cbhallo, cbhta, cdistall, chpta, sum As New TableCell

        totalcell.ColumnSpan = 1
        totalcell.HorizontalAlign = HorizontalAlign.Left
        totalcell.Text = "<b><font size=2>Total:&nbsp;" & i & "&nbsp;Employees&nbsp;</font></b>"
        totalta.Controls.Add(totalcell)

        cfixta.ColumnSpan = 1
        cfixta.HorizontalAlign = HorizontalAlign.Right
        cfixta.Text = "<b><font size=2>" & fixedta & "</font></b>"
        totalta.Controls.Add(cfixta)

        cactta.ColumnSpan = 1
        cactta.HorizontalAlign = HorizontalAlign.Right
        cactta.Text = "<b><font size=2>" & actualta & "</font></b>"
        totalta.Controls.Add(cactta)

        coutst.ColumnSpan = 1
        coutst.HorizontalAlign = HorizontalAlign.Right
        coutst.Text = "<b><font size=2>" & outstation & "</font></b>"
        totalta.Controls.Add(coutst)

        cabhall.ColumnSpan = 1
        cabhall.HorizontalAlign = HorizontalAlign.Right
        cabhall.Text = "<b><font size=2>" & abhallowance & "</font></b>"
        totalta.Controls.Add(cabhall)

        cincent.ColumnSpan = 1
        cincent.HorizontalAlign = HorizontalAlign.Right
        cincent.Text = "<b><font size=2>" & incentive & "</font></b>"
        totalta.Controls.Add(cincent)

        cteleall.ColumnSpan = 1
        cteleall.HorizontalAlign = HorizontalAlign.Right
        cteleall.Text = "<b><font size=2>" & teleallowance & "</font></b>"
        totalta.Controls.Add(cteleall)


        cbhallo.ColumnSpan = 1
        cbhallo.HorizontalAlign = HorizontalAlign.Right
        cbhallo.Text = "<b><font size=2>" & bhallowance & "</font></b>"
        totalta.Controls.Add(cbhallo)

        cbhta.ColumnSpan = 1
        cbhta.HorizontalAlign = HorizontalAlign.Right
        cbhta.Text = "<b><font size=2>" & bhta & "</font></b>"
        totalta.Controls.Add(cbhta)

        cdistall.ColumnSpan = 1
        cdistall.HorizontalAlign = HorizontalAlign.Right
        cdistall.Text = "<b><font size=2>" & distallowance & "</font></b>"
        totalta.Controls.Add(cdistall)

        chpta.ColumnSpan = 1
        chpta.HorizontalAlign = HorizontalAlign.Right
        chpta.Text = "<b><font size=2>" & hpta & "</font></b>"
        totalta.Controls.Add(chpta)

        sum.ColumnSpan = 2
        sum.HorizontalAlign = HorizontalAlign.Right
        sum.Text = "<b><font size=2>" & total & "</font></b>"
        totalta.Controls.Add(sum)

        tatble.Controls.Add(totalta)

        '///////////////////////////



      
        Dim lineq As New TableRow
        Dim linecellq As New TableCell
        linecellq.ColumnSpan = 13
        linecellq.Text = "<hr>"
        lineq.Controls.Add(linecellq)
        tatble.Controls.Add(lineq)

        If dt2.Rows.Count > 0 Then

            Dim cago As New TableRow
            cago.Width = 13
            Dim cg1, cg2 As New TableCell

            cg1.ColumnSpan = 4
            cg1.HorizontalAlign = HorizontalAlign.Center
            cg1.Text = "<b><font size=2>Cash:&nbsp;&nbsp;" & dt2.Rows(0)(0) & "</font></b>"
            cago.Controls.Add(cg1)

            cg2.ColumnSpan = 9
            cg2.HorizontalAlign = HorizontalAlign.Center
            cg2.Text = "<b><font size=2>Gold:&nbsp;&nbsp;" & dt2.Rows(0)(1) & "</font></b>"
            cago.Controls.Add(cg2)

            tatble.Controls.Add(cago)
        Else

            Dim cago As New TableRow
            cago.Width = 13
            Dim cg1, cg2 As New TableCell

            cg1.ColumnSpan = 4
            cg1.HorizontalAlign = HorizontalAlign.Center
            cg1.Text = "<b><font size=2>Cash:&nbsp;&nbsp;0</font></b>"
            cago.Controls.Add(cg1)

            cg2.ColumnSpan = 9
            cg2.HorizontalAlign = HorizontalAlign.Center
            cg2.Text = "<b><font size=2>Gold:&nbsp;&nbsp;0</font></b>"
            cago.Controls.Add(cg2)

            tatble.Controls.Add(cago)
        End If





        Dim last As New TableRow
        Dim last1 As New TableCell
        last1.ColumnSpan = 13
        last1.Text = "<hr>"
        last.Controls.Add(last1)
        tatble.Controls.Add(last)

        Dim aaw As New TableRow
        aaw.Width = 13
        Dim prepare, prepare1, verify, verify1, approve, approve1 As New TableCell

        prepare.ColumnSpan = 2
        prepare.HorizontalAlign = HorizontalAlign.Center
        prepare.Text = "<font size=2>Prepared By </font>"
        aaw.Controls.Add(prepare)

        prepare1.ColumnSpan = 2
        prepare1.HorizontalAlign = HorizontalAlign.Center
        prepare1.Text = " "
        aaw.Controls.Add(prepare1)

        verify.ColumnSpan = 2
        verify.HorizontalAlign = HorizontalAlign.Center
        verify.Text = "<font size=2>Verified By </font>"
        aaw.Controls.Add(verify)

        verify1.ColumnSpan = 2
        verify1.HorizontalAlign = HorizontalAlign.Center
        verify1.Text = " "
        aaw.Controls.Add(verify1)

        approve.ColumnSpan = 2
        approve.HorizontalAlign = HorizontalAlign.Center
        approve.Text = "<font size=2>Approved By </font>"
        aaw.Controls.Add(approve)

        approve1.ColumnSpan = 3
        approve1.HorizontalAlign = HorizontalAlign.Center
        approve1.Text = ""
        aaw.Controls.Add(approve1)

        tatble.Controls.Add(aaw)


        Dim foot1 As New TableRow
        Dim foot1a As New TableCell
        foot1a.ColumnSpan = 13
        foot1a.Text = "<hr>"
        foot1.Controls.Add(foot1a)
        tatble.Controls.Add(foot1)

    End Sub
    Sub pagenext()
        Dim pgebrk As New TableRow
        pgebrk.Width = 13
        Dim pgebrk1 As New TableCell
        pgebrk1.ColumnSpan = 13
        pgebrk1.HorizontalAlign = HorizontalAlign.Center
        pgebrk1.Text = "<DIV style=page-break-after:always></DIV>"
        pgebrk.Controls.Add(pgebrk1)
        tatble.Controls.Add(pgebrk)
    End Sub
    Private Function numbering(ByVal a) As Integer

        Dim ar As New TableRow
        ar.Width = 13
        Dim ar1 As New TableCell
        ar1.ColumnSpan = 13
        ar1.HorizontalAlign = HorizontalAlign.Right
        ar1.Text = "<font size=2>Page Number :" & a & "</font>"
        ar.Controls.Add(ar1)
        tatble.Controls.Add(ar)

    End Function
End Class
