Imports System.Data
Imports System.Data.oracleclient
Partial Class manpower_reqq_2df121803273
    Inherits System.Web.UI.Page
    Dim sql, sql1 As String
    Dim oh As New helper.oracle.OracleHelper
    Dim res As String
    Dim usr() As String
    Dim ff, branch_id, gen As Integer
    Dim ae As Integer
    Dim emp, dt, dt1, ds, ds1 As New DataTable
    Dim str_tkn As New StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            usr = Me.Session("user_id").ToString.Split("!")
            ff = Session("firm_id")
            branch_id = Session("branch_id")


            If Not IsPostBack Then
                Me.ADD.Checked = True
                ae = 1
                ds = oh.ExecuteDataSet("select count(t.emp_id) from form_accessibility t where t.form_id=1294 and t.emp_id=" & usr(0)).Tables(0)
                ds1 = oh.ExecuteDataSet("select t.access_id from employee_master t where t.emp_code=" & usr(0)).Tables(0)

                If CInt(ds.Rows(0)(0)) <> 1 And CInt(ds1.Rows(0)(0)) <> 33 Then
                    Dim cl_01 As New System.Text.StringBuilder
                    cl_01.Append("         alert('You Are Not Authorised..!');")
                    cl_01.Append(" window.open('../home.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_01.ToString, True)
                Else

                    dt = oh.ExecuteDataSet("select '-1','------select---------' from dual union select t.reason_id||'*'||t.additional_info,t.reason_text from REQUIRMENT_REASON_MASTER t order by 1").Tables(0)
                    Me.cmb_reason.DataSource = dt
                    Me.cmb_reason.DataTextField = dt.Columns(1).ColumnName
                    Me.cmb_reason.DataValueField = dt.Columns(0).ColumnName
                    Me.cmb_reason.DataBind()

                    dt = oh.ExecuteDataSet("select f.firm_id,f.firm_name from firm_master f where f.firm_id=" & ff).Tables(0)
                    Me.cmb_firm.DataSource = dt
                    Me.cmb_firm.DataTextField = dt.Columns(1).ColumnName
                    Me.cmb_firm.DataValueField = dt.Columns(0).ColumnName
                    Me.cmb_firm.DataBind()

                    dt = oh.ExecuteDataSet("select to_char(to_date(sysdate),'dd/mon/yyyy') from dual").Tables(0)
                    Me.txt_date.Text = dt.Rows(0)(0)
                    Me.txt_exp_dt.Text = dt.Rows(0)(0)

                End If
            End If

            Dim script_val As String
            script_val = "var header;" & "header='" & Me.txt_date.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
            Me.txt_date.Attributes.Add("onchange", "return checkdt1()")
            Me.txt_exp_dt.Attributes.Add("onchange", "return checkdt2()")

        Catch ex As Exception
            Me.Label15.Text = ex.Message
        End Try
    End Sub

    Protected Sub btn_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_confirm.Click

        Dim status As Integer
        Dim msg As String
        Dim req_by = Me.cmb_firm.SelectedItem.ToString()

        Dim params(22) As OracleParameter

        params(0) = New OracleParameter("PDATE_REQ", OracleType.VarChar, 200)
        params(0).Value = Me.txt_date.Text
        params(0).Direction = ParameterDirection.Input

        params(1) = New OracleParameter("PREQ_BY", OracleType.VarChar, 200)
        params(1).Value = req_by
        params(1).Direction = ParameterDirection.Input

        params(2) = New OracleParameter("PJOB_TITLE", OracleType.VarChar, 200)
        params(2).Value = Me.Txt_job.Text
        params(2).Direction = ParameterDirection.Input

        params(3) = New OracleParameter("PNO_OF_REQ", OracleType.Number, 5)
        params(3).Value = CInt(Me.txt_no_req.Text)
        params(3).Direction = ParameterDirection.Input


        params(4) = New OracleParameter("PDIVISION", OracleType.VarChar, 200)
        params(4).Value = Me.txt_div.Text
        params(4).Direction = ParameterDirection.Input

        params(5) = New OracleParameter("PEXPECTED_DT", OracleType.VarChar, 200)
        params(5).Value = Me.txt_exp_dt.Text
        params(5).Direction = ParameterDirection.Input

        params(6) = New OracleParameter("PTENURE", OracleType.Number, 5)
        params(6).Value = CInt(Me.cmb_tenure.Text)
        params(6).Direction = ParameterDirection.Input

        params(7) = New OracleParameter("PQUALIF", OracleType.VarChar, 200)
        params(7).Value = Me.txt_qualif.Text
        params(7).Direction = ParameterDirection.Input

        params(8) = New OracleParameter("PEXPIRIENCE", OracleType.Number, 5)
        params(8).Value = CInt(Me.txt_exp.Text)
        params(8).Direction = ParameterDirection.Input

        params(9) = New OracleParameter("PLOC", OracleType.VarChar, 200)
        params(9).Value = Me.txt_loc.Text
        params(9).Direction = ParameterDirection.Input

        params(10) = New OracleParameter("PTOT_STRENGTH", OracleType.Number, 6)
        params(10).Value = CInt(Me.txt_stren.Text)
        params(10).Direction = ParameterDirection.Input

        params(11) = New OracleParameter("PPAY_SCALE", OracleType.Number, 8)
        params(11).Value = CInt(Me.txt_pay.Text)
        params(11).Direction = ParameterDirection.Input

        params(12) = New OracleParameter("PNO_VACANCY", OracleType.Number, 6)
        params(12).Value = CInt(Me.txt_no_vacancy.Text)
        params(12).Direction = ParameterDirection.Input

        params(13) = New OracleParameter("PGENDER", OracleType.Number, 4)
        params(13).Value = gen
        params(13).Direction = ParameterDirection.Input

        params(14) = New OracleParameter("PREASON_RQ", OracleType.VarChar, 200)
        params(14).Value = Me.cmb_reason.SelectedItem.ToString() + "*" + Me.cmb_reason.Text
        params(14).Direction = ParameterDirection.Input

        params(15) = New OracleParameter("PADDI_INFO", OracleType.VarChar, 200)
        params(15).Value = Me.txt_info.Text
        params(15).Direction = ParameterDirection.Input

        params(16) = New OracleParameter("PFIRM_ID", OracleType.Number, 4)
        params(16).Value = ff
        params(16).Direction = ParameterDirection.Input

        params(17) = New OracleParameter("PBRANCH_ID", OracleType.Number, 4)
        params(17).Value = branch_id
        params(17).Direction = ParameterDirection.Input

        params(18) = New OracleParameter("PUSER_ID", OracleType.Number, 10)
        params(18).Value = CInt(usr(0))
        params(18).Direction = ParameterDirection.Input

        params(19) = New OracleParameter("MSG", OracleType.VarChar, 200)
        params(19).Direction = ParameterDirection.Output

        params(20) = New OracleParameter("STATUS", OracleType.Number, 8)
        params(20).Direction = ParameterDirection.Output

        params(21) = New OracleParameter("AE", OracleType.Number, 8)
        If Me.ADD.Checked = True Then
            ae = 1
            params(21).Value = ae
        Else
            ae = 2
            params(21).Value = ae
        End If
        params(21).Direction = ParameterDirection.Input


        params(22) = New OracleParameter("ID", OracleType.Number, 8)
        params(22).Direction = ParameterDirection.Input
        If Me.EDIT.Checked = True Then
            params(22).Value = CInt(Me.txt_id.Text)
        Else
            params(22).Value = 0
        End If


        oh.ExecuteNonQuery("hrm_requisition_proce", params)

        status = params(20).Value
        msg = params(19).Value

        If status <> 0 Then
            Dim cl_01 As New System.Text.StringBuilder
            cl_01.Append("         alert('" & msg & "'+'\n'+'Key ID='+'" & status & "');")
            cl_01.Append(" window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_01.ToString, True)
        Else
            Dim cl_01 As New System.Text.StringBuilder
            cl_01.Append("         alert('" & msg & "');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_01.ToString, True)
        End If
    End Sub
    Protected Sub male_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles male.CheckedChanged
        If Me.male.Checked = True Then
            gen = 0
            Me.female.Checked = False
        Else
            Me.female.Checked = True
            gen = 1
        End If
    End Sub

    Protected Sub ADD_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ADD.CheckedChanged
        If Me.ADD.Checked = True Then
            Me.EDIT.Checked = False
            Me.tr_edit.Visible = False
            Me.btn_confirm.Visible = True
            Me.btn_confirm.Text = "Confirm"
            Me.tr_edit.Visible = False
            ae = 1
            Me.txt_div.Text = ""
            Me.txt_exp.Text = ""
            Me.txt_id.Text = ""
            Me.txt_info.Text = ""
            Me.Txt_job.Text = ""
            Me.txt_loc.Text = ""
            Me.txt_no_req.Text = ""
            Me.txt_no_vacancy.Text = ""
            Me.txt_pay.Text = ""
            Me.txt_qualif.Text = ""
            Me.txt_stren.Text = ""
        End If
    End Sub
    Protected Sub EDIT_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EDIT.CheckedChanged
        If Me.EDIT.Checked = True Then
            Me.ADD.Checked = False
            Me.tr_edit.Visible = False
            Me.btn_confirm.Text = "Update"
            Me.tr_edit.Visible = True
            ae = 2
            Me.txt_div.Text = ""
            Me.txt_exp.Text = ""
            Me.txt_id.Text = ""
            Me.txt_info.Text = ""
            Me.Txt_job.Text = ""
            Me.txt_loc.Text = ""
            Me.txt_no_req.Text = ""
            Me.txt_no_vacancy.Text = ""
            Me.txt_pay.Text = ""
            Me.txt_qualif.Text = ""
            Me.txt_stren.Text = ""
        End If
    End Sub

    Protected Sub btn_search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Dim id As Integer
        Dim ddt As DataTable
        If Me.txt_id.Text = "" Then

            Dim cl_01 As New System.Text.StringBuilder
            cl_01.Append("         alert('ENTER ID');")
            cl_01.Append(" window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_01.ToString, True)
        Else
            id = Me.txt_id.Text
            ddt = oh.ExecuteDataSet("select t.date_req,t.req_by,t.job_title,t.no_of_req,t.division,t.expected_dt,t.tenure,t.qualif,t.expirience,t.loc,t.tot_strength,t.pay_scale,t.no_vacancy,t.gender,t.reason_rq,t.addi_info from MAN_REQ_DTLS t where t.req_id=" & id & "and t.firm_id=" & ff).Tables(0)
            If ddt.Rows.Count > 0 Then
                Me.lbl_msg.Visible = False
                Me.txt_date.Text = ddt.Rows(0)(0)
                Me.Txt_job.Text = ddt.Rows(0)(2)
                Me.txt_no_req.Text = ddt.Rows(0)(3)
                Me.txt_div.Text = ddt.Rows(0)(4)
                Me.txt_exp_dt.Text = ddt.Rows(0)(5)
                Me.txt_qualif.Text = ddt.Rows(0)(7)
                Me.txt_exp.Text = ddt.Rows(0)(8)
                Me.txt_loc.Text = ddt.Rows(0)(9)
                Me.txt_stren.Text = ddt.Rows(0)(10)
                Me.txt_pay.Text = ddt.Rows(0)(11)
                Me.txt_no_vacancy.Text = ddt.Rows(0)(12)

            Else
                Me.lbl_msg.Visible = True
                Me.txt_date.Text = ""
                Me.Txt_job.Text = ""
                Me.txt_no_req.Text = ""
                Me.txt_div.Text = ""
                Me.txt_exp_dt.Text = ""
                Me.txt_qualif.Text = ""
                Me.txt_exp.Text = ""
                Me.txt_loc.Text = ""
                Me.txt_stren.Text = ""
                Me.txt_pay.Text = ""
                Me.txt_no_vacancy.Text = ""
            End If
        End If

    End Sub

    
  
    Protected Sub btn_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Server.Transfer("../home.aspx")

    End Sub

    Protected Sub female_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles female.CheckedChanged
        If Me.male.Checked = True Then
            gen = 0
            Me.female.Checked = False
        Else
            Me.female.Checked = True
            gen = 1
        End If
    End Sub
End Class
