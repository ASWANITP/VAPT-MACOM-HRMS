Imports Microsoft.VisualBasic
Imports System.Data.OracleClient
Imports System.Data

Namespace IBankRecon.IDAL

    Public Interface IBankRecon
        Function GetChequeOpeningBalance(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal ParentAccount As Integer, ByVal SubAccount As Integer) As DataTable
        Function FillChequeDetails(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal ParentAccount As Integer, ByVal SubAccount As Integer, ByVal ChequeNumber As String) As DataTable
        Function FillCheque(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal BankAccount As String, ByVal OICType As String, ByVal ShowDetails As Boolean) As DataTable
        Function LedgerBalance(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal BankAccount As String, ByVal CutoffDate As Date) As Double
        Function ChequeBookUpdate(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal ParentAccount As Integer, ByVal SubAccount As Integer, ByVal ReceiptDate As Date, ByVal SerialFrom As String, ByVal SerialTo As String, ByVal Count As Integer, ByVal UserID As String) As String
        Function ChequeIssue(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal ParentAccount As Integer, ByVal SubAccount As Integer, ByVal ChequeNumber As String, ByVal ChequeDate As Date, ByVal ChequeAmount As Double, ByVal PaidFor As String, ByVal PaidTo As String, ByVal Remarks As String, ByVal Signatory1 As Integer, ByVal Signatory2 As Integer, ByVal UserID As String, ByVal OptionID As Integer) As String
        Function ModifyChequeIssue(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal ParentAccount As Integer, ByVal SubAccount As Integer, ByVal ChequeNumber As String, ByVal ChequeDate As Date, ByVal UserID As String) As String
        Function AnnexureUpdate(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal BankAccount As String, ByVal CutoffDate As Date, ByVal PassbookBalance As Double, ByVal Annexure1 As String, ByVal OtherCharges As String, ByVal Annexure2 As String, ByVal Annexure3 As String, ByVal Annexure4 As String, ByVal UserID As String) As String
    End Interface

End Namespace