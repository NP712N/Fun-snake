using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Rắn_Săn_Mồi
{
    class Food
    {
        int x, y, width, height;
        SolidBrush brush;
        public Rectangle foodR;

        public Food(Random randF)
        {
            x = randF.Next(0, 29) * 10;
            y = randF.Next(0, 29) * 10;
            brush = new SolidBrush(Color.DarkGoldenrod);
            width = height = 10;
            foodR = new Rectangle(x, y, width, height);           
        }

        public void foodLocation(Random randF)
        {
            x = randF.Next(0, 29) * 10;
            y = randF.Next(0, 29) * 10;
        }

        public void drawFood(Graphics paper)
        {
            foodR.X = x;
            foodR.Y = y;
            paper.FillEllipse(brush, foodR);
        }
    }
}
