Imports System.Data
Imports System.Data.OracleClient
Partial Class transferreport_transfer_report_a9d301e76240
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler

    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim result As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim user() As String
        'Dim firm As Integer = Session("firm_id")
        user = Session("user_id").ToString.Split("!")

       
        Dim scr As String
        scr = "var header;" & "header='" & Me.txtEmpcode.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", scr, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        Me.txtEmpcode.Attributes.Add("onblur", "Validate()")
        ' ''Session("firm_id") = 8
        If Not IsPostBack Then
            'dt = oh.ExecuteDataSet("select emp_code||'---'||emp_name,emp_code from employee_master where emp_code > 10000 order by emp_code ").Tables(0)
            'Me.cmb_select.DataSource = dt
            'Me.cmb_select.DataTextField = dt.Columns(0).ColumnName
            'Me.cmb_select.DataValueField = dt.Columns(1).ColumnName
            'Me.cmb_select.DataBind()
            Me.Txt_fdt.Text = Format(CDate("15/AUG/1947"), "dd/MMM/yyyy")
            Me.Txt_tdt.Text = Format(Date.Today, "dd/MMM/yyyy")
        End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return result
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim ds As New DataSet
        ds = oh.ExecuteDataSet("select e.emp_code||'---'||e.emp_name,e.emp_code,e.emp_name from employee_master e, employ_firm f where e.emp_code > 10000 and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.emp_code=" + eventArgument)
        If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            result = 1 & "@" & ds.Tables(0).Rows(0)("emp_name").ToString
        Else
            result = 0 & "@" & ""
        End If
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim user() As String
        user = Session("user_id").ToString.Split("!")


        '--------------- ReqID 8592 starts------------------------------
        If Session("firm_id") = 8 Then

            '---------------------end-------------------------------------


            If Me.txtEmpcode.Text = user(0) Then


                dt1 = oh.ExecuteDataSet("select e.emp_code from employee_master e,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.emp_code=" & Me.txtEmpcode.Text.Trim & " ").Tables(0)

                If (dt1.Rows.Count = 1) Then

                    If (CDate(Me.Txt_fdt.Text) <= CDate(Me.Txt_tdt.Text)) Then
                        Server.Transfer("transfer_display_report.aspx?emp=" & Me.txtEmpcode.Text.Trim & "&f_dt=" & Me.Txt_fdt.Text & "&t_dt=" & Me.Txt_tdt.Text)
                    Else
                        Dim msgbx As New System.Text.StringBuilder
                        msgbx.Append("         alert('PLEASE Check the date' );")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                        Exit Sub
                    End If
                Else
                    Dim msgbx As New System.Text.StringBuilder
                    msgbx.Append("         alert('PLEASE Check the Employee code' );")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                    Exit Sub
                End If
            Else
                Dim dhead As Integer
                Dim hr As Integer
                hr = oh.ExecuteDataSet("select t.access_id  from employee_master t where t.emp_code =" & user(0) & "").Tables(0).Rows(0)(0)

                dhead = oh.ExecuteDataSet("select d.dep_head from employee_master t,department_mst d where d.dep_id=t.department_id and t.emp_code=" & Me.txtEmpcode.Text & "").Tables(0).Rows(0)(0)

                If user(0) = dhead Or hr = 33 Then
                    dt1 = oh.ExecuteDataSet("select e.emp_code from employee_master e,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.emp_code=" & Me.txtEmpcode.Text.Trim & " ").Tables(0)

                    If (dt1.Rows.Count = 1) Then

                        If (CDate(Me.Txt_fdt.Text) <= CDate(Me.Txt_tdt.Text)) Then
                            Server.Transfer("transfer_display_report.aspx?emp=" & Me.txtEmpcode.Text.Trim & "&f_dt=" & Me.Txt_fdt.Text & "&t_dt=" & Me.Txt_tdt.Text)
                        Else
                            Dim msgbx As New System.Text.StringBuilder
                            msgbx.Append("         alert('PLEASE Check the date' );")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                            Exit Sub
                        End If
                    Else
                        Dim msgbx As New System.Text.StringBuilder
                        msgbx.Append("         alert('PLEASE Check the Employee code' );")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                        Exit Sub
                    End If

                Else
                    Dim msgbx As New System.Text.StringBuilder
                    msgbx.Append("         alert('You Are Not Authorised To View Others Details. Enter Own Emp Code' );")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                    Exit Sub
                End If

            End If

            '--------------- ReqID 8592 starts------------------------------
        Else

            dt1 = oh.ExecuteDataSet("select e.emp_code from employee_master e,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.emp_code=" & Me.txtEmpcode.Text.Trim & " ").Tables(0)

            If (dt1.Rows.Count = 1) Then

                If (CDate(Me.Txt_fdt.Text) <= CDate(Me.Txt_tdt.Text)) Then
                    Server.Transfer("transfer_display_report.aspx?emp=" & Me.txtEmpcode.Text.Trim & "&f_dt=" & Me.Txt_fdt.Text & "&t_dt=" & Me.Txt_tdt.Text)
                Else
                    Dim msgbx As New System.Text.StringBuilder
                    msgbx.Append("         alert('PLEASE Check the date' );")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                    Exit Sub
                End If
            Else
                Dim msgbx As New System.Text.StringBuilder
                msgbx.Append("         alert('PLEASE Check the Employee code' );")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                Exit Sub
            End If
        End If
        '---------------------end-------------------------------------

    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        'Server.Transfer("../home.aspx")
        Response.Redirect("../home.aspx")
    End Sub
End Class
