namespace Mutual_Friends
{
    using System.Collections.Generic;
    using System.IO;
    using System;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            List<Person> people = null;

            try
            {
                people = LoadFriends(Properties.Resources.FriendshipsFilePath);
            }
            catch(FileNotFoundException e)
            {
                CloseProgram(Code.FILE_NOT_FOUND_EXCEPTION, e.Message);
            }
            catch (ArgumentNullException e)
            {
                CloseProgram(Code.ARGUMENT_NULL_EXCEPTION, e.Message);
            }
            catch (Exception e)
            {
                CloseProgram(Code.EXCEPTION, e.Message);
            }

            Sort(ref people);

            List<int[]> mutualGroups = GetMutualGroups(people);

            List<int[]> groups = GetGroups(mutualGroups, people);

            DisplayGroups(mutualGroups, groups);

            //In my program, there is no possibility for a person to have no friends.
            //There is also no way for a person to have themself in a friend list.
            //Therefore for n people there is 2^n - 2 (for n >= 2) possible cases of mutual friend groups.
            //For example: 
            //For a set of people [1, 2], only available cases are:
            //  - having 1 in a friend list
            //  - having 2 in a friend list
            //In order to loop through all of available combinations I will use binary system.
            //Number of people will determine a length of a number, i.e.: for n = 4 the binary number will have 4 bits.
            //Let's continue with an example when n = 4.
            //Every mutual friend group is a set of indices. For example: [1, 2] or [0, 2, 3].
            //Every index indicates which bit of that binary number should be active (have a value of 1).
            //For exapmle: index = 2 would point at the third bit from the right side (counting from 0).
            //So a set [0, 2, 3] would translate as:
            //         [1 1 0 1]
            //This result - 1101 would convert to a decimal system as 13.
            //This number will be the last index that we should check.
            //The fact that a Person cannot have an empty freind list elimantes a binary number made of 0s only, in this example 0000.
            //The fact that a Person cannot have themself in their friend list eliminates a binary number made of 1s only, in this example 1111.
            //We can translate every binary number to decimal equivalent.
            //Our number 1101 would be 13.
            //It all concludes to the fact that, in order to loop through every single combination of mutual friends, we can loop through numbers from 1 to 2n - 2.

            CloseProgram(Code.CORRECT, null);
        }

        static List<Person> LoadFriends(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("File containing friendships not found.");
            string[] friendships = File.ReadAllLines(path);
            var ppl = new List<Person>();
            foreach (var friendship in friendships)
            {
                string[] friends = friendship.Split(',');

                if (!int.TryParse(friends[0], out int idPersonA) ||
                    !int.TryParse(friends[1], out int idPersonB)) 
                    throw new ArgumentNullException("ID must be an integer.", new Exception());

                if (idPersonA == idPersonB) throw new ArgumentException("IDs must differ.");

                var personA = ppl.Find(person => person.ID == idPersonA);
                if (personA == null)
                {
                    personA = new Person(idPersonA);
                    ppl.Add(personA);
                }

                var personB = ppl.Find(person => person.ID == idPersonB);
                if (personB == null)
                {
                    personB = new Person(idPersonB);
                    ppl.Add(personB);
                }

                if (personA.Friends.Contains(idPersonB)) throw new Exception($"Person with ID: {idPersonA} already has a person with ID: {idPersonB} in their friend list.");
                if (personB.Friends.Contains(idPersonA)) throw new Exception($"Person with ID: {idPersonB} already has a person with ID: {idPersonA} in their friend list.");

                personA.AddFriend(idPersonB);
                personB.AddFriend(idPersonA);
            }
            return ppl;
        }

        static List<int[]> GetMutualGroups(List<Person> people)
        {
            List<int[]> groups = new List<int[]>();
            //n is number of people
            int n = people.Count;

            //maximum allowed number of bits has to be smaller than number of people by two.
            //Let's consider a case of 3 people.
            //The only avilable cases of mutual friends are: 0, 1, or 2. 
            //Each number represents the index of a bit that should be active.
            //There is no possiblity to have a mutual friends group of count higher than 1.
            int maxBits = n - 2;

            //smallest nuumber to consider is always one because there is no possobility to have no friends.
            int minNumber = 1;

            //maximum number of combinations is 2^n - 2
            int maxNumber = (1 << n) - 2;

            //loop through all of the possible combinations
            for (int i = minNumber; i <= maxNumber; i++)
            {
                //Let's consider a number = i
                int number = i;

                //calculate number of active bits
                int bits = 0;
                while (number > 0)
                {
                    bits += number & 1;
                    number >>= 1;
                }

                //if number of active bits is bigger then maximum allowed number of bits, proceed to the next number
                if (bits > maxBits)
                    continue;

                //reset a value of number
                number = i;

                //create a list of indecies that are a part of cosidered combination
                List<int> indecies = new List<int>();

                //calculate those indecies
                int index = 0;
                while(number > 0)
                {
                    if ((number & 1) == 1)
                        indecies.Add(index);
                    number >>= 1;
                    index++;
                }

                groups.Add(indecies.ToArray());
            }
            return groups;
        }

        static List<int[]> GetGroups(List<int[]> mutualGroups, List<Person> people)
        {
            List<int[]> groups = new List<int[]>();
            foreach(var group in mutualGroups)
            {
                List<int> localGroup = new List<int>();
                foreach(var person in people)
                {
                    bool allFriends = true;
                    for(int i = 0; i < group.Length; i++)
                    {
                        if (!person.Friends.Contains(group[i]))
                        {
                            allFriends = false;
                            break;
                        }
                    }
                    if (allFriends) localGroup.Add(person.ID);
                }
                groups.Add(localGroup.ToArray());
            }
            return groups;
        }

        static void DisplayGroups(List<int[]> mututalFriendsGroups, List<int[]> groups)
        {
            for (int i = 0; i < mututalFriendsGroups.Count; i++)
            {
                if (groups[i].Length < 2) continue;

                Console.Write($"Mutual friends: [{mututalFriendsGroups[i][0]}");
                for (int j = 1; j < mututalFriendsGroups[i].Length; j++)
                    Console.Write($", {mututalFriendsGroups[i][j]}");

                Console.Write("]\n");

                Console.Write($"   [{groups[i][0]}");
                for (int j = 1; j < groups[i].Length; j++)
                    Console.Write($", {groups[i][j]}");
                Console.WriteLine("]\n");
            }
        }

        static void Sort(ref List<Person> people)
        {
            people = people.OrderBy(x => x.ID).ToList();
            foreach (var person in people)
                person.Friends.Sort();
        }

        enum Code
        {
            CORRECT = 0,
            FILE_NOT_FOUND_EXCEPTION = -1,
            ARGUMENT_NULL_EXCEPTION = -2,
            EXCEPTION = -3
        }

        static void CloseProgram(Code code, string message)
        {
            if (message != null)
            {
                Console.WriteLine();
                Console.WriteLine($"{code} occured.");
                Console.WriteLine();
                Console.WriteLine(message);
            }

            Console.WriteLine();

            Console.WriteLine($"Application closed with code {(int)code}.");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Environment.Exit((int)code);
        }
    }
}
