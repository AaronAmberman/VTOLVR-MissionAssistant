using System.Diagnostics;

namespace VTOLVR_VtsFileParser
{
    [DebuggerDisplay("Parent:{Parent} | Name:{Name}")]
    public class VtsObject
    {
        #region Properties

        public int IndentDepth { get; set; }
        public int LineNumber { get; set; }
        public List<VtsObject> Children { get; set; }
        public string Name { get; set; }
        public VtsObject Parent { get; set; } // null if on VtsCustomScenario
        public List<VtsProperty> Properties { get; set; }

        #endregion

        #region Constructors

        public VtsObject()
        {
            Children = new List<VtsObject>();
            Properties = new List<VtsProperty>();
        }

        #endregion
    }
}
