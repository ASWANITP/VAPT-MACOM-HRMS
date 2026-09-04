Imports System.Data
Imports system.data.oracleclient
Partial Class salaryreport_wage_slip_Emp_4965e3be9029
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    'Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_date.SelectedIndexChanged

    'End Sub

    ' '' ''Dim curr_User() As String
    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        
        'ScriptManager.RegisterStartupScript(Me, [GetType](), "showalert", "alert('Only alert Message');", True)
        If Not IsPostBack Then



            '--------------- ReqID 8592 starts------------------------------
            If Session("firm_id") = 8 Then
                '---------------------end--------------------------------------


                Dim curr_User() As String
                curr_User = Session("user_id").ToString.Split("!")
                Me.TxtEmployeeCode.Text = curr_User(0)


                '--------------- ReqID 8592 starts------------------------------
                Me.TxtEmployeeCode.ReadOnly = True
            Else
                Me.TxtEmployeeCode.ReadOnly = False

            End If
            '---------------------end--------------------------------------





            ' Lblmsg.Text = ""
            'Session("firm_id") = "24"

        End If
    End Sub


    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click

        If Convert.ToDateTime(TxtFromdt.Text) < Convert.ToDateTime(TxtTodate.Text) Then
            Dim sql As String

            '        sql = "select * from (select fm.firm_name,   em.emp_name, wg.fat_hus,desm.designation, to_char(trunc(to_date(wg.sal_dt, 'dd/mm/yyyy'), 'mm')) as dat," & _
            '       "to_char(last_day(to_date(wg.sal_dt, 'dd/mm/yyyy'))), nvl((wg.w_days - wg.l_days), 0) || '/' || nvl(wg.w_days, 0)," & _
            '      " nvl(wg.basic_pay, 0), nvl(wg.vda, 0), nvl(wg.ovt_wages, 0),  nvl(wg.gross_sal, 0), nvl(wg.tot_dedu, 0)," & _
            '     "  nvl(wg.net_pay, 0), br.branch_name," & _
            '"       ef.emp_code from m_wage wg join employ_firm ef on wg.emp_code=ef.emp_code join branch_master br " & _
            '"on ef.branch_id=br.branch_id  join designation_master desm on wg.designation_id=desm.designation_id join " & _
            '"employee_master em on ef.emp_code=em.emp_code " & _
            '"       join firm_master fm on em.firm_id=fm.firm_id" & _
            '"        where ef.emp_code=" + TxtEmployeeCode.Text.Trim("") + "  and ef.firm_id=" + Convert.ToString(Session("firm_id")) + "   " & _
            '"and wg.sal_dt > to_date(trunc(to_date('" + TxtFromdt.Text + "', 'dd/mm/yyyy'), 'mm')) and" & _
            '" wg.sal_dt < to_date(last_day(to_date('" + TxtTodate.Text + "', 'dd/mm/yyyy')))" & _
            '"        union " & _
            '"select fm.firm_name,       em.emp_name,       hwg.fat_hus,       desm.designation," & _
            '"   to_char(trunc(to_date(hwg.sal_dt, 'dd/mm/yyyy'), 'mm'))  as dat," & _
            '"       to_char(last_day(to_date(hwg.sal_dt, 'dd/mm/yyyy')))," & _
            '"       nvl((hwg.w_days - hwg.l_days), 0) || '/' || nvl(hwg.w_days, 0)," & _
            '"       nvl(hwg.basic_pay, 0)," & _
            '"       nvl(hwg.vda, 0)," & _
            '"       nvl(hwg.ovt_wages, 0)," & _
            '"       nvl(hwg.gross_sal, 0)," & _
            '"       nvl(hwg.tot_dedu, 0)," & _
            '"       nvl(hwg.net_pay, 0)," & _
            '"       br.branch_name," & _
            '"       ef.emp_code from m_wage_his hwg join employ_firm ef on hwg.emp_code=ef.emp_code " & _
            '"       join branch_master br on ef.branch_id=br.branch_id" & _
            '"       join designation_master desm on hwg.designation_id=desm.designation_id join employee_master em on" & _
            '" ef.emp_code=em.emp_code        join firm_master fm on em.firm_id=fm.firm_id" & _
            '"        where ef.emp_code=" + TxtEmployeeCode.Text.Trim("") + "  and ef.firm_id=" + Convert.ToString(Session("firm_id")) + " and " & _
            '"hwg.sal_dt > to_date(trunc(to_date('" + TxtFromdt.Text + "', 'dd/mm/yyyy'), 'mm')) and " & _
            '" hwg.sal_dt < to_date(last_day(to_date('" + TxtTodate.Text + "', 'dd/mm/yyyy')))    )fnl order by fnl.dat desc "


            sql = "select * from (select fm.firm_name,   em.emp_name, wg.fat_hus,desm.designation, to_char(trunc(to_date(wg.sal_dt, 'dd/mm/yyyy'), 'mm')) as dat, " & _
          "  to_char(last_day(to_date(wg.sal_dt, 'dd/mm/yyyy'))), nvl((wg.w_days - wg.l_days), 0) || '/' || nvl(wg.w_days, 0), " & _
          "  nvl(wg.basic_pay, 0), nvl(wg.vda, 0), nvl(wg.ovt_wages, 0),  nvl(wg.gross_sal, 0), nvl(wg.tot_dedu, 0), " & _
         "  nvl(wg.net_pay, 0), br.branch_name, " & _
          "   ef.emp_code, wg.sal_dt " & _
         "  from m_wage wg " & _
         "  join employ_firm ef on wg.emp_code=ef.emp_code " & _
         "  join branch_master br on ef.branch_id=br.branch_id  " & _
         "  join designation_master desm on wg.designation_id=desm.designation_id" & _
          "  join employee_master em on ef.emp_code=em.emp_code  " & _
          "  join firm_master fm on em.firm_id=fm.firm_id " & _
           "  where ef.emp_code = " + TxtEmployeeCode.Text.Trim("") + " And ef.firm_id = " + Convert.ToString(Session("firm_id")) + "" & _
    " and wg.sal_dt >= to_date(trunc(to_date('" + TxtFromdt.Text + "', 'dd/mm/yyyy'), 'mm')) and " & _
     "  wg.sal_dt <= to_date(last_day(to_date('" + TxtTodate.Text + "', 'dd/mm/yyyy')))  " & _
          "   union" & _
    "  select fm.firm_name,       em.emp_name,       hwg.fat_hus,       desm.designation,  " & _
      "  to_char(trunc(to_date(hwg.sal_dt, 'dd/mm/yyyy'), 'mm'))  as dat, " & _
         "   to_char(last_day(to_date(hwg.sal_dt, 'dd/mm/yyyy'))), " & _
          "  nvl((hwg.w_days - hwg.l_days), 0) || '/' || nvl(hwg.w_days, 0), " & _
          "  nvl(hwg.basic_pay, 0), " & _
         "   nvl(hwg.vda, 0), " & _
         "  nvl(hwg.ovt_wages, 0), " & _
    "  nvl(hwg.gross_sal, 0), " & _
          "  nvl(hwg.tot_dedu, 0), " & _
          "  nvl(hwg.net_pay, 0), " & _
          "   br.branch_name, " & _
          " ef.emp_code ,hwg.sal_dt" & _
         "  from m_wage_his hwg " & _
         "  join employ_firm ef on hwg.emp_code=ef.emp_code " & _
         "  join branch_master br on ef.branch_id=br.branch_id " & _
         "  join designation_master desm on hwg.designation_id=desm.designation_id" & _
        "   join employee_master em on  ef.emp_code=em.emp_code  " & _
     "  join firm_master fm on em.firm_id=fm.firm_id " & _
         "    where ef.emp_code = " + TxtEmployeeCode.Text.Trim("") + " And ef.firm_id = " + Convert.ToString(Session("firm_id")) + " And " & _
    " hwg.sal_dt >=to_date(trunc(to_date('" + TxtFromdt.Text + "', 'dd/mm/yyyy'), 'mm')) and " & _
     " hwg.sal_dt <= to_date(last_day(to_date('" + TxtTodate.Text + "', 'dd/mm/yyyy')))  " & _
       "  )fnl order by fnl.sal_dt desc "


            Dim dt As New DataTable


            dt = getDatatable(sql)

            If (dt.Rows.Count > 0) Then
                Session("resulttable") = dt
                Server.Transfer("wage_slip_report_emp.aspx")
            Else
                'Lblmsg.Text = "No WageSlip available for this EmployeeCode for this period"
                'trinvalid.Visible = True
                ScriptManager.RegisterStartupScript(Me, [GetType](), "showalert", "alert('No WageSlip available for this EmployeeCode for this period');", True)
            End If
        Else
            'trinvalid.Visible = True
            'Lblmsg.Text = "From Date should be less than To Date"
            ScriptManager.RegisterStartupScript(Me, [GetType](), "showalert", "alert('From Date should be less than To Date');", True)
        End If



    End Sub
    Private Function getDatatable(ByVal qry As Object) As DataTable
        Dim dtresults As New DataTable
        Dim oh As New Helper.Oracle.OracleHelper
        dtresults = oh.ExecuteDataSet(qry).Tables(0)
        Return dtresults
    End Function

    

    

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Response.Redirect("../home.aspx")
    End Sub


End Class
