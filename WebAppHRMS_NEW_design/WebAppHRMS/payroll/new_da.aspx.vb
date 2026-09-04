Imports System.Data
Imports System.Data.OracleClient
Partial Class new_da_90b6f78f3496
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim frm As Integer = Session("firm_id")
        If frm = 28 Then
            Response.Redirect("salaryvda.aspx")
        Else
            If frm = 24 Then
                Response.Redirect("salaryvda_statewise.aspx")
                Exit Sub
            End If
        End If

        CType(Me.Master, WebAppHRMS.edp).Subtitle = "<B><U>NEW DA</U></B>"
        Dim cs As String = "var cont_name;cont_name='" & Me.txt_newda.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        Me.txt_newda.Attributes.Add("onkeypress", "return isNumberKey(event)")
        If Session("access_id") = 33 Then
            Dim formaccess As DataTable = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=183 and emp_id=" & Session("user_id").ToString.Split("!")(0)).Tables(0)
            If formaccess.Rows(0)(0) = 0 Then
                Dim script1 As New System.Text.StringBuilder
                script1.Append("        alert('You are not Authorized');")
                script1.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            End If
            If Not IsPostBack Then
                Me.dt_effect.Text = Format(Now.Date, "dd/MMM/yyyy")
                Me.txt_preda.Text = ""
                Dim dt As DataTable
                dt = oh.ExecuteDataSet("select value from da_index where to_dt is null and firm_id=" & Session("firm_id") & "").Tables(0)
                Me.txt_preda.Text = dt.Rows(0)(0)
                Me.txt_newda.Text = ""
            End If
        Else
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('You are not Authorized');")
            script1.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If
    End Sub
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If IsNumeric(Me.txt_newda.Text) Then
            oh.ExecuteNonQuery("update da_index set to_dt=to_date('" & Me.dt_effect.Text & "')-1 where to_dt is null and firm_id=" & Session("firm_id") & "")
            oh.ExecuteNonQuery("insert into da_index values(" & Val(Me.txt_newda.Text) & ",to_date('" & Me.dt_effect.Text & "'),null,to_date('" & Format(Now.Date, "dd/MMM/yyyy") & "')," & Session("firm_id") & ")")
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('Successfully Saved');")
            script1.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If
    End Sub
End Class
