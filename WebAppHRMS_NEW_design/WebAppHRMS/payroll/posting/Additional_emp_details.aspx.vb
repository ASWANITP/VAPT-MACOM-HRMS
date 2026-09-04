Imports System.Data
Imports System.Data.OracleClient
Partial Class Additional_emp_details_a74e8e202020
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim usr() As String
            Dim sql As String
            usr = Me.Session("user_id").ToString.Split("!")
            Dim UserId As Integer = usr(0)
            Dim ff As Integer = Session("firm_id")
            Session("firm_id") = 8
            Dim dt As DataTable

            'Form id 1829
            dt = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=1829 and s.emp_id=" & UserId & "").Tables(0)
            If (dt.Rows(0)(0) = 0) Then
                Server.Transfer("../../show_err.aspx")
                Return
            End If
            Session("insert") = Server.UrlEncode(System.DateTime.Now.ToString())

            level_fill()
        End If

    End Sub
    Sub tech_fill()
        Me.DDLTL.ForeColor = Drawing.Color.Black
        Dim dtt As DataTable = oh.ExecuteDataSet("select 0, '---TECHLEAD---' as techlead from dual union select em.emp_code, em.emp_name from employee_master em where post_id = 1045 and status_id = 1 order by techlead").Tables(0)
        Me.DDLTL.DataSource = dtt
        Me.DDLTL.DataTextField = dtt.Columns(1).ColumnName
        Me.DDLTL.DataValueField = dtt.Columns(0).ColumnName
        Me.DDLTL.DataBind()
    End Sub
    Sub level_fill()
        Me.DDLL.ForeColor = Drawing.Color.Black
        Dim dtl As DataTable = oh.ExecuteDataSet("select 0, '---LEVEL---' as lev from dual union select t.level_id, t.levelr as lev from level_master t order by lev").Tables(0)
        Me.DDLL.DataSource = dtl
        Me.DDLL.DataTextField = dtl.Columns(1).ColumnName
        Me.DDLL.DataValueField = dtl.Columns(0).ColumnName
        Me.DDLL.DataBind()
    End Sub

    Sub cleardata()
        lbl_code.Text = ""
        lbl_name.Text = ""
        lblPost.Text = ""
        lblBranch.Text = ""

        txtAadhar.Text = ""
        txtPan.Text = ""
        txtUAN.Text = ""
        txtESI.Text = ""
        txtLocality.Text = ""
        txtOfficemail.Text = ""
        txtacno.Text = ""
        txtbank.Text = ""
        txtbranch.Text = ""
        txtifc.Text = ""

        txtinsno.Text = ""
        txtinscompany.Text = ""
        txtstartdate.Text = ""
        txtenddate.Text = ""
        'lnkins.Visible = False
        lnkbank.Visible = False
        hdnacno.Value = ""
        'hdninsno.Value = ""

    End Sub



    Public Shared Function VerifyEmailID(ByVal email As String) As Boolean
        Dim expresion As String
        expresion = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        If Regex.IsMatch(email, expresion) Then
            If Regex.Replace(email, expresion, String.Empty).Length = 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function



    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Try

            If hdnacno.Value.Length = 0 Then
                hdnacno.Value = txtacno.Text
            End If
            If hdninsno.Value.Length = 0 Then
                hdninsno.Value = txtinsno.Text
            End If


            Dim firm As Integer = Session("firm_id")
            Dim usr() As String
            usr = Me.Session("user_id").ToString.Split("!")
            Dim UserId As Integer = usr(0)

            If lbl_name.Text.Length = 0 Then
                Dim cl_script11 As New System.Text.StringBuilder
                cl_script11.Append("        alert('Invalid employee code');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
                cleardata()
                txtEcode.Focus()
                Return
            End If

            If txtOfficemail.Text.Length > 0 Then
                Dim emailidValStatus As Boolean = VerifyEmailID(txtOfficemail.Text)
                If emailidValStatus = False Then
                    Dim cl_script11 As New System.Text.StringBuilder
                    cl_script11.Append("        alert('Invalid mail id');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
                    txtOfficemail.Text = ""
                    txtOfficemail.Focus()
                    Return
                End If
            End If

            If txtstartdate.Text.Length > 0 Then
                If Not IsDate(txtstartdate.Text) Then
                    Dim cl_script11 As New System.Text.StringBuilder
                    cl_script11.Append("        alert('Invalid Date');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
                    txtstartdate.Focus()
                    Return
                End If
            End If

            If txtenddate.Text.Length > 0 Then
                If Not IsDate(txtenddate.Text) Then
                    Dim cl_script11 As New System.Text.StringBuilder
                    cl_script11.Append("        alert('Invalid Date');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
                    txtenddate.Focus()
                    Return
                End If
            End If

            Dim dt As DataTable
            Dim insert_Flag As Boolean
            dt = oh.ExecuteDataSet("select count(t.emp_code) from hrm_emp_additional_dtl t where t.emp_code=" & txtEcode.Text & " ").Tables(0)
            If dt.Rows(0)(0) = 0 Then
                insert_Flag = 1
            Else
                insert_Flag = 0
            End If

            'Code to save details.
            If ViewState("insert").ToString() = Session("insert").ToString() Then
                Dim parameter(22) As OracleParameter
                ''CODE
                parameter(0) = New OracleParameter("ecode", OracleType.Number, 6)
                parameter(0).Direction = ParameterDirection.Input
                parameter(0).Value = Me.lbl_code.Text

                parameter(1) = New OracleParameter("firmid", OracleType.Number, 2)
                parameter(1).Direction = ParameterDirection.Input
                parameter(1).Value = firm

                parameter(2) = New OracleParameter("aadhar", OracleType.VarChar, 12)
                parameter(2).Direction = ParameterDirection.Input
                parameter(2).Value = txtAadhar.Text

                parameter(3) = New OracleParameter("pan", OracleType.VarChar, 10)
                parameter(3).Direction = ParameterDirection.Input
                parameter(3).Value = txtPan.Text

                parameter(4) = New OracleParameter("uan", OracleType.VarChar, 12)
                parameter(4).Direction = ParameterDirection.Input
                parameter(4).Value = txtUAN.Text

                parameter(5) = New OracleParameter("esi", OracleType.VarChar, 10)
                parameter(5).Direction = ParameterDirection.Input
                parameter(5).Value = txtESI.Text

                parameter(6) = New OracleParameter("Locality", OracleType.VarChar, 100)
                parameter(6).Direction = ParameterDirection.Input
                parameter(6).Value = txtLocality.Text

                parameter(7) = New OracleParameter("Officemail", OracleType.VarChar, 50)
                parameter(7).Direction = ParameterDirection.Input
                parameter(7).Value = txtOfficemail.Text

                parameter(8) = New OracleParameter("acnum", OracleType.VarChar, 25)
                parameter(8).Direction = ParameterDirection.Input
                parameter(8).Value = hdnacno.Value

                parameter(9) = New OracleParameter("bank", OracleType.VarChar, 50)
                parameter(9).Direction = ParameterDirection.Input
                If hdnacno.Value.Length > 0 Then
                    parameter(9).Value = txtbank.Text
                Else
                    parameter(9).Value = ""
                End If

                parameter(10) = New OracleParameter("branchname", OracleType.VarChar, 50)
                parameter(10).Direction = ParameterDirection.Input
                If hdnacno.Value.Length > 0 Then
                    parameter(10).Value = txtbranch.Text
                Else
                    parameter(10).Value = ""
                End If


                parameter(11) = New OracleParameter("ifscno", OracleType.VarChar, 15)
                parameter(11).Direction = ParameterDirection.Input
                If hdnacno.Value.Length > 0 Then
                    parameter(11).Value = txtifc.Text
                Else
                    parameter(11).Value = ""
                End If


                parameter(12) = New OracleParameter("insno", OracleType.VarChar, 25)
                parameter(12).Direction = ParameterDirection.Input
                parameter(12).Value = hdninsno.Value

                parameter(13) = New OracleParameter("inscompany", OracleType.VarChar, 50)
                parameter(13).Direction = ParameterDirection.Input
                If hdninsno.Value.Length > 0 Then
                    parameter(13).Value = txtinscompany.Text
                Else
                    parameter(13).Value = ""
                End If


                parameter(14) = New OracleParameter("startdate", OracleType.VarChar, 15)
                parameter(14).Direction = ParameterDirection.Input
                If hdninsno.Value.Length > 0 Then
                    parameter(14).Value = txtstartdate.Text
                Else
                    parameter(14).Value = ""
                End If



                parameter(15) = New OracleParameter("enddate", OracleType.VarChar, 15)
                parameter(15).Direction = ParameterDirection.Input
                If hdninsno.Value.Length > 0 Then
                    parameter(15).Value = txtenddate.Text
                Else
                    parameter(15).Value = ""
                End If


                parameter(16) = New OracleParameter("op_flag", OracleType.Number, 1)
                parameter(16).Direction = ParameterDirection.Input
                parameter(16).Value = insert_Flag

                parameter(17) = New OracleParameter("userid", OracleType.Number, 6)
                parameter(17).Direction = ParameterDirection.Input
                parameter(17).Value = UserId

                parameter(18) = New OracleParameter("msg", OracleType.VarChar, 1000)
                parameter(18).Direction = ParameterDirection.Output


                parameter(19) = New OracleParameter("position", OracleType.VarChar, 45)
                parameter(19).Direction = ParameterDirection.Input
                parameter(19).Value = Txtposition.Text


                parameter(20) = New OracleParameter("tlecode", OracleType.Number, 6)
                parameter(20).Direction = ParameterDirection.Input
                parameter(20).Value = DDLTL.SelectedValue

                parameter(21) = New OracleParameter("transfr", OracleType.VarChar, 50)
                parameter(21).Direction = ParameterDirection.Input
                parameter(21).Value = Txttransfr.Text

                parameter(22) = New OracleParameter("emplevel", OracleType.VarChar, 3)
                parameter(22).Direction = ParameterDirection.Input
                parameter(22).Value = DDLL.SelectedValue


                oh.ExecuteNonQuery("HRM_EMP_ADDITIONAL_DTL_PROC", parameter)

                Dim message As String
                message = parameter(18).Value

                Dim cl_script1 As New StringBuilder
                cl_script1.Append("   alert('" & message & "');")
                'cl_script1.Append(" window.open(Additional_emp_details.aspx,_self);")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)
            End If
            cleardata()
            txtEcode.Text = ""
            Txtposition.Text = ""
            DDLTL.SelectedValue = 0
            Txttransfr.Text = ""
            DDLL.ClearSelection()
            txtEcode.Focus()
            Session("insert") = Server.UrlEncode(System.DateTime.Now.ToString())
        Catch ex As Exception
            Dim cl_script11 As New System.Text.StringBuilder
            cl_script11.Append("        alert('Error. please check the values entered.');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
        End Try
    End Sub


    Protected Sub txtEcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            cleardata()
            Dim itemno As Integer
            itemno = Me.txtEcode.Text
            If itemno = 0 Then
                'Response.Redirect("Final_Settlement.aspx")
                Return
            End If
            Dim frm As Integer = Session("firm_id")
            'Dim dt1 As DataTable = oh.ExecuteDataSet("select em.emp_code, em.emp_name, br.branch_name, po.post_name, em.branch_id, em.post_id from employee_master em, employ_firm f,branch_master br, post_mst po where em.emp_code=f.emp_code and em.branch_id=br.branch_id and em.post_id=po.post_id and  em.emp_code=" & itemno & " and em.status_id in (1,10) and f.firm_id=" & frm & "").Tables(0)
            Dim dt1 As DataTable = oh.ExecuteDataSet("select em.emp_code, em.emp_name, br.branch_name, po.post_name, em.branch_id, em.post_id from employee_master em, employ_firm f,branch_master br, post_mst po where em.emp_code=f.emp_code and em.branch_id=br.branch_id and em.post_id=po.post_id and  em.emp_code=" & itemno & " and em.status_id in (1,10) and f.firm_id=8").Tables(0)
            If dt1.Rows.Count > 0 Then

                Me.lbl_code.Text = dt1.Rows(0)(0)
                Me.lbl_name.Text = dt1.Rows(0)(1)
                If IsDBNull(dt1.Rows(0)(3)) Then
                    Me.lblPost.Text = " "
                Else
                    Me.lblPost.Text = dt1.Rows(0)(3)
                    Me.lblpostid.Text = dt1.Rows(0)("post_id")
                End If

                If IsDBNull(dt1.Rows(0)(2)) Then
                    Me.lblBranch.Text = " "
                Else
                    Me.lblBranch.Text = dt1.Rows(0)(2)
                    Me.lblbranchid.Text = dt1.Rows(0)("branch_id")
                End If
                loaddata()
                tech_fill()

            Else
                cleardata()
            End If


        Catch ex As Exception
            Dim cl_script11 As New System.Text.StringBuilder
            cl_script11.Append("alert('Error. please check the code entered.');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
        End Try
    End Sub

    Sub loaddata()
        Try
            Dim dt As New DataTable()
            dt = oh.ExecuteDataSet("select count(t.emp_code) from hrm_emp_additional_dtl t where t.emp_code=" & txtEcode.Text & " ").Tables(0)
            If dt.Rows(0)(0) = 1 Then
                Dim dt0 As DataTable = oh.ExecuteDataSet("select aadhar_no,   pan_no,   uan_no,   esi_no,   LANDMARK,   office_mailid from HRM_EMP_ADDITIONAL_DTL t where t.emp_code=" & txtEcode.Text & " ").Tables(0)
                If dt0.Rows.Count > 0 Then
                    txtAadhar.Text = dt0.Rows(0)(0).ToString()
                    txtPan.Text = dt0.Rows(0)(1).ToString()
                    txtUAN.Text = dt0.Rows(0)(2).ToString()
                    txtESI.Text = dt0.Rows(0)(3).ToString()
                    txtLocality.Text = dt0.Rows(0)(4).ToString()
                    txtOfficemail.Text = dt0.Rows(0)(5).ToString()
                End If

                Dim dt1 As DataTable = oh.ExecuteDataSet("select acno, bankname, branch, ifsc from HRM_EMP_ADDITIONAL_BANK_DTL t where t.emp_code=" & txtEcode.Text & " and t.status=1 ").Tables(0)
                If dt1.Rows.Count > 0 Then
                    If dt1.Rows(0)(0).ToString().Length > 0 Then
                        hdnacno.Value = dt1.Rows(0)(0).ToString()
                        txtacno.ReadOnly = True
                        lnkbank.Visible = True
                    End If
                    txtacno.Text = dt1.Rows(0)(0).ToString()
                    txtbank.Text = dt1.Rows(0)(1).ToString()
                    txtbranch.Text = dt1.Rows(0)(2).ToString()
                    txtifc.Text = dt1.Rows(0)(3).ToString()
                Else
                    lnkbank.Visible = False
                    txtacno.ReadOnly = False
                End If

                Dim dt2 As DataTable = oh.ExecuteDataSet("select  insurance_no,   ins_company,   ins_start_date,   ins_end_date from HRM_EMP_ADDITIONAL_INS_DTL t where t.emp_code=" & txtEcode.Text & " and t.status=1 ").Tables(0)
                If dt2.Rows.Count > 0 Then
                    If dt2.Rows(0)(0).ToString().Length > 0 Then
                        hdninsno.Value = dt2.Rows(0)(0).ToString()
                        txtinsno.ReadOnly = True
                        lnkins.Visible = True
                    End If
                    txtinsno.Text = dt2.Rows(0)(0).ToString()
                    txtinscompany.Text = dt2.Rows(0)(1).ToString()
                    txtstartdate.Text = dt2.Rows(0)(2).ToString()
                    txtenddate.Text = dt2.Rows(0)(3).ToString()
                Else
                    lnkins.Visible = False
                    txtinsno.ReadOnly = False
                End If
            End If

        Catch ex As Exception
            Dim cl_script11 As New System.Text.StringBuilder
            cl_script11.Append("        alert('Error while loading data.');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
        End Try
    End Sub


    Protected Sub lnkbank_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If lbl_name.Text.Length > 0 Then
            If txtacno.Text.Length > 0 Then
                oh.ExecuteNonQuery("update HRM_EMP_ADDITIONAL_BANK_DTL t set t.status = 0 where t.emp_code=" & txtEcode.Text & " and  t.acno = " & txtacno.Text & " ")
                txtacno.Text = ""
                txtbank.Text = ""
                txtbranch.Text = ""
                txtifc.Text = ""
                hdnacno.Value = ""
                txtacno.ReadOnly = False
                Dim cl_script11 As New System.Text.StringBuilder
                cl_script11.Append("        alert('Deleted.');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
            End If
        End If
    End Sub

    Protected Sub lnkins_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If lbl_name.Text.Length > 0 Then
            If txtinsno.Text.Length > 0 Then
                oh.ExecuteNonQuery("update HRM_EMP_ADDITIONAL_INS_DTL t set t.status = 0 where t.emp_code=" & txtEcode.Text & " and  t.insurance_no = '" & txtinsno.Text & "' ")
                txtinsno.Text = ""
                txtinscompany.Text = ""
                txtstartdate.Text = ""
                txtenddate.Text = ""
                hdninsno.Value = ""
                txtinsno.ReadOnly = False
                Dim cl_script11 As New System.Text.StringBuilder
                cl_script11.Append("        alert('Deleted.');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
            End If
        End If
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            Dim firm As Integer = Session("firm_id")
            Dim ds As New DataSet
            ds = oh.ExecuteDataSet("select em.emp_code,        em.emp_name,        pd.father_name,        pd.perm_add1 as house_name,        po.post_office,        dst.district_name,        st.state_name,        po.pin_code,        to_char(pd.birth_date, 'MM/DD/YYYY') DOB,        to_char(sysdate, 'MM/DD/YYYY') today,               to_char(em.join_dt, 'MM/DD/YYYY') DOJ,               trunc(TO_NUMBER(SYSDATE - TO_DATE(pd.birth_date)) / 365.25) age,         decode(pd.sex,1,'M',0,'F')as Gender,         (select bg.blood_type from bloodgroup_master bg where bg.blood_id=pd.blood_id) BLOOD_GROUP ,      d.designation ,      pst.post_name ,      dep.dep_name ,               case             when                       (select count(qm.qualification)   from employ_qualification_dtl ql,        qualification_master     qm  where qm.qualification_id = ql.qualification    and ql.emp_code = em.emp_code    and ql.year_pass = (select max(r.year_pass)                          from employ_qualification_dtl r                         where r.emp_code = em.emp_code))>0           then                    (select LISTAGG(qm.qualification, ' & ')  WITHIN GROUP (ORDER BY qm.qualification_id)   from employ_qualification_dtl ql,        qualification_master     qm  where qm.qualification_id = ql.qualification    and ql.emp_code =em.emp_code    and ql.year_pass = (select max(r.year_pass)                          from employ_qualification_dtl r                         where r.emp_code =em.emp_code))                                     else                        (select qm.qualification   from employ_qualification_dtl ql,        qualification_master     qm  where qm.qualification_id = ql.qualification    and ql.emp_code = em.emp_code    and ql.year_pass = (select max(r.year_pass)                          from employ_qualification_dtl r                         where r.emp_code = em.emp_code))              end as qualification,        (select emm.emp_name from employee_master emm where emm.emp_code = dep.dep_head) department_head,        (select emm.emp_name from employee_master emm where emm.emp_code=tlr.tl_empcode)Tech_Lead,        decode(em.status_id,1,'Live',10,'Maternity',6,'Long Leave',3,'Resigned',13,'Resigned',4,'Suspended',5,'Terminated') as STATUS    ,        pd.emp_email ,        (select hdtl.office_mailid from HRM_EMP_ADDITIONAL_DTL hdtl where hdtl.emp_code=em.emp_code  and rownum = 1)as office_mailID,           pd.cont_phone ,        (select tlr.emp_level from tl_trsfr_level tlr where tlr.emp_code=em.emp_code)as levelr,           (select tlr.emp_postion_cat from tl_trsfr_level tlr where tlr.emp_code=em.emp_code) as position_category,          (select tlr.transr_from_frm from tl_trsfr_level tlr where tlr.emp_code=em.emp_code) as firm_from_emp_tfred,  NVL(to_char((select to_date(e.enter_dt) from m_resign_appl e where e.status in (0, 1, 2, 5) and rownum = 1 and to_date(e.enter_dt)=(select max(to_date(m.enter_dt))from m_resign_appl m where m.emp_code=e.emp_code and m.status<>3) and e.emp_code=em.emp_code),'MM/DD/YYYY'),'NOT SUBMITTED')date_of_res_sub,  nvl(to_char(md.discont_dt,'MM/DD/YYYY'),'NOT RESIGNED')exit_dATE,   (select hdtl.landmark from HRM_EMP_ADDITIONAL_DTL hdtl where hdtl.emp_code=em.emp_code and rownum = 1)as land_mark,   nvl((select hdtl.aadhar_no from HRM_EMP_ADDITIONAL_DTL hdtl where hdtl.emp_code=em.emp_code and rownum = 1),  nvl((select a.idproof_number adhar_number   from appln_interview_dtl t,        employ_firm         f,        employee_master     eml,        appln_pers_dtl a  where f.emp_code = eml.emp_code and eml.emp_code=em.emp_code    and f.emp_code = t.emp_code and a.appln_no=t.appln_no and a.id_proof=8  and rownum = 1),'NOT UPDATED'))as adhar_no,     nvl(nvl((select hdtl.pan_no from HRM_EMP_ADDITIONAL_DTL hdtl where hdtl.emp_code=em.emp_code and rownum = 1),(select t.pan_no from etds_employee t where t.emp_id=em.emp_code )),'NOT UPDATED')as pan_no,      nvl((select hdtl.uan_no from HRM_EMP_ADDITIONAL_DTL hdtl where hdtl.emp_code=em.emp_code and rownum = 1),'NOT UPDATED')as uan_no,       nvl((select hdtl.esi_no from HRM_EMP_ADDITIONAL_DTL hdtl where hdtl.emp_code=em.emp_code and rownum = 1),'NOT UPDATED')as esi_no,        nvl((select hb.acno from HRM_EMP_ADDITIONAL_BANK_DTL hb where hb.emp_code=em.emp_code and rownum = 1),'NOT UPDATED')as account_number,         nvl((select hb.bankname from HRM_EMP_ADDITIONAL_BANK_DTL hb where hb.emp_code=em.emp_code and rownum = 1),'NOT UPDATED')as bank_name,          nvl((select hb.branch from HRM_EMP_ADDITIONAL_BANK_DTL hb where hb.emp_code=em.emp_code and rownum = 1),'NOT UPDATED')as bank_branch,           nvl((select hb.ifsc from HRM_EMP_ADDITIONAL_BANK_DTL hb where hb.emp_code=em.emp_code and rownum = 1),'NOT UPDATED')as ifsc_code,            nvl((select hs.insurance_no from HRM_EMP_ADDITIONAL_INS_DTL hs where hs.emp_code=em.emp_code and rownum = 1),'NOT UPDATED')as ins_number,             nvl((select hs.ins_company from HRM_EMP_ADDITIONAL_INS_DTL hs where hs.emp_code=em.emp_code and rownum = 1),'NOT UPDATED')as ins_company,              nvl((select hs.ins_start_date from HRM_EMP_ADDITIONAL_INS_DTL hs where hs.emp_code=em.emp_code and rownum = 1),'NOT UPDATED')as ins_start_date,   nvl((select max(hs.ins_end_date) from HRM_EMP_ADDITIONAL_INS_DTL hs where hs.emp_code=em.emp_code and rownum = 1),'NOT UPDATED')as ins_end_date           from employee_master     em,        employee_master_dtl     md,        employ_firm         f,        employ_personal_dtl pd,        designation_master  d,        post_master         po,        district_master     dst,        state_master        st,        department_mst      dep,        post_mst            pst,        tl_trsfr_level tlr  where em.emp_code = f.emp_code    and em.emp_code = pd.emp_code    and em.emp_code = md.emp_code    and em.designation_id = d.designation_id    and em.department_id = dep.dep_id    and em.emp_code=tlr.emp_code    and pd.perm_pin = po.sr_number    and po.district_id = dst.district_id    and dst.state_id = st.state_id    and em.post_id = pst.post_id    and f.firm_id = 8    and em.emp_code>=100001 order by em.emp_code")

            Dim dgGrid As New GridView
            dgGrid.AutoGenerateColumns = False
            dgGrid.EnableViewState = False
            dgGrid.Font.Name = "Times New Roman"
            dgGrid.HeaderStyle.BackColor = Drawing.Color.LightGray
            dgGrid.HeaderStyle.Font.Size = New FontUnit(FontSize.Smaller)
            dgGrid.HeaderStyle.HorizontalAlign = HorizontalAlign.Left
            dgGrid.RowStyle.VerticalAlign = VerticalAlign.Top
            dgGrid.RowStyle.Font.Size = New FontUnit(FontSize.Smaller)

            For i As Integer = 0 To ds.Tables(0).Columns.Count - 1
                Dim dbField As New BoundField
                dbField.HeaderText = ds.Tables(0).Columns(i).ColumnName
                dbField.DataField = ds.Tables(0).Columns(i).ColumnName
                dgGrid.Columns.Add(dbField)
            Next
            dgGrid.DataSource = ds
            dgGrid.DataBind()
            Dim fname As String = "Employee_AdditionalDtls.xls"
            WebAppHRMS.GridViewExportUtil.Export(fname, dgGrid)
        Catch ex As Exception
            Dim cl_script11 As New System.Text.StringBuilder
            cl_script11.Append("        alert('Please try later');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
        End Try
    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Response.Redirect("Additional_emp_details.aspx")
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        ViewState("insert") = Session("insert")
    End Sub

End Class
