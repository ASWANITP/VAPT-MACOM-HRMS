Imports System.Data
Imports system.data.oracleclient
Partial Class specificempattend_atterepo_d50e23416100
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim fir As Integer
    Dim firm, Str As String
    Dim dt1 As DataTable
    Dim sql As String
    Dim sql2 As String
    Dim fmid As Integer
    Dim dt As DataTable
    Dim dt2 As DataTable
    Dim str_tkn As New System.Text.StringBuilder
    Dim cl_script1 As New System.Text.StringBuilder



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '' ''Session("firm_id") = 8
        fir = Session("firm_id")
        firm = Session("firm_name")
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        If Not IsPostBack Then
            loadbranch()
        End If

    End Sub

    Function loadbranch()
        ' Str = "select  distinct b.branch_id ,b.branch_name  from employee_master e, branch_master b, employ_firm ef where e.emp_code = ef.emp_code and e.branch_id = b.branch_id and e.emp_code = ef.emp_code and ef.firm_id =" & fir & ""
        Str = "select distinct b.branch_id, b.branch_name from branch_master b left outer join (select distinct ef.firm_id from employee_master e, employ_firm ef where e.emp_code = ef.emp_code and ef.branch_id = e.branch_id and ef.firm_id = " & fir & " ) g on (g.firm_id = b.firm_id) where b.firm_id =" & fir & ""

        dt = oh.ExecuteDataSet(Str).Tables(0)
        Me.ddlbranch.DataSource = dt
        Me.ddlbranch.DataValueField = dt.Columns(0).ColumnName
        Me.ddlbranch.DataTextField = dt.Columns(1).ColumnName
        Me.ddlbranch.DataBind()
    End Function
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim script1 As New System.Text.StringBuilder

        Dim cl_script1 As New System.Text.StringBuilder

        If (ddldaydec.SelectedValue) = 0 And ddlnightsec.SelectedValue = 0 And ddldaygunman.SelectedValue = 0 And ddlnightgunman.SelectedValue = 0 Then

            cl_script1.Append(" alert('Please select any value');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        End If

        If CDate(Txt_Start.Text) > CDate(Date.Now) Then

            cl_script1.Append(" alert('Future Date Not Allowed');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

            Exit Sub

        End If

        Dim script2 As New System.Text.StringBuilder

        Dim cl_script2 As New System.Text.StringBuilder

        If (DropDownList1.SelectedValue) = 0 And ddlnightsec.SelectedValue = 0 And ddldaygunman.SelectedValue = 0 And ddlnightgunman.SelectedValue = 0 Then

            cl_script2.Append(" alert('Please select any value');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        End If

        If CDate(Txt_Start.Text) > CDate(Date.Now) Then

            cl_script2.Append(" alert('Future Date Not Allowed');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        End If




        Try

            Dim parameter(7) As OracleParameter

            parameter(0) = New OracleParameter("br_id", OracleType.Number, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = Me.ddlbranch.SelectedValue




            parameter(1) = New OracleParameter("day_sec", OracleType.Number, 150)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = Me.ddldaydec.SelectedValue


            parameter(2) = New OracleParameter("night_sec", OracleType.Number, 150)
            parameter(2).Direction = ParameterDirection.Input
            parameter(2).Value = Me.ddlnightsec.SelectedValue


            parameter(3) = New OracleParameter("day_gun", OracleType.Number, 150)
            parameter(3).Direction = ParameterDirection.Input
            parameter(3).Value = Me.ddldaygunman.SelectedValue



            parameter(4) = New OracleParameter("night_gun", OracleType.Number, 150)
            parameter(4).Direction = ParameterDirection.Input
            parameter(4).Value = Me.ddlnightgunman.SelectedValue



            parameter(5) = New OracleParameter("start_date", OracleType.DateTime, 150)
            parameter(5).Direction = ParameterDirection.Input
            parameter(5).Value = Format(CDate(Me.Txt_Start.Text), "dd/MMM/yyyy")


            parameter(6) = New OracleParameter("msg", OracleType.VarChar, 5000)
            parameter(6).Direction = ParameterDirection.Output


            parameter(7) = New OracleParameter("day_sec2", OracleType.Number, 150)
            parameter(7).Direction = ParameterDirection.Input
            parameter(7).Value = Me.DropDownList1.SelectedValue



            oh.ExecuteNonQuery("sec_attnd_regularize", parameter)    'as testing


            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('" & parameter(6).Value & "');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

        Response.Redirect("../home.aspx")
    End Sub



End Class
