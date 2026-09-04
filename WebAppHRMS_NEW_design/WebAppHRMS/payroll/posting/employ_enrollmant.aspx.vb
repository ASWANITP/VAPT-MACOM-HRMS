Imports System.Data
Imports System.Data.OracleClient
Partial Class payroll_Posting_employ_enrollmant_e5781d5f3864
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim frm As Integer = Session("firm_id")
        If Session("access_id") = 33 Then
            If Not IsPostBack Then
                Dim dt, dt1, dt2 As New DataTable
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
        Dim oh As New helper.oracle.OracleHelper
        Dim op(23) As OracleParameter

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

        op(22) = New OracleParameter("empcd", OracleType.Number, 5)
        op(22).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("employ_add_new", op)
        If Not IsDBNull(op(22).Value) Then
            '            Dim ps As New PHelper.passwdClass
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
                da = oh.ExecuteDataSet("select value from da_index where to_dt is NULL and firm_id=" & frd & "").Tables(0)
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
End Class
