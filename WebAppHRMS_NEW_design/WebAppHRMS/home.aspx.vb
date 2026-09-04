Imports System.Data.OracleClient
Imports WebAppHRMS
Imports WebAppHRMS.SessionHandler
Partial Class home
    Inherits System.Web.UI.Page
    Dim _SessionHandler As New SessionHandler
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '--------VAPT - Input Validation for Query Parameters--------
        ValidateQueryParameters()
        ValidateSessionData()
        '------------------------Session Checking---------------------------------
        Dim request As New HrmsLoginControlRequest
        Dim Hresponse As New HrmsLoginSessionResponse
        request.empCode = Session("session_empcode").ToString

        request.session = Session("session_id").ToString

        request.flag = "1"
        Hresponse = _SessionHandler.HrmsLoginControl(request)
        If Hresponse.message <> "SESSION IS LIVE" Then
            Session.RemoveAll()
            Response.Redirect("Main.aspx", True)
        End If

        If Session.SessionID <> Session("cookieSessionid") Then
            Session.RemoveAll()
            Response.Redirect("Main.aspx", True)
        End If

        'Dim cs As String = "var reg_val;reg_val='HKCU\\DotNet\\DotKv';"
        'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)

        'If CInt(Session("key")) <> CInt(Me.hdn_key.Value) Then
        '    Session.RemoveAll()
        '    Response.Redirect("../default.aspx")
        '    Exit Sub
        'End If

        'If Not IsPostBack Then
        '    'Me.Master.heading = Session("title")
        'End If
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        'If Session("menu_id") = 0 Then
        '    If Session("branch_id") = 0 Or Session("branch_id") = 9999 Then
        '        If (CInt(Session("access_id")) >= 10 And CInt(Session("access_id")) <= 15) Or CInt(Session("access_id")) = 51 Or CInt(Session("access_id")) = 52 Then
        '            Me.MasterPageFile = "~/ho.master"
        '        Else
        '            Me.MasterPageFile = "~/mis.master"

        '        End If
        '    Else
        '        Me.MasterPageFile = "~/branch.master"
        '    End If
        'Else
        Try
            '--------VAPT - Validate Session Values--------
            Dim branchId As Integer = 0
            Dim accessId As Integer = 0
            Dim firmId As Integer = 0
            Dim menuId As Integer = 0

            If Not Integer.TryParse(Session("branch_id").ToString(), branchId) Then branchId = 0
            If Not Integer.TryParse(Session("access_id").ToString(), accessId) Then accessId = 0
            If Not Integer.TryParse(Session("firm_id").ToString(), firmId) Then firmId = 0
            If Not Integer.TryParse(Session("menu_id").ToString(), menuId) Then menuId = 0

            If branchId = 0 Then

                If (CInt(Session("access_id")) >= 10 And CInt(Session("access_id")) <= 15) Or CInt(Session("access_id")) = 51 Or CInt(Session("access_id")) = 52 Then
                    If Session("menu_id") = 10 Then
                        If Session("firm_id") = 24 Then
                            Me.MasterPageFile = "~/jewel_ho_Accounts.master"
                        ElseIf Session("firm_id") = 37 Then
                            Me.MasterPageFile = "~/jewel_ho_Accounts.master"
                        ElseIf Session("firm_id") = 2 Then
                            Me.MasterPageFile = "~/ho_maben_Accounts.master"
                        ElseIf Session("firm_id") = 16 Then
                            Me.MasterPageFile = "~/macare_ho_Accounts.master"
                        Else
                            Me.MasterPageFile = "~/ho_Accounts.master"
                        End If
                    ElseIf Session("menu_id") = 20 Then
                        Me.MasterPageFile = "~/ho_Loans.master"
                    ElseIf Session("menu_id") = 30 Then

                        If Session("firm_id") = 1 Then
                            Me.MasterPageFile = "~/mafil_ho_Deposits.master"
                        ElseIf Session("firm_id") = 2 Then
                            Me.MasterPageFile = "~/maben_ho_Deposits.master"
                        ElseIf Session("firm_id") = 4 Then
                            Me.MasterPageFile = "~/maafin_ho_Deposits.master"
                        Else
                            Me.MasterPageFile = "~/ho_Deposits.master"
                        End If


                    ElseIf Session("menu_id") = 40 Then

                        If Session("firm_id") = 9 Then

                            Me.MasterPageFile = "~/maibro_ho_feebased.master"
                        ElseIf Session("firm_id") = 1 Then
                            Me.MasterPageFile = "~/mafil_ho_feebased.master"
                        Else
                            Me.MasterPageFile = "~/ho_feebased.master"
                        End If


                        ' Me.MasterPageFile = "~/ho_feebased.master"
                    ElseIf Session("menu_id") = 50 Then
                        If Session("firm_id") = 24 Then
                            Me.MasterPageFile = "~/jewho_hrm.master"
                        ElseIf Session("firm_id") = 37 Then
                            Me.MasterPageFile = "~/jewho_hrm.master"
                        ElseIf Session("firm_id") = 16 Then
                            Me.MasterPageFile = "~/macho_hrm.master"


                            '----------MODIFIED FOR MABEN Krishnadas aug-20 req-10230
                        ElseIf Session("firm_id") = 2 Then

                            If CInt(Session("access_id")) = 33 Then
                                Me.MasterPageFile = "~/m_hrm_maben.master"
                            Else
                                Me.MasterPageFile = "~/ho_hrm_maben_special.master"
                            End If

                            '-------------end


                        Else
                            If Session("firm_id") = 28 Then
                                Me.MasterPageFile = "~/hr_master.master"
                            Else
                                Me.MasterPageFile = "~/hr_master.master"
                            End If
                        End If


                    ElseIf Session("menu_id") = 60 Then
                        If Session("firm_id") = 24 Then
                            Me.MasterPageFile = "~/Majewel_ho_Others.master"
                        ElseIf Session("firm_id") = 37 Then
                            Me.MasterPageFile = "~/Majewel_ho_Others.master"
                        ElseIf Session("firm_id") = 20 Then
                            Me.MasterPageFile = "~/AgroFarm_ho_Others.master"
                        ElseIf Session("firm_id") = 16 Then
                            Me.MasterPageFile = "~/Macare_ho_Others.master"
                        ElseIf Session("firm_id") = 6 Or Session("firm_id") = 14 Or Session("firm_id") = 31 Or Session("firm_id") = 32 Then
                            Me.MasterPageFile = "~/macil_ho_Others.master"
                        Else
                            Me.MasterPageFile = "~/ho_Others.master"
                        End If
                    ElseIf Session("menu_id") = 80 Then
                        Me.MasterPageFile = "~/m_Legal.master"
                    ElseIf Session("menu_id") = 90 Then
                        Me.MasterPageFile = "~/Area_Wise_Recovery.master"
                    Else
                        Me.MasterPageFile = "~/hr_master.master"
                    End If
                Else

                    If Session("menu_id") = 10 Then

                        If Session("firm_id") = 24 Then
                            Me.MasterPageFile = "~/jewel_m_accounts.master"
                        ElseIf Session("firm_id") = 37 Then
                            Me.MasterPageFile = "~/jewel_m_accounts.master"
                        ElseIf Session("firm_id") = 2 Then
                            Me.MasterPageFile = "~/maben_m_accounts.master"
                        ElseIf Session("firm_id") = 16 Then
                            Me.MasterPageFile = "~/macare_m_accounts.master"
                        Else
                            Me.MasterPageFile = "~/m_accounts.master"
                        End If


                    ElseIf Session("menu_id") = 20 Then

                        If Session("firm_id") = 4 Then
                            Me.MasterPageFile = "~/maafin_m_loans.master"
                        Else
                            Me.MasterPageFile = "~/m_loans.master"
                        End If
                    ElseIf Session("menu_id") = 30 Then

                        If Session("firm_id") = 1 Then
                            Me.MasterPageFile = "~/mafil_m_deposits.master"
                        ElseIf Session("firm_id") = 2 Then
                            Me.MasterPageFile = "~/maben_m_deposits.master"
                        ElseIf Session("firm_id") = 4 Then
                            Me.MasterPageFile = "~/maafin_m_deposits.master"
                        Else
                            Me.MasterPageFile = "~/m_deposits.master"
                        End If

                    ElseIf Session("menu_id") = 40 Then

                        If Session("firm_id") = 9 Then
                            Me.MasterPageFile = "~/maibro_m_feebased.master"
                        ElseIf Session("firm_id") = 1 Then
                            Me.MasterPageFile = "~/mafil_m_feebased.master"
                        Else
                            Me.MasterPageFile = "~/m_feebased.master"
                        End If

                        '  Me.MasterPageFile = "~/m_feebased.master"
                    ElseIf Session("menu_id") = 50 Then

                        If Session("firm_id") = 24 Then
                            Me.MasterPageFile = "~/jewm_hrm.master"
                        ElseIf Session("firm_id") = 37 Then
                            Me.MasterPageFile = "~/jewm_hrm.master"
                        ElseIf Session("firm_id") = 16 Then
                            Me.MasterPageFile = "~/macm_hrm.master"
                        ElseIf Session("firm_id") = 4 Then
                            Me.MasterPageFile = "~/MAAFIN_m_hrm.master"
                            '------------REQ-9600-krishnadas--changed for Maben---------------
                        ElseIf Session("firm_id") = 2 Then

                            If CInt(Session("access_id")) = 33 Then
                                Me.MasterPageFile = "~/m_hrm_maben.master"
                            Else
                                Me.MasterPageFile = "~/ho_hrm_maben_special.master"
                            End If
                            '-----------------------------ends

                        Else
                            If Session("firm_id") = 28 Then
                                Me.MasterPageFile = "~/hr_master.master"
                            Else
                                Me.MasterPageFile = "~/hr_master.master"
                            End If
                        End If

                    ElseIf Session("menu_id") = 60 Then
                        If Session("firm_id") = 24 Then
                            Me.MasterPageFile = "~/Majewel_m_others.master"
                        ElseIf Session("firm_id") = 37 Then
                            Me.MasterPageFile = "~/Majewel_m_others.master"
                        ElseIf Session("firm_id") = 20 Then
                            Me.MasterPageFile = "~/AgroFarm_ m_others.master"
                        ElseIf Session("firm_id") = 16 Then
                            Me.MasterPageFile = "~/Macare_m_others.master"
                        ElseIf Session("firm_id") = 6 Or Session("firm_id") = 14 Or Session("firm_id") = 31 Or Session("firm_id") = 32 Then
                            Me.MasterPageFile = "~/macil_m_others.master"
                        Else
                            Me.MasterPageFile = "~/m_others.master"
                        End If
                    ElseIf Session("menu_id") = 70 Then
                        Me.MasterPageFile = "~/m_clinic.master"
                    ElseIf Session("menu_id") = 80 Then
                        Me.MasterPageFile = "~/m_Legal.master"
                    ElseIf Session("menu_id") = 90 Then
                        Me.MasterPageFile = "~/Area_Wise_Recovery.master"
                    Else
                        Me.MasterPageFile = "~/hr_master.master"
                    End If

                End If


            Else
                If Session("menu_id") = 10 Then
                    Me.MasterPageFile = "~/b_accounts.master"

                ElseIf Session("menu_id") = 101 Then
                    Me.MasterPageFile = "~/b_a_bankrecon.master"
                ElseIf Session("menu_id") = 102 Then
                    Me.MasterPageFile = "~/b_a_authSign.master"
                ElseIf Session("menu_id") = 103 Then
                    If Session("firm_id") = 24 Then
                        Me.MasterPageFile = "~/b_a_paymentrat_majwel.master"
                    ElseIf Session("firm_id") = 37 Then
                        Me.MasterPageFile = "~/b_a_paymentrat_majwel.master"
                    ElseIf Session("firm_id") = 16 Then
                        Me.MasterPageFile = "~/b_a_paymentrat_macare.master"
                    Else
                        Me.MasterPageFile = "~/b_a_paymentrat.master"
                    End If

                ElseIf Session("menu_id") = 104 Then
                    Me.MasterPageFile = "~/b_a_Fundtransfer.master"
                ElseIf Session("menu_id") = 105 Then
                    Me.MasterPageFile = "~/b_a_reports.master"
                    'ElseIf Session("menu_id") = 106 Then
                    '    Me.MasterPageFile = "~/b_a_InterestAcc.master"
                ElseIf Session("menu_id") = 107 Then
                    Me.MasterPageFile = "~/b_a_Incentive.master"
                ElseIf Session("menu_id") = 108 Then


                    If Session("firm_id") = 4 Then
                        Me.MasterPageFile = "~/maafin_b_a_GeneralAcc.master"
                    ElseIf Session("firm_id") = 2 Then
                        Me.MasterPageFile = "~/maben_b_a_GeneralAccNew.master"
                    Else
                        Me.MasterPageFile = "~/b_a_GeneralAcc.master"
                    End If


                ElseIf Session("menu_id") = 201 Then
                    If Session("firm_id") = 2 Then
                        Me.MasterPageFile = "~/b_GoldLoan_MABEN.master"
                    Else
                        Me.MasterPageFile = "~/b_GoldLoan.master"
                    End If
                ElseIf Session("menu_id") = 202 Then
                    Me.MasterPageFile = "~/b_GoldOD.master"
                ElseIf Session("menu_id") = 203 Then
                    Me.MasterPageFile = "~/b_BusinessLoan.master"
                ElseIf Session("menu_id") = 204 Then
                    Me.MasterPageFile = "~/b_Personal.master"
                ElseIf Session("menu_id") = 205 Then
                    Me.MasterPageFile = "~/b_SECLoan.master"
                ElseIf Session("menu_id") = 206 Then
                    Me.MasterPageFile = "~/b_SwarnaNidhi.master"
                ElseIf Session("menu_id") = 207 Then
                    Me.MasterPageFile = "~/b_HPNLoan.master"
                ElseIf Session("menu_id") = 208 Then
                    Me.MasterPageFile = "~/b_VehicleLoan.master"
                ElseIf Session("menu_id") = 209 Then
                    Me.MasterPageFile = "~/b_HPNSLoan.master"
                ElseIf Session("menu_id") = 210 Then
                    Me.MasterPageFile = "~/b_pronoteLoan.master"
                ElseIf Session("menu_id") = 211 Then
                    If Session("firm_id") = 2 Then
                        Me.MasterPageFile = "b_TakeOverLaon_Maben.master"
                    Else
                        Me.MasterPageFile = "~/b_TakeOverLaon.master"
                    End If
                ElseIf Session("menu_id") = 212 Then
                    Me.MasterPageFile = "~/b_Chits.master"


                ElseIf Session("menu_id") = 30 Then
                    Me.MasterPageFile = "~/b_deposits.master"
                ElseIf Session("menu_id") = 301 Then
                    'Firm id 1
                    If Session("firm_id") = 1 Then
                        Me.MasterPageFile = "~/b_savingDeposit_magfil.master"
                    Else
                        Me.MasterPageFile = "~/b_savingDeposit.master"
                    End If
                ElseIf Session("menu_id") = 302 Then

                    'Firm id 1
                    'If Session("firm_id") = 1 Then
                    '    Me.MasterPageFile = "~/b_TermDeposit.master"
                    'Else
                    '    Me.MasterPageFile = "~/b_TermDeposit_magfil.master"
                    'End If

                    Me.MasterPageFile = "~/b_TermDeposit.master"
                ElseIf Session("menu_id") = 303 Then
                    Me.MasterPageFile = "~/b_Debenture.master"
                ElseIf Session("menu_id") = 304 Then
                    Me.MasterPageFile = "~/b_bond.master"
                ElseIf Session("menu_id") = 305 Then
                    Me.MasterPageFile = "~/b_RecurrDeposit.master"
                ElseIf Session("menu_id") = 306 Then
                    Me.MasterPageFile = "~/b_deposit_others.master"
                ElseIf Session("menu_id") = 307 Then
                    Me.MasterPageFile = "~/b_d_Taxation.master"





                ElseIf Session("menu_id") = 40 Then
                    Me.MasterPageFile = "~/b_fee_based.master"
                ElseIf Session("menu_id") = 401 Then
                    Me.MasterPageFile = "~/b_Locker.master"
                ElseIf Session("menu_id") = 402 Then
                    Me.MasterPageFile = "~/b_MoneyTransfer.master"
                ElseIf Session("menu_id") = 403 Then
                    Me.MasterPageFile = "~/b_GeneralInsurance.master"
                ElseIf Session("menu_id") = 404 Then
                    Me.MasterPageFile = "~/b_LifeInsurance.master"
                ElseIf Session("menu_id") = 405 Then
                    Me.MasterPageFile = "~/b_Forex.master"
                ElseIf Session("menu_id") = 406 Then
                    Me.MasterPageFile = "~/b_GoldCoin.master"
                ElseIf Session("menu_id") = 407 Then
                    Me.MasterPageFile = "~/b_AirTicket.master"

                ElseIf Session("menu_id") = 50 Then
                    Me.MasterPageFile = "~/b_hrm.master"
                ElseIf Session("menu_id") = 501 Then

                    If Session("firm_id") = 4 Then
                        Me.MasterPageFile = "~/B_H_HRM_MAAFIN.master"
                    Else
                        If Session("firm_id") = 24 Then
                            Me.MasterPageFile = "~/B_H_HRM_JWEL.master"
                        Else
                            Me.MasterPageFile = "~/B_H_HRM.master"
                        End If
                    End If


                ElseIf Session("menu_id") = 502 Then
                    Me.MasterPageFile = "~/b_h_EmpPunching.master"
                ElseIf Session("menu_id") = 503 Then
                    Me.MasterPageFile = "~/b_h_SecurityPunching.master"
                ElseIf Session("menu_id") = 504 Then
                    Me.MasterPageFile = "~/b_h_Tour.master"
                ElseIf Session("menu_id") = 505 Then
                    Me.MasterPageFile = "~/b_h_staffNorms.master"
                ElseIf Session("menu_id") = 506 Then
                    Me.MasterPageFile = "~/b_h_leave.master"
                ElseIf Session("menu_id") = 507 Then
                    Me.MasterPageFile = "~/b_h_Posting.master"
                ElseIf Session("menu_id") = 508 Then
                    Me.MasterPageFile = "~/b_h_outstation.master"

                ElseIf Session("menu_id") = 60 Then
                    Me.MasterPageFile = "~/b_others.master"
                ElseIf Session("menu_id") = 601 Then
                    If Session("firm_id") = 24 Then
                        Me.MasterPageFile = "~/Majewel_b_o_Hardware.master"
                    ElseIf Session("firm_id") = 37 Then
                        Me.MasterPageFile = "~/Majewel_b_o_Hardware.master"
                    ElseIf Session("firm_id") = 16 Then
                        Me.MasterPageFile = "~/Macare_ b_o_Hardware.master"
                    Else
                        Me.MasterPageFile = "~/b_o_Hardware.master"
                    End If
                ElseIf Session("menu_id") = 602 Then
                    Me.MasterPageFile = "~/b_o_Software.master"
                ElseIf Session("menu_id") = 603 Then
                    Me.MasterPageFile = "~/b_o_Store.master"
                ElseIf Session("menu_id") = 604 Then
                    Me.MasterPageFile = "~/b_o_maintenance.master"
                ElseIf Session("menu_id") = 605 Then
                    Me.MasterPageFile = "~/b_o_GoldRecovery.master"
                ElseIf Session("menu_id") = 606 Then
                    Me.MasterPageFile = "~/b_o_audit.master"
                ElseIf Session("menu_id") = 607 Then
                    Me.MasterPageFile = "~/b_o_GL4.master"
                ElseIf Session("menu_id") = 608 Then
                    Me.MasterPageFile = "~/b_o_noticedist.master"
                ElseIf Session("menu_id") = 609 Then
                    Me.MasterPageFile = "~/b_o_spurious.master"
                ElseIf Session("menu_id") = 610 Then
                    Me.MasterPageFile = "~/b_o_CRM.master"
                ElseIf Session("menu_id") = 611 Then
                    If Session("firm_id") = 24 Then
                        Me.MasterPageFile = "~/Majewel_b_o_Others.master"
                    ElseIf Session("firm_id") = 37 Then
                        Me.MasterPageFile = "~/Majewel_b_o_Others.master"
                    ElseIf Session("firm_id") = 16 Then
                        Me.MasterPageFile = "~/Macare_b_o_Others.master"
                    ElseIf Session("firm_id") = 2 Then
                        Me.MasterPageFile = "~/MABEN_b_o_Others.master"
                    Else
                        Me.MasterPageFile = "~/b_o_Others.master"
                    End If
                End If

            End If
            'End If
        Catch ex As Exception
            Server.Transfer("show_err.aspx")
        End Try
    End Sub

    '--------VAPT - Input Validation Methods--------
    Private Sub ValidateQueryParameters()
        For Each key As String In Request.QueryString.AllKeys
            If key IsNot Nothing Then
                Dim value As String = Request.QueryString(key)

                If ContainsMaliciousContent(value) OrElse value.Length > 100 Then
                    Response.Redirect("show_err.aspx")
                    Return
                End If
            End If
        Next
    End Sub

    Private Sub ValidateSessionData()
        If Session("user_id") Is Nothing OrElse Session("branch_id") Is Nothing Then
            Response.Redirect("Main.aspx")
            Return
        End If

        Dim userId As String = Session("user_id").ToString()
        If String.IsNullOrEmpty(userId) OrElse ContainsMaliciousContent(userId) Then
            Session.RemoveAll()
            Response.Redirect("Main.aspx")
            Return
        End If
    End Sub

    Private Function ContainsMaliciousContent(input As String) As Boolean
        If String.IsNullOrEmpty(input) Then Return False

        Dim maliciousPatterns() As String = {
            "<script", "javascript:", "vbscript:", "onload=", "onerror=",
            "''", "--", "/*", "*/", "xp_", "sp_", "exec", "union",
            "select", "insert", "update", "delete", "drop", "create"
        }

        Dim lowerInput As String = input.ToLower()
        For Each pattern As String In maliciousPatterns
            If lowerInput.Contains(pattern) Then Return True
        Next

        Return False
    End Function
End Class
