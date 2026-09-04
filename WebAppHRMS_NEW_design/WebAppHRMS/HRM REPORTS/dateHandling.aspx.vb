
Partial Class HRM_Reports_dateHandling_a333e88a7124
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "SELECT DATE"
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txt_from.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Me.txt_from.Attributes.Add("onblur", "isValidDate('txt_from')")
        Me.txt_to.Attributes.Add("onblur", "isValidDate('txt_to')")
        If Not IsPostBack Then
            Me.txt_from.Value = Format(Date.Today, "dd/MM/yyyy")
            Me.txt_to.Value = Format(Date.Today, "dd/MM/yyyy")
            Me.hdn_option_id.Value = CInt(Request.QueryString("opt_id"))

            'Dim FromStr() As String = (Request.QueryString("from_dt")).ToString.Split("/")
            'Dim FromDt As String = Format(CDate(FromStr(1) + "/" + FromStr(0) + "/" + FromStr(2)), "dd-MMM-yyyy")
            'Dim ToStr() As String = (Request.QueryString("to_dt")).ToString.Split("/")
            'Dim ToDt As String = Format(CDate(ToStr(1) + "/" + ToStr(0) + "/" + ToStr(2)), "dd-MMM-yyyy")
        End If
    End Sub
End Class
