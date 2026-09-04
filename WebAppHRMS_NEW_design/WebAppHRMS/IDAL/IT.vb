Imports Microsoft.VisualBasic
Imports System.Data.OracleClient
Imports System.Data
Namespace IT.IDAL
    Public Interface ICommon
        Function FillBranch() As DataTable
        Function FillBank(ByVal BranchID As Integer, ByVal FirmID As Integer) As DataTable
        Function FillSignatory(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal ParentAccount As Integer, ByVal SubAccount As Integer) As DataTable
        Function FillState() As DataTable
        Function FillDistrict(ByVal StateID As Integer) As DataTable
        Function FillPost(ByVal DistrictID As Integer) As DataTable
        Function FillCommonBank() As DataTable
        Function FillActiveFirms(ByVal BranchID As Integer) As DataTable
        Function FillFundTransferFirms(ByVal BranchID As Integer, ByVal FirmID As Integer) As DataTable
        Function CheckAccess(ByVal FormID As Integer, ByVal EmpID As Integer) As DataTable
        Function MabenCheckAccess(ByVal FormID As Integer, ByVal EmpID As Integer, ByVal BranchID As Integer) As DataTable
        Function FillStateupd() As DataTable
        Function FillDistrictupd(ByVal StateID As Integer) As DataTable
        Function FillPostupd(ByVal DistrictID As Integer) As DataTable
        Function FillPincode(ByVal postid As Integer) As DataTable
    End Interface
    Public Class ResultHandler
        Dim transactionNo As Integer
        Dim errStatus As Integer
        Dim errMessage As String
        Public Property transactionid() As Integer
            Get
                Return transactionNo
            End Get
            Set(ByVal value As Integer)
                transactionNo = value
            End Set
        End Property
        Public Property status() As Integer
            Get
                Return errStatus
            End Get
            Set(ByVal value As Integer)
                errStatus = value
            End Set
        End Property
        Public Property message() As String
            Get
                Return errMessage
            End Get
            Set(ByVal value As String)
                errMessage = value
            End Set
        End Property
    End Class

End Namespace