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
                if (Tablica[i] != null && Tablica[i].Name != "bomb" + i.ToString())
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
                if (Tablica[i] != null && Tablica[i].Name != "bomb" + i.ToString())
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
                if (Tablica[i] != null && Tablica[i].Name != "bomb" + i.ToString())
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
                if (Tablica[i] != null && Tablica[i].Name != "bomb" + i.ToString())
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
                            Image = Properties.Resources.BigBubble,
                            Location = new System.Drawing.Point(i * 30, j * 30),
                            Name = "block" + n.ToString(),
                            Size = new System.Drawing.Size(30, 30),
                            SizeMode = PictureBoxSizeMode.Zoom,
                            TabIndex = n,
                            TabStop = false
                        };
                    }
                }
            }
        }

        public PictureBox Bomba(PictureBox player)
        {
            int x, y,n;
            x = (player.Top + player.Bottom) / 2;
            y = (player.Left + player.Right) / 2;
            x = x - (x % 30);
            y = y - (y % 30);
            n = (x/30) * 11 + (y/30);
            Tablica[n] = new PictureBox()
            {
                Image = Properties.Resources.bomb1,
                Location = new System.Drawing.Point(y,x),
                Name = "bomb" + n.ToString(),
                Size = new System.Drawing.Size(30,30),
                TabIndex = n,
                TabStop = false,
                Visible = true,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = System.Drawing.Color.Transparent
            };
            Tablica[n].SendToBack();
            return Tablica[n];
        }
        
        public Blok bum(int Zasięg,Plan P,PictureBox bomba)
        {
            int x, y, n , wielki=0,bu_x1=-1,bu_y1=-1,bu_x2=-1,bu_y2=-1,max_x1=0,max_x2=0,max_y1=0,max_y2=0;
            x = (bomba.Top + bomba.Bottom) / 2;
            y = (bomba.Left + bomba.Right) / 2;
            x = x - (x % 30);
            y = y - (y % 30);
            x = x / 30;
            y = y / 30;
            n = x * 11 + y;
            for (int j = y; j > y - Zasięg && P.Tablica[x][j] != 2; j--)
            {
                wielki++;
                max_y1++;
                if (P.Tablica[x][j] == 1)
                {
                    bu_y1=j;
                    break;
                }
            }
            for (int j = y; j < y + Zasięg && P.Tablica[x][j]!=2; j++)
            {
                wielki++;
                max_y2++;
                if (P.Tablica[x][j] == 1)
                {
                    bu_y2 = j;
                    break;
                }
            }
            for (int i = x; i < x + Zasięg && P.Tablica[i][y] != 2; i++)
            {
                wielki++;
                max_x2++;
                if (P.Tablica[i][y] == 1)
                {
                    bu_x2 = i;
                    break;
                }
            }
            for (int i = x; i > x - Zasięg && P.Tablica[i][y] != 2; i--)
            {
                wielki++;
                max_x1++;
                if (P.Tablica[i][y] == 1)
                {
                    bu_x1 = i;
                    break;
                }
            }
            Blok dele = new Blok()
            {
                d = wielki,
                Tablica=new PictureBox[d]
            };
            for(int i=0;i<wielki;i++)
            {
                if (i < max_x1)
                {
                    dele.Tablica[i] = new PictureBox()
                    {
                        Image = Properties.Resources.bomb1,
                        Location = new System.Drawing.Point((x - max_x1+i) * 30, y*30),
                        Name = "plomien" + i.ToString(),
                        Size = new System.Drawing.Size(30, 30),
                        TabIndex = i,
                        TabStop = false,
                        Visible = true,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackColor = System.Drawing.Color.Transparent
                    };
                }
                if (i < wielki && i>max_y2+max_y1+max_x1)
                {
                    dele.Tablica[i] = new PictureBox()
                    {
                        Image = Properties.Resources.bomb1,
                        Location = new System.Drawing.Point((x+i-(max_y2 + max_y1 + max_x1)) * 30, y*30),
                        Name = "plomien" + i.ToString(),
                        Size = new System.Drawing.Size(30, 30),
                        TabIndex = i,
                        TabStop = false,
                        Visible = true,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackColor = System.Drawing.Color.Transparent
                    };
                }
                if (i > max_x1 && i < max_y1+max_x1)
                {
                    dele.Tablica[i] = new PictureBox()
                    {
                        Image = Properties.Resources.bomb1,
                        Location = new System.Drawing.Point(x * 30, (y-max_y1+i-max_x1) * 30),
                        Name = "plomien" + i.ToString(),
                        Size = new System.Drawing.Size(30, 30),
                        TabIndex = i,
                        TabStop = false,
                        Visible = true,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackColor = System.Drawing.Color.Transparent
                    };
                }
                if (i < max_y2 + max_y1 + max_x1 && i > max_y1+max_x1)
                {
                    dele.Tablica[i] = new PictureBox()
                    {
                        Image = Properties.Resources.bomb1,
                        Location = new System.Drawing.Point(x * 30, (y-max_y1-max_x1+i) * 30),
                        Name = "plomien" + i.ToString(),
                        Size = new System.Drawing.Size(30, 30),
                        TabIndex = i,
                        TabStop = false,
                        Visible = true,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackColor = System.Drawing.Color.Transparent
                    };
                }
            }
            if (bu_y1 != -1 && bu_x1!=-1)
            {
                dele.Tablica[bu_x1 + 1].Dispose();
                dele.Tablica[bu_x1+1]= Tablica[x * 11 + y - bu_y1];
                Tablica[x * 11 + y - bu_y1] = null;
            }
            if (bu_y2 != -1 && bu_y1 != -1 && bu_x1 != -1)
            {
                dele.Tablica[bu_x1 + bu_y1 + bu_y2].Dispose();
                dele.Tablica[bu_x1+bu_y1+bu_y2] = Tablica[x * 11 + y + bu_y2];
                Tablica[x * 11 + y + bu_y2] = null;
            }
            if (bu_x1 != -1)
            {
                dele.Tablica[0].Dispose();
                dele.Tablica[0] = Tablica[(x-bu_x1) * 11 + y];
                Tablica[(x-bu_x1) * 11 + y] = null;
            }
            if (bu_x2 != -1)
            {
                dele.Tablica[wielki-1].Dispose();
                dele.Tablica[wielki-1] = Tablica[(x + bu_x2) * 11 + y];
                Tablica[(x + bu_x2) * 11 + y] = null;
            }
            return dele;
        }
    }
}
