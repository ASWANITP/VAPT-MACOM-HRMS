Imports System.Data
Imports System.Data.OracleClient
Imports System.IO

Partial Class salaryvda_b9f3103f3404

    Inherits System.Web.UI.Page

    Dim RH As New WholeHelper.ClsRepCtrl
    Dim oh As New Helper.Oracle.OracleHelper

    Dim dt, dt1 As New DataTable
    Dim res, fid As String
    Dim state As String




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CType(Me.Master, WebAppHRMS.edp).Subtitle = "<B><U>NEW VDA</U></B>"


        If Not IsPostBack Then
            statefill(Me.cmb_State)

        End If


        Dim cs As String = "var cont_name;cont_name='" & Me.txt_newda.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        Me.txt_newda.Attributes.Add("onkeypress", "return isNumberKey(event)")

        If Session("access_id") = 33 Then
            Dim formaccess As DataTable = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=814 and emp_id=" & Session("user_id").ToString.Split("!")(0)).Tables(0)
            If formaccess.Rows(0)(0) = 0 Then
                Dim script1 As New System.Text.StringBuilder
                script1.Append("        alert('You are not Authorized');")
                script1.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            End If
            Me.dt_effect.Text = Format(Now.Date, "dd/MMM/yyyy")
            Me.txt_preda.Text = ""
        

        Else
            If Not IsPostBack Then

                Dim script1 As New System.Text.StringBuilder
                script1.Append("        alert('You are not Authorized');")
                script1.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            End If
        End If


    End Sub

    Sub statefill(ByVal a As DropDownList)
        dt = oh.ExecuteDataSet("select '---- SELECT-----' as state_name,0 from dual union select upper(state_name), state_id from state_master order by state_name").Tables(0)
        a.DataSource = dt
        a.DataTextField = dt.Columns(0).ColumnName
        a.DataValueField = dt.Columns(1).ColumnName
        state = a.DataValueField
        a.DataBind()

    End Sub

    Private Sub cmb_State_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmb_State.SelectedIndexChanged

        Dim state As String = cmb_State.SelectedValue.ToString()
        Districtfill(state, Me.cmb_District)

    End Sub
    Sub Districtfill(ByVal state As String, ByVal b As DropDownList)
        Dim sta As String = state
        dt1 = oh.ExecuteDataSet("select '---- SELECT----' as district_name,0 from dual union select upper(district_name), district_id from district_master where state_id=" & sta).Tables(0)
        b.DataSource = dt1
        b.DataTextField = dt1.Columns(0).ColumnName
        b.DataValueField = dt1.Columns(1).ColumnName
        b.DataBind()

       
    End Sub

    Protected Sub Btn_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_confirm.Click



        If cmb_State.SelectedValue = "" Then
            MsgBox("Please Select State")
            'Me.txt_ser_text.Focus()
            Return
        End If

        If cmb_District.SelectedValue = " " Then
            MsgBox("Please Select District")
            'Me.txt_ser_text.Focus()
            Return
        End If

        If txt_newda.Text = "" Then
            MsgBox("Please Enter New DA")
            'Me.txt_ser_text.Focus()
            Return
        End If

        oh.ExecuteNonQuery("update da_index_districtwise set to_dt=to_date('" & Me.dt_effect.Text & "')-1 where to_dt is null and firm_id=" & Session("firm_id") & " and district=" & Me.cmb_District.SelectedValue & "")
        oh.ExecuteNonQuery("insert into da_index_districtwise(value,from_dt,to_dt,enter_dt,firm_id,district) values(" & Val(Me.txt_newda.Text) & ",to_date('" & Me.dt_effect.Text & "'),null,sysdate," & Session("firm_id") & "," & Me.cmb_District.SelectedValue & ")")
        Dim script1 As New System.Text.StringBuilder
        script1.Append("alert('Successfully Saved');")
        script1.Append("window.open('../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

    End Sub

    Protected Sub cmb_District_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_District.SelectedIndexChanged
        Dim dt As DataTable
        dt = oh.ExecuteDataSet("select value from da_index_districtwise where to_dt is null and district= " & Me.cmb_District.SelectedValue & " and firm_id=" & Session("firm_id") & "").Tables(0)
        If dt.Rows.Count >= 1 Then
            Me.txt_preda.Text = dt.Rows(0)(0)
        Else
            Me.txt_preda.Text = "Not Updated Yet"

        End If

    End Sub
End Class
