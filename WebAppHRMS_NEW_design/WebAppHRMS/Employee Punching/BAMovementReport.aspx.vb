Imports System.Data
Imports system.data.oracleclient
Partial Class Employee_Punching_BAMovementReport_1a34b2427851
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim fir As Integer
    Dim firm As String
    Dim sql As String
    Dim sql2 As String
    Dim fmid As Integer
    Dim dt, ddt, dta, dd1, dt1 As DataTable
    Dim dt2 As DataTable
    Dim str_tkn As New System.Text.StringBuilder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '' ''Session("firm_id") = 8
        fir = Session("firm_id")
        firm = Session("firm_name")
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        If Not IsPostBack Then
            'If fir = 31 Then
            '    sql = "select to_char(-1) empid , '---------Select All----------' as emp_Name   from dual union all select to_char(t.paid_ba_id),to_char(t.paid_ba_id) || ' - '|| t.p_agent_name  from HOSPITAL.MCHIT_PAID_BA_MASTER t"
            'Else
            '    sql = "select to_char(-1) empid, '---------Select All----------' as emp_Name from dual union all select to_char(t.paid_ba_id),to_char(t.paid_ba_id) || ' - ' || t.p_agent_name from macil.MCHIT_PAID_BA_MASTER t"
            'End If

            If fir = 8 Then
                sql = "SELECT -1 AS emp_code, '----SELECT EMPLOYEE CODE & NAME----' AS emp_name FROM dual UNION ALL SELECT m.emp_code, m.emp_code || ' -- ' || m.emp_name AS emp_name FROM employee_master m WHERE m.firm_id = 8 AND m.status_id = 1 AND m.post_id = 554 UNION ALL SELECT m.emp_code, m.emp_code || ' -- ' || m.emp_name AS emp_name FROM TBLBAMVMNTRPT t JOIN employee_master m ON t.empcode = m.emp_code WHERE m.firm_id = 8 AND m.status_id = 1 ORDER BY emp_name ASC"
            Else
                sql = "SELECT -1 AS emp_code, '----SELECT EMPLOYEE CODE & NAME----' AS emp_name FROM dual UNION ALL SELECT m.emp_code, m.emp_code || ' -- ' || m.emp_name AS emp_name FROM employee_master m WHERE m.firm_id = 8 AND m.status_id = 1 AND m.post_id = 554 UNION ALL SELECT m.emp_code, m.emp_code || ' -- ' || m.emp_name AS emp_name FROM TBLBAMVMNTRPT t JOIN employee_master m ON t.empcode = m.emp_code WHERE m.firm_id = 8 AND m.status_id = 1 ORDER BY emp_name ASC"
            End If

            dt = oh.ExecuteDataSet(sql).Tables(0)
            Me.dropemp.DataSource = dt
            Me.dropemp.DataTextField = dt.Columns(1).ColumnName
            Me.dropemp.DataValueField = dt.Columns(0).ColumnName
            Me.dropemp.DataBind()
        End If
        ' Me.dropemp.Enabled = False
        Me.TextBox2.Focus()



        Dim s As String = "select s.post_id from employee_master s where s.emp_code=" & user(0) & " "
        dta = oh.ExecuteDataSet("select s.post_id from employee_master s where s.emp_code=" & user(0) & "").Tables(0)

      


        dd1 = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=1006 and s.emp_id=" & dta.Rows(0)(0) & "").Tables(0)
        If dd1.Rows(0)(0) = 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

            'Me.Server.Transfer("~/show_err.aspx")
            'Else
            '    dts = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=855 and emp_id=" & UserAll(0) & "").Tables(0)
            '    If dts.Rows(0)(0) = 0 Then
            '        Dim cl_script0 As New System.Text.StringBuilder
            '        cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
            '        cl_script0.Append("window.open('../home.aspx','_self');")
            '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            '    End If
        End If








    End Sub
  

    
    Protected Sub btnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnext.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub btncnfrm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncnfrm.Click



        fir = Session("firm_id")
        'If fir = 31 Then
        '    dt1 = oh.ExecuteDataSet("select e.firm_id from hospital.MCHIT_PAID_BA_MASTER e where  e.paid_ba_id='" & Me.dropemp.Text & "'").Tables(0)
        'End If
        'If fir = 6 Then
        '    dt1 = oh.ExecuteDataSet("select e.firm_id from macil.MCHIT_PAID_BA_MASTER e where  e.paid_ba_id='" & Me.dropemp.Text & "'").Tables(0)
        'End If
        'If dt1.Rows.Count <= 0 Then
        '    str_tkn.Append("         alert('Invalid Employee Code...!');")
        '    str_tkn.Append(" window.open('../Home.aspx','_self');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        '    Exit Sub
        'Else
        '    fmid = dt1.Rows(0)(0)
        '    If fmid <> fir Then
        '        str_tkn.Append("         alert('Invalid Employee Code...!');")
        '        str_tkn.Append(" window.open('../Home.aspx','_self');")
        '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        '        Exit Sub
        '    End If
        'End If

        'If Trim(dropemp.Text) = "" Then
        '    Dim cl_script1 As New System.Text.StringBuilder
        '    cl_script1.Append("         alert('Please Enter Emp Code');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        'Else
        If TextBox2.Text = "" Or TextBox3.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select Date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else

            If CDate(TextBox2.Text) > CDate(TextBox3.Text) Then
                Dim cl_script1 As New System.Text.StringBuilder
                Me.TextBox2.Text = ""
                Me.TextBox3.Text = ""
                cl_script1.Append("         alert('From Date Is Not Valid');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else


                If Me.dropemp.SelectedItem.Value = -1 Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('Please select Employee Code');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)


                Else






                    If CDate(TextBox3.Text) > CDate(Date.Now) Or CDate(TextBox2.Text) > CDate(Date.Now) Then
                        Dim cl_script1 As New System.Text.StringBuilder
                        Me.TextBox2.Text = ""
                        Me.TextBox3.Text = ""
                        cl_script1.Append("         alert('Future Date Not Allowed');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Else
                        '--------------- ReqID 8592 starts------------------------------
                        Server.Transfer("BA_Myreport.aspx?&fdt=" & Me.TextBox2.Text & "&tdt=" & Me.TextBox3.Text & "&emp=" & Me.dropemp.SelectedValue)


                    End If
                End If
        End If
        End If
    End Sub

    Protected Sub dropemp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dropemp.SelectedIndexChanged
        'Dim zz As String

        'zz = Me.dropemp.SelectedItem.Value

        'zz = "select r.empcode from TBLBAMVMNTRPT r "

        'ddt = oh.ExecuteDataSet(zz).Tables(0)

    End Sub
End Class