Imports System.Data
Imports System.Data.OracleClient
Partial Class Application_select_219125167630
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "APPLICATION FORM"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.subtitle = "APPLICATION FORM"
        If Session("access_id") = 33 Then
            If Not IsPostBack Then
                str = "select appln_no||'   '||appln_name,appln_no from appln_pers_dtl where appln_no in (select appln_no from appln_interview_dtl where emp_code is null)order by appln_no"
                dt = oh.ExecuteDataSet(str).Tables(0)
                DropDownCandidate.DataSource = dt
                DropDownCandidate.DataTextField = dt.Columns(0).ColumnName
                DropDownCandidate.DataValueField = dt.Columns(1).ColumnName
                DropDownCandidate.DataBind()
            End If
        Else
            Response.Redirect("../../show_err.aspx")
        End If
    End Sub

    Protected Sub BtnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Server.Transfer("ApplicnReport.aspx?appln_no=" & DropDownCandidate.SelectedValue)

    End Sub

    Protected Sub DropDownCandidate_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

End Class
