Imports System.Data
Imports System.Data.OracleClient

Partial Class staff_noms_area_staffnorm_7f3078b02971
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oh As New Helper.Oracle.OracleHelper
            Dim dt As New DataTable
            dt = oh.ExecuteDataSet("select area_id,area_name from area_master order by area_name").Tables(0)
            Me.cmb_area.DataSource = dt
            Me.cmb_area.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_area.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_area.DataBind()

            Dim dt1 As New DataTable
            dt1 = oh.ExecuteDataSet("select state_id,state_name from state_master order by state_name").Tables(0)
            Me.cmb_state.DataSource = dt1
            Me.cmb_state.DataTextField = dt1.Columns(1).ColumnName
            Me.cmb_state.DataValueField = dt1.Columns(0).ColumnName
            Me.cmb_state.DataBind()

            Dim dt2 As New DataTable
            dt2 = oh.ExecuteDataSet("select zonal_id,zonal_name from zonal_master order by zonal_name").Tables(0)
            Me.cmb_zonal.DataSource = dt2
            Me.cmb_zonal.DataTextField = dt2.Columns(1).ColumnName
            Me.cmb_zonal.DataValueField = dt2.Columns(0).ColumnName
            Me.cmb_zonal.DataBind()


            'fill region
            Dim dtr As DataTable = oh.ExecuteDataSet("select reg_id,reg_name from region_master order by reg_name").Tables(0)
            Me.cmb_region.DataSource = dtr
            Me.cmb_region.DataTextField = dtr.Columns(1).ColumnName
            Me.cmb_region.DataValueField = dtr.Columns(0).ColumnName
            Me.cmb_region.DataBind()

            'fill division
            Dim dtd As DataTable = oh.ExecuteDataSet("select division_id,div_name from division_master order by div_name").Tables(0)
            Me.cmb_division.DataSource = dtd
            Me.cmb_division.DataTextField = dtd.Columns(1).ColumnName
            Me.cmb_division.DataValueField = dtd.Columns(0).ColumnName
            Me.cmb_division.DataBind()
        End If

    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        'Dim sql As String = ""
        If Me.rdb_all.Checked = True Then
            Me.Response.Redirect("staffnoms_rpt.aspx?all=" & 1)
        ElseIf Me.rdb_area.Checked = True Then
            Me.Server.Transfer("staffnoms_rpt.aspx?area_id=" & Me.cmb_area.SelectedValue & "&all=" & 2)
        ElseIf Me.rdb_state.Checked = True Then
            Me.Server.Transfer("staffnoms_rpt.aspx?state_id=" & Me.cmb_state.SelectedValue & "&all=" & 3)
        ElseIf Me.rdb_zonal.Checked = True Then
            Me.Server.Transfer("staffnoms_rpt.aspx?zonal_id=" & Me.cmb_zonal.SelectedValue & "&all=" & 4)
        ElseIf Me.rdb_region.Checked = True Then
            Me.Server.Transfer("staffnoms_rpt.aspx?region_id=" & Me.cmb_region.SelectedValue & "&all=" & 5)
        ElseIf Me.rdb_division.Checked = True Then
            Me.Server.Transfer("staffnoms_rpt.aspx?division_id=" & Me.cmb_division.SelectedValue & "&all=" & 6)

        End If
      
    End Sub

    Protected Sub rdb_all_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdb_all.CheckedChanged

    End Sub
End Class
