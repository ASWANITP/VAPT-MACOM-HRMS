Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Imports System.Data.OleDb
Imports System.Web.Services
Imports System.Windows.Forms.FileDialog
Imports System.Web
Partial Class bulk_upload_Approval_bulk_19edc3762153
    Inherits System.Web.UI.Page
    Dim dt1, dt2, dt3 As New DataTable
    Dim dd1, dta, dtt As New DataTable
    'Dim dt1 As String
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)



        Dim s As String = "select s.post_id from employee_master s where s.emp_code=" & User(0) & " "
        dta = oh.ExecuteDataSet("select s.post_id from employee_master s where s.emp_code=" & User(0) & "").Tables(0)

        If Not IsPostBack Then

            dd1 = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=7600 and s.emp_id=" & dta.Rows(0)(0) & "").Tables(0)
            If dd1.Rows(0)(0) = 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

                'Me.Server.Transfer("../show_err.aspx")
            End If
        End If
        If Not IsPostBack Then
            dt1 = oh.ExecuteDataSet("select 0||'-'||'0' as qualid, '--------SELECT--------' as qual   from dual h union all select distinct t.id||'-'||tt.seq_id,t.bulk_name as qual   from mactech.BULK_OPTION t, HRM_EMP_ADDITIONAL_TEMP tt  where t.status_id = tt.status_id    and tt.comp_id = 1    and tt.comp_id = t.id union all select distinct t.id||'-'||tt.seq_id, t.bulk_name as qual   from mactech.BULK_OPTION t, HRM_EMP_ADDITIONAL_TEMP tt  where t.status_id = tt.u_status_id    and tt.comp_id = 2    and tt.comp_id = t.id union all select distinct t.id||'-'||s.seq_id, t.bulk_name as qual   from mactech.BULK_OPTION t, EMPLOY_SAL_ADD_TEMP s  where t.status_id = s.status_id    and s.comp_id = 3    and s.comp_id = t.id union all select distinct t.id||'-'||s.seq_id, t.bulk_name as qual   from mactech.BULK_OPTION t, EMPLOY_SAL_ADD_TEMP s  where t.status_id = s.status_id    and s.comp_id = 4    and s.comp_id = t.id union all select distinct t.id||'-'||s.seq_id, t.bulk_name as qual   from mactech.BULK_OPTION t, EMPLOY_SAL_ADD_TEMP s  where t.status_id = s.status_id    and s.comp_id = 5    and s.comp_id = t.id union all select distinct t.id||'-'||i.seq_id, t.bulk_name as qual   from mactech.BULK_OPTION t, INCENTIVES_ALLOWANCES_TEMP i  where t.status_id = i.status_id    and i.comp_id = 6    and i.comp_id = t.id  order by qual  ").Tables(0)
            Me.DropDownList1.DataSource = dt1
            Me.DropDownList1.DataValueField = dt1.Columns(0).ColumnName
            Me.DropDownList1.DataTextField = dt1.Columns(1).ColumnName
            Me.DropDownList1.DataBind()

        End If


    End Sub
    

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim value As Double = Me.DropDownList1.SelectedValue.Split("-")(0)
        If value = "6" Then

            Me.DropDownList2.Visible = True

            dt2 = oh.ExecuteDataSet("select -1 as qualid, '--------SELECT--------' as qual from dual h union all select distinct t.all_id,t.all_name from ALLOWANCES_MASTER t,incentives_allowances_temp i,bulk_option b where t.all_id=i.all_id and i.comp_id=b.id and i.status_id=0").Tables(0)
            Me.DropDownList2.DataSource = dt2
            Me.DropDownList2.DataValueField = dt2.Columns(0).ColumnName
            Me.DropDownList2.DataTextField = dt2.Columns(1).ColumnName
            Me.DropDownList2.DataBind()

        Else
            Me.DropDownList2.Visible = False

            Exit Sub
        End If
        
    End Sub
    
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Me.DropDownList1.SelectedValue.Split("-")(0) = "0" Then
            Dim cl_script31 As New System.Text.StringBuilder(1, 500)
            cl_script31.Append("  alert('SELECT ANY DATA');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script31.ToString, True)
        Else

            If Me.DropDownList1.SelectedValue.Split("-")(0) = "6" Then
                Dim sql1 = ("select t.emp_code,t.all_amount,t.actul_amt from INCENTIVES_ALLOWANCES_TEMP t where t.seq_id=" & Me.DropDownList1.SelectedValue.Split("-")(1) & "")
                Dim dt4 = oh.ExecuteDataSet(sql1).Tables(0)
                If dt4.Rows.Count > 0 Then
                    GridView2.DataSource = dt4
                    GridView2.DataBind()
                    Response.ClearContent()
                    Response.Buffer = True
                    Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "Bulk-Upload" + " " + DateTime.Now.ToString("dd-MMMM-yyyy" + " " + "hh:mm tt") + ".xls"))
                    Response.ContentType = "application/ms-excel"
                    Dim sw As New StringWriter()
                    Dim htw As New HtmlTextWriter(sw)
                    GridView2.AllowPaging = False
                    GridView2.HeaderRow.Style.Add("background-color", "#FFFFFF")
                    For i As Integer = 0 To GridView2.HeaderRow.Cells.Count - 1
                        GridView2.HeaderRow.Cells(i).Style.Add("background-color", "#00BFFF")
                    Next
                    GridView2.RenderControl(htw)
                    Response.Write(sw.ToString())
                    Response.[End]()
                End If
            End If
            If Me.DropDownList1.SelectedValue.Split("-")(0) = "1" Then
                Dim sql2 = ("select t.emp_code,t.esi_no from hrm_emp_additional_temp t where t.seq_id=" & Me.DropDownList1.SelectedValue.Split("-")(1) & "")
                Dim dt4 = oh.ExecuteDataSet(sql2).Tables(0)
                If dt4.Rows.Count > 0 Then
                    GridView2.DataSource = dt4
                    GridView2.DataBind()
                    Response.ClearContent()
                    Response.Buffer = True
                    Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "Bulk-Upload" + " " + DateTime.Now.ToString("dd-MMMM-yyyy" + " " + "hh:mm tt") + ".xls"))
                    Response.ContentType = "application/ms-excel"
                    Dim sw As New StringWriter()
                    Dim htw As New HtmlTextWriter(sw)
                    GridView2.AllowPaging = False
                    GridView2.HeaderRow.Style.Add("background-color", "#FFFFFF")
                    For i As Integer = 0 To GridView2.HeaderRow.Cells.Count - 1
                        GridView2.HeaderRow.Cells(i).Style.Add("background-color", "#00BFFF")
                    Next
                    GridView2.RenderControl(htw)
                    Response.Write(sw.ToString())
                    Response.[End]()
                End If
            End If

            If Me.DropDownList1.SelectedValue.Split("-")(0) = "2" Then
                Dim sql3 = ("select t.emp_code,t.uan_no from hrm_emp_additional_temp t where t.seq_id=" & Me.DropDownList1.SelectedValue.Split("-")(1) & "")
                Dim dt4 = oh.ExecuteDataSet(sql3).Tables(0)
                If dt4.Rows.Count > 0 Then
                    GridView2.DataSource = dt4
                    GridView2.DataBind()
                    Response.ClearContent()
                    Response.Buffer = True
                    Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "Bulk-Upload" + " " + DateTime.Now.ToString("dd-MMMM-yyyy" + " " + "hh:mm tt") + ".xls"))
                    Response.ContentType = "application/ms-excel"
                    Dim sw As New StringWriter()
                    Dim htw As New HtmlTextWriter(sw)
                    GridView2.AllowPaging = False
                    GridView2.HeaderRow.Style.Add("background-color", "#FFFFFF")
                    For i As Integer = 0 To GridView2.HeaderRow.Cells.Count - 1
                        GridView2.HeaderRow.Cells(i).Style.Add("background-color", "#00BFFF")
                    Next
                    GridView2.RenderControl(htw)
                    Response.Write(sw.ToString())
                    Response.[End]()
                End If
            End If

            If Me.DropDownList1.SelectedValue.Split("-")(0) = "3" Or "4" Or "5" Then
                Dim sql4a = ""
                If Me.DropDownList1.SelectedValue.Split("-")(0) = 3 Then
                    sql4a = ("select t.emp_ID,t.TDS from EMPLOY_SAL_ADD_TEMP t where t.seq_id=" & Me.DropDownList1.SelectedValue.Split("-")(1) & "")
                End If
                If Me.DropDownList1.SelectedValue.Split("-")(0) = 4 Then
                    sql4a = ("select t.emp_ID,t.OTH_DED from EMPLOY_SAL_ADD_TEMP t where t.seq_id=" & Me.DropDownList1.SelectedValue.Split("-")(1) & "")
                End If
                If Me.DropDownList1.SelectedValue.Split("-")(0) = 5 Then
                    sql4a = ("select t.emp_ID,t.OTH_ADD from EMPLOY_SAL_ADD_TEMP t where t.seq_id=" & Me.DropDownList1.SelectedValue.Split("-")(1) & "")
                End If
                Dim dt4 = oh.ExecuteDataSet(sql4a).Tables(0)
                If dt4.Rows.Count > 0 Then
                    GridView2.DataSource = dt4
                    GridView2.DataBind()
                    Response.ClearContent()
                    Response.Buffer = True
                    Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "Bulk-Upload" + " " + DateTime.Now.ToString("dd-MMMM-yyyy" + " " + "hh:mm tt") + ".xls"))
                    Response.ContentType = "application/ms-excel"
                    Dim sw As New StringWriter()
                    Dim htw As New HtmlTextWriter(sw)
                    GridView2.AllowPaging = False
                    GridView2.HeaderRow.Style.Add("background-color", "#FFFFFF")
                    For i As Integer = 0 To GridView2.HeaderRow.Cells.Count - 1
                        GridView2.HeaderRow.Cells(i).Style.Add("background-color", "#00BFFF")
                    Next
                    GridView2.RenderControl(htw)
                    Response.Write(sw.ToString())
                    Response.[End]()
                End If
            End If
        End If


    End Sub
   
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click

        

        If Me.DropDownList1.SelectedValue.Split("-")(0) = "0" Then
            Dim cl_script31 As New System.Text.StringBuilder(1, 500)
            cl_script31.Append("  alert('SELECT ANY DATA');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script31.ToString, True)
        Else
            Dim value As Double = Me.DropDownList1.SelectedValue.Split("-")(0)
            Dim seqno As Double = Me.DropDownList1.SelectedValue.Split("-")(1)

            Dim parameter(2) As OracleParameter

            parameter(0) = New OracleParameter("val", OracleType.Number, 6)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = CInt(value)

            parameter(1) = New OracleParameter("seq", OracleType.Number, 6)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = CInt(seqno)

            parameter(2) = New OracleParameter("msg", OracleType.VarChar, 100)
            parameter(2).Direction = ParameterDirection.Output


            oh.ExecuteNonQuery("BULK_APPROVAL", parameter)
            Dim message As String
            message = parameter(2).Value

            Dim cl_script1 As New System.Text.StringBuilder(1, 500)
            ' cl_script1.Append("  alert('BULK-EXCEL APPROVED SUCCESSFULLY!!!!');")
            cl_script1.Append(" alert('" & message & "');")
            cl_script1.Append("window.open('Approval_bulk.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)


            'Me.DropDownList1.SelectedIndex = -1


            'If IsPostBack Then
            '    dt7 = oh.ExecuteDataSet("select -1 as qualid, '--------SELECT--------' as qual   from dual h union all select t.id,t.bulk_name as qual   from mactech.BULK_OPTION t, HRM_EMP_ADDITIONAL_TEMP tt  where t.status_id = tt.status_id    and rownum = 1 union all select t.id,t.bulk_name as qual   from mactech.BULK_OPTION t, HRM_EMP_ADDITIONAL_TEMP tt  where t.status_id = tt.u_status_id    and rownum = 1 union all select t.id,t.bulk_name as qual   from mactech.BULK_OPTION t, EMPLOY_SAL_ADD_TEMP s  where t.status_id = s.status_id    and rownum = 1 union all select t.id,t.bulk_name as qual   from mactech.BULK_OPTION t, INCENTIVES_ALLOWANCES_TEMP i  where t.status_id = i.status_id    and rownum = 1  order by qual ").Tables(0)
            '    Me.DropDownList1.DataSource = dt7
            '    Me.DropDownList1.DataValueField = dt7.Columns(0).ColumnName
            '    Me.DropDownList1.DataTextField = dt7.Columns(1).ColumnName
            '    Me.DropDownList1.DataBind()

            'End If

        End If


    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Server.Transfer("../home.aspx")
        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("window.open('../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)


    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub

    Protected Sub cmd_reject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_reject.Click

        Dim value As Double = Me.DropDownList1.SelectedValue.Split("-")(0)
        Dim seqno As Double = Me.DropDownList1.SelectedValue.Split("-")(1)



        If Me.DropDownList1.SelectedValue.Split("-")(0) = "0" Then
            Dim cl_script31 As New System.Text.StringBuilder(1, 500)
            cl_script31.Append("  alert('SELECT ANY DATA');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script31.ToString, True)
        Else

            Dim parameter(2) As OracleParameter

            parameter(0) = New OracleParameter("val", OracleType.Number, 6)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = CInt(value)


            parameter(1) = New OracleParameter("seq", OracleType.Number, 6)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = CInt(seqno)


            parameter(2) = New OracleParameter("msg", OracleType.VarChar, 100)
            parameter(2).Direction = ParameterDirection.Output


            oh.ExecuteNonQuery("BULK_REJECT", parameter)
            Dim message As String
            message = parameter(2).Value

            Dim cl_script1 As New System.Text.StringBuilder(1, 500)
            cl_script1.Append(" alert('" & message & "');")
            cl_script1.Append("window.open('Approval_bulk.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        End If

    End Sub
End Class
