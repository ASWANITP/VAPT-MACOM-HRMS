Imports System.Data
Imports System.Data.OracleClient
Partial Class HRM_EmployeeList_Search_8834b9ab4462
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim res, str, sf() As String
    Dim code As Integer = 0
    Dim rdb As Integer = 0
    Dim name As String = ""
    Dim auth As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sf = Session("user_id").ToString.Split("!")
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "Employee Search : Using Employee Code or Name or All"
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txtEmpCode.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
        If Not IsPostBack Then
            'auth = oh.ExecuteDataSet("select count(*) from form_accessibility t where t.form_id=1674 and t.emp_id=" & sf(0) & "").Tables(0).Rows(0)(0)
            'If auth = 0 Then
            '    Dim cl_script0 As New System.Text.StringBuilder
            '    cl_script0.Append("         alert(' You are not authorised');")
            '    cl_script0.Append("       window.open('../home.aspx','_self');")
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
            'End If
            Dim dt As DataTable
            Dim usr = Me.Session("user_id").ToString.Split("!")
            dt = oh.ExecuteDataSet("select t.access_id,t.post_id,t.department_id  from  employee_master t where t.emp_code=" & usr(0) & " ").Tables(0)
            If dt.Rows(0)(0) = 33 Or dt.Rows(0)(0) = 51 Or dt.Rows(0)(2) = 546 Or dt.Rows(0)(1) = 1201 Or dt.Rows(0)(1) = 107 Then

            Else
                Server.Transfer("../Show_err.aspx")
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
        Select Case (x)
            Case "1"
                st.Append("11")
                st.Append("@")
                Dim EmpCount As Integer = oh.ExecuteDataSet("select count(*) from employee_master e,employ_firm f where e.emp_code > 9999 and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.emp_code = " & str(1) & "").Tables(0).Rows(0)(0)
                If EmpCount = 1 Then
                    st.Append("Y")
                Else
                    st.Append("N")
                End If
        End Select
        res = st.ToString()
    End Sub

    Protected Sub cmdConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdConfirm.Click
        rdb = 0
        code = 0
        name = ""
        If Me.checkEmpCode.Checked = True Then
            rdb = 1
            code = Me.txtEmpCode.Text
        ElseIf Me.checkEmpName.Checked = True Then
            rdb = 2
            name = Me.txtEmpName.Text
        Else
            rdb = 3

        End If
        Me.Server.Transfer("Rpt_EmpContactList.aspx?rdb=" & rdb & "&code=" & code & "&name=" & name)
    End Sub
End Class
