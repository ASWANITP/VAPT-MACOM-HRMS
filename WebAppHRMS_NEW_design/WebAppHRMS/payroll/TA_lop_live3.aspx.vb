Imports System.Data
Imports System.Data.OracleClient
Partial Class TA_lop_live3_85ddf83d6894
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If (CDate(Me.txt_fdt.Text) <= CDate(Me.txt_tdt.Text) And CDate(Me.txt_tdt.Text) <= CDate(Format(Date.Today, "dd/MMM/yyyy"))) Then

            If (CInt(Me.txt_lf.Text) < CInt(Me.txt_lt.Text)) Then

                If (Me.chk_out.Checked = False And Me.chk_reg.Checked = False And Me.chk_all.Checked = False And Me.chk_all.Visible = True And Me.chk_out.Visible = True And Me.chk_reg.Visible = True) Then
                    Dim msgbx As New System.Text.StringBuilder
                    msgbx.Append("         alert('PLEASE SELECT THE OPTION PERMANANT OR OUTSOURCE OR ALL');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                    If (Me.chk_leave.Visible = True And Me.chk_lleav.Visible = True) Then
                        If (Me.chk_lleav.Checked = False And Me.chk_leave.Checked = False) Then


                            msgbx.Append("         alert(' PLEASE SELECT THE OPTION LEAVE OR LONGLEAVE ');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                            Exit Sub
                        End If
                    End If

                Else
                    If (Me.chk_leave.Visible = True And Me.chk_lleav.Visible = True) Then
                        If (Me.chk_lleav.Checked = False And Me.chk_leave.Checked = False) Then

                            Dim msgbx As New System.Text.StringBuilder
                            msgbx.Append("         alert(' PLEASE SELECT THE OPTION LEAVE OR LONGLEAVE ');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                            Exit Sub
                        End If
                    End If

                    '**************************live*************************************************
                    If (Me.cmb_status.SelectedValue = 1) Then

                        If (Me.txt_lf.Text = "" Or Me.txt_lt.Text = "") Then

                            Dim msgbx As New System.Text.StringBuilder
                            msgbx.Append("         alert('PLEASE ENTER THE LIMIT OF EMPLOYEE CODE');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                        Else

                            If (Me.chk_reg.Checked = True) Then

                                If (Me.chk_leave.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_lleav.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                                End If

                            End If

                            If (Me.chk_out.Checked = True) Then

                                If (Me.chk_leave.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_lleav.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                                End If


                            End If
                            If (Me.chk_all.Checked = True) Then

                                If (Me.chk_leave.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_lleav.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                                End If

                            End If
                        End If
                    End If
                    '**********************************resign*****************************
                    If (Me.cmb_status.SelectedValue = 3) Then

                        If (Me.txt_lf.Text = "" Or Me.txt_lt.Text = "") Then

                            Dim msgbx As New System.Text.StringBuilder
                            msgbx.Append("         alert('PLEASE ENTER THE LIMIT OF EMPLOYEE CODE');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                            Exit Sub
                        Else
                            If (Me.chk_reg.Checked = True) Then

                                If (Me.chk_leave.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_lleav.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                                End If
                            End If

                            If (Me.chk_out.Checked = True) Then

                                If (Me.chk_leave.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_lleav.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                                End If
                            End If

                            If (Me.chk_all.Checked = True) Then

                                If (Me.chk_leave.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_lleav.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                                End If

                            End If
                        End If
                    End If
                    '****************************REGULARISED***************************************

                    If (Me.cmb_status.SelectedValue = 88) Then
                        If (Me.chk_leave.Checked = True) Then

                            Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                        End If
                        If (Me.chk_lleav.Checked = True) Then
                            Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                        End If
                    End If

                    '*********************************Terminated************************************************
                    If (Me.cmb_status.SelectedValue = 5) Then
                        If (Me.txt_lf.Text = "" Or Me.txt_lt.Text = "") Then

                            Dim msgbx As New System.Text.StringBuilder
                            msgbx.Append("         alert('PLEASE ENTER THE LIMIT OF EMPLOYEE CODE');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                            Exit Sub
                        Else

                            If (Me.chk_reg.Checked = True) Then
                                If (Me.chk_leave.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_lleav.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                                End If
                            End If
                            If (Me.chk_out.Checked = True) Then
                                If (Me.chk_leave.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_lleav.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                                End If
                            End If
                            If (Me.chk_all.Checked = True) Then
                                If (Me.chk_leave.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_lleav.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                                End If
                            End If
                        End If
                    End If
                    '*******************************MATERNITY**********************************
                    If (Me.cmb_status.SelectedValue = 10) Then

                        If (Me.txt_lf.Text = "" Or Me.txt_lt.Text = "") Then

                            Dim msgbx As New System.Text.StringBuilder
                            msgbx.Append("         alert('PLEASE ENTER THE LIMIT OF EMPLOYEE CODE');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                        Else
                            If (Me.chk_reg.Checked = True) Then
                                If (Me.chk_leave.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_lleav.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                                End If
                            End If
                            If (Me.chk_out.Checked = True) Then
                                If (Me.chk_leave.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_lleav.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                                End If
                            End If
                            If (Me.chk_all.Checked = True) Then
                                If (Me.chk_leave.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_lleav.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                                End If
                            End If
                        End If
                    End If
                    '*****************SUSPENSION***************************
                    If (Me.cmb_status.SelectedValue = 4) Then

                        If (Me.txt_lf.Text = "" Or Me.txt_lt.Text = "") Then

                            Dim msgbx As New System.Text.StringBuilder
                            msgbx.Append("         alert('PLEASE ENTER THE LIMIT OF EMPLOYEE CODE');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                        Else
                            If (Me.chk_reg.Checked = True) Then
                                If (Me.chk_leave.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_lleav.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                                End If
                            End If
                            If (Me.chk_out.Checked = True) Then
                                If (Me.chk_leave.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_lleav.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                                End If
                            End If
                            If (Me.chk_all.Checked = True) Then
                                If (Me.chk_leave.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_lleav.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                                End If
                            End If
                        End If
                    End If
                    '*******************long leave**************************
                    If (Me.cmb_status.SelectedValue = 6) Then

                        If (Me.txt_lf.Text = "" Or Me.txt_lt.Text = "") Then

                            Dim msgbx As New System.Text.StringBuilder
                            msgbx.Append("         alert('PLEASE ENTER THE LIMIT OF EMPLOYEE CODE');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                        Else
                            If (Me.chk_reg.Checked = True) Then
                                If (Me.chk_leave.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_lleav.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                                End If
                            End If
                            If (Me.chk_out.Checked = True) Then
                                If (Me.chk_leave.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_lleav.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                                End If
                            End If
                            If (Me.chk_all.Checked = True) Then
                                If (Me.chk_leave.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_lleav.Checked = True) Then
                                    Server.Transfer("TAloplive3.aspx?&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 6)
                                End If
                            End If
                        End If
                    End If
                End If
            Else

                Dim msgbx As New System.Text.StringBuilder
                msgbx.Append("         alert('PLEASE Check the limit of employee code' );")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                Exit Sub
            End If
        Else

            Dim msgbx As New System.Text.StringBuilder
            msgbx.Append("         alert('PLEASE Check the From-date and To-date & To-date should be less than and equal to system date' );")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
            Exit Sub
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.txt_lf.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)
        If Session("access_id") = 33 Then
            If Not IsPostBack Then
                Me.txt_fdt.Text = Format(Date.Today, "dd/MMM/yyyy")

                Me.txt_tdt.Text = Format(Date.Today, "dd/MMM/yyyy")

            End If
        Else
            Response.Redirect("../show_err.aspx")
        End If
    End Sub




    Protected Sub chk_reg_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_reg.CheckedChanged
        If (Me.chk_reg.Checked = True) Then
            Me.chk_all.Checked = False
            Me.chk_out.Checked = False
        End If
    End Sub

    Protected Sub chk_out_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_out.CheckedChanged
        If (Me.chk_out.Checked = True) Then
            Me.chk_all.Checked = False
            Me.chk_reg.Checked = False

        End If
    End Sub

    Protected Sub chk_all_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_all.CheckedChanged
        If (Me.chk_all.Checked = True) Then
            Me.chk_out.Checked = False
            Me.chk_reg.Checked = False
        End If
    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Response.Redirect("../home.aspx")
    End Sub

    Protected Sub chk_leave_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_leave.CheckedChanged
        If (Me.chk_leave.Checked = True) Then
            Me.chk_lleav.Checked = False
        End If
    End Sub

    Protected Sub chk_lleav_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_lleav.CheckedChanged
        If (Me.chk_lleav.Checked = True) Then
            Me.chk_leave.Checked = False

        End If
    End Sub

    Protected Sub cmb_status_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_status.SelectedIndexChanged
        If (Me.cmb_status.SelectedValue = 88) Then
            Me.chk_out.Visible = False
            Me.chk_reg.Visible = False
            Me.chk_all.Visible = False
            Me.txt_lf.Visible = False
            Me.txt_lt.Visible = False
            Me.lbl.Visible = False
        Else
            Me.chk_out.Visible = True
            Me.chk_reg.Visible = True
            Me.chk_all.Visible = True
            Me.txt_lf.Visible = True
            Me.txt_lt.Visible = True
            Me.lbl.Visible = True
        End If
    End Sub
End Class
