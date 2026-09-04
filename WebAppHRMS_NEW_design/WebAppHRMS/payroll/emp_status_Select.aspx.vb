Imports System.IO
Imports System.Data
Imports System.Data.OracleClient
Partial Class Employee_status_emp_status_Select_6650cc1a6925
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim res As String
    Dim oh As New helper.oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Employee Status Report"

        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.cmb_firm.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function  call_server(arg,context) { " & cbref & "; } "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
       
        If Not IsPostBack Then
            Me.Hidden3.Value = 1
            Me.Hidden1.Value = 3
            Me.Hidden2.Value = 0
            fillfirm()
        End If
    End Sub
    Sub fillfirm()
        Dim dt As New DataTable
        dt = oh.ExecuteDataSet("select firm_id, firm_abbr from firm_master where firm_id=" & Session("firm_id") & " order by firm_name").Tables(0)
        Me.cmb_firm.DataSource = dt
        Me.cmb_firm.DataValueField = dt.Columns(0).ColumnName
        Me.cmb_firm.DataTextField = dt.Columns(1).ColumnName
        Me.cmb_firm.DataBind()
    End Sub

  

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim call_data = eventArgument
        Dim st() As String
        Dim str As New StringBuilder
        st = call_data.ToString.Split("*")
        If st(1) = 1 Then
            Dim dt As DataTable = oh.ExecuteDataSet("select firm_id || ' - ' || firm_abbr from firm_master where firm_id=" & Session("firm_id") & " order by firm_name").Tables(0)
            Dim dr As DataRow
            For Each dr In dt.Rows
                str.Append(dr(0))
                str.Append("$")
            Next
        ElseIf st(1) = 2 Then
            Dim dt As DataTable = oh.ExecuteDataSet("select designation_id|| ' - ' ||designation from designation_master order by designation").Tables(0)
            Dim dr As DataRow
            For Each dr In dt.Rows
                str.Append(dr(0))
                str.Append("$")
            Next
        End If
        res = str.ToString
    End Sub
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        '  Me.Server.Transfer("empstatusreport.aspx?firm_desig=" & Me.Hidden1.Value & "&designation=" & Me.Hidden2.Value & "&status=" & Me.Hidden1.Value & "&jointype=" & Me.cmb_joining.SelectedValue & "&emptype=" & Me.cmb_type.SelectedValue & "&date_type=" & Me.cmb_disdt.SelectedValue & "&fromdate=" & Me.txt_fromdt.Text & "&todate=" & Me.txt_todt.Text)
        If Me.Hidden3.Value = 1 Then
            Me.Server.Transfer("emp_app_report.aspx?firm_desig=" & Me.Hidden1.Value & "&designation= " & Me.Hidden2.Value & "&jointype=" & Me.cmb_joining.SelectedValue & "&emptype=" & Me.cmb_type.SelectedValue & "&fromdate=" & Me.txt_fromdt.Text & "&todate=" & Me.txt_todt.Text)

            'ElseIf Me.Hidden1.Value = 3 Then
            '    Me.Server.Transfer("emp_res_report.aspx?firm_desig=" & Me.Hidden1.Value & "&designation= " & Me.Hidden2.Value & "&emptype=" & Me.cmb_type.SelectedValue & "&date_type=" & Me.cmb_disdt.SelectedValue & "&fromdate=" & Me.txt_fromdt.Value & "&todate=" & Me.txt_todt.Value)
            'ElseIf Me.Hidden1.Value = 4 Then
            '    Me.Server.Transfer("emp_susp_report.aspx?firm_desig=" & Me.Hidden1.Value & "&designation= " & Me.Hidden2.Value & "&emptype=" & Me.cmb_type.SelectedValue & "&date_type=" & Me.cmb_disdt.SelectedValue & "&fromdate=" & Me.txt_fromdt.Value & "&todate=" & Me.txt_todt.Value)
            'ElseIf Me.Hidden1.Value = 5 Then
            '    Me.Server.Transfer("emp_ter_report.aspx?firm_desig=" & Me.Hidden1.Value & "&designation= " & Me.Hidden2.Value & "&emptype=" & Me.cmb_type.SelectedValue & "&date_type=" & Me.cmb_disdt.SelectedValue & "&fromdate=" & Me.txt_fromdt.Value & "&todate=" & Me.txt_todt.Value)
        End If

    End Sub
End Class
