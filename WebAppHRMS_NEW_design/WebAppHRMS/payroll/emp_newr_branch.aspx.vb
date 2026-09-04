Imports System.Data
Imports System.Data.OracleClient
Partial Class general_emp_newr_branch_5d6ad89c9657
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dt, dt1 As New DataTable
            dt = oh.ExecuteDataSet("select a.emp_code,a.emp_name,c.district_id,d.state_id from employee_master a,employ_personal_dtl b,post_master c,district_master d where a.emp_code=b.emp_code and b.perm_pin=c.sr_number and c.district_id=d.district_id and a.emp_code=" & Session("user_id").ToString.Split("!")(0)).Tables(0)
            Me.txt_empcode.Value = dt.Rows(0)(0)
            Me.txt_empnm.Value = dt.Rows(0)(1)
            dt1 = oh.ExecuteDataSet("select branch_id,branch_name from branch_master where district_id=" & dt.Rows(0)(2) & " order by branch_name").Tables(0)
            If dt1.Rows.Count <= 0 Then
                dt1 = oh.ExecuteDataSet("select branch_id,branch_name from branch_master where state_id=" & dt.Rows(0)(3) & " order by branch_name").Tables(0)
                If dt1.Rows.Count <= 0 Then
                    dt1 = oh.ExecuteDataSet("select branch_id,branch_name from branch_master order by branch_name").Tables(0)
                End If
            End If
            Me.cmb_branch.DataSource = dt1
            Me.cmb_branch.DataTextField = dt1.Columns(1).ColumnName
            Me.cmb_branch.DataValueField = dt1.Columns(0).ColumnName
            Me.cmb_branch.DataBind()
        End If
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Try
            Dim parm_coll(2) As OracleParameter
            parm_coll(0) = New OracleParameter("empid", OracleType.Number, 6)
            parm_coll(0).Value = Me.txt_empcode.Value
            parm_coll(0).Direction = ParameterDirection.Input
            parm_coll(1) = New OracleParameter("brid", OracleType.Number, 5)
            parm_coll(1).Value = Me.cmb_branch.Value
            parm_coll(1).Direction = ParameterDirection.Input
            parm_coll(2) = New OracleParameter("msg", OracleType.VarChar, 150)
            parm_coll(2).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("emp_nearbranch_update", parm_coll)
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('" & parm_coll(2).Value & "');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        Catch ex As Exception
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('" & ex.ToString & "');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        End Try
    End Sub
End Class
