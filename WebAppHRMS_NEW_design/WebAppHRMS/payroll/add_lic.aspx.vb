Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_add_lic_4c5ff0d22338
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New helper.oracle.OracleHelper
    Dim sql As String
    Dim dt As New DataTable
    Dim res
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("access_id") <> 33 Then
            Server.Transfer("../show_err.aspx")
        End If
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txt_emp_code.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)
        Select Case (x)
            Case "1"
                st.Append("11")
                st.Append("@")
                sql = "select count(t.emp_code) from hrm_lic_new t where t.emp_code=" & str(1) & ""
                dt = oh.ExecuteDataSet(sql).Tables(0)
                If dt.Rows(0)(0) > 0 Then
                    st.Append("5")
                Else
                    sql = "select emp_name from employee_master where emp_code=" & str(1) & ""
                    dt = oh.ExecuteDataSet(sql).Tables(0)
                    If dt.Rows.Count = 0 Then
                        st.Append("4")
                    Else
                        st.Append(dt.Rows(0)(0))
                    End If
                End If
                res = st.ToString()
        End Select
    End Sub
    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_submit.Click
        Dim usr() As String
        usr = Session("user_id").ToString.Split("!")
        Dim p(5) As OracleParameter
        p(0) = New OracleParameter("emp_code", OracleType.Number, 5)
        p(0).Value = Me.txt_emp_code.Text
        p(1) = New OracleParameter("lic_amt", OracleType.Number, 5)
        p(1).Value = Me.txt_lic_amt.Text
        p(2) = New OracleParameter("remarks", OracleType.VarChar, 1000)
        p(2).Value = Me.txt_remark.Text
        p(3) = New OracleParameter("enter_by", OracleType.Number, 10)
        p(3).Value = usr(0)
        p(4) = New OracleParameter("err_stat", OracleType.Number, 2)
        p(4).Direction = ParameterDirection.Output
        p(5) = New OracleParameter("err_msg", OracleType.VarChar, 1000)
        p(5).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("hrm_add_lic", p)
        If p(4).Value = 1 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & p(5).Value & "');")
            cl_script1.Append("         window.open('../Home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & p(5).Value & "');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If

    End Sub
End Class
