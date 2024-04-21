using System;


namespace MyCalculator;

    public class Calculator {

    public string GetExpressionFromUser()
    {
        string expression = "";
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("\nThank you for using the calculator!");
                Environment.Exit(0);
            }

            if (key.Key == ConsoleKey.Enter)
            {
                Console.Write("=");
                break;
            }

            else if (key.KeyChar == '=')
            {
                Console.Write("=");
                break;
            }

            else if (key.Key == ConsoleKey.Backspace && expression.Length > 0)
            {
                expression = expression.Remove(expression.Length - 1);
                Console.Write("\b \b");
            }
            else if (char.IsDigit(key.KeyChar) || "+-*/".Contains(key.KeyChar))
            {
                expression += key.KeyChar;
                Console.Write(key.KeyChar);
            }
        }
        return expression;
    }

    public double DoOperation(double num1, double num2, char op)
    {
        double result = 0;
            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 == 0)
                    {
                        Console.WriteLine("\nYou can't divide by 0. Try again.");
                    return double.NaN;

                }
                    result = num1 / num2;
                    break;
            }
            return result;
        }
}
