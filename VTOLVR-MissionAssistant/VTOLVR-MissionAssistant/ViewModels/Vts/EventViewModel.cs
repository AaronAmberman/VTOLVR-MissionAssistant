using System;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents an event for an event sequence.</summary>
    public class EventViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private ConditionalViewModel conditional;
        private int delay;
        private EventInfoViewModel eventInfo;
        private ConditionalViewModel exitConditional;
        private string nodeName;

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

        public int Delay
        {
            get => delay; set
            {
                delay = value;
                OnPropertyChanged();
            }
        }

        public EventInfoViewModel EventInfo
        {
            get => eventInfo; set
            {
                eventInfo = value;
                OnPropertyChanged();
            }
        }

        public ConditionalViewModel ExitConditional
        {
            get => exitConditional; set
            {
                exitConditional = value;
                OnPropertyChanged();
            }
        }

        public string NodeName
        {
            get => nodeName; set
            {
                nodeName = value;
                OnPropertyChanged();
            }
        }

        public SequenceViewModel Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="EventViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned Event object.</returns>
        public EventViewModel Clone()
        {
            return new EventViewModel
            {
                Conditional = Conditional?.Clone(),
                Delay = Delay,
                EventInfo = EventInfo?.Clone(),
                ExitConditional = ExitConditional?.Clone(),
                NodeName = NodeName,
                Parent = Parent
            };
        }

        #endregion
    }
}
