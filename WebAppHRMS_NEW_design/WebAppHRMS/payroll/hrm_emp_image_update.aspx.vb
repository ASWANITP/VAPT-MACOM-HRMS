Imports System.Data
Imports System.Data.OracleClient
Partial Class emp_image_hrm_emp_image_update_f0c39c838043
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim usr As Integer
    Dim image1() As Byte
    Dim image2() As Byte
    Dim int1, int2, int3, int4 As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'usr = Me.Session("user_id").ToString.Split("!")(0)
        'Me.hid3.Value = usr
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Dim dt As New DataTable
        dt = oh.ExecuteDataSet("select count(*) from employee_master where access_id<>33 and emp_code=" & User(0) & "").Tables(0)
        If dt.Rows(0)(0) > 0 Then
            Server.Transfer("../show_err.aspx")
        End If
        Dim cs As String = "var cont_name;cont_name='" & Me.txt_qualification.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        'If Not IsPostBack Then
        '    Me.hid2.Value = 0
        '    int3 = int4 = 0
        '    Dim sql As String = "select count(*) from dms.hrm_emp_ph_certi where emp_code=" & usr
        '    Dim stable As Integer = oh.ExecuteDataSet(sql).Tables(0).Rows(0)(0)
        '    If stable > 0 Then
        '        sql = "select qc.category,qm.qualification,e.qualification,e.marks,e.total,e.photo,e.certificate from dms.hrm_emp_ph_certi e,qualification_master qm,qualification_category qc where emp_code=" & usr & " and e.qualification=qm.qualification_id and qm.category_id=qc.category_id"
        '        Dim pq As DataTable = oh.ExecuteDataSet(sql).Tables(0)
        '        Me.txt_category.Value = pq.Rows(0)(1)
        '        Me.txt_qualification.Value = pq.Rows(0)(0)
        '        Me.hid1.Value = pq.Rows(0)(2)
        '        Me.txt_total.Text = pq.Rows(0)(4)
        '        Me.txt_marks.Text = pq.Rows(0)(3)
        '        Me.txt_marks.ReadOnly = True
        '        Me.txt_total.ReadOnly = True
        '        If Not IsDBNull(pq.Rows(0)(5)) Then
        '            Me.FileUpload1.Enabled = False
        '            Me.hid2.Value = 1
        '        End If
        '        If Not IsDBNull(pq.Rows(0)(6)) Then
        '            Me.FileUpload2.Enabled = False
        '            Me.hid2.Value = 2
        '        End If
        '    End If
        '    sql = "select a.qualification,c.category,b.qualification,nvl(b.percentage,0) from employ_qualification_dtl b,qualification_master a,qualification_category c where a.qualification_id=b.qualification and a.category_id=c.category_id and (b.emp_code,b.year_pass) in (select distinct emp_code,max(year_pass) from employ_qualification_dtl group by emp_code) and emp_code=" & usr & " and a.category_id in (select a.category_id from employ_qualification_dtl b,qualification_master a where a.qualification_id=b.qualification and b.emp_code=" & usr & ")"
        '    Dim dt As DataTable = oh.ExecuteDataSet(sql).Tables(0)
        '    Me.txt_category.Value = dt.Rows(0)(1)
        '    Me.txt_qualification.Value = dt.Rows(0)(0)
        '    Me.hid1.Value = dt.Rows(0)(2)
        'End If
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
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        int1 = int2 = 0
        If Me.hid2.Value = 1 Then
            int3 = 1
        End If
        If Me.hid2.Value = 2 Then
            int4 = 1
        End If
        If Me.hid2.Value = 3 Then
            int3 = 1
            int4 = 1
        End If
        'check photo type supported
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
        'check certificate type supported
        If Me.FileUpload2.HasFile Then
            Dim fileExtension As String
            fileExtension = System.IO.Path. _
                GetExtension(Me.FileUpload2.FileName).ToLower()
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
                cl_script.Append("   alert('The File Type of Certificate Not Supported!!--attach .jpg/.jpeg) ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            End If
        End If
        'attach photo
        Dim DirPath As String
        DirPath = Me.Server.MapPath("../image")
        Dim fnm, fnm1 As String
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
                int1 = 1
            End If

            If Me.FileUpload2.FileName <> "" Then
                fnm1 = GetUniqueFilename(DirPath + "/empcerticate.jpg")
                If Me.FileUpload2.HasFile Then
                    Me.FileUpload2.SaveAs(fnm1)
                End If
                Dim fs As New IO.FileStream(fnm1, IO.FileMode.Open, IO.FileAccess.Read)
                Dim b2(fs.Length) As Byte
                fs.Read(b2, 0, fs.Length)
                fs.Close()
                image2 = b2
                Dim fp As New IO.FileInfo(fnm1)
                If fp.Exists Then
                    fp.Delete()
                End If
                int2 = 1
            End If
            Dim sql As String
            If (int3 = 0 And int4 = 0) Then
                'If int3 = 1 And int4 = 1 Then
                '    sql = "delete from dms.hrm_emp_ph_certi h where h.emp_code= " & Me.TextBox1.Text
                '    oh.ExecuteNonQuery(sql)
                'End If
                If int1 = 1 And int2 = 1 Then
                    sql = "insert into dms.hrm_emp_ph_certi(emp_code,qualification,marks,total,photo,certificate)  values(:code,:quali,:mark,:tot,:ph,:certi)"
                ElseIf int1 = 1 Then
                    sql = "insert into dms.hrm_emp_ph_certi(emp_code,qualification,marks,total,photo)  values(:code,:quali,:mark,:tot,:ph)"
                Else
                    sql = "insert into dms.hrm_emp_ph_certi(emp_code,qualification,marks,total,certificate)  values(:code,:quali,:mark,:tot,:certi)"
                End If
                Dim parm_coll(5) As OracleParameter
                parm_coll(0) = New OracleParameter
                parm_coll(0).ParameterName = "code"
                parm_coll(0).OracleType = OracleType.Number
                parm_coll(0).Direction = ParameterDirection.Input
                parm_coll(0).Value = Me.TextBox1.Text

                parm_coll(1) = New OracleParameter
                parm_coll(1).ParameterName = "quali"
                parm_coll(1).OracleType = OracleType.Number
                parm_coll(1).Direction = ParameterDirection.Input
                parm_coll(1).Value = Me.hid1.Value

                parm_coll(2) = New OracleParameter
                parm_coll(2).ParameterName = "mark"
                parm_coll(2).OracleType = OracleType.Number
                parm_coll(2).Direction = ParameterDirection.Input
                parm_coll(2).Value = Int(Me.txt_marks.Text)

                parm_coll(3) = New OracleParameter
                parm_coll(3).ParameterName = "tot"
                parm_coll(3).OracleType = OracleType.Number
                parm_coll(3).Direction = ParameterDirection.Input
                parm_coll(3).Value = Int(Me.txt_total.Text)
                parm_coll(4) = New OracleParameter
                parm_coll(4).ParameterName = "ph"
                parm_coll(4).OracleType = OracleType.Blob
                parm_coll(4).Direction = ParameterDirection.Input
                parm_coll(4).Value = image1
                parm_coll(5) = New OracleParameter
                parm_coll(5).ParameterName = "certi"
                parm_coll(5).OracleType = OracleType.Blob
                parm_coll(5).Direction = ParameterDirection.Input
                parm_coll(5).Value = image2
                oh.ExecuteNonQuery(sql, parm_coll)
            ElseIf int3 = 1 And int4 = 0 Then
                sql = "update dms.hrm_emp_ph_certi h set h.certificate=:certi where h.emp_code=:code"
                Dim parm_coll1(1) As OracleParameter
                parm_coll1(0) = New OracleParameter
                parm_coll1(0).ParameterName = "code"
                parm_coll1(0).OracleType = OracleType.Number
                parm_coll1(0).Direction = ParameterDirection.Input
                parm_coll1(0).Value = Me.TextBox1.Text
                parm_coll1(1) = New OracleParameter
                parm_coll1(1).ParameterName = "certi"
                parm_coll1(1).OracleType = OracleType.Blob
                parm_coll1(1).Direction = ParameterDirection.Input
                parm_coll1(1).Value = image2
                oh.ExecuteNonQuery(sql, parm_coll1)
            ElseIf int3 = 0 And int4 = 1 Then
                sql = "update dms.hrm_emp_ph_certi h set h.photo= :ph where h.emp_code=:code"
                Dim parm_coll1(1) As OracleParameter
                parm_coll1(0) = New OracleParameter
                parm_coll1(0).ParameterName = "code"
                parm_coll1(0).OracleType = OracleType.Number
                parm_coll1(0).Direction = ParameterDirection.Input
                parm_coll1(0).Value = Me.TextBox1.Text
                parm_coll1(1) = New OracleParameter
                parm_coll1(1).ParameterName = "ph"
                parm_coll1(1).OracleType = OracleType.Blob
                parm_coll1(1).Direction = ParameterDirection.Input
                parm_coll1(1).Value = image1
                oh.ExecuteNonQuery(sql, parm_coll1)
            ElseIf int3 = 1 And int4 = 1 Then
                sql = "update dms.hrm_emp_ph_certi h set h.photo= :ph,h.certificate=:certi where h.emp_code=:code"
                Dim parm_coll1(2) As OracleParameter
                parm_coll1(0) = New OracleParameter
                parm_coll1(0).ParameterName = "code"
                parm_coll1(0).OracleType = OracleType.Number
                parm_coll1(0).Direction = ParameterDirection.Input
                parm_coll1(0).Value = Me.TextBox1.Text
                parm_coll1(1) = New OracleParameter
                parm_coll1(1).ParameterName = "ph"
                parm_coll1(1).OracleType = OracleType.Blob
                parm_coll1(1).Direction = ParameterDirection.Input
                parm_coll1(1).Value = image1
                parm_coll1(2) = New OracleParameter
                parm_coll1(2).ParameterName = "certi"
                parm_coll1(2).OracleType = OracleType.Blob
                parm_coll1(2).Direction = ParameterDirection.Input
                parm_coll1(2).Value = image2
                oh.ExecuteNonQuery(sql, parm_coll1)
            End If
        Catch ex As Exception
            Response.Write(ex.Message.ToString)
        End Try
        Dim cl_scriptp As New StringBuilder
        cl_scriptp.Append("   alert(' Successfully Done!!') ;")
        cl_scriptp.Append("window.open('hrm_emp_image_update.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scriptp.ToString, True)
    End Sub
    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim st As DataTable = oh.ExecuteDataSet("select count(*) from dms.hrm_emp_ph_certi t where emp_code=" & Me.hid3.Value).Tables(0)
    '    If st.Rows(0)(0) > 0 Then
    '        Dim dt As DataTable = oh.ExecuteDataSet("select photo as imag from dms.hrm_emp_ph_certi t where emp_code=" & Me.hid3.Value).Tables(0)
    '        If Not IsDBNull(dt.Rows(0)(0)) Then
    '            Me.Response.Redirect("view_emp_photo.aspx?empcode=" & Me.hid3.Value & "@1")
    '        End If
    '    End If
    'End Sub
    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Dim st As DataTable = oh.ExecuteDataSet("select count(*) from dms.hrm_emp_ph_certi t where emp_code=" & Me.hid3.Value).Tables(0)
    '    If st.Rows(0)(0) > 0 Then
    '        Dim dt As DataTable = oh.ExecuteDataSet("select certificate as imag from dms.hrm_emp_ph_certi t where emp_code=" & Me.hid3.Value).Tables(0)
    '        If Not IsDBNull(dt.Rows(0)(0)) Then
    '            Me.Response.Redirect("view_emp_photo.aspx?empcode=" & Me.hid3.Value & "@1")
    '        End If
    '    End If
    'End Sub
    Protected Sub btn_Ok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Ok.Click
        'If Not IsPostBack Then
        Me.hid3.Value = Me.TextBox1.Text
        Me.hid2.Value = 0
        int3 = int4 = 0
        Dim sql As String = "select count(*) from dms.hrm_emp_ph_certi where emp_code=" & Me.TextBox1.Text
        Dim stable As Integer = oh.ExecuteDataSet(Sql).Tables(0).Rows(0)(0)
        If stable > 0 Then
            'sql = "select qc.category,qm.qualification,e.qualification,e.marks,e.total,e.photo,e.certificate from dms.hrm_emp_ph_certi e,qualification_master qm,qualification_category qc where emp_code=" & Me.TextBox1.Text & " and e.qualification=qm.qualification_id and qm.category_id=qc.category_id"
            sql = "select qc.category,qm.qualification,e.qualification,e.marks,e.total,e.photo,e.certificate from dms.hrm_emp_ph_certi e,qualification_master qm,qualification_category qc where emp_code=" & Me.TextBox1.Text & " and e.qualification=qm.qualification_id and qm.category_id=qc.category_id"
            Dim pq As DataTable = oh.ExecuteDataSet(Sql).Tables(0)
            Me.txt_category.Value = pq.Rows(0)(1)
            Me.txt_qualification.Value = pq.Rows(0)(0)
            Me.hid1.Value = pq.Rows(0)(2)
            Me.txt_total.Text = pq.Rows(0)(4)
            Me.txt_marks.Text = pq.Rows(0)(3)
            Me.txt_marks.ReadOnly = True
            Me.txt_total.ReadOnly = True
            If Not IsDBNull(pq.Rows(0)(5)) And IsDBNull(pq.Rows(0)(6)) Then
                'Me.FileUpload1.Enabled = False
                Me.hid2.Value = 1
            End If
            If Not IsDBNull(pq.Rows(0)(6)) And IsDBNull(pq.Rows(0)(5)) Then
                'Me.FileUpload2.Enabled = False
                Me.hid2.Value = 2
            End If
            If Not IsDBNull(pq.Rows(0)(5)) And Not IsDBNull(pq.Rows(0)(6)) Then
                Me.hid2.Value = 3
            End If
        End If
        sql = "select a.qualification,c.category,b.qualification,nvl(b.percentage,0) from employ_qualification_dtl b,qualification_master a,qualification_category c where a.qualification_id=b.qualification and a.category_id=c.category_id and (b.emp_code,b.year_pass) in (select distinct emp_code,max(year_pass) from employ_qualification_dtl group by emp_code) and emp_code=" & Me.TextBox1.Text & " and a.category_id in (select a.category_id from employ_qualification_dtl b,qualification_master a where a.qualification_id=b.qualification and b.emp_code=" & Me.TextBox1.Text & ")"
        Dim dt As DataTable = oh.ExecuteDataSet(sql).Tables(0)
        Me.txt_category.Value = dt.Rows(0)(1)
        Me.txt_qualification.Value = dt.Rows(0)(0)
        Me.hid1.Value = dt.Rows(0)(2)
        ' End If
    End Sub
End Class
