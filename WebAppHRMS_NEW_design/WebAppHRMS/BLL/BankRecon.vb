Imports Microsoft.VisualBasic
Imports System.Data
'Imports BankRecon.DAL
Namespace BankRecon.BLL

    Public Class BRS
        Dim BR As New BankRecon.DAL.BankRecon
        Function GetChequeOpeningBalance(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal ParentAccount As Integer, ByVal SubAccount As Integer) As DataTable
            Return BR.GetChequeOpeningBalance(BranchID, FirmID, ParentAccount, SubAccount)
        End Function
        Function FillChequeDetails(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal ParentAccount As Integer, ByVal SubAccount As Integer, ByVal ChequeNumber As String) As DataTable
            Return BR.FillChequeDetails(BranchID, FirmID, ParentAccount, SubAccount, ChequeNumber)
        End Function
        Function FillCheque(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal BankAccount As String, ByVal OICType As String, ByVal ShowDetails As Boolean) As DataTable
            Dim BankDtl() As String = BankAccount.Split("~")
            Dim ParentAccount As Integer = CInt(BankDtl(0))
            Dim SubAccount As Integer = CInt(BankDtl(1))
            Dim SQL As String = ""
            If ShowDetails = True Then
                SQL = "select 'CHQ.No--'||cheque_no||'--('||to_char(cheque_dt)||')',cheque_no||'^'||cheque_dt from TBL_RECON_CHEQUE_LEAF_MST where status='I' and firm_id=" & FirmID & " and branch_id=" & BranchID & " and main_acc=" & ParentAccount & " and sub_acc=" & SubAccount & " order by cheque_no"
            Else
                Select Case OICType
                    Case "O"
                        SQL = "select cheque_no,cheque_no from TBL_RECON_CHEQUE_LEAF_MST where branch_id = " & BranchID & " and firm_id = " & FirmID & " and main_acc = " & ParentAccount & " and sub_acc = " & SubAccount & " and status in ('O')"
                    Case "I"
                        SQL = "select cheque_no,cheque_no from TBL_RECON_CHEQUE_LEAF_MST where branch_id = " & BranchID & " and firm_id = " & FirmID & " and main_acc = " & ParentAccount & " and sub_acc = " & SubAccount & " and status in ('I')"
                    Case "C"
                        SQL = "select cheque_no,cheque_no from TBL_RECON_CHEQUE_LEAF_MST where branch_id = " & BranchID & " and firm_id = " & FirmID & " and main_acc = " & ParentAccount & " and sub_acc = " & SubAccount & " and status in ('C')"
                    Case "OI", "IO"
                        SQL = "select cheque_no,cheque_no from TBL_RECON_CHEQUE_LEAF_MST where branch_id = " & BranchID & " and firm_id = " & FirmID & " and main_acc = " & ParentAccount & " and sub_acc = " & SubAccount & " and status in ('O','I')"
                    Case "OC", "OI"
                        SQL = "select cheque_no,cheque_no from TBL_RECON_CHEQUE_LEAF_MST where branch_id = " & BranchID & " and firm_id = " & FirmID & " and main_acc = " & ParentAccount & " and sub_acc = " & SubAccount & " and status in ('O','C')"
                    Case "IC", "CI"
                        SQL = "select cheque_no,cheque_no from TBL_RECON_CHEQUE_LEAF_MST where branch_id = " & BranchID & " and firm_id = " & FirmID & " and main_acc = " & ParentAccount & " and sub_acc = " & SubAccount & " and status in ('I','C')"
                    Case "OIC", "ALL"
                        SQL = "select cheque_no,cheque_no from TBL_RECON_CHEQUE_LEAF_MST where branch_id = " & BranchID & " and firm_id = " & FirmID & " and main_acc = " & ParentAccount & " and sub_acc = " & SubAccount & " and status in ('O','I','C')"
                End Select
            End If
            Return BR.FillCheque(BranchID, FirmID, BankAccount, SQL, ShowDetails)
        End Function
        Function FillCheque1(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal BankAccount As String, ByVal OICType As String, ByVal ShowDetails As Boolean) As DataTable
            Dim BankDtl() As String = BankAccount.Split("~")
            Dim ParentAccount As Integer = CInt(BankDtl(0))
            Dim SubAccount As Integer = CInt(BankDtl(1))
            Dim SQL As String = ""
            If ShowDetails = True Then
                SQL = "select 'CHQ.No--'||cheque_no||'--('||to_char(cheque_dt)||')',cheque_no||'^'||cheque_dt from TBL_RECON_CHEQUE_LEAF_MST where status='I' and firm_id=" & FirmID & " and branch_id=" & BranchID & " and main_acc=" & ParentAccount & " and sub_acc=" & SubAccount & " order by cheque_no"
            Else
                Select Case OICType
                    Case "O"
                        SQL = "select cheque_no,cheque_no from TBL_RECON_CHEQUE_LEAF_MST where branch_id = " & BranchID & " and firm_id = " & FirmID & " and main_acc = " & ParentAccount & " and sub_acc = " & SubAccount & " and status in ('O')"
                    Case "I"
                        SQL = "select cheque_no,cheque_no from TBL_RECON_CHEQUE_LEAF_MST where branch_id = " & BranchID & " and firm_id = " & FirmID & " and main_acc = " & ParentAccount & " and sub_acc = " & SubAccount & " and status in ('I')"
                    Case "C"
                        SQL = "select cheque_no,cheque_no from TBL_RECON_CHEQUE_LEAF_MST where branch_id = " & BranchID & " and firm_id = " & FirmID & " and main_acc = " & ParentAccount & " and sub_acc = " & SubAccount & " and status in ('C')"
                    Case "OI", "IO"
                        SQL = "select cheque_no,cheque_no from TBL_RECON_CHEQUE_LEAF_MST where branch_id = " & BranchID & " and firm_id = " & FirmID & " and main_acc = " & ParentAccount & " and sub_acc = " & SubAccount & " and status in ('O','I')"
                    Case "OC", "OI"
                        SQL = "select cheque_no,cheque_no from TBL_RECON_CHEQUE_LEAF_MST where branch_id = " & BranchID & " and firm_id = " & FirmID & " and main_acc = " & ParentAccount & " and sub_acc = " & SubAccount & " and status in ('O','C')"
                    Case "IC", "CI"
                        SQL = "select cheque_no,cheque_no from TBL_RECON_CHEQUE_LEAF_MST where branch_id = " & BranchID & " and firm_id = " & FirmID & " and main_acc = " & ParentAccount & " and sub_acc = " & SubAccount & " and status in ('I','C')"
                    Case "OIC", "ALL"
                        SQL = "select cheque_no,cheque_no from TBL_RECON_CHEQUE_LEAF_MST where branch_id = " & BranchID & " and firm_id = " & FirmID & " and main_acc = " & ParentAccount & " and sub_acc = " & SubAccount & " and status in ('O','I','C')"
                End Select
            End If
            Return BR.FillCheque(BranchID, FirmID, BankAccount, SQL, ShowDetails)
        End Function

        Function LedgerBalance(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal BankAccount As String, ByVal CutoffDate As Date) As Double
            Return BR.LedgerBalance(BranchID, FirmID, BankAccount, CutoffDate)
        End Function
        Function ChequeBookUpdate(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal ParentAccount As Integer, ByVal SubAccount As Integer, ByVal ReceiptDate As Date, ByVal SerialFrom As String, ByVal SerialTo As String, ByVal Count As Integer, ByVal UserID As String) As String
            Return BR.ChequeBookUpdate(BranchID, FirmID, ParentAccount, SubAccount, ReceiptDate, SerialFrom, SerialTo, Count, UserID)
        End Function
        Function ChequeIssue(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal ParentAccount As Integer, ByVal SubAccount As Integer, ByVal ChequeNumber As String, ByVal ChequeDate As Date, ByVal ChequeAmount As Double, ByVal PaidFor As String, ByVal PaidTo As String, ByVal Remarks As String, ByVal Signatory1 As Integer, ByVal Signatory2 As Integer, ByVal UserID As String, ByVal OptionID As Integer) As String
            Return BR.ChequeIssue(BranchID, FirmID, ParentAccount, SubAccount, ChequeNumber, ChequeDate, ChequeAmount, PaidFor, PaidTo, Remarks, Signatory1, Signatory2, UserID, OptionID)
        End Function
        Function ModifyChequeIssue(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal ParentAccount As Integer, ByVal SubAccount As Integer, ByVal ChequeNumber As String, ByVal ChequeDate As Date, ByVal UserID As String) As String
            Return BR.ModifyChequeIssue(BranchID, FirmID, ParentAccount, SubAccount, ChequeNumber, ChequeDate, UserID)
        End Function
        Function AnnexureUpdate(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal BankAccount As String, ByVal CutoffDate As Date, ByVal PassbookBalance As Double, ByVal Annexure1 As String, ByVal OtherCharges As String, ByVal Annexure2 As String, ByVal Annexure3 As String, ByVal Annexure4 As String, ByVal UserID As String) As String
            Return BR.AnnexureUpdate(BranchID, FirmID, BankAccount, CutoffDate, PassbookBalance, Annexure1, OtherCharges, Annexure2, Annexure3, Annexure4, UserID)
        End Function
        Function Dispose()
            Me.Finalize()
        End Function
    End Class
End Namespace