Imports System.Data
Imports System.Data.OracleClient
Partial Class salaryreport_salary_lop_live_58bea3178533
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim f As Integer = Session("firm_id")

        If (CDate(Me.txt_fdt.Text) <= CDate(Me.txt_tdt.Text) And CDate(Me.txt_tdt.Text) <= CDate(Format(Date.Today, "dd/MMM/yyyy"))) Then

            If (CInt(Me.txt_lf.Text) < CInt(Me.txt_lt.Text)) Then

                If (Me.chk_out.Checked = False And Me.chk_reg.Checked = False And Me.chk_all.Checked = False And Me.chk_all.Visible = True And Me.chk_reg.Visible = True And Me.chk_out.Visible = True) Then

                    Dim msgbx As New System.Text.StringBuilder
                    msgbx.Append("         alert('PLEASE SELECT THE OPTION PERMANANT OR OUTSOURCE OR ALL');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                    Exit Sub
                    If (Me.chk_lop.Visible = True And Me.chk_arr.Visible = True) Then
                        If (Me.chk_arr.Checked = False And Me.chk_lop.Checked = False) Then


                            msgbx.Append("         alert(' PLEASE SELECT THE OPTION LOP OR ARREAR ');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                            Exit Sub
                        End If
                    End If

                Else
                    If (Me.chk_lop.Visible = True And Me.chk_arr.Visible = True) Then
                        If (Me.chk_arr.Checked = False And Me.chk_lop.Checked = False) Then

                            Dim msgbx As New System.Text.StringBuilder
                            msgbx.Append("         alert(' PLEASE SELECT THE OPTION LOP OR ARREAR ');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                            Exit Sub
                        End If
                    End If
                    If (Me.cmb_status.SelectedValue = 1) Then
                        '*******************lop-live*******************
                        If (Me.chk_lop.Checked = True) Then
                            If (Me.txt_lf.Text = "" Or Me.txt_lt.Text = "") Then

                                Dim msgbx As New System.Text.StringBuilder
                                msgbx.Append("         alert('PLEASE ENTER THE LIMIT OF EMPLOYEE CODE');")
                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                            Else
                                If (Me.chk_reg.Checked = True) Then
                                    Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_out.Checked = True) Then
                                    Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_all.Checked = True) Then
                                    Server.Transfer("salloplive.aspx?&fdt=" & Me.txt_fdt.Text & "&frm =" & f & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                            End If
                        End If
                        '************************lop-arrear*********************
                        If (Me.chk_arr.Checked = True) Then
                            If (Me.txt_lf.Text = "" Or Me.txt_lt.Text = "") Then
                                Dim msgbx As New System.Text.StringBuilder
                                msgbx.Append("         alert('PLEASE ENTER THE LIMIT OF EMPLOYEE CODE');")
                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                                Exit Sub
                            Else
                                If (Me.chk_out.Checked = True) Then
                                    Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 3)
                                End If
                                If (Me.chk_all.Checked = True) Then
                                    Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 3)
                                End If
                                If (Me.chk_reg.Checked = True) Then
                                    Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 3)
                                End If
                            End If
                        End If
                    End If
                    '***********************************RESIGN*******************
                    If (Me.cmb_status.SelectedValue = 3) Then
                        If (Me.chk_lop.Checked = True) Then

                            If (Me.txt_lf.Text = "" Or Me.txt_lt.Text = "") Then
                                Dim msgbx As New System.Text.StringBuilder
                                msgbx.Append("         alert('PLEASE ENTER THE LIMIT OF EMPLOYEE CODE');")
                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                                Exit Sub
                            Else
                                If (Me.chk_reg.Checked = True) Then
                                    Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_out.Checked = True) Then
                                    Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                                If (Me.chk_all.Checked = True) Then
                                    Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 1)
                                End If
                            End If
                        End If
                        If (Me.chk_arr.Checked = True) Then
                            If (Me.txt_lf.Text = "" Or Me.txt_lt.Text = "") Then
                                Dim msgbx As New System.Text.StringBuilder
                                msgbx.Append("         alert('PLEASE ENTER THE LIMIT OF EMPLOYEE CODE');")
                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                                Exit Sub
                            Else
                                If (Me.chk_reg.Checked = True) Then
                                    Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 3)
                                End If
                                If (Me.chk_out.Checked = True) Then
                                    Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 3)
                                End If
                                If (Me.chk_all.Checked = True) Then
                                    Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue & "&ca=" & 3)
                                End If
                            End If
                        End If
                    End If
                    '********************************Regularized********************
                    If (Me.cmb_status.SelectedValue = 88) Then
                        Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&st=" & Me.cmb_status.SelectedValue)
                    End If
                    '****************************Termination***********************
                    If (Me.cmb_status.SelectedValue = 5) Then
                        If (Me.txt_lf.Text = "" Or Me.txt_lt.Text = "") Then
                            Dim msgbx As New System.Text.StringBuilder
                            msgbx.Append("         alert('PLEASE ENTER THE LIMIT OF EMPLOYEE CODE');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                            Exit Sub
                        Else
                            If (Me.chk_reg.Checked = True) Then
                                Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue)
                            End If
                            If (Me.chk_out.Checked = True) Then
                                Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue)
                            End If
                            If (Me.chk_all.Checked = True) Then
                                Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue)
                            End If
                        End If
                    End If
                    '***************************longleave****************************
                    If (Me.cmb_status.SelectedValue = 6) Then
                        If (Me.txt_lf.Text = "" Or Me.txt_lt.Text = "") Then
                            Dim msgbx As New System.Text.StringBuilder
                            msgbx.Append("         alert('PLEASE ENTER THE LIMIT OF EMPLOYEE CODE');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                            Exit Sub
                        Else
                            If (Me.chk_reg.Checked = True) Then
                                Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue)
                            End If
                            If (Me.chk_out.Checked = True) Then
                                Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue)
                            End If
                            If (Me.chk_all.Checked = True) Then
                                Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue)
                            End If
                        End If
                    End If
                    '***************************Suspension******************************
                    If (Me.cmb_status.SelectedValue = 4) Then
                        If (Me.txt_lf.Text = "" Or Me.txt_lt.Text = "") Then
                            Dim msgbx As New System.Text.StringBuilder
                            msgbx.Append("         alert('PLEASE ENTER THE LIMIT OF EMPLOYEE CODE');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                            Exit Sub
                        Else
                            If (Me.chk_reg.Checked = True) Then
                                Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue)
                            End If
                            If (Me.chk_out.Checked = True) Then
                                Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue)
                            End If
                            If (Me.chk_all.Checked = True) Then
                                Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue)
                            End If
                        End If
                    End If
                    '***************************MATERNITY**********************************
                    If (Me.cmb_status.SelectedValue = 10) Then
                        If (Me.txt_lf.Text = "" Or Me.txt_lt.Text = "") Then
                            Dim msgbx As New System.Text.StringBuilder
                            msgbx.Append("         alert('PLEASE ENTER THE LIMIT OF EMPLOYEE CODE');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                            Exit Sub
                        Else
                            If (Me.chk_reg.Checked = True) Then
                                Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 1 & "&st=" & Me.cmb_status.SelectedValue)
                            End If
                            If (Me.chk_out.Checked = True) Then
                                Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 2 & "&st=" & Me.cmb_status.SelectedValue)
                            End If
                            If (Me.chk_all.Checked = True) Then
                                Server.Transfer("salloplive.aspx?&frm =" & f & "&fdt=" & Me.txt_fdt.Text & "&tdt=" & Me.txt_tdt.Text & "&lf=" & Me.txt_lf.Text & "&lt=" & Me.txt_lt.Text & "&a=" & 3 & "&st=" & Me.cmb_status.SelectedValue)
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
        Dim f As Integer = Session("firm_id")
        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.txt_lf.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)
        If Session("access_id") = 33 Then
            If Not IsPostBack Then
                Me.txt_fdt.Text = Format(CDate("1/JAN/1954"), "dd/MMM/yyyy")
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

    Protected Sub cmb_status_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_status.SelectedIndexChanged
        If (Me.cmb_status.SelectedValue = 88) Then
            Me.chk_out.Visible = False
            Me.chk_reg.Visible = False
            Me.chk_all.Visible = False
            Me.txt_lf.Visible = False
            Me.txt_lt.Visible = False
            Me.lbl.Visible = False
            Me.chk_arr.Visible = False
            Me.chk_lop.Visible = False
        Else
            Me.chk_lop.Visible = True
            Me.chk_arr.Visible = True
            Me.chk_out.Visible = True
            Me.chk_reg.Visible = True
            Me.chk_all.Visible = True
            Me.txt_lf.Visible = True
            Me.txt_lt.Visible = True
            Me.lbl.Visible = True
        End If
        If (Me.cmb_status.SelectedValue = 5 Or Me.cmb_status.SelectedValue = 6 Or Me.cmb_status.SelectedValue = 10 Or Me.cmb_status.SelectedValue = 4) Then
            Me.chk_arr.Visible = False
            Me.chk_lop.Visible = False
        End If
    End Sub

    Protected Sub chk_lop_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_lop.CheckedChanged
        If (Me.chk_lop.Checked = True) Then
            Me.chk_arr.Checked = False
        End If
    End Sub

    Protected Sub chk_arr_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_arr.CheckedChanged
        If (Me.chk_arr.Checked = True) Then
            Me.chk_lop.Checked = False
        End If
    End Sub
End Class
