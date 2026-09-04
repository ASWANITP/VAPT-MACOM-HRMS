
Imports System.Data
Imports System.Data.OracleClient
Imports PdfSharp
Public Class edit_emp_address_approve
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, bg, re, id1, po, qual As DataTable
    Dim rid, idproof, bid As Integer
    Dim UserAll() As String

    Protected Sub cmd_reject_Click(sender As Object, e As EventArgs) Handles cmd_reject.Click

        If Me.cmb_code.SelectedValue = 0 Then
            Dim cl_script1 As New StringBuilder
            cl_script1.Append("         alert('Select any record!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            UserAll = Me.Session("user_id").ToString.Split("!")
            Dim enterBy As String = UserAll(0)
            Dim empId As String = Me.cmb_code.SelectedItem.Text
            Dim value As String = empId
            Dim result() As String = value.Split("-")
            Dim empcod As String = result(0)
            Dim empname As String = result(1)
            Dim religion As String = Me.cmb_religion.Text
            Dim idproof1 As String = Me.cmb_idproof.Text
            Dim bid1 As String = Me.cmb_bg.Text

            If rdPersonal.Checked Then
                Dim dt As DataTable
                dt = oh.ExecuteDataSet("select ap.perm_add1,post1.sr_number,dis1.district_id,state1.state_id,post1.pin_code,ap.pres_add1,post2.sr_number,dis2.district_id,state2.state_id,post2.pin_code from employ_personal_dtl ap,post_master post1,district_master dis1,state_master state1,post_master post2,district_master dis2,state_master state2 where ap.emp_code=" & empcod & " and ap.perm_pin=post1.sr_number and post1.district_id=dis1.district_id and dis1.state_id=state1.state_id and ap.pres_pin=post2.sr_number and post2.district_id=dis2.district_id and dis2.state_id=state2.state_id").Tables(0)


                Dim query As String = "SELECT religion_id FROM religion_master WHERE religion = '" & religion.Replace("'", "''") & "'"
                Dim ds As DataSet = oh.ExecuteDataSet(query)
                rid = ds.Tables(0).Rows(0)(0)

                Dim query1 As String = "select identity_id,identity_name from identity_gl4 where identity_name='" & idproof1.Replace("'", "''") & "'"
                Dim ds1 As DataSet = oh.ExecuteDataSet(query1)
                idproof = ds1.Tables(0).Rows(0)(0)



                Dim query2 As String = "select blood_id,blood_type from bloodgroup_master where blood_type='" & bid1.Replace("'", "''") & "'"
                Dim ds2 As DataSet = oh.ExecuteDataSet(query2)
                bid = ds2.Tables(0).Rows(0)(0)



                Dim param(24) As OracleParameter
                param(0) = New OracleParameter("empcode", OracleType.Number)
                param(0).Direction = ParameterDirection.Input
                param(0).Value = empcod

                param(1) = New OracleParameter("permadd1", OracleType.VarChar)
                param(1).Direction = ParameterDirection.Input
                param(1).Value = Me.txt_house1.Text

                param(2) = New OracleParameter("presadd1", OracleType.VarChar)
                param(2).Direction = ParameterDirection.Input
                param(2).Value = Me.txt_house2.Text

                param(3) = New OracleParameter("permpin", OracleType.Number)
                param(3).Direction = ParameterDirection.Input
                param(3).Value = dt.Rows(0)(1)

                param(4) = New OracleParameter("prespin", OracleType.Number)
                param(4).Direction = ParameterDirection.Input
                param(4).Value = dt.Rows(0)(6)


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
                param(15).Value = bid

                param(16) = New OracleParameter("idproof", OracleType.Number)
                param(16).Direction = ParameterDirection.Input
                param(16).Value = idproof

                param(17) = New OracleParameter("idno", OracleType.VarChar)
                param(17).Direction = ParameterDirection.Input
                If Me.txt_idno.Text = "" Then
                    param(17).Value = "NIL"
                Else
                    param(17).Value = Me.txt_idno.Text
                End If


                param(18) = New OracleParameter("religionid", OracleType.Number)
                param(18).Direction = ParameterDirection.Input
                param(18).Value = rid

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
                param(23).Value = 7

                param(24) = New OracleParameter("enterBy", OracleType.Number, 5)
                param(24).Value = enterBy


                param(22) = New OracleParameter("update_flag", OracleType.Number)
                param(22).Direction = ParameterDirection.Output
                param(22).Value = oh.ExecuteNonQuery("EDITEMP_ADDRESS_MACOM", param)

                'Dim updateFlag As Integer = Convert.ToInt32(param(22).Value)

                Dim script1 As New System.Text.StringBuilder
                If param(22).Value = 1 Then

                    script1.Append("        alert('Rejected!!');")
                    script1.Append("       window.open('edit_emp_address_approve.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

                Else
                    script1.Append("        alert('Sorry,An error occured');")
                    script1.Append("       window.open('edit_emp_address_approve.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

                End If
                '---------------------------------------------------------------------------------
            ElseIf rdQual.Checked Then

                Dim dt2 As DataTable
                dt2 = oh.ExecuteDataSet("SELECT t.qualification, t.institution, t.university, t.percentage, t.year_pass FROM EMPLOY_QUALIFICATION_TEMP t WHERE t.emp_code=" & empcod & " and t.status=0").Tables(0)

                Dim param1(12) As OracleParameter
                For i As Integer = 0 To dt2.Rows.Count - 1
                    param1(0) = New OracleParameter("empcode", OracleType.Number)
                    param1(0).Direction = ParameterDirection.Input
                    param1(0).Value = empcod

                    param1(1) = New OracleParameter("qual", OracleType.Number)
                    param1(1).Value = 0

                    param1(2) = New OracleParameter("num", OracleType.Number)
                    param1(2).Direction = ParameterDirection.Input
                    param1(2).Value = 0

                    param1(3) = New OracleParameter("qualificationid", OracleType.Number)
                    param1(3).Direction = ParameterDirection.Input
                    'param1(3).Value = hidQualID.Value
                    param1(3).Value = dt2.Rows(i)(0)



                    param1(4) = New OracleParameter("institute", OracleType.VarChar)
                    param1(4).Direction = ParameterDirection.Input
                    'If hidInstitution.Value = "" Then
                    '    param1(4).Value = "NIL"
                    'Else
                    '    param1(4).Value = hidInstitution.Value
                    'End If
                    If IsDBNull(dt2.Rows(i)(1)) Then
                        param1(4).Value = "NIL"
                    Else
                        param1(4).Value = dt2.Rows(i)(1)
                    End If

                    param1(5) = New OracleParameter("univer", OracleType.VarChar)
                    param1(5).Direction = ParameterDirection.Input
                    'If hidUniversity.Value = "" Then
                    '    param1(5).Value = "NIL"
                    'Else
                    '    param1(5).Value = hidUniversity.Value
                    'End If
                    If IsDBNull(dt2.Rows(i)(2)) Then
                        param1(5).Value = "NIL"
                    Else
                        param1(5).Value = dt2.Rows(i)(2)
                    End If

                    param1(6) = New OracleParameter("percen", OracleType.Number)
                    param1(6).Direction = ParameterDirection.Input
                    'If hidPercentage.Value = "" Then
                    '    param1(6).Value = 0
                    'Else
                    '    param1(6).Value = hidPercentage.Value

                    'End If
                    If IsDBNull(dt2.Rows(i)(3)) Then
                        param1(6).Value = 0
                    Else
                        param1(6).Value = dt2.Rows(i)(3)
                    End If

                    param1(7) = New OracleParameter("yearpass", OracleType.VarChar)
                    param1(7).Direction = ParameterDirection.Input
                    'If hidYearPass.Value = "" Then
                    '    param1(7).Value = 0
                    'Else
                    '    param1(7).Value = hidYearPass.Value

                    'End If
                    If IsDBNull(dt2.Rows(i)(4)) Then
                        param1(7).Value = 0
                    Else
                        param1(7).Value = dt2.Rows(i)(4)
                    End If

                    param1(8) = New OracleParameter("approved", OracleType.VarChar)
                    param1(8).Direction = ParameterDirection.Input
                    param1(8).Value = enterBy

                    param1(9) = New OracleParameter("high", OracleType.Number)
                    param1(9).Direction = ParameterDirection.Input
                    param1(9).Value = 0

                    param1(11) = New OracleParameter("fl", OracleType.Number, 5)
                    param1(11).Value = 8

                    param1(12) = New OracleParameter("enterBy", OracleType.Number, 5)
                    param1(12).Value = enterBy

                    param1(10) = New OracleParameter("update_flag", OracleType.Number)
                    param1(10).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("EDITEMP_QUALEXP_MACOM", param1)
                Next
                Dim script1 As New System.Text.StringBuilder '
                If param1(10).Value = 1 Then

                    script1.Append("        alert('Rejected!!');")
                    script1.Append("       window.open('edit_emp_address_approve.aspx','_self');")
                Else
                    script1.Append("        alert('Sorry,An error occured);")
                    script1.Append("       window.open('edit_emp_address_approve.aspx','_self');")
                End If
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

                '-----------------------------------------------------------------------------------
            ElseIf rdExp.Checked Then
                Dim dt3 As DataTable
                dt3 = oh.ExecuteDataSet("select t.organisation,t.designation,to_char(t.exp_frdate) as exp_frdate,to_char(t.exp_todate)  as exp_todate,t.nature_duty,t.releaving_reason,t.cont_person,t.cont_phone,t.present_salary from EMPLOY_EXPERIENCE_TEMP t where t.emp_code=" & empcod & " and t.status = 0").Tables(0)

                Dim param2(12) As OracleParameter
                For i As Integer = 0 To dt3.Rows.Count - 1
                    param2(0) = New OracleParameter("empcode", OracleType.Number)
                    param2(0).Direction = ParameterDirection.Input
                    param2(0).Value = empcod


                    param2(1) = New OracleParameter("org", OracleType.VarChar)
                    param2(1).Direction = ParameterDirection.Input
                    'param2(1).Value = hidOrganisation.Value
                    param2(1).Value = dt3.Rows(i)(0)

                    param2(2) = New OracleParameter("desig", OracleType.VarChar)
                    param2(2).Direction = ParameterDirection.Input
                    'If hidDesignation.Value = "" Then
                    '    param2(2).Value = "NIL"
                    'Else
                    '    param2(2).Value = hidDesignation.Value
                    'End If
                    If IsDBNull(dt3.Rows(i)(1)) Then
                        param2(2).Value = "NIL"
                    Else
                        param2(2).Value = dt3.Rows(i)(1)
                    End If

                    param2(3) = New OracleParameter("frdate", OracleType.DateTime)
                    param2(3).Direction = ParameterDirection.Input
                    'param2(3).Value = hidExpFrom.Value
                    param2(3).Value = dt3.Rows(i)(2)

                    param2(4) = New OracleParameter("todate", OracleType.DateTime)
                    param2(4).Direction = ParameterDirection.Input
                    'param2(4).Value = hidExpTo.Value
                    param2(4).Value = dt3.Rows(i)(3)

                    param2(5) = New OracleParameter("nature", OracleType.VarChar)
                    param2(5).Direction = ParameterDirection.Input
                    'If hidNatureDuty.Value = "" Then
                    '    param2(5).Value = "NIL"
                    'Else
                    '    param2(5).Value = hidNatureDuty.Value
                    'End If
                    If IsDBNull(dt3.Rows(i)(4)) Then
                        param2(5).Value = "NIL"
                    Else
                        param2(5).Value = dt3.Rows(i)(4)
                    End If

                    param2(6) = New OracleParameter("reason", OracleType.VarChar)
                    param2(6).Direction = ParameterDirection.Input
                    'If hidRelievingReason.Value = "" Then
                    '    param2(6).Value = "NIL"
                    'Else
                    '    param2(6).Value = hidRelievingReason.Value
                    'End If
                    If IsDBNull(dt3.Rows(i)(5)) Then
                        param2(6).Value = "NIL"
                    Else
                        param2(6).Value = dt3.Rows(i)(5)
                    End If

                    param2(7) = New OracleParameter("contact", OracleType.VarChar)
                    param2(7).Direction = ParameterDirection.Input
                    'If hidContactPerson.Value = " " Then
                    '    param2(7).Value = "NIL"
                    'Else
                    '    param2(7).Value = hidContactPerson.Value
                    'End If
                    If IsDBNull(dt3.Rows(i)(6)) Then
                        param2(7).Value = "NIL"
                    Else
                        param2(7).Value = dt3.Rows(i)(6)
                    End If

                    param2(8) = New OracleParameter("contactno", OracleType.VarChar)
                    param2(8).Direction = ParameterDirection.Input
                    'If hidContactPhone.Value = "" Then
                    '    param2(8).Value = "NIL"
                    'Else
                    '    param2(8).Value = hidContactPhone.Value
                    'End If
                    If IsDBNull(dt3.Rows(i)(7)) Then
                        param2(8).Value = "NIL"
                    Else
                        param2(8).Value = dt3.Rows(i)(7)
                    End If

                    param2(9) = New OracleParameter("salary", OracleType.Number)
                    param2(9).Direction = ParameterDirection.Input
                    'If hidSalary.Value = "" Then
                    '    param2(9).Value = 0
                    'Else
                    '    param2(9).Value = hidSalary.Value
                    'End If
                    If IsDBNull(dt3.Rows(i)(8)) Then
                        param2(9).Value = 0
                    Else
                        param2(9).Value = dt3.Rows(i)(8)
                    End If

                    param2(11) = New OracleParameter("fl", OracleType.Number, 5)
                    param2(11).Value = 9

                    param2(12) = New OracleParameter("enterBy", OracleType.Number, 5)
                    param2(12).Value = enterBy

                    param2(10) = New OracleParameter("update_flag", OracleType.Number)
                    param2(10).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("EDITEMP_EXP_MACOM", param2)
                Next
                Dim script1 As New System.Text.StringBuilder
                If param2(10).Value = 1 Then
                    script1.Append("        alert('Rejected!!');")
                    script1.Append("       window.open('edit_emp_address_approve.aspx','_self');")
                Else
                    script1.Append("        alert('Sorry,An error occured');")
                    script1.Append("       window.open('edit_emp_address_approve.aspx','_self');")
                End If
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            End If
        End If
    End Sub



    Dim UserCode As Integer

    Protected Sub rdPersonal_CheckedChanged(sender As Object, e As EventArgs) Handles rdPersonal.CheckedChanged
        If rdPersonal.Checked = True Then

            section1.Style("display") = "block"
            section2.Style("display") = "none"
            section3.Style("display") = "none"


            cmb_code.Items.Clear()

            Dim dt As DataTable = oh.ExecuteDataSet("select 0 as Empcode,'Select Employee Name' as Empname from dual union select emp_code,emp_code || ' - ' || emp_name from mactech.employ_person_temp e where  e.status =0").Tables(0)
            Me.cmb_code.DataSource = dt
            Me.cmb_code.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_code.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_code.DataBind()
        End If
    End Sub

    Protected Sub rdQual_CheckedChanged(sender As Object, e As EventArgs) Handles rdQual.CheckedChanged
        If rdQual.Checked = True Then
            section1.Style("display") = "none"
            section2.Style("display") = "none"
            section3.Style("display") = "block"

            cmb_code.Items.Clear()
            Dim dt As DataTable = oh.ExecuteDataSet("select 0 as Empcode, 'Select Employee Name' as Empname from dual union select ql.emp_code, ql.emp_code || ' - ' || e.emp_name from mactech.employee_master e,mactech.employ_qualification_temp ql where e.emp_code=ql.emp_code and ql.status = 0").Tables(0)
            Me.cmb_code.DataSource = dt
            Me.cmb_code.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_code.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_code.DataBind()
        End If
    End Sub

    Protected Sub rdExp_CheckedChanged(sender As Object, e As EventArgs) Handles rdExp.CheckedChanged
        If rdExp.Checked = True Then
            section1.Style("display") = "none"
            section2.Style("display") = "block"
            section3.Style("display") = "none"

            cmb_code.Items.Clear()
            Dim dt As DataTable = oh.ExecuteDataSet("select 0 as Empcode, 'Select Employee Name' as Empname from dual union select ex.emp_code, ex.emp_code || ' - ' || e.emp_name from mactech.employee_master e,mactech.employ_experience_temp ex where e.emp_code=ex.emp_code and ex.status = 0").Tables(0)
            Me.cmb_code.DataSource = dt
            Me.cmb_code.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_code.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_code.DataBind()
        End If
    End Sub


    Protected Sub cmd_update_Click(sender As Object, e As EventArgs) Handles cmd_update.Click

        If Me.cmb_code.SelectedValue = 0 Then
            Dim cl_script1 As New StringBuilder
            cl_script1.Append("         alert('Select any record!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            UserAll = Me.Session("user_id").ToString.Split("!")
            Dim enterBy As String = UserAll(0)
            Dim empId As String = Me.cmb_code.SelectedItem.Text
            Dim value As String = empId
            Dim result() As String = value.Split("-")
            Dim empcod As String = result(0)
            Dim empname As String = result(1)
            Dim religion As String = Me.cmb_religion.Text
            Dim idproof1 As String = Me.cmb_idproof.Text
            Dim bid1 As String = Me.cmb_bg.Text

            If rdPersonal.Checked Then
                Dim dt As DataTable
                dt = oh.ExecuteDataSet("select ap.perm_add1,post1.sr_number,dis1.district_id,state1.state_id,post1.pin_code,ap.pres_add1,post2.sr_number,dis2.district_id,state2.state_id,post2.pin_code from employ_personal_dtl ap,post_master post1,district_master dis1,state_master state1,post_master post2,district_master dis2,state_master state2 where ap.emp_code=" & empcod & " and ap.perm_pin=post1.sr_number and post1.district_id=dis1.district_id and dis1.state_id=state1.state_id and ap.pres_pin=post2.sr_number and post2.district_id=dis2.district_id and dis2.state_id=state2.state_id").Tables(0)


                Dim query As String = "SELECT religion_id FROM religion_master WHERE religion = '" & religion.Replace("'", "''") & "'"
                Dim ds As DataSet = oh.ExecuteDataSet(query)
                rid = ds.Tables(0).Rows(0)(0)

                Dim query1 As String = "select identity_id,identity_name from identity_gl4 where identity_name='" & idproof1.Replace("'", "''") & "'"
                Dim ds1 As DataSet = oh.ExecuteDataSet(query1)
                idproof = ds1.Tables(0).Rows(0)(0)



                Dim query2 As String = "select blood_id,blood_type from bloodgroup_master where blood_type='" & bid1.Replace("'", "''") & "'"
                Dim ds2 As DataSet = oh.ExecuteDataSet(query2)
                bid = ds2.Tables(0).Rows(0)(0)



                Dim param(24) As OracleParameter
                param(0) = New OracleParameter("empcode", OracleType.Number)
                param(0).Direction = ParameterDirection.Input
                param(0).Value = empcod

                param(1) = New OracleParameter("permadd1", OracleType.VarChar)
                param(1).Direction = ParameterDirection.Input
                param(1).Value = Me.txt_house1.Text

                param(2) = New OracleParameter("presadd1", OracleType.VarChar)
                param(2).Direction = ParameterDirection.Input
                param(2).Value = Me.txt_house2.Text

                param(3) = New OracleParameter("permpin", OracleType.Number)
                param(3).Direction = ParameterDirection.Input
                param(3).Value = dt.Rows(0)(1)

                param(4) = New OracleParameter("prespin", OracleType.Number)
                param(4).Direction = ParameterDirection.Input
                param(4).Value = dt.Rows(0)(6)


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
                param(15).Value = bid

                param(16) = New OracleParameter("idproof", OracleType.Number)
                param(16).Direction = ParameterDirection.Input
                param(16).Value = idproof

                param(17) = New OracleParameter("idno", OracleType.VarChar)
                param(17).Direction = ParameterDirection.Input
                If Me.txt_idno.Text = "" Then
                    param(17).Value = "NIL"
                Else
                    param(17).Value = Me.txt_idno.Text
                End If


                param(18) = New OracleParameter("religionid", OracleType.Number)
                param(18).Direction = ParameterDirection.Input
                param(18).Value = rid

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
                param(23).Value = 1

                param(24) = New OracleParameter("enterBy", OracleType.Number, 5)
                param(24).Value = enterBy


                param(22) = New OracleParameter("update_flag", OracleType.Number)
                param(22).Direction = ParameterDirection.Output
                param(22).Value = oh.ExecuteNonQuery("EDITEMP_ADDRESS_MACOM", param)

                'Dim updateFlag As Integer = Convert.ToInt32(param(22).Value)

                Dim script1 As New System.Text.StringBuilder
                If param(22).Value = 1 Then

                    script1.Append("        alert('Successfully Approved');")
                    script1.Append("       window.open('edit_emp_address_approve.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

                Else
                    script1.Append("        alert('Sorry,Not Approved');")
                    script1.Append("       window.open('edit_emp_address_approve.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

                End If
                '---------------------------------------------------------------------------------
            ElseIf rdQual.Checked Then

                Dim dt2 As DataTable
                dt2 = oh.ExecuteDataSet("SELECT t.qualification, t.institution, t.university, t.percentage, t.year_pass FROM EMPLOY_QUALIFICATION_TEMP t WHERE t.emp_code=" & empcod & " and t.status=0").Tables(0)

                Dim param1(12) As OracleParameter
                For i As Integer = 0 To dt2.Rows.Count - 1
                    param1(0) = New OracleParameter("empcode", OracleType.Number)
                    param1(0).Direction = ParameterDirection.Input
                    param1(0).Value = empcod

                    param1(1) = New OracleParameter("qual", OracleType.Number)
                    param1(1).Value = 0

                    param1(2) = New OracleParameter("num", OracleType.Number)
                    param1(2).Direction = ParameterDirection.Input
                    param1(2).Value = 0



                    param1(3) = New OracleParameter("qualificationid", OracleType.Number)
                    param1(3).Direction = ParameterDirection.Input
                    'param1(3).Value = hidQualID.Value
                    param1(3).Value = dt2.Rows(i)(0)


                    param1(4) = New OracleParameter("institute", OracleType.VarChar)
                    param1(4).Direction = ParameterDirection.Input
                    'If hidInstitution.Value = "" Then
                    '    param1(4).Value = "NIL"
                    'Else
                    '    param1(4).Value = hidInstitution.Value
                    'End If
                    If IsDBNull(dt2.Rows(i)(1)) Then
                        param1(4).Value = "NIL"
                    Else
                        param1(4).Value = dt2.Rows(i)(1)
                    End If

                    param1(5) = New OracleParameter("univer", OracleType.VarChar)
                    param1(5).Direction = ParameterDirection.Input
                    'If hidUniversity.Value = "" Then
                    '    param1(5).Value = "NIL"
                    'Else
                    '    param1(5).Value = hidUniversity.Value
                    'End If
                    If IsDBNull(dt2.Rows(i)(2)) Then
                        param1(5).Value = "NIL"
                    Else
                        param1(5).Value = dt2.Rows(i)(2)
                    End If

                    param1(6) = New OracleParameter("percen", OracleType.Number)
                    param1(6).Direction = ParameterDirection.Input
                    'If hidPercentage.Value = "" Then
                    '    param1(6).Value = 0
                    'Else
                    '    param1(6).Value = hidPercentage.Value

                    'End If

                    If IsDBNull(dt2.Rows(i)(3)) Then
                        param1(6).Value = 0
                    Else
                        param1(6).Value = dt2.Rows(i)(3)
                    End If

                    param1(7) = New OracleParameter("yearpass", OracleType.VarChar)
                    param1(7).Direction = ParameterDirection.Input
                    'If hidYearPass.Value = "" Then
                    '    param1(7).Value = 0
                    'Else
                    '    param1(7).Value = hidYearPass.Value

                    'End If

                    If IsDBNull(dt2.Rows(i)(4)) Then
                        param1(7).Value = 0
                    Else
                        param1(7).Value = dt2.Rows(i)(4)
                    End If

                    param1(8) = New OracleParameter("approved", OracleType.VarChar)
                    param1(8).Direction = ParameterDirection.Input
                    param1(8).Value = enterBy

                    param1(9) = New OracleParameter("high", OracleType.Number)
                    param1(9).Direction = ParameterDirection.Input
                    param1(9).Value = 0

                    param1(11) = New OracleParameter("fl", OracleType.Number, 5)
                    param1(11).Value = 2

                    param1(12) = New OracleParameter("enterBy", OracleType.Number, 5)
                    param1(12).Value = enterBy

                    param1(10) = New OracleParameter("update_flag", OracleType.Number)
                    param1(10).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("EDITEMP_QUALEXP_MACOM", param1)
                Next

                Dim script1 As New System.Text.StringBuilder '
                If param1(10).Value = 1 Then

                    script1.Append("        alert('Successfully Approved');")
                    script1.Append("       window.open('edit_emp_address_approve.aspx','_self');")
                Else
                    script1.Append("        alert('Sorry,Not Approved);")
                    script1.Append("       window.open('edit_emp_address_approve.aspx','_self');")
                End If
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

                '-----------------------------------------------------------------------------------
            ElseIf rdExp.Checked Then
                Dim dt3 As DataTable
                dt3 = oh.ExecuteDataSet("select t.organisation,t.designation,to_char(t.exp_frdate) as exp_frdate,to_char(t.exp_todate)  as exp_todate,t.nature_duty,t.releaving_reason,t.cont_person,t.cont_phone,t.present_salary from EMPLOY_EXPERIENCE_TEMP t where t.emp_code=" & empcod & " and t.status = 0").Tables(0)

                Dim param2(12) As OracleParameter
                For i As Integer = 0 To dt3.Rows.Count - 1
                    param2(0) = New OracleParameter("empcode", OracleType.Number)
                    param2(0).Direction = ParameterDirection.Input
                    param2(0).Value = empcod


                    param2(1) = New OracleParameter("org", OracleType.VarChar)
                    param2(1).Direction = ParameterDirection.Input
                    'param2(1).Value = hidOrganisation.Value
                    param2(1).Value = dt3.Rows(i)(0)

                    param2(2) = New OracleParameter("desig", OracleType.VarChar)
                    param2(2).Direction = ParameterDirection.Input
                    'If hidDesignation.Value = "" Then
                    '    param2(2).Value = "NIL"
                    'Else
                    '    param2(2).Value = hidDesignation.Value
                    'End If
                    If IsDBNull(dt3.Rows(i)(1)) Then
                        param2(2).Value = "NIL"
                    Else
                        param2(2).Value = dt3.Rows(i)(1)
                    End If


                    param2(3) = New OracleParameter("frdate", OracleType.DateTime)
                    param2(3).Direction = ParameterDirection.Input
                    'param2(3).Value = hidExpFrom.Value
                    param2(3).Value = dt3.Rows(i)(2)

                    param2(4) = New OracleParameter("todate", OracleType.DateTime)
                    param2(4).Direction = ParameterDirection.Input
                    'param2(4).Value = hidExpTo.Value
                    param2(4).Value = dt3.Rows(i)(3)

                    param2(5) = New OracleParameter("nature", OracleType.VarChar)
                    param2(5).Direction = ParameterDirection.Input
                    'If hidNatureDuty.Value = "" Then
                    '    param2(5).Value = "NIL"
                    'Else
                    '    param2(5).Value = hidNatureDuty.Value
                    'End If
                    If IsDBNull(dt3.Rows(i)(4)) Then
                        param2(5).Value = "NIL"
                    Else
                        param2(5).Value = dt3.Rows(i)(4)
                    End If

                    param2(6) = New OracleParameter("reason", OracleType.VarChar)
                    param2(6).Direction = ParameterDirection.Input
                    'If hidRelievingReason.Value = "" Then
                    '    param2(6).Value = "NIL"
                    'Else
                    '    param2(6).Value = hidRelievingReason.Value
                    'End If
                    If IsDBNull(dt3.Rows(i)(5)) Then
                        param2(6).Value = "NIL"
                    Else
                        param2(6).Value = dt3.Rows(i)(5)
                    End If

                    param2(7) = New OracleParameter("contact", OracleType.VarChar)
                    param2(7).Direction = ParameterDirection.Input
                    'If hidContactPerson.Value = " " Then
                    '    param2(7).Value = "NIL"
                    'Else
                    '    param2(7).Value = hidContactPerson.Value
                    'End If
                    If IsDBNull(dt3.Rows(i)(6)) Then
                        param2(7).Value = "NIL"
                    Else
                        param2(7).Value = dt3.Rows(i)(6)
                    End If

                    param2(8) = New OracleParameter("contactno", OracleType.VarChar)
                    param2(8).Direction = ParameterDirection.Input
                    'If hidContactPhone.Value = "" Then
                    '    param2(8).Value = "NIL"
                    'Else
                    '    param2(8).Value = hidContactPhone.Value
                    'End If
                    If IsDBNull(dt3.Rows(i)(7)) Then
                        param2(8).Value = "NIL"
                    Else
                        param2(8).Value = dt3.Rows(i)(7)
                    End If

                    param2(9) = New OracleParameter("salary", OracleType.Number)
                    param2(9).Direction = ParameterDirection.Input
                    'If hidSalary.Value = "" Then
                    '    param2(9).Value = 0
                    'Else
                    '    param2(9).Value = hidSalary.Value
                    'End If
                    If IsDBNull(dt3.Rows(i)(8)) Then
                        param2(9).Value = 0
                    Else
                        param2(9).Value = dt3.Rows(i)(8)
                    End If
                    param2(11) = New OracleParameter("fl", OracleType.Number, 5)
                    param2(11).Value = 3

                    param2(12) = New OracleParameter("enterBy", OracleType.Number, 5)
                    param2(12).Value = enterBy

                    param2(10) = New OracleParameter("update_flag", OracleType.Number)
                    param2(10).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("EDITEMP_EXP_MACOM", param2)
                Next
                Dim script1 As New System.Text.StringBuilder
                If param2(10).Value = 1 Then
                    script1.Append("        alert('Successfully Approved');")
                    script1.Append("       window.open('edit_emp_address_approve.aspx','_self');")

                Else
                    script1.Append("        alert('Sorry,Not Approved');")
                    script1.Append("       window.open('edit_emp_address_approve.aspx','_self');")
                End If
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            End If
            'Dim script As New System.Text.StringBuilder
            'Script.Append("       window.open('edit_emp_address_approve.aspx','_self');")
        End If
    End Sub

    Protected Sub cmb_code_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_code.SelectedIndexChanged


        Dim empId As String = Me.cmb_code.SelectedItem.Text
        Dim value As String = empId
        Dim result() As String = value.Split("-")
        Dim empcod As String = result(0)
        Dim empname As String = result(1)
        If rdPersonal.Checked = True Then
            Dim dt As DataTable
            dt = oh.ExecuteDataSet("select ap.perm_add1,post1.sr_number,dis1.district_id,state1.state_id,post1.pin_code,ap.pres_add1,post2.sr_number,dis2.district_id,state2.state_id,post2.pin_code from employ_person_temp ap,post_master post1,district_master dis1,state_master state1,post_master post2,district_master dis2,state_master state2 where ap.emp_code=" & empcod & " and ap.perm_pin=post1.sr_number and post1.district_id=dis1.district_id and dis1.state_id=state1.state_id and ap.pres_pin=post2.sr_number and post2.district_id=dis2.district_id and dis2.state_id=state2.state_id").Tables(0)
            Dim dt1 As DataTable = oh.ExecuteDataSet("select ap.emp_name, ap.landmark, ap.pp, ap.res_phone, ap.cont_phone, ap.father_name, ap.birth_date, ap.sex, ap.emp_email, ap.marital_status, ap.spouse_name, ap.child_number, b.blood_type, i.identity_name, ap.idproof_number, r.religion, ap.caste from employ_person_temp ap left join religion_master r on r.religion_id = ap.religion_id left join bloodgroup_master b on b.blood_id = ap.blood_id left join identity_gl4 i on i.identity_id = ap.id_proof where ap.emp_code = " & empcod & " and ap.status = 0").Tables(0)

            Me.txt_house1.Text = dt.Rows(0)(0)
            Me.txt_pin1.Text = dt.Rows(0)(4)
            Me.txt_house2.Text = dt.Rows(0)(5)
            Me.txt_pin2.Text = dt.Rows(0)(9)
            Dim state1, state2 As DataTable
            state1 = oh.ExecuteDataSet("select state_name from state_master where state_id=" & dt.Rows(0)(3) & "").Tables(0)
            Me.cmb_state1.Text = state1.Rows(0)(0)
            state2 = oh.ExecuteDataSet("select state_name from state_master where state_id=" & dt.Rows(0)(8) & "").Tables(0)
            Me.cmb_state2.Text = state2.Rows(0)(0)

            Dim district1, district2 As DataTable
            district1 = oh.ExecuteDataSet("select district_name from district_master where district_id='" & dt.Rows(0)(2) & "'").Tables(0)
            Me.cmb_district1.Text = district1.Rows(0)(0)
            district2 = oh.ExecuteDataSet("select district_name from district_master where district_id='" & dt.Rows(0)(7) & "'").Tables(0)
            Me.cmb_district2.Text = district2.Rows(0)(0)

            Dim post1, post2 As DataTable
            post1 = oh.ExecuteDataSet("select post_office from post_master where sr_number=" & dt.Rows(0)(1) & "").Tables(0)
            Me.cmb_post1.Text = post1.Rows(0)(0)
            post2 = oh.ExecuteDataSet("select post_office from post_master where sr_number=" & dt.Rows(0)(6) & "").Tables(0)
            Me.cmb_post2.Text = post2.Rows(0)(0)

            Me.txt_name.Text = dt1.Rows(0)(0)
            Me.txt_landmark.Text = dt1.Rows(0)(1)
            If dt1.Rows(0)(2) = 0 Then
                Me.chk_pp.Checked = True
                'Else
                '    Me.chk_pp.Checked = False
            End If
            Me.txt_phone.Text = dt1.Rows(0)(3)
            Me.txt_contactno.Text = dt1.Rows(0)(4)
            Me.txt_email.Text = dt1.Rows(0)(8)
            If dt1.Rows(0)(7) = 1 Then
                Me.rdb_genderlist.SelectedValue = "1"
            Else
                Me.rdb_genderlist.SelectedValue = "0"
            End If

            Me.txt_father.Text = dt1.Rows(0)(5)
            If dt1.Rows(0)(9) = 2 Then
                Me.rdb_maritallist.SelectedValue = "2"
            Else
                Me.rdb_maritallist.SelectedValue = "1"
            End If
            'Me.txt_spouse.Text = dt1.Rows(0)(5)
            'If dt1.Rows(0)(10) = "" Then
            If IsDBNull(dt1.Rows(0)(10)) Then
                Me.txt_spouse.Text = ""
            Else
                Me.txt_spouse.Text = dt1.Rows(0)(10)
            End If

            Me.txt_dob.Text = dt1.Rows(0)(6)
            Dim dte, dte1 As Date
            Dim age As Integer
            dte = Me.txt_dob.Text
            dte1 = Now.Date
            age = DateDiff(DateInterval.Year, dte, dte1)
            Me.txt_age.Text = age
            If age < 18 Then
                Me.txt_dob.Text = ""
            End If

            Me.txt_noofchildren.Text = dt1.Rows(0)(11)
            'Me.txt_age.Text =


            Me.cmb_religion.Text = dt1.Rows(0)(15)
            Me.txt_caste.Text = dt1.Rows(0)(16)

            Me.cmb_idproof.Text = dt1.Rows(0)(13)


            Me.txt_idno.Text = dt1.Rows(0)(14)

            'bg = oh.ExecuteDataSet("select blood_type from bloodgroup_master where blood_id=" & dt1.Rows(0)(12) & "").Tables(0)
            Me.cmb_bg.Text = dt1.Rows(0)(12)

        ElseIf rdQual.Checked = True Then

            Dim dt2 As DataTable
            dt2 = oh.ExecuteDataSet("SELECT qm.qualification,t.institution,t.university,t.percentage,t.year_pass FROM EMPLOY_QUALIFICATION_TEMP t,qualification_master qm  WHERE t.emp_code = " & empcod & " and t.qualification = qm.qualification_id and t.status = 0   ").Tables(0)
            'dt2 = oh.ExecuteDataSet("SELECT t.qualification, t.institution, t.university, t.percentage, t.year_pass FROM EMPLOY_QUALIFICATION_TEMP t WHERE t.emp_code=" & empcod & " and t.status=0").Tables(0)
            'Dim qualTable As DataTable = oh.ExecuteDataSet("SELECT qualification FROM qualification_master WHERE qualification_id=" & dt2.Rows(1)(0) & "").Tables(0)
            'ListBox1.Items.Clear()

            'For Each row As DataRow In dt2.Rows
            '    ' Get qualification name for each qualification ID
            '    Dim qualID As Integer = Convert.ToInt32(row("qualification"))
            '    Dim qualTable As DataTable = oh.ExecuteDataSet("SELECT qualification FROM qualification_master WHERE qualification_id=" & qualID & "").Tables(0)
            '    Dim qualName As String = If(qualTable.Rows.Count > 0, qualTable.Rows(0)("qualification").ToString(), "Unknown")

            '    hidQualID.Value = qualID.ToString()
            '    hidInstitution.Value = row("institution").ToString()
            '    hidUniversity.Value = row("university").ToString()
            '    hidPercentage.Value = row("percentage").ToString()
            '    hidYearPass.Value = row("year_pass").ToString()

            '    ' Format the display text
            '    Dim entry As String = qualName & " - " & row("institution") & " - " & row("university") & " - " & row("percentage") & " - " & row("year_pass")
            '    ListBox1.Items.Add(entry)
            'Next
            spanQualification.Visible = True

            For Each row As DataRow In dt2.Rows
                GridView1.DataSource = dt2
                GridView1.DataBind()
            Next

        ElseIf rdExp.Checked = True Then
            Dim dt3 As DataTable
            dt3 = oh.ExecuteDataSet("select t.organisation,t.designation,to_char(t.exp_frdate) as exp_frdate,to_char(t.exp_todate)  as exp_todate,t.nature_duty,t.releaving_reason,t.cont_person,t.cont_phone,t.present_salary from EMPLOY_EXPERIENCE_TEMP t where t.emp_code=" & empcod & " and t.status = 0").Tables(0)
            'For Each row As DataRow In dt3.Rows
            '    hidOrganisation.Value = row("organisation").ToString()
            '    hidDesignation.Value = row("designation").ToString()
            '    hidExpFrom.Value = row("exp_frdate").ToString()
            '    hidExpTo.Value = row("exp_todate").ToString()
            '    hidNatureDuty.Value = row("nature_duty").ToString()
            '    hidRelievingReason.Value = row("releaving_reason").ToString()
            '    hidContactPerson.Value = row("cont_person").ToString()
            '    hidContactPhone.Value = row("cont_phone").ToString()
            '    hidSalary.Value = row("present_salary").ToString()
            '    ' Format the display text for each employment experience record
            '    Dim entry As String = row("organisation").ToString() & " - " &
            '                  row("designation").ToString() & " - " &
            '                  row("exp_frdate").ToString() & " - " & row("exp_todate").ToString() & " - " &
            '                  row("nature_duty").ToString() & " - " &
            '                  row("releaving_reason").ToString() & " - " &
            '                  row("cont_person").ToString() & " - " &
            '                  row("cont_phone").ToString()
            '    row("present_salary").ToString()

            '    ListBox2.Items.Add(entry)
            'Next
            spanExp.Visible = True
            For Each row As DataRow In dt3.Rows
                GridView2.DataSource = dt3
                GridView2.DataBind()
            Next


        End If


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txt_house1.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=134 and emp_id=" & UserCode).Tables(0).Rows(0)(0)
        If acce > 0 Then

            If Not IsPostBack Then
                Dim dt As DataTable = oh.ExecuteDataSet("select 0 as Empcode,'Select Employee Name' as Empname from dual union select emp_code,emp_code || ' - ' || emp_name from mactech.employ_person_temp e where  e.status =0").Tables(0)
                Me.cmb_code.DataSource = dt
                Me.cmb_code.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_code.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_code.DataBind()

            End If

            If rdPersonal.Checked Then
                section1.Style("display") = "block"
                section2.Style("display") = "none"
                section3.Style("display") = "none"

            End If
            If rdQual.Checked Then
                spanQualification.Visible = False
            End If
            If rdExp.Checked Then
                spanExp.Visible = False
            End If
        Else
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('You are not Authorized');")
            script1.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If



    End Sub




End Class