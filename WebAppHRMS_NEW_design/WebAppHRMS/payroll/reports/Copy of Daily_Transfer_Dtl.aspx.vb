Imports System.Data
Imports System.Data.OracleClient
Partial Class HRM_Daily_Report_Daily_Transfer_Dtl_fa872b084523
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dtta As String = txt_frm.Text
        Dim dtt1 As String = txt_to.Text
        Me.Server.Transfer("Transfer_rpt.aspx?&fdt=" & dtta & "&tdt=" & dtt1 & "")
    End Sub
End Class
