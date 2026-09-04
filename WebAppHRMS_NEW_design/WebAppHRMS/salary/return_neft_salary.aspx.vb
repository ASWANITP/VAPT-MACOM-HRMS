Imports System.Data
Imports System.Data.OracleClient
Partial Class Return_Neft_Salary_return_neft_salary_7b2cfa886629
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim sql, sql1, sql2 As String
    Dim retValue As String
    Dim CallBackString As String
    Dim str As New System.Text.StringBuilder
    Dim userId As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dep_script As String
        dep_script = " var invoice ;invoice='" & Me.HidBranch.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "hid", dep_script, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        If Not IsPostBack Then
            userId = Me.Session("user_id").ToString.Split("!")(0)
            sql2 = "select count(*) from form_accessibility where emp_id='" & userId & "' and form_id=500"
            dt1 = oh.ExecuteDataSet(sql2).Tables(0)
            If (dt1.Rows(0)(0) = 0) Then
                Server.Transfer("../show_err.aspx")
                Exit Sub
            Else
                sql1 = "select -1,'---- ---- Branch_Name ---- ----' from dual union all select t.branch_id,t.branch_name from branch_master t order by 2"
                dt1 = oh.ExecuteDataSet(sql1).Tables(0)
                If (dt1.Rows.Count > 1) Then
                    Me.cmbBranch.DataSource = dt1
                    Me.cmbBranch.DataTextField = dt1.Columns(1).ColumnName
                    Me.cmbBranch.DataValueField = dt1.Columns(0).ColumnName
                    Me.cmbBranch.DataBind()
                End If
            End If
        End If
        Me.txtEmpCode.Attributes.Add("onchange", "return getReturnData()")
        Me.txtEmpCode.Attributes.Add("onKeyPress", "return isNumberKey(event)")
        Me.cmbNeftDtl.Attributes.Add("onchange", "return getEmpDtl()")
        Me.btnConfirm.Attributes.Add("onclick", "return btnConfirmOnclick()")
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CallBackString
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim DataString() As String = eventArgument.ToString.Split("^")
        Dim sql As String
        Dim dt As DataTable
        Dim dr As DataRow
        Select Case DataString(0)
            Case 1
                sql = "select -1,'--- EmployeeName ~ Amount ~ Month ~ Year ~ Send Date ---' from dual union all select n.emp_code,e.emp_name||'~'|| m.amount||'~'||t.month_name||'~'||n.year_for||'~'||m.send_date||'~'||n.month_for||'~'||n.enter_dt from hrm_neft_confirmation n, neft_master m, employee_master e, month t where n.emp_code = m.doc_id and n.module_id = m.module_id and n.module_id = 90 and n.firm_id = m.firm_id and m.amount = (n.net_salary + n.ta) and to_date(n.enter_dt) = to_date(m.value_date) and n.emp_code=e.emp_code and n.month_for=t.month_id and n.emp_code = " & CInt(DataString(1)) & " and n.firm_id= " & CInt(Me.Session("firm_id")) & ""
                dt = oh.ExecuteDataSet(sql).Tables(0)
                If dt.Rows.Count > 1 Then
                    For Each dr In dt.Rows
                        str.Append(dr(0))
                        str.Append("�")
                        str.Append(dr(1))
                        str.Append("�")
                    Next
                Else
                    str.Append("!~")
                End If
            Case 2
                Dim arr() As String = DataString(2).Split("~")
                Dim amount As String = arr(1)
                Dim year As String = arr(3)
                Dim month As String = arr(5)
                Dim valueDt As String = arr(6)
                sql = "select e.emp_name, b.branch_name, m.amount, n.enter_dt, n.net_salary, n.ta, n.beneficiary_account, n.beneficiary_branch, n.ifsc_code, m.send_date, e.branch_id from hrm_neft_confirmation n, employee_master e, branch_master b, neft_master m  where n.emp_code = e.emp_code and n.emp_code = m.doc_id and n.module_id = m.module_id and n.module_id = 90 and n.firm_id = m.firm_id and m.amount = (n.net_salary + n.ta) and to_date(n.enter_dt) = to_date(m.value_date) and e.branch_id = b.branch_id and n.emp_code = " & CInt(DataString(1)) & " and (n.net_salary + n.ta) = " & amount & " and n.month_for = " & month & " and n.year_for = " & year & " and to_date(n.enter_dt) = to_date('" & valueDt & "') and n.firm_id=" & CInt(Me.Session("firm_id")) & ""
                dt = oh.ExecuteDataSet(sql).Tables(0)
                If dt.Rows.Count > 0 Then
                    str.Append(dt.Rows(0)(0))
                    str.Append("�")
                    str.Append(dt.Rows(0)(1))
                    str.Append("�")
                    str.Append(dt.Rows(0)(2))
                    str.Append("�")
                    str.Append(Format(dt.Rows(0)(3), "dd/MMM/yyyy"))
                    str.Append("�")
                    str.Append(dt.Rows(0)(4))
                    str.Append("�")
                    str.Append(dt.Rows(0)(5))
                    str.Append("�")
                    str.Append(dt.Rows(0)(6))
                    str.Append("�")
                    str.Append(dt.Rows(0)(7))
                    str.Append("�")
                    str.Append(dt.Rows(0)(8))
                    str.Append("�")
                    str.Append(Format(dt.Rows(0)(9), "dd/MMM/yyyy"))
                    str.Append("�")
                    str.Append(dt.Rows(0)(10))
                Else
                    str.Append("~*")
                End If
            Case 3
                sql = "select count(*) from neft_customer t where t.moduleid=90 and t.cust_id='" & DataString(1) & "'"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                If dt.Rows(0)(0) > 0 Then
                    sql1 = "select count(*) from neft_customer t where t.cust_id='" & DataString(1) & "' and t.moduleid=90 and t.verify_status='T'"
                    dt1 = oh.ExecuteDataSet(sql1).Tables(0)
                    If dt1.Rows(0)(0) = 0 Then
                        str.Append("@@@")
                    End If
                Else
                    str.Append("~@!")
                End If
        End Select
        CallBackString = str.ToString
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim retValue As String
        Dim pr(11) As OracleParameter
        Try
            pr(0) = New OracleParameter("empCode", OracleType.Number, 8)
            pr(0).Value = CInt(Me.txtEmpCode.Text)
            pr(1) = New OracleParameter("branchId", OracleType.Number, 8)
            pr(1).Value = CInt(Me.Session("branch_id"))
            pr(2) = New OracleParameter("firmId", OracleType.Number, 8)
            pr(2).Value = CInt(Me.Session("firm_id"))
            pr(3) = New OracleParameter("recBranch", OracleType.Number, 8)
            If (Me.chkSelBr.Checked = True) Then
                pr(3).Value = CInt(Me.cmbBranch.SelectedValue)
            Else
                pr(3).Value = CInt(Me.HidBranch.Value)
            End If
            pr(4) = New OracleParameter("netSal", OracleType.Number, 20, 2)
            pr(4).Value = Me.HidNetSal.Value
            pr(5) = New OracleParameter("ta", OracleType.Number, 20, 2)
            pr(5).Value = Me.HidTa.Value
            pr(6) = New OracleParameter("paymode", OracleType.Number, 3)
            If (Me.radNeft.Checked = True) Then
                pr(6).Value = 1
            Else
                pr(6).Value = 2
            End If
            pr(7) = New OracleParameter("sendDt", OracleType.DateTime)
            pr(7).Value = CDate(Me.HidSendDt.Value)
            pr(8) = New OracleParameter("valueDt", OracleType.DateTime)
            pr(8).Value = CDate(Me.HidValueDt.Value)
            pr(9) = New OracleParameter("enterBy", OracleType.VarChar, 20)
            pr(9).Value = Me.Session("user_id")
            pr(10) = New OracleParameter("err_msg", OracleType.VarChar, 250)
            pr(10).Direction = ParameterDirection.Output
            pr(11) = New OracleParameter("transId", OracleType.Number, 10)
            pr(11).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("reverse_returned_neft_salary", pr)
            retValue = pr(10).Value

            Dim c1_script As New System.Text.StringBuilder
            c1_script.Append("alert('" & retValue & "');")
            c1_script.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client", c1_script.ToString, True)
            Server.Transfer("../general/voucher1.aspx?tno=" & pr(11).Value & "")
        Catch ex As Exception
            retValue = ex.Message
        End Try
    End Sub
End Class
