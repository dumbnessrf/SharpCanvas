# SharpCanvas

**SharpCanvas** ��һ��������������ʹ�õ� WPF �ؼ������ڻ��ƺ���Ⱦ 2D ͼ�Ρ�
���ṩ��һ����ֱ�۵� API ��������״���ı���ͼ��
��֧�ֹ㷺�Ļ�ͼѡ�����䡢��ߺ���Ӱ��

��֧�ֽ����ԣ��������ڱ༭��״�����ʹ������룻
���š�ƽ�ƺ�ѡ��Ҳ֧�ֽ���ʽ�༭��

��������Խ����Ƶ�ͼ�ε���Ϊ�����С��λͼ��
�����е���״�������������ֱ�����

<!--TOC-->
  - [��״](#shapes)
    - [��״�ṹ](#shape-structures)
      - [Բ��](#circle)
      - [��Բ](#ellipse)
      - [����](#line)
      - [�����](#polygon)
      - [ʮ��](#cross)
      - [һά����](#rectangle1d)
      - [��ά���δ��Ƕ�](#rectangle2d-with-angle)
      - [�ı�](#text)
      - [ͼ��](#image)
  - [�ӿڸ���](#interfaces-oveview)
  - [�÷�](#usage)
    - [��������](#create-a-canvas)
    - [����](#configurations)
    - [��ʾ��״](#display-shapes)
      - [Բ��](#circle)
      - [��Բ](#ellipse)
      - [����](#line)
      - [�����](#polygon)
      - [ʮ��](#cross)
      - [һά����](#rectangle1d)
      - [��ά����](#rectangle2d)
      - [�ı�](#text)
      - [ͼ��](#image)
    - [������״�������ԣ�](#attach-shapesinteractivity)
    - [������״](#detach-shapes)
    - [��ȡ���ӽṹ](#get-attach-structure)
    - [�����״](#clear-shapes)
    - [�������](#clear-canvas)
    - [����Ϊλͼ](#dump-to-bitmap)
  - [���ٿ�ʼ](#quick-start)
<!--/TOC-->

## ��״
- `Բ��`
- `��Բ`���Ƕ�
- `����`�������յ㶨��
- `�����`�ɵ㶨��
- `ʮ��`�ɵ��㶨��
- `һά����`
- `��ά����`���Ƕ�
- `�ı�`
- `ͼ��`

### ��״�ṹ
#### Բ��
```csharp
public record Circle : IShapeStructure
{
    public double Radius;
    public double CenterX;
    public double CenterY;
}

#### ��Բ
```csharp
public record Ellipse : IShapeStructure
{
    public double RadiusX;
    public double RadiusY;
    public double CenterX;
    public double CenterY;
    public double RotationDegree;
}
```


#### ����
```csharp
public record Line : IShapeStructure
{
    public double X1;
    public double Y1;
    public double X2;
    public double Y2;
}
```

#### �����
```csharp
public record Polygon : IShapeStructure
{
    public List<Point> Points;
    public bool IsClosed;
}
```

#### ʮ��
```csharp
public record Cross : IShapeStructure
{
    public double Size;
    public Point Center;
    public double AngleDegree;
}
```

#### һά����
```csharp
public record Rectangle1D : IShapeStructure
{
    public double Width;
    public double Height;
    public double X;
    public double Y;
}
```

#### ��ά���δ��Ƕ�
```csharp
public record Rectangle2D : IShapeStructure
{
    public double HalfWidth;
    public double HalfHeight;
    public double CenterX;
    public double CenterY;
    public double AngleDegree;
}
```

#### �ı�
```csharp
public record Text : IShapeStructure
{
    public string _Text;
    public double X;
    public double Y;
    public SolidColorBrush Brush = null;
    public double FontSize = 16;
}
```

#### ͼ��
`BitmapFrame` ���ڱ�ʾͼ��

## �ӿڸ���
```csharp
public interface ICVCanvas
{
    //--------------------------------��ʾ----------------------------
    void CV_DisplayImage(
        BitmapFrame image,
        double x = 0,
        double y = 0,
        double width = 0,
        double height = 0,
        double canvasW = 0,
        double canvasH = 0
    );
    void CV_DisplayRectangle1D(Rectangle1D rectangle1D, double canvasW = 0, double canvasH = 0);
    void CV_DisplayRectangle1Ds(
        List<Rectangle1D> rectangle1D,
        double canvasW = 0,
        double canvasH = 0
    );
    void CV_DisplayRectangle2D(Rectangle2D rectangle2D, double canvasW = 0, double canvasH = 0);
    void CV_DisplayRectangle2Ds(
        List<Rectangle2D> rectangle2D,
        double canvasW = 0,
        double canvasH = 0
    );
    void CV_DisplayCircle(Circle circle, double canvasW = 0, double canvasH = 0);
    void CV_DisplayCircles(List<Circle> circles, double canvasW = 0, double canvasH = 0);
    void CV_DisplayEllipse(Structure.Ellipse ellipse, double canvasW = 0, double canvasH = 0);
    void CV_DisplayEllipses(
        List<Structure.Ellipse> ellipses,
        double canvasW = 0,
        double canvasH = 0
    );
    void CV_DisplayCross(Cross cross, double canvasW = 0, double canvasH = 0);
    void CV_DisplayCrosses(List<Cross> crosses, double canvasW = 0, double canvasH = 0);
    void CV_DisplayLine(Structure.Line line, double canvasW = 0, double canvasH = 0);
    void CV_DisplayLines(List<Structure.Line> lines, double canvasW = 0, double canvasH = 0);
    void CV_DisplayText(Text text, double canvasW = 0, double canvasH = 0);
    void CV_DisplayPolygon(
        Structure.Polygon polygon,
        bool isClosed = true,
        double canvasW = 0,
        double canvasH = 0
    );
    void CV_DisplayPolygons(
        List<Structure.Polygon> polygons,
        bool isClosed = true,
        double canvasW = 0,
        double canvasH = 0
    );

    //------------------------------����------------------------------
    void CV_AttachRectangle1DToCanvas(string name, Rectangle1D rectangle1D);
    void CV_AttachRectangle2DToCanvas(string name, Rectangle2D rectangle2D);
    void CV_AttachCrossToCanvas(string name, Cross cross);
    void CV_AttachCircleToCanvas(string name, Circle circle);
    void CV_AttachEllipseToCanvas(string name, Structure.Ellipse ellipse);
    void CV_AttachLineToCanvas(string name, Structure.Line line);
    void CV_AttachPolygonToCanvas(string name, Structure.Polygon polygon);

    //----------����----------
    void CV_FitImageToCanvas(double canvasW = 0, double canvasH = 0);
    T CV_GetAttachStruture<T>(string name)
        where T : IShapeStructure;
    void CV_Detach(string name);
    void CV_SetStrokeColor(Brush brush, double thickness, int opacity = 100);
    void CV_SetFillColor(Brush brush, int opacity = 100);
    Task<BitmapFrame> CV_Dump(int width = 0, int height = 0);
    void CV_ClearShapes();
    void CV_Clear();
    void CV_SetThumbSize(int size);
}
```

## �÷�
### ��������
```xml
<sharpCanvas:MyCanvas x:Name="myCanvas"  ClipToBounds="True"
xmlns:sharpCanvas="clr-namespace:SharpCanvas;assembly=SharpCanvas"/>
```

### ����
```csharp
//������ʾ��״�����
myCanvas.CV_SetFillColor(Brushes.Yellow, 30);
//������ʾ��״�����
myCanvas.CV_SetStrokeColor(Brushes.Red, 1);
//�����༭��״������ͼ��С
myCanvas.CV_SetThumbSize(10);
```


### ��ʾ��״
#### Բ��
```csharp
myCanvas.CV_DisplayCircle(new(100, 200, 200));
```

#### ��Բ
```csharp
myCanvas.CV_DisplayEllipse(new(100, 50, 200, 200));
```

#### ����
```csharp
myCanvas.CV_DisplayLine(new(100, 100, 200, 200));
```

#### �����
```csharp
// ��������
var points = new List<Point>();
int numPoints = 50;
double scale = 10; // �������εĴ�С

for (int i = 0; i < numPoints; i++)
{
    double t = 2 * Math.PI * i / numPoints;
    double x = scale * (16 * Math.Pow(Math.Sin(t), 3));
    double y =
        -scale
        * (13 * Math.Cos(t) - 5 * Math.Cos(2 * t) - 2 * Math.Cos(3 * t) - Math.Cos(4 * t));
    points.Add(new Point(x, y));
}
myCanvas.CV_SetFillColor(Brushes.Pink, 70);
myCanvas.CV_DisplayPolygon(
    new SharpCanvas.Shapes.Structure.Polygon(points.Translate(300, 300), false)
);
```

#### ʮ��
```csharp
var height = this.myCanvas.m_currentImage.PixelHeight;
var width = this.myCanvas.m_currentImage.PixelWidth;
var random = new Random();
var crosses = new List<Point>();
this.myCanvas.CV_SetStrokeColor(Brushes.Red, 1);
for (int i = 0; i < 5000; i++)
{
    var x = random.Next(0, (int)width);
    var y = random.Next(0, (int)height);
    crosses.Add(new Point(x, y));
}
List<Cross> crosses1 = crosses.Select(p => new Cross(p, 45, 5)).ToList();
var sw = Stopwatch.StartNew();
this.myCanvas.CV_DisplayCrosses(crosses1);
sw.Stop();
```

#### һά����
```csharp
var rect = new Rectangle1D(100, 100, 200, 200);
myCanvas.CV_DisplayRectangle1D(rect);
```

#### ��ά����
```csharp
var rd = new Random();
var rects = new List<Rectangle2D>();
for (int i = 0; i < 10000; i++)
{
    var rect = new Rectangle2D(
        100,
        100,
        rd.Next(100, myCanvas.m_currentImage.PixelWidth - 100),
        rd.Next(100, myCanvas.m_currentImage.PixelHeight - 100),
        45
    );
    rects.Add(rect);
}

var sw = Stopwatch.StartNew();

for (int i = 0; i < 10000; i++)
{
    myCanvas.CV_DisplayRectangle2D(rects[i]);
}

sw.Stop();
```


#### �ı�
```csharp
myCanvas.CV_DisplayText(
    new Text(
        "Visiter the on more on the mefilled dream this agreeing the vainly velvet raven front smiling the soul prophet the",
        12,
        12,
        Brushes.Blue,
        16
    )
);
```

#### ͼ��
```csharp
var path = @"D:\Image.bmp";
BitmapFrame image = BitmapFrame.Create(new Uri(path));
myCanvas.CV_DisplayImage(image);
```

### ������״�������ԣ�
```csharp
//����һ�����ε�����
myCanvas.CV_AttachRectangle1DToCanvas("rect1", new Rectangle1D(100, 100, 200, 200));
//����һ��Բ�ε�����
myCanvas.CV_AttachCircleToCanvas("circle1", new Circle(100, 100, 50));
```
����һ��������ε����ε�����

![](./Documents/images/Snipaste_2024-07-19_17-42-10.png)

����һ��45�����Բ������

![](./Documents/images/Snipaste_2024-07-19_17-41-37.png)

### ȥ����״
```csharp
myCanvas.CV_Detach("rect1");
myCanvas.CV_Detach("circle1");
```

### ��ȡ���ӽṹ
```csharp
var rect1 = myCanvas.CV_GetAttachStruture<Rectangle1D>("rect1");
var circle1 = myCanvas.CV_GetAttachStruture<Circle>("circle1");
```

### �����״
**ע��**�� �ⲻ�������������ʾ��ͼ��
```csharp
myCanvas.CV_ClearShapes();
```

### �������
**ע��**�� �⽫�����������ʾ��������״��ͼ��
```csharp
myCanvas.CV_Clear();
```

### ����Ϊλͼ
```csharp
var path = SaveFileDialog(false, "jpg");
if (string.IsNullOrEmpty(path))
{
    return;
}
var bmp = myCanvas.CV_Dump(3000, 3000).GetAwaiter().GetResult();
JpegBitmapEncoder encoder = new JpegBitmapEncoder();
encoder.Frames.Add(bmp);
using var fs = new FileStream(path, FileMode.Create);
encoder.Save(fs);
```

## ���ٿ�ʼ
1. �� Visual Studio �д���һ���µ� WPF ��Ŀ��
2. ��Ӷ� SharpCanvas ������á�
3. ������ XAML �ļ������һ�� Canvas �ؼ���
4. ������ XAML �ļ���������´��룺
```xml
<sharpCanvas:MyCanvas x:Name="myCanvas"  ClipToBounds="True"
xmlns:sharpCanvas="clr-namespace:SharpCanvas;assembly=SharpCanvas"/>
```
5. ������Designer.cs�ļ���������´��룺
```csharp
//����һ��Բ��
myCanvas.CV_DisplayCircle(new(100, 200, 200));
```
6. ����������Ŀ�����鿴Բ���Ƿ���ʾ�ڻ����ϡ