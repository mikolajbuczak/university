namespace Football_Team_MVVM.Models
{
    using System;
    class Player
    {
        #region Variables
        private string firstName;
        private string lastName;
        private ushort age;
        private double weight;
        #endregion

        /// <summary>
        /// Initializes a default instance of a class Player
        /// </summary>
        public Player()
        {
            this.FirstName = "Mikołaj";
            this.LastName = "Buczak";
            this.Age = 20;
            this.Weight = 100.0;
        }

        /// <summary>
        /// Initializes an instance of a class Player
        /// </summary>
        /// <param name="_firstName">First name of the player.</param>
        /// <param name="_lastName">Last name of the player.</param>
        /// <param name="_age">Age of the player.</param>
        /// <param name="_weight">Weight of the player.</param>
        public Player(string _firstName, string _lastName, ushort _age, double _weight)
        {
            this.FirstName = _firstName;
            this.LastName = _lastName;
            this.Age = _age;
            this.Weight = _weight;
        }

        /// <summary>
        /// Initializes a new instance of a class Player from another instance of class Player
        /// </summary>
        /// <param name="player">Other player</param>
        public Player(Player player)
        {
            this.FirstName = player.FirstName;
            this.LastName = player.LastName;
            this.Age = player.Age;
            this.Weight = player.Weight;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} -> Wiek: {this.Age}, Waga: {this.Weight}kg";
        }

        #region Properties
        public string FirstName
        {
            get => this.firstName;
            set
            {
                this.firstName = value;
            }
        }
        public string LastName
        {
            get => this.lastName;
            set
            {
                this.lastName = value;
            }
        }
        public ushort Age
        {
            get => this.age;
            set
            {
                this.age = value;
            }
        }
        public double Weight
        {
            get => this.weight;
            set
            {
                this.weight = value;
            }
        }
        #endregion
    }
}
