Imports system.data
Imports System.Data.OracleClient
Partial Class Attend_Regularisation_hrm_atten_reg_web_rpt_4e98dede4169
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim RH As New WholeHelper.ClsRepCtrl
    Dim tb As New Table
    Dim BranchName As String
    Dim dr As DataRow
    Dim tot_count As Double
    Dim UserAll(), BranchAll() As String
    Dim UserCode, BranchId As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Frdt As String = Request.QueryString.Get("Fdt")
        Dim Todt As String = Request.QueryString.Get("Tdt")
        BranchAll = Me.Session("branch_id").ToString.Split("!")
        BranchId = BranchAll(0)

        dt = oh.ExecuteDataSet("select branch_name from branch_master where branch_id=" & BranchId & "").Tables(0)
        RH.Heading(Session("branch_id"), Session("branch_name"), Session("firm_name"), tb, "ATTENDANCE REGULARISATION REPORT OF " & dt.Rows(0)(0) & "", 18)
        dt = oh.ExecuteDataSet("select r.requested_by || '-' || e.emp_name as reqby,to_char(to_date(r.requested_dt)) as reqdt,r.remarks as remark,'LATE' as reqtype,decode(r.status_id,0,'APPLIED',9,'AM RECOMMENDED',8,'RM RECOMMENDED',7,'AM REJECTED',6,'RM REJECTED',2,'RH RECOMMENDED',3,'RH REJECTED',1,'SANCTIONED',4,'REJECTED',10,'APPLIED',11,'RECOMMEND',12,'SANCTIONED') as status,r.status_id,r.am_recomm as AM,r.am_recomm_reason as AMreason,r.rm_recomm as approv,r.rm_recomm_reason as appreason,r.requested_by from hrm_anytimepunching_reg r, employee_master e where r.requested_by = e.emp_code and r.branch_id = " & BranchId & " and to_date(r.requested_dt) between to_date(' " & Frdt & " ') and to_date(' " & Todt & " ') and r.not_punch is null union select r.requested_by || '-' || e.emp_name as reqby,to_char(to_date(r.att_req_dt)) as reqdt,b.failure_name as remark,'NON MARKING' as reqtype,decode(r.status_id,0,'APPLIED',2,'AM RECOMMENDED',3,'RM RECOMMENDED',5,'AM REJECTED',6,'RM REJECTED',4,'RH RECOMMENDED',7,'RH REJECTED',1,'SANCTIONED',8,'REJECTED',10,'APPLIED',11,'RECOMMEND',12,'SANCTIONED') as status,r.status_id,r.am_recomm as AM,r.am_recomm_reason as AMreason,r.rm_recomm as approv,r.rm_recomm_reason,r.requested_by from hrm_anytimepunching_reg r, employee_master e, branch_failure b where r.requested_by = e.emp_code and r.remarks = b.failure_id and r.branch_id = " & BranchId & " and to_date(r.att_req_dt) between to_date(' " & Frdt & " ') and to_date(' " & Todt & " ') and r.not_punch is not null union select a.requested_by || '-' || e.emp_name as reqby,to_char(to_date(a.requested_dt)) as reqdt,a.requested_reason as remark,'All Late' as reqtype,decode(a.status_id,0,'APPLIED',5,'AM RECOMMENDED',6,'AM REJECTED',1,'SANCTIONED',2,'REJECTED') as status,a.status_id,a.recommended_by as AM,a.am_recom_reason as AMreason,a.approved_by as approv,a.am_recom_reason as appreason,a.requested_by from hrm_attendance_regularisation a, employee_master e where a.requested_by = e.emp_code and to_date(a.requested_dt) >= ' " & Frdt & " ' and to_date(a.requested_dt) <= ' " & Todt & " ' and a.branch_id = " & BranchId & " order by reqdt").Tables(0)
        Dim tr07 As New TableRow
        Dim tr07_01, tr07_02, tr07_021, tr07_03, tr07_04, tr07_05, tr07_06, tr07_07 As New TableCell
        RH.AddColumn(tr07, tr07_01, 2, 10, "l", "REQUESTED&nbsp;BY&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_02, 2, 10, "l", "REQ&nbsp;DATE&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_03, 2, 10, "l", "REQUESTED&nbsp;REASON&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_04, 2, 10, "l", "REQUESTED&nbsp;TYPE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_05, 2, 10, "l", "APPLIED&nbsp;STATUS&nbsp;")
        RH.AddColumn(tr07, tr07_06, 8, 10, "l", "SANCTIONED&nbsp;/&nbsp;REJECTED&nbsp;BY-&nbsp;POST-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;REASON&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        tb.Controls.Add(tr07)
        RH.DrawLine(tb, 18)
        Dim RowBG As Integer = 0
        Dim ItemTotal As Integer = 0
        tot_count = 0
        For Each dr In dt.Rows
            Dim tr09 As New TableRow
            Dim tr09_01, tr09_02, tr09_03, tr09_04, tr09_05, tr09_06, tr09_07 As New TableCell
            If RowBG = 0 Then
                tr09.BackColor = Drawing.Color.AliceBlue
                RowBG = 1
            Else
                tr09.BackColor = Drawing.Color.WhiteSmoke
                RowBG = 0
            End If

            RH.AddColumn(tr09, tr09_01, 2, 10, "l", dr(0))
            'RH.AddColumn(tr09, tr09_02, 2, 10, "c", Format(dr(1), "dd/MMM/yyyy"))
            RH.AddColumn(tr09, tr09_02, 2, 10, "l", dr(1))
            RH.AddColumn(tr09, tr09_03, 2, 10, "l", dr(2))
            RH.AddColumn(tr09, tr09_04, 2, 10, "l", dr(3))
            RH.AddColumn(tr09, tr09_05, 2, 10, "l", dr(4))

            If (dr(3) = "NON MARKING" Or dr(3) = "LATE") Then
                If (dr(5) = 1 Or dr(5) = 8 Or dr(5) = 4) Then
                    dt = oh.ExecuteDataSet("select e.emp_code||'-'||e.emp_name||'-'||p.post_name from employee_master e,hrm_anytimepunching_reg r,post_mst p where e.post_id=p.post_id and e.emp_code=r.rm_recomm and e.emp_code=" & dr(8) & "").Tables(0)
                    RH.AddColumn(tr09, tr09_06, 8, 10, "l", dt.Rows(0)(0) & " - " & "" & dr(9))
                End If
                If (dr(5) = 2 Or dr(5) = 5 Or dr(5) = 9 Or dr(5) = 7) Then
                    dt = oh.ExecuteDataSet("select e.emp_code||'-'||e.emp_name||'-'||p.post_name from employee_master e,hrm_anytimepunching_reg r,post_mst p where e.post_id=p.post_id and e.emp_code=r.am_recomm and e.emp_code=" & dr(6) & "").Tables(0)
                    RH.AddColumn(tr09, tr09_06, 8, 10, "l", dt.Rows(0)(0) & " - " & "" & dr(9))
                End If
                If (dr(5) = 0) Then
                    'dt = oh.ExecuteDataSet("select e.emp_code||'-'||e.emp_name||'-'||p.post_name from employee_master e,hrm_anytimepunching_reg r,post_mst p where e.post_id=p.post_id and e.emp_code=r.am_recomm and e.emp_code=" & dr(6) & "").Tables(0)
                    RH.AddColumn(tr09, tr09_06, 8, 10, "l", " - ")
                End If
            End If
            If (dr(3) = "NON MARKING") Then
                If (dr(5) = 20 Or dr(5) = 21) Then
                    dt = oh.ExecuteDataSet("select e.emp_code||'-'||e.emp_name||'-'||p.post_name from employee_master e,hrm_anytimepunching_reg r,post_mst p where e.post_id=p.post_id and e.emp_code=r.recommended_by and e.emp_code=" & dr(10) & "").Tables(0)
                    RH.AddColumn(tr09, tr09_06, 8, 10, "l", dt.Rows(0)(0) & " - " & "" & dr(9))
                End If
                If (dr(5) = 11 Or dr(5) = 14) Then
                    dt = oh.ExecuteDataSet("select e.emp_code||'-'||e.emp_name||'-'||p.post_name from employee_master e,hrm_anytimepunching_reg r,post_mst p where e.post_id=p.post_id and e.emp_code=r.rm_recomm and e.emp_code=" & dr(10) & "").Tables(0)
                    RH.AddColumn(tr09, tr09_06, 8, 10, "l", dt.Rows(0)(0) & " - " & "" & dr(9))
                End If
                If (dr(5) = 12 Or dr(5) = 14) Then
                    dt = oh.ExecuteDataSet("select e.emp_code||'-'||e.emp_name||'-'||p.post_name from employee_master e,hrm_anytimepunching_reg r,post_mst p where e.post_id=p.post_id and e.emp_code=r.approved_by and e.emp_code=" & dr(6) & "").Tables(0)
                    RH.AddColumn(tr09, tr09_06, 8, 10, "l", " - ")
                End If
                If (dr(5) = 10) Then
                    'dt = oh.ExecuteDataSet("select e.emp_code||'-'||e.emp_name||'-'||p.post_name from employee_master e,hrm_anytimepunching_reg r,post_mst p where e.post_id=p.post_id and e.emp_code=r.am_recomm and e.emp_code=" & dr(6) & "").Tables(0)
                    RH.AddColumn(tr09, tr09_06, 8, 10, "l", " - ")
                End If
            End If

            If (dr(3) = "LATE") Then
                If (dr(5) = 11 Or dr(5) = 14) Then
                    dt = oh.ExecuteDataSet("select e.emp_code||'-'||e.emp_name||'-'||p.post_name from employee_master e,hrm_anytimepunching_reg r,post_mst p where e.post_id=p.post_id and e.emp_code=r.recommended_by and e.emp_code=" & dr(10) & "").Tables(0)
                    RH.AddColumn(tr09, tr09_06, 8, 10, "l", dt.Rows(0)(0) & " - " & "" & dr(9))
                End If
                If (dr(5) = 20 Or dr(5) = 21) Then
                    dt = oh.ExecuteDataSet("select e.emp_code||'-'||e.emp_name||'-'||p.post_name from employee_master e,hrm_anytimepunching_reg r,post_mst p where e.post_id=p.post_id and e.emp_code=r.rm_recomm and e.emp_code=" & dr(10) & "").Tables(0)
                    RH.AddColumn(tr09, tr09_06, 8, 10, "l", dt.Rows(0)(0) & " - " & "" & dr(9))
                End If
                If (dr(5) = 12 Or dr(5) = 14) Then
                    dt = oh.ExecuteDataSet("select e.emp_code||'-'||e.emp_name||'-'||p.post_name from employee_master e,hrm_anytimepunching_reg r,post_mst p where e.post_id=p.post_id and e.emp_code=r.approved_by and e.emp_code=" & dr(6) & "").Tables(0)
                    RH.AddColumn(tr09, tr09_06, 8, 10, "l", " - ")
                End If
                If (dr(5) = 10) Then
                    'dt = oh.ExecuteDataSet("select e.emp_code||'-'||e.emp_name||'-'||p.post_name from employee_master e,hrm_anytimepunching_reg r,post_mst p where e.post_id=p.post_id and e.emp_code=r.am_recomm and e.emp_code=" & dr(6) & "").Tables(0)
                    RH.AddColumn(tr09, tr09_06, 8, 10, "l", " - ")
                End If
            End If

            If (dr(3) = "All Late") Then
                If (dr(5) = 1 Or dr(5) = 2) Then
                    dt = oh.ExecuteDataSet("select e.emp_code||'-'||e.emp_name||'-'||p.post_name from employee_master e,hrm_attendance_regularisation r,post_mst p where e.post_id=p.post_id and e.emp_code=r.approved_by and e.emp_code=" & dr(8) & "").Tables(0)
                    RH.AddColumn(tr09, tr09_06, 8, 10, "l", dt.Rows(0)(0) & " - " & "" & dr(9))
                End If
                If (dr(5) = 5 Or dr(5) = 6) Then
                    dt = oh.ExecuteDataSet("select e.emp_code||'-'||e.emp_name||'-'||p.post_name from employee_master e,hrm_attendance_regularisation r,post_mst p  where e.post_id=p.post_id and e.emp_code=r.recommended_by and e.emp_code=" & dr(6) & "").Tables(0)
                    RH.AddColumn(tr09, tr09_06, 8, 10, "l", dt.Rows(0)(0) & " - " & "" & dr(9))
                End If
                If (dr(5) = 0) Then
                    'dt = oh.ExecuteDataSet("select e.emp_code||'-'||e.emp_name||'-'||p.post_name from employee_master e,hrm_anytimepunching_reg r,post_mst p where e.post_id=p.post_id and e.emp_code=r.am_recomm and e.emp_code=" & dr(6) & "").Tables(0)
                    RH.AddColumn(tr09, tr09_06, 8, 10, "l", " - ")
                End If
                If (dr(5) = 10) Then
                    'dt = oh.ExecuteDataSet("select e.emp_code||'-'||e.emp_name||'-'||p.post_name from employee_master e,hrm_anytimepunching_reg r,post_mst p where e.post_id=p.post_id and e.emp_code=r.am_recomm and e.emp_code=" & dr(6) & "").Tables(0)
                    RH.AddColumn(tr09, tr09_06, 8, 10, "l", " - ")
                End If
            End If


            tb.Controls.Add(tr09)
            tot_count += 1
        Next
        RH.DrawLine(tb, 18)
        Dim tr10 As New TableRow
        Dim tr10_01, tr10_02 As New TableCell
        tr10.BackColor = Drawing.Color.WhiteSmoke
        RH.AddColumn(tr10, tr10_01, 2, 10, "l", "TOTAL:")
        RH.AddColumn(tr10, tr10_02, 16, 10, "l", tot_count)
        tb.Controls.Add(tr10)
        RH.DrawLine(tb, 18)
        Panel1.Controls.Add(tb)
    End Sub
End Class
