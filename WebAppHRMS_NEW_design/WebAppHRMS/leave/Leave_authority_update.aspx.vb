Imports System.Data
Imports System.Data.OracleClient
Partial Class Leave_authority_update_92d2c3028449
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Dim res As String
    Dim dt1 As DataTable
    Dim slno As Integer
    Dim postid As Integer
    Dim brid As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Dim user() As String
            user = Session("user_id").ToString.Split("!")
            Dim cnt As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility f where f.form_id=542 and f.emp_id=" & user(0) & "").Tables(0).Rows(0)(0)
            If cnt = 0 Then
                Me.Server.Transfer("../show_err.aspx")
            End If

            CType(Me.Master, WebAppHRMS.edp).Subtitle = "LEAVE SANCTION AUTHORITY UPDATE"
            cmbBranch.BackColor = Drawing.Color.White
            cmb_department.BackColor = Drawing.Color.White
            cmb_leaveype.BackColor = Drawing.Color.White
            cmbBranch.BackColor = Drawing.Color.White
            cmb_post.BackColor = Drawing.Color.White
            If Not IsPostBack Then
                Dim usr = Session("user_id").ToString.Split("!")

                Dim dt As DataTable
                dt = oh.ExecuteDataSet("Select 0, '--SELECT--' as leave_desc from dual union select t.leave_id,t.leave_desc from hrm_leave_type t where t.firm_id = " & Session("firm_id") & " ").Tables(0)
                Me.cmb_leaveype.DataSource = dt
                Me.cmb_leaveype.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_leaveype.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_leaveype.DataBind()

                dt = oh.ExecuteDataSet("Select 0, '--SELECT--' as leave_desc from dual union Select t.post_type_id,t.post_rule_name from hrm_leave_list_type t").Tables(0)
                Me.cmb_post.DataSource = dt
                Me.cmb_post.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_post.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_post.DataBind()

                dt = oh.ExecuteDataSet("Select -1, '--SELECT--' as branch_name from dual union select branch_id,branch_name from branch_master").Tables(0)
                Me.cmbBranch.DataSource = dt
                Me.cmbBranch.DataTextField = dt.Columns(1).ColumnName
                Me.cmbBranch.DataValueField = dt.Columns(0).ColumnName
                Me.cmbBranch.DataBind()

                dt = oh.ExecuteDataSet("Select 0, '--SELECT--' as leave_desc from dual union select d.dep_id, d.dep_name from department_mst d where d.firm_id =" & Session("firm_id") & "").Tables(0)
                Me.cmb_department.DataSource = dt
                Me.cmb_department.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_department.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_department.DataBind()

                bindData()

                If GridView1.Rows.Count < 1 Then
                    lblheading.Visible = False
                Else
                    lblheading.Visible = True
                End If
            End If
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub



    Sub bindData()
        Try
            lblheading.Visible = True
            Dim sql As String
            Dim dtTemp As DataTable
            sql = "Select t.slno, t.post_type_id , h.post_rule_name Post, t.leave_type, lt.f_days Days_From, lt.t_days Days_To,  b.branch_id, b.branch_name Branch, t.dept_id, t.rec1 First_Recommend, t.rec2 Second_Recommend, t.sanction from leave_auth_list_new t, branch_master b, hrm_leave_list_type h, hrm_leave_type lt where t.branch_id=b.branch_id and t.post_type_id=h.post_type_id and t.leave_type=lt.leave_id order by t.slno "
            dtTemp = oh.ExecuteDataSet(sql).Tables(0)
            GridView1.DataSource = dtTemp
            GridView1.DataBind()
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub


    Sub clear_data()
        cmb_leaveype.Enabled = True
        cmb_post.Enabled = True
        cmbBranch.Enabled = True
        cmb_department.Enabled = True

        cmb_leaveype.SelectedIndex = 0
        cmb_post.SelectedIndex = 0
        cmbBranch.SelectedIndex = 0
        cmb_department.SelectedIndex = 0
        txtRec1.Text = ""
        txtRec2.Text = ""
        txtSanc.Text = ""
        Label1.Text = ""
        lblrec1.Text = ""
        lblrec2.Text = ""
        lblsanc.Text = ""
        GridView1.SelectedIndex = -1
        bindData()
    End Sub




    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Try
            Dim dt As DataTable

            If txtRec1.Text = "" And txtRec2.Text = "" And txtSanc.Text = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Please enter sanction authority details');", True)
                txtRec1.Focus()
                Exit Sub
            End If

            If Val(txtSelect.Text) = 0 Then
                dt = oh.ExecuteDataSet("select count(*) from leave_auth_list_new t where t.firm_id=" & Session("firm_id") & " and t.branch_id=" & cmbBranch.SelectedValue & " and t.dept_id= " & cmb_department.SelectedValue & " and t.leave_type=" & cmb_leaveype.SelectedValue & " and t.category_no=1 and t.rec1=" & txtRec1.Text & " and t.rec2=" & txtRec2.Text & " and t.sanction=" & txtSanc.Text & " ").Tables(0)
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)(0) > 0 Then
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Same details already entered !');", True)

                    End If
                End If
            End If

            If txtRec1.Text = 0 And txtRec2.Text = 0 And txtSanc.Text <> 0 And txtSanc.Text.Length > 0 Then
                btnConfirm.Focus()
            Else
                If txtRec1.Text.Length > 0 And lblrec1.Text.Length = 0 Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('First Recommend Employee Code entered Not found !');", True)
                    txtRec1.Focus()
                    Exit Sub
                End If
                If txtRec2.Text.Length > 0 And lblrec2.Text.Length = 0 Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Second Recommend Employee Code entered Not found !');", True)
                    txtRec2.Focus()
                    Exit Sub
                End If
                If txtSanc.Text.Length > 0 And txtSanc.Text.Length = 0 Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Sanction Employee Code entered Not found !');", True)
                    txtSanc.Focus()
                    Exit Sub
                End If
            End If

            Dim rule As String = ""
            dt = oh.ExecuteDataSet("select t.post_rule from hrm_leave_list_type t where t.post_type_id=" & cmb_post.SelectedValue & " and t.firm_id=" & Session("firm_id") & "").Tables(0)
            If dt.Rows.Count > 0 Then
                rule = dt.Rows(0)(0)
            End If
            Dim prm(17) As OracleParameter


            prm(0) = New OracleParameter("FIRMID", OracleType.Number, 2)
            prm(0).Direction = ParameterDirection.Input
            prm(0).Value = Session("firm_id")

            prm(1) = New OracleParameter("BRANCHID", OracleType.Number, 4)
            prm(1).Direction = ParameterDirection.Input
            prm(1).Value = cmbBranch.SelectedValue

            prm(2) = New OracleParameter("DEPTID", OracleType.Number, 4)
            prm(2).Direction = ParameterDirection.Input
            prm(2).Value = cmb_department.SelectedValue

            prm(3) = New OracleParameter("CATEGORYNO", OracleType.Number, 2)
            prm(3).Direction = ParameterDirection.Input
            prm(3).Value = 1

            prm(4) = New OracleParameter("LEAVETYPE", OracleType.Number, 1)
            prm(4).Direction = ParameterDirection.Input
            prm(4).Value = cmb_leaveype.SelectedValue

            prm(5) = New OracleParameter("EMPLISTRULE", OracleType.VarChar, 10000)
            prm(5).Direction = ParameterDirection.Input
            prm(5).Value = rule

            prm(6) = New OracleParameter("REC1ID", OracleType.Number, 6)
            prm(6).Direction = ParameterDirection.Input
            prm(6).Value = Val(txtRec1.Text)

            prm(7) = New OracleParameter("REC1POST", OracleType.Number, 3)
            prm(7).Direction = ParameterDirection.Input
            prm(7).Value = 1

            prm(8) = New OracleParameter("REC2ID", OracleType.Number, 6)
            prm(8).Direction = ParameterDirection.Input
            prm(8).Value = Val(txtRec2.Text)

            prm(9) = New OracleParameter("REC2POST", OracleType.Number, 3)
            prm(9).Direction = ParameterDirection.Input
            prm(9).Value = 2

            prm(10) = New OracleParameter("SANCTIONID", OracleType.Number, 6)
            prm(10).Direction = ParameterDirection.Input
            prm(10).Value = Val(txtSanc.Text)

            prm(11) = New OracleParameter("SANCTIONPOST", OracleType.Number, 3)
            prm(11).Direction = ParameterDirection.Input
            prm(11).Value = 3

            Dim usr = Session("user_id").ToString.Split("!")
            prm(12) = New OracleParameter("ENTEREDBY", OracleType.Number, 6)
            prm(12).Direction = ParameterDirection.Input
            prm(12).Value = usr(0)

            prm(13) = New OracleParameter("POSTID", OracleType.Number)
            prm(13).Direction = ParameterDirection.Input
            prm(13).Value = cmb_post.SelectedValue

            prm(14) = New OracleParameter("updSLNO", OracleType.Number)
            prm(14).Direction = ParameterDirection.Input
            prm(14).Value = Val(txtSelect.Text)

            prm(15) = New OracleParameter("CMDTYPE", OracleType.Number)
            prm(15).Direction = ParameterDirection.Input
            If Val(txtSelect.Text) = 0 Then
                prm(15).Value = 1
            Else
                prm(15).Value = 2
            End If

            prm(16) = New OracleParameter("err_stat", OracleType.Number, 1)
            prm(16).Direction = ParameterDirection.Output


            prm(17) = New OracleParameter("err_msg", OracleType.VarChar, 3000)
            prm(17).Direction = ParameterDirection.Output


            oh.ExecuteNonQuery("hrm_leave_auth_update_proc", prm)
            If prm(16).Value = 1 Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Record Saved successfully.');", True)
                txtSelect.Text = 0
                clear_data()
            Else
                Label1.Text = "Error..Record Not Saved."
            End If

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Record Not Saved ..!');", True)
        End Try
    End Sub

    Protected Sub cmb_post_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_post.SelectedIndexChanged
        Try
            Dim postid As Integer
            postid = cmb_post.SelectedValue
            If postid = 1 Or postid = 6 Then
                cmbBranch.Enabled = True
            Else
                cmbBranch.SelectedIndex = 0
            End If

            If postid = 3 Or postid = 4 Or postid = 5 Then
                cmbBranch.SelectedIndex = 1
                cmbBranch.Enabled = False
            Else
                cmbBranch.SelectedIndex = 0
            End If

            If postid = 3 Then
                cmb_department.Enabled = True
            Else
                cmb_department.SelectedIndex = 0
                cmb_department.Enabled = False
            End If
            If postid = 2 Then
                cmbBranch.Enabled = True
            Else
                cmb_department.SelectedIndex = 0
                cmb_department.Enabled = False
            End If
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub

    Protected Sub cmbBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBranch.SelectedIndexChanged

    End Sub

    Protected Sub txtRec1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRec1.TextChanged
        Try
            Dim dt As DataTable
            If txtRec1.Text.Length > 0 Then
                If Val(txtRec1.Text) = 0 Then Exit Sub
                dt = oh.ExecuteDataSet("select p.post_name from employee_master m,post_mst p where m.post_id=p.post_id and m.emp_code=" & txtRec1.Text & "").Tables(0)
                If dt.Rows.Count > 0 Then
                    lblrec1.Text = dt.Rows(0)(0).ToString()
                    txtRec2.Focus()
                Else
                    lblrec1.Text = ""
                    txtRec1.Text = ""
                    txtRec1.Focus()
                    Exit Sub
                End If
            Else
                lblrec1.Text = ""
            End If
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub

    Protected Sub txtRec2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRec2.TextChanged
        Try
            Dim dt As DataTable
            If txtRec2.Text.Length > 0 Then
                dt = oh.ExecuteDataSet("select p.post_name from employee_master m,post_mst p where m.post_id=p.post_id and m.emp_code=" & txtRec2.Text & "").Tables(0)
                If dt.Rows.Count > 0 Then
                    lblrec2.Text = dt.Rows(0)(0).ToString()
                    txtSanc.Focus()
                Else
                    lblrec2.Text = ""
                    txtRec2.Text = ""
                    txtRec2.Focus()
                    Exit Sub
                End If
            Else
                lblrec2.Text = ""
            End If
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub

    Protected Sub txtSanc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSanc.TextChanged
        Try
            Dim dt As DataTable
            If txtSanc.Text.Length > 0 Then
                dt = oh.ExecuteDataSet("select p.post_name from employee_master m,post_mst p where m.post_id=p.post_id and m.emp_code=" & txtSanc.Text & "").Tables(0)
                If dt.Rows.Count > 0 Then
                    lblsanc.Text = dt.Rows(0)(0).ToString()
                Else
                    lblsanc.Text = ""
                    txtSanc.Focus()
                End If
            Else
                lblsanc.Text = ""
            End If
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Try
            slno = CInt(GridView1.Rows(GridView1.SelectedIndex).Cells(0).Text)
            txtSelect.Text = 0
            Dim sql As String
            Dim dtTemp As DataTable
            sql = "Select t.slno, t.post_type_id ,t.leave_type,  b.branch_id, t.dept_id, t.rec1 First_Recommend, t.rec2 Second_Recommend, t.sanction from leave_auth_list_new t, branch_master b, hrm_leave_list_type h, hrm_leave_type lt where t.branch_id=b.branch_id and t.post_type_id=h.post_type_id and t.leave_type=lt.leave_id and t.slno=" & slno & " "
            dtTemp = oh.ExecuteDataSet(sql).Tables(0)
            Dim sno, pid, levid, bid, depid, rec1, rec2, sanc As Integer
            If dtTemp.Rows.Count > 0 Then
                sno = dtTemp.Rows(0)(0)
                pid = dtTemp.Rows(0)(1)
                levid = dtTemp.Rows(0)(2)
                bid = dtTemp.Rows(0)(3)
                depid = dtTemp.Rows(0)(4)
                rec1 = dtTemp.Rows(0)(5)
                rec2 = dtTemp.Rows(0)(6)
                sanc = dtTemp.Rows(0)(7)
            End If

            If slno = sno Then
                txtSelect.Text = slno
                cmb_leaveype.SelectedValue = levid
                cmb_post.SelectedValue = pid
                cmbBranch.SelectedValue = bid
                cmb_department.SelectedValue = depid
                txtRec1.Text = rec1
                txtRec2.Text = rec2
                txtSanc.Text = sanc
                txtRec1_TextChanged(Nothing, Nothing)
                txtRec2_TextChanged(Nothing, Nothing)
                txtSanc_TextChanged(Nothing, Nothing)
                cmb_leaveype.Enabled = False
                cmb_post.Enabled = False
                cmbBranch.Enabled = False
                cmb_department.Enabled = False
            End If
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub

    Protected Sub cmb_leaveype_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_leaveype.SelectedIndexChanged
        cmb_post.SelectedIndex = 0
        cmbBranch.SelectedIndex = 0
        cmb_department.SelectedIndex = 0
        txtRec1.Text = ""
        txtRec2.Text = ""
        txtSanc.Text = ""
        Label1.Text = ""
    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        clear_data()
    End Sub
End Class
