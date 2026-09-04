Imports System.Data
Imports System.Data.OracleClient
Partial Class payroll_Posting_employ_enrollmant_New_28205b542528
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2 As DataTable
    Dim cbResult As String
    Dim str_tkn As New System.Text.StringBuilder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("access_id") = 33 Then
            Dim frm As Integer = Session("firm_id")
            Dim script_val As String
            script_val = "var header;" & "header='" & Me.txtid.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
            Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)

            If Not IsPostBack Then
                Dim dt, dt1, dt2, dt3, dt4 As New DataTable
                dt = oh.ExecuteDataSet("select firm_id,firm_abbr from firm_master  where firm_id=" & frm & "").Tables(0)
                Me.cmb_firm.DataSource = dt
                Me.cmb_firm.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_firm.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_firm.DataBind()
                dt1 = oh.ExecuteDataSet("select designation_id,designation from designation_master order by designation").Tables(0)
                Me.cmb_desigation.DataSource = dt1
                Me.cmb_desigation.DataTextField = dt1.Columns(1).ColumnName
                Me.cmb_desigation.DataValueField = dt1.Columns(0).ColumnName
                Me.cmb_desigation.DataBind()
                dt2 = oh.ExecuteDataSet("select dep_id,dep_name from department_mst order by dep_name").Tables(0)
                Me.cmb_dep.DataSource = dt2
                Me.cmb_dep.DataTextField = dt2.Columns(1).ColumnName
                Me.cmb_dep.DataValueField = dt2.Columns(0).ColumnName
                Me.cmb_dep.DataBind()

                'dt3 = oh.ExecuteDataSet("select -1 as hid, '-----Select RHs-----' as hname from dual union all select distinct z.hr_head,z.hr_head||'--'||e.emp_name from zonal_master z,employee_master e where e.emp_code=z.hr_head order by hid").Tables(0)
                'Me.ddl_author.DataSource = dt3
                'Me.ddl_author.DataTextField = dt3.Columns(1).ColumnName
                'Me.ddl_author.DataValueField = dt3.Columns(0).ColumnName
                'Me.ddl_author.DataBind()
                'dt4 = oh.ExecuteDataSet("select -1 as rid, '-----Select R Officer-----' as rname from dual union all select distinct z.recruitment_officer, z.recruitment_officer|| '--' || e.emp_name from zonal_master z, employee_master e where e.emp_code = z.recruitment_officer order by rid").Tables(0)
                'Me.ddl_ro.DataSource = dt4
                'Me.ddl_ro.DataTextField = dt4.Columns(1).ColumnName
                'Me.ddl_ro.DataValueField = dt4.Columns(0).ColumnName
                'Me.ddl_ro.DataBind()
                basic_pay()
                If Me.cmb_bond.SelectedValue = 2 Then
                    Me.pnl_bond.Visible = True
                Else
                    Me.pnl_bond.Visible = False
                End If
                pay_dtl()
            End If
        Else
            Response.Redirect("../../show_err.aspx")
        End If
    End Sub

    Protected Sub rd_secdep_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.rd_secdep.SelectedValue = "T" Then
            Me.pnl_secdep.Visible = True
        Else
            Me.pnl_secdep.Visible = False
        End If
    End Sub

    Protected Sub cmb_pay_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.lbl_err.Text = ""
        pay_dtl()
    End Sub
    Sub basic_pay()
        Dim dg As DataTable
        dg = oh.ExecuteDataSet("select payment_id||'!'||designation_id,designation from designation_master order by designation").Tables(0)
        Me.cmb_pay.DataSource = dg
        Me.cmb_pay.DataTextField = dg.Columns(1).ColumnName
        Me.cmb_pay.DataValueField = dg.Columns(0).ColumnName
        Me.cmb_pay.DataBind()
    End Sub
    Sub pay_dtl()
        Me.cmb_basic.Items.Clear()
        Dim qp() As String
        qp = Me.cmb_pay.SelectedValue.Split("!")
        Dim sql = "select basic_pay,increment_amt,period from pay_scale where payment_id=" & qp(0) & " order by basic_pay"
        Dim pay As New DataTable
        pay = oh.ExecuteDataSet(sql).Tables(0)
        Dim i As Integer = 0
        Dim j As Integer = 1
        Dim l As Integer = pay.Rows.Count
        Dim pay_dtl(900) As Integer

        pay_dtl(0) = pay.Rows(0)(0)
        Me.cmb_basic.Items.Add(pay_dtl(0))
        While (l > 0 And j > 0)
            'Dim str As String = pay.Rows(i)(0)
            'pay_dtl(j) = pay.Rows(i)(0)
            Dim k = pay.Rows(i)(2)
            While k > 0
                pay_dtl(j) = pay_dtl(j - 1) + CInt(pay.Rows(i)(1))
                Me.cmb_basic.Items.Add(pay_dtl(j))
                k = k - 1
                j = j + 1
            End While
            l = l - 1
            i = i + 1
            If i < pay.Rows.Count Then
                pay_dtl(j) = pay.Rows(i)(0)
                Me.cmb_basic.Items.Add(pay_dtl(j))
                j = j + 1
            End If
        End While
        'MsgBox(Me.cmb_basic.SelectedValue)
    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Response.Redirect("../../home.aspx")
    End Sub

    Protected Sub txt_applnno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim d, d1, d2 As New DataTable
        Me.lbl_err.Text = " "
        Me.txt_cname.Text = ""
        d = oh.ExecuteDataSet("select appln_name from appln_pers_dtl where appln_no=" & Me.txt_applnno.Text).Tables(0)
        If d.Rows.Count > 0 Then
            d1 = oh.ExecuteDataSet("select * from appln_interview_dtl  a where emp_code is null and a.appln_no=" & Me.txt_applnno.Text).Tables(0)
            If d1.Rows.Count > 0 Then
                Me.txt_cname.Text = d.Rows(0)(0)
            Else
                Me.lbl_err.Text = " Check&nbspthe&nbspApplication&nbspNo&nbspEntered&nbspis&nbspCleared&nbspor&nbspNot"
                Me.lbl_err.Font.Bold = True
                Me.lbl_err.ForeColor = Drawing.Color.Red
            End If
        Else
            Me.lbl_err.Text = " Application&nbspNo&nbsp<font color=Navy>" + Me.txt_applnno.Text + "</font>&nbspdoes&nbspnot&nbspexist"
            Me.lbl_err.Font.Bold = True
            Me.lbl_err.ForeColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub cmb_bond_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.cmb_bond.SelectedValue = 2 Then
            Me.pnl_bond.Visible = True
        Else
            Me.pnl_bond.Visible = False
        End If
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim oh As New Helper.Oracle.OracleHelper
        Dim op(24) As OracleParameter

        op(0) = New OracleParameter("appln", OracleType.Number, 10)
        op(0).Value = Me.txt_applnno.Text
        op(0).Direction = ParameterDirection.Input

        op(1) = New OracleParameter("emptype", OracleType.Number, 5)
        op(1).Value = Me.cmb_type.SelectedValue
        op(1).Direction = ParameterDirection.Input

        op(2) = New OracleParameter("emp_period", OracleType.Number, 5)
        op(2).Value = Me.txt_period.Text
        op(2).Direction = ParameterDirection.Input

        op(3) = New OracleParameter("firm", OracleType.Number, 7)
        op(3).Value = Me.cmb_firm.SelectedValue
        op(3).Direction = ParameterDirection.Input

        op(4) = New OracleParameter("joindt", OracleType.DateTime, 7)
        op(4).Value = Me.txt_jodt.Text
        op(4).Direction = ParameterDirection.Input

        op(5) = New OracleParameter("esiflag", OracleType.Char, 2)
        op(5).Value = Me.rd_esi.SelectedValue
        op(5).Direction = ParameterDirection.Input

        op(6) = New OracleParameter("medical", OracleType.Char, 2)
        op(6).Value = Me.rd_medical.SelectedValue
        op(6).Direction = ParameterDirection.Input

        op(7) = New OracleParameter("pfflag", OracleType.Char, 2)
        op(7).Value = Me.rd_pf.SelectedValue
        op(7).Direction = ParameterDirection.Input

        op(8) = New OracleParameter("desi_id", OracleType.Number, 5)
        op(8).Value = Me.cmb_desigation.SelectedValue
        op(8).Direction = ParameterDirection.Input

        op(9) = New OracleParameter("dep_id", OracleType.Number, 5)
        op(9).Value = Me.cmb_dep.SelectedValue
        op(9).Direction = ParameterDirection.Input

        op(10) = New OracleParameter("daflag", OracleType.Char, 2)
        op(10).Value = Me.rd_da.SelectedValue
        op(10).Direction = ParameterDirection.Input

        op(11) = New OracleParameter("payid", OracleType.Number, 5)
        Dim qp() As String
        qp = Me.cmb_pay.SelectedValue.Split("!")
        op(11).Value = qp(0)
        op(11).Direction = ParameterDirection.Input

        op(12) = New OracleParameter("basic", OracleType.Number, 10, 2)
        op(12).Value = Me.cmb_basic.SelectedValue
        op(12).Direction = ParameterDirection.Input

        op(13) = New OracleParameter("secflag", OracleType.Char, 2)
        op(13).Value = Me.rd_secdep.SelectedValue
        op(13).Direction = ParameterDirection.Input
        If Me.rd_secdep.SelectedValue = "T" Then
            op(14) = New OracleParameter("secdep", OracleType.Number, 10, 2)
            op(14).Value = Me.txt_secdep.Text
            op(14).Direction = ParameterDirection.Input

            op(15) = New OracleParameter("depamt", OracleType.Number, 10, 2)
            op(15).Value = Me.txt_depamt.Text
            op(15).Direction = ParameterDirection.Input

            op(16) = New OracleParameter("instamt", OracleType.Number, 10, 2)
            op(16).Value = Me.txt_rdamt.Text
            op(16).Direction = ParameterDirection.Input

            op(17) = New OracleParameter("instno", OracleType.VarChar, 15)
            op(17).Value = Me.txt_instno.Text
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

            op(17) = New OracleParameter("instno", OracleType.VarChar, 15)
            op(17).Value = 0
            op(17).Direction = ParameterDirection.Input
        End If

        op(18) = New OracleParameter("bondflag", OracleType.Number, 2)
        op(18).Value = Me.cmb_bond.SelectedValue
        op(18).Direction = ParameterDirection.Input

        If Me.cmb_bond.SelectedValue = 2 Then
            op(19) = New OracleParameter("bondamt", OracleType.VarChar, 10, 2)
            op(19).Value = Me.txt_bondamt.Text
            op(19).Direction = ParameterDirection.Input

            op(20) = New OracleParameter("bondprd", OracleType.Number, 6)
            op(20).Value = Me.txt_bondprd.Text
            op(20).Direction = ParameterDirection.Input
        Else
            op(19) = New OracleParameter("bondamt", OracleType.VarChar, 10, 2)
            op(19).Value = 0
            op(19).Direction = ParameterDirection.Input

            op(20) = New OracleParameter("bondprd", OracleType.Number, 6)
            op(20).Value = 0
            op(20).Direction = ParameterDirection.Input
        End If

        op(21) = New OracleParameter("userid", OracleType.VarChar, 25)
        op(21).Value = Session("user_id")
        op(21).Direction = ParameterDirection.Input

        op(23) = New OracleParameter("banker", OracleType.Number, 1)
        op(23).Value = Me.rd_retired.SelectedValue
        op(23).Direction = ParameterDirection.Input

        op(24) = New OracleParameter("aut_per", OracleType.Number, 10)
        op(24).Value = Me.txtid.Text
        op(24).Direction = ParameterDirection.Input

        op(22) = New OracleParameter("empcd", OracleType.Number, 5)
        op(22).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("employ_add", op)
        If Not IsDBNull(op(22).Value) Then
            'Dim ps As New PHelper.passwdClass
            'ps.reset_password(CInt(op(22).Value), "ITJOINING")
        End If
        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("         alert(' Sucessfully Confirmed Employee Code: " & op(22).Value & "');")
        cl_script0.Append("       window.open('../../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
    End Sub

    Protected Sub rd_da_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.lbl_err.Text = ""
        Dim frd As Integer = Session("firm_id")
        If Me.cmb_basic.Items.Count > 0 Then
            Dim df() As String
            df = Me.cmb_pay.SelectedValue.Split("!")
            If Me.rd_da.SelectedValue = "T" And df(0) <> 14 Then
                Dim da As New DataTable
                da = oh.ExecuteDataSet("select value from da_index where to_dt is NULL and firm_id= " & frd & "").Tables(0)
                Dim sal As Decimal
                sal = CDec(Me.cmb_basic.SelectedValue) + CDec(da.Rows(0)(0))
                Me.txt_salary.Text = sal
            Else
                Me.txt_salary.Text = CDec(Me.cmb_basic.SelectedValue)
            End If
        Else
            Me.lbl_err.ForeColor = Drawing.Color.Red
            Me.lbl_err.Text = "Select Basic Pay"
        End If

    End Sub

    Protected Sub cmb_basic_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.lbl_err.Text = ""
        Dim frd As Integer = Session("firm_id")
        If Me.cmb_basic.Items.Count > 0 Then
            Dim df() As String
            df = Me.cmb_pay.SelectedValue.Split("!")
            If Me.rd_da.SelectedValue = "T" And df(0) <> 14 Then
                Dim da As New DataTable
                da = oh.ExecuteDataSet("select value from da_index where to_dt is NULL  and firm_id= " & frd & "").Tables(0)
                Dim sal As Decimal
                sal = CDec(Me.cmb_basic.SelectedValue) + CDec(da.Rows(0)(0))
                Me.txt_salary.Text = sal
            Else
                Me.txt_salary.Text = CDec(Me.cmb_basic.SelectedValue)
            End If
        Else
            Me.lbl_err.ForeColor = Drawing.Color.Red
            Me.lbl_err.Text = "Select Basic Pay"
        End If
    End Sub

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)

        Select Case (x)

            Case "1"
                dt1 = oh.ExecuteDataSet("select count(e.emp_code) from employee_master e,region_master r where e.emp_code=r.rh_hr and e.emp_code = '" & str(1) & "'").Tables(0)
                Dim j As Integer = dt1.Rows(0)(0)
                If j = 0 Then
                    Dim cl_script0 As New System.Text.StringBuilder
                    cl_script0.Append("         alert('Sorry!!! Emp code is nOt correct! ');")
                    cl_script0.Append("       window.open('../../home.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
                Else
                    dt = oh.ExecuteDataSet("select e.emp_code || '~' || e.emp_name from  employee_master  e  where e.emp_code = '" & str(1) & "'").Tables(0)
                    'dt = oh.ExecuteDataSet("select e.emp_code || '~' || e.emp_name from designation_master  c,branch_dtl_new t,department_mst  q,employee_master e,employee_master_dtl f,m_wage_his   w,post_mst  p where c.designation_id = e.designation_id and t.branch_id = e.branch_id and q.dep_id = e.department_id and w.emp_code = e.emp_code and e.emp_code = f.emp_code and w.emp_code = f.emp_code and e.post_id = p.post_id and e.emp_code='" & str(1) & "' group by e.emp_code ,e.emp_name,t.branch_name,c.designation ,e.join_dt,q.dep_name,p.post_name, f.pf_accno ").Tables(0)
                    'dt = oh.ExecuteDataSet("select  e.emp_code || '~' || e.emp_name || '~' || t.branch_name || '~' || c.designation || '~' || e.join_dt||'~'||q.dep_name ||'~'||p.post_name ||'~'||f.pf_accno ||'~'||w.p_fund from designation_master c,branch_dtl_new t,department_mst q,employee_master e,employee_master_dtl f,m_wage_his w ,post_mst p where c.designation_id = e.designation_id and t.branch_id = e.branch_id and q.dep_id = e.department_id and w.emp_code=e.emp_code and e.emp_code=f.emp_code and w.emp_code=f.emp_code and e.post_id=p.post_id and (w.sal_dt) in (select max(p.sal_dt)from m_wage_his p where e.emp_code ='" & str(1) & "')").Tables(0)
                    If dt.Rows.Count = 0 Then
                        str_tkn.Append("NULL")
                    Else
                        str_tkn.Append(dt.Rows(0)(0))
                        cbResult = str_tkn.ToString
                    End If
                End If
        End Select
    End Sub


    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult

        Return cbResult

    End Function
End Class
