Imports System.Data
Imports System.Data.oracleclient
Imports System.IO
Partial Class HRM_JOIN_DT_CHANGE_ce99096c3438
    Inherits System.Web.UI.Page
    Dim sql, sql7, sql1, fnm As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dts As DataTable
    Dim usr() As String
    Dim UserCode, firm As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String = Session("user_id").ToString.Split("!")
        UserCode = User(0)
        firm = Session("firm_id")
        If Not IsPostBack Then
            Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=1306 and emp_id=" & UserCode).Tables(0).Rows(0)(0)
            If acce = 0 Then
                Me.Server.Transfer("../show_err.aspx")
            End If
        End If
    End Sub

    Protected Sub btnConfrm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfrm.Click
        Try
            Dim fir As Integer
            If Me.new_join.Text = "" Or Me.txtecode.Text = "" Or Me.txtename.Text = "" Or Me.txt_date.Text = "" Then

                ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), UniqueID, "javascript:alert('Please Fill all data properly');", True)

                clear()

            Else
                dt = oh.ExecuteDataSet("select t.firm_id from employ_firm  t where t.emp_code=" & UserCode).Tables(0)

                If dt.Rows.Count = 1 Then

                    dts = oh.ExecuteDataSet("select t.firm_id from employ_firm  t where t.emp_code=" & Me.txtecode.Text).Tables(0)

                    If dts.Rows.Count = 1 Then
                        fir = dts.Rows(0)(0)

                        If fir = firm Then


                            Dim p(4) As OracleParameter

                            p(0) = New OracleParameter("emp_id", OracleType.Number, 6)
                            p(0).Value = Me.txtecode.Text

                            p(1) = New OracleParameter("newjndt", OracleType.DateTime)
                            p(1).Value = Me.new_join.Text

                            p(2) = New OracleParameter("user", OracleType.Number, 6)
                            p(2).Value = UserCode

                            p(3) = New OracleParameter("msg", OracleType.VarChar, 100)
                            p(3).Direction = ParameterDirection.Output


                            p(4) = New OracleParameter("flg", OracleType.Number, 6)
                            p(4).Direction = ParameterDirection.Output

                            oh.ExecuteNonQuery("join_dt_chnge", p)

                            If p(4).Value = 1 Then
                                ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), UniqueID, "javascript:alert('Successfully changed');", True)
                                clear()
                            Else
                                ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), UniqueID, "javascript:alert('Some problems.. please contact IT');", True)
                                clear()
                            End If

                        Else
                            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), UniqueID, "javascript:alert('You cant Choose employees in other firm');", True)
                            clear()
                        End If
                    Else
                        ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), UniqueID, "javascript:alert('Incorrect employee you entered. check firm');", True)
                        clear()
                    End If
                    Else
                        ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), UniqueID, "javascript:alert('Invalid firm.. You Are not Authorized');", True)
                        clear()
                    End If
                End If

        Catch ex As Exception
            Dim st As String
            st = ex.ToString()
            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), UniqueID, "javascript:alert('ERROR.. please contact IT');", True)
        End Try

    End Sub

   
    Protected Sub txtecode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        dt = oh.ExecuteDataSet("select to_char(e.join_dt),e.emp_name,e.status_id from employee_master e where e.emp_code=" & Me.txtecode.Text & "").Tables(0)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)(2) <> 1 Then
                ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), UniqueID, "javascript:alert('This employee Not Live');", True)
                clear()
            Else
                Me.txtename.Text = dt.Rows(0)(1).ToString()
                Me.txt_date.Text = dt.Rows(0)(0).ToString()

            End If
        Else
            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), UniqueID, "javascript:alert('Invalid employee code');", True)
            clear()
        End If
    End Sub
    Public Function clear()
        Me.txtecode.Text = ""
        Me.txtename.Text = ""
        Me.txt_date.Text = ""
        Me.new_join.Text = ""
        Return 1
    End Function
End Class
