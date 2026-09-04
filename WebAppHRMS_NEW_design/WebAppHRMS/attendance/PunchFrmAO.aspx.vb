Imports System.Data
Imports System.Data.OracleClient
Partial Class PunchFrm_AO_PunchFrmAO_f6d41b6d3321
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("access_id") = 25 Or Session("access_id") = 66 Then
            If Not IsPostBack Then
                branch_fill()
                dt1 = oh.ExecuteDataSet("select to_char(sysdate,'hh24:mi:ss') from dual").Tables(0)
                If CDate(dt1.Rows(0)(0)) <= CDate("16:30:00") Then
                    dt = oh.ExecuteDataSet("select em.emp_name||'('||em.emp_code||')',em.emp_code from employee_master em,daily_attend da where da.emp_code=em.emp_code and da.m_time is null  and da.branch_id=0  order by em.emp_name").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select em.emp_name||'('||em.emp_code||')',em.emp_code from employee_master em,daily_attend da where da.emp_code=em.emp_code and  da.e_time is null and da.branch_id= 0  order by em.emp_name").Tables(0)
                End If

                If dt.Rows.Count > 0 Then
                    Me.lst_emp.DataSource = dt
                    Me.lst_emp.DataTextField = dt.Columns(0).ColumnName
                    Me.lst_emp.DataValueField = dt.Columns(1).ColumnName
                    Me.lst_emp.DataBind()
                Else
                    lst_emp.Items.Insert(0, New ListItem("NO SUCH EMPLOYEE", "9999"))
                    lst_emp.DataBind()
                End If
            End If
        Else
            Response.Redirect("../show_err.aspx")
        End If

    End Sub
    Sub branch_fill()
        dt = oh.ExecuteDataSet("select branch_name,branch_id from branch_master order by branch_name").Tables(0)
        Me.drp_branch.DataSource = dt
        Me.drp_branch.DataTextField = dt.Columns(0).ColumnName
        Me.drp_branch.DataValueField = dt.Columns(1).ColumnName
        Me.drp_branch.DataBind()
    End Sub
    Protected Sub drp_branch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drp_branch.SelectedIndexChanged
        lst_emp.Items.Clear()
        dt1 = oh.ExecuteDataSet("select to_char(sysdate,'hh24:mi:ss') from dual").Tables(0)
        If CDate(dt1.Rows(0)(0)) <= CDate("16:30:00") Then
            dt = oh.ExecuteDataSet("select em.emp_name||'('||em.emp_code||')',em.emp_code from employee_master em,daily_attend da where da.emp_code=em.emp_code and da.m_time is null  and da.branch_id=" & Me.drp_branch.SelectedValue & " order by em.emp_name").Tables(0)
        Else
            dt = oh.ExecuteDataSet("select em.emp_name||'('||em.emp_code||')',em.emp_code from employee_master em,daily_attend da where da.emp_code=em.emp_code and  da.e_time is null and da.branch_id=" & Me.drp_branch.SelectedValue & " order by em.emp_name").Tables(0)
        End If

        If dt.Rows.Count > 0 Then
            Me.lst_emp.DataSource = dt
            Me.lst_emp.DataTextField = dt.Columns(0).ColumnName
            Me.lst_emp.DataValueField = dt.Columns(1).ColumnName
            Me.lst_emp.DataBind()
        Else
            lst_emp.Items.Insert(0, New ListItem("NO SUCH EMPLOYEE", "9999"))
            lst_emp.DataBind()
        End If
        Me.Lbl_shift.Text = "---------------------"
        Me.Label1.Text = "---------------------"
    End Sub

    Protected Sub lst_emp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_emp.SelectedIndexChanged

        If lst_emp.SelectedValue <> 9999 Then
            dt = oh.ExecuteDataSet("select em.emp_name,tb.in_time||' -�- '||tb.out_time,em.emp_code from employee_master em,time_tab tb where em.shift_id=tb.shift_id and em.emp_code=" & Me.lst_emp.SelectedValue & "").Tables(0)
            Me.Lbl_shift.Text = dt.Rows(0)(1)
            Me.Label1.Text = dt.Rows(0)(0) + "(" + Me.lst_emp.SelectedValue + ")"
        Else
            Me.Lbl_shift.Text = "---------------------"
            Me.Label1.Text = "---------------------"
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Me.Label1.Text <> "---------------------" And Me.txt_frm_shft.Text <> "" Then
            Dim str(10), temp(10) As String
            str = Me.Label1.Text.Split("(")
            temp = str(1).Split(")")
            Try
                Dim p(3) As OracleParameter
                p(0) = New OracleParameter("ecode", OracleType.Number, 5)
                p(0).Value = temp(0)
                p(1) = New OracleParameter("tme", OracleType.VarChar, 15)
                p(1).Value = Me.txt_frm_shft.Text
                p(2) = New OracleParameter("userid", OracleType.VarChar, 25)
                p(2).Value = Session("user_id")
                p(2).Direction = ParameterDirection.Output
                p(3) = New OracleParameter("status", OracleType.Number, 1)
                p(3).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("pay_aopunch", p)
                If p(2).Value = 1 Then
                    'MsgBox("UPDATED")
                    Dim cl_script As New StringBuilder
                    cl_script.Append("   alert('UPDATED') ;")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                    Server.Transfer("PunchFrmAO.aspx")
                Else
                    'MsgBox("ERROR")
                    Dim cl_script As New StringBuilder
                    cl_script.Append("   alert('ERROR !!') ;")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                    Me.txt_frm_shft.Text = ""
                    Me.Label1.Text = ""
                    Me.Lbl_shift.Text = ""
                End If
            Catch ex As Exception
                'MsgBox(ex.Message)
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('" & ex.Message & "') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            End Try

        Else
            'MsgBox("Enter All The Details")
            Dim cl_script As New StringBuilder
            cl_script.Append("   alert('Enter All The Details !!') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
        End If
    End Sub
End Class