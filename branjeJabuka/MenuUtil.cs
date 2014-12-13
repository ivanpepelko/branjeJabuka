using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace branjeVoca {
    static class MenuUtil {

        static public void Copyright() {
            int left = Console.WindowLeft;
            int top = Console.WindowTop;

            Console.SetCursorPosition(left, Console.WindowHeight - 2);
            Separator();
            Console.WriteLine("Branje vocaka v0.1 Alpha, Copyright © Ivan Pepelko 2014");
            Console.SetCursorPosition(left, top);
        }

        static public void Message(string _msg) {
            Console.WriteLine(_msg + " Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }

        static public void Message(string _msg, ConsoleColor _color) {
            Console.BackgroundColor = _color;
            Console.WriteLine(_msg + " Pritisnite bilo koju tipku za nastavak...");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadKey();
        }

        static public void PogresanUnosMessage() {
            Message("Pogrešan unos!", ConsoleColor.Red);
        }

        static public void Separator() {
            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        static public void Naslov(string _naslov) {
            Separator();
            Console.WriteLine(_naslov);
            Separator();
        }

        static public void NemaVisePlodovaMessage(Vocka _vocka) {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} nema vise plodova! Pritisnite bilo koju tipku za nastavak...", _vocka.VrstaVocke.ToString());
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadKey();
        }
    }
}
