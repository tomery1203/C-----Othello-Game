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
    public partial class GameSettings : Form
    {
        private int m_boardSize = 6;
        private const int MIN_BOARD_SIZE = 6;
        private const int MAX_BOARD_SIZE = 12;
        public GameSettings()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btn_PlayVSComputer_Click(object sender, EventArgs e)
        {
            OthelloForm newWindow = new OthelloForm(m_boardSize,1);
            newWindow.FormClosed += (s, args) => this.Close();
            this.Hide();
            newWindow.Show();
        }

        private void btn_PlayVSPlayer_Click(object sender, EventArgs e)
        {
            OthelloForm newWindow = new OthelloForm(m_boardSize,2);
            newWindow.FormClosed += (s, args) => this.Close();
            this.Hide();
            newWindow.Show();
        }

        private void btn_BoardSize_Click(object sender, EventArgs e)
        {
            this.m_boardSize += 2;

            if (this.m_boardSize > MAX_BOARD_SIZE)
            {
                this.m_boardSize = MIN_BOARD_SIZE;
            }

            btn_BoardSize.Text = "Board size : " + this.m_boardSize + "x" + this.m_boardSize + " (click to increase)";
        }
    }
}
