// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine(4+5);
Console.WriteLine("Added ANOTHER COMMIT");

string str = "New code in the Vova branch";
int i = 0;
int b = 4;
try
{
    Console.WriteLine(b / i);
}
catch (DivideByZeroException)
{
    Console.WriteLine("Catch");
    //throw;
}
Console.WriteLine("NExt step");