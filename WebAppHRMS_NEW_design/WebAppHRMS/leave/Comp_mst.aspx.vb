Imports System.Data
Imports System.Data.OracleClient
Partial Class Deepak_Comp_mst_229e70979571
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim st As String = Me.Session("user_id")
        Dim st1(), st2, st3 As String
        st1 = st.Split("!")
        st2 = st1(0)
        st3 = st1(1)
        sql = "select dep_id from department_mst where dep_head=" & st2 & ""
        Dim dt23 As New DataTable
        dt23 = oh.ExecuteDataSet(sql).Tables(0)

        If dt23.Rows.Count > 0 Then
            If dt23.Rows(0)(0) = 3 Then
                If Not IsPostBack Then
                    Me.txt_expire.Text = "31/Dec/2008"
                    fill()
                End If

            Else
                Me.Server.Transfer("../show_err.aspx")
            End If
        Else
            Me.Server.Transfer("../show_err.aspx")
        End If

        Me.Lbl_msg.Text = "<marquee><font>This Module For making a Compensatory Fill Comensatory name,date,Expiry date.After that insert it into the Selected state</font></marquee>"
    End Sub
    Sub fill()
        sql = "select comp_name||'--'||comp_date,comp_id from comp_master order by comp_name"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Me.Cmb_compname.DataSource = dt
        Me.Cmb_compname.DataTextField = dt.Columns(0).ColumnName
        Me.Cmb_compname.DataValueField = dt.Columns(1).ColumnName
        Me.Cmb_compname.DataBind()
        sql = "select state_name,state_id from state_master"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Me.Cmb_state.DataSource = dt
        Me.Cmb_state.DataTextField = dt.Columns(0).ColumnName
        Me.Cmb_state.DataValueField = dt.Columns(1).ColumnName
        Me.Cmb_state.DataBind()
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        
        sql = "select sysdate from dual"
        Dim dt1 As New DataTable
        dt1 = oh.ExecuteDataSet(sql).Tables(0)


        If (Me.Txt_comname.Text = "") Then
            Me.Lbl_msg.Text = "<font size=3><b>GIVE COMPENSATORY NAME<b></font>"
            Exit Sub
        End If
        If (Me.Txt_date.Text = "") Then
            Me.Lbl_msg.Text = "<font size=3><b>SELECT COMPENSATORY DATE<b></font>"
            Exit Sub
        End If
        If (Me.txt_expire.Text = "") Then
            Me.Lbl_msg.Text = "<font size=3><b>SELECT EXPIRY DATE<b></font>"
            Exit Sub
        End If
        Dim cdt1, cdt2 As New Date
        cdt1 = Me.Txt_date.Text
        cdt2 = Me.txt_expire.Text
        If (cdt1 >= cdt2) Then
            Me.Lbl_msg.Text = "<font size=3><b>EXPIRY DATE MUST BE GREATER THAN COMPENSATORY DATE<b></font>"
        ElseIf (cdt2 <= dt1.Rows(0)(0)) Then
            Me.Lbl_msg.Text = "<font size=3><b>EXPIRY DATE MUST BE GREATER THAN TODAY<b></font>"
        Else
            Dim dtd, usr As String
            dtd = Format(dt1.Rows(0)(0), "dd/MMM/yyyy")
            dtd = dtd.ToUpper
            usr = Me.Session("user_id")

            Dim id As Integer
            sql = "select count(*) from comp_master"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If (dt.Rows(0)(0) < 1) Then
                id = 1
            Else
                sql = "select max(comp_id)+1 from comp_master"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                id = dt.Rows(0)(0)
            End If
            sql = "select count(*) from comp_master where  to_date(comp_date)='" & Me.Txt_date.Text & "'"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If (dt.Rows(0)(0) > 0) Then
                Me.Lbl_msg.Text = "<font size=3><b>ALREADY ADD A COMPENSATORY ON THIS DATE<b></font>"
            Else
                sql = "insert into comp_master values(" & id & ",'" & Me.Txt_comname.Text & "','" & Me.Txt_date.Text & "','" & Me.txt_expire.Text & "','" & dtd & "','" & usr & "')"
                oh.ExecuteNonQuery(sql)
                Me.Lbl_msg.Text = "<font size=3><b>COMPENSATORY ADDED<b></font>"
                Me.Txt_comname.Text = ""
                Me.Txt_date.Text = ""
            End If
            fill()
        End If
       
    End Sub

    Protected Sub cmd_insert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_insert.Click
        Try

            Dim comp(1) As OracleParameter
            comp(0) = New OracleParameter("compid", OracleType.Int32)
            comp(0).Direction = ParameterDirection.Input
            comp(0).Value = Me.Cmb_compname.SelectedValue
            comp(1) = New OracleParameter("stateid", OracleType.Int32)
            comp(1).Direction = ParameterDirection.Input
            comp(1).Value = Me.Cmb_state.SelectedValue
            oh.ExecuteNonQuery("comp_insert", comp)
            Me.Lbl_msg.Text = "" & Me.Cmb_state.SelectedItem.Text & "<font size=3><b> ----- INSERTED<b></font>"
        Catch ex As Exception
            Me.Lbl_msg.Text = ex.Message
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("../home.aspx")
    End Sub
End Class
