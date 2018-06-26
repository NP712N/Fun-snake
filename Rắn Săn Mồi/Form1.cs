    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rắn_Săn_Mồi
{
    public partial class Form1 : Form
    {
        int Score = 0;
        Random randF = new Random();
        Food food;
        Toxic toxic;

        public Form1()
        {
            InitializeComponent();
            food = new Food(randF);
            toxic = new Toxic(randF);
        }

        Graphics paper;
        Snake snake = new Snake();
        Boolean left = false, right = false, up = false, down = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelScore.Text = Score.ToString();
            if (down == true) { snake.moveDown(); }
            if (up == true) { snake.moveUp(); }
            if (left == true) { snake.moveLeft(); }
            if (right == true) { snake.moveRight(); }

            if (Score == 20)
            {
                Restart();
                MessageBox.Show("Code: YTCQ1-N8QFQ-DFQF7-78FQH-8HVX7");
            }
            for (int i = 0; i < snake.SnakeR.Length; i++)
            {
                if(Score>=19)
                {
                    toxic.toxicLocation(randF);
                }
                if (snake.SnakeR[i].IntersectsWith(food.foodR))
                {
                    Score++;
                    snake.growSnake();
                    food.foodLocation(randF);
                    if (timer1.Interval >= 10)
                        timer1.Interval -= 5    ;
                }
                if (snake.SnakeR[i].IntersectsWith(toxic.toxic))
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Bạn đã cắn nhầm bã");
                    Restart();
                }

            }
            collision();
            this.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData==Keys.Space)
            {                
                if (Score == 0) { timer1.Enabled = true; }
                else { timer1.Enabled = false; }
                left = right = up = down = false;
                label1.Text = "";
            }

            if (e.KeyData == Keys.Up && down == false)
            {
                up = true;
                down = false;
                left = false;
                right = false;
            }
            if (e.KeyData == Keys.Down && up == false)
            {
                up = false;
                down = true;
                left = false;
                right = false;
            }
            if (e.KeyData == Keys.Left && right == false)
            {
                up = false;
                down = false;
                left = true;
                right = false;
            }
            if (e.KeyData == Keys.Right && left == false)
            {
                up = false;
                down = false;
                left = false;
                right = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            food.drawFood(paper);
            toxic.drawToxic(paper);
            snake.drawSnake(paper);           
        }

        public void collision()
        {
            for(int i=1;i<snake.SnakeR.Length;i++)
            {
                if(snake.SnakeR[0].IntersectsWith(snake.SnakeR[i]))
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Tự cắn vào mông");
                    Restart();
                }

                if(snake.SnakeR[0].Y<0||snake.SnakeR[0].Y>290)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Đâm vào tường");
                    Restart();
                }

                if(snake.SnakeR[0].X<0||snake.SnakeR[0].X>290)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Đâm vào tường");
                    Restart();
                }
            }
        }

        void Restart()
        {
            timer1.Enabled = false;
            timer1.Interval = 100;
            label1.Text = "Bấm Space để bắt đầu chơi";
            toolStripStatusLabelScore.Text = "0";
            Score = 0;
            MessageBox.Show("Chết cmnr");
            snake = new Snake();
        }

       
    }
}
