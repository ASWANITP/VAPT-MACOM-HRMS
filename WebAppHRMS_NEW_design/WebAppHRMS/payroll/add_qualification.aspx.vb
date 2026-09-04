Imports System.Data
Imports System.Data.OracleClient
Partial Class Add_Qualification_add_qualification_e63994605043
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.Txt_qualification.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)


        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "ADD NEW QUALIFICATION"
        CType(Me.Master, WebAppHRMS.edp).subtitle = "ADD NEW QUALIFICATION"

        If Not IsPostBack Then
            If Session("access_id") = 33 Then
                Dim dt As New DataTable
                dt = oh.ExecuteDataSet("select category_id,category from qualification_category order by category_id").Tables(0)
                Me.cmb_category.DataSource = dt
                Me.cmb_category.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_category.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_category.DataBind()
            Else
                Server.Transfer("../show_err.aspx")
            End If

        End If
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Try
            Dim p(3) As OracleParameter

            p(0) = New OracleParameter("Userid", OracleType.Number, 6)
            p(0).Value = Me.Session("user_id").ToString.Split("!")(0)


            p(1) = New OracleParameter("Categoryid", OracleType.Number, 2)
            p(1).Value = Me.cmb_category.SelectedValue

            p(2) = New OracleParameter("qualif", OracleType.VarChar, 100)
            p(2).Value = Me.txt_qualification.Text

            p(3) = New OracleParameter("msg", OracleType.VarChar, 150)
            p(3).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_add_qualification_master", p)
            Dim str_tkn As New System.Text.StringBuilder

            str_tkn.Append("         alert('" & p(3).Value & "');")
            str_tkn.Append(" window.open('add_qualification.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        Catch ex As Exception
        End Try

    End Sub
End Class
