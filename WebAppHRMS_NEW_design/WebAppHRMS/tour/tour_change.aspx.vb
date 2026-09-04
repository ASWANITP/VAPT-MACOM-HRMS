Imports System.Data
Imports System.Data.OracleClient
Partial Class tour_cancellation_tour_cancellation_76b853294593
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim dt, dt1, dtau As New DataTable
    Dim sql, res As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim st As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server(arg,context) { " & cbref & "; } "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.cmb_tour.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        If Not IsPostBack Then
            Me.Txt_chng_dt.Text = Format(Date.Now, "dd/MMM/yyyy")
        End If

    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim usr() As String
        usr = Session("user_id").ToString.Split("!")
        Dim in_data = eventArgument.Split("@")
        Dim dr As DataRow
        Dim st As New StringBuilder
        If in_data(0) = 3 Then

            sql = "select branch_id,department_id,post_id from employee_master e where e.emp_code=" & usr(0)
            Dim dt As DataTable = oh.ExecuteDataSet(sql).Tables(0)

            dtau = oh.ExecuteDataSet("select count(r.reg_id) from region_master r where r.ia_tour_head=" & usr(0) & "").Tables(0)

            If dtau.Rows(0)(0) > 0 Then

                sql = "select distinct e.emp_code ||' - '|| e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and t.tour_id in (0,1,4) AND E.DEPARTMENT_ID in (4,178,188) and to_date(t.to_dt)>=to_date(sysdate) and e.branch_id<>0 and  e.branch_id in (select a.branch_id from branch_dtl_new a where a.reg_id in (select r.reg_id from region_master r where r.ia_tour_head=" & usr(0) & ") )"

            ElseIf usr(0) = 30239 Then

                sql = "select distinct e.emp_code ||' - '|| e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and t.tour_id in (0,1,4)  and to_date(t.to_dt)>=to_date(sysdate) AND E.DEPARTMENT_ID in (4,178,188) )"
            Else

                If dt.Rows(0)(0) = 0 Then
                    sql = "select count(*) from department_mst t where t.vg_tour_sac=" & usr(0) & " or t.adt_tour_sac=" & usr(0) & ""
                    Dim cmb_emp As DataTable = oh.ExecuteDataSet(sql).Tables(0)
                    If cmb_emp.Rows(0)(0) > 0 Then
                        Dim dtw As DataTable = oh.ExecuteDataSet("select count(*) from department_mst t where t.vg_tour_sac=" & usr(0) & " or t.adt_tour_sac=" & usr(0) & "").Tables(0)
                        If dtw.Rows(0)(0) > 0 Then
                            Dim sql115 As String = "select t.dep_id from department_mst t where t.vg_tour_sac =" & usr(0) & " or t.adt_tour_sac=" & usr(0) & ""
                            Dim dte As DataTable = oh.ExecuteDataSet(sql115).Tables(0)
                            Dim dr3 As DataRow
                            Dim dep3 As String = " "
                            For Each dr3 In dte.Rows
                                If dep3 = " " Then
                                    dep3 = dr3(0)
                                Else
                                    dep3 = dep3.ToString + "," + dr3(0).ToString
                                End If

                            Next
                        End If
                    End If




                    sql = "select count(*) from department_major t where t.head_id like '%" & usr(0) & "%'"
                    Dim dep As DataTable = oh.ExecuteDataSet(sql).Tables(0)


                    If dep.Rows(0)(0) > 0 Then
                        Dim dtw As DataTable = oh.ExecuteDataSet("select count(*) from department_major t where t.head_id like '%" & usr(0) & "%'").Tables(0)
                        If dtw.Rows(0)(0) > 0 Then
                            Dim sql1 As String = "select t.department_id from department_major t where t.head_id like '%" & usr(0) & "%'"
                            dt = oh.ExecuteDataSet(sql1).Tables(0)
                        End If
                        sql = "select distinct e.emp_code ||' - '|| e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and t.tour_id in (0,1,4) and e.branch_id=0  and to_date(t.to_dt)>=to_date(sysdate) and e.department_id in (select d.dep_id from department_mst d where d.major_dep_id=" & dt.Rows(0)(0) & ") union select distinct e.emp_code || ' - ' || e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and t.tour_id in (0,1,4) and e.department_id in (select d.dep_id from department_mst d where d.major_dep_id=" & dt.Rows(0)(0) & ")  and e.branch_id <> 0 and e.department_id in (20,37,5,38)"
                    End If


                    If dt.Rows(0)(2) = 173 Or dt.Rows(0)(2) = 195 Then
                        Dim s As DataTable = oh.ExecuteDataSet("select zonal_id from zonal_master where head_id=" & usr(0)).Tables(0)
                        sql = "select distinct e.emp_code ||' - '|| e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and t.tour_id in (0,4,1)  and to_date(t.to_dt)>=to_date(sysdate) and e.post_id in (28,199) AND e.DEPARTMENT_ID not in (4,178,188,12,180,183) and e.branch_id in ( select branch_id  from area_detail where area_id in (select area_id from division_detail where div_id in (select division_id from region_detail where region_id in (select region_id from zonal_detail where zonal_id=" & s.Rows(0)(0) & " ))))"
                    Else
                        sql = "select distinct e.emp_code ||' - '|| e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and t.tour_id in (0)   and to_date(t.to_dt)>=to_date(sysdate) and e.emp_code=" & usr(0)
                    End If


                End If






                If dt.Rows(0)(0) <> 0 Then
                    If dt.Rows(0)(2) = 28 Or dt.Rows(0)(2) = 199 Then
                        '  Dim s As DataTable = oh.ExecuteDataSet("select reg_id  from region_master where head_id=" & usr(0)).Tables(0)
                        sql = "select distinct e.emp_code ||' - '|| e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and t.tour_id in (0,1,4) and e.post_id in (136,134,141,28,173)  and to_date(t.to_dt)>=to_date(sysdate) AND E.DEPARTMENT_ID not in (4,178,188,12,180,183) and e.branch_id<>0 and  e.branch_id in (select a.branch_id from branch_dtl_new a where a.reg_id in (select b.reg_id  from employee_master e,branch_dtl_new b where e.emp_code=" & usr(0) & " and b.branch_id=e.branch_id and e.post_id in (28,199)) )"
                    End If
                    If dt.Rows(0)(2) = 136 Or dt.Rows(0)(2) = 134 Or dt.Rows(0)(2) = 141 Or dt.Rows(0)(2) = 131 Or dt.Rows(0)(2) = 197 Then
                        '  Dim s As DataTable = oh.ExecuteDataSet("select b.branch_id  from employee_master e,branch_dtl_new b where e.emp_code=" & usr(0) & " and e.post_id in (136,141,134,131,197)").Tables(0)
                        sql = "select distinct e.emp_code || ' - ' || e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and t.tour_id in (0,1,4) and e.post_id in (10,11,198) A and to_date(t.to_dt)>=to_date(sysdate) ND E.DEPARTMENT_ID not in (4,178,188,12,180,183) and e.branch_id<>0 and  e.branch_id in (select a.branch_id from branch_dtl_new a where a.area_id in (select b.area_id  from employee_master e,branch_dtl_new b where e.emp_code=" & usr(0) & " and b.branch_id=e.branch_id and e.post_id in (136,141,134,131,197)) )"
                    End If
                    If dt.Rows(0)(2) = 10 Then
                        sql = "select distinct e.emp_code || ' - ' || e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code AND E.DEPARTMENT_ID not in (4,178,188,12,180,183)  and to_date(t.to_dt)>=to_date(sysdate) and t.tour_id in (0,1,4) and e.branch_id=" & dt.Rows(0)(0)
                    Else
                        sql = "select distinct e.emp_code || ' - ' || e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and t.tour_id in (0)  and to_date(t.to_dt)>=to_date(sysdate) and e.emp_code=" & usr(0)
                    End If
                End If

            End If
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows.Count > 0 Then
                For Each dr In dt.Rows
                    st.Append(dr(0))
                    st.Append("#")
                Next
            Else
                st.Append("0")
            End If
            st.Append("^")
            st.Append("1")
        ElseIf in_data(0) = 1 Then

            sql = "select from_dt || ' - ' ||to_dt || ' - ' || from_time || ' - ' || to_time || ' - ' || advance_rs || ' - ' || case when t.to_branch in(select branch_id from branch_master) then (select branch_name from branch_master br where br.branch_id=t.to_branch) else (select branch_name from before_completion bc where bc.old_id=t.to_branch) end || ' - ' || tour_purpose||'*'||sr_number||'#'||from_dt||'#'||to_dt||'#'||from_time ||'#'||to_time ||'#'||advance_rs||'#'||case when t.to_branch is null then t.others else case when t.to_branch in(select branch_id from branch_master) then (select branch_name from branch_master br where br.branch_id=t.to_branch) else (select branch_name from before_completion bc where bc.old_id=t.to_branch) end end ||'#'||tour_purpose from hrm_tour_dtl t where (t.tour_id in (0,4) or (t.tour_id=1 and to_date(t.to_dt)>=to_date(sysdate))) and t.emp_code=" & in_data(1) & " order by t.from_dt"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows.Count <> 0 Then
                For Each dr In dt.Rows
                    st.Append(dr(0))
                    st.Append("!")
                Next
            Else
                st.Append("0")
            End If
            st.Append("^")
            st.Append("2")
        End If

            res = st.ToString()


            ''''''''confirm
            'If in_data(0) = 2 Then
            '    Dim dw() As String = in_data(1).ToString.Split("#")

            '    If dw(0) = 0 Then
            '        st.Append("No Record Is Selected For Short Listing")
            '        st.Append("^")
            '        st.Append("3")

            '    Else

            '        Dim param(1) As OracleParameter
            '        param(0) = New OracleParameter("sr_no", OracleType.VarChar, 200)
            '        param(0).Direction = ParameterDirection.Input
            '        param(0).Value = in_data(1)

            '        param(1) = New OracleParameter("flag", OracleType.VarChar, 200)
            '        param(1).Direction = ParameterDirection.Output

            '        oh.ExecuteNonQuery("hrm_tour_cancellation", param)

            '        st.Append(param(1).Value)
            '        st.Append("^")
            '        st.Append("3")

            '    End If
            'End If


    End Sub

    Protected Sub cmd_comfirm_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_comfirm.ServerClick
        Dim dats As DataTable = oh.ExecuteDataSet("select to_date(sysdate-1) from dual").Tables(0)
        If CDate(Me.Txt_chng_dt.Text) < CDate(dats.Rows(0)(0)) Then
            Me.Txt_chng_dt.Text = ""
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('Back date is not allowed') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub
        End If
        If CDate(Me.Txt_chng_dt.Text) < CDate(Me.lbl_fromdt.Value) Then
            Me.Txt_chng_dt.Text = ""
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('change date  should be greater than FROM date') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub
        End If
        If Me.Txt_chng_dt.Text = "" Then
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('Please enter changing date') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub
        End If
        If Me.Hidden2.Value <> 0 And Me.Txt_chng_dt.Text <> "" Then
            Dim param(3) As OracleParameter
            param(0) = New OracleParameter("sr_no", OracleType.VarChar, 200)
            param(0).Direction = ParameterDirection.Input
            param(0).Value = Me.Hidden2.Value
            param(1) = New OracleParameter("chn_dt", OracleType.DateTime)
            param(1).Direction = ParameterDirection.Input
            param(1).Value = Me.Txt_chng_dt.Text
            param(2) = New OracleParameter("old_dt", OracleType.DateTime)
            param(2).Direction = ParameterDirection.Input
            param(2).Value = Me.lbl_todate.Value
            param(3) = New OracleParameter("flag", OracleType.VarChar, 200)
            param(3).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("hrm_tour_change", param)

            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('" & param(1).Value & "!!') ;")
            cl_script.Append("   window.open('tour_change.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)

        End If
    End Sub


End Class

