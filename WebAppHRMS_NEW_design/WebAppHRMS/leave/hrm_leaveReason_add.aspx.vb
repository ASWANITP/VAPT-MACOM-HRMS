Imports System.Data
Imports System.Data.OracleClient

Partial Class Leave_Reason_Add_hrm_leaveReason_add_53e492664793
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=174 and emp_id=" & UserCode).Tables(0).Rows(0)(0)
        If acce > 0 Then
            CType(Me.Master, WebAppHRMS.edp).Subtitle = "Add Leave Reason/Category"

            Dim script_val As String
            script_val = "var header;" & "header='" & Me.txtAdd.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
            Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)


            If Not IsPostBack Then

                dt = oh.ExecuteDataSet("select -1 as catid, '-----Select-----' as cat from dual union all select c.category_id,c. category_name from hrm_category_master c where c.status_id=1").Tables(0)
                Me.ddlCat.DataSource = dt
                Me.ddlCat.DataValueField = dt.Columns(0).ColumnName
                Me.ddlCat.DataTextField = dt.Columns(1).ColumnName
                Me.ddlCat.DataBind()
                Me.ddlCat.Focus()

            End If
        Else
            Me.Server.Transfer("../show_err.aspx")
        End If

    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim x = str(0)
        Select Case (x)

            Case "1" 'District

                dt = oh.ExecuteDataSet("select -1 as resid,'-----Select-----' as res from dual union all select t.reason_id, t.reason_name from hrm_category_dtl t where t.category_id= " & str(1) & " order by resid").Tables(0)
                res = FillData(res, dt)
                res = res + "@"
        End Select


    End Sub
    Public Function FillData(ByVal cbResult As String, ByVal DT As DataTable) As String
        For n As Integer = 0 To DT.Rows.Count - 1
            cbResult += DT.Rows(n)(0).ToString
            cbResult += "$"
            cbResult += DT.Rows(n)(1).ToString
            If n < DT.Rows.Count - 1 Then
                cbResult += "*"
            End If
        Next
        Return cbResult
    End Function

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim stat As Integer

        If Me.rdCat.Checked = True Then
            stat = 1
            Me.hdnRea.Value = 0
            Me.hdnCat.Value = 0
        Else
            stat = 2
            Me.hdnRea.Value = 0
        End If

        Try
            Dim p(4) As OracleParameter

            p(0) = New OracleParameter("Cat", OracleType.Number, 3)
            p(0).Value = Me.hdnCat.Value

            p(1) = New OracleParameter("Rea", OracleType.Number, 3)
            p(1).Value = Me.hdnRea.Value

            p(2) = New OracleParameter("AddItem", OracleType.VarChar, 80)
            p(2).Value = Me.txtAdd.Text

            p(3) = New OracleParameter("Sta", OracleType.Number, 2)
            p(3).Value = stat

            p(4) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
            p(4).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_Leave_CatRea_Proc", p)
            str_tkn.Append("         alert('" & p(4).Value & "');")
            str_tkn.Append(" window.open('hrm_leaveReason_add.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        Catch ex As Exception
        End Try
    End Sub
End Class
