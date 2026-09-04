Imports System.Data
Imports System.Data.OracleClient
Partial Class EXTRAFORMS_hrm_tour_status_rpt_61a2ec587861
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Me.hid_br.Value = Session("branch_id")
        'Me.CType(Me.Master, WebAppHRMS.edp).Subtitle = "TOUR SANCTION REPORT"
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.hid_br.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Me.txt_fromdt.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_fromdt')")
        Me.txt_todt.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_todt')")
        If Not IsPostBack Then
            Me.txt_empid.Text = User(0)
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fstr() As String = Me.txt_fromdt.Text.Split("/")
        Dim frm_str As String = fstr(1) & "/" & fstr(0) & "/" & fstr(2)
        Dim tstr() As String = Me.txt_todt.Text.Split("/")
        Dim to_str As String = tstr(1) & "/" & tstr(0) & "/" & tstr(2)
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Me.Response.Redirect("hrm_tour_status_rpt1.aspx?fromdt=" & Format(CDate(frm_str), "dd/MMM/yyyy") & "&todt=" & Format(CDate(to_str), "dd/MMM/yyyy") & " &empid=" & Me.txt_empid.Text)
    End Sub
End Class
