using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Rắn_Săn_Mồi
{
    class Toxic
    {
        int x2, y2, width2, height2;
        SolidBrush brush2;
        public Rectangle toxic;

        public Toxic(Random randT)
        {
            x2 = randT.Next(0, 29) * 10;
            y2 = randT.Next(0, 29) * 10;
            brush2 = new SolidBrush(Color.Purple);
            width2 = height2 = 10;
            toxic = new Rectangle(x2, y2, width2, height2);
        }

        public void toxicLocation(Random randT)
        {
            x2 = randT.Next(0, 29) * 10;
            y2 = randT.Next(0, 29) * 10;
        }

        public void drawToxic(Graphics paper)
        {
            toxic.X = x2;
            toxic.Y = y2;
            paper.FillEllipse(brush2, toxic);
        }

    }
}
