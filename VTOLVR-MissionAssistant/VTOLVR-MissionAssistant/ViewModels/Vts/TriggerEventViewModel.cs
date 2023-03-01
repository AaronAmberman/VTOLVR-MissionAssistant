using System;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a trigger event in VTOL VR.</summary>
    public class TriggerEventViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private ConditionalViewModel conditional;
        private bool enabled;
        private EventInfoViewModel eventInfo;
        private string eventName;
        private int id;
        private string proxyMode;
        private float? radius;
        private bool? sphericalRadius;
        private string triggerMode;
        private string triggerType;
        private WaypointViewModel waypoint;

        #endregion

        #region Properties

        public ConditionalViewModel Conditional
        {
            get => conditional; 
            set
            {
                conditional = value;
                OnPropertyChanged();
            }
        }

        public bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                OnPropertyChanged();
            }
        }

        public EventInfoViewModel EventInfo
        {
            get => eventInfo;
            set
            {
                eventInfo = value;
                OnPropertyChanged();
            }
        }

        public string EventName
        {
            get => eventName; 
            set
            {
                eventName = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get => id; 
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string ProxyMode
        {
            get => proxyMode; 
            set
            {
                proxyMode = value;
                OnPropertyChanged();
            }
        }

        public float? Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }

        public bool? SphericalRadius
        {
            get => sphericalRadius; 
            set
            {
                sphericalRadius = value;
                OnPropertyChanged();
            }
        }

        public string TriggerMode
        {
            get => triggerMode;
            set
            {
                triggerMode = value;
                OnPropertyChanged();
            }
        }

        public string TriggerType
        {
            get => triggerType;
            set
            {
                triggerType = value;
                OnPropertyChanged();
            }
        }

        public WaypointViewModel Waypoint
        {
            get => waypoint; 
            set
            {
                waypoint = value;
                OnPropertyChanged();
            }
        }

        public CustomScenarioViewModel Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="TriggerEventViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned TriggerEvent object.</returns>
        public TriggerEventViewModel Clone()
        {
            return new TriggerEventViewModel
            {
                Conditional = Conditional?.Clone(),
                Enabled = Enabled,
                EventInfo = EventInfo?.Clone(),
                EventName = EventName,
                Id = Id,
                ProxyMode = ProxyMode,
                Radius = Radius,
                SphericalRadius = SphericalRadius,
                TriggerMode = TriggerMode,
                TriggerType = TriggerType,
                Waypoint = Waypoint?.Clone(),
                Parent = Parent
            };
        }

        #endregion
    }
}
