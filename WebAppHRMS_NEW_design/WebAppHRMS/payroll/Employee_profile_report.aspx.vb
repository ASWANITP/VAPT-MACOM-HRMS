Imports System.Data
Imports System.Data.OracleClient
Partial Class Employee_Profile_Employee_profile_report_9d5b0d056437
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2 As New DataTable
    Dim dr, dr1, dr2 As DataRow
    Dim str, str1, str2 As String
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim frm As Integer = Session("firm_id")
        If frm = 28 Then
            Response.Redirect("Employee_profile_report_mfdtn.aspx?empcode=" & Request.QueryString("empcode") & "")
            Exit Sub
        End If
        If frm = 2 Then
            Response.Redirect("Employee_profile_reportmab.aspx?empcode=" & Request.QueryString("empcode") & "")
            Exit Sub
        End If
        '----shi
        If frm = 24 Then
            '                  0             1         2              3           4           5              6             7              8              9              10          11                12           13             14          15                          16                               17                      18               19            20                                                       21                                          22                                                               23                                                                                                            24                                                   25                                                 
            str = "select em.emp_code,em.emp_name,dp.dep_name,dm.designation,upper(p.post_name),upper(ep.perm_add1),upper(pm.post_office),d.district_name,sm.state_name,pm.pin_code,upper(ep1.pres_add1),pm1.post_office,d1.district_name,sm1.state_name,pm1.pin_code,ep.res_phone,ep.cont_phone,decode(ep.emp_email,null,'Not specified',ep.emp_email),ep.father_name,ep.birth_date,decode(ep.sex,1,'Male',0,'Female'),case when ep.marital_status=1 then 'Single' else 'Married' end,case when ep.marital_status=2 then ep.spouse_name end,decode(ep.blood_id,1,'O+',2,'O-',3,'A+',4,'A-',5,'B+',6,'B-',7,'AB+',8,'AB-','Not Specified'),decode(ep.religion_id,1,'HINDU',2,'CHRISTIAN',3,'MUSLIM',4,'PARSI',5,'SIKH',6,'BUDHIST'),ep.caste from employee_master em,department_mst dp,designation_master dm,post_mst_jwell p,employ_personal_dtl ep,post_master pm,district_master d,state_master sm,employ_personal_dtl ep1,post_master pm1,district_master d1,state_master sm1 where em.department_id=dp.dep_id and em.designation_id=dm.designation_id and em.post_id=p.post_id and em.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=d.district_id and d.state_id=sm.state_id and em.emp_code=ep1.emp_code and ep1.pres_pin=pm1.sr_number and pm1.district_id=d1.district_id and d1.state_id=sm1.state_id and ep.emp_code=" & Me.Request.QueryString("empcode") & " union select em.emp_code,em.emp_name,'--',dm.designation,'--',upper(ep.perm_add1),upper(pm.post_office),d.district_name,sm.state_name,pm.pin_code,upper(ep1.pres_add1),pm1.post_office,d1.district_name,sm1.state_name,pm1.pin_code,ep.res_phone,ep.cont_phone,decode(ep.emp_email,null,'Not specified',ep.emp_email),ep.father_name,ep.birth_date,decode(ep.sex,1,'Male',0,'Female'),case when ep.marital_status=1 then 'Single' else 'Married' end,case when ep.marital_status=2 then ep.spouse_name end,decode(ep.blood_id,1,'O+',2,'O-',3,'A+',4,'A-',5,'B+',6,'B-',7,'AB+',8,'AB-','Not Specified'),decode(ep.religion_id,1,'HINDU',2,'CHRISTIAN',3,'MUSLIM',4,'PARSI',5,'SIKH',6,'BUDHIST'),ep.caste from employee_master em,designation_master dm,employ_personal_dtl ep,post_master pm,district_master d,state_master sm,employ_personal_dtl ep1,post_master pm1,district_master d1,state_master sm1 where em.department_id=0 and em.designation_id=dm.designation_id and em.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=d.district_id and d.state_id=sm.state_id and em.emp_code=ep1.emp_code and ep1.pres_pin=pm1.sr_number and pm1.district_id=d1.district_id and d1.state_id=sm1.state_id and ep.emp_code=" & Me.Request.QueryString("empcode") & ""
        Else
            '                  0             1         2              3           4           5              6             7              8              9              10          11                12           13             14          15                          16                               17                      18               19            20                                                       21                                          22                                                               23                                                                                                            24                                                   25                                                 
            str = "select em.emp_code,em.emp_name,dp.dep_name,dm.designation,upper(p.post_name),upper(ep.perm_add1),upper(pm.post_office),d.district_name,sm.state_name,pm.pin_code,upper(ep1.pres_add1),pm1.post_office,d1.district_name,sm1.state_name,pm1.pin_code,ep.res_phone,ep.cont_phone,decode(ep.emp_email,null,'Not specified',ep.emp_email),ep.father_name,ep.birth_date,decode(ep.sex,1,'Male',0,'Female'),case when ep.marital_status=1 then 'Single' else 'Married' end,case when ep.marital_status=2 then ep.spouse_name end,decode(ep.blood_id,1,'O+',2,'O-',3,'A+',4,'A-',5,'B+',6,'B-',7,'AB+',8,'AB-','Not Specified'),decode(ep.religion_id,1,'HINDU',2,'CHRISTIAN',3,'MUSLIM',4,'PARSI',5,'SIKH',6,'BUDHIST'),ep.caste from employee_master em,department_mst dp,designation_master dm,post_mst p,employ_personal_dtl ep,post_master pm,district_master d,state_master sm,employ_personal_dtl ep1,post_master pm1,district_master d1,state_master sm1 where em.department_id=dp.dep_id and em.designation_id=dm.designation_id and em.post_id=p.post_id and em.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=d.district_id and d.state_id=sm.state_id and em.emp_code=ep1.emp_code and ep1.pres_pin=pm1.sr_number and pm1.district_id=d1.district_id and d1.state_id=sm1.state_id and ep.emp_code=" & Me.Request.QueryString("empcode") & " union select em.emp_code,em.emp_name,'--',dm.designation,'--',upper(ep.perm_add1),upper(pm.post_office),d.district_name,sm.state_name,pm.pin_code,upper(ep1.pres_add1),pm1.post_office,d1.district_name,sm1.state_name,pm1.pin_code,ep.res_phone,ep.cont_phone,decode(ep.emp_email,null,'Not specified',ep.emp_email),ep.father_name,ep.birth_date,decode(ep.sex,1,'Male',0,'Female'),case when ep.marital_status=1 then 'Single' else 'Married' end,case when ep.marital_status=2 then ep.spouse_name end,decode(ep.blood_id,1,'O+',2,'O-',3,'A+',4,'A-',5,'B+',6,'B-',7,'AB+',8,'AB-','Not Specified'),decode(ep.religion_id,1,'HINDU',2,'CHRISTIAN',3,'MUSLIM',4,'PARSI',5,'SIKH',6,'BUDHIST'),ep.caste from employee_master em,designation_master dm,employ_personal_dtl ep,post_master pm,district_master d,state_master sm,employ_personal_dtl ep1,post_master pm1,district_master d1,state_master sm1 where em.department_id=0 and em.designation_id=dm.designation_id and em.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=d.district_id and d.state_id=sm.state_id and em.emp_code=ep1.emp_code and ep1.pres_pin=pm1.sr_number and pm1.district_id=d1.district_id and d1.state_id=sm1.state_id and ep.emp_code=" & Me.Request.QueryString("empcode") & ""
        End If

        '----shi

        ''                  0             1         2              3           4           5              6             7              8              9              10          11                12           13             14          15                          16                               17                      18               19            20                                                       21                                          22                                                               23                                                                                                            24                                                   25                                                 
        'str = "select em.emp_code,em.emp_name,dp.dep_name,dm.designation,upper(p.post_name),upper(ep.perm_add1),upper(pm.post_office),d.district_name,sm.state_name,pm.pin_code,upper(ep1.pres_add1),pm1.post_office,d1.district_name,sm1.state_name,pm1.pin_code,ep.res_phone,ep.cont_phone,decode(ep.emp_email,null,'Not specified',ep.emp_email),ep.father_name,ep.birth_date,decode(ep.sex,1,'Male',0,'Female'),case when ep.marital_status=1 then 'Single' else 'Married' end,case when ep.marital_status=2 then ep.spouse_name end,decode(ep.blood_id,1,'O+',2,'O-',3,'A+',4,'A-',5,'B+',6,'B-',7,'AB+',8,'AB-','Not Specified'),decode(ep.religion_id,1,'HINDU',2,'CHRISTIAN',3,'MUSLIM',4,'PARSI',5,'SIKH',6,'BUDHIST'),ep.caste from employee_master em,department_mst dp,designation_master dm,post_mst p,employ_personal_dtl ep,post_master pm,district_master d,state_master sm,employ_personal_dtl ep1,post_master pm1,district_master d1,state_master sm1 where em.department_id=dp.dep_id and em.designation_id=dm.designation_id and em.post_id=p.post_id and em.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=d.district_id and d.state_id=sm.state_id and em.emp_code=ep1.emp_code and ep1.pres_pin=pm1.sr_number and pm1.district_id=d1.district_id and d1.state_id=sm1.state_id and ep.emp_code=" & Me.Request.QueryString("empcode") & " union select em.emp_code,em.emp_name,'--',dm.designation,'--',upper(ep.perm_add1),upper(pm.post_office),d.district_name,sm.state_name,pm.pin_code,upper(ep1.pres_add1),pm1.post_office,d1.district_name,sm1.state_name,pm1.pin_code,ep.res_phone,ep.cont_phone,decode(ep.emp_email,null,'Not specified',ep.emp_email),ep.father_name,ep.birth_date,decode(ep.sex,1,'Male',0,'Female'),case when ep.marital_status=1 then 'Single' else 'Married' end,case when ep.marital_status=2 then ep.spouse_name end,decode(ep.blood_id,1,'O+',2,'O-',3,'A+',4,'A-',5,'B+',6,'B-',7,'AB+',8,'AB-','Not Specified'),decode(ep.religion_id,1,'HINDU',2,'CHRISTIAN',3,'MUSLIM',4,'PARSI',5,'SIKH',6,'BUDHIST'),ep.caste from employee_master em,designation_master dm,employ_personal_dtl ep,post_master pm,district_master d,state_master sm,employ_personal_dtl ep1,post_master pm1,district_master d1,state_master sm1 where em.department_id=0 and em.designation_id=dm.designation_id and em.emp_code=ep.emp_code and ep.perm_pin=pm.sr_number and pm.district_id=d.district_id and d.state_id=sm.state_id and em.emp_code=ep1.emp_code and ep1.pres_pin=pm1.sr_number and pm1.district_id=d1.district_id and d1.state_id=sm1.state_id and ep.emp_code=" & Me.Request.QueryString("empcode") & ""
        dt = oh.ExecuteDataSet(str).Tables(0)
        str1 = "select qm.qualification,decode(eq.institution,null,'----','NILL','----',eq.institution),eq.university,eq.percentage,eq.year_pass from employ_qualification_dtl eq,qualification_master qm where eq.qualification=qm.qualification_id and eq.emp_code=" & Request.QueryString("empcode")
        dt1 = oh.ExecuteDataSet(str1).Tables(0)
        str2 = "select ex.organisation,ex.designation,ex.exp_frdate,ex.exp_todate,ex.nature_duty,ex.releaving_reason,ex.cont_person,ex.cont_phone from employ_experience_dtl ex where ex.emp_code=" & Request.QueryString("empcode")
        dt2 = oh.ExecuteDataSet(str2).Tables(0)

        Dim emp_prof_table As New Table

        If dt.Rows.Count > 0 Then

            emp_prof_table.Attributes.Add("width", "100%")
            Dim header As New TableRow
            header.Width = 8
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            Dim headcell As New TableCell
            headcell.ColumnSpan = 8
            headcell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
            headcell.HorizontalAlign = HorizontalAlign.Center
            header.Controls.Add(headcell)
            emp_prof_table.Controls.Add(header)

            Dim sheader As New TableRow
            sheader.Width = 8
            Dim sheadercell1 As New TableCell
            sheadercell1.ColumnSpan = 8
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
            sheader.Controls.Add(sheadercell1)
            emp_prof_table.Controls.Add(sheader)


            Dim subh As New TableRow
            Dim subcell1 As New TableCell
            Dim subcell2 As New TableCell
            Dim subcell3 As New TableCell
            subh.Width = 8
            subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
            subcell1.ColumnSpan = 2
            subcell1.HorizontalAlign = HorizontalAlign.Left
            subh.Controls.Add(subcell1)

            subcell2.ColumnSpan = 4
            subcell2.HorizontalAlign = HorizontalAlign.Center
            subcell2.Text = " "
            subh.Controls.Add(subcell2)

            subcell3.ColumnSpan = 2
            subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
            subcell3.HorizontalAlign = HorizontalAlign.Right
            subh.Controls.Add(subcell3)

            emp_prof_table.Controls.Add(subh)

            Dim pheader As New TableRow
            Dim pheadercell As New TableCell
            pheader.Width = 8
            pheadercell.ColumnSpan = 8
            pheadercell.HorizontalAlign = HorizontalAlign.Center
            pheadercell.Text = "<b><font size=3>Employee Profile</font></b>"
            pheader.Controls.Add(pheadercell)
            emp_prof_table.Controls.Add(pheader)

            Dim space As New TableRow
            space.Width = 8
            Dim s1 As New TableCell
            s1.ColumnSpan = 8
            s1.Text = "<hr>"
            space.Controls.Add(s1)
            emp_prof_table.Controls.Add(space)


            Dim no As New TableRow
            no.Width = 8
            Dim no1, no2, no3 As New TableCell
            no1.HorizontalAlign = HorizontalAlign.Left
            no2.HorizontalAlign = HorizontalAlign.Right
            no3.HorizontalAlign = HorizontalAlign.Left
            no1.ColumnSpan = 2
            no2.ColumnSpan = 4
            no3.ColumnSpan = 2
            no1.Text = "<b><font size=2>Employee Code&nbsp;:&nbsp;" & Me.Request.QueryString("empcode") & "</font></b>"
            no2.Text = "  "
            If Not IsDBNull(dt.Rows(0)(2)) Then
                no3.Text = "<b><font size=2>Dept&nbsp;:&nbsp;" & dt.Rows(0)(2) & "</font></b>"
            Else
                no3.Text = "<b><font size=2>Dept&nbsp;:&nbsp;------</font></b>"
            End If
            no.Controls.Add(no1)
            no.Controls.Add(no2)
            no.Controls.Add(no3)
            emp_prof_table.Controls.Add(no)


            Dim noq As New TableRow
            noq.Width = 8
            Dim noq1, noq2, noq3 As New TableCell
            noq1.HorizontalAlign = HorizontalAlign.Left
            noq2.HorizontalAlign = HorizontalAlign.Right
            noq3.HorizontalAlign = HorizontalAlign.Left
            noq1.ColumnSpan = 2
            noq2.ColumnSpan = 4
            noq3.ColumnSpan = 2
            noq1.Text = "<b><font size=2>Name&nbsp;:&nbsp;" & dt.Rows(0)(1) & "</font></b>"
            noq2.Text = "  "
            noq3.Text = "<b><font size=2>Desig&nbsp;:&nbsp;" & dt.Rows(0)(3) & "</font></b>"
            noq.Controls.Add(noq1)
            noq.Controls.Add(noq2)
            noq.Controls.Add(noq3)
            emp_prof_table.Controls.Add(noq)

            Dim nor As New TableRow
            nor.Width = 8
            Dim nor1, nor2, nor3 As New TableCell
            nor1.HorizontalAlign = HorizontalAlign.Left
            nor2.HorizontalAlign = HorizontalAlign.Right
            nor3.HorizontalAlign = HorizontalAlign.Left
            nor1.ColumnSpan = 2
            nor2.ColumnSpan = 4
            nor3.ColumnSpan = 2
            nor1.Text = "  "
            nor2.Text = "  "
            nor3.Text = "<b><font size=2>Post&nbsp;:&nbsp;" & dt.Rows(0)(4) & "</font></b>"
            nor.Controls.Add(nor1)
            nor.Controls.Add(nor2)
            nor.Controls.Add(nor3)
            emp_prof_table.Controls.Add(nor)



            Dim blank1 As New TableRow
            blank1.Width = 8
            Dim b1 As New TableCell
            b1.ColumnSpan = 8
            b1.Text = "<hr>"
            blank1.Controls.Add(b1)
            emp_prof_table.Controls.Add(blank1)

            Dim head1 As New TableRow
            head1.Width = 8
            Dim h1 As New TableCell
            h1.ColumnSpan = 8
            h1.Text = "<u><b><font size=2>Personal Details</font></b></u>"
            head1.Controls.Add(h1)
            emp_prof_table.Controls.Add(head1)


            Dim name As New TableRow
            Dim name1 As New TableCell
            Dim name2 As New TableCell
            name1.HorizontalAlign = HorizontalAlign.Left
            name2.HorizontalAlign = HorizontalAlign.Left
            name1.ColumnSpan = 2
            name2.ColumnSpan = 5
            name1.Text = "<b><font size=2>Employee Name &nbsp:</font></b>"
            name2.Text = "<font size=2>" & dt.Rows(0)(1) & "</font>"
            name.Controls.Add(name1)
            name.Controls.Add(name2)
            emp_prof_table.Controls.Add(name)

            Dim peradd As New TableRow
            Dim peradd1 As New TableCell
            Dim peradd2 As New TableCell
            peradd1.HorizontalAlign = HorizontalAlign.Left
            peradd2.HorizontalAlign = HorizontalAlign.Left
            peradd1.ColumnSpan = 2
            peradd2.ColumnSpan = 5
            peradd1.Text = "<b><font size=2>Permanant Address&nbsp:</font></b>"
            peradd2.Text = "<font size=2>" & dt.Rows(0)(5) & "</font>"
            peradd.Controls.Add(peradd1)
            peradd.Controls.Add(peradd2)
            emp_prof_table.Controls.Add(peradd)

            Dim postoff As New TableRow
            Dim postoff1 As New TableCell
            Dim postoff2 As New TableCell
            postoff1.HorizontalAlign = HorizontalAlign.Left
            postoff2.HorizontalAlign = HorizontalAlign.Left
            postoff1.ColumnSpan = 2
            postoff2.ColumnSpan = 5
            postoff1.Text = " "
            postoff2.Text = "<font size=2>" & dt.Rows(0)(6) & "&nbsp;&nbsp(P.O)</font>"
            postoff.Controls.Add(postoff1)
            postoff.Controls.Add(postoff2)
            emp_prof_table.Controls.Add(postoff)

            Dim distnme As New TableRow
            Dim distnme1 As New TableCell
            Dim distnme2 As New TableCell
            distnme1.HorizontalAlign = HorizontalAlign.Left
            distnme2.HorizontalAlign = HorizontalAlign.Left
            distnme1.ColumnSpan = 2
            distnme2.ColumnSpan = 5
            distnme1.Text = " "
            distnme2.Text = "<font size=2>" & dt.Rows(0)(7) & "</font>"
            distnme.Controls.Add(distnme1)
            distnme.Controls.Add(distnme2)
            emp_prof_table.Controls.Add(distnme)

            Dim stname As New TableRow
            Dim stname1 As New TableCell
            Dim stname2 As New TableCell
            stname1.HorizontalAlign = HorizontalAlign.Left
            stname2.HorizontalAlign = HorizontalAlign.Left
            stname1.ColumnSpan = 2
            stname2.ColumnSpan = 5
            stname1.Text = " "
            stname2.Text = "<font size=2>" & dt.Rows(0)(8) & "</font>"
            stname.Controls.Add(stname1)
            stname.Controls.Add(stname2)
            emp_prof_table.Controls.Add(stname)

            Dim pincode As New TableRow
            Dim pincode1 As New TableCell
            Dim pincode2 As New TableCell
            pincode1.HorizontalAlign = HorizontalAlign.Left
            pincode2.HorizontalAlign = HorizontalAlign.Left
            pincode1.ColumnSpan = 2
            pincode2.ColumnSpan = 5
            pincode1.Text = " "
            pincode2.Text = "<font size=2>P.I.N&nbsp;:&nbsp;" & dt.Rows(0)(9) & "</font>"
            pincode.Controls.Add(pincode1)
            pincode.Controls.Add(pincode2)
            emp_prof_table.Controls.Add(pincode)


            Dim preadd As New TableRow
            Dim preadd1 As New TableCell
            Dim preadd2 As New TableCell
            preadd1.HorizontalAlign = HorizontalAlign.Left
            preadd2.HorizontalAlign = HorizontalAlign.Left
            preadd1.ColumnSpan = 2
            preadd2.ColumnSpan = 5
            preadd1.Text = "<b><font size=2>Present Address&nbsp:</font></b>"
            preadd2.Text = "<font size=2>" & dt.Rows(0)(10) & "</font>"
            preadd.Controls.Add(preadd1)
            preadd.Controls.Add(preadd2)
            emp_prof_table.Controls.Add(preadd)

            Dim preposoff As New TableRow
            Dim preposoff1 As New TableCell
            Dim preposoff2 As New TableCell
            preposoff1.HorizontalAlign = HorizontalAlign.Left
            preposoff2.HorizontalAlign = HorizontalAlign.Left
            preposoff1.ColumnSpan = 2
            preposoff2.ColumnSpan = 5
            preposoff1.Text = " "
            preposoff2.Text = "<font size=2>" & dt.Rows(0)(11) & "&nbsp;&nbsp(P.O)</font>"
            preposoff.Controls.Add(preposoff1)
            preposoff.Controls.Add(preposoff2)
            emp_prof_table.Controls.Add(preposoff)

            Dim predisnme As New TableRow
            Dim predisnme1 As New TableCell
            Dim predisnme2 As New TableCell
            predisnme1.HorizontalAlign = HorizontalAlign.Left
            predisnme2.HorizontalAlign = HorizontalAlign.Left
            predisnme1.ColumnSpan = 2
            predisnme2.ColumnSpan = 5
            predisnme1.Text = " "
            predisnme2.Text = "<font size=2>" & dt.Rows(0)(12) & "</font>"
            predisnme.Controls.Add(predisnme1)
            predisnme.Controls.Add(predisnme2)
            emp_prof_table.Controls.Add(predisnme)

            Dim prestate As New TableRow
            Dim prestate1 As New TableCell
            Dim prestate2 As New TableCell
            prestate1.HorizontalAlign = HorizontalAlign.Left
            prestate2.HorizontalAlign = HorizontalAlign.Left
            prestate1.ColumnSpan = 2
            prestate2.ColumnSpan = 5
            prestate1.Text = " "
            prestate2.Text = "<font size=2>" & dt.Rows(0)(13) & "</font>"
            prestate.Controls.Add(prestate1)
            prestate.Controls.Add(prestate2)
            emp_prof_table.Controls.Add(prestate)

            Dim prepincode As New TableRow
            Dim prepincode11 As New TableCell
            Dim prepincode12 As New TableCell
            prepincode11.HorizontalAlign = HorizontalAlign.Left
            prepincode12.HorizontalAlign = HorizontalAlign.Left
            prepincode11.ColumnSpan = 2
            prepincode12.ColumnSpan = 5
            prepincode11.Text = " "
            prepincode12.Text = "<font size=2>P.I.N&nbsp;:&nbsp;" & dt.Rows(0)(14) & "</font>"
            prepincode.Controls.Add(prepincode11)
            prepincode.Controls.Add(prepincode12)
            emp_prof_table.Controls.Add(prepincode)

            If Not IsDBNull(dt.Rows(0)(15)) Then
                Dim resph As New TableRow
                Dim resph1 As New TableCell
                Dim resph2 As New TableCell
                resph1.HorizontalAlign = HorizontalAlign.Left
                resph2.HorizontalAlign = HorizontalAlign.Left
                resph1.ColumnSpan = 2
                resph2.ColumnSpan = 5
                resph1.Text = "<b><font size=2>Res. Phone:</font></b>"
                resph2.Text = "<font size=2>" & dt.Rows(0)(15) & "</font>"
                resph.Controls.Add(resph1)
                resph.Controls.Add(resph2)
                emp_prof_table.Controls.Add(resph)
            End If

            If Not IsDBNull(dt.Rows(0)(16)) Then
                Dim cophone As New TableRow
                Dim cophone1 As New TableCell
                Dim cophone2 As New TableCell
                cophone1.HorizontalAlign = HorizontalAlign.Left
                cophone2.HorizontalAlign = HorizontalAlign.Left
                cophone1.ColumnSpan = 2
                cophone2.ColumnSpan = 5
                cophone1.Text = "<b><font size=2>Contact Phone:</font></b>"
                cophone2.Text = "<font size=2>" & dt.Rows(0)(16) & "</font>"
                cophone.Controls.Add(cophone1)
                cophone.Controls.Add(cophone2)
                emp_prof_table.Controls.Add(cophone)
            End If

            Dim email As New TableRow
            Dim email1 As New TableCell
            Dim email2 As New TableCell
            email1.HorizontalAlign = HorizontalAlign.Left
            email2.HorizontalAlign = HorizontalAlign.Left
            email1.ColumnSpan = 2
            email2.ColumnSpan = 5
            email1.Text = "<b><font size=2>E-mail:</font></b>"
            email2.Text = "<font size=2>" & dt.Rows(0)(17) & "</font>"
            email.Controls.Add(email1)
            email.Controls.Add(email2)
            emp_prof_table.Controls.Add(email)



            Dim fatname As New TableRow
            Dim fatname1 As New TableCell
            Dim fatname2 As New TableCell
            fatname1.HorizontalAlign = HorizontalAlign.Left
            fatname2.HorizontalAlign = HorizontalAlign.Left
            fatname1.ColumnSpan = 2
            fatname2.ColumnSpan = 5
            fatname1.Text = "<b><font size=2>Father's Name:</font></b>"
            fatname2.Text = "<font size=2>" & dt.Rows(0)(18) & "</font>"
            fatname.Controls.Add(fatname1)
            fatname.Controls.Add(fatname2)
            emp_prof_table.Controls.Add(fatname)

            Dim bdate As New TableRow
            Dim bdate1 As New TableCell
            Dim bdate2 As New TableCell
            bdate1.HorizontalAlign = HorizontalAlign.Left
            bdate2.HorizontalAlign = HorizontalAlign.Left
            bdate1.ColumnSpan = 2
            bdate2.ColumnSpan = 5
            bdate1.Text = "<b><font size=2>Date of Birth:</font></b>"
            bdate2.Text = "<font size=2>" & Format(dt.Rows(0)(19), "dd/MMM/yyyy") & "</font>"
            bdate.Controls.Add(bdate1)
            bdate.Controls.Add(bdate2)
            emp_prof_table.Controls.Add(bdate)


            Dim sex As New TableRow
            Dim sex1 As New TableCell
            Dim sex2 As New TableCell
            sex1.HorizontalAlign = HorizontalAlign.Left
            sex2.HorizontalAlign = HorizontalAlign.Left
            sex1.ColumnSpan = 2
            sex2.ColumnSpan = 5
            sex1.Text = "<b><font size=2>Sex:</font></b>"
            sex2.Text = "<font size=2>" & dt.Rows(0)(20) & "</font>"
            sex.Controls.Add(sex1)
            sex.Controls.Add(sex2)
            emp_prof_table.Controls.Add(sex)




            Dim mstatus As New TableRow
            Dim mstatus1 As New TableCell
            Dim mstatus2 As New TableCell
            mstatus1.HorizontalAlign = HorizontalAlign.Left
            mstatus2.HorizontalAlign = HorizontalAlign.Left
            mstatus1.ColumnSpan = 2
            mstatus2.ColumnSpan = 5
            mstatus1.Text = "<b><font size=2>Martial Status:</font></b>"
            mstatus2.Text = "<font size=2>" & dt.Rows(0)(21) & "</font>"
            mstatus.Controls.Add(mstatus1)
            mstatus.Controls.Add(mstatus2)
            emp_prof_table.Controls.Add(mstatus)


            If Not IsDBNull(dt.Rows(0)(22)) Then
                Dim spname As New TableRow
                Dim spname1 As New TableCell
                Dim spname2 As New TableCell
                spname1.HorizontalAlign = HorizontalAlign.Left
                spname2.HorizontalAlign = HorizontalAlign.Left
                spname1.ColumnSpan = 2
                spname2.ColumnSpan = 5
                spname1.Text = "<b><font size=2>Spouse Name:</font></b>"
                spname2.Text = "<font size=2>" & dt.Rows(0)(22) & "</font>"
                spname.Controls.Add(spname1)
                spname.Controls.Add(spname2)
                emp_prof_table.Controls.Add(spname)
            End If

            Dim bloodgp As New TableRow
            Dim bloodgp1 As New TableCell
            Dim bloodgp2 As New TableCell
            bloodgp1.HorizontalAlign = HorizontalAlign.Left
            bloodgp2.HorizontalAlign = HorizontalAlign.Left
            bloodgp1.ColumnSpan = 2
            bloodgp2.ColumnSpan = 5
            bloodgp1.Text = "<b><font size=2>Blood Group:</font></b>"
            bloodgp2.Text = "<font size=2>" & dt.Rows(0)(23) & "</font>"
            bloodgp.Controls.Add(bloodgp1)
            bloodgp.Controls.Add(bloodgp2)
            emp_prof_table.Controls.Add(bloodgp)

            Dim religion As New TableRow
            Dim religion1 As New TableCell
            Dim religion2 As New TableCell
            religion1.HorizontalAlign = HorizontalAlign.Left
            religion2.HorizontalAlign = HorizontalAlign.Left
            religion1.ColumnSpan = 2
            religion2.ColumnSpan = 5
            religion1.Text = "<b><font size=2>Religion:</font></b>"
            religion2.Text = "<font size=2>" & dt.Rows(0)(24) & "</font>"
            religion.Controls.Add(religion1)
            religion.Controls.Add(religion2)
            emp_prof_table.Controls.Add(religion)

            Dim caste As New TableRow
            Dim caste1 As New TableCell
            Dim caste2 As New TableCell
            caste1.HorizontalAlign = HorizontalAlign.Left
            caste2.HorizontalAlign = HorizontalAlign.Left
            caste1.ColumnSpan = 2
            caste2.ColumnSpan = 5
            caste1.Text = "<b><font size=2>Caste:</font></b>"
            caste2.Text = "<font size=2>" & dt.Rows(0)(25) & "</font>"
            caste.Controls.Add(caste1)
            caste.Controls.Add(caste2)
            emp_prof_table.Controls.Add(caste)

            Dim blank2 As New TableRow
            blank2.Width = 8
            Dim bl As New TableCell
            bl.ColumnSpan = 8
            bl.Text = "  "
            blank2.Controls.Add(bl)
            emp_prof_table.Controls.Add(blank2)

            If dt1.Rows.Count > 0 Then
                Dim head2 As New TableRow
                head2.Width = 8
                Dim h2 As New TableCell
                h2.ColumnSpan = 8
                h2.Text = "<u><b><font size=2>Qualification Details</font></b></u>"
                head2.Controls.Add(h2)
                emp_prof_table.Controls.Add(head2)

                Dim qualhead As New TableRow
                qualhead.Width = 8
                Dim qf1, qf2, qf3, qf4, qf5 As New TableCell
                qualhead.BorderStyle = BorderStyle.Solid
                qualhead.BorderWidth = 1
                qualhead.BorderColor = Drawing.Color.Aqua

                qf1.ColumnSpan = 2
                qf1.HorizontalAlign = HorizontalAlign.Left
                qf1.Text = "<b><font size=2>Qualification</font></b>"
                qualhead.Controls.Add(qf1)

                qf2.ColumnSpan = 2
                qf2.HorizontalAlign = HorizontalAlign.Left
                qf2.Text = "<b><font size=2>Institution</font></b>"
                qualhead.Controls.Add(qf2)

                qf3.ColumnSpan = 2
                qf3.HorizontalAlign = HorizontalAlign.Left
                qf3.Text = "<b><font size=2>University</font></b>"
                qualhead.Controls.Add(qf3)

                qf4.ColumnSpan = 1
                qf4.HorizontalAlign = HorizontalAlign.Left
                qf4.Text = "<b><font size=2>%</font></b>"
                qualhead.Controls.Add(qf4)

                qf5.ColumnSpan = 1
                qf5.HorizontalAlign = HorizontalAlign.Left
                qf5.Text = "<b><font size=2>Year</font></b>"
                qualhead.Controls.Add(qf5)

                emp_prof_table.Controls.Add(qualhead)



                For Each dr1 In dt1.Rows

                    Dim qualvalue As New TableRow
                    qualvalue.Width = 8
                    Dim qv1, qv2, qv3, qv4, qv5 As New TableCell
                    qualvalue.BorderStyle = BorderStyle.Solid
                    qualvalue.BorderWidth = 1
                    qualvalue.BorderColor = Drawing.Color.Aqua

                    qv1.ColumnSpan = 2
                    qv1.HorizontalAlign = HorizontalAlign.Left
                    qv1.Text = "<font size=2>" & dr1(0) & "</font>"
                    qualvalue.Controls.Add(qv1)

                    qv2.ColumnSpan = 2
                    qv2.HorizontalAlign = HorizontalAlign.Left
                    qv2.Text = "<font size=2>" & dr1(1) & "</font>"
                    qualvalue.Controls.Add(qv2)

                    qv3.ColumnSpan = 2
                    qv3.HorizontalAlign = HorizontalAlign.Left
                    qv3.Text = "<font size=2>" & dr1(2) & "</font>"
                    qualvalue.Controls.Add(qv3)

                    qv4.ColumnSpan = 1
                    qv4.HorizontalAlign = HorizontalAlign.Left
                    qv4.Text = "<font size=2>" & dr1(3) & "</font>"
                    qualvalue.Controls.Add(qv4)

                    qv5.ColumnSpan = 1
                    qv5.HorizontalAlign = HorizontalAlign.Left
                    qv5.Text = "<font size=2>" & dr1(4) & "</font>"
                    qualvalue.Controls.Add(qv5)

                    emp_prof_table.Controls.Add(qualvalue)


                Next
            Else
                Dim qwarn As New TableRow
                qwarn.Width = 8
                Dim qw1 As New TableCell
                qw1.ColumnSpan = 8
                qw1.HorizontalAlign = HorizontalAlign.Center
                qw1.Text = "<b><font size=2>No Qualification Entered!!</font></b>"
                qwarn.Controls.Add(qw1)
                emp_prof_table.Controls.Add(qwarn)
            End If

            Dim blankg As New TableRow
            blankg.Width = 8
            Dim bl1 As New TableCell
            bl1.ColumnSpan = 8
            bl1.Text = "  "
            blankg.Controls.Add(bl1)
            emp_prof_table.Controls.Add(blankg)

            Dim blankd As New TableRow
            blankd.Width = 8
            Dim dl1 As New TableCell
            dl1.ColumnSpan = 8
            dl1.Text = "  "
            blankd.Controls.Add(dl1)
            emp_prof_table.Controls.Add(blankd)


            '/////////////////////////////////////////Experience////////////////////////////////////////

            If dt2.Rows.Count > 0 Then
                Dim head3 As New TableRow
                head3.Width = 8
                Dim h3 As New TableCell
                h3.ColumnSpan = 8
                h3.Text = "<u><b><font size=2>Experience Details</font></b></u>"
                head3.Controls.Add(h3)
                emp_prof_table.Controls.Add(head3)

                Dim i As Integer = 0

                For Each dr2 In dt2.Rows
                    Dim org As New TableRow
                    org.Width = 8
                    Dim sn, orgn, orgname As New TableCell

                    sn.ColumnSpan = 1
                    sn.HorizontalAlign = HorizontalAlign.Left
                    sn.Text = "<b><font size=2>" & i + 1 & ".</font></b>"
                    org.Controls.Add(sn)

                    orgn.ColumnSpan = 2
                    orgn.HorizontalAlign = HorizontalAlign.Left
                    orgn.Text = "<b><font size=2>Organization:</font></b>"
                    org.Controls.Add(orgn)

                    orgname.ColumnSpan = 5
                    orgname.HorizontalAlign = HorizontalAlign.Left
                    orgname.Text = "<font size=2>" & dr2(0) & "</font>"
                    org.Controls.Add(orgname)

                    emp_prof_table.Controls.Add(org)

                    Dim des As New TableRow
                    des.Width = 8
                    Dim dd, dd1, dd2 As New TableCell

                    dd.ColumnSpan = 1
                    dd.HorizontalAlign = HorizontalAlign.Left
                    dd.Text = " "
                    des.Controls.Add(dd)

                    dd1.ColumnSpan = 2
                    dd1.HorizontalAlign = HorizontalAlign.Left
                    dd1.Text = "<b><font size=2>Designation:</font></b>"
                    des.Controls.Add(dd1)

                    dd2.ColumnSpan = 5
                    dd2.HorizontalAlign = HorizontalAlign.Left
                    dd2.Text = "<font size=2>" & dr2(1) & "</font>"
                    des.Controls.Add(dd2)

                    emp_prof_table.Controls.Add(des)

                    Dim exfrom As New TableRow
                    exfrom.Width = 8
                    Dim xf1, xf2, xf3 As New TableCell

                    xf1.ColumnSpan = 1
                    xf1.HorizontalAlign = HorizontalAlign.Left
                    xf1.Text = " "
                    exfrom.Controls.Add(xf1)

                    xf2.ColumnSpan = 2
                    xf2.HorizontalAlign = HorizontalAlign.Left
                    xf2.Text = "<b><font size=2>Ex. From:</font></b>"
                    exfrom.Controls.Add(xf2)

                    xf3.ColumnSpan = 5
                    xf3.HorizontalAlign = HorizontalAlign.Left
                    xf3.Text = "<font size=2>" & Format(dr2(2), "dd/MMM/yyyy") & "</font>"
                    exfrom.Controls.Add(xf3)

                    emp_prof_table.Controls.Add(exfrom)

                    Dim exto As New TableRow
                    exto.Width = 8
                    Dim xt1, xt2, xt3 As New TableCell

                    xt1.ColumnSpan = 1
                    xt1.HorizontalAlign = HorizontalAlign.Left
                    xt1.Text = " "
                    exto.Controls.Add(xt1)

                    xt2.ColumnSpan = 2
                    xt2.HorizontalAlign = HorizontalAlign.Left
                    xt2.Text = "<b><font size=2>Ex. To:</font></b>"
                    exto.Controls.Add(xt2)

                    xt3.ColumnSpan = 5
                    xt3.HorizontalAlign = HorizontalAlign.Left
                    xt3.Text = "<font size=2>" & Format(dr2(3), "dd/MMM/yyyy") & "</font>"
                    exto.Controls.Add(xt3)

                    emp_prof_table.Controls.Add(exto)


                    Dim natdty As New TableRow
                    natdty.Width = 8
                    Dim nt1, nt2, nt3 As New TableCell

                    nt1.ColumnSpan = 1
                    nt1.HorizontalAlign = HorizontalAlign.Left
                    nt1.Text = " "
                    natdty.Controls.Add(nt1)

                    nt2.ColumnSpan = 2
                    nt2.HorizontalAlign = HorizontalAlign.Left
                    nt2.Text = "<b><font size=2>Nature of Duty:</font></b>"
                    natdty.Controls.Add(nt2)

                    nt3.ColumnSpan = 5
                    nt3.HorizontalAlign = HorizontalAlign.Left
                    nt3.Text = "<font size=2>" & dr2(4) & "</font>"
                    natdty.Controls.Add(nt3)

                    emp_prof_table.Controls.Add(natdty)

                    Dim rrson As New TableRow
                    rrson.Width = 8
                    Dim rr1, rr2, rr3 As New TableCell

                    rr1.ColumnSpan = 1
                    rr1.HorizontalAlign = HorizontalAlign.Left
                    rr1.Text = " "
                    rrson.Controls.Add(rr1)

                    rr2.ColumnSpan = 2
                    rr2.HorizontalAlign = HorizontalAlign.Left
                    rr2.Text = "<b><font size=2>Reason For Relieve:</font></b>"
                    rrson.Controls.Add(rr2)

                    rr3.ColumnSpan = 5
                    rr3.HorizontalAlign = HorizontalAlign.Left
                    rr3.Text = "<font size=2>" & dr2(5) & "</font>"
                    rrson.Controls.Add(rr3)

                    emp_prof_table.Controls.Add(rrson)

                    Dim ref As New TableRow
                    ref.Width = 8
                    Dim rf, rf1, rf2 As New TableCell

                    rf.ColumnSpan = 1
                    rf.HorizontalAlign = HorizontalAlign.Left
                    rf.Text = " "
                    ref.Controls.Add(rf)

                    rf1.ColumnSpan = 2
                    rf1.HorizontalAlign = HorizontalAlign.Left
                    rf1.Text = "<b><font size=2>Ref. Person:</font></b>"
                    ref.Controls.Add(rf1)

                    rf2.ColumnSpan = 5
                    rf2.HorizontalAlign = HorizontalAlign.Left
                    rf2.Text = "<font size=2>" & dr2(6) & "</font>"
                    ref.Controls.Add(rf2)

                    emp_prof_table.Controls.Add(ref)

                    Dim rfno As New TableRow
                    rfno.Width = 8
                    Dim rn, rn1, rn2 As New TableCell

                    rn.ColumnSpan = 1
                    rn.HorizontalAlign = HorizontalAlign.Left
                    rn.Text = " "
                    rfno.Controls.Add(rn)

                    rn1.ColumnSpan = 2
                    rn1.HorizontalAlign = HorizontalAlign.Left
                    rn1.Text = "<b><font size=2>Contact Number:</font></b>"
                    rfno.Controls.Add(rn1)

                    rn2.ColumnSpan = 5
                    rn2.HorizontalAlign = HorizontalAlign.Left
                    rn2.Text = "<font size=2>" & dr2(7) & "</font>"
                    rfno.Controls.Add(rn2)

                    emp_prof_table.Controls.Add(rfno)



                    i += 1


                Next



            Else
                Dim xwarn As New TableRow
                xwarn.Width = 8
                Dim xw1 As New TableCell
                xw1.ColumnSpan = 8
                xw1.HorizontalAlign = HorizontalAlign.Center
                xw1.Text = "<b><font size=2>No Experience Details Entered!!</font></b>"
                xwarn.Controls.Add(xw1)
                emp_prof_table.Controls.Add(xwarn)
            End If


        Else
            Dim warn As New TableRow
            warn.Width = 8
            Dim w1 As New TableCell
            w1.ColumnSpan = 8
            w1.HorizontalAlign = HorizontalAlign.Center
            w1.Text = "<b><font size=2>Please Check whether this employee has correct address!!</font></b>"
            warn.Controls.Add(w1)
            emp_prof_table.Controls.Add(warn)

        End If

        Pan_Emp_profile.Controls.Add(emp_prof_table)
    End Sub
End Class
