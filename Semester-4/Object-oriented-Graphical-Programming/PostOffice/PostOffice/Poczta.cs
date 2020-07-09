namespace PostOffice
{
    using System.Collections.Generic;
    static class Poczta
    {
        public static sbyte ID = 0;

        public static readonly Rozmiar MaksymalnyRozmiar = new Rozmiar(410, 380, 640);
        public static readonly Rozmiar MinimalnyRozmiar = new Rozmiar(90, 140, 20);
        
        public static List<WagaCena> CenaWagi = new List<WagaCena>() { new WagaCena(1000, 13),
                                                                       new WagaCena(2000, 15),
                                                                       new WagaCena(5000, 18),
                                                                       new WagaCena(10000, 24)};

        public static List<WymiarCena> CenaWymiar = new List<WymiarCena>() { new WymiarCena(new Rozmiar(500, 600, 300), 15),
                                                                             new WymiarCena( new Rozmiar(1000, 1000, 1000), 20)};

        public struct WagaCena
        {
            public ushort Waga;
            public double Cena;
            
            public WagaCena(ushort waga, double cena)
            {
                Waga = waga;
                Cena = cena;
            }
        }

        public struct WymiarCena
        {
            public Rozmiar Wymiary;
            public double Cena;

            public WymiarCena(Rozmiar rozmiar, double cena)
            {
                Wymiary = rozmiar;
                Cena = cena;
            }
        }
    }
}
