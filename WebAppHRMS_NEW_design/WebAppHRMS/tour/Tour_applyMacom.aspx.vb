Imports System.Data
Imports System.Data.OracleClient
Partial Class november_tour_Tour_apply_703b67167513
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dttt, dt1, dt2, dt3, dt4, dt5, dt6, dt7, dtx2, dtx1 As New DataTable
    Dim callbackResult, br, xx, xx1, xx2, yy, zz, sqlb As String
    Dim sf(), sql As String
    Dim BR_flag As Integer = 0




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_adv.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)

        Me.chk_srno.Attributes.Add("onchange", "handleCheckboxChange()")

        Dim cbRef As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "updateBranchName", "context")
        Dim cbScript As String = "function fetchBranchData(arg, context) { " & cbRef & "; }"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "fetchBranchData", cbScript, True)


       

        If Not IsPostBack Then
            'If Me.Session("branch_id") = 0 Then
            '    Me.Server.Transfer("../show_err.aspx")
            '    Exit Sub
            'Else
            sf = Session("user_id").ToString.Split("!")
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

                Me.hid_brnch.Text = ""
                If Session("firm_id") = 24 Then
                    dt = oh.ExecuteDataSet("select e.emp_code||'-----'||e.emp_name,e.emp_code,d.dep_name,ds.designation,p.post_name,b.branch_name from employee_master e,department_mst d,designation_master ds,post_mst_jwell p,branch b where e.emp_code=" & sf(0) & " and e.department_id=d.dep_id and e.designation_id=ds.designation_id and e.post_id=p.post_id and e.branch_id=b.branch_id").Tables(0)

                Else
                    dt = oh.ExecuteDataSet("select e.emp_code||'-----'||e.emp_name,e.emp_code,d.dep_name,ds.designation,p.post_name,b.branch_name from employee_master e,department_mst d,designation_master ds,post_mst p,branch b where e.emp_code=" & sf(0) & " and e.department_id=d.dep_id and e.designation_id=ds.designation_id and e.post_id=p.post_id and e.branch_id=b.branch_id").Tables(0)
                    hid_brnch.Text = oh.ExecuteDataSet("select b.BRANCH_ID from employee_master e, department_mst d, designation_master ds, post_mst p, branch b where e.emp_code = " & sf(0) & " and e.department_id = d.dep_id and e.designation_id = ds.designation_id and e.post_id = p.post_id and e.branch_id = b.branch_id").Tables(0).Rows(0)(0)
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

            Dim dt2 As DataTable = oh.ExecuteDataSet("select count(*) from TBLFIELD_PUNCH t where t.empcode = " & sf(0) & " ").Tables(0)
            If dt2.Rows(0)(0) > 0 Then
                Me.chk_srno.Visible = True
                Me.chk_br.Visible = False
                Me.chk_oth.Visible = False
                Me.chk_oth.Enabled = False
                Me.chk_br.Enabled = False
                Me.chk_br.Checked = False
                Me.chk_oth.Checked = False
            Else
                If dt2.Rows(0)(0) = 0 Then
                    Me.chk_srno.Visible = False
                End If
            End If
        End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return callbackResult
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

        Dim cal_data = eventArgument
        sf = Session("user_id").ToString.Split("!")
        sqlb = "select b.branch_id from employee_master e, branch_master b where e.branch_id = b.branch_id and e.emp_code = " & sf(0) & ""
        dt6 = oh.ExecuteDataSet(sqlb).Tables(0)
        br = dt6.Rows(0)(0).ToString
        Dim args As String() = eventArgument.Split("|"c) ' Split the flag and the value
        Dim flag As String = args(0)
        Dim tkt_br As String = args(1)
        Dim st As New StringBuilder


        If flag = "ticket" Then

            xx1 = "select count(*) from mactech.TBLFIELD_PUNCH h where h.empcode=(SELECT r.user_id FROM mactech.helpdesk_issue_sr r WHERE r.issue_sr_id = " & tkt_br & ")"

            dtx1 = oh.ExecuteDataSet(xx1).Tables(0)

            If dtx1.Rows(0)(0) > 0 Then

                xx2 = "SELECT b.branch_name,b.branch_id FROM branch_master b WHERE b.branch_id =0"

                dtx2 = oh.ExecuteDataSet(xx2).Tables(0)
                Session("nib") = dtx2.Rows(0)(1)
                st.Append(dtx2.Rows(0)(0))
                st.Append("$")
                st.Append(dtx2.Rows(0)(1))
                st.Append("@")

            Else
                xx = "SELECT b.branch_name,b.branch_id FROM employee_master e, branch_master b WHERE e.branch_id = b.branch_id AND e.emp_code = (SELECT r.user_id FROM mactech.helpdesk_issue_sr r WHERE r.issue_sr_id = " & tkt_br & ")"

                dt3 = oh.ExecuteDataSet(xx).Tables(0)

                If dt3.Rows.Count > 0 Then
                    Session("nib") = dt3.Rows(0)(1)
                    st.Append(dt3.Rows(0)(0))
                    st.Append("$")
                    st.Append(dt3.Rows(0)(1))
                    st.Append("@")

                Else
                    st.Append("%")
                    callbackResult = st.ToString
                    Exit Sub
                End If

            End If

            yy = "select bm.branch_name from branch_master bm where bm.branch_id=" & br & ""

            dt4 = oh.ExecuteDataSet(yy).Tables(0)

            If dt4.Rows.Count > 0 Then
                st.Append(dt4.Rows(0)(0))
                st.Append("#")
                st.Append("TK")
            End If

            callbackResult = st.ToString
            Exit Sub

        ElseIf flag = "branch" Then
            BR_flag = 1
            zz = "select bm.branch_name from branch_master bm where bm.branch_id=" & tkt_br & ""
            dt5 = oh.ExecuteDataSet(zz).Tables(0)

            If dt5.Rows.Count > 0 Then
                st.Append(dt5.Rows(0)(0))
                st.Append("@")
                st.Append("#")
                st.Append("BR")

            Else
                st.Append("&")
                callbackResult = st.ToString
                Exit Sub
            End If
            callbackResult = st.ToString
            Exit Sub
        End If


    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click


        Dim ftime, ttime As String
        ftime = Me.Txt_FromTime.Value
        ttime = Me.Txt_ToTime.Value
        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        Dim dt2 As DataTable
        dt2 = oh.ExecuteDataSet("select sysdate from dual").Tables(0)
        Dim script1 As New System.Text.StringBuilder()


        Dim dt7 As DataTable = oh.ExecuteDataSet("select count(*) from TBLFIELD_PUNCH t where t.empcode = " & sf(0) & " ").Tables(0)
        If dt7.Rows(0)(0) > 0 Then
            If (Me.chk_srno.Checked = False) Then
                script1.Append("alert('Please Select SR checkbox');")
                script1.Append("window.open('Tour_apply.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
                Exit Sub
            End If
        ElseIf dt7.Rows(0)(0) = 0 Then
            If Me.chk_br.Checked = False And Me.chk_oth.Checked = False Then
                script1.Append("alert('Please Select a checkbox');")
                script1.Append("window.open('Tour_apply.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
                Exit Sub
            End If
        End If
        Try
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
            ElseIf (Me.chk_srno.Checked = True And Me.HiddenField1.Value = 1) Then
                place = Me.new_txtbrnchid_dumy.Value
            ElseIf (Me.chk_srno.Checked = True And Me.HiddenField1.Value <> 1) Then
                place = Me.Session("nib")
            Else
                place = ""
            End If

            If (Me.chk_oth.Checked = True) Then
                other = Me.Txt_oth.Text
            Else
                other = ""
            End If


            Dim parameter(13) As OracleParameter
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
            parameter(6) = New OracleParameter("oth", OracleType.VarChar, 150)
            parameter(6).Direction = ParameterDirection.Input
            parameter(6).Value = other
            parameter(7) = New OracleParameter("adv", OracleType.Number, 150)
            parameter(7).Direction = ParameterDirection.Input
            parameter(7).Value = Me.Txt_adv.Text
            parameter(8) = New OracleParameter("purp", OracleType.VarChar, 150)
            parameter(8).Direction = ParameterDirection.Input
            parameter(8).Value = Me.Txt_purp.Text
            'parameter(7).Value = Me.Txt_oth.Text

            If Me.chk_srno.Checked = True Then

                If Me.HiddenField1.Value = 1 Then

                    parameter(9) = New OracleParameter("srtcktnumber", OracleType.Number, 150)
                    parameter(9).Direction = ParameterDirection.Input
                    parameter(9).Value = Me.txt_srno_dumy.Text

                    parameter(10) = New OracleParameter("brnchname", OracleType.VarChar, 150)
                    parameter(10).Direction = ParameterDirection.Input
                    parameter(10).Value = Me.HiddenField2.Value

                    parameter(11) = New OracleParameter("brnchid", OracleType.Number, 150)
                    parameter(11).Direction = ParameterDirection.Input
                    parameter(11).Value = Me.new_txtbrnchid_dumy.Value

                    parameter(12) = New OracleParameter("tktnum", OracleType.Number, 150)
                    parameter(12).Direction = ParameterDirection.Input
                    parameter(12).Value = 1
                Else

                    parameter(9) = New OracleParameter("srtcktnumber", OracleType.Number, 150)
                    parameter(9).Direction = ParameterDirection.Input
                    parameter(9).Value = Me.txt_srno_dumy.Text

                    parameter(10) = New OracleParameter("brnchname", OracleType.VarChar, 150)
                    parameter(10).Direction = ParameterDirection.Input
                    parameter(10).Value = Me.HiddenField2.Value


                    parameter(11) = New OracleParameter("brnchid", OracleType.Number, 150)
                    parameter(11).Direction = ParameterDirection.Input
                    parameter(11).Value = Session("nib")

                    parameter(12) = New OracleParameter("tktnum", OracleType.Number, 150)
                    parameter(12).Direction = ParameterDirection.Input
                    parameter(12).Value = 1
                End If
            Else

                parameter(9) = New OracleParameter("srtcktnumber", OracleType.Number, 150)
                parameter(9).Direction = ParameterDirection.Input
                parameter(9).Value = 0

                parameter(10) = New OracleParameter("brnchname", OracleType.VarChar, 150)
                parameter(10).Direction = ParameterDirection.Input
                parameter(10).Value = "yyyy"

                parameter(11) = New OracleParameter("brnchid", OracleType.Number, 150)
                parameter(11).Direction = ParameterDirection.Input
                parameter(11).Value = -5555

                parameter(12) = New OracleParameter("tktnum", OracleType.Number, 150)
                parameter(12).Direction = ParameterDirection.Input
                parameter(12).Value = 0
            End If

            parameter(13) = New OracleParameter("msg", OracleType.VarChar, 200)
            parameter(13).Direction = ParameterDirection.Output
            'oh.ExecuteNonQuery("hrm_tour_apply", parameter)
            oh.ExecuteNonQuery("HRM_TOUR_APPLY_INDI", parameter)    'as testing

            Dim message As String
            message = parameter(13).Value

            script1.Append("        alert('" & message & "');")
            script1.Append("window.open('Tour_apply.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        Catch ex As Exception
            script1.Append("alert('Error: " & ex.Message & "');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)
        End Try
    End Sub
End Class
