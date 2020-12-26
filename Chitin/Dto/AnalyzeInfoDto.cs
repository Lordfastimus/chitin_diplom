using System;
using System.Collections.Generic;

namespace Chitin.Dto
{
	public class AnalyzeInfoDto
	{
		public List<FileAnalizeInfoDto> AnlyseFiles { get; set; }
		public DateTime? AnalyseDate { get; set; }
		public string ProgrammName { get; set; }
		public string GetFileName()
		{
			return ProgrammName + "_" + AnalyseDate?.ToString("dd.MM.yyyy_HH.mm");
		}
	}
}
