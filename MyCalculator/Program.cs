using System;

namespace MyCalculator
{

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello! Welcome to  console calculator.\n");
            Console.WriteLine("Enter an expression in the format: number1 operator number2 (for example, 2 + 2)");
            Console.WriteLine("Supported operators: +, -, *, /");
            Console.WriteLine("To get the result after the expression, press equals(=)");
            Console.WriteLine("Press Esc to exit app");
            Console.WriteLine("\nWrite an expression. If you made a mistake with your input, you can delete it by pressing the backspace button");

            Calculator calculator = new Calculator();

            while (true)
            {

                //Отслеживаем что вводит пользователь и записываем результат в переменную
               string expression = calculator.GetExpressionFromUser();

                //Проверяем чтобы пользователь вводил только один раз оператор
                int operatorCount = 0;
                foreach (char c in expression)
                {

                    if (c == '+' || c == '-' || c == '*' || c == '/')
                    {
                        operatorCount++;
                    }

                }
                if (operatorCount > 1)
                {
                    Console.WriteLine("\nInvalid expression.Only one operator is allowed.");
                    continue;
                }
                  if (operatorCount < 1)
                {
                    Console.WriteLine("\nInvalid expression.You need to write 2 numbers and 1 operator");
                    continue;
                }

                // Определяем какое будет дейсвтие
                char[] operators = { '+', '-', '*', '/' };
                char op = ' ';

                foreach (char oper in operators)
                {
                    if (expression.Contains(oper))
                    {
                        op = oper;
                        break;
                    }
                }

                if (op == ' ')
                {
                    Console.WriteLine("\nInvalid expression. No operator found.");
                    break;
                }

                //Делим  полученную строку от пользовтеля на 2 части и записываем в переменные, разделяя оператором
                string[] parts = expression.Split(op);
                double num1 = 0;
                double num2 = 0;
                if (!double.TryParse(parts[0], out num1) || !double.TryParse(parts[1], out num2))
                {
                    Console.WriteLine("\nInvalid expression. Incorrect number format.");
                    continue;
                }

                //Проводим вычисление и выводим пользавателю
                double result = calculator.DoOperation(num1,num2, op); 
                Console.WriteLine(result);
            }
        }
        }
    }
