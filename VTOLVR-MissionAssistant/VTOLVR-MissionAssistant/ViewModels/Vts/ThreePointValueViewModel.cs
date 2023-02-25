using System;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a location in a 3D space.</summary>
    public class ThreePointValueViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private float x;
        private float y;
        private float z;

        #endregion

        #region Properties

        public float X
        {
            get => x; set
            {
                x = value;
                OnPropertyChanged();
            }
        }

        public float Y
        {
            get => y; set
            {
                y = value;
                OnPropertyChanged();
            }
        }

        public float Z
        {
            get => z; set
            {
                z = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="ThreePointValueViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned ThreePointValue object.</returns>
        public ThreePointValueViewModel Clone()
        {
            return new ThreePointValueViewModel
            {
                X = X,
                Y = Y,
                Z = Z
            };
        }

        /// <summary>Returns a string representation of the object.</summary>
        /// <returns>A string representing the object.</returns>
        public override string ToString()
        {
            // todo : If I can ever figure out which string format was used for some of the outputs
            //        then we could match the output of the file exactly but I cannot seem to get it
            //        to match all outputs. Specifically I cannot get the ones that have up to 15
            //        decimals to match the file output exactly. The general .ToString does a better
            //        job than any of the custom formats I tried.
            return $"({X}, {Y}, {Z})";
        }

        /// <summary>Returns a string representation of the object.</summary>
        /// <param name="format">The format to use for X, Y and Z.</param>
        /// <returns>A string representing the object with the specified format for X, Y and Z.</returns>
        public string ToString(string format)
        {
            string x = X.ToString(format);
            string y = Y.ToString(format);
            string z = Z.ToString(format);

            return $"({x}, {y}, {z})";
        }

        /// <summary>Returns a string representation of the object.</summary>
        /// <param name="xFormat">The X format.</param>
        /// <param name="yFormat">The Y format.</param>
        /// <param name="zFormat">The Z format.</param>
        /// <returns>A string representing the object with the specified format for each number.</returns>
        public string ToString(string xFormat, string yFormat, string zFormat)
        {
            string x = X.ToString(xFormat);
            string y = Y.ToString(yFormat);
            string z = Z.ToString(zFormat);

            return $"({x}, {y}, {z})";
        }

        #endregion
    }
}
