Imports System.Data.OracleClient
Imports System.Data
Public Class DateFiller
    Inherits System.Web.UI.UserControl

    Public f_name As String
    Public out_date As String
    Dim start_frmdt As String
    Dim start_todt As String
    WriteOnly Property blu_date() As String
        Set(ByVal value As String)
            out_date = value
        End Set
    End Property
    Public ReadOnly Property fromdate()
        Get
            fromdate = Me.txt_from.Text
        End Get

    End Property
    Public ReadOnly Property todate()
        Get
            todate = Me.txt_to.Text
        End Get

    End Property
    Public Property start_fromdate() As String
        Get
            Return (start_frmdt)
        End Get
        Set(ByVal value As String)
            start_frmdt = value
            Me.txt_from.Text = start_frmdt
        End Set
    End Property
    Public Property start_todate() As String
        Get
            Return (start_todt)
        End Get
        Set(ByVal value As String)
            start_todt = value
            Me.txt_to.Text = start_todt
        End Set
    End Property
End Class