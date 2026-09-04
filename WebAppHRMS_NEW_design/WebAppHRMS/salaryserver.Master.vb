Imports System.Data
Imports System.Text

Partial Class mailserverw
    Inherits System.Web.UI.MasterPage
    Dim date_on_br As New Main_BLL.Main_BLL
    'Public WriteOnly Property heading()
    '    Set(ByVal value)
    '        Dim str As New adv_string
    '        Me.lbl_head.Text = str.sentence_case(value)
    '    End Set
    'End Property
    Public WriteOnly Property mail_subtitle()
        Set(ByVal value)
            Me.lbl_user_name.Text = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ''-----------------samy old
        'Dim br_date As DataTable = date_on_br.fill_date(Session("branch_id"))
        'Me.lbl_date.Text = Format(br_date.Rows(0)(0), "dd/MMM/yyyy")
        'Me.lbl_time.Text = Format(System.DateTime.Now, "hh:mm:ss")
        ''Me.heading = Session("title")
        'Dim us() As String = Session("user_id").ToString.Split("!")
        'Dim client_ip As String
        'If us(1) = "10.0" Then
        '    client_ip = "10.0.0.101"
        'Else
        '    If us(1) = "10.0.0.31" Or us(1) = "192.168.1.3" Or us(1) = "20.0.1.31" Or us(1) = "127.0.0.1" Then
        '        client_ip = "localhost"
        '    Else
        '        client_ip = "220.225.200.51"
        '    End If
        'End If
        'client_ip = "10.0.0.101"
        'Dim cs As String = "var ip_add;ip_add='" & client_ip & "';"
        'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ip_add", cs, True)
        ''-----------------samy old
        '-----------------samy New----------------------
        Dim acces_id = Request.QueryString.Get("acces_id")
        Dim user = Request.QueryString.Get("userid")
        Dim br_id = Request.QueryString.Get("brid")
        Dim sysip = Request.QueryString.Get("sysip")
        If acces_id = 6 Then
            Dim br_date As DataTable = date_on_br.fill_date(br_id)
            Me.lbl_date.Text = Format(br_date.Rows(0)(0), "dd/MMM/yyyy")
            Me.lbl_time.Text = Format(System.DateTime.Now, "hh:mm:ss")


            'Me.heading = Session("title")
            'Dim us() As String = Session("user_id").ToString.Split("!")
            Dim client_ip As String
            If sysip = "10.0" Then
                client_ip = "10.0.0.101"
            Else
                If sysip = "10.0.0.31" Or sysip = "192.168.1.3" Or sysip = "20.0.1.31" Or sysip = "127.0.0.1" Then
                    client_ip = "localhost"
                Else
                    client_ip = "220.225.200.51"
                End If
            End If
            client_ip = "10.0.0.101"
            Dim cs As String = "var ip_add;ip_add='" & client_ip & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ip_add", cs, True)
        Else
            Dim br_date As DataTable = date_on_br.fill_date(Session("branch_id"))
            If br_date.Rows.Count <= 0 Then
                Dim cl_script1 As New StringBuilder
                cl_script1.Append(" alert('Please Login Again and Retry....!! ');")
                cl_script1.Append("    window.open('../main.aspx?key=75872','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)
                Exit Sub
            End If
            Me.lbl_date.Text = Format(br_date.Rows(0)(0), "dd/MMM/yyyy")
            Me.lbl_time.Text = Format(System.DateTime.Now, "hh:mm:ss")


            'Me.heading = Session("title")
            Dim us() As String = Session("user_id").ToString.Split("!")
            Dim client_ip As String
            If us(1) = "10.0" Then
                client_ip = "10.0.0.101"
            Else
                If us(1) = "10.0.0.31" Or us(1) = "192.168.1.3" Or us(1) = "20.0.1.31" Or us(1) = "127.0.0.1" Then
                    client_ip = "localhost"
                Else
                    client_ip = "220.225.200.51"
                End If
            End If
            client_ip = "10.0.0.101"
            Dim cs As String = "var ip_add;ip_add='" & client_ip & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ip_add", cs, True)
        End If
        ''-----------------samy New----------------------
    End Sub
End Class

