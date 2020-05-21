namespace Mutual_Friends
{
    using System.Collections.Generic;
    class Person
    {
        #region Fields
        readonly int? id = null;
        readonly List<int> friends = null;
        #endregion

        public Person(int _id)
        {
            id = _id;
            friends = new List<int>();
        }

        public void AddFriend(int friendID)
        {
            friends.Add(friendID);
        }

        public override string ToString()
        {
            return id.ToString();
        }

        #region Attributes
        public int ID
        {
            get => id.Value;
        }

        public List<int> Friends
        {
            get => friends;
        }
        #endregion
    }
}
