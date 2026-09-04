Imports System.IO
Imports SD = System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Text
Imports GemBox.Document
Imports System.Data

Public Class _Default
    Inherits System.Web.UI.Page
    Dim path As String = (HttpContext.Current.Request.PhysicalApplicationPath + "images\")
    Dim url1 As String
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dts As DataTable = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=5224 and s.emp_id=" & Session("user_id").ToString.Split("!")(0) & "").Tables(0)
            If (dts.Rows(0)(0) = 0) Then
                Server.Transfer("../show_err.aspx")
            End If
            Session("imgurl") = "NO"
            Me.Button1.Visible = False
            Dim dt1 As DataTable = oh.ExecuteDataSet("select '---SELECT EMPLOYEE---' a,0 b from dual union all select e.emp_code||'-'||e.emp_name, e.emp_code from employee_master e,employ_firm f where e.emp_code=f.emp_code and f.firm_id= " & Session("firm_id") & " and e.status_id=1 and e.emp_code>9999 order by b").Tables(0)
            Me.mydrop.DataSource = dt1
            Me.mydrop.DataTextField = dt1.Columns(0).ColumnName
            Me.mydrop.DataValueField = dt1.Columns(1).ColumnName
            Me.mydrop.DataBind()
        End If
    End Sub
    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Dim FileOK As Boolean = False
        Dim FileSaved As Boolean = False
        imgCrop.ImageUrl = Nothing
        If Upload.HasFile Then
            Session("WorkingImage") = Upload.FileName
            Dim FileExtension As String = System.IO.Path.GetExtension(Session("WorkingImage").ToString).ToLower
            Dim allowedExtensions() As String = New String() {".png", ".jpeg", ".jpg", ".gif"}
            Dim i As Integer = 0
            Do While (i < allowedExtensions.Length)
                If (FileExtension = allowedExtensions(i)) Then
                    FileOK = True
                End If

                i = (i + 1)
            Loop

        End If

        If FileOK Then
            Try
                Me.mypanel.Visible = False
                Me.Button1.Visible = False
                Me.mydrop.Enabled = False
                Upload.PostedFile.SaveAs((path + Session("WorkingImage")))
                FileSaved = True
            Catch ex As Exception
                lblError.Text = ("File could not be uploaded." + ex.Message.ToString)
                lblError.Visible = True
                FileSaved = False
            End Try

        Else
            'lblError.Text = "Cannot accept files of this type."
            'lblError.Visible = True
            If mydrop.SelectedValue = 0 Or mydrop.SelectedValue Is Nothing Or IsDBNull(mydrop.SelectedValue) Then
                Dim cl_scripts As New StringBuilder
                cl_scripts.Append("   alert(' Choose Any Employee !!') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scripts.ToString, True)
                Exit Sub
            End If
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('Please Upload An Image File(.png/.jpeg/.jpg/.gif) !!') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub
        End If

        If FileSaved Then
            'pnlUpload.Visible = False
            pnlCrop.Visible = True
            imgCrop.ImageUrl = ("../images/" + Session("WorkingImage").ToString)

            Dim fs As Stream = Upload.PostedFile.InputStream
            Dim br As BinaryReader = New BinaryReader(fs)
            Dim bytes = br.ReadBytes(fs.Length)
            Dim base64String = Convert.ToBase64String(bytes, 0, bytes.Length)
            Session("imgurl") = "data:image/png;base64," & base64String
        End If
    End Sub

    Protected Sub btnCrop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCrop.Click
        Dim ImageName As String = Session("WorkingImage").ToString
        If (Me.W.Value = "" Or IsDBNull(Me.W.Value)) Or (Me.H.Value = "" Or IsDBNull(Me.H.Value)) Or (Me.X.Value = "" Or IsDBNull(Me.X.Value)) Or (Me.Y.Value = "" Or IsDBNull(Me.Y.Value)) Then
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('Please Crop The Image Using Cursor!!') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub
        End If
        Dim w As Integer = Convert.ToInt32(Me.W.Value)
        Dim h As Integer = Convert.ToInt32(Me.H.Value)
        Dim x As Integer = Convert.ToInt32(Me.X.Value)
        Dim y As Integer = Convert.ToInt32(Me.Y.Value)
        Dim CropImage() As Byte = Crop((path + ImageName), w, h, x, y)
        Dim ms As MemoryStream = New MemoryStream(CropImage, 0, CropImage.Length)
        ms.Write(CropImage, 0, CropImage.Length)
        Dim CroppedImage As SD.Image = SD.Image.FromStream(ms, True)
        Dim SaveTo As String = (path + ("crop" + ImageName))
        CroppedImage.Save(SaveTo, CroppedImage.RawFormat)
        pnlCrop.Visible = False
        pnlCropped.Visible = True
        imgCropped.ImageUrl = ("../images/crop" + ImageName)
        Dim bytesu() As Byte = CType(CropImage, Byte())
        url1 = "data:image/png;base64," + Convert.ToBase64String(bytesu, 0, bytesu.Length)
        Session("imgurl") = url1
        Me.Button1.Visible = True
        'Dim dt As DataTable = oh.ExecuteDataSet("select t.emp_name,t.emp_code,decode(bg.blood_type,'O +','O+Ve','O -','O-Ve','A +','A+Ve','A -','A-Ve','B +','B+Ve','B -','B-Ve','AB +','AB+Ve','AB -','AB-Ve') from mactech.employee_master t,mactech.employ_personal_dtl pd,mactech.bloodgroup_master bg where bg.blood_id=pd.blood_id and pd.emp_code=t.emp_code and t.emp_code=100053").Tables(0)
        'Dim FilePath, source, fold As String
        'fold = Server.MapPath("~/files/1.html")
        'source = Server.MapPath("~/files/")
        'File.Copy(fold, System.IO.Path.Combine(source, System.IO.Path.GetFileName("2.html")), True)
        'FilePath = Server.MapPath("~/files/2.html")
        'IO.File.WriteAllText(FilePath, IO.File.ReadAllText(FilePath).Replace("myname", dt.Rows(0)(0)))
        'IO.File.WriteAllText(FilePath, IO.File.ReadAllText(FilePath).Replace("myblood", dt.Rows(0)(2)))
        'IO.File.WriteAllText(FilePath, IO.File.ReadAllText(FilePath).Replace("mycode", dt.Rows(0)(1)))
        'IO.File.WriteAllText(FilePath, IO.File.ReadAllText(FilePath).Replace("mysrc", url1))
        'ComponentInfo.SetLicense("FREE-LIMITED-KEY")
        ''Dim document As DocumentModel = DocumentModel.Load(Server.MapPath("~/files/new text document.html"))
        'Dim document As DocumentModel = DocumentModel.Load(FilePath)
        'Dim pageSetup = document.Sections(0).PageSetup
        'pageSetup.PageWidth = 151
        'pageSetup.PageHeight = 242.9
        'pageSetup.PageMargins.Left = 0
        'pageSetup.PageMargins.Right = 0
        'pageSetup.PageMargins.Top = 0
        'pageSetup.PageMargins.Bottom = -10
        'Using memoryStream As MemoryStream = New MemoryStream()
        '    document.Save(memoryStream, GemBox.Document.SaveOptions.PdfDefault)
        '    Dim bytes As Byte() = memoryStream.ToArray()
        '    memoryStream.Close()
        '    'Dim testFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "testitext.pdf")
        '    'File.WriteAllBytes(testFile, bytes)
        '    Response.Clear()
        '    Response.Buffer = True
        '    Response.ContentType = "application/pdf"
        '    Response.BinaryWrite(bytes)
        '    Response.End()
        'End Using
    End Sub
    Private Shared Function Crop(ByVal Img As String, ByVal Width As Integer, ByVal Height As Integer, ByVal X As Integer, ByVal Y As Integer) As Byte()
        Try
            Dim OriginalImage As SD.Image = SD.Image.FromFile(Img)
            Dim bmp As SD.Bitmap = New SD.Bitmap(Width, Height)
            bmp.SetResolution(OriginalImage.HorizontalResolution, OriginalImage.VerticalResolution)
            Dim Graphic As SD.Graphics = SD.Graphics.FromImage(bmp)
            Graphic.SmoothingMode = SmoothingMode.AntiAlias
            Graphic.InterpolationMode = InterpolationMode.HighQualityBicubic
            Graphic.PixelOffsetMode = PixelOffsetMode.HighQuality
            Graphic.DrawImage(OriginalImage, New SD.Rectangle(0, 0, Width, Height), X, Y, Width, Height, SD.GraphicsUnit.Pixel)
            Dim ms As MemoryStream = New MemoryStream
            bmp.Save(ms, OriginalImage.RawFormat)
            Return ms.GetBuffer
        Catch Ex As Exception
            Throw
        End Try
    End Function

    Protected Sub retry_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles retry.Click
        pnlCrop.Visible = True
        pnlCropped.Visible = False
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If mydrop.SelectedValue = 0 Or mydrop.SelectedValue Is Nothing Or IsDBNull(mydrop.SelectedValue) Then
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert(' Choose Any Employee !!') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub
        End If
        If (Not Upload.HasFile) AndAlso (IsDBNull(Session("imgurl")) Or Session("imgurl").ToString = "NO") Then
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('Please Upload An Image File(.png/.jpeg/.jpg/.gif) !!') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub
        End If

        If (IsDBNull(Session("imgurl")) Or Session("imgurl").ToString = "NO") Then
            Dim fs As Stream = Upload.PostedFile.InputStream
            Dim br As BinaryReader = New BinaryReader(fs)
            Dim bytes1 = br.ReadBytes(fs.Length)
            Dim base64String = Convert.ToBase64String(bytes1, 0, bytes1.Length)
            Session("imgurl") = "data:image/png;base64," & base64String
        End If


        'Dim dt As DataTable = oh.ExecuteDataSet("select t.emp_name,t.emp_code,decode(bg.blood_type,'O +','O+Ve','O -','O-Ve','A +','A+Ve','A -','A-Ve','B +','B+Ve','B -','B-Ve','AB +','AB+Ve','AB -','AB-Ve') from mactech.employee_master t,mactech.employ_personal_dtl pd,mactech.bloodgroup_master bg where bg.blood_id=pd.blood_id and pd.emp_code=t.emp_code and t.emp_code=" & mydrop.SelectedValue & "").Tables(0)


        Dim dt As DataTable = oh.ExecuteDataSet("SELECT t.emp_name, t.emp_code, pd.res_phone, /* bg.blood_type,*/ pd.birth_date, t.join_dt, pd.perm_add1 || ' ' || p.post_office || ', ' || d.district_name || ', ' || s.state_name || ' - ' || p.pin_code, DECODE(bg.blood_type, 'O +', 'O+Ve', 'O -', 'O-Ve', 'A +', 'A+Ve', 'A -', 'A-Ve', 'B +', 'B+Ve', 'B -', 'B-Ve', 'AB +', 'AB+Ve', 'AB -', 'AB-Ve') AS blood_type FROM mactech.employee_master t JOIN mactech.employ_personal_dtl pd ON pd.emp_code = t.emp_code JOIN mactech.bloodgroup_master bg ON bg.blood_id = pd.blood_id JOIN mactech.firm_master fm ON fm.firm_id = t.firm_id join mactech.post_master p on p.sr_number = pd.perm_pin join mactech.district_master d on d.district_id = p.district_id join mactech.state_master s on s.state_id = d.state_id WHERE t.emp_code =" & mydrop.SelectedValue & "").Tables(0)





        If dt.Rows.Count <= 0 Then
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('Incomplete Data Found For This Employee !!') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub
        End If
        Dim FilePath, source, fold As String
        fold = Server.MapPath("~/files/1.html")
        source = Server.MapPath("~/files/")
        File.Copy(fold, System.IO.Path.Combine(source, System.IO.Path.GetFileName("2.html")), True)
        FilePath = Server.MapPath("~/files/2.html")
        IO.File.WriteAllText(FilePath, IO.File.ReadAllText(FilePath).Replace("myname", dt.Rows(0)(0)))
        IO.File.WriteAllText(FilePath, IO.File.ReadAllText(FilePath).Replace("myblood", dt.Rows(0)(6)))
        IO.File.WriteAllText(FilePath, IO.File.ReadAllText(FilePath).Replace("mycode", dt.Rows(0)(1)))
        IO.File.WriteAllText(FilePath, IO.File.ReadAllText(FilePath).Replace("mysrc", Session("imgurl").ToString))


        IO.File.WriteAllText(FilePath, IO.File.ReadAllText(FilePath).Replace("mycontact", dt.Rows(0)(2)))
        IO.File.WriteAllText(FilePath, IO.File.ReadAllText(FilePath).Replace("mydob", dt.Rows(0)(3)))
        IO.File.WriteAllText(FilePath, IO.File.ReadAllText(FilePath).Replace("mydoj", dt.Rows(0)(4)))


        IO.File.WriteAllText(FilePath, IO.File.ReadAllText(FilePath).Replace("myaddress", dt.Rows(0)(5)))
        'IO.File.WriteAllText(FilePath, IO.File.ReadAllText(FilePath).Replace("mystate", dt.Rows(0)(6)))




        'IO.File.WriteAllText(FilePath, IO.File.ReadAllText(FilePath).Replace("", dt.Rows(0)(1)))





        ComponentInfo.SetLicense("FREE-LIMITED-KEY")
        'Dim document As DocumentModel = DocumentModel.Load(Server.MapPath("~/files/new text document.html"))
        Dim document As DocumentModel = DocumentModel.Load(FilePath)
        Dim pageSetup = document.Sections(0).PageSetup
        pageSetup.PageWidth = 151
        pageSetup.PageHeight = 242.9
        pageSetup.PageMargins.Left = 0
        pageSetup.PageMargins.Right = 0
        pageSetup.PageMargins.Top = 0
        pageSetup.PageMargins.Bottom = -10
        'If File.Exists(path + ("crop" + Session("WorkingImage").ToString)) Then
        '    File.Delete(path + ("crop" + Session("WorkingImage").ToString))
        'End If
        'If File.Exists(path + (Session("WorkingImage").ToString)) Then
        '    File.Delete(path + (Session("WorkingImage").ToString))
        'End If
        Using memoryStream As MemoryStream = New MemoryStream()
            document.Save(memoryStream, GemBox.Document.SaveOptions.PdfDefault)
            Dim bytes As Byte() = memoryStream.ToArray()
            memoryStream.Close()
            'Dim testFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "testitext.pdf")
            'File.WriteAllBytes(testFile, bytes)
            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "application/pdf"
            Response.BinaryWrite(bytes)
            Response.End()
        End Using
    End Sub

End Class
