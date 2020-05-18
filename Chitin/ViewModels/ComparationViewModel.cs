using Chitin.Common;
using Chitin.Models;
using ChitinLib;
using System.Collections.ObjectModel;
using System.Windows;

namespace Chitin.ViewModels
{
    public class ComparationViewModel : DependencyObject
    {


        public ObservableCollection<AnalyzeInfo> AnalyzeInfos
        {
            get { return (ObservableCollection<AnalyzeInfo>)GetValue(AnalyzeInfosProperty); }
            set { SetValue(AnalyzeInfosProperty, value); }
        }

        public static readonly DependencyProperty AnalyzeInfosProperty =
            DependencyProperty.Register(nameof(AnalyzeInfos), typeof(ObservableCollection<AnalyzeInfo>), typeof(ComparationViewModel), new PropertyMetadata(new ObservableCollection<AnalyzeInfo>()));


        public RelayCommand LoadCommand_1 =>
           new RelayCommand(obj =>
           {
               AnalyzeInfo_1 = FileHelper.OpenFile<AnalyzeInfo>();
           });

        public RelayCommand LoadCommand_2 =>
           new RelayCommand(obj =>
           {
               AnalyzeInfo_2 = FileHelper.OpenFile<AnalyzeInfo>();
           });
    }
}
