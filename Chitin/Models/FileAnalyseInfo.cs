using ChitinLib;
using System;

namespace Chitin.Models
{
   public class FileAnalyseInfo : NotifyPropertyChangedBase, IFileAnalyzeInfo
    {
        private string name;
        private string mD5;
        private long size;

        [field: NonSerialized()]
        public string FullName { get; set; }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string MD5
        {
            get => mD5;
            set
            {
                mD5 = value;
                OnPropertyChanged(nameof(MD5));
            }
        }

        public long Size
        {
            get => size;
            set
            {
                size = value;
                OnPropertyChanged(nameof(Size));
            }
        }
    }
}
