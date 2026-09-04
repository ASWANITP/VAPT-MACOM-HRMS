
Imports System.Data
Imports System.Data.OracleClient
Public Class punch_block_remove_approve
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Dim dt, dt2 As New DataTable
    Dim res As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim usr() As String
            usr = Session("user_id").ToString.Split("!")
            sql = "select count(*) from form_accessibility t where form_id=134 and emp_id= '" & usr(0) & "'"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows(0)(0) = 0 Then
                Server.Transfer("../show_err.aspx")
            Else
                sql = "select -1 as emp_code, 'Employee Code-Employee Name-Reason' from dual union select t.emp_code, t.emp_code || '*' || e.emp_name || '*' || t.s_msg from hrm_punching_block_temp t, employee_master e where t.emp_code = e.emp_code and t.status=0"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                Me.cmb_emp.DataSource = dt
                Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_emp.DataBind()
            End If
        End If
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txt_code.ClientID & "'" & " ; "
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
        str = cal_data.ToString.Split("@")
        Dim st As New StringBuilder
        Dim x = str(0)
        Select Case (x)
            Case "1"
                st.Append("11")
                st.Append("@")
                sql = "select emp_name from employee_master where emp_code=" & str(1) & " and status_id=1"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                If dt.Rows.Count = 0 Then
                    st.Append("1")
                Else
                    sql = "select count(*) from hrm_punching_block t where t.emp_code=" & str(1) & ""
                    dt2 = oh.ExecuteDataSet(sql).Tables(0)
                    If dt2.Rows(0)(0) > 0 Then
                        st.Append("2")
                    Else
                        st.Append(dt.Rows(0)(0))
                    End If
                End If
            Case "2"
                st.Append("22")
                st.Append("@")
                Dim p(4) As OracleParameter
                p(0) = New OracleParameter("str", OracleType.VarChar, 10000)
                p(0).Value = str(1)
                p(1) = New OracleParameter("reason", OracleType.VarChar, 100)
                p(1).Value = str(2)
                p(2) = New OracleParameter("userid", OracleType.VarChar, 30)
                p(2).Value = Session("user_id")
                p(3) = New OracleParameter("err_stat", OracleType.Number, 2)
                p(3).Direction = ParameterDirection.Output
                p(4) = New OracleParameter("err_msg", OracleType.VarChar, 1000)
                p(4).Direction = ParameterDirection.Output

                oh.ExecuteNonQuery("punch_blocking_ins", p)
                st.Append(p(3).Value)
                st.Append("@")
                st.Append(p(4).Value)
        End Select
        res = st.ToString()
    End Sub

    Protected Sub btn_reject_Click(sender As Object, e As EventArgs) Handles btn_reject.Click
        Dim UserAll() As String = Me.Session("user_id").ToString.Split("!")
        Dim enterBy As String = UserAll(0)
        Dim p(4) As OracleParameter
        p(0) = New OracleParameter("str", OracleType.VarChar, 10000)
        p(0).Value = Me.hid_details.Value

        p(1) = New OracleParameter("userid", OracleType.VarChar, 30)
        p(1).Value = Session("user_id")

        p(2) = New OracleParameter("err_stat", OracleType.Number, 2)
        p(2).Direction = ParameterDirection.Output

        p(3) = New OracleParameter("err_msg", OracleType.VarChar, 1000)
        p(3).Direction = ParameterDirection.Output

        p(4) = New OracleParameter("fl", OracleType.Number, 5)
        p(4).Value = 3

        'p(5) = New OracleParameter("enterBy", OracleType.Number, 5)
        'p(5).Value = enterBy

        oh.ExecuteNonQuery("PUNCH_BLOCKING_REM_MACOM", p)
        If p(2).Value = 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('" & p(3).Value & "');")
            cl_script0.Append("         window.open('punch_block_remove_approve.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            'cl_script0.Append("         alert('" & p(3).Value & "');")
            cl_script0.Append("        alert('Unblocking Rejected!!');")
            cl_script0.Append("         window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        Dim UserAll() As String = Me.Session("user_id").ToString.Split("!")
        Dim enterBy As String = UserAll(0)
        Dim p(4) As OracleParameter
        p(0) = New OracleParameter("str", OracleType.VarChar, 10000)
        p(0).Value = Me.hid_details.Value

        p(1) = New OracleParameter("userid", OracleType.VarChar, 30)
        p(1).Value = Session("user_id")

        p(2) = New OracleParameter("err_stat", OracleType.Number, 2)
        p(2).Direction = ParameterDirection.Output

        p(3) = New OracleParameter("err_msg", OracleType.VarChar, 1000)
        p(3).Direction = ParameterDirection.Output

        p(4) = New OracleParameter("fl", OracleType.Number, 5)
        p(4).Value = 2

        'p(5) = New OracleParameter("enterBy", OracleType.Number, 5)
        'p(5).Value = enterBy

        oh.ExecuteNonQuery("PUNCH_BLOCKING_REM_MACOM", p)
        If p(2).Value = 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('" & p(3).Value & "');")
            cl_script0.Append("         window.open('punch_block_remove_approve.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            'cl_script0.Append("         alert('" & p(3).Value & "');")
            cl_script0.Append("        alert('Block Removed Successfully');")
            cl_script0.Append("         window.open('punch_block_remove_approve.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        End If
    End Sub
End Class