Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_DeleteExcess_4cbca43e9365
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim st As Integer = 1
    Dim str As New StringBuilder
    Dim UserAll() As String
    Dim UserCode As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim UserAll() As String = Session("user_id").ToString.Split("!")
        ' Dim UserAll As Integer = User(0)
        Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=184 and emp_id=" & UserAll(0)).Tables(0).Rows(0)(0)
        If acce > 0 Then
            If Not IsPostBack Then
                dt = oh.ExecuteDataSet("select '  Select Allowance Type' all_name,-99 all_id from dual union select distinct a.all_name,a.all_id from hrm_ta_all_append t,incentives_allowances_master a where a.all_id=t.all_id union select distinct a.all_name,a.all_id from incentives_allowances_dtl t,incentives_allowances_master a where a.all_id=t.all_id union select cat_name all_name,cat_id all_id from category_sal_ded where status_id=1 order by all_name").Tables(0)
                Me.DropDownList1.DataSource = dt
                Me.DropDownList1.DataTextField = dt.Columns(0).ColumnName
                Me.DropDownList1.DataValueField = dt.Columns(1).ColumnName
                Me.DropDownList1.DataBind()
            End If
            Dim script_val As String
            script_val = "var loanno;" & "loanno='" & "" & Me.txt_empcode.ClientID & "'" & " ; "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
            Me.txt_empcode.Attributes.Add("onkeyPress", "return isNumberKey(event)")
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
            Dim enterBy As String = UserAll(0)
            For Each dr As GridViewRow In Me.GridView1.Rows
                chk = CType(dr.FindControl("CheckBox1"), CheckBox)
                If chk.Checked = True Then
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
                End If
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


                    p(3) = New OracleParameter("ErrorMessage", OracleType.VarChar, 100)
                    p(3).Direction = ParameterDirection.Output

                    p(4) = New OracleParameter("ErrorStatus", OracleType.Number, 1)
                    p(4).Direction = ParameterDirection.Output

                    p(5) = New OracleParameter("fl", OracleType.Number, 5)
                    p(5).Value = 1

                    p(6) = New OracleParameter("enter_by", OracleType.Number, 8)
                    p(6).Value = enterBy

                    p(7) = New OracleParameter("approve_by", OracleType.Number, 8)
                    p(7).Value = 0

                    oh.ExecuteNonQuery("SP_HRM_DELETE_EXCESS_MACOM", p)
                    Dim cl_script1 As New StringBuilder
                    ' cl_script1.Append("         alert('" & p(3).Value & "');")
                    If p(4).Value = 0 Then
                        st = 1
                        cl_script1.Append("         alert('Requested successfully');")
                        cl_script1.Append(" window.open('DeleteExcess.aspx','_self');")
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
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.txt_empcode.Text = "" Then
            Me.txt_empcode.Text = 0
        End If
        If Me.txt_empcode.Text = Nothing Then
            Me.txt_empcode.Text = 0
        End If
        If Me.DropDownList1.SelectedIndex > 0 Then
            If CInt(Me.txt_empcode.Text) > CInt(0) Then
                If Me.DropDownList1.SelectedValue > 900 Then
                    Dim dx As New DataTable
                    If Me.DropDownList1.SelectedValue = 991 Then
                        dt1 = oh.ExecuteDataSet("select  'Arrear Salary' all_name,a.emp_code, a.emp_name,t.arrear_sal amount,3 tablenm," & Me.DropDownList1.SelectedValue & " all_id from employ_sal_add t, employee_master a,employ_firm b where a.emp_code = t.emp_id and t.emp_id=" & Me.txt_empcode.Text & " and t.arrear_sal>0 and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & "").Tables(0)
                    End If
                    If Me.DropDownList1.SelectedValue = 992 Then
                        dt1 = oh.ExecuteDataSet("select  'Arrear DA' all_name,a.emp_code, a.emp_name,t.arrear_da amount,3 tablenm," & Me.DropDownList1.SelectedValue & " all_id from employ_sal_add t, employee_master a,employ_firm b where a.emp_code = t.emp_id and t.emp_id=" & Me.txt_empcode.Text & " and t.arrear_da>0 and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & "").Tables(0)
                    End If
                    If Me.DropDownList1.SelectedValue = 993 Then
                        dt1 = oh.ExecuteDataSet("select  'Other Additions' all_name,a.emp_code, a.emp_name,t.oth_add amount,3 tablenm," & Me.DropDownList1.SelectedValue & " all_id from employ_sal_add t, employee_master a,employ_firm b where a.emp_code = t.emp_id and t.emp_id=" & Me.txt_empcode.Text & " and t.oth_add>0 and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & "").Tables(0)
                    End If
                    If Me.DropDownList1.SelectedValue = 994 Then
                        dt1 = oh.ExecuteDataSet("select  'LIC' all_name,a.emp_code, a.emp_name,t.lic amount,3 tablenm," & Me.DropDownList1.SelectedValue & " all_id from employ_sal_add t, employee_master a,employ_firm b where a.emp_code = t.emp_id and t.emp_id=" & Me.txt_empcode.Text & " and t.lic>0 and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & "").Tables(0)
                    End If
                    If Me.DropDownList1.SelectedValue = 995 Then
                        dt1 = oh.ExecuteDataSet("select  'P_TAX' all_name,a.emp_code, a.emp_name,t.p_tax amount,3 tablenm," & Me.DropDownList1.SelectedValue & " all_id from employ_sal_add t, employee_master a,employ_firm b where a.emp_code = t.emp_id and t.emp_id=" & Me.txt_empcode.Text & " and t.p_tax>0 and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & "").Tables(0)
                    End If
                    If Me.DropDownList1.SelectedValue = 996 Then
                        dt1 = oh.ExecuteDataSet("select  'TDS' all_name,a.emp_code, a.emp_name,t.tds amount,3 tablenm," & Me.DropDownList1.SelectedValue & " all_id from employ_sal_add t, employee_master a,employ_firm b where a.emp_code = t.emp_id and t.emp_id=" & Me.txt_empcode.Text & " and t.tds>0 and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & "").Tables(0)
                    End If
                    If Me.DropDownList1.SelectedValue = 997 Then
                        dt1 = oh.ExecuteDataSet("select  'Other Deductions' all_name,a.emp_code, a.emp_name,t.oth_ded amount,3 tablenm," & Me.DropDownList1.SelectedValue & " all_id from employ_sal_add t, employee_master a,employ_firm b where a.emp_code = t.emp_id and t.emp_id=" & Me.txt_empcode.Text & " and t.oth_ded>0 and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & "").Tables(0)
                    End If

                Else
                    dt1 = oh.ExecuteDataSet("select  all_name,a.emp_code, a.emp_name,t.amount,1 tablenm,c.all_id from hrm_ta_all_append t, employee_master a,employ_firm b,incentives_allowances_master c where c.all_id=t.all_id and a.emp_code = t.emp_code and t.emp_code=" & Me.txt_empcode.Text & " and t.all_id=" & Me.DropDownList1.SelectedValue & " and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & "  union select all_name,a.emp_code, a.emp_name,t.all_amount amount,2 tablenm,c.all_id from incentives_allowances_dtl t, employee_master a,employ_firm b,incentives_allowances_master c where c.all_id=t.all_id and  a.emp_code = t.emp_code and t.emp_code=" & Me.txt_empcode.Text & " and t.all_id=" & Me.DropDownList1.SelectedValue & "  and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & " order by emp_code").Tables(0)

                End If
                If dt1.Rows.Count = 0 Then
                    Dim cl_script1 As New StringBuilder
                    cl_script1.Append("         alert('Please Check Employee Code!!!!!!!!');")

                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Me.GridView1.DataSource = dt2
                    Me.GridView1.DataBind()
                Else
                    Me.GridView1.DataSource = dt1
                    Me.GridView1.DataBind()
                End If

            Else
                If Me.DropDownList1.SelectedValue = 991 Then
                    dt1 = oh.ExecuteDataSet("select  'Arrear Salary' all_name,a.emp_code, a.emp_name,t.arrear_sal amount,3 tablenm," & Me.DropDownList1.SelectedValue & " all_id from employ_sal_add t, employee_master a,employ_firm b where a.emp_code = t.emp_id  and t.arrear_sal>0 and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & "").Tables(0)

                End If
                If Me.DropDownList1.SelectedValue = 992 Then
                    dt1 = oh.ExecuteDataSet("select  'Arrear DA' all_name,a.emp_code, a.emp_name,t.arrear_da amount,3 tablenm," & Me.DropDownList1.SelectedValue & " all_id from employ_sal_add t, employee_master a,employ_firm b where a.emp_code = t.emp_id  and t.arrear_da>0 and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & "").Tables(0)
                End If
                If Me.DropDownList1.SelectedValue = 993 Then
                    dt1 = oh.ExecuteDataSet("select  'Other Additions' all_name,a.emp_code, a.emp_name,t.oth_add amount,3 tablenm," & Me.DropDownList1.SelectedValue & " all_id from employ_sal_add t, employee_master a,employ_firm b where a.emp_code = t.emp_id  and t.oth_add>0 and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & "").Tables(0)
                End If
                If Me.DropDownList1.SelectedValue = 994 Then
                    dt1 = oh.ExecuteDataSet("select  'LIC' all_name,a.emp_code, a.emp_name,t.lic amount,3 tablenm," & Me.DropDownList1.SelectedValue & " all_id from employ_sal_add t, employee_master a,employ_firm b where a.emp_code = t.emp_id  and t.lic>0 and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & "").Tables(0)
                End If
                If Me.DropDownList1.SelectedValue = 995 Then
                    dt1 = oh.ExecuteDataSet("select  'P_TAX' all_name,a.emp_code, a.emp_name,t.p_tax amount,3 tablenm," & Me.DropDownList1.SelectedValue & " all_id from employ_sal_add t, employee_master a,employ_firm b where a.emp_code = t.emp_id  and t.p_tax>0 and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & "").Tables(0)
                End If
                If Me.DropDownList1.SelectedValue = 996 Then
                    dt1 = oh.ExecuteDataSet("select  'TDS' all_name,a.emp_code, a.emp_name,t.tds amount,3 tablenm," & Me.DropDownList1.SelectedValue & " all_id from employ_sal_add t, employee_master a,employ_firm b where a.emp_code = t.emp_id  and t.tds>0 and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & "").Tables(0)
                End If
                If Me.DropDownList1.SelectedValue = 997 Then
                    dt1 = oh.ExecuteDataSet("select  'Other Deductions' all_name,a.emp_code, a.emp_name,t.oth_ded amount,3 tablenm," & Me.DropDownList1.SelectedValue & " all_id from employ_sal_add t, employee_master a,employ_firm b where a.emp_code = t.emp_id  and t.oth_ded>0 and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & "").Tables(0)
                End If
                If Me.DropDownList1.SelectedValue < 900 Then
                    dt1 = oh.ExecuteDataSet("select  all_name,a.emp_code, a.emp_name,t.amount,1 tablenm,c.all_id from hrm_ta_all_append t, employee_master a,employ_firm b,incentives_allowances_master c where c.all_id=t.all_id and  a.emp_code = t.emp_code and t.all_id=" & Me.DropDownList1.SelectedValue & " and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & "  union select all_name,a.emp_code, a.emp_name,t.all_amount amount,2 tablenm,c.all_id from incentives_allowances_dtl t, employee_master a,employ_firm b,incentives_allowances_master c where c.all_id=t.all_id and  a.emp_code = t.emp_code and t.all_id=" & Me.DropDownList1.SelectedValue & "  and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & " order by emp_code").Tables(0)
                End If
                Me.GridView1.DataSource = dt1
                Me.GridView1.DataBind()

            End If

        Else
            If CInt(Me.txt_empcode.Text) > CInt(0) Then
                dt1 = oh.ExecuteDataSet("select  all_name,a.emp_code, a.emp_name,t.amount,1 tablenm,c.all_id  from hrm_ta_all_append t, employee_master a,employ_firm b,incentives_allowances_master c where c.all_id=t.all_id and  a.emp_code = t.emp_code and t.emp_code=" & Me.txt_empcode.Text & " and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & "  union select all_name,a.emp_code, a.emp_name,t.all_amount amount,2 tablenm,c.all_id from incentives_allowances_dtl t, employee_master a,employ_firm b,incentives_allowances_master c where c.all_id=t.all_id and  a.emp_code = t.emp_code and t.emp_code=" & Me.txt_empcode.Text & "  and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & " union select  'Arrear Salary' all_name,a.emp_code, a.emp_name,t.arrear_sal amount,3 tablenm,991 all_id from employ_sal_add t, employee_master a,employ_firm b where a.emp_code = t.emp_id and t.emp_id=" & Me.txt_empcode.Text & " and t.arrear_sal>0 and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & " union select  'Arrear DA' all_name,a.emp_code, a.emp_name,t.arrear_da amount,3 tablenm,992 all_id from employ_sal_add t, employee_master a,employ_firm b where a.emp_code = t.emp_id and t.emp_id=" & Me.txt_empcode.Text & " and t.arrear_da>0 and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & " union select  'Other Additions' all_name,a.emp_code, a.emp_name,t.oth_add amount,3 tablenm,993 all_id from employ_sal_add t, employee_master a,employ_firm b where a.emp_code = t.emp_id and t.emp_id=" & Me.txt_empcode.Text & " and t.oth_add>0 and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & " union select  'LIC' all_name,a.emp_code, a.emp_name,t.lic amount,3 tablenm,994 all_id from employ_sal_add t, employee_master a,employ_firm b where a.emp_code = t.emp_id and t.emp_id=" & Me.txt_empcode.Text & " and t.lic>0 and a.emp_code=b.emp_code and b.firm_id=" & Session("firm_id") & " order by emp_code").Tables(0)
                If dt1.Rows.Count = 0 Then
                    Dim cl_script1 As New StringBuilder
                    cl_script1.Append("         alert('Please Check Employee Code!!!!!!!!');")

                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

                Else
                    Me.GridView1.DataSource = dt1
                    Me.GridView1.DataBind()
                End If
            Else
                Me.GridView1.DataSource = dt2
                Me.GridView1.DataBind()
            End If
        End If
    End Sub
End Class