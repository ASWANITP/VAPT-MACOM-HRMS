Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OracleClient
Namespace AddClient.IDAL
    Public Interface AddClient
        Function ClientConfirm(ByVal companyName As String, ByVal address As String, ByVal pin As Integer, ByVal panNo As String, ByVal taxNo As String, ByVal contactNo As String, ByVal contactPerson As String) As ResultHandler
    End Interface
End Namespace
