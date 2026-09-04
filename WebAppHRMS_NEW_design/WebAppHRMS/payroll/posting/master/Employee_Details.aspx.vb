Imports System.Data.Entity.Core.Objects
Imports System.Security.Cryptography
Imports System.Security.Policy
Imports System.Threading.Tasks
Imports System.Web.Services.Description
Imports System.Windows.Forms.AxHost
Imports GemBox.Document
Imports log4net.Core
Imports OracleInternal
Imports Org.BouncyCastle.Asn1
Imports Org.BouncyCastle.Asn1.Pkcs
Imports Org.BouncyCastle.Utilities

Public Class Employee_Details
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

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Try
            Dim cal_data = eventArgument
            Dim st As New StringBuilder
            Dim x = cal_data
            Dim strr As New StringBuilder
            Select Case (x)
                Case "1"
                    dt = oh.ExecuteDataSet("select t.query from mactech.hrm_report_master t where t.query_id=909 and t.firm_id=99").Tables(0)
                    Dim vysh() As String = dt.Rows(0)(0).ToString.Split("$")
                    dt1 = oh.ExecuteDataSet(vysh(1)).Tables(0)
                    Dim dr As DataRow
                    For Each dr In dt1.Rows
                        Dim code As String = dr(0).ToString
                        Dim name As String = dr(1).ToString
                        Dim email As String = dr(2).ToString
                        Dim cont As String = dr(3).ToString
                        Dim res As String = dr(4).ToString
                        Dim pan As String = dr(5).ToString
                        Dim bnkacc As String = dr(6).ToString
                        first = vysh(0)
                        second += "<tr><td>" & code & "</td><td>" & name & "</td><td>" & email & "</td><td>" & cont & "</td><td>" & res & "</td><td>" & pan & "</td><td>" & bnkacc & "</td></tr>"
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
        dt = oh.ExecuteDataSet("select t.query from mactech.hrm_report_master t where t.query_id=909 and t.firm_id=99").Tables(0)
        Dim vysh() As String = dt.Rows(0)(0).ToString.Split("$")
        dt1 = oh.ExecuteDataSet(vysh(1)).Tables(0)
        Dim dr As DataRow
        For Each dr In dt1.Rows
            Dim code As String = dr(0).ToString
            Dim name As String = dr(1).ToString
            Dim email As String = dr(2).ToString
            Dim cont As String = dr(3).ToString
            Dim res As String = dr(4).ToString
            Dim pan As String = dr(5).ToString
            Dim bnkacc As String = dr(6).ToString


            first = vysh(3)
            second += "<tr><td>" & code & "</td><td>" & name & "</td><td>" & email & "</td><td>" & cont & "</td><td>" & res & "</td><td>" & pan & "</td><td>" & bnkacc & "</td></tr> "
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