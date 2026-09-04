Imports System.Data
Imports System.Data.OracleClient
Partial Class Resig_Termi_Date_Change_hrm_ResigTermi_DtChange_c6e950528361
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
        Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=184 and emp_id=" & UserCode).Tables(0).Rows(0)(0)
        If acce > 0 Then
            'CType(Me.Master, WebAppHRMS.edp).Subtitle = "Resigned/Terminated Date Change"
            Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
            masterPage.subtitle = "Resigned/Terminated Date Change"
            Dim script_val As String
            script_val = "var header;" & "header='" & Me.txtAdate.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
            Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
        Else
            Me.Server.Transfer("../../show_err.aspx")
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

                dt = oh.ExecuteDataSet("select e.emp_name || '*' || p.post_name || '*' || d.designation || '*' ||to_char(m.discont_dt,'dd/Mon/yyyy') from employee_master e,post_mst p,designation_master d,employee_master_dtl m where e.emp_code=m.emp_code and e.post_id=p.post_id and e.designation_id=d.designation_id and e.status_id in(3,5) and e.emp_code=" & str(1) & "").Tables(0)
                If dt.Rows.Count = 0 Then
                    str_tkn.Append("NULL")
                Else
                    str_tkn.Append(dt.Rows(0)(0))
                    cbResult = str_tkn.ToString
                End If
        End Select
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim empid As Integer
        Dim dat As String
        empid = Me.txtEcode.Text
        dat = Me.hidTermiDate.Value
        Dim empPr As Integer = oh.ExecuteDataSet("select count(*) from employ_promotion_dtl e where e.emp_code=" & empid & " and e.from_dt > to_date('" & dat & "')").Tables(0).Rows(0)(0)
        Dim empTr As Integer = oh.ExecuteDataSet("select count(*) from employ_transfer_dtl e where e.emp_code=" & empid & " and e.from_dt > to_date('" & dat & "')").Tables(0).Rows(0)(0)

        If empPr > 0 Or empTr > 0 Then

            str_tkn.Append("         alert(' Transaction Not Possible ');")
            str_tkn.Append(" window.open('hrm_ResigTermi_DtChange.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)

        Else
            Try
                Dim p(3) As OracleParameter

                p(0) = New OracleParameter("EmpID", OracleType.Number, 6)
                p(0).Value = Me.txtEcode.Text

                p(1) = New OracleParameter("UserID", OracleType.Number, 6)
                p(1).Value = UserCode

                p(2) = New OracleParameter("Rdate", OracleType.VarChar, 15)
                p(2).Value = Me.txtAdate.Text

                p(3) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                p(3).Direction = ParameterDirection.Output

                oh.ExecuteNonQuery("hrm_ResTer_DtChange", p)

                str_tkn.Append("         alert('" & p(3).Value & "');")
                str_tkn.Append(" window.open('hrm_ResigTermi_DtChange.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
            Catch ex As Exception
            End Try

        End If
    End Sub
End Class
