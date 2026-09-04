Imports System.Data.OracleClient
Imports System.Data

Partial Class Staff_Account_Staff_Acc_Dtl_12fe44a33050
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim sql As String
    Dim dt, dt1, dt2, dt3, dt4, dt5, dt6, dt7, dt8, dt9 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str As New System.Text.StringBuilder
    Dim CallBackString As String
    Dim userId, firm As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dep_script As String
        dep_script = " var invoice ;invoice='" & Me.txtcode.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "dep", dep_script, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        firm = CInt(Me.Session("firm_id"))
        userId = CInt(Me.Session("user_id").ToString.Split("!")(0))

        If Not IsPostBack Then
            sql = "select count(*) from form_accessibility where emp_id='" & userId & "' and form_id=503"
            dt9 = oh.ExecuteDataSet(sql).Tables(0)
            If dt9.Rows(0)(0) = 0 Then
                Server.Transfer("../show_err.aspx")
                Exit Sub
            End If
        End If
        Me.txtcode.Attributes.Add("onKeyPress", "return isNumberKey(event)")
        Me.txtcode.Attributes.Add("onblur", "return getDetail()")
        Me.btn_verify.Attributes.Add("onclick", "return btn_verify()")
        Me.btn_confirm.Attributes.Add("onclick", "return btn_confirm()")
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CallBackString
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim DataString() As String = eventArgument.ToString.Split("^")
        Dim emp As String = DataString(1)
        Select Case DataString(0)
            Case 1
                sql = "select count(*) from employee_master a,employ_firm e where a.emp_code =" & emp & "and a.emp_code=e.emp_code and e.firm_id=" & firm
                dt = oh.ExecuteDataSet(sql).Tables(0)
                If dt.Rows(0)(0) = 0 Then
                    str.Append(dt.Rows(0)(0))
                Else
                    sql = "select '00'||count(*) from employee_master a, designation_master c, employee_master_dtl t where a.emp_code =" & emp & "and c.designation_id = a.designation_id and a.status_id = 3 and a.emp_code = t.emp_code and to_date(t.discont_dt) < to_date(sysdate) - 365"
                    dt1 = oh.ExecuteDataSet(sql).Tables(0)
                    If dt1.Rows(0)(0) = 0 Then
                        str.Append(dt1.Rows(0)(0))
                    Else
                        sql = "select '0'||count(*)  from staff_account t where t.firm_id=" & firm & " and t.emp_code=" & emp & ""
                        dt2 = oh.ExecuteDataSet(sql).Tables(0)
                        If dt2.Rows(0)(0) = 0 Then
                            str.Append(dt2.Rows(0)(0))
                        Else
                            sql = "select t.account_no  from staff_account t where t.firm_id=" & firm & " and t.emp_code=" & emp & ""
                            dt3 = oh.ExecuteDataSet(sql).Tables(0)
                            If (dt3.Rows.Count > 0) Then
                                str.Append(dt3.Rows(0)(0))
                                str.Append("�")
                                sql = "select a.emp_name,a.firm_id, c.designation from employee_master a, designation_master c, employee_master_dtl t where a.emp_code =" & emp & " and c.designation_id = a.designation_id and a.status_id = 3 and a.emp_code = t.emp_code and to_date(t.discont_dt) < to_date(sysdate) - 365"
                                dt4 = oh.ExecuteDataSet(sql).Tables(0)
                                If dt4.Rows.Count > 0 Then
                                    str.Append(dt4.Rows(0)(0))
                                    str.Append("�")
                                    str.Append(dt4.Rows(0)(1))
                                    str.Append("�")
                                    str.Append(dt4.Rows(0)(2))
                                    str.Append("�")
                                End If
                            End If
                        End If
                    End If
                End If
            Case 2
                sql = "select t.status_id from subsidary_master t where t.firm_id=1 and t.parent_acc = 36027 And t.account_no = " & DataString(1) & ""
                dt6 = oh.ExecuteDataSet(sql).Tables(0)
                If (dt6.Rows(0)(0) <> 1) Then
                    str.Append("")
                    Exit Sub
                Else
                    sql = "select sum(decode(type, 'C', amount, amount * -1))from sub_all t where t.firm_id = 1 and t.parent_acc = 36027 and t.account_no =" & DataString(1) & ""
                    dt7 = oh.ExecuteDataSet(sql).Tables(0)
                    str.Append(dt7.Rows(0)(0))
                End If
                'End If
            Case 3
                Dim msg As String
                Dim pr(2) As OracleParameter
                pr(0) = New OracleParameter("acc_no", OracleType.Number, 15)
                pr(0).Value = DataString(1).ToString
                pr(1) = New OracleParameter("msg", OracleType.VarChar, 300)
                pr(1).Direction = ParameterDirection.Output
                pr(2) = New OracleParameter("user_id", OracleType.Number, 7)
                pr(2).Value = userId

                oh.ExecuteDataSet("sub_update_status", pr)
                msg = pr(1).Value
                str.Append(msg)
        End Select
        CallBackString = str.ToString
    End Sub

End Class
