Imports System.Data
Imports System.Data.OracleClient
Imports System.IO

Partial Class vipin_forms_Ho_Employees_reg_status_80192d688963
    Inherits System.Web.UI.Page
    Dim dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim UserAll(), res, sql, str As String
    Dim UserCode, stat As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_confirm.Click

        Dim d1 As Date = Me.txt_frmdate.Text
        Dim d2 As Date = Me.txt_todate.Text

        If Me.txt_empcode.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Enter Employee Code');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        ElseIf d1 > CDate(Date.Now) Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Future Date Not Allowed');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        ElseIf d2 > CDate(Date.Now) Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Future Date Not Allowed');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        ElseIf d1 > d2 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Date format not supported');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        Else
            Dim firm As Integer = Session("firm_id")
            Dim usr() As String
            usr = Me.Session("user_id").ToString.Split("!")
            Dim UserId As Integer = usr(0)
            Dim dt1 As DataTable
            GridView1.Visible = True

            Dim orcl As String = "select e.emp_code EmpCode, e.emp_name EmpName, h.apply_dt Requested_Date, e1.emp_name RecomendedBy, h.rec_dt RecommendedDate, e2.emp_name ApprovedBy, h.apply_dt ApprovedDate, decode(h.status, 0, 'REQUESTED', 1, 'SANCTIONED', 2, 'REJECTED', 3, 'RECOMMENDED') as Status from tbl_regularisation h, employee_master e, employee_master e1, employee_master e2 where e.emp_code = h.emp_code and e1.emp_code = h.rec_person and e2.emp_code = h.app_person and h.emp_code = " & Me.txt_empcode.Text & " and to_date(h.apply_dt) between '" & Me.txt_frmdate.Text & "' and '" & Me.txt_todate.Text & "' "
            dt1 = oh.ExecuteDataSet(orcl).Tables(0)
            If dt1.Rows.Count > 0 Then

                GridView1.DataSource = dt1
                GridView1.DataBind()
                GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF")
                For i As Integer = 0 To GridView1.HeaderRow.Cells.Count - 1
                    'Gridallemp.HeaderRow.Cells(i).Style.Add("background-color", "#00GFFF")
                    GridView1.HeaderRow.Cells(i).Style.Add("background-color", "#F08080")
                Next
            Else
                Dim cl_script11 As New System.Text.StringBuilder
                cl_script11.Append("        alert('No Data Found');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
            End If
        End If


    End Sub
    

    Protected Sub btn_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Server.Transfer("../home.aspx")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
       

        Try


            Dim dt As New DataTable
            Dim ap3 As String = """"
            Dim Sql33 As String = "select e.emp_code EmpCode, e.emp_name EmpName, h.apply_dt Requested_Date, e1.emp_name RecomendedBy, h.rec_dt RecommendedDate, e2.emp_name ApprovedBy, h.apply_dt ApprovedDate, decode(h.status, 0, 'REQUESTED', 1, 'SANCTIONED', 2, 'REJECTED', 3, 'RECOMMENDED') as Status from tbl_regularisation h, employee_master e, employee_master e1, employee_master e2 where e.emp_code = h.emp_code and e1.emp_code = h.rec_person and e2.emp_code = h.app_person and to_date(h.apply_dt) between '" & Me.txt_frmdate.Text & "' and '" & Me.txt_todate.Text & "' "
            dt = oh.ExecuteDataSet(Sql33).Tables(0)
            If dt.Rows.Count > 0 Then
                GridView1.DataSource = dt
                GridView1.DataBind()
            End If
            If (dt.Rows.Count > 0) Then


                Response.Clear()
                Response.Buffer = True
                Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls")
                Response.Charset = ""
                Response.ContentType = "application/vnd.ms-excel"
                Using sw As New StringWriter()
                    Dim hw As New HtmlTextWriter(sw)

                    'To Export all pages
                    GridView1.AllowPaging = False
                    GridView1.DataBind()


                    For Each cell As TableCell In GridView1.HeaderRow.Cells
                        cell.BackColor = GridView1.HeaderStyle.BackColor
                    Next
                    For Each row As GridViewRow In GridView1.Rows

                        For Each cell As TableCell In row.Cells
                            If row.RowIndex Mod 2 = 0 Then
                                cell.BackColor = GridView1.AlternatingRowStyle.BackColor
                            Else
                                cell.BackColor = GridView1.RowStyle.BackColor
                            End If
                            cell.CssClass = "textmode"
                        Next
                    Next

                    GridView1.RenderControl(hw)

                    Dim style As String = "<style> .textmode { } </style>"
                    Response.Write(style)
                    Response.Output.Write(sw.ToString())
                    Response.Flush()
                    Response.[End]()

                End Using
            Else
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('No Pending Data To Verify...') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)

            End If




        Catch ex As Exception
            Dim cl_script11 As New System.Text.StringBuilder
            cl_script11.Append("        alert('Please try later');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
        End Try





    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        'Required to verify that the control is rendered properly on page
    End Sub
End Class
