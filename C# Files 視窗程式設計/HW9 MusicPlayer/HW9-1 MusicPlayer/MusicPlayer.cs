using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW9_1_MusicPlayer
{
    class MusicPlayer: SoundPlayer
    {
        public bool loop = false;
        public string[] playlist;

        public string[] SelectWavFiles()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            String stFilter = "WAV(*.wav)|*.wav";

            ofd.Filter = stFilter;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.playlist = new string[ofd.FileNames.Length];
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    this.playlist[i] = ofd.FileNames[i];
                }
                this.Stop();
            }
            else
            {
                return null;
            }
            return this.playlist;
        }

        public void PlayMusic()
        {
            if (loop)
            {
                this.PlayLooping();
                return;
            }
            else
            {
                this.Play();
                return;
            }
        }

        public void SetMusicLocation(string path)
        {
            this.SoundLocation = path;
            this.Load();
        }

        public void SavePlaylist()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(sfd.FileName, playlist);
            }
        }

        public string[] LoadPlaylist()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                int n = 0;
                string[] tmp = new string[4];
                while (true)
                {
                    tmp[n] = sr.ReadLine();
                    n++;
                    if (sr.Peek() == -1)
                    {
                        break;
                    }
                }
                sr.Close();
                this.playlist = new string[n];
                for (int i = 0; i < n; i++)
                {
                    this.playlist[i] = tmp[i];
                }
                this.Stop();
            }
            else
            {
                return null;
            }
            return this.playlist;
        }
    }
}
