Imports System.Data
Imports System.Data.OracleClient
Partial Class payroll_posting_emp_appln1_fbd1c3001434
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim res, fid As String
    Dim oh As New helper.oracle.OracleHelper
    Dim val, ld, flag, appln_no As Integer
    Dim dt, dt1, dt2, dt3, dt4, emp_dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "ADD / EDIT APPLICATION"
        fid = Session("firm_id")


      

        If fid = 27 Then
            Response.Redirect("emp_appln1new_mafarm.aspx")
            Exit Sub
        End If
        If fid = 24 Then
            Response.Redirect("emp_appln1new_majewel.aspx")
            Exit Sub
        End If
        If fid = 2 Then
            Response.Redirect("emp_applnmab.aspx")
            Exit Sub
        End If


        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txt_age.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server(arg,context) { " & cbref & "; } "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)

        If Session("access_id") = 33 Then
            If Not IsPostBack Then
                val = 0
                ld = 1
                flag = 0
                statefill(Me.cmb_state_select, Me.cmb_dist_select, Me.cmb_post_select, Me.Txt_pin_select)
                'statefill(Me.cmb_pres_state, Me.cmb_pres_district, Me.cmb_pres_post, Me.txt_pres_pin)
                bloodfill()
                religionfill()
                idfill()
                'empfill()
                nearbrfill()
                Me.hid_perm_state.Value = 0
                Me.hid_pres_state.Value = 0
                Me.hid_perm_district.Value = 0
                Me.hid_pres_district.Value = 0
                Me.hid_perm_post.Value = 0
                Me.hid_pres_post.Value = 0
                Me.rd_marital_yes.Checked = True
                Me.rdb_new.Checked = True
                Me.cmd_edit.Enabled = False
            End If

            If Me.rdb_edit.Checked = True Then

                Me.cmd_confirm.Visible = False
                Me.cmd_edit.Enabled = True
                Me.txt_Appln_no.Visible = True


            End If

        Else
            Response.Redirect("../../show_err.aspx")
        End If
    End Sub
    Sub nearbrfill()
        dt1 = oh.ExecuteDataSet("select 0,'---SELECT---' branch_name,0 STATE_ID  from dual union select branch_id,branch_name,state_id from branch_master where branch_id not in (0,9999) order by branch_name").Tables(0)
        Me.cmb_nrbr.DataSource = dt1
        Me.cmb_nrbr.DataTextField = dt1.Columns(1).ColumnName
        Me.cmb_nrbr.DataValueField = dt1.Columns(0).ColumnName
        Me.cmb_nrbr.DataBind()
    End Sub
    Sub statefill(ByVal a As DropDownList, ByVal b As DropDownList, ByVal c As DropDownList, ByVal d As TextBox)
        dt1 = oh.ExecuteDataSet("select '---- SELECT-----' as state_name,0 from dual union select upper(state_name), state_id from state_master order by state_name").Tables(0)
        a.DataSource = dt1
        a.DataTextField = dt1.Columns(0).ColumnName
        a.DataValueField = dt1.Columns(1).ColumnName
        a.DataBind()
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

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)
        Dim dt As DataTable
        Select Case (x)
            Case "1"           'Permanant State Fill
                dt = oh.ExecuteDataSet("select district_id || '!' || upper(district_name) from district_master where state_id='" & str(1) & "' order by upper(district_name) ").Tables(0)
                If dt.Rows.Count > 0 Then
                    Dim dr As DataRow
                    For Each dr In dt.Rows
                        st.Append(dr(0))
                        st.Append("#")
                    Next
                    st = st.Append("$")

                    Dim dt1 As DataTable
                    dt1 = oh.ExecuteDataSet("select sr_number || '!' || upper(post_office) from post_master where district_id='" & dt.Rows(0)(0).ToString.Split("!")(0) & "' order by upper(post_office) ").Tables(0)
                    If dt1.Rows.Count > 0 Then
                        Dim dr1 As DataRow
                        For Each dr1 In dt1.Rows
                            st.Append(dr1(0))
                            st.Append("#")
                        Next
                        st = st.Append("$")
                        Dim dt2 As DataTable
                        dt2 = oh.ExecuteDataSet("select pin_code from post_master where sr_number ='" & dt1.Rows(0)(0).ToString.Split("!")(0) & "'").Tables(0)
                        If dt2.Rows.Count > 0 Then
                            st.Append(dt2.Rows(0)(0))
                            st.Append("#")
                        Else
                            st.Append("$")
                        End If
                    Else
                        st.Append("$$")
                    End If
                Else
                    st.Append("$$$")
                End If

            Case "2"           'Permanant District Fill
                Dim dt1 As DataTable
                dt1 = oh.ExecuteDataSet("select sr_number || '!' || upper(post_office) from post_master where district_id='" & str(1) & "' order by upper(post_office) ").Tables(0)
                If dt1.Rows.Count > 0 Then
                    Dim dr1 As DataRow
                    For Each dr1 In dt1.Rows
                        st.Append(dr1(0))
                        st.Append("#")
                    Next
                    st = st.Append("$")
                    Dim dt2 As DataTable
                    dt2 = oh.ExecuteDataSet("select pin_code from post_master where sr_number ='" & dt1.Rows(0)(0).ToString.Split("!")(0) & "'").Tables(0)

                    'dt2 = oh.ExecuteDataSet("SELECT district_name AS namee FROM district_master WHERE state_id = '" & str(1) & "' ORDER BY UPPER(district_name) ASC").Tables(0)
                    If dt2.Rows.Count > 0 Then
                        st.Append(dt2.Rows(0)(0))
                        st.Append("#")
                    Else
                        st.Append("@$")
                    End If
                Else
                    st.Append("$$")
                End If

            Case "3"           'Permanant post Fill
                Dim dt2 As DataTable
                dt2 = oh.ExecuteDataSet("select pin_code from post_master where sr_number ='" & str(1) & "'").Tables(0)
                If dt2.Rows.Count > 0 Then
                    st.Append(dt2.Rows(0)(0))
                    st.Append("#")
                Else
                    st.Append("$")
                End If

            Case "4"           'Present State Fill
                dt = oh.ExecuteDataSet("select district_id || '!' || upper(district_name) from district_master where state_id='" & str(1) & "' order by upper(district_name) ").Tables(0)
                If dt.Rows.Count > 0 Then
                    Dim dr As DataRow
                    For Each dr In dt.Rows
                        st.Append(dr(0))
                        st.Append("#")
                    Next
                    st = st.Append("$")

                    Dim dt1 As DataTable
                    dt1 = oh.ExecuteDataSet("select sr_number || '!' || upper(post_office) from post_master where district_id='" & dt.Rows(0)(0).ToString.Split("!")(0) & "' order by upper(post_office) ").Tables(0)
                    If dt1.Rows.Count > 0 Then
                        Dim dr1 As DataRow
                        For Each dr1 In dt1.Rows
                            st.Append(dr1(0))
                            st.Append("#")
                        Next
                        st = st.Append("$")
                        Dim dt2 As DataTable
                        dt2 = oh.ExecuteDataSet("select pin_code from post_master where sr_number ='" & dt1.Rows(0)(0).ToString.Split("!")(0) & "'").Tables(0)
                        If dt2.Rows.Count > 0 Then
                            st.Append(dt2.Rows(0)(0))
                            st.Append("#")
                        Else
                            st.Append("$")
                        End If
                    Else
                        st.Append("$$")
                    End If
                Else
                    st.Append("$$$")
                End If

           
            Case "5"           'Present District Fill
                Dim dt1 As DataTable
                dt1 = oh.ExecuteDataSet("select sr_number || '!' || upper(post_office) from post_master where district_id='" & str(1) & "' order by upper(post_office) ").Tables(0)
                If dt1.Rows.Count > 0 Then
                    Dim dr1 As DataRow
                    For Each dr1 In dt1.Rows
                        st.Append(dr1(0))
                        st.Append("#")
                    Next
                    st = st.Append("$")
                    Dim dt2 As DataTable
                    dt2 = oh.ExecuteDataSet("select pin_code from post_master where sr_number ='" & dt1.Rows(0)(0).ToString.Split("!")(0) & "'").Tables(0)
                    If dt2.Rows.Count > 0 Then
                        st.Append(dt2.Rows(0)(0))
                        st.Append("#")
                    Else
                        st.Append("$")
                    End If
                Else
                    st.Append("$$")
                End If

          
            Case "6"           'Present post Fill
                Dim dt2 As DataTable
                dt2 = oh.ExecuteDataSet("select pin_code from post_master where sr_number ='" & str(1) & "'").Tables(0)
                If dt2.Rows.Count > 0 Then
                    st.Append(dt2.Rows(0)(0))
                    st.Append("#")
                Else
                    st.Append("$")
                End If

            Case "7"
                Dim sr() As String
                sr = str(1).Split("#")
                dt = oh.ExecuteDataSet("select district_id || '!' || upper(district_name) from district_master where state_id='" & sr(0) & "' order by upper(district_name) ").Tables(0)
                If dt.Rows.Count > 0 Then
                    Dim dr As DataRow
                    For Each dr In dt.Rows
                        st.Append(dr(0))
                        st.Append("#")
                    Next
                    st = st.Append("$")

                    Dim dt1 As DataTable
                    dt1 = oh.ExecuteDataSet("select sr_number || '!' || upper(post_office) from post_master where district_id='" & sr(1) & "' order by upper(post_office) ").Tables(0)
                    If dt1.Rows.Count > 0 Then
                        Dim dr1 As DataRow
                        For Each dr1 In dt1.Rows
                            st.Append(dr1(0))
                            st.Append("#")
                        Next
                        st = st.Append("$")
                    Else
                        st.Append("$$")
                    End If
                Else
                    st.Append("$$$")
                End If

            Case "8"
                Dim dte, dte1 As Date
                Dim age As Integer
                dte = CDate(str(1))
                dte1 = Now.Date
                age = DateDiff(DateInterval.Year, dte, dte1)
                Me.txt_age.Text = age
                If age >= 18 Then
                    st.Append(age)
                End If
                st.Append("$")


            Case "10"
                Dim sr() As String
                sr = str(1).Split("#")
                emp_dt = oh.ExecuteDataSet("select t.emp_code||'!'||t.emp_code||'-'||t.emp_name from employee_master t join mactech.employ_firm f on f.emp_code=t.emp_code and f.firm_id=" & fid & "where t.emp_code>9999 and t.status_id=1 order by t.emp_code").Tables(0)
                If emp_dt.Rows.Count > 0 Then
                    Dim dr1 As DataRow
                    For Each dr1 In emp_dt.Rows
                        st.Append(dr1(0))
                        st.Append("#")
                    Next
                    st = st.Append("$")
                Else
                    st.Append("$$")
                End If
                st.Append("10ok")

            Case "9"
                Dim dtp As DataTable
                dtp = oh.ExecuteDataSet("select ap.appln_name||'!'||ap.perm_add1||'!'||post1.sr_number||'!'||dis1.district_id||'!'||state1.state_id||'!'||post1.pin_code||'!'||ap.pres_add1||'!'||post2.sr_number||'!'||dis2.district_id||'!'||state2.state_id||'!'||post2.pin_code||'!'||ap.landmark||'!'||ap.res_phone||'!'||ap.cont_phone||'!'||ap.appln_email||'!'||bld.blood_id||'!'||id.identity_id||'!'||ap.idproof_number||'!'||ap.pp||'!'||ap.religion_id||'!'||ap.caste||'!'||ap.father_name||'!'||ap.gender||'!'||ap.marital_status||'!'||ap.spouse_name||'!'||ap.birth_date||'!'||ap.child_number||'!'||ap.vacancy_info||'!'||ap.reffered_by||'!'||ap.other_dtl||'!'||ap.near_branch||'!'||ap.sslc_no ,state1.state_id, state2.state_id,dis1.district_id ,dis2.district_id,post1.sr_number,post2.sr_number   from appln_pers_dtl    ap,post_master       post1,district_master   dis1,state_master      state1,post_master       post2,district_master   dis2,state_master      state2,bloodgroup_master bld,identity_gl4      id where ap.appln_no = " & str(1) & " and ap.perm_pin = post1.sr_number and post1.district_id = dis1.district_id and dis1.state_id = state1.state_id and ap.pres_pin = post2.sr_number and post2.district_id = dis2.district_id and dis2.state_id = state2.state_id and ap.blood_id = bld.blood_id and ap.id_proof = id.identity_id").Tables(0)
                If dtp.Rows.Count > 0 Then
                    st.Append(dtp.Rows(0)(0))
                    st.Append("#")
                    st.Append("$")
                    'permanant ditrict fill
                    dt = oh.ExecuteDataSet("select district_id||'!'||upper(district_name) from district_master where state_id='" & dtp.Rows(0)(1) & "' order by upper(district_name) ").Tables(0)
                    Dim dr As DataRow
                    For Each dr In dt.Rows
                        st.Append(dr(0))
                        st.Append("#")
                    Next
                    st = st.Append("$")

                    Dim dt1 As DataTable
                    dt1 = oh.ExecuteDataSet("select sr_number||'!'||upper(post_office) from post_master where district_id='" & dtp.Rows(0)(3) & "' order by upper(post_office) ").Tables(0)
                    Dim dr1 As DataRow
                    For Each dr1 In dt1.Rows
                        st.Append(dr1(0))
                        st.Append("#")
                    Next
                    st = st.Append("$")
                    Dim dt2 As DataTable
                    dt2 = oh.ExecuteDataSet("select pin_code from post_master where sr_number ='" & dtp.Rows(0)(5) & "'").Tables(0)
                    st.Append(dt2.Rows(0)(0))
                    st.Append("#")
                    st.Append("$")

                    'present district fill
                    dt = oh.ExecuteDataSet("select district_id||'!'||upper(district_name) from district_master where state_id='" & dtp.Rows(0)(2) & "' order by upper(district_name) ").Tables(0)
                    For Each dr In dt.Rows
                        st.Append(dr(0))
                        st.Append("#")
                    Next
                    st = st.Append("$")
                    dt1 = oh.ExecuteDataSet("select sr_number||'!'||upper(post_office) from post_master where district_id='" & dtp.Rows(0)(4) & "' order by upper(post_office) ").Tables(0)
                    For Each dr1 In dt1.Rows
                        st.Append(dr1(0))
                        st.Append("#")
                    Next
                    st = st.Append("$")
                    dt2 = oh.ExecuteDataSet("select pin_code from post_master where sr_number ='" & dtp.Rows(0)(6) & "'").Tables(0)
                    st.Append(dt2.Rows(0)(0))
                    st.Append("#")
                    st.Append("$")

                Else
                    st.Append("$")
                End If
        End Select
        res = st.ToString
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click


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
        op(3).Value = Me.hid_perm_post.Value
        op(3).Direction = ParameterDirection.Input

        op(4) = New OracleParameter("cpres_pin", OracleType.Number, 7)
        op(4).Value = Me.hid_pres_post.Value
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
        If Me.rd_marital_yes.Checked = True Then
            pq = 2
        Else
            pq = 1
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
        op(24) = New OracleParameter("c_appln_no", OracleType.VarChar, 200)
        op(24).Direction = ParameterDirection.Output
        op(25) = New OracleParameter("nrbr", OracleType.Number, 4)
        op(25).Value = Me.cmb_nrbr.Value
        op(25).Direction = ParameterDirection.Input
        op(27) = New OracleParameter("sslcno", OracleType.VarChar, 20)
        op(27).Value = Me.txt_sslc.Text
        op(27).Direction = ParameterDirection.Input

        op(26) = New OracleParameter("flag", OracleType.Number, 2)
        op(26).Direction = ParameterDirection.Output

        oh.ExecuteNonQuery("hrm_new_appln", op)
        Dim cl_script0 As New System.Text.StringBuilder
        If op(26).Value = 1 Then
            cl_script0.Append(" alert(' Successfully Confirmed Application No: " & op(24).Value & "');")
            cl_script0.Append("       window.open('hrm_qualification_add.aspx?appno=" & op(24).Value & " ','_self');")
        End If

        '    ' Format the application number to ensure it's always four digits
        '    Dim appNumber As String = op(24).Value.ToString().PadRight(6, "")

        '    ' Append the alert script with the formatted application number
        '    cl_script0.Append("alert('Successfully Confirmed Application No: " & appNumber & "');")
        '    ' cl_script0.Append("alert('" & appNumber & "');")
        '    cl_script0.Append("window.open('hrm_qualification_add.aspx?appno=" & appNumber & " ','_self');")
        '    'cl_script0.Append("window.open('emp_appln1new.aspx','_self');")
        'Else
        '    ' Append the alert script with the formatted application number for the else condition
        '    'cl_script0.Append("alert('" & appNumber & "');")
        'End If


        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
    End Sub

   
    Protected Sub cmd_edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_edit.Click


        Dim script1 As New StringBuilder()
        Dim regex As New System.Text.RegularExpressions.Regex("[^a-zA-Z\s]")


        If regex.IsMatch(Me.txt_name.Type, "[^a-zA-Z\s]") Then
            script1.Append("alert('Numbers and special characters are not allowed..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
            Exit Sub
        End If


        If regex.IsMatch(Me.txt_fathus.Text) Then
            script1.Append("alert('Numbers and special characters are not allowed..!!'');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
            Exit Sub
        End If



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
        op(3).Value = Me.hid_perm_post.Value
        op(3).Direction = ParameterDirection.Input

        op(4) = New OracleParameter("cpres_pin", OracleType.Number, 7)
        op(4).Value = Me.hid_pres_post.Value
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
        If Me.rd_marital_yes.Checked = True Then
            pq = 2
        Else
            pq = 1
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
        op(24) = New OracleParameter("msg", OracleType.VarChar, 250)
        op(24).Direction = ParameterDirection.Output
        op(25) = New OracleParameter("nrbr", OracleType.Number, 4)
        op(25).Value = Me.cmb_nrbr.Value
        op(25).Direction = ParameterDirection.Input
     
        op(26) = New OracleParameter("appno", OracleType.Number, 10)
        op(26).Value = Me.txt_Appln_no.Value
        op(26).Direction = ParameterDirection.Input

        op(27) = New OracleParameter("sslcno", OracleType.VarChar, 16)
        op(27).Value = Me.txt_Appln_no.Value
        op(27).Direction = ParameterDirection.Input

        oh.ExecuteNonQuery("hrm_edit_appln", op)
        Dim cl_script0 As New System.Text.StringBuilder

        cl_script0.Append("         alert('" & op(24).Value & "');")
        cl_script0.Append("       window.open('hrm_appln_qualif_edit.aspx?appno=" & Me.txt_Appln_no.Value & "','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)


    End Sub

   
    'Protected Sub cmb_state_select_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_state_select.SelectedIndexChanged
    '    statefill(Me.cmb_state_select, Me.cmb_dist_select, Me.cmb_post_select, Me.Txt_pin_select)
    'End Sub

    Protected Sub btnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnext.Click
        Response.Redirect("../../home.aspx")
    End Sub

   

    Protected Sub Txt_pin_select_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_pin_select.TextChanged



        Dim script1 As New StringBuilder()
        Dim regex As New System.Text.RegularExpressions.Regex("[^a-zA-Z]")


        If regex.IsMatch(Me.txt_name.Type) Then
            script1.Append("alert('Numbers and special characters are not allowed..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
            Exit Sub
        End If


        If regex.IsMatch(Me.txt_fathus.Text) Then
            script1.Append("alert('Numbers and special characters are not allowed..!!'');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
            Exit Sub
        End If


        If (Me.Txt_pin_select.Text.Length < 5) Then
            script1.Append("        alert('Invalid Pincode..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If












        Dim pincode As String = Txt_pin_select.Text.Trim()

        Dim dt As DataTable

        If Session("firm_id") = 8 Then


            dt = oh.ExecuteDataSet("select -1, '---- SELECT-----' post_office from dual union all select pm.sr_number, pm.post_office as name FROM post_master pm WHERE pm.pin_code = '" & pincode & "' ORDER BY post_office asc").Tables(0)
        Else
            dt = oh.ExecuteDataSet("select -1, '---- SELECT-----' post_office from dual union all select pm.sr_number, pm.post_office as name FROM post_master pm WHERE pm.pin_code = '" & pincode & "' ORDER BY post_office asc").Tables(0)
        End If




        If dt.Rows.Count > 0 Then
            Me.cmb_post_select.DataSource = dt
            Me.cmb_post_select.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_post_select.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_post_select.DataBind()
        End If


    End Sub

    Protected Sub cmb_post_select_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_post_select.SelectedIndexChanged

        Dim selectedValue As String = cmb_post_select.SelectedValue


        Dim state As String = cmb_state_select.SelectedValue

        Dim dttt As DataTable


        If Session("firm_id") = 8 Then

            dttt = oh.ExecuteDataSet("SELECT district_name AS namee FROM district_master WHERE state_id = '" & state & "' ORDER BY UPPER(district_name) ASC").Tables(0)


        Else
            dttt = oh.ExecuteDataSet("SELECT district_name AS namee FROM district_master WHERE state_id = '" & state & "' ORDER BY UPPER(district_name) ASC").Tables(0)

        End If


        If dttt.Rows.Count > 0 Then
            Me.cmb_dist_select.DataSource = dttt
            'Me.cmb_dist_select.DataValueField = dttt.Columns(0).ColumnName
            Me.cmb_dist_select.DataTextField = "namee"
            Me.cmb_dist_select.DataBind()
        End If

    End Sub

    Protected Sub txt_name_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_name.ServerChange

        Dim script1 As New StringBuilder()

        Dim regex As New System.Text.RegularExpressions.Regex("[^a-zA-Z]")


        If regex.IsMatch(Me.txt_name.Type) Then
            script1.Append("alert('Numbers and special characters are not allowed..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
            Exit Sub
        End If


        If regex.IsMatch(Me.txt_fathus.Text) Then
            script1.Append("alert('Numbers and special characters are not allowed..!!'');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
            Exit Sub
        End If


      


    End Sub

    Protected Sub txt_Perm_hs_select_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Perm_hs_select.TextChanged

        Dim script1 As New StringBuilder()

        Dim regex As New System.Text.RegularExpressions.Regex("[^a-zA-Z]")


        If regex.IsMatch(Me.txt_name.Type) Then
            script1.Append("alert('Numbers and special characters are not allowed..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
            Exit Sub
        End If


        If regex.IsMatch(Me.txt_fathus.Text) Then
            script1.Append("alert('Numbers and special characters are not allowed..!!'');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
            Exit Sub
        End If


    End Sub

    Protected Sub txt_spousename_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_spousename.TextChanged

        Dim script1 As New StringBuilder()

        Dim regex As New System.Text.RegularExpressions.Regex("[^a-zA-Z]")


        If regex.IsMatch(Me.txt_spousename.Text) Then
            script1.Append("alert('Numbers and special characters are not allowed..!!'');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
            Exit Sub
        End If

    End Sub
End Class
