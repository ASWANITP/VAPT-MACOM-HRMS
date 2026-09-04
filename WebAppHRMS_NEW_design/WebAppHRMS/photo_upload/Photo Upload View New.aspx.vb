Imports System.Data
Imports System.Data.OracleClient

Partial Class Photo_upload_Photo_Upload_View_New_b8b6f42e4250
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim Usr() As String
    Dim UsrCode, brn, stat As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim user1 As Integer = Request.QueryString("user1")
        'Dim user1 As String = session("user_id").split("!")
        ' Dim user1() As String = user(0)
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        Dim id As Integer = 543

        dt2 = oh.ExecuteDataSet("select count(*) from form_accessibility f where f.form_id= " & id & " and f.emp_id= " & UserId & " ").Tables(0)
        ' dt1 = oh.ExecuteDataSet("select 0 as emp_code, '------select---------' emp_code  from dual  union all  select distinct d.emp_code, d.emp_code || '-------' || e.emp_name from dms.hrm_emp_ph_certi d ,employee_master e where d.emp_code = e.emp_code  and e.emp_code in (select pu.emp_code  from dms.hrm_emp_ph_certi pu  where pu.status in(0))  and e.branch_id = " & brn & " ").Tables(0)
        If dt2.Rows(0)(0) = 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised!!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script0.ToString, True)

        Else
            If Not ispostback Then
                'dt1 = oh.ExecuteDataSet("select distinct p.emp_code, p.emp_code || '-------' || e.emp_name  from dms.hrm_emp_ph_certi p, employee_master e  where p.status = 1  and p.emp_code = e.emp_code  and e.status_id in(1) order by p.emp_code").Tables(0)

                'dt1 = oh.ExecuteDataSet("select -1 as branch_id,'-----SELECT-----' from dual union all select branch_id,branch_id||'~~~~'||branch_name from branch_master where branch_id>=0 order by branch_id").Tables(0)

                'Me.DropDownList1.DataSource = dt1
                'Me.DropDownList1.DataTextField = dt1.Columns(1).ColumnName
                'Me.DropDownList1.DataValueField = dt1.Columns(0).ColumnName
                'Me.DropDownList1.DataBind()
                 
            End If
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)

        Dim fdt As String = Me.DropDownList1.SelectedItem.Value
        Dim usr As Integer = UserId

        'If DropDownList1.SelectedIndex = 0 Then
        '    MsgBox("Please select the value..@")
        'ElseIf DropDownList1.SelectedIndex = 1 Then
        '    Response.Redirect("Photo_Upload_Report_New.aspx")
        'ElseIf DropDownList1.SelectedIndex = 2 Then
        '    Response.Redirect("Photo_Upload_Report_New(2).aspx")
        'End If
       
        If Me.DropDownList1.SelectedValue = "Select" Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Please Select Status...');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script0.ToString, True)
        Else
            'Response.Redirect("Photo_Upload_Report_New.aspx?fdt=" & fdt & "&usr=" & UserId & "")
            Response.Redirect("Photo_Upload_Report_New.aspx?fdt=" & fdt & " ")
        End If
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        'dt1 = oh.ExecuteDataSet("select -1 as branch_id,'-----SELECT-----' from dual union all select branch_id,branch_id||'~~~~'||branch_name from branch_master where branch_id>=0 order by branch_id").Tables(0)

        'Me.DropDownList1.DataSource = dt1
        'Me.DropDownList1.DataTextField = dt1.Columns(1).ColumnName
        'Me.DropDownList1.DataValueField = dt1.Columns(0).ColumnName
        'Me.DropDownList1.DataBind()
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("../home.aspx")
    End Sub
End Class
