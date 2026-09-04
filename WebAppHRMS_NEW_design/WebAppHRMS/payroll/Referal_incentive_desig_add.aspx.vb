Imports System.Data
Imports System.Data.OracleClient
Partial Class referal_incentive_add_designation_556565188171
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2, dt3, dt4, dt7 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim CbResult As String = Nothing
    Dim str_tkn As New System.Text.StringBuilder
    Dim BranchID, RegionID, AreaID As Integer
    Dim Post As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "REFERRAL INCENTIVE-DESIGNATION ADD"
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Dim branch As String = Session("branch_id")
        Dim frm As Integer = Session("firm_id")
        '--KRISHNADAS CREATED FOR JEWEL REFERRAL INCENTIVE
        If Not IsPostBack Then

            dt1 = oh.ExecuteDataSet("select count(*) from form_accessibility t where t.form_id=1675 and t.emp_id= " & User(0) & " ").Tables(0)
            If dt1.Rows(0)(0) = 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('You Are Not Authorised !!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            End If
            load_data()
        End If
    End Sub
    Sub load_data()
        Dim frm As Integer = Session("firm_id")
        dt = oh.ExecuteDataSet("select 0, '---------Select----------'   from dual union all select t.designation_id, t.designation   from designation_master t  where t.designation_id not in        (select s.designation_id           from HRM_REFERRAL_AMOUNT_MASTER s          where s.firm_id =" & frm & ")  order by 2 ").Tables(0)
        If dt.Rows.Count >= 1 Then
            Me.cmb_desig.DataSource = dt
            Me.cmb_desig.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_desig.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_desig.DataBind()
        End If
    End Sub

    Protected Sub btn_Confirm_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Confirm.ServerClick
        Dim frm As Integer = Session("firm_id")
        Dim User = Session("user_id").ToString.Split("!")

        If Me.txt_first.Text = "" Or Me.txt_second.Text = "" Or Me.txt_third.Text = "" Or Me.txt_total.Text = "" Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('ENTER VALUES');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Me.cmb_desig.SelectedValue = 0
            Exit Sub

        Else
            If Me.cmb_desig.SelectedValue < 1 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('SELECT DESIGNATION');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                Exit Sub
            Else
                If Not IsNumeric(Me.txt_first.Text) Then
                    Dim cl_script0 As New System.Text.StringBuilder
                    cl_script0.Append("         alert('ENTER VALUE PROPERLY');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                    Exit Sub
                Else
                    If Not IsNumeric(Me.txt_second.Text) Then
                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert('ENTER VALUE PROPERLY');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                        Exit Sub
                    Else
                        If Not IsNumeric(Me.txt_third.Text) Then
                            Dim cl_script0 As New System.Text.StringBuilder
                            cl_script0.Append("         alert('ENTER VALUE PROPERLY');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                            Exit Sub
                        Else
                            If Not IsNumeric(Me.txt_total.Text) Then
                                Dim cl_script0 As New System.Text.StringBuilder
                                cl_script0.Append("         alert('ENTER VALUE PROPERLY');")
                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                                Exit Sub
                            End If
                            End If
                    End If
                    End If
                    If (CInt(Me.txt_first.Text) + CInt(Me.txt_second.Text) + CInt(Me.txt_third.Text)) <> CInt(Me.txt_total.Text) Then
                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert('PLEASE VERIFY TOTAL AMOUNT.TOTAL AMOUNT SHOULD BE SUM OF FIRST,SECOND AND THIRD INSTALLMENT');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                        Exit Sub
                    Else
                        Try
                            Dim p(7) As OracleParameter
                            p(0) = New OracleParameter("desig", OracleType.Number, 4)
                            p(0).Value = Me.cmb_desig.SelectedValue


                            p(1) = New OracleParameter("total", OracleType.Number, 9)
                            p(1).Value = CInt(Me.txt_total.Text)

                            p(2) = New OracleParameter("firstamnt", OracleType.Number, 9)
                            p(2).Value = CInt(Me.txt_first.Text)

                            p(3) = New OracleParameter("secondamnt", OracleType.Number, 9)
                            p(3).Value = CInt(Me.txt_second.Text)

                            p(4) = New OracleParameter("thirdamnt", OracleType.Number, 9)
                            p(4).Value = CInt(Me.txt_third.Text)

                            p(5) = New OracleParameter("firm", OracleType.Number, 9)
                            p(5).Value = frm

                            p(6) = New OracleParameter("userid", OracleType.Number, 9)
                            p(6).Value = CInt(User(0))

                            p(7) = New OracleParameter("msg", OracleType.VarChar, 100)
                            p(7).Direction = ParameterDirection.Output


                            oh.ExecuteNonQuery("hrm_referral_amount_master_pro", p)
                            CbResult = p(7).Value

                            Dim cl_script0 As New System.Text.StringBuilder
                            cl_script0.Append("         alert('" + CbResult + "');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                            load_data()
                            Me.cmb_desig.SelectedValue = 0
                            Me.txt_total.Text = ""
                            Me.txt_first.Text = ""
                            Me.txt_second.Text = ""
                            Me.txt_third.Text = ""

                        Catch ex As Exception
                            CbResult = ex.Message
                            Dim cl_script0 As New System.Text.StringBuilder
                            cl_script0.Append("         alert('" + CbResult + "');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

                        End Try
                    End If
            End If

        End If
    End Sub
End Class
