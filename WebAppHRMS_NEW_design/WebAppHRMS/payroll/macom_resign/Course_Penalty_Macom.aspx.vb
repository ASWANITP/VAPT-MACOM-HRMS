Imports System.Data
Imports System.Data.OracleClient
Partial Class Payroll_macom_resign_Course_Penalty_Macom_75516bea3920
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dtj, ceo, depp, dt5, det, dat As New DataTable
    Dim sf() As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fid As Integer = Session("firm_id")
        If Not IsPostBack Then
            sf = Session("user_id").ToString.Split("!")
            Me.txt_emp.Text = sf(0)

            Dim dat As DataTable = oh.ExecuteDataSet("select count(t.emp_code) from TBL_HIGHER_EDN_DTLS_MACOM t where t.status=1 and t.agree_penality is null and  t.emp_code=" & sf(0) & "").Tables(0)
            If dat.Rows(0)(0) > 0 Then
                det = oh.ExecuteDataSet("select  e.emp_code,e.emp_name, dt.course_name, dt.course_duration, dt.amt_paid_company, dt.penalty_amt from employee_master e, TBL_HIGHER_EDN_DTLS_MACOM dt where e.emp_code =" & sf(0) & " and e.emp_code=dt.emp_code and dt.agree_penality is null").Tables(0)


                Me.txt_emp.Text = det.Rows(0)(0)
                Me.Txt_empname.Text = det.Rows(0)(1)

                Me.Txt_course.Text = det.Rows(0)(2)

                Me.Txt_durat.Text = det.Rows(0)(3)
                Me.Txt_fee.Text = det.Rows(0)(4)
                Me.Txt_amount.Text = det.Rows(0)(5)
            Else
                Dim cl_script1 As New System.Text.StringBuilder
                ''cl_script1.Append("        alert('Please confirm your COURSE PENALITY!!');")
                ' cl_script1.Append("        window.open('../resignation_enter.aspx','_self');")
                Response.Redirect("resignation_enter.aspx")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If
        End If
    End Sub

    Protected Sub b1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles b1.Click
        'Dim flag As Integer = 1
        'Dim dts1 As DataTable = oh.ExecuteDataSet("select query from hrm_report_master where firm_id=99 and query_id=160").Tables(0)
        'Dim strd() As String = dts1.Rows(0)(0).ToString.Split("$")
        'dt5 = oh.ExecuteDataSet(strd(1).Replace("mycode", Session("user_id").ToString.Split("!")(0))).Tables(0)
        'If (dt5.Rows(0)(0) = 0) Then
        '    dtj = oh.ExecuteDataSet(strd(2).Replace("mycode", Session("user_id").ToString.Split("!")(0))).Tables(0)
        'If Not IsPostBack Then
        sf = Session("user_id").ToString.Split("!")
        Me.txt_emp.Text = sf(0)
        'End If
        Dim dat As DataTable = oh.ExecuteDataSet("select * from TBL_HIGHER_EDN_DTLS_MACOM t where t.status=1 and t.agree_penality is null  and t.course_name ='" & Me.Txt_course.Text & "' and t.emp_code=" & sf(0) & "").Tables(0)
        If dat.Rows(0)(0) > 0 Then

            Dim query As String = ("UPDATE TBL_HIGHER_EDN_DTLS_MACOM el set el.agree_penality=1 where el.emp_code=" & sf(0) & " and el.status=1    and el.course_name ='" & Me.Txt_course.Text & "' and to_char(el.end_dt)<to_Char(sysdate)")
            oh.ExecuteNonQuery(query)
            Dim cl_script21 As New System.Text.StringBuilder(1, 500)
            cl_script21.Append("  alert('Successfully Entered');")

            'cl_script21.Append("        window.open('././newresign/resignation_enter.aspx','_self');")
            'Response.Redirect("../../../resignation_enter.aspx")
            Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)

            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script21.ToString, True)
            Exit Sub
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            ''cl_script1.Append("        alert('Please confirm your COURSE PENALITY!!');")
            ' cl_script1.Append("        window.open('../resignation_enter.aspx','_self');")
            ' cl_script1.Append("        window.open('././newresign/resignation_enter.aspx','_self');")
            ' Response.Redirect("./maben/resignation_enter.aspx.aspx")
            Response.Redirect("resignation_enter.aspx")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
        Exit Sub

        'Dim sq178 As String = "UPDATE TBL_HIGHER_EDN_DTLS el set el.agree_penality=1 where el.emp_code=" & sf(0) & " and el.status=1 and to_char(el.end_dt)<to_Char(sysdate)"
    End Sub
    'Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
    '    Dim cl_script21 As New System.Text.StringBuilder(1, 500)
    '    cl_script21.Append("window.open('circumab.aspx', '', '');")
    '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script21.ToString, True)
    'End Sub


    Protected Sub Cmd_Exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Response.Redirect("~/home.aspx")
    End Sub
End Class



