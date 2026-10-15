using Task4.TextMasker;

const string EnterTextPrompt = "Enter any text:";
const string EmptyText = "";

Console.WriteLine(EnterTextPrompt);

string? usersText = Console.ReadLine();

if (usersText == null)
{
    usersText = EmptyText;
}

TextMaskService textMaskService = new TextMaskService();

Console.WriteLine(textMaskService.Mask(usersText));
