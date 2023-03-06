using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Othello
{
    public class GameAndLogic
    {
        public Board m_board;
        private Player m_playerOne;
        private Player m_playerTwo;
        private OthelloForm m_gameForm;

        public GameAndLogic()
        {
            this.m_board = null;
            this.m_playerOne = setPlayer("Black");
            this.m_playerTwo = null;
        }

        public void SetGameFormReference(OthelloForm i_form)
        {
            m_gameForm = i_form;
        }

        public void setGame(int i_numOfPlayers, int io_BoardSize)
        {
            switch (i_numOfPlayers)
            {
                case (1):
                    m_playerTwo = setPlayer("bot");
                    break;
                case (2):
                    m_playerTwo = setPlayer();
                    break;
            }
            m_board = buildBoard(io_BoardSize);
        }

        private Board buildBoard(int i_BoardSize)
        {
            Board board;
            board = new Board();
            board.m_size = i_BoardSize;
            board.SetBoard(i_BoardSize + 2);
            return board;
        }

        private Player setPlayer(string i_name = "white")
        {
            String name = i_name;
            Player playerOne;
            playerOne = new Player();
            playerOne.Name = name;
            return playerOne;
        }

        private bool hasAnyMove(int io_Turn, Player io_Player)
        {
            int points = 0;
            bool o_flag = false;

            for (int i = 1; i < m_board.Size; i++)
            {
                for (int j = 1; j < m_board.Size; j++)
                {
                    if ((m_board.m_board[i, j] == 0))
                    {
                        o_flag = true;
                    }
                }
            }
            io_Player.VictoryPoints = points;
            io_Player.hasMoves = o_flag;

            return o_flag;
        }

        private void countPoints(Player io_PlayerOne, Player io_PlayerTwo)
        {
            int countOne = 0;
            int countTwo = 0;

            for (int i = 1; i <= m_board.Size; i++)
            {
                for (int j = 1; j <= m_board.Size; j++)
                {
                    if ((m_board.m_board[i, j] == 1))
                    {
                        countOne += 1;
                    }
                    if ((m_board.m_board[i, j] == 2))
                    {
                        countTwo += 1;
                    }
                }
            }
            io_PlayerOne.VictoryPoints = countOne;
            io_PlayerTwo.VictoryPoints = countTwo;
        }

        private bool getMoves(int io_Turn, int i_XPosition, int i_YPosition)
        {
            bool o_flag = false;
            if (m_board.ValidateMove(i_XPosition, i_YPosition, io_Turn))
            {
                o_flag = true;
            }
            return o_flag;
        }

        private void playerPlay(ref int io_Turn, Player io_Player, int i_row, int i_col)
        {

            if (getMoves(io_Turn, i_row, i_col))
            {
                m_board.UpdateBoard(i_row, i_col, io_Turn);
            }
        }

        private void botPlay(ref int io_Turn, Player io_Player)
        {
            int horizantonalMove;
            int verticalMove;
            bool flag;
            Random rnd = new Random();
            int maxTries = 0;

            while (true)
            {
                horizantonalMove = rnd.Next(1, m_board.m_size + 1);
                verticalMove = rnd.Next(1, m_board.m_size + 1);
                if (hasAnyMove(io_Turn, io_Player))
                {

                    flag = m_board.ValidateMove(horizantonalMove, verticalMove, io_Turn);
                    if (maxTries == 100) flag = false;
                    if (flag)
                    {
                        m_board.UpdateBoard(horizantonalMove, verticalMove, io_Turn);
                        io_Turn = 1;
                        return;
                    }
                    else
                    {
                        maxTries++;
                        continue;
                    }
                }
                else
                {
                    io_Player.hasMoves = false;
                    io_Turn = 1;
                    return;
                }
            }
        }

        private void isGameOver(int io_turn)
        {
            if (!(m_playerOne.hasMoves && m_playerTwo.hasMoves))
            {
                gameOver(m_playerOne, m_playerTwo, io_turn);
            }
        }

        private void gameOver(Player io_PlayerOne, Player io_PlayerTwo, int io_turn)
        {
            countPoints(io_PlayerOne, io_PlayerTwo);
            if (io_PlayerOne.VictoryPoints > io_PlayerTwo.VictoryPoints)
            {
                io_PlayerOne.m_victory++;
                int totalGames = io_PlayerOne.m_victory + io_PlayerTwo.m_victory;
                string message = string.Format("Black won!! ({0} / {1}) ({2} / {3})\nWould you like another round??", io_PlayerOne.VictoryPoints, io_PlayerTwo.VictoryPoints, io_PlayerOne.m_victory, totalGames);
                DialogResult result = MessageBox.Show(message, "Othello", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    io_PlayerTwo.hasMoves = io_PlayerOne.hasMoves = true;
                    int size = m_board.m_size;
                    m_board = null;
                    m_board = buildBoard(size);
                    InitializeButtons();
                }
                else if (result == DialogResult.No)
                {
                    io_PlayerOne.m_victory = io_PlayerTwo.m_victory = 0;
                    Environment.Exit(0);
                }
            }
            else
            {
                io_PlayerTwo.m_victory++;
                int totalGames = io_PlayerOne.m_victory + io_PlayerTwo.m_victory;
                string message = string.Format("White won!! ({0} / {1}) ({2} / {3})\nWould you like another round?", io_PlayerTwo.VictoryPoints, io_PlayerOne.VictoryPoints, io_PlayerTwo.m_victory, totalGames);
                DialogResult result = MessageBox.Show(message, "Othello", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    io_PlayerTwo.hasMoves = io_PlayerOne.hasMoves = true;
                    int size = m_board.m_size;
                    m_board = null;
                    m_board = buildBoard(size);
                    InitializeButtons();
                }
                else if (result == DialogResult.No)
                {
                    io_PlayerOne.m_victory = io_PlayerTwo.m_victory = 0;
                    Environment.Exit(0);
                }
            }
        }

        public bool IsthereAnyMoves()
        {
            bool o_flag = false;
            for (int i = 1; i <= m_board.Size; i++)
            {
                for (int j = 1; j <= m_board.Size; j++)
                {
                    if (m_board.m_board[i, j] == 0)
                    {
                        o_flag = true;
                    }
                }
            }
            return o_flag;
        }
       
        public bool IsthereAnyValidMoves()
        {
            bool o_flag = false;
            for (int i = 1; i <= m_board.Size; i++)
            {
                for (int j = 1; j <= m_board.Size; j++)
                {
                    if (m_board.m_board[i, j] == 3)
                    {
                        o_flag = true;
                    }
                }
            }
            return o_flag;
        }
       
        public void InitializeButtons()
        {
             int cellSize = 35;
            m_gameForm.m_buttons = new Button[m_board.m_size, m_board.m_size];
            int formWidth = m_board.m_size * cellSize + 7;
            int formHeight = m_board.m_size * cellSize + 7;
            m_gameForm.ClientSize = new Size(formWidth, formHeight);

            for (int i = 0; i < m_board.m_size; i++)
            {
                for (int j = 0; j < m_board.m_size; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(cellSize, cellSize);
                    btn.Location = new Point(i * cellSize, j * cellSize);
                    btn.Click += new EventHandler(m_gameForm.Button_Click);
                    int val = m_board.m_board[i + 1, j + 1];
                    if (val == 0)
                    {
                        btn.Enabled = false;
                    }
                    else if (val == 1)
                    {
                        btn.Enabled = false;
                        btn.BackColor = Color.Black;
                        btn.ForeColor = Color.White;
                        btn.Text = "O";
                    }
                    else if (val == 2)
                    {
                        btn.Enabled = false;
                        btn.BackColor = Color.White;
                        btn.ForeColor = Color.Black;
                        btn.Text = "O";
                    }
                    else if (val == 3)
                    {
                        btn.Enabled = true;
                        btn.BackColor = Color.Green;
                    }

                    m_gameForm.m_buttons[i, j] = btn;
                    m_gameForm.Controls.Add(btn);
                }
            }
        }

        public void PrintFormText(int i_turn)
        {
            if (i_turn == 1)
            {
                m_gameForm.Text = "Othello - Black's Turn";
            }
            else
            {
                m_gameForm.Text = "Othello - White's Turn";
            }
        }
        
        public void ClearButtons()
        {
            m_gameForm.Controls.Clear();
            InitializeButtons();
        }

        public void MakeMove(int i_row, int i_col, ref int i_turn)
        {
            bool isAnyMoves = !IsthereAnyMoves();
            bool isAnyValidMoves = !IsthereAnyValidMoves();
            bool PlayerOneHasMoves = hasAnyMove(i_turn, m_playerOne);
            bool PlayerTwoHasMoves = hasAnyMove(i_turn, m_playerTwo);
            if (isAnyMoves || isAnyValidMoves)
            {
                gameOver(m_playerOne, m_playerTwo, i_turn);
                return;
            }
            isGameOver(i_turn);
            
            if (m_playerTwo.m_Name == "bot")
            {
                if (PlayerOneHasMoves || PlayerTwoHasMoves)
                {
                    playerPlay(ref i_turn, m_playerOne, i_row, i_col);
                    i_turn = 2;
                    botPlay(ref i_turn, m_playerTwo);
                }
                else
                {
                    m_playerOne.hasMoves = m_playerTwo.hasMoves = false;
                }
            }
            else
            {
                switch (i_turn)
                {
                    case 1:
                        if (hasAnyMove(i_turn, m_playerOne))
                        {
                            playerPlay(ref i_turn, m_playerOne, i_row, i_col);
                            i_turn = 2;
                            break;
                        }
                        else
                        {
                            m_playerOne.hasMoves = false;
                            i_turn = 2;
                            break;
                        }
                    case 2:
                        if (hasAnyMove(i_turn, m_playerTwo))
                        {
                            playerPlay(ref i_turn, m_playerTwo, i_row, i_col);
                            i_turn = 1;
                            break;
                        }
                        else
                        {
                            m_playerTwo.hasMoves = false;
                            i_turn = 1;
                            break;
                        }
                }
            }
            m_board.Replace3With0();
            m_board.UpdateValidBoard(i_turn);
        }


    }    
}

