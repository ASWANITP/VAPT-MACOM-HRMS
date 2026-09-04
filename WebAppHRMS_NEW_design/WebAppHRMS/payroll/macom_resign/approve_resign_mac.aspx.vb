Imports System.Data
Imports System.Data.OracleClient
Partial Class new_approve_resign_7506ce352852
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dtr, tdtt, lastdt1, lastdt, dt, dt1 As DataTable
    Dim alls() As String
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim usr() As String
        usr = Me.Session("user_id").ToString.Split("!")
        If Me.Txt_rdt.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Please enter Relieving date ..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            Dim parameter(4) As OracleParameter
            parameter(0) = New OracleParameter("code", OracleType.Number, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = Me.lbl_code.Text
            parameter(1) = New OracleParameter("reldt", OracleType.DateTime, 150)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = Me.Txt_rdt.Text
            parameter(2) = New OracleParameter("usr", OracleType.Number, 150)
            parameter(2).Direction = ParameterDirection.Input
            parameter(2).Value = usr(0)
            parameter(3) = New OracleParameter("ubr", OracleType.Number, 150)
            parameter(3).Direction = ParameterDirection.Input
            parameter(3).Value = Session("branch_id")
            parameter(4) = New OracleParameter("msg", OracleType.Number, 150)
            parameter(4).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("M_RESIGNING_SAN_MAC", parameter)
            If parameter(4).Value = 1 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('Sanctioned successfully!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If
            If parameter(4).Value = 2 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('No Such application Exist for Approval!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If
            If parameter(4).Value = 3 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('Error ...Contact IT Department...!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If
            dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=121 and t.firm_id=99").Tables(0)
            alls = dt.Rows(0)(0).ToString.Split("$")
            dtr = oh.ExecuteDataSet(alls(32)).Tables(0)
            Me.cmb_emp.DataSource = dtr
            Me.cmb_emp.DataTextField = dtr.Columns(0).ColumnName
            Me.cmb_emp.DataValueField = dtr.Columns(1).ColumnName
            Me.cmb_emp.DataBind()
            Me.Txt_rdt.Text = ""
            Me.Txt_rea.Text = ""
            Me.Txt_rsdt.Text = ""
            Me.lbl_name.Text = ""
            Me.lbl_code.Text = ""
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim usr() As String
            Dim sql As String
            dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=121 and t.firm_id=99").Tables(0)
            alls = dt.Rows(0)(0).ToString.Split("$")
            usr = Me.Session("user_id").ToString.Split("!")
            dt1 = oh.ExecuteDataSet(alls(33).Replace("mycode", usr(0))).Tables(0)
            If Session("branch_id") = 0 Then
                If (dt1.Rows(0)(0) = 444) Then
                    dtr = oh.ExecuteDataSet(alls(34)).Tables(0)
                    Me.cmb_emp.DataSource = dtr
                    Me.cmb_emp.DataTextField = dtr.Columns(0).ColumnName
                    Me.cmb_emp.DataValueField = dtr.Columns(1).ColumnName
                    Me.cmb_emp.DataBind()
                    If dtr.Rows.Count > 0 Then
                        lastdt = oh.ExecuteDataSet(alls(35).Replace("mycode", Me.cmb_emp.SelectedValue)).Tables(0)
                        lastdt1 = oh.ExecuteDataSet(alls(36)).Tables(0)
                        If lastdt.Rows(0)(0) > lastdt1.Rows(0)(0) Then
                            tdtt = oh.ExecuteDataSet(alls(37).Replace("mycode", Me.cmb_emp.SelectedValue)).Tables(0)
                            'Txt_rdt.Text = tdtt.Rows(0)(0)
                        Else
                            tdtt = oh.ExecuteDataSet(alls(38)).Tables(0)
                            'Txt_rdt.Text = tdtt.Rows(0)(0)
                        End If
                        Dim dt11 As DataTable = oh.ExecuteDataSet(alls(39).Replace("mycode", Me.cmb_emp.SelectedValue)).Tables(0)
                        Dim dt21 As DataTable = oh.ExecuteDataSet(alls(40).Replace("mycode", Me.cmb_emp.SelectedValue)).Tables(0)
                        Me.lbl_code.Text = dt11.Rows(0)(0)
                        Me.lbl_name.Text = dt11.Rows(0)(1)
                        Me.Txt_rsdt.Text = Format(CDate(dt21.Rows(0)(0)), "dd/MMM/yyyy")
                        If IsDBNull(dt21.Rows(0)(1)) Then
                            Me.Txt_rea.Text = ""
                        Else
                            Me.Txt_rea.Text = dt21.Rows(0)(1)
                        End If
                    Else
                        Dim cl_script11 As New System.Text.StringBuilder
                        cl_script11.Append("        alert('No Employees Found...!!');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
                    End If
                Else
                    ' Server.Transfer("../../show_err.aspx")
                    'Response.Redirect("../../show_err.aspx")
                    Dim cl_script0 As New System.Text.StringBuilder
                    cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
                    cl_script0.Append("window.open('../../home.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

                End If
            End If
        End If
    End Sub

    Protected Sub cmb_emp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_emp.SelectedIndexChanged
        dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=121 and t.firm_id=99").Tables(0)
        alls = dt.Rows(0)(0).ToString.Split("$")
        If Me.cmb_emp.SelectedValue <> "" Then
            Dim dt1 As DataTable = oh.ExecuteDataSet(alls(41).Replace("mycode", Me.cmb_emp.SelectedValue)).Tables(0)
            Dim dt2 As DataTable = oh.ExecuteDataSet(alls(42).Replace("mycode", Me.cmb_emp.SelectedValue)).Tables(0)
            Me.lbl_code.Text = dt1.Rows(0)(0)
            Me.lbl_name.Text = dt1.Rows(0)(1)
            Me.Txt_rsdt.Text = Format(CDate(dt2.Rows(0)(0)), "dd/MMM/yyyy")
            If IsDBNull(dt2.Rows(0)(1)) Then
                Me.Txt_rea.Text = ""
            Else
                Me.Txt_rea.Text = dt2.Rows(0)(1)
            End If
        Else
            Dim cl_script11 As New System.Text.StringBuilder
            cl_script11.Append("        alert('No Employees Found...!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
        End If
    End Sub

    Protected Sub Txt_rdt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_rdt.TextChanged
        'dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=121 and t.firm_id=99").Tables(0)
        'alls = dt.Rows(0)(0).ToString.Split("$")
        'Dim dt2 As DataTable = oh.ExecuteDataSet(alls(42).Replace("mycode", Me.cmb_emp.SelectedValue)).Tables(0)
        'If Format(CDate(Me.Txt_rdt.Text), "dd/MMM/yyyy") > Format(CDate(dt2.Rows(0)(0)), "dd/MMM/yyyy") Then
        '    Me.Txt_rdt.Text = ""
        '    Me.lbl1.Text = "Relieving date must be less or Equal to Resign Date"
        '    Dim cl_script11 As New System.Text.StringBuilder
        '    cl_script11.Append("        alert('Relieving date must be less or Equal to Resign Date...!!');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
        'Else
        '    Me.lbl1.Text = " "
        'End If
    End Sub

    Protected Sub cmd_att_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_att.ServerClick
        dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=121 and t.firm_id=99").Tables(0)
        alls = dt.Rows(0)(0).ToString.Split("$")
        Dim dt6 As DataTable = oh.ExecuteDataSet(alls(43).Replace("mycode", Me.cmb_emp.SelectedValue)).Tables(0)
        If dt6.Rows(0)(0) = 0 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('No Resignation Letter Attached');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Verify Resignation Letter');")
            cl_script1.Append("window.open('resign_attach.aspx?empid=" & Me.cmb_emp.SelectedValue & "');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
    End Sub
End Class
