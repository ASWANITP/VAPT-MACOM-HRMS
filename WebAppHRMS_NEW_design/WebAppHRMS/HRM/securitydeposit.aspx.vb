Imports System.Data
Imports System.Data.OracleClient
Partial Class SecurityDep_securitydeposit_7e49a34a1830
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New helper.oracle.OracleHelper
    Dim CallBackString As String
    Dim dt As New DataTable
    Dim fnm, sql, userAll(), usr, sql1 As String
    Dim a, b, c, d, g As String
    Dim EmpCode As Integer
    Dim str As New System.Text.StringBuilder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim script_val As String
        script_val = "var header_txt;header_txt='" & Me.txtempcode.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "header_txt", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)

        Me.cmbemployee.Attributes.Add("onchange", "emponchange()")

        If Not IsPostBack() Then
            a = "select '----Select Employee-----' emp, -1 from dual union all select t.emp_code||'--'||t.emp_name,t.emp_code from employee_master t where t.status_id=1 order by emp"
            dt = oh.ExecuteDataSet(a).Tables(0)
            Me.cmbemployee.DataSource = dt
            Me.cmbemployee.DataValueField = dt.Columns(1).ColumnName
            Me.cmbemployee.DataTextField = dt.Columns(0).ColumnName
            Me.cmbemployee.DataBind()
        End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CallBackString
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim data() As String = eventArgument.ToString.Split("^")
        Dim dr As DataRow
        Select Case data(0)
            Case 1
                Dim EmpCode As Integer = CInt(data(1))
                Dim sql1 As String
                sql1 = "select t.emp_code|| '~' ||t.emp_name|| '~' ||s.rdno|| '~' ||t.join_dt|| '~' ||u.branch_name|| '~' ||v.post_name,t.emp_code from employee_master t,employee_master_dtl s,branch_master u,post_mst v where t.status_id = 1 and t.branch_id=u.branch_id and t.emp_code=s.emp_code and t.post_id=v.post_id and t.emp_code=" & EmpCode & ""
                Dim empdt As New DataTable
                empdt = oh.ExecuteDataSet(sql1).Tables(0)
                If empdt.Rows.Count > 0 Then
                    For Each dr In empdt.Rows
                        str.Append(dr(0))
                        str.Append("^")
                    Next
                    str.Append("0")
                End If
        End Select
        CallBackString = str.ToString
    End Sub

    Protected Sub btnconfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnconfirm.Click
        'empcode in varchar,
        'amount  in number,
        'p_transidno out number,
        'err_stat out number,
        'err_msg out varchar2

        Dim pr(4) As OracleParameter

        Dim message As String

        Try
            pr(0) = New OracleParameter("empcode", OracleType.Number, 4)
            pr(0).Value = CInt(Me.cmbemployee.SelectedValue)

            pr(1) = New OracleParameter("amount", OracleType.Number, 10)
            pr(1).Value = CDbl(Me.txtamount.Text)

            pr(2) = New OracleParameter("p_transidno", OracleType.Number, 10)
            pr(2).Direction = ParameterDirection.Output

            pr(3) = New OracleParameter("err_stat", OracleType.Number, 10)
            pr(3).Direction = ParameterDirection.Output

            pr(4) = New OracleParameter("err_msg", OracleType.VarChar, 300)
            pr(4).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("security_deposit_insert", pr)
            message = pr(4).Value

        Catch ex As Exception
            message = ex.Message
        End Try
        Dim str As New StringBuilder
        str.Append("alert('" & message & "');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ret_v", str.ToString, True)
        Dim cl_script0 As New System.Text.StringBuilder

        If pr(3).Value = 0 And pr(2).Value <> 0 Then
            Server.Transfer("../general/voucher1.aspx?tno=" & pr(2).Value & "")
        End If
    End Sub
End Class
