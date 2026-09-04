Imports System.Data
Imports System.Data.oracleclient
Partial Class leave_compensatory_apply_0ddee57a8529
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim sql, sql1 As String
    Dim oh As New helper.oracle.OracleHelper
    'Dim oh As New OracleHelper
    Dim res As String
    Dim usr() As String
    Dim emp, dt, dt1 As New DataTable

    Dim firmid As Integer
    Dim branchid As Integer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '------VAPT - improper parameter validation---------------------------------------
        Dim paramCount As Integer = Request.QueryString.Count
        If Request.QueryString.Count > 0 Then
            Response.StatusCode = 400
            Response.StatusDescription = "Bad Request"
            Response.End()
        End If
        Try

            '---------------------------
            Try
                firmid = Convert.ToInt32(Me.Session("firm_id"))
                branchid = Me.Session("branch_id")

                If firmid = 24 Then
                    sql = "select nvl(t.branch_id,'NULL') branch ,t.block_all from hrm_block_leave_frm t where t.firm_id=24 and t.block_opt='APPLY'"
                    Dim dtCheck As New DataTable
                    Dim branch As String
                    dtCheck = oh.ExecuteDataSet(sql).Tables(0)
                    branch = dtCheck.Rows(0)(0)
                    Dim flag As Boolean = False
                    If dtCheck.Rows.Count > 0 Then
                        If dtCheck.Rows(0)(1) = "Y" Then
                            flag = True
                        End If
                        If branch <> "NULL" Then
                            Dim ar() = branch.Split(",")
                            Dim index As Integer
                            For index = 0 To ar.Length - 1
                                If Val(ar(index)) = branchid Then
                                    flag = True
                                    Exit For
                                End If
                            Next
                        End If

                        If flag = True Then
                            Dim cl_script As New StringBuilder
                            cl_script.Append("   alert('Leave Entry BLOCKED from HO') ;")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "BLOCKLEAVE", cl_script.ToString, True)
                            Return
                        End If
                    End If
                End If
            Catch ex As System.Exception
            End Try
            '---------------------------


            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "sub_call_receiver", "context")
            Dim cbscript As String = "function sub_call_server(arg,context) { " & cbref & "; } "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "sub_call_server", cbscript, True)

            Dim sc As String = "var cont_name;cont_name='" & Me.txt_apply_date.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var2", sc, True)

            usr = Me.Session("user_id").ToString.Split("!")
            Me.hid_emp_code.Value = usr(0)

            If Not IsPostBack Then
                Me.txt_apply_date.Value = Format(Date.Now, "dd/MMM/yyyy")
            End If
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub


    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim st1 As String
        Dim x = str(0)
        Dim dr As DataRow

          firmid = Convert.ToInt32(Me.Session("firm_id"))
        Try
            If x = 1 Then
                st.Append("11")
                st.Append("@")

                If firmid = 24 Then
                    sql = "select e.emp_code||'*'||e.emp_name||'*'||p.post_name||'*'||d.designation||'*'||dm.dep_name||'*'||b.branch_name||'*'||e.join_dt||'*'||case when e.emp_type=1 then 'REGULAR' else 'OUTSOURCE' end from  post_mst_jwell p,designation_master d,department_mst dm,branch b,employee_master e where e.post_id=p.post_id and e.department_id=dm.dep_id and d.designation_id=e.designation_id and e.branch_id=b.branch_id and emp_code=" & str(1) & ""
                Else
                    sql = "select e.emp_code||'*'||e.emp_name||'*'||p.post_name||'*'||d.designation||'*'||dm.dep_name||'*'||b.branch_name||'*'||e.join_dt||'*'||case when e.emp_type=1 then 'REGULAR' else 'OUTSOURCE' end from post_mst p,designation_master d,department_mst dm,branch b,employee_master e where e.post_id=p.post_id and e.department_id=dm.dep_id and d.designation_id=e.designation_id and e.branch_id=b.branch_id and emp_code=" & str(1) & ""
                End If

                 dt = oh.ExecuteDataSet(sql).Tables(0)
                If dt.Rows.Count = 0 Then
                    st.Append("4")
                Else
                    st.Append(dt.Rows(0)(0))
                    st.Append("@")
                    sql = "select -1 as comp_id,'Compansatory_date-Name-State_Name-Expiry_Date' from dual union all select distinct cm.comp_id,TO_CHAR(cd.comp_date, 'DD/MON/YYYY')||'*'||cm.comp_name||'*'||sm.state_name||'*'||TO_CHAR(cd.exp_date, 'DD/MON/YYYY')  from hrm_comp_eligible ce,hrm_comp_dtl cd,hrm_comp_mst cm,state_master sm where cd.comp_id=ce.comp_id and cd.comp_date<=to_date(sysdate) and cd.exp_date>= to_date(sysdate) and sm.state_id=ce.state_id and cm.comp_id=ce.comp_id and ce.status=0 and cd.emp_code=ce.emp_code and ce.emp_code=" & str(1) & ""
                    dt = oh.ExecuteDataSet(sql).Tables(0)
                    If dt.Rows.Count = 1 Then
                        st.Append("5")
                    Else
                        For Each dr In dt.Rows
                            st.Append(dr(0))
                            st.Append("$")
                            st.Append(dr(1))
                            st.Append("!")
                        Next
                    End If
                End If
                res = st.ToString()
            End If


            If x = 2 Then
                Dim str1() As String
                str1 = str(1).Split("#")
                sql = "select count(*) from hrm_comp_appl t where t.emp_code=" & str1(0) & " and to_date(t.leave_dt)=to_date('" & str1(1) & "') and t.status_id  in (0,1,4)"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                st.Append("22@")
                If dt.Rows(0)(0) = 0 Then
                    Dim leave(6) As OracleParameter
                    leave(0) = New OracleParameter("em_code", OracleType.Number)
                    leave(0).Direction = ParameterDirection.Input
                    leave(0).Value = str1(0)
                    leave(1) = New OracleParameter("go_dt", OracleType.VarChar, 100)
                    leave(1).Direction = ParameterDirection.Input
                    leave(1).Value = str1(1)
                    leave(2) = New OracleParameter("co_id", OracleType.Number, 5)
                    leave(2).Direction = ParameterDirection.Input
                    leave(2).Value = str1(2)
                    leave(3) = New OracleParameter("go_reason", OracleType.VarChar, 100)
                    leave(3).Direction = ParameterDirection.Input
                    leave(3).Value = str1(3)
                    leave(4) = New OracleParameter("email", OracleType.VarChar, 300)
                    leave(4).Direction = ParameterDirection.Input
                    leave(4).Value = str1(4)
                    leave(5) = New OracleParameter("msg", OracleType.VarChar, 100)
                    leave(5).Direction = ParameterDirection.InputOutput
                    leave(6) = New OracleParameter("flag", OracleType.Number)
                    leave(6).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("hrm_compensatory_apply", leave)
                    st1 = leave(6).Value & "@" & leave(5).Value
                    st.Append(st1)
                    res = st.ToString
                Else
                    st.Append("4")
                    res = st.ToString
                End If
            End If
        Catch ex As Exception
            st.Append(ex.Message)
            res = st.ToString
        End Try
    End Sub

End Class
