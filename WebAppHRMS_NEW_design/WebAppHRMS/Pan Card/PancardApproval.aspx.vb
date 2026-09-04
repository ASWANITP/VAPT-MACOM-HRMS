'Imports system
Imports System.IO
Imports System.Data
Imports System.Data.OracleClient


Partial Class PancardApproval_be8aeb5e2729
    Inherits System.Web.UI.Page

    Dim dt, dt1, dt2, dts1, dts2, dtpri, dtrs As New DataTable
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



            dd1 = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=6023 and s.emp_id=" & dta.Rows(0)(0) & "").Tables(0)
            If dd1.Rows(0)(0) = 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

                Me.Server.Transfer("../show_err.aspx")
                'Else
                '    dts = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=855 and emp_id=" & UserAll(0) & "").Tables(0)
                '    If dts.Rows(0)(0) = 0 Then
                '        Dim cl_script0 As New System.Text.StringBuilder
                '        cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
                '        cl_script0.Append("window.open('../home.aspx','_self');")
                '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                '    End If
            End If




            usr = Me.Session("user_id").ToString.Split("!")




            Dim yy As String



            yy = "SELECT -1 AS emp_code, '----SELECT EMPLOYEE CODE & NAME----' AS emp_name FROM dual UNION ALL SELECT m.emp_code,m.emp_code||' -- '|| m.emp_name FROM employee_master m, pancard p WHERE m.firm_id = 8 and m.emp_code = p.empcode and p.status = 0 ORDER BY emp_name ASC"
            dt = oh.ExecuteDataSet(yy).Tables(0)
            If dt.Rows.Count > 0 Then
                Me.DropDownList1.DataSource = dt
                Me.DropDownList1.DataValueField = dt.Columns(0).ColumnName
                Me.DropDownList1.DataTextField = dt.Columns(1).ColumnName
                Me.DropDownList1.DataBind()
            End If

        End If



















    End Sub


    Protected Sub btnapprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnapprove.Click

        Dim script1 As New System.Text.StringBuilder


        usr = Me.Session("user_id").ToString.Split("!")
        Dim emp As Integer = CInt(usr(0).ToString())



        Dim pan(5) As OracleParameter
        pan(0) = New OracleParameter("emp_codes", OracleType.Number)
        pan(0).Direction = ParameterDirection.Input
        'pan(0).Value = empCode
        'pan(0).Value = CInt(Me.txt_ecode.Text)
        pan(0).Value = DropDownList1.SelectedItem.Value



        pan(1) = New OracleParameter("oldpan_numb", OracleType.VarChar, 100)
        pan(1).Direction = ParameterDirection.Input
        pan(1).Value = Me.txt_oldpan.Text




        pan(2) = New OracleParameter("new_pan_numb", OracleType.VarChar, 100)
        pan(2).Direction = ParameterDirection.Input
        pan(2).Value = Me.txt_pan.Text





        pan(3) = New OracleParameter("apprv_rjctd", OracleType.Number, 100)
        pan(3).Direction = ParameterDirection.Input
        pan(3).Value = emp


        pan(4) = New OracleParameter("flag", OracleType.Number, 100)
        pan(4).Direction = ParameterDirection.Input
        pan(4).Value = 1

        pan(5) = New OracleParameter("msg", OracleType.VarChar, 200)
        pan(5).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("pancard_approvereject", pan)


        Dim message As String
        message = pan(5).Value


        script1.Append("alert('" & message & "');")
        script1.Append("window.open('PancardApproval.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)




    End Sub

    Protected Sub btnreject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreject.Click


        Dim script1 As New System.Text.StringBuilder


        usr = Me.Session("user_id").ToString.Split("!")
        Dim emp As Integer = CInt(usr(0).ToString())




        Dim pan(5) As OracleParameter
        pan(0) = New OracleParameter("emp_codes", OracleType.Number)
        pan(0).Direction = ParameterDirection.Input
        'pan(0).Value = empCode
        'pan(0).Value = CInt(Me.txt_ecode.Text)
        pan(0).Value = DropDownList1.SelectedItem.Value




        pan(1) = New OracleParameter("oldpan_numb", OracleType.VarChar, 100)
        pan(1).Direction = ParameterDirection.Input
        pan(1).Value = Me.txt_oldpan.Text




        pan(2) = New OracleParameter("new_pan_numb", OracleType.VarChar, 100)
        pan(2).Direction = ParameterDirection.Input
        pan(2).Value = Me.txt_pan.Text



        pan(3) = New OracleParameter("apprv_rjctd", OracleType.Number, 100)
        pan(3).Direction = ParameterDirection.Input
        pan(3).Value = emp



        pan(4) = New OracleParameter("flag", OracleType.Number, 100)
        pan(4).Direction = ParameterDirection.Input

        pan(4).Value = 2


        pan(5) = New OracleParameter("msg", OracleType.VarChar, 100)
        pan(5).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("pancard_approvereject", pan)


        Dim message As String
        message = pan(5).Value


        script1.Append("alert('" & message & "');")
        script1.Append("window.open('PancardApproval.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)





    End Sub

    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click

        usr = Me.Session("user_id").ToString.Split("!")

        Dim dt1 As DataTable
        Dim Query As String
        Query = "SELECT p.image FROM pancard p WHERE p.empcode ='" & DropDownList1.SelectedValue.ToString() & "' AND p.status = 0"
        Try
            dt1 = oh.ExecuteDataSet(Query).Tables(0)
            If dt1.Rows.Count > 0 Then
                Dim bytes() As Byte = CType(dt1.Rows(0)("image"), Byte())
                Response.Buffer = True
                Response.Charset = ""
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.ContentType = "~/image/jpg"
                Response.AddHeader("content-disposition", "attachment;filename=pancard.jpg")
                Response.BinaryWrite(bytes)
                Response.Flush()
                Response.End()
            Else


            End If
        Catch ex As Exception

        End Try





    End Sub



    Protected Sub btnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnext.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged


        Dim emp = DropDownList1.SelectedValue


        If Session("firm_id") = 8 Then


            dt = oh.ExecuteDataSet("select p.existing_pan_num, p.new_pan_num from employee_master e, PANCARD p where e.emp_code =p.empcode and p.status = 0 and p.empcode = " & emp & "").Tables(0)
        Else
            dt = oh.ExecuteDataSet("select p.existing_pan_num, p.new_pan_num from employee_master e, PANCARD p where e.emp_code =p.empcode and p.status = 0and p.empcode = " & emp & "").Tables(0)
        End If

        Me.txt_oldpan.Text = dt.Rows(0)(0)
        Me.txt_pan.Text = dt.Rows(0)(1)

    End Sub
End Class
