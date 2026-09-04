Imports System.Data
Imports System.Data.OracleClient
Partial Class Tour_Report_Brwise_tour_branchwise_rptselect_afb5dbc09809
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim str As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "Employees Tour Report Branchwise or All in a Given period"
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Tour Report"

        Dim acessid As String
        acessid = acces_chk("tour_branchwise_rptselect")
        If acessid = 1 Then
            Response.Redirect("../show_err.aspx")
        End If


        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Txt_FromDate.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)

        If Not IsPostBack Then
            'str = "select branch_id,branch_name from branch_master union select old_id,branch_name from before_completion where branch_id is null order by branch_name "
            str = "select b.branch_id, b.branch_name  from branch_master b  where b.firm_id=" & Session("firm_id") & "  union  select a.old_id, a.branch_name  from before_completion a  where a.branch_id is null  and a.firm_id=" & Session("firm_id") & "  order by branch_name"
            dt = oh.ExecuteDataSet(str).Tables(0)
            Me.Cmb_Branch.DataSource = dt
            Me.Cmb_Branch.DataValueField = dt.Columns(0).ColumnName
            Me.Cmb_Branch.DataTextField = dt.Columns(1).ColumnName
            Me.Cmb_Branch.DataBind()
        End If

    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        Dim frm As Integer
        frm = Session("firm_id")
        If (frm = 8) Then
            Me.Server.Transfer("tour_report_macom.aspx?branchid=" & 0 & "&fromdate=" & Me.Txt_FromDate.Text & "&todate=" & Me.Txt_ToDate.Text)
            Exit Sub
        End If
        If Me.check_branch.Checked = True Then
            Me.Server.Transfer("tour_branchwise_rpt.aspx?status=" & 0 & "&branchid=" & 0 & "&fromdate=" & Me.Txt_FromDate.Text & "&todate=" & Me.Txt_ToDate.Text)  'All Branches status=0
        ElseIf Me.check_branch.Checked = False Then
            Me.Server.Transfer("tour_branchwise_rpt.aspx?status=" & 1 & "&branchid=" & Me.Cmb_Branch.SelectedValue & "&fromdate=" & Me.Txt_FromDate.Text & "&todate=" & Me.Txt_ToDate.Text)  'individual Branch status=1
        End If
    End Sub
    Function acces_chk(ByVal tp As String)
        Dim tr(2) As OracleParameter
        tr(0) = New OracleParameter("usr_id", OracleType.VarChar, 50)
        tr(0).Direction = ParameterDirection.Input
        tr(0).Value = Me.Session("user_id")
        tr(1) = New OracleParameter("form_nm", OracleType.VarChar, 50)
        tr(1).Direction = ParameterDirection.Input
        tr(1).Value = tp
        tr(2) = New OracleParameter("flag", OracleType.Number, 2)
        tr(2).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("form_acces_chk", tr)
        Dim flg As Integer
        flg = tr(2).Value
        Return flg
    End Function
End Class
