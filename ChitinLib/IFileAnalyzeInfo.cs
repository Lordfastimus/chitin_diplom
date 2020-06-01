namespace ChitinLib
{
    public interface IFileAnalyzeInfo
    {
        string Name { get; set; }
        string MD5 {get; set;}
        long Size {get; set;}
        string FullName { get; set; }
    }
}
