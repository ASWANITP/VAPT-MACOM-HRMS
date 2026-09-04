Imports System.Data
Imports System.Data.OracleClient

Partial Class Auction_date_87ab45252667
    Inherits System.Web.UI.Page
    Dim dta As Integer
    Dim optn As Integer
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        dta = Me.dplType.SelectedValue
        If dta = 0 Then
            Dim script_val As String
            script_val = "Please Select your Choice To Continue!"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Else
            If Session("firm_id") = 27 Then
                Server.Transfer("Rd_data_mafarm.aspx?adt=" & dta & "")
            Else
                Server.Transfer("Rd_data.aspx?adt=" & dta & "")
            End If
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("access_id") = 33
        If Session("access_id") = 33 Then 
            Dim script_val As String
            script_val = "var loanno;" & "loanno='" & "" & Me.dplType.ClientID & "'" & " ; "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Else
            Me.Server.Transfer("../show_err.aspx")
        End If

    End Sub

    Protected Sub Btn_Exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Exit.Click
        Dim rt1 As New System.Text.StringBuilder
        rt1.Append("nop=0;     window.open('../home.aspx','_self'); ")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script20", rt1.ToString, True)
    End Sub
End Class
