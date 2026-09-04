Imports System.Data
Imports System.Data.OracleClient
Partial Class november_employ_not_punch_f0468b649893
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Txt_lmt.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)
        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        dt = oh.ExecuteDataSet("select emp_code from employee_master where post_id=173 and emp_code=" & sf(0) & " and status_id=1 ").Tables(0)
        If (Session("access_id") = 33 Or dt.Rows.Count = 1) Then

            If Not IsPostBack Then
                sql = "select '---select---'brname,-1 brid from dual union select branch_name,branch_id from branch_master where branch_id =" & Session("branch_id") & ""
                dt = oh.ExecuteDataSet(sql).Tables(0)
                Me.cmb_branch.DataSource = dt
                Me.cmb_branch.DataTextField = dt.Columns(0).ColumnName
                Me.cmb_branch.DataValueField = dt.Columns(1).ColumnName
                Me.cmb_branch.DataBind()
            End If
        Else
            Response.Redirect("../show_err.aspx")
        End If
    End Sub


    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        dim post as integer
Dim branch As String
        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        If (Me.chk_bh.Checked = True) Then
            post = 1
        Else
            If (Me.chk_abh.Checked = True) Then
                post = 2
            Else
                post = 0
            End If
        End If
        Dim script1 As New System.Text.StringBuilder
        If (Me.Txt_lmt.Text = "") Then
            script1.Append("        alert('Please Fill All Entries');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        Else
            If (Me.chk_all.Checked = True) Then
                Dim parameter(2) As OracleParameter
                parameter(0) = New OracleParameter("user", OracleType.Number, 150)
                parameter(0).Direction = ParameterDirection.Input
                parameter(0).Value = sf(0)
                parameter(1) = New OracleParameter("lim", OracleType.VarChar, 150)
                parameter(1).Direction = ParameterDirection.Input
                parameter(1).Value = Me.Txt_lmt.Text
                parameter(2) = New OracleParameter("flag", OracleType.Number, 150)
                parameter(2).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("emp_not_punched1", parameter)
                If (parameter(2).Value = 1) Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    If (Me.chk_bh.Checked = True) Then
                        cl_script1.Append("window.open('employ_not_punch_report.aspx?&post=" & post & "','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Else
                        If (Me.chk_abh.Checked = True) Then
                            cl_script1.Append("window.open('employ_not_punch_report.aspx?&post=" & post & "','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                        End If
                        If (Me.chk_bh.Checked = False And Me.chk_abh.Checked = False) Then
                            cl_script1.Append("window.open('employ_not_punch_report.aspx?&post=" & post & "','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                        End If
                    End If
                Else
                    script1.Append("        alert('ERROR IN DATA');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
                End If
            Else
                branch = Me.cmb_branch.SelectedValue
                Dim parameter(3) As OracleParameter
                parameter(0) = New OracleParameter("user", OracleType.Number, 150)
                parameter(0).Direction = ParameterDirection.Input
                parameter(0).Value = sf(0)
                parameter(1) = New OracleParameter("lim", OracleType.Number, 150)
                parameter(1).Direction = ParameterDirection.Input
                parameter(1).Value = Me.Txt_lmt.Text
                parameter(2) = New OracleParameter("br", OracleType.Number, 150)
                parameter(2).Direction = ParameterDirection.Input
                parameter(2).Value = branch
                parameter(3) = New OracleParameter("msg", OracleType.Number, 150)
                parameter(3).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("emp_not_punched", parameter)
                If (parameter(3).Value = 1) Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    If (Me.chk_bh.Checked = True) Then
                        cl_script1.Append("window.open('employ_not_punch_report.aspx?&post=" & post & "','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Else
                        If (Me.chk_abh.Checked = True) Then
                            cl_script1.Append("window.open('employ_not_punch_report.aspx?&post=" & post & "','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                        Else
                            cl_script1.Append("window.open('employ_not_punch_report.aspx?&post=" & post & "','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                        End If
                    End If
                Else
                    script1.Append("        alert('ERROR IN DATA');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
                End If
            End If
        End If
    End Sub
End Class
