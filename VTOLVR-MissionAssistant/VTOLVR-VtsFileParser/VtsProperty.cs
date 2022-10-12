using System.Diagnostics;

namespace VTOLVR_VtsFileParser
{
    [DebuggerDisplay("{Name} = {Value}")]
    public class VtsProperty
    {
        #region Properties

        public int IndentDepth { get; set; }
        public int LineNumber { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        #endregion
    }
}
