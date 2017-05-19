using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gierka
{
    public partial class Form1 : Form
    {
        bool right;
        bool left;
        bool up;
        bool down;

        public Form1()
        {
            InitializeComponent();
             player.Top = screen.Bottom - player.Height-5;
             player.Left = screen.Left + 100;
        }
	PictureBox[] blocki= new PictureBox[6];

        private void timer1_Tick(object sender, EventArgs e)
        {

            ///// Side Collision



            blocki[0] = block1;
            blocki[1] = block2;
            blocki[2] = block3;
            blocki[3] = block4;
            blocki[4] = block5;
            blocki[5] = block6;
            for (int i=0;i<6;i++)
            {
                if (player.Right >= blocki[i].Left - 2 && player.Right < blocki[i].Right && player.Bottom > blocki[i].Top && player.Top < blocki[i].Bottom)
                {
                    player.Left = blocki[i].Left - (player.Right-player.Left);
                    right = false;
                    //  player.Left = player.Left-3;
                }
                if (player.Left <= blocki[i].Right + 2 && player.Left > blocki[i].Left && player.Bottom > blocki[i].Top && player.Top < blocki[i].Bottom)
                {
                    player.Left = blocki[i].Right;
                    left = false;
                    // player.Left = player.Left + 3;
                }
                /////Top Collision
                if (player.Top <= blocki[i].Bottom + 2 && player.Right > blocki[i].Left && player.Left < blocki[i].Right && player.Bottom < blocki[i].Bottom + 33 && player.Top > blocki[i].Top)
                {
                    player.Top = blocki[i].Bottom;
                    up = false;
                    //player.Top = player.Top + 3;
                }
                /// Bottom Collision
                if (player.Bottom >= blocki[i].Top - 2 && player.Right > blocki[i].Left && player.Left < blocki[i].Right && player.Top > blocki[i].Top - 33 && player.Bottom < blocki[i].Bottom)
                {
                    player.Top = blocki[i].Top - (player.Bottom-player.Top);
                    down = false;
                    //  player.Top = player.Top - 3;
                }
            } 

            
            /////// Walking
            if (right==true)
            {
                player.Left += 3;
            }
            if(left==true)
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
            ////////
         
            
           

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Right)
            {
                right = true;
            }
            if(e.KeyCode==Keys.Left)
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
        }

        
        


}
}
