Imports System.Data
Imports System.Data.OracleClient
Partial Class Qualification_Addition_hrm_qualification_add_cf9fd8193778
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult, fid As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fid = Session("firm_id")
        If fid = 27 Then
            Response.Redirect("hrm_qualification_add_mafarm.aspx")
            Exit Sub
        End If

        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "Qualification/Experiance Addition"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.Subtitle = "Qualification/Experience Addition"

        'UserAll = Me.Session("user_id").ToString.Split("!")
        'UserCode = UserAll(0)

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtAppno.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
        If Session("access_id") = 33 Then
            If Not IsPostBack Then
                dt1 = oh.ExecuteDataSet("select -1 as qualid ,'--------SELECT--------' as qual from dual union all select t.qualification_id ,t.qualification from qualification_master t order by qual").Tables(0)
                Me.ddlQual.DataSource = dt1
                Me.ddlQual.DataValueField = dt1.Columns(0).ColumnName
                Me.ddlQual.DataTextField = dt1.Columns(1).ColumnName
                Me.ddlQual.DataBind()
                Me.ddlQual.Focus()
            End If
        Else
            Server.Transfer("../../show_err.aspx")
        End If

    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return cbResult
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)

        Select Case (x)

            Case "1"

                dt = oh.ExecuteDataSet("select t.appln_name|| '*' ||t.birth_date from appln_pers_dtl t where not exists(select appln_no from appln_qualif_dtl q where q.appln_no=t.appln_no) and t.appln_no=" & str(1) & "").Tables(0)
                If dt.Rows.Count = 0 Then
                    str_tkn.Append("NULL")
                Else
                    str_tkn.Append(dt.Rows(0)(0))
                    cbResult = str_tkn.ToString
                End If
        End Select
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

        If Me.hdnQualAdd.Value = "" Then

            Me.hdnQualAdd.Value = 0

        End If

        If Me.hdnExpAdd.Value = "" Then

            Me.hdnExpAdd.Value = 0

        End If

        Try
            Dim p(5) As OracleParameter

            p(0) = New OracleParameter("Applno", OracleType.Number, 6)
            p(0).Value = Me.txtAppno.Text

            p(1) = New OracleParameter("QualData", OracleType.VarChar, 5000)
            p(1).Value = Me.hdnQualAdd.Value

            p(2) = New OracleParameter("Qualif", OracleType.Number, 5)
            p(2).Value = Me.hdnQual.Value

            p(3) = New OracleParameter("ExpData", OracleType.VarChar, 5000)
            p(3).Value = Me.hdnExpAdd.Value()

            p(4) = New OracleParameter("OutMsg", OracleType.VarChar, 100)
            p(4).Direction = ParameterDirection.Output

            p(5) = New OracleParameter("flag", OracleType.Number, 2)
            p(5).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_QualExp_add_proc", p)

            str_tkn.Append("         alert('" & p(4).Value & "');")
            If p(5).Value = 0 Then
                str_tkn.Append(" window.open('appl_other_detail.aspx?appln_no=" & Me.txtAppno.Text & " ','_self');")
            End If
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        Catch ex As Exception
        End Try
        Me.txtAppno.Text = ""
        Me.txtName.Text = ""
    End Sub

    Protected Sub txtAppno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAppno.TextChanged
        'Dim num As String
        Dim dt, dt1, dt2, dt3 As New DataTable
        dt = oh.ExecuteDataSet("select t.* from appln_qualif_dtl t where t.appln_no='" & txtAppno.Text & "'").Tables(0)
        dt1 = oh.ExecuteDataSet("select t.* from appln_exp_dtl t where t.appln_no='" & txtAppno.Text & "'").Tables(0)
        dt2 = oh.ExecuteDataSet("select t.* from appln_pers_dtl t where t.appln_no='" & txtAppno.Text & "'").Tables(0)

        If dt.Rows.Count > 0 Or dt1.Rows.Count > 0 Then
            str_tkn.Append("         alert('Application Number Details are entered');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
            txtAppno.Text = ""
            txtName.Text = ""
        ElseIf dt2.Rows.Count = 0 And dt.Rows.Count = 0 And dt1.Rows.Count = 0 Then
            'txtName.Text = dt.Rows(0)(1)
            'ddlQual.SelectedItem.Text = dt.Rows(0)(2)
            'txtInist.Text = dt.Rows(0)(3)
            'txtUni.Text = dt.Rows(0)(4)
            'txtYpass.Text = dt.Rows(0)(5)
            'txtMark.Text = dt.Rows(0)(6)

            str_tkn.Append("         alert('Please Enter Valid application Number');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
            txtAppno.Text = ""
            txtName.Text = ""
        ElseIf dt2.Rows.Count > 0 And dt.Rows.Count = 0 And dt1.Rows.Count = 0 Then
            dt3 = oh.ExecuteDataSet("select t.appln_name from appln_pers_dtl t where t.appln_no='" & txtAppno.Text & "'").Tables(0)
            Dim name As String = dt3.Rows(0)(0)
            txtName.Text = name
        End If


    End Sub
End Class
