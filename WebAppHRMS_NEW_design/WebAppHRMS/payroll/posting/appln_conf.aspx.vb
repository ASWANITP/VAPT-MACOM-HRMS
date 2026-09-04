Imports System.Data
Imports System.Data.OracleClient
Partial Class payroll_Posting_appln_conf_dc38b86b2612
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dtv As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtv = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=5218 and emp_id=" & Me.Session("user_id").ToString.Split("!")(0)).Tables(0)
        If Session("access_id") = 33 And Session("firm_id") <> 24 Then
            Me.cmb_appln.ForeColor = Drawing.Color.DeepPink
            Me.cmb_place.ForeColor = Drawing.Color.DeepPink
            Me.cmb_post.ForeColor = Drawing.Color.DeepPink
            Me.cmb_status.ForeColor = Drawing.Color.DeepPink
            Me.txt_dt.ForeColor = Drawing.Color.DeepPink
            Me.txt_intvwid.ForeColor = Drawing.Color.DeepPink
            Me.txt_intvwname.ForeColor = Drawing.Color.DeepPink
            If Not IsPostBack Then
                Dim dt, dt1, dt2, dtshort As New DataTable
                dt2 = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=103 and t.firm_id=99").Tables(0)
                Dim mystr As String = dt2.Rows(0)(0)
                mystr = mystr.Replace("myfirm", Session("firm_id"))
                dtshort = oh.ExecuteDataSet(mystr).Tables(0)
                Me.cmb_appln.DataSource = dtshort
                Me.cmb_appln.DataTextField = dtshort.Columns(1).ColumnName
                Me.cmb_appln.DataValueField = dtshort.Columns(0).ColumnName
                Me.cmb_appln.DataBind()

                dt = oh.ExecuteDataSet("select post_id,post_name from post_mst order by post_name").Tables(0)
                Me.cmb_post.DataSource = dt
                Me.cmb_post.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_post.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_post.DataBind()

                dt1 = oh.ExecuteDataSet("select branch_id,branch_name from branch_master where branch_id<>9999 order by branch_name").Tables(0)
                Me.cmb_place.DataSource = dt1
                Me.cmb_place.DataTextField = dt1.Columns(1).ColumnName
                Me.cmb_place.DataValueField = dt1.Columns(0).ColumnName
                Me.cmb_place.DataBind()
            End If
        ElseIf Session("access_id") = 33 And Session("firm_id") = 24 And dtv.Rows(0)(0) > 0 Then
            Me.cmb_appln.ForeColor = Drawing.Color.DeepPink
            Me.cmb_place.ForeColor = Drawing.Color.DeepPink
            Me.cmb_post.ForeColor = Drawing.Color.DeepPink
            Me.cmb_status.ForeColor = Drawing.Color.DeepPink
            Me.txt_dt.ForeColor = Drawing.Color.DeepPink
            Me.txt_intvwid.ForeColor = Drawing.Color.DeepPink
            Me.txt_intvwname.ForeColor = Drawing.Color.DeepPink
            If Not IsPostBack Then
                Dim dt, dt1, dt2, dtshort As New DataTable
                dt2 = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=103 and t.firm_id=99").Tables(0)
                Dim mystr As String = dt2.Rows(0)(0)
                mystr = mystr.Replace("myfirm", Session("firm_id"))
                dtshort = oh.ExecuteDataSet(mystr).Tables(0)
                Me.cmb_appln.DataSource = dtshort
                Me.cmb_appln.DataTextField = dtshort.Columns(1).ColumnName
                Me.cmb_appln.DataValueField = dtshort.Columns(0).ColumnName
                Me.cmb_appln.DataBind()

                dt = oh.ExecuteDataSet("select post_id,post_name from post_mst order by post_name").Tables(0)
                Me.cmb_post.DataSource = dt
                Me.cmb_post.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_post.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_post.DataBind()

                dt1 = oh.ExecuteDataSet("select branch_id,branch_name from branch_master where branch_id<>9999 order by branch_name").Tables(0)
                Me.cmb_place.DataSource = dt1
                Me.cmb_place.DataTextField = dt1.Columns(1).ColumnName
                Me.cmb_place.DataValueField = dt1.Columns(0).ColumnName
                Me.cmb_place.DataBind()
            End If
        Else
            Response.Redirect("../../show_err.aspx")
        End If
    End Sub

    Protected Sub txt_intvwid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_intvwid.TextChanged
        Me.txt_intvwname.Text = ""
        Me.lbl_msg.Text = ""
        Dim sf As New DataTable
        sf = oh.ExecuteDataSet("select emp_name from employee_master where status_id=1 and emp_code=" & Me.txt_intvwid.Text).Tables(0)
        If sf.Rows.Count > 0 Then
            Me.txt_intvwname.Text = sf.Rows(0)(0)
        Else
            Me.lbl_msg.Text = "Employee Does not Exist"
            Me.lbl_msg.ForeColor = Drawing.Color.DeepPink
        End If
    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Response.Redirect("../../home.aspx")
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If txt_intvwid.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Sorry, please enter Interviewer');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        End If
        If txt_dt.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Sorry, please enter Interviewe date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        End If

        Dim op(6) As OracleParameter
        op(0) = New OracleParameter("c_appln", OracleType.Number, 8)
        op(0).Value = Me.cmb_appln.SelectedValue
        op(0).Direction = ParameterDirection.Input

        op(1) = New OracleParameter("c_intervwby", OracleType.Number, 5)
        op(1).Value = Me.txt_intvwid.Text
        op(1).Direction = ParameterDirection.Input

        op(2) = New OracleParameter("c_intervwplace", OracleType.Number, 4)
        op(2).Value = Me.cmb_place.SelectedValue
        op(2).Direction = ParameterDirection.Input

        op(3) = New OracleParameter("c_proppost", OracleType.Number, 3)
        op(3).Value = Me.cmb_post.SelectedValue
        op(3).Direction = ParameterDirection.Input

        op(4) = New OracleParameter("c_intervwdt", OracleType.DateTime, 8)
        op(4).Value = Me.txt_dt.Text
        op(4).Direction = ParameterDirection.Input

        op(5) = New OracleParameter("c_intervwstatus", OracleType.Number, 8)
        op(5).Value = Me.cmb_status.SelectedValue
        op(5).Direction = ParameterDirection.Input

        op(6) = New OracleParameter("c_remarks", OracleType.VarChar, 100)
        op(6).Value = 0
        op(6).Direction = ParameterDirection.Input

        oh.ExecuteNonQuery("new_intervw", op)
        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("         alert(' Sucessfully Confirmed Appln No: " & op(0).Value & "');")
        cl_script0.Append("       window.open('../../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)

    End Sub

    Protected Sub txt_dt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.lbl_msg.Text = ""
        Dim td As Date = Me.txt_dt.Text
        If td.DayOfWeek = DayOfWeek.Sunday Then
            'Date.Today.DayOfWeek.Sunday()
            Me.lbl_msg.Text = "You have selected sunday/Select Correct Date "
            Me.lbl_msg.ForeColor = Drawing.Color.DeepPink
            Me.lbl_msg.Font.Bold = True
            Me.txt_dt.Text = ""
            Me.txt_dt.Focus()
        End If
    End Sub


End Class
