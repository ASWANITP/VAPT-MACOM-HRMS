Imports Microsoft.VisualBasic
'Imports TDS_IDAL.ITDS
Imports System.Data.OracleClient
Imports System.Data
Namespace DAL_nmS
    Public Class TDS_DAL
        Implements TDS_IDAL.ITDS.TDS_INT
        Dim oh As New helper.oracle.OracleHelper
        Dim sql, str As String
        Dim dt As New DataTable
        Public Function emp_dtl(ByVal emp_id As Integer, ByVal month As String) As String Implements TDS_IDAL.ITDS.TDS_INT.emp_dtl
            Dim str As String = ""
            dt = oh.ExecuteDataSet("select to_char(to_date(rs.sal_date),'mm-yyyy')||','||to_char(to_date(rs.sal_date),'dd-MON-yyyy')||'!'||to_char(to_date(rs.sal_date),'MON-yyyy')||'!'||rs.tds_cut_amt||'!'||1 from etds_request rs where to_char(to_date(rs.sal_date),'MON-yyyy') ='" & month & "' and rs.emp_id=" & emp_id & "").Tables(0)
            For i As Integer = 0 To dt.Rows.Count - 1
                str += dt.Rows(i)(0)
                str += "$"
            Next
            Return str
        End Function
        Public Function fill_data(ByVal id As Integer) As System.Data.DataTable Implements TDS_IDAL.ITDS.TDS_INT.fill_data

            If id = 31 Then   'Employees in eTDSEmployee is Showing..!!
                sql = "select 0 as emp_id,' --SELECT EMPLOYEE--' as emp_name from dual union select et.emp_id,et.emp_id||'  -  '||em.emp_name from etds_employee et,employee_master em where et.emp_id=em.emp_code order by emp_id"
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If
            If id = 32 Then   'Category in eTDS Category is Showing..!!
                sql = "select 0,upper(' --Select Category--') as Category_name from dual union select ec.category_id,upper(ec.category_name) from etds_category ec where ec.category_id>0 order by category_name"
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If
            If id = 34 Then   'From date Showing..!!
                If Today.Month = 4 Then
                    sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy') as sal_dt,'--SELECT MONTH--' from dual union SELECT TO_CHAR(Sysdate,'mm-yyyy') as sal_dt,TO_CHAR(Sysdate,'MON-yyyy') FROM DUAL order by sal_dt desc"
                Else
                    If Today.Month > 4 Then
                        sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') as sal_dt,to_char(m1.sal_dt,'MON-yyyy') from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy') union SELECT TO_CHAR(Sysdate,'mm-yyyy') as sal_dt,TO_CHAR(Sysdate,'MON-yyyy') FROM DUAL order by sal_dt desc"
                    Else
                        sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') as sal_dt,to_char(m1.sal_dt,'MON-yyyy') from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where (to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')-1) or (to_char(m2.sal_dt,'mm')<=03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')) union SELECT TO_CHAR(Sysdate,'mm-yyyy') as sal_dt,TO_CHAR(Sysdate,'MON-yyyy') FROM DUAL  order by sal_dt desc"
                    End If
                End If
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If
            If id = 35 Then   'Employees in eTDSEmployee is Showing..!!
                sql = "select -1, '-------------SELECT-----------'  from dual union all select et.emp_id,et.emp_id||'     '||em.emp_name from etds_employee et,employee_master em where et.emp_id=em.emp_code order by 1"
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If

            If id = 4 Then
                sql = "select ed.emp_id,ed.deducted_month,ed.tds_amt,ed.surcharge,ed.edu_cess from  etds_deducted  ed,employee_master e,employ_firm f where ed.emp_id=e.emp_code and e.emp_code=f.emp_code  and ed.tds_status=1 and ed.tds_amt>0 and f.firm_id=" & System.Web.HttpContext.Current.Session("firm_id") & " order by ed.deducted_month,ed.emp_id"
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If

            If id = 55 Then
                If Today.Month >= 5 Then
                    sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy')||','||to_date('31/dec/9000') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') ||','||to_date(m1.sal_dt,'dd-MON-yyyy')  as sal_dt,to_char(m1.sal_dt,'MON-yyyy')from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy') order by sal_dt desc"
                Else
                    sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy')||','||to_date('31/dec/9000') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') ||','||to_date(m1.sal_dt,'dd-MON-yyyy') as sal_dt,to_char(m1.sal_dt,'MON-yyyy') from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy')||','||to_date(m2.sal_dt,'dd-MON-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where (to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')-1) or (to_char(m2.sal_dt,'mm')<=03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')) order by sal_dt desc"
                End If
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If
            If id = 56 Then
                Dim str As String
                If Today.Month >= 4 Then
                    str = "select '0','--SELECT MONTH--',0 as month_id,'0' as yr from dual union select to_char(t.month_id||'-'||to_char(sysdate,'yyyy'))||','||'28-'||t.abbr||'-'||to_char(sysdate,'yyyy'),to_char(to_char(t.abbr)||'-'||to_char(sysdate,'yyyy')),t.month_id,to_char(sysdate,'yyyy') yr from month t where t.month_id>3 union select to_char(t.month_id||'-'||((to_char(sysdate,'yyyy'))+1))||','||'28-'||t.abbr||'-'||((to_char(sysdate,'yyyy'))+1),to_char(to_char(t.abbr)||'-'||((to_char(sysdate,'yyyy'))+1)),t.month_id,to_char(to_number(to_char(sysdate,'yyyy'))+1) yr from month t where t.month_id<4 order by yr,month_id"
                Else
                    str = "select '0','--SELECT MONTH--',0 as month_id,'0' as yr from dual union select to_char(t.month_id||'-'||((to_char(sysdate,'yyyy'))-1))||','||'28-'||t.abbr||'-'||(to_char(sysdate,'yyyy')-1),to_char(to_char(t.abbr)||'-'||(to_char(sysdate,'yyyy')-1)),t.month_id,to_char(sysdate,'yyyy') yr from month t where t.month_id>3 union select to_char(t.month_id||'-'||(to_char(sysdate,'yyyy')))||','||'28-'||t.abbr||'-'||(to_char(sysdate,'yyyy')),to_char(to_char(t.abbr)||'-'||(to_char(sysdate,'yyyy'))),t.month_id,to_char(to_number(to_char(sysdate,'yyyy'))+1) yr from month t where t.month_id<4 order by yr,month_id"
                    '    str = "select to_char(to_date('31/dec/9000'),'mm-yyyy')||','||to_date('31/dec/9000') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') ||','||to_date(m1.sal_dt,'dd-MON-yyyy') as sal_dt,to_char(m1.sal_dt,'MON-yyyy') from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy')||','||to_date(m2.sal_dt,'dd-MON-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where (to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')-1) or (to_char(m2.sal_dt,'mm')<=03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')) order by sal_dt desc"
                End If

                dt = oh.ExecuteDataSet(str).Tables(0)
                Return dt
            End If
            If id = 67 Then
                sql = "select to_char(sysdate,'MM') from dual"
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If

            Return dt
        End Function
        Public Function fill_data_new(ByVal id As Integer, ByVal firm As Integer) As System.Data.DataTable Implements TDS_IDAL.ITDS.TDS_INT.fill_data_new
            If id = 31 Then   'Employees in eTDSEmployee is Showing..!!
                sql = "select 0 as emp_id,' --SELECT EMPLOYEE--' as emp_name from dual union select et.emp_id,et.emp_id||'  -  '||em.emp_name from etds_employee et,employee_master em,employ_firm ef where et.emp_id=em.emp_code and ef.emp_code=em.emp_code and ef.firm_id=" & firm & " order by emp_id"
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If
            If id = 32 Then   'Category in eTDS Category is Showing..!!
                sql = "select 0,upper(' --Select Category--') as Category_name from dual union select ec.category_id,upper(ec.category_name) from etds_category ec where ec.category_id>0 order by category_name"
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If
            If id = 34 Then   'From date Showing..!!
                If Today.Month = 4 Then
                    sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy') as sal_dt,'--SELECT MONTH--' from dual union SELECT TO_CHAR(Sysdate,'mm-yyyy') as sal_dt,TO_CHAR(Sysdate,'MON-yyyy') FROM DUAL order by sal_dt desc"
                Else
                    If Today.Month > 4 Then
                        sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') as sal_dt,to_char(m1.sal_dt,'MON-yyyy') from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy') union SELECT TO_CHAR(Sysdate,'mm-yyyy') as sal_dt,TO_CHAR(Sysdate,'MON-yyyy') FROM DUAL order by sal_dt desc"
                    Else
                        sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') as sal_dt,to_char(m1.sal_dt,'MON-yyyy') from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where (to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')-1) or (to_char(m2.sal_dt,'mm')<=03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')) union SELECT TO_CHAR(Sysdate,'mm-yyyy') as sal_dt,TO_CHAR(Sysdate,'MON-yyyy') FROM DUAL  order by sal_dt desc"
                    End If
                End If
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If
            If id = 35 Then   'Employees in eTDSEmployee is Showing..!!
                sql = "select -1,'-----Select--------' from dual union all select et.emp_id,et.emp_id||'     '||em.emp_name from etds_employee et,employee_master em,employ_firm ef where et.emp_id=em.emp_code and ef.emp_code=em.emp_code and ef.firm_id=" & firm & "  and em.status_id=1 order by 1"
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If

            If id = 4 Then
                sql = "select ed.emp_id,ed.deducted_month,ed.tds_amt,ed.surcharge,ed.edu_cess from  etds_deducted  ed,employee_master e where ed.emp_id=e.emp_code and ed.tds_status=1 and ed.tds_amt>0 and ed.firm_id=" & System.Web.HttpContext.Current.Session("firm_id") & " order by ed.deducted_month,ed.emp_id"
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If

            If id = 55 Then
                If Today.Month >= 5 Then
                    sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy')||','||to_date('31/dec/9000') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') ||','||to_date(m1.sal_dt,'dd-MON-yyyy')  as sal_dt,to_char(m1.sal_dt,'MON-yyyy')from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy') order by sal_dt desc"
                Else
                    sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy')||','||to_date('31/dec/9000') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') ||','||to_date(m1.sal_dt,'dd-MON-yyyy') as sal_dt,to_char(m1.sal_dt,'MON-yyyy') from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy')||','||to_date(m2.sal_dt,'dd-MON-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where (to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')-1) or (to_char(m2.sal_dt,'mm')<=03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')) order by sal_dt desc"
                End If
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If
            If id = 56 Then
                Dim str As String
                If Today.Month >= 4 Then
                    str = "select '0','--SELECT MONTH--',0 as month_id,'0' as yr from dual union select to_char(t.month_id||'-'||to_char(sysdate,'yyyy'))||','||'28-'||t.abbr||'-'||to_char(sysdate,'yyyy'),to_char(to_char(t.abbr)||'-'||to_char(sysdate,'yyyy')),t.month_id,to_char(sysdate,'yyyy') yr from month t where t.month_id>3 union select to_char(t.month_id||'-'||((to_char(sysdate,'yyyy'))+1))||','||'28-'||t.abbr||'-'||((to_char(sysdate,'yyyy'))+1),to_char(to_char(t.abbr)||'-'||((to_char(sysdate,'yyyy'))+1)),t.month_id,to_char(to_number(to_char(sysdate,'yyyy'))+1) yr from month t where t.month_id<4 order by yr,month_id"
                Else
                    str = "select '0','--SELECT MONTH--',0 as month_id,'0' as yr from dual union select to_char(t.month_id||'-'||((to_char(sysdate,'yyyy'))-1))||','||'28-'||t.abbr||'-'||(to_char(sysdate,'yyyy')-1),to_char(to_char(t.abbr)||'-'||(to_char(sysdate,'yyyy')-1)),t.month_id,to_char(sysdate,'yyyy') yr from month t where t.month_id>3 union select to_char(t.month_id||'-'||(to_char(sysdate,'yyyy')))||','||'28-'||t.abbr||'-'||(to_char(sysdate,'yyyy')),to_char(to_char(t.abbr)||'-'||(to_char(sysdate,'yyyy'))),t.month_id,to_char(to_number(to_char(sysdate,'yyyy'))+1) yr from month t where t.month_id<4 order by yr,month_id"
                    '    str = "select to_char(to_date('31/dec/9000'),'mm-yyyy')||','||to_date('31/dec/9000') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') ||','||to_date(m1.sal_dt,'dd-MON-yyyy') as sal_dt,to_char(m1.sal_dt,'MON-yyyy') from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy')||','||to_date(m2.sal_dt,'dd-MON-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where (to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')-1) or (to_char(m2.sal_dt,'mm')<=03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')) order by sal_dt desc"
                End If

                dt = oh.ExecuteDataSet(str).Tables(0)
                Return dt
            End If
            If id = 67 Then
                sql = "select to_char(sysdate,'MM') from dual"
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If

            Return dt

        End Function

        Public Function tds_confirm(ByVal tid As Integer, ByVal str As String) As String Implements TDS_IDAL.ITDS.TDS_INT.tds_confirm
            If tid = 4 Then
                Try
                    Dim param(1) As OracleParameter
                    param(0) = New OracleParameter("str", OracleType.VarChar, 10000)
                    param(0).Direction = ParameterDirection.Input
                    param(0).Value = str
                    param(1) = New OracleParameter("flag", OracleType.Number, 2)
                    param(1).Direction = ParameterDirection.InputOutput
                    param(1).Value = 0
                    param(2) = New OracleParameter("strl", OracleType.VarChar, 100)
                    param(2).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("proc_etds_dep", param)
                    str = param(2).Value
                Catch ex As Exception
                    str = ex.Message
                Finally
                End Try
            End If

            If tid = 8 Then
                Try
                    Dim param(2) As OracleParameter
                    param(0) = New OracleParameter("str", OracleType.VarChar, 500)
                    param(0).Direction = ParameterDirection.InputOutput
                    param(0).Value = str
                    param(1) = New OracleParameter("flag", OracleType.Number, 2)
                    param(1).Direction = ParameterDirection.InputOutput
                    param(1).Value = 0
                    param(2) = New OracleParameter("firmId", OracleType.Number, 2)
                    param(2).Direction = ParameterDirection.InputOutput
                    param(2).Value = System.Web.HttpContext.Current.Session("firm_id")
                    oh.ExecuteNonQuery("proc_etds_ack", param)
                    str = param(0).Value & "%" & param(1).Value
                Catch ex As Exception
                    str = ex.Message
                Finally
                End Try
            End If

            If tid = 33 Then   ' for TDS Other Details Insertion CONFIRM..!!
                Try
                    Dim params(1) As OracleParameter
                    params(0) = New OracleParameter("othdetails", OracleType.VarChar, 1000)
                    params(0).Value = str
                    params(0).Direction = ParameterDirection.Input
                    params(1) = New OracleParameter("ReturnMessage", OracleType.VarChar, 500)
                    params(1).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("etds_other_details", params)
                    str = params(1).Value.ToString
                Catch ex As Exception
                    str = ex.Message.ToString
                End Try
            End If

            If tid = 11 Then
                Dim param(1) As OracleParameter
                param(0) = New OracleParameter("str", OracleType.VarChar)
                param(0).Direction = ParameterDirection.Input
                param(0).Value = str
                param(1) = New OracleParameter("err_stat", OracleType.Number)
                param(1).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("eTDS_add_employee", param)
                str = param(1).Value
            End If

            If tid = 55 Then
                Dim param(1) As OracleParameter
                param(0) = New OracleParameter("str", OracleType.VarChar)
                param(0).Direction = ParameterDirection.Input
                param(0).Value = str
                param(1) = New OracleParameter("err_stat", OracleType.Number)
                param(1).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("eTDS_deduction_request", param)
                str = param(1).Value
            End If
            If tid = 21 Then
                Dim param(1) As OracleParameter
                param(0) = New OracleParameter("em_id", OracleType.Number)
                param(0).Direction = ParameterDirection.Input
                param(0).Value = str
                param(0) = New OracleParameter("str", OracleType.VarChar)
                param(0).Direction = ParameterDirection.Input
                param(0).Value = str
                param(1) = New OracleParameter("err_stat", OracleType.Number)
                param(1).Direction = ParameterDirection.Output
                param(1) = New OracleParameter("err_msg", OracleType.Number)
                param(1).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("eTDS_add_employee", param)
                str = param(1).Value
            End If

            Return str
        End Function
        Public Function tds_other_type_fill(ByVal id As Integer, ByVal category_id As Integer) As System.Data.DataTable Implements TDS_IDAL.ITDS.TDS_INT.tds_other_type_fill
            Dim str As String = ""
            If id = 1 Then  'get respective Types of a Category..!!
                str = "select et.type_id,upper(et.type_name) from etds_type et where et.category_id=" & category_id & " and status=1 order by et.type_name"
                dt = oh.ExecuteDataSet(str).Tables(0)
            End If

            If id = 2 Then 'her  category id is Employee Code..!!
                If Today.Month >= 4 Then
                    str = "select ee.emp_id||'*'||em.emp_name||'*'||ec.category_id||'*'||ec.category_name||'*'||et.type_id||'*'||et.type_name||'*'||round(nvl(eo.amount,0),2)||'*'||to_char(eo.sal_date,'mm-YYYY')||'*'||to_char(eo.sal_date,'MON-YYYY')||'*'||decode(et.etds_type,'C','CREDIT','D','DEBIT','NS') from  eTDS_Employee ee,eTDS_Others eo,employee_master em,employ_firm f,eTDS_Type et,eTDS_Category ec where ee.emp_id=eo.emp_id and ee.emp_id=em.emp_code and eo.type_id=et.type_id and et.category_id=ec.category_id and em.emp_code=f.emp_code and f.firm_id=" & System.Web.HttpContext.Current.Session("firm_id") & " and ee.emp_id=" & category_id & " and eo.sal_date between to_date('1/apr/'||(to_char(sysdate,'yyyy'))) and to_date('31/mar/'||((to_char(sysdate,'yyyy')+1))) order by ec.category_name"
                Else
                    str = "select ee.emp_id||'*'||em.emp_name||'*'||ec.category_id||'*'||ec.category_name||'*'||et.type_id||'*'||et.type_name||'*'||round(nvl(eo.amount,0),2)||'*'||to_char(eo.sal_date,'mm-YYYY')||'*'||to_char(eo.sal_date,'MON-YYYY')||'*'||decode(et.etds_type,'C','CREDIT','D','DEBIT','NS') from  eTDS_Employee ee,eTDS_Others eo,employee_master em,employ_firm f,eTDS_Type et,eTDS_Category ec where ee.emp_id=eo.emp_id and ee.emp_id=em.emp_code and eo.type_id=et.type_id and et.category_id=ec.category_id and em.emp_code=f.emp_code and f.firm_id=" & System.Web.HttpContext.Current.Session("firm_id") & " and ee.emp_id=" & category_id & " and eo.sal_date between to_date('1/apr/'||((to_char(sysdate,'yyyy'))-1)) and to_date('31/mar/'||(to_char(sysdate,'yyyy'))) order by ec.category_name"
                End If
                dt = oh.ExecuteDataSet(str).Tables(0)
            End If

            If id = 3 Then
                str = "select e.emp_name from employee_master e,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & System.Web.HttpContext.Current.Session("firm_id") & " and e.emp_code=" & category_id & ""
                dt = oh.ExecuteDataSet(str).Tables(0)
            End If

            If id = 4 Then
                str = "select FLOOR( MONTHS_BETWEEN( CURRENT_DATE, t.birth_date) / 12 ) from employ_personal_dtl t,employ_firm f where t.emp_code=f.emp_code and f.firm_id=" & System.Web.HttpContext.Current.Session("firm_id") & " and t.emp_code=" & category_id & ""
                dt = oh.ExecuteDataSet(str).Tables(0)
            End If

            'If id = 11 Then
            '    Dim dt1, dt2, dt3 As New DataTable
            '    dt3 = oh.ExecuteDataSet("select em.emp_code from employee_master_dtl em,employee_master es where add_months(em.discont_dt,1)>=to_date(sysdate) and  em.emp_code=es.emp_code and es.status_id<>1 and  em.emp_code=" & category_id & " union select em.emp_code from employee_master_dtl em,employee_master es where  em.emp_code=es.emp_code and es.status_id=1 and  em.emp_code=" & category_id & "").Tables(0)
            '    If dt3.Rows.Count = 0 Then
            '        Return dt3
            '    Else
            '        dt1 = oh.ExecuteDataSet("select count(emp_id)||'^^' from etds_employee where emp_id=" & category_id & "").Tables(0)
            '        Dim ss() As String
            '        ss = dt1.Rows(0)(0).ToString.Split("^")
            '        If ss(0) = 0 Then
            '            dt2 = oh.ExecuteDataSet("select ep.emp_code||'^'||ep.emp_name||'^'||ep.sex||'^'||to_char(ep.birth_date,'DD/MM/YYYY') from employ_personal_dtl ep where ep.emp_code=" & category_id & "").Tables(0)
            '            If dt2.Rows.Count > 0 Then
            '                Return dt2
            '            End If
            '        Else
            '            Return dt1
            '        End If
            '    End If
            'End If

            If id = 11 Then
                Dim dt1, dt2, dt3 As New DataTable
                dt3 = oh.ExecuteDataSet("select em.emp_code from employee_master_dtl em,employee_master es where add_months(em.discont_dt,1)>=to_date(sysdate) and  em.emp_code=es.emp_code and es.status_id<>1 and  em.emp_code=" & category_id & " union select em.emp_code from employee_master_dtl em,employee_master es where  em.emp_code=es.emp_code and es.status_id=1 and  em.emp_code=" & category_id & "").Tables(0)
                If dt3.Rows.Count = 0 Then
                    Return dt3
                Else
                    dt1 = oh.ExecuteDataSet("select count(emp_id)||'^^' from etds_employee where emp_id=" & category_id & "").Tables(0)
                    Dim ss() As String
                    ss = dt1.Rows(0)(0).ToString.Split("^")
                    dt2 = oh.ExecuteDataSet("select ep.emp_code||'^'||ep.emp_name||'^'||ep.sex||'^'||to_char(ep.birth_date,'DD/MM/YYYY') from employ_personal_dtl ep where ep.emp_code=" & category_id & "").Tables(0)
                    If dt2.Rows.Count > 0 Then
                        Return dt2
                    End If
                End If
            End If

            If id = 12 Then
                dt = oh.ExecuteDataSet("select pan_no from etds_employee where emp_id=" & category_id & "").Tables(0)
                If dt.Rows.Count = 1 Then
                    Return dt
                End If
            End If

            If id = 55 Then
                dt = oh.ExecuteDataSet("select emp_id from etds_employee where emp_id=" & category_id & "").Tables(0)
                If dt.Rows.Count <> 0 Then
                    dt = oh.ExecuteDataSet("select em.emp_code||'@'||em.emp_name||'@'||dp.dep_name||'@'||br.branch_name from employee_master em,department_mst dp,branch_master br,active_firms a,employ_firm e where em.department_id=dp.dep_id and em.branch_id=br.branch_id and a.branch_id=br.branch_id and e.emp_code=em.emp_code and e.firm_id=" & System.Web.HttpContext.Current.Session("firm_id") & " and a.firm_id=" & System.Web.HttpContext.Current.Session("firm_id") & " and em.emp_code=" & category_id & " ").Tables(0)
                    If dt.Rows.Count > 0 Then
                        Return dt
                    End If
                Else
                    Return dt
                End If
            End If

            If id = 23 Then
                dt = oh.ExecuteDataSet("select count(*) from etds_employee where emp_id=" & category_id & "").Tables(0)
            End If

            If id = 25 Then
                If Date.Now.Month > 3 Then
                    str = "select to_char(w.SAL_DT, 'mon/yyyy'),w.gross_sal,w.VDA,w.LOP, w.BONUS,w.EXGRATIA,w.P_TAX,  w.P_FUND,  w.LIC,w.SAL_DT  from mwage_all w  where w.EMP_CODE = " & category_id & "  and w.SAL_DT between  to_date('1/apr/' || (select to_char(to_date(parmtr_value), 'YYYY')  from general_parameter  where module_id = 0  and firm_id = 1  and parmtr_id = 3))  and to_date('31/mar/' || (select to_char(to_date(parmtr_value), 'YYYY')  from general_parameter  where module_id = 0  and firm_id = 1  and parmtr_id = 4))      union all   select to_char(w.SAL_DT, 'mon/yyyy'),  w.gross_sal,  w.VDA,  w.LOP,  w.BONUS,  w.EXGRATIA,  w.P_TAX,  w.P_FUND,  w.LIC,w.SAL_DT  from m_wage_his w ,employee_master_dtl em   where   w.EMP_CODE=em.emp_code and em.new_empcode=" & category_id & "  and w.SAL_DT between  to_date('1/apr/' || (select to_char(to_date(parmtr_value), 'YYYY')  from general_parameter  where module_id = 0  and firm_id = 1  and parmtr_id = 3))  and to_date('31/mar/' || (select to_char(to_date(parmtr_value), 'YYYY')  from general_parameter  where module_id = 0  and firm_id = 1  and parmtr_id = 4))    order by sal_dt"
                Else
                    str = "select to_char(w.SAL_DT, 'mon/yyyy'),  w.gross_sal,  w.VDA,  w.LOP,  w.BONUS,  w.EXGRATIA,  w.P_TAX,  w.P_FUND,  w.LIC,w.SAL_DT  from mwage_all w  where w.EMP_CODE = " & category_id & "  and w.SAL_DT between  to_date('1/apr/' || (select to_char(to_date(parmtr_value), 'YYYY')  from general_parameter  where module_id = 0  and firm_id = 1  and parmtr_id = 3))  and to_date('31/mar/' || (select to_char(to_date(parmtr_value), 'YYYY')  from general_parameter  where module_id = 0  and firm_id = 1  and parmtr_id = 4))      union all   select to_char(w.SAL_DT, 'mon/yyyy'),  w.gross_sal,  w.VDA,  w.LOP,  w.BONUS,  w.EXGRATIA,  w.P_TAX,  w.P_FUND,  w.LIC,w.SAL_DT  from m_wage_his w ,employee_master_dtl em   where w.EMP_CODE =em.new_empcode and em.emp_code= " & category_id & "  and w.SAL_DT between  to_date('1/apr/' || (select to_char(to_date(parmtr_value), 'YYYY')  from general_parameter  where module_id = 0  and firm_id = 1  and parmtr_id = 3))  and to_date('31/mar/' || (select to_char(to_date(parmtr_value), 'YYYY')  from general_parameter  where module_id = 0  and firm_id = 1  and parmtr_id = 4)) order by sal_dt"
                End If
                dt = oh.ExecuteDataSet(str).Tables(0)
            End If

            If id = 24 Then
                str = "select e.emp_name,t.pan_no,d.dep_name from etds_employee t,employee_master e,department_mst d where t.emp_id=e.emp_code and e.department_id=d.dep_id and t.emp_id=" & category_id & ""
                dt = oh.ExecuteDataSet(str).Tables(0)
            End If

            If id = 26 Then
                str = "select count(*) from form_accessibility t where t.emp_id=" & category_id & " and t.form_id=157"
                dt = oh.ExecuteDataSet(str).Tables(0)
            End If

            If id = 27 Then
                str = "select count(*) from etds_employee where emp_id=" & category_id & ""
                dt = oh.ExecuteDataSet(str).Tables(0)
            End If

            If id = 28 Then
                str = "select count(*) from ETDS_POSSIBLE_EMPLOYEES where emp_code=" & category_id & ""
                dt = oh.ExecuteDataSet(str).Tables(0)
            End If

            If id = 29 Then
                str = "select count(*) from etds_employee where emp_id=" & category_id & " and senior='Y'"
                dt = oh.ExecuteDataSet(str).Tables(0)
            End If
            Return dt
        End Function
        Public Function tds_disp(ByVal id As Integer, ByVal emp_id As String) As String Implements TDS_IDAL.ITDS.TDS_INT.tds_disp
            If id = 1 Then
                Dim st As String
                Dim p(8) As OracleParameter
                p(0) = New OracleParameter("emid", OracleType.Number, 5)
                p(0).Value = emp_id
                p(1) = New OracleParameter("one_mon_sal", OracleType.Double)
                p(1).Direction = ParameterDirection.Output
                p(2) = New OracleParameter("tot_sal", OracleType.Double)
                p(2).Direction = ParameterDirection.Output

                p(3) = New OracleParameter("ded_amt", OracleType.Double)
                p(3).Direction = ParameterDirection.Output
                p(4) = New OracleParameter("inc_amt", OracleType.Double)
                p(4).Direction = ParameterDirection.Output

                p(5) = New OracleParameter("tax_amt", OracleType.Double)
                p(5).Direction = ParameterDirection.Output
                p(6) = New OracleParameter("tds_ded", OracleType.Number)
                p(6).Direction = ParameterDirection.Output


                p(7) = New OracleParameter("err_stat", OracleType.Number)
                p(7).Direction = ParameterDirection.Output
                p(8) = New OracleParameter("err_msg", OracleType.VarChar, 1000)
                p(8).Direction = ParameterDirection.Output

                oh.ExecuteNonQuery("etds_disp_sal", p)
                st = p(7).Value & "#" & p(8).Value & "#" & p(1).Value & "#" & p(2).Value & "#" & p(3).Value & "#" & p(4).Value & "#" & p(5).Value & "#" & p(6).Value
                Return st
            End If
        End Function
        Public Function tds_exp(ByVal id As Integer, ByVal emp_id As Integer, ByVal amount As Double) As String Implements TDS_IDAL.ITDS.TDS_INT.tds_exp
            If id = 1 Then
                Dim st As String
                Dim p(4) As OracleParameter
                p(0) = New OracleParameter("emid", OracleType.Number, 5)
                p(0).Value = emp_id
                p(1) = New OracleParameter("tot_income", OracleType.Double)
                p(1).Value = amount
                p(2) = New OracleParameter("tax_amot", OracleType.Double)
                p(2).Direction = ParameterDirection.Output
                p(3) = New OracleParameter("err_st", OracleType.Number)
                p(3).Direction = ParameterDirection.Output
                p(4) = New OracleParameter("err_mg", OracleType.VarChar, 1000)
                p(4).Direction = ParameterDirection.Output

                oh.ExecuteNonQuery("etds_tda_calc", p)
                st = p(3).Value & "#" & p(4).Value & "#" & p(2).Value
                Return st
            End If

        End Function
        Public Function tds_rep(ByVal id As Integer, ByVal emp_id As Integer, ByVal month As String) As System.Data.DataTable Implements TDS_IDAL.ITDS.TDS_INT.tds_rep
            If id = 26 Then
                sql = "select nvl(sum(ia.ALL_AMOUNT),0) from incallow_all ia where ia.EMP_CODE=" & emp_id & " and to_char(ia.PR_DATE,'mon/yyyy')='" & month & "' and ia.ALL_ID=3"
            End If

            If id = 27 Then
                sql = "select nvl(sum(ia.ALL_AMOUNT),0) from incallow_all ia where ia.EMP_CODE=" & emp_id & " and to_char(ia.PR_DATE,'mon/yyyy')='" & month & "' and ia.ALL_ID=1"
            End If

            If id = 28 Then
                sql = "select nvl(sum(ia.ALL_AMOUNT),0) from incallow_all ia where ia.EMP_CODE=" & emp_id & " and to_char(ia.PR_DATE,'mon/yyyy')='" & month & "' and ia.ALL_ID not in (1,2,3,8)"
            End If

            If id = 29 Then
                sql = "select nvl(sum(t.pat_amt),0) from hrm_pat_inc t where t.emp_code=" & emp_id & " and to_char(t.sal_dt,'mon/yyyy')='" & month & "'"
            End If

            If id = 30 Then
                sql = "select nvl(sum(t.tds_amt)+sum(t.surcharge)+sum(t.edu_cess),0) from etds_deducted t where t.emp_id=" & emp_id & " and to_char(t.deducted_month,'mon/yyyy')='" & month & "'"
            End If

            If id = 31 Then
                sql = "select count(*) from etds_possible_employees t where t.emp_code=" & emp_id & " and t.firm_id=" & System.Web.HttpContext.Current.Session("firm_id") & " "
                'dt = oh.ExecuteDataSet(sql).Tables(0)
            End If
            If id = 32 Then
                'sql = "select nvl(sum(ia.bonus+ia.exgratia),0),to_char(ia.proc_dt,'mon/yyyy') from hrm_bonus_dtl_his ia where ia.EMP_CODE=" & emp_id & " and to_char(ia.proc_dt,'dd/mon/yyyy')  between to_date('1/apr/'||(to_char(sysdate,'yyyy'))) and to_date('31/mar/'||((to_char(sysdate,'yyyy')+1))) group by ia.proc_dt"
                sql = "select nvl(sum(ia.bonus+ia.exgratia),0),to_char(ia.proc_dt,'mon/yyyy') from hrm_bonus_dtl_his ia where ia.EMP_CODE=" & emp_id & " and to_char(ia.proc_dt,'dd/mon/yyyy')  between  to_date('1/apr/'||(select to_char(to_date(parmtr_value),'YYYY') from general_parameter where module_id=0 and firm_id=1 and parmtr_id=3)) and to_date('31/mar/'||(select to_char(to_date(parmtr_value),'YYYY') from general_parameter where module_id=0 and firm_id=1 and parmtr_id=4)) group by ia.proc_dt"
            End If
            If id = 57 Then
                sql = "select count(t.ack_no) from etds_ack t where t.tds_year=" & emp_id & " and t.quarter=" & month & ""
            End If
            dt = oh.ExecuteDataSet(sql).Tables(0)
            Return dt
        End Function
    End Class
