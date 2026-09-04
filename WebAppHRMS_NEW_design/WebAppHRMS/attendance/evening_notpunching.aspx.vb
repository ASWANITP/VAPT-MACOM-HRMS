Imports System.Data
Imports System.Data.OracleClient
Partial Class evening_notpunching_5da2d2287056
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_report.Click
        If Me.txt_date.Text = "" Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Please Enter Date !!!!');")
            'cl_script0.Append("window.open('pl3_rep.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        Else
            If CDate(Me.txt_date.Text) > Date.Now Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('Future Date Not Allowed');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                Me.Server.Transfer("rpt_eveningnotpunching.aspx?fr_dt=" & Me.txt_date.Text)
            End If
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.txt_date.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Me.txt_date.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_date')")
        If Not IsPostBack Then
            dt = OH.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
            Me.hdn_sysdate.Value = Format(dt.Rows(0)(0), "dd/MMM/yyyy")
            Me.txt_date.Text = Me.hdn_sysdate.Value
        End If

    End Sub
End Class
