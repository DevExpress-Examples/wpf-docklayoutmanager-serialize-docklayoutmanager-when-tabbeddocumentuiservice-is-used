﻿' Developer Express Code Central Example:
' How to serialize DockLayoutManager using TabbedDocumentUIService
' 
' Some of DockLayoutManager's panel groups can contain documents that were created
' from ViewModel with IDocumentManagerService. To serialize and restore them
' correctly, it is necessary to perform these steps:
' 
' 1. Create a style and set a
' name for DocumentPanel. To do this, bind DocumentPanel.BindableName to a unique
' property.
' 
' 2. Apply this style to all documents that will be created from
' ViewModel.
' 
' 3. Before serializing DockLayoutManager, serialize all documents
' created from ViewModel.
' 
' 4. Before restoring DockLayoutManager, recreate all
' documents created from ViewModel.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=T155653

Imports System.Reflection
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.
<Assembly: AssemblyTitle("Example2")>
<Assembly: AssemblyDescription("")>
<Assembly: AssemblyConfiguration("")>
<Assembly: AssemblyCompany("")>
<Assembly: AssemblyProduct("Example2")>
<Assembly: AssemblyCopyright("Copyright ©  2014")>
<Assembly: AssemblyTrademark("")>
<Assembly: AssemblyCulture("")>

' Setting ComVisible to false makes the types in this assembly not visible 
' to COM components.  If you need to access a type in this assembly from 
' COM, set the ComVisible attribute to true on that type.
<Assembly: ComVisible(False)>

'In order to begin building localizable applications, set 
'<UICulture>CultureYouAreCodingWith</UICulture> in your .csproj file
'inside a <PropertyGroup>.  For example, if you are using US english
'in your source files, set the <UICulture> to en-US.  Then uncomment
'the NeutralResourceLanguage attribute below.  Update the "en-US" in
'the line below to match the UICulture setting in the project file.

'[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]


<Assembly: ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)>


' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Build and Revision Numbers 
' by using the '*' as shown below:
' [assembly: AssemblyVersion("1.0.*")]
<Assembly: AssemblyVersion("1.0.0.0")>
<Assembly: AssemblyFileVersion("1.0.0.0")>