End Namespace

'Imports Microsoft.VisualBasic
'Imports TDS_IDAL.ITDS
'Imports System.Data.OracleClient
'Imports System.Data
'Namespace DAL_nmS
'    Public Class TDS_DAL
'        Implements TDS_IDAL.ITDS.TDS_INT
'        Dim oh As New helper.oracle.OracleHelper
'        Dim sql, str As String
'        Dim dt As New DataTable

'        Public Function emp_dtl(ByVal emp_id As Integer, ByVal month As String) As String Implements TDS_IDAL.ITDS.TDS_INT.emp_dtl
'            Dim str As String = ""
'            dt = oh.ExecuteDataSet("select to_char(to_date(rs.sal_date),'mm-yyyy')||','||to_char(to_date(rs.sal_date),'dd-MON-yyyy')||'!'||to_char(to_date(rs.sal_date),'MON-yyyy')||'!'||rs.tds_cut_amt||'!'||1 from etds_request rs where to_char(to_date(rs.sal_date),'MON-yyyy') ='" & month & "' and rs.emp_id=" & emp_id & "").Tables(0)
'            For i As Integer = 0 To dt.Rows.Count - 1
'                str += dt.Rows(i)(0)
'                str += "$"
'            Next
'            Return str
'        End Function
'        Public Function fill_data(ByVal id As Integer) As System.Data.DataTable Implements TDS_IDAL.ITDS.TDS_INT.fill_data
'            If id = 31 Then   'Employees in eTDSEmployee is Showing..!!
'                sql = "select 0 as emp_id,' --SELECT EMPLOYEE--' as emp_name from dual union select et.emp_id,et.emp_id||'  -  '||em.emp_name from etds_employee et,employee_master em where et.emp_id=em.emp_code order by emp_id"
'                dt = oh.ExecuteDataSet(sql).Tables(0)
'            End If
'            If id = 32 Then   'Category in eTDS Category is Showing..!!
'                sql = "select 0,upper(' --Select Category--') as Category_name from dual union select ec.category_id,upper(ec.category_name) from etds_category ec where ec.category_id>0 order by category_name"
'                dt = oh.ExecuteDataSet(sql).Tables(0)
'            End If
'            If id = 34 Then   'From date Showing..!!
'                If Today.Month = 4 Then
'                    sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy') as sal_dt,'--SELECT MONTH--' from dual union SELECT TO_CHAR(Sysdate,'mm-yyyy') as sal_dt,TO_CHAR(Sysdate,'MON-yyyy') FROM DUAL order by sal_dt desc"
'                Else
'                    If Today.Month > 4 Then
'                        sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') as sal_dt,to_char(m1.sal_dt,'MON-yyyy') from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy') union SELECT TO_CHAR(Sysdate,'mm-yyyy') as sal_dt,TO_CHAR(Sysdate,'MON-yyyy') FROM DUAL order by sal_dt desc"
'                    Else
'                        sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') as sal_dt,to_char(m1.sal_dt,'MON-yyyy') from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where (to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')-1) or (to_char(m2.sal_dt,'mm')<=03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')) union SELECT TO_CHAR(Sysdate,'mm-yyyy') as sal_dt,TO_CHAR(Sysdate,'MON-yyyy') FROM DUAL  order by sal_dt desc"
'                    End If
'                End If
'                dt = oh.ExecuteDataSet(sql).Tables(0)
'            End If
'            If id = 35 Then   'Employees in eTDSEmployee is Showing..!!
'                sql = "select et.emp_id,et.emp_id||'     '||em.emp_name from etds_employee et,employee_master em where et.emp_id=em.emp_code order by emp_name"
'                dt = oh.ExecuteDataSet(sql).Tables(0)
'            End If

