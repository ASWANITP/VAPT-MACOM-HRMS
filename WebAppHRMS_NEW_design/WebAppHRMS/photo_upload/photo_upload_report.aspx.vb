Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class vipin_forms_photo_upload_report_178efdcf6260
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim crSections As Sections
    Dim report As New ReportDocument
    Dim UserAll(), BranchAll() As String
    Dim UserCode, BranchId As Integer
    Dim dt2, dt5 As DataTable
    Dim export As New IO.MemoryStream

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'dt2 = oh.ExecuteDataSet("select p.employee_code, e.emp_name, p.photo  from dms.photo_upload p, employee_master e where p.employee_code = e.emp_code    and p.status in (0) and p.employee_code = " & Me.Request.QueryString("fdt") & "").Tables(0)

        dt2 = oh.ExecuteDataSet("select p.emp_code, e.emp_name, p.photo   from dms.hrm_emp_ph_certi p, employee_master e  where p.emp_code = e.emp_code  and p.status in (0)  and p.emp_code = " & Me.Request.QueryString("fdt") & "").Tables(0)
        report.Load(Server.MapPath("photoCrystalReport.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("photo_upload").SetDataSource(dt2)
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.ReportSource = report
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

        report.Close()
        report.Dispose()
        GC.Collect()


    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

        Try

            Dim parcol(3) As OracleParameter

            parcol(0) = New OracleParameter("ecde", OracleType.Number, 50)
            parcol(0).Value = CInt(Me.Request.QueryString("fdt"))
            parcol(0).Direction = ParameterDirection.Input





            parcol(1) = New OracleParameter("verfby", OracleType.Number, 50)
            parcol(1).Value = Me.Request.QueryString("usr")
            parcol(1).Direction = ParameterDirection.Input

            parcol(2) = New OracleParameter("typeid", OracleType.Number, 50)
            parcol(2).Value = 1
            parcol(2).Direction = ParameterDirection.Input


            parcol(3) = New OracleParameter("msg", OracleType.VarChar, 100)
            parcol(3).Direction = ParameterDirection.Output



            oh.ExecuteNonQuery("photo_upload_new_proc", parcol)




            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & parcol(3).Value & "');")
            cl_script1.Append(" window.open('photo_upload_confirm.aspx','_self');")

            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            'Response.Redirect("photo_upload_confirm.aspx")
            'dd1()

        Catch ex As Exception

        End Try
    End Sub
    Sub dd1()
        Server.Transfer("photo_upload_confirm.aspx")

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try

            Dim parcol(3) As OracleParameter

            parcol(0) = New OracleParameter("ecde", OracleType.Number, 50)
            parcol(0).Value = CInt(Me.Request.QueryString("fdt"))
            parcol(0).Direction = ParameterDirection.Input





            parcol(1) = New OracleParameter("verfby", OracleType.Number, 50)
            parcol(1).Value = Me.Request.QueryString("usr")
            parcol(1).Direction = ParameterDirection.Input

            parcol(2) = New OracleParameter("typeid", OracleType.Number, 50)
            parcol(2).Value = 2

            parcol(3) = New OracleParameter("msg", OracleType.VarChar, 100)
            parcol(3).Direction = ParameterDirection.Output



            oh.ExecuteNonQuery("photo_upload_new_proc", parcol)




            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & parcol(3).Value & "');")
            cl_script1.Append(" window.open('photo_upload_confirm.aspx','_self');")

            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            'Response.Redirect("photo_upload_confirm.aspx")
            'dd1()

        Catch ex As Exception

        End Try


    End Sub
End Class
