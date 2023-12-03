using System;
using System.Collections.Generic;

// Абстрактний клас для графічних примітивів
public abstract class GraphicPrimitive
{
    public int X { get; set; }
    public int Y { get; set; }

    public abstract void Draw();

    public virtual void Move(int deltaX, int deltaY)
    {
        X += deltaX;
        Y += deltaY;
    }
}

// Клас кола
public class Circle : GraphicPrimitive
{
    public int Radius { get; set; }

    public Circle(int x, int y, int radius)
    {
        X = x;
        Y = y;
        Radius = radius;
    }

    public override void Draw()
    {
        Console.WriteLine($"Circle at ({X}, {Y}) with radius {Radius}");
    }
}

// Клас прямокутника
public class Rectangle : GraphicPrimitive
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public override void Draw()
    {
        Console.WriteLine($"Rectangle at ({X}, {Y}) with width {Width} and height {Height}");
    }
}

// Клас трикутника
public class Triangle : GraphicPrimitive
{
    public override void Draw()
    {
        Console.WriteLine($"Triangle at ({X}, {Y})");
    }
}

// Клас групи примітивів
public class Group : GraphicPrimitive
{
    private List<GraphicPrimitive> primitives = new List<GraphicPrimitive>();

    public Group(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    public override void Draw()
    {
        Console.WriteLine("Group:");
        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }

    public void MoveGroup(int deltaX, int deltaY)
    {
        foreach (var primitive in primitives)
        {
            primitive.Move(deltaX, deltaY);
        }
    }
}

// Клас редактора графіки
public class GraphicsEditor
{
    private List<GraphicPrimitive> primitives = new List<GraphicPrimitive>();

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    public void DrawAll()
    {
        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }

    public void ScaleAll(float factor)
    {
        foreach (var primitive in primitives)
        {
            if (primitive is Circle)
            {
                Circle circle = (Circle)primitive;
                circle.Radius = (int)(circle.Radius * factor);
            }
            else if (primitive is Rectangle)
            {
                Rectangle rectangle = (Rectangle)primitive;
                rectangle.Width = (int)(rectangle.Width * factor);
                rectangle.Height = (int)(rectangle.Height * factor);
            }
            // Додайте інші перевірки та операції для інших типів примітивів
        }
    }

    public static void Main()
    {
        GraphicsEditor editor = new GraphicsEditor();

        Circle circle = new Circle(10, 20, 30);
        Rectangle rectangle = new Rectangle(40, 50, 60, 70);
        Triangle triangle = new Triangle { X = 80, Y = 90 };

        Group group = new Group(100, 100);
        group.AddPrimitive(circle);
        group.AddPrimitive(rectangle);

        editor.AddPrimitive(circle);
        editor.AddPrimitive(rectangle);
        editor.AddPrimitive(triangle);
        editor.AddPrimitive(group);

        editor.DrawAll();

        // Масштабування всіх примітивів
        editor.ScaleAll(0.5f);

        Console.WriteLine("Після масштабування:");
        editor.DrawAll();
    }
}