'            If id = 4 Then
'                sql = "select ed.emp_id,ed.deducted_month,ed.tds_amt,ed.surcharge,ed.edu_cess from  etds_deducted  ed,employee_master e where ed.emp_id=e.emp_code and ed.tds_status=1 and ed.tds_amt>0 order by ed.deducted_month,ed.emp_id"
'                dt = oh.ExecuteDataSet(sql).Tables(0)
'            End If

'            If id = 55 Then
'                If Today.Month >= 5 Then
'                    sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy')||','||to_date('31/dec/9000') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') ||','||to_date(m1.sal_dt,'dd-MON-yyyy')  as sal_dt,to_char(m1.sal_dt,'MON-yyyy')from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy') order by sal_dt desc"
'                Else
'                    sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy')||','||to_date('31/dec/9000') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') ||','||to_date(m1.sal_dt,'dd-MON-yyyy') as sal_dt,to_char(m1.sal_dt,'MON-yyyy') from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy')||','||to_date(m2.sal_dt,'dd-MON-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where (to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')-1) or (to_char(m2.sal_dt,'mm')<=03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')) order by sal_dt desc"
'                End If
'                dt = oh.ExecuteDataSet(sql).Tables(0)
'            End If
'            If id = 56 Then
'                Dim str As String
'                If Today.Month >= 4 Then
'                    str = "select '0','--SELECT MONTH--',0 as month_id,'0' as yr from dual union select to_char(t.month_id||'-'||to_char(sysdate,'yyyy'))||','||'28-'||t.abbr||'-'||to_char(sysdate,'yyyy'),to_char(to_char(t.abbr)||'-'||to_char(sysdate,'yyyy')),t.month_id,to_char(sysdate,'yyyy') yr from month t where t.month_id>3 union select to_char(t.month_id||'-'||((to_char(sysdate,'yyyy'))+1))||','||'28-'||t.abbr||'-'||((to_char(sysdate,'yyyy'))+1),to_char(to_char(t.abbr)||'-'||((to_char(sysdate,'yyyy'))+1)),t.month_id,to_char(to_number(to_char(sysdate,'yyyy'))+1) yr from month t where t.month_id<4 order by yr,month_id"
'                Else
'                    str = "select '0','--SELECT MONTH--',0 as month_id,'0' as yr from dual union select to_char(t.month_id||'-'||((to_char(sysdate,'yyyy'))-1))||','||'28-'||t.abbr||'-'||(to_char(sysdate,'yyyy')-1),to_char(to_char(t.abbr)||'-'||(to_char(sysdate,'yyyy')-1)),t.month_id,to_char(sysdate,'yyyy') yr from month t where t.month_id>3 union select to_char(t.month_id||'-'||(to_char(sysdate,'yyyy')))||','||'28-'||t.abbr||'-'||(to_char(sysdate,'yyyy')),to_char(to_char(t.abbr)||'-'||(to_char(sysdate,'yyyy'))),t.month_id,to_char(to_number(to_char(sysdate,'yyyy'))+1) yr from month t where t.month_id<4 order by yr,month_id"
'                    '    str = "select to_char(to_date('31/dec/9000'),'mm-yyyy')||','||to_date('31/dec/9000') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') ||','||to_date(m1.sal_dt,'dd-MON-yyyy') as sal_dt,to_char(m1.sal_dt,'MON-yyyy') from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy')||','||to_date(m2.sal_dt,'dd-MON-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where (to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')-1) or (to_char(m2.sal_dt,'mm')<=03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')) order by sal_dt desc"
'                End If

'                dt = oh.ExecuteDataSet(str).Tables(0)
'                Return dt
'            End If
'            If id = 67 Then
'                sql = "select to_char(sysdate,'MM') from dual"
'                dt = oh.ExecuteDataSet(sql).Tables(0)
'            End If

'            Return dt
'            'If id = 31 Then   'Employees in eTDSEmployee is Showing..!!
'            '    sql = "select 0 as emp_id,' --SELECT EMPLOYEE--' as emp_name from dual union select et.emp_id,et.emp_id||'  -  '||em.emp_name from etds_employee et,employee_master em where et.emp_id=em.emp_code order by emp_id"
'            '    dt = oh.ExecuteDataSet(sql).Tables(0)
'            'End If
'            'If id = 32 Then   'Category in eTDS Category is Showing..!!
'            '    sql = "select 0,upper(' --Select Category--') as Category_name from dual union select ec.category_id,upper(ec.category_name) from etds_category ec where ec.category_id>0 order by category_name"
'            '    dt = oh.ExecuteDataSet(sql).Tables(0)
'            'End If
'            'If id = 34 Then   'From date Showing..!!
'            '    If Today.Month = 4 Then
'            '        sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy') as sal_dt,'--SELECT MONTH--' from dual union SELECT TO_CHAR(Sysdate,'mm-yyyy') as sal_dt,TO_CHAR(Sysdate,'MON-yyyy') FROM DUAL order by sal_dt desc"
'            '    Else
'            '        If Today.Month > 4 Then
'            '            sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') as sal_dt,to_char(m1.sal_dt,'MON-yyyy') from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy') union SELECT TO_CHAR(Sysdate,'mm-yyyy') as sal_dt,TO_CHAR(Sysdate,'MON-yyyy') FROM DUAL order by sal_dt desc"
'            '        Else
'            '            sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') as sal_dt,to_char(m1.sal_dt,'MON-yyyy') from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where (to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')-1) or (to_char(m2.sal_dt,'mm')<=03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')) union SELECT TO_CHAR(Sysdate,'mm-yyyy') as sal_dt,TO_CHAR(Sysdate,'MON-yyyy') FROM DUAL  order by sal_dt desc"
'            '        End If
'            '    End If
'            '    dt = oh.ExecuteDataSet(sql).Tables(0)
'            'End If
'            'If id = 35 Then   'Employees in eTDSEmployee is Showing..!!
'            '    sql = "select et.emp_id,et.emp_id||'     '||em.emp_name from etds_employee et,employee_master em where et.emp_id=em.emp_code order by emp_name"
'            '    dt = oh.ExecuteDataSet(sql).Tables(0)
'            'End If

'            'If id = 4 Then
'            '    sql = "select ed.emp_id,ed.deducted_month,ed.tds_amt,ed.surcharge,ed.edu_cess from  etds_deducted  ed,employee_master e where ed.emp_id=e.emp_code and ed.tds_status=1 and ed.tds_amt>0 order by ed.deducted_month,ed.emp_id"
'            '    dt = oh.ExecuteDataSet(sql).Tables(0)
'            'End If

'            'If id = 55 Then
'            '    If Today.Month >= 5 Then
'            '        sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy')||','||to_date('31/dec/9000') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') ||','||to_date(m1.sal_dt,'dd-MON-yyyy')  as sal_dt,to_char(m1.sal_dt,'MON-yyyy')from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy') order by sal_dt desc"
'            '    Else
'            '        sql = "select to_char(to_date('31/dec/9000'),'mm-yyyy')||','||to_date('31/dec/9000') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') ||','||to_date(m1.sal_dt,'dd-MON-yyyy') as sal_dt,to_char(m1.sal_dt,'MON-yyyy') from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy')||','||to_date(m2.sal_dt,'dd-MON-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where (to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')-1) or (to_char(m2.sal_dt,'mm')<=03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')) order by sal_dt desc"
'            '    End If
'            '    dt = oh.ExecuteDataSet(sql).Tables(0)
'            'End If
'            'If id = 56 Then
'            '    Dim str As String
'            '    If Today.Month >= 4 Then
'            '        str = "select '0','--SELECT MONTH--',0 as month_id,'0' as yr from dual union select to_char(t.month_id||'-'||to_char(sysdate,'yyyy'))||','||'28-'||t.abbr||'-'||to_char(sysdate,'yyyy'),to_char(to_char(t.abbr)||'-'||to_char(sysdate,'yyyy')),t.month_id,to_char(sysdate,'yyyy') yr from month t where t.month_id>3 union select to_char(t.month_id||'-'||((to_char(sysdate,'yyyy'))+1))||','||'28-'||t.abbr||'-'||((to_char(sysdate,'yyyy'))+1),to_char(to_char(t.abbr)||'-'||((to_char(sysdate,'yyyy'))+1)),t.month_id,to_char(to_number(to_char(sysdate,'yyyy'))+1) yr from month t where t.month_id<4 order by yr,month_id"
'            '    Else
'            '        str = "select '0','--SELECT MONTH--',0 as month_id,'0' as yr from dual union select to_char(t.month_id||'-'||((to_char(sysdate,'yyyy'))-1))||','||'28-'||t.abbr||'-'||(to_char(sysdate,'yyyy')-1),to_char(to_char(t.abbr)||'-'||(to_char(sysdate,'yyyy')-1)),t.month_id,to_char(sysdate,'yyyy') yr from month t where t.month_id>3 union select to_char(t.month_id||'-'||(to_char(sysdate,'yyyy')))||','||'28-'||t.abbr||'-'||(to_char(sysdate,'yyyy')),to_char(to_char(t.abbr)||'-'||(to_char(sysdate,'yyyy'))),t.month_id,to_char(to_number(to_char(sysdate,'yyyy'))+1) yr from month t where t.month_id<4 order by yr,month_id"
'            '        '    str = "select to_char(to_date('31/dec/9000'),'mm-yyyy')||','||to_date('31/dec/9000') as sal_dt,'--SELECT MONTH--' from dual union select distinct to_char(m1.sal_dt,'mm-yyyy') ||','||to_date(m1.sal_dt,'dd-MON-yyyy') as sal_dt,to_char(m1.sal_dt,'MON-yyyy') from m_wage m1 union select distinct to_char(m2.sal_dt,'mm-yyyy')||','||to_date(m2.sal_dt,'dd-MON-yyyy') as sal_dt,to_char(m2.sal_dt,'MON-yyyy') from m_wage_his m2 where (to_char(m2.sal_dt,'mm')>03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')-1) or (to_char(m2.sal_dt,'mm')<=03 and to_char(m2.sal_dt,'yyyy')=to_char(sysdate,'yyyy')) order by sal_dt desc"
'            '    End If

