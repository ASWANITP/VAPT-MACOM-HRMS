Imports System.Data
Imports System.Data.OracleClient

Partial Class Transfer_Promotion_Receival_6350809b4851
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable

    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder
    Dim recvstatus1 As Integer
 


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'If Page.IsPostBack <> True Then
        '    dt1 = oh.ExecuteDataSet("select tp.emp_code from trans_prom tp where tp.recv_status = 0").Tables(0)
        'End If


        'Me.DropDownList1.DataSource = dt
        'DropDownList1.DataValueField = dt.Columns(0).ColumnName
        'DropDownList1.DataBind()


        Dim user() As String = Session("user_id").ToString.Split("!")

        Dim emno As Integer = oh.ExecuteDataSet("select count(em.post_id)    from employee_master em    where  em.post_id in (195,421) and em.emp_code = '" & User(0) & "'").Tables(0).Rows(0)(0)
        If emno = 0 Then
            str_tkn.Append("         alert('You are not authorized...!');")
            str_tkn.Append(" window.open('../Home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        Else


            If Page.IsPostBack <> True Then



                dt = oh.ExecuteDataSet("select count(em.post_id)    from employee_master em    where  em.post_id = 195 and em.emp_code = '" & user(0) & "'").Tables(0)
                'If dt.Rows.Count > 1 Then
                Dim z As Integer = dt.Rows(0)(0)
                If z > 0 Then

                    dt1 = oh.ExecuteDataSet("select tp.emp_code from trans_prom tp where tp.recv_status = 0 and tp.status  = 1").Tables(0)
                    Me.DropDownList1.DataSource = dt1
                    DropDownList1.DataValueField = dt1.Columns(0).ColumnName
                    DropDownList1.DataBind()


                Else
                    'dt = oh.ExecuteDataSet("select count(em.post_id)    from employee_master em    where  em.post_id = 421 and em.emp_code = '" & user(0) & "'").Tables(0)
                    'If dt.Rows.Count > 1 Then

                    dt2 = oh.ExecuteDataSet("select tp.emp_code from trans_prom tp where tp.recv_status = 0 and tp.status  = 2").Tables(0)
                    Me.DropDownList1.DataSource = dt2
                    DropDownList1.DataValueField = dt2.Columns(0).ColumnName
                    DropDownList1.DataBind()

                End If
            End If
            End If
        'End If


    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim pro(4) As OracleParameter
        pro(0) = New OracleParameter("emp_code1", OracleType.Number, 7)
        pro(0).Value = Me.DropDownList1.SelectedValue
        pro(0).Direction = ParameterDirection.Input
        pro(1) = New OracleParameter("branch1", OracleType.Number, 4)
        pro(1).Value = 0
        pro(1).Direction = ParameterDirection.Input
        pro(2) = New OracleParameter("status1", OracleType.Number, 2)
        pro(2).Value = 0
        pro(2).Direction = ParameterDirection.Input
        pro(3) = New OracleParameter("recv_status1", OracleType.Number, 5)
        pro(3).Value = 1
        pro(3).Direction = ParameterDirection.Input
        pro(4) = New OracleParameter("msg", OracleType.VarChar, 100)
        pro(4).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("TRA_PRO", pro)


        Dim message As String
        message = pro(4).Value

        str_tkn.Append("        alert('" & message & "');")
        str_tkn.Append(" window.open('../../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)




    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim pro(4) As OracleParameter
        pro(0) = New OracleParameter("emp_code1", OracleType.Number, 7)
        pro(0).Value = Me.DropDownList1.SelectedValue
        pro(0).Direction = ParameterDirection.Input
        pro(1) = New OracleParameter("branch1", OracleType.Number, 4)
        pro(1).Value = 0
        pro(1).Direction = ParameterDirection.Input
        pro(2) = New OracleParameter("status1", OracleType.Number, 2)
        pro(2).Value = 0
        pro(2).Direction = ParameterDirection.Input
        pro(3) = New OracleParameter("recv_status1", OracleType.Number, 5)
        pro(3).Value = 3
        pro(3).Direction = ParameterDirection.Input
        pro(4) = New OracleParameter("msg", OracleType.VarChar, 100)
        pro(4).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("TRA_PRO", pro)


        Dim message As String
        message = pro(4).Value

        str_tkn.Append("        alert('" & message & "');")
        str_tkn.Append(" window.open('../../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)


       
    End Sub
End Class
