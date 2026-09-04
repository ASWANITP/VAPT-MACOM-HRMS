Public Class hr_master
    Inherits System.Web.UI.MasterPage
    Dim date_on_br As New Main_BLL.Main_BLL
    Dim oh As New Helper.Oracle.OracleHelper
    Public WriteOnly Property heading()
        Set(ByVal value)
            Dim str As New adv_string
            Me.lbl_head.Text = str.sentence_case(value)
        End Set
    End Property
    Public WriteOnly Property subtitle()
        Set(ByVal value)
            Me.lbl_subhead.Text = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cs As String = "var msg_str;msg_str='" & Session("message") & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "mesg", cs, True)
        'Me.lbl_date.Text = Format(System.DateTime.Now, "dd/MMM/yyyy")
        Dim br_date As DataTable = date_on_br.fill_date(Session("branch_id"))
        Me.lbl_date.Text = Format(br_date.Rows(0)(0), "dd/MMM/yyyy")
        Me.lbl_time.Text = Format(System.DateTime.Now, "hh:mm:ss")
        Me.heading = Session("title")
        Dim str As New adv_string
        Me.lbl_user.Text = "Welcome :" & str.sentence_case(Session("user_name"))
        'If Not IsPostBack Then
        '    PopulateMenu()
        'End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim var As Integer
        var = CInt(Session("branch_id"))
        Dim cl_script0 As New System.Text.StringBuilder
        'cl_script0.Append("window.open('MISHome.aspx','_self')")
        If Session("firm_id") = 1 Then
            cl_script0.Append("window.open('mafil_MISHome.aspx','_self')")
        ElseIf Session("firm_id") = 2 Then
            cl_script0.Append("window.open('Maben_MISHome.aspx','_self')")
        ElseIf Session("firm_id") = 4 Then
            cl_script0.Append("window.open('Maafin_MISHome.aspx','_self')")
        ElseIf Session("firm_id") = 3 Then
            cl_script0.Append("window.open('MISHome.aspx','_self')")
        ElseIf Session("firm_id") = 16 Then
            cl_script0.Append("window.open('macare_MISHome.aspx','_self')")
        ElseIf Session("firm_id") = 5 Then
            cl_script0.Append("window.open('Magro_MISHome.aspx','_self')")
        ElseIf Session("firm_id") = 29 Then
            cl_script0.Append("window.open('Matr_MISHome.aspx','_self')")
        ElseIf Session("firm_id") = 9 Then
            cl_script0.Append("window.open('Maibro_MISHome.aspx','_self')")
        Else
            If Session("firm_id") = 8 Then
                Dim edop As DataTable = oh.ExecuteDataSet("select t.query from mactech.hrm_report_master t  where t.query_id=136 and t.firm_id=99").Tables(0)
                Dim lop1 As DataTable = oh.ExecuteDataSet(edop.Rows(0)(0).ToString.Replace("mycode", Me.Session("user_id").ToString.Split("!")(0))).Tables(0)
                If lop1.Rows(0)(0) = 1 Then
                    cl_script0.Append("window.open('Misc_MISHome.aspx','_self')")
                Else
                    cl_script0.Append("window.open('Misc_MISHome.aspx','_self')")
                End If
            Else
                cl_script0.Append("window.open('Misc_MISHome.aspx','_self')")
            End If
        End If
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Session.RemoveAll()

        Session.Abandon()
        Dim manager As New System.Web.SessionState.SessionIDManager()
        Dim newId As String = manager.CreateSessionID(Context)

        Dim isRedirected As Boolean = False
        Dim isAdded As Boolean = False
        manager.SaveSessionID(Context, newId, isRedirected, isAdded)



        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("window.open('main.aspx','_self')")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
    End Sub

End Class