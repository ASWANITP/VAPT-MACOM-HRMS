Imports System.Data
Imports System.Data.OracleClient
Partial Class Video_Recording_Branch_Video_Format_2bf6da0f4754
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim a, SQL As String
    Dim dt, dt1 As New DataTable
    Dim cbResult, sql1 As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim f As Integer = Session("firm_id")
        If f = 24 Then
            Response.Redirect("promotion_with_tfr_frm1_Jwell.aspx")
            Exit Sub
        End If
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.Txt_empcode.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", script_val.ToString, True)
        Me.Cmd_Confirm.Attributes.Add("OnClick", "return Cmd_Click()")
        Me.Txt_empcode.Attributes.Add("OnChange", "return EmpOnchange()")
        '/--- For Call Back ---//
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        '--Krishnadas modifieed for maben 
        If Not IsPostBack Then
            '===============CHECKING FOR POST AND FORM ACCESSIBILITY==================
            Dim user_id() As String = Session("user_id").ToString.Split("!")
            SQL = "select count(t.emp_id) from form_accessibility t where t.form_id=565 and t.emp_id='" & user_id(0) & "'"
            dt = oh.ExecuteDataSet(SQL).Tables(0)
            If dt.Rows(0)(0) = 0 Then
                Dim script_val1 As New StringBuilder
                script_val1.Append("         alert('You Not Authorized To View This Page !!');")
                script_val1.Append("         window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script_val1.ToString, True)
                Exit Sub
            End If
        End If
    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        Dim frm As Integer = Session("firm_id")
        If frm = 2 Then
            Server.Transfer("promotion_with_tfr_frm2_mab.aspx?empcode=" & Me.Txt_empcode.Text)
            Exit Sub
        End If
        Server.Transfer("promotion_with_tfr_frm2.aspx?empcode=" & Me.Txt_empcode.Text)

    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return cbResult
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim f As Integer = Session("firm_id")
        Dim Data() As String = eventArgument.Split(CChar("!"))
        Select Case CInt(Data(0))
            Case 1 '--//-------- Date Onchange ---------//--
                dt1 = oh.ExecuteDataSet("select count(f.EMP_CODE)  from employ_firm f where f.EMP_CODE = '" & Data(1) & "'  and  f.firm_id=" & f & "").Tables(0)
                If dt1.Rows(0)(0) = 1 Then
                    If Session("firm_id") = 24 Then
                        SQL = "select t.EMP_NAME || '~' ||b.dep_name||'~'||a.post_name  from emp_master t, post_mst_jwell a,department_mst b where t.EMP_CODE = '" & Data(1) & "'  and a.post_id = t.POST_ID   and t.DEPARTMENT_ID=b.dep_id   and t.STATUS_ID = 1"
                    Else
                        SQL = "select t.EMP_NAME || '~' ||b.dep_name||'~'||a.post_name  from emp_master t, post_mst a,department_mst b where t.EMP_CODE = '" & Data(1) & "'  and a.post_id = t.POST_ID   and t.DEPARTMENT_ID=b.dep_id   and t.STATUS_ID = 1"
                    End If
                    dt = oh.ExecuteDataSet(SQL).Tables(0)
                    If dt.Rows.Count > 0 Then
                        cbResult = dt.Rows(0)(0).ToString
                    Else
                        cbResult = ""
                    End If
                Else

                    Dim script_val11 As New StringBuilder
                    script_val11.Append("         alert('You Not Authorized To Transfer This CODE.PLz Login to correct FIRM !!');")
                    script_val11.Append("         window.open('../home.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script_val11.ToString, True)
                    Exit Sub
                End If
        End Select
    End Sub
End Class
