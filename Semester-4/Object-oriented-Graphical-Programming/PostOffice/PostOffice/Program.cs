namespace PostOffice
{
    using System;
    class Program
    {
        static void Main()
        {
            Osoba MikolajBuczak = new Osoba("Mikolaj", "Buczak", "Klobuck", "42-100", "ul. Prosta", "13a", "+48987654321", "37", "mikobuc558@student.polsl.pl");
            Osoba KamilKaloch = new Osoba("Kamil", "Kaloch", "Katowice", "40-000", "Nieznana", "1", "+48123456789", "1", "kamilkaloch@gmail.com");

            Paczkomat paczkomatKatowice = new Paczkomat("Katowice", "40-000", "Pocztowa", "1");
            Paczkomat paczkomatKlobuck = new Paczkomat("Klobuck", "42-100", "Przesylkowa", "24");

            PrzesylkaKurierska paczkaKurierska = new PrzesylkaKurierska(MikolajBuczak, KamilKaloch, 2000, new Rozmiar(200, 100, 300), DateTime.Now);
            PrzesylkaPaczkomatowa paczkaPaczkomatowa = new PrzesylkaPaczkomatowa(MikolajBuczak, KamilKaloch, 2000, new Rozmiar(500, 1000, 300), DateTime.Now, paczkomatKatowice);

            Console.WriteLine(paczkaKurierska.GenerujListPrzewozowy());
            Console.WriteLine(paczkaPaczkomatowa.GenerujListPrzewozowy());
            Console.ReadKey();
        }
    }
}