'            '    dt = oh.ExecuteDataSet(str).Tables(0)
'            '    Return dt
'            'End If
'            'If id = 67 Then
'            '    sql = "select to_char(sysdate,'MM') from dual"
'            '    dt = oh.ExecuteDataSet(sql).Tables(0)
'            'End If

'            'Return dt
'        End Function
'        Public Function tds_confirm(ByVal tid As Integer, ByVal str As String) As String Implements TDS_IDAL.ITDS.TDS_INT.tds_confirm
'            If tid = 4 Then
'                Try
'                    Dim param(1) As OracleParameter
'                    param(0) = New OracleParameter("str", OracleType.VarChar, 500)
'                    param(0).Direction = ParameterDirection.InputOutput
'                    param(0).Value = str
'                    param(1) = New OracleParameter("flag", OracleType.Number, 2)
'                    param(1).Direction = ParameterDirection.InputOutput
'                    param(1).Value = 0
'                    oh.ExecuteNonQuery("proc_etds_dep", param)
'                    str = param(0).Value
'                Catch ex As Exception
'                    str = ex.Message
'                Finally
'                End Try
'            End If

'            If tid = 8 Then
'                Try
'                    Dim param(1) As OracleParameter
'                    param(0) = New OracleParameter("str", OracleType.VarChar, 500)
'                    param(0).Direction = ParameterDirection.InputOutput
'                    param(0).Value = str
'                    param(1) = New OracleParameter("flag", OracleType.Number, 2)
'                    param(1).Direction = ParameterDirection.InputOutput
'                    param(1).Value = 0
'                    oh.ExecuteNonQuery("proc_etds_ack", param)
'                    str = param(0).Value & "%" & param(1).Value
'                Catch ex As Exception
'                    str = ex.Message
'                Finally
'                End Try
'            End If

