using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW9_1_MusicPlayer
{
    public partial class Form1 : Form
    {
        Form2 f2 = new Form2();
        MusicPlayer mp = new MusicPlayer();
        string[] playlist;
        string path;
        bool created = false;
        RadioButton[] rb = new RadioButton[4];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.f2.Hide();
        }

        private void Loop_CheckedChanged(object sender, EventArgs e)
        {
            if (Loop.Checked)
            {
                this.mp.loop = true;
            }
            else
            {
                this.mp.loop = false;
            }
        }

        private void FileBtn_Click(object sender, EventArgs e)
        {
            this.playlist = this.mp.SelectWavFiles();
            if (this.playlist != null)
            {
                Create();
            }
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            this.mp.SetMusicLocation(this.path);
            this.mp.PlayMusic(); 
            if (this.Loop.Checked)
            {
                this.f2.Show();
            }
        }

        private void rb_checked(object sender, EventArgs e)
        {
            RadioButton RBref = (RadioButton)sender;
            this.path = RBref.Text;
            this.mp.Stop();
            this.f2.Hide();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            this.mp.Stop();
            this.f2.Hide();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (this.created)
            {
                this.mp.SavePlaylist();
            }
            else
            {
                MessageBox.Show("請先建立播放清單", "", MessageBoxButtons.OK);
            }
            
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.playlist = this.mp.LoadPlaylist();
            if (this.playlist != null)
            {
                Create();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK && this.playlist != null)
            {
                for (int i = 0; i < this.playlist.Length; i++)
                {
                    this.rb[i].ForeColor = colorDialog.Color;
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            fontDialog.MaxSize = 24;
            if (fontDialog.ShowDialog() == DialogResult.OK && this.playlist != null)
            {
                for (int i = 0; i < this.playlist.Length; i++)
                {
                    this.rb[i].Font = fontDialog.Font;
                    this.rb[i].SetBounds(30, 30 + fontDialog.Font.Height * i, 500, fontDialog.Font.Height);
                }
            }
        }

        private void Create()
        {
            for (int i = 0; i < this.rb.Length; i++)
            {
                if (this.rb[i] != null)
                {
                    this.rb[i].Dispose();
                }
            }
            this.rb = new RadioButton[this.playlist.Length];
            for (int i = 0; i < this.playlist.Length; i++)
            {
                this.rb[i] = new RadioButton();
                this.rb[i].ForeColor = colorDialog.Color;
                this.rb[i].Font = fontDialog.Font;
                this.rb[i].SetBounds(30, 30 + fontDialog.Font.Height * i, 500, fontDialog.Font.Height);
                this.rb[i].Text = this.playlist[i];
                this.rb[i].Click += new EventHandler(rb_checked);
                Playlist.Controls.Add(this.rb[i]);
            }
            this.rb[0].Checked = true;
            this.path = this.rb[0].Text;
            this.created = true;
            this.f2.Hide();
        }
    }
}
