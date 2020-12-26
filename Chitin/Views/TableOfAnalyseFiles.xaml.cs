using Chitin.Models;
using ChitinLib;
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

        public ObservableCollection<IFileAnalyzeInfo> ItemsSource
        {
            get { return (ObservableCollection<IFileAnalyzeInfo>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(ObservableCollection<IFileAnalyzeInfo>), typeof(TableOfAnalyseFiles), new PropertyMetadata(new ObservableCollection<IFileAnalyzeInfo>()));
    }
}
