Imports System.Data
Imports System.Data.OracleClient
Partial Public Class edpm
    Inherits System.Web.UI.MasterPage
    Dim date_on_br As New Main_BLL.Main_BLL
    Public WriteOnly Property heading()
        Set(ByVal value)
            Dim str As New adv_string
            'Me.lbl_head.Text = str.sentence_case(value)
        End Set
    End Property
    Public WriteOnly Property subtitle()
        Set(ByVal value)
            'Me.lbl_subhead.Text = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.lbl_date.Text = Format(System.DateTime.Now, "dd/MMM/yyyy")
        Dim br_date As DataTable = date_on_br.fill_date(Session("branch_id"))
        ' Me.lbl_date.Text = Format(br_date.Rows(0)(0), "dd/MMM/yyyy")
        'Me.lbl_time.Text = Format(System.DateTime.Now, "hh:mm:ss")
        Me.heading = Session("title")
        'If Not IsPostBack Then
        '    PopulateMenu()
        'End If
    End Sub
    'Private Sub PopulateMenu()
    '    Dim dst As DataSet = GetMenuData()
    '    For Each masterRow As DataRow In dst.Tables("main").Rows()
    '        Dim masterItem As New MenuItem(masterRow("menu_name").ToString())
    '        masterItem.Selectable = False
    '        Menu1.Items.Add(masterItem)
    '        For Each childRow As DataRow In masterRow.GetChildRows("Children")
    '            Dim childItem As New MenuItem(childRow("sub_menu_name").ToString())
    '            childItem.NavigateUrl = childRow("url").ToString()
    '            masterItem.ChildItems.Add(childItem)
    '        Next
    '    Next
    'End Sub
    'Private Function GetMenuData() As DataSet
    '    Dim dadCats As New OracleDataAdapter("SELECT * FROM main_menu", connection.con)
    '    Dim dadProducts As New OracleDataAdapter("SELECT a.menu_id,a.sub_menu_id,a.sub_menu_name,b.url FROM sub_menu a,menu_target b where a.menu_id=b.menu_id and a.sub_menu_id=b.sub_menu_id", connection.con)
    '    Dim dst As New DataSet()
    '    Try
    '        If connection.con.State <> ConnectionState.Open Then
    '            connection.con.Open()
    '        End If
    '        dadCats.Fill(dst, "main")
    '        dadProducts.Fill(dst, "sub")
    '    Catch ex As Exception
    '    Finally
    '        connection.con.Close()
    '    End Try
    '    dst.Relations.Add("Children", dst.Tables("main").Columns("menu_id"), _
    '        dst.Tables("sub").Columns("menu_id"))
    '    Return dst
    'End Function
End Class

