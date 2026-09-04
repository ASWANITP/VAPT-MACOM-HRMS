Imports System.Data
Imports System.Data.OracleClient

Partial Class test_emp_exp_emp_state_exp_select_0a84e1ea6311
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler

    Dim oh As New Helper.Oracle.OracleHelper
    'dim oh as New heper.oracle.Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim dr As DataRow
    Dim str, str1, str2, str3 As String

    Dim cbresult As String = Nothing
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Statewise Employee Experience Details"

        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.Cmb_State.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        'Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        'Dim cbscript As String = "function call_server (arg,context) {" & cbref & ";}"
        'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
        Me.Cmb_State.Attributes.Add("Onchange", "fill1()")
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "sub_call_receiver", "context")
        Dim cbscript As String = "function sub_call_server(arg,context) { " & cbref & "; } "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "sub_call_server", cbscript, True)


        If Not IsPostBack Then
            str = "select s.state_id,s.state_name as statename from state_master s order by statename"
            dt = oh.ExecuteDataSet(str).Tables(0)
            Me.Cmb_State.DataSource = dt
            Me.Cmb_State.DataTextField = dt.Columns(1).ColumnName
            Me.Cmb_State.DataValueField = dt.Columns(0).ColumnName
            Me.Cmb_State.DataBind()

            str2 = "select 9999 as id,'ASSISTANT MANAGER'as designation from dual union select 9998 as id,'JUNIOR OFFICER'as designation from dual union select designation_id as id,designation as designation from designation_master where designation_id not in(33,64,68,69,15,16,13,54,55,14,43) order by designation"
            dt2 = oh.ExecuteDataSet(str2).Tables(0)
            Me.Cmb_Designation.DataSource = dt2
            Me.Cmb_Designation.DataTextField = dt2.Columns(1).ColumnName
            Me.Cmb_Designation.DataValueField = dt2.Columns(0).ColumnName
            Me.Cmb_Designation.DataBind()

            str3 = "select p.post_id,p.post_name from post_mst p order by p.post_name"
            dt3 = oh.ExecuteDataSet(str3).Tables(0)
            Me.Cmb_Post.DataSource = dt3
            Me.Cmb_Post.DataTextField = dt3.Columns(1).ColumnName
            Me.Cmb_Post.DataValueField = dt3.Columns(0).ColumnName
            Me.Cmb_Post.DataBind()

        End If


    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return cbresult
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim dis As Integer = cal_data
        Dim st As New StringBuilder
        Try
            str1 = "select d.district_id,d.district_name from district_master d where d.state_id=" & dis & " order by d.district_name"
            dt1 = oh.ExecuteDataSet(str1).Tables(0)

        Catch ex As Exception
        Finally

        End Try
        
        If dt1.Rows.Count <> 0 Then
            For Each dr In dt1.Rows
                str_tkn.Append("~")
                str_tkn.Append(dr(0))
                str_tkn.Append("!")
                str_tkn.Append(dr(1))
            Next
        End If
        str_tkn.Append("#")

        cbresult = str_tkn.ToString
    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        Me.Server.Transfer("emp_exp_stwise_rpt.aspx?state=" & Me.Hid_State.Value & "&district=" & Me.Hid_District.Value & "&designation=" & Me.Hid_Desig.Value & "&post=" & Me.Hid_Post.Value)
    End Sub
End Class
