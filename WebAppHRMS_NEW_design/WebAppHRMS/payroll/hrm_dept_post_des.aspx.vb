Imports System.Data
Imports System.Data.OracleClient
Partial Class RajDeptPost_hrm_dept_post_des_ce46433c9615
    Inherits System.Web.UI.Page

    Dim cbResult As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode As Integer
    Dim strResult As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim script_val As String
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Add Department/Post/Designation"
        script_val = "var header;" & "header='" & Me.ddlMainDept.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=244 and emp_id=" & UserCode).Tables(0).Rows(0)(0)
        If acce > 0 Then
            If Not IsPostBack Then
                dt = oh.ExecuteDataSet("select -1 as dept_no, '------select------' as dept_name from dual union all select t.Department_id, t.department_name as dept_name from department_major t order by dept_name").Tables(0)
                Me.ddlMainDept.DataSource = dt
                Me.ddlMainDept.DataValueField = dt.Columns(0).ColumnName
                Me.ddlMainDept.DataTextField = dt.Columns(1).ColumnName
                Me.ddlMainDept.DataBind()
                dt = oh.ExecuteDataSet("select -1 as Grade_Id, '------select------' as Grade_name from dual union all select t.grade_id, t.grade as Grade_name from grade_master t order by grade_id").Tables(0)
                Me.ddlGrade.DataSource = dt
                Me.ddlGrade.DataValueField = dt.Columns(0).ColumnName
                Me.ddlGrade.DataTextField = dt.Columns(1).ColumnName
                Me.ddlGrade.DataBind()
            End If

            Me.btnConfirm.Attributes.Add("onclick", "return ConfirmOnClick()")

        Else
            Me.Server.Transfer("../show_err.aspx")
        End If




    End Sub



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim frm As Integer = Session("firm_id")  'CRF 70007003 By Megha P k Post Duplication Jwell
        Dim fl As Integer
        Dim valrd As Integer
        UserAll = Me.Session("user_id").ToString.Split("!")
        Dim enter_By As String = UserAll(0)
        If Me.rdDept.Checked = True Then
            fl = 1
            valrd = Me.ddlMainDept.SelectedValue

        ElseIf Me.rdPost.Checked = True Then
            fl = 2
            valrd = 0
        Else
            fl = 3
            valrd = Me.ddlGrade.SelectedValue

        End If
        Try
            Dim pr(7) As OracleParameter

            pr(0) = New OracleParameter("fl", OracleType.Number, 5)
            pr(0).Value = fl

            pr(1) = New OracleParameter("valrd", OracleType.Number, 10)
            pr(1).Value = valrd

            pr(2) = New OracleParameter("dattxt", OracleType.VarChar, 50)
            pr(2).Value = Me.txtdpd.Text

            pr(3) = New OracleParameter("msg", OracleType.VarChar, 50)
            pr(3).Direction = ParameterDirection.Output

            pr(4) = New OracleParameter("frm", OracleType.Number, 5)
            pr(4).Value = frm

            pr(5) = New OracleParameter("valrd1", OracleType.VarChar, 50)
            pr(5).Value = ""

            pr(6) = New OracleParameter("enter_By", OracleType.Number, 6)
            pr(6).Value = enter_By

            pr(7) = New OracleParameter("approve_By", OracleType.Number, 6)
            pr(7).Value = 0



            oh.ExecuteNonQuery("HRM_DEP_POST_DES_MACOM", pr)

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & pr(3).Value & "');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Me.txtdpd.Text = ""
            Me.ddlMainDept.SelectedValue = -1
            Me.ddlGrade.SelectedValue = -1
        Catch ex As Exception

        End Try
    End Sub
End Class
