Imports System.Data
Imports System.Data.OracleClient
Partial Class payroll_Posting_newapplnexp_e9d240db4065
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim ww As Integer
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            applnfill()
            fillqualification()
        End If
    End Sub
    Sub fillqualification()
        dt = oh.ExecuteDataSet("select qualification_id,qualification,category_id from qualification_master order by qualification").Tables(0)
        Me.cmb_qualification.DataSource = dt
        Me.cmb_qualification.DataTextField = dt.Columns(1).ColumnName
        Me.cmb_qualification.DataValueField = dt.Columns(0).ColumnName
        Me.cmb_qualification.DataBind()
    End Sub

    Protected Sub cmd_add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_add.Click
        Dim qual As New Table
        'checkdup(hd_qual, cmb_qualification)
        'If ww = 1 Then
        If Me.txt_institution.Text <> "" Then
            If Me.txt_university.Text <> "" Then
                If Me.txt_percentage.Text <> "" Then
                    If Me.txt_passyear.Text <> "" Then
                        Me.hd_qual.Value = Me.hd_qual.Value + Me.cmb_qualification.SelectedValue & "^" & Me.txt_institution.Text & "^" & Me.txt_university.Text & "^" & Me.txt_percentage.Text & "^" & Me.txt_passyear.Text + "#"
                    End If
                End If
            End If
        End If
        'Else
        'Me.lbl_err.Text = "Allready added"
        'End If

        qual.Attributes.Add("align", "center")
        qual.Attributes.Add("width", "60%")
        qual.Attributes.Add("border", "1")
        Dim t As New TableRow
        Dim td1, td2, td3, td4, td5 As New TableCell

        td1.Text = "Qualification"
        td1.ColumnSpan = 5
        t.Cells.Add(td1)
        ' tr.ID = "a1"
        td2.Text = "Institution"
        td2.ColumnSpan = 1
        t.Cells.Add(td2)
        td3.Text = "University"
        td3.ColumnSpan = 1
        t.Cells.Add(td3)
        td4.Text = "Percentage"
        td4.ColumnSpan = 1
        t.Cells.Add(td4)
        td5.Text = "Year Of Passing"
        td5.ColumnSpan = 1
        t.Cells.Add(td5)
        qual.Rows.Add(t)
        Dim st As String
        st = Me.hd_qual.Value
        If st <> "" Then
            Dim str() As String
            str = st.Split("#")

            Dim tr() As String
            Dim i As Integer

            For i = 0 To str.Length - 1

                If str(i) <> "" Then
                    tr = str(i).Split("^")

                    Dim tr1 As New TableRow
                    Dim tc4, tc5, tc6, tc7, tc8, tc9 As New TableCell
                    Dim dt As New DataTable
                    Dim oh As New Helper.Oracle.OracleHelper
                    dt = oh.ExecuteDataSet("select qualification from qualification_master where qualification_id=" & tr(0) & "").Tables(0)
                    tc4.ColumnSpan = 5
                    tc4.Text = "<font size=3>" & dt.Rows(0)(0) & "</font>"
                    tc5.ColumnSpan = 1
                    tc5.Text = "<font size=3>" & tr(1) & "</font>"
                    tc6.ColumnSpan = 1
                    tc6.Text = "<font size=3>" & tr(2) & "</font>"
                    tc7.ColumnSpan = 1
                    tc7.Text = "<font size=3>" & tr(3) & "</font>"
                    tc8.ColumnSpan = 1
                    tc8.Text = "<font size=3>" & tr(4) & "</font>"
                    tr1.Controls.Add(tc4)
                    tr1.Controls.Add(tc5)
                    tr1.Controls.Add(tc6)
                    tr1.Controls.Add(tc7)
                    tr1.Controls.Add(tc8)
                    qual.Controls.Add(tr1)
                End If
            Next
        End If

        pnl_qual.Controls.Add(qual)

        Me.txt_institution.Text = ""
        Me.txt_university.Text = ""
        Me.txt_passyear.Text = ""
        Me.txt_percentage.Text = ""

    End Sub
    Sub checkdup(ByVal a As HiddenField, ByVal b As DropDownList)
        Dim qq As Integer
        Dim qstr() As String
        Dim qstr1() As String
        If a.Value = "" Then
            If Me.txt_institution.Text <> "" Then
                If Me.txt_university.Text <> "" Then
                    If Me.txt_percentage.Text <> "" Then
                        If Me.txt_passyear.Text <> "" Then
                            Me.hd_qual.Value = Me.hd_qual.Value + Me.cmb_qualification.SelectedValue & "^" & Me.txt_institution.Text & "^" & Me.txt_university.Text & "^" & Me.txt_percentage.Text & "^" & Me.txt_passyear.Text + "#"
                        End If
                    End If
                End If
            End If
        Else
            qstr = a.Value.Split("#")
            For qq = 0 To qstr.Length - 1
                qstr1 = qstr(qq).Split("^")
                If qstr1(0) = b.SelectedValue Or qstr1(0) = "" Then
                    ww = 1
                Else
                    If Me.txt_institution.Text <> "" Then
                        If Me.txt_university.Text <> "" Then
                            If Me.txt_percentage.Text <> "" Then
                                If Me.txt_passyear.Text <> "" Then
                                    Me.hd_qual.Value = Me.hd_qual.Value + Me.cmb_qualification.SelectedValue & "^" & Me.txt_institution.Text & "^" & Me.txt_university.Text & "^" & Me.txt_percentage.Text & "^" & Me.txt_passyear.Text + "#"
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        End If
    End Sub

    Protected Sub cmd_addexp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_addexp.Click
        If Me.txt_orgnization.Text <> "" And Me.txt_designation.Text <> "" And Me.txt_dutynature.Text <> "" And Me.txt_presalary.Text <> "" And Me.txt_expfrom.Text <> "" And Me.txt_expto.Text <> "" And Me.txt_cperson.Text <> "" And Me.txt_cphoneno.Text <> "" And Me.txt_reason.Text <> "" Then
            Me.hd_exp.Value = Me.hd_exp.Value + Me.txt_orgnization.Text & "~" & Me.txt_designation.Text & "~" & Me.txt_dutynature.Text & "~" & Me.txt_presalary.Text & "~" & Me.txt_expfrom.Text & "~" & Me.txt_expto.Text & "~" & Me.txt_cperson.Text & "~" & Me.txt_cphoneno.Text & "~" & Me.txt_reason.Text + "!"
        End If
        Dim exp As New Table
        exp.Attributes.Add("align", "center")
        exp.Attributes.Add("width", "60%")
        exp.Attributes.Add("border", "1")
        Dim t As New TableRow
        Dim td1, td2, td3, td4, td5, td6, td7, td8 As New TableCell
        td1.Text = "Organization"
        td1.ColumnSpan = 1
        t.Cells.Add(td1)
        ' tr.ID = "a1"
        td2.Text = "Designation"
        td2.ColumnSpan = 1
        t.Cells.Add(td2)
        td3.Text = "Nature of Duty"
        td3.ColumnSpan = 1
        t.Cells.Add(td3)
        td4.Text = "Present Salary"
        td4.ColumnSpan = 1
        t.Cells.Add(td4)
        td5.Text = "Period"
        td5.ColumnSpan = 1
        t.Cells.Add(td5)
        td6.Text = "Contact Person"
        td6.ColumnSpan = 1
        t.Cells.Add(td6)
        td7.Text = "Contact Phone No"
        td7.ColumnSpan = 1
        t.Cells.Add(td7)
        td8.Text = "Releaving Reason"
        td8.ColumnSpan = 1
        t.Cells.Add(td8)
        exp.Rows.Add(t)

        Dim st As String
        st = Me.hd_exp.Value
        If st <> "" Then
            Dim str() As String
            str = st.Split("!")

            Dim tr() As String
            Dim i As Integer

            For i = 0 To str.Length - 1

                If str(i) <> "" Then
                    tr = str(i).Split("~")

                    Dim tr1 As New TableRow
                    Dim tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9 As New TableCell
                    Dim dt As New DataTable
                    Dim oh As New Helper.Oracle.OracleHelper
                    tc1.ColumnSpan = 1
                    tc1.Text = "<font size=3>" & tr(0) & "</font>"
                    tc2.ColumnSpan = 1
                    tc2.Text = "<font size=3>" & tr(1) & "</font>"
                    tc3.ColumnSpan = 1
                    tc3.Text = "<font size=3>" & tr(2) & "</font>"
                    tc4.ColumnSpan = 1
                    tc4.Text = "<font size=3>" & tr(3) & "</font>"
                    tc5.ColumnSpan = 1
                    tc5.Text = "<font size=3>" & tr(4) & "to" & tr(5) & "</font>"
                    tc6.ColumnSpan = 1
                    tc6.Text = "<font size=3>" & tr(6) & "</font>"
                    tc7.ColumnSpan = 1
                    tc7.Text = "<font size=3>" & tr(7) & "</font>"
                    tc8.ColumnSpan = 1
                    tc8.Text = "<font size=3>" & tr(8) & "</font>"
                    tr1.Controls.Add(tc1)
                    tr1.Controls.Add(tc2)
                    tr1.Controls.Add(tc3)
                    tr1.Controls.Add(tc4)
                    tr1.Controls.Add(tc5)
                    tr1.Controls.Add(tc6)
                    tr1.Controls.Add(tc7)
                    tr1.Controls.Add(tc8)
                    exp.Controls.Add(tr1)
                End If
            Next
        End If
        pnl_exp.Controls.Add(exp)
        Me.txt_orgnization.Text = ""
        Me.txt_designation.Text = ""
        Me.txt_dutynature.Text = ""
        Me.txt_presalary.Text = ""
        Me.txt_expfrom.Text = ""
        Me.txt_expto.Text = ""
        Me.txt_cperson.Text = ""
        Me.txt_cphoneno.Text = ""
        Me.txt_reason.Text = ""
    End Sub

    Protected Sub txt_applnno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_applnno.TextChanged
        Dim d, d1, d2 As New DataTable
        Me.lbl_err.Text = " "
        Me.txt_cname.Text = ""
        d = oh.ExecuteDataSet("select appln_name from appln_pers_dtl where appln_no=" & Me.txt_applnno.Text).Tables(0)
        If d.Rows.Count > 0 Then
            d1 = oh.ExecuteDataSet("select * from appln_qualif_dtl  a where a.appln_no=" & Me.txt_applnno.Text).Tables(0)
            d2 = oh.ExecuteDataSet("select * from appln_exp_dtl b where b.appln_no=" & Me.txt_applnno.Text).Tables(0)
            If d1.Rows.Count > 0 Or d2.Rows.Count > 0 Then
                Me.lbl_err.Text = " Application Already added"
                Me.lbl_err.Font.Bold = True
                Me.lbl_err.ForeColor = Drawing.Color.Red
            Else
                Me.txt_cname.Text = d.Rows(0)(0)
            End If
        Else
            Me.lbl_err.Text = " Application No " + Me.txt_applnno.Text + "does not exist"
            Me.lbl_err.Font.Bold = True
            Me.lbl_err.ForeColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If Me.txt_applnno.Text <> "" And Me.hd_qual.Value <> "" Then
            Dim oh As New Helper.Oracle.OracleHelper
            Dim op(3) As OracleParameter
            op(0) = New OracleParameter("c_appln", OracleType.Number, 8)
            op(0).Value = Me.txt_applnno.Text
            op(0).Direction = ParameterDirection.Input

            op(1) = New OracleParameter("c_qual", OracleType.VarChar, 500)
            op(1).Value = Me.hd_qual.Value
            op(1).Direction = ParameterDirection.Input

            op(2) = New OracleParameter("c_exp", OracleType.VarChar, 500)
            op(2).Value = Me.hd_exp.Value
            op(2).Direction = ParameterDirection.Input

            op(3) = New OracleParameter("userid", OracleType.VarChar, 25)
            op(3).Value = Session("user_id")
            op(3).Direction = ParameterDirection.Input

            oh.ExecuteNonQuery("new_qualifexp", op)
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' Sucessfully Confirmed Appln No: " & op(0).Value & "');")
            cl_script0.Append("       window.open('newappln_otherdtl.aspx?appno=" & op(0).Value & "','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' Did U filled the Necessary Columns')")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        End If
    End Sub
    Sub applnfill()
        Me.txt_applnno.Text = Request.QueryString.Get("appno")
        Dim d, d1, d2 As New DataTable
        Me.lbl_err.Text = " "
        Me.txt_cname.Text = ""
        d = oh.ExecuteDataSet("select appln_name from appln_pers_dtl where appln_no=" & Me.txt_applnno.Text).Tables(0)
        If d.Rows.Count > 0 Then
            d1 = oh.ExecuteDataSet("select * from appln_qualif_dtl  a where a.appln_no=" & Me.txt_applnno.Text).Tables(0)
            d2 = oh.ExecuteDataSet("select * from appln_exp_dtl b where b.appln_no=" & Me.txt_applnno.Text).Tables(0)
            If d1.Rows.Count > 0 Or d2.Rows.Count > 0 Then
                Me.lbl_err.Text = " Application Already added"
                Me.lbl_err.Font.Bold = True
                Me.lbl_err.ForeColor = Drawing.Color.Red
            Else
                Me.txt_cname.Text = d.Rows(0)(0)
            End If
        Else
            Me.lbl_err.Text = " Application No " + Me.txt_applnno.Text + "does not exist"
            Me.lbl_err.Font.Bold = True
            Me.lbl_err.ForeColor = Drawing.Color.Red
        End If

    End Sub
End Class

