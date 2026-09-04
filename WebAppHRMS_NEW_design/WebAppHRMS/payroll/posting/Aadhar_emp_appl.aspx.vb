Imports System.Data
Imports System.Data.OracleClient
Partial Class test_Aadhar_emp_appl_aba36d805593
    Inherits System.Web.UI.Page
    Dim res, fid As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim val, ld, flag, appln_no As Integer
    Dim dt, dt1, dt2, dt3, dt4, emp_dt As New DataTable


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim cs As String = "var cont_name;cont_name='" & Me.rd_marital_yes.ClientID & "';"
        'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        Dim script1 As New System.Text.StringBuilder

        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "ADD / EDIT APPLICATION"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.subtitle = "ADD / EDIT APPLICATION"
        fid = Session("firm_id")
        If Not fid = 8 Then
            script1.Append("        alert('Only For Macom Entrollment..!!');")
            script1.Append("       window.open('../home.aspx ','_self');")

            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If

        Me.Rado_ad.Checked = True


        If Me.Checkbox3.Checked = True Then
            Me.Checkbox4.Checked = False
        ElseIf Me.Checkbox4.Checked = True Then
            Me.Checkbox3.Checked = False
        Else
            Me.Checkbox3.Checked = True

        End If

        If Session("access_id") = 33 Then
            If Not IsPostBack Then
                dt1 = oh.ExecuteDataSet("select 0,'---SELECT---' branch_name,0 STATE_ID  from dual union select branch_id,branch_name,state_id from branch_master where branch_id not in (0,9999) order by branch_name").Tables(0)
                Me.cmb_nrbr.DataSource = dt1
                Me.cmb_nrbr.DataTextField = dt1.Columns(1).ColumnName
                Me.cmb_nrbr.DataValueField = dt1.Columns(0).ColumnName
                Me.cmb_nrbr.DataBind()

                dt = oh.ExecuteDataSet("select blood_type,blood_id from bloodgroup_master order by blood_id").Tables(0)
                Me.cmb_bloodgp.DataSource = dt
                Me.cmb_bloodgp.DataTextField = dt.Columns(0).ColumnName
                Me.cmb_bloodgp.DataValueField = dt.Columns(1).ColumnName
                Me.cmb_bloodgp.DataBind()


                dt = oh.ExecuteDataSet("select identity_name,identity_id from identity_gl4 order by identity_id").Tables(0)
                Me.cmb_idproof.DataSource = dt
                Me.cmb_idproof.DataTextField = dt.Columns(0).ColumnName
                Me.cmb_idproof.DataValueField = dt.Columns(1).ColumnName
                Me.cmb_idproof.DataBind()



                dt = oh.ExecuteDataSet("select religion,religion_id from religion_master order by religion_id").Tables(0)
                Me.cmb_religion.DataSource = dt
                Me.cmb_religion.DataTextField = dt.Columns(0).ColumnName
                Me.cmb_religion.DataValueField = dt.Columns(1).ColumnName
                Me.cmb_religion.DataBind()
            End If
        Else
            Response.Redirect("../show_err.aspx")
        End If
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim script1 As New System.Text.StringBuilder



        If Me.txt_adhar.Value = "" Then
            script1.Append("        alert('Please Enter Aadhar Number..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            'ElseIf Me.txt_adhar.Value.ToString.Length < 12 Then

            'script1.Append("        alert('Please Enter Valid Aadhar Number..!!');")
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf Me.Text_post.Value = "" Then
            script1.Append("        alert('Please Enter Post..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf Me.txt_Perm_hs_name.Text = "" Or Me.Text_perm_state.Text = "" Or Me.txt_perm_pin.Text = "" Or Me.Text_perm_dis.Text = "" Or Me.Text_perm_post.Text = "" Then
            script1.Append("        alert('Please Add Full  Permanant Address..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf Me.txt_Pres_hs_name.Text = "" Or Me.Text_pers_state.Text = "" Or Me.Text_pers_dis.Text = "" Or Me.txt_pres_pin.Text = "" Or Me.Text_pers_post.Text = "" Then
            script1.Append("        alert('Please Add Full  Present Address ..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf Me.txt_lankmark.Text = "" Then
            script1.Append("        alert('Please Enter  Landmark..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf Me.txt_phone.Text = "" Then
            script1.Append("        alert('Please Enter Phone Number ..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        ElseIf Me.txt_contactno.Text = "" Then
            script1.Append("        alert('Please Enter Contact Number ..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)


        ElseIf Me.cmb_religion.SelectedValue = "" Then
            script1.Append("        alert('Please Select Religion ..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf Me.txt_email.Text = "" Then
            script1.Append("        alert('Please Enter Email id..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf Me.txt_fathus.Text = "" Then
            script1.Append("        alert('Please enter Father/Husbant Name ..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf Me.RadioButtonList1.SelectedValue = 1 Then


            If Me.txt_spousename.Text = "" Then
                script1.Append("        alert('Please Enter spouse Name ..!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

            ElseIf Me.txt_child.Text = "" Then
                script1.Append("        alert('Please Enter No of Child..!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

            End If

            If Me.txt_caste.Text = "" Then
                script1.Append("        alert('Please Enter Cast ..!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

            ElseIf Me.txt_idno.Text = "" Then
                script1.Append("        alert('Please Enter Id Number ..!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            ElseIf Me.txt_sslc.Text = "" Then
                script1.Append("        alert('Please Enter SSLC no ..!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

            ElseIf Me.cmb_nrbr.SelectedIndex = 0 Then
                script1.Append("        alert('Please Select Nearest  Manappuram Branch In Your Location ..!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Else

                Dim oh As New Helper.Oracle.OracleHelper
                Dim op(27) As OracleParameter
                op(0) = New OracleParameter("c_name", OracleType.VarChar, 40)
                op(0).Value = Me.txt_name.Value
                op(0).Direction = ParameterDirection.Input

                op(1) = New OracleParameter("cperm_add", OracleType.VarChar, 50)
                op(1).Value = Me.txt_Perm_hs_name.Text
                op(1).Direction = ParameterDirection.Input

                op(2) = New OracleParameter("cpres_add", OracleType.VarChar, 50)
                op(2).Value = Me.txt_Pres_hs_name.Text
                op(2).Direction = ParameterDirection.Input

                op(3) = New OracleParameter("cperm_pin", OracleType.Number, 7)
                op(3).Value = Me.txt_perm_pin.Text
                op(3).Direction = ParameterDirection.Input

                op(4) = New OracleParameter("cpres_pin", OracleType.Number, 7)
                op(4).Value = Me.txt_pres_pin.Text
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

                Dim pq As Integer
                If Me.RadioButtonList1.SelectedValue = 1 Then
                    pq = 2
                Else
                    pq = 3
                End If
                op(11) = New OracleParameter("c_marital", OracleType.Number, 1)
                op(11).Value = pq
                op(11).Direction = ParameterDirection.Input

                op(12) = New OracleParameter("c_father", OracleType.VarChar, 40)
                op(12).Value = Me.txt_fathus.Text
                op(12).Direction = ParameterDirection.Input

                op(13) = New OracleParameter("c_spouse", OracleType.VarChar, 40)
                If pq = 2 Then
                    op(13).Value = Me.txt_spousename.Text
                Else
                    op(13).Value = ""
                End If
                op(13).Direction = ParameterDirection.Input

                op(14) = New OracleParameter("c_child", OracleType.Number, 2)
                If pq = 2 Then
                    op(14).Value = Me.txt_child.Text
                Else
                    op(14).Value = 0
                End If
                op(14).Direction = ParameterDirection.Input

                op(15) = New OracleParameter("c_dob", OracleType.DateTime)
                op(15).Value = Me.txt_dob.Value
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
                    'op(22).Value = Me.cmb_emp.SelectedValue
                    op(22).Value = Me.hid_emp.Value
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
                op(24) = New OracleParameter("c_appln_no", OracleType.Char, 200)
                op(24).Direction = ParameterDirection.Output
                op(25) = New OracleParameter("nrbr", OracleType.Number, 4)
                op(25).Value = Me.cmb_nrbr.Value
                op(25).Direction = ParameterDirection.Input
                op(27) = New OracleParameter("sslcno", OracleType.VarChar, 20)
                op(27).Value = Me.txt_sslc.Text
                op(27).Direction = ParameterDirection.Input

                op(26) = New OracleParameter("flag", OracleType.Number, 2)
                op(26).Direction = ParameterDirection.Output

                oh.ExecuteNonQuery("HRM_NEW_APPLN", op)
                Dim cl_script0 As New System.Text.StringBuilder
                If op(26).Value = 1 Then
                    cl_script0.Append("         alert(' Sucessfully Confirmed Application No: " & op(24).Value & "');")
                    cl_script0.Append("       window.open('hrm_qualification_add.aspx?appno=" & op(24).Value & " ','_self');")
                Else
                    cl_script0.Append("         alert(" & op(24).Value & ");")
                End If

                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
            End If

        Else


            If Me.txt_caste.Text = "" Then
                script1.Append("        alert('Please Enter Cast ..!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

            ElseIf Me.txt_idno.Text = "" Then
                script1.Append("        alert('Please Enter Id Number ..!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            ElseIf Me.txt_sslc.Text = "" Then
                script1.Append("        alert('Please Enter SSLC no ..!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

            ElseIf Me.cmb_nrbr.SelectedIndex = 0 Then
                script1.Append("        alert('Please Select Nearest  Manappuram Branch In Your Location ..!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Else

                Dim oh As New Helper.Oracle.OracleHelper
                Dim op(27) As OracleParameter
                op(0) = New OracleParameter("c_name", OracleType.VarChar, 40)
                op(0).Value = Me.txt_name.Value
                op(0).Direction = ParameterDirection.Input

                op(1) = New OracleParameter("cperm_add", OracleType.VarChar, 50)
                op(1).Value = Me.txt_Perm_hs_name.Text
                op(1).Direction = ParameterDirection.Input

                op(2) = New OracleParameter("cpres_add", OracleType.VarChar, 50)
                op(2).Value = Me.txt_Pres_hs_name.Text
                op(2).Direction = ParameterDirection.Input

                op(3) = New OracleParameter("cperm_pin", OracleType.Number, 7)
                op(3).Value = Me.txt_perm_pin.Text
                op(3).Direction = ParameterDirection.Input

                op(4) = New OracleParameter("cpres_pin", OracleType.Number, 7)
                op(4).Value = Me.txt_pres_pin.Text
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

                Dim pq As Integer
                If Me.RadioButtonList1.SelectedValue = 1 Then
                    pq = 2
                Else
                    pq = 3
                End If
                op(11) = New OracleParameter("c_marital", OracleType.Number, 1)
                op(11).Value = pq
                op(11).Direction = ParameterDirection.Input

                op(12) = New OracleParameter("c_father", OracleType.VarChar, 40)
                op(12).Value = Me.txt_fathus.Text
                op(12).Direction = ParameterDirection.Input

                op(13) = New OracleParameter("c_spouse", OracleType.VarChar, 40)
                If pq = 2 Then
                    op(13).Value = Me.txt_spousename.Text
                Else
                    op(13).Value = ""
                End If
                op(13).Direction = ParameterDirection.Input

                op(14) = New OracleParameter("c_child", OracleType.Number, 2)
                If pq = 2 Then
                    op(14).Value = Me.txt_child.Text
                Else
                    op(14).Value = 0
                End If
                op(14).Direction = ParameterDirection.Input

                op(15) = New OracleParameter("c_dob", OracleType.DateTime)
                op(15).Value = Me.txt_dob.Value
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
                    'op(22).Value = Me.cmb_emp.SelectedValue
                    op(22).Value = Me.hid_emp.Value
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
                op(24) = New OracleParameter("c_appln_no", OracleType.Char, 200)
                op(24).Direction = ParameterDirection.Output
                op(25) = New OracleParameter("nrbr", OracleType.Number, 4)
                op(25).Value = Me.cmb_nrbr.Value
                op(25).Direction = ParameterDirection.Input
                op(27) = New OracleParameter("sslcno", OracleType.VarChar, 20)
                op(27).Value = Me.txt_sslc.Text
                op(27).Direction = ParameterDirection.Input

                op(26) = New OracleParameter("flag", OracleType.Number, 2)
                op(26).Direction = ParameterDirection.Output

                oh.ExecuteNonQuery("HRM_NEW_APPLN", op)
                Dim cl_script0 As New System.Text.StringBuilder
                If op(26).Value = 1 Then
                    cl_script0.Append("         alert(' Sucessfully Confirmed Application No: " & op(24).Value & "');")
                    cl_script0.Append("       window.open('hrm_qualification_add.aspx?appno=" & op(24).Value & " ','_self');")
                Else
                    cl_script0.Append("         alert(" & op(24).Value & ");")
                End If

                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
            End If
        End If


    End Sub
    Protected Sub Button2_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.ServerClick
        If Me.Checkbox3.Checked = True Then
            Me.Checkbox4.Checked = False
            Me.txt_Perm_hs_name.Text = Me.txt_Perm_hs_select.Value
            Me.Text_perm_state.Text = Me.Text_state.Value
            Me.Text_perm_dis.Text = Me.Text_dist.Value
            Me.Text_perm_post.Text = Me.Text_post.Value
            Me.txt_perm_pin.Text = Me.Txt_pin_select.Value

        ElseIf Me.Checkbox4.Checked = True Then
            Me.Checkbox3.Checked = False
            Me.txt_Pres_hs_name.Text = Me.txt_Perm_hs_select.Value
            Me.Text_pers_state.Text = Me.Text_state.Value
            Me.Text_pers_dis.Text = Me.Text_dist.Value
            Me.Text_pers_post.Text = Me.Text_post.Value
            Me.txt_pres_pin.Text = Me.Txt_pin_select.Value
        End If
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If Me.RadioButtonList1.SelectedValue = 1 Then
            Me.row3.Visible = True
        Else
            Me.row3.Visible = False
        End If
    End Sub

    'Protected Sub txt_dob_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dob.TextChanged

    'End Sub

    'Protected Sub chk_add_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_add.CheckedChanged
    '    If Me.chk_add.Checked = True Then
    '        Me.txt_Pres_hs_name.Text = Me.txt_Perm_hs_name.Text
    '        Me.Text_pers_state.Text = Me.Text_perm_state.Text
    '        Me.Text_pers_dis.Text = Me.Text_perm_dis.Text
    '        Me.Text_pers_post.Text = Me.Text_perm_post.Text
    '        Me.txt_pres_pin.Text = Me.txt_perm_pin.Text
    '    End If
    'End Sub
End Class

