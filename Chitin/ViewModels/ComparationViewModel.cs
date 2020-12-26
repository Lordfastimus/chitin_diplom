using Chitin.Common;
using Chitin.Dto;
using Chitin.Models;
using ChitinLib;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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
			   var readAnalyzedInfo = FileHelper.OpenFile<AnalyzeInfoDto>();
			   analyzeInfo.AnalyseDate = readAnalyzedInfo.AnalyseDate;
			   analyzeInfo.ProgrammName = readAnalyzedInfo.ProgrammName;
			   analyzeInfo.AnlyseFiles = new ObservableCollection<IFileAnalyzeInfo>(readAnalyzedInfo.AnlyseFiles.Select(x => (new FileAnalyseInfo()
			   {
				   MD5 = x.MD5,
				   Name = x.Name,
				   Size = x.Size
			   })).ToList());
		   });

		public RelayCommand CompareResultsCommand =>
		   new RelayCommand(obj =>
		   {
			   var compareService = new CompareService();
			   if (!compareService.ProgrammsAreEquals(AnalyzeInfo_1.AnlyseFiles, AnalyzeInfo_2.AnlyseFiles))
			   {
				   MessageBox.Show(string.Join(";" + Environment.NewLine, compareService.Errors) + Environment.NewLine + "Программы не равны", "Обнаружены различия в программах");
			   }
			   else
			   {
				   MessageBox.Show("Различия в программах не обнаружены." + Environment.NewLine + "Программы равны");
			   }
		   });
	}
}
