Imports System.Data
Imports System.Data.OracleClient
Partial Class Payroll_leave_intimation_leave_intimation_dephead_c033b30b7382
    Inherits System.Web.UI.Page
    Dim dt, dt1, dts, dth, dt3 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim cas, UserCode As Integer
    Dim UserAll(), sf() As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim s As String = "select s.post_id from employee_master s where s.emp_code=" & UserAll(0) & " "
        dth = oh.ExecuteDataSet("select s.post_id from employee_master s where s.emp_code=" & UserAll(0) & "").Tables(0)
        If Not IsPostBack Then

            dt1 = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=6015 and s.emp_id=" & UserAll(0) & "").Tables(0)
            If dt1.Rows(0)(0) = 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

                'Me.Server.Transfer("../show_err.aspx")
                'Else
                '    dts = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=855 and emp_id=" & UserAll(0) & "").Tables(0)
                '    If dts.Rows(0)(0) = 0 Then
                '        Dim cl_script0 As New System.Text.StringBuilder
                '        cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
                '        cl_script0.Append("window.open('../home.aspx','_self');")
                '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                '    End If
            End If
        End If

        Me.hid_br.Value = Session("branch_id")
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "LEAVE INTIMATION REPORT"
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.hid_br.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Me.txt_fromdt.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_fromdt')")
        Me.txt_todt.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_todt')")
        cas = CInt(Request.QueryString("case"))


       
        If Not IsPostBack Then

            dt1 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
            Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yyyy")

            Me.txt_fromdt.Text = Format(Now.Date, "dd/MMM/yyyy")
            Me.txt_todt.Text = Format(Now.Date, "dd/MMM/yyyy")

            dt3 = oh.ExecuteDataSet("select 'SELECT HEAD', 0 from dual union all select e.emp_code || '-' || e.emp_name, e.emp_code from employee_master e where e.firm_id = 8 and e.branch_id = 0 and e.STATUS_ID = 1 and e.post_id = 1045 union all select e.emp_code|| '-' || e.emp_name, e.emp_code from employee_master e where e.emp_code in (100015, 100462,100336,100004,100002,100993,100098,100051,100279,100418,100239,100305,100063,100473,100020,100333,100801,100797,100294,100070,100074,100001)order by 2").Tables(0)
            Me.ddltl.DataSource = dt3
            Me.ddltl.DataTextField = dt3.Columns(0).ColumnName
            Me.ddltl.DataValueField = dt3.Columns(1).ColumnName
            Me.ddltl.DataBind()

        End If

    End Sub

    Protected Sub Exit_btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Exit_btn.Click
        Response.Redirect("~/home.aspx")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            Dim firm As Integer = Session("firm_id")
            Dim usr() As String
            usr = Me.Session("user_id").ToString.Split("!")
            Dim UserId As Integer = UserAll(0)
            Dim dt1 As DataTable
            Griduser.Visible = True


            Dim orcl As String = "select  to_char(t.leave_date) as ""LEAVE DATE"",(select d.emp_name from employee_master d where d.emp_code = t.nhead) as ""TECHLEAD NAME"", decode(t.status, 1, 'INFORMED', 2, 'NOT INFORMED') as STATUS,m.emp_name as ""EMPLOYEE NAME"", t.emp_code as ""EMPLOYEE CODE"", UPPER(t.remark) as ""LEAVE REASON"",  to_char(t.curr_date) as ""ENTERED DATE"", case when ctz.emp_code > 0 then (select emp_name from employee_master where emp_code = ctz.dep_head) else (select distinct emm.emp_name from employee_master emm where emm.emp_code = dep.dep_head) end ""DEPARTMENT HEAD"" from employee_master m, department_mst dep, tbl_leave_intimation t, employ_firm f left outer join macom_department_head ctz on (ctz.emp_code = f.EMP_CODE) where t.emp_code = m.emp_code and dep.dep_id = m.department_id and f.firm_id = 8 and to_date(t.curr_date) between to_date('" & txt_fromdt.Text & "') and to_date('" & txt_todt.Text & "') and f.emp_code = t.emp_code and t.emp_code=" & Me.ddlemp.SelectedValue & " order by 1"
            dt1 = oh.ExecuteDataSet(orcl).Tables(0)
            If dt1.Rows.Count > 0 Then
                Griduser.DataSource = dt1
                Griduser.DataBind()
                Griduser.HeaderRow.Style.Add("background-color", "#FFFFFF")
                For i As Integer = 0 To Griduser.HeaderRow.Cells.Count - 1
                    'Gridallemp.HeaderRow.Cells(i).Style.Add("background-color", "#00GFFF")
                    Griduser.HeaderRow.Cells(i).Style.Add("background-color", "#F08080")
                Next
            Else
                Dim cl_script11 As New System.Text.StringBuilder
                cl_script11.Append("        alert('No Data Found');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
            End If

        Catch ex As Exception
            Dim cl_script11 As New System.Text.StringBuilder
            cl_script11.Append("        alert('Error. please check the values entered.');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
        End Try
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            Dim firm As Integer = Session("firm_id")
            Dim ds As New DataSet
            Dim str As String
            str = "select  to_char(t.leave_date) as ""LEAVE DATE"",(select d.emp_name from employee_master d where d.emp_code = t.nhead) as ""TECHLEAD NAME"", decode(t.status, 1, 'INFORMED', 2, 'NOT INFORMED') as STATUS,m.emp_name as ""EMPLOYEE NAME"", t.emp_code as ""EMPLOYEE CODE"", UPPER(t.remark) as ""LEAVE REASON"",  to_char(t.curr_date) as ""ENTERED DATE"", case when ctz.emp_code > 0 then (select emp_name from employee_master where emp_code = ctz.dep_head) else (select distinct emm.emp_name from employee_master emm where emm.emp_code = dep.dep_head) end ""DEPARTMENT HEAD"" from employee_master m, department_mst dep, tbl_leave_intimation t, employ_firm f left outer join macom_department_head ctz on (ctz.emp_code = f.EMP_CODE) where t.emp_code = m.emp_code and dep.dep_id = m.department_id and f.firm_id = 8 and to_date(t.curr_date) between to_date('" & txt_fromdt.Text & "') and to_date('" & txt_todt.Text & "') and f.emp_code = t.emp_code and t.emp_code=" & Me.ddlemp.SelectedValue & " order by 1"
            ds = oh.ExecuteDataSet(str)

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
            Dim fname As String = "Employee_LeaveDtls.xls"
            WebAppHRMS.GridViewExportUtil.Export(fname, dgGrid)
        Catch ex As Exception
            Dim cl_script11 As New System.Text.StringBuilder
            cl_script11.Append("        alert('Please try later');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
        End Try
    End Sub

    Protected Sub ddlemp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlemp.SelectedIndexChanged
        dt3 = oh.ExecuteDataSet("select count(*) from employee_master m, department_mst dep, tbl_leave_intimation t, employ_firm f left outer join macom_department_head ctz on (ctz.emp_code = f.EMP_CODE) where t.emp_code = m.emp_code and dep.dep_id = m.department_id and f.firm_id = 8 and to_date(t.curr_date) between to_date('" & txt_fromdt.Text & "') and to_date('" & txt_todt.Text & "') and f.emp_code = t.emp_code and t.emp_code=" & Me.ddlemp.SelectedValue & " order by 1").Tables(0)
        Me.Txt_tot.Text = dt3.Rows(0)(0)
    End Sub

    Protected Sub ddltl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddltl.SelectedIndexChanged
        dt3 = oh.ExecuteDataSet("select 'SELECT EMPLOYEE',0 from dual union all select  m.emp_code||'-'||m.emp_name,m.emp_code from tbl_dept_structure d,employee_master m where d.emp_code=m.emp_code and  d.head=" & Me.ddltl.SelectedValue & "order by 2 ").Tables(0)
        Me.ddlemp.DataSource = dt3
        Me.ddlemp.DataTextField = dt3.Columns(0).ColumnName
        Me.ddlemp.DataValueField = dt3.Columns(1).ColumnName
        Me.ddlemp.DataBind()
    End Sub
End Class
