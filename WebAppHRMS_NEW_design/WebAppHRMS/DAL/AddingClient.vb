Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OracleClient
Imports FillCombo
Namespace DAL
    Public Class AddingClient
        Implements AddClient.IDAL.AddClient
        Implements AddCategory.IDAL.AddCategory
        Implements AddSubCategory.IDAL.AddSubCategory
        Implements AddNewItem.IDAL.AddNewItem
        Implements AddSanction.IDAL.AddSanction
        Implements Payment.IDAL.Payment
        Dim OH As New Helper.Oracle.OracleHelper
        Dim FC As New FillCombo
        Dim RH As New ResultHandler
        Function comboFill(ByVal query As String) As DataTable
            Return FC.comboFill(query)
        End Function

        Public Function ClientConfirm(ByVal companyName As String, ByVal address As String, ByVal pin As Integer, ByVal panNo As String, ByVal taxNo As String, ByVal contactNo As String, ByVal contactPerson As String) As ResultHandler Implements AddClient.IDAL.AddClient.ClientConfirm
            Try

                Dim pr(8) As OracleParameter
                pr(0) = New OracleParameter("companyName1", OracleType.VarChar, 40)
                pr(0).Value = companyName
                pr(0).Direction = ParameterDirection.Input

                pr(1) = New OracleParameter("address1", OracleType.VarChar, 100)
                pr(1).Value = address
                pr(1).Direction = ParameterDirection.Input

                pr(2) = New OracleParameter("pin1", OracleType.Number, 6)
                pr(2).Value = pin
                pr(2).Direction = ParameterDirection.Input

                pr(3) = New OracleParameter("panNo1", OracleType.VarChar, 12)
                pr(3).Value = panNo
                pr(3).Direction = ParameterDirection.Input

                pr(4) = New OracleParameter("taxNo1", OracleType.VarChar, 15)
                pr(4).Value = taxNo
                pr(4).Direction = ParameterDirection.Input

                pr(5) = New OracleParameter("contactNo1", OracleType.VarChar, 12)
                pr(5).Value = contactNo
                pr(5).Direction = ParameterDirection.Input

                pr(6) = New OracleParameter("contactPerson1", OracleType.VarChar, 40)
                pr(6).Value = contactPerson
                pr(6).Direction = ParameterDirection.Input

                pr(7) = New OracleParameter("err_stat", OracleType.Number, 1)
                pr(7).Direction = ParameterDirection.Output

                pr(8) = New OracleParameter("err_msg", OracleType.VarChar, 50)
                pr(8).Direction = ParameterDirection.Output

                OH.ExecuteNonQuery("Payment_AddClient", pr)

                RH.status = pr(7).Value
                RH.message = pr(8).Value
            Catch ex As Exception
                RH.status = 2
                RH.message = ex.Message.ToString()
            End Try
            Return RH
        End Function

        Public Function CategoryConfirm(ByVal firmid As Integer, ByVal expense As String, ByVal acountNo As Integer, ByVal statusId As Char) As ResultHandler Implements AddCategory.IDAL.AddCategory.CategoryConfirm
            Dim message As String = ""
            Try
                '-----------------------Checking values------------------------------------------
                message = "Firm ID"
                Dim fmno As Integer = CInt(firmid)
                message = "Account No"
                Dim account As Integer = CInt(acountNo)
                message = "Procedure - "
                '------------------------Passing values to procedure-----------------------------
                Try
                    Dim pr(5) As OracleParameter
                    pr(0) = New OracleParameter("firmid1", OracleType.Number, 2)
                    pr(0).Value = firmid
                    pr(0).Direction = ParameterDirection.Input

                    pr(1) = New OracleParameter("expense1", OracleType.VarChar, 40)
                    pr(1).Value = expense
                    pr(1).Direction = ParameterDirection.Input


                    pr(2) = New OracleParameter("acountNo1", OracleType.Number, 5)
                    pr(2).Value = acountNo
                    pr(2).Direction = ParameterDirection.Input

                    pr(3) = New OracleParameter("statusId1", OracleType.Char, 1)
                    pr(3).Value = statusId
                    pr(3).Direction = ParameterDirection.Input


                    pr(4) = New OracleParameter("err_stat", OracleType.Number, 1)
                    pr(4).Direction = ParameterDirection.Output

                    pr(5) = New OracleParameter("err_msg", OracleType.VarChar, 50)
                    pr(5).Direction = ParameterDirection.Output
                    OH.ExecuteNonQuery("Payment_AddCategory", pr)

                    RH.status = pr(4).Value
                    RH.message = pr(5).Value

                Catch ex As Exception
                    RH.status = 2
                    RH.message = ex.Message.ToString()
                End Try
                '------------------------End of procedure------------------------------------------
            Catch ex As Exception
                RH.status = 2
                RH.message = ex.Message.ToString() + "Check -- " + message
            End Try
            Return RH
        End Function

        Public Function SubCategoryConfirm(ByVal firmid As Integer, ByVal expenseId As Integer, ByVal subcategory As String, ByVal accountNo As Integer) As ResultHandler Implements AddSubCategory.IDAL.AddSubCategory.SubCategoryConfirm
            Dim message As String = ""
            Try
                '-----------------------Checking values------------------------------------------
                message = "Firm ID"
                Dim fmno As Integer = CInt(firmid)
                message = "Expense ID"
                Dim expense As Integer = CInt(expenseId)
                message = "Account No"
                Dim account As Integer = CInt(accountNo)
                message = "Procedure - "
                '------------------------Passing values to procedure-----------------------------
                Try
                    Dim pr(5) As OracleParameter
                    pr(0) = New OracleParameter("firmid1", OracleType.Number, 2)
                    pr(0).Value = firmid
                    pr(0).Direction = ParameterDirection.Input

                    pr(1) = New OracleParameter("expenseId1", OracleType.Number, 2)
                    pr(1).Value = expenseId
                    pr(1).Direction = ParameterDirection.Input


                    pr(2) = New OracleParameter("subcategory1", OracleType.VarChar, 40)
                    pr(2).Value = subcategory
                    pr(2).Direction = ParameterDirection.Input

                    pr(3) = New OracleParameter("accountNo1", OracleType.Number, 6)
                    pr(3).Value = accountNo
                    pr(3).Direction = ParameterDirection.Input


                    pr(4) = New OracleParameter("err_stat", OracleType.Number, 1)
                    pr(4).Direction = ParameterDirection.Output

                    pr(5) = New OracleParameter("err_msg", OracleType.VarChar, 50)
                    pr(5).Direction = ParameterDirection.Output
                    OH.ExecuteNonQuery("Payment_AddSubCategory", pr)

                    RH.status = pr(4).Value
                    RH.message = pr(5).Value

                Catch ex As Exception
                    RH.status = 2
                    RH.message = ex.Message.ToString()
                End Try
                '------------------------End of procedure------------------------------------------
            Catch ex As Exception
                RH.status = 2
                RH.message = ex.Message.ToString() + "Check -- " + message
            End Try
            Return RH
        End Function

        Public Function NewItemConfirm(ByVal departmentid As Integer, ByVal item As String) As ResultHandler Implements AddNewItem.IDAL.AddNewItem.NewItemConfirm
            Dim message As String = ""
            Try
                '-----------------------Checking values------------------------------------------
                message = "Dept ID"
                Dim dpno As Integer = CInt(departmentid)
                message = "Procedure - "
                '------------------------Passing values to procedure-----------------------------
                Try
                    Dim pr(3) As OracleParameter
                    pr(0) = New OracleParameter("departmentid1", OracleType.Number, 3)
                    pr(0).Value = departmentid
                    pr(0).Direction = ParameterDirection.Input

                    pr(1) = New OracleParameter("item", OracleType.VarChar, 50)
                    pr(1).Value = item
                    pr(1).Direction = ParameterDirection.Input

                    pr(2) = New OracleParameter("err_stat", OracleType.Number, 1)
                    pr(2).Direction = ParameterDirection.Output

                    pr(3) = New OracleParameter("err_msg", OracleType.VarChar, 50)
                    pr(3).Direction = ParameterDirection.Output
                    OH.ExecuteNonQuery("Payment_AddNewItem", pr)

                    RH.status = pr(2).Value
                    RH.message = pr(3).Value

                Catch ex As Exception
                    RH.status = 2
                    RH.message = ex.Message.ToString()
                End Try
                '------------------------End of procedure------------------------------------------
            Catch ex As Exception
                RH.status = 2
                RH.message = ex.Message.ToString() + "Check -- " + message
            End Try
            Return RH
        End Function

        Public Function sanctionConfirm(ByVal firmid As Integer, ByVal departmentId As Integer, ByVal sanctionDetails As String, ByVal totalAmount As Double, ByVal purpose As String, ByVal sanctionDate As Date, ByVal recommendBy As Integer, ByVal sanctionedBy As Integer, ByVal enteredBy As String, ByVal statusId As Integer) As ResultHandler Implements AddSanction.IDAL.AddSanction.sanctionConfirm
            Dim message As String = ""
            Try
                '-----------------------Checking values------------------------------------------
                message = "Firm ID"
                Dim fmno As Integer = CInt(firmid)
                message = "Dept ID"
                Dim dpno As Integer = CInt(departmentId)
                message = "Total Amount"
                Dim totAmount As Double = CDbl(totalAmount)
                message = "Sanction Date"
                Dim sanctionDt As Date = CDate(sanctionDate)
                message = "Recommended by"
                Dim recommend As Integer = CInt(recommendBy)
                message = "Sanctioned by"
                Dim sanctionby As Integer = CInt(sanctionedBy)
                message = "Status Id"
                Dim status As Integer = CInt(statusId)
                message = "Procedure - "
                '------------------------Passing values to procedure------------------------------
                Try
                    Dim pr(10) As OracleParameter
                    pr(0) = New OracleParameter("firmid1", OracleType.Number, 2)
                    pr(0).Value = firmid
                    pr(0).Direction = ParameterDirection.Input

                    pr(1) = New OracleParameter("departmentId1", OracleType.Number, 3)
                    pr(1).Value = departmentId
                    pr(1).Direction = ParameterDirection.Input

                    pr(2) = New OracleParameter("sanctionDetails1", OracleType.VarChar, 1000)
                    pr(2).Value = sanctionDetails
                    pr(2).Direction = ParameterDirection.Input

                    pr(3) = New OracleParameter("purpose1", OracleType.VarChar, 100)
                    pr(3).Value = purpose
                    pr(3).Direction = ParameterDirection.Input

                    pr(4) = New OracleParameter("sanctionDate1", OracleType.DateTime)
                    pr(4).Value = sanctionDate
                    pr(4).Direction = ParameterDirection.Input

                    pr(5) = New OracleParameter("recommendBy1", OracleType.Number, 5)
                    pr(5).Value = recommendBy
                    pr(5).Direction = ParameterDirection.Input

                    pr(6) = New OracleParameter("sanctionedBy1", OracleType.Number, 5)
                    pr(6).Value = sanctionedBy
                    pr(6).Direction = ParameterDirection.Input

                    pr(7) = New OracleParameter("enteredBy1", OracleType.VarChar, 25)
                    pr(7).Value = enteredBy
                    pr(7).Direction = ParameterDirection.Input

                    pr(8) = New OracleParameter("statusId1", OracleType.Number, 1)
                    pr(8).Value = statusId
                    pr(8).Direction = ParameterDirection.Input

                    pr(9) = New OracleParameter("err_stat", OracleType.Number, 1)
                    pr(9).Direction = ParameterDirection.Output

                    pr(10) = New OracleParameter("err_msg", OracleType.VarChar, 50)
                    pr(10).Direction = ParameterDirection.Output
                    OH.ExecuteNonQuery("Payment_AddSanction", pr)

                    RH.status = pr(9).Value
                    RH.message = pr(10).Value

                Catch ex As Exception
                    RH.status = 2
                    RH.message = ex.Message.ToString() + "Check -- " + message
                End Try
                '------------------------End of procedure------------------------------------------
            Catch ex As Exception
                RH.status = 2
                RH.message = ex.Message.ToString() + "Check -- " + message
            End Try
            Return RH
        End Function

        Public Function PaymentConfirm(ByVal firmid As Integer, ByVal departmentId As Integer, ByVal paymentDtl As String, ByVal companyid As Integer, ByVal tdsAmount As Double, ByVal description As String, ByVal payMode As String, ByVal employeeCode As Integer, ByVal serviceTax As Double, ByVal salesTax As Double, ByVal payAmount As Double, ByVal chequeNo As String, ByVal chequeDate As Date, ByVal bankName As String, ByVal ddComm As Double, ByVal userid As String, ByVal branchId As Integer, ByVal sanctionId1 As Integer, ByVal payDtl1 As String, ByVal bankAcc1 As Integer, ByVal account As Integer, ByVal brstat As Integer) As ResultHandler Implements Payment.IDAL.Payment.PaymentConfirm
            Dim message As String = ""
            Try
                '-----------------------Checking values--------------------------------------------
                message = "Firm ID"
                Dim fmno As Integer = CInt(firmid)
                message = "Deptartment ID"
                Dim dpno As Integer = CInt(departmentId)
                'message = "paymentDtl"
                'Dim paydtl As String = paymentDtl.ToString
                message = "Company Id"
                Dim company As Integer = CInt(companyid)
                message = "Tds"
                Dim tds As Double = CDbl(tdsAmount)
                message = "Employee Code"
                Dim employee As Integer = CInt(employeeCode)
                message = "Service Tax"
                Dim service As Double = CDbl(serviceTax)
                message = "Sales Tax"
                Dim sales As Double = CDbl(salesTax)
                message = "Pay Amount"
                Dim pay As Double = CDbl(payAmount)
                message = "DD Commission"
                Dim DD As Double = CDbl(ddComm)
                message = "Branch Id"
                Dim branch As Integer = CInt(branchId)
                message = "Sanction Id"
                Dim sanction As Integer = CInt(sanctionId1)
                message = "Bank Account"
                Dim bank As Double = CDbl(bankAcc1)
                message = "Cheque Date"
                Dim cheque As Date = CDate(chequeDate)
                message = "Account "
                Dim acc As Integer = CInt(account)
                message = "Procedure - "
                '------------------------Passing values to procedure------------------------------
                Try
                    Dim pr(24) As OracleParameter
                    pr(0) = New OracleParameter("firmid1", OracleType.Number, 2)
                    pr(0).Value = firmid
                    pr(0).Direction = ParameterDirection.Input

                    pr(1) = New OracleParameter("paymentDtl1", OracleType.VarChar, 1000)
                    pr(1).Value = paymentDtl
                    pr(1).Direction = ParameterDirection.Input

                    pr(2) = New OracleParameter("companyid1", OracleType.Number, 5)
                    pr(2).Value = companyid
                    pr(2).Direction = ParameterDirection.Input

                    pr(3) = New OracleParameter("tdsAmount1", OracleType.Number, 12, 2)
                    pr(3).Value = tdsAmount
                    pr(3).Direction = ParameterDirection.Input

                    pr(4) = New OracleParameter("description1", OracleType.VarChar, 100)
                    pr(4).Value = description
                    pr(4).Direction = ParameterDirection.Input

                    pr(5) = New OracleParameter("payMode1", OracleType.Char, 1)
                    pr(5).Value = payMode
                    pr(5).Direction = ParameterDirection.Input

                    pr(6) = New OracleParameter("employeeCode1", OracleType.Number, 5)
                    pr(6).Value = employeeCode
                    pr(6).Direction = ParameterDirection.Input

                    pr(7) = New OracleParameter("serviceTax1", OracleType.Number, 7, 2)
                    pr(7).Value = serviceTax
                    pr(7).Direction = ParameterDirection.Input

                    pr(8) = New OracleParameter("salesTax1", OracleType.Number, 7, 2)
                    pr(8).Value = salesTax
                    pr(8).Direction = ParameterDirection.Input

                    pr(9) = New OracleParameter("payAmount", OracleType.Number, 12, 2)
                    pr(9).Value = payAmount
                    pr(9).Direction = ParameterDirection.Input

                    pr(10) = New OracleParameter("chequeNo", OracleType.VarChar, 20)
                    pr(10).Value = chequeNo
                    pr(10).Direction = ParameterDirection.Input

                    pr(11) = New OracleParameter("chequeDate", OracleType.DateTime)
                    pr(11).Value = chequeDate
                    pr(11).Direction = ParameterDirection.Input

                    pr(12) = New OracleParameter("bankName", OracleType.VarChar, 30)
                    pr(12).Value = bankName
                    pr(12).Direction = ParameterDirection.Input

                    pr(13) = New OracleParameter("ddComm", OracleType.Number, 10)
                    pr(13).Value = ddComm
                    pr(13).Direction = ParameterDirection.Input

                    pr(14) = New OracleParameter("userid", OracleType.VarChar, 25)
                    pr(14).Value = userid
                    pr(14).Direction = ParameterDirection.Input

                    pr(15) = New OracleParameter("departmentId1", OracleType.Number, 3)
                    pr(15).Value = departmentId
                    pr(15).Direction = ParameterDirection.Input

                    pr(16) = New OracleParameter("err_stat", OracleType.Number, 1)
                    pr(16).Direction = ParameterDirection.Output

                    pr(17) = New OracleParameter("err_msg", OracleType.VarChar, 500)
                    pr(17).Direction = ParameterDirection.Output

                    pr(18) = New OracleParameter("branchId1", OracleType.Number, 3)
                    pr(18).Value = branchId
                    pr(18).Direction = ParameterDirection.Input

                    pr(19) = New OracleParameter("sanctionId1", OracleType.Number, 6)
                    pr(19).Value = sanctionId1
                    pr(19).Direction = ParameterDirection.Input

                    pr(20) = New OracleParameter("payDtl", OracleType.VarChar, 3)
                    pr(20).Value = payDtl1
                    pr(20).Direction = ParameterDirection.Input

                    pr(21) = New OracleParameter("bankAcc", OracleType.Number, 6)
                    pr(21).Value = bankAcc1
                    pr(21).Direction = ParameterDirection.Input

                    pr(22) = New OracleParameter("p_transno", OracleType.Number, 10)
                    pr(22).Direction = ParameterDirection.Output

                    pr(23) = New OracleParameter("accountName", OracleType.Number, 6)
                    pr(23).Value = account
                    pr(23).Direction = ParameterDirection.Input

                    pr(24) = New OracleParameter("brstat1", OracleType.Number, 6)
                    pr(24).Value = brstat
                    pr(24).Direction = ParameterDirection.Input

                    OH.ExecuteNonQuery("Payment_Payment2", pr)

                    RH.status = pr(16).Value
                    RH.message = pr(17).Value
                    RH.transactionid = pr(22).Value

                Catch ex As Exception
                    RH.status = 2
                    RH.message = ex.Message.ToString() + "Check -- " + message
                End Try
                '------------------------End of procedure------------------------------------------
            Catch ex As Exception
                RH.status = 2
                RH.message = ex.Message.ToString() + "Check -- " + message
            End Try
            Return RH
        End Function
    End Class
End Namespace

