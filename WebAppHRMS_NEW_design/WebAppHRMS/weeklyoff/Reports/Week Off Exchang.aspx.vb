Imports System.Data
Imports System.Data.OracleClient

Partial Class HRM_Week_Off_Exchang_d85b5c4b8123
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim a, b, c, script_val As String
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim str, str1, str2 As String
    Dim ds As New DataSet
    Dim UserAll(), res, sql As String
    Dim UserCode, postid As Integer
    Public Shared cbresult As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "EMPLOYEES WEEK OFF EXCHANGE"
        Dim masterPage As edp = CType(Me.Master, edp)
        masterPage.subtitle = "EMPLOYEES WEEK OFF EXCHANGE"
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.ddlbranch.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Try
            dt = oh.ExecuteDataSet("select e.emp_code,e.post_id  from employee_master e where  e.emp_code=" & UserCode & "").Tables(0)
            postid = dt.Rows(0)(1)
            If postid = 1 Then
                dt1 = oh.ExecuteDataSet("select -1 as branch_id ,'-------Select-------' as branch_name from dual union all select p.branch_id,p.branch_name from  branch_master p where p.branch_id='" & Session("branch_id") & "'").Tables(0)
                Me.ddlbranch.DataSource = dt1
                Me.ddlbranch.DataValueField = dt1.Columns(0).ColumnName
                Me.ddlbranch.DataTextField = dt1.Columns(1).ColumnName
                Me.ddlbranch.DataBind()
            ElseIf postid = 10 Then
                dt1 = oh.ExecuteDataSet("select -1 as branch_id ,'-------Select-------' as branch_name from dual union all select p.branch_id,p.branch_name from  branch_master p where p.branch_id='" & Session("branch_id") & "'").Tables(0)
                Me.ddlbranch.DataSource = dt1
                Me.ddlbranch.DataValueField = dt1.Columns(0).ColumnName
                Me.ddlbranch.DataTextField = dt1.Columns(1).ColumnName
                Me.ddlbranch.DataBind()
            ElseIf postid = 198 Then
                dt1 = oh.ExecuteDataSet("select -1 as branch_id ,'-------Select-------' as branch_name from dual union all select p.branch_id,p.branch_name from  branch_master p where p.branch_id='" & Session("branch_id") & "'").Tables(0)
                Me.ddlbranch.DataSource = dt1
                Me.ddlbranch.DataValueField = dt1.Columns(0).ColumnName
                Me.ddlbranch.DataTextField = dt1.Columns(1).ColumnName
                Me.ddlbranch.DataBind()
            ElseIf postid = 136 Then
                dt2 = oh.ExecuteDataSet("select -1 as branch_id ,'-------Select-------' as branch_name from dual union all select b.branch_id,b.BRANCH_NAME  from area_master a, branch_dtl_new b where a.area_id=b.area_id and a.area_head_id = " & UserCode & " order by branch_name").Tables(0)
                Me.ddlbranch.DataSource = dt2
                Me.ddlbranch.DataValueField = dt2.Columns(0).ColumnName
                Me.ddlbranch.DataTextField = dt2.Columns(1).ColumnName
                Me.ddlbranch.DataBind()
            ElseIf postid = 199 Then
                dt3 = oh.ExecuteDataSet("select -1 as branch_id ,'-------Select-------' as branch_name from dual union all select t.branch_id,t.branch_name from branch_dtl_new b, employee_master e,branch_dtl_new t where e.branch_id=b.branch_id and b.reg_id= t.reg_id and e.post_id in(199,280) and e.emp_code=" & UserCode & "").Tables(0)
                Me.ddlbranch.DataSource = dt3
                Me.ddlbranch.DataValueField = dt3.Columns(0).ColumnName
                Me.ddlbranch.DataTextField = dt3.Columns(1).ColumnName
                Me.ddlbranch.DataBind()
            ElseIf postid = 280 Then
                dt3 = oh.ExecuteDataSet("select -1 as branch_id ,'-------Select-------' as branch_name from dual union all select t.branch_id,t.branch_name from branch_dtl_new b, employee_master e,branch_dtl_new t where e.branch_id=b.branch_id and b.reg_id= t.reg_id and e.post_id in(199,280) and e.emp_code=" & UserCode & "").Tables(0)
                Me.ddlbranch.DataSource = dt3
                Me.ddlbranch.DataValueField = dt3.Columns(0).ColumnName
                Me.ddlbranch.DataTextField = dt3.Columns(1).ColumnName
                Me.ddlbranch.DataBind()
            Else

                Me.Response.Redirect("../../show_err.aspx")
                Exit Sub

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

 

    Protected Sub BtnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnConfirm.Click
        Dim bran As String
        bran = hiddn1.Value
        Me.Server.Transfer("Week_Off_Exchg_Report.aspx?bran_name=" & bran & "")
    End Sub
End Class
