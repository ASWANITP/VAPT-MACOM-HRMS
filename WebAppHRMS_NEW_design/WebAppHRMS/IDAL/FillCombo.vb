Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OracleClient

Public Class FillCombo
    Dim OH As New Helper.Oracle.OracleHelper
    Dim DT As New DataTable
    Public Function comboFill(ByVal query As String) As DataTable
        DT = OH.ExecuteDataSet(query).Tables(0)
        Return DT
    End Function
End Class

