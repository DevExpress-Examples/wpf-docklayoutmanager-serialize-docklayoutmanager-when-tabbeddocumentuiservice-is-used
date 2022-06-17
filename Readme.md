<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128643881/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T155653)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF Dock Layout Manager - Serialize DockLayoutManager When You Use the TabbedDocumentUIService


Some of DockLayoutManager’s panel groups can contain documents that were created from ViewModel with [IDocumentManagerService](https://docs.devexpress.com/WPF/18171/mvvm-framework/services/predefined-set/document-services). To serialize and restore these panels and their child documents correctly, it is necessary to perform the following steps.


Item names are used to identify items when saving/restoring the layout. For this reason, it is necessary to set unique names for all DockLayoutManager panels. In the current scenario, this can be done by setting the DocumentPanel.[BindableName](https://docs.devexpress.com/WPF/DevExpress.Xpf.Docking.BaseLayoutItem.BindableName) property in the [TabbedDocumentUIService.DocumentPanelStyle](https://docs.devexpress.com/WPF/DevExpress.Xpf.Docking.TabbedDocumentUIService.DocumentPanelStyle).

Another important point is that the DockLayoutManager's save/restore mechanism is not the [XamlWriter](https://docs.microsoft.com/en-us/dotnet/api/system.windows.markup.xamlwriter?redirectedfrom=MSDN&view=windowsdesktop-6.0) alternative — it does not save/restore the content of its panels. It is necessary to restore it. In this example, we use the following approach:

1. Before saving layout settings, serialize all documents created from the ViewModel.
2. Before restoring settings, recreate all documents.</p>

![image](https://user-images.githubusercontent.com/12169834/174028784-aea53a4e-ea99-4b2b-ac61-8377479ca7af.png)


<!-- default file list -->
## Files to Look At:

* [Converter.cs](./CS/Converter.cs) (VB: [Converter.vb](./VB/Converter.vb))
* [Document.xaml](./CS/Document.xaml) (VB: [Document.xaml](./VB/Document.xaml))
* [Document.xaml.cs](./CS/Document.xaml.cs) (VB: [Document.xaml.vb](./VB/Document.xaml.vb))
* [MainViewModel.cs](./CS/MainViewModel.cs) (VB: [MainViewModel.vb](./VB/MainViewModel.vb))
* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))
* [ViewModel.cs](./CS/ViewModel.cs) (VB: [ViewModel.vb](./VB/ViewModel.vb))
<!-- default file list end -->

## Documentation

- [Common Concepts - Save/Restore Control Layout](https://docs.devexpress.com/WPF/7391/common-concepts/save-and-restore-layouts)
- [WPF Dock Layout Manager - Save and Restore the Layout of Dock Panels and Controls](https://docs.devexpress.com/WPF/7059/controls-and-libraries/layout-management/dock-windows/miscellaneous/saving-and-restoring-the-layout-of-dock-panels-and-controls)
