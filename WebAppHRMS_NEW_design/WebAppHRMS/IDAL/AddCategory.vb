Imports Microsoft.VisualBasic
Namespace AddCategory.IDAL
    Public Interface AddCategory
        'Function comboFill(ByVal cmbName As String, ByVal query As String)
        Function CategoryConfirm(ByVal firmid As Integer, ByVal expense As String, ByVal acountNo As Integer, ByVal statusId As Char) As ResultHandler
    End Interface
End Namespace
