using System;
namespace PoligonRegulat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int n; //number of corners
        Point center,topleftcorner;
        int size=300;
        double u;
        double currentangle = 0;
        Point[] points = new Point[37];

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                n = Convert.ToInt32(textBox1.Text);
                if (n >= 3 && n <= 20)
                {
                    u = 360 / Convert.ToDouble(n); //the size that the angle grows by
                    this.Refresh();
                }
                else
                {
                    MessageBox.Show("The input number is not valid. Please insert a value between 3 and 20!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("The input is not a number!");
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                currentangle = 0;
                Pen red = new Pen(Color.Red);
                Pen green = new Pen(Color.Green);
                e.Graphics.Clear(Color.White);

                topleftcorner = new Point((this.Width / 2) - 100, (this.Height / 2) - 100); //the starting point of the drawing
                center = new Point(topleftcorner.X + (size / 2), topleftcorner.Y + (size / 2)); //the center of the polygon/circle

                Rectangle rectangle = new Rectangle(topleftcorner.X, topleftcorner.Y, size, size);
                e.Graphics.DrawEllipse(red, rectangle); //drawing cicle

                for (int index = 1; index <= n; index++)
                {
                    double rad = Math.PI * currentangle / 180; //converting degrees to radians

                    double px = center.X + Math.Cos(rad) * (size / 2);
                    double py = center.Y + Math.Sin(rad) * (size / 2);

                    Rectangle point = new Rectangle(Convert.ToInt32(px), Convert.ToInt32(py), 2, 2);
                    e.Graphics.DrawEllipse(green, point); //drawing corner

                    currentangle += u;
                    points[index] = new Point(Convert.ToInt32(px), Convert.ToInt32(py)); //ading corner to array
                }

                for (int index = 1; index < n; index++) //drawing line between each of the corners
                {
                    for (int j = index + 1; j <= n; j++)
                    {
                        e.Graphics.DrawLine(red, points[index], points[j]);
                    }
                }
            }
            catch(Exception ex)
            {
                
            }
            
        }
    }
}
