Imports System.Data
Imports System.Data.OracleClient
Partial Class attendance_punch1_6bd9f8f13625
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim result As String
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cs As String = "var cont_name;cont_name='" & Me.txt_empcd.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        Me.cmd_ok.Attributes.Add("onclick", "return punch_check()")
        Dim clientcb As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "rec_result", "context", True)
        Dim cl_func As String = "function emp_pnch(arg,context) {" & clientcb & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "emp_pnch", cl_func, True)
        Me.lbl_gun.Text = "With out Gun"
        Me.chk_gun.Checked = False
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return result
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim ar As Array
        ar = eventArgument.Split("*")
        Select Case ar(0)
            Case 1
                result = emp_punch(ar(1), ar(2))
                'Case 2
        End Select
    End Sub
    Protected Sub cmd_ok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_ok.Click
      
        Dim pun_str As Array
        Dim i As Int16
        pun_str = Split(Me.hdn_pun.Value, "!")
        Try

            Dim pr(4) As OracleParameter
            pr(0) = New OracleParameter("empcd", OracleType.Number, 5)
            pr(0).Value = CInt(pun_str(1))
            pr(1) = New OracleParameter("brno", OracleType.Number, 4)
            pr(1).Value = CInt(Session("branch_id"))
            pr(2) = New OracleParameter("pun_time", OracleType.VarChar, 10)
            pr(2).Value = pun_str(0)
            pr(3) = New OracleParameter("gun_st", OracleType.Number, 10)
            If Me.chk_gun.Checked = True Then
                pr(3).Value = 1
            Else
                pr(3).Value = 0
            End If
            pr(4) = New OracleParameter("error_st", OracleType.Number)
            pr(4).Direction = ParameterDirection.Output
           
            oh.ExecuteNonQuery("Sec_UpdateDailyAttend", pr)
            Me.lbl_err.ForeColor = Drawing.Color.DarkRed
            If pr(4).Value = 0 Then
                Me.lbl_err.Text = "Successfully Confirmed"
            Else
                Me.lbl_err.Text = "Client System time Change Is Not Permitted"
            End If
        Catch ex As Exception

            Me.lbl_err.Visible = True
            Me.lbl_err.Text = ex.Message
        End Try
        Me.txt_empcd.Value = ""
        Me.txt_ename.Value = ""
        Me.txt_shift.Value = ""
        Me.txt_pswd.Value = ""
    End Sub
 
    Function emp_punch(ByVal empcd, ByVal pswd)
        Dim pnch As String = "select a.emp_code,a.status_id,a.shift_id,a.emp_name,b.shift,b.in_time,b.ncry_time,b.mcry_time,b.early_time,b.out_time,b.ovr_time,a.category,d.m_time,d.e_time,b.start_time from employee_master a,time_tab b,daily_attend d where a.shift_id=b.shift_id and a.shift_id in (4,5) and a.emp_code=d.emp_code and a.emp_code=" & empcd & " and a.password='" & pswd & "'"
        'Dim pnch As New OracleDataAdapter("select a.emp_code,a.status_id,a.shift_id,a.emp_name,b.shift,b.in_time,b.ncry_time,b.mcry_time,b.early_time,b.out_time,b.ovr_time,a.category,d.m_time,d.e_time,a.password,b.start_time from employee_master a,time_tab b,daily_attend d where a.shift_id=b.shift_id  and a.emp_code=d.emp_code and a.emp_code=" & empcd & " and a.password='" & pswd & "' and a.branch_id=d.branch_id and a.firm_id=d.firm_id  and d.firm_id=" & Session("firm_id") & " and d.branch_id=" & Session("branch_id"), Helper.Oracle.connection.con)
        'Dim pnch As New OracleDataAdapter("select a.emp_code,a.status_id,a.shift_id,a.emp_name,b.shift,b.in_time,b.ncry_time,b.mcry_time,b.early_time,b.out_time,b.ovr_time,a.category from employee_master a,time_tab b where a.shift_id=b.shift_id  and  a.emp_code=10188", Helper.Oracle.connection.con)
        Dim dt2 As New DataTable
        dt2 = oh.ExecuteDataSet(pnch).Tables(0)
        Dim dr1 As DataRow
        'Dim st As String
        'st = Request.QueryString("pas")
        Dim pun_str As New System.Text.StringBuilder
        If dt2.Rows.Count > 0 Then
            For Each dr1 In dt2.Rows
                'a.emp_code
                pun_str.Append(dr1(0))
                pun_str.Append("!")
                ',a.status_id
                pun_str.Append(dr1(1))
                pun_str.Append("!")
                'a.shift_id
                pun_str.Append(dr1(2))
                pun_str.Append("!")
                'a.emp_name
                pun_str.Append(dr1(3))
                pun_str.Append("!")
                ',b.shift
                pun_str.Append(dr1(4))
                pun_str.Append("!")
                'b.in_time,
                pun_str.Append(dr1(5))
                pun_str.Append("!")
                'b.ncry_time,
                pun_str.Append(dr1(6))
                pun_str.Append("!")
                'b.mcry_time
                pun_str.Append(dr1(7))
                pun_str.Append("!")
                'b.early_time
                pun_str.Append(dr1(8))
                pun_str.Append("!")
                'b.out_time
                pun_str.Append(dr1(9))
                pun_str.Append("!")
                'b.ovr_time
                pun_str.Append(dr1(10))
                pun_str.Append("!")
                'a.category
                pun_str.Append(dr1(11))
                pun_str.Append("!")
                'd.m_time
                pun_str.Append(dr1(12))
                pun_str.Append("!")
                'd.e_time,
                pun_str.Append(dr1(13))
                pun_str.Append("!")
                'a.password
                'pun_str.Append(dr1(14))
                'pun_str.Append("!")
                'b.start_time
                pun_str.Append(dr1(14))
            Next
            Return pun_str.ToString
        End If
    End Function
    Function emp_tour()
        Dim adp As String = "select emp_code,emp_name,category,shift_id from employee_master where emp_code=" & Request.QueryString("sub") & " "
        Dim d As New Integer
        d = Request.QueryString("sub")
        Dim dt As New DataTable
        dt = oh.ExecuteDataSet(adp).Tables(0)
        Dim dr As DataRow
        Dim emp_off As New System.Text.StringBuilder
        For Each dr In dt.Rows
            emp_off.Append(dr(0))
            emp_off.Append("~")
            emp_off.Append(dr(1))
            emp_off.Append("~")
            emp_off.Append(dr(2))
            emp_off.Append("~")
            emp_off.Append(dr(3))
        Next
        Response.Write(emp_off)
    End Function
End Class
