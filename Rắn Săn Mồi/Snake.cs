using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Rắn_Săn_Mồi
{
    class Snake
    {
        private Rectangle[] snakeR;
        public Rectangle[] SnakeR
        {
            get
            {
                return snakeR;
            }
        }

        SolidBrush brush;
        int x, y, width, heigth;

        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        public Snake()
        {
            snakeR = new Rectangle[3]; 
            brush = new SolidBrush(Color.Cyan);
            x = 30;y = 0; width = heigth = 10;
            for(int i=0;i<snakeR.Length;i++)
            {
                snakeR[i] = new Rectangle(x, y, width, heigth);
                x -= 10;
            }   
        }

        /// <summary>
        /// vẽ rắn
        /// </summary>
        /// <param name="paper"></param>

        public void drawSnake(Graphics paper)
        {
            foreach(Rectangle rec in snakeR)
            {
                paper.FillEllipse(brush, rec);
            }
        }

        /// <summary>
        /// Vẽ rắn di chuyển
        /// </summary>
        public void drowSnakeRun()
        {
            for(int i=snakeR.Length-1;i>0;i--)
            {
                snakeR[i] = snakeR[i - 1];
            }
        }

        public void moveDown()
        {
            drowSnakeRun();
            snakeR[0].Y += 10;
        }
        public void moveUp()
        {
            drowSnakeRun();
            snakeR[0].Y -= 10;
        }

        public void moveRight()
        {
            drowSnakeRun();
            snakeR[0].X += 10;
        }
        public void moveLeft()
        {
            drowSnakeRun();
            snakeR[0].X -= 10;
        }

        public void growSnake()
        {
            List<Rectangle> rec = snakeR.ToList();
            rec.Add(new Rectangle(snakeR[snakeR.Length - 1].X, snakeR[snakeR.Length - 1].Y, width, heigth));
            snakeR = rec.ToArray();
        }
    }
}
