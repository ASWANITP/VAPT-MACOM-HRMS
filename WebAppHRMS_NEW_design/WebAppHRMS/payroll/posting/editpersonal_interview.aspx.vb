Imports System.Data
Imports System.Data.OracleClient
Partial Class edit_interview_details_editpersonal_interview_38847f0f8765
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txt_house1.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        If Session("access_id") = 33 Then
            'CType(Me.Master, WebAppHRMS.edp).Subtitle = "EDIT PERSONAL DETAILS"
            Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
            masterPage.subtitle = "EDIT PERSONAL DETAILS"
            Me.txt_house1.Attributes.Add("onkeyup", "upperconverter1()")
            Me.txt_house2.Attributes.Add("onkeyup", "upperconverter2()")
            Me.txt_lmark.Attributes.Add("onkeyup", "upperconverter3()")
            Me.txt_idno.Attributes.Add("onkeyup", "upperconverter4()")

            If Not IsPostBack Then
                Dim cm_app As DataTable
                cm_app = oh.ExecuteDataSet("select ap.appln_no,ap.appln_no || ' - ' ||ap.appln_name from appln_pers_dtl ap where ap.appln_no not in(select ai.appln_no from appln_interview_dtl ai where ai.emp_code is not null) order by ap.appln_no").Tables(0)
                Me.cmb_appno.DataSource = cm_app
                Me.cmb_appno.DataTextField = cm_app.Columns(1).ColumnName
                Me.cmb_appno.DataValueField = cm_app.Columns(0).ColumnName
                Me.cmb_appno.DataBind()


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

                'blood group
                Dim blood As DataTable
                blood = oh.ExecuteDataSet("select blood_id,blood_type from bloodgroup_master").Tables(0)
                Me.cmb_bg.DataSource = blood
                Me.cmb_bg.DataTextField = blood.Columns(1).ColumnName
                Me.cmb_bg.DataValueField = blood.Columns(0).ColumnName
                Me.cmb_bg.DataBind()

                'id proof
                Dim id As DataTable
                id = oh.ExecuteDataSet("select identity_id,identity_name from identity_gl4").Tables(0)
                Me.cmb_idproof.DataSource = id
                Me.cmb_idproof.DataTextField = id.Columns(1).ColumnName
                Me.cmb_idproof.DataValueField = id.Columns(0).ColumnName
                Me.cmb_idproof.DataBind()
                cmb_appno_SelectedIndexChanged(sender, e)
            End If
        Else
            Response.Redirect("../../show_err.aspx")
        End If

       
    End Sub

    Protected Sub cmb_appno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_appno.SelectedIndexChanged
        Dim dt As DataTable
        dt = oh.ExecuteDataSet("select ap.appln_name,ap.perm_add1,post1.sr_number,dis1.district_id,state1.state_id,post1.pin_code,ap.pres_add1,post2.sr_number,dis2.district_id,state2.state_id,nvl(post2.pin_code,0),nvl(ap.landmark,0),nvl(ap.res_phone,0),nvl(ap.cont_phone,0),nvl(ap.appln_email,0),nvl(bld.blood_id,0),nvl(id.identity_id,0),nvl(ap.idproof_number,0),ap.pp from appln_pers_dtl ap,post_master post1,district_master dis1,state_master state1,post_master post2,district_master dis2,state_master state2,bloodgroup_master bld,identity_gl4 id where ap.appln_no=" & Me.cmb_appno.SelectedValue & " and ap.perm_pin=post1.sr_number and post1.district_id=dis1.district_id and dis1.state_id=state1.state_id and ap.pres_pin=post2.sr_number and post2.district_id=dis2.district_id and dis2.state_id=state2.state_id and ap.blood_id=bld.blood_id and ap.id_proof=id.identity_id").Tables(0)
        Me.txt_name.Text = dt.Rows(0)(0)
        Me.txt_house1.Text = dt.Rows(0)(1)
        Me.cmb_state1.SelectedValue = dt.Rows(0)(4)

        'district fill
        Dim district As DataTable
        district = oh.ExecuteDataSet("select district_id,district_name from district_master where state_id='" & Me.cmb_state1.SelectedValue & "'order by district_name").Tables(0)
        Me.cmb_district1.DataSource = district
        Me.cmb_district1.DataTextField = district.Columns(1).ColumnName
        Me.cmb_district1.DataValueField = district.Columns(0).ColumnName
        Me.cmb_district1.DataBind()

        Me.cmb_district1.SelectedValue = dt.Rows(0)(3)


        'post
        Dim post As DataTable
        post = oh.ExecuteDataSet("select sr_number,post_office from post_master where district_id='" & Me.cmb_district1.SelectedValue & "'order by post_office").Tables(0)
        Me.cmb_post1.DataSource = post
        Me.cmb_post1.DataTextField = post.Columns(1).ColumnName
        Me.cmb_post1.DataValueField = post.Columns(0).ColumnName
        Me.cmb_post1.DataBind()
        Me.cmb_post1.SelectedValue = dt.Rows(0)(2)
        Me.txt_pin1.Text = dt.Rows(0)(5)
        '''''''''''''''

        Me.txt_house2.Text = dt.Rows(0)(6)
        Me.cmb_state2.SelectedValue = dt.Rows(0)(9)

        'district fill
        Dim district1 As DataTable
        district1 = oh.ExecuteDataSet("select district_id,district_name from district_master where state_id='" & Me.cmb_state2.SelectedValue & "'order by district_name").Tables(0)
        Me.cmb_district2.DataSource = district1
        Me.cmb_district2.DataTextField = district1.Columns(1).ColumnName
        Me.cmb_district2.DataValueField = district1.Columns(0).ColumnName
        Me.cmb_district2.DataBind()

        Me.cmb_district2.SelectedValue = dt.Rows(0)(8)


        'post
        Dim post2 As DataTable
        post2 = oh.ExecuteDataSet("select sr_number,post_office from post_master where district_id='" & Me.cmb_district2.SelectedValue & "'order by post_office").Tables(0)
        Me.cmb_post2.DataSource = post2
        Me.cmb_post2.DataTextField = post2.Columns(1).ColumnName
        Me.cmb_post2.DataValueField = post2.Columns(0).ColumnName
        Me.cmb_post2.DataBind()
        Me.cmb_post2.SelectedValue = dt.Rows(0)(7)

        Me.txt_pin2.Text = dt.Rows(0)(10)

        Me.txt_lmark.Text = dt.Rows(0)(11)
        Me.txt_phone.Text = dt.Rows(0)(12)
        Me.txt_contact.Text = dt.Rows(0)(13)
        Me.txt_email.Text = dt.Rows(0)(14)
        Me.cmb_bg.SelectedValue = dt.Rows(0)(15)
        Me.cmb_idproof.SelectedValue = dt.Rows(0)(16)
        Me.txt_idno.Text = dt.Rows(0)(17)
        If dt.Rows(0)(18) = 1 Then
            Me.Chk_pp.Checked = True
        End If
        Me.chk_same.Checked = False
    End Sub

    Protected Sub cmb_state1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_state1.SelectedIndexChanged
        'district fill
        Dim district1 As DataTable
        district1 = oh.ExecuteDataSet("select district_id,district_name from district_master where state_id='" & Me.cmb_state1.SelectedValue & "'order by district_name").Tables(0)
        Me.cmb_district1.DataSource = district1
        Me.cmb_district1.DataTextField = district1.Columns(1).ColumnName
        Me.cmb_district1.DataValueField = district1.Columns(0).ColumnName
        Me.cmb_district1.DataBind()
        cmb_district1_SelectedIndexChanged(sender, e)
    End Sub

    Protected Sub cmb_state2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_state2.SelectedIndexChanged
        'district fill
        Dim district1 As DataTable
        district1 = oh.ExecuteDataSet("select district_id,district_name from district_master where state_id='" & Me.cmb_state2.SelectedValue & "'order by district_name").Tables(0)
        Me.cmb_district2.DataSource = district1
        Me.cmb_district2.DataTextField = district1.Columns(1).ColumnName
        Me.cmb_district2.DataValueField = district1.Columns(0).ColumnName
        Me.cmb_district2.DataBind()
        cmb_district2_SelectedIndexChanged(sender, e)
    End Sub
    Protected Sub cmb_district1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_district1.SelectedIndexChanged
        'post
        Dim post2 As DataTable
        post2 = oh.ExecuteDataSet("select sr_number,post_office,pin_code from post_master where district_id='" & Me.cmb_district1.SelectedValue & "'order by post_office").Tables(0)
        Me.cmb_post1.DataSource = post2
        Me.cmb_post1.DataTextField = post2.Columns(1).ColumnName
        Me.cmb_post1.DataValueField = post2.Columns(0).ColumnName
        Me.cmb_post1.DataBind()
        cmb_post1_SelectedIndexChanged(sender, e)
    End Sub
    Protected Sub cmb_district2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_district2.SelectedIndexChanged
        'post
        Dim post2 As DataTable
        post2 = oh.ExecuteDataSet("select sr_number,post_office,pin_code from post_master where district_id='" & Me.cmb_district2.SelectedValue & "'order by post_office").Tables(0)
        Me.cmb_post2.DataSource = post2
        Me.cmb_post2.DataTextField = post2.Columns(1).ColumnName
        Me.cmb_post2.DataValueField = post2.Columns(0).ColumnName
        Me.cmb_post2.DataBind()
        cmb_post2_SelectedIndexChanged(sender, e)
    End Sub


    Protected Sub cmb_post1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_post1.SelectedIndexChanged
        'post
        Dim post1 As DataTable
        post1 = oh.ExecuteDataSet("select pin_code from post_master where sr_number=" & Me.cmb_post1.SelectedValue).Tables(0)
        Me.txt_pin1.Text = post1.Rows(0)(0)
    End Sub

    Protected Sub cmb_post2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_post2.SelectedIndexChanged
        'post
        Dim post2 As DataTable
        post2 = oh.ExecuteDataSet("select pin_code from post_master where sr_number=" & Me.cmb_post2.SelectedValue).Tables(0)
        Me.txt_pin2.Text = post2.Rows(0)(0)
    End Sub

    Protected Sub cmb_idproof_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_idproof.SelectedIndexChanged
        Me.txt_idno.Text = " "
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

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim param(13) As OracleParameter
        param(0) = New OracleParameter("applnno", OracleType.Number)
        param(0).Direction = ParameterDirection.Input
        param(0).Value = Me.cmb_appno.SelectedValue

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

        param(5) = New OracleParameter("resphone", OracleType.VarChar)
        param(5).Direction = ParameterDirection.Input
        param(5).Value = Me.txt_phone.Text

        param(6) = New OracleParameter("contphone", OracleType.VarChar)
        param(6).Direction = ParameterDirection.Input
        param(6).Value = Me.txt_contact.Text

        param(7) = New OracleParameter("applnemail", OracleType.VarChar)
        param(7).Direction = ParameterDirection.Input
        param(7).Value = Me.txt_email.Text

        param(8) = New OracleParameter("bloodid", OracleType.Number)
        param(8).Direction = ParameterDirection.Input
        param(8).Value = Me.cmb_bg.SelectedValue

        param(9) = New OracleParameter("idproof", OracleType.Number)
        param(9).Direction = ParameterDirection.Input
        param(9).Value = Me.cmb_idproof.SelectedValue

        param(10) = New OracleParameter("idproofnumber", OracleType.VarChar)
        param(10).Direction = ParameterDirection.Input
        param(10).Value = Me.txt_idno.Text

        param(11) = New OracleParameter("land_mark", OracleType.VarChar)
        param(11).Direction = ParameterDirection.Input
        param(11).Value = Me.txt_lmark.Text



        param(12) = New OracleParameter("pp1", OracleType.Number)
        If Me.Chk_pp.Checked = True Then
            param(12).Value = 1
        Else
            param(12).Value = 0
        End If
        param(12).Direction = ParameterDirection.Input

        param(13) = New OracleParameter("update_flag", OracleType.Number)
        param(13).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("editappln_per", param)
        Dim script1 As New System.Text.StringBuilder
        If param(13).Value = 1 Then

            script1.Append("        alert('Successfully Edited');")
            script1.Append("window.open('editpersonal_interview.aspx','_self');")
        Else
            script1.Append("        alert('Sorry,Error in Editing');")
        End If
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
    End Sub
End Class
