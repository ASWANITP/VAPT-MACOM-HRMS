Imports System.Data
Imports System.Data.OracleClient
Public Class add_vda
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As DataTable
    Dim val As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "<B><U>NEW DA</U></B>"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.subtitle = "<B><U>NEW DA</U></B>"
        Dim cs As String = "var cont_name;cont_name='" & Me.txt_preda.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        Me.txt_emp.Attributes.Add("onkeypress", "return isNumberKey(event)")
        If Session("access_id") = 33 Then
            Dim formaccess As DataTable = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=183 and emp_id=" & Session("user_id").ToString.Split("!")(0)).Tables(0)
            If formaccess.Rows(0)(0) = 0 Then
                'Dim script1 As New System.Text.StringBuilder
                'script1.Append("        alert('You are not Authorized');")
                'script1.Append("window.open('../home.aspx','_self');")
                'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.Page.GetType(), "alert", "alert('You are not Authorized');", True)
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "popupScript", "javascript:showalert();", True)
            End If
            If Not IsPostBack Then
                Dim dt As DataTable
                dt = oh.ExecuteDataSet("select value from da_index where to_dt is null and firm_id=" & Session("firm_id") & "").Tables(0)
                Me.txt_preda.Text = dt.Rows(0)(0)
                Me.lbl_msg.Visible = False
                val = 1
            End If
        Else
            Dim script1 As New System.Text.StringBuilder
            'script1.Append("        alert('You are not Authorized');")
            'script1.Append("window.open('../home.aspx','_self');")
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.Page.GetType(), "alert", "alert('You are not Authorized');", True)
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "popupScript", "javascript:showalert();", True)

        End If
    End Sub
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim dx As New DataTable
        If Me.txt_emp.Text = "" Then
            'Dim script1 As New System.Text.StringBuilder
            'script1.Append("        alert('Enter Employee Code');")
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.Page.GetType(), "alert", "alert('Enter Employee Code');", True)

        Else
            dx = oh.ExecuteDataSet("select count(*)from employee_master t where t.status_id=1 and t.emp_code=" & Me.txt_emp.Text & "").Tables(0)

            If dx.Rows(0)(0) = 1 Then

                If Me.ADD.Checked = False And Me.DELTE.Checked = False Then

                    'Dim script1 As New System.Text.StringBuilder
                    'script1.Append("        alert('Please select ADD/DELETE');")
                    'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

                    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.Page.GetType(), "alert", "alert('Please select ADD/DELETE');", True)
                    Me.txt_emp.Text = ""

                Else

                    Dim op(2) As OracleParameter
                    op(0) = New OracleParameter("emp_id", OracleType.Number, 7)
                    op(0).Value = CInt(Me.txt_emp.Text)

                    op(1) = New OracleParameter("type_id", OracleType.Number, 5)
                    If Me.ADD.Checked = True And Me.DELTE.Checked = False Then
                        op(1).Value = 1
                    End If

                    If Me.ADD.Checked = False And Me.DELTE.Checked = True Then
                        op(1).Value = 0
                    End If

                    op(2) = New OracleParameter("msg", OracleType.VarChar, 200)
                    op(2).Direction = ParameterDirection.Output


                    oh.ExecuteNonQuery("vda_on_off", op)

                    Dim mss As String
                    mss = op(2).Value.ToString()
                    If mss.Contains("total count") Then

                        'Dim cl_script1 As New System.Text.StringBuilder
                        'cl_script1.Append("         alert('SUCCESSFULLY CONFIRMED');")
                        'cl_script1.Append("         window.open('../home.aspx','_self');")
                        'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                        ScriptManager.RegisterClientScriptBlock(Me.Page, Me.Page.GetType(), "alert", "alert('SUCCESSFULLY CONFIRMED');", True)
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "popupScript", "javascript:showalert();", True)

                    Else
                        'Dim cl_script1 As New System.Text.StringBuilder
                        'cl_script1.Append("         alert('" + op(2).Value + "');")
                        'cl_script1.Append("         window.open('../home.aspx','_self');")
                        'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                        ScriptManager.RegisterClientScriptBlock(Me.Page, Me.Page.GetType(), "alert", "alert(' " + op(2).Value + " ');", True)
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "popupScript", "javascript:showalert();", True)

                    End If
                End If

            ElseIf dx.Rows(0)(0) = 0 Then
                'Dim script1 As New System.Text.StringBuilder
                'script1.Append("        alert('Employee Code Does Not Exists');")
                'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.Page.GetType(), "alert", "alert('Employee Code Does Not Exists');", True)

                Me.txt_emp.Text = ""
            End If
        End If
    End Sub

    Protected Sub btn_search_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dss, ds As New DataTable
        ds = oh.ExecuteDataSet("select count(*)from employee_master t where t.status_id=1 and t.emp_code=" & Me.txt_emp.Text & "").Tables(0)
        If ds.Rows(0)(0) = 1 Then
            dss = oh.ExecuteDataSet("select t.da_flag,p.payment_id from employee_master t join employ_promotion_dtl p on p.emp_code=t.emp_code and p.enter_dt in(select max(k.enter_dt) from employ_promotion_dtl k where k.emp_code=" & Me.txt_emp.Text & ")where t.emp_code=" & Me.txt_emp.Text & " ").Tables(0)
            If dss.Rows(0)(0) = "T" And dss.Rows(0)(1) = 8 Then
                Me.lbl_msg.Text = "CURRENTLY VDA ACTIVE"
                Me.lbl_msg.Visible = True
            ElseIf dss.Rows(0)(0) = "F" And dss.Rows(0)(1) = 14 Then
                Me.lbl_msg.Text = "CURRENTLY VDA NOT ACTIVE"
                Me.lbl_msg.Visible = True
            Else
                Me.lbl_msg.Text = "CURRENTLY VDA NOT ACTIVE.."
                Me.lbl_msg.Visible = True
            End If
        Else
            'Dim script1 As New System.Text.StringBuilder
            'script1.Append("        alert('Please Enter Valid Employee Code');")
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.Page.GetType(), "alert", "alert('Please Enter Valid Employee Code');", True)
            Me.txt_emp.Text = ""
        End If
    End Sub

    Protected Sub ADD_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.ADD.Checked = True Then
            Me.DELTE.Checked = False
            val = 1
        End If
        If Me.DELTE.Checked = True Then
            Me.ADD.Checked = False
            val = 0
        End If
    End Sub

    Protected Sub DELTE_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.ADD.Checked = True Then
            Me.DELTE.Checked = False
            val = 1
        End If
        If Me.DELTE.Checked = True Then
            Me.ADD.Checked = False
            val = 0
        End If
    End Sub
End Class
