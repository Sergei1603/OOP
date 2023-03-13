using System.Security.Cryptography.X509Certificates;

namespace ЛР4
{
    public partial class Form1 : Form
    {
        public class Ccircle
        {
            public int r = 10;
            public int x;
            public int y;
            public Ccircle(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public void paint_Ccircle(PaintEventArgs e)
            {
                e.Graphics.DrawEllipse(new Pen(System.Drawing.Color.Black), new Rectangle(x, y, r, r));
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_paint_Click(object sender, EventArgs e)
        {
            pict_box.Refresh();
        }

        private void pict_box_MouseClick(object sender, MouseEventArgs e)
        {
            Ccircle c = new Ccircle(e.X, e.Y);
           
        }

        private void pict_box_Paint(object sender, PaintEventArgs e)
        {
      //      e.Graphics.DrawEllipse(new Pen(System.Drawing.Color.Black), )
        }
    }
}