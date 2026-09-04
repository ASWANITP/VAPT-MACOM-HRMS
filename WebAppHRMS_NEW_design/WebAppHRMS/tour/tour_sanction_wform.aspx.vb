Imports System.Data
Imports System.Data.OracleClient
Imports System.IO

Partial Class Tour_Sanction_tour_sanction_wform_8621ff0f1998
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim dr As DataRow
    Dim str, str1 As String
    Dim ttype As Integer

    Dim res As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' CType(Me.Master, WebAppHRMS.edp).Subtitle = "<div style=""text-align: center; font-weight: bold; font-size: 14pt; color: #cc0099; font-family: 'Courier New'; text-decoration: underline;"">TOUR SANCTION</div>"
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.Txt_Branch.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Me.Cmb_TourDetails.Attributes.Add("onchange", "fill1()")
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "sub_call_receiver", "context")
        Dim cbscript As String = "function sub_call_server(arg,context) { " & cbref & "; } "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "sub_call_server", cbscript, True)
        Dim user As Array
        user = Session("user_id").ToString.Split("!")
        If Not IsPostBack Then            ' 


            'Dim dp As DataTable = oh.ExecuteDataSet("select count(*) from form_accessibility f where f.form_id=91 and f.emp_id=" & user(0)).Tables(0)
            'If dp.Rows(0)(0) = 0 Then
            '    Response.Redirect("../show_err.aspx")
            'End If
            pageload()
            'str = "select 0 as srnumber,'Please Select ' from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.tour_id=0 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.tour_id=0 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.tour_id=0 and ht.to_branch is null order by srnumber"
            'dt = oh.ExecuteDataSet(str).Tables(0)
            'Cmb_TourDetails.DataSource = dt
            'Cmb_TourDetails.DataValueField = dt.Columns(0).ColumnName
            'Cmb_TourDetails.DataTextField = dt.Columns(1).ColumnName
            'Cmb_TourDetails.DataBind()
        End If
    End Sub
    Sub pageload()
        Dim brid As Integer = Me.Session("branch_id")
        Dim ff As Integer = Me.Session("firm_id")
        Dim userid As String = Me.Session("user_id")
        Dim uid() As String = userid.Split("!")
        Dim ecode As Integer = uid(0)
        Me.ttype = 0
        Dim dt33 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & ecode & "").Tables(0)
        Try
            Dim para(5) As OracleParameter

            para(0) = New OracleParameter("tcase", OracleType.Number, 8)
            para(0).Value = Me.ttype
            para(0).Direction = ParameterDirection.Input

            para(1) = New OracleParameter("empcode", OracleType.Number, 5)
            para(1).Value = ecode
            para(1).Direction = ParameterDirection.Input

            para(2) = New OracleParameter("branchid", OracleType.Number, 5)
            para(2).Value = dt33.Rows(0)(0)
            para(2).Direction = ParameterDirection.Input

            para(3) = New OracleParameter("depid", OracleType.VarChar, 5000)
            para(3).Direction = ParameterDirection.Output

            para(4) = New OracleParameter("postid", OracleType.Number, 5)
            para(4).Direction = ParameterDirection.Output

            para(5) = New OracleParameter("flag", OracleType.Number, 2)
            para(5).Direction = ParameterDirection.Output

            oh.ExecuteDataSet("hrm_tour_sanction_rejection", para)

            If para(5).Value = 1 And ff <> 24 Then     ' Branch_id=0 and Dep_head<>0  ie Head office     and ht.dep_id=" & para(3).Value & "


                ' str = "select 0 as srnumber,'Please Select ' from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and  ht.branch_id=0 and ht.emp_code<>" & uid(0) & " and ht.tour_id=0 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and ht.tour_id=0 and ht.emp_code<>" & uid(0) & " and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and ht.tour_id=0 and ht.emp_code<>" & uid(0) & " and ht.to_branch is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id<>0 and  (" & para(3).Value & " ) in (4,23,37,5,38) and  ht.tour_id=0 and ht.emp_code<>" & uid(0) & " and  ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id<>0 and (" & para(3).Value & " ) in (4,23,37,5,38) and  ht.emp_code<>" & uid(0) & "  and ht.tour_id=0 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and (" & para(3).Value & " ) in (4,23,37,5,38) and  ht.emp_code<>" & uid(0) & " and ht.branch_id<>0 and ht.tour_id=0 and ht.to_branch is null order by srnumber"
                str = "select 0 as srnumber,'Please Select ' from dual  union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and em.department_id in (" & para(3).Value & ") and  em.branch_id=0 and ht.emp_code<>" & uid(0) & " and ht.tour_id in (0,4) and ht.to_branch=bm1.branch_id and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and ht.tour_id in (0,4) and ht.emp_code<>" & uid(0) & " and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and em.department_id in (" & para(3).Value & ") and em.branch_id=0 and ht.tour_id in (0,4) and ht.emp_code<>" & uid(0) & " and ht.to_branch is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (23) in (" & para(3).Value & " )   and  ht.tour_id in (4) and ht.emp_code<>" & uid(0) & " and  ht.to_branch=bm1.branch_id and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (23) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & "  and ht.tour_id in (4) and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and (23) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & " and ht.branch_id=0 and em.department_id<>20 and ht.tour_id in (4) and ht.to_branch is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (37) in (" & para(3).Value & " )   and  ht.tour_id in (0,4) and ht.emp_code<>" & uid(0) & " and  ht.to_branch=bm1.branch_id and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (37) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & "  and ht.tour_id in (0,4) and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and (37) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & " and ht.branch_id=0 and em.department_id<>20 and ht.tour_id in (0,4) and ht.to_branch is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (5) in (" & para(3).Value & " )   and  ht.tour_id in (0,4) and ht.emp_code<>" & uid(0) & " and  ht.to_branch=bm1.branch_id and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (5) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & "  and ht.tour_id in (0,4) and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and (5) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & " and ht.branch_id=0 and em.department_id<>20 and ht.tour_id in (0,4) and ht.to_branch is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (38) in (" & para(3).Value & " )   and  ht.tour_id in (0,4) and ht.emp_code<>" & uid(0) & " and  ht.to_branch=bm1.branch_id and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (38) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & "  and ht.tour_id in (0,4) and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and (38) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & " and ht.branch_id=0 and em.department_id<>20 and ht.tour_id in (0,4) and ht.to_branch is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (180) in (" & para(3).Value & " )   and  ht.tour_id in (4) and ht.emp_code<>" & uid(0) & " and  ht.to_branch=bm1.branch_id and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (180) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & "  and ht.tour_id in (4) and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and (180) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & " and ht.branch_id=0 and em.department_id<>20 and ht.tour_id in (4) and ht.to_branch is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (183) in (" & para(3).Value & " )   and  ht.tour_id in (4) and ht.emp_code<>" & uid(0) & " and  ht.to_branch=bm1.branch_id and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (183) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & "  and ht.tour_id in (4) and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and (183) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & " and ht.branch_id=0 and em.department_id<>20 and ht.tour_id in (4) and ht.to_branch is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & "  order by srnumber"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_TourDetails.DataSource = dt
                Cmb_TourDetails.DataValueField = dt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()
            ElseIf para(5).Value = 1 And ff = 24 Then
                str = "select 0 as srnumber,'Please Select ' from dual  union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,branch_master bm1  where ht.emp_code=em.emp_code  and em.department_id in (" & para(3).Value & ") and  em.branch_id=0 and ht.emp_code<>" & uid(0) & " and ht.tour_id in (0,4) and nvl(ht.to_branch,0)=bm1.branch_id and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union  select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and em.branch_id=0 and ht.tour_id in (0) and ht.emp_code<>" & uid(0) & "  and nvl(ht.to_branch,0)=bc1.old_id and bc1.branch_id is null and ht.SANCTION_PERSON<>" & uid(0) & "  and ht.recom_person<>" & uid(0) & " "
                Me.cmd_rec.Visible = False
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_TourDetails.DataSource = dt
                Cmb_TourDetails.DataValueField = dt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()
            ElseIf para(5).Value = 378 And ff = 24 Then
                str = "select 0 as srnumber,'Please Select ' from dual  union select ht.sr_number as srnumber, ht.emp_code || '       ' || em.emp_name || ' ' || to_char(ht.from_dt) || '-' || to_char(ht.to_dt) from hrm_tour_dtl ht, employee_master em, branch_master bc1 where ht.emp_code = em.emp_code and ht.dep_id in (select d.dep_id from department_mst d where d.firm_id = 24) and em.branch_id = 0 and ht.tour_id in (0, 4) and ht.emp_code <> " & uid(0) & " and ht.emp_code in (select d.dep_head  from department_mst d, employ_firm f where f.emp_code = d.dep_head and d.dep_head = ht.emp_code and f.firm_id = 24)  and bc1.branch_id =ht.branch_id and ht.SANCTION_PERSON <> " & uid(0) & " and ht.recom_person <> " & uid(0) & " union  select ht.sr_number as srnumber, ht.emp_code || '       ' || em.emp_name || ' ' || to_char(ht.from_dt) || '-' || to_char(ht.to_dt)from hrm_tour_dtl ht, employee_master em, branch_master bc1 where ht.emp_code = em.emp_code and ht.dep_id in (select d.dep_id from department_mst d where d.firm_id = 24) and em.branch_id = 0 and ht.tour_id in (0, 4) and ht.emp_code <> " & uid(0) & " and em.department_id in (select d.dep_id from department_mst d where d.dep_head=" & uid(0) & ") and bc1.branch_id = ht.branch_id  and ht.SANCTION_PERSON <> " & uid(0) & " and ht.recom_person <> " & uid(0) & ""
                Me.cmd_rec.Visible = False
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_TourDetails.DataSource = dt
                Cmb_TourDetails.DataValueField = dt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()
            ElseIf para(5).Value = 88 And ff = 24 Then
                str = "select 0 as srnumber,'Please Select ' from dual  union select ht.sr_number as srnumber, ht.emp_code || '       ' || em.emp_name || ' ' || to_char(ht.from_dt) || '-' || to_char(ht.to_dt) from hrm_tour_dtl ht, employee_master em, branch_master bc1,employ_firm f where ht.emp_code = em.emp_code and em.post_id=378 and em.emp_code=f.emp_code  and em.branch_id = 0 and f.firm_id=24  and ht.tour_id in (0, 4)  and ht.emp_code <> " & uid(0) & "  and bc1.branch_id = ht.branch_id and ht.SANCTION_PERSON <> " & uid(0) & "  and ht.recom_person <> " & uid(0) & ""
                Me.cmd_rec.Visible = False
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_TourDetails.DataSource = dt
                Cmb_TourDetails.DataValueField = dt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()
            ElseIf para(5).Value = 20 Then

                str = "select 0 as srnumber,'Please Select ' from dual  union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and em.department_id in (" & para(3).Value & ") and  em.branch_id=0 and ht.emp_code<>" & uid(0) & " and ht.tour_id in (4) and ht.to_branch=bm1.branch_id and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and ht.tour_id in (4) and ht.emp_code<>" & uid(0) & " and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and em.department_id in (" & para(3).Value & ") and em.branch_id=0 and ht.tour_id in (4) and ht.emp_code<>" & uid(0) & " and ht.to_branch is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (23) in (" & para(3).Value & " )   and  ht.tour_id in (4) and ht.emp_code<>" & uid(0) & " and  ht.to_branch=bm1.branch_id and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (23) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & "  and ht.tour_id in (4) and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and (23) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & " and ht.branch_id=0 and em.department_id<>20 and ht.tour_id in (4) and ht.to_branch is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (37) in (" & para(3).Value & " )   and  ht.tour_id in (4) and ht.emp_code<>" & uid(0) & " and  ht.to_branch=bm1.branch_id and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (37) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & "  and ht.tour_id in (4) and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and (37) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & " and ht.branch_id=0 and em.department_id<>20 and ht.tour_id in (4) and ht.to_branch is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (5) in (" & para(3).Value & " )   and  ht.tour_id in (4) and ht.emp_code<>" & uid(0) & " and  ht.to_branch=bm1.branch_id and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (5) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & "  and ht.tour_id in (4) and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and (5) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & " and ht.branch_id=0 and em.department_id<>20 and ht.tour_id in (4) and ht.to_branch is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (38) in (" & para(3).Value & " )   and  ht.tour_id in (4) and ht.emp_code<>" & uid(0) & " and  ht.to_branch=bm1.branch_id and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (38) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & "  and ht.tour_id in (4) and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and (38) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & " and ht.branch_id=0 and em.department_id<>20 and ht.tour_id in (4) and ht.to_branch is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (180) in (" & para(3).Value & " )   and  ht.tour_id in (4) and ht.emp_code<>" & uid(0) & " and  ht.to_branch=bm1.branch_id and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (180) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & "  and ht.tour_id in (4) and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and (180) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & " and ht.branch_id=0 and em.department_id<>20 and ht.tour_id in (4) and ht.to_branch is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (183) in (" & para(3).Value & " )   and  ht.tour_id in (4) and ht.emp_code<>" & uid(0) & " and  ht.to_branch=bm1.branch_id and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and em.department_id<>20 and (183) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & "  and ht.tour_id in (4) and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and (183) in (" & para(3).Value & " ) and  ht.emp_code<>" & uid(0) & " and ht.branch_id=0 and em.department_id<>20 and ht.tour_id in (4) and ht.to_branch is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'  '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and em.status_id not in (3,4)  and em.department_id in (" & para(5).Value & " ) and ht.emp_code in (select dp.dep_head from department_mst dp where dp.dep_head is not null ) and ht.tour_id in (0) and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'  '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and em.department_id in (" & para(5).Value & " ) and em.status_id not in (3,4) and ht.emp_code in (select dp.dep_head from department_mst dp where dp.dep_head is not null ) and ht.tour_id in (0) and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'  '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and em.status_id not in (3,4) and em.department_id in (" & para(5).Value & " ) and ht.emp_code in (select dp.dep_head from department_mst dp where dp.dep_head is not null ) and ht.tour_id in (0) and ht.to_branch is null order by srnumber"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_TourDetails.DataSource = dt
                Cmb_TourDetails.DataValueField = dt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()

            ElseIf para(5).Value = 2 Then     'BH
                Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                '  str = "select 0 as srnumber,'Please Select ' from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id not in(10,198,11,12,13,14,15,16,17,18,101,146,148,149,90,136,141,134,131,127,126,137,142,163,164,140,35,36,112,30,33,28,29,32,31,34,128,173) and ht.branch_id <>0 and ht.branch_id=" & dt55.Rows(0)(0) & " and ht.dep_id not in (4,23,37,5,38,20) and ht.tour_id=0 and ht.dep_id not in (4,178,188,183,23,180) and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id not in (10,198,11,12,13,14,15,16,17,18,101,146,148,149,90,136,141,134,131,127,126,137,142,163,164,140,35,36,112,30,33,28,29,32,31,34,128,173) and ht.branch_id <>0 and ht.dep_id not in (4,178,188,183,23,180) and ht.branch_id=" & dt55.Rows(0)(0) & "  and ht.dep_id not in (4,23,37,5,38) and ht.tour_id=0 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id not in(10,198,11,12,13,14,15,16,17,18,101,146,148,149,90,136,141,134,131,127,126,137,142,163,164,140,35,36,112,30,33,28,29,32,31,34,128,173) and ht.branch_id <>0 and ht.dep_id not in (4,178,188,183,23,180) and ht.branch_id=" & dt55.Rows(0)(0) & " and ht.dep_id not in (4,23,37,5,38)  and ht.tour_id=0 and ht.to_branch is null order by srnumber"
                str = "select 0 as srnumber,'Please Select ' from dual"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_TourDetails.DataSource = dt
                Cmb_TourDetails.DataValueField = dt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()

            ElseIf para(5).Value = 55 Then     'audit & vigilance
                Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                str = "select 0 as srnumber,'Please Select ' from dual  union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and  ht.branch_id=0 and ht.emp_code<>" & uid(0) & " and ht.tour_id in (4) and ht.to_branch=bm1.branch_id  union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and ht.tour_id in (4) and ht.emp_code<>" & uid(0) & " and ht.to_branch=bc1.old_id and bc1.branch_id is null  union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and ht.tour_id in (4) and ht.emp_code<>" & uid(0) & " and ht.to_branch is null  union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and  ht.branch_id<>0 and ht.emp_code<>" & uid(0) & " and ht.tour_id in (4) and ht.to_branch=bm1.branch_id  union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id<>0 and ht.tour_id in (4) and ht.emp_code<>" & uid(0) & " and ht.to_branch=bc1.old_id and bc1.branch_id is null  union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id<>0 and ht.tour_id in (4) and ht.emp_code<>" & uid(0) & " and ht.to_branch is null  order by srnumber"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_TourDetails.DataSource = dt
                Cmb_TourDetails.DataValueField = dt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()
            ElseIf para(5).Value = 3 Then         'Area Manager  so bh only to show

                ' str = "select 0 as srnumber,'Please Select ' from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and (ht.post_id in (10,198, 11, 12, 13, 14, 15, 16, 17, 18, 101, 146, 148, 149, 90)   or (ht.dep_id = 20 )) and ht.branch_id in (select branch_id from area_detail where area_id in (select area_id from area_master where area_head_id=" & ecode & ")) and ht.tour_id=0 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and (ht.post_id in (10,198, 11, 12, 13, 14, 15, 16, 17, 18, 101, 146, 148, 149, 90)   or (ht.dep_id = 20 ))  and ht.branch_id in (select branch_id from area_detail where area_id in (select area_id from area_master where area_head_id=" & ecode & ")) and ht.tour_id=0 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and (ht.post_id in  (10,198, 11, 12, 13, 14, 15, 16, 17, 18, 101, 146, 148, 149, 90)   or (ht.dep_id = 20 ))  and ht.branch_id in (select branch_id from area_detail where area_id in (select area_id from area_master where area_head_id=" & ecode & ")) and ht.tour_id=0 and ht.to_branch is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id not in(10,198,11,12,13,14,15,16,17,18,101,146,148,149,90,136,141,134,131,127,126,137,142,197,200,199,163,164,140,35,36,112,30,33,28,29,32,31,34,128,173) and ht.branch_id <>0 and ht.branch_id in (select branch_id from area_detail where area_id in (select area_id from area_master where area_head_id=" & ecode & "))  and ht.dep_id not in (4,23,37,5,38,20) and ht.tour_id=4 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id not in (10,198,11,12,13,14,15,16,17,18,101,146,148,149,90,136,141,134,131,127,126,137,142,163,164,140,35,36,112,30,33,28,29,32,31,34,128,173,199,200,197) and ht.branch_id <>0 and ht.branch_id in (select branch_id from area_detail where area_id in (select area_id from area_master where area_head_id=" & ecode & "))  and ht.dep_id not in (4,23,37,5,38,20) and ht.tour_id=4 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id not in (10,198,11,12,13,14,15,16,17,18,101,146,148,149,90,136,141,134,131,127,126,137,142,163,164,140,35,36,112,30,33,28,29,32,31,34,128,173,197,199,200) and ht.branch_id <>0 and ht.branch_id in (select branch_id from area_detail where area_id in (select area_id from area_master where area_head_id=" & ecode & "))  and ht.dep_id not in (4,23,37,5,38,20)  and ht.tour_id=4 and ht.to_branch is null order by srnumber"
                str = "select 0 as srnumber,'Please Select ' from dual "
                'union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and (ht.post_id in (10,198, 11, 12, 13, 14, 15, 16, 17, 18, 101, 146, 148, 149, 90)   or (ht.dep_id = 20 )) and ht.branch_id in (select branch_id from branch_dtl_new where area_id in (select b.area_id from branch_dtl_new b,employee_master e where b.branch_id=e.branch_id and e.emp_code=" & ecode & ")) and ht.tour_id=0 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and (ht.post_id in (10,198, 11, 12, 13, 14, 15, 16, 17, 18, 101, 146, 148, 149, 90)   or (ht.dep_id = 20 ))  and ht.branch_id in (select branch_id from branch_dtl_new where area_id in (select b.area_id from branch_dtl_new b,employee_master e where b.branch_id=e.branch_id and e.emp_code=" & ecode & ")) and ht.tour_id=0 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and (ht.post_id in  (10,198, 11, 12, 13, 14, 15, 16, 17, 18, 101, 146, 148, 149, 90)   or (ht.dep_id = 20 ))  and ht.branch_id in (select branch_id from branch_dtl_new where area_id in (select b.area_id from branch_dtl_new b,employee_master e where b.branch_id=e.branch_id and e.emp_code=" & ecode & ")) and ht.tour_id=0 and ht.to_branch is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id not in(10,198,11,12,13,14,15,16,17,18,101,146,148,149,90,136,141,134,131,127,126,137,142,197,200,199,163,164,140,35,36,112,30,33,28,29,32,31,34,128,173) and ht.branch_id <>0 and ht.branch_id in (select branch_id from branch_dtl_new where area_id in (select b.area_id from branch_dtl_new b,employee_master e where b.branch_id=e.branch_id and e.emp_code=" & ecode & ")) and ht.dep_id not in (4,23,37,5,38,20) and ht.tour_id=4 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id not in (10,198,11,12,13,14,15,16,17,18,101,146,148,149,90,136,141,134,131,127,126,137,142,163,164,140,35,36,112,30,33,28,29,32,31,34,128,173,199,200,197) and ht.branch_id <>0 and ht.branch_id in (select branch_id from branch_dtl_new where area_id in (select b.area_id from branch_dtl_new b,employee_master e where b.branch_id=e.branch_id and e.emp_code=" & ecode & ")) and ht.dep_id not in (4,23,37,5,38,20) and ht.tour_id=4 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id not in (10,198,11,12,13,14,15,16,17,18,101,146,148,149,90,136,141,134,131,127,126,137,142,163,164,140,35,36,112,30,33,28,29,32,31,34,128,173,197,199,200) and ht.branch_id <>0 and ht.branch_id in (select branch_id from branch_dtl_new where area_id in (select b.area_id from branch_dtl_new b,employee_master e where b.branch_id=e.branch_id and e.emp_code=" & ecode & ")) and ht.dep_id not in (4,23,37,5,38,20)  and ht.tour_id=4 and ht.to_branch is null order by srnumber"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_TourDetails.DataSource = dt
                Cmb_TourDetails.DataValueField = dt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()


                '=-==-=====-=-=-=-=-==-=-=-=-=--=-=--=-=-modi starts of 26 may 2009=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
                ''Conditions Changed..!!No divisional magers post.so regional mangers direct to area managers

                'ElseIf para(5).Value = 4 Then       'Divisional Manager  so only Area Managers

                '    str = "select 0 as srnumber,'Please Select ' from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131) and ht.emp_code in(select aa.area_head_id from area_master aa where aa.area_id in(select d.area_id from division_detail d where d.div_id in (select a.division_id from division_master a where a.div_head_id=" & ecode & "))) and ht.tour_id=0 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131) and ht.emp_code in(select aa.area_head_id from area_master aa where aa.area_id in(select d.area_id from division_detail d where d.div_id in (select a.division_id from division_master a where a.div_head_id=" & ecode & "))) and ht.tour_id=0 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131) and ht.emp_code in(select aa.area_head_id from area_master aa where aa.area_id in(select d.area_id from division_detail d where d.div_id in (select a.division_id from division_master a where a.div_head_id=" & ecode & "))) and ht.tour_id=0 and ht.to_branch is null order by srnumber"
                '    dt = oh.ExecuteDataSet(str).Tables(0)
                '    Cmb_TourDetails.DataSource = dt
                '    Cmb_TourDetails.DataValueField = dt.Columns(0).ColumnName
                '    Cmb_TourDetails.DataTextField = dt.Columns(1).ColumnName
                '    Cmb_TourDetails.DataBind()

                'ElseIf para(5).Value = 5 Then       'Region Manager so only Divisional Manager

                '    str = "select 0 as srnumber,'Please Select ' from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id in (127,126,137,142,163,164,140) and ht.emp_code in(select dd.div_head_id from division_master dd where dd.division_id in(select rd.division_id from region_detail rd where rd.region_id in (select rm.reg_id from region_master rm where rm.head_id=" & ecode & "))) and ht.tour_id=0 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id in (127,126,137,142,163,164,140) and ht.emp_code in(select dd.div_head_id from division_master dd where dd.division_id in(select rd.division_id from region_detail rd where rd.region_id in (select rm.reg_id from region_master rm where rm.head_id=" & ecode & "))) and ht.tour_id=0 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id in (127,126,137,142,163,164,140) and ht.emp_code in(select dd.div_head_id from division_master dd where dd.division_id in(select rd.division_id from region_detail rd where rd.region_id in (select rm.reg_id from region_master rm where rm.head_id=" & ecode & "))) and ht.tour_id=0 and ht.to_branch is null order by srnumber"
                '    dt = oh.ExecuteDataSet(str).Tables(0)
                '    Cmb_TourDetails.DataSource = dt
                '    Cmb_TourDetails.DataValueField = dt.Columns(0).ColumnName
                '    Cmb_TourDetails.DataTextField = dt.Columns(1).ColumnName
                '    Cmb_TourDetails.DataBind()

                ''=-=-=-====-=-=-==-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=
                'so new  query will be:

            ElseIf para(5).Value = 5 Then       'Region Manager so only Area Manager

                ' str = "select 0 as srnumber,'Please Select ' from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131,197) and ht.emp_code in (select aa.area_head_id from area_master aa where aa.area_id in (select bd.area_id from branch_detail bd where bd.reg_id in (select c.reg_id from region_master c where c.head_id=" & ecode & "))) and ht.tour_id=0 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131,197) and ht.emp_code in (select aa.area_head_id from area_master aa where aa.area_id in (select bd.area_id from branch_detail bd where bd.reg_id in (select c.reg_id from region_master c where c.head_id=" & ecode & "))) and ht.tour_id=0 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131,197) and ht.emp_code in (select aa.area_head_id from area_master aa where aa.area_id in (select bd.area_id from branch_detail bd where bd.reg_id in (select c.reg_id from region_master c where c.head_id=" & ecode & "))) and ht.tour_id=0 and ht.to_branch is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and (ht.post_id in  (10,198, 11, 12, 13, 14, 15, 16, 17, 18, 101, 146, 148, 149, 90)   or (ht.dep_id = 20 )) and ht.branch_id in (select ad.branch_id from area_detail ad where ad.area_id in (select dd.area_id from division_detail dd,region_detail rd where dd.div_id=rd.division_id and rd.region_id in (select reg_id from region_master where head_id=" & ecode & " ))) and ht.tour_id=4 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and (ht.post_id in  (10,198, 11, 12, 13, 14, 15, 16, 17, 18, 101, 146, 148, 149, 90)   or (ht.dep_id = 20 )) and ht.branch_id in (select ad.branch_id from area_detail ad where ad.area_id in (select dd.area_id from division_detail dd,region_detail rd where dd.div_id=rd.division_id and rd.region_id in (select reg_id from region_master where head_id=" & ecode & " )))  and ht.tour_id=4 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and (ht.post_id in  (10,198, 11, 12, 13, 14, 15, 16, 17, 18, 101, 146, 148, 149, 90)   or (ht.dep_id = 20 )) and ht.branch_id in (select ad.branch_id from area_detail ad where ad.area_id in (select dd.area_id from division_detail dd,region_detail rd where dd.div_id=rd.division_id and rd.region_id in (select reg_id from region_master where head_id=" & ecode & " ))) and ht.tour_id=4 and ht.to_branch is null order by srnumber"

                'str = "select 0 as srnumber,'Please Select ' from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131,197) and ht.branch_id in (select branch_id from branch_dtl_new where reg_id in (select b.reg_id from branch_dtl_new b,employee_master e where b.branch_id=e.branch_id and e.emp_code=" & ecode & "))  and ht.tour_id=0 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131,197) and ht.branch_id in (select branch_id from branch_dtl_new where reg_id in (select b.reg_id from branch_dtl_new b,employee_master e where b.branch_id=e.branch_id and e.emp_code=" & ecode & "))  and ht.tour_id=0 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131,197) and ht.branch_id in (select branch_id from branch_dtl_new where reg_id in (select b.reg_id from branch_dtl_new b,employee_master e where b.branch_id=e.branch_id and e.emp_code=" & ecode & "))  and ht.tour_id=0 and ht.to_branch is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and (ht.post_id in  (10,198, 11, 12, 13, 14, 15, 16, 17, 18, 101, 146, 148, 149, 90)   or (ht.dep_id = 20 )) and ht.branch_id in (select branch_id from branch_dtl_new where reg_id in (select b.reg_id from branch_dtl_new b,employee_master e where b.branch_id=e.branch_id and e.emp_code=" & ecode & "))  and ht.tour_id=4 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and (ht.post_id in  (10,198, 11, 12, 13, 14, 15, 16, 17, 18, 101, 146, 148, 149, 90)   or (ht.dep_id = 20 )) and ht.branch_id in (select branch_id from branch_dtl_new where reg_id in (select b.reg_id from branch_dtl_new b,employee_master e where b.branch_id=e.branch_id and e.emp_code=" & ecode & "))   and ht.tour_id=4 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and (ht.post_id in  (10,198, 11, 12, 13, 14, 15, 16, 17, 18, 101, 146, 148, 149, 90)   or (ht.dep_id = 20 )) and ht.branch_id in (select branch_id from branch_dtl_new where reg_id in (select b.reg_id from branch_dtl_new b,employee_master e where b.branch_id=e.branch_id and e.emp_code=" & ecode & "))  and ht.tour_id=4 and ht.to_branch is null order by srnumber"
                str = "select 0 as srnumber,'Please Select ' from dual "
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_TourDetails.DataSource = dt
                Cmb_TourDetails.DataValueField = dt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()




                '=-=-=-=-===-=-=-=-=-=-=-=-=-=-=-=-=-=modi ends of 26 may 2009=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-

            ElseIf para(5).Value = 6 Then       'Zonal Manager so only region manager
                'str = "select 0 as srnumber,'Please Select ',0 as emp_code from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131,197) and ht.branch_id in (select aa.branch_id from area_detail aa where aa.area_id in (select bd.area_id from branch_detail bd where bd.reg_id in (select zd.region_id from Zonal_master c,zonal_detail zd where zd.zonal_id=c.zonal_id and c.hr_head=21820 ))) and ht.tour_id=0 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131) and ht.branch_id in (select aa.branch_id from area_detail aa where aa.area_id in (select bd.area_id from branch_detail bd where bd.reg_id in (select zd.region_id from Zonal_master c,zonal_detail zd where zd.zonal_id=c.zonal_id and c.hr_head=21820 ))) and ht.tour_id=0 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131,197) and ht.branch_id in (select aa.branch_id from area_detail aa where aa.area_id in (select bd.area_id from branch_detail bd where bd.reg_id in (select zd.region_id from Zonal_master c,zonal_detail zd where zd.zonal_id=c.zonal_id and c.hr_head=21820 ))) and ht.tour_id=0 and ht.to_branch is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and (ht.post_id in  (10,198, 11, 12, 13, 14, 15, 16, 17, 18, 101, 146, 148, 149, 90)   or (ht.dep_id = 20 )) and ht.branch_id in (select ad.branch_id from area_detail ad where ad.area_id in (select dd.area_id from division_detail dd,region_detail rd where dd.div_id=rd.division_id and rd.region_id in (select zd.region_id from Zonal_master c,zonal_detail zd where zd.zonal_id=c.zonal_id and c.hr_head=21820 ))) and ht.tour_id=4 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and (ht.post_id in  (10,198, 11, 12, 13, 14, 15, 16, 17, 18, 101, 146, 148, 149, 90)   or (ht.dep_id = 20 )) and ht.branch_id in (select ad.branch_id from area_detail ad where ad.area_id in (select dd.area_id from division_detail dd,region_detail rd where dd.div_id=rd.division_id and rd.region_id in (select zd.region_id from Zonal_master c,zonal_detail zd where zd.zonal_id=c.zonal_id and c.hr_head=21820 )))  and ht.tour_id=4 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and (ht.post_id in  (10,198, 11, 12, 13, 14, 15, 16, 17, 18, 101, 146, 148, 149, 90)   or (ht.dep_id = 20 )) and ht.branch_id in (select ad.branch_id from area_detail ad where ad.area_id in (select dd.area_id from division_detail dd,region_detail rd where dd.div_id=rd.division_id and rd.region_id in (select zd.region_id from Zonal_master c,zonal_detail zd where zd.zonal_id=c.zonal_id and c.hr_head=21820 ))) and ht.tour_id=4 and ht.to_branch is null  union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id in (35,36,112,30,33,28,29,32,31,34,128,199,200) and em.branch_id in (select rm.BRANCH_ID from branch_dtl_new rm where rm.reg_id in(select zd.region_id from zonal_detail zd where zd.zonal_id in (select zm.zonal_id from zonal_master zm where zm.hr_head=21820 ))) and ht.tour_id=0 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id in (35,36,112,30,33,28,29,32,31,34,128,199,200) and em.branch_id in (select rm.BRANCH_ID from branch_dtl_new rm where rm.reg_id in(select zd.region_id from zonal_detail zd where zd.zonal_id in (select zm.zonal_id from zonal_master zm where zm.hr_head=21820 ))) and ht.tour_id=0 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id in (35,36,112,30,33,28,29,32,31,34,128,199,200) and em.branch_id in (select rm.BRANCH_ID from branch_dtl_new rm where rm.reg_id in(select zd.region_id from zonal_detail zd where zd.zonal_id in (select zm.zonal_id from zonal_master zm where zm.hr_head=21820 ))) and ht.tour_id=0 and ht.to_branch is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131,197) and ht.branch_id in (select aa.branch_id from area_detail aa ,zonal_detail rd,region_detail rrd,division_detail dd,zonal_master zm where zm.hr_head=21820  and zm.zonal_id=rd.zonal_id and rd.region_id=rrd.region_id and rrd.division_id=dd.div_id and dd.area_id=aa.area_id ) and ht.tour_id=4 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose),ht.emp_code  from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131,197) and ht.branch_id in (select aa.branch_id from area_detail aa ,zonal_detail rd,region_detail rrd,division_detail dd,zonal_master zm where zm.hr_head=21820  and zm.zonal_id=rd.zonal_id and rd.region_id=rrd.region_id and rrd.division_id=dd.div_id and dd.area_id=aa.area_id ) and ht.tour_id=4 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131,197) and ht.branch_id in (select aa.branch_id from area_detail aa ,zonal_detail rd,region_detail rrd,division_detail dd,zonal_master zm where zm.hr_head=21820  and zm.zonal_id=rd.zonal_id and rd.region_id=rrd.region_id and rrd.division_id=dd.div_id and dd.area_id=aa.area_id ) and ht.tour_id=4 and ht.to_branch is null order by emp_code,srnumber"
                '  str = "select 0 as srnumber,'Please Select ',0 as emp_code from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131,197) and ht.branch_id in (select aa.branch_id from area_detail aa where aa.area_id in (select bd.area_id from branch_detail bd where bd.reg_id in (select zd.region_id from Zonal_master c,zonal_detail zd where zd.zonal_id=c.zonal_id and c.hr_head=" & ecode & " ))) and ht.tour_id=0 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131) and ht.branch_id in (select aa.branch_id from area_detail aa where aa.area_id in (select bd.area_id from branch_detail bd where bd.reg_id in (select zd.region_id from Zonal_master c,zonal_detail zd where zd.zonal_id=c.zonal_id and c.hr_head=" & ecode & " ))) and ht.tour_id=0 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131,197) and ht.branch_id in (select aa.branch_id from area_detail aa where aa.area_id in (select bd.area_id from branch_detail bd where bd.reg_id in (select zd.region_id from Zonal_master c,zonal_detail zd where zd.zonal_id=c.zonal_id and c.hr_head=" & ecode & " ))) and ht.tour_id=0 and ht.to_branch is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and (ht.post_id in  (10,198, 11, 12, 13, 14, 15, 16, 17, 18, 101, 146, 148, 149, 90)   or (ht.dep_id = 20 )) and ht.branch_id in (select ad.branch_id from area_detail ad where ad.area_id in (select dd.area_id from division_detail dd,region_detail rd where dd.div_id=rd.division_id and rd.region_id in (select zd.region_id from Zonal_master c,zonal_detail zd where zd.zonal_id=c.zonal_id and c.hr_head=" & ecode & " ))) and ht.tour_id=4 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and (ht.post_id in  (10,198, 11, 12, 13, 14, 15, 16, 17, 18, 101, 146, 148, 149, 90)   or (ht.dep_id = 20 )) and ht.branch_id in (select ad.branch_id from area_detail ad where ad.area_id in (select dd.area_id from division_detail dd,region_detail rd where dd.div_id=rd.division_id and rd.region_id in (select zd.region_id from Zonal_master c,zonal_detail zd where zd.zonal_id=c.zonal_id and c.hr_head=" & ecode & " )))  and ht.tour_id=4 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and (ht.post_id in  (10,198, 11, 12, 13, 14, 15, 16, 17, 18, 101, 146, 148, 149, 90)   or (ht.dep_id = 20 )) and ht.branch_id in (select ad.branch_id from area_detail ad where ad.area_id in (select dd.area_id from division_detail dd,region_detail rd where dd.div_id=rd.division_id and rd.region_id in (select zd.region_id from Zonal_master c,zonal_detail zd where zd.zonal_id=c.zonal_id and c.hr_head=" & ecode & " ))) and ht.tour_id=4 and ht.to_branch is null  union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id in (35,36,112,30,33,28,29,32,31,34,128,199,200) and em.branch_id in (select rm.BRANCH_ID from branch_dtl_new rm where rm.reg_id in(select zd.region_id from zonal_detail zd where zd.zonal_id in (select zm.zonal_id from zonal_master zm where zm.hr_head=" & ecode & " ))) and ht.tour_id=0 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id in (35,36,112,30,33,28,29,32,31,34,128,199,200) and em.branch_id in (select rm.BRANCH_ID from branch_dtl_new rm where rm.reg_id in(select zd.region_id from zonal_detail zd where zd.zonal_id in (select zm.zonal_id from zonal_master zm where zm.hr_head=" & ecode & " ))) and ht.tour_id=0 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id in (35,36,112,30,33,28,29,32,31,34,128,199,200) and em.branch_id in (select rm.BRANCH_ID from branch_dtl_new rm where rm.reg_id in(select zd.region_id from zonal_detail zd where zd.zonal_id in (select zm.zonal_id from zonal_master zm where zm.hr_head=" & ecode & " ))) and ht.tour_id=0 and ht.to_branch is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131,197) and ht.branch_id in (select aa.branch_id from area_detail aa ,zonal_detail rd,region_detail rrd,division_detail dd,zonal_master zm where zm.hr_head=" & ecode & " and zm.zonal_id=rd.zonal_id and rd.region_id=rrd.region_id and rrd.division_id=dd.div_id and dd.area_id=aa.area_id ) and ht.tour_id=4 and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose),ht.emp_code  from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131,197) and ht.branch_id in (select aa.branch_id from area_detail aa ,zonal_detail rd,region_detail rrd,division_detail dd,zonal_master zm where zm.hr_head=" & ecode & " and zm.zonal_id=rd.zonal_id and rd.region_id=rrd.region_id and rrd.division_id=dd.div_id and dd.area_id=aa.area_id ) and ht.tour_id=4 and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code  from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131,197) and ht.branch_id in (select aa.branch_id from area_detail aa ,zonal_detail rd,region_detail rrd,division_detail dd,zonal_master zm where zm.hr_head=" & ecode & " and zm.zonal_id=rd.zonal_id and rd.region_id=rrd.region_id and rrd.division_id=dd.div_id and dd.area_id=aa.area_id ) and ht.tour_id=4 and ht.to_branch is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and  ht.branch_id=0 and ht.emp_code<>" & uid(0) & " and ht.tour_id in (0,4) and ht.to_branch=bm1.branch_id and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and ht.tour_id in (0,4) and ht.emp_code<>" & uid(0) & " and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and ht.tour_id in (0,4) and ht.emp_code<>" & uid(0) & " and ht.to_branch is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " order by emp_code,srnumber"
                str = "select 0 as srnumber,'Please Select ',0 as emp_code from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and  ht.branch_id=0 and ht.emp_code<>" & uid(0) & " and ht.tour_id in (0,4) and ht.to_branch=bm1.branch_id and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and ht.tour_id in (0,4) and ht.emp_code<>" & uid(0) & " and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||' '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt),ht.emp_code from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id in (" & para(3).Value & ") and ht.branch_id=0 and ht.tour_id in (0,4) and ht.emp_code<>" & uid(0) & " and ht.to_branch is null and ht.SANCTION_PERSON<>" & uid(0) & " and ht.recom_person<>" & uid(0) & " order by emp_code,srnumber"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_TourDetails.DataSource = dt
                Cmb_TourDetails.DataValueField = dt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()

            ElseIf para(5).Value = 7 Then       'chairman
                Me.cmd_rec.Visible = False
                str = "select 0 as srnumber,'Please Select ' from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'  '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and em.status_id not in (3,4) and ht.post_id in (35,36,112,30,33,28,29,32,31,34,128) and ht.emp_code in(select rm.head_id from region_master rm where rm.reg_id in(select zd.region_id from zonal_detail zd where zd.zonal_id in (select zm.zonal_id from zonal_master zm ))) and ht.tour_id in (0,4) and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'  '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and em.status_id not in (3,4) and ht.post_id in (35,36,112,30,33,28,29,32,31,34,128) and ht.emp_code in(select rm.head_id from region_master rm where rm.reg_id in(select zd.region_id from zonal_detail zd where zd.zonal_id in (select zm.zonal_id from zonal_master zm ))) and ht.tour_id in (0,4) and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'  '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and em.status_id not in (3,4) and ht.post_id in (35,36,112,30,33,28,29,32,31,34,128) and ht.emp_code in(select rm.head_id from region_master rm where rm.reg_id in(select zd.region_id from zonal_detail zd where zd.zonal_id in (select zm.zonal_id from zonal_master zm ))) and ht.tour_id in (0,4) and ht.to_branch is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'  '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and em.status_id not in (3,4) and ht.emp_code in (select g.head_id from zonal_master g where g.head_id is not null union select dp.dep_head from department_mst dp where dp.dep_head is not null) and ht.tour_id in (0,4) and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'  '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and em.status_id not in (3,4) and ht.emp_code in (select g.head_id from zonal_master g where g.head_id is not null union select dp.dep_head from department_mst dp where dp.dep_head is not null) and ht.tour_id in (0,4) and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'  '||to_char(ht.from_dt)||'-'||to_char(ht.to_dt) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and em.status_id not in (3,4) and ht.emp_code in (select g.rh_hr from region_master g where g.rh_hr is not null union select dp.dep_head from department_mst dp where dp.dep_head is not null union select ht.emp_code from department_major dm where dm.head_id like '%'||ht.emp_code||'%') and ht.tour_id in (0,4) and ht.to_branch is null order by srnumber"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_TourDetails.DataSource = dt
                Cmb_TourDetails.DataValueField = dt.Columns(0).ColumnName
                Cmb_TourDetails.DataTextField = dt.Columns(1).ColumnName
                Cmb_TourDetails.DataBind()

            ElseIf para(5).Value = 10 Then         'Not an authorised Person in Head officew

                Dim cl_script2 As New StringBuilder
                cl_script2.Append(" alert('You Have No Authority to View this page!!! ');")
                cl_script2.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script2.ToString, True)


            ElseIf para(5).Value = 11 Then         'Not an authorised Person in Branch

                Dim cl_script3 As New StringBuilder
                cl_script3.Append(" alert('You Have No Authority!!! ');")
                cl_script3.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script3.ToString, True)


            ElseIf para(5).Value = 0 Then

                Dim cl_script3 As New StringBuilder
                cl_script3.Append(" alert('Some Problems May Have Occured..!! (Exception!!) ');")
                cl_script3.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script3.ToString, True)


            End If
        Catch ex As Exception
            Dim cl_script5 As New StringBuilder
            cl_script5.Append("   alert('" & ex.ToString & " ') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script5.ToString, True)

        Finally
        End Try

    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim SrlNO As Integer = CInt(eventArgument)
        Dim cal_data = eventArgument
        Dim dis As Integer = cal_data
        res = GetData(SrlNO)
    End Sub

    Private Function GetData(ByVal SrlNO As Integer) As String
        Dim st As New StringBuilder
        Try
            Dim s As Double = oh.ExecuteDataSet("select nvl(h.to_branch,99999) from hrm_tour_dtl h where h.sr_number=" & SrlNO & "").Tables(0).Rows(0)(0)
            If s <> 99999 Then
                '                     0              1          2               3                     4               5                                  6                                                                               7
                str1 = "select ht.emp_code||'*'||em.emp_name||'*'||bm.branch_name||'*'||dm.designation||'*'||dp.dep_name||'*'||pm.post_name||'*'||to_char(ht.from_dt)||'*'||to_char(ht.to_dt)||'*'||nvl(ht.from_time,0)||'*'||nvl(ht.to_time,0)||'*'||bm1.branch_name||'*'||decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose))||'*'||nvl(ht.advance_rs,0)||'*'||decode(ht.tra_dt,null,'0',to_char(ht.tra_dt))||'*'||e1.emp_code||'--'||e1.emp_name||'*'||ht.tour_id from employee_master em,branch bm,designation_master dm,department_mst dp,post_mst pm,branch bm1,hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code=ht.recom_person and e1.emp_code>9999) where  ht.emp_code=em.emp_code and bm.branch_id=ht.branch_id and dm.designation_id=ht.desig_id and dp.dep_id=ht.dep_id and pm.post_id=ht.post_id and ht.to_branch=bm1.branch_id and ht.tour_id in (0,4) and ht.sr_number =" & SrlNO & " "
            ElseIf s = 99999 Then
                str1 = "select ht.emp_code||'*'||em.emp_name||'*'||bm.branch_name||'*'||dm.designation||'*'||dp.dep_name||'*'||pm.post_name||'*'||to_char(ht.from_dt)||'*'||to_char(ht.to_dt)||'*'||nvl(ht.from_time,0)||'*'||nvl(ht.to_time,0)||'*'||decode(ht.others,null,'Not Specified',ht.others)||'*'||decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose))||'*'||nvl(ht.advance_rs,0)||'*'||decode(ht.tra_dt,null,'0',to_char(ht.tra_dt))||'*'||e1.emp_code||'--'||e1.emp_name||'*'||ht.tour_id from employee_master em,branch_master bm,designation_master dm,department_mst dp,post_mst pm,hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code=ht.recom_person and e1.emp_code>9999)  where  ht.emp_code=em.emp_code and bm.branch_id=ht.branch_id and dm.designation_id=ht.desig_id and dp.dep_id=ht.dep_id and pm.post_id=ht.post_id and ht.tour_id in (0,4) and ht.sr_number =" & SrlNO & " union select ht.emp_code||'*'||em.emp_name||'*'||bc.branch_name||'*'||dm.designation||'*'||dp.dep_name||'*'||pm.post_name||'*'||ht.from_dt||'*'||ht.to_dt||'*'||nvl(ht.from_time,0)||'*'||nvl(ht.to_time,0)||'*'||decode(ht.others,null,'Not Specified',ht.others)||'*'||decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose))||'*'||nvl(ht.advance_rs,0)||'*'||decode(ht.tra_dt,null,'0',to_char(ht.tra_dt))||'*'||e1.emp_code||'--'||e1.emp_name||'*'||ht.tour_id from employee_master em,before_completion bc,designation_master dm,department_mst dp,post_mst pm,hrm_tour_dtl ht left outer join employee_master e1 on (e1.emp_code=ht.recom_person and e1.emp_code>9999)  where ht.emp_code=em.emp_code and bc.old_id=ht.branch_id and bc.branch_id is null and dm.designation_id=ht.desig_id and dp.dep_id=ht.dep_id and pm.post_id=ht.post_id and ht.tour_id in (0,4) and ht.sr_number =" & SrlNO & ""
            End If

            dt1 = oh.ExecuteDataSet(str1).Tables(0)

        Catch ex As Exception
        Finally

        End Try
        If dt1.Rows.Count > 0 Then

            st.Append(dt1.Rows(0)(0))
            st.Append("@")
            st.Append("!")
        Else
            st.Append("$")
            st.Append("@")
            st.Append("!")
        End If
        Return st.ToString
    End Function


    Private Sub LoadInitValue()
        Dim arg1, arg2(), arg3() As String

        If Cmb_TourDetails.Items.Count > 1 Then
            Cmb_TourDetails.SelectedIndex = 1
            arg1 = GetData(CInt(Cmb_TourDetails.SelectedValue))
        Else
            Return
        End If


        arg2 = arg1.Split("@")
        If (arg2(0) <> "$") Then

            arg3 = arg2(0).Split("*")

            Txt_EmpCode.Text = arg3(0)
            Txt_EmpName.Text = arg3(1)
            Txt_Branch.Text = arg3(2)
            Txt_Designation.Text = arg3(3)
            Txt_Department.Text = arg3(4)
            Txt_Post.Text = arg3(5)
            Txt_TourFrom.Text = arg3(6)
            Txt_TourTo.Text = arg3(7)

            Txt_TourPlace.Text = arg3(10)
            Txt_Purpose.Text = arg3(11)

            Txt_Advance.Text = arg3(12)
            If ((arg3(13)) <> "") Then

                Txt_ApplyDate.Text = arg3(13)
            End If
            If ((arg3(14)) = "--") Then
                Txt_rec.Text = "No Recommendation"
            Else
                Txt_rec.Text = arg3(14)
            End If
            If ((arg3(13)) = "") Then

                Txt_ApplyDate.Text = "Not Specified"
            End If
            If ((arg3(8)) <> "") Then

                Txt_FromTime.Text = arg3(8)
            End If
            If ((arg3(8)) = "") Then

                Txt_FromTime.Text = "Not Specified"
            End If
            If ((arg3(9)) <> "") Then

                Txt_ToTime.Text = arg3(9)
            End If
            If ((arg3(9)) = "") Then

                Txt_ToTime.Text = "Not Specified"
            End If

            t1.Style("display") = "inline"

            'Cmd_Confirm.Attributes.Add("disabled", "false")
            'Cmd_Cancel.Attributes("disabled") = "false"
            'cmd_rec.Attributes("disabled") = "false"
        End If
    End Sub



    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click


        Dim userid As String = Me.Session("user_id")
        Dim uid() As String = userid.Split("!")
        Dim ecode1 As Integer = uid(0)
        Me.ttype = Me.Cmb_TourDetails.SelectedValue


        Try
            Dim para(5) As OracleParameter

            para(0) = New OracleParameter("tcase", OracleType.Number, 8)
            para(0).Value = Me.ttype
            para(0).Direction = ParameterDirection.Input

            para(1) = New OracleParameter("empcode", OracleType.Number, 5)
            para(1).Value = ecode1
            para(1).Direction = ParameterDirection.Input

            para(2) = New OracleParameter("branchid", OracleType.Number, 5)
            para(2).Value = -99
            para(2).Direction = ParameterDirection.Input

            para(3) = New OracleParameter("depid", OracleType.VarChar, 5000)
            para(3).Direction = ParameterDirection.Output

            para(4) = New OracleParameter("postid", OracleType.Number, 5)
            para(4).Direction = ParameterDirection.Output

            para(5) = New OracleParameter("flag", OracleType.Number, 2)
            para(5).Direction = ParameterDirection.Output

            oh.ExecuteDataSet("hrm_tour_sanction_rejection", para)

            If para(5).Value = 20 Then    'Confirmed Successfully   


                Dim cl_script8 As New StringBuilder
                cl_script8.Append(" alert('Confirmed Successfully..!! ');")
                'cl_script8.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script8.ToString, True)

                pageload()
                LoadInitValue()

            ElseIf para(5).Value = 21 Then   'Already  Updated!!


                Dim cl_script9 As New StringBuilder
                cl_script9.Append(" alert('Already Confirmed !! ');")
                'cl_script9.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)

            ElseIf para(5).Value = 24 Then   'Already  Updated!!


                Dim cl_script9 As New StringBuilder
                cl_script9.Append(" alert('A PUNCHING BLOCK IS FOUND IN TOUR APPILED DATE ! ');")
                'cl_script9.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)


            ElseIf para(5).Value = 22 Then   'Already  Updated!!


                Dim cl_script9 As New StringBuilder
                cl_script9.Append(" alert('A Leave Applied on that day !! ');")
                'cl_script9.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)

            ElseIf para(5).Value = 26 Then   'Already  Updated!!


                Dim cl_script9 As New StringBuilder
                cl_script9.Append(" alert('You are not Authorised to Sanction!! ');")
                'cl_script9.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)

            ElseIf para(5).Value = 0 Then

                Dim cl_script10 As New StringBuilder
                cl_script10.Append(" alert('Some Problems May Have Occured..!! (Exception!!) ');")
                cl_script10.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script10.ToString, True)


            End If
        Catch ex As Exception
            Dim cl_script11 As New StringBuilder
            cl_script11.Append("   alert('" & ex.Message.Replace("'", "") & " ')")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script11.ToString, True)

        Finally
        End Try
    End Sub

    Protected Sub Cmd_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Cancel.Click

        Dim userid As String = Me.Session("user_id")
        Dim uid() As String = userid.Split("!")
        Dim ecode1 As Integer = uid(0)
        Me.ttype = Me.Cmb_TourDetails.SelectedValue


        Try
            Dim para(5) As OracleParameter

            para(0) = New OracleParameter("tcase", OracleType.Number, 8)
            para(0).Value = Me.ttype
            para(0).Direction = ParameterDirection.Input

            para(1) = New OracleParameter("empcode", OracleType.Number, 5)
            para(1).Value = ecode1
            para(1).Direction = ParameterDirection.Input

            para(2) = New OracleParameter("branchid", OracleType.Number, 5)
            para(2).Value = -999
            para(2).Direction = ParameterDirection.Input

            para(3) = New OracleParameter("depid", OracleType.VarChar, 5000)
            para(3).Direction = ParameterDirection.Output

            para(4) = New OracleParameter("postid", OracleType.Number, 5)
            para(4).Direction = ParameterDirection.Output

            para(5) = New OracleParameter("flag", OracleType.Number, 2)
            para(5).Direction = ParameterDirection.Output

            oh.ExecuteDataSet("hrm_tour_sanction_rejection", para)

            If para(5).Value = 30 Then    'Cancelled Successfully   


                Dim cl_script8 As New StringBuilder
                cl_script8.Append(" alert('Tour Cancelled Successfully..!! ');")
                'cl_script8.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script8.ToString, True)

                pageload()

            ElseIf para(5).Value = 31 Then   'Already  Cancelled!!


                Dim cl_script9 As New StringBuilder
                cl_script9.Append(" alert('Already Cancelled !! ');")
                'cl_script9.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)



            ElseIf para(5).Value = 0 Then

                Dim cl_script10 As New StringBuilder
                cl_script10.Append(" alert('Some Problems May Have Occured..!! (Exception!!) ');")
                cl_script10.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script10.ToString, True)


            End If
        Catch ex As Exception
            Dim cl_script11 As New StringBuilder
            cl_script11.Append("   alert('" & ex.ToString & " ') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script11.ToString, True)

        Finally
        End Try
    End Sub


    Protected Sub cmd_rec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_rec.Click
        Dim userid As String = Me.Session("user_id")
        Dim uid() As String = userid.Split("!")
        Dim ecode1 As Integer = uid(0)
        Me.ttype = Me.Cmb_TourDetails.SelectedValue


        Try
            Dim para(5) As OracleParameter

            para(0) = New OracleParameter("tcase", OracleType.Number, 8)
            para(0).Value = Me.ttype
            para(0).Direction = ParameterDirection.Input

            para(1) = New OracleParameter("empcode", OracleType.Number, 5)
            para(1).Value = ecode1
            para(1).Direction = ParameterDirection.Input

            para(2) = New OracleParameter("branchid", OracleType.Number, 5)
            para(2).Value = -9999
            para(2).Direction = ParameterDirection.Input

            para(3) = New OracleParameter("depid", OracleType.VarChar, 5000)
            para(3).Direction = ParameterDirection.Output

            para(4) = New OracleParameter("postid", OracleType.Number, 5)
            para(4).Direction = ParameterDirection.Output

            para(5) = New OracleParameter("flag", OracleType.Number, 2)
            para(5).Direction = ParameterDirection.Output

            oh.ExecuteDataSet("hrm_tour_sanction_rejection", para)

            If para(5).Value = 40 Then    'Confirmed Successfully   


                Dim cl_script8 As New StringBuilder
                cl_script8.Append(" alert('recommended Successfully..!! ');")
                cl_script8.Append("       window.open('tour_sanction_wform.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script8.ToString, True)

                pageload()

            ElseIf para(5).Value = 41 Then   'Already  Updated!!


                Dim cl_script9 As New StringBuilder
                cl_script9.Append(" alert('Already Recommended !! ');")
                'cl_script9.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)

            ElseIf para(5).Value = 42 Then   'Already  Updated!!


                Dim cl_script9 As New StringBuilder
                cl_script9.Append(" alert('A Leave Applied on that day !! ');")
                'cl_script9.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)



            ElseIf para(5).Value = 0 Then

                Dim cl_script10 As New StringBuilder
                cl_script10.Append(" alert('Some Problems May Have Occured..!! (Exception!!) ');")
                cl_script10.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script10.ToString, True)


            End If
        Catch ex As Exception
            Dim cl_script11 As New StringBuilder
            cl_script11.Append("   alert('" & ex.Message.Replace("'", "") & " ') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script11.ToString, True)

        Finally
        End Try
    End Sub
End Class
