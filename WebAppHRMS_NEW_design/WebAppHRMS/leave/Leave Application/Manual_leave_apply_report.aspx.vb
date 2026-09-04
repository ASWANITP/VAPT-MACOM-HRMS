Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Manual_leave_apply_report_923a50792229
    Inherits System.Web.UI.Page
    Dim report As New ReportDocument

    Dim dt, dt1, dt2, dt3, dt4, dt_emp, dt_Month As New DataTable
    Dim oh As New helper.oracle.OracleHelper
    Dim sql, seq_id, lv_type As String
    Dim dr As DataRow
    Dim oth_taken, mon_id As Integer
    Dim export As New IO.MemoryStream
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim user = Session("user_id").ToString.Split("!")
        Dim frm = Session("firm_name").ToString
        Dim fid = Session("firm_id").ToString

        Try
            Dim br As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & user(0)).Tables(0)
            Dim ff As DataTable = oh.ExecuteDataSet("select firm_abbr from firm_master where firm_id=" & fid).Tables(0)

            'seq_id = Request.QueryString.Get("leave_seq")
            'sql = "select t.emp_code,t.category_id,t.reason_id,to_char(t.leave_apply_date,'DD/MON/yyyy'),t.leave_id,t.leave_days,to_char(t.leave_frdate,'DD/MON/yyyy'),to_char(t.leave_todate,'DD/MON/yyyy'),t.recom_reason from hrm_leave_apply_sanction t where t.leave_seq=" & seq_id & ""
            'dt_emp = oh.ExecuteDataSet(sql).Tables(0)

            'New code---------------------------------
            Dim fromdate As String
            Dim todate As String
            Dim firmid As Integer = Session("firm_id")

            If firmid = 28 Then
                Dim Month_no As String = oh.ExecuteDataSet("select to_char(to_date(SysDate),'mm') from dual").Tables(0).Rows(0)(0)
                If (CInt(Month_no) > 0 And CInt(Month_no) <= 3) Then
                    fromdate = oh.ExecuteDataSet("select '01/Apr/'|| to_char(to_char(to_date(SysDate),'yyyy') - 1) from dual").Tables(0).Rows(0)(0)
                    todate = oh.ExecuteDataSet("select '31/Mar/'|| to_char(to_char(to_date(SysDate),'yyyy')) from dual").Tables(0).Rows(0)(0)
                Else
                    fromdate = oh.ExecuteDataSet("select '01/Apr/'||to_char(to_date(SysDate),'yyyy') from dual").Tables(0).Rows(0)(0)
                    todate = oh.ExecuteDataSet("select '31/Mar/'|| to_char(to_char(to_date(SysDate),'yyyy') + 1) from dual").Tables(0).Rows(0)(0)
                End If
            End If
            '-----------------------------------------


            sql = "select em.emp_name,dm.designation||','||dem.dep_name,ed.perm_add1,pm.post_office||','||nvl(ed.cont_phone,0) from employee_master em,designation_master dm,department_mst dem,employ_personal_dtl ed,post_master pm where pm.sr_number=ed.perm_pin and ed.emp_code=em.emp_code and em.designation_id=dm.designation_id and em.department_id=dem.dep_id and em.emp_code=" & user(0) & ""
            dt = oh.ExecuteDataSet(sql).Tables(0)
            'sql = "select t.leave_id,t.leave_days from employ_leave_master t where t.emp_code=" & user(0) & " order by leave_id"
            sql = "select t.leave_id, t.leave_days from employ_leave_master t where t.emp_code = " & user(0) & "  union select 5 leave_id, count(ce.emp_code) leave_days from hrm_comp_eligible ce,   hrm_comp_dtl      cd,    hrm_comp_mst  cm where cd.comp_id = ce.comp_id   and cd.comp_date <= to_date(sysdate)   and cd.exp_date >= to_date(sysdate)   and cm.comp_id = ce.comp_id   and ce.status = 0   and cd.emp_code = ce.emp_code   and ce.emp_code = " & user(0) & " order by leave_id"
            dt1 = oh.ExecuteDataSet(sql).Tables(0)

            'New code---------------------------------
            If firmid = 28 Then
                sql = "select t.leave_id,decode(t.leave_id,1,sum(t.leave_days),2,sum(t.leave_days),3,sum(t.leave_days),sum(t.leave_days)) from employ_leave_dtl t where t.emp_code=" & user(0) & " and t.leave_process_id not in (0,3) and leave_frdate >= to_date('" & fromdate & "') and leave_todate <= to_date('" & todate & "') group by leave_id order by t.leave_id"
                dt2 = oh.ExecuteDataSet(sql).Tables(0)
            Else
                sql = "select t.leave_id,decode(t.leave_id,1,sum(t.leave_days),2,sum(t.leave_days),3,sum(t.leave_days),sum(t.leave_days)) from employ_leave_dtl t where t.emp_code=" & user(0) & " and t.leave_process_id not in (0,3) and to_char(leave_frdate,'YYYY')=to_char(sysdate,'YYYY') group by leave_id order by t.leave_id"
                dt2 = oh.ExecuteDataSet(sql).Tables(0)
            End If


            'Leave taken in the month.
            Dim from_Month_date As String
            Dim to_Month_date As String

            'Corrent month
            from_Month_date = oh.ExecuteDataSet("select '01-'|| to_char(to_char(to_date(SysDate),'MON')) || '-' || to_char(to_char(to_date(SysDate),'yyyy') ) from dual").Tables(0).Rows(0)(0)
            to_Month_date = oh.ExecuteDataSet("select to_char(Last_day(sysdate),'dd') || '-' || to_char(to_char(to_date(SysDate),'MON')) || '-' || to_char(to_char(to_date(SysDate),'yyyy') ) from dual").Tables(0).Rows(0)(0)

            'last month 26 to current month 25
            'from_Month_date = oh.ExecuteDataSet("Select '26-' || to_char(To_date(add_months(sysdate, -1), 'dd-MON-yyyy'),'Mon-yyyy') from dual").Tables(0).Rows(0)(0)
            'to_Month_date = oh.ExecuteDataSet("Select '25-' || to_char(To_date(sysdate), 'Mon-yyyy')  from dual").Tables(0).Rows(0)(0)

            'If firmid = 28 Then
            sql = "select t.leave_id,decode(t.leave_id,1,sum(t.leave_days),2,sum(t.leave_days),3,sum(t.leave_days),sum(t.leave_days)) from employ_leave_dtl t where t.emp_code=" & user(0) & " and t.leave_process_id not in (0,3) and leave_frdate >= to_date('" & from_Month_date & "') and leave_todate <= to_date('" & to_Month_date & "') group by leave_id order by t.leave_id"
            dt_Month = oh.ExecuteDataSet(sql).Tables(0)
            'End If


            report.Load(Server.MapPath("Manual_leave_crystal.rpt"), OpenReportMethod.OpenReportByTempCopy)
            If Session("branch_id") = 0 Then
                Dim ptr As String = "select post_id from employee_master where emp_code=" & user(0)
                dt4 = oh.ExecuteDataSet(ptr).Tables(0)
                If dt4.Rows(0)(0) <> 173 Then
                    sql = "select dm.dep_name from employee_master t,department_mst dm where t.department_id=dm.dep_id and dm.dep_head is not null and t.emp_code=" & user(0) & ""
                    dt4 = oh.ExecuteDataSet(sql).Tables(0)
                    If dt4.Rows.Count > 0 Then
                        sql = "select count(*) from department_mst dep where dep.dep_head=" & user(0)
                        dt4 = oh.ExecuteDataSet(sql).Tables(0)
                        If dt4.Rows.Count > 0 Then
                            report.SetParameterValue("to_person", "Managing Director")
                        Else
                            sql = "select nvl(pm.post_name||','||dm.dep_name,'0') from employee_master t,department_mst dm,post_mst pm,employee_master ed where t.department_id=dm.dep_id and dm.dep_head=ed.emp_code and ed.post_id=pm.post_id and t.emp_code=" & user(0) & ""
                            dt4 = oh.ExecuteDataSet(sql).Tables(0)
                            report.SetParameterValue("to_person", dt4.Rows(0)(0))
                        End If
                    Else
                        report.SetParameterValue("to_person", "")
                    End If
                Else
                    sql = "select zonal_name from zonal_master z where head_id=" & user(0)
                    dt4 = oh.ExecuteDataSet(sql).Tables(0)
                    report.SetParameterValue("to_person", "ZONAL MANAGER, " & user(0))

                End If

            Else
                report.SetParameterValue("to_person", "BRANCH HEAD")
            End If

            ' End If
            report.SetParameterValue("name", dt.Rows(0)(0))
            report.SetParameterValue("code", user(0))
            report.SetParameterValue("des_dep", dt.Rows(0)(1))
            'report.SetParameterValue("doa", dt_emp.Rows(0)(3))
            report.SetParameterValue("firm", frm)
            report.SetParameterValue("fr", ff.Rows(0)(0))

            report.SetParameterValue("address", dt.Rows(0)(2))
            report.SetParameterValue("phone_no", dt.Rows(0)(3))

            Dim tota1 As Integer = 0
            report.SetParameterValue("pre_total", 0)
            report.SetParameterValue("leave_total", 0)
            report.SetParameterValue("month_total", 0)

            report.SetParameterValue("casual_avail", 0)
            report.SetParameterValue("sick_avail", 0)
            report.SetParameterValue("earned_avail", 0)
            For Each dr In dt1.Rows
                If dr(0) = 1 Then
                    tota1 = tota1 + Val(dr(1).ToString())
                    report.SetParameterValue("casual_avail", dr(1))
                Else
                    If dr(0) = 2 Then
                        tota1 = tota1 + Val(dr(1).ToString())
                        report.SetParameterValue("sick_avail", dr(1))
                    Else
                        If dr(0) = 3 Then
                            tota1 = tota1 + Val(dr(1).ToString())
                            report.SetParameterValue("earned_avail", dr(1))
                        Else
                            If dr(0) = 5 Then
                                tota1 = tota1 + Val(dr(1).ToString())
                                report.SetParameterValue("compo", dr(1))
                            End If
                        End If
                    End If
                End If
            Next
            report.SetParameterValue("leave_total", tota1)

            tota1 = 0
            report.SetParameterValue("casual_taken", 0)
            report.SetParameterValue("sick_taken", 0)
            report.SetParameterValue("earned_taken", 0)
            report.SetParameterValue("other_taken", 0)
            oth_taken = 0
            For Each dr In dt2.Rows
                If dr(0) = 1 Then
                    tota1 = tota1 + Val(dr(1).ToString())
                    report.SetParameterValue("casual_taken", dr(1))
                Else
                    If dr(0) = 2 Then
                        tota1 = tota1 + Val(dr(1).ToString())
                        report.SetParameterValue("sick_taken", dr(1))
                    Else
                        If dr(0) = 3 Then
                            tota1 = tota1 + Val(dr(1).ToString())
                            report.SetParameterValue("earned_taken", dr(1))
                        Else
                            oth_taken = oth_taken + dr(1)
                            tota1 = tota1 + Val(dr(1).ToString())
                            report.SetParameterValue("other_taken", oth_taken)
                        End If
                    End If
                End If
            Next
            report.SetParameterValue("pre_total", tota1)




            'Monthly Leaves taken
            tota1 = 0
            report.SetParameterValue("month_cl", 0)
            report.SetParameterValue("month_el", 0)
            report.SetParameterValue("month_sl", 0)
            report.SetParameterValue("month_lop", 0)
            oth_taken = 0
            For Each dr In dt_Month.Rows
                If dr(0) = 1 Then
                    tota1 = tota1 + Val(dr(1).ToString())
                    report.SetParameterValue("month_cl", dr(1))
                Else
                    If dr(0) = 2 Then
                        tota1 = tota1 + Val(dr(1).ToString())
                        report.SetParameterValue("month_sl", dr(1))
                    Else
                        If dr(0) = 3 Then
                            tota1 = tota1 + Val(dr(1).ToString())
                            report.SetParameterValue("month_el", dr(1))
                        Else
                            oth_taken = oth_taken + dr(1)
                            tota1 = tota1 + Val(dr(1).ToString())
                            report.SetParameterValue("month_lop", oth_taken)
                        End If
                    End If
                End If
            Next
            report.SetParameterValue("month_total", tota1)

            export = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "application/pdf"
            Response.BinaryWrite(export.ToArray())
            Response.End()
            Me.CrystalReportViewer1.ReportSource = export


        Catch ex As Exception
            'MsgBox(ex.Message)
            'Dim cl_script As New StringBuilder
            'cl_script.Append("")
            'cl_script.Append("window.open('../home.aspx','_self');")
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)

        End Try
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Close()
        report.Dispose()
        GC.Collect()
    End Sub
End Class
