using System;
using System.Collections.Generic;
using SimpleCalculatorLibrary;

namespace Lab2
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length < 1)
			{
				showMessage("[info]: please specify calculation string");
				return;
			}

			string sPassedString = args[0];

			/*
				Calculator initialization.
			*/
			ICalculator calculator = new Calculator(new List<IOperation>{
				new AdditionOperation(),
				new SubtractionOperation(),
				new MultiplicationOperation(),
				new DivisionOperation(),
				new ModuloDivisionOperation(),
				new ExponentiationOperation()
			});
			
			/*
				Calculations based on the passed string.
			*/
			Result result = calculator.calculate(sPassedString);

			if (result.iCode != 0)
			{
				showMessage($"[error]: {result.sMessage}..");
				return;
			}
			
			showMessage($"[result]: {result.iValue}");
		}
		static void showMessage(string sMessage) {Console.WriteLine("\n" + sMessage);}
	}
}
