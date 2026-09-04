Imports System.Data
Imports System.Data.OracleClient
Partial Class Resigned_Emp_hrm_resignemp_data_259137708795
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim UserAll(), res As String
    Dim UserCode, BranchId As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Resigned Employees Search"

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtEcode.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)


        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)

    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str() As String

        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)


        Select Case (x)

            Case "1"
                Dim liv As Integer = oh.ExecuteDataSet("select count(*) from employee_master e where e.status_id=1 and e.emp_code=" & str(1) & "").Tables(0).Rows(0)(0)
                If liv > 0 Then
                    str_tkn.Append("This Employee is not in Resigned Status")
                    res = str_tkn.ToString
                Else
                    Dim appCnt As Integer
                    dt = oh.ExecuteDataSet("select count(*) from m_resign_appl m where m.status=1 and m.emp_code=" & str(1) & "").Tables(0)
                    appCnt = dt.Rows(0)(0)

                    If appCnt = 0 Then
                        dt1 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || to_char(r.notice_dt) || '*' ||to_char(r.discont_dt) || '*' || r.remarks from employee_master e, employee_resigtermi r where e.emp_code = r.emp_code and r.status_id=3 and r.emp_code = " & str(1) & "").Tables(0)
                    Else
                        dt1 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || to_char(m.enter_dt) || '*' ||to_char(r.discont_dt) || '*' ||r.remarks from employee_master e, employee_resigtermi r, m_resign_appl m where e.emp_code = r.emp_code and r.emp_code = m.emp_code and m.status=1 and r.emp_code = " & str(1) & "").Tables(0)
                    End If

                    If dt1.Rows.Count = 0 Then
                        str_tkn.Append("NULL")
                        res = str_tkn.ToString
                    Else
                        str_tkn.Append(dt1.Rows(0)(0))
                        res = str_tkn.ToString
                    End If
                End If
        End Select
    End Sub
End Class
