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

        #region Properties
        public string FirstName
        {
            get => this.firstName;
            set
            {
                if (value == String.Empty) throw new Exception("First name cannot be an empty string.");
                this.firstName = value;
            }
        }
        public string LastName
        {
            get => this.lastName;
            set
            {
                if (value == String.Empty) throw new Exception("Last name cannot be an empty string.");
                this.lastName = value;
            }
        }
        public ushort Age
        {
            get => this.age;
            set
            {
                if (value < 18 || value > 55) throw new Exception("Age has to be within the range from 18 to 55.");
                this.age = value;
            }
        }
        public double Weight
        {
            get => this.weight;
            set
            {
                if (value < 50.0 || value > 100.0) throw new Exception("Weight has to be withing the range from 50 to 100 kilograms.");
                this.weight = value;
            }
        }
        #endregion
    }
}
