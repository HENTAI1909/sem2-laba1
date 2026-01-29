// вар 66 стр 67
Console.Write("Введите первый катет прямоугольного треугольника: ");
double cat1 = double.Parse(Console.ReadLine()!);
Console.Write("Введите второй катет прямоугольного треугольника: ");
double cat2 = double.Parse(Console.ReadLine()!);
RightTriangle rt = new RightTriangle(cat1, cat2);
Console.WriteLine(rt);
Console.Write("\nВведите боковую сторону равнобедренного треугольника: ");
double side = double.Parse(Console.ReadLine()!);
Console.Write("Введите угол при вершине (в градусах): ");
double angle = double.Parse(Console.ReadLine()!);
IsoscelesTriangle it = new IsoscelesTriangle(side, angle);
Console.WriteLine(it);
Console.Write("\nВведите сторону равностороннего треугольника: ");
double eqSide = double.Parse(Console.ReadLine()!);
EquilateralTriangle et = new EquilateralTriangle(eqSide);
Console.WriteLine(et);
abstract class Triangle
{
    protected double a, b, angle;
    protected Triangle(double s1, double s2, double ang)
    {
        a = s1;
        b = s2;
        angle = ang * Math.PI / 180;
    }
    public abstract double GetArea();
    public abstract double GetPerimeter();

    public override string ToString()
    {
        return $"Треугольник: площадь = {GetArea():F2}, периметр = {GetPerimeter():F2}";
    }
}
class RightTriangle : Triangle
{
    public RightTriangle(double cat1, double cat2) : base(cat1, cat2, 90) { }
    public override double GetArea() => a * b / 2;
    public override double GetPerimeter()
    {
        double c = Math.Sqrt(a * a + b * b);
        return a + b + c;
    }
    public override string ToString()
    {
        return $"Прямоугольный треугольник: площадь = {GetArea():F2}, периметр = {GetPerimeter():F2}";
    }
}
class IsoscelesTriangle : Triangle
{
    public IsoscelesTriangle(double side, double angleDeg) : base(side, side, angleDeg) { }
    public override double GetArea() => 0.5 * a * b * Math.Sin(angle);
    public override double GetPerimeter()
    {
        double c = Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(angle));
        return a + b + c;
    }
    public override string ToString()
    {
        return $"Равнобедренный треугольник: площадь = {GetArea():F2}, периметр = {GetPerimeter():F2}";
    }
}
class EquilateralTriangle : Triangle
{
    public EquilateralTriangle(double side) : base(side, side, 60) { }
    public override double GetArea() => Math.Sqrt(3) / 4 * a * a;
    public override double GetPerimeter() => 3 * a;
    public override string ToString()
    {
        return $"Равносторонний треугольник: площадь = {GetArea():F2}, периметр = {GetPerimeter():F2}";
    }
}
