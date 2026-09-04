Imports System.Data
Imports System.Data.OracleClient
Partial Class november_tour_Tour_apply_5ace8aa13319
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim sf() As String
    Dim firmid As Integer
    Dim branchid As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '------VAPT - improper parameter validation---------------------------------------
        Dim paramCount As Integer = Request.QueryString.Count
        If Request.QueryString.Count > 0 Then
            Response.StatusCode = 400
            Response.StatusDescription = "Bad Request"
            Response.End()
        End If
        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_purp.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        If Not IsPostBack Then
            'If Me.Session("branch_id") = 0 Then
            '    Me.Server.Transfer("../show_err.aspx")
            '    Exit Sub
            'Else
            firmid = Convert.ToInt32(Me.Session("firm_id"))
            branchid = Me.Session("branch_id")
            sf = Session("user_id").ToString.Split("!")
            Me.Txt_fdt.Text = Format(Date.Now, "dd/MMM/yyyy")
            ' Dim pp As DataTable = oh.ExecuteDataSet("select department_id from employee_master where emp_code=" & sf(0) & " and status_id=1").Tables(0)

            If firmid = 28 And Me.Session("branch_id") = 3439 Then
                dt = oh.ExecuteDataSet("select e.emp_code || '-----' || e.emp_name, e.emp_code, d.dep_name, ds.designation, p.post_name, b.branch_name from employee_master e, department_mst d, department_mst_mageeth dm, designation_master ds, post_mst p, branch_master b where e.emp_code = " & sf(0) & " and e.designation_id = ds.designation_id and e.post_id = p.post_id and e.branch_id = b.branch_id and dm.dep_id= d.dep_id and dm.emp_code=e.emp_code").Tables(0)
            ElseIf firmid = 28 And Me.Session("branch_id") = 3427 Then
                dt = oh.ExecuteDataSet("select e.emp_code || '-----' || e.emp_name, e.emp_code, d.dep_name, ds.designation, p.post_name, b.branch_name from employee_master e, department_mst d, department_mst_mps dm, designation_master ds, post_mst p, branch_master b where e.emp_code = " & sf(0) & " and e.designation_id = ds.designation_id and e.post_id = p.post_id and e.branch_id = b.branch_id and dm.dep_id= d.dep_id and dm.emp_code=e.emp_code").Tables(0)
            Else
                dt = oh.ExecuteDataSet("select e.emp_code||'-----'||e.emp_name,e.emp_code,d.dep_name,ds.designation,p.post_name,b.branch_name from employee_master e,department_mst d,designation_master ds,post_mst p,branch_master b where e.emp_code=" & sf(0) & " and e.department_id=d.dep_id and e.designation_id=ds.designation_id and e.post_id=p.post_id and e.branch_id=b.branch_id").Tables(0)
            End If
            '  End If
            Try
                Me.Txt_emp.Value = dt.Rows(0)(0)
                Me.Txt_dep.Value = dt.Rows(0)(2)
                Me.Txt_des.Value = dt.Rows(0)(3)
                Me.Txt_post.Value = dt.Rows(0)(4)
                Me.Txt_br.Value = dt.Rows(0)(5)
                Dim sql As String


            Catch ex As Exception
            Finally
                dt.Dispose()
            End Try
        End If
        'End If

    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim ftime, ttime As String
        
        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        Dim dt2 As DataTable
        dt2 = oh.ExecuteDataSet("select sysdate from dual").Tables(0)
        Dim script1 As New System.Text.StringBuilder


        If Format(Me.Txt_fdt.Text, "dd/MMM/yyyy") < Format(Date.Today, "dd/MMM/yyyy") Then

            script1.Append("        alert('Back date application is not possible..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        '    Dim attcnt As Integer = oh.ExecuteDataSet("select count(emp_code) from daily_attend where emp_code=" & sf(0) & " and m_time is not null").Tables(0).Rows(0)(0)
        '    If attcnt <> 0 Then

        '        '  Dim attbr As Integer = oh.ExecuteDataSet("select m_branch from daily_attend where emp_code=" & sf(0) & " and m_time is not null").Tables(0).Rows(0)(0)
        '        '   If attbr = Me.cmb_place.SelectedValue Then
        '        script1.Append("        alert('This Cannot be Possible..You are not punched Today..!!');")
        '        script1.Append("window.open('earlygoing_apply.aspx','_self');")
        '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        '        Exit Sub
        '        'End If

        '    End If
        'End If

        Dim parameter(3) As OracleParameter
        parameter(0) = New OracleParameter("em_code", OracleType.Number, 150)
        parameter(0).Direction = ParameterDirection.Input
        parameter(0).Value = sf(0)
        parameter(1) = New OracleParameter("go_dt", OracleType.DateTime, 150)
        parameter(1).Direction = ParameterDirection.Input
        parameter(1).Value = Format(CDate(Me.Txt_fdt.Text), "dd/MMM/yyyy")
        parameter(2) = New OracleParameter("go_reason", OracleType.VarChar, 150)
        parameter(2).Direction = ParameterDirection.Input
        parameter(2).Value = Me.Txt_purp.Text
         parameter(3) = New OracleParameter("msg", OracleType.VarChar, 150)
        parameter(3).Direction = ParameterDirection.Output
        'oh.ExecuteNonQuery("hrm_tour_apply", parameter)
        oh.ExecuteNonQuery("hrm_earlygoing_apply", parameter)    'as testing

        Dim message As String
        message = parameter(3).Value

        script1.Append("        alert('" & message & "');")
        script1.Append("window.open('earlygoing_apply.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)


    End Sub

  
End Class
