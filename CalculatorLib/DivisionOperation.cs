namespace SimpleCalculatorLibrary
{
	public class DivisionOperation : IOperation
	{
		public string sOperator {get{return "/";}}

		public Result apply(int iLeftOperand, int iRightOperand)
		{
			if (iRightOperand == 0)
				return new Result(1, "division by zero");

			return new Result((int)iLeftOperand / iRightOperand);
		}
	}
}