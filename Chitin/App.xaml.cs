using Chitin.ViewModels;
using Chitin.Views;
using System;
using System.Windows;

namespace Chitin
{
	public partial class App : Application
    {
		private static MainWindowViewModel MainWindowViewModel { get; set; }

		private void ApplicationOnStartup(object sender, StartupEventArgs e)
		{
			try
			{
				StartApp();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.ToString());
				throw;
			}
		}

		private void StartApp()
		{
			MainWindowViewModel = new MainWindowViewModel();
			var mainWindow = new MainWindow() { DataContext = MainWindowViewModel };
			MainWindow = mainWindow;
			MainWindow.Show();
		}
	}
}
