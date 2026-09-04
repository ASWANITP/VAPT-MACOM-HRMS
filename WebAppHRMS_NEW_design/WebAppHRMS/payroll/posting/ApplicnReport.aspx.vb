Imports System.Data
Imports System.Data.OracleClient
Partial Class Application_ApplicnReport_3dd351153665
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dt1 As New DataTable
    Dim dt2 As New DataTable
    Dim dt3 As New DataTable
    Dim dr As DataRow
    Dim str1 As String
    Dim str2 As String
    Dim str3 As String
    Dim str4 As String
    Dim fir As Integer
    Dim firm As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        fir = Session("firm_id")
        firm = Session("firm_name")
        Dim frmadr As DataTable = oh.ExecuteDataSet("select m.firm_address from firm_master m where m.firm_id=" & fir & "").Tables(0)
        str1 = "select upper(a.appln_name),upper(a.perm_add1),upper(a.pres_add1),upper(a.father_name),p.pin_code,upper(p.post_office),upper(d.district_name),upper(s.state_name),pr.pin_code,upper(pr.post_office),upper(dr.district_name),upper(sr.state_name),a.res_phone,a.cont_phone,a.birth_date,a.gender,g.gender_name,a.appln_email,a.marital_status,upper(a.spouse_name),a.child_number,b.blood_type,i.identity_name,a.idproof_number,upper(r.religion),upper(a.caste),upper(a.landmark),a.pp from appln_pers_dtl a,gender g,post_master p,district_master d,state_master s,post_master pr,district_master dr,state_master sr,bloodgroup_master b,identity i,religion_master r where a.gender=g.gender_id and a.perm_pin=p.sr_number and p.district_id=d.district_id and d.state_id=s.state_id and a.pres_pin=pr.sr_number and pr.district_id=dr.district_id and dr.state_id=sr.state_id and a.blood_id = b.blood_id And a.id_proof = i.identity_id And a.religion_id = r.religion_id and a.appln_no=" & Request.QueryString("appln_no")
        'str1 = "select upper(a.appln_name),  upper(a.perm_add1),  upper(a.pres_add1),  upper(a.father_name),  p.pin_code,  upper(p.post_office),  upper(d.district_name),  upper(s.state_name),  pr.pin_code,  upper(pr.post_office),  upper(dr.district_name),  upper(sr.state_name),  a.res_phone,  a.cont_phone,  a.birth_date,  a.gender,  g.gender_name,  a.appln_email,  a.marital_status,  upper(a.spouse_name),  a.child_number,  b.blood_type,  i.identity_name,  a.idproof_number,  upper(r.religion),  upper(a.caste),  upper(a.landmark),  a.pp  from appln_pers_dtl    a,  gender            g,  post_master       p,  district_master   d,  state_master      s,  post_master       pr,  district_master   dr,  state_master      sr,  bloodgroup_master b,  identity          i,  religion_master   r,  appln_interview_dtl api,  employee_master em,  employ_firm ef  where a.gender = g.gender_id  and a.perm_pin = p.sr_number  and p.district_id = d.district_id  and d.state_id = s.state_id  and a.pres_pin = pr.sr_number  and pr.district_id = dr.district_id  and dr.state_id = sr.state_id  and a.blood_id = b.blood_id  And a.id_proof = i.identity_id  and api.appln_no=a.appln_no  and api.emp_code=em.emp_code  and em.emp_code=ef.emp_code  and ef.firm_id=" & fir & "  And a.religion_id = r.religion_id  and a.appln_no = " & Request.QueryString("appln_no")
        dt = oh.ExecuteDataSet(str1).Tables(0)
        str2 = "select upper(qm.qualification),upper(qc.category),upper(aq.institution),upper(aq.university),aq.percentage,aq.year_pass from appln_qualif_dtl aq ,appln_pers_dtl a,qualification_master qm,qualification_category qc where a.appln_no=aq.appln_no and aq.qualification=qm.qualification_id and qc.category_id=qm.category_id and a.appln_no=" & Request.QueryString("appln_no")
        'str2 = "select upper(qm.qualification),  upper(qc.category),  upper(aq.institution),  upper(aq.university),  aq.percentage,  aq.year_pass  from appln_qualif_dtl       aq,  appln_pers_dtl         a,  qualification_master   qm,  qualification_category qc,  appln_interview_dtl api,  employee_master     em,  employ_firm         ef  where a.appln_no = aq.appln_no  and aq.qualification = qm.qualification_id  and qc.category_id = qm.category_id  and api.appln_no = a.appln_no  and api.emp_code = em.emp_code  and em.emp_code = ef.emp_code  and ef.firm_id =" & fir & "  and a.appln_no = " & Request.QueryString("appln_no")
        dt1 = oh.ExecuteDataSet(str2).Tables(0)
        str3 = "select ad.emp_mana,upper(ad.emp_name),upper(ad.emp_relation),ad.dir_mana,upper(ad.dir_name),upper(ad.dir_relation),upper(ad.ref1_name),upper(ad.ref1_add),ad.ref1_phone,upper(ad.ref2_name),upper(ad.ref2_add),ad.ref2_phone,ad.appln_dt,upper(ad.other_dtl) from appln_other_dtl ad,appln_pers_dtl a where a.appln_no=ad.appln_no and a.appln_no=" & Request.QueryString("appln_no")
        'str3 = "select ad.emp_mana,  upper(ad.emp_name),  upper(ad.emp_relation),  ad.dir_mana,  upper(ad.dir_name),  upper(ad.dir_relation),  upper(ad.ref1_name),  upper(ad.ref1_add),  ad.ref1_phone,  upper(ad.ref2_name),  upper(ad.ref2_add),  ad.ref2_phone,  ad.appln_dt,  upper(ad.other_dtl)  from appln_other_dtl ad, appln_pers_dtl a,appln_interview_dtl api,  employee_master     em,  employ_firm         ef  where a.appln_no = ad.appln_no  and api.appln_no = a.appln_no  and api.emp_code = em.emp_code  and em.emp_code = ef.emp_code  and ef.firm_id = " & fir & "  and a.appln_no = " & Request.QueryString("appln_no")
        dt2 = oh.ExecuteDataSet(str3).Tables(0)
        str3 = "select * from appln_exp_dtl where appln_no=" & Request.QueryString("appln_no")
        'str3 = "select a.*  from appln_exp_dtl       a,  appln_interview_dtl api,  employee_master     em,  employ_firm         ef  where api.appln_no = a.appln_no  and api.emp_code = em.emp_code  and em.emp_code = ef.emp_code  and ef.firm_id = " & fir & "  and appln_no = " & Request.QueryString("appln_no")
        dt3 = oh.ExecuteDataSet(str3).Tables(0)
        Dim atable As New Table
        Dim header As New TableRow
        Dim hcell As New TableCell
        header.Width = 10
        hcell.ColumnSpan = 10
        hcell.HorizontalAlign = HorizontalAlign.Center
        hcell.Text = "<b><font size=5 color=red >" & firm & " </font></b>"
        hcell.BackColor = Drawing.Color.Gold
        header.Controls.Add(hcell)
        atable.Controls.Add(header)
        Dim header1 As New TableRow
        Dim hcell1 As New TableCell
        header1.Width = 10
        hcell1.ColumnSpan = 10
        hcell1.BackColor = Drawing.Color.Gold
        hcell1.HorizontalAlign = HorizontalAlign.Center
        hcell1.Text = "<b><font size=2 color=red> " & frmadr.Rows(0)(0) & " </font></b>"
        header1.Controls.Add(hcell1)
        atable.Controls.Add(header1)
        Dim row3 As New TableRow
        Dim datecell As New TableCell
        Dim headcell As New TableCell
        Dim timecell As New TableCell
        row3.Width = 10
        datecell.ColumnSpan = 2
        headcell.ColumnSpan = 6
        timecell.ColumnSpan = 2
        datecell.HorizontalAlign = HorizontalAlign.Left
        headcell.HorizontalAlign = HorizontalAlign.Center
        timecell.HorizontalAlign = HorizontalAlign.Right
        datecell.Text = "<b><font size=2>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        row3.Controls.Add(datecell)
        timecell.Text = "<b><font size=2>Time :" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        row3.Controls.Add(headcell)
        row3.Controls.Add(timecell)
        atable.Controls.Add(row3)
        Dim row4 As New TableRow
        Dim subhead As New TableCell
        row4.Width = 10
        subhead.ColumnSpan = 10
        subhead.HorizontalAlign = HorizontalAlign.Center
        subhead.Text = "<b><font size=3>PERSONAL DATA FORM</font></b>"
        row4.Controls.Add(subhead)
        atable.Controls.Add(row4)
        Dim line As New TableRow
        Dim line1 As New TableCell
        line1.ColumnSpan = 10
        line1.Text = "<hr>"
        line.Controls.Add(line1)
        atable.Controls.Add(line)
        Dim i As Integer = 0
        For i = 0 To 4
            Dim blank As New TableRow
            blank.Width = 10
            atable.Controls.Add(blank)
        Next
        Dim no As New TableRow
        Dim no1 As New TableCell
        Dim no2 As New TableCell
        no1.HorizontalAlign = HorizontalAlign.Left
        no2.HorizontalAlign = HorizontalAlign.Left
        no1.ColumnSpan = 5
        no1.Text = "<b><font size=2>Application Number &nbsp:</font></b>"
        no2.Text = "<font size=2>" & Request.QueryString("appln_no") & "</font>"
        no.Controls.Add(no1)
        no.Controls.Add(no2)
        atable.Controls.Add(no)
        Dim blank1 As New TableRow
        blank1.Width = 10
        atable.Controls.Add(blank1)

        Dim name As New TableRow
        Dim name1 As New TableCell
        Dim name2 As New TableCell
        name1.HorizontalAlign = HorizontalAlign.Left
        name2.HorizontalAlign = HorizontalAlign.Left
        name1.ColumnSpan = 5
        name1.Text = "<b><font size=2>Name (As given in SSLC Book)&nbsp:</font></b>"
        name2.Text = "<font size=2>" & dt.Rows(0)(0) & "</font>"
        name.Controls.Add(name1)
        name.Controls.Add(name2)
        atable.Controls.Add(name)
        Dim blank2 As New TableRow
        blank2.Width = 10
        atable.Controls.Add(blank2)
        Dim arr As Array
        arr = Split(dt.Rows(0)(14), "/")
        Dim ayear As Date = Format(Date.Now, "dd/MMM/yyyy")
        Dim arr1 As Array
        arr1 = Split(ayear, "/")
        Dim age As Integer = arr1(2) - arr(2)
        Dim dob As New TableRow
        Dim dob1 As New TableCell
        Dim dob2 As New TableCell
        dob1.HorizontalAlign = HorizontalAlign.Left
        dob2.HorizontalAlign = HorizontalAlign.Left
        dob1.ColumnSpan = 5
        dob1.Text = "<b><font size=2>Date of Birth and Age&nbsp:</font></b>"
        dob2.Text = "<font size=2>" & dt.Rows(0)(14) & ",&nbsp&nbsp" & age & "</font></b>"
        dob.Controls.Add(dob1)
        dob.Controls.Add(dob2)
        atable.Controls.Add(dob)
        Dim blank3 As New TableRow
        blank3.Width = 10
        atable.Controls.Add(blank3)

        Dim permadd As New TableRow
        Dim peraddcell As New TableCell
        Dim peraddcell1 As New TableCell
        permadd.Width = 10
        peraddcell.ColumnSpan = 5
        peraddcell.HorizontalAlign = HorizontalAlign.Left
        peraddcell1.HorizontalAlign = HorizontalAlign.Left
        peraddcell.Text = "<b><font size=2>Permanant Address&nbsp:</font></b>"
        peraddcell1.Text = "<font size=2>" & dt.Rows(0)(1) & "</font>"
        permadd.Controls.Add(peraddcell)
        permadd.Controls.Add(peraddcell1)
        atable.Controls.Add(permadd)
        Dim blank4 As New TableRow
        blank4.Width = 10
        atable.Controls.Add(blank4)

        Dim post As New TableRow
        Dim postcell As New TableCell
        Dim postcell1 As New TableCell
        post.Width = 10
        postcell.ColumnSpan = 5
        postcell1.ColumnSpan = 5
        postcell.HorizontalAlign = HorizontalAlign.Left
        postcell1.HorizontalAlign = HorizontalAlign.Left
        postcell1.Text = "<font size=2>" & dt.Rows(0)(5) & "," & dt.Rows(0)(6) & "&nbsp&nbspDistict,</font>"
        post.Controls.Add(postcell)
        post.Controls.Add(postcell1)
        atable.Controls.Add(post)
        Dim blank5 As New TableRow
        blank5.Width = 10
        atable.Controls.Add(blank5)

        Dim state As New TableRow
        Dim statecell As New TableCell
        Dim statecell1 As New TableCell
        state.Width = 10
        statecell.ColumnSpan = 5
        statecell.HorizontalAlign = HorizontalAlign.Left
        statecell1.HorizontalAlign = HorizontalAlign.Left
        statecell1.Text = "<font size=2>" & dt.Rows(0)(7) & "<b>&nbsp&nbspPIN :</b> " & dt.Rows(0)(4) & "</font>"
        state.Controls.Add(statecell)
        state.Controls.Add(statecell1)
        atable.Controls.Add(state)
        Dim blank6 As New TableRow
        blank6.Width = 10
        atable.Controls.Add(blank6)


        Dim presadd As New TableRow
        Dim presaddcell As New TableCell
        Dim presaddcell1 As New TableCell
        presadd.Width = 10
        presaddcell.ColumnSpan = 5
        presaddcell.HorizontalAlign = HorizontalAlign.Left
        presaddcell1.HorizontalAlign = HorizontalAlign.Left
        presaddcell.Text = "<b><font size=2>Present Address&nbsp:</font></b>"
        presaddcell1.Text = "<font size=2>" & dt.Rows(0)(2) & "</font>"
        presadd.Controls.Add(presaddcell)
        presadd.Controls.Add(presaddcell1)
        atable.Controls.Add(presadd)
        Dim blank7 As New TableRow
        blank7.Width = 10
        atable.Controls.Add(blank7)

        Dim prepost As New TableRow
        Dim prepostcell As New TableCell
        Dim prepostcell1 As New TableCell
        prepost.Width = 10
        prepostcell.ColumnSpan = 5
        prepostcell1.ColumnSpan = 5
        prepostcell.HorizontalAlign = HorizontalAlign.Left
        prepostcell1.HorizontalAlign = HorizontalAlign.Left
        prepostcell1.Text = "<font size=2>" & dt.Rows(0)(9) & "," & dt.Rows(0)(10) & "&nbsp&nbspDistict,</font>"
        prepost.Controls.Add(prepostcell)
        prepost.Controls.Add(prepostcell1)
        atable.Controls.Add(prepost)
        Dim blank8 As New TableRow
        blank8.Width = 10
        atable.Controls.Add(blank8)

        Dim prestate As New TableRow
        Dim prestatecell As New TableCell
        Dim prestatecell1 As New TableCell
        prestate.Width = 10
        prestatecell.ColumnSpan = 5
        prestatecell.HorizontalAlign = HorizontalAlign.Left
        prestatecell1.HorizontalAlign = HorizontalAlign.Left
        prestatecell1.Text = "<font size=2>" & dt.Rows(0)(11) & "&nbsp&nbsp<b>PIN :</b> " & dt.Rows(0)(8) & "</font>"
        prestate.Controls.Add(prestatecell)
        prestate.Controls.Add(prestatecell1)
        atable.Controls.Add(prestate)
        Dim blank9 As New TableRow
        blank9.Width = 10
        atable.Controls.Add(blank9)

        Dim email As New TableRow
        Dim emailcell As New TableCell
        Dim emailcell1 As New TableCell
        email.Width = 10
        emailcell.ColumnSpan = 5
        emailcell.HorizontalAlign = HorizontalAlign.Left
        emailcell1.HorizontalAlign = HorizontalAlign.Left
        emailcell.Text = "<b><font size=2>E-mail&nbsp:</font></b>"
        emailcell1.Text = "<font size=2>" & dt.Rows(0)(17) & "</font>"
        email.Controls.Add(emailcell)
        email.Controls.Add(emailcell1)
        atable.Controls.Add(email)

        atable.Controls.Add(blank4)

        Dim phone1 As New TableRow
        Dim phone2 As New TableRow
        Dim phoneCell1 As New TableCell
        Dim phoneCell2 As New TableCell
        phone1.Width = 10
        phoneCell1.HorizontalAlign = HorizontalAlign.Left
        phoneCell1.ColumnSpan = 5
        phoneCell1.Text = "<b><font size=2>Two Contact Numbers&nbsp:</font></b>"
        phoneCell2.HorizontalAlign = HorizontalAlign.Left
        If dt.Rows(0)(27) = 0 Then
            phoneCell2.Text = "<b><font size=2>Residence:&nbsp;&nbsp;</b>" & dt.Rows(0)(12) & "</font>"
        ElseIf dt.Rows(0)(27) = 1 Then
            phoneCell2.Text = "<b><font size=2>Residence:&nbsp;&nbsp;</b>" & dt.Rows(0)(12) & "&nbsp;&nbsp;(PP) </font>"
        End If
        phone1.Controls.Add(phoneCell1)
        phone1.Controls.Add(phoneCell2)
        atable.Controls.Add(phone1)
        Dim phoneCell3 As New TableCell
        Dim phoneCell4 As New TableCell
        phone2.Width = 10
        phoneCell3.HorizontalAlign = HorizontalAlign.Left
        phoneCell3.ColumnSpan = 5
        phoneCell4.HorizontalAlign = HorizontalAlign.Left
        phoneCell4.Text = "<b><font size=2>Mobile:&nbsp;&nbsp;</b>" & dt.Rows(0)(13) & "</font>"
        phone2.Controls.Add(phoneCell3)
        phone2.Controls.Add(phoneCell4)
        atable.Controls.Add(phone2)
        Dim blanka As New TableRow
        blanka.Width = 10
        atable.Controls.Add(blanka)


        Dim gender As New TableRow
        Dim gencell As New TableCell
        Dim gencell1 As New TableCell
        gender.Width = 10
        gencell.HorizontalAlign = HorizontalAlign.Left
        gencell.ColumnSpan = 5
        gencell1.HorizontalAlign = HorizontalAlign.Left
        gencell.Text = "<b><font size=2>Gender&nbsp:</font></b>"
        gencell1.Text = "<font size=2>" & dt.Rows(0)(16) & "</font>"
        gender.Controls.Add(gencell)
        gender.Controls.Add(gencell1)
        atable.Controls.Add(gender)
        Dim blankd As New TableRow
        blankd.Width = 10
        atable.Controls.Add(blankd)

        Dim martial As New TableRow
        Dim martialcell As New TableCell
        Dim martialcell1 As New TableCell
        martial.Width = 10
        martialcell.ColumnSpan = 5
        martialcell.HorizontalAlign = HorizontalAlign.Left
        martialcell.Text = "<b><font size=2>Martial Status&nbsp:</font></b>"
        martialcell1.HorizontalAlign = HorizontalAlign.Left
        If IsDBNull(dt.Rows(0)(18)) Then
            martialcell1.Text = "Not Specified "
        ElseIf dt.Rows(0)(18) = 1 Then
            martialcell1.Text = "Single"
        ElseIf dt.Rows(0)(18) = 2 Then
            martialcell1.Text = "Married"
        End If
        martial.Controls.Add(martialcell)
        martial.Controls.Add(martialcell1)
        atable.Controls.Add(martial)
        Dim blankb As New TableRow
        blankb.Width = 10
        atable.Controls.Add(blankb)

        Dim fname As New TableRow
        Dim fnamecell As New TableCell
        Dim fnamecell1 As New TableCell
        fname.Width = 10
        fnamecell.ColumnSpan = 5
        fnamecell.HorizontalAlign = HorizontalAlign.Left
        If dt.Rows(0)(15) = 1 And dt.Rows(0)(18) = 2 And Not IsDBNull(dt.Rows(0)(19)) Then
            fnamecell.Text = "<b><font size=2>Husband's Name&nbsp:</font></b>"
            fnamecell1.HorizontalAlign = HorizontalAlign.Left
            fnamecell1.Text = "<font size=2>" & dt.Rows(0)(19) & "</font>"
            Dim child As New TableRow
            Dim child1 As New TableCell
            Dim child2 As New TableCell
            child.Width = 10
            child1.ColumnSpan = 5
            child1.HorizontalAlign = HorizontalAlign.Left
            child2.HorizontalAlign = HorizontalAlign.Left
            child1.Text = "<b><font size=2>No of Children&nbsp:</font></b>"
            If IsDBNull(dt.Rows(0)(20)) Then
                child2.Text = "<font size=2>" & 0 & "</font>"
            Else
                child2.Text = "<font size=2>" & dt.Rows(0)(20) & "</font>"
            End If
            child.Controls.Add(child1)
            child.Controls.Add(child2)
            atable.Controls.Add(child)
        Else
            fnamecell.Text = "<b><font size=2>Father's Name&nbsp:</font></b>"
            fnamecell1.HorizontalAlign = HorizontalAlign.Left
            fnamecell1.Text = "<font size=2>" & dt.Rows(0)(3) & "</font>"
        End If
        fname.Controls.Add(fnamecell)
        fname.Controls.Add(fnamecell1)
        atable.Controls.Add(fname)
        Dim blankc As New TableRow
        blankc.Width = 10
        atable.Controls.Add(blankc)
        Dim docrow As New TableRow
        Dim docrowno As New TableRow
        Dim doccell1, doccell2, doccell3, doccell4 As New TableCell
        docrow.Width = 10
        docrowno.Width = 10
        doccell1.ColumnSpan = 5
        doccell3.ColumnSpan = 5
        doccell1.HorizontalAlign = HorizontalAlign.Left
        doccell1.Text = "<b><font size=2>Details of Document Identity Number</font></b>"
        doccell2.HorizontalAlign = HorizontalAlign.Left
        doccell2.Text = "<font size=2>" & dt.Rows(0)(22) & "</font>"
        docrow.Controls.Add(doccell1)
        docrow.Controls.Add(doccell2)
        doccell3.HorizontalAlign = HorizontalAlign.Right
        doccell4.HorizontalAlign = HorizontalAlign.Left
        'doccell3.Text = "<b><font size=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbspNo&nbsp:&nbsp</font></b>"
        doccell4.Text = "<b><font size=2>&nbsp;&nbsp;No&nbsp:&nbsp</b>" & dt.Rows(0)(23) & "<font>"
        docrowno.Controls.Add(doccell3)
        docrowno.Controls.Add(doccell4)
        atable.Controls.Add(docrow)
        atable.Controls.Add(docrowno)
        Dim blankf As New TableRow
        blankf.Width = 10
        atable.Controls.Add(blankf)

        Dim blood As New TableRow
        Dim blood1, blood2 As New TableCell
        blood.Width = 10
        blood1.ColumnSpan = 5
        blood1.HorizontalAlign = HorizontalAlign.Left
        blood2.HorizontalAlign = HorizontalAlign.Left
        blood1.Text = "<b><font size=2>Blood Group&nbsp:</font></b>"
        blood2.Text = "<font size=2>" & dt.Rows(0)(21) & "</font>"
        blood.Controls.Add(blood1)
        blood.Controls.Add(blood2)
        atable.Controls.Add(blood)
        Dim blankg As New TableRow
        blankg.Width = 10
        atable.Controls.Add(blankg)
        Dim religion As New TableRow
        Dim religion1, religion2 As New TableCell
        religion.Width = 10
        religion1.ColumnSpan = 5
        religion1.HorizontalAlign = HorizontalAlign.Left
        religion2.HorizontalAlign = HorizontalAlign.Left
        religion1.Text = "<b><font size=2>Religion And Caste&nbsp:</font></b>"
        If IsDBNull(dt.Rows(0)(25)) Then
            religion2.Text = "<font size=2>" & dt.Rows(0)(24) & "&nbsp;&nbsp;<b>Caste</b>&nbsp;:&nbsp;NA</font>"
        Else
            religion2.Text = "<font size=2>" & dt.Rows(0)(24) & "<b>&nbsp;&nbsp;Caste</b>&nbsp:&nbsp" & dt.Rows(0)(25) & "</font>"
        End If
        religion.Controls.Add(religion1)
        religion.Controls.Add(religion2)
        atable.Controls.Add(religion)
        Dim blankh As New TableRow
        blankh.Width = 10
        atable.Controls.Add(blankh)
        Dim blankz As New TableRow
        blankz.Width = 10
        atable.Controls.Add(blankz)
        If dt1.Rows.Count > 0 Then
            Dim qualrow As New TableRow
            Dim qualcell1 As New TableCell
            qualrow.Width = 10
            qualcell1.ColumnSpan = 10
            qualcell1.HorizontalAlign = HorizontalAlign.Left
            qualcell1.Text = "<b><font size=3>Qualifications :</font></b>"
            qualrow.Controls.Add(qualcell1)
            atable.Controls.Add(qualrow)
            Dim linea As New TableRow
            Dim line1a As New TableCell
            line1a.ColumnSpan = 10
            line1a.Text = "<hr>"
            linea.Controls.Add(line1a)
            atable.Controls.Add(linea)

            Dim qr1 As New TableRow
            qr1.Attributes.Add("border", 1)
            qr1.Width = 10
            qr1.BorderStyle = BorderStyle.Solid
            'qr1.BorderWidth = 1
            qr1.BorderColor = Drawing.Color.Black
            Dim qc1 As New TableCell
            qc1.ColumnSpan = 1
            qc1.HorizontalAlign = HorizontalAlign.Left
            Dim qca As New TableCell
            qca.ColumnSpan = 2
            qca.HorizontalAlign = HorizontalAlign.Left
            Dim qc2 As New TableCell
            qc2.ColumnSpan = 2
            qc2.HorizontalAlign = HorizontalAlign.Left
            Dim qc3 As New TableCell
            qc3.ColumnSpan = 2
            qc3.HorizontalAlign = HorizontalAlign.Left
            Dim qc4 As New TableCell
            qc4.ColumnSpan = 2
            qc4.HorizontalAlign = HorizontalAlign.Left
            Dim qc5 As New TableCell
            qc5.ColumnSpan = 1
            qc5.HorizontalAlign = HorizontalAlign.Left
            qc1.Text = "<b><font size=2>SI No.</font></b>"
            qca.Text = "<b><font size=2>Category</font></b>"
            qc2.Text = "<b><font size=2>Exams Passed</font></b>"
            qc3.Text = "<b><font size=2>College/University</font></b>"
            qc4.Text = "<b><font size=2>Year of Passing</font></b>"
            qc5.Text = "<b><font size=2>Class&nbsp/&nbsp% of Marks</font></b>"
            qr1.Controls.Add(qc1)
            qr1.Controls.Add(qca)
            qr1.Controls.Add(qc2)
            qr1.Controls.Add(qc3)
            qr1.Controls.Add(qc4)
            qr1.Controls.Add(qc5)
            atable.Controls.Add(qr1)
            Dim w As Integer = 0
            Dim lines As New TableRow
            Dim line1s As New TableCell
            line1s.ColumnSpan = 10
            line1s.Text = "<hr>"
            lines.Controls.Add(line1s)
            atable.Controls.Add(lines)

            For Each dr In dt1.Rows
                Dim qual As New TableRow
                qual.Width = 10
                Dim qw1, qwa, qw2, qw3, qw4, qw5 As New TableCell
                qw1.ColumnSpan = 0.5
                qwa.ColumnSpan = 2.5
                qw2.ColumnSpan = 2
                qw3.ColumnSpan = 2
                qw4.ColumnSpan = 2
                qw5.ColumnSpan = 1
                qw1.HorizontalAlign = HorizontalAlign.Left
                qwa.HorizontalAlign = HorizontalAlign.Left
                qw2.HorizontalAlign = HorizontalAlign.Left
                qw3.HorizontalAlign = HorizontalAlign.Left
                qw4.HorizontalAlign = HorizontalAlign.Left
                qw5.HorizontalAlign = HorizontalAlign.Left
                w = w + 1
                qw1.Text = "<font size=2>" & w & "</font>"
                qwa.Text = "<font size=2>" & dr(1) & "</font>"
                qw2.Text = "<font size=2>" & dr(0) & "</font>"
                If IsDBNull(dr(2)) Then
                    qw3.Text = "<font size=2>" & dr(3) & "</font>"
                Else
                    qw3.Text = "<font size=2>" & dr(2) & "</font>"
                End If
                qw4.Text = "<font size=2>" & dr(5) & "</font>"
                qw5.Text = "<font size=2>" & dr(4) & "</font>"
                qual.Controls.Add(qw1)
                qual.Controls.Add(qwa)
                qual.Controls.Add(qw2)
                qual.Controls.Add(qw3)
                qual.Controls.Add(qw4)
                qual.Controls.Add(qw5)
                atable.Controls.Add(qual)
            Next
            Dim lineb As New TableRow
            Dim line1b As New TableCell
            line1b.ColumnSpan = 10
            line1b.Text = "<hr>"
            lineb.Controls.Add(line1b)
            atable.Controls.Add(lineb)
        Else
            Dim label As New TableRow
            Dim label2 As New TableCell
            label.Width = 10
            label2.ColumnSpan = 10
            label2.HorizontalAlign = HorizontalAlign.Center
            label2.Text = "<b><font size=2>NO QUALIFICATIONS SPECIFIED!</font></b>"
            label.Controls.Add(label2)
            atable.Controls.Add(label)
        End If

        Dim blankn As New TableRow
        blankn.Width = 10
        atable.Controls.Add(blankn)
        atable.Controls.Add(blankn)


        Dim k As Integer
        For k = 0 To 5
            Dim bba As New TableRow
            atable.Controls.Add(bba)
        Next k
        'qr1.Attributes.Add("border", 1)
        'qr1.Width = 10
        'qr1.BorderStyle = BorderStyle.Solid
        ''qr1.BorderWidth = 1
        'qr1.BorderColor = Drawing.Color.Black

        If dt3.Rows.Count > 0 Then
            Dim exprow As New TableRow
            Dim expcell1 As New TableCell
            exprow.Width = 10
            expcell1.ColumnSpan = 10
            expcell1.HorizontalAlign = HorizontalAlign.Left
            expcell1.Text = "<b><font size=3>Previous Experience :</font></b>"
            exprow.Controls.Add(expcell1)
            atable.Controls.Add(exprow)
            Dim er1 As New TableRow
            er1.Attributes.Add("border", 1)
            er1.Width = 10
            er1.BorderStyle = BorderStyle.Solid
            er1.BorderColor = Drawing.Color.Black
            Dim ec1 As New TableCell
            ec1.ColumnSpan = 1
            ec1.HorizontalAlign = HorizontalAlign.Left
            Dim linebf As New TableRow
            Dim line1bf As New TableCell
            line1bf.ColumnSpan = 10
            line1bf.Text = "<hr>"
            linebf.Controls.Add(line1bf)
            atable.Controls.Add(linebf)

            Dim eca As New TableCell
            eca.ColumnSpan = 1
            eca.HorizontalAlign = HorizontalAlign.Left
            Dim ec2 As New TableCell
            ec2.ColumnSpan = 1
            ec2.HorizontalAlign = HorizontalAlign.Left
            Dim ec3 As New TableCell
            ec3.ColumnSpan = 1
            ec3.HorizontalAlign = HorizontalAlign.Left
            Dim ec4 As New TableCell
            ec4.ColumnSpan = 1
            ec4.HorizontalAlign = HorizontalAlign.Left
            Dim ec5 As New TableCell
            ec5.ColumnSpan = 1
            ec5.HorizontalAlign = HorizontalAlign.Left
            Dim ec6 As New TableCell
            ec6.ColumnSpan = 1
            ec6.HorizontalAlign = HorizontalAlign.Left
            Dim ec7 As New TableCell
            ec7.ColumnSpan = 1
            ec7.HorizontalAlign = HorizontalAlign.Left
            Dim ec8 As New TableCell
            ec8.ColumnSpan = 1
            ec8.HorizontalAlign = HorizontalAlign.Left
            ec1.Text = "<b><font size=2>Organisation</font></b>"
            eca.Text = "<b><font size=2>Designation</font></b>"
            ec2.Text = "<b><font size=2>Experience fromdate</font></b>"
            ec3.Text = "<b><font size=2>Experience todate</font></b>"
            ec4.Text = "<b><font size=2>Nature of Duty</font></b>"
            ec5.Text = "<b><font size=2>Relieving Reason</font></b>"
            ec6.Text = "<b><font size=2>Contact Person</font></b>"
            ec7.Text = "<b><font size=2>Contact Phone</font></b>"
            ec8.Text = "<b><font size=2>Present Salary</font></b>"
            er1.Controls.Add(ec1)
            er1.Controls.Add(eca)
            er1.Controls.Add(ec2)
            er1.Controls.Add(ec3)
            er1.Controls.Add(ec4)
            er1.Controls.Add(ec5)
            er1.Controls.Add(ec6)
            er1.Controls.Add(ec7)
            er1.Controls.Add(ec8)
            atable.Controls.Add(er1)
            Dim line9 As New TableRow
            Dim line19 As New TableCell
            line19.ColumnSpan = 10
            line19.Text = "<hr>"
            line9.Controls.Add(line19)
            atable.Controls.Add(line9)
            For Each dr In dt3.Rows
                Dim expn As New TableRow
                expn.Width = 10
                Dim expn1, expn2, expn3, expn4, expn5, expn6, expn7, expn8, expn9 As New TableCell
                expn1.ColumnSpan = 1
                expn2.ColumnSpan = 1
                expn3.ColumnSpan = 1
                expn4.ColumnSpan = 1
                expn5.ColumnSpan = 1
                expn6.ColumnSpan = 1
                expn7.ColumnSpan = 1
                expn8.ColumnSpan = 1
                expn9.ColumnSpan = 1
                expn1.HorizontalAlign = HorizontalAlign.Left
                expn2.HorizontalAlign = HorizontalAlign.Left
                expn3.HorizontalAlign = HorizontalAlign.Left
                expn4.HorizontalAlign = HorizontalAlign.Left
                expn5.HorizontalAlign = HorizontalAlign.Left
                expn6.HorizontalAlign = HorizontalAlign.Left
                expn7.HorizontalAlign = HorizontalAlign.Left
                expn8.HorizontalAlign = HorizontalAlign.Left
                expn9.HorizontalAlign = HorizontalAlign.Left
                expn1.Text = "<font size=2>" & (dr(1)).ToString.ToUpper & "</font>"
                expn2.Text = "<font size=2>" & dr(2).ToString.ToUpper & "</font>"
                expn3.Text = "<font size=2>" & Format(dr(3), "dd/MMM/yyyy") & "</font>"
                expn4.Text = "<font size=2>" & Format(dr(4), "dd/MMM/yyyy") & "</font>"
                expn5.Text = "<font size=2>" & (dr(5)).ToString.ToUpper & "</font>"
                expn6.Text = "<font size=2>" & (dr(6)).ToString.ToUpper & "</font>"
                expn7.Text = "<font size=2>" & (dr(7)).ToString.ToUpper & "</font>"
                expn8.Text = "<font size=2>" & dr(8) & "</font>"
                expn9.Text = "<font size=2>" & dr(9) & "</font>"
                expn.Controls.Add(expn1)
                expn.Controls.Add(expn1)
                expn.Controls.Add(expn2)
                expn.Controls.Add(expn3)
                expn.Controls.Add(expn4)
                expn.Controls.Add(expn5)
                expn.Controls.Add(expn6)
                expn.Controls.Add(expn7)
                expn.Controls.Add(expn8)
                expn.Controls.Add(expn9)
                atable.Controls.Add(expn)
            Next
            atable.Controls.Add(blankh)

            Dim linebk As New TableRow
            Dim line1bk As New TableCell
            line1bk.ColumnSpan = 10
            line1bk.Text = "<hr>"
            linebk.Controls.Add(line1bk)
            atable.Controls.Add(linebk)
        End If
        Dim blanks As New TableRow
        blanks.Width = 10
        atable.Controls.Add(blanks)

        Dim emp As New TableRow
        Dim empa As New TableRow
        Dim empb As New TableRow
        Dim emp1 As New TableCell
        Dim emp2 As New TableCell
        Dim empe As New TableCell
        Dim empname As New TableCell
        Dim emprel As New TableCell
        empname.HorizontalAlign = HorizontalAlign.Left
        emprel.HorizontalAlign = HorizontalAlign.Left
        emp.Width = 10
        emp1.ColumnSpan = 5
        emp1.HorizontalAlign = HorizontalAlign.Left
        'emp2.HorizontalAlign = HorizontalAlign.Left
        emp2.HorizontalAlign = HorizontalAlign.Right
        emp2.ColumnSpan = 5
        empe.ColumnSpan = 5
        empe.HorizontalAlign = HorizontalAlign.Right
        emp1.Text = "<b><font size=2>Specify relatives,if any,employed in Manappuram Group&nbsp:</font></b>"
        'emp2.Text = "<b><font size=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1. Name &nbsp :</font></b>"
        emp2.Text = "<b><font size=2>1. Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</font></b>"
        'empe.Text = "<b><font size=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2.Relationship &nbsp :</font></b>"
        empe.Text = "<b><font size=2>2.Relationship &nbsp :</font></b>"
        If dt2.Rows.Count > 0 Then
            If (IsDBNull(dt2.Rows(0)(1)) And IsDBNull(dt2.Rows(0)(0))) Then
                empname.Text = "<font size=2>Not Specified</font>"
            Else
                empname.Text = "<font size=2>" & dt2.Rows(0)(1) & "</font>"
                emprel.Text = "<font size=2>" & dt2.Rows(0)(2) & "</font>"
            End If
        Else
            empname.Text = "<font size=2>Not Specified</font>"
        End If
        emp.Controls.Add(emp1)
        empa.Controls.Add(emp2)
        empa.Controls.Add(empname)
        empb.Controls.Add(empe)
        empb.Controls.Add(emprel)
        atable.Controls.Add(emp)
        Dim blankl As New TableRow
        blankl.Width = 10
        atable.Controls.Add(blankl)

        atable.Controls.Add(empa)
        atable.Controls.Add(empb)
        blankg.Width = 10
        atable.Controls.Add(blankg)
        atable.Controls.Add(blankh)


        Dim dir As New TableRow
        Dim dira As New TableRow
        Dim dirb As New TableRow
        Dim dir1 As New TableCell
        Dim dir2 As New TableCell
        Dim dire As New TableCell
        Dim dirname As New TableCell
        Dim dirrel As New TableCell
        dirname.HorizontalAlign = HorizontalAlign.Left
        dirrel.HorizontalAlign = HorizontalAlign.Left
        dir.Width = 10
        dir1.ColumnSpan = 5
        dir1.HorizontalAlign = HorizontalAlign.Left
        dir2.HorizontalAlign = HorizontalAlign.Right
        dir2.ColumnSpan = 5
        dire.ColumnSpan = 5
        dire.HorizontalAlign = HorizontalAlign.Right
        dir1.Text = "<b><font size=2>Specify relationship with directirs,if any&nbsp:</font></b>"

        dir2.Text = "<b><font size=2>Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</font></b>"
        dire.Text = "<b><font size=2>Relationship &nbsp :</font></b>"
        If dt2.Rows.Count > 0 Then
            If (IsDBNull(dt2.Rows(0)(3)) And IsDBNull(dt2.Rows(0)(4))) Then
                dirname.Text = "<font size=2>Not Specified</font>"
            Else
                dirname.Text = "<font size=2>" & dt2.Rows(0)(4) & "</font>"
                dirrel.Text = "<font size=2>" & dt2.Rows(0)(5) & "</font>"
            End If
        Else
            dirname.Text = "<font size=2>Not Specified</font>"
        End If
        dir.Controls.Add(dir1)
        dira.Controls.Add(dir2)
        dira.Controls.Add(dirname)
        dirb.Controls.Add(dire)
        dirb.Controls.Add(dirrel)
        atable.Controls.Add(dir)
        atable.Controls.Add(dira)
        atable.Controls.Add(dirb)
        blankg.Width = 10
        atable.Controls.Add(blankg)
        atable.Controls.Add(blankh)


        Dim ref As New TableRow
        Dim refa As New TableRow
        Dim refb As New TableRow
        Dim refc As New TableRow
        Dim ref1 As New TableCell
        Dim ref2 As New TableCell
        Dim refe As New TableCell
        Dim refname As New TableCell
        Dim refrel As New TableCell
        Dim refph As New TableCell
        Dim refphc As New TableCell
        refname.HorizontalAlign = HorizontalAlign.Left
        refrel.HorizontalAlign = HorizontalAlign.Left
        ref.Width = 10
        ref1.ColumnSpan = 5
        refphc.ColumnSpan = 5
        ref1.HorizontalAlign = HorizontalAlign.Left
        ref2.HorizontalAlign = HorizontalAlign.Right
        refphc.HorizontalAlign = HorizontalAlign.Right
        refph.HorizontalAlign = HorizontalAlign.Left
        ref2.ColumnSpan = 5
        refe.ColumnSpan = 5
        'refb.Height = 1
        refe.HorizontalAlign = HorizontalAlign.Left
        ref1.Text = "<b><font size=2>Reference&nbsp:</font></b>"

        ref2.Text = "<b><font size=2>a)Govt Employee &nbsp :</font></b>"
        refphc.Text = "<b><font size=2>&nbsp;&nbsp;&nbsp;&nbspPhone No&nbsp :</font></b>"
        If dt2.Rows.Count > 0 Then
            If (IsDBNull(dt2.Rows(0)(3)) And IsDBNull(dt2.Rows(0)(4))) Then
                refname.Text = "<font size=2>Not Specified</font>"
            Else
                refname.Text = "<font size=2>" & dt2.Rows(0)(6) & "</font>"
                refrel.Text = "<font size=2>" & dt2.Rows(0)(7) & "</font>"
                refph.Text = "<font size=2>" & dt2.Rows(0)(8) & "</font>"
            End If
        Else
            refname.Text = "<font size=2>Not Specified</font>"
        End If
        ref.Controls.Add(ref1)
        refa.Controls.Add(ref2)
        refa.Controls.Add(refname)
        refb.Controls.Add(refe)
        refb.Controls.Add(refrel)
        refc.Controls.Add(refphc)
        refc.Controls.Add(refph)
        atable.Controls.Add(ref)
        atable.Controls.Add(refa)
        atable.Controls.Add(refb)
        atable.Controls.Add(refc)
        blankg.Width = 10
        atable.Controls.Add(blankg)
        atable.Controls.Add(blankh)

        Dim refr2 As New TableRow
        Dim refa2 As New TableRow
        Dim refb2 As New TableRow
        Dim refc2 As New TableRow
        Dim ref12 As New TableCell
        Dim ref22 As New TableCell
        Dim refe2 As New TableCell
        Dim refname2 As New TableCell
        Dim refrel2 As New TableCell
        Dim refpha As New TableCell
        Dim refph2 As New TableCell
        refname2.HorizontalAlign = HorizontalAlign.Left
        refrel2.HorizontalAlign = HorizontalAlign.Left
        refr2.Width = 10
        ref12.ColumnSpan = 5
        ref12.HorizontalAlign = HorizontalAlign.Left
        ref22.HorizontalAlign = HorizontalAlign.Right
        refpha.HorizontalAlign = HorizontalAlign.Right
        refph2.HorizontalAlign = HorizontalAlign.Left
        ref22.ColumnSpan = 5
        refe2.ColumnSpan = 5
        refpha.ColumnSpan = 5
        refe2.HorizontalAlign = HorizontalAlign.Left
        ref22.Text = "<b><font size=2>b)Others&nbsp &nbsp :</font></b>"
        refpha.Text = "<b><font size=2>&nbsp;&nbsp;&nbsp;&nbspPhone No&nbsp :</font></b>"
        If dt2.Rows.Count > 0 Then
            If (IsDBNull(dt2.Rows(0)(3)) And IsDBNull(dt2.Rows(0)(4))) Then
                refname2.Text = "<font size=2>Not Specified</font>"
            Else
                refname2.Text = "<font size=2>" & dt2.Rows(0)(9) & "</font>"
                refrel2.Text = "<font size=2>" & dt2.Rows(0)(10) & "</font>"
                refph2.Text = "<font size=2>" & dt2.Rows(0)(11) & "</font>"
            End If
        Else
            refname2.Text = "<font size=2>Not Specified</font>"
        End If
        refr2.Controls.Add(ref12)
        refa2.Controls.Add(ref22)
        refa2.Controls.Add(refname2)
        refb2.Controls.Add(refe2)
        refb2.Controls.Add(refrel2)
        refc2.Controls.Add(refpha)
        refc2.Controls.Add(refph2)
        atable.Controls.Add(refr2)
        atable.Controls.Add(refa2)
        atable.Controls.Add(refb2)
        atable.Controls.Add(refc2)
        blankg.Width = 10

        For k = 0 To 5
            atable.Controls.Add(blankg)
        Next k
        Dim other As New TableRow
        Dim other1 As New TableCell
        Dim other2 As New TableCell
        other.Width = 10
        other1.ColumnSpan = 5
        other1.HorizontalAlign = HorizontalAlign.Left
        other2.HorizontalAlign = HorizontalAlign.Left
        other1.Text = "<b><font size=2>Other Details&nbsp:</font></b>"
        If dt2.Rows.Count > 0 Then
            If IsDBNull(dt2.Rows(0)(13)) Then
                other2.Text = "<font size=2>Not Specified</font>"
            Else
                other2.Text = "<font size=2>" & dt2.Rows(0)(13) & "</font>"
            End If
        End If
        other.Controls.Add(other1)
        other.Controls.Add(other2)
        atable.Controls.Add(other)
        For k = 0 To 5
            atable.Controls.Add(blankg)
        Next k

        Dim dater As New TableRow
        Dim dater1 As New TableCell
        Dim dater2 As New TableCell
        dater.Width = 10
        dater1.ColumnSpan = 5
        dater1.HorizontalAlign = HorizontalAlign.Left
        dater2.HorizontalAlign = HorizontalAlign.Left
        dater1.Text = "<b><font size=2>Date&nbsp:</font></b>"
        If dt2.Rows.Count > 0 Then
            dater2.Text = "<font size=2>" & Format(dt2.Rows(0)(12), "dd/MMM/yyyy") & "</font>"
        Else
            dater2.Text = "<font size=2>Not Specified</font>"
        End If
        dater.Controls.Add(dater1)
        dater.Controls.Add(dater2)
        atable.Controls.Add(dater)
        Dim lined As New TableRow
        Dim line1d As New TableCell
        line1d.ColumnSpan = 10
        line1d.Text = "<hr>"
        lined.Controls.Add(line1d)
        atable.Controls.Add(lined)
        Dim frel As New TableRow
        frel.Width = 10
        Dim freel As New TableCell
        freel.ColumnSpan = 10
        freel.HorizontalAlign = HorizontalAlign.Center
        freel.Text = "<b><u><font size=3>FOR OFFICE USE ONLY</font></u></b>"
        frel.Controls.Add(freel)
        atable.Controls.Add(frel)
        Dim bb As Integer
        For bb = 1 To 35
            Dim free As New TableRow
            free.Width = 10
            Dim free1 As New TableCell
            free1.ColumnSpan = 10
            free.Controls.Add(free1)
            atable.Controls.Add(free)
        Next
        Dim lineaa As New TableRow
        Dim line1aa As New TableCell
        line1aa.ColumnSpan = 10
        line1aa.Text = "<hr>"
        lineaa.Controls.Add(line1aa)
        atable.Controls.Add(lineaa)

        Panel1.Controls.Add(atable)
    End Sub
End Class
