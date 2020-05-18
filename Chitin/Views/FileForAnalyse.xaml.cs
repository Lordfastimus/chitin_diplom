using Chitin.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chitin.Views
{
    public partial class FileForAnalyse : UserControl
    {
        public FileForAnalyse()
        {
            InitializeComponent();
        }

        public AnalyzeInfo SelectedFile
        {
            get { return (AnalyzeInfo)GetValue(SelctedFileProperty); }
            set { SetValue(SelctedFileProperty, value); }
        }

        public static readonly DependencyProperty SelctedFileProperty =
            DependencyProperty.Register(nameof(SelectedFile), typeof(AnalyzeInfo), typeof(FileForAnalyse), new PropertyMetadata(null));

        public ICommand LoadCommand
        {
            get { return (ICommand)GetValue(LoadCommandProperty); }
            set { SetValue(LoadCommandProperty, value); }
        }

        public static readonly DependencyProperty LoadCommandProperty =
            DependencyProperty.Register(nameof(LoadCommand), typeof(ICommand), typeof(FileForAnalyse), new PropertyMetadata(null));
    }
}
