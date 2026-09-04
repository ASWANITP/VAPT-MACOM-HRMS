Imports System.Data
Imports System.Data.OracleClient
Partial Class Incetive_AthorisedEmp_Add_hrm_Incentive_authEmpAdd_c7211eda6869
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim UserAll(), res As String
    Dim UserCode, BranchId As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=184 and emp_id=" & UserCode).Tables(0).Rows(0)(0)
        If acce > 0 Then

            CType(Me.Master, WebAppHRMS.edp).Subtitle = "Incentive Authorised Employee Add"

            Dim script_val As String
            script_val = "var header;" & "header='" & Me.txtEcode.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)


            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
            Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)

            If Not IsPostBack Then

                dt = oh.ExecuteDataSet("select -1 as allid ,'-----Select------' as allname from dual union select t.all_id,t.all_name from incentives_allowances_master t where t.all_status=1 order by allname").Tables(0)
                Me.ddlIns.DataSource = dt
                Me.ddlIns.DataValueField = dt.Columns(0).ColumnName
                Me.ddlIns.DataTextField = dt.Columns(1).ColumnName
                Me.ddlIns.DataBind()
                Me.ddlIns.Focus()

            End If
        Else
            Me.Server.Transfer("../show_err.aspx")
        End If

    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

        Dim call_data = eventArgument
        Dim str() As String

        str = call_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)

        Select Case (x)
            Case "1"

                dt1 = oh.ExecuteDataSet("select t.emp_name from employee_master t where t.status_id=1 and t.emp_code=" & str(1) & " ").Tables(0)

                If dt1.Rows.Count = 0 Then
                    str_tkn.Append("")
                    res = str_tkn.ToString
                Else
                    str_tkn.Append(dt1.Rows(0)(0))
                    res = str_tkn.ToString
                End If
        End Select

    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

        Try
            Dim p(2) As OracleParameter

            p(0) = New OracleParameter("Insid", OracleType.Number, 5)
            p(0).Value = Me.hdnIns.Value

            p(1) = New OracleParameter("Empid", OracleType.Number, 6)
            p(1).Value = Me.txtEcode.Text

            p(2) = New OracleParameter("Outmsg", OracleType.VarChar, 500)
            p(2).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_Ins_AutEmpAdd_proc", p)

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & p(2).Value & "');")
            cl_script1.Append(" window.open('hrm_Incentive_authEmpAdd.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        Catch ex As Exception
        End Try
    End Sub
End Class
