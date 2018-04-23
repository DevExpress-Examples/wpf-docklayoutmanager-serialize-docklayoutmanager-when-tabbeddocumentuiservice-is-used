Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Xml
Imports System.Xml.Serialization
Imports DevExpress.Mvvm
Imports DevExpress.Xpf.Docking

Namespace Example2
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
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
