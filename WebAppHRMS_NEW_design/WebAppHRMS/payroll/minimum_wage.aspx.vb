Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Partial Class jewel_minimum_wage_1420c7683669
    Inherits System.Web.UI.Page
    Dim RH As New WholeHelper.ClsRepCtrl
    Dim oh As New Helper.Oracle.OracleHelper

    Dim dt, dt1 As New DataTable
    Dim res, fid As String
    Dim state As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CType(Me.Master, WebAppHRMS.edp).Subtitle = "<B><U>Minimum Wage Updation </U></B>"
        If Not IsPostBack Then
            statefill(Me.cmb_State)
            desfill(Me.cmb_des)
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
    Sub desfill(ByVal a As DropDownList)
        dt = oh.ExecuteDataSet("select '---- SELECT-----' as designation, 0 from dual union select upper(t.designation) as designation, t.designation_id from DESIGNATION_MASTER t where t.designation_id=1 union select 'OTHERS' as designation, 2 from dual order by designation").Tables(0)
        a.DataSource = dt
        a.DataTextField = dt.Columns(0).ColumnName
        a.DataValueField = dt.Columns(1).ColumnName
        state = a.DataValueField
        a.DataBind()

    End Sub

    'Private Sub cmb_State_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmb_State.SelectedIndexChanged

    '    Dim state As String = cmb_State.SelectedValue.ToString()
    '    Districtfill(state, Me.cmb_District)

    'End Sub
    'Sub Districtfill(ByVal state As String, ByVal b As DropDownList)
    '    Dim sta As String = state
    '    dt1 = oh.ExecuteDataSet("select '---- SELECT----' as district_name,0 from dual union select upper(district_name), district_id from district_master where state_id=" & sta).Tables(0)
    '    b.DataSource = dt1
    '    b.DataTextField = dt1.Columns(0).ColumnName
    '    b.DataValueField = dt1.Columns(1).ColumnName
    '    b.DataBind()


    'End Sub

    Protected Sub Btn_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_confirm.Click



        If cmb_State.SelectedValue = "" Then
            MsgBox("Please Select State")
            'Me.txt_ser_text.Focus()
            Return
        End If

        If cmb_des.SelectedValue = " " Then
            MsgBox("Please Select Designation")
            'Me.txt_ser_text.Focus()
            Return
        End If

        If txt_newda.Text = "" Then
            MsgBox("Please Enter New Minimum Wage")
            'Me.txt_ser_text.Focus()
            Return
        End If

        oh.ExecuteNonQuery("update DA_INDEX_STATEWISE_MINI set to_dt=to_date('" & Me.dt_effect.Text & "')-1 where to_dt is null and firm_id=" & Session("firm_id") & "   and desig_id =" & cmb_des.SelectedValue & "")
        'oh.ExecuteNonQuery("insert into DA_INDEX_STATEWISE_MINI(value,from_dt,to_dt,enter_dt,firm_id,state) values(" & Val(Me.txt_newda.Text) & ",to_date('" & Me.dt_effect.Text & "'),null,to_date('" & Format(Now.Date, "dd/MMM/yyyy") & "')," & Session("firm_id") & "," & Me.cmb_State.SelectedValue & ")")
        oh.ExecuteNonQuery("insert into DA_INDEX_STATEWISE_MINI(value,from_dt,to_dt,enter_dt,firm_id,state,desig_id) values(" & Val(Me.txt_newda.Text) & ",to_date('" & Me.dt_effect.Text & "'),null,to_date('" & Format(Now.Date, "dd/MMM/yyyy") & "')," & Session("firm_id") & ",'" & Me.cmb_State.SelectedValue & "',' " & Me.cmb_des.SelectedValue & "')")
        Dim script1 As New System.Text.StringBuilder
        script1.Append("alert('Successfully Saved');")
        script1.Append("window.open('../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

    End Sub

    Protected Sub cmb_State_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_State.SelectedIndexChanged
        Dim dt As DataTable
        dt = oh.ExecuteDataSet("select value from DA_INDEX_STATEWISE_MINI t where to_dt is null and t.state= " & Me.cmb_State.SelectedValue & " and t.firm_id=" & Session("firm_id") & " and desig_id =" & cmb_des.SelectedValue & "").Tables(0)
        If dt.Rows.Count >= 1 Then
            Me.txt_preda.Text = dt.Rows(0)(0)
        Else
            Me.txt_preda.Text = "Not Updated Yet"

        End If

    End Sub
End Class


