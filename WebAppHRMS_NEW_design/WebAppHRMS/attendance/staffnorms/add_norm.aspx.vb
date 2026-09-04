Imports System.Data
Imports System.Data.OracleClient
Partial Class audit_staffnorm_audit_norm_cf88f00a6132
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dts As New DataTable
    Dim strResult As New System.Text.StringBuilder
    Dim UserAll(), res, sql, str As String
    Dim UserCode, BranchID, PostID, AreaID, RegionID, ZonalID, DepID, OpHead As Integer
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dts1 As DataTable = oh.ExecuteDataSet("select query from hrm_report_master where firm_id=99 and query_id=134").Tables(0)
        Dim strd() As String = dts1.Rows(0)(0).ToString.Split("#")
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)

        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        dts = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=6013 and emp_id=" & User(0) & "").Tables(0)
        If dts.Rows(0)(0) = 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
            cl_script0.Append("window.open('../../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If




        dt1 = oh.ExecuteDataSet(strd(6).Replace("mybranch", UserCode)).Tables(0)
        If dt1.Rows(0)(0) > 0 Then

            If Not IsPostBack = True Then
                'dt = oh.ExecuteDataSet(strd(7)).Tables(0)
                'Me.drpdwn_region.DataSource = dt
                'Me.drpdwn_region.DataValueField = dt.Columns(1).ColumnName
                'Me.drpdwn_region.DataTextField = dt.Columns(0).ColumnName
                'Me.drpdwn_region.DataBind()
                'Me.drpdwn_region.Focus()

                dt2 = oh.ExecuteDataSet(strd(8)).Tables(0)
                Me.drp_post.DataSource = dt2
                Me.drp_post.DataValueField = dt2.Columns(1).ColumnName
                Me.drp_post.DataTextField = dt2.Columns(0).ColumnName
                Me.drp_post.DataBind()
            End If
        Else
            Me.Server.Transfer("../../show_err.aspx")
        End If

    End Sub

    Protected Sub btn_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_confirm.Click

        'If Me.drpdwn_region.SelectedValue = -1 Then
        '    Dim cl_script021 As New System.Text.StringBuilder
        '    cl_script021.Append("         alert('Please Select branch');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script021.ToString, True)
        '    Exit Sub
        'End If
        If Me.drp_post.SelectedValue = -1 = -1 Then
            Dim cl_script021 As New System.Text.StringBuilder
            cl_script021.Append("         alert('Please Select department');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script021.ToString, True)
            Exit Sub
        End If
        If Me.txt_req_num.Text = "" Then
            Dim cl_script021 As New System.Text.StringBuilder
            cl_script021.Append("         alert('Please Enter Required Number');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script021.ToString, True)
            Me.txt_req_num.Text = ""
            Exit Sub
        End If

        Try


            Dim parcol(3) As OracleParameter

            parcol(0) = New OracleParameter("br_id", OracleType.Number, 50)
            parcol(0).Value = 0
            parcol(0).Direction = ParameterDirection.Input


            parcol(1) = New OracleParameter("dep_id", OracleType.Number, 50)
            parcol(1).Value = Me.drp_post.SelectedValue
            parcol(1).Direction = ParameterDirection.Input


            parcol(2) = New OracleParameter("reqnm", OracleType.Number, 50)
            parcol(2).Value = Me.txt_req_num.Text
            parcol(2).Direction = ParameterDirection.Input

            parcol(3) = New OracleParameter("msg", OracleType.VarChar, 100)
            parcol(3).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("STAFFNORM_upd_macom", parcol)

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & parcol(3).Value & "');")
            cl_script1.Append(" window.open('add_norm.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Catch ex As Exception

        End Try

    End Sub

    'Protected Sub drpdwn_region_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpdwn_region.SelectedIndexChanged
    '    Dim dts1 As DataTable = oh.ExecuteDataSet("select query from hrm_report_master where firm_id=99 and query_id=134").Tables(0)
    '    Dim strd() As String = dts1.Rows(0)(0).ToString.Split("#")
    '    dt2 = oh.ExecuteDataSet(strd(8).Replace("mybranch", Me.drpdwn_region.SelectedValue)).Tables(0)
    '    Me.drp_post.DataSource = dt2
    '    Me.drp_post.DataValueField = dt2.Columns(1).ColumnName
    '    Me.drp_post.DataTextField = dt2.Columns(0).ColumnName
    '    Me.drp_post.DataBind()
    '    Me.drp_post.Focus()
    'End Sub

    Protected Sub txt_req_num_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_req_num.TextChanged
        Dim arr() As String = {")", "(", "!", "@", "#", "$", "%", "^", "&", "*", "<", ">", "/", "\", "."}
        Dim pass As String = Me.txt_req_num.Text
        For Each gh As String In arr
            If pass.Contains(gh) Then
                Dim cl_script021 As New System.Text.StringBuilder
                cl_script021.Append("         alert('Special Characters Are Not Allowed In Required Number !!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script021.ToString, True)
                Me.txt_req_num.Text = ""
                Exit Sub
            End If
        Next
    End Sub
End Class
