# SharpCanvas

**SharpCanvas** is a lightweight and easy-to-use WPF control for drawing and rendering 2D graphics. 
It provides a simple and intuitive API for drawing shapes, text, and images, 
and supports a wide range of drawing options such as fill, stroke, and shadow.

Also supports interactivity, including mouse and touch input for editing shapes;
Zooming, panning, and selection is also supported for interactive editing.

Finally, you can export the drawn graphics as a bitmap in any size, 
and the shapes in canvas would be preserved and keep ratio.

<!--TOC-->
  - [Shapes](#shapes)
    - [Shape Structures](#shape-structures)
      - [Circle](#circle)
      - [Ellipse](#ellipse)
      - [Line](#line)
      - [Polygon](#polygon)
      - [Cross](#cross)
      - [Rectangle1D](#rectangle1d)
      - [Rectangle2D with angle](#rectangle2d-with-angle)
      - [Text](#text)
      - [Image](#image)
  - [Interfaces Oveview](#interfaces-oveview)
  - [Usage](#usage)
    - [Create a Canvas](#create-a-canvas)
    - [Configurations](#configurations)
    - [Display Shapes](#display-shapes)
      - [Circle](#circle)
      - [Ellipse](#ellipse)
      - [Line](#line)
      - [Polygon](#polygon)
      - [Cross](#cross)
      - [Rectangle1D](#rectangle1d)
      - [Rectangle2D](#rectangle2d)
      - [Text](#text)
      - [Image](#image)
    - [Attach Shapes(Interactivity)](#attach-shapesinteractivity)
    - [Detach Shapes](#detach-shapes)
    - [Get Attach Structure](#get-attach-structure)
    - [Clear Shapes](#clear-shapes)
    - [Clear Canvas](#clear-canvas)
    - [Dump to Bitmap](#dump-to-bitmap)
  - [Quick Start](#quick-start)
<!--/TOC-->

## Shapes
- `Circle`
- `Ellipse` with angle
- `Line` define by start and end point
- `Polygon` define by points
- `Cross` define by single point
- `Rectangle1D`
- `Rectangle2D` with angle
- `Text`
- `Image`

### Shape Structures
#### Circle
```csharp
public record Circle : IShapeStructure
{
    public double Radius;
    public double CenterX;
    public double CenterY;
}
```
#### Ellipse
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
#### Line
```csharp
public record Line : IShapeStructure
{
    public double X1;
    public double Y1;
    public double X2;
    public double Y2;
}
```
#### Polygon
```csharp
public record Polygon : IShapeStructure
{
    public List<Point> Points;
    public bool IsClosed;
}
```
#### Cross
```csharp
public record Cross : IShapeStructure
{
    public double Size;
    public Point Center;
    public double AngleDegree;
}
```
#### Rectangle1D
```csharp
public record Rectangle1D : IShapeStructure
{
    public double Width;
    public double Height;
    public double X;
    public double Y;
}
```
#### Rectangle2D with angle
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
#### Text
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
#### Image
`BitmapFrame` is used to represent the image.

## Interfaces Oveview
```csharp
public interface ICVCanvas
{
    //--------------------------------Display----------------------------
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

    //------------------------------Attachments------------------------------
    void CV_AttachRectangle1DToCanvas(string name, Rectangle1D rectangle1D);
    void CV_AttachRectangle2DToCanvas(string name, Rectangle2D rectangle2D);
    void CV_AttachCrossToCanvas(string name, Cross cross);
    void CV_AttachCircleToCanvas(string name, Circle circle);
    void CV_AttachEllipseToCanvas(string name, Structure.Ellipse ellipse);
    void CV_AttachLineToCanvas(string name, Structure.Line line);
    void CV_AttachPolygonToCanvas(string name, Structure.Polygon polygon);

    //----------Operations----------
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

## Usage
### Create a Canvas
```xml
<sharpCanvas:MyCanvas x:Name="myCanvas"  ClipToBounds="True"
xmlns:sharpCanvas="clr-namespace:SharpCanvas;assembly=SharpCanvas"/>
```
### Configurations
```csharp
//adjust the fill of the shapes displayed
myCanvas.CV_SetFillColor(Brushes.Yellow, 30);
//adjust the stroke of the shapes displayed
myCanvas.CV_SetStrokeColor(Brushes.Red, 1);
//adjust the size of the thumb for editing shapes
myCanvas.CV_SetThumbSize(10);
```
### Display Shapes
#### Circle
```csharp
myCanvas.CV_DisplayCircle(new(100, 200, 200));
```
#### Ellipse
```csharp
myCanvas.CV_DisplayEllipse(new(100, 50, 200, 200));
```
#### Line
```csharp
myCanvas.CV_DisplayLine(new(100, 100, 200, 200));
```
#### Polygon
```csharp
// draw heart shape
var points = new List<Point>();
int numPoints = 50;
double scale = 10; // adjust the size of the heart

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
#### Cross
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
#### Rectangle1D
```csharp
var rect = new Rectangle1D(100, 100, 200, 200);
myCanvas.CV_DisplayRectangle1D(rect);
```
#### Rectangle2D
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
#### Text
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
#### Image
```csharp
var path = @"D:\Image.bmp";
BitmapFrame image = BitmapFrame.Create(new Uri(path));
myCanvas.CV_DisplayImage(image);
```
### Attach Shapes(Interactivity)
```csharp
//attach a rectangle to the canvas
myCanvas.CV_AttachRectangle1DToCanvas("rect1", new Rectangle1D(100, 100, 200, 200));
//attach a circle to the canvas
myCanvas.CV_AttachCircleToCanvas("circle1", new Circle(100, 100, 50));
```
Attach a start with polygon to the canvas
![Star](./Documents/images/Snipaste_2024-07-19_17-42-10.png "Star")
Attach a 45бу ellipse to the canvas
![45бу Ellipse](./Documents/images/Snipaste_2024-07-19_17-41-37.png "45бу Ellipse")
### Detach Shapes
```csharp
myCanvas.CV_Detach("rect1");
myCanvas.CV_Detach("circle1");
```
### Get Attach Structure
```csharp
var rect = myCanvas.CV_GetAttachStruture<Rectangle1D>("rect1");
var circle = myCanvas.CV_GetAttachStruture<Circle>("circle1");
```
### Clear Shapes
**Note:** This will not clear the image displayed on the canvas.
```csharp
myCanvas.CV_ClearShapes();
```
### Clear Canvas
**Note:** This will clear all the shapes and the image displayed on the canvas.
```csharp
myCanvas.CV_Clear();
```

### Dump to Bitmap
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

## Quick Start
1. Create a new WPF project in Visual Studio.
2. Add a reference to the SharpCanvas library.
3. Add a Canvas control to your XAML file.
4. Add the following code to your XAML file:
```xml
<sharpCanvas:MyCanvas x:Name="myCanvas"  ClipToBounds="True"
xmlns:sharpCanvas="clr-namespace:SharpCanvas;assembly=SharpCanvas"/>
```
5. Add the following code to your code-behind file:
```csharp
//draw a circle
myCanvas.CV_DisplayCircle(new(100, 200, 200));
```
6. Run the application.