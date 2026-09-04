Imports System.Data
Imports system.data.oracleclient
Partial Class specificempattend_atterepo_d50e23417457
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim fir As Integer
    Dim firm As String
    Dim dt1 As DataTable
    Dim sql As String
    Dim sql2 As String
    Dim fmid As Integer
    Dim dt As DataTable
    Dim dt2 As DataTable
    Dim str_tkn As New System.Text.StringBuilder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '' ''Session("firm_id") = 8
        fir = Session("firm_id")
        firm = Session("firm_name")
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        If Not IsPostBack Then
            Me.TextBox1.Text = user(0)
        End If
        Me.TextBox1.Enabled = False
        Me.TextBox2.focus()
        sql = "select count(t.emp_id) from form_accessibility t where t.form_id=849 and t.emp_id='" & user(0) & "'"
        sql2 = "select em.branch_id from employee_master em where em.emp_code='" & user(0) & "'"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        dt2 = oh.ExecuteDataSet(sql2).Tables(0)
        If dt2.Rows(0)(0) = 0 Or dt.Rows(0)(0) <> 0 Then
            Me.TextBox1.Enabled = True
            Me.TextBox1.focus()
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        dt1 = oh.ExecuteDataSet("select ef.firm_id from employee_master e,employ_firm ef where ef.emp_code=e.emp_code and e.emp_code=" & Me.TextBox1.Text & "").Tables(0)
        If dt1.Rows.Count <= 0 Then
            str_tkn.Append("         alert('Invalid Employee Code...!');")
            str_tkn.Append(" window.open('atterepo.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
            Exit Sub
        Else
            fmid = dt1.Rows(0)(0)
            If fmid <> fir Then
                str_tkn.Append("         alert('Invalid Employee Code...!');")
                str_tkn.Append(" window.open('atterepo.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
                Exit Sub
            End If
        End If

        If Session("firm_id") = 27 Then

            Dim user1() As String
            user1 = Session("user_id").ToString.Split("!")
            If Me.TextBox1.Text = user1(0) Then
                'Server.Transfer("individualreport_mafarm.aspx?&fdt=" & Me.TextBox2.Text & "&tdt=" & Me.TextBox3.Text & "&emp=" & Me.TextBox1.Text)
                Server.Transfer("individualreport_mafarm.aspx?&fdt=" & Me.TextBox2.Text & "&tdt=" & Me.TextBox3.Text & "&emp=" & Me.TextBox1.Text)
            End If
        End If



        If Trim(TextBox1.Text) = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Enter Emp Code');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            If TextBox2.Text = "" Or TextBox3.Text = "" Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('Please Select Date');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                If CDate(TextBox2.Text) > CDate(TextBox3.Text) Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('To Date Not Valid');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Else
                    If CDate(TextBox3.Text) > CDate(Date.Now) Or CDate(TextBox2.Text) > CDate(Date.Now) Then
                        Dim cl_script1 As New System.Text.StringBuilder
                        cl_script1.Append("         alert('Future Date Not Allowed');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Else
                        '--------------- ReqID 8592 starts------------------------------
                        If Session("firm_id") = 8 Then


                            '---------------------end--------------------------------------------------------------------

                            Dim user() As String
                            user = Session("user_id").ToString.Split("!")
                            If Me.TextBox1.Text = user(0) Then
                                Server.Transfer("individualreport_macom.aspx?&fdt=" & Me.TextBox2.Text & "&tdt=" & Me.TextBox3.Text & "&emp=" & Me.TextBox1.Text)
                            Else
                                ' ..............attendance report access to vasanthakumar sir..............
                                If user(0) = 32706 Then
                                    Server.Transfer("individualreport_macom.aspx?&fdt=" & Me.TextBox2.Text & "&tdt=" & Me.TextBox3.Text & "&emp=" & Me.TextBox1.Text)
                                Else

                                    ' ..............attendance report access to vasanthakumar sir..............
                                    Dim dhead As String
                                    dhead = oh.ExecuteDataSet("select d.dep_head from department_mst d,employee_master t where t.department_id=d.dep_id and t.emp_code=" & Me.TextBox1.Text & "").Tables(0).Rows(0)(0)
                                    If dhead = user(0) Then
                                        Server.Transfer("individualreport_macom.aspx?&fdt=" & Me.TextBox2.Text & "&tdt=" & Me.TextBox3.Text & "&emp=" & Me.TextBox1.Text)
                                    Else
                                        Dim hr As String
                                        hr = oh.ExecuteDataSet("select t.access_id from employee_master t where t.emp_code=" & user(0) & "").Tables(0).Rows(0)(0)
                                        If hr = 33 Then
                                            Server.Transfer("individualreport_macom.aspx?&fdt=" & Me.TextBox2.Text & "&tdt=" & Me.TextBox3.Text & "&emp=" & Me.TextBox1.Text)
                                        Else

                                            Dim cl_script1 As New System.Text.StringBuilder
                                            cl_script1.Append("         alert('You Are Not Allowed To Enter Other Employee Code... Enter Your Own');")
                                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                                        End If
                                    End If
                                End If

                            End If








                            '--------------- ReqID 8592 starts ------------------------------
                        Else

                            If Session("firm_id") = 24 Then ''''----Req id :18166

                                Dim user() As String
                                user = Session("user_id").ToString.Split("!")
                                If Me.TextBox1.Text = user(0) Then
                                    Server.Transfer("individualreport.aspx?&fdt=" & Me.TextBox2.Text & "&tdt=" & Me.TextBox3.Text & "&emp=" & Me.TextBox1.Text)
                                Else
                                    Dim hr As String
                                    hr = oh.ExecuteDataSet("select t.access_id from employee_master t where t.emp_code=" & user(0) & "").Tables(0).Rows(0)(0)

                                    '------------------
                                    ' Req. 18384
                                    ' hrm_report_access Table contains employee code and an associated query to fetch access allowed employees. (To view their punching report)
                                    '------------------

                                    Dim empcount As Integer
                                    empcount = 0
                                    Dim sb As New StringBuilder()
                                    Dim dtSQL As New DataTable()
                                    dtSQL = oh.ExecuteDataSet("Select t.query from hrm_report_access t where t.firm_id = " & Session("firm_id") & " and t.emp_code = " & user(0) & " ").Tables(0)
                                    If dtSQL.Rows.Count > 0 Then
                                        sb.Append(dtSQL.Rows(0)(0))
                                        sb.Append(Me.TextBox1.Text)

                                        Dim ds As New DataSet()
                                        Dim sql As String = sb.ToString()
                                        ds = oh.ExecuteDataSet(sql)
                                        If ds.Tables(0).Rows.Count > 0 Then
                                            empcount = Convert.ToInt32(ds.Tables(0).Rows(0)(0).ToString())
                                        End If
                                    End If

                                    '--------------------------------------
                                    If hr = 33 Or empcount = 1 Then
                                        Server.Transfer("individualreport.aspx?&fdt=" & Me.TextBox2.Text & "&tdt=" & Me.TextBox3.Text & "&emp=" & Me.TextBox1.Text)
                                    Else
                                        Dim cl_script1 As New System.Text.StringBuilder
                                        cl_script1.Append("         alert('You Are Not Allowed To Enter Other Employee Code... Enter Your Own');")
                                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                                    End If
                                End If


                            Else
                                Server.Transfer("individualreport.aspx?&fdt=" & Me.TextBox2.Text & "&tdt=" & Me.TextBox3.Text & "&emp=" & Me.TextBox1.Text)
                            End If      ' Firm check 24 end here..



                            'Server.Transfer("individualreport.aspx?&fdt=" & Me.TextBox2.Text & "&tdt=" & Me.TextBox3.Text & "&emp=" & Me.TextBox1.Text)
                        End If

                        '---------------------end--------------------------------------------------------------------



                    End If
                End If
            End If
        End If
    End Sub


End Class
