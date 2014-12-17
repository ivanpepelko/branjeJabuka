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
        //private static FileStream Storage; // TODO

        static void Main(string[] args) {
            Console.Title = "Branje voćki v1.0";

            //Storage = File.Open("storage", FileMode.OpenOrCreate); // TODO
            Vocke = new List<Vocka>();
            Beraci = new List<BeracVoca>();

            Meni();

        }

        static private void Meni() {
            Console.Clear();
            MenuUtil.Copyright();
            MenuUtil.Naslov("Branje voćki - Glavni meni");
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
                    //SpremiPrijeIzlaza();  // TODO
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
                    //SpremiPrijeIzlaza(); // TODO
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
            Console.WriteLine("F2 - Dodaj berača");
            Console.WriteLine("F3 - Branje plodova");
            Console.WriteLine("F4 - Popis ubranih plodova po beraču");
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

                case ConsoleKey.F2:
                    string ime = "";
                    while (ime == "") {
                        Console.WriteLine("Unesite ime:");
                        ime = Console.ReadLine();
                        if (ime == "")
                            MenuUtil.PogresanUnosMessage();
                    };

                    Console.WriteLine("Unesite veličinu spremnika ili pritisnite\nEnter za standardni spremnik (5000 grama):");
                    string velicina = Console.ReadLine();
                    int vel;
                    bool is_velicina_int = int.TryParse(velicina, out vel);
                    if (is_velicina_int) {
                        Beraci.Add(new BeracVoca(ime, vel));
                    } else {
                        Beraci.Add(new BeracVoca(ime));
                    }
                    MenuUtil.Message("Berač " + ime + " sa spremnikom od " + (is_velicina_int ? vel : 5000) + " grama je dodan!", ConsoleColor.DarkGreen);

                    MeniBeraci();
                    break;

                case ConsoleKey.F3:
                    MenuUtil.Naslov("Odaberite berača:");

                    if (Beraci.Count == 0) {
                        MenuUtil.Message("Još nema berača!", ConsoleColor.Blue);
                        MenuUtil.Separator();
                    } else {
                        foreach (BeracVoca b in Beraci) {
                            Console.WriteLine("{0} - {1}", Beraci.IndexOf(b), b.Ime);
                        }
                        MenuUtil.Separator();

                        int index_beraca;

                        if (int.TryParse(Console.ReadLine(), out index_beraca)) {
                            BeracVoca berac = Beraci.ElementAt(index_beraca);
                            Console.Clear();
                            MenuUtil.Naslov("Odaberite voćku:");
                            if (Vocke.Count == 0) {
                                MenuUtil.Message("Još nijedna voćka nije posađena!", ConsoleColor.Blue);
                                MenuUtil.Separator();
                            } else {
                                foreach (Vocka v in Vocke) {
                                    Console.WriteLine("{0} - {1}", Vocke.IndexOf(v), v.VrstaVocke.ToString());
                                }
                                MenuUtil.Separator();

                                int index_vocke;

                                if (int.TryParse(Console.ReadLine(), out index_vocke)) {
                                    Vocka vocka = Vocke.ElementAt(index_vocke);
                                    Console.WriteLine("Ubrati najteži plod? (D/N)");
                                    string odg = Console.ReadLine().ToUpper();
                                    if (odg == "D") {
                                        berac.uberiNajteziPlod(vocka);
                                    } else if (odg == "N") {
                                        berac.uberiPlod(vocka);
                                    } else {
                                        MenuUtil.PogresanUnosMessage();
                                        MeniBeraci();
                                    }
                                } else {
                                    MenuUtil.PogresanUnosMessage();
                                    MeniBeraci();
                                }

                            }
                            MeniBeraci();
                        } else {
                            MenuUtil.PogresanUnosMessage();
                            MeniBeraci();
                        }
                    }

                    MeniBeraci();
                    break;

                case ConsoleKey.F4:
                    MenuUtil.Naslov("Odaberite berača:");

                    if (Beraci.Count == 0) {
                        MenuUtil.Message("Još nema berača!", ConsoleColor.Blue);
                        MenuUtil.Separator();
                    } else {
                        foreach (BeracVoca b in Beraci) {
                            Console.WriteLine("{0} - {1}", Beraci.IndexOf(b), b.Ime);
                        }
                        MenuUtil.Separator();

                        int index_beraca;

                        if (int.TryParse(Console.ReadLine(), out index_beraca)) {
                            Console.Clear();
                            BeracVoca berac = Beraci.ElementAt(index_beraca);
                            MenuUtil.Separator();
                            Console.WriteLine("U spremniku berača {0} se nalaze sljedeći plodovi:", berac.Ime);
                            foreach (Plod p in berac.SpremnikPlodova) {
                                Console.WriteLine("Plod: {0}; Tezina: {1}", p.Vocka.VrstaVocke.ToString(), p.Tezina);
                            }
                            MenuUtil.Separator();
                            Console.WriteLine("Ukupno: {0}/{1} grama", berac.TezinaUbranihPlodova, berac.VelicinaSpremnika);
                            MenuUtil.Separator();
                            MenuUtil.Message("Kraj popisa plodova.");
                            MeniBeraci();
                        } else {
                            MenuUtil.PogresanUnosMessage();
                            MeniBeraci();
                        }
                    }

                    MeniBeraci();
                    break;

                case ConsoleKey.Backspace:
                    Meni();
                    break;

                case ConsoleKey.Escape:
                    //SpremiPrijeIzlaza(); // TODO
                    Environment.Exit(0);
                    break;

                default:
                    MenuUtil.PogresanUnosMessage();
                    MeniBeraci();
                    break;
            }
        }

        // TODO
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

            //Storage.Write(bytes, 0, bytes.Length * sizeof(byte)); // TODO

        }

    }
}
