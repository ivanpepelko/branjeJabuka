using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace branjeVoca {

    enum VrstaVocke {
        Jabuka,
        Naranca,
        Sljiva,
        Kruska,
        Banana
    }

    class Vocka {

        public List<Plod> Plodovi;

        public VrstaVocke VrstaVocke {
            get;
            set;
        }

        public Vocka(VrstaVocke _vrsta_vocke) {
            this.VrstaVocke = _vrsta_vocke;
            this.Plodovi = new List<Plod>();
            Random rnd = new Random();
            int broj_plodova = rnd.Next(10, 50);
            for (int i = 0; i < broj_plodova; i++) {
                this.Plodovi.Add(new Plod(this, rnd.Next(150, 500)));
            }
        }


    }
}
