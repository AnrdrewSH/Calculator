using System;
using System.Collections.Generic;
using SimpleCalculatorLibrary;
using Xunit;

namespace SimpleCalculatorLibraryTests
{
	public class CalculatorTests
	{
		[Fact]
		static public void AdditionOperationTest()
		{
			int iResult = new Calculator(new List<IOperation>{
				new AdditionOperation()
			}).calculate("2+2").iValue;

			Assert.Equal(4, iResult);
		}
		
		[Fact]
		static public void SubtractionOperationTest()
		{
			int iResult = new Calculator(new List<IOperation>{
				new SubtractionOperation()
			}).calculate("2-3").iValue;

			Assert.Equal(-1, iResult);
		}
		
		[Fact]
		static public void MultiplicationOperationTest()
		{
			int iResult = new Calculator(new List<IOperation>{
				new MultiplicationOperation()
			}).calculate("2*3").iValue;

			Assert.Equal(6, iResult);
		}
		
		[Fact]
		static public void DivisionOperationTest()
		{
			int iResult = new Calculator(new List<IOperation>{
				new DivisionOperation()
			}).calculate("6/2").iValue;

			Assert.Equal(3, iResult);
		}
		
		[Fact]
		static public void ModuloDivisionOperationTest()
		{
			int iResult = new Calculator(new List<IOperation>{
				new ModuloDivisionOperation()
			}).calculate("6%4").iValue;

			Assert.Equal(2, iResult);
		}
		
		[Fact]
		static public void ExponentiationOperationTest()
		{
			int iResult = new Calculator(new List<IOperation>{
				new ExponentiationOperation()
			}).calculate("2**4").iValue;

			Assert.Equal(16, iResult);
		}
		
		[Fact]
		static public void PriorityOperationsTest()
		{
			int iResult = new Calculator(new List<IOperation>{
				new AdditionOperation(),
				new MultiplicationOperation()
			}).calculate("2*(2+2*2)").iValue;

			Assert.Equal(12, iResult);
		}
	}
}
