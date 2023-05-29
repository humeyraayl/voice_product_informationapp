using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace humeyrayıldız_project
{
    public class circularprogresbar: UserControl
    {
        //fields design
        float valueSize = 40;
        int borderSize = 15;
        Color middleCircleColor = Color.DarkBlue;
        Color outerCircleColor = Color.Transparent;

        //constructer
        public circularprogresbar()
        {
            DoubleBuffered = true;
        }

        //properties
        public float ValueSize
        {
            get { return valueSize; }
            set { valueSize = (value > 100) ? 100 : value; Invalidate(); }
        }
        public int BorderSize
        {
            get { return borderSize; }
            set { valueSize = (value > 20) ? 20 : value; Invalidate(); }
        }
        public Color MiddleCircleColor
        {
            get { return middleCircleColor; }
            set { middleCircleColor = ForeColor = value; Invalidate(); }

        }
        public Color OuterCircleColor
        {
            get { return outerCircleColor; }
            set { outerCircleColor = value; Invalidate(); }

        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen Backpen = new Pen(Color.White, BorderSize - 1);
            Pen pen = new Pen(middleCircleColor, BorderSize) { StartCap = LineCap.Round, EndCap = LineCap.Round };
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            graphics.FillPie(new SolidBrush(outerCircleColor), new Rectangle(10, 10, Width - 20, Height - 20), 0, 360);
            graphics.DrawArc(Backpen, new Rectangle(10, 10, Width - 20, Height - 20), -90, 360);
            graphics.DrawArc(pen, new Rectangle(10, 10, Width - 20, Height - 20), -90, (ValueSize / 100) * 360);

            //show value
            StringFormat stringFormat = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
            graphics.DrawString(valueSize + "%", Font, new SolidBrush(ForeColor), ClientRectangle, stringFormat);


            base.OnPaint(e);
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            Height = Width;
            base.OnSizeChanged(e);
        }
    }
}
