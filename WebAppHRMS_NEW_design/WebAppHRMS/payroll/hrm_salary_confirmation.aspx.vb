Imports System.Data
Imports System.Data.OracleClient
Partial Class salary_hrm_salary_confirmation_96dc537a5968
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim str_tkn As New System.Text.StringBuilder
    Dim oh As New helper.oracle.OracleHelper
    Dim CbResult As String = Nothing
    Dim dt, dt1, dt4 As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim cs As String = "var cont_name;cont_name='" & Me.cmb_dept.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
            Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
            If Not IsPostBack Then
                If Session("access_id") <> 33 Then
                    Response.Redirect("../show_err.aspx")
                    Exit Sub
                End If
                departmentfill()
            End If
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub
    Private Sub departmentfill()
        Dim dt As DataTable
        'dt = oh.ExecuteDataSet("select distinct d.dep_id, d.dep_name from department_mst d, employee_master e where e.status_id = 1 and e.emp_code > 9999 and e.department_id = d.dep_id and e.branch_id = 0 and e.emp_code in (select emp_id from salari where status = 0 union select emp_code from incentives_allowances_dtl where status = 1) and  not exists (select emp_code from hrm_sd_confirmation where emp_code=e.EMP_CODE) order by d.dep_name").Tables(0)
        dt = oh.ExecuteDataSet("select distinct d.dep_id, d.dep_name from department_mst d, employee_master e,m_wage w where e.status_id = 1 and w.rec_firm = " & Session("firm_id") & "  and e.emp_code > 9999 and e.department_id = d.dep_id and e.emp_code=w.emp_code and (e.branch_id in (0, 1295) or w.rec_firm = 16 or w.rec_firm = 33 or w.rec_firm = 24  or w.rec_firm = 2) and e.emp_code in (select emp_id from salari where status = 0 union select emp_code from incentives_allowances_dtl where status = 1) and not exists (select emp_code from hrm_sd_confirmation where emp_code = e.EMP_CODE) order by d.dep_name").Tables(0)
        Try
            Me.cmb_dept.DataSource = dt
            Me.cmb_dept.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_dept.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_dept.DataBind()
            Me.hid3.Value = dt.Rows(0)(0)
        Catch ex As Exception
        Finally
            dt.Dispose()
            oh.dispose()
        End Try
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        'Dim depid As Integer = eventArgument
        Dim DataStr() As String
        DataStr = eventArgument.Split("#")
        Select Case (DataStr(1))
            Case 1
                Dim Instr() As String = DataStr(0).Split("%")
                Dim CODE As String = Instr(0)
                dt1 = oh.ExecuteDataSet("select h.emp_code,e.emp_name,h.acc_no,h.salary,h.allowance,h.old_code from hrm_bank_confirmation h,employee_master e,m_wage w where  e.emp_code=w.emp_code and w.rec_firm = " & Session("firm_id") & " and h.emp_code=w.emp_code and e.status_id=1 and e.department_id=" & CODE & " and (e.branch_id in (0, 1295) or w.rec_firm = 33 or  w.rec_firm=16 or w.rec_firm=24 or w.rec_firm=2) and h.emp_code not in (select s.emp_code from hrm_sd_confirmation s)and h.acc_no is not null").Tables(0)
                If dt1.Rows.Count > 0 Then
                    Dim dr As DataRow
                    For Each dr In dt1.Rows
                        str_tkn.Append(dr(0))
                        str_tkn.Append("!")
                        str_tkn.Append(dr(1))
                        str_tkn.Append("!")
                        str_tkn.Append(dr(2))
                        str_tkn.Append("!")
                        str_tkn.Append(dr(3))
                        str_tkn.Append("!")
                        str_tkn.Append(dr(4))
                        str_tkn.Append("!")
                        str_tkn.Append(dr(5))
                        str_tkn.Append("~")
                    Next
                    str_tkn.Append("@")
                    str_tkn.Append("2")
                End If
                CbResult = str_tkn.ToString
            Case 2
                Dim Instr() As String = DataStr(0).Split("%")
                Dim SalData As String = Instr(0)
                Dim depid As String = Instr(1)
                Try
                    Dim User() As String
                    User = Session("user_id").ToString.Split("!")
                    Dim p(3) As OracleParameter

                    p(0) = New OracleParameter("str", OracleType.VarChar, 100000000)
                    p(0).Value = SalData

                    p(1) = New OracleParameter("verifyid", OracleType.Number, 5)
                    p(1).Value = User(0)

                    p(2) = New OracleParameter("depid", OracleType.Number, 4)
                    p(2).Value = depid

                    p(3) = New OracleParameter("msg", OracleType.VarChar, 100)
                    p(3).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("hrmbankconfirmation", p)
                    CbResult = p(3).Value
                Catch ex As Exception
                    CbResult = ex.Message
                End Try
        End Select
    End Sub
End Class
