Imports System.Data
Imports System.Data.OracleClient

Partial Class Maternity_Leave_Report_Maternity_Leave_Form_75798ab17342
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt3 As New DataTable
    Dim str As New System.Text.StringBuilder
    Dim ajusr As Integer

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
       
        Me.Server.Transfer("Maternity_Leave_Report(1).aspx?fdt=" & Me.TextBox1.Text & "&tdt=" & Me.TextBox2.Text)

    End Sub

     
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack <> True Then
            ajusr = Me.Session("user_id").ToString.Split("!")(0)

            dt3 = oh.ExecuteDataSet("select count(x.cnt) from (select count(em.emp_code) as cnt,em.emp_code from employee_master em, post_mst pm where em.post_id in (195) and em.post_id=pm.post_id group by em.emp_code union  select count(em.emp_code) as cnt,em.emp_code from employee_master em, post_mst pm, department_mst dm where em.post_id in ( 85) and dm.dep_id = 70 and em.department_id=dm.dep_id and em.post_id=pm.post_id  group by em.emp_code) x where x.emp_code='" & ajusr & "'").Tables(0)
            '  If dt3.Rows(0)(0) Is Nothing Then
            If dt3.Rows(0)(0) = 0 Then

                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('You are not authorized');")
                cl_script1.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)
            End If
        End If



    End Sub
End Class
