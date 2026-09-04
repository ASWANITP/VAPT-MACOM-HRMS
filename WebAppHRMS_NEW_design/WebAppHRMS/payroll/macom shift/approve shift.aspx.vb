Imports System.Data
Imports System.Data.OracleClient
Partial Class feb2009_change_shift_press_4f8ff6be3738
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim str, pass_data, res As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3, dt4, dt5 As New DataTable
    Dim sf() As String
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder
    Dim DesID As Integer
    Dim DepID As Integer
    Dim s As Integer = 1
    Dim fmid As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.Session("user_id") = "" Then
            Dim cl_script1 As New StringBuilder
            cl_script1.Append(" alert('Please Login Again and Retry....!! ');")
            cl_script1.Append("    window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)
            Exit Sub
        End If

        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.lbl_msg.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)

        dt1 = oh.ExecuteDataSet("select '---SELECT---', 0 DEP from dual union all select distinct t.dep_name, T.DEP_ID from department_mst t,hrm_assign_shift h where t.dep_id=h.dep ORDER BY DEP").Tables(0)

        Me.emp_code.DataSource = dt1
        Me.emp_code.DataTextField = dt1.Columns(0).ColumnName
        Me.emp_code.DataValueField = dt1.Columns(1).ColumnName
        Me.emp_code.DataBind()
        Me.emp_code.Attributes.Add("onchange", "fill_table()")

    End Sub

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str() As String
        Dim a As New Integer
        Dim parameter(5) As OracleParameter
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)
        Dim ajil() As String = str(1).Split("*")
        Dim backResult As String = ""
        Try
            Select Case (x)
                Case "1"
                    'dt5 = oh.ExecuteDataSet("select em.emp_code||'~'||em.emp_name||'~'||t.eff_date||'~'||b.in_time||'~'||b.out_time||'~'||b.shift||'~'||b.shift_id||'~'||t.dep from hrm_assign_shift t,employee_master em,time_tab b where em.emp_code=t.emp_code and b.shift_id=t.shift_id and t.dep=" & str(1) & " AND T.STATUS=0 union select em.emp_code || '~' || em.emp_name || '~' || t.eff_dt || '~' || b.in_time || '~' || b.out_time || '~' || b.shift || '~' || b.shift_id || '~' || t.dep_id from hrm_shift_change t, employee_master em, time_tab b where em.emp_code = t.emp_code and b.shift_id = t.shift_id and t.emp_code in(select em.emp_code from employee_master em where em.department_id = " & str(1) & ") and to_date(t.eff_dt)>=to_date(sysdate)").Tables(0)
                    dt5 = oh.ExecuteDataSet("select em.emp_code||'~'||em.emp_name||'~'||t.eff_date||'~'||b.in_time||'~'||b.out_time||'~'||b.shift||'~'||b.shift_id||'~'||t.dep from hrm_assign_shift t,employee_master em,time_tab b where em.emp_code=t.emp_code and b.shift_id=t.shift_id and t.dep=" & str(1) & " AND T.STATUS=0").Tables(0)
                    Dim dr As DataRow
                    For Each dr In dt5.Rows
                        backResult += dr(0)
                        backResult += "@"
                    Next
                    str_tkn.Append(backResult)
                    cbResult = str_tkn.ToString
            End Select
        Catch ex As Exception
            str_tkn.Append("")
            cbResult = str_tkn.ToString
        End Try
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return cbResult
    End Function

    Protected Sub Cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_confirm.Click

        Dim str() As String = Me.Hidden2.Value.ToString.Split("@")
        Dim parameter(5) As OracleParameter
        For i As Integer = 0 To str.Length - 1
            Dim ptr() As String = str(i).ToString.Split("#")
            parameter(0) = New OracleParameter("empid", OracleType.VarChar, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = ptr(0)
            parameter(1) = New OracleParameter("depid", OracleType.VarChar, 150)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = ptr(4)
            sf = Session("user_id").ToString.Split("!")
            parameter(2) = New OracleParameter("user", OracleType.VarChar, 150)
            parameter(2).Direction = ParameterDirection.Input
            parameter(2).Value = sf(0)
            parameter(3) = New OracleParameter("effdt", OracleType.VarChar, 150)
            parameter(3).Direction = ParameterDirection.Input
            parameter(3).Value = Format(CDate(ptr(1)), "dd/MMM/yyyy")
            parameter(4) = New OracleParameter("shift", OracleType.VarChar, 150)
            parameter(4).Direction = ParameterDirection.Input
            parameter(4).Value = ptr(3)
            parameter(5) = New OracleParameter("msg", OracleType.VarChar, 150)
            parameter(5).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("hrm_change_shift", parameter)
            Dim a As String = parameter(5).Value
            If a.StartsWith("SUCESSFULLY") Then
                s = s * 1
            Else
                s = s * 0
            End If
        Next
        If s <> 0 Then
            Dim cl_scrip1 As New StringBuilder
            cl_scrip1.Append("   alert('SUCCESSFULLY APPROVED') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
        Else
            Dim cl_scrip1 As New StringBuilder
            cl_scrip1.Append("   alert('SOME ERROR HAPPEND. PLEASE INFORM IT!!') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
        End If


    End Sub

    Protected Sub rejectbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rejectbtn.Click



        Dim str() As String = Me.Hidden2.Value.ToString.Split("@")
        Dim parameter(5) As OracleParameter
        For i As Integer = 0 To str.Length - 1
            Dim ptr() As String = str(i).ToString.Split("#")
            parameter(0) = New OracleParameter("empid", OracleType.VarChar, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = ptr(0)
            parameter(1) = New OracleParameter("depid", OracleType.VarChar, 150)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = ptr(4)
            sf = Session("user_id").ToString.Split("!")
            parameter(2) = New OracleParameter("user", OracleType.VarChar, 150)
            parameter(2).Direction = ParameterDirection.Input
            parameter(2).Value = sf(0)
            parameter(3) = New OracleParameter("effdt", OracleType.VarChar, 150)
            parameter(3).Direction = ParameterDirection.Input
            parameter(3).Value = Format(CDate(ptr(1)), "dd/MMM/yyyy")
            parameter(4) = New OracleParameter("shift", OracleType.VarChar, 150)
            parameter(4).Direction = ParameterDirection.Input
            parameter(4).Value = ptr(3)
            parameter(5) = New OracleParameter("msg", OracleType.VarChar, 150)
            parameter(5).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("hrm_shift_reject", parameter)
            Dim a As String = parameter(5).Value
            If a.StartsWith("SUCESSFULLY") Then
                s = s * 1
            Else
                s = s * 0
            End If
        Next
        If s <> 0 Then
            Dim cl_scrip1 As New StringBuilder
            cl_scrip1.Append("   alert('SUCCESSFULLY REJECTED') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
        Else
            Dim cl_scrip1 As New StringBuilder
            cl_scrip1.Append("   alert('SOME ERROR HAPPEND. PLEASE INFORM IT!!') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
        End If
    End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Response.Redirect("main.aspx")
    'End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Server.Transfer("~/home.aspx")
    End Sub
End Class

