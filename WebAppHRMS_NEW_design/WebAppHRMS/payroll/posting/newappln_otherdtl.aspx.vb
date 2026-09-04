Imports System.Data.OracleClient
Imports System.Data
Partial Class payroll_Posting_newappln_otherdtl_e872bd665844
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub txt_applnno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        applnfill()
    End Sub
    Sub applnfill()
        Me.txt_applnno.Text = Request.QueryString.Get("appno")
        Dim d, d1 As New DataTable
        Me.lbl_err.Text = " "
        Me.txt_cname.Text = ""
        d = oh.ExecuteDataSet("select appln_name from appln_pers_dtl a,appln_qualif_dtl b where  a.appln_no=b.appln_no and a.appln_no=" & Me.txt_applnno.Text).Tables(0)
        If d.Rows.Count > 0 Then
            d1 = oh.ExecuteDataSet("select * from appln_other_dtl  a where a.appln_no=" & Me.txt_applnno.Text).Tables(0)
            If d1.Rows.Count > 0 Then
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

    Protected Sub chk_relative_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_relative.CheckedChanged
        If Me.chk_relative.Checked = True Then
            Me.txt_empname.Enabled = True
            Me.txt_emprel.Enabled = True
        Else
            Me.txt_empname.Enabled = False
            Me.txt_emprel.Enabled = False
        End If
    End Sub

    Protected Sub chk_dir_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_dir.CheckedChanged
        If Me.chk_relative.Checked = True Then
            Me.txt_dirname.Enabled = True
            Me.txt_dirprel.Enabled = True
        Else
            Me.txt_dirname.Enabled = False
            Me.txt_dirprel.Enabled = False
        End If
    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Response.Redirect("../../home.aspx")
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If Me.txt_refname1.Text = "" Or Me.txt_refadd1.Text = "" Or Me.txt_refph1.Text = "" Or Me.txt_refname2.Text = "" Or Me.txt_refadd2.Text = "" Or Me.txt_refph2.Text = "" Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' Check whether U filled All Mandatory Fields');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        ElseIf Me.chk_dir.Checked = True And (Me.txt_empname.Text = "" Or Me.txt_emprel.Text = "") Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert(' Check whether U filled All Mandatory Fields');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        ElseIf Me.chk_dir.Checked = True And (Me.txt_dirname.Text = "" Or Me.txt_dirprel.Text = "") Then
            Dim cl_script12 As New System.Text.StringBuilder
            cl_script12.Append("         alert(' Check whether U filled All Mandatory Fields');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script12.ToString, True)
        Else
            Dim oh As New Helper.Oracle.OracleHelper
            Dim op(13) As OracleParameter
            op(0) = New OracleParameter("c_appln", OracleType.Number, 8)
            op(0).Value = Me.txt_applnno.Text
            op(0).Direction = ParameterDirection.Input
            op(1) = New OracleParameter("c_empreln", OracleType.VarChar, 500)
            If Me.chk_relative.Checked = True Then
                op(1).Value = 1
            Else
                op(1).Value = 0
            End If
            op(1).Direction = ParameterDirection.Input
            If Me.chk_relative.Checked = True And Me.txt_empname.Text <> "" And Me.txt_emprel.Text <> "" Then
                op(2) = New OracleParameter("c_emp", OracleType.VarChar, 50)
                op(2).Value = Me.txt_empname.Text
                op(2).Direction = ParameterDirection.Input
                op(3) = New OracleParameter("c_emprel", OracleType.VarChar, 20)
                op(3).Value = Me.txt_emprel.Text
                op(3).Direction = ParameterDirection.Input

            ElseIf Me.chk_relative.Checked = False Then
                op(2) = New OracleParameter("c_emp", OracleType.VarChar, 50)
                op(2).Value = ""
                op(2).Direction = ParameterDirection.Input
                op(3) = New OracleParameter("c_emprel", OracleType.VarChar, 20)
                op(3).Value = ""
                op(3).Direction = ParameterDirection.Input
            End If
            op(4) = New OracleParameter("c_dirreln", OracleType.VarChar, 500)
            If Me.chk_dir.Checked = True Then
                op(4).Value = 1
            Else
                op(4).Value = 0
            End If
            op(4).Direction = ParameterDirection.Input
            If Me.chk_dir.Checked = True And Me.txt_dirname.Text <> "" And Me.txt_dirprel.Text <> "" Then
                op(5) = New OracleParameter("c_dir", OracleType.VarChar, 50)
                op(5).Value = Me.txt_dirname.Text
                op(5).Direction = ParameterDirection.Input
                op(6) = New OracleParameter("c_dirrel", OracleType.VarChar, 20)
                op(6).Value = Me.txt_emprel.Text
                op(6).Direction = ParameterDirection.Input
            ElseIf Me.chk_dir.Checked = False Then
                op(5) = New OracleParameter("c_dir", OracleType.VarChar, 50)
                op(5).Value = ""
                op(5).Direction = ParameterDirection.Input

                op(6) = New OracleParameter("c_dirrel", OracleType.VarChar, 20)
                op(6).Value = ""
                op(6).Direction = ParameterDirection.Input
            End If
            op(7) = New OracleParameter("c_refname1", OracleType.VarChar, 40)
            op(7).Value = Me.txt_refname1.Text
            op(7).Direction = ParameterDirection.Input
            op(8) = New OracleParameter("c_refadd1", OracleType.VarChar, 50)
            op(8).Value = Me.txt_refname1.Text
            op(8).Direction = ParameterDirection.Input
            op(9) = New OracleParameter("c_refph1", OracleType.VarChar, 15)
            op(9).Value = Me.txt_refname1.Text
            op(9).Direction = ParameterDirection.Input
            op(10) = New OracleParameter("c_refname2", OracleType.VarChar, 40)
            op(10).Value = Me.txt_refname2.Text
            op(10).Direction = ParameterDirection.Input
            op(11) = New OracleParameter("c_refadd2", OracleType.VarChar, 50)
            op(11).Value = Me.txt_refname2.Text
            op(11).Direction = ParameterDirection.Input
            op(12) = New OracleParameter("c_refph2", OracleType.VarChar, 15)
            op(12).Value = Me.txt_refname2.Text
            op(12).Direction = ParameterDirection.Input
            op(13) = New OracleParameter("c_otherdtl", OracleType.VarChar, 75)
            If Me.txt_otherdtl.Text = "" Then
                op(13).Value = ""
            Else
                op(13).Value = Me.txt_otherdtl.Text
            End If
            op(13).Direction = ParameterDirection.Input
            oh.ExecuteNonQuery("new_applnother", op)
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' Sucessfully Confirmed Appln No: " & op(0).Value & "');")
            cl_script0.Append("       window.open('../../payroll/posting/ApplicnReport.aspx?appln_no=" & op(0).Value & "');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)

        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        applnfill()
    End Sub
End Class
