using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace Frågesport
{
    class FontHelper
    {
        public FontHelper()
        {
            
        }

        public int FontSize (Label[] categoryLabels, string fontName, int width, int height, Graphics g)
        {
            int longestLength = -1;
            int longestIndex = -1;

            for (int i = 0; i < categoryLabels.Length; i++)
            {
                if (categoryLabels[i].Text.Length > longestLength)
                {
                    longestLength = categoryLabels[i].Text.Length;
                    longestIndex = i;
                }
            }
            SizeF size = new SizeF(width, height);
            int fontSize = 100;
            int fittedChars = 0;
            int linesFilled = 0;

            while (fittedChars < categoryLabels[longestIndex].Text.Length || linesFilled > 1)
            {
                g.MeasureString(categoryLabels[longestIndex].Text, new Font(fontName, fontSize), size, StringFormat.GenericDefault, out fittedChars, out linesFilled);
                fontSize -= 3;
            }

            return fontSize;
        }

        public int FontSizeString (string text, string fontName, int width, int height, Graphics g)
        {
            SizeF size = new SizeF(width, height);
            int fontSize = 100;
            int fittedChars = 0;
            int linesFilled = 0;

            while (fittedChars < text.Length || linesFilled > 1)
            {
                g.MeasureString(text, new Font(fontName, fontSize), size, StringFormat.GenericDefault, out fittedChars, out linesFilled);
                fontSize -= 1;
            }

            return fontSize;
        }

        public void SetFont (string fontName, int fontSize, Label label)
        {
            label.Font = new Font(fontName, fontSize);
        }
    }
}
