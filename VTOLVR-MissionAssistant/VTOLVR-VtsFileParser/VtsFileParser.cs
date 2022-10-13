using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace VTOLVR_VtsFileParser
{
    /// <summary>Parses the VTS file for VTOL VR missions. This class cannot be inherited.</summary>
    public sealed class VtsFileParser
    {
        #region Strings

        public const string CustomScenario = "CustomScenario";

        #region Sections

        private IReadOnlyList<string> sectionStrings = new List<string>
        {
            "BASES", "Briefing", "Conditionals", "ConditionalActions", "EventSequences", "GlobalValues",
            "OBJECTIVES", "OBJECTIVES_OPFOR", "PATHS", "ResourceManifest", "StaticObjects", "TimedEventGroups",
            "TRIGGER_EVENTS", "UNITGROUPS", "UNITS", "WAYPOINTS"
        };

        public IReadOnlyList<string> SectionStrings => sectionStrings;

        public const string Bases = "BASES";
        public const string Briefing = "Briefing";
        public const string Conditionals = "Conditionals";
        public const string ConditionalActions = "ConditionalActions";
        public const string EventSequences = "EventSequences";
        public const string GlobalValues = "GlobalValues";
        public const string Objectives = "OBJECTIVES";
        public const string ObjectivesOpFor = "OBJECTIVES_OPFOR";
        public const string Paths = "PATHS";
        public const string ResourceManifest = "ResourceManifest";
        public const string StaticObjects = "StaticObjects";
        public const string TimedEventGroups = "TimedEventGroups";
        public const string TriggerEvents = "TRIGGER_EVENTS";
        public const string UnitGroups = "UNITGROUPS";
        public const string Units = "UNITS";
        public const string Waypoints = "WAYPOINTS";

        #endregion

        #region Objects

        private IReadOnlyList<string> objectStrings = new List<string>
        {
            "ACTIONS", "ALLIED", "BASE_BLOCK", "BaseInfo", "BRIEFING_NOTE", "COMP", "completeEvent",
            "CONDITIONAL", "ConditionalAction", "ELSE_ACTIONS", "ELSE_IF", "ENEMY", "EVENT", "EventInfo",
            "EventTarget", "failEvent", "fields", "gv", "ParamAttrInfo", "Objective", "ParamInfo", "PATH",
            "SEQUENCE", "startEvent", "StaticObject", "TimedEventGroup", "TimedEventInfo", "TriggerEvent",
            "UnitSpawner", "UnitFields", "WAYPOINT"
        };

        public IReadOnlyList<string> ObjectStrings => objectStrings;

        public const string Actions = "ACTIONS";
        public const string Allied = "ALLIED";
        public const string BaseBlock = "BASE_BLOCK";
        public const string BaseInfo = "BaseInfo";
        public const string BriefingNote = "BRIEFING_NOTE";
        public const string Comp = "COMP";
        public const string CompleteEvent = "completeEvent";
        public const string Conditional = "CONDITIONAL";
        public const string ConditionalAction = "ConditionalAction";
        public const string ElseActions = "ELSE_ACTIONS";
        public const string ElseIf = "ELSE_IF";
        public const string Enemy = "ENEMY";
        public const string Event = "EVENT";
        public const string EventInfo = "EventInfo";
        public const string EventTarget = "EventTarget";
        public const string FailEvent = "failEvent";
        public const string Fields = "fields";
        public const string GlobalValue = "gv";
        public const string ParamAttrInfo = "ParamAttrInfo";
        public const string Objective = "Objective";
        public const string ParamInfo = "ParamInfo";
        public const string Path = "PATH";
        public const string Sequence = "SEQUENCE";
        public const string StartEvent = "startEvent";
        public const string StaticObject = "StaticObject";
        public const string TimedEventGroup = "TimedEventGroup";
        public const string TimedEventInfo = "TimedEventInfo";
        public const string TriggerEvent = "TriggerEvent";
        public const string UnitSpawner = "UnitSpawner";
        public const string UnitFields = "UnitFields";
        public const string Waypoint = "WAYPOINT";

        #endregion

        #endregion

        #region Fields

        private VtsSection section = VtsSection.None;

        #endregion

        #region Properties

        /// <summary>Gets the VTS file referenced by the parser.</summary>
        public string VtsFile { get; private set; }

        #endregion

        #region Methods

        private void AdvancedLine(VtsFileParserData data, StreamReader sr)
        {
            data.Line = sr.ReadLine();
            data.LineNumber++;
            data.Data = data.Line.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
            data.TabFreeData = data.Data == null ? null : data.Data.Length == 0 ? null : data.Data[0].Replace("\t", "").Trim();
            data.IndentDepth = data.Data == null ? -1 : data.Data.Length == 0 ? -1 : Regex.Match(data.Data[0], "\\t*").Groups[0].Length;

            //Debug.WriteLine($"Line:{data.Line}|Line number:{data.LineNumber}");
        }

        public VtsCustomScenario ParseVtsFile(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
            {
                throw new ArgumentNullException(nameof(file));
            }

            if (!File.Exists(file))
            {
                throw new ArgumentException("File must exist!");
            }

            VtsFile = file;

            return ParseVtsFile();
        }

        private VtsCustomScenario ParseVtsFile()
        {
            VtsCustomScenario scenario = new VtsCustomScenario(VtsFile);
            VtsFileParserData data = new VtsFileParserData();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            section = VtsSection.CustomScenarioProperties;

            try
            {
                using (FileStream fs = new FileStream(VtsFile, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                    {
                        data.Line = sr.ReadLine();

                        if (data.Line != CustomScenario)
                            throw new InvalidDataException("Cannot locate root object \"CustomScenario\". Invalid file.");

                        data.Line = sr.ReadLine(); // opening brace of CustomScenario
                        data.LineNumber = 2;

                        while (!string.IsNullOrWhiteSpace(data.Line))
                        {
                            AdvancedLine(data, sr);

                            ProcessLineOfText(data, scenario, sr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An exception occurred attempting to parse the VTS file.{Environment.NewLine}{ex}");

                scenario.ErrorOnRead = true;
            }

            sw.Stop();

            Debug.WriteLine($"Parse duration:{sw.Elapsed}");

            return scenario;
        }

        private void ProcessLineOfText(VtsFileParserData data, VtsCustomScenario scenario, StreamReader sr)
        {
            // when we only have one element in the line, this will be...
            // 1. '{'
            // 2. '}'
            // 3. a top level collection (UNITS, PATHS, WAYPOINTS, etc.) (we call them sections)
            // 4. an individual object in a collection (UnitSpawner, PATH, WAYPOINT, etc.) (our objects)
            // 5. a child object (UnitFields, TimedEventInfo, ParamInfo, etc.) (more of our objects)
            if (data.Data.Length == 1)
            {
                if (data.TabFreeData != "{" && data.TabFreeData != "}")
                {
                    SetSection(data.TabFreeData);
                }

                if (ObjectStrings.Contains(data.TabFreeData))
                {
                    VtsObject childObject = ProcessObject(data, scenario, sr);

                    switch (section)
                    {
                        case VtsSection.Units:
                            scenario.Units.Add(childObject);
                            break;
                        case VtsSection.Paths:
                            scenario.Paths.Add(childObject);
                            break;
                        case VtsSection.Waypoints:
                            scenario.Waypoints.Add(childObject);
                            break;
                        case VtsSection.UnitGroups:
                            scenario.UnitGroups.Add(childObject);
                            break;
                        case VtsSection.TimedEventGroups:
                            scenario.TimedEventGroups.Add(childObject);
                            break;
                        case VtsSection.TriggerEvents:
                            scenario.TriggerEvents.Add(childObject);
                            break;
                        case VtsSection.Objectives:
                            scenario.Objectives.Add(childObject);
                            break;
                        case VtsSection.StaticObjects:
                            scenario.StaticObjects.Add(childObject);
                            break;
                        case VtsSection.Conditionals:
                            scenario.Conditionals.Add(childObject);
                            break;
                        case VtsSection.ConditionalActions:
                            scenario.ConditionalActions.Add(childObject);
                            break;
                        case VtsSection.EventSequences:
                            scenario.EventSequences.Add(childObject);
                            break;
                        case VtsSection.Bases:
                            scenario.Bases.Add(childObject);
                            break;
                        case VtsSection.GlobalValues:
                            scenario.GlobalValues.Add(childObject);
                            break;
                        case VtsSection.Briefing:
                            scenario.Briefing.Add(childObject);
                            break;
                    }
                }
            }
            else
            {
                switch (section)
                {
                    case VtsSection.CustomScenarioProperties:
                        scenario.Properties.Add(new VtsProperty
                        {
                            IndentDepth = data.IndentDepth,
                            LineNumber = data.LineNumber,
                            Name = data.TabFreeData,
                            Value = data.Data[1].Trim()
                        });
                        break;
                    case VtsSection.ResourceManifest:
                        // we don't need to attempt to process the closing tag of the ResourceManifest sections
                        if (data.Data.Length == 0) return;

                        scenario.ResourceManifest.Add(new VtsProperty
                        {
                            IndentDepth = data.IndentDepth,
                            LineNumber = data.LineNumber,
                            Name = data.TabFreeData,
                            Value = data.Data[1].Trim()
                        });
                        break;
                }
            }
        }

        private VtsObject ProcessObject(VtsFileParserData data, VtsCustomScenario scenario, StreamReader sr, VtsObject parent = null)
        {
            VtsObject obj = new VtsObject
            {
                IndentDepth = data.IndentDepth,
                LineNumber = data.LineNumber,
                Name = data.TabFreeData,
                Parent = parent
            };

            while (!string.IsNullOrWhiteSpace(data.Line))
            {
                AdvancedLine(data, sr);

                if (data.TabFreeData == "{")
                {
                    continue;
                }
                else if (data.TabFreeData == "}")
                {
                    // the object is at an end, return it
                    return obj;
                }
                else if (ObjectStrings.Contains(data.TabFreeData))
                {
                    // just in case a property name matches an object...
                    // let's make sure if its an object we only have 1 data point in data.Data and not 2 (because it was split at the '=')
                    if (data.Data.Length == 2)
                    {
                        obj.Properties.Add(new VtsProperty
                        {
                            IndentDepth = data.IndentDepth,
                            LineNumber = data.LineNumber,
                            Name = data.TabFreeData,
                            Value = data.Data[1].Trim()
                        });
                    }
                    else
                    {
                        VtsObject child = ProcessObject(data, scenario, sr, obj);

                        obj.Children.Add(child);
                    }
                }
                else if (data.Data.Length == 2)
                {
                    obj.Properties.Add(new VtsProperty
                    {
                        IndentDepth = data.IndentDepth,
                        LineNumber = data.LineNumber,
                        Name = data.TabFreeData,
                        Value = data.Data[1].Trim()
                    });
                }
            }

            return obj;
        }

        private void SetSection(string element)
        {
            if (element == Units) section = VtsSection.Units;
            if (element == Paths) section = VtsSection.Paths;
            if (element == Waypoints) section = VtsSection.Waypoints;
            if (element == UnitGroups) section = VtsSection.UnitGroups;
            if (element == TimedEventGroups) section = VtsSection.TimedEventGroups;
            if (element == TriggerEvents) section = VtsSection.TriggerEvents;
            if (element == Objectives) section = VtsSection.Objectives;
            if (element == ObjectivesOpFor) section = VtsSection.ObjectivesOpFor;
            if (element == StaticObjects) section = VtsSection.StaticObjects;
            if (element == Conditionals) section = VtsSection.Conditionals;
            if (element == ConditionalActions) section = VtsSection.ConditionalActions;
            if (element == EventSequences) section = VtsSection.EventSequences;
            if (element == Bases) section = VtsSection.Bases;
            if (element == GlobalValues) section = VtsSection.GlobalValues;
            if (element == Briefing) section = VtsSection.Briefing;
            if (element == ResourceManifest) section = VtsSection.ResourceManifest;
        }

        #endregion
    }
}
