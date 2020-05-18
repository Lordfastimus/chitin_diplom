﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chitin.Models
{
    [Serializable]
    public class FileAnalyseInfo : INotifyPropertyChanged
    {
        private string name;
        private string mD5;
        private long size;

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

        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}