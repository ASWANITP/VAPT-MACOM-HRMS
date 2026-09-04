Namespace branch
    Partial Class datefiller
        Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
            'Put user code to initialize the page here
            Me.Uc_date1.fun_name = "fun1"
            Me.Uc_date2.fun_name = "fun2"
            Me.Uc_date1.blu_date = Me.hid_date.ClientID
            Me.Uc_date2.blu_date = Me.hid_date1.ClientID
            If Not IsPostBack Then
                Me.hid_date.Value = Format(Today, "dd/MMM/yyyy")
                Me.hid_date1.Value = Format(Today, "dd/MMM/yyyy")
            End If
            'Me.hid_date.Value = Format(Today, "dd/MMM/yyyy")
            'Me.hid_date1.Value = Format(Today, "dd/MMM/yyyy")
            'Dim a As String
            'a = """"

            'With Response
            '    .Write("<script>")
            '    .Write("var curr_day,curr_month,curr_year,ctl_name;")
            '    .Write("curr_day=" & Now.Day & ";")
            '    .Write("curr_month=" & Now.Month & ";")
            '    .Write("curr_year=" & Now.Year & ";")
            '    .Write("ctl_name=" & a & Me.lbl_date.ClientID.ToString & a & ";")
            '    .Write("from=" & a & Me.txt_from.ClientID.ToString & a & ";")
            '    .Write("to=" & a & Me.txt_to.ClientID.ToString & a & ";")
            '    .Write("</script>")
            'End With

        End Sub
        Public Property fromdate()
            Get
                fromdate = Me.hid_date.Value
            End Get
            Set(ByVal Value)
            End Set
        End Property
        Public Property todate()
            Get
                todate = Me.hid_date1.Value
            End Get
            Set(ByVal Value)
            End Set
        End Property
    End Class

End Namespace