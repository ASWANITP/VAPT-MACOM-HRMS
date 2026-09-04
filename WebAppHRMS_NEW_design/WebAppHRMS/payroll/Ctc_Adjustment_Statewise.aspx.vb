Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Partial Class jewel_Ctc_Adjustment_Statewise_76d1f4866604
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim RH As New WholeHelper.ClsRepCtrl
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim res, fid As String
    Dim state As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "<B><U>CTC Adjustment Updation</U></B>"
        If Not IsPostBack Then
            designation(Me.cmb_State)
            qualification(Me.cmb_emp)
        End If

        '----shima
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.cmb_State.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server(arg,context) { " & cbref & "; } "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
        '----shima



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
        'Dim sc As String = "var cont_name;cont_name='" & Me.txtBranch.ClientID & "';"
        'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var2", sc, True)
        Me.cmb_State.Attributes.Add("onchange", "emp_fill()")
        Me.cmb_emp.Attributes.Add("onchange", "quali_fill()")
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim x = str(0)
        Dim y = str(1)
        Dim z = str(2)
        Dim strr As New StringBuilder
        Dim backResult As String = ""   'shima
        Dim val As New StringBuilder
        Select Case (x)
            Case "1"
                Dim sfs() As String
                sfs = Session("user_id").ToString.Split("!")
                Dim sqo As String = "select nvl(sum(t.value),0) from CTC_desig_Updation t where to_dt is null and t.designation = " & y & " and t.qualification_cat_id = " & z & " and t.firm_id = " & Session("firm_id") & ""
                dt = oh.ExecuteDataSet(sqo).Tables(0)
                'dt = oh.ExecuteDataSet("select nvl(sum(t.value),0) from CTC_desig_Updation t where to_dt is null and t.designation = " & y & " and t.qualification_cat_id = " & z & " and t.firm_id = " & Session("firm_id") & "").Tables(0)
                strr.Append(dt.Rows(0)(0))
                '---shima

            Case "2"
                Dim sfs() As String
                sfs = Session("user_id").ToString.Split("!")
                Dim sqo As String = "select nvl(sum(t.value),0) from CTC_desig_Updation t where to_dt is null and t.designation = " & y & " and t.qualification_cat_id = " & z & " and t.firm_id = " & Session("firm_id") & ""
                dt = oh.ExecuteDataSet(sqo).Tables(0)
                'dt = oh.ExecuteDataSet("select nvl(sum(t.value),0) from CTC_desig_Updation t where to_dt is null and t.designation = " & y & " and t.qualification_cat_id = " & z & " and t.firm_id = " & Session("firm_id") & "").Tables(0)
                strr.Append(dt.Rows(0)(0))


                '----shima
        End Select
        res = strr.ToString
    End Sub

    Sub designation(ByVal a As DropDownList)
        dt = oh.ExecuteDataSet("select '------ SELECT -------' as designation, 0 from dual union select upper(d.designation), d.designation_id from DESIGNATION_MASTER d order by designation").Tables(0)
        a.DataSource = dt
        a.DataTextField = dt.Columns(0).ColumnName
        a.DataValueField = dt.Columns(1).ColumnName
        state = a.DataValueField
        a.DataBind()

    End Sub
    Sub qualification(ByVal a As DropDownList)
        dt = oh.ExecuteDataSet("select '------ SELECT -------' as category, 0 from dual union select upper(d.category), d.category_id from QUALIFICATION_CATEGORY d order by category").Tables(0)
        a.DataSource = dt
        a.DataTextField = dt.Columns(0).ColumnName
        a.DataValueField = dt.Columns(1).ColumnName
        state = a.DataValueField
        a.DataBind()

    End Sub


   
   

    Protected Sub Btn_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_confirm.Click



        If cmb_State.SelectedValue = "" Then
            MsgBox("Please Select Designation")
            'Me.txt_ser_text.Focus()
            Return
        End If


        If txt_newda.Text = "" Then
            MsgBox("Please Enter New CTC")
            'Me.txt_ser_text.Focus()
            Return
        End If
      

        oh.ExecuteNonQuery("update CTC_desig_Updation set to_dt=to_date('" & Me.dt_effect.Text & "')-1 where to_dt is null and designation=" & Me.cmb_State.SelectedValue & " and qualification_cat_id=" & Me.cmb_emp.SelectedValue & " and firm_id=" & Session("firm_id") & "")
        oh.ExecuteNonQuery("insert into CTC_desig_Updation(value,from_dt,to_dt,enter_dt,firm_id,designation,qualification_cat_id) values(" & Val(Me.txt_newda.Text) & ",to_date('" & Me.dt_effect.Text & "'),null,to_date('" & Format(Now.Date, "dd/MMM/yyyy") & "')," & Session("firm_id") & "," & Me.cmb_State.SelectedValue & "," & Me.cmb_emp.SelectedValue & ")")
        Dim script1 As New System.Text.StringBuilder
        script1.Append("alert('Successfully Saved');")

        script1.Append("window.open('../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)


    End Sub



End Class




