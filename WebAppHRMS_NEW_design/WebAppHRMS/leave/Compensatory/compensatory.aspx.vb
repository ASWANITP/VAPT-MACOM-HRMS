Imports System.Data
Imports System.Data.OracleClient
Partial Class staffaccount_compensatory_030f17465140
    Inherits System.Web.UI.Page
    Dim str As String
    Dim dt, dt1, dt2, dt3, dt4, dt5, dt6, dt7 As New DataTable
    Dim oh As New helper.oracle.OracleHelper
    'Dim oh As New OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "ADD COMPENSATORY"
        If Not IsPostBack Then

            If Me.Session("access_id") = 33 Then


                Me.txt_dt.Text = Format(Date.Now, "dd/MMM/yyyy")
                dt = oh.ExecuteDataSet("SELECT add_months(to_date(TO_CHAR(TRUNC(current_date, 'YYYY'), 'DD-MON-YYYY')),12)-1 FROM dual").Tables(0)
                Me.txt_exdt.Text = Format(dt.Rows(0)(0), "dd/MMM/yyyy")
                str = "select -1,'-Select State-' as state_name from dual union all select cm.state_id,cm.state_name as dtl from state_master cm order by state_name"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Me.cmb_state.DataSource = dt
                Me.cmb_state.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_state.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_state.DataBind()
                dt1 = oh.ExecuteDataSet("select -1,'-Select district-' as district_name from dual union all select cm.district_id,cm.district_name as dtl from district_master cm order by district_name").Tables(0)
                Me.cmb_dist.DataSource = dt1
                Me.cmb_dist.DataTextField = dt1.Columns(1).ColumnName
                Me.cmb_dist.DataValueField = dt1.Columns(0).ColumnName
                Me.cmb_dist.DataBind()

                dt2 = oh.ExecuteDataSet("select -1,'-Select zone-' as zonal_name from dual union all select cm.zonal_id,cm.zonal_name as dtl from zonal_master cm order by zonal_name").Tables(0)
                Me.cmb_zone.DataSource = dt2
                Me.cmb_zone.DataTextField = dt2.Columns(1).ColumnName
                Me.cmb_zone.DataValueField = dt2.Columns(0).ColumnName
                Me.cmb_zone.DataBind()
                dt3 = oh.ExecuteDataSet("select -1,'-Select Area-' as area_name from dual union all select cm.area_id,cm.area_name as dtl from area_master cm order by area_name").Tables(0)
                Me.cmb_area.DataSource = dt3
                Me.cmb_area.DataTextField = dt3.Columns(1).ColumnName
                Me.cmb_area.DataValueField = dt3.Columns(0).ColumnName
                Me.cmb_area.DataBind()
                dt4 = oh.ExecuteDataSet("select -1,'-Select Region-' as reg_name from dual union all select cm.reg_id,cm.reg_name as dtl from region_master cm order by reg_name").Tables(0)
                Me.cmb_region.DataSource = dt4
                Me.cmb_region.DataTextField = dt4.Columns(1).ColumnName
                Me.cmb_region.DataValueField = dt4.Columns(0).ColumnName
                Me.cmb_region.DataBind()
                dt5 = oh.ExecuteDataSet("select -1,'-Select Branch-' as branch_name from dual union all select cm.branch_id,cm.branch_name as dtl from branch cm order by branch_name").Tables(0)
                Me.cmb_branch.DataSource = dt5
                Me.cmb_branch.DataTextField = dt5.Columns(1).ColumnName
                Me.cmb_branch.DataValueField = dt5.Columns(0).ColumnName
                Me.cmb_branch.DataBind()
                dt6 = oh.ExecuteDataSet("select -1,' -Select Employee- ' as emp_name from dual union all select cm.emp_code,cm.emp_code||'-'||cm.emp_name as dtl from employee_master cm where cm.status_id=1 and cm.shift_id not in (4,5) order by emp_name").Tables(0)
                Me.cmb_emp.DataSource = dt6
                Me.cmb_emp.DataTextField = dt6.Columns(1).ColumnName
                Me.cmb_emp.DataValueField = dt6.Columns(0).ColumnName
                Me.cmb_emp.DataBind()

                str = "select t.comp_id,t.comp_name from hrm_comp_mst t where t.status=0"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Me.cmb_comp.DataSource = dt
                Me.cmb_comp.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_comp.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_comp.DataBind()


                Me.chk_state.Attributes.Add("onclick", "chkstatus()")
                Me.chk_zone.Attributes.Add("onclick", "chkstatus()")
                Me.chk_region.Attributes.Add("onclick", "chkstatus()")
                Me.chk_emp.Attributes.Add("onclick", "chkstatus()")
                Me.chk_dist.Attributes.Add("onclick", "chkstatus()")
                Me.chk_branch.Attributes.Add("onclick", "chkstatus()")
                Me.chk_area.Attributes.Add("onclick", "chkstatus()")
                Me.chk_assigncomp.Attributes.Add("onclick", "chk_add()")
                Me.chk_addcomp.Attributes.Add("onclick", "chk_add1()")
            Else
                Me.Server.Transfer("../../show_err.aspx")

            End If

        End If
        Dim cs As String = "var cont_name;cont_name='" & Me.ListBox1.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
    End Sub
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click

        Dim usr = Me.Session("user_id").ToString.Split("!")
        Dim stat As Integer
        If Me.chk_state.Checked = True Then
            stat = 1
        End If
        If Me.chk_dist.Checked = True Then
            stat = 2

        End If
        If Me.chk_zone.Checked = True Then
            stat = 3

        End If
        If Me.chk_area.Checked = True Then
            stat = 4
        End If
        If Me.chk_region.Checked = True Then
            stat = 5
        End If
        If Me.chk_branch.Checked = True Then
            stat = 6
        End If
        If Me.chk_emp.Checked = True Then
            stat = 7
        End If
        Dim dt As DataTable = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
        If CDate(Me.txt_dt.Text) >= CDate(dt.Rows(0)(0)) Then


            Dim param(8) As OracleParameter

            param(0) = New OracleParameter("comdt", OracleType.DateTime)
            param(0).Direction = ParameterDirection.Input
            param(0).Value = CDate(Me.txt_dt.Text)

            param(1) = New OracleParameter("exdt", OracleType.DateTime)
            param(1).Direction = ParameterDirection.Input
            param(1).Value = CDate(Me.txt_exdt.Text)

            param(2) = New OracleParameter("comnm", OracleType.VarChar)
            param(2).Direction = ParameterDirection.Input
            param(2).Value = Me.cmb_comp.SelectedItem.Text

            param(3) = New OracleParameter("userid", OracleType.VarChar)
            param(3).Direction = ParameterDirection.Input
            param(3).Value = usr(0)

            param(4) = New OracleParameter("states", OracleType.VarChar, 5000)
            param(4).Direction = ParameterDirection.Input
            param(4).Value = Me.Hidden2.Value

            param(5) = New OracleParameter("com_id", OracleType.VarChar)
            param(5).Direction = ParameterDirection.Input
            param(5).Value = Me.cmb_comp.SelectedValue
            param(6) = New OracleParameter("status", OracleType.Number)
            param(6).Direction = ParameterDirection.Input
            param(6).Value = stat

            param(7) = New OracleParameter("err_stat", OracleType.Number)
            param(7).Direction = ParameterDirection.Output

            param(8) = New OracleParameter("err_msg", OracleType.VarChar, 100)
            param(8).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_compensatory_credit", param)

            If param(7).Value = 1 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('Successfully Inserted');")
                cl_script1.Append("         window.open('compensatory.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('Try Again');")
                cl_script1.Append("         window.open('compensatory.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If

        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Back Date entry is blocked');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub


        End If
    End Sub

   
    Protected Sub cmd_addc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_addc.Click
        If Me.Txt_compen.Text = "" Then

            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert(' Please Enter COMPENSATORY Name !');")
            ' cl_script0.Append("       window.open('compensatory_sanction.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
            Exit Sub
        Else
            Dim leave(2) As OracleParameter
            leave(0) = New OracleParameter("comnm", OracleType.VarChar, 5000)
            leave(0).Direction = ParameterDirection.Input
            leave(0).Value = Me.Txt_compen.Text
            leave(1) = New OracleParameter("msg", OracleType.VarChar, 100)
            leave(1).Direction = ParameterDirection.InputOutput
            leave(2) = New OracleParameter("flag", OracleType.Number)
            leave(2).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("hrm_comp_add", leave)
            If leave(2).Value = 1 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert(' " & leave(1).Value & " ');")


                cl_script0.Append("       window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
                'Server.Transfer("compensatory.aspx")
            Else
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert(' " & leave(1).Value & " ');")
                '   cl_script0.Append("       window.open('compensatory.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
                Server.Transfer("compensatory.aspx")
            End If

        End If

        


    End Sub
End Class
