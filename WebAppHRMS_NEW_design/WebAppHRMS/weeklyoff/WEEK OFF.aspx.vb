Imports System.Data
Imports System.Data.OracleClient

Partial Class HRM_WEEK_OFF_bb422d926143
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim a, b, c, script_val As String
    Dim dt, dt1, dt2 As New DataTable
    Dim str, str1, str2 As String
    Dim ds As New DataSet
    Public Shared cbresult As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("branch_id") = 0 Then
            'CType(Me.Master, WebAppHRMS.edp).Subtitle = "EMPLOYEES WEEK OFF"
            Dim masterPage As edp = CType(Me.Master, edp)
            masterPage.subtitle = "EMPLOYEES WEEK OFF"
            Dim script_val As String
            script_val = "var header;" & "header='" & Me.ddlbranch.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
            Try
                dt = oh.ExecuteDataSet("select -1 as branch_id ,'-------Select-------' as branch_name from dual union all select p.branch_id,p.branch_name from  branch_master p order by branch_name").Tables(0)
                Me.ddlbranch.DataSource = dt
                Me.ddlbranch.DataValueField = dt.Columns(0).ColumnName
                Me.ddlbranch.DataTextField = dt.Columns(1).ColumnName
                Me.ddlbranch.DataBind()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Me.Server.Transfer("Week_Off_Report.aspx?bran_name=" & Session("branch_id") & "")
        End If
      
      
       
       
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncnfrm.Click
        Dim bran As String
        bran = Me.hiddn1.Value
        Me.Server.Transfer("Week_Off_Report.aspx?bran_name=" & bran & "")
    End Sub
End Class
