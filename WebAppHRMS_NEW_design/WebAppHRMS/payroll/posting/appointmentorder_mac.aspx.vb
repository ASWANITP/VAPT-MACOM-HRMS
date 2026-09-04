Imports System.Data
Imports System.Data.OracleClient
Partial Class Appointment_Order_appointmentorder_e89e90669853
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
            End If
        Else
            Response.Redirect("../../show_err.aspx")
        End If
    End Sub
    Protected Sub cmd_appletter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_appletter.Click
        dts1 = oh.ExecuteDataSet("select query from hrm_report_master where firm_id=99 and query_id=100").Tables(0)
        Dim str() As String = dts1.Rows(0)(0).ToString.Split("#")
        'Dim _filename As String = (System.Guid.NewGuid.ToString + ".doc")
        Dim _filename As String = ("Offer Letter-" + Me.cmb_code.SelectedValue + ".doc")
        Dim htmlRaw As String = Str(0)
        Dim sqls As String = Str(1).Replace("mycode", Me.cmb_code.SelectedValue)
        dts2 = oh.ExecuteDataSet(sqls).Tables(0)
        If dts2.Rows.Count > 0 Then
            htmlRaw = htmlRaw.Replace("mydate", dts2.Rows(0)(0))
            htmlRaw = htmlRaw.Replace("mysyntax", dts2.Rows(0)(1))
            htmlRaw = htmlRaw.Replace("myname", dts2.Rows(0)(2))
            htmlRaw = htmlRaw.Replace("myfasp", dts2.Rows(0)(3))
            htmlRaw = htmlRaw.Replace("myhouse", dts2.Rows(0)(4))
            htmlRaw = htmlRaw.Replace("mypo", dts2.Rows(0)(5))
            htmlRaw = htmlRaw.Replace("mydist", dts2.Rows(0)(6))
            htmlRaw = htmlRaw.Replace("myplace", dts2.Rows(0)(7))
            htmlRaw = htmlRaw.Replace("mydesig", dts2.Rows(0)(8))
            htmlRaw = htmlRaw.Replace("offerpost", dts2.Rows(0)(9))
            htmlRaw = htmlRaw.Replace("mytime", dts2.Rows(0)(10))
            htmlRaw = htmlRaw.Replace("myjoin", dts2.Rows(0)(11))
            htmlRaw = htmlRaw.Replace("mysecu", dts2.Rows(0)(12))
            htmlRaw = htmlRaw.Replace("depoword", dts2.Rows(0)(13))


            htmlRaw = htmlRaw.Replace("confirmby", dts2.Rows(0)(14))
            htmlRaw = htmlRaw.Replace("confirmpost", dts2.Rows(0)(15))
            htmlRaw = htmlRaw.Replace("mybasic", dts2.Rows(0)(16))
            htmlRaw = htmlRaw.Replace("myvda", dts2.Rows(0)(17))
            htmlRaw = htmlRaw.Replace("myepf", dts2.Rows(0)(18))
            htmlRaw = htmlRaw.Replace("myeesi", dts2.Rows(0)(19))
            htmlRaw = htmlRaw.Replace("mybonus", dts2.Rows(0)(20))
            htmlRaw = htmlRaw.Replace("myctc", dts2.Rows(0)(21))
            htmlRaw = htmlRaw.Replace("myyctc", dts2.Rows(0)(22))

            htmlRaw = htmlRaw.Replace("ctcword", dts2.Rows(0)(23))
            htmlRaw = htmlRaw.Replace("mycode", dts2.Rows(0)(24))
            htmlRaw = htmlRaw.Replace("mydept", dts2.Rows(0)(25))
            htmlRaw = htmlRaw.Replace("mybranch", dts2.Rows(0)(26))
            htmlRaw = htmlRaw.Replace("mybreakup", dts2.Rows(0)(27))

            htmlRaw = htmlRaw.Replace("myit", dts2.Rows(0)(28))
            htmlRaw = htmlRaw.Replace("myhra", dts2.Rows(0)(29))


            htmlRaw = htmlRaw.Replace("mytel", dts2.Rows(0)(30))
            htmlRaw = htmlRaw.Replace("myspaa", dts2.Rows(0)(31))
            htmlRaw = htmlRaw.Replace("myouts", dts2.Rows(0)(32))
            htmlRaw = htmlRaw.Replace("myfixta", dts2.Rows(0)(33))
            htmlRaw = htmlRaw.Replace("myoa", dts2.Rows(0)(34))
            htmlRaw = htmlRaw.Replace("myce", dts2.Rows(0)(35))
            htmlRaw = htmlRaw.Replace("mymr", dts2.Rows(0)(36))

            htmlRaw = htmlRaw.Replace("myveh", dts2.Rows(0)(37))
            htmlRaw = htmlRaw.Replace("mygrs_sal", dts2.Rows(0)(38))
            htmlRaw = htmlRaw.Replace("mytot_ded", dts2.Rows(0)(39))
            htmlRaw = htmlRaw.Replace("mynet_sal", dts2.Rows(0)(40))

            htmlRaw = htmlRaw.Replace("myybasic_pay", dts2.Rows(0)(41))
            htmlRaw = htmlRaw.Replace("myyvda", dts2.Rows(0)(42))
            htmlRaw = htmlRaw.Replace("myyveh", dts2.Rows(0)(43))
            htmlRaw = htmlRaw.Replace("myyhra", dts2.Rows(0)(44))
            htmlRaw = htmlRaw.Replace("myyspaa", dts2.Rows(0)(45))
            htmlRaw = htmlRaw.Replace("myyouts", dts2.Rows(0)(46))
            htmlRaw = htmlRaw.Replace("myytel", dts2.Rows(0)(47))
            htmlRaw = htmlRaw.Replace("myyfixta", dts2.Rows(0)(48))
            htmlRaw = htmlRaw.Replace("myyoa", dts2.Rows(0)(49))
            htmlRaw = htmlRaw.Replace("myyce", dts2.Rows(0)(50))
            htmlRaw = htmlRaw.Replace("myymr", dts2.Rows(0)(51))
            htmlRaw = htmlRaw.Replace("myyepf", dts2.Rows(0)(52))
            htmlRaw = htmlRaw.Replace("myyesi", dts2.Rows(0)(53))


            htmlRaw = htmlRaw.Replace("myybonus", dts2.Rows(0)(54))
            htmlRaw = htmlRaw.Replace("myygrs_sal", dts2.Rows(0)(55))
            htmlRaw = htmlRaw.Replace("myytot_ded", dts2.Rows(0)(56))
            htmlRaw = htmlRaw.Replace("myynet_sal", dts2.Rows(0)(57))

            htmlRaw = htmlRaw.Replace("myemployeepdf", dts2.Rows(0)(58))
            htmlRaw = htmlRaw.Replace("myyemployeepdf", dts2.Rows(0)(59))

            'htmlRaw = htmlRaw.Replace("myemployeeesi", dts2.Rows(0)(60))
            'htmlRaw = htmlRaw.Replace("myyemployeeesi", dts2.Rows(0)(61))














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
    End Sub
End Class
