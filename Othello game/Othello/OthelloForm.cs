using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Othello
{
    public partial class OthelloForm : Form
    {
        private int m_boardSize;
        private GameAndLogic m_newGame;
        public Button[,] m_buttons;
        private const int m_cellSize = 35;
        private int m_turn;
        private int m_numberOfPlayers;
       
        public OthelloForm(int i_BoardSize, int i_NumOfPlayers)
        {
            InitializeComponent();
            this.m_boardSize = i_BoardSize;          
            this.m_newGame = new GameAndLogic();
            this.m_numberOfPlayers = i_NumOfPlayers;
            this.m_newGame.setGame(i_NumOfPlayers, m_boardSize);
            this.m_turn = 1;
            this.m_newGame.m_board.UpdateValidBoard(m_turn);
            m_newGame.SetGameFormReference(this);
            m_newGame.InitializeButtons();
        }

        private void OthelloForm_Load(object sender, EventArgs e)
        {
            
        }

        public void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
        int row = btn.Top / m_cellSize;
        int col = btn.Left / m_cellSize;
            this.m_newGame.MakeMove(col+1, row+1, ref m_turn);
            if (this.m_numberOfPlayers == 2) 
            {
                m_newGame.PrintFormText(m_turn);
            }
        m_newGame.ClearButtons();         
        }

    }
}
