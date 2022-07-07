Imports DevExpress.Mvvm

Namespace Example2

    Public Class ViewModel
        Inherits ViewModelBase

        Private textField As String = "Document1"

        Public Property Text As String
            Get
                Return textField
            End Get

            Set(ByVal value As String)
                SetProperty(textField, value, Function() Text)
            End Set
        End Property

        Private name As String

        Public Property DocumentName As String
            Get
                Return name
            End Get

            Set(ByVal value As String)
                SetProperty(name, value, Function() DocumentName)
            End Set
        End Property
    End Class
End Namespace
