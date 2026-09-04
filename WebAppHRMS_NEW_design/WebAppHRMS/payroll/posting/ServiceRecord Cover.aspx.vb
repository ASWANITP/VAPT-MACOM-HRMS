Imports System.Data
Imports System.Data.OracleClient

Partial Class ServiceRecord_Cover_9ca1569b4877
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt3 As New DataTable
    Dim branch As String



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.firm.Text = Session("firm_name")
        Me.branch_lbl.Text = Session("branch_name")
        branch = Me.Session("branch_id").ToString.Split("!")(0)
        '-----mafarm
        Dim str As String
        str = ("select d.district_name from branch_master t join district_master d on d.district_id=t.district_id where t.branch_id=" & branch & "")
        dt = oh.ExecuteDataSet(str).Tables(0)
        If dt.Rows.Count > 0 Then
            Me.District.Text = dt.Rows(0)(0)
        Else
            Me.District.Text = ""
        End If
    End Sub
End Class
