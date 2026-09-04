Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class leave_leave_apply_report_16d3b1138297
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim dt, dt1 As New DataTable
    Dim first, second, third As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim res As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        dt = oh.ExecuteDataSet("select count(*) from mactech.form_accessibility t WHERE T.EMP_ID=" & user(0) & " and t.form_id=5219").Tables(0)
        If dt.Rows(0)(0) = 0 Then
            Me.Server.Transfer("../../../show_err.aspx")
        End If
        Dim scr As String
        scr = "var header;" & "header='1';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", scr, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Private Function MaskEmail(rawEmail As String) As String
        If String.IsNullOrEmpty(rawEmail) Then
            Return rawEmail
        End If

        Dim atIndex As Integer = rawEmail.IndexOf("@")
        If atIndex > 0 Then
            Dim firstChar As String = rawEmail.Substring(0, 1)
            Dim domainPart As String = rawEmail.Substring(atIndex)
            Return firstChar & "*****" & domainPart
        Else
            Return rawEmail ' fallback if invalid format
        End If
    End Function

    Private Function MaskPhone(rawPhone As String) As String
        If String.IsNullOrEmpty(rawPhone) OrElse rawPhone.Length < 4 Then
            Return rawPhone
        End If
        Return New String("X"c, rawPhone.Length - 4) & rawPhone.Substring(rawPhone.Length - 4)
    End Function

    Private Function MaskBankAccount(rawAcc As String) As String
        If String.IsNullOrEmpty(rawAcc) OrElse rawAcc.Length < 4 Then
            Return rawAcc
        End If
        Return New String("X"c, rawAcc.Length - 4) & rawAcc.Substring(rawAcc.Length - 4)
    End Function

    Private Function MaskPAN(rawPAN As String) As String
        If String.IsNullOrEmpty(rawPAN) OrElse rawPAN.Length <> 10 Then
            Return rawPAN
        End If
        Return New String("X"c, 5) & rawPAN.Substring(5)
    End Function


    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Try
            Dim cal_data = eventArgument
            Dim st As New StringBuilder
            Dim x = cal_data
            Dim strr As New StringBuilder
            Select Case (x)
                Case "1"
                    dt = oh.ExecuteDataSet("select t.query from mactech.hrm_report_master t where t.query_id=126 and t.firm_id=99").Tables(0)
                    Dim vysh() As String = dt.Rows(0)(0).ToString.Split("$")
                    dt1 = oh.ExecuteDataSet(vysh(1)).Tables(0)
                    Dim dr As DataRow
                    For Each dr In dt1.Rows
                        Dim code As String = dr(0).ToString
                        Dim name As String = dr(1).ToString
                        Dim hname As String = dr(2).ToString
                        Dim pofice As String = dr(3).ToString
                        Dim distr As String = dr(4).ToString
                        Dim state As String = dr(5).ToString
                        Dim pin As String = dr(6).ToString
                        Dim lm As String = dr(7).ToString
                        Dim dob As String = dr(8).ToString
                        Dim doj As String = dr(9).ToString
                        Dim age As String = dr(10).ToString
                        Dim gen As String = dr(11).ToString
                        Dim mar As String = dr(12).ToString
                        Dim bg As String = dr(13).ToString
                        Dim des As String = dr(14).ToString
                        Dim post As String = dr(15).ToString
                        Dim dep As String = dr(16).ToString
                        Dim qual As String = dr(17).ToString
                        Dim dephd As String = dr(18).ToString
                        Dim tlmgr As String = dr(19).ToString
                        Dim tlmgr2 As String = dr(20).ToString
                        Dim cate As String = dr(21).ToString
                        Dim sts As String = dr(22).ToString
                        'Dim email As String = dr(23).ToString
                        Dim email As String = MaskEmail(dr(23).ToString)
                        Dim offmail As String = dr(24).ToString
                        'Dim contno As String = dr(25).ToString
                        Dim contno As String = MaskPhone(dr(25).ToString)
                        Dim bpay As String = dr(26).ToString
                        Dim vda As String = dr(27).ToString
                        Dim tatot As String = dr(28).ToString
                        Dim gross As String = dr(29).ToString
                        Dim bonex As String = dr(30).ToString
                        Dim epf As String = dr(31).ToString
                        Dim eesi As String = dr(32).ToString
                        Dim ctc As String = dr(33).ToString
                        Dim aexp As String = dr(34).ToString
                        Dim expm As String = dr(35).ToString
                        Dim texp As String = dr(36).ToString
                        'Dim bnkacno As String = dr(37).ToString
                        Dim bnkacno As String = MaskBankAccount(dr(37).ToString)
                        Dim bnkname As String = dr(38).ToString
                        Dim ifsc As String = dr(39).ToString
                        Dim esino As String = dr(40).ToString
                        Dim uanno As String = dr(41).ToString
                        Dim level As String = dr(42).ToString
                        Dim poscat As String = dr(43).ToString
                        Dim idprof As String = dr(44).ToString
                        Dim idname As String = dr(45).ToString
                        'Dim pan As String = dr(46).ToString
                        Dim pan As String = MaskPAN(dr(46).ToString)
                        Dim drs As String = dr(47).ToString
                        Dim epexit As String = dr(48).ToString
                        Dim resreas As String = dr(49).ToString
                        Dim ctcadj As String = dr(50).ToString
                        Dim skil As String = dr(51).ToString
                        Dim ofe As String = dr(52).ToString
                        Dim incr As String = dr(53).ToString
                        Dim promo As String = dr(54).ToString
                        Dim pfs As String = dr(55).ToString
                        Dim ofdoj As String = dr(56).ToString
                        Dim source As String = dr(57).ToString
                        Dim stat As String = dr(58).ToString
                        'Dim res As String = dr(59).ToString
                        Dim res As String = MaskPhone(dr(59).ToString)
                        Dim fathname As String = dr(60).ToString
                        Dim descat As String = dr(61).ToString
                        Dim catcode As String = dr(62).ToString
                        Dim crrntstartdte As String = dr(63).ToString




                        first = vysh(0)
                        second += "<tr><td>" & code & "</td><td>" & name & "</td><td>" & fathname & "</td><td>" & hname & "</td><td>" & pofice & "</td><td>" & distr & "</td><td>" & state & "</td><td>" & pin & "</td><td>" & lm & "</td><td>" & dob & "</td><td>" & doj & "</td><td>" & age & "</td><td>" & gen & "</td><td>" & mar & "</td><td>" & bg & "</td><td>" & des & "</td><td>" & descat & "</td><td>" & catcode & "</td><td>" & post & "</td><td>" & dep & "</td><td>" & qual & "</td><td>" & dephd & "</td><td><a href='javascript:passpage2(" & code & ")'>" & tlmgr & "</a></td><td>" & tlmgr2 & "</td><td>" & cate & "</td><td>" & email & "</td><td>" & offmail & "</td><td>" & contno & "</td><td>" & res & "</td><td>" & bpay & "</td><td>" & vda & "</td><td><a href='javascript:passpage1(" & code & ")'>" & tatot & "</a></td><td>" & gross & "</td><td>" & bonex & "</td><td>" & epf & "</td><td>" & eesi & "</td><td>" & ctc & "</td><td>" & aexp & "</td><td>" & expm & "</td><td>" & texp & "</td><td>" & bnkacno & "</td><td>" & bnkname & "</td><td>" & ifsc & "</td><td>" & esino & "</td><td>" & uanno & "</td><td>" & level & "</td><td>" & poscat & "</td><td>" & idprof & "</td><td>" & idname & "</td><td>" & pan & "</td><td>" & drs & "</td><td>" & epexit & "</td><td>" & resreas & "</td><td>" & ctcadj & "</td>      <td>" & skil & "</td><td>" & ofe & "</td><td>" & incr & "</td> <td>" & promo & "</td> <td>" & pfs & "</td><td>" & ofdoj & "</td><td>" & source & "</td> <td>" & crrntstartdte & "</td>  <td>" & stat & "</td><td><a href='javascript:passpage(" & code & "," & pin & ")' class='animated-button1'><span/><span/><span/><span/>   Edit </a></td></tr>"
                        third = "</tbody> </table> </div> </section>"
                    Next
                    strr.Append(first & second & third)
            End Select
            res = strr.ToString
        Catch ex As Exception
            res = ex.ToString
        End Try
    End Sub
    Protected Sub mybut1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mybut1.Click
        Dim _filename As String = ("MACOM MASTER" + ".xls")
        dt = oh.ExecuteDataSet("select t.query from mactech.hrm_report_master t where t.query_id=126 and t.firm_id=99").Tables(0)
        Dim vysh() As String = dt.Rows(0)(0).ToString.Split("$")
        dt1 = oh.ExecuteDataSet(vysh(1)).Tables(0)
        Dim dr As DataRow
        For Each dr In dt1.Rows
            Dim code As String = dr(0).ToString
            Dim name As String = dr(1).ToString
            Dim hname As String = dr(2).ToString
            Dim pofice As String = dr(3).ToString
            Dim distr As String = dr(4).ToString
            Dim state As String = dr(5).ToString
            Dim pin As String = dr(6).ToString
            Dim lm As String = dr(7).ToString
            Dim dobs, dojs, epexits, drss, incrs, promos, ofdojs, bnkacnos As String
            If dr(8).ToString = "" Then
                dobs = dr(8).ToString
            Else
                dobs = Format(CDate(dr(8).ToString), "dd/MMM/yyyy")
            End If
            Dim dob As String = dobs
            If dr(9).ToString = "" Then
                dojs = dr(9).ToString
            Else
                dojs = Format(CDate(dr(9).ToString), "dd/MMM/yyyy")
            End If
            Dim doj As String = dojs
            Dim age As String = dr(10).ToString
            Dim gen As String = dr(11).ToString
            Dim mar As String = dr(12).ToString
            Dim bg As String = dr(13).ToString
            Dim des As String = dr(14).ToString
            Dim post As String = dr(15).ToString
            Dim dep As String = dr(16).ToString
            Dim qual As String = dr(17).ToString
            Dim dephd As String = dr(18).ToString
            Dim tlmgr As String = dr(19).ToString
            Dim tlmgr2 As String = dr(20).ToString
            Dim cate As String = dr(21).ToString
            Dim sts As String = dr(22).ToString
            'Dim email As String = dr(23).ToString
            Dim email As String = MaskEmail(dr(23).ToString)
            Dim offmail As String = dr(24).ToString
            'Dim contno As String = dr(25).ToString
            Dim contno As String = MaskPhone(dr(25).ToString)
            Dim bpay As String = dr(26).ToString
            Dim vda As String = dr(27).ToString
            Dim tatot As String = dr(28).ToString
            Dim gross As String = dr(29).ToString
            Dim bonex As String = dr(30).ToString
            Dim epf As String = dr(31).ToString
            Dim eesi As String = dr(32).ToString
            Dim ctc As String = dr(33).ToString
            Dim aexp As String = dr(34).ToString
            Dim expm As String = dr(35).ToString
            Dim texp As String = dr(36).ToString
            'Dim bnkacno As String = dr(34).ToString
            If MaskBankAccount(dr(37).ToString) = "" Then
                bnkacnos = MaskBankAccount(dr(37).ToString)
            Else
                bnkacnos = "&nbsp;" + MaskBankAccount(dr(37).ToString)
            End If
            Dim bnkacno As String = bnkacnos
            Dim bnkname As String = dr(38).ToString
            Dim ifsc As String = dr(39).ToString
            Dim esino As String = dr(40).ToString
            Dim uanno As String = dr(41).ToString
            Dim level As String = dr(42).ToString
            Dim poscat As String = dr(43).ToString
            Dim idprof As String = dr(44).ToString
            Dim idname As String = dr(45).ToString
            'Dim pan As String = dr(46).ToString
            Dim pan As String = MaskPAN(dr(46).ToString)
            If dr(47).ToString = "" Then
                drss = dr(47).ToString
            Else
                drss = Format(CDate(dr(47).ToString), "dd/MMM/yyyy")
            End If
            Dim drs As String = drss
            If dr(48).ToString = "" Then
                epexits = dr(48).ToString
            Else
                epexits = Format(CDate(dr(48).ToString), "dd/MMM/yyyy")
            End If
            Dim epexit As String = epexits
            Dim resreas As String = dr(49).ToString
            Dim ctcadj As String = dr(50).ToString
            Dim skil As String = dr(51).ToString
            Dim ofe As String = dr(52).ToString
            If dr(53).ToString = "" Then
                incrs = dr(53).ToString
            Else
                incrs = Format(CDate(dr(53).ToString), "dd/MMM/yyyy")
            End If
            Dim incr As String = incrs
            If dr(54).ToString = "" Then
                promos = dr(54).ToString
            Else
                promos = Format(CDate(dr(54).ToString), "dd/MMM/yyyy")
            End If
            Dim promo As String = promos
            Dim pfs As String = dr(55).ToString
            If dr(56).ToString = "" Then
                ofdojs = dr(56).ToString
            Else
                ofdojs = Format(CDate(dr(56).ToString), "dd/MMM/yyyy")
            End If
            Dim ofdoj As String = ofdojs
            Dim source As String = dr(57).ToString
            Dim stat As String = dr(58).ToString
            'Dim res As String = dr(59).ToString
            Dim res As String = MaskPhone(dr(59).ToString)
            Dim fathname As String = dr(60).ToString
            Dim descat As String = dr(61).ToString
            Dim catcode As String = dr(62).ToString
            Dim crrntstartdte As String = dr(63).ToString

            first = vysh(3)
            second += "<tr><td>" & code & "</td><td>" & name & "</td><td>" & fathname & "</td><td>" & hname & "</td><td>" & pofice & "</td><td>" & distr & "</td><td>" & state & "</td><td>" & pin & "</td><td>" & lm & "</td><td>" & dob & "</td><td>" & doj & "</td><td>" & age & "</td><td>" & gen & "</td><td>" & mar & "</td><td>" & bg & "</td><td>" & des & "</td><td>" & descat & "</td><td>" & catcode & "</td><td>" & post & "</td><td>" & dep & "</td><td>" & qual & "</td><td>" & dephd & "</td><td>" & tlmgr & "</td><td>" & tlmgr2 & "</td><td>" & cate & "</td><td>" & email & "</td><td>" & offmail & "</td><td>" & contno & "</td><td>" & res & "</td><td>" & bpay & "</td><td>" & vda & "</td><td><a href='javascript:passpage1(" & code & ")'>" & tatot & "</a></td><td>" & gross & "</td><td>" & bonex & "</td><td>" & epf & "</td><td>" & eesi & "</td><td>" & ctc & "</td><td>" & aexp & "</td><td>" & expm & "</td><td>" & texp & "</td><td>" & bnkacno & "</td><td>" & bnkname & "</td><td>" & ifsc & "</td><td>" & esino & "</td><td>" & uanno & "</td><td>" & level & "</td><td>" & poscat & "</td><td>" & idprof & "</td><td>" & idname & "</td><td>" & pan & "</td><td>" & drs & "</td><td>" & epexit & "</td><td>" & resreas & "</td><td>" & ctcadj & "</td>      <td>" & skil & "</td><td>" & ofe & "</td><td>" & incr & "</td>  <td>" & promo & "</td><td>" & pfs & "</td><td>" & ofdoj & "</td><td>" & source & "</td> <td>" & crrntstartdte & "</td> <td>" & stat & "</td></tr>"
            third = "</tbody> </table> </div> </section>"
        Next
        Dim strr As String
        strr = first & second & third
        Dim strHTML As StringBuilder = New StringBuilder
        strHTML.Append(("<html " + (" xmlns:o='urn:schemas-microsoft-com:office:office'" + (" xmlns:w='urn:schemas-microsoft-com:office:word'" + (" xmlns='http://www.w3.org/TR/REC-html40'>")))))
        strHTML.Append(("<xml><w:WordDocument>" + (" <w:View>Print</w:View>" + (" " + (" <w:DoNotOptimizeForBrowser/>" + (" </w:WordDocument>" + " </xml>"))))))
        strHTML.Append(("<body><div class='page-settings'>" + (strr + "</div></body></html>")))
        Response.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml")
        Response.AppendHeader("Content-disposition", ("attachment;filename=" + (_filename + "")))
        Response.Write(strHTML.ToString)
    End Sub
End Class
