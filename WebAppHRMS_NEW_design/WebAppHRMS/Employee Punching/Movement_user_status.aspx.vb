Imports System.Data
Imports System.Data.OracleClient
Partial Class Employee_Punching_Movement_user_status_cbc6afc57737
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim cas As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Dim fid As Integer = Session("firm_id")
        If fid = 28 Then
            Me.hid_br.Value = Session("branch_id")
            CType(Me.Master, WebAppHRMS.edp).Subtitle = "MOVEMENT STATUS REPORT"
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
        Else
            Response.Redirect("~/show_err.aspx")
        End If
    End Sub
    

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            Dim firm As Integer = Session("firm_id")
            Dim ds As New DataSet
            Dim str As String
            str = "select e.emp_code as EMPCODE,e.sanc_per, em.emp_name as EMPNAME, trim(e.going_dt) as GOINGDATE, s.emp_name as APPROVER, e.reason REASON,e.rej_person,s1.emp_name as rejected_by, decode(e.status, 1, 'Sanctioned', 0, 'Applied', 2, 'Rejected') as STATUS from employee_master em ,hrm_movement_appl e left outer join employee_master s on (e.sanc_per = s.emp_code) left outer join employee_master s1 on (e.rej_person = s1.emp_code ) where e.emp_code = em.emp_code and to_date(e.going_dt) between to_date('" & txt_fromdt.Text & "') and to_date('" & txt_todt.Text & "')"
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
            GridViewExportUtil.Export(fname, dgGrid)
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


            Dim orcl As String = "select e.emp_code as EMPCODE,e.sanc_per, em.emp_name as EMPNAME, trim(e.going_dt) as GOINGDATE, s.emp_name as APPROVER, e.reason REASON,e.rej_person,s1.emp_name as rejected_by, decode(e.status, 1, 'Sanctioned', 0, 'Applied', 2, 'Rejected') as STATUS from employee_master em ,hrm_movement_appl e left outer join employee_master s on (e.sanc_per = s.emp_code) left outer join employee_master s1 on (e.rej_person = s1.emp_code ) where e.emp_code = em.emp_code and to_date(e.going_dt) between to_date('" & txt_fromdt.Text & "') and to_date('" & txt_todt.Text & "')"
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
        Response.Redirect("~/home.aspx")
    End Sub
End Class

