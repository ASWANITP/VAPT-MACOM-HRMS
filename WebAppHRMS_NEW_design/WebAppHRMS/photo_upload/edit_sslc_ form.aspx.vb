Imports System.Data
Imports System.Data.OracleClient
Partial Class vipin_forms_edit_sslc_form_5e6904ba1486
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt3, dt4, dt5, dt6, dt9, dt12, dt13 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim empid As Integer
    Dim dat As DateTime

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtDate.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        ' dt5 = oh.ExecuteDataSet("select e.emp_code, e.emp_name, p.post_name  from employee_master e, post_mst p where e.post_id = p.post_id  and e.post_id=242    and e.emp_code=" & UserId & "").Tables(0)
        dt5 = oh.ExecuteDataSet("select count(t.emp_id) from form_accessibility t where t.form_id=565 and t.emp_id= " & UserId & " ").Tables(0)
        If Not IsPostBack Then
            If dt5.Rows(0)(0) > 0 Then

                dt = oh.ExecuteDataSet("select 0 as emp_code, '------select---------' emp_code  from dual   union  select x.emp_code,x.m from (select distinct e.emp_code,  e.emp_code || '-' || e.emp_name || '-' || e.join_dt as m  from employee_master e  where e.join_dt >= to_date(sysdate - 2)  and e.post_id not in (89)  and e.department_id not in (154)  and e.emp_code not in (select p.emp_code  from macdms.hrm_emp_ph_certi p  where p.status in (1, 0))  order by e.emp_code)x ").Tables(0)

                Me.DropDownList1.DataSource = dt
                Me.DropDownList1.DataTextField = dt.Columns(1).ColumnName
                Me.DropDownList1.DataValueField = dt.Columns(0).ColumnName
                Me.DropDownList1.DataBind()

            Else

                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('You Are Not Authorised!!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

            End If
        End If
        dt13 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)

        dat = dt13.Rows(0)(0)

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged

        'Dim cnt() As String = Me.DropDownList1.SelectedItem.ToString.Split("-")

        dt1 = oh.ExecuteDataSet("select  ap.sslc_no,ap.birth_date  from  appln_interview_dtl a, appln_pers_dtl ap where ap.appln_no = a.appln_no      and a.emp_code = " & Me.DropDownList1.SelectedValue & " group by  ap.sslc_no,ap.birth_date").Tables(0)

        If IsDBNull(dt1.Rows(0)(0)) Or IsDBNull(dt1.Rows(0)(1)) Then

            dt3 = oh.ExecuteDataSet("select distinct  ap.sslc_no,ap.birth_date  from employee_master a, employ_personal_dtl ap where a.emp_code = ap.emp_code   and a.emp_code = " & Me.DropDownList1.SelectedValue & " group by  ap.sslc_no,ap.birth_date").Tables(0)

            If dt3.Rows.Count > 0 Then
                'Me.TextBox3.Visible = True
                'Me.TextBox4.Visible = True
                If IsDBNull(dt3.Rows(0)(0)) Or IsDBNull(dt3.Rows(0)(1)) Then
                    Me.TextBox1.Text = "NOT UPDATED"
                    Me.TextBox2.Text = "NOT UPDATED"
                Else
                    Me.TextBox1.Text = dt3.Rows(0)(0)
                    Me.TextBox2.Text = dt3.Rows(0)(1)
                End If
                



            End If


        Else
            'Me.TextBox3.Visible = False
            'Me.TextBox4.Visible = False

            Me.TextBox1.Text = dt1.Rows(0)(0)
            Me.TextBox2.Text = dt1.Rows(0)(1)


        End If


    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Me.txtDate.Text > dat Then
            Dim script2 As New System.Text.StringBuilder
            script2.Append("alert('Future date not allowed');")
            'script1.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script2.ToString, True)
        ElseIf (Me.txtDate.Text = "" Or Me.txtsslc.Text = "") Then

            Dim script2 As New System.Text.StringBuilder
            script2.Append("alert('Please fill all entries');")
            'script1.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script2.ToString, True)
        Else

            Dim parm_col(3) As OracleParameter

            parm_col(0) = New OracleParameter("ecode1", OracleType.Number, 10)

            parm_col(0).Value = Me.DropDownList1.SelectedValue

            parm_col(1) = New OracleParameter("sslc1", OracleType.VarChar, 15)

            parm_col(1).Value = Me.txtsslc.Text

            parm_col(2) = New OracleParameter("dtb1", OracleType.DateTime)

            parm_col(2).Value = Me.txtDate.Text

5:          parm_col(3) = New OracleParameter("msg1", OracleType.VarChar, 50)
            parm_col(3).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_update_ssc", parm_col)

            Dim script1 As New System.Text.StringBuilder
            script1.Append("alert('" & parm_col(3).Value & "');")
            script1.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If

    End Sub

    Protected Sub TextBox4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Server.Transfer("../home.aspx")
    End Sub
End Class
