Imports System.Data
Imports System.Data.OracleClient
Partial Class hrm_punch_firmwise_Report_a92882ea8526
    Inherits System.Web.UI.Page
    Dim cbResult As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim UserAll(), BranchAll(), res, sql, str As String
    Dim UserCode, BranchId As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Punching Report Firm Wise"

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtDate.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        dt = oh.ExecuteDataSet("select -1 as frmid, '------select Firm------' as firm  from dual  union all  select distinct f.firm_id, f.firm_abbr  from firm_master f, employee_master e, employ_firm ef  where e.emp_code = ef.emp_code  and ef.firm_id = f.firm_id  and ef.firm_id=' " & Session("firm_id") & " '  order by frmid").Tables(0)
        Me.ddlFirm.DataSource = dt
        Me.ddlFirm.DataValueField = dt.Columns(0).ColumnName
        Me.ddlFirm.DataTextField = dt.Columns(1).ColumnName
        Me.ddlFirm.DataBind()
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim usr = Session("user_id").ToString.Split("!")
        '--------------- ReqID 8592 starts------------------------------
        If Session("firm_id") = 8 Then

            '---------------------end--------------------------------------------------------------------

            dt = oh.ExecuteDataSet("select count(t.dep_head) from department_mst t where t.dep_head = " & usr(0) & "").Tables(0)
            dt2 = oh.ExecuteDataSet("select count(t.emp_code) from employee_master t where t.access_id = 33 And t.emp_code = " & usr(0) & "").Tables(0)
            If (dt.Rows(0)(0) = 1 Or dt2.Rows(0)(0) = 1) Then
                Server.Transfer("hrm_punch_firmwise_Cryrpt.aspx?Fdt=" & txtDate.Text & "&frm=" & Me.hdnFirm.Value)
            Else
                str_tkn.Append("         alert('You are not authorized...!');")
                'str_tkn.Append(" window.open('hrm_punch_firmwise_Report.aspx.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)

            End If
            '--------------- ReqID 8592 starts------------------------------
        Else
            Server.Transfer("hrm_punch_firmwise_Cryrpt.aspx?Fdt=" & txtDate.Text & "&frm=" & Me.hdnFirm.Value)
        End If
        '---------------------end-------------------------------------------
    End Sub
End Class
