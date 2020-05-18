using System.Collections.Generic;
using System.Linq;

namespace ChitinLib
{
    public class CompareService
    {
        const string COUNT_NOT_EQUAL = "Количество значимых файлов различны: {0}, {1}";
        const string SIZE_NOT_EQUAL = "Размеры значимых файлов различны: {0}, {1}";
        const string MD5_NOT_FOUND = "Не найден файл {0}, c MD5 = {1}";
        const string SIZE_NOT_EQUAL2 = "Размеры у файлов {0} c MD5 = {1} не равны: {2} {3}";

        public ICollection<string> Errors { get; set; } = new List<string>();

        public bool ProgrammsAreEquals(IEnumerable<IFileAnalyzeInfo> fileAnalyzeInfos_1, IEnumerable<IFileAnalyzeInfo> fileAnalyzeInfos_2)
        {
            if (fileAnalyzeInfos_1.Count() != fileAnalyzeInfos_2.Count())
            {
                Errors.Add(string.Format(COUNT_NOT_EQUAL, fileAnalyzeInfos_1.Count(), fileAnalyzeInfos_2.Count()));
            }

            if (fileAnalyzeInfos_1.Sum(x => x.Size) != fileAnalyzeInfos_2.Sum(x => x.Size))
            {
                Errors.Add(string.Format(SIZE_NOT_EQUAL, fileAnalyzeInfos_1.Sum(x => x.Size), fileAnalyzeInfos_2.Sum(x => x.Size)));
            }

            foreach (var fileAnalyzeInfo in fileAnalyzeInfos_1)
            {
                var fileFromSecondProgramm = fileAnalyzeInfos_2.FirstOrDefault(x => x.MD5 == fileAnalyzeInfo.MD5 && x.Name == fileAnalyzeInfo.Name);
                if (fileFromSecondProgramm != null)
                {
                    if(fileFromSecondProgramm.Size != fileAnalyzeInfo.Size)
                    {
                        Errors.Add(string.Format(SIZE_NOT_EQUAL2, fileAnalyzeInfo.Name, fileAnalyzeInfo.MD5, fileAnalyzeInfo.Size, fileFromSecondProgramm.Size));
                    }

                }
                else
                {
                    Errors.Add(string.Format(MD5_NOT_FOUND, fileAnalyzeInfo.Name, fileAnalyzeInfo.MD5));
                }
            }

            return Errors.Count == 0;
        }
    }
}
