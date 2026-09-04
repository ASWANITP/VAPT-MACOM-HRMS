Imports System.Data.OracleClient
Imports System.IO
Imports System.Data

Partial Class Service_Record_Form_adc19a5c6704
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim branch, ajuser As Integer
    Dim dt, dt3 As New DataTable
    Dim str As New System.Text.StringBuilder
    Dim x As Integer
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim DirPath As String
        DirPath = Server.MapPath("~/Payroll/Posting/ServiceRecord")
        Dim di As DirectoryInfo = New DirectoryInfo(DirPath)
        If di.Exists Then
            Directory.Delete(Server.MapPath("~/Payroll/Posting/ServiceRecord"), True)
        End If
        Server.Transfer("Copy of Service Record.aspx?emp1=" & Me.txt_emp1.Text & "&emp2=" & Me.txt_emp2.Text & "")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
 
        If Page.IsPostBack <> True Then

            branch = Me.Session("branch_id").ToString.Split("!")(0)
            ajuser = Me.Session("user_id").ToString.Split("!")(0)
            dt3 = oh.ExecuteDataSet("select count(em.emp_code) from employee_master em where em.post_id in (198,173,1,71,10,197,73,195,378,308,350,371,69) and em.branch_id = '" & branch & "' and em.emp_code = ' " & ajuser & "'").Tables(0)
            If dt3.Rows(0)(0) = 0 Then

                str.Append("alert('You are not authorized...!');")
                str.Append(" window.open('../Home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str.ToString, True)

            Else


                'dt = oh.ExecuteDataSet("select em.emp_code ||' --- ' || em.emp_name,em.emp_code as Employees,em.emp_code from Employee_Master em,employ_firm ef,branch_master bm where em.branch_id = bm.branch_id  and bm.branch_id ='" & branch & "'    and em.status_id = 1 and em.emp_code = ef.emp_code and ef.firm_id = ' " & Session("firm_id") & " ' and em.emp_code > 9999 order by em.emp_code ").Tables(0)
                'Me.DropDownList1.DataSource = dt
                'DropDownList1.DataValueField = dt.Columns(0).ColumnName
                'DropDownList1.datavaluefield = dt.columns(1).columnname

                'DropDownList1.DataBind()



            End If
        End If
    End Sub
End Class
