using System.Collections.Generic;
using System.Windows.Input;
using DevExpress.Mvvm;
using System.Xml.Serialization;
using System.IO;

namespace Example2 {
    public class MainViewModel : ViewModelBase {
        List<DocumentInfo> documents = new List<DocumentInfo>();
        List<string> names = new List<string>();
        XmlSerializer serializer = new XmlSerializer(typeof(List<DocumentInfo>));
        int index = 0;

        public List<DocumentInfo> Documents {
            get { return documents; }
            set { documents = value; }
        }

        public ICommand ShowDocumentCommand { get; private set; }
        public ICommand SaveDocsInfoCommand { get; private set; }
        public ICommand RestoreDocsInfoCommand { get; private set; }
        IDocumentManagerService DocumentManager { get { return GetService<IDocumentManagerService>(); } }

        public MainViewModel() {
            ShowDocumentCommand = new DelegateCommand<string>(OnShowDocumentCommandExecute);
            SaveDocsInfoCommand = new DelegateCommand<string>(SaveDocsInfo);
            RestoreDocsInfoCommand = new DelegateCommand<string>(RestoreDocsInfo);
        }
        public void OnShowDocumentCommandExecute(string document) {
            ShowDocument(new DocumentInfo() { Document = document });
        }
        public void RestoreDocsInfo(string path) {
            if (File.Exists(path))
                using (TextReader reader = new StreamReader(path)) {
                    RestoreDocuments(serializer.Deserialize(reader) as List<DocumentInfo>);
                };
        }
        public void RestoreDocuments(List<DocumentInfo> values) {
            if (values != null && values.Count > 0)
                foreach (var docInfo in values) {
                    ShowDocument(docInfo);
                }
        }
        public void SaveDocsInfo(string path) {
            using (TextWriter writer = new StreamWriter(path, false)) {
                serializer.Serialize(writer, Documents);
            };
        }
        private string CreateDocumentName(string document) {
            string name = document + index;
            while (names.Contains(name)) {
                index++;
                name = document + index;
            }
            return name;
        }
        private void ShowDocument(DocumentInfo docInfo) {
            IDocument doc = DocumentManager.CreateDocument(docInfo.Document, null, this);
            doc.DestroyOnClose = true;
            if (string.IsNullOrEmpty(docInfo.Name))
                docInfo.Name = CreateDocumentName(docInfo.Document);
            (doc.Content as ViewModel).DocumentName = docInfo.Name;
            doc.Title = docInfo.Name;
            doc.Id = docInfo.Name;
            names.Add(docInfo.Name);
            documents.Add(docInfo);
            doc.Show();
        }

        string str = "Example";
        public string StrValue {
            get { return str; }
            set { str = value; }
        }
    }

    public class DocumentInfo {
        public string Name { get; set; }
        public string Document { get; set; }
    }
}