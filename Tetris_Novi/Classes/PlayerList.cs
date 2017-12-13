using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Tetris.Classes
{
    [Serializable]
    public class PlayerList
    {

        #region Fields

        List<Player> _list;

        #endregion

        #region Properties

        [XmlArrayItem("PlayerList",typeof(Player))]
        public List<Player> List { get => _list; set => _list = value; }

        #endregion

        #region Constructors

        public PlayerList()
        {
            _list = new List<Player>();
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
            List = p.List;
        }

        #endregion        

    }
}
