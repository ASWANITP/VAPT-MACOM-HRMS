Imports Microsoft.VisualBasic
Imports system.Data
Imports System.Data.OracleClient
Namespace AddNewItem.IDAL
    Public Interface AddNewItem
        Function NewItemConfirm(ByVal departmentid As Integer, ByVal item As String) As ResultHandler
    End Interface
End Namespace