'            If tid = 33 Then   ' for TDS Other Details Insertion CONFIRM..!!
'                Try
'                    Dim params(1) As OracleParameter
'                    params(0) = New OracleParameter("othdetails", OracleType.VarChar, 1000)
'                    params(0).Value = str
'                    params(0).Direction = ParameterDirection.Input
'                    params(1) = New OracleParameter("ReturnMessage", OracleType.VarChar, 500)
'                    params(1).Direction = ParameterDirection.Output
'                    oh.ExecuteNonQuery("etds_other_details", params)
'                    str = params(1).Value.ToString
'                Catch ex As Exception
'                    str = ex.Message.ToString
'                End Try
'            End If

'            If tid = 11 Then
'                Dim param(1) As OracleParameter
'                param(0) = New OracleParameter("str", OracleType.VarChar)
'                param(0).Direction = ParameterDirection.Input
'                param(0).Value = str
'                param(1) = New OracleParameter("err_stat", OracleType.Number)
'                param(1).Direction = ParameterDirection.Output
'                oh.ExecuteNonQuery("eTDS_add_employee", param)
'                str = param(1).Value
'            End If

'            If tid = 55 Then
'                Dim param(1) As OracleParameter
'                param(0) = New OracleParameter("str", OracleType.VarChar)
'                param(0).Direction = ParameterDirection.Input
'                param(0).Value = str
'                param(1) = New OracleParameter("err_stat", OracleType.Number)
'                param(1).Direction = ParameterDirection.Output
'                oh.ExecuteNonQuery("eTDS_deduction_request", param)
'                str = param(1).Value
'            End If
'            Return str
'        End Function
'        Public Function tds_other_type_fill(ByVal id As Integer, ByVal category_id As Integer) As System.Data.DataTable Implements TDS_IDAL.ITDS.TDS_INT.tds_other_type_fill
'            Dim str As String = ""
'            If id = 1 Then  'get respective Types of a Category..!!
'                str = "select et.type_id,upper(et.type_name) from etds_type et where et.category_id=" & category_id & " order by et.type_name"
'                dt = oh.ExecuteDataSet(str).Tables(0)
'            End If

