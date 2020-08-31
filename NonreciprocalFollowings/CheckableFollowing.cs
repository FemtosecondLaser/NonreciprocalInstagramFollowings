using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace NonreciprocalFollowings
{
    public class CheckableFollowing : INotifyPropertyChanged
    {
        public CheckableFollowing(string iD)
        {
            if (iD == null)
                throw new ArgumentNullException(nameof(iD));

            this.ID = iD;
            this.OnPropertyChanged(nameof(ID));
        }

        public string ID { get; }
        public bool IsChecked { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
