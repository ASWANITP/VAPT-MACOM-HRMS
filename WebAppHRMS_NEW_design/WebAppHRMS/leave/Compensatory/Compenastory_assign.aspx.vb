Imports System.Data
Imports System.Data.OracleClient

Partial Class Compenastory_assign_5a9845185764
    Inherits System.Web.UI.Page
    Dim dt1, dt2 As New DataTable
    Dim OH As New Helper.Oracle.OracleHelper
    Dim stat_id, pucn_stat As String

   
    Protected Sub btn_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        Server.Transfer("../../home.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            dt1 = OH.ExecuteDataSet("select 0,'WITH PUNCH' from dual").Tables(0)
            Me.dplPunchStat.DataSource = dt1
            Me.dplPunchStat.DataValueField = dt1.Columns(0).ColumnName
            Me.dplPunchStat.DataTextField = dt1.Columns(1).ColumnName
            Me.dplPunchStat.DataBind()

            dt2 = OH.ExecuteDataSet("select -1,'---SELECT---' from dual union select distinct t.state_id,t.state_name from branch_detail t where t.firm_id='" & Session("firm_id") & "' order by 1").Tables(0)
            Me.dplState.DataSource = dt2
            Me.dplState.DataValueField = dt2.Columns(0).ColumnName
            Me.dplState.DataTextField = dt2.Columns(1).ColumnName
            Me.dplState.DataBind()

        End If



        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.txt_compname.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Me.txt_Compdate.Attributes.Add("onchange", "return checkDt()")


    End Sub

  
   
    'Protected Sub dplState_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dplState.SelectedIndexChanged
    '    stat_id = Me.dplState.SelectedValue.ToString()
    'End Sub

    'Protected Sub dplPunchStat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dplPunchStat.SelectedIndexChanged
    '    pucn_stat = Me.dplPunchStat.SelectedItem.Value
    'End Sub

    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_submit.Click
        Dim mes As String
        Dim uid As Array
        uid = Session("user_id").split("!")
        Dim Parameter(6) As OracleParameter

        Parameter(0) = New OracleParameter("firmids", OracleType.Number, 3)
        Parameter(0).Value = CInt(Session("firm_id"))
        Parameter(0).Direction = ParameterDirection.Input

        Parameter(1) = New OracleParameter("compdt", OracleType.DateTime, 4)
        Parameter(1).Value = Me.txt_Compdate.Text
        Parameter(1).Direction = ParameterDirection.Input

        Parameter(2) = New OracleParameter("punchkg", OracleType.VarChar, 4)
        Parameter(2).Value = Me.dplPunchStat.SelectedItem.Value

        Parameter(2).Direction = ParameterDirection.Input

        Parameter(3) = New OracleParameter("CompensatoryName", OracleType.VarChar, 100)
        Parameter(3).Value = Me.txt_compname.Text
        Parameter(3).Direction = ParameterDirection.Input

        Parameter(4) = New OracleParameter("user", OracleType.Number, 6)
        Parameter(4).Value = CInt(uid(0))
        Parameter(4).Direction = ParameterDirection.Input

        Parameter(5) = New OracleParameter("StateID", OracleType.Number, 3)
        Parameter(5).Value = Me.dplState.SelectedValue.ToString()
        Parameter(5).Direction = ParameterDirection.Input


        Parameter(6) = New OracleParameter("msg", OracleType.VarChar, 300)
        Parameter(6).Direction = ParameterDirection.Output
        OH.ExecuteNonQuery("COMPENSATORY_ADD_HRM", Parameter)
        mes = Parameter(6).Value
        Dim cl_script1 As New System.Text.StringBuilder
        cl_script1.Append("         alert('" & mes & "');")
        cl_script1.Append("         window.open('Compenastory_assign.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

    End Sub
End Class
