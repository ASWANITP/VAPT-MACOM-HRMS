Imports System.Data
Imports System.Data.OracleClient

Partial Class Transfer_Promotion_Order_d1e939898147
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim status1, branch1, emp_code1, recv_status1 As Integer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '    status = Request.QueryString("status")

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        branch1 = Me.Session("branch_id").ToString.Split("!")(0)
        emp_code1 = Me.Session("user_id").ToString.Split("!")(0)

        Dim script1 As New System.Text.StringBuilder
        If RadioButton1.Checked = True Then
            status1 = 1
        Else
            RadioButton2.Checked = True
            status1 = 2
        End If

        Dim pro(4) As OracleParameter
        pro(0) = New OracleParameter("emp_code1", OracleType.Number, 7)
        pro(0).Value = emp_code1
        pro(0).Direction = ParameterDirection.Input
        pro(1) = New OracleParameter("branch1", OracleType.Number, 4)
        pro(1).Value = branch1
        pro(1).Direction = ParameterDirection.Input
        pro(2) = New OracleParameter("status1", OracleType.Number, 2)
        pro(2).Value = status1
        pro(2).Direction = ParameterDirection.Input
        pro(3) = New OracleParameter("recv_status1", OracleType.Number, 5)
        pro(3).Value = 0
        pro(3).Direction = ParameterDirection.Input
        pro(4) = New OracleParameter("msg", OracleType.VarChar, 100)
        pro(4).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("TRA_PRO", pro)


        Dim message As String
        message = pro(4).Value

        script1.Append("        alert('" & message & "');")
        script1.Append(" window.open('../../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)


    End Sub
End Class
