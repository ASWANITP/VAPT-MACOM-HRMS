Imports System.Data
Imports System.Data.OracleClient
Partial Class november_tour_Tour_apply_5ace8aa19373
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dtj, ceo, depp As New DataTable
    Dim sf() As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '------VAPT - improper parameter validation---------------------------------------
        Dim paramCount As Integer = Request.QueryString.Count
        If Request.QueryString.Count > 0 Then
            Response.StatusCode = 400
            Response.StatusDescription = "Bad Request"
            Response.End()
        End If
        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_purp.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        Dim dep1 As String = " "
        Dim fid As Integer = Session("firm_id")
        If fid = 8 Then
            Server.Transfer("EarlyRecSancMac.aspx")
        End If
        If Not IsPostBack Then

            loadfile()

        End If

    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click

        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        '        Dim sf As Integer = 10584
        Dim dt2, dt3 As DataTable
        dt2 = oh.ExecuteDataSet("select sysdate from dual").Tables(0)
        Dim arr, arr1 As Array

        arr = Me.cmb_emp.SelectedValue.Split("*")
        arr1 = arr(0).split("-----")
        dt3 = oh.ExecuteDataSet("select count(j.early_sancby)  from othleave_sanction_authority j where j.early_sancby=" & sf(0) & " and j.emp_id=" & arr1(0) & "").Tables(0)
        If dt3.Rows(0)(0) > 0 Then

            Dim script1 As New System.Text.StringBuilder
            Try
                Dim parameter(4) As OracleParameter
                parameter(0) = New OracleParameter("emp_id", OracleType.Number, 150)
                parameter(0).Direction = ParameterDirection.Input
                parameter(0).Value = arr1(0)

                parameter(1) = New OracleParameter("go_date", OracleType.DateTime, 150)
                parameter(1).Direction = ParameterDirection.Input
                parameter(1).Value = Format(CDate(Me.Txt_fdt.Text), "dd/MMM/yyyy")

                parameter(2) = New OracleParameter("rec_san_emp_code", OracleType.Number, 150)
                parameter(2).Direction = ParameterDirection.Input
                ' parameter(2).Value = sf(0)
                parameter(2).Value = sf(0)

                parameter(3) = New OracleParameter("btn_type", OracleType.Number, 150)
                parameter(3).Direction = ParameterDirection.Input
                parameter(3).Value = 1

                parameter(4) = New OracleParameter("err_msg", OracleType.VarChar, 5000)
                parameter(4).Direction = ParameterDirection.Output
                'oh.ExecuteNonQuery("hrm_tour_apply", parameter)

                oh.ExecuteNonQuery("hrm_earlygoing_san", parameter) 'as testing


                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('" & parameter(4).Value & "');")
                ' cl_script1.Append(" window.open('earlygoing_sanc.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                loadfile()


            Catch ex As Exception

            End Try
        Else
            Me.Server.Transfer("../show_err.aspx")
        End If


    End Sub
    Function loadfile()
        sf = Session("user_id").ToString.Split("!")
        ' sf As Integer = 10584
        ' dt1 = oh.ExecuteDataSet("select count(j.erly_recby)  from othleave_sanction_authority j where j.erly_recby = " & sf(0) & "").Tables(0)
        ' dt2 = oh.ExecuteDataSet("select count(j.early_sancby)  from othleave_sanction_authority j where j.early_sancby=" & sf(0) & "").Tables(0)
        Me.Txt_br.Value = ""
        Me.Txt_dep.Value = ""
        Me.Txt_des.Value = ""
        Me.Txt_emp.Value = ""
        Me.Txt_fdt.Text = ""
        Me.Txt_post.Value = ""
        Me.Txt_purp.Text = ""
        dt = oh.ExecuteDataSet("select '----SELECT----','0' as empcode  from dual union select e.emp_code || '-----' || e.emp_name || '-----' || to_char(a.going_dt), e.emp_code || '-----' || e.emp_name || '*' || d.dep_name || '*' || ds.designation || '*' || p.post_name || '*' || b.branch_name || '*' || to_char(a.going_dt) || '*' || a.reason from othleave_sanction_authority t, hrm_earlygoing_appl a,employee_master e,department_mst d,designation_master ds,post_mst p,branch b where a.emp_code = e.emp_code  and a.status in (0)  and t.emp_id = a.emp_code  and t.erly_recby = " & sf(0) & "  and e.department_id = d.dep_id  and e.designation_id = ds.designation_id and e.post_id = p.post_id and e.branch_id=b.BRANCH_ID").Tables(0)
        '  End If
        If dt.Rows.Count > 0 Then
            cmb_emp.DataSource = dt
            cmb_emp.DataValueField = dt.Columns(1).ColumnName
            cmb_emp.DataTextField = dt.Columns(0).ColumnName
            cmb_emp.DataBind()
        End If
    End Function

    Protected Sub cmb_emp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_emp.SelectedIndexChanged


        Dim arr As Array
        arr = Me.cmb_emp.SelectedValue.Split("*")
        Me.Txt_emp.Value = arr(0)
        Me.Txt_dep.Value = arr(1)
        Me.Txt_des.Value = arr(2)
        Me.Txt_post.Value = arr(3)
        Me.Txt_br.Value = arr(4)
        Me.Txt_fdt.Text = arr(5)
        Me.Txt_purp.Text = arr(6)



    End Sub

    Protected Sub cmd_recom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_recom.Click

        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")

        Dim arr, arr1 As Array

        arr = Me.cmb_emp.SelectedValue.Split("*")
        arr1 = arr(0).split("-----")
        Dim dt2 As DataTable
        dt2 = oh.ExecuteDataSet("select sysdate from dual").Tables(0)
        ' dt3 = oh.ExecuteDataSet("select count(j.erly_recby)  from othleave_sanction_authority j where j.erly_recby=" & sf(0) & " and j.emp_id=" & arr1(0) & "").Tables(0)
        'If dt3.Rows(0)(0) > 0 Then
        Dim script1 As New System.Text.StringBuilder
        Try

            Dim parameter(4) As OracleParameter

            parameter(0) = New OracleParameter("emp_id", OracleType.Number, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = arr1(0)

            parameter(1) = New OracleParameter("go_date", OracleType.DateTime, 150)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = Format(CDate(Me.Txt_fdt.Text), "dd/MMM/yyyy")

            parameter(2) = New OracleParameter("rec_san_emp_code", OracleType.Number, 150)
            parameter(2).Direction = ParameterDirection.Input
            'parameter(2).Value = sf(0)
            parameter(2).Value = sf(0)

            parameter(3) = New OracleParameter("btn_type", OracleType.Number, 150)
            parameter(3).Direction = ParameterDirection.Input
            parameter(3).Value = 4

            parameter(4) = New OracleParameter("err_msg", OracleType.VarChar, 5000)
            parameter(4).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_earlygoing_san", parameter)    'as testing

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & parameter(4).Value & "');")
            cl_script1.Append(" window.open('earlygoing_sanc.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

            loadfile()

        Catch ex As Exception

        End Try
        '  Else
        ' Me.Server.Transfer("../show_err.aspx")
        ' End If

    End Sub

    Protected Sub cmd_reject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_reject.Click

        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")

        Dim dt2 As DataTable
        dt2 = oh.ExecuteDataSet("select sysdate from dual").Tables(0)

        Dim script1 As New System.Text.StringBuilder
        Try

            Dim arr, arr1 As Array

            arr = Me.cmb_emp.SelectedValue.Split("*")
            arr1 = arr(0).split("-----")

            Dim parameter(4) As OracleParameter

            parameter(0) = New OracleParameter("emp_id", OracleType.Number, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = arr1(0)

            parameter(1) = New OracleParameter("go_date", OracleType.DateTime, 150)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = Format(CDate(Me.Txt_fdt.Text), "dd/MMM/yyyy")

            parameter(2) = New OracleParameter("rec_san_emp_code", OracleType.Number, 150)
            parameter(2).Direction = ParameterDirection.Input
            parameter(2).Value = sf(0)

            parameter(3) = New OracleParameter("btn_type", OracleType.Number, 150)
            parameter(3).Direction = ParameterDirection.Input
            parameter(3).Value = 2

            parameter(4) = New OracleParameter("err_msg", OracleType.VarChar, 5000)
            parameter(4).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_earlygoing_san", parameter)    'as testing

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & parameter(4).Value & "');")
            cl_script1.Append(" window.open('earlygoing_sanc.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

            loadfile()

        Catch ex As Exception

        End Try


    End Sub

    Protected Sub rdbrec_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbrec.CheckedChanged
        sf = Session("user_id").ToString.Split("!")
        If Me.rdbrec.Checked = True Then
            dt = oh.ExecuteDataSet("select '----SELECT----','0' as empcode  from dual union select e.emp_code || '-----' || e.emp_name || '-----' || to_char(a.going_dt), e.emp_code || '-----' || e.emp_name || '*' || d.dep_name || '*' || ds.designation || '*' || p.post_name || '*' || b.branch_name || '*' || to_char(a.going_dt) || '*' || a.reason from othleave_sanction_authority t, hrm_earlygoing_appl a,employee_master e,department_mst d,designation_master ds,post_mst p,branch b where a.emp_code = e.emp_code  and a.status in (0)  and t.emp_id = a.emp_code  and t.erly_recby = " & sf(0) & "  and e.department_id = d.dep_id  and e.designation_id = ds.designation_id and e.post_id = p.post_id and e.branch_id=b.BRANCH_ID").Tables(0)
            '  End If
            If dt.Rows.Count > 0 Then
                cmb_emp.DataSource = dt
                cmb_emp.DataValueField = dt.Columns(1).ColumnName
                cmb_emp.DataTextField = dt.Columns(0).ColumnName
                cmb_emp.DataBind()
            End If
        Else

            dt = oh.ExecuteDataSet("select '----SELECT----','0' as empcode  from dual union select e.emp_code || '-----' || e.emp_name || '-----' || to_char(a.going_dt), e.emp_code || '-----' || e.emp_name || '*' || d.dep_name || '*' || ds.designation || '*' || p.post_name || '*' || b.branch_name || '*' || to_char(a.going_dt) || '*' || a.reason from othleave_sanction_authority t, hrm_earlygoing_appl a,employee_master e,department_mst d,designation_master ds,post_mst p,branch b where a.emp_code = e.emp_code  and a.status in (4,5,6)  and t.emp_id = a.emp_code  and t.early_sancby = " & sf(0) & "  and e.department_id = d.dep_id  and e.designation_id = ds.designation_id and e.post_id = p.post_id and e.branch_id=b.BRANCH_ID union select e.emp_code || '-----' || e.emp_name || '-----' || to_char(a.going_dt), e.emp_code || '-----' || e.emp_name || '*' || d.dep_name || '*' || ds.designation || '*' || p.post_name || '*' || b.branch_name || '*' || to_char(a.going_dt) || '*' || a.reason from othleave_sanction_authority t, hrm_earlygoing_appl a,employee_master e,department_mst d,designation_master ds,post_mst p,branch b where a.emp_code = e.emp_code  and a.status in (0)  and t.emp_id = a.emp_code  and t.early_sancby = " & sf(0) & "  and e.department_id = d.dep_id  and e.designation_id = ds.designation_id and e.post_id = p.post_id and e.branch_id=b.BRANCH_ID and t.erly_recby=0 ").Tables(0)
            '  End If
            If dt.Rows.Count > 0 Then
                cmb_emp.DataSource = dt
                cmb_emp.DataValueField = dt.Columns(1).ColumnName
                cmb_emp.DataTextField = dt.Columns(0).ColumnName
                cmb_emp.DataBind()
            End If

        End If
    End Sub

    Protected Sub rdbsanc_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbsanc.CheckedChanged
        sf = Session("user_id").ToString.Split("!")
        If Me.rdbsanc.Checked = True Then
            dt = oh.ExecuteDataSet("select '----SELECT----','0' as empcode  from dual union select e.emp_code || '-----' || e.emp_name || '-----' || to_char(a.going_dt), e.emp_code || '-----' || e.emp_name || '*' || d.dep_name || '*' || ds.designation || '*' || p.post_name || '*' || b.branch_name || '*' || to_char(a.going_dt) || '*' || a.reason from othleave_sanction_authority t, hrm_earlygoing_appl a,employee_master e,department_mst d,designation_master ds,post_mst p,branch b where a.emp_code = e.emp_code  and a.status in (4,5,6)  and t.emp_id = a.emp_code  and t.early_sancby = " & sf(0) & "  and e.department_id = d.dep_id  and e.designation_id = ds.designation_id and e.post_id = p.post_id and e.branch_id=b.BRANCH_ID union select e.emp_code || '-----' || e.emp_name || '-----' || to_char(a.going_dt), e.emp_code || '-----' || e.emp_name || '*' || d.dep_name || '*' || ds.designation || '*' || p.post_name || '*' || b.branch_name || '*' || to_char(a.going_dt) || '*' || a.reason from othleave_sanction_authority t, hrm_earlygoing_appl a,employee_master e,department_mst d,designation_master ds,post_mst p,branch b where a.emp_code = e.emp_code  and a.status in (0)  and t.emp_id = a.emp_code  and t.early_sancby = " & sf(0) & "  and e.department_id = d.dep_id  and e.designation_id = ds.designation_id and e.post_id = p.post_id and e.branch_id=b.BRANCH_ID and t.erly_recby=0 ").Tables(0)

            '  End If
            If dt.Rows.Count > 0 Then
                cmb_emp.DataSource = dt
                cmb_emp.DataValueField = dt.Columns(1).ColumnName
                cmb_emp.DataTextField = dt.Columns(0).ColumnName
                cmb_emp.DataBind()
            End If
        Else

            dt = oh.ExecuteDataSet("select '----SELECT----','0' as empcode  from dual union select e.emp_code || '-----' || e.emp_name || '-----' || to_char(a.going_dt), e.emp_code || '-----' || e.emp_name || '*' || d.dep_name || '*' || ds.designation || '*' || p.post_name || '*' || b.branch_name || '*' || to_char(a.going_dt) || '*' || a.reason from othleave_sanction_authority t, hrm_earlygoing_appl a,employee_master e,department_mst d,designation_master ds,post_mst p,branch b where a.emp_code = e.emp_code  and a.status in (0)  and t.emp_id = a.emp_code  and t.erly_recby = " & sf(0) & "  and e.department_id = d.dep_id  and e.designation_id = ds.designation_id and e.post_id = p.post_id and e.branch_id=b.BRANCH_ID").Tables(0)
            '  End If
            If dt.Rows.Count > 0 Then
                cmb_emp.DataSource = dt
                cmb_emp.DataValueField = dt.Columns(1).ColumnName
                cmb_emp.DataTextField = dt.Columns(0).ColumnName
                cmb_emp.DataBind()
            End If

        End If
    End Sub
End Class
