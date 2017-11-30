using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tetris_Novi.Klase
{
    [Serializable]
    public class ListaIgraca
    {
        List<Igrac> _listaIgraca;

        [XmlArrayItem("Igrac", typeof(Igrac))]
        public List<Igrac> Lista
        {
            get { return _listaIgraca; }
            set { _listaIgraca = value; }
        }

        public ListaIgraca()
        {
            _listaIgraca = new List<Igrac>();
        }

        public void AddIgrac(Igrac igrac)
        {
            _listaIgraca.Add(igrac);
        }
        
        public void Sort()
        {
            for(int i = 0; i < _listaIgraca.Count; i++)
            {
                for(int j = i+1; j < _listaIgraca.Count; j++)
                {
                    if(_listaIgraca[i].BrojPoena < _listaIgraca[j].BrojPoena)
                    {
                        var x = _listaIgraca[i];
                        _listaIgraca[i] = _listaIgraca[j];
                        _listaIgraca[j] = x;
                    }
                }
            }
        }
    }
}
