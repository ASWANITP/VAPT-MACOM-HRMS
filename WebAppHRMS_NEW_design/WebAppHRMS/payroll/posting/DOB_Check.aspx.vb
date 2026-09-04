Imports system.data
Imports System.Data.OracleClient
Partial Class HRM_DOB_Check_7509bda16559
    Inherits System.Web.UI.Page
    'Implements System.Web.UI.ICallbackEventHandler
    Dim userAll() As String
    Dim usercode As Integer
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As DataTable

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            dt1 = oh.ExecuteDataSet("select count(*) from employ_personal_dtl p where p.emp_name like ('%" & Me.txtname.Text & "%') and p.birth_date = to_date('" & Me.txtdob.Text & "')").Tables(0)
            If dt1.Rows(0)(0) = 0 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append(" alert('THERE IS NO EMPLOYEE'S OS THIS DOB AND NAME');")
                cl_script1.Append("window.open('DOB_CHECK.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                Me.Server.Transfer("Emp_Details.aspx?e_name=" & Me.txtname.Text & "&dob=" & Me.txtdob.Text & "")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        userAll = Me.Session("user_id").ToString.Split("!")
        usercode = userAll(0)
        Dim frm As Integer
        frm = 578
        dt = oh.ExecuteDataSet("select count(*) from form_accessibility f where f.form_id='" & frm & "' and f.emp_id='" & userAll(0) & "'").Tables(0)
        If dt.Rows(0)(0) = 0 Then

            Me.Response.Redirect("../../show_err.aspx")
            Exit Sub
        End If
    End Sub
End Class
