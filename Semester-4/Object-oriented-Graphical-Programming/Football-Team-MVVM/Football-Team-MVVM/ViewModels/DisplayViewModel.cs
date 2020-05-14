namespace Football_Team_MVVM.ViewModels
{
    using Models;
    using BaseClass;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.IO;

    internal partial class DisplayViewModel:ViewModelBase
    {
        private ObservableCollection<PlayerViewModel> players = null;
        private ushort[] ages = GetAgeList();

        private static string defaultFirstName = "Wprowadź imię gracza";
        private static string defaultLastName = "Wprowadź nazwisko gracza";
        private static ushort defaultAge = 18;
        private static double defaultWeight = 60;
        private static int defaultIndex = -1;

        private string currentFirstName = defaultFirstName;
        private string currentLastName = defaultLastName;
        private ushort currentAge = defaultAge;
        private double currentWeight = defaultWeight;
        private int currentIndex = defaultIndex;

        public ObservableCollection<PlayerViewModel> Players
        {
            get
            {
                if (players == null)
                {
                    players = new ObservableCollection<PlayerViewModel>();
                    LoadPlayers();
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

        private void SavePlayers()
        {
            List<Player> savePlayers = new List<Player>();
            foreach (PlayerViewModel playerViewModel in players)
                savePlayers.Add(playerViewModel.CurrentPlayer);

            string jsonData = JsonConvert.SerializeObject(savePlayers);
            File.WriteAllText(@"data.json", jsonData);
        }

        private void LoadPlayers()
        {
            if (!File.Exists("data.json"))
            {
                LoadDefaultPlayers();
                return;
            }

            List<Player> loadPlayers = JsonConvert.DeserializeObject<List<Player>>(File.ReadAllText("data.json"));
            if (loadPlayers.Count > 0)
            {
                foreach (Player player in loadPlayers)
                    players.Add(new PlayerViewModel(player));
                return;
            }
            LoadDefaultPlayers();
        }

        private void LoadDefaultPlayers()
        {
            players.Add(new PlayerViewModel(new Player("Mikołaj", "Klatka", 30, 56)));
            players.Add(new PlayerViewModel(new Player()));
            players.Add(new PlayerViewModel(new Player("Brygida", "Dzidy", 45, 30.9)));
        }

        private bool CheckIfExisits(string _name, string _lastName, ushort _age, double _weight)
        {
            foreach(PlayerViewModel playerViewModel in players)
            {
                if (playerViewModel.CurrentPlayer.FirstName == _name &&
                    playerViewModel.CurrentPlayer.LastName == _lastName &&
                    playerViewModel.CurrentPlayer.Age == _age &&
                    playerViewModel.CurrentPlayer.Weight == _weight) return true;
            }
            return false;
        }
    }
}
