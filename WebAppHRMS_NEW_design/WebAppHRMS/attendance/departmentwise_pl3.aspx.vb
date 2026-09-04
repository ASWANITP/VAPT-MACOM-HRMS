Imports System.Data
Imports System.Data.OracleClient

Partial Class departmentwise_pl3_departmentwise_pl3_eef0465d6360
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt1 As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "<U><B>DEPARTMENT WISE PL3</B></U>"
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.txt_fromdt.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)

        If Not IsPostBack Then
            Dim dt As DataTable
            dt = oh.ExecuteDataSet("select distinct dep_id,dep_name from department_mst d, employee_master e,employ_firm f where e.department_id=d.dep_id and e.status_id=1 and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " order by dep_name").Tables(0)
            Me.cmb_dpt.DataSource = dt
            Me.cmb_dpt.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_dpt.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_dpt.DataBind()
            
            dt1 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
            Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yyyy")
            Me.txt_fromdt.Text = Me.hdn_sysdate.Value
            Me.txt_todt.Text = Me.hdn_sysdate.Value

            Me.txt_fromdt.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_fromdt')")
            Me.txt_todt.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_todt')")
        End If
    End Sub
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If Me.txt_fromdt.Text = "" Or Me.txt_todt.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select Date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            If CDate(Me.txt_fromdt.Text) > CDate(Me.txt_todt.Text) Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('To Date Not Valid');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                If CDate(Me.txt_fromdt.Text) > CDate(Date.Now) Or CDate(Me.txt_todt.Text) > CDate(Date.Now) Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('Future Date Not Allowed');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Else
                    Me.Server.Transfer("rpt_departmentwise_pl3.aspx?dep_id=" & Me.cmb_dpt.SelectedValue & "&dep_name=" & Me.cmb_dpt.SelectedItem.Text & "&fr_dt=" & Me.txt_fromdt.Text & "&to_dt=" & Me.txt_todt.Text)
                End If
            End If
        End If
    End Sub
End Class