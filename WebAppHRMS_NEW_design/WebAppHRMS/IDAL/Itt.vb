Imports Microsoft.VisualBasic
Imports System.Data.Entity.Infrastructure.Design
Namespace tt_IDAL.IDAL
    Public Class Itt
        Public Interface TT_IDAL
            Function execquery(ByVal qry As String) As Data.DataTable
            Function updatebankdtl(ByVal fmno As Integer, ByVal brid As Integer, ByVal bankdtl As String) As String
            Function executequery(ByVal qry As String) As String
            Function ttreqbranch(ByVal fmno As Integer, ByVal brid As Integer, ByVal reqdtl As String) As String
            Function ttamconf(ByVal fmno As Integer, ByVal brid As Integer, ByVal ttdtl As String) As String
            Function ttconfirm_ao(ByVal fmno As Integer, ByVal brid As Integer, ByVal ttdtl As String) As ResultHandler
            Function ttcancel_branch(ByVal fmno As Integer, ByVal brid As Integer, ByVal ttdtl As String) As String
            Function tt_toao(ByVal fmno As Integer, ByVal brid As Integer, ByVal ttdtl As String) As ResultHandler
            Function tt_receive(ByVal fmno As Integer, ByVal brid As Integer, ByVal ttdtl As String) As ResultHandler
            Function tt_nearbr(ByVal brid As Integer, ByVal detail As String) As String
            Function tt_nearbr_verify(ByVal detail As String) As String
            Function tt_add_update_bank(ByVal fmno As Integer, ByVal brid As Integer, ByVal bankdtl As String) As String
            Function tt_add_update_location_dtls(ByVal brid As Integer, ByVal bankdtl As String) As String
            Function tt_add_location(ByVal location As String) As String
        End Interface
    End Class
End Namespace
