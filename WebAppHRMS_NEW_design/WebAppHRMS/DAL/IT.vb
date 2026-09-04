Imports Microsoft.VisualBasic
Imports System.Data.OracleClient
Imports System.Data
'Imports IT.IDAL
Namespace IT.DAL
    Public Class Common
        Inherits System.Web.UI.Page
        Implements IT.IDAL.ICommon
        Dim OH As New helper.oracle.OracleHelper
        Dim DT As New DataTable
        Public Function FillBank(ByVal BranchID As Integer, ByVal FirmID As Integer) As System.Data.DataTable Implements IDAL.ICommon.FillBank
            DT = OH.ExecuteDataSet("select parent_acc||'~'||account_no as account,account_no||'-'||account_name from SUBSIDARY_MASTER where parent_acc = 32100 and status_id = 1 and branch_id = " & BranchID & " and firm_id = " & FirmID & " union all select a.account_no||'~0' as account,a.account_no||'-'||a.account_name from ACCOUNT_PROFILE a,ACCOUNT_STATUS b where b.branch_id = " & BranchID & " and b.firm_id = " & FirmID & " and b.status_id = 4 and b.account_no = a.account_no order by account").Tables(0)
            Return DT
        End Function
        Public Function FillBranch() As System.Data.DataTable Implements IDAL.ICommon.FillBranch
            DT = OH.ExecuteDataSet("select t.branch_id,t.branch_name from BRANCH_MASTER t,active_firms a where a.firm_id=" & Me.Session("firm_id") & " and a.branch_id=t.branch_id order by branch_name").Tables(0)
            Return DT
        End Function
        Public Function fillPincode(ByVal postid As Integer) As System.Data.DataTable Implements IDAL.ICommon.FillPincode
            DT = OH.ExecuteDataSet("select pin_code,post_office from post_master where sr_number = " & postid & "").Tables(0)
            Return DT
        End Function
        Public Function FillPostupd(ByVal DistrictID As Integer) As System.Data.DataTable Implements IDAL.ICommon.FillPostupd
            DT = OH.ExecuteDataSet("select to_char(-1) post_code, '----------SELECT----------' post_office from dual union select sr_number || '^' || pin_code as post_code, post_office from post_master where district_id = " & DistrictID & " order by post_office").Tables(0)
            Return DT
        End Function
        Public Function FillDistrictupd(ByVal StateID As Integer) As System.Data.DataTable Implements IDAL.ICommon.FillDistrictupd
            DT = OH.ExecuteDataSet("select -1 district_id, '----------SELECT----------' district_name  from dual union select district_id,district_name from DISTRICT_MASTER where state_id = " & StateID & " order by district_name").Tables(0)
            Return DT
        End Function
        Public Function FillStateupd() As System.Data.DataTable Implements IDAL.ICommon.FillStateupd
            DT = OH.ExecuteDataSet("select -1 state_id, '----------SELECT----------' state_name  from dual union select state_id,state_name from STATE_MASTER order by state_name").Tables(0)
            Return DT
        End Function
        Public Function FillSignatory(ByVal BranchID As Integer, ByVal FirmID As Integer, ByVal ParentAccount As Integer, ByVal SubAccount As Integer) As System.Data.DataTable Implements IDAL.ICommon.FillSignatory
            DT = OH.ExecuteDataSet("select gm||','||agm||','||am||','||employee1||','||employee2||','||employee3 from AUTHORIZER_DTL where branch_id = " & BranchID & " and firm_id = " & FirmID & " and parent_acc = " & ParentAccount & " and sub_acc = " & SubAccount & " and status = 1").Tables(0)
            If DT.Rows.Count > 0 Then
                DT = OH.ExecuteDataSet("select emp_code,emp_name from EMPLOYEE_MASTER where emp_code in (" & DT.Rows(0)(0) & ")").Tables(0)
            End If
            Return DT
        End Function
        Public Function FillCommonBank() As System.Data.DataTable Implements IDAL.ICommon.FillCommonBank
            DT = OH.ExecuteDataSet("select bank_id,name from BANK order by name").Tables(0)
            Return DT
        End Function
        Public Function FillState() As System.Data.DataTable Implements IDAL.ICommon.FillState
            DT = OH.ExecuteDataSet("select state_id,state_name from STATE_MASTER order by state_name").Tables(0)
            Return DT
        End Function
        Public Function FillDistrict(ByVal StateID As Integer) As System.Data.DataTable Implements IDAL.ICommon.FillDistrict
            DT = OH.ExecuteDataSet("select district_id,district_name from DISTRICT_MASTER where state_id = " & StateID & " order by district_name").Tables(0)
            Return DT
        End Function
        Public Function FillPost(ByVal DistrictID As Integer) As System.Data.DataTable Implements IDAL.ICommon.FillPost
            DT = OH.ExecuteDataSet("select sr_number||'^'||pin_code,post_office from post_master where district_id = " & DistrictID & " order by post_office").Tables(0)
            Return DT
        End Function
        Public Function CheckAccess(ByVal FormID As Integer, ByVal EmpID As Integer) As System.Data.DataTable Implements IDAL.ICommon.CheckAccess
            DT = OH.ExecuteDataSet("select * from FORM_ACCESSIBILITY where form_id=" & FormID & " and emp_id=" & EmpID & "").Tables(0)
            Return DT
        End Function
        Public Function FillActiveFirms(ByVal BranchID As Integer) As System.Data.DataTable Implements IDAL.ICommon.FillActiveFirms
            DT = OH.ExecuteDataSet("select af.firm_id,fm.firm_abbr from active_firms af ,firm_master fm where af.branch_id=" & BranchID & " and af.firm_id=fm.firm_id").Tables(0)
            Return DT
        End Function
        Public Function FillFundTransferFirms(ByVal BranchID As Integer, ByVal FirmID As Integer) As System.Data.DataTable Implements IDAL.ICommon.FillFundTransferFirms
            If BranchID = 0 Then
                DT = OH.ExecuteDataSet("select firm_id,firm_abbr from firm_master where firm_id = " & FirmID & "").Tables(0)
            Else
                DT = OH.ExecuteDataSet("select firm_id,firm_abbr from firm_master where firm_id= " & FirmID & " union all select af.firm_id,fm.firm_abbr from active_firms af ,firm_master fm, AO_FUND f where af.branch_id=" & BranchID & " and af.firm_id = fm.firm_id and f.from_firm = " & FirmID & " and f.to_firm = af.firm_id").Tables(0)
            End If
            Return DT
        End Function
        Public Function MabenCheckAccess(ByVal FormID As Integer, ByVal EmpID As Integer, ByVal BranchID As Integer) As System.Data.DataTable Implements IDAL.ICommon.MabenCheckAccess
            DT = OH.ExecuteDataSet("select * from FORM_ACCESSIBILITY t, employee_master a where t.form_id = " & FormID & " and t.emp_id = " & EmpID & " and t.emp_id = a.emp_code and a.branch_id = " & BranchID & "").Tables(0)
            Return DT
        End Function
    End Class
End Namespace