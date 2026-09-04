Imports System.Data
Imports System.Data.OracleClient
Partial Class payroll_newappln1_bfc6228f3070
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim val, ld, flag, appln_no As Integer
    Dim dt, dt1, dt2, dt3, dt4 As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("access_id") = 33 Then
            If Not IsPostBack Then
                val = 0
                ld = 1
                flag = 0
                statefill(Me.cmb_perm_state, Me.cmb_perm_district, Me.cmb_perm_post, Me.txt_perm_pin)
                statefill(Me.cmb_pres_state, Me.cmb_pres_district, Me.cmb_pres_post, Me.txt_pres_pin)
                bloodfill()
                religionfill()
                idfill()
                empfill()
                nearbrfill()
            End If
            If Me.cmb_vacanysource.SelectedValue = 0 Then
                Me.pnl_vacancy.Visible = True
                Me.pnl_other.Visible = False
            ElseIf Me.cmb_vacanysource.SelectedValue = 4 Then
                Me.pnl_other.Visible = True
                Me.pnl_vacancy.Visible = False
            Else
                Me.pnl_vacancy.Visible = False
                Me.pnl_other.Visible = False
            End If
        Else
            Response.Redirect("../../show_err.aspx")
        End If
        
    End Sub
    Sub nearbrfill()
        dt1 = oh.ExecuteDataSet("select 0,' SELECT' branch_name,0 STATE_ID  from dual union select branch_id,branch_name,state_id from branch_master where branch_id not in (0,9999) order by branch_name").Tables(0)
        Me.cmb_nrbr.DataSource = dt1
        Me.cmb_nrbr.DataTextField = dt1.Columns(1).ColumnName
        Me.cmb_nrbr.DataValueField = dt1.Columns(0).ColumnName
        Me.cmb_nrbr.DataBind()
    End Sub
    Sub statefill(ByVal a As DropDownList, ByVal b As DropDownList, ByVal c As DropDownList, ByVal d As TextBox)
        dt1 = oh.ExecuteDataSet("select upper(state_name),state_id from state_master order by upper(state_name) ").Tables(0)
        a.DataSource = dt1
        a.DataTextField = dt1.Columns(0).ColumnName
        a.DataValueField = dt1.Columns(1).ColumnName
        a.DataBind()
        If a.Items.Count > 0 Then
            districtfill(a, b, c, d)
        End If
    End Sub
    Sub districtfill(ByVal a As DropDownList, ByVal b As DropDownList, ByVal c As DropDownList, ByVal d As TextBox)
        dt2 = oh.ExecuteDataSet("select upper(district_name),district_id from district_master where state_id='" & a.SelectedValue & "' order by upper(district_name) ").Tables(0)
        b.DataSource = dt2
        b.DataTextField = dt2.Columns(0).ColumnName
        b.DataValueField = dt2.Columns(1).ColumnName
        b.DataBind()
        If b.Items.Count > 0 Then
            postfill(b, c, d)
        End If
    End Sub
    Sub postfill(ByVal b As DropDownList, ByVal c As DropDownList, ByVal d As TextBox)
        dt3 = oh.ExecuteDataSet("select upper(post_office),sr_number from post_master where district_id='" & b.SelectedValue & "' order by upper(post_office) ").Tables(0)
        c.DataSource = dt3
        c.DataTextField = dt3.Columns(0).ColumnName
        c.DataValueField = dt3.Columns(1).ColumnName
        c.DataBind()
        If c.Items.Count > 0 Then
            pinfill(d, c)
        End If
    End Sub
    Sub pinfill(ByVal d As TextBox, ByVal c As DropDownList)
        dt4 = oh.ExecuteDataSet("select pin_code from post_master where sr_number ='" & c.SelectedValue & "'").Tables(0)
        d.Text = dt4.Rows(0)(0)
    End Sub

    Protected Sub cmb_perm_state_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.cmb_perm_district.Items.Clear()
        Me.cmb_perm_post.Items.Clear()
        Me.txt_perm_pin.Text = ""
        If Me.cmb_perm_state.Items.Count > 0 Then
            districtfill(cmb_perm_state, cmb_perm_district, cmb_perm_post, txt_perm_pin)
        End If
    End Sub

    Protected Sub cmb_perm_district_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.cmb_perm_post.Items.Clear()
        Me.txt_perm_pin.Text = ""
        If Me.cmb_perm_district.Items.Count > 0 Then
            postfill(cmb_perm_district, cmb_perm_post, txt_perm_pin)
        End If
    End Sub

    Protected Sub cmb_perm_post_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.txt_perm_pin.Text = ""
        If Me.cmb_perm_post.Items.Count > 0 Then
            pinfill(Me.txt_perm_pin, Me.cmb_perm_post)
        End If
    End Sub

    Protected Sub chk_add_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Me.chk_add.Checked = True) Then
            dt2 = oh.ExecuteDataSet("select upper(post_office),sr_number from post_master where district_id ='" & Me.cmb_perm_district.SelectedValue & "' order by upper(post_office) ").Tables(0)
            Me.cmb_pres_post.DataSource = dt2
            Me.cmb_pres_post.DataTextField = dt2.Columns(0).ColumnName
            Me.cmb_pres_post.DataValueField = dt2.Columns(1).ColumnName
            Me.cmb_pres_post.DataBind()
            Me.txt_Pres_hs_name.Text = Me.txt_Perm_hs_name.Text
            Me.cmb_pres_state.SelectedItem.Text = Me.cmb_perm_state.SelectedItem.Text
            Me.cmb_pres_district.SelectedItem.Text = Me.cmb_perm_district.SelectedItem.Text
            Me.cmb_pres_post.SelectedItem.Text = Me.cmb_perm_post.SelectedItem.Text
            Me.txt_pres_pin.Text = Me.txt_perm_pin.Text
            Me.hd_post.Value = Me.cmb_perm_post.SelectedValue
            Me.cmb_pres_post.SelectedValue = Me.hd_post.Value
        Else
            Me.txt_Pres_hs_name.Text = ""
        End If
    End Sub

    Protected Sub cmb_pres_state_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.cmb_pres_district.Items.Clear()
        Me.cmb_pres_post.Items.Clear()
        Me.txt_pres_pin.Text = ""
        If Me.cmb_pres_state.Items.Count > 0 Then
            districtfill(Me.cmb_pres_state, Me.cmb_pres_district, Me.cmb_pres_post, Me.txt_pres_pin)
        End If
    End Sub

    Protected Sub cmb_pres_district_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.cmb_pres_post.Items.Clear()
        Me.txt_pres_pin.Text = ""
        If Me.cmb_pres_district.Items.Count > 0 Then
            postfill(Me.cmb_pres_district, Me.cmb_pres_post, Me.txt_pres_pin)
        End If
    End Sub

    Protected Sub cmb_pres_post_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.txt_pres_pin.Text = ""
        If Me.cmb_pres_post.Items.Count > 0 Then
            pinfill(Me.txt_pres_pin, Me.cmb_pres_post)
        End If
    End Sub

    Protected Sub txt_dob_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dte, dte1 As Date
        Dim age As Integer
        dte = Me.txt_dob.Text
        dte1 = Now.Date
        age = DateDiff(DateInterval.Year, dte, dte1)
        Me.txt_age.Text = age
        If age < 18 Then
            Me.txt_dob.Text = ""
        End If
    End Sub

    Protected Sub rd_marital_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.rd_marital.SelectedValue = 2 Then
            Me.txt_spousename.Visible = True
            Me.txt_child.Visible = True
            Me.lbl_no.Visible = True
            Me.lbl_spouse.Visible = True
        ElseIf Me.rd_marital.SelectedValue = 1 Then
            Me.txt_spousename.Visible = False
            Me.txt_child.Visible = False
            Me.lbl_no.Visible = False
            Me.lbl_spouse.Visible = False
        End If
    End Sub
    Sub bloodfill()
        dt = oh.ExecuteDataSet("select blood_type,blood_id from bloodgroup_master order by blood_id").Tables(0)
        Me.cmb_bloodgp.DataSource = dt
        Me.cmb_bloodgp.DataTextField = dt.Columns(0).ColumnName
        Me.cmb_bloodgp.DataValueField = dt.Columns(1).ColumnName
        Me.cmb_bloodgp.DataBind()
    End Sub
    Sub religionfill()
        dt = oh.ExecuteDataSet("select religion,religion_id from religion_master order by religion_id").Tables(0)
        Me.cmb_religion.DataSource = dt
        Me.cmb_religion.DataTextField = dt.Columns(0).ColumnName
        Me.cmb_religion.DataValueField = dt.Columns(1).ColumnName
        Me.cmb_religion.DataBind()
    End Sub
    Sub idfill()
        dt = oh.ExecuteDataSet("select identity_name,identity_id from identity_gl4 order by identity_id").Tables(0)
        Me.cmb_idproof.DataSource = dt
        Me.cmb_idproof.DataTextField = dt.Columns(0).ColumnName
        Me.cmb_idproof.DataValueField = dt.Columns(1).ColumnName
        Me.cmb_idproof.DataBind()
    End Sub

    'Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
   
    'End Sub

    Protected Sub cmb_vacanysource_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.cmb_vacanysource.SelectedValue = 0 Then
            Me.pnl_vacancy.Visible = True
            Me.pnl_other.Visible = False
        ElseIf Me.cmb_vacanysource.SelectedValue = 4 Then
            Me.pnl_other.Visible = True
            Me.pnl_vacancy.Visible = False
        Else
            Me.pnl_vacancy.Visible = False
            Me.pnl_other.Visible = False
        End If
    End Sub
    Sub empfill()
        Dim emp As New DataTable
        emp = oh.ExecuteDataSet("select emp_code,emp_code||'-'||emp_name from employee_master where emp_code>9999 and status_id=1 order by emp_code").Tables(0)
        Me.cmb_emp.DataSource = emp
        Me.cmb_emp.DataTextField = emp.Columns(1).ColumnName
        Me.cmb_emp.DataValueField = emp.Columns(0).ColumnName
        Me.cmb_emp.DataBind()
    End Sub

    'Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
    '    Server.Transfer("../../home.aspx")
    'End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If Me.rd_marital.SelectedValue = 2 Then
            If Me.txt_spousename.Text = "" Then
                Dim cl_script01 As New System.Text.StringBuilder
                cl_script01.Append("         alert(' Enter Spouse Name ');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script01.ToString, True)
                Exit Sub
            End If
        End If
        If Me.txt_caste.Text = "" Then
            Dim cl_script01 As New System.Text.StringBuilder
            cl_script01.Append("         alert(' Enter Caste ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script01.ToString, True)
        ElseIf Me.txt_idno.Text = "" Then
            Dim cl_script01 As New System.Text.StringBuilder
            cl_script01.Append("         alert(' Enter ID Proof Details ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script01.ToString, True)
        ElseIf Me.txt_fathus.Text = "" Then
            Dim cl_script01 As New System.Text.StringBuilder
            cl_script01.Append("         alert(' Enter Father Name ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script01.ToString, True)
        ElseIf Me.cmb_nrbr.Value = 0 Then
            Dim cl_script01 As New System.Text.StringBuilder
            cl_script01.Append("         alert(' Select the Near Branch in Your Location ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script01.ToString, True)
        Else
            Dim oh As New Helper.Oracle.OracleHelper
            Dim op(25) As OracleParameter
            op(0) = New OracleParameter("c_name", OracleType.VarChar, 40)
            op(0).Value = Me.txt_name.Text
            op(0).Direction = ParameterDirection.Input

            op(1) = New OracleParameter("cperm_add", OracleType.VarChar, 50)
            op(1).Value = Me.txt_Perm_hs_name.Text
            op(1).Direction = ParameterDirection.Input

            op(2) = New OracleParameter("cpres_add", OracleType.VarChar, 50)
            op(2).Value = Me.txt_Pres_hs_name.Text
            op(2).Direction = ParameterDirection.Input

            op(3) = New OracleParameter("cperm_pin", OracleType.Number, 7)
            op(3).Value = Me.cmb_perm_post.SelectedValue
            op(3).Direction = ParameterDirection.Input

            op(4) = New OracleParameter("cpres_pin", OracleType.Number, 7)
            op(4).Value = Me.cmb_pres_post.SelectedValue
            op(4).Direction = ParameterDirection.Input

            op(5) = New OracleParameter("c_landmark", OracleType.VarChar, 60)
            op(5).Value = Me.txt_lankmark.Text
            op(5).Direction = ParameterDirection.Input

            op(6) = New OracleParameter("c_pp", OracleType.Number, 1)
            If Me.chk_pp.Checked = True Then
                op(6).Value = 1
            Else
                op(6).Value = 0
            End If
            op(6).Direction = ParameterDirection.Input

            op(7) = New OracleParameter("c_resphone", OracleType.VarChar, 15)
            op(7).Value = Me.txt_phone.Text
            op(7).Direction = ParameterDirection.Input

            op(8) = New OracleParameter("c_contno", OracleType.VarChar, 15)
            op(8).Value = Me.txt_contactno.Text
            op(8).Direction = ParameterDirection.Input

            op(9) = New OracleParameter("c_email", OracleType.VarChar, 30)
            op(9).Value = Me.txt_email.Text
            op(9).Direction = ParameterDirection.Input

            op(10) = New OracleParameter("c_gender", OracleType.Number, 1)
            op(10).Value = Me.rd_gender.SelectedValue
            op(10).Direction = ParameterDirection.Input

            op(11) = New OracleParameter("c_marital", OracleType.Number, 1)
            op(11).Value = Me.rd_marital.SelectedValue
            op(11).Direction = ParameterDirection.Input

            op(12) = New OracleParameter("c_father", OracleType.VarChar, 40)
            op(12).Value = Me.txt_fathus.Text
            op(12).Direction = ParameterDirection.Input

            op(13) = New OracleParameter("c_spouse", OracleType.VarChar, 40)
            If Me.rd_marital.SelectedValue = 2 Then
                op(13).Value = Me.txt_spousename.Text
            Else
                op(13).Value = ""
            End If
            op(13).Direction = ParameterDirection.Input

            op(14) = New OracleParameter("c_child", OracleType.Number, 2)
            If Me.rd_marital.SelectedValue = 2 Then
                op(14).Value = Me.txt_child.Text
            Else
                op(14).Value = 0
            End If
            op(14).Direction = ParameterDirection.Input

            op(15) = New OracleParameter("c_dob", OracleType.DateTime)
            op(15).Value = Me.txt_dob.Text
            op(15).Direction = ParameterDirection.Input

            op(16) = New OracleParameter("c_religion", OracleType.Number, 2)
            op(16).Value = Me.cmb_religion.SelectedValue
            op(16).Direction = ParameterDirection.Input

            op(17) = New OracleParameter("c_caste", OracleType.VarChar, 15)
            op(17).Value = Me.txt_caste.Text
            op(17).Direction = ParameterDirection.Input

            op(18) = New OracleParameter("c_idproof", OracleType.Number, 2)
            op(18).Value = Me.cmb_idproof.SelectedValue
            op(18).Direction = ParameterDirection.Input

            op(19) = New OracleParameter("c_idno", OracleType.VarChar, 25)
            op(19).Value = Me.txt_idno.Text
            op(19).Direction = ParameterDirection.Input

            op(20) = New OracleParameter("c_bloodgp", OracleType.Number, 2)
            op(20).Value = Me.cmb_bloodgp.SelectedValue
            op(20).Direction = ParameterDirection.Input
            op(21) = New OracleParameter("vacancy_info", OracleType.Number, 2)
            op(21).Value = Me.cmb_vacanysource.SelectedValue
            op(21).Direction = ParameterDirection.Input
            op(22) = New OracleParameter("emp_ref", OracleType.Number, 5)
            op(23) = New OracleParameter("v_other", OracleType.VarChar, 100)
            If Me.cmb_vacanysource.SelectedValue = 0 Then
                op(22).Value = Me.cmb_emp.SelectedValue
                op(23).Value = ""
            ElseIf Me.cmb_vacanysource.SelectedValue = 4 Then
                op(22).Value = 0
                op(23).Value = Me.txt_other.Text
            Else
                op(22).Value = 0
                op(23).Value = ""
            End If
            op(22).Direction = ParameterDirection.Input
            op(23).Direction = ParameterDirection.Input
            op(24) = New OracleParameter("c_appln_no", OracleType.Number, 8)
            op(24).Direction = ParameterDirection.Output
            op(25) = New OracleParameter("nrbr", OracleType.Number, 4)
            op(25).Value = Me.cmb_nrbr.Value
            op(25).Direction = ParameterDirection.Input
            oh.ExecuteNonQuery("new_appln12", op)
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' Sucessfully Confirmed Appln No: " & op(24).Value & "');")
            cl_script0.Append("       window.open('newapplnexp.aspx?appno=" & op(24).Value & " ','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        End If
    End Sub
End Class
