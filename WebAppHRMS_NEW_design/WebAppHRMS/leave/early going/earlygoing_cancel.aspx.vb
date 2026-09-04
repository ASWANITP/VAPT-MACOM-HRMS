Imports System.Data
Imports System.Data.OracleClient
Partial Class november_tour_Tour_apply_5ace8aa12470
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
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
        If Not IsPostBack Then
            Dim dep As String = " "
            sf = Session("user_id").ToString.Split("!")
            Dim brid As Integer = Me.Session("branch_id")
            Dim dtr As DataTable = oh.ExecuteDataSet("select branch_id,department_id,post_id from employee_master where emp_code=" & sf(0) & " and status_id=1").Tables(0)
            dt = oh.ExecuteDataSet("select e.emp_code||'-----'||e.emp_name||'-----'||to_char(w.going_dt),e.emp_code||'-----'||e.emp_name||'*'||d.dep_name||'*'||ds.designation||'*'||p.post_name||'*'||b.branch_name||'*'||to_char(w.going_dt)||'*'||w.reason from employee_master e,department_mst d,designation_master ds,post_mst p,branch b,hrm_earlygoing_appl w where w.emp_code=e.emp_code and w.status =0 and e.emp_code=" & sf(0) & " and e.department_id=d.dep_id and e.designation_id=ds.designation_id and e.post_id=p.post_id and e.branch_id=b.branch_id").Tables(0)
            '  End If
            If dt.Rows.Count > 0 Then
                cmb_emp.DataSource = dt
                cmb_emp.DataValueField = dt.Columns(1).ColumnName
                cmb_emp.DataTextField = dt.Columns(0).ColumnName
                cmb_emp.DataBind()

                Dim arr As Array
                arr = Me.cmb_emp.SelectedValue.Split("*")
                Me.Txt_emp.Value = arr(0)
                Me.Txt_dep.Value = arr(1)
                Me.Txt_des.Value = arr(2)
                Me.Txt_post.Value = arr(3)
                Me.Txt_br.Value = arr(4)
                Me.Txt_fdt.Text = arr(5)
                Me.Txt_purp.Text = arr(6)
            Else
                Dim script1 As New System.Text.StringBuilder
                script1.Append("        alert('No Application Exist');")
                script1.Append("window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
                Exit Sub
            End If
        End If
        ' Dim pp As DataTable = oh.ExecuteDataSet("select department_id from employee_master where emp_code=" & sf(0) & " and status_id=1").Tables(0)
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click

        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        Dim dt2 As DataTable
        dt2 = oh.ExecuteDataSet("select sysdate from dual").Tables(0)
        Dim script1 As New System.Text.StringBuilder
        Dim arr, arr1 As Array
        arr = Me.cmb_emp.SelectedValue.Split("*")
        arr1 = arr(0).split("-----")

        Dim parameter(4) As OracleParameter
        parameter(0) = New OracleParameter("emp_id", OracleType.Number, 150)
        parameter(0).Direction = ParameterDirection.Input
        parameter(0).Value = sf(0)

        parameter(1) = New OracleParameter("go_date", OracleType.DateTime, 150)
        parameter(1).Direction = ParameterDirection.Input
        parameter(1).Value = Format(CDate(Me.Txt_fdt.Text), "dd/MMM/yyyy")

        parameter(2) = New OracleParameter("rec_san_emp_code", OracleType.Number, 150)
        parameter(2).Direction = ParameterDirection.Input
        ' parameter(2).Value = sf(0)
        parameter(2).Value = sf(0)

        parameter(3) = New OracleParameter("btn_type", OracleType.Number, 150)
        parameter(3).Direction = ParameterDirection.Input
        parameter(3).Value = 2

        parameter(4) = New OracleParameter("err_msg", OracleType.VarChar, 5000)
        parameter(4).Direction = ParameterDirection.Output
        'oh.ExecuteNonQuery("hrm_tour_apply", parameter)

        oh.ExecuteNonQuery("hrm_earlygoing_san", parameter) 'as testing

        'Dim parameter(2) As OracleParameter
        'parameter(0) = New OracleParameter("emp_id", OracleType.Number, 150)
        'parameter(0).Direction = ParameterDirection.Input
        'parameter(0).Value = sf(0)
        'parameter(1) = New OracleParameter("go_date", OracleType.DateTime, 150)
        'parameter(1).Direction = ParameterDirection.Input
        'parameter(1).Value = Format(CDate(Me.Txt_fdt.Text), "dd/MMM/yyyy")
        'parameter(2) = New OracleParameter("err_msg", OracleType.VarChar, 5000)
        'parameter(2).Direction = ParameterDirection.Output
        ''oh.ExecuteNonQuery("hrm_tour_apply", parameter)
        'oh.ExecuteNonQuery("hrm_earlygoing_san", parameter)    'as testing

        Dim message As String
        message = parameter(4).Value

        script1.Append("        alert('" & message & "');")
        script1.Append("window.open('earlygoing_cancel.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)




    End Sub

  
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

    
End Class
