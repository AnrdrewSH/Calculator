using System;

namespace SimpleCalculatorLibrary
{
	public class ExponentiationOperation : IOperation
	{
		public string sOperator {get{return "**";}}

		public Result apply(int iLeftOperand, int iRightOperand)
		{
			return new Result((int)Math.Pow(iLeftOperand, iRightOperand));
		}
	}
}