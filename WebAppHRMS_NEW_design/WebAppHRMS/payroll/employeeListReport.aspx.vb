Imports System.Data
Imports System.Data.OracleClient
Partial Class employeeListReport_employeeListReport_b24d42606947
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
     
        If Not IsPostBack Then

            If (Me.chk_ar.Checked = False) Then

                Me.cmb_are.Visible = False
                Me.cmb_branch.Visible = True
                Me.cmb_area.Visible = True

                dt = oh.ExecuteDataSet("select distinct a.area_name,a.area_id from area_master a,branch b where a.area_id=b.area_id and b.firm_id=" & Session("firm_id") & " order by a.area_name ").Tables(0)
                Me.cmb_area.DataSource = dt
                Me.cmb_area.DataTextField = dt.Columns(0).ColumnName
                Me.cmb_area.DataValueField = dt.Columns(1).ColumnName
                Me.cmb_area.DataBind()
                dt = oh.ExecuteDataSet("select b.branch_name,b.branch_id from branch_master b,area_detail ad,area_master am where b.branch_id=ad.branch_id and b.firm_id=" & Session("firm_id") & " and ad.area_id=am.area_id and am.area_id=" & Me.cmb_area.SelectedValue & " ").Tables(0)
                Me.cmb_branch.DataSource = dt
                Me.cmb_branch.DataTextField = dt.Columns(0).ColumnName
                Me.cmb_branch.DataValueField = dt.Columns(1).ColumnName
                Me.cmb_branch.DataBind()
            End If

        Else
            Me.cmb_area.Visible = False
            Me.cmb_branch.Visible = False
            Me.cmb_are.Visible = True


        End If
    End Sub

    Protected Sub cmb_area_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_area.SelectedIndexChanged
        If (Me.chk_ar.Checked = False) Then
            Me.cmb_branch.Visible = True
            Me.cmb_are.Visible = False
            Me.cmb_area.Visible = True

            dt = oh.ExecuteDataSet("select b.branch_name,b.branch_id from branch_master b,area_detail ad,area_master am where b.branch_id=ad.branch_id and b.firm_id=" & Session("firm_id") & " and ad.area_id=am.area_id and am.area_id=" & Me.cmb_area.SelectedValue & " ").Tables(0)
            Me.cmb_branch.DataSource = dt
            Me.cmb_branch.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_branch.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_branch.DataBind()
        Else
            Me.cmb_branch.Visible = False
            Me.cmb_are.Visible = True
            Me.cmb_area.Visible = False
            dt = oh.ExecuteDataSet("select distinct a.area_name,a.area_id from area_master a,branch b where a.area_id=b.area_id and b.firm_id=" & Session("firm_id") & " order by a.area_name ").Tables(0)
            Me.cmb_are.DataSource = dt
            Me.cmb_are.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_are.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_are.DataBind()
        End If
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click



        Dim sql As String

        If (Me.chk_ar.Checked = False) Then

            sql = "select b.branch_name,  a.emp_code,  a.emp_name,  to_char(to_date(a.join_dt)) as join_date,  decode(a.emp_type, 1, 'REGULAR', 2, 'OUTSOURCE', 'TRAINEE') as type,  f.firm_abbr,  ds.designation,  d.dep_name,  p.post_name,  case  when ep.sex = 1 then  'MALE'  else  'FEMALE'  end,  dm.district_name  from employee_master     a,  employ_firm ef,  firm_master         f,  department_mst      d,  designation_master  ds,  branch_master       b,  post_mst            p,  employ_personal_dtl ep,  post_master         pm,  district_master     dm  where a.emp_code=ef.emp_code  and ef.firm_id=" & Session("firm_id") & "  and ef.firm_id=f.firm_id  and a.designation_id = ds.designation_id  and a.department_id = d.dep_id  and a.post_id = p.post_id  and a.branch_id = b.branch_id  and b.branch_id = " & Me.cmb_branch.SelectedValue & "  and a.status_id = 1  and a.emp_code = ep.emp_code  and ep.pres_pin = pm.sr_number  and b.district_id = dm.district_id  union  select b.branch_name,  a.emp_code,  a.emp_name,  to_char(to_date(a.join_dt)) as join_date,  decode(a.emp_type, 1, 'REGULAR', 2, 'OUTSOURCE', 'TRAINEE') as type,  f.firm_abbr,  ds.designation,  d.dep_name,  p.post_name,  case  when ep.sex = 1 then  'MALE'  else  'FEMALE'  end,  dm.district_name  from employee_master     a,  employ_firm ef , firm_master         f,  department_mst      d,  designation_master  ds,  before_completion   b,  post_mst            p,  employ_personal_dtl ep,  post_master         pm,  district_master     dm  where a.emp_code=ef.emp_code  and ef.firm_id=" & Session("firm_id") & "  and ef.firm_id=f.firm_id  and a.designation_id = ds.designation_id  and a.department_id = d.dep_id  and a.post_id = p.post_id  and a.branch_id = b.old_id  and b.branch_id is null  and b.old_id = " & Me.cmb_branch.SelectedValue & "  and a.status_id = 1  and a.emp_code = ep.emp_code  and ep.pres_pin = pm.sr_number  and b.district_id = dm.district_id"
            If (Me.cmb_branch.SelectedValue >= 0) Then
                dt1 = oh.ExecuteDataSet("select count(ep.sex)  from employee_master     a,  employ_firm ef,  firm_master         f,  department_mst      d,  designation_master  ds,  branch_master       b,  post_mst            p,  employ_personal_dtl ep,  post_master         pm,  district_master     dm  where a.emp_code=ef.emp_code  and ef.firm_id=f.firm_id  and ef.firm_id=" & Session("firm_id") & "  and a.designation_id = ds.designation_id  and a.department_id = d.dep_id  and a.post_id = p.post_id  and a.branch_id = b.branch_id  and b.branch_id = " & Me.cmb_branch.SelectedValue & "  and a.status_id = 1  and a.emp_code = ep.emp_code  and ep.pres_pin = pm.sr_number  and b.district_id = dm.district_id and ep.sex = 0").Tables(0)
                dt2 = oh.ExecuteDataSet("select count(ep.sex) from employee_master a,employ_firm ef,firm_master f,department_mst d,designation_master ds,branch_master b,post_mst p,employ_personal_dtl ep,post_master pm,district_master dm where a.emp_code=ef.emp_code  and ef.firm_id=f.firm_id  and ef.firm_id=" & Session("firm_id") & "  and a.designation_id=ds.designation_id and a.department_id=d.dep_id and a.post_id=p.post_id and a.branch_id=b.branch_id and b.branch_id=" & Me.cmb_branch.SelectedValue & " and a.status_id=1 and a.emp_code=ep.emp_code and ep.pres_pin=pm.sr_number and b.district_id=dm.district_id and ep.sex=1  ").Tables(0)
            Else
                dt1 = oh.ExecuteDataSet("select count(ep.sex) from employee_master a,employ_firm ef,firm_master f,department_mst d,designation_master ds,before_completion b,post_mst p,employ_personal_dtl ep,post_master pm,district_master dm where a.emp_code=ef.emp_code  and ef.firm_id=f.firm_id  and ef.firm_id=" & Session("firm_id") & "  and a.designation_id=ds.designation_id and a.department_id=d.dep_id and a.post_id=p.post_id and a.branch_id=b.old_id and b.branch_id is null and b.old_id=" & Me.cmb_branch.SelectedValue & " and a.status_id=1 and a.emp_code=ep.emp_code and ep.pres_pin=pm.sr_number and b.district_id=dm.district_id and ep.sex=0 ").Tables(0)
                dt2 = oh.ExecuteDataSet("select count(ep.sex) from employee_master a,employ_firm ef,firm_master f,department_mst d,designation_master ds,before_completion b,post_mst p,employ_personal_dtl ep,post_master pm,district_master dm where a.emp_code=ef.emp_code  and ef.firm_id=f.firm_id  and ef.firm_id=" & Session("firm_id") & "  and a.designation_id=ds.designation_id and a.department_id=d.dep_id and a.post_id=p.post_id and a.branch_id=b.old_id and b.branch_id is null and b.old_id=" & Me.cmb_branch.SelectedValue & " and a.status_id=1 and a.emp_code=ep.emp_code and ep.pres_pin=pm.sr_number and b.district_id=dm.district_id and ep.sex=1 ").Tables(0)
            End If

            
            Server.Transfer("employ_area_branch_display.aspx?sql=" & sql & "&br=" & Me.cmb_branch.SelectedItem.Text & "&male=" & dt2.Rows(0)(0) & "&fema=" & dt1.Rows(0)(0) & "")
        Else
            'sql = " select b.branch_name,a.emp_code,a.emp_name,to_char(to_date(a.join_dt)) as join_date,decode(a.emp_type,1,'REGULAR',2,'OUTSOURCE','TRAINEE') as type,f.firm_abbr,ds.designation,d.dep_name,p.post_name,case when ep.sex=1 then 'MALE' else 'FEMALE' end as sex,dm.district_name from employee_master a,firm_master f,department_mst d,designation_master ds,branch_master b,post_mst p,employ_personal_dtl ep,post_master pm,district_master dm,area_master am,area_detail ad where a.firm_id=f.firm_id and a.designation_id=ds.designation_id and a.department_id=d.dep_id and a.post_id=p.post_id and a.branch_id=b.branch_id and a.status_id=1 and a.emp_code=ep.emp_code and ep.pres_pin=pm.sr_number and b.district_id=dm.district_id and ad.branch_id=a.branch_id and ad.area_id=" & Me.cmb_are.SelectedValue & " group by b.branch_name,a.emp_code,a.emp_name,a.join_dt,a.emp_type,f.firm_abbr,ds.designation,d.dep_name,p.post_name,ep.sex,dm.district_name order by a.join_dt"
            dt1 = oh.ExecuteDataSet("select count(ep.sex) from employee_master a,firm_master f,department_mst d,designation_master ds,branch_master b,post_mst p,employ_personal_dtl ep,post_master pm,district_master dm where a.firm_id=f.firm_id and a.designation_id=ds.designation_id and a.department_id=d.dep_id and a.post_id=p.post_id and a.branch_id=b.branch_id and b.branch_id=" & Me.cmb_branch.SelectedValue & " and a.status_id=1 and a.emp_code=ep.emp_code and ep.pres_pin=pm.sr_number and b.district_id=dm.district_id and ep.sex=0 order by a.join_dt").Tables(0)
            dt2 = oh.ExecuteDataSet("select count(ep.sex) from employee_master a,firm_master f,department_mst d,designation_master ds,branch_master b,post_mst p,employ_personal_dtl ep,post_master pm,district_master dm where a.firm_id=f.firm_id and a.designation_id=ds.designation_id and a.department_id=d.dep_id and a.post_id=p.post_id and a.branch_id=b.branch_id and b.branch_id=" & Me.cmb_branch.SelectedValue & " and a.status_id=1 and a.emp_code=ep.emp_code and ep.pres_pin=pm.sr_number and b.district_id=dm.district_id and ep.sex=1 order by a.join_dt").Tables(0)
            Me.Server.Transfer("emp_area_branch.aspx?&ar=" & Me.cmb_are.SelectedValue & "&area=" & Me.cmb_are.SelectedItem.Text & "")

        End If
    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Server.Transfer("../home.aspx")
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_ar.CheckedChanged
        If (Me.chk_ar.Checked = True) Then
            Me.cmb_are.Visible = True
            Me.cmb_branch.Visible = False
            Me.cmb_area.Visible = False

            dt = oh.ExecuteDataSet("select area_name,area_id from area_master order by area_name ").Tables(0)
            Me.cmb_are.DataSource = dt
            Me.cmb_are.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_are.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_are.DataBind()
        Else

            Me.cmb_are.Visible = False
            Me.cmb_branch.Visible = True
            Me.cmb_area.Visible = True
        End If
    End Sub
End Class
