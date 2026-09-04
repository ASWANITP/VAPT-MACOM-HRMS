Imports System.Data
Imports System.Data.OracleClient
Partial Class AnyTimePunching_New_hrm_Punch_Regular_Form_96f032a99538
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.rdb_Indi.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Me.rdb_All.Attributes.Add("onclick", "ALL_LATE()")
        Me.rdb_Indi.Attributes.Add("onclick", "INDI_LATE()")
        Me.rdb_Nonmarking.Attributes.Add("onclick", "NONMARKING()")
    End Sub
End Class
