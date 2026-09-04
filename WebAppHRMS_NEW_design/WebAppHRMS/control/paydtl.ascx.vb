Imports System.Data.OracleClient
Imports System.Data
Public Class paydtl
    Inherits System.Web.UI.UserControl
    Dim pay_mode As Int16
    Dim title As String
    Dim all_client_id
    Public pay_a_type As Int16 = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cash_client_id, cheque_client_id, tfr_client_id, total_client_id As String
        Dim bank_hdn_client_id, bank_client_id, branch_hdn_client_id, branch_client_id, panel_id As String
        Session("pay") = "C"
        cash_client_id = Me.txt_cash.ClientID.ToString
        cheque_client_id = Me.txt_cheque.ClientID.ToString
        tfr_client_id = Me.txt_tfr.ClientID.ToString
        total_client_id = Me.txt_total.ClientID.ToString
        bank_hdn_client_id = Me.hdn_bank.ClientID.ToString
        bank_client_id = Me.hdn_bankdtl.ClientID.ToString
        branch_hdn_client_id = Me.hdn_branch.ClientID.ToString
        branch_client_id = Me.hdn_branchdtl.ClientID.ToString
        panel_id = Me.pnl_bank.ClientID.ToString
        all_client_id = cash_client_id + "#" + cheque_client_id + "#" + tfr_client_id + "#" + total_client_id + "#" + bank_hdn_client_id + "#" + bank_client_id + "#" + branch_hdn_client_id + "#" + branch_client_id + "#" + panel_id
        Dim client_id_scr As String = "var curr_day,curr_month,curr_year,pay_mode,client_id,a_pay_type;" + "curr_day=" & Now.Day & ";" + "curr_month=" & Now.Month & ";" + "curr_year=" & Now.Year & ";" + "pay_mode=" & 1 & ";" + "client_id='" & all_client_id & "';a_pay_type=" & pay_a_type & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "cl_id", client_id_scr, True)
        Dim bnkdtl_cid, brndtl_cid, cash_cid, chq_cid, tfr_cid, bhd_cid, thd_cid, pnl_cid, tot_cid As String
        cash_cid = "'" + Me.txt_cash.ClientID.ToString + "'"
        chq_cid = "'" + Me.txt_cheque.ClientID.ToString + "'"
        tfr_cid = "'" + Me.txt_tfr.ClientID.ToString + "'"
        bhd_cid = "'" + Me.hdn_bank.ClientID.ToString + "'"
        tot_cid = "'" + Me.txt_total.ClientID.ToString + "'"
        thd_cid = "'" + Me.hdn_branch.ClientID.ToString + "'"
        brndtl_cid = "'" + Me.hdn_branchdtl.ClientID.ToString + "'"
        bnkdtl_cid = "'" + Me.hdn_bankdtl.ClientID.ToString + "'"
        pnl_cid = "'" + Me.pnl_bank.ClientID.ToString + "'"
        Me.txt_cash.Attributes.Add("OnChange", "check_cash()")
        Me.txt_cheque.Attributes.Add("OnChange", "get_bank_name()")
        Me.txt_tfr.Attributes.Add("OnChange", "get_sub_name()")
        'Me.txt_cash.Attributes.Add("onkeyup", "return txt_onkeyup2('txt_cash')")
        'Me.txt_cheque.Attributes.Add("onkeyup", "return txt_onkeyup2('txt_cheque')")
        'Me.txt_tfr.Attributes.Add("onkeyup", "return txt_onkeyup2('txt_tfr')")
        Select Case pay_mode
            Case 1
                Me.txt_cash.Enabled = True
                Me.txt_cheque.Enabled = False
                Me.txt_tfr.Enabled = False
            Case 2
                Me.txt_cash.Enabled = False
                Me.txt_cheque.Enabled = True
                Me.txt_tfr.Enabled = False
            Case 3
                Me.txt_cash.Enabled = False
                Me.txt_cheque.Enabled = False
                Me.txt_tfr.Enabled = True
            Case 4
                Me.txt_cash.Enabled = True
                Me.txt_cheque.Enabled = True
                Me.txt_tfr.Enabled = False
            Case 5
                Me.txt_cash.Enabled = True
                Me.txt_cheque.Enabled = True
                Me.txt_tfr.Enabled = True
        End Select
        If Not IsPostBack Then
            getbankdtl()
            getbranchdtl()
        End If
        If pay_a_type = 3 Then
            Me.txt_tfr.Enabled = False
            Me.txt_tfr.BorderStyle = BorderStyle.None
            Me.txt_tfr.BackColor = Drawing.Color.AntiqueWhite
            Me.txt_tfr.BorderColor = Drawing.Color.AntiqueWhite
            Me.tfr_td.InnerText = HttpUtility.HtmlDecode("&nbsp;")
        End If
    End Sub
    Private Sub getbankdtl()
        Dim SQL As String
        Dim oh As New Helper.Oracle.OracleHelper
        If Session("branch_id") = 0 And Session("firm_id") = 1 Then
            SQL = "select account_name ||' '|| account_no as account_name,account_no from subsidary_master where parent_acc=(select parmtr_value from general_parameter where parmtr_id=6 and firm_id=" & Session("firm_id") & " and module_id=0) and branch_id=" & Session("branch_id") & " and firm_id=" & Session("firm_id") & " and status_id=1 union all select account_name ||' '|| account_no  as account_name,account_no from account_profile where account_no in (40401,40402,40403,40404,40405,40406,40407,40418,40455) order by account_name"
        ElseIf Session("branch_id") = 0 And Session("firm_id") = 24 Then
            SQL = "select account_name ||' '|| account_no as account_name,account_no from subsidary_master where parent_acc=(select parmtr_value from general_parameter where parmtr_id=6 and firm_id=" & Session("firm_id") & " and module_id=0) and branch_id=" & Session("branch_id") & " and firm_id=" & Session("firm_id") & " and status_id=1 union all select account_name ||' '|| account_no  as account_name,account_no from account_profile where account_no in (40465,40402) order by account_name"
        ElseIf Session("branch_id") = 0 And Session("firm_id") = 16 Then
            SQL = "select account_name ||' '|| account_no as account_name,account_no from subsidary_master where parent_acc=(select parmtr_value from general_parameter where parmtr_id=6 and firm_id=" & Session("firm_id") & " and module_id=0) and branch_id=" & Session("branch_id") & " and firm_id=" & Session("firm_id") & " and status_id=1 union all select account_name ||' '|| account_no  as account_name,account_no from account_profile where account_no in (40406) order by account_name"

        ElseIf Session("branch_id") = 0 And Session("firm_id") = 25 Then
            SQL = "select account_name ||' '|| account_no,account_no from subsidary_master where parent_acc=(select parmtr_value from general_parameter where parmtr_id=6 and firm_id=1 and module_id=0) and branch_id=" & Session("branch_id") & " and firm_id=1 and status_id=1 order by account_name"
        Else
            SQL = "select account_name ||' '|| account_no,account_no from subsidary_master where parent_acc=(select parmtr_value from general_parameter where parmtr_id=6 and firm_id=" & Session("firm_id") & " and module_id=0) and branch_id=" & Session("branch_id") & " and firm_id=" & Session("firm_id") & " and status_id=1 order by account_name"
        End If
        If Request.QueryString.Get("mod_id") = 16 Then
            SQL = "select '--NIL---',1 from dual"
        End If

        Dim dt As New DataTable
        Try
            dt = oh.ExecuteDataSet(SQL).Tables(0)
            Dim str As New System.Text.StringBuilder
            For Each dr As DataRow In dt.Rows
                str.Append(dr(1))
                str.Append("@")
                str.Append(dr(0))
                str.Append("^")
            Next

            Me.hdn_bank.Value = str.ToString
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Private Sub getbranchdtl()
        Dim SQL As String
        'If Session("branch_id") = 0 Then
        '    SQL = "select a.account_name ||' '|| a.account_no,a.parent_acc || '~' || a.account_no from subsidary_master a,branch_account b where a.parent_acc=b.parent_acc and a.account_no=b.account_no and a.firm_id=b.firm_id and b.firm_id=" & Session("firm_id") & " and a.branch_id=0 order by a.account_name"
        'Else
        '    SQL = "select FIRM_ABBR,firm_id || '~1' from firm_master where  firm_id<>" & Session("firm_id") & " and firm_id in (select firm_id from active_firms where branch_id=" & Session("branch_id") & ") and firm_id in (select af.to_firm from ao_fund af where af.from_firm=" & Session("firm_id") & ") order by FIRM_ABBR"
        'End If
        If Session("branch_id") = 0 Then
            SQL = "select branch_name ||' '|| a.branch_id,a.branch_id ||'~1' from branch_master a where  exists (select branch_id from active_firms b where b.branch_id=a.branch_id and b.firm_id=" & Session("firm_id") & ") order by a.branch_name"
        Else
            SQL = "select FIRM_ABBR,firm_id || '~1' from firm_master where  firm_id<>" & Session("firm_id") & " and firm_id in (select firm_id from active_firms where branch_id=" & Session("branch_id") & ") and firm_id in (select af.to_firm from ao_fund af where af.from_firm=" & Session("firm_id") & ") order by FIRM_ABBR"
        End If

        Dim dt As New DataTable
        Dim oh As New Helper.Oracle.OracleHelper
        Try
            dt = oh.ExecuteDataSet(SQL).Tables(0)
            Dim str As New System.Text.StringBuilder
            For Each dr As DataRow In dt.Rows
                str.Append(dr(1))
                str.Append("@")
                str.Append(dr(0))
                str.Append("^")
            Next
            Me.hdn_branch.Value = str.ToString
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Public ReadOnly Property cash()
        Get
            If IsNumeric(Me.txt_cash.Text) Then
                Return CType(Me.txt_cash.Text, Double)
            Else
                Return 0
            End If
        End Get
    End Property
    Public ReadOnly Property cheque()
        Get
            If IsNumeric(Me.txt_cheque.Text) Then
                Return CType(Me.txt_cheque.Text, Double)
            Else
                Return 0
            End If
        End Get
    End Property
    Public ReadOnly Property tfr()
        Get
            If IsNumeric(Me.txt_tfr.Text) Then
                Return CType(Me.txt_tfr.Text, Double)
            Else
                Return 0
            End If

        End Get
    End Property
    Public ReadOnly Property total()
        Get
            If IsNumeric(Me.txt_cash.Text) Or IsNumeric(Me.txt_cheque.Text) Or IsNumeric(Me.txt_tfr.Text) Then
                Return CType(Me.txt_total.Value, Double)
            Else
                Return 0
            End If
        End Get
    End Property
    Public Sub clear()
        Me.txt_cash.Text = ""
        Me.txt_cheque.Text = ""
        Me.txt_tfr.Text = ""
        Me.txt_total.Value = ""
    End Sub
    Public ReadOnly Property bank_dtl()
        Get
            Return Me.hdn_bankdtl.Value
        End Get
    End Property
    Public ReadOnly Property branch_dtl()
        Get
            Return Me.hdn_branchdtl.Value
        End Get
    End Property
    Public Property heading()
        Get
            Return title
        End Get
        Set(ByVal Value)
            title = Value
        End Set
    End Property
    Protected Sub New()
        Me.pay_mode = 5
    End Sub
    Public Property paymodes()
        Get
            Return pay_mode
        End Get
        Set(ByVal value)
            pay_mode = value
        End Set
    End Property
End Class
