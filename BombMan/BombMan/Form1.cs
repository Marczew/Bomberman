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
            ///colision
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
                right = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                up = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                down = true;
            }
            if (e.KeyCode == Keys.ControlKey)
            {
                if (ilosc_bomb > 0) //ograniczenie do bomb
                {
                    ilosc_bomb = A.Bomba(player, ilosc_bomb, B); //stworzenie bomby
                    if (A.Tablica != null && A.d > ilosc_bomb && ilosc_bomb >= 0)
                    {
                        panel1.Controls.Add(A.Tablica[ilosc_bomb]); //wyświetlenie bomby
                        C[ilosc_bomb] = B.Bum(z, R, A.Tablica[ilosc_bomb]); //stworzenie płomienia
                        if (C[ilosc_bomb].d != 0 && C[ilosc_bomb].Tablica != null)
                        {
                            await Task.Delay(4000);  //opóźnienie 4s
                            for (int i = 0; i < C[ilosc_bomb].d; i++)
                            {
                                if (C[ilosc_bomb].Tablica[i] != null) //wyświetlanie bomby
                                {
                                    C[ilosc_bomb].Tablica[i].Visible = true;
                                    if (C[ilosc_bomb].Tablica[i].Name != "bomb" + i.ToString()) panel1.Controls.Add(C[ilosc_bomb].Tablica[i]);
                                }
                            }
                            await Task.Delay(300); //czas wyświetlenia płomienia
                            for (int i = 0; i < C[ilosc_bomb].d; i++)
                            {
                                if (C[ilosc_bomb].Tablica[i] != null) //niszczenie bloczków
                                {
                                    C[ilosc_bomb].Tablica[i].Visible = false;
                                    C[ilosc_bomb].Tablica[i].Dispose();
                                    C[ilosc_bomb].Tablica[i] = null;
                                    R.Poprawa(B);
                                }
                            }
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
                right = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                up = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                down = false;
            }
            if (e.KeyCode == Keys.ControlKey)
            {
            }
        }
    }
}
