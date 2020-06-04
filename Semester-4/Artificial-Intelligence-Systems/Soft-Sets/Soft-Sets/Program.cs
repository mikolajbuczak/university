namespace Soft_Sets
{
    using System;

    class Program
    {
        static void Main()
        {
            #region Trousers
            Trousers TrousersA = new Trousers(Trousers.Attributes.Jeans, Trousers.Attributes.Modern, Trousers.Attributes.Zip);
            Trousers TrousersB = new Trousers(Trousers.Attributes.Jeans, Trousers.Attributes.Classic, Trousers.Attributes.Blue, Trousers.Attributes.Buttons);

            Console.WriteLine("The best trousers for person A are:");
            TrousersA.ShowBestMatches();

            Console.WriteLine("The best trousers for person B are:");
            TrousersB.ShowBestMatches();
            #endregion

            #region Vegetables
            Vegetables VegetablesA = new Vegetables(Vegetables.Attributes.Fresh, Vegetables.Attributes.Spicy, Vegetables.Attributes.Red);
            Vegetables VegetablesB = new Vegetables(Vegetables.Attributes.Frozen, Vegetables.Attributes.Green, Vegetables.Attributes.Sweet, Vegetables.Attributes.Leafy);
            Vegetables VegetablesC = new Vegetables(Vegetables.Attributes.Fresh, Vegetables.Attributes.Green, Vegetables.Attributes.Red, Vegetables.Attributes.Sweet);

            Console.WriteLine("The best vegetables for person A are:");
            VegetablesA.ShowBestMatches();

            Console.WriteLine("The best vegetables for person B are:");
            VegetablesB.ShowBestMatches();

            Console.WriteLine("The best vegetables for person C are:");
            VegetablesC.ShowBestMatches();
            #endregion

            Console.ReadKey();
        }
    }
}
