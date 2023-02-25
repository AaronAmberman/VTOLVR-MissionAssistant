using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents an event target in VTOL VR.</summary>
    public class EventTargetViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private string eventName;
        private string methodName;
        private ObservableCollection<ParamInfoViewModel> paramInfos = new ObservableCollection<ParamInfoViewModel>();
        private object target;
        private string targetType;

        #endregion

        #region Properties

        public string EventName
        {
            get => eventName;
            set
            {
                eventName = value;
                OnPropertyChanged();
            }
        }

        public string MethodName
        {
            get => methodName;
            set
            {
                methodName = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ParamInfoViewModel> ParamInfos
        {
            get => paramInfos;
            set
            {
                paramInfos = value;
                OnPropertyChanged();
            }
        }

        // this could be a UnitSpawner, a UnitGroup, a TriggerEvent, a System value (like an int), a ConditionalAction, 
        // an Objective, a Sequence, a TimedEventGroup, a List<UnitSpawner>, a StaticObject
        public object Target
        {
            get => target; 
            set
            {
                target = value;
                OnPropertyChanged();
            }
        }

        public string TargetType
        {
            get => targetType; 
            set
            {
                targetType = value;
                OnPropertyChanged();
            }
        }

        public object Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="EventTargetViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned EventTarget object.</returns>
        public EventTargetViewModel Clone()
        {
            return new EventTargetViewModel
            {
                EventName = EventName,
                MethodName = MethodName,
                ParamInfos = new ObservableCollection<ParamInfoViewModel>(ParamInfos.Select(x => x.Clone()).ToList()),
                Target = Target,
                TargetType = TargetType,
                Parent = Parent
            };
        }

        #endregion
    }
}
