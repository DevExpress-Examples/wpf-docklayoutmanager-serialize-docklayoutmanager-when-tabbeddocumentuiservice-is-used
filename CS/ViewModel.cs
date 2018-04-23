using DevExpress.Mvvm;

namespace Example2 {
    public class ViewModel : ViewModelBase {
        string text = "Document1";
        public string Text {
            get { return text; }
            set { SetProperty(ref text, value, () => Text); }
        }
        string name;
        public string DocumentName {
            get { return name; }
            set { SetProperty(ref name, value, () => DocumentName); }
        }
    }
}