Imports System.Data
Imports System.Data.OracleClient
Partial Class Employee_Punching_Movement_Recommend_Macom_33cdcf157521
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3, dtj, ceo, depp, dtr, dta As New DataTable
    Dim sf() As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_purp.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Dim dep1 As String = " "
        Dim fid As Integer = Session("firm_id")
        Dim s As String = "select s.post_id from employee_master s where s.emp_code=" & User(0) & " "
        dta = oh.ExecuteDataSet("select s.post_id from employee_master s where s.emp_code=" & User(0) & "").Tables(0)
        If Not IsPostBack Then
            dt1 = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=6000 and s.emp_id=" & dta.Rows(0)(0) & "").Tables(0)

            'dt1 = oh.ExecuteDataSet("select count(*) from mactech.tbl_movement_mst t where t.rec_usr=" & User(0) & " and t.status_id=0").Tables(0)
            If dt1.Rows(0)(0) > 0 Then
                dt = oh.ExecuteDataSet("select '----SELECT----', '0' as empcode from dual union select t.emp_code || '~' || t.emp_name as ID, t.emp_code || '~' || t.reqst_dt || '~' || t.exit_time || '~' || t.entry_time || '~' || s.dep_name || '~' || t.place || '~' || t.purpose || '~' || t.rec_usr || '~' || t.aprv_usr as Details from TBL_MOVEMENT_MST t, department_mst s where t.department_id = s.dep_id and t.status_id =0 and t.reqst_dt =to_date(sysdate) and t.rec_usr =" & User(0) & "").Tables(0)
                If dt.Rows.Count > 0 Then
                    cmb_emp.DataSource = dt
                    cmb_emp.DataValueField = dt.Columns(1).ColumnName
                    cmb_emp.DataTextField = dt.Columns(0).ColumnName
                    cmb_emp.DataBind()
                Else
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('No Data Found!!!!');")
                    cl_script1.Append(" window.open('Regularise_Recommend.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                End If
            Else
                Me.Server.Transfer("../show_err.aspx")
            End If
        End If
        Me.Text_RJTRSN.Visible = False
        Me.New_Reject.Visible = False
        Me.Label1.Visible = False
    End Sub


    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click

        Me.New_Reject.Enabled = False
        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")

        Dim dt2 As DataTable
        dt2 = oh.ExecuteDataSet("select sysdate from dual").Tables(0)
        Dim arr, arr1 As Array

        arr = Me.cmb_emp.SelectedValue.Split("~")
        'arr1 = arr(0).split("-----")




        Dim script1 As New System.Text.StringBuilder
        Try


            Dim sq178 As String = "update TBL_MOVEMENT_MST s set s.status_id = 1, s.recommend_by =:recode, s.reccomend_dt = sysdate where s.emp_code =:code and s.rec_usr =:recode and s.status_id = 0"

            Dim prrr(1) As OracleParameter

            prrr(0) = New OracleParameter
            prrr(0).ParameterName = "code"
            prrr(0).OracleType = OracleType.Number
            prrr(0).Direction = ParameterDirection.Input
            prrr(0).Value = arr(0)

            prrr(1) = New OracleParameter
            prrr(1).ParameterName = "recode"
            prrr(1).OracleType = OracleType.Number
            prrr(1).Direction = ParameterDirection.Input
            prrr(1).Value = sf(0)

            If oh.ExecuteNonQuery(sq178, prrr) Then


                Dim cl_scrip1 As New StringBuilder
                cl_scrip1.Append("   alert('Recommended Successfully') ;")
                cl_scrip1.Append("window.open('Movement_Recommend_Macom.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
                'Me.btn_reject.Enabled = False
            End If


            Me.EMP_CODE.Value = ""
            Me.Txt_emp.Value = ""
            Me.Txt_fdt.Text = ""
            Me.Txt_From.Text = ""
            'Me.Txt_To.Text = ""
            Me.Txt_dep.Value = ""
            Me.Textplace.Value = ""
            Me.Txt_purp.Text = ""

            'Me.Txt_movtype.Text = " "





        Catch ex As Exception

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("                        alert('Error. please check the values entered.');")
            'cl_script1.Append("window.open('Movement_Recommend_Macom.aspx','_self');")

            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        End Try



    End Sub
    'Sub loadfile()
    '    sf = Session("user_id").ToString.Split("!")

    '    Me.Txt_br.Value = ""
    '    Me.Txt_dep.Value = ""
    '    Me.Txt_des.Value = ""
    '    Me.Txt_emp.Value = ""
    '    Me.Txt_fdt.Text = ""
    '    Me.Txt_post.Value = ""
    '    Me.Txt_purp.Text = ""
    '    cmb_emp.SelectedValue = 0

    '    Me.Txt_To.Text = ""
    '    Me.Txt_From.Text = ""

    '    dt = oh.ExecuteDataSet("select '----SELECT----','0' as empcode from dual union select e.emp_code || '-----' || e.emp_name || '-----' || to_char(a.going_dt), e.emp_code || '-----' || e.emp_name || '*' || d.dep_name || '*' || ds.designation || '*' || p.post_name || '*' || b.branch_name || '*' || to_char(a.going_dt) || '*' ||a.frm_time||'*'||a.to_time||'*'|| a.reason from hrm_movement_appl a, employee_master e, department_mst d, designation_master ds, post_mst p, branch b where a.emp_code = e.emp_code and a.status in (0) and e.department_id = d.dep_id and e.designation_id = ds.designation_id and e.post_id = p.post_id  and e.post_id=976 and e.branch_id = b.BRANCH_ID ").Tables(0)
    '    If dt.Rows.Count > 0 Then
    '        cmb_emp.DataSource = dt
    '        cmb_emp.DataValueField = dt.Columns(1).ColumnName
    '        cmb_emp.DataTextField = dt.Columns(0).ColumnName
    '        cmb_emp.DataBind()
    '    End If
    'End Sub

    Protected Sub cmb_emp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_emp.SelectedIndexChanged
        Dim arr As Array
        arr = Me.cmb_emp.SelectedValue.Split("~")
        Me.EMP_CODE.Value = arr(0)
        Me.Txt_emp.Value = arr(1)
        Me.Txt_fdt.Text = arr(2)
        Me.Txt_From.Text = arr(3)
        'Me.Txt_To.Text = arr(3)
        Me.Txt_dep.Value = arr(4)
        Me.Textplace.Value = arr(5)
        Me.Txt_purp.Text = arr(6)
        'Me.Txt_post.Value = arr(7)
        'Me.Txt_br.Value = arr(8)

        'Me.Txt_dep.Value = arr(1)
        'Me.Txt_des.Value = arr(2)
        'Me.Txt_post.Value = arr(3)
        'Me.Txt_br.Value = arr(4)
        'Me.Txt_fdt.Text = arr(5)
        'Me.Txt_From.Text = arr(6)
        'Me.Txt_To.Text = arr(7)
        'Me.Textplace.Value = arr(8)
        'Me.Txt_purp.Text = arr(9)

        'If (arr(7) = 1) Then
        '    Me.Txt_movtype.Value = "PERSONAL"
        'ElseIf (arr(7) = 2) Then
        ''    Me.Txt_movtype.Value = "OFFICIAL"
        'End If


        'Me.Txt_movtype.Value = arr(10)


    End Sub

    Protected Sub cmd_reject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_reject.Click
        Me.Text_RJTRSN.Visible = True
        Me.New_Reject.Visible = True
        Me.Label1.Visible = True
        Me.cmd_reject.Visible = False
        Me.cmd_confirm.Enabled = False
    End Sub

    Protected Sub New_Reject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles New_Reject.Click
        'Me.cmd_confirm.Enabled = False
        If (Text_RJTRSN.Text = "") Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Enter Rejected Reason..!!');")
            cl_script1.Append("window.open('Movement_Recommend_Macom.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else

            Dim sf() As String
            sf = Session("user_id").ToString.Split("!")

            Dim dt2 As DataTable
            dt2 = oh.ExecuteDataSet("select sysdate from dual").Tables(0)
            Dim arr, arr1 As Array

            arr = Me.cmb_emp.SelectedValue.Split("~")
            'arr1 = arr(0).split("-----")




            Dim script1 As New System.Text.StringBuilder
            Try


                'Dim sq17 As String = "UPDATE tbl_regularisation h set h.app_person= :appcode,h.status=:status,h.app_remarks=:remarks,h.app_date=:appdt,h.pay_id=:payid where h.apply_dt=:appdate1 and h.emp_code=:code"
                Dim sq178 As String = "update TBL_MOVEMENT_MST s set s.status_id = 3, s.recommend_by = :recode, s.reccomend_dt = sysdate, s.rej_reason = :reason where s.emp_code = :code and s.rec_usr = :recode and s.status_id =0"

                Dim prrr(2) As OracleParameter

                prrr(0) = New OracleParameter
                prrr(0).ParameterName = "code"
                prrr(0).OracleType = OracleType.Number
                prrr(0).Direction = ParameterDirection.Input
                prrr(0).Value = arr(0)

                prrr(1) = New OracleParameter
                prrr(1).ParameterName = "reason"
                prrr(1).OracleType = OracleType.VarChar
                prrr(1).Direction = ParameterDirection.Input
                prrr(1).Value = Me.Text_RJTRSN.Text


                prrr(2) = New OracleParameter
                prrr(2).ParameterName = "recode"
                prrr(2).OracleType = OracleType.Number
                prrr(2).Direction = ParameterDirection.Input
                prrr(2).Value = sf(0)


                If oh.ExecuteNonQuery(sq178, prrr) Then


                    Dim cl_scrip1 As New StringBuilder
                    cl_scrip1.Append("   alert('Rejected Successfully') ;")
                    cl_scrip1.Append("window.open('Movement_Recommend_Macom.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
                    'Me.btn_reject.Enabled = False
                End If

                Me.EMP_CODE.Value = ""
                Me.Txt_emp.Value = ""
                Me.Txt_fdt.Text = ""
                Me.Txt_From.Text = ""
                'Me.Txt_To.Text = ""
                Me.Txt_dep.Value = ""
                Me.Textplace.Value = ""
                Me.Txt_purp.Text = ""
                Me.Text_RJTRSN.Text = ""



            Catch ex As Exception

                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("                        alert('Error. please check the values entered.');")
                'cl_script1.Append("window.open('Movement_Recommend_Macom.aspx','_self');")

                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

            End Try

        End If
    End Sub

    Protected Sub Cmd_Exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Response.Redirect("~/home.aspx")
    End Sub

    Protected Sub Txt_fdt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_fdt.TextChanged

    End Sub
End Class

