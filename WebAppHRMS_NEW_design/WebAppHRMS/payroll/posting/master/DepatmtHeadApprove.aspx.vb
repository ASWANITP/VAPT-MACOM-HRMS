Imports system
'Imports System.IO
Imports System.Data
Imports System.Data.OracleClient


Partial Class DepatmtHeadApprove_a908a8d93399
    Inherits System.Web.UI.Page

    Dim dt, dt1, dt2, dts1, dts2, dtpri, dtrs, ddt, dtx As New DataTable
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




        Dim s As String = "select s.post_id from employee_master s where s.emp_code=" & User(0) & " "
        dta = oh.ExecuteDataSet("select s.post_id from employee_master s where s.emp_code=" & User(0) & "").Tables(0)

        If Not IsPostBack Then



            dd1 = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=1001 and s.emp_id=" & dta.Rows(0)(0) & "").Tables(0)
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





            'yy = "SELECT -1 AS emp_code, '----SELECT DEPARTMENT----' AS emp_name FROM dual UNION ALL SELECT m.emp_code,m.emp_code||' -- '|| m.emp_name FROM employee_master m, pancard p WHERE m.firm_id = 8 and m.emp_code = p.empcode and p.status = 0 ORDER BY emp_name ASC"

            'yy = "select -1 as dep_id, '----SELECT DEPARTMENT----' AS dep_name FROM DUAL UNION SELECT d.dep_id, d.dep_name from DEPARTMENT_MST d, TBLDPTMTCONFIRM p where d.dep_head=p.dep_head and p.status = 0 order by dep_name asc"
            yy = "select -1 as dep_id, '----SELECT DEPARTMENT----' AS dep_name
                    FROM DUAL
                    UNION
                    SELECT d.dep_id, d.dep_name
                    from DEPARTMENT_MST d, TBLDPTMTCONFIRM p
                    where d.dep_id = p.dep_id
                    and p.status = 0
                    order by dep_name asc"

            dt = oh.ExecuteDataSet(yy).Tables(0)
            If dt.Rows.Count > 0 Then
                Me.DropDownList1.DataSource = dt
                Me.DropDownList1.DataValueField = dt.Columns(0).ColumnName
                Me.DropDownList1.DataTextField = dt.Columns(1).ColumnName
                'Me.dep_id.Text = dt.Columns(0).ColumnName
                'Me.DropDownList1.DataTextField = dt.Columns(1).ColumnName
                Me.DropDownList1.DataBind()
            End If









          




        End If



















    End Sub


  

    Protected Sub btnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnext.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged

        Dim xx As String

        'xx = "SELECT dm.dep_head,(select em.emp_name  from employee_master em where em.emp_code=  dm.dep_head)||'('||dm.dep_head||')' FROM department_mst dm where dm.dep_id ='" & DropDownList1.SelectedValue & "' and dm.firm_id = 8"

        xx = "SELECT t.dep_head, (select em.emp_name from employee_master em where em.emp_code = dm.dep_head) || '(' || dm.dep_head || ')' FROM department_mst dm,TBLDPTMTCONFIRM t where t.status=0 and dm.dep_id = '" & DropDownList1.SelectedValue & "' and dm.dep_id=t.dep_id"

        ddt = oh.ExecuteDataSet(xx).Tables(0)
        If ddt.Rows.Count > 0 Then
            Me.txt_previousdptmt.Text = ddt.Rows(0)(1)


        End If



        Dim aa As String

        aa = "select d.newdep_head, (select em.emp_name from employee_master em where em.emp_code= d.newdep_head)||'('||d.newdep_head||')' from TBLDPTMTCONFIRM d, department_mst m where d.status=0 and m.dep_id ='" & DropDownList1.SelectedValue & "' and d.dep_id=m.dep_id"


        dtx = oh.ExecuteDataSet(aa).Tables(0)

        If dtx.Rows.Count > 0 Then
            Me.txt_newdptmthead.Text = dtx.Rows(0)(1)


        End If

    End Sub

    'Protected Sub btnconfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnconfirm.Click
    

    'End Sub

    'Protected Sub DropDownList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList2.SelectedIndexChanged



    
    'End Sub

    Protected Sub btnapprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnapprove.Click

        Dim script1 As New System.Text.StringBuilder


        If (Me.DropDownList1.SelectedItem.Value = -1) Then
            script1.Append("        alert('Please Select Department..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If




        usr = Me.Session("user_id").ToString.Split("!")
        Dim emp As Integer = CInt(usr(0).ToString())

        Try

        

            Dim dptapprv(7) As OracleParameter
            dptapprv(0) = New OracleParameter("dptmtid", OracleType.Number)
            dptapprv(0).Direction = ParameterDirection.Input

            dptapprv(0).Value = DropDownList1.SelectedItem.Value



            dptapprv(1) = New OracleParameter("dptmthead", OracleType.Number)
            dptapprv(1).Direction = ParameterDirection.Input
            dptapprv(1).Value = Me.txt_previousdptmt.Text.Split("(")(1).Replace(")", "0")




            dptapprv(2) = New OracleParameter("newdeptmthead", OracleType.Number)
            dptapprv(2).Direction = ParameterDirection.Input
            dptapprv(2).Value = Me.txt_newdptmthead.Text.Split("(")(1).Replace(")", "")





            dptapprv(3) = New OracleParameter("apprvrempcod", OracleType.Number)
            dptapprv(3).Direction = ParameterDirection.Input
            dptapprv(3).Value = emp

            dptapprv(4) = New OracleParameter("rejectrempcode", OracleType.Number)
            dptapprv(4).Direction = ParameterDirection.Input
            dptapprv(4).Value = emp


            dptapprv(5) = New OracleParameter("emp_code", OracleType.Number)
            dptapprv(5).Direction = ParameterDirection.Input
            dptapprv(5).Value = emp


            dptapprv(6) = New OracleParameter("flag", OracleType.Number)
            dptapprv(6).Direction = ParameterDirection.Input
            dptapprv(6).Value = 1

            dptapprv(7) = New OracleParameter("msg", OracleType.VarChar, 1000)
            dptapprv(7).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("dptmthead_approvereject", dptapprv)


            Dim message As String
            message = dptapprv(7).Value

            'Dim message As String = dptapprv(2).Value


            script1.Append("alert('" & message & "');")
            script1.Append("window.open('DepatmtHeadApprove.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        Catch ex As Exception

        End Try




    End Sub

    Protected Sub btnrjct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnrjct.Click
        Dim script1 As New System.Text.StringBuilder


        If (Me.DropDownList1.SelectedItem.Value = -1) Then
            script1.Append("        alert('Please Select Department..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If




        usr = Me.Session("user_id").ToString.Split("!")
        Dim emp As Integer = CInt(usr(0).ToString())




        Dim dptrjct(7) As OracleParameter
        dptrjct(0) = New OracleParameter("dptmtid", OracleType.Number)
        dptrjct(0).Direction = ParameterDirection.Input
        'pan(0).Value = empCode
        'pan(0).Value = CInt(Me.txt_ecode.Text)
        dptrjct(0).Value = DropDownList1.SelectedItem.Value




        dptrjct(1) = New OracleParameter("dptmthead", OracleType.VarChar, 100)
        dptrjct(1).Direction = ParameterDirection.Input
        dptrjct(1).Value = Me.txt_previousdptmt.Text.Split("(")(1).Replace(")", "")




        dptrjct(2) = New OracleParameter("newdeptmthead", OracleType.Number)
        dptrjct(2).Direction = ParameterDirection.Input
        dptrjct(2).Value = Me.txt_newdptmthead.Text.Split("(")(1).Replace(")", "")



        dptrjct(3) = New OracleParameter("rejectrempcode", OracleType.Number)
        dptrjct(3).Direction = ParameterDirection.Input
        dptrjct(3).Value = emp


        dptrjct(4) = New OracleParameter("apprvrempcod", OracleType.Number)
        dptrjct(4).Direction = ParameterDirection.Input
        dptrjct(4).Value = emp



        dptrjct(5) = New OracleParameter("emp_code", OracleType.Number)
        dptrjct(5).Direction = ParameterDirection.Input
        dptrjct(5).Value = emp

        dptrjct(6) = New OracleParameter("flag", OracleType.Number)
        dptrjct(6).Direction = ParameterDirection.Input

        dptrjct(6).Value = 2


        dptrjct(7) = New OracleParameter("msg", OracleType.VarChar, 100)
        dptrjct(7).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("dptmthead_approvereject", dptrjct)


        Dim message As String
        message = dptrjct(7).Value

        'Dim message As String = dptrjct(2).Value


        script1.Append("alert('" & message & "');")
        script1.Append("window.open('DepatmtHeadApprove.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)





    End Sub

End Class