'            If id = 2 Then 'her  category id is Employee Code..!!
'                If Today.Month >= 4 Then
'                    str = "select ee.emp_id||'*'||em.emp_name||'*'||ec.category_id||'*'||ec.category_name||'*'||et.type_id||'*'||et.type_name||'*'||round(nvl(eo.amount,0),2)||'*'||to_char(eo.sal_date,'mm-YYYY')||'*'||to_char(eo.sal_date,'MON-YYYY')||'*'||decode(et.etds_type,'C','CREDIT','D','DEBIT','NS') from  eTDS_Employee ee,eTDS_Others eo,employee_master em,eTDS_Type et,eTDS_Category ec where ee.emp_id=eo.emp_id and ee.emp_id=em.emp_code and eo.type_id=et.type_id and et.category_id=ec.category_id and ee.emp_id=" & category_id & " and eo.sal_date between to_date('1/apr/'||(to_char(sysdate,'yyyy'))) and to_date('31/mar/'||((to_char(sysdate,'yyyy')+1))) order by ec.category_name"
'                Else
'                    str = "select ee.emp_id||'*'||em.emp_name||'*'||ec.category_id||'*'||ec.category_name||'*'||et.type_id||'*'||et.type_name||'*'||round(nvl(eo.amount,0),2)||'*'||to_char(eo.sal_date,'mm-YYYY')||'*'||to_char(eo.sal_date,'MON-YYYY')||'*'||decode(et.etds_type,'C','CREDIT','D','DEBIT','NS') from  eTDS_Employee ee,eTDS_Others eo,employee_master em,eTDS_Type et,eTDS_Category ec where ee.emp_id=eo.emp_id and ee.emp_id=em.emp_code and eo.type_id=et.type_id and et.category_id=ec.category_id and ee.emp_id=" & category_id & " and eo.sal_date between to_date('1/apr/'||((to_char(sysdate,'yyyy'))-1)) and to_date('31/mar/'||(to_char(sysdate,'yyyy'))) order by ec.category_name"
'                End If
'                dt = oh.ExecuteDataSet(str).Tables(0)
'            End If

