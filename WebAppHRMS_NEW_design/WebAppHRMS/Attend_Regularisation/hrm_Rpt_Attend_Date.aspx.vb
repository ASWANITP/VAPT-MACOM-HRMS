Imports System.Data
Imports System.Data.OracleClient
Partial Class Attend_Regularisation_No_Date_check__Attend_Regularisation_hrm_Rpt_Attend_HW_5d62251a4739
    Inherits System.Web.UI.Page
    Dim dt1 As New DataTable
    Dim OH As New Helper.Oracle.OracleHelper
    Dim cas As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.txt_fromdt.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Me.txt_fromdt.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_fromdt')")
        Me.txt_todt.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_todt')")
        cas = CInt(Request.QueryString("case"))
        If Not IsPostBack Then
            dt1 = OH.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
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
        If cas = 1 Then
            Me.Response.Redirect("hrm_Rpt_Ind_Attend_Status.aspx?fromdt=" & Format(CDate(frm_str), "dd/MMM/yyyy") & "&todt=" & Format(CDate(to_str), "dd/MMM/yyyy"))
        ElseIf cas = 2 Then
            Me.Response.Redirect("hrm_Rpt_NotPunch_Status.aspx?fromdt=" & Format(CDate(frm_str), "dd/MMM/yyyy") & "&todt=" & Format(CDate(to_str), "dd/MMM/yyyy"))
        End If
    End Sub
End Class
