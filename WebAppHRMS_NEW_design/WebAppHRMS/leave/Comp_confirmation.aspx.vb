Imports System.Data
Imports System.Data.OracleClient
Partial Class LEAVE_DETAILS_Comp_confirmation_e1f782796584
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim st As String = Me.Session("user_id")
        Dim st1(), st2, st3 As String
        st1 = st.Split("!")
        st2 = st1(0)
        st3 = st1(1)
        Me.Label5.Text = "<marquee><font color=red>This Module For Compensatory confirmation.Need to Select Employee and Sanction Or Reject it.</font></marquee>"
        If Me.Session("branch_id") = 0 Then
            sql = "select dep_id from department_mst  where dep_head=" & st2 & ""
            dt1 = oh.ExecuteDataSet(sql).Tables(0)
            If dt1.Rows.Count > 0 Then
                If Not IsPostBack Then
                    sql = "select count(*) from employee_master a,EMPLOY_compENSAT_MASTER b where a.department_id=" & dt1.Rows(0)(0) & "  and a.emp_code=b.emp_code AND B.APPLY_DT IS NOT NULL AND B.LEAVE_DT IS NOT NULL and b.status_id=1 and b.compensat_flag='F' order by b.APPLY_DT"
                    dt = oh.ExecuteDataSet(sql).Tables(0)
                    If (dt.Rows(0)(0) = 0) Then
                        Me.cmb_ecode.Items.Add("NO COMPENSATION WAITING TO CONFIRM")
                        sql = "select emp_code||' -- '||emp_name,emp_code from employee_master where  emp_code=" & st2 & ""
                        dt = oh.ExecuteDataSet(sql).Tables(0)
                        Me.cmb_san_person.DataSource = dt
                        Me.cmb_san_person.DataTextField = dt.Columns(0).ColumnName
                        Me.cmb_san_person.DataValueField = dt.Columns(1).ColumnName
                        Me.cmb_san_person.DataBind()
                        Me.txt_rec.Text = Me.cmb_san_person.SelectedItem.Text
                    Else
                        FILL()
                    End If
                End If
            Else
                Me.Server.Transfer("../show_err.aspx")
            End If
        Else
            sql = "select access_id from employee_master where emp_code=" & st2 & ""
            Dim dt56 As New DataTable
            dt56 = oh.ExecuteDataSet(sql).Tables(0)
            If dt56.Rows(0)(0) = 51 Then
                If Not IsPostBack Then
                    brFILL()

                End If
            Else
                Me.Server.Transfer("../show_err.aspx")
            End If

        End If

    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Try

            If (Me.txt_name.Text = "") Then
                Me.Label5.Text = "<font color=red size=3><b>NO COMPENSATION WAITING TO CONFIRM</b></font>"
            Else
                Dim comp(3) As OracleParameter
                comp(0) = New OracleParameter("status", OracleType.Int32)
                comp(0).Direction = ParameterDirection.Input
                comp(0).Value = 2
                comp(1) = New OracleParameter("san_person", OracleType.Int32)
                comp(1).Direction = ParameterDirection.Input
                comp(1).Value = Me.cmb_san_person.SelectedValue

                Dim st As String = Me.cmb_ecode.SelectedValue
                Dim st1(), st2, st3 As String
                st1 = st.Split("*")
                st2 = st1(0)
                st3 = st1(1)


                comp(2) = New OracleParameter("comp_num", OracleType.Int32)
                comp(2).Direction = ParameterDirection.Input
                comp(2).Value = st2
                comp(3) = New OracleParameter("comp_date", OracleType.DateTime)
                comp(3).Direction = ParameterDirection.Input
                comp(3).Value = Me.txt_offdate.Text

                oh.ExecuteNonQuery("comp_confirmation", comp)
                clear()
                Me.Label5.Text = "<font size=3 color=red><b>COMPENSATION CONFIRMED</b></font>"
                If Me.Session("branch_id") = 0 Then
                    FILL()
                Else
                    brFILL()
                End If

            End If
        Catch ex As Exception
            Me.Label5.Text = ex.Message
        End Try

    End Sub

    Protected Sub cmd_reject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_reject.Click

        Try

            If (Me.txt_name.Text = "") Then
                Me.Label5.Text = "<font color=red size=3><b>NO COMPENSATION WAITING TO CONFIRM</b></font>"
            Else
                Dim comp(3) As OracleParameter
                comp(0) = New OracleParameter("status", OracleType.Int32)
                comp(0).Direction = ParameterDirection.Input
                comp(0).Value = 3
                comp(1) = New OracleParameter("san_person", OracleType.Number)
                comp(1).Direction = ParameterDirection.Input
                comp(1).Value = Me.cmb_san_person.SelectedValue
                Dim st As String = Me.cmb_ecode.SelectedValue
                Dim st1(), st2, st3 As String
                st1 = st.Split("*")
                st2 = st1(0)
                st3 = st1(1)
                comp(2) = New OracleParameter("comp_num", OracleType.VarChar)
                comp(2).Direction = ParameterDirection.Input
                comp(2).Value = st2
                comp(3) = New OracleParameter("comp_date", OracleType.DateTime)
                comp(3).Direction = ParameterDirection.Input
                comp(3).Value = Me.txt_offdate.Text
                oh.ExecuteNonQuery("comp_confirmation", comp)
                clear()
                Me.Label5.Text = "<font size=3 color=red><b>COMPENSATION REJECTED</b></font>"
            End If
            If Me.Session("branch_id") = 0 Then
                FILL()
            Else
                brFILL()
            End If

        Catch ex As Exception
            Me.Label5.Text = ex.Message
        End Try
    End Sub
    Sub clear()
        Me.txt_name.Text = ""
        Me.txt_offdate.Text = ""
        Me.txt_leavdate.Text = ""
        Me.txt_designation.Text = ""
        Me.txt_recomended.Text = ""
    End Sub
    Sub FILL()
        Dim usr As String = Me.Session("user_id")
        Dim usr1() As String = usr.Split("!")
        Dim user As String = usr1(0)
        sql = "select dep_id from department_mst where dep_head=" & user & ""
        Dim dt32 As New DataTable
        dt32 = oh.ExecuteDataSet(sql).Tables(0)
        sql = "select 'EmpCode:'|| a.emp_code||' | '|| 'Emp name:'|| a.emp_name||' | '|| 'Comp:'|| C.COMP_NAME||' | '|| 'CompDate:'||  b.compensat_date,b.EMP_CODE||'*'||b.compensat_date  from employee_master a,EMPLOY_compENSAT_MASTER b,COMP_MASTER C where C.COMP_ID=B.COMP_ID AND a.department_id=" & dt32.Rows(0)(0) & "  and a.emp_code=b.emp_code and b.status_id=1  AND B.APPLY_DT IS NOT NULL AND B.LEAVE_DT IS NOT NULL AND C.EXPIRY_DT>sysdate and B.LEAVE_DT>sysdate order by b.APPLY_DT"
        ' sql = "select 'EmpCode:'|| a.emp_code||' | '|| 'CompDate:'|| b.compensat_date||' | '|| 'Emp name:'|| a.emp_name||' | '|| 'Comp:'|| C.COMP_NAME,b.EMP_CODE||'*'||b.compensat_date  from employee_master a,EMPLOY_compENSAT_MASTER b,COMP_MASTER C where C.COMP_ID=B.COMP_ID AND a.department_id=" & dt32.Rows(0)(0) & "  and a.emp_code=b.emp_code and b.status_id=1 and b.compensat_flag='F' AND B.APPLY_DT IS NOT NULL AND B.LEAVE_DT IS NOT NULL AND C.EXPIRY_DT>sysdate order by b.APPLY_DT"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Me.cmb_ecode.DataSource = dt
        Me.cmb_ecode.DataTextField = dt.Columns(0).ColumnName
        Me.cmb_ecode.DataValueField = dt.Columns(1).ColumnName
        Me.cmb_ecode.DataBind()
        'If dt.Rows.Count = 1 Then
        '    Me.txt_name.Text = dt.Rows(0)(0)
        '    Me.txt_offdate.Text = dt.Rows(0)(1)
        '    Me.txt_leavdate.Text = dt.Rows(0)(2)
        '    Me.txt_designation.Text = dt.Rows(0)(3)
        '    Me.txt_recomended.Text = dt.Rows(0)(4)
        'End If
       
        sql = "select a.emp_name,to_char(b.comp_date),to_char(b.from_date)||'  - TO -  '||to_char(b.to_date),c.designation,d.emp_name from employee_master a,EMPLOY_compensat_master b,designation_master c,employee_master d where a.emp_code=b.emp_code and a.designation_id=c.designation_id and d.emp_code=b.rec_person  and b.comp_ID=" & Me.cmb_ecode.SelectedValue
        If dt.Rows.Count > 0 Then
            Dim st As String = Me.cmb_ecode.SelectedValue
            Dim st1(), st2, st3 As String
            st1 = st.Split("*")
            st2 = st1(0)
            st3 = st1(1)
            sql = "SELECT E.EMP_NAME,C.COMPENSAT_DATE,C.LEAVE_DT,D.DESIGNATION,E.EMP_NAME FROM EMPLOYEE_MASTER E,EMPLOY_COMPENSAT_MASTER C,designation_master D WHERE E.EMP_CODE=C.EMP_CODE AND E.DESIGNATION_ID=D.DESIGNATION_ID AND C.STATUS_ID=1 AND C.EMP_CODE=" & st1(0) & "  and C.COMPENSAT_DATE='" & st1(1) & "'"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows.Count = 1 Then
                Me.txt_name.Text = dt.Rows(0)(0)
                Me.txt_offdate.Text = dt.Rows(0)(1)
                Me.txt_leavdate.Text = dt.Rows(0)(2)
                Me.txt_designation.Text = dt.Rows(0)(3)
                Me.txt_recomended.Text = dt.Rows(0)(4)
            Else

                Me.txt_name.Text = dt.Rows(0)(0)
                Me.txt_offdate.Text = dt.Rows(0)(1)
                Me.txt_leavdate.Text = dt.Rows(0)(2)
                Me.txt_designation.Text = dt.Rows(0)(3)
                Me.txt_recomended.Text = dt.Rows(0)(4)
            End If

        Else
            Exit Sub
        End If
        sql = "select emp_code||' -- '||emp_name,emp_code from employee_master where  emp_code>9999 and emp_code=" & user & " and emp_code in(select dep_head from department_mst) order by emp_code"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Me.cmb_san_person.DataSource = dt
        Me.cmb_san_person.DataTextField = dt.Columns(0).ColumnName
        Me.cmb_san_person.DataValueField = dt.Columns(1).ColumnName
        Me.cmb_san_person.DataBind()
        Me.txt_rec.Text = Me.cmb_san_person.SelectedItem.Text
    End Sub


    Protected Sub cmb_ecode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_ecode.SelectedIndexChanged
        Dim st As String = Me.cmb_ecode.SelectedValue
        Dim st1(), st2, st3 As String
        st1 = st.Split("*")
        st2 = st1(0)
        st3 = st1(1)
        sql = "SELECT E.EMP_NAME,C.COMPENSAT_DATE,C.LEAVE_DT,D.DESIGNATION,E.EMP_NAME FROM EMPLOYEE_MASTER E,EMPLOY_COMPENSAT_MASTER C,designation_master D WHERE E.EMP_CODE=C.EMP_CODE AND E.DESIGNATION_ID=D.DESIGNATION_ID AND C.EMP_CODE=" & st1(0) & " and c.compensat_date='" & st1(1) & "'"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Me.txt_name.Text = dt.Rows(0)(0)
        Me.txt_offdate.Text = dt.Rows(0)(1)
        Me.txt_leavdate.Text = dt.Rows(0)(2)
        Me.txt_designation.Text = dt.Rows(0)(3)
        Me.txt_recomended.Text = dt.Rows(0)(4)

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("../home.aspx")
    End Sub

    Sub brFILL()
        Dim usr As String = Me.Session("user_id")
        Dim usr1() As String = usr.Split("!")
        Dim user As String = usr1(0)

        sql = "select a.emp_code||'   |     '||b.compensat_date||'    |     '||a.emp_name,b.EMP_CODE||'*'||b.compensat_date  from employee_master a,EMPLOY_compENSAT_MASTER b,COMP_MASTER C where C.COMP_ID=B.COMP_ID AND a.branch_id=" & Me.Session("branch_id") & "  and a.emp_code=b.emp_code and b.status_id=1  AND B.APPLY_DT IS NOT NULL AND B.LEAVE_DT IS NOT NULL AND C.EXPIRY_DT>sysdate and B.LEAVE_DT>sysdate order by b.APPLY_DT"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Me.cmb_ecode.DataSource = dt
        Me.cmb_ecode.DataTextField = dt.Columns(0).ColumnName
        Me.cmb_ecode.DataValueField = dt.Columns(1).ColumnName
        Me.cmb_ecode.DataBind()
        'sql = "select a.emp_name,to_char(b.comp_date),to_char(b.from_date)||'  - TO -  '||to_char(b.to_date),c.designation,d.emp_name from employee_master a,EMPLOY_compensat_master b,designation_master c,employee_master d where a.emp_code=b.emp_code and a.designation_id=c.designation_id and d.emp_code=b.rec_person  and b.comp_ID=" & Me.cmb_ecode.SelectedValue
        If dt.Rows.Count > 0 Then
            Dim st As String = Me.cmb_ecode.SelectedValue
            Dim st1(), st2, st3 As String
            st1 = st.Split("*")
            st2 = st1(0)
            st3 = st1(1)
            sql = "SELECT E.EMP_NAME,C.COMPENSAT_DATE,C.LEAVE_DT,D.DESIGNATION,E.EMP_NAME FROM EMPLOYEE_MASTER E,EMPLOY_COMPENSAT_MASTER C,designation_master D WHERE E.EMP_CODE=C.EMP_CODE AND E.DESIGNATION_ID=D.DESIGNATION_ID AND C.STATUS_ID=1 AND C.EMP_CODE=" & st1(0) & "  and C.COMPENSAT_DATE='" & st1(1) & "'"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows.Count = 1 Then
                Me.txt_name.Text = dt.Rows(0)(0)
                Me.txt_offdate.Text = dt.Rows(0)(1)
                Me.txt_leavdate.Text = dt.Rows(0)(2)
                Me.txt_designation.Text = dt.Rows(0)(3)
                Me.txt_recomended.Text = dt.Rows(0)(4)
            Else

                Me.txt_name.Text = dt.Rows(0)(0)
                Me.txt_offdate.Text = dt.Rows(0)(1)
                Me.txt_leavdate.Text = dt.Rows(0)(2)
                Me.txt_designation.Text = dt.Rows(0)(3)
                Me.txt_recomended.Text = dt.Rows(0)(4)
            End If
            sql = "select emp_code||' -- '||emp_name,emp_code from employee_master where  emp_code=" & user & ""
            dt = oh.ExecuteDataSet(sql).Tables(0)
            Me.cmb_san_person.DataSource = dt
            Me.cmb_san_person.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_san_person.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_san_person.DataBind()
            Me.txt_rec.Text = Me.cmb_san_person.SelectedItem.Text
        Else
            Me.cmb_ecode.Items.Add("NO COMPENSATION WAITING TO CONFIRM")
            Exit Sub
        End If

    End Sub
End Class
