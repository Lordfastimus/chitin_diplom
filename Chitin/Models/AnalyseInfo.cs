using ChitinLib;
using System;
using System.Collections.ObjectModel;

namespace Chitin.Models
{
	public class AnalyzeInfo : NotifyPropertyChangedBase
    {
        private ObservableCollection<IFileAnalyzeInfo> anlyseFiles;
        private string programmName;
        private DateTime? analyseDate;

        public string ProgrammName
        {
            get => programmName;
            set
            {
                programmName = value;
                OnPropertyChanged(nameof(ProgrammName));
            }
        }
        public ObservableCollection<IFileAnalyzeInfo> AnlyseFiles
        {
            get => anlyseFiles;
            set
            {
                anlyseFiles = value;
                OnPropertyChanged(nameof(AnlyseFiles));
            }
        }
        public DateTime? AnalyseDate
        {
            get => analyseDate;
            set
            {
                analyseDate = value;
                OnPropertyChanged(nameof(AnalyseDate));
            }
        }       
    }
}
