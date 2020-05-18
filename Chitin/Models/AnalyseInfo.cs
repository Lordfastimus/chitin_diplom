using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Chitin.Models
{
    [Serializable]
    public class AnalyzeInfo : NotifyPropertyChengedBase
    {
        private ObservableCollection<FileAnalyseInfo> anlyseFiles;
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
        public ObservableCollection<FileAnalyseInfo> AnlyseFiles
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
        public string GetFileName()
        {
            return ProgrammName + "_" + AnalyseDate?.ToString("dd.MM.yyyy_HH.mm");
        }
    }
}
