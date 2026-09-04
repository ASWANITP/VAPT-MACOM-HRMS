Imports System.Data
Imports System.Data.OracleClient

Partial Class Edit_present_permanent_addresss_of_emp_editqualification_df52cee62718
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Public tab As New Table
    Dim i As Integer = 0
    Dim script1 As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            clearall()
            qualificationfill()
            cmbcode()
            '  Dim jd As DataTable = oh.ExecuteDataSet("select e.join_dt,upper(d.designation),e.basic_pay from employee_master e,designation_master d where e.designation_id=d.designation_id and e.emp_code=" & Request.QueryString("empcode")).Tables(0)
            Dim jd As DataTable = oh.ExecuteDataSet("select distinct e.join_dt,upper(d.designation),upper(br.branch_name),upper(branch_abbr),upper(f.firm_abbr),e.basic_pay from employee_master e,designation_master d,branch_master br,firm_master f where e.designation_id=d.designation_id and f.firm_id=e.firm_id  and br.branch_id=e.branch_id and e.emp_code=" & Request.QueryString("empcode") & " union select distinct e.join_dt,upper(d.designation),upper(bc.branch_name),'Not Inagurated',upper(f.firm_abbr),e.basic_pay from employee_master e,designation_master d,before_completion bc,firm_master f where e.designation_id=d.designation_id and f.firm_id=e.firm_id and bc.old_id=e.branch_id and e.emp_code=" & Request.QueryString("empcode")).Tables(0)
            If jd.Rows.Count > 0 Then
                Me.lb_join.Text = Format(jd.Rows(0)(0), "dd/MMM/yyyy")
                Me.lb_desig.Text = jd.Rows(0)(1)
                Me.lb_branch.Text = jd.Rows(0)(2)
                Me.lb_firm.Text = jd.Rows(0)(4)
                Me.lb_sal.Text = FormatNumber(jd.Rows(0)(5), 2)
                If Not IsDBNull(jd.Rows(0)(3)) Then
                    Me.lb_abbr.Text = jd.Rows(0)(3)
                Else
                    Me.lb_abbr.Text = ""
                End If

            End If

        End If

    End Sub

    Sub qualificationfill()
        Dim dtq As DataTable = oh.ExecuteDataSet("select qualification_id,qualification from qualification_master order by qualification").Tables(0)
        Me.cmb_addq.DataSource = dtq
        Me.cmb_addq.DataTextField = dtq.Columns(1).ColumnName
        Me.cmb_addq.DataValueField = dtq.Columns(0).ColumnName
        Me.cmb_addq.DataBind()
    End Sub
   
    Private Sub clearall()
        Me.txt_org.Text = ""
        Me.txt_designation.Text = ""
        Me.txt_periodfrom.Text = Format(Now.Date, "dd/MMM/yyyy")
        Me.txt_periodto.Text = Format(Now.Date, "dd/MMM/yyyy")
        Me.txt_nature.Text = ""
        Me.txt_reason.Text = ""
        Me.txt_contact.Text = ""
        Me.txt_contactno.Text = ""
        Me.txt_salary.Text = ""
    End Sub

    Public Sub cmbcode()
        Dim dt As DataTable = oh.ExecuteDataSet("select eq.qualification,q.qualification,eq.institution,eq.university,eq.percentage,eq.year_pass,case when(em.qualification_id=eq.qualification) then 1 else 0 end from employ_qualification_dtl eq,qualification_master q,employee_master_dtl em where eq.qualification=q.qualification_id and eq.emp_code=em.emp_code and eq.emp_code=" & Request.QueryString("empcode") & " order by eq.year_pass").Tables(0)

        If dt.Rows.Count = 0 Then

            Dim cl_script01 As New System.Text.StringBuilder
            cl_script01.Append("         alert(' No Qualification Details Found');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script01.ToString, True)
            Me.txt_addinstitute.Text = ""
            Me.txt_adduniversity.Text = ""
            Me.txt_addpercentage.Text = ""
            Me.txt_addyear.Text = ""

        End If

        qualificationdetails()
        expdetails()
        

    End Sub

    Sub expdetails()
        Dim dt1 As DataTable = oh.ExecuteDataSet("select upper(ex.organisation),upper(ex.designation),ex.exp_frdate,ex.exp_todate,upper(ex.nature_duty),upper(ex.present_salary),upper(ex.cont_person),ex.cont_phone,upper(ex.releaving_reason) from employ_experience_dtl ex where emp_code=" & Request.QueryString("empcode")).Tables(0)
        Me.ListBox2.Items.Clear()
        If dt1.Rows.Count = 0 Then
            clearall()
            Exit Sub
        End If
        Dim de As DataRow
        For Each de In dt1.Rows
            Dim ex As String
            ex = de(0) & " - " & de(1) & " - " & de(2) & " - " & de(3) & " - " & de(4) & " - " & de(5) & " - " & de(6) & " - " & de(7) & " - " & de(8)
            Me.ListBox2.Items.Add(ex)
        Next
    End Sub

    Sub qualificationdetails()
        Me.ListBox1.Items.Clear()
        Dim dq As DataTable
        dq = oh.ExecuteDataSet("select eq.qualification,q.qualification,eq.institution,eq.university,eq.percentage,eq.year_pass,case when(em.qualification_id=eq.qualification) then 1 else 0 end from employ_qualification_dtl eq,qualification_master q,employee_master_dtl em where eq.qualification=q.qualification_id and eq.emp_code=em.emp_code and eq.emp_code=" & Request.QueryString("empcode") & " order by eq.year_pass").Tables(0)

        Dim dr As DataRow
        For Each dr In dq.Rows
            Dim high As String
            If dr(6) = 1 Then
                high = "HIGH"
                Me.hid3.Value = dr(0)
            Else
                high = "LOW"
            End If
            Dim str As String
            str = dr(0) & " - " & dr(1) & " - " & dr(2) & " - " & dr(3) & " - " & dr(4) & "% - " & dr(5) & " - " & high
            Me.ListBox1.Items.Add(str)
        Next
    End Sub

    Private Sub procedure(ByVal num As Integer)
        Dim param(12) As OracleParameter
        param(0) = New OracleParameter("empcode", OracleType.Number)
        param(0).Direction = ParameterDirection.Input
        param(0).Value = Request.QueryString("empcode")

        param(1) = New OracleParameter("qual", OracleType.Number)
        param(1).Direction = ParameterDirection.Input
        If num = 1 Then
            param(1).Value = 0
        Else
            param(1).Value = Me.hid1.Value
        End If

        param(2) = New OracleParameter("num", OracleType.Number)
        param(2).Direction = ParameterDirection.Input
        param(2).Value = num


        param(3) = New OracleParameter("qualificationid", OracleType.Number)
        param(3).Direction = ParameterDirection.Input
        param(3).Value = Me.cmb_addq.SelectedValue

        param(4) = New OracleParameter("institute", OracleType.VarChar)
        param(4).Direction = ParameterDirection.Input
        If Me.txt_addinstitute.Text = "" Then
            param(4).Value = "NIL"
        Else
            param(4).Value = Me.txt_addinstitute.Text
        End If

        param(5) = New OracleParameter("univer", OracleType.VarChar)
        param(5).Direction = ParameterDirection.Input
        If Me.txt_adduniversity.Text = "" Then
            param(5).Value = "NIL"
        Else
            param(5).Value = Me.txt_adduniversity.Text
        End If

        param(6) = New OracleParameter("percen", OracleType.Number)
        param(6).Direction = ParameterDirection.Input
        If Me.txt_addpercentage.Text = "" Then
            param(6).Value = 0
        Else
            param(6).Value = Me.txt_addpercentage.Text

        End If

        param(7) = New OracleParameter("yearpass", OracleType.VarChar)
        param(7).Direction = ParameterDirection.Input
        If Me.txt_addyear.Text = "" Then
            param(7).Value = 0
        Else
            param(7).Value = Me.txt_addyear.Text

        End If

        param(8) = New OracleParameter("approved", OracleType.VarChar)
        param(8).Direction = ParameterDirection.Input
        param(8).Value = Session("user_id")

        param(9) = New OracleParameter("high", OracleType.Number)
        param(9).Direction = ParameterDirection.Input
        param(9).Value = 0
        'param(9).Value = Convert.ToInt32(Me.hid3.Value)

        param(11) = New OracleParameter("fl", OracleType.Number, 5)
        param(11).Value = 5

        param(12) = New OracleParameter("enterBy", OracleType.Number, 5)
        param(12).Value = 0


        param(10) = New OracleParameter("update_flag", OracleType.Number)
        param(10).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("EDITEMP_QUALEXP_MACOM", param)
        Dim script1 As New System.Text.StringBuilder
        If param(10).Value = 1 Then

            script1.Append("        alert('Successfully done');")
            Me.ListBox3.Items.Clear()
            expdetails()
        Else
            script1.Append("        alert('Sorry,Error in Editing');")
        End If
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

    End Sub

    Protected Sub cmd_add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_add.Click

        Dim high As String
        If Me.chk_higher.Checked = True Then
            high = "HIGH"
            Me.hid3.Value = Me.cmb_addq.SelectedValue
        Else
            high = "LOW"
        End If
        Dim str As String
        str = Me.cmb_addq.SelectedValue & " - " & Me.cmb_addq.SelectedItem.Text & " - " & Me.txt_addinstitute.Text & " - " & Me.txt_adduniversity.Text & " - " & Me.txt_addpercentage.Text & "% - " & Me.txt_addyear.Text & " - " & high
        procedure(1)
        Me.ListBox1.Items.Clear()
        qualificationdetails()
        cleara()
    End Sub

    Protected Sub cmd_edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_edit.Click
        
        If Me.ListBox1.SelectedIndex = -1 Then
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('Please Select A Qualification To Edit');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        
        Dim k As Integer = 0
        Dim high As String
        Dim lst As New ListItem
        lst = Me.ListBox1.SelectedItem
        If Me.chk_higher.Checked = False And Me.hid2.Value = "HIGH" Then
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('Please Mark Higher Qualification');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        If Me.chk_higher.Checked = True Then

            high = "HIGH"
            Me.hid3.Value = Me.cmb_addq.SelectedValue
        Else
            high = "LOW"
        End If
        procedure(2)
        'MsgBox(Request.QueryString("empcode"))

        qualificationdetails()
        cleara()
    End Sub

    Protected Sub cmd_delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_delete.Click
        If Me.ListBox1.SelectedIndex = -1 Then
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('Please Select A Qualification To Delete');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub

        End If
        If Me.hid2.Value = "HIGH" Then
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('Sorry,You must select One Higher Qualification before delete');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        procedure(3)
        ' Me.ListBox1.Items.Remove(Me.ListBox1.SelectedItem)
        qualificationdetails()
        cleara()
    End Sub

   

    Protected Sub cmd_clear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_clear.Click
        cleara()
    End Sub
    Public Sub cleara()
        Me.txt_addinstitute.Text = ""
        Me.txt_adduniversity.Text = ""
        Me.txt_addpercentage.Text = ""
        Me.txt_addyear.Text = ""
    End Sub

    Protected Sub cmd_next_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_next.Click
        Me.Server.Transfer("editempaddresshrm.aspx")
    End Sub

   



    Protected Sub cmd_adde_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_adde.Click
        If Me.ListBox3.Items.Count = 0 Then
            Exit Sub
        End If
        If Session("firm_id") <> 8 Then
            oh.ExecuteNonQuery("delete from employ_experience_dtl where emp_code=" & Request.QueryString("empcode"))
        End If

        Dim stre As String = ""
        For Each item As ListItem In Me.ListBox3.Items
            item.Selected = True
            stre = Me.ListBox3.SelectedItem().Text
            Me.txt_org.Text = Split(stre, " - ")(0)
            Me.txt_designation.Text = Split(stre, " - ")(1)
            Me.txt_periodfrom.Text = Split(stre, " - ")(2)
            Me.txt_periodto.Text = Split(stre, " - ")(3)
            Me.txt_nature.Text = Split(stre, " - ")(4)
            Me.txt_salary.Text = Split(stre, " - ")(5)
            Me.txt_contact.Text = Split(stre, " - ")(6)
            Me.txt_contactno.Text = Split(stre, " - ")(7)
            Me.txt_reason.Text = Split(stre, " - ")(8)
            proceduree()
            item.Selected = False
        Next
        expdetails()
        clearall()
        Me.ListBox3.Items.Clear()
    End Sub

    Protected Sub cmd_listadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_listadd.Click
        Dim stre As String = ""
        stre = Me.txt_org.Text & " - " & Me.txt_designation.Text & " - " & Format(CDate(Me.txt_periodfrom.Text), "dd/MMM/yyyy") & " - " & Format(CDate(Me.txt_periodto.Text), "dd/MMM/yyyy") & " - " & Me.txt_nature.Text & " - " & Me.txt_salary.Text & " - " & Me.txt_contact.Text & " - " & Me.txt_contactno.Text & " - " & Me.txt_reason.Text
        Me.ListBox3.Items.Add(stre)
    End Sub


    Private Sub proceduree()
        Dim param(12) As OracleParameter
        param(0) = New OracleParameter("empcode", OracleType.Number)
        param(0).Direction = ParameterDirection.Input
        param(0).Value = Request.QueryString("empcode")

        param(1) = New OracleParameter("org", OracleType.VarChar)
        param(1).Direction = ParameterDirection.Input
        param(1).Value = Me.txt_org.Text

        param(2) = New OracleParameter("desig", OracleType.VarChar)
        param(2).Direction = ParameterDirection.Input
        If Me.txt_designation.Text = "" Then
            param(2).Value = "NIL"
        Else
            param(2).Value = Me.txt_designation.Text
        End If

        param(3) = New OracleParameter("frdate", OracleType.DateTime)
        param(3).Direction = ParameterDirection.Input
        param(3).Value = Me.txt_periodfrom.Text

        param(4) = New OracleParameter("todate", OracleType.DateTime)
        param(4).Direction = ParameterDirection.Input
        param(4).Value = Me.txt_periodto.Text

        param(5) = New OracleParameter("nature", OracleType.VarChar)
        param(5).Direction = ParameterDirection.Input
        If Me.txt_nature.Text = "" Then
            param(5).Value = "NIL"
        Else
            param(5).Value = Me.txt_nature.Text
        End If

        param(6) = New OracleParameter("reason", OracleType.VarChar)
        param(6).Direction = ParameterDirection.Input
        If Me.txt_reason.Text = "" Then
            param(6).Value = "NIL"
        Else
            param(6).Value = Me.txt_reason.Text
        End If

        param(7) = New OracleParameter("contact", OracleType.VarChar)
        param(7).Direction = ParameterDirection.Input
        If Me.txt_contact.Text = " " Then
            param(7).Value = "NIL"
        Else
            param(7).Value = Me.txt_contact.Text
        End If

        param(8) = New OracleParameter("contactno", OracleType.VarChar)
        param(8).Direction = ParameterDirection.Input
        If Me.txt_contactno.Text = "" Then
            param(8).Value = "NIL"
        Else
            param(8).Value = Me.txt_contactno.Text
        End If

        param(9) = New OracleParameter("salary", OracleType.Number)
        param(9).Direction = ParameterDirection.Input
        If Me.txt_salary.Text = "" Then
            param(9).Value = 0
        Else
            param(9).Value = Me.txt_salary.Text
        End If
        param(11) = New OracleParameter("fl", OracleType.Number, 5)
        param(11).Value = 6

        param(12) = New OracleParameter("enterBy", OracleType.Number, 5)
        param(12).Value = 0

        param(10) = New OracleParameter("update_flag", OracleType.Number)
        param(10).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("EDITEMP_EXP_MACOM", param)
        Dim script1 As New System.Text.StringBuilder
        If param(10).Value = 1 Then
            script1.Append("        alert('Successfully done');")
        Else
            script1.Append("        alert('Sorry,Error in Editing');")
        End If
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

    End Sub

    Protected Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If Me.ListBox1.Items.Count = 0 Then
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('No Qualification Details To Select');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

            Exit Sub
        End If
        If Me.ListBox1.SelectedIndex = -1 Then
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('Please Select A Qualification');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        Dim str As String = Me.ListBox1.SelectedItem().Text
        Me.cmb_addq.SelectedValue = Split(str, " - ")(0)
        Me.txt_addinstitute.Text = Split(str, " - ")(2)
        Me.txt_adduniversity.Text = Split(str, " - ")(3)
        Dim st As String = Split(str, " - ")(4)
        Me.txt_addpercentage.Text = Split(st, "%")(0)
        Me.txt_addyear.Text = Split(str, " - ")(5)
        If Split(str, " - ")(6) = "HIGH" Then
            Me.hid2.Value = "HIGH"
            Me.chk_higher.Checked = True
            Me.hid3.Value = Split(str, " - ")(0)
        Else
            Me.chk_higher.Checked = False
            Me.hid2.Value = "LOW"
        End If
        Me.hid1.Value = Split(str, " - ")(0)
    End Sub

    Protected Sub ListBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        If Me.ListBox2.Items.Count = 0 Then
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('No Experience Details Found');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub

        End If
        If Me.ListBox2.SelectedIndex = -1 Then
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('Please Select An Experience');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        Dim str As String = Me.ListBox2.SelectedItem().Text
        Me.txt_org.Text = Split(str, " - ")(0)
        Me.txt_designation.Text = Split(str, " - ")(1)
        Me.txt_periodfrom.Text = Format(CDate(Split(str, " - ")(2)), "dd/MMM/yyyy")
        Me.txt_periodto.Text = Format(CDate(Split(str, " - ")(3)), "dd/MMM/yyyy")
        Me.txt_nature.Text = Split(str, " - ")(4)
        Me.txt_salary.Text = Split(str, " - ")(5)
        Me.txt_contact.Text = Split(str, " - ")(6)
        Me.txt_contactno.Text = Split(str, " - ")(7)
        Me.txt_reason.Text = Split(str, " - ")(8)
        ' Me.ListBox2.Items.Remove(Me.ListBox2.SelectedItem)
    End Sub
End Class

