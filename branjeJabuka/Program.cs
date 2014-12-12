using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace branjeVoca {
    class Program {

        internal static List<Vocka> Vocke;
        internal static List<BeracVoca> Beraci;

        static void Main(string[] args) {
            Vocke = new List<Vocka>();
            Beraci = new List<BeracVoca>();

            Meni();

            Console.ReadKey();

        }

        static internal void Meni() {
            Console.Clear();
            Copyright();
            Naslov("Branje vocaka - Glavni meni");
            Console.WriteLine("1 - Voćke");
            Console.WriteLine("2 - Berači");
            Console.WriteLine("9 - Izlaz");
            Separator();
            Console.WriteLine("Odaberite opciju:");

            string opt = Console.ReadLine();

            switch (opt) {
                case "1":
                    MeniVocke();
                    break;
                case "2":
                    MeniBeraci();
                    break;
                case "9":
                    Environment.Exit(0);
                    break;
                default:
                    PogresanUnosMessage();
                    Meni();
                    break;
            }

        }

        static internal void MeniVocke() {
            Console.Clear();
            Copyright();
            Naslov("Voćke");
            Console.WriteLine("1 - Pregled voćki u voćnjaku");
            Console.WriteLine("2 - Posadi voćku");
            Console.WriteLine("9 - Povratak u glavni meni");
            Separator();

            Console.WriteLine("Odaberite opciju:");

            string opt = Console.ReadLine();

            switch (opt) {
                case "1":
                    Naslov("Popis voćki");
                    if (Vocke.Count == 0) {
                        Message("Još nijedna voćka nije posađena!", ConsoleColor.Blue);
                        Separator();
                    } else {
                        foreach (Vocka vocka in Vocke) {
                            Console.WriteLine("{0} - {1}", Vocke.IndexOf(vocka), vocka.VrstaVocke.ToString());
                        }
                        Separator();
                        Message("Kraj ispisa voćki.");
                    }
                    MeniVocke();
                    break;
                case "2":
                    Separator();
                    Console.WriteLine("Vrste:");
                    List<VrstaVocke> vrste = Enum.GetValues(typeof(VrstaVocke)).Cast<VrstaVocke>().ToList<VrstaVocke>();
                    foreach (VrstaVocke vrsta in vrste) {
                        Console.WriteLine("{0} - {1}", vrste.IndexOf(vrsta), vrsta.ToString());
                    }
                    Separator();
                    Console.WriteLine("Odaberite vrstu:");
                    string input = Console.ReadLine();
                    int vr;
                    if (int.TryParse(input, out vr)) {
                        if (vr < 0 || vr > vrste.Count) {
                            PogresanUnosMessage();
                        } else {
                            Vocka nova_vocka = new Vocka(vrste.ElementAt<VrstaVocke>(vr));
                            Vocke.Add(nova_vocka);
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("{0} je uspješno posađena! Pritisnite bilo koju tipku za nastavak...", nova_vocka.VrstaVocke.ToString());
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ReadKey();
                        }
                    } else {
                        PogresanUnosMessage();
                    }
                    MeniVocke();
                    break;
                case "9":
                    Meni();
                    break;
                default:
                    PogresanUnosMessage();
                    MeniVocke();
                    break;
            }
        }

        static internal void MeniBeraci() {
            Console.Clear();
            Copyright();
            Naslov("Berači");
            Console.WriteLine("1 - Popis berača");
            Console.WriteLine("9 - Povratak u glavni meni");
            Separator();
            Console.WriteLine("Odaberite opciju:");

            string opt = Console.ReadLine();

            switch (opt) {
                case "1":
                    Message("Not yet!", ConsoleColor.Red);
                    MeniBeraci();
                    break;
                case "9":
                    Meni();
                    break;
                default:
                    PogresanUnosMessage();
                    MeniBeraci();
                    break;
            }
        }

        static internal void Copyright() {
            int left = Console.WindowLeft;
            int top = Console.WindowTop;

            Console.SetCursorPosition(left, Console.WindowHeight - 2);
            Separator();
            Console.WriteLine("Branje vocaka v0.1 Alpha, Copyright © Ivan Pepelko 2014");
            Console.SetCursorPosition(left, top);
        }

        static internal void Message(string _msg) {
            Console.WriteLine(_msg + " Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }

        static internal void Message(string _msg, ConsoleColor _color) {
            Console.BackgroundColor = _color;
            Console.WriteLine(_msg + " Pritisnite bilo koju tipku za nastavak...");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadKey();
        }

        static internal void PogresanUnosMessage() {
            Message("Pogrešan unos!", ConsoleColor.Red);
        }

        static internal void Separator() {
            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        static internal void Naslov(string _naslov) {
            Separator();
            Console.WriteLine(_naslov);
            Separator();
        }
    }
}
