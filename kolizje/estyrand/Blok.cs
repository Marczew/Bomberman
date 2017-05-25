using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estyrand
{
    class Blok
    {
        public PictureBox[] Tablica;
        public int d;

        public Blok()
        {
            Tablica = null;
            d = 0;
        }
        public bool Testr(PictureBox player,bool k)
        {
            for (int i = 0; i < d; i++)
            {
                if (Tablica[i] != null)
                {
                    if (player.Right >= Tablica[i].Left - 2 && player.Right < Tablica[i].Right && player.Bottom > Tablica[i].Top && player.Top < Tablica[i].Bottom)
                    {
                        player.Left = Tablica[i].Left - (player.Right - player.Left);
                        return false;
                        //  player.Left = player.Left-3;
                    }
                }
            }
            if (player.Right >= 388)
            {
                player.Left = 388 - player.Width;
                return false;
            }
            return k;
        }
        public bool Testl(PictureBox player,bool k)
        {
            for (int i = 0; i < d; i++)
            {
                if (Tablica[i] != null)
                {
                    if (player.Left <= Tablica[i].Right + 2 && player.Left > Tablica[i].Left && player.Bottom > Tablica[i].Top && player.Top < Tablica[i].Bottom)
                    {
                        player.Left = Tablica[i].Right;
                        return false;
                        // player.Left = player.Left + 3;
                    }
                }
            }
            if (player.Left <= 2)
            {
                player.Left = 0;
                return false;
            }
            return k;
        }
        public bool Testt(PictureBox player,bool k)
        {
            for (int i = 0; i < d; i++)
            {
                if (Tablica[i] != null)
                {
                    if (player.Top <= Tablica[i].Bottom + 2 && player.Right > Tablica[i].Left && player.Left < Tablica[i].Right && player.Top > Tablica[i].Top)
                    {
                        player.Top = Tablica[i].Bottom;
                        return false;
                        //player.Top = player.Top + 3;
                    }
                }
            }
            if (player.Top <=2 )
            {
                player.Top = 0;
                return false;
            }
            return k;
        }
        public bool Testb(PictureBox player,bool k)
        {
            for (int i = 0; i < d; i++)
            {
                if (Tablica[i] != null)
                {
                    if (player.Bottom >= Tablica[i].Top - 2 && player.Right > Tablica[i].Left && player.Left < Tablica[i].Right && player.Bottom < Tablica[i].Bottom)
                    {
                        player.Top = Tablica[i].Top - player.Height;
                        return false;
                        //  player.Top = player.Top - 3;
                    }
                }
            }
            if (player.Bottom >= 328)
            {
                player.Top = 330 - player.Height;
                return false;
            }
            return k;
        }

        public void Bloczki(Plan p)
        {
            int n;
            d = p.w * p.k;
            Tablica = new PictureBox[d];
            for (int i = 0; i < p.w; i++)
            {
                for (int j = 0; j < p.k; j++)
                {
                    if (p.Tablica[i][j] == 1)
                    {
                        n = i * 11 + j;
                        Tablica[n] = new PictureBox()
                        {
                            BackgroundImage = Properties.Resources.cegla,
                            Location = new System.Drawing.Point(i * 30, j * 30),
                            Name = "block" + n.ToString(),
                            Size = new System.Drawing.Size(30, 30),
                            TabIndex = n,
                            TabStop = false
                        };
                    }
                    if (p.Tablica[i][j] == 2)
                    {
                        n = i * 11 + j;
                        Tablica[n] = new PictureBox()
                        {
                            BackgroundImage = Properties.Resources.Brick,
                            Location = new System.Drawing.Point(i * 30, j * 30),
                            Name = "block" + n.ToString(),
                            Size = new System.Drawing.Size(30, 30),
                            TabIndex = n,
                            TabStop = false,
                            Visible = true
                        };
                    }
                    if (p.Tablica[i][j] == 3)
                    {
                        n = i * 11 + j;
                        Tablica[n] = new PictureBox()
                        {
                            BackgroundImage = Properties.Resources.BigBubble,
                            Location = new System.Drawing.Point(i * 30, j * 30),
                            Name = "block" + n.ToString(),
                            Size = new System.Drawing.Size(30, 30),
                            TabIndex = n,
                            TabStop = false
                        };
                    }
                }
            }
        }
    }
}
