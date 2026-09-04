Imports Microsoft.VisualBasic
Imports system.Data
Imports System.Data.OracleClient
Namespace AddSubCategory.IDAL
    Public Interface AddSubCategory
        Function SubCategoryConfirm(ByVal firmid As Integer, ByVal expenseId As Integer, ByVal subcategory As String, ByVal accountNo As Integer) As ResultHandler
    End Interface
End Namespace
