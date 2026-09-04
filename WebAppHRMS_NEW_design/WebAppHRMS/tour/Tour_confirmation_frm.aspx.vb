Imports System.Data
Imports System.Data.OracleClient
Partial Class TOUR_Tour_confirmation_frm_15d3fa521629
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql, sql1 As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Authorised employee can access this page
            'MsgBox(Session("user_id"))
            Dim sf() As String
            sf = Session("user_id").ToString.Split("!")
            dt2 = oh.ExecuteDataSet("select ACCESS_ID from employee_master where emp_code= " & sf(0) & " ").Tables(0)
            If dt2.Rows(0)(0) <> 25 Then
                Server.Transfer("../show_err.aspx")
            End If
            fill_combo()        'combobos filling function
            fill_select()       'textbox filling function
        End If

        Me.Timer1.Enabled = False
        Me.lbl_message.Text = ""


        'sf = Session("user_id").ToString.Split("!")  if u will use then value store in hidden field
        '**********IMPORTANT NOTES************************************************************
        'IN TOUR_MASTER TABLE TOUR_STATUS FIELD REPRESENTS
        ' 0  -  TOUR APPLICATION 
        ' 1  -  TOUR COFIRMATION RECOMMENDED
        ' 2  -  TOUR CACELLATION CONFIRMED
        ' 3  -  TOUR CACELLATION CANCELLED
        '*************************************************************************************
        'EXIT BTN FUNCTION CALL VB SIDE AND SCRIPT SIDE


        Me.cmd_Exit.Attributes.Add("onclick", "exit()")

    End Sub
    Sub fill_select()
        Dim arr As Array
        Me.hidd_ecode.Value = ""
        dt = oh.ExecuteDataSet("select b.emp_name||'('||a.emp_code||')' ,a.emp_code||'*'||b.emp_name||'*'||(a.to_date-a.from_date)||'*'||a.apply_date||'*'||a.tour_place||'*'||a.tour_purpose||'*'||a.recomment_by||'*'||c.designation from tour_master a,employee_master b,designation_master c where a.emp_code=b.emp_code and a.remarks like 'Appro%' and a.RECOMMENT_BY is not null and a.tour_status=1 and a.sanction_date is null and a.sanction_person is null and  b.designation_id=c.designation_id order by b.emp_name").Tables(0)
        If dt.Rows.Count > 0 Then
            Me.lbl_message.Visible = False
            Me.lbl_message.Text = ""

            arr = Me.cmb_ecode.SelectedValue.Split("*")
            'IF COMBOBOX VALUE WILL B NULL SYSTEM WILL SHOWS INDEX WAS OUT OF RANGE <AVOIDING THT WE R USING "LENGTH"
            If arr.Length > 1 Then
                Me.txt_designation.Text = arr(7)
                Me.txt_name.Text = arr(1)
                Me.txt_duration.Text = arr(2)
                Me.txt_applydate.Text = arr(3)
                Me.txt_recomended.Text = arr(6)
                Me.txt_place.Text = arr(4)
                Me.txt_purpose.Text = arr(5)
                Me.hidd_ecode.Value = arr(0)
                Me.lbl_message.Visible = False
            End If
        End If
        
    End Sub


    Protected Sub cmb_ecode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_ecode.SelectedIndexChanged

        fill_select()
        Me.lbl_message.Visible = False
    End Sub

   
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        Dim arr = Me.cmb_ecode.SelectedValue.Split("*")

        Dim prm(3) As OracleParameter

        prm(0) = New OracleParameter("ecode", OracleType.Int32, 15)
        prm(0).Direction = ParameterDirection.Input
        prm(0).Value = CInt(arr(0))

       
        prm(1) = New OracleParameter("access_ecode", OracleType.Int32, 15)
        prm(1).Direction = ParameterDirection.Input
        prm(1).Value = sf(0)

        prm(2) = New OracleParameter("apply_dt", OracleType.DateTime)
        prm(2).Direction = ParameterDirection.Input
        prm(2).Value = CDate(Me.txt_applydate.Text)

        prm(3) = New OracleParameter("tour_pl", OracleType.VarChar, 50)
        prm(3).Direction = ParameterDirection.Input
        prm(3).Value = Me.txt_place.Text

        oh.ExecuteNonQuery("tour_confirmation", prm)

        clear()
        fill_combo()
        fill_select()
        Me.Timer1.Enabled = True
        Me.lbl_message.Visible = True
        Me.lbl_message.Text = "TOUR CONFIRMED SUCCESSFULLY!!!!"

    End Sub

    Protected Sub cmd_Exit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
       
        Server.Transfer("../home.aspx")
    End Sub
    Sub clear()
        Me.txt_designation.Text = ""
        Me.txt_name.Text = ""
        Me.txt_duration.Text = ""
        Me.txt_applydate.Text = ""
        Me.txt_recomended.Text = ""
        Me.txt_place.Text = ""
        Me.txt_purpose.Text = ""
    End Sub
    Sub fill_combo()
        dt = oh.ExecuteDataSet("select b.emp_name||'('||a.emp_code||')' ,a.emp_code||'*'||b.emp_name||'*'||(a.to_date-a.from_date)||'*'||a.apply_date||'*'||a.tour_place||'*'||a.tour_purpose||'*'||a.recomment_by||'*'||c.designation from tour_master a,employee_master b,designation_master c where a.emp_code=b.emp_code and a.remarks like 'Appro%' and a.RECOMMENT_BY is not null and a.tour_status=1 and a.sanction_date is null and a.sanction_person is null and  b.designation_id=c.designation_id order by b.emp_name").Tables(0)
        If dt.Rows.Count = 0 Then
            clear()
        End If
        Me.cmb_ecode.DataSource = dt
        Me.cmb_ecode.DataTextField = dt.Columns(0).ColumnName
        Me.cmb_ecode.DataValueField = dt.Columns(1).ColumnName
        Me.cmb_ecode.DataBind()
        Me.lbl_message.Visible = False

    End Sub

    Protected Sub Cmd_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        Dim arr = Me.cmb_ecode.SelectedValue.Split("*")

        Dim prm(3) As OracleParameter

        prm(0) = New OracleParameter("ecode", OracleType.Int32, 15)
        prm(0).Direction = ParameterDirection.Input
        prm(0).Value = CInt(arr(0))


        prm(1) = New OracleParameter("access_ecode", OracleType.Int32, 15)
        prm(1).Direction = ParameterDirection.Input
        prm(1).Value = sf(0)

        prm(2) = New OracleParameter("apply_dt", OracleType.DateTime)
        prm(2).Direction = ParameterDirection.Input
        prm(2).Value = CDate(Me.txt_applydate.Text)

        prm(3) = New OracleParameter("tour_pl", OracleType.VarChar, 50)
        prm(3).Direction = ParameterDirection.Input
        prm(3).Value = Me.txt_place.Text
        oh.ExecuteNonQuery("tour_cacellation", prm)

        clear()
        fill_combo()
        fill_select()
        Me.Timer1.Enabled = True
        Me.lbl_message.Visible = True
        Me.lbl_message.Text = "TOUR CACELLED SUCCESSFULLY!!!!"

    End Sub

    
End Class
