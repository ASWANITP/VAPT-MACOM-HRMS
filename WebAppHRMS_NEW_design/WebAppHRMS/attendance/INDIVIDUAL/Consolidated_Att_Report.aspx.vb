Imports System.Data
Imports System.Data.OracleClient
Partial Class Consolidated_Att_Report_1fe278951305
    Inherits System.Web.UI.Page
    Dim cat, type, id1 As Integer
    Dim sql As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack() Then
            Me.Txt_fdate.Text = Format(CDate(Date.Today), "dd/MMM/yyyy")
            Me.Txt_tdate.Text = Format(CDate(Date.Today), "dd/MMM/yyyy")
        End If

        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")

        dt = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=1810 and s.emp_id=" & sf(0) & "").Tables(0)
        If (dt.Rows(0)(0) = 0) Then
            Server.Transfer("../../show_err.aspx")
        End If

    End Sub



    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If Me.Txt_fdate.Text = "" Or Me.Txt_tdate.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select Date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            If CDate(Me.Txt_fdate.Text) > CDate(Me.Txt_tdate.Text) Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('To Date Not Valid');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                If CDate(Me.Txt_fdate.Text) > CDate(Date.Now) Or CDate(Me.Txt_tdate.Text) > CDate(Date.Now) Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('Future Date Not Allowed');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Else
                    cat = Me.CMB_CAT.SelectedValue
                    Server.Transfer("ConsolidatedReport.aspx?fdate=" & Me.Txt_fdate.Text & "&tdate=" & Me.Txt_tdate.Text & "&category=" & cat)
                End If
            End If
        End If
    End Sub

    Protected Sub cmb_branch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub


End Class
