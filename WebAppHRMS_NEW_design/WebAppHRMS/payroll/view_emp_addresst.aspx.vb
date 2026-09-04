Imports System.Data
Imports System.Data.OracleClient
Partial Class view_emp_address_view_emp_addresst_cab9ce948539
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim user() As String
            user = Session("user_id").ToString.Split("!")
            Dim dt As DataTable = oh.ExecuteDataSet("select e.emp_code,e.emp_code || ' - ' || e.emp_name from employee_master e where e.emp_code=" & user(0)).Tables(0)
            Me.txt_emp.Text = dt.Rows(0)(1)
            cmbcode()
        End If
    End Sub

    Private Sub cmbcode()
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        Dim dt1 As DataTable = oh.ExecuteDataSet("select ap.perm_add1,ap.pres_add1 from employ_personal_dtl ap where ap.emp_code=" & user(0)).Tables(0)
        If dt1.Rows.Count > 0 Then
            Me.txt_house1.Text = dt1.Rows(0)(0)
            Me.txt_house2.Text = dt1.Rows(0)(1)
        End If

        Dim dt As DataTable
        dt = oh.ExecuteDataSet("select ap.perm_add1,state1.state_name,dis1.district_name,post1.post_office,post1.pin_code,ap.pres_add1,state2.state_name,dis2.district_name,post2.post_office,post2.pin_code from employ_personal_dtl ap,post_master post1,district_master dis1,state_master state1,post_master post2,district_master dis2,state_master state2 where ap.emp_code=" & user(0) & " and ap.perm_pin=post1.sr_number and post1.district_id=dis1.district_id and dis1.state_id=state1.state_id and ap.pres_pin=post2.sr_number and post2.district_id=dis2.district_id and dis2.state_id=state2.state_id").Tables(0)
        Dim script1 As New System.Text.StringBuilder
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        If dt.Rows.Count = 0 Then
            script1.Append("        alert('Address Not Found');")
            Exit Sub
        Else
            Me.txt_state1.Text = dt.Rows(0)(1)
            Me.txt_district1.Text = dt.Rows(0)(2)
            Me.txt_post1.Text = dt.Rows(0)(3)
            Me.txt_pin1.Text = dt.Rows(0)(4)

            Me.txt_state2.Text = dt.Rows(0)(6)
            Me.txt_district2.Text = dt.Rows(0)(7)
            Me.txt_post2.Text = dt.Rows(0)(8)
            Me.txt_pin2.Text = dt.Rows(0)(9)
        End If

    End Sub

End Class
