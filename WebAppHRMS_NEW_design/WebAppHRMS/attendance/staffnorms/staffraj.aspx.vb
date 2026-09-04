Imports System.Data
Imports System.Data.OracleClient
Partial Class satffnorms_staffraj_acbe912b6339
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim str1, str2, str3 As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Staff norms other updating form"
        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.TxtStaff.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)

        Dim usr() As String
        usr = Session("user_id").ToString().Split("!")
        If Not IsPostBack Then
            dt = oh.ExecuteDataSet("select t.emp_id from form_accessibility t where t.emp_id=" & usr(0) & " and t.form_id=65").Tables(0)
            If dt.Rows.Count = 0 Then
                Server.Transfer("../../show_err.aspx")
            Else
                str1 = "select zonal_id,zonal_name from zonal_master order by zonal_name"
                dt = oh.ExecuteDataSet(str1).Tables(0)
                Cmb_zone.DataSource = dt
                Cmb_zone.DataTextField = dt.Columns(1).ColumnName
                Cmb_zone.DataValueField = dt.Columns(0).ColumnName
                Cmb_zone.DataBind()


                str2 = "select norms_id,norm_for from staff_norm_other where zonal_id=" & Cmb_zone.SelectedValue & ""
                dt1 = oh.ExecuteDataSet(str2).Tables(0)
                Cmb_Norm.DataSource = dt1
                Cmb_Norm.DataTextField = dt1.Columns(1).ColumnName
                Cmb_Norm.DataValueField = dt1.Columns(0).ColumnName
                Cmb_Norm.DataBind()

                dt2 = oh.ExecuteDataSet("select no_of_staff from staff_norm_other where zonal_id=" & Cmb_zone.SelectedValue & "and norms_id=" & Cmb_Norm.SelectedValue).Tables(0)
                TxtStaff.Text = dt2.Rows(0)(0)
                Hid_staff.Value = dt2.Rows(0)(0)
            End If

        End If
    End Sub
   
    Protected Sub CmdUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdUpdate.Click
        Try
            oh.ExecuteNonQuery("update staff_norm_other set no_of_staff=" & TxtStaff.Text & " where zonal_id=" & Cmb_zone.SelectedValue & " and norms_id=" & Cmb_Norm.SelectedValue)
            Dim cl_script0 As New StringBuilder
            cl_script0.Append("   alert('Successfully Updated!!') ;")
            cl_script0.Append("       window.open('../../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script0.ToString, True)
           

        Catch ex As Exception
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('ERROR OCCURED!! PLEASE TRY LATER!!') ;")
            cl_script.Append("       window.open('../../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
        Finally
        End Try
    End Sub

    Protected Sub Cmb_zone_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmb_zone.SelectedIndexChanged
        str2 = "select norms_id,norm_for from staff_norm_other where zonal_id=" & Cmb_zone.SelectedValue & ""
        dt1 = oh.ExecuteDataSet(str2).Tables(0)
        Cmb_Norm.DataSource = dt1
        Cmb_Norm.DataTextField = dt1.Columns(1).ColumnName
        Cmb_Norm.DataValueField = dt1.Columns(0).ColumnName
        Cmb_Norm.DataBind()


        dt2 = oh.ExecuteDataSet("select no_of_staff from staff_norm_other where zonal_id=" & Cmb_zone.SelectedValue & "and norms_id=" & Cmb_Norm.SelectedValue).Tables(0)
        TxtStaff.Text = dt2.Rows(0)(0)
        Hid_staff.Value = dt2.Rows(0)(0)

       

    End Sub

    Protected Sub Cmb_Norm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmb_Norm.SelectedIndexChanged
        dt2 = oh.ExecuteDataSet("select no_of_staff from staff_norm_other where zonal_id=" & Cmb_zone.SelectedValue & "and norms_id=" & Cmb_Norm.SelectedValue).Tables(0)
        TxtStaff.Text = dt2.Rows(0)(0)
        Hid_staff.Value = dt2.Rows(0)(0)

    End Sub
End Class
