namespace SimpleCalculatorLibrary
{
	public class SubtractionOperation : IOperation
	{
		public string sOperator {get{return "-";}}

		public Result apply(int iLeftOperand, int iRightOperand)
		{
			return new Result(iLeftOperand - iRightOperand);
		}
	}
}