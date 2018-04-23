Imports System.ComponentModel
Imports System.IO
Imports System.Windows

Namespace Example2
    Partial Public Class MainWindow
        Inherits Window

        Private path As String = "layout.xml"
        Private docPath As String = "DocumentCollection.xml"
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub Window_Closing(ByVal sender As Object, ByVal e As CancelEventArgs)
            SaveGridToXml()
        End Sub
        Private Sub SaveGridToXml()
            TryCast(dockLayoutManager.DataContext, MainViewModel).SaveDocsInfo(docPath)
            dockLayoutManager.SaveLayoutToXml(path)
        End Sub
        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If File.Exists(path) Then
                TryCast(dockLayoutManager.DataContext, MainViewModel).RestoreDocsInfo(docPath)
                dockLayoutManager.RestoreLayoutFromXml(path)
            End If
        End Sub
    End Class
End Namespace