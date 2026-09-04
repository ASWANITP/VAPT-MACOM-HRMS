Imports System.Data.OracleClient
Imports System.Data

Partial Class Service_Record_Form_adc19a5c7319
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim branch, ajuser As Integer
    Dim dt, dt3 As New DataTable
    Dim str As New System.Text.StringBuilder
    Dim x As Integer
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Response.Redirect("Service Record.aspx?emp=" & Me.DropDownList1.SelectedValue & "")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
 
        If Page.IsPostBack <> True Then
            '----------------------krishnadas--for mafarm reqid 9814
            branch = Me.Session("branch_id")
            ajuser = Me.Session("user_id").ToString.Split("!")(0)
            dt = oh.ExecuteDataSet("select * from form_accessibility where FORM_ID=851 and EMP_ID=" & ajuser & "").Tables(0)
            If dt.Rows.Count <= 0 Then
                str.Append("alert('You are not authorized...!');")
                str.Append(" window.open('../../Home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str.ToString, True)
            Else

                'dt3 = oh.ExecuteDataSet("select count(em.emp_code) from employee_master em where em.post_id in (198,173,71,1,10,197,73,195,378,308,350,371,69) and em.branch_id = '" & branch & "' and em.emp_code = ' " & ajuser & "'").Tables(0)
                'If dt3.Rows(0)(0) = 0 Then

                '    str.Append("alert('You are not authorized...!');")
                '    str.Append(" window.open('../Home.aspx','_self');")
                '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str.ToString, True)

                'Else

                If branch = 0 Then
                    dt = oh.ExecuteDataSet("select em.emp_code ||' --- ' || em.emp_name,em.emp_code as Employees,em.emp_code from Employee_Master em,employ_firm ef,branch_master bm where em.branch_id = bm.branch_id and em.status_id = 1 and em.emp_code = ef.emp_code and ef.firm_id = ' " & Session("firm_id") & " ' and em.emp_code > 9999 order by em.emp_code").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select em.emp_code ||' --- ' || em.emp_name,em.emp_code as Employees,em.emp_code from Employee_Master em,employ_firm ef,branch_master bm where em.branch_id = bm.branch_id  and bm.branch_id ='" & branch & "'    and em.status_id = 1 and em.emp_code = ef.emp_code and ef.firm_id = ' " & Session("firm_id") & " ' and em.emp_code > 9999 order by em.emp_code").Tables(0)

                End If
                Me.DropDownList1.DataSource = dt
                DropDownList1.DataTextField = dt.Columns(0).ColumnName
                DropDownList1.DataValueField = dt.Columns(1).ColumnName

                DropDownList1.DataBind()



            End If
        End If
    End Sub
End Class
