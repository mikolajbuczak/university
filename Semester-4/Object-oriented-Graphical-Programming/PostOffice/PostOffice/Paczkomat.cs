namespace PostOffice
{
    using System;
    using System.Text.RegularExpressions;
    class Paczkomat
    {
        public static sbyte Enumerator = 0;
        public sbyte Numer { get; private set; }
        public string Miasto { get; private set; }
        public string KodPocztowy { get; private set; }
        public string Ulica { get; private set; }
        public string NumerBudynku { get; private set; }

        public Paczkomat(string miasto, string kodPocztowy, string ulica, string numerBudynku)
        {
            if (Enumerator == sbyte.MaxValue)
                throw new OverflowException("Zbyt duża liczba paczkomatów.");
            Numer = Enumerator++;

            if (String.IsNullOrEmpty(miasto.Trim()))
                throw new ArgumentException("Podano nieprawidłowe miasto.");
            Miasto = miasto.Trim();

            if (!Regex.IsMatch(kodPocztowy.Trim(), "\\d{2}-\\d{3}"))
                throw new ArgumentException("Podano nieprawidłowy kod pocztowy.");
            KodPocztowy = kodPocztowy.Trim();

            if (String.IsNullOrEmpty(ulica.Trim()))
                throw new ArgumentException("Podano nieprawidłową nazwę ulicy.");
            if (ulica.ToLower().StartsWith("ul.") || ulica.ToLower().StartsWith("al.")) ulica = ulica.Substring(3);
            Ulica = ulica.Trim();

            if (String.IsNullOrEmpty(numerBudynku.Trim()))
                throw new ArgumentException("Podano nieprawidłowy numer budynku.");
            NumerBudynku = numerBudynku.Trim();
        }
    }
}
