Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OracleClient
Namespace AddSanction.IDAL
    Public Interface AddSanction
        Function sanctionConfirm(ByVal firmid As Integer, ByVal departmentId As Integer, ByVal sanctionDetails As String, ByVal totalAmount As Double, ByVal purpose As String, ByVal sanctionDate As Date, ByVal recommendBy As Integer, ByVal sanctionedBy As Integer, ByVal enteredBy As String, ByVal statusId As Integer) As ResultHandler
    End Interface
End Namespace
