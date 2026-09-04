Imports System.Data
Imports System.Data.OracleClient
Partial Class vipin_forms_photo_upload_new_ff8d610d8011

    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim image1() As Byte
    Dim image2() As Byte
    Dim usr, user1 As Integer
    Dim dt1, dt5, dt6, dt, dt2, dt10, dt11 As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim user1 As Integer = User(0)
        Dim status As Integer = Request.QueryString("status")



        If Not IsPostBack Then

            'Dim id As Integer = 533

            'form accessibility---> 533---->Magfill
            'form accessibility---> 544---->Majewel
            'form accessibility---> 545---->Macare


            dt2 = oh.ExecuteDataSet("select count(*)  from form_accessibility f where f.form_id in(533,544,545)   and f.emp_id =" & user1 & "").Tables(0)

            If dt2.Rows(0)(0) <> 0 Then



                dt1 = oh.ExecuteDataSet("select f.form_id from form_accessibility f where f.emp_id = " & user1 & "").Tables(0)







                If dt1.Rows(0)(0) = 533 Then

                    '--------MAGFILL---------





                    'dt = oh.ExecuteDataSet("select -1 emp_code, '------select---------' emp_code  from dual union all select distinct e.emp_code, e.emp_code || '-------' || e.emp_name  from employee_master e where e.join_dt = to_date(sysdate)   and e.post_id not in (89)   and e.department_id not in (154)   and e.emp_code not in (select p.employee_code from photo_upload p where p.status in(1,0)) union (select distinct e.emp_code, e.emp_code || '-------' || e.emp_name          from macdms.hrm_emp_ph_certi t, employee_master e        where t.photo is null          and e.emp_code = t.emp_code          and e.emp_code not in              (select p.employee_code  from photo_upload p where p.status in(1,0))          and e.status_id = 1          and e.post_id not in (89)          and e.department_id not in (154)          and e.EMP_NAME not like 'IBM%')").Tables(0)
                    'dt = oh.ExecuteDataSet("select -1 emp_code, '------select---------' emp_code  from dual union all select distinct e.emp_code, e.emp_code || '-------' || e.emp_name  from employee_master e where e.join_dt = to_date(sysdate)   and e.post_id not in (89)   and e.department_id not in (154)   and e.emp_code not in       (select p.employee_code from photo_upload p where p.status in (1, 0))union (select distinct e.emp_code, e.emp_code || '-------' || e.emp_name         from macdms.hrm_emp_ph_certi t, employee_master e        where t.photo is null          and e.emp_code = t.emp_code          and e.emp_code not in              (select p.employee_code                 from photo_upload p                where p.status in (1, 0))          and e.status_id = 1          and e.post_id not in (89)          and e.department_id not in (154)          and e.EMP_NAME not like 'IBM%') union                    select e.emp_code, e.emp_code || '-------' || e.emp_name  from employee_master e where e.emp_code not in (select t.emp_code from macdms.hrm_emp_ph_certi t)   and e.status_id in (1)   and e.emp_code > 10000   and e.post_id not in (89)   and e.department_id  not in (154)   and e.emp_name not like ('IBM%')").Tables(0)
                    'dt = oh.ExecuteDataSet("select -1 emp_code, '------select---------' emp_code  from dual union all  select distinct e.emp_code, e.emp_code || '-------' || e.emp_name  from employee_master e, firm_master f where e.join_dt = to_date(sysdate)   and e.post_id not in (89)   and e.department_id not in (154)   and e.emp_code not in       (select p.employee_code from photo_upload p where p.status in (1, 0))   and f.firm_id = 1   and e.firm_id = f.firm_id union select distinct e.emp_code, e.emp_code || '-------' || e.emp_name  from macdms.hrm_emp_ph_certi t, employee_master e, firm_master f where t.photo is null   and e.emp_code = t.emp_code   and e.emp_code not in       (select p.employee_code from photo_upload p where p.status in (1, 0))   and e.status_id = 1   and e.post_id not in (89)   and e.department_id not in (154)   and e.EMP_NAME not like 'IBM%'   and f.firm_id = 1   and e.firm_id = f.firm_id union select e.emp_code, e.emp_code || '-------' || e.emp_name  from employee_master e, firm_master f where e.emp_code not in (select t.emp_code from macdms.hrm_emp_ph_certi t)   and e.status_id in (1)   and e.emp_code > 10000   and e.post_id not in (89)   and e.department_id not in (154)   and e.emp_name not like ('IBM%')   and f.firm_id = 1   and e.firm_id = f.firm_id").Tables(0)
                    ' dt = oh.ExecuteDataSet("select -1 emp_code, '------select---------' emp_code     from dual   union all    select distinct e.emp_code,    e.emp_code || '-------' || e.emp_name || '-------' ||    e.join_dt    from employee_master e, branch_dtl_new b    where  e.post_id not in (89)    and e.department_id not in (154) and e.JOIN_DT>to_date('20/feb/2012')   and e.emp_code in    (select p.emp_code from macdms.hrm_emp_ph_certi p where p.status in (2))    and e.branch_id = b.branch_id    and b.status_id not in (2, 3, 4)    union    select distinct e.emp_code,    e.emp_code || '-------' || e.emp_name || '-------' ||    e.join_dt    from macdms.hrm_emp_ph_certi t, employee_master e, branch_dtl_new b    where t.photo is null    and e.emp_code = t.emp_code  and e.JOIN_DT>to_date('20/feb/2012')  and e.emp_code not in (select p.emp_code    from macdms.hrm_emp_ph_certi p    where p.status in (1, 0))    and e.status_id = 1    and e.post_id not in (89)    and e.department_id not in (154)    and e.EMP_NAME not like 'IBM%'    and b.branch_id = e.branch_id    and b.status_id not in (2, 3, 4)    union    select e.emp_code,    e.emp_code || '-------' || e.emp_name || '-------' || e.join_dt    from employee_master e, branch_dtl_new b    where e.emp_code not in (select t.emp_code from macdms.hrm_emp_ph_certi t)    and e.emp_code not in (select p.emp_code    from macdms.hrm_emp_ph_certi p    where p.status in (1, 0))    and e.status_id in (1) and e.JOIN_DT>to_date('20/feb/2012')   and e.emp_code > 10000    and e.post_id not in (89)    and e.department_id not in (154)    and e.emp_name not like ('IBM%')    and b.branch_id = e.branch_id    and b.status_id not in (2, 3, 4)").Tables(0)

                    '=======
                    If status = 1 Then



                        dt = oh.ExecuteDataSet("select -1 emp_code, '------select---------' emp_code     from dual   union all select distinct e.emp_code,    e.emp_code || '-------' || e.emp_name || '-------' ||    e.join_dt    from macdms.hrm_emp_ph_certi t, employee_master e, branch_dtl_new b    where t.photo is null    and e.emp_code = t.emp_code  and e.JOIN_DT>to_date('20/feb/2012')  and e.emp_code not in (select p.emp_code    from macdms.hrm_emp_ph_certi p    where p.status in (1,2,0))    and e.status_id = 1    and e.post_id not in (89)    and e.department_id not in (154)    and e.EMP_NAME not like 'IBM%'    and b.branch_id = e.branch_id    and b.status_id not in (2, 3, 4)    union    select e.emp_code,    e.emp_code || '-------' || e.emp_name || '-------' || e.join_dt    from employee_master e, branch_dtl_new b    where e.emp_code not in (select t.emp_code from macdms.hrm_emp_ph_certi t)    and e.emp_code not in (select p.emp_code    from macdms.hrm_emp_ph_certi p    where p.status in (1,2,0))    and e.status_id in (1) and e.JOIN_DT>to_date('20/feb/2012')   and e.emp_code > 10000    and e.post_id not in (89)    and e.department_id not in (154)    and e.emp_name not like ('IBM%')    and b.branch_id = e.branch_id    and b.status_id not in (2, 3, 4)").Tables(0)
                    ElseIf status = 2 Then

                        dt = oh.ExecuteDataSet("select -1 emp_code, '------select---------' emp_code     from dual   union all    select distinct e.emp_code,    e.emp_code || '-------' || e.emp_name || '-------' ||    e.join_dt    from employee_master e, branch_dtl_new b    where  e.post_id not in (89)    and e.department_id not in (154) and e.JOIN_DT>to_date('20/feb/2012')   and e.emp_code in    (select p.emp_code from macdms.hrm_emp_ph_certi p where p.status in (2))    and e.branch_id = b.branch_id    and b.status_id not in (2, 3, 4)").Tables(0)
                    End If
                    '=======
                    Me.DropDownList1.DataSource = dt
                    Me.DropDownList1.DataValueField = dt.Columns(0).ColumnName
                    Me.DropDownList1.DataTextField = dt.Columns(1).ColumnName
                    Me.DropDownList1.DataBind()
                    Me.DropDownList1.Focus()

                ElseIf dt1.Rows(0)(0) = 544 Then


                    '-------MAJEWELL---------



                    ' dt = oh.ExecuteDataSet("select -1 emp_code, '------select---------' emp_code  from dual  union all  select distinct e.emp_code,  e.emp_code || '-------' || e.emp_name || '-------' ||  e.join_dt  from employee_master e, branch_dtl_new b  where e.post_id not in (89)  and e.department_id not in (154)  and e.emp_code in (select p.emp_code from macdms.hrm_emp_ph_certi p where p.status in (2))  and e.branch_id = b.branch_id  and b.status_id in (2, 4)  union  select distinct e.emp_code,  e.emp_code || '-------' || e.emp_name || '-------' ||  e.join_dt  from macdms.hrm_emp_ph_certi t, employee_master e, branch_dtl_new b  where t.photo is null  and e.emp_code = t.emp_code  and e.emp_code not in (select p.emp_code  from macdms.hrm_emp_ph_certi p  where p.status in (1, 0))  and e.status_id = 1  and e.post_id not in (89)  and e.department_id not in (154)  and e.EMP_NAME not like 'IBM%'  and b.branch_id = e.branch_id  and b.status_id in (2, 4)  union  select e.emp_code,  e.emp_code || '-------' || e.emp_name || '-------' || e.join_dt  from employee_master e, branch_dtl_new b  where e.emp_code not in (select t.emp_code from macdms.hrm_emp_ph_certi t)  and e.emp_code not in (select p.emp_code  from macdms.hrm_emp_ph_certi p  where p.status in (1, 0))  and e.status_id in (1)  and e.emp_code > 10000  and e.post_id not in (89)  and e.department_id not in (154)  and e.emp_name not like ('IBM%')  and b.branch_id = e.branch_id  and b.status_id in (2, 4) ").Tables(0)

                    '=======
                    If status = 1 Then



                        dt = oh.ExecuteDataSet("select -1 emp_code, '------select---------' emp_code     from dual   union all select distinct e.emp_code,    e.emp_code || '-------' || e.emp_name || '-------' ||    e.join_dt    from macdms.hrm_emp_ph_certi t, employee_master e, branch_dtl_new b    where t.photo is null    and e.emp_code = t.emp_code  and e.JOIN_DT>to_date('20/feb/2012')  and e.emp_code not in (select p.emp_code    from macdms.hrm_emp_ph_certi p    where p.status in (1,2,0))    and e.status_id = 1    and e.post_id not in (89)    and e.department_id not in (154)    and e.EMP_NAME not like 'IBM%'    and b.branch_id = e.branch_id    and b.status_id not in (2, 3, 4)    union    select e.emp_code,    e.emp_code || '-------' || e.emp_name || '-------' || e.join_dt    from employee_master e, branch_dtl_new b    where e.emp_code not in (select t.emp_code from macdms.hrm_emp_ph_certi t)    and e.emp_code not in (select p.emp_code    from macdms.hrm_emp_ph_certi p    where p.status in (1,2,0))    and e.status_id in (1) and e.JOIN_DT>to_date('20/feb/2012')   and e.emp_code > 10000    and e.post_id not in (89)    and e.department_id not in (154)    and e.emp_name not like ('IBM%')    and b.branch_id = e.branch_id    and b.status_id not in (2, 3, 4)").Tables(0)
                    ElseIf status = 2 Then

                        dt = oh.ExecuteDataSet("select -1 emp_code, '------select---------' emp_code     from dual   union all    select distinct e.emp_code,    e.emp_code || '-------' || e.emp_name || '-------' ||    e.join_dt    from employee_master e, branch_dtl_new b    where  e.post_id not in (89)    and e.department_id not in (154) and e.JOIN_DT>to_date('20/feb/2012')   and e.emp_code in    (select p.emp_code from macdms.hrm_emp_ph_certi p where p.status in (2))    and e.branch_id = b.branch_id    and b.status_id not in (2, 3, 4)").Tables(0)
                    End If
                    '=======
                    Me.DropDownList1.DataSource = dt
                    Me.DropDownList1.DataValueField = dt.Columns(0).ColumnName
                    Me.DropDownList1.DataTextField = dt.Columns(1).ColumnName
                    Me.DropDownList1.DataBind()
                    Me.DropDownList1.Focus()


                ElseIf dt1.Rows(0)(0) = 545 Then



                    '-----------MACARE----------


                    '  dt = oh.ExecuteDataSet("select -1 emp_code, '------select---------' emp_code  from dual  union all  select distinct e.emp_code,  e.emp_code || '-------' || e.emp_name || '-------' ||  e.join_dt  from employee_master e, branch_dtl_new b  where e.post_id not in (89)  and e.department_id not in (154)  and e.emp_code not in (select p.emp_code from macdms.hrm_emp_ph_certi p where p.status in (2))  and e.branch_id = b.branch_id  and b.status_id in (3)  union  select distinct e.emp_code,  e.emp_code || '-------' || e.emp_name || '-------' ||  e.join_dt  from macdms.hrm_emp_ph_certi t, employee_master e, branch_dtl_new b  where t.photo is null  and e.emp_code = t.emp_code  and e.emp_code not in (select p.emp_code  from macdms.hrm_emp_ph_certi p  where p.status in (1, 0))  and e.status_id = 1  and e.post_id not in (89)  and e.department_id not in (154)  and e.EMP_NAME not like 'IBM%'  and b.branch_id = e.branch_id  and b.status_id in (3)  union  select e.emp_code,  e.emp_code || '-------' || e.emp_name || '-------' || e.join_dt  from employee_master e, branch_dtl_new b  where e.emp_code not in (select t.emp_code from macdms.hrm_emp_ph_certi t)  and e.emp_code not in (select p.emp_code  from macdms.hrm_emp_ph_certi p  where p.status in (1, 0))  and e.status_id in (1)  and e.emp_code > 10000  and e.post_id not in (89)  and e.department_id not in (154)  and e.emp_name not like ('IBM%')  and b.branch_id = e.branch_id  and b.status_id in (3)").Tables(0)

                    '=======
                    If status = 1 Then



                        dt = oh.ExecuteDataSet("select -1 emp_code, '------select---------' emp_code     from dual   union all select distinct e.emp_code,    e.emp_code || '-------' || e.emp_name || '-------' ||    e.join_dt    from macdms.hrm_emp_ph_certi t, employee_master e, branch_dtl_new b    where t.photo is null    and e.emp_code = t.emp_code  and e.JOIN_DT>to_date('20/feb/2012')  and e.emp_code not in (select p.emp_code    from macdms.hrm_emp_ph_certi p    where p.status in (1,2,0))    and e.status_id = 1    and e.post_id not in (89)    and e.department_id not in (154)    and e.EMP_NAME not like 'IBM%'    and b.branch_id = e.branch_id    and b.status_id not in (2, 3, 4)    union    select e.emp_code,    e.emp_code || '-------' || e.emp_name || '-------' || e.join_dt    from employee_master e, branch_dtl_new b    where e.emp_code not in (select t.emp_code from macdms.hrm_emp_ph_certi t)    and e.emp_code not in (select p.emp_code    from macdms.hrm_emp_ph_certi p    where p.status in (1,2,0))    and e.status_id in (1) and e.JOIN_DT>to_date('20/feb/2012')   and e.emp_code > 10000    and e.post_id not in (89)    and e.department_id not in (154)    and e.emp_name not like ('IBM%')    and b.branch_id = e.branch_id    and b.status_id not in (2, 3, 4)").Tables(0)
                    ElseIf status = 2 Then

                        dt = oh.ExecuteDataSet("select -1 emp_code, '------select---------' emp_code     from dual   union all    select distinct e.emp_code,    e.emp_code || '-------' || e.emp_name || '-------' ||    e.join_dt    from employee_master e, branch_dtl_new b    where  e.post_id not in (89)    and e.department_id not in (154) and e.JOIN_DT>to_date('20/feb/2012')   and e.emp_code in    (select p.emp_code from macdms.hrm_emp_ph_certi p where p.status in (2))    and e.branch_id = b.branch_id    and b.status_id not in (2, 3, 4)").Tables(0)
                    End If
                    '=======
                    Me.DropDownList1.DataSource = dt
                    Me.DropDownList1.DataValueField = dt.Columns(0).ColumnName
                    Me.DropDownList1.DataTextField = dt.Columns(1).ColumnName
                    Me.DropDownList1.DataBind()
                    Me.DropDownList1.Focus()


                End If
            Else
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('You Are Not Authorised!!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

            End If



        End If






    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim user1 As Integer = User(0)


        '-------check photo type supported------------>

        If Me.FileUpload1.HasFile Then
            Dim fileExtension As String
            fileExtension = System.IO.Path. _
                GetExtension(Me.FileUpload1.FileName).ToLower()
            Dim allowedExtensions As String() = _
                {".jpg", ".jpeg"}
            Dim fileok As Boolean
            fileok = False
            For i As Integer = 0 To allowedExtensions.Length - 1
                If fileExtension = allowedExtensions(i) Then
                    fileok = True
                End If
            Next
            If Not (fileok) Then
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('The File Type of Photo Not Supported!!--attach .jpg/.jpeg') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            End If


        End If


        '-----------checking ssslc number and date of birth.........////////




        'dt5 = oh.ExecuteDataSet("select distinct a.emp_code, ap.sslc_no  from employee_master a, employ_personal_dtl ap where a.emp_code = ap.emp_code      and a.emp_code = " & Me.DropDownList1.SelectedValue & " group by a.emp_code, ap.sslc_no").Tables(0)
        dt5 = oh.ExecuteDataSet("select distinct  ap.sslc_no,ap.birth_date  from  appln_interview_dtl a, appln_pers_dtl ap where ap.appln_no = a.appln_no      and a.emp_code = " & Me.DropDownList1.SelectedValue & " ").Tables(0)

        If IsDBNull(dt5.Rows(0)(0)) Or IsDBNull(dt5.Rows(0)(1)) Then
            dt6 = oh.ExecuteDataSet("select  ep.sslc_no,ep.birth_date  from employ_personal_dtl ep where ep.emp_code = " & Me.DropDownList1.SelectedValue & "").Tables(0)
            If (dt6.Rows(0)(0) = Me.TextBox1.Text And dt6.Rows(0)(1) = Me.txt_select.Text) Then
                '--------------------


                Dim DirPath As String
                DirPath = Me.Server.MapPath("../image")
                Dim fnm As String
                Try
                    If Me.FileUpload1.FileName <> "" Then
                        fnm = GetUniqueFilename(DirPath + "/empphoto.jpg")
                        If Me.FileUpload1.HasFile Then
                            Me.FileUpload1.SaveAs(fnm)
                        End If
                        Dim fs As New IO.FileStream(fnm, IO.FileMode.Open, IO.FileAccess.Read)

                        Dim bl(fs.Length) As Byte
                        fs.Read(bl, 0, fs.Length)
                        fs.Close()
                        image1 = bl
                        Dim fp As New IO.FileInfo(fnm)


                        If fp.Exists Then
                            fp.Delete()
                        End If
                        'int1 = 1
                    End If
                    'fileupload1.PostedFile.ContentLength







                    'Dim sql As String
                    ''If int1 = 1 Then
                    'sql = "insert into dms.photo_upload(employee_code,photo,status,updated_by,update_date,sslc_number,date_of_birth)  values (:code,:ph,:st,:upd,:updt,:ssl,:dtb)"
                    ''End If


                    'Dim parm_col(6) As OracleParameter

                    'parm_col(0) = New OracleParameter
                    'parm_col(0).ParameterName = "code"
                    'parm_col(0).OracleType = OracleType.Number
                    'parm_col(0).Direction = ParameterDirection.Input
                    'parm_col(0).Value = Me.DropDownList1.SelectedValue

                    'parm_col(1) = New OracleParameter
                    'parm_col(1).ParameterName = "ph"
                    'parm_col(1).OracleType = OracleType.Blob
                    'parm_col(1).Direction = ParameterDirection.Input
                    'parm_col(1).Value = image1


                    'parm_col(2) = New OracleParameter
                    'parm_col(2).ParameterName = "st"
                    'parm_col(2).OracleType = OracleType.Number
                    'parm_col(2).Direction = ParameterDirection.Input
                    'parm_col(2).Value = 0




                    'parm_col(3) = New OracleParameter
                    'parm_col(3).ParameterName = "upd"
                    'parm_col(3).OracleType = OracleType.Number
                    'parm_col(3).Direction = ParameterDirection.Input
                    'parm_col(3).Value = user1


                    'parm_col(4) = New OracleParameter
                    'parm_col(4).ParameterName = "updt"
                    'parm_col(4).OracleType = OracleType.DateTime
                    'parm_col(4).Direction = ParameterDirection.Input
                    'parm_col(4).Value = Now()


                    'parm_col(5) = New OracleParameter
                    'parm_col(5).ParameterName = "ssl"
                    'parm_col(5).OracleType = OracleType.VarChar
                    'parm_col(5).Direction = ParameterDirection.Input
                    'parm_col(5).Value = Me.TextBox1.Text




                    'parm_col(6) = New OracleParameter
                    'parm_col(6).ParameterName = "dtb"
                    'parm_col(6).OracleType = OracleType.DateTime
                    'parm_col(6).Direction = ParameterDirection.Input
                    'parm_col(6).Value = Me.txt_select.Text

                    'oh.ExecuteNonQuery(sql, parm_col)






                    'Dim sql1 As String

                    'sql1 = "update dms.photo_upload h set h.photo= :ph where h.employee_code=:code"
                    'Dim parm_coll1(1) As OracleParameter

                    'parm_coll1(0) = New OracleParameter
                    'parm_coll1(0).ParameterName = "code"
                    'parm_coll1(0).OracleType = OracleType.Number
                    'parm_coll1(0).Direction = ParameterDirection.Input
                    'parm_coll1(0).Value = Me.DropDownList1.SelectedValue

                    'parm_coll1(1) = New OracleParameter
                    'parm_coll1(1).ParameterName = "ph"
                    'parm_coll1(1).OracleType = OracleType.Blob
                    'parm_coll1(1).Direction = ParameterDirection.Input
                    'parm_coll1(1).Value = image1

                    'oh.ExecuteNonQuery(sql1, parm_coll1)

                    '-----------------------------dms.emp_certifi-------




                    dt10 = oh.ExecuteDataSet("select count(*) from macdms.hrm_emp_ph_certi d where d.emp_code=" & Me.DropDownList1.SelectedValue & "").Tables(0)


                    If dt10.Rows(0)(0) = 0 Then
                        Dim dms As String
                        'If int1 = 1 Then
                        dms = "insert into macdms.hrm_emp_ph_certi(emp_code,photo,status,updated_by,update_date)  values (:code,:ph,:st,:upd.:updt)"
                        'End If


                        Dim dms1(4) As OracleParameter

                        dms1(0) = New OracleParameter
                        dms1(0).ParameterName = "code"
                        dms1(0).OracleType = OracleType.Number
                        dms1(0).Direction = ParameterDirection.Input
                        dms1(0).Value = Me.DropDownList1.SelectedValue

                        dms1(1) = New OracleParameter
                        dms1(1).ParameterName = "ph"
                        dms1(1).OracleType = OracleType.Blob
                        dms1(1).Direction = ParameterDirection.Input
                        dms1(1).Value = image1

                        dms1(2) = New OracleParameter
                        dms1(2).ParameterName = "st"
                        dms1(2).OracleType = OracleType.Number
                        dms1(2).Direction = ParameterDirection.Input
                        dms1(2).Value = 0

                        dms1(3) = New OracleParameter
                        dms1(3).ParameterName = "upd"
                        dms1(3).OracleType = OracleType.Number
                        dms1(3).Direction = ParameterDirection.Input
                        dms1(3).Value = user1


                        dms1(4) = New OracleParameter
                        dms1(4).ParameterName = "updt"
                        dms1(4).OracleType = OracleType.DateTime
                        dms1(4).Direction = ParameterDirection.Input
                        dms1(4).Value = Now()



                        oh.ExecuteNonQuery(dms, dms1)



                        Dim sq1 As String

                        sq1 = "update macdms.hrm_emp_ph_certi h set h.photo= :ph where h.emp_code=:code"
                        Dim emp(1) As OracleParameter

                        emp(0) = New OracleParameter
                        emp(0).ParameterName = "code"
                        emp(0).OracleType = OracleType.Number
                        emp(0).Direction = ParameterDirection.Input
                        emp(0).Value = Me.DropDownList1.SelectedValue

                        emp(1) = New OracleParameter
                        emp(1).ParameterName = "ph"
                        emp(1).OracleType = OracleType.Blob
                        emp(1).Direction = ParameterDirection.Input
                        emp(1).Value = image1

                        oh.ExecuteNonQuery(sq1, emp)
















                    Else
                        dt11 = oh.ExecuteDataSet("select d.photo from macdms.hrm_emp_ph_certi d where d.emp_code=" & Me.DropDownList1.SelectedValue & "").Tables(0)

                        If IsDBNull(dt11.Rows(0)(0)) Then
                            Dim sq1 As String

                            sq1 = "update macdms.hrm_emp_ph_certi h set h.photo= :ph,h.status=:st,h.updated_by=:upd,h.update_date=:updt where h.emp_code=:code"
                            Dim emp(4) As OracleParameter

                            emp(0) = New OracleParameter
                            emp(0).ParameterName = "code"
                            emp(0).OracleType = OracleType.Number
                            emp(0).Direction = ParameterDirection.Input
                            emp(0).Value = Me.DropDownList1.SelectedValue

                            emp(1) = New OracleParameter
                            emp(1).ParameterName = "ph"
                            emp(1).OracleType = OracleType.Blob
                            emp(1).Direction = ParameterDirection.Input
                            emp(1).Value = image1

                            emp(2) = New OracleParameter
                            emp(2).ParameterName = "st"
                            emp(2).OracleType = OracleType.Number
                            emp(2).Direction = ParameterDirection.Input
                            emp(2).Value = 0

                            emp(3) = New OracleParameter
                            emp(3).ParameterName = "upd"
                            emp(3).OracleType = OracleType.Number
                            emp(3).Direction = ParameterDirection.Input
                            emp(3).Value = user1


                            emp(4) = New OracleParameter
                            emp(4).ParameterName = "updt"
                            emp(4).OracleType = OracleType.DateTime
                            emp(4).Direction = ParameterDirection.Input
                            emp(4).Value = Now()


                            oh.ExecuteNonQuery(sq1, emp)
                        End If
                    End If







                    Dim sq As String

                    sq = "update employ_personal_dtl h set h.sslc_no= :ssl,h.remarks='PHOTO UPDATION' where h.emp_code=:code"
                    Dim personal(1) As OracleParameter

                    personal(0) = New OracleParameter
                    personal(0).ParameterName = "code"
                    personal(0).OracleType = OracleType.Number
                    personal(0).Direction = ParameterDirection.Input
                    personal(0).Value = Me.DropDownList1.SelectedValue


                    personal(1) = New OracleParameter
                    personal(1).ParameterName = "ssl"
                    personal(1).OracleType = OracleType.VarChar
                    personal(1).Direction = ParameterDirection.Input
                    personal(1).Value = Me.TextBox1.Text



                    oh.ExecuteNonQuery(sq, personal)



                Catch ex As Exception
                    Response.Write(ex.Message.ToString)
                End Try



                Dim cl_scriptp As New StringBuilder
                cl_scriptp.Append("   alert(' Successfully Done!!') ;")
                cl_scriptp.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scriptp.ToString, True)

            Else

                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('SSLC NUMBER OR DATE OF BIRTH YOU ENTERED IS WRONG!!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script0.ToString, True)

            End If
        Else



            If (dt5.Rows(0)(0) = Me.TextBox1.Text And dt5.Rows(0)(1) = Me.txt_select.Text) Then
                '--------------------


                Dim DirPath As String
                DirPath = Me.Server.MapPath("../image")
                Dim fnm As String
                Try
                    If Me.FileUpload1.FileName <> "" Then
                        fnm = GetUniqueFilename(DirPath + "/empphoto.jpg")
                        If Me.FileUpload1.HasFile Then
                            Me.FileUpload1.SaveAs(fnm)
                        End If
                        Dim fs As New IO.FileStream(fnm, IO.FileMode.Open, IO.FileAccess.Read)

                        Dim bl(fs.Length) As Byte
                        fs.Read(bl, 0, fs.Length)
                        fs.Close()
                        image1 = bl
                        Dim fp As New IO.FileInfo(fnm)


                        If fp.Exists Then
                            fp.Delete()
                        End If
                        'int1 = 1
                    End If
                    'fileupload1.PostedFile.ContentLength







                    'Dim sql As String
                    ''If int1 = 1 Then
                    'sql = "insert into dms.photo_upload(employee_code,photo,status,updated_by,update_date,sslc_number,date_of_birth)  values (:code,:ph,:st,:upd,:updt,:ssl,:dtb)"
                    ''End If


                    'Dim parm_col(6) As OracleParameter

                    'parm_col(0) = New OracleParameter
                    'parm_col(0).ParameterName = "code"
                    'parm_col(0).OracleType = OracleType.Number
                    'parm_col(0).Direction = ParameterDirection.Input
                    'parm_col(0).Value = Me.DropDownList1.SelectedValue

                    'parm_col(1) = New OracleParameter
                    'parm_col(1).ParameterName = "ph"
                    'parm_col(1).OracleType = OracleType.Blob
                    'parm_col(1).Direction = ParameterDirection.Input
                    'parm_col(1).Value = image1


                    'parm_col(2) = New OracleParameter
                    'parm_col(2).ParameterName = "st"
                    'parm_col(2).OracleType = OracleType.Number
                    'parm_col(2).Direction = ParameterDirection.Input
                    'parm_col(2).Value = 0




                    'parm_col(3) = New OracleParameter
                    'parm_col(3).ParameterName = "upd"
                    'parm_col(3).OracleType = OracleType.Number
                    'parm_col(3).Direction = ParameterDirection.Input
                    'parm_col(3).Value = user1


                    'parm_col(4) = New OracleParameter
                    'parm_col(4).ParameterName = "updt"
                    'parm_col(4).OracleType = OracleType.DateTime
                    'parm_col(4).Direction = ParameterDirection.Input
                    'parm_col(4).Value = Now()


                    'parm_col(5) = New OracleParameter
                    'parm_col(5).ParameterName = "ssl"
                    'parm_col(5).OracleType = OracleType.VarChar
                    'parm_col(5).Direction = ParameterDirection.Input
                    'parm_col(5).Value = Me.TextBox1.Text




                    'parm_col(6) = New OracleParameter
                    'parm_col(6).ParameterName = "dtb"
                    'parm_col(6).OracleType = OracleType.DateTime
                    'parm_col(6).Direction = ParameterDirection.Input
                    'parm_col(6).Value = Me.txt_select.Text

                    'oh.ExecuteNonQuery(sql, parm_col)


                    ''--------------photo update--------------------


                    'Dim sql1 As String

                    'sql1 = "update dms.photo_upload h set h.photo= :ph where h.employee_code=:code"
                    'Dim parm_coll1(1) As OracleParameter

                    'parm_coll1(0) = New OracleParameter
                    'parm_coll1(0).ParameterName = "code"
                    'parm_coll1(0).OracleType = OracleType.Number
                    'parm_coll1(0).Direction = ParameterDirection.Input
                    'parm_coll1(0).Value = Me.DropDownList1.SelectedValue

                    'parm_coll1(1) = New OracleParameter
                    'parm_coll1(1).ParameterName = "ph"
                    'parm_coll1(1).OracleType = OracleType.Blob
                    'parm_coll1(1).Direction = ParameterDirection.Input
                    'parm_coll1(1).Value = image1

                    'oh.ExecuteNonQuery(sql1, parm_coll1)


                    dt10 = oh.ExecuteDataSet("select count(*) from macdms.hrm_emp_ph_certi d where d.emp_code=" & Me.DropDownList1.SelectedValue & "").Tables(0)


                    If dt10.Rows(0)(0) = 0 Then
                        Dim dms As String
                        'If int1 = 1 Then
                        dms = "insert into macdms.hrm_emp_ph_certi(emp_code,photo,status,updated_by,update_date)  values (:code,:ph,:st,:upd,:updt)"
                        'End If


                        Dim dms1(4) As OracleParameter

                        dms1(0) = New OracleParameter
                        dms1(0).ParameterName = "code"
                        dms1(0).OracleType = OracleType.Number
                        dms1(0).Direction = ParameterDirection.Input
                        dms1(0).Value = Me.DropDownList1.SelectedValue

                        dms1(1) = New OracleParameter
                        dms1(1).ParameterName = "ph"
                        dms1(1).OracleType = OracleType.Blob
                        dms1(1).Direction = ParameterDirection.Input
                        dms1(1).Value = image1

                        dms1(2) = New OracleParameter
                        dms1(2).ParameterName = "st"
                        dms1(2).OracleType = OracleType.Number
                        dms1(2).Direction = ParameterDirection.Input
                        dms1(2).Value = 0

                        dms1(3) = New OracleParameter
                        dms1(3).ParameterName = "upd"
                        dms1(3).OracleType = OracleType.Number
                        dms1(3).Direction = ParameterDirection.Input
                        dms1(3).Value = user1


                        dms1(4) = New OracleParameter
                        dms1(4).ParameterName = "updt"
                        dms1(4).OracleType = OracleType.DateTime
                        dms1(4).Direction = ParameterDirection.Input
                        dms1(4).Value = Now()



                        oh.ExecuteNonQuery(dms, dms1)



                        Dim sq1 As String

                        sq1 = "update macdms.hrm_emp_ph_certi h set h.photo= :ph,h.status=:st where h.emp_code=:code"
                        Dim emp(2) As OracleParameter

                        emp(0) = New OracleParameter
                        emp(0).ParameterName = "code"
                        emp(0).OracleType = OracleType.Number
                        emp(0).Direction = ParameterDirection.Input
                        emp(0).Value = Me.DropDownList1.SelectedValue

                        emp(1) = New OracleParameter
                        emp(1).ParameterName = "ph"
                        emp(1).OracleType = OracleType.Blob
                        emp(1).Direction = ParameterDirection.Input
                        emp(1).Value = image1

                        emp(2) = New OracleParameter
                        emp(2).ParameterName = "st"
                        emp(2).OracleType = OracleType.Number
                        emp(2).Direction = ParameterDirection.Input
                        emp(2).Value = 0

                        oh.ExecuteNonQuery(sq1, emp)
















                    Else
                        dt11 = oh.ExecuteDataSet("select d.photo,d.status from macdms.hrm_emp_ph_certi d where d.emp_code=" & Me.DropDownList1.SelectedValue & "").Tables(0)

                        If IsDBNull(dt11.Rows(0)(0)) Then
                            Dim sq1 As String

                            sq1 = "update macdms.hrm_emp_ph_certi h set h.photo= :ph,h.status=:st,h.updated_by=:upd,h.update_date=:updt where h.emp_code=:code"
                            Dim emp(4) As OracleParameter

                            emp(0) = New OracleParameter
                            emp(0).ParameterName = "code"
                            emp(0).OracleType = OracleType.Number
                            emp(0).Direction = ParameterDirection.Input
                            emp(0).Value = Me.DropDownList1.SelectedValue

                            emp(1) = New OracleParameter
                            emp(1).ParameterName = "ph"
                            emp(1).OracleType = OracleType.Blob
                            emp(1).Direction = ParameterDirection.Input
                            emp(1).Value = image1

                            emp(2) = New OracleParameter
                            emp(2).ParameterName = "st"
                            emp(2).OracleType = OracleType.Number
                            emp(2).Direction = ParameterDirection.Input
                            emp(2).Value = 0

                            emp(3) = New OracleParameter
                            emp(3).ParameterName = "upd"
                            emp(3).OracleType = OracleType.Number
                            emp(3).Direction = ParameterDirection.Input
                            emp(3).Value = user1


                            emp(4) = New OracleParameter
                            emp(4).ParameterName = "updt"
                            emp(4).OracleType = OracleType.DateTime
                            emp(4).Direction = ParameterDirection.Input
                            emp(4).Value = Now()

                            oh.ExecuteNonQuery(sq1, emp)
                        Else
                            If (dt11.Rows(0)(1) = 2) Then
                                Dim sq1 As String

                                sq1 = "update macdms.hrm_emp_ph_certi h set h.photo= :ph,h.status=:st where h.emp_code=:code"
                                Dim emp(2) As OracleParameter

                                emp(0) = New OracleParameter
                                emp(0).ParameterName = "code"
                                emp(0).OracleType = OracleType.Number
                                emp(0).Direction = ParameterDirection.Input
                                emp(0).Value = Me.DropDownList1.SelectedValue

                                emp(1) = New OracleParameter
                                emp(1).ParameterName = "ph"
                                emp(1).OracleType = OracleType.Blob
                                emp(1).Direction = ParameterDirection.Input
                                emp(1).Value = image1

                                emp(2) = New OracleParameter
                                emp(2).ParameterName = "st"
                                emp(2).OracleType = OracleType.Number
                                emp(2).Direction = ParameterDirection.Input
                                emp(2).Value = 0

                                oh.ExecuteNonQuery(sq1, emp)

                            End If
                        End If
                    End If







                    '--------------update  in table-----------------

                    Dim sq As String

                    sq = "update employ_personal_dtl h set h.sslc_no= :ssl,h.remarks='PHOTO UPDATION' where h.emp_code=:code"

                    Dim personal(1) As OracleParameter

                    personal(0) = New OracleParameter
                    personal(0).ParameterName = "code"
                    personal(0).OracleType = OracleType.Number
                    personal(0).Direction = ParameterDirection.Input
                    personal(0).Value = Me.DropDownList1.SelectedValue


                    personal(1) = New OracleParameter
                    personal(1).ParameterName = "ssl"
                    personal(1).OracleType = OracleType.VarChar
                    personal(1).Direction = ParameterDirection.Input
                    personal(1).Value = Me.TextBox1.Text



                    oh.ExecuteNonQuery(sq, personal)


                Catch ex As Exception
                    Response.Write(ex.Message.ToString)
                End Try

                Dim cl_scriptp As New StringBuilder
                cl_scriptp.Append("   alert(' Successfully Done!!') ;")
                cl_scriptp.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scriptp.ToString, True)

            Else

                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('SSLC NUMBER OR DATE OF BIRTH YOU ENTERED IS WRONG!!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script0.ToString, True)

            End If
        End If
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
End Class