'            If id = 3 Then
'                str = "select emp_name from employee_master where emp_code=" & category_id & ""
'                dt = oh.ExecuteDataSet(str).Tables(0)
'            End If

'            If id = 4 Then
'                str = "select FLOOR( MONTHS_BETWEEN( CURRENT_DATE, t.birth_date) / 12 ) from employ_personal_dtl t where t.emp_code=" & category_id & ""
'                dt = oh.ExecuteDataSet(str).Tables(0)
'            End If

'            If id = 11 Then
'                Dim dt1, dt2, dt3 As New DataTable
'                dt3 = oh.ExecuteDataSet("select em.emp_code from employee_master_dtl em,employee_master es where add_months(em.discont_dt,1)>=to_date(sysdate) and  em.emp_code=es.emp_code and es.status_id<>1 and  em.emp_code=" & category_id & " union select em.emp_code from employee_master_dtl em,employee_master es where  em.emp_code=es.emp_code and es.status_id=1 and  em.emp_code=" & category_id & "").Tables(0)
'                If dt3.Rows.Count = 0 Then
'                    Return dt3
'                Else
'                    dt1 = oh.ExecuteDataSet("select count(emp_id)||'^^' from etds_employee where emp_id=" & category_id & "").Tables(0)
'                    Dim ss() As String
'                    ss = dt1.Rows(0)(0).ToString.Split("^")
'                    If ss(0) = 0 Then
'                        dt2 = oh.ExecuteDataSet("select ep.emp_code||'^'||ep.emp_name||'^'||ep.sex||'^'||to_char(ep.birth_date,'DD/MM/YYYY') from employ_personal_dtl ep where ep.emp_code=" & category_id & "").Tables(0)
'                        If dt2.Rows.Count > 0 Then
'                            Return dt2
'                        End If
'                    Else
'                        Return dt1
'                    End If
'                End If
'            End If

