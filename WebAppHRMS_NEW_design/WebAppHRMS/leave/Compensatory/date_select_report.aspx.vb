Imports System.Data
Imports System.Data.OracleClient
Partial Class gold_coin_date_select_report_e12261828014
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '------VAPT - improper parameter validation---------------------------------------
        Dim paramCount As Integer = Request.QueryString.Count
        If Request.QueryString.Count > 0 Then
            Response.StatusCode = 400
            Response.StatusDescription = "Bad Request"
            Response.End()
        End If

        CType(Me.Master, WebAppHRMS.edp).Subtitle = "COMPENSATORY STATUS REPORT"
        If Not IsPostBack Then
            Dim dat As Date

            dat = CDate("1/JAN/" & Now.Date.Year)
            Me.txt_from_dt.Text = Format(dat, "dd/MMM/yyyy")
            Dim usr() As String
            usr = Session("user_id").ToString().Split("!")
            Dim dt As DataTable = oh.ExecuteDataSet("select max(leave_dt) from hrm_comp_appl where emp_code=" & usr(0) & "").Tables(0)
            Me.txt_to_dt.Text = Format(dt.Rows(0)(0), "dd/MMM/yyyy")
        End If
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txt_to_dt.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
     
        If CDate(Me.txt_from_dt.Text) > CDate(Me.txt_to_dt.Text) Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('To Date Not Valid');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            Dim usr() As String
            usr = Session("user_id").ToString().Split("!")
            Dim dt As DataTable = oh.ExecuteDataSet("select max(leave_dt) from hrm_comp_appl where emp_code=" & usr(0) & "").Tables(0)
            If dt.Rows.Count = 0 Then
                If CDate(Me.txt_from_dt.Text) > CDate(Date.Now) Or CDate(Me.txt_to_dt.Text) > CDate(Date.Now) Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('Future Date Not Allowed');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Else
                    Server.Transfer("comp_application_report.aspx?fdt=" & Me.txt_from_dt.Text & "&tdt=" & Me.txt_to_dt.Text & "")
                End If

            Else
                If Not IsDBNull(dt.Rows(0)(0)) Then
                    If CDate(Me.txt_from_dt.Text) > CDate(dt.Rows(0)(0)) Or CDate(Me.txt_to_dt.Text) > CDate(dt.Rows(0)(0)) Then
                        Dim ldt As String = Format(CDate(dt.Rows(0)(0)), "dd/MMM/yyyy")
                        Dim cl_script1 As New System.Text.StringBuilder
                        cl_script1.Append("         alert('Future Date Not Allowed and your last leave date is " & ldt & "');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Else
                        Server.Transfer("comp_application_report.aspx?fdt=" & Me.txt_from_dt.Text & "&tdt=" & Me.txt_to_dt.Text & "")
                    End If
                Else
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('You Have no Compensatory OFF to view');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Server.Transfer("date_select_report.aspx")
                End If
                End If
           
        End If


    End Sub
End Class
