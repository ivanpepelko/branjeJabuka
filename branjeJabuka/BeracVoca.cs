using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace branjeVoca {
    class BeracVoca {

        public string Ime {
            get;
            set;
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
                Plod plod = _vocka.nadiNajteziPlod();
                this.SpremnikPlodova.Add(plod);
                _vocka.Plodovi.Remove(plod);
            }
        }

        public void uberiNajteziPlod(Vocka _vocka, int _komada) {
            for (int i = 0; i < _komada; i++) {
                if (_vocka.Plodovi.Count != 0) {
                    Plod plod = _vocka.nadiNajteziPlod();
                    this.SpremnikPlodova.Add(plod);
                    _vocka.Plodovi.Remove(plod);
                }
            }

        }
        
    }
}
