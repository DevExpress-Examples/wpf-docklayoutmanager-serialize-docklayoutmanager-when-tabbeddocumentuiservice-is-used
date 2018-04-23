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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Xpf.Docking;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Example2
{
    public class MainViewModel : ViewModelBase
    {
        private List<DocumentInfo> documents = new List<DocumentInfo>();

        private List<string> names = new List<string>();

        XmlSerializer serializer = new XmlSerializer(typeof(List<DocumentInfo>));

        int index = 0;




        public List<DocumentInfo> Documents
        {
            get { return documents; }
            set { documents = value; }
        }

        public ICommand ShowDocumentCommand { get; private set; }

        public ICommand SaveDocsInfoCommand { get; private set; }

        public ICommand RestoreDocsInfoCommand { get; private set; }

        IDocumentManagerService DocumentManager { get { return GetService<IDocumentManagerService>(); } }




        public void RestoreDocsInfo(string path)
        {
            if (File.Exists(path))
                using (TextReader reader = new StreamReader(path))
                {
                    RestoreDocuments(serializer.Deserialize(reader) as List<DocumentInfo>);
                };
        }

        public void SaveDocsInfo(string path)
        {
            using (TextWriter writer = new StreamWriter(path, false))
            {
                serializer.Serialize(writer, Documents);
            };
        }




        public MainViewModel()
        {
            ShowDocumentCommand = new DelegateCommand<string>(OnShowDocumentCommandExecute);
            SaveDocsInfoCommand = new DelegateCommand<string>(SaveDocsInfo);
            RestoreDocsInfoCommand = new DelegateCommand<string>(RestoreDocsInfo);
        }

        public void OnShowDocumentCommandExecute(string document)
        {
            ShowDocument(new DocumentInfo() { Document = document });
        }

        private string CreateDocumentName(string document)
        {
            string name = document + index;
            while (names.Contains(name))
            {
                index++;
                name = document + index;
            }
            return name;
        }

        private void ShowDocument(DocumentInfo docInfo)
        {
            IDocument doc = DocumentManager.CreateDocument(docInfo.Document, null, this);
            doc.DestroyOnClose = true;
            if (string.IsNullOrEmpty(docInfo.Name))
                docInfo.Name = CreateDocumentName(docInfo.Document);
            (doc.Content as ViewModel).DocumentName = docInfo.Name;
            doc.Title = docInfo.Name;
            names.Add(docInfo.Name);
            documents.Add(docInfo);
            doc.Show();
        }

        public void RestoreDocuments(List<DocumentInfo> values)
        {
            if (values != null && values.Count > 0)
                foreach (var docInfo in values)
                {
                    ShowDocument(docInfo);
                }
        }

        string str = "Example";

        public string StrValue
        {
            get { return str; }
            set { str = value; }
        }
    }

    public class DocumentInfo
    {
        public string Name { get; set; }
        public string Document { get; set; }
    }
}
