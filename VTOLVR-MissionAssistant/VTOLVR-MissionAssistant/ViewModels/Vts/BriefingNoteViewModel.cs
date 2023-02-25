using System;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a briefing note in VTOL VR.</summary>
    public class BriefingNoteViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private string audioClipPath;
        private string imagePath;
        private string text;

        #endregion

        #region Properties

        public string AudioClipPath 
        { 
            get => audioClipPath;
            set
            {
                audioClipPath = value;
                OnPropertyChanged();
            }
        }

        public string ImagePath 
        { 
            get => imagePath;
            set
            {
                imagePath = value;
                OnPropertyChanged();
            }
        }

        public string Text 
        { 
            get => text;
            set
            {
                text = value;
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

        /// <summary>Creates a new instance of <see cref="BriefingNoteViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned BriefingNote object.</returns>
        public BriefingNoteViewModel Clone()
        {
            return new BriefingNoteViewModel
            {
                AudioClipPath = AudioClipPath,
                ImagePath = ImagePath,
                Text = Text,
                Parent = Parent
            };
        }

        #endregion
    }
}
