Imports System.Data
Imports System.Data.OracleClient
Partial Class Payroll_Report_WFHome_081da55b2205
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim str As String
    Dim fir As Integer



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        fir = Session("firm_id")
        Dim userid As String = Session("user_id").Split("!")(0)
        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Txt_From.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)

        If Not IsPostBack Then
            dt1 = oh.ExecuteDataSet("select m.emp_code from employee_master m where m.firm_id=" & fir & " and m.firm_id in (8) and m.emp_code= " & userid & "").Tables(0)
            If Session("access_id") = 33 And dt1.Rows.Count > 0 Then
                CType(Me.Master, WebAppHRMS.edp).Subtitle = "View Work From Home details of selected Employee"
            Else
                Response.Redirect("../show_err.aspx")
            End If
        End If
    End Sub


    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click

        If (Me.Cmb_type.SelectedIndex = -1) Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select Any CheckBox');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        ElseIf CDate(Me.Txt_From.Text) > CDate(Me.Txt_to.Text) Or CDate(Me.Txt_to.Text) > Date.Now Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Invalid Date Selected');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            Me.Server.Transfer("view_wfh_rpt.aspx?type=" & Me.Cmb_type.SelectedValue & "&wfhfrom=" & Me.Txt_From.Text & "&wfhto=" & Me.Txt_to.Text)
        End If

    End Sub
End Class
