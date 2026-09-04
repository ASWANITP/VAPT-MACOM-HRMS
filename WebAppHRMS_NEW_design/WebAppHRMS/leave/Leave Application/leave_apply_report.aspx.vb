Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO


Partial Class leave_leave_apply_report_2d673a024102
    Inherits System.Web.UI.Page
    Dim report As New ReportDocument

    Dim dt, dt1, dt2, dt3, dt4, dt_emp As New DataTable
    Dim oh As New helper.oracle.OracleHelper
    Dim sql, seq_id, lv_type As String
    Dim dr As DataRow
    Dim oth_taken, mon_id As Integer
    Dim export As New IO.MemoryStream
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim user = Session("user_id").ToString.Split("!")
        Dim frm = Session("firm_name").ToString
        Dim fid = Session("firm_id").ToString

        'New manual leave application format for foundation
        Dim firmid As Integer = Session("firm_id")
        If firmid = 28 Then
            Me.Server.Transfer("Manual_leave_apply_report.aspx")
        End If

        Try

            Dim br As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & user(0)).Tables(0)
            Dim ff As DataTable = oh.ExecuteDataSet("select firm_abbr from firm_master where firm_id=" & fid).Tables(0)

            'seq_id = Request.QueryString.Get("leave_seq")
            'sql = "select t.emp_code,t.category_id,t.reason_id,to_char(t.leave_apply_date,'DD/MON/yyyy'),t.leave_id,t.leave_days,to_char(t.leave_frdate,'DD/MON/yyyy'),to_char(t.leave_todate,'DD/MON/yyyy'),t.recom_reason from hrm_leave_apply_sanction t where t.leave_seq=" & seq_id & ""
            'dt_emp = oh.ExecuteDataSet(sql).Tables(0)



            'New code---------------------------------
            Dim fromdate As String
            Dim todate As String


            If firmid = 28 Or firmid = 8 Or firmid = 24 Then
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
            sql = "select t.leave_id,t.leave_days from employ_leave_master t where t.emp_code=" & user(0) & " order by leave_id"
            dt1 = oh.ExecuteDataSet(sql).Tables(0)

            'New code---------------------------------
            If firmid = 28 Or firmid = 8 Or firmid = 24 Then
                sql = "select t.leave_id,decode(t.leave_id,1,sum(t.leave_days),2,sum(t.leave_days),3,sum(t.leave_days),sum(t.leave_days)) from employ_leave_dtl t where t.emp_code=" & user(0) & " and t.leave_process_id not in (0,3) and leave_frdate >= to_date('" & fromdate & "') and leave_todate <= to_date('" & todate & "') group by leave_id order by t.leave_id"
                dt2 = oh.ExecuteDataSet(sql).Tables(0)
            Else
                sql = "select t.leave_id,decode(t.leave_id,1,sum(t.leave_days),2,sum(t.leave_days),3,sum(t.leave_days),sum(t.leave_days)) from employ_leave_dtl t where t.emp_code=" & user(0) & " and t.leave_process_id not in (0,3) and to_char(leave_frdate,'YYYY')=to_char(sysdate,'YYYY') group by leave_id order by t.leave_id"
                dt2 = oh.ExecuteDataSet(sql).Tables(0)
            End If


            'sql = "select t.reason_name from hrm_category_dtl t where t.category_id=" & dt_emp.Rows(0)(1) & " and t.reason_id=" & dt_emp.Rows(0)(2) & ""
            'dt4 = oh.ExecuteDataSet(sql).Tables(0)

            report.Load(Server.MapPath("leave_crystal.rpt"), OpenReportMethod.OpenReportByTempCopy)
            'report.SetParameterValue("ground_of_appli", dt4.Rows(0)(0))

            'sql = "select to_char(sysdate,'mm') from dual"
            'dt4 = oh.ExecuteDataSet(sql).Tables(0)
            'mon_id = CInt(dt4.Rows(0)(0)) * 2
            'sql = "select nvl(sum(t.leave_days),0) from employ_leave_dtl t where t.emp_code=" & dt_emp.Rows(0)(0) & " and t.leave_process_id not in (0,3) and to_char(leave_frdate,'YYYY')=to_char(sysdate,'YYYY')"
            'dt4 = oh.ExecuteDataSet(sql).Tables(0)

            'If CInt(dt4.Rows(0)(0)) > mon_id Then
            '    report.SetParameterValue("to_person", "CHAIRMAN")
            'Else
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
                            If Session("firm_id") = 8 Then
                                report.SetParameterValue("to_person", "MD and CEO")
                            Else
                                report.SetParameterValue("to_person", "Managing Director")
                            End If
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
            'If dt_emp.Rows(0)(4) = 1 Then
            '    lv_type = "CASUAL"
            'ElseIf dt_emp.Rows(0)(4) = 2 Then
            '    lv_type = "SICK"
            'ElseIf dt_emp.Rows(0)(4) = 3 Then
            '    lv_type = "EARNED"
            'ElseIf dt_emp.Rows(0)(4) = 4 Then
            '    lv_type = "LOP"
            'End If
            'report.SetParameterValue("nat_leave", lv_type)
            'report.SetParameterValue("no_days", dt_emp.Rows(0)(5))
            'report.SetParameterValue("fr_dt", dt_emp.Rows(0)(6))
            'report.SetParameterValue("to_dt", dt_emp.Rows(0)(7))
            report.SetParameterValue("address", dt.Rows(0)(2))
            report.SetParameterValue("phone_no", dt.Rows(0)(3))

            report.SetParameterValue("casual_avail", 0)
            report.SetParameterValue("sick_avail", 0)
            report.SetParameterValue("earned_avail", 0)
            For Each dr In dt1.Rows
                If dr(0) = 1 Then
                    report.SetParameterValue("casual_avail", dr(1))
                Else
                    If dr(0) = 2 Then
                        report.SetParameterValue("sick_avail", dr(1))
                    Else
                        If dr(0) = 3 Then
                            report.SetParameterValue("earned_avail", dr(1))
                        End If
                    End If
                End If
            Next



            report.SetParameterValue("casual_taken", 0)
            report.SetParameterValue("sick_taken", 0)
            report.SetParameterValue("earned_taken", 0)
            report.SetParameterValue("other_taken", 0)
            oth_taken = 0
            For Each dr In dt2.Rows
                If dr(0) = 1 Then
                    report.SetParameterValue("casual_taken", dr(1))
                Else
                    If dr(0) = 2 Then
                        report.SetParameterValue("sick_taken", dr(1))
                    Else
                        If dr(0) = 3 Then
                            report.SetParameterValue("earned_taken", dr(1))
                        Else
                            oth_taken = oth_taken + dr(1)
                            report.SetParameterValue("other_taken", oth_taken)
                        End If
                    End If
                End If
            Next
            'Dim str As String = "select e.emp_code,e.emp_name,p.post_name,case when e.branch_id in (select branch_id from branch_master) then (select branch_name from branch_master where branch_id=e.branch_id) else (select branch_name from before_completion bc where bc.branch_id is null and bc.old_id=e.branch_id) end as branch from employee_master e,post_mst p,hrm_leave_apply_sanction h where e.post_id=p.post_id and h.leave_seq=" & seq_id & " and e.emp_code=h.recom_person"
            'dt4 = oh.ExecuteDataSet(str).Tables(0)
            'If dt4.Rows.Count > 0 Then
            '    report.SetParameterValue("recommented", dt4.Rows(0)(0))
            '    report.SetParameterValue("recomname", dt4.Rows(0)(1))
            '    report.SetParameterValue("recompost", dt4.Rows(0)(2))
            '    report.SetParameterValue("recombranch", dt4.Rows(0)(3))
            'Else
            '    report.SetParameterValue("recommented", "")
            '    report.SetParameterValue("recomname", "")
            '    report.SetParameterValue("recompost", "")
            '    report.SetParameterValue("recombranch", "")
            'End If
            'If IsDBNull(dt_emp.Rows(0)(8)) Then
            '    report.SetParameterValue("recomreason", "")
            'Else
            '    report.SetParameterValue("recomreason", dt_emp.Rows(0)(8))
            'End If

            'report.SetDataSource(leave)



            'export = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
            'Response.Clear()
            'Response.Buffer = True
            'Response.ContentType = "application/pdf"
            'Response.BinaryWrite(export.ToArray())
            'Response.End()
            'Me.CrystalReportViewer1.ReportSource = export

            Dim exportStream As Stream = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)

            ' Copy to MemoryStream to make it usable
            Dim export As New MemoryStream()
            exportStream.CopyTo(export)
            export.Position = 0

            ' Send it to the browser
            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-disposition", "inline; filename=report.pdf")
            Response.BinaryWrite(export.ToArray())
            Response.Flush()
            HttpContext.Current.ApplicationInstance.CompleteRequest()


            'Me.CrystalReportViewer1.ReportSource = report

        Catch ex As Exception
            MsgBox(ex.Message)
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
