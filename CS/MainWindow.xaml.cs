using System.ComponentModel;
using System.IO;
using System.Windows;

namespace Example2 {
    public partial class MainWindow : Window {
        string path = "layout.xml";
        string docPath = "DocumentCollection.xml";
        public MainWindow() {
            InitializeComponent();
        }
        private void Window_Closing(object sender, CancelEventArgs e) {
            SaveGridToXml();
        }
        private void SaveGridToXml() {
            (dockLayoutManager.DataContext as MainViewModel).SaveDocsInfo(docPath);
            dockLayoutManager.SaveLayoutToXml(path);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            if (File.Exists(path)) {
                (dockLayoutManager.DataContext as MainViewModel).RestoreDocsInfo(docPath);
                dockLayoutManager.RestoreLayoutFromXml(path);
            }
        }
    }
}