Imports System.Data
Imports System.Data.OracleClient
Partial Class RD_Aadd_and_Delete_hrm_rd_Add_Delete_04b314898919
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
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "RD Add/Change"
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=184 and emp_id=" & UserCode).Tables(0).Rows(0)(0)
        If acce > 0 Then

            Dim script_val As String
            script_val = "var header;" & "header='" & Me.txtEcode.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
            Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
        Else
            Me.Server.Transfer("../show_err.aspx")
        End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return cbResult
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)

        Select Case (x)

            Case "1"

                dt = oh.ExecuteDataSet("select a.emp_name || ' * ' || f.post_name || ' * ' || d.designation ||' * ' || e.branch_name || ' * ' || c.dep_name || ' * ' ||a.basic_pay|| ' * ' ||hs.amount from employee_master a left outer join hrm_rd_security hs on (a.emp_code = hs.emp_code), department_mst  c,designation_mst d,branch_master e, post_mst f where a.department_id = c.dep_id and a.designation_id = d.designation_id and a.branch_id = e.branch_id and a.status_id = 1 and a.post_id = f.post_id and a.emp_code = " & str(1) & "").Tables(0)
                If dt.Rows.Count = 0 Then
                    str_tkn.Append("NULL")
                Else
                    str_tkn.Append(dt.Rows(0)(0))
                    cbResult = str_tkn.ToString
                End If
        End Select

    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

        Dim rdstat As Integer
        Dim amount As Integer
        If Me.rdDelete.Checked = True Then

            rdstat = 1
            amount = 0


        ElseIf Me.rdAdd.Checked = True Then

            rdstat = 2
            amount = Me.txtRd.Text

        End If

        Dim acce As Integer = oh.ExecuteDataSet("select count(*) from hrm_rd_security  t where t.emp_code=" & Me.txtEcode.Text).Tables(0).Rows(0)(0)

        If acce > 0 And rdstat = 2 Then

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Already Added.....!!!');")
            cl_script1.Append(" window.open('hrm_rd_Add_Delete.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        Else
            Try

                Dim p(3) As OracleParameter

                p(0) = New OracleParameter("EmpID", OracleType.Number, 7)
                p(0).Value = Me.txtEcode.Text

                p(1) = New OracleParameter("Amt", OracleType.Number, 6)
                p(1).Value = amount

                p(2) = New OracleParameter("Stat", OracleType.Number, 2)
                p(2).Value = rdstat

                p(3) = New OracleParameter("OutMsg", OracleType.VarChar, 100)
                p(3).Direction = ParameterDirection.Output

                oh.ExecuteNonQuery("hrm_rd_AddDelete_Proc", p)

                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('" & p(3).Value & "');")
                cl_script1.Append(" window.open('hrm_rd_Add_Delete.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

            Catch ex As Exception
            End Try

        End If



    End Sub
End Class
