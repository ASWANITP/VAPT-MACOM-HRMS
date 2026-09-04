Imports Microsoft.VisualBasic
Imports System.Data
Namespace TDS_IDAL
    Public Class ITDS
        Public Interface TDS_INT
            Function tds_confirm(ByVal tid As Integer, ByVal str As String) As String 'Add Eligible Employee,Add Salary Details,Add other TDS Details,TDS Deposited,Tds Deduction Request,TDS_Acknowledgement
            Function fill_data(ByVal id As Integer) As DataTable 'Add Salary Details-Fill Combo Employee-Fill Combo Month,Add other TDS Details:-Fill Employee-Fill month,Add other TDS Details-Fill Combo category-Fill Combo type,TDS Deposited-Fill Data,Tds Deduction Request-fill Details-fill month,TDS_calculator-fill Details
            Function fill_data_new(ByVal id As Integer, ByVal firm As Integer) As DataTable
            'function fill_mon() as DataTable 'Add Salary Details-Fill Combo Month,Add other TDS Details:-Fill month
            '    ' Add Eligible Employee
            'Function valid_emp(ByVal emp_id As Integer) As String
            '    'Add Salary Details
            Function emp_dtl(ByVal emp_id As Integer, ByVal month As String) As String 'fill employee Details
            '    'Add other TDS Details
            'function fill_cat() as DataTable 'Fill Combo category
            'function fill_type() as DataTable 'Fill Combo type
            '    'TDS Deposited
            'function fill_cat() as DataTable
            'Tds Deduction Report
            Function tds_other_type_fill(ByVal id As Integer, ByVal category_id As Integer) As DataTable
            Function tds_disp(ByVal id As Integer, ByVal emp_id As String) As String 'fill tds Details
            Function tds_exp(ByVal id As Integer, ByVal emp_id As Integer, ByVal amount As Double) As String
            Function tds_rep(ByVal id As Integer, ByVal emp_id As Integer, ByVal month As String) As DataTable
        End Interface
    End Class
End Namespace
