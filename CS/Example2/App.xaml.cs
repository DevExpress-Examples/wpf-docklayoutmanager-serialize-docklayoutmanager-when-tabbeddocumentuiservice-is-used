// Developer Express Code Central Example:
// How to serialize DockLayoutManager using TabbedDocumentUIService
// 
// Some of DockLayoutManager’s panel groups can contain documents that were created
// from ViewModel with IDocumentManagerService. To serialize and restore them
// correctly, it is necessary to perform these steps:
// 
// 1. Create a style and set a
// name for DocumentPanel. To do this, bind DocumentPanel.BindableName to a unique
// property.
// 
// 2. Apply this style to all documents that will be created from
// ViewModel.
// 
// 3. Before serializing DockLayoutManager, serialize all documents
// created from ViewModel.
// 
// 4. Before restoring DockLayoutManager, recreate all
// documents created from ViewModel.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=T155653

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Example2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }
}
