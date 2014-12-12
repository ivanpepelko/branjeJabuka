using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace branjeVoca {
    class BeracVoca {

        public string Ime {
            get;
            protected set;
        }

        public int VelicinaSpremnika {
            get;
            protected set;
        }

        public List<Plod> SpremnikPlodova;

        public int TezinaUbranihPlodova {
            get {
                int tezina = 0;
                foreach (Plod plod in this.SpremnikPlodova) {
                    tezina += plod.Tezina;
                }
                return tezina;
            }
        }

        public BeracVoca(string _ime) {
            this.Ime = _ime;
            this.SpremnikPlodova = new List<Plod>();
            this.VelicinaSpremnika = 5000;
        }

        public BeracVoca(string _ime, int _velicina_spremnika) {
            this.Ime = _ime;
            this.SpremnikPlodova = new List<Plod>();
            this.VelicinaSpremnika = _velicina_spremnika;
        }

        public void uberiPlod(Vocka _vocka) {
            if (_vocka.Plodovi.Count != 0) {
                Plod plod = _vocka.Plodovi.First<Plod>();
                this.SpremnikPlodova.Add(plod);
                _vocka.Plodovi.Remove(plod);
            }
        }

        public void uberiPlod(Vocka _vocka, int _komada) {
            for (int i = 0; i < _komada; i++) {
                if (_vocka.Plodovi.Count != 0) {
                    Plod plod = _vocka.Plodovi.First<Plod>();
                    this.SpremnikPlodova.Add(plod);
                    _vocka.Plodovi.Remove(plod);
                }
            }
        }

        public void uberiNajteziPlod(Vocka _vocka) {
            if (_vocka.Plodovi.Count != 0) {
                Plod plod = this.nadiNajteziPlod(_vocka);
                this.SpremnikPlodova.Add(plod);
                _vocka.Plodovi.Remove(plod);
            }
        }

        public void uberiNajteziPlod(Vocka _vocka, int _komada) {
            for (int i = 0; i < _komada; i++) {
                if (_vocka.Plodovi.Count != 0) {
                    Plod plod = this.nadiNajteziPlod(_vocka);
                    this.SpremnikPlodova.Add(plod);
                    _vocka.Plodovi.Remove(plod);
                }
            }

        }

        public Plod nadiNajteziPlod(Vocka _vocka) {
            Plod plod = _vocka.Plodovi.First();
            foreach (Plod p in _vocka.Plodovi) {
                if (p.Tezina > plod.Tezina) {
                    plod = p;
                } else {
                    continue;
                }
            }

            return plod;
        }
    }
}
