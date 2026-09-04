Imports System.Data
Imports System.Data.OracleClient

Partial Class Holiday_Register_Form_da9e27878725
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim branch As Integer



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        branch = Me.Session("branch_id").ToString.Split("!")(0)

        'dt = oh.ExecuteDataSet("select  em.emp_code ||'--'|| em.emp_name,em.emp_code,em.emp_name  from  employee_master em,  employ_firm ef,  branch_master bm  where  em.emp_code = ef.emp_code  and bm.branch_id = em.branch_id  and bm.branch_id = '" & branch & "'  and ef.firm_id =  '" & Session("firm_id") & "'").Tables(0)

        ' dt = oh.ExecuteDataSet("select em.emp_code || '--' || em.emp_name as Employees   from employee_master em, employ_firm ef, branch_master bm  where em.emp_code = ef.emp_code    and bm.branch_id = em.branch_id    and bm.branch_id = '" & Session("branch_id") & "'    and ef.firm_id = '" & Session("firm_id") & "'   order by em.emp_code").Tables(0)

        If Page.IsPostBack <> True Then
            If branch = 0 Then
                dt = oh.ExecuteDataSet("select em.emp_code || '--' || em.emp_name,  em.emp_code  as Employees,  em.emp_code    from employee_master em, employ_firm ef, branch_master bm   where em.emp_code = ef.emp_code     and bm.branch_id = em.branch_id and ef.firm_id = '" & Session("firm_id") & "' and em.status_id = 1   order by em.emp_code").Tables(0)

            Else
                dt = oh.ExecuteDataSet("select em.emp_code || '--' || em.emp_name,  em.emp_code  as Employees,  em.emp_code    from employee_master em, employ_firm ef, branch_master bm   where em.emp_code = ef.emp_code     and bm.branch_id = em.branch_id     and bm.branch_id = '" & branch & "'     and ef.firm_id = '" & Session("firm_id") & "' and em.status_id = 1   order by em.emp_code").Tables(0)
            End If


            Me.DropDownList1.DataSource = dt

            DropDownList1.DataValueField = dt.Columns(0).ColumnName
            DropDownList1.DataValueField = dt.Columns(1).ColumnName
            DropDownList1.DataBind()
        End If
 
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Server.Transfer("Holiday Register Crystal Report.aspx?aji=" & Me.DropDownList1.SelectedValue & "")

        'Server.Transfer("Holiday Register Crystal Report.aspx?aj=" & Me.DropDownList1.SelectedValue & "")
    End Sub
End Class
