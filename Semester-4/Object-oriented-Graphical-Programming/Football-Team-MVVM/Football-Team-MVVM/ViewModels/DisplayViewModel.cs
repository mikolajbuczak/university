namespace Football_Team_MVVM.ViewModels
{
    using BaseClass;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    internal partial class DisplayViewModel:ViewModelBase
    {
        private ObservableCollection<PlayerViewModel> players = null;
        private ushort[] ages = GetAgeList();

        private string currentFirstName = "Enter the first name";
        private string currentLastName = "Enter the last name";
        private ushort currentAge = 18;
        private double currentWeight = 55;
        private int currentIndex = -1;

        public ObservableCollection<PlayerViewModel> Players
        {
            get
            {
                if (players == null)
                {
                    players = new ObservableCollection<PlayerViewModel>();
                    //LoadPlayers();
                }
                return players;
            }
        }

        public ushort[] Ages
        {
            get => this.ages;
        }

        public string CurrentFirstName
        {
            get => this.currentFirstName;
            set { this.currentFirstName = value; }
        }

        public string CurrentLastName
        {
            get => this.currentLastName;
            set { this.currentLastName = value; }
        }

        public ushort CurrentAge
        {
            get => this.currentAge;
            set { this.currentAge = value; }
        }

        public double CurrentWeight
        {
            get => this.currentWeight;
            set { this.currentWeight = value; }
        }

        public int CurrentIndex
        {
            get => this.currentIndex;
            set { this.currentIndex = value; }
        }

        private static ushort[] GetAgeList()
        {
            List<ushort> ages = new List<ushort>();
            for (ushort i = 18; i <= 50; i++)
                ages.Add(i);
            return ages.ToArray();
        }
    }
}
