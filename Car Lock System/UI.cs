using System;
using System.ComponentModel;
using System.Drawing;
using GTA.UI;

namespace Car_Lock_System
{
    class UI
    {
        public UI()
        {
            container = new ContainerElement(new PointF(100.0f, 50.0f), new SizeF(100.0f, 25.0f));
        }

        private ContainerElement container;

        public void displayText(String text)
        {
            container.Centered = true;
            TextElement textElement = new TextElement(text, new PointF(5.0f, 5.0f), 0.3f);
            container.Items.Add(textElement);
            container.ScaledDraw();
        }
    }
}
