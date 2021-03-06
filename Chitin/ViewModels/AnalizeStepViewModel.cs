﻿using Chitin.Common;
using Chitin.Dto;
using Chitin.Models;
using ChitinLib;
using Ookii.Dialogs.Wpf;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Chitin.ViewModels
{
	public class AnalizeStepViewModel : DependencyObject
	{
		#region Dependency property

		public string ProgrammName
		{
			get { return (string)GetValue(ProgrammNameProperty); }
			set { SetValue(ProgrammNameProperty, value); }
		}

		public static readonly DependencyProperty ProgrammNameProperty =
			DependencyProperty.Register(nameof(ProgrammName), typeof(string), typeof(AnalizeStepViewModel), new PropertyMetadata(string.Empty));


		public string SelectedFolderPath
		{
			get { return (string)GetValue(SelectedFolderPathProperty); }
			set { SetValue(SelectedFolderPathProperty, value); }
		}

		public static readonly DependencyProperty SelectedFolderPathProperty =
			DependencyProperty.Register(nameof(SelectedFolderPath), typeof(string), typeof(AnalizeStepViewModel), new PropertyMetadata(string.Empty));


		public ObservableCollection<IFileAnalyzeInfo> FilesForAnalyse
		{
			get { return (ObservableCollection<IFileAnalyzeInfo>)GetValue(FilesForAnalyseProperty); }
			set { SetValue(FilesForAnalyseProperty, value); }
		}

		public static readonly DependencyProperty FilesForAnalyseProperty =
			DependencyProperty.Register(nameof(IFileAnalyzeInfo), typeof(ObservableCollection<IFileAnalyzeInfo>), typeof(AnalizeStepViewModel), new PropertyMetadata(new ObservableCollection<IFileAnalyzeInfo>()));

		#endregion

		private void SelectFilesFromDir()
		{
			FilesForAnalyse.Clear();
			var rootPathLength = Directory.GetParent(SelectedFolderPath).FullName.Length;

			foreach (var fileName in FileHelper.GetFileNamesForDirectory(SelectedFolderPath))
			{
				FilesForAnalyse.Add(new FileAnalyseInfo() { FullName = fileName, Name = fileName.Substring(rootPathLength) });
			}
		}

		private void Clear()
		{
			ProgrammName = string.Empty;
			FilesForAnalyse = new ObservableCollection<IFileAnalyzeInfo>();
		}

		#region Command

		public RelayCommand CalculateMD5Command =>
		   new RelayCommand(obj =>
		   {
			   FilesForAnalyse = new ObservableCollection<IFileAnalyzeInfo>(CryptoHelper.CalculateMD5ForFiles(FilesForAnalyse.ToList()));
			   Parallel.ForEach(FilesForAnalyse, new Action<IFileAnalyzeInfo>(file =>
			   {
				   var fileInfo = new FileInfo(file.FullName);
				   file.Size = fileInfo.Length;
				   var fileBody = File.ReadAllBytes(fileInfo.FullName);
				   file.MD5 = CryptoHelper.GetHashMD5(fileBody);
			   }));
		   }, o => FilesForAnalyse.Count > 0);

		public RelayCommand SelectDirForAnalyseCommand =>
			new RelayCommand(obj =>
			{
				VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog();
				dialog.Description = "Выберите папку с программой для анализа.";
				dialog.UseDescriptionForTitle = true;
				if ((bool)dialog.ShowDialog())
				{
					SelectedFolderPath = dialog.SelectedPath;
					ProgrammName = new DirectoryInfo(dialog.SelectedPath).Name;
					SelectFilesFromDir();
				}
			});

		public RelayCommand SaveResultCommand =>
			new RelayCommand(obj =>
			{
				var dialog = new VistaSaveFileDialog();
				dialog.DefaultExt = ".xml";
				var fileInfo = new AnalyzeInfoDto()
				{
					ProgrammName = ProgrammName,
					AnalyseDate = DateTime.Now,
					AnlyseFiles = FilesForAnalyse.Select(x => new FileAnalizeInfoDto()
					{
						MD5 = x.MD5,
						Name = x.Name,
						Size = x.Size
					}).ToList()
				};

				dialog.FileName = Path.Combine(FileHelper.GetAnalyseFolder(), fileInfo.GetFileName());

				if ((bool)dialog.ShowDialog())
				{
					try
					{
						FileHelper.SerializeObject(fileInfo, dialog.FileName);
						MessageBox.Show("Сохранение прошло успешно", "Сохранение");
						Clear();
					}
					catch (Exception e)
					{
						MessageBox.Show(e.ToString(), "Ошибка сохранения");
					}
				}
			}, o => !string.IsNullOrWhiteSpace(ProgrammName) && !FilesForAnalyse.Any(f => string.IsNullOrWhiteSpace(f.MD5)));

		#endregion
	}
}
