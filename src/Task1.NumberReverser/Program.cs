using Task1.NumberReverser;
using Task1.NumberReverser.Exceptions;

const string EmptyText = "";

Console.WriteLine("Enter an integer number:");

string? usersInput = Console.ReadLine();

if (usersInput == null)
{
    usersInput = EmptyText;
}

NumberReverseService numberReverseService = new NumberReverseService();

try
{
    Console.WriteLine(numberReverseService.ReverseNumber(usersInput));
}
catch (InvalidNumberException exception)
{
    Console.WriteLine(exception.Message);
}
