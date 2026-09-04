Imports System.Data
Imports System.Data.OracleClient
Partial Class Make_Employ_to_live_ffe0af696554
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim dr As DataRow
    Dim str, str1 As String
    Dim stat As Integer

    Dim res As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Cmb_res.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)

        Me.Cmb_res.Attributes.Add("onchange", "fill1()")
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "sub_call_receiver", "context")
        Dim cbscript As String = "function sub_call_server(arg,context) { " & cbref & "; } "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "sub_call_server", cbscript, True)

        If Not IsPostBack Then

            pageload()

        End If

    End Sub
    Sub pageload()
        Dim brid As Integer = Me.Session("branch_id")
        Dim fid As Integer = Session("firm_id").ToString
        Dim userid As String = Me.Session("user_id")
        Dim uid() As String = userid.Split("!")

        dt = oh.ExecuteDataSet("select emp_id from form_accessibility where emp_id=" & uid(0) & " and form_id=147").Tables(0)

        ' dt = oh.ExecuteDataSet("select access_id from employee_master where emp_code=" & uid(0) & " and post_id=85").Tables(0)

        Try


            If dt.Rows.Count = 1 Then
                '------------------------reqid-15654----
                str = "select 0 as srnumber,'Please Select ' from dual union select e.emp_code,e.emp_code||'---'||e.emp_name||' , '||'Resigned Date:'||to_char(m.discont_dt) from employee_master e,employee_master_dtl m,employ_firm ef where e.status_id in (3) and to_date(m.discont_dt)>=to_date('1/june/2009') and e.emp_code>9999 and e.emp_code=m.emp_code  and e.emp_code=ef.emp_code and m.discont_dt > to_date(sysdate-210) and ef.firm_id=" & fid & " and m.discont_dt is not null "
                '------------------------reqid-15654----

                dt = oh.ExecuteDataSet(str).Tables(0)
                Cmb_res.DataSource = dt
                Cmb_res.DataValueField = dt.Columns(0).ColumnName
                Cmb_res.DataTextField = dt.Columns(1).ColumnName
                Cmb_res.DataBind()


                Me.lbl_rec.Text = dt.Rows.Count - 1


            Else
                Dim cl_script5 As New StringBuilder
                cl_script5.Append("window.open('../show_err.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script5.ToString, True)
            End If
        Catch ex As Exception
            Dim cl_script5 As New StringBuilder
            cl_script5.Append("   alert('" & ex.ToString & " ') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script5.ToString, True)

        Finally
        End Try

    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim SrlNO As Integer = CInt(eventArgument)
        Dim cal_data = eventArgument
        Dim dis As Integer = cal_data
        Dim st As New StringBuilder
        Try

            '                     0              1          2               3                     4               5                                  6                                                                               7
            str1 = "select em.emp_code||'*'||em.emp_name||'*'||bm.branch_name||'*'||dm.designation||'*'||dp.dep_name||'*'||pm.post_name||'*'||nvl(ht.approval_person,0)||'*'||to_char(ht.discont_dt) from employee_resigtermi ht,employee_master em,before_completion bm,designation_master dm,department_mst dp,post_mst pm where ht.emp_code=em.emp_code and bm.old_id=em.branch_id and bm.branch_id is null and dm.designation_id=em.designation_id and dp.dep_id=em.department_id and pm.post_id=em.post_id and em.status_id=3 and em.emp_code=" & SrlNO & " union select em.emp_code||'*'||em.emp_name||'*'||bm.branch_name||'*'||dm.designation||'*'||dp.dep_name||'*'||pm.post_name||'*'||nvl(ht.approval_person,0)||'*'||to_char(ht.discont_dt) from employee_resigtermi ht,employee_master em,branch_master bm,designation_master dm,department_mst dp,post_mst pm where ht.emp_code=em.emp_code and bm.branch_id=em.branch_id and dm.designation_id=em.designation_id and dp.dep_id=em.department_id and pm.post_id=em.post_id and em.status_id=3 and em.emp_code=" & SrlNO & ""

            dt1 = oh.ExecuteDataSet(str1).Tables(0)

        Catch ex As Exception
        Finally

        End Try
        If dt1.Rows.Count > 0 Then

            st.Append(dt1.Rows(0)(0))
            st.Append("@")
            st.Append("!")
        Else
            st.Append("$")
            st.Append("@")
            st.Append("!")
        End If
        res = st.ToString
    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        Dim userid As String = Me.Session("user_id")
        Dim uid() As String = userid.Split("!")
        Dim ecode1 As Integer = uid(0)

        Try
            Dim para(2) As OracleParameter

            para(0) = New OracleParameter("empid", OracleType.Number, 8)
            para(0).Value = Me.Cmb_res.SelectedValue
            para(0).Direction = ParameterDirection.Input

            para(1) = New OracleParameter("cancelemp", OracleType.Number, 5)
            para(1).Value = ecode1
            para(1).Direction = ParameterDirection.Input

            para(2) = New OracleParameter("msg", OracleType.VarChar, 150)
            para(2).Direction = ParameterDirection.Output

            oh.ExecuteDataSet("live_the_employee", para)
            Dim message As String = para(2).Value

            Dim cl_script8 As New StringBuilder
            cl_script8.Append(" alert('" & message & " ');")
            cl_script8.Append("       window.open('Make_Employ_to_live.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script8.ToString, True)
        Catch ex As Exception
            Dim cl_script11 As New StringBuilder
            cl_script11.Append("   alert('" & ex.ToString & " ') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script11.ToString, True)

        Finally
        End Try
    End Sub

End Class
