Imports System.Data
Imports System.Data.OracleClient
Public Class DeleteExcessApprove
    Inherits System.Web.UI.Page

    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim st As Integer = 1
    Dim str As New StringBuilder
    Dim UserAll() As String
    Dim UserCode As Integer

    Protected Sub ddl_employee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_employee.SelectedIndexChanged
        Dim empcod As Integer = ddl_employee.SelectedValue
        dt1 = oh.ExecuteDataSet("select al.all_name, h.emp_code, a.emp_name, h.amount, h.table_id as tablenm, h.all_id from employee_master a, hr_excess_removed_temp h, incentives_allowances_master al where h.all_id = al.all_id And a.emp_code = h.emp_code and a.emp_code = " & empcod & " and h.status=0 union select ca.cat_name, h.emp_code, a.emp_name, h.amount, h.table_id as tablenm, h.all_id from employee_master a, hr_excess_removed_temp h, category_sal_ded ca where h.all_id = ca.cat_id and a.emp_code = h.emp_code and a.emp_code = " & empcod & " and h.status=0").Tables(0)
        Me.GridView1.DataSource = dt1
        Me.GridView1.DataBind()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Me.GridView1.Rows.Count > 0 Then
            Dim empcode
            Dim chk As CheckBox
            Dim val, incid As Integer
            Dim amt As Double
            Dim tab As Integer
            UserAll = Me.Session("user_id").ToString.Split("!")
            Dim approveBy As String = UserAll(0)
            For Each dr As GridViewRow In Me.GridView1.Rows
                'chk = CType(dr.FindControl("CheckBox1"), CheckBox)
                'If chk.Checked = True Then
                val = 1
                    st = 0
                    empcode = dr.Cells(1).Text
                    amt = dr.Cells(3).Text
                    tab = Me.GridView1.DataKeys(dr.RowIndex).Values(0)
                    incid = Me.GridView1.DataKeys(dr.RowIndex).Values(1)
                    str = str.Append(incid)
                    str = str.Append("^")
                    str = str.Append(empcode)
                    str = str.Append("^")
                    str = str.Append(amt)
                    str = str.Append("^")
                    str = str.Append(tab)
                    str = str.Append("!")
                'End If
            Next
            If st = 1 Then
                Dim cl_script1 As New StringBuilder
                cl_script1.Append("         alert('Select any record for delete');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Return
            Else
                Try
                    Dim p(7) As OracleParameter

                    p(0) = New OracleParameter("Data", OracleType.VarChar, 5000)
                    p(0).Value = str.ToString

                    p(1) = New OracleParameter("UserID", OracleType.VarChar, 100)
                    p(1).Value = Session("user_id")

                    p(2) = New OracleParameter("BranchID", OracleType.Number, 6)
                    p(2).Value = Session("branch_id")


                    p(3) = New OracleParameter("ErrorMessage", OracleType.VarChar, 400)
                    p(3).Direction = ParameterDirection.Output

                    p(4) = New OracleParameter("ErrorStatus", OracleType.Number, 1)
                    p(4).Direction = ParameterDirection.Output

                    p(5) = New OracleParameter("fl", OracleType.Number, 5)
                    p(5).Value = 3

                    p(6) = New OracleParameter("enter_by", OracleType.Number, 5)
                    p(6).Value = 0

                    p(7) = New OracleParameter("approve_by", OracleType.Number, 5)
                    p(7).Value = approveBy

                    oh.ExecuteNonQuery("SP_HRM_DELETE_EXCESS_MACOM", p)
                    Dim cl_script1 As New StringBuilder
                    'cl_script1.Append("         alert('" & p(3).Value & "');")
                    If p(4).Value = 0 Then
                        st = 1
                        cl_script1.Append("         alert('Rejected!!');")
                        cl_script1.Append(" window.open('DeleteExcessApprove.aspx','_self');")
                    Else
                        cl_script1.Append("         alert('" & p(3).Value & "');")
                    End If
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Catch ex As Exception
                End Try
            End If
        Else
            Dim cl_script1 As New StringBuilder
            cl_script1.Append("         alert('Select any record for delete');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Return
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim UserAll() As String = Session("user_id").ToString.Split("!")
        ' Dim UserAll As Integer = User(0)
        Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=134 and emp_id=" & UserAll(0)).Tables(0).Rows(0)(0)
        If acce > 0 Then
            If Not IsPostBack Then
                dt = oh.ExecuteDataSet("select 0 as Empcode, 'Select Employee' as Empname from dual union select e.emp_code, e.emp_code || ' - ' || em.emp_name from mactech.hr_excess_removed_temp e,mactech.employee_master em where e.emp_code=em.emp_code and e.status = 0").Tables(0)
                Me.ddl_employee.DataSource = dt
                Me.ddl_employee.DataTextField = dt.Columns(1).ColumnName
                Me.ddl_employee.DataValueField = dt.Columns(0).ColumnName
                Me.ddl_employee.DataBind()
            End If
            Dim script_val As String
            script_val = "var loanno;" & "loanno='" & "" & Me.ddl_employee.ClientID & "'" & " ; "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
            Me.ddl_employee.Attributes.Add("onkeyPress", "return isNumberKey(event)")
        Else
            Me.Server.Transfer("../show_err.aspx")
            Exit Sub
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.GridView1.Rows.Count > 0 Then
            Dim empcode
            Dim chk As CheckBox
            Dim val, incid As Integer
            Dim amt As Double
            Dim tab As Integer
            UserAll = Me.Session("user_id").ToString.Split("!")
            Dim approveBy As String = UserAll(0)
            For Each dr As GridViewRow In Me.GridView1.Rows
                'chk = CType(dr.FindControl("CheckBox1"), CheckBox)
                'If chk.Checked = True Then
                val = 1
                    st = 0
                    empcode = dr.Cells(1).Text
                    amt = dr.Cells(3).Text
                    tab = Me.GridView1.DataKeys(dr.RowIndex).Values(0)
                    incid = Me.GridView1.DataKeys(dr.RowIndex).Values(1)
                    str = str.Append(incid)
                    str = str.Append("^")
                    str = str.Append(empcode)
                    str = str.Append("^")
                    str = str.Append(amt)
                    str = str.Append("^")
                    str = str.Append(tab)
                    str = str.Append("!")
                'End If
            Next
            If st = 1 Then
                Dim cl_script1 As New StringBuilder
                cl_script1.Append("         alert('Select any record for delete');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Return
            Else
                Try
                    Dim p(7) As OracleParameter

                    p(0) = New OracleParameter("Data", OracleType.VarChar, 5000)
                    p(0).Value = str.ToString

                    p(1) = New OracleParameter("UserID", OracleType.VarChar, 100)
                    p(1).Value = Session("user_id")

                    p(2) = New OracleParameter("BranchID", OracleType.Number, 6)
                    p(2).Value = Session("branch_id")


                    p(3) = New OracleParameter("ErrorMessage", OracleType.VarChar, 400)
                    p(3).Direction = ParameterDirection.Output

                    p(4) = New OracleParameter("ErrorStatus", OracleType.Number, 1)
                    p(4).Direction = ParameterDirection.Output

                    p(5) = New OracleParameter("fl", OracleType.Number, 5)
                    p(5).Value = 2

                    p(6) = New OracleParameter("enter_by", OracleType.Number, 5)
                    p(6).Value = 0

                    p(7) = New OracleParameter("approve_by", OracleType.Number, 5)
                    p(7).Value = approveBy

                    oh.ExecuteNonQuery("SP_HRM_DELETE_EXCESS_MACOM", p)
                    Dim cl_script1 As New StringBuilder
                    'cl_script1.Append("         alert('" & p(3).Value & "');")
                    If p(4).Value = 0 Then
                        st = 1
                        cl_script1.Append("         alert('Approved Successfully');")
                        cl_script1.Append(" window.open('DeleteExcessApprove.aspx','_self');")
                    Else
                        cl_script1.Append("         alert('" & p(3).Value & "');")
                    End If
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Catch ex As Exception
                End Try
            End If
        Else
            Dim cl_script1 As New StringBuilder
            cl_script1.Append("         alert('Select any record for delete');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Return
        End If
    End Sub

End Class

