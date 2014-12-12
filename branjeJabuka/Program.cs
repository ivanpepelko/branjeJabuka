using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace branjeVoca {
    class Program {

        private static List<Vocka> Vocke;
        private static List<BeracVoca> Beraci;
        //private static FileStream Storage;

        static void Main(string[] args) {
            //Storage = File.Open("storage", FileMode.OpenOrCreate);
            Vocke = new List<Vocka>();
            Beraci = new List<BeracVoca>();
            
            Meni();

        }

        static private void Meni() {
            Console.Clear();
            MenuUtil.Copyright();
            MenuUtil.Naslov("Branje vocaka - Glavni meni");
            Console.WriteLine("F1 - Voćke");
            Console.WriteLine("F2 - Berači");
            Console.WriteLine("ESC - Izlaz");
            MenuUtil.Separator();
            
            switch (Console.ReadKey(true).Key) {
                case ConsoleKey.F1:
                    MeniVocke();
                    break;
                case ConsoleKey.F2:
                    MeniBeraci();
                    break;
                case ConsoleKey.Escape:
                    //SpremiPrijeIzlaza();
                    Environment.Exit(0);
                    break;
                default:
                    MenuUtil.PogresanUnosMessage();
                    Meni();
                    break;
            }

        }

        static private void MeniVocke() {
            Console.Clear();
            MenuUtil.Copyright();
            MenuUtil.Naslov("Voćke");
            Console.WriteLine("F1 - Pregled voćki u voćnjaku");
            Console.WriteLine("F2 - Posadi voćku");
            Console.WriteLine("Backspace - Povratak u glavni meni");
            Console.WriteLine("ESC - Izlaz");
            MenuUtil.Separator();

            switch (Console.ReadKey(true).Key) {
                case ConsoleKey.F1:
                    MenuUtil.Naslov("Popis voćki");
                    if (Vocke.Count == 0) {
                        MenuUtil.Message("Još nijedna voćka nije posađena!", ConsoleColor.Blue);
                        MenuUtil.Separator();
                    } else {
                        foreach (Vocka vocka in Vocke) {
                            Console.WriteLine("{0} - {1}", Vocke.IndexOf(vocka), vocka.VrstaVocke.ToString());
                        }
                        MenuUtil.Separator();
                        MenuUtil.Message("Kraj ispisa voćki.");
                    }
                    MeniVocke();
                    break;
                case ConsoleKey.F2:
                    MenuUtil.Separator();
                    Console.WriteLine("Vrste:");
                    List<VrstaVocke> vrste = Enum.GetValues(typeof(VrstaVocke)).Cast<VrstaVocke>().ToList<VrstaVocke>();
                    foreach (VrstaVocke vrsta in vrste) {
                        Console.WriteLine("{0} - {1}", vrste.IndexOf(vrsta), vrsta.ToString());
                    }
                    MenuUtil.Separator();
                    Console.WriteLine("Odaberite vrstu:");
                    string input = Console.ReadLine();
                    int vr;
                    if (int.TryParse(input, out vr)) {
                        if (vr < 0 || vr > vrste.Count) {
                            MenuUtil.PogresanUnosMessage();
                        } else {
                            Vocka nova_vocka = new Vocka(vrste.ElementAt<VrstaVocke>(vr));
                            Vocke.Add(nova_vocka);
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("{0} je uspješno posađena! Pritisnite bilo koju tipku za nastavak...", nova_vocka.VrstaVocke.ToString());
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ReadKey();
                        }
                    } else {
                        MenuUtil.PogresanUnosMessage();
                    }
                    MeniVocke();
                    break;
                case ConsoleKey.Backspace:
                    Meni();
                    break;
                case ConsoleKey.Escape:
                    //SpremiPrijeIzlaza();
                    Environment.Exit(0);
                    break;
                default:
                    MenuUtil.PogresanUnosMessage();
                    MeniVocke();
                    break;
            }
        }

        static private void MeniBeraci() {
            Console.Clear();
            MenuUtil.Copyright();
            MenuUtil.Naslov("Berači");
            Console.WriteLine("F1 - Popis berača");
            Console.WriteLine("Backspace - Povratak u glavni meni");
            Console.WriteLine("ESC - Izlaz");
            MenuUtil.Separator();

            switch (Console.ReadKey(true).Key) {
                case ConsoleKey.F1:
                    MenuUtil.Naslov("Popis berača");
                    if (Beraci.Count == 0) {
                        MenuUtil.Message("Još nema berača!", ConsoleColor.Blue);
                        MenuUtil.Separator();
                    } else {
                        foreach (BeracVoca berac in Beraci) {
                            Console.WriteLine("{0} - {1}, spremnik: {2} grama", Beraci.IndexOf(berac), berac.Ime, berac.VelicinaSpremnika);
                        }
                        MenuUtil.Separator();
                        MenuUtil.Message("Kraj popisa beraca.");
                    }
                    MeniBeraci();
                    break;
                case ConsoleKey.Backspace:
                    Meni();
                    break;
                case ConsoleKey.Escape:
                    //SpremiPrijeIzlaza();
                    Environment.Exit(0);
                    break;
                default:
                    MenuUtil.PogresanUnosMessage();
                    MeniBeraci();
                    break;
            }
        }

        static private void SpremiPrijeIzlaza() {
            string towrite = "";
            foreach (Vocka voc in Vocke) {
                towrite += voc.VrstaVocke.ToString();
                towrite += "\n";
                foreach (Plod plod in voc.Plodovi) {
                    towrite += plod.Tezina;
                    towrite += "\t";
                }
                towrite += "\n\n";
            }

            byte[] bytes = new byte[towrite.Length * sizeof(char)];
            System.Buffer.BlockCopy(towrite.ToCharArray(), 0, bytes, 0, bytes.Length * sizeof(byte));

            //Storage.Write(bytes, 0, bytes.Length * sizeof(byte));
        }

    }
}
