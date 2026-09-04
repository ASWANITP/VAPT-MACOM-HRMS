Imports System.Data
Imports System.Data.OracleClient
Partial Class Employee_Punching_Movement_Approval_OPHead_2bda143a1379
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dtj, ceo, depp As New DataTable
    Dim sf() As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_purp.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Dim dep1 As String = " "
        Dim fid As Integer = Session("firm_id")
        If fid = 28 Then
            If Not IsPostBack Then
                'Access checking 5187  OP Head
                Dim str As String = "select count(*) from form_accessibility s where s.form_id=5187 and s.emp_id=" & User(0) & ""
                dt = oh.ExecuteDataSet(str).Tables(0)
                If (dt.Rows(0)(0) = 0) Then
                    Response.Redirect("~/show_err.aspx")
                    'Server.Transfer("../../show_err.aspx")
                    Return
                End If
                loadfile()
            End If

            Me.Text_RJTRSN.Visible = False
            Me.New_Reject.Visible = False
        Else
            Response.Redirect("~/show_err.aspx")
        End If

    End Sub


    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click

        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")

        Dim dt2 As DataTable
        dt2 = oh.ExecuteDataSet("select sysdate from dual").Tables(0)
        Dim arr, arr1 As Array

        arr = Me.cmb_emp.SelectedValue.Split("*")
        arr1 = arr(0).split("-----")




        Dim script1 As New System.Text.StringBuilder
        Try
            Dim parameter(5) As OracleParameter

            parameter(0) = New OracleParameter("emp_id", OracleType.Number, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = arr1(0)

            parameter(1) = New OracleParameter("san_emp_code", OracleType.Number, 150)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = sf(0)

            parameter(2) = New OracleParameter("btn_type", OracleType.Number, 150)
            parameter(2).Direction = ParameterDirection.Input
            parameter(2).Value = 1

            parameter(3) = New OracleParameter("rej_reas", OracleType.VarChar, 350)
            parameter(3).Direction = ParameterDirection.Input
            parameter(3).Value = Text_RJTRSN.Text

            parameter(4) = New OracleParameter("err_msg", OracleType.VarChar, 5000)
            parameter(4).Direction = ParameterDirection.Output

            parameter(5) = New OracleParameter("go_dt", OracleType.DateTime, 150)
            parameter(5).Direction = ParameterDirection.Input
            parameter(5).Value = Format(CDate(Me.Txt_fdt.Text), "dd/MMM/yyyy")

            oh.ExecuteNonQuery(" hrm_movement_OPsan", parameter)

            Dim message As String
            message = parameter(4).Value



            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("                        alert('" & message & "');")
            loadfile()
            'script1.Append("window.open('Movement_Approval_CEO.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            loadfile()


        Catch ex As Exception

        End Try



    End Sub
    Sub loadfile()
        sf = Session("user_id").ToString.Split("!")

        Me.Txt_br.Value = ""
        Me.Txt_dep.Value = ""
        Me.Txt_des.Value = ""
        Me.Txt_emp.Value = ""
        Me.Txt_fdt.Text = ""
        Me.Txt_post.Value = ""
        Me.Txt_purp.Text = ""
        cmb_emp.SelectedValue = 0

        Me.Txt_To.Text = ""
        Me.Txt_From.Text = ""

        dt = oh.ExecuteDataSet("select '----SELECT----','0' as empcode from dual union select e.emp_code || '-----' || e.emp_name || '-----' || to_char(a.going_dt), e.emp_code || '-----' || e.emp_name || '*' || d.dep_name || '*' || ds.designation || '*' || p.post_name || '*' || b.branch_name || '*' || to_char(a.going_dt) || '*' ||a.frm_time||'*'||a.to_time||'*'|| a.reason from hrm_movement_appl a, employee_master e, department_mst d, designation_master ds, post_mst p, branch b where a.emp_code = e.emp_code and a.status in (0) and e.department_id = d.dep_id and e.designation_id = ds.designation_id and e.post_id = p.post_id  and e.post_id not in 976 and e.branch_id = b.BRANCH_ID ").Tables(0)
        If dt.Rows.Count > 0 Then
            cmb_emp.DataSource = dt
            cmb_emp.DataValueField = dt.Columns(1).ColumnName
            cmb_emp.DataTextField = dt.Columns(0).ColumnName
            cmb_emp.DataBind()
        End If
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
        Me.Txt_From.Text = arr(6)
        Me.Txt_To.Text = arr(7)
        Me.Txt_purp.Text = arr(8)
    End Sub

    Protected Sub cmd_reject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_reject.Click
        Me.Text_RJTRSN.Visible = True
        Me.New_Reject.Visible = True
        Me.cmd_reject.Visible = False
        Me.cmd_confirm.Enabled = False
    End Sub

    Protected Sub New_Reject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles New_Reject.Click
        Me.cmd_confirm.Enabled = False
        If (Text_RJTRSN.Text = "") Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Enter Rejected Reason..!!');")
            cl_script1.Append(" window.open('Movement_Approval_CEO.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else

            Dim sf() As String
            sf = Session("user_id").ToString.Split("!")
            '        Dim sf As Integer = 10584
            Dim dt2, dt3 As DataTable
            dt2 = oh.ExecuteDataSet("select sysdate from dual").Tables(0)
            Dim arr, arr1 As Array

            arr = Me.cmb_emp.SelectedValue.Split("*")
            arr1 = arr(0).split("-----")


            Dim script1 As New System.Text.StringBuilder
            Try
                Dim parameter(5) As OracleParameter

                parameter(0) = New OracleParameter("emp_id", OracleType.Number, 150)
                parameter(0).Direction = ParameterDirection.Input
                parameter(0).Value = arr1(0)

                parameter(1) = New OracleParameter("san_emp_code", OracleType.Number, 150)
                parameter(1).Direction = ParameterDirection.Input
                parameter(1).Value = sf(0)

                parameter(2) = New OracleParameter("btn_type", OracleType.Number, 150)
                parameter(2).Direction = ParameterDirection.Input
                parameter(2).Value = 0

                parameter(3) = New OracleParameter("rej_reas", OracleType.VarChar, 350)
                parameter(3).Direction = ParameterDirection.Input
                parameter(3).Value = Text_RJTRSN.Text

                parameter(4) = New OracleParameter("err_msg", OracleType.VarChar, 5000)
                parameter(4).Direction = ParameterDirection.Output

                parameter(5) = New OracleParameter("go_dt", OracleType.DateTime, 150)
                parameter(5).Direction = ParameterDirection.Input
                parameter(5).Value = Format(CDate(Me.Txt_fdt.Text), "dd/MMM/yyyy")

                oh.ExecuteNonQuery(" hrm_movement_OPsan", parameter)


                script1.Append("                             alert('" & parameter(4).Value & "');")
                loadfile()
                'script1.Append("window.open('movementslip_mfdtn.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)



            Catch ex As Exception

            End Try

        End If
    End Sub

    Protected Sub Cmd_Exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Response.Redirect("~/home.aspx")
    End Sub
End Class

