using System;
using System.Collections.Generic;

namespace Chitin.Models
{
    [Serializable]
    public class AnalyzeInfo
    {
        public string ProgrammName { get; set; }
        public List<FileAnalyseInfo> AnlyseFiles { get; set; }
        public DateTime AnalyseDate { get; set; }
        public string GetFileName()
        {
            return ProgrammName + "_" + AnalyseDate.ToString("dd.MM.yyyy_HH.mm");
        }
    }
}
