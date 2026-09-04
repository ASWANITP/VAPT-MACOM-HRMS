Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Imports System.Web.Script.Services
Imports System.Web.Services
Partial Class leave_appli_to_4a487d033298
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim sql, fnm As String
    Dim _encryptDecrypt As New EncryptionService

    Dim oh As New Helper.Oracle.OracleHelper
    Dim res As String
    Dim usr() As String

    Dim firmid As Integer
    Dim branchid As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '------VAPT - improper parameter validation---------------------------------------
        Dim paramCount As Integer = Request.QueryString.Count
        If Request.QueryString.Count > 0 Then
            Response.StatusCode = 400
            Response.StatusDescription = "Bad Request"
            Response.End()
        End If

        '--------VAPT - Prevent Caching of Sensitive Content--------
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")

        '--------VAPT - Validate Session--------
        If Session("user_id") Is Nothing OrElse Session("firm_id") Is Nothing OrElse Session("branch_id") Is Nothing Then
            RedirectToLogin()
            Return
        End If

        Try
            Dim script_val As String
            script_val = "var loanno;" & "loanno='" & "" & Me.txt_ldays.ClientID & "'" & " ; "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "sub_call_receiver", "context")
            Dim cbscript As String = "function sub_call_server(arg,context) { " & cbref & "; } "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "sub_call_server", cbscript, True)


            firmid = Convert.ToInt32(Me.Session("firm_id"))
            branchid = Me.Session("branch_id")

            Dim User() As String = Session("user_id").ToString.Split("!")
            Dim UserId As Integer = User(0)
            '---------70009846
            Dim dept As DataTable = oh.ExecuteDataSet("select count(*)from employee_master t where t.DEPARTMENT_ID in(748,825) and t.emp_code=" & User(0) & " ").Tables(0)
            If dept.Rows(0)(0) = 1 Then
                Response.Redirect("leave_appli_to_mageeth.aspx")
            End If
            '-----------


            Try
                If firmid = 24 Then
                    sql = "select nvl(t.branch_id,'NULL') branch ,t.block_all from hrm_block_leave_frm t where t.firm_id=24 and t.block_opt='APPLY'"
                    Dim dtCheck As New DataTable
                    Dim branch As String
                    dtCheck = oh.ExecuteDataSet(sql).Tables(0)
                    branch = dtCheck.Rows(0)(0)
                    Dim flag As Boolean = False
                    If dtCheck.Rows.Count > 0 Then
                        If dtCheck.Rows(0)(1) = "Y" Then
                            flag = True
                        End If
                        If branch <> "NULL" Then
                            Dim ar() = branch.Split(",")
                            Dim index As Integer
                            For index = 0 To ar.Length - 1
                                If Val(ar(index)) = branchid Then
                                    flag = True
                                    Exit For
                                End If
                            Next
                        End If

                        If flag = True Then
                            Dim cl_script As New StringBuilder
                            cl_script.Append("   alert('Leave Entry BLOCKED from HO') ;")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "BLOCKLEAVE", cl_script.ToString, True)
                            Return
                        End If
                    End If
                End If

            Catch ex As System.Exception
            End Try



            'Dim sc As String = "var cont_name;cont_name='" & Me.txt_lcasual.ClientID & "';"
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var2", sc, True)
            Dim emp As New DataTable
            usr = Me.Session("user_id").ToString.Split("!")
            '---sh
            If firmid = 24 Then
                sql = "select e.emp_code,e.emp_name,p.post_name,d.designation,dm.dep_name,b.branch_name,e.join_dt,case when e.emp_type=1 then 'REGULAR' else 'OUTSOURCE' end from employee_master e,post_mst_jwell p,designation_master d,branch_dtl_new b,department_mst dm where e.post_id=p.post_id and e.department_id=dm.dep_id and d.designation_id=e.designation_id and e.branch_id=b.branch_id and emp_code=" & usr(0) & ""
            Else
                sql = "select e.emp_code,e.emp_name,p.post_name,d.designation,dm.dep_name,b.branch_name,e.join_dt,case when e.emp_type=1 then 'REGULAR' else 'OUTSOURCE' end from employee_master e,post_mst p,designation_master d,branch_dtl_new b,department_mst dm where e.post_id=p.post_id and e.department_id=dm.dep_id and d.designation_id=e.designation_id and e.branch_id=b.branch_id and emp_code=" & usr(0) & ""
            End If
            '---sh

            emp = oh.ExecuteDataSet(sql).Tables(0)
            If emp.Rows.Count > 0 Then
                Me.hdnEcode.Value = _encryptDecrypt.Encrypt(usr(0))
                Me.hdnEname.Value = _encryptDecrypt.Encrypt(emp.Rows(0)(1))
                Me.txt_epost.Value = emp.Rows(0)(2)
                Me.txt_edesig.Value = emp.Rows(0)(3)
                Me.txt_edep.Value = emp.Rows(0)(4)
                Me.txt_ebr.Value = emp.Rows(0)(5)
                Me.txt_ejoindt.Value = Format(emp.Rows(0)(6), "dd/MMM/yyyy")
                Me.txt_etype.Value = emp.Rows(0)(7)
                Me.txt_lappdt.Value = Format(Date.Now, "dd/MMM/yyyy")
                sql = "select leave_id,leave_days from employ_leave_master where emp_code=" & usr(0) & ""
                emp = oh.ExecuteDataSet(sql).Tables(0)

                'COMMENDED....Modified code added below---Request no:12083...12-Oct-2016
                'If emp.Rows.Count = 1 Then
                '    Me.txt_lcasual.Value = emp.Rows(0)(1)
                '    Me.txt_learned.Value = 0
                '    Me.txt_lsick.Value = 0
                'ElseIf emp.Rows.Count > 1 Then
                '    Dim dr As DataRow
                '    For Each dr In emp.Rows
                '        If dr(0) = 1 Then
                '            Me.txt_lcasual.Value = dr(1)
                '        End If
                '        If dr(0) = 2 Then
                '            Me.txt_lsick.Value = dr(1)
                '        End If
                '        If dr(0) = 3 Then

                '            Me.txt_learned.Value = dr(1)
                '        End If
                '    Next
                'Else
                '    Me.txt_lcasual.Value = 0
                '    Me.txt_learned.Value = 0
                '    Me.txt_lsick.Value = 0
                'End If
                '===========================================================

                'Newly added code.........
                Dim query = "select nvl(sum((t.leave_days )),0) as a from hrm_leave_apply_sanction t where t.reject_reason is null and t.status_id in (0,4,5) and t.emp_code=" & usr(0) & " and t.leave_id=1 union all select nvl(sum((t.leave_days )),0) as b  from hrm_leave_apply_sanction t where t.reject_reason is null and t.status_id in (0,4,5) and t.emp_code=" & usr(0) & " and t.leave_id=2 union all select nvl(sum((t.leave_days )),0) as c  from hrm_leave_apply_sanction t where t.reject_reason is null and t.status_id in (0,4,5) and t.emp_code=" & usr(0) & " and t.leave_id=3"
                Dim dtleave As New DataTable
                dtleave = oh.ExecuteDataSet(query).Tables(0)


                If emp.Rows.Count = 1 Then

                    If Session("firm_id") = 8 Or Session("firm_id") = 28 Then

                        Me.txt_lcasual.Value = Math.Max(0, (emp.Rows(0)(1) - dtleave.Rows(0)(0)))
                        hdnCasual.Value = txt_lcasual.Value

                    Else
                        Me.txt_lcasual.Value = emp.Rows(0)(1)
                        hdnCasual.Value = txt_lcasual.Value
                    End If

                    Me.txt_learned.Value = 0
                    hdnSick.Value = 0
                    hdnEarned.Value = 0
                    Me.txt_lsick.Value = 0
                ElseIf emp.Rows.Count > 1 Then
                    Dim dr As DataRow
                    For Each dr In emp.Rows
                        If dr(0) = 1 Then
                            If Session("firm_id") = 8 Or Session("firm_id") = 28 Then

                                Me.txt_lcasual.Value = Math.Max(0, (dr(1) - dtleave.Rows(0)(0)))
                                hdnCasual.Value = txt_lcasual.Value
                            Else
                                Me.txt_lcasual.Value = dr(1)
                                hdnCasual.Value = txt_lcasual.Value
                            End If
                        End If
                        If dr(0) = 2 Then
                            If Session("firm_id") = 8 Or Session("firm_id") = 28 Then

                                Me.txt_lsick.Value = Math.Max(0, (dr(1) - dtleave.Rows(1)(0)))
                                hdnSick.Value = txt_lsick.Value
                            Else
                                Me.txt_lsick.Value = dr(1)
                                hdnSick.Value = txt_lsick.Value

                            End If
                        End If
                        If dr(0) = 3 Then
                            If Session("firm_id") = 8 Or Session("firm_id") = 28 Then

                                Me.txt_learned.Value = Math.Max(0, (dr(1) - dtleave.Rows(2)(0)))
                                hdnEarned.Value = txt_learned.Value

                            Else
                                Me.txt_learned.Value = dr(1)
                                hdnEarned.Value = txt_learned.Value
                            End If
                        End If
                    Next
                Else
                    Me.txt_lcasual.Value = 0
                    Me.txt_learned.Value = 0
                    Me.txt_lsick.Value = 0

                    hdnCasual.Value = 0
                    hdnEarned.Value = 0
                    hdnSick.Value = 0
                End If
                '-----------------------------------------------------------End

                sql = "select 0,'--select--' from dual union select category_id,category_name from hrm_category_master where status_id=1"
                Dim dt3 As New DataTable
                dt3 = oh.ExecuteDataSet(sql).Tables(0)
                Me.cmb_category.DataSource = dt3
                Me.cmb_category.DataTextField = dt3.Columns(1).ColumnName
                Me.cmb_category.DataValueField = dt3.Columns(0).ColumnName
                Me.cmb_category.DataBind()
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
        Try
            '--------VAPT - Validate Callback Parameters--------
            If String.IsNullOrEmpty(eventArgument) OrElse eventArgument.Length > 500 Then
                res = "Error: Invalid input"
                Return
            End If

            If ContainsMaliciousContent(eventArgument) Then
                res = "Error: Invalid input"
                Return
            End If

            Dim dt, dt1, dt2 As New DataTable
            Dim oh As New Helper.Oracle.OracleHelper
            Dim to_les, cnt, dt_dif As New Integer
            to_les = 0
            Dim dat, dto As New Date
            Dim dat1 As String
            Dim cal_data = eventArgument
            Dim dis() As String = cal_data.ToString.Split("$")

            '--------VAPT - Validate Split Parameters--------
            If dis.Length < 2 Then
                res = "Error: Invalid parameters"
                Return
            End If
            Dim st As New StringBuilder
            Dim st1 As String
            Try
                If dis(0) = "8" Then
                    '--------VAPT - Validate Date Parameters--------
                    If dis.Length < 4 OrElse Not ValidateDateParameter(dis(1)) OrElse Not ValidateDateParameter(dis(2)) Then
                        res = "Error: Invalid date parameters"
                        Return
                    End If

                    dat = DateTime.Parse(dis(1))
                    dto = DateTime.Parse(dis(2))
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
                    'If dis(3) = 1 Then
                    '    dt_dif = DateDiff(DateInterval.Day, dto, dat)

                    '    sql = "select count(*) from branch_holiday bh,employee_master e where e.emp_code=" & usr(0) & " and e.branch_id=bh.branch_id"
                    '    dt = oh.ExecuteDataSet(sql).Tables(0)
                    '    If dt.Rows(0)(0) <> 0 Then
                    '        sql = "select id from branch_holiday bh,employee_master e where e.emp_code=" & usr(0) & " and e.branch_id=bh.branch_id"
                    '        dt = oh.ExecuteDataSet(sql).Tables(0)
                    '        dat1 = Format(dat, "dd/MMM/yyyy")
                    '        While (dat <= dto)
                    '            dat1 = Format(dat, "dd/MMM/yyyy")
                    '            sql = "select count(*) from branch_holiday bh,employee_master e where e.emp_code=" & usr(0) & " and e.branch_id=bh.branch_id and to_char(to_date('" & dat1 & "'),'D')=" & dt.Rows(0)(0) & " and '" & dat1 & "' not in (select working_date from hrm_branch_holiday_work where branch_id=bh.branch_id and working_date between '" & dis(1) & "' and '" & dis(2) & "' and hol_status=1)"
                    '            dt2 = oh.ExecuteDataSet(sql).Tables(0)
                    '            sql = "select count(*) from common_holiday bh,employee_master e,branch_master b where e.emp_code=" & usr(0) & " and e.branch_id=b.branch_id and bh.state_id=b.state_id and bh.branch_id=b.branch_id and to_date(bh.hol_day)=to_char('" & dat1 & "')  and '" & dat1 & "' not in (select working_date from hrm_branch_holiday_work where branch_id=bh.branch_id and working_date between '" & dis(1) & "' and '" & dis(2) & "' and hol_status=2)"
                    '            dt1 = oh.ExecuteDataSet(sql).Tables(0)
                    '            If dt2.Rows(0)(0) <> 0 Then
                    '                to_les = to_les + dt2.Rows(0)(0)
                    '            End If
                    '            If dt1.Rows(0)(0) <> 0 Then
                    '                to_les = to_les + dt1.Rows(0)(0)
                    '            End If
                    '            dat = dat.AddDays(1)
                    '        End While
                    '        cnt = cnt + 1 - to_les
                    '    End If
                    'Else
                    cnt = cnt + 1
                    ' End If
                    st.Append(1 & "^^" & cnt)
                    res = st.ToString
                ElseIf dis(0) = "9" Then
                    '--------VAPT - Validate Category Parameter--------
                    If dis.Length < 2 OrElse Not ValidateNumericParameter(dis(1)) Then
                        res = "Error: Invalid category parameter"
                        Return
                    End If
                    'sql = "select 0,'--select--' from dual union select reason_id,reason_name from hrm_category_dtl where category_id=" & dis(1) & ""
                    sql = "select 0,' --select--' from dual union (select reason_id,reason_name from(select reason_id, reason_name from hrm_category_dtl where category_id = " & dis(1) & " order by reason_name))order by 2"
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
                res = "Error: Processing failed"
            End Try
        Catch ex As Exception
            res = "Error: Invalid request"
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
        'If (DateDiff(DateInterval.Day, leavetodt, appdte) > 3) Then
        '    Dim cl_script As New StringBuilder
        '    cl_script.Append("   alert('TIME FOR SUBMITTING LEAVE APLICATION IS OVER') ;")
        '    cl_script.Append("window.open('../home.aspx','_self');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
        '    Exit Sub
        'End If

        If Me.cmb_ltype.SelectedValue = 1 And Me.txt_lcasual.Value = 1 Then
            If Me.txt_ldays.Value > 1 Then
                Me.Button1.Enabled = True
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('You Have only one Casual Leave,So you cannot apply morethan one days!!') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            End If

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
            cl_script.Append("   alert('Select Supporting Attachments!!') ;")
            ' cl_script.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub
        End If


        '--------VAPT - Enhanced File Upload Validation--------
        If Me.file_support1.HasFile Then
            If Not ValidateUploadedFile(Me.file_support1) Then
                Me.Button1.Enabled = True
                Dim cl_script As New StringBuilder
                cl_script.Append("alert('First Attachment: Invalid file type or malicious content detected!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            End If
        End If
        If Me.file_support2.HasFile Then
            If Not ValidateUploadedFile(Me.file_support2) Then
                Me.Button1.Enabled = True
                Dim cl_script As New StringBuilder
                cl_script.Append("alert('Second Attachment: Invalid file type or malicious content detected!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            End If
        End If

        If Me.file_support3.HasFile Then
            If Not ValidateUploadedFile(Me.file_support3) Then
                Me.Button1.Enabled = True
                Dim cl_script As New StringBuilder
                cl_script.Append("alert('Third Attachment: Invalid file type or malicious content detected!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            End If
        End If

        If Me.file_support4.HasFile Then
            If Not ValidateUploadedFile(Me.file_support4) Then
                Me.Button1.Enabled = True
                Dim cl_script As New StringBuilder
                cl_script.Append("alert('Fourth Attachment: Invalid file type or malicious content detected!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            End If
        End If

        If Me.file_support5.HasFile Then
            If Not ValidateUploadedFile(Me.file_support5) Then
                Me.Button1.Enabled = True
                Dim cl_script As New StringBuilder
                cl_script.Append("alert('Fifth Attachment: Invalid file type or malicious content detected!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            End If
        End If


        If Me.file_support1.FileName <> "" And Me.Chk_yes.Checked = True And Me.chk_1st.Checked = True Then
            Dim leave(12) As OracleParameter
            leave(0) = New OracleParameter("emp_id", OracleType.Int32)
            leave(0).Direction = ParameterDirection.Input
            leave(0).Value = _encryptDecrypt.Decrypt(str(0))
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
            leave(7).Value = 0
            leave(8) = New OracleParameter("res_id", OracleType.Int32)
            leave(8).Direction = ParameterDirection.Input
            leave(8).Value = str(8)
            leave(12) = New OracleParameter("new_reason", OracleType.VarChar)
            leave(12).Direction = ParameterDirection.Input
            leave(12).Value = Me.txt_oth_reason.Value

            leave(9) = New OracleParameter("msg", OracleType.VarChar, 500)
            leave(9).Direction = ParameterDirection.Output
            leave(10) = New OracleParameter("flag", OracleType.Number)
            leave(10).Direction = ParameterDirection.Output
            leave(11) = New OracleParameter("lvsq", OracleType.Number)
            leave(11).Direction = ParameterDirection.Output


            oh.ExecuteNonQuery("hrm_leave_appli", leave)
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
                            parm_coll(1).Value = _encryptDecrypt.Decrypt(Me.hdnEcode.Value.ToString())
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
                            parm_coll(1).Value = _encryptDecrypt.Decrypt(Me.hdnEcode.Value.ToString())
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
                            parm_coll(1).Value = _encryptDecrypt.Decrypt(Me.hdnEcode.Value.ToString())
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
                            parm_coll(1).Value = _encryptDecrypt.Decrypt(Me.hdnEcode.Value.ToString())
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
                            parm_coll(1).Value = _encryptDecrypt.Decrypt(Me.hdnEcode.Value.ToString())
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
            Dim leave(12) As OracleParameter
            leave(0) = New OracleParameter("emp_id", OracleType.Int32)
            leave(0).Direction = ParameterDirection.Input
            leave(0).Value = _encryptDecrypt.Decrypt(str(0))
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
            leave(7).Value = 0
            leave(8) = New OracleParameter("res_id", OracleType.Int32)
            leave(8).Direction = ParameterDirection.Input
            leave(8).Value = str(8)
            leave(12) = New OracleParameter("new_reason", OracleType.VarChar)
            leave(12).Direction = ParameterDirection.Input
            leave(12).Value = Me.txt_oth_reason.Value

            leave(9) = New OracleParameter("msg", OracleType.VarChar, 500)
            leave(9).Direction = ParameterDirection.Output
            leave(10) = New OracleParameter("flag", OracleType.Number)
            leave(10).Direction = ParameterDirection.Output
            leave(11) = New OracleParameter("lvsq", OracleType.Number)
            leave(11).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_leave_appli", leave)
            Me.Button1.Enabled = True
            Dim cl_script1 As New StringBuilder
            cl_script1.Append("   alert('" & leave(9).Value & "');")
            cl_script1.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)


        Else
            Me.Button1.Enabled = True
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('First Select Supporting Attachments!!') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub
        End If
    End Sub

    '--------VAPT - Parameter Validation Methods--------
    Private Function ValidateDateParameter(dateValue As String) As Boolean
        Try
            Dim parsedDate As DateTime
            If DateTime.TryParse(dateValue, parsedDate) Then
                Return parsedDate >= DateTime.Now.AddYears(-2) AndAlso parsedDate <= DateTime.Now.AddYears(1)
            End If
            Return False
        Catch
            Return False
        End Try
    End Function
    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Shared Function GetKey() As Object
        ' Read API key from request headers
        Dim apiKey As String = HttpContext.Current.Request.Headers("X-API-Key")

        If String.IsNullOrEmpty(apiKey) OrElse apiKey <> "SPA-API-KEY-2024" Then
            Return New With {.message = "Invalid API key"}
        End If

        ' Example: read from Web.config
        Dim key As String = "3F2A9C7B1D4E6F8A0B5C7D9E2F4A6C8D"
        Dim xorKey As String = "XOR2024"

        ' XOR encryption
        Dim encryptedBytes = key.Select(Function(c, i) CByte(AscW(c) Xor AscW(xorKey(i Mod xorKey.Length)))).ToArray()
        Dim encrypted As String = Convert.ToBase64String(encryptedBytes)

        Return New With {.key = encrypted}
    End Function

    Private Function ValidateNumericParameter(numValue As String) As Boolean
        Try
            Dim parsedNum As Integer
            If Integer.TryParse(numValue, parsedNum) Then
                Return parsedNum > 0 AndAlso parsedNum <= 9999
            End If
            Return False
        Catch
            Return False
        End Try
    End Function

    Private Function ContainsMaliciousContent(input As String) As Boolean
        If String.IsNullOrEmpty(input) Then Return False

        Dim maliciousPatterns As String() = {
            "<script", "javascript:", "vbscript:", "onload=", "onerror=",
            "''", "--", "/*", "*/", "xp_", "sp_", "exec", "union",
            "select", "insert", "update", "delete", "drop", "create"
        }

        Dim lowerInput As String = input.ToLower()
        For Each pattern As String In maliciousPatterns
            If lowerInput.Contains(pattern) Then Return True
        Next

        Return False
    End Function

    Private Function ValidateUploadedFile(fileUpload As FileUpload) As Boolean
        Try
            If Not fileUpload.HasFile Then Return False

            ' File size validation (1MB limit)
            If fileUpload.PostedFile.ContentLength > 1048576 Then Return False

            ' File extension validation
            Dim fileExtension As String = System.IO.Path.GetExtension(fileUpload.FileName).ToLower()
            Dim allowedExtensions As String() = {".jpg", ".jpeg", ".png", ".bmp"}

            If Not allowedExtensions.Contains(fileExtension) Then Return False

            ' MIME type validation
            Dim allowedMimeTypes As String() = {"image/jpeg", "image/jpg", "image/png", "image/bmp"}
            If Not allowedMimeTypes.Contains(fileUpload.PostedFile.ContentType.ToLower()) Then Return False

            ' Filename validation
            If ContainsMaliciousContent(fileUpload.FileName) Then Return False

            Return True
        Catch
            Return False
        End Try
    End Function

    Private Sub RedirectToLogin()
        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("alert('Please Login Again');")
        cl_script0.Append("window.open('../main.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
    End Sub

End Class
