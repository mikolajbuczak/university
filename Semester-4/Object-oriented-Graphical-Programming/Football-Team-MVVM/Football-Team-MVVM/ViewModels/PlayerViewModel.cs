namespace Football_Team_MVVM.ViewModels
{
    using BaseClass;
    using Models;
    using System;
    class PlayerViewModel : ViewModelBase
    {
        Player player = null;

        public PlayerViewModel(Player player)
        {
            this.player = player;
        }

        public Player CurrentPlayer
        {
            get => this.player;
        }
        public string FirstName
        {
            get => player.FirstName;
            set
            {
                player.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get => player.LastName;
            set
            {
                player.FirstName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public ushort Age
        {
            get => player.Age;
            set
            {
                player.Age = value;
                OnPropertyChanged(nameof(Age));
            }
        }
        public double Weight
        {
            get => player.Weight;
            set
            {
                player.Weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }
        public string Info
        {
            get => this.ToString();
        }

        public override string ToString()
        {
            return this.CurrentPlayer.ToString();
        }
    }
}
