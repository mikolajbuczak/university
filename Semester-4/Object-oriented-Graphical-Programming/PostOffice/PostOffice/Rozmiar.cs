namespace PostOffice
{
    class Rozmiar
    {
        public ushort Szerokosc { get; private set; }
        public ushort Dlugosc { get; private set; }
        public ushort Wysokosc { get; private set; }

        public Rozmiar(ushort szerokosc, ushort dlugosc, ushort wysokosc)
        {
            Szerokosc = szerokosc;
            Dlugosc = dlugosc;
            Wysokosc = wysokosc;
        }

        public static bool operator <=(Rozmiar a, Rozmiar b)
        {
            return a.Szerokosc <= b.Szerokosc && a.Dlugosc <= b.Dlugosc && a.Wysokosc <= b.Wysokosc;
        }

        public static bool operator >=(Rozmiar a, Rozmiar b)
        {
            return a.Szerokosc >= b.Szerokosc && a.Dlugosc >= b.Dlugosc && a.Wysokosc >= b.Wysokosc;
        }

        public static bool operator <(Rozmiar a, Rozmiar b)
        {
            return a.Szerokosc < b.Szerokosc && a.Dlugosc < b.Dlugosc && a.Wysokosc < b.Wysokosc;
        }

        public static bool operator >(Rozmiar a, Rozmiar b)
        {
            return a.Szerokosc > b.Szerokosc && a.Dlugosc > b.Dlugosc && a.Wysokosc > b.Wysokosc;
        }
    }
}
