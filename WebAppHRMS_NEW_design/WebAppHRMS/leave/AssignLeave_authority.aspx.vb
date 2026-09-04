Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_AssignLeave_authority_54ff50e72852
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New helper.oracle.OracleHelper
    Dim sql As String
    Dim backResult As String
    Dim dt1 As DataTable
    Dim dt As DataTable

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return backResult
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        backResult = ""
        Dim data() As String = eventArgument.Split("*")
        Select Case CInt(data(0))
            Case 1
                Dim brid As Integer = data(1)
                Dim dt1 As New DataSet
                dt1 = oh.ExecuteDataSet("select a.f_days || '*' || a.t_days || '*' || decode(rec.EMP_NAME, 'MANAPPURAM', 'NO RECOMMENDATION', rec.EMP_NAME|| '--' || prec.post_name) || '*' || san.EMP_NAME || '--' || psan.post_name || '*' ||b.BRANCH_NAME || '*' || pemp.post_name||'*'||a.l_rec_by||'*'||a.l_sanc_by||'*'||a.rule_id from leave_sanction_authority a,emp_master m,employ_firm f,branch b,emp_master rec,emp_master san, post_mst prec,post_mst psan,post_mst pemp where a.emp_code = m.EMP_CODE  and m.BRANCH_ID = b.BRANCH_ID and m.EMP_CODE = f.emp_code and a.l_rec_by = rec.EMP_CODE  and a.l_sanc_by = san.EMP_CODE  and m.POST_ID = pemp.post_id and rec.POST_ID = prec.post_id and san.POST_ID = psan.post_id and a.emp_code=" & brid & "")
                For i As Integer = 0 To dt1.Tables(0).Rows.Count - 1
                    backResult += dt1.Tables(0).Rows(i)(0).ToString
                    backResult += "@"
                Next
                Me.Hidden1.Value = backResult
        End Select
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim firmid As Integer
        firmid = Session("firm_id")
        If firmid = 8 Then

            ' Server.Transfer("AssignLeave_authorityMAC.aspx")
            Response.Redirect("AssignLeave_authorityMAC.aspx")

        End If



        Try
            'If Session("firm_id") = 2 Then
            'Dim cl_script As New StringBuilder
            'cl_script.Append("window.open('Leave_authority_update.aspx','_self');")
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            'Else
            Dim user_id() As String = Session("user_id").ToString.Split("!")
            sql = "select count(t.emp_id) from form_accessibility t where t.form_id=855  and t.emp_id='" & user_id(0) & "' "
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows(0)(0) = 0 Then
                Dim script_val1 As New StringBuilder
                script_val1.Append("         alert('You Not Authorized To View This Page !!');")
                script_val1.Append("         window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script_val1.ToString, True)
                Exit Sub
            End If
            Dim script_val As String
            script_val = "var loanno;" & "loanno='" & "" & Me.txtBranch.ClientID & "'" & " ; "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
            Dim cbscript As String = "function call_server(arg,context) { " & cbref & "; } "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "sub_call_server", cbscript, True)
            ' CType(Me.Master, WebAppHRMS.edp).Subtitle = "LEAVE SANCTION"
            If Not IsPostBack Then
                Dim usr = Session("user_id").ToString.Split("!")

                Dim dt, dt1 As DataTable
                '---sh
                If firmid = 24 Then
                    dt = oh.ExecuteDataSet("select -1 emp_code,'---Select---' from dual union all select m.EMP_CODE emp_code, m.EMP_CODE || ' - ' || m.EMP_NAME || ' - '||p.post_name from emp_master m, employ_firm f,post_mst_jwell  p where m.EMP_CODE = f.emp_code and m.POST_ID=p.post_id and f.firm_id =" & Session("firm_id") & " and m.STATUS_ID = 1 order by EMP_CODE").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select -1 emp_code,'---Select---' from dual union all select m.EMP_CODE emp_code, m.EMP_CODE || ' - ' || m.EMP_NAME || ' - '||p.post_name from emp_master m, employ_firm f,post_mst p where m.EMP_CODE = f.emp_code and m.POST_ID=p.post_id and f.firm_id =" & Session("firm_id") & " and m.STATUS_ID = 1 order by EMP_CODE").Tables(0)
                End If
                '---sh
                Me.ddl_emp.DataSource = dt
                Me.ddl_emp.DataTextField = dt.Columns(1).ColumnName
                Me.ddl_emp.DataValueField = dt.Columns(0).ColumnName
                Me.ddl_emp.DataBind()
                Me.ddlSac.DataSource = dt
                Me.ddlSac.DataTextField = dt.Columns(1).ColumnName
                Me.ddlSac.DataValueField = dt.Columns(0).ColumnName
                Me.ddlSac.DataBind()
                '---sh
                If firmid = 24 Then

                    dt1 = oh.ExecuteDataSet("select -1 emp_code,'---Select---' from dual union all select 0 emp_code, 'No Recommendation' from dual union all select m.EMP_CODE emp_code, m.EMP_CODE || ' - ' || m.EMP_NAME || ' - '||p.post_name from emp_master m, employ_firm f,post_mst_jwell p where m.EMP_CODE = f.emp_code and m.POST_ID=p.post_id and f.firm_id =" & Session("firm_id") & " and m.STATUS_ID = 1 order by EMP_CODE").Tables(0)
                Else
                    dt1 = oh.ExecuteDataSet("select -1 emp_code,'---Select---' from dual union all select 0 emp_code, 'No Recommendation' from dual union all select m.EMP_CODE emp_code, m.EMP_CODE || ' - ' || m.EMP_NAME || ' - '||p.post_name from emp_master m, employ_firm f,post_mst p where m.EMP_CODE = f.emp_code and m.POST_ID=p.post_id and f.firm_id =" & Session("firm_id") & " and m.STATUS_ID = 1 order by EMP_CODE").Tables(0)
                End If
                '---sh
                Me.ddlRec.DataSource = dt1
                Me.ddlRec.DataTextField = dt1.Columns(1).ColumnName
                Me.ddlRec.DataValueField = dt1.Columns(0).ColumnName
                Me.ddlRec.DataBind()
            End If
                'End If '--------- Firm check ends....

        Catch ex As Exception

        End Try
        'Dim usr1() As String = Me.Session("user_id").ToString.Split("!")
        Dim sc As String = "var cont_name;cont_name='" & Me.txtBranch.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var2", sc, True)
        Me.ddl_emp.Attributes.Add("onchange", "emp_fill()")
        ' Me.txt_ParFrDt.Attributes.Add("onkeyup", "OnkeyUpChqDate1()")
        ' Me.txt_ParToDt.Attributes.Add("onkeyup", "OnkeyUpChqDate()")
    End Sub
    Protected Sub cmd_cfm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_cfm.Click
        Dim Message As String
        Dim status As Integer
        Dim pr(5) As OracleParameter
        Dim oh As New Helper.Oracle.OracleHelper
        Try
            pr(0) = New OracleParameter("str", OracleType.VarChar)
            pr(0).Value = Me.Hidden2.Value
            pr(1) = New OracleParameter("userid", OracleType.VarChar)
            pr(1).Value = Me.Session("user_id")
            pr(2) = New OracleParameter("ERR_STAT", OracleType.Number, 3)
            pr(2).Direction = ParameterDirection.Output
            pr(3) = New OracleParameter("ERR_MSG", OracleType.VarChar, 300)
            pr(3).Direction = ParameterDirection.Output
            pr(4) = New OracleParameter("empcode", OracleType.Number, 6)
            pr(4).Value = Me.ddl_emp.SelectedValue
            pr(5) = New OracleParameter("typeid", OracleType.Number, 6)
            pr(5).Value = 1

            oh.ExecuteNonQuery("hrm_leaveauthority_assign", pr)
            Message = pr(3).Value
            status = pr(2).Value
        Catch ex As Exception
            Message = ex.Message
        End Try
        Dim cl_script1 As New System.Text.StringBuilder
        cl_script1.Append("         alert('" & Message & "');")
        cl_script1.Append("         window.open('../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
    End Sub
End Class
