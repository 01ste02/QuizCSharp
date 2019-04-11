using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Frågesport
{
    class SizeHelper
    {
        public int horizontalHeight;
        public int horizontalWidth;
        public int verticalHeight;
        public int verticalWidth;

        public int scoreHeight;
        public int scoreWidth;

        public SizeHelper()
        {

        }

        public void SizeWidth (int formWidth, int formHeight, int index, Label label)
        {
            int height = (int)(formHeight * 0.1);
            int width = (int)(formWidth / 5.5);
            horizontalHeight = height;
            horizontalWidth = width;

            int margin = 10;
            int individualWidth = width - 2 * margin;
            label.Width = individualWidth;
            label.Height = height;
            label.Location = new Point(index * width + margin + (int)(width * 0.5), label.Location.Y);

            label.Font = new Font("Stencil", 20);
        }

        public void SizeHeight (int formWidth, int formHeight, int index, Label label)
        {
            int margin = 10;
            int marginLeft = 10;
            int height = (formHeight - horizontalHeight - margin) / 5;
            int individualHeight = height - 2 * margin;
            verticalHeight = individualHeight;
            verticalWidth = (int)(horizontalWidth * 0.5) - 10;

            label.Width = (int)(horizontalWidth * 0.5) - 10;
            label.Height = individualHeight;
            label.Location = new Point(marginLeft, 14 + horizontalHeight + margin + index * height);
        }

        public void SizeCards (int verticalIndex, int horizontalIndex, Label label)
        {
            int margin = 10;
            int height = verticalHeight;
            int width = horizontalWidth - 2 * margin;

            label.Width = width;
            label.Height = height;
            label.Location = new Point(margin * 2 + verticalWidth + horizontalIndex * (width + 2 * margin), 14 + horizontalHeight + margin + verticalIndex * (height + 2 * margin));
        }

        public void SizeScoreGbx (int formWidth, int count, int teamNum, GroupBox gbx)
        {
            gbx.Width = (formWidth - 30) / count;
            gbx.Location = new Point((gbx.Width + 10) * teamNum + 10, 0);
        }

        public void SizeScoreLabels (int formWidth, int parentHeight, int count, Label lbl)
        {
            lbl.Width = formWidth - 4;
            lbl.Height = parentHeight - 32;
        }
    }
}
