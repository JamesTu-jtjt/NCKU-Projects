using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW8_2_5inaRow
{
    public partial class Form1 : Form
    {
        string p1 = "w", p2 = "w", state = "n";
        Character P1, P2, CP;
        Piece[,] Board = new Piece[19, 19];
        DialogResult result;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartBtn.Visible = true;
            W1Btn.Visible = true;
            W2Btn.Visible = true;
            M1Btn.Visible = true;
            M2Btn.Visible = true;
            A1Btn.Visible = true;
            A2Btn.Visible = true;
            P1nBtn.Visible = false;
            P1hBtn.Visible = false;
            P1vBtn.Visible = false;
            P1cBtn.Visible = false;
            P2nBtn.Visible = false;
            P2hBtn.Visible = false;
            P2vBtn.Visible = false;
            P2cBtn.Visible = false;
        }

        private void W1Btn_Click(object sender, EventArgs e)
        {
            P1L.Text = "P1: 戰士";
            this.p1 = "w";
        }

        private void W2Btn_Click(object sender, EventArgs e)
        {
            P2L.Text = "P2: 戰士";
            this.p2 = "w";
        }

        private void M1Btn_Click(object sender, EventArgs e)
        {
            P1L.Text = "P1: 法師";
            this.p1 = "m";
        }

        private void M2Btn_Click(object sender, EventArgs e)
        {
            P2L.Text = "P2: 法師";
            this.p2 = "m";
        }

        private void A1Btn_Click(object sender, EventArgs e)
        {
            P1L.Text = "P1: 弓箭手";
            this.p1 = "a";
        }

        private void A2Btn_Click(object sender, EventArgs e)
        {
            P2L.Text = "P2: 弓箭手";
            this.p2 = "a";
        }
        private void StartBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    this.Board[i, j] = new Piece();
                    this.Board[i, j].SetBounds(200 + 19 * j, 50 + 19 * i, 21, 21);
                    this.Board[i, j].row = i;
                    this.Board[i, j].col = j;
                    this.Board[i, j].Click += new EventHandler(Board_Click);
                    Controls.Add(this.Board[i, j]);
                }
            }
            switch (this.p1)
            {
                case "w":
                    this.P1 = new Warrior(1);
                    break;
                case "m":
                    this.P1 = new Magician(1);
                    break;
                case "a":
                    this.P1 = new Archer(1);
                    break;
            }
            switch (this.p2)
            {
                case "w":
                    this.P2 = new Warrior(2);
                    break;
                case "m":
                    this.P2 = new Magician(2);
                    break;
                case "a":
                    this.P2 = new Archer(2);
                    break;
            }
            StartBtn.Visible = false;
            W1Btn.Visible = false;
            W2Btn.Visible = false;
            M1Btn.Visible = false;
            M2Btn.Visible = false;
            A1Btn.Visible = false;
            A2Btn.Visible = false;
            P1nBtn.Visible = true;
            P1hBtn.Visible = true;
            P1hBtn.Text = "橫向棋子: " + P1.numB.ToString() + "顆";
            P1vBtn.Visible = true;
            P1vBtn.Text = "縱向棋子: " + P1.numC.ToString() + "顆";
            P1cBtn.Visible = true;
            P1cBtn.Text = "覆蓋棋子: " + P1.numD.ToString() + "顆";
            P2nBtn.Visible = true;
            P2hBtn.Visible = true;
            P2hBtn.Text = "橫向棋子: " + P2.numB.ToString() + "顆";
            P2vBtn.Visible = true;
            P2vBtn.Text = "縱向棋子: " + P2.numC.ToString() + "顆";
            P2cBtn.Visible = true;
            P2cBtn.Text = "覆蓋棋子: " + P2.numD.ToString() + "顆";
            SwitchPlayer(2);
        }

        private void P1nBtn_Click(object sender, EventArgs e)
        {
            this.state = "n";
        }

        private void P1hBtn_Click(object sender, EventArgs e)
        {
            this.state = "h";
        }

        private void P1vBtn_Click(object sender, EventArgs e)
        {
            this.state = "v";
        }

        private void P1cBtn_Click(object sender, EventArgs e)
        {
            this.state = "c";
        }

        private void P2nBtn_Click(object sender, EventArgs e)
        {
            this.state = "n";
        }

        private void P2hBtn_Click(object sender, EventArgs e)
        {
            this.state = "h";
        }

        private void P2vBtn_Click(object sender, EventArgs e)
        {
            this.state = "v";
        }

        private void P2cBtn_Click(object sender, EventArgs e)
        {
            this.state = "c";
        }
        private void Board_Click(object sender, EventArgs e)
        {
            Piece pieceRef = (Piece)sender;
            bool valid = false;
            switch (this.state)
            {
                case "n":
                    if (pieceRef.playerPiece == 0)
                    {
                        pieceRef.BackColor = this.CP.color;
                        pieceRef.playerPiece = this.CP.p;
                        valid = true;
                    }
                    break;
                case "h":
                    if (pieceRef.playerPiece == 0)
                    {
                        pieceRef.BackColor = this.CP.color;
                        pieceRef.playerPiece = this.CP.p;
                        if (pieceRef.col + 1 != 19 && this.Board[pieceRef.row, pieceRef.col + 1].playerPiece == 0)
                        {
                            this.Board[pieceRef.row, pieceRef.col + 1].BackColor = this.CP.color;
                            this.Board[pieceRef.row, pieceRef.col + 1].playerPiece = this.CP.p;
                        }
                        this.CP.numB--;
                        valid = true;
                    }
                    break;
                case "v":
                    if (pieceRef.playerPiece == 0)
                    {
                        pieceRef.BackColor = this.CP.color;
                        pieceRef.playerPiece = this.CP.p;
                        if (pieceRef.row + 1 != 19 && this.Board[pieceRef.row + 1, pieceRef.col].playerPiece == 0)
                        {
                            this.Board[pieceRef.row + 1, pieceRef.col].BackColor = this.CP.color;
                            this.Board[pieceRef.row + 1, pieceRef.col].playerPiece = this.CP.p;
                        }
                        this.CP.numC--;
                        valid = true;
                    }
                    break;
                case "c":
                    if (pieceRef.playerPiece != this.CP.p)
                    {
                        pieceRef.BackColor = this.CP.color;
                        pieceRef.playerPiece = this.CP.p;
                        this.CP.numD--;
                        valid = true;
                    }
                    break;
            }
            if (valid)
            {
                if (pieceRef.Win(this.Board))
                {
                    this.result = MessageBox.Show("遊戲結束!! \n" + "P" + pieceRef.playerPiece.ToString() + "獲勝!", "", MessageBoxButtons.OK);
                    if (this.result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                SwitchPlayer(this.CP.p);
            }
        }
        
        private void SwitchPlayer(int player)
        {
            if (player == 1)
            {
                this.CP = this.P2;
                P1nBtn.Enabled = false;
                P1hBtn.Enabled = false;
                P1vBtn.Enabled = false;
                P1cBtn.Enabled = false;
                P2nBtn.Enabled = true;
                if (this.CP.numB > 0)
                {
                    P2hBtn.Enabled = true;
                }
                if (this.CP.numC > 0)
                {
                    P2vBtn.Enabled = true;
                }
                if (this.CP.numD > 0)
                {
                    P2cBtn.Enabled = true;
                }
            }
            else
            {
                this.CP = this.P1;
                P1nBtn.Enabled = true;
                P2nBtn.Enabled = false;
                P2hBtn.Enabled = false;
                P2vBtn.Enabled = false;
                P2cBtn.Enabled = false;
                if (this.CP.numB > 0)
                {
                    P1hBtn.Enabled = true;
                }
                if (this.CP.numC > 0)
                {
                    P1vBtn.Enabled = true;
                }
                if (this.CP.numD > 0)
                {
                    P1cBtn.Enabled = true;
                }
            }
            this.state = "n";
            P1hBtn.Text = "橫向棋子: " + this.P1.numB.ToString() + "顆";
            P1vBtn.Text = "縱向棋子: " + this.P1.numC.ToString() + "顆";
            P1cBtn.Text = "覆蓋棋子: " + this.P1.numD.ToString() + "顆";
            P2hBtn.Text = "橫向棋子: " + this.P2.numB.ToString() + "顆";
            P2vBtn.Text = "縱向棋子: " + this.P2.numC.ToString() + "顆";
            P2cBtn.Text = "覆蓋棋子: " + this.P2.numD.ToString() + "顆";
        }
    }
}
