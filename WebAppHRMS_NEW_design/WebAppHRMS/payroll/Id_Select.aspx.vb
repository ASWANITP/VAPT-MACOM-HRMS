Imports System.Data
Imports System.Data.OracleClient
Partial Class ins_date_sel_08faea999934
    Inherits System.Web.UI.Page
    Dim dt, au As New DataTable
    Dim oh As New helper.oracle.OracleHelper
    Dim usr() As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.cmb_firm.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        usr = Me.Session("user_id").ToString.Split("!")
        
        If Not IsPostBack Then
            CType(Me.Master, WebAppHRMS.edp).Subtitle = "ManPower Requisition Report"

            au = oh.ExecuteDataSet("select count(t.emp_id)from form_accessibility t where t.form_id=1295 and t.emp_id=" & usr(0)).Tables(0)
            If CInt(au.Rows(0)(0)) = 0 Then

                Dim cl_01 As New System.Text.StringBuilder
                cl_01.Append("         alert('You Are Not Authorised..!');")
                cl_01.Append(" window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_01.ToString, True)

            Else
                dt = oh.ExecuteDataSet("select -1,'---Select---' from dual union select t.req_id,to_char(t.req_id) from MAN_REQ_DTLS t order by 1").Tables(0)
                Me.cmb_firm.DataSource = dt
                Me.cmb_firm.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_firm.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_firm.DataBind()

            End If
        End If
    End Sub

    Protected Sub Button1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.ServerClick
        Dim ind = Me.cmb_firm.SelectedValue

        Response.Redirect("req_report.aspx?IDV=" + ind + "")

    End Sub
End Class
