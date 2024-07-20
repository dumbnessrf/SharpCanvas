using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using SharpCanvas;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SharpCanvas.MyCanvas _sharpCanvas;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _sharpCanvas.CV_DisplayCircle(new SharpCanvas.Shapes.Structure.Circle(50, 100, 100));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _sharpCanvas = new SharpCanvas.MyCanvas();
            elementHost1.Child = _sharpCanvas;
            _sharpCanvas.Loaded += (s, ee) =>
            {
                var path = @"D:\4个二维码.png";
                BitmapFrame image = BitmapFrame.Create(new Uri(path));

                _sharpCanvas.CV_DisplayImage(image);
            };
        }
    }
}
