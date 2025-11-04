using ClassLibrary1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("inserisci primo num complesso");
        NumeroComplesso c1 = NumeroComplesso.Parse(Console.ReadLine());
        Console.WriteLine("inserisci secondo num complesso");
        NumeroComplesso c2 = NumeroComplesso.Parse(Console.ReadLine());
        var somma = c1 + c2;
        Console.WriteLine($"{somma}");
        var sottr = c1 - c2;
        Console.WriteLine($"{sottr}");
        var molt = c1 * c2;
        Console.WriteLine($"{molt}");
        var diviso = c1 / c2;
        Console.WriteLine($"{diviso}");
    }
}
