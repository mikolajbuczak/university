namespace PostOffice
{
    using System;
    class PrzesylkaPaczkomatowa : Przesylka
    {
        public Paczkomat Paczkomat { get; private set; }

        public PrzesylkaPaczkomatowa(Osoba nadawca, Osoba odbiorca, ushort waga, Rozmiar rozmiar, DateTime dataNadania, Paczkomat paczkomat) :
            base(nadawca, odbiorca, waga, rozmiar, dataNadania) 
        {
            if (rozmiar > Poczta.MaksymalnyRozmiar)
                throw new Exception("Paczka nie zmieści się w paczkomacie.");
            Paczkomat = paczkomat;
        }

        public override double ObliczKoszt()
        {
            return Math.Min(CenaWaga, CenaWymiar);
        }

        public override ListPrzewozowy GenerujListPrzewozowy()
        {
            return new ListPrzewozowy(ID, Nadawca, Odbiorca, DataNadania, ObliczKoszt(), Paczkomat);
        }
    }
}
