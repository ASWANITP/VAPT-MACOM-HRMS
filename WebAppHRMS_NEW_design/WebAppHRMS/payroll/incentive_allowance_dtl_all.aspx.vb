Imports System.Data
Imports System.Data.OracleClient
Partial Class incentive_allowance_incentive_allowance_dtl_all_eab8d84a5823
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dt As DataTable = oh.ExecuteDataSet("select all_id,all_name from incentives_allowances_master m order by m.all_id").Tables(0)
            Try
                Me.cmb_allname.DataSource = dt
                Me.cmb_allname.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_allname.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_allname.DataBind()
            Catch ex As Exception
                dt.Dispose()
                oh.dispose()
            End Try
        End If
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim allid As Integer = 9999
        If Me.rdb_name.Checked = True Then
            allid = Me.cmb_allname.SelectedValue
        End If

        Me.Response.Redirect("rpt_incentive_allowance_dtl_all.aspx?allid=" & allid)
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        oh.dispose()
    End Sub
End Class
