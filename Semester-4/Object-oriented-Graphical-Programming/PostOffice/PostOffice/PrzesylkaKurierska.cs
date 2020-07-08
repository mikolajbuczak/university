namespace PostOffice
{
    using System;
    class PrzesylkaKurierska : Przesylka
    {
        public PrzesylkaKurierska(Osoba nadawca, Osoba odbiorca, ushort waga, Rozmiar rozmiar, DateTime dataNadania) :
            base(nadawca, odbiorca, waga, rozmiar, dataNadania) { }

        public override double ObliczKoszt()
        {
            return Math.Max(CenaWaga, CenaWymiar);
        }

        public override ListPrzewozowy GenerujListPrzewozowy()
        {
            return new ListPrzewozowy(ID, Nadawca, Odbiorca, DataNadania, ObliczKoszt());
        }
    }
}
