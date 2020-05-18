using Chitin.Common;
using Chitin.Models;
using ChitinLib;
using System.Collections.Generic;
using System.Windows;

namespace Chitin.ViewModels
{
    public class ComparationViewModel : DependencyObject
    {
        public AnalyzeInfo AnalyzeInfo_1
        {
            get { return (AnalyzeInfo)GetValue(AnalyzeInfo_1Property); }
            set { SetValue(AnalyzeInfo_1Property, value); }
        }

        public static readonly DependencyProperty AnalyzeInfo_1Property =
            DependencyProperty.Register(nameof(AnalyzeInfo_1), typeof(AnalyzeInfo), typeof(ComparationViewModel), new PropertyMetadata(new AnalyzeInfo()));


        public AnalyzeInfo AnalyzeInfo_2
        {
            get { return (AnalyzeInfo)GetValue(AnalyzeInfo_2Property); }
            set { SetValue(AnalyzeInfo_2Property, value); }
        }

        public static readonly DependencyProperty AnalyzeInfo_2Property =
            DependencyProperty.Register(nameof(AnalyzeInfo_2), typeof(AnalyzeInfo), typeof(ComparationViewModel), new PropertyMetadata(new AnalyzeInfo()));


        public RelayCommand LoadCommand =>
           new RelayCommand(obj =>
           {
               var analyzeInfo = obj as AnalyzeInfo;
               var readAnalyzedInfo = FileHelper.OpenFile<AnalyzeInfo>();
               analyzeInfo.AnalyseDate = readAnalyzedInfo.AnalyseDate;
               analyzeInfo.ProgrammName = readAnalyzedInfo.ProgrammName;
               analyzeInfo.AnlyseFiles = readAnalyzedInfo.AnlyseFiles;
           });
    }
}
