Imports System.Data
Imports System.Data.OracleClient
Partial Class Payroll_leave_intimation_leave_intimation_ceo_88b160c29851
    Inherits System.Web.UI.Page
    Dim dt, dt1, dts As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim cas, UserCode As Integer
    Dim UserAll(), sf() As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim User() As String
        'User = Session("user_id").ToString.Split("!")
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        dts = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=855 and emp_id=" & UserAll(0) & "").Tables(0)
        If dts.Rows(0)(0) = 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        Me.hid_br.Value = Session("branch_id")
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "LEAVE INTIMATION PENDING REPORT"
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


            Dim orcl As String = "select distinct trim(t.leave_date) as ""LEAVE DATE"", (select d.emp_name from employee_master d where d.emp_code = t.nhead) as ""TECHLEAD NAME"", decode(t.status, 1, 'INFORMED', 2, 'NOT INFORMED') as ""STATUS"", m.emp_name as ""EMPLOYEE NAME"", m.emp_code as ""EMPLOYEE CODE"" from employee_master m, department_mst dep, tbl_leave_intimation t, employ_firm f left outer join macom_department_head ctz on (ctz.emp_code = f.EMP_CODE) where t.emp_code = m.emp_code and dep.dep_id = m.department_id and f.firm_id = 8 and to_date(t.curr_date)between to_date('" & txt_fromdt.Text & "') and to_date('" & txt_todt.Text & "') and f.emp_code = t.emp_code union all select to_char(e.CURR_DATE) ""LEAVE DATE"", m1.emp_name ""TECHLEAD NAME"", 'PENDING' STATUS, m.emp_name ""EMPLOYEE NAME"", e.emp_code ""EMPLOYEE CODE"" from ATTENDANCE e, tbl_dept_structure d, employee_master m, employee_master m1, employee_master m2, department_mst dep where to_date(e.curr_date) between to_date('" & txt_fromdt.Text & "') and to_date('" & txt_todt.Text & "') and d.emp_code = e.emp_code and e.emp_code not in (select t.emp_code from tbl_leave_intimation t where to_date(t.leave_date) between to_date('" & txt_fromdt.Text & "') and to_date('" & txt_todt.Text & "')) and e.emp_code = m.emp_code and m.department_id = dep.dep_id and m2.emp_code = dep.dep_head and e.m_time is null and e.firm_id = 8 and d.head = m1.emp_code and e.branch_id = 0 order by 1, 2,3"
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
            str = "select distinct trim(t.leave_date) as ""LEAVE DATE"", (select d.emp_name from employee_master d where d.emp_code = t.nhead) as ""TECHLEAD NAME"", decode(t.status, 1, 'INFORMED', 2, 'NOT INFORMED') as STATUS, m.emp_name as ""EMPLOYEE NAME"", m.emp_code as ""EMPLOYEE CODE"" from employee_master m, department_mst dep, tbl_leave_intimation t, employ_firm f left outer join macom_department_head ctz on (ctz.emp_code = f.EMP_CODE) where t.emp_code = m.emp_code and dep.dep_id = m.department_id and f.firm_id = 8 and to_date(t.curr_date)between to_date('" & txt_fromdt.Text & "') and to_date('" & txt_todt.Text & "') and f.emp_code = t.emp_code union all select to_char(e.CURR_DATE) ""LEAVE DATE"", m1.emp_name ""TECHLEAD NAME"", 'PENDING' STATUS, m.emp_name ""EMPLOYEE NAME"", e.emp_code ""EMPLOYEE CODE"" from ATTENDANCE e, tbl_dept_structure d, employee_master m, employee_master m1, employee_master m2, department_mst dep where to_date(e.curr_date) between to_date('" & txt_fromdt.Text & "') and to_date('" & txt_todt.Text & "') and d.emp_code = e.emp_code and e.emp_code not in (select t.emp_code from tbl_leave_intimation t where to_date(t.leave_date) between to_date('" & txt_fromdt.Text & "') and to_date('" & txt_todt.Text & "')) and e.emp_code = m.emp_code and m.department_id = dep.dep_id and m2.emp_code = dep.dep_head and e.m_time is null and e.firm_id = 8 and d.head = m1.emp_code and e.branch_id = 0 order by 1, 2,3"
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

End Class


