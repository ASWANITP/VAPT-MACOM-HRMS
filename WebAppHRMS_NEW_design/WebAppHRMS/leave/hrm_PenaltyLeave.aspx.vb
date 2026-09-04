Imports System.Data
Imports System.Data.OracleClient
Partial Class Compulsary_Leave_hrm_CompulsaryLeave_12b9105a9704
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtBranch.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "Penalty Leave"

        If Not IsPostBack Then
            Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=174 and emp_id=" & UserCode).Tables(0).Rows(0)(0)
            If acce = 0 Then
                Me.Server.Transfer("../show_err.aspx")
            End If
            Me.txtDate.Text = Format(Now.Date, "dd/MMM/yyyy")
        End If

    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return cbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim fid As Integer = Session("firm_id")
        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)
        Select Case (x)
            Case "1"
                dt1 = oh.ExecuteDataSet("select count(*) from emp_master e,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & fid & " and e.emp_code= " & str(1) & "").Tables(0)
                If dt1.Rows(0)(0) = 1 Then
                    dt = oh.ExecuteDataSet("select e.emp_name|| '*' ||b.BRANCH_NAME || '*' || p.post_name || '*' || d.designation from employee_master e,post_mst p,designation_master d,branch_dtl_new b where e.branch_id=b.BRANCH_ID and e.post_id=p.post_id and e.designation_id=d.designation_id and e.status_id =1 and e.emp_code=" & str(1) & "").Tables(0)
                    If dt.Rows.Count = 0 Then
                        str_tkn.Append("NULL")
                    Else
                        str_tkn.Append(dt.Rows(0)(0))
                        cbResult = str_tkn.ToString
                    End If
                Else
                    str_tkn.Append("         alert('Please Select Valid Emp Code Invalid FIRM');")
                    'str_tkn.Append(" window.open('hrm_PenaltyLeave.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
                End If
        End Select
    End Sub
    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim stat As Integer
        Dim mreg As Integer = 0
        Dim ereg As Integer = 0
        Dim lop As Integer = 0
        Try
            Dim p(5) As OracleParameter

            p(0) = New OracleParameter("EmpID", OracleType.Number, 6)
            p(0).Value = Me.txtEcode.Text

            p(1) = New OracleParameter("UserID", OracleType.Number, 6)
            p(1).Value = UserCode

            p(2) = New OracleParameter("Ldate", OracleType.DateTime)
            p(2).Value = CDate(Me.txtDate.Text)

            p(3) = New OracleParameter("days", OracleType.Number, 2)
            p(3).Value = Me.txt_Days.Text

            p(4) = New OracleParameter("remarks", OracleType.VarChar, 75)
            p(4).Value = "PENALTY-LEAVE:" & Me.txt_remarks.Value
            p(5) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
            p(5).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_PenaltyLeave_Proc", p)
            str_tkn.Append("         alert('" & p(5).Value & "');")
            str_tkn.Append(" window.open('hrm_PenaltyLeave.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        Catch ex As Exception
        End Try

    End Sub
End Class
