Imports System.Data
Imports System.Data.OracleClient
Partial Class LeaveApplication_Leave_Updation_70eeaa418351
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim ds, dts As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim users() As String = Me.Session("user_id").ToString.Split("!")
        dts = oh.ExecuteDataSet("select * from form_accessibility where emp_id=" & users(0) & " and form_id=5157").Tables(0)
        If dts.Rows.Count > 0 Then
            If Not IsPostBack Then

                Dim dtb As New DataTable
                Dim str As String = "select category_id,upper(CATEGORY_NAME) from  hrm_category_master   where STATUS_ID=1 order by 2"
                dtb = oh.ExecuteDataSet(str).Tables(0)

                If dtb.Rows.Count > 0 Then

                    Me.ddl_category.DataSource = dtb
                    Me.ddl_category.DataTextField = dtb.Columns(1).ColumnName
                    Me.ddl_category.DataValueField = dtb.Columns(0).ColumnName
                    Me.ddl_category.DataBind()
                    Me.ddl_category.Items.Insert(0, New ListItem("Select", "-1"))
                Else

                    Me.ddl_category.Items.Clear()
                    Me.ddl_category.Items.Insert(0, New ListItem("Select", "-1"))
                    Me.ddl_category.SelectedValue = -1

                End If


            End If
        Else
            Me.Server.Transfer("../show_err.aspx")
        End If

    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.yesCheck.Checked = True Then
           
            Dim dtb As New DataTable
            Dim stn As String = "select nvl(max(h.category_id),0) + 1  from hrm_category_master h"
            dtb = oh.ExecuteDataSet(stn).Tables(0)
            Dim st As String = "insert into hrm_category_master(category_id, category_name, status_id) values(" & dtb.Rows(0)(0) & ",'" & txtcategory.Text.Replace("'", "''") & "',1) "
            oh.ExecuteNonQuery(st)

            Dim cl_script As New StringBuilder
            cl_script.Append(" alert('category Inserted');")
            cl_script.Append(" window.open('leave_updation.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            txtcategory.Text = ""

        Else
            Dim catre(2) As OracleParameter


            catre(0) = New OracleParameter("reaso_name", OracleType.VarChar, 500)
            catre(0).Direction = ParameterDirection.Input
            catre(0).Value = Me.txtreason.Text

            catre(1) = New OracleParameter("catego_id", OracleType.Number, 10)
            catre(1).Direction = ParameterDirection.Input
            catre(1).Value = ddl_category.SelectedValue

            catre(2) = New OracleParameter("msg", OracleType.VarChar, 500)
            catre(2).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_leave_reason_update", catre)
            Dim cl_script As New StringBuilder
            cl_script.Append(" alert('" & catre(2).Value & "');")
            cl_script.Append(" window.open('leave_updation.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            txtreason.Text = ""
            ddl_category.SelectedItem.Text = ""
        End If
    End Sub

    Protected Sub ddl_category_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_category.SelectedIndexChanged
        Dim dtb As New DataTable
        Dim stn As String = "select CATEGORY_ID from hrm_category_master where CATEGORY_NAME = '" & ddl_category.SelectedItem.Text & "' "
        dtb = oh.ExecuteDataSet(stn).Tables(0)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("~\home.aspx")
    End Sub
End Class
