using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a event info on a trigger event.</summary>
    public class EventInfoViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private string eventName;
        private ObservableCollection<EventTargetViewModel> eventTargets = new ObservableCollection<EventTargetViewModel>();

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

        public ObservableCollection<EventTargetViewModel> EventTargets
        {
            get => eventTargets; 
            set
            {
                eventTargets = value;
                OnPropertyChanged();
            }
        }

        // can be a Block, a TriggerEvent, Objective or a Sequence
        public object Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="EventInfoViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned EventInfo object.</returns>
        public EventInfoViewModel Clone()
        {
            return new EventInfoViewModel
            {
                EventName = EventName,
                EventTargets = new ObservableCollection<EventTargetViewModel>(EventTargets.Select(x => x.Clone()).ToList()),
                Parent = Parent
            };
        }

        #endregion
    }
}
