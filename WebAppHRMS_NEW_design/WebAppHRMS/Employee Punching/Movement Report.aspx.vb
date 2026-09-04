Imports System.Data
Imports System.Data.OracleClient

Partial Class Employee_Punching_Movement_Report_b422ee418693
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim cas As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Me.hid_br.Value = Session("branch_id")
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "MOVEMENT REPORT"
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.hid_br.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Me.txt_fromdt.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_fromdt')")
        Me.txt_todt.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_todt')")
        cas = CInt(Request.QueryString("case"))
        Dim str As String = "select count(*) from form_accessibility s where s.form_id=9998 and s.emp_id=" & User(0) & ""
        dt2 = oh.ExecuteDataSet(str).Tables(0)
        If Not IsPostBack Then
            Dim accessCount As Integer = Convert.ToInt32(dt2.Rows(0)(0))
            If Session("access_id") = 33 Or accessCount = 1 Then
                dt1 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
                Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yyyy")

                Me.txt_fromdt.Text = Format(Now.Date, "dd/MMM/yyyy")
                Me.txt_todt.Text = Format(Now.Date, "dd/MMM/yyyy")
            Else
                Me.Server.Transfer("../show_err.aspx")

            End If
            'dt1 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
            'Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yyyy")

            'Me.txt_fromdt.Text = Format(Now.Date, "dd/MMM/yyyy")
            'Me.txt_todt.Text = Format(Now.Date, "dd/MMM/yyyy")
        End If
    End Sub


    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            Dim firm As Integer = Session("firm_id")
            Dim ds As New DataSet
            Dim str As String
            If firm = 27 Then
                str = "select trim(t.reqst_dt) as REQUST_DATE, t.emp_code as EMPCODE, t.emp_name as EMPNAME, t.exit_time as EXIT_TIME, t.entry_time as ENTRY_TIME, decode(t.mov_type, 1, 'Personal', 2, 'Official') as MOVEMENT_TYPE, t.place as PLACE, t.purpose as PURPOSE, (select d.emp_name from mactech.employee_master d where d.emp_code=t.rec_usr) as RECOMMENDER,(select d.emp_name from mactech.employee_master d where d.emp_code=t.aprv_usr) as APPROVER, decode(t.status_id, 1, 'Recommended', 0, 'Applied', 2, 'Approved', 3, 'Rejected') as STATUS from mactech.tbl_movement_mst t where t.emp_code = t.emp_code and to_date(t.reqst_dt) between to_date ('" & txt_fromdt.Text & "') and to_date('" & txt_todt.Text & "') and t.firm=27"

            Else
                str = "select trim(t.reqst_dt) as ""REQUST DATE"", t.emp_code as ""EMPLOYEE CODE"", upper(t.emp_name) as ""EMPLOYEE NAME"", upper(decode(t.status_id, 1, 'Recommended', 0, 'Applied', 2, 'Approved', 3, 'Rejected', 4, 'Cancelled', 5, 'Time Out')) as STATUS, t.exit_time as ""EXIT TIME"", t.entry_time as ""ENTRY TIME"", upper(decode(t.mov_type, 1, 'Personal', 2, 'Official')) as TYPE, upper(t.place) as PLACE, upper(t.purpose) as PURPOSE, (select d.emp_name from mactech.employee_master d where d.emp_code = t.rec_usr) as RECOMMENDER, (select d.emp_name from mactech.employee_master d where d.emp_code = t.aprv_usr) as APPROVER from mactech.tbl_movement_mst t, mactech.employee_master mm where mm.emp_code = t.emp_code and mm.firm_id = 8 and to_date(t.reqst_dt) between to_date('" & txt_fromdt.Text & "') and to_date('" & txt_todt.Text & "') order by 1 DESC, 4 ASC, 5 ASC, 6 ASC"
            End If
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
            Dim fname As String = "Employee_MovementDtls.xls"
            WebAppHRMS.GridViewExportUtil.Export(fname, dgGrid)
        Catch ex As Exception
            Dim cl_script11 As New System.Text.StringBuilder
            cl_script11.Append("        alert('Please try later');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            Dim firm As Integer = Session("firm_id")
            Dim usr() As String
            usr = Me.Session("user_id").ToString.Split("!")
            Dim UserId As Integer = usr(0)
            Dim dt1 As DataTable
            Griduser.Visible = True
            Dim orcl As String
            If firm = 27 Then
                orcl = "select trim(t.reqst_dt) as REQUST_DATE, t.emp_code as EMPCODE, t.emp_name as EMPNAME, t.exit_time as EXIT_TIME, t.entry_time as ENTRY_TIME, decode(t.mov_type, 1, 'Personal', 2, 'Official') as MOVEMENT_TYPE, t.place as PLACE, t.purpose as PURPOSE, (select d.emp_name from mactech.employee_master d where d.emp_code=t.rec_usr) as RECOMMENDER,(select d.emp_name from mactech.employee_master d where d.emp_code=t.aprv_usr) as APPROVER, decode(t.status_id, 1, 'Recommended', 0, 'Applied', 2, 'Approved', 3, 'Rejected') as STATUS from mactech.tbl_movement_mst t where t.emp_code = t.emp_code and to_date(t.reqst_dt) between to_date ('" & txt_fromdt.Text & "') and to_date('" & txt_todt.Text & "') and t.firm=27"
            Else
                orcl = "select trim(t.reqst_dt) as ""REQUST DATE"", t.emp_code as ""EMPLOYEE CODE"", upper(t.emp_name) as ""EMPLOYEE NAME"", upper(decode(t.status_id, 1, 'Recommended', 0, 'Applied', 2, 'Approved', 3, 'Rejected', 4, 'Cancelled', 5, 'Time Out')) as STATUS, t.exit_time as ""EXIT TIME"", t.entry_time as ""ENTRY TIME"", upper(decode(t.mov_type, 1, 'Personal', 2, 'Official')) as TYPE, upper(t.place) as PLACE, upper(t.purpose) as PURPOSE, (select d.emp_name from mactech.employee_master d where d.emp_code = t.rec_usr) as RECOMMENDER, (select d.emp_name from mactech.employee_master d where d.emp_code = t.aprv_usr) as APPROVER from mactech.tbl_movement_mst t, mactech.employee_master mm where mm.emp_code = t.emp_code and mm.firm_id = 8 and to_date(t.reqst_dt) between to_date('" & txt_fromdt.Text & "') and to_date('" & txt_todt.Text & "') order by 1 DESC, 4 ASC, 5 ASC, 6 ASC"

            End If
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

    Protected Sub Exit_btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Exit_btn.Click
        Response.Redirect("../home.aspx")
    End Sub

    Protected Sub txt_fromdt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_fromdt.TextChanged

    End Sub
End Class



