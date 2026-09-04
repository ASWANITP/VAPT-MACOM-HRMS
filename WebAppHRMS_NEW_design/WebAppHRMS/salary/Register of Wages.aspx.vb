Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class Register_of_Wages_b3ab4c232243
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt1 As DataTable
    Dim aj_report As New ReportDocument
    Dim export As New IO.MemoryStream
    Dim fid, brid As String

    Protected Sub Page_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.aj_report.Close()
        Me.aj_report.Dispose()
        GC.Collect()
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim aj1 As String = Me.Request.QueryString("aj")
        brid = Session("branch_id").ToString

        ''dt1 = oh.ExecuteDataSet("select em.emp_name    as Name_of_the_Employee,mw.fat_hus     as Fathers_Husbands_Name, dm.designation as Designation,  mw.basic_pay   as Min_Basic,  mw.vda         as Min_DA,  mw.basic_pay   as Act_Basic,  mw.vda         as Act_DA,  mw.w_days as Tot_attendance,  mw.gross_sal as Gross_wages_payable,  mw.remark_ded as Ded_Emp_Contribution,  mw.oth_ded as Other_Deduction,  mw.tot_dedu as Total_Deduction,  mw.wages_pble as Wages_Paid,  mw.sal_dt as Date_Of_Payment    from employee_master em, m_wage mw, designation_master dm,employ_firm ef,branch_master bm     where    em.emp_code = mw.emp_code and  em.designation_id = dm.designation_id and  em.emp_code = ef.emp_code  and bm.branch_id = em.branch_id and  ef.firm_id = '" & Session("firm_id") & "' and bm.branch_id = '" & Session("branch_id") & "'   order by em.emp_code ").Tables(0)
        'If brid = 0 Then
        '    dt1 = oh.ExecuteDataSet("select em.emp_name    as Name_of_the_Employee,     mw.fat_hus     as Fathers_Husbands_Name,       dm.designation as Designation,       mw.basic_pay   as Min_Basic,       mw.vda         as Min_DA,       mw.basic_pay   as Act_Basic,       mw.vda         as Act_DA,       mw.w_days      as Tot_attendance,        mw.p_fund + mw.esi as DED_EMP_CONTRIBUTION,       mw.gross_sal   as Gross_wages_payable,       /*mw.remark_ded  as Ded_Emp_Contribution,*/       mw.oth_ded     as Other_Deduction,       mw.tot_dedu    as Total_Deduction,       mw.wages_pble  as Wages_Paid,       mw.sal_dt      as Date_Of_Payment        from employee_master    em,       m_wage             mw,       designation_master dm,       employ_firm        ef,       branch_master      bm where em.emp_code = mw.emp_code   and em.designation_id = dm.designation_id   and em.emp_code = ef.emp_code   and bm.branch_id = em.branch_id   and ef.firm_id = '" & Session("firm_id") & "'   order by em.emp_code,,bm.branch_id").Tables(0)
        'Else
        '    dt1 = oh.ExecuteDataSet("select em.emp_name    as Name_of_the_Employee,     mw.fat_hus     as Fathers_Husbands_Name,       dm.designation as Designation,       mw.basic_pay   as Min_Basic,       mw.vda         as Min_DA,       mw.basic_pay   as Act_Basic,       mw.vda         as Act_DA,       mw.w_days      as Tot_attendance,        mw.p_fund + mw.esi as DED_EMP_CONTRIBUTION,       mw.gross_sal   as Gross_wages_payable,       /*mw.remark_ded  as Ded_Emp_Contribution,*/       mw.oth_ded     as Other_Deduction,       mw.tot_dedu    as Total_Deduction,       mw.wages_pble  as Wages_Paid,       mw.sal_dt      as Date_Of_Payment        from employee_master    em,       m_wage             mw,       designation_master dm,       employ_firm        ef,       branch_master      bm where em.emp_code = mw.emp_code   and em.designation_id = dm.designation_id   and em.emp_code = ef.emp_code   and bm.branch_id = em.branch_id   and ef.firm_id = '" & Session("firm_id") & "'   and bm.branch_id = '" & Session("branch_id") & "'  order by em.emp_code").Tables(0)
        'End If
        'aj_report.Load(Server.MapPath("Register_Of_Wages_Crystal.rpt"), OpenReportMethod.OpenReportByTempCopy)

        fid = Session("firm_id").ToString
        'dt1 = oh.ExecuteDataSet("select em.emp_name    as Name_of_the_Employee,mw.fat_hus     as Fathers_Husbands_Name, dm.designation as Designation,  mw.basic_pay   as Min_Basic,  mw.vda         as Min_DA,  mw.basic_pay   as Act_Basic,  mw.vda         as Act_DA,  mw.w_days as Tot_attendance,  mw.gross_sal as Gross_wages_payable,  mw.remark_ded as Ded_Emp_Contribution,  mw.oth_ded as Other_Deduction,  mw.tot_dedu as Total_Deduction,  mw.wages_pble as Wages_Paid,  mw.sal_dt as Date_Of_Payment    from employee_master em, m_wage mw, designation_master dm,employ_firm ef,branch_master bm     where    em.emp_code = mw.emp_code and  em.designation_id = dm.designation_id and  em.emp_code = ef.emp_code  and bm.branch_id = em.branch_id and  ef.firm_id = '" & Session("firm_id") & "' and bm.branch_id = '" & Session("branch_id") & "'   order by em.emp_code ").Tables(0)
        If (fid = 6) Or (fid = 14) Or (fid = 31) Or (fid = 32) Then
            dt1 = oh.ExecuteDataSet("select bm.branch_name, em.emp_name    as Name_of_the_Employee,     mw.fat_hus     as Fathers_Husbands_Name,       dm.designation as Designation,       mw.basic_pay   as Min_Basic,       mw.vda         as Min_DA,       mw.basic_pay   as Act_Basic,       mw.vda         as Act_DA,       mw.w_days      as Tot_attendance,        mw.p_fund + mw.esi as DED_EMP_CONTRIBUTION,       mw.gross_sal   as Gross_wages_payable,       /*mw.remark_ded  as Ded_Emp_Contribution,*/       mw.oth_ded     as Other_Deduction,       mw.tot_dedu    as Total_Deduction,       mw.wages_pble  as Wages_Paid,       mw.sal_dt      as Date_Of_Payment        from employee_master    em,       m_wage             mw,       designation_master dm,       employ_firm        ef,       branch_master      bm where em.emp_code = mw.emp_code   and em.designation_id = dm.designation_id   and em.emp_code = ef.emp_code   and bm.branch_id = em.branch_id   and ef.firm_id in(6,14,31,32)  order by bm.branch_id").Tables(0)
            aj_report.Load(Server.MapPath("Register_Of_Wages_Crystal1.rpt"), OpenReportMethod.OpenReportByTempCopy)
        ElseIf brid = 0 Then
            dt1 = oh.ExecuteDataSet("select em.emp_name    as Name_of_the_Employee,     mw.fat_hus     as Fathers_Husbands_Name,       dm.designation as Designation,       mw.basic_pay   as Min_Basic,       mw.vda         as Min_DA,       mw.basic_pay   as Act_Basic,       mw.vda         as Act_DA,       mw.w_days      as Tot_attendance,        mw.p_fund + mw.esi as DED_EMP_CONTRIBUTION,       mw.gross_sal   as Gross_wages_payable,       /*mw.remark_ded  as Ded_Emp_Contribution,*/       mw.oth_ded     as Other_Deduction,       mw.tot_dedu    as Total_Deduction,       mw.wages_pble  as Wages_Paid,       mw.sal_dt      as Date_Of_Payment        from employee_master    em,       m_wage             mw,       designation_master dm,       employ_firm        ef,       branch_master      bm where em.emp_code = mw.emp_code   and em.designation_id = dm.designation_id   and em.emp_code = ef.emp_code   and bm.branch_id = em.branch_id   and ef.firm_id = '" & Session("firm_id") & "'   order by em.emp_code,bm.branch_id").Tables(0)
            aj_report.Load(Server.MapPath("Register_Of_Wages_Crystal.rpt"), OpenReportMethod.OpenReportByTempCopy)


        Else
            dt1 = oh.ExecuteDataSet("select em.emp_name    as Name_of_the_Employee,     mw.fat_hus     as Fathers_Husbands_Name,       dm.designation as Designation,       mw.basic_pay   as Min_Basic,       mw.vda         as Min_DA,       mw.basic_pay   as Act_Basic,       mw.vda         as Act_DA,       mw.w_days      as Tot_attendance,        mw.p_fund + mw.esi as DED_EMP_CONTRIBUTION,       mw.gross_sal   as Gross_wages_payable,       /*mw.remark_ded  as Ded_Emp_Contribution,*/       mw.oth_ded     as Other_Deduction,       mw.tot_dedu    as Total_Deduction,       mw.wages_pble  as Wages_Paid,       mw.sal_dt      as Date_Of_Payment        from employee_master    em,       m_wage             mw,       designation_master dm,       employ_firm        ef,       branch_master      bm where em.emp_code = mw.emp_code   and em.designation_id = dm.designation_id   and em.emp_code = ef.emp_code   and bm.branch_id = em.branch_id   and ef.firm_id = '" & Session("firm_id") & "'   and bm.branch_id = '" & Session("branch_id") & "'  order by em.emp_code").Tables(0)
            aj_report.Load(Server.MapPath("Register_Of_Wages_Crystal.rpt"), OpenReportMethod.OpenReportByTempCopy)


        End If


        aj_report.Database.Tables("Wages").SetDataSource(dt1)
        aj_report.SetParameterValue("BRANCH", Session("branch_name"))
        aj_report.SetParameterValue("FIRM", Session("firm_name"))
        Me.CrystalReportViewer1.DisplayGroupTree = False

        Me.CrystalReportViewer1.ReportSource = aj_report


        export = aj_report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/pdf"
        Response.BinaryWrite(export.ToArray())
        Response.End()


    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Me.aj_report.Close()
        Me.aj_report.Dispose()
        GC.Collect()
    End Sub
End Class
