Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class PF_REPORT_pfform6a_crpt_659b03062374
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim report As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim currentdt As DataTable = oh.ExecuteDataSet("select to_char(sysdate,'MM'),to_char(sysdate,'YYYY') from dual").Tables(0)
        Dim date1, date2 As String
        Dim year1, year2 As String
        If currentdt.Rows(0)(0) < 12 And currentdt.Rows(0)(0) > 4 Then
            date1 = "1/MAR/" & currentdt.Rows(0)(1)
            date2 = "28/FEB/" & currentdt.Rows(0)(1) + 1
            year1 = currentdt.Rows(0)(1)
            year2 = currentdt.Rows(0)(1) + 1
        Else
            date1 = "1/MAR/" & currentdt.Rows(0)(1) - 1
            date2 = "28/FEB/" & currentdt.Rows(0)(1)
            year1 = currentdt.Rows(0)(1) - 1
            year2 = currentdt.Rows(0)(1)
        End If

        Dim dt As DataTable
        'Dim st As String = "select p.pf_accno,upper(p.emp_name) as emp_name,p.pf_sal_tot,p.e_pf_tot,p.ac_no1_tot,p.ac_no2_tot,p.dis_dt,p.status,p.emp_code from pf_details p where status_id=1 or (join_dt>=to_date('1/mar/2008') and join_dt<to_date('28/feb/2009')) or (enter_dt>=to_date('1/mar/2008') and enter_dt<to_date('28/feb/2009')) order by p.emp_code"
        '---correct
        'Dim st As String = "select p.pf_accno,upper(p.emp_name) as emp_name,sum(pf_sal) as pf_sal_tot,sum(e_pf) as e_pf_tot,sum(ac_no1) as ac_no1_tot, sum(ac_no2) as ac_no2_tot,dis_dt,status,emp_code from pf_details p where status_id=1 or (join_dt>=to_date('1/mar/2008') and join_dt<to_date('28/feb/2009')) or (enter_dt>=to_date('1/mar/2008') and enter_dt<to_date('28/feb/2009')) group by emp_code,emp_name,father_name,firm_name,pf_accno,status_id ,dis_dt,status order by emp_code"
        Dim st As String = ""
        'If Me.Request.QueryString("firm") = 1 Then
        '    st = "select substr(p.pf_accno,13,10) as pf_accno,upper(p.emp_name) as emp_name,sum(pf_sal) as pf_sal_tot,sum(e_pf) as e_pf_tot,sum(ac_no1) as ac_no1_tot, sum(ac_no2) as ac_no2_tot,dis_dt,status,emp_code from pf_details p where firm_id=1 and (status_id=1 or (join_dt>=to_date('" & date1 & "') and join_dt<=to_date('" & date2 & "')) or (enter_dt>=to_date('" & date1 & "') and enter_dt<=to_date('" & date2 & "'))) group by emp_code,emp_name,father_name,firm_name,pf_accno,status_id ,dis_dt,status order by emp_code"
        'Else
        '    st = "select substr(p.pf_accno,13,10) as pf_accno,upper(p.emp_name) as emp_name,sum(pf_sal) as pf_sal_tot,sum(e_pf) as e_pf_tot,sum(ac_no1) as ac_no1_tot, sum(ac_no2) as ac_no2_tot,dis_dt,status,emp_code from pf_details p where firm_id in(2,3) and (status_id=1 or (join_dt>=to_date('" & date1 & "') and join_dt<=to_date('" & date2 & "')) or (enter_dt>=to_date('" & date1 & "') and enter_dt<=to_date('" & date2 & "'))) group by emp_code,emp_name,father_name,firm_name,pf_accno,status_id ,dis_dt,status order by emp_code"
        'End If
        ' st = "select substr(p.pf_accno,13,10) as pf_accno,upper(p.emp_name) as emp_name,sum(pf_sal) as pf_sal_tot,sum(e_pf) as e_pf_tot,sum(ac_no1) as ac_no1_tot, sum(ac_no2) as ac_no2_tot,dis_dt,status,emp_code from pf_details p where pf_firm =" & Request.QueryString("firm") & " and (status_id=1 or (join_dt>=to_date('" & date1 & "') and join_dt<=to_date('" & date2 & "')) or (enter_dt>=to_date('" & date1 & "') and enter_dt<=to_date('" & date2 & "'))) group by emp_code,emp_name,father_name,firm_name,pf_accno,status_id ,dis_dt,status order by emp_code"
        st = "select substr(lima.pf_no,13,10) as pf_accno,lima.emp_name as emp_name,sum(lima.pf_sal) as pf_sal_tot,sum(lima.e_pf) as e_pf_tot, sum(lima.ac_no1) as ac_no1_tot, sum(lima.ac_no2) as ac_no2_tot, case when lima.pf_no in (select pf_no from m_pf_dtl p where p.discon_dt is not null) then (select em.discont_dt from employee_master_dtl em where em.emp_code = lima.emp_code) else null end as dis_dt,lima.status,lima.emp_code, sum(lima.excess) as excess_paid from (select e.emp_code,e.emp_name,f.firm_name, m.sal_dt, m.pf_sal, m.emp_pf as e_pf,m.ac_no1 as AC_no1,m.ac_no10 as ac_no2, to_char(m.sal_dt, 'MM') as sal_month,m.pf_no,decode(e.status_id, 3, 'Resigned', 5, 'Terminated') as status,case when m.emp_pf > 780 then m.emp_pf - 780  end as excess,e.status_id,null as join_dt, null as enter_dt from m_pf_dtl            m, employee_master     e, firm_master         f,employee_master_dtl em where m.emp_code = e.emp_code and m.emp_code = em.emp_code and em.new_empcode is null and m.pf_firm = f.firm_id  and m.pf_firm = " & Me.Request.QueryString("firm") & "  and (m.sal_dt >= to_date('" & date1 & "') and m.sal_dt <= to_date('" & date2 & "')) union select e.emp_code, e.emp_name, f.firm_name, m.sal_dt, m.pf_sal,m.emp_pf as e_pf, m.ac_no1 as AC_no1,m.ac_no10 as ac_no2,to_char(m.sal_dt, 'MM') as sal_month, m.pf_no, decode(e.status_id, 3, 'Resigned', 5, 'Terminated') as status, case when m.emp_pf > 780 then  m.emp_pf - 780  else  0  end as excess, e.status_id,null as join_dt, null as enter_dt from m_pf_dtl            m, employee_master     e, firm_master         f, employee_master_dtl em  where m.emp_code = em.emp_code  and em.new_empcode = e.emp_code and m.pf_firm = f.firm_id  and m.pf_firm = " & Me.Request.QueryString("firm") & "  and (m.sal_dt >= to_date('" & date1 & "') and  m.sal_dt <= to_date('" & date2 & "'))) lima, employ_personal_dtl ep where lima.emp_code = ep.emp_code group by lima.emp_code, lima.emp_name,father_name, firm_name,pf_no, lima.status_id,lima.status order by emp_code"
        dt = oh.ExecuteDataSet(st).Tables(0)
        report.Load(Server.MapPath("crpt_form6a.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.SetDataSource(dt)
        If Me.Request.QueryString("firm") = 1 Then
            report.SetParameterValue("pf", "KR/KC/15076/")
        Else
            report.SetParameterValue("pf", "KR/KC/15001/")
        End If
        Me.CrystalReportViewer1.ReportSource = report
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()

    End Sub
End Class
