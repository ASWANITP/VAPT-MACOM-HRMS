Imports System.Data
Imports System.Data.OracleClient
Partial Class Employee_Punching_Movementslip_mfdtn_494216743145
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dtn, dtn1, dt2, dt3, st, st1, st2, st3 As New DataTable
    Dim sf(), sf1(), sf2(), app, rec, frm, dm As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_purp.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        If Not IsPostBack Then

            frm = Session("firm_id")
            If frm = 27 Then
                Response.Redirect("Movement_Mafarm.aspx")
                Exit Sub
            End If
            sf = Session("user_id").ToString.Split("!")
            Me.Txt_fdt.Text = Format(Date.Now, "dd/MMM/yyyy")
            Me.Txt_FromTime.Text = "00:00 AM"
            Me.Txt_ToTime.Text = "00:00 AM"
            Me.Txt_tot_time.Enabled = False

            Dim newd As DataTable = oh.ExecuteDataSet("select t.stat from PHOTO_STAT t WHERE T.MODULE_ID=4").Tables(0)
            If newd.Rows(0)(0) = 1 Then
                'Dim st As DataTable = New DataTable
                'rec = "select  substr(substr(t.recommender, instr(t.recommender, '-') + 1, length(t.recommender)), 0, instr(substr(t.recommender, instr(t.recommender, '-') + 1, length(t.recommender)), '-') - 1),substr(t.recommender, 0, instr(t.recommender, '-') - 1) from movement_master t where t.emp_code = " & sf(0) & ""
                'app = "select  substr(substr(t.approver, instr(t.approver, '-') + 1, length(t.approver)), 0, instr(substr(t.approver, instr(t.approver, '-') + 1, length(t.approver)), '-') - 1),substr(t.approver, 0, instr(t.approver, '-') - 1) from movement_master t where t.emp_code = " & sf(0) & ""
                '------------------------recomm 107 / app 105 
                Try

                    Dim paras(3) As OracleParameter
                    paras(0) = New OracleParameter("p_flag", OracleType.Number)
                    paras(0).Direction = ParameterDirection.Input
                    paras(0).Value = 53
                    paras(1) = New OracleParameter("p_data", OracleType.VarChar, 1000)
                    paras(1).Direction = ParameterDirection.Input
                    paras(1).Value = sf(0).ToString
                    paras(2) = New OracleParameter("p_msg", OracleType.VarChar, 100)
                    paras(2).Direction = ParameterDirection.Output
                    paras(2).Value = dm
                    paras(3) = New OracleParameter("qry_result", OracleType.Cursor)
                    paras(3).Direction = ParameterDirection.Output

                    st = oh.ExecuteDataSet("proc_vo_macom", paras).Tables(0)
                    'Me.ddltl.DataSource = st
                    'Me.ddltl.DataTextField = st.Columns(1).ColumnName
                    'Me.ddltl.DataValueField = st.Columns(0).ColumnName
                    'Me.ddltl.DataBind()



                    Dim pare(3) As OracleParameter
                    pare(0) = New OracleParameter("p_flag", OracleType.Number)
                    pare(0).Direction = ParameterDirection.Input
                    pare(0).Value = 107
                    pare(1) = New OracleParameter("p_data", OracleType.VarChar, 1000)
                    pare(1).Direction = ParameterDirection.Input
                    pare(1).Value = sf(0).ToString
                    pare(2) = New OracleParameter("p_msg", OracleType.VarChar, 100)
                    pare(2).Direction = ParameterDirection.Output
                    pare(2).Value = dm
                    pare(3) = New OracleParameter("qry_result", OracleType.Cursor)
                    pare(3).Direction = ParameterDirection.Output

                    st1 = oh.ExecuteDataSet("proc_vo_macom", pare).Tables(0)
                    'Me.ddltl.DataSource = st1
                    'Me.ddltl.DataTextField = st1.Columns(1).ColumnName
                    'Me.ddltl.DataValueField = st1.Columns(0).ColumnName
                    'Me.ddltl.DataBind()

                    ' Create a new DataTable with unified structure
                    Dim combinedTable As New DataTable()
                    combinedTable.Columns.Add("Value", GetType(String)) ' For DataValueField
                    combinedTable.Columns.Add("Text", GetType(String))  ' For DataTextField

                    ' Add rows from st
                    For Each row As DataRow In st.Rows
                        Dim newRow As DataRow = combinedTable.NewRow()
                        newRow("Value") = row(0).ToString() ' Assuming Column A
                        newRow("Text") = row(1).ToString()  ' Assuming Column B
                        combinedTable.Rows.Add(newRow)
                    Next

                    ' Add rows from st1
                    For Each row As DataRow In st1.Rows
                        Dim newRow As DataRow = combinedTable.NewRow()
                        newRow("Value") = row("EMP_CODE").ToString()
                        newRow("Text") = row("EMP_NAME").ToString()
                        combinedTable.Rows.Add(newRow)
                    Next

                    ' Bind to dropdown
                    Me.ddltl.DataSource = combinedTable
                    Me.ddltl.DataValueField = "Value"
                    Me.ddltl.DataTextField = "Text"
                    Me.ddltl.DataBind()


                    Dim para(3) As OracleParameter
                    para(0) = New OracleParameter("p_flag", OracleType.Number)
                    para(0).Direction = ParameterDirection.Input
                    para(0).Value = 62
                    para(1) = New OracleParameter("p_data", OracleType.VarChar, 1000)
                    para(1).Direction = ParameterDirection.Input
                    para(1).Value = sf(0).ToString
                    para(2) = New OracleParameter("p_msg", OracleType.VarChar, 100)
                    para(2).Direction = ParameterDirection.Output
                    para(2).Value = dm
                    para(3) = New OracleParameter("qry_result", OracleType.Cursor)
                    para(3).Direction = ParameterDirection.Output

                    st2 = oh.ExecuteDataSet("proc_vo_macom", para).Tables(0)
                    'Me.ddlapp.DataSource = st2
                    'Me.ddlapp.DataTextField = st2.Columns(1).ColumnName
                    'Me.ddlapp.DataValueField = st2.Columns(0).ColumnName
                    'Me.ddlapp.DataBind()



                    Dim parr(3) As OracleParameter
                    parr(0) = New OracleParameter("p_flag", OracleType.Number)
                    parr(0).Direction = ParameterDirection.Input
                    parr(0).Value = 105
                    parr(1) = New OracleParameter("p_data", OracleType.VarChar, 1000)
                    parr(1).Direction = ParameterDirection.Input
                    parr(1).Value = sf(0).ToString
                    parr(2) = New OracleParameter("p_msg", OracleType.VarChar, 100)
                    parr(2).Direction = ParameterDirection.Output
                    parr(2).Value = dm
                    parr(3) = New OracleParameter("qry_result", OracleType.Cursor)
                    parr(3).Direction = ParameterDirection.Output

                    st3 = oh.ExecuteDataSet("proc_vo_macom", parr).Tables(0)
                    'Me.ddlapp.DataSource = st3
                    'Me.ddlapp.DataTextField = st3.Columns(1).ColumnName
                    'Me.ddlapp.DataValueField = st3.Columns(0).ColumnName
                    'Me.ddlapp.DataBind()

                    ' Create a new DataTable with unified structure
                    Dim combinedTablee As New DataTable()
                    combinedTablee.Columns.Add("Value", GetType(String)) ' For DataValueField
                    combinedTablee.Columns.Add("Text", GetType(String))  ' For DataTextField

                    ' Add rows from st
                    For Each row As DataRow In st2.Rows
                        Dim newRow As DataRow = combinedTablee.NewRow()
                        newRow("Value") = row(0).ToString() ' Assuming Column A
                        newRow("Text") = row(1).ToString()  ' Assuming Column B
                        combinedTablee.Rows.Add(newRow)
                    Next

                    ' Add rows from st1
                    For Each row As DataRow In st3.Rows
                        Dim newRow As DataRow = combinedTablee.NewRow()
                        newRow("Value") = row("EMP_CODE").ToString()
                        newRow("Text") = row("EMP_NAME").ToString()
                        combinedTablee.Rows.Add(newRow)
                    Next

                    ' Bind to dropdown
                    Me.ddlapp.DataSource = combinedTablee
                    Me.ddlapp.DataValueField = "Value"
                    Me.ddlapp.DataTextField = "Text"
                    Me.ddlapp.DataBind()




                    'Dim parameterq(3) As OracleParameter

                    'parameterq(0) = New OracleParameter("emp", OracleType.Cursor, 7)
                    'parameterq(0).Direction = ParameterDirection.Input
                    'parameterq(0).Value = sf(0)
                    'parameterq(1) = New OracleParameter("firm", OracleType.Cursor, 5)
                    'parameterq(1).Direction = ParameterDirection.Input
                    'parameterq(1).Value = Session("firm_id")
                    'parameterq(2) = New OracleParameter("log", OracleType.Cursor, 5)
                    'parameterq(2).Direction = ParameterDirection.Output
                    'parameterq(3) = New OracleParameter("logfr", OracleType.Cursor, 5)
                    'parameterq(3).Direction = ParameterDirection.Output
                    'oh.ExecuteNonQuery("proc_vo_macom", parameterq)
                    'Response.Write(parameterq(2).Value)
                Catch ex As Exception
                    Response.Write(ex.ToString)
                End Try

                'Dim st1 As DataTable = oh.ExecuteDataSet(st.ToString).Tables(0)

                'Me.ddltl.DataSource = st1
                'Me.ddltl.DataTextField = st1.Columns(1).ColumnName
                'Me.ddltl.DataValueField = st1.Columns(0).ColumnName
                'Me.ddltl.DataBind()
                '--------------------------

                'Dim dt1 As DataTable = oh.ExecuteDataSet(app).Tables(0)
                'Me.ddlapp.DataSource = dt1
                'Me.ddlapp.DataTextField = dt1.Columns(1).ColumnName
                'Me.ddlapp.DataValueField = dt1.Columns(0).ColumnName
                'Me.ddlapp.DataBind()


                'Dim dt3 As DataTable = oh.ExecuteDataSet(rec).Tables(0)
                'Me.ddltl.DataSource = dt3
                'Me.ddltl.DataTextField = dt3.Columns(1).ColumnName
                'Me.ddltl.DataValueField = dt3.Columns(0).ColumnName
                'Me.ddltl.DataBind()

            Else

                Dim tl As DataTable = oh.ExecuteDataSet("select count(t.emp_code) from mactech.tl_trsfr_level t where t.tl_empcode=" & sf(0) & " and t.emp_code in(select emp_code from mactech.employ_firm where firm_id=8)").Tables(0)
                Dim admin As DataTable = oh.ExecuteDataSet("select count(t.emp_code) from mactech.employee_master t where t.department_id = 544 and t.emp_code in(select emp_code from mactech.employ_firm where firm_id=8)and t.emp_code=" & sf(0) & "").Tables(0)

                If admin.Rows(0)(0) >= 1 Then
                    rec = "select distinct a, b from (select 0 a, '--- select ---' b from dual union all select nvl(ctz.dep_head, dep.dep_head) dep_head_code, case when ctz.emp_code > 0 then (select emp_name from mactech.employee_master where emp_code = ctz.dep_head) else (select distinct emm.emp_name from mactech.employee_master emm where emm.emp_code = dep.dep_head) end department_head from mactech.employee_master em, mactech.department_mst dep, mactech.employee_master da, mactech.employ_firm f left outer join macom_department_head ctz on (ctz.emp_code = f.EMP_CODE) where f.emp_Code = em.emp_code and da.emp_code = nvl(ctz.dep_head, dep.dep_head) and dep.dep_id = em.department_id and f.firm_id = 8 and em.status_id = 1 and em.emp_code = " & sf(0) & " union all select case when (select count(t.emp_code) from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1251 and t.status_id = 1) > 0 then (select distinct t.emp_code from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1251 and t.status_id = 1) end emp_code, case when (select count(t.emp_name) from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1251 and t.status_id = 1) > 0 then (select distinct t.emp_name from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1251 and t.status_id = 1) end emp_name from dual) where a <> " & sf(0) & " order by a"
                    app = "select distinct a, b from (select 0 a, '--- select ---' b from dual union all select distinct nvl(ctz.tl_empcode, 0) tlcode, case when ctz.emp_code > 0 then (select distinct emp_name from mactech.employee_master where emp_code = ctz.tl_empcode) else (select distinct emm.emp_name from mactech.employee_master emm where emm.emp_code = ctz.tl_empcode) end tl_empcode from mactech.employee_master em, mactech.department_mst dep, mactech.employ_firm f left outer join mactech.tl_trsfr_level ctz on (ctz.emp_code = f.EMP_CODE) inner join mactech.employee_master d on (d.emp_code = ctz.tl_empcode) where f.emp_Code = em.emp_code and f.firm_id = 8 and em.status_id = 1 and em.emp_code = " & sf(0) & " union all select case when (select count(t.emp_code) from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1251 and t.status_id = 1) > 0 then (select t.emp_code from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1251 and t.status_id = 1) end emp_code, case when (select count(t.emp_name) from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1251 and t.status_id = 1) > 0 then (select t.emp_name from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1251 and t.status_id = 1) end emp_name from dual union all select case when (select count(t.emp_code) from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 107 and t.status_id = 1) > 0 then (select distinct t.emp_code from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 107 and t.status_id = 1) end emp_code, case when (select count(t.emp_name) from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 107 and t.status_id = 1) > 0 then (select distinct t.emp_name from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 107 and t.status_id = 1) end emp_name from dual)order by a"
                End If
                If tl.Rows(0)(0) >= 1 Then
                    app = "select distinct a, b from (select 0 a, '--- select ---' b from dual union all select case when (select count(t.emp_code) from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1251 and t.status_id = 1) > 0 then (select t.emp_code from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1251 and t.status_id = 1) end emp_code, case when (select count(t.emp_name) from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1251 and t.status_id = 1) > 0 then (select t.emp_name from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1251 and t.status_id = 1) end emp_name from dual union all select case when (select count(t.emp_code) from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.emp_code = 100051 and t.status_id = 1) > 0 then (select t.emp_code from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.emp_code = 100051 and t.status_id = 1) end emp_code, case when (select count(t.emp_name) from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.emp_code = 100051 and t.status_id = 1) > 0 then (select t.emp_name from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.emp_code = 100051 and t.status_id = 1) end emp_name from dual union all select nvl(ctz.dep_head, dep.dep_head) dep_head_code, case when ctz.emp_code > 0 then (select emp_name from mactech.employee_master where emp_code = ctz.dep_head) else (select distinct emm.emp_name from mactech.employee_master emm where emm.emp_code = dep.dep_head) end department_head from mactech.employee_master em, mactech.department_mst dep, mactech.daily_attend da, mactech.employ_firm f left outer join macom_department_head ctz on (ctz.emp_code = f.EMP_CODE) where f.emp_Code = em.emp_code and da.emp_code = nvl(ctz.dep_head, dep.dep_head) and to_date(da.curr_date) = to_date(sysdate) and da.m_time is not null and dep.dep_id = em.department_id and f.firm_id = 8 and em.status_id = 1 and em.emp_code = " & sf(0) & ") where a <> " & sf(0) & " order by a"
                    rec = "select distinct a, b from (select 0 a, '--- select ---' b from dual union all select case when (select count(t.emp_code) from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1201 and t.status_id = 1) > 0 then (select distinct t.emp_code from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1201 and t.status_id = 1) end emp_code, case when (select count(t.emp_name) from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1201 and t.status_id = 1) > 0 then (select distinct t.emp_name from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1201 and t.status_id = 1) end emp_name from dual union all select nvl(ctz.dep_head, dep.dep_head) dep_head_code, case when ctz.emp_code > 0 then (select emp_name from mactech.employee_master where emp_code = ctz.dep_head) else (select distinct emm.emp_name from mactech.employee_master emm where emm.emp_code = dep.dep_head) end department_head from mactech.employee_master em, mactech.department_mst dep, mactech.employ_firm f left outer join macom_department_head ctz on (ctz.emp_code = f.EMP_CODE) where f.emp_Code = em.emp_code and dep.dep_id = em.department_id and f.firm_id = 8 and em.status_id = 1 and em.emp_code = " & sf(0) & ") where a <> " & sf(0) & "order by a"
                Else
                    app = "select distinct a, b from (select 0 a, '--- select ---' b from dual union all select nvl(ctz.dep_head, dep.dep_head) dep_head_code, case when ctz.emp_code > 0 then (select emp_name from mactech.employee_master where emp_code = ctz.dep_head) else (select distinct emm.emp_name from mactech.employee_master emm where emm.emp_code = dep.dep_head) end department_head from mactech.employee_master em, mactech.department_mst dep, mactech.employee_master da, mactech.employ_firm f left outer join macom_department_head ctz on (ctz.emp_code = f.EMP_CODE) where f.emp_Code = em.emp_code and da.emp_code = nvl(ctz.dep_head, dep.dep_head) and dep.dep_id = em.department_id and f.firm_id = 8 and em.status_id = 1 and em.emp_code = " & sf(0) & " union all select case when (select count(t.emp_code) from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1251 and t.status_id = 1) > 0 then (select distinct t.emp_code from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1251 and t.status_id = 1) end emp_code, case when (select count(t.emp_name) from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1251 and t.status_id = 1) > 0 then (select distinct t.emp_name from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1251 and t.status_id = 1) end emp_name from dual) where a <> " & sf(0) & " order by a"
                    rec = "select distinct a, b from (select 0 a, '--- select ---' b from dual union all select distinct nvl(ctz.tl_empcode, 0) tlcode, case when ctz.emp_code > 0 then (select distinct emp_name from mactech.employee_master where emp_code = ctz.tl_empcode) else (select distinct emm.emp_name from mactech.employee_master emm where emm.emp_code = ctz.tl_empcode) end tl_empcode from mactech.employee_master em, mactech.department_mst dep, mactech.employ_firm f left outer join mactech.tl_trsfr_level ctz on (ctz.emp_code = f.EMP_CODE) inner join mactech.employee_master d on (d.emp_code = ctz.tl_empcode) where f.emp_Code = em.emp_code and f.firm_id = 8 and em.status_id = 1 and em.emp_code =" & sf(0) & " union all select case when (select count(t.emp_code) from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1201 and t.status_id = 1) > 0 then (select distinct t.emp_code from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1201 and t.status_id = 1) end emp_code, case when (select count(t.emp_name) from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1201 and t.status_id = 1) > 0 then (select distinct t.emp_name from mactech.employee_master t, mactech.employ_firm f where f.firm_id = 8 and f.emp_code = t.emp_code and t.post_id = 1201 and t.status_id = 1) end emp_name from dual) where a <> " & sf(0) & "order by a"
                End If
                sf1 = Session("user_id").ToString.Split("!")

                Dim dt1 As DataTable = oh.ExecuteDataSet(app).Tables(0)
                Me.ddlapp.DataSource = dt1
                Me.ddlapp.DataTextField = dt1.Columns(1).ColumnName
                Me.ddlapp.DataValueField = dt1.Columns(0).ColumnName
                Me.ddlapp.DataBind()


                Dim dt3 As DataTable = oh.ExecuteDataSet(rec).Tables(0)
                Me.ddltl.DataSource = dt3
                Me.ddltl.DataTextField = dt1.Columns(1).ColumnName
                Me.ddltl.DataValueField = dt1.Columns(0).ColumnName
                Me.ddltl.DataBind()

            End If



            dt = oh.ExecuteDataSet("select e.emp_code || '-----' || e.emp_name, e.emp_code, d.dep_name, ds.designation, p.post_name, b.branch_name, e1.emp_name, tl.tl_empcode from employee_master e, department_mst d, designation_master ds, post_mst p, branch_master b, tl_trsfr_level tl, employee_master e1 where e.emp_code = " & sf(0) & " and e.department_id = d.dep_id and e.designation_id = ds.designation_id and e.post_id = p.post_id and tl.emp_code=e.emp_code and tl.tl_empcode=e1.emp_code and e.branch_id = b.branch_id").Tables(0)
            Try
                Me.Txt_emp.Value = dt.Rows(0)(0)
                Me.Txt_dep.Value = dt.Rows(0)(2)
                Me.Txt_des.Value = dt.Rows(0)(3)
                Me.Txt_post.Value = dt.Rows(0)(4)
                Me.Txt_br.Value = dt.Rows(0)(5)


                Dim dt2 As DataTable = oh.ExecuteDataSet("select 0 a,'--- select ---'b from dual union all select 1 a,'PERSONAL'b from dual union all select 2 a,'OFFICIAL'b from dual").Tables(0)
                Me.ddl_movtype.DataSource = dt2
                Me.ddl_movtype.DataTextField = dt2.Columns(1).ColumnName
                Me.ddl_movtype.DataValueField = dt2.Columns(0).ColumnName
                Me.ddl_movtype.DataBind()





                'sf1 = Session("user_id").ToString.Split("!")

                'Dim dt1 As DataTable = oh.ExecuteDataSet(app).Tables(0)
                'Me.ddlapp.DataSource = dt1
                'Me.ddlapp.DataTextField = dt1.Columns(1).ColumnName
                'Me.ddlapp.DataValueField = dt1.Columns(0).ColumnName
                'Me.ddlapp.DataBind()


                'Dim dt3 As DataTable = oh.ExecuteDataSet(rec).Tables(0)
                'Me.ddltl.DataSource = dt3
                'Me.ddltl.DataTextField = dt1.Columns(1).ColumnName
                'Me.ddltl.DataValueField = dt1.Columns(0).ColumnName
                'Me.ddltl.DataBind()

            Catch ex As Exception
            Finally
                dt.Dispose()
            End Try
        End If
        Me.Txt_FromTime.Attributes.Add("onclick", "checken()")
    End Sub


    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim time As DateTime = DateTime.Parse(Request.Form(Txt_ToTime.UniqueID))
        Dim script1 As New System.Text.StringBuilder
        sf2 = Session("user_id").ToString.Split("!")


        If (Me.ddl_movtype.SelectedItem.Value = 0) Then
            script1.Append("        alert(' Please Select Movement Type...!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        If (Me.ddltl.SelectedItem.Value = 0) Then
            script1.Append("        alert(' Please Select Recommender...!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If


        If (Me.ddlapp.SelectedItem.Value = 0) Then
            script1.Append("        alert(' Please Select Approver...!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If

        If Me.ddltl.SelectedValue = Me.ddlapp.SelectedValue Then
            script1.Append("alert('Recommender and Approver cannot be same. Please choose different individuals.');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If




        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        Dim dt2 As DataTable
        dt2 = oh.ExecuteDataSet("select sysdate from dual").Tables(0)

        If sf(0) = ddltl.SelectedValue Then
            script1.Append("alert('Request Employee and Recommender cannot be same.Please select a different Recommender..');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If


        If sf(0) = ddlapp.SelectedValue Then
            script1.Append("alert('Request Employee and Approver cannot be same.Please select a different Approver..');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If

        If (Txt_purp.Text = "") Then
            script1.Append("        alert('Please Enter Movement Reason..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf (Txtplace.Text = "") Then
            script1.Append("        alert('Please Enter Movement Place..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)


        ElseIf (Txt_FromTime.Text = "00:00 AM") Then
            script1.Append("        alert('Please Enter From Time..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf (Txt_ToTime.Text = "00:00 AM") Then
            script1.Append("        alert('Please Enter To Time..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf (ddl_movtype.Text = "") Then
            script1.Append("        alert('Please Select Movement type..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        ElseIf (Txt_tot_time.Text = "") Then
            script1.Append("        alert('Invalid From Time Or To Time..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)




        Else


            dtn = oh.ExecuteDataSet("select t.emp_name from employee_master t where t.emp_code=" & sf(0) & "").Tables(0)
            dtn1 = oh.ExecuteDataSet("select t.tl_empcode from tl_trsfr_level t where t.emp_code=" & sf(0) & "").Tables(0)

            Dim parameter(11) As OracleParameter
            parameter(0) = New OracleParameter("em_code", OracleType.Number, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = sf(0)
            parameter(1) = New OracleParameter("empname", OracleType.VarChar, 80)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = dtn.Rows(0)(0)
            parameter(2) = New OracleParameter("go_dt", OracleType.DateTime, 150)
            parameter(2).Direction = ParameterDirection.Input
            parameter(2).Value = Format(CDate(Me.Txt_fdt.Text), "dd/MMM/yyyy")
            parameter(3) = New OracleParameter("movtype", OracleType.VarChar, 150)
            parameter(3).Direction = ParameterDirection.Input
            parameter(3).Value = Me.ddl_movtype.SelectedValue
            parameter(4) = New OracleParameter("go_reason", OracleType.VarChar, 150)
            parameter(4).Direction = ParameterDirection.Input
            parameter(4).Value = Me.Txt_purp.Text
            parameter(5) = New OracleParameter("exit_time", OracleType.VarChar, 10)
            parameter(5).Direction = ParameterDirection.Input
            parameter(5).Value = Me.Txt_FromTime.Text
            parameter(6) = New OracleParameter("entry_time", OracleType.VarChar, 10)
            parameter(6).Direction = ParameterDirection.Input
            parameter(6).Value = Me.Txt_ToTime.Text
            parameter(7) = New OracleParameter("tot_time", OracleType.VarChar, 10)
            parameter(7).Direction = ParameterDirection.Input
            parameter(7).Value = Me.Txt_tot_time.Text
            parameter(8) = New OracleParameter("place", OracleType.VarChar, 150)
            parameter(8).Direction = ParameterDirection.Input
            parameter(8).Value = Me.Txtplace.Text
            parameter(9) = New OracleParameter("recper", OracleType.Number, 150)
            parameter(9).Direction = ParameterDirection.Input
            parameter(9).Value = Me.ddltl.SelectedValue
            parameter(10) = New OracleParameter("aprper", OracleType.Number, 100)
            parameter(10).Direction = ParameterDirection.Input
            parameter(10).Value = Me.ddlapp.SelectedValue
            parameter(11) = New OracleParameter("msg", OracleType.VarChar, 150)
            parameter(11).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("HRM_MOVEMENT_APPLYM", parameter)
            Dim message As String
            message = parameter(11).Value
            script1.Append("                        alert('" & message & "');")
            script1.Append("window.open('Movementslip_macom.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If
    End Sub



    Protected Sub Txt_ToTime_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ToTime.TextChanged

        Txt_ToTime.Text = Txt_ToTime.Text.ToUpper()
        Dim script1 As New System.Text.StringBuilder


        If (Me.Txt_FromTime.Text = "00:00 AM") Then
            script1.Append("        alert(' Please Select From Time..!!');")
            script1.Append("window.open('movementslip_macom.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If

        Dim f1() As String = Split(Me.Txt_FromTime.Text, " ")
        Dim f2() As String = Split(Me.Txt_ToTime.Text, " ")




        Dim f3() As String = Split(f1(0), ":")
        Dim f4() As String = Split(f2(0), ":")
        Dim InTimeString As String
        Dim OutTimeString As String
        Dim x As String
        Dim dFrom As DateTime
        Dim dTo As DateTime




        If (Me.Txt_FromTime.Text = "12:00 AM" And Me.Txt_ToTime.Text = "12:00 PM") Then
            script1.Append("        alert(' Invalid Shift Time..!!');")
            Me.Txt_FromTime.Text = "00:00 AM"
            Me.Txt_ToTime.Text = "00:00 AM"
            script1.Append("window.open('movementslip_macom.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        ElseIf (Me.Txt_FromTime.Text = "12:00 PM" And Me.Txt_ToTime.Text = "12:00 AM") Then
            script1.Append("        alert(' Invalid Shift Time..!!');")
            Me.Txt_FromTime.Text = "00:00AM"
            Me.Txt_ToTime.Text = "00:00 AM"
            script1.Append("window.open('movementslip_macom.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)


        ElseIf (Me.Txt_FromTime.Text = "11:00 AM" And Me.Txt_ToTime.Text = "12:00 AM") Then
            script1.Append("        alert(' Invalid Shift Time..!!');")
            Me.Txt_FromTime.Text = "00:00AM"
            Me.Txt_ToTime.Text = "00:00 AM"
            script1.Append("window.open('movementslip_macom.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If

        If (f2(1) = "AM" Or f2(1) = "PM") And (f1(1) = "AM" Or f1(1) = "PM") Then


            OutTimeString = f1(0) & ":00"
            Dim outHr As Double = CDbl(f3(0))


            InTimeString = f2(0) & ":00"
            Dim InHr As Double = CDbl(f4(0))

            OutTimeString = f1(0) & ":00"
            InTimeString = f2(0) & ":00"
            If (f2(1) = "PM") Then
                InHr = CDbl(f4(0))
                If (InHr < 12) Then
                    InHr = InHr + 12
                End If
                InTimeString = InHr & ":" & f4(1) & ":00"
            End If
            If (f1(1) = "PM") Then
                outHr = CDbl(f3(0))
                If (outHr < 12) Then
                    outHr = outHr + 12
                End If
                OutTimeString = outHr & ":" & f3(1) & ":00"
            End If


            If (outHr < 7 Or outHr > 21) Or (InHr < 7 Or InHr > 21) Or (outHr > InHr) Then

                script1.Append("        alert(' Invalid Shift Time..!!');")
                Me.Txt_FromTime.Text = "00:00 AM"
                Me.Txt_ToTime.Text = "00:00 AM"

                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)




            ElseIf DateTime.TryParse(OutTimeString, dFrom) AndAlso DateTime.TryParse(InTimeString, dTo) Then
                Dim TSA As TimeSpan = dTo - dFrom
                Dim hour As Integer = TSA.Hours
                Dim mins As Integer = TSA.Minutes
                Dim secs As Integer = TSA.Seconds
                If (mins < 0) Then

                    script1.Append("        alert(' Invalid Shift Time..!!');")
                    Me.Txt_FromTime.Text = "00:00 AM"
                    Me.Txt_ToTime.Text = "00:00 AM"

                Else
                    Dim timeDiff As String = ((hour.ToString("00") & ":") + mins.ToString("00") & ":") + secs.ToString("00")
                    x = timeDiff
                    Me.Txt_tot_time.Text = x

                End If
            End If






            Dim sfs() As String
            sfs = Session("user_id").ToString.Split("!")
            Dim sqo As String = "select hrm_movement_check('" & sfs(0) & "','" & Format(CDate(Me.Txt_fdt.Text), "dd/MMM/yyyy") & "'," & Me.ddl_movtype.SelectedValue & ",'" & Me.Txt_FromTime.Text & "','" & Me.Txt_ToTime.Text & "', '" & Me.Txt_tot_time.Text & "') from dual"
            dt = oh.ExecuteDataSet(sqo).Tables(0)
            Dim message As String

            If IsDBNull(dt.Rows(0)(0)) Then
                message = ""
            Else
                message = dt.Rows(0)(0)
            End If

            If message <> "" Then
                script1.Append("                        alert('" & message & "');")
                script1.Append("window.open('Movementslip_macom.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            End If

        Else


            script1.Append("        alert('Please Enter Time in Correct Format..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Me.Txt_FromTime.Text = "00:00 AM"
            Me.Txt_ToTime.Text = "00:00 AM"


        End If


        ' --- Applied Count (flag=101) ---
        Dim parasCount(3) As OracleParameter
        parasCount(0) = New OracleParameter("p_flag", OracleType.Number)
        parasCount(0).Direction = ParameterDirection.Input
        parasCount(0).Value = 101

        parasCount(1) = New OracleParameter("p_data", OracleType.VarChar, 1000)
        parasCount(1).Direction = ParameterDirection.Input
        parasCount(1).Value = Session("user_id").ToString.Split("!")(0).ToString()

        parasCount(2) = New OracleParameter("p_msg", OracleType.VarChar, 100)
        parasCount(2).Direction = ParameterDirection.Output

        parasCount(3) = New OracleParameter("qry_result", OracleType.Cursor)
        parasCount(3).Direction = ParameterDirection.Output

        Dim dsCount As DataSet = oh.ExecuteDataSet("proc_vo_macom", parasCount)
        Dim totalLimit As Integer = 6
        Dim dtCount As DataTable = dsCount.Tables(0)
        Dim count As Integer = 0
        If dtCount.Rows.Count > 0 Then
            count = Convert.ToInt32(dtCount.Rows(0)(0))
        End If
        'Txt_BalanceCountt.Text = count.ToString()
        Txt_BalanceCountt.Text = count.ToString() & "/" & totalLimit.ToString()
        Txt_BalanceCountt.ReadOnly = True


        ' --- Balance Time (flag=1) ---
        Dim parasTime(3) As OracleParameter
        parasTime(0) = New OracleParameter("p_flag", OracleType.Number)
        parasTime(0).Direction = ParameterDirection.Input
        parasTime(0).Value = 1

        parasTime(1) = New OracleParameter("p_data", OracleType.VarChar, 1000)
        parasTime(1).Direction = ParameterDirection.Input
        parasTime(1).Value = Session("user_id").ToString.Split("!")(0).ToString()

        parasTime(2) = New OracleParameter("p_msg", OracleType.VarChar, 100)
        parasTime(2).Direction = ParameterDirection.Output

        parasTime(3) = New OracleParameter("qry_result", OracleType.Cursor)
        parasTime(3).Direction = ParameterDirection.Output

        Dim dsTime As DataSet = oh.ExecuteDataSet("proc_movement_macom_new", parasTime)
        Dim dtTime As DataTable = dsTime.Tables(0)
        Dim totalMinutes As String = 0

        'If dtTime.Rows.Count > 0 Then
        'totalMinutes = Convert.ToDouble(dtTime.Rows(0)(0))
        ' End If
        'Dim ts As TimeSpan = TimeSpan.FromMinutes(totalMinutes)
        'Txt_BalanceTimee.Text = ts.ToString() ' HH:MM:SS
        Dim usedMinutes As Double = 0

        If dtTime.Rows.Count > 0 AndAlso Not IsDBNull(dtTime.Rows(0)(0)) Then
            usedMinutes = Convert.ToDouble(dtTime.Rows(0)(0))
        Else
            usedMinutes = 0
        End If

        Dim defaultMinutes As Double = 180  ' 3 hours in minutes
        Dim remainingMinutes As Double = defaultMinutes - usedMinutes

        ' Ensure remainingMinutes is not negative
        If remainingMinutes < 0 Then
            remainingMinutes = 0
        End If

        Dim remainingTime As TimeSpan = TimeSpan.FromMinutes(remainingMinutes)
        Txt_BalanceTimee.Text = remainingTime.ToString()
        Txt_BalanceTimee.ReadOnly = True


    End Sub

    Protected Sub Txt_fdt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_fdt.TextChanged

        Dim dF As Date = Me.Txt_fdt.Text
        Dim dF1 As Date = Date.Today
        'Dim dF2 As Date = dF1.AddDays(1)


        If (dF < dF1) Then
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('You Can't Select Back Date..!!');")
            Me.Txt_fdt.Text = Format(Date.Now, "dd/MMM/yyyy")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        ElseIf (CDate(Me.Txt_fdt.Text) > dF1) Then
            Dim script1 As New System.Text.StringBuilder
            script1.Append("     alert('You Can't Select Future Date!!');")
            Me.Txt_fdt.Text = Format(Date.Now, "dd/MMM/yyyy")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If

    End Sub


    Protected Sub Txt_FromTime_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_FromTime.TextChanged
        Txt_FromTime.Text = Txt_FromTime.Text.ToUpper()

        Dim script1 As New System.Text.StringBuilder
        Dim currtime As DateTime = DateTime.Now
        currtime = Format(Now, "hh:mm:ss tt")
        Dim leng = currtime.ToString.Length
        Dim mytime As String = currtime.ToString
        Dim mytimer As String = mytime.Substring(leng - 3)
        Dim ch As String = mytime.Substring(leng - 2)
        mytime = mytime.Replace(mytimer, "")
        Dim sp() As String = mytime.Split(" ")
        mytime = mytime.Replace(sp(0) + " ", "")



        Dim dFrom As DateTime
        Dim dTo As DateTime
        Dim sDateFrom As String = mytime
        Dim sDateTo As String = Me.Txt_FromTime.Text.ToString.Split(" ")(0) + ":00"

        If CDate(Date.Today) = CDate(Me.Txt_fdt.Text) Then
            If DateTime.TryParse(sDateFrom, dFrom) AndAlso DateTime.TryParse(sDateTo, dTo) Then

                Dim dd As String = sDateTo.Split(":")(0)
                Dim dd1 As String = ""
                Select Case dd
                    Case "01"
                        dd1 = "13"
                    Case "02"
                        dd1 = "14"
                    Case "03"
                        dd1 = "15"
                    Case "04"
                        dd1 = "16"
                    Case "05"
                        dd1 = "17"
                    Case "06"
                        dd1 = "18"
                    Case "07"
                        dd1 = "19"
                    Case "08"
                        dd1 = "20"
                    Case "09"
                        dd1 = "21"
                    Case "10"
                        dd1 = "22"
                    Case "11"
                        dd1 = "23"
                    Case "12"
                        dd1 = "24"

                End Select

                sDateTo = dd1 & ":" & sDateTo.Split(":")(1) & ":" & sDateTo.Split(":")(2)
                DateTime.TryParse(sDateTo, dTo)

                Dim TSA As TimeSpan = dTo - dFrom
                Dim hour As Integer = TSA.Hours
                Dim mins As Integer = TSA.Minutes
                Dim secs As Integer = TSA.Seconds
                Dim timeDiff As String = ((hour.ToString("00") & ":") + mins.ToString("00") & ":") + secs.ToString("00")


            End If
        End If




        'If CDate(Date.Today) = CDate(Me.Txt_fdt.Text) Then
        'If ch <> Me.Txt_FromTime.Text.ToString.Split(" ")(1).ToUpper Then
        '    If mytime < Me.Txt_FromTime.Text.ToString.Split(" ")(0) Then
        '        script1.Append("        alert(' Please Select  Future Time!!..!!');")
        '        Me.Txt_FromTime.Text = "00:00 am"
        '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        '        Exit Sub
        '    End If
        'End If
        'End If
        '-------------------------------remove
        Dim a As DateTime
        a = Convert.ToDateTime(Me.Txt_FromTime.Text)
        If a < Convert.ToDateTime(DateTime.Now) Then
            script1.Append("        alert(' Choose Future Time!!');")
            Me.Txt_FromTime.Text = "00:00 AM"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        '------------
        If a < Convert.ToDateTime(DateTime.Now) Then
            script1.Append("        alert(' Choose Future Time...!!');")
            Me.Txt_ToTime.Text = "00:00 AM"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        '--------

        If ch <> Me.Txt_FromTime.Text.ToString.Split(" ")(1).ToUpper Then
            If ch = "PM" And Me.Txt_FromTime.Text.ToString.Split(" ")(1).ToUpper = "AM" Then
                script1.Append("        alert(' Choose Future Time..!!');")
                Me.Txt_FromTime.Text = "00:00 AM"
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
                Exit Sub
            End If
        End If
        '-------------------------------remove

        If (Me.Txt_FromTime.Text = "00:00 AM") Then
            script1.Append("        alert(' Please Select To Time..!!');")
            script1.Append("window.open('movementslip_macom.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If


        ' --- Applied Count (flag=101) ---
        Dim parasCount(3) As OracleParameter
        parasCount(0) = New OracleParameter("p_flag", OracleType.Number)
        parasCount(0).Direction = ParameterDirection.Input
        parasCount(0).Value = 101

        parasCount(1) = New OracleParameter("p_data", OracleType.VarChar, 1000)
        parasCount(1).Direction = ParameterDirection.Input
        parasCount(1).Value = Session("user_id").ToString.Split("!")(0).ToString()

        parasCount(2) = New OracleParameter("p_msg", OracleType.VarChar, 100)
        parasCount(2).Direction = ParameterDirection.Output

        parasCount(3) = New OracleParameter("qry_result", OracleType.Cursor)
        parasCount(3).Direction = ParameterDirection.Output

        Dim dsCount As DataSet = oh.ExecuteDataSet("proc_vo_macom", parasCount)
        Dim totalLimit As Integer = 6
        Dim dtCount As DataTable = dsCount.Tables(0)
        Dim count As Integer = 0

        If dtCount.Rows.Count > 0 Then
            count = Convert.ToInt32(dtCount.Rows(0)(0))
        End If
        'Txt_BalanceCountt.Text = count.ToString()
        Txt_BalanceCountt.Text = count.ToString() & "/" & totalLimit.ToString()
        Txt_BalanceCountt.ReadOnly = True


        ' --- Balance Time (flag=1) ---
        Dim parasTime(3) As OracleParameter
        parasTime(0) = New OracleParameter("p_flag", OracleType.Number)
        parasTime(0).Direction = ParameterDirection.Input
        parasTime(0).Value = 1

        parasTime(1) = New OracleParameter("p_data", OracleType.VarChar, 1000)
        parasTime(1).Direction = ParameterDirection.Input
        parasTime(1).Value = Session("user_id").ToString.Split("!")(0).ToString()

        parasTime(2) = New OracleParameter("p_msg", OracleType.VarChar, 100)
        parasTime(2).Direction = ParameterDirection.Output

        parasTime(3) = New OracleParameter("qry_result", OracleType.Cursor)
        parasTime(3).Direction = ParameterDirection.Output

        Dim dsTime As DataSet = oh.ExecuteDataSet("proc_movement_macom_new", parasTime)
        Dim dtTime As DataTable = dsTime.Tables(0)
        Dim totalMinutes As String = 0

        'If dtTime.Rows.Count > 0 Then
        'totalMinutes = Convert.ToDouble(dtTime.Rows(0)(0))
        'End If
        ' Dim ts As TimeSpan = TimeSpan.FromMinutes(totalMinutes)
        'Txt_BalanceTimee.Text = ts.ToString() ' HH:MM:SS
        Dim usedMinutes As Double = 0

        If dtTime.Rows.Count > 0 AndAlso Not IsDBNull(dtTime.Rows(0)(0)) Then
            usedMinutes = Convert.ToDouble(dtTime.Rows(0)(0))
        Else
            usedMinutes = 0
        End If

        Dim defaultMinutes As Double = 180  ' 3 hours in minutes
        Dim remainingMinutes As Double = defaultMinutes - usedMinutes

        ' Ensure remainingMinutes is not negative
        If remainingMinutes < 0 Then
            remainingMinutes = 0
        End If

        Dim remainingTime As TimeSpan = TimeSpan.FromMinutes(remainingMinutes)
        Txt_BalanceTimee.Text = remainingTime.ToString()
        Txt_BalanceTimee.ReadOnly = True



    End Sub





    Protected Sub Cmd_Exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Response.Redirect("~/home.aspx")
    End Sub

End Class