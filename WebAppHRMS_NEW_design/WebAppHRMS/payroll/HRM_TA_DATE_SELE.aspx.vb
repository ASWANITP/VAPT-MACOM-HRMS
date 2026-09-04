Imports System.Data
Imports System.Data.OracleClient
Partial Class HRM_TA_DATE_SELE_6f0cd14e1724
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim dt1 As New DataTable
    Dim fir As Integer
    Dim firm, use As String
    Dim fmid As Integer
    Dim str, res As String
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("firm_id") = 8 Then
            'Server.Transfer("~/TA/taformat.aspx")
            Response.Redirect("~/TA/taformat.aspx")

        End If
        '--------------10621------jewel Krishnadas
        fir = Session("firm_id")
        firm = Session("firm_name")
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        use = user(0)
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txtLeaveFrom.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        If Not IsPostBack Then
            Dim TodDate As String = oh.ExecuteDataSet("select to_char(to_date(SysDate),'dd/Mon/yyyy') from dual").Tables(0).Rows(0)(0)
            Me.txtLeaveFrom.Text = TodDate
            Me.txtLeaveToDate.Text = TodDate
            Me.hidLeaveFrom.Value = TodDate
            Me.hidLeaveTo.Value = TodDate
        End If
    End Sub
    Protected Sub cmdConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdConfirm.Click
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        Me.Server.Transfer("HRM_TA_STATUS.aspx?fdt=" & Me.txtLeaveFrom.Text & "&tdt=" & Me.txtLeaveToDate.Text)
    End Sub
End Class
