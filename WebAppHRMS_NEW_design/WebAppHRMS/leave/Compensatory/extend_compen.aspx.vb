Imports System.Data
Imports System.Data.OracleClient
Partial Class compensatory_extension_extend_compen_122a91077953
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2 As New DataTable
    Dim oh As New helper.oracle.OracleHelper
    Dim UserAll(), res, sql, str As String
    Dim UserCode, stat As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder
    Dim z As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim emno As Integer = oh.ExecuteDataSet("select count(d.emp_id)  from form_accessibility d  where d.emp_id=" & UserCode & " and d.form_id=750").Tables(0).Rows(0)(0)
        If emno = 0 Then
            str_tkn.Append("         alert('You are not authorized...!');")
            str_tkn.Append(" window.open('../../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        Else
            If Not IsPostBack = True Then
                dt1 = oh.ExecuteDataSet("select -1 emp_code, '------Employee Code--------' employ_name from dual union all select distinct hc.emp_code, e.emp_code || '--' || e.emp_name from hrm_comp_dtl hc, hrm_comp_eligible he, employee_master e,employ_firm fm where hc.emp_code = he.emp_code and e.emp_code = he.emp_code and e.emp_code=fm.emp_code and fm.firm_id=" & Session("firm_id") & " and hc.comp_id = he.comp_id and hc.exp_date >= to_date('1-jan-2013') and hc.exp_date <> '31/dec/2013' and he.status = 0").Tables(0)
                Me.drp_emp.DataSource = dt1
                Me.drp_emp.DataTextField = dt1.Columns(1).ColumnName
                Me.drp_emp.DataValueField = dt1.Columns(0).ColumnName
                Me.drp_emp.DataBind()
            End If
        End If

    End Sub
    Protected Sub drp_emp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drp_emp.SelectedIndexChanged
        dt = oh.ExecuteDataSet("select distinct hm.comp_name || '-----' || hc.exp_date,hc.comp_id  from hrm_comp_dtl      hc,  hrm_comp_eligible he,  employee_master   e,  hrm_comp_mst      hm  where hc.emp_code = he.emp_code  and e.emp_code = he.emp_code  and he.comp_id = hm.comp_id  and hc.comp_id = he.comp_id  and to_date(hc.exp_date) >= to_date('1-jan-2013')  and hc.exp_date <> '31/dec/2013'  and he.status = 0  and e.emp_code = " & Me.drp_emp.SelectedValue & "").Tables(0)
        Me.drp_comp.DataSource = dt
        Me.drp_comp.DataTextField = dt.Columns(0).ColumnName
        Me.drp_comp.DataValueField = dt.Columns(1).ColumnName
        Me.drp_comp.DataBind()
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'dt2 = oh.ExecuteDataSet("select distinct hc.exp_date  from hrm_comp_dtl      hc,  hrm_comp_eligible he,  employee_master   e,  hrm_comp_mst      hm  where hc.emp_code = he.emp_code  and e.emp_code = he.emp_code  and he.comp_id = hm.comp_id  and to_date(hc.exp_date) >= to_date(sysdate)  and he.status = 0  and e.branch_id = 0  and e.emp_code = " & Me.drp_emp.SelectedValue & "").Tables(0)
        'dt2.Rows(0)(0) = z
        'If Me.txt_cal.Text < z Then
        '    str_tkn.Append("         alert('Please Check the Current Expiry date...!');")
        '    str_tkn.Append(" window.open('../home.aspx','_self');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        'End If
        If Me.txt_cal.Text = "" Then

            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('Please Enter Expiry date') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Exit Sub

        End If
        Dim p(3) As OracleParameter

        p(0) = New OracleParameter("emcod", OracleType.Number, 10)
        p(0).Value = Me.drp_emp.SelectedValue

        p(1) = New OracleParameter("compid", OracleType.Number, 4)
        p(1).Value = Me.drp_comp.SelectedValue

        p(2) = New OracleParameter("cdte", OracleType.DateTime)
        p(2).Value = CDate(Me.txt_cal.Text)

        p(3) = New OracleParameter("msg", OracleType.VarChar, 100)
        p(3).Direction = ParameterDirection.Output

        oh.ExecuteNonQuery("hrm_comp_extend", p)
        Dim script1 As New System.Text.StringBuilder
        script1.Append("   alert(' " & p(3).Value & "');")

        script1.Append("window.open('../../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)


    End Sub
End Class
