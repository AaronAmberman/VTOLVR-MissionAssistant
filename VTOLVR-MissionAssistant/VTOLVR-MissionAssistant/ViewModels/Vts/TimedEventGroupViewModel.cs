using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a timed event group in VTOL VR.</summary>
    public class TimedEventGroupViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private bool beginImmediately;
        private int groupId;
        private string groupName;
        private int initialDelay;
        private ObservableCollection<TimedEventInfoViewModel> timedEventInfos = new ObservableCollection<TimedEventInfoViewModel>();

        #endregion

        #region Properties

        public bool BeginImmediately
        {
            get => beginImmediately; 
            set
            {
                beginImmediately = value;
                OnPropertyChanged();
            }
        }

        public int GroupId
        {
            get => groupId; 
            set
            {
                groupId = value;
                OnPropertyChanged();
            }
        }

        public string GroupName
        {
            get => groupName;
            set
            {
                groupName = value;
                OnPropertyChanged();
            }
        }

        public int InitialDelay
        {
            get => initialDelay;
            set
            {
                initialDelay = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TimedEventInfoViewModel> TimedEventInfos
        {
            get => timedEventInfos;
            set
            {
                timedEventInfos = value;
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

        /// <summary>Creates a new instance of <see cref="TimedEventGroupViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned TimedEventGroup object.</returns>
        public TimedEventGroupViewModel Clone()
        {
            return new TimedEventGroupViewModel
            {
                BeginImmediately = BeginImmediately,
                GroupId = GroupId,
                GroupName = GroupName,
                InitialDelay = InitialDelay,
                TimedEventInfos = new ObservableCollection<TimedEventInfoViewModel>(TimedEventInfos.Select(x => x.Clone()).ToList()),
                Parent = Parent
            };
        }

        #endregion
    }
}
