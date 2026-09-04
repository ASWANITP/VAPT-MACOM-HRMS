Imports system.data
Imports System.Data.OracleClient
Partial Class HRM_PL3_Short_28f326cb8942
    Inherits System.Web.UI.Page
    'Implements Web.UI.ICallbackEventHandler
    Dim userAll As Integer
    Dim usercode As Integer
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2 As DataTable
    Dim sql, b As String
    Public Shared cbresult As String
    Protected Sub btnconfrm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnconfrm.Click
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        dt = oh.ExecuteDataSet("select count(*) from employee_master e,department_mst d where e.department_id=d.dep_id and d.major_dep_id in (15,18,19,20,21,22,23,24,25) and e.emp_code=" & User(0) & "").Tables(0)
        If dt.Rows(0)(0) = 0 Then
            dt = oh.ExecuteDataSet("select count(*) from employee_master e,department_mst d where e.department_id=d.dep_id and d.major_dep_id in (26,27,14) and e.emp_code=" & User(0) & "").Tables(0)
            If dt.Rows(0)(0) = 0 Then
                Dim p(0) As OracleParameter
                p(0) = New OracleParameter("Dat", OracleType.DateTime, 20)
                p(0).Direction = ParameterDirection.Input
                p(0).Value = Me.txtdate.Text
                If oh.ExecuteNonQuery("hrm_department_short", p) Then
                    Server.Transfer("hrm_dep_short_crpt.aspx")
                End If
            Else
                Dim p(0) As OracleParameter
                p(0) = New OracleParameter("Dat", OracleType.DateTime, 20)
                p(0).Direction = ParameterDirection.Input
                p(0).Value = Me.txtdate.Text
                If oh.ExecuteNonQuery("hrm_department_short_Macare", p) Then
                    Server.Transfer("hrm_dep_short_crpt.aspx")
                End If
            End If
        Else
            Dim p(0) As OracleParameter
            p(0) = New OracleParameter("Dat", OracleType.DateTime, 20)
            p(0).Direction = ParameterDirection.Input
            p(0).Value = Me.txtdate.Text
            If oh.ExecuteNonQuery("hrm_department_short_Jewel", p) Then
                Server.Transfer("hrm_dep_short_crpt.aspx")
            End If
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim script_val As String
        script_val = "var header_txt;header_txt='" & Me.txtdate.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "header_txt", script_val, True)
    End Sub
End Class
