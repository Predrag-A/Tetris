using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Novi.Classes
{
    [Serializable]
    public class PlayerList
    {

        #region Fields

        List<Player> list;

        #endregion

        #region Properties

        public List<Player> List { get { return list; } set { list = value; } }

        #endregion

        #region Constructors

        private PlayerList()
        {
            list = new List<Player>();
        }

        #endregion

        #region Methods

        public void Add(Player p)
        {
            List.Add(p);
            List.Sort();
        }

        public void Serialize(string fileName)
        {
            XMLSerialization.Serialization.Serialize(this, fileName);
        }

        public void Deserialize(string fileName)
        {
            XMLSerialization.Serialization.DeSerialize(this, fileName);
        }

        #endregion

        #region Singleton

        private static PlayerList _instance;

        public static PlayerList Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PlayerList();
                return _instance;
            }

            set
            {
                _instance = value;
            }
        }

        #endregion

    }
}
