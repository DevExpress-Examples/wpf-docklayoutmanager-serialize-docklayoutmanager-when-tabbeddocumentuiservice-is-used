Imports System.Collections.Generic
Imports System.Windows.Input
Imports DevExpress.Mvvm
Imports System.Xml.Serialization
Imports System.IO

Namespace Example2

    Public Class MainViewModel
        Inherits DevExpress.Mvvm.ViewModelBase

        Private _ShowDocumentCommand As ICommand, _SaveDocsInfoCommand As ICommand, _RestoreDocsInfoCommand As ICommand

        Private documentsField As System.Collections.Generic.List(Of Example2.DocumentInfo) = New System.Collections.Generic.List(Of Example2.DocumentInfo)()

        Private names As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)()

        Private serializer As System.Xml.Serialization.XmlSerializer = New System.Xml.Serialization.XmlSerializer(GetType(System.Collections.Generic.List(Of Example2.DocumentInfo)))

        Private index As Integer = 0

        Public Property Documents As List(Of Example2.DocumentInfo)
            Get
                Return Me.documentsField
            End Get

            Set(ByVal value As List(Of Example2.DocumentInfo))
                Me.documentsField = value
            End Set
        End Property

        Public Property ShowDocumentCommand As ICommand
            Get
                Return _ShowDocumentCommand
            End Get

            Private Set(ByVal value As ICommand)
                _ShowDocumentCommand = value
            End Set
        End Property

        Public Property SaveDocsInfoCommand As ICommand
            Get
                Return _SaveDocsInfoCommand
            End Get

            Private Set(ByVal value As ICommand)
                _SaveDocsInfoCommand = value
            End Set
        End Property

        Public Property RestoreDocsInfoCommand As ICommand
            Get
                Return _RestoreDocsInfoCommand
            End Get

            Private Set(ByVal value As ICommand)
                _RestoreDocsInfoCommand = value
            End Set
        End Property

        Private ReadOnly Property DocumentManager As IDocumentManagerService
            Get
                Return GetService(Of DevExpress.Mvvm.IDocumentManagerService)()
            End Get
        End Property

        Public Sub New()
            Me.ShowDocumentCommand = New DevExpress.Mvvm.DelegateCommand(Of String)(AddressOf Me.OnShowDocumentCommandExecute)
            Me.SaveDocsInfoCommand = New DevExpress.Mvvm.DelegateCommand(Of String)(AddressOf Me.SaveDocsInfo)
            Me.RestoreDocsInfoCommand = New DevExpress.Mvvm.DelegateCommand(Of String)(AddressOf Me.RestoreDocsInfo)
        End Sub

        Public Sub OnShowDocumentCommandExecute(ByVal document As String)
            Me.ShowDocument(New Example2.DocumentInfo() With {.Document = document})
        End Sub

        Public Sub RestoreDocsInfo(ByVal path As String)
            If System.IO.File.Exists(path) Then
                Using reader As System.IO.TextReader = New System.IO.StreamReader(path)
                    Me.RestoreDocuments(TryCast(Me.serializer.Deserialize(reader), System.Collections.Generic.List(Of Example2.DocumentInfo)))
                End Using
            End If
        End Sub

        Public Sub RestoreDocuments(ByVal values As System.Collections.Generic.List(Of Example2.DocumentInfo))
            If values IsNot Nothing AndAlso values.Count > 0 Then
                For Each docInfo In values
                    Me.ShowDocument(docInfo)
                Next
            End If
        End Sub

        Public Sub SaveDocsInfo(ByVal path As String)
            Using writer As System.IO.TextWriter = New System.IO.StreamWriter(path, False)
                Me.serializer.Serialize(writer, Me.Documents)
            End Using
        End Sub

        Private Function CreateDocumentName(ByVal document As String) As String
            Dim name As String = document & Me.index
            While Me.names.Contains(name)
                Me.index += 1
                name = document & Me.index
            End While

            Return name
        End Function

        Private Sub ShowDocument(ByVal docInfo As Example2.DocumentInfo)
            Dim doc As DevExpress.Mvvm.IDocument = Me.DocumentManager.CreateDocument(docInfo.Document, Nothing, Me)
            doc.DestroyOnClose = True
            If String.IsNullOrEmpty(docInfo.Name) Then docInfo.Name = Me.CreateDocumentName(docInfo.Document)
            TryCast(doc.Content, Example2.ViewModel).DocumentName = docInfo.Name
            doc.Title = docInfo.Name
            doc.Id = docInfo.Name
            Me.names.Add(docInfo.Name)
            Me.documentsField.Add(docInfo)
            doc.Show()
        End Sub

        Private str As String = "Example"

        Public Property StrValue As String
            Get
                Return Me.str
            End Get

            Set(ByVal value As String)
                Me.str = value
            End Set
        End Property
    End Class

    Public Class DocumentInfo

        Public Property Name As String

        Public Property Document As String
    End Class
End Namespace
