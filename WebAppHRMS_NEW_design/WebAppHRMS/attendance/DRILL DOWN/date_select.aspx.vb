Imports System.Data
Imports System.Data.OracleClient
Partial Class pledge_MJ_report_mj_date_select_3a47b73e9042
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str_tkn As New StringBuilder
    Dim fdt, tdt, pr As String
    Dim pf As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim dts As New DataTable
        Dim usr() As String = Me.Session("user_id").ToString.Split("!")
        'Dim optio As Integer = Request.QueryString.Get("opt_id")
        'Me.HiddenField1.Value = optio
        If Not IsPostBack Then

            '----------------form aceesibility 1293---------------------------

            dts = oh.ExecuteDataSet("select count(f.form_id) from form_accessibility f where f.form_id=1293 and f.emp_id=" & usr(0) & " ").Tables(0)
            If CInt(dts.Rows(0)(0)) = 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('You Are Not Authorized!');")
                cl_script0.Append("window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

            Else

                dt = oh.ExecuteDataSet("select to_char(to_date(sysdate),'dd/mon/yyyy') from dual").Tables(0)
                Me.txt_from.Text = dt.Rows(0)(0)
                Me.txt_to.Text = dt.Rows(0)(0)
            End If

            Dim script_val As String
            script_val = "var header;" & "header='" & Me.txt_from.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
            Me.txt_from.Attributes.Add("onchange", "return checkDt()")
            Me.txt_to.Attributes.Add("onchange", "return checkDt()")
        End If
    End Sub

    Protected Sub btn_generate_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_generate.ServerClick
        'if(!document.getElementById (cont_name[0]+"txt_per").value)
        '////{
        '////    document.getElementById (cont_name[0]+"txt_per").value="";
        '////    document.getElementById (cont_name[0]+"txt_per").focus;
        '////    alert("ENTER PERIOD");
        '////    return false;
        '////}
        '// var fdt=document.getElementById (cont_name[0]+"txt_from").value;
        '// var tdt=document.getElementById (cont_name[0]+"txt_to").value;
        '// var pr=document.getElementById (cont_name[0]+"txt_per").value;
        '//  window.open ("leave_repo.aspx?FromDt="+fdt+"&ToDt="+tdt+"&per="+pr+"","_self")
        If Me.txt_per.Text = "" Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Period Not Found!');")
            cl_script0.Append("window.open('../../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        Else
            fdt = Me.txt_from.Text.ToString()
            tdt = Me.txt_to.Text.ToString()
            pr = Me.txt_per.Text.ToString()
            Server.Transfer("leave_repo.aspx?FromDt=" + fdt + "&ToDt=" + tdt + "&per=" + pr + "")

        End If

    End Sub

    Protected Sub btn_exit_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exit.ServerClick
        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("window.open('../../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
    End Sub
End Class
