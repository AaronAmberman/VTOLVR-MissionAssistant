namespace VTOLVR_VtsFileParser
{
    public class VtsCustomScenario
    {
        #region Properties

        public List<VtsProperty> Properties { get; set; }
        public List<VtsObject> Units { get; set; }
        public List<VtsObject> Paths { get; set; }
        public List<VtsObject> Waypoints { get; set; }
        public List<VtsObject> UnitGroups { get; set; }
        public List<VtsObject> TimedEventGroups { get; set; }
        public List<VtsObject> TriggerEvents { get; set; }
        public List<VtsObject> Objectives { get; set; }
        public List<VtsObject> StaticObjects { get; set; }
        public List<VtsObject> Conditionals { get; set; }
        public List<VtsObject> ConditionalActions { get; set; }
        public List<VtsObject> EventSequences { get; set; }
        public List<VtsObject> Bases { get; set; }
        public List<VtsObject> GlobalValues { get; set; }
        public List<VtsObject> Briefing { get; set; }
        public List<VtsProperty> ResourceManifest { get; set; }

        public bool ErrorOnRead { get; set; }

        /// <summary>Gets the VTS file referenced.</summary>
        public string VtsFile { get; }

        #endregion

        #region Constructors

        public VtsCustomScenario(string vtsFile)
        {
            VtsFile = vtsFile;

            Properties = new List<VtsProperty>();
            Units = new List<VtsObject>();
            Paths = new List<VtsObject>();
            Waypoints = new List<VtsObject>();
            UnitGroups = new List<VtsObject>();
            TimedEventGroups = new List<VtsObject>();
            TriggerEvents = new List<VtsObject>();
            Objectives = new List<VtsObject>();
            StaticObjects = new List<VtsObject>();
            Conditionals = new List<VtsObject>();
            ConditionalActions = new List<VtsObject>();
            EventSequences = new List<VtsObject>();
            Bases = new List<VtsObject>();
            GlobalValues = new List<VtsObject>();
            Briefing = new List<VtsObject>();
            ResourceManifest = new List<VtsProperty>();
        }

        #endregion
    }
}
