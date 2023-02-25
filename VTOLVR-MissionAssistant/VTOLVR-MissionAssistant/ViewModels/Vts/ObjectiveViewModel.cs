using System;
using System.Collections.ObjectModel;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents an objective in VTOL VR.</summary>
    public class ObjectiveViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private bool autoSetWaypoint;
        private int completionReward;
        private ObjectiveFieldsViewModel fields;
        private string objectiveInfo;
        private int objectiveID;
        private string objectiveName;
        private string objectiveType;
        private int orderID;
        private bool required;
        private ObservableCollection<ObjectiveViewModel> preReqObjectives = new ObservableCollection<ObjectiveViewModel>();
        private string startMode;
        private object waypoint;
        private EventInfoViewModel completeEvent;
        private EventInfoViewModel failEvent;
        private EventInfoViewModel startEvent;

        #endregion

        #region Properties

        public bool AutoSetWaypoint
        {
            get => autoSetWaypoint; 
            set
            {
                autoSetWaypoint = value;
                OnPropertyChanged();
            }
        }

        public int CompletionReward
        {
            get => completionReward;
            set
            {
                completionReward = value;
                OnPropertyChanged();
            }
        }

        public ObjectiveFieldsViewModel Fields
        {
            get => fields;
            set
            {
                fields = value;
                OnPropertyChanged();
            }
        }

        public string ObjectiveInfo
        {
            get => objectiveInfo;
            set
            {
                objectiveInfo = value;
                OnPropertyChanged();
            }
        }

        public int ObjectiveID
        {
            get => objectiveID; 
            set
            {
                objectiveID = value;
                OnPropertyChanged();
            }
        }

        public string ObjectiveName
        {
            get => objectiveName; 
            set
            {
                objectiveName = value;
                OnPropertyChanged();
            }
        }

        public string ObjectiveType
        {
            get => objectiveType;
            set
            {
                objectiveType = value;
                OnPropertyChanged();
            }
        }

        public int OrderID
        {
            get => orderID; 
            set
            {
                orderID = value;
                OnPropertyChanged();
            }
        }

        public bool Required
        {
            get => required; 
            set
            {
                required = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ObjectiveViewModel> PreReqObjectives
        {
            get => preReqObjectives;
            set
            {
                preReqObjectives = value;
                OnPropertyChanged();
            }
        }

        public string StartMode
        {
            get => startMode; 
            set
            {
                startMode = value;
                OnPropertyChanged();
            }
        }

        public object Waypoint
        {
            get => waypoint; 
            set
            {
                waypoint = value;
                OnPropertyChanged();
            }
        }

        public EventInfoViewModel CompleteEvent
        {
            get => completeEvent; 
            set
            {
                completeEvent = value;
                OnPropertyChanged();
            }
        }

        public EventInfoViewModel FailEvent
        {
            get => failEvent; 
            set
            {
                failEvent = value;
                OnPropertyChanged();
            }
        }

        public EventInfoViewModel StartEvent
        {
            get => startEvent; 
            set
            {
                startEvent = value;
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

        /// <summary>Creates a new instance of <see cref="ObjectiveViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned Objective object.</returns>
        public ObjectiveViewModel Clone()
        {
            return new ObjectiveViewModel
            {
                AutoSetWaypoint = AutoSetWaypoint,
                CompletionReward = CompletionReward,
                Fields = Fields.Clone(),
                ObjectiveInfo = ObjectiveInfo,
                ObjectiveID = ObjectiveID,
                ObjectiveName = ObjectiveName,
                ObjectiveType = ObjectiveType,
                OrderID = OrderID,
                Required = Required,
                PreReqObjectives = PreReqObjectives,
                StartMode = StartMode,
                Waypoint = Waypoint is ICloneable cloneable ? cloneable.Clone() : Waypoint, // prefer clone, else just reference
                CompleteEvent = CompleteEvent.Clone(),
                FailEvent = FailEvent.Clone(),
                StartEvent = StartEvent.Clone(),
                Parent = Parent
            };
        }

        #endregion
    }
}
