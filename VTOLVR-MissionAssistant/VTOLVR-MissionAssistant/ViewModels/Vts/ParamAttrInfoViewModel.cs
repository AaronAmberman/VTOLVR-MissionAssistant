using System;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a param attr info object for a param info object.</summary>
    public class ParamAttrInfoViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private string data;
        private string type;

        #endregion

        #region Properties

        public string Data
        {
            get => data;
            set
            {
                data = value;
                OnPropertyChanged();
            }
        }

        public string Type
        {
            get => type; 
            set
            {
                type = value;
                OnPropertyChanged();
            }
        }

        public ParamInfoViewModel Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="ParamAttrInfoViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned ParamAttrInfo object.</returns>
        public ParamAttrInfoViewModel Clone()
        {
            return new ParamAttrInfoViewModel
            {
                Data = Data,
                Type = Type,
                Parent = Parent
            };
        }

        #endregion
    }
}
