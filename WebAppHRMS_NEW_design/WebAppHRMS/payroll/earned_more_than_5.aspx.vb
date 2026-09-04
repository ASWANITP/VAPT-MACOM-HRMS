Imports System.Data
Imports System.Data.oracleclient
Partial Class leave_earned_more_than_5_b782aa856264
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim sql As String
    Dim oh As New helper.oracle.OracleHelper
    Dim res As String
    Dim usr() As String
    Dim emp, dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "sub_call_receiver", "context")
            Dim cbscript As String = "function sub_call_server(arg,context) { " & cbref & "; } "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "sub_call_server", cbscript, True)

            Dim script_val As String
            script_val = "var loanno;" & "loanno='" & "" & Me.Label1.ClientID & "'" & " ; "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

            usr = Me.Session("user_id").ToString.Split("!")
            If Not IsPostBack Then
                Dim Sql2 = "select t.access_id from employee_master t where t.emp_code=" & usr(0) & ""
                dt = oh.ExecuteDataSet(Sql2).Tables(0)
                If dt.Rows(0)(0) <> 33 Then
                    Server.Transfer("../show_err.aspx")
                End If
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
        Dim dr As DataRow
        Dim x = str(0)
        Try
            If x = 1 Then
                st.Append("11")
                st.Append("@")
                sql = "select t.emp_code||'*'||e.emp_name||'*'||t.leave_days||'*'||0 from employ_leave_master t,employee_master e where e.emp_code=t.emp_code and t.leave_days>17 and t.leave_id=3 order by t.emp_code"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                If dt.Rows.Count = 0 Then
                    st.Append("4")
                Else
                    For Each dr In dt.Rows
                        st.Append(dr(0))
                        st.Append("!")
                    Next
                End If
                res = st.ToString()
            End If
            If x = 2 Then

                st.Append("22@")

                Dim leave(2) As OracleParameter
                leave(0) = New OracleParameter("str_details", OracleType.VarChar)
                leave(0).Direction = ParameterDirection.Input
                leave(0).Value = str(1)
                leave(1) = New OracleParameter("err_stat", OracleType.Number)
                leave(1).Direction = ParameterDirection.InputOutput
                leave(2) = New OracleParameter("err_msg", OracleType.VarChar, 100)
                leave(2).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("hrm_earned_leave_more5", leave)
                st.Append(leave(1).Value)
                st.Append("@")
                st.Append(leave(2).Value)
                res = st.ToString
          
            End If


        Catch ex As Exception
     
        End Try
               
    End Sub
End Class
