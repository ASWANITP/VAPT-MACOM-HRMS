Imports System.Data
Imports System.Data.OracleClient
Partial Class employeesearch_location_empsearch_location_ca663f5c1093
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim state As DataTable = oh.ExecuteDataSet("select state_id,state_name from state_master order by state_name").Tables(0)
            Dim district As DataTable = oh.ExecuteDataSet("select district_id,district_name from district_master order by district_name").Tables(0)

            Try

            
                If state.Rows.Count > 0 Then
                    Me.cmb_state.DataSource = state
                    Me.cmb_state.DataTextField = state.Columns(1).ColumnName
                    Me.cmb_state.DataValueField = state.Columns(0).ColumnName
                    Me.cmb_state.DataBind()
                End If

                If district.Rows.Count > 0 Then
                    Me.cmb_district.DataSource = district
                    Me.cmb_district.DataTextField = district.Columns(1).ColumnName
                    Me.cmb_district.DataValueField = district.Columns(0).ColumnName
                    Me.cmb_district.DataBind()
                    postfill()
                End If
            Catch ex As Exception
            Finally
                state.Dispose()
                district.Dispose()
                oh.dispose()
            End Try
        End If
      
    End Sub
    Private Sub postfill()
        Dim post As DataTable = oh.ExecuteDataSet("select sr_number,post_office from post_master where district_id=" & Me.cmb_district.SelectedValue & " order by post_office").Tables(0)
        Try

            If post.Rows.Count > 0 Then
                Me.cmb_post.DataSource = post
                Me.cmb_post.DataTextField = post.Columns(1).ColumnName
                Me.cmb_post.DataValueField = post.Columns(0).ColumnName
                Me.cmb_post.DataBind()
            End If

        Catch ex As Exception
        Finally
            post.Dispose()
            oh.dispose()
        End Try
    End Sub
   
    Protected Sub cmd_report_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_report.Click
        Dim rdb As Integer = 0
        If Me.rdb_state.Checked = True Then
            rdb = 1
        ElseIf Me.rdb_district.Checked = True Then
            rdb = 2
        End If
        If Me.chk_post.Checked = True Then
            rdb = 3
        End If
        Me.Server.Transfer("rpt_empsearch_location.aspx?rdb=" & rdb & "&state=" & Me.cmb_state.SelectedValue & "&district=" & Me.cmb_district.SelectedValue & "&post=" & Me.cmb_post.SelectedValue & "&gender=" & Me.cmb_gender.SelectedValue)

    End Sub

    Protected Sub cmb_district_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_district.SelectedIndexChanged
        postfill()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        oh.dispose()
    End Sub
End Class
