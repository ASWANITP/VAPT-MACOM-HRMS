Imports System.Data
Imports System.Data.OracleClient
Partial Class Payroll_Appointmnt_Mafarm_917b8fda7921
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt6, dt7, dt8, dt9, dt10, dt11, dt12, dts1, dts2, dtq As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txt_dt.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        If Session("access_id") = 33 Or Session("access_id") = 60 Then
            If Not IsPostBack Then
                Dim dt As New DataTable
                dt = oh.ExecuteDataSet("select e.emp_code||'-'||e.emp_name, e.emp_code from employee_master e,employ_firm f where e.emp_code=f.emp_code and f.firm_id= " & Session("firm_id") & " and e.status_id=1 and e.emp_code>9999 order by emp_code").Tables(0)
                Me.cmb_code.DataSource = dt
                Me.cmb_code.DataTextField = dt.Columns(0).ColumnName
                Me.cmb_code.DataValueField = dt.Columns(1).ColumnName
                Me.cmb_code.DataBind()
                Me.txt_dt.Text = Format(Now.Date, "dd/MMM/yyyy")
                Me.Txtjoin.Text = Format(Now.Date, "dd/MMM/yyyy")
            End If
        Else
            Response.Redirect("../../show_err.aspx")
        End If
    End Sub
    Protected Sub cmd_appletter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_appletter.Click
        dts1 = oh.ExecuteDataSet("select query from hrm_report_master where firm_id=99 and query_id=111").Tables(0)
        Dim str() As String = dts1.Rows(0)(0).ToString.Split("#")
        'Dim _filename As String = (System.Guid.NewGuid.ToString + ".doc")
        Dim _filename As String = ("Offer Letter-" + Me.cmb_code.SelectedValue + ".doc")
        Dim htmlRaw As String = str(0)
        Dim sqls As String = str(1).Replace("mycode", Me.cmb_code.SelectedValue)
        dts2 = oh.ExecuteDataSet(sqls).Tables(0)

        Dim d1 As Date = Me.Txtjoin.Text
        If d1 < Format(Now.Date, "dd/MMM/yyyy") Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Past Date Not Allowed');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else

            If dts2.Rows.Count > 0 Then
                htmlRaw = htmlRaw.Replace("mydate", Format(Now.Date, "dd/MMM/yyyy"))
                htmlRaw = htmlRaw.Replace("mydts", Me.Txtjoin.Text)
                htmlRaw = htmlRaw.Replace("myname", dts2.Rows(0)(1))
                htmlRaw = htmlRaw.Replace("myfasp", dts2.Rows(0)(2))
                htmlRaw = htmlRaw.Replace("myhouse", dts2.Rows(0)(3))
                htmlRaw = htmlRaw.Replace("mypo", dts2.Rows(0)(4))
                htmlRaw = htmlRaw.Replace("mydist", dts2.Rows(0)(5))
                htmlRaw = htmlRaw.Replace("mystate", dts2.Rows(0)(6))
                htmlRaw = htmlRaw.Replace("mydesig", dts2.Rows(0)(7))
                htmlRaw = htmlRaw.Replace("offerpost", dts2.Rows(0)(8))
                htmlRaw = htmlRaw.Replace("mytime", dts2.Rows(0)(9))
                htmlRaw = htmlRaw.Replace("myjoin", dts2.Rows(0)(10))
                htmlRaw = htmlRaw.Replace("mysecdep", dts2.Rows(0)(11))
                htmlRaw = htmlRaw.Replace("secdeprs", dts2.Rows(0)(12))
                htmlRaw = htmlRaw.Replace("mybasic", dts2.Rows(0)(15))
                htmlRaw = htmlRaw.Replace("myvda", dts2.Rows(0)(14))
                htmlRaw = htmlRaw.Replace("basicrs", dts2.Rows(0)(16))
                htmlRaw = htmlRaw.Replace("mygrade", dts2.Rows(0)(17))
                htmlRaw = htmlRaw.Replace("mydep", dts2.Rows(0)(18))
                htmlRaw = htmlRaw.Replace("myinr", dts2.Rows(0)(19))
                htmlRaw = htmlRaw.Replace("inrrs", dts2.Rows(0)(20))
                htmlRaw = htmlRaw.Replace("name", dts2.Rows(0)(21))
                Dim strHTML As StringBuilder = New StringBuilder
                strHTML.Append(("<html " + (" xmlns:o='urn:schemas-microsoft-com:office:office'" + (" xmlns:w='urn:schemas-microsoft-com:office:word'" + (" xmlns='http://www.w3.org/TR/REC-html40'>")))))
                strHTML.Append(("<xml><w:WordDocument>" + (" <w:View>Print</w:View>" + (" " + (" <w:DoNotOptimizeForBrowser/>" + (" </w:WordDocument>" + " </xml>"))))))
                strHTML.Append(("<body><div class='page-settings'>" + (htmlRaw + "</div></body></html>")))
                Response.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml")
                Response.AppendHeader("Content-disposition", ("attachment;filename=" + (_filename + "")))
                Response.Write(strHTML.ToString)
            Else
                Dim script1 As New System.Text.StringBuilder
                script1.Append("alert('Incomplete Data found for this Employee');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            End If
        End If
    End Sub
End Class

