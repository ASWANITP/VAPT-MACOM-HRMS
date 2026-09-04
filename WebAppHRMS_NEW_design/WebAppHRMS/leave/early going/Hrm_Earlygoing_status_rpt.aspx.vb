Imports System.Data
Imports System.Data.OracleClient
Partial Class EXTRAFORMS_hrm_tour_status_rpt_a199cc552317
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim cas As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '------ VAPT - proper parameter validation ------------------------
        Dim isValid As Boolean = True
        Dim regex As New System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]+$")

        For Each key As String In Request.QueryString.AllKeys
            Dim value As String = Request.QueryString(key)

            ' If value contains disallowed characters, mark invalid
            If Not regex.IsMatch(value) Then
                isValid = False
                Exit For
            End If
        Next

        If Not isValid Then
            Response.StatusCode = 400
            Response.StatusDescription = "Bad Request - Invalid Characters"
            Response.End()
        End If

        '-------------------------------------------------------------------
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Me.hid_br.Value = Session("branch_id")
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "EARLY GOING STATUS REPORT"
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.hid_br.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Me.txt_fromdt.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_fromdt')")
        Me.txt_todt.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_todt')")
        cas = CInt(Request.QueryString("case"))
        If Not IsPostBack Then
            dt1 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
            Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yyyy")
            Me.txt_fromdt.Text = Me.hdn_sysdate.Value
            Me.txt_todt.Text = Me.hdn_sysdate.Value
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fstr() As String = Me.txt_fromdt.Text.Split("/")
        Dim frm_str As String = fstr(1) & "/" & fstr(0) & "/" & fstr(2)
        Dim tstr() As String = Me.txt_todt.Text.Split("/")
        Dim to_str As String = tstr(1) & "/" & tstr(0) & "/" & tstr(2)
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Session("fromdt") = Format(CDate(frm_str), "dd/MMM/yyyy")
        Session("todt") = Format(CDate(to_str), "dd/MMM/yyyy")

        If cas = 1 Then
            Response.Redirect("Hrm_Earlygoing_status_rpt1.aspx")
        ElseIf cas = 2 Then
            Response.Redirect("Hrm_Earlygoing_status_rpt2.aspx")
        End If
    End Sub
End Class
