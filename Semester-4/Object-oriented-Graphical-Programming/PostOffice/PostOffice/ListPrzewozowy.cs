namespace PostOffice
{
    using System;
    using System.Text;
    class ListPrzewozowy
    {
        public sbyte NumerPrzesylki { get; }

        public Osoba Nadawca { get; } = null;
        public Osoba Odbiorca { get; } = null;

        public DateTime DataNadania { get; }

        public double Koszt { get; }

        public Paczkomat Paczkomat { get; } = null;

        public ListPrzewozowy(sbyte numerPrzesylki, Osoba nadawca, Osoba odbiorca, DateTime dataNadania, double koszt, Paczkomat paczkomat = null)
        {
            NumerPrzesylki = numerPrzesylki;
            Nadawca = nadawca;
            Odbiorca = odbiorca;
            DataNadania = dataNadania;
            Koszt = koszt;
            Paczkomat = paczkomat;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"Informacja o przesyłce numer: {NumerPrzesylki}\n");
            stringBuilder.Append($"Data nadania: {DataNadania}\n");
            stringBuilder.Append($"Nadawca:\n{Nadawca}\n");
            stringBuilder.Append($"Adresat:\n{Odbiorca}\n");
            stringBuilder.Append($"Adres wysyłki:\n");
            if(Paczkomat != null)
            {
                stringBuilder.Append($"Paczkomat {Paczkomat.Numer}\n");
                stringBuilder.Append($"{Paczkomat.KodPocztowy} {Paczkomat.Miasto}\n");
                stringBuilder.Append($"ul. {Paczkomat.Ulica} {Paczkomat.NumerBudynku}\n");
            }
            else
            {
                stringBuilder.Append($"{Odbiorca.KodPocztowy} {Odbiorca.Miasto}\n");
                stringBuilder.Append($"ul. {Odbiorca.Ulica} {Odbiorca.NumerBudynku}\n");
            }
            stringBuilder.Append($"Kosz przesyłki: {Koszt} zł\n\n\n");

            return stringBuilder.ToString();
        }
    }
}
