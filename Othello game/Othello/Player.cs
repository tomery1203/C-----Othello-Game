using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Othello
{
   
    public class Player
    {
        public String m_Name;
        public int m_VictoryPoints;
        private bool m_hasMoves = true;
        public int m_victory = 0;

        public Player()
        {
            this.m_Name = "bot";
            this.m_VictoryPoints = 2;

        }

        public bool hasMoves
        {
            get { return m_hasMoves; }
            set { m_hasMoves = value; }
        }

        public String Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public int VictoryPoints
        {
            get { return m_VictoryPoints; }
            set { m_VictoryPoints = value; }
        }

    }
}
