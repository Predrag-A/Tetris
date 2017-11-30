using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tetris_Novi.Classes
{
    [Serializable]
    public class PlayerList
    {

        #region Attributes

        List<Player> list;

        #endregion

        #region Properties

        [XmlArrayItem("List",typeof(Player))]
        public List<Player> List { get { return list; } set { list = value; } }

        #endregion

        #region Constructors

        public PlayerList()
        {
            list = new List<Player>();
        }

        #endregion

        #region Methods

        public void Add(Player p)
        {
            List.Add(p);
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

    }
}
