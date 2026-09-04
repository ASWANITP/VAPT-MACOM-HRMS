
Imports System.Data
Imports System.Data.OracleClient
Public Class Individual_punch_block
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.txtcode.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select Empcode');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
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

                        dt1 = oh.ExecuteDataSet("select f.firm_id from employ_firm f where f.emp_code=" & txtcode.Text & "").Tables(0)
                        If (dt1.Rows(0)(0) = Session("firm_id")) Then
                            Server.Transfer("Display_punchblock_report.aspx?Fdt=" & txtfdt.Text & "&Tdt=" & txttdt.Text & "&Ecode=" & txtcode.Text)
                        Else
                            Dim cl_script1 As New System.Text.StringBuilder
                            cl_script1.Append("         alert('You are not authorized');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")

        dt = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=1521 and s.emp_id=" & sf(0) & "").Tables(0)
        If (dt.Rows(0)(0) = 0) Then
            Server.Transfer("../../show_err.aspx")

        End If

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtcode.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
    End Sub

End Class