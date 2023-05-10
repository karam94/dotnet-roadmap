namespace Classes;

public static class Program
{
    private static void Main()
    {
        Animal myDog = new Dog("Rufus");
        myDog.Speak();

        var result = Calculator.Multiply(3, 5);
        Console.WriteLine($"3 multiplied by 5 is {result}");

        var sum = Calculator.Add(1, 2, 3);
        Console.WriteLine($"1 + 2 + 3 = {sum}");

        var hypotenuse = Calculator.CalculateHypotenuse(10, 2);
        Console.WriteLine(
            $"The hypotenuse of a right angled triangle with one side 10cm & the other 2cm is {hypotenuse}");
    }
}

public abstract class Animal
{
    protected readonly string Name;

    protected Animal(string name)
    {
        Name = name;
    }

    public abstract void Speak();
}

public class Dog : Animal
{
    public Dog(string name) : base(name)
    {
    }

    public override void Speak()
    {
        Console.WriteLine($"{Name} says woof!");
    }
}

public class Cat : Animal
{
    public Cat(string name) : base(name)
    {
    }

    public override void Speak()
    {
        Console.WriteLine($"{Name} says meow!");
    }
}

public static class Calculator
{
    public static int Multiply(int x, int y) => x * y;
    public static int Add(params int[] numbers) => numbers.Sum();

    public static int CalculateHypotenuse(int a, int b)
    {
        static int Square(int z) => z * z;
        return Square(a) + Square(b);
    }
}

public partial class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public partial class Person
{
    public void PrintName()
    {
        Console.WriteLine($"Name: {FirstName} {LastName}");
    }
}