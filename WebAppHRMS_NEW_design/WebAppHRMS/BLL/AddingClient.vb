Imports Microsoft.VisualBasic
Imports DAL.AddingClient
Imports ResultHandler
Namespace BLL
    Public Class AddingClient
        Dim dd As New DAL.AddingClient
        Dim RH As New ResultHandler
        Public Function fillstate(ByVal query As String)
            Return dd.comboFill(query)
        End Function
        Public Function Confirm(ByVal companyName As String, ByVal address As String, ByVal pin As Integer, ByVal panNo As String, ByVal taxNo As String, ByVal contactNo As String, ByVal contactPerson As String)
            'Dim dd1 As New DAL.AddingClient
            Try
                Dim rh1 As New ResultHandler
                rh1 = dd.ClientConfirm(companyName, address, pin, panNo, taxNo, contactNo, contactPerson)
                RH.status = rh1.status
                RH.message = rh1.message
            Catch ex As Exception
                RH.status = 3
                RH.message = ex.Message.ToString()
            End Try
            Return RH
        End Function
        Public Function categoryConfirm(ByVal fmid As Integer, ByVal categoryName As String, ByVal category_no As Integer, ByVal status As String)
            Try
                Dim rh2 As New ResultHandler
                rh2 = dd.CategoryConfirm(fmid, categoryName, category_no, status)
                RH.status = rh2.status
                RH.message = rh2.message
            Catch ex As Exception
                RH.status = 3
                RH.message = ex.Message.ToString()
            End Try
            Return RH
        End Function
        Function SubCategoryConfirm(ByVal firmid As Integer, ByVal expenseId As Integer, ByVal subcategory As String, ByVal accountNo As Integer)
            Try
                Dim rh3 As New ResultHandler
                rh3 = dd.SubCategoryConfirm(firmid, expenseId, subcategory, accountNo)
                RH.status = rh3.status
                RH.message = rh3.message
            Catch ex As Exception
                RH.status = 3
                RH.message = ex.Message.ToString()
            End Try
            Return RH
        End Function
        Function NewItemConfirm(ByVal departmentid As Integer, ByVal item As String)
            Try
                Dim rh4 As New ResultHandler
                rh4 = dd.NewItemConfirm(departmentid, item)
                RH.status = rh4.status
                RH.message = rh4.message
            Catch ex As Exception
                RH.status = 3
                RH.message = ex.Message.ToString()
            End Try
            Return RH
        End Function
        Function sanctionConfirm(ByVal firmid As Integer, ByVal departmentId As Integer, ByVal sanctionDetails As String, ByVal totalAmount As Double, ByVal purpose As String, ByVal sanctionDate As Date, ByVal recommendBy As Integer, ByVal sanctionedBy As Integer, ByVal enteredBy As String, ByVal statusId As Integer)
            Try
                Dim rh5 As New ResultHandler
                rh5 = dd.sanctionConfirm(firmid, departmentId, sanctionDetails, totalAmount, purpose, sanctionDate, recommendBy, sanctionedBy, enteredBy, statusId)
                RH.status = rh5.status
                RH.message = rh5.message
            Catch ex As Exception
                RH.status = 3
                RH.message = ex.Message.ToString()
            End Try
            Return RH
        End Function
        Function PaymentConfirm(ByVal firmid As Integer, ByVal departmentId As Integer, ByVal paymentDtl As String, ByVal companyid As Integer, ByVal tdsAmount As Double, ByVal description As String, ByVal payMode As String, ByVal employeeCode As Integer, ByVal serviceTax As Double, ByVal salesTax As Double, ByVal payAmount As Double, ByVal chequeNo As String, ByVal chequeDate As Date, ByVal bankName As String, ByVal ddComm As Double, ByVal userid As String, ByVal branchId As Integer, ByVal sanctionId1 As Integer, ByVal payDtl1 As String, ByVal bankAcc1 As Integer, ByVal account As Integer, ByVal brstat As Integer)
            Try
                Dim rh6 As New ResultHandler
                If payDtl1 = "CH" Then
                    chequeNo = "C-" & chequeNo
                End If
                If payDtl1 = "DD" Then
                    chequeNo = "D-" & chequeNo
                End If
                'rh6 = dd.PaymentConfirm(firmid,departmentId, paymentDtl, companyid, tdsAmount, description, payMode, employeeCode, serviceTax, salesTax, billNo, payAmount, chequeNo, chequeDate, bankName, ddComm, userid, categoryId, subId)
                rh6 = dd.PaymentConfirm(firmid, departmentId, paymentDtl, companyid, tdsAmount, description, payMode, employeeCode, serviceTax, salesTax, payAmount, chequeNo, chequeDate, bankName, ddComm, userid, branchId, sanctionId1, payDtl1, bankAcc1, account, brstat)
                'PaymentConfirm( firmid  ,  departmentId  ,  paymentDtl  ,  companyid  ,  tdsAmount  ,  description  ,  payMode  ,  employeeCode  ,  serviceTax  ,  salesTax  ,  payAmount  ,  chequeNo  ,  chequeDate,bankName,ddComm,userid,branchId,sanctionId1,payDtl1,bankAcc1,account)
                RH.status = rh6.status
                RH.message = rh6.message
                RH.transactionid = rh6.transactionid
            Catch ex As Exception
                RH.status = 3
                RH.message = ex.Message.ToString()
            End Try
            Return RH
        End Function
    End Class
End Namespace