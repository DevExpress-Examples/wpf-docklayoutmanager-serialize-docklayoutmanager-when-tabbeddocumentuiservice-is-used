Imports System
Imports DevExpress.Mvvm
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Example2
    Public Class ViewModel
        Inherits ViewModelBase


        Private text_Renamed As String = "Document1"
        Public Property Text() As String
            Get
                Return text_Renamed
            End Get
            Set(ByVal value As String)
                SetProperty(text_Renamed, value, Function() Text)
            End Set
        End Property

        Private name As String
        Public Property DocumentName() As String
            Get
                Return name
            End Get
            Set(ByVal value As String)
                SetProperty(name, value, Function() DocumentName)
            End Set
        End Property


    End Class
End Namespace
