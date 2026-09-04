Imports system.data
Imports System.Data.OracleClient

Partial Class MusterCover_page_49d12edd3384
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper
    'krishnadas
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("access_id") = 33 Then

                Me.Label1.Text = Session("firm_name")
                Me.Label2.Text = Session("branch_name")
                Me.Label3.Text = oh.ExecuteDataSet("select to_char(to_date(sysdate),'YYYY') from dual").Tables(0).Rows(0)(0)
            Else
                Response.Redirect("../../show_err.aspx")
            End If
        End If
    End Sub
End Class
