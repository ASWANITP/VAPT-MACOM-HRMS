
Imports System.Data
Imports System.Data.OracleClient
Public Class hrm_compulsaryleave_report
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Me.txtfdt.Text = "" Or Me.txttdt.Text = "" Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('Please Select Date');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                If CDate(Me.txtfdt.Text) > CDate(Me.txtfdt.Text) Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('To Date Not Valid');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Else
                    If CDate(Me.txtfdt.Text) > CDate(Date.Now) Or CDate(Me.txtfdt.Text) > CDate(Date.Now) Then
                        Dim cl_script1 As New System.Text.StringBuilder
                        cl_script1.Append("         alert('Future Date Not Allowed');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Else


                    If (Session("firm_id") = 8) Then
                        Server.Transfer("hrm_compulsary_reportrpt.aspx?Fdt=" & txtfdt.Text & "&Tdt=" & txttdt.Text)
                    Else
                        Dim cl_script1 As New System.Text.StringBuilder
                        cl_script1.Append("         alert('You are not authorized');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    End If
                End If
            End If
            End If
        'End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        '------VAPT - improper parameter validation---------------------------------------
        Dim paramCount As Integer = Request.QueryString.Count
        If Request.QueryString.Count > 0 Then
            Response.StatusCode = 400
            Response.StatusDescription = "Bad Request"
            Response.End()
        End If

        '------------------------------------------------------------------------
        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")

        dt = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=174 and s.emp_id=" & sf(0) & "").Tables(0)
        If (dt.Rows(0)(0) = 0) Then
            Server.Transfer("../show_err.aspx")

        End If

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtfdt.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "Employee Compulsary Leave Report"
    End Sub

End Class