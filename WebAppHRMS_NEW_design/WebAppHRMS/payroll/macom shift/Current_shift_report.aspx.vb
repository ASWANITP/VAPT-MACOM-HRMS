Imports System.Data
Imports System.Data.OracleClient


Public Class Current_shift_report
    Inherits System.Web.UI.Page
    Dim dt, dt3 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sf() As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            sf = Session("user_id").ToString.Split("!")
            dt3 = oh.ExecuteDataSet("select count(*) from employee_master t where t.emp_code=" & sf(0) & " and  t.department_id=546 and t.firm_id=8 and t.status_id=1 ").Tables(0)
            If dt3.Rows(0)(0) = 0 Then

                'Me.Response.Redirect("../../show_err.aspx")
                'Me.Response.Redirect("../../show_err.aspx")--CHANGE
                Me.Server.Transfer("../../show_err.aspx")
            End If
            LoadEmployeeData()
        End If
    End Sub


    Private Sub LoadEmployeeData()
        Dim query As String = "select em.emp_code, em.emp_name, dm.dep_name as department_name, tt.in_time || ' - ' || tt.out_time AS shift_time from employee_master em left join mactech.department_mst dm on em.department_id = dm.dep_id left join time_tab tt on em.shift_id = tt.shift_id where (em.status_id = 1 and em.firm_id = 8) order by em.emp_code"
        Dim dt As DataSet = oh.ExecuteDataSet(query)
        dt = oh.ExecuteDataSet(query)
        Try
            Dim ds As DataSet = oh.ExecuteDataSet(query)
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                gvEmployees.DataSource = ds
                gvEmployees.DataBind()
            Else
                gvEmployees.DataSource = Nothing
                gvEmployees.DataBind()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class