Imports System.Data
Imports System.Data.OracleClient
Imports System.IO

Partial Class salaryvda_b9f3103f2291

    Inherits System.Web.UI.Page

    Dim RH As New WholeHelper.ClsRepCtrl
    Dim oh As New Helper.Oracle.OracleHelper

    Dim dt, dt1 As New DataTable
    Dim res, fid As String
    Dim state As String




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CType(Me.Master, WebAppHRMS.edp).Subtitle = "<B><U>NEW VDA</U></B>"
        dt = oh.ExecuteDataSet("SELECT '01'||substr(sysdate,3) AS first_day_of_current_month FROM dual").Tables(0)
        Dim temp As String
        temp = dt.Rows(0)(0).ToString()
        Me.dt_effect.Text = temp

        If Not IsPostBack Then
            statefill(Me.cmb_State)

        End If


        Dim cs As String = "var cont_name;cont_name='" & Me.txt_newda.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        Me.txt_newda.Attributes.Add("onkeypress", "return isNumberKey(event)")

        'If Session("access_id") = 33 Then
        '    Dim formaccess As DataTable = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=814 and emp_id=" & Session("user_id").ToString.Split("!")(0)).Tables(0)
        '    If formaccess.Rows(0)(0) = 0 Then
        '        Dim script1 As New System.Text.StringBuilder
        '        script1.Append("        alert('You are not Authorized');")
        '        script1.Append("window.open('../home.aspx','_self');")
        '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        '    End If
        '    Me.dt_effect.Text = Format(Now.Date, "dd/MMM/yyyy")
        '    Me.txt_preda.Text = ""


        'Else
        '    If Not IsPostBack Then

        '        Dim script1 As New System.Text.StringBuilder
        '        script1.Append("        alert('You are not Authorized');")
        '        script1.Append("window.open('../home.aspx','_self');")
        '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        '    End If
        'End If


    End Sub

    'Sub statefill(ByVal a As DropDownList)
    '    dt = oh.ExecuteDataSet("select '---- SELECT-----' as state_name,0 from dual union select upper(state_name), state_id from state_master order by state_name").Tables(0)
    '    a.DataSource = dt
    '    a.DataTextField = dt.Columns(0).ColumnName
    '    a.DataValueField = dt.Columns(1).ColumnName
    '    state = a.DataValueField
    '    a.DataBind()

    'End Sub

    'Private Sub cmb_State_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmb_State.SelectedIndexChanged

    '    Dim state As String = cmb_State.SelectedValue.ToString()
    '    statefill(state, Me.cmb_State)

    'End Sub
    Sub statefill(ByVal a As DropDownList)
        dt = oh.ExecuteDataSet("select '---- SELECT-----' as state_name,0 from dual union select upper(state_name), state_id from state_master order by state_name").Tables(0)
        a.DataSource = dt
        a.DataTextField = dt.Columns(0).ColumnName
        a.DataValueField = dt.Columns(1).ColumnName
        state = a.DataValueField
        a.DataBind()

    End Sub
    Protected Sub Btn_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_confirm.Click



        If cmb_State.SelectedValue = 0 Then
          
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select State!!');")
            'cl_script1.Append("         window.open('salaryvda_statewise.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        End If
  

        If txt_newda.Text = "" Then
           
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Enter New DA!!');")
            'cl_script1.Append("         window.open('salaryvda_statewise.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub

        End If

        If txt_preda.Text = "" Then

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('error!!');")
            cl_script1.Append("         window.open('salaryvda_statewise.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub

        End If



        If dt_effect.Text = "" Then
          
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('please select date!!');")
            'cl_script1.Append("         window.open('salaryvda_statewise.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub

            Exit Sub
        End If

          


        oh.ExecuteNonQuery("update da_index_statewise set to_dt=to_date('" & Me.dt_effect.Text & "')-1 where to_dt is null and firm_id=" & Session("firm_id") & "and state=(" & Me.cmb_State.SelectedValue & ")")
        oh.ExecuteNonQuery("insert into da_index_statewise(value,from_dt,to_dt,enter_dt,firm_id,state) values(" & Val(Me.txt_newda.Text) & ",to_date('" & Me.dt_effect.Text & "'),null,to_date('" & Format(Now.Date, "dd/MMM/yyyy") & "')," & Session("firm_id") & "," & Me.cmb_State.SelectedValue & ")")

        Dim script1 As New System.Text.StringBuilder
        script1.Append("alert('Successfully Saved');")
        script1.Append("window.open('salaryvda_statewise.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)



    End Sub

    Protected Sub cmb_District_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_State.SelectedIndexChanged
        Dim dt As DataTable
        dt = oh.ExecuteDataSet("select value from da_index_statewise where to_dt is null and state= " & Me.cmb_State.SelectedValue & " and firm_id=" & Session("firm_id") & "").Tables(0)
        If dt.Rows.Count >= 1 Then
            Me.txt_preda.Text = dt.Rows(0)(0)
        Else
            Me.txt_preda.Text = "Not Updated Yet"

        End If

    End Sub

    Protected Sub txt_preda_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_preda.TextChanged

    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Server.Transfer("../home.aspx")

    End Sub
End Class
