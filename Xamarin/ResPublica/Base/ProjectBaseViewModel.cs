using System.Collections.Generic;
using CorePCL;

namespace ResPublica.Base
{
    public abstract class ProjectBaseViewModel : BaseViewModel//, INotifyPropertyChanged
    {
		public IDictionary<string, SVGBindingProperty> SvgCollection { get; set; }
        public IDictionary<string, string[]> LookupLists;

        public ProjectBaseViewModel()
        {
            SvgCollection = new Dictionary<string, SVGBindingProperty>();
        }

        //protected void SetProperty<U>(
        //    ref U backingStore, U value,
        //    string propertyName,
        //    Action onChanged = null,
        //    Action<U> onChanging = null)
        //{
        //    if (EqualityComparer<U>.Default.Equals(backingStore, value))
        //        return;

        //    if (onChanging != null)
        //        onChanging(value);

        //    OnPropertyChanging(propertyName);

        //    backingStore = value;

        //    if (onChanged != null)
        //        onChanged();

        //    OnPropertyChanged(propertyName);
        //}

        //#region INotifyPropertyChanging implementation

        //public event PropertyChangingEventHandler PropertyChanging;

        //#endregion

        //public void OnPropertyChanging(string propertyName)
        //{
        //    if (PropertyChanging == null)
        //        return;

        //    PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        //}

        //#region INotifyPropertyChanged implementation

        //public event PropertyChangedEventHandler PropertyChanged;

        //#endregion

        //public void OnPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged == null)
        //        return;

        //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
