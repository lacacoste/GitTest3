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
catch (Exception)
{
    Console.WriteLine("Exception");
    //throw;
}
finally
{
    Console.WriteLine("Finiality");
}
Console.WriteLine("NExt step");

List<int> list = new List<int> { 5, 3, 4, 6, 8, 2, 3, 322, 211 };

// Query style
var resultSet = from li in list where li > 100 & li <300 select li;

//Method Style
var resultMethod = list.Where(list => list < 8 & list > 3).ToList();
var result2 = list.Where(list => list % 2 == 0).ToList();

foreach( var item in resultSet)
    Console.WriteLine( item);

foreach(var item in resultMethod)
    Console.WriteLine(item);

foreach (var item in result2)
    Console.WriteLine(item);

int[] aric = new int[] { 0, 0, 89, 29, 24, 17 };

Console.WriteLine(aric.Max() - aric.Min());
Console.WriteLine(aric.Max());
Console.WriteLine(aric.Min());

