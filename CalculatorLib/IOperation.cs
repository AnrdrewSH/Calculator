namespace SimpleCalculatorLibrary
{
	public interface IOperation
	{
		string sOperator {get;}

		Result apply(int iLeftOperand, int iRightOperand);
	}
}
