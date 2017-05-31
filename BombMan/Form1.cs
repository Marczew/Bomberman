using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BombMan
{
    public partial class BombMan : Form
    {
        bool right;
        bool left;
        bool up;
        bool down;

        Plan R; //plan mapy
        Blok B, A = new Blok();
        int ilosc_bomb = 1;
        int z = 2;  //zasięg wybuchu
        int index = 0;
        Blok[] C = new Blok[8];

        public BombMan()
        {
            R = new Plan()
            {
                N = 100, ///bloczki do niszczenia(max)
                P = 2   ///potwory(max)
            };
            R.Plano(); //stworzenie mapy
            B = new Blok();
            B.Bloczki(R); //zamiania planu na elementy graficzne
            for (int i = 0; i < B.d; i++) //wyswietlanie
            {
                if (B.Tablica[i] != null) Controls.Add(B.Tablica[i]);
            }
            InitializeComponent();
            player.Top = 0;
            player.Left = 0;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (right == true && index == 1)
            {
                player.Image = Properties.Resources.PlayerR;

            }
            if (left == true && index == 1)
            {
                player.Image = Properties.Resources.PlayerL;
            }
            if (up == true && index == 1)
            {
                player.Image = Properties.Resources.PlayerU;
            }
            if (down == true && index == 1)
            {
                player.Image = Properties.Resources.PlayerD;
            }
            if (down == false && up == false && left==false && right==false && index==0)
            {
                player.Image = Properties.Resources.PlayerS;
            }
            ///colision plansza
            right = B.Testr(player, right);
            left = B.Testl(player, left);
            up = B.Testt(player, up);
            down = B.Testb(player, down);
            ///moving
            if (right == true)
            {
                player.Left += 3;
            }
            if (left == true)
            {
                player.Left -= 3;
            }
            if (up == true)
            {
                player.Top -= 3;
            }
            if (down == true)
            {
                player.Top += 3;
            }
        }

        private async void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                index++;
                right = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                index++;
                left = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                index++;
                up = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                index++;
                down = true;
            }
            if (e.KeyCode == Keys.ControlKey)
            {
                if (ilosc_bomb > 0 ) //ograniczenie do bomb
                {
                    if (A.Tablica != null)
                    {
                        if (A.Tablica[ilosc_bomb - 1] == null)
                        {
                            ilosc_bomb = A.Bomba(player, ilosc_bomb, B); //stworzenie bomby
                        }
                    }
                    else
                    {
                        ilosc_bomb = A.Bomba(player, ilosc_bomb, B); //stworzenie bomby
                    }
                    if (A.Tablica != null && A.d > ilosc_bomb)
                    {
                        panel1.Controls.Add(A.Tablica[ilosc_bomb]); //wyświetlenie bomby
                        int bum = ilosc_bomb;
                        await Task.Delay(4000); //opóźnienie 4s
                        C[bum] = B.Bum(z, R, A.Tablica[bum]); //stworzenie płomienia
                        if (C[bum]==null)
                        {

                        }
                        else if (C[bum].d != 0 && C[bum].Tablica != null)
                        {
                            
                            R.Poprawa(B);
                            for (int i = 0; i < C[bum].d; i++)
                            {
                                if (C[bum].Tablica[i] != null && C[bum].Tablica[i].Name != "bomb" + i.ToString() && C[bum].Tablica[i].Name != "block" + i.ToString()) //wyświetlanie bomby
                                {
                                    C[bum].Tablica[i].Visible = true;
                                    panel1.Controls.Add(C[bum].Tablica[i]);
                                }
                            }
                            await Task.Delay(300); //czas wyświetlenia płomienia
                            for (int i = 0; i < C[bum].d; i++)
                            {
                                if (C[bum].Tablica[i] != null) //niszczenie bloczków
                                {
                                    C[bum].Tablica[i].Visible = false;
                                    C[bum].Tablica[i].Dispose();
                                    C[bum].Tablica[i] = null;
                                    
                                }
                            }
                            C[bum] = null;
                            A.Tablica[bum] = null;
                            ilosc_bomb++;
                        }
                    }
                }
            }
        }



        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                index = 0;
                right = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                index = 0;
                left = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                index = 0;
                up = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                index = 0;
                down = false;
            }
            if (e.KeyCode == Keys.ControlKey)
            {
            }
        }
    }
}
