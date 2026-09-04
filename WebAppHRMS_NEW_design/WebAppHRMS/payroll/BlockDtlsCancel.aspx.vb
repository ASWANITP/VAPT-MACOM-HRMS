Imports System.Data
Imports System.Data.OracleClient
Partial Class BlockALert_BlockDtlsCancel_bb6b615b8375
    Inherits System.Web.UI.Page
    Implements ICallbackEventHandler
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim dr As DataRow
    Dim Eligible As Integer
    Dim str, str1, res, UserId, uer() As String
    Dim cl_scriptq As New StringBuilder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            CType(Me.Master, WebAppHRMS.edp).Subtitle = "Details of Punching Blocks of an Employee and Removal"
            '//-=-===-==-=-=-=-=-=-=-=     Common   -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\\
            Dim script_val As String
            script_val = "var loanno;" & "loanno='" & "" & Me.txtEmpCode.ClientID & "'" & " ; "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "sub_call_receiver", "context")
            Dim cbscript As String = "function sub_call_server(arg,context) { " & cbref & "; } "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "sub_call_server", cbscript, True)
            '//-=-=-=-=-==-=-=-=-=-=-=---=--=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\\
            Me.hidUserCode.Value = Me.Session("user_id")
            UserId = Me.Session("user_id")
            uer = UserId.Split("!")
            Eligible = oh.ExecuteDataSet("select count(*) from form_accessibility where emp_id=" & uer(0) & " and form_id=106").Tables(0).Rows(0)(0)
            If Eligible = 0 Then
                Me.Server.Transfer("../show_err.aspx")
            End If
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Try
            Dim Cnt, Cnt1 As Integer
            Dim cal_data = eventArgument
            Dim str(), starr(), sql, MasterBlock As String
            Dim MasterBlkString As String = ""
            str = cal_data.ToString.Split("$")
            Dim x = str(0)

            Dim st As New StringBuilder

            Select Case (x)
                Case "1"
                    Dim dis As Integer = str(1)
                    st.Append("11")
                    st.Append("^")
                    Dim empCnt As Integer = oh.ExecuteDataSet("select count(*) from employee_master em where em.emp_code = " & dis & "").Tables(0).Rows(0)(0)
                    Dim dty As DataTable = oh.ExecuteDataSet("select firm_id from employ_firm where emp_code=" & dis & "").Tables(0)
                    If dty.Rows.Count = 0 Then
                        st.Append("E")
                    Else
                        If dty.Rows(0)(0) <> Session("firm_id") Then
                            st.Append("E")
                        Else
                            If empCnt = 0 Then
                                st.Append("N")
                            Else
                                Dim stnew As String = "select em.emp_name||'*'||b.BRANCH_NAME||'*'||pm.post_name||'*'||case when em.status_id=1 then 'LIVE' when em.status_id=3 then 'RESIGNED' when em.status_id=4 then 'SUSPENDED' when em.status_id=6 then 'LONG LEAVE' when em.status_id=10 then 'MATERNITY LEAVE' when em.status_id=5 and ed.new_empcode is null then 'TERMINATED' when em.status_id=5 and ed.new_empcode is not null then 'REGULARISED' end from employee_master em,employee_master_dtl ed,branch b,post_mst pm where em.emp_code = ed.emp_code and em.branch_id = b.BRANCH_ID and em.post_id = pm.post_id and em.emp_code = " & dis & ""
                                Dim ns As DataTable = oh.ExecuteDataSet(stnew).Tables(0)
                                If ns.Rows.Count > 0 Then
                                    st.Append(ns.Rows(0)(0))
                                    st.Append("@")
                                Else
                                    st.Append("$")
                                    st.Append("@")
                                End If
                            End If
                        End If
                    End If
                Case "2"
                    st.Append("12")
                    st.Append("^")
                    Dim dat() As String = str(1).Split("~")  'dat(0) = empcode,dat(1) = blockDate
                    Dim diff As Integer = oh.ExecuteDataSet("select to_number(to_date(sysdate) - to_date(sysdate)+1) from dual").Tables(0).Rows(0)(0)
                    Dim dty As DataTable = oh.ExecuteDataSet("select firm_id from employ_firm where emp_code=" & dat(0) & "").Tables(0)
                    If dty.Rows.Count = 0 Then
                        st.Append("E")
                    Else
                        If dty.Rows(0)(0) <> Session("firm_id") Then
                            st.Append("E")
                        Else
                            If diff = 0 Then    ' Blockdate = sysdate
                                Cnt = oh.ExecuteDataSet("select count(*) from employee_block_dtl where emp_code = " & dat(0) & " and to_date(block_date) = to_date(sysdate) and block_status = 1").Tables(0).Rows(0)(0)
                                If Cnt = 0 Then
                                    st.Append("N")
                                Else
                                    sql = "select em.emp_code||'*'||em.emp_name||'*'||bm.block_reason from employee_block_dtl eb,employee_master em,block_master_1 bm where eb.emp_code = em.emp_code and eb.block_id = bm.block_id and em.emp_code = " & dat(0) & " and to_date(eb.block_date) = to_date(sysdate) and eb.block_status = 1"
                                    dt = oh.ExecuteDataSet(sql).Tables(0)
                                    If dt.Rows.Count > 0 Then
                                        For Each dr In dt.Rows
                                            st.Append(dr(0))
                                            st.Append("@")
                                        Next
                                    Else
                                        st.Append("$")
                                        st.Append("@")
                                    End If
                                End If
                            Else
                                Cnt1 = oh.ExecuteDataSet("select count(*) from employee_block_dtl where emp_code = " & dat(0) & " and to_date(block_date) = to_date(sysdate) and block_status = 1").Tables(0).Rows(0)(0)
                                'Cnt = oh.ExecuteDataSet("select count(*) from Employee_Main_Block_His a where a.emp_code = " & dat(0) & " and to_date(a.block_date) = to_date('" & dat(1) & "') and a.block_id > 0").Tables(0).Rows(0)(0)
                                If Cnt1 = 0 Then
                                    st.Append("N")
                                Else
                                    If Cnt1 > 0 Then
                                        sql = "select em.emp_code||'*'||em.emp_name||'*'||bm.block_reason||'*'||bm.block_id from employee_block_dtl eb,employee_master em,block_master_1 bm where eb.emp_code = em.emp_code and eb.block_id = bm.block_id and em.emp_code = " & dat(0) & " and to_date(eb.block_date) = to_date(sysdate) and eb.block_status = 1"
                                        dt = oh.ExecuteDataSet(sql).Tables(0)
                                    End If

                                    If MasterBlkString <> "" Then
                                        st.Append(MasterBlkString)
                                    End If
                                    If dt.Rows.Count > 0 Then
                                        For Each dr In dt.Rows
                                            st.Append(dr(0))
                                            st.Append("@")
                                        Next
                                    End If
                                    If dt.Rows.Count = 0 And MasterBlkString = "" Then
                                        st.Append("$")
                                        st.Append("@")
                                    End If
                                End If
                            End If
                        End If
                    End If
            End Select
            res = st.ToString
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub
    Protected Sub cmdConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdConfirm.Click
        Try
            Dim p(5) As OracleParameter

            p(0) = New OracleParameter("EmpCode", OracleType.Number, 6)
            p(0).Value = Me.hidEmpCode.Value
            p(0).Direction = ParameterDirection.Input

            p(1) = New OracleParameter("BlockDate", OracleType.VarChar, 15)
            p(1).Value = Format(Date.Today, "dd/MMM/yyyy")
            p(1).Direction = ParameterDirection.Input

            p(2) = New OracleParameter("BlockID", OracleType.VarChar, 100)
            p(2).Value = Me.hidBlockID.Value
            p(2).Direction = ParameterDirection.Input

            p(3) = New OracleParameter("UserID", OracleType.VarChar, 20)
            p(3).Value = Me.hidUserCode.Value
            p(3).Direction = ParameterDirection.Input

            p(4) = New OracleParameter("OutMsg", OracleType.VarChar, 300)
            p(4).Direction = ParameterDirection.Output

            p(5) = New OracleParameter("Flag", OracleType.Number)
            p(5).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("HRM_PUNCHBLOCMAC", p)

            If p(5).Value > 0 Then
                cl_scriptq.Append(" alert('" & p(4).Value & "');")
                cl_scriptq.Append("       window.open('BlockDtlsCancel.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scriptq.ToString, True)
            Else
                cl_scriptq.Append(" alert('" & p(4).Value & "..!!');")
                cl_scriptq.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scriptq.ToString, True)
            End If
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub
End Class
