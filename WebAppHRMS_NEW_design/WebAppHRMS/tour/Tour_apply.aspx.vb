Imports System.Data
Imports System.Data.OracleClient
Partial Class november_tour_Tour_apply_d1bb416e4757
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim sf(), fid As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_adv.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        If Not IsPostBack Then
            'If Me.Session("branch_id") = 0 Then
            '    Me.Server.Transfer("../show_err.aspx")
            '    Exit Sub
            'Else
            sf = Session("user_id").ToString.Split("!")

            fid = Session("firm_id")

            Dim dt22 As DataTable = oh.ExecuteDataSet("select count(*) from TBLFIELD_PUNCH t where t.empcode = " & sf(0) & " ").Tables(0)
            'Dim dt22 As DataTable = oh.ExecuteDataSet("select t.firm_id from mactech.employee_master t, mactech.employ_firm g where t.emp_code = g.emp_code and g.firm_id = 8 and t.emp_code =  " & sf(0) & " ").Tables(0)

            If fid = 8 Or dt22.Rows(0)(0) > 0 Then
                'If dt22.Rows(0)(0) = 8 Then
                Response.Redirect("Tour_applyMacom.aspx")
                Exit Sub
            End If


            Me.Txt_fdt.Text = Format(Date.Now, "dd/MMM/yyyy")
            Me.Txt_tdt.Text = Format(Date.Now, "dd/MMM/yyyy")
            Dim pp As DataTable = oh.ExecuteDataSet("select department_id,post_id from employee_master where emp_code=" & sf(0) & " and status_id=1").Tables(0)
            If pp.Rows.Count = 0 Then
                Me.Server.Transfer("../show_err.aspx")
                Exit Sub
            Else
                Dim depid As Integer = pp.Rows(0)(0)
                If (depid = 101 Or depid = 211 Or depid = 23 Or depid = 252 Or depid = 4 Or depid = 180 Or depid = 178 Or depid = 183 Or depid = 188) Then  'Branch opening or vigilance
                    If (pp.Rows(0)(1) = 199 Or pp.Rows(0)(1) = 349 Or pp.Rows(0)(1) = 244 Or pp.Rows(0)(1) = 69 Or pp.Rows(0)(1) = 73 Or pp.Rows(0)(1) = 71 Or pp.Rows(0)(1) = 85) Then
                    Else
                        Me.Server.Transfer("../show_err.aspx")
                        Exit Sub
                    End If
                End If
                If Session("firm_id") = 24 Then
                    dt = oh.ExecuteDataSet("select e.emp_code||'-----'||e.emp_name,e.emp_code,d.dep_name,ds.designation,p.post_name,b.branch_name from employee_master e,department_mst d,designation_master ds,post_mst_jwell p,branch b where e.emp_code=" & sf(0) & " and e.department_id=d.dep_id and e.designation_id=ds.designation_id and e.post_id=p.post_id and e.branch_id=b.branch_id").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select e.emp_code||'-----'||e.emp_name,e.emp_code,d.dep_name,ds.designation,p.post_name,b.branch_name from employee_master e,department_mst d,designation_master ds,post_mst p,branch b where e.emp_code=" & sf(0) & " and e.department_id=d.dep_id and e.designation_id=ds.designation_id and e.post_id=p.post_id and e.branch_id=b.branch_id").Tables(0)
                End If
            End If
            Try
                Me.Txt_emp.Value = dt.Rows(0)(0)
                Me.Txt_dep.Value = dt.Rows(0)(2)
                Me.Txt_des.Value = dt.Rows(0)(3)
                Me.Txt_post.Value = dt.Rows(0)(4)
                Me.Txt_br.Value = dt.Rows(0)(5)
                Dim sql As String

                sql = "select b.branch_name, b.branch_id  from branch_master b  WHERE b.BRANCH_ID <> 9999  and b.firm_id = " & Session("firm_id") & "  union  select branch_name, old_id  from before_completion  where branch_id is null  and status_id not in (2)  and firm_id=" & Session("firm_id") & "  union  select b.branch_name, b.branch_id  from branch_master b  WHERE b.BRANCH_ID in (0)  order by branch_name"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                Me.cmb_place.DataSource = dt
                Me.cmb_place.DataTextField = dt.Columns(0).ColumnName
                Me.cmb_place.DataValueField = dt.Columns(1).ColumnName
                Me.cmb_place.DataBind()
            Catch ex As Exception
            Finally
                dt.Dispose()
            End Try
        End If
        'End If           
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim ftime, ttime As String
        ftime = Me.Txt_FromTime.Value
        ttime = Me.Txt_ToTime.Value
        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        Dim dt2 As DataTable
        dt2 = oh.ExecuteDataSet("select sysdate from dual").Tables(0)
        Dim script1 As New System.Text.StringBuilder


        If Me.Txt_fdt.Text = Format(Date.Now, "dd/MMM/yyyy") Then
            Dim attcnt As Integer = oh.ExecuteDataSet("select count(emp_code) from daily_attend where emp_code=" & sf(0) & " and m_time is not null").Tables(0).Rows(0)(0)
            If attcnt <> 0 Then
                If Txt_oth.Text = "" Then
                    Dim attbr As Integer = oh.ExecuteDataSet("select m_branch from daily_attend where emp_code=" & sf(0) & " and m_time is not null").Tables(0).Rows(0)(0)
                    If attbr = Me.cmb_place.SelectedValue Then
                        script1.Append("        alert('This Cannot be Possible..You Put Tour to Branch where you punched Today..!!');")
                        script1.Append("window.open('Tour_apply.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
                        Exit Sub
                    End If
                End If
            End If
        End If
        Dim place, other As String
        If (Me.chk_br.Checked = True) Then
            place = Me.cmb_place.SelectedValue
        Else
            place = ""
        End If

        If (Me.chk_oth.Checked = True) Then
            other = Me.Txt_oth.Text
        Else
            other = ""
        End If
        Dim parameter(9) As OracleParameter
        parameter(0) = New OracleParameter("emp", OracleType.Number, 150)
        parameter(0).Direction = ParameterDirection.Input
        parameter(0).Value = sf(0)
        parameter(1) = New OracleParameter("fdt", OracleType.DateTime, 150)
        parameter(1).Direction = ParameterDirection.Input
        parameter(1).Value = Format(CDate(Me.Txt_fdt.Text), "dd/MMM/yyyy")
        parameter(2) = New OracleParameter("tdt", OracleType.DateTime, 150)
        parameter(2).Direction = ParameterDirection.Input
        parameter(2).Value = Format(CDate(Me.Txt_tdt.Text), "dd/MMM/yyyy")
        parameter(3) = New OracleParameter("ftm", OracleType.VarChar, 150)
        parameter(3).Direction = ParameterDirection.Input
        parameter(3).Value = ftime
        parameter(4) = New OracleParameter("ttm", OracleType.VarChar, 150)
        parameter(4).Direction = ParameterDirection.Input
        parameter(4).Value = ttime
        parameter(5) = New OracleParameter("pla", OracleType.VarChar, 150)
        parameter(5).Direction = ParameterDirection.Input
        parameter(5).Value = place
        parameter(6) = New OracleParameter("purp", OracleType.VarChar, 150)
        parameter(6).Direction = ParameterDirection.Input
        parameter(6).Value = Me.Txt_purp.Text
        parameter(7) = New OracleParameter("oth", OracleType.VarChar, 150)
        parameter(7).Direction = ParameterDirection.Input
        parameter(7).Value = other
        parameter(8) = New OracleParameter("adv", OracleType.Number, 150)
        parameter(8).Direction = ParameterDirection.Input
        parameter(8).Value = Me.Txt_adv.Text
        parameter(9) = New OracleParameter("msg", OracleType.VarChar, 150)
        parameter(9).Direction = ParameterDirection.Output
        'oh.ExecuteNonQuery("hrm_tour_apply", parameter)
        oh.ExecuteNonQuery("HRM_TOUR_APPLY_INDI", parameter)    'as testing

        Dim message As String
        message = parameter(9).Value

        script1.Append("        alert('" & message & "');")
        script1.Append("window.open('Tour_apply.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
    End Sub
End Class
