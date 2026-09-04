Imports System.Data
Imports System.Data.OracleClient
Partial Class Tour_Sanction_tour_sanction_wform_8621ff0f3769
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt10, dt11, dt12 As New DataTable
    Dim dr, dr1 As DataRow
    Dim str, str1, sql, sql1, sql2, str3, str4, str5, str6, str7 As String
    Dim ttype As Integer
    Dim uid(), usr() As String
    Dim res As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Tour Sanction Form"

        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Cmb_TourDetails.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)

        Me.Cmb_TourDetails.Attributes.Add("onchange", "fill1()")
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "sub_call_receiver", "context")
        Dim cbscript As String = "function sub_call_server(arg,context) { " & cbref & "; } "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "sub_call_server", cbscript, True)
        Dim user As Array
        user = Session("user_id").ToString.Split("!")
        If Not IsPostBack Then
            Dim firmid As Integer = Me.Session("firm_id")
            Dim brid As Integer = Me.Session("branch_id")
            Dim userid As String = Me.Session("user_id")
            'If firmid = 2 Then
            '    Dim cl_script As New StringBuilder
            '    '    cl_script.Append("   alert(' Redirecting to new maben Leave sanction page') ;")
            '    cl_script.Append("window.open('new_tour_sanction_Mab.aspx','_self');")
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            'Else
            uid = userid.Split("!")
            If brid = 0 Then
                Me.Chk_ho.Visible = True
                Me.Chk_Br.Visible = True
            Else
                Me.Chk_ho.Visible = False
            End If
            pageload()
            ' End If
        End If

    End Sub
    Sub pageload() 'Branch staff Recommendation
        Dim userid As String = Me.Session("user_id")
        uid = userid.Split("!")
        Dim dtt1, dtt2, dtt3, dtt4, dtt5, dt2 As New DataTable
        If Me.Chk_sac.Checked = True Then
            Me.Chk_rec.Checked = False
            Me.cmd_rec.Visible = False
            Me.Cmd_Confirm.Visible = True
            If Me.Chk_Br.Checked = True Then
                Me.Chk_ho.Checked = False
                Dim dtt As New DataTable 'Branch staff sanction

                sql = "select t.post_id from mactech.employee_master t where t.emp_code='" & uid(0) & "'"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                If dt.Rows(0)(0) = 1209 Then
                    sql1 = "select count(ht.emp_code) from hrm_tour_dtl ht, employee_master em, branch bm1, othleave_sanction_authority a, department_mst m where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_recby = 0 and a.t_sanby =" & uid(0) & " and ht.emp_code <> " & uid(0) & " and m.dep_id = 542 and em.department_id = m.dep_id and ht.tour_id in (0) and nvl(ht.to_branch, 0) = bm1.branch_id and a.branch_id <> 0 order by emp_name"
                    sql2 = "select count(ht.emp_code) from hrm_tour_dtl ht, employee_master em, branch bm1, othleave_sanction_authority a, department_mst m where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_recby <> 0 and a.t_sanby =" & uid(0) & " and ht.emp_code <> " & uid(0) & " and m.dep_id = 542 and em.department_id = m.dep_id and ht.tour_id in (4) and nvl(ht.to_branch, 0) = bm1.branch_id and a.branch_id <> 0 order by emp_name"


                    dt1 = oh.ExecuteDataSet(sql1).Tables(0)
                    dt2 = oh.ExecuteDataSet(sql2).Tables(0)
                    If dt1.Rows(0)(0) > 0 Then


                        dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_sanby = " & uid(0) & " and ht.emp_code <> " & uid(0) & "  and ht.tour_id in (4,5) and nvl(ht.to_branch, 0) = bm1.branch_id and a.branch_id<>0 union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id  and a.t_recby=0 and a.t_sanby=" & uid(0) & "  and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0,4) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id<>0 order by emp_name").Tables(0)
                        Cmb_TourDetails.DataSource = dtt
                        Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                        Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                        Cmb_TourDetails.DataBind()

                    End If
                    If dt2.Rows(0)(0) > 0 Then

                        dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_sanby = " & uid(0) & " and ht.emp_code <> " & uid(0) & "  and ht.tour_id in (4,5) and nvl(ht.to_branch, 0) = bm1.branch_id and a.branch_id<>0 union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id  and a.t_recby=0 and a.t_sanby=" & uid(0) & "  and ht.emp_code <>" & uid(0) & " and ht.tour_id in (4) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id<>0 order by emp_name").Tables(0)
                        Cmb_TourDetails.DataSource = dtt
                        Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                        Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                        Cmb_TourDetails.DataBind()
                    End If

                Else
                    dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_sanby = " & uid(0) & " and ht.emp_code <> " & uid(0) & "  and ht.tour_id in (4,5) and nvl(ht.to_branch, 0) = bm1.branch_id and a.branch_id<>0 union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id  and a.t_recby=0 and a.t_sanby=" & uid(0) & "  and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0,4) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id<>0 order by emp_name").Tables(0)
                    Cmb_TourDetails.DataSource = dtt
                    Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                    Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                    Cmb_TourDetails.DataBind()





                End If


            Else
                Me.Chk_ho.Checked = True
                Dim dtt As New DataTable 'Ho staff Sanction

                Dim fid As Integer
                fid = Session("firm_id")
                If fid = 28 Then
                    dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name  from dual union select ht.sr_number as srnumber,        ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||       to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||        to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||        bm1.branch_name || ' (Branch)' || '    Purpose: ' ||       decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name  from mactech.hrm_tour_dtl                ht,       mactech.employee_master             em,       branch                      bm1,       othleave_sanction_authority a where ht.emp_code = em.emp_code   and ht.emp_code = a.emp_id   and a.t_sanby = " & uid(0) & "   and ht.tour_id in (4, 5)   and nvl(ht.to_branch, 0) = bm1.branch_id   and a.branch_id = 0 union select ht.sr_number as srnumber,       ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||       to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||       to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||       decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name  from mactech.hrm_tour_dtl                ht,       mactech.employee_master             em,       mactech.branch                      bm1,       mactech.othleave_sanction_authority a where ht.emp_code = em.emp_code    and ht.emp_code = a.emp_id   and a.t_recby = 0   and a.t_sanby =" & uid(0) & "   and ht.tour_id in (0, 4)   and nvl(ht.to_branch, 0) = bm1.branch_id   and a.branch_id = 0 order by emp_name").Tables(0)
                    Cmb_TourDetails.DataSource = dtt
                    Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                    Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                    Cmb_TourDetails.DataBind()
                Else

                    dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_sanby = " & uid(0) & " and ht.emp_code <> " & uid(0) & "  and ht.tour_id in (4,5) and nvl(ht.to_branch, 0) = bm1.branch_id and a.branch_id=0 union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id  and a.t_recby=0 and a.t_sanby=" & uid(0) & "  and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0,4) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id=0 order by emp_name").Tables(0)
                    Cmb_TourDetails.DataSource = dtt
                    Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                    Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                    Cmb_TourDetails.DataBind()
                End If
            End If

        Else
            Me.Chk_rec.Checked = True
            Me.cmd_rec.Visible = True
            Me.Cmd_Confirm.Visible = False
            Dim brid As Integer = Me.Session("branch_id")

            Dim ecode As Integer = uid(0)
            If Me.Chk_Br.Checked = True Then
                Me.Chk_ho.Checked = False
                Dim dtt As New DataTable 'Branch Recommendation
                dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1, othleave_sanction_authority a where ht.emp_code = em.emp_code   and ht.emp_code = a.emp_id and a.t_recby=" & uid(0) & " and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id<>0  order by emp_name").Tables(0)
                Cmb_TourDetails.DataSource = dtt
                Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()
            Else
                Me.Chk_ho.Checked = True
                Dim dt As New DataTable 'Ho staff Recommendation
                dtt1 = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1, othleave_sanction_authority a where ht.emp_code = em.emp_code   and ht.emp_code = a.emp_id and a.t_recby=" & uid(0) & " and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id=0  order by emp_name").Tables(0)
                Cmb_TourDetails.DataSource = dt
                Cmb_TourDetails.DataValueField = dt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()
            End If
        End If

    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim SrlNO As Integer = CInt(eventArgument)
        Session("SrlNO") = SrlNO
        Dim cal_data = eventArgument
        Dim dis As Integer = cal_data
        Dim st As New StringBuilder
        Dim dt7, dt8, dt9 As New DataTable

        str5 = "select count(*) from FIELDPNCH_INSERT k where k.srnos = " & SrlNO & " "
        dt9 = oh.ExecuteDataSet(str5).Tables(0)
        If dt9.Rows(0)(0) > 0 Then
            'str3 = "Select count(*) from helpdesk_issue_sr t where t.issue_sr_id = (select k.srtktnos from FIELDPNCH_INSERT k where k.srnos = " & SrlNO & ") and t.status in (0, 19, 20, 21, 22, 15, 16, 17)"

            str3 = "Select count(*) from helpdesk_issue_sr t where t.issue_sr_id = (select k.srtktnos from FIELDPNCH_INSERT k where k.srnos = " & SrlNO & ") and t.status in (select p.status from field_tckt_stats p )"
            dt7 = oh.ExecuteDataSet(str3).Tables(0)

            If dt7.Rows(0)(0) = 0 Then
                st.Append("ALERT:Ticket in progress. Please select another employee.")
                res = st.ToString
                Exit Sub
            End If
        End If
        Try

            Dim s As Double = oh.ExecuteDataSet("select nvl(h.to_branch,99999) from hrm_tour_dtl h where h.sr_number=" & SrlNO & "").Tables(0).Rows(0)(0)


            str4 = "Select count(*) from TBLFIELD_PUNCH t where t.empcode = (select k.empcode from FIELDPNCH_INSERT k where k.srnos = " & SrlNO & ")"
            dt8 = oh.ExecuteDataSet(str4).Tables(0)
            If dt8.Rows(0)(0) = 1 Then
                If s <> 99999 Then

                    str1 = "select ht.emp_code || '*' || em.emp_name || '*' || bm.branch_name || '*' || dm.designation || '*' || dp.dep_name || '*' || pm.post_name || '*' || to_char(ht.from_dt) || '*' || to_char(ht.to_dt) || '*' || nvl(ht.from_time, 0) || '*' || nvl(ht.to_time, 0) || '*' || bm1.branch_name || '*' || decode(ht.tour_purpose, null, 'Not Specified', upper(ht.tour_purpose)) || '*' || nvl(ht.advance_rs, 0) || '*' || decode(ht.tra_dt, null, '0', to_char(ht.tra_dt)) || '*' || e1.emp_code || '--' || e1.emp_name || '*' || ht.tour_id || '*' || nb.status_name || '*' || kp.remarks || '*' || (select ta.m_time from tour_attend ta where ta.m_branch = ht.to_branch and ta.curr_date between ht.from_dt and ht.to_dt and ht.emp_code = ta.emp_code) || '*' || (select ta.e_time from tour_attend ta where ta.m_branch = ht.to_branch and ta.curr_date between ht.from_dt and ht.to_dt and ht.emp_code = ta.emp_code) from employee_master em, branch_master bm, designation_master dm, department_mst dp, post_mst pm, HELPDESK_ISSUE_SR pp, helpdesk_statusnew nb, FIELDPNCH_INSERT kp, branch_master bm1, hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code = ht.recom_person and e1.emp_code > 9999) where ht.emp_code = em.emp_code and bm.branch_id = ht.branch_id and dm.designation_id = ht.desig_id and dp.dep_id = ht.dep_id and ht.emp_code = kp.empcode and ht.sr_number = kp.srnos and nb.status_id = pp.status and kp.srtktnos = pp.issue_sr_id and pm.post_id = ht.post_id and ht.to_branch = bm1.branch_id and ht.tour_id in (0, 4) and ht.sr_number = " & SrlNO & " union select ht.emp_code || '*' || em.emp_name || '*' || bm.branch_name || '*' || dm.designation || '*' || dp.dep_name || '*' || pm.post_name || '*' || ht.from_dt || '*' || ht.to_dt || '*' || nvl(ht.from_time, 0) || '*' || nvl(ht.to_time, 0) || '*' || bc1.branch_name || '*' || decode(ht.tour_purpose, null, 'Not Specified', upper(ht.tour_purpose)) || '*' || nvl(ht.advance_rs, 0) || '*' || decode(ht.tra_dt, null, '0', to_char(ht.tra_dt)) || '*' || e1.emp_code || '--' || e1.emp_name || '*' || ht.tour_id || '*' || nb.status_name || '*' || kp.remarks || '*' || (select ta.m_time from tour_attend ta where ta.m_branch = ht.to_branch and ta.curr_date between ht.from_dt and ht.to_dt and ht.emp_code = ta.emp_code) || '*' || (select ta.e_time from tour_attend ta where ta.m_branch = ht.to_branch and ta.curr_date between ht.from_dt and ht.to_dt and ht.emp_code = ta.emp_code) from employee_master em, branch_master bm, designation_master dm, department_mst dp, post_mst pm, HELPDESK_ISSUE_SR pp, helpdesk_statusnew nb, FIELDPNCH_INSERT kp, before_completion bc1, hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code = ht.recom_person and e1.emp_code > 9999) where ht.emp_code = em.emp_code and bm.branch_id = ht.branch_id and dm.designation_id = ht.desig_id and dp.dep_id = ht.dep_id and ht.emp_code = kp.empcode and ht.sr_number = kp.srnos and nb.status_id = pp.status and kp.srtktnos = pp.issue_sr_id and pm.post_id = ht.post_id and ht.to_branch = bc1.old_id and bc1.branch_id is null and ht.tour_id in (0, 4) and ht.sr_number = " & SrlNO & " union select ht.emp_code || '*' || em.emp_name || '*' || bc.branch_name || '*' || dm.designation || '*' || dp.dep_name || '*' || pm.post_name || '*' || ht.from_dt || '*' || ht.to_dt || '*' || nvl(ht.from_time, 0) || '*' || nvl(ht.to_time, 0) || '*' || bm1.branch_name || '*' || decode(ht.tour_purpose, null, 'Not Specified', upper(ht.tour_purpose)) || '*' || nvl(ht.advance_rs, 0) || '*' || decode(ht.tra_dt, null, '0', to_char(ht.tra_dt)) || '*' || e1.emp_code || '--' || e1.emp_name || '*' || ht.tour_id || '*' || nb.status_name || '*' || kp.remarks || '*' || (select ta.m_time from tour_attend ta where ta.m_branch = ht.to_branch and ta.curr_date between ht.from_dt and ht.to_dt and ht.emp_code = ta.emp_code) || '*' || (select ta.e_time from tour_attend ta where ta.m_branch = ht.to_branch and ta.curr_date between ht.from_dt and ht.to_dt and ht.emp_code = ta.emp_code) from employee_master em, before_completion bc, designation_master dm, department_mst dp, post_mst pm, HELPDESK_ISSUE_SR pp, helpdesk_statusnew nb, FIELDPNCH_INSERT kp, branch_master bm1, hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code = ht.recom_person and e1.emp_code > 9999) where ht.emp_code = em.emp_code and bc.old_id = ht.branch_id and bc.branch_id is null and dm.designation_id = ht.desig_id and dp.dep_id = ht.dep_id and ht.emp_code = kp.empcode and ht.sr_number = kp.srnos and nb.status_id = pp.status and kp.srtktnos = pp.issue_sr_id and pm.post_id = ht.post_id and ht.to_branch = bm1.branch_id and ht.tour_id = 0 and ht.sr_number = " & SrlNO & " union select ht.emp_code || '*' || em.emp_name || '*' || bc.branch_name || '*' || dm.designation || '*' || dp.dep_name || '*' || pm.post_name || '*' || ht.from_dt || '*' || ht.to_dt || '*' || nvl(ht.from_time, 0) || '*' || nvl(ht.to_time, 0) || '*' || bc1.branch_name || '*' || decode(ht.tour_purpose, null, 'Not Specified', upper(ht.tour_purpose)) || '*' || nvl(ht.advance_rs, 0) || '*' || decode(ht.tra_dt, null, '0', to_char(ht.tra_dt)) || '*' || e1.emp_code || '--' || e1.emp_name || '*' || ht.tour_id || '*' || nb.status_name || '*' || kp.remarks || '*' || (select ta.m_time from tour_attend ta where ta.m_branch = ht.to_branch and ta.curr_date between ht.from_dt and ht.to_dt and ht.emp_code = ta.emp_code) || '*' || (select ta.e_time from tour_attend ta where ta.m_branch = ht.to_branch and ta.curr_date between ht.from_dt and ht.to_dt and ht.emp_code = ta.emp_code) from employee_master em, before_completion bc, designation_master dm, department_mst dp, post_mst pm, HELPDESK_ISSUE_SR pp, helpdesk_statusnew nb, FIELDPNCH_INSERT kp, before_completion bc1, hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code = ht.recom_person and e1.emp_code > 9999) where ht.emp_code = em.emp_code and bc.old_id = ht.branch_id and bc.branch_id is null and dm.designation_id = ht.desig_id and dp.dep_id = ht.dep_id and ht.emp_code = kp.empcode and ht.sr_number = kp.srnos and nb.status_id = pp.status and kp.srtktnos = pp.issue_sr_id and pm.post_id = ht.post_id and ht.to_branch = bc1.old_id and bc1.branch_id is null and ht.tour_id = 0 and ht.sr_number =" & SrlNO & ""
                    st.Append("~")
                ElseIf s = 99999 Then

                    str1 = "select ht.emp_code || '*' || em.emp_name || '*' || bm.branch_name || '*' || dm.designation || '*' || dp.dep_name || '*' || pm.post_name || '*' || to_char(ht.from_dt) || '*' || to_char(ht.to_dt) || '*' || nvl(ht.from_time, 0) || '*' || nvl(ht.to_time, 0) || '*' || decode(ht.others, null, 'Not Specified', ht.others) || '*' || decode(ht.tour_purpose, null, 'Not Specified', upper(ht.tour_purpose)) || '*' || nvl(ht.advance_rs, 0) || '*' || decode(ht.tra_dt, null, '0', to_char(ht.tra_dt)) || '*' || e1.emp_code || '--' || e1.emp_name || '*' || ht.tour_id || '*' || nb.status_name || '*' || kp.remarks || '*' || (select ta.m_time from tour_attend ta where ta.m_branch = ht.to_branch and ta.curr_date between ht.from_dt and ht.to_dt and ht.emp_code = ta.emp_code) || '*' || (select ta.e_time from tour_attend ta where ta.m_branch = ht.to_branch and ta.curr_date between ht.from_dt and ht.to_dt and ht.emp_code = ta.emp_code) from employee_master em, branch_master bm, designation_master dm, department_mst dp, post_mst pm, HELPDESK_ISSUE_SR pp, helpdesk_statusnew nb, FIELDPNCH_INSERT kp, hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code = ht.recom_person and e1.emp_code > 9999) where ht.emp_code = em.emp_code and bm.branch_id = ht.branch_id and dm.designation_id = ht.desig_id and dp.dep_id = ht.dep_id and ht.emp_code = kp.empcode and ht.sr_number = kp.srnos and nb.status_id = pp.status and kp.srtktnos = pp.issue_sr_id and pm.post_id = ht.post_id and ht.tour_id in (0, 4) and ht.sr_number = " & SrlNO & " union select ht.emp_code || '*' || em.emp_name || '*' || bc.branch_name || '*' || dm.designation || '*' || dp.dep_name || '*' || pm.post_name || '*' || ht.from_dt || '*' || ht.to_dt || '*' || nvl(ht.from_time, 0) || '*' || nvl(ht.to_time, 0) || '*' || decode(ht.others, null, 'Not Specified', ht.others) || '*' || decode(ht.tour_purpose, null, 'Not Specified', upper(ht.tour_purpose)) || '*' || nvl(ht.advance_rs, 0) || '*' || decode(ht.tra_dt, null, '0', to_char(ht.tra_dt)) || '*' || e1.emp_code || '--' || e1.emp_name || '*' || ht.tour_id || '*' || nb.status_name || '*' || kp.remarks || '*' || (select ta.m_time from tour_attend ta where ta.m_branch = ht.to_branch and ta.curr_date between ht.from_dt and ht.to_dt and ht.emp_code = ta.emp_code) || '*' || (select ta.e_time from tour_attend ta where ta.m_branch = ht.to_branch and ta.curr_date between ht.from_dt and ht.to_dt and ht.emp_code = ta.emp_code) from employee_master em, before_completion bc, designation_master dm, department_mst dp, post_mst pm, HELPDESK_ISSUE_SR pp, helpdesk_statusnew nb, FIELDPNCH_INSERT kp, hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code = ht.recom_person and e1.emp_code > 9999) where ht.emp_code = em.emp_code and bc.old_id = ht.branch_id and bc.branch_id is null and dm.designation_id = ht.desig_id and dp.dep_id = ht.dep_id and ht.emp_code = kp.empcode and ht.sr_number = kp.srnos and nb.status_id = pp.status and kp.srtktnos = pp.issue_sr_id and pm.post_id = ht.post_id and ht.tour_id in (0, 4) and ht.sr_number =" & SrlNO & ""
                    st.Append("~")
                End If

            Else
                If s <> 99999 Then
                    If Session("firm_id") = 24 Then
                        '                     0              1          2               3                     4               5                                  6                                                                               7
                        '   str1 = "select ht.emp_code||'*'||em.emp_name||'*'||bm.branch_name||'*'||dm.designation||'*'||dp.dep_name||'*'||pm.post_name||'*'||to_char(ht.from_dt)||'*'||to_char(ht.to_dt)||'*'||nvl(ht.from_time,0)||'*'||nvl(ht.to_time,0)||'*'||bm1.branch_name||'*'||decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose))||'*'||nvl(ht.advance_rs,0)||'*'||decode(ht.tra_dt,null,'0',to_char(ht.tra_dt))||'*'||e1.emp_code||'--'||e1.emp_name||'*'||ht.tour_id from employee_master em,branch_master bm,designation_master dm,department_mst dp,post_mst pm,branch_master bm1,hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code=ht.recom_person) where  ht.emp_code=em.emp_code and bm.branch_id=ht.branch_id and dm.designation_id=ht.desig_id and dp.dep_id=ht.dep_id and pm.post_id=ht.post_id and ht.to_branch=bm1.branch_id and ht.tour_id in (0,4) and ht.sr_number =" & SrlNO & " union select ht.emp_code||'*'||em.emp_name||'*'||bm.branch_name||'*'||dm.designation||'*'||dp.dep_name||'*'||pm.post_name||'*'||ht.from_dt||'*'||ht.to_dt||'*'||nvl(ht.from_time,0)||'*'||nvl(ht.to_time,0)||'*'||bc1.branch_name||'*'||decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose))||'*'||nvl(ht.advance_rs,0)||'*'||decode(ht.tra_dt,null,'0',to_char(ht.tra_dt))||'*'||e1.emp_code||'--'||e1.emp_name||'*'||ht.tour_id from employee_master em,branch_master bm,designation_master dm,department_mst dp,post_mst pm,before_completion bc1,hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code=ht.recom_person ) where ht.emp_code=em.emp_code and bm.branch_id=ht.branch_id and dm.designation_id=ht.desig_id and dp.dep_id=ht.dep_id and pm.post_id=ht.post_id and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.tour_id in (0,4) and ht.sr_number =" & SrlNO & " union select ht.emp_code||'*'||em.emp_name||'*'||bc.branch_name||'*'||dm.designation||'*'||dp.dep_name||'*'||pm.post_name||'*'||ht.from_dt||'*'||ht.to_dt||'*'||nvl(ht.from_time,0)||'*'||nvl(ht.to_time,0)||'*'||bm1.branch_name||'*'||decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose))||'*'||nvl(ht.advance_rs,0)||'*'||decode(ht.tra_dt,null,'0',to_char(ht.tra_dt))||'*'||e1.emp_code||'--'||e1.emp_name||'*'||ht.tour_id from employee_master em,before_completion bc,designation_master dm,department_mst dp,post_mst pm,branch_master bm1,hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code=ht.recom_person) where  ht.emp_code=em.emp_code and bc.old_id=ht.branch_id and bc.branch_id is null and dm.designation_id=ht.desig_id and dp.dep_id=ht.dep_id and pm.post_id=ht.post_id and ht.to_branch=bm1.branch_id and ht.tour_id=0 and ht.sr_number =" & SrlNO & " union select ht.emp_code||'*'||em.emp_name||'*'||bc.branch_name||'*'||dm.designation||'*'||dp.dep_name||'*'||pm.post_name||'*'||ht.from_dt||'*'||ht.to_dt||'*'||nvl(ht.from_time,0)||'*'||nvl(ht.to_time,0)||'*'||bc1.branch_name||'*'||decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose))||'*'||nvl(ht.advance_rs,0)||'*'||decode(ht.tra_dt,null,'0',to_char(ht.tra_dt))||'*'||e1.emp_code||'--'||e1.emp_name||'*'||ht.tour_id from employee_master em,before_completion bc,designation_master dm,department_mst dp,post_mst pm,before_completion bc1,hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code=ht.recom_person )  where ht.emp_code=em.emp_code and bc.old_id=ht.branch_id and bc.branch_id is null and dm.designation_id=ht.desig_id and dp.dep_id=ht.dep_id and pm.post_id=ht.post_id and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.tour_id=0 and ht.sr_number =" & SrlNO & ""
                        str1 = "select ht.emp_code || '*' || em.emp_name || '*' || bm.branch_name || '*' || dm.designation || '*' || dp.dep_name || '*' || pm.post_name || '*' || to_char(ht.from_dt) || '*' || to_char(ht.to_dt) || '*' || nvl(ht.from_time, 0) || '*' || nvl(ht.to_time, 0) || '*' || bm1.branch_name || '*' || decode(ht.tour_purpose, null, 'Not Specified', upper(ht.tour_purpose)) || '*' || nvl(ht.advance_rs, 0) || '*' || decode(ht.tra_dt, null, '0', to_char(ht.tra_dt)) || '*' || e1.emp_code || '--' || e1.emp_name || '*' || ht.tour_id from employee_master em, branch_master bm, designation_master dm, department_mst dp, post_mst_jwell pm, branch_master bm1, hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code = ht.recom_person and e1.emp_code > 9999) where ht.emp_code = em.emp_code and bm.branch_id = ht.branch_id and dm.designation_id = ht.desig_id and dp.dep_id = ht.dep_id and pm.post_id = ht.post_id and ht.to_branch = bm1.branch_id and ht.tour_id in (0, 4) and ht.sr_number = " & SrlNO & " union select ht.emp_code || '*' || em.emp_name || '*' || bm.branch_name || '*' || dm.designation || '*' || dp.dep_name || '*' || pm.post_name || '*' || ht.from_dt || '*' || ht.to_dt || '*' || nvl(ht.from_time, 0) || '*' || nvl(ht.to_time, 0) || '*' || bc1.branch_name || '*' || decode(ht.tour_purpose, null, 'Not Specified', upper(ht.tour_purpose)) || '*' || nvl(ht.advance_rs, 0) || '*' || decode(ht.tra_dt, null, '0', to_char(ht.tra_dt)) || '*' || e1.emp_code || '--' || e1.emp_name || '*' || ht.tour_id from employee_master em, branch_master bm, designation_master dm, department_mst dp, post_mst_jwell pm, before_completion bc1, hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code = ht.recom_person and e1.emp_code > 9999) where ht.emp_code = em.emp_code and bm.branch_id = ht.branch_id and dm.designation_id = ht.desig_id and dp.dep_id = ht.dep_id and pm.post_id = ht.post_id and ht.to_branch = bc1.old_id and bc1.branch_id is null and ht.tour_id in (0, 4) and ht.sr_number = " & SrlNO & " union select ht.emp_code || '*' || em.emp_name || '*' || bc.branch_name || '*' || dm.designation || '*' || dp.dep_name || '*' || pm.post_name || '*' || ht.from_dt || '*' || ht.to_dt || '*' || nvl(ht.from_time, 0) || '*' || nvl(ht.to_time, 0) || '*' || bm1.branch_name || '*' || decode(ht.tour_purpose, null, 'Not Specified', upper(ht.tour_purpose)) || '*' || nvl(ht.advance_rs, 0) || '*' || decode(ht.tra_dt, null, '0', to_char(ht.tra_dt)) || '*' || e1.emp_code || '--' || e1.emp_name || '*' || ht.tour_id from employee_master em, before_completion bc, designation_master dm, department_mst dp, post_mst_jwell pm, branch_master bm1, hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code = ht.recom_person and e1.emp_code > 9999) where ht.emp_code = em.emp_code and bc.old_id = ht.branch_id and bc.branch_id is null and dm.designation_id = ht.desig_id and dp.dep_id = ht.dep_id and pm.post_id = ht.post_id and ht.to_branch = bm1.branch_id and ht.tour_id = 0 and ht.sr_number = " & SrlNO & " union select ht.emp_code || '*' || em.emp_name || '*' || bc.branch_name || '*' || dm.designation || '*' || dp.dep_name || '*' || pm.post_name || '*' || ht.from_dt || '*' || ht.to_dt || '*' || nvl(ht.from_time, 0) || '*' || nvl(ht.to_time, 0) || '*' || bc1.branch_name || '*' || decode(ht.tour_purpose, null, 'Not Specified', upper(ht.tour_purpose)) || '*' || nvl(ht.advance_rs, 0) || '*' || decode(ht.tra_dt, null, '0', to_char(ht.tra_dt)) || '*' || e1.emp_code || '--' || e1.emp_name || '*' || ht.tour_id from employee_master em, before_completion bc, designation_master dm, department_mst dp, post_mst_jwell_jwell pm, before_completion bc1, hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code = ht.recom_person and e1.emp_code > 9999) where ht.emp_code = em.emp_code and bc.old_id = ht.branch_id and bc.branch_id is null and dm.designation_id = ht.desig_id and dp.dep_id = ht.dep_id and pm.post_id = ht.post_id and ht.to_branch = bc1.old_id and bc1.branch_id is null and ht.tour_id = 0 and ht.sr_number =" & SrlNO & ""
                    Else
                        str1 = "select ht.emp_code||'*'||em.emp_name||'*'||bm.branch_name||'*'||dm.designation||'*'||dp.dep_name||'*'||pm.post_name||'*'||to_char(ht.from_dt)||'*'||to_char(ht.to_dt)||'*'||nvl(ht.from_time,0)||'*'||nvl(ht.to_time,0)||'*'||bm1.branch_name||'*'||decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose))||'*'||nvl(ht.advance_rs,0)||'*'||decode(ht.tra_dt,null,'0',to_char(ht.tra_dt))||'*'||e1.emp_code||'--'||e1.emp_name||'*'||ht.tour_id from employee_master em,branch_master bm,designation_master dm,department_mst dp,post_mst pm,branch_master bm1,hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code=ht.recom_person and e1.emp_code>9999) where  ht.emp_code=em.emp_code and bm.branch_id=ht.branch_id and dm.designation_id=ht.desig_id and dp.dep_id=ht.dep_id and pm.post_id=ht.post_id and ht.to_branch=bm1.branch_id and ht.tour_id in (0,4) and ht.sr_number =" & SrlNO & " union select ht.emp_code||'*'||em.emp_name||'*'||bm.branch_name||'*'||dm.designation||'*'||dp.dep_name||'*'||pm.post_name||'*'||ht.from_dt||'*'||ht.to_dt||'*'||nvl(ht.from_time,0)||'*'||nvl(ht.to_time,0)||'*'||bc1.branch_name||'*'||decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose))||'*'||nvl(ht.advance_rs,0)||'*'||decode(ht.tra_dt,null,'0',to_char(ht.tra_dt))||'*'||e1.emp_code||'--'||e1.emp_name||'*'||ht.tour_id from employee_master em,branch_master bm,designation_master dm,department_mst dp,post_mst pm,before_completion bc1,hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code=ht.recom_person and e1.emp_code>9999 ) where ht.emp_code=em.emp_code and bm.branch_id=ht.branch_id and dm.designation_id=ht.desig_id and dp.dep_id=ht.dep_id and pm.post_id=ht.post_id and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.tour_id in (0,4) and ht.sr_number =" & SrlNO & " union select ht.emp_code||'*'||em.emp_name||'*'||bc.branch_name||'*'||dm.designation||'*'||dp.dep_name||'*'||pm.post_name||'*'||ht.from_dt||'*'||ht.to_dt||'*'||nvl(ht.from_time,0)||'*'||nvl(ht.to_time,0)||'*'||bm1.branch_name||'*'||decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose))||'*'||nvl(ht.advance_rs,0)||'*'||decode(ht.tra_dt,null,'0',to_char(ht.tra_dt))||'*'||e1.emp_code||'--'||e1.emp_name||'*'||ht.tour_id from employee_master em,before_completion bc,designation_master dm,department_mst dp,post_mst pm,branch_master bm1,hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code=ht.recom_person and e1.emp_code>9999) where  ht.emp_code=em.emp_code and bc.old_id=ht.branch_id and bc.branch_id is null and dm.designation_id=ht.desig_id and dp.dep_id=ht.dep_id and pm.post_id=ht.post_id and ht.to_branch=bm1.branch_id and ht.tour_id=0 and ht.sr_number =" & SrlNO & " union select ht.emp_code||'*'||em.emp_name||'*'||bc.branch_name||'*'||dm.designation||'*'||dp.dep_name||'*'||pm.post_name||'*'||ht.from_dt||'*'||ht.to_dt||'*'||nvl(ht.from_time,0)||'*'||nvl(ht.to_time,0)||'*'||bc1.branch_name||'*'||decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose))||'*'||nvl(ht.advance_rs,0)||'*'||decode(ht.tra_dt,null,'0',to_char(ht.tra_dt))||'*'||e1.emp_code||'--'||e1.emp_name||'*'||ht.tour_id from employee_master em,before_completion bc,designation_master dm,department_mst dp,post_mst pm,before_completion bc1,hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code=ht.recom_person and e1.emp_code>9999 )  where ht.emp_code=em.emp_code and bc.old_id=ht.branch_id and bc.branch_id is null and dm.designation_id=ht.desig_id and dp.dep_id=ht.dep_id and pm.post_id=ht.post_id and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.tour_id=0 and ht.sr_number =" & SrlNO & ""
                    End If

                ElseIf s = 99999 Then
                    If Session("firm_id") = 24 Then

                        str1 = "select ht.emp_code || '*' || em.emp_name || '*' || bm.branch_name || '*' || dm.designation || '*' || dp.dep_name || '*' || pm.post_name || '*' || to_char(ht.from_dt) || '*' || to_char(ht.to_dt) || '*' || nvl(ht.from_time, 0) || '*' || nvl(ht.to_time, 0) || '*' || decode(ht.others, null, 'Not Specified', ht.others) || '*' || decode(ht.tour_purpose, null, 'Not Specified', upper(ht.tour_purpose)) || '*' || nvl(ht.advance_rs, 0) || '*' || decode(ht.tra_dt, null, '0', to_char(ht.tra_dt)) || '*' || e1.emp_code || '--' || e1.emp_name || '*' || ht.tour_id from employee_master em, branch_master bm, designation_master dm, department_mst dp, post_mst_jwell pm, hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code = ht.recom_person and e1.emp_code > 9999) where ht.emp_code = em.emp_code and bm.branch_id = ht.branch_id and dm.designation_id = ht.desig_id and dp.dep_id = ht.dep_id and pm.post_id = ht.post_id and ht.tour_id in (0, 4) and ht.sr_number = " & SrlNO & " union select ht.emp_code || '*' || em.emp_name || '*' || bc.branch_name || '*' || dm.designation || '*' || dp.dep_name || '*' || pm.post_name || '*' || ht.from_dt || '*' || ht.to_dt || '*' || nvl(ht.from_time, 0) || '*' || nvl(ht.to_time, 0) || '*' || decode(ht.others, null, 'Not Specified', ht.others) || '*' || decode(ht.tour_purpose, null, 'Not Specified', upper(ht.tour_purpose)) || '*' || nvl(ht.advance_rs, 0) || '*' || decode(ht.tra_dt, null, '0', to_char(ht.tra_dt)) || '*' || e1.emp_code || '--' || e1.emp_name || '*' || ht.tour_id from employee_master em, before_completion bc, designation_master dm, department_mst dp, post_mst_jwell pm, hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code = ht.recom_person and e1.emp_code > 9999) where ht.emp_code = em.emp_code and bc.old_id = ht.branch_id and bc.branch_id is null and dm.designation_id = ht.desig_id and dp.dep_id = ht.dep_id and pm.post_id = ht.post_id and ht.tour_id in (0, 4) and ht.sr_number = " & SrlNO & ""
                    Else
                        str1 = "select ht.emp_code||'*'||em.emp_name||'*'||bm.branch_name||'*'||dm.designation||'*'||dp.dep_name||'*'||pm.post_name||'*'||to_char(ht.from_dt)||'*'||to_char(ht.to_dt)||'*'||nvl(ht.from_time,0)||'*'||nvl(ht.to_time,0)||'*'||decode(ht.others,null,'Not Specified',ht.others)||'*'||decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose))||'*'||nvl(ht.advance_rs,0)||'*'||decode(ht.tra_dt,null,'0',to_char(ht.tra_dt))||'*'||e1.emp_code||'--'||e1.emp_name||'*'||ht.tour_id from employee_master em,branch_master bm,designation_master dm,department_mst dp,post_mst pm,hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code=ht.recom_person and e1.emp_code>9999)  where  ht.emp_code=em.emp_code and bm.branch_id=ht.branch_id and dm.designation_id=ht.desig_id and dp.dep_id=ht.dep_id and pm.post_id=ht.post_id and ht.tour_id in (0,4) and ht.sr_number =" & SrlNO & " union select ht.emp_code||'*'||em.emp_name||'*'||bc.branch_name||'*'||dm.designation||'*'||dp.dep_name||'*'||pm.post_name||'*'||ht.from_dt||'*'||ht.to_dt||'*'||nvl(ht.from_time,0)||'*'||nvl(ht.to_time,0)||'*'||decode(ht.others,null,'Not Specified',ht.others)||'*'||decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose))||'*'||nvl(ht.advance_rs,0)||'*'||decode(ht.tra_dt,null,'0',to_char(ht.tra_dt))||'*'||e1.emp_code||'--'||e1.emp_name||'*'||ht.tour_id from employee_master em,before_completion bc,designation_master dm,department_mst dp,post_mst pm,hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code=ht.recom_person and e1.emp_code>9999 )  where ht.emp_code=em.emp_code and bc.old_id=ht.branch_id and bc.branch_id is null and dm.designation_id=ht.desig_id and dp.dep_id=ht.dep_id and pm.post_id=ht.post_id and ht.tour_id in (0,4) and ht.sr_number =" & SrlNO & ""
                    End If
                End If

            End If

            dt1 = oh.ExecuteDataSet(str1).Tables(0)

        Catch ex As Exception
        Finally

        End Try
        If dt1.Rows.Count > 0 Then

            st.Append(dt1.Rows(0)(0))
            st.Append("@")
            st.Append("!")
        Else
            st.Append("$")
            st.Append("@")
            st.Append("!")
        End If
        res = st.ToString
    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click

        If Me.Cmb_TourDetails.SelectedValue <> 0 Then
            Dim userid As String = Me.Session("user_id")
            Dim uid() As String = userid.Split("!")
            Dim ecode1 As Integer = uid(0)
            Me.ttype = Me.Cmb_TourDetails.SelectedValue
            Try
                Dim para(4) As OracleParameter

                para(0) = New OracleParameter("tcase", OracleType.Number, 8)
                para(0).Value = Me.ttype
                para(0).Direction = ParameterDirection.Input

                para(1) = New OracleParameter("empcode", OracleType.Number, 5)
                para(1).Value = ecode1
                para(1).Direction = ParameterDirection.Input

                para(2) = New OracleParameter("branchid", OracleType.Number, 5)
                para(2).Value = -99
                para(2).Direction = ParameterDirection.Input

                para(3) = New OracleParameter("flag", OracleType.Number, 2)
                para(3).Direction = ParameterDirection.Output

                para(4) = New OracleParameter("msg", OracleType.VarChar, 80)
                para(4).Direction = ParameterDirection.Output

                oh.ExecuteDataSet("hrm_tour_sanctions", para)

                If para(3).Value = 1 Then
                    Dim cl_script8 As New StringBuilder
                    cl_script8.Append(" alert('" & para(4).Value & "..!! ');")
                    '   cl_script8.Append("       window.open('new_tour_sanction_wform.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script8.ToString, True)
                    pageload()
                ElseIf para(3).Value = 0 Then
                    Dim cl_script8 As New StringBuilder
                    cl_script8.Append(" alert('" & para(4).Value & "..!! ');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script8.ToString, True)

                End If
            Catch ex As Exception
                Dim cl_script11 As New StringBuilder
                cl_script11.Append("   alert('" & ex.ToString & " ') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script11.ToString, True)

            Finally
            End Try
        End If
    End Sub

    Protected Sub Cmd_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Cancel.Click

        If Me.Cmb_TourDetails.SelectedValue <> 0 Then

            Dim userid As String = Me.Session("user_id")
            Dim uid() As String = userid.Split("!")
            Dim ecode1 As Integer = uid(0)
            Me.ttype = Me.Cmb_TourDetails.SelectedValue
            Try
                Dim para(4) As OracleParameter

                para(0) = New OracleParameter("tcase", OracleType.Number, 8)
                para(0).Value = Me.ttype
                para(0).Direction = ParameterDirection.Input

                para(1) = New OracleParameter("empcode", OracleType.Number, 5)
                para(1).Value = ecode1
                para(1).Direction = ParameterDirection.Input

                para(2) = New OracleParameter("branchid", OracleType.Number, 5)
                para(2).Value = -999
                para(2).Direction = ParameterDirection.Input

                para(3) = New OracleParameter("msg", OracleType.VarChar, 80)
                para(3).Direction = ParameterDirection.Output

                para(4) = New OracleParameter("flag", OracleType.Number, 2)
                para(4).Direction = ParameterDirection.Output

                oh.ExecuteDataSet("hrm_tour_sanctions", para)

                If para(4).Value = 1 Then
                    Dim cl_script8 As New StringBuilder
                    cl_script8.Append(" alert('" & para(3).Value & "..!! ');")
                    '  cl_script8.Append("       window.open('new_tour_sanction_wform.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script8.ToString, True)
                    pageload()
                Else
                    Dim cl_script8 As New StringBuilder
                    cl_script8.Append(" alert('" & para(3).Value & "..!! ');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script8.ToString, True)
                End If

            Catch ex As Exception
                Dim cl_script11 As New StringBuilder
                cl_script11.Append("   alert('" & ex.ToString & " ') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script11.ToString, True)

            Finally
            End Try
        End If
    End Sub
    Protected Sub cmd_rec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_rec.Click
        If Me.Cmb_TourDetails.SelectedValue <> 0 Then
            Dim userid As String = Me.Session("user_id")
            Dim uid() As String = userid.Split("!")
            Dim ecode1 As Integer = uid(0)
            Me.ttype = Me.Cmb_TourDetails.SelectedValue


	    Dim script1 As New System.Text.StringBuilder()
            Dim numy As Integer = Me.Session("SrlNO")
            str6 = "select count(*) from FIELDPNCH_INSERT k where k.srnos = " & numy & " "
            dt10 = oh.ExecuteDataSet(str6).Tables(0)

            If dt10.Rows(0)(0) > 0 Then

                If Me.TextBox3.Text = "" Then
                    Dim cl_script11 As New StringBuilder
                    cl_script11.Append("   alert('please enter the remark ') ;")
                    cl_script11.Append("window.open('new_tour_sanction_wform.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script11.ToString, True)
                    Exit Sub
                End If
            End If


            Try
                Dim para(4) As OracleParameter

                para(0) = New OracleParameter("tcase", OracleType.Number, 8)
                para(0).Value = Me.ttype
                para(0).Direction = ParameterDirection.Input

                para(1) = New OracleParameter("empcode", OracleType.Number, 5)
                para(1).Value = ecode1
                para(1).Direction = ParameterDirection.Input

                para(2) = New OracleParameter("branchid", OracleType.Number, 5)
                para(2).Value = -9999
                para(2).Direction = ParameterDirection.Input

                para(3) = New OracleParameter("msg", OracleType.VarChar, 80)
                para(3).Direction = ParameterDirection.InputOutput
                para(3).Value = Me.TextBox3.Text

                para(4) = New OracleParameter("flag", OracleType.Number, 2)
                para(4).Direction = ParameterDirection.Output

                oh.ExecuteDataSet("hrm_tour_sanctions", para)

                If para(4).Value = 1 Then
                    Dim cl_script8 As New StringBuilder
                    cl_script8.Append(" alert('" & para(3).Value & "..!! ');")
                    '  cl_script8.Append("       window.open('new_tour_sanction_wform.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script8.ToString, True)
                    pageload()
                Else
                    Dim cl_script8 As New StringBuilder
                    cl_script8.Append(" alert('" & para(3).Value & "..!! ');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script8.ToString, True)
                End If


            Catch ex As Exception
                Dim cl_script11 As New StringBuilder
                cl_script11.Append("   alert('" & ex.ToString & " ') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script11.ToString, True)

            Finally
            End Try
        End If


    End Sub

    Protected Sub Chk_sac_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_sac.CheckedChanged
        Dim userid As String = Me.Session("user_id")
        Dim uid() As String = userid.Split("!")
        Dim sql As String = ""
        If Me.Chk_sac.Checked = True Then
            Me.Chk_rec.Checked = False
            Me.cmd_rec.Visible = False
            Me.Cmd_Confirm.Visible = True
            If Me.Chk_Br.Checked = True Then
                Me.Chk_ho.Checked = False
                Dim dtt As New DataTable 'Branch staff sanction

                sql = "select t.post_id from mactech.employee_master t where t.emp_code='" & uid(0) & "'"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                If dt.Rows(0)(0) = 1209 Then

                    sql1 = "select count(ht.emp_code) from hrm_tour_dtl ht, employee_master em, branch bm1, othleave_sanction_authority a, department_mst m where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_recby = 0 and a.t_sanby =" & uid(0) & " and ht.emp_code <> " & uid(0) & " and m.dep_id = 542 and em.department_id = m.dep_id and ht.tour_id in (0) and nvl(ht.to_branch, 0) = bm1.branch_id and a.branch_id <> 0 order by emp_name"
                    sql2 = "select count(ht.emp_code) from hrm_tour_dtl ht, employee_master em, branch bm1, othleave_sanction_authority a, department_mst m where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_recby <> 0 and a.t_sanby =" & uid(0) & " and ht.emp_code <> " & uid(0) & " and m.dep_id = 542 and em.department_id = m.dep_id and ht.tour_id in (4) and nvl(ht.to_branch, 0) = bm1.branch_id and a.branch_id <> 0 order by emp_name"
                    dt1 = oh.ExecuteDataSet(sql1).Tables(0)
                    dt2 = oh.ExecuteDataSet(sql2).Tables(0)
                    If dt1.Rows(0)(0) > 0 Then


                        dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_sanby = " & uid(0) & " and ht.emp_code <> " & uid(0) & "  and ht.tour_id in (4,5) and nvl(ht.to_branch, 0) = bm1.branch_id and a.branch_id<>0 union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id  and a.t_recby=0 and a.t_sanby=" & uid(0) & "  and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0,4) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id<>0 order by emp_name").Tables(0)
                        Cmb_TourDetails.DataSource = dtt
                        Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                        Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                        Cmb_TourDetails.DataBind()

                    End If
                    If dt2.Rows(0)(0) > 0 Then

                        dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_sanby = " & uid(0) & " and ht.emp_code <> " & uid(0) & "  and ht.tour_id in (4,5) and nvl(ht.to_branch, 0) = bm1.branch_id and a.branch_id<>0 union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id  and a.t_recby=0 and a.t_sanby=" & uid(0) & "  and ht.emp_code <>" & uid(0) & " and ht.tour_id in (4) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id<>0 order by emp_name").Tables(0)
                        Cmb_TourDetails.DataSource = dtt
                        Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                        Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                        Cmb_TourDetails.DataBind()
                    End If

                Else
                    dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_sanby = " & uid(0) & " and ht.emp_code <> " & uid(0) & "  and ht.tour_id in (4,5) and nvl(ht.to_branch, 0) = bm1.branch_id and a.branch_id<>0 union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id  and a.t_recby=0 and a.t_sanby=" & uid(0) & "  and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0,4) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id<>0 order by emp_name").Tables(0)
                    Cmb_TourDetails.DataSource = dtt
                    Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                    Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                    Cmb_TourDetails.DataBind()





                End If
                'dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_sanby = " & uid(0) & " and ht.emp_code <> " & uid(0) & "  and ht.tour_id in (0,4,5) and nvl(ht.to_branch, 0) = bm1.branch_id and a.branch_id<>0 union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id  and a.t_recby=0 and a.t_sanby=" & uid(0) & "  and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0,4) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id<>0 order by emp_name").Tables(0)
                'Cmb_TourDetails.DataSource = dtt
                'Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                'Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                'Cmb_TourDetails.DataBind()
            Else
                Me.Chk_ho.Checked = True
                Dim dtt As New DataTable 'Ho staff Sanction
                Dim fid As Integer
                fid = Session("firm_id")
                If fid = 28 Then
                    dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name  from dual union select ht.sr_number as srnumber,        ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||       to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||        to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||        bm1.branch_name || ' (Branch)' || '    Purpose: ' ||       decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name  from mactech.hrm_tour_dtl                ht,       mactech.employee_master             em,       branch                      bm1,       othleave_sanction_authority a where ht.emp_code = em.emp_code   and ht.emp_code = a.emp_id   and a.t_sanby = " & uid(0) & "   and ht.tour_id in (4, 5)   and nvl(ht.to_branch, 0) = bm1.branch_id   and a.branch_id = 0 union select ht.sr_number as srnumber,       ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||       to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||       to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||       decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name  from mactech.hrm_tour_dtl                ht,       mactech.employee_master             em,       mactech.branch                      bm1,       mactech.othleave_sanction_authority a where ht.emp_code = em.emp_code    and ht.emp_code = a.emp_id   and a.t_recby = 0   and a.t_sanby =" & uid(0) & "   and ht.tour_id in (0, 4)   and nvl(ht.to_branch, 0) = bm1.branch_id   and a.branch_id = 0 order by emp_name").Tables(0)
                    Cmb_TourDetails.DataSource = dtt
                    Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                    Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                    Cmb_TourDetails.DataBind()
                Else


                    dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose)  emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_sanby = " & uid(0) & " and ht.emp_code <> " & uid(0) & "  and ht.tour_id in (4,5) and nvl(ht.to_branch, 0) = bm1.branch_id and a.branch_id=0 union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id  and a.t_recby=0 and a.t_sanby=" & uid(0) & "  and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0,4) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id=0 order by emp_name").Tables(0)
                    Cmb_TourDetails.DataSource = dtt
                    Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                    Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                    Cmb_TourDetails.DataBind()
                End If
            End If

        Else
            Me.Chk_rec.Checked = True
            Me.cmd_rec.Visible = True
            Me.Cmd_Confirm.Visible = False
            Dim brid As Integer = Me.Session("branch_id")

            Dim ecode As Integer = uid(0)
            If Me.Chk_Br.Checked = True Then
                Me.Chk_ho.Checked = False
                Dim dtt As New DataTable 'Branch Recommendation
                dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1, othleave_sanction_authority a where ht.emp_code = em.emp_code   and ht.emp_code = a.emp_id and a.t_recby=" & uid(0) & " and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id<>0 ").Tables(0)
                Cmb_TourDetails.DataSource = dtt
                Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()
            Else
                Me.Chk_ho.Checked = True
                Dim dtt1 As New DataTable 'Ho staff Recommendation
                dtt1 = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1, othleave_sanction_authority a where ht.emp_code = em.emp_code   and ht.emp_code = a.emp_id and a.t_recby=" & uid(0) & " and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id=0 ").Tables(0)
                Cmb_TourDetails.DataSource = dtt1
                Cmb_TourDetails.DataValueField = dtt1.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dtt1.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()
            End If

        End If


        'Dim script1 As New System.Text.StringBuilder()
        'Dim numy As Integer = Me.Session("SrlNO")
        'str6 = "select count(*) from FIELDPNCH_INSERT k where k.srnos = " & numy & " "
        'dt10 = oh.ExecuteDataSet(str6).Tables(0)

        'If dt10.Rows(0)(0) > 0 Then

        '    'Me.n2.Visible = False
        '    'Me.n7.Visible = True
        '    'Me.TextBox3.Visible = False
        '    'Me.TextBox4.Visible = True


        '    dt = oh.ExecuteDataSet("select k.remarks from fieldpnch_insert k where k.srnos=" & numy & " ").Tables(0)
        '    'If dt12.Rows(0)(0) Then
        '    Me.TextBox4.Text = dt.Rows(0)(0)
        'End If


    End Sub

    Protected Sub Chk_rec_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_rec.CheckedChanged
        If Me.Chk_rec.Checked = True Then
            Me.Txt_rec.Visible = False
            Me.Chk_sac.Checked = False
            Me.Cmd_Confirm.Visible = False
            Me.cmd_rec.Visible = True
            Dim brid As Integer = Me.Session("branch_id")

            Dim userid As String = Me.Session("user_id")
            Dim uid() As String = userid.Split("!")
            Dim ecode As Integer = uid(0)
            If Me.Chk_Br.Checked = True Then
                Me.Chk_ho.Checked = False
                Dim dtt As New DataTable 'Branch staff Recommendation
                dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1, othleave_sanction_authority a where ht.emp_code = em.emp_code   and ht.emp_code = a.emp_id and a.t_recby=" & uid(0) & " and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id<>0  order by emp_name").Tables(0)
                Cmb_TourDetails.DataSource = dtt
                Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()
            Else
                Me.Chk_ho.Checked = True
                Dim dtt1 As New DataTable 'Ho staff Recommendation
                dtt1 = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1, othleave_sanction_authority a where ht.emp_code = em.emp_code   and ht.emp_code = a.emp_id and a.t_recby=" & uid(0) & " and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id=0  order by emp_name").Tables(0)
                Cmb_TourDetails.DataSource = dtt1
                Cmb_TourDetails.DataValueField = dtt1.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dtt1.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()
            End If
        Else
            Me.Chk_sac.Checked = True
            Me.Cmd_Confirm.Visible = False
            Me.Cmd_Confirm.Visible = True
            Dim brid As Integer = Me.Session("branch_id")

            Dim userid As String = Me.Session("user_id")
            Dim uid() As String = userid.Split("!")
            Dim ecode As Integer = uid(0)

            If Me.Chk_Br.Checked = True Then
                Me.Chk_ho.Checked = False
                Dim dtt As New DataTable 'Branch staff sanction
                dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_sanby = " & uid(0) & " and ht.emp_code <> " & uid(0) & "  and ht.tour_id in (0,4,5) and nvl(ht.to_branch, 0) = bm1.branch_id  and a.branch_id<>0 union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id  and a.t_recby=0 and a.t_sanby=" & uid(0) & "  and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0,4) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id<>0 order by emp_name").Tables(0)
                Cmb_TourDetails.DataSource = dtt
                Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()
            Else
                Me.Chk_ho.Checked = True
                Dim dtt As New DataTable 'Ho staff Sanction
                dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_sanby = " & uid(0) & " and ht.emp_code <> " & uid(0) & "  and ht.tour_id in (4,5) and nvl(ht.to_branch, 0) = bm1.branch_id   and a.branch_id=0  union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id  and a.t_recby=0 and a.t_sanby=" & uid(0) & "  and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0,4) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id=0 order by emp_name").Tables(0)
                Cmb_TourDetails.DataSource = dtt
                Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()
            End If

        End If

        Dim script1 As New System.Text.StringBuilder()
        Dim numk As Integer = Me.Session("SrlNO")
        str7 = "select count(*) from FIELDPNCH_INSERT k where k.srnos = " & numk & " "
        dt11 = oh.ExecuteDataSet(str7).Tables(0)
        If dt11.Rows(0)(0) > 0 Then

            'Me.n2.Visible = True
            'Me.n7.Visible = False
            'Me.TextBox3.Visible = True
            'Me.TextBox4.Visible = False


        End If

    End Sub

    Protected Sub Chk_Br_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_Br.CheckedChanged
        If Me.Chk_Br.Checked = True Then
            Me.Chk_ho.Checked = False
            If Me.Chk_sac.Checked = True Then
                Me.cmd_rec.Visible = False
                Me.Cmd_Confirm.Visible = True
                Dim brid As Integer = Me.Session("branch_id")

                Dim userid As String = Me.Session("user_id")
                Dim uid() As String = userid.Split("!")
                Dim ecode As Integer = uid(0)

                Dim dtt As New DataTable 'Branch staff sanction
                dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_sanby = " & uid(0) & " and ht.emp_code <> " & uid(0) & "  and ht.tour_id in (0,4,5) and nvl(ht.to_branch, 0) = bm1.branch_id and a.branch_id<>0 union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id  and a.t_recby=0 and a.t_sanby=" & uid(0) & "  and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0,4) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id<>0  order by emp_name").Tables(0)
                Cmb_TourDetails.DataSource = dtt
                Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()

            Else 'Branch staff recommendation
                Me.cmd_rec.Visible = True
                Me.Cmd_Confirm.Visible = False
                Dim brid As Integer = Me.Session("branch_id")

                Dim userid As String = Me.Session("user_id")
                Dim uid() As String = userid.Split("!")
                Dim ecode As Integer = uid(0)
                Dim dtt As New DataTable
                dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1, othleave_sanction_authority a where ht.emp_code = em.emp_code   and ht.emp_code = a.emp_id and a.t_recby=" & uid(0) & " and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0) and nvl(ht.to_branch,0) = bm1.branch_id  and a.branch_id<>0 order by emp_name").Tables(0)
                Cmb_TourDetails.DataSource = dtt
                Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()
            End If
        Else
            Me.Chk_ho.Checked = True
            Dim dtt4, dtt6, dtt7 As New DataTable

            Dim brid As Integer = Me.Session("branch_id")

            Dim userid As String = Me.Session("user_id")
            Dim uid() As String = userid.Split("!")
            Dim ecode As Integer = uid(0)
            Dim dep As String = ""
            If Me.Chk_sac.Checked = True Then
                Me.cmd_rec.Visible = False
                Me.Cmd_Confirm.Visible = True
                Dim dtt As New DataTable 'Ho staff Sanction

                Dim fid As Integer
                fid = Session("firm_id")
                If fid = 28 Then
                    dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name  from dual union select ht.sr_number as srnumber,        ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||       to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||        to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||        bm1.branch_name || ' (Branch)' || '    Purpose: ' ||       decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name  from mactech.hrm_tour_dtl                ht,       mactech.employee_master             em,       branch                      bm1,       othleave_sanction_authority a where ht.emp_code = em.emp_code   and ht.emp_code = a.emp_id   and a.t_sanby = " & uid(0) & "   and ht.tour_id in (4, 5)   and nvl(ht.to_branch, 0) = bm1.branch_id   and a.branch_id = 0 union select ht.sr_number as srnumber,       ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||       to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||       to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||       decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name  from mactech.hrm_tour_dtl                ht,       mactech.employee_master             em,       mactech.branch                      bm1,       mactech.othleave_sanction_authority a where ht.emp_code = em.emp_code    and ht.emp_code = a.emp_id   and a.t_recby = 0   and a.t_sanby =" & uid(0) & "   and ht.tour_id in (0, 4)   and nvl(ht.to_branch, 0) = bm1.branch_id   and a.branch_id = 0 order by emp_name").Tables(0)
                    Cmb_TourDetails.DataSource = dtt
                    Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                    Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                    Cmb_TourDetails.DataBind()
                Else


                    dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_sanby = " & uid(0) & " and ht.emp_code <> " & uid(0) & "  and ht.tour_id in (4,5) and nvl(ht.to_branch, 0) = bm1.branch_id   and a.branch_id=0 union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id  and a.t_recby=0 and a.t_sanby=" & uid(0) & "  and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0,4) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id=0 order by emp_name").Tables(0)
                    Cmb_TourDetails.DataSource = dtt
                    Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                    Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                    Cmb_TourDetails.DataBind()
                End If
            Else
                Me.cmd_rec.Visible = True
                Me.Cmd_Confirm.Visible = False
                Dim dtt1 As New DataTable 'Ho staff Recommendation
                dtt1 = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1, othleave_sanction_authority a where ht.emp_code = em.emp_code   and ht.emp_code = a.emp_id and a.t_recby=" & uid(0) & " and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id=0  order by emp_name").Tables(0)
                Cmb_TourDetails.DataSource = dtt1
                Cmb_TourDetails.DataValueField = dtt1.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dtt1.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()
            End If
        End If

    End Sub

    Protected Sub Chk_ho_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_ho.CheckedChanged
        If Me.Chk_ho.Checked = False Then
            Me.Chk_Br.Checked = True
            If Me.Chk_sac.Checked = True Then
                Me.cmd_rec.Visible = False
                Me.Cmd_Confirm.Visible = True
                Dim brid As Integer = Me.Session("branch_id")

                Dim userid As String = Me.Session("user_id")
                Dim uid() As String = userid.Split("!")
                Dim ecode As Integer = uid(0)

                Dim dtt As New DataTable 'Branch staff sanction

                Dim fid As Integer
                fid = Session("firm_id")
                If fid = 28 Then
                    dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name  from dual union select ht.sr_number as srnumber,        ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||       to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||        to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||        bm1.branch_name || ' (Branch)' || '    Purpose: ' ||       decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name  from mactech.hrm_tour_dtl                ht,       mactech.employee_master             em,       branch                      bm1,       othleave_sanction_authority a where ht.emp_code = em.emp_code   and ht.emp_code = a.emp_id   and a.t_sanby = " & uid(0) & "   and ht.tour_id in (4, 5)   and nvl(ht.to_branch, 0) = bm1.branch_id   and a.branch_id = 0 union select ht.sr_number as srnumber,       ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||       to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||       to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||       decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name  from mactech.hrm_tour_dtl                ht,       mactech.employee_master             em,       mactech.branch                      bm1,       mactech.othleave_sanction_authority a where ht.emp_code = em.emp_code    and ht.emp_code = a.emp_id   and a.t_recby = 0   and a.t_sanby =" & uid(0) & "   and ht.tour_id in (0, 4)   and nvl(ht.to_branch, 0) = bm1.branch_id   and a.branch_id = 0 order by emp_name").Tables(0)
                    Cmb_TourDetails.DataSource = dtt
                    Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                    Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                    Cmb_TourDetails.DataBind()
                Else
                    dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_sanby = " & uid(0) & " and ht.emp_code <> " & uid(0) & "  and ht.tour_id in (0,4,5) and nvl(ht.to_branch, 0) = bm1.branch_id and a.branch_id<>0 union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id  and a.t_recby=0 and a.t_sanby=" & uid(0) & "  and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0,4) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id<>0 order by emp_name").Tables(0)
                    Cmb_TourDetails.DataSource = dtt
                    Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                    Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                    Cmb_TourDetails.DataBind()
                End If


            Else 'Branch staff recommendation
                Dim brid As Integer = Me.Session("branch_id")
                Me.cmd_rec.Visible = True
                Me.Cmd_Confirm.Visible = False
                Dim userid As String = Me.Session("user_id")
                Dim uid() As String = userid.Split("!")
                Dim ecode As Integer = uid(0)
                Dim dtt As New DataTable
                dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1, othleave_sanction_authority a where ht.emp_code = em.emp_code   and ht.emp_code = a.emp_id and a.t_recby=" & uid(0) & " and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0) and nvl(ht.to_branch,0) = bm1.branch_id  and a.branch_id<>0  order by emp_name").Tables(0)
                Cmb_TourDetails.DataSource = dtt
                Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()
            End If
        Else
            Me.Chk_ho.Checked = True
            Me.Chk_Br.Checked = False
            Dim dtt4, dtt6, dtt7 As New DataTable

            Dim brid As Integer = Me.Session("branch_id")

            Dim userid As String = Me.Session("user_id")
            Dim uid() As String = userid.Split("!")
            Dim ecode As Integer = uid(0)
            Dim dep As String = ""
            If Me.Chk_sac.Checked = True Then

                Dim dtt As New DataTable 'Ho staff Sanction

                Dim fid As Integer
                fid = Session("firm_id")
                If fid = 28 Then
                    dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name  from dual union select ht.sr_number as srnumber,        ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||       to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||        to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||        bm1.branch_name || ' (Branch)' || '    Purpose: ' ||       decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name  from mactech.hrm_tour_dtl                ht,       mactech.employee_master             em,       branch                      bm1,       othleave_sanction_authority a where ht.emp_code = em.emp_code   and ht.emp_code = a.emp_id   and a.t_sanby = " & uid(0) & "   and ht.tour_id in (4, 5)   and nvl(ht.to_branch, 0) = bm1.branch_id   and a.branch_id = 0 union select ht.sr_number as srnumber,       ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||       to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||       to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||       decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name  from mactech.hrm_tour_dtl                ht,       mactech.employee_master             em,       mactech.branch                      bm1,       mactech.othleave_sanction_authority a where ht.emp_code = em.emp_code    and ht.emp_code = a.emp_id   and a.t_recby = 0   and a.t_sanby =" & uid(0) & "   and ht.tour_id in (0, 4)   and nvl(ht.to_branch, 0) = bm1.branch_id   and a.branch_id = 0 order by emp_name").Tables(0)
                    Cmb_TourDetails.DataSource = dtt
                    Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                    Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                    Cmb_TourDetails.DataBind()
                Else
                    dtt = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id and a.t_sanby = " & uid(0) & " and ht.emp_code <> " & uid(0) & "  and ht.tour_id in (4,5) and nvl(ht.to_branch, 0) = bm1.branch_id  and a.branch_id=0 union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||       bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1,othleave_sanction_authority a where ht.emp_code = em.emp_code and ht.emp_code = a.emp_id  and a.t_recby=0 and a.t_sanby=" & uid(0) & "  and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0,4) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id=0 order by emp_name").Tables(0)
                    Cmb_TourDetails.DataSource = dtt
                    Cmb_TourDetails.DataValueField = dtt.Columns(0).ColumnName
                    Cmb_TourDetails.DataTextField = dtt.Columns(1).ColumnName
                    Cmb_TourDetails.DataBind()
                End If

            Else
                Dim dtt1 As New DataTable 'Ho staff Recommendation
                dtt1 = oh.ExecuteDataSet("select 0 as srnumber, ' Please Select ' emp_name from dual union select ht.sr_number as srnumber,ht.emp_code || '       ' || em.emp_name || '       ' || 'from:' || ' ' ||to_char(ht.from_dt) || '       ' || 'To:' || ' ' ||to_char(ht.to_dt) || '       ' || 'Tour To:' || ' ' ||bm1.branch_name || ' (Branch)' || '    Purpose: ' ||decode(ht.tour_purpose, null, 'Not Specified', ht.tour_purpose) emp_name from hrm_tour_dtl ht,employee_master em,branch bm1, othleave_sanction_authority a where ht.emp_code = em.emp_code   and ht.emp_code = a.emp_id and a.t_recby=" & uid(0) & " and ht.emp_code <>" & uid(0) & " and ht.tour_id in (0) and nvl(ht.to_branch,0) = bm1.branch_id and a.branch_id=0 order by emp_name ").Tables(0)
                Cmb_TourDetails.DataSource = dtt1
                Cmb_TourDetails.DataValueField = dtt1.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dtt1.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()
            End If
        End If
    End Sub

    'Protected Sub view_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles view.Click
    '    'usr = Me.Session("user_id").ToString.Split("!")
    '    Dim cl_script11 As New StringBuilder
    '    cl_script11.Append("window.open('Copy of new_tour_sanction_wform.aspx');")
    '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script11.ToString, True)
    'End Sub


End Class
