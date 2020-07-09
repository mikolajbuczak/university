namespace PostOffice
{
    using System;
    class PrzesylkaEkspres : Przesylka
    {
        public PrzesylkaEkspres(Osoba nadawca, Osoba odbiorca, ushort waga, Rozmiar rozmiar, DateTime dataNadania) :
            base(nadawca, odbiorca, waga, rozmiar, dataNadania) { }

        public override double ObliczKoszt()
        {
            return CenaWaga + CenaWymiar;
        }

        public override ListPrzewozowy GenerujListPrzewozowy()
        {
            return new ListPrzewozowy(ID, Nadawca, Odbiorca, DataNadania, ObliczKoszt());
        }
    }
}
