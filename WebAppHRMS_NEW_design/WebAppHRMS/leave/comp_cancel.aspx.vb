Imports System.Data
Imports System.Data.OracleClient
Partial Class RAJEESH_comp_cancel_5f3a74087842
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.txt_empcode.Text = "" Then
            Me.Label1.Text = "<FONT SIZE=3><B>ENTER EMPLOYEE CODE</B></FONT>"
            Exit Sub
        End If
        If Me.cmb_type.Items.Count = 0 Then
            Me.Label1.Text = "<FONT SIZE=3><B>YOU HAVE NO COMPENSATORY FOR CANCELATION</B></FONT>"
            Exit Sub
        End If

        sql = "select count(*) from employee_master where emp_code=" & Me.txt_empcode.Text & ""
        Dim dt43 As New DataTable
        dt43 = oh.ExecuteDataSet(sql).Tables(0)
        If dt43.Rows.Count > 0 Then
       
            Dim DT As String = Me.txt_dt.Text
            DT = DT.ToUpper
            Try

                Dim tour(3) As OracleParameter
                tour(0) = New OracleParameter("emp_id", OracleType.Number)
                tour(0).Direction = ParameterDirection.Input
                tour(0).Value = Me.txt_empcode.Text
                tour(1) = New OracleParameter("dt", OracleType.DateTime)
                tour(1).Direction = ParameterDirection.Input
                tour(1).Value = DT
                tour(2) = New OracleParameter("type", OracleType.Int32)
                tour(2).Direction = ParameterDirection.Input
                tour(2).Value = Me.cmb_type.SelectedValue
                tour(3) = New OracleParameter("er", OracleType.Int32)
                tour(3).Direction = ParameterDirection.Output
                tour(3).Value = 0
                oh.ExecuteNonQuery("comp_cancel", tour)
                If tour(3).Value = 1 Then
                    Me.Label1.Text = "<FONT SIZE=3 ><B>" & Me.txt_empcode.Text & "-" & Me.cmb_type.SelectedItem.Text & "-COMPENSATORY CANCELLED </B></FONT>"
                    Me.txt_dt.Text = ""
                    Me.txt_ldt.Text = ""
                    Me.txt_empcode.Text = ""
                    Me.cmb_type.SelectedItem.Text = ""
                    filldata()
                Else
                    Me.Label1.Text = "<FONT SIZE=3 ><B>CANCELATION FAILED </B></FONT>"
                End If
            Catch ex As Exception
                Me.Label1.Text = ex.Message
            End Try
        Else
            Me.Label1.Text = "<FONT SIZE=3 ><B>NO SUCH EMPLOYEE</B></FONT>"
        End If
    End Sub

    Protected Sub txt_empcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        '    sql = "select c.comp_name,c.comp_id,c.comp_date from comp_master c,employ_compensat_master e where e.comp_id=c.comp_id and e.status_id in (1,2) and  e.emp_code=" & Me.txt_empcode.Text & ""
        '    Dim dt4 As New DataTable
        '    dt4 = oh.ExecuteDataSet(sql).Tables(0)
        '    If dt4.Rows.Count > 0 Then
        '        Me.cmb_type.DataSource = dt4
        '        Me.cmb_type.DataTextField = dt4.Columns(0).ColumnName
        '        Me.cmb_type.DataValueField = dt4.Columns(1).ColumnName
        '        Me.cmb_type.DataBind()
        '        If dt4.Rows.Count = 1 Then
        '            Me.txt_dt.Text = Format(dt4.Rows(0)(2), "dd-MMM-yyyy")
        '        End If
        '    Else
        '        Me.Label1.Text = "" & Me.txt_empcode.Text & "-- YOU HAVE NO COMPENSATORY FOR CANCELATION"
        '        Me.txt_empcode.Text = ""
        '    End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Label2.Text = "<marquee><font>This is for canceling the leave.select compensatory and cancel it</font></marquee>"
        Dim st As String = Me.Session("user_id")
        Dim st1(), st2, st3 As String
        st1 = st.Split("!")
        st2 = st1(0)
        st3 = st1(1)
        Me.txt_empcode.Text = st2
        sql = "select count(*) from employee_master where emp_code=" & st2 & ""
        Dim dt43 As New DataTable
        dt43 = oh.ExecuteDataSet(sql).Tables(0)
        If dt43.Rows(0)(0) = 0 Then
            Me.Label1.Text = "<FONT SIZE=3 ><B>NO SUCH EMPLOYEE</B></FONT>"
            Me.txt_empcode.Text = ""
            Exit Sub
        End If

        If Not IsPostBack Then
            filldata()
        End If
      
      
        sql = "select count(*) from comp_master c,employ_compensat_master e where e.comp_id=c.comp_id and e.status_id in (1,2) and  e.emp_code=" & st2 & " and c.expiry_dt>sysdate"
        Dim dt4 As New DataTable
        dt4 = oh.ExecuteDataSet(sql).Tables(0)
        If dt4.Rows.Count = 0 Then
            Me.Label2.Text = "" & Me.txt_empcode.Text & "--NOW  YOU HAVE NO COMPENSATORY FOR CANCELATION"
        End If
    End Sub

    Protected Sub cmb_type_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' sql = "select comp_date from comp_master where comp_id=" & Me.cmb_type.SelectedValue & ""
        sql = "select c.comp_date,e.leave_dt from comp_master c,employ_compensat_master e where c.comp_id=e.comp_id and c.comp_id=" & Me.cmb_type.SelectedValue & " and e.emp_code=" & Me.txt_empcode.Text & "  and e.status_id in (1,2) and c.expiry_dt>sysdate"
        Dim dt6 As New DataTable
        dt6 = oh.ExecuteDataSet(sql).Tables(0)
        If dt6.Rows.Count > 0 Then
            Me.txt_dt.Text = Format(dt6.Rows(0)(0), "DD-MMM-YYYY")
            Me.txt_ldt.Text = Format(dt6.Rows(0)(1), "DD-MMM-YYYY")
        Else
            Me.txt_dt.Text = "NO DATE"
        End If
    End Sub

    Protected Sub cmb_type_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_type.SelectedIndexChanged
        '  sql = "select comp_date from comp_master where comp_id=" & Me.cmb_type.SelectedValue & ""
        sql = "select c.comp_date,e.leave_dt from comp_master c,employ_compensat_master e where c.comp_id=e.comp_id and c.comp_id=" & Me.cmb_type.SelectedValue & " and e.emp_code=" & Me.txt_empcode.Text & "  and e.status_id in (1,2) and c.expiry_dt>sysdate"
        Dim dt6 As New DataTable
        dt6 = oh.ExecuteDataSet(sql).Tables(0)
        If dt6.Rows.Count > 0 Then
            Me.txt_dt.Text = dt6.Rows(0)(0)
            Me.txt_ldt.Text = dt6.Rows(0)(1)
        Else
            Me.txt_dt.Text = "NO DATE"
        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Server.Transfer("../home.aspx")
    End Sub
    Sub filldata()
        Dim st As String = Me.Session("user_id")
        Dim st1(), st2, st3 As String
        st1 = st.Split("!")
        st2 = st1(0)
        st3 = st1(1)
        Me.txt_empcode.Text = st2
        sql = "select c.comp_name,c.comp_id,c.comp_date,e.leave_dt from comp_master c,employ_compensat_master e where e.comp_id=c.comp_id and e.status_id in (1,2) and  e.emp_code=" & st2 & " and c.expiry_dt>sysdate"
        Dim dt4 As New DataTable
        dt4 = oh.ExecuteDataSet(sql).Tables(0)
        If dt4.Rows.Count = 1 Then
            Me.cmb_type.DataSource = dt4
            Me.cmb_type.DataTextField = dt4.Columns(0).ColumnName
            Me.cmb_type.DataValueField = dt4.Columns(1).ColumnName
            Me.cmb_type.DataBind()
            Me.txt_dt.Text = dt4.Rows(0)(2)
            Me.txt_ldt.Text = dt4.Rows(0)(3)
        Else
            If dt4.Rows.Count > 0 Then
                Me.cmb_type.DataSource = dt4
                Me.cmb_type.DataTextField = dt4.Columns(0).ColumnName
                Me.cmb_type.DataValueField = dt4.Columns(1).ColumnName
                Me.cmb_type.DataBind()
                If dt4.Rows.Count = 1 Then
                    Me.txt_dt.Text = Format(dt4.Rows(0)(2), "dd-MMM-yyyy")
                End If
            Else
                Me.Label2.Text = "<FONT SIZE=3 COLOR=RED><B>" & Me.txt_empcode.Text & "--NOW YOU HAVE NO COMPENSATORY FOR CANCELATION</B></FONT>"
                Me.txt_empcode.Text = ""
            End If
        End If
    End Sub
End Class
