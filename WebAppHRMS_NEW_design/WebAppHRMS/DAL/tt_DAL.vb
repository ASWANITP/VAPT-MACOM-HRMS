Imports System.Data.OracleClient
Namespace TTDAL.DAL
    Public Class tt_DAL
        Implements tt_IDAL.IDAL.Itt.TT_IDAL
        Dim oh As New Helper.Oracle.OracleHelper
        Public Function execquery(ByVal qry As String) As System.Data.DataTable Implements tt_IDAL.IDAL.Itt.TT_IDAL.execquery
            Dim dt As New DataTable
            dt = oh.ExecuteDataSet(qry).Tables(0)
            Return dt
        End Function

        Public Function updatebankdtl(ByVal fmno As Integer, ByVal brid As Integer, ByVal bankdetails As String) As String Implements tt_IDAL.IDAL.Itt.TT_IDAL.updatebankdtl
            Dim msg As String
            Try
                Dim parameters(3) As OracleParameter
                parameters(0) = New OracleParameter("fmno", OracleType.Number, 3)
                parameters(0).Value = fmno
                parameters(0).Direction = ParameterDirection.Input
                parameters(1) = New OracleParameter("brid", OracleType.Number, 5)
                parameters(1).Value = brid
                parameters(1).Direction = ParameterDirection.Input
                parameters(2) = New OracleParameter("dtls", OracleType.VarChar, 300)
                parameters(2).Value = bankdetails
                parameters(2).Direction = ParameterDirection.Input
                parameters(3) = New OracleParameter("err_stat", OracleType.VarChar, 300)
                parameters(3).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("tt_bankdtl_update", parameters)
                msg = parameters(3).Value
            Catch ex As Exception
                msg = ex.ToString
            End Try
            Return msg
        End Function

        Public Function executequery(ByVal qry As String) As String Implements tt_IDAL.IDAL.Itt.TT_IDAL.executequery
            Dim dt As New DataTable
            Dim str As String
            dt = oh.ExecuteDataSet(qry).Tables(0)
            str = dt.Rows(0)(0).ToString
            Return str
        End Function

        Public Function ttreqbranch(ByVal fmno As Integer, ByVal brid As Integer, ByVal reqdtl As String) As String Implements tt_IDAL.IDAL.Itt.TT_IDAL.ttreqbranch
            Dim msg As String
            Try
                Dim parameters(3) As OracleParameter
                parameters(0) = New OracleParameter("fmno", OracleType.Number, 3)
                parameters(0).Value = fmno
                parameters(0).Direction = ParameterDirection.Input
                parameters(1) = New OracleParameter("brno", OracleType.Number, 5)
                parameters(1).Value = brid
                parameters(1).Direction = ParameterDirection.Input
                parameters(2) = New OracleParameter("details", OracleType.VarChar, 1000)
                parameters(2).Value = reqdtl
                parameters(2).Direction = ParameterDirection.Input
                parameters(3) = New OracleParameter("reqmsg", OracleType.VarChar, 300)
                parameters(3).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("tt_req_branch", parameters)
                msg = parameters(3).Value
            Catch ex As Exception
                msg = ex.ToString
            End Try
            Return msg
        End Function

        Public Function ttamconf(ByVal fmno As Integer, ByVal brid As Integer, ByVal ttdtl As String) As String Implements tt_IDAL.IDAL.Itt.TT_IDAL.ttamconf
            Dim msg As String
            Try
                Dim parameters(3) As OracleParameter
                parameters(0) = New OracleParameter("fmno", OracleType.Number, 3)
                parameters(0).Value = fmno
                parameters(0).Direction = ParameterDirection.Input
                parameters(1) = New OracleParameter("brno", OracleType.Number, 5)
                parameters(1).Value = brid
                parameters(1).Direction = ParameterDirection.Input
                parameters(2) = New OracleParameter("details", OracleType.VarChar, 10000)
                parameters(2).Value = ttdtl
                parameters(2).Direction = ParameterDirection.Input
                parameters(3) = New OracleParameter("reqmsg", OracleType.VarChar, 300)
                parameters(3).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("tt_am_approval", parameters)
                msg = parameters(3).Value
            Catch ex As Exception
                msg = ex.ToString
            End Try
            Return msg
        End Function
        Public Function ttconfirm_ao(ByVal fmno As Integer, ByVal brid As Integer, ByVal ttdtl As String) As ResultHandler Implements tt_IDAL.IDAL.Itt.TT_IDAL.ttconfirm_ao
            Dim rh1 As New ResultHandler
            Try
                Dim parameters(5) As OracleParameter
                parameters(0) = New OracleParameter("fmno", OracleType.Number, 3)
                parameters(0).Value = fmno
                parameters(0).Direction = ParameterDirection.Input
                parameters(1) = New OracleParameter("brno", OracleType.Number, 5)
                parameters(1).Value = brid
                parameters(1).Direction = ParameterDirection.Input
                parameters(2) = New OracleParameter("details", OracleType.VarChar, 100000)
                parameters(2).Value = ttdtl
                parameters(2).Direction = ParameterDirection.Input
                parameters(3) = New OracleParameter("trans_no", OracleType.Number, 8)
                parameters(3).Direction = ParameterDirection.Output
                parameters(4) = New OracleParameter("errstat", OracleType.Number, 2)
                parameters(4).Direction = ParameterDirection.Output
                parameters(5) = New OracleParameter("msg", OracleType.VarChar, 300)
                parameters(5).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("tt_ao_confirm", parameters)
                rh1.message = parameters(5).Value
                rh1.transactionid = parameters(3).Value
                rh1.status = parameters(4).Value
            Catch ex As Exception
                rh1.message = ex.ToString
            End Try
            Return rh1
        End Function

        Public Function ttcancel_branch(ByVal fmno As Integer, ByVal brid As Integer, ByVal ttdtl As String) As String Implements tt_IDAL.IDAL.Itt.TT_IDAL.ttcancel_branch
            Dim msg As String
            Try
                Dim parameters(3) As OracleParameter
                parameters(0) = New OracleParameter("fmno", OracleType.Number, 3)
                parameters(0).Value = fmno
                parameters(0).Direction = ParameterDirection.Input
                parameters(1) = New OracleParameter("brno", OracleType.Number, 5)
                parameters(1).Value = brid
                parameters(1).Direction = ParameterDirection.Input
                parameters(2) = New OracleParameter("details", OracleType.VarChar, 10000)
                parameters(2).Value = ttdtl
                parameters(2).Direction = ParameterDirection.Input
                parameters(3) = New OracleParameter("reqmsg", OracleType.VarChar, 300)
                parameters(3).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("tt_bh_cancel", parameters)
                msg = parameters(3).Value
            Catch ex As Exception
                msg = ex.ToString
            End Try
            Return msg
        End Function

        Public Function tt_toao(ByVal fmno As Integer, ByVal brid As Integer, ByVal ttdtl As String) As ResultHandler Implements tt_IDAL.IDAL.Itt.TT_IDAL.tt_toao
            Dim op(5) As OracleParameter
            op(0) = New OracleParameter("brid", OracleType.Number, 5)
            op(0).Value = CInt(brid)
            op(0).Direction = ParameterDirection.Input
            op(1) = New OracleParameter("fmno", OracleType.Number, 3)
            op(1).Value = CInt(fmno)
            op(1).Direction = ParameterDirection.Input
            op(2) = New OracleParameter("dtls", OracleType.VarChar, 500)
            op(2).Value = ttdtl
            op(2).Direction = ParameterDirection.Input
            op(3) = New OracleParameter("trans_no", OracleType.Number, 8)
            op(3).Direction = ParameterDirection.Output
            op(4) = New OracleParameter("errstat", OracleType.Number, 3)
            op(4).Direction = ParameterDirection.Output
            op(5) = New OracleParameter("msg", OracleType.VarChar, 100)
            op(5).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("tt_toho", op)
            Dim rh As New ResultHandler
            rh.message = op(5).Value
            rh.status = op(4).Value
            rh.transactionid = op(3).Value
            Return rh
        End Function

        Public Function tt_receive(ByVal fmno As Integer, ByVal brid As Integer, ByVal ttdtl As String) As ResultHandler Implements tt_IDAL.IDAL.Itt.TT_IDAL.tt_receive
            Dim op(5) As OracleParameter
            op(0) = New OracleParameter("fmno", OracleType.Number, 5)
            op(0).Value = CInt(fmno)
            op(0).Direction = ParameterDirection.Input
            op(1) = New OracleParameter("brno", OracleType.Number, 3)
            op(1).Value = CInt(brid)
            op(1).Direction = ParameterDirection.Input
            op(2) = New OracleParameter("ttdtls", OracleType.VarChar, 500)
            op(2).Value = ttdtl
            op(2).Direction = ParameterDirection.Input
            op(3) = New OracleParameter("trans_no", OracleType.Number, 8)
            op(3).Direction = ParameterDirection.Output
            op(4) = New OracleParameter("errstat", OracleType.Number, 3)
            op(4).Direction = ParameterDirection.Output
            op(5) = New OracleParameter("msg", OracleType.VarChar, 100)
            op(5).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("tt_receive", op)
            Dim rh As New ResultHandler
            rh.message = op(5).Value
            rh.status = op(4).Value
            rh.transactionid = op(3).Value
            Return rh
        End Function
        Public Function tt_nearbr(ByVal brid As Integer, ByVal detail As String) As String Implements tt_IDAL.IDAL.Itt.TT_IDAL.tt_nearbr
            Dim msg As String
            Try
                Dim parameters(2) As OracleParameter
                parameters(0) = New OracleParameter("brno", OracleType.Number, 5)
                parameters(0).Value = brid
                parameters(0).Direction = ParameterDirection.Input
                parameters(1) = New OracleParameter("details", OracleType.VarChar, 10000)
                parameters(1).Value = detail
                parameters(1).Direction = ParameterDirection.Input
                parameters(2) = New OracleParameter("reqmsg", OracleType.VarChar, 300)
                parameters(2).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("tt_nearest_br", parameters)
                msg = parameters(2).Value
            Catch ex As Exception
                msg = ex.ToString
            End Try
            Return msg
        End Function

        Public Function tt_nearbr_verify(ByVal detail As String) As String Implements tt_IDAL.IDAL.Itt.TT_IDAL.tt_nearbr_verify
            Dim msg, input() As String
            Try
                input = detail.Split("©")
                Dim parameters(2) As OracleParameter
                parameters(1) = New OracleParameter("details", OracleType.VarChar, 10000)
                parameters(1).Value = input(0)
                parameters(1).Direction = ParameterDirection.Input
                parameters(0) = New OracleParameter("userid", OracleType.VarChar, 25)
                parameters(0).Value = input(1)
                parameters(0).Direction = ParameterDirection.Input
                parameters(2) = New OracleParameter("reqmsg", OracleType.VarChar, 300)
                parameters(2).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("tt_nearest_br_verify", parameters)
                msg = parameters(2).Value
            Catch ex As Exception
                msg = ex.ToString
            End Try
            Return msg
        End Function
        Public Function tt_add_update_bank(ByVal fmno As Integer, ByVal brid As Integer, ByVal bankdtl As String) As String Implements tt_IDAL.IDAL.Itt.TT_IDAL.tt_add_update_bank
            Dim msg As String
            Try
                Dim parameters(3) As OracleParameter
                parameters(0) = New OracleParameter("fmno", OracleType.Number, 3)
                parameters(0).Value = fmno
                parameters(0).Direction = ParameterDirection.Input
                parameters(1) = New OracleParameter("brno", OracleType.Number, 5)
                parameters(1).Value = brid
                parameters(1).Direction = ParameterDirection.Input
                parameters(2) = New OracleParameter("details", OracleType.VarChar, 10000)
                parameters(2).Value = bankdtl
                parameters(2).Direction = ParameterDirection.Input
                parameters(3) = New OracleParameter("reqmsg", OracleType.VarChar, 300)
                parameters(3).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("tt_add_update_bank", parameters)
                msg = parameters(3).Value
            Catch ex As Exception
                msg = ex.ToString
            End Try
            Return msg
        End Function
        Public Function tt_add_update_location_dtls(ByVal brid As Integer, ByVal bankdtl As String) As String Implements tt_IDAL.IDAL.Itt.TT_IDAL.tt_add_update_location_dtls
            Dim msg As String
            Try
                Dim parameters(3) As OracleParameter
                parameters(0) = New OracleParameter("branch", OracleType.Number, 3)
                parameters(0).Value = brid
                parameters(0).Direction = ParameterDirection.Input
                parameters(1) = New OracleParameter("dtls", OracleType.VarChar, 5000)
                parameters(1).Value = bankdtl
                parameters(1).Direction = ParameterDirection.Input
                parameters(2) = New OracleParameter("flag", OracleType.Number, 3)
                parameters(2).Direction = ParameterDirection.Output
                parameters(3) = New OracleParameter("msg", OracleType.VarChar, 300)
                parameters(3).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("tt_add_update_location_dtl", parameters)
                msg = parameters(3).Value
            Catch ex As Exception
                msg = ex.ToString
            End Try
            Return msg
        End Function

        Public Function tt_add_location(ByVal location As String) As String Implements tt_IDAL.IDAL.Itt.TT_IDAL.tt_add_location
            Dim msg As String
            Try
                Dim parameters(2) As OracleParameter
                parameters(0) = New OracleParameter("location_nm", OracleType.VarChar, 70)
                parameters(0).Value = location
                parameters(0).Direction = ParameterDirection.Input
                parameters(1) = New OracleParameter("flag", OracleType.Number, 5)
                parameters(1).Direction = ParameterDirection.Output
                parameters(2) = New OracleParameter("msg", OracleType.VarChar, 150)
                parameters(2).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("tt_add_location", parameters)
                msg = parameters(2).Value
            Catch ex As Exception
                msg = ex.ToString
            End Try
            Return msg
        End Function
    End Class
End Namespace
