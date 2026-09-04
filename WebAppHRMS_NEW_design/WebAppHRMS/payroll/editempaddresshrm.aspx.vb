Imports System.Data
Imports System.Data.OracleClient
Partial Class new_edit_personal_and_qualification_details1_editempaddresshrm_4c6a90a03251
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim bg, re, id1, po As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txt_house1.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        If Session("access_id") = 33 Then
            If Not IsPostBack Then
                'Dim dt As DataTable = oh.ExecuteDataSet("select emp_code,emp_code || ' - ' || emp_name|| ' - ( ' || s.remark || ' )'from employee_master e,status_mst s where emp_code>9999 and e.status_id=s.status_id order by emp_code").Tables(0)
                'Me.cmb_code.DataSource = dt
                'Me.cmb_code.DataTextField = dt.Columns(1).ColumnName
                'Me.cmb_code.DataValueField = dt.Columns(0).ColumnName
                'Me.cmb_code.DataBind()

                'state 
                Dim state As DataTable
                state = oh.ExecuteDataSet("select state_id,state_name from state_master order by state_name").Tables(0)
                Me.cmb_state1.DataSource = state
                Me.cmb_state1.DataTextField = state.Columns(1).ColumnName
                Me.cmb_state1.DataValueField = state.Columns(0).ColumnName
                Me.cmb_state1.DataBind()
                Me.cmb_state2.DataSource = state
                Me.cmb_state2.DataTextField = state.Columns(1).ColumnName
                Me.cmb_state2.DataValueField = state.Columns(0).ColumnName
                Me.cmb_state2.DataBind()

                'bollod group
                bloodfill()
                religionfill()
                idfill()
                ' cmbcode()
            End If
        Else
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('You are not Authorized');")
            script1.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If

    End Sub
    Sub bloodfill()
        bg = oh.ExecuteDataSet("select blood_id,blood_type from bloodgroup_master  union select 0,'NIL' from dual order by blood_id").Tables(0)
        Me.cmb_bg.DataSource = bg
        Me.cmb_bg.DataTextField = bg.Columns(1).ColumnName
        Me.cmb_bg.DataValueField = bg.Columns(0).ColumnName
        Me.cmb_bg.DataBind()
    End Sub
    Sub religionfill()
        re = oh.ExecuteDataSet("select religion,religion_id from religion_master order by religion_id").Tables(0)
        Me.cmb_religion.DataSource = re
        Me.cmb_religion.DataTextField = re.Columns(0).ColumnName
        Me.cmb_religion.DataValueField = re.Columns(1).ColumnName
        Me.cmb_religion.DataBind()
    End Sub
    Sub idfill()
        id1 = oh.ExecuteDataSet("select identity_name,identity_id from identity_gl4 order by identity_id").Tables(0)
        Me.cmb_idproof.DataSource = id1
        Me.cmb_idproof.DataTextField = id1.Columns(0).ColumnName
        Me.cmb_idproof.DataValueField = id1.Columns(1).ColumnName
        Me.cmb_idproof.DataBind()
    End Sub
    Protected Sub cmb_code_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_code.SelectedIndexChanged
        '   cmbcode()
    End Sub
    Private Sub cmbcode()
        Dim script1 As New System.Text.StringBuilder
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        Dim dtch As DataTable = oh.ExecuteDataSet("select emp_code from employee_master where emp_code=" & Me.Txt_emp.Text & "").Tables(0)
        If dtch.Rows.Count = 0 Then
            script1.Append("        alert('Employee doesnt exist');")
            Exit Sub
        End If

        Dim dtr As DataTable = oh.ExecuteDataSet("select emp_code,emp_code || ' - ' || emp_name|| ' - ( ' || s.remark || ' )'from employee_master e,status_mst s where emp_code>9999 and e.emp_code=" & Me.Txt_emp.Text & " and e.status_id=s.status_id order by emp_code").Tables(0)
        Me.cmb_code.DataSource = dtr
        Me.cmb_code.DataTextField = dtr.Columns(1).ColumnName
        Me.cmb_code.DataValueField = dtr.Columns(0).ColumnName
        Me.cmb_code.DataBind()
        Me.txt_age.Text = ""
        Me.txt_caste.Text = ""
        Me.txt_contactno.Text = ""
        Me.txt_dob.Text = ""
        Me.txt_email.Text = ""
        Me.txt_father.Text = ""
        Me.txt_house1.Text = ""
        Me.txt_house2.Text = ""
        Me.txt_idno.Text = ""
        Me.txt_landmark.Text = ""
        Me.txt_name.Text = ""
        Me.txt_noofchildren.Text = ""
        Me.txt_phone.Text = ""
        Me.txt_pin1.Text = ""
        Me.txt_spouse.Text = ""

        Dim dt As DataTable
        dt = oh.ExecuteDataSet("select ap.perm_add1,post1.sr_number,dis1.district_id,state1.state_id,post1.pin_code,ap.pres_add1,post2.sr_number,dis2.district_id,state2.state_id,post2.pin_code from employ_personal_dtl ap,post_master post1,district_master dis1,state_master state1,post_master post2,district_master dis2,state_master state2 where ap.emp_code=" & Me.cmb_code.SelectedValue & " and ap.perm_pin=post1.sr_number and post1.district_id=dis1.district_id and dis1.state_id=state1.state_id and ap.pres_pin=post2.sr_number and post2.district_id=dis2.district_id and dis2.state_id=state2.state_id").Tables(0)
        '   Dim dt1 As DataTable = oh.ExecuteDataSet("select ap.perm_add1,post1.sr_number,dis1.district_id,state1.state_id,post1.pin_code,ap.pres_add1,post2.sr_number,dis2.district_id,state2.state_id,post2.pin_code,ap.landmark,ap.pp,ap.res_phone,ap.father_name,ap.birth_date,ap.sex,ap.emp_email,ap.marital_status,ap.spouse_name,ap.child_number,ap.blood_id,ap.id_proof,ap.idproof_number,ap.religion_id,ap.caste from employ_personal_dtl ap,post_master post1,district_master dis1,state_master state1,post_master post2,district_master dis2,state_master state2 where ap.emp_code=" & Me.cmb_code.SelectedValue & " and ap.perm_pin=post1.sr_number and post1.district_id=dis1.district_id and dis1.state_id=state1.state_id and ap.pres_pin=post2.sr_number and post2.district_id=dis2.district_id and dis2.state_id=state2.state_id").Tables(0)
        Dim dt1 As DataTable = oh.ExecuteDataSet("select ap.emp_name,ap.landmark,ap.pp,ap.res_phone,ap.cont_phone,ap.father_name,ap.birth_date,ap.sex,ap.emp_email,ap.marital_status,ap.spouse_name,ap.child_number,ap.blood_id,ap.id_proof,ap.idproof_number,ap.religion_id,ap.caste from employ_personal_dtl ap where ap.emp_code=" & Me.cmb_code.SelectedValue).Tables(0)
       

        If dt.Rows.Count = 0 Then
            script1.Append("        alert('Address Not Found');")
        Else
            Me.cmb_state1.SelectedValue = dt.Rows(0)(3)
            If Not IsDBNull(dt.Rows(0)(0)) Then
                Me.txt_house1.Text = dt.Rows(0)(0)
            End If

            'district fill
            Dim district As DataTable
            district = oh.ExecuteDataSet("select district_id,district_name from district_master where state_id='" & Me.cmb_state1.SelectedValue & "'order by district_name").Tables(0)
            If district.Rows.Count > 0 Then
                Me.cmb_district1.DataSource = district
                Me.cmb_district1.DataTextField = district.Columns(1).ColumnName
                Me.cmb_district1.DataValueField = district.Columns(0).ColumnName
                Me.cmb_district1.DataBind()

                Me.cmb_district1.SelectedValue = dt.Rows(0)(2)

                'post
                Dim post As DataTable
                post = oh.ExecuteDataSet("select sr_number,post_office from post_master where district_id='" & Me.cmb_district1.SelectedValue & "'order by post_office").Tables(0)
                If post.Rows.Count > 0 Then
                    Me.cmb_post1.DataSource = post
                    Me.cmb_post1.DataTextField = post.Columns(1).ColumnName
                    Me.cmb_post1.DataValueField = post.Columns(0).ColumnName
                    Me.cmb_post1.DataBind()
                    Me.cmb_post1.SelectedValue = dt.Rows(0)(1)
                    Me.txt_pin1.Text = dt.Rows(0)(4)
                Else
                    Me.cmb_post1.DataSource = Nothing
                    Me.cmb_post1.Items.Clear()

                End If
            Else
                Me.cmb_district1.DataSource = Nothing
                Me.cmb_district1.Items.Clear()

                '''''''''''''''
            End If
            Me.cmb_state2.SelectedValue = dt.Rows(0)(8)

            'district fill
            Dim district2 As DataTable
            district2 = oh.ExecuteDataSet("select district_id,district_name from district_master where state_id='" & Me.cmb_state2.SelectedValue & "'order by district_name").Tables(0)
            If district2.Rows.Count > 0 Then

                Me.cmb_district2.DataSource = district2
                Me.cmb_district2.DataTextField = district2.Columns(1).ColumnName
                Me.cmb_district2.DataValueField = district2.Columns(0).ColumnName
                Me.cmb_district2.DataBind()

                Me.cmb_district2.SelectedValue = dt.Rows(0)(7)
                Me.txt_house2.Text = dt.Rows(0)(5)


                'post
                Dim post2 As DataTable
                post2 = oh.ExecuteDataSet("select sr_number,post_office from post_master where district_id='" & Me.cmb_district2.SelectedValue & "'order by post_office").Tables(0)
                If post2.Rows.Count > 0 Then
                    Me.cmb_post2.DataSource = post2
                    Me.cmb_post2.DataTextField = post2.Columns(1).ColumnName
                    Me.cmb_post2.DataValueField = post2.Columns(0).ColumnName
                    Me.cmb_post2.DataBind()
                    Me.cmb_post2.SelectedValue = dt.Rows(0)(6)
                    Me.txt_pin2.Text = dt.Rows(0)(9)
                Else
                    Me.cmb_post2.DataSource = Nothing
                    Me.cmb_post2.Items.Clear()
                End If
            Else
                Me.cmb_district2.DataSource = Nothing
                Me.cmb_district2.Items.Clear()
            End If


        End If
        If dt1.Rows.Count = 0 Then
            script1.Append("        alert('Details Not Found');")

        Else
            If Not IsDBNull(dt1.Rows(0)(0)) Then
                Me.txt_name.Text = dt1.Rows(0)(0)
            End If
            If Not IsDBNull(dt1.Rows(0)(3)) Then
                Me.txt_phone.Text = dt1.Rows(0)(3)
            End If
            If dt1.Rows(0)(2) = 1 Then
                Me.chk_pp.Checked = True
            Else
                Me.chk_pp.Checked = False
            End If
            If Not IsDBNull(dt1.Rows(0)(4)) Then
                Me.txt_contactno.Text = dt1.Rows(0)(4)
            End If
            If Not IsDBNull(dt1.Rows(0)(1)) Then
                Me.txt_landmark.Text = dt1.Rows(0)(1)
            End If
            If Not IsDBNull(dt1.Rows(0)(5)) Then
                Me.txt_father.Text = dt1.Rows(0)(5)
            End If
            If Not IsDBNull(dt1.Rows(0)(6)) Then
                Me.txt_dob.Text = Format(dt1.Rows(0)(6), "dd/MMM/yyyy")
            End If
            Me.rdb_genderlist.SelectedValue = dt1.Rows(0)(7)
            Me.rdb_maritallist.SelectedValue = dt1.Rows(0)(9)
            If Not IsDBNull(dt1.Rows(0)(8)) Then
                Me.txt_email.Text = dt1.Rows(0)(8)
            End If
            If Not IsDBNull(dt1.Rows(0)(10)) Then
                Me.txt_spouse.Text = dt1.Rows(0)(10)
            End If
            If dt1.Rows(0)(9) = 2 Then
                If Not IsDBNull(dt1.Rows(0)(11)) Then
                    Me.txt_noofchildren.Text = dt1.Rows(0)(11)
                End If
            End If
            Me.cmb_bg.SelectedValue = dt1.Rows(0)(12)

            If dt1.Rows(0)(13) = 0 Then
                Me.cmb_idproof.SelectedValue = 7
            Else
                Me.cmb_idproof.SelectedValue = dt1.Rows(0)(13)
            End If
            If Not IsDBNull(dt1.Rows(0)(14)) Then
                Me.txt_idno.Text = dt1.Rows(0)(14)
            End If
            Me.cmb_religion.SelectedValue = dt1.Rows(0)(15)
            If Not IsDBNull(dt1.Rows(0)(16)) Then
                Me.txt_caste.Text = dt1.Rows(0)(16)
            End If
            Dim dte, dte1 As Date
            Dim age As Integer
            If Me.txt_dob.Text <> "" Then
                dte = Me.txt_dob.Text
                dte1 = Now.Date
                age = DateDiff(DateInterval.Year, dte, dte1)
                Me.txt_age.Text = age
            End If
            If age < 18 Then
                Me.txt_dob.Text = ""
            End If
        End If
    End Sub
    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_state1.SelectedIndexChanged
        'district fill
        Dim district1 As DataTable
        district1 = oh.ExecuteDataSet("select district_id,district_name from district_master where state_id='" & Me.cmb_state1.SelectedValue & "'order by district_name").Tables(0)
        If district1.Rows.Count > 0 Then
            Me.cmb_district1.DataSource = district1
            Me.cmb_district1.DataTextField = district1.Columns(1).ColumnName
            Me.cmb_district1.DataValueField = district1.Columns(0).ColumnName
            Me.cmb_district1.DataBind()
            cmb_district1_SelectedIndexChanged(sender, e)
        Else
            Me.cmb_district1.DataSource = Nothing
            Me.cmb_district1.Items.Clear()
            Me.cmb_post1.DataSource = Nothing
            Me.cmb_post1.Items.Clear()
            Me.txt_pin1.Text = ""
        End If
    End Sub
    Protected Sub cmb_state2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_state2.SelectedIndexChanged
        'district fill
        Dim district1 As DataTable
        district1 = oh.ExecuteDataSet("select district_id,district_name from district_master where state_id='" & Me.cmb_state2.SelectedValue & "'order by district_name").Tables(0)
        If district1.Rows.Count > 0 Then
            Me.cmb_district2.DataSource = district1
            Me.cmb_district2.DataTextField = district1.Columns(1).ColumnName
            Me.cmb_district2.DataValueField = district1.Columns(0).ColumnName
            Me.cmb_district2.DataBind()
            cmb_district2_SelectedIndexChanged(sender, e)
        Else
            Me.cmb_district2.DataSource = Nothing
            Me.cmb_district2.Items.Clear()
            Me.cmb_post2.DataSource = Nothing
            Me.cmb_post2.Items.Clear()
            Me.txt_pin2.Text = ""
        End If

    End Sub
    Protected Sub cmb_district1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_district1.SelectedIndexChanged
        'post
        Dim post1 As DataTable
        post1 = oh.ExecuteDataSet("select sr_number,post_office,pin_code from post_master where district_id='" & Me.cmb_district1.SelectedValue & "'order by post_office").Tables(0)
        If post1.Rows.Count > 0 Then
            Me.cmb_post1.DataSource = post1
            Me.cmb_post1.DataTextField = post1.Columns(1).ColumnName
            Me.cmb_post1.DataValueField = post1.Columns(0).ColumnName
            Me.cmb_post1.DataBind()
            cmb_post1_SelectedIndexChanged(sender, e)
        Else
            Me.cmb_post2.DataSource = Nothing
            Me.cmb_post2.Items.Clear()
            Me.txt_pin1.Text = ""
        End If

    End Sub
    Protected Sub cmb_district2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_district2.SelectedIndexChanged
        'post
        Dim post2 As DataTable
        post2 = oh.ExecuteDataSet("select sr_number,post_office,pin_code from post_master where district_id='" & Me.cmb_district2.SelectedValue & "'order by post_office").Tables(0)
        If post2.Rows.Count > 0 Then
            Me.cmb_post2.DataSource = post2
            Me.cmb_post2.DataTextField = post2.Columns(1).ColumnName
            Me.cmb_post2.DataValueField = post2.Columns(0).ColumnName
            Me.cmb_post2.DataBind()
            cmb_post2_SelectedIndexChanged(sender, e)
        Else
            Me.cmb_post2.DataSource = Nothing
            Me.cmb_post2.Items.Clear()
            Me.txt_pin2.Text = ""
        End If

    End Sub
    Protected Sub cmb_post1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_post1.SelectedIndexChanged
        'post
        Dim pin1 As DataTable
        pin1 = oh.ExecuteDataSet("select pin_code from post_master where sr_number=" & Me.cmb_post1.SelectedValue).Tables(0)
        If pin1.Rows.Count > 0 Then
            Me.txt_pin1.Text = pin1.Rows(0)(0)
            Me.chk_same.Checked = False
        Else
            Me.txt_pin1.Text = ""
        End If

    End Sub
    Protected Sub cmb_post2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_post2.SelectedIndexChanged
        'post
        Dim pin2 As DataTable
        pin2 = oh.ExecuteDataSet("select pin_code from post_master where sr_number=" & Me.cmb_post2.SelectedValue).Tables(0)
        If pin2.Rows.Count > 0 Then
            Me.txt_pin2.Text = pin2.Rows(0)(0)
        Else
            Me.txt_pin2.Text = ""
        End If
    End Sub
    Protected Sub cmd_update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_update.Click
        Dim param(24) As OracleParameter
        param(0) = New OracleParameter("empcode", OracleType.Number)
        param(0).Direction = ParameterDirection.Input
        param(0).Value = Me.cmb_code.SelectedValue

        param(1) = New OracleParameter("permadd1", OracleType.VarChar)
        param(1).Direction = ParameterDirection.Input
        param(1).Value = Me.txt_house1.Text

        param(2) = New OracleParameter("presadd1", OracleType.VarChar)
        param(2).Direction = ParameterDirection.Input
        param(2).Value = Me.txt_house2.Text

        param(3) = New OracleParameter("permpin", OracleType.Number)
        param(3).Direction = ParameterDirection.Input
        param(3).Value = Me.cmb_post1.SelectedValue

        param(4) = New OracleParameter("prespin", OracleType.Number)
        param(4).Direction = ParameterDirection.Input
        param(4).Value = Me.cmb_post2.SelectedValue


        param(5) = New OracleParameter("empname", OracleType.VarChar)
        param(5).Direction = ParameterDirection.Input
        param(5).Value = Me.txt_name.Text

        param(6) = New OracleParameter("fathername", OracleType.VarChar)
        param(6).Direction = ParameterDirection.Input
        If Me.txt_father.Text = "" Then
            param(6).Value = ""
        Else
            param(6).Value = Me.txt_father.Text

        End If

        param(7) = New OracleParameter("resphone", OracleType.VarChar)
        param(7).Direction = ParameterDirection.Input
        If Me.txt_phone.Text = "" Then
            param(7).Value = ""
        Else
            param(7).Value = Me.txt_phone.Text
        End If

        param(8) = New OracleParameter("contactphone", OracleType.VarChar)
        param(8).Direction = ParameterDirection.Input
        If Me.txt_contactno.Text = "" Then
            param(8).Value = ""
        Else
            param(8).Value = Me.txt_contactno.Text
        End If

        param(9) = New OracleParameter("birthdate", OracleType.DateTime)
        param(9).Direction = ParameterDirection.Input
        param(9).Value = Me.txt_dob.Text

        param(10) = New OracleParameter("gender", OracleType.Number)
        param(10).Direction = ParameterDirection.Input
        param(10).Value = Me.rdb_genderlist.SelectedValue

        param(11) = New OracleParameter("email", OracleType.VarChar)
        param(11).Direction = ParameterDirection.Input
        If Me.txt_email.Text = "" Then
            param(11).Value = ""
        Else
            param(11).Value = Me.txt_email.Text

        End If

        param(12) = New OracleParameter("marital", OracleType.Number)
        param(12).Direction = ParameterDirection.Input
        param(12).Value = Me.rdb_maritallist.SelectedValue

        param(13) = New OracleParameter("spouse", OracleType.VarChar)
        param(13).Direction = ParameterDirection.Input
        If Me.txt_spouse.Text = "" Then
            param(13).Value = "" + "~" + Me.Session("userid")
        Else
            param(13).Value = Me.txt_spouse.Text + "~" + Me.Session("userid")

        End If

        param(14) = New OracleParameter("child", OracleType.Number)
        param(14).Direction = ParameterDirection.Input
        If Me.txt_noofchildren.Text = "" Then
            param(14).Value = 0
        Else
            param(14).Value = Me.txt_noofchildren.Text
        End If

        param(15) = New OracleParameter("blood", OracleType.Number)
        param(15).Direction = ParameterDirection.Input
        param(15).Value = Me.cmb_bg.SelectedValue

        param(16) = New OracleParameter("idproof", OracleType.Number)
        param(16).Direction = ParameterDirection.Input
        param(16).Value = Me.cmb_idproof.SelectedValue

        param(17) = New OracleParameter("idno", OracleType.VarChar)
        param(17).Direction = ParameterDirection.Input
        If Me.txt_idno.Text = "" Then
            param(17).Value = "NIL"
        Else
            param(17).Value = Me.txt_idno.Text
        End If


        param(18) = New OracleParameter("religionid", OracleType.Number)
        param(18).Direction = ParameterDirection.Input
        param(18).Value = Me.cmb_religion.SelectedValue

        param(19) = New OracleParameter("caste1", OracleType.VarChar)
        param(19).Direction = ParameterDirection.Input
        If Me.txt_caste.Text = "" Then
            param(19).Value = "NIL"
        Else
            param(19).Value = Me.txt_caste.Text

        End If

        param(20) = New OracleParameter("landmark1", OracleType.VarChar)
        param(20).Direction = ParameterDirection.Input
        If Me.txt_landmark.Text = "" Then
            param(20).Value = ""
        Else
            param(20).Value = Me.txt_landmark.Text

        End If

        param(21) = New OracleParameter("ppp", OracleType.VarChar)
        param(21).Direction = ParameterDirection.Input
        If Me.chk_pp.Checked = True Then
            param(21).Value = 1
        Else
            param(21).Value = 0
        End If

        param(23) = New OracleParameter("fl", OracleType.Number, 5)
        param(23).Value = 4

        param(24) = New OracleParameter("enterBy", OracleType.Number, 5)
        param(24).Value = 0
        param(22) = New OracleParameter("update_flag", OracleType.Number)
        param(22).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("EDITEMP_ADDRESS_MACOM", param)
        Dim script1 As New System.Text.StringBuilder
        If param(22).Value = 1 Then

            script1.Append("        alert('Successfully Edited');")

            'Response.Redirect("editqualification.aspx?empcode=" & Me.cmb_code.SelectedValue)
            'script1.Append("       window.open('editqualification.aspx');")
            script1.Append("       window.open('editqualification.aspx?empcode=" & Me.cmb_code.SelectedValue & "');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        Else
            script1.Append("        alert('Sorry,Error in Editing');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        End If

    End Sub
    Protected Sub chk_same_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_same.CheckedChanged
        If Me.chk_same.Checked = True Then
            Me.txt_house2.Text = Me.txt_house1.Text
            Me.cmb_state2.SelectedValue = Me.cmb_state1.SelectedValue
            cmb_state2_SelectedIndexChanged(sender, e)
            Me.cmb_district2.SelectedValue = Me.cmb_district1.SelectedValue
            cmb_district2_SelectedIndexChanged(sender, e)
            Me.cmb_post2.SelectedValue = Me.cmb_post1.SelectedValue
            Me.txt_pin2.Text = Me.txt_pin1.Text
        End If
    End Sub
    Protected Sub txt_dob_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dob.TextChanged
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
    Protected Sub rdb_maritallist_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdb_maritallist.SelectedIndexChanged
        If Me.rdb_maritallist.SelectedValue = 1 Then
            Me.txt_spouse.Enabled = False
            Me.txt_noofchildren.Enabled = False
        ElseIf Me.rdb_maritallist.SelectedValue = 2 Then
            Me.txt_spouse.Enabled = True
            Me.txt_noofchildren.Enabled = True
        End If
    End Sub
    Protected Sub cmd_next_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_next.Click
        Me.Server.Transfer("editqualification.aspx?empcode=" & Me.cmb_code.SelectedValue)
    End Sub

    Protected Sub Txt_emp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_emp.TextChanged
        cmbcode()
    End Sub
End Class
