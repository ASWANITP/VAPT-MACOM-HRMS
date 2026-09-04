Imports System.Data
Imports System.Data.OracleClient
Partial Class HRM_SECURITY_HRM_AllowanceUpdation_9a7f00b32376
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim CbResult As String = Nothing
    Dim str, pass_data, res As String
    Dim dt, dt1, dt2, dt3, dt4, dt5 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str_tkn As New System.Text.StringBuilder
    'Dim KL As clsABC
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.Session("user_id") = "" Then
            Dim cl_script1 As New StringBuilder
            cl_script1.Append(" alert('Please Login Again and Retry....!! ');")
            cl_script1.Append("    window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)
            Exit Sub
        End If
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "EMPLOYEE LEAVE RECOMMEND OR SANCTION"
        Dim User() As String

        User = Session("user_id").ToString.Split("!")
        Dim dt As New DataTable
        If Not IsPostBack Then
            'If Session("access_id") <> 19 Then
            'Server.Transfer("../show_err.aspx")
            'Else
            dt1 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
            Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yyyy")
            Me.txt_date.Text = Me.hdn_sysdate.Value
            'End If
        End If
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txt_amount.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        Me.txt_date.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_date')")
        'Me.txt_amount.Attributes.Add("onkeyup", "Numberonly('txt_amount')")
        Me.chk_add.Attributes.Add("onclick", "chk_add1()")
        Me.chk_del.Attributes.Add("onclick", "chk_del1()")
        Me.btn3.Attributes.Add("onclick", "rejectbutton()")
        Me.btn2.Attributes.Add("onclick", "sancbutton()")
        Me.btn1.Attributes.Add("onclick", "recombutton()")


        'Me.cmb_allowance.Attributes.Add("onchange", "all_select()")
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim Datastr() As String
        Dim allid() As String
        Dim cal_data = eventArgument
        Dim dis() As String = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim st1 As String
        Dim a As New Integer
        Dim tr(5) As OracleParameter
        Datastr = eventArgument.Split("#")
        allid = Datastr(0).Split("%")
        Dim frm As Integer = Session("firm_id")
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Select Case (Datastr(1))

            Case 1
                res = call_proc(2)
                If res = 1 Then
                    dt1 = oh.ExecuteDataSet("select emp_code || '*' || emp_name || '*' || decode(g.leave_id, 1, 'C/L', 2, 'S/L', 3, 'E/L', 4, 'LOP', 5, 'MAT', 6, 'L/L', 'UNK') || '*' || leave_frdate || '*' || leave_todate || '*' || leave_days || '*' || leave_apply_date || '*' || leave_reason || '*' || leave_seq || '*' || null || '*' || null || '*' || null || '*' || leave_todate || '*' || leave_days||'*'||" & User(0) & " from hrm_leave_application g where sanc_code  = " & User(0) & " order by g.emp_code, g.leave_frdate").Tables(0)
                    If dt1.Rows.Count > 0 Then
                        For Each dr In dt1.Rows
                            str_tkn.Append(dr(0))
                            str_tkn.Append("!")
                        Next
                        CbResult = str_tkn.ToString
                    Else
                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert('No Details!!!!');")
                        cl_script0.Append("window.open('../home.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                    End If
                End If
            Case 2
                res = call_proc(1)
                If res = 1 Then
                    'dt2 = oh.ExecuteDataSet("select emp_code||'*'||emp_name, ||'*'||leave_frdate, leave_todate, total_leave_month, leave_id, leave_reason from hrm_leave_application g where sanc_code = " & User(0) & " order by g.emp_code, g.leave_apply_date").Tables(0)
                    dt2 = oh.ExecuteDataSet("select g.emp_code || '*' || g.emp_name || '*' || decode(g.leave_id, 1, 'C/L', 2, 'S/L', 3, 'E/L', 4, 'LOP', 5, 'MAT', 6, 'L/L', 'UNK') || '*' || leave_frdate || '*' || leave_todate || '*' || leave_days || '*' || leave_apply_date || '*' || leave_reason || '*' || leave_seq || '*' || 'ajil' || '*' || null || '*' || null || '*' || leave_todate || '*' || leave_days||'*'||decode(nvl(i.remarks,0),0,'UNINFORMED',1,'')||'*'||" & User(0) & " from hrm_leave_application g left join hrm_employleave_inform i on (i.emp_code=g.emp_code and g.leave_frdate=i.leave_from and g.leave_todate=i.leave_to) where sanc_code = " & User(0) & " order by g.emp_code, g.leave_frdate").Tables(0)
                    If dt2.Rows.Count > 0 Then
                        For Each dr In dt2.Rows
                            str_tkn.Append(dr(0))
                            str_tkn.Append("!")
                        Next
                        CbResult = str_tkn.ToString
                    Else
                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert('No Details!!!!');")
                        cl_script0.Append("window.open('../home.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                    End If
                End If
            Case 3
                For Each elem As String In Datastr(0).Split("^")
                    ' dt3 = oh.ExecuteDataSet("select emp_code || '*' || emp_name || '*' || decode(g.leave_id, 1, 'C/L', 2, 'S/L', 3, 'E/L', 4, 'LOP', 5, 'MAT', 6, 'L/L', 'UNK') || '*' || leave_frdate || '*' || leave_todate || '*' || leave_days || '*' || leave_apply_date || '*' || leave_reason || '*' || leave_seq || '*' || null || '*' || null || '*' || null || '*' || leave_todate || '*' || leave_days from hrm_leave_application g where sanc_code  = " & User(0) & " order by g.emp_code, g.leave_apply_date").Tables(0)
                    tr(0) = New OracleParameter("usr_id", OracleType.VarChar, 50)
                    tr(0).Direction = ParameterDirection.Input
                    tr(0).Value = Me.Session("user_id")
                    tr(1) = New OracleParameter("id", OracleType.Number, 1)
                    tr(1).Direction = ParameterDirection.Input
                    tr(1).Value = 2
                    tr(2) = New OracleParameter("str", OracleType.VarChar, 500)
                    tr(2).Direction = ParameterDirection.Input
                    tr(2).Value = elem

                    tr(3) = New OracleParameter("flag", OracleType.Number, 2)
                    tr(3).Direction = ParameterDirection.Output
                    tr(4) = New OracleParameter("msg", OracleType.VarChar, 500)
                    tr(4).Direction = ParameterDirection.Output
                    tr(5) = New OracleParameter("str1", OracleType.VarChar, 4000)
                    tr(5).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("HRM_LEAVE_SANC_REJ", tr)
                    a = tr(3).Value
                    If a = 1 Then
                        st1 = "SUCCESSFULLY REJECTED"
                        'Dim cl_script1 As New StringBuilder
                        'cl_script1.Append("    window.open('HRM_leave_rec_sanMAC.aspx','_self');")
                    Else
                        st1 = "ERROR OCCURED, PLEASE INFORM IT!!!"
                    End If
                    res = call_proc(1)
                    If res = 1 Then
                        dt2 = oh.ExecuteDataSet("select emp_code || '*' || emp_name || '*' || decode(g.leave_id, 1, 'C/L', 2, 'S/L', 3, 'E/L', 4, 'LOP', 5, 'MAT', 6, 'L/L', 'UNK') || '*' || leave_frdate || '*' || leave_todate || '*' || leave_days || '*' || leave_apply_date || '*' || leave_reason || '*' || leave_seq || '*' || null || '*' || null || '*' || null || '*' || leave_todate || '*' || leave_days from hrm_leave_application g where sanc_code  = " & User(0) & " order by g.emp_code, g.leave_frdate").Tables(0)
                        If dt2.Rows.Count > 0 Then
                            For Each dr In dt2.Rows
                                str_tkn.Append(dr(0))
                                str_tkn.Append("!")
                            Next
                            CbResult = str_tkn.ToString
                        Else
                            Dim cl_script0 As New System.Text.StringBuilder
                            cl_script0.Append("         alert('No Details!!!!');")
                            cl_script0.Append("window.open('../home.aspx','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                        End If
                    End If
                Next

            Case 4
                For Each elem As String In Datastr(0).Split("^")
                    ' dt3 = oh.ExecuteDataSet("select emp_code || '*' || emp_name || '*' || decode(g.leave_id, 1, 'C/L', 2, 'S/L', 3, 'E/L', 4, 'LOP', 5, 'MAT', 6, 'L/L', 'UNK') || '*' || leave_frdate || '*' || leave_todate || '*' || leave_days || '*' || leave_apply_date || '*' || leave_reason || '*' || leave_seq || '*' || null || '*' || null || '*' || null || '*' || leave_todate || '*' || leave_days from hrm_leave_application g where sanc_code  = " & User(0) & " order by g.emp_code, g.leave_apply_date").Tables(0)
                    tr(0) = New OracleParameter("usr_id", OracleType.VarChar, 50)
                    tr(0).Direction = ParameterDirection.Input
                    tr(0).Value = Me.Session("user_id")
                    tr(1) = New OracleParameter("id", OracleType.Number, 1)
                    tr(1).Direction = ParameterDirection.Input
                    tr(1).Value = 1
                    tr(2) = New OracleParameter("str", OracleType.VarChar, 500)
                    tr(2).Direction = ParameterDirection.Input
                    tr(2).Value = elem

                    tr(3) = New OracleParameter("flag", OracleType.Number, 2)
                    tr(3).Direction = ParameterDirection.Output
                    tr(4) = New OracleParameter("msg", OracleType.VarChar, 500)
                    tr(4).Direction = ParameterDirection.Output
                    tr(5) = New OracleParameter("str1", OracleType.VarChar, 4000)
                    tr(5).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("HRM_LEAVE_SANC_REJ", tr)
                    a = tr(3).Value
                    If a = 1 Then
                        st1 = "SUCCESSFULLY SANCTION"
                        'Dim cl_script1 As New StringBuilder
                        'cl_script1.Append("    window.open('HRM_leave_rec_sanMAC.aspx','_self');")
                    Else
                        st1 = "ERROR OCCURED, PLEASE INFORM IT!!!"
                    End If

                    st.Append(st1)
                    CbResult = st.ToString
                Next

            Case 5
                For Each elem As String In Datastr(0).Split("^")
                    ' dt3 = oh.ExecuteDataSet("select emp_code || '*' || emp_name || '*' || decode(g.leave_id, 1, 'C/L', 2, 'S/L', 3, 'E/L', 4, 'LOP', 5, 'MAT', 6, 'L/L', 'UNK') || '*' || leave_frdate || '*' || leave_todate || '*' || leave_days || '*' || leave_apply_date || '*' || leave_reason || '*' || leave_seq || '*' || null || '*' || null || '*' || null || '*' || leave_todate || '*' || leave_days from hrm_leave_application g where sanc_code  = " & User(0) & " order by g.emp_code, g.leave_apply_date").Tables(0)
                    tr(0) = New OracleParameter("usr_id", OracleType.VarChar, 50)
                    tr(0).Direction = ParameterDirection.Input
                    tr(0).Value = Me.Session("user_id")
                    tr(1) = New OracleParameter("id", OracleType.Number, 1)
                    tr(1).Direction = ParameterDirection.Input
                    tr(1).Value = 4
                    tr(2) = New OracleParameter("str", OracleType.VarChar, 500)
                    tr(2).Direction = ParameterDirection.Input
                    tr(2).Value = elem

                    tr(3) = New OracleParameter("flag", OracleType.Number, 2)
                    tr(3).Direction = ParameterDirection.Output
                    tr(4) = New OracleParameter("msg", OracleType.VarChar, 500)
                    tr(4).Direction = ParameterDirection.Output
                    tr(5) = New OracleParameter("str1", OracleType.VarChar, 4000)
                    tr(5).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("HRM_LEAVE_SANC_REJ", tr)
                    a = tr(3).Value
                    If a = 1 Then
                        st1 = "SUCCESSFULLY REJECTED"
                    Else
                        st1 = "ERROR OCCURED, PLEASE INFORM IT!!!"
                    End If

                    st.Append(st1)
                    CbResult = st.ToString
                Next
        End Select
    End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Try
    '        Dim frm As Integer = Session("firm_id")
    '        Dim e_firm = oh.ExecuteDataSet("select f.firm_id from employ_firm f where f.emp_code=" & Me.txt_code.Text & "").Tables(0).Rows(0)(0)
    '        If e_firm = frm Then
    '            Dim op(5) As OracleParameter
    '            op(0) = New OracleParameter("empcode", OracleType.Number, 6)
    '            op(0).Value = Me.txt_code.Text
    '            op(1) = New OracleParameter("empname", OracleType.VarChar, 20)
    '            op(1).Value = Me.txt_amount.Text
    '            op(2) = New OracleParameter("frdt", OracleType.DateTime)
    '            op(2).Value = Me.txt_date.Text
    '            op(3) = New OracleParameter("userid", OracleType.VarChar, 100)
    '            op(3).Value = Session("user_id")
    '            op(4) = New OracleParameter("status", OracleType.Number, 1)
    '            op(4).Value = 1
    '            op(5) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
    '            op(5).Direction = ParameterDirection.Output
    '            oh.ExecuteNonQuery("HRM_ADD_CTCADJUSTMENT", op)
    '            Dim cl_script1 As New System.Text.StringBuilder
    '            cl_script1.Append("         alert('" + op(5).Value + "');")
    '            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
    '        Else
    '            Dim cl_script1 As New System.Text.StringBuilder
    '            cl_script1.Append("         alert('Not A Valid Employee/Other Firm Employee');")
    '            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
    '        End If

    '    Catch ex As Exception
    '        Dim cl_script1 As New System.Text.StringBuilder
    '        cl_script1.Append("         alert('Not A Valid Employee');")
    '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
    ''    End Try
    'End Sub

    'Protected Sub Button2_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.ServerClick
    '    Response.Redirect("../home.aspx")
    'End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Me.Server.Transfer("~/home.aspx")
        Response.Redirect("~/home.aspx")
    End Sub
    Function call_proc(ByVal tp As Integer)

        Dim tr(2) As OracleParameter
        tr(0) = New OracleParameter("usr_id", OracleType.VarChar, 50)
        tr(0).Direction = ParameterDirection.Input
        tr(0).Value = Me.Session("user_id")
        tr(1) = New OracleParameter("tpid", OracleType.Number, 1)
        tr(1).Direction = ParameterDirection.Input
        tr(1).Value = tp
        tr(2) = New OracleParameter("flag", OracleType.Number, 2)
        tr(2).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("hrm_leave_access_author_new", tr)
        Dim flg As Integer
        flg = tr(2).Value
        Return flg
    End Function

    Protected Sub btn1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn1.Click

    End Sub
End Class
