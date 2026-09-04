Imports System.Data
Imports System.Data.OracleClient
Partial Class staffaccount_compensat_cancel_3dafddb82523
    Inherits System.Web.UI.Page

    Implements System.Web.UI.ICallbackEventHandler
    'Dim oh As New helper.oracle.OracleHelper
    Dim oh As New helper.oracle.OracleHelper
    Dim str As String
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '------VAPT - improper parameter validation---------------------------------------
        Dim paramCount As Integer = Request.QueryString.Count
        If Request.QueryString.Count > 0 Then
            Response.StatusCode = 400
            Response.StatusDescription = "Bad Request"
            Response.End()
        End If
        If Not IsPostBack Then
            If Request.QueryString.Get("key") <> 2 Then
                CType(Me.Master, WebAppHRMS.edp).Subtitle = "COMPENSATORY OFF CANCEL"
                Me.hid_key.Value = 1
            ElseIf Request.QueryString.Get("key") = 2 Then
                If Me.Session("access_id") = 33 Then
                    CType(Me.Master, WebAppHRMS.edp).Subtitle = "COMPENSATORY OFF CANCEL BY HRM"
                    Me.hid_key.Value = 2
                Else
                    Me.Server.Transfer("../../show_err.aspx")
                End If
            Else
                Me.Server.Transfer("../../show_err.aspx")
            End If
        End If

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.cmb_com.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
        cmb_com.Attributes.Add("onchange", "compensatoryOnchange()")
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return str
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        str = ""
        Dim s As String() = Session("user_id").ToString.Split("!")
        Dim data() As String = eventArgument.Split("*")
        Select Case CInt(data(0))
            Case 1
                Dim dt As New DataTable
                If data(1) = 1 Then
                    dt = oh.ExecuteDataSet("select '-1','--EMPLOYEE CODE - COMPENSATORY - LEAVE DATE--' from dual union all select distinct al.leave_dt||'*'||al.emp_code||'*'||al.comp_id,al.emp_code||' -'||cm.comp_name||' -'||cd.comp_date from hrm_comp_appl al,hrm_comp_mst cm ,employee_master em,hrm_comp_dtl cd where cd.comp_id=cm.comp_id and (al.status_id=0  or al.status_id in (1,4) and to_date(al.leave_dt)>=to_date(sysdate) ) and al.comp_id=cm.comp_id and al.emp_code=em.emp_code and al.emp_code=" & s(0) & "").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select '-1', '--EMPLOYEE CODE - COMPENSATORY - LEAVE DATE--'  from dual union all select distinct al.leave_dt || '*' || al.emp_code || '*' || al.comp_id,al.emp_code || ' -' || cm.comp_name || ' -' || cd.comp_dt from hrm_comp_appl   al,hrm_comp_mst    cm,hrm_comp_eligible    cd, employee_master em where cd.comp_id = cm.comp_id and em.status_id=1  and al.status_id =1 and cd.emp_code=em.emp_code  and al.comp_id = cm.comp_id  and al.emp_code = em.emp_code").Tables(0)
                End If
                For i As Integer = 0 To dt.Rows.Count - 1
                    str += dt.Rows(i)(0).ToString
                    str += "@"
                    str += dt.Rows(i)(1).ToString
                    If i < dt.Rows.Count - 1 Then
                        str += "%"
                    End If
                Next

            Case 2
                'Dim brid As String() = data(1).ToString.Split("*")
                Dim dt2 As New DataTable
                dt = oh.ExecuteDataSet("select al.emp_code||'#'||em.emp_name||'#'||al.apply_dt||'#'||al.leave_dt||'#'||al.reason from hrm_comp_appl al,employee_master em where al.emp_code=" & data(2) & " and al.leave_dt='" & data(1) & "' and al.emp_code=em.emp_code").Tables(0)
                If dt.Rows.Count > 0 Then
                    str += dt.Rows(0)(0).ToString
                End If

        End Select
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim param(2) As OracleParameter
        Dim str() As String
        str = Me.Session("user_id").ToString.Split("!")

        param(0) = New OracleParameter("cmpdtl", OracleType.VarChar, 800)
        param(0).Direction = ParameterDirection.Input
        param(0).Value = Me.Hidden1.Value & "*" & str(0)

        param(1) = New OracleParameter("key", OracleType.Number, 2)
        param(1).Direction = ParameterDirection.Input
        param(1).Value = Me.hid_key.Value

        param(2) = New OracleParameter("flag", OracleType.Number, 2)
        param(2).Direction = ParameterDirection.Output

        oh.ExecuteNonQuery("hrm_comp_cancel", param)
        Dim status As Integer
        status = param(2).Value
        If status = 1 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Application is Cancelled successfully');")
            cl_script1.Append("         window.open('compensat_cancel.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please try again');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        End If
    End Sub

End Class
