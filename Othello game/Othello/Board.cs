using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Othello
{
    public class Board
    {
        public int[,] m_board;
        public int m_size;
        private static readonly int[] sr_dx = { 1, 1, 0, -1, -1, -1, 0, 1 };
        private static readonly int[] sr_dy = { 0, 1, 1, 1, 0, -1, -1, -1 };
        public Board()
        {
            this.m_board = null;
            this.m_size = 0;
        }

        public int Size
        {
            get { return this.m_size; }
            set { this.m_size = value; }
        }

        public void SetBoard(int i_size)
        {
            this.m_board = new int[i_size, i_size];
            for (int i = 0; i < i_size; i++)
            {
                this.m_board[0, i] = -1;
                this.m_board[i, 0] = -1;
                this.m_board[i_size - 1, i] = -1;
                this.m_board[i, i_size - 1] = -1;
            }
            for (int i = 1; i < i_size; i++)
            {
                for (int j = 1; j < i_size; j++)
                {
                    this.m_board[i, j] = 0;
                }
            }
            this.m_board[(i_size / 2) - 1, (i_size / 2) - 1] = 1;
            this.m_board[(i_size / 2), (i_size / 2)] = 1;
            this.m_board[(i_size / 2) - 1, i_size / 2] = 2;
            this.m_board[i_size / 2, (i_size / 2) - 1] = 2;

        }

        private bool checkFlip(int i_xPoisition, int i_yPoisition, int i_dirX, int i_dirY, int io_turn)
        {
            int tempX = i_xPoisition + i_dirX;
            int tempY = i_yPoisition + i_dirY;
            bool o_flag = false;

            while (m_board[tempX, tempY] != io_turn && m_board[tempX, tempY] != -1 && tempX <= m_size && tempY <= m_size)
            {
                if (tempX == 0 || tempX == m_size)
                {
                    break;
                }
                if (tempY == 0 || tempY == m_size)
                {
                    break;
                }
                tempX += i_dirX;
                tempY += i_dirY;
            }

            if (m_board[tempX, tempY] == io_turn)
            {
                while (i_xPoisition != tempX || i_yPoisition != tempY)
                {
                    UpdateBoard(i_xPoisition, i_yPoisition, io_turn);
                    i_xPoisition += i_dirX;
                    i_yPoisition += i_dirY;
                    o_flag = true;
                }
            }

            return o_flag;
        }

        public bool CheckNeighbour(int i_xPosition, int i_yPosition, int io_turn)
        {
            bool o_flag = false;

            switch (io_turn)
            {
                case 1:
                    for (int k = 0; k < sr_dx.Length; k++)
                    {
                        int i = sr_dx[k];
                        int j = sr_dy[k];

                        if (m_board[i_xPosition + i, i_yPosition + j] == 2 && checkFlip(i_xPosition, i_yPosition, i, j, io_turn))
                        {
                            o_flag = true;
                        }
                    }

                    break;
                case 2:
                    for (int k = 0; k < sr_dx.Length; k++)
                    {
                        int i = sr_dx[k];
                        int j = sr_dy[k];

                        if (m_board[i_xPosition + i, i_yPosition + j] == 1 && checkFlip(i_xPosition, i_yPosition, i, j, io_turn))
                        {
                            o_flag = true;
                        }
                    }

                    break;
            }
            return o_flag;
        }

        public bool ValidateMove(int i_xPosition, int i_yPosition, int io_turn)
        {
            bool o_flag;

            if ((i_xPosition <= m_size && i_xPosition >= 1) && (i_yPosition <= m_size && i_yPosition >= 1))
            {
                if (m_board[i_xPosition, i_yPosition] == 1 || m_board[i_xPosition, i_yPosition] == 2)
                {
                    o_flag = false;
                }
                else
                {
                    o_flag = CheckNeighbour(i_xPosition, i_yPosition, io_turn);
                }
            }
            else
            {
                o_flag = false;
            }
            return o_flag;
        }

        public void UpdateBoard(int i_xPosition, int i_yPosition, int i_player)
        {
            this.m_board[i_xPosition, i_yPosition] = i_player;
        }

        public void UpdateValidBoard(int i_player)
        {
            for (int i = 1; i < m_size + 1; i++)
            {
                for (int j = 1; j < m_size + 1; j++)
                {
                    if (m_board[i, j] == 0 && ValidateMoveStart(i, j, i_player))
                    {
                        m_board[i, j] = 3;
                    }
                }
            }
        }

        public bool ValidateMoveStart(int i_xPosition, int i_yPosition, int io_turn)
        {
            bool o_flag;

            if ((i_xPosition <= m_size && i_xPosition >= 1) && (i_yPosition <= m_size && i_yPosition >= 1))
            {
                if (m_board[i_xPosition, i_yPosition] == 1 || m_board[i_xPosition, i_yPosition] == 2)
                {
                    o_flag = false;
                }
                else
                {
                    o_flag = CheckNeighbourStart(i_xPosition, i_yPosition, io_turn);
                }
            }
            else
            {
                o_flag = false;
            }
            return o_flag;
        }

        public bool CheckNeighbourStart(int i_xPosition, int i_yPosition, int io_turn)
        {
            bool o_flag = false;


            switch (io_turn)
            {
                case 1:
                    for (int k = 0; k < sr_dx.Length; k++)
                    {
                        int i = sr_dx[k];
                        int j = sr_dy[k];

                        if (m_board[i_xPosition + i, i_yPosition + j] == 2 && checkFlipStart(i_xPosition, i_yPosition, i, j, io_turn))
                        {
                            o_flag = true;
                        }
                    }

                    break;
                case 2:
                    for (int k = 0; k < sr_dx.Length; k++)
                    {
                        int i = sr_dx[k];
                        int j = sr_dy[k];

                        if (m_board[i_xPosition + i, i_yPosition + j] == 1 && checkFlipStart(i_xPosition, i_yPosition, i, j, io_turn))
                        {
                            o_flag = true;
                        }
                    }

                    break;
            }
            return o_flag;

        }

        private bool checkFlipStart(int i_xPoisition, int i_yPoisition, int i_dirX, int i_dirY, int io_turn)
        {
            int tempX = i_xPoisition + i_dirX;
            int tempY = i_yPoisition + i_dirY;
            bool o_flag = false;
            while (m_board[tempX, tempY] != io_turn && m_board[tempX, tempY] != -1 && tempX <= m_size && tempY <= m_size)
            {
                if (tempX == 0 || tempX == m_size)
                {
                    break;
                }
                if (tempY == 0 || tempY == m_size)
                {
                    break;
                }
                tempX += i_dirX;
                tempY += i_dirY;
            }

            if (m_board[tempX, tempY] == io_turn)
            {
                while (i_xPoisition != tempX || i_yPoisition != tempY)
                {                    
                    i_xPoisition += i_dirX;
                    i_yPoisition += i_dirY;
                    o_flag = true;
                }
            }

            return o_flag;
        }

        public void Replace3With0()
        {
            int rows = m_size;
            int cols = m_size;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (this.m_board[i, j] == 3)
                    {
                        this.m_board[i, j] = 0;
                    }
                }
            }
        }

    }
}

