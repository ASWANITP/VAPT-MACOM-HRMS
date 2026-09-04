
Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.ReportAppServer.DataDefModel
Imports PdfSharp.Pdf
Public Class hrm_dept_post_des_approve
    Inherits System.Web.UI.Page

    Dim cbResult As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode As Integer
    Dim maj_dept As String
    Dim grade, dept, des, post As Integer


    Protected Sub ddlMainDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMainDept.SelectedIndexChanged

        If rdDept.Checked Then
            Dim selectedValue As String = ddlMainDept.SelectedValue
            Dim value As String = selectedValue
            Dim result() As String = value.Split("-")
            'Dim dept As String = result(0)
            'Dim maj_dept As String = result(1)
            dept = result(0)
            maj_dept = result(1)
            If (maj_dept <> "n") Then
                dt = oh.ExecuteDataSet("select t.department_name from DEPARTMENT_MAJOR t where t.department_id=" & maj_dept).Tables(0)

                txtdpd.Text = dt.Rows(0)(0)
            Else
                txtdpd.Text = ""
            End If
        ElseIf rdDes.Checked Then
            Dim selectedValue As String = ddlMainDept.SelectedValue
            Dim value As String = selectedValue
            Dim result() As String = value.Split("-")
            'Dim des As String = result(0)
            'Dim grade As String = result(1)
            des = result(0)
            grade = result(1)
            If (grade <> 0) Then
                dt = oh.ExecuteDataSet("select t.grade as Grade_name from mactech.grade_master t where t.grade_id=" & grade).Tables(0)

                txtdpd.Text = dt.Rows(0)(0)
            Else
                txtdpd.Text = ""
            End If
        End If
    End Sub

    Protected Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        Dim frm As Integer = Session("firm_id")
        UserAll = Me.Session("user_id").ToString.Split("!")
        Dim approved_By As String = UserAll(0)
        Dim fl As Integer
        Dim valrd1 As String

        If ddlMainDept.SelectedValue = "n-n" Or ddlMainDept.SelectedValue = "-1" Or ddlMainDept.SelectedValue = "0-0" Then

            Dim script As String = "alert('Please select a value from the dropdown.');"
            ClientScript.RegisterStartupScript(Me.GetType(), "alertScript", script, True)
        Else

            If Me.rdDept.Checked = True Then

                fl = 7
                valrd1 = Me.ddlMainDept.SelectedItem.Text & "*" & Me.ddlMainDept.SelectedValue


            ElseIf Me.rdPost.Checked = True Then

                fl = 8

                valrd1 = Me.ddlMainDept.SelectedItem.Text & "*" & Me.ddlMainDept.SelectedValue

            Else

                fl = 9
                valrd1 = Me.ddlMainDept.SelectedItem.Text & "*" & Me.ddlMainDept.SelectedValue

            End If
            Try
                Dim pr(7) As OracleParameter

                pr(0) = New OracleParameter("fl", OracleType.Number, 5)
                pr(0).Value = fl

                pr(1) = New OracleParameter("valrd", OracleType.Number, 10)
                pr(1).Value = 0

                pr(2) = New OracleParameter("dattxt", OracleType.VarChar, 50)
                'pr(2).Value = Me.txtdpd.Text
                pr(2).Value = ""

                pr(3) = New OracleParameter("msg", OracleType.VarChar, 50)
                pr(3).Direction = ParameterDirection.Output

                pr(4) = New OracleParameter("frm", OracleType.Number, 5)
                pr(4).Value = frm

                pr(5) = New OracleParameter("valrd1", OracleType.VarChar, 50)
                pr(5).Value = valrd1

                pr(6) = New OracleParameter("enter_By", OracleType.Number, 5)
                pr(6).Value = 0

                pr(7) = New OracleParameter("approve_By", OracleType.Number, 5)
                pr(7).Value = approved_By


                oh.ExecuteNonQuery("HRM_DEP_POST_DES_MACOM", pr)

                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('" & pr(3).Value & "');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Me.txtdpd.Text = ""
                ddlMainDept.Items.Remove(ddlMainDept.SelectedItem)
                Me.ddlMainDept.SelectedValue = "n-n"
            Catch ex As Exception

            End Try
        End If
        'Dim cl_script As New System.Text.StringBuilder
        'cl_script.Append("window.open('hrm_dept_post_des_approve.aspx','_self');")
        'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script.ToString, True)
    End Sub

    Protected Sub rdDept_CheckedChanged(sender As Object, e As EventArgs) Handles rdDept.CheckedChanged
        If rdDept.Checked = True Then
            Me.ddlMainDept.Visible = True
            Me.lblFirst.Visible = True
            Me.lblFirst.Text = "Select New Department"
            Me.lblSecond.Visible = True
            Me.lblSecond.Text = "Main Department"
            Me.txtdpd.Visible = True

            Me.txtdpd.Text = ""
            ddlMainDept.Items.Clear()

            dt = oh.ExecuteDataSet("select to_char('n-n') as dep_id, '------select------' as dep_name from dual union all select t.dep_id||'-'||t.major_dep_id,t.dep_name as newDept from department_temp t where t.status=0").Tables(0)
            Dim value As String = dt.Rows(0)(1).ToString()
            Dim result() As String = value.Split("-")
            Dim dept As String = result(0)
            Dim maj_dept As String = result(1)
            Me.ddlMainDept.DataSource = dt
            Me.ddlMainDept.DataValueField = dt.Columns(0).ColumnName
            Me.ddlMainDept.DataTextField = dt.Columns(1).ColumnName
            Me.ddlMainDept.DataBind()
        End If

    End Sub

    Protected Sub rdPost_CheckedChanged(sender As Object, e As EventArgs) Handles rdPost.CheckedChanged
        If rdPost.Checked = True Then
            Me.ddlMainDept.Visible = True
            Me.lblFirst.Visible = True
            Me.lblFirst.Text = "Select New Post"
            Me.lblSecond.Visible = False
            Me.txtdpd.Visible = False
            ddlMainDept.Items.Clear()
            lblSecond.Visible = False
            txtdpd.Visible = False
            dt = oh.ExecuteDataSet("select -1 as post_id, '------select------' as post_name from dual union all select t.post_id,t.post_name as newPost from post_temp t where t.status=0").Tables(0)
            'post = dt.Rows(0)(1)
            Me.ddlMainDept.DataSource = dt
            Me.ddlMainDept.DataValueField = dt.Columns(0).ColumnName
            Me.ddlMainDept.DataTextField = dt.Columns(1).ColumnName
            Me.ddlMainDept.DataBind()
            ddlMainDept.SelectedIndex = -1
        End If
    End Sub

    Protected Sub rdDes_CheckedChanged(sender As Object, e As EventArgs) Handles rdDes.CheckedChanged
        If rdDes.Checked = True Then
            Me.ddlMainDept.Visible = True
            Me.lblFirst.Visible = True
            Me.lblFirst.Text = "Select New Designation"
            Me.lblSecond.Visible = True
            Me.lblSecond.Text = "Grade"
            Me.txtdpd.Visible = True

            Me.txtdpd.Text = ""
            ddlMainDept.Items.Clear()



            dt = oh.ExecuteDataSet("select ('0-0') as Designation_id, '------select------' as designation from dual union all select t.designation_id ||'-'||t.grade_id,t.designation as newDesig from designation_temp t where t.status=0").Tables(0)
            Dim value As String = dt.Rows(0)(1).ToString()
            Dim result() As String = value.Split("-")
            Dim des As String = result(0)
            Dim grade As String = result(1)
            Me.ddlMainDept.DataSource = dt
            Me.ddlMainDept.DataValueField = dt.Columns(0).ColumnName
            Me.ddlMainDept.DataTextField = dt.Columns(1).ColumnName
            Me.ddlMainDept.DataBind()
            ddlMainDept.SelectedIndex = -1
        End If
    End Sub



    Dim strResult As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim script_val As String
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Approve Department/Post/Designation"
        script_val = "var header;" & "header='" & Me.ddlMainDept.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=134 and emp_id=" & UserCode).Tables(0).Rows(0)(0)
        If acce > 0 Then
            If Not IsPostBack Then

                If rdDept.Checked = True Then
                    Me.ddlMainDept.Visible = True
                    Me.lblFirst.Visible = True
                    Me.lblFirst.Text = "Select New Department"
                    Me.lblSecond.Visible = True
                    Me.lblSecond.Text = "Main Department"
                    Me.txtdpd.Visible = True

                    ddlMainDept.Items.Clear()

                    dt = oh.ExecuteDataSet("select to_char('n-n') as dep_id, '------select------' as dep_name from dual union all select t.dep_id||'-'||t.major_dep_id,t.dep_name as newDept from department_temp t where t.status=0").Tables(0)
                    Dim value As String = dt.Rows(0)(1).ToString()
                    Dim result() As String = value.Split("-")
                    Dim dept As String = result(0)
                    Dim maj_dept As String = result(1)
                    Me.ddlMainDept.DataSource = dt
                    Me.ddlMainDept.DataValueField = dt.Columns(0).ColumnName
                    Me.ddlMainDept.DataTextField = dt.Columns(1).ColumnName
                    Me.ddlMainDept.DataBind()
                End If


            End If

            'Me.btnConfirm.Attributes.Add("onclick", "return ConfirmOnClick()")

        Else
            Me.Server.Transfer("../show_err.aspx")
        End If

    End Sub



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click


        Dim frm As Integer = Session("firm_id")  'CRF 70007003 By Megha P k Post Duplication Jwell
        UserAll = Me.Session("user_id").ToString.Split("!")
        Dim approved_By As String = UserAll(0)
        Dim fl As Integer
        Dim valrd1 As String


        If ddlMainDept.SelectedValue = "n-n" Or ddlMainDept.SelectedValue = "-1" Or ddlMainDept.SelectedValue = "0-0" Then

            Dim script As String = "alert('Please select a value from the dropdown.');"
            ClientScript.RegisterStartupScript(Me.GetType(), "alertScript", script, True)
        Else
            If Me.rdDept.Checked = True Then

                fl = 4
                valrd1 = Me.ddlMainDept.SelectedItem.Text & "*" & Me.ddlMainDept.SelectedValue

            ElseIf Me.rdPost.Checked = True Then

                fl = 5
                valrd1 = Me.ddlMainDept.SelectedItem.Text & "*" & Me.ddlMainDept.SelectedValue

            Else

                fl = 6
                valrd1 = Me.ddlMainDept.SelectedItem.Text & "*" & Me.ddlMainDept.SelectedValue

            End If
            Try
                Dim pr(7) As OracleParameter

                pr(0) = New OracleParameter("fl", OracleType.Number, 5)
                pr(0).Value = fl

                pr(1) = New OracleParameter("valrd", OracleType.Number, 10)
                pr(1).Value = 0

                pr(2) = New OracleParameter("dattxt", OracleType.VarChar, 50)
                'pr(2).Value = Me.txtdpd.Text
                pr(2).Value = ""

                pr(3) = New OracleParameter("msg", OracleType.VarChar, 50)
                pr(3).Direction = ParameterDirection.Output

                pr(4) = New OracleParameter("frm", OracleType.Number, 5)
                pr(4).Value = frm

                pr(5) = New OracleParameter("valrd1", OracleType.VarChar, 50)
                pr(5).Value = valrd1

                pr(6) = New OracleParameter("enter_By", OracleType.Number, 5)
                pr(6).Value = 0

                pr(7) = New OracleParameter("approve_By", OracleType.Number, 5)
                pr(7).Value = approved_By


                oh.ExecuteNonQuery("HRM_DEP_POST_DES_MACOM", pr)

                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('" & pr(3).Value & "');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Me.txtdpd.Text = ""
                ddlMainDept.Items.Remove(ddlMainDept.SelectedItem)
                Me.ddlMainDept.SelectedValue = "n-n"

            Catch ex As Exception

            End Try
        End If
        'Dim cl_script As New System.Text.StringBuilder
        'cl_script.Append("window.open('hrm_dept_post_des_approve.aspx','_self');")
        'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script.ToString, True)
    End Sub

End Class