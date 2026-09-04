'Option Strict On
'Option Explicit On
Imports System.Data
Imports System.Data.OracleClient
Partial Class report_AgencyWiseTrxn_0357ac432644
    Inherits System.Web.UI.Page
    Dim objHelper As New Helper.Oracle.OracleHelper
    Dim dsOut As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = Session("title")
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "LEAVE SANCTION FORM"
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.Txt_Problem_id.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        'If Not IsPostBack Then
        '    Me.Txt_Problem_id.Text = Format(Now, "dd/MMM/yyyy")
        '    'Me.Txt_DateTo.Text = Format(Now, "dd/MMM/yyyy")
        'End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Butn_Rectify.Click
        Try
            Dim strBuild As New StringBuilder
            Dim DbResult As String = ""
            Dim srt() As String = Me.Txt_Problem_id.Text.Replace(Chr(13), "").Split(Chr(10))
            For n As Integer = 0 To srt.Length - 1
                strBuild.Append(srt(n))
                strBuild.Append(",")
            Next
            'UserID              in               varchar2,
            'problemid           in               varchar2,
            'ErrorMsg            out              varchar2,
            'ErrorStat           out              number
            Dim user() As String = Session("user_id").ToString.Split("!")

            Dim params(3) As OracleParameter
            params(0) = New OracleParameter("UserID", OracleType.VarChar, 10)
            params(0).Value = CStr(user(0))
            params(0).Direction = ParameterDirection.Input

            params(1) = New OracleParameter("problemid", OracleType.VarChar, 10000)
            params(1).Value = strBuild.ToString
            params(1).Direction = ParameterDirection.Input

            params(2) = New OracleParameter("ErrorMsg", OracleType.VarChar, 500)
            params(2).Direction = ParameterDirection.Output

            params(3) = New OracleParameter("ErrorStat", OracleType.Number, 2)
            params(3).Direction = ParameterDirection.Output

            'objHelper.ExecuteNonQuery("problem_rectification_stp", params)
            objHelper.ExecuteNonQuery("hrm_Leave_sanction_Proc_new", params)
            DbResult = params(2).Value.ToString

            If params(3).Value = 0 Then
                lblMessage.Text = DbResult
                Me.Txt_Problem_id.Text = ""
            Else
                lblMessage.Text = DbResult
            End If

            'val = strBuild
        Catch ex As Exception
            lblMessage.Text = ex.Message
        End Try
    End Sub
End Class
