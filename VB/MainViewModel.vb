Imports System.Collections.Generic
Imports System.Windows.Input
Imports DevExpress.Mvvm
Imports System.Xml.Serialization
Imports System.IO

Namespace Example2
	Public Class MainViewModel
		Inherits ViewModelBase

'INSTANT VB NOTE: The field documents was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private documents_Conflict As New List(Of DocumentInfo)()
		Private names As New List(Of String)()
		Private serializer As New XmlSerializer(GetType(List(Of DocumentInfo)))
		Private index As Integer = 0

		Public Property Documents() As List(Of DocumentInfo)
			Get
				Return documents_Conflict
			End Get
			Set(ByVal value As List(Of DocumentInfo))
				documents_Conflict = value
			End Set
		End Property

		Private privateShowDocumentCommand As ICommand
		Public Property ShowDocumentCommand() As ICommand
			Get
				Return privateShowDocumentCommand
			End Get
			Private Set(ByVal value As ICommand)
				privateShowDocumentCommand = value
			End Set
		End Property
		Private privateSaveDocsInfoCommand As ICommand
		Public Property SaveDocsInfoCommand() As ICommand
			Get
				Return privateSaveDocsInfoCommand
			End Get
			Private Set(ByVal value As ICommand)
				privateSaveDocsInfoCommand = value
			End Set
		End Property
		Private privateRestoreDocsInfoCommand As ICommand
		Public Property RestoreDocsInfoCommand() As ICommand
			Get
				Return privateRestoreDocsInfoCommand
			End Get
			Private Set(ByVal value As ICommand)
				privateRestoreDocsInfoCommand = value
			End Set
		End Property
		Private ReadOnly Property DocumentManager() As IDocumentManagerService
			Get
				Return GetService(Of IDocumentManagerService)()
			End Get
		End Property

		Public Sub New()
			ShowDocumentCommand = New DelegateCommand(Of String)(AddressOf OnShowDocumentCommandExecute)
			SaveDocsInfoCommand = New DelegateCommand(Of String)(AddressOf SaveDocsInfo)
			RestoreDocsInfoCommand = New DelegateCommand(Of String)(AddressOf RestoreDocsInfo)
		End Sub
'INSTANT VB NOTE: The parameter document was renamed since it may cause conflicts with calls to static members of the user-defined type with this name:
		Public Sub OnShowDocumentCommandExecute(ByVal document_Conflict As String)
			ShowDocument(New DocumentInfo() With {.Document = document_Conflict})
		End Sub
		Public Sub RestoreDocsInfo(ByVal path As String)
			If File.Exists(path) Then
				Using reader As TextReader = New StreamReader(path)
					RestoreDocuments(TryCast(serializer.Deserialize(reader), List(Of DocumentInfo)))
				End Using
			End If
		End Sub
		Public Sub RestoreDocuments(ByVal values As List(Of DocumentInfo))
			If values IsNot Nothing AndAlso values.Count > 0 Then
				For Each docInfo In values
					ShowDocument(docInfo)
				Next docInfo
			End If
		End Sub
		Public Sub SaveDocsInfo(ByVal path As String)
			Using writer As TextWriter = New StreamWriter(path, False)
				serializer.Serialize(writer, Documents)
			End Using
		End Sub
'INSTANT VB NOTE: The parameter document was renamed since it may cause conflicts with calls to static members of the user-defined type with this name:
		Private Function CreateDocumentName(ByVal document_Conflict As String) As String
			Dim name As String = document_Conflict & index
			Do While names.Contains(name)
				index += 1
				name = document_Conflict & index
			Loop
			Return name
		End Function
		Private Sub ShowDocument(ByVal docInfo As DocumentInfo)
			Dim doc As IDocument = DocumentManager.CreateDocument(docInfo.Document, Nothing, Me)
			doc.DestroyOnClose = True
			If String.IsNullOrEmpty(docInfo.Name) Then
				docInfo.Name = CreateDocumentName(docInfo.Document)
			End If
			TryCast(doc.Content, ViewModel).DocumentName = docInfo.Name
			doc.Title = docInfo.Name
			doc.Id = docInfo.Name
			names.Add(docInfo.Name)
			documents_Conflict.Add(docInfo)
			doc.Show()
		End Sub

		Private str As String = "Example"
		Public Property StrValue() As String
			Get
				Return str
			End Get
			Set(ByVal value As String)
				str = value
			End Set
		End Property
	End Class

	Public Class DocumentInfo
		Public Property Name() As String
		Public Property Document() As String
	End Class
End Namespace