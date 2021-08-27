<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128643881/14.1.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T155653)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Converter.cs](./CS/Example2/Converter.cs) (VB: [Converter.vb](./VB/Example2/Converter.vb))
* [Document.xaml](./CS/Example2/Document.xaml) (VB: [Document.xaml](./VB/Example2/Document.xaml))
* [Document.xaml.cs](./CS/Example2/Document.xaml.cs) (VB: [Document.xaml.vb](./VB/Example2/Document.xaml.vb))
* [MainViewModel.cs](./CS/Example2/MainViewModel.cs) (VB: [MainViewModel.vb](./VB/Example2/MainViewModel.vb))
* [MainWindow.xaml](./CS/Example2/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/Example2/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/Example2/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/Example2/MainWindow.xaml.vb))
* [ViewModel.cs](./CS/Example2/ViewModel.cs) (VB: [ViewModel.vb](./VB/Example2/ViewModel.vb))
<!-- default file list end -->
# How to: Serialize DockLayoutManager When TabbedDocumentUIService Is Used


<p>Some of DockLayoutManager’s panel groups can contain documents that were created from ViewModel with <a href="https://documentation.devexpress.com/#WPF/CustomDocument18171">IDocumentManagerService</a>. To serialize and restore them correctly, it is necessary to perform the following steps.<br><br>Item names are used to identify items when saving/restoring the layout. For this reason, it will be necessary to set unique names for all DockLayoutManager panels. In the current scenario, this can be done by setting the DocumentPanel.<a href="https://documentation.devexpress.com/#WPF/DevExpressXpfDockingBaseLayoutItem_BindableNametopic">BindableName</a> property in the <a href="https://documentation.devexpress.com/#WPF/DevExpressXpfDockingTabbedDocumentUIService_DocumentPanelStyletopic">TabbedDocumentUIService.DocumentPanelStyle</a>.<br><br>Another important point is that the DockLayoutManager's saving/restoring mechanism is not the <a href="https://msdn.microsoft.com/en-us/library/system.windows.markup.xamlwriter%28v=vs.110%29.aspx">XamlWriter</a> alternative - it does not save/restore content of its panels. It will be necessary to additionally restore it. In this example, we used the following approach:<br>1. Before saving layout settings, serialize all documents created from the ViewModel.<br>2. Before restoring settings, recreate all documents.</p>

<br/>


