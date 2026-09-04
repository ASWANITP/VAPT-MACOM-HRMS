Imports System.Data
Imports System.Data.OracleClient
Partial Class feb2009_change_shift_press_4f8ff6be4197
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
        fmid = Session("firm_id")
        Me.txtEcode.Focus()
        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.lbl_msg.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Me.Cmb_shift.Attributes.Add("onchange", "emp_fill()")
        Me.Txt_effdt.Attributes.Add("onchange", "date_check()")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
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
                    dt2 = oh.ExecuteDataSet("select a.emp_name||'^'||(case when (select department_id from employee_master where emp_code=" & Session("user_id").ToString.Split("!")(0) & ")=a.department_id then 1 else 0 end)||'^'||(select dep_name from department_mst where dep_id=a.department_id) from employee_master a where a.emp_code = " & str(1) & "").Tables(0)
                    str_tkn.Append(dt2.Rows(0)(0))
                    str_tkn.Append("#")
                    cbResult = str_tkn.ToString
                    dt5 = oh.ExecuteDataSet("select '--select--' er,0 s  from dual union all select distinct t.in_time,1 from time_tab t order by er").Tables(0)
                    Dim dr As DataRow
                    For Each dr In dt5.Rows
                        backResult += dr(0) & "~" & dr(1)
                        backResult += "@"
                    Next
                    str_tkn.Append(backResult)
                    cbResult = str_tkn.ToString
                Case "2"
                    If CDate(ajil(2)) <= CDate(Date.Today) Then
                        str_tkn.Append("NOT")
                        cbResult = str_tkn.ToString
                    Else
                        dt2 = oh.ExecuteDataSet("select '--select--' er,0 s  from dual union all select t.out_time,t.shift_id from time_tab t where t.in_time in ('" & ajil(1) & "') order by er").Tables(0)
                        Dim dr As DataRow
                        For Each dr In dt2.Rows
                            backResult += dr(0) & "~" & dr(1)
                            backResult += "@"
                        Next
                        str_tkn.Append(backResult)
                        cbResult = str_tkn.ToString
                    End If
                Case "3"
                    dt2 = oh.ExecuteDataSet("select t.shift ||'/'||t.shift_id from time_tab t where t.in_time in ('" & str(1) & "') and t.out_time in ('" & str(2) & "') and rownum=1 order by t.shift_id").Tables(0)
                    Dim dr As DataRow
                    For Each dr In dt2.Rows
                        backResult += dr(0)
                        backResult += "@"
                    Next
                    dt3 = oh.ExecuteDataSet("select t.department_id from employee_master t where t.emp_code in ('" & str(3) & "')").Tables(0)
                    str_tkn.Append(backResult)
                    str_tkn.Append(dt3.Rows(0)(0))
                    cbResult = str_tkn.ToString
                Case "4"
                    If CDate(ajil(0)) <= CDate(Date.Today) Then
                        str_tkn.Append("NOT")
                        cbResult = str_tkn.ToString
                    ElseIf (IsDBNull(ajil(1)) Or ajil(1) = "") Then
                        str_tkn.Append("CODE")
                        cbResult = str_tkn.ToString
                    Else
                        dt2 = oh.ExecuteDataSet("select a.emp_name||'^'||(case when (select department_id from employee_master where emp_code=" & Session("user_id").ToString.Split("!")(0) & ")=a.department_id then 1 else 0 end)||'^'||(select dep_name from department_mst where dep_id=a.department_id) from employee_master a where a.emp_code = " & ajil(1) & "").Tables(0)
                        str_tkn.Append(dt2.Rows(0)(0))
                        str_tkn.Append("#")
                        cbResult = str_tkn.ToString
                        dt5 = oh.ExecuteDataSet("select '--select--' er,0 s  from dual union all select distinct t.in_time,1 from time_tab t order by er").Tables(0)
                        Dim dr As DataRow
                        For Each dr In dt5.Rows
                            backResult += dr(0) & "~" & dr(1)
                            backResult += "@"
                        Next
                        str_tkn.Append(backResult)
                        cbResult = str_tkn.ToString
                    End If
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
            oh.ExecuteNonQuery("dep_change_shift", parameter)
            Dim a As String = parameter(5).Value
            If a.StartsWith("SUCESSFULLY") Then
                s = s * 1
            Else
                s = s * 0
            End If
        Next
        If s <> 0 Then
            Dim cl_scrip1 As New StringBuilder
            cl_scrip1.Append("   alert('SUCCESSFULLY ADDED TO CHANGE SHIFT') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
        Else
            Dim cl_scrip1 As New StringBuilder
            cl_scrip1.Append("   alert('CHECK WHETHER THERE EXISTS ANY SAME DAY FOR SAME EMPLOYEE!!') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
        End If
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cl_scrip1 As New StringBuilder
        cl_scrip1.Append("   window.open('leave_sele2.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Server.Transfer("~/home.aspx")
    End Sub
End Class

