using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pointsss
{
    class Point : IComparable
    {
        //Поля класса, координаты точки
        public int X { get; protected set; }
        public int Y { get; protected set; }
        //Конструкторы
        public Point()
        {
            X = Y = 0;
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        //Методы
        public override string ToString()
        {
            return $"Точка:\nX = {X}\nY = {Y}";
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            Point point = obj as Point;
            if (point.X == X && point.Y == Y) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        //Операторы
        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1.Equals(p2));
        }
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
    }

    class ColoredPoint : Point
    {
        //Поле класса, цвет точки
        public string Color { get; protected set; }
        //Конструкторы
        public ColoredPoint()
        {
            Color = "black";
            X = Y = 0;
        }
        public ColoredPoint(int x, int y)
        {
            Color = "black";
            X = x;
            Y = y;
        }
        public ColoredPoint(string color, int x, int y)
        {
            Color = color;
            X = x;
            Y = y;
        }
        //Методы
        public override string ToString()
        {
            return $"Цветная точка:\nX = {X}\nY = {Y}\nColor {Color}";
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            ColoredPoint coloredpoint = obj as ColoredPoint;
            if (coloredpoint.X == X && coloredpoint.Y == Y && coloredpoint.Color == Color) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //Операторы
        public static bool operator ==(ColoredPoint p1, ColoredPoint p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(ColoredPoint p1, ColoredPoint p2)
        {
            return !(p1.Equals(p2));
        }
        public static ColoredPoint operator +(ColoredPoint p1, ColoredPoint p2)
        {
            return new ColoredPoint(p1.X + p2.X, p1.Y + p2.Y);
        }
    }

    class Line : Point
    {
        //Поля класса, доп., точки для линии
        public int X2 { get; protected set; }
        public int Y2 { get; protected set; }

        //Конструкторы
        public Line()
        {
            X = Y = X2 = Y2 = 0;
        }

        public Line(int x, int y, int x2, int y2)
        {
            X = x;
            Y = y;
            X2 = x2;
            Y2 = y2;
        }
        //Методы
        public override string ToString()
        {
            return $"Линия:\nX = {X}\tY = {Y}\nX2 = {X2}\tY2 = {Y2}";
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            Line line = obj as Line;
            if (line.X == X && line.Y == Y && line.X2 == X2 && line.Y2 == Y2) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //Операторы
        public static bool operator ==(Line p1, Line p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Line p1, Line p2)
        {
            return !(p1.Equals(p2));
        }
        public static Line operator +(Line l1, Line l2)
        {
            return new Line(l1.X + l2.X, l1.Y + l2.Y, l1.X2 + l2.X2, l1.Y2 + l2.Y2);
        }
    }

    class ColoredLine : Line
    {
        //Поле класса, цвет линии
        public string Color { get; protected set; }
        //Конструкторы
        public ColoredLine()
        {
            Color = "black";
            X = Y = X2 = Y2 = 0;
        }
        public ColoredLine(int x, int y, int x2, int y2)
        {
            X = x;
            Y = y;
            X2 = x2;
            Y2 = y2;
        }
        public ColoredLine(string color, int x, int y, int x2, int y2)
        {
            Color = color;
            X = x;
            Y = y;
            X2 = x2;
            Y2 = y2;
        }
        //Методы
        public override string ToString()
        {
            return $"Цветная линия:\nX = {X}\tY = {Y}\nX2 = {X2}\tY2 = {Y2}\nColor: {Color}";
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            ColoredLine coloredline = obj as ColoredLine;
            if (coloredline.X == X && coloredline.Y == Y && coloredline.X2 == X2 && coloredline.Y2 == Y2 && coloredline.Color == Color) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //Операторы
        public static bool operator ==(ColoredLine p1, ColoredLine p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(ColoredLine p1, ColoredLine p2)
        {
            return !(p1.Equals(p2));
        }
        public static ColoredLine operator +(ColoredLine l1, ColoredLine l2)
        {
            return new ColoredLine(l1.X + l2.X, l1.Y + l2.Y, l1.X2 + l2.X2, l1.Y2 + l2.Y2);
        }
    }
    class Polygons : Line
    {
        //Поле класса, массив обьектов точек и размерность
        private Point[] Coordinates;
        private int Dimension;
        //Конструкторы
        public Polygons()
        {
            Dimension = 3;
            Coordinates = new Point[Dimension];
            Coordinates[0] = new Point();
            Coordinates[1] = new Point();
            Coordinates[2] = new Point();
        }
        public Polygons(params Point[] coordinates)
        {
            Coordinates = new Point[coordinates.Length];
            for (int i = 0; i < coordinates.Length; i++)
                Coordinates[i] = coordinates[i];
            Dimension = Coordinates.Length;
        }
        //Методы
        public override string ToString()
        {
            string str = "Многоугольник:\n";
            for (int i = 0; i < Coordinates.Length; i++)
            {
                str += $"{i + 1}. " + Coordinates[i].ToString() + "\n\n";
            }
            return str;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            Polygons polygon = obj as Polygons;
            bool IsTrue = true;
            if (polygon.Dimension != Dimension)
                return false;
            for (int i = 0; i < polygon.Coordinates.Length; i++)
            {
                if (polygon.Coordinates[i].X != Coordinates[i].X && polygon.Coordinates[i].Y != Coordinates[i].Y) { IsTrue = false; break; }
            }
            return IsTrue;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //Операторы
        public static bool operator ==(Polygons p1, Polygons p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Polygons p1, Polygons p2)
        {
            return !(p1.Equals(p2));
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Простые точки:\n");
            Point p1 = new Point(7, 8);
            Point p2 = new Point(8, 7);
            Console.WriteLine("1) " + p1.ToString() + "\n");
            Console.WriteLine("2) " + p2.ToString() + "\n");

            Console.WriteLine("Цветные точки:\n");
            ColoredPoint cp1 = new ColoredPoint("red", 3, 4);
            ColoredPoint cp2 = new ColoredPoint("red", 3, 4);
            Console.WriteLine("1) " + cp1.ToString() + "\n");
            Console.WriteLine("2) " + cp2.ToString() + "\n");

            Console.WriteLine("Линии:\n");
            Line l1 = new Line();
            Line l2 = new Line(3, 4, 5, 6);
            Console.WriteLine("1) " + l1.ToString() + "\n");
            Console.WriteLine("2) " + l2.ToString() + "\n");

            Console.WriteLine("Цветные линии:\n");
            ColoredLine cl1 = new ColoredLine("blue", 4, 5, 6, 7);
            ColoredLine cl2 = new ColoredLine("blue", 4, 5, 6, 7);
            Console.WriteLine("1) " + cl1.ToString() + "\n");
            Console.WriteLine("2) " + cl2.ToString() + "\n");

            Console.WriteLine("Многоугольники:\n");
            Polygons pol1 = new Polygons();
            Polygons pol2 = new Polygons(p1, p2, new Point(3, 4));
            Console.WriteLine("1) " + pol1.ToString() + "\n");
            Console.Write("2) " + pol2.ToString());

            Console.ReadLine();
        }
    }
}