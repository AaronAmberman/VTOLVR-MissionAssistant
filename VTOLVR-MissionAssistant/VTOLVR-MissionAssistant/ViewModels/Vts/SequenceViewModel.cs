using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents an event sequence in VTOL VR.</summary>
    public class SequenceViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private ObservableCollection<EventViewModel> events = new ObservableCollection<EventViewModel>();
        private int id;
        private string sequenceName;
        private bool startImmediately;
        private bool whileLoop;

        #endregion

        #region Properties

        public ObservableCollection<EventViewModel> Events
        {
            get => events;
            set
            {
                events = value;
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

        public string SequenceName
        {
            get => sequenceName;
            set
            {
                sequenceName = value;
                OnPropertyChanged();
            }
        }

        public bool StartImmediately
        {
            get => startImmediately; 
            set
            {
                startImmediately = value;
                OnPropertyChanged();
            }
        }

        public bool WhileLoop
        {
            get => whileLoop; 
            set
            {
                whileLoop = value;
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

        /// <summary>Creates a new instance of <see cref="SequenceViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned Sequence object.</returns>
        public SequenceViewModel Clone()
        {
            return new SequenceViewModel
            {
                Events = new ObservableCollection<EventViewModel>(Events.Select(x => x.Clone()).ToList()),
                Id = Id,
                SequenceName = SequenceName,
                StartImmediately = StartImmediately,
                WhileLoop = WhileLoop,
                Parent = Parent
            };
        }

        #endregion
    }
}
