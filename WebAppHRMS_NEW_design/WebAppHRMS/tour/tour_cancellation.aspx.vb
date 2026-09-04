Imports System.Data
Imports System.Data.OracleClient
Partial Class tour_cancellation_tour_cancellation_76b853296144
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim dt, dt1, dtt As New DataTable
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

    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim usr() As String
        usr = Session("user_id").ToString.Split("!")
        Dim in_data = eventArgument.Split("@")
        Dim firm = Session("firm_id")
        Dim dr As DataRow
        Dim st As New StringBuilder
        If in_data(0) = 3 Then

            sql = "select branch_id,department_id,post_id from employee_master e where e.emp_code=" & usr(0)
            Dim dt As DataTable = oh.ExecuteDataSet(sql).Tables(0)
            dtt = oh.ExecuteDataSet("select count(r.reg_id) from region_master r where r.ia_tour_head=" & usr(0) & "").Tables(0)

            Dim dtacs As New DataTable
            dtacs = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=890 and s.emp_id=" & usr(0) & "").Tables(0)

            'adding rule from database 
            Dim ruldt As DataTable
            Dim rulcmd As String
            Dim rulqry As String = ""

            rulcmd = "select * from ho_tour_rule ht where ht.stats_id=1 and ht.rule=2 and ht.emp_code=" & usr(0) & " order by ht.rule"
            ruldt = oh.ExecuteDataSet(rulcmd).Tables(0)

            If ruldt.Rows.Count > 0 Then

                Dim rowCount As Integer = ruldt.Rows.Count
                For rowCounter As Integer = 0 To rowCount - 1
                    rulqry = rulqry + ruldt.Rows(rowCounter)(2).ToString
                Next

                sql = rulqry

            ElseIf (dtacs.Rows(0)(0) = 1) Then
                sql = "select distinct e.emp_code || ' - ' || e.emp_name from hrm_tour_dtl t ,employee_master e,employ_firm ef where t.emp_code=e.emp_code and t.tour_id in (0,4,1)  and e.emp_code=ef.emp_code and ef.firm_id=" & firm


            ElseIf usr(0) = 30239 Then
                sql = "select distinct e.emp_code || ' - ' || e.emp_name,e.emp_code from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and (t.tour_id in (0,4) or (t.tour_id=1 and to_date(t.to_dt)>=to_date(sysdate)))and e.branch_id=0 and e.department_id in (4,178,188) union select distinct e.emp_code || ' - ' || e.emp_name,e.emp_code from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and (t.tour_id in (0,4) or (t.tour_id=1 and to_date(t.to_dt)>=to_date(sysdate))) and e.department_id in (4,178,188)  and e.branch_id <> 0 order by emp_code "
            ElseIf (usr(0) = 32706 Or usr(0) = 65161) Then
                sql = "select distinct e.emp_code || ' - ' || e.emp_name,e.emp_code from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and (t.tour_id in (0,4) or (t.tour_id=1 and to_date(t.to_dt)>=to_date(sysdate)))and e.branch_id=0 and e.department_id in (490,517) union select distinct e.emp_code || ' - ' || e.emp_name,e.emp_code from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and (t.tour_id in (0,4) or (t.tour_id=1 and to_date(t.to_dt)>=to_date(sysdate))) and e.department_id in (490,517)  and e.branch_id <> 0 order by emp_code "
            ElseIf usr(0) = 22246 Then
                sql = "select distinct e.emp_code || ' - ' || e.emp_name, e.emp_code  from hrm_tour_dtl t, employee_master e  where t.emp_code = e.emp_code  and (t.tour_id in (0, 4) or  (t.tour_id = 1 and to_date(t.to_dt) >= to_date(sysdate)))  and e.branch_id = 0and e.emp_code in (53730, 47781, 10988, 16862,42585)  union  select distinct e.emp_code || ' - ' || e.emp_name, e.emp_code  from hrm_tour_dtl t, employee_master e  where t.emp_code = e.emp_code  and (t.tour_id in (0, 4) or  (t.tour_id = 1 and to_date(t.to_dt) >= to_date(sysdate)))  and e.department_id in (466,4)  and e.branch_id <> 0  order by emp_code"
            Else

                If dtt.Rows(0)(0) > 0 Then

                    sql = "select distinct e.emp_code || ' - ' || e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and (t.tour_id in (0,4) or (t.tour_id=1 and to_date(t.to_dt)>=to_date(sysdate))) and e.department_id in (4,178,188)  and e.branch_id in (select b1.branch_id from region_master b,branch_dtl_new b1 where b1.reg_id=b.reg_id and b.ia_tour_head=" & usr(0) & ")"
                Else


                    If dt.Rows(0)(0) = 0 And usr(0) <> 30239 And usr(0) <> 30133 Then

                        sql = "select count(*) from department_mst where dep_head=" & dt.Rows(0)(1)
                        Dim dep1 As DataTable = oh.ExecuteDataSet(sql).Tables(0)


                        If dep1.Rows(0)(0) > 0 Then
                            Dim sql115 As String = "select t.dep_id from department_mst t where t.dep_head =" & usr(0) & ""
                            Dim dte As DataTable = oh.ExecuteDataSet(sql115).Tables(0)
                            Dim dr1 As DataRow
                            Dim dep As String = " "
                            For Each dr1 In dte.Rows
                                If dep = " " Then
                                    dep = dr1(0)
                                Else
                                    dep = dep.ToString + "," + dr1(0).ToString
                                End If

                            Next
                            sql = "select distinct e.emp_code || ' - ' || e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and (t.tour_id in (0,4) or (t.tour_id=1 and t.from_dt>=to_date(sysdate)))and e.branch_id=0 and e.department_id in (" & dep & ") union select distinct e.emp_code || ' - ' || e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and (t.tour_id in (0,4) or (t.tour_id=1 and t.from_dt>=to_date(sysdate))) and e.department_id in (" & dep & ")  and e.branch_id <> 0 and e.department_id in (4,23,38,178,179,180,183,188,189) "

                        ElseIf dt.Rows(0)(2) = 173 Then
                            Dim s As DataTable = oh.ExecuteDataSet("select zonal_id from zonal_master where head_id=" & usr(0)).Tables(0)
                            sql = "select distinct e.emp_code || ' - ' || e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and (t.tour_id in (0,4) or (t.tour_id=1 and t.from_dt>=to_date(sysdate))) and ((e.post_id in (28) and (e.branch_id in ( select branch_id  from area_detail where area_id in (select area_id from division_detail where div_id in (select division_id from region_detail where region_id in (select region_id from zonal_detail where zonal_id=" & s.Rows(0)(0) & " )))) ))  or t.emp_code=" & usr(0) & " ) union select distinct e.emp_code || ' - ' || e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and (t.tour_id in (0,4) or (t.tour_id=1 and t.from_dt>=to_date(sysdate))) and e.post_id not in (10,11,136,134,141,28,173) AND E.DEPARTMENT_ID not in (4,23,37,5,38) and e.branch_id<>0 and         e.branch_id in ( select branch_id  from area_detail where area_id in (select area_id from division_detail where div_id in (select division_id from region_detail where region_id in (select region_id from zonal_detail where zonal_id=" & s.Rows(0)(0) & " ))))"
                        Else
                            sql = "select distinct e.emp_code || ' - ' || e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and t.tour_id in (0,4)  and e.emp_code=" & usr(0)
                        End If




                    ElseIf dt.Rows(0)(2) = 28 Or dt.Rows(0)(2) = 199 And (dt.Rows(0)(1) <> 4 Or dt.Rows(0)(1) <> 178 Or dt.Rows(0)(1) <> 188) Then
                        Dim s As DataTable = oh.ExecuteDataSet("select reg_id  from region_master where head_id=" & usr(0)).Tables(0)
                        sql = "select distinct e.emp_code || ' - ' || e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and (t.tour_id in (0,4) or (t.tour_id=1 and t.from_dt>=to_date(sysdate))) and ((e.post_id in(136,141,134) and (e.branch_id in (select branch_id from area_detail where area_id in (select area_id from division_detail where div_id in (select division_id from region_detail where region_id=" & s.Rows(0)(0) & " ))))) or t.emp_code=" & usr(0) & " ) union union select distinct e.emp_code || ' - ' || e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and (t.tour_id in (0,4) or (t.tour_id=1 and t.from_dt>=to_date(sysdate))) and e.post_id not in (10,11,136,134,141,28,173) AND E.DEPARTMENT_ID not in (4,23,37,5,38) and e.branch_id<>0 and  e.branch_id in (select branch_id from area_detail where area_id in (select area_id from division_detail where div_id in (select division_id from region_detail where region_id=" & s.Rows(0)(0) & " )))"
                    ElseIf dt.Rows(0)(2) = 136 Or dt.Rows(0)(2) = 134 Or dt.Rows(0)(2) = 141 Then
                        Dim s As DataTable = oh.ExecuteDataSet("select area_id  from area_master where area_head_id=" & usr(0)).Tables(0)
                        sql = "select distinct e.emp_code || ' - ' || e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and (t.tour_id in (0,4) or (t.tour_id=1 and t.from_dt>=to_date(sysdate))) and ((e.post_id in(10,11) and (e.branch_id in (select branch_id from area_detail where area_id=" & s.Rows(0)(0) & " ))) or t.emp_code=" & usr(0) & " ) and e.branch_id<>0 union select distinct e.emp_code || ' - ' || e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and (t.tour_id in (0,4) or (t.tour_id=1 and t.from_dt>=to_date(sysdate))) and e.post_id not in (10,11,136,134,141,28,173) AND E.DEPARTMENT_ID not in (4,23,37,5,38) and e.branch_id<>0 and  e.branch_id in (select branch_id from area_detail where area_id=" & s.Rows(0)(0) & " )"
                    ElseIf dt.Rows(0)(2) = 10 Then
                        sql = "select distinct e.emp_code || ' - ' || e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code AND E.DEPARTMENT_ID not in (20,4,23,37,5,38) and (t.tour_id in (0,4) or (t.tour_id=1 and t.from_dt>=to_date(sysdate))) and e.branch_id=" & dt.Rows(0)(0)
                    Else
                        sql = "select distinct e.emp_code || ' - ' || e.emp_name from hrm_tour_dtl t ,employee_master e where t.emp_code=e.emp_code and t.tour_id in (0,4)  and e.emp_code=" & usr(0)

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

            sql = "select '---------Select----------'||'*'||'0#0' from dual union select from_dt || ' - ' ||to_dt || ' - ' || from_time || ' - ' || to_time || ' - ' || advance_rs || ' - ' || case when t.to_branch in(select branch_id from branch_master) then (select branch_name from branch_master br where br.branch_id=t.to_branch) else (select branch_name from before_completion bc where bc.old_id=t.to_branch) end || ' - ' || tour_purpose||'*'||sr_number||'#'||from_dt||'#'||to_dt||'#'||from_time ||'#'||to_time ||'#'||advance_rs||'#'||case when t.to_branch is null then t.others else case when t.to_branch in(select branch_id from branch_master) then (select branch_name from branch_master br where br.branch_id=t.to_branch) else (select branch_name from before_completion bc where bc.old_id=t.to_branch) end end ||'#'||tour_purpose from hrm_tour_dtl t where (t.tour_id in (0,4) or (t.tour_id = 1 and (to_date(t.to_dt) >= to_date(sysdate) or to_date(t.to_dt)>=to_date('01-'||to_char(sysdate,'MON-YYYY'))))) and t.emp_code=" & in_data(1) & " order by 1"
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
        Dim str() As String
        str = Session("user_id").ToString.Split("!")
        Dim seqno = Me.cmb_tour.SelectedValue
        ''Krishnadas changed for macare request

        If Me.Hidden2.Value <> 0 Then

            Dim param(2) As OracleParameter
            param(0) = New OracleParameter("sr_no", OracleType.VarChar, 200)
            param(0).Direction = ParameterDirection.Input
            param(0).Value = Me.Hidden2.Value

            param(1) = New OracleParameter("userid", OracleType.VarChar, 200)
            param(1).Direction = ParameterDirection.Input
            param(1).Value = str(0)

            param(2) = New OracleParameter("flag", OracleType.VarChar, 200)
            param(2).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_tour_cancellation", param)

            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('" & param(2).Value & "!!') ;")
            cl_script.Append("   window.open('tour_cancellation.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)

        End If
    End Sub
End Class

