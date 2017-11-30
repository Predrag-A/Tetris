using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tetris_Novi.Klase
{
    [Serializable]
    public class Igrac
    {
        private string _imeIgraca;
        private int _brojPoena;

        [XmlElementAttribute("Ime")]
        public string ImeIgraca
        {
            get
            {
                return _imeIgraca;
            }

            set
            {
                _imeIgraca = value;
            }
        }

        [XmlElementAttribute("Broj Poena")]
        public int BrojPoena
        {
            get
            {
                return _brojPoena;
            }

            set
            {
                _brojPoena = value;
            }
        }

        public Igrac()
        {
            ImeIgraca = "";
            BrojPoena = 0;
        }
        public Igrac(string ime, int brojPoena)
        {
            ImeIgraca = ime;
            BrojPoena = brojPoena;
        }

        public override string ToString()
        {
            return ImeIgraca + "\t" + BrojPoena;
        }
    }
}
