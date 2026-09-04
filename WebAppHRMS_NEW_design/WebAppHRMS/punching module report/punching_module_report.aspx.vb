
Imports System.Data
Imports System.Data.OracleClient
Public Class punching_module_report
    Inherits System.Web.UI.Page

    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim txtFromDate As String = Request.QueryString("fdt")
            Dim txtToDate As String = Request.QueryString("tdt")
            'Dim empCode As String = Request.QueryString("emp")

            'If String.IsNullOrEmpty(txtFromDate) OrElse String.IsNullOrEmpty(txtToDate) Then
            '    txtFromDate = DateTime.Now.ToString("yyyy-MM-dd")
            '    txtToDate = txtFromDate
            'End If
            If String.IsNullOrEmpty(txtFromDate) OrElse String.IsNullOrEmpty(txtToDate) Then
                txtFromDate = DateTime.Now.ToString("yyyy-MM-dd")
                txtToDate = txtFromDate
            End If

            LoadNormsData(txtFromDate, txtToDate)
        End If
    End Sub


    Private Sub LoadNormsData(txtFromDate As String, txtToDate As String)
        Dim query As String = "select a.emp_code, c.emp_name, TO_CHAR(a.curr_date, 'MM/DD/YYYY') as curr_date, a.m_time, case when E.m_cnt > 0 and a.m_time is not null then 'OLD MODULE' when a.m_time is null then '' ELSE 'NEW MODULE' END IN_MODULE, a.e_time, case when g.e_cnt > 0 and a.e_time is not null then 'OLD MODULE' when a.e_time is null then '' ELSE 'NEW MODULE' END OUT_MODULE from mactech.attend a left join (select d.emp_code, to_date(d.punch_day) punch_day, count(*) m_cnt from mactech.punch_tbl_macom d where d.m_time is not null group by d.emp_code, d.punch_day) e on (a.emp_code = e.emp_code and a.curr_date = e.punch_day) left join (select f.emp_code, to_date(f.punch_day) punch_day, count(*) e_cnt from mactech.punch_tbl_macom f where f.e_time is not null group by f.emp_code, f.punch_day) g on (a.emp_code = g.emp_code and a.curr_date = g.punch_day), mactech.employ_firm b, mactech.employee_master c where a.emp_code = c.emp_code and b.emp_code = c.emp_code and b.firm_id = 8 and c.status_id=1 and a.curr_date between to_date('" & txtFromDate & "', 'yyyy-mm-dd') and to_date('" & txtToDate & "', 'yyyy-mm-dd') union all select ah.emp_code, c.emp_name, TO_CHAR(ah.curr_date, 'MM/DD/YYYY') as curr_date, ah.m_time, case when E.m_cnt > 0 and ah.m_time is not null then 'OLD MODULE' when ah.m_time is null then '' ELSE 'NEW MODULE' END IN_MODULE, ah.e_time, case when g.e_cnt > 0 and ah.e_time is not null then 'OLD MODULE' when ah.e_time is null then '' ELSE 'NEW MODULE' END OUT_MODULE from mactech.daily_attend ah left join (select d.emp_code, to_date(d.punch_day) punch_day, count(*) m_cnt from mactech.punch_tbl_macom d where d.m_time is not null group by d.emp_code, d.punch_day) e on (ah.emp_code = e.emp_code and ah.curr_date = e.punch_day) left join (select f.emp_code, to_date(f.punch_day) punch_day, count(*) e_cnt from mactech.punch_tbl_macom f where f.e_time is not null group by f.emp_code, f.punch_day) g on (ah.emp_code = g.emp_code and ah.curr_date = g.punch_day), mactech.employ_firm b, mactech.employee_master c where ah.emp_code = c.emp_code and b.emp_code = c.emp_code and b.firm_id = 8 and c.status_id=1 and ah.curr_date between to_date('" & txtFromDate & "', 'yyyy-mm-dd') and to_date('" & txtToDate & "', 'yyyy-mm-dd')order by emp_code asc"
        Try
            Dim ds As DataSet = oh.ExecuteDataSet(query)
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                gvNorms.DataSource = ds.Tables(0)
                gvNorms.DataBind()
            Else
                gvNorms.DataSource = Nothing
                gvNorms.DataBind()
            End If
        Catch ex As Exception
            Response.Write("Error loading data: " & ex.Message)
        End Try

    End Sub

End Class
