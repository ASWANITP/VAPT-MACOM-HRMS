Imports System.Data
Imports System.Data.OracleClient

Partial Class EMPLOYEE_DISIPLINARY_ACTION_DISCLIPINE_cc6a94021107

    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler

    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    'Dim strResult As New System.Text.StringBuilder
    'Dim UserAll(), res, sql, str As String
    'Dim UserCode, BranchID, PostID, AreaID, RegionID, ZonalID, DepID, OpHead As Integer
    'Dim str_tkn As New System.Text.StringBuilder
    Dim result, b As String
    Dim str As New StringBuilder


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        Dim scr As String = "var header;header='" & Me.txt_empcode.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "header", scr, True)



        Dim cbreq As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "fromserver", "context", True)
        Dim cbres As String = "function toserver(arg,context){" & cbreq & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "toserver", cbres, True)




        If Not IsPostBack = True Then

            dt = oh.ExecuteDataSet("select -1 emp_code, '------select---------' emp_code from dual union all select distinct e.emp_code, e.emp_code || '-------' || e.emp_name  from designation_mst d, employee_master e where e.designation_id = 29   and e.status_id = 1   and e.designation_id = d.designation_id").Tables(0)
            Me.drpdwn_discpl_tkn_by.DataSource = dt
            Me.drpdwn_discpl_tkn_by.DataValueField = dt.Columns(0).ColumnName
            Me.drpdwn_discpl_tkn_by.DataTextField = dt.Columns(1).ColumnName
            Me.drpdwn_discpl_tkn_by.DataBind()
            Me.drpdwn_discpl_tkn_by.Focus()

            dt1 = oh.ExecuteDataSet("select -1 discipline_id, '------select---------' discipline_id  from dual union all select dm.discipline_id,       dm.discipline_id || '---- ' || dm.discipline_category  from discipline_master dm").Tables(0)
            Me.drpdwn_discpl_type.DataSource = dt1
            Me.drpdwn_discpl_type.DataValueField = dt1.Columns(0).ColumnName
            Me.drpdwn_discpl_type.DataTextField = dt1.Columns(1).ColumnName
            Me.drpdwn_discpl_type.DataBind()
            Me.drpdwn_discpl_type.Focus()

        End If

        Me.txt_empcode.Attributes.Add("onkeypress", "NumericCheck()")
        Me.txt_empcode.Attributes.Add("onchange", "txt_empcodeonchange()")

    End Sub

    Protected Sub btn_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_confirm.Click

        Try


            Dim parcol(8) As OracleParameter

            parcol(0) = New OracleParameter("empcde", OracleType.Number, 50)
            parcol(0).Value = Me.txt_empcode.Text
            parcol(0).Direction = ParameterDirection.Input





            parcol(1) = New OracleParameter("desg", OracleType.VarChar, 50)
            parcol(1).Value = Me.txt_designation.Text
            parcol(1).Direction = ParameterDirection.Input





            parcol(2) = New OracleParameter("dep", OracleType.VarChar, 50)
            parcol(2).Value = Me.txt_department.Text
            parcol(2).Direction = ParameterDirection.Input




            
            parcol(3) = New OracleParameter("brnm", OracleType.VarChar, 50)
            parcol(3).Value = Me.txt_branchname.Text
            parcol(3).Direction = ParameterDirection.Input



            parcol(4) = New OracleParameter("distkn", OracleType.Number, 50)
            parcol(4).Value = Me.drpdwn_discpl_tkn_by.SelectedValue
            parcol(4).Direction = ParameterDirection.Input




            parcol(5) = New OracleParameter("distyp", OracleType.Number, 50)
            parcol(5).Value = Me.drpdwn_discpl_type.SelectedValue
            parcol(5).Direction = ParameterDirection.Input


            parcol(6) = New OracleParameter("disfrm", OracleType.DateTime)
            parcol(6).Value = Me.txt_frmdate.Text
            parcol(6).Direction = ParameterDirection.Input



            parcol(7) = New OracleParameter("disto", OracleType.DateTime)
            parcol(7).Value = Me.txt_todate.Text
            parcol(7).Direction = ParameterDirection.Input



            parcol(8) = New OracleParameter("msg", OracleType.VarChar, 100)
            parcol(8).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("employee_discipline_action", parcol)




            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & parcol(8).Value & "');")
            cl_script1.Append(" window.open('discipline.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)



        Catch ex As Exception

        End Try
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult


        Return result

    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

        Dim data() As String = eventArgument.Split("#")


        Select Case (data(0))


            Case "1"
                b = "select distinct  e.emp_name||'$'||d.designation||'$'||dp.dep_name||'$'||b.BRANCH_NAME||'$'||e.emp_code||'$'||e.designation_id||'$'||e.department_id||'$'||e.BRANCH_ID  from department_mst  dp,       employee_master e,       designation_mst d,       branch_dtl_new  b where e.branch_id = b.BRANCH_ID   and e.designation_id = d.designation_id   and e.department_id = dp.dep_id   and e.status_id = 1   and e.emp_code=" & data(1) & ""
                dt2 = oh.ExecuteDataSet(b).Tables(0)
                str.Append(dt2.Rows(0)(0))
                str.Append("$")

                'Case "2"
                '    b = "select t.emp_name from employee_master t where t.emp_code= " & data(1) & ""
                '    dt2 = oh.ExecuteDataSet(b).Tables(0)
                '    str.Append(dt2.Rows(0)(0))
                '    str.Append("$")

                'Case "3"
                '    b = "select t.emp_name from employee_master t where t.emp_code= " & data(1) & ""
                '    dt = oh.ExecuteDataSet(b).Tables(0)
                '    str.Append(dt2.Rows(0)(0))
                '    str.Append("$")


        End Select

        result = str.ToString

    End Sub
End Class
