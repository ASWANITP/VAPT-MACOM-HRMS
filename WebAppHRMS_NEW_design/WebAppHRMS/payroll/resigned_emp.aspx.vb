Imports System.Data
Imports System.Data.OracleClient
Partial Class Resigned_Employees_resigned_emp_026f53408777
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt1 As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "SELECT DATE"
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "SELECT DATE"
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.txt_from.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        If Not IsPostBack Then
            dt1 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
            Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yyyy")
            Me.txt_from.Text = Me.hdn_sysdate.Value
            Me.txt_to.Text = Me.hdn_sysdate.Value
        End If
        Me.txt_from.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_from')")
        Me.txt_to.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_to')")

    End Sub
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Me.Server.Transfer("rpt_resigned_emp.aspx?fromdt=" & Me.txt_from.Text & "&todt=" & Me.txt_to.Text)
    End Sub
End Class
