namespace PostOffice
{
    using System;
    using System.Linq;
    abstract class Przesylka
    {
        protected sbyte ID { get; }

        protected Osoba Nadawca { get; }
        protected Osoba Odbiorca { get; }

        protected ushort Waga { get; }
        protected Rozmiar Wymiary { get; }

        protected DateTime DataNadania { get; }

        protected double CenaWaga { get; }
        protected double CenaWymiar { get; }

        protected Przesylka(Osoba nadawca, Osoba odbiorca, ushort waga, Rozmiar rozmiar, DateTime dataNadania)
        {
            if (Poczta.ID == sbyte.MaxValue)
                throw new OverflowException("Zbyt duża liczba przesyłek");

            if (nadawca == null)
                throw new ArgumentException("Nie podano nadawcy.");

            if (odbiorca == null)
                throw new ArgumentException("Nie podano odbiorcy.");

            if (waga > Poczta.CenaWagi.Last().Waga)
                throw new ArgumentException("Przesyłka jest za ciężka.");

            if(rozmiar < Poczta.MinimalnyRozmiar)
                throw new ArgumentException("Przesyłka jest za mała.");

            if (rozmiar > Poczta.CenaWymiar.Last().Wymiary)
                throw new ArgumentException("Przesyłka jest za duża.");

            if(dataNadania == default)
                throw new ArgumentException("Podano nieprawidłową datę nadania przesyłki.");

            ID = Poczta.ID++;

            Nadawca = nadawca;
            Odbiorca = odbiorca;

            Waga = waga;
            Wymiary = rozmiar;

            DataNadania = dataNadania;

            CenaWaga = Poczta.CenaWagi.Last(x => x.Waga <= Waga).Cena;
            CenaWymiar = Poczta.CenaWymiar.First(y => Wymiary <= y.Wymiary).Cena;
        }

        public abstract double ObliczKoszt();
        public abstract ListPrzewozowy GenerujListPrzewozowy();

    }
}
