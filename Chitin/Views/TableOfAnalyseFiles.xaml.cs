using Chitin.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Chitin.Views
{
    public partial class TableOfAnalyseFiles : UserControl
    {
        public TableOfAnalyseFiles()
        {
            InitializeComponent();
        }

        public ObservableCollection<FileAnalyseInfo> ItemsSource
        {
            get { return (ObservableCollection<FileAnalyseInfo>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(ObservableCollection<FileAnalyseInfo>), typeof(TableOfAnalyseFiles), new PropertyMetadata(new ObservableCollection<FileAnalyseInfo>()));
    }
}
