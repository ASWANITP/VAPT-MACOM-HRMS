Imports CrystalDecisions.Web
Imports Helper.Oracle
Imports System.Data
Imports System.Data.OracleClient
Public Class Acc_file_Report
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then

            '' Execute and bind
            Dim sql As String = "select to_char(trunc(t.req_date)) as Date_Forwarded, t.file_name as File_Name, e_req.emp_code || ' - ' || e_req.emp_name as Received_from, d2.dep_name as Requester_Department, t.purpose as Purpose, e_rec.emp_code || ' - ' || e_rec.emp_name as Receiver_Name, d2.dep_name as Receiver_Department, nvl(to_char(trunc(t.received_date)), '----------') as Date_received, t.remark as Remarks, nvl(t.receiver_remark, '----------') as Receiver_Remarks from tbl_accfile_mov t inner join employee_master e_req on t.req_name = e_req.emp_code inner join department_mst d1 on e_req.department_id = d1.dep_id inner join employee_master e_rec on t.receiver_name = e_rec.emp_code inner join department_mst d2 on e_rec.department_id = d2.dep_id where to_date(t.req_date) between to_date(:FromDate) and to_date(:ToDate) order by t.req_date desc"
            Dim fromDt As DateTime = DateTime.ParseExact(Request.QueryString("fdt"), "yyyy-MM-dd", Nothing).Date
            Dim toDt As DateTime = DateTime.ParseExact(Request.QueryString("tdt"), "yyyy-MM-dd", Nothing).Date
            'Dim emp As Integer = Integer.Parse(Request.QueryString("emp"))

            Dim pFromDate As New OracleParameter("FromDate", OracleType.DateTime) With {.Value = fromDt}
            Dim pToDate As New OracleParameter("ToDate", OracleType.DateTime) With {.Value = toDt}
            'Dim pEmpCode As New OracleParameter("EmpCode", OracleType.Number) With {.Value = emp}

            Dim ds As DataSet = oh.ExecuteDataSet(sql, New OracleParameter() {pFromDate, pToDate})
            Dim dt As DataTable = ds.Tables(0)

            gvReport.AllowPaging = False
            gvReport.DataSource = dt
            gvReport.DataBind()
        End If

    End Sub

    Protected Sub BtnLoadReport_Click(sender As Object, e As EventArgs) Handles BtnLoadReport.Click



    End Sub

    Protected Sub gvReport_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvReport.PageIndex = e.NewPageIndex
        ' Re-bind using the same logic
        BtnLoadReport_Click(Nothing, Nothing)
    End Sub

End Class