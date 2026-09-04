Imports Microsoft.VisualBasic
Imports System.Data.OracleClient
Imports System.Data
'Imports IBankRecon.IDAL
Namespace BankRecon.DAL
    Public Class BankRecon
        Implements IBankRecon.IDAL.IBankRecon
        Dim OH As New Helper.Oracle.OracleHelper
        Dim DT As New DataTable
        Dim OutputMessage As String
        Public Function AnnexureUpdate(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal BankAccount As String, ByVal CutoffDate As Date, ByVal PassbookBalance As Double, ByVal Annexure1 As String, ByVal OtherCharges As String, ByVal Annexure2 As String, ByVal Annexure3 As String, ByVal Annexure4 As String, ByVal UserID As String) As String Implements IBankRecon.IDAL.IBankRecon.AnnexureUpdate
            Try
                Dim BankDtl() As String = BankAccount.ToString.Split("~")
                Dim ParentAccount As Integer = CInt(BankDtl(0))
                Dim SubAccount As Integer = CInt(BankDtl(1))
                Dim Params(12) As OracleParameter
                Params(0) = New OracleParameter("BranchID", OracleType.Number, 4)
                Params(0).Value = BranchID
                Params(0).Direction = ParameterDirection.Input
                Params(1) = New OracleParameter("FirmID", OracleType.Number, 2)
                Params(1).Value = FirmID
                Params(1).Direction = ParameterDirection.Input
                Params(2) = New OracleParameter("ParentAcc", OracleType.Number, 6)
                Params(2).Value = ParentAccount
                Params(2).Direction = ParameterDirection.Input
                Params(3) = New OracleParameter("SubAcc", OracleType.Number, 6)
                Params(3).Value = SubAccount
                Params(3).Direction = ParameterDirection.Input
                Params(4) = New OracleParameter("CutoffDate", OracleType.DateTime)
                Params(4).Value = CutoffDate
                Params(4).Direction = ParameterDirection.Input
                Params(5) = New OracleParameter("PBBalance", OracleType.Number, 11, 2)
                Params(5).Value = PassbookBalance
                Params(5).Direction = ParameterDirection.Input
                Params(6) = New OracleParameter("Anx0", OracleType.VarChar, 5000)
                Params(6).Value = OtherCharges
                Params(6).Direction = ParameterDirection.Input
                Params(7) = New OracleParameter("Anx1", OracleType.VarChar, 5000)
                Params(7).Value = Annexure1
                Params(7).Direction = ParameterDirection.Input
                Params(8) = New OracleParameter("Anx2", OracleType.VarChar, 5000)
                Params(8).Value = Annexure2
                Params(8).Direction = ParameterDirection.Input
                Params(9) = New OracleParameter("Anx3", OracleType.VarChar, 5000)
                Params(9).Value = Annexure3
                Params(9).Direction = ParameterDirection.Input
                Params(10) = New OracleParameter("Anx4", OracleType.VarChar, 5000)
                Params(10).Value = Annexure4
                Params(10).Direction = ParameterDirection.Input
                Params(11) = New OracleParameter("UserID", OracleType.VarChar, 50)
                Params(11).Value = UserID
                Params(11).Direction = ParameterDirection.Input
                Params(12) = New OracleParameter("ErrorMsg", OracleType.VarChar, 1000)
                Params(12).Direction = ParameterDirection.Output
                OH.ExecuteNonQuery("STP_RECON_ANX_UPDATE", Params)
                OutputMessage = Params(12).Value.ToString
            Catch ex As Exception
                OutputMessage = ex.Message.ToString
            Finally
                OH.dispose()
                DT.Dispose()
            End Try
            Return OutputMessage
        End Function
        Public Function ChequeBookUpdate(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal ParentAccount As Integer, ByVal SubAccount As Integer, ByVal ReceiptDate As Date, ByVal SerialFrom As String, ByVal SerialTo As String, ByVal Count As Integer, ByVal UserID As String) As String Implements IBankRecon.IDAL.IBankRecon.ChequeBookUpdate
            '--//-- Last Modified By -- John Paul 
            '--//-- Last Modified On -- 28-Aug-2008
            Try
                Dim Params(9) As OracleParameter
                Params(0) = New OracleParameter("firmId", OracleType.Number, 3)
                Params(0).Value = FirmID
                Params(1) = New OracleParameter("branchId", OracleType.Number, 4)
                Params(1).Value = BranchID
                Params(2) = New OracleParameter("pAcnt", OracleType.Number, 7)
                Params(2).Value = ParentAccount
                Params(3) = New OracleParameter("sAcnt", OracleType.Number, 7)
                Params(3).Value = SubAccount
                Params(4) = New OracleParameter("receiptDt", OracleType.DateTime)
                Params(4).Value = ReceiptDate
                Params(5) = New OracleParameter("serialFrom", OracleType.VarChar, 25)
                Params(5).Value = SerialFrom
                Params(6) = New OracleParameter("serialTo", OracleType.VarChar, 25)
                Params(6).Value = SerialTo
                Params(7) = New OracleParameter("totalNo", OracleType.Number, 10)
                Params(7).Value = Count
                Params(8) = New OracleParameter("flg", OracleType.Number, 2)
                Params(8).Direction = ParameterDirection.Output
                Params(9) = New OracleParameter("errMsg", OracleType.LongVarChar, 500)
                Params(9).Direction = ParameterDirection.Output
                OH.ExecuteNonQuery("STP_RECON_ADD_LEAVES", Params)
                OutputMessage = (Params(8).Value.ToString) + "^" + (Params(9).Value).ToString
            Catch ex As Exception
                OutputMessage = "1^" + (ex.Message.ToString)
            Finally
                OH.dispose()
                DT.Dispose()
            End Try
            Return OutputMessage
        End Function
        Public Function ChequeIssue(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal ParentAccount As Integer, ByVal SubAccount As Integer, ByVal ChequeNumber As String, ByVal ChequeDate As Date, ByVal ChequeAmount As Double, ByVal PaidFor As String, ByVal PaidTo As String, ByVal Remarks As String, ByVal Signatory1 As Integer, ByVal Signatory2 As Integer, ByVal UserID As String, ByVal OptionID As Integer) As String Implements IBankRecon.IDAL.IBankRecon.ChequeIssue
            '--//-- Last Modified By -- PremSankar 
            '--//-- Last Modified On -- 28-Aug-2008
            Try
                Dim Params(15) As OracleParameter
                Params(0) = New OracleParameter("FirmID", OracleType.Number, 2)
                Params(0).Value = FirmID
                Params(0).Direction = ParameterDirection.Input
                Params(1) = New OracleParameter("BranchID", OracleType.Number, 4)
                Params(1).Value = BranchID
                Params(1).Direction = ParameterDirection.Input
                Params(2) = New OracleParameter("MainAccount", OracleType.Number, 6)
                Params(2).Value = ParentAccount
                Params(2).Direction = ParameterDirection.Input
                Params(3) = New OracleParameter("SubAccount", OracleType.Number, 6)
                Params(3).Value = SubAccount
                Params(3).Direction = ParameterDirection.Input
                Params(4) = New OracleParameter("ChequeNo", OracleType.VarChar, 20)
                Params(4).Value = ChequeNumber
                Params(4).Direction = ParameterDirection.Input
                Params(5) = New OracleParameter("ChequeDate", OracleType.DateTime)
                Params(5).Value = ChequeDate
                Params(5).Direction = ParameterDirection.Input
                Params(6) = New OracleParameter("ChequeAmount", OracleType.Double, 11)
                Params(6).Value = ChequeAmount
                Params(6).Direction = ParameterDirection.Input
                Params(7) = New OracleParameter("PaidFor", OracleType.VarChar, 50)
                Params(7).Value = PaidFor
                Params(7).Direction = ParameterDirection.Input
                Params(8) = New OracleParameter("PaidTo", OracleType.VarChar, 50)
                Params(8).Value = PaidTo
                Params(8).Direction = ParameterDirection.Input
                Params(9) = New OracleParameter("Remark", OracleType.VarChar, 100)
                Params(9).Value = Remarks
                Params(9).Direction = ParameterDirection.Input
                Params(10) = New OracleParameter("UserID", OracleType.VarChar, 30)
                Params(10).Value = UserID
                Params(10).Direction = ParameterDirection.Input
                Params(11) = New OracleParameter("Sign1", OracleType.Number, 5)
                Params(11).Value = Signatory1
                Params(11).Direction = ParameterDirection.Input
                Params(12) = New OracleParameter("Sign2", OracleType.Number, 5)
                Params(12).Value = Signatory2
                Params(12).Direction = ParameterDirection.Input
                Params(13) = New OracleParameter("Flag", OracleType.Number, 2)
                Params(13).Direction = ParameterDirection.Output
                Params(14) = New OracleParameter("FormID", OracleType.Number, 2)
                Params(14).Value = OptionID
                Params(14).Direction = ParameterDirection.Input
                '--1 -old 2 - new 0 -cancel
                Params(15) = New OracleParameter("ErrorMsg", OracleType.VarChar, 150)
                Params(15).Direction = ParameterDirection.Output
                OH.ExecuteNonQuery("STP_RECON_CHEQUE_ISSUE", Params)
                OutputMessage = Params(13).Value.ToString + "^" + Params(15).Value.ToString
            Catch ex As Exception
                OutputMessage = "1" + ex.Message.ToString
            Finally
                OH.dispose()
                DT.Dispose()
            End Try
            Return OutputMessage
        End Function
        Public Function ModifyChequeIssue(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal ParentAccount As Integer, ByVal SubAccount As Integer, ByVal ChequeNumber As String, ByVal ChequeDate As Date, ByVal UserID As String) As String Implements IBankRecon.IDAL.IBankRecon.ModifyChequeIssue
            '--//-- Last Modified By -- John Paul 
            '--//-- Last Modified On -- 28-Aug-2008
            Try
                Dim Params(8) As OracleParameter
                Params(0) = New OracleParameter("branchId", OracleType.Number, 4)
                Params(0).Value = BranchID
                Params(1) = New OracleParameter("firmId", OracleType.Number, 2)
                Params(1).Value = FirmID
                Params(2) = New OracleParameter("pAcnt", OracleType.Number, 6)
                Params(2).Value = ParentAccount
                Params(3) = New OracleParameter("sAcnt", OracleType.Number, 6)
                Params(3).Value = SubAccount
                Params(4) = New OracleParameter("cheqNo", OracleType.Number, 20)
                Params(4).Value = ChequeNumber
                Params(5) = New OracleParameter("cheqDt", OracleType.DateTime)
                Params(5).Value = ChequeDate
                Params(6) = New OracleParameter("userInfo", OracleType.VarChar, 30)
                Params(6).Value = UserID
                Params(7) = New OracleParameter("errFlg", OracleType.Number, 1)
                Params(7).Direction = ParameterDirection.Output
                Params(8) = New OracleParameter("errMsg", OracleType.LongVarChar, 200)
                Params(8).Direction = ParameterDirection.Output
                OH.ExecuteDataSet("STP_RECON_MODIFY_ISSUE", Params)
                OutputMessage = Params(7).Value.ToString + "^" + Params(8).Value.ToString
            Catch ex As Exception
                OutputMessage = "1^" + ex.Message.ToString
            Finally
                OH.dispose()
                DT.Dispose()
            End Try
            Return OutputMessage
        End Function
        Public Function FillCheque(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal BankAccount As String, ByVal OICType As String, ByVal ShowDetails As Boolean) As System.Data.DataTable Implements IBankRecon.IDAL.IBankRecon.FillCheque
            Try
                DT = OH.ExecuteDataSet(OICType).Tables(0)
                Return DT
            Catch ex As Exception
            Finally
                OH.dispose()
                DT.Dispose()
            End Try
        End Function
        Public Function LedgerBalance(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal BankAccount As String, ByVal CutoffDate As Date) As Double Implements IBankRecon.IDAL.IBankRecon.LedgerBalance
            Try
                Dim BankDtl() As String = BankAccount.Split("~")
                Dim ParentAccount As Integer = CInt(BankDtl(0))
                Dim SubAccount As Integer = CInt(BankDtl(1))
                If ParentAccount = 32100 And SubAccount <> 0 Then
                    DT = OH.ExecuteDataSet("select nvl(sum(decode(type,'D',amount,-1*amount)),0) from full_sub_transaction where branch_id = " & BranchID & " and firm_id = " & FirmID & " and parent_acc = 32100 and account_no = " & SubAccount & " and amount <> 0 and to_date(tra_dt) <= '" & Format(CutoffDate, "dd-MMM-yyyy") & "'").Tables(0)
                Else
                    DT = OH.ExecuteDataSet("select nvl(sum(decode(type,'D',amount,-1*amount)),0) from full_transaction_all where branch_id = " & BranchID & " and firm_id = " & FirmID & " and account_no = " & ParentAccount & " and amount <> 0 and tra_dt <= '" & Format(CutoffDate, "dd-MMM-yyyy") & "'").Tables(0)
                End If
                Return CDbl(DT.Rows(0)(0))
            Catch ex As Exception
            Finally
                OH.dispose()
                DT.Dispose()
            End Try
        End Function
        Public Function FillChequeDetails(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal ParentAccount As Integer, ByVal SubAccount As Integer, ByVal ChequeNumber As String) As System.Data.DataTable Implements IBankRecon.IDAL.IBankRecon.FillChequeDetails
            Try
                DT = OH.ExecuteDataSet("select TRA_DT,AMOUNT,PAID_FOR,PAID_TO,REMARKS,ATH_SIG1,ATH_SIG2,CHEQUE_DT,ENTERED_BY,UPDATED_BY from TBL_RECON_CHEQUE_LEAF_MST where branch_id = " & BranchID & " and firm_id = " & FirmID & " and main_acc = " & ParentAccount & " and sub_acc = " & SubAccount & " and cheque_no=" & ChequeNumber & " and status in ('I')").Tables(0)
                Return DT
            Catch ex As Exception
            Finally
                OH.dispose()
                DT.Dispose()
            End Try
        End Function
        Public Function GetChequeOpeningBalance(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal ParentAccount As Integer, ByVal SubAccount As Integer) As System.Data.DataTable Implements IBankRecon.IDAL.IBankRecon.GetChequeOpeningBalance
            Try
                DT = OH.ExecuteDataSet("select nvl(sum(total-paid),0) from tbl_recon_cheque_book_mst where branch_id=" & BranchID & " and firm_id=" & FirmID & " and main_acc=" & ParentAccount & " and sub_acc=" & SubAccount & "").Tables(0)
                Return DT
            Catch ex As Exception
            Finally
                OH.dispose()
                DT.Dispose()
            End Try
        End Function
    End Class
End Namespace