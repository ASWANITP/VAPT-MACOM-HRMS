Imports System.Data
Imports System.Data.oracleclient
Imports System.IO
Partial Class macom_shift_change_leave_appli_to_mageeth_da50c7f93658
    Inherits System.Web.UI.Page

    Implements System.Web.UI.ICallbackEventHandler
    Dim sql, fnm As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim res As String
    Dim usr() As String

    Dim firmid As Integer
    Dim branchid As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.orow.Visible = False
            Me.crow.Visible = False
            Me.vrow.Visible = False
            Dim script_val As String
            script_val = "var loanno;" & "loanno='" & "" & Me.txt_ldays.ClientID & "'" & " ; "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "sub_call_receiver", "context")
            Dim cbscript As String = "function sub_call_server(arg,context) { " & cbref & "; } "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "sub_call_server", cbscript, True)


            firmid = Convert.ToInt32(Me.Session("firm_id"))
            branchid = Me.Session("branch_id")

            'Dim sc As String = "var cont_name;cont_name='" & Me.txt_lcasual.ClientID & "';"
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var2", sc, True)
            Dim emp As New DataTable
            usr = Me.Session("user_id").ToString.Split("!")
            '---sh
            If firmid = 28 And Me.Session("branch_id") = 3439 Then
                sql = "select e.emp_code, e.emp_name, p.post_name, d.designation, dd.dep_name, b.branch_name, e.join_dt, case when e.emp_type = 1 then 'REGULAR' else 'OUTSOURCE' end , dm.dep_id from employee_master e, post_mst p, designation_master d, branch_dtl_new b, department_mst_mageeth dm, department_mst dd where e.post_id = p.post_id and d.designation_id = e.designation_id and e.branch_id = b.branch_id and e.emp_code = " & usr(0) & " and dd.dep_id = dm.dep_id and dm.emp_code = e.emp_code"
            ElseIf firmid = 28 And Me.Session("branch_id") = 3427 Then
                sql = "select e.emp_code, e.emp_name, p.post_name, d.designation, dd.dep_name, b.branch_name, e.join_dt, case when e.emp_type = 1 then 'REGULAR' else 'OUTSOURCE' end , dm.dep_id from employee_master e, post_mst p, designation_master d, branch_dtl_new b, department_mst_mps dm, department_mst dd where e.post_id = p.post_id and d.designation_id = e.designation_id and e.branch_id = b.branch_id and e.emp_code = " & usr(0) & " and dd.dep_id = dm.dep_id and dm.emp_code = e.emp_code"
            Else
                sql = "select e.emp_code,e.emp_name,p.post_name,d.designation,dm.dep_name,b.branch_name,e.join_dt,case when e.emp_type=1 then 'REGULAR' else 'OUTSOURCE' end,dm.dep_id from employee_master e,post_mst p,designation_master d,branch_dtl_new b,department_mst dm where e.post_id=p.post_id and e.department_id=dm.dep_id and d.designation_id=e.designation_id and e.branch_id=b.branch_id and emp_code=" & usr(0) & ""
            End If
            '---sh

            emp = oh.ExecuteDataSet(sql).Tables(0)
            If emp.Rows.Count > 0 Then
                Me.txt_ecode.Value = usr(0)
                Me.txt_ename.Value = emp.Rows(0)(1)
                Me.txt_epost.Value = emp.Rows(0)(2)
                Me.txt_edesig.Value = emp.Rows(0)(3)
                Me.txt_edep.Value = emp.Rows(0)(4)
                Me.txt_ebr.Value = emp.Rows(0)(5)
                Me.txt_ejoindt.Value = Format(emp.Rows(0)(6), "dd/MMM/yyyy")
                Me.txt_etype.Value = emp.Rows(0)(7)
                Me.txt_lappdt.Value = Format(Date.Now, "dd/MMM/yyyy")
                sql = "select leave_id,leave_days from employ_leave_master where emp_code=" & usr(0) & ""
                emp = oh.ExecuteDataSet(sql).Tables(0)


                'Newly added code.........
                'Dim query = "select nvl(sum((t.leave_days )),0) as a from hrm_leave_apply_sanction t where t.reject_reason is null and t.status_id in (0,4,5) and t.emp_code=" & usr(0) & " and t.leave_id=1 union all select nvl(sum((t.leave_days )),0) as b  from hrm_leave_apply_sanction t where t.reject_reason is null and t.status_id in (0,4,5) and t.emp_code=" & usr(0) & " and t.leave_id=2 union all select nvl(sum((t.leave_days )),0) as c  from hrm_leave_apply_sanction t where t.reject_reason is null and t.status_id in (0,4,5) and t.emp_code=" & usr(0) & " and t.leave_id=3"
                Dim query = "select nvl (sum(case when t.leave_form in (11, 12) then (t.leave_days) / 2 else (t.leave_days) end),0) as a from hrm_leave_apply_sanction t where t.reject_reason is null and t.status_id in (0, 4, 5) and t.emp_code = " & usr(0) & " and t.leave_id = 1 union all select nvl (sum(case when t.leave_form in (11, 12) then (t.leave_days) / 2 else (t.leave_days) end),0) as b from hrm_leave_apply_sanction t where t.reject_reason is null and t.status_id in (0, 4, 5) and t.emp_code = " & usr(0) & " and t.leave_id = 2 union all select nvl (sum(case when t.leave_form in (11, 12) then (t.leave_days) / 2 else (t.leave_days) end),0) as c from hrm_leave_apply_sanction t where t.reject_reason is null and t.status_id in (0, 4, 5) and t.emp_code = " & usr(0) & " and t.leave_id = 3"
                Dim dtleave As New DataTable
                dtleave = oh.ExecuteDataSet(query).Tables(0)


                If emp.Rows.Count = 1 Then

                    If Session("firm_id") = 8 Or Session("firm_id") = 28 Then

                        Me.txt_lcasual.Value = Math.Max(0, (emp.Rows(0)(1) - dtleave.Rows(0)(0)))
                    Else
                        Me.txt_lcasual.Value = emp.Rows(0)(1)
                    End If

                    'Me.txt_learned.Value = 0
                    'Me.txt_lsick.Value = 0
                ElseIf emp.Rows.Count > 1 Then
                    Dim dr As DataRow
                    For Each dr In emp.Rows
                        If dr(0) = 1 Then
                            If Session("firm_id") = 8 Or Session("firm_id") = 28 Then

                                Me.txt_lcasual.Value = Math.Max(0, (dr(1) - dtleave.Rows(0)(0)))
                            Else
                                Me.txt_lcasual.Value = dr(1)
                            End If
                        End If

                    Next
                Else
                    Me.txt_lcasual.Value = 0
                End If
                '-----------------------------------------------------------End

                sql = "select -1, '--select--' from dual union select 0, '---Not in the list want to Enter---' from dual union select category_id, category_name from hrm_category_master where status_id = 1"
                Dim dt3 As New DataTable
                dt3 = oh.ExecuteDataSet(sql).Tables(0)
                Me.cmb_category.DataSource = dt3
                Me.cmb_category.DataTextField = dt3.Columns(1).ColumnName
                Me.cmb_category.DataValueField = dt3.Columns(0).ColumnName
                Me.cmb_category.DataBind()
                If firmid = 28 And Me.Session("branch_id") = 3439 Then
                    sql = "select e.emp_code, e.emp_name, p.post_name, d.designation, dd.dep_name, b.branch_name, e.join_dt, case when e.emp_type = 1 then 'REGULAR' else 'OUTSOURCE' end , e.department_id from employee_master e, post_mst p, designation_master d, branch_dtl_new b, department_mst_mageeth dm, department_mst dd where e.post_id = p.post_id and d.designation_id = e.designation_id and e.branch_id = b.branch_id and e.emp_code = " & usr(0) & " and dd.dep_id = dm.dep_id and dm.emp_code = e.emp_code"
                ElseIf firmid = 28 And Me.Session("branch_id") = 3427 Then
                    sql = "select e.emp_code, e.emp_name, p.post_name, d.designation, dd.dep_name, b.branch_name, e.join_dt, case when e.emp_type = 1 then 'REGULAR' else 'OUTSOURCE' end , e.department_id from employee_master e, post_mst p, designation_master d, branch_dtl_new b, department_mst_mps dm, department_mst dd where e.post_id = p.post_id and d.designation_id = e.designation_id and e.branch_id = b.branch_id and e.emp_code = " & usr(0) & " and dd.dep_id = dm.dep_id and dm.emp_code = e.emp_code"
                Else
                    sql = "select e.emp_code,e.emp_name,p.post_name,d.designation,dm.dep_name,b.branch_name,e.join_dt,case when e.emp_type=1 then 'REGULAR' else 'OUTSOURCE' end,e.department_id from employee_master e,post_mst p,designation_master d,branch_dtl_new b,department_mst dm where e.post_id=p.post_id and e.department_id=dm.dep_id and d.designation_id=e.designation_id and e.branch_id=b.branch_id and emp_code=" & usr(0) & ""
                End If

                emp = oh.ExecuteDataSet(sql).Tables(0)
                If firmid = 28 And (emp.Rows(0)(8) = 748 Or emp.Rows(0)(8) = 738 Or emp.Rows(0)(8) = 825) Then
                    sql = "select 0, '--Select--' from dual union select t.leave_id, decode(t.leave_id, 1, 'CASUAL', 2, 'SICK', 3, 'EARNED', 4, 'LOP', 10, 'MATERNITY', 8, 'ONAM', 9, 'CHRISTMAS', 11, 'VACATION', 12, 'HALF DAY') from leave_master t where (t.leave_id = (case when to_date(sysdate) between substr((select t.parmtr_value from general_parameter t where t.module_id = 33 and t.parmtr_id = 804), 1, instr((select t.parmtr_value from general_parameter t where t.module_id = 33 and t.parmtr_id = 804), '_') - 1) and substr((select t.parmtr_value from general_parameter t where t.module_id = 33 and t.parmtr_id = 804), instr((select t.parmtr_value from general_parameter t where t.module_id = 33 and t.parmtr_id = 804), '_') + 1, length((select t.parmtr_value from general_parameter t where t.module_id = 33 and t.parmtr_id = 804))) then ('8') else ('1') end) or t.leave_id = (case when to_date(sysdate) between substr((select t.parmtr_value from general_parameter t where t.module_id = 33 and t.parmtr_id = 804), 1, instr((select t.parmtr_value from general_parameter t where t.module_id = 33 and t.parmtr_id = 804), '_') - 1) and substr((select t.parmtr_value from general_parameter t where t.module_id = 33 and t.parmtr_id = 804), instr((select t.parmtr_value from general_parameter t where t.module_id = 33 and t.parmtr_id = 804), '_') + 1, length((select t.parmtr_value from general_parameter t where t.module_id = 33 and t.parmtr_id = 804))) then ('9') else ('1') end) or t.leave_id = (case when to_date(sysdate) between substr((select t.parmtr_value from general_parameter t where t.module_id = 33 and t.parmtr_id = 804), 1, instr((select t.parmtr_value from general_parameter t where t.module_id = 33 and t.parmtr_id = 804), '_') - 1) and substr((select t.parmtr_value from general_parameter t where t.module_id = 33 and t.parmtr_id = 804), instr((select t.parmtr_value from general_parameter t where t.module_id = 33 and t.parmtr_id = 804), '_') + 1, length((select t.parmtr_value from general_parameter t where t.module_id = 33 and t.parmtr_id = 804))) then ('11') else ('1') end) or t.leave_id = 1)"
                    Dim dt31 As New DataTable
                    dt31 = oh.ExecuteDataSet(sql).Tables(0)
                    Me.cmb_ltype.DataSource = dt31
                    Me.cmb_ltype.DataTextField = dt31.Columns(1).ColumnName
                    Me.cmb_ltype.DataValueField = dt31.Columns(0).ColumnName
                    Me.cmb_ltype.DataBind()
                    If dt31.Rows.Count > 2 Then
                        Me.orow.Visible = True
                        Me.crow.Visible = True
                        Me.vrow.Visible = True
                        Me.clrow.Visible = True
                    End If

                    sql = "select leave_id,leave_days from employ_leave_master where emp_code=" & usr(0) & " and leave_id in(8,9,11) order by leave_id"
                    emp = oh.ExecuteDataSet(sql).Tables(0)
                    Dim query1 = "select nvl(sum((t.leave_days )),0) as a from hrm_leave_apply_sanction t where t.reject_reason is null and t.status_id in (0,4,5) and t.emp_code=" & usr(0) & " and t.leave_id=8 union all select nvl(sum((t.leave_days )),0) as b  from hrm_leave_apply_sanction t where t.reject_reason is null and t.status_id in (0,4,5) and t.emp_code=" & usr(0) & " and t.leave_id=9 union all select nvl(sum((t.leave_days )),0) as c  from hrm_leave_apply_sanction t where t.reject_reason is null and t.status_id in (0,4,5) and t.emp_code=" & usr(0) & " and t.leave_id=11"
                    Dim dtleave1 As New DataTable
                    dtleave1 = oh.ExecuteDataSet(query1).Tables(0)

                    If emp.Rows.Count > 1 Then
                        Dim dr As DataRow
                        For Each dr In emp.Rows
                            If dr(0) = 8 Then
                                If Session("firm_id") = 8 Or Session("firm_id") = 28 Then

                                    Me.Text1.Value = Math.Max(0, (dr(1) - dtleave1.Rows(0)(0)))
                                Else
                                    Me.Text1.Value = dr(1)
                                End If
                            End If
                            If dr(0) = 9 Then
                                If Session("firm_id") = 8 Or Session("firm_id") = 28 Then

                                    Me.Text2.Value = Math.Max(0, (dr(1) - dtleave1.Rows(1)(0)))

                                Else
                                    Me.Text2.Value = dr(1)
                                End If
                            End If
                            If dr(0) = 11 Then
                                If Session("firm_id") = 8 Or Session("firm_id") = 28 Then

                                    Me.Text3.Value = Math.Max(0, (dr(1) - dtleave1.Rows(2)(0)))
                                Else
                                    Me.Text3.Value = dr(1)
                                End If
                            End If
                        Next
                    Else
                        Me.Text1.Value = 0
                        Me.Text2.Value = 0
                        Me.Text3.Value = 0
                    End If
                End If
            Else
                Me.Server.Transfer("../show_err.aspx")
            End If
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim dt, dt1, dt2 As New DataTable
        Dim oh As New Helper.Oracle.OracleHelper
        Dim to_les, cnt, dt_dif As New Integer
        to_les = 0
        Dim dat, dto As New Date
        Dim dat1, cnt1 As String
        Dim cal_data = eventArgument
        Dim dis() As String = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim st1 As String
        Try
            If dis(0) = 8 Then
                dat = dis(1)
                dto = dis(2)
                cnt = DateDiff(DateInterval.Day, dat, dto)
                If cnt < 0 Then
                    st.Append(0 & "^^" & cnt)
                    res = st.ToString
                    Return
                End If
                If dis(3) = 6 Then
                    If cnt < 8 Then
                        st.Append(-1 & "^^" & cnt)
                        res = st.ToString
                        Return
                    End If
                End If

                cnt = cnt + 1
                If (dis(4) = "1" And cnt = 1) Or (dis(4) = "2" And cnt = 1) Then
                    cnt1 = "0.5"
                    st.Append(1 & "^^" & cnt1)
                ElseIf (dis(4) = "1" And cnt > 1) Or (dis(4) = "2" And cnt > 1) Then
                    st.Append("NO" & "^^" & cnt)
                Else
                    st.Append(1 & "^^" & cnt)
                End If
                res = st.ToString
            ElseIf dis(0) = 9 Then
                sql = "select 0,'--select--' from dual union select reason_id,reason_name from hrm_category_dtl where category_id=" & dis(1) & ""
                dt = oh.ExecuteDataSet(sql).Tables(0)
                If dt.Rows.Count > 0 Then
                    Dim dr As DataRow
                    st.Append(2 & "^^")
                    For Each dr In dt.Rows
                        st.Append(dr(0) & "%%" & dr(1))
                        st.Append("**")
                    Next
                End If
                res = st.ToString
            Else
                st1 = "Error"
                st.Append(st1)
                res = st.ToString
            End If
        Catch ex As Exception
            st.Append(ex.Message)
            res = st.ToString
        End Try
    End Sub
    Public Shared Function GetUniqueFilename(ByVal FileName As String) As String
        Dim count As Integer = 0
        Dim Name As String = ""

        If System.IO.File.Exists(FileName) Then
            Dim f As New System.IO.FileInfo(FileName)
            If Not String.IsNullOrEmpty(f.Extension) Then
                Name = f.FullName.Substring(0, f.FullName.LastIndexOf("."))
            Else
                Name = f.FullName
            End If
            While System.IO.File.Exists(FileName)
                count += 1
                FileName = Name + count.ToString() + f.Extension
            End While
        End If
        Return FileName
    End Function
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Button1.Enabled = False
        Dim dt As DataTable = oh.ExecuteDataSet("select sysdate from dual").Tables(0)
        Dim appdte As Date = dt.Rows(0)(0)
        Dim leavetodt As Date = CDate(Me.txt_ltodt.Text)
        If Hidden1.Value = "0" Or Hidden1.Value = "" Then
            Me.Button1.Enabled = True
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('Please Select Any Leave Duarion Category') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub
        End If
        If Me.cmb_ltype.SelectedValue = 2 And Me.txt_ldays.Value > 5 And Me.Chk_no.Checked = True And CDate(Me.txt_lappdt.Value) > CDate(Me.txt_ltodt.Text) Then
            Me.Button1.Enabled = True
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('Please submit fitness certificate!!') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub
        End If
        If Me.cmb_ltype.SelectedValue = 2 And Me.txt_ldays.Value > 3 And Me.Chk_no.Checked = True And CDate(Me.txt_lappdt.Value) > CDate(Me.txt_ltodt.Text) Then
            Me.Button1.Enabled = True
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('Please submit Medical certificate!!') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub
        End If
        If Me.cmb_ltype.SelectedValue = 3 And Me.txt_ldays.Value > 3 And CDate(Me.txt_lappdt.Value).AddDays(7) > CDate(Me.txt_lfdt.Text) Then
            Me.Button1.Enabled = True
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('Sorry,Earn leave for more than 3 days should apply before 7 days of entering into leave!!') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub
        End If
        Dim str() As String
        str = Me.hid_val.Value.Split("#")
        If (Me.chk_1st.Checked = False And Me.chk_2.Checked = False And Me.Chk_3.Checked = False And Me.Chk_4.Checked = False And Me.Chk_5.Checked = False And Me.Chk_yes.Checked = True) Then
            Me.Button1.Enabled = True
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('Select Supporting Attachments!!                         ')              ;")
            ' cl_script.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub
        End If


        If Me.file_support1.HasFile Then
            Dim fileExtension As String
            fileExtension = System.IO.Path. _
                GetExtension(Me.file_support1.FileName).ToLower()
            Dim allowedExtensions As String() = _
                {".jpg", ".jpeg", ".png", ".bmp"}
            Dim fileok As Boolean
            fileok = False
            For i As Integer = 0 To allowedExtensions.Length - 1
                If fileExtension = allowedExtensions(i) Then
                    fileok = True
                End If
            Next
            If Not (fileok) Then
                Me.Button1.Enabled = True
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('First Attachement Type Not Supported!!') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            End If

        End If
        If Me.file_support2.HasFile Then
            Dim fileExtension As String
            fileExtension = System.IO.Path. _
                GetExtension(Me.file_support2.FileName).ToLower()
            Dim allowedExtensions As String() = _
                {".jpg", ".jpeg", ".png", ".bmp"}
            Dim fileok As Boolean
            fileok = False
            For i As Integer = 0 To allowedExtensions.Length - 1
                If fileExtension = allowedExtensions(i) Then
                    fileok = True
                End If
            Next
            If Not (fileok) Then
                Me.Button1.Enabled = True
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('Second Attachement Type Not Supported!!') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub

            End If

        End If

        If Me.file_support3.HasFile Then
            Dim fileExtension As String
            fileExtension = System.IO.Path. _
                GetExtension(Me.file_support3.FileName).ToLower()
            Dim allowedExtensions As String() = _
                {".jpg", ".jpeg", ".png", ".bmp"}
            Dim fileok As Boolean
            fileok = False
            For i As Integer = 0 To allowedExtensions.Length - 1
                If fileExtension = allowedExtensions(i) Then
                    fileok = True
                End If
            Next
            If Not (fileok) Then
                Me.Button1.Enabled = True
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('Third Attachement Type Not Supported!!') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            End If

        End If

        If Me.file_support4.HasFile Then
            Dim fileExtension As String
            fileExtension = System.IO.Path. _
                GetExtension(Me.file_support4.FileName).ToLower()
            Dim allowedExtensions As String() = _
                {".jpg", ".jpeg", ".png", ".bmp"}
            Dim fileok As Boolean
            fileok = False
            For i As Integer = 0 To allowedExtensions.Length - 1
                If fileExtension = allowedExtensions(i) Then
                    fileok = True
                End If
            Next
            If Not (fileok) Then
                Me.Button1.Enabled = True
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('Fourth Attachement Type Not Supported!!') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            End If

        End If

        If Me.file_support5.HasFile Then
            Dim fileExtension As String
            fileExtension = System.IO.Path. _
                GetExtension(Me.file_support5.FileName).ToLower()
            Dim allowedExtensions As String() = _
                {".jpg", ".jpeg", ".png", ".bmp"}
            Dim fileok As Boolean
            fileok = False
            For i As Integer = 0 To allowedExtensions.Length - 1
                If fileExtension = allowedExtensions(i) Then
                    fileok = True
                End If
            Next
            If Not (fileok) Then
                Me.Button1.Enabled = True
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('Fifth Attachement Type Not Supported!!') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            End If

        End If


        If Me.file_support1.FileName <> "" And Me.Chk_yes.Checked = True And Me.chk_1st.Checked = True Then
            Dim leave(13) As OracleParameter
            leave(0) = New OracleParameter("emp_id", OracleType.Int32)
            leave(0).Direction = ParameterDirection.Input
            leave(0).Value = str(0)
            leave(1) = New OracleParameter("leav_id", OracleType.Int32)
            leave(1).Direction = ParameterDirection.Input
            leave(1).Value = str(1)
            leave(2) = New OracleParameter("leav_no", OracleType.Number)
            leave(2).Direction = ParameterDirection.Input
            leave(2).Value = str(2)
            leave(3) = New OracleParameter("leav_frdate", OracleType.DateTime)
            leave(3).Direction = ParameterDirection.Input
            leave(3).Value = str(3)
            leave(4) = New OracleParameter("leav_todate", OracleType.DateTime)
            leave(4).Direction = ParameterDirection.Input
            leave(4).Value = str(4)
            leave(5) = New OracleParameter("leav_applydate", OracleType.DateTime)
            leave(5).Direction = ParameterDirection.Input
            leave(5).Value = str(5)
            leave(6) = New OracleParameter("cat_id", OracleType.Int32)
            leave(6).Direction = ParameterDirection.Input
            leave(6).Value = str(6)
            leave(7) = New OracleParameter("app_sub", OracleType.Int32)
            leave(7).Direction = ParameterDirection.Input
            Dim LF As Integer = 0
            If CheckBox1.Checked Then
                LF = 11
            ElseIf CheckBox2.Checked Then
                LF = 12
            ElseIf CheckBox3.Checked Then
                LF = 13
            End If
            leave(7).Value = LF
            leave(8) = New OracleParameter("res_id", OracleType.Int32)
            leave(8).Direction = ParameterDirection.Input
            If str(6) = 0 Then

                leave(8).Value = 0
            Else
                leave(8).Value = str(8)

            End If



            leave(12) = New OracleParameter("new_reason", OracleType.VarChar)
            leave(12).Direction = ParameterDirection.Input
            leave(12).Value = Me.txt_oth_reason.Value



            leave(13) = New OracleParameter("leave_rsn", OracleType.VarChar)
            leave(13).Direction = ParameterDirection.Input
            leave(13).Value = Me.txt_oth_reason.Value



            leave(9) = New OracleParameter("msg", OracleType.VarChar, 500)
            leave(9).Direction = ParameterDirection.Output
            leave(10) = New OracleParameter("flag", OracleType.Number)
            leave(10).Direction = ParameterDirection.Output
            leave(11) = New OracleParameter("lvsq", OracleType.Number)
            leave(11).Direction = ParameterDirection.Output


            oh.ExecuteNonQuery("hrm_leave_appli_school", leave)
            Me.Button1.Enabled = True
            Dim DirPath As String
            DirPath = Me.Server.MapPath("../image")
            If Not IsDBNull(leave(11).Value) Then

                If (leave(11).Value <> 0) Then
                    Dim cp As String = Me.Server.MapPath(Me.Request.ApplicationPath)

                    Try
                        If Me.file_support1.FileName <> "" Then


                            fnm = GetUniqueFilename(DirPath + "/support1.jpg")
                            If Me.file_support1.HasFile Then
                                Me.file_support1.SaveAs(fnm)
                            End If
                            Dim fs As New IO.FileStream(fnm, IO.FileMode.Open, IO.FileAccess.Read)
                            Dim bl(fs.Length) As Byte
                            fs.Read(bl, 0, fs.Length)
                            fs.Close()
                            Dim fp As New IO.FileInfo(fnm)
                            If fp.Exists Then
                                fp.Delete()
                            End If

                            Dim inte As Integer = 1
                            sql = "insert into macdms.Hrm_app_leave_support(leav_seq,support,emp_code,id) values(:appid,:ph,:tit,:op)"
                            Dim parm_coll(3) As OracleParameter
                            parm_coll(0) = New OracleParameter
                            parm_coll(0).ParameterName = "ph"
                            parm_coll(0).OracleType = OracleType.Blob
                            parm_coll(0).Direction = ParameterDirection.Input
                            parm_coll(0).Value = bl
                            parm_coll(1) = New OracleParameter
                            parm_coll(1).ParameterName = "tit"
                            parm_coll(1).OracleType = OracleType.VarChar
                            parm_coll(1).Direction = ParameterDirection.Input
                            parm_coll(1).Value = Me.txt_ecode.Value.ToString()
                            parm_coll(2) = New OracleParameter
                            parm_coll(2).ParameterName = "appid"
                            parm_coll(2).OracleType = OracleType.Number
                            parm_coll(2).Direction = ParameterDirection.Input
                            parm_coll(2).Value = leave(11).Value
                            parm_coll(3) = New OracleParameter
                            parm_coll(3).ParameterName = "op"
                            parm_coll(3).OracleType = OracleType.Number
                            parm_coll(3).Direction = ParameterDirection.Input
                            parm_coll(3).Value = inte
                            oh.ExecuteNonQuery(sql, parm_coll)
                        End If

                        If Me.file_support2.FileName <> "" Then


                            fnm = GetUniqueFilename(DirPath + "/support2.jpg")
                            If Me.file_support2.HasFile Then
                                Me.file_support2.SaveAs(fnm)
                            End If
                            Dim fs As New IO.FileStream(fnm, IO.FileMode.Open, IO.FileAccess.Read)
                            Dim bl(fs.Length) As Byte
                            fs.Read(bl, 0, fs.Length)
                            fs.Close()
                            Dim fp As New IO.FileInfo(fnm)
                            If fp.Exists Then
                                fp.Delete()
                            End If

                            Dim inte As Integer = 2
                            sql = "insert into macdms.Hrm_app_leave_support(leav_seq,support,emp_code,id) values(:appid,:ph,:tit,:op)"
                            Dim parm_coll(3) As OracleParameter
                            parm_coll(0) = New OracleParameter
                            parm_coll(0).ParameterName = "ph"
                            parm_coll(0).OracleType = OracleType.Blob
                            parm_coll(0).Direction = ParameterDirection.Input
                            parm_coll(0).Value = bl
                            parm_coll(1) = New OracleParameter
                            parm_coll(1).ParameterName = "tit"
                            parm_coll(1).OracleType = OracleType.VarChar
                            parm_coll(1).Direction = ParameterDirection.Input
                            parm_coll(1).Value = Me.txt_ecode.Value.ToString()
                            parm_coll(2) = New OracleParameter
                            parm_coll(2).ParameterName = "appid"
                            parm_coll(2).OracleType = OracleType.Number
                            parm_coll(2).Direction = ParameterDirection.Input
                            parm_coll(2).Value = leave(11).Value
                            parm_coll(3) = New OracleParameter
                            parm_coll(3).ParameterName = "op"
                            parm_coll(3).OracleType = OracleType.Number
                            parm_coll(3).Direction = ParameterDirection.Input
                            parm_coll(3).Value = inte
                            oh.ExecuteNonQuery(sql, parm_coll)
                            Me.Button1.Enabled = True
                        End If
                        If Me.file_support3.FileName <> "" Then

                            fnm = GetUniqueFilename(DirPath + "/support3.jpg")
                            If Me.file_support3.HasFile Then
                                Me.file_support3.SaveAs(fnm)
                            End If
                            Dim fs As New IO.FileStream(fnm, IO.FileMode.Open, IO.FileAccess.Read)
                            Dim bl(fs.Length) As Byte
                            fs.Read(bl, 0, fs.Length)
                            fs.Close()
                            Dim fp As New IO.FileInfo(fnm)
                            If fp.Exists Then
                                fp.Delete()
                            End If

                            Dim inte As Integer = 3
                            sql = "insert into macdms.Hrm_app_leave_support(leav_seq,support,emp_code,id) values(:appid,:ph,:tit,:op)"
                            Dim parm_coll(3) As OracleParameter
                            parm_coll(0) = New OracleParameter
                            parm_coll(0).ParameterName = "ph"
                            parm_coll(0).OracleType = OracleType.Blob
                            parm_coll(0).Direction = ParameterDirection.Input
                            parm_coll(0).Value = bl
                            parm_coll(1) = New OracleParameter
                            parm_coll(1).ParameterName = "tit"
                            parm_coll(1).OracleType = OracleType.VarChar
                            parm_coll(1).Direction = ParameterDirection.Input
                            parm_coll(1).Value = Me.txt_ecode.Value.ToString()
                            parm_coll(2) = New OracleParameter
                            parm_coll(2).ParameterName = "appid"
                            parm_coll(2).OracleType = OracleType.Number
                            parm_coll(2).Direction = ParameterDirection.Input
                            parm_coll(2).Value = leave(11).Value
                            parm_coll(3) = New OracleParameter
                            parm_coll(3).ParameterName = "op"
                            parm_coll(3).OracleType = OracleType.Number
                            parm_coll(3).Direction = ParameterDirection.Input
                            parm_coll(3).Value = inte
                            oh.ExecuteNonQuery(sql, parm_coll)
                        End If
                        Me.Button1.Enabled = True
                        If Me.file_support4.FileName <> "" Then


                            fnm = GetUniqueFilename(DirPath + "/support4.jpg")
                            If Me.file_support4.HasFile Then
                                Me.file_support4.SaveAs(fnm)
                            End If
                            Dim fs As New IO.FileStream(fnm, IO.FileMode.Open, IO.FileAccess.Read)
                            Dim bl(fs.Length) As Byte
                            fs.Read(bl, 0, fs.Length)
                            fs.Close()
                            Dim fp As New IO.FileInfo(fnm)
                            If fp.Exists Then
                                fp.Delete()
                            End If
                            Dim inte As Integer = 4

                            sql = "insert into macdms.Hrm_app_leave_support(leav_seq,support,emp_code,id) values(:appid,:ph,:tit,:op)"
                            Dim parm_coll(3) As OracleParameter
                            parm_coll(0) = New OracleParameter
                            parm_coll(0).ParameterName = "ph"
                            parm_coll(0).OracleType = OracleType.Blob
                            parm_coll(0).Direction = ParameterDirection.Input
                            parm_coll(0).Value = bl
                            parm_coll(1) = New OracleParameter
                            parm_coll(1).ParameterName = "tit"
                            parm_coll(1).OracleType = OracleType.VarChar
                            parm_coll(1).Direction = ParameterDirection.Input
                            parm_coll(1).Value = Me.txt_ecode.Value.ToString()
                            parm_coll(2) = New OracleParameter
                            parm_coll(2).ParameterName = "appid"
                            parm_coll(2).OracleType = OracleType.Number
                            parm_coll(2).Direction = ParameterDirection.Input
                            parm_coll(2).Value = leave(11).Value
                            parm_coll(3) = New OracleParameter
                            parm_coll(3).ParameterName = "op"
                            parm_coll(3).OracleType = OracleType.Number
                            parm_coll(3).Direction = ParameterDirection.Input
                            parm_coll(3).Value = inte
                            oh.ExecuteNonQuery(sql, parm_coll)
                        End If
                        If Me.file_support5.FileName <> "" Then


                            fnm = GetUniqueFilename(DirPath + "/support5.jpg")
                            If Me.file_support5.HasFile Then
                                Me.file_support5.SaveAs(fnm)
                            End If
                            Dim fs As New IO.FileStream(fnm, IO.FileMode.Open, IO.FileAccess.Read)
                            Dim bl(fs.Length) As Byte
                            fs.Read(bl, 0, fs.Length)
                            fs.Close()
                            Dim fp As New IO.FileInfo(fnm)
                            If fp.Exists Then
                                fp.Delete()
                            End If

                            Dim inte As Integer = 5
                            sql = "insert into macdms.Hrm_app_leave_support(leav_seq,support,emp_code,id) values(:appid,:ph,:tit,:op)"
                            Dim parm_coll(3) As OracleParameter
                            parm_coll(0) = New OracleParameter
                            parm_coll(0).ParameterName = "ph"
                            parm_coll(0).OracleType = OracleType.Blob
                            parm_coll(0).Direction = ParameterDirection.Input
                            parm_coll(0).Value = bl
                            parm_coll(1) = New OracleParameter
                            parm_coll(1).ParameterName = "tit"
                            parm_coll(1).OracleType = OracleType.VarChar
                            parm_coll(1).Direction = ParameterDirection.Input
                            parm_coll(1).Value = Me.txt_ecode.Value.ToString()
                            parm_coll(2) = New OracleParameter
                            parm_coll(2).ParameterName = "appid"
                            parm_coll(2).OracleType = OracleType.Number
                            parm_coll(2).Direction = ParameterDirection.Input
                            parm_coll(2).Value = leave(11).Value
                            parm_coll(3) = New OracleParameter
                            parm_coll(3).ParameterName = "op"
                            parm_coll(3).OracleType = OracleType.Number
                            parm_coll(3).Direction = ParameterDirection.Input
                            parm_coll(3).Value = inte
                            oh.ExecuteNonQuery(sql, parm_coll)
                        End If


                    Catch ex As Exception
                        Response.Write(ex.Message.ToString)
                    End Try

                End If

            End If
            Me.hid_val.Value = ""
            Me.Button1.Enabled = True
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('" & leave(9).Value & "!!') ;")
            cl_script.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)

        ElseIf Me.Chk_yes.Checked = False Then
            Dim leave(13) As OracleParameter
            leave(0) = New OracleParameter("emp_id", OracleType.Int32)
            leave(0).Direction = ParameterDirection.Input
            leave(0).Value = str(0)
            leave(1) = New OracleParameter("leav_id", OracleType.Int32)
            leave(1).Direction = ParameterDirection.Input
            leave(1).Value = str(1)
            leave(2) = New OracleParameter("leav_no", OracleType.Number)
            leave(2).Direction = ParameterDirection.Input
            leave(2).Value = str(2)
            leave(3) = New OracleParameter("leav_frdate", OracleType.DateTime)
            leave(3).Direction = ParameterDirection.Input
            leave(3).Value = str(3)
            leave(4) = New OracleParameter("leav_todate", OracleType.DateTime)
            leave(4).Direction = ParameterDirection.Input
            leave(4).Value = str(4)
            leave(5) = New OracleParameter("leav_applydate", OracleType.DateTime)
            leave(5).Direction = ParameterDirection.Input
            leave(5).Value = str(5)
            leave(6) = New OracleParameter("cat_id", OracleType.Int32)
            leave(6).Direction = ParameterDirection.Input
            leave(6).Value = str(6)
            leave(7) = New OracleParameter("app_sub", OracleType.Int32)
            leave(7).Direction = ParameterDirection.Input

            Dim LF As Integer = 0
            If CheckBox1.Checked Then
                LF = 11
            ElseIf CheckBox2.Checked Then
                LF = 12
            ElseIf CheckBox3.Checked Then
                LF = 13
            End If
            leave(7).Value = LF

            leave(8) = New OracleParameter("res_id", OracleType.Int32)
            leave(8).Direction = ParameterDirection.Input
            If str(8) = "" Then
                str(8) = 0

            End If
            leave(8).Value = str(8)
            leave(12) = New OracleParameter("new_reason", OracleType.VarChar)
            leave(12).Direction = ParameterDirection.Input
            leave(12).Value = Me.txt_oth_reason.Value
            'leave(12).Value = Me.cmb_reason.SelectedValue

            leave(13) = New OracleParameter("leave_rsn", OracleType.VarChar)
            leave(13).Direction = ParameterDirection.Input
            leave(13).Value = Me.txt_oth_reason.Value




            'If (cmb_category.SelectedIndex) = -1 Then

            '    leave(12) = New OracleParameter("new_reason", OracleType.VarChar, 100)
            '    leave(12).Direction = ParameterDirection.Input
            '    leave(12).Value = Me.cmb_reason.SelectedValue

            'ElseIf (cmb_category.SelectedIndex) = 0 Then

            '    leave(13) = New OracleParameter("leave_rsn", OracleType.VarChar, 100)
            '    leave(13).Direction = ParameterDirection.Input
            '    leave(13).Value = Me.txt_oth_reason.Value
            'End If

            leave(9) = New OracleParameter("msg", OracleType.VarChar, 500)
            leave(9).Direction = ParameterDirection.Output
            leave(10) = New OracleParameter("flag", OracleType.Number)
            leave(10).Direction = ParameterDirection.Output
            leave(11) = New OracleParameter("lvsq", OracleType.Number)
            leave(11).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_leave_appli_school", leave)
            Me.Button1.Enabled = True
            Dim cl_script1 As New StringBuilder
            cl_script1.Append("   alert('" & leave(9).Value & "')                                                          ;")
            cl_script1.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)


        Else
            Me.Button1.Enabled = True
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('First Select Supporting Attachments!!                                                                 ')                                                  ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub
        End If
    End Sub


End Class
