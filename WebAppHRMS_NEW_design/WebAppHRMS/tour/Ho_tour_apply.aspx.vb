Imports System.Data
Imports System.Data.OracleClient
Partial Class november_tour_Tour_apply_d1bb416e6324
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim str, str1 As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim res As String
    Dim sf() As String
    Dim sanemp As Integer
    Dim ttype As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_adv.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        Me.Cmb_Select.Attributes.Add("onchange", "fill1()")
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "sub_call_receiver", "context")
        Dim cbscript As String = "function sub_call_server(arg,context) { " & cbref & "; } "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "sub_call_server", cbscript, True)
        sf = Session("user_id").ToString.Split("!")
        sanemp = sf(0)
        If Not IsPostBack Then
            pageload()
            Me.Txt_fdt.Text = Format(Date.Now, "dd/MMM/yyyy")
            Me.Txt_tdt.Text = Format(Date.Now, "dd/MMM/yyyy")
            '----sh

            If Session("firm_id") = 2 Then
                str1 = "select branch_name, branch_id from mactech.branch_master where firm_id = " & Session("firm_id") & " union all select branch_name, branch_id from mactech.branch_master where branch_id = 0 order by branch_name"
            Else
                str1 = "select b.branch_name, b.branch_id  from branch_master b  WHERE b.BRANCH_ID <> 9999  and b.firm_id = " & Session("firm_id") & "  union  select branch_name, old_id  from before_completion  where branch_id is null  and status_id not in (2)  and firm_id =" & Session("firm_id") & "  union  select b.branch_name, b.branch_id  from branch_master b  WHERE b.BRANCH_ID in (0)  order by branch_name"
            End If
            '----sh

            'str1 = "select b.branch_name, b.branch_id  from branch_master b  WHERE b.BRANCH_ID <> 9999  and b.firm_id = " & Session("firm_id") & "  union  select branch_name, old_id  from before_completion  where branch_id is null  and status_id not in (2)  and firm_id =" & Session("firm_id") & "  union  select b.branch_name, b.branch_id  from branch_master b  WHERE b.BRANCH_ID in (0)  order by branch_name"
            dt = oh.ExecuteDataSet(str1).Tables(0)
            Me.cmb_place.DataSource = dt
            Me.cmb_place.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_place.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_place.DataBind()
        End If
    End Sub
    Sub pageload()
        Dim brid As Integer = Me.Session("branch_id")
        Dim userid As String = Me.Session("user_id")
        Dim uid() As String = userid.Split("!")
        Dim ecode As Integer = uid(0)
        Me.ttype = 0
        Try
            Dim para(5) As OracleParameter

            para(0) = New OracleParameter("tcase", OracleType.Number, 8)
            para(0).Value = Me.ttype
            para(0).Direction = ParameterDirection.Input

            para(1) = New OracleParameter("empcode", OracleType.Number, 5)
            para(1).Value = ecode
            para(1).Direction = ParameterDirection.Input

            para(2) = New OracleParameter("branchid", OracleType.Number, 5)
            para(2).Value = brid
            para(2).Direction = ParameterDirection.Input

            para(3) = New OracleParameter("depid", OracleType.VarChar, 5000)
            para(3).Direction = ParameterDirection.Output

            para(4) = New OracleParameter("postid", OracleType.VarChar, 500)
            para(4).Direction = ParameterDirection.Output

            para(5) = New OracleParameter("flag", OracleType.Number, 2)
            para(5).Direction = ParameterDirection.Output

            oh.ExecuteDataSet("tour_sanct_rej_apply", para)

            If para(5).Value = 869 Then
                Dim ruldt As DataTable
                Dim rulcmd As String
                Dim rulqry As String = ""

                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_appl.Visible = False
                Me.cmd_Recommend.Visible = False
                Me.cmd_confirm.Visible = False

                rulcmd = "select * from ho_tour_rule ht where ht.stats_id=1 and ht.rule=1 and ht.emp_code=" + uid(0) + " order by ht.rule"
                ruldt = oh.ExecuteDataSet(rulcmd).Tables(0)


                If ruldt.Rows.Count > 0 Then

                    If ruldt.Rows(0)(4).ToString = "1" Then
                        Me.cmd_appl.Visible = True
                    End If
                    If ruldt.Rows(0)(5).ToString = "1" Then
                        Me.cmd_Recommend.Visible = True
                    End If
                    If ruldt.Rows(0)(6).ToString = "1" Then
                        Me.cmd_confirm.Visible = True
                    End If

                    Dim rowCount As Integer = ruldt.Rows.Count
                    For rowCounter As Integer = 0 To rowCount - 1
                        rulqry = rulqry + ruldt.Rows(rowCounter)(2).ToString
                    Next

                    dt = oh.ExecuteDataSet(rulqry).Tables(0)
                    Cmb_Select.DataSource = dt
                    Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                    Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                    Cmb_Select.DataBind()

                End If

            ElseIf para(5).Value = 1 Then     ' Branch_id=0 and Dep_head<>0  ie Head office     and ht.dep_id=" & para(3).Value & "

                'str = "select 0 as srnumber,'Please Select ' from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code  and ht.dep_id=" & para(3).Value & " and ht.branch_id=0 and ht.tour_id in (0,4) and ht.to_branch=bm1.branch_id and ht.emp_code <> " & ecode & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code  and ht.dep_id=" & para(3).Value & " and ht.branch_id=0 and ht.tour_id in (0,4) and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.emp_code <> " & ecode & " union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code  and ht.dep_id=" & para(3).Value & " and ht.branch_id=0 and ht.tour_id in (0,4) and ht.to_branch is null and ht.emp_code <> " & ecode & " order by srnumber"
                'str = "select 0 as empcode,'Please Select ' from dual union select em.emp_code as empcode,em.emp_code||' --- '||em.emp_name from employee_master em where em.branch_id = 0 and em.department_id in  (" & para(3).Value & ") and em.status_id = 1 and em.emp_code <> " & ecode & " order by empcode"
                str = "select 0 as empcode,'Please Select ' from dual union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em where  em.department_id in (" & para(3).Value & ") and em.status_id=1 and  em.branch_id=0 and em.emp_code<>" & uid(0) & "  union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em where  em.department_id in (" & para(3).Value & ") and em.branch_id=0 and (4) in (" & para(3).Value & " ) and em.status_id=1  and em.emp_code<>" & uid(0) & " union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em where  em.department_id in (" & para(3).Value & ") and em.branch_id<>0 and em.status_id=1 and (23) in (" & para(3).Value & " )   and em.emp_code<>" & uid(0) & " union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em where  em.department_id in (" & para(3).Value & ") and em.status_id=1 and em.branch_id<>0 and (37) in (" & para(3).Value & " )   and em.emp_code<>" & uid(0) & " union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em where  em.department_id in (" & para(3).Value & ") and em.branch_id<>0 and em.status_id=1 and (5) in (" & para(3).Value & " )   and em.emp_code<>" & uid(0) & " union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em where  em.department_id in (" & para(3).Value & ") and em.branch_id<>0 and (38) in (" & para(3).Value & " ) and em.status_id=1  and em.emp_code<>" & uid(0) & " union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em where  em.department_id in (" & para(3).Value & ") and em.branch_id<>0 and (180) in (" & para(3).Value & " ) and em.status_id=1  and em.emp_code<>" & uid(0) & " union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em where  em.department_id in (" & para(3).Value & ") and em.branch_id<>0 and (183) in (" & para(3).Value & " ) and em.status_id=1  and em.emp_code<>" & uid(0) & " union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em where  em.department_id in (" & para(3).Value & ") and em.branch_id=0 and (188) in (" & para(3).Value & " ) and em.status_id=1  and em.emp_code<>" & uid(0) & " union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em where  em.department_id in (" & para(3).Value & ") and em.branch_id=0 and (178) in (" & para(3).Value & " ) and em.status_id=1  and em.emp_code<>" & uid(0) & " order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()


            ElseIf para(5).Value = 2 Then     'BH

                'str = "select 0 as srnumber,'Please Select ' from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id not in(10,11,12,13,14,15,16,17,18,101,146,148,149,90,136,141,134,131,127,126,137,142,163,164,140,35,36,112,30,33,28,29,32,31,34,128,173) and ht.branch_id=" & Me.Session("branch_id") & " and ht.tour_id in (0,4) and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id not in(10,11,12,13,14,15,16,17,18,101,146,148,149,90,136,141,134,131,127,126,137,142,163,164,140,35,36,112,30,33,28,29,32,31,34,128,173) and ht.branch_id=" & Me.Session("branch_id") & " and ht.tour_id in (0,4) and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id not in(10,11,12,13,14,15,16,17,18,101,146,148,149,90,136,141,134,131,127,126,137,142,163,164,140,35,36,112,30,33,28,29,32,31,34,128,173) and ht.branch_id=" & Me.Session("branch_id") & " and ht.tour_id in (0,4) and ht.to_branch is null order by srnumber"
                str = "select 0 as empcode,'Please Select ' from dual union select em.emp_code as empcode,em.emp_code||'--'||em.emp_name||' -- '||upper(dp.dep_name) from employee_master em,department_mst dp where em.department_id = dp.dep_id and em.branch_id = " & brid & " /*and em.department_id = " & para(3).Value & "*/ and em.status_id = 1 and em.post_id not in(10,11,12,13,14,15,16,17,18,101,146,148,149,90,136,141,134,131,127,126,137,142,163,164,140,35,36,112,30,33,28,29,32,31,34,128,173) and em.emp_code <> " & ecode & " order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()

            ElseIf para(5).Value = 90 Then     'ASO
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode,'Please Select ' from dual union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em where  em.status_id=1 and  em.emp_code<>" & uid(0) & " and em.post_id  in (210) order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()
            ElseIf para(5).Value = 88 Then     'ASO
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode,'Please Select ' from dual union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em where  em.status_id=1 and  em.emp_code<>" & uid(0) & " and em.post_id  in (136,197,369,245,412,440) order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()
            ElseIf para(5).Value = 91 Then     'ASO
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode,'Please Select ' from dual union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em where  em.status_id=1 and  em.emp_code<>" & uid(0) & " and em.post_id  in (202,369,402) order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()
            ElseIf para(5).Value = 89 Then     'interview
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode,'Please Select ' from dual union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em where  em.status_id=1 and  em.emp_code<>" & uid(0) & " and em.post_id  in (202,210,136,221,197) order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()

            ElseIf para(5).Value = 92 Then     'interview
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode,'Please Select ' from dual union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em where  em.status_id=1 and  em.emp_code<>" & uid(0) & " and em.post_id  in (362) order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()

            ElseIf para(5).Value = 93 Then     'Insurance ASo/Coordinators
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode,'Please Select ' from dual union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em where  em.status_id=1 and  em.emp_code<>" & uid(0) & " and em.post_id  in (273,385) order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()

            ElseIf para(5).Value = 77 Then     'ASO
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode,'Please Select ' from dual union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em, employ_firm f where em.emp_code=f.emp_code and  em.status_id=1 and  em.emp_code<>" & uid(0) & " and em.post_id  in (322) order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()

            ElseIf para(5).Value = 55 Then     'audit
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode,'Please Select ' from dual union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em,employ_firm f where em.emp_code=f.emp_code and em.department_id in (" & para(3).Value & ") and f.firm_id=" & Session("firm_id") & "  and em.status_id in (1,11) and  em.branch_id=0 and em.emp_code<>" & uid(0) & " and em.branch_id  in (select b.branch_id from branch_dtl_new b,region_master r where r.reg_id=b.reg_id and r.reg_id in (" & para(4).Value & ")) and em.status_id in (1,11)  and em.emp_code<>" & uid(0) & " union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em,employ_firm f where em.emp_code=f.emp_code and  em.department_id in (" & para(3).Value & ") and f.firm_id=" & Session("firm_id") & " and em.branch_id<>0 and em.branch_id  in (select b.branch_id from branch_dtl_new b,region_master r where r.reg_id=b.reg_id and r.reg_id in (" & para(4).Value & ")) and em.status_id in (1,11)  and em.emp_code<>" & uid(0) & "  order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()

            ElseIf para(5).Value = 56 Then     'vigilance
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_confirm.Visible = False
                str = "select 0 as empcode,'Please Select ' from dual union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em where  em.department_id in (" & para(3).Value & ") and em.status_id=1 and  em.branch_id=0 and em.emp_code<>" & uid(0) & " and em.status_id=1  and em.emp_code<>" & uid(0) & " union select em.emp_code as empcode,em.emp_code||'       '||em.emp_name from employee_master em where  em.department_id in (" & para(3).Value & ") and em.branch_id<>0 and em.status_id=1  and em.emp_code<>" & uid(0) & "  order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()

            ElseIf para(5).Value = 3 Then         'Area Manager  so bh and emps in negative branches only to show

                'str = "select 0 as srnumber,'Please Select ' from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id in (10,11,12,13,14,15,16,17,18,101,146,148,149,90) and ht.branch_id in (select branch_id from area_detail where area_id=(select area_id from area_master where area_head_id=" & ecode & ")) and ht.tour_id in (0,4) and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id in (10,11,12,13,14,15,16,17,18,101,146,148,149,90) and ht.branch_id in (select branch_id from area_detail where area_id=(select area_id from area_master where area_head_id=" & ecode & ")) and ht.tour_id in (0,4) and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id in (10,11,12,13,14,15,16,17,18,101,146,148,149,90) and ht.branch_id in (select branch_id from area_detail where area_id=(select area_id from area_master where area_head_id=" & ecode & ")) and ht.tour_id in (0,4) and ht.to_branch is null order by srnumber"
                str = "select 0 as empcode,'Please Select ' from dual union select em.emp_code as empcode,em.emp_code||' -- '||em.emp_name||' -- '||upper(dp.dep_name) from employee_master em,department_mst dp where em.department_id = dp.dep_id and /*em.branch_id = " & brid & " and em.department_id = " & para(3).Value & " and*/ em.status_id = 1 and em.post_id in(10,11,12,13,14,15,16,17,18,101,146,148,149,90) and em.branch_id in (select branch_id from area_detail where area_id=(select area_id from area_master where area_head_id=" & ecode & ")) union select em.emp_code as empcode,em.emp_code||' --- '||em.emp_name||' --- '||upper(dp.dep_name)||' --- '||upper(bc.branch_name) from employee_master em,department_mst dp,before_completion bc where em.department_id = dp.dep_id and em.branch_id = bc.old_id and bc.branch_id is null and /*em.branch_id = " & brid & " and em.department_id = " & para(3).Value & " and*/ em.status_id = 1 and em.post_id not in(146,148,149,90,136,141,134,131,127,126,137,142,163,164,140,35,36,112,30,33,28,29,32,31,34,128,173) and bc.area_id=(select area_id from area_master where area_head_id=" & ecode & ") order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()
                '------------26/12/2011---------------------
            ElseIf para(5).Value = 101 Then
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode, 'Please Select '  from dual union select em.emp_code as empcode,em.emp_code || '---' || em.emp_name  from employee_master em where em.status_id = 1   and em.emp_code <> " & uid(0) & "   and  em.department_id in (108,445,434) order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()
                '----------------------------
            ElseIf para(5).Value = 102 Then
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode, 'Please Select '  from dual union select em.emp_code as empcode, em.emp_code || '---' || em.emp_name  from employee_master em where em.status_id = 1   and em.emp_code <> " & uid(0) & "   and em.department_id in (213,212,283,232) order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()
                '-----------------end-----------------------


            ElseIf para(5).Value = 103 Then
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode, 'please select' from dual union select t.emp_code as empcode,t.emp_code ||'---'||t.emp_name from employee_master t,employ_firm f where f.emp_code=t.emp_code and t.department_id=4 and f.firm_id=4 and t.branch_id <>0 and t.status_id=1"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()

            ElseIf para(5).Value = 104 Then
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode, 'Please Select '  from dual  union  select em.emp_code as empcode, em.emp_code || '---' || em.emp_name  from employee_master em  where em.status_id = 1  and em.emp_code <> " & uid(0) & " and em.department_id in (71)  order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()

                '--------------crm-audit--------------

            ElseIf para(5).Value = 105 Then
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                'str = "select 0 as empcode, 'Please Select '  from dual  union  select em.emp_code as empcode, em.emp_code || '---' || em.emp_name  from employee_master em  where em.status_id = 1  and em.emp_code <> " & uid(0) & " and em.department_id in (443)  order by empcode"
                str = "select 0 as empcode, 'Please Select '  from dual  union  select em.emp_code as empcode, em.emp_code || '---' || em.emp_name  from employee_master em  where em.status_id = 1  and em.emp_code <> " & uid(0) & "  and em.department_id in (443)  union  select em.emp_code as empcode, em.emp_code || '---' || em.emp_name  from employee_master em  where em.status_id = 1  and em.emp_code <> " & uid(0) & "  and em.department_id in (176)  and em.POST_ID in (362)  order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()

                '---------------------------------------------------

                '--------------------------hard ware staff---------------------------

            ElseIf para(5).Value = 106 Then
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode, 'Please Select '  from dual  union  select em.emp_code as empcode, em.emp_code || '       ' || em.emp_name  from employee_master em,branch b  where em.status_id = 1  and em.emp_code <>" & uid(0) & "  and em.post_id in (39,310)  and b.BRANCH_ID=em.branch_id   order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()


            ElseIf para(5).Value = 107 Then
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode, 'Please Select '  from dual  union  select em.emp_code as empcode, em.emp_code || '       ' || em.emp_name  from employee_master em,branch b  where em.status_id = 1  and em.emp_code <>" & uid(0) & "  and em.post_id in (39,310)  and b.BRANCH_ID=em.branch_id  and b.STATE_ID in (18,19,20)  order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()

            ElseIf para(5).Value = 112 Then
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode, 'Please Select '  from dual  union  select em.emp_code as empcode, em.emp_code || '       ' || em.emp_name  from employee_master em,branch b,employ_firm ef  where em.status_id = 1 and em.emp_code=ef.emp_code and ef.firm_id=" & Session("firm_id") & "  and em.emp_code <>" & uid(0) & "  and em.post_id in (39,310)  and b.BRANCH_ID=em.branch_id   order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()

            ElseIf para(5).Value = 113 Then
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode, 'Please Select '  from dual  union  select em.emp_code as empcode, em.emp_code || '       ' || em.emp_name  from employee_master em, branch b  where em.status_id = 1   and em.emp_code <> " & uid(0) & "  and b.status_id in (9)  and b.BRANCH_ID = em.branch_id  union  select em.emp_code as empcode, em.emp_code || '       ' || em.emp_name  from employee_master em, branch b  where em.status_id = 1  and em.emp_code <>" & uid(0) & "  and b.firm_id = 4  and em.department_id in (107,412,471)  and em.branch_id not in (0)  and b.BRANCH_ID = em.branch_id"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()

            ElseIf para(5).Value = 114 Then
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode, 'Please Select '  from dual  union  select em.emp_code as empcode, em.emp_code || '       ' || em.emp_name  from employee_master em, branch b,employ_firm ef  where em.status_id = 1  and em.emp_code <>" & uid(0) & "  and em.emp_code=ef.emp_code  and b.BRANCH_ID = em.branch_id  and em.emp_code not in (20002)  and ef.firm_id=4  union  select em.emp_code as empcode, em.emp_code || '       ' || em.emp_name  from employee_master em, branch b,employ_firm ef  where em.status_id = 1  and em.emp_code <> " & uid(0) & "  and b.firm_id = 4  and em.department_id in (107, 412, 471)  and em.emp_code=ef.emp_code  and em.emp_code not in (20002)  and ef.firm_id=4  and b.BRANCH_ID = em.branch_id"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()

            ElseIf para(5).Value = 115 Then
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode, 'Please Select ' from dual union select em.emp_code as empcode, em.emp_code || '       ' || em.emp_name  from employee_master em, branch b, employ_firm ef where em.status_id = 1   and em.emp_code <>" & uid(0) & "   and em.emp_code = ef.emp_code   and b.BRANCH_ID = em.branch_id   and ef.firm_id = 24"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()



            ElseIf para(5).Value = 108 Then
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode, 'Please Select '  from dual  union  select em.emp_code as empcode, em.emp_code || '       ' || em.emp_name  from employee_master em,branch b  where em.status_id = 1  and em.emp_code <>" & uid(0) & "  and em.post_id in (39,310)  and b.BRANCH_ID=em.branch_id   order by empcode"
                'str = "select 0 as empcode, 'Please Select '  from dual  union  select em.emp_code as empcode, em.emp_code || '---' || em.emp_name  from employee_master em  where em.status_id = 1  and em.emp_code <> " & uid(0) & "  and em.department_id in (443)  union  select em.emp_code as empcode, em.emp_code || '---' || em.emp_name  from employee_master em  where em.status_id = 1  and em.emp_code <> " & uid(0) & "  and em.department_id in (176)  and em.POST_ID in (362)  order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()



            ElseIf para(5).Value = 110 Then
                '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                Me.cmd_Recommend.Visible = False
                Me.cmd_appl.Visible = False
                str = "select 0 as empcode, 'Please Select '  from dual  union  select em.emp_code as empcode, em.emp_code || '       ' || em.emp_name  from employee_master em, branch b  where em.status_id = 1  and em.emp_code <> " & uid(0) & "  and em.department_id in (491)  and b.BRANCH_ID = em.branch_id  order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()





                '=-==-=====-=-=-=-=-==-=-=-=-=--=-=--=-=-modi starts of 26 may 2009=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
                ''Conditions Changed..!!No divisional magers post.so regional mangers direct to area managers

                'ElseIf para(5).Value = 4 Then       'Divisional Manager  so only Area Managers

                '    str = "select 0 as srnumber,'Please Select ' from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131) and ht.emp_code in(select aa.area_head_id from area_master aa where aa.area_id in(select d.area_id from division_detail d where d.div_id in (select a.division_id from division_master a where a.div_head_id=" & ecode & "))) and ht.tour_id in (0,4) and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131) and ht.emp_code in(select aa.area_head_id from area_master aa where aa.area_id in(select d.area_id from division_detail d where d.div_id in (select a.division_id from division_master a where a.div_head_id=" & ecode & "))) and ht.tour_id in (0,4) and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131) and ht.emp_code in(select aa.area_head_id from area_master aa where aa.area_id in(select d.area_id from division_detail d where d.div_id in (select a.division_id from division_master a where a.div_head_id=" & ecode & "))) and ht.tour_id in (0,4) and ht.to_branch is null order by srnumber"
                '    dt = oh.ExecuteDataSet(str).Tables(0)
                '    Cmb_Select.DataSource = dt
                '    Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                '    Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                '    Cmb_Select.DataBind()

                'ElseIf para(5).Value = 5 Then       'Region Manager so only Divisional Manager

                '    str = "select 0 as srnumber,'Please Select ' from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id in (127,126,137,142,163,164,140) and ht.emp_code in(select dd.div_head_id from division_master dd where dd.division_id in(select rd.division_id from region_detail rd where rd.region_id in (select rm.reg_id from region_master rm where rm.head_id=" & ecode & "))) and ht.tour_id in (0,4) and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id in (127,126,137,142,163,164,140) and ht.emp_code in(select dd.div_head_id from division_master dd where dd.division_id in(select rd.division_id from region_detail rd where rd.region_id in (select rm.reg_id from region_master rm where rm.head_id=" & ecode & "))) and ht.tour_id in (0,4) and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id in (127,126,137,142,163,164,140) and ht.emp_code in(select dd.div_head_id from division_master dd where dd.division_id in(select rd.division_id from region_detail rd where rd.region_id in (select rm.reg_id from region_master rm where rm.head_id=" & ecode & "))) and ht.tour_id in (0,4) and ht.to_branch is null order by srnumber"
                '    dt = oh.ExecuteDataSet(str).Tables(0)
                '    Cmb_Select.DataSource = dt
                '    Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                '    Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                '    Cmb_Select.DataBind()

                ''=-=-=-====-=-=-==-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=
                'so new  query will be:

            ElseIf para(5).Value = 5 Then       'Region Manager so only Area Manager

                'str = "select 0 as srnumber,'Please Select ' from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131) and ht.emp_code in (select aa.area_head_id from area_master aa where aa.area_id in (select bd.area_id from branch_detail bd where bd.reg_id in (select c.reg_id from region_master c where c.head_id=" & ecode & "))) and ht.tour_id in (0,4) and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131) and ht.emp_code in (select aa.area_head_id from area_master aa where aa.area_id in (select bd.area_id from branch_detail bd where bd.reg_id in (select c.reg_id from region_master c where c.head_id=" & ecode & "))) and ht.tour_id in (0,4) and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id in (136,141,134,131) and ht.emp_code in (select aa.area_head_id from area_master aa where aa.area_id in (select bd.area_id from branch_detail bd where bd.reg_id in (select c.reg_id from region_master c where c.head_id=" & ecode & "))) and ht.tour_id in (0,4) and ht.to_branch is null order by srnumber"
                str = "select 0 as empcode,'Please Select ' from dual union select em.emp_code as empcode,em.emp_code||' -- '||em.emp_name||' -- '||upper(dp.dep_name) from employee_master em,department_mst dp where em.department_id = dp.dep_id and /*em.branch_id = " & brid & " and em.department_id = " & para(3).Value & " and*/ em.status_id = 1 and em.post_id in(136,141,134,131) and em.emp_code in (select aa.area_head_id from area_master aa where aa.area_id in (select bd.area_id from branch_detail bd where bd.reg_id in (select c.reg_id from region_master c where c.head_id=" & ecode & "))) order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()



                '=-=-=-=-===-=-=-=-=-=-=-=-=-=-=-=-=-=modi ends of 26 may 2009=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-

            ElseIf para(5).Value = 6 Then       'Zonal Manager so only region manager

                'str = "select 0 as srnumber,'Please Select ' from dual union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bm1.branch_name||' (Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,branch_master bm1 where ht.emp_code=em.emp_code and ht.post_id in (35,36,112,30,33,28,29,32,31,34,128) and ht.emp_code in(select rm.head_id from region_master rm where rm.reg_id in(select zd.region_id from zonal_detail zd where zd.zonal_id in (select zm.zonal_id from zonal_master zm where zm.head_id=" & ecode & "))) and ht.tour_id in (0,4) and ht.to_branch=bm1.branch_id union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||bc1.branch_name||' (N.O.Branch)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em,before_completion bc1 where ht.emp_code=em.emp_code and ht.post_id in (35,36,112,30,33,28,29,32,31,34,128) and ht.emp_code in(select rm.head_id from region_master rm where rm.reg_id in(select zd.region_id from zonal_detail zd where zd.zonal_id in (select zm.zonal_id from zonal_master zm where zm.head_id=" & ecode & "))) and ht.tour_id in (0,4) and ht.to_branch=bc1.old_id and bc1.branch_id is null union select ht.sr_number as srnumber,ht.emp_code||'       '||em.emp_name||'       '||'from:'||' '||to_char(ht.from_dt)||'       '||'To:'||' '||to_char(ht.to_dt)||'       '||'Tour To:'||' '||Decode(ht.others,null,'Not Specified',ht.others)||' (Other Place)'||'    Purpose: '||decode(ht.tour_purpose,null,'Not Specified',ht.tour_purpose) from hrm_tour_dtl ht,employee_master em where ht.emp_code=em.emp_code and ht.post_id in (35,36,112,30,33,28,29,32,31,34,128) and ht.emp_code in(select rm.head_id from region_master rm where rm.reg_id in(select zd.region_id from zonal_detail zd where zd.zonal_id in (select zm.zonal_id from zonal_master zm where zm.head_id=" & ecode & "))) and ht.tour_id in (0,4) and ht.to_branch is null order by srnumber"
                str = "select 0 as empcode,'Please Select ' from dual union select em.emp_code as empcode,em.emp_code||' -- '||em.emp_name||' -- '||upper(dp.dep_name) from employee_master em,department_mst dp where em.department_id = dp.dep_id and /*em.branch_id = 0 and em.department_id = 0 and*/ em.status_id = 1 and em.post_id in (35,36,112,30,33,28,29,32,31,34,128) and em.emp_code in (select rm.head_id from region_master rm where rm.reg_id in (select zd.region_id from zonal_detail zd where zd.zonal_id in (select zm.zonal_id from zonal_master zm where zm.hr_head=" & ecode & "))) order by empcode"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_Select.DataSource = dt
                Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Cmb_Select.DataBind()

            ElseIf para(5).Value = 10 Then         'Not an authorised Person in Head officew

                Dim cl_script2 As New StringBuilder
                cl_script2.Append(" alert('You Have No Authority to View this page!!! ');")
                cl_script2.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script2.ToString, True)


            ElseIf para(5).Value = 11 Then         'Not an authorised Person in Branch and no zm_headid in zonal_masteer

                Dim cl_script3 As New StringBuilder
                cl_script3.Append(" alert('You Have No Authority!!! ');")
                cl_script3.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script3.ToString, True)


            ElseIf para(5).Value = 0 Then

                Dim cl_script3 As New StringBuilder
                cl_script3.Append(" alert('Some Problems May Have Occured..!! (Exception!!) ');")
                cl_script3.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script3.ToString, True)

                'ElseIf para(5).Value = 869 Then
                '    Dim fid As String = Me.Session("firm_id").ToString
                '    '   Dim dt55 As DataTable = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & uid(0) & "").Tables(0)
                '    Me.cmd_Recommend.Visible = False
                '    Me.cmd_appl.Visible = False
                '    str = "select 0 as empcode, 'Please Select ' from dual union select em.emp_code as empcode, em.emp_code || '       ' || em.emp_name  from employee_master em, employ_firm ef where em.status_id = 1   and em.emp_code <>" & uid(0) & "   and em.emp_code = ef.emp_code   and ef.firm_id =" & fid & " order by empcode"
                '    dt = oh.ExecuteDataSet(str).Tables(0)
                '    Cmb_Select.DataSource = dt
                '    Cmb_Select.DataValueField = dt.Columns(0).ColumnName
                '    Cmb_Select.DataTextField = dt.Columns(1).ColumnName
                '    Cmb_Select.DataBind()

            End If
        Catch ex As Exception
            Dim cl_script5 As New StringBuilder
            cl_script5.Append("   alert('" & ex.ToString & " ') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script5.ToString, True)

        Finally
        End Try

    End Sub
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim ftime, ttime As String
        ftime = Me.Txt_FromTime.Value
        ttime = Me.Txt_ToTime.Value
        'Dim dt2 As DataTable
        'dt2 = oh.ExecuteDataSet("select sysdate from dual").Tables(0)

        Dim script1 As New System.Text.StringBuilder
        Dim place, other As String
        If (Me.chk_br.Checked = True) Then
            place = Me.cmb_place.SelectedValue
        Else
            place = ""
        End If

        If (Me.chk_oth.Checked = True) Then
            other = Me.Txt_oth.Text
        Else
            other = ""
        End If
        Dim parameter(11) As OracleParameter
        parameter(0) = New OracleParameter("emp", OracleType.Number, 8)
        parameter(0).Direction = ParameterDirection.Input
        parameter(0).Value = Me.Cmb_Select.SelectedValue
        parameter(1) = New OracleParameter("fdt", OracleType.DateTime, 20)
        parameter(1).Direction = ParameterDirection.Input
        'parameter(1).Value = Format(CDate(Me.Txt_fdt.Text), "dd/MMM/yyyy")
        parameter(1).Value = Me.Txt_fdt.Text
        parameter(2) = New OracleParameter("tdt", OracleType.DateTime, 20)
        parameter(2).Direction = ParameterDirection.Input
        'parameter(2).Value = Format(CDate(Me.Txt_tdt.Text), "dd/MMM/yyyy")
        parameter(2).Value = Me.Txt_tdt.Text
        parameter(3) = New OracleParameter("ftm", OracleType.VarChar, 30)
        parameter(3).Direction = ParameterDirection.Input
        parameter(3).Value = ftime
        parameter(4) = New OracleParameter("ttm", OracleType.VarChar, 30)
        parameter(4).Direction = ParameterDirection.Input
        parameter(4).Value = ttime
        parameter(5) = New OracleParameter("pla", OracleType.VarChar, 10)
        parameter(5).Direction = ParameterDirection.Input
        parameter(5).Value = place
        parameter(6) = New OracleParameter("purp", OracleType.VarChar, 80)
        parameter(6).Direction = ParameterDirection.Input
        parameter(6).Value = Me.Txt_purp.Text
        parameter(7) = New OracleParameter("oth", OracleType.VarChar, 80)
        parameter(7).Direction = ParameterDirection.Input
        parameter(7).Value = other
        parameter(8) = New OracleParameter("adv", OracleType.Number, 10)
        parameter(8).Direction = ParameterDirection.Input
        parameter(8).Value = Me.Txt_adv.Text
        parameter(9) = New OracleParameter("msg", OracleType.VarChar, 150)
        parameter(9).Direction = ParameterDirection.Output

        'sancperson
        parameter(10) = New OracleParameter("sancperson", OracleType.Number, 6)
        parameter(10).Direction = ParameterDirection.Input
        parameter(10).Value = sanemp

        parameter(11) = New OracleParameter("id", OracleType.Number, 1)
        parameter(11).Direction = ParameterDirection.Input
        'Code conditionally set for Macom HR to handle apply/Recommend/Sanction seperately.     
        If Session("firm_id") = 8 Then
            parameter(11).Value = 3  ' for Apply and Sanction
        Else
            parameter(11).Value = 1  ' for sanction
        End If


        If Session("firm_id") = 8 Then
            oh.ExecuteNonQuery("TOUR_APPLY_HR_NEW", parameter)
        Else
            oh.ExecuteNonQuery("tour_apply_all", parameter)
        End If
        '----------------------------------------------

        Dim message As String
        message = parameter(9).Value

        script1.Append("        alert('" & message & "');")

        script1.Append("window.open('Ho_tour_apply.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)


    End Sub


    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim SrlNO As Integer = CInt(eventArgument)
        Dim cal_data = eventArgument
        Dim dis As Integer = cal_data
        Dim st As New StringBuilder
        Try
            If Session("firm_id") = 24 Then
                '                     0              1          2               3                     4               5                                  6                                                                               7
                str1 = "select e.emp_code||' --- '||e.emp_name||'*'||d.dep_name||'*'||ds.designation||'*'||p.post_name||'*'||b.branch_name,e.emp_code from employee_master e,department_mst d,designation_master ds,post_mst_jwell p,branch_master b where e.department_id=d.dep_id and e.designation_id=ds.designation_id and e.post_id=p.post_id and e.branch_id=b.branch_id and e.emp_code=" & SrlNO & " union select e.emp_code||' --- '||e.emp_name||'*'||d.dep_name||'*'||ds.designation||'*'||p.post_name||'*'||bc.branch_name||'(N.O.B)',e.emp_code from employee_master e,department_mst d,designation_master ds,post_mst_jwell p,before_completion bc where e.department_id=d.dep_id and e.designation_id=ds.designation_id and e.post_id=p.post_id and e.branch_id=bc.old_id and bc.branch_id is null and e.emp_code=" & SrlNO & "" 'ht.emp_code and ht.sr_number=
            Else
                str1 = "select e.emp_code||' --- '||e.emp_name||'*'||d.dep_name||'*'||ds.designation||'*'||p.post_name||'*'||b.branch_name,e.emp_code from employee_master e,department_mst d,designation_master ds,post_mst p,branch_master b where e.department_id=d.dep_id and e.designation_id=ds.designation_id and e.post_id=p.post_id and e.branch_id=b.branch_id and e.emp_code=" & SrlNO & " union select e.emp_code||' --- '||e.emp_name||'*'||d.dep_name||'*'||ds.designation||'*'||p.post_name||'*'||bc.branch_name||'(N.O.B)',e.emp_code from employee_master e,department_mst d,designation_master ds,post_mst p,before_completion bc where e.department_id=d.dep_id and e.designation_id=ds.designation_id and e.post_id=p.post_id and e.branch_id=bc.old_id and bc.branch_id is null and e.emp_code=" & SrlNO & "" 'ht.emp_code and ht.sr_number=
            End If
            dt1 = oh.ExecuteDataSet(str1).Tables(0)

            If dt1.Rows.Count > 0 Then

                st.Append(dt1.Rows(0)(0))
                st.Append("@")
                st.Append("!")
            Else
                st.Append("$")
                st.Append("@")
                st.Append("!")
            End If
        Catch ex As Exception
        Finally

        End Try
        
        res = st.ToString
    End Sub
    Protected Sub cmd_Recommend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Recommend.Click
        Dim ftime, ttime As String
        ftime = Me.Txt_FromTime.Value
        ttime = Me.Txt_ToTime.Value

        Dim script2 As New System.Text.StringBuilder

        Dim place, other As String
        If (Me.chk_br.Checked = True) Then
            place = Me.cmb_place.SelectedValue
        Else
            place = ""
        End If

        If (Me.chk_oth.Checked = True) Then
            other = Me.Txt_oth.Text
        Else
            other = ""
        End If
        Dim parameter(11) As OracleParameter
        parameter(0) = New OracleParameter("emp", OracleType.Number, 8)
        parameter(0).Direction = ParameterDirection.Input
        parameter(0).Value = Me.Cmb_Select.SelectedValue
        parameter(1) = New OracleParameter("fdt", OracleType.DateTime, 20)
        parameter(1).Direction = ParameterDirection.Input
        'parameter(1).Value = Format(CDate(Me.Txt_fdt.Text), "dd/MMM/yyyy")
        parameter(1).Value = Me.Txt_fdt.Text
        parameter(2) = New OracleParameter("tdt", OracleType.DateTime, 20)
        parameter(2).Direction = ParameterDirection.Input
        'parameter(2).Value = Format(CDate(Me.Txt_tdt.Text), "dd/MMM/yyyy")
        parameter(2).Value = Me.Txt_tdt.Text
        parameter(3) = New OracleParameter("ftm", OracleType.VarChar, 20)
        parameter(3).Direction = ParameterDirection.Input
        parameter(3).Value = ftime
        parameter(4) = New OracleParameter("ttm", OracleType.VarChar, 20)
        parameter(4).Direction = ParameterDirection.Input
        parameter(4).Value = ttime
        parameter(5) = New OracleParameter("pla", OracleType.VarChar, 20)
        parameter(5).Direction = ParameterDirection.Input
        parameter(5).Value = place
        parameter(6) = New OracleParameter("purp", OracleType.VarChar, 80)
        parameter(6).Direction = ParameterDirection.Input
        parameter(6).Value = Me.Txt_purp.Text
        parameter(7) = New OracleParameter("oth", OracleType.VarChar, 80)
        parameter(7).Direction = ParameterDirection.Input
        parameter(7).Value = other
        parameter(8) = New OracleParameter("adv", OracleType.Number, 10)
        parameter(8).Direction = ParameterDirection.Input
        parameter(8).Value = Me.Txt_adv.Text
        parameter(9) = New OracleParameter("msg", OracleType.VarChar, 150)
        parameter(9).Direction = ParameterDirection.Output
        'sancperson
        parameter(10) = New OracleParameter("sancperson", OracleType.Number, 6)
        parameter(10).Direction = ParameterDirection.Input
        parameter(10).Value = sanemp

        parameter(11) = New OracleParameter("id", OracleType.Number, 1)
        parameter(11).Direction = ParameterDirection.Input
        parameter(11).Value = 2   ' For Recommend

        'Code conditionally set for Macom HR to handle apply/Recommend/Sanction seperately.
        If Session("firm_id") = 8 Then
            oh.ExecuteNonQuery("TOUR_APPLY_HR_NEW", parameter)
        Else
            oh.ExecuteNonQuery("tour_apply_all", parameter)
        End If
        '----------------------------------------------

        Dim message As String
        message = parameter(9).Value

        script2.Append("        alert('" & message & "');")

        script2.Append("window.open('Ho_tour_apply.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script2.ToString, True)
    End Sub

    Protected Sub cmd_appl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_appl.Click
        Dim ftime, ttime As String
        ftime = Me.Txt_FromTime.Value
        ttime = Me.Txt_ToTime.Value
        'Dim dt2 As DataTable
        'dt2 = oh.ExecuteDataSet("select sysdate from dual").Tables(0)

        Dim script1 As New System.Text.StringBuilder
        Dim place, other As String
        If (Me.chk_br.Checked = True) Then
            place = Me.cmb_place.SelectedValue
        Else
            place = ""
        End If

        If (Me.chk_oth.Checked = True) Then
            other = Me.Txt_oth.Text
        Else
            other = ""
        End If
        Dim parameter(11) As OracleParameter
        parameter(0) = New OracleParameter("emp", OracleType.Number, 8)
        parameter(0).Direction = ParameterDirection.Input
        parameter(0).Value = Me.Cmb_Select.SelectedValue
        parameter(1) = New OracleParameter("fdt", OracleType.DateTime, 20)
        parameter(1).Direction = ParameterDirection.Input
        'parameter(1).Value = Format(CDate(Me.Txt_fdt.Text), "dd/MMM/yyyy")
        parameter(1).Value = Me.Txt_fdt.Text
        parameter(2) = New OracleParameter("tdt", OracleType.DateTime, 20)
        parameter(2).Direction = ParameterDirection.Input
        'parameter(2).Value = Format(CDate(Me.Txt_tdt.Text), "dd/MMM/yyyy")
        parameter(2).Value = Me.Txt_tdt.Text
        parameter(3) = New OracleParameter("ftm", OracleType.VarChar, 30)
        parameter(3).Direction = ParameterDirection.Input
        parameter(3).Value = ftime
        parameter(4) = New OracleParameter("ttm", OracleType.VarChar, 30)
        parameter(4).Direction = ParameterDirection.Input
        parameter(4).Value = ttime
        parameter(5) = New OracleParameter("pla", OracleType.VarChar, 10)
        parameter(5).Direction = ParameterDirection.Input
        parameter(5).Value = place
        parameter(6) = New OracleParameter("purp", OracleType.VarChar, 80)
        parameter(6).Direction = ParameterDirection.Input
        parameter(6).Value = Me.Txt_purp.Text
        parameter(7) = New OracleParameter("oth", OracleType.VarChar, 80)
        parameter(7).Direction = ParameterDirection.Input
        parameter(7).Value = other
        parameter(8) = New OracleParameter("adv", OracleType.Number, 10)
        parameter(8).Direction = ParameterDirection.Input
        parameter(8).Value = Me.Txt_adv.Text
        parameter(9) = New OracleParameter("msg", OracleType.VarChar, 150)
        parameter(9).Direction = ParameterDirection.Output

        'sancperson
        parameter(10) = New OracleParameter("sancperson", OracleType.Number, 6)
        parameter(10).Direction = ParameterDirection.Input
        parameter(10).Value = sanemp

        parameter(11) = New OracleParameter("id", OracleType.Number, 1)
        parameter(11).Direction = ParameterDirection.Input

        'Code conditionally set for Macom HR to handle apply/Recommend/Sanction seperately.
        If Session("firm_id") = 8 Then
            parameter(11).Value = 1  ' for Apply
        Else
            parameter(11).Value = 3  ' for sanction
        End If

        If Session("firm_id") = 8 Then
            oh.ExecuteNonQuery("TOUR_APPLY_HR_NEW", parameter)
        Else
            oh.ExecuteNonQuery("tour_apply_all", parameter)
        End If
        '----------------------------------------------


        Dim message As String
        message = parameter(9).Value

        script1.Append("        alert('" & message & "');")

        script1.Append("window.open('Ho_tour_apply.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)


    End Sub
End Class
