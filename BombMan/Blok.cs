using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BombMan
{
    class Blok
    {
        public PictureBox[] Tablica;  //tablica obrazków
        public int d;                 //ilość obrazków w tablicy(jej długość)

        public Blok()  //konstruktor
        {
            Tablica = null;
            d = 0;
        }
        public bool Testr(PictureBox player, bool k) //kolizja z lewej storny
        {
            for (int i = 0; i < d; i++)
            {
                if (Tablica[i] != null && Tablica[i].Name == "block" + i.ToString()) //sprawdza tylko bloczki
                {
                    if (player.Right >= Tablica[i].Left - 2 && player.Right < Tablica[i].Right && player.Bottom > Tablica[i].Top && player.Top < Tablica[i].Bottom)
                    {
                        player.Left = Tablica[i].Left - player.Width; //ustawia w pozycji gracza jego szerokość w lewo od bloczka
                        return false;
                        //  player.Left = player.Left-3;
                    }
                }
            }
            if (player.Right >= 388)
            {
                player.Left = 390 - player.Width;
                return false;
            }
            return k;
        }
        public bool Testl(PictureBox player, bool k) //kolizja z prawej strony
        {
            for (int i = 0; i < d; i++)
            {
                if (Tablica[i] != null && Tablica[i].Name == "block" + i.ToString()) //sprawdza tylko bloczki
                {
                    if (player.Left <= Tablica[i].Right + 2 && player.Left > Tablica[i].Left && player.Bottom > Tablica[i].Top && player.Top < Tablica[i].Bottom)
                    {
                        player.Left = Tablica[i].Right; //ustawia w pozycji gracza po prawej stronie bloczka
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
        public bool Testt(PictureBox player, bool k) //kolizja z góry
        {
            for (int i = 0; i < d; i++)
            {
                if (Tablica[i] != null && Tablica[i].Name == "block" + i.ToString()) //sprawdza tylko bloczki
                {
                    if (player.Top <= Tablica[i].Bottom + 2 && player.Right > Tablica[i].Left && player.Left < Tablica[i].Right && player.Top > Tablica[i].Top)
                    {
                        player.Top = Tablica[i].Bottom; //ustawia w pozycji gracza pod bloczkiem
                        return false;
                        //player.Top = player.Top + 3;
                    }
                }
            }
            if (player.Top <= 2)
            {
                player.Top = 0;
                return false;
            }
            return k;
        }
        public bool Testb(PictureBox player, bool k) //kolizja z dołu
        {
            for (int i = 0; i < d; i++)
            {
                if (Tablica[i] != null && Tablica[i].Name == "block" + i.ToString()) //sprawdza tylko bloczki
                {
                    if (player.Bottom >= Tablica[i].Top - 2 && player.Right > Tablica[i].Left && player.Left < Tablica[i].Right && player.Bottom < Tablica[i].Bottom)
                    {
                        player.Top = Tablica[i].Top - player.Height; //ustawia w pozycji gracza jego wysokość w górę od bloczka
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

        public void Bloczki(Plan p) //translacja z planu na bloczki
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
                            Name = "potwor" + n.ToString(),
                            Size = new System.Drawing.Size(30, 30),
                            SizeMode = PictureBoxSizeMode.Zoom,
                            TabIndex = n,
                            TabStop = false
                        };
                    }
                }
            }
        }

        public int Bomba(PictureBox player, int ilosc_bomb, Blok A) //postawienie bomby
        {
            int x, y, n;
            x = (player.Top + player.Bottom) / 2; //współrzędna x (góra-dół)
            y = (player.Left + player.Right) / 2; //współrzędan y (prawo-lewo)
            x = x - (x % 30);
            y = y - (y % 30);
            n = (y * 11 / 30) + x / 30;
            if (ilosc_bomb == 0) return 0;
            if (A.Tablica[n] != null) return ilosc_bomb;
            if (Tablica != null) //jeżeli kiedyś została postawiona bomba
            {
                for (int i = 0; i < d; i++)
                {
                    if (Tablica[i] != null && Tablica[i].Left == y && Tablica[i].Top == x) return ilosc_bomb;
                }
            }
            n = ilosc_bomb - 1;
            if (Tablica == null) //jeżeli nie została jeszcze postawiona bomba to nie ma tablicy
            {
                d = ilosc_bomb;
                Tablica = new PictureBox[d];
            }
            if (d < ilosc_bomb) //jeżeli została zwiększona ilość bomb podczas działania programu przez bonus to zostaje zwiększona ilość elementów tablicy,w której są bomby
            {
                PictureBox[] B;
                B = new PictureBox[ilosc_bomb];
                for (int i = 0; i < d; i++)
                {
                    if (Tablica[i] != null) B[i] = Tablica[i];
                }
                Tablica = B;
            }
            Tablica[n] = new PictureBox() //stworzenie bomby
            {
                Image = Properties.Resources.bomba,
                Location = new System.Drawing.Point(y, x),
                Name = "bomb" + n.ToString(),
                Size = new System.Drawing.Size(30, 30),
                TabIndex = n,
                TabStop = false,
                Visible = true,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = System.Drawing.Color.Transparent
            };
            Tablica[n].SendToBack(); //bomba pod graczem
            return n;
        }

        public Blok Bum(int Zasięg, Plan P, PictureBox bomba) //funkcja tworząca tablice zawierającą bombę płomienie i bloczki do zniszczenia
        {
            if (bomba == null) return null;
            int x, y, n, wielki = 0, bu_x1 = -1, bu_y1 = -1, bu_x2 = -1, bu_y2 = -1, max_x1 = 0, max_x2 = 0, max_y1 = 0, max_y2 = 0;
            x = (bomba.Left + bomba.Right) / 2; //współrzędan x (prawo-lewo) UWAGA
            y = (bomba.Top + bomba.Bottom) / 2; //współrzędna y (góra-dół)
            x = x - (x % 30);
            y = y - (y % 30);
            x = x / 30;
            y = y / 30;
            n = y * 11 + x;
            for (int j = y - 1; j > y - Zasięg - 1 && j >= 0; j--)
            {
                if (P.Tablica[x][j] == 2) break;

                wielki++; //wielkość tablicy
                max_y1++; //ile w góre
                if (P.Tablica[x][j] == 1) bu_y1 = max_y1;
                if (P.Tablica[x][j] == 1) break;
            }
            for (int j = y + 1; j < y + Zasięg + 1 && j < 11; j++)
            {
                if (P.Tablica[x][j] == 2) break;

                wielki++;
                max_y2++; //ile w dół
                if (P.Tablica[x][j] == 1) bu_y2 = max_y2;
                if (P.Tablica[x][j] == 1) break;
            }
            for (int i = x + 1; i < x + Zasięg + 1 && i < 13; i++)
            {
                if (P.Tablica[i][y] == 2) break;

                wielki++;
                max_x2++; //ile w prawo
                if (P.Tablica[i][y] == 1) bu_x2 = max_x2;
                if (P.Tablica[i][y] == 1) break;
            }
            for (int i = x - 1; i > x - Zasięg - 1 && i >= 0; i--)
            {
                if (P.Tablica[i][y] == 2) break;

                wielki++;
                max_x1++; //ile w lewo
                if (P.Tablica[i][y] == 1) bu_x1 = max_x1;
                if (P.Tablica[i][y] == 1) break;
            }
            Blok dele = new Blok()
            {
                d = wielki + 1 //jeszcze jeden dla bomby
            };
            dele.Tablica = new PictureBox[dele.d];
            for (int i = 0; i < wielki + 2; i++)
            {
                if (i < max_y1) //płomień nad bombą
                {
                    dele.Tablica[i] = new PictureBox()
                    {
                        Image = Properties.Resources.plonienpion,
                        Location = new System.Drawing.Point(x * 30, (y - max_y1 + i) * 30),
                        Name = "plomien" + i.ToString(),
                        Size = new System.Drawing.Size(32, 32),
                        TabIndex = i,
                        TabStop = false,
                        Visible = true,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackColor = System.Drawing.Color.Transparent
                    };
                    dele.Tablica[i].BringToFront();
                }
                if (i >= max_y1 && i < max_y1 + max_x1) //płomień po lewej
                {
                    dele.Tablica[i] = new PictureBox()
                    {
                        Image = Properties.Resources.plonienpoziom,
                        Location = new System.Drawing.Point((x - max_x1 + i - max_y1) * 30, y * 30),
                        Name = "plomien" + i.ToString(),
                        Size = new System.Drawing.Size(32, 32),
                        TabIndex = i,
                        TabStop = false,
                        Visible = true,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackColor = System.Drawing.Color.Transparent
                    };
                    dele.Tablica[i].BringToFront();
                }
                if (i == max_y1 + max_x1) //bomba
                {
                    dele.Tablica[i] = bomba;
                }
                if (i <= max_x2 + max_x1 + max_y1 && i > max_y1 + max_x1) //płomień po prawej
                {
                    dele.Tablica[i] = new PictureBox()
                    {
                        Image = Properties.Resources.plonienpoziom,
                        Location = new System.Drawing.Point((x - max_y1 - max_x1 + i) * 30, y * 30),
                        Name = "plomien" + i.ToString(),
                        Size = new System.Drawing.Size(32, 32),
                        TabIndex = i,
                        TabStop = false,
                        Visible = true,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackColor = System.Drawing.Color.Transparent
                    };
                    dele.Tablica[i].BringToFront();
                }
                if (i <= wielki && i > max_x2 + max_x1 + max_y1) //płomień pod bombą
                {
                    dele.Tablica[i] = new PictureBox()
                    {
                        Image = Properties.Resources.plonienpion,
                        Location = new System.Drawing.Point(x * 30, (y + i - (max_x2 + max_x1 + max_y1)) * 30),
                        Name = "plomien" + i.ToString(),
                        Size = new System.Drawing.Size(32, 32),
                        TabIndex = i,
                        TabStop = false,
                        Visible = true,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackColor = System.Drawing.Color.Transparent
                    };
                    dele.Tablica[i].BringToFront();
                }
            }
            if (bu_y1 != -1) //kiedy bloczek do zniszczenia jest nad bombą
            {
                int l = x * 11 + y - bu_y1;
                if (dele.Tablica[0] != null) dele.Tablica[0].Dispose(); ///bum bloczek nad bombą
                dele.Tablica[0] = Tablica[l];
                dele.Tablica[0].Name = "block" + 0.ToString();
                Tablica[l] = null;
            }
            if (bu_x1 != -1) //kiedy bloczek do zniszczenia jest po lewej
            {
                int l = (x - bu_x1) * 11 + y;
                if (dele.Tablica[max_y1] != null) dele.Tablica[max_y1].Dispose(); ///bum bloczek po lewej
                dele.Tablica[max_y1] = Tablica[l];
                dele.Tablica[max_y1].Name = "block" + max_y1.ToString();
                Tablica[l] = null;
            }
            if (bu_x2 != -1) //kiedy bloczek do zniszczenia jest po prawej
            {
                int l = (x + bu_x2) * 11 + y;
                if (dele.Tablica[max_y1 + max_x1 + max_x2] != null) dele.Tablica[max_y1 + max_x1 + max_x2].Dispose(); ///bum bloczek po prawej
                dele.Tablica[max_y1 + max_x1 + max_x2] = Tablica[l];
                dele.Tablica[max_y1 + max_x1 + max_x2].Name = "block" + (max_y1 + max_x1 + max_x2).ToString();
                Tablica[l] = null;
            }
            if (bu_y2 != -1) //kiedy bloczek do zniszczenia jest pod bombą
            {
                int l = x * 11 + y + bu_y2;
                if (dele.Tablica[wielki] != null) dele.Tablica[wielki].Dispose(); ///bum bloczek pod bombą
                dele.Tablica[wielki] = Tablica[l];
                dele.Tablica[wielki].Name = "block" + wielki.ToString(); 
                Tablica[l] = null;
            }
            return dele;
        }
    }
}
