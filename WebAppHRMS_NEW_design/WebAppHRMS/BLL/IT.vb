Imports Microsoft.VisualBasic
Imports System.Data
'Imports IT.DAL
Namespace IT.BLL
    Public Class Common
        Dim ITCom As New IT.DAL.Common
        Function FillBranch() As DataTable
            Return ITCom.FillBranch()
        End Function
        Function FillBank(ByVal BranchID As Integer, ByVal FirmID As Integer) As DataTable
            Return ITCom.FillBank(BranchID, FirmID)
        End Function
        Function FillSignatory(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal ParentAccount As Integer, ByVal SubAccount As Integer) As DataTable
            Return ITCom.FillSignatory(BranchID, FirmID, ParentAccount, SubAccount)
        End Function
        Function CheckAccess(ByVal FormID As Integer, ByVal EmpID As Integer) As DataTable
            Return ITCom.CheckAccess(FormID, EmpID)
        End Function
        Function FillCommonBank() As DataTable
            Return ITCom.FillCommonBank()
        End Function
        Function FillState() As DataTable
            Return ITCom.FillState()
        End Function
        Function FillDistrict(ByVal StateID As Integer) As DataTable
            Return ITCom.FillDistrict(StateID)
        End Function
        Function FillPost(ByVal DistrictID As Integer) As DataTable
            Return ITCom.FillPost(DistrictID)
        End Function
        Function FillActiveFirms(ByVal BranchID As Integer) As DataTable
            Return ITCom.FillActiveFirms(BranchID)
        End Function
        Function FillFundTransferFirms(ByVal BranchID As Integer, ByVal FirmID As Integer) As DataTable
            Return ITCom.FillFundTransferFirms(BranchID, FirmID)
        End Function
        Function Dispose()
            Me.Finalize()
        End Function
        Function FillStateupd() As DataTable
            Return ITCom.FillStateupd()
        End Function

        Function FillDistrictupd(ByVal StateID As Integer) As DataTable
            Return ITCom.FillDistrictupd(StateID)
        End Function

        Function FillPostupd(ByVal DistrictID As Integer) As DataTable
            Return ITCom.FillPostupd(DistrictID)
        End Function

        Function FillPincode(ByVal postid As Integer) As DataTable
            Return ITCom.fillpincode(postid)
        End Function
    End Class
End Namespace