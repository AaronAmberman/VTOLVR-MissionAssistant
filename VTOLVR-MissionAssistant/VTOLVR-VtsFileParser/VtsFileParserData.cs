namespace VTOLVR_VtsFileParser
{
    /// <summary>Represents a line of data in the VTS file.</summary>
    public class VtsFileParserData
    {
        public string[] Data { get; set; }
        public string TabFreeData { get; set; }
        public int IndentDepth { get; set; }
        public string Line { get; set; }
        public int LineNumber { get; set; }
    }
}
