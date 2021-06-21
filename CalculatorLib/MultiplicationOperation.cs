namespace SimpleCalculatorLibrary
{
	public class MultiplicationOperation : IOperation
	{
		public string sOperator {get{return "*";}}

		public Result apply(int iLeftOperand, int iRightOperand)
		{
			return new Result(iLeftOperand * iRightOperand);
		}
	}
}