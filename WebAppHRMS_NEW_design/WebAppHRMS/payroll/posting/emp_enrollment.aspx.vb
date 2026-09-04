Imports System.Data
Imports System.Data.oracleclient
Imports System.IO

Partial Class payroll_posting_emp_enrollment_771140627393
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New helper.oracle.OracleHelper
    Dim res As String
    Dim frm As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "EMPLOYEE ENROLLMENT"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.subtitle = "EMPLOYEE ENROLLMENT"
        frm = Session("firm_id")
        If frm = 28 Then
            Response.Redirect("emp_enrollment_mfdtn.aspx")
            Exit Sub
        End If
        If frm = 27 Then
            Response.Redirect("emp_enrollment_maf.aspx")
            Exit Sub
        End If
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txt_applnno.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server(arg,context) { " & cbref & "; } "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
        If Session("access_id") = 33 Then
            If Not IsPostBack Then
                Me.txt_applnno.Focus()
                Dim dt, dt1, dt2, dt33, dt44 As New DataTable
                dt = oh.ExecuteDataSet("select firm_id,firm_abbr from firm_master  where firm_id= " & frm & "").Tables(0)
                Me.cmb_firm.DataSource = dt
                Me.cmb_firm.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_firm.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_firm.DataBind()
                dt1 = oh.ExecuteDataSet("select designation_id,designation from designation_master order by designation").Tables(0)
                Me.cmb_desigation.DataSource = dt1
                Me.cmb_desigation.DataTextField = dt1.Columns(1).ColumnName
                Me.cmb_desigation.DataValueField = dt1.Columns(0).ColumnName
                Me.cmb_desigation.DataBind()
                dt2 = oh.ExecuteDataSet("select dep_id, dep_name from department_mst d where d.firm_id=" & frm & "  union all select dep_id, dep_name from department_mst d where d.firm_id=0 order by dep_name").Tables(0)
                Me.cmb_dep.DataSource = dt2
                Me.cmb_dep.DataTextField = dt2.Columns(1).ColumnName
                Me.cmb_dep.DataValueField = dt2.Columns(0).ColumnName
                Me.cmb_dep.DataBind()
                basic_pay()
                Dim datable As DataTable = oh.ExecuteDataSet("select value from da_index a where a.to_dt is null and firm_id=" & frm & "").Tables(0)
                Me.hid1_da.Value = datable.Rows(0)(0)
                dt = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
                Me.hdn_sysdate.Value = Format(dt.Rows(0)(0), "dd/MMM/yyyy")
                Me.txt_period.Value = 6
                Me.txt_jodt.Text = Format(dt.Rows(0)(0), "dd/MMM/yyyy")



                If frm = 16 Or frm = 33 Then
                    dt33 = oh.ExecuteDataSet("select -1,'---------Select----------' from dual union all select 0 emp_code, 'No Recommendation' from dual union all select e.emp_code, e.emp_code||'--'||e.emp_name   from employee_master  e  join employ_firm f on f.emp_code=e.emp_code and f.firm_id in (16,33) where e.status_id=1  order by 1 ").Tables(0)
                    dt44 = oh.ExecuteDataSet("select -1,'---------Select----------' from dual union all select e.emp_code, e.emp_code||'--'||e.emp_name   from employee_master  e  join employ_firm f on f.emp_code=e.emp_code and f.firm_id in (16,33) where e.status_id=1  order by 1 ").Tables(0)
                ElseIf frm = 6 Or frm = 14 Or frm = 31 Or frm = 32 Then
                    dt33 = oh.ExecuteDataSet("select -1,'---------Select----------' from dual union all select 0 emp_code, 'No Recommendation' from dual union all select e.emp_code, e.emp_code||'--'||e.emp_name   from employee_master  e  join employ_firm f on f.emp_code=e.emp_code and f.firm_id in (6,14,31,32) where e.status_id=1  order by 1 ").Tables(0)
                    dt44 = oh.ExecuteDataSet("select -1,'---------Select----------' from dual union all select e.emp_code, e.emp_code||'--'||e.emp_name   from employee_master  e  join employ_firm f on f.emp_code=e.emp_code and f.firm_id in (6,14,31,32) where e.status_id=1  order by 1 ").Tables(0)
                Else
                    dt33 = oh.ExecuteDataSet("select -1,'---------Select----------' from dual union all select 0 emp_code, 'No Recommendation' from dual union all select e.emp_code, e.emp_code||'--'||e.emp_name   from employee_master  e  join employ_firm f on f.emp_code=e.emp_code and f.firm_id=" & frm & " where e.status_id=1  order by 1 ").Tables(0)
                    dt44 = oh.ExecuteDataSet("select -1,'---------Select----------' from dual union all select e.emp_code, e.emp_code||'--'||e.emp_name   from employee_master  e  join employ_firm f on f.emp_code=e.emp_code and f.firm_id=" & frm & " where e.status_id=1  order by 1 ").Tables(0)
                End If

                Me.cmb_sanct1.DataSource = dt44
                Me.cmb_sanct1.DataTextField = dt44.Columns(1).ColumnName
                Me.cmb_sanct1.DataValueField = dt44.Columns(0).ColumnName
                Me.cmb_sanct1.DataBind()
                Me.cmb_sanct2.DataSource = dt44
                Me.cmb_sanct2.DataTextField = dt44.Columns(1).ColumnName
                Me.cmb_sanct2.DataValueField = dt44.Columns(0).ColumnName
                Me.cmb_sanct2.DataBind()
                Me.cmb_sanct3.DataSource = dt44
                Me.cmb_sanct3.DataTextField = dt44.Columns(1).ColumnName
                Me.cmb_sanct3.DataValueField = dt44.Columns(0).ColumnName
                Me.cmb_sanct3.DataBind()
                Me.cmb_sanct4.DataSource = dt33
                Me.cmb_sanct4.DataTextField = dt33.Columns(1).ColumnName
                Me.cmb_sanct4.DataValueField = dt33.Columns(0).ColumnName
                Me.cmb_sanct4.DataBind()
                Me.cmb_sanct5.DataSource = dt44
                Me.cmb_sanct5.DataTextField = dt44.Columns(1).ColumnName
                Me.cmb_sanct5.DataValueField = dt44.Columns(0).ColumnName
                Me.cmb_sanct5.DataBind()
                Me.cmb_rec1.DataSource = dt33
                Me.cmb_rec1.DataTextField = dt33.Columns(1).ColumnName
                Me.cmb_rec1.DataValueField = dt33.Columns(0).ColumnName
                Me.cmb_rec1.DataBind()
                Me.cmb_rec2.DataSource = dt33
                Me.cmb_rec2.DataTextField = dt33.Columns(1).ColumnName
                Me.cmb_rec2.DataValueField = dt33.Columns(0).ColumnName
                Me.cmb_rec2.DataBind()
                Me.cmb_rec3.DataSource = dt33
                Me.cmb_rec3.DataTextField = dt33.Columns(1).ColumnName
                Me.cmb_rec3.DataValueField = dt33.Columns(0).ColumnName
                Me.cmb_rec3.DataBind()
                Me.cmb_rec4.DataSource = dt33
                Me.cmb_rec4.DataTextField = dt33.Columns(1).ColumnName
                Me.cmb_rec4.DataValueField = dt33.Columns(0).ColumnName
                Me.cmb_rec4.DataBind()
                Me.cmb_rec5.DataSource = dt33
                Me.cmb_rec5.DataTextField = dt33.Columns(1).ColumnName
                Me.cmb_rec5.DataValueField = dt33.Columns(0).ColumnName
                Me.cmb_rec5.DataBind()

                Me.cmb_sanct6.DataSource = dt44
                Me.cmb_sanct6.DataTextField = dt44.Columns(1).ColumnName
                Me.cmb_sanct6.DataValueField = dt44.Columns(0).ColumnName
                Me.cmb_sanct6.DataBind()
                Me.cmb_sanct7.DataSource = dt44
                Me.cmb_sanct7.DataTextField = dt44.Columns(1).ColumnName
                Me.cmb_sanct7.DataValueField = dt44.Columns(0).ColumnName
                Me.cmb_sanct7.DataBind()
                Me.cmb_sanct8.DataSource = dt44
                Me.cmb_sanct8.DataTextField = dt44.Columns(1).ColumnName
                Me.cmb_sanct8.DataValueField = dt44.Columns(0).ColumnName
                Me.cmb_sanct8.DataBind()
                Me.cmb_sanct9.DataSource = dt44
                Me.cmb_sanct9.DataTextField = dt44.Columns(1).ColumnName
                Me.cmb_sanct9.DataValueField = dt44.Columns(0).ColumnName
                Me.cmb_sanct9.DataBind()
                Me.cmb_rec6.DataSource = dt33
                Me.cmb_rec6.DataTextField = dt33.Columns(1).ColumnName
                Me.cmb_rec6.DataValueField = dt33.Columns(0).ColumnName
                Me.cmb_rec6.DataBind()
                Me.cmb_rec7.DataSource = dt33
                Me.cmb_rec7.DataTextField = dt33.Columns(1).ColumnName
                Me.cmb_rec7.DataValueField = dt33.Columns(0).ColumnName
                Me.cmb_rec7.DataBind()
                Me.cmb_rec8.DataSource = dt33
                Me.cmb_rec8.DataTextField = dt33.Columns(1).ColumnName
                Me.cmb_rec8.DataValueField = dt33.Columns(0).ColumnName
                Me.cmb_rec8.DataBind()
                Me.cmb_rec9.DataSource = dt33
                Me.cmb_rec9.DataTextField = dt33.Columns(1).ColumnName
                Me.cmb_rec9.DataValueField = dt33.Columns(0).ColumnName
                Me.cmb_rec9.DataBind()



            End If
        Else
            Response.Redirect("../../show_err.aspx")
        End If

    End Sub
    Sub basic_pay()
        Dim dg As DataTable
        dg = oh.ExecuteDataSet("select payment_id||'!'||designation_id,designation from designation_master order by designation").Tables(0)
        Me.cmb_pay.DataSource = dg
        Me.cmb_pay.DataTextField = dg.Columns(1).ColumnName
        Me.cmb_pay.DataValueField = dg.Columns(0).ColumnName
        Me.cmb_pay.DataBind()
        Me.hid2.Value = dg.Rows(0)(0)
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)
        Dim y = str(1).ToString.Split("!")
        Dim strr As New StringBuilder
        Select Case (x)
            Case "1"
                Dim sql = "select basic_pay,increment_amt,period from pay_scale where payment_id=" & y(0) & " order by basic_pay"
                Dim pay As New DataTable
                pay = oh.ExecuteDataSet(sql).Tables(0)
                Dim i As Integer = 0
                Dim j As Integer = 1
                Dim l As Integer = pay.Rows.Count
                Dim pay_dtl(900) As Integer

                pay_dtl(0) = pay.Rows(0)(0)
                strr.Append("1$")

                strr.Append(pay_dtl(0))
                strr.Append("#")

                While (l > 0 And j > 0)
                    Dim k = pay.Rows(i)(2)
                    While k > 0
                        pay_dtl(j) = pay_dtl(j - 1) + CInt(pay.Rows(i)(1))
                        strr.Append(pay.Rows(i)(0) + pay.Rows(i)(1) * j)
                        strr.Append("#")
                        k = k - 1
                        j = j + 1
                    End While
                    l = l - 1
                    i = i + 1
                    If i < pay.Rows.Count Then
                        pay_dtl(j) = pay.Rows(i)(0)
                        strr.Append(pay_dtl(j))
                        strr.Append("#")
                        j = j + 1
                    End If
                    j = 1
                End While

            Case "2"
                Dim fdt(900) As String
                Dim d, d1, d2 As New DataTable
                d = oh.ExecuteDataSet("select * from appln_pers_dtl h,appln_interview_dtl a where h.appln_no=a.appln_no and a.emp_code is null and a.status=1 and h.rejoining in(0,1) and h.appln_no= " & str(1)).Tables(0)


                Dim qry As String
                Dim count As Integer
                Dim i As Integer = 0
                Dim j As Integer = 0
                Dim dt1, dt2 As DataTable
                dt1 = oh.ExecuteDataSet("select count(t.f_days) as total from LEAVE_SANCTION_DAYS t where t.firm_id=" & frm & "").Tables(0)
                qry = "select t.f_days|| '@' || t.t_days as days from LEAVE_SANCTION_DAYS t where t.firm_id=" & frm & " order by t.f_days asc"
                dt2 = oh.ExecuteDataSet(qry).Tables(0)
                If dt1.Rows.Count > 0 Then
                    count = dt1.Rows(0)(0)
                End If


                If d.Rows.Count > 0 Then
                    d1 = oh.ExecuteDataSet("select appln_name from appln_pers_dtl a,appln_interview_dtl b where b.emp_code is null and a.appln_no=b.appln_no and a.appln_no=" & str(1)).Tables(0)
                    If d1.Rows.Count > 0 Then
                        strr.Append("2$")
                        strr.Append(d1.Rows(0)(0))

                        strr.Append("$")
                        strr.Append(count)
                        strr.Append("@")
                        For i = 0 To dt2.Rows.Count - 1
                            fdt(j) = dt2.Rows(i)(0)
                            strr.Append(fdt(j))
                            strr.Append("@")
                            j = j + 1
                        Next


                    Else
                        strr.Append("3$")
                    End If
                Else
                    Dim kg As DataTable = oh.ExecuteDataSet("select count(*) from appln_interview_dtl where appln_no=" & str(1)).Tables(0)
                    If kg.Rows(0)(0) > 0 Then
                        Dim dtw As DataTable = oh.ExecuteDataSet("select count(*) from appln_interview_dtl where emp_code is not null and appln_no=" & str(1)).Tables(0)
                        If dtw.Rows(0)(0) > 0 Then
                            strr.Append("6$")
                        Else
                            strr.Append("7$")
                        End If

                    Else
                        strr.Append("5$")
                    End If
                    strr.Append("4$")
                End If
        End Select
        res = strr.ToString
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim op(26) As OracleParameter
        op(0) = New OracleParameter("appln", OracleType.Number, 10)
        op(0).Value = Me.hid_appln_no.Value
        op(0).Direction = ParameterDirection.Input

        op(1) = New OracleParameter("emptype", OracleType.Number, 5)
        op(1).Value = Me.cmb_type.SelectedValue
        op(1).Direction = ParameterDirection.Input

        op(2) = New OracleParameter("emp_period", OracleType.Number, 5)
        op(2).Value = Me.txt_period.Value
        op(2).Direction = ParameterDirection.Input

        op(3) = New OracleParameter("firm", OracleType.Number, 7)
        op(3).Value = Me.cmb_firm.SelectedValue
        op(3).Direction = ParameterDirection.Input

        op(4) = New OracleParameter("joindt", OracleType.DateTime, 7)
        op(4).Value = Format(CDate(Me.txt_jodt.Text), "dd/MMM/yyyy")
        op(4).Direction = ParameterDirection.Input

        op(5) = New OracleParameter("esiflag", OracleType.Char, 2)
        op(5).Value = Me.hid_esi.Value
        op(5).Direction = ParameterDirection.Input

        op(6) = New OracleParameter("pfflag", OracleType.Char, 2)
        op(6).Value = Me.hid_pf.Value
        op(6).Direction = ParameterDirection.Input

        op(7) = New OracleParameter("desi_id", OracleType.Number, 5)
        op(7).Value = Me.cmb_desigation.SelectedValue
        op(7).Direction = ParameterDirection.Input

        op(9) = New OracleParameter("dep_id", OracleType.Number, 5)
        op(9).Value = Me.cmb_dep.SelectedValue
        op(9).Direction = ParameterDirection.Input

        op(10) = New OracleParameter("daflag", OracleType.Char, 2)
        op(10).Value = Me.hid_da.Value
        op(10).Direction = ParameterDirection.Input

        op(11) = New OracleParameter("payid", OracleType.Number, 5)
        Dim qp() As String
        qp = Me.cmb_pay.SelectedValue.Split("!")
        op(11).Value = qp(0)
        op(11).Direction = ParameterDirection.Input

        op(12) = New OracleParameter("basic", OracleType.Number, 10, 2)
        op(12).Value = Me.hid_basic.Value
        op(12).Direction = ParameterDirection.Input

        op(13) = New OracleParameter("secflag", OracleType.Char, 2)
        op(13).Value = Me.hid_security.Value
        op(13).Direction = ParameterDirection.Input
        If Me.hid_security.Value = "T" Then
            op(14) = New OracleParameter("secdep", OracleType.Number, 10, 2)
            op(14).Value = Me.txt_sec.Value
            op(14).Direction = ParameterDirection.Input

            op(15) = New OracleParameter("depamt", OracleType.Number, 10, 2)
            op(15).Value = Me.txt_dep.Value
            op(15).Direction = ParameterDirection.Input

            op(16) = New OracleParameter("instamt", OracleType.Number, 10, 2)
            op(16).Value = Me.txt_installment_amount.Value
            op(16).Direction = ParameterDirection.Input

            op(17) = New OracleParameter("instno", OracleType.Number, 15)
            op(17).Value = Me.txt_installments.Value
            op(17).Direction = ParameterDirection.Input
        Else
            op(14) = New OracleParameter("secdep", OracleType.Number, 10, 2)
            op(14).Value = 0
            op(14).Direction = ParameterDirection.Input

            op(15) = New OracleParameter("depamt", OracleType.Number, 10, 2)
            op(15).Value = 0
            op(15).Direction = ParameterDirection.Input

            op(16) = New OracleParameter("instamt", OracleType.Number, 10, 2)
            op(16).Value = 0
            op(16).Direction = ParameterDirection.Input

            op(17) = New OracleParameter("instno", OracleType.Number, 15)
            op(17).Value = 0
            op(17).Direction = ParameterDirection.Input
        End If

        op(18) = New OracleParameter("bondflag", OracleType.Number, 2)
        op(18).Value = Me.cmb_bond.SelectedValue
        op(18).Direction = ParameterDirection.Input

        If Me.cmb_bond.SelectedValue = 2 Then
            op(19) = New OracleParameter("bondamt", OracleType.Number, 10)
            If Me.txt_bond.Value = "" Then
                op(19).Value = 0
            Else
                op(19).Value = Me.txt_bond.Value
            End If

            op(19).Direction = ParameterDirection.Input

            op(20) = New OracleParameter("bondprd", OracleType.Number, 6)
            If Me.txt_bond.Value = "" Then
                op(20).Value = 0
            Else
                op(20).Value = Me.txt_bond_period.Text
            End If
            op(20).Direction = ParameterDirection.Input
        Else
            op(19) = New OracleParameter("bondamt", OracleType.Number, 10)
            op(19).Value = 0
            op(19).Direction = ParameterDirection.Input

            op(20) = New OracleParameter("bondprd", OracleType.Number, 6)
            op(20).Value = 0
            op(20).Direction = ParameterDirection.Input
        End If

        op(8) = New OracleParameter("userid", OracleType.VarChar, 25)
        op(8).Value = Session("user_id")
        op(8).Direction = ParameterDirection.Input

        Dim bank As Integer = 0
        If Me.chk_retired.Checked = True Then
            bank = 1
        End If
        op(21) = New OracleParameter("banker", OracleType.Number, 1)
        op(21).Value = bank
        op(21).Direction = ParameterDirection.Input

        op(22) = New OracleParameter("mediflg", OracleType.VarChar, 1)
        op(22).Value = Me.hid_mediflag.Value
        op(22).Direction = ParameterDirection.Input

        op(23) = New OracleParameter("empcd", OracleType.Number, 5)
        op(23).Direction = ParameterDirection.Output

        op(24) = New OracleParameter("msg", OracleType.VarChar, 150)
        op(24).Direction = ParameterDirection.Output



        '----------------------megha--------------------------------

        op(25) = New OracleParameter("datas", OracleType.VarChar, 500)
        op(25).Direction = ParameterDirection.Input
        op(25).Value = Me.hid_datas.Value
        op(26) = New OracleParameter("other", OracleType.VarChar, 500)
        op(26).Direction = ParameterDirection.Input
        op(26).Value = Me.hid_others.Value




        '-----------------------------------------------------------


        oh.ExecuteNonQuery("employ_add_new", op)
        Dim cl_script0 As New System.Text.StringBuilder

        If Not IsDBNull(op(23).Value) Then
            Dim ps As New WebAppHRMS.passwdClass
            ps.reset_password(CInt(op(23).Value), "ITJOINING")
            cl_script0.Append("         alert(' Sucessfully Confirmed Employee Code:  " & op(23).Value & "');")
            cl_script0.Append("       window.open('../../home.aspx','_self');")
        Else
            cl_script0.Append("         alert(' Error =>" & op(24).Value & "');")
            cl_script0.Append("window.open('emp_enrollment.aspx','_self');")
        End If

        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
    End Sub


End Class
