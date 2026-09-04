Imports System.Data
Imports System.Data.OracleClient
Partial Class test_hrm_confirmation_test_hrm_confirm_450a4f9d2771
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim res As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql, sql1, str As String
    Dim dt As New DataTable
    Dim UserAll() As String
    Dim UserCode, ElgCnt As Integer
    Dim cl_script As New StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "HRM Confirmation of Incentives/Allowances"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.subtitle = "HRM Confirmation of Incentives/Allowances"
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.Txt_ItemTotal.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)

        Me.Cmb_Item.Attributes.Add("onchange", "get_final_total()")


        If Session("access_id") = 33 Then
            If Not IsPostBack Then
                '=-=-=-=-
                Me.UserAll = Me.Session("user_id").ToString.Split("!")
                Me.UserCode = Me.UserAll(0)
                Me.ElgCnt = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id = 184 and emp_id = " & Me.UserCode & "").Tables(0).Rows(0)(0)
                If ElgCnt = 0 Then
                    Dim cl_script0 As New System.Text.StringBuilder
                    cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
                    cl_script0.Append("window.open('../home.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

                Else
                    fill()
                End If
            End If
        Else
            Me.Server.Transfer("../show_err.aspx")
        End If

    End Sub
    Sub fill()

        str = "select a.all_id, a.all_name from incentives_allowances_master a,hrm_firm_allowance h where a.all_id=h.all_id and h.status = 0 and h.firm_id=" & Session("firm_id") & " order by a.all_name"
        dt = oh.ExecuteDataSet(str).Tables(0)
        If dt.Rows.Count > 0 Then
            Me.Cmb_Item.DataSource = dt
            Me.Cmb_Item.DataTextField = dt.Columns(1).ColumnName
            Me.Cmb_Item.DataValueField = dt.Columns(0).ColumnName
            Me.Cmb_Item.DataBind()
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('No Incentive to be Confirmed..!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        sql = "select sum(nvl(l.all_amount, 0)) from incentives_allowances_dtl l,employ_firm f where l.emp_code=f.emp_code and  l.all_id =" & eventArgument & " and f.firm_id= " & Session("firm_id") & " and l.branch_id is null and l.pr_date is null"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        res = FormatNumber(dt.Rows(0)(0), 2).ToString
    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        oh.ExecuteNonQuery("update arun.hrm_firm_allowance  a set a.status=1 where a.all_id=" & Me.Cmb_Item.SelectedValue & " and a.firm_id=" & Session("firm_id") & "")
        fill()
    End Sub

    Protected Sub Cmd_Report_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Report.Click
        Me.Server.Transfer("itemwiserpt_for_hrm.aspx?allid=" & Me.Cmb_Item.SelectedValue)
    End Sub
End Class
