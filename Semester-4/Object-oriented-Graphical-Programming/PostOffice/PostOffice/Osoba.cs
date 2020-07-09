namespace PostOffice
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class Osoba
    {
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }
        public string Miasto { get; private set; }
        public string KodPocztowy { get; private set; }
        public string Ulica { get; private set; }
        public string NumerBudynku { get; private set; }
        public string NumerMieszkania { get; private set; }
        public string NumerTelefonu { get; private set; }
        public string AdresEmail { get; private set; }

        public Osoba(string imie, string nazwisko, string miasto, string kodPocztowy, string ulica, string numerBudynku, string numerTelefonu, string numerMieszkania = null, string adresEmail = null)
        {
            if (String.IsNullOrEmpty(imie.Trim()))
                throw new ArgumentException("Podano nieprawidłowe imię.");
            Imie = imie.Trim();

            if (String.IsNullOrEmpty(nazwisko.Trim()))
                throw new ArgumentException("Podano nieprawidłowe nazwisko.");
            Nazwisko = nazwisko.Trim();

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

            if(numerMieszkania != null && String.IsNullOrEmpty(numerMieszkania.Trim()))
                throw new ArgumentException("Podano nieprawidłowy numer mieszkania.");
            NumerMieszkania = numerMieszkania.Trim();

            if (String.IsNullOrEmpty(numerTelefonu.Trim()))
                throw new ArgumentException("Podano nieprawidłowy numer telefonu.");
            NumerTelefonu = numerTelefonu.Trim();

            if (!Regex.IsMatch(adresEmail.Trim(), "[A-Za-z0-9]+@[a-z]+.[a-z]+"))
                throw new ArgumentException("Podano nieprawidłowy adres e-mail.");
            AdresEmail = adresEmail.Trim();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{Imie} {Nazwisko}\nAdres:\nul. {Ulica} {NumerBudynku}");
            if (NumerMieszkania != null) stringBuilder.Append($"/{NumerMieszkania}");
            stringBuilder.Append($"\nDane kontaktowe:\nNumer telefonu: {NumerTelefonu}\n");
            if (AdresEmail != null) stringBuilder.Append($"Adres e-mail: {AdresEmail}\n");
            return stringBuilder.ToString();
        }
    }
}
