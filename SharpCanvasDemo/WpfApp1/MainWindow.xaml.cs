using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SharpCanvas;

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var path = @"D:\Image.bmp";
        BitmapFrame image = BitmapFrame.Create(new Uri(path));

        myCanvas.CV_DisplayImage(image);
        myCanvas.CV_DisplayCircle(new SharpCanvas.Shapes.Structure.Circle(50, 100, 100));
    }
}
