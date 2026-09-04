Imports System.Data
Imports System.Data.OracleClient
Partial Class vipin_forms_photo_report_view_14d1b1ef3831
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim frdt, todt As String
    Dim dt, dt1, dt2, dt3 As New DataTable



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click




        Dim fdt As String = Me.drpdwn_employee.SelectedItem.Value




        Response.Redirect("photoviewcrystal.aspx?fdt=" & fdt & "")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim User() As String = Session("user_id").ToString.Split("!")
        'Dim User1 As Integer = User(0)
        Dim user1 As Integer = Request.QueryString("user1")
        frdt = Request.QueryString.Get("frdt")
        todt = Request.QueryString.Get("todt")
        Dim id As Integer = 543

        dt1 = oh.ExecuteDataSet("select count(*) from form_accessibility f where f.form_id= " & id & " and f.emp_id= " & User1 & " ").Tables(0)

        If dt1.Rows(0)(0) = 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised!!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script0.ToString, True)

        Else
            If Not IsPostBack Then




                'dt = oh.ExecuteDataSet("select count(*) from employee_master where emp_code = " & UserId & " and status_id = 1 and post_id in (1,10,198) and branch_id = " & brn & "").Tables(0)

                'If dt.Rows(0)(0) > 0 Then
                Dim str As String = "select distinct p.emp_code, p.emp_code || '-------' || e.emp_name  from dms.hrm_emp_ph_certi p, employee_master e  where p.status = 1  and to_date(e.JOIN_DT) between to_date(" & frdt & ") and to_date(" & todt & ") and p.emp_code = e.emp_code  and e.status_id in(1) order by p.emp_code"
                'dt1 = oh.ExecuteDataSet("select distinct p.emp_code, p.emp_code || '-------' || e.emp_name  from dms.hrm_emp_ph_certi p, employee_master e  where p.status = 1  and to_date(e.JOIN_DT) between to_date(" & frdt & ") and to_date(" & todt & ") and p.emp_code = e.emp_code  and e.status_id in(1) order by p.emp_code").Tables(0)
                dt1 = oh.ExecuteDataSet(str).Tables(0)
                Me.drpdwn_employee.DataSource = dt1
                Me.drpdwn_employee.DataTextField = dt1.Columns(1).ColumnName
                Me.drpdwn_employee.DataValueField = dt1.Columns(0).ColumnName
                Me.drpdwn_employee.DataBind()
            End If
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Server.Transfer("home.aspx")

    End Sub
End Class
