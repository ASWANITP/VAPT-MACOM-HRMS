Imports System.Data
Imports System.Data.OracleClient
Partial Class emp_current_ver_2_emp_current_report_65a7201d7721
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim total As Integer = 0
    Dim exptotal As Double = 0.0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.Request.QueryString("depid") = 0 Then   ' All Departments

            If Me.Request.QueryString("status") = 0 Then
                '                   0                     1          2           3              4          5           6           7                                    8         9              10           11                     12            13                    14                  15                 16                     17                                     18           19                                                                                20                                                    
                str = "select bd.zonal_name as aa,bd.REG_NAME,bd.DIV_NAME,bd.AREA_NAME,bd.BRANCH_NAME,ec.emp_code,ec.emp_name,nvl(ec.contact_no,0)as Contact_No,ec.designation,ec.department,ec.post,ec.join_dt as D_O_J,ec.qualification,nvl(ec.age,0)as Age,nvl(ec.exp_day,0)as Exp_days,ec.emp_type,ec.discont_dt as Disc_Date,decode(ec.old_empcode,'',0,ec.old_empcode),ec.gender,ec.marital,ep.birth_date as DOB,stm.state_name from branch_detail bd,employee_current ec,employ_personal_dtl ep,post_master pm,district_master dis,state_master stm where ec.branch_id=bd.BRANCH_ID and ec.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=dis.district_id and dis.state_id=stm.state_id and ec.status_id not in(3,5) union select zm.zonal_name as aa,rm.reg_name,dm.div_name,am.area_name,bc.branch_name,ec.emp_code,ec.emp_name,nvl(ec.contact_no,0)as Contact_No,ec.designation,ec.department,ec.post,ec.join_dt as D_O_J,ec.qualification,nvl(ec.age,0)as Age,nvl(ec.exp_day,0)as Exp_days,ec.emp_type,ec.discont_dt as Disc_Date,decode(ec.old_empcode,'',0,ec.old_empcode),ec.gender,ec.marital,ep.birth_date as DOB,stm.state_name from employee_current ec,employ_personal_dtl ep,post_master pm,district_master dis,state_master stm,before_completion bc,area_master am,division_detail dd,division_master dm,region_detail rd,region_master rm,zonal_detail zd,zonal_master zm where ec.branch_id=bc.old_id and ec.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=dis.district_id and dis.state_id=stm.state_id and bc.branch_id is null and ec.branch_id<0 and bc.area_id=am.area_id and am.area_id=dd.area_id and dd.div_id=dm.division_id and dm.division_id=rd.division_id and rd.region_id=rm.reg_id and rm.reg_id=zd.region_id and zm.zonal_id=zd.zonal_id and ec.status_id not in(3,5) order by aa,emp_code "

            ElseIf Me.Request.QueryString("status") = 5 Then

                str = "select bd.zonal_name as aa,bd.REG_NAME,bd.DIV_NAME,bd.AREA_NAME,bd.BRANCH_NAME,ec.emp_code,ec.emp_name,nvl(ec.contact_no,0)as Contact_No,ec.designation,ec.department,ec.post,ec.join_dt as D_O_J,ec.qualification,nvl(ec.age,0)as Age,nvl(ec.exp_day,0)as Exp_days,ec.emp_type,ec.discont_dt as Disc_Date,decode(ec.old_empcode,'',0,ec.old_empcode),ec.gender,ec.marital,ep.birth_date as DOB,stm.state_name from branch_detail bd,employee_current ec,employ_personal_dtl ep,post_master pm,district_master dis,state_master stm,employee_master_dtl ed where ec.emp_code=ed.emp_code and ed.NEW_EMPCODE is null and ec.branch_id=bd.BRANCH_ID and ec.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=dis.district_id and dis.state_id=stm.state_id and ec.status_id=5 union select zm.zonal_name as aa,rm.reg_name,dm.div_name,am.area_name,bc.branch_name,ec.emp_code,ec.emp_name,nvl(ec.contact_no,0)as Contact_No,ec.designation,ec.department,ec.post,ec.join_dt as D_O_J,ec.qualification,nvl(ec.age,0)as Age,nvl(ec.exp_day,0)as Exp_days,ec.emp_type,ec.discont_dt as Disc_Date,decode(ec.old_empcode,'',0,ec.old_empcode),ec.gender,ec.marital,ep.birth_date as DOB,stm.state_name from employee_current ec,employ_personal_dtl ep,post_master pm,district_master dis,state_master stm,before_completion bc,area_master am,division_detail dd,division_master dm,region_detail rd,region_master rm,zonal_detail zd,zonal_master zm,employee_master_dtl ed where ec.emp_code=ed.emp_code and ed.NEW_EMPCODE is null and ec.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=dis.district_id and dis.state_id=stm.state_id and ec.branch_id=bc.old_id and bc.branch_id is null and ec.branch_id<0 and bc.area_id=am.area_id and am.area_id=dd.area_id and dd.div_id=dm.division_id and dm.division_id=rd.division_id and rd.region_id=rm.reg_id and rm.reg_id=zd.region_id and zm.zonal_id=zd.zonal_id and ec.status_id=5 order by aa,emp_code "
            Else
                str = "select bd.zonal_name as aa,bd.REG_NAME,bd.DIV_NAME,bd.AREA_NAME,bd.BRANCH_NAME,ec.emp_code,ec.emp_name,nvl(ec.contact_no,0)as Contact_No,ec.designation,ec.department,ec.post,ec.join_dt as D_O_J,ec.qualification,nvl(ec.age,0)as Age,nvl(ec.exp_day,0)as Exp_days,ec.emp_type,ec.discont_dt as Disc_Date,decode(ec.old_empcode,'',0,ec.old_empcode),ec.gender,ec.marital,ep.birth_date as DOB,stm.state_name from branch_detail bd,employee_current ec,employ_personal_dtl ep,post_master pm,district_master dis,state_master stm where ec.branch_id=bd.BRANCH_ID and ec.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=dis.district_id and dis.state_id=stm.state_id and ec.status_id=" & Me.Request.QueryString("status") & " union select zm.zonal_name as aa,rm.reg_name,dm.div_name,am.area_name,bc.branch_name,ec.emp_code,ec.emp_name,nvl(ec.contact_no,0)as Contact_No,ec.designation,ec.department,ec.post,ec.join_dt as D_O_J,ec.qualification,nvl(ec.age,0)as Age,nvl(ec.exp_day,0)as Exp_days,ec.emp_type,ec.discont_dt as Disc_Date,decode(ec.old_empcode,'',0,ec.old_empcode),ec.gender,ec.marital,ep.birth_date as DOB,stm.state_name from employee_current ec,employ_personal_dtl ep,post_master pm,district_master dis,state_master stm,before_completion bc,area_master am,division_detail dd,division_master dm,region_detail rd,region_master rm,zonal_detail zd,zonal_master zm where ec.branch_id=bc.old_id and ec.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=dis.district_id and dis.state_id=stm.state_id and bc.branch_id is null and ec.branch_id<0 and bc.area_id=am.area_id and am.area_id=dd.area_id and dd.div_id=dm.division_id and dm.division_id=rd.division_id and rd.region_id=rm.reg_id and rm.reg_id=zd.region_id and zm.zonal_id=zd.zonal_id and ec.status_id=" & Me.Request.QueryString("status") & " order by aa,emp_code "

            End If
        ElseIf Me.Request.QueryString("depid") <> 0 Then  '  for depid<>0

            If Me.Request.QueryString("status") = 0 Then
                '                   0                     1          2           3              4          5           6           7                                    8         9              10           11                           12            13                        14              15                    16                     17          18                19                                                                    20                                                    
                str = "select bd.zonal_name as aa,bd.REG_NAME,bd.DIV_NAME,bd.AREA_NAME,bd.BRANCH_NAME,ec.emp_code,ec.emp_name,nvl(ec.contact_no,0)as Contact_No,ec.designation,ec.department,ec.post,ec.join_dt as D_O_J,ec.qualification,nvl(ec.age,0)as Age,nvl(ec.exp_day,0)as Exp_days,ec.emp_type,ec.discont_dt as Disc_Date,decode(ec.old_empcode,'',0,ec.old_empcode),ec.gender,ec.marital,ep.birth_date as DOB,stm.state_name from branch_detail bd,employee_current ec,employ_personal_dtl ep,post_master pm,district_master dis,state_master stm where ec.branch_id=bd.BRANCH_ID and ec.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=dis.district_id and dis.state_id=stm.state_id and ec.status_id not in(3,5) and ec.department_id=" & Me.Request.QueryString("depid") & " union select zm.zonal_name as aa,rm.reg_name,dm.div_name,am.area_name,bc.branch_name,ec.emp_code,ec.emp_name,nvl(ec.contact_no,0)as Contact_No,ec.designation,ec.department,ec.post,ec.join_dt as D_O_J,ec.qualification,nvl(ec.age,0)as Age,nvl(ec.exp_day,0)as Exp_days,ec.emp_type,ec.discont_dt as Disc_Date,decode(ec.old_empcode,'',0,ec.old_empcode),ec.gender,ec.marital,ep.birth_date as DOB,stm.state_name from employee_current ec,employ_personal_dtl ep,post_master pm,district_master dis,state_master stm,before_completion bc,area_master am,division_detail dd,division_master dm,region_detail rd,region_master rm,zonal_detail zd,zonal_master zm where ec.branch_id=bc.old_id and ec.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=dis.district_id and dis.state_id=stm.state_id and bc.branch_id is null and ec.branch_id<0 and bc.area_id=am.area_id and am.area_id=dd.area_id and dd.div_id=dm.division_id and dm.division_id=rd.division_id and rd.region_id=rm.reg_id and rm.reg_id=zd.region_id and zm.zonal_id=zd.zonal_id and ec.status_id not in(3,5) and ec.department_id=" & Me.Request.QueryString("depid") & " order by aa,emp_code "

            ElseIf Me.Request.QueryString("status") = 5 Then

                str = "select bd.zonal_name as aa,bd.REG_NAME,bd.DIV_NAME,bd.AREA_NAME,bd.BRANCH_NAME,ec.emp_code,ec.emp_name,nvl(ec.contact_no,0)as Contact_No,ec.designation,ec.department,ec.post,ec.join_dt as D_O_J,ec.qualification,nvl(ec.age,0)as Age,nvl(ec.exp_day,0)as Exp_days,ec.emp_type,ec.discont_dt as Disc_Date,decode(ec.old_empcode,'',0,ec.old_empcode),ec.gender,ec.marital,ep.birth_date as DOB,stm.state_name from branch_detail bd,employee_current ec,employ_personal_dtl ep,post_master pm,district_master dis,state_master stm,employee_master_dtl ed where ec.emp_code=ed.emp_code and ed.NEW_EMPCODE is null and ec.branch_id=bd.BRANCH_ID and ec.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=dis.district_id and dis.state_id=stm.state_id and ec.status_id=5 and ec.department_id=" & Me.Request.QueryString("depid") & " union select zm.zonal_name as aa,rm.reg_name,dm.div_name,am.area_name,bc.branch_name,ec.emp_code,ec.emp_name,nvl(ec.contact_no,0)as Contact_No,ec.designation,ec.department,ec.post,ec.join_dt as D_O_J,ec.qualification,nvl(ec.age,0)as Age,nvl(ec.exp_day,0)as Exp_days,ec.emp_type,ec.discont_dt as Disc_Date,decode(ec.old_empcode,'',0,ec.old_empcode),ec.gender,ec.marital,ep.birth_date as DOB,stm.state_name from employee_current ec,employ_personal_dtl ep,post_master pm,district_master dis,state_master stm,before_completion bc,area_master am,division_detail dd,division_master dm,region_detail rd,region_master rm,zonal_detail zd,zonal_master zm,employee_master_dtl ed where ec.emp_code=ed.emp_code and ed.NEW_EMPCODE is null and ec.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=dis.district_id and dis.state_id=stm.state_id and ec.branch_id=bc.old_id and bc.branch_id is null and ec.branch_id<0 and bc.area_id=am.area_id and am.area_id=dd.area_id and dd.div_id=dm.division_id and dm.division_id=rd.division_id and rd.region_id=rm.reg_id and rm.reg_id=zd.region_id and zm.zonal_id=zd.zonal_id and ec.status_id=5 and ec.department_id=" & Me.Request.QueryString("depid") & " order by aa,emp_code "
            Else
                str = "select bd.zonal_name as aa,bd.REG_NAME,bd.DIV_NAME,bd.AREA_NAME,bd.BRANCH_NAME,ec.emp_code,ec.emp_name,nvl(ec.contact_no,0)as Contact_No,ec.designation,ec.department,ec.post,ec.join_dt as D_O_J,ec.qualification,nvl(ec.age,0)as Age,nvl(ec.exp_day,0)as Exp_days,ec.emp_type,ec.discont_dt as Disc_Date,decode(ec.old_empcode,'',0,ec.old_empcode),ec.gender,ec.marital,ep.birth_date as DOB,stm.state_name from branch_detail bd,employee_current ec,employ_personal_dtl ep,post_master pm,district_master dis,state_master stm where ec.branch_id=bd.BRANCH_ID and ec.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=dis.district_id and dis.state_id=stm.state_id and ec.status_id=" & Me.Request.QueryString("status") & " and ec.department_id=" & Me.Request.QueryString("depid") & " union select zm.zonal_name as aa,rm.reg_name,dm.div_name,am.area_name,bc.branch_name,ec.emp_code,ec.emp_name,nvl(ec.contact_no,0)as Contact_No,ec.designation,ec.department,ec.post,ec.join_dt as D_O_J,ec.qualification,nvl(ec.age,0)as Age,nvl(ec.exp_day,0)as Exp_days,ec.emp_type,ec.discont_dt as Disc_Date,decode(ec.old_empcode,'',0,ec.old_empcode),ec.gender,ec.marital,ep.birth_date as DOB,stm.state_name from employee_current ec,employ_personal_dtl ep,post_master pm,district_master dis,state_master stm,before_completion bc,area_master am,division_detail dd,division_master dm,region_detail rd,region_master rm,zonal_detail zd,zonal_master zm where ec.branch_id=bc.old_id and ec.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=dis.district_id and dis.state_id=stm.state_id and bc.branch_id is null and ec.branch_id<0 and bc.area_id=am.area_id and am.area_id=dd.area_id and dd.div_id=dm.division_id and dm.division_id=rd.division_id and rd.region_id=rm.reg_id and rm.reg_id=zd.region_id and zm.zonal_id=zd.zonal_id and ec.status_id=" & Me.Request.QueryString("status") & " and ec.department_id=" & Me.Request.QueryString("depid") & " order by aa,emp_code "

            End If

        End If

        dt = oh.ExecuteDataSet(str).Tables(0)


        Dim empcurtable As New Table
        empcurtable.Width = 22
        empcurtable.Attributes.Add("width", "100%")

        If dt.Rows.Count > 0 Then

            Dim header As New TableRow
            header.Width = 22
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            Dim headcell As New TableCell
            headcell.ColumnSpan = 22
            headcell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
            headcell.HorizontalAlign = HorizontalAlign.Center
            header.Controls.Add(headcell)
            empcurtable.Controls.Add(header)

            Dim sheader As New TableRow
            sheader.Width = 22
            Dim sheadercell1 As New TableCell
            sheadercell1.ColumnSpan = 22
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
            sheader.Controls.Add(sheadercell1)
            empcurtable.Controls.Add(sheader)


            Dim subh As New TableRow
            Dim subcell1 As New TableCell
            Dim subcell2 As New TableCell
            Dim subcell3 As New TableCell
            subh.Width = 22
            subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
            subcell1.ColumnSpan = 3
            subcell1.HorizontalAlign = HorizontalAlign.Left
            subh.Controls.Add(subcell1)

            subcell2.ColumnSpan = 16
            subcell2.HorizontalAlign = HorizontalAlign.Center
            subcell2.Text = " "
            subh.Controls.Add(subcell2)

            subcell3.ColumnSpan = 3
            subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
            subcell3.HorizontalAlign = HorizontalAlign.Center
            subh.Controls.Add(subcell3)

            empcurtable.Controls.Add(subh)

            Dim pheader As New TableRow
            Dim pheadercell As New TableCell
            pheader.Width = 22
            pheadercell.ColumnSpan = 22
            pheadercell.HorizontalAlign = HorizontalAlign.Center


            If Me.Request.QueryString("status") = 0 Then
                pheadercell.Text = "<body align=center ><b><font size=3>List of All&nbsp;(&nbsp;Except Resigned and Terminated&nbsp;)&nbsp;employees</font></b>"
            ElseIf Me.Request.QueryString("status") = 1 Then
                pheadercell.Text = "<body align=center ><b><font size=3>List of Normal employees</font></b>"
            ElseIf Me.Request.QueryString("status") = 3 Then
                pheadercell.Text = "<body align=center ><b><font size=3>List of Resigned employees</font></b>"
            ElseIf Me.Request.QueryString("status") = 4 Then
                pheadercell.Text = "<body align=center ><b><font size=3>List of Suspended employees</font></b>"
            ElseIf Me.Request.QueryString("status") = 6 Then
                pheadercell.Text = "<body align=center ><b><font size=3>List of employees in Long Leave</font></b>"
            ElseIf Me.Request.QueryString("status") = 10 Then
                pheadercell.Text = "<body align=center ><b><font size=3>List of employees in Maternity Leave</font></b>"
            ElseIf Me.Request.QueryString("status") = 5 Then
                pheadercell.Text = "<body align=center ><b><font size=3>List of Terminated employees</font></b>"

            End If
            pheader.Controls.Add(pheadercell)
            empcurtable.Controls.Add(pheader)



            Dim line1 As New TableRow
            Dim linecell1 As New TableCell
            line1.Width = 22
            linecell1.ColumnSpan = 22
            linecell1.Text = "<hr>"
            line1.Controls.Add(linecell1)
            empcurtable.Controls.Add(line1)





            Dim field As New TableRow
            field.Width = 25
            Dim f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, f17, f18, f19, f20, f21, f22 As New TableCell

            f1.ColumnSpan = 1
            f1.HorizontalAlign = HorizontalAlign.Left
            f1.Text = "<b><font size=2>Zone</font></b>"
            field.Controls.Add(f1)


            f2.ColumnSpan = 1
            f2.HorizontalAlign = HorizontalAlign.Left
            f2.Text = "<b><font size=2>Region</font></b>"
            field.Controls.Add(f2)

            f3.ColumnSpan = 1
            f3.HorizontalAlign = HorizontalAlign.Left
            f3.Text = "<b><font size=2>Division</font></b>"
            field.Controls.Add(f3)

            f4.ColumnSpan = 1
            f4.HorizontalAlign = HorizontalAlign.Left
            f4.Text = "<b><font size=2>Area</font></b>"
            field.Controls.Add(f4)

            f5.ColumnSpan = 1
            f5.HorizontalAlign = HorizontalAlign.Left
            f5.Text = "<b><font size=2>Branch</font></b>"
            field.Controls.Add(f5)

            f14.ColumnSpan = 1
            f14.HorizontalAlign = HorizontalAlign.Left
            f14.Text = "<b><font size=2>Emp Code</font></b>"
            field.Controls.Add(f14)

            f15.ColumnSpan = 1
            f15.HorizontalAlign = HorizontalAlign.Left
            f15.Text = "<b><font size=2>Emp Name</font></b>"
            field.Controls.Add(f15)


            f18.ColumnSpan = 1
            f18.HorizontalAlign = HorizontalAlign.Left
            f18.Text = "<b><font size=2>Cont.No</font></b>"
            field.Controls.Add(f18)

            f19.ColumnSpan = 1
            f19.HorizontalAlign = HorizontalAlign.Left
            f19.Text = "<b><font size=2>Desig.</font></b>"
            field.Controls.Add(f19)

            f20.ColumnSpan = 1
            f20.HorizontalAlign = HorizontalAlign.Left
            f20.Text = "<b><font size=2>Dept.</font></b>"
            field.Controls.Add(f20)

            f6.ColumnSpan = 1
            f6.HorizontalAlign = HorizontalAlign.Left
            f6.Text = "<b><font size=2>Post</font></b>"
            field.Controls.Add(f6)

            f7.ColumnSpan = 1
            f7.HorizontalAlign = HorizontalAlign.Left
            f7.Text = "<b><font size=2>D.O.J</font></b>"
            field.Controls.Add(f7)


            f8.ColumnSpan = 1
            f8.HorizontalAlign = HorizontalAlign.Left
            f8.Text = "<b><font size=2>Qualif.n</font></b>"
            field.Controls.Add(f8)


            f9.ColumnSpan = 1
            f9.HorizontalAlign = HorizontalAlign.Left
            f9.Text = "<b><font size=2>Age</font></b>"
            field.Controls.Add(f9)

            f10.ColumnSpan = 1
            f10.HorizontalAlign = HorizontalAlign.Left
            f10.Text = "<b><font size=2>Exp. Days</font></b>"
            field.Controls.Add(f10)


            f11.ColumnSpan = 1
            f11.HorizontalAlign = HorizontalAlign.Left
            f11.Text = "<b><font size=2>Emp Type</font></b>"
            field.Controls.Add(f11)


            f12.ColumnSpan = 1
            f12.HorizontalAlign = HorizontalAlign.Left
            f12.Text = "<b><font size=2>Discont Dt</font></b>"
            field.Controls.Add(f12)


            f13.ColumnSpan = 1
            f13.HorizontalAlign = HorizontalAlign.Left
            f13.Text = "<b><font size=2>Old EmCode</font></b>"
            field.Controls.Add(f13)

            f21.ColumnSpan = 1
            f21.HorizontalAlign = HorizontalAlign.Left
            f21.Text = "<b><font size=2>Gender</font></b>"
            field.Controls.Add(f21)

            f17.ColumnSpan = 1
            f17.HorizontalAlign = HorizontalAlign.Left
            f17.Text = "<b><font size=2>Martial Status</font></b>"
            field.Controls.Add(f17)

            f22.ColumnSpan = 1
            f22.HorizontalAlign = HorizontalAlign.Left
            f22.Text = "<b><font size=2>Date&nbsp;Of&nbsp;Birth</font></b>"
            field.Controls.Add(f22)

            f16.ColumnSpan = 1
            f16.HorizontalAlign = HorizontalAlign.Left
            f16.Text = "<b><font size=2>Native&nbsp;District</font></b>"
            field.Controls.Add(f16)


            empcurtable.Controls.Add(field)

            Dim linek As New TableRow
            Dim linecellk As New TableCell
            linek.Width = 22
            linecellk.ColumnSpan = 22
            linecellk.Text = "<hr>"
            linek.Controls.Add(linecellk)
            empcurtable.Controls.Add(linek)

            For Each dr In dt.Rows

                total += 1

                Dim val As New TableRow
                val.Width = 22
                Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24 As New TableCell

                v14.ColumnSpan = 1
                v14.HorizontalAlign = HorizontalAlign.Left
                v14.Text = "<font size=2>" & dr(0) & "&nbsp;</font>"
                val.Controls.Add(v14)

                v15.ColumnSpan = 1
                v15.HorizontalAlign = HorizontalAlign.Left
                v15.Text = "<font size=2>" & dr(1) & "&nbsp;</font>"
                val.Controls.Add(v15)

                v16.ColumnSpan = 1
                v16.HorizontalAlign = HorizontalAlign.Left
                v16.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
                val.Controls.Add(v16)

                v17.ColumnSpan = 1
                v17.HorizontalAlign = HorizontalAlign.Left
                v17.Text = "<font size=2>" & dr(3) & "&nbsp;</font>"
                val.Controls.Add(v17)

                v18.ColumnSpan = 1
                v18.HorizontalAlign = HorizontalAlign.Left
                v18.Text = "<font size=2>" & dr(4) & "&nbsp;</font>"
                val.Controls.Add(v18)


                'Code
                v1.ColumnSpan = 1
                v1.HorizontalAlign = HorizontalAlign.Left
                v1.Text = "<font size=2>" & dr(5) & "&nbsp;</font>"
                val.Controls.Add(v1)


                'name
                v2.ColumnSpan = 1
                v2.HorizontalAlign = HorizontalAlign.Left
                v2.Text = "<font size=2>" & dr(6) & "&nbsp;</font>"
                val.Controls.Add(v2)

                'cont no
                v3.ColumnSpan = 1
                v3.HorizontalAlign = HorizontalAlign.Left
                If IsDBNull(dr(2)) Then
                    v3.Text = "<font size=2>----</font>"
                Else
                    v3.Text = "<font size=2>" & dr(7) & "&nbsp;</font>"
                End If

                val.Controls.Add(v3)

                'Designtion
                v4.ColumnSpan = 1
                v4.HorizontalAlign = HorizontalAlign.Left
                v4.Text = "<font size=2>" & dr(8) & "&nbsp;</font>"
                val.Controls.Add(v4)

                'Deptmt
                v5.ColumnSpan = 1
                v5.HorizontalAlign = HorizontalAlign.Left
                v5.Text = "<font size=2>" & dr(9) & "&nbsp;</font>"
                val.Controls.Add(v5)

                'Post
                v6.ColumnSpan = 1
                v6.HorizontalAlign = HorizontalAlign.Left
                v6.Text = "<font size=2>" & dr(10) & "&nbsp;</font>"
                val.Controls.Add(v6)

                'DOJ
                v7.ColumnSpan = 1
                v7.HorizontalAlign = HorizontalAlign.Left
                v7.Text = "<font size=2>" & Format(dr(11), "dd/MMM/yyyy") & "&nbsp;</font>"
                val.Controls.Add(v7)


                'Qualficn
                v8.ColumnSpan = 1
                v8.HorizontalAlign = HorizontalAlign.Left
                v8.Text = "<font size=2>" & dr(12) & "</font>"
                val.Controls.Add(v8)

                ''Age
                v9.ColumnSpan = 1
                v9.HorizontalAlign = HorizontalAlign.Right
                If dr(13) = 0 Or IsDBNull(dr(13)) Then
                    v9.Text = "<font size=2>----</font>"
                Else
                    v9.Text = "<font size=2>" & dr(13) & "&nbsp;</font>"
                End If
                val.Controls.Add(v9)


                'ExpZ_days
                v10.ColumnSpan = 1
                v10.HorizontalAlign = HorizontalAlign.Right
                v10.Text = "<font size=2>" & dr(14) & "&nbsp;</font>"
                val.Controls.Add(v10)
                Me.exptotal += dr(14)

                'Emptype
                v11.ColumnSpan = 1
                v11.HorizontalAlign = HorizontalAlign.Left
                v11.Text = "<font size=2>" & dr(15) & "&nbsp;</font>"
                val.Controls.Add(v11)

                'Disc date
                v12.ColumnSpan = 1
                v12.HorizontalAlign = HorizontalAlign.Left
                If IsDBNull(dr(16)) Then
                    v12.Text = "<font size=2>----</font>"
                Else
                    v12.Text = "<font size=2>" & Format(dr(16), "dd/MMM/yyyy") & "&nbsp;</font>"
                End If
                val.Controls.Add(v12)

                'Old Vode
                v13.ColumnSpan = 1
                v13.HorizontalAlign = HorizontalAlign.Left
                If dr(17) = 0 Then
                    v13.Text = "<font size=2>----</font>"
                Else
                    v13.Text = "<font size=2>" & dr(17) & "&nbsp;</font>"
                End If
                val.Controls.Add(v13)

                v21.ColumnSpan = 1     'Gender
                v21.HorizontalAlign = HorizontalAlign.Left
                v21.Text = "<font size=2>" & dr(18) & "&nbsp;</font>"
                val.Controls.Add(v21)

                v22.ColumnSpan = 1    'Martial Status
                v22.HorizontalAlign = HorizontalAlign.Left
                v22.Text = "<font size=2>" & dr(19) & "&nbsp;</font>"
                val.Controls.Add(v22)

                v23.ColumnSpan = 1    'Date of Birth
                v23.HorizontalAlign = HorizontalAlign.Left
                If Not IsDBNull(dr(20)) Then
                    v23.Text = "<font size=2>" & Format(dr(20), "dd-MMM-yyyy") & "&nbsp;</font>"
                Else
                    v23.Text = "<font size=2>Not Entered!&nbsp;</font>"
                End If
                val.Controls.Add(v23)

                v24.ColumnSpan = 1    'Native District
                v24.HorizontalAlign = HorizontalAlign.Left
                v24.Text = "<font size=2>" & dr(21) & "&nbsp;</font>"
                val.Controls.Add(v24)


                empcurtable.Controls.Add(val)

            Next

            Dim linee As New TableRow
            Dim linecelle As New TableCell
            linee.Width = 22
            linecelle.ColumnSpan = 22
            linecelle.Text = "<hr>"
            linee.Controls.Add(linecelle)
            empcurtable.Controls.Add(linee)

            Dim totrow As New TableRow
            totrow.Width = 22
            Dim t1 As New TableCell
            t1.ColumnSpan = 22
            t1.HorizontalAlign = HorizontalAlign.Left
            t1.Text = "<b><font size=2> Total Employee(s):&nbsp;" & Me.total & " and Total Exp.Days=" & Me.exptotal & "</font></b>"
            totrow.Controls.Add(t1)
            empcurtable.Controls.Add(totrow)

        Else

            Dim warn As New TableRow
            warn.Width = 22
            Dim w1 As New TableCell
            w1.ColumnSpan = 22
            w1.HorizontalAlign = HorizontalAlign.Center
            w1.Text = "<b><font size=3>No Data !!</font><b>"
            warn.Controls.Add(w1)
            empcurtable.Controls.Add(warn)

        End If

        Panel_EmpStatus.Controls.Add(empcurtable)
    End Sub
End Class
