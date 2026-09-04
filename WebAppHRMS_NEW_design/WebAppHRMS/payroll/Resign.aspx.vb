Imports System.Data
Imports System.Data.OracleClient
Partial Class HRM_Resign_8adb8e3f9423
    Inherits System.Web.UI.Page
    Dim cm As OracleConnection
    Dim cmd As OracleCommand
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dtr As New DataTable
    Dim ds As New DataSet
    Dim a, b, c, script_val As String
    Dim dt, dt1, dt2 As New DataTable
    Dim str As String = ""
    Dim cbresult, postn As String

  

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CType(Me.Master, WebAppHRMS.edp).Subtitle = "RESIGNING EMPLOYEES"
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.ddlpost.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Try

            'dt = oh.ExecuteDataSet("select -1 as post_id ,'-------Select-------' as post_name from dual union all select p.post_id,p.post_name from post_mst p where p.post_id in (select distinct t.post_id from emp_master t where t.status_id=1 ) order by post_name ").Tables(0)
            dt = oh.ExecuteDataSet("select -1 as post_id, '-------Select-------' as post_name  from dual  union all  select p.post_id, p.post_name  from post_mst p  where p.post_id in  (select distinct t.post_id  from emp_master t, employ_firm ef  where t.status_id = 1  and t.emp_code = ef.emp_code  and ef.firm_id = " & Session("firm_id") & ")  order by post_name").Tables(0)
            Me.ddlpost.DataSource = dt
            Me.ddlpost.DataValueField = dt.Columns(0).ColumnName
            Me.ddlpost.DataTextField = dt.Columns(1).ColumnName
            Me.ddlpost.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnconfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnconfirm.Click
        Dim post As Integer
        post = Me.hiddn.Value
        Me.Server.Transfer("Resign_Report.aspx?post_name=" & post & "")

    End Sub

  
End Class
