Imports System.Data
Imports System.Data.OracleClient
Partial Class hrm_hrm_TFR_APP_tostore_e546f7998521
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)

        Dim id As Integer
        id = 322

        dt1 = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=" & id & " and emp_id=" & UserCode & "").Tables(0)
        If dt1.Rows(0)(0) <= 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised !!!!');")
            cl_script0.Append("window.open('../../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtDate.ClientID & "';"
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
        Dim j As Integer
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)

        If Me.ddl1.SelectedValue = 1 Then
            j = 1
        ElseIf Me.ddl1.SelectedValue = 2 Then
            j = 2
        Else
            j = 0
        End If
       

        Select Case (x)

            Case "1"
                If j = 2 Then

                    dt = oh.ExecuteDataSet("select -1 as eid, ' --------SELECT----------' as ename from dual union all select e.emp_code, t.emp_code || '--' || e.emp_name || '--' || t.from_dt from employee_master e, employ_transfer_dtl t where e.emp_code = t.emp_code and t.status_id = 8 and t.to_dt is null and t.branch_id <> 0 and e.status_id = 1 and t.from_dt = to_date('" & str(1) & "') and t.from_dt <> e.join_dt and e.emp_code not in (select m.description from mail_dept_dtl m where e.emp_code=m.description and m.particular_id=128) order by eid").Tables(0)

                ElseIf j = 1 Then

                    dt = oh.ExecuteDataSet("select -1 as eid, ' --------SELECT----------' as ename  from dual union all select e.emp_code, e.emp_code || '--' || e.emp_name || '--' || e.join_dt from employee_master e where e.join_dt = to_date('" & str(1) & "') and e.emp_code not in (select m.description from mail_dept_dtl m where e.emp_code=m.description and m.particular_id=126) order by eid").Tables(0)
                Else
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('select the type of order !!!!');")
                    cl_script1.Append(" window.open('hrm_TFR_APP_tostore.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                End If
                res = FillData(res, dt)
                res = res + "@"

            Case "2"

                dt1 = oh.ExecuteDataSet("select e.emp_name || '*' || b.branch_name || '*' || p.post_name || '*' ||e.status_id from employee_master e, branch_dtl_new b, post_mst p where e.branch_id=b.branch_id and  e.post_id=p.post_id and e.emp_code=" & str(1) & "").Tables(0)

                If dt1.Rows.Count = 0 Then
                    str_tkn.Append("NULL")
                    res = str_tkn.ToString
                Else
                    str_tkn.Append(dt1.Rows(0)(0))
                    res = str_tkn.ToString
                End If

        End Select

    End Sub
    Public Function FillData(ByVal cbResult As String, ByVal DT As DataTable) As String
        For n As Integer = 0 To DT.Rows.Count - 1
            cbResult += DT.Rows(n)(0).ToString
            cbResult += "$"
            cbResult += DT.Rows(n)(1).ToString
            If n < DT.Rows.Count - 1 Then
                cbResult += "*"
            End If
        Next
        Return cbResult
    End Function

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

        Try

            Dim p(3) As OracleParameter

            p(0) = New OracleParameter("Datas", OracleType.VarChar, 5000)
            p(0).Value = Me.hdnSend.Value

            p(1) = New OracleParameter("PrID", OracleType.Number, 6)
            p(1).Value = UserCode

            p(2) = New OracleParameter("status", OracleType.Number, 100)
            p(2).Value = Me.Hdn.Value

            p(3) = New OracleParameter("OutMsg", OracleType.VarChar, 100)
            p(3).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_App_Tfr_Proc", p)

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & p(3).Value & "');")
            cl_script1.Append(" window.open('hrm_TFR_APP_tostore.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class

