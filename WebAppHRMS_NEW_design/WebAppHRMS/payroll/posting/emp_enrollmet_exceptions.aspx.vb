Imports System.Data
Imports System.Data.oracleclient
Imports System.IO
Partial Class payroll_posting_emp_enrollmet_exceptions_9cbf8cdb7483
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New helper.oracle.OracleHelper
    Dim res As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "EMPLOYEE ENROLLMENT"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.subtitle = "EMPLOYEE ENROLLMENT"
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txt_name.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server(arg,context) { " & cbref & "; } "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)

        If Not IsPostBack Then
            Dim dt1 As DataTable = oh.ExecuteDataSet("select form_id from form_accessibility where form_id=252 and emp_id=" & Me.Session("user_id").ToString.Split("!")(0)).Tables(0)
            If dt1.Rows.Count > 0 Then
                Dim dt As DataTable = oh.ExecuteDataSet("select a.appln_no ,a.appln_no || ' - ' || ap.appln_name from appln_pers_dtl ap, appln_interview_dtl a where ap.appln_no = a.appln_no and a.emp_code is null and (a.verify_status =0 or ap.rejoining = 2) order by a.appln_no").Tables(0)
                Me.cmb_appno.DataSource = dt
                Me.cmb_appno.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_appno.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_appno.DataBind()
            Else
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('You are not Authorised to view this page');")
                cl_script0.Append("       window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
            End If
          
        End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)
        Dim strr As New StringBuilder

        Dim dt As New DataTable
        dt = oh.ExecuteDataSet("select ap.appln_name,ap.perm_add1 || ',' || p1.post_office || ',' || d1.district_name  || ',' ||s1.state_name || ',' ||p1.pin_code ,ap.birth_date,ap.sslc_no,ap.rejoining,p.post_name from appln_pers_dtl ap, post_master p1,appln_interview_dtl a,post_mst p ,district_master d1,state_master s1 where ap.appln_no=a.appln_no and a.appln_no=1086 and a.post_id=p.post_id and ap.perm_pin=p1.sr_number and p1.district_id=d1.district_id and d1.state_id=s1.state_id").Tables(0)
        strr.Append(dt.Rows(0)(0))
        strr.Append("#")
        strr.Append(dt.Rows(0)(1))
        strr.Append("#")
        strr.Append(dt.Rows(0)(2))
        strr.Append("#")
        strr.Append(dt.Rows(0)(3))
        strr.Append("#")
        strr.Append(dt.Rows(0)(4))
        strr.Append("#")
        strr.Append(dt.Rows(0)(5))
        strr.Append("#")
        res = strr.ToString
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim op(1) As OracleParameter
        op(0) = New OracleParameter("appln", OracleType.Number, 10)
        op(0).Value = Me.hid1.Value
        op(0).Direction = ParameterDirection.Input

        op(1) = New OracleParameter("msg", OracleType.Number, 5)
        op(1).Direction = ParameterDirection.Output

        oh.ExecuteNonQuery("hrmapplnexception", op)
        Dim cl_script0 As New System.Text.StringBuilder

        cl_script0.Append("         alert('" & op(1).Value & "');")
        cl_script0.Append("       window.open('emp_enrollmet_exceptions.aspx','_self');")

        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)

    End Sub
End Class
