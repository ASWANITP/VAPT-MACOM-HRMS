Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_AssignLeave_authority_54ff50e76897
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
                Dim dt1, dt2 As New DataSet
                dt1 = oh.ExecuteDataSet("select a.f_days || '*' || a.t_days || '*' || decode(rec.EMP_NAME, 'MANAPPURAM', 'NO RECOMMENDATION', rec.EMP_NAME|| '--' || prec.post_name) || '*' || san.EMP_NAME || '--' || psan.post_name || '*' ||b.BRANCH_NAME || '*' || pemp.post_name||'*'||a.l_rec_by||'*'||a.l_sanc_by||'*'||a.rule_id from leave_sanction_authority a,emp_master m,employ_firm f,branch b,emp_master rec,emp_master san, post_mst prec,post_mst psan,post_mst pemp where a.emp_code = m.EMP_CODE  and m.BRANCH_ID = b.BRANCH_ID and m.EMP_CODE = f.emp_code and a.l_rec_by = rec.EMP_CODE  and a.l_sanc_by = san.EMP_CODE  and m.POST_ID = pemp.post_id and rec.POST_ID = prec.post_id and san.POST_ID = psan.post_id and a.emp_code=" & brid & "")
                dt2 = oh.ExecuteDataSet("select decode(recom.EMP_NAME, 'MANAPPURAM', 'NO RECOMMENDATION', recom.EMP_NAME || '--' || precom.post_name)||'#'|| decode(recto.EMP_NAME, 'MANAPPURAM', 'NO RECOMMENDATION', recto.EMP_NAME || '--' || precto.post_name)||'#'|| decode(recat.EMP_NAME, 'MANAPPURAM', 'NO RECOMMENDATION', recat.EMP_NAME || '--' || precat.post_name)||'#'|| decode(recear.EMP_NAME, 'MANAPPURAM', 'NO RECOMMENDATION', recear.EMP_NAME || '--' || precear.post_name)||'#'|| ac.c_recby||'#'||ac.t_recby||'#'||ac.at_recby||'#'||ac.erly_recby||'#'||ac.rule || '*' || decode(sancom.EMP_NAME, 'MANAPPURAM', 'NO RECOMMENDATION', sancom.EMP_NAME || '--' || psancom.post_name)||'#'|| decode(sancto.EMP_NAME, 'MANAPPURAM', 'NO RECOMMENDATION', sancto.EMP_NAME || '--' || psancto.post_name)||'#'|| decode(sancat.EMP_NAME, 'MANAPPURAM', 'NO RECOMMENDATION', sancat.EMP_NAME || '--' || psancat.post_name)||'#'|| decode(sancear.EMP_NAME, 'MANAPPURAM', 'NO RECOMMENDATION', sancear.EMP_NAME || '--' || psancear.post_name)||'#'|| ac.c_sanby||'#'||ac.t_sanby||'#'||ac.at_sanby||'#'||ac.early_sancby||'#'||ac.rule from othleave_sanction_authority ac, emp_master m, employ_firm f, emp_master recom, emp_master sancom, emp_master recto, emp_master sancto, emp_master recat, emp_master sancat, emp_master recear, emp_master sancear, post_mst precom, post_mst psancom, post_mst precto, post_mst psancto, post_mst precat, post_mst psancat, post_mst precear, post_mst psancear where ac.emp_id = m.EMP_CODE and m.EMP_CODE = f.emp_code and ac.c_recby = recom.EMP_CODE and ac.c_sanby = sancom.EMP_CODE and ac.t_recby = recto.EMP_CODE and ac.t_sanby = sancto.EMP_CODE and ac.at_recby = recat.EMP_CODE and ac.at_sanby = sancat.EMP_CODE and ac.erly_recby = recear.EMP_CODE and ac.early_sancby = sancear.EMP_CODE and recom.POST_ID = precom.post_id and sancom.POST_ID = psancom.post_id and recto.POST_ID = precto.post_id and sancto.POST_ID = psancto.post_id and recat.POST_ID = precat.post_id and sancat.POST_ID = psancat.post_id and recear.POST_ID = precear.post_id and sancear.POST_ID = psancear.post_id and ac.emp_id =" & brid & "")
                For i As Integer = 0 To dt1.Tables(0).Rows.Count - 1
                    backResult += dt1.Tables(0).Rows(i)(0).ToString
                    backResult += "@"
                Next
                For j As Integer = 0 To dt2.Tables(0).Rows.Count - 1
                    backResult += dt2.Tables(0).Rows(j)(0).ToString
                Next
                Me.Hidden1.Value = backResult
        End Select
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("firm_id") = 2 Then
                Dim cl_script As New StringBuilder
                cl_script.Append("window.open('Leave_authority_update.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Else
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
                    dt = oh.ExecuteDataSet("select -1 emp_code,'---Select---' from dual union  select m.EMP_CODE emp_code, m.EMP_CODE || ' - ' || m.EMP_NAME || ' - '||p.post_name from emp_master m, employ_firm f,post_mst p where m.EMP_CODE = f.emp_code and m.POST_ID=p.post_id and f.firm_id =" & Session("firm_id") & " and m.STATUS_ID = 1 order by EMP_CODE").Tables(0)
                    Me.ddl_emp.DataSource = dt
                    Me.ddl_emp.DataTextField = dt.Columns(1).ColumnName
                    Me.ddl_emp.DataValueField = dt.Columns(0).ColumnName
                    Me.ddl_emp.DataBind()
                    Me.ddlSac.DataSource = dt
                    Me.ddlSac.DataTextField = dt.Columns(1).ColumnName
                    Me.ddlSac.DataValueField = dt.Columns(0).ColumnName
                    Me.ddlSac.DataBind()


                    Me.DropDownList3.DataSource = dt
                    Me.DropDownList3.DataTextField = dt.Columns(1).ColumnName
                    Me.DropDownList3.DataValueField = dt.Columns(0).ColumnName
                    Me.DropDownList3.DataBind()
                    Me.DropDownList5.DataSource = dt
                    Me.DropDownList5.DataTextField = dt.Columns(1).ColumnName
                    Me.DropDownList5.DataValueField = dt.Columns(0).ColumnName
                    Me.DropDownList5.DataBind()
                    Me.DropDownList7.DataSource = dt
                    Me.DropDownList7.DataTextField = dt.Columns(1).ColumnName
                    Me.DropDownList7.DataValueField = dt.Columns(0).ColumnName
                    Me.DropDownList7.DataBind()
                    Me.DropDownList9.DataSource = dt
                    Me.DropDownList9.DataTextField = dt.Columns(1).ColumnName
                    Me.DropDownList9.DataValueField = dt.Columns(0).ColumnName
                    Me.DropDownList9.DataBind()

                    dt1 = oh.ExecuteDataSet("select -1 emp_code,'---Select---' from dual union all select 0 emp_code, 'No Recommendation' from dual union all select m.EMP_CODE emp_code, m.EMP_CODE || ' - ' || m.EMP_NAME || ' - '||p.post_name from emp_master m, employ_firm f,post_mst p where m.EMP_CODE = f.emp_code and m.POST_ID=p.post_id and f.firm_id =" & Session("firm_id") & " and m.STATUS_ID = 1 order by EMP_CODE").Tables(0)
                    Me.ddlRec.DataSource = dt1
                    Me.ddlRec.DataTextField = dt1.Columns(1).ColumnName
                    Me.ddlRec.DataValueField = dt1.Columns(0).ColumnName
                    Me.ddlRec.DataBind()

                    Me.DropDownList4.DataSource = dt1
                    Me.DropDownList4.DataTextField = dt1.Columns(1).ColumnName
                    Me.DropDownList4.DataValueField = dt1.Columns(0).ColumnName
                    Me.DropDownList4.DataBind()
                    Me.DropDownList6.DataSource = dt1
                    Me.DropDownList6.DataTextField = dt1.Columns(1).ColumnName
                    Me.DropDownList6.DataValueField = dt1.Columns(0).ColumnName
                    Me.DropDownList6.DataBind()
                    Me.DropDownList8.DataSource = dt1
                    Me.DropDownList8.DataTextField = dt1.Columns(1).ColumnName
                    Me.DropDownList8.DataValueField = dt1.Columns(0).ColumnName
                    Me.DropDownList8.DataBind()
                    Me.DropDownList10.DataSource = dt1
                    Me.DropDownList10.DataTextField = dt1.Columns(1).ColumnName
                    Me.DropDownList10.DataValueField = dt1.Columns(0).ColumnName
                    Me.DropDownList10.DataBind()
                End If
            End If '--------- Firm check ends....

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
        If Me.ddl_emp.SelectedIndex = 0 Then
            Message = " please select  any Employee  "

        Else






            Try
                pr(0) = New OracleParameter("str", OracleType.VarChar)
                pr(0).Value = Me.Hidden2.Value + "%" + Me.Hidden3.Value
                pr(1) = New OracleParameter("userid", OracleType.VarChar)
                pr(1).Value = Me.Session("user_id")
                pr(2) = New OracleParameter("ERR_STAT", OracleType.Number, 3)
                pr(2).Direction = ParameterDirection.Output
                pr(3) = New OracleParameter("ERR_MSG", OracleType.VarChar, 300)
                pr(3).Direction = ParameterDirection.Output
                pr(4) = New OracleParameter("empcode", OracleType.Number, 6)
                pr(4).Value = Me.ddl_emp.SelectedValue
                pr(5) = New OracleParameter("typeid", OracleType.Number, 6)
                pr(5).Value = 3
                oh.ExecuteNonQuery("hrm_leaveauthority_assign", pr)




                Message = pr(3).Value
                status = pr(2).Value
            Catch ex As Exception
                Message = ex.Message
            End Try
        End If
        Dim cl_script1 As New System.Text.StringBuilder
        cl_script1.Append("         alert('" & Message & "');")
        cl_script1.Append("         window.open('../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
    End Sub
End Class
