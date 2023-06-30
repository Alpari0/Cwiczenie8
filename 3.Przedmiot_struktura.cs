using System;

enum Rzadkosc { Powszechny, Rzadki, Unikalny, Epicki }
enum TypPrzedmiotu { Bron, Zbroja, Amulet, Pierscien, Helm, Tarcza, Buty }

struct Przedmiot
{
    public int Waga;
    public int Wartosc;
    public Rzadkosc KlasaRzadkosci;
    public TypPrzedmiotu Typ;
    public string NazwaWlasna;

    public void WypiszInformacje()
    {
        Console.WriteLine("Nazwa: " + NazwaWlasna);
        Console.WriteLine("Typ: " + Typ);
        Console.WriteLine("Rzadkosc: " + KlasaRzadkosci);
        Console.WriteLine("Wartosc: " + Wartosc + " sztuk zlota");
        Console.WriteLine("Waga: " + Waga);
    }
}

class Program
{
    static Przedmiot WypelnijPrzedmiot(int waga, int wartosc, Rzadkosc rzadkosc, TypPrzedmiotu typ, string nazwa)
    {
        Przedmiot przedmiot;
        przedmiot.Waga = waga;
        przedmiot.Wartosc = wartosc;
        przedmiot.KlasaRzadkosci = rzadkosc;
        przedmiot.Typ = typ;
        przedmiot.NazwaWlasna = nazwa;
        return przedmiot;
    }

    static Przedmiot LosujPrzedmiot(Przedmiot[] przedmioty)
    {
        int[] szanse = { 50, 25, 15, 10 };
        int losowaLiczba = new Random().Next(1, 101);
        int sumaSzans = 0;
        Rzadkosc wylosowanaRzadkosc = Rzadkosc.Powszechny;

        for (int i = 0; i < szanse.Length; i++)
        {
            sumaSzans += szanse[i];
            if (losowaLiczba <= sumaSzans)
            {
                wylosowanaRzadkosc = (Rzadkosc)i;
                break;
            }
        }

        Przedmiot[] wylosowanePrzedmioty = Array.FindAll(przedmioty, p => p.KlasaRzadkosci == wylosowanaRzadkosc);
        return wylosowanePrzedmioty[new Random().Next(wylosowanePrzedmioty.Length)];
    }
    static void Main(string[] args)
    {
        Przedmiot miecz = WypelnijPrzedmiot(5, 100, Rzadkosc.Rzadki, TypPrzedmiotu.Bron, "Miecz Ognia");
        miecz.WypiszInformacje();

        Console.WriteLine();

        Przedmiot[] skrzynka = new Przedmiot[5];
        skrzynka[0] = WypelnijPrzedmiot(5, 100, Rzadkosc.Rzadki, TypPrzedmiotu.Bron, "Miecz Ognia");
        skrzynka[1] = WypelnijPrzedmiot(3, 50, Rzadkosc.Powszechny, TypPrzedmiotu.Amulet, "Amulet Zdrowia");
        skrzynka[2] = WypelnijPrzedmiot(8, 200, Rzadkosc.Unikalny, TypPrzedmiotu.Zbroja, "Zbroja Smoka");
        skrzynka[3] = WypelnijPrzedmiot(2, 150, Rzadkosc.Epicki, TypPrzedmiotu.Pierscien, "Pierscien Mocy");
        skrzynka[4] = WypelnijPrzedmiot(4, 75, Rzadkosc.Powszechny, TypPrzedmiotu.Tarcza, "Tarcza Ochronna");

        Przedmiot wylosowanyPrzedmiot = LosujPrzedmiot(skrzynka);
        Console.WriteLine("Wylosowales przedmiot:");
        wylosowanyPrzedmiot.WypiszInformacje();
    }
}