'            If id = 55 Then
'                dt = oh.ExecuteDataSet("select emp_id from etds_employee where emp_id=" & category_id & "").Tables(0)
'                If dt.Rows.Count <> 0 Then
'                    dt = oh.ExecuteDataSet("select em.emp_code||'@'||em.emp_name||'@'||dp.dep_name||'@'||br.branch_name from employee_master em,department_mst dp,branch_master br where em.department_id=dp.dep_id and em.branch_id=br.branch_id and em.emp_code=" & category_id & "").Tables(0)
'                    If dt.Rows.Count > 0 Then
'                        Return dt
'                    End If
'                Else
'                    Return dt
'                End If
'            End If

'            If id = 23 Then
'                dt = oh.ExecuteDataSet("select count(*) from etds_employee where emp_id=" & category_id & "").Tables(0)
'            End If

'            If id = 25 Then
'                If Date.Now.Month > 3 Then
'                    str = "select to_char(w.SAL_DT,'mon/yyyy'),w.BASIC_PAY,w.VDA,w.LOP,w.BONUS,w.EXGRATIA,w.P_TAX,w.P_FUND,w.LIC from mwage_all w where w.EMP_CODE=" & category_id & " and w.SAL_DT between to_date('1/apr/'||to_char(sysdate,'yyyy')) and to_date('31/mar/'||(to_char(sysdate,'yyyy')+1)) order by w.SAL_DT"
'                Else
'                    str = "select to_char(w.SAL_DT,'mon/yyyy'),w.BASIC_PAY,w.VDA,w.LOP,w.BONUS,w.EXGRATIA,w.P_TAX,w.P_FUND,w.LIC from mwage_all w where w.EMP_CODE=" & category_id & " and w.SAL_DT between to_date('1/apr/'||(to_char(sysdate,'yyyy')-1)) and to_date('31/mar/'||to_char(sysdate,'yyyy')) order by w.SAL_DT"
'                End If
'                dt = oh.ExecuteDataSet(str).Tables(0)
'            End If

'            If id = 24 Then
'                str = "select e.emp_name,t.pan_no,d.dep_name from etds_employee t,employee_master e,department_mst d where t.emp_id=e.emp_code and e.department_id=d.dep_id and t.emp_id=" & category_id & ""
'                dt = oh.ExecuteDataSet(str).Tables(0)
'            End If

'            If id = 26 Then
'                str = "select count(*) from form_accessibility t where t.emp_id=" & id & " and t.form_id=" & category_id & ""
'                dt = oh.ExecuteDataSet(str).Tables(0)
'            End If

'            If id = 27 Then
'                str = "select count(*) from etds_employee where emp_id=" & category_id & ""
'                dt = oh.ExecuteDataSet(str).Tables(0)
'            End If

'            If id = 28 Then
'                str = "select count(*) from ETDS_POSSIBLE_EMPLOYEES where emp_code=" & category_id & ""
'                dt = oh.ExecuteDataSet(str).Tables(0)
'            End If

'            Return dt
'        End Function
'        Public Function tds_disp(ByVal id As Integer, ByVal emp_id As String) As String Implements TDS_IDAL.ITDS.TDS_INT.tds_disp
'            If id = 1 Then
'                Dim st As String
'                Dim p(8) As OracleParameter
'                p(0) = New OracleParameter("emid", OracleType.Number, 5)
'                p(0).Value = emp_id
'                p(1) = New OracleParameter("one_mon_sal", OracleType.Double)
'                p(1).Direction = ParameterDirection.Output
'                p(2) = New OracleParameter("tot_sal", OracleType.Double)
'                p(2).Direction = ParameterDirection.Output

'                p(3) = New OracleParameter("ded_amt", OracleType.Double)
'                p(3).Direction = ParameterDirection.Output
'                p(4) = New OracleParameter("inc_amt", OracleType.Double)
'                p(4).Direction = ParameterDirection.Output

'                p(5) = New OracleParameter("tax_amt", OracleType.Double)
'                p(5).Direction = ParameterDirection.Output
'                p(6) = New OracleParameter("tds_ded", OracleType.Number)
'                p(6).Direction = ParameterDirection.Output


'                p(7) = New OracleParameter("err_stat", OracleType.Number)
'                p(7).Direction = ParameterDirection.Output
'                p(8) = New OracleParameter("err_msg", OracleType.VarChar, 1000)
'                p(8).Direction = ParameterDirection.Output

'                oh.ExecuteNonQuery("etds_disp_sal", p)
'                st = p(7).Value & "#" & p(8).Value & "#" & p(1).Value & "#" & p(2).Value & "#" & p(3).Value & "#" & p(4).Value & "#" & p(5).Value & "#" & p(6).Value
'                Return st
'            End If
'        End Function
'        Public Function tds_exp(ByVal id As Integer, ByVal emp_id As Integer, ByVal amount As Double) As String Implements TDS_IDAL.ITDS.TDS_INT.tds_exp
'            If id = 1 Then
'                Dim st As String
'                Dim p(4) As OracleParameter
'                p(0) = New OracleParameter("emid", OracleType.Number, 5)
'                p(0).Value = emp_id
'                p(1) = New OracleParameter("tot_income", OracleType.Double)
'                p(1).Value = amount
'                p(2) = New OracleParameter("tax_amot", OracleType.Double)
'                p(2).Direction = ParameterDirection.Output
'                p(3) = New OracleParameter("err_st", OracleType.Number)
'                p(3).Direction = ParameterDirection.Output
'                p(4) = New OracleParameter("err_mg", OracleType.VarChar, 1000)
'                p(4).Direction = ParameterDirection.Output

'                oh.ExecuteNonQuery("etds_tda_calc", p)
'                st = p(3).Value & "#" & p(4).Value & "#" & p(2).Value
'                Return st
'            End If

'        End Function
'        Public Function tds_rep(ByVal id As Integer, ByVal emp_id As Integer, ByVal month As String) As System.Data.DataTable Implements TDS_IDAL.ITDS.TDS_INT.tds_rep
'            If id = 26 Then
'                sql = "select nvl(sum(ia.ALL_AMOUNT),0) from incallow_all ia where ia.EMP_CODE=" & emp_id & " and to_char(ia.PR_DATE,'mon/yyyy')='" & month & "' and ia.ALL_ID=3"
'            End If

'            If id = 27 Then
'                sql = "select nvl(sum(ia.ALL_AMOUNT),0) from incallow_all ia where ia.EMP_CODE=" & emp_id & " and to_char(ia.PR_DATE,'mon/yyyy')='" & month & "' and ia.ALL_ID=1"
'            End If

'            If id = 28 Then
'                sql = "select nvl(sum(ia.ALL_AMOUNT),0) from incallow_all ia where ia.EMP_CODE=" & emp_id & " and to_char(ia.PR_DATE,'mon/yyyy')='" & month & "' and ia.ALL_ID=7"
'            End If

'            If id = 29 Then
'                sql = "select nvl(sum(t.pat_amt),0) from hrm_pat_inc t where t.emp_code=" & emp_id & " and to_char(t.sal_dt,'mon/yyyy')='" & month & "'"
'            End If

'            If id = 30 Then
'                sql = "select nvl(sum(t.tds_amt)+sum(t.surcharge)+sum(t.edu_cess),0) from etds_deducted t where t.emp_id=" & emp_id & " and to_char(t.deducted_month,'mon/yyyy')='" & month & "'"
'            End If

'            If id = 31 Then
'                sql = "select count(*) from etds_possible_employees t where t.emp_code=" & emp_id & " "
'                dt = oh.ExecuteDataSet(sql).Tables(0)
'            End If

'            If id = 57 Then
'                sql = "select count(t.ack_no) from etds_ack t where t.tds_year=" & emp_id & " and t.quarter=" & month & ""
'                dt = oh.ExecuteDataSet(sql).Tables(0)
'            End If

'            Return dt
'        End Function

'    End Class
'End Namespace
