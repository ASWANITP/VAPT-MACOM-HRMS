Imports System.Data
Imports System.Data.OracleClient
Partial Class Qualification_Addition_hrm_qualification_edit_617290ae5796
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn, str_tkn1 As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "Qualification/Experiance Addition"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.subtitle = "Qualification/Experiance Addition"

        'UserAll = Me.Session("user_id").ToString.Split("!")
        'UserCode = UserAll(0)
        Dim apno As Integer = Me.Request.QueryString("appno")
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtAppno.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)

        If Not IsPostBack Then
            Dim dt As DataTable = oh.ExecuteDataSet("select ap.appln_name from appln_pers_dtl ap where ap.appln_no=" & apno).Tables(0)
            Me.txtName.Text = dt.Rows(0)(0)
            Me.txtAppno.Text = apno

            dt1 = oh.ExecuteDataSet("select -1 as qualid ,'--------SELECT--------' as qual from dual union all select t.qualification_id ,t.qualification from qualification_master t order by qual").Tables(0)
            Me.ddlQual.DataSource = dt1
            Me.ddlQual.DataValueField = dt1.Columns(0).ColumnName
            Me.ddlQual.DataTextField = dt1.Columns(1).ColumnName
            Me.ddlQual.DataBind()
            Me.ddlQual.Focus()
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

               
                dt2 = oh.ExecuteDataSet("select q.appln_no||'*'|| p.appln_name||'*'||m.qualification||'*'||q.institution||'*'||q.university||'*'||q.percentage||'*'||q.year_pass||'*'||q.sq_no||'*'||m.qualification_id from appln_qualif_dtl q , appln_pers_dtl p ,qualification_master m where q.appln_no=p.appln_no and q.qualification=m.qualification_id and q.appln_no=" & str(1) & " ").Tables(0)
                Dim dr As DataRow

                For Each dr In dt2.Rows
                    str_tkn.Append(dr(0))
                    str_tkn.Append("!")
                Next
                str_tkn.Append("@")


                dt1 = oh.ExecuteDataSet("select e.appln_no||'*'||e.organisation||'*'||e.designation||'*'||e.exp_fromdt||'*'||e.exp_todt||'*'||e.nature_duty||'*'||e.cont_person||'*'||e.cont_phone||'*'||e.releaving_reason||'*'||e.present_salary||'*'||e.sq_no from appln_exp_dtl e where e.appln_no=" & str(1) & " ").Tables(0)
                Dim dr1 As DataRow

                For Each dr1 In dt1.Rows
                    str_tkn.Append(dr1(0))
                    str_tkn.Append("!")
                Next
                str_tkn.Append("@")
                cbResult = str_tkn.ToString

        End Select
    End Sub

     Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Try
            Dim p(4) As OracleParameter

            p(0) = New OracleParameter("apno", OracleType.Number, 6)
            p(0).Value = Me.txtAppno.Text

            p(1) = New OracleParameter("QualData", OracleType.VarChar, 5000)
            p(1).Value = Me.Hidden1.Value

            p(2) = New OracleParameter("ExpData", OracleType.VarChar, 5000)
            p(2).Value = Me.Hidden2.Value

            p(3) = New OracleParameter("msg", OracleType.VarChar, 100)
            p(3).Direction = ParameterDirection.Output

            p(4) = New OracleParameter("flag", OracleType.Number)
            p(4).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("appln_edit_qualification", p)

            str_tkn.Append("         alert('" & p(3).Value & "');")
            If p(4).Value = 0 Then
                str_tkn.Append(" window.open('../../home.aspx','_self');")
            End If
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        Catch ex As Exception

        End Try

      
    End Sub
End Class
