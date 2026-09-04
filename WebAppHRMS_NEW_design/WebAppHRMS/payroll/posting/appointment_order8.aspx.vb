Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Appointment_Order_appointment_order_a847782c6210
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim report As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt, dthra, dtallow, dtmin, pf_cuttoff, pfrt, pfamt, esirt, esi, pfrate, esirate As DataTable
        dt = oh.ExecuteDataSet("select upper(e.emp_name) as emp_name,upper(ap.pres_add1) as pres_add1,upper(post2.post_office) as post_office,upper(dis2.district_name) as district,upper(state2.state_name) as state,post2.pin_code,upper(ap.father_name) as father_name,upper(ap.spouse_name) as spouse_name,ap.sex,ap.marital_status,e.emp_type,ep.from_dt,nvl(e.security_dep, 0) as security_dep,upper(f.firm_name) as firm_name,upper(d.designation) as designation,nvl(ep.basic_pay, 0) as basic_pay,ep.payment_id,ep.designation_Id ,upper(p.post_name),e.rejoining from employee_master      e,employ_personal_dtl  ap,post_master          post2,district_master      dis2,state_master         state2,firm_master          f,designation_master   d,post_mst p ,employ_transfer_dtl et ,employ_promotion_dtl ep where e.emp_code = " & Request.QueryString("empid") & " and e.emp_code=et.emp_code and et.status_id=1 and e.post_id=p.post_id and e.emp_code = ap.emp_code and ap.pres_pin = post2.sr_number and post2.district_id = dis2.district_id and dis2.state_id = state2.state_id and e.firm_id = f.firm_id and ep.designation_id = d.designation_id and e.emp_code = ep.emp_code and ep.from_dt in (select min(pe.from_dt) from employ_promotion_dtl pe where pe.emp_code = " & Request.QueryString("empid") & ")").Tables(0)
        dthra = oh.ExecuteDataSet("select nvl(sum(t.amount),0) from hrm_ta_all_append t where t.all_id=61 and t.emp_code= " & Request.QueryString("empid") & "").Tables(0)
        dtallow = oh.ExecuteDataSet("select nvl(sum(t.amount),0) from hrm_ta_all_append t where t.all_id!=61 and t.emp_code= " & Request.QueryString("empid") & "").Tables(0)
        If dt.Rows.Count = 0 Then
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('Incomplete Data found for this Employee');")
            script1.Append("window.open('appointmentorder.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        Dim father_or_spouse As String = ""
        If dt.Rows(0)(8) = 0 And dt.Rows(0)(9) = 2 Then
            father_or_spouse = "W/o " & dt.Rows(0)(7)
        ElseIf dt.Rows(0)(8) = 1 Then
            father_or_spouse = "S/o " & dt.Rows(0)(6)
        ElseIf dt.Rows(0)(8) = 0 Then
            father_or_spouse = "D/o " & dt.Rows(0)(6)
        End If

        Dim secamt, basic As String
        secamt = getWords(dt.Rows(0)(12))
        Dim jndate As Date
        jndate = Format(dt.Rows(0)(11), "dd/MMM/yyyy")
        Dim jday As String = jndate.DayOfWeek.ToString
        Dim frd As Integer = Session("firm_id")
        Dim vda As Integer
        Dim basicamt As String
        'If (dt.Rows(0)(16) = 14 Or dt.Rows(0)(17) = 34 Or dt.Rows(0)(17) = 35) Then
        basicamt = dt.Rows(0)(15)
        'Else
        'Dim da As DataTable = oh.ExecuteDataSet("select d.value from employ_promotion_dtl ep,da_index d where ep.emp_code=" & Request.QueryString("empid") & " and ep.from_dt in(select min(pe.from_dt) from employ_promotion_dtl pe where pe.emp_code=" & Request.QueryString("empid") & ") and ((ep.from_dt >= d.from_dt and ep.from_dt <=d.to_dt) or (ep.from_dt >= d.from_dt and d.to_dt is null and d.firm_id=8))").Tables(0)
        Dim da As DataTable = oh.ExecuteDataSet("SELECT t.value FROM DA_INDEX T, EMPLOYEE_MASTER E WHERE E.EMP_CODE =" & Request.QueryString("empid") & " AND E.JOIN_DT BETWEEN T.FROM_DT AND T.TO_DT AND T.FIRM_ID =8").Tables(0)
        'basicamt = dt.Rows(0)(15) + da.Rows(0)(0)
        If (da.Rows.Count) > 0 Then
            vda = da.Rows(0)(0)
        Else
            Dim da1 As DataTable = oh.ExecuteDataSet("SELECT t.value FROM DA_INDEX T, EMPLOYEE_MASTER E WHERE E.EMP_CODE =" & Request.QueryString("empid") & " and t.to_dt is null AND T.FIRM_ID = 8").Tables(0)
            vda = da1.Rows(0)(0)
        End If

        'End If
        '=======
        pf_cuttoff = oh.ExecuteDataSet("select a.parmtr_value as pf_cutoff from general_parameter a where a.module_id=33 and a.firm_id=1 and a.parmtr_id=6").Tables(0)
        pfrt = oh.ExecuteDataSet("select a.parmtr_value as pfrt from general_parameter a where a.module_id=33 and a.firm_id=1 and a.parmtr_id=7").Tables(0)

        esirt = oh.ExecuteDataSet("select a.parmtr_value as esi_rt from general_parameter a where a.module_id=33 and a.firm_id=1 and a.parmtr_id=8").Tables(0)
        dtmin = oh.ExecuteDataSet("select min(t.basic_pay) from employee_master t where t.firm_id=8 and t.status_id=1").Tables(0)
        Dim gross, epf As Integer
        Dim bonusmin As Integer = dtmin.Rows(0)(0)
        Dim bonusamt As Integer

        Dim hra, allow As Integer
        If IsDBNull(dthra.Rows(0)(0)) Then
            hra = 0
        Else
            hra = dthra.Rows(0)(0)
        End If

        If IsDBNull(dtallow.Rows(0)(0)) Then
            allow = 0
        Else
            allow = dtallow.Rows(0)(0)
        End If

        gross = (basicamt + vda + allow + hra)
        'Dim grosspfrt = gross * pfrt.Rows(0)(0)
        'Dim availsalry As Integer = (basicamt + vda) * (3.25)
        'pfamt = oh.ExecuteDataSet("select least(round(('" & grosspfrt & "')/100,0),'" & pf_cuttoff.Rows(0)(0) & "') from dual").Tables(0)
        pfrate = oh.ExecuteDataSet("select a.parmtr_value from general_parameter a where a.module_id=33 and a.firm_id=1 and a.parmtr_id=103").Tables(0)
        'esi = oh.ExecuteDataSet("select ceil('" & availsalry & "'/100) from dual").Tables(0)
        esirate = oh.ExecuteDataSet("select a.parmtr_value from general_parameter a where a.module_id=33 and a.firm_id=1 and a.parmtr_id=104").Tables(0)
        Dim esiamt As Integer
        If gross >= 15000 Then
            'epf = pfamt.Rows(0)(0) + (15000 * 0.5) / 100
            epf = 15000 * pfrate.Rows(0)(0) / 100
        Else
            'epf = pfamt.Rows(0)(0) + (gross * 0.5) / 100
            epf = gross * pfrate.Rows(0)(0) / 100
        End If
        If gross < 21000 Then
            bonusamt = (bonusmin) * (20 / 100)
            'esiamt = esi.Rows(0)(0)
            esiamt = gross * esirate.Rows(0)(0) / 100
        ElseIf gross >= 21000 And gross <= 50000 Then
            bonusamt = 1400
            esiamt = 0
        ElseIf gross > 50000 Then
            bonusamt = 0
            esiamt = 0
        End If
        '=====
        Dim years As Integer
        Dim pay_dtl(900) As Integer
        Dim qp As String = ""

        If dt.Rows(0)(16) <> 14 Then
            Dim sql = "select basic_pay,increment_amt,period from pay_scale where payment_id=" & dt.Rows(0)(16)
            Dim pay As New DataTable
            pay = oh.ExecuteDataSet(sql).Tables(0)
            Dim i As Integer = 0
            Dim j As Integer = 1
            Dim l As Integer = pay.Rows.Count
            Dim qqq As Integer
            pay_dtl(0) = pay.Rows(0)(0)
            qp = pay_dtl(0)

            While (l > 0 And j > 0)
                If pay.Rows(i)(1) = 0 Then
                    Exit While
                End If
                qqq = pay.Rows(i)(1) * pay.Rows(i)(2)
                qp = qp & " - " & pay.Rows(i)(1)
                pay_dtl(j) = pay_dtl(j - 1) + CInt(qqq)
                qp = qp & " - " & pay_dtl(j)
                j = j + 1
                l = l - 1
                i = i + 1

            End While
            For i = 0 To pay.Rows.Count - 1
                years = years + pay.Rows(i)(2)
            Next

        End If
        basic = getWords(basicamt)
        If dt.Rows(0)(17) = 74 Then
            report.Load(Server.MapPath("app_officer.rpt"), OpenReportMethod.OpenReportByTempCopy)
        ElseIf dt.Rows(0)(10) = 2 Then
            report.Load(Server.MapPath("app_outsource.rpt"), OpenReportMethod.OpenReportByTempCopy)
        ElseIf dt.Rows(0)(10) = 1 Then
            report.Load(Server.MapPath("app_regular8.rpt"), OpenReportMethod.OpenReportByTempCopy)
            report.SetParameterValue("basic", dt.Rows(0)(15))
            report.SetParameterValue("vda", vda)
            report.SetParameterValue("payscale", qp)
            report.SetParameterValue("years", years & " years")
        End If
        report.SetParameterValue("confirm_post", Request.QueryString("confirm_post"))
        report.SetParameterValue("confirmed_by", Request.QueryString("confirm_by"))
        If Not IsDBNull(dt.Rows(0)(19)) Then
            If dt.Rows(0)(19) = 1 Then
                report.SetParameterValue("subject", "Offer Of Rejoining As a" & dt.Rows(0)(14))
                report.SetParameterValue("bond", "Assurance-cum-Indemnity-cum Bond ")
            Else
                report.SetParameterValue("subject", Request.QueryString("subject"))
                report.SetParameterValue("bond", "Indemnity-cum-Surety Bond ")
            End If
        Else
            report.SetParameterValue("subject", Request.QueryString("subject"))
            report.SetParameterValue("bond", "Indemnity-cum-Surety Bond ")

        End If
        'report.SetParameterValue("confirm_day", Format(CDate(Request.QueryString("confirm_dt")), "MMMM dd, yyyy"))
        report.SetParameterValue("confirm_day", Format(dt.Rows(0)(11), "MMMM dd, yyyy"))
        report.SetParameterValue("emp_name", dt.Rows(0)(0))
        report.SetParameterValue("father_spouse", father_or_spouse)
        report.SetParameterValue("pres_add", dt.Rows(0)(1))
        report.SetParameterValue("post_office", dt.Rows(0)(2))
        report.SetParameterValue("district", dt.Rows(0)(3))
        report.SetParameterValue("state", dt.Rows(0)(4))
        report.SetParameterValue("pincode", dt.Rows(0)(5))
        report.SetParameterValue("designation", dt.Rows(0)(14))
        report.SetParameterValue("emppost", dt.Rows(0)(18))

        report.SetParameterValue("basicamt", basicamt)
        report.SetParameterValue("basicpay", basic)

        If dt.Rows(0)(17) <> 74 Then
            report.SetParameterValue("securityamt", dt.Rows(0)(12))
            report.SetParameterValue("securitydep", secamt)
        End If

        If dt.Rows(0)(17) = 74 Then
            Dim kk As DataTable = oh.ExecuteDataSet("select b.BRANCH_NAME from branch_dtl_new b ,employ_transfer_dtl e where e.branch_id=b.branch_id and e.status_id=8 and e.from_dt in(select min(from_dt) from employ_transfer_dtl t where t.emp_code=" & Request.QueryString("empid") & " and t.status_id=8) and e.emp_code=" & Request.QueryString("empid")).Tables(0)
            If IsDBNull(kk.Rows(0)(0)) Then
                report.SetParameterValue("branch", "A.O.VALAPPAD")
            Else
                report.SetParameterValue("branch", kk.Rows(0)(0))
            End If

        End If
        report.SetParameterValue("firm", Session("firm_name"))
        report.SetParameterValue("joindt", Format(dt.Rows(0)(11), "dd/MM/yyyy"))
        report.SetParameterValue("joinday", jday)
        report.SetParameterValue("emp_code", Request.QueryString("empid"))
        'Dim hra, allow As Integer
        If IsDBNull(dthra.Rows(0)(0)) Then
            report.SetParameterValue("HRA", "NILL")
            hra = 0
        Else
            hra = dthra.Rows(0)(0)
            report.SetParameterValue("HRA", hra.ToString())
        End If

        If IsDBNull(dtallow.Rows(0)(0)) Then
            report.SetParameterValue("Allow", "NILL")
            allow = 0
        Else
            allow = dtallow.Rows(0)(0)
            report.SetParameterValue("Allow", allow.ToString())
        End If
        report.SetParameterValue("year", Format(dt.Rows(0)(11), "yyy"))
        If bonusamt = 0 Then
            report.SetParameterValue("bonusamt", "NILL")
            report.SetParameterValue("comma", "")
            report.SetParameterValue("BONUS", "")
        Else
            'report.SetParameterValue("comma", ",")
            report.SetParameterValue("BONUS", ", Bonus")
            report.SetParameterValue("bonusamt", bonusamt)
        End If
        'report.SetParameterValue("bonusamt", bonusamt.ToString())
        report.SetParameterValue("epf", epf)
        If esiamt = 0 Then
            report.SetParameterValue("eesi", "NILL")
            report.SetParameterValue("ESI", "")
            report.SetParameterValue("comma", "")
        Else
            report.SetParameterValue("ESI", "ESI")
            report.SetParameterValue("comma", ",")
            report.SetParameterValue("eesi", esiamt)
        End If
        Dim CTC As Integer
        'If esiamt <> "NILL" Then
        CTC = basicamt + vda + allow + hra + epf + esiamt + bonusamt
        ' Else
        '     CTC = dt.Rows(0)(15) + vda + dtallow.Rows(0)(0) + dthra.Rows(0)(0) + epf + bonusamt
        ' End If

        ' If bonusamt <> "NILL" Then
        '     CTC = dt.Rows(0)(15) + vda + dtallow.Rows(0)(0) + dthra.Rows(0)(0) + epf + esiamt + bonusamt
        ' Else
        '     CTC = dt.Rows(0)(15) + vda + dtallow.Rows(0)(0) + dthra.Rows(0)(0) + epf + esiamt
        ' End If

        'If bonusamt <> "NILL" And esiamt <> "NILL" Then
        '   CTC = dt.Rows(0)(15) + vda + dtallow.Rows(0)(0) + dthra.Rows(0)(0) + epf + esiamt + bonusamt
        'Else
        ' CTC = dt.Rows(0)(15) + vda + dtallow.Rows(0)(0) + dthra.Rows(0)(0) + epf
        'End If

        report.SetParameterValue("CTC", CTC.ToString())
        Dim alphaCTC As String
        Dim actc As String
        alphaCTC = getWords(CTC)

        If alphaCTC.StartsWith("and") Then
            actc = alphaCTC.Remove(0, 5)
        Else
            actc = alphaCTC.ToString()
        End If

        report.SetParameterValue("alphaCTC", actc)
        Me.CrystalReportViewer1.ReportSource = report
    End Sub



    Public Function getWords(ByVal myNumber As String) As String
        getWords = SpellNumber(myNumber)
    End Function

    Private Function SpellNumber(ByVal MyNumber As String)
        Dim Rupees, Paise, Temp, ornum
        Dim DecimalPlace, Count
        Dim Place(9) As String
        Place(2) = " Thousand "
        Place(3) = " Lakh "
        Place(4) = " Crore "
        MyNumber = Convert.ToString(MyNumber)
        DecimalPlace = InStr(MyNumber, ".")
        If DecimalPlace > 0 Then
            ornum = Trim(Left(MyNumber, DecimalPlace - 1))
        Else
            ornum = MyNumber
        End If
        If DecimalPlace > 0 Then
            Paise = GetTens(Left(Mid(MyNumber, DecimalPlace + 1) & _
                                 "00", 2))
            MyNumber = Trim(Left(MyNumber, DecimalPlace - 1))
            ornum = MyNumber
        End If
        Count = 1
        Do While MyNumber <> ""
            If ornum = MyNumber Then
                Temp = GetHundreds(Right(MyNumber, 3))
                If Temp <> "" Then Rupees = Temp & Place(Count) & Rupees
                If Len(MyNumber) > 3 Then
                    If MyNumber = ornum Then
                        MyNumber = Left(MyNumber, Len(MyNumber) - 3)
                    Else
                        MyNumber = Left(MyNumber, Len(MyNumber) - 2)
                    End If
                Else
                    MyNumber = ""
                End If
                Count = Count + 1
            Else
                Temp = GetTens(Right(MyNumber, 2))
                If Temp <> "" Then Rupees = Temp & Place(Count) & Rupees
                If Len(MyNumber) > 2 Then
                    If MyNumber = ornum Then
                        MyNumber = Left(MyNumber, Len(MyNumber) - 3)
                    Else
                        MyNumber = Left(MyNumber, Len(MyNumber) - 2)
                    End If
                Else
                    MyNumber = ""
                End If
                Count = Count + 1
            End If
        Loop
        Select Case Rupees
            Case ""
                Rupees = "zero Rupees"
            Case "One"
                Rupees = "One Rupees"
            Case Else
                Rupees = Rupees & " Rupees"
        End Select
        'Select Case Paise
        '    Case ""
        '        Paise = " and zero Paise"
        '    Case "One"
        '        Paise = " and One Paise"
        '    Case Else
        '        Paise = " and " & Paise & " Paise"
        'End Select
        SpellNumber = Rupees & Paise
    End Function

    Private Function GetHundreds(ByVal MyNumber As String)
        Dim Result As String
        If Val(MyNumber) = 0 Then Exit Function
        MyNumber = Right("000" & MyNumber, 3)
        If Mid(MyNumber, 1, 1) <> "0" Then
            Result = GetDigit(Mid(MyNumber, 1, 1)) & " Hundred "
        End If
        If Mid(MyNumber, 2, 1) <> "0" Then
            Result = Result & GetTens(Mid(MyNumber, 2))
        Else
            Result = Result & GetDigit(Mid(MyNumber, 3))
        End If
        GetHundreds = Result
    End Function

    Private Function GetTens(ByVal TensText As String)
        Dim Result As String
        Result = ""
        If Val(Left(TensText, 1)) = 1 Then
            If Len(TensText) = 1 Then
                Result = Result & GetDigit(Right(TensText, 1))
            Else
                Select Case Val(TensText)
                    Case 10 : Result = "and  Ten"
                    Case 11 : Result = "and  Eleven"
                    Case 12 : Result = "and  Twelve"
                    Case 13 : Result = "and  Thirteen"
                    Case 14 : Result = "and  Fourteen"
                    Case 15 : Result = "and  Fifteen"
                    Case 16 : Result = "and  Sixteen"
                    Case 17 : Result = "and  Seventeen"
                    Case 18 : Result = "and  Eighteen"
                    Case 19 : Result = "and  Nineteen"
                    Case Else
                End Select
            End If
        Else
            If Len(TensText) = 1 Then
            Else
                Dim kl
                kl = CInt(Val(Left(TensText, 1)))
                Select Case CInt(Val(Left(TensText, 1)))
                    Case 2 : Result = "and  Twenty "
                    Case 3 : Result = "and  Thirty "
                    Case 4 : Result = "and  Forty "
                    Case 5 : Result = "and  Fifty "
                    Case 6 : Result = "and  Sixty "
                    Case 7 : Result = "and  Seventy "
                    Case 8 : Result = "and  Eighty "
                    Case 9 : Result = "and  Ninety "
                    Case Else
                End Select
            End If
            Result = Result & GetDigit(Right(TensText, 1))
        End If
        GetTens = Result
    End Function

    Private Function GetDigit(ByVal Digit As String)
        Select Case Val(Digit)
            Case 1 : GetDigit = "One"
            Case 2 : GetDigit = "Two"
            Case 3 : GetDigit = "Three"
            Case 4 : GetDigit = "Four"
            Case 5 : GetDigit = "Five"
            Case 6 : GetDigit = "Six"
            Case 7 : GetDigit = "Seven"
            Case 8 : GetDigit = "Eight"
            Case 9 : GetDigit = "Nine"
            Case Else : GetDigit = ""
        End Select
    End Function

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        report.Close()
    End Sub


End Class
