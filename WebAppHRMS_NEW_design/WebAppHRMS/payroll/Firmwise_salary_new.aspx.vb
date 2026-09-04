Imports System.Data
Imports System.Data.OracleClient
Partial Class Leave_Firmwise_salary_new_1aba1a552965
    Inherits System.Web.UI.Page
    ' Implements System.Web.UI.ICallbackEventHandler
    Dim objHelper As New helper.oracle.OracleHelper
    Dim dsOut As New DataSet
    Dim sql, sql1, res As String
    Dim dt1, dt2 As New DataTable
    Dim UserAll() As String
    Dim UserCode As Integer

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim fd As Integer = Session("firm_id")
        Dim strBuild As New StringBuilder

        sql = "select t.query,t.qry_desc from hrm_report_master t where t.firm_id=" & fd & " and t.query_id=" & DropDownList1.SelectedValue & ""
        dt1 = objHelper.ExecuteDataSet(sql).Tables(0)
        ' If Me.DropDownList1.SelectedValue = 1 Then
        ' strBuild.Append("select t.*, s.remark, f.firm_abbr, case  when t.branch_id in (select branch_id from branch_master) then (select branch_name from branch_master br where t.branch_id = br.branch_id) else (select branch_name from before_completion bc where t.branch_id = bc.old_id  and bc.branch_id <> 0) end as branch_name, f1.firm_abbr as rece_firm, dp.dep_name as department, case when t.branch_id > 0 then (select ft.firm_abbr  from firm_master ft, branch_master b  where b.branch_id = t.branch_id and ft.firm_id = b.firm_id) else 'MAFIL' end as branch_firm,ds.designation  from emp_master  e,status_mst   s, firm_master  f, department_mst dp,designation_master ds,m_wage t  left outer join firm_master f1 on (f1.firm_id = t.rec_firm) where t.status_id = s.status_id and f.firm_id= " & fd & " and t.department_id = dp.dep_id and t.emp_code = e.emp_code and t.designation_id=ds.designation_id and t.firm_id = f.firm_id order by t.emp_code")
        strBuild.Append(dt1.Rows(0)(0))
        'Else
        'strBuild.Append("select em.EMP_CODE, em.EMP_NAME, sum(decode(al.all_id, 1, al.all_amount, 0)) as fixed_ta, sum(decode(al.all_id, 2, al.all_amount, 0)) as Actual_Ta, sum(decode(al.all_id, 3, al.all_amount, 0)) as outstation,sum(decode(al.all_id, 4, al.all_amount, 0)) as ABH_ALLOWANCE,sum(decode(al.all_id, 5, al.all_amount, 0)) as BH_ALLOWANCE,sum(decode(al.all_id, 6, al.all_amount, 0)) as BH_TA,sum(decode(al.all_id, 7, al.all_amount, 0)) as VIGILANCE_SP_ALLOWANCE,sum(decode(al.all_id, 8, al.all_amount, 0)) as TELEPHONE_ALLOWANCE,sum(decode(al.all_id, 9, al.all_amount, 0)) as DISTANCE_ALLOWANCE, sum(decode(al.all_id, 10, al.all_amount, 0)) as HP_TA, sum(decode(al.all_id, 11, al.all_amount, 0)) as HP_INCENTIVE,sum(decode(al.all_id, 12, al.all_amount, 0)) as INSURANCE_INCENTIVE, sum(decode(al.all_id, 13, al.all_amount, 0)) as FOREX_INCENTIVE, sum(decode(al.all_id, 14, al.all_amount, 0)) as GLR_INCENTIVE,sum(decode(al.all_id, 15, al.all_amount, 0)) as DEPOSIT_MOBILISATION,sum(decode(al.all_id, 16, al.all_amount, 0)) as BOND_INCENTIVE,sum(decode(al.all_id, 17, al.all_amount, 0)) as BUSINESS_LOAN, sum(decode(al.all_id, 18, al.all_amount, 0)) as PERSONAL_LOAN, sum(decode(al.all_id, 19, al.all_amount, 0)) as GOLD_GA, sum(decode(al.all_id, 20, al.all_amount, 0)) as MANAGER_INCENTIVE,sum(decode(al.all_id, 21, al.all_amount, 0)) as MONTHLY_INCENTIVE,sum(decode(al.all_id, 22, al.all_amount, 0)) as DEPOSIT_MARKETING,sum(decode(al.all_id, 23, al.all_amount, 0)) as LEGAL_INCENTIVE,sum(decode(al.all_id, 24, al.all_amount, 0)) as CIVIL_INCENTIVE,sum(decode(al.all_id, 25, al.all_amount, 0)) as CHITS_INCENTIVE,sum(decode(al.all_id, 26, al.all_amount, 0)) as OTHER_INCENTIVE,sum(decode(al.all_id, 27, al.all_amount, 0)) as SUMMER_ALLOWANCE,sum(decode(al.all_id, 28, al.all_amount, 0)) as GOLDCOIN_MARKETING,sum(decode(al.all_id, 29, al.all_amount, 0)) as MUTUALFUND_MARKETING, sum(decode(al.all_id, 30, al.all_amount, 0)) as BRANCH_OPENING, sum(decode(al.all_id, 31, al.all_amount, 0)) as MONEY_TRANSFER, sum(decode(al.all_id, 32, al.all_amount, 0)) as GOLD_LOAN_MARKETING, sum(decode(al.all_id, 33, al.all_amount, 0)) as REFERAL_INCENTIVE, sum(decode(al.all_id, 34, al.all_amount, 0)) as AM_DM_INCENTIVE, sum(decode(al.all_id, 35, al.all_amount, 0)) as MARKETTING_BAL_SALARY, sum(decode(al.all_id, 36, al.all_amount, 0)) as RISK_ALLOWANCE, sum(decode(al.all_id, 37, al.all_amount, 0)) as LEAVE_ENCASHMENT, sum(decode(al.all_id, 38, al.all_amount, 0)) as LEAVE_INCENTIVE, sum(decode(al.all_id, 39, al.all_amount, 0)) as SPEC_ALLOW_AUCTION_GOLD,  sum(decode(al.all_id, 40, al.all_amount, 0)) as VISHU_ALLOWANCE, sum(decode(al.all_id, 41, al.all_amount, 0)) as SPECIAL_ALLOWANCE_AO, sum(decode(al.all_id, 42, al.all_amount, 0)) as PAT_INCENTIVE, sum(decode(al.all_id, 43, al.all_amount, 0)) as AM_SPECIAL_ALLOWANCE, sum(decode(al.all_id, 44, al.all_amount, 0)) as AUDITORS_FIXED_TA,  sum(decode(al.all_id, 45, al.all_amount, 0)) as JEWELLERY_INCENTIVE, sum(decode(al.all_id, 46, al.all_amount, 0)) as JR_ABH_ALLOWANCE, sum(decode(al.all_id, 47, al.all_amount, 0)) as KRA_INCENTIVE, sum(decode(al.all_id, 48, al.all_amount, 0)) as SD_INCENTIVE, sum(decode(al.all_id, 49, al.all_amount, 0)) as RD_INCENTIVE, sum(decode(al.all_id, 50, al.all_amount, 0)) as SITE_FINALISATION, sum(decode(al.all_id, 51, al.all_amount, 0)) as PERFORMANCE_SP_INCENTIVE, sum(decode(al.all_id, 52, al.all_amount, 0)) as HARDWARE_TA,sum(decode(al.all_id, 53, al.all_amount, 0)) as KANAKADEEPAM_INCENTIVES, sum(decode(al.all_id, 54, al.all_amount, 0)) as FOUNDATION_TA, sum(decode(al.all_id, 55, al.all_amount, 0)) as JEWELLERY_ALLOWANCE, sum(decode(al.all_id, 56, al.all_amount, 0)) as LEGAL_TA, sum(decode(al.all_id, 57, al.all_amount, 0)) as FOOD_ALLOWANCE, sum(decode(al.all_id, 58, al.all_amount, 0)) as NCD_ARREAR_INCENTIVE,sum(decode(al.all_id, 59, al.all_amount, 0)) as VIGILANCE_INCENTIVE, sum(decode(al.all_id, 60, al.all_amount, 0)) as CASH_VAN,sum(decode(al.all_id, 61, al.all_amount, 0)) as HRA,sum(decode(al.all_id, 62, al.all_amount, 0)) as OUTSTATION_ARREAR, sum(decode(al.all_id, 63, al.all_amount, 0)) as FIXED_TA_ARREAR,sum(decode(al.all_id, 64, al.all_amount, 0)) as ALLOWANCE_ARREAR,sum(decode(al.all_id, 65, al.all_amount, 0)) as FOOD_ALLOWANCE_ARREAR, sum(decode(al.all_id, 66, al.all_amount, 0)) as JEWELLERY_FIXED_TA, sum(decode(al.all_id, 75, al.all_amount, 0)) as FIXEDVARIABLEALLOWANCE, sum(decode(al.all_id, 69, al.all_amount, 0)) as JEWELLERY_OUTSTATION,sum(decode(al.all_id, 74, al.all_amount, 0)) as BUISINESS_INCENTIVE, sum(decode(al.all_id, 76, al.all_amount, 0)) as PERFORMANCEBONUS, sum(decode(al.all_id, 70, al.all_amount, 0)) as MACARESPECIALALLOW, sum(decode(al.all_id, 78, al.all_amount, 0)) as SCARPALLOW, fm.firm_abbr as Received_firm, p.post_name  from emp_master  em,incentives_allowances_dtl al,employ_firm f,firm_master  fm,employee_master_dtl ed,post_mst  p where em.EMP_CODE = al.emp_code  and al.EMP_CODE = ed.emp_code and em.EMP_CODE=f.emp_code and f.firm_id=fm.firm_id and em.POST_ID = p.post_id AND F.FIRM_ID = " & fd & " group by em.EMP_CODE, em.EMP_NAME, fm.firm_abbr, ed.new_empcode, em.STATUS_ID,p.post_name order by em.EMP_CODE")
        'End If

        dsOut = objHelper.ExecuteDataSet(strBuild.ToString)
        If dsOut.Tables.Count > 0 AndAlso dsOut.Tables(0).Rows.Count > 0 Then
            Dim dgGrid As New GridView
            dgGrid.AutoGenerateColumns = False
            dgGrid.EnableViewState = False
            dgGrid.Font.Name = "Times New Roman"
            dgGrid.HeaderStyle.BackColor = Drawing.Color.LightGray
            dgGrid.HeaderStyle.Font.Size = New FontUnit(FontSize.Smaller)
            dgGrid.HeaderStyle.HorizontalAlign = HorizontalAlign.Left
            dgGrid.RowStyle.VerticalAlign = VerticalAlign.Top
            dgGrid.RowStyle.Font.Size = New FontUnit(FontSize.Smaller)

            For i As Integer = 0 To dsOut.Tables(0).Columns.Count - 1
                Dim dbField As New BoundField
                dbField.HeaderText = dsOut.Tables(0).Columns(i).ColumnName
                dbField.DataField = dsOut.Tables(0).Columns(i).ColumnName
                dgGrid.Columns.Add(dbField)
            Next
            dgGrid.DataSource = dsOut
            dgGrid.DataBind()
            If Me.DropDownList1.SelectedValue = 1 Then
                Dim fname As String = DropDownList1.SelectedItem.Text + ".xls"
                WebAppHRMS.GridViewExportUtil.Export(fname, dgGrid)
            Else
                Dim fname As String = DropDownList1.SelectedItem.Text +".xls"
                WebAppHRMS.GridViewExportUtil.Export(fname, dgGrid)
            End If

        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fd As Integer = Session("firm_id")
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim acce As Integer = objHelper.ExecuteDataSet("select count(*) from form_accessibility t where form_id=840 and emp_id=" & UserCode).Tables(0).Rows(0)(0)
        If acce > 0 Then
            If Not IsPostBack Then
                Dim dt1 As New DataTable
                sql = "select -1,'--------------Select-----------' as emp from dual union all select t.query_id,t.qry_desc from hrm_report_master t where t.firm_id=" & fd & ""


                dt1 = objHelper.ExecuteDataSet(sql).Tables(0)
                Me.DropDownList1.DataSource = dt1
                Me.DropDownList1.DataTextField = dt1.Columns(1).ColumnName
                Me.DropDownList1.DataValueField = dt1.Columns(0).ColumnName
                Me.DropDownList1.DataBind()
            End If
        Else
            Me.Server.Transfer("../show_err.aspx")
            'End If
        End If
    End Sub

    

    'Protected Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
    '    If Me.RadioButton1.Checked Then
    '        Me.DropDownList2.Visible = True
    '        Me.DropDownList1.Visible = False
    '    Else
    '        Me.DropDownList2.Visible = False
    '        Me.DropDownList1.Visible = True
    '    End If
    'End Sub

    'Protected Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
    '    If Me.RadioButton2.Checked = True Then
    '        Me.DropDownList2.Visible = False
    '        Me.DropDownList1.Visible = True
    '    Else
    '        Me.DropDownList2.Visible = True
    '        Me.DropDownList1.Visible = False
    '    End If
    'End Sub

    

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Response.Redirect("../home.aspx")
    End Sub
End Class
