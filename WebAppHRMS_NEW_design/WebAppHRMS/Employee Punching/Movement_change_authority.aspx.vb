Imports System.Data
Imports System.Data.OracleClient
Partial Class Employee_Punching_Movement_change_authority_47bf526f4256
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Dim backResult As String
    Dim dt, dt1, dt3, dt4 As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim firmid As Integer
        firmid = Session("firm_id")
        Try
            Dim user_id() As String = Session("user_id").ToString.Split("!")
            sql = "select count(t.emp_id) from form_accessibility t where t.form_id=855  and t.emp_id='" & user_id(0) & "' "
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows(0)(0) = 0 Then
                Dim script_val1 As New StringBuilder
                script_val1.Append("         alert('You Not Authorized To View This Page !!');")
                script_val1.Append("         window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script_val1.ToString, True)
                Exit Sub
            End If
            If Not IsPostBack Then
                If firmid = 27 Then
                    dt = oh.ExecuteDataSet("select '----------SELECT EMPLOYEE----------',-1 from dual union select t.emp_code|| '----' || t.emp_name || '----' || decode(t.mov_type, 1, 'PERSONAL', 2, 'OFFICIAL'),t.emp_code from tbl_movement_mst t where t.status_id in (0, 1) and t.reqst_dt = to_char(sysdate) and t.firm=27").Tables(0)
                    If dt.Rows.Count > 0 Then
                        ddl_emp.DataSource = dt
                        ddl_emp.DataValueField = dt.Columns(1).ColumnName
                        ddl_emp.DataTextField = dt.Columns(0).ColumnName
                        ddl_emp.DataBind()
                    Else
                        Dim cl_script1 As New System.Text.StringBuilder
                        cl_script1.Append("         alert('No Data Found!!!!');")
                        cl_script1.Append(" window.open('Movement_change_authority.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    End If
                Else

                    dt = oh.ExecuteDataSet("select '----------SELECT EMPLOYEE----------',-1 from dual union select t.emp_code|| '----' || t.emp_name || '----' || decode(t.mov_type, 1, 'PERSONAL', 2, 'OFFICIAL'),t.emp_code from tbl_movement_mst t where t.status_id in (0, 1) and t.reqst_dt = to_char(sysdate)").Tables(0)
                    If dt.Rows.Count > 0 Then
                        ddl_emp.DataSource = dt
                        ddl_emp.DataValueField = dt.Columns(1).ColumnName
                        ddl_emp.DataTextField = dt.Columns(0).ColumnName
                        ddl_emp.DataBind()
                    Else
                        Dim cl_script1 As New System.Text.StringBuilder
                        cl_script1.Append("         alert('No Data Found!!!!!');")
                        cl_script1.Append(" window.open('Movement_change_authority.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    End If
                End If
                DdlBind()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub DdlBind()
        dt3 = oh.ExecuteDataSet("select -1 emp_code,'----------SELECT EMPLOYEE----------' from dual  union all select m.EMP_CODE emp_code, m.EMP_CODE || ' - ' || m.EMP_NAME || ' - '||p.post_name from emp_master m, employ_firm f,post_mst p where m.EMP_CODE = f.emp_code and m.POST_ID=p.post_id and f.firm_id =" & Session("firm_id") & " and m.STATUS_ID = 1 order by EMP_CODE").Tables(0)
        Me.ddlRec.DataSource = dt3
        Me.ddlRec.DataTextField = dt3.Columns(1).ColumnName
        Me.ddlRec.DataValueField = dt3.Columns(0).ColumnName
        Me.ddlRec.DataBind()
        Me.ddlSac.DataSource = dt3
        Me.ddlSac.DataTextField = dt3.Columns(1).ColumnName
        Me.ddlSac.DataValueField = dt3.Columns(0).ColumnName
        Me.ddlSac.DataBind()
    End Sub

    Protected Sub ddl_emp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_emp.SelectedIndexChanged
        Dim dt2 As New DataTable
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Dim StrArr() As String
        dt2 = oh.ExecuteDataSet("select d.dep_name || '*' || p.post_name from tbl_movement_mst t, employee_master e, post_mst p, department_mst d where t.emp_code = e.emp_code and t.status_id in (0, 1) and t.reqst_dt = to_char(sysdate) and e.department_id = d.dep_id and e.post_id = p.post_id and t.emp_code=" + Me.ddl_emp.SelectedValue).Tables(0)
        StrArr = dt2.Rows(0)(0).split("*")
        Try
            Me.txtBranch.Value = StrArr(0).ToString()
            Me.txtPost.Value = StrArr(1).ToString()
        Catch ex As Exception
        Finally
            dt.Dispose()
        End Try
    End Sub




    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim script1 As New System.Text.StringBuilder
    '    Dim sql8 As String = "update tbl_movement_mst t set t.rec_usr=" & Me.ddlRec.SelectedValue & " where t.emp_code=" & Me.ddl_emp.SelectedValue & " and to_date(t.reqst_dt) = to_date(sysdate)"

    '    oh.ExecuteNonQuery(sql8)
    '    script1.Append("        alert('Updated Recommender..!!');")
    '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

    'End Sub

    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Dim script1 As New System.Text.StringBuilder
    '    Dim sql8 As String = "update tbl_movement_mst t set t.aprv_usr=" & Me.ddlSac.SelectedValue & " where t.emp_code=" & Me.ddl_emp.SelectedValue & " and to_date(t.reqst_dt) = to_date(sysdate)"
    '    oh.ExecuteNonQuery(sql8)
    '    script1.Append("        alert('Updated Approver..!!');")
    '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

    'End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim script1 As New System.Text.StringBuilder
        Dim sql8 As String


        If (Me.ddlSac.SelectedIndex = 0) Then
            script1.Append("        alert(' Please Select approver...!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        If (Me.ddlRec.SelectedIndex = 0) Then
            script1.Append("        alert(' Please Select Recommender...!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        If ddlRec.SelectedIndex > 0 Then

            If ddlSac.SelectedIndex > 0 Then
                sql8 = "update tbl_movement_mst t set  t.rec_usr=" & Me.ddlRec.SelectedValue & ", t.aprv_usr=" & Me.ddlSac.SelectedValue & " where t.emp_code=" & Me.ddl_emp.SelectedValue & " and to_date(t.reqst_dt) = to_date(sysdate)"
                'ElseIf (ddlRec.SelectedValue) = True And (ddlSac.SelectedValue) = True Then
            End If
        End If
        oh.ExecuteNonQuery(sql8)
        script1.Append("        alert('Updated ..!!');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

    End Sub
End Class



