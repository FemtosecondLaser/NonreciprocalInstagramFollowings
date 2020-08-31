using NonreciprocalFollowings.NonreciprocalFollowingsIdentifiers;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace NonreciprocalFollowings
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly INonreciprocalFollowingsIdentifier nonReciprocalFollowingsIdentifier;
        private string followers;
        private string following;
        private ObservableCollection<CheckableFollowing> nonReciprocalFollowings;

        public MainViewModel(INonreciprocalFollowingsIdentifier nonReciprocalFollowingsIdentifier)
        {
            if (nonReciprocalFollowingsIdentifier == null)
                throw new ArgumentNullException(nameof(nonReciprocalFollowingsIdentifier));

            this.nonReciprocalFollowingsIdentifier = nonReciprocalFollowingsIdentifier;

            this.FilterNonreciprocalFollowingsCommand =
                new DelegateCommand(FilterNonreciprocalFollowings);
        }

        public string Followers
        {
            get => this.followers;
            set
            {
                this.followers = value;
                this.OnPropertyChanged();
            }
        }

        public string Following
        {
            get => this.following;
            set
            {
                this.following = value;
                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<CheckableFollowing> NonReciprocalFollowings
        {
            get => this.nonReciprocalFollowings;
            private set
            {
                this.nonReciprocalFollowings = value;
                this.OnPropertyChanged();
            }
        }

        public ICommand FilterNonreciprocalFollowingsCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void FilterNonreciprocalFollowings()
        {
            var nonReciprocalFollowingsHashSet =
                this.nonReciprocalFollowingsIdentifier.Identify(
                    this.Followers,
                    this.Following);

            this.NonReciprocalFollowings =
                new ObservableCollection<CheckableFollowing>(
                    nonReciprocalFollowingsHashSet.Select(
                        f => new CheckableFollowing(f)
                        ));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
