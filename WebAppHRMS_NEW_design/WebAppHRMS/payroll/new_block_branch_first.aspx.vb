Imports System.Data
Imports System.Data.OracleClient
Partial Class new_punch_block_rpt_new_block_branch_new_block_branch_a25aa5d92304
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack = True Then
            dt = oh.ExecuteDataSet("select -1 branch_id, '----------SELECT BRANCH----------' branch_name from dual union all select  branch_id, branch_name from branch_master order by branch_id").Tables(0)
            Me.br_drop.DataSource = dt
            Me.br_drop.DataTextField = dt.Columns(1).ColumnName
            Me.br_drop.DataValueField = dt.Columns(0).ColumnName
            Me.br_drop.DataBind()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fdt As String = Me.br_drop.Text
        Dim tdt As String = Me.txt_month.Text
        Server.Transfer("new_block_br_report.aspx?&fdt='" & Me.br_drop.Text & "'&tdt='" & Me.txt_month.Text & "'")
        'Server.Transfer("new_block_br_report.aspx?&fdt='" & Me.br_drop.Text & "'&tdt='" & Me.txt_month.Text& "'")
    End Sub
End Class
