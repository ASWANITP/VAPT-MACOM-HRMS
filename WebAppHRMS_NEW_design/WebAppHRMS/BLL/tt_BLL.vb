Imports Microsoft.VisualBasic
Imports System.Data.Entity.Infrastructure.Design
Namespace TTBLL
    Public Class tt_BLL
        Dim ttobj As New TTDAL.DAL.tt_DAL
        Function getdata(ByVal query As String) As Data.DataTable
            If query <> "" Then
                Return ttobj.execquery(query)
            Else
                Dim dt As New Data.DataTable
                Return dt
            End If
        End Function
        Function confirmation(ByVal procid As Integer, ByVal firm As Integer, ByVal branch As Integer, ByVal Details As String) As String
            Dim msg As String = ""
            If procid = 1 Then
                msg = ttobj.updatebankdtl(firm, branch, Details)
            ElseIf procid = 2 Then
                msg = ttobj.ttreqbranch(firm, branch, Details)
            ElseIf procid = 3 Then
                msg = ttobj.ttamconf(firm, branch, Details)
            ElseIf procid = 4 Then
                msg = ttobj.ttcancel_branch(firm, branch, Details)
            ElseIf procid = 5 Then
                msg = ttobj.tt_nearbr(branch, Details)
            ElseIf procid = 6 Then
                msg = ttobj.tt_nearbr_verify(Details)
            ElseIf procid = 7 Then
                msg = ttobj.tt_add_update_bank(firm, branch, Details)
            ElseIf procid = 8 Then
                msg = ttobj.tt_add_location(Details)
            ElseIf procid = 9 Then
                msg = ttobj.tt_add_update_location_dtls(branch, Details)
            End If
            Return msg
        End Function
        Function dispdata(ByVal query As String) As String
            If query <> "" Then
                Return ttobj.executequery(query)
            Else
                Return " "
            End If

        End Function
        Function confirmation_acc(ByVal procid As Integer, ByVal firm As Integer, ByVal branch As Integer, ByVal Details As String) As ResultHandler
            Dim rh As New ResultHandler
            If procid = 1 Then
                rh = ttobj.ttconfirm_ao(firm, branch, Details)
            ElseIf procid = 2 Then
                rh = ttobj.tt_toao(firm, branch, Details)
            ElseIf procid = 3 Then
                rh = ttobj.tt_receive(firm, branch, Details)
            End If
            Return rh

        End Function
    End Class
End Namespace
