Imports System.Data
Imports System.Data.OracleClient
Partial Class Payroll_Block_details1_61d9775c1801
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt9, nai As New DataTable
    Dim dr As DataRow
    Dim str, str1, shi As String
    Dim BlAleTable As New Table
    Dim LoginUser(), usercode As String
    Dim Logger, BlockCount, i As Integer
    Dim colors As String = "#fff7ef"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load





        LoginUser = Me.Session("user_id").ToString.Split("!")

        usercode = LoginUser(0)
        If Not IsPostBack Then
            Dim script As String = "window.onload = function() { openPopup(); };"
            ClientScript.RegisterStartupScript(Me.GetType(), "PopupScript", script, True)
        End If








        'If Not IsPostBack Then
        '    'Button1.Enabled = false
        '    'Me.cmb_reason.Enabled = False
        '    Dim script1 As New System.Text.StringBuilder
        '    script1.Append("        window.open('alertmessage.aspx', 'WinC', 'width=500px,height=380px,toolbar=no,location=no,directories=no,status=no,menubar=no, scrollbars=no,resizable=no,copyhistory=no');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)


        'End If

        Dim dt1 As String
        dt1 = Request.QueryString("dt").ToString()
        Dim dt3 As String
        dt3 = Request.QueryString("emp").ToString()
        LoginUser = Me.Session("user_id").ToString.Split("!")
        Me.Logger = LoginUser(0)

        Dim dr As DataRow
        dt2 = oh.ExecuteDataSet("select query from hrm_report_master where firm_id=99 and query_id=206").Tables(0)

        str = "select bm.block_reason as Reason from employee_block_dtl eb, block_master_1 bm where eb.block_id = bm.block_id and eb.block_status = 1 and eb.emp_code = " & dt3 & " and trunc(eb.block_date)='" + dt1 + "'  UNION ALL select bm.block_reason as Reason from employee_block_dtl_his eb, block_master_1 bm where eb.block_id = bm.block_id and eb.block_status = 1 and eb.emp_code = " & dt3 & "and trunc(eb.block_date)='" + dt1 + "'  order by Reason"
        ' str = "select eb.block_date,eb.emp_code,bm.block_id,bm.block_reason as Reason from employee_block_dtl eb, block_master_1 bm where eb.block_id = bm.block_id and eb.block_status = 1 and eb.emp_code = " & Me.Logger & " and trunc(eb.block_date) = '" + dt1 + "' UNION ALL select eb.block_date,eb.emp_code,bm.block_id,bm.block_reason as Reason from employee_block_dtl_his eb, block_master_1 bm where eb.block_id = bm.block_id and eb.block_status = 1 and eb.emp_code = " & Me.Logger & "and trunc(eb.block_date) = '" + dt1 + "' order by Reason"
        dt = oh.ExecuteDataSet(str).Tables(0)

        shi = "select distinct t.emp_name from employee_master t, employee_block_dtl_his b where t.emp_code=b.emp_code and b.emp_code= " & dt3 & " union all select distinct t.emp_name from employee_master t, employee_block_dtl b where t.emp_code=b.emp_code and b.emp_code= " & dt3 & ""
        nai = oh.ExecuteDataSet(shi).Tables(0)
        Dim nam As String = nai.Rows(0)(0).ToString()

        Dim strarray() As String = dt2.Rows(0)(0).ToString.Split("$")

        Dim htmlRaw As String = strarray(0)
        Dim htmlRaw2 As String = strarray(1)
        Dim htmlOk As String = strarray(2)


        Dim strHTML As StringBuilder = New StringBuilder
        strHTML.Append(htmlRaw)
        strHTML.Append("<tr> <td>" & dt1 & "</td>  <td>" & dt3 & "</td><td>" & nam & "</td> </tr>")


        strHTML.Append(htmlRaw2)
        Dim i As Integer = 0

        Dim htmlRaw1 As String = ""
        For Each dr In dt.Rows
            i = i + 1
            strHTML.Append("<tr> <td>" & i & "</td>  <td>" & dr(0) & "</td>  </tr>")
        Next
        strHTML.Append(htmlOk)

        Response.Write(strHTML.ToString)


    End Sub



End Class
