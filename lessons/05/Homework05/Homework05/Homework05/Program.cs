﻿using System;

namespace Homework05
{
    class Program
    {
		// Список фигур
		enum Figure { Сircle=1,	Triangle, Rectangle }

		static void Main(string[] args)
		{
			var accuracyCalculations=-1;
			while (accuracyCalculations < 0 || accuracyCalculations > 10)
			{ 
				accuracyCalculations = (int)ReadDouble("точность расчётов (количество знаков после запятой (от 0 до 10)):", 0);
			}

			Console.WriteLine("Список фигур:\n1. Круг,\n2. Равносторонний треугольник,\n3. Прямоугольник.");
			var figure = (Figure)ReadDouble("номер фигуры:", 0);

			switch (figure)
            {
				case Figure.Сircle:
                    Console.WriteLine("Выбрана окружность:");
					double r = ReadDouble("радиус:", accuracyCalculations);
					Console.WriteLine($"Длина окружности: {Math.Round(2.0 * Math.PI * r, accuracyCalculations, MidpointRounding.AwayFromZero)}");
					Console.WriteLine($"Площадь окружности: {Math.Round(Math.PI * r * r, accuracyCalculations, MidpointRounding.AwayFromZero)}");
					break;
				case Figure.Triangle:
					Console.WriteLine("Выбран равносторонний треугольник:");
					double a = ReadDouble("длину стороны:", accuracyCalculations);
					Console.WriteLine($"Периметр треугольника: {Math.Round(3.0*a, accuracyCalculations, MidpointRounding.AwayFromZero)}");
					Console.WriteLine($"Площадь треугольника: {Math.Round(a*a*Math.Sqrt(3)/4, accuracyCalculations, MidpointRounding.AwayFromZero)}");
					break;
				case Figure.Rectangle:
					Console.WriteLine("Выбран прямоугольник:");
					double b1 = ReadDouble("длину 1-й стороны:", accuracyCalculations);
					double b2 = ReadDouble("длину 2-й стороны:", accuracyCalculations);
					Console.WriteLine($"Периметр прямоугольника: {Math.Round(2.0*(b1+b2), accuracyCalculations, MidpointRounding.AwayFromZero)}");
					Console.WriteLine($"Площадь прямоугольника: {Math.Round(b1*b2, accuracyCalculations, MidpointRounding.AwayFromZero)}");
					break;
				default:
					WriteWithColor("Не удалось выбрать фигуру.", ConsoleColor.Red);
					break;
            }
		}

		// Метод для ввода значения double с указанием кол-ва знаков после запятой и проверкой значений
		static double ReadDouble(string name, int accuracy)
		{
			for ( ; ; )
			{
				try
				{
					Console.WriteLine($"Введите {name}");
					return Math.Round(double.Parse(Console.ReadLine()), accuracy, MidpointRounding.AwayFromZero);
				}
				catch (ArgumentNullException exception)
				{
					WriteWithColor("Пожалуйста, введите число корректно.\n" + exception.Message, ConsoleColor.Red);
				}
				catch (FormatException exception)
				{
					WriteWithColor("Не удаётся распознать число. Пожалуйста, введите число корректно.\n" + exception.Message, ConsoleColor.Red);
				}
				catch (OverflowException exception)
				{
					WriteWithColor("Введенное значение выходит за пределы допустимых.\n" +
								   "Пожалуйста введите значение в пределах от " + double.MinValue + " до " + double.MaxValue + ".\n" +
								   exception.Message, ConsoleColor.Red);
				}
			}
		}

		// Метод для вывода цветного сообщения
		static void WriteWithColor(string message, ConsoleColor color)
		{
			var restoreColor = Console.ForegroundColor;
			Console.ForegroundColor = color;
			Console.WriteLine(message);
			Console.ForegroundColor = restoreColor;
		}

	}
}
