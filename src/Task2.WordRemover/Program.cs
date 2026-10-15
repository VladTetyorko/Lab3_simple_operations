using Task2.WordRemover;
using Task2.WordRemover.Exceptions;
using Task2.WordRemover.Parsing;
using Task2.WordRemover.Validation;

const string EnterTextPrompt = "Enter any text:";
const string EnterCountPrompt = "Enter how many words to remove:";
const string InvalidCountMessage = "The number of words must be an integer.";
const string EmptyText = "";

Console.WriteLine(EnterTextPrompt);

string usersText = ReadLineOrEmpty();

Console.WriteLine(EnterCountPrompt);

string usersCount = ReadLineOrEmpty();

if (!WordCountValidator.IfInputIsValidCount(usersCount))
{
    Console.WriteLine(InvalidCountMessage);
    return;
}

WordRemoveService wordRemoveService = new WordRemoveService();

try
{
    Console.WriteLine(wordRemoveService.RemoveFirstWords(usersText, IntegerReader.Read(usersCount)));
}
catch (InvalidWordCountException exception)
{
    Console.WriteLine(exception.Message);
}

string ReadLineOrEmpty()
{
    string? enteredLine = Console.ReadLine();

    if (enteredLine == null)
    {
        return EmptyText;
    }

    return enteredLine;
}
