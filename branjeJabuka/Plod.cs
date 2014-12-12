using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace branjeVoca {
    class Plod {

        public Vocka Vocka;

        public int Tezina {
            get;
            protected set;
        }

        public Plod(Vocka _vocka, int _tezina) {
            this.Vocka = _vocka;
            this.Tezina = _tezina;
        }
    }
}
