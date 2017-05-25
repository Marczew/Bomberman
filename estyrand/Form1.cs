using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estyrand
{
    public partial class Form1 : Form
    {
        bool right;
        bool left;
        bool up;
        bool down;
        Plan R;
        Blok B,A=new Blok();
        int ilosc_bomb = 1;
        int z = 2;
        public Form1()
        {
            R = new Plan()
            {
                N = 0, ///bloczki do niszczenia
                P = 2   ///potwory
            };
            R.Plano();
            B = new Blok();
            B.Bloczki(R);
            for (int i = 0; i < B.d; i++)
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
            right = B.Testr(player,right);
            left = B.Testl(player,left);
            up = B.Testt(player,up);
            down = B.Testb(player,down);
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
                int ib=ilosc_bomb;
                if(ib!=0) ib = A.Bomba(player, ib,B);
                if(A.Tablica!=null && A.d>ib && ib<ilosc_bomb)
                {
                    if(A.Tablica[ib]!=null) panel1.Controls.Add(A.Tablica[ib]);
                    Blok C = new Blok();
                    C = B.Bum(z, R, A.Tablica[ib]);
                    if (C.d != 0 && C.Tablica != null)
                    {
                        await Task.Delay(4000);
                        for (int i = 0; i < C.d - 1; i++)
                        {
                            if(C.Tablica[i]!=null)
                            {
                                C.Tablica[i].Visible = true;
                                panel1.Controls.Add(C.Tablica[i]);
                            }
                        }
                        await Task.Delay(300);
                        for (int i = 0; i < C.d; i++)
                        {
                            if (C.Tablica[i] != null)
                            {
                                C.Tablica[i].Visible = false;
                                C.Tablica[i].Dispose();
                            }
                        }
                        if (ib < ilosc_bomb) ib++;
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
