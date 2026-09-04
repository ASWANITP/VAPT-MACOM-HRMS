Imports System.Data
Imports System.Data.OracleClient
Partial Class promotiondetails_promotion_report_1ee797829058
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '' ''Session("firm_id") = 8
            ' dt = oh.ExecuteDataSet("select e.emp_code || '---' || e.emp_name, e.emp_code  from employee_master e,employ_firm f where e.emp_code > 9999 and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " order by e.emp_code").Tables(0)
            'Added on 9-03-2017 for RqstId=12731
           
            If Session("firm_id") = 8 Then
                dt = oh.ExecuteDataSet("select e.emp_code || '---' || e.emp_name, e.emp_code emp_code  from employee_master e, employ_firm f  where e.emp_code > 100000   and e.emp_code = f.emp_code   and f.firm_id = " & Session("firm_id") & " union all select e.emp_code || '---' || e.emp_name, e.emp_code emp_code  from employee_master e, employ_firm f  where e.emp_code > 9999   and e.emp_code = f.emp_code   and e.emp_code=32706   and f.firm_id = " & Session("firm_id") & "  order by emp_code").Tables(0)
                '..........req id 13239...................
            ElseIf Session("firm_id") = 24 Then
                dt = oh.ExecuteDataSet("select e.emp_code || '---' || e.emp_name, e.emp_code emp_code  from employee_master e, employ_firm f  where e.emp_code > 100000   and e.emp_code = f.emp_code   and f.firm_id = " & Session("firm_id") & " union all select e.emp_code || '---' || e.emp_name, e.emp_code emp_code  from employee_master e, employ_firm f  where e.emp_code > 9999   and e.emp_code = f.emp_code      and f.firm_id = " & Session("firm_id") & "  order by emp_code").Tables(0)
                '..........req id 13239...................
            Else
                dt = oh.ExecuteDataSet("select e.emp_code || '---' || e.emp_name, e.emp_code  from employee_master e,employ_firm f where e.emp_code > 9999 and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " order by e.emp_code").Tables(0)
            End If
            Me.cmb_select.DataSource = dt
            Me.cmb_select.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_select.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_select.DataBind()
            Me.txt_fdt.Text = Format(CDate("15/AUG/1947"), "dd/MMM/yyyy")
            Me.txt_tdt.Text = Format(Date.Today, "dd/MMM/yyyy")
        End If
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim user() As String
        Dim firm As Integer = Session("firm_id")
        user = Session("user_id").ToString.Split("!")
        Dim val As String
        val = Me.cmb_select.SelectedValue

        '--------------- ReqID 8592 starts------------------------------
        If Session("firm_id") = 8 Or 24 Then

            '---------------------end-------------------------------------




            If val = user(0) And Session("firm_id") = 8 Then


                If (CDate(Me.txt_fdt.Text) <= CDate(Me.txt_tdt.Text)) Then
                    Server.Transfer("promotion_display_report1.aspx?emp=" & Me.cmb_select.SelectedValue & "&f_dt=" & Me.txt_fdt.Text & "&t_dt=" & Me.txt_tdt.Text)
                Else
                    Dim msgbx As New System.Text.StringBuilder
                    msgbx.Append("         alert('PLEASE Check the date' );")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                    Exit Sub
                End If
            ElseIf val = user(0) And Session("firm_id") <> 8 Then


                If (CDate(Me.txt_fdt.Text) <= CDate(Me.txt_tdt.Text)) Then
                    Server.Transfer("promotion_display_report.aspx?emp=" & Me.cmb_select.SelectedValue & "&f_dt=" & Me.txt_fdt.Text & "&t_dt=" & Me.txt_tdt.Text)
                Else
                    Dim msgbx As New System.Text.StringBuilder
                    msgbx.Append("         alert('PLEASE Check the date' );")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                    Exit Sub
                End If
            Else
                Dim dhead As String
                Dim hr As Integer



                dhead = oh.ExecuteDataSet("select d.dep_head from employee_master t,department_mst d where d.dep_id=t.department_id and t.emp_code=" & Me.cmb_select.SelectedValue & "").Tables(0).Rows(0)(0)
                hr = oh.ExecuteDataSet("select t.access_id  from employee_master t where t.emp_code =" & user(0) & "").Tables(0).Rows(0)(0)
                If user(0) = dhead Or hr = 33 Then
                    If (CDate(Me.txt_fdt.Text) <= CDate(Me.txt_tdt.Text)) And Session("firm_id") = 8 Then
                        Server.Transfer("promotion_display_report1.aspx?emp=" & Me.cmb_select.SelectedValue & "&f_dt=" & Me.txt_fdt.Text & "&t_dt=" & Me.txt_tdt.Text)
                    ElseIf (CDate(Me.txt_fdt.Text) <= CDate(Me.txt_tdt.Text)) And Session("firm_id") <> 8 Then
                        Server.Transfer("promotion_display_report.aspx?emp=" & Me.cmb_select.SelectedValue & "&f_dt=" & Me.txt_fdt.Text & "&t_dt=" & Me.txt_tdt.Text)
                    Else
                        Dim msgbx As New System.Text.StringBuilder
                        msgbx.Append("         alert('PLEASE Check the date' );")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                        Exit Sub
                    End If
                Else
                    Dim msgbx As New System.Text.StringBuilder
                    msgbx.Append("         alert('You Are Not Authorised To view this..Choose Own emp Code..' );")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                    Exit Sub
                End If
            End If
            '--------------- ReqID 8592 starts------------------------------
        Else
            Server.Transfer("promotion_display_report.aspx?emp=" & Me.cmb_select.SelectedValue & "&f_dt=" & Me.txt_fdt.Text & "&t_dt=" & Me.txt_tdt.Text)
        End If

        '---------------------end-------------------------------------


    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        'Server.Transfer("../home.aspx")
        Response.Redirect("../home.aspx")
    End Sub
End Class
