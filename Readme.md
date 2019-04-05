<!-- default file list -->
*Files to look at*:

* [Converter.cs](./CS/Converter.cs) (VB: [Converter.vb](./VB/Converter.vb))
* [Document.xaml](./CS/Document.xaml) (VB: [Document.xaml](./VB/Document.xaml))
* [Document.xaml.cs](./CS/Document.xaml.cs) (VB: [Document.xaml.vb](./VB/Document.xaml.vb))
* [MainViewModel.cs](./CS/MainViewModel.cs) (VB: [MainViewModel.vb](./VB/MainViewModel.vb))
* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))
* [ViewModel.cs](./CS/ViewModel.cs) (VB: [ViewModel.vb](./VB/ViewModel.vb))
<!-- default file list end -->
# How to: Serialize DockLayoutManager When TabbedDocumentUIService Is Used


<p>Some of DockLayoutManager’s panel groups can contain documents that were created from ViewModel with <a href="https://documentation.devexpress.com/#WPF/CustomDocument18171">IDocumentManagerService</a>. To serialize and restore them correctly, it is necessary to perform the following steps.<br><br>Item names are used to identify items when saving/restoring the layout. For this reason, it will be necessary to set unique names for all DockLayoutManager panels. In the current scenario, this can be done by setting the DocumentPanel.<a href="https://documentation.devexpress.com/#WPF/DevExpressXpfDockingBaseLayoutItem_BindableNametopic">BindableName</a> property in the <a href="https://documentation.devexpress.com/#WPF/DevExpressXpfDockingTabbedDocumentUIService_DocumentPanelStyletopic">TabbedDocumentUIService.DocumentPanelStyle</a>.<br><br>Another important point is that the DockLayoutManager's saving/restoring mechanism is not the <a href="https://msdn.microsoft.com/en-us/library/system.windows.markup.xamlwriter%28v=vs.110%29.aspx">XamlWriter</a> alternative - it does not save/restore content of its panels. It will be necessary to additionally restore it. In this example, we used the following approach:<br>1. Before saving layout settings, serialize all documents created from the ViewModel.<br>2. Before restoring settings, recreate all documents.</p>

<br/>


