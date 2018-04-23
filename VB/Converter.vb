Imports System
Imports System.Windows.Data
Imports DevExpress.Xpf.Docking

Namespace Example2
    Public Class Converter
        Implements IValueConverter

        Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
            Dim item As BaseLayoutItem = TryCast(value, BaseLayoutItem)
            Dim model As MainViewModel = TryCast(parameter, MainViewModel)
            Return value.ToString()

        End Function
        Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
            Dim name As String = value.ToString()
            Dim model As MainViewModel = TryCast(parameter, MainViewModel)
            Return name
        End Function
    End Class
End Namespace