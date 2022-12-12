using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smooth_moving_picturebox
{
    public partial class Form1 : Form
    {
        int leftScore;
        int rightScore;
        bool moveRight, moveLeft, moveUp, moveDown;
        bool moveRight2, moveLeft2, moveUp2, moveDown2;
        
        int speed = 7;

        int bulletSpeed = 14;

        bool rightBullet = false;
        bool leftBullet = false;

        bool rightWinner = false;
        bool leftWinner = false;


        public Form1()
        {
            InitializeComponent();

            resetGame();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {

        }

        private void moveTimerEvent(object sender, EventArgs e)
        {
            // This is the right player
            if (moveLeft && pictureBox1.Left > 475)
            {
                pictureBox1.Left -= speed;
            }
            if (moveRight && pictureBox1.Left < 730)
            {
                pictureBox1.Left += speed;
            }
            if (moveUp && pictureBox1.Top > 0)
            {
                pictureBox1.Top -= speed;
            }
            if (moveDown && pictureBox1.Top < 382)
            {
                pictureBox1.Top += speed;
            }

            // This is the left player
            if (moveLeft2 && pictureBox2.Left > 1)
            {
                pictureBox2.Left -= speed;
            }
            if (moveRight2 && pictureBox2.Left < 257)
            {
                pictureBox2.Left += speed;
            }
            if (moveUp2 && pictureBox2.Top > 0)
            {
                pictureBox2.Top -= speed;
            }
            if (moveDown2 && pictureBox2.Top < 382)
            {
                pictureBox2.Top += speed;
            }
            // Score of Player Left
            leftTxtScore.Text = leftScore.ToString();
            // Socre of Player Right
            rightTxtScore.Text = rightScore.ToString();

            // leftBullet fire
            if (leftBullet == true)
            {
                pictureBox4.Left += bulletSpeed;
                if (pictureBox4.Left >= 768)
                {
                    leftBullet = false;
                    pictureBox4.Left = -100;
                }
            }
            // rightBullet fire
            if (rightBullet == true)
            {
                pictureBox3.Left -= bulletSpeed;
                if (pictureBox3.Left <= 0)
                {
                    rightBullet = false;
                    pictureBox3.Left = -100;
                }
            }
            //right
            if (pictureBox3.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                rightScore += 1;
                rightBullet = false;
                pictureBox3.Left = -100;
            }
            // left
            if (pictureBox4.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                leftScore += 1;
                leftBullet = false;
                pictureBox4.Left = -100;
            }
            // player left Wins
            if (leftScore > 20)
            {
                leftWinner = true;
                moveTimer.Stop();
                gameOver();           
            }
            // player right wins
            if (rightScore > 20)
            {
                rightWinner = true;
                moveTimer.Stop();
                gameOver();
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            // Player right
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = true;
            }

            // Player left
            if (e.KeyCode == Keys.A)
            {
                moveLeft2 = true;
            }
            if (e.KeyCode == Keys.D)
            {
                moveRight2 = true;
            }
            if (e.KeyCode == Keys.W)
            {
                moveUp2 = true;
            }
            if (e.KeyCode == Keys.S)
            {
                moveDown2 = true;
            }

            // Bullet Left
            if (e.KeyCode == Keys.Space)
            {
                if (leftBullet == false)
                {
                    pictureBox4 .Top = pictureBox2.Top + 15;
                    pictureBox4 .Left = pictureBox2.Left + 20;
                    leftBullet = true;
                }
            }
            // Bullet right
            if (e.KeyCode == Keys.L)
            {
                if (rightBullet == false)
                {
                    pictureBox3.Top = pictureBox1.Top + 15;
                    pictureBox3.Left = pictureBox1.Left + 20;
                    rightBullet = true;
                }
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            // Player right
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = false;
            }

            // Player left
            if (e.KeyCode == Keys.A)
            {
                moveLeft2 = false;
            }
            if (e.KeyCode == Keys.D)
            {
                moveRight2 = false;
            }
            if (e.KeyCode == Keys.W)
            {
                moveUp2 = false;
            }
            if (e.KeyCode == Keys.S)
            {
                moveDown2 = false;
            }
            // game resets
            if (e.KeyCode == Keys.R && (leftScore >= 20 || rightScore >= 20))
            {
                resetGame();
            }
        }

        private void resetGame()
        {
            moveTimer.Start();
            leftScore = 0;
            rightScore = 0;
            gameWinner.Text = "";
            gameWinner2.Text = "";
            restart.Text = "";
            restart1.Text = "";
            rightBullet = false;
            leftBullet = false;
            pictureBox3.Left = 1000;
            pictureBox4.Left = 1000;
        }

        private void gameOver()
        {
            // player lett wins
            if (leftWinner)
            {
                gameWinner.Text += "PLAYER LEFT WINS!!!";
                restart1.Text += "press R to restart";
            }
            // player right wins
            else if (rightWinner)
            {
                gameWinner2.Text += "PLAYER RIGHT WINS!!!";
                restart.Text += "press R to restart";
            }
        }
    }
}