Imports System.Data
Imports System.Data.OracleClient
Partial Class Employee_Punching_Consolidated_HOD_1231ede26564
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim cas As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Me.hid_br.Value = Session("branch_id")
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "MOVEMENT STATUS REPORT"
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.hid_br.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Me.txt_fromdt.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_fromdt')")
        Me.txt_todt.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_todt')")
        cas = CInt(Request.QueryString("case"))
        Dim fid As Integer = Session("firm_id")
        If fid = 28 Then
            If Not IsPostBack Then
                'Access checking 5187
                Dim str As String = "select count(*) from form_accessibility s where s.form_id in(5187,5188) and s.emp_id=" & User(0) & ""
                dt = oh.ExecuteDataSet(str).Tables(0)
                If (dt.Rows(0)(0) = 0) Then
                    Response.Redirect("~/show_err.aspx")
                    'Server.Transfer("../../show_err.aspx")
                    Return
                End If
                dt1 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
                'Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yyyy")

                Me.txt_fromdt.Text = Format(Now.Date, "dd/MMM/yyyy")
                Me.txt_todt.Text = Format(Now.Date, "dd/MMM/yyyy")
            End If
        Else
            Response.Redirect("~/show_err.aspx")
        End If
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            Dim firm As Integer = Session("firm_id")
            Dim ds As New DataSet
            Dim str As String
            str = "select e.emp_code as EMPCODE, em.emp_name as EMPNAME, trim(e.going_dt) as GOINGDATE    from hrm_movement_appl e, employee_master em,employee_master s  where e.emp_code = em.emp_code  and e.sanc_per=s.emp_code and to_date(e.going_dt) between to_date('" & txt_fromdt.Text & "') and to_date('" & txt_todt.Text & "')"
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
            Dim fname As String = "Employee_cosolidatedDtls.xls"
            GridViewExportUtil.Export(fname, dgGrid)
        Catch ex As Exception
            Dim cl_script11 As New System.Text.StringBuilder
            cl_script11.Append("        alert('Please try later');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
        End Try
    End Sub

    Protected Sub confirm_btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles confirm_btn.Click
        Try

            Dim firm As Integer = Session("firm_id")
            Dim usr() As String
            usr = Me.Session("user_id").ToString.Split("!")
            Dim UserId As Integer = usr(0)
            Dim dt1 As DataTable
            Gridallemp.Visible = True


            Dim orcl As String = "select e.emp_code as EMPCODE, em.emp_name as EMPNAME, trim(e.going_dt) as GOINGDATE    from hrm_movement_appl e, employee_master em,employee_master s  where e.emp_code = em.emp_code  and e.sanc_per=s.emp_code and to_date(e.going_dt) between to_date('" & txt_fromdt.Text & "') and to_date('" & txt_todt.Text & "')"
            dt1 = oh.ExecuteDataSet(orcl).Tables(0)
            If dt1.Rows.Count > 0 Then
                Gridallemp.DataSource = dt1
                Gridallemp.DataBind()
                Gridallemp.HeaderRow.Style.Add("background-color", "#FFFFFF")
                For i As Integer = 0 To Gridallemp.HeaderRow.Cells.Count - 1
                    'Gridallemp.HeaderRow.Cells(i).Style.Add("background-color", "#00GFFF")
                    Gridallemp.HeaderRow.Cells(i).Style.Add("background-color", "#F08080")
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
        Response.Redirect("~/home.aspx")
    End Sub
End Class

