Imports System.Data
Imports System.Data.OracleClient
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class One_day_shift_request
    Inherits System.Web.UI.Page

    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt1 As DataTable
    Dim UserCode As Integer
    Dim shiftdate As Date
    Dim oldshid, dep_id As Integer
    Dim dt, dt3 As DataTable
    Dim sf() As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.Subtitle = "ONEDAY SHIFT REQUEST"

        If Not IsPostBack Then
            sf = Session("user_id").ToString.Split("!")
            dt3 = oh.ExecuteDataSet("select count(*) from tl_trsfr_level where tl_empcode=" & sf(0) & " ").Tables(0)
            If dt3.Rows(0)(0) = 0 Then

                Me.Response.Redirect("../../show_err.aspx")
            Else
                BindEmpCodeDropdown()
                BindShiftDropdown()
            End If

        End If
    End Sub
    Private Sub BindEmpCodeDropdown()

        'Dim tlEmpCode As String = System.Web.HttpContext.Current.Session("user_id").Split("!")(0)
        'UserCode = tlEmpCode

        sf = Session("user_id").ToString.Split("!")
        UserCode = sf(0)

        Dim query As String = "SELECT a.emp_code, b.emp_name || ' - ' || a.emp_code emp_name FROM TL_TRSFR_LEVEL a JOIN employee_master b ON a.emp_code = b.emp_code WHERE b.firm_id = 8 and b.status_id=1 AND a.TL_EMPCODE = '" & sf(0) & "'"

        Dim dt1 As DataTable = oh.ExecuteDataSet(query).Tables(0)

        If dt1.Rows.Count > 0 Then
            ddlEmpCode.DataSource = dt1
            ddlEmpCode.DataTextField = "emp_name"
            ddlEmpCode.DataValueField = "emp_code"
            ddlEmpCode.DataBind()
            ddlEmpCode.Items.Insert(0, New ListItem("--Select Employee--", ""))
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('No employee found for this code.');", True)
        End If
    End Sub



    Private Sub BindShiftDropdown()

        ' Dim query As String = "select -1 as in_time, '-----Select-----' as name from dual union all select t.shift_id, t.shift || ' --> ' || t.in_time || ' -- ' || t.out_time from time_tab t, time_tab_macare_nw m where t.shift_id = m.shift_id order by in_time "
        Dim query As String = "select -1 as in_time, '-----Select-----' as name from dual union all select t.shift_id, t.shift || ' --> ' || t.in_time || ' -- ' || t.out_time from time_tab t, TIME_TAB_MACOM m where t.shift_id = m.shiftid order by in_time"

        Dim ds As DataSet = oh.ExecuteDataSet(query)

        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
            Dim dtShift As DataTable = ds.Tables(0)

            If dtShift.Rows.Count > 0 Then
                ddlShiftSelection.DataSource = dtShift
                ddlShiftSelection.DataTextField = "name"
                ddlShiftSelection.DataValueField = "in_time"
                ddlShiftSelection.DataBind()

            End If
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Unable to retrieve shift data.');", True)
        End If

    End Sub



    Protected Sub ddlEmpCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim selectedCode As String = ddlEmpCode.SelectedValue
        If selectedCode <> "" Then

            Dim query As String = "SELECT a.emp_code, b.emp_name , c.dep_name, c.dep_id, d.shift AS shift_name , d.shift_id FROM TL_TRSFR_LEVEL a JOIN employee_master b ON a.emp_code = b.emp_code JOIN department_mst c ON b.department_id = c.dep_id JOIN time_tab d ON b.shift_id = d.shift_id WHERE b.firm_id = 8 AND a.emp_code = '" & selectedCode & "'"

            dt1 = oh.ExecuteDataSet(query).Tables(0)



            If dt1.Rows.Count > 0 Then
                Emp_name.Text = dt1.Rows(0)("emp_name").ToString()
                Emp_dep.Text = dt1.Rows(0)("dep_name").ToString()
                shift_name.Text = dt1.Rows(0)("shift_name").ToString()
                oldshid = dt1.Rows(0)("shift_id")
                dep_id = dt1.Rows(0)("dep_id").ToString()
                Session("shif") = dt1.Rows(0)("shift_id")


                'BindShiftDropdown()
            Else
                Emp_name.Text = ""
                Emp_dep.Text = ""
                shift_name.Text = ""
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('No employee found for this code.');", True)
            End If
        Else
            Emp_name.Text = ""
            Emp_dep.Text = ""
            shift_name.Text = ""
        End If
    End Sub

    Protected Sub btnRequest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRequest.Click
        Dim script2 As New System.Text.StringBuilder

        If String.IsNullOrWhiteSpace(ddlEmpCode.SelectedValue) OrElse
       String.IsNullOrWhiteSpace(txtShiftChangeDate.Text) OrElse
       ddlShiftSelection.SelectedValue = "-1" OrElse
       String.IsNullOrWhiteSpace(txtRemarks.Text) Then

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('PLEASE FILL ALL DETAILS');", True)
            Exit Sub
        End If

        If Me.Session("shif") = Me.ddlShiftSelection.SelectedValue Then

            script2.Append("alert('please select another shift');")
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertScript", script2.ToString(), True)
            Exit Sub

        End If


        Dim empid As Integer
        empid = ddlEmpCode.SelectedValue

        Dim newshid As Integer = ddlShiftSelection.SelectedValue

        Dim shiftdate As Date
        shiftdate = txtShiftChangeDate.Text


        Dim remarks As String
        remarks = txtRemarks.Text



        Dim p(6) As OracleParameter

        p(0) = New OracleParameter("EmpID", OracleType.Number, 6)
        p(0).Value = empid
        p(0).Direction = ParameterDirection.Input

        p(1) = New OracleParameter("newshid", OracleType.Number, 6)
        p(1).Value = newshid
        p(1).Direction = ParameterDirection.Input


        p(2) = New OracleParameter("uid", OracleType.Number, 8)
        p(2).Value = System.Web.HttpContext.Current.Session("user_id").Split("!")(0)
        p(2).Direction = ParameterDirection.Input

        p(3) = New OracleParameter("shiftdate", OracleType.DateTime, 6)
        p(3).Value = shiftdate
        p(3).Direction = ParameterDirection.Input

        p(4) = New OracleParameter("remarks", OracleType.VarChar, 36)
        p(4).Value = remarks
        p(4).Direction = ParameterDirection.Input


        p(5) = New OracleParameter("flag", OracleType.Number, 6)
        p(5).Value = 1
        p(5).Direction = ParameterDirection.Input

        p(6) = New OracleParameter("errmsg", OracleType.VarChar, 100)
        p(6).Direction = ParameterDirection.Output


        Try

            oh.ExecuteNonQuery("hrm_one_day_shift_change_req", p)



            Dim errmsg As String = p(6).Value.ToString()

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", $"alert('{errmsg}');setTimeout(function(){{ window.location.href = window.location.href; }}, 100);", True)

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", $"alert('Error occurred: {ex.Message}');", True)
        End Try



        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('SHIFT REQUEST HAS BEEN SUCCESSFULLY SUBMITTED');setTimeout(function(){ window.location.href = window.location.href; }, 100);", True)
    End Sub


    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/home.aspx")
    End Sub


End Class