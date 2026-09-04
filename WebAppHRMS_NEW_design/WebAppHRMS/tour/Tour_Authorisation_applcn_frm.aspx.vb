Imports System.Data
Imports System.Data.OracleClient
Partial Class TOUR_Tour_Authorisation_applcn_frm_005b7ec02816
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Dim fr_time, to_time As String
    
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txt_name.BackColor = Drawing.Color.BlanchedAlmond
        Me.Timer1.Enabled = False
        Me.Lbl_MESSAGE.Text = ""
        If Not IsPostBack Then
            dt = oh.ExecuteDataSet("select a.emp_name||'('||a.emp_code||')' ,a.emp_code||'*'||a.emp_name||'*'||a.status_id||'*'||b.branch_name||'*'||a.designation_id||'*'||c.designation||'*'||e.POST_NAME||'*'||d.dep_name from employee_master a,branch_master b,designation_master c,department_mst d,post_mst e where a.branch_id=b.branch_id and a.status_id=1 and a.designation_id=c.designation_id and a.department_id=d.dep_id and a.post_id=e.POST_ID order by a.emp_name").Tables(0)
            If dt.Rows.Count > 0 Then
                Me.cmb_employee.DataSource = dt
                Me.cmb_employee.DataTextField = dt.Columns(0).ColumnName
                Me.cmb_employee.DataValueField = dt.Columns(1).ColumnName
                Me.cmb_employee.DataBind()
            End If
            
            fill_select()

            Me.rd_am1.Checked = True
            Me.rd_am2.Checked = True
            Me.Lbl_MESSAGE.Visible = False
            Me.txt_advance.Text = 0
        End If

        
        Me.Cmd_exit.Attributes.Add("onclick", "exit()")
    End Sub

    Protected Sub txt_tortdt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_tortdt.TextChanged
        If (Me.txt_tfrmdt.Text = "") Then
            Me.Lbl_MESSAGE.Visible = True
            Me.Lbl_MESSAGE.Text = "First Enter From Date"
            Me.txt_tortdt.Text = ""
        Else
            Dim dat, dat1 As Date
            Dim a As Integer
            dat = CDate(Me.txt_tfrmdt.Text)
            dat1 = CDate(Me.txt_tortdt.Text)
            a = DateDiff(DateInterval.DayOfYear, dat, dat1)
            If (a < 0) Then
                Me.Lbl_MESSAGE.Visible = True
                Me.Lbl_MESSAGE.Text = "From Date Must be Less Than To Date"
                Me.txt_tfrmdt.Text = ""
            End If
        End If
    End Sub

    Protected Sub Cmd_Clear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        clear()
        Me.Timer1.Enabled = True
        Me.Lbl_MESSAGE.Visible = True
        Me.Lbl_MESSAGE.Text = "TOUR AUTHORISATION UPDATED SUCCESSFULLY!!!!"
    End Sub
    
    Sub clear()
        Me.txt_ecode.Text = ""
        Me.txt_desig.Text = ""
        Me.txt_name.Text = ""
        Me.txt_branch.Text = ""
        Me.txt_tfrmdt.Text = ""
        Me.txt_tortdt.Text = ""
        Me.txt_hh1.Text = ""
        Me.txt_mm1.Text = ""
        Me.txt_ss1.Text = ""
        Me.txt_hh2.Text = ""
        Me.txt_mm2.Text = ""
        Me.txt_ss2.Text = ""
        Me.txt_advance.Text = 0
        Me.txt_tourplace.Text = ""
        Me.txt_tourpurpose.Text = ""
        Me.txt_department.Text = ""
        Me.txt_post.Text = ""

        'MsgBox("fsdfsdfsdfsfsdf")
    End Sub

    Protected Sub Cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_confirm.Click
        If (Me.txt_tfrmdt.Text = "" Or Me.txt_tortdt.Text = "" Or Me.txt_tourplace.Text = "" Or Me.txt_tourpurpose.Text = "") Then
            Me.Lbl_MESSAGE.Visible = True
            Me.Lbl_MESSAGE.Text = "Please fill All Entries"
        Else

            If (Me.rd_am1.Checked = True) Then
                Me.rd_pm1.Checked = False
                fr_time = Me.txt_hh1.Text + ":" + Me.txt_mm1.Text + ":" + Me.txt_ss1.Text + " " + "AM"
            ElseIf (Me.rd_pm1.Checked = True) Then
                Me.rd_am1.Checked = False
                fr_time = Me.txt_hh1.Text + ":" + Me.txt_mm1.Text + ":" + Me.txt_ss1.Text + " " + "PM"
            End If
            If (Me.rd_am2.Checked = True) Then
                Me.rd_pm2.Checked = False
                to_time = Me.txt_hh2.Text + ":" + Me.txt_mm2.Text + ":" + Me.txt_ss2.Text + " " + "AM"
            ElseIf (Me.rd_pm2.Checked = True) Then
                Me.rd_am2.Checked = False
                to_time = Me.txt_hh2.Text + ":" + Me.txt_mm2.Text + ":" + Me.txt_ss2.Text + " " + "PM"
            End If

            insert()
        End If
    End Sub
    Sub insert()
        Dim arr1 As Array
        arr1 = Me.hidd_statusid.Value.Split("*")
        
        Dim prm(9) As OracleParameter

        prm(0) = New OracleParameter("ecode", OracleType.Int32)
        prm(0).Direction = ParameterDirection.Input
        prm(0).Value = Me.txt_ecode.Text

        prm(1) = New OracleParameter("frm_date", OracleType.DateTime)
        prm(1).Direction = ParameterDirection.Input
        prm(1).Value = Me.txt_tfrmdt.Text

        prm(2) = New OracleParameter("to_date", OracleType.DateTime)
        prm(2).Direction = ParameterDirection.Input
        prm(2).Value = Me.txt_tortdt.Text

        prm(3) = New OracleParameter("advance", OracleType.Int32, 15)
        prm(3).Direction = ParameterDirection.Input
        prm(3).Value = Me.txt_advance.Text

        prm(4) = New OracleParameter("place", OracleType.VarChar, 50)
        prm(4).Direction = ParameterDirection.Input
        prm(4).Value = Me.txt_tourplace.Text

        prm(5) = New OracleParameter("purpose", OracleType.VarChar, 35)
        prm(5).Direction = ParameterDirection.Input
        prm(5).Value = Me.txt_tourpurpose.Text

        prm(6) = New OracleParameter("frm_time", OracleType.VarChar, 25)
        prm(6).Direction = ParameterDirection.Input
        prm(6).Value = fr_time

        prm(7) = New OracleParameter("to_time", OracleType.VarChar, 25)
        prm(7).Direction = ParameterDirection.Input
        prm(7).Value = to_time

        prm(8) = New OracleParameter("status_id", OracleType.Int32, 55)
        prm(8).Direction = ParameterDirection.Input
        prm(8).Value = arr1(0)

        prm(9) = New OracleParameter("desig_id", OracleType.Int32, 25)
        prm(9).Direction = ParameterDirection.Input
        prm(9).Value = arr1(1)


        Dim erst As Integer = 0

        erst = oh.ExecuteNonQuery("tour_authorisation", prm)

        clear()

        If erst = 1 Then
            Me.Timer1.Enabled = True
            Me.Lbl_MESSAGE.Visible = True
            Me.Lbl_MESSAGE.Text = "TOUR APPLIED SUCCESSFULLY!!!!"

        Else
            Me.Timer1.Enabled = True
            Me.Lbl_MESSAGE.Visible = True
            Me.Lbl_MESSAGE.Text = "TOUR APPLIED NOT CONFIRMED!!!!"
        End If
       
    End Sub

    Protected Sub txt_ecode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ecode.TextChanged
        'sql = "select count(*) from employee_master a,designation_master b,branch_master c where a.branch_id=c.branch_id and a.designation_id=b.designation_id and a.emp_code=" & Me.txt_ecode.Text
        'dt = oh.ExecuteDataSet(sql).Tables(0)
        'If (dt.Rows(0)(0) < 1) Then
        '    Me.txt_name.Text = ""
        '    Me.txt_desig.Text = ""
        '    Me.txt_branch.Text = ""
        'Else
        '    sql = "select a.emp_name,b.designation,c.branch_name from employee_master a,designation_master b,branch_master c where a.branch_id=c.branch_id and a.designation_id=b.designation_id and a.emp_code=" & Me.txt_ecode.Text
        '    dt = oh.ExecuteDataSet(sql).Tables(0)
        '    If dt.Rows.Count > 0 Then
        '    Me.txt_name.Text = dt.Rows(0)(0)
        '    Me.txt_desig.Text = dt.Rows(0)(1)
        '    Me.txt_branch.Text = dt.Rows(0)(2)
        '    End If

        'End If

    End Sub

    Sub fill_select()
        'FROM THE DROP DOWN LIST QUERY SPLIT VALUES AND STORE IT AN ARRAY

        '        0                  1             2                   3                   4                         5                  6                    7
        ' a.emp_code||'*'||a.emp_name||'*'||a.status_id||'*'||c.branch_name||'*'||d.designation_id||'*'||e.designation||'*'||f.postoffer_name||'*'||g.dep_name from employ_master_dtl a,employ_transfer_dtl b,branch_master c,employ_promotion_dtl d,designation_master e,postoffer_master f,department_mst g where a.emp_code=b.emp_code and a.status_id=1 and b.tfr_todate is null and b.branch_id=c.
        Dim arr As Array
        Me.hidd_statusid.Value = ""

        arr = Me.cmb_employee.SelectedValue.Split("*")
        Me.txt_ecode.Text = arr(0)
        Me.txt_name.Text = arr(1)
        Me.txt_desig.Text = arr(5)
        Me.txt_branch.Text = arr(3)
        Me.txt_post.Text = arr(6)
        Me.txt_department.Text = arr(7)
        Me.hidd_statusid.Value = arr(2) & "*" & arr(4)

    End Sub

    Protected Sub cmb_employee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_employee.SelectedIndexChanged
        fill_select()
        Me.Lbl_MESSAGE.Visible = False
    End Sub

    Protected Sub Cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_exit.Click
        Server.Transfer("../home.aspx")
    End Sub

    Protected Sub cmd_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_cancel.Click
        Dim arr1 As Array
        arr1 = Me.hidd_statusid.Value.Split("*")

        Dim prm(0) As OracleParameter

        prm(0) = New OracleParameter("ecode", OracleType.Int32)
        prm(0).Direction = ParameterDirection.Input
        prm(0).Value = Me.txt_ecode.Text

        Dim erst As Integer = 0

        erst = oh.ExecuteNonQuery("tour_authorisation_delete", prm)

        clear()
        If erst = 1 Then
            Me.Timer1.Enabled = True
            Me.Lbl_MESSAGE.Visible = True
            Me.Lbl_MESSAGE.Text = "TOUR APPLICATION DELETED SUCCESSFULLY!!!!"
        End If
    End Sub

    
    
End Class
