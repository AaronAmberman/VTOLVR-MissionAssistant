using System.Collections;
using System.Collections.ObjectModel;
using VTS.Collections;

namespace VTOLVR_MissionAssistant.Collections
{
    public class ObservablePropertyedCollection<T> : ObservableCollection<T>
    {
        public ObservableCollection<DictionaryEntry> properties = new ObservableCollection<DictionaryEntry>();
        public ObservableCollection<DictionaryEntry> Properties { get { return properties; } }

        public ObservablePropertyedCollection()
        {
        }

        public ObservablePropertyedCollection(PropertyedCollection<T> propertyedCollection)
        {
            foreach (T item in propertyedCollection)
            {
                Add(item);
            }

            int count = propertyedCollection.GetPropertyCount();

            for (int i = 0; i < count; i++)
            {
                DictionaryEntry entry = propertyedCollection.GetProperty(i);

                Properties.Add(entry);
            }
        }

        public ObservablePropertyedCollection(ObservablePropertyedCollection<T> propertyedCollection)
        {
            foreach (T item in propertyedCollection)
            {
                Add(item);
            }

            foreach (DictionaryEntry entry in propertyedCollection.Properties)
            {
                Properties.Add(entry);
            }
        }
    }
}
