Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Imports System.Security.Cryptography
Partial Class Leave_Module_leave_applied_status_3f8d0f7a8364
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt1 As New DataTable
    Dim fir As Integer
    Dim firm As String
    Dim fmid As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        hdnEdata.Value = "8080808080808080"
        fir = Session("firm_id")
        firm = Session("firm_name")
        Dim cs As String = "var cont_name;cont_name='" & Me.cmb_code.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "LEAVE APPLIED STATUS"
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        dt1 = oh.ExecuteDataSet("select ef.firm_id from employee_master e,employ_firm ef where ef.emp_code=e.emp_code and e.emp_code=" & user(0) & "").Tables(0)
        fmid = dt1.Rows(0)(0)
        If fmid <> fir Then
            Response.Redirect("../show_err.aspx")
        End If
        If Not IsPostBack Then
            'Session("user_id") = "31039!123"
            Dim sql As String = "select distinct e.emp_code, e.emp_code || ' - ' || e.emp_name  from employee_master e,employ_firm ef  where e.emp_code = " & user(0) & "  and ef.firm_id=" & fir & "  and ef.emp_code=e.emp_code"
            Dim dt As DataTable = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows.Count > 0 Then
                Me.cmb_code.DataSource = dt
                Me.cmb_code.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_code.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_code.DataBind()
                Me.txt_from.Text = Format(CDate("1 / JAN / 2010"), "dd/MMM/yyyy")
                Me.txt_to.Text = Format(Now.Date, "dd/MMM/yyyy")
            End If
        End If
        Me.txt_from.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_from')")
        Me.txt_to.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_to')")

    End Sub
    'Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
    '    If Session("firm_id") = 2 Then
    '        Me.Response.Redirect("rpt_leave_applied_status_new.aspx?empcode=" & Me.cmb_code.SelectedValue & "&fromdt=" & Me.txt_from.Text & "&todt=" & Me.txt_to.Text)
    '    Else
    '        Me.Response.Redirect("rpt_leave_applied_status.aspx?empcode=" & Me.cmb_code.SelectedValue & "&fromdt=" & Me.txt_from.Text & "&todt=" & Me.txt_to.Text)
    '    End If
    'End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Context.Items("empcode") = hdnSelectedEmp.Value

        Context.Items("fromdt") = Me.txt_from.Text
        Context.Items("todt") = Me.txt_to.Text

        If Session("firm_id") = 2 Then
            Server.Transfer("rpt_leave_applied_status_new.aspx")
        Else
            Server.Transfer("rpt_leave_applied_status.aspx")
        End If
    End Sub

#Region "Encryption"
    Public Shared Function DecryptStringAES(cipherText As String) As String
        Dim keybytes As Byte() = Encoding.UTF8.GetBytes("8080808080808080")
        Dim iv As Byte() = Encoding.UTF8.GetBytes("8080808080808080")

        Dim encrypted As Byte() = Convert.FromBase64String(cipherText)
        Dim decriptedFromJavascript As String = DecryptStringFromBytes(encrypted, keybytes, iv)

        Return String.Format("{0}", decriptedFromJavascript)
    End Function
    Private Shared Function DecryptStringFromBytes(cipherText As Byte(), key As Byte(), iv As Byte()) As String
        ' Check arguments.
        If cipherText Is Nothing OrElse cipherText.Length <= 0 Then
            Throw New ArgumentNullException("cipherText")
        End If
        If key Is Nothing OrElse key.Length <= 0 Then
            Throw New ArgumentNullException("key")
        End If
        If iv Is Nothing OrElse iv.Length <= 0 Then
            Throw New ArgumentNullException("key")
        End If

        ' Declare the string used to hold the decrypted text.
        Dim plaintext As String = Nothing

        ' Create a RijndaelManaged object with the specified key and IV.
        Using rijAlg As New RijndaelManaged()
            ' Settings
            rijAlg.Mode = CipherMode.CBC
            rijAlg.Padding = PaddingMode.PKCS7
            rijAlg.FeedbackSize = 128

            rijAlg.Key = key
            rijAlg.IV = iv

            ' Create a decryptor to perform the stream transform.
            Dim decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV)
            Try
                ' Create the streams used for decryption.
                Using msDecrypt As New MemoryStream(cipherText)
                    Using csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)
                        Using srDecrypt As New StreamReader(csDecrypt)
                            ' Read the decrypted bytes from the decrypting stream and place them in a string.
                            plaintext = srDecrypt.ReadToEnd()
                        End Using
                    End Using
                End Using
            Catch
                plaintext = "keyError"
            End Try
        End Using

        Return plaintext
    End Function

#End Region



End Class
