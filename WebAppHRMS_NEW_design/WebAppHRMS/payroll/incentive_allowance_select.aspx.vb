Imports System.Data
Imports System.Data.OracleClient
Partial Class TA_UPD_VER3_incentive_allowance_select_e01e86ac8030
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim str, str1 As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Departmentwise and Employeewise Allowances or Incentives Insertion/Updation Form "

        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Txt_itemValue.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)

        If Not IsPostBack Then
            Dim userid As String = Me.Session("user_id")
            Dim arruid As String() = userid.Split("!")
            Dim fis As Integer = session("firm_id")
            Dim uid As Integer = arruid(0)
            Dim s As Integer = oh.ExecuteDataSet("select count(auth_empcode) from incentives_allowances_master where auth_empcode=" & uid & "").Tables(0).Rows(0)(0)
            If s < 1 Then
                Me.Server.Transfer("../show_err.aspx")
            Else
                Dim a As Integer = oh.ExecuteDataSet("select status_id from employee_master where emp_code=" & uid & "").Tables(0).Rows(0)(0)

                If a = 1 Then
                    str = "select e.emp_code, e.emp_code || '   ' || e.emp_name  from employee_master e,employ_firm f where e.emp_code=f.emp_code and  e.emp_code > 9999  and e.emp_code in (select m.emp_code from employee_master_dtl m where (m.discont_dt is NULL or m.discont_dt >= to_date(sysdate) - 90)) and f.firm_id=" & fis & " order by emp_code"
                    dt = oh.ExecuteDataSet(str).Tables(0)
                    Me.Cmb_Employee.DataSource = dt
                    Me.Cmb_Employee.DataTextField = dt.Columns(1).ColumnName
                    Me.Cmb_Employee.DataValueField = dt.Columns(0).ColumnName
                    Me.Cmb_Employee.DataBind()

                    fill()
                Else
                    Me.Server.Transfer("../show_err.aspx")
                End If
            End If

            
        End If



    End Sub

    Sub fill()
        'str1 = "select a.all_id,a.all_name from incentives_allowances_master a order by a.all_name"
        str1 = "select distinct a.all_id,a.all_name from mactech.hrm_ta_employees t, mactech.employee_master e,mactech.incentives_allowances_master a where t.emp_code = e.emp_code and e.firm_id=8 and a.all_id=t.all_id order by a.all_name"
        dt1 = oh.ExecuteDataSet(str1).Tables(0)
        Me.Cmb_Item.DataSource = dt1
        Me.Cmb_Item.DataTextField = dt1.Columns(1).ColumnName
        Me.Cmb_Item.DataValueField = dt1.Columns(0).ColumnName
        Me.Cmb_Item.DataBind()

    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        '-----to provide security department heads empcode only can enter values!!!!

        Dim userid As String = Me.Session("user_id")
        Dim uid() As String = userid.Split("!")
        Dim ecode As Integer = uid(0)

        Try
            Dim para(5) As OracleParameter

            para(0) = New OracleParameter("empcode", OracleType.Number, 5)
            para(0).Value = Me.Cmb_Employee.SelectedValue
            para(0).Direction = ParameterDirection.Input

            para(1) = New OracleParameter("item_number", OracleType.Number, 2)
            para(1).Value = Me.Cmb_Item.SelectedValue
            para(1).Direction = ParameterDirection.Input

            para(2) = New OracleParameter("item_value", OracleType.Double)
            para(2).Value = Me.Txt_itemValue.Text
            para(2).Direction = ParameterDirection.Input

            para(3) = New OracleParameter("enterby", OracleType.VarChar)
            para(3).Value = Me.Session("user_id")
            para(3).Direction = ParameterDirection.Input

            para(4) = New OracleParameter("entercode", OracleType.Number, 5)
            para(4).Value = ecode
            para(4).Direction = ParameterDirection.Input

            para(5) = New OracleParameter("flag", OracleType.Number, 1)
            para(5).Direction = ParameterDirection.Output

            oh.ExecuteDataSet("deptwise_ta_upd_ins", para)
            If para(5).Value = 1 Then
                Dim cl_script As New StringBuilder
                cl_script.Append(" alert('Successfully Inserted!!! ');")
                'cl_script.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            ElseIf para(5).Value = 2 Then
                Dim cl_script1 As New StringBuilder
                cl_script1.Append(" alert('Successfully Updated!!! ');")
                ' cl_script1.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)

            ElseIf para(5).Value = 3 Then
                Dim cl_script2 As New StringBuilder
                cl_script2.Append(" alert('You Have No Authority!!! ');")
                cl_script2.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script2.ToString, True)

            ElseIf para(5).Value = 4 Then
                Dim cl_script3 As New StringBuilder
                cl_script3.Append(" alert('This Item Already made Tally.So Cannot Insert or Update!!! ');")
                'cl_script3.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script3.ToString, True)
                'MsgBox("hai")
                'fill()

            ElseIf para(5).Value = 0 Then
                Dim cl_script4 As New StringBuilder
                cl_script4.Append(" alert('Some Problems may have occured!!! ');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script4.ToString, True)

            End If
        Catch ex As Exception
            Dim cl_script5 As New StringBuilder
            cl_script5.Append("   alert('" & ex.ToString & " ') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script5.ToString, True)

        Finally
        End Try

    End Sub

    Protected Sub Cmd_Report_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Report.Click
        Me.Server.Transfer("itemwiseall_report.aspx?item_id=" & Me.Cmb_Item.SelectedValue)
    End Sub
End Class
