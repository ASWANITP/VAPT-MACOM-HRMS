Imports System.Data
Imports System.Data.OracleClient
Partial Class vipin_forms_photo_upload_confirm_11f27b001778
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim image1() As Byte
    Dim image2() As Byte
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim Usr() As String
    Dim UsrCode, brn As Integer



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim User() As String = Session("user_id").ToString.Split("!")
        'Dim UserId As Integer = User(0)


        'brn = Session("branch_id")

        If Not IsPostBack Then


            'status---->photo_upload
            '0--->uploaded
            '1--->verified
            '2--->rejected
            dd()




        End If


            

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)

        Dim fdt As String = Me.DropDownList1.SelectedItem.Value
        Dim usr As Integer = UserId



        Response.Redirect("photo_upload_report.aspx?fdt=" & fdt & "&usr=" & UserId & "")
    End Sub
    Sub dd()

        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)


        brn = Session("branch_id")

        If (brn <> 0) Then

            dt = oh.ExecuteDataSet("select count(*) from employee_master where emp_code = " & UserId & " and status_id = 1 and post_id in (1,10,198,350,261,262,308) and branch_id = " & brn & "").Tables(0)

            If dt.Rows(0)(0) > 0 Then
                'dt1 = oh.ExecuteDataSet("select 0 as emp_code, '------select---------' emp_code  from dual union all select distinct d.employee_code, d.employee_code || '-------' || e.emp_name  from macdms.photo_upload d, employee_master e where d.employee_code = e.emp_code and e.emp_code  in       (select pu.employee_code from macdms.photo_upload pu where pu.status in (0))  and e.branch_id = " & brn & " ").Tables(0)
                dt1 = oh.ExecuteDataSet("select 0 as emp_code, '------select---------' emp_code  from dual  union all  select distinct d.emp_code, d.emp_code || '-------' || e.emp_name from macdms.hrm_emp_ph_certi d ,employee_master e where d.emp_code = e.emp_code  and e.emp_code in (select pu.emp_code  from macdms.hrm_emp_ph_certi pu  where pu.status in(0))  and e.branch_id = " & brn & " ").Tables(0)

                Me.DropDownList1.DataSource = dt1
                Me.DropDownList1.DataTextField = dt1.Columns(1).ColumnName
                Me.DropDownList1.DataValueField = dt1.Columns(0).ColumnName
                Me.DropDownList1.DataBind()
            End If

        ElseIf (brn = 0) Then

            'dt2 = oh.ExecuteDataSet("select count(e.emp_code)  from department_major d, employee_master e where d.head_id > 0   and d.head_id = e.emp_code   and e.emp_code=" & UserId & "").Tables(0)
            dt2 = oh.ExecuteDataSet("select distinct d.dep_head  from department_mst d where d.dep_head > 0   and d.dep_head = " & UserId & "").Tables(0)
            If dt2.Rows(0)(0) > 0 Then

                'dt3 = oh.ExecuteDataSet("select 0 as emp_code, '------select---------' emp_code  from dual union all select distinct e.emp_code, e.emp_code || '~' || e.emp_name  from photo_upload r, employee_master e where e.emp_code = r.employee_code  and e.emp_code in       (select pu.employee_code from photo_upload pu where pu.status in (0)) and  e.department_id in (select dp.dep_id                             from department_major d, department_mst dp                            where dp.major_dep_id = d.department_id                              and d.head_id = " & UserId & ")").Tables(0)
                dt3 = oh.ExecuteDataSet("select 0 as emp_code, '------select---------' emp_code  from dual  union all  select distinct e.emp_code, e.emp_code || '~' || e.emp_name  from macdms.hrm_emp_ph_certi r, employee_master e  where e.emp_code = r.emp_code  and e.emp_code in (select pu.emp_code  from macdms.hrm_emp_ph_certi pu  where pu.status in (0))  and e.department_id in  (select t.dep_id  from department_mst t  where t.dep_head = " & UserId & ")").Tables(0)


                Me.DropDownList1.DataSource = dt3
                Me.DropDownList1.DataTextField = dt3.Columns(1).ColumnName
                Me.DropDownList1.DataValueField = dt3.Columns(0).ColumnName
                Me.DropDownList1.DataBind()

            Else


                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('You Are Not Authorised!!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script0.ToString, True)

            End If
        End If


    End Sub
End Class
