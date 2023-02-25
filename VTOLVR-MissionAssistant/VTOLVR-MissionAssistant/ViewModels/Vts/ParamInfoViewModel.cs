using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using VTS;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a param info object.</summary>
    public class ParamInfoViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private string name;
        private ObservableCollection<ParamAttrInfoViewModel> paramAttrInfos = new ObservableCollection<ParamAttrInfoViewModel>();
        private string type;
        private object value;

        #endregion

        #region Properties

        public string Name
        {
            get => name; 
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ParamAttrInfoViewModel> ParamAttrInfos { get => paramAttrInfos; set => paramAttrInfos=value; }

        public string Type
        {
            get => type; 
            set
            {
                type = value;
                OnPropertyChanged();
            }
        }

        public object Value
        {
            get => value; 
            set
            {
                this.value = value;
                OnPropertyChanged();
            }
        }

        public EventTargetViewModel Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="ParamInfoViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned ParamInfo object.</returns>
        public ParamInfoViewModel Clone()
        {
            ParamInfoViewModel pi = new ParamInfoViewModel
            {
                Name = Name,
                ParamAttrInfos = new ObservableCollection<ParamAttrInfoViewModel>(ParamAttrInfos.Select(x => x.Clone()).ToList()),
                Type = Type,
                Parent = Parent
            };

            /*
             * System.Boolean : value = False || True
             * System.Single : value = 1 || 1.0
             * System.String : value = '' (or any other string)
             * UnitReference : value = -1:0 (this means empty I guess) || 6 (UnitSpawner object)
             * UnitReferenceListAI : value = 0;7; (; separated list of unit ids)
             * UnitReferenceListOtherSubs : value = 157;158;179;180;183;184;260;261;312;178;152;154;159; (; separated list of unit ids)
             * ConditionalActionReference : value = 0 (id of action)
             * AirportReference : value = map:0 (base -> BaseInfo object) || unit:0 (UnitSpawner object)
             * VTSAudioReference : value = null (path on hard drive)
             * GlobalValue : value = 0 (index of global value)
             * FollowPath : value = 23 (id of path)
             * Waypoint : value = 8 (id of waypoint)
             * Teams : value = Allied || Enemy
             * FixedPoint : value = (52126.018064498901, 2258.798828125, 38374.517822265625) (ThreePointValue)
             * GroundUnitSpawn+MoveSpeeds : value = Fast_30 || Medium_20 || Slow_10
             * SmokeFlare+FlareColors : value = Blue
             */

            if (pi.Type == KeywordStrings.SystemBoolean || pi.Type == KeywordStrings.SystemSingle || pi.Type == KeywordStrings.SystemString ||
                pi.Type == KeywordStrings.Teams || pi.Type == KeywordStrings.GroundUnitSpawnPlusMoveSpeeds || pi.Type == KeywordStrings.SmokeFlarePlusFlareColors)
            {
                pi.Value = Value;
            }
            else if (pi.Type == KeywordStrings.UnitReference)
            {
                UnitSpawnerViewModel unit = Value as UnitSpawnerViewModel;

                pi.Value = unit?.Clone();
            }
            else if (pi.Type == KeywordStrings.UnitReferenceListAI || pi.Type == KeywordStrings.UnitReferenceListOtherSubs)
            {
                ObservableCollection<UnitSpawnerViewModel> units = Value as ObservableCollection<UnitSpawnerViewModel>;

                if (units != null)
                {
                    ObservableCollection<UnitSpawnerViewModel> newUnits = new ObservableCollection<UnitSpawnerViewModel>();

                    foreach (UnitSpawnerViewModel unit in units)
                    {
                        newUnits.Add(unit.Clone());
                    }

                    pi.Value = newUnits;
                }
            }
            else if (pi.Type == KeywordStrings.ConditionalActionReference)
            {
                ConditionalActionViewModel conditionalAction = Value as ConditionalActionViewModel;

                pi.Value = conditionalAction?.Clone();
            }
            else if (pi.Type == KeywordStrings.AirportReference)
            {
                if (Value is BaseInfoViewModel baseInfo)
                {
                    pi.Value = baseInfo?.Clone();
                }
                else if (Value is UnitSpawnerViewModel unit)
                {
                    pi.Value = unit?.Clone();
                }
            }
            else if (pi.Type == KeywordStrings.VTSAudioReference)
            {
                FileInfo file = Value as FileInfo;

                if (file != null)
                {
                    pi.Value = new FileInfo(file.FullName);
                }
            }
            else if (pi.Type == KeywordStrings.GlobalValueParamInfoType)
            {
                GlobalValueViewModel globalValue = Value as GlobalValueViewModel;

                pi.Value = globalValue?.Clone();
            }
            else if (pi.Type == KeywordStrings.FollowPath)
            {
                PathViewModel path = Value as PathViewModel;

                pi.Value = path?.Clone();
            }
            else if (pi.Type == KeywordStrings.WaypointParamInfoType)
            {
                WaypointViewModel waypoint = Value as WaypointViewModel;

                pi.Value = waypoint?.Clone();
            }
            else if (pi.Type == KeywordStrings.FixedPoint)
            {
                ThreePointValueViewModel threePointValue = Value as ThreePointValueViewModel;

                pi.Value = threePointValue?.Clone();
            }

            return pi;
        }

        #endregion
    }
}
