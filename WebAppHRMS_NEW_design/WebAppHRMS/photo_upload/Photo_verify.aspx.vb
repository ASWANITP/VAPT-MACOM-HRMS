Imports System.Data
Imports System.Data.OracleClient
Partial Class Photo_verify_2d59f3e31679
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim image1() As Byte
    Dim image2() As Byte
    Dim dt, dt1, dt2, dt3, dt4, dt5, dt6, dt7 As New DataTable
    Dim Usr() As String
    Dim s, sst As String
    Dim UsrCode, brn, nom, i As Integer
    ''MODIFIED
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            dd()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        Dim fdt As String = Me.DropDownList1.SelectedItem.Value
        Dim usr As Integer = UserId
        Response.Redirect("photo_upload_report1.aspx?fdt=" & fdt & "&usr=" & UserId & "")
    End Sub
    Sub dd()

        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        Dim firm As Integer
        firm = oh.ExecuteDataSet("select f.firm_id from employ_firm f where f.emp_code=" & UserId & "").Tables(0).Rows(0)(0)
        brn = Session("branch_id")
        dt2 = oh.ExecuteDataSet("select count(d.dep_id)  from department_mst d where d.dep_head > 0   and d.dep_head =" & UserId & " ").Tables(0)
        If dt2.Rows(0)(0) > 0 Then
            dt1 = oh.ExecuteDataSet("select 0 as emp_code, '------select---------' emp_code   from dual union all select distinct e.emp_code, e.emp_code || '~' || e.emp_name  from hrm_emp_upload r, employee_master e, employ_firm f  where e.emp_code = r.emp_code  and e.emp_code in  (select pu.emp_code from hrm_emp_upload pu where pu.status_id in (0))   and e.emp_code = f.emp_code    and e.department_id in (select d.dep_id from department_mst d where d.dep_head=" & UserId & ")   and f.firm_id =" & firm & " ").Tables(0)
            Me.DropDownList1.DataSource = dt1
            Me.DropDownList1.DataTextField = dt1.Columns(1).ColumnName
            Me.DropDownList1.DataValueField = dt1.Columns(0).ColumnName
            Me.DropDownList1.DataBind()
        Else
            Dim cl_script As New System.Text.StringBuilder
            cl_script.Append("         alert('You Are Not Authorised!!!!');")
            cl_script.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
        End If
    End Sub
End Class
