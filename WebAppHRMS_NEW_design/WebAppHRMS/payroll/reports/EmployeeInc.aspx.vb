Imports System.Data
Imports System.IO
Partial Class EmployeeInc_e79c7c569031
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
   
    Private Function process()

        Dim firm_id As String = Convert.ToString(Session("firm_id"))
        Dim dt As New DataTable

        dt = oh.ExecuteDataSet("select p.emp_code    as E_CODE, e.EMP_NAME    as NAME,p.basic_pay   as BASIC_PAY,p.from_dt     as LAST_INCREMENT,e.JOIN_DT     as JOIN_DATE,d.designation as Designation,ps.post_name  as POST_NAME, (select case when (select count(qm.qualification) from employ_qualification_dtl q join qualification_master qm on q.qualification =qm.qualification_id where q.emp_code = e.EMP_CODE and q.year_pass in (select max(s.year_pass) from employ_qualification_dtl s where s.emp_code = e.EMP_CODE)) > 1 then (select qm.qualification from employ_qualification_dtl q join qualification_master qm on q.qualification =qm.qualification_id where q.emp_code = e.EMP_CODE and q.year_pass in (select max(s.year_pass) from employ_qualification_dtl s where s.emp_code = e.EMP_CODE) and rownum = 1) else (select qm.qualification from employ_qualification_dtl q join qualification_master qm on q.qualification = qm.qualification_id where q.emp_code = e.EMP_CODE and q.year_pass in (select max(s.year_pass) from employ_qualification_dtl s where s.emp_code = e.EMP_CODE)) end from dual) as  QUALIFICATION from employ_promotion_dtl p,emp_master  e,employ_firm f,designation_mst d,post_mst  ps where (e.EMP_CODE = p.emp_code) and f.emp_code = p.emp_code and e.DESIGNATION_ID = d.designation_id and e.POST_ID = ps.post_id and f.firm_id = '" + firm_id + "' AND E.STATUS_ID = 1 and p.to_dt is null and add_months(to_date(p.from_dt),12) <= to_date('" + txt_date.Text + "') and p.status_id not in (4) order by 1").Tables(0)
        GrvEmp.DataSource = dt
        GrvEmp.DataBind()

        If dt.Rows.Count > 0 Then
            LabelMonth.Text = "Salary Increment Eligible Report As On " + txt_date.Text
        ElseIf dt.Rows.Count = 0 And txt_date.Text <> "" Then
            LabelMonth.Text = "No Records Found"
        End If



    End Function

    'Private Function getDatatable(ByVal qry As Object) As DataTable
    '    Dim dtresults As New DataTable
    '    Dim oh As New Helper.Oracle.OracleHelper
    '    dtresults = oh.ExecuteDataSet(qry).Tables(0)
    '    Return dtresults
    'End Function

    Protected Sub ButtonExccel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonExccel.Click
        Dim filename As String
        'filename = "Emp_Increment_" + DDLMonths.SelectedValue + ".xls"
        filename = "Emp_Increment_" + txt_date.Text + ".xls"


        Response.ClearContent()
        Response.Buffer = True
        Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", filename))
        Response.ContentType = "application/ms-excel"
        Dim sw As New StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        GrvEmp.AllowPaging = False
        GrvEmp.DataBind()
        'Change the Header Row back to white color
        GrvEmp.HeaderRow.Style.Add("background-color", "#FFFFFF")
        'Applying stlye to gridview header cells
        For i As Integer = 0 To GrvEmp.HeaderRow.Cells.Count - 1
            GrvEmp.HeaderRow.Cells(i).Style.Add("background-color", "#507CD1")
        Next
        Dim j As Integer = 1
        'This loop is used to apply stlye to cells based on particular row
        For Each gvrow As GridViewRow In GrvEmp.Rows
            gvrow.BackColor = Drawing.Color.White
            If j <= GrvEmp.Rows.Count Then
                If j Mod 2 <> 0 Then
                    For k As Integer = 0 To gvrow.Cells.Count - 1
                        gvrow.Cells(k).Style.Add("background-color", "#EFF3FB")
                    Next
                End If
            End If
            j += 1
        Next
        GrvEmp.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim UserAll() As String = Session("user_id").ToString.Split("!")
            Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=184 and emp_id=" & UserAll(0)).Tables(0).Rows(0)(0)
            If acce <= 0 Then
                Me.Server.Transfer("../../show_err.aspx")
                Exit Sub
            End If
        End If

    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        process()
    End Sub

    Protected Sub btn_Report_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Report.Click
        process()
    End Sub
End Class
