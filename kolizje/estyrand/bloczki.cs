using System.Windows.Forms;

namespace estyrand
{
    class Bloczki
    {
        PictureBox[] t;
        int d;
        bool Testr(PictureBox player)
        {
            for (int i = 0; i < this->d; i++)
            {
                if (player.Right >= t[i].Left - 2 && player.Right < t[i].Right && player.Bottom > t[i].Top && player.Top < t[i].Bottom)
                {
                    player.Left = t[i].Left - (player.Right - player.Left);
                    return false;
                    //  player.Left = player.Left-3;
                }
            }
        }
        bool Testl(PictureBox player)
        {
            for (int i = 0; i < this->d; i++)
            {
                if (player.Left <= t[i].Right + 2 && player.Left > t[i].Left && player.Bottom > t[i].Top && player.Top < t[i].Bottom)
                {
                    player.Left = t[i].Right;
                    return false;
                    // player.Left = player.Left + 3;
                }
            }
        }
            bool Testt(PictureBox player)
            {
                for (int i = 0; i < d; i++)
                {
                    if (player.Top <= t[i].Bottom + 2 && player.Right > t[i].Left && player.Left < t[i].Right && player.Top > t[i].Top)
                    {
                        player.Top = t[i].Bottom;
                        return false;
                        //player.Top = player.Top + 3;
                    }
                }
            }
            bool Testb(PictureBox player)
            {
                for (int i = 0; i < d; i++)
                {
                    if (player.Bottom >= t[i].Top - 2 && player.Right > t[i].Left && player.Left < t[i].Right && player.Bottom < t[i].Bottom)
                    {
                        player.Top = t[i].Top - (player.Bottom - player.Top);
                        return false;
                        //  player.Top = player.Top - 3;
                    }
                }
            }

            Bloczki(randplan p);
            {
                int n;
                this->d = p.w * p.k;
                this->t = new PictureBox[d];
                for (int i = 0; i < p.w; i++)
                {
                    for (int j = 0; j < p.k; j++)
                    {
                        if (p.t[i][j] == 1)
                        {
                            n = i * 13 + j;
                            this->t[n] = new PictureBox()
                            {
                                BackgroundImage = global::Gierka.Properties.Resources.cegla,
                                Location = new System.Drawing.Point(i * 30, j * 30),
                                Name = "block" + n.ToString(),
                                Size = new System.Drawing.Size(30, 30),
                                TabIndex = n,
                                TabStop = false
                            };
                        }
                        if (p.t[i][j] == 2)
                        {
                            n = i * 13 + j;
                            this->t[n] = new PictureBox()
                            {
                                BackgroundImage = global::Gierka.Properties.Resources.Brick,
                                Location = new System.Drawing.Point(i * 30, j * 30),
                                Name = "block" + n.ToString(),
                                Size = new System.Drawing.Size(30, 30),
                                TabIndex = n,
                                TabStop = false
                            };
                        }
                        if (p.t[i][j] == 3)
                        {
                            n = i * 13 + j;
                            this->t[n] = new PictureBox()
                            {
                                BackgroundImage = global::Gierka.Properties.Resources.BigBubble,
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
}
