Imports System.Data
Imports System.Data.OracleClient

Partial Class payroll_posting_appl_other_detail_3df3eea01904
    Inherits System.Web.UI.Page

    Dim res As String
    Dim oh As New helper.oracle.OracleHelper
    Dim val, ld, flag, appln_no As Integer
    Dim dt, dt1, dt2, dt3, dt4 As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "OTHER DETAILS"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.subtitle = "OTHER DETAILS"
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txt_appname.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        If Not IsPostBack Then
            Dim appno = Request.QueryString("appln_no")
            If appno <> 0 Then
                Me.txt_appno.Text = appno
                Me.txt_appname.Value = oh.ExecuteDataSet("select appln_name from appln_pers_dtl a where appln_no=" & appno).Tables(0).Rows(0)(0)
            End If
        End If
    End Sub

    Protected Sub cmd_add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_add.Click
        Dim oh As New Helper.Oracle.OracleHelper
        Dim op(14) As OracleParameter
        op(0) = New OracleParameter("c_appln", OracleType.Number, 8)
        op(0).Value = Me.txt_appno.Text 'value edited by m*
        op(0).Direction = ParameterDirection.Input
        op(1) = New OracleParameter("c_empreln", OracleType.VarChar, 500)
        If Me.chk_emp.Checked = True Then
            op(1).Value = 1
        Else
            op(1).Value = 0
        End If
        op(1).Direction = ParameterDirection.Input
        If Me.chk_emp.Checked = True Then
            op(2) = New OracleParameter("c_emp", OracleType.VarChar, 50)
            op(2).Value = Me.txt_empname.Value
            op(2).Direction = ParameterDirection.Input
            op(3) = New OracleParameter("c_emprel", OracleType.VarChar, 20)
            op(3).Value = Me.txt_emprelation.Value
            op(3).Direction = ParameterDirection.Input

        ElseIf Me.chk_emp.Checked = False Then
            op(2) = New OracleParameter("c_emp", OracleType.VarChar, 50)
            op(2).Value = ""
            op(2).Direction = ParameterDirection.Input
            op(3) = New OracleParameter("c_emprel", OracleType.VarChar, 20)
            op(3).Value = ""
            op(3).Direction = ParameterDirection.Input
        End If
        op(4) = New OracleParameter("c_dirreln", OracleType.VarChar, 500)
        If Me.chk_director.Checked = True Then
            op(4).Value = 1
        Else
            op(4).Value = 0
        End If
        op(4).Direction = ParameterDirection.Input
        If Me.chk_director.Checked = True Then
            op(5) = New OracleParameter("c_dir", OracleType.VarChar, 50)
            op(5).Value = Me.txt_directorname.Value
            op(5).Direction = ParameterDirection.Input
            op(6) = New OracleParameter("c_dirrel", OracleType.VarChar, 20)
            op(6).Value = Me.txt_directorrelation.Value
            op(6).Direction = ParameterDirection.Input
        ElseIf Me.chk_director.Checked = False Then
            op(5) = New OracleParameter("c_dir", OracleType.VarChar, 50)
            op(5).Value = ""
            op(5).Direction = ParameterDirection.Input

            op(6) = New OracleParameter("c_dirrel", OracleType.VarChar, 20)
            op(6).Value = ""
            op(6).Direction = ParameterDirection.Input
        End If
        op(7) = New OracleParameter("c_refname1", OracleType.VarChar, 40)
        op(7).Value = Me.txt_ref1name.Value
        op(7).Direction = ParameterDirection.Input

        op(8) = New OracleParameter("c_refadd1", OracleType.VarChar, 50)
        op(8).Value = Me.txt_ref1address.Value
        op(8).Direction = ParameterDirection.Input

        op(9) = New OracleParameter("c_refph1", OracleType.VarChar, 15)
        op(9).Value = Me.txt_ref1phone.Value
        op(9).Direction = ParameterDirection.Input

        op(10) = New OracleParameter("c_refname2", OracleType.VarChar, 40)
        op(10).Value = Me.txt_ref2name.Value
        op(10).Direction = ParameterDirection.Input

        op(11) = New OracleParameter("c_refadd2", OracleType.VarChar, 50)
        op(11).Value = Me.txt_ref2address.Value
        op(11).Direction = ParameterDirection.Input

        op(12) = New OracleParameter("c_refph2", OracleType.VarChar, 15)
        op(12).Value = Me.txt_ref2phone.Value
        op(12).Direction = ParameterDirection.Input
        op(13) = New OracleParameter("c_otherdtl", OracleType.VarChar, 75)
        If Me.txt_other.Value = "" Then
            op(13).Value = ""
        Else
            op(13).Value = Me.txt_other.Value
        End If
        op(13).Direction = ParameterDirection.Input

        Dim usrfrm As String = Session("user_id").ToString.Split("!")(0) & "#" & Session("firm_id")
        op(14) = New OracleParameter("userfirm", OracleType.VarChar, 50)
        op(14).Value = usrfrm
        op(14).Direction = ParameterDirection.Input

        oh.ExecuteNonQuery("new_applnother", op)

        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("         alert(' Sucessfully Confirmed Appln No: " & op(0).Value & "');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        Clear()
    End Sub

    Protected Sub txt_appno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_appno.TextChanged
        Dim appno As Integer = Me.txt_appno.Text
        Dim dt, dt1 As New DataTable
        dt = oh.ExecuteDataSet("select appln_name from appln_pers_dtl a where not exists (select appln_no from appln_other_dtl q where q.appln_no= a.appln_no) and a.appln_no =" & appno).Tables(0)
        dt1 = oh.ExecuteDataSet("select t.*, t.rowid from appln_other_dtl t where t.appln_no='" & txt_appno.Text & "'").Tables(0)

        If dt.Rows.Count > 0 Then
            Me.txt_appname.Value = dt.Rows(0)(0)
        ElseIf dt1.Rows.Count > 0 Then

            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Application Number Details are entered');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
            txt_appno.Text = ""
            txt_appname.Value = ""
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Please Enter Valid Application Number...!!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
            Me.txt_appname.Value = ""
            Me.txt_appno.Text = ""
            Me.txt_appno.Focus()
        End If

    End Sub
    Private Sub Clear()
        txt_appno.Text = ""
        txt_appname.Value = ""
        txt_ref1name.Value = ""
        txt_ref1address.Value = ""
        txt_ref1phone.Value = ""
        txt_ref2name.Value = ""
        txt_ref2address.Value = ""
        txt_ref2phone.Value = ""
        txt_directorname.Value = ""
        txt_empname.Value = ""
        txt_emprelation.Value = ""
        txt_other.Value = ""
        chk_director.Checked = False
        chk_emp.Checked = False
    End Sub

End Class
