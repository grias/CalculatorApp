using CalculatorApp;
using CalculatorApp.Operations;

internal class Program
{
    private static Calculator _calc = new Calculator();

    private static void Main(string[] args)
    {
        RegisterOperations();

        ProgramLooping();
    }

    private static void RegisterOperations()
    {
        _calc.RegisterOperation("+", new AddOperation());
        _calc.RegisterOperation("-", new SubtractOperation());
        _calc.RegisterOperation("*", new MultiplyOperation());
        _calc.RegisterOperation("/", new DivideOperation());
    }

    private static void ProgramLooping()
    {
        while (true)
        {
            ProgramLoop();

            Console.WriteLine("Press Escape to exit program. Press any key to continue.");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }

    private static void ProgramLoop()
    {
        double operand1 = RequestDoubleValueFormCommandPrompt("Enter first argument: ");
        string symbol = RequestOperationSymbolFromCommandPrompt();
        double operand2 = RequestDoubleValueFormCommandPrompt("Enter second argument: ");

        double result = _calc.ExecuteOperation(operand1, operand2, symbol);

        Console.WriteLine($"{result} = {operand1} {symbol} {operand2}");

    }

    private static string RequestOperationSymbolFromCommandPrompt()
    {
        string symbol;
        while (true)
        {
            Console.Write($"Enter operation ({string.Join(", ", _calc.GetRegisteredOperatorsSymbols().ToArray())}): ");
            symbol = Console.ReadLine() ?? "";
            if (_calc.CheckIfOperationSymbolRegistered(symbol))
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter registered operator.");
            }
        }
        return symbol;
    }

    private static double RequestDoubleValueFormCommandPrompt(string message)
    {
        double value;
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out value))
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter valid number.");
            }
        }
        return value;
    }
}