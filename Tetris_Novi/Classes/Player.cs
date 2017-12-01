using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tetris.Classes
{

    [Serializable]
    public class Player : IComparable
    {
        #region Attributes

        string name;
        int score;
        private DateTime time;

        #endregion

        #region Properties

        [XmlElementAttribute("PlayerName")]
        public string Name { get { return name; } set { name = value; } }
        [XmlElementAttribute("Score")]
        public int Score { get { return score; } set { score = value; } }
        [XmlElementAttribute("Date")]
        public DateTime Time { get { return time; } set { time = value; } }

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
            Player p = obj as Player;
            if (p.Score == Score && p.Name == Name)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Player " + Name + "; Score: " + Score.ToString() + " Date: " + Time.ToShortDateString();
        }



        #endregion

        #region Compare

        public int CompareTo(object x)
        {
            if (x.GetType() != typeof(Player))
                return -1;
            Player p = x as Player;
            if (this.score >= p.Score)
                return -1;
            return 1;
        }

        #endregion        

    }
}
