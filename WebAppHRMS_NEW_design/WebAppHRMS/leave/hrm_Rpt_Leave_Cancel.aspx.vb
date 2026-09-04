Imports System.Data
Imports System.Data.OracleClient
Partial Class new_leave_hrm_Rpt_Leave_Cancel_d1b03d506623
    Inherits System.Web.UI.Page
    Dim dt1 As New DataTable
    Dim OH As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.txt_From.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Me.txt_From.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_from')")
        Me.txt_To.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_to')")
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "LEAVE CANCELLATION REPORT"
        If Not IsPostBack Then
            dt1 = OH.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
            Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yyyy")
            Me.txt_From.Text = Me.hdn_sysdate.Value
            Me.txt_To.Text = Me.hdn_sysdate.Value
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fstr() As String = Me.txt_From.Text.Split("/")
        Dim frm_str As String = fstr(1) & "/" & fstr(0) & "/" & fstr(2)
        Dim tstr() As String = Me.txt_To.Text.Split("/")
        Dim to_str As String = tstr(1) & "/" & tstr(0) & "/" & tstr(2)
        Me.Response.Redirect("hrm_Rpt_Leave_Cancel1.aspx?fromdt=" & Format(CDate(frm_str), "dd/MMM/yyyy") & "&todt=" & Format(CDate(to_str), "dd/MMM/yyyy"))
    End Sub
End Class