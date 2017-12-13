using System;
using System.Xml.Serialization;

namespace Tetris.Classes
{

    [Serializable]
    public class Player : IComparable
    {
        #region Fields

        string _name;
        int _score;
        private DateTime _time;

        #endregion

        #region Properties

        [XmlElement("PlayerName")]
        public string Name { get => _name; set => _name = value; }
        [XmlElement("Score")]
        public int Score { get => _score; set => _score = value; }
        [XmlElement("Date")]
        public DateTime Time { get => _time; set => _time = value; }

        #endregion

        #region Constructor

        public Player()
        {
            Name = "Default player";
            Score = 0;
            Time = DateTime.Now;
        }

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
            Time = DateTime.Now;
        }

        #endregion

        #region Overriden Methods

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != typeof(Player))
                return false;
            var p = obj as Player;
            return p.Score == Score && p.Name == Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Player " + Name + "; Score: " + Score + " Date: " + Time.ToShortDateString();
        }



        #endregion

        #region Compare

        public int CompareTo(object x)
        {
            if (x.GetType() != typeof(Player))
                return -1;
            if (x is Player p && _score >= p.Score)
                return -1;
            return 1;
        }

        #endregion        

    }
}
