Imports system
'Imports System.IO
Imports System.Data
Imports System.Data.OracleClient


Partial Class DepatmtHeadChnge_919afd7b5596
    Inherits System.Web.UI.Page

    Dim dt, dt1, dt2, dts1, dts2, dtpri, dtrs, ddt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    'Dim dts1, dts2, dtpri, dtrs, Data As New DataTable
    Dim UserAll(), UserCode, sql As String
    Dim str_tkn As New StringBuilder
    Dim cat, sf() As Integer
    'Dim usr() As String
    Dim usr() As String
    Dim dts, dth, dd1, dta As New DataTable
    Dim str, strs, frm As String
    Dim sfs() As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        frm = Session("firm_id")




        Dim s As String = "select s.dep_id from DEPARTMENT_MST s where s.emp_code=" & User(0) & ""

        dta = oh.ExecuteDataSet("select s.department_id from employee_master s where s.emp_code=" & User(0) & " ").Tables(0)

        If Not IsPostBack Then



            dd1 = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=1002 and s.emp_id=" & dta.Rows(0)(0) & "").Tables(0)
            If dd1.Rows(0)(0) = 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

                Me.Server.Transfer("~/show_err.aspx")
                'Else
                '    dts = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=855 and emp_id=" & UserAll(0) & "").Tables(0)
                '    If dts.Rows(0)(0) = 0 Then
                '        Dim cl_script0 As New System.Text.StringBuilder
                '        cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
                '        cl_script0.Append("window.open('../home.aspx','_self');")
                '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                '    End If
            End If

            '    usr = Me.Session("user_id").ToString.Split("!")


            Dim yy As String


            'yy = "SELECT -1 AS emp_code, '----SELECT DEPARTMENT----' AS emp_name FROM dual UNION ALL SELECT m.emp_code,m.emp_code||' -- '|| m.emp_name FROM employee_master m, pancard p WHERE m.firm_id = 8 and m.emp_code = p.empcode and p.status = 0 ORDER BY emp_name ASC"

            yy = "SELECT -1 AS dep_id, '----SELECT DEPARTMENT----' AS dep_name FROM DUAL UNION SELECT d.dep_id, d.dep_name FROM DEPARTMENT_MST d WHERE d.firm_id = " & frm & " AND d.status = 1 UNION SELECT t.dptmtid, t.dptmtname FROM TBL_DPTMT_HEADCHNGE t WHERE t.dptmtid IN (SELECT a.department_id FROM mactech.employee_master a WHERE a.firm_id = " & frm & " AND a.status_id = 1) ORDER BY dep_name ASC"

            dt = oh.ExecuteDataSet(yy).Tables(0)
            If dt.Rows.Count > 0 Then
                Me.DropDownList1.DataSource = dt
                Me.DropDownList1.DataValueField = dt.Columns(0).ColumnName
                Me.DropDownList1.DataTextField = dt.Columns(1).ColumnName
                Me.dep_id.Text = dt.Columns(0).ColumnName
                'Me.DropDownList1.DataTextField = dt.Columns(1).ColumnName
                Me.DropDownList1.DataBind()
            End If


            Dim zz As String


            zz = "SELECT -2 AS emp_code, '--SELECT EMPLOYEE CODE & NAME--' AS emp_name FROM dual UNION ALL SELECT m.emp_code,m.emp_code||' -- '|| m.emp_name FROM employee_master m, employ_firm f where f.firm_id= " & frm & " and m.emp_code=f.emp_code and m.status_id=1 order by emp_name asc"

            dt = oh.ExecuteDataSet(zz).Tables(0)
            If dt.Rows.Count > 0 Then
                Me.DropDownList2.DataSource = dt
                Me.DropDownList2.DataValueField = dt.Columns(0).ColumnName
                Me.DropDownList2.DataTextField = dt.Columns(1).ColumnName

                'Me.DropDownList1.DataTextField = dt.Columns(1).ColumnName
                Me.DropDownList2.DataBind()
            End If
        End If
    End Sub


 

    Protected Sub btnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnext.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged

        Dim xx As String

        'xx = "SELECT dm.dep_head,(select em.emp_name  from employee_master em where em.emp_code=  dm.dep_head  )||'('||dm.dep_head||')' FROM department_mst dm where dm.dep_id ='" & DropDownList1.SelectedValue & "' and dm.firm_id = 8"

        xx = "SELECT dm.dep_head,(select em.emp_name  from employee_master em where em.emp_code=  dm.dep_head  )||'('||dm.dep_head||')' FROM department_mst dm where dm.dep_id ='" & DropDownList1.SelectedValue & "'"

        ddt = oh.ExecuteDataSet(xx).Tables(0)
        If ddt.Rows.Count > 0 Then
            Me.txt_previousdptmt.Text = ddt.Rows(0)(1)


        End If

    End Sub

    Protected Sub btnconfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnconfirm.Click
        Dim script1 As New System.Text.StringBuilder()


        usr = Me.Session("user_id").ToString.Split("!")
        'Dim emp As Integer = CInt(usr(0).ToString())


        If (Me.DropDownList1.SelectedItem.Value = -1) Then
            script1.Append("        alert('Please Select Department..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If


        If (Me.DropDownList2.SelectedItem.Value = -2) Then
            script1.Append("        alert('Please Select Department Head..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If

        ' Database operations

        Try

        
            Dim dep(4) As OracleParameter

            dep(0) = New OracleParameter("dptmtid", OracleType.Number)
            dep(0).Direction = ParameterDirection.Input
            dep(0).Value = DropDownList1.SelectedItem.Value


            dep(1) = New OracleParameter("dptmthead", OracleType.Number)
            dep(1).Direction = ParameterDirection.Input
            dep(1).Value = Me.txt_previousdptmt.Text.Split("(")(1).Replace(")", "0")


            dep(2) = New OracleParameter("emp_code", OracleType.Number)
            dep(2).Direction = ParameterDirection.Input
            dep(2).Value = usr(0)



            dep(3) = New OracleParameter("newdeptmthead", OracleType.Number)
            dep(3).Direction = ParameterDirection.Input
            dep(3).Value = DropDownList2.SelectedItem.Value


            dep(4) = New OracleParameter("msg", OracleType.VarChar, 100)
            dep(4).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("dptmt_confrm", dep)
            Dim message As String = dep(4).Value

            script1.Append("alert('" & message & "');")
            script1.Append("window.open('DepatmtHeadChnge.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client_script", script1.ToString(), True)


        Catch ex As Exception

        End Try
        

    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList2.SelectedIndexChanged

        '    'Dim zz As String
        '    'zz = "SELECT -1 AS emp_code, '----SELECT EMPLOYEE CODE & NAME----' AS emp_name FROM dual UNION ALL SELECT m.emp_code,m.emp_code||' -- '|| m.emp_name FROM employee_master m, employ_firm f where f.firm_id=8 and m.emp_code=f.emp_code and m.status_id=1 order by emp_name asc"

        '    'dt = oh.ExecuteDataSet(zz).Tables(0)
        '    'If dt.Rows.Count > 0 Then
        '    '    Me.DropDownList2.DataSource = dt
        '    '    Me.DropDownList2.DataValueField = dt.Columns(0).ColumnName
        '    '    Me.DropDownList2.DataTextField = dt.Columns(1).ColumnName

        '    '    'Me.DropDownList1.DataTextField = dt.Columns(1).ColumnName
        '    '    Me.DropDownList2.DataBind()
        '    'End If
    End Sub
End Class
