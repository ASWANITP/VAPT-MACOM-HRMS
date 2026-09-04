Imports Microsoft.VisualBasic
Imports system.Data
Imports System.Data.OracleClient
Namespace Payment.IDAL
    Public Interface Payment
        Function PaymentConfirm(ByVal firmid As Integer, ByVal departmentId As Integer, ByVal paymentDtl As String, ByVal companyid As Integer, ByVal tdsAmount As Double, ByVal description As String, ByVal payMode As String, ByVal employeeCode As Integer, ByVal serviceTax As Double, ByVal salesTax As Double, ByVal payAmount As Double, ByVal chequeNo As String, ByVal chequeDate As Date, ByVal bankName As String, ByVal ddComm As Double, ByVal userid As String, ByVal branchId As Integer, ByVal sanctionId1 As Integer, ByVal payDtl1 As String, ByVal bankAcc1 As Integer, ByVal account As Integer, ByVal brstat As Integer) As ResultHandler
    End Interface
End Namespace

