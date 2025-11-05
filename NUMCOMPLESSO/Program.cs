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
        Console.WriteLine($"{somma.R},{somma.IMG");
        var sottr = c1 - c2;
        Console.WriteLine($"{sottr.R},{sottr.IMG");
        var molt = c1 * c2;
        Console.WriteLine($"{molt.R},{molt.IMG}");
        var diviso = c1 / c2;
        Console.WriteLine($"{diviso.R},{diviso.IMG}");
    }
}
