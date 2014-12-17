using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace branjeVoca {
    class BeracVoca {

        public string Ime {
            get;
            private set;
        }

        public int VelicinaSpremnika {
            get;
            private set;
        }

        public List<Plod> SpremnikPlodova;

        public int TezinaUbranihPlodova {
            get {
                int tezina = (from plod in this.SpremnikPlodova
                              select plod.Tezina).Sum();
                return tezina;
            }
        }

        private bool mozeUbrati(Plod _plod) {
            bool moze = true;
            if (this.VelicinaSpremnika < this.TezinaUbranihPlodova + _plod.Tezina)
                moze = false;
            return moze;
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
                Plod plod = _vocka.Plodovi.First();
                if (this.mozeUbrati(plod)) {
                    this.SpremnikPlodova.Add(plod);
                    _vocka.Plodovi.Remove(plod);
                } else {
                    MenuUtil.SpremnikJePunMessage(this);
                }
            } else {
                MenuUtil.NemaVisePlodovaMessage(_vocka);
            }
        }

        public void uberiPlod(Vocka _vocka, int _komada) {
            for (int i = 0; i < _komada; i++) {
                if (_vocka.Plodovi.Count != 0) {
                    Plod plod = _vocka.Plodovi.First();
                    if (this.mozeUbrati(plod)) {
                        this.SpremnikPlodova.Add(plod);
                        _vocka.Plodovi.Remove(plod);
                    } else {
                        MenuUtil.SpremnikJePunMessage(this);
                    }
                } else {
                    MenuUtil.NemaVisePlodovaMessage(_vocka);
                    break;
                }
            }
        }

        public void uberiNajteziPlod(Vocka _vocka) {
            if (_vocka.Plodovi.Count != 0) {
                Plod plod = this.nadiNajteziPlod(_vocka);
                if (this.mozeUbrati(plod)) {
                    this.SpremnikPlodova.Add(plod);
                    _vocka.Plodovi.Remove(plod);
                } else {
                    MenuUtil.SpremnikJePunMessage(this);
                }
            } else {
                MenuUtil.NemaVisePlodovaMessage(_vocka);
            }
        }

        public void uberiNajteziPlod(Vocka _vocka, int _komada) {
            for (int i = 0; i < _komada; i++) {
                if (_vocka.Plodovi.Count != 0) {
                    Plod plod = this.nadiNajteziPlod(_vocka);
                    if (this.mozeUbrati(plod)) {
                        this.SpremnikPlodova.Add(plod);
                        _vocka.Plodovi.Remove(plod);
                    } else {
                        MenuUtil.SpremnikJePunMessage(this);
                    }
                } else {
                    MenuUtil.NemaVisePlodovaMessage(_vocka);
                    break;
                }
            }

        }

        public Plod nadiNajteziPlod(Vocka _vocka) {
            int t_max = (from pl in _vocka.Plodovi
                         select pl.Tezina).Max();
            Plod plod = (from pl in _vocka.Plodovi
                         where pl.Tezina == t_max
                         select pl).Single();

            return plod;
        }
    }
}
