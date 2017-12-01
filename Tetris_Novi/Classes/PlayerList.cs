using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Tetris.Classes
{
    [Serializable]
    public class PlayerList
    {

        #region Attributes

        List<Player> list;

        #endregion

        #region Properties

        [XmlArrayItem("PlayerList",typeof(Player))]
        public List<Player> List { get { return list; } set { list = value; } }

        #endregion

        #region Constructors

        public PlayerList()
        {
            list = new List<Player>();
        }

        #endregion

        #region Methods

        //Adds a player to the list
        public void Add(Player p)
        {
            List.Add(p);
            List.Sort();
        }

        //Used for XML serialization
        public void Serialize(string fileName)
        {
            var xmlserializer = new XmlSerializer(typeof(PlayerList));

            using (var fileWriter = new FileStream(fileName, FileMode.Create))
            {
                xmlserializer.Serialize(fileWriter, this);
            }
        }

        //Used for XML deserialization
        public void Deserialize(string fileName)
        {
            PlayerList p;
            var serializer = new XmlSerializer(typeof(PlayerList));
            using (var reader = XmlReader.Create(fileName))
            {
                p = (PlayerList)serializer.Deserialize(reader);
            }
            this.List = p.List;
        }

        #endregion        

    }
}
