using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a timed event info in VTOL VR.</summary>
    public class TimedEventInfoViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private string eventName;
        private ObservableCollection<EventTargetViewModel> eventTargets = new ObservableCollection<EventTargetViewModel>();
        private int time;

        #endregion

        #region Properties

        public string EventName
        {
            get => eventName; set
            {
                eventName = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<EventTargetViewModel> EventTargets
        {
            get => eventTargets; set
            {
                eventTargets = value;
                OnPropertyChanged();
            }
        }

        public int Time
        {
            get => time; set
            {
                time = value;
                OnPropertyChanged();
            }
        }

        public TimedEventGroupViewModel Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="TimedEventInfoViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned TimedEventInfo object.</returns>
        public TimedEventInfoViewModel Clone()
        {
            return new TimedEventInfoViewModel
            {
                EventName = EventName,
                EventTargets = new ObservableCollection<EventTargetViewModel>(EventTargets.Select(x => x.Clone()).ToList()),
                Time = Time,
                Parent = Parent
            };
        }

        #endregion
    }
}
