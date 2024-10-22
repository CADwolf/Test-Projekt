using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    internal class Calculator
    {
	private int ReadNumber(bool AllowZero)
	{
	    int result = 0;
	    bool isvalid = false;
	    do
	    {
		Console.WriteLine("Geben sie eine zahl oder eine Klammer ein");
		ConsoleKeyInfo keyInfo = Console.ReadKey();
		char firstchar = keyInfo.KeyChar;
		if (firstchar == '(')
		{
		    string backup = UserInput;
		    UserInput = UserInput + " " + firstchar;
		    Console.WriteLine();
		    result = StartCalculation(')');
		    isvalid = true;
		    if (AllowZero == false && result == 0)
		    {
			isvalid = false;
			UserInput = backup;
		    }
		}
		else
		{
		    string benutzereingabe1 = Console.ReadLine();
		    benutzereingabe1 = firstchar + benutzereingabe1;
		    isvalid = int.TryParse(benutzereingabe1, out result);
		    if (AllowZero == false && result == 0)
		    {
			isvalid = false;
		    }
		    if (isvalid)
		    {
			UserInput = UserInput + " " + benutzereingabe1;
			Console.WriteLine();
		    }
		}
		if (isvalid == false)
		{
		    Console.WriteLine("Keine Güldige Zahl oder es wurde versucht durch 0 zu teilen");
		}
	    } while (!isvalid);
	    return result;
	}
	private int Calculate(int number1, int number2, char Operator)
	{
	    // 1. Welcher Operator?
	    // 2. Operator auswerten
	    int Result = 0;
	    // 3. Ergebnis zurückgeben
	    if (Operator == '+')
	    {
		Result = number1 + number2;
	    }
	    else if (Operator == '-')
	    {
		Result = number1 - number2;
	    }
	    else if (Operator == '*')
	    {
		Result = number1 * number2;
	    }
	    else if (Operator == '/')
	    {
		Result = number1 / number2;
	    }
	    else if (Operator == '!')
	    {
		Fakultät(Result);
	    }
	    return Result;
	}
	public int StartCalculation(char Endoperator)
	{
	    // 1. Zahl einlesen
	    int number1 = ReadNumber(true); // <--- Zahl wird eingelesen UserInput
	    int result = number1;
	    bool isarithmeticoperator;
	    do
	    {
		// 2. Operator einlesen
		char Operator;
		Operator = ReadOperator(Endoperator); // <--- Operator wird eingelesen UserInput
						      // 3. Ist Operator ein Rechen Operator?
						      // Ja : weiter mit 4.
						      // Nein : Ergebnis zurückgeben
		isarithmeticoperator = Operator != Endoperator;
		if (isarithmeticoperator)
		{
		    bool AllowZero = true;
		    // 4. ReadNumber
		    if (Operator == '/')
		    {
			AllowZero = false;
		    }
		    int number2 = ReadNumber(AllowZero); // <--- 2. Zahl wird eingelesen UserInput
							 // 5. Zwischenergebnis berechnen
		    result = Calculate(result, number2, Operator);
		    // 6. Zurück zu 2.
		    Console.WriteLine("Ergebnis: " + result);
		}
	    } while (isarithmeticoperator);
	    return result;
	}
	private char ReadOperator(char EndOperator)
	{
	    bool isOperatorValid = false;
	    char operatorEingabe;
	    do
	    {
		// Operator einlesen
		Console.WriteLine($"Tragen sie ein zeichen ein ( + , - , / , *, !) oder {EndOperator}");
		ConsoleKeyInfo keyInfo = Console.ReadKey();
		operatorEingabe = keyInfo.KeyChar;
		Console.WriteLine();
		// Zwischenergebnis berechnen
		if (operatorEingabe == '+')
		{
		    isOperatorValid = true;
		}
		else if (operatorEingabe == '-')
		{
		    isOperatorValid = true;
		}
		else if (operatorEingabe == '*')
		{
		    isOperatorValid = true;
		}
		else if (operatorEingabe == '/')
		{
		    isOperatorValid = true;
		}
		else if (operatorEingabe == EndOperator)
		{
		    isOperatorValid = true;
		}
		else if (operatorEingabe == '!')
		{
		    isOperatorValid = true;
		}
	    } while (!isOperatorValid);
	    UserInput = UserInput + " " + operatorEingabe;
	    return operatorEingabe;
	}
	private int Fakultät(int value)
	{
	    if (value < 0)
	    {
		return 1;
	    }
	    var result = 1;
	    for (var i = 2; i < value + 1; i++)
	    {
		result *= i;
	    }
	    return result;
	}
	public string UserInput { get; private set; }
    }
    internal class Program
    {
	static void Main(string[] args)
	{
	    Calculator calc = new Calculator();
	    int result = calc.StartCalculation('=');
	    string output = calc.UserInput + " " + result;
	    Console.WriteLine(output);
	    Console.ReadKey();
	}
    }
}