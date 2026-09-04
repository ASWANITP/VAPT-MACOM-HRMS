Imports System.Data
Imports System.Data.OracleClient
Partial Class audit_staffnorm_audit_norm_cf88f00a9584
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim strResult As New System.Text.StringBuilder
    Dim UserAll(), res, sql, str As String
    Dim UserCode, BranchID, PostID, AreaID, RegionID, ZonalID, DepID, OpHead As Integer
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim dts1 As DataTable = oh.ExecuteDataSet("select query from hrm_report_master where firm_id=99 and query_id=130").Tables(0)
        Dim strd() As String = dts1.Rows(0)(0).ToString.Split("#")
        dt1 = oh.ExecuteDataSet(strd(0).Replace("mycode", UserCode)).Tables(0)
        If dt1.Rows(0)(0) > 0 Then
            If Not IsPostBack = True Then
                dt = oh.ExecuteDataSet(strd(1)).Tables(0)
                Me.drpdwn_region.DataSource = dt
                Me.drpdwn_region.DataValueField = dt.Columns(0).ColumnName
                Me.drpdwn_region.DataTextField = dt.Columns(1).ColumnName
                Me.drpdwn_region.DataBind()
                Me.drpdwn_region.Focus()
            End If
        Else
            Me.Server.Transfer("../../show_err.aspx")
        End If
    End Sub

    Protected Sub btn_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        Me.Server.Transfer("honorshsur_maf.aspx?branch=" & Me.drpdwn_region.SelectedValue & "")
    End Sub

    Protected Sub drpdwn_region_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpdwn_region.SelectedIndexChanged
 
    End Sub
End Class
