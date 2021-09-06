Imports DevExpress.Mvvm

Namespace Example2
	Public Class ViewModel
		Inherits ViewModelBase

'INSTANT VB NOTE: The field text was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private text_Conflict As String = "Document1"
		Public Property Text() As String
			Get
				Return text_Conflict
			End Get
			Set(ByVal value As String)
				SetProperty(text_Conflict, value, Function() Text)
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