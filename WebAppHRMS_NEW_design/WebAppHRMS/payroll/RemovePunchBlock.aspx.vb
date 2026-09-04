Imports System.Data
Imports System.Data.OracleClient
Partial Class EXTRAFORMS_RemoveDateBlock_c07538d45380
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim CbResult As String = Nothing
    Dim sql As String
    Dim code As String
    Dim usr() As String
    Dim CHIT As New IT.DAL.Common
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "REMOVE PUNCH BLOCK"
        Dim BranchID As Integer = CInt(Session("branch_id"))
        usr = Me.Session("user_id").ToString.Split("!")
        '----------------------------------------------------------'
        dt = CHIT.CheckAccess(105, usr(0))
        If (dt.Rows.Count = 0) Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised \n To View This Page!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Exit Sub
        End If
        '----------------------------------------------------------'

        If BranchID <> 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Pls Login in Head Office!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If

        Me.txt_Code.Attributes.Add("onblur", "OnBlurEmpCode()")
        Me.txt_Code.Attributes.Add("onkeyup", "IsNumberOnly()")
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txt_Code.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim Datastr() As String
        Datastr = eventArgument.Split("#")
        Dim trdt As Date = Format(Date.Today, "dd/MMM/yyyy")
        Select Case (Datastr(1))
            Case 1
                Dim Instr() As String = Datastr(0).Split("%")
                If (Instr(1) = "-11") Then
                    Dim EmpCode As String = Instr(0)
                    dt = oh.ExecuteDataSet("select a.emp_name from employee_master a where a.emp_code='" & EmpCode & "' and a.status_id=1 and a.emp_code>10000").Tables(0)
                    CbResult = dt.Rows(0)(0)
                    CbResult = CbResult + "@"
                End If
            Case 2
                Dim Instr() As String = Datastr(0).Split("%")
                If (Instr(1) = "-22") Then
                    Dim EmpCode As String = Instr(0)
                    Try
                        dt = oh.ExecuteDataSet("select count(*) from late_leave_exception where emp_code=" & EmpCode & " and BLOCK_NO=1").Tables(0)
                        If (dt.Rows(0)(0) = 0) Then
                            CbResult = "This Employee Code Not Blocked ..!!!!"
                            Exit Sub
                        Else
                            dt = oh.ExecuteDataSet("select count(*) from late_leave_exception where emp_code=" & EmpCode & " and BLOCK_NO=1 and RELE_DT is not NULL").Tables(0)
                            If (dt.Rows(0)(0) > 0) Then
                                CbResult = "Already Updated ..!!!!"
                                Exit Sub
                            Else
                                oh.ExecuteNonQuery("UPDATE late_leave_exception set RELE_DT=sysdate where emp_code=" & EmpCode & " and BLOCK_NO=1 and RELE_DT is NULL")
                                oh.ExecuteNonQuery("update employee_block_dtl eb set eb.block_status = 0 where eb.emp_code = " & EmpCode & " and eb.block_id = 102 and eb.block_status = 1")

                                CbResult = "Confirmed Successfully ..!!!"
                                Exit Sub
                            End If
                        End If
                    Catch ex As Exception
                        CbResult = ex.Message
                    End Try
                End If
        End Select
    End Sub
End Class
