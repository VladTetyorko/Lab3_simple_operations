using Task3.ShapeArea;
using Task3.ShapeArea.Exceptions;
using Task3.ShapeArea.Formatting;
using Task3.ShapeArea.Parsing;
using Task3.ShapeArea.Validation;

const string MenuHeader = "Which area do you want to calculate?";
const string SquareOption = "1 - Square";
const string CircleOption = "2 - Circle";
const string RectangleOption = "3 - Rectangle";
const string TriangleOption = "4 - Triangle";
const string SquareChoice = "1";
const string CircleChoice = "2";
const string RectangleChoice = "3";
const string TriangleChoice = "4";
const string EnterSidePrompt = "Enter the side:";
const string EnterRadiusPrompt = "Enter the radius:";
const string EnterWidthPrompt = "Enter the width:";
const string EnterHeightPrompt = "Enter the height:";
const string EnterBasePrompt = "Enter the base:";
const string UnknownChoiceMessage = "Choose a number between 1 and 4.";
const string InvalidDimensionInputMessage = "A dimension must be a number, for example 2.5 or 2,5.";
const string EmptyText = "";

Console.WriteLine(MenuHeader);
Console.WriteLine(SquareOption);
Console.WriteLine(CircleOption);
Console.WriteLine(RectangleOption);
Console.WriteLine(TriangleOption);

string usersChoice = ReadLineOrEmpty();

ShapeAreaService shapeAreaService = new ShapeAreaService();

try
{
    switch (usersChoice)
    {
        case SquareChoice:
        {
            double side = ReadDimension(EnterSidePrompt);

            Console.WriteLine(AreaFormatter.Format(shapeAreaService.SquareArea(side)));
            break;
        }
        case CircleChoice:
        {
            double radius = ReadDimension(EnterRadiusPrompt);

            Console.WriteLine(AreaFormatter.Format(shapeAreaService.CircleArea(radius)));
            break;
        }
        case RectangleChoice:
        {
            double width = ReadDimension(EnterWidthPrompt);
            double height = ReadDimension(EnterHeightPrompt);

            Console.WriteLine(AreaFormatter.Format(shapeAreaService.RectangleArea(width, height)));
            break;
        }
        case TriangleChoice:
        {
            double baseLength = ReadDimension(EnterBasePrompt);
            double height = ReadDimension(EnterHeightPrompt);

            Console.WriteLine(AreaFormatter.Format(shapeAreaService.TriangleArea(baseLength, height)));
            break;
        }
        default:
        {
            Console.WriteLine(UnknownChoiceMessage);
            break;
        }
    }
}
catch (InvalidDimensionException exception)
{
    Console.WriteLine(exception.Message);
}

double ReadDimension(string prompt)
{
    Console.WriteLine(prompt);

    string enteredDimension = ReadLineOrEmpty();

    if (!DimensionValidator.IfInputIsValidDimension(enteredDimension))
    {
        throw new InvalidDimensionException(InvalidDimensionInputMessage);
    }

    return DecimalReader.Read(enteredDimension);
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
